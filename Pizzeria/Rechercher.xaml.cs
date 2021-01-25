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
    /// Logique d'interaction pour Rechercher.xaml
    /// </summary>
    public partial class Rechercher : Window
    {
        public List<Client> listeClient;
        public Client client;
        public Rechercher()
        {
            InitializeComponent();
        }

        public Rechercher(List<Client> listeClient)
        {
            this.listeClient = listeClient;
            InitializeComponent();
            
        }

        private Client FindClient(int num)
        {
            foreach(Client c in listeClient)
            {
                if(c.TelClient == num)
                {
                    return c;
                }
            }
            return null;
        }
        private void ChercherClient(object sender, RoutedEventArgs e)
        {
            if (BoxTel.Text.Length != 0)
            {
                int tel = 0;
                Int32.TryParse(BoxTel.Text, out tel);
                Client c = FindClient(tel);
                this.client = c;
                if(c != null)
                {
                    LabelNom.Content = c.NomClient;
                    LabelPrenom.Content = c.PrenomClient;
                    LabelTel.Content = c.TelClient;
                    LabelAdresse.Content = c.AdrClient;
                    BtnCommande.Content = "Commander";
                }
                else
                {
                    LabelNom.Content = "Nom : Introuvable";
                    LabelPrenom.Content = "Prenom : Introuvable";
                    LabelTel.Content = "Tel : Introuvable";
                    LabelAdresse.Content = "Adresse : Introuvable";
                    BtnCommande.Content = "Fermer";
                }
                CanvaClient.Visibility = Visibility.Visible;
             
            }
            else
            {
                MessageBox.Show("Entrez un numéro de téléphone","Erreur");
            }

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void PasserCommande(object sender, RoutedEventArgs e)
        {
            if (client != null)
            {
                var WindowPasserCommande = new PasserCommande(client);
                WindowPasserCommande.Show();
            }
            this.Close();
        }
    }
}
