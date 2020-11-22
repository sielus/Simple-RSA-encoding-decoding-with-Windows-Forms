﻿
namespace RSA_WF
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.privateKeyTextBox = new System.Windows.Forms.TextBox();
            this.publicKeyTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.updateKeys = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 46);
            this.button1.TabIndex = 0;
            this.button1.Text = "Generate Keys";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.generateKeysOnClick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 188);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 46);
            this.button2.TabIndex = 1;
            this.button2.Text = "Decrypt file";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 136);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(93, 46);
            this.button3.TabIndex = 2;
            this.button3.Text = "Encrypt file";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 84);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(93, 46);
            this.button4.TabIndex = 3;
            this.button4.Text = "Load Keys";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.loadKeysClick);
            // 
            // privateKeyTextBox
            // 
            this.privateKeyTextBox.Location = new System.Drawing.Point(133, 32);
            this.privateKeyTextBox.Multiline = true;
            this.privateKeyTextBox.Name = "privateKeyTextBox";
            this.privateKeyTextBox.Size = new System.Drawing.Size(182, 175);
            this.privateKeyTextBox.TabIndex = 4;
            this.privateKeyTextBox.TextChanged += new System.EventHandler(this.checkForNumbers);
            // 
            // publicKeyTextBox
            // 
            this.publicKeyTextBox.Location = new System.Drawing.Point(343, 32);
            this.publicKeyTextBox.Multiline = true;
            this.publicKeyTextBox.Name = "publicKeyTextBox";
            this.publicKeyTextBox.Size = new System.Drawing.Size(182, 175);
            this.publicKeyTextBox.TabIndex = 5;
            this.publicKeyTextBox.TextChanged += new System.EventHandler(this.checkForNumbers);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(130, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Private key";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(340, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Public key";
            // 
            // updateKeys
            // 
            this.updateKeys.Enabled = false;
            this.updateKeys.Location = new System.Drawing.Point(450, 214);
            this.updateKeys.Name = "updateKeys";
            this.updateKeys.Size = new System.Drawing.Size(75, 23);
            this.updateKeys.TabIndex = 8;
            this.updateKeys.Text = "Update keys";
            this.updateKeys.UseVisualStyleBackColor = true;
            this.updateKeys.Click += new System.EventHandler(this.updateKeysClick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 249);
            this.Controls.Add(this.updateKeys);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.publicKeyTextBox);
            this.Controls.Add(this.privateKeyTextBox);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox privateKeyTextBox;
        private System.Windows.Forms.TextBox publicKeyTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button updateKeys;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

