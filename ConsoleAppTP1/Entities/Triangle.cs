using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTP1.Entities
{
    class Triangle : Forme
    {

        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }

        private double dp => (A + B + C) / 2d;
        public override double Aire => Math.Sqrt(dp * (dp - A) * (dp - B) * (dp - C));

        public override double Perimetre => A + B + C;

        public override string ToString()
        {
            return $"Triangle de coté A = {A}, B = {B}, C = {C}" + Environment.NewLine + base.ToString();
        }
    }
}
