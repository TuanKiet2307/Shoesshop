using baitapltw.Models;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace baitapltw.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext dbContext = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View(dbContext.Products.ToList());    
        }
    }
}