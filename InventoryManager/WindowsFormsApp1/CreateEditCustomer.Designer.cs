namespace WindowsFormsApp1
{
    partial class CreateEditCustomer
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
            this.IdTxt = new System.Windows.Forms.Label();
            this.IdLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.postalCodeTxt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cityTxt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.countryTxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.nipTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.mailTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.phoneNumberTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nameTxt = new System.Windows.Forms.TextBox();
            this.lb = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.addressRow2Txt = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.addressRow1Txt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // IdTxt
            // 
            this.IdTxt.AutoSize = true;
            this.IdTxt.Location = new System.Drawing.Point(216, 111);
            this.IdTxt.Name = "IdTxt";
            this.IdTxt.Size = new System.Drawing.Size(14, 16);
            this.IdTxt.TabIndex = 40;
            this.IdTxt.Text = "0";
            // 
            // IdLabel
            // 
            this.IdLabel.AutoSize = true;
            this.IdLabel.Location = new System.Drawing.Point(99, 111);
            this.IdLabel.Name = "IdLabel";
            this.IdLabel.Size = new System.Drawing.Size(18, 16);
            this.IdLabel.TabIndex = 39;
            this.IdLabel.Text = "Id";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(436, 523);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(101, 38);
            this.cancelButton.TabIndex = 38;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click_1);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(310, 523);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(93, 38);
            this.saveButton.TabIndex = 37;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(99, 403);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 16);
            this.label8.TabIndex = 36;
            this.label8.Text = "Postal Code";
            // 
            // postalCodeTxt
            // 
            this.postalCodeTxt.Location = new System.Drawing.Point(216, 397);
            this.postalCodeTxt.Name = "postalCodeTxt";
            this.postalCodeTxt.Size = new System.Drawing.Size(445, 22);
            this.postalCodeTxt.TabIndex = 35;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(99, 359);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 16);
            this.label7.TabIndex = 34;
            this.label7.Text = "City";
            // 
            // cityTxt
            // 
            this.cityTxt.Location = new System.Drawing.Point(216, 353);
            this.cityTxt.Name = "cityTxt";
            this.cityTxt.Size = new System.Drawing.Size(445, 22);
            this.cityTxt.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(99, 312);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 16);
            this.label6.TabIndex = 32;
            this.label6.Text = "Country";
            // 
            // countryTxt
            // 
            this.countryTxt.Location = new System.Drawing.Point(216, 306);
            this.countryTxt.Name = "countryTxt";
            this.countryTxt.Size = new System.Drawing.Size(445, 22);
            this.countryTxt.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(99, 270);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 16);
            this.label5.TabIndex = 30;
            this.label5.Text = "Nip";
            // 
            // nipTxt
            // 
            this.nipTxt.Location = new System.Drawing.Point(216, 264);
            this.nipTxt.Name = "nipTxt";
            this.nipTxt.Size = new System.Drawing.Size(445, 22);
            this.nipTxt.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(99, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 16);
            this.label4.TabIndex = 28;
            this.label4.Text = "Mail";
            // 
            // mailTxt
            // 
            this.mailTxt.Location = new System.Drawing.Point(216, 225);
            this.mailTxt.Name = "mailTxt";
            this.mailTxt.Size = new System.Drawing.Size(445, 22);
            this.mailTxt.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(99, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 16);
            this.label3.TabIndex = 26;
            this.label3.Text = "Phone Number";
            // 
            // phoneNumberTxt
            // 
            this.phoneNumberTxt.Location = new System.Drawing.Point(216, 186);
            this.phoneNumberTxt.Name = "phoneNumberTxt";
            this.phoneNumberTxt.Size = new System.Drawing.Size(445, 22);
            this.phoneNumberTxt.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(99, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 24;
            this.label2.Text = "Name";
            // 
            // nameTxt
            // 
            this.nameTxt.Location = new System.Drawing.Point(216, 142);
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.Size = new System.Drawing.Size(445, 22);
            this.nameTxt.TabIndex = 23;
            // 
            // lb
            // 
            this.lb.AutoSize = true;
            this.lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb.Location = new System.Drawing.Point(342, 55);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(195, 29);
            this.lb.TabIndex = 22;
            this.lb.Text = "Create Customer";
            this.lb.UseWaitCursor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(99, 489);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 16);
            this.label1.TabIndex = 44;
            this.label1.Text = "Address Row 2";
            // 
            // addressRow2Txt
            // 
            this.addressRow2Txt.Location = new System.Drawing.Point(216, 483);
            this.addressRow2Txt.Name = "addressRow2Txt";
            this.addressRow2Txt.Size = new System.Drawing.Size(445, 22);
            this.addressRow2Txt.TabIndex = 43;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(99, 445);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 16);
            this.label9.TabIndex = 42;
            this.label9.Text = "Address Row 1";
            // 
            // addressRow1Txt
            // 
            this.addressRow1Txt.Location = new System.Drawing.Point(216, 439);
            this.addressRow1Txt.Name = "addressRow1Txt";
            this.addressRow1Txt.Size = new System.Drawing.Size(445, 22);
            this.addressRow1Txt.TabIndex = 41;
            // 
            // CreateEditCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 599);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addressRow2Txt);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.addressRow1Txt);
            this.Controls.Add(this.IdTxt);
            this.Controls.Add(this.IdLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.postalCodeTxt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cityTxt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.countryTxt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nipTxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.mailTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.phoneNumberTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameTxt);
            this.Controls.Add(this.lb);
            this.Name = "CreateEditCustomer";
            this.Text = "CreateEditCustomer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label IdTxt;
        private System.Windows.Forms.Label IdLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox postalCodeTxt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox cityTxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox countryTxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox nipTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox mailTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox phoneNumberTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameTxt;
        private System.Windows.Forms.Label lb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox addressRow2Txt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox addressRow1Txt;
    }
}