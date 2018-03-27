namespace ProjetTransDevCS
{
    partial class FormTypeContrat
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
            this.listBoxTypeContrat = new System.Windows.Forms.ListBox();
            this.buttonAjouterTypeContrat = new System.Windows.Forms.Button();
            this.buttonSupprimerTypeContrat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxTypeContrat
            // 
            this.listBoxTypeContrat.FormattingEnabled = true;
            this.listBoxTypeContrat.ItemHeight = 16;
            this.listBoxTypeContrat.Location = new System.Drawing.Point(245, 12);
            this.listBoxTypeContrat.Name = "listBoxTypeContrat";
            this.listBoxTypeContrat.Size = new System.Drawing.Size(420, 276);
            this.listBoxTypeContrat.TabIndex = 1;
            this.listBoxTypeContrat.SelectedIndexChanged += new System.EventHandler(this.listBoxTypeContrat_SelectedIndexChanged);
            // 
            // buttonAjouterTypeContrat
            // 
            this.buttonAjouterTypeContrat.Location = new System.Drawing.Point(20, 12);
            this.buttonAjouterTypeContrat.Name = "buttonAjouterTypeContrat";
            this.buttonAjouterTypeContrat.Size = new System.Drawing.Size(219, 40);
            this.buttonAjouterTypeContrat.TabIndex = 2;
            this.buttonAjouterTypeContrat.Text = "Ajouter un Type de Contrat";
            this.buttonAjouterTypeContrat.UseVisualStyleBackColor = true;
            this.buttonAjouterTypeContrat.Click += new System.EventHandler(this.buttonAjouterTypeContrat_Click);
            // 
            // buttonSupprimerTypeContrat
            // 
            this.buttonSupprimerTypeContrat.Enabled = false;
            this.buttonSupprimerTypeContrat.Location = new System.Drawing.Point(20, 58);
            this.buttonSupprimerTypeContrat.Name = "buttonSupprimerTypeContrat";
            this.buttonSupprimerTypeContrat.Size = new System.Drawing.Size(219, 40);
            this.buttonSupprimerTypeContrat.TabIndex = 3;
            this.buttonSupprimerTypeContrat.Text = "Supprimer un Type de Contrat";
            this.buttonSupprimerTypeContrat.UseVisualStyleBackColor = true;
            this.buttonSupprimerTypeContrat.Click += new System.EventHandler(this.buttonSupprimerTypeContrat_Click);
            // 
            // FormTypeContrat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(677, 300);
            this.Controls.Add(this.buttonSupprimerTypeContrat);
            this.Controls.Add(this.buttonAjouterTypeContrat);
            this.Controls.Add(this.listBoxTypeContrat);
            this.Name = "FormTypeContrat";
            this.Text = "Type de Contrat";
            this.Load += new System.EventHandler(this.FormTypeContrat_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxTypeContrat;
        private System.Windows.Forms.Button buttonAjouterTypeContrat;
        private System.Windows.Forms.Button buttonSupprimerTypeContrat;
    }
}