using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria
{
    class Pizzerria
    {
        private string nom;
        private string adresse;
        private List<Client> clients;
        private List<Commis> commis;
        private List<Livreur> livreur;

        public Pizzerria(string nom, string adresse, List<Client> clients , List<Commis> commis , List<Livreur> livreur )
        {
            this.nom = nom;
            this.adresse = adresse;
            this.clients = clients;
            this.commis = commis;
            this.livreur = livreur;
        }

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public string Adresse
        {
            get { return adresse; }
            set { adresse = value; }
        }

        public List<Client> Clients
        {
            get { return clients; }
            set { clients = value; }
        }

        public List<Commis> Commis
        {
            get { return commis; }
            set { commis = value; }
        }

        public List<Livreur> Livreur
        {
            get { return livreur; }
            set { livreur = value; }
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
    }
}
