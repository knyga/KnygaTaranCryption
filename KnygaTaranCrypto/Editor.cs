using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace KnygaTaranCrypto
{
    public partial class Editor : Form
    {
        string prev;
        /// <summary>
        /// Текст из блока редактирования
        /// </summary>
        public string EditedText
        {
            get { return this.MainTextBox.Text; }
            set { this.MainTextBox.Text = value; }
        }

        Regex pattern;

        public Editor(string text, string title, Regex pattern)
        {
            InitializeComponent();
            this.Text = title;
            prev = text;
            this.MainTextBox.Text = text;
            this.pattern = pattern;
        }

        public Editor(string text, string title)
            : this(text, title, new Regex(".+"))
        { }

        private void OKButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            this.MainTextBox.Clear();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void MainTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!pattern.IsMatch(EditedText) && !String.IsNullOrEmpty(EditedText))
            {
                EditedText = prev;
                MessageBox.Show("Были введены недопустимые символы", "Ошибка");
            }
            else
            {
                prev = EditedText;
            }
        }

		private void UpdateReadOnly(bool state)
		{
			    OKButton.Enabled = !state;
			    ClearButton.Enabled = !state;
			    MainTextBox.ReadOnly = state;
		}

	    public bool ReadOnly
	    {
			get { return MainTextBox.ReadOnly; }
		    set { UpdateReadOnly(value); }
	    }

    }
}
