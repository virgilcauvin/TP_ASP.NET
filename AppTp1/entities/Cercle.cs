using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTp1.entities
{
    public class Cercle : Forme
    {

        int rayon;
        public int Rayon { get => rayon; set => rayon = value; }
        double aire;
        double perimetre;

        public void Aire()
        {
            this.aire = Math.PI * (rayon * rayon);
        }

        public void Perimetre()
        {
            this.perimetre = 2 * Math.PI * rayon;
        }

        public override string ToString()
        {
            Aire();
            Perimetre();
            return String.Format("Cercle de rayon: {0}\n Aire: {1}\n Perimetre: {2}\n", this.rayon, this.aire, this.perimetre);
        }
    }
}
