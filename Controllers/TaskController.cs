using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NextUp.Models;
using NextUp.Services.Interfaces;

namespace NextUp.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly ICategoryService _categoryService;
        private readonly ITagService _tagService;

        public TaskController(ITaskService taskService, ICategoryService categoryService, ITagService tagService)
        {
            _taskService = taskService;
            _categoryService = categoryService;
            _tagService = tagService;
        }

        public async Task<IActionResult> Index()
        {
            List<TaskItem> tasks = await _taskService.GetAllAsync();
            return View(tasks);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await LoadFormDataAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskItem task, List<int>? tagIds)
        {
            if (!ModelState.IsValid)
            {
                await LoadFormDataAsync();
                return View(task);
            }

            await _taskService.CreateAsync(task, tagIds);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            TaskItem? task = await _taskService.GetByIdAsync(id);
            List<int> selectedIds = task.TaskTags.Select(tt => tt.TagId).ToList();

            if (task == null)
            {
                return NotFound();
            }

            await LoadFormDataAsync(selectedIds);
            return View(task);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TaskItem task, int id, List<int>? tagIds)
        {
            if (task.Id != id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                await LoadFormDataAsync();
                return View(task);
            }

            await _taskService.UpdateAsync(task, tagIds);
            return RedirectToAction(nameof(Index));
        }

        private async Task LoadFormDataAsync(List<int>? selectedTagIds = null)
        {
            List<Category> categories = await _categoryService.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");

            List<Tag> tags = await _tagService.GetAllAsync();
            ViewBag.Tags = new MultiSelectList(tags, "Id", "Name", selectedTagIds);
        }
    }
}
