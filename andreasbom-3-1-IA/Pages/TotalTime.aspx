<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="TotalTime.aspx.cs" Inherits="andreasbom_3_1_IA.Pages.TotalTime" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderPageHeader" runat="server">
    <div class="container page-header-text background">
        <h2>Sammanlagd arbetstid</h2>
    </div>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

    <div class="container full row background">
        <div id="period">
            <div class="inline-block">
                <label for="TextBoxFromDate" class="block">Från</label>
                <asp:TextBox ID="TextBoxFromDate" runat="server"
                    Text="2015-01-01"
                    CssClass="form-control date-control" />

                <%--Komplettering: Validering av textbox-rutor  --%>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                    runat="server"
                    ErrorMessage="Fyll i datum när perioden startar"
                    ControlToValidate="TextBoxFromDate"
                    Display="none" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server"
                    Text="*"
                    Display="None"
                    ErrorMessage="Fältet 'Från' är inskrivet i fel format. Försök igen (ex. 2015-01-01)"
                    ControlToValidate="TextBoxFromDate"
                    ValidationExpression="^(19|20)\d\d([-])(0[1-9]|1[012])\2(0[1-9]|[12][0-9]|3[01])" />


            </div>
            <div class="inline-block">
                <label for="TextBoxToDate" class="block">T.o.m</label>
                <asp:TextBox ID="TextBoxToDate" runat="server"
                    Text="2015-12-31"
                    CssClass=" form-control date-control" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                    runat="server"
                    ErrorMessage="Fyll i datum när perioden slutar"
                    ControlToValidate="TextBoxToDate"
                    Display="none" />
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Startdatum måste vara lägre än slutdatum" 
                    Operator="LessThanEqual"
                    Type="Date"
                    ControlToCompare="TextBoxToDate"
                    ControlToValidate="TextBoxFromDate" 
                    Display="None"
                    EnableClientScript="true"
                    Text="*"/> 
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                    Text="*"
                    Display="None"
                    ErrorMessage="Fältet 't.o.m' är inskrivet i fel format. Försök igen (ex. 2015-01-01)"
                    ControlToValidate="TextBoxToDate"
                    ValidationExpression="^(19|20)\d\d([-])(0[1-9]|1[012])\2(0[1-9]|[12][0-9]|3[01])" />

                <%-- SLUT Komplettering: Validering av textbox-rutor  --%>

            </div>
            <%-- En postback görs automatiskt vid klick, och vid inläsning av sidan har värdena i Textboxarna sparats i viewstaten(?) Ytterligare funktionalitet på knappen behövs inte. Kanske en oacceptabel lösning? I annat fall får man använda sessionsvariabler för att lagra värdena --%>
            <asp:Button ID="ButtonFetchTotalTime" runat="server" 
                Text="Hämta" 
                CssClass="btn btn-default btn-sm" />
        </div>

        <div class="table-responsive">
            <asp:ListView ID="ListViewTotalTime" runat="server"
                ItemType="andreasbom_3_1_IA.Model.BLL.TimeReport"
                SelectMethod="ListView1_GetData">

                <LayoutTemplate>
                    <table class="table table-striped ">
                        <thead>
                            <tr>
                                <th>Namn
                                </th>
                                <th>Anst.Nr
                                </th>
                                <th>Total Tid (h)
                                </th>
                            </tr>
                        </thead>
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                    </table>
                    <%-- Data Pager --%>
                    <%--<asp:DataPager ID="DataPagerTotalTime" runat="server"
                    PageSize="3"
                    PagedControlID="ListViewTotalTime">
                    <Fields>
                        <asp:NextPreviousPagerField ShowFirstPageButton="true"
                            FirstPageText=" << "
                            ButtonType="Button"
                            ButtonCssClass="btn btn-link .btn-link"
                            ShowPreviousPageButton="false"
                            ShowNextPageButton="false"
                            ShowLastPageButton="false" />
                        <asp:NumericPagerField ButtonType="Button"
                            PreviousPageText=" < "
                            NextPageText=" > "
                            NextPreviousButtonCssClass="Button"
                            NumericButtonCssClass="btn btn-link btn-link" />
                        <asp:NextPreviousPagerField ShowLastPageButton="true"
                            LastPageText=" >> "
                            ButtonType="Button"
                            ButtonCssClass="btn btn-link"
                            ShowFirstPageButton="false"
                            ShowPreviousPageButton="false"
                            ShowNextPageButton="false" />
                    </Fields>
                </asp:DataPager>--%>

                </div>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <%#: Item.FirstName + " " + Item.LastName %>
                        </td>
                        <td>
                            <%#: Item.EmpCode  %>
                        </td>
                        <td>
                            <%#: Item.Total / 60 %>
                        </td>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <h2>Inga poster finns att visa</h2>
                </EmptyDataTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
