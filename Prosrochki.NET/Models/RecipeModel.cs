using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Prosrochki.NET.Models
{
    public class RecipeModel
    {
        [DisplayName("ID Number")]
        public int Id { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 1)]
        [DisplayName("Recipe's Name")]
        public string? Name { get; set; }

        [DisplayName("Ingredients")]
        public string? Ingredients { get; set; }

        [StringLength(500)]
        [DisplayName("Product's Description")]
        public string? Description { get; set; }
    }
}
