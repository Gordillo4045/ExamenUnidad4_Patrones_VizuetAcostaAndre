using System;
using System.IO;
using System.Collections.Generic;
using ExamenUnidad4_Patrones_VizuetAcostaAndre.Negocio.Dominio;

namespace ExamenUnidad4_Patrones_VizuetAcostaAndre.Negocio.Servicios
{
    public static class ExportacionTxt
    {
        private static readonly string RutaArchivo = "pedidos_exportados.txt";

        public static void Exportar(IEnumerable<Pedido> pedidos)
        {
            using (StreamWriter writer = new StreamWriter(RutaArchivo, append: false))
            {
                writer.WriteLine("=== LISTADO DE PEDIDOS ===");
                writer.WriteLine($"Fecha de exportación: {DateTime.Now}");
                writer.WriteLine("--------------------------------------------");

                foreach (var p in pedidos)
                {
                    writer.WriteLine($"ID: {p.Id}");
                    writer.WriteLine($"Cliente: {p.ClienteId}");
                    writer.WriteLine($"Dirección: {p.DireccionEntrega}");
                    writer.WriteLine($"Total: {p.Total:C}");
                    writer.WriteLine($"Tipo Envío: {p.TipoEnvio}");
                    writer.WriteLine($"Estado: {p.Estado.Nombre}");
                    writer.WriteLine("--------------------------------------------");
                }
            }
        }
    }
}
