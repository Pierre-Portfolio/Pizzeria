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
    /// Logique d'interaction pour PasserCommande.xaml
    /// </summary>
    public partial class PasserCommande : Window
    {
        public Commande currentCommande;
        public Client currentClient;
        public PasserCommande()
        {
            currentCommande = new Commande();
            currentClient = null;
            InitializeComponent();
        }

        public PasserCommande(Client c)
        {
            currentClient = c;
            currentCommande = new Commande(currentClient.TelClient, currentClient.NomClient);
            InitializeComponent();
        }

        private void Click_btnPizza(object sender, RoutedEventArgs e)
        {
            
            CanvaExtra.Visibility = Visibility.Hidden;
            CanvaPizza.Visibility = Visibility.Visible;
        }

        private void Click_btnExtra(object sender, RoutedEventArgs e)
        {
            CanvaPizza.Visibility = Visibility.Hidden;
            CanvaExtra.Visibility = Visibility.Visible;

        }

        private void AddCumulClient()
        {
            List<Client> c1 = new List<Client>();
            string path = "..\\..\\..\\Clients.csv";
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
                        c1.Add(new Client(Convert.ToInt32(tem[0]), tem[1], tem[2], tem[3], int.Parse(tem[4]), new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0])), int.Parse(tem[6])));
                    }
                }
                lecteur.Close();
            }
            StreamWriter writer = new StreamWriter(path);
            foreach(Client c in c1)
            {
                if(c.TelClient == currentClient.TelClient)
                {
                    c.CmlCmd++;
                }
                string line = c.NumClient + ";" + c.NomClient + ";" + c.PrenomClient + ";" + c.AdrClient + ";" + c.TelClient + ";" + c.DatePremiereCmd.Day + "/" + c.DatePremiereCmd.Month + "/" + c.DatePremiereCmd.Year + ";" + c.CmlCmd;
                writer.WriteLine(line);
            }
            writer.Close();
        }
        private void Click_btnValider(object sender, RoutedEventArgs e) //Ajout de la commande au csv
        {
            if (currentCommande.ListePizza != null && currentCommande.ListePizza.Count != 0)
            {
                string path = "..\\..\\..\\Commandes.csv";
                string date = currentCommande.Date.Day + "/" + currentCommande.Date.Month + "/" + currentCommande.Date.Year;
                string line = currentCommande.NumCommande + ";" + currentCommande.Heure + "h;" +date + ";" + currentCommande.NumeroClient + ";"+currentClient.NomClient + ";" + "chenal" + ";" + currentCommande.Etat.ToString() + ";";
                for (int i = 0; i < currentCommande.ListePizza.Count; i++)
                {
                    if (currentCommande.ListePizza[i].Garnitures.Count != 0)
                    {
                        line += currentCommande.ListePizza[i].Taille + ",";
                        for (int j = 0; j < currentCommande.ListePizza[i].Garnitures.Count; j++)
                        {
                            if (j >= currentCommande.ListePizza[i].Garnitures.Count - 1)
                            {
                                if (i >= currentCommande.ListePizza.Count-1)
                                    line += currentCommande.ListePizza[i].Garnitures[j].ToString();
                                else
                                    line += currentCommande.ListePizza[i].Garnitures[j].ToString() + "/";
                            }
                            else
                            {
                                line += currentCommande.ListePizza[i].Garnitures[j].ToString() + ",";
                            }
                        }
                    }
                    else
                    {
                        if (i >= currentCommande.ListePizza.Count - 1)
                        {
                            line += currentCommande.ListePizza[i].Taille;
                        }
                        else
                        {
                            line += currentCommande.ListePizza[i].Taille + "/";
                        }
                    }
                }
                line += ";";
                for(int i = 0; i < currentCommande.ProduitAnnexes.Count; i++)
                {
                    if (i == currentCommande.ProduitAnnexes.Count - 1)
                    {
                        line += currentCommande.ProduitAnnexes[i].NomBoisson+"-"+ currentCommande.ProduitAnnexes[i].Volume;
                    }
                    else
                    {
                        line += currentCommande.ProduitAnnexes[i].NomBoisson + "-" + currentCommande.ProduitAnnexes[i].Volume+"/";
                    }
                }
                if (!File.Exists(path))
                {
                    // Creation du fichier.
                    StreamWriter sw = File.CreateText(path);
                    sw.WriteLine(line);
                    sw.Close();
                }
                else
                {
                    StreamWriter sw = File.AppendText(path);
                    sw.WriteLine(line);
                    sw.Close();
                }
                AddCumulClient();
                MessageBox.Show("Commande envoyé en cuisine !", "Commande");
                this.Close();
            }
            else
            {
                MessageBox.Show("Probleme saisie commande", "Erreur");
            }
        }

        private void Click_Ajouter_Extra(object sender, RoutedEventArgs e)
        {
            string s = Coca.IsChecked == true ? "Coca" : Sprite.IsChecked == true ? "Sprite" : Fanta.IsChecked == true ? "Fanta" : "RedBull";
            double volume = DemiLitre.IsChecked == true ? 0.5 : Litre.IsChecked == true ? 1 : LitreDemi.IsChecked == true ? 1.5 : 2;
            currentCommande.ProduitAnnexes.Add(new Boisson(s, volume));
            Coca.IsChecked = false;
            Sprite.IsChecked = false;
            Fanta.IsChecked = false;
            RedBull.IsChecked = false;
            DemiLitre.IsChecked = false;
            Litre.IsChecked = false;
            LitreDemi.IsChecked = false;
            Litre2.IsChecked = false;
            CanvaExtra.Visibility = Visibility.Hidden;
            refreshAffichage();

        }
        private void Click_Ajouter_SelectPizza(object sender, RoutedEventArgs e)
        {
            Pizza.TaillePizza t = RadioPetit.IsChecked == true ? Pizza.TaillePizza.Petite : RadioMoy.IsChecked == true? Pizza.TaillePizza.Moyenne : Pizza.TaillePizza.Grande;
            List<Pizza.Garniture> listeGarn = new List<Pizza.Garniture>();
            if (checkFromage.IsChecked == true)
            {
                listeGarn.Add(Pizza.Garniture.Fromage);
            }
            if (checkVege.IsChecked == true)
            {
                listeGarn.Add(Pizza.Garniture.Vegetarienne);
            }
            if (checkSauceT.IsChecked == true)
            {
                listeGarn.Add(Pizza.Garniture.Sauce_tomate);
            }
            if (checkTouteG.IsChecked == true)
            {
                listeGarn.Add(Pizza.Garniture.Toute_garnies);
            }
            Pizza p = new Pizza(listeGarn,t);
            currentCommande.ListePizza.Add(p);
            CanvaPizza.Visibility = Visibility.Hidden;
            checkFromage.IsChecked = false;
            checkVege.IsChecked = false;
            checkSauceT.IsChecked = false;
            checkTouteG.IsChecked = false;
            RadioPetit.IsChecked = false;
            RadioMoy.IsChecked = false;
            RadioGrand.IsChecked = false;

            refreshAffichage();
        }

        private void refreshAffichage()
        {
            ListView AfficheCommande = new ListView();
            AfficheCommande.Height = 200;
            AfficheCommande.Width = 250;
            AfficheCommande.Background = new SolidColorBrush(Colors.White) { Opacity = 0 };

            CanvaAfficheCommande.Children.Add(AfficheCommande);
            if(currentCommande != null)
            {
                if(currentCommande.ListePizza != null && currentCommande.ListePizza.Count != 0)
                {
                    foreach (Pizza p in currentCommande.ListePizza)
                    {
                        Button currentPizza = new Button();
                        currentPizza.Content = "Pizza :" + p.AffichePizza();
                        AfficheCommande.Items.Add(currentPizza);
                        
                    }

                }
                if(currentCommande.ProduitAnnexes != null && currentCommande.ProduitAnnexes.Count != 0)
                {
                    foreach(Boisson b in currentCommande.ProduitAnnexes)
                    {
                        Button currentBoisson = new Button();
                        currentBoisson.Content = "Boisson : " + b.AfficherBoisson();
                        AfficheCommande.Items.Add(currentBoisson);
                    }
                }
            }
            CanvaPizza.Visibility = Visibility.Hidden;
            CanvaExtra.Visibility = Visibility.Hidden;

        }
    }
}
