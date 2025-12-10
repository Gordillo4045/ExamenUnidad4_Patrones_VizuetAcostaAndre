using System;

namespace ExamenUnidad4_Patrones_VizuetAcostaAndre.Negocio.Dominio.Estados
{
    public class EnviadoState : IEstadoPedido
    {
        public string Nombre => "Enviado";

        public void Pagar(Pedido pedido)
        {
        }

        public void Enviar(Pedido pedido)
        {
        }

        public void Entregar(Pedido pedido)
        {
            pedido.CambiarEstado(new EntregadoState());
        }

        public void Cancelar(Pedido pedido)
        {
            throw new InvalidOperationException("No se puede cancelar un pedido que ya fue enviado.");
        }
    }
}
