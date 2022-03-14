using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SurfingBlogRt.DAL;
using SurfingBlogRt.Models;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SurfingBlogRt.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = new DataContext();
        }

        public async Task<IActionResult> Index()
        {
            if(HttpContext.User.Identity.IsAuthenticated)
            {
                if (HttpContext.User.Claims.Any())
                {
                    var claim = HttpContext.User.FindFirstValue(ClaimTypes.Name);
                    var user = _context.Users.FirstOrDefault(user => user.Nickname == claim);              
                }
            }          
            return await CreateStatisticTable();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> CreateStatisticTable()
        {
            var table = new List<StatisticTableViewModel>();

            var announcements = await _context.Announcements
                .Include(a => a.Type)
                .ToListAsync();

            foreach(var announcment in announcements)
            {
                if(table.Any(elem => elem.Type.Equals(announcment.Type.TypeName) &&
                elem.Theme.Equals(announcment.Theme)))
                {
                    var tableItem = table.Where(elem =>
                         elem.Type.Equals(announcment.Type.TypeName) &&
                         elem.Theme.Equals(announcment.Theme)).FirstOrDefault();
                    tableItem.Count++;
                }
                else
                {
                    table.Add(new StatisticTableViewModel()
                    {
                        Count = 1,
                        Theme = announcment.Theme,
                        Type = announcment.Type.TypeName
                    });
                }
            }
            var orderedTable = table.OrderBy(elem => elem.Type).ToList();
            return View(orderedTable);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
