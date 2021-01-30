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
    /// Logique d'interaction pour ModifLivreur.xaml
    /// </summary>
    public partial class ModifLivreur : Window
    {
        public Pizzerria p;
        Livreur c;
        public ModifLivreur(Pizzerria p)
        {
            InitializeComponent();
            this.p = p;
        }
        public ModifLivreur(Livreur c, Pizzerria p)
        {
            InitializeComponent();
            this.c = c;
            this.p = p;
        }

        private void Change(object sender, RoutedEventArgs e)
        {
            Livreur cl = p.Livreur.Find(x => x.NumEmploye.Equals(c.NumEmploye));

            c.NomEmploye = BoxNom.Text;
            c.PrenomEmploye = BoxPrenom.Text;
            c.AdrEmploye = BoxAdresse.Text;
            c.NumEmploye = BoxTel.Text;
            
            c.EtatLivreur = Enum.Parse<Livreur.etat_livreur>(ComboBoxEtat.Text);
            c.MoyenLivraison = Enum.Parse<Livreur.moyen_Livraison>(ComboBoxTransport.Text);
            
            if (cl != null)
            {
                cl.NomEmploye = BoxNom.Text;
                cl.PrenomEmploye = BoxPrenom.Text;
                cl.AdrEmploye = BoxAdresse.Text;
                cl.EtatLivreur = Enum.Parse<Livreur.etat_livreur>(ComboBoxEtat.Text);
                cl.MoyenLivraison = Enum.Parse<Livreur.moyen_Livraison>(ComboBoxTransport.Text);
                cl.NumEmploye = BoxTel.Text;

                p.ReWriteCsvLivreur();
            }
            
            this.Close();

        }
    }
}
