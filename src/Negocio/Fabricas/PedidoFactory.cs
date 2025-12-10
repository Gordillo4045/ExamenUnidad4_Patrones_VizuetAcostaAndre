using ExamenUnidad4_Patrones_VizuetAcostaAndre.Negocio.Dominio;

namespace ExamenUnidad4_Patrones_VizuetAcostaAndre.Negocio.Fabricas
{
    public abstract class PedidoFactory
    {
        public abstract Pedido CrearPedido(
            string clienteId,
            string direccionEntrega,
            decimal total,
            TipoEnvio tipoEnvio
        );
    }
}
