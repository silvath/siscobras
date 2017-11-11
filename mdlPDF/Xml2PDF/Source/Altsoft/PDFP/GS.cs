namespace Altsoft.PDFP
{
    using Altsoft.Common;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct GS
    {
        // Methods
        public void SetDefaults()
        {
            double num1 = 0f;
            this.RG_b = num1;
            num1 = num1;
            this.RG_g = num1;
            num1 = num1;
            this.RG_r = num1;
            num1 = num1;
            this.rg_b = num1;
            num1 = num1;
            this.rg_g = num1;
            this.rg_r = num1;
            num1 = 0f;
            this.CS_4 = num1;
            num1 = num1;
            this.CS_3 = num1;
            num1 = num1;
            this.CS_2 = num1;
            num1 = num1;
            this.CS_1 = num1;
            num1 = num1;
            this.cs_4 = num1;
            num1 = num1;
            this.cs_3 = num1;
            num1 = num1;
            this.cs_2 = num1;
            this.cs_1 = num1;
            this.numOfCSParams = 0;
            this.w = 1f;
            this.CTM = new CTM();
            this.FontID = "";
            this.FontSize = 0f;
            this.PathOpened = false;
            this.TextOpened = false;
            num1 = 0f;
            this.ty = num1;
            this.tx = num1;
            this.d = new double[1];
            this.d[0] = 0f;
        }


        // Fields
        public double cs_1;
        public double CS_1;
        public double cs_2;
        public double CS_2;
        public double cs_3;
        public double CS_3;
        public double cs_4;
        public double CS_4;
        public CTM CTM;
        public double[] d;
        public string FontID;
        public double FontSize;
        public int numOfCSParams;
        public bool PathOpened;
        public double rg_b;
        public double RG_b;
        public double rg_g;
        public double RG_g;
        public double rg_r;
        public double RG_r;
        public bool TextOpened;
        public double tx;
        public double ty;
        public double w;
    }
}

