using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria
{
    public class Client
    {
        //Test Git
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
            set { firstCommande = value;}
        }

        public int NumClient
        {
            get { return numClient; }
            set { numClient = value; }
        }
        public string AdrClient
        {
            get { return adrClient; }
            set { adrClient = value; }
        }

        public string NomClient
        {
            get { return nomClient; }
            set { nomClient = value; }
        }

        public string PrenomClient
        {
            get { return prenomClient; }
            set { prenomClient = value; }
        }

        public DateTime DatePremiereCmd
        {
            get { return datePremiereCmd; }
            set { datePremiereCmd = value; }
        }

        public int CumulCommande
        {
            get { return cumulCommande; }
            set { cumulCommande = value; }
        }

    }
}
