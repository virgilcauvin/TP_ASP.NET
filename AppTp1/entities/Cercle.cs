using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTp1.entities
{
    public class Cercle : Forme
    {
        public int Rayon { get => Rayon; set => Rayon = value; }
        double aire;
        double perimetre;

        public void Aire()
        {
            this.aire = Math.PI * (Rayon * Rayon);
        }

        public void Perimetre()
        {
            this.perimetre = 2 * Math.PI * Rayon;
        }

        public override string ToString()
        {
            Aire();
            Perimetre();
            return String.Format("Cercle de rayon: {0}\n Aire: {1}\n Perimetre: {2}\n", this.Rayon, this.aire, this.perimetre);
        }
    }
}
