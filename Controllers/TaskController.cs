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

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
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

        private async Task LoadFormDataAsync()
        {
            List<Category> categories = await _categoryService.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");

            List<Tag> tags = await _tagService.GetAllAsync();
            ViewBag.Tags = new SelectList(tags, "Id", "Name");
        }
    }
}
