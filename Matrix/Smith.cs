using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    internal class Smith : Personaje
    {
        int capaInfecMax;
        int capaInfec;
        
        public Smith(int capacidad, int mortalidad, int edad) : base(mortalidad, edad) 
        {
            this.nombre="Smith";
            this.capaInfecMax = capacidad;
            this.capaInfec=0;
        }


        //Devuelve la capacidad de infectar para comprobar a cuantos puede asesinar vilmente
        int getCapaInfec() { return capaInfec; }    

        //Actualiza la capacidad de infectar 
        void setCapaInfec(int numero) { this.capaInfec = numero; }
    }
}
