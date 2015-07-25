<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="andreasbom_3_1_IA.Pages.Default" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderPageHeader" runat="server">
    <div class="container page-header-text background">
        <h2>Schema</h2>
    </div>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div id="wrapper" class="container full row background">
        <div id="insert-new">
            <asp:FormView ID="FormView1" runat="server"
                ItemType="andreasbom_3_1_IA.Model.BLL.Shift"
                InsertMethod="FormView1_InsertItem"
                RenderOuterTable="false"
                DefaultMode="Insert">
                <InsertItemTemplate>
                    <div class=" row full">
                        
                        <ul id="insert-shift" class="nav nav-pills">
                            <li class="col-sm-2">
                                <label for="Date" class="block label-input">Datum</label>
                                <asp:TextBox ID="Date" runat="server"
                                    CssClass="form-control input-date"
                                    Text="<%# BindItem.Date  %>" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorDate"
                                    runat="server"
                                    ErrorMessage="Fältet DATUM får inte vara tomt"
                                    Text="*"
                                    Display="None"
                                    ControlToValidate="Date" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                                    runat="server"
                                    Text="*"
                                    Display="None"
                                    ErrorMessage="Fältet för datum ska vara i formatet 2015-01-01"
                                    ControlToValidate="Date"
                                    ValidationExpression="^(19|20)\d\d([-])(0[1-9]|1[012])\2(0[1-9]|[12][0-9]|3[01])" />

                            </li>
                            <li class="col-sm-2">
                                <label for="DropDownListTOS" class="block label-input">Pass</label>
                                <asp:DropDownList ID="DropDownListTOS" runat="server"
                                    onFocus="this.size=8;"
                                    onBlur="this.size=1"
                                    onclick="this.size=1;"
                                    onMouseOut="this.size=1;"
                                    ItemType="andreasbom_3_1_IA.Model.BLL.TypeOfShift"
                                    SelectMethod="DropDownListTypeOfShift_GetData"
                                    DataTextField="Description"
                                    DataValueField="TOSID"
                                    CssClass="form-control position-absolute"
                                    SelectedValue='<%# BindItem.TOSID %>' />
                            </li>
                            <li class="col-sm-1">
                                <label for="DropDownListEmpID" class="block label-input">Anst.Nr</label>
                                <asp:DropDownList ID="DropDownListEmpID" runat="server"
                                    onclick="this.size=1;"
                                    onBlur="this.size=1"
                                    onFocus="this.size=10;"
                                    onMouseOut="this.size=1;"
                                    ItemType="andreasbom_3_1_IA.Model.BLL.Employee"
                                    SelectMethod="DropDownListEmployee_GetData"
                                    DataTextField="EmpCode"
                                    DataValueField="EmpID"
                                    CssClass="form-control position-absolute dropdownlist input-empcode"
                                    SelectedValue='<%# BindItem.EmpID %>' />

                            </li>
                            <li class="col-sm-3">
                                <label for="LinkButtonSaveShift"></label>
                                <asp:LinkButton ID="LinkButtonSaveShift" runat="server"
                                    CssClass="btn btn-link btn-insert"
                                    Text="Spara"
                                    CommandName="Insert" />
                            </li>
                            <li></li>
                        </ul>

                    </div>
                </InsertItemTemplate>
            </asp:FormView>

        </div>
        <div class="table-responsive">
            <asp:ListView ID="ListViewAllShifts" runat="server"
                ItemType="andreasbom_3_1_IA.Model.BLL.ShiftsAndEmployees"
                SelectMethod="ListViewAllShifts_GetData"
                DeleteMethod="FormView1_DeleteItem"
                DataKeyNames="ShiftID">
                <LayoutTemplate>
                    <table class="table table-striped ">
                        <thead>
                            <tr>
                                <th>Datum
                                </th>
                                <th>Pass
                                </th>
                                <th>Namn
                                </th>
                                <th>Anst.Nr
                                </th>
                                <th>Börjar
                                </th>
                                <th>Slutar
                                </th>
                                <th></th>
                            </tr>
                        </thead>
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                    </table>

                    <%-- Data Pager --%>
                    <asp:DataPager ID="DataPagerShifts" runat="server"
                        PageSize="10"
                        PagedControlID="ListViewAllShifts">
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
                </LayoutTemplate>

                <ItemTemplate>
                    <tr>
                        <td>
                            <%#: Item.Date.ToShortDateString() %>
                        </td>
                        <td>
                            <%#: Item.Description  %>
                        </td>
                        <td>
                            <%#: Item.FirstName + " " + Item.LastName %>
                        </td>
                        <td>
                            <%#: Item.EmpCode %>
                        </td>
                        <td>
                            <%#: Item.StartTime %>
                        </td>
                        <td>
                            <%#: Item.EndTime %>
                        </td>
                        <td>
                            <asp:LinkButton ID="LinkButtonDelete" runat="server"
                                OnClientClick='<%# String.Format("return confirm(\"Vi du ta bort passet?\")") %>'
                                CommandName="Delete"
                                CommandArgument='<%$ RouteValue:id %>'
                                Text="Radera"
                                CausesValidation="false"
                                CssClass="btn btn-link btn-link-edit" />

                        </td>

                    </tr>
                </ItemTemplate>

            </asp:ListView>
        </div>
        <%--END table-responsive --%>
    </div>

</asp:Content>
