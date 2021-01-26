﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria
{
    public class Livreur : Personelle
    {
        public enum etat_livreur
        {
            surplace,
            enconges,
            enlivraison,
        }
        private etat_livreur etatLivreur;
        private string moyenLivraison;

        public Livreur(string nomEmploye, string prenomEmploye, string adrEmploye, string numEmploye, etat_livreur etatLivreur, string moyenLivraison) : base(nomEmploye, prenomEmploye, adrEmploye, numEmploye)
        {
            this.etatLivreur = etatLivreur;
            this.moyenLivraison = moyenLivraison;
        }

        public etat_livreur EtatLivreur
        {
            get { return etatLivreur; }
        }
        public string MoyenLivraison
        {
            get { return moyenLivraison; }
        }
    }
}
