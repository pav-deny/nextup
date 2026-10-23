using Microsoft.AspNetCore.Mvc;
using NextUp.Models;
using NextUp.Services.Interfaces;

namespace NextUp.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public async Task<IActionResult> Index()
        {
            List<TaskItem> tasks = await _taskService.GetAllAsync();
            return View(tasks);
        }
    }
}
