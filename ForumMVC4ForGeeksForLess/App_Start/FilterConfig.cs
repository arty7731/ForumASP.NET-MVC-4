using System.Web;
using System.Web.Mvc;

namespace ForumMVC4ForGeeksForLess
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}