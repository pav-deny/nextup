using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NextUp.Models;
using NextUp.Services.Interfaces;

namespace NextUp.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagService _tagService;
        private readonly ICategoryService _categoryService;

        public TagController(ITagService tagService, ICategoryService categoryService)
        {
            _tagService = tagService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            List<Tag> tags = await _tagService.GetAllAsync();
            return View(tags);
        }

        //Helper method - loads categories
        private async Task LoadCategoriesAsync()
        {
            List<Category> categories = await _categoryService.GetAllAsync();
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

            if (await _tagService.IsDuplicateAsync(tag))
            {
                await LoadCategoriesAsync();
                ModelState.AddModelError(nameof(tag.Name), "A tag with that name already exists in this category!");
                return View(tag);
            }

            await _tagService.CreateAsync(tag);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            await LoadCategoriesAsync();

            Tag? tag = await _tagService.GetByIdAsync(id);

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

            if (await _tagService.IsDuplicateAsync(tag))
            {
                await LoadCategoriesAsync();
                ModelState.AddModelError(nameof(tag.Name), "A tag with that name already exists in this category!");
                return View(tag);
            }

            await _tagService.UpdateAsync(tag);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Tag? tag = await _tagService.GetByIdAsync(id);

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
            bool isDeleted = await _tagService.DeleteAsync(id);

            if (!isDeleted)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}