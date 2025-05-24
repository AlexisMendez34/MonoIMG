using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MonoIMG
{
    internal class Extraer
    {
        int[,] matrix;
        public int[,] ExtIMG(string archivo)
        {
            string img = "../../imagenes/" + archivo;
            if (!File.Exists(img))
            {
                Console.WriteLine("Imagen no encontrada");
                matrix = new int[0, 0];
                Console.WriteLine("Presione cualquier tecla para continuar");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Extracción de matriz preparada\n...");

                //Extracción de matriz a partir de la imagen
                Bitmap imgBit = new Bitmap(img);
                int tamImg = imgBit.Width;
                if (imgBit.Width != imgBit.Height)
                {
                    Console.WriteLine("No es un a imagen cuadrada.");
                    matrix = new int[0, 0];
                    Console.WriteLine("Presione cualquier tecla para continuar");
                    Console.ReadLine();
                    return matrix;
                }
                matrix = new int[tamImg, tamImg];

                //Recorrido del arreglo bidimensional (matriz) para almacenar los pixeles de la imagen monocromática en la matriz
                for (int i = 0; i < tamImg; i++)
                {
                    for (int j = 0; j < tamImg; j++)
                    {
                        Color color = imgBit.GetPixel(j, i);
                        int pixel = (color.R + color.G + color.B) / 3;
                        matrix[j, i] = pixel;
                    }
                }
                Console.WriteLine("Extracción exitosa!");
                Console.WriteLine("...");
            }
            return matrix;
        }
    }
}
