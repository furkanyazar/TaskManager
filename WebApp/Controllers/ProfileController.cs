using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Security.Hashing;
using Entities.Concrete;
using Entities.Dtos;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;

namespace WebApp.Controllers
{
    public class ProfileController : Controller
    {
        private IUserService _userService;

        private IMapper _mapper;

        private UserRegisterDtoValidator validator = new();
        private ValidationResult validation;

        public ProfileController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var result = _userService.GetById(Convert.ToInt32(HttpContext.User.Claims.SingleOrDefault(x => x.Type == "UserId").Value));

            var user = _mapper.Map<UserDetailDto>(result);

            return View(user);
        }

        [HttpPost]
        public IActionResult Index(UserDetailDto userDetailDto)
        {
            var oldUser = _userService.GetById(Convert.ToInt32(HttpContext.User.Claims.SingleOrDefault(y => y.Type == "UserId").Value));

            if (userDetailDto.Password is null)
                userDetailDto.Password = Defaults.PASSWORD_KEY;

            if (userDetailDto.ImageUrl is null)
                userDetailDto.ImageUrl = oldUser.ImageUrl;

            var userToValidate = _mapper.Map<UserRegisterDto>(userDetailDto);

            validation = validator.Validate(userToValidate);

            if (validation.IsValid)
            {
                var userToCheck = _userService.GetByUserEmail(userDetailDto.Email);

                if (userToCheck is not null && userToCheck.Email != oldUser.Email)
                {
                    ModelState.AddModelError("Email", Messages.EmailAlreadyExists);

                    return View(userDetailDto);
                }

                if (Request.Form.Files["UserImage"] is not null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(Request.Form.Files[0].FileName);
                    string path = Path.Combine(Directory.GetCurrentDirectory(), Defaults.DEFAULT_AVATAR_UPLOAD_PATH, fileName);

                    var stream = new FileStream(path, FileMode.Create);
                    Request.Form.Files["UserImage"].CopyTo(stream);

                    userDetailDto.ImageUrl = Defaults.DEFAULT_AVATAR_URL_PATH + fileName;

                    stream.Close();
                }

                var user = _mapper.Map<User>(userDetailDto);
                user.UserId = oldUser.UserId;

                if (userDetailDto.Password == Defaults.PASSWORD_KEY)
                {
                    user.PasswordHash = oldUser.PasswordHash;
                    user.PasswordSalt = oldUser.PasswordSalt;
                }
                else
                {
                    HashingHelper.CreatePasswordHash(userDetailDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

                    user.PasswordHash = passwordHash;
                    user.PasswordSalt = passwordSalt;
                }

                _userService.Update(user);

                return RedirectToAction("Index");
            }

            foreach (var item in validation.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            return View(userDetailDto);
        }

        public IActionResult DeletePhoto()
        {
            var result = _userService.GetById(Convert.ToInt32(HttpContext.User.Claims.SingleOrDefault(x => x.Type == "UserId").Value));
            result.ImageUrl = Defaults.DEFAULT_AVATAR_URL;

            _userService.Update(result);

            return RedirectToAction("Index");
        }
    }
}
