using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KnygaTaranCryptoLib
{
    public interface IChiper
    {
        /// <summary>
        /// Длина блока в битах, на которые делится входное сообщение
        /// </summary>
        int DataBlockLength { get; }

        byte[] Encrypt(byte[] data, byte[] key);
        byte[] Decrypt(byte[] data, byte[] key);
    }
}
