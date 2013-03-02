using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Windows.Forms;
using KnygaTaranCryptoLib.Ciphers;
using Org.BouncyCastle.Crypto.Engines;

namespace KnygaTaranCrypto
{
    public partial class KeyOptionsForm : Form
    {
	    private byte[] _key;
	    private byte[] _iv;

	    private ModeParams _mParams;

		public KeyOptionsForm(Type cipherType, ModeParams modeParams)
        {
            InitializeComponent();
			_mParams = modeParams;
            _iv = new byte[8];
			tbPassword.Text = _mParams.TextKey;
			tbSeed.Text = _mParams.Seed.ToString();

            //128 (blow, idea, cast)
            if (cipherType.Equals(typeof (BlowfishEngine)) || cipherType.Equals(typeof (IdeaEngine)) ||
                cipherType.Equals(typeof (Cast5Engine)))
            {
                lbKeyLength.Items.Add(new KeyLengthObject(){Length = 128});
            }
            //56 (DES)
            if (cipherType.Equals(typeof (DesEngine)))
            {
				lbKeyLength.Items.Add(new KeyLengthObject() { Length = 56 });
            }
            //168 (3DES)
            if (cipherType.Equals(typeof (DesEdeEngine)))
            {
				lbKeyLength.Items.Add(new KeyLengthObject(){Length = 168});
            }
            //256 (blow,gost)
            if (cipherType.Equals(typeof (Gost28147Engine)) || cipherType.Equals(typeof (BlowfishEngine)))
            {
				lbKeyLength.Items.Add(new KeyLengthObject(){Length = 256});
            }
			
			// select first
			lbKeyLength.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbPassword.Text.Length < 3)
            {
                MessageBox.Show("Введите минимум 3 символа для пароля", "Error");
                return;
            }

            //filling up _iv
            int seed = 0;
            try
            {
                seed = int.Parse(tbSeed.Text);
            }
            catch
            {
                seed = 0;
            }

            new Random(seed).NextBytes(_iv);

            // password
	        int bitSize = (lbKeyLength.SelectedItem as KeyLengthObject).Length;

	        var passwordAsBytes = Encoding.Default.GetBytes(tbPassword.Text);

            switch (bitSize)
            {
                case 256:
                    {
                        SHA256 sha256 = new SHA256Managed();
                        _key = sha256.ComputeHash(passwordAsBytes);
                    }
                    break;

                case 128:
                    {
                        MD5 md5 = new MD5Cng();
                        _key = md5.ComputeHash(passwordAsBytes);
                    }
                    break;
                case 168:
                    {
                        SHA1 sh1 = new SHA1Cng();
                        var tempKey = sh1.ComputeHash(passwordAsBytes).ToList();
                        tempKey.Add(255);
                        _key = tempKey.ToArray();
                    }
                    break;
                case 56:
                    {
                        var tempKey = new List<byte>();
	                    var hashBytes = BitConverter.GetBytes(tbPassword.GetHashCode());
                        tempKey.AddRange(hashBytes);
						tempKey.AddRange(hashBytes);
                        _key = tempKey.ToArray();
                    }
                    break;
            }

            MessageBox.Show("Ключ шифрования и вектор инициализации успешно изменены");

	        _mParams.Key = _key;
	        _mParams.IV = _iv;
	        _mParams.TextKey = tbPassword.Text;
	        _mParams.Seed = seed;

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

		private class KeyLengthObject
		{
			public int Length { get; set; }

			public override string ToString()
			{
				return Length + "-bit";
			}
		}
    }
}
