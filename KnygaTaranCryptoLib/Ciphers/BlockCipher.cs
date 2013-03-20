using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Parameters;

namespace KnygaTaranCryptoLib.Ciphers
{
    public class BlockCipher : IChiper
    {
        public int DataBlockLength { get; private set; }

        private IBlockCipher _blockCipher;

        public BlockCipher(IBlockCipher blockCipher)
        {
			if (!blockCipher.GetType().Equals(typeof(AesEngine)))
				DataBlockLength = 8; // in bytes
			else
			{
				DataBlockLength = 16; // aes processes blocks of 16 bytes
			}
            _blockCipher = blockCipher;
        }

        public byte[] Encrypt(byte[] data, byte[] key)
        {
            if (data.Length != 8 && data.Length != 16)
                throw new Exception("Improper block length enryption attempt");

            _blockCipher.Reset();
            _blockCipher.Init(true, new KeyParameter(key));
            var ouput = new byte[data.Length];
            _blockCipher.ProcessBlock(data, 0, ouput, 0);
            return ouput;
        }

        public byte[] Decrypt(byte[] data, byte[] key)
        {
			if (data.Length != 8 && data.Length != 16)
                throw new Exception("Improper block length decryption attempt");

            _blockCipher.Reset();
            _blockCipher.Init(false, new KeyParameter(key));
            var ouput = new byte[data.Length];
            _blockCipher.ProcessBlock(data, 0, ouput, 0);
            return ouput;
        }

        /// <summary>
        /// allows to extract type of... (surprise) used cipher 
        /// </summary>
        public Type CipherType { get { return _blockCipher.GetType(); }}

        public override string ToString()
        {
            var algName = _blockCipher.AlgorithmName;
	        if (algName.ToLower() == "desede")
		        return "Triple DES";
			return algName;
        }
    }
}
