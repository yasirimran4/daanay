using DAANAY.Models;

namespace DAANAY.Data;

/// <summary>
/// In-memory sample data for Deliverable 2 UI pages (no database / packages).
/// </summary>
public static class SampleData
{
    public static List<Category> Categories { get; } =
    [
        new() { Id = 1, Name = "Nuts", Description = "Almonds, cashews, walnuts and more." },
        new() { Id = 2, Name = "Dried Fruits", Description = "Raisins, dates, apricots and figs." },
        new() { Id = 3, Name = "Seeds", Description = "Pumpkin, sunflower and chia seeds." },
        new() { Id = 4, Name = "Gift Boxes", Description = "Assorted dry fruit gift packs." }
    ];

    public static List<Product> Products { get; } =
    [
        new() { Id = 1, Name = "California Almonds", Description = "Crunchy premium almonds, lightly roasted.", Price = 1800, Stock = 40, CategoryId = 1, CategoryName = "Nuts", Unit = "1kg" },
        new() { Id = 2, Name = "Cashew Kernels", Description = "Whole white cashews, grade W320.", Price = 2200, Stock = 25, CategoryId = 1, CategoryName = "Nuts", Unit = "1kg" },
        new() { Id = 3, Name = "Walnuts", Description = "Fresh walnut halves, rich in omega-3.", Price = 2500, Stock = 18, CategoryId = 1, CategoryName = "Nuts", Unit = "1kg" },
        new() { Id = 4, Name = "Golden Raisins", Description = "Sweet seedless golden raisins.", Price = 900, Stock = 55, CategoryId = 2, CategoryName = "Dried Fruits", Unit = "500g" },
        new() { Id = 5, Name = "Ajwa Dates", Description = "Premium Ajwa dates from Madinah.", Price = 3200, Stock = 12, CategoryId = 2, CategoryName = "Dried Fruits", Unit = "1kg" },
        new() { Id = 6, Name = "Dried Apricots", Description = "Soft sun-dried apricots.", Price = 1400, Stock = 30, CategoryId = 2, CategoryName = "Dried Fruits", Unit = "500g" },
        new() { Id = 7, Name = "Pumpkin Seeds", Description = "Roasted unsalted pumpkin seeds.", Price = 1100, Stock = 35, CategoryId = 3, CategoryName = "Seeds", Unit = "500g" },
        new() { Id = 8, Name = "Festive Mix Box", Description = "Assorted nuts and dried fruits gift box.", Price = 4500, Stock = 10, CategoryId = 4, CategoryName = "Gift Boxes", Unit = "box" }
    ];

    public static List<CartItem> Cart { get; } =
    [
        new() { ProductId = 1, ProductName = "California Almonds", UnitPrice = 1800, Quantity = 1, Unit = "1kg" },
        new() { ProductId = 4, ProductName = "Golden Raisins", UnitPrice = 900, Quantity = 2, Unit = "500g" }
    ];

    public static List<Order> Orders { get; } =
    [
        new()
        {
            Id = 1001,
            CustomerName = "Ayesha Khan",
            DeliveryAddress = "House 12, Street 4, Islamabad",
            Phone = "0300-1234567",
            OrderDate = DateTime.Today.AddDays(-5),
            Status = "Delivered",
            PaymentMethod = "Cash on Delivery",
            TotalAmount = 3600,
            Items =
            [
                new() { ProductId = 1, ProductName = "California Almonds", Quantity = 1, UnitPrice = 1800 },
                new() { ProductId = 4, ProductName = "Golden Raisins", Quantity = 2, UnitPrice = 900 }
            ]
        },
        new()
        {
            Id = 1002,
            CustomerName = "Bilal Ahmed",
            DeliveryAddress = "Flat 3B, Gulberg III, Lahore",
            Phone = "0321-7654321",
            OrderDate = DateTime.Today.AddDays(-1),
            Status = "Pending",
            PaymentMethod = "Cash on Delivery",
            TotalAmount = 2200,
            Items =
            [
                new() { ProductId = 2, ProductName = "Cashew Kernels", Quantity = 1, UnitPrice = 2200 }
            ]
        },
        new()
        {
            Id = 1003,
            CustomerName = "Ayesha Khan",
            DeliveryAddress = "House 12, Street 4, Islamabad",
            Phone = "0300-1234567",
            OrderDate = DateTime.Today,
            Status = "Confirmed",
            PaymentMethod = "Cash on Delivery",
            TotalAmount = 4500,
            Items =
            [
                new() { ProductId = 8, ProductName = "Festive Mix Box", Quantity = 1, UnitPrice = 4500 }
            ]
        }
    ];

    public static List<CustomerInfo> Customers { get; } =
    [
        new() { Id = 1, FullName = "Ayesha Khan", Email = "ayesha@example.com", Phone = "0300-1234567", Address = "House 12, Street 4, Islamabad", TotalOrders = 2 },
        new() { Id = 2, FullName = "Bilal Ahmed", Email = "bilal@example.com", Phone = "0321-7654321", Address = "Flat 3B, Gulberg III, Lahore", TotalOrders = 1 },
        new() { Id = 3, FullName = "Sara Malik", Email = "sara@example.com", Phone = "0333-9988776", Address = "PECHS Block 2, Karachi", TotalOrders = 0 }
    ];

    public static readonly string[] OrderStatuses = ["Pending", "Confirmed", "Shipped", "Delivered"];
}
