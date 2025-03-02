using System;
using System.Collections;

namespace UsageCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedList lstEmployé = new SortedList();
            lstEmployé.Add("372288Z", new Employé { Nom = "Fall ",
                PréNom = "Racine ",
                Matricule = "372288Z" });
            Employé layssa = new Employé()
            {
                Nom = "Diaw ",
                PréNom= "Layssa ",
                Matricule = "501603A"
                };
            Employé ngor = new Employé()
                {
                Nom = "Sène ",
                PréNom = "Ngor ",
                Matricule = "500125B"
                };
            lstEmployé.Add(layssa.Matricule, layssa);
            lstEmployé.Add(ngor.Matricule, ngor);

            Employé unEmployé = (Employé)lstEmployé["372288Z"];

            if (unEmployé != null)
            {
                Console.WriteLine($"Matricule:{unEmployé.Matricule}, Prénom: {unEmployé.PréNom}, Nom: {unEmployé.Nom}, ");

                }

            Console.WriteLine(  "Appuyer sur Entrée pour afficher la liste des employés ");
            Console.ReadLine();

            foreach (DictionaryEntry employé in lstEmployé)
            {
                Employé autreEmployé = (Employé)employé.Value;
                Console.WriteLine($"Matricule: {autreEmployé.Matricule}, PréNom: {autreEmployé.PréNom},Nom: {autreEmployé.Nom}");
            }
            Console.ReadLine();
        }
    }
}
