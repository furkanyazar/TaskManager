using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace WebApp.ViewComponents
{
    public class WeeklyTasks : ViewComponent
    {
        private ITaskService _taskService;

        public WeeklyTasks(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public IViewComponentResult Invoke()
        {
            var result = _taskService.GetAllByTypeIdAndUserId(2, Convert.ToInt32(HttpContext.User.Claims.SingleOrDefault().Value)).Where(x => x.DateOfInsert >= DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + 1) && x.DateOfDeadline == DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + 8)).ToList();

            return View(result);
        }
    }
}
