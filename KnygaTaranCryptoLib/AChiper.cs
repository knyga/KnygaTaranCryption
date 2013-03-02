using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KnygaTaranCryptoLib
{
    /// <summary>
    /// Обище для всех шифроф методы, если реализовывать вручную
    /// </summary>
    public abstract class AChiper
    {
        public byte[] XOR(byte[] d1, byte[] d2)
        {
            if (d1.Length!=d2.Length)
                throw new Exception("Cant XOR arrays of different length");

            byte[] data = new byte[d1.Length];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (byte)(d1[i] ^ d2[i]);
            }
            return data;
        }
    }
}
