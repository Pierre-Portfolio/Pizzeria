﻿using System;
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
        public string actualWindow = "home";

        // On crée toutes les pages dynamique
        Grid DynamicGridClient = new Grid();
        Grid DynamicGridCommands = new Grid();
        Grid DynamicGridStat= new Grid();
        Grid DynamicGridAdmin = new Grid();
        #endregion

        #region fonction refresh
        public void RefreshHard()
        {
            if(actualWindow != "home")
            {
                MainGrid.Children.RemoveAt(6);
            }
        }

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

        public List<Client> ChargerCSVClient(string path)
        {
            List<Client> c1 = new List<Client>();
            if (File.Exists(path))
            {
                c1.Add(new Client(1, "11 rue machin", "Pierre", "CheminExiste", "601020304"));
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
                        c1.Add(new Client(Convert.ToInt32(tem[0]), tem[1], tem[2], tem[3],tem[4]));
                    }
                }
                lecteur.Close();
            }
            else
            {
                c1.Add(new Client(2, "11 rue machin", "Pierre", "Jean", "601020304"));
            }
            return c1;
        }

        public List<Commis> ChargerCSVCommis(string path)
        {
            List<Commis> c1 = new List<Commis>();
            if (File.Exists(path))
            {
                c1.Add(new Commis("Chene", "Alain", "23 rue des Louviers 75002 Paris", "0613424305", "surplace", new DateTime(2020 , 10 , 10)));
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
            else
            {
                c1.Add(new Commis("Chemin", "Alain", "23 rue des Louviers 75002 Paris", "0613424305", "surplace", new DateTime(2020, 10, 10)));
            }
            return c1;
        }

        public List<Livreur> ChargerCSVLivreur(string path)
        {
            List<Livreur> c1 = new List<Livreur>();
            if (File.Exists(path))
            {
                c1.Add(new Livreur("Chenal", "Louis", "23 rue des frenes 75003 Paris", "0613424305", "surplace", "velo"));
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
            else
            {
                c1.Add(new Livreur("Chemin", "Louis", "23 rue des frenes 75003 Paris", "0613424305", "surplace", "velo"));
            }
            return c1;
        }
        #endregion

        #region Parti Commande
        private void CommandesBtn_Click(object sender, RoutedEventArgs e)
        {
            RefreshPasOpti();
            MainGrid.Children.Add(DynamicGridCommands);
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
            DynamicGridClient.Margin = new Thickness(100, 20, 0, 0);


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
            Grid.SetColumnSpan(txtBlock1, 4);
            DynamicGridClient.Children.Add(txtBlock1);

            // tableau des clients
            DataGrid myGridClient = new DataGrid();
            myGridClient.Width = 700;
            myGridClient.Height = 80;
            myGridClient.ItemsSource = ChargerCSVClient("..\\..\\..\\Clients.csv");
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
            myGridCommis.Width = 700;
            myGridCommis.Height = 80;
            myGridCommis.Margin = new Thickness(0, -45, 0, 0);
            myGridCommis.ItemsSource = ChargerCSVCommis("..\\..\\..\\Commis.csv");
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
            myGridLivreur.Width = 700;
            myGridLivreur.Height = 80;
            myGridLivreur.Margin = new Thickness(0, 20, 0, 0);
            List<Livreur> livreur = new List<Livreur>();
            myGridLivreur.ItemsSource = ChargerCSVLivreur("..\\..\\..\\Livreur.csv");
            myGridLivreur.Foreground = new SolidColorBrush(Colors.Orange);
            Grid.SetRow(myGridLivreur, 6);
            Grid.SetColumn(myGridLivreur, 0);
            DynamicGridClient.Children.Add(myGridLivreur);
            #endregion creation window client

            #region creation window Commande
            // création grid dynamic
            DynamicGridCommands.HorizontalAlignment = HorizontalAlignment.Left;
            DynamicGridCommands.Height = 324;
            DynamicGridCommands.Margin = new Thickness(27, 0, 0, 0);
            DynamicGridCommands.VerticalAlignment = VerticalAlignment.Center;
            DynamicGridCommands.Width = 743;
            #endregion creation window Commande

            #region creation window Statistique
            // création grid dynamic
            DynamicGridStat.HorizontalAlignment = HorizontalAlignment.Left;
            DynamicGridStat.Height = 324;
            DynamicGridStat.Margin = new Thickness(27, 0, 0, 0);
            DynamicGridStat.VerticalAlignment = VerticalAlignment.Center;
            DynamicGridStat.Width = 743;
            #endregion creation window Statistique

            #region creation window Administration
            DynamicGridAdmin.HorizontalAlignment = HorizontalAlignment.Left;
            DynamicGridAdmin.Height = 324;
            DynamicGridAdmin.Margin = new Thickness(27, 0, 0, 0);
            DynamicGridAdmin.VerticalAlignment = VerticalAlignment.Center;
            DynamicGridAdmin.Width = 743;
            #endregion creation window Administration


        }
        #endregion
    }
}
