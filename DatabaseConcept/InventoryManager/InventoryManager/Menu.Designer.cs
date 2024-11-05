namespace InventoryManager
{
    partial class Menu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            loginBox = new TextBox();
            passwordBox = new TextBox();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            loginButton = new Button();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // loginBox
            // 
            loginBox.Location = new Point(233, 248);
            loginBox.Name = "loginBox";
            loginBox.Size = new Size(332, 27);
            loginBox.TabIndex = 0;
            loginBox.TextChanged += loginBox_TextChanged;
            // 
            // passwordBox
            // 
            passwordBox.Location = new Point(233, 299);
            passwordBox.Name = "passwordBox";
            passwordBox.PasswordChar = '*';
            passwordBox.Size = new Size(332, 27);
            passwordBox.TabIndex = 1;
            passwordBox.TextChanged += passwordBox_TextChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.box2;
            pictureBox1.Location = new Point(344, 73);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(108, 100);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label1.Location = new Point(134, 248);
            label1.Name = "label1";
            label1.Size = new Size(61, 28);
            label1.TabIndex = 3;
            label1.Text = "Login";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label2.Location = new Point(134, 298);
            label2.Name = "label2";
            label2.Size = new Size(93, 28);
            label2.TabIndex = 4;
            label2.Text = "Password";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label3.Location = new Point(265, 192);
            label3.Name = "label3";
            label3.Size = new Size(269, 41);
            label3.TabIndex = 5;
            label3.Text = "Inventory Manager";
            // 
            // loginButton
            // 
            loginButton.Location = new Point(344, 352);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(108, 43);
            loginButton.TabIndex = 6;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += this.loginButton_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(28, 20);
            label4.Name = "label4";
            label4.Size = new Size(133, 20);
            label4.TabIndex = 7;
            label4.Text = "Inventory Manager";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(28, 60);
            label5.Name = "label5";
            label5.Size = new Size(181, 20);
            label5.TabIndex = 8;
            label5.Text = "Author: Wojciech Mierzwa";
            label5.Click += label5_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(28, 40);
            label6.Name = "label6";
            label6.Size = new Size(79, 20);
            label6.TabIndex = 9;
            label6.Text = "version 0.3";
            label6.Click += label6_Click;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(loginButton);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(passwordBox);
            Controls.Add(loginBox);
            Name = "Menu";
            Text = "InventoryManager";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox loginBox;
        private TextBox passwordBox;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button loginButton;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}
