// HomeController.cs
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StackUp.Application.DTOs;
using StackUp.Domain.Entities.IdentityEntites;
using StackUp.Infrastructure.Persistence;
using StackUp.UI.ViewModels;
using System.Globalization;

namespace StackUp.UI.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly InventoryDbContext _context;
    private readonly UserManager<AppUser> _userManager;
    private readonly IAntiforgery _antiforgery;

    public HomeController(InventoryDbContext context, UserManager<AppUser> userManager, IAntiforgery antiforgery)
    {
        _context = context;
        _userManager = userManager;
        _antiforgery = antiforgery;
    }

    public async Task<IActionResult> Index()
    {
        var model = new HomeViewModel();

        model.UserCount = await _userManager.Users.CountAsync();
        model.SuppliersCount = await _context.Suppliers.CountAsync();
        model.TotalOrdersCount = await _context.Orders.CountAsync();

        model.TotalSoldProductsPrice = await _context.Orders
            .Join(_context.Products,
                  o => o.ProductId,
                  p => p.Id,
                  (o, p) => new { o, p })
            .SumAsync(x => x.o.Quantity * x.p.SellingPrice);

        model.MostSoldProducts = await _context.Orders
            .Join(_context.Products,
                  o => o.ProductId,
                  p => p.Id,
                  (o, p) => new { o, p })
            .GroupBy(x => new { x.p.Id, x.p.ProductName })
            .Select(g => new MostSoldProductDTO
            {
                ProductId = g.Key.Id,
                ProductName = g.Key.ProductName,
                QuantitySold = g.Sum(x => x.o.Quantity)
            })
            .OrderByDescending(p => p.QuantitySold)
            .Take(5)
            .ToListAsync();

        var today = DateTime.UtcNow;
        var startMonth = new DateTime(today.Year, today.Month, 1).AddMonths(-11);
        var endMonth = new DateTime(today.Year, today.Month, 1).AddMonths(1).AddDays(-1);

        var last12Months = Enumerable.Range(0, 12)
            .Select(i => startMonth.AddMonths(i))
            .ToList();

        var monthlySalesData = await _context.Orders
            .Where(o => o.OrderDate >= startMonth && o.OrderDate <= endMonth)
            .GroupBy(o => new { o.OrderDate.Year, o.OrderDate.Month })
            .Select(g => new
            {
                Year = g.Key.Year,
                Month = g.Key.Month,
                QuantitySold = g.Sum(o => o.Quantity)
            })
            .ToListAsync();

        model.MonthlyProductSales = last12Months.Select(m => new MonthlyProductSalesDTO
        {
            Month = m.ToString("MM/yyyy", CultureInfo.InvariantCulture),
            QuantitySold = monthlySalesData
                .Where(ms => ms.Year == m.Year && ms.Month == m.Month)
                .Sum(ms => ms.QuantitySold)
        }).ToList();

        model.RecentOrders = await _context.Orders
            .Include(o => o.Customer)
            .Include(o => o.Supplier)
            .OrderByDescending(o => o.OrderDate)
            .Take(5)
            .Select(o => new OrderDTO
            {
                Id = o.Id,
                OrderNumber = o.OrderNumber,
                CustomerName = o.Customer.CustomerName,
                SupplierName = o.Supplier.SupplierName,
                OrderDate = o.OrderDate
            })
            .ToListAsync();

        model.RecentSuppliers = await _context.Suppliers
            .OrderByDescending(s => s.CreatedAt)
            .Take(5)
            .Select(s => new SupplierDTO
            {
                Id = s.Id,
                SupplierName = s.SupplierName,
                Email = s.ContactInfo.Email,
                Phone = s.ContactInfo.Phone
            })
            .ToListAsync();

        ViewData["AntiforgeryToken"] = _antiforgery.GetAndStoreTokens(HttpContext).RequestToken;

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteOrder([FromBody] DeleteRequest request)
    {
        if (request == null || request.Id < 1)
        {
            return Json(new { success = false, message = "Invalid Order ID." });
        }

        var order = await _context.Orders
            .FirstOrDefaultAsync(o => o.Id == request.Id);

        if (order == null)
        {
            return Json(new { success = false, message = "Order not found." });
        }

        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();

        return Json(new { success = true });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteSupplier([FromBody] DeleteRequest request)
    {
        if (request == null || request.Id < 1)
        {
            return Json(new { success = false, message = "Invalid Supplier ID." });
        }

        var supplier = await _context.Suppliers
            .FirstOrDefaultAsync(s => s.Id == request.Id);

        if (supplier == null)
        {
            return Json(new { success = false, message = "Supplier not found." });
        }

        _context.Suppliers.Remove(supplier);
        await _context.SaveChangesAsync();

        return Json(new { success = true });
    }

    public class DeleteRequest
    {
        public int Id { get; set; }
    }
}
