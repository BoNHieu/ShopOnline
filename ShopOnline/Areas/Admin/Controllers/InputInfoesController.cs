using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Models;
using ShopOnline.Data;

namespace ShopOnline.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class InputInfoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InputInfoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/InputInfoes
        //public async Task<IActionResult> Index(string InputId)
        //{
        //    var applicationDbContext = _context.InputInfos.Include(i => i.Input).Include(i => i.Product).Include(i => i.Supplier).Where(d=>d.InputId == InputId);
        //    ViewData["InputId"] = InputId;
        //    return View(await applicationDbContext.ToListAsync());
        //}

        // GET: Admin/InputInfoes/Details/5
        //public async Task<IActionResult> Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var inputInfo = await _context.InputInfos
        //        .Include(i => i.Input)
        //        .Include(i => i.Product)
        //        .Include(i => i.Supplier)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (inputInfo == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(inputInfo);
        //}

        // GET: Admin/InputInfoes/Create
        public IActionResult Create(string InputId)
        {
            ViewData["InputId"] = new SelectList(_context.Inputs, "Id", "Id");
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name");
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "Id", "Name");
            return View();
        }

        // POST: Admin/InputInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost,ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePost(string InputId,[Bind("Id,InputId,ProductId,SupplierId,Count,Inputprice,OutputPrice")] InputInfo inputInfo)
        {
            if (ModelState.IsValid)
            {
                inputInfo.InputId = InputId;
                _context.Add(inputInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Edit", "Inputs", new { Id = InputId });
            }
            ViewData["InputId"] = new SelectList(_context.Inputs, "Id", "Id", inputInfo.InputId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", inputInfo.ProductId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "Id", "Name", inputInfo.SupplierId);
            return View(inputInfo);
        }

        // GET: Admin/InputInfoes/Edit/5
        public async Task<IActionResult> Edit(string id,string InputId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inputInfo = await _context.InputInfos.FindAsync(id);
            if (inputInfo == null)
            {
                return NotFound();
            }
            ViewData["InputId"] = new SelectList(_context.Inputs, "Id", "Id", inputInfo.InputId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", inputInfo.ProductId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "Id", "Name", inputInfo.SupplierId);
            return View(inputInfo);
        }

        // POST: Admin/InputInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id,string InputId, [Bind("Id,InputId,ProductId,SupplierId,Count,Inputprice,OutputPrice")] InputInfo inputInfo)
        {
            if (id != inputInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inputInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InputInfoExists(inputInfo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Edit", "Inputs", new { Id = InputId });
            }
            ViewData["InputId"] = new SelectList(_context.Inputs, "Id", "Id", inputInfo.InputId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", inputInfo.ProductId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "Id", "Name", inputInfo.SupplierId);
            return View(inputInfo);
        }

        // GET: Admin/InputInfoes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inputInfo = await _context.InputInfos
                .Include(i => i.Input)
                .Include(i => i.Product)
                .Include(i => i.Supplier)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inputInfo == null)
            {
                return NotFound();
            }

            return View(inputInfo);
        }

        // POST: Admin/InputInfoes/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(string id)
        //{
        //    var inputInfo = await _context.InputInfos.FindAsync(id);
        //    _context.InputInfos.Remove(inputInfo);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool InputInfoExists(string id)
        {
            return _context.InputInfos.Any(e => e.Id == id);
        }
    }
}
