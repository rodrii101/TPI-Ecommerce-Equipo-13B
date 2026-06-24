<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListarEstadoPedido.aspx.cs" Inherits="Ecommerce.ListarEstadoPedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container m-3">
     <p class="fs-1">Listado Estado pedidos</p>
     <div class="row">
         <div class="col">
             <asp:GridView runat="server" ID="dgvListadoEstadoPedido" DataKeyNames="IdEstadoPedido" OnSelectedIndexChanged="dgvListadoEstadoPedido_SelectedIndexChanged" CssClass="table table-hover border border-dark" AutoGenerateColumns="false">
                 <Columns>
                     <asp:BoundField HeaderText="Id" DataField="IdEstadoPedido" />
                     <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                     <asp:CheckBoxField HeaderText="Estado" DataField="Estado" />
                     <asp:CommandField ShowSelectButton="true" SelectText="Seleccionar" HeaderText="Accion" />
                 </Columns>
             </asp:GridView>
             <div>
                 <a class="btn btn-primary" href="/FormularioEstadoPedido.aspx">Agregar</a>
             </div>
         </div>
     </div>
 </div>
 <br />
</asp:Content>
