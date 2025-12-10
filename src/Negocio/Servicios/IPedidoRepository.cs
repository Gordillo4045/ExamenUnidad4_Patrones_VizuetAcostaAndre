using System.Collections.Generic;
using ExamenUnidad4_Patrones_VizuetAcostaAndre.Negocio.Dominio;

namespace ExamenUnidad4_Patrones_VizuetAcostaAndre.Negocio.Servicios
{
    public interface IPedidoRepository
    {
        void Guardar(Pedido pedido);
        void Actualizar(Pedido pedido);
        Pedido? BuscarPorId(int id);
        IEnumerable<Pedido> ObtenerTodos();
    }
}
