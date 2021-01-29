using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria
{
    public class Commis : Personelle
    {
        public enum etat_commis
        {
            surplace,
            enconges,
        }

        private etat_commis etatCommis;
        private DateTime dateEmbauche;

        public Commis(string nomEmploye, string prenomEmploye, string adrEmploye,string mdpEmploye, string numEmploye, etat_commis etatCommis, DateTime dateEmbauche) : base(nomEmploye, prenomEmploye, adrEmploye, mdpEmploye, numEmploye)
        {
            this.etatCommis = etatCommis;
            this.dateEmbauche = dateEmbauche;
        }
        public etat_commis EtatCommis
        {
            get { return etatCommis; }
            set { this.etatCommis = value; }
        }
        public DateTime DateEmbauche
        {
            get { return dateEmbauche; }
        }
    }
}
