using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTp1.entities
{
    class Triangle : Forme
    {
        int a;
        int b;
        int c;
        public int A { get => a; set => a = value; }
        public int B { get => b; set => b = value; }
        public int C { get => c; set => c = value; }

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
            return String.Format("Triangle de coté A={0} B={1} C={2}\n Aire: {3}\n Perimetre: {4}", this.a, this.b, this.c, this.aire, this.perimetre) ;
        }
    }
}
