<%@ Page Title="" Language="C#" MasterPageFile="~/MasterCliente.Master" AutoEventWireup="true" CodeBehind="VerDetallePedido.aspx.cs" Inherits="Ecommerce.VerDetallePedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5 mb-5">
        <div class="row">
            <ul class="col-3 m-3 me-5 nav flex-column">
                <li class="nav-item">
                    <a class="nav-link link-dark" href="/Perfil.aspx">Perfil</a>
                    <hr />
                </li>
                <li class="nav-item">
                    <a class="nav-link link-dark" href="/Direccion.aspx">Direccion</a>
                    <hr />
                </li>
                <li class="nav-item">
                    <a class="nav-link link-dark" href="/CompraDelUsuario.aspx">Compras</a>
                    <hr />
                </li>
                <li class="nav-item">
                    <a class="nav-link link-dark" href="#">Cerrar sesion</a>
                    <hr />
                </li>
            </ul>

            <div class="col-8">
                <asp:GridView runat="server" ID="dgvDetallePedido" DataKeyNames="IdPedido" CssClass="table table-bordered table-striped shadow-sm text-center" AutoGenerateColumns="false" AllowPaging="true" PageSize="10">
                    <Columns>
                        <asp:BoundField HeaderText="Id" DataField="IdPedidoDetalle" />
                        <asp:BoundField HeaderText="Producto" DataField="Producto.Nombre" />
                        <asp:BoundField HeaderText="PrecioUnitario" DataField="PrecioUnitario" />
                        <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
                        <asp:BoundField HeaderText="Vendedor" DataField="NombreDelVendedor" />
                      <%--  <asp:BoundField HeaderText="Subtotal" DataField="Subtotal" />--%>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
