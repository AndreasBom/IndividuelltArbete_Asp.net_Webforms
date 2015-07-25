using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using andreasbom_3_1_IA.Model.BLL;

namespace andreasbom_3_1_IA.Pages.Shared
{

    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string message = Page.GetTempData("Message") as string;
            
            if (message != null)
            {
                LiteralMessage.Text = message;
                PanelSuccessMessage.Visible = true;
            }
        }
    }
}