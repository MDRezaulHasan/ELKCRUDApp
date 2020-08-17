using System.Web.Mvc;

namespace ELKCRUDApp.Areas.ElasticsearchApi
{
    public class ElasticsearchApiAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ElasticsearchApi";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ElasticsearchApi_default",
                "ElasticsearchApi/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}