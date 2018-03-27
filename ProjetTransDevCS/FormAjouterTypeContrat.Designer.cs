namespace ProjetTransDevCS
{
    partial class FormAjouterTypeContrat
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
            this.groupBoxTypeContrat = new System.Windows.Forms.GroupBox();
            this.textBoxNomTypeContrat = new System.Windows.Forms.TextBox();
            this.labelNomTypeDiplome = new System.Windows.Forms.Label();
            this.buttonAjouterTypeContrat = new System.Windows.Forms.Button();
            this.groupBoxTypeContrat.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxTypeContrat
            // 
            this.groupBoxTypeContrat.Controls.Add(this.textBoxNomTypeContrat);
            this.groupBoxTypeContrat.Controls.Add(this.labelNomTypeDiplome);
            this.groupBoxTypeContrat.Location = new System.Drawing.Point(12, 12);
            this.groupBoxTypeContrat.Name = "groupBoxTypeContrat";
            this.groupBoxTypeContrat.Size = new System.Drawing.Size(342, 127);
            this.groupBoxTypeContrat.TabIndex = 1;
            this.groupBoxTypeContrat.TabStop = false;
            this.groupBoxTypeContrat.Text = "Type de Contrat";
            // 
            // textBoxNomTypeContrat
            // 
            this.textBoxNomTypeContrat.Location = new System.Drawing.Point(102, 55);
            this.textBoxNomTypeContrat.Name = "textBoxNomTypeContrat";
            this.textBoxNomTypeContrat.Size = new System.Drawing.Size(163, 22);
            this.textBoxNomTypeContrat.TabIndex = 1;
            // 
            // labelNomTypeDiplome
            // 
            this.labelNomTypeDiplome.AutoSize = true;
            this.labelNomTypeDiplome.Location = new System.Drawing.Point(59, 60);
            this.labelNomTypeDiplome.Name = "labelNomTypeDiplome";
            this.labelNomTypeDiplome.Size = new System.Drawing.Size(37, 17);
            this.labelNomTypeDiplome.TabIndex = 0;
            this.labelNomTypeDiplome.Text = "Nom";
            // 
            // buttonAjouterTypeContrat
            // 
            this.buttonAjouterTypeContrat.Location = new System.Drawing.Point(146, 145);
            this.buttonAjouterTypeContrat.Name = "buttonAjouterTypeContrat";
            this.buttonAjouterTypeContrat.Size = new System.Drawing.Size(94, 39);
            this.buttonAjouterTypeContrat.TabIndex = 2;
            this.buttonAjouterTypeContrat.Text = "Ajouter";
            this.buttonAjouterTypeContrat.UseVisualStyleBackColor = true;
            this.buttonAjouterTypeContrat.Click += new System.EventHandler(this.buttonAjouterTypeContrat_Click);
            // 
            // FormAjouterTypeContrat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(366, 211);
            this.Controls.Add(this.buttonAjouterTypeContrat);
            this.Controls.Add(this.groupBoxTypeContrat);
            this.Name = "FormAjouterTypeContrat";
            this.Text = "FormAjouterTypeContrat";
            this.Load += new System.EventHandler(this.FormAjouterTypeContrat_Load);
            this.groupBoxTypeContrat.ResumeLayout(false);
            this.groupBoxTypeContrat.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxTypeContrat;
        private System.Windows.Forms.TextBox textBoxNomTypeContrat;
        private System.Windows.Forms.Label labelNomTypeDiplome;
        private System.Windows.Forms.Button buttonAjouterTypeContrat;
    }
}