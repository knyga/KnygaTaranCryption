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
        //Автократност
        private bool _isAutoMultiplicity = false;

	    private ModeParams _mParams;

        Dictionary<string, Encoding> encodingDict;

        public Criptonator(BlockChiperMode cipherMode)
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

            UpdateChiper(cipherMode);
        }

        private void UpdateChiper(BlockChiperMode chiperMode)
        {
            this._chiperMode = chiperMode;
            this.Text = string.Format("Шифрование/Расшифрование {0} - {1}",
                                      chiperMode.Chiper,
                                      chiperMode);
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
            EncryptEditBinary();
        }

        private DialogResult EncryptEditBinary()
        {
            DialogResult dr = default(DialogResult);
            Editor et = new Editor(encrypt.ToBitArrayString(), "Редактировать открытый текст (бинарная последовательность)", new System.Text.RegularExpressions.Regex("^[10]*$"));
            if ((dr=et.ShowDialog()) == System.Windows.Forms.DialogResult.OK)
            {
                encrypt.ReadFromBooleanText(et.EditedText);
                UpdateTextAreas();
            }
            return dr;
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
            var od = new SaveFileDialog();
            if (od.ShowDialog() == DialogResult.OK)
            {
                decrypt.WriteToFile(od.FileName);
            }
        }

        private void DecryptButton_Click(object sender, EventArgs e)
        {
            //int left = (_chiperMode.Chiper.DataBlockLength - decrypt.Data.Length % _chiperMode.Chiper.DataBlockLength) * 8;
            //Не задан ключ или инициализирующий вектор
            if (_mParams.Key.Length < 8 || _mParams.IV.Length < 8)
            {
                OptionsStripMenuItem_Click(sender, e);
                DecryptButton_Click(sender, e);
            }
            //if (!_isAutoMultiplicity && left != 0)
            //{
            //    MessageBox.Show(string.Format("Количество байт текста не кратно {0}! Добавьте {1} бит (1 или 0) или включите автократность (Правка-Автократность)",
            //        _chiperMode.Chiper.DataBlockLength,
            //        left), "Ошибка кратности", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    DecryptEditBinaryButton_Click(sender, e);
            //}
            encrypt.Data = _chiperMode.Decrypt(decrypt.Data, _mParams.Key, _mParams.IV);
            EncryptRichPreview.Text = encrypt.ToString();
        }

        private void EncryptButton_Click(object sender, EventArgs e)
        {
            int left = (_chiperMode.Chiper.DataBlockLength - encrypt.Data.Length % _chiperMode.Chiper.DataBlockLength);
            if (_chiperMode.Chiper.DataBlockLength == left)
            {
                left = 0;
            }
            left *= 8;

            //Не задан ключ или инициализирующий вектор
            if (_mParams.Key.Length < 8 || _mParams.IV.Length < 8)
            {
                OptionsStripMenuItem_Click(sender, e);
            }
            if (!_isAutoMultiplicity && left != 0)
            {
                MessageBox.Show(string.Format("Количество байт текста не кратно {0}! Добавьте {1} бит (1 или 0) или удалите {2} бит (1 или 0), или включите автократность (Правка-Автократность)",
                    _chiperMode.Chiper.DataBlockLength,
                    left,
                    _chiperMode.Chiper.DataBlockLength*8-left), "Ошибка кратности", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (EncryptEditBinary() == DialogResult.OK)
                {
                    EncryptButton_Click(sender, e);
                }
                else
                {
                    return;
                }

            }
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
            ListSelector ls = new ListSelector(this.encodingDict, "Выбор кодировки для раcшифрования", this.decrypt.Encoding.EncodingName);
            if (ls.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.decrypt.Encoding = ls.Selected as System.Text.Encoding;
                decrypt.EscapeBOM();
                UpdateTextAreas();
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void electronicCodebookECBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateChiper(new EcbMode()
            {
                Chiper = this._chiperMode.Chiper
            });
        }

        private void cipherBlockChainingCBCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateChiper(new CbcMode()
            {
                Chiper = this._chiperMode.Chiper
            });
        }

        private void cipherFeedbackCFBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateChiper(new CfbMode()
            {
                Chiper = this._chiperMode.Chiper
            });
        }

        private void outputFeedbackOFBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateChiper(new OfbMode()
            {
                Chiper = this._chiperMode.Chiper
            });
        }

        private void автократкностьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _isAutoMultiplicity = !_isAutoMultiplicity;
        }

        private void OptionsStripMenuItem_Click(object sender, EventArgs e)
        {
            var keyOptsForm = new KeyOptionsForm((_chiperMode.Chiper as BlockCipher).CipherType,_chiperMode.Chiper.DataBlockLength, _mParams);
            keyOptsForm.ShowDialog();
        }


        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //WebBrowser page?
        }

		private void msiLearnAlgorithm_Click(object sender, EventArgs e)
		{
			new WebBrowser(Properties.Resources.Learning).Show();
		}

		private void msiEncrypt_Click(object sender, EventArgs e)
		{
			new WebBrowser(Properties.Resources.Encrypt).Show();
		}

		private void msiDecrypt_Click(object sender, EventArgs e)
		{
			new WebBrowser(Properties.Resources.Decrypt).Show();
		}

		private void msiCopingWithFiles_Click(object sender, EventArgs e)
		{
			new WebBrowser(Properties.Resources.CopeWithFiles).Show();
		}

    }

    /// <summary>
    /// Местный парень?:)
    /// </summary>
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
