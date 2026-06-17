<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioCategoria.aspx.cs" Inherits="Ecommerce.FormularioCategoria" %>

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
    <p class="fs-2 text-center">Formulario de categoria</p>
    <div class="container text-center">
        <div class="row justify-content-center">
            <div class="col-5">
                <div class="mb-4">
                    <label for="txtIdCategoria" class="form-label">ID</label>
                    <asp:TextBox ID="txtIdCategoria" CssClass="form-control" runat="server" />
                </div>
                <div class="mb-4">
                    <label for="txtDescripcionCategoria" class="form-label">Descripcion</label>
                    <asp:TextBox ID="txtDescripcionCategoria" CssClass="form-control" runat="server" />
                    <div class="row">
                        <asp:RequiredFieldValidator Display="Dynamic" CssClass="validacionTextbox" ErrorMessage="Debe ingresar una Descripcion" ControlToValidate="txtDescripcionCategoria" runat="server" />
                        <asp:RegularExpressionValidator Display="Dynamic" CssClass="validacionTextbox" ErrorMessage="Solo letras" ControlToValidate="txtDescripcionCategoria" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$" runat="server" />
                    </div>
                </div>
                <div class="mb-4">
                    <asp:Button OnClick="btmAgregarCategoria_Click" Text="Agregar" CssClass="btn btn-primary" ID="btmAgregarCategoria" runat="server" />
                    <a class="btn btn-primary" href="/listarCategorias.aspx">Cancelar</a>
                    <asp:Button Text="Inactivar" CssClass="btn btn-warning" OnClick="btnDesativarYActivarCategoria_Click" ID="btnDesativarYActivarCategoria" runat="server" />

                </div>
            </div>
        </div>
    </div>
</asp:Content>
