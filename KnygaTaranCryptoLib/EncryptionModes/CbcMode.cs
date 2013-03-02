using System.Collections.Generic;

namespace KnygaTaranCryptoLib
{
    public class CbcMode : BlockChiperMode
    {
        public CbcMode()
        {
            _modeName = "Cipher Block Chaining (CBC)";
        }

        public CbcMode(IChiper iChiper) : base(iChiper)
        {
            _modeName = "Cipher Block Chaining (CBC)";
        }

        /// <summary>
        /// Зашифровать по режиму Cipher Block Chaining (CBC)
        /// </summary>
        /// <param name="data">Данные</param>
        /// <param name="key">Ключ</param>
        /// <param name="IV">Вектор инициализации</param>
        /// <returns>Зашифрованные данные</returns>
        private byte[] CBCEncrypt(byte[] data, byte[] key, byte[] IV)
        {
            byte[][] spArr = SplitByteArray(data, this.Chiper.DataBlockLength);
            byte[] data2 = new byte[data.Length];
            byte[] enc = new byte[data.Length];
            List<byte> output = new List<byte>();
            for (int i = 0; i < spArr.GetLength(0); i++)
            {
                data2 = XOR(spArr[i], IV);
                enc = Chiper.Encrypt(data2, key);
                output.AddRange(enc);
                IV = enc;
            }
            return output.ToArray();
        }

        /// <summary>
        /// Расшифровать по режиму Cipher Block Chaining
        /// </summary>
        /// <param name="data">Данные</param>
        /// <param name="key">Ключ</param>
        /// <param name="IV">Вектор инициализации</param>
        /// <returns>Зашифрованные данные</returns>
        private byte[] CBCDecrypt(byte[] data, byte[] key, byte[] IV)
        {
            byte[][] spArr = SplitByteArray(data, Chiper.DataBlockLength);
            byte[] data2 = new byte[data.Length];
            byte[] denc = new byte[data.Length];
            List<byte> output = new List<byte>();
            for (int i = spArr.GetLength(0)-1; i >=0 ; i--)
            {
                denc = Chiper.Decrypt(spArr[i], key);
                data2 = XOR(denc, i > 0 ? spArr[i - 1] : IV);
                output.InsertRange(0, data2);
            }
            return output.ToArray();
        }

        public override byte[] Encrypt(byte[] data, byte[] key, byte[] IV)
        {
            return this.CBCEncrypt(data, key, IV);
        }

        public override byte[] Decrypt(byte[] data, byte[] key, byte[] IV)
        {
            return this.CBCDecrypt(data, key, IV);
        }
    }
}