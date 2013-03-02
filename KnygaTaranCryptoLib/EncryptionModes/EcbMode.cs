using System.Collections.Generic;

namespace KnygaTaranCryptoLib
{
    public class EcbMode : BlockChiperMode
    {
        public EcbMode()
        {
            _modeName = "Electronic Codebook (ECB)";
        }

        public EcbMode(IChiper iChiper) : base(iChiper)
        {
            _modeName = "Electronic Codebook (ECB)";
        }

        /// <summary>
        /// Зашифровать по режиму Electronic Codebook (ECB)
        /// </summary>
        /// <param name="data">Данные</param>
        /// <param name="key">Ключ</param>
        /// <returns>Зашифрованные данные</returns>
        public byte[] ECBEncrypt(byte[] data, byte[] key)
        {
            byte[][] spArr = SplitByteArray(data, Chiper.DataBlockLength);
            List<byte> output = new List<byte>();
            for (int i = 0; i < spArr.GetLength(0); i++)
            {
                output.AddRange(Chiper.Encrypt(spArr[i], key));
            }
            return output.ToArray();
        }

        /// <summary>
        /// Расшифровать по режиму Electronic Codebook (ECB)
        /// </summary> 
        /// <param name="data">Данные</param>
        /// <param name="key">Ключ</param>
        /// <returns>Зашифрованные данные</returns>
        public byte[] ECBDecrypt(byte[] data, byte[] key)
        {
            byte[][] spArr = SplitByteArray(data, Chiper.DataBlockLength);
            List<byte> output = new List<byte>();
            for (int i = 0; i < spArr.GetLength(0); i++)
            {
                output.AddRange(Chiper.Decrypt(spArr[i], key));
            }
            return output.ToArray();
        }

        public override byte[] Encrypt(byte[] data, byte[] key, byte[] IV)
        {
            return this.ECBEncrypt(data, key);
        }

        public override byte[] Decrypt(byte[] data, byte[] key, byte[] IV)
        {
            return this.ECBDecrypt(data, key);
        }
    }
}