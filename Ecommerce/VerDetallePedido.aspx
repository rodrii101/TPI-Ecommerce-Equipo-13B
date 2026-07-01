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
                <h1>Pedido <%= PedidoSeleccionado.IdPedido %> </h1>
                <div class=" m-3 p-2 border border-secondary-subtle rounded shadow">
                    <div class="d-flex">

                        <div class="w-50 me-4">
                            <h6>Datos Usuario</h6>
                            <p>Nombre y Apellido <%= PedidoSeleccionado.PedidoConfirmado.Cliente.Nombre %>, <%= PedidoSeleccionado.PedidoConfirmado.Cliente.Apellido %></p>
                            <p>Telefono: <%= PedidoSeleccionado.PedidoConfirmado.Cliente.Telefono %> </p>
                            <p>DNI: <%= PedidoSeleccionado.PedidoConfirmado.Cliente.DNI %> </p>
                        </div>
                        <asp:Panel ID="PanelDomicilio" Visible="false" runat="server">
                            <div>
                                <h6>Domicilio</h6>
                                <p>Direccion: <%= PedidoSeleccionado.PedidoConfirmado.DireccionEntrega.Calle %> <%= PedidoSeleccionado.PedidoConfirmado.DireccionEntrega.Altura %></p>
                                <p><%= PedidoSeleccionado.PedidoConfirmado.DireccionEntrega.Piso %> <%= PedidoSeleccionado.PedidoConfirmado.DireccionEntrega.Departamento %></p>
                                <p><%= PedidoSeleccionado.PedidoConfirmado.DireccionEntrega.Localidad %> (CP:<%= PedidoSeleccionado.PedidoConfirmado.DireccionEntrega.CodigoPostal %>)</p>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="panelRetiroAlLocal" Visible="false" runat="server">
                            <div>
                                <h6>Local</h6>
                                <p>Se retira en el local</p>
                            </div>
                        </asp:Panel>
                    </div>
                    <div class="d-flex mb-1">
                        <p>Forma De entrega: <%= PedidoSeleccionado.PedidoConfirmado.FormaEntrega.Descripcion%></p>
                    </div>
                    <div class="d-flex mb-1">
                        <p>Forma de Pago: <%= PedidoSeleccionado.PedidoConfirmado.FormaDePago.Descripcion%></p>
                    </div>
                </div>
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
                <div class="d-flex justify-content-end">
                    <p class="fw-bolder font-monospace me-4">Total: <%= PedidoSeleccionado.PedidoConfirmado.MontoTotal %></p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
