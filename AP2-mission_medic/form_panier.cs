using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;

namespace Medicaments
{
    public partial class form_panier : Form
    {
        public Panier panier { get; set; }
        public form_panier()
        {
            InitializeComponent();
            this.panier = new Panier();
            idUtilisateur.Text = "Connecté en tant que : " + StockTemp.idUtili;
            string connectionString = "Server=172.22.48.38;Database=gsb_praticienCompletee;User Id=admin;Password=admin;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // Ouvrir la connexion
                connection.Open();

                //Requête
                string query = "SELECT medicament.id, medicament.designation, medicament.marque, medicament.concentration, medicament.type, medicament.Prix FROM medicament LIMIT 30";

                //Récuépération des données utilisateurs
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {

                    // Exécuter la requête et obtenir les résultats dans un DataReader
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int idMed = reader.GetInt32(0);
                            string designation = reader.GetString(1);
                            string marque = reader.GetString(2);
                            string concentration = reader.GetString(3);
                            string type = reader.GetString(4);
                            double prix = reader.GetDouble(5);

                            Medicaments medic = new Medicaments(idMed, designation, marque, concentration, type, prix);
                            comboBox_choix.Items.Add(medic.ToString());
                        }
                    }
                }
            }
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            if(comboBox_choix.SelectedIndex != -1)
            {
                string selected_medic = comboBox_choix.SelectedItem.ToString();
                comboBox_panier.Items.Add(selected_medic);
                comboBox_choix.Text = "";
                comboBox_choix.SelectedIndex = -1;

                txtDesignation.Text = "Designation : ";
                txtMarque.Text = "Marque : ";
                txtConcentration.Text = "Concentration : ";
                txtType.Text = "Type : ";
                txtPrix.Text = "Prix : ";
            }

            CalculPrix();
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            if(comboBox_panier.SelectedIndex != -1)
            {
                string selected_medic = comboBox_panier.SelectedItem.ToString();
                comboBox_panier.Items.Remove(selected_medic);
                comboBox_panier.Text = "";
                comboBox_panier.SelectedIndex = -1;
            }

            CalculPrix();
        }

        private void button_valider_Click(object sender, EventArgs e)
        {
            //Vérification du panier et insertion de ce dernier dans la base de données
            if (comboBox_panier.Items.Count != 0)
            {
                MessageBox.Show($"Panier validé", "Validé", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //On va insérer dans la BDD le numéro du panier et l'utilisateur qui le concerne
                
                string connectionString = "Server=172.22.48.38;Database=gsb_praticienCompletee;User Id=admin;Password=admin;";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    // Ouvrir la connexion
                    connection.Open();

                    //Requête
                    string query = "INSERT INTO panier VALUES (0,@idUser)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idUser", Convert.ToInt32(StockTemp.idUtili));
                        command.ExecuteNonQuery();
                    }
                }

                //On récupère l'id du panier associé à l'user afin d'y insérer les médics

                int idPanierInt = 0;

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    // Ouvrir la connexion
                    connection.Open();

                    //Requête
                    string idPanier = "SELECT idPanier FROM panier WHERE panier.idPra = @codePra";

                    using (MySqlCommand command = new MySqlCommand(idPanier, connection))
                    {
                        command.Parameters.AddWithValue("@codePra", StockTemp.idUtili);
                        command.ExecuteNonQuery();

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                idPanierInt = reader.GetInt32(0);
                            }
                        }
                    }                   
                }

                //Pour chaque médicament dans le panier de l'application, on récupère son id afin de l'enregistrer dans un panier dans la BDD
                foreach (String str in comboBox_panier.Items)
                {
                    string[] result = Regex.Split(str.ToString(), @";");
                    string idMed = result[0];
                    int index = 9;
                    string trueIdMed = idMed.Substring(index);
                    int idMedInt = Convert.ToInt32(trueIdMed);

                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        // Ouvrir la connexion
                        connection.Open();

                        //Requête
                        string query = "INSERT INTO medpanier VALUES (@idPanier,@idMed)";

                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@idPanier", idPanierInt);
                            command.Parameters.AddWithValue("@idMed", idMedInt);
                            command.ExecuteNonQuery();
                        }
                    }
                }

            }
            else
            {
                MessageBox.Show($"Panier vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculPrix()
        {
            double prixTot = 0;

            foreach (var item in comboBox_panier.Items)
            {
                string[] result = Regex.Split(item.ToString(), @";");
                string prix = result[5];
                int index = 9;
                string truePrix = prix.Substring(index);
                double prixDouble = Convert.ToDouble(truePrix);
                prixTot += prixDouble;
            }
            //prixLabel.Text = prixTot.ToString();
            prixLabel.Text = "Le prix total est de: " + prixTot.ToString();

            switch (StockTemp.codePrati)
            {
                case "MH":
                    prixTot = prixTot * 1.01;
                    break;

                case "MV":
                    prixTot = prixTot * 1.02;
                    break;

                case "PH":
                    prixTot = prixTot * 1.03;
                    break;

                case "PO":
                    prixTot = prixTot * 1.04;
                    break;

                case "PS":
                    prixTot = prixTot * 1.05;
                    break;
            }

            prixFinal.Text = "Après majoration, le prix est de: " + prixTot.ToString("F2");
        }

        private void ButtonDeco_Click(object sender, EventArgs e)
        {
            StockTemp.codePrati = "";
            StockTemp.idUtili = "";
            this.Close();
        }

        private void comboBox_choix_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox_choix.SelectedItem != null)
            {
                int index = 0;
                string[] result = Regex.Split(comboBox_choix.SelectedItem.ToString(), @";");
                string designation = result[1];
                index = 15;
                string trueDesignation = designation.Substring(index);
                string marque = result[2];
                index = 11;
                string trueMarque = marque.Substring(index);
                string concentration = result[3];
                index = 18;
                string trueConc = concentration.Substring(index);
                string type = result[4];
                index = 9;
                string trueType = type.Substring(index);
                string prix = result[5];
                index = 9;
                string truePrix = prix.Substring(index);

                txtDesignation.Text = "Designation : " + trueDesignation;
                txtMarque.Text = "Marque : " + trueMarque;
                txtConcentration.Text = "Concentration : " + trueConc;
                txtType.Text = "Type : " + trueType;
                txtPrix.Text = "Prix : " + truePrix;
            }
        }
    }
}
