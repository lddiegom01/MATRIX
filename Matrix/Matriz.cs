using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    internal class Matriz
    {
        int filas;
        int columnas;
        List<Personaje> listaPersonajes = new List<Personaje>();

        public Matriz(int filas, int columnas)
        {
            this.filas = filas;
            this.columnas = columnas;
            this.listaPersonajes.Clear();
        }

        //Metodo que añade un personaje a la lista de personajes de la matriz 
        public void addPersonaje(Personaje personaje) 
        {
            this.listaPersonajes.Add(personaje);
        }

        //Devuelve solo el nombre de un personaje de la lista
        public string getNombreDePersonaje(int num)
        {
            return this.listaPersonajes[num].getNombre();
        }

        //Devuelve solo la ciudad de un personaje de la lista 
        public string getCiudadDelPersonaje(int num)
        {
            return this.listaPersonajes[num].getCiudad();
        }
    }
}
