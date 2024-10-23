using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StackUp.Application.ApplicationServices.Services;
using StackUp.Application.DTOs;

namespace StackUp.UI.Controllers;

[Authorize]

public class OrdersController : Controller
{

    #region Dependencies

    private readonly OrderService _orderService;
    private readonly SupplierService _supplierService;
    private readonly CustomerService _customerService;
    private readonly ProductService _productService;

    public OrdersController(
        OrderService orderService,
        SupplierService supplierService,
        CustomerService customerService,
        ProductService productService)
    {
        _orderService = orderService;
        _supplierService = supplierService;
        _customerService = customerService;
        _productService = productService;
    }
    #endregion

    public async Task<IActionResult> Index(string orderNumber, List<int> supplierIds, List<int> customerIds, int page = 1, int pageSize = 10)
    {
        IEnumerable<OrderDTO> orders;

        if (!string.IsNullOrEmpty(orderNumber) || (supplierIds != null && supplierIds.Any()) || (customerIds != null && customerIds.Any()))
        {
            orders = await _orderService.GetFilteredOrdersAsync(orderNumber, supplierIds, customerIds);
        }
        else
        {
            orders = await _orderService.GetAllOrdersAsync();
        }

        var totalOrders = orders.Count();
        var ordersToDisplay = orders
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        var suppliers = await _supplierService.GetAllSuppliersAsync();
        var customers = await _customerService.GetAllCustomersAsync();
        var products = await _productService.GetAllProductsAsync();

        ViewBag.Suppliers = suppliers;
        ViewBag.Customers = customers;
        ViewBag.Products = products;
        ViewBag.CurrentOrderNumber = orderNumber;
        ViewBag.SelectedSupplierIds = supplierIds ?? new List<int>();
        ViewBag.SelectedCustomerIds = customerIds ?? new List<int>();

        ViewBag.CurrentPage = page;
        ViewBag.PageSize = pageSize;
        ViewBag.TotalPages = (int)Math.Ceiling(totalOrders / (double)pageSize);

        return View(ordersToDisplay);
    }


    public async Task<IActionResult> Details(int id)
    {
        var order = await _orderService.GetOrderByIdAsync(id);
        if (order == null)
        {
            return NotFound();
        }
        return View(order);
    }

    public async Task<IActionResult> Create()
    {
        var suppliers = await _supplierService.GetAllSuppliersAsync();
        var customers = await _customerService.GetAllCustomersAsync();
        var products = await _productService.GetAllProductsAsync();

        ViewBag.Suppliers = new SelectList(suppliers, "Id", "SupplierName");
        ViewBag.Customers = new SelectList(customers, "Id", "CustomerName");
        ViewBag.Products = new SelectList(products, "Id", "ProductName");

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(OrderDTO order)
    {
        if (ModelState.IsValid)
        {
            await _orderService.AddOrderAsync(order);
            return RedirectToAction(nameof(Index));
        }

        var suppliers = await _supplierService.GetAllSuppliersAsync();
        var customers = await _customerService.GetAllCustomersAsync();
        var products = await _productService.GetAllProductsAsync();

        ViewBag.Suppliers = new SelectList(suppliers, "Id", "SupplierName");
        ViewBag.Customers = new SelectList(customers, "Id", "CustomerName");
        ViewBag.Products = new SelectList(products, "Id", "ProductName");

        return View(order);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var order = await _orderService.GetOrderByIdAsync(id);
        if (order == null)
        {
            return NotFound();
        }

        var suppliers = await _supplierService.GetAllSuppliersAsync();
        var customers = await _customerService.GetAllCustomersAsync();
        var products = await _productService.GetAllProductsAsync();

        ViewBag.Suppliers = new SelectList(suppliers, "Id", "SupplierName");
        ViewBag.Customers = new SelectList(customers, "Id", "CustomerName");
        ViewBag.Products = new SelectList(products, "Id", "ProductName");

        return View(order);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(OrderDTO order)
    {
        if (ModelState.IsValid)
        {
            await _orderService.UpdateOrderAsync(order);
            return RedirectToAction(nameof(Index));
        }

        var suppliers = await _supplierService.GetAllSuppliersAsync();
        var customers = await _customerService.GetAllCustomersAsync();
        var products = await _productService.GetAllProductsAsync();

        ViewBag.Suppliers = new SelectList(suppliers, "Id", "SupplierName");
        ViewBag.Customers = new SelectList(customers, "Id", "CustomerName");
        ViewBag.Products = new SelectList(products, "Id", "ProductName");

        return View(order);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        if (id < 1)
        {
            return RedirectToAction(nameof(Index));
        }
        await _orderService.RemoveOrderAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
