using Microsoft.AspNetCore.Mvc;
using NextUp.Models;
using NextUp.Services.Interfaces;
using NextUp.ViewModels;
using System.Diagnostics;

namespace NextUp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITaskService _taskService;

        public HomeController(ILogger<HomeController> logger, ITaskService taskService)
        {
            _logger = logger;
            _taskService = taskService;
        }

        public async Task<IActionResult> Index()
        {
            List<TaskItem> upcoming = (await _taskService.GetAllAsync()).OrderBy(t => t.DueDateTime).ToList();

            return View(upcoming);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
