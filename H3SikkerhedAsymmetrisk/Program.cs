using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace H3SikkerhedAsymmetrisk
{
    public class Program
    {
        static void Main(string[] args)
        {
            //AsymmetriskXml();
            RsaWithCsp();
            Console.ReadKey();
        }

        private static void RsaWithCsp()
        {
            var csp = new CSPKey();
            string text = "Bla bla bla";
            csp.CreateKey();
            var encrypted = csp.EncryptData(Encoding.UTF8.GetBytes(text));
            csp.SaveText(encrypted);
            Console.WriteLine("Sender");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Original Text = " + text);
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Encrypted Text = " + Convert.ToBase64String(encrypted));
        }

        public static void AsymmetriskXml()
        {
            var rsa = new XMLKey();
            string text = "Bla bla bla";
            string publicKey = "c:\\Programmering\\publickey.xml";
            string privateKey = "c:\\Programmering\\privatekey.xml";
            rsa.MakeKey(publicKey, privateKey);
            var encrypted = rsa.Encrypt(publicKey, Encoding.UTF8.GetBytes(text));
            //var decrypted = rsa.Decrypt(privateKey, encrypted);
            rsa.SaveText(encrypted);
            Console.WriteLine("The text : " + text);
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Encrypted text : " + Convert.ToBase64String(encrypted));
        }
    }
}
