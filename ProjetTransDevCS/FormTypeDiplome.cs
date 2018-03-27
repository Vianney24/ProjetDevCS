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
    public partial class FormTypeDiplome : Form
    {
        public FormTypeDiplome()
        {
            InitializeComponent();
        }

        private void FormTypeDiplome_Load(object sender, EventArgs e)
        {
            MAJlistBoxTypeDiplome();
        }

        private void MAJlistBoxTypeDiplome()
        {
            #region mise à jour des types de diplome dans la listBox
            listBoxTypeDiplome.Items.Clear();
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
                maCommande.CommandText = @" SELECT * FROM `typediplome`
                                            ORDER BY LibelleTypDiplome";

                // 3- le reader
                MySqlDataReader monReader = maCommande.ExecuteReader();

                // 4- parcours reader  
                while (monReader.Read())
                {
                    int IDTypDiplome = Convert.ToInt32(monReader["IDTypDiplome"]);
                    string LibelleTypDiplome = monReader["LibelleTypDiplome"].ToString();

                    ClassTypeDiplome monTypeDiplome = new ClassTypeDiplome(IDTypDiplome, LibelleTypDiplome);

                    listBoxTypeDiplome.Items.Add(monTypeDiplome);
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

        private void buttonAjouterTypeDiplome_Click(object sender, EventArgs e)
        {
            FormAjouterTypeDiplome monFormAjouterTypeDiplome = new FormAjouterTypeDiplome();
            if(monFormAjouterTypeDiplome.ShowDialog() != DialogResult)
            {
                MAJlistBoxTypeDiplome();
                buttonSupprimerTypeDiplome.Enabled = false;
            }
        }

        private void listBoxTypeDiplome_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxTypeDiplome.SelectedItem != null)
            {
                buttonSupprimerTypeDiplome.Enabled = true;
            }
        }

        private void buttonSupprimerTypeDiplome_Click(object sender, EventArgs e)
        {
            if (listBoxTypeDiplome.SelectedItem != null)
            {
                ClassTypeDiplome monTypeDiplomeSelectionne = (ClassTypeDiplome)listBoxTypeDiplome.SelectedItem;
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
                    maCommande.CommandText = @" DELETE FROM `typediplome`
                                        WHERE IDTypDiplome=" + monTypeDiplomeSelectionne.IDTypDiplome;

                    // 3- exécution de la requete
                    maCommande.ExecuteNonQuery();

                    MessageBox.Show("Type de Diplome supprimé");
                    MAJlistBoxTypeDiplome();

                    // 6- fermeture connexion
                    maConnexion.Close();
                }
                catch (Exception erreur)
                {
                    MessageBox.Show(erreur.Message);
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un type de Diplome");
            }            
        }
    }
}
