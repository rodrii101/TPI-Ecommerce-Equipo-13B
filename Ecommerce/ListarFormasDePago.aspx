<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListarFormasDePago.aspx.cs" Inherits="Ecommerce.ListarFormasDePago" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container m-3">
        <p class="fs-1">Listado formas de pago</p>
        <div class="row">
            <div class="col">
                <asp:GridView runat="server" ID="dgvListadoFormasDePago" DataKeyNames="IdFormasDePago" OnSelectedIndexChanged="dgvListadoFormasDePago_SelectedIndexChanged" CssClass="table table-hover border border-dark" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField HeaderText="Id" DataField="IdFormasDePago" />
                        <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                        <asp:CheckBoxField HeaderText="Estado" DataField="Estado" />
                        <asp:CommandField ShowSelectButton="true" SelectText="Seleccionar" HeaderText="Accion" />
                    </Columns>
                </asp:GridView>
                <div>
                    <a class="btn btn-primary" href="/FormularioFormasDePago.aspx">Agregar</a>
                </div>
            </div>
        </div>
    </div>
    <br />
</asp:Content>
