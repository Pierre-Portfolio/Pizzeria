using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria
{
    public class Livreur : Personel
    {
        public enum etat_livreur
        {
            surplace,
            enconges,
            enlivraison,
        }
        private etat_livreur etatLivreur;
        private string moyenLivraison;

        public Livreur(string nomEmploye, string prenomEmploye, string adrEmploye, string mdpEmploye, string numEmploye, etat_livreur etatLivreur, string moyenLivraison) : base(nomEmploye, prenomEmploye, adrEmploye, mdpEmploye, numEmploye)
        {
            this.etatLivreur = etatLivreur;
            this.moyenLivraison = moyenLivraison;
        }

        public etat_livreur EtatLivreur
        {
            get { return etatLivreur; }
            set { this.etatLivreur = value; }
        }
        public string MoyenLivraison
        {
            get { return moyenLivraison; }
            set { this.moyenLivraison = value; }
        }

        public string GetLineCSV()
        {
            return nomEmploye + ";" + prenomEmploye + ";" + mdpEmploye + ";" + adrEmploye + ";" + numEmploye + ";" + etatLivreur.ToString() + ";" + moyenLivraison;
        }
    }
}
