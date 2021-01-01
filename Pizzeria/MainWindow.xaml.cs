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
    /// 
    public partial class MainWindow : Window
    {
        // permet de savoir la fenetre actuel
        public string actualWindow = "home";

        // On crée toutes les pages dynamique
        Grid DynamicGridClient = new Grid();
        Grid DynamicGridCommandes = new Grid();
        Grid DynamicGridStatistiques = new Grid();
        Grid DynamicGridAdministrations = new Grid();

        public void Refresh()
        {
            DynamicGridClient.Visibility = Visibility.Hidden;
            DynamicGridCommandes.Visibility = Visibility.Hidden;
            DynamicGridStatistiques.Visibility = Visibility.Hidden;
            DynamicGridAdministrations.Visibility = Visibility.Hidden;
        }

        private void ClientsBtn_Click(object sender, RoutedEventArgs e)
        {
            actualWindow = "clients";
            Refresh();
            FillClient();
        }

        private void CommandesBtn_Click(object sender, RoutedEventArgs e)
        {
            actualWindow = "commandes";
            Refresh();
            MessageBox.Show("text");
        }

        private void StatistiqueBtn_Click(object sender, RoutedEventArgs e)
        {
            actualWindow = "statistiques";
            Refresh();
            MessageBox.Show("text");
        }

        private void AdminitrationBtn_Click(object sender, RoutedEventArgs e)
        {
            actualWindow = "administrations";
            Refresh();
            MessageBox.Show("text");
        }

        public void FillClient()
        {
            Refresh();
            DynamicGridClient.Visibility = Visibility.Visible;
            // création grid dynamic
            DynamicGridClient.HorizontalAlignment = HorizontalAlignment.Left;
            DynamicGridClient.Height = 324;
            DynamicGridClient.Margin = new Thickness(27, 0, 0, 0);
            DynamicGridClient.VerticalAlignment = VerticalAlignment.Center;
            DynamicGridClient.Width = 743;
            Grid.SetRow(DynamicGridClient, 2);
            Grid.SetColumn(DynamicGridClient, 0);
            Grid.SetColumnSpan(DynamicGridClient, 4);
            MainGrid.Children.Add(DynamicGridClient);

            // Create Columns
            ColumnDefinition gridCol1 = new ColumnDefinition();
            DynamicGridClient.ColumnDefinitions.Add(gridCol1);

            // Create Rows
            RowDefinition gridRow1 = new RowDefinition();
            gridRow1.Height = new GridLength(30);
            RowDefinition gridRow2 = new RowDefinition();
            gridRow2.Height = new GridLength(80);
            RowDefinition gridRow3 = new RowDefinition();
            gridRow3.Height = new GridLength(30);
            RowDefinition gridRow4 = new RowDefinition();
            gridRow4.Height = new GridLength(80);
            RowDefinition gridRow5 = new RowDefinition();
            gridRow5.Height = new GridLength(30);
            RowDefinition gridRow6 = new RowDefinition();
            gridRow6.Height = new GridLength(80);
            DynamicGridClient.RowDefinitions.Add(gridRow1);
            DynamicGridClient.RowDefinitions.Add(gridRow2);
            DynamicGridClient.RowDefinitions.Add(gridRow3);
            DynamicGridClient.RowDefinitions.Add(gridRow4);
            DynamicGridClient.RowDefinitions.Add(gridRow5);
            DynamicGridClient.RowDefinitions.Add(gridRow6);
            DynamicGridClient.Margin = new Thickness(0, 0, 0, 0);

            // titre 1
            TextBlock txtBlock1 = new TextBlock();
            txtBlock1.Text = "Liste des Clients";
            txtBlock1.FontSize = 14;
            txtBlock1.Background = new SolidColorBrush(Colors.Orange);
            txtBlock1.FontWeight = FontWeights.Bold;
            txtBlock1.Foreground = new SolidColorBrush(Colors.Green);
            txtBlock1.VerticalAlignment = VerticalAlignment.Top;
            txtBlock1.HorizontalAlignment = HorizontalAlignment.Center;
            Grid.SetRow(txtBlock1, 0);
            Grid.SetColumn(txtBlock1, 0);
            DynamicGridClient.Children.Add(txtBlock1);

            // tableau des clients
            DataGrid myGridClient = new DataGrid();
            myGridClient.Width = 655;
            myGridClient.Height = 80;
            // myGridClient.Margin = new Thickness(20, -80, 20, 72);
            List<Client> clients = new List<Client>();
            clients.Add(new Client(false, 1, "8 rue machin", "Patrick", "Jean", new DateTime(2010, 8, 18), 4));
            clients.Add(new Client(false, 2, "9 rue machin", "Pierre", "Jean", new DateTime(2010, 8, 18), 4));
            clients.Add(new Client(false, 3, "10 rue machin", "Pierre", "Jean", new DateTime(2010, 8, 18), 4));
            clients.Add(new Client(false, 4, "11 rue machin", "Pierre", "Jean", new DateTime(2010, 8, 18), 4));
            myGridClient.ItemsSource = clients;
            myGridClient.Foreground = new SolidColorBrush(Colors.Orange);
            Grid.SetRow(myGridClient, 1);
            Grid.SetColumn(myGridClient, 0);
            //Grid.SetColumnSpan(myGridClient, 4);
            DynamicGridClient.Children.Add(myGridClient);

            // titre 2
            TextBlock txtBlock2 = new TextBlock();
            txtBlock2.Text = "Liste des Commis";
            txtBlock2.FontSize = 14;
            txtBlock2.HorizontalAlignment = HorizontalAlignment.Center;
            txtBlock2.Background = new SolidColorBrush(Colors.Orange);
            txtBlock2.FontWeight = FontWeights.Bold;
            txtBlock2.Foreground = new SolidColorBrush(Colors.Green);
            txtBlock2.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(txtBlock2, 3);
            Grid.SetColumn(txtBlock2, 0);
            DynamicGridClient.Children.Add(txtBlock2);

            // tableau des commis
            DataGrid myGridCommis = new DataGrid();
            myGridCommis.Width = 655;
            myGridCommis.Height = 80;
            myGridCommis.Margin = new Thickness(0, -45, 0, 0);

            List<Commis> commis = new List<Commis>();
            commis.Add(new Commis("Patrick", "Sur place", new DateTime(2010, 8, 18)));
            commis.Add(new Commis("Patrick", "Sur place", new DateTime(2010, 8, 18)));
            commis.Add(new Commis("Patrick", "Sur place", new DateTime(2010, 8, 18)));
            commis.Add(new Commis("Patrick", "Sur place", new DateTime(2010, 8, 18)));
            myGridCommis.ItemsSource = commis;
            myGridCommis.Foreground = new SolidColorBrush(Colors.Orange);
            Grid.SetRow(myGridCommis, 4);
            Grid.SetColumn(myGridCommis, 0);
            //Grid.SetColumnSpan(myGridClient, 4);
            DynamicGridClient.Children.Add(myGridCommis);

            // titre 3
            TextBlock txtBlock3 = new TextBlock();
            txtBlock3.Text = "Liste des Livreur";
            txtBlock3.FontSize = 14;
            txtBlock3.Background = new SolidColorBrush(Colors.Orange);
            txtBlock3.FontWeight = FontWeights.Bold;
            txtBlock3.Foreground = new SolidColorBrush(Colors.Green);
            txtBlock3.VerticalAlignment = VerticalAlignment.Top;
            txtBlock3.Margin = new Thickness(0, 5, 0, 0);
            txtBlock3.HorizontalAlignment = HorizontalAlignment.Center;
            Grid.SetRow(txtBlock3, 5);
            Grid.SetColumn(txtBlock3, 0);
            DynamicGridClient.Children.Add(txtBlock3);

            // tableau des serveur
            DataGrid myGridLivreur = new DataGrid();
            myGridLivreur.Width = 655;
            myGridLivreur.Height = 80;
            myGridLivreur.Margin = new Thickness(0, 20, 0, 0);
            List<Livreur> livreur = new List<Livreur>();
            livreur.Add(new Livreur("Patrick", "Sur place", "scooteur"));
            livreur.Add(new Livreur("Patrick", "Sur place", "scooteur"));
            livreur.Add(new Livreur("Patrick", "Sur place", "scooteur"));
            livreur.Add(new Livreur("Patrick", "Sur place", "scooteur"));
            myGridLivreur.ItemsSource = livreur;
            myGridLivreur.Foreground = new SolidColorBrush(Colors.Orange);
            Grid.SetRow(myGridLivreur, 6);
            Grid.SetColumn(myGridLivreur, 0);
            //Grid.SetColumnSpan(myGridClient, 4);
            DynamicGridClient.Children.Add(myGridLivreur);
        }

        public MainWindow()
        {
            InitializeComponent();
            //FillClient();
        }
    }
}
