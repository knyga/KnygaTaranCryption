using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KnygaTaranCryptoLib
{
    /// <summary>
    /// Обёртка режимов для шифров
    /// </summary>
    public abstract class BlockChiperMode: AChiper
    {
        IChiper _chiper;
        protected string _modeName;

        /// <summary>
        /// Шифр
        /// </summary>
        public IChiper Chiper
        {
            get { return _chiper; }
            set { _chiper = value; }
        }
        
        protected BlockChiperMode()
        {
            
        }

        protected BlockChiperMode(IChiper iChiper)
        {
            _chiper = iChiper;
        }

        public abstract byte[] Encrypt(byte[] data, byte[] key, byte[] IV);
        public abstract byte[] Decrypt(byte[] data, byte[] key, byte[] IV);

        /// <summary>
        /// Разбить массив байт на массивы байт фиксированной длины
        /// </summary>
        /// <param name="arr">Массив байт</param>
        /// <param name="blockLength">Длина блока</param>
        /// <returns>Разбитый массив массивов байт</returns>
        protected byte[][] SplitByteArray(byte[] arr, int blockLength)
        {
            int spArrLength = (int)Math.Ceiling((double)arr.Length / blockLength);
            byte[][] spArr = new byte[spArrLength][];

            int pos = 0;
            for (int i = 0; i < spArrLength; i++)
            {
                spArr[i] = new byte[blockLength];
                for (int j = 0; j < blockLength; j++)
                {
                    pos = i*blockLength+j;
                    spArr[i][j] = arr.Length > pos ? arr[pos] : (byte)255;
                }
            }

            return spArr;
        }

        public override string ToString()
        {
            return _modeName;
        }

    }
}
