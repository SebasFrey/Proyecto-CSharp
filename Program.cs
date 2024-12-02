using System; // Importa el espacio de nombres System.
using System.IO; // Importa el espacio de nombres para manejar archivos.

namespace GPSRegistration // Define un espacio de nombres para organizar tu código.
{
    class Program // Define la clase principal del programa.
    {
        static void Main(string[] args) // Método principal donde comienza la ejecución.
        {
            Console.WriteLine("=== Sistema de Registro GPS ==="); // Mensaje de bienvenida.

            // Bucle infinito para mantener el programa en ejecución.
            while (true)
            {
                Console.WriteLine("\nMenú Principal:");
                Console.WriteLine("1. Registrar GPS"); // Opción para registrar un nuevo GPS.
                Console.WriteLine("2. Salir"); // Opción para salir del programa.

                // Solicita una opción al usuario.
                Console.Write("\nSeleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1": // Si elige "1", llama al método RegistrarGPS.
                        RegistrarGPS();
                        break;
                    case "2": // Si elige "2", finaliza el programa.
                        Console.WriteLine("¡Gracias por usar el sistema!");
                        return; // Termina la ejecución.
                    default: // Maneja opciones no válidas.
                        Console.WriteLine("Opción no válida. Por favor, intente nuevamente.");
                        break;
                }
            }
        }

        // Método para registrar datos de un GPS.
        static void RegistrarGPS()
        {
            Console.WriteLine("\n=== Registro de Nuevo GPS ===");

            // Solicitar datos del GPS al usuario.
            Console.Write("Marca del GPS: ");
            string marca = Console.ReadLine();

            Console.Write("Modelo del GPS: ");
            string modelo = Console.ReadLine();

            Console.Write("IMEI: ");
            string imei = Console.ReadLine();

            Console.Write("Proveedor de Tarjeta SIM: ");
            string sim = Console.ReadLine();

            Console.Write("Número de la Tarjeta SIM: ");
            string simcard = Console.ReadLine();

            Console.Write("Tipo de Vehículo: ");
            string vehiculo = Console.ReadLine();

            Console.Write("Placa del Vehículo: ");
            string placa = Console.ReadLine();

            Console.Write("Modelo del Vehículo: ");
            string modeloVehi = Console.ReadLine();

            // Crear el contenido a guardar.
            string contenido = $"Marca: {marca}\nModelo: {modelo}\nIMEI: {imei}\n" + $"Proveedor SIM: {sim}\nNúmero SIM: {simcard}\n" + $"Tipo de Vehículo: {vehiculo}\nPlaca: {placa}\n" + $"Modelo Vehículo: {modeloVehi}\n";

            // Especificar la ruta del archivo.
            string filePath = "GPSsRegistrados.txt";

            try
            {
                // Guardar el contenido en el archivo.
                File.AppendAllText(filePath, contenido + "\n"); // Agregar contenido al archivo existente.

                Console.WriteLine($"¡GPS registrado exitosamente! Los datos se guardaron en '{filePath}'.");
            }
            catch (Exception ex)
            {
                // Manejo de errores si algo sale mal al guardar.
                Console.WriteLine($"Error al guardar los datos: {ex.Message}");
            }
        }
    }
}
