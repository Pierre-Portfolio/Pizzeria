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
        public string currentIdCommande = "";
        public PagePriseEnCharge(Pizzerria p)
        {
            InitializeComponent();
            this.p = p;
            //InitListeCommande();
            if(p.CurrentUser is Commis)
            {
                SelectLivreur.Visibility = Visibility.Visible;
                InitListeLivreur();
            }
            else
            {
                SelectLivreur.Visibility = Visibility.Hidden;
                InitListeCommande();
            }
        }

        private void InitListeLivreur()
        {
            foreach (Livreur l in p.Livreur)
            {
                if (l.EtatLivreur != Livreur.etat_livreur.enconges)
                {
                    ComboxBoxLivreur.Items.Add(l.NumEmploye);
                }
            }
        }
        private void InitListeCommande()
        {
            ComboxBoxIdCommande.Items.Clear();
            if (p.CurrentUser is Livreur)
            {
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
                foreach (Commande c in p.Commandes)
                {
                    if (c.Etat == Commande.EtatCommande.en_livraison && c.LivreurCharge.NumEmploye.Equals(currentLName))
                    {
                        ComboxBoxIdCommande.Items.Add(c.NumCommande);
                    }
                }
            }
        }
        private void ComboxBoxIdCommande_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentIdCommande = ComboxBoxIdCommande.SelectedItem.ToString();
        }
        private void Valider(object sender, RoutedEventArgs e)
        {
            if (p.CurrentUser is Livreur)
            {
                if(currentIdCommande != "")
                {
                    Commande c = p.Commandes.Find(x => x.NumCommande == Int32.Parse(currentIdCommande));
                    Facture f = new Facture(c);
                    c.Facture = f;
                    c.LivreurCharge = (Livreur) p.CurrentUser;
                    c.Etat = Commande.EtatCommande.en_livraison;
                    p.ReWriteCsvCommande();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Erreur, choissez une commande");
                }
            }
            else
            {
                if(currentIdCommande != "")
                {
                    Commande c = p.Commandes.Find(x => x.NumCommande == Int32.Parse(currentIdCommande));
                    c.Etat = Commande.EtatCommande.fermer;
                    p.ReWriteCsvCommande();
                    if (c.Facture == null)
                    {
                        c.Facture = new Facture(c);
                    }
                    p.Factures.Add(c.Facture);
                    p.ReWriteCsvFacture();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Erreur, choissez une commande");
                }
            }
        }

        private void ComboxBoxLivreur_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentLName = ComboxBoxLivreur.SelectedItem.ToString();
            InitListeCommande();
        }
        private void CommandePerdu(object sender, RoutedEventArgs e)
        {
            if (currentIdCommande != "")
            {
                Commande c = p.Commandes.Find(x => x.NumCommande == Int32.Parse(currentIdCommande));
                c.Etat = Commande.EtatCommande.perdue;
                p.ReWriteCsvCommande();
                this.Close();
            }
            else
            {
                MessageBox.Show("Erreur, choissez une commande");
            }
        }
    }
}
