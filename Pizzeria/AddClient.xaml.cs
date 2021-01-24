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
        public AddClient()
        {
            InitializeComponent();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        
        private void AddToCsv(Client c)
        {
            string path = "..\\..\\..\\Clients.csv";
            string line = c.NumClient + ";" + c.NomClient + ";" + c.PrenomClient + ";" + c.AdrClient + ";" + c.TelClient + ";" + c.DatePremiereCmd.Day+"/"+c.DatePremiereCmd.Month+"/"+c.DatePremiereCmd.Year + ";" + c.CumulCommande;
            if (!File.Exists(path))
            {
                // Creation du fichier.
                StreamWriter sw = File.CreateText(path);
                sw.WriteLine(line);
                sw.Close();
            }
            else
            {
                StreamWriter sw = File.AppendText(path);
                sw.WriteLine(c.NumClient + ";" + c.NomClient + ";" + c.PrenomClient + ";" + c.AdrClient + ";" + c.TelClient + ";" + c.DatePremiereCmd.Day + "/" + c.DatePremiereCmd.Month + "/" + c.DatePremiereCmd.Year + ";" + c.CumulCommande);
                sw.Close();
            }
        }
        
        private void AjouterClient(object sender, RoutedEventArgs e)
        {
            if(BoxNom.Text != "" && BoxPrenom.Text.Length != 0 && BoxAdresse.Text.Length != 0 && BoxTel.Text.Length != 0)
            {
                Client c = new Client(Client.lastNum + 1,  BoxNom.Text, BoxPrenom.Text, BoxAdresse.Text, int.Parse(BoxTel.Text));
                AddToCsv(c);
                var WindowMain = new MainWindow();
                WindowMain.Show(); 
                this.Close();
            }
            else
            {
                MessageBox.Show("Champs manquant","Erreur d'ajout");
            }
        }

        private void BoxNom_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
    }
}
