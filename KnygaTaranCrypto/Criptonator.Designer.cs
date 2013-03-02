﻿namespace KnygaTaranCrypto
{
    partial class Criptonator
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.EncryptEncodingButton = new System.Windows.Forms.Button();
            this.EncryptToDecryptButton = new System.Windows.Forms.Button();
            this.EncryptWatchFileButton = new System.Windows.Forms.Button();
            this.EncryptRichPreview = new System.Windows.Forms.RichTextBox();
            this.EncryptButton = new System.Windows.Forms.Button();
            this.EncryptEditBinaryButton = new System.Windows.Forms.Button();
            this.EncryptEditTextButton = new System.Windows.Forms.Button();
            this.EncryptSaveToFileButton = new System.Windows.Forms.Button();
            this.EncryptOpenFileButton = new System.Windows.Forms.Button();
            this.EncryptLabel = new System.Windows.Forms.Label();
            this.DecryptEditBinaryButton = new System.Windows.Forms.Button();
            this.DecryptEditTextButton = new System.Windows.Forms.Button();
            this.DecryptSaveFileButton = new System.Windows.Forms.Button();
            this.DecryptOpenFileButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.DecryptWatchFileButton = new System.Windows.Forms.Button();
            this.DecryptButton = new System.Windows.Forms.Button();
            this.DecryptRichPreview = new System.Windows.Forms.RichTextBox();
            this.DecryptToEncryptButton = new System.Windows.Forms.Button();
            this.DecryptEncodingButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnKeyOptions = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(961, 529);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnKeyOptions);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.EncryptEncodingButton);
            this.panel1.Controls.Add(this.EncryptToDecryptButton);
            this.panel1.Controls.Add(this.EncryptWatchFileButton);
            this.panel1.Controls.Add(this.EncryptRichPreview);
            this.panel1.Controls.Add(this.EncryptButton);
            this.panel1.Controls.Add(this.EncryptEditBinaryButton);
            this.panel1.Controls.Add(this.EncryptEditTextButton);
            this.panel1.Controls.Add(this.EncryptSaveToFileButton);
            this.panel1.Controls.Add(this.EncryptOpenFileButton);
            this.panel1.Controls.Add(this.EncryptLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(955, 258);
            this.panel1.TabIndex = 0;
            // 
            // EncryptEncodingButton
            // 
            this.EncryptEncodingButton.Location = new System.Drawing.Point(37, 33);
            this.EncryptEncodingButton.Name = "EncryptEncodingButton";
            this.EncryptEncodingButton.Size = new System.Drawing.Size(93, 34);
            this.EncryptEncodingButton.TabIndex = 10;
            this.EncryptEncodingButton.Text = "Кодировка";
            this.EncryptEncodingButton.UseVisualStyleBackColor = true;
            this.EncryptEncodingButton.Click += new System.EventHandler(this.EncryptEncodingButton_Click);
            // 
            // EncryptToDecryptButton
            // 
            this.EncryptToDecryptButton.Location = new System.Drawing.Point(369, 33);
            this.EncryptToDecryptButton.Name = "EncryptToDecryptButton";
            this.EncryptToDecryptButton.Size = new System.Drawing.Size(93, 34);
            this.EncryptToDecryptButton.TabIndex = 9;
            this.EncryptToDecryptButton.Text = "В расшифровку";
            this.EncryptToDecryptButton.UseVisualStyleBackColor = true;
            this.EncryptToDecryptButton.Click += new System.EventHandler(this.EncryptToDecryptButton_Click);
            // 
            // EncryptWatchFileButton
            // 
            this.EncryptWatchFileButton.Location = new System.Drawing.Point(256, 33);
            this.EncryptWatchFileButton.Name = "EncryptWatchFileButton";
            this.EncryptWatchFileButton.Size = new System.Drawing.Size(93, 34);
            this.EncryptWatchFileButton.TabIndex = 8;
            this.EncryptWatchFileButton.Text = "Просмотр файла";
            this.EncryptWatchFileButton.UseVisualStyleBackColor = true;
            this.EncryptWatchFileButton.Click += new System.EventHandler(this.EncryptWatchFileButton_Click);
            // 
            // EncryptRichPreview
            // 
            this.EncryptRichPreview.Location = new System.Drawing.Point(14, 86);
            this.EncryptRichPreview.Name = "EncryptRichPreview";
            this.EncryptRichPreview.ReadOnly = true;
            this.EncryptRichPreview.Size = new System.Drawing.Size(932, 128);
            this.EncryptRichPreview.TabIndex = 7;
            this.EncryptRichPreview.Text = "";
            // 
            // EncryptButton
            // 
            this.EncryptButton.Location = new System.Drawing.Point(23, 220);
            this.EncryptButton.Name = "EncryptButton";
            this.EncryptButton.Size = new System.Drawing.Size(923, 26);
            this.EncryptButton.TabIndex = 6;
            this.EncryptButton.Text = "Зашифровать";
            this.EncryptButton.UseVisualStyleBackColor = true;
            this.EncryptButton.Click += new System.EventHandler(this.EncryptButton_Click);
            // 
            // EncryptEditBinaryButton
            // 
            this.EncryptEditBinaryButton.Location = new System.Drawing.Point(595, 33);
            this.EncryptEditBinaryButton.Name = "EncryptEditBinaryButton";
            this.EncryptEditBinaryButton.Size = new System.Drawing.Size(93, 34);
            this.EncryptEditBinaryButton.TabIndex = 5;
            this.EncryptEditBinaryButton.Text = "Редактировать бинарно";
            this.EncryptEditBinaryButton.UseVisualStyleBackColor = true;
            this.EncryptEditBinaryButton.Click += new System.EventHandler(this.EncryptEditBinaryButton_Click);
            // 
            // EncryptEditTextButton
            // 
            this.EncryptEditTextButton.Location = new System.Drawing.Point(482, 33);
            this.EncryptEditTextButton.Name = "EncryptEditTextButton";
            this.EncryptEditTextButton.Size = new System.Drawing.Size(93, 34);
            this.EncryptEditTextButton.TabIndex = 4;
            this.EncryptEditTextButton.Text = "Редактировать текстово";
            this.EncryptEditTextButton.UseVisualStyleBackColor = true;
            this.EncryptEditTextButton.Click += new System.EventHandler(this.EncryptEditTextButton_Click);
            // 
            // EncryptSaveToFileButton
            // 
            this.EncryptSaveToFileButton.Location = new System.Drawing.Point(708, 33);
            this.EncryptSaveToFileButton.Name = "EncryptSaveToFileButton";
            this.EncryptSaveToFileButton.Size = new System.Drawing.Size(91, 34);
            this.EncryptSaveToFileButton.TabIndex = 3;
            this.EncryptSaveToFileButton.Text = "Сохранить в файл";
            this.EncryptSaveToFileButton.UseVisualStyleBackColor = true;
            this.EncryptSaveToFileButton.Click += new System.EventHandler(this.EncryptSaveToFileButton_Click);
            // 
            // EncryptOpenFileButton
            // 
            this.EncryptOpenFileButton.Location = new System.Drawing.Point(143, 33);
            this.EncryptOpenFileButton.Name = "EncryptOpenFileButton";
            this.EncryptOpenFileButton.Size = new System.Drawing.Size(93, 34);
            this.EncryptOpenFileButton.TabIndex = 2;
            this.EncryptOpenFileButton.Text = "Открыть файл";
            this.EncryptOpenFileButton.UseVisualStyleBackColor = true;
            this.EncryptOpenFileButton.Click += new System.EventHandler(this.EncryptOpenFileButton_Click);
            // 
            // EncryptLabel
            // 
            this.EncryptLabel.AutoSize = true;
            this.EncryptLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EncryptLabel.Location = new System.Drawing.Point(425, 6);
            this.EncryptLabel.Name = "EncryptLabel";
            this.EncryptLabel.Size = new System.Drawing.Size(120, 20);
            this.EncryptLabel.TabIndex = 0;
            this.EncryptLabel.Text = "Зашифровать";
            // 
            // DecryptEditBinaryButton
            // 
            this.DecryptEditBinaryButton.Location = new System.Drawing.Point(655, 42);
            this.DecryptEditBinaryButton.Name = "DecryptEditBinaryButton";
            this.DecryptEditBinaryButton.Size = new System.Drawing.Size(93, 34);
            this.DecryptEditBinaryButton.TabIndex = 14;
            this.DecryptEditBinaryButton.Text = "Редактировать бинарно";
            this.DecryptEditBinaryButton.UseVisualStyleBackColor = true;
            this.DecryptEditBinaryButton.Click += new System.EventHandler(this.DecryptEditBinaryButton_Click);
            // 
            // DecryptEditTextButton
            // 
            this.DecryptEditTextButton.Location = new System.Drawing.Point(542, 42);
            this.DecryptEditTextButton.Name = "DecryptEditTextButton";
            this.DecryptEditTextButton.Size = new System.Drawing.Size(93, 34);
            this.DecryptEditTextButton.TabIndex = 13;
            this.DecryptEditTextButton.Text = "Редактировать текстово";
            this.DecryptEditTextButton.UseVisualStyleBackColor = true;
            this.DecryptEditTextButton.Click += new System.EventHandler(this.DecryptEditTextButton_Click);
            // 
            // DecryptSaveFileButton
            // 
            this.DecryptSaveFileButton.Location = new System.Drawing.Point(768, 42);
            this.DecryptSaveFileButton.Name = "DecryptSaveFileButton";
            this.DecryptSaveFileButton.Size = new System.Drawing.Size(91, 34);
            this.DecryptSaveFileButton.TabIndex = 12;
            this.DecryptSaveFileButton.Text = "Сохранить в файл";
            this.DecryptSaveFileButton.UseVisualStyleBackColor = true;
            this.DecryptSaveFileButton.Click += new System.EventHandler(this.DecryptSaveFileButton_Click);
            // 
            // DecryptOpenFileButton
            // 
            this.DecryptOpenFileButton.Location = new System.Drawing.Point(203, 42);
            this.DecryptOpenFileButton.Name = "DecryptOpenFileButton";
            this.DecryptOpenFileButton.Size = new System.Drawing.Size(93, 34);
            this.DecryptOpenFileButton.TabIndex = 11;
            this.DecryptOpenFileButton.Text = "Открыть файл";
            this.DecryptOpenFileButton.UseVisualStyleBackColor = true;
            this.DecryptOpenFileButton.Click += new System.EventHandler(this.DecryptOpenFileButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(425, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Расшифровать";
            // 
            // DecryptWatchFileButton
            // 
            this.DecryptWatchFileButton.Location = new System.Drawing.Point(316, 42);
            this.DecryptWatchFileButton.Name = "DecryptWatchFileButton";
            this.DecryptWatchFileButton.Size = new System.Drawing.Size(93, 34);
            this.DecryptWatchFileButton.TabIndex = 17;
            this.DecryptWatchFileButton.Text = "Просмотр файла";
            this.DecryptWatchFileButton.UseVisualStyleBackColor = true;
            this.DecryptWatchFileButton.Click += new System.EventHandler(this.DecryptWatchFileButton_Click);
            // 
            // DecryptButton
            // 
            this.DecryptButton.Location = new System.Drawing.Point(14, 224);
            this.DecryptButton.Name = "DecryptButton";
            this.DecryptButton.Size = new System.Drawing.Size(923, 26);
            this.DecryptButton.TabIndex = 15;
            this.DecryptButton.Text = "Расшифровать";
            this.DecryptButton.UseVisualStyleBackColor = true;
            this.DecryptButton.Click += new System.EventHandler(this.DecryptButton_Click);
            // 
            // DecryptRichPreview
            // 
            this.DecryptRichPreview.Location = new System.Drawing.Point(14, 95);
            this.DecryptRichPreview.Name = "DecryptRichPreview";
            this.DecryptRichPreview.ReadOnly = true;
            this.DecryptRichPreview.Size = new System.Drawing.Size(932, 123);
            this.DecryptRichPreview.TabIndex = 16;
            this.DecryptRichPreview.Text = "";
            // 
            // DecryptToEncryptButton
            // 
            this.DecryptToEncryptButton.Location = new System.Drawing.Point(429, 42);
            this.DecryptToEncryptButton.Name = "DecryptToEncryptButton";
            this.DecryptToEncryptButton.Size = new System.Drawing.Size(93, 34);
            this.DecryptToEncryptButton.TabIndex = 18;
            this.DecryptToEncryptButton.Text = "В зашифровку";
            this.DecryptToEncryptButton.UseVisualStyleBackColor = true;
            this.DecryptToEncryptButton.Click += new System.EventHandler(this.DecryptToEncryptButton_Click);
            // 
            // DecryptEncodingButton
            // 
            this.DecryptEncodingButton.Location = new System.Drawing.Point(97, 42);
            this.DecryptEncodingButton.Name = "DecryptEncodingButton";
            this.DecryptEncodingButton.Size = new System.Drawing.Size(93, 34);
            this.DecryptEncodingButton.TabIndex = 19;
            this.DecryptEncodingButton.Text = "Кодировка";
            this.DecryptEncodingButton.UseVisualStyleBackColor = true;
            this.DecryptEncodingButton.Click += new System.EventHandler(this.DecryptEncodingButton_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.DecryptEncodingButton);
            this.panel2.Controls.Add(this.DecryptToEncryptButton);
            this.panel2.Controls.Add(this.DecryptRichPreview);
            this.panel2.Controls.Add(this.DecryptButton);
            this.panel2.Controls.Add(this.DecryptWatchFileButton);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.DecryptOpenFileButton);
            this.panel2.Controls.Add(this.DecryptSaveFileButton);
            this.panel2.Controls.Add(this.DecryptEditTextButton);
            this.panel2.Controls.Add(this.DecryptEditBinaryButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 267);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(955, 259);
            this.panel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Открытый текст:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Зашифрованный текст:";
            // 
            // btnKeyOptions
            // 
            this.btnKeyOptions.Location = new System.Drawing.Point(825, 33);
            this.btnKeyOptions.Name = "btnKeyOptions";
            this.btnKeyOptions.Size = new System.Drawing.Size(87, 34);
            this.btnKeyOptions.TabIndex = 12;
            this.btnKeyOptions.Text = "Выбор ключа";
            this.btnKeyOptions.UseVisualStyleBackColor = true;
            this.btnKeyOptions.Click += new System.EventHandler(this.btnKeyOptions_Click);
            // 
            // Criptonator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 529);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Criptonator";
            this.Text = "Шифрование/Расшифрование";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label EncryptLabel;
        private System.Windows.Forms.Button EncryptEditBinaryButton;
        private System.Windows.Forms.Button EncryptEditTextButton;
        private System.Windows.Forms.Button EncryptSaveToFileButton;
        private System.Windows.Forms.Button EncryptOpenFileButton;
        private System.Windows.Forms.RichTextBox EncryptRichPreview;
        private System.Windows.Forms.Button EncryptButton;
        private System.Windows.Forms.Button EncryptWatchFileButton;
        private System.Windows.Forms.Button EncryptToDecryptButton;
        private System.Windows.Forms.Button EncryptEncodingButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button DecryptEncodingButton;
        private System.Windows.Forms.Button DecryptToEncryptButton;
        private System.Windows.Forms.RichTextBox DecryptRichPreview;
        private System.Windows.Forms.Button DecryptButton;
        private System.Windows.Forms.Button DecryptWatchFileButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button DecryptOpenFileButton;
        private System.Windows.Forms.Button DecryptSaveFileButton;
        private System.Windows.Forms.Button DecryptEditTextButton;
        private System.Windows.Forms.Button DecryptEditBinaryButton;
        private System.Windows.Forms.Button btnKeyOptions;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}