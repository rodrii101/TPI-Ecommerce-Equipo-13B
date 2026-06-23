<%@ Page Title="" Language="C#" MasterPageFile="~/MasterCliente.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="Ecommerce.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="m-5">Carrito</h3>
    <%-- Este es el caso que aun no se encuentre un producto--%>
    <% if (listaCarritoDetalle.Count > 0)
        {

    %>
    <div class="container">
        <div class="row">
            <asp:Repeater ID="repRepetidorDetalleCarrito" runat="server">
                <ItemTemplate>
                    <div class="col-7 me-5 ">
                        <div class="m-2 d-flex p-3 border border-secondary-subtle rounded shadow justify-content-between" style="height: 130px">
                            <img src="https://images.fravega.com/f500/2c7c1702016f66dee9351507ff774996.jpg" class="w-25" alt="Alternate Text" />
                            <p><%# Eval("Producto.Nombre") %></p>
                            <div class="d-flex text-center" style="height: 40px">
                                <span>-</span>
                                <span>1</span>
                                <span>+</span>
                            </div>
                            <p><%# Eval("Producto.Precio") %></p>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

            <div class="col-4  p-3 border border-secondary-subtle rounded shadow">
                <div class="m-3">
                    <ul style="list-style-type: none">
                        <li class="m-3">Detalle de la compra</li>
                        <hr />
                        <li class="m-3">Catidad de productos</li>
                        <li class="m-3">Descuento</li>
                        <hr />
                        <li class="m-3 d-flex justify-content-between">
                            <asp:Label Text="Total a pagar" runat="server" />
                            <span class="text-end">$ Monto a pagar</span>
                        </li>
                        <hr />
                        <li class="m-3">
                            <asp:Button Text="Finalizar compra" CssClass="btn btn-success mb-3 w-100" runat="server" />
                            <asp:Button Text="Continuar agregando productos" CssClass="btn btn-outline-secondary mb-3 w-100" runat="server" />
                        </li>

                    </ul>
                </div>
            </div>
        </div>

    </div>
    <%}
        else
        {  %>
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-5 ">
                <div class=" m-4 p-3 text-center">
                    <svg xmlns="http://www.w3.org/2000/svg" width="40" height="40" fill="currentColor" class="m-2 bi bi-cart-fill" viewBox="0 0 16 16">
                        <path d="M0 1.5A.5.5 0 0 1 .5 1H2a.5.5 0 0 1 .485.379L2.89 3H14.5a.5.5 0 0 1 .491.592l-1.5 8A.5.5 0 0 1 13 12H4a.5.5 0 0 1-.491-.408L2.01 3.607 1.61 2H.5a.5.5 0 0 1-.5-.5M5 12a2 2 0 1 0 0 4 2 2 0 0 0 0-4m7 0a2 2 0 1 0 0 4 2 2 0 0 0 0-4m-7 1a1 1 0 1 1 0 2 1 1 0 0 1 0-2m7 0a1 1 0 1 1 0 2 1 1 0 0 1 0-2" />
                    </svg>
                    <p>No hay ningun producto en el carrito</p>
                    <p>¡¡Agregue un producto al carrito!!</p>
                </div>
                <div class="m-4 text-center">
                    <a href="/DefaultCliente.aspx">Volver al inicio</a>
                </div>
            </div>
        </div>
    </div>
    <%} %>
    <br />
</asp:Content>
