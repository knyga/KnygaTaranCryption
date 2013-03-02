using System.Collections.Generic;

namespace KnygaTaranCryptoLib
{
    public class CfbMode : BlockChiperMode
    {
        public CfbMode()
        {
            _modeName = "Cipher Feedback (CFB)";
        }

        public CfbMode(IChiper iChiper) : base(iChiper)
        {
            _modeName = "Cipher Feedback (CFB)";
        }

        /// <summary>
        /// Зашифровать по режиму Cipher Feedback (CFB)
        /// </summary>
        /// <param name="data">Данные</param>
        /// <param name="key">Ключ</param>
        /// <param name="IV">Вектор инициализации</param>
        /// <returns>Зашифрованные данные</returns>
        public byte[] CFBEncrypt(byte[] data, byte[] key, byte[] IV)
        {
            byte[][] spArr = SplitByteArray(data, Chiper.DataBlockLength);
            byte[] keyEnc = new byte[data.Length];
            byte[] data2 = new byte[data.Length];
            List<byte> output = new List<byte>();
            for (int i = 0; i < spArr.GetLength(0); i++)
            {
                keyEnc = Chiper.Encrypt(i>0?data2:IV, key);
                data2 = XOR(spArr[i], keyEnc);
                output.AddRange(data2);
            }
            return output.ToArray();
        }

        /// <summary>
        /// Расшифровать по режиму Cipher Feedback
        /// </summary>
        /// <param name="data">Данные</param>
        /// <param name="key">Ключ</param>
        /// <param name="IV">Вектор инициализации</param>
        /// <returns>Зашифрованные данные</returns>
        public byte[] CFBDecrypt(byte[] data, byte[] key, byte[] IV)
        {
            byte[][] spArr = SplitByteArray(data, Chiper.DataBlockLength);
            byte[] keyEnc = new byte[data.Length];
            byte[] data2 = new byte[data.Length];
            List<byte> output = new List<byte>();
            for (int i = spArr.GetLength(0) - 1; i >= 0; i--)
            {
                data2 = XOR(spArr[i], Chiper.Encrypt(i>0?spArr[i-1]:IV,key));
                output.InsertRange(0, data2);
            }
            return output.ToArray();
        }

        public override byte[] Encrypt(byte[] data, byte[] key, byte[] IV)
        {
            return this.CFBEncrypt(data, key, IV);
        }

        public override byte[] Decrypt(byte[] data, byte[] key, byte[] IV)
        {
            return this.CFBDecrypt(data, key, IV);
        }
    }
}