using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StackUp.Application.ApplicationServices.Services;
using StackUp.Application.DTOs;

namespace StackUp.UI.Controllers;

[Authorize]

public class SuppliersController : Controller
{
    private readonly SupplierService _supplierService;

    public SuppliersController(SupplierService supplierService)
    {
        _supplierService = supplierService;
    }

    public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
    {
        var suppliers = await _supplierService.GetAllSuppliersAsync();
        var suppliersToDisplay = suppliers
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        var totalSuppliers = suppliers.Count();

        ViewBag.CurrentPage = page;
        ViewBag.PageSize = pageSize;
        ViewBag.TotalPages = (int)Math.Ceiling(totalSuppliers / (double)pageSize);

        return View(suppliersToDisplay);
    }

    public async Task<IActionResult> Details(int id)
    {
        var supplier = await _supplierService.GetSupplierByIdAsync(id);
        if (supplier == null)
        {
            return NotFound();
        }
        return View(supplier);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(SupplierDTO supplier)
    {
        if (ModelState.IsValid)
        {
            await _supplierService.AddSupplierAsync(supplier);
            return RedirectToAction(nameof(Index));
        }
        return View(supplier);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var supplier = await _supplierService.GetSupplierByIdAsync(id);
        if (supplier == null)
        {
            return NotFound();
        }
        return View(supplier);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(SupplierDTO supplier)
    {
        if (ModelState.IsValid)
        {
            await _supplierService.UpdateSupplierAsync(supplier);
            return RedirectToAction(nameof(Index));
        }
        return View(supplier);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        if (id < 1)
        {
            return RedirectToAction(nameof(Index));
        }
        await _supplierService.RemoveSupplierAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
