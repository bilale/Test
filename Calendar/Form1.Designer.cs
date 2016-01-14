namespace Calendar
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtText = new System.Windows.Forms.TextBox();
            this.mcDebut = new System.Windows.Forms.MonthCalendar();
            this.tbDuree = new System.Windows.Forms.TrackBar();
            this.lblDuree = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnColor = new System.Windows.Forms.Button();
            this.cdColor = new System.Windows.Forms.ColorDialog();
            this.editView1 = new Calendar.EditView();
            ((System.ComponentModel.ISupportInitialize)(this.tbDuree)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nouveau Rendez-Vous";
            // 
            // txtText
            // 
            this.txtText.Location = new System.Drawing.Point(16, 30);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(224, 20);
            this.txtText.TabIndex = 1;
            // 
            // mcDebut
            // 
            this.mcDebut.Location = new System.Drawing.Point(13, 68);
            this.mcDebut.MaxSelectionCount = 1;
            this.mcDebut.Name = "mcDebut";
            this.mcDebut.TabIndex = 2;
            this.mcDebut.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.mcDebut_DateChanged);
            // 
            // tbDuree
            // 
            this.tbDuree.LargeChange = 30;
            this.tbDuree.Location = new System.Drawing.Point(16, 254);
            this.tbDuree.Maximum = 180;
            this.tbDuree.Minimum = 30;
            this.tbDuree.Name = "tbDuree";
            this.tbDuree.Size = new System.Drawing.Size(182, 45);
            this.tbDuree.SmallChange = 30;
            this.tbDuree.TabIndex = 3;
            this.tbDuree.TickFrequency = 30;
            this.tbDuree.Value = 30;
            this.tbDuree.Scroll += new System.EventHandler(this.tbDuree_Scroll);
            // 
            // lblDuree
            // 
            this.lblDuree.AutoSize = true;
            this.lblDuree.Location = new System.Drawing.Point(204, 254);
            this.lblDuree.Name = "lblDuree";
            this.lblDuree.Size = new System.Drawing.Size(35, 13);
            this.lblDuree.TabIndex = 4;
            this.lblDuree.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 297);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "label3";
            // 
            // txtColor
            // 
            this.txtColor.Enabled = false;
            this.txtColor.Location = new System.Drawing.Point(57, 297);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(22, 20);
            this.txtColor.TabIndex = 6;
            // 
            // btnAjouter
            // 
            this.btnAjouter.Location = new System.Drawing.Point(252, 337);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(78, 22);
            this.btnAjouter.TabIndex = 7;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // btnModifier
            // 
            this.btnModifier.Enabled = false;
            this.btnModifier.Location = new System.Drawing.Point(342, 337);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(78, 22);
            this.btnModifier.TabIndex = 8;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.UseVisualStyleBackColor = true;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.Enabled = false;
            this.btnAnnuler.Location = new System.Drawing.Point(518, 337);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(78, 22);
            this.btnAnnuler.TabIndex = 9;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.Enabled = false;
            this.btnSupprimer.Location = new System.Drawing.Point(437, 337);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(78, 22);
            this.btnSupprimer.TabIndex = 10;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = true;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(85, 297);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(38, 23);
            this.btnColor.TabIndex = 11;
            this.btnColor.Text = "...";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // editView1
            // 
            this.editView1.AllowDrop = true;
            this.editView1.Location = new System.Drawing.Point(252, 30);
            this.editView1.Name = "editView1";
            this.editView1.Size = new System.Drawing.Size(514, 301);
            this.editView1.TabIndex = 12;
            this.editView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.editView1_DragDrop);
            this.editView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.editView1_DragEnter);
            this.editView1.DragOver += new System.Windows.Forms.DragEventHandler(this.editView1_DragOver);
            this.editView1.DragLeave += new System.EventHandler(this.editView1_DragLeave);
            this.editView1.Paint += new System.Windows.Forms.PaintEventHandler(this.editView1_Paint);
            this.editView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.editView1_MouseDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 371);
            this.Controls.Add(this.editView1);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.txtColor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblDuree);
            this.Controls.Add(this.tbDuree);
            this.Controls.Add(this.mcDebut);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.tbDuree)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.MonthCalendar mcDebut;
        private System.Windows.Forms.TrackBar tbDuree;
        private System.Windows.Forms.Label lblDuree;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.ColorDialog cdColor;
        private EditView editView1;
       


    }
}

