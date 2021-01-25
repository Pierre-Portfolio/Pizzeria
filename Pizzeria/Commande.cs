using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria
{
    public class Commande
    {
        public enum EtatCommande
        {
            en_preparation, en_livraison, fermer, perdue
        }

        private int numCommande;
        private string heure;
        private DateTime date;
        private int numeroClient;
        private string nomClient;
        private string nomCommis;
        private EtatCommande etat;
        private List<Pizza> listePizza;
        private List<Boisson> produitAnnexes;

        public int NumCommande { get => numCommande;}
        public string Heure { get => heure;}
        public DateTime Date { get => date;}
        public int NumeroClient { get => numeroClient; }
        public string NomClient { get => nomClient;}
        public string NomCommis { get => nomCommis; }
        public EtatCommande Etat { get => etat; set => etat = value; }
        public List<Pizza> ListePizza { get => listePizza;}
        public List<Boisson> ProduitAnnexes { get => produitAnnexes; }

        public Commande()
        {
            this.numCommande = 0;
            this.heure = null;
            this.date = DateTime.Now;
            this.numeroClient = 0;
            this.nomClient = "";
            this.nomCommis = "";
            this.etat = EtatCommande.en_preparation;
            this.listePizza = new List<Pizza>();
            this.produitAnnexes = new List<Boisson>();
        }

        public Commande(int numCommande, string heure, DateTime date, int numeroClient, string nomClient, string nomCommis, EtatCommande etat, List<Pizza> listePizza, List<Boisson> produitAnnexes)
        {
            this.numCommande = numCommande;
            this.heure = heure;
            this.date = date;
            this.numeroClient = numeroClient;
            this.nomClient = nomClient;
            this.nomCommis = nomCommis;
            this.etat = etat;
            this.listePizza = listePizza;
            this.produitAnnexes = produitAnnexes;
        }
    }
}
