using ExamenUnidad4_Patrones_VizuetAcostaAndre.Negocio.Dominio;

namespace ExamenUnidad4_Patrones_VizuetAcostaAndre.Negocio.Fabricas
{
    public class PedidoExpressFactory : PedidoFactory
    {
        public override Pedido CrearPedido(string clienteId, string direccionEntrega, decimal total, TipoEnvio tipoEnvio)
        {
            decimal totalConRecargo = total * 1.10m;
            return new Pedido(clienteId, direccionEntrega, totalConRecargo, tipoEnvio);
        }
    }
}
