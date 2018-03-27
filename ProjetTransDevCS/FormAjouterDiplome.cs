using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProjetTransDevCS
{
    public partial class FormAjouterDiplome : Form
    {
        public int IDEmploye;
        public int IDDiplome;
        public string DateObtention;

        public FormAjouterDiplome(int idEmploye)
        {
            InitializeComponent();

            // Récupération de l'id de l'employé
            this.IDEmploye = idEmploye;

            // initialisation de l'id du diplome
            int dernierIDDiplome = GetLastIdFromTable("diplome","IDDiplome");
            IDDiplome = dernierIDDiplome + 1;

            // création de la date du diplome pour la requete
            DateTime monDateTime = this.dateTimePickerDiplome.Value;
            string annee = monDateTime.Year.ToString();
            string mois = monDateTime.Month.ToString();
            string jour = monDateTime.Day.ToString();

            DateObtention = annee + "-" + mois + "-" + jour;

            #region Mise à jour des types de diplomes dans la comboBox
                comboBoxTypeDiplome.Items.Clear();
                try
                {
                    string chaineConnexion = ProjetTransDevCS.Properties.Settings.Default.chaineConnexion;

                    // 1- connexion
                    MySqlConnection maConnexion = new MySqlConnection(chaineConnexion);
                    maConnexion.Open();
                    if (maConnexion.State != ConnectionState.Open)
                        throw new Exception("erreur connexion");

                    // 2- la commande
                    MySqlCommand maCommande = new MySqlCommand();
                    maCommande.Connection = maConnexion;
                    maCommande.CommandType = CommandType.Text;
                    maCommande.CommandText = @" SELECT  * 
                                                    FROM typediplome
                                                    ORDER BY LibelleTypDiplome";

                    // 3- le reader
                    MySqlDataReader monReader = maCommande.ExecuteReader();

                    // 4- parcours reader
                    while (monReader.Read())
                    {
                        int IDTypDiplome = Convert.ToInt32(monReader["IDTypDiplome"]);
                        string LibelleTypDiplome= monReader["LibelleTypDiplome"].ToString();

                        ClassTypeDiplome monTypeDiplome = new ClassTypeDiplome(IDTypDiplome, LibelleTypDiplome);

                        comboBoxTypeDiplome.Items.Add(monTypeDiplome);
                    }

                    // 5- fermeture reader
                    monReader.Close();

                    // 6- fermeture connexion
                    maConnexion.Close();
                }
                catch (Exception erreur)
                {
                    MessageBox.Show(erreur.Message);
                }
            #endregion
        }

        private void FormAjouterDiplome_Load(object sender, EventArgs e)
        {

        }

        #region boutons ajouter et annuler        
            private void buttonAnnuler_Click(object sender, EventArgs e)
            {
                Close();
            }

            private void buttonAjouter_Click(object sender, EventArgs e)
            {
                if(textBoxNomEtablissementDiplome.Text != "" && textBoxCPEtablissement.Text != "" && textBoxVilleEtablissement.Text != "")
                {
                    ClassTypeDiplome monTypeDiplome = (ClassTypeDiplome)comboBoxTypeDiplome.SelectedItem;
                    try
                    {
                        string chaineConnexion = ProjetTransDevCS.Properties.Settings.Default.chaineConnexion;

                        // 1- connexion
                        MySqlConnection maConnexion = new MySqlConnection(chaineConnexion);
                        maConnexion.Open();
                        if (maConnexion.State != ConnectionState.Open)
                            throw new Exception("erreur connexion");

                        // 2- la commande
                        MySqlCommand maCommande = new MySqlCommand();
                        maCommande.Connection = maConnexion;
                        maCommande.CommandType = CommandType.Text;
                        maCommande.CommandText = @" INSERT 
                                                    INTO `diplome`(`IDDiplome`, `DateDiplome`, `NomEtablissementDiplome`, `CPEtablissementDiplome`, `VilleEtablissementDiplome`, `IDEmploye`, `IDTypDiplome`) 
                                                    VALUES (
                                                        '" + IDDiplome + "'," +
                                                        "'" + DateObtention + "'," +
                                                        "'" + textBoxNomEtablissementDiplome.Text + "'," +
                                                        "'" + textBoxCPEtablissement.Text + "'," +
                                                        "'" + textBoxVilleEtablissement.Text + "'," +
                                                        "'" + this.IDEmploye + "'," +
                                                        "'" + monTypeDiplome.IDTypDiplome + "')";

                        maCommande.ExecuteNonQuery();

                        // 6- fermeture connexion
                        maConnexion.Close();

                        Close();
                    }
                    catch (Exception erreur)
                    {
                        MessageBox.Show(erreur.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Veuillez remplir tout les champs");
                }
            }
        #endregion

        private int GetLastIdFromTable(string NomTable, string NomColonne)
        {
            string chaineConnexion = ProjetTransDevCS.Properties.Settings.Default.chaineConnexion;

            // 1- connexion
            MySqlConnection maConnexion = new MySqlConnection(chaineConnexion);
            maConnexion.Open();
            if (maConnexion.State != ConnectionState.Open)
                throw new Exception("erreur de connexion");

            // mise en place de la commande
            MySqlCommand maCommande = new MySqlCommand();
            maCommande.Connection = maConnexion;
            maCommande.CommandType = CommandType.Text;
            maCommande.CommandText = @"SELECT MAX(" + NomColonne + ") AS max FROM " + NomTable;


            // 3: Exécution de la commande DataReader
            MySqlDataReader monDataReader = maCommande.ExecuteReader();

            // 4: Parcours du DataReader
            monDataReader.Read();

            // Exploitation de la ligne lue
            if (monDataReader["max"] is DBNull)
            {
                int id = 0;
                return id;
            }
            else
            {
                int id = Convert.ToInt32(monDataReader["max"]);
                return id;
            }

            // fermeture de la connexion
            monDataReader.Close();
            maConnexion.Close();
        }
    }
}
