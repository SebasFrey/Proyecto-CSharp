using System; // Se importa el espacio de nombres para las funcionalidades de consola y entrada/salida.
using System.IO; // Se importa el espacio de nombres para trabajar con archivos y directorios.

namespace Program // Definimos el espacio de nombres para organizar las clases y archivos.
{
    class Program // Definimos la clase principal del programa.
    {
        static void Main(string[] args) // Método principal donde se ejecuta el programa.
        {
            bool continuar = true; // Variable que controla el flujo del menú.

            // Bucle principal que muestra el menú y ejecuta las opciones hasta que el usuario decida salir.
            while (continuar)
            {
                MostrarMenu(); // Llama al método que muestra el menú de opciones.

                string opcion = Console.ReadLine(); // Lee la opción seleccionada por el usuario.

                // Estructura de control que ejecuta las acciones según la opción seleccionada.
                switch (opcion)
                {
                    case "1": // Opción 1: Registrar un nuevo GPS.
                        RegistrarDatos();
                        break;
                    case "2": // Opción 2: Mostrar los registros guardados.
                        MostrarRegistros();
                        break;
                    case "3": // Opción 3: Buscar un registro por IMEI o Placa.
                        BuscarRegistro();
                        break;
                    case "4": // Opción 4: Salir del programa.
                        continuar = false; // Cambia la variable para salir del bucle.
                        Console.WriteLine("Saliendo del programa. ¡Hasta luego!"); // Mensaje de despedida.
                        break;
                    default: // Si el usuario ingresa una opción no válida.
                        Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
                        break;
                }
            }
        }

        static void MostrarMenu() // Método que muestra el menú con las opciones disponibles.
        {
            Console.WriteLine("\n=== Menú Principal ==="); // Encabezado del menú.
            Console.WriteLine("1. Registrar nuevo GPS"); // Opción para registrar un GPS.
            Console.WriteLine("2. Mostrar registros guardados"); // Opción para mostrar registros.
            Console.WriteLine("3. Buscar registro por IMEI o Placa"); // Opción para buscar registros.
            Console.WriteLine("4. Salir"); // Opción para salir del programa.
            Console.WriteLine("=======================");
            Console.Write("Selecciona una opción: "); // Solicita la opción del usuario.
        }

        static void RegistrarDatos() // Método para registrar los datos de un nuevo GPS.
        {
            // Se solicita al usuario la información necesaria.
            string marca = PedirDato("Ingresar marca del GPS:");
            string modelo = PedirDato("Ingresar modelo del GPS:");
            string IMEI = PedirDatoNumerico("Ingresar IMEI del GPS (15 dígitos):", 15);
            string proveedorSim = PedirDato("Ingresar proveedor de la SIM Card:");
            string numeroSim = PedirDatoNumerico("Ingresar número de la SIM Card (10 dígitos):", 10);
            string tipoVehiculo = PedirDato("Ingresar tipo de vehículo:");
            string placaVehiculo = PedirDato("Ingresar placa del vehículo:");

            // Se crea un registro con todos los datos proporcionados.
            string registro = $"Fecha: {DateTime.Now}\n" +
                              $"Marca GPS: {marca}\nModelo GPS: {modelo}\nIMEI: {IMEI}\n" +
                              $"Proveedor SIM: {proveedorSim}\nNúmero SIM: {numeroSim}\n" +
                              $"Tipo Vehículo: {tipoVehiculo}\nPlaca Vehículo: {placaVehiculo}\n" +
                              $"-----------------------------------";

            // Llama al método para guardar los datos en un archivo.
            GuardarDatosEnArchivo(registro);
            Console.WriteLine("Datos guardados correctamente."); // Mensaje de confirmación.
        }

        static string PedirDato(string mensaje) // Método para pedir un dato de texto al usuario.
        {
            string dato;
            do
            {
                Console.WriteLine(mensaje); // Muestra el mensaje al usuario.
                dato = Console.ReadLine()?.Trim(); // Lee la entrada y elimina los espacios innecesarios.
                if (string.IsNullOrWhiteSpace(dato)) // Verifica si el dato está vacío.
                {
                    Console.WriteLine("Este campo no puede estar vacío. Inténtalo de nuevo.");
                }
                else if (!EsValido(dato)) // Verifica si el dato contiene caracteres no válidos.
                {
                    Console.WriteLine("El dato contiene caracteres no permitidos. Inténtalo de nuevo.");
                    dato = null; // Reinicia el valor de dato para que el ciclo se repita.
                }
            } while (string.IsNullOrWhiteSpace(dato)); // Repite hasta que el dato sea válido.

            return dato; // Devuelve el dato válido.
        }

        static string PedirDatoNumerico(string mensaje, int longitud) // Método para pedir un dato numérico con una longitud específica.
        {
            string dato;
            do
            {
                Console.WriteLine(mensaje); // Muestra el mensaje al usuario.
                dato = Console.ReadLine()?.Trim(); // Lee la entrada y elimina los espacios innecesarios.
                if (!long.TryParse(dato, out _) || dato.Length != longitud) // Verifica que sea un número válido y con la longitud correcta.
                {
                    Console.WriteLine($"Por favor, ingresa un valor numérico válido de {longitud} dígitos.");
                    dato = null; // Reinicia el valor de dato para que el ciclo se repita.
                }
            } while (string.IsNullOrWhiteSpace(dato)); // Repite hasta que el dato sea válido.

            return dato; // Devuelve el dato numérico válido.
        }

        static void GuardarDatosEnArchivo(string datos) // Método para guardar los datos en un archivo.
        {
            using (StreamWriter writer = new StreamWriter("GPSInstalados.txt", true)) // Abre el archivo en modo "append".
            {
                writer.WriteLine(datos); // Escribe los datos en el archivo.
            }
        }

        static void MostrarRegistros() // Método para mostrar los registros guardados en el archivo.
        {
            string archivo = "GPSInstalados.txt"; // Nombre del archivo donde se guardan los registros.

            if (File.Exists(archivo)) // Verifica si el archivo existe.
            {
                string contenido = File.ReadAllText(archivo); // Lee el contenido completo del archivo.
                Console.WriteLine("\n=== Registros Guardados ===");
                Console.WriteLine(contenido); // Muestra el contenido de los registros.
            }
            else
            {
                Console.WriteLine("No hay registros guardados."); // Mensaje si no existen registros.
            }
        }

        static void BuscarRegistro() // Método para buscar un registro por IMEI o placa.
        {
            Console.Write("Ingresa el IMEI o Placa para buscar: ");
            string criterio = Console.ReadLine()?.Trim(); // Lee el criterio de búsqueda (IMEI o Placa).

            string archivo = "GPSInstalados.txt"; // Nombre del archivo donde se guardan los registros.

            if (File.Exists(archivo)) // Verifica si el archivo existe.
            {
                string[] lineas = File.ReadAllText(archivo).Split(new[] { "-----------------------------------" }, StringSplitOptions.RemoveEmptyEntries); // Lee el archivo y divide los registros.
                bool encontrado = false;

                foreach (string registro in lineas) // Recorre los registros para buscar coincidencias.
                {
                    if (registro.Contains(criterio)) // Si el registro contiene el criterio de búsqueda.
                    {
                        Console.WriteLine("\n=== Registro Encontrado ===");
                        Console.WriteLine(registro.Trim()); // Muestra el registro encontrado.
                        Console.WriteLine("---------------------------");
                        encontrado = true;
                    }
                }

                if (!encontrado) // Si no se encuentra ningún registro.
                {
                    Console.WriteLine("No se encontró ningún registro con el criterio ingresado.");
                }
            }
            else
            {
                Console.WriteLine("No hay registros guardados.");
            }
        }

        static bool EsValido(string texto) // Método que valida si un texto contiene caracteres no permitidos.
        {
            foreach (char c in texto)
            {
                if (!char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c) && c != '-') // Permite solo letras, dígitos, espacios y guiones.
                {
                    return false;
                }
            }
            return true; // Devuelve true si todos los caracteres son válidos.
        }
    }
}
