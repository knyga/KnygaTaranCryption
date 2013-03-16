using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using mshtml;

namespace KnygaTaranCrypto
{
    public partial class WebBrowser : Form
    {
        private string _basicCSS = @"
    /** {padding: 0; margin: 0}*/
    body {overflow:none}
    img {width: 100%}
";

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="context">Содержимое страницы <html>...</html> </param>
        public WebBrowser(string context)
        {
            InitializeComponent();
            _webBrowser.DocumentText = context;
        }

        /// <summary>
        /// Добавляет пользовательские стили
        /// </summary>
        /// <param name="style">Пользовательский css стиль</param>
        private void AddStyle(string style)
        {
            if (_webBrowser.Document != null)
            {
                IHTMLDocument2 doc = (_webBrowser.Document.DomDocument) as IHTMLDocument2;
                IHTMLStyleSheet ss = doc.createStyleSheet("", 0);
                ss.cssText = style;

            }
        }

        private void _webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.Text = _webBrowser.Document.Title;
            AddStyle(this._basicCSS);
        }
    }
}
