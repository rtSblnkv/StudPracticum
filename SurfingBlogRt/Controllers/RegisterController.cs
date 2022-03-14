using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurfingBlogRt.DAL;
using SurfingBlogRt.Helpers;
using SurfingBlogRt.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SurfingBlogRt.Controllers
{
    public class RegisterController:Controller
    {
        DataContext context;

        public RegisterController()
        {
            context = new DataContext();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser(UserViewModel uvModel,IFormFile imageData)
        {         

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

                var roleId = setUserRole(uvModel.LoginAsACompany);

                var user = new User()
                {
                    Nickname = uvModel.Nickname,
                    Password = uvModel.Password,
                    Email = uvModel.Email,
                    RoleId = roleId
                };
                context.Users.Add(user);
                context.SaveChanges();

                await AuthenticateHelper.Authenticate(user.Id,user.Nickname,user.Role.RoleName, false, HttpContext); // аутентификация
                HttpContext.Session.SetInt32("Id", user.Id);

                return RedirectToAction("Index", "Home");
            }
            else ModelState.AddModelError("", "Проверьте корректность введённых данных.");

            return View("Index",uvModel);
        }
        public int setUserRole(bool asACompany) 
        {
            var roleName = asACompany ? "User" : "Company";
            return    context.Roles.FirstOrDefault(role => role.RoleName.Equals(roleName)).Id;
        }
    }
}
