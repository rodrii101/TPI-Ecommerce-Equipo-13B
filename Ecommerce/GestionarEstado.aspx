<%@ Page Title="" Language="C#" MasterPageFile="~/MasterCliente.Master" AutoEventWireup="true" CodeBehind="GestionarEstado.aspx.cs" Inherits="Ecommerce.GestionarEstado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="divDatosPedido" runat="server">
        <p><strong>Datos del Pedido:</strong></p>
        <ul class="list-unstyled mb-0">
            <li><strong>Id Pedido:</strong>
                <asp:Label ID="lblIdPedido" runat="server" Text="" /></li>
            <li><strong>Cliente:</strong>
                <asp:Label ID="lblCliente" runat="server" Text="" /></li>
            <li><strong>Fecha:</strong>
                <asp:Label ID="lblFecha" runat="server" Text="" /></li>
            <li><strong>Estado:</strong>
                <asp:Label ID="lblEstado" runat="server" Text="" /></li>
            <li><strong>Forma de entrega:</strong>
                <asp:Label ID="lblFormaDeEntrega" runat="server" Text="" /></li>
            <li><strong>Forma de pago:</strong>
                <asp:Label ID="lblFormaDePago" runat="server" Text="" /></li>
            <li><strong>Monto Total:</strong>
                <asp:Label ID="lblMontoTotal" runat="server" Text="" /></li>
        </ul>

        <%-- LISTA HISTORIAL PEDIDO --%>
        <div id="divHistorialPedido" runat="server" class="mt-4">
            <p><strong>Historial de Estados:</strong></p>

            <asp:GridView ID="dgvHistorial" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered">
                <Columns>
                    <asp:BoundField HeaderText="Fecha de Cambio" DataField="FechaCambio" DataFormatString="{0:dd/MM/yyyy HH:mm}" />
                    <asp:BoundField HeaderText="Estado" DataField="Estado.Descripcion" /> 
                    <asp:BoundField HeaderText="Observaciones" DataField="Observaciones" NullDisplayText="Sin observaciones" />
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <asp:Panel ID="panelResgistrarEstado" runat="server" Visible="false">
            <div>
                <asp:DropDownList ID="ddlEstados" runat="server" CssClass="form-control"></asp:DropDownList>
                <asp:TextBox ID="txtObservacion" runat="server" CssClass="form-control" TextMode="MultiLine" MaxLength="500" placeholder="Ingrese observaciones...." ></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="btnRegistrar" runat="server" CssClass="btn btn-success" Text="Registrar" OnClick="btnRegistrar_Click" />
            </div>
        </asp:Panel>

        <div>
            <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-danger" Text="Atras" OnClick="btnCancelar_Click"/>
            <asp:Button ID="btnRegistrarEstado" runat="server" CssClass="btn btn-primary" OnClick="btnRegistrarEstado_Click" Text="Registrar Nuevo Estado"/>

        </div>



    </div>
</asp:Content>
