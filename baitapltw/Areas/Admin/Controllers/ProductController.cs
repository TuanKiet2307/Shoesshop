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
            string path = Path.Combine(Server.MapPath("~/Content/SanPham/assets/img/"), Path.GetFileName(FeatureImage.FileName));
            FeatureImage.SaveAs(path);
            product.FeatureImage = "/Content/SanPham/assets/img/" + Path.GetFileName(FeatureImage.FileName);
            dbContext.Products.Add(product);
            dbContext.SaveChanges();
            return RedirectToAction("Index", "Product");
        }
        public ActionResult Update(int id)
        {
            var listCate = dbContext.Categories.ToList();
            ViewBag.Loai = listCate;
            var findProduct = dbContext.Products.Find(id);
            return View(findProduct);
        }
        [HttpPost]
        public ActionResult Update(Product product, HttpPostedFileBase FeatureImage)
        {
            if (!ModelState.IsValid)
            {
                var listCate = dbContext.Categories.ToList();
                ViewBag.Loai = listCate;
                return View("Create", product);
            }
            var updateProduct = dbContext.Products.Find(product.Id);
            string path = Path.Combine(Server.MapPath("~/Content/SanPham/assets/img/"), Path.GetFileName(FeatureImage.FileName));
            FeatureImage.SaveAs(path);
            updateProduct.Title = product.Title;
            updateProduct.Detail = product.Detail;
            updateProduct.ProductCateId = product.ProductCateId;
            updateProduct.Des = product.Des;
            updateProduct.FeatureImage = product.FeatureImage;
            updateProduct.FeatureImage = "/Content/SanPham/assets/img/" + Path.GetFileName(FeatureImage.FileName);
            dbContext.SaveChanges();
            return RedirectToAction("Index", "Product");
        }

        public ActionResult Delete(int id) 
        {
            var findProduct = dbContext.Products.Find(id);
            dbContext.Products.Remove(findProduct);
            dbContext.SaveChanges();
            return RedirectToAction("Index", "Product");
        }
    }
}