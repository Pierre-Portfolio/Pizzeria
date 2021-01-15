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
