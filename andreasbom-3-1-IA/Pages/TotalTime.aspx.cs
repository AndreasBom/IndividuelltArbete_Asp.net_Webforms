using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using andreasbom_3_1_IA.Model.BLL;


namespace andreasbom_3_1_IA.Pages
{
    public partial class TotalTime : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }


        public IEnumerable<andreasbom_3_1_IA.Model.BLL.TimeReport> ListView1_GetData()
        {
            //KOMPLETTERING, Valideringen kontrollerar att fråndatum är lägre än tom-datum, samt att ett godkänt datumformat skrivs in. I detta fallet kanske det inte hade varit absolut nödvändigt med validering på två ställen (javascript på klienten i form av valideringskontroller, samt i code-behide på servern) eftersom indata endast är parametrar till den lagrade proceduren, och inte data som skrivs till databasen. Men nu fungerar valideringen även om javascript är blockerad.

            var fromDate = TextBoxFromDate.Text;
            var toDate = TextBoxToDate.Text;

            //Om datumen i textboxarna kan konverteras till datumformat...
            try
            {
                var fr = Convert.ToDateTime(fromDate);
                var td = Convert.ToDateTime(toDate);

                //Om fråndatum är större än tilldatum fås ett felmeddelande
                if (fr > td)
                {
                    ModelState.AddModelError("Message",
                        "Fel TryUpdateModel datuminmatning, Från-datum måste vara lägre än t.o.m-datum");
                    return null;
                }

                //Klarar koden valideringen ovan anropas GetTotalTime
                return Service.GetTotalTime(Convert.ToDateTime(fromDate), Convert.ToDateTime(toDate));

            }
            //...Annars skickas ett felmeddelande till validationsummary
            catch
            {
                ModelState.AddModelError("Message", "Fel datuminmatning, Skriv in ett datum med formatet 2015-01-01");
                return null;
            }
        }

        //SLUT Komplettering

    }
}