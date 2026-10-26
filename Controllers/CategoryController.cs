using Microsoft.AspNetCore.Mvc;
using NextUp.Models;
using NextUp.Services.Interfaces;
using static NextUp.Common.ValidationConstants;
using static NextUp.Common.ErrorMesages;

namespace NextUp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            List<Category> categories = await _service.GetAllAsync();
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

            if (await _service.IsDuplicateAsync(category))
            {
                ModelState.AddModelError(nameof(category.Name), DuplicateCategoryMsg);
                return View(category);
            }

            await _service.CreateAsync(category);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == GlobalCategoryId)
            {
                return RedirectToAction(nameof(Index));
            }

            Category? category = await _service.GetByIdAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Category category)
        {
            if (id != category.Id || id == GlobalCategoryId)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(category);
            }

            if (await _service.IsDuplicateAsync(category))
            {
                ModelState.AddModelError(nameof(category.Name), DuplicateCategoryMsg);
                return View(category);
            }

            await _service.UpdateAsync(category);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == GlobalCategoryId)
            {
                return RedirectToAction(nameof(Index));
            }

            Category? category = await _service.GetByIdAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            bool isDeleted = await _service.DeleteAsync(id);

            if (!isDeleted)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
