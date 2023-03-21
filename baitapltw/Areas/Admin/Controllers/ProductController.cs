using baitapltw.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace baitapltw.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class ProductController : Controller
    {
        // GET: Admin/Product
        private readonly ApplicationDbContext dbContext = new ApplicationDbContext();
        public ActionResult Index()
        {
            var listProduct = dbContext.Products.ToList();
            return View(listProduct);
        }
        
        public ActionResult Details(int id)
        {
            var product = dbContext.Products.FirstOrDefault(x => x.Id == id);
            return View(product);
        }
        
        public ActionResult Create()
        {
            var ds = dbContext.Categories.ToList();
            ViewBag.categories = ds;
            return View();
        }
        
        [HttpPost]
        public ActionResult SaveProduct(Product product, HttpPostedFileBase FeatureImage)
        {
            if (!ModelState.IsValid)
            {
                var ds = dbContext.Categories.ToList();
                ViewBag.categories = ds;
                return View("Create", product);
            }
            string path = Path.Combine(Server.MapPath("~/Content/NoiThat/images"), Path.GetFileName(FeatureImage.FileName));
            FeatureImage.SaveAs(path);
            product.FeatureImage = "Content/NoiThat/images/" + Path.GetFileName(FeatureImage.FileName);
            
            dbContext.Products.Add(product);
            dbContext.SaveChanges();
            
            return RedirectToAction("Index", "Product");
        }
    }
}