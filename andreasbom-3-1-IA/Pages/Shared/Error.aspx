<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="andreasbom_3_1_IA.Pages.Shared.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">


    <div class="container">
        <h1 class="">Serverfel</h1>
        <h3>Något gick fel</h3>
        <p>Vi beklagar att ett fel inträffade varför vi inte kunde hantera din förfrågan</p>
        
        <a href='<%$ RouteUrl:routename=Default %>' runat="server" style="background-color: yellow; line-height: 50px">Tillbaks till startsidan</a>

    </div>
</asp:Content>
