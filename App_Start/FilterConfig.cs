using System.Web.Mvc;

namespace Chess20
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Remove(new AuthorizeAttribute());
            //filters.Add(new AuthorizeAttribute());
        }
    }
}