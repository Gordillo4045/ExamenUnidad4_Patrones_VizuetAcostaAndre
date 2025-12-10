namespace ExamenUnidad4_Patrones_VizuetAcostaAndre.Negocio.Dominio.Estados
{
    public interface IEstadoPedido
    {
        string Nombre { get; }

        void Pagar(Pedido pedido);
        void Enviar(Pedido pedido);
        void Entregar(Pedido pedido);
        void Cancelar(Pedido pedido);
    }
}
