using baitapltw.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace baitapltw.ViewModel
{
    public class NewsViewModel
    {
        public IEnumerable<Product> UpcommingProducts { get; set; }
        public bool ShowAction { get; set; }
    }
}