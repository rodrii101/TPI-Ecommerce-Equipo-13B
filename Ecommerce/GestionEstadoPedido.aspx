<%@ Page Title="" Language="C#" MasterPageFile="~/MasterCliente.Master" AutoEventWireup="true" CodeBehind="GestionEstadoPedido.aspx.cs" Inherits="Ecommerce.GestionEstadoPedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager runat="server"></asp:ScriptManager>

    <div class="container mb-5 mt-5">
        <p class="fs-1">GESTION ESTADOS DE PEDIDOS </p>
        <div class="row">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="col-3 mb-3">
                        <asp:Label Text="Filtrado por Id del Pedido" runat="server" />
                        <asp:TextBox ID="txtIdPedido" CssClass="form-control mt-2" OnTextChanged="txtIdPedido_TextChanged" AutoPostBack="true" runat="server" />
                    </div>

                    <div class="col-8">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:Panel ID="panelPedidos" runat="server" Visible="false">
                                    <asp:GridView runat="server" ID="dgvPedidos" DataKeyNames="IdPedido" CssClass="table table-bordered table-striped shadow-sm text-center" OnSelectedIndexChanged="dgvPedidos_SelectedIndexChanged" AutoGenerateColumns="false" AllowPaging="true" PageSize="10">
                                        <Columns>
                                            <asp:BoundField HeaderText="Id" DataField="IdPedido" />
                                            <asp:BoundField HeaderText="Nombre" DataField="PedidoConfirmado.Cliente.Nombre"/>
                                            <asp:BoundField HeaderText="Apellido" DataField="PedidoConfirmado.Cliente.Apellido"/>
                                            <asp:BoundField HeaderText="Fecha Pedido" DataField="FechaPedido" />
                                            <asp:BoundField HeaderText="Estado" DataField="EstadoActual.Descripcion" />
                                            <asp:BoundField HeaderText="Total" DataField="PedidoConfirmado.MontoTotal" />
                                            <asp:CommandField ShowSelectButton="true" SelectText="📝" HeaderText="Gestionar Estado" />
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>

                                <asp:Panel ID="panelSinPedidos" runat="server" Visible="false" >
                                    <div class="col-7  m-3 d-flex justify-content-center align-items-center border border-secondary-subtle rounded shadow text-center">
                                        <div class="m-3 p-2">
                                            <p>En este momento no se encuentran pedidos.</p>
                                            <a class="btn btn-success" href="/Carrito.aspx">Realice una compra</a>
                                        </div>
                                    </div>
                                </asp:Panel>

                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <br />


</asp:Content>
