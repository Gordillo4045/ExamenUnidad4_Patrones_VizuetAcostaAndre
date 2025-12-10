using System;
using System.Collections.Generic;
using System.Linq;
using ExamenUnidad4_Patrones_VizuetAcostaAndre.Negocio.Dominio;
using ExamenUnidad4_Patrones_VizuetAcostaAndre.Negocio.Fabricas;

namespace ExamenUnidad4_Patrones_VizuetAcostaAndre.Negocio.Servicios
{
    public class PedidoService
    {
        private readonly PedidoFactory _pedidoFactory;
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(PedidoFactory pedidoFactory, IPedidoRepository pedidoRepository)
        {
            _pedidoFactory = pedidoFactory;
            _pedidoRepository = pedidoRepository;
        }

        public Pedido CrearNuevoPedido(string clienteId, string direccion, decimal total, TipoEnvio tipoEnvio)
        {
            var pedido = _pedidoFactory.CrearPedido(clienteId, direccion, total, tipoEnvio);
            _pedidoRepository.Guardar(pedido);
            return pedido;
        }

        public void CambiarEstado(int pedidoId, EstadoPedidoAccion accion)
        {
            var pedido = _pedidoRepository.BuscarPorId(pedidoId);

            if (pedido == null)
            {
                throw new InvalidOperationException("Pedido no encontrado.");
            }

            switch (accion)
            {
                case EstadoPedidoAccion.Pagar:
                    pedido.Pagar();
                    break;
                case EstadoPedidoAccion.Enviar:
                    pedido.Enviar();
                    break;
                case EstadoPedidoAccion.Entregar:
                    pedido.Entregar();
                    break;
                case EstadoPedidoAccion.Cancelar:
                    pedido.Cancelar();
                    break;
            }

            _pedidoRepository.Actualizar(pedido);
        }

        public IEnumerable<Pedido> ObtenerPedidos()
        {
            return _pedidoRepository.ObtenerTodos();
        }

        public IEnumerable<Pedido> ObtenerPedidosActivos()
        {
            return _pedidoRepository.ObtenerTodos()
                .Where(p => p.Estado.Nombre != "Cancelado");
        }
    }
}
