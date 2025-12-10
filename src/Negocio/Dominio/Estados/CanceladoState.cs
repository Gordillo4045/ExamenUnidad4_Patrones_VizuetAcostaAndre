using System;

namespace ExamenUnidad4_Patrones_VizuetAcostaAndre.Negocio.Dominio.Estados
{
    public class CanceladoState : IEstadoPedido
    {
        public string Nombre => "Cancelado";

        public void Pagar(Pedido pedido)
        {
            throw new InvalidOperationException("No se puede pagar un pedido cancelado.");
        }

        public void Enviar(Pedido pedido)
        {
            throw new InvalidOperationException("No se puede enviar un pedido cancelado.");
        }

        public void Entregar(Pedido pedido)
        {
            throw new InvalidOperationException("No se puede entregar un pedido cancelado.");
        }

        public void Cancelar(Pedido pedido)
        {
        }
    }
}
