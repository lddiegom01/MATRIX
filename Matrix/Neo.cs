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
    }
}
