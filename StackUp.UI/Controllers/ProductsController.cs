using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StackUp.Application.ApplicationServices.Services;
using StackUp.Application.DTOs;

namespace StackUp.UI.Controllers;

[Authorize]

public class ProductsController : Controller
{
    #region Dependencies

    private readonly ProductService _productService;
    private readonly CategoryService _categoryService;
    private readonly SupplierService _supplierService;
    private readonly IWebHostEnvironment _webHostEnvironment;
    public ProductsController(
        ProductService productRepository,
        CategoryService categoryRepository,
        SupplierService supplierRepository,
        IWebHostEnvironment webHostEnvironment)
    {

        _productService = productRepository;
        _categoryService = categoryRepository;
        _supplierService = supplierRepository;
        _webHostEnvironment = webHostEnvironment;
    }

    #endregion


    public async Task<IActionResult> Index(string ProductName, List<int> CategoryIds, List<int> SupplierIds, int page = 1, int pageSize = 10)
    {

        IEnumerable<ProductDTO> products;

        if (!string.IsNullOrEmpty(ProductName) || (CategoryIds != null && CategoryIds.Any()) || (SupplierIds != null && SupplierIds.Any()))
        {
            products = await _productService.GetFilteredProductsAsync(ProductName, CategoryIds, SupplierIds);
        }
        else
        {
            products = await _productService.GetAllProductsAsync();
        }
        var totalProducts = products.Count();
        var productsToDisplay = products
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        var categories = await _categoryService.GetAllCategoriesAsync();
        var suppliers = await _supplierService.GetAllSuppliersAsync();

        ViewBag.Categories = categories;
        ViewBag.Suppliers = suppliers;
        ViewBag.CurrentProductName = ProductName;
        ViewBag.SelectedCategoryIds = CategoryIds ?? new List<int>();
        ViewBag.SelectedSupplierIds = SupplierIds ?? new List<int>();

        ViewBag.CurrentPage = page;
        ViewBag.PageSize = pageSize;
        ViewBag.TotalPages = (int)Math.Ceiling(totalProducts / (double)pageSize);
        return View(productsToDisplay);
    }


    public async Task<IActionResult> Details(int id)
    {
        ViewBag.Categories = await _categoryService.GetAllCategoriesAsync();
        ViewBag.Suppliers = await _supplierService.GetAllSuppliersAsync();

        var product = await _productService.GetProductByIdAsync(id);
        return View(product);
    }


    public async Task<IActionResult> Create()
    {
        var categories = await _categoryService.GetAllCategoriesAsync();
        var suppliers = await _supplierService.GetAllSuppliersAsync();

        ViewBag.Categories = new SelectList(categories, "Id", "CategoryName");
        ViewBag.Suppliers = new SelectList(suppliers, "Id", "SupplierName");

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ProductDTO product)
    {
        if (ModelState.IsValid)
        {
            if (product.ImageFile != null && product.ImageFile.Length > 0)
            {
                string uniqueFileName = await SaveImageFileAsync(product.ImageFile);
                product.ImageUrl = uniqueFileName;
            }
            await _productService.AddProductAsync(product);
            return RedirectToAction(nameof(Index));
        }

        var categories = await _categoryService.GetAllCategoriesAsync();
        var suppliers = await _supplierService.GetAllSuppliersAsync();

        ViewBag.Categories = new SelectList(categories, "Id", "CategoryName");
        ViewBag.Suppliers = new SelectList(suppliers, "Id", "SupplierName");

        return View(product);
    }



    public async Task<IActionResult> Edit(int id)
    {
        var product = await _productService.GetProductByIdAsync(id);
        var categories = await _categoryService.GetAllCategoriesAsync();
        var suppliers = await _supplierService.GetAllSuppliersAsync();
        ViewBag.Categories = new SelectList(categories, "Id", "CategoryName");
        ViewBag.Suppliers = new SelectList(suppliers, "Id", "SupplierName");
        return View(product);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(ProductDTO product)
    {
        var categories = await _categoryService.GetAllCategoriesAsync();
        var suppliers = await _supplierService.GetAllSuppliersAsync();
        ViewBag.Categories = new SelectList(categories, "Id", "CategoryName");
        ViewBag.Suppliers = new SelectList(suppliers, "Id", "SupplierName");

        if (ModelState.IsValid)
        {
            if (product.ImageFile != null && product.ImageFile.Length > 0)
            {
                string uniqueFileName = await SaveImageFileAsync(product.ImageFile);
                product.ImageUrl = uniqueFileName;
            }
            await _productService.UpdateProductAsync(product);
            return RedirectToAction(nameof(Index));
        }
        return View(product);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        if (id < 1)
        {
            return RedirectToAction(nameof(Index));
        }
        await _productService.DeleteProductAsync(id);
        return RedirectToAction(nameof(Index));
    }






    private async Task<string> SaveImageFileAsync(IFormFile imageFile)
    {
        string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");

        if (!Directory.Exists(uploadsFolder))
        {
            Directory.CreateDirectory(uploadsFolder);
        }

        string uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;

        string filePath = Path.Combine(uploadsFolder, uniqueFileName);

        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await imageFile.CopyToAsync(fileStream);
        }

        return "/uploads/" + uniqueFileName;
    }






}
