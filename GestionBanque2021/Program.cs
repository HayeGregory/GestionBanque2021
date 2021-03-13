using Models;
using System;

namespace GestionBanque2021
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Gestion bancaire\n----------------");

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

            AffichageComptes(C1CA, C1CB, C2CA);
            C1CA.Depot(1000);
            C1CB.Depot(2000);
            C2CA.Depot(500);
            C1CA.Retrait(2000);
            AffichageComptes(C1CA, C1CB, C2CA);
        }

        private static void AffichageComptes(Courant C1CA, Courant C1CB, Courant C2CA)
        {
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine($"C1CA : {C1CA.Numero} | solde : {C1CA.Solde,2} | LDC : {C1CA.LigneDeCredit,2} | " +
                                $"titulaire : {C1CA.Titulaire.Prenom} {C1CA.Titulaire.Prenom}");
            Console.WriteLine($"C2CA : {C2CA.Numero} | solde : {C2CA.Solde,2} | LDC : {C2CA.LigneDeCredit,2} | " +
                                $"titulaire : {C2CA.Titulaire.Prenom} {C2CA.Titulaire.Prenom}");
            Console.WriteLine($"C1CB : {C1CB.Numero} | solde : {C1CB.Solde,2} | LDC : {C1CB.LigneDeCredit,2} | " +
                                $"titulaire : {C1CB.Titulaire.Prenom} {C1CB.Titulaire.Prenom}");
        }
    }
}
