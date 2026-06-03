<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListarCategorias.aspx.cs" Inherits="Ecommerce.ListarCategorias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p class="fs-1">LISTADO CATEGORIAS </p>

    <div class="row">
        <div class="col">
            <asp:GridView runat="server" ID="dgvListadoCategorias" OnSelectedIndexChanged="dgvListadoCategorias_SelectedIndexChanged" CssClass="table table-hover border border-dark" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField HeaderText="Id" DataField="IdCategoria" />
                    <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                    <asp:CommandField ShowSelectButton="true" SelectText="Seleccionar" HeaderText="Accion" />
                </Columns>
            </asp:GridView>
            <div>
                <a Class="btn btn-primary" href="/FormularioCategoria.aspx">Agregar</a>
                
            </div>
        </div>
    </div>
    <br />

</asp:Content>
