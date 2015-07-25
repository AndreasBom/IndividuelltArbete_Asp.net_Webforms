using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using andreasbom_3_1_IA.Model.DAL;
using andreasbom_3_1_IA.Model.BLL;


namespace andreasbom_3_1_IA.Pages
{
    public partial class Default : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        //Fetches and returns all employees
        private IEnumerable<ShiftsAndEmployees> ShiftList
        {
            get { return Service.GetCachedShifts(); }
            
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        //Returns a List of shifts, pageWise
        public IEnumerable<ShiftsAndEmployees> ListViewAllShifts_GetData(int maximumRows, int startRowIndex, out int totalRowCount)
        {
                totalRowCount = ShiftList.Count();
                return ShiftList.Skip(startRowIndex).Take(maximumRows);
        }
        
        //Insert new shifts
        public void FormView1_InsertItem()
        {
            var shift = new Shift();
            TryUpdateModel(shift);
            if (ModelState.IsValid)
            {
                try
                {
                    Service.InsertShift(shift);
                    //Success message saved in Session varible "Message"
                    Page.SetTempData("Message", String.Format("Uppgifterna har sparats"));
                    //Flush cache 
                    HttpContext.Current.Cache.Remove("Shifts");
                    Response.RedirectToRoute("Default");
                }
                catch (Exception)
                {

                    ModelState.AddModelError(String.Empty, "Passet kunde inte sparas.");
                }
            }
        }

        public IEnumerable<TypeOfShift> DropDownListTypeOfShift_GetData()
        {
            return Service.GetCachedTypeOfShift();
        }

        public IEnumerable<Model.BLL.Employee> DropDownListEmployee_GetData()
        {
            return Service.GetCachedAllEmployees();
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void FormView1_DeleteItem(int ShiftID)
        {
            try
            {
                Service.DeleteShift(ShiftID);
                Page.SetTempData("Message", "Passet har raderats");
                //Flush cache 
                HttpContext.Current.Cache.Remove("Shifts");
                Response.RedirectToRoute("Default");
            }
            catch
            {

                ModelState.AddModelError("", "Något fel inträffade när passet skulle raderas");
            }
        }
    }
}