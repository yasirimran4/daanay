using DAANAY.Data;
using Microsoft.AspNetCore.Mvc;

namespace DAANAY.Controllers;

public class ProductsController : Controller
{
    [HttpGet]
    public IActionResult Index(string? search, int? categoryId)
    {
        var products = SampleData.Products.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            products = products.Where(p =>
                p.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                p.Description.Contains(search, StringComparison.OrdinalIgnoreCase));
        }

        if (categoryId is > 0)
        {
            products = products.Where(p => p.CategoryId == categoryId);
        }

        ViewBag.Search = search ?? string.Empty;
        ViewBag.CategoryId = categoryId;
        ViewBag.Categories = SampleData.Categories;
        return View(products.ToList());
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        var product = SampleData.Products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }
}
