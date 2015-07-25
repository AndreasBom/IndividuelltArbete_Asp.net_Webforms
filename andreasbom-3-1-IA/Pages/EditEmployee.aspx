<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="EditEmployee.aspx.cs" Inherits="andreasbom_3_1_IA.Pages.EditEmployee" %>

<%@ Import Namespace="System.Web.Optimization" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderPageHeader" runat="server">
    <div class="container page-header-text background">
        <h2>Redigera uppgifter</h2>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div class="container full row background">
        <asp:FormView ID="FormViewEmployee" runat="server"
            ItemType="andreasbom_3_1_IA.Model.BLL.Employee"
            DataKeyNames="EmpID"
            DefaultMode="Edit"
            RenderOuterTable="false"
            SelectMethod="FormViewEmployee_GetItem"
            UpdateMethod="FormViewEmployee_UpdateItem"
            DeleteMethod="FormViewEmployee_DeleteItem">
            <EditItemTemplate>
                <div class="row">
                    <div class="form-group col-sm-6">

                        <label for="FirstName">Förnamn</label>
                        <asp:TextBox ID="FirstName" runat="server" CssClass="form-control" Text="<%# BindItem.FirstName %>" MaxLength="20" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                            runat="server"
                            ErrorMessage="Fältet FÖRNAMN får inte vara tomt"
                            Text="*"
                            Display="None"
                            ControlToValidate="FirstName" />

                        <label for="LastName">Efternamn</label>
                        <asp:TextBox ID="LastName" runat="server" CssClass="form-control" Text="<%# BindItem.LastName %>" MaxLength="20" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                            runat="server"
                            ErrorMessage="Fältet EFTERNAMN får inte vara tomt"
                            Text="*"
                            Display="None"
                            ControlToValidate="LastName" />

                        <div class="row">
                            <div class="col-xs-8">
                                <label for="BirthNo">Personnummer</label>
                                <asp:TextBox ID="BirthNo" runat="server" CssClass="form-control" Width="175px" Text="<%# BindItem.BirthNo %>" MaxLength="11" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                                    runat="server"
                                    ErrorMessage="Fältet PERSONNUMMER får inte vara tomt"
                                    Text="*"
                                    Display="None"
                                    ControlToValidate="BirthNo" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                                    runat="server"
                                    ErrorMessage="Skriv in ett personnummer med formatet 770101-0101"
                                    Text="*"
                                    Display="None"
                                    ControlToValidate="BirthNo"
                                    ValidationExpression="^[1-9]\d{5}-\d{4}" />

                            </div>
                            <div class="col-xs-4">
                                <label for="EmpCode">Anst.nr</label>
                                <asp:TextBox ID="EmpCode" runat="server" CssClass="form-control" Text="<%# BindItem.EmpCode %>" MaxLength="6" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                                    runat="server"
                                    ErrorMessage="Fältet ANST.NR får inte vara tomt"
                                    Text="*"
                                    Display="None"
                                    ControlToValidate="EmpCode" />

                            </div>
                        </div>

                    </div>
                    <div class="form-group col-sm-6">
                        <label for="Street">Gata</label>
                        <asp:TextBox ID="Street" runat="server" CssClass="form-control" Text="<%# BindItem.Street %>" MaxLength="25" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5"
                            runat="server"
                            ErrorMessage="Fältet GATA får inte vara tomt"
                            Text="*"
                            Display="None"
                            ControlToValidate="Street" />

                        <div class="row">
                            <div class="col-xs-4">
                                <label for="PostNo">Postnummer</label>
                                <asp:TextBox ID="PostNo" runat="server" CssClass="form-control" Text="<%# BindItem.PostNo %>" MaxLength="5" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6"
                                    runat="server"
                                    ErrorMessage="Fältet POSTNUMMER får inte vara tomt"
                                    Text="*"
                                    Display="None"
                                    ControlToValidate="PostNo" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2"
                                    runat="server"
                                    ErrorMessage="Postnummret ska vara 5 siffror"
                                    Text="*"
                                    Display="None"
                                    ControlToValidate="PostNo"
                                    ValidationExpression="^\d*(\d){5,}$" />


                            </div>
                            <div class="col-xs-8">
                                <label for="City">Ort</label>
                                <asp:TextBox ID="City" runat="server" CssClass="form-control" Text="<%# BindItem.City %>" MaxLength="20" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7"
                                    runat="server"
                                    ErrorMessage="Fältet ORT får inte vara tomt"
                                    Text="*"
                                    Display="None"
                                    ControlToValidate="City" />

                            </div>
                        </div>
                        <label for="PhoneNo">Telefon</label>
                        <asp:TextBox ID="PhoneNo" runat="server" CssClass="form-control" Text="<%# BindItem.PhoneNo %>" MaxLength="15" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8"
                            runat="server"
                            ErrorMessage="Fältet TELEFON får inte vara tomt"
                            Text="*"
                            Display="None"
                            ControlToValidate="PhoneNo" />

                    </div>

                    <div class="col-sm-3">
                        <asp:LinkButton runat="server" Text="Spara"
                            CommandName="Update"
                            CssClass="btn btn-default" />
                        <asp:HyperLink runat="server" NavigateUrl='<%# GetRouteUrl("Employees", null) %>'
                            Text="Avbryt"
                            CssClass="btn btn-default" />
                    </div>
                    <div class="col-sm-1 col-sm-offset-6 ">
                        <asp:LinkButton runat="server" Text="Radera uppgifter"
                            CommandName="Delete"
                            CssClass="btn btn-warning"
                            OnClientClick='<%# String.Format("return confirm(\"Vi du ta bort personen {0} {1}?\")", Item.FirstName, Item.LastName) %>' />
                    </div>


                </div>
            </EditItemTemplate>

            <ItemTemplate>
                <div>Hello</div>

            </ItemTemplate>


        </asp:FormView>

        <%-- Confirmation MESSAGE --%>
        <asp:Panel ID="PanelSuccessMessage" runat="server" CssClass="alert alert-success" Visible="false">
            <asp:Button ID="ButtonClose" runat="server" Text="&#10006;" CssClass="btn btn-default close-btn" />
        </asp:Panel>
        
    </div>

    <%: Scripts.Render("~/bundles/jQuery") %>
    <script type="text/javascript">
        $('#<%=ButtonClose.ClientID %>').click(function (e) {
            e.preventDefault();
            $('#<%=PanelSuccessMessage.ClientID %>').hide("slow");

        });
    </script>
</asp:Content>
