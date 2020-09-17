using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTP1.Entities
{

    class Rectangle : Forme
    {
        public int Longueur { get; set; }
        public virtual int Largeur { get; set; }

        public override double Aire => Longueur * Largeur;

        public override double Perimetre => 2 * (Longueur + Largeur);

        public override string ToString()
        {
            return ToString(false);
        }

        protected string ToString(bool fromCarre)
        {
            if (fromCarre)
                return base.ToString();
            return $"Rectangle de longueur={Longueur} et largeur={Largeur}" + Environment.NewLine + base.ToString();
        }
    }
}
