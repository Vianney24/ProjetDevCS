namespace ProjetTransDevCS
{
    partial class FormAccueil
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxEmploye = new System.Windows.Forms.ListBox();
            this.buttonAjouterEmploye = new System.Windows.Forms.Button();
            this.buttonModifierEmploye = new System.Windows.Forms.Button();
            this.buttonSupprimerEmploye = new System.Windows.Forms.Button();
            this.buttonTypeDiplome = new System.Windows.Forms.Button();
            this.buttonTypeContrat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxEmploye
            // 
            this.listBoxEmploye.FormattingEnabled = true;
            this.listBoxEmploye.ItemHeight = 16;
            this.listBoxEmploye.Location = new System.Drawing.Point(256, 31);
            this.listBoxEmploye.Name = "listBoxEmploye";
            this.listBoxEmploye.Size = new System.Drawing.Size(576, 276);
            this.listBoxEmploye.TabIndex = 0;
            this.listBoxEmploye.SelectedIndexChanged += new System.EventHandler(this.listBoxEmploye_SelectedIndexChanged);
            // 
            // buttonAjouterEmploye
            // 
            this.buttonAjouterEmploye.Location = new System.Drawing.Point(36, 31);
            this.buttonAjouterEmploye.Name = "buttonAjouterEmploye";
            this.buttonAjouterEmploye.Size = new System.Drawing.Size(190, 40);
            this.buttonAjouterEmploye.TabIndex = 1;
            this.buttonAjouterEmploye.Text = "Ajouter un employé";
            this.buttonAjouterEmploye.UseVisualStyleBackColor = true;
            this.buttonAjouterEmploye.Click += new System.EventHandler(this.buttonAjouterEmploye_Click);
            // 
            // buttonModifierEmploye
            // 
            this.buttonModifierEmploye.Location = new System.Drawing.Point(36, 77);
            this.buttonModifierEmploye.Name = "buttonModifierEmploye";
            this.buttonModifierEmploye.Size = new System.Drawing.Size(190, 40);
            this.buttonModifierEmploye.TabIndex = 2;
            this.buttonModifierEmploye.Text = "Modifier un employé";
            this.buttonModifierEmploye.UseVisualStyleBackColor = true;
            this.buttonModifierEmploye.Click += new System.EventHandler(this.buttonModifierEmploye_Click);
            // 
            // buttonSupprimerEmploye
            // 
            this.buttonSupprimerEmploye.Location = new System.Drawing.Point(36, 123);
            this.buttonSupprimerEmploye.Name = "buttonSupprimerEmploye";
            this.buttonSupprimerEmploye.Size = new System.Drawing.Size(190, 40);
            this.buttonSupprimerEmploye.TabIndex = 3;
            this.buttonSupprimerEmploye.Text = "Supprimer un employé";
            this.buttonSupprimerEmploye.UseVisualStyleBackColor = true;
            this.buttonSupprimerEmploye.Click += new System.EventHandler(this.buttonSupprimerEmploye_Click);
            // 
            // buttonTypeDiplome
            // 
            this.buttonTypeDiplome.Location = new System.Drawing.Point(625, 388);
            this.buttonTypeDiplome.Name = "buttonTypeDiplome";
            this.buttonTypeDiplome.Size = new System.Drawing.Size(207, 40);
            this.buttonTypeDiplome.TabIndex = 4;
            this.buttonTypeDiplome.Text = "Types de diplome";
            this.buttonTypeDiplome.UseVisualStyleBackColor = true;
            this.buttonTypeDiplome.Click += new System.EventHandler(this.buttonAjouterTypeDiplome_Click);
            // 
            // buttonTypeContrat
            // 
            this.buttonTypeContrat.Location = new System.Drawing.Point(412, 388);
            this.buttonTypeContrat.Name = "buttonTypeContrat";
            this.buttonTypeContrat.Size = new System.Drawing.Size(207, 40);
            this.buttonTypeContrat.TabIndex = 5;
            this.buttonTypeContrat.Text = "Types de Contrat";
            this.buttonTypeContrat.UseVisualStyleBackColor = true;
            this.buttonTypeContrat.Click += new System.EventHandler(this.buttonAjouterTypeContrat_Click);
            // 
            // FormAccueil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(844, 440);
            this.Controls.Add(this.buttonTypeContrat);
            this.Controls.Add(this.buttonTypeDiplome);
            this.Controls.Add(this.buttonSupprimerEmploye);
            this.Controls.Add(this.buttonModifierEmploye);
            this.Controls.Add(this.buttonAjouterEmploye);
            this.Controls.Add(this.listBoxEmploye);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormAccueil";
            this.Text = "Accueil";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxEmploye;
        private System.Windows.Forms.Button buttonAjouterEmploye;
        private System.Windows.Forms.Button buttonModifierEmploye;
        private System.Windows.Forms.Button buttonSupprimerEmploye;
        private System.Windows.Forms.Button buttonTypeDiplome;
        private System.Windows.Forms.Button buttonTypeContrat;
    }
}

