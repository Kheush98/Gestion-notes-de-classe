using System;
using System.Collections;

namespace UsageCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            int lignesParPage = DemanderNombreLignesParPage();

            SortedList listeEtudiants = new SortedList();

            SaisirEtudiants(listeEtudiants);

            AfficherEtudiants(listeEtudiants, lignesParPage);
        }

        static int DemanderNombreLignesParPage()
        {
            int lignes;
            do
            {
                Console.Write("Nombre de lignes par page (1-15, défaut 5) : ");
                string input = Console.ReadLine();
                
                if (string.IsNullOrWhiteSpace(input))
                    return 5;

                if (int.TryParse(input, out lignes) && lignes >= 1 && lignes <= 15)
                    return lignes;

                Console.WriteLine("Nombre invalide. Réessayez.");
            } while (true);
        }

        static void SaisirEtudiants(SortedList listeEtudiants)
        {
            while (true)
            {
                Console.Write("Voulez-vous ajouter un étudiant ? (O/N) : ");
                if (Console.ReadLine().ToUpper() != "O")
                    break;

                Etudiant etudiant = new Etudiant();
                
                Console.Write("Numéro d'ordre : ");
                etudiant.NO = Console.ReadLine();

                Console.Write("Prénom : ");
                etudiant.Prénom = Console.ReadLine();

                Console.Write("Nom : ");
                etudiant.Nom = Console.ReadLine();

                Console.Write("Note Contrôle Continu : ");
                etudiant.NoteCC = double.Parse(Console.ReadLine());

                Console.Write("Note Devoir : ");
                etudiant.NoteDevoir = double.Parse(Console.ReadLine());

                listeEtudiants.Add(etudiant.NO, etudiant);
            }
        }

        static void AfficherEtudiants(SortedList listeEtudiants, int lignesParPage)
        {
            double sommeMoyennes = 0;
            int compteur = 0;

            foreach (DictionaryEntry entry in listeEtudiants)
            {
                Etudiant etudiant = (Etudiant)entry.Value;
                double moyenne = etudiant.CalculerMoyenne();
                sommeMoyennes += moyenne;
                compteur++;

                Console.WriteLine($"NO: {etudiant.NO}, " +
                                  $"Prénom: {etudiant.Prénom}, " +
                                  $"Nom: {etudiant.Nom}, " +
                                  $"Note CC: {etudiant.NoteCC}, " +
                                  $"Note Devoir: {etudiant.NoteDevoir}, " +
                                  $"Moyenne: {moyenne:F2}");

                if (compteur % lignesParPage == 0)
                {
                    Console.WriteLine("Appuyez sur une touche pour continuer...");
                    Console.ReadKey();
                }
            }

            if (compteur > 0)
            {
                double moyenneClasse = sommeMoyennes / compteur;
                Console.WriteLine($"\nMoyenne de la classe : {moyenneClasse:F2}");
            }

            Console.WriteLine("Fin du programme. Appuyez sur une touche pour quitter.");
            Console.ReadKey();
        }
    }
}