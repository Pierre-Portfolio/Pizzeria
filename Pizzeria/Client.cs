using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria
{
    public class Client
    {
        private int numClient;
        private string adrClient;
        private string nomClient;
        private string prenomClient;
        private DateTime datePremiereCmd;
        private string cumulCommande;

        public Client(int numClient, string adrClient, string nomClient, string prenomClient, string cumulCommande)
        {
            this.numClient = numClient;
            this.nomClient = nomClient;
            this.prenomClient = prenomClient;
            this.adrClient = adrClient;
            this.datePremiereCmd = DateTime.Now;
            this.cumulCommande = cumulCommande;
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

        public string CumulCommande
        {
            get { return cumulCommande; }
        }

    }
}
