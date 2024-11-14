using System;
using System.IO;

namespace Program
{
  class Program
  {
    static void Main(string[] args)
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

      using (StreamWriter writer = new StreamWriter("RegistroBasicoGPS.txt", true))
      {
        writer.WriteLine("Fecha de registro: " + DateTime.Now);
        writer.WriteLine("Marca: " + marca);
        writer.WriteLine("Modelo: " + modelo);
        writer.WriteLine("IMEI: " + IMEI);
        writer.WriteLine("Proveedor de SIM: " + proveedorSim);
        writer.WriteLine("Número de SIM: " + numeroSim);
        writer.WriteLine("Día de Recarga: " + recargaSim);
        writer.WriteLine("-----------------------------------");
      }

      Console.WriteLine("\nDatos guardados en RegistroBasicoGPS.txt");
      Console.WriteLine("Resumen de datos ingresados:");
      Console.WriteLine($"Marca: {marca}");
      Console.WriteLine($"Modelo: {modelo}");
      Console.WriteLine($"IMEI: {IMEI}");
      Console.WriteLine($"Proveedor de SIM: " + proveedorSim);
      Console.WriteLine($"Día de Recarga: " + recargaSim);
      Console.WriteLine($"Número de SIM: " + numeroSim);
    }
  }
}
