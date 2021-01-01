using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria
{
    class Livreur : Personelle
    {
        private string etatLivreur;
        private string moyenEmbauche;

        public Livreur(string nomEmploye, string etatLivreur, string moyenEmbauche) : base(nomEmploye)
        {
            this.etatLivreur = etatLivreur;
            this.moyenEmbauche = moyenEmbauche;
        }

        public string EtatLivreur
        {
            get { return etatLivreur; }
            set { etatLivreur = value; }
        }
        public string DateEmbauche
        {
            get { return moyenEmbauche; }
            set { moyenEmbauche = value; }
        }
    }
}
