﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace Pizzeria
{
    public class Pizzerria
    {
        private string nom;
        private string adresse;
        private List<Client> clients;
        private List<Commis> commis;
        private List<Livreur> livreur;
        private List<Commande> commandes;
        public Pizzerria(string nom, string adresse)
        {
            this.nom = nom;
            this.adresse = adresse;
            this.clients = ChargerCSVClient();
            this.commis = ChargerCSVCommis();
            this.livreur = ChargerCSVLivreur();
            this.commandes = ChargerCSVCommande();
        }

        public string Nom
        {
            get { return nom; }
        }

        public string Adresse
        {
            get { return adresse; }
        }

        public List<Client> Clients
        {
            get { return clients; }
        }
        public List<Commis> Commis
        {
            get { return commis; }
        }

        public List<Livreur> Livreur
        {
            get { return livreur; }
        }
        public List<Commande> Commandes
        {
            get { return commandes; }
        }

        public void addClient(Client c)
        {
            this.clients.Add(c);
        }

        public void addCommis(Commis c)
        {
            this.commis.Add(c);
        }

        public void addLivreur(Livreur l)
        {
            this.livreur.Add(l);
        }

        public void addCommande(Commande c)
        {
            this.commandes.Add(c);
        }

        #region Fonctions pour charger les CSV
        public List<Client> ChargerCSVClient()
        {
            string path = "..\\..\\..\\Clients.csv";
            List<Client> c1 = new List<Client>();
            if (File.Exists(path))
            {
                StreamReader lecteur = new StreamReader(path);
                string ligne = "";
                while (lecteur.Peek() > 0)
                {
                    //Peek() est une fonction qui retourne -1 s'il n'y a
                    //plus de caractère à lire
                    ligne = lecteur.ReadLine();
                    if (ligne != null)
                    {

                        string[] tem = ligne.Split(';');
                        string[] date = tem[5].Split('/');
                        c1.Add(new Client(Convert.ToInt32(tem[0]), tem[1], tem[2], tem[3], int.Parse(tem[4]), new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0])), int.Parse(tem[6])));
                    }
                }
                lecteur.Close();
            }
            return c1;
        }

        public List<Commis> ChargerCSVCommis()
        {
            string path = "..\\..\\..\\Commis.csv";
            List<Commis> c1 = new List<Commis>();
            if (File.Exists(path))
            {
                StreamReader lecteur = new StreamReader(path);
                string ligne = "";
                while (lecteur.Peek() > 0)
                {
                    //Peek() est une fonction qui retourne -1 s'il n'y a
                    //plus de caractère à lire
                    ligne = lecteur.ReadLine();
                    if (ligne != null)
                    {
                        string[] tem = ligne.Split(';');
                        Commis.etat_commis en = Enum.Parse<Commis.etat_commis>(tem[4]);
                        c1.Add(new Commis(tem[0], tem[1], tem[2], tem[3], en, Convert.ToDateTime(tem[5])));
                    }
                }
                lecteur.Close();
            }
            return c1;
        }

        public List<Livreur> ChargerCSVLivreur()
        {
            string path = "..\\..\\..\\Livreur.csv";
            List<Livreur> c1 = new List<Livreur>();
            if (File.Exists(path))
            {
                StreamReader lecteur = new StreamReader(path);
                string ligne = "";
                while (lecteur.Peek() > 0)
                {
                    //Peek() est une fonction qui retourne -1 s'il n'y a
                    //plus de caractère à lire
                    ligne = lecteur.ReadLine();
                    if (ligne != null)
                    {
                        string[] tem = ligne.Split(';');
                        Livreur.etat_livreur en = Enum.Parse<Livreur.etat_livreur>(tem[4]);
                        c1.Add(new Livreur(tem[0], tem[1], tem[2], tem[3], en, tem[5]));
                    }
                }
                lecteur.Close();
            }
            return c1;
        }

        private List<Commande> ChargerCSVCommande()
        {
            string path = "..\\..\\..\\Commandes.csv";
            List<Commande> c1 = new List<Commande>();
            if (File.Exists(path))
            {
                StreamReader lecteur = new StreamReader(path);
                string ligne = "";
                while (lecteur.Peek() > 0)
                {
                    //Peek() est une fonction qui retourne -1 s'il n'y a
                    //plus de caractère à lire
                    ligne = lecteur.ReadLine();
                    if (ligne != null)
                    {

                        string[] tem = ligne.Split(';');
                        string[] date = tem[2].Split('/');
                        DateTime newDate = DateTime.Now;
                        if (date != null && date.Length == 3)
                        {
                            newDate = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));
                        }

                        Commande.EtatCommande en = Enum.Parse<Commande.EtatCommande>(tem[6]);
                        List<Pizza> p = new List<Pizza>();
                        string[] pizzas = tem[7].Split('/');
                        foreach (string s in pizzas)
                        {
                            string[] elem = s.Split(',');
                            List<Pizza.Garniture> pg = new List<Pizza.Garniture>();
                            for (int i = 1; i < elem.Length; i++)
                            {
                                Pizza.Garniture e = Enum.Parse<Pizza.Garniture>(elem[i]);
                                pg.Add(e);
                            }
                            Pizza piz = new Pizza(pg, Enum.Parse<Pizza.TaillePizza>(elem[0]));
                            p.Add(piz);
                        }
                        List<Boisson> b = new List<Boisson>();
                        string[] boisson = tem[8].Split('/');
                        foreach (string s in boisson)
                        {
                            string[] elem = s.Split('-');
                            if (elem != null && elem.Length == 2)
                            {
                                b.Add(new Boisson(elem[0], double.Parse(elem[1])));
                            }
                        }
                        c1.Add(new Commande(int.Parse(tem[0]), tem[1], newDate, int.Parse(tem[3]), tem[4], tem[5], en, p, b));
                    }
                }
                lecteur.Close();
            }
            return c1;
        }
        #endregion

        #region Refresh
        public void Refresh()
        {
            this.clients = ChargerCSVClient();
            this.commis = ChargerCSVCommis();
            this.livreur = ChargerCSVLivreur();
            this.commandes = ChargerCSVCommande();
        }
        #endregion
    }
}
