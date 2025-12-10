using System;

namespace ExamenUnidad4_Patrones_VizuetAcostaAndre.Negocio.Dominio.Estados
{
    public class PagadoState : IEstadoPedido
    {
        public string Nombre => "Pagado";

        public void Pagar(Pedido pedido)
        {
        }

        public void Enviar(Pedido pedido)
        {
            pedido.CambiarEstado(new EnviadoState());
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
