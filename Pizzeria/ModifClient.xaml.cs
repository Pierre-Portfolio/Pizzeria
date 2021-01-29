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
    /// Logique d'interaction pour ModifClient.xaml
    /// </summary>
    public partial class ModifClient : Window
    {
        public ModifClient()
        {
            InitializeComponent();
        }

        Client c;
        public ModifClient(Client c)
        {
            InitializeComponent();
            this.c = c;
        }

        private void Change(object sender, RoutedEventArgs e)
        {
            
            c.NomClient = BoxNom.Text;
            c.PrenomClient = BoxPrenom.Text;
            c.AdrClient = BoxAdresse.Text;
            c.TelClient = Convert.ToInt32(BoxTel.Text);
            this.Close();
        }

    }
}
