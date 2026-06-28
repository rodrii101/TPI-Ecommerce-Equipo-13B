<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioMarca.aspx.cs" Inherits="Ecommerce.FormularioMarca" %>

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
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <div class="container text-center mb-5 mt-5">
         <p class="fs-2 mb-5 text-center">Formulario de Marca</p>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="row justify-content-center">
                    <div class="col-3">
                        <div class="mb-3">
                            <asp:Label Text="Id" ID="lblIdMarca" runat="server" />
                            <asp:TextBox ID="txtIdMarca" CssClass="form-control text-center" runat="server" />
                        </div>
                        <div class="mb-3">
                            <label for="txtDescripcionMarca" class="form-label">Descripcion</label>
                            <asp:TextBox ID="txtDescripcionMarca" CssClass="form-control text-center" runat="server" />
                            <asp:RequiredFieldValidator Display="Dynamic" CssClass="validacionTextbox" ErrorMessage="Debe ingresar una Descripcion" ControlToValidate="txtDescripcionMarca" runat="server" />
                            <asp:RegularExpressionValidator Display="Dynamic" CssClass="validacionTextbox" ErrorMessage="Solo letras" ControlToValidate="txtDescripcionMarca" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$" runat="server" />
                            <asp:Label Text="" ID="lblExisteMarca" CssClass="validacionTextbox" runat="server" />

                        </div>
                        <div class="mb-3">
                            <label for="txtUrlImagenMarca" class="form-label">Imagen marca</label>
                            <asp:TextBox ID="txtUrlImagenMarca" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtUrlImagenMarca_TextChanged" runat="server" />
                        </div>
                        <div class="mb-3">
                            <asp:Button OnClick="btmAgregarMarca_Click" Text="Agregar" CssClass="btn btn-primary" ID="btmAgregarMarca" runat="server" />
                            <a class="btn btn-primary" href="/ListarMarcas.aspx">Cancelar</a>
                            <asp:Button Text="Inactivar" OnClick="btmDesactivarYActivarMarca_Click" CssClass="btn btn-warning" ID="btmDesactivarYActivarMarca" runat="server" />
                        </div>
                    </div>

                    <div class="col-5">
                        <img src="<% = UrlImagen %>" alt="" width="400" height="300" />
                    </div>
                    </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
