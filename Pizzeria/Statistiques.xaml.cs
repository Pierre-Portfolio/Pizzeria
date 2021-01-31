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
    /// Logique d'interaction pour Statistiques.xaml
    /// </summary>
    public partial class Statistiques : Page
    {
        public Pizzerria p;
        public double prixMoyen = 0;
        public double prixMoyPeriode = 0;
        public Statistiques(Pizzerria p)
        {
            InitializeComponent();
            this.p = p;
            Calendar.DisplayDate = DateTime.Now;
            Calendar.DisplayDateEnd = DateTime.Now;
            Calendar.DisplayDateStart = new DateTime(2010,01,01);
            InitAll();
        }
        /// <summary>
        /// Ajout des commandes à la liste des commande dans la page statistiques
        /// </summary>
        public void AddCommandeToList(Commande c, int i)
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
            Commande1.Width = ListViewCommandes.Width;
            Commande1.Margin = new Thickness(0, 0, 0, 0);
            if (c.Etat == Commande.EtatCommande.fermer)
                Commande1.Background = new SolidColorBrush(Colors.Green);
            else if(c.Etat == Commande.EtatCommande.perdue)
                Commande1.Background = new SolidColorBrush(Colors.Red);
            else    
                Commande1.Background = new SolidColorBrush(Colors.DarkGray);
            Grid.SetRow(Commande1, i);
            ListViewCommandes.Items.Add(Commande1);

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

            Infos.Content += "Num commande :" + c.NumCommande + "\nClient : " + c.NomClient + "\nCommis : " + c.NomCommis + "\nHeure :" + c.Heure + "h\nEtat : " + c.Etat;
            Grid.SetColumn(Infos, 2);
            Commande1.Children.Add(Infos);
        }
        /// <summary>
        /// Initialisation des variable et des items .xaml
        /// </summary>
        public void InitAll()
        {
            if (p.Factures != null && p.Factures.Count != 0)
            {
                foreach (Facture f in p.Factures)
                {
                    prixMoyen += f.Prix;
                }
                prixMoyen /= p.Factures.Count;
            }
            Moy.Text = prixMoyen.ToString("0.##")+"€";
            if(p.Commandes != null && p.Commandes.Count != 0)
            {
                int i = 0;
                p.Commandes.ForEach(c =>
                {
                    AddCommandeToList(c, i);
                    i++;
                });
            }

            if(p.Clients != null && p.Clients.Count != 0)
            {
                Client bestClient = null;
                foreach(KeyValuePair<int,Client> val in p.Clients)
                {
                    if(bestClient == null)
                    {
                        bestClient = val.Value;
                    }else if(val.Value.CmlCmd > bestClient.CmlCmd)
                    {
                        bestClient = val.Value;
                    }
                }
                RecordClientNom.Text = bestClient.NomClient;
                RecordClientPrenom.Text = bestClient.PrenomClient;
                RecordClientTel.Text = bestClient.TelClient+"";
                RecordClientCumul.Text = bestClient.CmlCmd+ (bestClient.CmlCmd > 1 ? " commandes" : " commande");
            }

            if (p.Commis != null && p.Commis.Count != 0)
            {

                Commis bestCommis = null;
                foreach (Commis val in p.Commis)
                {
                    GridCommis.Items.Add(val);
                    if (bestCommis == null)
                    {
                        bestCommis = val;
                    }
                    else if (val.CumulTache > bestCommis.CumulTache)
                    {
                        bestCommis = val;
                    }
                }
                RecordCommisNom.Text = bestCommis.NomEmploye;
                RecordCommisPrenom.Text = bestCommis.PrenomEmploye;
                RecordCommisTel.Text = bestCommis.NumEmploye;
                RecordCommisCumul.Text = bestCommis.CumulTache + (bestCommis.CumulTache > 1 ?" commandes": " commande");
            }
            
            if (p.Livreur != null && p.Livreur.Count != 0)
            {
                Livreur bestLivreur = null;
                foreach (Livreur val in p.Livreur)
                {
                    GridLivreur.Items.Add(val);
                    if (bestLivreur == null)
                    {
                        bestLivreur = val;
                    }
                    else if (val.CumulTache > bestLivreur.CumulTache)
                    {
                        bestLivreur = val;
                    }
                }
                RecordLivreurNom.Text = bestLivreur.NomEmploye;
                RecordLivreurPrenom.Text = bestLivreur.PrenomEmploye;
                RecordLivreurTel.Text = bestLivreur.NumEmploye;
                RecordLivreurCumul.Text = bestLivreur.CumulTache + (bestLivreur.CumulTache > 1 ? " livraisons" : " livraison");
            }
            
            
        }
        /// <summary>
        /// Gestion de l'event en cas de selection dans le calendrier
        /// </summary>
        public void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedDatesCollection dates = Calendar.SelectedDates;
            ChangementCommande(dates);
        }
        /// <summary>
        /// Affiche les commandes suivant la plage de date donné
        /// </summary>
        public void ChangementCommande(SelectedDatesCollection dates)
        {
            ListViewCommandes.Items.Clear();
            int countCommande = 0;
            prixMoyPeriode = 0;
            List<Facture> facturePeriode = new List<Facture>();
            foreach (DateTime d in dates)
            {
                List<Commande> commandeToAdd = new List<Commande>();
                commandeToAdd = p.Commandes.FindAll(x => x.Date.Day == d.Day && x.Date.Month == d.Month && x.Date.Year == d.Year);
                if (commandeToAdd != null)
                {
                    int i = 0;
                    foreach (Commande c in commandeToAdd)
                    {
                        AddCommandeToList(c, i);
                        i++;
                        if(c.Etat == Commande.EtatCommande.fermer)
                            countCommande++;
                    }
                }
                List<Facture> facttmp = new List<Facture>();
                facttmp = p.Factures.FindAll(x => {
                    if (x.Details != null)
                    {
                        return x.Details.Date.Day == d.Day && x.Details.Date.Month == d.Month && x.Details.Date.Year == d.Year;
                    }
                    return false;
                });
                if(facttmp != null)
                {
                    facttmp.ForEach(x => facturePeriode.Add(x));
                }
            }

            if(facturePeriode != null)
            {
                foreach(Facture f in facturePeriode)
                {
                    prixMoyPeriode += f.Prix;
                }
            }
            if (countCommande != 0)
            {
                prixMoyPeriode /= countCommande;
            }
            if (prixMoyPeriode == 0)
                MoyPeriode.Text = "Erreur";
            else
                MoyPeriode.Text = prixMoyPeriode.ToString("0.##") + "€";

        }
    }
}
