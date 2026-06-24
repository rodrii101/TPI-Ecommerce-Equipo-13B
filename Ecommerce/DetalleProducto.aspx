<%@ Page Title="" Language="C#" MasterPageFile="~/MasterCliente.Master" AutoEventWireup="true" CodeBehind="DetalleProducto.aspx.cs" Inherits="Ecommerce.DetalleProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container m-4">
        <div class="row">
            <div class="col-7 mb-5 mt-5">
                <div id="carouselExample" class="carousel slide carousel-dark mb-3" data-bs-ride="carousel" clientidmode="Static">
                    <div class="carousel-inner">
                        <asp:Repeater ID="rptCarrusel" runat="server">
                            <ItemTemplate>
                                <div class='carousel-item <%# Container.ItemIndex == 0 ? "active" : "" %>' data-id='<%# Eval("Id") %>'>
                                    <img src='<%# Eval("ImagenUrl") %>' class="d-block w-100" style="max-height: 400px; object-fit: contain;" alt='Producto <%# Eval("IdProducto") %>' onerror="this.onerror=null; this.src='https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png'" />
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <button class="carousel-control-prev" type="button" data-bs-target="#carouselExample" data-bs-slide="prev">
                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Anterior</span>
                    </button>
                    <button class="carousel-control-next" type="button" data-bs-target="#carouselExample" data-bs-slide="next">
                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Siguiente</span>
                    </button>
                </div>
            </div>
            <div class="col-5 border rounded-3 p-6">
                <div class="m-3">
                    <h2><%=ProductoSeleccionado.Nombre %></h2>
                    <br />
                    <p class="fs-3">$<%= ProductoSeleccionado.Precio.ToString()%></p>
                    <hr />
                    <h3>Descripcion</h3>
                    <p class="fs-6"><%= ProductoSeleccionado.Descripcion %></p>
                    <hr />
                    <div class="d-flex justify-content-center">
                        <asp:Button ID="btnAgregarProductoEnDetalleProducto" OnClick="btnAgregarProductoEnDetalleProducto_Click" Text="Agregar al carrito" CssClass="btn btn-success w-75" runat="server" />
                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
