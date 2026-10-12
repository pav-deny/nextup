using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NextUp.Data;
using NextUp.Models;

namespace NextUp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
         
        public async Task<IActionResult> Index()
        {
            List<Category> categories = await _context.Categories.ToListAsync();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 1)
            {
                return RedirectToAction(nameof(Index));
            }

            Category? category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Category category)
        {
            if (id != category.Id || id == 1)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(category);
            }

            _context.Update(category);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
