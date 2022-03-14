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
    public class AnnoucementTypesController : Controller
    {
        private readonly DataContext _context;

        public AnnoucementTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: AnnoucementTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.AnnoucementTypes.ToListAsync());
        }

        // GET: AnnoucementTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var annoucementType = await _context.AnnoucementTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (annoucementType == null)
            {
                return NotFound();
            }

            return View(annoucementType);
        }

        // GET: AnnoucementTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AnnoucementTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TypeName")] AnnoucementType annoucementType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(annoucementType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(annoucementType);
        }

        // GET: AnnoucementTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var annoucementType = await _context.AnnoucementTypes.FindAsync(id);
            if (annoucementType == null)
            {
                return NotFound();
            }
            return View(annoucementType);
        }

        // POST: AnnoucementTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TypeName")] AnnoucementType annoucementType)
        {
            if (id != annoucementType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(annoucementType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnnoucementTypeExists(annoucementType.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(annoucementType);
        }

        // GET: AnnoucementTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var annoucementType = await _context.AnnoucementTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (annoucementType == null)
            {
                return NotFound();
            }

            return View(annoucementType);
        }

        // POST: AnnoucementTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var annoucementType = await _context.AnnoucementTypes.FindAsync(id);
            _context.AnnoucementTypes.Remove(annoucementType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnnoucementTypeExists(int id)
        {
            return _context.AnnoucementTypes.Any(e => e.Id == id);
        }
    }
}
