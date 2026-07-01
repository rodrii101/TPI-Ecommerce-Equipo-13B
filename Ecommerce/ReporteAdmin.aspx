<%@ Page Title="" Language="C#" MasterPageFile="~/MasterCliente.Master" AutoEventWireup="true" CodeBehind="ReporteAdmin.aspx.cs" Inherits="Ecommerce.ReporteAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="mb-5 mt-5">
        <h1>Reportes</h1>
        <h2 class="text-center mb-4">Top 10 Pedidos</h2>
        <asp:GridView ID="dgvTopPedidos" runat="server" DataKeyNames="IdPedido" CssClass="table table-bordered table-striped shadow-sm text-center mb-5"
            AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="IdPedido" DataField="IdPedido" />
                <asp:BoundField HeaderText="Nombre" DataField="PedidoConfirmado.Cliente.Nombre" />
                <asp:BoundField HeaderText="Apellido" DataField="PedidoConfirmado.Cliente.Apellido" />
                <asp:BoundField HeaderText="Monto" DataField="PedidoConfirmado.MontoTotal" />
            </Columns>
        </asp:GridView>
        <h2  class="text-center mb-4" >Top 10 Producto</h2>
        <asp:GridView ID="dgvTopProducto" runat="server" DataKeyNames="IdProducto" CssClass="table table-bordered table-striped shadow-sm text-center mb-5"
            AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="IdProducto" DataField="Producto.Id" />
                <asp:BoundField HeaderText="Nombre" DataField="Producto.Nombre" />
                <asp:BoundField HeaderText="Marca" DataField="Producto.Marca.Descripcion" />
                <asp:BoundField HeaderText="Categoria" DataField="Producto.Categoria.Descripcion" />
                <asp:BoundField HeaderText="CantidadTotal" DataField="Cantidad" />
            </Columns>
        </asp:GridView>
        <h2  class="text-center mb-4">Top 10 Vendedores</h2>
        <asp:GridView ID="dgvTopVendedores" runat="server" DataKeyNames="IdPedido" CssClass="table table-bordered table-striped shadow-sm text-center mb-5"
            AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="IdVendedor" DataField="Producto.IdVendedor" />
                <asp:BoundField HeaderText="Nombre del vendedor" DataField="NombreDelVendedor" />
                <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
                <asp:BoundField HeaderText="Total" DataField="PrecioUnitario" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
