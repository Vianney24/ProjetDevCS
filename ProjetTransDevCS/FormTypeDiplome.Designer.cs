namespace ProjetTransDevCS
{
    partial class FormTypeDiplome
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
            this.buttonSupprimerTypeDiplome = new System.Windows.Forms.Button();
            this.buttonAjouterTypeDiplome = new System.Windows.Forms.Button();
            this.listBoxTypeDiplome = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // buttonSupprimerTypeDiplome
            // 
            this.buttonSupprimerTypeDiplome.Enabled = false;
            this.buttonSupprimerTypeDiplome.Location = new System.Drawing.Point(16, 58);
            this.buttonSupprimerTypeDiplome.Name = "buttonSupprimerTypeDiplome";
            this.buttonSupprimerTypeDiplome.Size = new System.Drawing.Size(219, 40);
            this.buttonSupprimerTypeDiplome.TabIndex = 6;
            this.buttonSupprimerTypeDiplome.Text = "Supprimer un Type de Diplome";
            this.buttonSupprimerTypeDiplome.UseVisualStyleBackColor = true;
            this.buttonSupprimerTypeDiplome.Click += new System.EventHandler(this.buttonSupprimerTypeDiplome_Click);
            // 
            // buttonAjouterTypeDiplome
            // 
            this.buttonAjouterTypeDiplome.Location = new System.Drawing.Point(16, 12);
            this.buttonAjouterTypeDiplome.Name = "buttonAjouterTypeDiplome";
            this.buttonAjouterTypeDiplome.Size = new System.Drawing.Size(219, 40);
            this.buttonAjouterTypeDiplome.TabIndex = 5;
            this.buttonAjouterTypeDiplome.Text = "Ajouter un Type de Diplome";
            this.buttonAjouterTypeDiplome.UseVisualStyleBackColor = true;
            this.buttonAjouterTypeDiplome.Click += new System.EventHandler(this.buttonAjouterTypeDiplome_Click);
            // 
            // listBoxTypeDiplome
            // 
            this.listBoxTypeDiplome.FormattingEnabled = true;
            this.listBoxTypeDiplome.ItemHeight = 16;
            this.listBoxTypeDiplome.Location = new System.Drawing.Point(241, 12);
            this.listBoxTypeDiplome.Name = "listBoxTypeDiplome";
            this.listBoxTypeDiplome.Size = new System.Drawing.Size(420, 276);
            this.listBoxTypeDiplome.TabIndex = 4;
            this.listBoxTypeDiplome.SelectedIndexChanged += new System.EventHandler(this.listBoxTypeDiplome_SelectedIndexChanged);
            // 
            // FormTypeDiplome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(677, 300);
            this.Controls.Add(this.buttonSupprimerTypeDiplome);
            this.Controls.Add(this.buttonAjouterTypeDiplome);
            this.Controls.Add(this.listBoxTypeDiplome);
            this.Name = "FormTypeDiplome";
            this.Text = "Type de Diplome";
            this.Load += new System.EventHandler(this.FormTypeDiplome_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSupprimerTypeDiplome;
        private System.Windows.Forms.Button buttonAjouterTypeDiplome;
        private System.Windows.Forms.ListBox listBoxTypeDiplome;
    }
}