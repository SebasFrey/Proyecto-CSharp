using System;  // Importa el espacio de nombres System, que incluye clases fundamentales como Console y DateTime.
using System.IO;  // Importa el espacio de nombres para trabajar con entradas y salidas de archivos.

namespace Program  // Define el espacio de nombres del proyecto.
{
    class Program  // Define la clase principal del programa.
    {
        static void Main(string[] args)  // Método principal que se ejecuta al iniciar el programa.
        {
            bool continuar = true;  // Variable para controlar el ciclo del menú.

            while (continuar)  // Inicia un bucle que continuará hasta que la variable 'continuar' sea falsa.
            {
                MostrarMenu();  // Llama al método para mostrar el menú.

                string opcion = Console.ReadLine();  // Lee la opción seleccionada por el usuario desde la consola.

                switch (opcion)  // Usa una estructura switch para ejecutar una acción basada en la opción seleccionada.
                {
                    case "1":  // Si la opción es 1, se ejecuta el método para registrar un nuevo GPS.
                        RegistrarDatos();
                        break;
                    case "2":  // Si la opción es 2, se ejecuta el método para mostrar los registros guardados.
                        MostrarRegistros();
                        break;
                    case "3":  // Si la opción es 3, se ejecuta el método para buscar un registro por IMEI o placa.
                        BuscarRegistro();
                        break;
                    case "4":  // Si la opción es 4, se termina el programa.
                        continuar = false;  // Cambia la variable 'continuar' a false para salir del bucle y finalizar el programa.
                        Console.WriteLine("Saliendo del programa. ¡Hasta luego!");  // Muestra un mensaje de despedida.
                        break;
                    default:  // Si la opción no es válida, muestra un mensaje de error.
                        Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
                        break;
                }
            }
        }

        static void MostrarMenu()  // Método para mostrar el menú de opciones al usuario.
        {
            Console.WriteLine("\n=== Menú Principal ===");  // Muestra el encabezado del menú.
            Console.WriteLine("1. Registrar nuevo GPS");  // Opción 1: Registrar nuevo GPS.
            Console.WriteLine("2. Mostrar registros guardados");  // Opción 2: Mostrar los registros guardados.
            Console.WriteLine("3. Buscar registro por IMEI o Placa");  // Opción 3: Buscar un registro por IMEI o placa.
            Console.WriteLine("4. Salir");  // Opción 4: Salir del programa.
            Console.WriteLine("=======================");
            Console.Write("Selecciona una opción: ");  // Solicita al usuario que ingrese una opción.
        }

        static void RegistrarDatos()  // Método para registrar un nuevo GPS.
        {
            // Se utilizan métodos para pedir los datos del GPS y del vehículo.
            string marca = PedirDato("Ingresar marca del GPS:");
            string modelo = PedirDato("Ingresar modelo del GPS:");
            string IMEI = PedirDato("Ingresar IMEI del GPS:");  // Ahora no se valida la longitud del IMEI.
            string proveedorSim = PedirDato("Ingresar proveedor de la SIM Card:");
            string numeroSim = PedirDato("Ingresar número de la SIM Card:");  // Ya no se valida la longitud del número SIM.
            string tipoVehiculo = PedirDato("Ingresar tipo de vehículo:");
            string placaVehiculo = PedirDato("Ingresar placa del vehículo:");

            // Se crea una cadena con la información del registro, incluyendo la fecha actual.
            string registro = $"Fecha: {DateTime.Now}\n" +
                              $"Marca GPS: {marca}\nModelo GPS: {modelo}\nIMEI: {IMEI}\n" +
                              $"Proveedor SIM: {proveedorSim}\nNúmero SIM: {numeroSim}\n" +
                              $"Tipo Vehículo: {tipoVehiculo}\nPlaca Vehículo: {placaVehiculo}\n" +
                              $"-----------------------------------";

            // Llama a un método para guardar los datos en un archivo.
            GuardarDatosEnArchivo(registro);
            Console.WriteLine("Datos guardados correctamente.");  // Muestra un mensaje indicando que los datos fueron guardados.
        }

        static string PedirDato(string mensaje)  // Método para solicitar un dato al usuario y validar que no esté vacío o contenga caracteres no permitidos.
        {
            string dato;
            do
            {
                Console.WriteLine(mensaje);  // Muestra el mensaje solicitando el dato.
                dato = Console.ReadLine()?.Trim();  // Lee el dato ingresado y elimina los espacios en blanco.
                if (string.IsNullOrWhiteSpace(dato))  // Verifica si el dato está vacío.
                {
                    Console.WriteLine("Este campo no puede estar vacío. Inténtalo de nuevo.");
                }
                else if (!EsValido(dato))  // Verifica si el dato contiene caracteres no permitidos.
                {
                    Console.WriteLine("El dato contiene caracteres no permitidos. Inténtalo de nuevo.");
                    dato = null;
                }
            } while (string.IsNullOrWhiteSpace(dato));  // Repite el ciclo mientras el dato sea vacío o no válido.

            return dato;  // Retorna el dato ingresado por el usuario.
        }

        static void GuardarDatosEnArchivo(string datos)  // Método para guardar los datos en un archivo.
        {
            using (StreamWriter writer = new StreamWriter("GPSInstalados.txt", true))  // Abre el archivo en modo de escritura, agregando al final.
            {
                writer.WriteLine(datos);  // Escribe los datos en el archivo.
            }
        }

        static void MostrarRegistros()  // Método para mostrar los registros guardados en el archivo.
        {
            string archivo = "GPSInstalados.txt";  // Nombre del archivo donde se almacenan los registros.

            if (File.Exists(archivo))  // Verifica si el archivo existe.
            {
                string contenido = File.ReadAllText(archivo);  // Lee todo el contenido del archivo.
                Console.WriteLine("\n=== Registros Guardados ===");
                Console.WriteLine(contenido);  // Muestra el contenido de los registros en la consola.
            }
            else
            {
                Console.WriteLine("No hay registros guardados.");  // Muestra un mensaje si no existen registros.
            }
        }

        static void BuscarRegistro()  // Método para buscar un registro por IMEI o placa.
        {
            Console.Write("Ingresa el IMEI o Placa para buscar: ");  // Solicita al usuario que ingrese el IMEI o placa.
            string criterio = Console.ReadLine()?.Trim();  // Lee el criterio de búsqueda.

            string archivo = "GPSInstalados.txt";  // Nombre del archivo donde se almacenan los registros.

            if (File.Exists(archivo))  // Verifica si el archivo existe.
            {
                string[] lineas = File.ReadAllText(archivo).Split(new[] { "-----------------------------------" }, StringSplitOptions.RemoveEmptyEntries);  // Separa los registros en líneas.
                bool encontrado = false;  // Bandera para indicar si se encontró el registro.

                foreach (string registro in lineas)  // Recorre cada registro en el archivo.
                {
                    if (registro.Contains(criterio))  // Si el registro contiene el criterio de búsqueda.
                    {
                        Console.WriteLine("\n=== Registro Encontrado ===");
                        Console.WriteLine(registro.Trim());  // Muestra el registro encontrado.
                        Console.WriteLine("---------------------------");
                        encontrado = true;  // Marca que se encontró un registro.
                    }
                }

                if (!encontrado)  // Si no se encontró ningún registro.
                {
                    Console.WriteLine("No se encontró ningún registro con el criterio ingresado.");
                }
            }
            else
            {
                Console.WriteLine("No hay registros guardados.");  // Si el archivo no existe.
            }
        }

        static bool EsValido(string texto)  // Método para validar si el texto contiene solo caracteres permitidos (letras, dígitos, espacios y guiones).
        {
            foreach (char c in texto)  // Recorre cada carácter del texto.
            {
                if (!char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c) && c != '-')  // Si el carácter no es válido.
                {
                    return false;
                }
            }
            return true;  // Retorna verdadero si todos los caracteres son válidos.
        }
    }
}
