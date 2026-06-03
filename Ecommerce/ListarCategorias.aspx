<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListarCategorias.aspx.cs" Inherits="Ecommerce.ListarCategorias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>LISTADO CATEGORIAS </p>
    <asp:GridView runat="server" ID="dgvListadoCategorias"></asp:GridView>
</asp:Content>
