using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTp1.entities
{
    class Rectangle : Forme
    {
        int largeur;
        int longueur;
        public int Largeur { get => largeur; set => largeur = value; }
        public int Longueur { get => longueur; set => longueur = value; }

        int aire;
        int perimetre;

        public void Aire()
        {
            this.aire = longueur * largeur;
        }

        public void Perimetre()
        {
            this.perimetre = (2 * longueur) + (2 * largeur);
        }

        public override string ToString()
        {
            Aire();
            Perimetre();
            return String.Format("Rectangle de largeur= {0} et de longueur= {1}\n Aire: {2}\n Perimetre: {3}\n",this.largeur, this.longueur, this.aire, this.perimetre);
        }
    }
}
