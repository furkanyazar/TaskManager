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

        public IActionResult AddDaily(Task task)
        {
            task.UserId = Convert.ToInt32(HttpContext.User.Claims.SingleOrDefault(x => x.Type == "UserId").Value);
            task.DateOfDeadline = DateTime.Today.AddDays(1);

            validation = validator.Validate(task);

            if (validation.IsValid)
            {
                _taskService.Add(task);

                var result = _taskService.GetAll().LastOrDefault();

                return Json(new { success = true, id = result.TaskId });
            }

            return Json(new { success = false, message = validation.Errors[0].ErrorMessage });
        }

        public IActionResult AddWeekly(Task task)
        {
            task.UserId = Convert.ToInt32(HttpContext.User.Claims.SingleOrDefault(x => x.Type == "UserId").Value);
            task.DateOfDeadline = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);

            validation = validator.Validate(task);

            if (validation.IsValid)
            {
                _taskService.Add(task);

                var result = _taskService.GetAll().LastOrDefault();

                return Json(new { success = true, id = result.TaskId });
            }

            return Json(new { success = false, message = validation.Errors[0].ErrorMessage });
        }

        public IActionResult AddMonthly(Task task)
        {
            var year = DateTime.Now.Year;
            var month = DateTime.Now.Month;

            task.UserId = Convert.ToInt32(HttpContext.User.Claims.SingleOrDefault(x => x.Type == "UserId").Value);
            task.DateOfDeadline = new DateTime(year, month, DateTime.DaysInMonth(year, month)).AddDays(1);

            validation = validator.Validate(task);

            if (validation.IsValid)
            {
                _taskService.Add(task);

                var result = _taskService.GetAll().LastOrDefault();

                return Json(new { success = true, id = result.TaskId });
            }

            return Json(new { success = false, message = validation.Errors[0].ErrorMessage });
        }

        public IActionResult Update(Task task)
        {
            var result = _taskService.GetById(task.TaskId);

            if (result is null)
                return Json(new { success = false, message = Messages.TaskNotFound });

            task.DateOfDeadline = result.DateOfDeadline;
            task.DateOfInsert = result.DateOfInsert;
            task.Status = result.Status;
            task.UserId = result.UserId;

            validation = validator.Validate(task);

            if (validation.IsValid)
            {
                _taskService.Update(task);

                return Json(new { success = true, status = task.Status });
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

        public IActionResult Succeed(int id)
        {
            var result = _taskService.GetById(id);

            if (result is null)
                return Json(new { success = false, message = Messages.TaskNotFound });

            result.Status = !result.Status;

            _taskService.Update(result);

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
