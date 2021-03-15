using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    abstract public class Compte
    {
        // attributes
        private string _numero;
        private double _solde;
        private Personne _titulaire;

        // props
        public Personne Titulaire
        {
            get { return _titulaire; }
            set { _titulaire = value; }
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
        public virtual void Retrait(double montant) {
            Retrait(montant, 0D);
        }
        protected void Retrait(double montant, double ldc) {
            if (montant < 0) return;                        // exception montant negatif
            if (montant > Solde + ldc) return;              // exception : solde insuffisant

            Solde -= montant;

        }

        public void Depot(double montant)
        {
            if (montant < 0) return;                        // exception montant negatif

            Solde += montant;

        }

        protected abstract double CalculInteret();

        public void AppliquerInteret() {
            Solde += CalculInteret();
        }

        // operator
        public static double operator +(double t, Compte c)
        {
            return (t > 0 ? t : 0) + (c.Solde > 0 ? c.Solde : 0);
        }
    }
}
