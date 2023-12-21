namespace C969Tpennartz
{
    partial class LoginForm
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
            this.Login_button = new System.Windows.Forms.Button();
            this.exit_button = new System.Windows.Forms.Button();
            this.Username_label = new System.Windows.Forms.Label();
            this.Password_label = new System.Windows.Forms.Label();
            this.Username_text = new System.Windows.Forms.TextBox();
            this.Password_text = new System.Windows.Forms.TextBox();
            this.Login_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Login_button
            // 
            this.Login_button.BackColor = System.Drawing.SystemColors.Control;
            this.Login_button.Location = new System.Drawing.Point(554, 301);
            this.Login_button.Name = "Login_button";
            this.Login_button.Size = new System.Drawing.Size(75, 23);
            this.Login_button.TabIndex = 0;
            this.Login_button.Text = "Login";
            this.Login_button.UseVisualStyleBackColor = false;
            this.Login_button.Click += new System.EventHandler(this.Login_Button_Click);
            // 
            // exit_button
            // 
            this.exit_button.Location = new System.Drawing.Point(655, 301);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(76, 23);
            this.exit_button.TabIndex = 1;
            this.exit_button.Text = "Exit";
            this.exit_button.UseVisualStyleBackColor = true;
            this.exit_button.Click += new System.EventHandler(this.exitbutton_Click);
            // 
            // Username_label
            // 
            this.Username_label.AutoSize = true;
            this.Username_label.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Username_label.Location = new System.Drawing.Point(229, 132);
            this.Username_label.Name = "Username_label";
            this.Username_label.Size = new System.Drawing.Size(58, 13);
            this.Username_label.TabIndex = 2;
            this.Username_label.Text = "Username:";
            // 
            // Password_label
            // 
            this.Password_label.AutoSize = true;
            this.Password_label.Location = new System.Drawing.Point(229, 173);
            this.Password_label.Name = "Password_label";
            this.Password_label.Size = new System.Drawing.Size(56, 13);
            this.Password_label.TabIndex = 3;
            this.Password_label.Text = "Password:";
            // 
            // Username_text
            // 
            this.Username_text.Location = new System.Drawing.Point(291, 129);
            this.Username_text.Name = "Username_text";
            this.Username_text.Size = new System.Drawing.Size(211, 20);
            this.Username_text.TabIndex = 4;
            // 
            // Password_text
            // 
            this.Password_text.Location = new System.Drawing.Point(291, 170);
            this.Password_text.Name = "Password_text";
            this.Password_text.PasswordChar = '*';
            this.Password_text.Size = new System.Drawing.Size(211, 20);
            this.Password_text.TabIndex = 5;
            // 
            // Login_label
            // 
            this.Login_label.AutoSize = true;
            this.Login_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login_label.Location = new System.Drawing.Point(56, 147);
            this.Login_label.Name = "Login_label";
            this.Login_label.Size = new System.Drawing.Size(70, 25);
            this.Login_label.TabIndex = 6;
            this.Login_label.Text = "Login";
            // 
            // LoginForm
            // 
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(747, 384);
            this.Controls.Add(this.Login_label);
            this.Controls.Add(this.Password_text);
            this.Controls.Add(this.Username_text);
            this.Controls.Add(this.Password_label);
            this.Controls.Add(this.Username_label);
            this.Controls.Add(this.exit_button);
            this.Controls.Add(this.Login_button);
            this.Name = "LoginForm";
            this.Text = "Login Window";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.Button Login_button;
        private System.Windows.Forms.Button exit_button;
        private System.Windows.Forms.Label Username_label;
        private System.Windows.Forms.Label Password_label;
        private System.Windows.Forms.TextBox Username_text;
        private System.Windows.Forms.TextBox Password_text;
        private System.Windows.Forms.Label Login_label;
    }
}

