using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria
{
    class Commis : Personelle
    {
        private string etatCommis;
        private DateTime dateEmbauche;

        public Commis(string NomEmploye, string etatCommis, DateTime dateEmbauche) : base(NomEmploye)
        {
            this.etatCommis = etatCommis;
            this.dateEmbauche = dateEmbauche;
        }
    }
}
