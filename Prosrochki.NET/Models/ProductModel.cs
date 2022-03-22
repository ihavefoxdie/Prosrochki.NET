using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Prosrochki.NET.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 1)]
        [DisplayName("Product's Name")]
        public string? Name { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Date Produced")]
        public DateTime DateProduced { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Expiration Date")]
        public DateTime ExpirationDate { get; set; }

        [Required]
        [DisplayName("Weight/Volume")]
        public decimal Weight { get; set; }

        [StringLength(500)]
        [DisplayName("Product's Description")]
        public string? Description  { get; set; }
    }
}

