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
    /// Logique d'interaction pour addCommis.xaml
    /// </summary>
    public partial class addCommis : Window
    {
        public addCommis()
        {
            InitializeComponent();
        }

        private void AddToCsv(Commis c)
        {
            string path = "..\\..\\..\\Commis.csv";
            string line = c.GetLineCSV();
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
                sw.WriteLine(line);
                sw.Close();
            }
        }
        private void AjouterCommis(object sender, RoutedEventArgs e)
        {
            if (BoxNom.Text != "" && BoxPrenom.Text.Length != 0 && BoxAdresse.Text.Length != 0 && BoxTel.Text.Length != 0)
            {
                Commis c = new Commis(BoxNom.Text, BoxPrenom.Text, BoxAdresse.Text,"x", BoxTel.Text, Commis.etat_commis.surplace,DateTime.Now,0);
                AddToCsv(c);
                var WindowMain = new MainWindow();
                WindowMain.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Champs manquant", "Erreur d'ajout");
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void BoxNom_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
