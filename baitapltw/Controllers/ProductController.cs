using baitapltw.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace baitapltw.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        private readonly ApplicationDbContext dbContext = new ApplicationDbContext();
        public ActionResult Details(int id)
        {
            var product = dbContext.Products.FirstOrDefault(x => x.Id == id);
            return View(product);
        }
        private int isExist(int id)
        {
            List<CartItem> cart = (List<CartItem>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Product.Id.Equals(id))
                    return i;
            return -1;
        }
        public ActionResult UpdateCart()
        {
            int productId = int.Parse(Request.Form["productId"]);
            int quantity = int.Parse(Request.Form["quantity"]);

            List<CartItem> cart = (List<CartItem>)Session["cart"];
            int index = isExist(productId);
            if (index != -1)
            {
                cart[index].Quantity = quantity;
            }
            Session["cart"] = cart;


            return RedirectToAction("ViewCart");
        }
        public ActionResult AddCart(int id)
        {
            Product product = dbContext.Products.Find(id);
            if (Session["cart"] == null)
            {
                List<CartItem> cart = new List<CartItem>();
                cart.Add(new CartItem { Product = product, Quantity = 1 });
                Session["cart"] = cart;
            }
            else
            {
                List<CartItem> cart = (List<CartItem>)Session["cart"];
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new CartItem { Product = product, Quantity = 1 });
                }
                Session["cart"] = cart;
            }
            return RedirectToAction("ViewCart");
        }
        public ActionResult ViewCart()
        {
            return View();
        }
    }
}