using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTp1.entities
{
    class Rectangle : Forme
    {
        public int Largeur { get => Largeur; set => Largeur = value; }
        public int Longueur { get => Longueur; set => Longueur = value; }

        int aire;
        int perimetre;

        public void Aire()
        {
            this.aire = Longueur * Largeur;
        }

        public void Perimetre()
        {
            this.perimetre = (2 * Longueur) + (2 * Largeur);
        }

        public override string ToString()
        {
            Aire();
            Perimetre();
            return String.Format("Rectangle de largeur={0} et de longueur={1}\n Aire: {2}\n Perimetre: {3}",this.Largeur, this.Longueur, this.aire, this.perimetre);
        }
    }
}
