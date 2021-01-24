using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria
{
    class Facture
    {
        private int idFacture;
        private Commande details;
        private int prix;

        public Facture(int idFacture, Commande commande, int prix)
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
    }
}
