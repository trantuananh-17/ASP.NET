using System.Web;
using System.Web.Mvc;

namespace TranTuanAnh_2022604426
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
