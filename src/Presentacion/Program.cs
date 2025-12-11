using System;
using ExamenUnidad4_Patrones_VizuetAcostaAndre.Datos;
using ExamenUnidad4_Patrones_VizuetAcostaAndre.Negocio.Dominio;
using ExamenUnidad4_Patrones_VizuetAcostaAndre.Negocio.Fabricas;
using ExamenUnidad4_Patrones_VizuetAcostaAndre.Negocio.Servicios;

namespace ExamenUnidad4_Patrones_VizuetAcostaAndre.Presentacion
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var pedidoRepository = new InMemoryPedidoRepository();

            PedidoFactory pedidoFactory = new PedidoLocalFactory();

            var pedidoService = new PedidoService(pedidoFactory, pedidoRepository);
            var envioService = new EnvioService();

            var facade = new LogisticaFacade(pedidoService, envioService);

            EjecutarMenu(facade);
        }

        private static void EjecutarMenu(LogisticaFacade facade)
        {
            string opcion;
            do
            {
                Console.WriteLine("=======================================");
                Console.WriteLine("  Gestión de Entregas de Comercio Electrónico");
                Console.WriteLine("=======================================");
                Console.WriteLine("1. Crear nuevo pedido");
                Console.WriteLine("2. Pagar pedido");
                Console.WriteLine("3. Enviar pedido");
                Console.WriteLine("4. Entregar pedido");
                Console.WriteLine("5. Cancelar pedido");
                Console.WriteLine("6. Listar pedidos");
                Console.WriteLine("7. Exportar pedidos a TXT");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = Console.ReadLine() ?? "";

                try
                {
                    switch (opcion)
                    {
                        case "1":
                            CrearPedido(facade);
                            break;
                        case "2":
                            CambiarEstado(facade, EstadoPedidoAccion.Pagar);
                            break;
                        case "3":
                            CambiarEstado(facade, EstadoPedidoAccion.Enviar);
                            break;
                        case "4":
                            CambiarEstado(facade, EstadoPedidoAccion.Entregar);
                            break;
                        case "5":
                            CambiarEstado(facade, EstadoPedidoAccion.Cancelar);
                            break;
                        case "6":
                            ListarPedidos(facade);
                            break;
                        case "7":
                            facade.ExportarPedidos();
                            Console.WriteLine("\nArchivo generado: pedidos_exportados.txt");
                            break;
                        case "0":
                            Console.WriteLine("Saliendo...");
                            break;
                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[ERROR] {ex.Message}");
                }

                if (opcion != "0")
                {
                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }

            } while (opcion != "0");
        }

        private static void CrearPedido(LogisticaFacade facade)
        {
            Console.Write("Id del cliente: ");
            var clienteId = Console.ReadLine() ?? "";

            Console.Write("Dirección de entrega: ");
            var direccion = Console.ReadLine() ?? "";

            Console.Write("Total del pedido: ");
            var totalTexto = Console.ReadLine();
            decimal total = decimal.TryParse(totalTexto, out var t) ? t : 0m;

            Console.WriteLine("\nTipo de envío:");
            Console.WriteLine("1. Local");
            Console.WriteLine("2. Nacional");
            Console.WriteLine("3. Internacional");
            Console.WriteLine("4. Express");
            Console.Write("Seleccione tipo de envío: ");
            var tipoTexto = Console.ReadLine();

            int tipoNumero = int.TryParse(tipoTexto, out var tempTipo) ? tempTipo : 1;
            var tipoEnvio = (TipoEnvio)tipoNumero;

            var pedido = facade.CrearPedidoConEnvio(clienteId, direccion, total, tipoEnvio);

            Console.WriteLine("\nPedido creado correctamente:");
            Console.WriteLine(pedido);
        }

        private static void CambiarEstado(LogisticaFacade facade, EstadoPedidoAccion accion)
        {
            Console.Write("Id del pedido: ");
            var idTexto = Console.ReadLine();
            int id = int.TryParse(idTexto, out var tempId) ? tempId : 0;

            facade.CambiarEstadoPedido(id, accion);
            Console.WriteLine("Estado del pedido actualizado correctamente.");
        }

        private static void ListarPedidos(LogisticaFacade facade)
        {
            var pedidos = facade.ListarPedidos();

            Console.WriteLine("\nListado de pedidos:");
            foreach (var p in pedidos)
            {
                Console.WriteLine(p);
            }
        }
    }
}
