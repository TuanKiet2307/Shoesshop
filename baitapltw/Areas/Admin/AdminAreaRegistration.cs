using System.Web.Mvc;

namespace baitapltw.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { controller = "Dashboard" ,action = "Index", id = UrlParameter.Optional }, new[] { "baitapltw.Areas.Admin.Controllers" }
            );
        }
    }
}