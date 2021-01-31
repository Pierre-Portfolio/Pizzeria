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
    /// Logique d'interaction pour AddLivreur.xaml
    /// </summary>
    public partial class AddLivreur : Window
    {
        public MainWindow mw;
        public Pizzerria p;
        public AddLivreur(Pizzerria p, MainWindow mw)
        {
            this.p = p;
            this.mw = mw;
            InitializeComponent();
            BoxLivraison.ItemsSource = Enum.GetValues(typeof(Livreur.moyen_Livraison));
            BoxTel.MaxLength = 10;

        }

        /// <summary>
        /// Permet d'ajouter un nouveau livreur à la liste et de réécrire le .csv
        /// </summary>
        private void AjouterLivreur(object sender, RoutedEventArgs e)
        {
            if (BoxNom.Text != "" && BoxPrenom.Text.Length != 0 && BoxAdresse.Text.Length != 0 && BoxTel.Text.Length != 0 && BoxLivraison.Text.Length != 0)
            {
                if (BoxTel.Text.Length != 10)
                    MessageBox.Show("Erreur numéro de téléphone");
                else
                {
                    int test = 0;
                    if (Int32.TryParse(BoxTel.Text, out test))
                    {
                        if (p.Livreur.Find(x => x.NumEmploye.Equals(BoxTel.Text)) != null)
                            MessageBox.Show("Numero déjà utilisé");
                        else
                        {
                            Livreur l = new Livreur(BoxNom.Text, BoxPrenom.Text, BoxAdresse.Text, "x", BoxTel.Text, Livreur.etat_livreur.surplace, Enum.Parse<Livreur.moyen_Livraison>(BoxLivraison.Text));
                            p.AjouterLivreurFinCSV(l);
                            p.Livreur.Add(l);
                            mw.myGridLivreur.Items.Clear();
                            foreach(Livreur val in p.Livreur)
                                mw.myGridLivreur.Items.Add(val);
                            this.Close();
                        }
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
