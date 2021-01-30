using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria
{
    public class Facture
    {
        private int idFacture;
        private Commande details;
        private double prix;
        public static int lastFacture = 0;
        public Facture(Commande commande)
        {
            this.idFacture = lastFacture+1;
            this.details = commande;
            this.prix = CalculPrix();
            lastFacture = this.idFacture;
        }

        public Facture(int idFacture, Commande commande, double prix)
        {
            this.idFacture = idFacture;
            this.details = commande;
            this.prix = prix;
        }

        public int IdFacture
        {
            get { return this.idFacture; }
        }
        public Commande Details
        {
            get { return this.details; }
        }
        public double Prix
        {
            get{ return this.prix; }
        }
        public double CalculPrix()
        {
            double res = 0;
            if(details.ListePizza != null && details.ListePizza.Count != 0)
            {
                foreach(Pizza p in details.ListePizza)
                {
                    res += p.Prix;
                }
            }
            if(details.ProduitAnnexes != null && details.ProduitAnnexes.Count != 0)
            {
                foreach (Boisson b in details.ProduitAnnexes)
                {
                    res += b.Prix;
                }
            }
            return res;
        }
    
        public string GetLineForCSV()
        {
            return idFacture + ";" + details.NumCommande + ";" + prix;
        }
    }
}
