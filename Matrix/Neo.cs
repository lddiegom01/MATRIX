using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    internal class Neo : Personaje
    {
        int confianza;
        bool elegido;

        public Neo(bool elegido, int mortalidad, int edad) : base (mortalidad, edad)
        {
            this.nombre="Neo";
            this.confianza=50;
            this.elegido=elegido;
        }

        public bool isElegido()
        {
            int w = RandomNumber.Aleatorio(0, 1);
            if (w == 0) 
            {
                elegido=false;
            } 
            else if (w == 1) 
            {
                elegido=true;
            }
            return elegido;
        }
        /**
        static bool SonCasillasAdyacentesNulas(int[,] matriz, int fila, int columna, int filas, int columnas)
        {
            // Check adjacent squares for null and move Personaje
            if (currentRow - 1 >= 0 && matrix[currentRow - 1, currentCol] == 0)
            {
                matrix[currentRow - 1, currentCol] = newPersonaje;
                matrix[currentRow, currentCol] = 0;
                currentRow = currentRow - 1;
            }
            else if (currentRow + 1 < matrix.GetLength(0) && matrix[currentRow + 1, currentCol] == 0)
            {
                matrix[currentRow + 1, currentCol] = newPersonaje;
                matrix[currentRow, currentCol] = 0;
                currentRow = currentRow + 1;
            }
            else if (currentCol - 1 >= 0 && matrix[currentRow, currentCol - 1] == 0)
            {
                matrix[currentRow, currentCol - 1] = newPersonaje;
                matrix[currentRow, currentCol] = 0;
                currentCol = currentCol - 1;
            }
            else if (currentCol + 1 < matrix.GetLength(1) && matrix[currentRow, currentCol + 1] == 0)
            {
                matrix[currentRow, currentCol + 1] = newPersonaje;
                matrix[currentRow, currentCol] = 0;
                currentCol = currentCol + 1;
            }
        }
        */
        /**
        public void moverNeo(int xneo, int yneo) 
        {
            if(isElegido())
            {
                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        int nuevaFila = fila + i;
                        int nuevaColumna = columna + j;

                        // Verificar límites de la matriz
                        if (nuevaFila >= 0 && nuevaFila < filas && nuevaColumna >= 0 && nuevaColumna < columnas)
                        {
                            // Verificar si la casilla adyacente no es nula
                            if (matriz[nuevaFila, nuevaColumna] != 0)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
        }*/
    }
}
