<%@ Page Title="" Language="C#" MasterPageFile="~/MasterCliente.Master" AutoEventWireup="true" CodeBehind="CompraDelUsuario.aspx.cs" Inherits="Ecommerce.CompraDelUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
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
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="ConCompras" Visible="false" runat="server">
                            <asp:GridView runat="server" ID="dgvPedidosUsuario" DataKeyNames="IdPedido" CssClass="table table-bordered table-striped shadow-sm text-center" OnSelectedIndexChanged="dgvPedidosUsuario_SelectedIndexChanged" AutoGenerateColumns="false" AllowPaging="true" PageSize="10">
                                <Columns>
                                    <asp:BoundField HeaderText="Id" DataField="IdPedido" />
                                    <asp:BoundField HeaderText="FechaPedido" DataField="FechaPedido" />
                                    <asp:BoundField HeaderText="Estado" DataField="EstadoActual.Descripcion" />
                                    <asp:BoundField HeaderText="Total" DataField="PedidoConfirmado.MontoTotal" />
                                    <asp:CommandField ShowSelectButton="true" SelectText="📝" HeaderText="Ver detalle pedido" />
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                        <asp:Panel ID="SinCompras" Visible="false" runat="server">

                            <div class="col-7  m-3 d-flex justify-content-center align-items-center border border-secondary-subtle rounded shadow text-center">
                                <div class="m-3 p-2">
                                    <p>En este momento no se encuentra ninguna compra</p>
                                    <a class="btn btn-success" href="/Carrito.aspx">Realice una compra</a>
                                </div>
                            </div>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
