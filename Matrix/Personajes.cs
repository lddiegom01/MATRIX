using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class Personajes
    {
        internal class Localizacion
        {
            private int latitud;
            private int altitud;
            private string ciudad;
            public Localizacion(string ciu)
            {
                this.latitud = Random.aleatorio(-90, 90);
                this.altitud = Random.aleatorio(-180,180); 
                this.ciudad = ciu;
            }
        }

        protected int mortalidad;
        Localizacion localizacion;
        protected int edad;
        protected int mortem;
        protected int nombre;

        public Personajes(int mortalidad, int alt, int lat, string ciu, int edad, int mortem)
        {
            this.mortalidad=mortalidad;
            this.localizacion= new Localizacion(lat,alt,ciu);
            this.edad=edad;
            this.mortem=mortem;
            this.nombre;
        }
    }
}
