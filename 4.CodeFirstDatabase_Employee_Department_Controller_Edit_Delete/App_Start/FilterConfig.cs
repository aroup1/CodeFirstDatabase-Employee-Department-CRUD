using System.Web;
using System.Web.Mvc;

namespace _4.CodeFirstDatabase_Employee_Department_Controller_Edit_Delete
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
