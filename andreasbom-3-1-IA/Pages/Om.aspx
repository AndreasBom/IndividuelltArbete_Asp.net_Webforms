<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Om.aspx.cs" Inherits="andreasbom_3_1_IA.Pages.Om" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPageHeader" runat="server">
    <div class="container page-header-text background">
        <h3 class="container page-header-text">Individuellt Arbete </h3>
    <h4 class="container page-header-text">1DV406 ASP.NET Webforms (7,5hp) och 1DV405 Databasteknik (7,5hp)</h4>
        <h6 class="container page-header-text"><em>Webbprogrammerare 120hp </em><br/><em>Linnéuniversitetet, Fakulteten för teknik</em></h6>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

    <div class="container full row background">
        <div class="col-sm-12">
            <h5 id="h5-om">Arbetet genomfördes som ett slutprojekt i kurserna ASP.NET Webforms och Databasteknik under våren 2015. Nedan följer projektets riktlinjer. 
            </h5>

            <h4>Krav på webbapplikationen till det individuella arbetet</h4>
            <p>(Krav kursen Databasteknik ställer på databasen som ingår i det individuella arbetet hittar du på webbplatsen för kursen <a href="https://coursepress.lnu.se/kurs/databasteknik/beskrivning/" target="_blank ">Databasteknik</a> )</p>
            
            <ul id="about">
                <li>Det individuella arbetet ska i sin helhet versionshanteras via Git och hanteras på GitHub. Repositoriet du ska använda tillhandahålls av kursledningen.
                    En idébeskrivning, pdf- eller md-fil med namnet idebeskrivning.pdf|md, ska senast tisdagen den 3 mars 2015 12:00 lags upp i repositoriet för ditt individuella arbete. Meddela även kurseldningen att det finns en idébeskrivning. Idébeskrivningen ska innehålla:
                        <ul>
                            <li>En kort beskrivning av problemet.</li>
                            <li>En fysisk datamodell i form av ett databasdiagram om tre tabeller med relationer mellan tabellerna. Exempeldata ska även finnas för samtliga tabeller i datamodellen.</li>
                            <li>
                                “Mockup”, en eller flera av enklare slag, vars fokus är att beskriva funktion snarare än grafisk design.
                            </li>
                            <li>
                               Den fullständiga webbapplikationen och databasen måste senast tisdagen den 17 mars 2015 12:00 ha publicerats på publikationsservern FALKEN. Källkoden till den publicerade applikationen ska finnas tillgänglig på GitHub, helst i form av en “release”. 
                            </li>
                        </ul>
                </li>
                <li>
                    Webbapplikationen ska vara skapad med ASP.NET 4.5 och C#.
                </li>
                <li>
                    Webbapplikationen måste bestå av minst två .aspx-sidor.
                </li>
                <li>
                    Webbapplikationen måste använda sig av minst en “master page”.
                </li>
                <li>
                    Webbapplikationen ska vara en s.k. femlagerapplikation. Lager som ska finnas med är:
                    <ul>
                        <li>
                            Användargränssnittlager
                        </li>
                        <li>
                             Presentationslogiklager
                        </li>
                        <li>
                            Affärslogiklager
                        </li>
                        <li>
                            Dataåtkomstlager
                        </li>
                        <li>
                            Datalager
                        </li>
                    </ul>
                    Inget lager får “hoppas” över, t.ex. får presentationslogiklagret inte kommunicera direkt med dataåtkomst- eller datalagret.
                </li>
                <li>
                    Användargränssnittlagret (klienten) ska vara av en webbläsare som tillåter JavaScript. Det räcker att applikationen fungerar på en av följande webbläsare: FireFox, Chrome, IE, Opera eller Safari.
                </li>
                <li>
                    Klasser för affärslogik- och dataåtkomstlager ska placeras i separata kataloger: Model respektive DAL. Affärslogik- och dataåtkomstlagret måste implementeras med C#-klasser som du egenhändigt skriver för hand.
                </li>
                <li>
                    Dataåtkomstlagret måste använda ADO.NET för att kommunicera med datalagret.
                </li>
                <li>
                    Datalagret måste utgöras av en databas.
                </li>
                <li>
                    Webbapplikationen ska minst utgöra ett gränssnitt mot tre tabeller. Det ska vara möjligt att hämta och presentera data från alla tre tabeller. Via webbformulär ska det för två av tabellerna vara möjligt att lägga till, uppdatera och ta bort poster.
                </li>
                <li>
                    Användaren måste bli informerad med ett meddelande då användaren på något sätt försökt/lyckats påverka datat i tabellerna. Både ”rätt”- och felmeddelande måste visas.
                </li>
                <li>
                    Allt data måste utan undantag valideras i så väl användargränssnittlagret, som i presentationslogiklagret, som i affärslogiklagret.
                </li>
                <li>
                    All kommunikation med databasen måste ske genom användaren appUser som har lösenordet **********. Användaren appUser får bara ha exekveringsrättigheter av lagrade procedurer. Rättigheter till andra objekt, som t.ex. tabeller, tillåts inte.
                </li>
            </ul>
               
        </div>
    </div>

</asp:Content>
