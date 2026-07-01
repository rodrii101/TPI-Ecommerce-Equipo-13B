<%@ Page Title="" Language="C#" MasterPageFile="~/MasterCliente.Master" AutoEventWireup="true" CodeBehind="GestionarEstado.aspx.cs" Inherits="Ecommerce.GestionarEstado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="divDatosPedido" runat="server" class="container my-5">
        
        <div class="row mb-4">
            <div class="col">
                <h2 class="fw-bold text-dark border-bottom pb-2">Gestión del Pedido</h2>
            </div>
        </div>

        <div class="row g-4">
            <%-- DATO PEDIDOS --%>
            <div class="col-12 col-md-6">
                <div class="card h-100 shadow-sm border-0 bg-light">
                    <div class="card-body p-4">
                        <h5 class="card-title fw-bold mb-4 text-secondary text-uppercase tracking-wider fs-6">
                            Datos del Pedido
                        </h5>
                        
                        <div class="row g-3">
                            <div class="col-6">
                                <span class="text-muted d-block small">ID Pedido</span>
                                <strong class="text-dark fs-5"><asp:Label ID="lblIdPedido" runat="server" Text="" /></strong>
                            </div>
                            <div class="col-6">
                                <span class="text-muted d-block small">Monto Total</span>
                                <strong class="text-dark fs-5"><asp:Label ID="lblMontoTotal" runat="server" Text="" /></strong>
                            </div>
                            
                            <div class="col-12"><hr class="my-1 text-black-50"></div>
                            
                            <div class="col-12">
                                <span class="text-muted d-block small">Cliente</span>
                                <span class="text-dark fw-semibold"><asp:Label ID="lblCliente" runat="server" Text="" /></span>
                            </div>
                            <div class="col-12">
                                <span class="text-muted d-block small">Fecha</span>
                                <span class="text-dark"><asp:Label ID="lblFecha" runat="server" Text="" /></span>
                            </div>
                            <div class="col-6">
                                <span class="text-muted d-block small">Forma de Entrega</span>
                                <span class="text-dark fw-semibold"><asp:Label ID="lblFormaDeEntrega" runat="server" Text="" /></span>
                            </div>
                            <div class="col-6">
                                <span class="text-muted d-block small">Forma de Pago</span>
                                <span class="text-dark fw-semibold"><asp:Label ID="lblFormaDePago" runat="server" Text="" /></span>
                            </div>
                            <div class="col-12">
                                <span class="text-muted d-block small">Estado Actual</span>
                                <span class="text-dark fw-bold fs-5"><asp:Label ID="lblEstado" runat="server" Text="" /></span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <%-- FORMULARIO PEDIDO --%>
            <div class="col-12 col-md-6">
                <div class="card h-100 shadow-sm border-0">
                    <div class="card-body p-4 d-flex flex-column justify-content-between">
                        
                        <div>
                            <div class="mb-3">
                                <asp:Button ID="btnRegistrarEstado" runat="server" class="btn btn-primary w-100 py-2 fw-semibold shadow-sm" OnClick="btnRegistrarEstado_Click" Text="Registrar Nuevo Estado"/>
                            </div>

                            <asp:Panel ID="panelResgistrarEstado" runat="server" Visible="false" class="card card-body bg-light border-0 mb-3 animate__animated animate__fadeIn">
                                <h6 class="fw-bold mb-3 text-primary">Actualizar Estado</h6>
                                
                                <div class="mb-3">
                                    <label class="form-label small fw-bold text-muted">Seleccione el nuevo estado:</label>
                                    <asp:DropDownList ID="ddlEstados" runat="server" CssClass="form-select shadow-sm"></asp:DropDownList>
                                </div>
                                <div class="mb-3">
                                    <label class="form-label small fw-bold text-muted">Observaciones:</label>
                                    <asp:TextBox ID="txtObservacion" runat="server" CssClass="form-control shadow-sm" TextMode="MultiLine" Rows="3" MaxLength="500" placeholder="Ingrese observaciones si es necesario..." ></asp:TextBox>
                                </div>
                                <div>
                                    <asp:Button ID="btnRegistrar" runat="server" CssClass="btn btn-success w-100 shadow-sm fw-semibold" Text="Guardar Estado" OnClick="btnRegistrar_Click" />
                                </div>
                            </asp:Panel>
                        </div>

                        <div class="mt-auto pt-3 border-top">
                            <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-outline-danger w-100" Text="Volver Atrás" OnClick="btnCancelar_Click"/>
                        </div>

                    </div>
                </div>
            </div>
        </div>

        <%-- HISTORIAL DE ESTADOS --%>
        <div id="divHistorialPedido" runat="server" class="mt-5">
            <div class="card shadow-sm border-0">
                <div class="card-header bg-dark text-white p-3">
                    <h5 class="card-title mb-0 fw-semibold fs-6">Historial de Estados</h5>
                </div>
                <div class="card-body p-0">
                    <div class="table-responsive">
                        <asp:GridView ID="dgvHistorial" runat="server" AutoGenerateColumns="false" CssClass="table table-hover table-striped mb-0 align-middle">
                            <HeaderStyle CssClass="table-light text-secondary text-uppercase fs-7 border-bottom" />
                            <Columns>
                                <asp:BoundField HeaderText="Fecha de Cambio" DataField="FechaCambio" DataFormatString="{0:dd/MM/yyyy HH:mm}" ItemStyle-CssClass="ps-4" HeaderStyle-CssClass="ps-4" />
                                <asp:BoundField HeaderText="Estado" DataField="Estado.Descripcion" ItemStyle-CssClass="fw-semibold text-primary" /> 
                                <asp:BoundField HeaderText="Observaciones" DataField="Observaciones" NullDisplayText="Sin observaciones" ItemStyle-CssClass="text-muted italic" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>