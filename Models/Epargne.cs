using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Epargne : Compte
    {
        // attributes
        private DateTime _dateDernierRetrait;

        // props
        public DateTime DateDernierRetrait
        {
            get { return _dateDernierRetrait; }
            private set { _dateDernierRetrait = value; }
        }

        // methods
        public override void Retrait(double montant)
        {
            double oldSolde = Solde;
            base.Retrait(montant);

            if (oldSolde == Solde) return;

            DateDernierRetrait = DateTime.Now;

        }

        protected override double CalculInteret()
        {
            return Solde * 0.045D;
        }
    }
}
