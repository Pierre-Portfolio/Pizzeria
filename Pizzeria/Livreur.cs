using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria
{
    class Livreur : Personelle
    {
        private string etatLivreur;
        private DateTime moyenEmbauche;

        public Livreur(string NomEmploye, string etatLivreur, DateTime moyenEmbauche) : base(NomEmploye)
        {
            this.etatLivreur = etatLivreur;
            this.moyenEmbauche = moyenEmbauche;
        }
    }
}
