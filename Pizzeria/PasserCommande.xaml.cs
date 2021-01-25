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
    /// Logique d'interaction pour PasserCommande.xaml
    /// </summary>
    public partial class PasserCommande : Window
    {
        public Commande currentCommande;
        public PasserCommande()
        {
            currentCommande = new Commande();
            InitializeComponent();
        }

        private void Click_btnPizza(object sender, RoutedEventArgs e)
        {
            CanvaPizza.Visibility = Visibility.Visible;
        }

        private void Click_btnExtra(object sender, RoutedEventArgs e)
        {

        }

        private void Click_btnValider(object sender, RoutedEventArgs e)
        {

        }
        private void Click_Ajouter_SelectPizza(object sender, RoutedEventArgs e)
        {
            Pizza.TaillePizza t = RadioPetit.IsChecked == true ? Pizza.TaillePizza.Petite : RadioMoy.IsChecked == true? Pizza.TaillePizza.Moyenne : Pizza.TaillePizza.Grande;
            List<Pizza.Garniture> listeGarn = new List<Pizza.Garniture>();
            if (checkFromage.IsChecked == true)
            {
                listeGarn.Add(Pizza.Garniture.Fromage);
            }
            if (checkVege.IsChecked == true)
            {
                listeGarn.Add(Pizza.Garniture.Vegetarienne);
            }
            if (checkSauceT.IsChecked == true)
            {
                listeGarn.Add(Pizza.Garniture.Sauce_tomate);
            }
            if (checkTouteG.IsChecked == true)
            {
                listeGarn.Add(Pizza.Garniture.Toute_garnies);
            }
            Pizza p = new Pizza(listeGarn,t);
            currentCommande.ListePizza.Add(p);
            CanvaPizza.Visibility = Visibility.Hidden;
            refreshAffichage();
        }

        private void refreshAffichage()
        {
            if(currentCommande != null)
            {
                if(currentCommande.ListePizza != null && currentCommande.ListePizza.Count != 0)
                {
                    Label titrePizza = new Label();
                    titrePizza.Content = "Vos pizzas : \n";
                    AfficheCommande.Children.Add(titrePizza);
                    foreach (Pizza p in currentCommande.ListePizza)
                    {
                        Button currentPizza = new Button();
                        currentPizza.Content = p.AffichePizza();
                        AfficheCommande.Children.Add(currentPizza);
                    }
                }
            }
        }
    }
}
