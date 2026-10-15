using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NextUp.Data;
using NextUp.Models;

namespace NextUp.Controllers
{
    public class TagController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TagController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Tag> tags = await _context.Tags.Include(t => t.Category).ToListAsync();
            return View(tags);
        }

        //Helper method - loads categories
        private async Task LoadCategoriesAsync()
        {
            List<Category> categories = await _context.Categories.ToListAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await LoadCategoriesAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Tag tag)
        {
            if (!ModelState.IsValid)
            {
                await LoadCategoriesAsync();
                return View(tag);
            }

            bool isDuplicate = await _context.Tags.AnyAsync(t => t.CategoryId == tag.CategoryId && t.Name == tag.Name);

            if (isDuplicate)
            {
                await LoadCategoriesAsync();
                ModelState.AddModelError(nameof(tag.Name), "A tag with that name already exists in this category!");
                return View(tag);
            }

            _context.Tags.Add(tag);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            await LoadCategoriesAsync();

            Tag? tag = await _context.Tags.FindAsync(id);

            if (tag == null)
            {
                return NotFound();
            }

            return View(tag);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Tag tag)
        {
            if (tag.Id != id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                await LoadCategoriesAsync();
                return View(tag);
            }

            bool isDuplicate = await _context.Tags.AnyAsync(t => t.CategoryId == tag.CategoryId && t.Name == tag.Name && t.Id != tag.Id);

            if (isDuplicate)
            {
                await LoadCategoriesAsync();
                ModelState.AddModelError(nameof(tag.Name), "A tag with that name already exists in this category!");
                return View(tag);
            }

            _context.Update(tag);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Tag? tag = await _context.Tags.Include(t => t.Category).FirstOrDefaultAsync(t => t.Id == id);

            if (tag == null)
            {
                return NotFound();
            }

            return View(tag);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Tag? tag = await _context.Tags.FirstOrDefaultAsync(t => t.Id == id);

            if (tag == null)
            {
                return NotFound();
            }

            _context.Tags.Remove(tag);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}