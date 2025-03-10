namespace Medicaments
{
    partial class form_panier
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label_titre = new System.Windows.Forms.Label();
            this.comboBox_choix = new System.Windows.Forms.ComboBox();
            this.button_add = new System.Windows.Forms.Button();
            this.label_titre2 = new System.Windows.Forms.Label();
            this.comboBox_panier = new System.Windows.Forms.ComboBox();
            this.button_delete = new System.Windows.Forms.Button();
            this.button_valider = new System.Windows.Forms.Button();
            this.prixLabel = new System.Windows.Forms.Label();
            this.prixFinal = new System.Windows.Forms.Label();
            this.ButtonDeco = new System.Windows.Forms.Button();
            this.idUtilisateur = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_titre
            // 
            this.label_titre.AutoSize = true;
            this.label_titre.Location = new System.Drawing.Point(24, 25);
            this.label_titre.Name = "label_titre";
            this.label_titre.Size = new System.Drawing.Size(280, 15);
            this.label_titre.TabIndex = 0;
            this.label_titre.Text = "Choisir un médicament à ajouter dans votre panier :";
            // 
            // comboBox_choix
            // 
            this.comboBox_choix.FormattingEnabled = true;
            this.comboBox_choix.Location = new System.Drawing.Point(24, 58);
            this.comboBox_choix.Name = "comboBox_choix";
            this.comboBox_choix.Size = new System.Drawing.Size(313, 23);
            this.comboBox_choix.TabIndex = 1;
            // 
            // button_add
            // 
            this.button_add.Location = new System.Drawing.Point(139, 246);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(75, 23);
            this.button_add.TabIndex = 2;
            this.button_add.Text = "Ajouter";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // label_titre2
            // 
            this.label_titre2.AutoSize = true;
            this.label_titre2.Location = new System.Drawing.Point(477, 28);
            this.label_titre2.Name = "label_titre2";
            this.label_titre2.Size = new System.Drawing.Size(179, 15);
            this.label_titre2.TabIndex = 3;
            this.label_titre2.Text = "Voici le contenu de votre panier :";
            // 
            // comboBox_panier
            // 
            this.comboBox_panier.FormattingEnabled = true;
            this.comboBox_panier.Location = new System.Drawing.Point(477, 58);
            this.comboBox_panier.Name = "comboBox_panier";
            this.comboBox_panier.Size = new System.Drawing.Size(311, 23);
            this.comboBox_panier.TabIndex = 4;
            // 
            // button_delete
            // 
            this.button_delete.Location = new System.Drawing.Point(594, 135);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(75, 23);
            this.button_delete.TabIndex = 5;
            this.button_delete.Text = "Supprimer ";
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // button_valider
            // 
            this.button_valider.Location = new System.Drawing.Point(576, 174);
            this.button_valider.Name = "button_valider";
            this.button_valider.Size = new System.Drawing.Size(112, 23);
            this.button_valider.TabIndex = 6;
            this.button_valider.Text = "Valider Panier";
            this.button_valider.UseVisualStyleBackColor = true;
            this.button_valider.Click += new System.EventHandler(this.button_valider_Click);
            // 
            // prixLabel
            // 
            this.prixLabel.AutoSize = true;
            this.prixLabel.Location = new System.Drawing.Point(576, 250);
            this.prixLabel.Name = "prixLabel";
            this.prixLabel.Size = new System.Drawing.Size(109, 15);
            this.prixLabel.TabIndex = 7;
            this.prixLabel.Text = "Le prix total est de :";
            // 
            // prixFinal
            // 
            this.prixFinal.AutoSize = true;
            this.prixFinal.Location = new System.Drawing.Point(576, 278);
            this.prixFinal.Name = "prixFinal";
            this.prixFinal.Size = new System.Drawing.Size(176, 15);
            this.prixFinal.TabIndex = 8;
            this.prixFinal.Text = "Après majoration, le prix est de: ";
            // 
            // ButtonDeco
            // 
            this.ButtonDeco.Location = new System.Drawing.Point(693, 415);
            this.ButtonDeco.Name = "ButtonDeco";
            this.ButtonDeco.Size = new System.Drawing.Size(86, 23);
            this.ButtonDeco.TabIndex = 9;
            this.ButtonDeco.Text = "Déconnexion";
            this.ButtonDeco.UseVisualStyleBackColor = true;
            this.ButtonDeco.Click += new System.EventHandler(this.ButtonDeco_Click);
            // 
            // idUtilisateur
            // 
            this.idUtilisateur.AutoSize = true;
            this.idUtilisateur.Location = new System.Drawing.Point(12, 406);
            this.idUtilisateur.Name = "idUtilisateur";
            this.idUtilisateur.Size = new System.Drawing.Size(130, 15);
            this.idUtilisateur.TabIndex = 10;
            this.idUtilisateur.Text = "Connecté en tant que : ";
            // 
            // form_panier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.idUtilisateur);
            this.Controls.Add(this.ButtonDeco);
            this.Controls.Add(this.prixFinal);
            this.Controls.Add(this.prixLabel);
            this.Controls.Add(this.button_valider);
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.comboBox_panier);
            this.Controls.Add(this.label_titre2);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.comboBox_choix);
            this.Controls.Add(this.label_titre);
            this.Name = "form_panier";
            this.Text = "Panier";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label_titre;
        private ComboBox comboBox_choix;
        private Button button_add;
        private Label label_titre2;
        private ComboBox comboBox_panier;
        private Button button_delete;
        private Button button_valider;
        private Label prixLabel;
        private Label prixFinal;
        private Button ButtonDeco;
        private Label idUtilisateur;
    }
}