<%@ Page Title="" Language="C#" MasterPageFile="~/MasterCliente.Master" AutoEventWireup="true" CodeBehind="EditarPerfil.aspx.cs" Inherits="Ecommerce.EditarPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="mt-3">Editar Perfil</h2>
    <div class="container mt-4 mb-5 d-flex">
        <div class="row w-100 d-flex justify-content-center">
            <div class="col-7 m-3 border border-secondary-subtle rounded shadow">
                <%-- Aca ira la imagen del usuario --%>
                <div class="m-4 text-center">
                    <img src="https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/083.png" class="border border-secondary rounded" alt="ImagenDelUsuario" width="100px" height="100px" />
                </div>
                <div class="d-flex">
                    <div class="m-4 w-50">
                        <label for="txtBoxNombreEditarUsuario" class="form-label">Nombre</label>
                        <asp:TextBox ID="txtBoxNombreEditarUsuario" CssClass="form-control border-button" runat="server" />
                    </div>

                    <div class="m-4 w-50">
                        <label for="txtApellidoEditarUsuario" class="form-label">Apellido</label>
                        <asp:TextBox ID="txtApellidoEditarUsuario" CssClass="form-control border-button" runat="server" />
                    </div>
                </div>
                <div class="d-flex ">
                    <div class="m-4 w-50">
                        <label for="txtTelefonoEditarUsuario" class="form-label">Telefono</label>
                        <asp:TextBox ID="txtTelefonoEditarUsuario" CssClass="form-control border-button" runat="server" />
                    </div>

                    <div class="m-4 w-50">
                        <label for="txtDniEditarUsuario" class="form-label">DNI</label>
                        <asp:TextBox ID="txtDniEditarUsuario" CssClass="form-control border-button" runat="server" />
                    </div>
                </div>
                <div class="m-4">
                    <label for="txtEditarFoto" class="form-label">Url imagen</label>
                    <asp:TextBox ID="txtEditarFoto" CssClass="form-control border-button" runat="server" />
                </div>
                <div class="m-4 ">
                    <asp:Button CssClass="btn btn-success m-1" Text="Agregar" runat="server" />
                    <a class="btn btn-secondary m-1" href="/Perfil.aspx">Cancelar</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
