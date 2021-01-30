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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pizzeria
{
    /// <summary>
    /// Logique d'interaction pour Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        public Pizzerria p;
        public MainWindow mw;
        public Settings(Pizzerria p, MainWindow mw)
        {
            InitializeComponent();
            this.p = p;
            this.mw = mw;

        }

        private void Deconnect(object sender, RoutedEventArgs e)
        {
            MainWindow mainWin = new MainWindow();
            mainWin.Show();
            mw.Close();
        }

        private void ChangeMdp(object sender, RoutedEventArgs e)
        {
            if (mdp1.Text.Length == 0 || mdp2.Text.Length == 0 || !mdp1.Text.Equals(mdp2.Text))
                MessageBox.Show("Il semble que quelque chose ne va pas..");
            else
            {
                string pass = mdp1.Text;
                if (p.CurrentUser is Commis)
                {
                    Commis c = p.Commis.Find(x => x.NumEmploye.Equals(p.CurrentUser.NumEmploye));
                    if (c != null)
                    {
                        c.MdpEmploye = pass;
                        p.ReWriteCsvCommis();
                        MessageBox.Show("Mot de passe modifié");
                    }
                    else
                        MessageBox.Show("Une erreure c'est produite");
                }
                else
                {
                    Livreur c = p.Livreur.Find(x => x.NumEmploye.Equals(p.CurrentUser.NumEmploye));
                    if (c != null)
                    {
                        c.MdpEmploye = pass;
                        p.ReWriteCsvLivreur();
                        MessageBox.Show("Mot de passe modifié");
                    }
                    else
                        MessageBox.Show("Une erreure c'est produite");
                }

            }
        }
    }
}
