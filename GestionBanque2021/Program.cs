using Models;
using System;
using System.Collections.Generic;

namespace GestionBanque2021
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Gestion bancaire\n----------------");

            #region test Personne
            Personne ClientA = new Personne()
            {
                Nom = "Haye",
                Prenom = "Gregory",
                DateNaiss = new DateTime(1979, 06, 14)
            };
            Personne ClientB = new Personne()
            {
                Nom = "Hubert",
                Prenom = "Emmanuelle",
                DateNaiss = new DateTime(1975, 10, 25)
            };

            Console.WriteLine($"Client A: {ClientA.Nom} {ClientA.Prenom} | {ClientA.DateNaiss } ");
            Console.WriteLine($"Client B: {ClientB.Nom} {ClientB.Prenom} | {ClientB.DateNaiss } ");
            #endregion

            #region test Courant/Epargne depot retrait
            Courant C1CA = new Courant
            {
                Numero = "1111",
                LigneDeCredit = 1000,
                Titulaire = ClientA
            };
            Courant C1CB = new Courant
            {
                Numero = "3333",
                LigneDeCredit = 1000,
                Titulaire = ClientB
            };
            Courant C2CA = new Courant
            {
                Numero = "2222",
                LigneDeCredit = 0,
                Titulaire = ClientA
            };
            Epargne CE1CA = new Epargne
            {
                Numero = "9999",
                Titulaire = ClientA
            };
            Epargne CE1CB = new Epargne
            {
                Numero = "8888",
                Titulaire = ClientA
            };

            AffichageComptes(C1CA, C1CB, C2CA, CE1CA, CE1CB);
            C1CA.Depot(1000);
            C1CB.Depot(2000);
            C2CA.Depot(500);
            C1CA.Retrait(2000);

            CE1CA.Depot(777);
            CE1CB.Depot(555);
            CE1CA.Retrait(77);
            CE1CB.Retrait(55);
            AffichageComptes(C1CA, C1CB, C2CA, CE1CA, CE1CB); 
            #endregion

            #region Test banque , indexeur
            Banque ING = new Banque() { Nom = "ING" };
            ING.Ajouter(C1CA);
            ING.Ajouter(C1CA);
            ING.Ajouter(C2CA);
            ING.Ajouter(C1CB);
            //ING.Ajouter(CE1CB);
            //ING.Ajouter(CE1CA);

            AfficherComptes(ING);
            ING["2255"]?.Depot(1500);   // ? pour ne pas executer la methode si l'indexeur renvoi null
            ING["2255"]?.Retrait(100);
            double soldeTmp = ING["1111"].Solde;
            // ING["1111"] = C2CA; // indexeur set a private sinon , on peut remplacer des comtpes :DD

            AfficherComptes(ING);
            #endregion

            #region test Surcharge operator
            ING["1111"].Depot(5000);
            ING["3333"].Retrait(2500);
            AfficherComptes(ING);

            Console.WriteLine($"Avoir des comptes de {ClientA.Prenom} : {ING.AvoirDesComptes(ClientA)}");
            Console.WriteLine($"Avoir des comptes de {ClientB.Prenom} : {ING.AvoirDesComptes(ClientB)}");

            #endregion
        }

        private static void AfficherComptes(Banque banque)
        {
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine($"Liste des comptes de la banque {banque.Nom} : ");
            foreach (Courant compte in banque.Comptes.Values)
            {
                Console.WriteLine($"N° {compte.Numero} | solde : {compte.Solde, 10} | LDC : {compte.LigneDeCredit,10} | " +
                                $"titulaire : {compte.Titulaire.Prenom} {compte.Titulaire.Prenom}");
            }
        }

        private static void AffichageComptes(Courant C1CA, Courant C1CB, Courant C2CA, Epargne CE1CA, Epargne CE1CB)
        {
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine($"C1CA : {C1CA.Numero} | solde : {C1CA.Solde,2} | LDC : {C1CA.LigneDeCredit,2} | " +
                                $"titulaire : {C1CA.Titulaire.Prenom} {C1CA.Titulaire.Prenom}");
            Console.WriteLine($"C2CA : {C2CA.Numero} | solde : {C2CA.Solde,2} | LDC : {C2CA.LigneDeCredit,2} | " +
                                $"titulaire : {C2CA.Titulaire.Prenom} {C2CA.Titulaire.Prenom}");
            Console.WriteLine($"C1CB : {C1CB.Numero} | solde : {C1CB.Solde,2} | LDC : {C1CB.LigneDeCredit,2} | " +
                                $"titulaire : {C1CB.Titulaire.Prenom} {C1CB.Titulaire.Prenom}");
            Console.WriteLine($"CE1CA : {CE1CA.Numero} | solde : {CE1CA.Solde,2} | Date Retrait : {CE1CA.DateDernierRetrait,2} | " +
                                $"titulaire : {CE1CA.Titulaire.Prenom} {CE1CA.Titulaire.Prenom}");
            Console.WriteLine($"CE1CB : {CE1CB.Numero} | solde : {CE1CB.Solde,2} | Date Retrait : {CE1CB.DateDernierRetrait,2} | " +
                                $"titulaire : {CE1CB.Titulaire.Prenom} {CE1CB.Titulaire.Prenom}");

        }
    }
}
