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

        // Guardar los datos en el archivo
        using (StreamWriter writer = new StreamWriter("GPSInstalados.txt", true))
        {
          writer.WriteLine("Fecha de registro: " + DateTime.Now);
          Console.WriteLine($"Marca: {marca}");
          Console.WriteLine($"Modelo: {modelo}");
          Console.WriteLine($"IMEI: {IMEI}");
          Console.WriteLine($"Proveedor de SIM: " + proveedorSim);
          Console.WriteLine($"Número de SIM: " + numeroSim);
          Console.WriteLine($"Día de Recarga: " + recargaSim);
          writer.WriteLine("-----------------------------------");
        }

        Console.WriteLine("\nDatos guardados en GPSInstalados.txt");
        Console.WriteLine("Resumen de datos ingresados:");
        Console.WriteLine($"Marca: {marca}");
        Console.WriteLine($"Modelo: {modelo}");
        Console.WriteLine($"IMEI: {IMEI}");
        Console.WriteLine($"Proveedor de SIM: " + proveedorSim);
        Console.WriteLine($"Número de SIM: " + numeroSim);
        Console.WriteLine($"Día de Recarga: " + recargaSim);

        // Preguntar al usuario si quiere ingresar otro registro
        Console.WriteLine("\n¿Deseas ingresar otro registro? (s/n)");
        continuar = Console.ReadLine().ToLower();

      } while (continuar == "s");

      Console.WriteLine("Programa finalizado. ¡Hasta luego!");
    }
  }
}
