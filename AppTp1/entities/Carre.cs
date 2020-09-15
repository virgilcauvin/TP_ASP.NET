using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTp1.entities
{
    class Carre : Forme
    {
        public int Longueur { get => Longueur; set => Longueur = value; }
        double aire;
        double perimetre;

        public void Aire()
        {
            this.aire = Longueur * Longueur;
        }

        public void Perimetre()
        {
            this.perimetre = 4 * Longueur;
        }

        public override string ToString()
        {
            Aire();
            Perimetre();
            return String.Format("Carré de coté={0}\n Aire: {1}\n Perimetre: {2}", this.Longueur, this.aire, this.perimetre);
        }
    }
}
