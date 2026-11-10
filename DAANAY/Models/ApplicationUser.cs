using Microsoft.AspNetCore.Identity;

namespace DAANAY.Models;

// Custom user class for ASP.NET Core Identity.
// Extra fields (FullName, Phone) are stored with the Identity user.
public class ApplicationUser : IdentityUser
{
    public string FullName { get; set; } = string.Empty;

    public string? Address { get; set; }
}
