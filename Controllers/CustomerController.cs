using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Turuyum.Models;

namespace Turuyum.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        truYumContext db = new truYumContext();
        public ActionResult Index()
        {
            var list = db.MenuItems.ToList();
            ViewBag.Clist = db.Categories.ToList();
            return View(list);
        }
        public ActionResult Cart(int? id)
        {
            if (id != null)
            {
                Cart cart = new Cart()
                {
                    MenuItemId = (int)id
                };
                db.Carts.Add(cart);
                db.SaveChanges();
                return RedirectToAction("ViewCart");
            }
            else
            {
                return View("Cart");
            }
        }
        public class CartList
        {
            public int CartId { get; set; }
            public string Name { get; set; }
            public bool FreeDelivery { get; set; }
            public double Price { get; set; }
        }
        public ActionResult ViewCart()
        {
            var list = (from cart in db.Carts
                        join menu in db.MenuItems on cart.MenuItemId equals menu.MenuItemId
                        orderby cart.MenuItemId
                        select new CartList()
                        {
                            CartId = cart.MenuItemId,
                            Name = menu.Name,
                            FreeDelivery = menu.freedelivery,
                            Price = menu.price,
                        }).ToList();

            return View(list);
        }
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                Cart Cid = db.Carts.Find(id);
                db.Carts.Remove(Cid);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }
    }
}
