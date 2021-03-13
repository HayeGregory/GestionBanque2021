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
                if (value < 0) return;
                
                _ligneDeCredit = value;
                
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
            if (montant < 0) return;                        // exception montant negatif
            if (montant > Solde + LigneDeCredit) return;    // exception : solde insuffisant

            Solde -= montant;

        }
        public void Depot(double montant)
        {
            if (montant < 0) return;                        // exception montant negatif
 
            Solde += montant;
            
        }
    }
}
