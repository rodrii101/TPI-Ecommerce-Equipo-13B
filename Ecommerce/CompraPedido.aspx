<%--<%@ Page Title="" Language="C#" MasterPageFile="~/MasterCliente.Master" AutoEventWireup="true" CodeBehind="CompraPedido.aspx.cs" Inherits="Ecommerce.CompraPedido" %>--%>
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterCliente.Master" AutoEventWireup="true" CodeBehind="CompraPedido.aspx.cs" Inherits="Ecommerce.CompraPedido" EnableEventValidation="false" %>
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

    <%--PANEL CARGAR DATOS--%>
    <asp:Panel ID="panelCargaDatos" runat="server" Visible="true">
        <h3 class="mb-4">Confirmacion de compra</h3>
        <div class="row justify-content-center">
            <div class="col-5">
                
                <%-- MODIFICACIÓN AQUÍ: UPDATE PANEL EXCLUSIVO PARA DATOS DE USUARIO --%>
                <asp:UpdatePanel ID="upDatosUsuario" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="m-4 p-3 border border-secondary-subtle rounded shadow-sm bg-white">
                            <h5>Datos Usuario</h5>
                            <p class="mb-1">
                                Nombre:
                                <asp:TextBox ID="txtNombre" runat="server" Enabled="false"></asp:TextBox>
                                <asp:RequiredFieldValidator ValidationGroup="DatosPersonales" Display="Dynamic" CssClass="validacionTextbox" ErrorMessage="Debe ingresar un nombre" ControlToValidate="txtNombre" runat="server" />
                                <asp:RegularExpressionValidator ValidationGroup="DatosPersonales" Display="Dynamic" CssClass="validacionTextbox" ErrorMessage="Solo letras" ControlToValidate="txtNombre" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$" runat="server" />
                            </p>
                            <p class="mb-1">
                                Apellido:
                                <asp:TextBox ID="txtApellido" runat="server" Enabled="false"></asp:TextBox>
                                <asp:RequiredFieldValidator  ValidationGroup="DatosPersonales" Display="Dynamic" CssClass="validacionTextbox" ErrorMessage="Debe ingresar un nombre" ControlToValidate="txtApellido" runat="server" />
                                <asp:RegularExpressionValidator ValidationGroup="DatosPersonales" Display="Dynamic" CssClass="validacionTextbox" ErrorMessage="Solo letras" ControlToValidate="txtApellido" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$" runat="server"></asp:RegularExpressionValidator>
                            </p>
                            <p class="mb-1">
                                Email:
                                <asp:TextBox ID="txtEmail" runat="server" Enabled="false"></asp:TextBox>
                            </p>
                            <p class="mb-1">
                                DNI:
                                <asp:TextBox ID="txtDNI" runat="server" Enabled="false"></asp:TextBox>
                                <asp:RequiredFieldValidator ValidationGroup="DatosPersonales" Display="Dynamic" CssClass="validacionTextbox" ErrorMessage="Debe ingresar un DNI" ControlToValidate="txtDNI" runat="server" />
                                <asp:RegularExpressionValidator ValidationGroup="DatosPersonales" Display="Dynamic" CssClass="validacionTextbox" ErrorMessage="Solo 8 numeros" ControlToValidate="txtDNI" ValidationExpression="^\d{8}$" runat="server" />
                            </p>
                            <p class="mb-1">
                                Telefono:
                                <asp:TextBox ID="txtTelefono" runat="server" Enabled="false"></asp:TextBox>
                                <asp:RequiredFieldValidator ValidationGroup="DatosPersonales" Display="Dynamic" CssClass="validacionTextbox" ErrorMessage="Debe ingresar un Telefono" ControlToValidate="txtTelefono" runat="server" />
                                <asp:RegularExpressionValidator ValidationGroup="DatosPersonales" Display="Dynamic" CssClass="validacionTextbox" ErrorMessage="Solo numeros" ControlToValidate="txtTelefono" ValidationExpression="^[0-9]+$" runat="server" />
                            </p>
                            <asp:Button ID="btnGuardar" runat="server" ValidationGroup="DatosPersonales" Visible="false" CssClass="btn btn-success" Text="Guardar" OnClick="btnGuardar_Click"/>
                            <asp:Button ID="btnModificar" runat="server" Visible="false" CssClass="btn btn-secondary" Text="Modificar" CausesValidation="false" OnClick="btnModificar_Click" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

                <%-- MODIFICACIÓN AQUÍ: UPDATE PANEL EXCLUSIVO PARA FORMA DE ENTREGA --%>
                <div class="m-4 p-3 border border-secondary-subtle rounded shadow-sm bg-white">
                    <h5 class="mb-3">Forma de entrega</h5>
                    <asp:UpdatePanel ID="upFormaEntrega" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:RadioButtonList ID="rblFormaDeEntrega" runat="server" CssClass="w-100 d-flex" AutoPostBack="true" OnSelectedIndexChanged="rblFormaDeEntrega_SelectedIndexChanged">
                                <asp:ListItem Value="DOMICILIO" cssClass="w-50" Selected="true" Text="Envío a Domicilio" />
                                <asp:ListItem Value="LOCAL" cssClass="w-50" Text="Retiro en Local" />
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

                                <h6 class="mt-3  mb-3">Nueva direccion</h6>
                                <div class="d-flex mb-3">
                                    <div class="m-1 w-50">
                                        <label class="mb-1" for="txtCallePedido">Calle</label>
                                        <asp:TextBox ID="txtCallePedido" CssClass="form-control rounde" runat="server" />
                                        <asp:RequiredFieldValidator ValidationGroup="NuevaDireccion" Display="Dynamic" CssClass="validacionTextbox" ErrorMessage="Debe ingresar una calle" ControlToValidate="txtCallePedido" runat="server" />
                                        <asp:RegularExpressionValidator ValidationGroup="NuevaDireccion" Display="Dynamic" CssClass="validacionTextbox" ErrorMessage="Solo letras" ControlToValidate="txtCallePedido" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$" runat="server" />
                                    </div>
                                    <div class="m-1 w-50">
                                        <label class="mb-1" for="txtAlturaPedido">Altura</label>
                                        <asp:TextBox ID="txtAlturaPedido" CssClass="form-control rounde" runat="server" />
                                        <asp:RequiredFieldValidator ValidationGroup="NuevaDireccion" Display="Dynamic" CssClass="validacionTextbox" ErrorMessage="Debe ingresar una Altura" ControlToValidate="txtAlturaPedido" runat="server" />
                                        <asp:RegularExpressionValidator ValidationGroup="NuevaDireccion" Display="Dynamic" CssClass="validacionTextbox" ErrorMessage="Solo numeros" ControlToValidate="txtAlturaPedido" ValidationExpression="^[0-9]+$" runat="server" />
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
                                        <asp:RequiredFieldValidator ValidationGroup="NuevaDireccion" Display="Dynamic" CssClass="validacionTextbox" ErrorMessage="Debe ingresar localidad" ControlToValidate="txtLocalidadPedido" runat="server" />
                                        <asp:RegularExpressionValidator ValidationGroup="NuevaDireccion" Display="Dynamic" CssClass="validacionTextbox" ErrorMessage="Solo letras" ControlToValidate="txtLocalidadPedido" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$" runat="server" />
                                    </div>
                                    <div class="m-1 w-50">
                                        <label class="mb-1" for="txtCodPostalPedido">Codigo Postal</label>
                                        <asp:TextBox ID="txtCodPostalPedido" CssClass="form-control rounde" runat="server" />
                                        <asp:RequiredFieldValidator ValidationGroup="NuevaDireccion" Display="Dynamic" CssClass="validacionTextbox" ErrorMessage="Debe ingresar un codigo postal" ControlToValidate="txtCodPostalPedido" runat="server" />
                                        <asp:RegularExpressionValidator ValidationGroup="NuevaDireccion" Display="Dynamic" CssClass="validacionTextbox" ErrorMessage="Solo letras y numeros" ControlToValidate="txtCodPostalPedido" ValidationExpression="^[A-Za-z0-9]+$" runat="server" />
                                    </div>
                                </div>
                                <div class="mb-3">
                                    <label class="mb-1" for="txtObservacionesPedido">Observaciones</label>
                                    <asp:TextBox ID="txtObservacionesPedido" CssClass="form-control rounde" runat="server" />
                                </div>
                                <asp:Button ValidationGroup="NuevaDireccion" CssClass="btn btn-secondary m-1 w-100" Text="Agregar nueva direccion" ID="NuevaDireccionPedido" OnClick="NuevaDireccionPedido_Click" runat="server" />
                            </asp:Panel>
                            <asp:Panel ID="PanelRetiroAlLocal" Visible="false" runat="server">
                                <p>Retiro al local</p>
                                <svg class="text-center" width="30" height="30" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 384 512">
                                    <path d="M0 188.6C0 84.4 86 0 192 0S384 84.4 384 188.6c0 119.3-120.2 262.3-170.4 316.8-11.8 12.8-31.5 12.8-43.3 0-50.2-54.5-170.4-197.5-170.4-316.8zM192 256a64 64 0 1 0 0-128 64 64 0 1 0 0 128z" />
                                </svg>
                                <p>Estamos ubicados en Tucuman al 2042</p>
                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

                <%-- EL REPETIDOR DE FORMA DE PAGO NO LLEVA UPDATE PANEL PROPIO, DE ESTA MANERA NO SE REINICIA TRAS EL POSTBACK DE LOS OTROS PANELES --%>
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
                <asp:UpdatePanel ID="upResumenCompra" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
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
                        <asp:Label runat="server" Text="Cantidad de productos:"></asp:Label>
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
            </ContentTemplate>
        <Triggers>
            <%-- OBLIGAMOS A ESTE PANEL A ACTUALIZARSE CUANDO CAMBIEN LOS OTROS PANELES --%>
            <asp:AsyncPostBackTrigger ControlID="btnGuardar" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnModificar" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="rblFormaDeEntrega" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="NuevaDireccionPedido" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
            </div>
        </div>
    </asp:Panel>

    <%--VISTA CONFIRMAR PEDIDO (Lleva su propio UpdatePanel para cuando hagas el cambio de vista general con btnFinalizarCompraPedido o btnAtras)--%>
    <asp:UpdatePanel ID="upConfirmarPedido" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="panelConfirmarPedido" runat="server" Visible="false">
                <h3 class="mb-4">Confirmación de pedido</h3>
                <div class="row justify-content-center">
                    <div class="col-5">
                        <div class="m-4 p-3 border border-secondary-subtle rounded shadow-sm bg-white">
                            <h5>Datos Personales</h5>
                            <p class="mb-1">
                                <strong>Nombre y apellido:</strong>
                                <asp:Label ID="lblConfNombre" runat="server" Text="" />
                                <asp:Label ID="lblConfApellido" runat="server" Text="" />
                            </p>
                            <p class="mb-1">
                                <strong>Email:</strong>
                                <asp:Label ID="lblConfEmail" runat="server" Text="" />
                            </p>
                            <p class="mb-1">
                                <strong>DNI:</strong>
                                <asp:Label ID="lblConfDni" runat="server" Text="" />
                            </p>
                            <p class="mb-3">
                                <strong>Teléfono:</strong>
                                <asp:Label ID="lblConfTelefono" runat="server" Text="" />
                            </p>
                            <hr />

                            <h5 class="mb-3">Forma de entrega</h5>
                            <div class="mb-2">
                                <asp:Label ID="lblConfTipoEntrega" runat="server" CssClass="fw-semibold" Text="" />
                            </div>
                            <div id="divConfDomicilio" runat="server" visible="false">
                                <p><strong>Envío a:</strong></p>
                                <ul class="list-unstyled mb-0">
                                    <li><strong>Calle:</strong> <asp:Label ID="lblConfCalle" runat="server" Text="" /></li>
                                    <li><strong>Altura:</strong> <asp:Label ID="lblConfAltura" runat="server" Text="" /></li>
                                    <li><strong>Piso:</strong> <asp:Label ID="lblConfPiso" runat="server" Text="" /></li>
                                    <li><strong>Departamento:</strong> <asp:Label ID="lblConfDepto" runat="server" Text="" /></li>
                                    <li><strong>Localidad:</strong> <asp:Label ID="lblConfLocalidad" runat="server" Text="" /></li>
                                    <li><strong>Código Postal:</strong> <asp:Label ID="lblConfCodPostal" runat="server" Text="" /></li>
                                    <li><strong>Observaciones:</strong> <asp:Label ID="lblConfObservaciones" runat="server" Text="" /></li>
                                </ul>
                            </div>
                            <div id="divConfRetiro" runat="server" visible="false">
                                <p>
                                   <strong> Retiro en local – </strong>
                                    <asp:Label ID="lblRetiro" runat="server"></asp:Label>
                                </p>
                            </div>
                            <hr />

                            <h5 class="mb-3">Forma de pago</h5>
                            <p>
                                <asp:Label ID="lblConfPago" runat="server" Text="" CssClass="fw-semibold" />
                            </p>
                        </div>
                    </div>

                    <div class="col-4 align-self-start">
                        <div class="p-3 m-2 border border-secondary-subtle rounded shadow-sm bg-white">
                            <h5 class="mb-3">Resumen de compra</h5>
                            <hr />
                            <asp:Repeater ID="rptConfirmarPedido" runat="server">
                                <ItemTemplate>
                                    <div class="d-flex align-items-center mb-3">
                                        <img src="<%# ObtenerImagenPrincipal((dominioEcommerce.CarritoDetalle)Container.DataItem)%>" width="75" height="75" alt="<%# Eval("Producto.Nombre") %>" />
                                        <div class="flex-column">
                                            <p class="mb-0"><%# Eval("Producto.Nombre") %></p>
                                            <span class="text-dark">$ <%# (Convert.ToDecimal(Eval("Cantidad")) * Convert.ToDecimal(Eval("Producto.Precio"))).ToString("0.00") %></span>
                                            <p class="text-muted mb-0 fs-6">Cantidad: <%# Eval("Cantidad") %></p>
                                        </div>
                                    </div>
                                    <hr />
                                </ItemTemplate>
                            </asp:Repeater>
                            <div class="d-flex justify-content-between my-2">
                                <asp:Label runat="server" Text="Cantidad de productos:" />
                                <asp:Label ID="lblConfCantidadProductos" runat="server" CssClass="fw-semibold" Text="" />
                            </div>
                            <hr />
                            <div class="d-flex justify-content-between my-3 align-items-center">
                                <asp:Label runat="server" Text="Total a pagar:" CssClass="fw-bold fs-5" />
                                <asp:Label ID="lblConfTotalAPagar" runat="server" CssClass="text-end fw-bold fs-5 text-primary" Text="" />
                            </div>
                            <hr />
                            <div class="gap-2 d-flex flex-column">
                                <asp:Button ID="btnConfirmarPedido" OnClick="btnConfirmarPedido_Click" runat="server" Text="Confirmar pedido" CssClass="btn btn-success py-2 w-100 fw-semibold" />
                                <asp:Button ID="btnAtras" runat="server" CssClass="btn btn-secondary py-2 w-100 fw-semibold" Text="Atrás" OnClick="btnAtras_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <%-- ESTA LÍNEA OBLIGA A btnAtras A HACER UN POSTBACK COMPLETO --%>
            <asp:PostBackTrigger ControlID="btnAtras" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>