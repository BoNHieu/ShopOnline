using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Models;
using ShopOnline.Data;

namespace ShopOnline.Areas.Manage.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly HostingEnvironment _hostingEnviroment;
        public ProductsController(ApplicationDbContext context,HostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnviroment = hostingEnvironment;
        }

        // GET: Admin/Products
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Products.Include(p => p.Category);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/Products/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Admin/Products/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Image,Status,Descirption,CategoryId")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);

                // Image being saved

                string webRootPath = _hostingEnviroment.WebRootPath;

                var files = HttpContext.Request.Form.Files;

                var productFromDb = _context.Products.Find(product.Id);

                if(files.Count != 0)
                {
                    var uploads = Path.Combine(webRootPath, @"images\ProductImage");
                    var extension = Path.GetExtension(files[0].FileName);

                    using (var filestream = new FileStream(Path.Combine(uploads, product.Id + extension), FileMode.Create))
                    {
                        files[0].CopyTo(filestream);
                    }
                    productFromDb.Image = @"\" + @"images\ProductImage" + @"\" + product.Id + extension;
                }
                else
                {
                    var uploads = Path.Combine(webRootPath, @"images\ProductImage" + @"\" + "default_image.png");
                    System.IO.File.Copy(uploads, webRootPath + @"\" + @"images\ProductImage" + @"\" + product.Id + ".png");
                    productFromDb.Image = @"\" + @"images\ProductImage" + @"\" + product.Id + ".png";
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        // GET: Admin/Products/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Image,Status,Descirption,CategoryId")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string webRootPath = _hostingEnviroment.WebRootPath;

                    var files = HttpContext.Request.Form.Files;

                    var productFromDb = _context.Products.Where(m => m.Id == product.Id).FirstOrDefault();

                    if (files.Count > 0 && files[0] != null)
                    {
                        var uploads = Path.Combine(webRootPath, @"images\ProductImage");
                        var extension_new = Path.GetExtension(files[0].FileName);
                        var extension_old = Path.GetExtension(productFromDb.Image);

                        if (System.IO.File.Exists(Path.Combine(uploads, product.Id + extension_old)))
                        {
                            System.IO.File.Delete(Path.Combine(uploads, product.Id + extension_old));
                        }
                        using (var filestream = new FileStream(Path.Combine(uploads, product.Id + extension_new), FileMode.Create))
                        {
                            files[0].CopyTo(filestream);
                        }
                        product.Image = @"\" + @"images\ProductImage" + @"\" + product.Id + extension_new;
                    }
                    if (product.Image != null)
                    {
                        productFromDb.Image = product.Image;
                    }
                    productFromDb.Name = product.Name;
                    productFromDb.Status = product.Status;
                    productFromDb.Descirption = product.Descirption;
                    productFromDb.CategoryId = product.CategoryId;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var product = await _context.Products.FindAsync(id);
            string webRootPath = _hostingEnviroment.WebRootPath;

            if (product == null)
            {
                return NotFound();
            }
            else
            {
                var uploads = Path.Combine(webRootPath, @"images\ProductImage");
                var extension = Path.GetExtension(product.Image);

                if (System.IO.File.Exists(Path.Combine(uploads, product.Id + extension)))
                {
                    System.IO.File.Delete(Path.Combine(uploads, product.Id + extension));
                }
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(string id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
