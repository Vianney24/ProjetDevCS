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
    public partial class FormAjouterTypeDiplome : Form
    {
        public int IDTypeDiplome;

        public FormAjouterTypeDiplome()
        {
            InitializeComponent();
            int dernierIdTypeDiplome = GetLastIdFromTable("typediplome", "IDTypDiplome");
            IDTypeDiplome = dernierIdTypeDiplome + 1;
        }

        private void FormAjouterTypeDiplome_Load(object sender, EventArgs e)
        {

        }

        private void buttonAjouterTypeDiplome_Click(object sender, EventArgs e)
        {
            if(textBoxNomTypeDiplome.Text != "")
            {
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
                    maCommande.CommandText = @" INSERT INTO `typediplome`(`IDTypDiplome`, `LibelleTypDiplome`) 
                                            VALUES ('" + IDTypeDiplome + "','" + textBoxNomTypeDiplome.Text + "')";

                    // 3- exécution de la requete
                    maCommande.ExecuteNonQuery();

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
                MessageBox.Show("Veuillez remplir tous les champs");
            }
        }

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
