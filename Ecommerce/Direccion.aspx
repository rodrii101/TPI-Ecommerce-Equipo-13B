<%@ Page Title="" Language="C#" MasterPageFile="~/MasterCliente.Master" AutoEventWireup="true" CodeBehind="Direccion.aspx.cs" Inherits="Ecommerce.Direccion" %>

<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="mt-3">Perfil</h2>

    <div class="container mt-5 mb-5">
        <div class="row">
            <ul class="col-3 m-3 me-5 nav flex-column">
                <li class="nav-item">
                    <a class="nav-link link-dark" href="/Perfil.aspx">Perfil</a>
                    <hr />
                </li>
                <li class="nav-item">
                    <a class="nav-link link-dark" href="/Direccion.aspx">Direccion</a>
                    <hr />
                </li>
                <li class="nav-item">
                    <a class="nav-link link-dark" href="/CompraDelUsuario.aspx  ">Historial pedidos</a>
                    <hr />
                </li>
                <li class="nav-item">
                    <a class="nav-link link-dark" href="#">Cerrar sesion</a>
                    <hr />
                </li>
            </ul>
            <main class="col-8">
                <%-- Caso que no haya una direccion --%>
                <%if (listaDirecciones.Count > 0)
                    {
                %>
                <div class="row">
                    <asp:Repeater ID="repRepetidorDomicilios" runat="server">
                        <ItemTemplate>
                            <article class="col-4 p-3 m-1 border border-secondary-subtle rounded shadow">
                                <div>
                                    <span><%# Eval("Calle") %> <%#Eval("Altura") %></span>
                                    <br />
                                    <span><%# Eval("CodigoPostal") %> </span>
                                    <br />
                                    <span><%# Eval("Localidad") %> </span>
                                </div>
                                <a href="/FormularioDireccion.aspx?Id=<%# Eval("Id")%>">Editar</a>
                            </article>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="d-flex justify-content-start mt-2">
                    <a class="btn btn-success" href="/FormularioDireccion.aspx">Agregar una direccion</a>
                </div>
                <%}
                    else
                    {  %>
                <div class="col-7  m-3 d-flex justify-content-center align-items-center border border-secondary-subtle rounded shadow text-center">
                    <div class="m-3 p-2">
                        <p>En este momento no se encuentra ninguna direccion</p>
                        <a class="btn btn-success" href="/FormularioDireccion.aspx">Agregar una direccion</a>
                    </div>
                </div>
                <%} %>
            </main>
        </div>
    </div>
</asp:Content>
