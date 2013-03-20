using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Windows.Forms;
using KnygaTaranCryptoLib;
using KnygaTaranCryptoLib.Ciphers;
using Org.BouncyCastle.Crypto.Engines;

namespace KnygaTaranCrypto
{
    public partial class KeyOptionsForm : Form
    {
	    private byte[] _key;
	    private byte[] _iv;

	    private ModeParams _mParams;

		public KeyOptionsForm(Type cipherType, int IVLength, ModeParams modeParams)
        {
            InitializeComponent();
			_mParams = modeParams;
            _iv = new byte[IVLength];
			tbPassword.Text = _mParams.TextKey;
			tbSeed.Text = _mParams.Seed.ToString();

            //128 (blow, idea, cast, AES)
            if (cipherType.Equals(typeof (BlowfishEngine))  ||  cipherType.Equals(typeof (IdeaEngine)) ||
                cipherType.Equals(typeof (Cast5Engine))     ||  cipherType.Equals(typeof (AesEngine)))
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
            //256 (blow,gost,AES)
            if (cipherType.Equals(typeof (Gost28147Engine)) || cipherType.Equals(typeof (BlowfishEngine)) ||
                cipherType.Equals(typeof (AesEngine)))
            {
				lbKeyLength.Items.Add(new KeyLengthObject(){Length = 256});
            }
			
			// select first
			lbKeyLength.SelectedIndex = 0;
        }

        //!!!!!WARNING!!!!!
        //The specified cryptographic algorithm is not supported on this platform.
        //http://social.msdn.microsoft.com/Forums/en-US/csharplanguage/thread/04328b17-aeea-439a-9574-e6e0a7ce8040/
        //!!!!!WARNING!!!!!
        //На XP не будут работать алгоритмы хэширования эти, нужно что-то другое для получения дайжеста использовать или в Кастеле поискать
        //Может SHA-3 подойдет? Там длина динамическая, хватит одного алгоритма на все случаи
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
						MD5 md5 = new MD5CryptoServiceProvider();
                        _key = md5.ComputeHash(passwordAsBytes);
                    }
                    break;
                case 168:
                    {
                        SHA1 sh1 = new SHA1Managed();
                        var tempKey = sh1.ComputeHash(passwordAsBytes).ToList();
                        tempKey.Add(255);
                        _key = tempKey.ToArray();
                    }
                    break;
                case 56:
                    {
                        var tempKey = new List<byte>();
	                    var hashBytes = BitConverter.GetBytes(tbPassword.GetHashCode());
                        //?? :) 32*2 
						// - надо ж 64 бита где-то взять
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

		private void btnEditIvBitSequence_Click(object sender, EventArgs e)
		{
			new Random(int.Parse(tbSeed.Text)).NextBytes(_iv);
			var ivData = new Data100(_iv);

			var editor = new Editor(ivData.ToBitArrayString(),"IV");
			editor.ReadOnly = true;
			editor.ShowDialog();
		}

    }
}
