using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Pizzeria
{
    public class Commis : Personel,ISauvegardable , INotifyPropertyChanged
    {
        public enum etat_commis
        {
            surplace,
            enconges,
        }

        private etat_commis etatCommis;
        private DateTime dateEmbauche;

        public Commis(string nomEmploye, string prenomEmploye, string adrEmploye,string mdpEmploye, string numEmploye, etat_commis etatCommis, DateTime dateEmbauche, int cumul=0) : base(nomEmploye, prenomEmploye, adrEmploye, mdpEmploye, numEmploye, cumul)
        {
            this.etatCommis = etatCommis;
            this.dateEmbauche = dateEmbauche;
        }

        public etat_commis EtatCommis
        {
            get { return etatCommis; }
            set { this.etatCommis = value; OnPropertyChanged("EtatCommis"); }
        }
        public DateTime DateEmbauche
        {
            get { return dateEmbauche; }
            set { this.dateEmbauche = value; OnPropertyChanged("DateEmbauche"); }
        }
        /// <summary>
        /// Fonction de creation de la ligne string permettant de créer le .csv
        /// </summary>
        public string GetLineForCSV()
        {
            string date = dateEmbauche.Day + "/" + dateEmbauche.Month+"/" + dateEmbauche.Year;
            return nomEmploye + ";" + prenomEmploye+";"+mdpEmploye + ";" + adrEmploye + ";" + numEmploye + ";" + etatCommis.ToString()+";"+date+";"+cumulTache ;

        }
    }
}
