<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Ecommerce.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--QUITAR msjError EN EL 2do txtBox // COLOCAR TypeMode="password"--%>
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-4 m-5 border rounded shadow">
                <div class="m-5 text-center">
                    <svg xmlns="http://www.w3.org/2000/svg" width="70" height="70" fill="currentColor" class="bi bi-person-circle" viewBox="0 0 16 16">
                        <path d="M11 6a3 3 0 1 1-6 0 3 3 0 0 1 6 0" />
                        <path fill-rule="evenodd" d="M0 8a8 8 0 1 1 16 0A8 8 0 0 1 0 8m8-7a7 7 0 0 0-5.468 11.37C3.242 11.226 4.805 10 8 10s4.757 1.225 5.468 2.37A7 7 0 0 0 8 1" />
                    </svg>
                </div>
                <div class="m-4 text-center">
                    <label ID="lblRegistroEmail" runat="server" for="txtRegistroEmail">Ingrese su Email:</label>
                    <asp:TextBox ID="txtRegistroEmail" runat="server" CssClass="form-control border-button"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="txtRegistroEmail" runat="server" Display="Dynamic" ForeColor="Red" ErrorMessage="Debe completar este campo con un email."></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ControlToValidate="txtRegistroEmail" runat="server" Display="Dynamic" ForeColor="Red" ErrorMessage="Ingrese un email." ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$"></asp:RegularExpressionValidator>
                </div>
                <div class="m-4 text-center">
                    <%--CONTRASEÑA: AL MENOS 6 CARACTERES, 1 LETRA Y 1 NUMERO--%>
                    <label ID="lblPassword" runat="server" for="txtPassword">Crear contraseña:</label>
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control border-button"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="txtPassword" runat="server" Display="Dynamic" ForeColor="Red" ErrorMessage="Debe completar este campo con una contraseña."></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ControlToValidate="txtPassword" runat="server" Display="Dynamic" ForeColor="Red" ErrorMessage="La contraseña debe tener al menos 6 caracteres, una letra y un número." ValidationExpression="^(?=.*[A-Za-z])(?=.*\d).{6,}$"></asp:RegularExpressionValidator>
                </div>
                <div class="m-4 text-center">
                    <label ID="lblConfirmarPassword" runat="server" for="txtConfirmarPassword">Confirmar contraseña:</label>
                    <asp:TextBox ID="txtConfirmarPassword" runat="server" CssClass="form-control border-button"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="txtConfirmarPassword" runat="server" Display="Dynamic" ForeColor="Red" ErrorMessage="Debe completar este campo con una contraseña."></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ControlToValidate="txtConfirmarPassword" runat="server" Display="Dynamic" ForeColor="Red" ErrorMessage="La contraseña debe tener al menos 6 caracteres, una letra y un número." ValidationExpression="^(?=.*[A-Za-z])(?=.*\d).{6,}$"></asp:RegularExpressionValidator>
                    <asp:CompareValidator ControlToValidate="txtConfirmarPassword" ControlToCompare="txtPassword" runat="server" Display="Dynamic" ForeColor="OrangeRed" ErrorMessage="Las contraseñas deben coindicir."></asp:CompareValidator>
                </div>
                <div class="m-4 text-center">
                    <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" CssClass="btn btn-primary" OnClick="btnRegistrar_Click"/>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
