using NextUp.Models;

namespace NextUp.Services.Interfaces
{
    public interface ITaskService
    {
        Task<List<TaskItem>> GetAllAsync();
        Task<TaskItem?> GetByIdAsync(int id);
        Task CreateAsync(TaskItem task, List<int>? tagIds);
        Task<bool> UpdateAsync(TaskItem task, List<int>? tagIds);
        Task<bool> DeleteAsync(int id);
    }
}
