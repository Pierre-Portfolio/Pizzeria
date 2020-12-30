using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria
{
    abstract class Personelle
    {
        private string NomEmploye;

        public Personelle(string NomEmploye)
        {
            this.NomEmploye = NomEmploye;
        }
    }
}
