<%@ Page Title="" Language="C#" MasterPageFile="~/MasterCliente.Master" AutoEventWireup="true" CodeBehind="RegistroVendedor.aspx.cs" Inherits="Ecommerce.RegistroVendedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <div class="container mt-4 mb-5 d-flex">
       <div class="row w-100 d-flex justify-content-center">
           <div class="col-7 m-3 border border-secondary-subtle rounded shadow">
                <div class="m-4 text-center">
                    <h2 class="mt-3 d-flex justify-content-center">REGÍSTRATE PARA VENDER EN NUESTRO SITIO</h2>
                </div>
                <div class="d-flex">
                    <div class="m-4 w-50">
                        <label for="txtNombreVendedor" class="form-label">Nombre:</label>
                        <asp:TextBox ID="txtNombreVendedor" CssClass="form-control border-button" runat="server" MaxLength="70" />
                        <asp:RequiredFieldValidator ControlToValidate="txtNombreVendedor" runat="server" Display="Dynamic" ForeColor="Red" ErrorMessage="Este campo es obligatorio."></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ControlToValidate="txtNombreVendedor" runat="server" Display="Dynamic" ForeColor="Red" ErrorMessage="Ingresar un nombre valido." ValidationExpression="^(?=.{2,70}$)[A-Za-zÁÉÍÓÚáéíóúÑñ]+(?:[ '-][A-Za-zÁÉÍÓÚáéíóúÑñ]+)*$"></asp:RegularExpressionValidator>

                    </div>

                    <div class="m-4 w-50">
                        <label for="txtApellidoVendedor" class="form-label">Apellido</label>
                        <asp:TextBox ID="txtApellidoVendedor" CssClass="form-control border-button" runat="server" MaxLength="70" />
                        <asp:RequiredFieldValidator ControlToValidate="txtApellidoVendedor" runat="server" Display="Dynamic" ForeColor="Red" ErrorMessage="Este campo es obligatorio."></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ControlToValidate="txtApellidoVendedor" runat="server" Display="Dynamic" ForeColor="Red" ErrorMessage="Ingresar un nombre valido." ValidationExpression="^(?=.{2,70}$)[A-Za-zÁÉÍÓÚáéíóúÑñ]+(?:[ '-][A-Za-zÁÉÍÓÚáéíóúÑñ]+)*$"></asp:RegularExpressionValidator>

                    </div>
               </div>
               <div class="d-flex ">
                   <div class="m-4 w-50">
                       <label for="txtTelefonoVendedor" class="form-label">Telefono</label>
                       <asp:TextBox ID="txtTelefonoVendedor" CssClass="form-control border-button" runat="server" />
                       <asp:RequiredFieldValidator ControlToValidate="txtTelefonoVendedor" runat="server" Display="Dynamic" ForeColor="Red" ErrorMessage="Este campo es obligatorio."></asp:RequiredFieldValidator>
                       <asp:RegularExpressionValidator ControlToValidate="txtTelefonoVendedor" runat="server" Display="Dynamic" ForeColor="Red" ErrorMessage="Telefono invalido." ValidationExpression="^\d{10,12}$"></asp:RegularExpressionValidator>
                   </div>

                   <div class="m-4 w-50">
                       <label for="txtDniVendedor" class="form-label">DNI</label>
                       <asp:TextBox ID="txtDniVendedor" CssClass="form-control border-button" runat="server" />
                       <asp:RequiredFieldValidator ControlToValidate="txtDniVendedor" runat="server" Display="Dynamic" ForeColor="Red" ErrorMessage="Este campo es obligatorio."></asp:RequiredFieldValidator>
                       <asp:RegularExpressionValidator ControlToValidate="txtDniVendedor" runat="server" Display="Dynamic" ForeColor="Red" ErrorMessage="Ingrese un DNI válido (7 u 8 dígitos, sin puntos)." ValidationExpression="^\d{7,8}$"></asp:RegularExpressionValidator>
                   </div>
               </div>
               <div class="m-4">
                   <label for="txtFechaNacimientoVendedor" class="form-label" TextMode="Date">Fecha nacimiento</label>
                   <asp:TextBox ID="txtFechaNacimientoVendedor" CssClass="form-control border-button" TextMode="Date" runat="server" />
                   <asp:RequiredFieldValidator ControlToValidate="txtDniVendedor" runat="server" Display="Dynamic" ForeColor="Red" ErrorMessage="Este campo es obligatorio."></asp:RequiredFieldValidator>
               </div>
               <%--<div class="m-4">
                   <label for="txtDireccionVendedor" class="form-label">Direccion</label>
                   <asp:TextBox ID="txtDireccionVendedor" runat="server" CssClass="form-control border-button"></asp:TextBox>
               </div>--%>
               <div class="m-4 ">
                   <asp:Button ID="btnRegistrarVendedor" runat="server" CssClass="btn btn-success" Text="Registrar" OnClick="btnRegistrarVendedor_Click"/>
                   <a class="btn btn-secondary m-1" href="/DefaultCliente.aspx">Cancelar</a>
               </div>
           </div>
       </div>
   </div>


</asp:Content>
