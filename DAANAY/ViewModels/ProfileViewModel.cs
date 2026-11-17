using System.ComponentModel.DataAnnotations;

namespace DAANAY.ViewModels;

public class ProfileViewModel
{
    [Required(ErrorMessage = "Full name is required.")]
    [Display(Name = "Full Name")]
    public string FullName { get; set; } = "Ayesha Khan";

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; } = "ayesha@example.com";

    [Display(Name = "Phone Number")]
    public string? PhoneNumber { get; set; } = "0300-1234567";

    [Display(Name = "Delivery Address")]
    [DataType(DataType.MultilineText)]
    public string? Address { get; set; } = "House 12, Street 4, Islamabad";
}
