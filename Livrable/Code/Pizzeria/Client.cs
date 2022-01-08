using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Pizzeria
{
    public class Client :ISauvegardable, INotifyPropertyChanged
    {
        private int numClient;
        private string nomClient;
        private string prenomClient;
        private string adrClient;
        private DateTime datePremiereCmd;
        private int telClient;
        private int cumulCommande;
        public static int lastNum = 1;
        public event PropertyChangedEventHandler PropertyChanged;

        public Client(int numClient, string nomClient, string prenomClient, string adrClient, int telClient, int cumulCommande = 0)
        {
            this.numClient = numClient;
            this.nomClient = nomClient;
            this.prenomClient = prenomClient;
            this.adrClient = adrClient;
            this.telClient = telClient;
            this.datePremiereCmd = DateTime.Now;
            this.cumulCommande = cumulCommande;
            lastNum = numClient;
        }
        public Client(int numClient, string nomClient, string prenomClient,string adrClient, int telClient, DateTime datefirstCommande, int cumulCommande = 0)
        {
            this.numClient = numClient;
            this.nomClient = nomClient;
            this.prenomClient = prenomClient;
            this.adrClient = adrClient;
            this.telClient = telClient;
            this.datePremiereCmd = datefirstCommande;
            this.cumulCommande = cumulCommande;
            lastNum = numClient;
        }

        #region Propietes
        public int NumClient
        {
            get { return numClient; }
            set { this.numClient = value; OnPropertyChanged("NumClient"); }
        }

        public string NomClient
        {
            get { return nomClient; }
            set { this.nomClient = value; OnPropertyChanged("NomClient"); }
        }

        public string PrenomClient
        {
            get { return prenomClient; }
            set { this.prenomClient = value; OnPropertyChanged("PrenomClient"); }
        }
        public string AdrClient
        {
            get { return adrClient; }
            set { this.adrClient = value; OnPropertyChanged("AdrClient"); }
        }
        public int TelClient
        {
            get{ return this.telClient; }
            set { this.telClient = value; OnPropertyChanged("telClient"); }
        }

        public DateTime DatePremiereCmd
        {
            get { return datePremiereCmd; }
            set { this.datePremiereCmd = value; OnPropertyChanged("DatePremiereCmd"); }
        }

        public int CmlCmd
        {
            get { return cumulCommande; }
            set { this.cumulCommande = value; OnPropertyChanged("CmlCmd"); }
        }
        #endregion

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        /// <summary>
        /// Fonction de creation de la ligne string permettant de créer le .csv
        /// </summary>
        /// <returns>string</returns>
        public string GetLineForCSV()
        {
            string date = datePremiereCmd.Day + "/" + datePremiereCmd.Month + "/" + datePremiereCmd.Year;
            return numClient + ";" + nomClient + ";" + prenomClient + ";" + adrClient + ";" + telClient + ";" + date + ";" + cumulCommande;
        }
    }
}
