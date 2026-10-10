using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace NextUp.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(7)]
        [RegularExpression("^#[0-9A-Fa-f]{6}$", ErrorMessage = "Use a hex color like #FF8C5A.")]
        public string ColorHex { get; set; }
    }
}
