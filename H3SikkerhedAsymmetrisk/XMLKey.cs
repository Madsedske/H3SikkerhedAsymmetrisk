using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace H3SikkerhedAsymmetrisk
{
    public class XMLKey
    {
        public void MakeKey(string publicKey, string privateKey)
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;

                if (File.Exists(privateKey))
                {
                    File.Delete(privateKey);
                }

                if (File.Exists(publicKey))
                {
                    File.Delete(publicKey);
                }

                var publicKeyfolder = Path.GetDirectoryName(publicKey);
                var privateKeyfolder = Path.GetDirectoryName(privateKey);

                if (!Directory.Exists(publicKeyfolder))
                {
                    Directory.CreateDirectory(publicKeyfolder);
                }

                if (!Directory.Exists(privateKeyfolder))
                {
                    Directory.CreateDirectory(privateKeyfolder);
                }

                File.WriteAllText(publicKey, rsa.ToXmlString(false));
                File.WriteAllText(privateKey, rsa.ToXmlString(true));
            }
        }

        public void SaveText(byte[] encryptedText)
        {
            string encryptedTextFile = "c:\\Programmering\\encryptedText.txt";
            File.WriteAllText(encryptedTextFile, Convert.ToBase64String(encryptedText));
        }

        public byte[] Encrypt(string publicKey, byte[] dataToEncrypt)
        {
            byte[] cipherBytes;

            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                rsa.FromXmlString(File.ReadAllText(publicKey));

                cipherBytes = rsa.Encrypt(dataToEncrypt, false);
            }
            return cipherBytes;
        }

        public byte[] Decrypt(string privateKey, byte[] dataToEncrypt)
        {
            byte[] plainText;

            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                rsa.FromXmlString(File.ReadAllText(privateKey));
                plainText = rsa.Decrypt(dataToEncrypt, false);
            }
            return plainText;
        }
    }
}
