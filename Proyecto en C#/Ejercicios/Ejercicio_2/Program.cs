using System;

namespace Program

{

  class Program

  {
    static void Main(string[] args)
    {

      Console.WriteLine("Ingresa tu nombre:");
      string nombre = Console.ReadLine();

      Console.WriteLine("Ingresa tu edad:");
      int edad = int.Parse(Console.ReadLine());

      Console.WriteLine("Ingresa tu nacionalidad:");
      string nacion = Console.ReadLine();

      Console.WriteLine("Ingresa tu alrtura (en centimetros):");
      double altura = double.Parse(Console.ReadLine());



Console.WriteLine($"Hola {nombre}, sabemos que tienes {edad} años de edad, mides {altura} cm de alto y vives en {nacion}.");



    }

  }
}
