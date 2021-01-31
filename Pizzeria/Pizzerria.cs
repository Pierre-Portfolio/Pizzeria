using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace Pizzeria
{
    /// Pour un soucis de conflit classe / namespace. La classe Pizzeria s'écrit avec 2 r
    public class Pizzerria
    {
        private string nom;
        private string adresse;
        private Dictionary<int,Client> clients;
        private List<Commis> commis;
        private List<Livreur> livreur;
        private List<Commande> commandes;
        private List<Facture> factures;

        private Personel currentUser;
        public Pizzerria(string nom, string adresse)
        {
            this.nom = nom;
            this.adresse = adresse;
            this.clients = ChargerCSVClient();
            this.commis = ChargerCSVCommis();
            this.livreur = ChargerCSVLivreur();
            this.commandes = ChargerCSVCommande();
            this.factures = ChargerCSVFacture();
            this.currentUser = null;
        }
        #region Propietes
        public string Nom
        {
            get { return nom; }
        }
        public string Adresse
        {
            get { return adresse; }
        }
        public Dictionary<int,Client> Clients
        {
            get { return clients; }
        }
        public List<Commis> Commis
        {
            get { return commis; }
        }
        public List<Livreur> Livreur
        {
            get { return livreur; }
        }
        public List<Commande> Commandes
        {
            get { return commandes; }
        }

        public List<Facture> Factures
        {
            get { return this.factures; }
        }

        public Personel CurrentUser
        {
            get { return this.currentUser; }
            set { this.currentUser = value; }
        }
        #endregion
        public void ModifCumule()
        {
            this.currentUser.CumulTache++;
        }

        /// <summary>
        /// Les fonctions de la region suivante permettent toute de charger un fichier csv.
        /// </summary>
        /// <returns>List<T></returns>
        #region Fonctions pour charger les CSV
        public Dictionary<int,Client> ChargerCSVClient()
        {
            string path = "..\\..\\..\\Clients.csv";
            Dictionary<int,Client> c1 = new Dictionary<int, Client>();
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
                        if(!c1.ContainsKey(int.Parse(tem[4])))
                            c1.Add(int.Parse(tem[4]),new Client(Convert.ToInt32(tem[0]), tem[1], tem[2], tem[3], int.Parse(tem[4]), new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0])), int.Parse(tem[6])));
                    }
                }
                lecteur.Close();
            }
            return c1;
        }

        public List<Commis> ChargerCSVCommis()
        {
            string path = "..\\..\\..\\Commis.csv";
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
                        Commis.etat_commis en = Enum.Parse<Commis.etat_commis>(tem[5]);
                        c1.Add(new Commis(tem[0], tem[1], tem[3], tem[2],tem[4], en, Convert.ToDateTime(tem[6]), Int32.Parse(tem[7])));
                    }
                }
                lecteur.Close();
            }
            return c1;
        }

        public List<Livreur> ChargerCSVLivreur()
        {
            string path = "..\\..\\..\\Livreur.csv";
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
                        Livreur.etat_livreur en = Enum.Parse<Livreur.etat_livreur>(tem[5]);
                        c1.Add(new Livreur(tem[0], tem[1], tem[3],tem[2], tem[4], en, Enum.Parse<Livreur.moyen_Livraison>(tem[6]),Int32.Parse(tem[7])));
                    }
                }
                lecteur.Close();
            }
            return c1;
        }

        private List<Commande> ChargerCSVCommande()
        {
            string path = "..\\..\\..\\Commandes.csv";
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

                        Livreur l = null; 
                        l = Livreur.Find(x => x.NumEmploye.Equals(tem[7]));

                        List<Pizza> p = new List<Pizza>();
                        string[] pizzas = tem[8].Split('/');
                        foreach (string s in pizzas)
                        {
                            string[] elem = s.Split(',');
                            List<Pizza.Garniture> pg = new List<Pizza.Garniture>();
                            for (int i = 1; i < elem.Length; i++)
                            {
                                Pizza.Garniture e = Enum.Parse<Pizza.Garniture>(elem[i]);
                                pg.Add(e);
                            }
                            Pizza piz = new Pizza(pg, Enum.Parse<Pizza.TaillePizza>(elem[0]));
                            p.Add(piz);
                        }
                        List<Boisson> b = new List<Boisson>();
                        string[] boisson = tem[9].Split('/');
                        foreach (string s in boisson)
                        {
                            string[] elem = s.Split('-');
                            if (elem != null && elem.Length == 2)
                            {
                                b.Add(new Boisson(elem[0], double.Parse(elem[1])));
                            }
                        }
                        c1.Add(new Commande(int.Parse(tem[0]), tem[1], newDate, int.Parse(tem[3]), tem[4], tem[5], en,l, p, b));
                    }
                }
                lecteur.Close();
            }
            return c1;
        }
        
        private List<Facture> ChargerCSVFacture()
        {
            string path = "..\\..\\..\\Factures.csv";
            List<Facture> c1 = new List<Facture>();
            if (File.Exists(path))
            {
                StreamReader reader = new StreamReader(path);
                string line = "";
                while(reader.Peek() > 0)
                {
                    line = reader.ReadLine();
                    if(line != null)
                    {
                        string[] tem = line.Split(';');
                        Commande c = Commandes.Find(x => x.NumCommande == Int32.Parse(tem[1]));
                        Facture f = new Facture(Int32.Parse(tem[0]),c,Double.Parse(tem[2]));
                        c1.Add(f);
                    }
                }
            }
            return c1;
        }
        #endregion

        /// <summary>
        /// Les fonctions de la region suivante permettent toute de modifier un fichier csv.
        /// </summary>
        #region AddToCsv
        public void AjouterClientFinCSV(Client c)
        {
            string path = "..\\..\\..\\Clients.csv";
            string line = c.NumClient + ";" + c.NomClient + ";" + c.PrenomClient + ";" + c.AdrClient + ";" + c.TelClient + ";" + c.DatePremiereCmd.Day + "/" + c.DatePremiereCmd.Month + "/" + c.DatePremiereCmd.Year + ";" + c.CmlCmd;
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
        }
        public void AjouterCommisFinCSV(Commis c)
        {
            string path = "..\\..\\..\\Commis.csv";
            string line = c.GetLineForCSV();
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
        }
        public void AjouterLivreurFinCSV(Livreur l)
        {
            string path = "..\\..\\..\\Livreur.csv";
            string line = l.GetLineForCSV();
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
        }
        public void ReWriteCsvClient()
        {
            string path = "..\\..\\..\\Clients.csv";
            if (Clients != null && Clients.Count != 0)
            {
                StreamWriter wr = new StreamWriter(path);
                string line = "";
                int i = 0;
                foreach (KeyValuePair<int, Client> val in Clients)
                {
                    i++;
                    line += val.Value.GetLineForCSV();
                    if (i != Clients.Count)
                        line += "\n";
                }
                wr.WriteLine(line);
                wr.Close();
            }
        }

        public void ReWriteCsvCommis()
        {
            string path = "..\\..\\..\\Commis.csv";
            if (Commis != null && Commis.Count != 0)
            {
                StreamWriter wr = new StreamWriter(path);
                string line = "";
                int i = 0;
                foreach (Commis c in Commis)
                {
                    i++;
                    line += c.GetLineForCSV();
                    if (i != Commis.Count)
                        line += "\n";
                }
                wr.Write(line);
                wr.Close();
            }
        }

        public void ReWriteCsvLivreur()
        {
            string path = "..\\..\\..\\Livreur.csv";
            if (Livreur != null && Livreur.Count != 0)
            {
                StreamWriter wr = new StreamWriter(path);
                string line = "";
                int i = 0;
                foreach (Livreur l in Livreur)
                {
                    i++;
                    line += l.GetLineForCSV();
                    if (i != Livreur.Count)
                        line += "\n";
                }
                wr.Write(line);
                wr.Close();
            }
        }
        
        public void ReWriteCsvCommande()
        {
            string path = "..\\..\\..\\Commandes.csv";
            if (Commandes != null && Commandes.Count != 0)
            {
                StreamWriter wr = new StreamWriter(path);
                string line = "";
                int i = 0;
                foreach (Commande c in Commandes)
                {
                    i++;
                    line += c.GetLineForCSV();
                    if (i != Commandes.Count)
                        line += "\n";
                }
                wr.Write(line);
                wr.Close();
            }
        }
        
        public void ReWriteCsvFacture()
        {
            string path = "..\\..\\..\\Factures.csv";
            if (factures != null && factures.Count != 0)
            {
                StreamWriter wr = new StreamWriter(path);
                string line = "";
                int i = 0;
                foreach (Facture f in factures)
                {
                    i++;
                    line += f.GetLineForCSV();
                    if (i != factures.Count)
                        line += "\n";
                }
                wr.Write(line);
                wr.Close();
            }
        }
        #endregion

        #region Refresh
        /// <summary>
        /// Recharger les liste de la classe Pizzerria
        /// </summary>
        public void Refresh()
        {
            this.clients = new Dictionary<int, Client>();
            this.commis = new List<Commis>();
            this.livreur = new List<Livreur>();
            this.commandes = new List<Commande>();
            
            this.clients = ChargerCSVClient();
            this.commis = ChargerCSVCommis();
            this.livreur = ChargerCSVLivreur();
            this.commandes = ChargerCSVCommande();
        }
        #endregion
    }
}
