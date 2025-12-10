using System.Collections.Generic;
using System.Linq;
using ExamenUnidad4_Patrones_VizuetAcostaAndre.Negocio.Dominio;
using ExamenUnidad4_Patrones_VizuetAcostaAndre.Negocio.Servicios;

namespace ExamenUnidad4_Patrones_VizuetAcostaAndre.Datos
{
    public class InMemoryPedidoRepository : IPedidoRepository
    {
        private readonly List<Pedido> _pedidos = new();
        private int _nextId = 1;

        public void Guardar(Pedido pedido)
        {
            pedido.Id = _nextId++;
            _pedidos.Add(pedido);
        }

        public void Actualizar(Pedido pedido)
        {
            var index = _pedidos.FindIndex(p => p.Id == pedido.Id);
            if (index >= 0)
            {
                _pedidos[index] = pedido;
            }
        }

        public Pedido? BuscarPorId(int id)
        {
            return _pedidos.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Pedido> ObtenerTodos()
        {
            return _pedidos.ToList();
        }
    }
}
