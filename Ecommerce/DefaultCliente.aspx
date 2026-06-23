<%@ Page Title="" Language="C#" MasterPageFile="~/MasterCliente.Master" AutoEventWireup="true" CodeBehind="DefaultCliente.aspx.cs" Inherits="Ecommerce.DefaultCliente" %>
<%@ Import Namespace="dominioEcommerce" %>  <%-- Agrego dominios --%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />

    <div id="carouselExampleIndicators" class="carousel slide">
        <div class="carousel-indicators">
            <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
            <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="1" aria-label="Slide 2"></button>
            <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="2" aria-label="Slide 3"></button>
        </div>
        <div class="carousel-inner">
            <div class="carousel-item active">
                <img src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTGxyWmnCOl2aZwQZOrI8SnJ302yBc46YK97g&s" class="d-block w-100" style="height: 300px;" alt="fotoCarrusel">
            </div>
            <div class="carousel-item">
                <img src="https://png.pngtree.com/background/20210714/original/pngtree-cyber-monday-super-sale-banner-background-picture-image_1222812.jpg" class="d-block w-100" style="height: 300px;" alt="fotoCarrusel">
            </div>
            <div class="carousel-item">
                <img src="https://www.shutterstock.com/image-vector/black-friday-sale-banner-modern-600nw-2538035933.jpg" class="d-block w-100" style="height: 300px;" alt="fotoCarrusel">
            </div>
        </div>
        <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Previous</span>
        </button>
        <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Next</span>
        </button>
    </div>
    <br />

    <div class="row justify-content-center">
        <asp:Repeater ID="rptRepeater" OnItemCommand="rptRepeater_ItemCommand" runat="server">
            <ItemTemplate>
                <div class="col-3">
                    <div class="card border border-secondary-subtle rounded shadow m-2" style="width: 20rem;">
                          
                        <img src="<%# ObtenerImagenPrincipal((Producto)Container.DataItem) %>" alt="<%#Eval("Nombre") %>" class="card-img-top" onerror="this.onerror=null; this.src='https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png'"/>
                        <div class="card-body">
                            <h2 class="card-title"><%#Eval("Nombre") %></h2>
                            <h3 class="card-title"><%#Eval("Precio") %></h3>
                        </div>
                        <asp:Button CssClass="btn btn-outline-info m-4" ID="btnAgregarAlCarrito" CommandArgument='<%# Eval("Id") %>' Text="Agregar al carrito" CommandName="AgregarAlCarrito" runat="server"/>
                        <%--<asp:Button ID="btnVerDetalleProducto" runat="server" OnClick="btnVerDetalleProducto_Click"/>--%>
                    </div>
                </div>

            </ItemTemplate>

        </asp:Repeater>
    </div>



    <%--<div class="row justify-content-center">
        <%foreach (dominioEcommerce.Producto producto in listaProducto)
            {
        %>
        <div class="col-3">
            <div class="card border border-secondary-subtle rounded shadow m-2" style="width: 20rem;">
                <img src="https://images.fravega.com/f500/2c7c1702016f66dee9351507ff774996.jpg">" class="card-img-top" alt="...">
                <div class="card-body">
                    <h3 class="card-title"><%: producto.Nombre %></h3>
                    <h6>$<%: producto.Precio %></h6>
                </div>
                <asp:Button CssClass="btn btn-outline-info m-4" Text="Agregar al carrito" runat="server" />
            </div>
            </div>
        <%  } %>

    </div>--%>
</asp:Content>
