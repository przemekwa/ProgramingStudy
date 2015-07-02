using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Study
{
    class Bezpieczenstwo2 : IStudyTest
    {
        public void Study()
        {
            var cert = GetCertificate2();

            var ue = new UnicodeEncoding();

            var msg = ue.GetBytes("Przemek Walkowski");

            var hash = new SHA1Managed().ComputeHash(msg);

            var signed = Sign(hash, cert);
        }

        private static byte[] Sign(byte[] hash, X509Certificate2 cert)
        {
            var rsa = (RSACryptoServiceProvider)cert.PrivateKey;

            var result = rsa.SignHash(hash, CryptoConfig.MapNameToOID("SHA1"));

            return result;
        }

        private static X509Certificate2 GetCertificate2()
        {
            var store = new X509Store("testCert", StoreLocation.CurrentUser);

            store.Open(OpenFlags.ReadOnly);

            foreach (var certificate in store.Certificates)
            {
                if (certificate.Subject == "CN=Przemek")
                {
                    return certificate;
                }
            }

            return null;
        }




    }
}
