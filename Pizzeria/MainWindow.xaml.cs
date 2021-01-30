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
using System.ComponentModel;

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
        DataGrid myGridClient = new DataGrid();
        DataGrid myGridCommis = new DataGrid();
        DataGrid myGridLivreur = new DataGrid();

        Grid DynamicGridCommands = new Grid();
        ListView ListeViewCommande = new ListView();

        Grid DynamicGridStat= new Grid();
        Grid DynamicGridAdmin = new Grid();

        public Pizzerria p1;
        #endregion

        #region fonction refresh


        public void RefreshPasOpti()
        {
            p1.Refresh();
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
        private void OpenAddClient(object sender, RoutedEventArgs e)
        {
            var WindowAddClient = new AddClient(p1);
            WindowAddClient.Show();
        }
        private void OpenChercherClient(object sender, RoutedEventArgs e)
        {
            var WindowChercher = new Rechercher(this.p1);
            WindowChercher.Show();
        }
        private void OpenAddCommis(object sender, RoutedEventArgs e)
        {
            var WindowAddComis = new addCommis();
            WindowAddComis.Show();
            this.Close();
        }
        private void OpenAddLivreur(object sender, RoutedEventArgs e)
        {
            var WindowAddLivreur = new AddLivreur();
            WindowAddLivreur.Show();
            this.Close();
        }
        private void ButtonModifClient(object sender, RoutedEventArgs e)
        {
            if (myGridClient.SelectedItems.Count == 1)
            {
                foreach (Object o in myGridClient.SelectedItems)
                {
                    ModifClient w = new ModifClient((Client)o,p1);
                    w.Show();
                    w.BoxNom.Text = ((Client)o).NomClient;
                    w.BoxPrenom.Text = ((Client)o).PrenomClient;
                    w.BoxAdresse.Text = ((Client)o).AdrClient;
                    w.BoxTel.Text = Convert.ToString(((Client)o).TelClient);
                }
            }
            else
            {
                MessageBox.Show("Le nombre de ligne selectionné est incorrect ! ");
            }
        }


        private void BtnModifCommis(object sender, RoutedEventArgs e)
        {
            if (myGridCommis.SelectedItems.Count == 1)
            {
                foreach (Object o in myGridCommis.SelectedItems)
                {
                    ModifCommis w = new ModifCommis((Commis)o, p1);
                    w.Show();
                    
                    w.BoxNom.Text = ((Commis)o).NomEmploye;
                    w.BoxPrenom.Text = ((Commis)o).PrenomEmploye;
                    w.BoxAdresse.Text = ((Commis)o).AdrEmploye;
                    w.BoxTel.Text = Convert.ToString(((Commis)o).NumEmploye);

                    w.ComboBoxEtat.ItemsSource = Enum.GetValues(typeof(Commis.etat_commis)).Cast<Commis.etat_commis>();
                    w.ComboBoxEtat.Text = ((Commis)o).EtatCommis.ToString();
                    
                }
            }
            else
            {
                MessageBox.Show("Le nombre de ligne selectionné est incorrect ! ");
            }
        }

        private void BtnModifLivreur(object sender, RoutedEventArgs e)
        {
            if (myGridLivreur.SelectedItems.Count == 1)
            {
                foreach (Object o in myGridLivreur.SelectedItems)
                {

                    ModifLivreur w = new ModifLivreur((Livreur)o, p1);
                    w.Show();

                    w.BoxNom.Text = ((Livreur)o).NomEmploye;
                    w.BoxPrenom.Text = ((Livreur)o).PrenomEmploye;
                    w.BoxAdresse.Text = ((Livreur)o).AdrEmploye;
                    w.BoxTel.Text = Convert.ToString(((Livreur)o).NumEmploye);

                    w.ComboBoxEtat.ItemsSource = Enum.GetValues(typeof(Livreur.etat_livreur)).Cast<Livreur.etat_livreur>();
                    w.ComboBoxEtat.Text = ((Livreur)o).EtatLivreur.ToString();

                    w.ComboBoxTransport.ItemsSource = Enum.GetValues(typeof(Livreur.moyen_Livraison)).Cast<Livreur.moyen_Livraison>();
                    w.ComboBoxTransport.Text = ((Livreur)o).MoyenLivraison.ToString();

                }
            }
            else
            {
                MessageBox.Show("Le nombre de ligne selectionné est incorrect ! ");
            }
        }
        #endregion

        #region Parti Commande
        private void CommandesBtn_Click(object sender, RoutedEventArgs e)
        {
            RefreshPasOpti();
            AjoutCommande();
            MainGrid.Children.Add(DynamicGridCommands);
        }
        #endregion

        #region Parti Statistique
        private void StatistiqueBtn_Click(object sender, RoutedEventArgs e)
        {
            RefreshPasOpti();
            Frame frame = new Frame();
            frame.Content = new Statistiques();
            DynamicGridStat.Children.Add(frame);
            MainGrid.Children.Add(DynamicGridStat);
        }

        private void GenerationPageStatistiques()
        {
            /* ==== Creation partie client ====*/
            // création grid dynamic
            DynamicGridStat.HorizontalAlignment = HorizontalAlignment.Left;
            DynamicGridStat.VerticalAlignment = VerticalAlignment.Center;
            DynamicGridStat.Height = 400;
            DynamicGridStat.Width = 780;
            DynamicGridStat.Margin = new Thickness(0, 0, 0, 0);
            Grid.SetRow(DynamicGridStat, 2);
            Grid.SetColumn(DynamicGridStat, 0);
            Grid.SetColumnSpan(DynamicGridStat, 4);
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
        public void BlockBtnBase()
        {
            if(p1.CurrentUser is Commis)
            {
                ClientsBtn.IsEnabled = true;
                CommandesBtn.IsEnabled = true;
                StatistiqueBtn.IsEnabled = true;
                AdminitrationBtn.IsEnabled = true;
            }
            else if(p1.CurrentUser is Livreur)
            {
                CommandesBtn.IsEnabled = true;
            }
            else
            {   
                ClientsBtn.IsEnabled = false;
                CommandesBtn.IsEnabled = false;
                StatistiqueBtn.IsEnabled = false;
                AdminitrationBtn.IsEnabled = false;
            }
        }
        public void GenerationPageClient()
        {
            /* ==== Creation partie client ====*/
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
            btnAddClient.Content = "";
            btnAddClient.Background = Brushes.Green;
            btnAddClient.Height = 15;
            btnAddClient.Width = 15;
            btnAddClient.BorderThickness = new Thickness(0, 0, 0, 0);
            btnAddClient.Margin = new Thickness(150, -11, 0, 0);
            btnAddClient.ToolTip = "Ajouter un client";
            btnAddClient.Background = new ImageBrush(new BitmapImage(new Uri(@"https://cdn.pixabay.com/photo/2014/04/02/10/41/button-304224_640.png")));
            btnAddClient.Click += new RoutedEventHandler(OpenAddClient);
            DynamicGridClient.Children.Add(btnAddClient);

            //Btn modifier
            Button btnModifClient = new Button();
            btnModifClient.Content = "";
            btnModifClient.Background = Brushes.Green;
            btnModifClient.Height = 15;
            btnModifClient.Width = 15;
            btnModifClient.BorderThickness = new Thickness(0, 0, 0, 0);
            btnModifClient.Margin = new Thickness(200, -11, 0, 0);
            btnModifClient.ToolTip = "Modifier un client";
            btnModifClient.Background = new ImageBrush(new BitmapImage(new Uri(@"https://cdn.pixabay.com/photo/2016/03/29/06/22/edit-1287617_1280.png")));
            btnModifClient.Click += new RoutedEventHandler(ButtonModifClient);
            DynamicGridClient.Children.Add(btnModifClient);

            //Btn del
            Button btnSuprClient = new Button();
            btnSuprClient.Content = "";
            btnSuprClient.Background = Brushes.Red;
            btnSuprClient.Height = 15;
            btnSuprClient.Width = 15;
            btnSuprClient.BorderThickness = new Thickness(0, 0, 0, 0);
            btnSuprClient.ToolTip = "Supprimer un client";
            btnSuprClient.Background = new ImageBrush(new BitmapImage(new Uri(@"https://cdn.pixabay.com/photo/2013/07/12/17/00/remove-151678_960_720.png")));
            btnSuprClient.Margin = new Thickness(250, -11, 0, 0);
            DynamicGridClient.Children.Add(btnSuprClient);

            //Btn Rechercher
            Button btnChercher = new Button();
            btnChercher.Content = "";
            btnChercher.BorderThickness = new Thickness(0, 0, 0, 0);
            btnChercher.Background = new SolidColorBrush(Colors.White);
            btnChercher.Background = new ImageBrush(new BitmapImage(new Uri(@"https://www.icone-png.com/png/1/1402.png")));
            btnChercher.Height = 15;
            btnChercher.Width = 15;
            btnChercher.ToolTip = "Rechercher un client";
            btnChercher.Margin = new Thickness(300, -11, 0, 0);
            btnChercher.Click += new RoutedEventHandler(OpenChercherClient);
            DynamicGridClient.Children.Add(btnChercher);

            // tableau des clients
            myGridClient.Width = 700;
            myGridClient.Height = 100;
            Dictionary<int, Client> l = p1.Clients;
            myGridClient.ItemsSource = l.Values;
            myGridClient.Foreground = new SolidColorBrush(Colors.Orange);
            myGridClient.GridLinesVisibility = DataGridGridLinesVisibility.None;
            myGridClient.Margin = new Thickness(0, -22, 0, 0);
            myGridClient.BorderThickness = new Thickness(0, 0, 0, 0);
            myGridClient.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
            myGridClient.IsReadOnly = true;
            Grid.SetRow(myGridClient, 1);
            Grid.SetColumn(myGridClient, 0);
            Grid.SetColumnSpan(myGridClient, 4);
            DynamicGridClient.Children.Add(myGridClient);
            #endregion
            /* ==== Fin creation partie client ====*/

            /* ==== Debut creation partie commis ====*/
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
            txtBlock2.Margin = new Thickness(0, -22, 0, 0);
            Grid.SetRow(txtBlock2, 3);
            Grid.SetColumn(txtBlock2, 0);
            DynamicGridClient.Children.Add(txtBlock2);

            //Btn ajouter
            Button btnAddCommis = new Button();
            btnAddCommis.Content = "";
            btnAddCommis.Background = Brushes.Green;
            btnAddCommis.Height = 15;
            btnAddCommis.Width = 15;
            btnAddCommis.BorderThickness = new Thickness(0, 0, 0, 0);
            btnAddCommis.Margin = new Thickness(154, -125, 0, 0);
            btnAddCommis.Click += new RoutedEventHandler(OpenAddCommis);
            btnAddCommis.ToolTip = "Ajouter un commis";
            btnAddCommis.Background = new ImageBrush(new BitmapImage(new Uri(@"https://cdn.pixabay.com/photo/2014/04/02/10/41/button-304224_640.png")));
            Grid.SetRow(btnAddCommis, 3);
            Grid.SetColumn(btnAddCommis, 0);
            DynamicGridClient.Children.Add(btnAddCommis);

            //Btn modifier
            Button btnModifCommis = new Button();
            btnModifCommis.Content = "";
            btnModifCommis.Background = Brushes.Green;
            btnModifCommis.Height = 15;
            btnModifCommis.Width = 15;
            btnModifCommis.BorderThickness = new Thickness(0, 0, 0, 0);
            btnModifCommis.Margin = new Thickness(204, -125, 0, 0);
            btnModifCommis.ToolTip = "Modifier un commis";
            btnModifCommis.Background = new ImageBrush(new BitmapImage(new Uri(@"https://cdn.pixabay.com/photo/2016/03/29/06/22/edit-1287617_1280.png")));
            btnModifCommis.Click += new RoutedEventHandler(BtnModifCommis);
            Grid.SetRow(btnModifCommis, 3);
            Grid.SetColumn(btnModifCommis, 0);
            DynamicGridClient.Children.Add(btnModifCommis);

            //Btn del
            Button btnSuprCommis = new Button();
            btnSuprCommis.Content = "";
            btnSuprCommis.Background = Brushes.Red;
            btnSuprCommis.Height = 15;
            btnSuprCommis.Width = 15;
            btnSuprCommis.BorderThickness = new Thickness(0, 0, 0, 0);
            btnSuprCommis.Background = new ImageBrush(new BitmapImage(new Uri(@"https://cdn.pixabay.com/photo/2013/07/12/17/00/remove-151678_960_720.png")));
            btnSuprCommis.Margin = new Thickness(254, -125, 0, 0);
            btnSuprCommis.ToolTip = "Supprimer un commis";
            Grid.SetRow(btnSuprCommis, 3);
            Grid.SetColumn(btnSuprCommis, 0);
            DynamicGridClient.Children.Add(btnSuprCommis);

            // tableau des commis
            myGridCommis.Width = 700;
            myGridCommis.Height = 100;
            myGridCommis.Margin = new Thickness(0, -135, 0, 0);
            myGridCommis.GridLinesVisibility = DataGridGridLinesVisibility.None;
            myGridCommis.ItemsSource = p1.Commis;
            myGridCommis.Foreground = new SolidColorBrush(Colors.Orange);
            myGridCommis.BorderThickness = new Thickness(0, 0, 0, 0);
            myGridCommis.IsReadOnly = true;
            Grid.SetRow(myGridCommis, 4);
            Grid.SetColumn(myGridCommis, 0);
            DynamicGridClient.Children.Add(myGridCommis);

            #endregion
            /* ==== Fin creation partie commis ====*/

            /* ==== Debut creation partie Livreur ====*/
            #region DynamicLivreur
            // titre 3
            TextBlock txtBlock3 = new TextBlock();
            txtBlock3.Text = "Liste des Livreurs";
            txtBlock3.FontSize = 14;
            txtBlock3.Width = 700;
            txtBlock3.Background = new SolidColorBrush(Colors.Black);
            txtBlock3.FontWeight = FontWeights.Bold;
            txtBlock3.Foreground = new SolidColorBrush(Colors.Orange);
            txtBlock3.VerticalAlignment = VerticalAlignment.Top;
            txtBlock3.Margin = new Thickness(0, -15, 0, 0);
            txtBlock3.HorizontalAlignment = HorizontalAlignment.Center;
            txtBlock3.TextAlignment = TextAlignment.Center;
            Grid.SetRow(txtBlock3, 5);
            Grid.SetColumn(txtBlock3, 0);
            DynamicGridClient.Children.Add(txtBlock3);

            //Btn ajouter
            Button btnAddLivreur = new Button();
            btnAddLivreur.Content = "";
            btnAddLivreur.Background = Brushes.Green;
            btnAddLivreur.Height = 15;
            btnAddLivreur.Width = 15;
            btnAddLivreur.BorderThickness = new Thickness(0, 0, 0, 0);
            btnAddLivreur.Margin = new Thickness(154, -110, 0, 0);
            btnAddLivreur.ToolTip = "Ajouter un livreur";
            btnAddLivreur.Click += new RoutedEventHandler(OpenAddLivreur);
            btnAddLivreur.Background = new ImageBrush(new BitmapImage(new Uri(@"https://cdn.pixabay.com/photo/2014/04/02/10/41/button-304224_640.png")));
            Grid.SetRow(btnAddLivreur, 5);
            Grid.SetColumn(btnAddLivreur, 0);
            DynamicGridClient.Children.Add(btnAddLivreur);
            
            //Btn modifier
            Button btnModifLivreur = new Button();
            btnModifLivreur.Content = "";
            btnModifLivreur.Background = Brushes.Green;
            btnModifLivreur.Height = 15;
            btnModifLivreur.Width = 15;
            btnModifLivreur.BorderThickness = new Thickness(0, 0, 0, 0);
            btnModifLivreur.Margin = new Thickness(204, -110, 0, 0);
            btnModifLivreur.ToolTip = "Modifier un livreur";
            btnModifLivreur.Background = new ImageBrush(new BitmapImage(new Uri(@"https://cdn.pixabay.com/photo/2016/03/29/06/22/edit-1287617_1280.png")));
            btnModifLivreur.Click += new RoutedEventHandler(BtnModifLivreur);
            Grid.SetRow(btnModifLivreur, 5);
            Grid.SetColumn(btnModifLivreur, 0);
            DynamicGridClient.Children.Add(btnModifLivreur);

            // tableau des serveur
            myGridLivreur.Width = 700;
            myGridLivreur.Height = 100;
            myGridLivreur.Margin = new Thickness(0, 5, 0, 0);
            myGridLivreur.GridLinesVisibility = DataGridGridLinesVisibility.None;
            myGridLivreur.ItemsSource = p1.Livreur;
            myGridLivreur.Foreground = new SolidColorBrush(Colors.Orange);
            myGridLivreur.BorderThickness = new Thickness(0, 0, 0, 0);
            Grid.SetRow(myGridLivreur, 6);
            Grid.SetColumn(myGridLivreur, 0);
            DynamicGridClient.Children.Add(myGridLivreur);

            #endregion
            /* ==== Debut creation partie Livreur ====*/


        }

        public void GenerationPageCommande()
        {
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
            gridRowCommande1.Height = new GridLength(30);
            RowDefinition gridRowCommande2 = new RowDefinition();
            gridRowCommande2.Height = new GridLength(300); 
            RowDefinition gridRowCommande3 = new RowDefinition();
            gridRowCommande3.Height = new GridLength(40);
            DynamicGridCommands.RowDefinitions.Add(gridRowCommande1);
            DynamicGridCommands.RowDefinitions.Add(gridRowCommande2);
            DynamicGridCommands.RowDefinitions.Add(gridRowCommande3);

            //Ajout des btns
            Image pictTextCmd = new Image();
            pictTextCmd.Height = 30;
            pictTextCmd.Width = 773;
            pictTextCmd.Margin = new Thickness(5, 0, 0, 0);
            Uri resourceUri = new Uri("..\\..\\..\\titrecmd.png", UriKind.Relative);
            pictTextCmd.Source = new BitmapImage(resourceUri);
            pictTextCmd.Stretch = Stretch.Fill;
            Grid.SetRow(pictTextCmd, 0);
            DynamicGridCommands.Children.Add(pictTextCmd);
        }

        public void AjoutCommande()
        {
            //Création liste view
            DynamicGridCommands.Children.Remove(ListeViewCommande);
            ListeViewCommande.Items.Clear();

            ListeViewCommande.Height = 370;
            ListeViewCommande.Width = 780;
            ScrollViewer.SetHorizontalScrollBarVisibility(ListeViewCommande, ScrollBarVisibility.Hidden);
            ListeViewCommande.Background = new SolidColorBrush(Colors.White) { Opacity = 0 };
            ListeViewCommande.BorderThickness = new Thickness(0, 0, 0, 0);
            Grid.SetRow(ListeViewCommande, 1);
            DynamicGridCommands.Children.Add(ListeViewCommande);
            //Ajout des commandes
            int i = 0;
            p1.Commandes.ForEach(c =>
            {
                if (p1.CurrentUser is Commis || (p1.CurrentUser is Livreur && (c.Etat == Commande.EtatCommande.en_preparation || (c.Etat == Commande.EtatCommande.en_livraison && c.LivreurCharge.NumEmploye.Equals(p1.CurrentUser.NumEmploye)))))
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
                    c.ListePizza.ForEach(p =>
                        pizzas.Content += p.AffichePizza()
                    );
                    Grid.SetColumn(pizzas, 0);
                    Commande1.Children.Add(pizzas);

                    Label extra = new Label();
                    //extra.Foreground = new SolidColorBrush(Colors.White);
                    c.ProduitAnnexes.ForEach(b =>
                        extra.Content = b.AfficherBoisson()
                    );
                    Grid.SetColumn(extra, 1);
                    Commande1.Children.Add(extra);

                    Label Infos = new Label();
                    //Infos.Foreground = new SolidColorBrush(Colors.White);

                    Infos.Content += "Num commande :" + c.NumCommande + "\nClient : " + c.NomClient + "\nCommis : " + c.NomCommis + "\nHeure :" + c.Heure + "\nEtat : " + c.Etat;
                    Grid.SetColumn(Infos, 2);
                    Commande1.Children.Add(Infos);

                    i++;
                }
            });

            //Ajout bouton prise en charge commande
            Button priseEncharge = new Button();
            priseEncharge.Width = 780;
            priseEncharge.Height = 30;
            priseEncharge.Background = new SolidColorBrush(Colors.Green);
            priseEncharge.BorderThickness = new Thickness(0, 0, 0, 0);
            priseEncharge.Margin = new Thickness(0, 10, 0,0);
            priseEncharge.Click += new RoutedEventHandler(PriseEnChargeCommande);
            if (p1.CurrentUser is Livreur)
            {
                priseEncharge.Content = "Prendre une commande en charge";
            }
            else
            {
                priseEncharge.Content = "Encaisser une commande";
            }
            Grid.SetRow(priseEncharge, 2);
            DynamicGridCommands.Children.Add(priseEncharge);
        }
        
        public void PriseEnChargeCommande(object sender, RoutedEventArgs e)
        {
            var WindowPriseEnCharge = new PagePriseEnCharge(this.p1);
            WindowPriseEnCharge.Show();
        }
        public MainWindow()
        {
            InitializeComponent();
            this.p1 = new Pizzerria("Tom et Pierre", "En face de l'ESILV");

            BlockBtnBase();
            GenerationPageClient();
            GenerationPageCommande();
            GenerationPageStatistiques();
        }
        #endregion

        #region Connexion application
        private void Click_Connection(object sender, RoutedEventArgs e)
        {
            if(BoxNom.Text.Length != 0 && PasseWordBox.Password.Length != 0)
            {
                Commis c = null;
                foreach(Commis current in p1.Commis)
                {
                    if (current.NomEmploye.Equals(BoxNom.Text))
                    {
                        c = current;
                    }
                }
                if (c != null && c.MdpEmploye.Equals(PasseWordBox.Password)) 
                {
                    p1.CurrentUser = c;
                    BlockBtnBase();
                    CanvaConnexion.Visibility = Visibility.Hidden;
                }
                else
                {
                    Livreur l = null;
                    foreach(Livreur current in p1.Livreur)
                    {
                        if (current.NomEmploye.Equals(BoxNom.Text))
                        {
                            l = current;
                        }
                    }
                    if (l != null && l.MdpEmploye.Equals(PasseWordBox.Password))
                    {
                        p1.CurrentUser = l;
                        BlockBtnBase();
                        CanvaConnexion.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        MessageBox.Show("Erreur", "Erreur");
                    }
                }
            }
        }
        #endregion connection application
    }
}
