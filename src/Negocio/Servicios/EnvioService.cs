using System;
using ExamenUnidad4_Patrones_VizuetAcostaAndre.Negocio.Dominio;

namespace ExamenUnidad4_Patrones_VizuetAcostaAndre.Negocio.Servicios
{
    public class EnvioService
    {
        public void GenerarGuiaEnvio(Pedido pedido)
        {
            Console.WriteLine($"[ENVÍO] Se generó la guía para el pedido {pedido.Id} ({pedido.TipoEnvio}).");
        }
    }
}
