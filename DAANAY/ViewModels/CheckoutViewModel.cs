using System.ComponentModel.DataAnnotations;

namespace DAANAY.ViewModels;

public class CheckoutViewModel
{
    [Required(ErrorMessage = "Full name is required.")]
    [Display(Name = "Full Name")]
    public string FullName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Phone number is required.")]
    [Display(Name = "Phone")]
    public string Phone { get; set; } = string.Empty;

    [Required(ErrorMessage = "Delivery address is required.")]
    [Display(Name = "Delivery Address")]
    [DataType(DataType.MultilineText)]
    public string DeliveryAddress { get; set; } = string.Empty;

    [Display(Name = "Payment Method")]
    public string PaymentMethod { get; set; } = "Cash on Delivery";

    [Display(Name = "Order Notes")]
    public string? Notes { get; set; }
}
