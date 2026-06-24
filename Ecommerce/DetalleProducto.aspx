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

            <div class="col-5 border rounded-3 p-3">
                <div class="m-3">
                    <img src="<%= ProductoSeleccionado.Marca.UrlImagen %>" class="w-25 h-25" alt="Marca <%= ProductoSeleccionado.Marca.Descripcion%>" />
                    <h2><%=ProductoSeleccionado.Nombre %></h2>
                    <br />
                    <div class="mb-4">
                        <h3>$<%= ProductoSeleccionado.Precio%></h3>
                        <p class="fs-6 text-muted">Precio s/imp. nac $<%= (ProductoSeleccionado.Precio*79)/100 %></p>
                    </div>
                    <hr />
                    <h2>Descripcion</h2>
                    <p class="fs-6"><%= ProductoSeleccionado.Descripcion %></p>
                    <hr />
                    <div class="mb-4">
                        <p class="text-muted">Stock disponible <%= ProductoSeleccionado.Stock %></p>
                    </div>
                    <div class="d-flex justify-content-center">
                        <asp:Button Text="Comprar" ID="btnComprarAhora" OnClick="btnComprarAhora_Click" CssClass="btn btn-success w-100 m-2" runat="server" />
                        <asp:Button ID="btnAgregarProductoEnDetalleProducto" OnClick="btnAgregarProductoEnDetalleProducto_Click" Text="Agregar al carrito" CssClass="btn btn-success w-100 m-2" runat="server" />
                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
