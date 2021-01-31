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
                Commis c = new Commis(BoxNom.Text, BoxPrenom.Text, BoxAdresse.Text,"x", BoxTel.Text, Commis.etat_commis.surplace,DateTime.Now,0);
                p.AjouterCommisFinCSV(c);
                var WindowMain = new MainWindow();
                WindowMain.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Champs manquant", "Erreur d'ajout");
            }
        }
    }
}
