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
using System.IO;


namespace Pizzeria
{
    /// <summary>
    /// Logique d'interaction pour AddClient.xaml
    /// </summary>
    public partial class AddClient : Window
    {
        public Pizzerria p;
        public MainWindow mw;
        public AddClient(Pizzerria p, MainWindow mw)
        {
            InitializeComponent();
            this.p = p;
            this.mw = mw;
            BoxTel.MaxLength = 10;
        }
        /// <summary>
        /// Ajouter un client à la liste p.Client et au .csv
        /// </summary>
        private void AjouterClient(object sender, RoutedEventArgs e)
        {
            if (BoxNom.Text != "" && BoxPrenom.Text.Length != 0 && BoxAdresse.Text.Length != 0 && BoxTel.Text.Length != 0)
            {
                if (BoxTel.Text.Length != 10)
                    MessageBox.Show("Erreur numéro de téléphone");
                else
                {
                    int test = 0;
                    if (Int32.TryParse(BoxTel.Text, out test))
                    {
                        Client c = new Client(Client.lastNum + 1, BoxNom.Text, BoxPrenom.Text, BoxAdresse.Text, int.Parse(BoxTel.Text));
                        p.AjouterClientFinCSV(c);
                        p.Clients.Add(c.TelClient, c);
                        mw.myGridClient.ItemsSource = p.Clients.Values;
                        var WindowCommande = new PasserCommande(p, c);
                        WindowCommande.Show();
                        this.Close();
                        
                    }
                    else
                    {
                        MessageBox.Show("Erreur, numéro au mauvais format");
                    }
                }
            }
            else
            {
                MessageBox.Show("Champs manquant","Erreur d'ajout");
            }
        }

    }
}
