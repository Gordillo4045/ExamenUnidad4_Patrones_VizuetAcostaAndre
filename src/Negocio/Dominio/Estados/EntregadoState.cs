using System;

namespace ExamenUnidad4_Patrones_VizuetAcostaAndre.Negocio.Dominio.Estados
{
    public class EntregadoState : IEstadoPedido
    {
        public string Nombre => "Entregado";

        public void Pagar(Pedido pedido)
        {
        }

        public void Enviar(Pedido pedido)
        {
        }

        public void Entregar(Pedido pedido)
        {
        }

        public void Cancelar(Pedido pedido)
        {
            throw new InvalidOperationException("No se puede cancelar un pedido que ya fue entregado.");
        }
    }
}
