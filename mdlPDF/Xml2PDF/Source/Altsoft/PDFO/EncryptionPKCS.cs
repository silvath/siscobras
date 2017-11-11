namespace Altsoft.PDFO
{
    using Altsoft.Cryptography;
    using System;
    using System.IO;
    using System.Security.Cryptography.X509Certificates;

    public class EncryptionPKCS : IEncryption
    {
        // Methods
        private EncryptionPKCS()
        {
            this.mDocKey = null;
            this.mSeed = null;
            this.mDict = null;
        }

        private EncryptionPKCS(PDFDict dict, ISecurityHandler sec)
        {
            this.mDocKey = null;
            this.mSeed = null;
            this.mDict = null;
        }

        public static EncryptionPKCS Create(X509Certificate[] certs, UserAccessPermissions[] perms, int keyLength)
        {
            int num1;
            Random random1 = new Random();
            EncryptionPKCS npkcs1 = new EncryptionPKCS();
            npkcs1.mSeed = new byte[20];
            random1.NextBytes(npkcs1.mSeed);
            npkcs1.mDict = Library.CreateDict();
            npkcs1.mDict["V"] = PDF.O(2);
            npkcs1.mDict["R"] = PDF.O(1);
            PDFArray array1 = Library.CreateArray();
            npkcs1.mDict["Recipients"] = array1;
            for (num1 = 0; (num1 < certs.Length); num1 += 1)
            {
                array1.Add(npkcs1.CreateRecipientString(certs[num1], perms[num1], keyLength));
            }
            npkcs1.mDict["Length"] = PDF.O(keyLength);
            npkcs1.mDict["Filter"] = PDF.N("Adobe.PubSec");
            return npkcs1;
        }

        public PDFDict CreateEncryptionDict(Document doc)
        {
            return this.Dict;
        }

        private PDFString CreateRecipientString(X509Certificate cert, UserAccessPermissions perm, int keyLength)
        {
            PDFString text1 = Library.CreateString("");
            ASN1 asn1 = new ASN1(48);
            asn1.Add(ASN1Convert.FromOID("1.2.840.113549.1.7.3"));
            ASN1 asn2 = new ASN1(160);
            byte[] numArray1 = new byte[1];
            asn2.Add(new ASN1(2, numArray1));
            ASN1 asn3 = new ASN1(48);
            ASN1 asn4 = new ASN1(48);
            asn3.Add(asn4);
            new ASN1(2, cert.GetSerialNumber());
            return text1;
        }

        public Stream DecryptStream(Stream src, int id, int gene)
        {
            return null;
        }

        public byte[] DecryptString(PDFString src, int id, int gene)
        {
            return null;
        }

        public Stream EncryptStream(Stream src, int id, int gene)
        {
            return null;
        }

        public byte[] EncryptString(PDFString src, int id, int gene)
        {
            return src.Bytes;
        }

        public static IEncryption Factory(PDFDict encryptDict, ISecurityHandler sec)
        {
            PDFName name1 = (encryptDict["Filter"] as PDFName);
            if (name1 == null)
            {
                return null;
            }
            if (name1.Value != "Adobe.PubSec")
            {
                return null;
            }
            return new EncryptionPKCS(encryptDict, sec);
        }


        // Properties
        public PDFDict Dict
        {
            get
            {
                return this.mDict;
            }
        }

        public string Filter
        {
            get
            {
                return null;
            }
        }

        public int KeyLength
        {
            get
            {
                return 0;
            }
        }

        public uint UserPermissions
        {
            get
            {
                return 0;
            }
        }


        // Fields
        private PDFDict mDict;
        private byte[] mDocKey;
        private byte[] mSeed;
    }
}

