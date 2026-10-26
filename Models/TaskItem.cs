using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static NextUp.Common.ValidationConstants.Task;

namespace NextUp.Models
{
    public class TaskItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxTitleLength)]
        public string Title { get; set; } = null!;

        [ForeignKey(nameof(Category))]
        [Range(MinCategoryId, MaxCategoryId, ErrorMessage = CategoryIdErrMsg)]
        public int CategoryId { get; set; }

        public Category? Category { get; set; }

        public DateTime CreatedOn { get; private set; } = DateTime.UtcNow;

        public DateTime EditedOn { get; set; }

        [Display(Name = "Due date")]
        public DateTime DueDateTime { get; set; }

        [MaxLength(MaxNotesLength)]
        public string? Notes { get; set; }

        public ICollection<TaskTag> TaskTags { get; set; } = new List<TaskTag>();
    }
}