using NextUp.Models;

namespace NextUp.Services.Interfaces
{
    public interface ITagService
    {
        Task<List<Tag>> GetAllAsync();
        Task<Tag?> GetByIdAsync(int id);
        Task CreateAsync(Tag tag);
        Task UpdateAsync(Tag tag);
        Task<bool> DeleteAsync(int id);
        Task<bool> IsDuplicateAsync(Tag tag);
    }
}
