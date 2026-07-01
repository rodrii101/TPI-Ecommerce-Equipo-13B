using dominioEcommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocioEcommerce
{
    public class PedidoNegocio
    {
        public void CrearPedido(Pedido nuevoPedido, List<PedidoDetalle> listaPedidoDetalle)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("storedCrearPedido");
                datos.setearParametro("@IdCliente", nuevoPedido.IdCliente);
                datos.setearParametro("@Nombre", nuevoPedido.PedidoConfirmado.Cliente.Nombre);
                datos.setearParametro("@Apellido", nuevoPedido.PedidoConfirmado.Cliente.Apellido);
                datos.setearParametro("@Telefono", nuevoPedido.PedidoConfirmado.Cliente.Telefono);
                datos.setearParametro("@Dni", nuevoPedido.PedidoConfirmado.Cliente.DNI);
                datos.setearParametro("@DescripcionFormasDeEntrega", nuevoPedido.PedidoConfirmado.FormaEntrega.Descripcion);
                datos.setearParametro("@Calle", nuevoPedido.PedidoConfirmado.DireccionEntrega.Calle != null ? nuevoPedido.PedidoConfirmado.DireccionEntrega.Calle : (object)DBNull.Value);
                datos.setearParametro("@Altura", nuevoPedido.PedidoConfirmado.DireccionEntrega.Altura != null ? nuevoPedido.PedidoConfirmado.DireccionEntrega.Altura : (object)DBNull.Value);
                datos.setearParametro("@Piso", nuevoPedido.PedidoConfirmado.DireccionEntrega.Piso != null ? nuevoPedido.PedidoConfirmado.DireccionEntrega.Piso : (object)DBNull.Value);
                datos.setearParametro("@Departamento", nuevoPedido.PedidoConfirmado.DireccionEntrega.Departamento != null ? nuevoPedido.PedidoConfirmado.DireccionEntrega.Departamento : (object)DBNull.Value);
                datos.setearParametro("@CodigoPostal", nuevoPedido.PedidoConfirmado.DireccionEntrega.CodigoPostal != null ? nuevoPedido.PedidoConfirmado.DireccionEntrega.CodigoPostal : (object)DBNull.Value);
                datos.setearParametro("@Localidad", nuevoPedido.PedidoConfirmado.DireccionEntrega.Localidad != null ? nuevoPedido.PedidoConfirmado.DireccionEntrega.Localidad : (object)DBNull.Value);
                datos.setearParametro("@DescripcionFormaDePago", nuevoPedido.PedidoConfirmado.FormaDePago.Descripcion);
                datos.setearParametro("@MontoTotal", nuevoPedido.PedidoConfirmado.MontoTotal);

                int idNuevoPedido = datos.ejecutarScalar();
                datos.cerrarConexion();


                foreach (PedidoDetalle pedidoDetalles in listaPedidoDetalle)
                {
                    AccesoDatos datoPedidos = new AccesoDatos();
                    datoPedidos.setearProcedimiento("storedCrearPedidoDetalle");
                    datoPedidos.setearParametro("@IdPedido", idNuevoPedido);
                    datoPedidos.setearParametro("@IdProducto", pedidoDetalles.IdProducto);
                    datoPedidos.setearParametro("@NombreProducto", pedidoDetalles.Producto.Nombre);
                    datoPedidos.setearParametro("@PrecioUnitario", pedidoDetalles.PrecioUnitario);
                    datoPedidos.setearParametro("@Cantidad", pedidoDetalles.Cantidad);
                    datoPedidos.setearParametro("@IdVendedor", pedidoDetalles.Producto.IdVendedor);
                    datoPedidos.setearParametro("@NombreVendedor", pedidoDetalles.NombreDelVendedor);
                    datoPedidos.ejecutarAccion();
                    datoPedidos.cerrarConexion();
                }
                AccesoDatos datosSeguimiento = new AccesoDatos();
                datosSeguimiento.setearProcedimiento("storedCrearEstadoSeguimientoPedido");
                datosSeguimiento.setearParametro("@IdPedido", idNuevoPedido);
                datosSeguimiento.setearParametro("@IdEstado", 1);
                datosSeguimiento.ejecutarAccion();
                datosSeguimiento.cerrarConexion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void DisminuirStockPorCompra(int IdProducto, int Cantidad)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("storedDisminuirStock");
                datos.setearParametro("@Cantidad", Cantidad);
                datos.setearParametro("@IdProducto", IdProducto);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public List<Pedido> BuscarPedidoDelUsuario(int IdUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Pedido> listaPedido = new List<Pedido>();
            try
            {
                datos.setearProcedimiento("BuscarPedidosUsuario");
                datos.setearParametro("@IdUsuario", IdUsuario);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Pedido aux = new Pedido();
                    aux.IdPedido = (int)datos.Lector["Id"];
                    aux.EstadoActual = new EstadoPedido();
                    aux.EstadoActual.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.FechaPedido = (DateTime)datos.Lector["Fecha"];
                    aux.PedidoConfirmado = new ConfirmarPedido();
                    aux.PedidoConfirmado.MontoTotal = (decimal)datos.Lector["MontoTotal"];
                    listaPedido.Add(aux);
                }
                return listaPedido;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }
        public List<PedidoDetalle> BuscarDetallePedido(int IdPedido)
        {
            AccesoDatos datos = new AccesoDatos();
            List<PedidoDetalle> listaPedidoDetalle = new List<PedidoDetalle>();
            try
            {
                datos.setearProcedimiento("VerDatosDetallePedido");
                datos.setearParametro("@IdPedido", IdPedido);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    PedidoDetalle aux = new PedidoDetalle();
                    aux.IdPedidoDetalle = (int)datos.Lector["IdPedidoDetalle"];
                    aux.Producto = new Producto();
                    aux.Producto.Nombre = (string)datos.Lector["NombreProducto"];
                    aux.PrecioUnitario = (Decimal)datos.Lector["PrecioUnitario"];
                    aux.Cantidad = (int)datos.Lector["Cantidad"];
                    aux.NombreDelVendedor = (string)datos.Lector["NombreVendedor"];
                    listaPedidoDetalle.Add(aux);
                }
                return listaPedidoDetalle;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }



        public List<Pedido> listarTodosLosPedidos()
        {
            List<Pedido> listaPedidos = new List<Pedido>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("storedListarPedidos");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Pedido auxPedido = new Pedido();
                    auxPedido.IdPedido = (int)datos.Lector["Id"];
                    auxPedido.EstadoActual = new EstadoPedido();
                    auxPedido.EstadoActual.Descripcion = (string)datos.Lector["EstadoDescripcion"];
                    auxPedido.FechaPedido = (DateTime)datos.Lector["Fecha"];
                    auxPedido.PedidoConfirmado = new ConfirmarPedido();
                    auxPedido.PedidoConfirmado.Cliente = new Usuario();
                    auxPedido.PedidoConfirmado.Cliente.Nombre = (string)datos.Lector["Nombre"];
                    auxPedido.PedidoConfirmado.Cliente.Apellido = (string)datos.Lector["Apellido"];
                    auxPedido.PedidoConfirmado.MontoTotal = (decimal)datos.Lector["MontoTotal"];
                    auxPedido.IdEstadoActual = (int)datos.Lector["IdEstadoActual"];
                    listaPedidos.Add(auxPedido);
                }
                return listaPedidos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }



        public Pedido buscarPedido(int idPedido)
        {
            Pedido auxPedido = new Pedido();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("storedTraerUnPedido");
                datos.setearParametro("@IdPedido", idPedido);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    auxPedido.IdPedido = (int)datos.Lector["Id"];
                    auxPedido.PedidoConfirmado = new ConfirmarPedido();
                    auxPedido.PedidoConfirmado.Cliente = new Usuario();
                    auxPedido.PedidoConfirmado.Cliente.Nombre = (string)datos.Lector["Nombre"];
                    auxPedido.PedidoConfirmado.Cliente.Apellido = (string)datos.Lector["Apellido"];
                    auxPedido.PedidoConfirmado.FormaEntrega = new FormasDeEntrega();
                    auxPedido.PedidoConfirmado.FormaEntrega.Descripcion = (string)datos.Lector["DescripcionFormasDeEntrega"];
                    auxPedido.PedidoConfirmado.FormaDePago = new FormasDePagos();
                    auxPedido.PedidoConfirmado.FormaDePago.Descripcion = (string)datos.Lector["DescripcionFormaDePago"];
                    auxPedido.EstadoActual = new EstadoPedido();
                    auxPedido.EstadoActual.Descripcion = (string)datos.Lector["EstadoDescripcion"];
                    auxPedido.FechaPedido = (DateTime)datos.Lector["Fecha"];
                    auxPedido.PedidoConfirmado.MontoTotal = (decimal)datos.Lector["MontoTotal"];
                }
                return auxPedido;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public List<Pedido> ListarPedidos(int IdUsuario, string Id = "")
        {
            List<Pedido> listaPedidos = new List<Pedido>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                if (Id != "")
                {
                    datos.setearProcedimiento("VerDatosCompletosPedidoUsuario");
                    datos.setearParametro("@IdUsuario", IdUsuario);
                    datos.setearParametro("@IdPedido", int.Parse(Id));

                }
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Pedido aux = new Pedido();
                    aux.IdPedido = (int)datos.Lector["IdPedido"];
                    aux.PedidoConfirmado = new ConfirmarPedido();
                    aux.PedidoConfirmado.Cliente = new Usuario();
                    aux.PedidoConfirmado.Cliente.Nombre = (string)datos.Lector["Nombre"];
                    aux.PedidoConfirmado.Cliente.Apellido = (string)datos.Lector["Apellido"];
                    aux.PedidoConfirmado.Cliente.Telefono = (string)datos.Lector["Telefono"];
                    aux.PedidoConfirmado.Cliente.DNI = (string)datos.Lector["Dni"];
                    aux.PedidoConfirmado.FormaEntrega = new FormasDeEntrega();
                    aux.PedidoConfirmado.FormaEntrega.Descripcion = (string)datos.Lector["DescripcionFormasDeEntrega"];
                    aux.PedidoConfirmado.FormaDePago = new FormasDePagos();
                    aux.PedidoConfirmado.FormaDePago.Descripcion = (string)datos.Lector["DescripcionFormaDePago"];
                    aux.PedidoConfirmado.DireccionEntrega = new DireccionUsuario();

                    if (!(datos.Lector["Calle"] is DBNull))
                        aux.PedidoConfirmado.DireccionEntrega.Calle = (string)datos.Lector["Calle"];

                    if (!(datos.Lector["Altura"] is DBNull))
                        aux.PedidoConfirmado.DireccionEntrega.Altura = (int)datos.Lector["Altura"];

                    if (!(datos.Lector["Piso"] is DBNull))
                        aux.PedidoConfirmado.DireccionEntrega.Piso = (string)datos.Lector["Piso"];

                    if (!(datos.Lector["Departamento"] is DBNull))
                        aux.PedidoConfirmado.DireccionEntrega.Departamento = (string)datos.Lector["Departamento"];

                    if (!(datos.Lector["CodigoPostal"] is DBNull))
                        aux.PedidoConfirmado.DireccionEntrega.CodigoPostal = (string)datos.Lector["CodigoPostal"];

                    if (!(datos.Lector["Localidad"] is DBNull))
                        aux.PedidoConfirmado.DireccionEntrega.Localidad = (string)datos.Lector["Localidad"];

                    aux.PedidoConfirmado.MontoTotal = (decimal)datos.Lector["MontoTotal"];
                    aux.EstadoActual = new EstadoPedido();
                    aux.EstadoActual.Descripcion = (string)datos.Lector["Descripcion"];
                    listaPedidos.Add(aux);
                }
                return listaPedidos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public List<PedidoDetalle> ReporteTopVendedores()
        {
            AccesoDatos datos = new AccesoDatos();
            List<PedidoDetalle> listaTopVendedores = new List<PedidoDetalle>();
            try
            {
                datos.setearProcedimiento("vista_TopVendedores");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    PedidoDetalle aux = new PedidoDetalle();
                    aux.Producto = new Producto();
                    aux.Producto.IdVendedor = (int)datos.Lector["IdVendedor"];
                    aux.NombreDelVendedor = (string)datos.Lector["NombreVendedor"];
                    aux.Cantidad = (int)datos.Lector["CantidadTotalVendida"];
                    aux.PrecioUnitario = (decimal)datos.Lector["TotalVendido"];
                    listaTopVendedores.Add(aux);
                }
                return listaTopVendedores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public List<PedidoDetalle> ReporteTopProductos()
        {
            AccesoDatos datos = new AccesoDatos();
            List<PedidoDetalle> listaTopProductos = new List<PedidoDetalle>();
            try
            {
                datos.setearProcedimiento("vista_TopProductos");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    PedidoDetalle aux = new PedidoDetalle();
                    aux.Producto = new Producto();
                    aux.Producto.Id = (int)datos.Lector["IdProducto"];
                    aux.Producto.Nombre = (string)datos.Lector["NombreProducto"];
                    aux.Producto.Marca = new Marca();
                    aux.Producto.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Producto.Categoria = new Categoria();
                    aux.Producto.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.Cantidad = (int)datos.Lector["CantidadVendida"];
                    listaTopProductos.Add(aux);
                }
                return listaTopProductos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public List<Pedido> ReporteTopPedidos()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Pedido> listaTopPedidos = new List<Pedido>();
            try
            {
                datos.setearProcedimiento("vista_TopPedidos");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Pedido aux = new Pedido();
                    aux.PedidoConfirmado = new ConfirmarPedido();
                    aux.PedidoConfirmado.Cliente = new Usuario();
                    aux.IdPedido = (int)datos.Lector["IdPedido"];
                    aux.PedidoConfirmado.Cliente.Nombre = (string)datos.Lector["Nombre"];
                    aux.PedidoConfirmado.Cliente.Apellido = (string)datos.Lector["Apellido"];
                    aux.PedidoConfirmado.MontoTotal = (decimal)datos.Lector["MontoTotal"];
                    listaTopPedidos.Add(aux);
                }
                return listaTopPedidos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
