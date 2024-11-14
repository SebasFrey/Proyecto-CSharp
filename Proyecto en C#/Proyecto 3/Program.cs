using System; // Se utiliza para acceder a funciones básicas de C#, como la consola.

namespace Program // Este es el espacio de nombres de nuestro programa.
{
  class Program // Esta es nuestra clase principal, llamada "Program".
  {
    static void Main(string[] args) // Método principal donde comienza la ejecución del programa.
    {
      Console.WriteLine("Hola Mundo"); // Imprime "Hola Mundo" en la consola.

      // **Declaración y uso de variables**
      int numero = 20; // Variable de tipo entero.
      double decimalNum = 2.3; // Variable de tipo doble (número decimal de doble precisión).
      string texto = "Si puedes imaginarlo\nPuedes programarlo"; // Cadena de texto con salto de línea.
      bool esVerdadero = true; // Variable booleana que almacena verdadero o falso.

      Console.WriteLine(numero);
      Console.WriteLine(decimalNum);
      Console.WriteLine(texto);
      Console.WriteLine(esVerdadero);

      // **Operaciones Básicas**
      int a = 20;
      int b = 23;

      int suma = a + b; // Suma de dos enteros.
      int resta = a - b; // Resta de dos enteros.
      int multi = a * b; // Multiplicación de dos enteros.
      double div = (double)a / b; // División, convertimos 'a' a double para resultado decimal.

      Console.WriteLine("Suma: " + suma);
      Console.WriteLine("Resta: " + resta);
      Console.WriteLine("Multiplicación: " + multi);
      Console.WriteLine("División: " + div);

      // **Condicionales**
      int edadUsuario = 20; // Cambiamos el nombre de la variable para evitar conflictos

      if (edadUsuario >= 18)
      {
        Console.WriteLine("Eres mayor de edad.");
      }
      else
      {
        Console.WriteLine("Eres menor de edad.");
      }

      // **Ciclos**
      // Ciclo for
      for (int i = 0; i < 5; i++)
      {
        Console.WriteLine("Valor de i: " + i); // Imprime el valor de i en cada iteración.
      }

      // Ciclo while
      int j = 0;
      while (j < 5)
      {
        Console.WriteLine("Valor de j: " + j);
        j++;
      }

      // Ciclo do-while
      int k = 0;
      do
      {
        Console.WriteLine("Valor de k: " + k);
        k++;
      } while (k < 5);

      // **Entrada y salida de datos**

      // Leer un dato de tipo string
      Console.WriteLine("Por favor, ingresa tu nombre:");
      string nombre = Console.ReadLine();
      Console.WriteLine("Hola, " + nombre + "!");

      // Leer un número entero (int)
      Console.WriteLine("Por favor, ingresa tu edad:");
      int edadIngresada;
      if (int.TryParse(Console.ReadLine(), out edadIngresada))
      {
        Console.WriteLine("Tienes " + edadIngresada + " años.");
      }
      else
      {
        Console.WriteLine("Entrada no válida para la edad.");
      }

      // Leer un número decimal (double)
      Console.WriteLine("Por favor, ingresa un número decimal:");
      double numeroDecimal;
      if (double.TryParse(Console.ReadLine(), out numeroDecimal))
      {
        Console.WriteLine("El número ingresado es: " + numeroDecimal);
      }
      else
      {
        Console.WriteLine("Entrada no válida para un número decimal.");
      }

      // Leer un valor booleano (bool)
      Console.WriteLine("¿Es cierto? (true o false):");
      bool esCierto;
      if (bool.TryParse(Console.ReadLine(), out esCierto))
      {
        Console.WriteLine("El valor ingresado es: " + esCierto);
      }
      else
      {
        Console.WriteLine("Entrada no válida para un valor booleano.");
      }
    }
  }
}
