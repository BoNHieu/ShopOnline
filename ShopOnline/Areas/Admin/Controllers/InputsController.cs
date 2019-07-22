using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Models;
using ShopOnline.Data;
using ShopOnline.Models;
using ShopOnline.Models.ViewModel;

namespace ShopOnline.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class InputsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        [BindProperty]
        public InputViewModel InputVM { get; set; }
        
        public InputsController(ApplicationDbContext db,UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager)
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            var ListInput = _db.Inputs.ToList();

            return View(ListInput);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost,ActionName("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePost([Bind("Id,Name,DateInput")] Input input)
        {
            if(ModelState.IsValid)
            {
                if (_signInManager.IsSignedIn(User))
                {
                    var InputUser = _db.ApplicationUsers.Where(d => d.Id == _userManager.GetUserId(User)).FirstOrDefault();
                    input.Name = InputUser.Name;
                }
                _db.Inputs.Add(input);
                _db.SaveChanges();
                return RedirectToAction("Create","InputInfoes",new {InputId = input.Id });
            }
            return View(input);
        }


        public async Task<IActionResult> Edit(string Id)
        {
            if(Id == null)
            {
                return NotFound();
            }
            var Input = await _db.Inputs.FindAsync(Id);
            if(Input == null)
            {
                return NotFound();
            }
            else
            {
                InputVM = new InputViewModel()
                {
                    Input = Input,
                    inputInfos = _db.InputInfos
                    .Include(d=>d.Product)
                    .Include(d=>d.Supplier)
                    .Where(d => d.InputId == Id).ToList()
                };
            }
            return View(InputVM);
        }


        public async Task<IActionResult> Details(string Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var Input = await _db.Inputs.FindAsync(Id);
            if (Input == null)
            {
                return NotFound();
            }
            else
            {
                InputVM = new InputViewModel()
                {
                    Input = Input,
                    inputInfos = _db.InputInfos
                    .Include(d => d.Product)
                    .Include(d => d.Supplier)
                    .Where(d => d.InputId == Id).ToList()
                };
            }
            return View(InputVM);
        }


    }
}