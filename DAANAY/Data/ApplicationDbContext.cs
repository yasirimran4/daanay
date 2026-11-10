using DAANAY.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAANAY.Data;

// EF Core DbContext used ONLY for ASP.NET Core Identity tables.
// Product, cart, and order data will continue to use ADO.NET (see DbHelper).
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}
