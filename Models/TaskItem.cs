using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NextUp.Models
{
    public class TaskItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public DateTime CreatedOn { get; private set; } = DateTime.UtcNow;

        public DateTime? EditedOn { get; set; }

        public DateTime? DueDateTime { get; set; }

        [MaxLength(500)]
        public string? Notes { get; set; }

        public ICollection<TaskTag> TaskTags { get; set; }
    }
}