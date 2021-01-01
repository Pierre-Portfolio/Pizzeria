using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ClientsBtn_Click(object sender, RoutedEventArgs e)
        {
            FillClient();
        }

        private void CommandesBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("text");
        }

        private void StatistiqueBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("text");
        }

        private void AdminitrationBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("text");
        }

        public void FillClient()
        {
            List<Client> clients = new List<Client>();
            clients.Add(new Client(false, 1, "8 rue machin", "Patrick", "Jean", new DateTime(2010, 8, 18), 4));
            clients.Add(new Client(false, 2, "9 rue machin", "Pierre", "Jean", new DateTime(2010, 8, 18), 4));
            clients.Add(new Client(false, 3, "10 rue machin", "Pierre", "Jean", new DateTime(2010, 8, 18), 4));
            myGridClient.ItemsSource = clients;
        }
    }
}
