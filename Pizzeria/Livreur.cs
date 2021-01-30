using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Pizzeria
{
    public class Livreur : Personel , INotifyPropertyChanged
    {
        public enum etat_livreur
        {
            surplace,
            enconges,
            enlivraison,
        }
        private etat_livreur etatLivreur;
        //private string moyenLivraison;

        public enum moyen_Livraison
        {
            velo,
            scooter,
            trotinette,
        }
        private moyen_Livraison moyenLivraison;

        public Livreur(string nomEmploye, string prenomEmploye, string adrEmploye, string mdpEmploye, string numEmploye, etat_livreur etatLivreur, moyen_Livraison moyenLivraison, int cumul = 0) : base(nomEmploye, prenomEmploye, adrEmploye, mdpEmploye, numEmploye, cumul)
        {
            this.etatLivreur = etatLivreur;
            this.moyenLivraison = moyenLivraison;
        }

        public etat_livreur EtatLivreur
        {
            get { return etatLivreur; }
            set { this.etatLivreur = value; OnPropertyChanged("EtatLivreur"); }
        }
        public moyen_Livraison MoyenLivraison
        {
            get { return moyenLivraison; }
            set { this.moyenLivraison = value; OnPropertyChanged("MoyenLivraison"); }
        }

        public string GetLineCSV()
        {
            return nomEmploye + ";" + prenomEmploye + ";" + mdpEmploye + ";" + adrEmploye + ";" + numEmploye + ";" + etatLivreur.ToString() + ";" + moyenLivraison+";"+cumulTache;
        }
    }
}
