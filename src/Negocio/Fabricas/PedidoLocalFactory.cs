using ExamenUnidad4_Patrones_VizuetAcostaAndre.Negocio.Dominio;

namespace ExamenUnidad4_Patrones_VizuetAcostaAndre.Negocio.Fabricas
{
    public class PedidoLocalFactory : PedidoFactory
    {
        public override Pedido CrearPedido(string clienteId, string direccionEntrega, decimal total, TipoEnvio tipoEnvio)
        {
            return new Pedido(clienteId, direccionEntrega, total, tipoEnvio);
        }
    }
}
