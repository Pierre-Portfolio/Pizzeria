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
using System.IO;
using System.Net.NetworkInformation;

namespace Pizzeria
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        #region Variable Globale
        // permet de savoir la fenetre actuel
        // On crée toutes les pages dynamique
        Grid DynamicGridClient = new Grid();
        Grid DynamicGridCommands = new Grid();
        Grid DynamicGridStat= new Grid();
        Grid DynamicGridAdmin = new Grid();

        //Test
        public List<Client> listeClient;
        #endregion

        #region fonction refresh


        public void RefreshPasOpti()
        {
            if (MainGrid.Children.Contains(DynamicGridClient))
            {
                MainGrid.Children.Remove(DynamicGridClient);
            }
            else if (MainGrid.Children.Contains(DynamicGridCommands))
            {
                MainGrid.Children.Remove(DynamicGridCommands);
            }
            else if (MainGrid.Children.Contains(DynamicGridStat))
            {
                MainGrid.Children.Remove(DynamicGridStat);
            }
            else if (MainGrid.Children.Contains(DynamicGridAdmin)){
                MainGrid.Children.Remove(DynamicGridAdmin);
            }
        }
        #endregion

        #region Parti Client
        private void ClientsBtn_Click(object sender, RoutedEventArgs e)
        {
            RefreshPasOpti();
            MainGrid.Children.Add(DynamicGridClient);
        }

        public static List<Client> ChargerCSVClient(string path)
        {
            List<Client> c1 = new List<Client>();
            if (File.Exists(path))
            {
                StreamReader lecteur = new StreamReader(path);
                string ligne = "";
                while (lecteur.Peek() > 0)
                {
                    //Peek() est une fonction qui retourne -1 s'il n'y a
                    //plus de caractère à lire
                    ligne = lecteur.ReadLine();
                    if (ligne != null)
                    {

                        string[] tem = ligne.Split(';');
                        string[] date = tem[5].Split('/');
                        c1.Add(new Client(Convert.ToInt32(tem[0]), tem[1], tem[2], tem[3], int.Parse(tem[4]), new DateTime(int.Parse(date[2]),int.Parse(date[1]),int.Parse(date[0])), int.Parse(tem[6])));
                    }
                }
                lecteur.Close();
            }
            return c1;
        }

        public List<Commis> ChargerCSVCommis(string path)
        {
            List<Commis> c1 = new List<Commis>();
            if (File.Exists(path))
            {
                StreamReader lecteur = new StreamReader(path);
                string ligne = "";
                while (lecteur.Peek() > 0)
                {
                    //Peek() est une fonction qui retourne -1 s'il n'y a
                    //plus de caractère à lire
                    ligne = lecteur.ReadLine();
                    if (ligne != null)
                    {
                        string[] tem = ligne.Split(';');
                        c1.Add(new Commis(tem[0], tem[1], tem[2], tem[3],tem[4],Convert.ToDateTime(tem[5])));
                    }
                }
                lecteur.Close();
            }
            return c1;
        }

        public List<Livreur> ChargerCSVLivreur(string path)
        {
            List<Livreur> c1 = new List<Livreur>();
            if (File.Exists(path))
            {
                StreamReader lecteur = new StreamReader(path);
                string ligne = "";
                while (lecteur.Peek() > 0)
                {
                    //Peek() est une fonction qui retourne -1 s'il n'y a
                    //plus de caractère à lire
                    ligne = lecteur.ReadLine();
                    if (ligne != null)
                    {
                        string[] tem = ligne.Split(';');
                        c1.Add(new Livreur(tem[0], tem[1], tem[2], tem[3],tem[4],tem[5]));
                    }
                }
                lecteur.Close();
            }
            return c1;
        }

        private void OpenAddClient(object sender, RoutedEventArgs e)
        {
            var WindowAddClient = new AddClient();
            WindowAddClient.Show();
            this.Close();
        }

        private void OpenChercherClient(object sender, RoutedEventArgs e)
        {
            var WindowChercher = new Rechercher(this.listeClient);
            WindowChercher.Show();
        }
        #endregion

        #region Parti Commande
        private void CommandesBtn_Click(object sender, RoutedEventArgs e)
        {
            RefreshPasOpti();
            MainGrid.Children.Add(DynamicGridCommands);
        }

        private void OpenCommandeWindow(object sender, RoutedEventArgs e)
        {
            var WindowCommandeOpen = new PasserCommande();
            WindowCommandeOpen.Show();
        }

        private List<Commande> ChargerCSVCommande()
        {
            string path = "..\\..\\..\\Commandes.csv" ;
            List<Commande> c1 = new List<Commande>();
            if (File.Exists(path))
            {
                StreamReader lecteur = new StreamReader(path);
                string ligne = "";
                while (lecteur.Peek() > 0)
                {
                    //Peek() est une fonction qui retourne -1 s'il n'y a
                    //plus de caractère à lire
                    ligne = lecteur.ReadLine();
                    if (ligne != null)
                    {

                        string[] tem = ligne.Split(';');
                        string[] date = tem[2].Split('/');
                        DateTime newDate = DateTime.Now;
                        if (date != null && date.Length == 3)
                        {
                            newDate = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));
                        }

                        Commande.EtatCommande en = Enum.Parse<Commande.EtatCommande>(tem[6]);
                        List<Pizza> p = new List<Pizza>();
                        string[] pizzas = tem[7].Split('/');
                        foreach(string s in pizzas)
                        {
                            string[] elem = s.Split(',');
                            List<Pizza.Garniture> pg = new List<Pizza.Garniture>();
                            for(int i = 1; i < elem.Length; i++)
                            {
                                Pizza.Garniture e = Enum.Parse<Pizza.Garniture>(elem[i]);
                                pg.Add(e);
                            }
                            Pizza piz = new Pizza(pg,Enum.Parse<Pizza.TaillePizza>(elem[0]));
                            p.Add(piz);
                        }
                        List<Boisson> b = new List<Boisson>();
                        string[] boisson = tem[8].Split('/');
                        foreach (string s in boisson)
                        {
                            string[] elem = s.Split('-');
                            if (elem != null && elem.Length == 2)
                            {
                                b.Add(new Boisson(elem[0], double.Parse(elem[1])));
                            }
                        }
                        c1.Add(new Commande(int.Parse(tem[0]), tem[1],newDate,int.Parse(tem[3]) ,tem[4],tem[5], en, p, b));
                    }
                }
                lecteur.Close();
            }
            return c1;
        }
        #endregion

        #region Parti Statistique
        private void StatistiqueBtn_Click(object sender, RoutedEventArgs e)
        {
            RefreshPasOpti();
            MainGrid.Children.Add(DynamicGridStat);
        }
        #endregion

        #region Parti Administration
        private void AdminitrationBtn_Click(object sender, RoutedEventArgs e)
        {
            RefreshPasOpti();
            MainGrid.Children.Add(DynamicGridAdmin);
        }
        #endregion

        #region Parti Main
        public MainWindow()
        {
            InitializeComponent();
            Pizzerria p1 = new Pizzerria("Tom et Pierre", "Enface de l'ESILV", new List<Client>(), new List<Commis>(), new List<Livreur>());

            #region creation window Client
            // création grid dynamic
            DynamicGridClient.HorizontalAlignment = HorizontalAlignment.Left;
            DynamicGridClient.Height = 400;
            DynamicGridClient.Margin = new Thickness(0, 0, 0, 0);
            DynamicGridClient.VerticalAlignment = VerticalAlignment.Center;
            DynamicGridClient.Width = 780;

            // Create Columns
            Grid.SetRow(DynamicGridClient, 2);
            Grid.SetColumn(DynamicGridClient, 0);
            Grid.SetColumnSpan(DynamicGridClient, 4);
            ColumnDefinition gridColClient1 = new ColumnDefinition();
            DynamicGridClient.ColumnDefinitions.Add(gridColClient1);

            // Create Rows
            RowDefinition gridRowClient1 = new RowDefinition();
            gridRowClient1.Height = new GridLength(30);
            RowDefinition gridRowClient2 = new RowDefinition();
            gridRowClient2.Height = new GridLength(100);
            RowDefinition gridRowClient3 = new RowDefinition();
            gridRowClient3.Height = new GridLength(30);
            RowDefinition gridRowClient4 = new RowDefinition();
            gridRowClient4.Height = new GridLength(100);
            RowDefinition gridRowClient5 = new RowDefinition();
            gridRowClient5.Height = new GridLength(30);
            RowDefinition gridRowClient6 = new RowDefinition();
            gridRowClient6.Height = new GridLength(100);
            DynamicGridClient.RowDefinitions.Add(gridRowClient1);
            DynamicGridClient.RowDefinitions.Add(gridRowClient2);
            DynamicGridClient.RowDefinitions.Add(gridRowClient3);
            DynamicGridClient.RowDefinitions.Add(gridRowClient4);
            DynamicGridClient.RowDefinitions.Add(gridRowClient5);
            DynamicGridClient.RowDefinitions.Add(gridRowClient6);
            DynamicGridClient.Margin = new Thickness(100, 20, 0, 0);

            #region DynamicClient
            // titre 1
            TextBlock txtBlock1 = new TextBlock();
            txtBlock1.Text = "Liste des Clients";
            txtBlock1.FontSize = 14;
            txtBlock1.Width = 700;
            txtBlock1.TextAlignment = TextAlignment.Center;
            txtBlock1.Background = new SolidColorBrush(Colors.Black);
            txtBlock1.Foreground = new SolidColorBrush(Colors.Orange);
            txtBlock1.VerticalAlignment = VerticalAlignment.Top;
            txtBlock1.HorizontalAlignment = HorizontalAlignment.Center;
            txtBlock1.FontWeight = FontWeights.Bold;
            Grid.SetRow(txtBlock1, 0);
            Grid.SetColumn(txtBlock1, 0);
            Grid.SetColumnSpan(txtBlock1, 4);
            DynamicGridClient.Children.Add(txtBlock1);

            //Btn ajouter
            Button btnAddClient = new Button();
            btnAddClient.Content = "+";
            btnAddClient.Background = Brushes.Green;
            btnAddClient.Height = 15;
            btnAddClient.Width = 15;
            btnAddClient.Margin = new Thickness(150, -10, 0, 0);
            btnAddClient.Click += new RoutedEventHandler(OpenAddClient);
            DynamicGridClient.Children.Add(btnAddClient);

            //Btn del
            Button btnSuprClient = new Button();
            btnSuprClient.Content = "-";
            btnSuprClient.Background = Brushes.Red;
            btnSuprClient.Height = 15;
            btnSuprClient.Width = 15;
            btnSuprClient.Margin = new Thickness(200, -10, 0, 0);
            DynamicGridClient.Children.Add(btnSuprClient);

            //Btn Rechercher
            Button btnChercher = new Button();
            btnChercher.Content = "Chercher";
            btnChercher.BorderThickness = new Thickness(0, 0, 0, 0);
            btnChercher.Background = new SolidColorBrush(Colors.White);
            btnChercher.Height = 15;
            btnChercher.Width = 68;
            btnChercher.Margin = new Thickness(300, -11, 0, 0);
            btnChercher.Click += new RoutedEventHandler(OpenChercherClient);
            DynamicGridClient.Children.Add(btnChercher);

            // tableau des clients
            DataGrid myGridClient = new DataGrid();
            myGridClient.Width = 700;
            myGridClient.Height = 100;
            List<Client> l = ChargerCSVClient("..\\..\\..\\Clients.csv");
            this.listeClient = l;
            myGridClient.ItemsSource = l;
            myGridClient.Foreground = new SolidColorBrush(Colors.Orange);
            myGridClient.GridLinesVisibility = DataGridGridLinesVisibility.None;
            myGridClient.Margin = new Thickness(0, -22, 0, 0);
            myGridClient.BorderThickness = new Thickness(0, 0, 0, 0);
            Grid.SetRow(myGridClient, 1);
            Grid.SetColumn(myGridClient, 0);
            Grid.SetColumnSpan(myGridClient, 4);
            DynamicGridClient.Children.Add(myGridClient);
            #endregion

            #region DynamicCommis
            // titre 2
            TextBlock txtBlock2 = new TextBlock();
            txtBlock2.Text = "Liste des Commis";
            txtBlock2.FontSize = 14;
            txtBlock2.Width = 700;
            txtBlock2.HorizontalAlignment = HorizontalAlignment.Center;
            txtBlock2.VerticalAlignment = VerticalAlignment.Top;
            txtBlock2.Background = new SolidColorBrush(Colors.Black);
            txtBlock2.Foreground = new SolidColorBrush(Colors.Orange);
            txtBlock2.FontWeight = FontWeights.Bold;
            txtBlock2.TextAlignment = TextAlignment.Center;
            txtBlock2.Margin = new Thickness(0, -20, 0, 0);
            Grid.SetRow(txtBlock2, 3);
            Grid.SetColumn(txtBlock2, 0);
            DynamicGridClient.Children.Add(txtBlock2);

            // tableau des commis
            DataGrid myGridCommis = new DataGrid();
            myGridCommis.Width = 700;
            myGridCommis.Height = 100;
            myGridCommis.Margin = new Thickness(0, -135, 0, 0);
            myGridCommis.GridLinesVisibility = DataGridGridLinesVisibility.None;
            myGridCommis.ItemsSource = ChargerCSVCommis("..\\..\\..\\Commis.csv");
            myGridCommis.Foreground = new SolidColorBrush(Colors.Orange);
            myGridCommis.BorderThickness = new Thickness(0, 0, 0, 0);
            Grid.SetRow(myGridCommis, 4);
            Grid.SetColumn(myGridCommis, 0);
            DynamicGridClient.Children.Add(myGridCommis);
            #endregion

            #region DynamicLivreur
            // titre 3
            TextBlock txtBlock3 = new TextBlock();
            txtBlock3.Text = "Liste des Livreur";
            txtBlock3.FontSize = 14;
            txtBlock3.Width = 700;
            txtBlock3.Background = new SolidColorBrush(Colors.Black);
            txtBlock3.FontWeight = FontWeights.Bold;
            txtBlock3.Foreground = new SolidColorBrush(Colors.Orange);
            txtBlock3.VerticalAlignment = VerticalAlignment.Top;
            txtBlock3.Margin = new Thickness(0, -13, 0, 0);
            txtBlock3.HorizontalAlignment = HorizontalAlignment.Center;
            txtBlock3.TextAlignment = TextAlignment.Center;
            Grid.SetRow(txtBlock3, 5);
            Grid.SetColumn(txtBlock3, 0);
            DynamicGridClient.Children.Add(txtBlock3);

            // tableau des serveur
            DataGrid myGridLivreur = new DataGrid();
            myGridLivreur.Width = 700;
            myGridLivreur.Height = 100;
            myGridLivreur.Margin = new Thickness(0, 5, 0, 0);
            myGridLivreur.GridLinesVisibility = DataGridGridLinesVisibility.None;
            List<Livreur> livreur = new List<Livreur>();
            myGridLivreur.ItemsSource = ChargerCSVLivreur("..\\..\\..\\Livreur.csv");
            myGridLivreur.Foreground = new SolidColorBrush(Colors.Orange);
            myGridLivreur.BorderThickness = new Thickness(0, 0, 0, 0);
            Grid.SetRow(myGridLivreur, 6);
            Grid.SetColumn(myGridLivreur, 0);
            DynamicGridClient.Children.Add(myGridLivreur);
            #endregion
            #endregion creation window client

            #region creation window Commande
            /*=== Creation du GridGlobal ===*/
            DynamicGridCommands.HorizontalAlignment = HorizontalAlignment.Left;
            DynamicGridCommands.VerticalAlignment = VerticalAlignment.Center;
            DynamicGridCommands.Height = 400;
            DynamicGridCommands.Width = 780;
            DynamicGridCommands.Margin = new Thickness(100, 20, 0, 0);
            Grid.SetRow(DynamicGridCommands, 2);
            Grid.SetColumn(DynamicGridCommands, 0);
            Grid.SetColumnSpan(DynamicGridCommands, 4);
            /*=== Fin creation GridGlobal === */

            //Creation du tableau 
            ColumnDefinition gridColCommande = new ColumnDefinition();
            DynamicGridCommands.ColumnDefinitions.Add(gridColCommande);

            // Create Rows
            RowDefinition gridRowCommande1 = new RowDefinition();
            gridRowCommande1.Height = new GridLength(370);
            RowDefinition gridRowCommande2 = new RowDefinition();
            gridRowCommande2.Height = new GridLength(30);
            DynamicGridCommands.RowDefinitions.Add(gridRowCommande1);
            DynamicGridCommands.RowDefinitions.Add(gridRowCommande2);

            ListView ListeViewCommande = new ListView();
            ListeViewCommande.Height = 370;
            ListeViewCommande.Width = 780;
            ScrollViewer.SetHorizontalScrollBarVisibility(ListeViewCommande, ScrollBarVisibility.Hidden);
            ListeViewCommande.Background = new SolidColorBrush(Colors.White) { Opacity = 0};
            ListeViewCommande.BorderThickness = new Thickness(0,0,0,0); 
            DynamicGridCommands.Children.Add(ListeViewCommande);


            //Ajout des commandes
            List<Commande> listeCommandes = ChargerCSVCommande();
            int i = 0;
            foreach (Commande c in listeCommandes)
            {
                Grid Commande1 = new Grid();
                ColumnDefinition Test1commande1Colum = new ColumnDefinition();
                ColumnDefinition Test2commande1Colum = new ColumnDefinition();
                ColumnDefinition Test3commande1Colum = new ColumnDefinition();
                Commande1.ColumnDefinitions.Add(Test1commande1Colum);
                Commande1.ColumnDefinitions.Add(Test2commande1Colum);
                Commande1.ColumnDefinitions.Add(Test3commande1Colum);

                Commande1.HorizontalAlignment = HorizontalAlignment.Left;
                Commande1.VerticalAlignment = VerticalAlignment.Top;
                Commande1.Height = 100;
                Commande1.Width = 750;
                Commande1.Margin = new Thickness(0, 0, 0, 0);
                Commande1.Background = new SolidColorBrush(Colors.DarkGray);
                Grid.SetRow(Commande1, i);
                ListeViewCommande.Items.Add(Commande1);

                Label pizzas = new Label();
                //pizzas.Foreground = new SolidColorBrush(Colors.White);
                foreach (Pizza p in c.ListePizza)
                {
                    pizzas.Content += p.AffichePizza();
                }
                Grid.SetColumn(pizzas, 0);
                Commande1.Children.Add(pizzas);

                Label extra = new Label();
                //extra.Foreground = new SolidColorBrush(Colors.White);

                foreach (Boisson b in c.ProduitAnnexes)
                {
                    extra.Content = b.AfficherBoisson();
                }
                Grid.SetColumn(extra, 1);
                Commande1.Children.Add(extra);

                Label Infos = new Label();
                //Infos.Foreground = new SolidColorBrush(Colors.White);

                Infos.Content += "Num commande :" + c.NumCommande + "\nClient : " + c.NomClient + "\nCommis : " + c.NomCommis + "\nHeure :" + c.Heure + "\nEtat : " + c.Etat;
                Grid.SetColumn(Infos, 2);
                Commande1.Children.Add(Infos);

                i++;
            }

            //Ajout des btns
            Button btnCommander = new Button();
            btnCommander.Content = "Commander";
            btnCommander.Height = 30;
            btnCommander.Width = 100;
            btnCommander.Background = new SolidColorBrush(Colors.Orange);
            Grid.SetRow(btnCommander, 1);
            btnCommander.Click += new RoutedEventHandler(OpenCommandeWindow);
            DynamicGridCommands.Children.Add(btnCommander);
            #endregion creation window Administration


        }
        #endregion
    }
}
