using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTP1.Entities
{
    class Cercle : Forme
    {
       
        public int Rayon { get; set; }

        public override double Aire => Rayon * Rayon * Math.PI;

        public override double Perimetre => 2 * Math.PI * Rayon;

        public override string ToString()
        {
            return $"Cercle de rayon {Rayon}" + Environment.NewLine + base.ToString();
        }

    }
}
