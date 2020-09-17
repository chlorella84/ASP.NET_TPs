using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTP1.Entities
{
    public abstract class Forme
    {
        public abstract double Aire { get; }
        public abstract double Perimetre { get; }

        public override String ToString()
        {
            return $"Aire = {Aire}" + Environment.NewLine + $"Périmètre = {Perimetre}" + Environment.NewLine;
        }

        


    }
}
