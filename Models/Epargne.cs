using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Epargne
    {
        // attributes
        private string _numero;
        private double _solde;
        private DateTime _dateDernierRetrait;
        private Personne _titulaire;

        // props
        public Personne Titulaire
        {
            get { return _titulaire; }
            set { _titulaire = value; }
        }

        public DateTime DateDernierRetrait
        {
            get { return _dateDernierRetrait; }
            private set { _dateDernierRetrait = value; }
        }

        public double Solde
        {
            get { return _solde; }
            private set { _solde = value; }
        }

        public string Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }

        // methods
        public void Retrait(double montant)
        {
            if (montant < 0) return;                        // exception montant negatif
            if (montant > Solde) return;                    // exception : solde insuffisant

            Solde -= montant;
            DateDernierRetrait = DateTime.Now;

        }
        public void Depot(double montant)
        {
            if (montant < 0) return;                        // exception montant negatif
 
            Solde += montant;
            
        }

        public static double operator +(double t, Epargne c)
        {
            return (t > 0 ? t : 0) + (c.Solde > 0 ? c.Solde : 0);
        }
    }
}
