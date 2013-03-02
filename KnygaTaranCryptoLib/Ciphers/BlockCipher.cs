using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;

namespace KnygaTaranCryptoLib.Ciphers
{
    public class BlockCipher : IChiper
    {
        public int DataBlockLength { get; private set; }

        private IBlockCipher _blockCipher;

        public BlockCipher(IBlockCipher blockCipher)
        {
            DataBlockLength = 8; // in bytes
            _blockCipher = blockCipher;
        }

        public byte[] Encrypt(byte[] data, byte[] key)
        {
            if (data.Length != 8)
                throw new Exception("Improper block length enryption attempt");

            _blockCipher.Reset();
            _blockCipher.Init(true, new KeyParameter(key));
            var ouput = new byte[8];
            _blockCipher.ProcessBlock(data, 0, ouput, 0);
            return ouput;
        }

        public byte[] Decrypt(byte[] data, byte[] key)
        {
            if (data.Length != 8)
                throw new Exception("Improper block length decryption attempt");

            _blockCipher.Reset();
            _blockCipher.Init(false, new KeyParameter(key));
            var ouput = new byte[8];
            _blockCipher.ProcessBlock(data, 0, ouput, 0);
            return ouput;
        }

        /// <summary>
        /// allows to extract type of... (surprise) used cipher 
        /// </summary>
        public Type CipherType { get { return _blockCipher.GetType(); }}

        public override string ToString()
        {
            return _blockCipher.AlgorithmName;
        }
    }
}
