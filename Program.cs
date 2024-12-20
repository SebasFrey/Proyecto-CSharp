<<<<<<< HEAD
﻿using System; // Importa el espacio de nombres System, que contiene clases básicas como Console.
using System.IO;
=======
﻿using System; // Importa el espacio de nombres System.
using System.IO; // Importa el espacio de nombres para manejar archivos.
>>>>>>> fuegote

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

<<<<<<< HEAD
            Console.Write("Proveedor De La Tarjeta SIM: ");
            string sim = Console.ReadLine(); // Almacena el proveedor de la tarjeta SIM.
=======
            Console.Write("Proveedor de Tarjeta SIM: ");
            string sim = Console.ReadLine();
>>>>>>> fuegote

            Console.Write("Número de la Tarjeta SIM: ");
            string simcard = Console.ReadLine();

            Console.Write("Tipo de Vehículo: ");
            string vehiculo = Console.ReadLine();

            Console.Write("Placa del Vehículo: ");


            Console.Write("Modelo Del Vehiculo: ");
            string modeloVehi = Console.ReadLine(); // Almacena el modelo del vehículo.

            // Muestra un resumen de los datos registrados.
            Console.WriteLine($"\nGPS registrado:");
            Console.WriteLine($"Marca: {marca}"); // Muestra la marca del GPS.
            Console.WriteLine($"Modelo: {modelo}"); // Muestra el modelo del GPS.
            Console.WriteLine($"IMEI: {imei}");
            Console.WriteLine($"Proveedor De La Tarjeta SIM: {sim}");
            Console.WriteLine($"Numero De La Tarjeta SIM: {simcard}");
            Console.WriteLine($"Tipo De Vehiculo: {vehiculo}");
            Console.WriteLine($"Placa Del Vehiculo: {placa}");
            Console.WriteLine($"Modelo Del Vehiculo: {modeloVehi}");
            Console.WriteLine($"Vehiculo: {vehiculo}"); // Muestra el tipo de vehículo.
=======
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
>>>>>>> fuegote
        }
    }
}
