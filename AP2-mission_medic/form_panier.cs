using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
                string query = "SELECT medicament.designation, medicament.marque, medicament.concentration, medicament.type, medicament.Prix FROM medicament LIMIT 10";

                //Récuépération des données utilisateurs
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {

                    // Exécuter la requête et obtenir les résultats dans un DataReader
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string designation = reader.GetString(0);
                            string marque = reader.GetString(1);
                            string concentration = reader.GetString(2);
                            string type = reader.GetString(3);
                            double prix = reader.GetDouble(4);

                            Medicaments medic = new Medicaments(designation, marque, concentration, type, prix);
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
            }
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
        }

        private void button_valider_Click(object sender, EventArgs e)
        {
            double prixTot = 0;

            foreach (var item in comboBox_panier.Items)
            {
                string[] result = Regex.Split(item.ToString(), @";");
                string prix = result[4];
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
            Application.Exit();     
        }
    }
}
