using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria
{
    public class Client
    {
        private bool firstCommande;
        private int numClient;
        private string adrClient;
        private string nomClient;
        private string prenomClient;
        private DateTime datePremiereCmd;
        private int cumulCommande;

        public Client(bool firstCommande, int numClient, string adrClient, string nomClient, string prenomClient, DateTime datePremiereCmd, int cumulCommande)
        {
            this.firstCommande = firstCommande;
            this.numClient = numClient;
            this.adrClient = adrClient;
            this.nomClient = nomClient;
            this.prenomClient = prenomClient;
            this.datePremiereCmd = datePremiereCmd;
            this.cumulCommande = cumulCommande;
        }

        public bool FirstCommande
        {
            get{return firstCommande; }
        }

        public int NumClient
        {
            get { return numClient; }
        }
        public string AdrClient
        {
            get { return adrClient; }
        }

        public string NomClient
        {
            get { return nomClient; }
        }

        public string PrenomClient
        {
            get { return prenomClient; }
        }

        public DateTime DatePremiereCmd
        {
            get { return datePremiereCmd; }
        }

        public int CumulCommande
        {
            get { return cumulCommande; }
        }

    }
}
