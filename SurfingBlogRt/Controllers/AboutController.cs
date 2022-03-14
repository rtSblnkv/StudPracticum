using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SurfingBlogRt.DAL;
using SurfingBlogRt.Models;

namespace SurfingBlogRt.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        public IActionResult About()
        {
            return View();
        }
    }
}
