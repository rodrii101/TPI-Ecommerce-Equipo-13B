<%@ Page Title="" Language="C#" MasterPageFile="~/MasterCliente.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="Ecommerce.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="mt-3">Perfil</h2>
    <div class="container mt-5 mb-5">
        <div class="row w-100">
            <ul class="col-3 m-3 me-5 nav flex-column">
                <li class="nav-item">
                    <a class="nav-link link-dark" href="/Perfil.aspx">Perfil</a>
                    <hr />
                </li>
                <li class="nav-item">
                    <a class="nav-link link-dark" href="/Direccion.aspx">Direccion</a>
                    <hr />
                </li>
                <li class="nav-item">
                    <a class="nav-link link-dark" href="/CompraDelUsuario.aspx">Compras</a>
                    <hr /> 
                </li>
                <li class="nav-item">
                    <asp:Button Text="Cerrar sesion" Id="btnCerrarSesion" OnClick="btnCerrarSesion_Click" CssClass="nav-link link-dark" runat="server" />             
                    <hr />
                </li>
            </ul>
            <div class="col-7 m-3 border border-secondary-subtle rounded shadow">
                <div class="m-4 text-center">
                    <asp:Image ID="imagenPerfilUsuario" CssClass="rounded-circle" Width="100px" Height="100px" ImageUrl="https://static.vecteezy.com/system/resources/previews/004/141/669/non_2x/no-photo-or-blank-image-icon-loading-images-or-missing-image-mark-image-not-available-or-image-coming-soon-sign-simple-nature-silhouette-in-frame-isolated-illustration-vector.jpg" runat="server"/>
                </div> 
                <div class="d-flex">
                    <div class="m-4 w-50">
                        <label for="txtBoxNombreUsuario" class="form-label">Nombre</label>
                        <asp:TextBox ID="txtBoxNombreUsuario" CssClass="form-control-plaintext border-button" ReadOnly="true" runat="server" />
                    </div>

                    <div class="m-4 w-50">
                        <label for="txtApellidoUsuario" class="form-label">Apellido</label>
                        <asp:TextBox ID="txtApellidoUsuario" CssClass="form-control-plaintext border-button"  ReadOnly="true" runat="server" />
                    </div>
                </div>
                <div class="d-flex ">
                    <div class="m-4 w-50">
                        <label for="txtTelefonoUsuario" class="form-label">Telefono</label>
                        <asp:TextBox ID="txtTelefonoUsuario" CssClass="form-control-plaintext border-button" ReadOnly="true" runat="server" />
                    </div>

                    <div class="m-4 w-50">
                        <label for="txtDniUsuario" class="form-label">DNI</label>
                        <asp:TextBox ID="txtDniUsuario" CssClass="form-control-plaintext border-button" ReadOnly="true" runat="server" />
                    </div>
                </div>
                <div class="d-flex mb-4">
                    <div class="m-4 w-50">
                        <label for="txtEmailUsuario" class="form-label">Email</label>
                        <asp:TextBox ID="txtEmailUsuario" CssClass="form-control-plaintext border-button" ReadOnly="true" runat="server" />
                    </div>

                    <div class="m-4 w-50">
                        <label for="txtFechaNacimiento" class="form-label">Fecha nacimiento</label>
                        <asp:TextBox ID="txtFechaNacimiento" CssClass="form-control-plaintext border-button" TextMode="Date" ReadOnly="true" runat="server" />
                    </div>
                </div>
                <div class="m-4">
                    <a class="btn btn-outline-secondary" href="/EditarPerfil.aspx">Editar</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
