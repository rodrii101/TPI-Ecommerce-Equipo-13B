<%@ Page Title="" Language="C#" MasterPageFile="~/MasterCliente.Master" AutoEventWireup="true" CodeBehind="Direccion.aspx.cs" Inherits="Ecommerce.Direccion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="mt-3">Perfil</h2>

    <div class="container mt-5 mb-5 d-flex">
        <div class="row w-100 d-flex justify-content-center">
            <ul class="col-3 m-3 nav flex-column">
                <li class="nav-item">
                    <a class="nav-link link-dark" href="/Perfil.aspx">Perfil</a>
                    <hr /> 
                </li>
                 
                <li class="nav-item">
                    <a class="nav-link link-dark" href="/Formulario">Direccion</a>
                    <hr /> 
                </li>
                <li class="nav-item">
                    <a class="nav-link link-dark" href="#">Historial pedidos</a>
                    <hr /> 
                </li>
                <li class="nav-item">
                    <a class="nav-link link-dark" href="#">Cerrar sesion</a>
                    <hr /> 
                </li>
            </ul>
            <%-- Caso que no haya una direccion --%>
            <div class="col-7  m-3 d-flex justify-content-center align-items-center border border-secondary-subtle rounded shadow text-center">
                <div class="m-3 p-2">
                    <p>En este momento no se encuentra ninguna direccion</p>
                    <a class="btn btn-success" href="/FormularioDireccion.aspx">Agregar una direccion</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
