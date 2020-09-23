using System.Collections.Generic;

namespace BO
{
    public class Samourai : IdAbstract
    {
        public int Force { get; set; }
        public string Nom { get; set; }
        public virtual Arme Arme { get; set; }
        public virtual List<ArtMartial> ArtMartials { get; set; } = new List<ArtMartial>();
        public int Somme
        {
            get
            {
                if (Arme != null)
                {
                    return (Force + Arme.Degats) * (ArtMartials.Count);
                }
                return (Force * ArtMartials.Count);
            }
 
        }

    }
}
