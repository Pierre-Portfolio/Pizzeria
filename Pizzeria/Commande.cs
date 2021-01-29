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
        private Livreur livreurCharge;
        public static int lastCommande = 0;

        public int NumCommande { get => numCommande;}
        public string Heure { get => heure;}
        public DateTime Date { get => date;}
        public int NumeroClient { get => numeroClient; }
        public string NomClient { get => nomClient;}
        public string NomCommis { get => nomCommis; }
        public EtatCommande Etat { get => etat; set => etat = value; }
        public List<Pizza> ListePizza { get => listePizza;}
        public List<Boisson> ProduitAnnexes { get => produitAnnexes; }
        public Livreur LivreurCharge { get => livreurCharge; set => livreurCharge = value; }

        public Commande(int numclient = 0,string nomclient = "", string nomcommis ="")
        {
            this.numCommande = lastCommande +1;
            this.heure = (DateTime.Now.Hour+ 1) + "";
            this.date = DateTime.Now;
            this.numeroClient = numclient;
            this.nomClient = nomclient;
            this.nomCommis = nomcommis;
            this.etat = EtatCommande.en_preparation;
            this.listePizza = new List<Pizza>();
            this.produitAnnexes = new List<Boisson>();
            this.livreurCharge = null;
            lastCommande++;
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
            lastCommande = numCommande;

        }

        public string GetLineForCSV()
        {
            string ndate = date.Day + "/" +date.Month +"/"+date.Year;
            string line = numCommande + ";" + heure + ";" + ndate + ";" + numeroClient + ";" + nomClient + ";" + nomCommis + ";"+etat+";";
            //Ici => Add le nom du livreur si != null

            for (int i = 0; i < ListePizza.Count; i++)
            {
                if (ListePizza[i].Garnitures.Count != 0)
                {
                    line += ListePizza[i].Taille + ",";
                    for (int j = 0; j < ListePizza[i].Garnitures.Count; j++)
                    {
                        if (j >= ListePizza[i].Garnitures.Count - 1)
                        {
                            if (i >= ListePizza.Count - 1)
                                line += ListePizza[i].Garnitures[j].ToString();
                            else
                                line += ListePizza[i].Garnitures[j].ToString() + "/";
                        }
                        else
                        {
                            line += ListePizza[i].Garnitures[j].ToString() + ",";
                        }
                    }
                }
                else
                {
                    if (i >= ListePizza.Count - 1)
                    {
                        line += ListePizza[i].Taille;
                    }
                    else
                    {
                        line += ListePizza[i].Taille + "/";
                    }
                }
            }
            line += ";";
            for (int i = 0; i < ProduitAnnexes.Count; i++)
            {
                if (i == ProduitAnnexes.Count - 1)
                {
                    line += ProduitAnnexes[i].NomBoisson + "-" + ProduitAnnexes[i].Volume;
                }
                else
                {
                    line += ProduitAnnexes[i].NomBoisson + "-" + ProduitAnnexes[i].Volume + "/";
                }
            }
            return line;
        }
    }
}
