<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioFormasDePago.aspx.cs" Inherits="Ecommerce.FormularioFormasDePago" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <p class="fs-2 text-center">Formulario de Formas de pago</p>
<div class="container text-center m-4">
    <div class="row justify-content-center">
        <div class="col-5">
            <div class="mb-4">
                <label for="txtIdFormasDePago" class="form-label">Id</label>
                <asp:TextBox ID="txtIdFormasDePago" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-4">
                <label for="txtDescripcionFormasDePago" class="form-label">Descripcion</label>
                <asp:TextBox ID="txtDescripcionFormasDePago" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-4">
                <asp:Button OnClick="btmAgregarFormasDePago_Click" Text="Agregar" CssClass="btn btn-primary" ID="btmAgregarFormasDePago" runat="server" />
                <a class="btn btn-primary" href="/listarFormasDePago.aspx">Cancelar</a>
                <asp:Button  Text="Inactivar" OnClick="btmDesactivarYActivarFormasDePago_Click"  CssClass="btn btn-warning" ID="btmDesactivarYActivarFormasDePago" runat="server" />
            </div>
        </div>
    </div>
</div>
</asp:Content>
