<%@ Page Title="" Language="C#" MasterPageFile="~/MasterCliente.Master" AutoEventWireup="true" CodeBehind="CompraPedido.aspx.cs" Inherits="Ecommerce.CompraPedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="mb-4">Mi Carrito</h3>
    <div class="row justify-content-center">
        <div class="col-4">
            <h2>Datos Usuario</h2>
            <div class="m-4 p-3 border border-secondary-subtle rounded shadow-sm bg-white">
                <p class="mb-1">Nombre y apellido: <asp:Label Text="" ID="lblNombreUsuario" runat="server" /> <asp:Label Text="" ID="lblApellidoUsuario" runat="server" /> </p>
                <p class="mb-1">Email: <asp:Label Text="" ID="lblEmailUsuario" runat="server" /> </p>
                <p class="mb-1">DNI: <asp:Label Text="" ID="lblDniUsuario" runat="server" /></p>
                <p class="mb-1">Telefono <asp:Label Text="" ID="lblTelefonoUsuario" runat="server" /></p>
            </div>
        </div>
        <div class="col-4 m-2 border border-secondary-subtle rounded shadow-sm bg-white">
            <div class="p-4">
                <h5 class="mb-3">Resumen de compra</h5>
                <hr />
                <asp:Repeater ID="repRepetidorProductos" runat="server">
                    <ItemTemplate>
                        <div class="d-flex align-items-center mb-3">
                            <img src="<%# ObtenerImagenPrincipal((dominioEcommerce.CarritoDetalle)Container.DataItem)%>" width="75" height="75" alt="<%# Eval("Producto.Nombre") %>" />
                            <div class="flex-column">
                                <p class="mb-0"><%# Eval("Producto.Nombre") %></p>
                                <p class="text-muted mb-0">Catidad del Producto <%# Eval("Cantidad") %></p>
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
