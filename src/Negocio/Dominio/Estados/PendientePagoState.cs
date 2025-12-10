using System;

namespace ExamenUnidad4_Patrones_VizuetAcostaAndre.Negocio.Dominio.Estados
{
    public class PendientePagoState : IEstadoPedido
    {
        public string Nombre => "Pendiente de pago";

        public void Pagar(Pedido pedido)
        {
            pedido.CambiarEstado(new PagadoState());
        }

        public void Enviar(Pedido pedido)
        {
            throw new InvalidOperationException("No se puede enviar un pedido que no ha sido pagado.");
        }

        public void Entregar(Pedido pedido)
        {
            throw new InvalidOperationException("No se puede entregar un pedido que no ha sido enviado.");
        }

        public void Cancelar(Pedido pedido)
        {
            pedido.CambiarEstado(new CanceladoState());
        }
    }
}
