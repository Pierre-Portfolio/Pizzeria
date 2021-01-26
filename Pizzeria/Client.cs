using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria
{
    public class Client
    {
        private int numClient;
        private string nomClient;
        private string prenomClient;
        private string adrClient;
        private DateTime datePremiereCmd;
        private int telClient;
        private int cumulCommande;
        public static int lastNum = 1;
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
        }

        public string NomClient
        {
            get { return nomClient; }
        }

        public string PrenomClient
        {
            get { return prenomClient; }
        }
        public string AdrClient
        {
            get { return adrClient; }
        }
        public int TelClient
        {
            get{ return this.telClient; }
        }

        public DateTime DatePremiereCmd
        {
            get { return datePremiereCmd; }
        }

        public int CumulCommande
        {
            get { return cumulCommande; }
            set { this.cumulCommande = value; }
        }
        #endregion
    }
}
