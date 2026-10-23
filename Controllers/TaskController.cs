using Microsoft.AspNetCore.Mvc;
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
    }
}
