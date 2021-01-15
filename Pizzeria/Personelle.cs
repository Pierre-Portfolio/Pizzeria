using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria
{
    public abstract class Personelle
    {
        protected string nomEmploye;
        protected string prenomEmploye;
        protected string adrEmploye;
        protected string numEmploye;

        public Personelle(string nomEmploye, string prenomEmploye, string adrEmploye, string numEmploye = null)
        {
            this.nomEmploye = nomEmploye;
            this.prenomEmploye = prenomEmploye;
            this.adrEmploye = adrEmploye;
            this.numEmploye = numEmploye;
        }
        public string NomEmploye
        {
            get { return nomEmploye; }
        }

        public string PrenomEmploye
        {
            get { return prenomEmploye; }
        }

        public string AdrEmploye
        {
            get { return adrEmploye; }
        }

        public string NumEmploye
        {
            get { return numEmploye; }
        }
    }
}
