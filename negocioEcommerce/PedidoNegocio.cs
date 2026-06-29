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
        public void CrearPedido(Pedido nuevoPedido, List<CarritoDetalle> listaPedidoDetalle)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("storedCrearPedido");
                datos.setearParametro("@IdCliente", nuevoPedido.PedidoConfirmado.Cliente.Id);
                datos.setearParametro("@Nombre", nuevoPedido.PedidoConfirmado.Cliente.Nombre);
                datos.setearParametro("@Apellido", nuevoPedido.PedidoConfirmado.Cliente.Apellido);
                datos.setearParametro("@Telefono", nuevoPedido.PedidoConfirmado.Cliente.Telefono);
                datos.setearParametro("@Dni", nuevoPedido.PedidoConfirmado.Cliente.DNI);
                datos.setearParametro("@DescripcionFormasDeEntrega", nuevoPedido.PedidoConfirmado.FormaEntrega.Descripcion);
                datos.setearParametro("@Calle", nuevoPedido.PedidoConfirmado.DireccionEntrega.Calle);
                datos.setearParametro("@Altura", nuevoPedido.PedidoConfirmado.DireccionEntrega.Altura);
                datos.setearParametro("@Piso", nuevoPedido.PedidoConfirmado.DireccionEntrega.Piso);
                datos.setearParametro("@Departamento", nuevoPedido.PedidoConfirmado.DireccionEntrega.Departamento);
                datos.setearParametro("@CodigoPostal", nuevoPedido.PedidoConfirmado.DireccionEntrega.CodigoPostal);
                datos.setearParametro("@Localidad", nuevoPedido.PedidoConfirmado.DireccionEntrega.Localidad);
                datos.setearParametro("@DescripcionFormaDePago", nuevoPedido.PedidoConfirmado.FormaDePago.Descripcion);
                datos.setearParametro("@MontoTotal", nuevoPedido.PedidoConfirmado.MontoTotal);

                int idNuevoPedido = datos.ejecutarScalar();
                datos.cerrarConexion();


                foreach (CarritoDetalle pedidoDetalles in listaPedidoDetalle)
                {
                    AccesoDatos datoPedidos = new AccesoDatos();
                    datoPedidos.setearProcedimiento("storedCrearPedidoDetalle");
                    datoPedidos.setearParametro("@IdPedido", idNuevoPedido);
                    datoPedidos.setearParametro("@IdProducto", pedidoDetalles.Producto.Id);
                    datoPedidos.setearParametro("@NombreProducto", pedidoDetalles.Producto.Nombre);
                    datoPedidos.setearParametro("@Preciounitario", pedidoDetalles.Producto.Precio);
                    datoPedidos.setearParametro("@Cantidad", pedidoDetalles.Cantidad);
                    datoPedidos.setearParametro("@IdVendedor", pedidoDetalles.Usuario.Id);
                    datoPedidos.setearParametro("@NombreVendedor", pedidoDetalles.Usuario.Nombre);
                    datoPedidos.ejecutarAccion();
                    datoPedidos.cerrarConexion();
                }
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
