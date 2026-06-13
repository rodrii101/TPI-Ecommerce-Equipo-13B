<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioProducto.aspx.cs" Inherits="Ecommerce.FormularioProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager> <%--ESTO ES PARA EL UP PANEL--%>
    <h1>FORMULARIO PRODUCTO</h1>

    <div class="row-3">
        <div class="col-3">
            <div class="mb-3">
                <asp:label ID="lblId" runat="server" class="form-label">ID</asp:label>
                <asp:TextBox ID="txtId" runat="server" CssClass="form-control"/>
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"/>
            </div>
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripcion></label>
                <asp:TextBox runat="server" ID="txtDescripcion" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-e">
                <label for="txtPrecio" class="form-label">Precio</label>
                <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" placeholder="$"></asp:TextBox>
            </div>
            <div>
                <label for="ddlCategoria" class="form-label">Categoria</label>
                <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="form-select"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="txtStock" class="form-label">Stock</label>
                <asp:TextBox runat="server" ID="txtStock" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="mb-3">
            <asp:Button runat="server" ID="btnAgregarProducto" CssClass="btn btn-primary" Text="Agregar" OnClick="btnAgregarProducto_Click"/>
        </div>
    </div>
    <div class="row">
        <div class="col-6">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <asp:Button ID="btnEliminar" runat="server" CssClass="btn btn-danger" Text="Eliminar" OnClick="btnEliminar_Click" />
                        <asp:Button ID="btnDesactivar" runat="server" CssClass="btn btn-warning" Text="Desactivar" OnClick="btnDesactivar_Click"/>
                    </div>
                    <%if (confirmarEliminacion)
                    {%>
                        <div class="mb-3">
                            <asp:Button ID="btnConfirmarEliminacion" runat="server" CssClass="btn-danger" Text="Confirmar Eliminacion" OnClick="btnConfirmarEliminacion_Click" />
                        </div>
                    <%} %>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

</asp:Content>
