<%@ Page Title="" Language="C#" MasterPageFile="~/MasterCliente.Master" AutoEventWireup="true" CodeBehind="FormularioDireccion.aspx.cs" Inherits="Ecommerce.FormularioDireccion" %>

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
    <h2 class="mt-4">Direccion</h2>
    <div class="container mb-5 mt-4">
        <div class="row justify-content-center">
            <div class="col-6 m-3 p-4 border border-secondary-subtle rounded shadow">
                <h3 class="text-center m-2 mb-4">Formulario de direccion</h3>
                <div class="mb-4">
                    <label for="txtCalle">Calle</label>
                    <asp:TextBox ID="txtCalle" CssClass="form-control rounde w-100" runat="server" />
                    <asp:RequiredFieldValidator Display="Dynamic" CssClass="validacionTextbox" ErrorMessage="Debe ingresar una calle" ControlToValidate="txtCalle" runat="server" />
                    <asp:RegularExpressionValidator Display="Dynamic" CssClass="validacionTextbox" ErrorMessage="Solo letras" ControlToValidate="txtCalle" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$" runat="server" />
                </div>
                <div class="mb-4">
                    <label for="txtAltura">Altura</label>
                    <asp:TextBox ID="txtAltura" CssClass="form-control rounde w-100" runat="server" />
                    <asp:RequiredFieldValidator Display="Dynamic" CssClass="validacionTextbox" ErrorMessage="Debe ingresar una Altura" ControlToValidate="txtAltura" runat="server" />
                    <asp:RegularExpressionValidator Display="Dynamic" CssClass="validacionTextbox" ErrorMessage="Solo numeros" ControlToValidate="txtAltura" ValidationExpression="^[0-9]+$" runat="server" />
                </div>
                <div class="d-flex mb-4">
                    <div class="m-1 w-50">
                        <label for="txtPiso">Piso</label>
                        <asp:TextBox ID="txtPiso" CssClass="form-control rounde" runat="server" />
                    </div>
                    <div class="m-1 w-50">
                        <label for="txtDepartamento">Departamento</label>
                        <asp:TextBox ID="txtDepartamento" CssClass="form-control rounde" runat="server" />
                    </div>

                </div>
                <div class="mb-4">
                    <label for="txtLocalidad">Localidad</label>
                    <asp:TextBox ID="txtLocalidad" CssClass="form-control rounde w-100" runat="server" />
                    <asp:RequiredFieldValidator Display="Dynamic" CssClass="validacionTextbox" ErrorMessage="Debe ingresar localidad" ControlToValidate="txtLocalidad" runat="server" />
                    <asp:RegularExpressionValidator Display="Dynamic" CssClass="validacionTextbox" ErrorMessage="Solo letras" ControlToValidate="txtLocalidad" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$" runat="server" />
                </div>
                <div class="mb-4">
                    <label for="txtCodigoPostal">CodigoPostal</label>
                    <asp:TextBox ID="txtCodigoPostal" CssClass="form-control rounde w-25" runat="server" />
                    <asp:RequiredFieldValidator Display="Dynamic" CssClass="validacionTextbox" ErrorMessage="Debe ingresar un codigo postal" ControlToValidate="txtCodigoPostal" runat="server" />
                    <asp:RegularExpressionValidator Display="Dynamic" CssClass="validacionTextbox" ErrorMessage="Solo letras y numeros" ControlToValidate="txtCodigoPostal" ValidationExpression="^[A-Za-z0-9]+$" runat="server" />
                </div>
                <div class="mb-4">
                    <label for="txtObservacion">Observacion</label>
                    <asp:TextBox ID="txtObservacion" CssClass="form-control rounde w-100" runat="server" />
                </div>
                <div class="">
                    <asp:Button CssClass="btn btn-success m-1" ID="btnAgregarDireccion" OnClick="btnAgregarDireccion_Click" Text="Agregar" runat="server" />
                    <a class="btn btn-secondary m-1" href="/Direccion.aspx">Cancelar</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
