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
        private readonly ApplicationDbContext dbContext = new ApplicationDbContext();
        // GET: Admin/Product
        public ActionResult Index()
        {
            var listProduct = dbContext.Products.ToList();
            return View(listProduct);
        }

        public ActionResult Create()
        {

            var listCate = dbContext.Categories.ToList();
            ViewBag.Loai = listCate;
            return View();
        }
        [HttpPost]
        public ActionResult SaveProduct(Product product, HttpPostedFileBase FeatureImage)
        {
            if (!ModelState.IsValid)
            {

                var listCate = dbContext.Categories.ToList();
                ViewBag.Loai = listCate;
                return View("Create", product);
            }
            string path = Path.Combine(Server.MapPath("~/Content/NoiThat/images"), Path.GetFileName(FeatureImage.FileName));
            FeatureImage.SaveAs(path);
            product.FeatureImage = "/Content/NoiThat/images/" + Path.GetFileName(FeatureImage.FileName);
            dbContext.Products.Add(product);
            dbContext.SaveChanges();
            return RedirectToAction("Index", "Product");
        }
    }
}