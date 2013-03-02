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
            //передать параметры ШИФРА и РЕЖИМА
            var title = string.Format("Шифрование/Расшифрование {0} - {1}",
                                      CipherList.SelectedItem,
                                      ModeList.SelectedItem);

            var selectedMode = ModeList.SelectedItem as BlockChiperMode;
            selectedMode.Chiper = CipherList.SelectedItem as BlockCipher;

            var cpn = new Criptonator(title, selectedMode);
            cpn.ShowDialog();
       }

    }
}
