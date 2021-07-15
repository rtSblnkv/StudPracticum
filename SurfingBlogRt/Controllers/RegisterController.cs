using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurfingBlogRt.DAL;
using SurfingBlogRt.Helpers;
using SurfingBlogRt.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SurfingBlogRt.Controllers
{
    public class RegisterController:Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser(UserViewModel uvModel,IFormFile imageData)
        {         
            var context = new DataContext();

            if (ModelState.IsValid)
            {
                if(uvModel.Password != uvModel.ConfirmPassword)
                {
                    ModelState.AddModelError(nameof(uvModel.ConfirmPassword), "Пароли не совпадают");
                    return View("Index", uvModel);
                }

                var mailIsTaken = context.Users.Any(x => x.Email == uvModel.Email);

                if(mailIsTaken)
                {
                    ModelState.AddModelError(nameof(uvModel.Email), "Такая почта уже зарегистрирована");
                    return View("Index", uvModel);
                }
                var nicknameIsTaken = context.Users.Any(x => x.Nickname == uvModel.Nickname);

                if (nicknameIsTaken)
                {
                    ModelState.AddModelError(nameof(uvModel.Nickname), "Такой псевдоним уже занят");
                    return View("Index", uvModel);
                }


                Guid? img = Guid.Empty;

                if (imageData != null)
                {
                    var extension = Path.GetExtension(imageData.FileName);
                    if (extension != ".jpg" && extension != ".jpeg" && extension != ".png")
                    {
                        ModelState.AddModelError("", "Недопустимый формат изображения");
                    }
                }

                var helper = new ImageHelper();

                img = await helper.UploadImage(imageData);

                var user = new User()
                {
                    Nickname = uvModel.Nickname,
                    Password = uvModel.Password,
                    Email = uvModel.Email,
                    LastName = uvModel.LastName,
                    FirstName = uvModel.FirstName,
                    Photo = img,
                    Contacts = uvModel.Contacts,
                    AboutMe = uvModel.AboutMe,
                    Achievements = uvModel.Achievements
                };
                context.Users.Add(user);
                context.SaveChanges();

                await AuthenticateHelper.Authenticate(user.Id,user.Nickname, false, HttpContext); // аутентификация

                if (user.Photo.HasValue && Guid.Empty != user.Photo.Value)
                {
                    HttpContext.Session.SetString("Photo", user.Photo.Value.ToString());
                }
                HttpContext.Session.SetInt32("Id", user.Id);

                return RedirectToAction("Index", "Home");
            }
            else ModelState.AddModelError("", "Проверьте корректность введённых данных.");

            return View("Index",uvModel);

        }
    }
}
