using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria
{
    public class Pizza
    {
        // le prix de base d'une Pizza est de 10e
        public enum TaillePizza
        {
            Petite = 1, Moyenne = 2, Grande = 3
        }

        public enum Garniture
        {
            Sauce_tomate = 1, Fromage = 1, Vegetarienne = 5, Toute_garnies = 7
        }

        private List<Garniture> garnitures;
        private TaillePizza taille;
        private double prix = 10;

        public Pizza(List<Garniture> garnitures, TaillePizza taille)
        {
            this.garnitures = garnitures;
            this.taille = taille;
            foreach(Garniture g in garnitures)
            {
                this.prix += Convert.ToDouble(g);
            }
            this.prix *=  Convert.ToDouble(taille);
        }

        public List<Garniture> Garnitures
        {
            get { return this.garnitures; }
        }

        public TaillePizza Taille
        {
            get { return this.taille; }
        }

        public double Prix
        {
            get { return this.prix; }
        }

        public string AffichePizza()
        {
            string s = this.Taille + " ";
            foreach(Garniture g in this.garnitures)
            {
                s += g + " ";
            }
            return s +" "+this.prix+"€\n" ;
        }
    }
}
