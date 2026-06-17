<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DetalleProducto.aspx.cs" Inherits="Ecommerce.DetalleProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container m-4">
        <div class="row">
            <div class="col-7">
                <div id="carouselExampleIndicators" class="carousel slide">
                    <div class="carousel-indicators">
                        <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
                        <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="1" aria-label="Slide 2"></button>
                        <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="2" aria-label="Slide 3"></button>
                    </div>
                    <div class="carousel-inner">
                        <div class="carousel-item active">
                            <img src="https://images.fravega.com/f500/af3e20d4d8108a3030b5abb6399782c6.jpg" class="d-block img-fluid mx-auto" style="max-height: 400px;" alt="...">
                        </div>
                        <div class="carousel-item">
                            <img src="https://i02.appmifile.com/mi-com-product/fly-birds/xiaomi-14t/M/1015.jpg" class="d-block img-fluid mx-auto" style="max-height: 400px;" alt="...">
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
            </div>
            <div class="col-5 border rounded-3 p-6">
                <div class ="m-3">
                    <h2>Nombre del producto</h2>
                    <br />
                    <p class="fs-3">$11111111</p>
                    <hr />
                    <h3>Descripcion</h3>
                    <p class="fs-6">Aca va la descripcion del producto</p>
                    <hr />
                    <div class="d-flex justify-content-center">
                    <asp:Button Text="Agregar al carrito" CssClass="btn btn-success w-75" runat="server" />
                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
