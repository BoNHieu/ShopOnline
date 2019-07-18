using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Data;
using ShopOnline.Models;

namespace ShopOnline.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ManageUsersController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;

        public ManageUsersController(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var ListUser = await _db.ApplicationUsers.ToListAsync();
            var ListRole = await _db.ApplicationRoles.ToListAsync();
            return View(ListUser);
        }

        //GET/EDIT
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _db.ApplicationUsers.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ViewData["RoleId"] = new SelectList(_db.ApplicationRoles, "Id", "Name");
            return View(user);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(string id, ApplicationUsers user,string role)
        {
            ViewData["RoleId"] = new SelectList(_db.ApplicationRoles, "Id", "Name");
            if (id != user.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    ApplicationUsers userFromDb = await _db.ApplicationUsers.Where(d => d.Id == id).FirstOrDefaultAsync();
                    userFromDb.Name = user.Name;
                    userFromDb.UserName = user.UserName;
                    userFromDb.Email = user.Email;
                    userFromDb.Address = user.Address;
                    userFromDb.PhoneNumber = user.PhoneNumber;

                    if(role != null)
                    {
                        ApplicationRoles Role = await _db.ApplicationRoles.FindAsync(role);
                        var result = _db.UserRoles.Where(d => d.UserId == id).FirstOrDefault();
                        var OldRole = _db.ApplicationRoles.Find(result.RoleId);

                        if (result == null)
                        {
                            await _userManager.AddToRoleAsync(userFromDb, Role.Name);
                        }
                        else
                        {
                            await _userManager.RemoveFromRoleAsync(userFromDb, OldRole.Name);
                            await _userManager.AddToRoleAsync(userFromDb, Role.Name);
                        }
                    }

                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationUsersExists(user.Id))
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
            return View(user);
        }


        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _db.ApplicationUsers.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(string id)
        {
            //ApplicationUsers userFromDb = await _db.ApplicationUsers.Where(d => d.Id == id).FirstOrDefaultAsync();
            //userFromDb.LockoutEnd = DateTime.Now.AddYears(1000);
            var user = await _db.ApplicationUsers.FindAsync(id);
            _db.ApplicationUsers.Remove(user);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationUsersExists(string id)
        {
            return _db.ApplicationUsers.Any(e => e.Id == id);
        }
    }
}