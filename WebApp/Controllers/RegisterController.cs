using AutoMapper;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Security.Hashing;
using Entities.Concrete;
using Entities.Dtos;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private IUserService _userService;

        private IMapper _mapper;

        private UserRegisterDtoValidator validator = new();
        private ValidationResult validation;

        public RegisterController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(UserRegisterDto userRegisterDto)
        {
            validation = validator.Validate(userRegisterDto);

            if (validation.IsValid)
            {
                HashingHelper.CreatePasswordHash(userRegisterDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

                var user = _mapper.Map<User>(userRegisterDto);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;

                _userService.Add(user);

                return RedirectToAction("Index", "Login");
            }

            foreach (var item in validation.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            return View();
        }
    }
}
