using System.Web.Routing;

namespace andreasbom_3_1_IA
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("About",        "about",            "~/Page/Om.aspx");
            routes.MapPageRoute("Newemployee", "employees/new",     "~/Pages/NewEmployee.aspx");
            routes.MapPageRoute("Edit",         "employee/{id}",         "~/Pages/EditEmployee.aspx");
            routes.MapPageRoute("Serverfel",    "serverfel",        "~/Pages/Shared/Error.aspx");
            routes.MapPageRoute("Default",      "",                 "~/Pages/Default.aspx");
            routes.MapPageRoute("Employees",    "employees/all",    "~/Pages/Employees.aspx");


        }
    }
}