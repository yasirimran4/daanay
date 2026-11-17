namespace DAANAY.Models;

public class CartItem
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public string Unit { get; set; } = "500g";

    public decimal LineTotal => UnitPrice * Quantity;
}
