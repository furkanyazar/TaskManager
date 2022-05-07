using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace WebApp.ViewComponents
{
    public class DailyTasks : ViewComponent
    {
        private ITaskService _taskService;

        public DailyTasks(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public IViewComponentResult Invoke()
        {
            var result = _taskService.GetAllByTypeIdAndUserId(1, Convert.ToInt32(HttpContext.User.Claims.SingleOrDefault().Value)).Where(x => x.DateOfInsert.Date == DateTime.Today && x.DateOfDeadline == DateTime.Today.AddDays(1)).ToList();

            return View(result);
        }
    }
}
