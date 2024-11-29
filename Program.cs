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

            string registro = $"Fecha: {DateTime.Now}\n" +
                              $"Marca GPS: {marca}\nModelo GPS: {modelo}\nIMEI: {IMEI}\n" +
                              $"Proveedor SIM: {proveedorSim}\nNúmero SIM: {numeroSim}\n" +
                              $"Tipo Vehículo: {tipoVehiculo}\nPlaca Vehículo: {placaVehiculo}\n" +
                              $"-----------------------------------";

            GuardarDatosEnArchivo(registro);
            Console.WriteLine("Datos guardados correctamente.");
        }

        static string PedirDato(string mensaje)
        {
            string dato;
            do
            {
                Console.WriteLine(mensaje);
                dato = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(dato))
                {
                    Console.WriteLine("Este campo no puede estar vacío. Inténtalo de nuevo.");
                }
                else if (!EsValido(dato))
                {
                    Console.WriteLine("El dato contiene caracteres no permitidos. Inténtalo de nuevo.");
                    dato = null;
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
                dato = Console.ReadLine()?.Trim();
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
            string criterio = Console.ReadLine()?.Trim();

            string archivo = "GPSInstalados.txt";

            if (File.Exists(archivo))
            {
                string[] lineas = File.ReadAllText(archivo).Split(new[] { "-----------------------------------" }, StringSplitOptions.RemoveEmptyEntries);
                bool encontrado = false;

                foreach (string registro in lineas)
                {
                    if (registro.Contains(criterio))
                    {
                        Console.WriteLine("\n=== Registro Encontrado ===");
                        Console.WriteLine(registro.Trim());
                        Console.WriteLine("---------------------------");
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

        static bool EsValido(string texto)
        {
            foreach (char c in texto)
            {
                if (!char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c) && c != '-')
                {
                    return false;
                }
            }
            return true;
        }
    }
}
