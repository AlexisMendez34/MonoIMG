using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoIMG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Extraer extractor = new Extraer(); //Extraer la matriz de la imagen
            Construir construccion = new Construir(); //Crear la nueva imagen a partir de la matriz monocromática

            string archivo = null;
            int[,] matrix;
            char op = '-';
            do
            {
                Console.WriteLine(" -------------------------------");
                Console.WriteLine("|\t---MONO IMG---\t\t|");
                Console.WriteLine("|-------------------------------|");
                Console.WriteLine("|\ta) Iniciar\t\t|");
                Console.WriteLine("|\tb) Salir\t\t|");
                Console.WriteLine(" -------------------------------");
                Console.WriteLine("\nÚltimo rchivo: " + (String.IsNullOrEmpty(archivo) ? "Ninguno" : archivo));

                Console.WriteLine("Puede usar la imagen 'casillas.png' como prueba\no puede guardar sus propias imagenes\ndeben ser imagenes cuadradas"); //Ruta de la carpeta imagenes /Proyecto/imagenes

                Console.Write("\nIngrese un inciso: ");
                try
                {
                    op = char.Parse(Console.ReadLine().ToLower());
                }
                catch (FormatException ex)
                {
                    op = '-';
                    Console.Clear();
                    Console.WriteLine("Ha ocurrido un error: " + ex.Message);
                    Console.WriteLine("Presione cualquier tecla para continuar");
                    Console.ReadKey();
                }
                finally
                {
                    Console.Clear();
                }

                switch (op)
                {
                    case 'a':
                        Console.Write("Ingrese el nombre de la imagen: ");
                        archivo = Console.ReadLine();
                        matrix = extractor.ExtIMG(archivo);
                        construccion.GuardarImagenDesdeMatriz("../../imagenes/monocromatica_" + archivo, matrix);
                        Console.Clear();
                        break;
                    case 'b':
                        Console.WriteLine("Adios :)");
                        Console.WriteLine("Presione cualquier tecla para salir del programa");
                        Console.ReadKey();
                        break;
                    case '-':
                        break;
                    default:
                        Console.WriteLine("Inciso invalido");
                        break;
                }
            }
            while (op != 'b');

            //Hay que reutilizar el código de MatrixIMG para poder extraer la imagen, a su vez que se hace monocromática

            //Por ultimo, se debe realizar una interfaz que permita al usuario elegir que proceso realizar.
        }
    }
}
