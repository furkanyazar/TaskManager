using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Security.Hashing;
using Entities.Dtos;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private IUserService _userService;

        private UserLoginDtoValidator validator = new();
        private ValidationResult validation;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IndexAsync(UserLoginDto userLoginDto)
        {
            validation = validator.Validate(userLoginDto);

            if (validation.IsValid)
            {
                var userToCheck = _userService.GetByUserEmail(userLoginDto.Email);

                if (userToCheck is null)
                {
                    ModelState.AddModelError("Email", "E-posta hatalı");

                    return View();
                }

                if (!HashingHelper.VerifyPasswordHash(userLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
                {
                    ModelState.AddModelError("Password", "Şifre hatalı");

                    return View();
                }

                var claims = new List<Claim>
                {
                    new Claim("UserId", userToCheck.UserId.ToString())
                };

                var claimIdentity = new ClaimsIdentity(claims, "U");
                var claimsPrincipal = new ClaimsPrincipal(claimIdentity);

                await HttpContext.SignInAsync(claimsPrincipal);

                return RedirectToAction("Index", "Register");
            }

            foreach (var item in validation.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            return View();
        }
    }
}
