using DAANAY.Data;
using DAANAY.Models;
using DAANAY.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DAANAY.Controllers;

public class AdminController : Controller
{
    [HttpGet]
    public IActionResult Dashboard()
    {
        ViewBag.ProductCount = SampleData.Products.Count;
        ViewBag.CategoryCount = SampleData.Categories.Count;
        ViewBag.OrderCount = SampleData.Orders.Count;
        ViewBag.CustomerCount = SampleData.Customers.Count;
        ViewBag.PendingOrders = SampleData.Orders.Count(o => o.Status == "Pending");
        ViewBag.LowStock = SampleData.Products.Count(p => p.Stock < 15);
        return View();
    }

    [HttpGet]
    public IActionResult Products()
    {
        return View(SampleData.Products);
    }

    [HttpGet]
    public IActionResult CreateProduct()
    {
        LoadCategories();
        return View(new ProductFormViewModel());
    }

    [HttpPost]
    public IActionResult CreateProduct(ProductFormViewModel model)
    {
        LoadCategories();
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var category = SampleData.Categories.FirstOrDefault(c => c.Id == model.CategoryId);
        var nextId = SampleData.Products.Max(p => p.Id) + 1;
        SampleData.Products.Add(new Product
        {
            Id = nextId,
            Name = model.Name,
            Description = model.Description,
            Price = model.Price,
            Stock = model.Stock,
            CategoryId = model.CategoryId,
            CategoryName = category?.Name ?? "Uncategorized",
            Unit = model.Unit
        });

        TempData["Message"] = "Product created (sample data).";
        return RedirectToAction(nameof(Products));
    }

    [HttpGet]
    public IActionResult EditProduct(int id)
    {
        var product = SampleData.Products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return NotFound();
        }

        LoadCategories();
        return View(new ProductFormViewModel
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Stock = product.Stock,
            CategoryId = product.CategoryId,
            Unit = product.Unit
        });
    }

    [HttpPost]
    public IActionResult EditProduct(ProductFormViewModel model)
    {
        LoadCategories();
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var product = SampleData.Products.FirstOrDefault(p => p.Id == model.Id);
        if (product == null)
        {
            return NotFound();
        }

        var category = SampleData.Categories.FirstOrDefault(c => c.Id == model.CategoryId);
        product.Name = model.Name;
        product.Description = model.Description;
        product.Price = model.Price;
        product.Stock = model.Stock;
        product.CategoryId = model.CategoryId;
        product.CategoryName = category?.Name ?? product.CategoryName;
        product.Unit = model.Unit;

        TempData["Message"] = "Product updated (sample data).";
        return RedirectToAction(nameof(Products));
    }

    [HttpPost]
    public IActionResult DeleteProduct(int id)
    {
        var product = SampleData.Products.FirstOrDefault(p => p.Id == id);
        if (product != null)
        {
            SampleData.Products.Remove(product);
            TempData["Message"] = "Product deleted (sample data).";
        }

        return RedirectToAction(nameof(Products));
    }

    [HttpGet]
    public IActionResult Categories()
    {
        return View(SampleData.Categories);
    }

    [HttpGet]
    public IActionResult CreateCategory()
    {
        return View(new CategoryFormViewModel());
    }

    [HttpPost]
    public IActionResult CreateCategory(CategoryFormViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var nextId = SampleData.Categories.Max(c => c.Id) + 1;
        SampleData.Categories.Add(new Category
        {
            Id = nextId,
            Name = model.Name,
            Description = model.Description
        });

        TempData["Message"] = "Category created (sample data).";
        return RedirectToAction(nameof(Categories));
    }

    [HttpGet]
    public IActionResult Orders()
    {
        return View(SampleData.Orders.OrderByDescending(o => o.OrderDate).ToList());
    }

    [HttpGet]
    public IActionResult OrderDetails(int id)
    {
        var order = SampleData.Orders.FirstOrDefault(o => o.Id == id);
        if (order == null)
        {
            return NotFound();
        }

        ViewBag.Statuses = SampleData.OrderStatuses;
        return View(order);
    }

    [HttpPost]
    public IActionResult UpdateOrderStatus(int id, string status)
    {
        var order = SampleData.Orders.FirstOrDefault(o => o.Id == id);
        if (order != null && SampleData.OrderStatuses.Contains(status))
        {
            order.Status = status;
            TempData["Message"] = $"Order #{id} status set to {status}.";
        }

        return RedirectToAction(nameof(OrderDetails), new { id });
    }

    [HttpGet]
    public IActionResult Customers()
    {
        return View(SampleData.Customers);
    }

    [HttpGet]
    public IActionResult Inventory()
    {
        return View(SampleData.Products.OrderBy(p => p.Stock).ToList());
    }

    private void LoadCategories()
    {
        ViewBag.Categories = new SelectList(SampleData.Categories, "Id", "Name");
    }
}
