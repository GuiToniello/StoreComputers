using System.Web;
using System.Web.Mvc;

namespace Uniplac.Trabalho_Final.Apresentacao.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
