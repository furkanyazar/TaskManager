using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace WebApp.ViewComponents
{
    public class SidebarProfile : ViewComponent
    {
        private IUserService _userService;

        public SidebarProfile(IUserService userService)
        {
            _userService = userService;
        }

        public IViewComponentResult Invoke()
        {
            var result = _userService.GetById(Convert.ToInt32(HttpContext.User.Claims.SingleOrDefault(x => x.Type == "UserId").Value));

            return View(result);
        }
    }
}
