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
            this.label2.Location = new System.Drawing.Point(12, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Kontostand: ";
            // 
            // Kontostandlbl
            // 
            this.Kontostandlbl.AutoSize = true;
            this.Kontostandlbl.Location = new System.Drawing.Point(105, 25);
            this.Kontostandlbl.Name = "Kontostandlbl";
            this.Kontostandlbl.Size = new System.Drawing.Size(35, 13);
            this.Kontostandlbl.TabIndex = 3;
            this.Kontostandlbl.Text = "label3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Transaktionen:";
            // 
            // TransaktionenListBox
            // 
            this.TransaktionenListBox.FormattingEnabled = true;
            this.TransaktionenListBox.Location = new System.Drawing.Point(96, 68);
            this.TransaktionenListBox.Name = "TransaktionenListBox";
            this.TransaktionenListBox.Size = new System.Drawing.Size(402, 121);
            this.TransaktionenListBox.TabIndex = 5;
            // 
            // LogoutBtn
            // 
            this.LogoutBtn.Location = new System.Drawing.Point(686, 12);
            this.LogoutBtn.Name = "LogoutBtn";
            this.LogoutBtn.Size = new System.Drawing.Size(86, 30);
            this.LogoutBtn.TabIndex = 6;
            this.LogoutBtn.Text = "Ausloggen";
            this.LogoutBtn.UseVisualStyleBackColor = true;
            this.LogoutBtn.Click += new System.EventHandler(this.LogoutBtn_Click);
            // 
            // ReloadBtn
            // 
            this.ReloadBtn.Location = new System.Drawing.Point(15, 201);
            this.ReloadBtn.Name = "ReloadBtn";
            this.ReloadBtn.Size = new System.Drawing.Size(84, 23);
            this.ReloadBtn.TabIndex = 7;
            this.ReloadBtn.Text = "Aktualisieren";
            this.ReloadBtn.UseVisualStyleBackColor = true;
            this.ReloadBtn.Click += new System.EventHandler(this.ReloadBtn_Click);
            // 
            // TransferBtn
            // 
            this.TransferBtn.Location = new System.Drawing.Point(105, 201);
            this.TransferBtn.Name = "TransferBtn";
            this.TransferBtn.Size = new System.Drawing.Size(82, 23);
            this.TransferBtn.TabIndex = 8;
            this.TransferBtn.Text = "Überweisen";
            this.TransferBtn.UseVisualStyleBackColor = true;
            this.TransferBtn.Click += new System.EventHandler(this.TransferBtn_Click);
            // 
            // depositBtn
            // 
            this.depositBtn.Location = new System.Drawing.Point(193, 201);
            this.depositBtn.Name = "depositBtn";
            this.depositBtn.Size = new System.Drawing.Size(75, 23);
            this.depositBtn.TabIndex = 9;
            this.depositBtn.Text = "Einzahlen";
            this.depositBtn.UseVisualStyleBackColor = true;
            this.depositBtn.Click += new System.EventHandler(this.depositBtn_Click);
            // 
            // WithdrawBtn
            // 
            this.WithdrawBtn.Location = new System.Drawing.Point(274, 201);
            this.WithdrawBtn.Name = "WithdrawBtn";
            this.WithdrawBtn.Size = new System.Drawing.Size(75, 23);
            this.WithdrawBtn.TabIndex = 10;
            this.WithdrawBtn.Text = "Abheben";
            this.WithdrawBtn.UseVisualStyleBackColor = true;
            this.WithdrawBtn.Click += new System.EventHandler(this.WithdrawBtn_Click);
            // 
            // Hauptmenue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 761);
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
    }
}