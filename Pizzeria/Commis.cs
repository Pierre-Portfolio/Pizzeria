using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria
{
    class Commis : Personelle
    {
        private string etatCommis;
        private DateTime dateEmbauche;

        public Commis(string nomEmploye, string etatCommis, DateTime dateEmbauche) : base(nomEmploye)
        {
            this.etatCommis = etatCommis;
            this.dateEmbauche = dateEmbauche;
        }
        public string EtatCommis
        {
            get { return etatCommis; }
            set { etatCommis = value; }
        }
        public DateTime DateEmbauche
        {
            get { return dateEmbauche; }
            set { dateEmbauche = value; }
        }
    }
}
