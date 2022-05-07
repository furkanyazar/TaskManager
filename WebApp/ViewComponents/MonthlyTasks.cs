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
            var result = _taskService.GetAllByTypeIdAndUserId(3, Convert.ToInt32(HttpContext.User.Claims.SingleOrDefault().Value)).OrderBy(x => x.DateOfInsert).ToList();

            return View(result);
        }
    }
}
