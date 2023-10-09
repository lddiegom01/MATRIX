using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    internal class Random
    {
        public int aleatorio(int min,int max)
        {
            Random random = new Random();
            return random.Next(min, max + 1);
    }
}
