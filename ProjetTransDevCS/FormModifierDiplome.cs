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
    public partial class FormModifierDiplome : Form
    {
        public ClassDiplome monDiplome;
        public string DateObtentionDiplome;

        public FormModifierDiplome(ClassDiplome monDiplomeSelectionne)
        {
            InitializeComponent();
            this.monDiplome = monDiplomeSelectionne;

            #region création de la date du diplome pour la requete
                DateTime monDateTime = this.dateTimePickerDiplome.Value;
                string annee = monDateTime.Year.ToString();
                string mois = monDateTime.Month.ToString();
                string jour = monDateTime.Day.ToString();
                DateObtentionDiplome = annee + "-" + mois + "-" + jour;
            #endregion

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
                        string LibelleTypDiplome = monReader["LibelleTypDiplome"].ToString();

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

        private void FormModifierDiplome_Load(object sender, EventArgs e)
        {
            dateTimePickerDiplome.Value = Convert.ToDateTime(this.monDiplome.DateDiplome);
            comboBoxTypeDiplome.SelectedItem = this.monDiplome.TypeDiplome;
            textBoxNomEtablissementDiplome.Text = this.monDiplome.NomEtablissementDiplome;
            textBoxCPEtablissement.Text = this.monDiplome.CPEtablissementDiplome;
            textBoxVilleEtablissement.Text = this.monDiplome.VilleEtablissementDiplome;
        }

        #region boutons annuler et modifier
            private void buttonAnnuler_Click(object sender, EventArgs e)
            {
                Close();
            }

            private void buttonModifier_Click(object sender, EventArgs e)
            {
                if (textBoxNomEtablissementDiplome.Text != "" && textBoxCPEtablissement.Text != "" && textBoxVilleEtablissement.Text != "")
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
                        maCommande.CommandText = @" UPDATE `diplome` 
                                                        SET 
                                                            `IDDiplome`='" + this.monDiplome.IDDiplome + "'," +
                                                        "`DateDiplome`='" + DateObtentionDiplome + "'," +
                                                        "`NomEtablissementDiplome`='" + textBoxNomEtablissementDiplome.Text + "'," +
                                                        "`CPEtablissementDiplome`='" + textBoxCPEtablissement.Text + "'," +
                                                        "`VilleEtablissementDiplome`='" + textBoxVilleEtablissement.Text + "'," +
                                                        "`IDEmploye`='" + this.monDiplome.IDEmploye + "'," +
                                                        "`IDTypDiplome`='" + monTypeDiplome + "' " +
                                                    "WHERE IDDiplome=" + this.monDiplome.IDDiplome;

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
                else
                {
                    MessageBox.Show("Veuillez remplir tout les champs");
                }
            }
        #endregion


    }
}
