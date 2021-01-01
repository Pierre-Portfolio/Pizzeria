using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria
{
    abstract class Personelle
    {
        private string nomEmploye;

        public Personelle(string nomEmploye)
        {
            this.nomEmploye = nomEmploye;
        }
        public string NomEmploye
        {
            get { return nomEmploye; }
            set { nomEmploye = value; }
        }
    }
}
