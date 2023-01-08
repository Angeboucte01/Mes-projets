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
using System.Data.SqlClient;
using System.Data;


namespace WPF_BD_10
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SqlConnection conBD;
        private bool test = false;

        public MainWindow()
        {
            InitializeComponent();

            //Configuration de la chaine de connexion // Creation d'un objet de type connexion
            conBD = new SqlConnection(@"Data Source=LAPTOP-Q5QGQTQU\SQLEXPRESS08;Initial Catalog=Etudiants;Integrated Security=True");

            //Chargement du ComboBox
            Charger_groupe();

            //Chargement du DataGrid
            Charger_liste_etudiants();
        }

        /// <summary>
        /// Remplir le DataGrid avec les données collectées de la BD
        /// </summary>
        private void Charger_liste_etudiants()
        {
            //Ma requête
            string maRequete = "select * from Etudiant";
            //Ma commande
            SqlCommand cmd = new SqlCommand(maRequete, conBD);

            conBD.Open(); //Ouvrir la connexion

            SqlDataReader dr = cmd.ExecuteReader(); //Lire les enregistrements collectés suite à l'exécution de la requête
            //Stockage des données lus par DataReader dans DataTable
            DataTable dt = new DataTable();
            dt.Load(dr);

            conBD.Close(); //Fermer la connexion

            //Chargement du DataGrid avec les données stockées dans DataTable
            dgListe.ItemsSource = dt.DefaultView;

        }

        /// <summary>
        /// Remplir le comboBox des groupes
        /// </summary>
        private void Charger_groupe()
        {
            //Ma requête
            string maRequete = "select * from Groupes";
            //Ma commande
            SqlCommand cmd = new SqlCommand(maRequete, conBD);

            conBD.Open(); //Ouvrir la connexion

            SqlDataReader dr = cmd.ExecuteReader(); //Lire les enregistrements collectés suite à l'exécution de la requête

            //Chargement du ComboBox avec les données de la BD
            while (dr.Read())
            {
                cbxGroupe.Items.Add(dr[1]);
            }

            conBD.Close(); //Fermer la connexion

        }

        /// <summary>
        /// Manipulation d'un textBox avec un Hint
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTrait_TextChanged(object sender, TextChangedEventArgs e)
        {
            lblHint.Content = "";
        }


        /// <summary>
        /// Ajout d'un enregistrement dans la table Etudiants de la BD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            //Ma requête
            string maRequete = "insert into Etudiant values (@nom, @prenom, @groupe)";

            //Ma commande
            SqlCommand cmd = new SqlCommand(maRequete, conBD);

            cmd.CommandType = CommandType.Text; //Comment exécuter ma requête

            //Récupérer les informations à mettre dans les paramètres
            cmd.Parameters.AddWithValue("@nom", txtNom.Text);
            cmd.Parameters.AddWithValue("@prenom", txtPrenom.Text);
            cmd.Parameters.AddWithValue("@groupe", cbxGroupe.SelectedItem.ToString());

            conBD.Open(); //Ouvrir la connexion
            cmd.ExecuteNonQuery(); //Exécuter la requête
            conBD.Close(); //Fermer la connexion

            //Afficher un message de confirmation
            MessageBox.Show("Ajout fait avec succès!", "Confirmation");

            //Recharger le DataGrid
            Charger_liste_etudiants();

            //Vider les composants
            txtNom.Clear();
            txtPrenom.Clear();
            cbxGroupe.SelectedIndex = -1;
            txtTrait.Clear();
        }

        /// <summary>
        /// Suppression d'un étudiant de la BD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            //Ma requête
            string maRequete = "delete from Etudiant where id_etudiant = " + txtTrait.Text;

            //Ma commande
            SqlCommand cmd = new SqlCommand(maRequete, conBD);

            conBD.Open(); //Ouvrir la connexion
            cmd.ExecuteNonQuery(); //Exécuter la requête
            conBD.Close(); //Fermer la connexion

            //Afficher un message de confirmation
            MessageBox.Show("Suppression faite avec succès!", "Confirmation");

            //Recharger le DataGrid
            Charger_liste_etudiants();

            //Vider les composants
            txtNom.Clear();
            txtPrenom.Clear();
            cbxGroupe.SelectedIndex = -1;
            txtTrait.Clear();

        }

        /// <summary>
        /// Mise à jour des informations d'un étudiant existant dans la BD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            //Ma requête
            string maRequete = "update Etudiant set nom = '" + txtNom.Text + "', prenom = '" + txtPrenom.Text + "', groupe = '" +
                cbxGroupe.SelectedItem.ToString() + "' where id_etudiant = '" + txtTrait.Text + "'";

            //Ma commande
            SqlCommand cmd = new SqlCommand(maRequete, conBD);

            conBD.Open(); //Ouvrir la connexion
            cmd.ExecuteNonQuery(); //Exécuter la requête
            conBD.Close(); //Fermer la connexion

            //Afficher un message de confirmation
            MessageBox.Show("Mise à jour faite avec succès!", "Confirmation");

            //Recharger le DataGrid
            Charger_liste_etudiants();

            //Vider les composants
            txtNom.Clear();
            txtPrenom.Clear();
            cbxGroupe.SelectedIndex = -1;
            txtTrait.Clear();

        }

        /// <summary>
        /// Sélection d'une ligne dans le DataGrid pour l'affciher
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgListe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid monDataGrid = (DataGrid)sender; //Créer mon propre objet de type DataGrid
            
            //Récupération des données de la ligne séléctionnée dans mon Data Grid
            DataRowView ligne_selectionnee = monDataGrid.SelectedItem as DataRowView;

            if (ligne_selectionnee != null)
            {
                txtNom.Text = ligne_selectionnee["nom"].ToString();
                txtPrenom.Text = ligne_selectionnee["prenom"].ToString();
                cbxGroupe.Text = ligne_selectionnee["groupe"].ToString();
                txtTrait.Text = ligne_selectionnee["id_etudiant"].ToString();

            }

        }

        /// <summary>
        /// Affichage des étudiants dans le DataGrid selon le groupe sélectionné dans le ComboBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxGroupe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (cbxGroupe.SelectedIndex != -1)
            {
                //Ma requête
                string maRequete = "select * from Etudiant where groupe =" + cbxGroupe.SelectedItem.ToString();
                //Ma commande
                SqlCommand cmd = new SqlCommand(maRequete, conBD);

                conBD.Open(); //Ouvrir la connexion

                SqlDataReader dr = cmd.ExecuteReader(); //Lire les enregistrements collectés suite à l'exécution de la requête
                                                        //Stockage des données lus par DataReader dans DataTable
                DataTable dt = new DataTable();
                dt.Load(dr);

                conBD.Close(); //Fermer la connexion

                
                dgListe.ItemsSource = dt.DefaultView; //Rechargement de la liste selon le groupe choisi
                

            }
            
        }
    }
}
