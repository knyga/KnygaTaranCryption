﻿namespace KnygaTaranCrypto
{
    partial class ModeCipherSelectionForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModeCipherSelectionForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.CipherList = new System.Windows.Forms.ListBox();
            this.ModeList = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.modeHelpButton = new System.Windows.Forms.Button();
            this.chiperHelpButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(503, 180);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.CipherList, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.ModeList, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(497, 134);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // CipherList
            // 
            this.CipherList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CipherList.FormattingEnabled = true;
            this.CipherList.Location = new System.Drawing.Point(3, 3);
            this.CipherList.Name = "CipherList";
            this.CipherList.Size = new System.Drawing.Size(242, 128);
            this.CipherList.TabIndex = 0;
            // 
            // ModeList
            // 
            this.ModeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ModeList.FormattingEnabled = true;
            this.ModeList.Location = new System.Drawing.Point(251, 3);
            this.ModeList.Name = "ModeList";
            this.ModeList.Size = new System.Drawing.Size(243, 128);
            this.ModeList.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.modeHelpButton);
            this.panel1.Controls.Add(this.chiperHelpButton);
            this.panel1.Controls.Add(this.OKButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 143);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(497, 34);
            this.panel1.TabIndex = 1;
            // 
            // modeHelpButton
            // 
            this.modeHelpButton.Location = new System.Drawing.Point(102, 2);
            this.modeHelpButton.Name = "modeHelpButton";
            this.modeHelpButton.Size = new System.Drawing.Size(102, 23);
            this.modeHelpButton.TabIndex = 2;
            this.modeHelpButton.Text = "Изучить режим";
            this.modeHelpButton.UseVisualStyleBackColor = true;
            this.modeHelpButton.Click += new System.EventHandler(this.modeHelpButton_Click);
            // 
            // chiperHelpButton
            // 
            this.chiperHelpButton.Location = new System.Drawing.Point(3, 2);
            this.chiperHelpButton.Name = "chiperHelpButton";
            this.chiperHelpButton.Size = new System.Drawing.Size(93, 23);
            this.chiperHelpButton.TabIndex = 1;
            this.chiperHelpButton.Text = "Изучить шифр";
            this.chiperHelpButton.UseVisualStyleBackColor = true;
            this.chiperHelpButton.Click += new System.EventHandler(this.chiperHelpButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(419, 0);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 0;
            this.OKButton.Text = "Выбрать";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // ModeCipherSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 180);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ModeCipherSelectionForm";
            this.Text = "Выбор алгоритма и режима";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ListBox CipherList;
        private System.Windows.Forms.ListBox ModeList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button modeHelpButton;
        private System.Windows.Forms.Button chiperHelpButton;
    }
}

