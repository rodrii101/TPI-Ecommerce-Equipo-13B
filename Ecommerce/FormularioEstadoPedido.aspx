<%@ Page Title="" Language="C#" MasterPageFile="~/MasterCliente.Master" AutoEventWireup="true" CodeBehind="FormularioEstadoPedido.aspx.cs" Inherits="Ecommerce.FormularioEstadoPedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .validacionTextbox {
            color: red;
            font-size: 12px;
            text-align: left;
            display: inline;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
    <div class="container text-center mb-5 mt-5">
          <p class="fs-2 mb-4 text-center">Formulario Estado Pedido</p>
        <div class="row justify-content-center">
            <div class="col-5">
                <div class="mb-4">
                    <label for="txtIdEstadoPedido" class="form-label">Id</label>
                    <asp:TextBox ID="txtIdEstadoPedido" CssClass="form-control text-center" runat="server" />
                </div>
                <div class="mb-4">
                    <label for="txtDescripcionEstadoPedido" class="form-label">Descripcion</label>
                    <asp:TextBox ID="txtDescripcionEstadoPedido" CssClass="form-control text-center" runat="server" />
                    <div class="row">
                        <asp:RequiredFieldValidator Display="Dynamic" CssClass="validacionTextbox" ErrorMessage="Debe ingresar una Descripcion" ControlToValidate="txtDescripcionEstadoPedido" runat="server" />
                        <asp:RegularExpressionValidator Display="Dynamic" CssClass="validacionTextbox" ErrorMessage="Solo letras" ControlToValidate="txtDescripcionEstadoPedido" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$" runat="server" />
                        <asp:Label Text="" ID="lblDescripcionEstadoPedido" CssClass="validacionTextbox" runat="server" />
                    </div>
                </div>
                <div class="mb-4">
                    <asp:Button ID="btnAgregarEstadoPedido" OnClick="btnAgregarEstadoPedido_Click" Text="Agregar" CssClass="btn btn-primary" runat="server" />
                    <a class="btn btn-primary" href="/ListarEstadoPedido.aspx">Cancelar</a>
                    <asp:Button Text="Inactivar" OnClick="btmDesactivarYActivarEstadoPedido_Click" CssClass="btn btn-warning" ID="btmDesactivarYActivarEstadoPedido" runat="server" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
