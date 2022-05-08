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
            var result = _taskService.GetAllByUserId(Convert.ToInt32(HttpContext.User.Claims.SingleOrDefault().Value)).Where(x => x.DateOfInsert >= DateTime.Now.AddHours(3).Date.AddDays(-(int)DateTime.Now.AddHours(3).Date.DayOfWeek + (int)DayOfWeek.Monday) && x.DateOfDeadline == DateTime.Now.AddHours(3).Date.AddDays(-(int)DateTime.Now.AddHours(3).Date.DayOfWeek + (int)DayOfWeek.Monday + 7) && x.DateOfDeadline.Date != DateTime.Now.AddHours(3).Date.AddDays(1)).ToList();

            return View(result);
        }
    }
}
