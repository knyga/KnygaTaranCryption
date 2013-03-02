using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KnygaTaranCryptoLib;
using System.Diagnostics;
using KnygaTaranCryptoLib.Ciphers;

namespace KnygaTaranCrypto
{
    public partial class Criptonator : Form
    {
        private Data100 encrypt;
        private Data100 decrypt;
        private BlockChiperMode _chiperMode;

	    private ModeParams _mParams;

        Dictionary<string, Encoding> encodingDict;

        public Criptonator(string title, BlockChiperMode cipherMode)
        {
            InitializeComponent();
            encrypt = new Data100();
            decrypt = new Data100();

			_mParams = new ModeParams();

            this.encodingDict = new Dictionary<string, Encoding>(){
                {Encoding.ASCII.EncodingName, Encoding.ASCII},
                {Encoding.BigEndianUnicode.EncodingName, Encoding.BigEndianUnicode},
                {Encoding.Default.EncodingName, Encoding.Default},
                {Encoding.UTF8.EncodingName, Encoding.UTF8},
                {Encoding.UTF32.EncodingName, Encoding.UTF32},
                {Encoding.Unicode.EncodingName, Encoding.Unicode},
            };

            this.Text = title;
            _chiperMode = cipherMode;
        }

        private void UpdateTextAreas()
        {
            DecryptRichPreview.Text = decrypt.ToString();
            EncryptRichPreview.Text = encrypt.ToString();
        }

        private void EncryptOpenFileButton_Click(object sender, EventArgs e)
        {
            var od = new OpenFileDialog();
            if (od.ShowDialog() == DialogResult.OK)
            {
                encrypt.ReadFromFile(od.FileName);
                encrypt.EscapeBOM();
                UpdateTextAreas();
            }
        }

        private void EncryptWatchFileButton_Click(object sender, EventArgs e)
        {
            var od = new OpenFileDialog();
            if (od.ShowDialog() == DialogResult.OK)
            {
                Process.Start(od.FileName);
            }
        }

        private void EncryptToDecryptButton_Click(object sender, EventArgs e)
        {
            //decrypt = encrypt;
	        decrypt.Data = encrypt.Data;
			UpdateTextAreas();
        }

        private void EncryptEditTextButton_Click(object sender, EventArgs e)
        {
            Editor et = new Editor(encrypt.ToString(), "Редактировать открытый текст");
            if (et.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                encrypt.ReadFromText(et.EditedText);
                UpdateTextAreas(); 
            }
        }

        private void EncryptEditBinaryButton_Click(object sender, EventArgs e)
        {
            Editor et = new Editor(encrypt.ToBitArrayString(), "Редактировать открытый текст (бинарная последовательность)", new System.Text.RegularExpressions.Regex("^[10]*$"));
            if (et.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                encrypt.ReadFromBooleanText(et.EditedText);
                UpdateTextAreas();
            }
        }



        private void EncryptSaveToFileButton_Click(object sender, EventArgs e)
        {
            var od = new SaveFileDialog();
            if (od.ShowDialog() == DialogResult.OK)
            {
                encrypt.WriteToFile(od.FileName);
                MessageBox.Show("Файл успешно сохранен", "Success");
            }
        }

        private void DecryptOpenFileButton_Click(object sender, EventArgs e)
        {
            var od = new OpenFileDialog();
            if (od.ShowDialog() == DialogResult.OK)
            {
                decrypt.ReadFromFile(od.FileName);
                decrypt.EscapeBOM();
                UpdateTextAreas();
            }
        }

        private void DecryptWatchFileButton_Click(object sender, EventArgs e)
        {
            var od = new OpenFileDialog();
            if (od.ShowDialog() == DialogResult.OK)
            {
                Process.Start(od.FileName);
            }
        }

        private void DecryptToEncryptButton_Click(object sender, EventArgs e)
        {
            encrypt.Data = decrypt.Data;
            UpdateTextAreas();
        }

        private void DecryptEditTextButton_Click(object sender, EventArgs e)
        {
            Editor et = new Editor(decrypt.ToString(), "Редактировать закрытый текст");
            if (et.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                decrypt.ReadFromText(et.EditedText);
                UpdateTextAreas();
            }
        }

        private void DecryptEditBinaryButton_Click(object sender, EventArgs e)
        {
            Editor et = new Editor(decrypt.ToBitArrayString(), "Редактировать закрытый текст (бинарная последовательность)", new System.Text.RegularExpressions.Regex("^[10]*$"));
            if (et.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                decrypt.ReadFromBooleanText(et.EditedText);
                UpdateTextAreas();
            }
        }

        private void DecryptSaveFileButton_Click(object sender, EventArgs e)
        {
            var od = new OpenFileDialog();
            if (od.ShowDialog() == DialogResult.OK)
            {
                decrypt.WriteToFile(od.FileName);
            }
        }

        private void DecryptButton_Click(object sender, EventArgs e)
        {
            encrypt.Data = _chiperMode.Decrypt(decrypt.Data, _mParams.Key, _mParams.IV);
            EncryptRichPreview.Text = encrypt.ToString();
        }

        private void EncryptButton_Click(object sender, EventArgs e)
        {
            decrypt.Data = _chiperMode.Encrypt(encrypt.Data, _mParams.Key, _mParams.IV);
            DecryptRichPreview.Text = decrypt.ToString();
        }

        private void EncryptEncodingButton_Click(object sender, EventArgs e)
        {
            ListSelector ls = new ListSelector(this.encodingDict, "Выбор кодировки для шифрования", this.encrypt.Encoding.EncodingName);
            if (ls.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.encrypt.Encoding = ls.Selected as System.Text.Encoding;
                encrypt.EscapeBOM();
                UpdateTextAreas();
            }
        }

        private void DecryptEncodingButton_Click(object sender, EventArgs e)
        {
            ListSelector ls = new ListSelector(this.encodingDict, "Выбор кодировки для разшифрования", this.decrypt.Encoding.EncodingName);
            if (ls.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.decrypt.Encoding = ls.Selected as System.Text.Encoding;
                decrypt.EscapeBOM();
                UpdateTextAreas();
            }
        }

        private void btnKeyOptions_Click(object sender, EventArgs e)
        {
            var keyOptsForm = new KeyOptionsForm((_chiperMode.Chiper as BlockCipher).CipherType, _mParams);
            keyOptsForm.ShowDialog();
        }
    }

	public class ModeParams
	{
		public byte[] Key { get; set; }
		public byte[] IV { get; set; }

		public string TextKey { get; set; }
		public int Seed { get; set; }

		public ModeParams()
		{
			Seed = 0;
			TextKey = "";
			Key = new byte[1];
			IV = new byte[1];
		}
	}
}
