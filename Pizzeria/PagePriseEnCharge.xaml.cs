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
    /// Logique d'interaction pour PagePriseEnCharge.xaml
    /// </summary>
    public partial class PagePriseEnCharge : Window
    {
        public Pizzerria p;
        public string currentLName;
        public PagePriseEnCharge(Pizzerria p)
        {
            this.p = p;
            InitializeComponent();
            InitPriseEnCharge();
        }

        private void InitPriseEnCharge()
        {
            ComboxBoxLivreur.Items.Clear();
            ComboxBoxIdCommande.Items.Clear();
            if (p.CurrentUser is Livreur)
            {
                SelectLivreur.Visibility = Visibility.Hidden;
                foreach (Commande c in p.Commandes)
                {
                    if (c.Etat == Commande.EtatCommande.en_preparation)
                    {
                        ComboxBoxIdCommande.Items.Add(c.NumCommande);
                    }
                }
            }
            else
            {
                SelectLivreur.Visibility = Visibility.Visible;
                foreach (Livreur l in p.Livreur)
                {
                    if (l.EtatLivreur != Livreur.etat_livreur.enconges)
                    {
                        ComboxBoxLivreur.Items.Add(l.NumEmploye);
                    }
                }

                foreach (Commande c in p.Commandes)
                {
                    if (c.Etat == Commande.EtatCommande.en_livraison && c.LivreurCharge.NumEmploye == currentLName)
                    {
                        ComboxBoxIdCommande.Items.Add(c.NumCommande);
                    }
                }
            }
        }
        private void ComboxBoxIdCommande_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ValiderLivreur(object sender, RoutedEventArgs e)
        {
            if (p.CurrentUser is Livreur)
            {
                if (ComboxBoxIdCommande.SelectedIndex != -1)
                {
                    string s = ComboxBoxIdCommande.Text;
                    p.Commandes.Find(x => x.NumCommande == Int32.Parse(s)).LivreurCharge = p.CurrentUser as Livreur;
                    p.Commandes.Find(x => x.NumCommande == Int32.Parse(s)).Etat = Commande.EtatCommande.en_livraison;
                    Livreur l = p.CurrentUser as Livreur;
                    l.EtatLivreur = Livreur.etat_livreur.enlivraison;
                    p.CurrentUser = l;
                }
                else
                {
                    MessageBox.Show("Erreur, choissez une commande");
                }
            }
            else
            {

            }
        }

        private void ComboxBoxLivreur_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentLName = ComboxBoxLivreur.Text;
            InitPriseEnCharge();
        }
    }
}
