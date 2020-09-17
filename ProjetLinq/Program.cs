using ProjetLinq.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLinq
{
    class Program
    {
        private static List<Auteur> ListeAuteurs = new List<Auteur>();
        private static List<Livre> ListeLivres = new List<Livre>();
        static void Main(string[] args)
        {
            InitialiserDatas();

            Console.WriteLine("1. Afficher la liste des prénoms des auteurs dont le nom commence par G");
            foreach(var auteur in ListeAuteurs.Where(x => x.Nom.StartsWith("G")))
                {
                Console.WriteLine(auteur.Prenom);
                }
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine("2. Afficher l’auteur ayant écrit le plus de livres");
            var MeilleurAuteur = ListeLivres.GroupBy(x => x.Auteur).OrderByDescending(x=>x.Count()).FirstOrDefault().Key;
            Console.WriteLine(string.Format("{0} {1}", MeilleurAuteur.Prenom, MeilleurAuteur.Nom)); 
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine("3. Afficher le nombre moyen de pages par livre par auteur");
            var livresParAuteur = ListeLivres.GroupBy(x => x.Auteur);
            foreach(var item in livresParAuteur)
            {
                Console.WriteLine($"{item.Key.Prenom} {item.Key.Nom} moyenne de pages = {item.Average(x=>x.NbPages)} ");
            }
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine("4. Afficher le titre du livre avec le plus de pages");
            var livreLePlusLong = ListeLivres.OrderByDescending(x => x.NbPages).FirstOrDefault();
            Console.WriteLine(livreLePlusLong.Titre);
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine("5. Afficher combien ont gagné les auteurs en moyenne(moyenne des factures)");
            var profitMoyenne = ListeAuteurs.Average(f => f.Factures.Sum(m => m.Montant));
            Console.WriteLine(profitMoyenne);
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine("6. Afficher les auteurs et la liste de leurs livres");
            foreach(var auteur in ListeAuteurs)
            {
                Console.WriteLine(string.Format("{0} {1}", auteur.Prenom, auteur.Nom));
                foreach (var livre in ListeLivres.Where(a => a.Auteur == auteur))
                {
                    Console.WriteLine("      " + livre.Titre);
                }
            }
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine("7. Afficher les titres de tous les livres triés par ordre alphabétique");
            ListeLivres.Select(t => t.Titre).OrderBy(x => x).ToList().ForEach(Console.WriteLine);
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine("8. Afficher la liste des livres dont le nombre de pages est supérieur à la moyenne");
            var nbPageMoyenne = ListeLivres.Average(p=>p.NbPages);
            foreach(var item in ListeLivres.Where(p=>p.NbPages>nbPageMoyenne))
            {
                Console.WriteLine(item.Titre);
            }
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine("9. Afficher l'auteur ayant écrit le moins de livres");
            var auteurMoinsDeLivres = ListeAuteurs.OrderBy(x => ListeLivres.Count(l => l.Auteur == x)).FirstOrDefault();
            Console.WriteLine($"{auteurMoinsDeLivres.Prenom} {auteurMoinsDeLivres.Nom}");

            Console.ReadKey();
        }
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

    }
}

