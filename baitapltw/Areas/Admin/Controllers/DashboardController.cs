using baitapltw.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace baitapltw.Areas.Admin.Controllers
{
    
    public class DashboardController : Controller
    {
        //Get: admin/dashboard
        [Authorize(Roles = "admin")]
        public ActionResult index()
        {
            return View();
        }
        
    }
}