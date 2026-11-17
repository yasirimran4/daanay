using DAANAY.Data;
using DAANAY.Models;
using DAANAY.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DAANAY.Controllers;

public class OrdersController : Controller
{
    [HttpGet]
    public IActionResult Checkout()
    {
        if (!SampleData.Cart.Any())
        {
            TempData["Message"] = "Your cart is empty.";
            return RedirectToAction("Index", "Cart");
        }

        ViewBag.Cart = SampleData.Cart;
        ViewBag.CartTotal = SampleData.Cart.Sum(c => c.LineTotal);
        return View(new CheckoutViewModel());
    }

    [HttpPost]
    public IActionResult Checkout(CheckoutViewModel model)
    {
        ViewBag.Cart = SampleData.Cart;
        ViewBag.CartTotal = SampleData.Cart.Sum(c => c.LineTotal);

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        if (!SampleData.Cart.Any())
        {
            TempData["Message"] = "Your cart is empty.";
            return RedirectToAction("Index", "Cart");
        }

        var nextId = SampleData.Orders.Count == 0 ? 1001 : SampleData.Orders.Max(o => o.Id) + 1;
        var order = new Order
        {
            Id = nextId,
            CustomerName = model.FullName,
            DeliveryAddress = model.DeliveryAddress,
            Phone = model.Phone,
            OrderDate = DateTime.Now,
            Status = "Pending",
            PaymentMethod = model.PaymentMethod,
            TotalAmount = SampleData.Cart.Sum(c => c.LineTotal),
            Items = SampleData.Cart.Select(c => new OrderItem
            {
                ProductId = c.ProductId,
                ProductName = c.ProductName,
                Quantity = c.Quantity,
                UnitPrice = c.UnitPrice
            }).ToList()
        };

        SampleData.Orders.Insert(0, order);
        SampleData.Cart.Clear();

        TempData["Message"] = $"Order #{order.Id} placed successfully (Cash on Delivery).";
        return RedirectToAction(nameof(Details), new { id = order.Id });
    }

    [HttpGet]
    public IActionResult History()
    {
        // Sample customer order history (UI-only)
        var orders = SampleData.Orders
            .Where(o => o.CustomerName.Contains("Ayesha", StringComparison.OrdinalIgnoreCase))
            .OrderByDescending(o => o.OrderDate)
            .ToList();

        return View(orders);
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        var order = SampleData.Orders.FirstOrDefault(o => o.Id == id);
        if (order == null)
        {
            return NotFound();
        }

        return View(order);
    }
}
