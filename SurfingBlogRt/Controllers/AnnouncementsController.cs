using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SurfingBlogRt.DAL;
using SurfingBlogRt.Helpers;
using SurfingBlogRt.Models;

namespace SurfingBlogRt.Controllers
{
    public class AnnouncementsController : Controller
    {
        private readonly DataContext _context;

        public AnnouncementsController()
        {
            _context = new DataContext();
        }

        // GET: Announcements
        public async Task<IActionResult> Show(string type, int? id, string format, string location)
        {
            var announcements = await 
                getAnnouncementsFiltered(type,format,location)
                .ToListAsync();
            ViewData["Type"] = type;
            //Клара Цетки

            int page = id ?? 0;
            if (IsAjaxRequest())
            {
                return PartialView("Items", PageHelper.GetItemsPage(announcements,page));
            }
            else
            {
                ViewData["Themes"] = getThemeFilterData(type);
                ViewData["Locations"] = getLocationFilterData(type);
                ViewData["Formats"] = getFormatFilterData(type);
                return View(PageHelper.GetItemsPage(announcements, page));
            }           
        }

        public bool IsAjaxRequest()
        {
            if (Request == null)
                throw new ArgumentNullException("Request is null");
            if (Request.Headers != null)
                return Request.Headers["X-Requested-With"] == "XMLHttpRequest";
            return false;
        }

        public IQueryable<Announcement> getAnnouncementsFiltered(string type, string format, string location)
        {
            IQueryable<Announcement> filteredAnnouncementsQuery =  _context.Announcements
                .Include(a => a.Company)
                .Include(a => a.Type)
                .Where(announcement => announcement.Type.TypeName.Equals(type));

            if(format != null)
            {
                filteredAnnouncementsQuery = filteredAnnouncementsQuery.Where(a => a.Format.Equals(format));
            }

            if(location != null)
            {
                filteredAnnouncementsQuery = filteredAnnouncementsQuery.Where(a => a.Location.Equals(location));
            }

            return filteredAnnouncementsQuery;
        }

        // GET: Announcements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var announcement = await _context.Announcements
                .Include(a => a.Company)
                .Include(a => a.Type)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (announcement == null)
            {
                return NotFound();
            }

            return View(announcement);
        }

        // GET: Announcements/Create
        public IActionResult Create()
        {
            ViewData["TypeIds"] = getAnnouncementTypeData();
            return View();
        }

        // POST: Announcements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TypeId,Description,Name,Theme,Location,Format,StartDate,LongtityInDays,CreateDate,Image")] Announcement announcement)
        {
            if (ModelState.IsValid)
            {
                var companyIdString = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!int.TryParse(companyIdString, out var companyId))
                {
                    return View("Create", announcement);
                }

                announcement.CompanyId = companyId;
                _context.Add(announcement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details),announcement);
            }
            ViewData["TypeIds"] = getAnnouncementTypeDataEditing(announcement.TypeId);
            return View(announcement);
        }

        // GET: Announcements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var announcement = await _context.Announcements.FindAsync(id);
            if (announcement == null)
            {
                return NotFound();
            }
            ViewData["TypeIds"] = getAnnouncementTypeDataEditing(announcement.TypeId);
            return View(announcement);
        }

        public SelectList getThemeFilterData(string type)
        {
            return new SelectList(
                _context.Announcements
                .Include(a => a.Type)
                .Where(a => a.Type.TypeName.Equals(type))
                .Select(a => a.Theme)
                .Distinct());
        }

        public SelectList getLocationFilterData(string type)
        {
            return new SelectList(
                _context.Announcements
                .Include(a => a.Type)
                .Where(a => a.Type.TypeName.Equals(type))
                .Select(a => a.Location)
                .Distinct());
        }

        public SelectList getFormatFilterData(string type)
        {
            return new SelectList(
                _context.Announcements
                .Include(a => a.Type)
                .Where(a => a.Type.TypeName.Equals(type))
                .Select(a => a.Format)
                .Distinct());
        }

        public SelectList getAnnouncementTypeDataEditing(int typeId)
        {
            return new SelectList(_context.AnnoucementTypes, "Id", "TypeName", typeId);
        }

        public SelectList getAnnouncementTypeData()
        {
            return new SelectList(_context.AnnoucementTypes, "Id", "TypeName");
        }

        // POST: Announcements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,Name,Theme,Location,Format,StartDate,LongtityInDays,CreateDate,Image")] Announcement announcement)
        {
            if (id != announcement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(announcement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnnouncementExists(announcement.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Details), announcement);
            }
            ViewData["TypeIds"] = getAnnouncementTypeDataEditing(announcement.TypeId);
            return View(announcement);
        }

        // GET: Announcements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var announcement = await _context.Announcements
                .Include(a => a.Company)
                .Include(a => a.Type)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (announcement == null)
            {
                return NotFound();
            }

            return View(announcement);
        }

        // POST: Announcements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var announcement = await _context.Announcements
                .Include(a => a.Type)
                .FirstAsync(a => a.Id == id);
            _context.Announcements.Remove(announcement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Show),new { type = announcement.Type.TypeName, id = 1 });
        }

        private bool AnnouncementExists(int id)
        {
            return _context.Announcements.Any(e => e.Id == id);
        }
    }
}
