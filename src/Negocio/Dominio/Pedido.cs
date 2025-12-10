using ExamenUnidad4_Patrones_VizuetAcostaAndre.Negocio.Dominio.Estados;

namespace ExamenUnidad4_Patrones_VizuetAcostaAndre.Negocio.Dominio
{
    public class Pedido
    {
        public int Id { get; set; }
        public string ClienteId { get; private set; }
        public string DireccionEntrega { get; private set; }
        public decimal Total { get; private set; }
        public TipoEnvio TipoEnvio { get; private set; }

        public IEstadoPedido Estado { get; private set; }

        public Pedido(string clienteId, string direccionEntrega, decimal total, TipoEnvio tipoEnvio)
        {
            ClienteId = clienteId;
            DireccionEntrega = direccionEntrega;
            Total = total;
            TipoEnvio = tipoEnvio;

            Estado = new PendientePagoState();
        }

        public void CambiarEstado(IEstadoPedido nuevoEstado)
        {
            Estado = nuevoEstado;
        }

        public void Pagar() => Estado.Pagar(this);
        public void Enviar() => Estado.Enviar(this);
        public void Entregar() => Estado.Entregar(this);
        public void Cancelar() => Estado.Cancelar(this);

        public override string ToString()
        {
            return $"[Id: {Id}] Cliente: {ClienteId} | Total: {Total:C} | Tipo envío: {TipoEnvio} | Estado: {Estado.Nombre}";
        }
    }
}
