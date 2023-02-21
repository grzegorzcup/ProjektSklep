using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjektSklep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjektSklep.Services;
using Microsoft.EntityFrameworkCore;
using ProjektSklep.Data;

namespace ProjektSklep.Controllers
{
    public class ShopController : Controller
    {
        private readonly IShopService _shopService;

        private readonly ProjektSklepContext _projektSklepContext;

        public ShopController(IShopService shopservice,ProjektSklepContext projektSklepContext)
        {
            _shopService = shopservice;
            _projektSklepContext= projektSklepContext;
        }

        public IActionResult Index()
        {
            var list = _shopService.GetAll();

            return View(list);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product body)
        {
            if (!ModelState.IsValid)
            {
                return View(body);
            }
            
            var id = _shopService.Save(body);

            TempData["ProductId"] = id;

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var product = _shopService.Get(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _shopService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}