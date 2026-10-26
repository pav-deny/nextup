using Microsoft.EntityFrameworkCore;
using NextUp.Data;
using NextUp.Models;
using NextUp.Services.Interfaces;
using static NextUp.Common.ValidationConstants;

namespace NextUp.Services
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext _context;

        public TaskService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(TaskItem task, List<int>? tagIds)
        {
            List<Tag> tags = await GetTaskTagsAsync(task, tagIds);

            foreach (Tag tag in tags)
            {
                task.TaskTags.Add(new TaskTag { TagId = tag.Id });
            }

            task.EditedOn = task.CreatedOn;

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            TaskItem? task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);

            if (task == null)
            {
                return false;
            }

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<TaskItem>> GetAllAsync()
        {
            return await _context.Tasks.Include(t => t.Category)
                .Include(t => t.TaskTags).ThenInclude(tt => tt.Tag)
                .ToListAsync();
        }

        public async Task<TaskItem?> GetByIdAsync(int id)
        {
            return await _context.Tasks.Include(t => t.Category)
                    .Include(t => t.TaskTags).ThenInclude(tt => tt.Tag)
                    .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<bool> UpdateAsync(TaskItem task, List<int>? tagIds)
        {
            TaskItem? originalTask = await _context.Tasks
                .Include(t => t.TaskTags)
                .FirstOrDefaultAsync(t => t.Id == task.Id);

            if (originalTask == null)
            {
                return false;
            }

            _context.TaskTags.RemoveRange(originalTask.TaskTags);

            List<Tag> tags = await GetTaskTagsAsync(task, tagIds);

            foreach (Tag tag in tags)
            {
                originalTask.TaskTags.Add(new TaskTag { TagId = tag.Id });
            }

            originalTask.EditedOn = DateTime.UtcNow;
            originalTask.Title = task.Title;
            originalTask.Notes = task.Notes;
            originalTask.DueDateTime = task.DueDateTime;
            originalTask.CategoryId = task.CategoryId;

            await _context.SaveChangesAsync();
            return true;
        }

        private async Task<List<Tag>> GetTaskTagsAsync(TaskItem task, List<int>? tagIds)
        {
            tagIds ??= new List<int>();  //If tagIds are null make them an empty list

            List<Tag> tags = await _context.Tags
                .Where(t => tagIds.Contains(t.Id) && (t.CategoryId == task.CategoryId || t.CategoryId == GlobalCategoryId))
                .ToListAsync();

            return tags;
        }
    }
}
