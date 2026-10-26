using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using static NextUp.Common.ValidationConstants.CategoryConstants;

namespace NextUp.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(MaxColorHexLength)]
        [RegularExpression(HexCodeRegEx, ErrorMessage = HexCodeErrMsg)]
        public string ColorHex { get; set; }
    }
}
