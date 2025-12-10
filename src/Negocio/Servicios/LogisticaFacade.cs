using System.Collections.Generic;
using ExamenUnidad4_Patrones_VizuetAcostaAndre.Negocio.Dominio;

namespace ExamenUnidad4_Patrones_VizuetAcostaAndre.Negocio.Servicios
{
    public class LogisticaFacade
    {
        private readonly PedidoService _pedidoService;
        private readonly EnvioService _envioService;

        public LogisticaFacade(PedidoService pedidoService, EnvioService envioService)
        {
            _pedidoService = pedidoService;
            _envioService = envioService;
        }

        public Pedido CrearPedidoConEnvio(string clienteId, string direccion, decimal total, TipoEnvio tipoEnvio)
        {
            var pedido = _pedidoService.CrearNuevoPedido(clienteId, direccion, total, tipoEnvio);
            _envioService.GenerarGuiaEnvio(pedido);
            return pedido;
        }

        public void CambiarEstadoPedido(int pedidoId, EstadoPedidoAccion accion)
        {
            _pedidoService.CambiarEstado(pedidoId, accion);
        }

        public IEnumerable<Pedido> ListarPedidos()
        {
            return _pedidoService.ObtenerPedidos();
        }

        public IEnumerable<Pedido> ListarPedidosActivos()
        {
            return _pedidoService.ObtenerPedidosActivos();
        }

        public void ExportarPedidos()
        {
            var pedidos = _pedidoService.ObtenerPedidos();
            ExportacionTxt.Exportar(pedidos);
        }
    }
}
