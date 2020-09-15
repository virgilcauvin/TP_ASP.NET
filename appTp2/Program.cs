using AppTp2.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appTp2
{
    public class Program
    {
        private static List<Auteur> ListeAuteurs = new List<Auteur>();
        private static List<Livre> ListeLivres = new List<Livre>();

        private static void InitialiserDatas()
        {
            ListeAuteurs.Add(new Auteur("GROUSSARD", "Thierry"));
            ListeAuteurs.Add(new Auteur("GABILLAUD", "Jérôme"));
            ListeAuteurs.Add(new Auteur("HUGON", "Jérôme"));
            ListeAuteurs.Add(new Auteur("ALESSANDRI", "Olivier"));
            ListeAuteurs.Add(new Auteur("de QUAJOUX", "Benoit"));
            ListeLivres.Add(new Livre(1, "C# 4", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 533));
            ListeLivres.Add(new Livre(2, "VB.NET", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 539));
            ListeLivres.Add(new Livre(3, "SQL Server 2008", "SQL, Transact SQL", ListeAuteurs.ElementAt(1), 311));
            ListeLivres.Add(new Livre(4, "ASP.NET 4.0 et C#", "Sous visual studio 2010", ListeAuteurs.ElementAt(3), 544));
            ListeLivres.Add(new Livre(5, "C# 4", "Développez des applications windows avec visual studio 2010", ListeAuteurs.ElementAt(2), 452));
            ListeLivres.Add(new Livre(6, "Java 7", "les fondamentaux du langage", ListeAuteurs.ElementAt(0), 416));
            ListeLivres.Add(new Livre(7, "SQL et Algèbre relationnelle", "Notions de base", ListeAuteurs.ElementAt(1), 216));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3500, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3200, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(1).addFacture(new Facture(4000, ListeAuteurs.ElementAt(1)));
            ListeAuteurs.ElementAt(2).addFacture(new Facture(4200, ListeAuteurs.ElementAt(2)));
            ListeAuteurs.ElementAt(3).addFacture(new Facture(3700, ListeAuteurs.ElementAt(3)));
        }

        public static void Main(string[] args)
        {
            InitialiserDatas();

            foreach (var item in ListeAuteurs.Where(x => x.Nom.First() == 'G'))
            {
                Console.WriteLine("Prénom des auterurs dont le nom commence par la lettre G: " + item.Prenom);
            };

            Console.WriteLine("/////////////////////////////////\n");

            var bob = "";
            var bab = 0;
            foreach (var item in ListeLivres.GroupBy(x => x.Auteur))
            {
                if (item.Count() > bab)
                {
                    bob = item.Key.Nom + " " + item.Key.Prenom;
                    bab = item.Count();
                }
            }
            Console.WriteLine(bob + " " + bab);


            Console.WriteLine("/////////////////////////////////\n");

            var pages = 0;
            var livres = 0;
            foreach (var item in ListeLivres.GroupBy(x => x.Auteur))
            {
                livres = 0;
                foreach (var item2 in item)
                {
                    pages += item2.NbPages;
                }
                 livres = pages / item.Count();
                Console.WriteLine("Nombre de pages moyens des livres par auteurs"+ " " + livres);
            }

           



            Console.ReadLine();

        }
    }
}
