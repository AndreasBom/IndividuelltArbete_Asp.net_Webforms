using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using andreasbom_3_1_IA.Model.BLL;

namespace andreasbom_3_1_IA.Pages
{
    public partial class EditEmployee : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        public andreasbom_3_1_IA.Model.BLL.Employee FormViewEmployee_GetItem([RouteData]int id)
        {
            try
            {
                return Service.GetEmpolyee(id);
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett fel inträffade när uppgifterna skulle hämtas");
                return null;
            }
        }

        public void FormViewEmployee_UpdateItem(int EmpID)
        {
            
            try
            {
                var employee = Service.GetEmpolyee(EmpID);

                if (TryUpdateModel(employee))
                {
                    Service.SaveEmployee(employee);
                    Page.SetTempData("Message",
                    String.Format("Uppgifterna har uppdaterats"));
                    Response.RedirectToRoute("Employees");
                }
            }
            catch (Exception)
            {

                ModelState.AddModelError(String.Empty, "Fel inträffade då personaluppgifter skulle uppdateras.");
            }
        }


        public void FormViewEmployee_DeleteItem(int EmpID)
        {
            try
            {
                var employee = Service.GetEmpolyee(EmpID);
                Service.DeleteEmployee(EmpID);
                Page.SetTempData("Message",
                    String.Format("Personaluppgifter för {0} {1} raderades", employee.FirstName, employee.LastName));
                Response.RedirectToRoute("Employees");
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }
                ModelState.AddModelError(String.Empty, ex.Message);
               
            }
        }

    }
}