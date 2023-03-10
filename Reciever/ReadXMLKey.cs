using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Reciever
{
    public class ReadXMLKey
    {
        public byte[] Decrypt(byte[] dataToDecrypt)
        {
            string privateKeyPath = "c:\\Programmering\\privatekey.xml";
            byte[] decrypted;

            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;

                rsa.FromXmlString(File.ReadAllText(privateKeyPath));

                decrypted = rsa.Decrypt(dataToDecrypt, false);
            }
            return decrypted;
        }

        public string ReadText() 
        {
            string encryptedTextFile = "c:\\Programmering\\encryptedText.txt";
            string text = File.ReadAllText(encryptedTextFile);
            return text;
        }
    }
}
