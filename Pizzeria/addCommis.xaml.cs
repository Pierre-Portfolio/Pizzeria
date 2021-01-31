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
        public Pizzerria p;
        public addCommis(Pizzerria p)
        {
            this.p = p;
            InitializeComponent();
            BoxTel.MaxLength = 10;
        }
        /// <summary>
        /// Ajouter un commis à la liste p.Commis et au csv
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AjouterCommis(object sender, RoutedEventArgs e)
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
                        Commis c = new Commis(BoxNom.Text, BoxPrenom.Text, BoxAdresse.Text, "x", BoxTel.Text, Commis.etat_commis.surplace, DateTime.Now, 0);
                        p.AjouterCommisFinCSV(c);
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
                MessageBox.Show("Champs manquant", "Erreur d'ajout");
            }
        }
    }
}
