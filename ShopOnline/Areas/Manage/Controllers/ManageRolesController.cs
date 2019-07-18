using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Data;
using ShopOnline.Models;

namespace ShopOnline.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ManageRolesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ManageRolesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Manage/ManageRoles
        public async Task<IActionResult> Index()
        {
            return View(await _context.ApplicationRoles.ToListAsync());
        }

        // GET: Manage/ManageRoles/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationRoles = await _context.ApplicationRoles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (applicationRoles == null)
            {
                return NotFound();
            }

            return View(applicationRoles);
        }

        // GET: Manage/ManageRoles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Manage/ManageRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,NormalizedName,ConcurrencyStamp")] ApplicationRoles applicationRoles)
        {
            if (ModelState.IsValid)
            {
                _context.Add(applicationRoles);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(applicationRoles);
        }

        // GET: Manage/ManageRoles/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationRoles = await _context.ApplicationRoles.FindAsync(id);
            if (applicationRoles == null)
            {
                return NotFound();
            }
            return View(applicationRoles);
        }

        // POST: Manage/ManageRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,NormalizedName,ConcurrencyStamp")] ApplicationRoles applicationRoles)
        {
            if (id != applicationRoles.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicationRoles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationRolesExists(applicationRoles.Id))
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
            return View(applicationRoles);
        }

        // GET: Manage/ManageRoles/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationRoles = await _context.ApplicationRoles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (applicationRoles == null)
            {
                return NotFound();
            }

            return View(applicationRoles);
        }

        // POST: Manage/ManageRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var applicationRoles = await _context.ApplicationRoles.FindAsync(id);
            _context.ApplicationRoles.Remove(applicationRoles);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationRolesExists(string id)
        {
            return _context.ApplicationRoles.Any(e => e.Id == id);
        }
    }
}
