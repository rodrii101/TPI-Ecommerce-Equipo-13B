<%@ Page Title="" Language="C#" MasterPageFile="~/MasterCliente.Master" AutoEventWireup="true" CodeBehind="ListarMarcas.aspx.cs" Inherits="Ecommerce.ListarMarcas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <div class="container mb-5 mt-5">
        <p class="fs-1">Listado de Marcas </p>
        <div class="row">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="col-3 mb-3">
                        <asp:Label Text="Filtrado por descripcion" runat="server" />
                        <asp:TextBox ID="txtFiltroRapidoMarca" CssClass="form-control mt-2" OnTextChanged="txtFiltroRapidoMarca_TextChanged" AutoPostBack="true" runat="server" />
                    </div>
                    <div class="col-3 aling-items-center">
                        <div class="mb-3 d-flex">
                            <asp:CheckBox Text="Filtro avanzado" CssClass="me-3" ID="chkFiltroAvanzadoMarca" OnCheckedChanged="chkFiltroAvanzadoMarca_CheckedChanged" AutoPostBack="true" runat="server" />
                              <asp:Button Text="Limpiar filtro" CssClass="btn btn-primary mb-3" ID="btnLimpiarFiltro" OnClick="btnLimpiarFiltro_Click"   runat="server" />
                        </div>
                    </div>
                    <asp:Panel ID="PanelFiltroAvanzado" runat="server" Visible="false">
                        <div class="row">
                            <div class="col-3">
                                <div class="mb-3">
                                    <asp:Label Text="Campo" runat="server" />
                                    <asp:TextBox ID="txtCampoMarca" Text="Descripcion" CssClass="form-control" runat="server" /> 
                                </div>
                            </div>
                            <div class="col-3">
                                <div class="mb-3">
                                    <asp:Label Text="Criterio" runat="server" />
                                    <asp:DropDownList ID="ddlCriterioMarca" CssClass="form-control" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-3">
                                <div class="mb-3">
                                    <asp:Label Text="Filtro" runat="server" />
                                    <asp:TextBox ID="txtFiltroAvanzado" CssClass="form-control" runat="server" />
                                </div>
                            </div>
                            <div class="col-3">
                                <div class="mb-3">
                                    <asp:Label Text="Estado" runat="server" />
                                    <asp:DropDownList ID="ddlEstadoMarca" CssClass="form-control" runat="server">
                                        <asp:ListItem Text="Todos" />
                                        <asp:ListItem Text="Activo" />
                                        <asp:ListItem Text="Inactivo" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <asp:Button Text="Buscar marca" CssClass="btn btn-primary mb-3 me-4" ID="btnBuscarFiltroAvanzado" OnClick="btnBuscarFiltroAvanzado_Click" runat="server" />
                      
                    </asp:Panel>


                    <asp:Panel ID="PanelConMarca" runat="server" Visible="false">
                        <asp:GridView runat="server" ID="dgvListadoMarcas" DataKeyNames="IdMarca" OnSelectedIndexChanged="dgvListadoMarcas_SelectedIndexChanged" CssClass="table table-bordered table-striped shadow-sm text-center" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" OnPageIndexChanging="dgvListadoMarcas_PageIndexChanging">
                            <Columns>
                                <asp:BoundField HeaderText="Id" DataField="IdMarca" />
                                <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                                <asp:CheckBoxField HeaderText="Estado" DataField="Estado" />
                                <asp:CommandField ShowSelectButton="true" SelectText="📝" HeaderText="Accion" />
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                    <asp:Panel ID="PanelSinMarca" CssClass="d-flex justify-content-center align-items-center " runat="server" Visible="false">
                        <div class="col-5  m-3 border border-secondary-subtle rounded shadow text-center">
                            <div class="m-3 p-2">
                                <p>No se encontro ninguna Marca</p>
                            </div>
                        </div>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="col">
                <div>
                    <a class="btn btn-primary" href="/FormularioMarca.aspx">Agregar</a>
                </div>
            </div>
        </div>
    </div>
    <br />
</asp:Content>
