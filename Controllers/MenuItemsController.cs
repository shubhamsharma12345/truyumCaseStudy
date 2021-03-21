using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Turuyum.Models;

namespace Turuyum.Controllers
{
    public class MenuItemsController : Controller
    {
        truYumContext db = new truYumContext();
        // GET: MenuItems
        public ActionResult Index()
        {
            var list = db.Categories.ToList();
            return View(list);
        }
        public ActionResult Insert()
        {
            Category cat = new Category();
            return View(cat);

        }

        [HttpPost]
        public ActionResult Insert(Category cat)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(cat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Insert");
            }


        }
        public ActionResult MenuList()
        {
            var list = db.MenuItems.ToList();
            return View(list);
        }
        public ActionResult MenuInsert()
        {
            MenuItem menu = new MenuItem();
            var list = db.Categories.ToList();
            ViewBag.Category = list;
            return View(menu);

        }

        [HttpPost]
        public ActionResult MenuInsert(MenuItem menu)
        {
            if (ModelState.IsValid)
            {
                db.MenuItems.Add(menu);
                db.SaveChanges();
                return RedirectToAction("MenuList");
            }
            else
            {
                return RedirectToAction("MenuInsert");
            }


        }
        public ActionResult MenuUpdate(int? id)
        {
            MenuItem menu = null;
            if (id != null)
            { menu = db.MenuItems.Find(id);
            }
            var list = db.Categories.ToList();
            ViewBag.Category = list;
            return View(menu);
        }
        
        [HttpPost]
        public ActionResult MenuUpdate(int? id, MenuItem menu)
        {

            if (ModelState.IsValid)
            {
                var list = db.MenuItems.Where(x => x.MenuItemId == id).ToList();
                list.ForEach(x =>
                {
                    x.Name = menu.Name;
                    x.freedelivery = menu.freedelivery;
                    x.price = menu.price;
                    x.Active = menu.Active;
                    x.CategoryId = menu.CategoryId;

                });
                db.SaveChanges();

            }
            return RedirectToAction("MenuList");
        }
    }
}