<%@ Page Title="" Language="C#" MasterPageFile="~/MasterCliente.Master" AutoEventWireup="true" CodeBehind="EditarPerfil.aspx.cs" Inherits="Ecommerce.EditarPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="mt-3">Editar Perfil</h2>
    <div class="container mt-4 mb-5 d-flex">
        <div class="row w-100 d-flex justify-content-center">
            <div class="col-7 m-3 border border-secondary-subtle rounded shadow">
                <div class="m-4 text-center">
                    <asp:Image ID="imgEditarFotoPerfil" CssClass="rounded-circle" Width="100px" Height="100px" ImageUrl="https://static.vecteezy.com/system/resources/previews/004/141/669/non_2x/no-photo-or-blank-image-icon-loading-images-or-missing-image-mark-image-not-available-or-image-coming-soon-sign-simple-nature-silhouette-in-frame-isolated-illustration-vector.jpg" runat="server"/>
                    
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
                    <label for="txtFechaNacimiento" class="form-label">Fecha nacimiento</label>
                    <asp:TextBox ID="txtFechaNacimiento" CssClass="form-control border-button" TextMode="Date" runat="server" />
                </div>
                <div class="m-4">
                    <label class="form-label">Url imagen</label>
                    <input type="file" ID="txtImagenPerfil" runat="server" class="form-control" />
                </div>
                <div class="m-4 ">
                    <asp:Button ID="btnEditarUsuario" OnClick="btnEditarUsuario_Click" CssClass="btn btn-success m-1" Text="Agregar" runat="server" />
                    <a class="btn btn-secondary m-1" href="/Perfil.aspx">Cancelar</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
