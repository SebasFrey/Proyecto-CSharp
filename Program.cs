using System;
using System.IO;

namespace Program
{
  class Program
  {
    static void Main(string[] args)
    {
      string continuar;

      do
      {
        // Recopilación de datos del GPS
        Console.WriteLine("Ingresar marca del GPS:");
        string marca = Console.ReadLine();

        Console.WriteLine("Ingresar modelo del GPS:");
        string modelo = Console.ReadLine();

        Console.WriteLine("Ingresar IMEI del GPS:");
        string IMEI = Console.ReadLine();

        Console.WriteLine("Ingresar proveedor de la SIM Card:");
        string proveedorSim = Console.ReadLine();

        Console.WriteLine("Ingresar número de la SIM Card:");
        string numeroSim = Console.ReadLine();

        Console.WriteLine("Ingresar día de recarga de la SIM Card:");
        string recargaSim = Console.ReadLine();

        // Nuevos campos para la información del activo
        Console.WriteLine("Ingresar tipo de vehículo (moto, carro, etc.):");
        string tipoVehiculo = Console.ReadLine();

        Console.WriteLine("Ingresar placa del vehículo:");
        string placaVehiculo = Console.ReadLine();

        Console.WriteLine("Ingresar marca del vehículo:");
        string marcaVehiculo = Console.ReadLine();

        // Guardar los datos en el archivo
        using (StreamWriter writer = new StreamWriter("GPSInstalados.txt", true))
        {
          writer.WriteLine("Fecha de registro: " + DateTime.Now);
          writer.WriteLine($"Marca GPS: {marca}");
          writer.WriteLine($"Modelo GPS: {modelo}");
          writer.WriteLine($"IMEI: {IMEI}");
          writer.WriteLine($"Proveedor de SIM: {proveedorSim}");
          writer.WriteLine($"Número de SIM: {numeroSim}");
          writer.WriteLine($"Día de Recarga: {recargaSim}");
          writer.WriteLine($"Tipo de Vehículo: {tipoVehiculo}");
          writer.WriteLine($"Placa del Vehículo: {placaVehiculo}");
          writer.WriteLine($"Marca del Vehículo: {marcaVehiculo}");
          writer.WriteLine("-----------------------------------");
        }

        // Mostrar resumen de datos ingresados
        Console.WriteLine("\nDatos guardados en GPSInstalados.txt");
        Console.WriteLine("Resumen de datos ingresados:");
        Console.WriteLine($"Marca GPS: {marca}");
        Console.WriteLine($"Modelo GPS: {modelo}");
        Console.WriteLine($"IMEI: {IMEI}");
        Console.WriteLine($"Proveedor de SIM: {proveedorSim}");
        Console.WriteLine($"Número de SIM: {numeroSim}");
        Console.WriteLine($"Día de Recarga: {recargaSim}");
        Console.WriteLine($"Tipo de Vehículo: {tipoVehiculo}");
        Console.WriteLine($"Placa del Vehículo: {placaVehiculo}");
        Console.WriteLine($"Marca del Vehículo: {marcaVehiculo}");

        // Preguntar al usuario si quiere ingresar otro registro
        Console.WriteLine("\n¿Deseas ingresar otro registro? (s/n)");
        continuar = Console.ReadLine().ToLower();

      } while (continuar == "s");

      Console.WriteLine("Programa finalizado. ¡Hasta luego!");
    }
  }
}

