using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StackUp.Application.ApplicationServices.Services;
using StackUp.Application.DTOs;

namespace StackUp.UI.Controllers;

[Authorize]

public class CategoriesController : Controller
{
    private readonly CategoryService _categoryService;

    public CategoriesController(CategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
    {
        var categories = await _categoryService.GetAllCategoriesAsync();

        var categoriesToDisplay = categories.Select(c => new CategoryDTO
        {
            Id = c.Id,
            CategoryName = c.CategoryName,
            ParentId = c.ParentId,
            ParentName = c.ParentId.HasValue ? categories.FirstOrDefault(p => p.Id == c.ParentId)?.CategoryName : "No Parent"
        }).Skip((page - 1) * pageSize).Take(pageSize).ToList();

        var totalCategories = categories.Count();

        ViewBag.CurrentPage = page;
        ViewBag.PageSize = pageSize;
        ViewBag.TotalPages = (int)Math.Ceiling(totalCategories / (double)pageSize);

        return View(categoriesToDisplay);
    }



    public async Task<IActionResult> Details(int id)
    {
        var category = await _categoryService.GetCategoryByIdAsync(id);
        if (category == null)
        {
            return NotFound();
        }
        return View(category);
    }

    public async Task<IActionResult> Create()
    {
        var categories = await _categoryService.GetAllCategoriesAsync();
        ViewBag.ParentCategories = new SelectList(categories, "Id", "CategoryName");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CategoryDTO category)
    {
        var categories = await _categoryService.GetAllCategoriesAsync();
        ViewBag.ParentCategories = new SelectList(categories, "Id", "CategoryName");
        if (ModelState.IsValid)
        {
            await _categoryService.AddCategoryAsync(category);
            return RedirectToAction(nameof(Index));
        }
        return View(category);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var category = await _categoryService.GetCategoryByIdAsync(id);
        if (category == null)
        {
            return NotFound();
        }
        var categories = await _categoryService.GetAllCategoriesAsync();
        ViewBag.ParentCategories = new SelectList(categories, "Id", "CategoryName", category.ParentId);
        return View(category);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(CategoryDTO category)
    {

        if (ModelState.IsValid)
        {
            await _categoryService.UpdateCategoryAsync(category);
            return RedirectToAction(nameof(Index));
        }
        var categories = await _categoryService.GetAllCategoriesAsync();
        ViewBag.ParentCategories = new SelectList(categories, "Id", "CategoryName", category.ParentId);
        return View(category);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        if (id < 1)
        {
            return RedirectToAction(nameof(Index));
        }
        await _categoryService.RemoveCategoryAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
