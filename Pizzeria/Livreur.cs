using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria
{
    public class Livreur : Personelle
    {
        private string etatLivreur;
        private string moyenLivraison;

        public Livreur(string nomEmploye, string prenomEmploye, string adrEmploye, string numEmploye, string etatLivreur, string moyenLivraison) : base(nomEmploye, prenomEmploye, adrEmploye, numEmploye)
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
