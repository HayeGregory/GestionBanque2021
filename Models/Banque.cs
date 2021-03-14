using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Banque
    {
        // attributes
        private readonly Dictionary<string, Courant> _comptes = new Dictionary<string, Courant>();
        
        // props
        public string Nom { get; set; }
        public Dictionary<string, Courant> Comptes
        {
            get
            {
                return _comptes;
            }
        }

        // indexeurs
        public Courant this[string index] {
            get {
                if (!Comptes.ContainsKey(index)) return null; // exception : compte inexistant
                return Comptes[index]; 
            }
            private set { Comptes[index] = value; }
        }

        // methods
        public void Ajouter(Courant compte) {
            if (_comptes.ContainsKey(compte.Numero)) return;    // exception : compte existant

            Comptes.Add(compte.Numero, compte);
        }

        public bool Supprimer(string numero) {
            return Comptes.Remove(numero);
        }

        public double AvoirDesComptes(Personne titulaire) {
            double total = 0;

            foreach (Courant compte in Comptes.Values)
            {
                if (compte.Titulaire != titulaire) continue;
                total += compte;
            }

            return total;
        }


    }
}
