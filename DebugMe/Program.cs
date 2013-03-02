using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KnygaTaranCryptoLib;

namespace DebugMe
{
    class Program
    {
        static void Main(string[] args)
        {
            //оборачиваю
            //BlockChiperMode ch = new ChiperModel(new ConcretChiper());

            ////создаю данные
            //Data100 data = new Data100();
            //data.ReadFromText("A striking example of the degree to which ECB can leave plaintext data patterns in the ciphertext can be seen when ECB mode is used to encrypt a bitmap image which uses large areas of uniform colour. While the colour of each individual pixel is encrypted, the overall image may still be discerned as the pattern of identically coloured pixels in the original remains in the encrypted version.", Encoding.ASCII);

            ////создаю ключ
            //Data100 key = new Data100();
            //key.ReadFromText("key64bit64bit64bit64bit64bit64bit64bit64bit64bit64bit64bit64bit64bit64bit64bit64bit64bit", Encoding.ASCII);
            ////подрезаю ключ, чтобы был правильной длины
            //key.Crop(ch.Chiper.DataBlockLength);

            ////создаю вектор инициализации
            //Data100 IV = new Data100();
            //IV.ReadFromText("VECTORVECTORVECTORVECTORVECTORVECTORVECTORVECTORVECTORVECTORVECTORVECTORVECTORVECTORVECTORVECTORVECTOR", Encoding.ASCII);
            ////подрезаю ключ, чтобы был правильной длины
            //IV.Crop(ch.Chiper.DataBlockLength);

            ////туда-сюда
            //byte[] enc1 = ch.EcbModel.ECBEncrypt(data.Data, key.Data);
            //byte[] dec1 = ch.EcbModel.ECBDecrypt(enc1, key.Data);

            //byte[] enc2 = ch.CbcModel.CBCEncrypt(data.Data, key.Data, IV.Data);
            //byte[] dec2 = ch.CbcModel.CBCDecrypt(enc2, key.Data, IV.Data);

            //byte[] enc3 = ch.CfbModel.CFBEncrypt(data.Data, key.Data, IV.Data);
            //byte[] dec3 = ch.CfbModel.CFBDecrypt(enc3, key.Data, IV.Data);

            //byte[] enc4 = ch.OfbModel.OFBEncrypt(data.Data, key.Data, IV.Data);
            //byte[] dec4 = ch.OfbModel.OFBDecrypt(enc4, key.Data, IV.Data);

            //Data100 output = new Data100(dec1);
            //output.WriteToFile("Decrypted_ECB.txt");
            //output = new Data100(dec2);
            //output.WriteToFile("Decrypted_CBC.txt");
            //output = new Data100(dec3);
            //output.WriteToFile("Decrypted_CFB.txt");
            //output = new Data100(dec4);
            //output.WriteToFile("Decrypted_OFB.txt");

            //output = new Data100(enc1);
            //output.WriteToFile("Encrypted_ECB.txt");
            //output = new Data100(enc2);
            //output.WriteToFile("Encrypted_CBC.txt");
            //output = new Data100(enc3);
            //output.WriteToFile("Encrypted_CFB.txt");
            //output = new Data100(enc4);
            //output.WriteToFile("Encrypted_OFB.txt");

	        var fa = new byte[8];
	        var sa = new byte[8];
        }
    }
}
