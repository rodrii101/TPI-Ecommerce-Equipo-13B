<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListarProductos.aspx.cs" Inherits="Ecommerce.ListarProductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>LISTADO DE PRODUCTOS</h1>

    <div class="row mb-3">
        <asp:GridView ID="dgvListaProductos" runat="server" DataKeyNames="Id" 
            CssClass="table table-bordered table-striped shadow-sm" 
            Style="text-align: center;"  AutoGenerateColumns="false"
            OnSelectedIndexChanged="dgvListaProductos_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="Id" DataField="Id" />
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                <asp:BoundField HeaderText="Precio" DataField="Precio" />
                <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
                <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                <asp:BoundField HeaderText="TipoVendedor" DataField="IdVendedor" />
                <asp:CheckBoxField HeaderText="Estado" DataField="Estado" />
                <asp:BoundField HeaderText="Stock" DataField="Stock" />
                <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="📝" />
            </Columns>
        </asp:GridView> 

        <div>
            <a class="btn btn-primary" href="/FormularioProducto.aspx">➕ Agregar Producto</a>
        </div>
    </div>

</asp:Content>
