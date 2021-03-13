using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Courant
    {
        // attributes
        private string _numero;
        private double _solde;
        private double _ligneDeCredit;
        private Personne _titulaire;

        // props
        public Personne Titulaire
        {
            get { return _titulaire; }
            set { _titulaire = value; }
        }

        public double LigneDeCredit
        {
            get { return _ligneDeCredit; }
            set
            {
                if (value > 0)
                {
                    _ligneDeCredit = value;
                }
            }
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
            if (montant > 0)
            {
                if (Solde + LigneDeCredit >= montant)
                {
                    Solde -= montant;
                }
                else
                {
                    // exception : solde insuffisant
                }
            }
            else
            {
                // exception montant negatif
            }
        }
        public void Depot(double montant)
        {
            if (montant > 0)
            {
                Solde += montant;
            }
            else
            {
                // exception montant negatif
            }
        }
    }
}
