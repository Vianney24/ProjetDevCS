namespace ProjetTransDevCS
{
    partial class FormAjouterTypeDiplome
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
            this.groupBoxTypeDiplome = new System.Windows.Forms.GroupBox();
            this.labelNomTypeDiplome = new System.Windows.Forms.Label();
            this.textBoxNomTypeDiplome = new System.Windows.Forms.TextBox();
            this.buttonAjouterTypeDiplome = new System.Windows.Forms.Button();
            this.groupBoxTypeDiplome.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxTypeDiplome
            // 
            this.groupBoxTypeDiplome.Controls.Add(this.textBoxNomTypeDiplome);
            this.groupBoxTypeDiplome.Controls.Add(this.labelNomTypeDiplome);
            this.groupBoxTypeDiplome.Location = new System.Drawing.Point(12, 12);
            this.groupBoxTypeDiplome.Name = "groupBoxTypeDiplome";
            this.groupBoxTypeDiplome.Size = new System.Drawing.Size(342, 127);
            this.groupBoxTypeDiplome.TabIndex = 0;
            this.groupBoxTypeDiplome.TabStop = false;
            this.groupBoxTypeDiplome.Text = "Type de diplome";
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
            // textBoxNomTypeDiplome
            // 
            this.textBoxNomTypeDiplome.Location = new System.Drawing.Point(102, 55);
            this.textBoxNomTypeDiplome.Name = "textBoxNomTypeDiplome";
            this.textBoxNomTypeDiplome.Size = new System.Drawing.Size(163, 22);
            this.textBoxNomTypeDiplome.TabIndex = 1;
            // 
            // buttonAjouterTypeDiplome
            // 
            this.buttonAjouterTypeDiplome.Location = new System.Drawing.Point(144, 145);
            this.buttonAjouterTypeDiplome.Name = "buttonAjouterTypeDiplome";
            this.buttonAjouterTypeDiplome.Size = new System.Drawing.Size(94, 39);
            this.buttonAjouterTypeDiplome.TabIndex = 1;
            this.buttonAjouterTypeDiplome.Text = "Ajouter";
            this.buttonAjouterTypeDiplome.UseVisualStyleBackColor = true;
            this.buttonAjouterTypeDiplome.Click += new System.EventHandler(this.buttonAjouterTypeDiplome_Click);
            // 
            // FormAjouterTypeDiplome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(366, 211);
            this.Controls.Add(this.buttonAjouterTypeDiplome);
            this.Controls.Add(this.groupBoxTypeDiplome);
            this.Name = "FormAjouterTypeDiplome";
            this.Text = "FormAjouterTypeDiplome";
            this.Load += new System.EventHandler(this.FormAjouterTypeDiplome_Load);
            this.groupBoxTypeDiplome.ResumeLayout(false);
            this.groupBoxTypeDiplome.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxTypeDiplome;
        private System.Windows.Forms.TextBox textBoxNomTypeDiplome;
        private System.Windows.Forms.Label labelNomTypeDiplome;
        private System.Windows.Forms.Button buttonAjouterTypeDiplome;
    }
}