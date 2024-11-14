using System;

namespace CSharpProyecto_1
{
    class Proyecto_1
    {
        static void Main(string[] args)
        {
            // Imprime un saludo en consola.
            Console.WriteLine("Hello, World!");

            // Declaración de una cadena de texto (string).
            string myString = "Si puedes imaginarlo, puedes programarlo";
            Console.WriteLine(myString);

            // Declaración de un número entero (int).
            int myInt = 20;
            myInt = myInt + 23;
            Console.WriteLine(myInt - 1);
            Console.WriteLine(myInt);

            // Declaración de un número decimal (double).
            double myDouble = 20.23;
            Console.WriteLine(myDouble);

            // Declaración de un número decimal de precisión simple (float).
            float myFloat = 23.20f;
            Console.WriteLine(myFloat);
            Console.WriteLine(myFloat + myDouble);
            Console.WriteLine(myFloat + myDouble + myInt);

            // Declaración de una variable booleana (bool).
            bool myBool = true;
            myBool = false;
            Console.WriteLine(myBool);

            // Declaración de una variable dinámica (dynamic), que puede cambiar de tipo en tiempo de ejecución.
            dynamic myDynamic = 20;
            myDynamic = "Mi Dato Dinamico";
            Console.WriteLine(myDynamic);
            Console.WriteLine(myDynamic + myFloat);

            // Declaración de una variable con tipo inferido (var). El tipo se deduce automáticamente.
            var myVar = "MI variable de tipo inferido";
            Console.WriteLine(myVar);
            Console.WriteLine($"El valor de mi entero es {myInt} y el de mi bool {myBool}");

            // Declaración de una constante (const). Su valor no puede cambiar después de ser asignado.
            const string myConst = "Mi constante";  // Se corrigió el tipo de la constante.
            Console.WriteLine(myConst);
        }
    }
}
