namespace Bankautomat
{
    partial class Login
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
            this.BenutzerNameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PasswortBox = new System.Windows.Forms.TextBox();
            this.AnmeldeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kundennummer";
            // 
            // BenutzerNameBox
            // 
            this.BenutzerNameBox.Location = new System.Drawing.Point(12, 25);
            this.BenutzerNameBox.Name = "BenutzerNameBox";
            this.BenutzerNameBox.Size = new System.Drawing.Size(100, 20);
            this.BenutzerNameBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Passwort";
            // 
            // PasswortBox
            // 
            this.PasswortBox.Location = new System.Drawing.Point(12, 64);
            this.PasswortBox.Name = "PasswortBox";
            this.PasswortBox.PasswordChar = '*';
            this.PasswortBox.Size = new System.Drawing.Size(100, 20);
            this.PasswortBox.TabIndex = 3;
            // 
            // AnmeldeButton
            // 
            this.AnmeldeButton.Location = new System.Drawing.Point(12, 90);
            this.AnmeldeButton.Name = "AnmeldeButton";
            this.AnmeldeButton.Size = new System.Drawing.Size(100, 23);
            this.AnmeldeButton.TabIndex = 4;
            this.AnmeldeButton.Text = "Anmelden";
            this.AnmeldeButton.UseVisualStyleBackColor = true;
            this.AnmeldeButton.Click += new System.EventHandler(this.AnmeldeButton_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AnmeldeButton);
            this.Controls.Add(this.PasswortBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BenutzerNameBox);
            this.Controls.Add(this.label1);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox BenutzerNameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PasswortBox;
        private System.Windows.Forms.Button AnmeldeButton;
    }
}

