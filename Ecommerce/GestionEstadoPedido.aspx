<%@ Page Title="" Language="C#" MasterPageFile="~/MasterCliente.Master" AutoEventWireup="true" CodeBehind="GestionEstadoPedido.aspx.cs" Inherits="Ecommerce.GestionEstadoPedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager runat="server"></asp:ScriptManager>

    <div class="container my-5">
        
        <div class="row mb-4">
            <div class="col">
                <h2 class="fw-bold text-dark border-bottom pb-2">Gestión de Estados de Pedidos</h2>
            </div>
        </div>

        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                
                <div class="row mb-4">
                    <div class="col-12 col-md-4 col-lg-3">
                        <div class="card shadow-sm border-0 bg-light p-3">
                            <label class="form-label small fw-bold text-muted mb-1">Filtrado por ID del Pedido</label>
                            <asp:TextBox ID="txtIdPedido" CssClass="form-control shadow-sm" OnTextChanged="txtIdPedido_TextChanged" AutoPostBack="true" runat="server" placeholder="Ej: 3" />
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-12">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                
                                <asp:Panel ID="panelPedidos" runat="server" Visible="false" class="card shadow-sm border-0">
                                    <div class="card-body p-0">
                                        <div class="table-responsive">
                                            <asp:GridView runat="server" ID="dgvPedidos" DataKeyNames="IdPedido" CssClass="table table-hover table-striped mb-0 align-middle text-center" OnSelectedIndexChanged="dgvPedidos_SelectedIndexChanged" AutoGenerateColumns="false" AllowPaging="true" PageSize="10">
                                                <HeaderStyle CssClass="table-light text-secondary text-uppercase fs-7 border-bottom" />
                                                <Columns>
                                                    <asp:BoundField HeaderText="Id" DataField="IdPedido" ItemStyle-CssClass="fw-bold text-dark" />
                                                    <asp:BoundField HeaderText="Nombre" DataField="PedidoConfirmado.Cliente.Nombre" ItemStyle-CssClass="text-dark" />
                                                    <asp:BoundField HeaderText="Apellido" DataField="PedidoConfirmado.Cliente.Apellido" ItemStyle-CssClass="text-dark" />
                                                    <asp:BoundField HeaderText="Fecha Pedido" DataField="FechaPedido" ItemStyle-CssClass="text-dark" />
                                                    <asp:BoundField HeaderText="Estado" DataField="EstadoActual.Descripcion" ItemStyle-CssClass="text-dark" />
                                                    <asp:BoundField HeaderText="Total" DataField="PedidoConfirmado.MontoTotal" ItemStyle-CssClass="text-dark" />
                                                    <asp:CommandField ShowSelectButton="true" SelectText="📝" HeaderText="Gestionar Estado" ControlStyle-CssClass="text-decoration-none fs-5" />
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </asp:Panel>

                                <asp:Panel ID="panelSinPedidos" runat="server" Visible="false">
                                    <div class="card shadow-sm border-0 bg-light text-center py-5">
                                        <div class="card-body">
                                            <p class="text-muted fs-5 mb-3">En este momento no se encuentran pedidos en el sistema.</p>
                                            <a class="btn btn-success px-4 py-2 fw-semibold" href="/Carrito.aspx">Realice una compra</a>
                                        </div>
                                    </div>
                                </asp:Panel>

                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

</asp:Content>