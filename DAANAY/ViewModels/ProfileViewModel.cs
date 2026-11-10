using System.ComponentModel.DataAnnotations;

namespace DAANAY.ViewModels;

public class ProfileViewModel
{
    [Required(ErrorMessage = "Full name is required.")]
    [Display(Name = "Full Name")]
    [StringLength(100)]
    public string FullName { get; set; } = string.Empty;

    [Display(Name = "Email")]
    public string Email { get; set; } = string.Empty;

    [Phone(ErrorMessage = "Please enter a valid phone number.")]
    [Display(Name = "Phone Number")]
    public string? PhoneNumber { get; set; }

    [Display(Name = "Address")]
    [StringLength(250)]
    public string? Address { get; set; }
}
