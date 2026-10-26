using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace NextUp.Models
{
    [PrimaryKey(nameof(TaskId), nameof(TagId))]
    public class TaskTag
    {
        [ForeignKey(nameof(Task))]
        public int TaskId { get; set; }

        public TaskItem Task { get; set; } = null!;

        [ForeignKey(nameof(Tag))]
        public int TagId { get; set; }

        public Tag Tag { get; set; } = null!;
    }
}
