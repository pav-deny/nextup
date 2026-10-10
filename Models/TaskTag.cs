using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace NextUp.Models
{
    [PrimaryKey(nameof(TaskItemId), nameof(TagId))]
    public class TaskTag
    {
        [ForeignKey(nameof(TaskItem))]
        public int TaskItemId { get; set; }

        public TaskItem TaskItem { get; set; }

        [ForeignKey(nameof(Tag))]
        public int TagId { get; set; }

        public Tag Tag { get; set; }
    }
}
