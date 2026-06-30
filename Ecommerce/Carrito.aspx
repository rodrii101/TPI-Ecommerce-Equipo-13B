<%@ Page Title="" Language="C#" MasterPageFile="~/MasterCliente.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="Ecommerce.Carrito" %>

<%@ Import Namespace="dominioEcommerce" %>
<%-- Agrego dominios --%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <%--ESTO ES PARA EL UPDATEPANEL--%>
    <div class="container my-5">
        <h3 class="mb-4">Mi Carrito</h3>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:Panel ID="panelConProductos" runat="server" Visible="false">
                    <div class="row g-4 align-items-start">

                        <%-- COLUMNA IZQUIERDA --%>
                        <div class="col-lg-8">
                            <asp:Repeater ID="repRepetidorDetalleCarrito" OnItemCommand="repRepetidorDetalleCarrito_ItemCommand" runat="server">
                                <ItemTemplate>
                                    <div class="mb-3 p-3 border border-secondary-subtle rounded shadow-sm bg-white" style="min-height: 130px">
                                        <div class="pb-2">
                                            <p class="mb-0 fw-bold text-muted small">Vendedor <span class="text-success"><%#Eval("Usuario.Nombre") %></span> </p>
                                        </div>
                                        <hr class="mt-0 mb-3 text-secondary-50 opacity-25" />
                                        <div class="d-flex justify-content-between align-items-center"> 

                                            <img src="<%# ObtenerImagenPrincipal((CarritoDetalle)Container.DataItem)%>" alt="<%# Eval("Producto.Nombre") %>" style="max-height: 90px; width: auto;" />

                                            <div class="flex-grow-1 ms-3">
                                                <p class="mb-1 fw-semibold"><%# Eval("Producto.Nombre") %></p>
                                                <asp:LinkButton ID="btnEliminar" runat="server" CssClass="text-danger text-decoration-none small" CommandName="Eliminar" CommandArgument="<%# ((CarritoDetalle)Container.DataItem).Producto.Id %>">Eliminar</asp:LinkButton>
                                            </div>
                                            <%-- MSJ AVISO SI NO HAY STOCK SUFICIENTE --%>
                                            <div class="mt-2">
                                                <asp:Label ID="lblSinStock" runat="server" 
                                                    Text="¡Atención! Ya no contamos con stock de este producto." 
                                                    ForeColor="Red" 
                                                    Font-Bold="true"
                                                    Visible='<%# !(bool)Eval("HayStock") %>' />
            
                                                <asp:Label ID="lblCantidadModificada" runat="server" 
                                                    Text="¡Atención! Cantidad ajustada por stock insuficiente." 
                                                    ForeColor="OrangeRed" 
                                                    Font-Bold="true"
                                                    Visible='<%# !(bool)Eval("HayEsaCantidad") %>' />
                                            </div>

                                            <%-- BOTONES +/- --%>
                                            <div class="d-flex align-items-center border rounded mx-3 bg-light">
                                                <asp:Button ID="btnRestar" runat="server" Text="-" CssClass="btn btn-sm btn-light px-2" CommandName="Restar" CommandArgument='<%# Eval("Producto.Id") %>' />
                                                <span class="px-3 fw-bold"><%# Eval("Cantidad") %></span>
                                                <asp:Button ID="btnSumar" runat="server" Text="+" CssClass="btn btn-sm btn-light px-2" CommandName="Sumar" CommandArgument='<%# Eval("Producto.Id") %>' />
                                                <%--<asp:Label ID="lblNoHayStock" runat="server" ForeColor="Red" Text="Stock insuficiente" Visible="false"></asp:Label>--%>
                                            </div>
                                            <p class="mb-0 fw-bold">$ <%# Eval("Producto.Precio") %></p>
                                        </div>
                                        <div class="d-flex justify-content-end mt-2 border-top pt-2">
                                            <span class="fw-semibold text-secondary">Subtotal: 
                                                <span class="text-dark">$ <%# (Convert.ToDecimal(Eval("Cantidad")) * Convert.ToDecimal(Eval("Producto.Precio"))).ToString("0.00") %></span>
                                            </span>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>

                        <%-- COLUMNA DERECHA  --%>
                        <div class="col-lg-4 position-sticky" style="top: 20px; z-index: 1020;">
                            <div class="p-4 border border-secondary-subtle rounded shadow-sm bg-white">
                                <h5 class="mb-3">Resumen de compra</h5>
                                <hr />
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
                                    <%--<a class="btn btn-primary py-2 w-100 fw-semibold" href="/CompraPedido.aspx" <>Finalizar compra</a>--%>
                                    <asp:Button ID="btnFinalizarCompra" runat="server" Text="Finalizar Compra" CssClass="btn btn-primary py-2 w-100 fw-semibold" OnClick="btnFinalizarCompra_Click"/>
                                    <%--<asp:Button runat="server" Text="Finalizar compra" CssClass="btn btn-primary py-2 w-100 fw-semibold" />--%>
                                    <asp:LinkButton ID="btnContinuarComprando" runat="server" Text="Continuar comprando" CssClass="btn btn-outline-secondary py-2 w-100" OnClick="btnContinuarComprando_Click"></asp:LinkButton>
                                </div>
                            </div>
                        </div>

                    </div>
                </asp:Panel>


                <asp:Panel ID="panelSinProductos" runat="server" Visible="false">
                    <%-- CARRITO VACIO --%>
                    <div class="container">
                        <div class="row justify-content-center">
                            <div class="col-md-6 text-center py-5">
                                <svg xmlns="http://www.w3.org/2000/svg" width="50" height="50" fill="currentColor" class="mb-3 text-secondary" viewBox="0 0 16 16">
                                    <path d="M0 1.5A.5.5 0 0 1 .5 1H2a.5.5 0 0 1 .485.379L2.89 3H14.5a.5.5 0 0 1 .491.592l-1.5 8A.5.5 0 0 1 13 12H4a.5.5 0 0 1-.491-.408L2.01 3.607 1.61 2H.5a.5.5 0 0 1-.5-.5M5 12a2 2 0 1 0 0 4 2 2 0 0 0 0-4m7 0a2 2 0 1 0 0 4 2 2 0 0 0 0-4m-7 1a1 1 0 1 1 0 2 1 1 0 0 1 0-2m7 0a1 1 0 1 1 0 2 1 1 0 0 1 0-2" />
                                </svg>
                                <h5>Tu carrito está vacío</h5>
                                <p class="text-muted">¡Agrega productos para comenzar tu compra!</p>
                                <a href="/DefaultCliente.aspx" class="btn btn-primary mt-2">Volver al inicio</a>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
