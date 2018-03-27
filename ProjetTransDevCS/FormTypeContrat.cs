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
    public partial class FormTypeContrat : Form
    {
        public FormTypeContrat()
        {
            InitializeComponent();
        }

        private void FormTypeContrat_Load(object sender, EventArgs e)
        {
            MAJlistBoxTypeContrat();
        }

        private void buttonAjouterTypeContrat_Click(object sender, EventArgs e)
        {
            FormAjouterTypeContrat monFormAjouterTypeContrat = new FormAjouterTypeContrat();
            if(monFormAjouterTypeContrat.ShowDialog() != DialogResult.OK)
            {
                MAJlistBoxTypeContrat();
                buttonSupprimerTypeContrat.Enabled = false;
            }
        }

        private void buttonSupprimerTypeContrat_Click(object sender, EventArgs e)
        {
            if(listBoxTypeContrat.SelectedItem != null)
            {
                ClassTypeContrat monTypeContratSelectionne = (ClassTypeContrat)listBoxTypeContrat.SelectedItem;
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
                    maCommande.CommandText = @" DELETE FROM `typecontrat` 
                                            WHERE IDTypContrat=" + monTypeContratSelectionne.IDTypContrat;

                    // 3- exécution de la requete
                    maCommande.ExecuteNonQuery();

                    MessageBox.Show("Type de contrat supprimé");

                    // 6- fermeture connexion
                    maConnexion.Close();
                }
                catch (Exception erreur)
                {
                    MessageBox.Show(erreur.Message);
                }
                MAJlistBoxTypeContrat();
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un type de contrat");
            }
        }

        private void MAJlistBoxTypeContrat()
        {
            #region mise à jour des employé dans la listBox
            listBoxTypeContrat.Items.Clear();
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
                maCommande.CommandText = @" SELECT * FROM `typecontrat` 
                                            ORDER BY LibelleTypContrat";

                // 3- le reader
                MySqlDataReader monReader = maCommande.ExecuteReader();

                // 4- parcours reader  
                while (monReader.Read())
                {
                    int IDTypContrat = Convert.ToInt32(monReader["IDTypContrat"]);
                    string LibelleTypContrat = monReader["LibelleTypContrat"].ToString();                    

                    ClassTypeContrat monContrat = new ClassTypeContrat(IDTypContrat, LibelleTypContrat);

                    listBoxTypeContrat.Items.Add(monContrat);
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

        private void listBoxTypeContrat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBoxTypeContrat.SelectedItem != null)
            {
                buttonSupprimerTypeContrat.Enabled = true;
            }
        }
    }
}
