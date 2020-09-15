using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTp1.entities
{
    class Triangle : Forme
    {
        public int A { get => A; set => A = value; }
        public int B { get => B; set => B = value; }
        public int C { get => C; set => C = value; }

        double aire;
        double perimetre;

        public void Aire()
        {
            
        }

        public void Perimetre()
        {
            
        }

        public override string ToString()
        {
            Aire();
            Perimetre();
            return String.Format("Triangle de coté A={0} B={1} C={2}\n Aire: {3}\n Perimetre: {4}", this.A, this.B, this.C, this.aire, this.perimetre) ;
        }
    }
}
