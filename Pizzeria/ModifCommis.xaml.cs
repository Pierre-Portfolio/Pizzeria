using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Pizzeria
{
    /// <summary>
    /// Logique d'interaction pour ModifCommis.xaml
    /// </summary>
    public partial class ModifCommis : Window
    {

        public Pizzerria p;
        Commis c;
        public ModifCommis(Pizzerria p)
        {
            InitializeComponent();
            this.p = p;
        }
        public ModifCommis(Commis c, Pizzerria p)
        {
            InitializeComponent();
            this.c = c;
            this.p = p;
        }

        private void Change(object sender, RoutedEventArgs e)
        {
            Commis cl = p.Commis.Find(x => x.NumEmploye.Equals(c.NumEmploye));

            c.NomEmploye = BoxNom.Text;
            c.PrenomEmploye = BoxPrenom.Text;
            c.AdrEmploye = BoxAdresse.Text;
            c.NumEmploye = BoxTel.Text;
            c.EtatCommis = c.EtatCommis;
            
            cl.NomEmploye = BoxNom.Text;
            cl.PrenomEmploye = BoxPrenom.Text;
            cl.AdrEmploye = BoxAdresse.Text;
            cl.EtatCommis = c.EtatCommis;
            cl.NumEmploye = BoxTel.Text;

            p.ReWriteCsvCommis();
            
            this.Close();
            
        }
    }
}
