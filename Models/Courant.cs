using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Courant : Compte
    {
        // attributes
        private double _ligneDeCredit;

        // props
        public double LigneDeCredit
        {
            get { return _ligneDeCredit; }
            set
            {
                if (value < 0) return;
                
                _ligneDeCredit = value;

            }
        }

        // methods
        public override void Retrait(double montant)
        {
            base.Retrait(montant, LigneDeCredit);
        }
    }
}
