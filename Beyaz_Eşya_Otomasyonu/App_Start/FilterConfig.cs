using System.Web;
using System.Web.Mvc;

namespace Beyaz_Eşya_Otomasyonu
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
