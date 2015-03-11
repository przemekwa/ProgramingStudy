using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Study
{
   public class Bezpieczenstwo : IStudyTest
    {
        private byte[] Encrypt(SymmetricAlgorithm symmetricAlgorithm, string text)
        {
            ICryptoTransform encryptor = symmetricAlgorithm.CreateEncryptor(symmetricAlgorithm.Key, symmetricAlgorithm.IV);

            using (var msEncrypt = new MemoryStream())
            {
                using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (var swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.WriteLine(text);
                    }
                    return msEncrypt.ToArray();
                }
            }
        }

        private string Decrypt(SymmetricAlgorithm symmetricAlgorithm, byte[] msg)
        {
            ICryptoTransform decryptor = symmetricAlgorithm.CreateDecryptor(symmetricAlgorithm.Key, symmetricAlgorithm.IV);
            using (var msDecrypt = new MemoryStream(msg))
            {
                using (var csDecrypt =new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (var srDecrypt = new StreamReader(csDecrypt))
                    {
                        return srDecrypt.ReadToEnd();
                    }
                }
            }
        }

        private byte[] EncryptRSA(byte[] msg, CspParameters csp)
        {
            using (var RSA = new RSACryptoServiceProvider(csp))
            {
                 return RSA.Encrypt(msg, false);
            }
        }

        private byte[] DecryptRSA(byte[] msg, CspParameters csp)
        {
            using (var RSA = new RSACryptoServiceProvider(csp))
            {
                return RSA.Decrypt(msg, false);
            }
        }

        private void AsyMetricAlg()
        {
            var csp = new CspParameters();
            
            csp.KeyContainerName = "KontenerRSA";
            
            string  publicKeyXml;

            using (var RSA = new RSACryptoServiceProvider(csp))
            {
                 publicKeyXml = RSA.ToXmlString(false);
            }

            //File.WriteAllText("test.txt",publicKeyXml);


          //  var t1 = File.ReadAllText("test.txt");


            var msg = "T";

            var uniCodeMsg = new UnicodeEncoding();

            var encryptMsg = this.EncryptRSA(uniCodeMsg.GetBytes(msg), csp);

            File.WriteAllBytes("wiadomosc2.txt", encryptMsg);

            byte[] test = new byte[128];
           

          //  test = File.ReadAllBytes("wiadomosc2.txt");

            List<byte> listByte = new List<byte>();
            List<byte> listByte2 = new List<byte>();

            using (var sr = new StreamReader("wiadomosc2.txt", uniCodeMsg))
            {
                int byteStream = 0;
                
                while ((byteStream = sr.BaseStream.ReadByte()) != -1)
                {
                    var intByte = BitConverter.GetBytes(byteStream);

                    if (BitConverter.IsLittleEndian)
                    {
                        Array.Reverse(intByte);
                    }

                    var h = false;
                    var onlyzero = 0;

                    foreach (var b in intByte)
                    {
                        if (b == 0)
                        {
                            onlyzero++;
                        }

                        if (onlyzero == 4)
                        {
                            listByte.Add(0);
                            onlyzero = 0;
                        }


                        if (b != 0)
                        {
                            h = true;
                        }

                        if (h)
                        {
                            listByte.Add(b);
                            onlyzero = 0;
                            h = false;
                        }

                    }
                }
            }

            test = listByte.ToArray();


            if (test.Length != encryptMsg.Length)
            {
                Console.WriteLine("fl");
            }
           


            var decryptMsg = this.DecryptRSA(test, csp);



            Console.WriteLine(" Wiadomość: {0}", msg);
            Console.WriteLine(" Wiadomość zakodowana: {0}", uniCodeMsg.GetString(encryptMsg));
            Console.WriteLine(" Wiadomość odkodowana: {0}", uniCodeMsg.GetString(decryptMsg));



            Console.ReadLine();

        }

        private void SymetricAlg()
        {
            SymmetricAlgorithm sa = new TripleDESCryptoServiceProvider();

            var msg = "Tajny Tekst";

            Console.WriteLine("Wiadomość: {0}", msg);

            var encryptMsg = this.Encrypt(sa, msg);

            Console.Write("Zakodowana wiadomość: ");

            foreach (var c in encryptMsg)
            {
                Console.Write(c);
            }
            Console.WriteLine();

            var msg2 = this.Decrypt(sa, encryptMsg);

            Console.WriteLine("Odkodowana: {0}", msg2);

            Console.ReadLine();
        }

        public Bezpieczenstwo()
        {
         
        }

        public void Study()
        {
            this.AsyMetricAlg();
        }
    }
}

