<%@ Page Title="" Language="C#" MasterPageFile="~/MasterCliente.Master" AutoEventWireup="true" CodeBehind="CambiarPassword.aspx.cs" Inherits="Ecommerce.CambiarPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-4 m-5 border rounded shadow">
                
                <div class="m-5 text-center">
                    <svg xmlns="http://www.w3.org/2000/svg" width="70" height="70" fill="currentColor" class="bi bi-person-circle" viewBox="0 0 16 16">
                        <path d="M11 6a3 3 0 1 1-6 0 3 3 0 0 1 6 0" />
                        <path fill-rule="evenodd" d="M0 8a8 8 0 1 1 16 0A8 8 0 0 1 0 8m8-7a7 7 0 0 0-5.468 11.37C3.242 11.226 4.805 10 8 10s4.757 1.225 5.468 2.37A7 7 0 0 0 8 1" />
                    </svg>
                </div>

                <%-- PANEL 1: VERIFICAR CONTRASEÑA ACTUAL --%>
                <asp:Panel ID="panelVerificarPass" runat="server">
                    <div class="m-4 text-center">
                        <label for="txtVerficarPass">Ingrese su contraseña actual:</label>
                        <asp:TextBox ID="txtVerficarPass" runat="server" CssClass="form-control border-button" TextMode="Password"></asp:TextBox>
                        <div class="mt-2">
                            <asp:Label ID="lblPassInvalida" runat="server" ForeColor="Red" Text="Esa contraseña es incorrecta" Visible="false"></asp:Label>
                        </div>
                    </div>    
                    <div class="m-4 text-center">
                        <asp:Button ID="btnAceptar" runat="server" Text="Continuar" CssClass="btn btn-primary w-100" OnClick="btnAceptar_Click"/>
                    </div>
                </asp:Panel>

                <%-- PANEL 2: CAMBIAR CONTRASEÑA --%>
                <asp:Panel ID="panelCambiarPass" runat="server" Visible="false">
                    <div class="m-4 text-center">
                        <label for="txtNuevaPass">Nueva contraseña:</label>
                        <asp:TextBox ID="txtNuevaPass" runat="server" CssClass="form-control border-button" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtNuevaPass" runat="server" Display="Dynamic" ForeColor="Red" ErrorMessage="Debe completar este campo con una contraseña."></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ControlToValidate="txtNuevaPass" runat="server" Display="Dynamic" ForeColor="Red" ErrorMessage="La contraseña debe tener al menos 6 caracteres, una letra y un número." ValidationExpression="^(?=.*[A-Za-z])(?=.*\d).{6,}$"></asp:RegularExpressionValidator>
                    </div>
                    
                    <div class="m-4 text-center">
                        <label for="txtConfirmarPass">Confirmar contraseña:</label>
                        <asp:TextBox ID="txtConfirmarPass" runat="server" CssClass="form-control border-button" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtConfirmarPass" runat="server" Display="Dynamic" ForeColor="Red" ErrorMessage="Debe completar este campo con una contraseña."></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ControlToValidate="txtConfirmarPass" runat="server" Display="Dynamic" ForeColor="Red" ErrorMessage="La contraseña debe tener al menos 6 caracteres, una letra y un número." ValidationExpression="^(?=.*[A-Za-z])(?=.*\d).{6,}$"></asp:RegularExpressionValidator>
                        <asp:CompareValidator ControlToValidate="txtConfirmarPass" ControlToCompare="txtNuevaPass" runat="server" Display="Dynamic" ForeColor="OrangeRed" ErrorMessage="Las contraseñas deben coindicir."></asp:CompareValidator>
                    </div>

                    <div class="m-4 text-center">
                        <asp:Label ID="lblCambioPass" runat="server" ForeColor="Green" Text="Contraseña cambiada" Visible="false"></asp:Label>
                    </div>

                    <div class="m-4 text-center d-flex justify-content-between gap-2">
                        <asp:Button ID="btnVolver" runat="server" CssClass="btn btn-secondary w-50" Text="Volver" OnClick="btnVolver_Click" CausesValidation="false" />
                        <asp:Button ID="btnCambiarPass" runat="server" CssClass="btn btn-primary w-50" Text="Cambiar contraseña" OnClick="btnCambiarPass_Click"/>
                    </div>
                </asp:Panel>

            </div>
        </div>
    </div>
</asp:Content>
