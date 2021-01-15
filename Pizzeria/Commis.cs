using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria
{
    public class Commis : Personelle
    {
        private string etatCommis;
        private DateTime dateEmbauche;

        public Commis(string nomEmploye, string prenomEmploye, string adrEmploye, string numEmploye, string etatCommis, DateTime dateEmbauche) : base(nomEmploye, prenomEmploye, adrEmploye, numEmploye)
        {
            this.etatCommis = etatCommis;
            this.dateEmbauche = dateEmbauche;
        }
        public string EtatCommis
        {
            get { return etatCommis; }
        }
        public DateTime DateEmbauche
        {
            get { return dateEmbauche; }
        }
    }
}
