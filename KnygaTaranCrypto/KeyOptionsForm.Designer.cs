namespace KnygaTaranCrypto
{
    partial class KeyOptionsForm
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.tbSeed = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tbPassword = new System.Windows.Forms.TextBox();
			this.lbKeyLength = new System.Windows.Forms.ListBox();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Пароль:";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lbKeyLength);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Controls.Add(this.btnSave);
			this.panel1.Controls.Add(this.tbSeed);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.tbPassword);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(450, 245);
			this.panel1.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.label3.Location = new System.Drawing.Point(12, 123);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(77, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Длина ключа:";
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(218, 210);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Отмена";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(124, 210);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 4;
			this.btnSave.Text = "Сохранить";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// tbSeed
			// 
			this.tbSeed.Location = new System.Drawing.Point(272, 67);
			this.tbSeed.Name = "tbSeed";
			this.tbSeed.Size = new System.Drawing.Size(100, 20);
			this.tbSeed.TabIndex = 3;
			this.tbSeed.Text = "0";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 70);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(243, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Шаг для псевдослучайного генератора (seed) :";
			// 
			// tbPassword
			// 
			this.tbPassword.Location = new System.Drawing.Point(15, 25);
			this.tbPassword.Multiline = true;
			this.tbPassword.Name = "tbPassword";
			this.tbPassword.Size = new System.Drawing.Size(423, 35);
			this.tbPassword.TabIndex = 1;
			// 
			// lbKeyLength
			// 
			this.lbKeyLength.FormattingEnabled = true;
			this.lbKeyLength.Location = new System.Drawing.Point(124, 123);
			this.lbKeyLength.Name = "lbKeyLength";
			this.lbKeyLength.Size = new System.Drawing.Size(180, 69);
			this.lbKeyLength.TabIndex = 7;
			// 
			// KeyOptionsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(450, 245);
			this.Controls.Add(this.panel1);
			this.Name = "KeyOptionsForm";
			this.Text = "Опции шифрования";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox tbSeed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPassword;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ListBox lbKeyLength;
    }
}