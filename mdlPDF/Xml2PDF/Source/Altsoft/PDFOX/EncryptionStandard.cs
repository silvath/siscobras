namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;
    using System.IO;
    using System.Security;
    using System.Security.Cryptography;

    public class EncryptionStandard : IEncryption
    {
        // Methods
        static EncryptionStandard()
        {
            EncryptionStandard.PadString = new byte[32] { 40, 191, 78, 94, 78, 117, 138, 65, 100, 0, 78, 86, 255, 250, 1, 8, 46, 46, 0, 182, 208, 104, 62, 128, 47, 12, 169, 254, 100, 83, 105, 122 };
            EncryptionStandard.md5 = new MD5CryptoServiceProvider();
        }

        internal EncryptionStandard()
        {
            this.mEncMetadata = true;
            this.mRev = -1;
            this.mV = -1;
        }

        internal EncryptionStandard(PDFDict dict, ISecurityHandler sec)
        {
            this.mEncMetadata = true;
            this.mRev = -1;
            this.mV = -1;
            this.mDict = dict;
            this.mRev = ((PDFInteger) this.mDict["R"]).Int32Value;
            if (!(this.mDict["Length"] is PDFInteger))
            {
                this.mKeyLength = 40;
            }
            else
            {
                this.mKeyLength = ((PDFInteger) this.mDict["Length"]).Int32Value;
            }
            if (!(this.mDict["V"] is PDFInteger))
            {
                this.mV = 0;
            }
            else
            {
                this.mV = ((PDFInteger) this.mDict["V"]).Int32Value;
            }
            this.mPerm = BitConverter.ToUInt32(BitConverter.GetBytes(((PDFInteger) this.mDict["P"]).Int32Value), 0);
            this.mOEntry = (this.mDict["O"] as PDFString).Bytes;
            this.mUEntry = (this.mDict["U"] as PDFString).Bytes;
            PDFBoolean flag1 = (this.mDict["EncryptMetadata"] as PDFBoolean);
            if (flag1 != null)
            {
                this.mEncMetadata = flag1.Value;
            }
            this.mDocId = this.mDict.Doc.Id1;
            this.mOwnerPassword = "";
            if (sec != null)
            {
                if (!this.VerifyUserPassword(""))
                {
                    this.mUserPassword = sec.GetUserPassword();
                }
                else
                {
                    this.mUserPassword = "";
                }
            }
            else
            {
                this.mUserPassword = "";
            }
            if (!this.VerifyUserPassword(this.mUserPassword))
            {
                throw new SecurityException("Wrong PDF Document user password");
            }
        }

        private byte[] ComputeObjKey(int id, int gene)
        {
            int num1;
            byte[] numArray1 = BitConverter.GetBytes(id);
            byte[] numArray5 = new byte[3];
            numArray5[0] = numArray1[0];
            numArray5[1] = numArray1[1];
            numArray5[2] = numArray1[2];
            byte[] numArray2 = Utils.AppendByteArrays(this.DocKey, numArray5);
            byte[] numArray3 = BitConverter.GetBytes(gene);
            numArray5 = new byte[2];
            numArray5[0] = numArray3[0];
            numArray5[1] = numArray3[1];
            numArray2 = Utils.AppendByteArrays(numArray2, numArray5);
            numArray2 = EncryptionStandard.md5.ComputeHash(numArray2);
            byte[] numArray4 = new byte[Math.Min((this.DocKey.Length + 5), 16)];
            for (num1 = 0; (num1 < numArray4.Length); num1 += 1)
            {
                numArray4[num1] = numArray2[num1];
            }
            return numArray4;
        }

        public static EncryptionStandard Create(string ownerPassword, string userPassword, UserAccessPermissions perm, int keyLength, bool encMetadata)
        {
            if (ownerPassword == null)
            {
                ownerPassword = "";
            }
            if (userPassword == null)
            {
                userPassword = "";
            }
            EncryptionStandard standard1 = new EncryptionStandard();
            standard1.mUserPassword = userPassword;
            standard1.mOwnerPassword = ownerPassword;
            standard1.mPerm = ((uint) perm);
            standard1.mKeyLength = keyLength;
            standard1.mRev = 3;
            standard1.mV = 2;
            standard1.mEncMetadata = encMetadata;
            return standard1;
        }

        public PDFDict CreateEncryptionDict(Document doc)
        {
            PDFDict dict1 = Library.CreateDict();
            this.mDocId = doc.Id1;
            dict1["V"] = PDF.O(2);
            dict1["O"] = PDF.S(this.OEntry);
            dict1["U"] = PDF.S(this.UEntry);
            dict1["R"] = PDF.O(this.Rev);
            dict1["P"] = PDF.O(this.UserPermissions);
            dict1["Length"] = PDF.O(this.KeyLength);
            dict1["Filter"] = PDF.N("Standard");
            return dict1;
        }

        public Stream DecryptStream(Stream src, int id, int gene)
        {
            return new RC4Transcoder(src, this.ComputeObjKey(id, gene));
        }

        public byte[] DecryptString(PDFString src, int id, int gene)
        {
            byte[] numArray1 = src.Bytes;
            RC4CryptoTransform transform1 = new RC4CryptoTransform(this.ComputeObjKey(id, gene));
            return transform1.TransformFinalBlock(numArray1, 0, numArray1.Length);
        }

        public Stream EncryptStream(Stream src, int id, int gene)
        {
            return new RC4Transcoder(src, this.ComputeObjKey(id, gene));
        }

        public byte[] EncryptString(PDFString src, int id, int gene)
        {
            byte[] numArray1 = src.Bytes;
            RC4CryptoTransform transform1 = new RC4CryptoTransform(this.ComputeObjKey(id, gene));
            return transform1.TransformFinalBlock(numArray1, 0, numArray1.Length);
        }

        public static IEncryption Factory(PDFDict encryptDict, ISecurityHandler sec)
        {
            PDFName name1 = (encryptDict["Filter"] as PDFName);
            if (name1 == null)
            {
                return null;
            }
            if (name1.Value != "Standard")
            {
                return null;
            }
            return new EncryptionStandard(encryptDict, sec);
        }

        private static byte[] PadPassword(string pwd)
        {
            int num1;
            int num2;
            byte[] numArray1 = new byte[32];
            if (pwd.Length <= 32)
            {
                Utils.StringToBytes(pwd).CopyTo(numArray1, 0);
                for (num1 = 0; (num1 < (32 - pwd.Length)); num1 += 1)
                {
                    numArray1[(pwd.Length + num1)] = EncryptionStandard.PadString[num1];
                }
                return numArray1;
            }
            for (num2 = 0; (num2 < 32); num2 += 1)
            {
                numArray1[num2] = ((byte) pwd[num2]);
            }
            return numArray1;
        }

        private bool VerifyUserPassword(string pwd)
        {
            int num1;
            EncryptionStandard standard1 = new EncryptionStandard();
            standard1.mV = this.mV;
            standard1.mDocId = this.mDocId;
            standard1.mKeyLength = this.mKeyLength;
            standard1.mOEntry = this.mOEntry;
            standard1.mPerm = this.mPerm;
            standard1.mRev = this.mRev;
            standard1.mEncMetadata = this.mEncMetadata;
            standard1.mUserPassword = pwd;
            standard1.UEntry;
            if (standard1.UEntry.Length != this.UEntry.Length)
            {
                return false;
            }
            for (num1 = 0; (num1 < this.UEntry.Length); num1 += 1)
            {
                if (this.UEntry[num1] != standard1.UEntry[num1])
                {
                    return false;
                }
            }
            return true;
        }


        // Properties
        public PDFDict Dict
        {
            get
            {
                return this.mDict;
            }
        }

        private byte[] DocId
        {
            get
            {
                return this.mDocId;
            }
        }

        private byte[] DocKey
        {
            get
            {
                byte[] numArray1;
                int num2;
                int num3;
                int num1 = (this.KeyLength / 8);
                if (this.mDocKey == null)
                {
                    if (this.Rev <= 2)
                    {
                        num1 = 5;
                    }
                    numArray1 = EncryptionStandard.PadPassword(this.UserPassword);
                    numArray1 = Utils.AppendByteArrays(numArray1, this.OEntry);
                    numArray1 = Utils.AppendByteArrays(numArray1, BitConverter.GetBytes(this.UserPermissions));
                    numArray1 = Utils.AppendByteArrays(numArray1, this.DocId);
                    if ((this.Rev >= 3) && !this.EncryptMetadata)
                    {
                        byte[] numArray2 = new byte[4] { 255, 255, 255, 255 };
                        numArray1 = Utils.AppendByteArrays(numArray1, numArray2);
                    }
                    numArray1 = EncryptionStandard.md5.ComputeHash(numArray1);
                    if (this.Rev >= 3)
                    {
                        for (num2 = 0; (num2 < 50); num2 += 1)
                        {
                            numArray1 = EncryptionStandard.md5.ComputeHash(numArray1);
                        }
                    }
                    this.mDocKey = new byte[num1];
                    for (num3 = 0; (num3 < num1); num3 += 1)
                    {
                        this.mDocKey[num3] = numArray1[num3];
                    }
                }
                return this.mDocKey;
            }
        }

        public bool EncryptMetadata
        {
            get
            {
                return this.mEncMetadata;
            }
        }

        public string Filter
        {
            get
            {
                return "Standard";
            }
        }

        public int KeyLength
        {
            get
            {
                return this.mKeyLength;
            }
        }

        private byte[] OEntry
        {
            get
            {
                int num1;
                byte[] numArray1;
                int num2;
                byte[] numArray2;
                byte num3;
                byte num4;
                byte[] numArray3;
                int num5;
                RC4CryptoTransform transform1;
                if (this.mOEntry == null)
                {
                    num1 = (this.KeyLength / 8);
                    numArray1 = EncryptionStandard.md5.ComputeHash(EncryptionStandard.PadPassword(this.OwnerPassword));
                    if (this.Rev >= 3)
                    {
                        for (num2 = 0; (num2 < 50); num2 += 1)
                        {
                            numArray1 = EncryptionStandard.md5.ComputeHash(numArray1);
                        }
                    }
                    if (this.Rev <= 2)
                    {
                        num1 = 5;
                    }
                    numArray2 = EncryptionStandard.PadPassword(this.UserPassword);
                    num3 = ((byte) ((this.Rev >= 3) ? 20 : 1));
                    for (num4 = 0; (num4 < num3); num4 += 1)
                    {
                        numArray3 = new byte[num1];
                        for (num5 = 0; (num5 < num1); num5 += 1)
                        {
                            numArray3[num5] = (numArray1[num5] ^ num4);
                        }
                        transform1 = new RC4CryptoTransform(numArray3);
                        transform1.TransformBlock(numArray2, 0, numArray2.Length, numArray2, 0);
                    }
                    this.mOEntry = numArray2;
                }
                return this.mOEntry;
            }
        }

        private string OwnerPassword
        {
            get
            {
                this.mOwnerPassword;
                return this.mOwnerPassword;
            }
        }

        public int Rev
        {
            get
            {
                this.mRev;
                return this.mRev;
            }
        }

        private byte[] UEntry
        {
            get
            {
                RC4CryptoTransform transform1;
                byte[] numArray1;
                byte[] numArray2;
                byte num2;
                int num3;
                RC4CryptoTransform transform2;
                int num1 = (this.KeyLength / 8);
                if (this.mUEntry == null)
                {
                    if (this.Rev <= 2)
                    {
                        transform1 = new RC4CryptoTransform(this.DocKey);
                        this.mUEntry = transform1.TransformFinalBlock(EncryptionStandard.PadString, 0, EncryptionStandard.PadString.Length);
                    }
                    else if (this.Rev >= 3)
                    {
                        numArray1 = ((byte[]) EncryptionStandard.PadString.Clone());
                        numArray1 = Utils.AppendByteArrays(numArray1, this.DocId);
                        numArray1 = EncryptionStandard.md5.ComputeHash(numArray1);
                        numArray2 = new byte[num1];
                        for (num2 = 0; (num2 < 20); num2 += 1)
                        {
                            for (num3 = 0; (num3 < num1); num3 += 1)
                            {
                                numArray2[num3] = (this.DocKey[num3] ^ num2);
                            }
                            transform2 = new RC4CryptoTransform(numArray2);
                            transform2.TransformBlock(numArray1, 0, numArray1.Length, numArray1, 0);
                        }
                        this.mUEntry = Utils.AppendByteArrays(numArray1, new byte[16]);
                    }
                    else
                    {
                        throw new NotImplementedException();
                    }
                }
                return this.mUEntry;
            }
        }

        private string UserPassword
        {
            get
            {
                this.mUserPassword;
                return this.mUserPassword;
            }
        }

        public uint UserPermissions
        {
            get
            {
                return this.mPerm;
            }
        }

        public int V
        {
            get
            {
                return this.mV;
            }
        }


        // Fields
        private static MD5CryptoServiceProvider md5;
        private PDFDict mDict;
        private byte[] mDocId;
        private byte[] mDocKey;
        private bool mEncMetadata;
        private int mKeyLength;
        private byte[] mOEntry;
        private string mOwnerPassword;
        private uint mPerm;
        private int mRev;
        private byte[] mUEntry;
        private string mUserPassword;
        private int mV;
        private static byte[] PadString;
    }
}

