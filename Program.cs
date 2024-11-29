using System;

namespace GPSRegistration
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Sistema de Registro GPS ===");

            while (true)
            {
                Console.WriteLine("\nMenú Principal:");
                Console.WriteLine("1. Registrar GPS");
                Console.WriteLine("2. Salir");

                Console.Write("\nSeleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        RegistrarUbicacion();
                        break;
                    case "2":
                        Console.WriteLine("¡Gracias por usar el sistema!");
                        return;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, intente nuevamente.");
                        break;
                }
            }
        }
        static void RegistrarUbicacion()
        {
            Console.WriteLine("\n=== Registro de Nueva Ubicación ===");

            Console.Write("Marca Del GPS: ");
            string marca = Console.ReadLine();

            Console.Write("Modelo Del GPS: ");
            string modelo = Console.ReadLine();

            Console.Write("IMEI: ");
            string imei = Console.ReadLine();

            Console.Write("Proveedor De Tarjeta SIM: ");
            string sim = Console.ReadLine();

            Console.Write("Numero De La Tarjeta SIM: ");
            string simcard = Console.ReadLine();

            Console.Write("Tipo De Vehiculo: ");
            string vehiculo = Console.ReadLine();

            Console.Write("Placa Del Vehiculo: ");
            string placa = Console.ReadLine();

            Console.Write("Modelo Del Vehiculo");
            string modeloVehi = Console.ReadLine();

            Console.WriteLine($"\nGPS registrado:");
            Console.WriteLine($"Marca: {marca}");
            Console.WriteLine($"Modelo: {modelo}");
            Console.WriteLine($"Vehiculo: {vehiculo}");
        }
    }
}
