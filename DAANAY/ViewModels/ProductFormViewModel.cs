using System.ComponentModel.DataAnnotations;

namespace DAANAY.ViewModels;

public class ProductFormViewModel
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "Product Name")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Description")]
    public string Description { get; set; } = string.Empty;

    [Required]
    [Range(1, 100000)]
    [Display(Name = "Price (PKR)")]
    public decimal Price { get; set; }

    [Required]
    [Range(0, 100000)]
    [Display(Name = "Stock")]
    public int Stock { get; set; }

    [Required]
    [Display(Name = "Category")]
    public int CategoryId { get; set; }

    [Required]
    [Display(Name = "Unit")]
    public string Unit { get; set; } = "500g";
}
