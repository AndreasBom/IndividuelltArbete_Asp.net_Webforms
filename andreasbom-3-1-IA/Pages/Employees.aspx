<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="andreasbom_3_1_IA.Pages.Employees" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderPageHeader" runat="server">
    <div class="container page-header-text background">
        <h2>Personal</h2>
    </div>
</asp:Content>




<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <%-- ListView --%>
    <div class="table-responsive container full row background">
        <asp:ListView ID="ListViewEmployees" runat="server"
            ItemType="andreasbom_3_1_IA.Model.BLL.Employee"
            SelectMethod="ListViewEmployees_GetData"
            DeleteMethod="ListViewEmployees_DeleteItem"
            DataKeyNames="EmpID">
            <LayoutTemplate>
                <table class="table table-striped ">
                    <thead>
                        <tr>
                            <th>Namn
                            </th>
                            <th>Anst.Nr
                            </th>
                            <th>Adress
                            </th>
                            <th>Stad
                            </th>
                            <th>Telefonnummer
                            </th>
                            <th></th>
                        </tr>
                    </thead>
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                </table>
                <%-- Data Pager --%>
                <asp:DataPager ID="DataPagerEmployees" runat="server"
                    PageSize="10"
                    PagedControlID="ListViewEmployees">
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
                </asp:DataPager>

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
                        <%#: Item.Street %>
                    </td>
                    <td>
                        <%#: Item.City %>
                    </td>
                    <td>
                        <%#: Item.PhoneNo %>
                    </td>
                    <td>
                        <asp:HyperLink runat="server" NavigateUrl='<%# GetRouteUrl("Edit", new {id = Item.EmpID}) %>'
                            Text="Redigera"
                            CssClass="btn btn-link btn-link-edit" />
                    </td>

                </tr>
            </ItemTemplate>
            <EmptyDataTemplate>
                <h2>Det finns inga personer inlagda i systemet</h2>
            </EmptyDataTemplate>
        </asp:ListView>
        <div class="right add-btn">
            <asp:HyperLink runat="server"
                NavigateUrl='<%$ RouteUrl:routename=Newemployee %>'
                CssClass="btn btn-default"
                Text="Lägg till ny" />
        </div>
    </div>


</asp:Content>
