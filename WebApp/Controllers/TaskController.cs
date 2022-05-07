using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace WebApp.Controllers
{
    public class TaskController : Controller
    {
        private ITaskService _taskService;

        private TaskValidator validator = new();
        private ValidationResult validation;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public IActionResult Add(Task task)
        {
            task.UserId = Convert.ToInt32(HttpContext.User.Claims.SingleOrDefault(x => x.Type == "UserId").Value);

            switch (task.TaskTypeId)
            {
                case 1:
                    task.DateOfDeadline = DateTime.Today.AddDays(1);
                    break;
                case 2:
                    DateTime startOfNextWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + 8);
                    task.DateOfDeadline = startOfNextWeek;
                    break;
                case 3:
                    var year = DateTime.Now.Year;
                    var month = DateTime.Now.Month;
                    DateTime startOfNextMonth = new DateTime(year, month, DateTime.DaysInMonth(year, month)).AddDays(1);
                    task.DateOfDeadline = startOfNextMonth;
                    break;
                default:
                    task.DateOfDeadline = DateTime.Today.AddDays(1);
                    break;
            }

            validation = validator.Validate(task);

            if (validation.IsValid)
            {
                _taskService.Add(task);

                return Json(new { success = true });
            }

            return Json(new { success = false, message = validation.Errors[0].ErrorMessage });
        }

        public IActionResult Update(Task task)
        {
            var result = _taskService.GetById(task.TaskId);

            if (result is null)
                return Json(new { success = false, message = Messages.TaskNotFound });

            validation = validator.Validate(task);

            if (validation.IsValid)
            {
                _taskService.Update(task);

                return Json(new { success = true });
            }

            return Json(new { success = false, message = validation.Errors[0].ErrorMessage });
        }

        public IActionResult Delete(int id)
        {
            var result = _taskService.GetById(id);

            if (result is null)
                return Json(new { success = false, message = Messages.TaskNotFound });

            _taskService.Delete(result);

            return Json(new { success = true });
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Daily()
        {
            return View();
        }

        public IActionResult Weekly()
        {
            return View();
        }

        public IActionResult Monthly()
        {
            return View();
        }
    }
}
