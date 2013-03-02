using System.Collections.Generic;

namespace KnygaTaranCryptoLib
{
    public class OfbMode : BlockChiperMode
    {
        public OfbMode()
        {
            _modeName = "Output Feedback (OFB)";
        }

        public OfbMode(IChiper iChiper) : base(iChiper)
        {
            _modeName = "Output Feedback (OFB)";
        }

        /// <summary>
        /// Зашифровать по режиму Output Feedback (OFB)
        /// </summary>
        /// <param name="data">Данные</param>
        /// <param name="key">Ключ</param>
        /// <param name="IV">Вектор инициализации</param>
        /// <returns>Зашифрованные данные</returns>
        public byte[] OFBEncrypt(byte[] data, byte[] key, byte[] IV)
        {
            byte[][] spArr = SplitByteArray(data, Chiper.DataBlockLength);
            byte[] keyEnc = new byte[data.Length];
            byte[] data2 = new byte[data.Length];
            List<byte> output = new List<byte>();
            for (int i = 0; i < spArr.GetLength(0); i++)
            {
                keyEnc = Chiper.Encrypt(i > 0 ? keyEnc : IV, key);
                data2 = XOR(spArr[i], keyEnc);
                output.AddRange(data2);
            }
            return output.ToArray();
        }

        /// <summary>
        /// Расшифровать по режиму Output Feedback
        /// </summary>
        /// <param name="data">Данные</param>
        /// <param name="key">Ключ</param>
        /// <param name="IV">Вектор инициализации</param>
        /// <returns>Зашифрованные данные</returns>
        public byte[] OFBDecrypt(byte[] data, byte[] key, byte[] IV)
        {
            byte[][] spArr = SplitByteArray(data, Chiper.DataBlockLength);
            byte[] keyEnc = new byte[data.Length];
            byte[] data2 = new byte[data.Length];
            List<byte> output = new List<byte>();
            for (int i = 0; i < spArr.GetLength(0); i++)
            {
                keyEnc = Chiper.Encrypt(i > 0 ? keyEnc : IV, key);//
                data2 = XOR(spArr[i], keyEnc);
                output.AddRange(data2);
            }
            return output.ToArray();
        }

        public override byte[] Encrypt(byte[] data, byte[] key, byte[] IV)
        {
            return this.OFBEncrypt(data, key, IV);
        }

        public override byte[] Decrypt(byte[] data, byte[] key, byte[] IV)
        {
            return this.OFBDecrypt(data, key, IV);
        }
    }
}