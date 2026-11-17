using DAANAY.Data;
using DAANAY.Models;
using Microsoft.AspNetCore.Mvc;

namespace DAANAY.Controllers;

public class CartController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View(SampleData.Cart);
    }

    [HttpPost]
    public IActionResult Add(int productId, int quantity = 1)
    {
        var product = SampleData.Products.FirstOrDefault(p => p.Id == productId);
        if (product == null)
        {
            return RedirectToAction("Index", "Products");
        }

        if (quantity < 1)
        {
            quantity = 1;
        }

        var existing = SampleData.Cart.FirstOrDefault(c => c.ProductId == productId);
        if (existing != null)
        {
            existing.Quantity += quantity;
        }
        else
        {
            SampleData.Cart.Add(new CartItem
            {
                ProductId = product.Id,
                ProductName = product.Name,
                UnitPrice = product.Price,
                Quantity = quantity,
                Unit = product.Unit
            });
        }

        TempData["Message"] = $"{product.Name} added to cart.";
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public IActionResult Update(int productId, int quantity)
    {
        var item = SampleData.Cart.FirstOrDefault(c => c.ProductId == productId);
        if (item != null)
        {
            if (quantity <= 0)
            {
                SampleData.Cart.Remove(item);
            }
            else
            {
                item.Quantity = quantity;
            }
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public IActionResult Remove(int productId)
    {
        var item = SampleData.Cart.FirstOrDefault(c => c.ProductId == productId);
        if (item != null)
        {
            SampleData.Cart.Remove(item);
            TempData["Message"] = $"{item.ProductName} removed from cart.";
        }

        return RedirectToAction(nameof(Index));
    }
}
