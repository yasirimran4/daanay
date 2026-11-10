using System.ComponentModel.DataAnnotations;

namespace DAANAY.ViewModels;

public class SignupViewModel
{
    [Required(ErrorMessage = "Full name is required.")]
    [Display(Name = "Full Name")]
    [StringLength(100, ErrorMessage = "Full name cannot be longer than 100 characters.")]
    public string FullName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    [Display(Name = "Email")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Password is required.")]
    [DataType(DataType.Password)]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters.")]
    [Display(Name = "Password")]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please confirm your password.")]
    [DataType(DataType.Password)]
    [Display(Name = "Confirm Password")]
    [Compare("Password", ErrorMessage = "Password and Confirm Password do not match.")]
    public string ConfirmPassword { get; set; } = string.Empty;
}
