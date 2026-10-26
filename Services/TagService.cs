using Microsoft.EntityFrameworkCore;
using NextUp.Data;
using NextUp.Models;
using NextUp.Services.Interfaces;

namespace NextUp.Services
{
    public class TagService : ITagService
    {
        private readonly ApplicationDbContext _context;

        public TagService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Tag tag)
        {
            _context.Tags.Add(tag);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Tag? tag = await _context.Tags.FindAsync(id);

            if (tag == null)
            {
                return false;
            }

            _context.Tags.Remove(tag);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Tag?> GetByIdAsync(int id)
        {
            return await _context.Tags.Include(t => t.Category).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<List<Tag>> GetAllAsync()
        {
            return await _context.Tags.Include(t => t.Category).ToListAsync();
        }

        public async Task<bool> IsDuplicateAsync(Tag tag)
        {
            return await _context.Tags.AnyAsync(t => t.Name == tag.Name && t.CategoryId == tag.CategoryId && t.Id != tag.Id);
            //Duplicate tags are tags that have the same name in the same category
        }

        public async Task UpdateAsync(Tag tag)
        {
            _context.Tags.Update(tag);
            await _context.SaveChangesAsync();
        }
    }
}
