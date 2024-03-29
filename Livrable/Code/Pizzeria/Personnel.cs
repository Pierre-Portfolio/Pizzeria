﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Pizzeria
{
    public abstract class Personel : INotifyPropertyChanged
    {
        protected string nomEmploye;
        protected string prenomEmploye;
        protected string adrEmploye;
        protected string mdpEmploye;
        protected string numEmploye;
        protected int cumulTache;
        public event PropertyChangedEventHandler PropertyChanged;

        public Personel(string nomEmploye, string prenomEmploye, string adrEmploye, string mdpEmploye, string numEmploye = null, int cumulTache = 0)
        {
            this.nomEmploye = nomEmploye;
            this.prenomEmploye = prenomEmploye;
            this.adrEmploye = adrEmploye;
            this.mdpEmploye = mdpEmploye;
            this.numEmploye = numEmploye;
            this.cumulTache = cumulTache;
        }

        public string NomEmploye
        {
            get { return nomEmploye; }
            set { this.nomEmploye = value; OnPropertyChanged("NomEmploye"); }
        }

        public string PrenomEmploye
        {
            get { return prenomEmploye; }
            set { this.prenomEmploye = value; OnPropertyChanged("PrenomEmploye"); }
        }

        public string AdrEmploye
        {
            get { return adrEmploye; }
            set { this.adrEmploye = value; OnPropertyChanged("AdrEmploye"); }
        }

        public string MdpEmploye
        {
            get { return this.mdpEmploye; }
            set { this.mdpEmploye = value;}
        }

        public string NumEmploye
        {
            get { return numEmploye; }
            set { this.numEmploye = value; OnPropertyChanged("NumEmploye"); }
        }

        public int CumulTache
        {
            get { return cumulTache; }
            set { this.cumulTache = value;}
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
