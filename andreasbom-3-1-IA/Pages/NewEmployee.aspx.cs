using System;
using andreasbom_3_1_IA.Model.BLL;

namespace andreasbom_3_1_IA.Pages
{


    public partial class NewEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void FormView1_InsertItem()
        {
            var employee = new andreasbom_3_1_IA.Model.BLL.Employee();
            
            TryUpdateModel(employee);
            if (ModelState.IsValid)
            {
                try
                {
                    Service service = new Service();
                    service.SaveEmployee(employee);
                    Page.SetTempData("Message",
                    String.Format("Uppgifterna har sparats"));
                    Response.RedirectToRoute("Employees");
                }
                catch (Exception)
                {
                    
                    throw;
                }

            }
        }
    }
}