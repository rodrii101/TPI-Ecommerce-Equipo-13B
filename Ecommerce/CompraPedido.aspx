<%@ Page Title="" Language="C#" MasterPageFile="~/MasterCliente.Master" AutoEventWireup="true" CodeBehind="CompraPedido.aspx.cs" Inherits="Ecommerce.CompraPedido" %>

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
    <h3 class="mb-4">Confirmacion pedido</h3>
    <div class="row justify-content-center">
        <div class="col-5">
            <div class="m-4 p-3 border border-secondary-subtle rounded shadow-sm bg-white">
                <h5>Datos Usuario</h5>
                <p class="mb-1">
                    Nombre y apellido:
                    <asp:Label Text="Nombre: " ID="lblNombreUsuario" runat="server" />
                    <asp:Label Text="" ID="lblApellidoUsuario" runat="server" />
                </p>
                <p class="mb-1">
                    Email:
                    <asp:Label Text="" ID="lblEmailUsuario" runat="server" />
                </p>
                <p class="mb-1">
                    DNI:
                    <asp:Label Text="" ID="lblDniUsuario" runat="server" />
                </p>
                <p class="mb-1">
                    Telefono
                    <asp:Label Text="" ID="lblTelefonoUsuario" runat="server" />
                </p>
            </div>
            <div class="m-4 p-3 border border-secondary-subtle rounded shadow-sm bg-white">
                <h5 class="mb-3">Forma de entrega</h5>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <asp:RadioButtonList ID="rblFormaDeEntrega" runat="server" CssClass="w-100 d-flex" AutoPostBack="true" OnSelectedIndexChanged="rblFormaDeEntrega_SelectedIndexChanged">
                            <asp:ListItem Value="Domicilio" cssClass="w-50" Selected="true" Text="Envío a Domicilio" />
                            <asp:ListItem Value="Retiro" cssClass="w-50" Text="Retiro en Local" />
                        </asp:RadioButtonList>
                        <asp:Panel ID="PanelConDireccionUsuario" Visible="true" runat="server">
                            <p class="fw-semibold mb-2">Domicilios del usuario</p>
                            <div class="list-group">
                                <asp:Repeater ID="repRepetidorDomicilios" runat="server">
                                    <ItemTemplate>
                                        <div class="list-group-item d-flex align-items-center rounded-3 mb-2 p-2 border bg-light">
                                            <input class="form-check-input me-2" type="radio" name="grupoDomicilio"
                                                value="<%# Eval("Id") %>" <%# Container.ItemIndex == 0 ? "checked" : "" %> id="<%# Eval("Id") %>" />
                                            <label class="form-check-label w-100" style="cursor: pointer;" for="<%# Eval("Id") %>">
                                                <span><%# Eval("Calle") %> <%# Eval("Altura") %></span>
                                                <span class="text-muted d-block"><%# Eval("Localidad") %> (CP: <%# Eval("CodigoPostal") %>)</span>
                                            </label>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>

                            <h6 class="mt-3  mb-3">Nueva direccion</h>
                            <div class="d-flex mb-3">
                                <div class="m-1 w-50">
                                    <label class="mb-1" for="txtCallePedido">Calle</label>
                                    <asp:TextBox ID="txtCallePedido" CssClass="form-control rounde" runat="server" />
                                    <asp:RequiredFieldValidator Display="Dynamic" CssClass="validacionTextbox" ErrorMessage="Debe ingresar una calle" ControlToValidate="txtCallePedido" runat="server" />
                                    <asp:RegularExpressionValidator Display="Dynamic" CssClass="validacionTextbox" ErrorMessage="Solo letras" ControlToValidate="txtCallePedido" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$" runat="server" />
                                </div>
                                <div class="m-1 w-50">
                                    <label class="mb-1" for="txtAlturaPedido">Altura</label>
                                    <asp:TextBox ID="txtAlturaPedido" CssClass="form-control rounde" runat="server" />
                                    <asp:RequiredFieldValidator Display="Dynamic" CssClass="validacionTextbox" ErrorMessage="Debe ingresar una Altura" ControlToValidate="txtAlturaPedido" runat="server" />
                                    <asp:RegularExpressionValidator Display="Dynamic" CssClass="validacionTextbox" ErrorMessage="Solo numeros" ControlToValidate="txtAlturaPedido" ValidationExpression="^[0-9]+$" runat="server" />
                                </div>
                            </div>
                                <div class="d-flex mb-3">
                                    <div class="m-1 w-50">
                                        <label class="mb-1" for="txtPisoPedido">Piso</label>
                                        <asp:TextBox ID="txtPisoPedido" CssClass="form-control rounde" runat="server" />
                                    </div>
                                    <div class="m-1 w-50">
                                        <label for="txtDepartamentoPedido">Departamento</label>
                                        <asp:TextBox ID="txtDepartamentoPedido" CssClass="form-control rounde" runat="server" />
                                    </div>
                                </div>
                                <div class="d-flex mb-3">
                                    <div class="m-1 w-50">
                                        <label class="mb-1" for="txtLocalidadPedido">Localidad</label>
                                        <asp:TextBox ID="txtLocalidadPedido" CssClass="form-control rounde" runat="server" />
                                        <asp:RequiredFieldValidator Display="Dynamic" CssClass="validacionTextbox" ErrorMessage="Debe ingresar localidad" ControlToValidate="txtLocalidadPedido" runat="server" />
                                        <asp:RegularExpressionValidator Display="Dynamic" CssClass="validacionTextbox" ErrorMessage="Solo letras" ControlToValidate="txtLocalidadPedido" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$" runat="server" />
                                    </div>
                                    <div class="m-1 w-50">
                                        <label class="mb-1" for="txtCodPostalPedido">Codigo Postal</label>
                                        <asp:TextBox ID="txtCodPostalPedido" CssClass="form-control rounde" runat="server" />
                                        <asp:RequiredFieldValidator Display="Dynamic" CssClass="validacionTextbox" ErrorMessage="Debe ingresar un codigo postal" ControlToValidate="txtCodPostalPedido" runat="server" />
                                        <asp:RegularExpressionValidator Display="Dynamic" CssClass="validacionTextbox" ErrorMessage="Solo letras y numeros" ControlToValidate="txtCodPostalPedido" ValidationExpression="^[A-Za-z0-9]+$" runat="server" />
                                    </div>
                                </div>
                                <div class="mb-3">
                                    <label class="mb-1" for="txtObservacionesPedido">Observaciones</label>
                                    <asp:TextBox ID="txtObservacionesPedido" CssClass="form-control rounde" runat="server" />
                                </div>
                                <asp:Button CssClass="btn btn-secondary m-1 w-100" Text="Agregar nueva direccion" ID="NuevaDireccionPedido" OnClick="NuevaDireccionPedido_Click" runat="server" />
                        </asp:Panel>
                        <asp:Panel ID="PanelRetiroAlLocal" Visible="false" runat="server">
                            <p>Retiro al local</p>
                            <svg class="text-center" width="30" height="30" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 384 512">
                                <!--!Font Awesome Free v7.2.0 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license/free Copyright 2026 Fonticons, Inc.-->
                                <path d="M0 188.6C0 84.4 86 0 192 0S384 84.4 384 188.6c0 119.3-120.2 262.3-170.4 316.8-11.8 12.8-31.5 12.8-43.3 0-50.2-54.5-170.4-197.5-170.4-316.8zM192 256a64 64 0 1 0 0-128 64 64 0 1 0 0 128z" />
                            </svg>
                            <p>Estamos ubicados en Tucuman al 2042</p>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="m-4 p-3 border border-secondary-subtle rounded shadow-sm bg-white">
                <h5 class="mb-3">Forma de Pago</h5>
                <asp:Repeater ID="repRepitidorFormaDePago" runat="server">
                    <ItemTemplate>
                        <div class="list-group-item d-flex align-items-center rounded-3 mb-2 p-2 border bg-light">
                            <input type="radio" name="grupoPagos" value="<%# Eval("IdFormasDePago") %>" <%# Container.ItemIndex == 0 ? "checked" : "" %> id="pago_<%# Eval("IdFormasDePago") %>" />
                            <label class="form-check-label w-100" style="cursor: pointer;" for="pago_<%# Eval("IdFormasDePago") %>">
                                <span><%# Eval("Descripcion") %></span>
                            </label>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <div class="col-4 align-self-start ">
            <div class="p-3 m-2 border border-secondary-subtle rounded shadow-sm bg-white">
                <h5 class="mb-3">Resumen de compra</h5>
                <hr />
                <asp:Repeater ID="repRepetidorProductos" runat="server">
                    <ItemTemplate>
                        <div class="d-flex align-items-center mb-3">
                            <img src="<%# ObtenerImagenPrincipal((dominioEcommerce.CarritoDetalle)Container.DataItem)%>" width="75" height="75" alt="<%# Eval("Producto.Nombre") %>" />
                            <div class="flex-column">
                                <p class="mb-0"><%# Eval("Producto.Nombre") %></p>
                                <asp:Label Text="SubTotal" runat="server" />
                                <span class="text-dark">$ <%# (Convert.ToDecimal(Eval("Cantidad")) * Convert.ToDecimal(Eval("Producto.Precio"))).ToString("0.00") %></span>
                                 <p class="text-muted mb-0 fs-6">Catidad del Producto <%# Eval("Cantidad") %></p>
                            </div>
                        </div>
                        <hr />
                    </ItemTemplate>
                </asp:Repeater>
                <div class="d-flex justify-content-between my-2">
                    <asp:Label runat="server" CssClass="" Text="Cantidad de productos:"></asp:Label>
                    <asp:Label ID="lblCantidadProductos" runat="server" class="fw-semibold" Text=""></asp:Label>
                </div>
                <hr />
                <div class="d-flex justify-content-between my-3 align-items-center">
                    <asp:Label runat="server" Text="Total a pagar:" CssClass="fw-bold fs-5" />
                    <asp:Label ID="lblTotalAPagar" runat="server" class="text-end fw-bold fs-5 text-primary" Text=""></asp:Label>
                </div>
                <hr />
                <div class="gap-2 d-flex flex-column">
                    <asp:Button ID="btnFinalizarCompraPedido" OnClick="btnFinalizarCompraPedido_Click" runat="server" Text="Finalizar compra" CssClass="btn btn-primary py-2 w-100 fw-semibold" />
                </div>
            </div>

        </div>
    </div>
</asp:Content>
