namespace Bankautomat
{
    partial class Hauptmenue
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
            this.label1 = new System.Windows.Forms.Label();
            this.Kundennummerlbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Kontostandlbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TransaktionenListBox = new System.Windows.Forms.ListBox();
            this.LogoutBtn = new System.Windows.Forms.Button();
            this.ReloadBtn = new System.Windows.Forms.Button();
            this.TransferBtn = new System.Windows.Forms.Button();
            this.depositBtn = new System.Windows.Forms.Button();
            this.WithdrawBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Nachnamelbl = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Vornamelbl = new System.Windows.Forms.Label();
            this.Telefonlbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kundennummer: ";
            // 
            // Kundennummerlbl
            // 
            this.Kundennummerlbl.AutoSize = true;
            this.Kundennummerlbl.Location = new System.Drawing.Point(105, 9);
            this.Kundennummerlbl.Name = "Kundennummerlbl";
            this.Kundennummerlbl.Size = new System.Drawing.Size(35, 13);
            this.Kundennummerlbl.TabIndex = 1;
            this.Kundennummerlbl.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Kontostand: ";
            // 
            // Kontostandlbl
            // 
            this.Kontostandlbl.AutoSize = true;
            this.Kontostandlbl.Location = new System.Drawing.Point(178, 111);
            this.Kontostandlbl.Name = "Kontostandlbl";
            this.Kontostandlbl.Size = new System.Drawing.Size(35, 13);
            this.Kontostandlbl.TabIndex = 3;
            this.Kontostandlbl.Text = "label3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.Location = new System.Drawing.Point(24, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Transaktionen:";
            // 
            // TransaktionenListBox
            // 
            this.TransaktionenListBox.FormattingEnabled = true;
            this.TransaktionenListBox.Location = new System.Drawing.Point(108, 140);
            this.TransaktionenListBox.Name = "TransaktionenListBox";
            this.TransaktionenListBox.Size = new System.Drawing.Size(525, 550);
            this.TransaktionenListBox.TabIndex = 5;
            // 
            // LogoutBtn
            // 
            this.LogoutBtn.Location = new System.Drawing.Point(672, 8);
            this.LogoutBtn.Name = "LogoutBtn";
            this.LogoutBtn.Size = new System.Drawing.Size(100, 30);
            this.LogoutBtn.TabIndex = 6;
            this.LogoutBtn.Text = "Ausloggen";
            this.LogoutBtn.UseVisualStyleBackColor = true;
            this.LogoutBtn.Click += new System.EventHandler(this.LogoutBtn_Click);
            // 
            // ReloadBtn
            // 
            this.ReloadBtn.Location = new System.Drawing.Point(12, 715);
            this.ReloadBtn.Name = "ReloadBtn";
            this.ReloadBtn.Size = new System.Drawing.Size(100, 30);
            this.ReloadBtn.TabIndex = 7;
            this.ReloadBtn.Text = "Aktualisieren";
            this.ReloadBtn.UseVisualStyleBackColor = true;
            this.ReloadBtn.Click += new System.EventHandler(this.ReloadBtn_Click);
            // 
            // TransferBtn
            // 
            this.TransferBtn.Location = new System.Drawing.Point(193, 715);
            this.TransferBtn.Name = "TransferBtn";
            this.TransferBtn.Size = new System.Drawing.Size(100, 30);
            this.TransferBtn.TabIndex = 8;
            this.TransferBtn.Text = "Überweisen";
            this.TransferBtn.UseVisualStyleBackColor = true;
            this.TransferBtn.Click += new System.EventHandler(this.TransferBtn_Click);
            // 
            // depositBtn
            // 
            this.depositBtn.Location = new System.Drawing.Point(299, 715);
            this.depositBtn.Name = "depositBtn";
            this.depositBtn.Size = new System.Drawing.Size(100, 30);
            this.depositBtn.TabIndex = 9;
            this.depositBtn.Text = "Einzahlen";
            this.depositBtn.UseVisualStyleBackColor = true;
            this.depositBtn.Click += new System.EventHandler(this.depositBtn_Click);
            // 
            // WithdrawBtn
            // 
            this.WithdrawBtn.Location = new System.Drawing.Point(405, 715);
            this.WithdrawBtn.Name = "WithdrawBtn";
            this.WithdrawBtn.Size = new System.Drawing.Size(100, 30);
            this.WithdrawBtn.TabIndex = 10;
            this.WithdrawBtn.Text = "Abheben";
            this.WithdrawBtn.UseVisualStyleBackColor = true;
            this.WithdrawBtn.Click += new System.EventHandler(this.WithdrawBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Nachname:";
            // 
            // Nachnamelbl
            // 
            this.Nachnamelbl.AutoSize = true;
            this.Nachnamelbl.Location = new System.Drawing.Point(105, 25);
            this.Nachnamelbl.Name = "Nachnamelbl";
            this.Nachnamelbl.Size = new System.Drawing.Size(35, 13);
            this.Nachnamelbl.TabIndex = 12;
            this.Nachnamelbl.Text = "label5";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Vorname:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Telefonnummer:";
            // 
            // Vornamelbl
            // 
            this.Vornamelbl.AutoSize = true;
            this.Vornamelbl.Location = new System.Drawing.Point(105, 40);
            this.Vornamelbl.Name = "Vornamelbl";
            this.Vornamelbl.Size = new System.Drawing.Size(35, 13);
            this.Vornamelbl.TabIndex = 15;
            this.Vornamelbl.Text = "label7";
            // 
            // Telefonlbl
            // 
            this.Telefonlbl.AutoSize = true;
            this.Telefonlbl.Location = new System.Drawing.Point(105, 55);
            this.Telefonlbl.Name = "Telefonlbl";
            this.Telefonlbl.Size = new System.Drawing.Size(35, 13);
            this.Telefonlbl.TabIndex = 16;
            this.Telefonlbl.Text = "label8";
            // 
            // Hauptmenue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 761);
            this.Controls.Add(this.Telefonlbl);
            this.Controls.Add(this.Vornamelbl);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Nachnamelbl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.WithdrawBtn);
            this.Controls.Add(this.depositBtn);
            this.Controls.Add(this.TransferBtn);
            this.Controls.Add(this.ReloadBtn);
            this.Controls.Add(this.LogoutBtn);
            this.Controls.Add(this.TransaktionenListBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Kontostandlbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Kundennummerlbl);
            this.Controls.Add(this.label1);
            this.Name = "Hauptmenue";
            this.Text = "Hauptmenue";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Kundennummerlbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Kontostandlbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox TransaktionenListBox;
        private System.Windows.Forms.Button LogoutBtn;
        private System.Windows.Forms.Button ReloadBtn;
        private System.Windows.Forms.Button TransferBtn;
        private System.Windows.Forms.Button depositBtn;
        private System.Windows.Forms.Button WithdrawBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Nachnamelbl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label Vornamelbl;
        private System.Windows.Forms.Label Telefonlbl;
    }
}