using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using NextUp.Data;
using NextUp.Models;
using NextUp.Services.Interfaces;

namespace NextUp.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if (id == 1)
            {
                return false;
            }

            Category? category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return false;
            }

            List<Tag> tags = await _context.Tags.Where(t => t.CategoryId == category.Id).ToListAsync();
            _context.Tags.RemoveRange(tags);

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<bool> IsDuplicateAsync(Category category)
        {
            return await _context.Categories.AnyAsync(c => c.Name == category.Name && c.Id != category.Id);
        }

        public async Task UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }
    }
}
