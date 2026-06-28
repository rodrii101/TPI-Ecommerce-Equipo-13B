<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioFormasDePago.aspx.cs" Inherits="Ecommerce.FormularioFormasDePago" %>

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
    <div class="container text-center mb-5 my-5">
        <p class="fs-2 text-center mb-4">Formulario de Formas de pago</p>
        <div class="row justify-content-center">
            <div class="col-5">
                <div class="mb-4">
                    <label for="txtIdFormasDePago" class="form-label">Id</label>
                    <asp:TextBox ID="txtIdFormasDePago" CssClass="form-control text-center" runat="server" />
                </div>
                <div class="mb-4">
                    <label for="txtDescripcionFormasDePago" class="form-label">Descripcion</label>
                    <asp:TextBox ID="txtDescripcionFormasDePago" CssClass="form-control text-center" runat="server" />
                    <div class="row">
                        <asp:RequiredFieldValidator Display="Dynamic" CssClass="validacionTextbox" ErrorMessage="Debe ingresar una Descripcion" ControlToValidate="txtDescripcionFormasDePago" runat="server" />
                        <asp:RegularExpressionValidator Display="Dynamic" CssClass="validacionTextbox" ErrorMessage="Solo letras" ControlToValidate="txtDescripcionFormasDePago" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$" runat="server" />
                        <asp:Label Text="" ID="lblDescripcionPago"  CssClass="validacionTextbox" runat="server" />
                    </div>
                </div>
                <div class="mb-4">
                    <asp:Button OnClick="btmAgregarFormasDePago_Click" Text="Agregar" CssClass="btn btn-primary" ID="btmAgregarFormasDePago" runat="server" />
                    <a class="btn btn-primary" href="/listarFormasDePago.aspx">Cancelar</a>
                    <asp:Button Text="Inactivar" OnClick="btmDesactivarYActivarFormasDePago_Click" CssClass="btn btn-warning" ID="btmDesactivarYActivarFormasDePago" runat="server" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
