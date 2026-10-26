using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static NextUp.Common.ValidationConstants.Tag;

namespace NextUp.Models
{
    [Index(nameof(CategoryId), nameof(Name), IsUnique = true)]
    public class Tag
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; }

        [ForeignKey(nameof(Category))]
        [Range(MinCategoryId, MaxCategoryId, ErrorMessage = CategoryIdErrMsg)]
        public int CategoryId { get; set; }

        public Category? Category { get; set; }

        public ICollection<TaskTag> TaskTags { get; set; } = new List<TaskTag>();
    }
}