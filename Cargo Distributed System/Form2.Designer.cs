
namespace Cargo_Distributed_System
{
    partial class RegistrationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrationForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.userNameTbx = new System.Windows.Forms.TextBox();
            this.passwordTbx = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.securityQuestionCbx = new System.Windows.Forms.ComboBox();
            this.answerSecurityCbx = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.registerBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(219, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Registration";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(79, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(404, 28);
            this.label3.TabIndex = 2;
            this.label3.Text = "Orange Cargo Distributed System";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(80, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "UserName :";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(87, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Password :";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // userNameTbx
            // 
            this.userNameTbx.Location = new System.Drawing.Point(179, 183);
            this.userNameTbx.Name = "userNameTbx";
            this.userNameTbx.Size = new System.Drawing.Size(247, 20);
            this.userNameTbx.TabIndex = 5;
            this.userNameTbx.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // passwordTbx
            // 
            this.passwordTbx.Location = new System.Drawing.Point(179, 209);
            this.passwordTbx.Name = "passwordTbx";
            this.passwordTbx.Size = new System.Drawing.Size(247, 20);
            this.passwordTbx.TabIndex = 6;
            this.passwordTbx.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(31, 261);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Security Question :";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // securityQuestionCbx
            // 
            this.securityQuestionCbx.FormattingEnabled = true;
            this.securityQuestionCbx.Items.AddRange(new object[] {
            "What is your best friend name ?",
            "What is your favorite sport ?",
            "Which city do you want to live in ?"});
            this.securityQuestionCbx.Location = new System.Drawing.Point(179, 261);
            this.securityQuestionCbx.Name = "securityQuestionCbx";
            this.securityQuestionCbx.Size = new System.Drawing.Size(247, 21);
            this.securityQuestionCbx.TabIndex = 8;
            this.securityQuestionCbx.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // answerSecurityCbx
            // 
            this.answerSecurityCbx.Location = new System.Drawing.Point(179, 288);
            this.answerSecurityCbx.Name = "answerSecurityCbx";
            this.answerSecurityCbx.Size = new System.Drawing.Size(247, 20);
            this.answerSecurityCbx.TabIndex = 9;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(179, 235);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(247, 20);
            this.textBox1.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(20, 235);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(153, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Re-enter Password :";
            // 
            // registerBtn
            // 
            this.registerBtn.BackColor = System.Drawing.Color.Gray;
            this.registerBtn.Location = new System.Drawing.Point(261, 328);
            this.registerBtn.Name = "registerBtn";
            this.registerBtn.Size = new System.Drawing.Size(75, 23);
            this.registerBtn.TabIndex = 12;
            this.registerBtn.Text = "Register";
            this.registerBtn.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(237, 97);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 65);
            this.button1.TabIndex = 19;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(546, 371);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.registerBtn);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.answerSecurityCbx);
            this.Controls.Add(this.securityQuestionCbx);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.passwordTbx);
            this.Controls.Add(this.userNameTbx);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RegistrationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registration";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox userNameTbx;
        private System.Windows.Forms.TextBox passwordTbx;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox securityQuestionCbx;
        private System.Windows.Forms.TextBox answerSecurityCbx;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button registerBtn;
        private System.Windows.Forms.Button button1;
    }
}