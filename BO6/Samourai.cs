namespace BO
{
    public class Samourai
    {
        public int Id { get; set; }
        public int Force { get; set; }
        public string Nom { get; set; }
        public virtual Arme Arme { get; set; }
        public int Somme
        {
            get
            {
                if (Arme != null)
                {
                    return Force + Arme.Degats;
                }
                return Force;
            }
 
        }

    }
}
