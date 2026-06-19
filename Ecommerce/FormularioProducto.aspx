<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioProducto.aspx.cs" Inherits="Ecommerce.FormularioProducto" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    
    <h1 class="mb-4">FORMULARIO PRODUCTO</h1>

    <div class="row">
        
        <div class="col-md-6">
            <div class="mb-3">
                <asp:label ID="lblId" runat="server" class="form-label fw-bold">ID</asp:label>
                <asp:TextBox ID="txtId" runat="server" CssClass="form-control border border-dark"/>
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label fw-bold">Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control border border-dark" MaxLength="55"/>
                <asp:RequiredFieldValidator ControlToValidate="txtNombre" runat="server" Display="Dynamic" ForeColor="Red" ErrorMessage="Debe completar este campo."></asp:RequiredFieldValidator>
            </div>
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label fw-bold">Descripcion</label>
                <asp:TextBox runat="server" ID="txtDescripcion" TextMode="MultiLine" Rows="2" CssClass="form-control border border-dark" MaxLength="150"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="ddlCategoria" class="form-label fw-bold">Categoria</label>
                <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="form-select border border-dark"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="txtPrecio" class="form-label fw-bold">Precio</label>
                <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control border border-dark" placeholder="$"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="txtPrecio" runat="server" Display="Dynamic" ForeColor="Red" ErrorMessage="Debe completar este campo."></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ControlToValidate="txtPrecio" runat="server" Display="Dynamic" ValidationExpression="^\d{1,8}(,\d{1,2})?$" ForeColor="Red" ErrorMessage="Solo admite 8 numeros enteros y 2 decimales (ej: 1234,56)."></asp:RegularExpressionValidator>
            </div>
            <div class="mb-3">
                <label for="txtStock" class="form-label fw-bold">Stock</label>
                <asp:TextBox runat="server" ID="txtStock" CssClass="form-control border border-dark"></asp:TextBox>
                <asp:RegularExpressionValidator ControlToValidate="txtStock" runat="server" Display="Dynamic" ValidationExpression="^[0-9]+$" ForeColor="Red" ErrorMessage="Solo admite numeros enteros."></asp:RegularExpressionValidator>
            </div>

            <div class="mt-4">
                <asp:Button runat="server" ID="btnAgregarProducto" CssClass="btn btn-primary me-2 px-4" Text="Agregar" OnClick="btnAgregarProducto_Click"/>
                <asp:Button runat="server" ID="btnCancelar" CssClass="btn btn-danger me-2 px-4" Text="Cancelar" OnClick="btnCancelar_Click"/>
            </div>
        </div>

        <div class="col-md-6">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="txtImagenUrl" class="form-label fw-bold">Url Imagen</label>
                        <asp:TextBox ID="txtImagenUrl" runat="server" CssClass="form-control border border-dark"></asp:TextBox>
                    </div>
                    
                    <div class="p-2 border border-info border-3 rounded mb-3" style="min-height: 250px; background-color: #f8f9fa;">
                        <p class="text-muted small text-center mb-1">Carrusel de Imagenes</p>

                        <%if (Request.QueryString["id"] != null)
                        {%>
                             <div id="carouselExample" class="carousel slide carousel-dark mb-3" data-bs-ride="carousel" ClientIDMode="Static">
                                  <div class="carousel-inner">
                                        <asp:Repeater ID="rptCarrusel" runat="server" OnItemCommand="rptCarrusel_ItemCommand">
                                            <ItemTemplate>
                                                <div class='carousel-item <%# Container.ItemIndex == 0 ? "active" : "" %>' data-id='<%# Eval("Id") %>'>
                                                    <img src='<%# Eval("ImagenUrl") %>' class="d-block w-100" style="max-height: 250px; object-fit: contain;" alt='Producto <%# Eval("IdProducto") %>' onerror="this.onerror=null; this.src='https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png'" />
                                                    <div class="text-center mt-2">
                                                        <asp:Button ID="btnEstablecerPrincipal" runat="server" 
                                                            Text="Elegir como Principal" 
                                                            CommandName="EstablecerPrincipal" 
                                                            CommandArgument='<%# Eval("Id") %>' 
                                                            CssClass="btn btn-success btn-sm" />
                                                    </div>
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
                        <%}
                        else
                        {%>
                             <div id="carouselExampleNuevo" class="carousel slide carousel-dark mb-3" data-bs-ride="carousel" ClientIDMode="Static">
                                  <div class="carousel-inner">
                                        <asp:Repeater ID="rptCarrusel2" runat="server" OnItemDataBound="rptCarrusel2_ItemDataBound" OnItemCommand="rptCarrusel2_ItemCommand">
                                            <ItemTemplate>
                                                <div class='carousel-item <%# Container.ItemIndex == 0 ? "active" : "" %>'>
                                                    <img src='<%# Eval("ImagenUrl") %>' class="d-block w-100" style="max-height: 250px; object-fit: contain;" alt='Producto <%# Eval("idProducto") %>' onerror="this.onerror=null; this.src='https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png'">
                                                    <asp:Button ID="btnEliminarItem" runat="server" 
                                                        Text="Eliminar esta imagen" 
                                                        CommandName="EliminarImagen"
                                                        CssClass="btn btn-danger mt-2" />
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                  </div>
                                  <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleNuevo" data-bs-slide="prev">
                                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                        <span class="visually-hidden">Anterior</span>
                                  </button>
                                  <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleNuevo" data-bs-slide="next">
                                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                        <span class="visually-hidden">Siguiente</span>
                                  </button>
                            </div>
                        <%}%>

                        <asp:HiddenField ID="hfImagenActualId" runat="server" ClientIDMode="Static" />
                    </div>

                    <div class="d-flex gap-2 mb-3">
                        <asp:Button ID="btnGuardarImg" runat="server" CssClass="btn btn-primary" Text="Guardar imagen" OnClick="btnGuardarImg_Click"/>
                        <asp:Button ID="btnEliminarImg" runat="server" CssClass="btn text-white" Style="background-color: #ff7f27;" Text="Borrar img" OnClick="btnEliminarImg_Click"/>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

    <div class="row mt-3">
        <div class="col-md-6">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <asp:Button ID="btnEliminar" runat="server" CssClass="btn text-white" Style="background-color: #ff7f27;" Text="borrar producto" OnClick="btnEliminar_Click" />
                        <asp:Button ID="btnDesactivar" runat="server" CssClass="btn btn-warning ms-2" Text="Desactivar" OnClick="btnDesactivar_Click"/>
                    </div>
                    <%if (confirmarEliminacion)
                    {%>
                        <div class="mb-3 alert alert-danger p-2">
                            <asp:Button ID="btnConfirmarEliminacion" runat="server" CssClass="btn btn-danger" Text="Confirmar Eliminacion" OnClick="btnConfirmarEliminacion_Click" />
                        </div>
                    <%} %>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

    <%-- SCRIPT PARA OBTENER EL ID DE LA IMAGEN ACTUAL --%>
    <script>
        function inicializarCarrusel() {
            var hiddenField = document.getElementById('hfImagenActualId');
            var carrusel = document.getElementById('carouselExample') || document.getElementById('carouselExampleNuevo');
            if (!carrusel || !hiddenField) return;

            function actualizarHiddenField() {
                var itemActivo = carrusel.querySelector('.carousel-item.active');
                if (itemActivo) {
                    var id = itemActivo.getAttribute('data-id');
                    if (id) {
                        hiddenField.value = id;
                        console.log("Hidden field actualizado: " + id);
                    }
                }
            }

            carrusel.removeEventListener('slid.bs.carousel', actualizarHiddenField);
            carrusel.addEventListener('slid.bs.carousel', actualizarHiddenField);

            actualizarHiddenField();
        }

        Sys.Application.add_load(inicializarCarrusel);
    </script>
</asp:Content>