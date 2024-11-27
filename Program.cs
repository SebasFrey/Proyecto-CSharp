using System;
using System.IO;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continuar = true;

            while (continuar)
            {
                MostrarMenu();

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        RegistrarDatos();
                        break;
                    case "2":
                        MostrarRegistros();
                        break;
                    case "3":
                        BuscarRegistro();
                        break;
                    case "4":
                        continuar = false;
                        Console.WriteLine("Saliendo del programa. ¡Hasta luego!");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
                        break;
                }
            }
        }

        static void MostrarMenu()
        {
            Console.WriteLine("\n=== Menú Principal ===");
            Console.WriteLine("1. Registrar nuevo GPS");
            Console.WriteLine("2. Mostrar registros guardados");
            Console.WriteLine("3. Buscar registro por IMEI o Placa");
            Console.WriteLine("4. Salir");
            Console.WriteLine("=======================");
            Console.Write("Selecciona una opción: ");
        }

        static void RegistrarDatos()
        {
            string marca = PedirDato("Ingresar marca del GPS:");
            string modelo = PedirDato("Ingresar modelo del GPS:");
            string IMEI = PedirDatoNumerico("Ingresar IMEI del GPS (15 dígitos):", 15);
            string proveedorSim = PedirDato("Ingresar proveedor de la SIM Card:");
            string numeroSim = PedirDatoNumerico("Ingresar número de la SIM Card (10 dígitos):", 10);
            string tipoVehiculo = PedirDato("Ingresar tipo de vehículo:");
            string placaVehiculo = PedirDato("Ingresar placa del vehículo:");

            string registro = $"Fecha: {DateTime.Now}\nMarca GPS: {marca}\nModelo GPS: {modelo}\nIMEI: {IMEI}\n" +
                              $"Proveedor SIM: {proveedorSim}\nNúmero SIM: {numeroSim}\nTipo Vehículo: {tipoVehiculo}\n" +
                              $"Placa Vehículo: {placaVehiculo}\n-----------------------------------";

            GuardarDatosEnArchivo(registro);
            Console.WriteLine("Datos guardados correctamente.");
        }

        static string PedirDato(string mensaje)
        {
            string dato;
            do
            {
                Console.WriteLine(mensaje);
                dato = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(dato))
                {
                    Console.WriteLine("Este campo no puede estar vacío. Inténtalo de nuevo.");
                }
            } while (string.IsNullOrWhiteSpace(dato));

            return dato;
        }

        static string PedirDatoNumerico(string mensaje, int longitud)
        {
            string dato;
            do
            {
                Console.WriteLine(mensaje);
                dato = Console.ReadLine();
                if (!long.TryParse(dato, out _) || dato.Length != longitud)
                {
                    Console.WriteLine($"Por favor, ingresa un valor numérico válido de {longitud} dígitos.");
                    dato = null;
                }
            } while (string.IsNullOrWhiteSpace(dato));

            return dato;
        }

        static void GuardarDatosEnArchivo(string datos)
        {
            using (StreamWriter writer = new StreamWriter("GPSInstalados.txt", true))
            {
                writer.WriteLine(datos);
            }
        }

        static void MostrarRegistros()
        {
            string archivo = "GPSInstalados.txt";

            if (File.Exists(archivo))
            {
                string contenido = File.ReadAllText(archivo);
                Console.WriteLine("\n=== Registros Guardados ===");
                Console.WriteLine(contenido);
            }
            else
            {
                Console.WriteLine("No hay registros guardados.");
            }
        }

        static void BuscarRegistro()
        {
            Console.Write("Ingresa el IMEI o Placa para buscar: ");
            string criterio = Console.ReadLine();

            string archivo = "GPSInstalados.txt";

            if (File.Exists(archivo))
            {
                string[] lineas = File.ReadAllLines(archivo);
                bool encontrado = false;

                foreach (string linea in lineas)
                {
                    if (linea.Contains(criterio))
                    {
                        Console.WriteLine(linea);
                        encontrado = true;
                    }
                }

                if (!encontrado)
                {
                    Console.WriteLine("No se encontró ningún registro con el criterio ingresado.");
                }
            }
            else
            {
                Console.WriteLine("No hay registros guardados.");
            }
        }
    }
}
