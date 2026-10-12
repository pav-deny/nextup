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
    }
}
