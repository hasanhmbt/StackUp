using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StackUp.Application.ApplicationServices.Services;
using StackUp.Application.DTOs;

namespace StackUp.UI.Controllers;

[Authorize]

public class CustomersController : Controller
{
    private readonly CustomerService _customerService;

    public CustomersController(CustomerService customerService)
    {
        _customerService = customerService;
    }

    public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
    {
        var customers = await _customerService.GetAllCustomersAsync();
        var customersToDisplay = customers
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        var totalCustomers = customers.Count();

        ViewBag.CurrentPage = page;
        ViewBag.PageSize = pageSize;
        ViewBag.TotalPages = (int)Math.Ceiling(totalCustomers / (double)pageSize);

        return View(customersToDisplay);
    }

    public async Task<IActionResult> Details(int id)
    {
        var customer = await _customerService.GetCustomerByIdAsync(id);
        if (customer == null)
        {
            return NotFound();
        }
        return View(customer);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CustomerDTO customer)
    {
        if (ModelState.IsValid)
        {
            await _customerService.AddCustomerAsync(customer);
            return RedirectToAction(nameof(Index));
        }
        return View(customer);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var customer = await _customerService.GetCustomerByIdAsync(id);
        if (customer == null)
        {
            return NotFound();
        }
        return View(customer);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(CustomerDTO customer)
    {
        if (ModelState.IsValid)
        {
            await _customerService.UpdateCustomerAsync(customer);
            return RedirectToAction(nameof(Index));
        }
        return View(customer);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        if (id < 1)
        {
            return RedirectToAction(nameof(Index));
        }
        await _customerService.RemoveCustomerAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
