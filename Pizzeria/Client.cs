using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria
{
    class Client
    {
        private bool FirstCommande;
        private int NumClient;
        private string AdrClient;
        private string NomClient;
        private string PrenomClient;
        private DateTime DatePremiereCmd;
        private int CumulCommande;

        public Client(bool FirstCommande, int NumClient, string AdrClient, string NomClient, string PrenomClient, DateTime DatePremiereCmd, int CumulCommande)
        {
            this.FirstCommande = FirstCommande;
            this.NumClient = NumClient;
            this.AdrClient = AdrClient;
            this.NomClient = NomClient;
            this.PrenomClient = PrenomClient;
            this.DatePremiereCmd = DatePremiereCmd;
            this.CumulCommande = CumulCommande;
        }
    }
}
