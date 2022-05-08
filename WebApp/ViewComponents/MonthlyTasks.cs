using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace WebApp.ViewComponents
{
    public class MonthlyTasks : ViewComponent
    {
        private ITaskService _taskService;

        public MonthlyTasks(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public IViewComponentResult Invoke()
        {
            var month = DateTime.Now.AddHours(3).Month;
            var year = DateTime.Now.AddHours(3).Year;

            var result = _taskService.GetAllByUserId(Convert.ToInt32(HttpContext.User.Claims.SingleOrDefault().Value)).Where(x => x.DateOfInsert.Year == year && x.DateOfInsert.Month == month && x.DateOfDeadline == new DateTime(year, month, DateTime.DaysInMonth(year, month)).AddDays(1)).ToList();

            return View(result);
        }
    }
}
