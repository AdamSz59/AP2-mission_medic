using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Medicaments
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_conexion_Click(object sender, EventArgs e)
        {
            string user = identifiant.Text;
            string mdpUser = mdp.Text;

            // String de connexion (remplacez les informations par celles de votre propre serveur)
            string connectionString = "Server=172.22.48.38;Database=gsb_praticienCompletee;User Id=admin;Password=admin;";

            try
            {
                // Créer une connexion à la base de données
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    // Ouvrir la connexion
                    connection.Open();

                    //Requête
                    string query = "SELECT id, mdp, code_type_praticien FROM praticien WHERE id = @id";

                    //Récuépération des données utilisateurs
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id",user);

                        // Exécuter la requête et obtenir les résultats dans un DataReader
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            int id = 0;
                            string mdp = "";

                            // Lire les résultats et les afficher
                            while (reader.Read())
                            {
                                id = reader.GetInt32(0);    // Récupère la première colonne (Id)
                                mdp = reader.GetString(1); // Récupère la deuxième colonne (Mdp)
                                StockTemp.codePrati = reader.GetString(2);
                            }

                            if (Convert.ToInt32(user) == id && mdpUser == mdp)
                            {
                                StockTemp.idUtili = id.ToString();
                                form_panier form2 = new form_panier();
                                form2.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Accès refuser ! Les identifiants sont incorrects", "Autorisation refusé", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Si une erreur se produit, afficher un message d'erreur
                MessageBox.Show($"Erreur de connexion : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void identifiant_TextChanged(object sender, EventArgs e)
        {

        }
    }
}