using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using andreasbom_3_1_IA.Model.BLL;

namespace andreasbom_3_1_IA.Pages
{
    public partial class Employees : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        //Fetches and returns all employees
        private IEnumerable<Model.BLL.Employee> EmployeesList
        {
            get { return Service.GetAllEmployees(); }
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public IEnumerable<Model.BLL.Employee> ListViewEmployees_GetData(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            totalRowCount = EmployeesList.Count();
            return EmployeesList.Skip(startRowIndex).Take(maximumRows);
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewEmployees_DeleteItem(int EmpID)
        {
            try
            {
                Service.DeleteEmployee(EmpID);
            }
            catch (Exception)
            {

                throw new ApplicationException("Could not delete contact");
            }
        }
    }
}