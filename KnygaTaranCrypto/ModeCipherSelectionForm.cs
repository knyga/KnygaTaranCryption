using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KnygaTaranCryptoLib;
using KnygaTaranCryptoLib.Ciphers;
using Org.BouncyCastle.Crypto.Engines;

namespace KnygaTaranCrypto
{
    public partial class ModeCipherSelectionForm : Form
    {
      
        public ModeCipherSelectionForm()
        {
            InitializeComponent();

            var _blockCiphers = new[]
                {
                    new BlockCipher(new AesEngine()),
                    new BlockCipher(new BlowfishEngine()),
                    new BlockCipher(new DesEdeEngine()),
                    new BlockCipher(new IdeaEngine()),
                    new BlockCipher(new Cast5Engine()),
                    new BlockCipher(new Gost28147Engine()),
                    new BlockCipher(new DesEngine())
                };

            var _cipherModes = new BlockChiperMode[]
                {
                    new CbcMode(),
                    new CfbMode(),
                    new EcbMode(),
                    new OfbMode()
                };

            CipherList.Items.AddRange(_blockCiphers);
            ModeList.Items.AddRange(_cipherModes);

            CipherList.SelectedIndex = 0;
            ModeList.SelectedIndex = 0;
        }



        private void OKButton_Click(object sender, EventArgs e)
        {
            var selectedMode = ModeList.SelectedItem as BlockChiperMode;
            selectedMode.Chiper = CipherList.SelectedItem as BlockCipher;

            var cpn = new Criptonator(selectedMode);
            cpn.Show();
       }

        private void chiperHelpButton_Click(object sender, EventArgs e)
        {
            //как в modeHelpButton_Click
            //смотри /Pages
        }

        private void modeHelpButton_Click(object sender, EventArgs e)
        {
            BlockChiperMode mode = ModeList.SelectedItem as BlockChiperMode;
            Type modesType = mode.GetType();
            string page = string.Empty;

            //Все страницы нужно сначала добавить в список ресурсов проекта
            //Ветвление на отрисовку
            if(modesType.Equals(typeof(CbcMode))) {
                page = Properties.Resources.CBCMode;
            } else if(modesType.Equals(typeof(CfbMode))) {
                page = Properties.Resources.CFBMode;
            } else if(modesType.Equals(typeof(EcbMode))) {
                page = Properties.Resources.ECBMode;
            } else if(modesType.Equals(typeof(OfbMode))) {
                page = Properties.Resources.OFBMode;
            };

            new WebBrowser(page).Show();
        }

    }
}
