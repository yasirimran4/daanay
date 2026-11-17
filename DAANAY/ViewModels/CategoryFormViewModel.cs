using System.ComponentModel.DataAnnotations;

namespace DAANAY.ViewModels;

public class CategoryFormViewModel
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "Category Name")]
    public string Name { get; set; } = string.Empty;

    [Display(Name = "Description")]
    public string Description { get; set; } = string.Empty;
}
