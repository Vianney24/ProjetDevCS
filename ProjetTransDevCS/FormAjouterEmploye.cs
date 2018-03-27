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
    public partial class FormAjouterEmploye : Form
    {
        public int IDEmploye;
        public int IDContrat;
        public string DateDeNaissance;
        public string DateContrat;

        public FormAjouterEmploye()
        {
            InitializeComponent();

            #region Récupération et initialisation de l'id de l'employé
                int dernierIdEmploye = GetLastIdFromTable("employe", "IDEmploye");
                IDEmploye = dernierIdEmploye + 1;
            #endregion

            #region récupération et intialisation de l'id du contrat
                int dernierIdContrat = GetLastIdFromTable("contrat", "IDContrat");
                IDContrat = dernierIdContrat + 1;
            #endregion            

            #region grisement des boutons du groupbox diplome
            buttonModifierDiplome.Enabled = false;
                buttonSupprimerDiplome.Enabled = false;
            #endregion

            dateTimePickerDateNaissanceEmploye.Format = DateTimePickerFormat.Custom;
            dateTimePickerDateNaissanceEmploye.CustomFormat = "yyyy-MM-dd";
            dateTimePickerContratEmploye.Format = DateTimePickerFormat.Custom;
            dateTimePickerContratEmploye.CustomFormat = "yyyy-MM-dd";

        }

        private void FormAjouterEmploye_Load(object sender, EventArgs e)
        {
            #region mise à jour des services dans la comboBox                
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
                                                FROM service
                                                ORDER BY LibelleService";

                    // 3- le reader
                    MySqlDataReader monReader = maCommande.ExecuteReader();

                    // 4- parcours reader  
                    comboBoxServiceEmploye.Items.Clear();
                    while (monReader.Read())
                    {
                        int IDService = Convert.ToInt32(monReader["IDService"]);
                        string LibelleService = monReader["LibelleService"].ToString();

                        ClassService monService = new ClassService(IDService, LibelleService);

                        comboBoxServiceEmploye.Items.Add(monService);
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

            #region mise à jour des types des contrat dans la comboBox
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
                                                FROM typecontrat
                                                ORDER BY LibelleTypContrat";

                    // 3- le reader
                    MySqlDataReader monReader = maCommande.ExecuteReader();

                    // 4- parcours reader  
                    comboBoxTypeContrat.Items.Clear();
                    while (monReader.Read())
                    {
                        int IDTypContrat = Convert.ToInt32(monReader["IDTypContrat"]);
                        string LibelleTypContrat = monReader["LibelleTypContrat"].ToString();

                        ClassTypeContrat monTypeContrat = new ClassTypeContrat(IDTypContrat, LibelleTypContrat);

                        comboBoxTypeContrat.Items.Add(monTypeContrat);
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

        #region boutons annuler et ajouter
            private void buttonAnnuler_Click(object sender, EventArgs e)
            {
                for(int i = 0; i < listBoxDiplome.Items.Count; i++)
                {
                    listBoxDiplome.SelectedIndex = i;
                    ClassDiplome monDiplomeSelectionne = (ClassDiplome)listBoxDiplome.SelectedItem;
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
                        maCommande.CommandText = @" DELETE FROM `diplome` 
                                                    WHERE IDDiplome=" + monDiplomeSelectionne.IDDiplome;

                        // 3- exécution de la requete
                        maCommande.ExecuteNonQuery();

                        // 4- fermeture connexion
                        maConnexion.Close();
                    }
                    catch (Exception erreur)
                    {
                        MessageBox.Show(erreur.Message);
                    }
                }               

                Close();
            }

            private void buttonAjouterEmploye_Click(object sender, EventArgs e)
            {
                #region création de la date de naisance de l'employé pour la requete
                    DateTime monDateTime = this.dateTimePickerDateNaissanceEmploye.Value;
                    string annee = monDateTime.Year.ToString();
                    string mois = monDateTime.Month.ToString();
                    string jour = monDateTime.Day.ToString();
                    DateDeNaissance = annee + "-" + mois + "-" + jour;
                #endregion

                #region création de la date de contrat de l'employé pour la requete
                    DateTime monDateTimeContrat = this.dateTimePickerContratEmploye.Value;
                    string anneeContrat = monDateTimeContrat.Year.ToString();
                    string moisContrat = monDateTimeContrat.Month.ToString();
                    string jourContrat = monDateTimeContrat.Day.ToString();
                    DateContrat = anneeContrat + "-" + moisContrat + "-" + jourContrat;
                #endregion

                if (textBoxNomEmploye.Text != "" && textBoxPrenomEmploye.Text != "" && textBoxAdresseL1Employe.Text != "" && textBoxCodePostalEmploye.Text != "" && textBoxVilleEmploye.Text != "" && textBoxTelephoneEmploye.Text != "" && textBoxSalaireContrat.Text != "")
                {
                    #region ajout de l'employé
                    ClassService monServiceSelectionne = (ClassService)comboBoxServiceEmploye.SelectedItem;
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
                        maCommande.CommandText = @"INSERT 
                                                INTO `employe`(`IDEmploye`, `NomEmploye`, `PrenomEmploye`, `DateNaissanceEmploye`, `AdresseL1Employe`, `AdresseL2Employe`, `CPEmploye`, `VilleEmploye`, `TelephoneEmploye`, `IDContrat`, `IDService`) 
                                                VALUES (
                                                    '" + IDEmploye + "'," +
                                                    "'" + textBoxNomEmploye.Text.ToUpper() + "'," +
                                                    "'" + textBoxPrenomEmploye.Text.ToLower() + "'," +
                                                    "'" + DateDeNaissance + "'," +
                                                    "'" + textBoxAdresseL1Employe.Text + "'," +
                                                    "'" + textBoxAdresseL2Employe.Text + "'," +
                                                    "'" + textBoxCodePostalEmploye.Text + "'," +
                                                    "'" + textBoxVilleEmploye.Text + "'," +
                                                    "'" + textBoxTelephoneEmploye.Text + "'," +
                                                    "'" + IDContrat + "'," +
                                                    "'" + monServiceSelectionne.IDService + "'" +
                                                ")";

                        // 3- Exécution de la requète
                        maCommande.ExecuteNonQuery();


                        // 4- fermeture connexion
                        maConnexion.Close();
                    }
                    catch (Exception erreur)
                    {
                        MessageBox.Show(erreur.Message);
                    }
                    #endregion

                    #region ajout du contrat
                    ClassTypeContrat monTypeContratSelectionne = (ClassTypeContrat)comboBoxTypeContrat.SelectedItem;
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
                        maCommande.CommandText = @"INSERT INTO `contrat`(`IDContrat`, `DateEmbaucheContrat`, `SalaireContrat`, `NumeroContrat`, `IDTypContrat`) 
                                                           VALUES ('" + IDContrat + "','" + DateContrat + "','" + textBoxSalaireContrat.Text + "','" + IDContrat + "','" + monTypeContratSelectionne.IDTypContrat + "')";

                        // 3- Exécution de la requète
                        maCommande.ExecuteNonQuery();


                        // 4- fermeture connexion
                        maConnexion.Close();
                    }
                    catch (Exception erreur)
                    {
                        MessageBox.Show(erreur.Message);
                    }
                #endregion

                    Close();
                }   
                else
                {
                    MessageBox.Show("Veuillez remplir tous les champs");
                }
            }
        #endregion

        #region groupBox diplome
            private void buttonAjouterDiplome_Click(object sender, EventArgs e)
            {
                FormAjouterDiplome monFormAjouterDiplome = new FormAjouterDiplome(IDEmploye);
                if(monFormAjouterDiplome.ShowDialog() != DialogResult.OK)
                {
                    GetListBoxDiplome();
                }
            }

            private void buttonModifierDiplome_Click(object sender, EventArgs e)
            {
                ClassDiplome monDiplomeSelectionne = (ClassDiplome)listBoxDiplome.SelectedItem;

                FormModifierDiplome monFormModifierDiplome = new FormModifierDiplome(monDiplomeSelectionne);
                if (monFormModifierDiplome.ShowDialog() != DialogResult.OK)
                {
                    GetListBoxDiplome();
                }
            }

            private void buttonSupprimerDiplome_Click(object sender, EventArgs e)
            {
                if(listBoxDiplome.SelectedItem != null)
                {
                    ClassDiplome monDiplomeSelectionne = (ClassDiplome)listBoxDiplome.SelectedItem;
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
                        maCommande.CommandText = @" DELETE FROM `diplome` 
                                                    WHERE IDDiplome=" + monDiplomeSelectionne.IDDiplome;

                        // 3- exécution de la commande
                        maCommande.ExecuteNonQuery();

                        // 4- fermeture connexion
                        maConnexion.Close();
                    }
                    catch (Exception erreur)
                    {
                        MessageBox.Show(erreur.Message);
                    }

                    GetListBoxDiplome();
                }
                else
                {
                    MessageBox.Show("Veuillez selectionner un diplôme");
                }   
            }

            private void listBoxDiplome_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (listBoxDiplome.SelectedItem != null)
                {
                    buttonModifierDiplome.Enabled = true;
                    buttonSupprimerDiplome.Enabled = true;
                }
            }
        #endregion

        #region fonctions
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

            private void GetListBoxDiplome()
            {
                listBoxDiplome.Items.Clear();
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
                    maCommande.CommandText = @" SELECT * 
                                                FROM diplome, typediplome 
                                                WHERE diplome.IDTypDiplome=typediplome.IDTypDiplome
                                                AND diplome.IDEmploye='" + IDEmploye + "' ORDER BY DateDiplome";

                    // 3- le reader
                    MySqlDataReader monReader = maCommande.ExecuteReader();

                    // 4- parcours reader
                    while (monReader.Read())
                    {
                        int IDDiplome = Convert.ToInt32(monReader["IDTypDiplome"]);
                        string DateDiplome = monReader["DateDiplome"].ToString();
                        string NomEtablissementDiplome = monReader["NomEtablissementDiplome"].ToString();
                        string CPEtablissementDiplome = monReader["CPEtablissementDiplome"].ToString();
                        string VilleEtablissementDiplome = monReader["VilleEtablissementDiplome"].ToString();
                        int IDEmploye = Convert.ToInt32(monReader["IDEmploye"]);
                        int IDTypDiplome = Convert.ToInt32(monReader["IDTypDiplome"]);
                        string LibelleTypDiplome = monReader["LibelleTypDiplome"].ToString();

                        ClassTypeDiplome monTypeDiplome = new ClassTypeDiplome(IDTypDiplome, LibelleTypDiplome);
                        ClassDiplome monClassDiplome = new ClassDiplome(IDDiplome, DateDiplome, NomEtablissementDiplome, CPEtablissementDiplome, VilleEtablissementDiplome, IDEmploye, monTypeDiplome);
                    
                        listBoxDiplome.Items.Add(monClassDiplome);
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
            }
        #endregion

        private void FormAjouterEmploye_FormClosed(object sender, FormClosedEventArgs e)
        {
            for (int i = 0; i < listBoxDiplome.Items.Count; i++)
            {
                listBoxDiplome.SelectedIndex = i;
                ClassDiplome monDiplomeSelectionne = (ClassDiplome)listBoxDiplome.SelectedItem;
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
                    maCommande.CommandText = @" DELETE FROM `diplome` 
                                                    WHERE IDDiplome=" + monDiplomeSelectionne.IDDiplome;

                    // 3- exécution de la requete
                    maCommande.ExecuteNonQuery();

                    // 4- fermeture connexion
                    maConnexion.Close();
                }
                catch (Exception erreur)
                {
                    MessageBox.Show(erreur.Message);
                }
            }
        }
    }
}
