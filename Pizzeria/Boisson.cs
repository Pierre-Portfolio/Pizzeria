using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria
{
    public class Boisson
    {
        // par défault le prix d'une boisson est de 1e + le volume
        private string nomBoisson;
        private double volume;
        private double prix;

        public Boisson(string nomBoisson, double volume)
        {
            this.nomBoisson = nomBoisson;
            this.volume = volume < 0.5 ? 0.5 : volume > 2 ? 2 : volume;
            this.prix = Volume * 2 + 1;
        }

        public string NomBoisson
        {
            get { return this.nomBoisson; }
        }

        public double Volume
        {
            get { return this.volume; }
        }

        public double Prix
        {
            get { return this.prix; }
        }

        public string AfficherBoisson()
        {
            return this.nomBoisson + " " + this.volume + "L " + this.prix + "€\n";
        }
    }
}
