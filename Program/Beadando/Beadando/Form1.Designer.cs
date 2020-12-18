namespace Beadando
{
    partial class Form1
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
            this.dgv_gitarok = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_sorozatszam = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_tipus = new System.Windows.Forms.TextBox();
            this.tb_gyarto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtp_gyartasDatum = new System.Windows.Forms.DateTimePicker();
            this.cb_balkezes = new System.Windows.Forms.CheckBox();
            this.labelx = new System.Windows.Forms.Label();
            this.tb_erintokszama = new System.Windows.Forms.TextBox();
            this.cbb_hangszedok = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_hozzaad = new System.Windows.Forms.Button();
            this.btn_torol = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_gitarok)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_gitarok
            // 
            this.dgv_gitarok.AllowUserToAddRows = false;
            this.dgv_gitarok.AllowUserToDeleteRows = false;
            this.dgv_gitarok.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_gitarok.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_gitarok.Location = new System.Drawing.Point(12, 12);
            this.dgv_gitarok.Name = "dgv_gitarok";
            this.dgv_gitarok.RowHeadersWidth = 100;
            this.dgv_gitarok.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_gitarok.Size = new System.Drawing.Size(776, 273);
            this.dgv_gitarok.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 320);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sorozatszám:";
            // 
            // tb_sorozatszam
            // 
            this.tb_sorozatszam.Location = new System.Drawing.Point(140, 317);
            this.tb_sorozatszam.Name = "tb_sorozatszam";
            this.tb_sorozatszam.Size = new System.Drawing.Size(171, 22);
            this.tb_sorozatszam.TabIndex = 2;
            this.tb_sorozatszam.Leave += new System.EventHandler(this.tb_Sorozatszam_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 360);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Típus:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 400);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Gyártó:";
            // 
            // tb_tipus
            // 
            this.tb_tipus.Location = new System.Drawing.Point(140, 357);
            this.tb_tipus.Name = "tb_tipus";
            this.tb_tipus.Size = new System.Drawing.Size(171, 22);
            this.tb_tipus.TabIndex = 5;
            // 
            // tb_gyarto
            // 
            this.tb_gyarto.Location = new System.Drawing.Point(140, 397);
            this.tb_gyarto.Name = "tb_gyarto";
            this.tb_gyarto.Size = new System.Drawing.Size(171, 22);
            this.tb_gyarto.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 439);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Gyártás dátuma:";
            // 
            // dtp_gyartasDatum
            // 
            this.dtp_gyartasDatum.CustomFormat = "dd MMM yyyy";
            this.dtp_gyartasDatum.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_gyartasDatum.Location = new System.Drawing.Point(140, 439);
            this.dtp_gyartasDatum.Name = "dtp_gyartasDatum";
            this.dtp_gyartasDatum.Size = new System.Drawing.Size(171, 22);
            this.dtp_gyartasDatum.TabIndex = 8;
            // 
            // cb_balkezes
            // 
            this.cb_balkezes.AutoSize = true;
            this.cb_balkezes.Location = new System.Drawing.Point(412, 321);
            this.cb_balkezes.Name = "cb_balkezes";
            this.cb_balkezes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cb_balkezes.Size = new System.Drawing.Size(87, 21);
            this.cb_balkezes.TabIndex = 10;
            this.cb_balkezes.Text = "Balkezes";
            this.cb_balkezes.UseVisualStyleBackColor = true;
            // 
            // labelx
            // 
            this.labelx.AutoSize = true;
            this.labelx.Location = new System.Drawing.Point(414, 362);
            this.labelx.Name = "labelx";
            this.labelx.Size = new System.Drawing.Size(101, 17);
            this.labelx.TabIndex = 11;
            this.labelx.Text = "Érintők száma:";
            // 
            // tb_erintokszama
            // 
            this.tb_erintokszama.Location = new System.Drawing.Point(547, 357);
            this.tb_erintokszama.Name = "tb_erintokszama";
            this.tb_erintokszama.Size = new System.Drawing.Size(145, 22);
            this.tb_erintokszama.TabIndex = 12;
            // 
            // cbb_hangszedok
            // 
            this.cbb_hangszedok.FormattingEnabled = true;
            this.cbb_hangszedok.Location = new System.Drawing.Point(547, 397);
            this.cbb_hangszedok.Name = "cbb_hangszedok";
            this.cbb_hangszedok.Size = new System.Drawing.Size(145, 24);
            this.cbb_hangszedok.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(414, 400);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "Hangszedők:";
            // 
            // btn_hozzaad
            // 
            this.btn_hozzaad.Location = new System.Drawing.Point(417, 441);
            this.btn_hozzaad.Name = "btn_hozzaad";
            this.btn_hozzaad.Size = new System.Drawing.Size(114, 37);
            this.btn_hozzaad.TabIndex = 15;
            this.btn_hozzaad.Text = "Hozzáad";
            this.btn_hozzaad.UseVisualStyleBackColor = true;
            this.btn_hozzaad.Click += new System.EventHandler(this.btn_hozzaad_Click);
            // 
            // btn_torol
            // 
            this.btn_torol.Location = new System.Drawing.Point(547, 441);
            this.btn_torol.Name = "btn_torol";
            this.btn_torol.Size = new System.Drawing.Size(115, 37);
            this.btn_torol.TabIndex = 16;
            this.btn_torol.Text = "Töröl";
            this.btn_torol.UseVisualStyleBackColor = true;
            this.btn_torol.Click += new System.EventHandler(this.btn_torol_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 490);
            this.Controls.Add(this.btn_torol);
            this.Controls.Add(this.btn_hozzaad);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbb_hangszedok);
            this.Controls.Add(this.tb_erintokszama);
            this.Controls.Add(this.labelx);
            this.Controls.Add(this.cb_balkezes);
            this.Controls.Add(this.dtp_gyartasDatum);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_gyarto);
            this.Controls.Add(this.tb_tipus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_sorozatszam);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_gitarok);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_gitarok)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_gitarok;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_sorozatszam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_tipus;
        private System.Windows.Forms.TextBox tb_gyarto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtp_gyartasDatum;
        private System.Windows.Forms.CheckBox cb_balkezes;
        private System.Windows.Forms.Label labelx;
        private System.Windows.Forms.TextBox tb_erintokszama;
        private System.Windows.Forms.ComboBox cbb_hangszedok;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_hozzaad;
        private System.Windows.Forms.Button btn_torol;
    }
}

