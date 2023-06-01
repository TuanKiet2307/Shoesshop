using baitapltw.Models;
using baitapltw.ViewModel;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public ActionResult IndexCate()
        {
            return View(dbContext.Products.ToList());
        }
        public ActionResult Business()
        {
            return View(dbContext.Products.ToList());
        }
        public ActionResult Technology()
        {
            return View(dbContext.Products.ToList());
        }
        public ActionResult World()
        {
            return View(dbContext.Products.ToList());
        }
        public ActionResult Law()
        {
            return View(dbContext.Products.ToList());
        }
        public ActionResult Sport()
        {
            return View(dbContext.Products.ToList());
        }
        public ActionResult Education()
        {
            return View(dbContext.Products.ToList());
        }
        public ActionResult Social()
        {
            return View(dbContext.Products.ToList());
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
        public RedirectToRouteResult RemoveItem(int ProductId)
        {
            List<CartItem> cart = (List<CartItem>)Session["cart"];
            CartItem DelItem = cart.FirstOrDefault(x => x.Product.Id == ProductId);
            if (DelItem != null)
            {
                cart.Remove(DelItem);
            }
            return RedirectToAction("ViewCart");
        }
        public ActionResult ViewCart()
        {
            return View();
        }
        public ActionResult Search(string strSearch)
        {
            List<Product> product = dbContext.Products.OrderBy(x => x.Title).ToList();
            if(!string.IsNullOrEmpty(strSearch))
            {
                product = product.Where(x => x.Title.Contains(strSearch)).ToList();
            }
            return View(product);
        }
        [Authorize]
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();
            var product = dbContext.Attendances.Where(a => a.AttendeeId == userId).Select(a => a.Product).Include(l => l.Category).ToList();
            var viewModel = new NewsViewModel
            {
                UpcommingProducts = product,
                ShowAction = User.Identity.IsAuthenticated
            };
            return View(viewModel);
        }

    }
}