using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KnygaTaranCryptoLib
{
    /// <summary>
    /// Пример реализации
    /// </summary>
    public class ConcretChiper : AChiper, IChiper
    {
        int dataBlockLength = 64;

        public int DataBlockLength
        {
            get { return dataBlockLength; }
        }

        public byte[] Encrypt(byte[] data, byte[] key)
        {
            byte[] data2 = new byte[data.Length];
            data.CopyTo(data2, 0);
            for (int i = 0; i < data2.Length; i++)
                data2[i] = (byte)(data2[i] - key[i]/2);
            return data2;
           // return this.XOR(data, key);
        }

        public byte[] Decrypt(byte[] data, byte[] key)
        {
            byte[] data2 = new byte[data.Length];
            data.CopyTo(data2, 0);
            for (int i = 0; i < data2.Length; i++)
                data2[i] = (byte)(data2[i] + key[i] / 2);
            return data2;
          //  return this.XOR(data, key);
        }
    }
}
