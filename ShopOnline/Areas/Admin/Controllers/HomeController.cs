using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models;
using ShopOnline.Data;

namespace ShopOnline.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public decimal total { get; set; }
        public IActionResult Index()
        {
            var countInput = _db.Inputs.ToList().Count;
            ViewBag.CountInput = countInput;

            var countProduct = _db.Products.ToList().Count;
            ViewBag.countProduct = countProduct;

            var countSupplier = _db.Suppliers.ToList().Count;
            ViewBag.countSupplier = countSupplier;

            var CountCategory = _db.Categories.ToList().Count;
            ViewBag.CountCategory = CountCategory;

            var ListInput = _db.InputInfos.ToList();
            foreach (var item in ListInput)
            {
                total += item.Count * item.Inputprice;
            }
            ViewData["total"] = total;
            return View(ListInput);
        }

        [HttpPost,ActionName("Index")]
        [ValidateAntiForgeryToken]
        public IActionResult Index(DateTime? DateStart,DateTime? DateEnd)
        {
            var countInput = _db.Inputs.ToList().Count;
            ViewBag.CountInput = countInput;

            var countProduct = _db.Products.ToList().Count;
            ViewBag.countProduct = countProduct;

            var countSupplier = _db.Suppliers.ToList().Count;
            ViewBag.countSupplier = countSupplier;

            var CountCategory = _db.Categories.ToList().Count;
            ViewBag.CountCategory = CountCategory;
            List<InputInfo> ListInput = new List<InputInfo>();
            if(DateStart == null && DateEnd == null)
            {
                ListInput = _db.InputInfos.ToList();
            }
            else if(DateStart == null && DateEnd != null)
            {
                ListInput = _db.InputInfos.Where(d => d.Input.DateInput <= DateEnd).ToList();
            }
            else if (DateStart != null && DateEnd == null)
            {
                ListInput = _db.InputInfos.Where(d => d.Input.DateInput >= DateStart).ToList();
            }
            else
            {
                ListInput = _db.InputInfos.Where(d => d.Input.DateInput >= DateStart && d.Input.DateInput <= DateEnd).ToList();
            }
            foreach(var item in ListInput)
            {
                total += item.Count * item.Inputprice;
            }
            ViewData["total"] = total;
            return View(ListInput);
        }
    }
}