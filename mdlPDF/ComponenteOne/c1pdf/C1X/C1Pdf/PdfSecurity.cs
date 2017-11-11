namespace C1.C1Pdf
{
    using C1.Util.Localization;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Security.Cryptography;
    using System.Text;

    public class PdfSecurity
    {
        // Methods
        static PdfSecurity()
        {
            PdfSecurity.VP = new byte[32] { 40, 191, 78, 94, 78, 117, 138, 65, 100, 0, 78, 86, 255, 250, 1, 8, 46, 46, 0, 182, 208, 104, 62, 128, 47, 12, 169, 254, 100, 83, 105, 122 };
        }

        internal PdfSecurity(C1PdfDocumentBase doc)
        {
            this.VQ = new byte[256];
            this.VR = new byte[256];
            this.VC = doc;
            this.VF = string.Empty;
            this.VE = string.Empty;
            this.VL = true;
            this.VM = true;
            this.VN = true;
            this.VO = true;
            this.VK = new MD5CryptoServiceProvider();
        }

        internal void 9Z()
        {
            byte num2;
            byte num3;
            byte num4;
            if (((this.VE == null) || (this.VE.Length == 0)) && ((this.VF == null) || (this.VF.Length == 0)))
            {
                this.VI = null;
                return;
            }
            this.VG = this.A3(this.VE);
            byte[] numArray1 = (((this.VF != null) && (this.VF.Length > 0)) ? this.A3(this.VF) : this.A3(this.VE));
            this.A8(this.VG, numArray1, 5);
            int num1 = this.A4();
            ArrayList list1 = new ArrayList();
            byte[] numArray2 = this.A3(this.VE);
            int num5 = 0;
            while ((num5 < numArray2.Length))
            {
                num2 = numArray2[num5];
                list1.Add(num2);
                num5 += 1;
            }
            numArray2 = this.VG;
            num5 = 0;
            while ((num5 < numArray2.Length))
            {
                num3 = numArray2[num5];
                list1.Add(num3);
                num5 += 1;
            }
            list1.Add(((byte) num1));
            list1.Add(((byte) (num1 >> 8)));
            list1.Add(((byte) (num1 >> 16)));
            list1.Add(((byte) (num1 >> 24)));
            numArray2 = this.AB();
            for (num5 = 0; (num5 < numArray2.Length); num5 += 1)
            {
                num4 = numArray2[num5];
                list1.Add(num4);
            }
            this.VK.ComputeHash(((byte[]) list1.ToArray(typeof(byte))));
            this.VI = new byte[5];
            Array.Copy(this.VK.Hash, this.VI, 5);
            this.VH = this.A3(null);
            this.A5(this.VH, this.VI);
        }

        internal void A0(int 0EC, byte[] 0ED)
        {
            if (this.VI == null)
            {
                return;
            }
            int num1 = 0;
            int num2 = this.VI.Length;
            byte[] numArray1 = new byte[((uint) (num2 + 5))];
            int num3 = 0;
            while ((num3 < num2))
            {
                numArray1[num3] = this.VI[num3];
                num3 += 1;
            }
            int num4 = num3;
            num3 = (num4 + 1);
            numArray1[num3] = ((byte) 0EC);
            int num5 = num3;
            num3 = (num5 + 1);
            numArray1[num3] = ((byte) (0EC >> 8));
            int num6 = num3;
            num3 = (num6 + 1);
            numArray1[num3] = ((byte) (0EC >> 16));
            int num7 = num3;
            num3 = (num7 + 1);
            numArray1[num3] = ((byte) num1);
            int num8 = num3;
            num3 = (num8 + 1);
            numArray1[num3] = ((byte) (num1 >> 8));
            this.A8(0ED, numArray1, numArray1.Length);
        }

        internal void A1()
        {
            if (this.VI == null)
            {
                return;
            }
            this.VD = this.VC.65("Encryption Dictionary");
            this.VC.67();
            this.VC.68("Filter", "/Standard");
            this.VC.6A("V", ((long) 1));
            this.VC.6A("R", ((long) 2));
            this.VC.6A("P", ((long) this.A4()));
            this.VC.68("O", string.Format("<{0}>", this.A9(this.VG)));
            this.VC.68("U", string.Format("<{0}>", this.A9(this.VH)));
            this.VC.6B();
        }

        internal void A2()
        {
            if (this.VI == null)
            {
                return;
            }
            this.VC.68("Encrypt", this.VC.6K(this.VD));
            this.VC.68("ID", this.AA());
        }

        private byte[] A3(string 0EE)
        {
            if (0EE == null)
            {
                0EE = string.Empty;
            }
            byte[] numArray1 = new byte[32];
            byte[] numArray2 = Encoding.ASCII.GetBytes(0EE);
            int num1 = numArray2.Length;
            if (num1 > 0)
            {
                Array.Copy(numArray2, 0, numArray1, 0, Math.Min(num1, 32));
            }
            if (num1 < 32)
            {
                Array.Copy(PdfSecurity.VP, 0, numArray1, num1, (32 - num1));
            }
            return numArray1;
        }

        private int A4()
        {
            int num1 = -4;
            if (!this.VL)
            {
                num1 -= 4;
            }
            if (!this.VM)
            {
                num1 -= 16;
            }
            if (!this.VN)
            {
                num1 -= 8;
            }
            if (!this.VO)
            {
                num1 -= 32;
            }
            return num1;
        }

        private void A5(byte[] 0EF, byte[] 0EG)
        {
            this.AD(0EF, 0EG, 0EG.Length);
        }

        private void A6(byte[] 0EH, byte[] 0EI, int 0EJ)
        {
            this.AD(0EH, 0EI, 0EJ);
        }

        private void A7(byte[] 0EK, byte[] 0EL)
        {
            this.A8(0EK, 0EL, 0EL.Length);
        }

        private void A8(byte[] 0EM, byte[] 0EN, int 0EO)
        {
            0EN = this.VK.ComputeHash(0EN);
            this.A6(0EM, 0EN, 0EO);
        }

        private string A9(byte[] 0EP)
        {
            byte num1;
            int num2;
            StringBuilder builder1 = new StringBuilder();
            byte[] numArray1 = 0EP;
            for (num2 = 0; (num2 < numArray1.Length); num2 += 1)
            {
                num1 = numArray1[num2];
                builder1.AppendFormat("{0:X2}", num1);
            }
            return builder1.ToString();
        }

        private string AA()
        {
            return string.Format("[<{0}> <{0}>]", this.A9(this.AB()));
        }

        private byte[] AB()
        {
            if (this.VJ == null)
            {
                this.VJ = new byte[16];
                new Random().NextBytes(this.VJ);
            }
            return this.VJ;
        }

        private void AC(byte[] 0EQ, int 0ER)
        {
            int num1;
            int num3;
            byte num4;
            for (num1 = 0; (num1 < 256); num1 += 1)
            {
                this.VR[num1] = 0EQ[(num1 % 0ER)];
                this.VQ[num1] = ((byte) num1);
            }
            int num2 = 0;
            for (num3 = 0; (num3 < 256); num3 += 1)
            {
                num2 = (((num2 + this.VQ[num3]) + this.VR[num3]) % 256);
                num4 = this.VQ[num3];
                this.VQ[num3] = this.VQ[num2];
                this.VQ[num2] = num4;
            }
        }

        private void AD(byte[] 0ES, byte[] 0ET, int 0EU)
        {
            int num3;
            byte num4;
            byte num5;
            this.AC(0ET, 0EU);
            0EU = 0ES.Length;
            int num1 = 0;
            int num2 = 0;
            for (num3 = 0; (num3 < 0EU); num3 += 1)
            {
                num1 = ((num1 + 1) % 256);
                num2 = ((num2 + this.VQ[num1]) % 256);
                num4 = this.VQ[num1];
                this.VQ[num1] = this.VQ[num2];
                this.VQ[num2] = num4;
                num5 = this.VQ[((this.VQ[num1] + this.VQ[num2]) % 256)];
                0ES[num3] = (0ES[num3] ^ num5);
            }
        }


        // Properties
        [E("AllowCopyContent", "Gets or sets whether the user can copy contents from the pdf document."), DefaultValue(true)]
        public bool AllowCopyContent
        {
            get
            {
                return this.VM;
            }
            set
            {
                this.VM = value;
            }
        }

        [E("AllowEditAnnotations", "Gets or sets whether the user can edit annotations in the pdf document."), DefaultValue(true)]
        public bool AllowEditAnnotations
        {
            get
            {
                return this.VO;
            }
            set
            {
                this.VO = value;
            }
        }

        [DefaultValue(true), E("AllowEditContent", "Gets or sets whether the user can edit the contents of the pdf document.")]
        public bool AllowEditContent
        {
            get
            {
                return this.VN;
            }
            set
            {
                this.VN = value;
            }
        }

        [DefaultValue(true), E("AllowPrint", "Gets or sets whether the user can print the pdf document.")]
        public bool AllowPrint
        {
            get
            {
                return this.VL;
            }
            set
            {
                this.VL = value;
            }
        }

        [E("OwnerPassword", "Gets or sets the password required to change permissions for the pdf document."), DefaultValue("")]
        public string OwnerPassword
        {
            get
            {
                return this.VF;
            }
            set
            {
                this.VF = value;
            }
        }

        [E("UserPassword", "Gets or sets the password required to open the pdf document."), DefaultValue("")]
        public string UserPassword
        {
            get
            {
                return this.VE;
            }
            set
            {
                this.VE = value;
            }
        }

        internal bool Y5
        {
            get
            {
                return (this.VI != null);
            }
        }


        // Fields
        internal C1PdfDocumentBase VC;
        internal int VD;
        private string VE;
        private string VF;
        private byte[] VG;
        private byte[] VH;
        private byte[] VI;
        private byte[] VJ;
        private HashAlgorithm VK;
        private bool VL;
        private bool VM;
        private bool VN;
        private bool VO;
        private static byte[] VP;
        private byte[] VQ;
        private byte[] VR;
    }
}

