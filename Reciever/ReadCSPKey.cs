using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Reciever
{
    public class ReadCSPKey
    {
        public byte[] DecryptData(byte[] dataDecrypt, string containerName)
        {
            byte[] plainText;
            var para = new CspParameters { KeyContainerName = containerName };
            using (var rsa = new RSACryptoServiceProvider(2048, para))
            {
                plainText = rsa.Decrypt(dataDecrypt, false);
            }
            return plainText;
        }
        public string ReadText()
        {
            string encryptedTextFile = "c:\\Programmering\\encryptedText.txt";
            string text = File.ReadAllText(encryptedTextFile);
            return text;
        }
    }
}
