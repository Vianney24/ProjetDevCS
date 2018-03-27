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
    public partial class FormAccueil : Form
    {
        public FormAccueil()
        {
            InitializeComponent();
            buttonModifierEmploye.Enabled = false;
            buttonSupprimerEmploye.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MAJlistBoxEmploye();
        }

        #region boutons ajouter, modifier et supprimer
        private void buttonAjouterEmploye_Click(object sender, EventArgs e)
        {
            FormAjouterEmploye monFormAjouterEmploye = new FormAjouterEmploye();
            if(monFormAjouterEmploye.ShowDialog() != DialogResult.OK)
            {
                MAJlistBoxEmploye();
            }
        }

        private void buttonModifierEmploye_Click(object sender, EventArgs e)
        {

        }

        private void buttonSupprimerEmploye_Click(object sender, EventArgs e)
        {
            ClassEmploye monEmployeSelectionne = (ClassEmploye)listBoxEmploye.SelectedItem;
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
                maCommande.CommandText = @" DELETE FROM `employe` 
                                            WHERE IDEmploye=" + monEmployeSelectionne.IDEmploye;

                // 3- exécution de la requete
                maCommande.ExecuteNonQuery();

                // 6- fermeture connexion
                maConnexion.Close();
            }
            catch (Exception erreur)
            {
                MessageBox.Show(erreur.Message);
            }
            MAJlistBoxEmploye();
        }
        #endregion 

        private void MAJlistBoxEmploye()
        {
            #region mise à jour des employé dans la listBox
            listBoxEmploye.Items.Clear();
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
                                                FROM Employe 
                                                ORDER BY NomEmploye";

                // 3- le reader
                MySqlDataReader monReader = maCommande.ExecuteReader();

                // 4- parcours reader  
                while (monReader.Read())
                {
                    int IDEmploye = Convert.ToInt32(monReader["IDEmploye"]);
                    string NomEmploye = monReader["NomEmploye"].ToString();
                    string PrenomEmploye = monReader["PrenomEmploye"].ToString();
                    DateTime DateNaissanceEmploye = Convert.ToDateTime(monReader["DateNaissanceEmploye"]);
                    string AdresseL1Employe = monReader["AdresseL1Employe"].ToString();
                    string AdresseL2Employe = monReader["AdresseL2Employe"].ToString();
                    string CPEmploye = monReader["CPEmploye"].ToString();
                    string VilleEmploye = monReader["VilleEmploye"].ToString();
                    string TelephoneEmploye = monReader["TelephoneEmploye"].ToString();
                    int IDContrat = Convert.ToInt32(monReader["IDContrat"]);
                    int IDService = Convert.ToInt32(monReader["IDService"]);

                    ClassEmploye monEmploye = new ClassEmploye(IDEmploye, NomEmploye, PrenomEmploye, DateNaissanceEmploye, AdresseL1Employe, AdresseL2Employe, CPEmploye, VilleEmploye, TelephoneEmploye, IDContrat, IDService);

                    listBoxEmploye.Items.Add(monEmploye);
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

        private void listBoxEmploye_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBoxEmploye.SelectedItem != null)
            {
                buttonModifierEmploye.Enabled = true;
                buttonSupprimerEmploye.Enabled = true;
            }
        }

        private void buttonAjouterTypeDiplome_Click(object sender, EventArgs e)
        {
            FormTypeDiplome monFormTypeDiplome = new FormTypeDiplome();
            monFormTypeDiplome.ShowDialog();
        }

        private void buttonAjouterTypeContrat_Click(object sender, EventArgs e)
        {
            FormTypeContrat monFormTypeContrat = new FormTypeContrat();
            monFormTypeContrat.ShowDialog();
        }        
    }
}
