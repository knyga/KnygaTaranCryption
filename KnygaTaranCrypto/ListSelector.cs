using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace KnygaTaranCrypto
{
    public partial class ListSelector : Form
    {
        IDictionary dict;
        object selected;

        /// <summary>
        /// Выбранный объект
        /// </summary>
        public object Selected
        {
            get { return selected; }
        }

        public ListSelector(IDictionary dict, string title, object selectedKey)
        {
            InitializeComponent();
            this.dict = dict;
            this.selected = new WeakReference(selected);

            this.Text = title;

            List<string> ls = new List<string>();
            foreach (string s in dict.Keys)
                ls.Add(s);
            ls.Sort();
            ListFull.DataSource = ls;

            if (dict.Contains(selectedKey))
            {
                ListFull.SelectedItem = selectedKey;
            }
                            
        }

        public ListSelector(IDictionary dict, string title):this(dict,title,null)
        {
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            this.selected = dict[ListFull.SelectedValue];
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
