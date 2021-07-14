using Microsoft.AspNetCore.Mvc;
using SurfingBlogRt.DAL;
using SurfingBlogRt.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        [Route("CreateUser")]
        public async Task<IActionResult> AddNewUser(UserViewModel uvModel)
        {
            var context = new DataContext();
            if(ModelState.IsValid)
            {
                if (uvModel.Password == uvModel.ConfirmPassword)
                {

                }
                else ModelState.AddModelError("", "Пароли не совпадают.Попробуйте ещё раз.");
            }
            else ModelState.AddModelError("",)

           

            if (string.IsNullOrEmpty(news.Text)
                && imageData == null)
            {
                ViewBag.Posts = context.News
                    .Include(n => n.Author)
                    .OrderByDescending(n => n.CreateDate)
                    .ToList();
                return View("Index", news);
            }

            if (imageData != null)
            {
                var extension = Path.GetExtension(imageData.FileName);
                if (extension != ".jpg" && extension != ".jpeg" && extension != ".png")
                {
                    ViewBag.FileError = true;
                    ViewBag.Posts = context.News
                    .Include(n => n.Author)
                    .OrderByDescending(n => n.CreateDate)
                    .ToList();
                    return View("Index", news);
                }
            }

            news.AuthorId = 1;
            news.CreateDate = DateTime.Now;

            var helper = new ImageHelper();
            news.Image = await helper.UploadImage(imageData);


            context.News.Add(news);
            context.SaveChanges();

            ViewBag.Posts = context.News
                   .Include(n => n.Author)
                   .OrderByDescending(n => n.CreateDate)
                   .ToList();
            return View("Index", news);
        }
    }
}
