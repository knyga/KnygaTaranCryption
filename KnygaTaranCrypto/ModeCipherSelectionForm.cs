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
	        BlockCipher blockCipher = CipherList.SelectedItem as BlockCipher;
	        Type cipherType = blockCipher.CipherType;
	        string page = null;

	        if (cipherType.Equals(typeof (AesEngine)))
		        page = Properties.Resources.AES;
	        if (cipherType.Equals(typeof (BlowfishEngine)))
		        page = Properties.Resources.BlowFish;
	        if (cipherType.Equals(typeof(DesEdeEngine)))
		        page = Properties.Resources.TrippleDES;
	        if (cipherType.Equals(typeof (IdeaEngine)))
		        page = Properties.Resources.IDEA;
	        if (cipherType.Equals(typeof (Cast5Engine)))
		        page = Properties.Resources.CAST;
	        if (cipherType.Equals(typeof (Gost28147Engine)))
		        page = Properties.Resources.GOST28147;
	        if (cipherType.Equals(typeof (DesEngine)))
		        page = Properties.Resources.DES;
			
			new WebBrowser(page).Show();
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
