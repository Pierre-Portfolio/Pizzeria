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
        public Pizzerria p;
        Client c;
        public ModifClient(Pizzerria p)
        {
            InitializeComponent();
            this.p = p;
        }
        public ModifClient(Client c, Pizzerria p)
        {
            InitializeComponent();
            this.c = c;
            this.p = p;
        }

        private void Change(object sender, RoutedEventArgs e)
        {
            Client cl = null;
            p.Clients.TryGetValue(c.TelClient, out cl);

            c.NomClient = BoxNom.Text;
            c.PrenomClient = BoxPrenom.Text;
            c.AdrClient = BoxAdresse.Text;
            c.TelClient = Convert.ToInt32(BoxTel.Text);
            
            if(cl != null)
            {
                cl.NomClient = BoxNom.Text;
                cl.PrenomClient = BoxPrenom.Text;
                cl.AdrClient = BoxAdresse.Text;
                cl.TelClient = Convert.ToInt32(BoxTel.Text);
                p.ReWriteCsvClient();
            }
            this.Close();
        }

    }
}
