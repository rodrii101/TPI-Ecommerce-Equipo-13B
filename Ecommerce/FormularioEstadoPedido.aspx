<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioEstadoPedido.aspx.cs" Inherits="Ecommerce.FormularioEstadoPedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .validacionTextbox {
            color: black;
            font-size: 15px;
            text-align: left;
            display: inline;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p class="fs-2 text-center">Formulario Estado Pedido</p>
    <div class="container text-center m-4">
        <div class="row justify-content-center">
            <div class="col-5">
                <div class="mb-4">
                    <label for="txtIdEstadoPedido" class="form-label">Id</label>
                    <asp:TextBox ID="txtIdEstadoPedido" CssClass="form-control" runat="server" />
                </div>
                <div class="mb-4">
                    <label for="txtDescripcionEstadoPedido" class="form-label">Descripcion</label>
                    <asp:TextBox ID="txtDescripcionEstadoPedido" CssClass="form-control" runat="server" />
                    <div class="row">
                        <asp:RequiredFieldValidator Display="Dynamic" CssClass="validacionTextbox" ErrorMessage="Debe ingresar una Descripcion" ControlToValidate="txtDescripcionEstadoPedido" runat="server" />
                        <asp:RegularExpressionValidator Display="Dynamic" CssClass="validacionTextbox" ErrorMessage="Solo letras" ControlToValidate="txtDescripcionEstadoPedido" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$" runat="server" />
                    </div>
                </div>
                <div class="mb-4">
                    <asp:Button ID="btnAgregarEstadoPedido" OnClick="btnAgregarEstadoPedido_Click"  Text="Agregar" CssClass="btn btn-primary" runat="server" />
                    <a class="btn btn-primary" href="/ListarEstadoPedido.aspx">Cancelar</a>
                    <asp:Button Text="Inactivar" OnClick="btmDesactivarYActivarEstadoPedido_Click" CssClass="btn btn-warning" ID="btmDesactivarYActivarEstadoPedido" runat="server" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
