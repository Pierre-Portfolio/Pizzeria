using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria
{
    class Livreur : Personelle
    {
        private string etatLivreur;
        private string moyenLivraison;

        public Livreur(string nomEmploye, string etatLivreur, string moyenLivraison) : base(nomEmploye)
        {
            this.etatLivreur = etatLivreur;
            this.moyenLivraison = moyenLivraison;
        }

        public string EtatLivreur
        {
            get { return etatLivreur; }
        }
        public string MoyenLivraison
        {
            get { return moyenLivraison; }
        }
    }
}
