using System; // Importa el espacio de nombres System, que contiene clases básicas como Console.

namespace GPSRegistration // Define un espacio de nombres para organizar tu código.
{
    class Program // Define la clase principal del programa.
    {
        static void Main(string[] args) // Método principal donde comienza la ejecución del programa.
        {
            Console.WriteLine("=== Sistema de Registro GPS ==="); // Mensaje de bienvenida.

            // Bucle infinito para mantener el programa ejecutándose hasta que el usuario decida salir.
            while (true)
            {
                // Menú principal del sistema.
                Console.WriteLine("\nMenú Principal:");
                Console.WriteLine("1. Registrar GPS"); // Opción para registrar un nuevo GPS.
                Console.WriteLine("2. Salir"); // Opción para salir del programa.

                // Solicita al usuario que seleccione una opción.
                Console.Write("\nSeleccione una opción: ");
                string opcion = Console.ReadLine(); // Lee la opción ingresada por el usuario.

                // Estructura switch para manejar las opciones del menú.
                switch (opcion)
                {
                    case "1": // Si elige "1", llama al método RegistrarGPS().
                        RegistrarGPS();
                        break;
                    case "2": // Si elige "2", finaliza el programa.
                        Console.WriteLine("¡Gracias por usar el sistema!");
                        return; // Termina la ejecución del programa.
                    default: // Maneja cualquier entrada no válida.
                        Console.WriteLine("Opción no válida. Por favor, intente nuevamente.");
                        break;
                }
            }
        }

        // Método para registrar los datos de un nuevo GPS.
        static void RegistrarGPS()
        {
            Console.WriteLine("\n=== Registro de Nueva GPS ==="); // Título para la sección de registro.

            // Solicita y almacena los datos relacionados con el GPS.
            Console.Write("Marca Del GPS: ");
            string marca = Console.ReadLine(); // Almacena la marca del GPS.

            Console.Write("Modelo Del GPS: ");
            string modelo = Console.ReadLine(); // Almacena el modelo del GPS.

            Console.Write("IMEI: ");
            string imei = Console.ReadLine(); // Almacena el número IMEI del GPS.

            Console.Write("Proveedor De Tarjeta SIM: ");
            string sim = Console.ReadLine(); // Almacena el proveedor de la tarjeta SIM.

            Console.Write("Numero De La Tarjeta SIM: ");
            string simcard = Console.ReadLine(); // Almacena el número de la tarjeta SIM.

            Console.Write("Tipo De Vehiculo: ");
            string vehiculo = Console.ReadLine(); // Almacena el tipo de vehículo.

            Console.Write("Placa Del Vehiculo: ");
            string placa = Console.ReadLine(); // Almacena la placa del vehículo.

            Console.Write("Modelo Del Vehiculo");
            string modeloVehi = Console.ReadLine(); // Almacena el modelo del vehículo.

            // Muestra un resumen de los datos registrados.
            Console.WriteLine($"\nGPS registrado:");
            Console.WriteLine($"Marca: {marca}"); // Muestra la marca del GPS.
            Console.WriteLine($"Modelo: {modelo}"); // Muestra el modelo del GPS.
            Console.WriteLine($"Vehiculo: {vehiculo}"); // Muestra el tipo de vehículo.
        }
    }
}
