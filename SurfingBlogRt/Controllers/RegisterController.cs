using Microsoft.AspNetCore.Mvc;
using SurfingBlogRt.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SurfingBlogRt.Controllers
{
    public class RegisterController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
