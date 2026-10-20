using NextUp.Models;

namespace NextUp.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int id);
        Task CreateAsync(Category category);
        Task UpdateAsync(Category category);
        Task<bool> DeleteAsync(int id);
        Task<bool> IsDuplicateAsync(Category category);
    }
}
