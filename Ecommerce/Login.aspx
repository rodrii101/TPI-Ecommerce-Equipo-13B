<%@ Page Title="" Language="C#" MasterPageFile="~/MasterCliente.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Ecommerce.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container ">
        <br />
        <div class="row justify-content-center">
            <div class="col-4 m-5 border border-secondary-subtle rounded shadow">
                <div class="m-4 text-center">
                    <svg xmlns="http://www.w3.org/2000/svg" width="70" height="70" fill="currentColor" class="bi bi-person-circle" viewBox="0 0 16 16">
                        <path d="M11 6a3 3 0 1 1-6 0 3 3 0 0 1 6 0" />
                        <path fill-rule="evenodd" d="M0 8a8 8 0 1 1 16 0A8 8 0 0 1 0 8m8-7a7 7 0 0 0-5.468 11.37C3.242 11.226 4.805 10 8 10s4.757 1.225 5.468 2.37A7 7 0 0 0 8 1" />
                    </svg>
                </div>
                <div class="m-4 ">
                    <label for="txtLoginEmail" class="form-label">Correo</label>
                    <asp:TextBox ID="txtLoginEmail" CssClass="form-control border-button" placeholder="Ingrese su correo" runat="server" />
                </div>
                <div class="m-4">
                    <label for="txtLoginContra" class="form-label">Contraseña</label>
                    <asp:TextBox ID="txtLoginContra" CssClass="form-control" placeholder="Contraseña" type="password" runat="server" />
                </div>
                <div class="m-4">
                    <p>Si no estas registrado ¡Registrate!</p>
                    <asp:Button Text="Registrarse" CssClass="btn btn-primary btn-sm" runat="server" />
                </div>
                <div class="m-4">
                    <asp:Button Text="Login" ID="btnLoginUsuario" OnClick="btnLoginUsuario_Click" CssClass="btn btn-warning btn-sm w-100" runat="server" />
                </div>
            </div>
        </div>
        <br />
    </div>
</asp:Content>
