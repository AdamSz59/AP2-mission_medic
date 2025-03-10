namespace Medicaments
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.identifiant = new System.Windows.Forms.TextBox();
            this.id_txt = new System.Windows.Forms.Label();
            this.mdp_txt = new System.Windows.Forms.Label();
            this.mdp = new System.Windows.Forms.TextBox();
            this.button_conexion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // identifiant
            // 
            this.identifiant.Location = new System.Drawing.Point(304, 75);
            this.identifiant.Name = "identifiant";
            this.identifiant.Size = new System.Drawing.Size(156, 23);
            this.identifiant.TabIndex = 0;
            this.identifiant.TextChanged += new System.EventHandler(this.identifiant_TextChanged);
            // 
            // id_txt
            // 
            this.id_txt.AutoSize = true;
            this.id_txt.Location = new System.Drawing.Point(351, 43);
            this.id_txt.Name = "id_txt";
            this.id_txt.Size = new System.Drawing.Size(67, 15);
            this.id_txt.TabIndex = 1;
            this.id_txt.Text = "Identifiant :";
            // 
            // mdp_txt
            // 
            this.mdp_txt.Location = new System.Drawing.Point(342, 117);
            this.mdp_txt.Name = "mdp_txt";
            this.mdp_txt.Size = new System.Drawing.Size(98, 23);
            this.mdp_txt.TabIndex = 0;
            this.mdp_txt.Text = "Mot de passe :";
            // 
            // mdp
            // 
            this.mdp.BackColor = System.Drawing.SystemColors.Window;
            this.mdp.Location = new System.Drawing.Point(304, 154);
            this.mdp.Name = "mdp";
            this.mdp.Size = new System.Drawing.Size(156, 23);
            this.mdp.TabIndex = 2;
            this.mdp.UseSystemPasswordChar = true;
            // 
            // button_conexion
            // 
            this.button_conexion.Location = new System.Drawing.Point(332, 212);
            this.button_conexion.Name = "button_conexion";
            this.button_conexion.Size = new System.Drawing.Size(102, 31);
            this.button_conexion.TabIndex = 3;
            this.button_conexion.Text = "Connexion";
            this.button_conexion.UseVisualStyleBackColor = true;
            this.button_conexion.Click += new System.EventHandler(this.button_conexion_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_conexion);
            this.Controls.Add(this.mdp_txt);
            this.Controls.Add(this.mdp);
            this.Controls.Add(this.id_txt);
            this.Controls.Add(this.identifiant);
            this.Name = "Form1";
            this.Text = "Formulaire de connexion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox identifiant;
        private Label id_txt;
        private Label mdp_txt;
        private TextBox mdp;
        private Button button_conexion;
    }
}