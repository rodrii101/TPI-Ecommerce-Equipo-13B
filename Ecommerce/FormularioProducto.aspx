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
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" MaxLength="55"/>
                <asp:RequiredFieldValidator ControlToValidate="txtNombre" runat="server" Display="Dynamic" ForeColor="Red" ErrorMessage="Debe completar este campo."></asp:RequiredFieldValidator>
            </div>
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripcion></label>
                <asp:TextBox runat="server" ID="txtDescripcion" TextMode="MultiLine" CssClass="form-control" MaxLength="150"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtPrecio" class="form-label">Precio</label>
                <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" placeholder="$"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="txtPrecio" runat="server" Display="Dynamic" ForeColor="Red" ErrorMessage="Debe completar este campo."></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ControlToValidate="txtPrecio" runat="server" Display="Dynamic" ValidationExpression="^\d{1,8}(,\d{1,2})?$" ForeColor="Red" ErrorMessage="Solo admite 8 numeros enteros y 2 decimales (ej: 1234,56)."></asp:RegularExpressionValidator>
            </div>
            <div>
                <label for="ddlCategoria" class="form-label">Categoria</label>
                <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="form-select"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="txtStock" class="form-label">Stock</label>
                <asp:TextBox runat="server" ID="txtStock" CssClass="form-control"></asp:TextBox>
                <asp:RegularExpressionValidator ControlToValidate="txtStock" runat="server" Display="Dynamic" ValidationExpression="^[0-9]+$" ForeColor="Red" ErrorMessage="Solo admite numeros enteros."></asp:RegularExpressionValidator>
            </div>
        </div>
        <%-- SECTOR IMAGENES--%>
        <div class="col-6">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="txtImagenUrl" class="form-label">Url Imagen [La primera imagen sera la principal. Puedes editarlo luego.]</label>
                        <asp:TextBox ID="txtImagenUrl" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    
                    <div class="col">
                         <div id="carouselExample" class="carousel slide carousel-dark mb-3" data-bs-ride="carousel" ClientIDMode="Static">
                              <div class="carousel-inner">
                                    <asp:Repeater ID="rptCarrusel" runat="server">
                                        <ItemTemplate>
                                            <div class='carousel-item <%# Container.ItemIndex == 0 ? "active" : "" %>' data-id='<%# Eval("id") %>'>
                                        
                                                <img src='<%# Eval("ImagenUrl") %>' class="d-block w-100" alt='Producto <%# Eval("idProducto") %>'onerror="this.onerror=null; this.src='https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png'">
            
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
                        <%-- ASP:HiddenField ES UTIL PARA OBTENER EL ID DE LA IMAGEN ACTUAL--%>
                        <asp:HiddenField ID="hfImagenActualId" runat="server" ClientIDMode="Static" />
                    </div>

                    <div class="col mb-3">
                        <asp:Button ID="btnEliminarImg" runat="server" CssClass="btn btn-danger" Text="Eliminar imagen" OnClick="btnEliminarImg_Click"/>
                        <asp:Button ID="btnElegirPrincipal" runat="server" CssClass="btn btn-danger" Text="Imagen Principal" OnClick="btnElegirPrincipal_Click"/>
                    </div>

                    <div>
                        <asp:Button ID="btnGuardarImg" runat="server" CssClass="btn btn-danger" Text="Guardar imagen" OnClick="btnGuardarImg_Click"/>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
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

    <%--SCRIP PARA OBETNER id DE LA IMAGEN ACUTAL--%>
    <script>
    document.addEventListener("DOMContentLoaded", function () {
        var myCarousel = document.getElementById('carouselExample');

        myCarousel.addEventListener('slid.bs.carousel', function (event) {
            // event.relatedTarget es el elemento '.carousel-item' que se acaba de activar
            var itemActivo = event.relatedTarget;
            
            // Obtenemos el valor del atributo data-id
            var idImagenActual = itemActivo.getAttribute('data-id');
            
            console.log("ID de la imagen actual en pantalla: " + idImagenActual);

            // OPCIONAL: Guardamos el ID en el HiddenField de ASP.NET
            var hiddenField = document.getElementById('hfImagenActualId');
            if (hiddenField) {
                hiddenField.value = idImagenActual;
            }
        });
    });
</script>
</asp:Content>
