namespace C1.C1Pdf
{
    using System;
    using System.Drawing;
    using System.Drawing.Printing;
    using System.Runtime.InteropServices;

    internal class 0T : IDisposable
    {
        // Methods
        static 0T()
        {
            0T.VX = 0;
        }

        public 0T(bool tryPrinter)
        {
            this.VW = tryPrinter;
        }

        private void AE()
        {
            if (this.VW)
            {
                try
                {
                    this.AF();
                }
                catch
                {
                }
            }
            if (this.VU == IntPtr.Zero)
            {
                this.VU = 0T.AG("DISPLAY", null, IntPtr.Zero, IntPtr.Zero);
                this.VV.X = 0T.AI(this.VU, 88);
                this.VV.Y = 0T.AI(this.VU, 90);
            }
            if (this.VU == IntPtr.Zero)
            {
                throw new ApplicationException("Failed to create reference hDC.");
            }
            0T.VX += 1;
        }

        private void AF()
        {
            PrinterResolution resolution1;
            PrinterSettings settings1 = new PrinterSettings();
            foreach (string text1 in PrinterSettings.InstalledPrinters)
            {
                settings1.PrinterName = text1;
                if (!settings1.IsValid)
                {
                    continue;
                }
                resolution1 = settings1.DefaultPageSettings.PrinterResolution;
                if ((resolution1.X != resolution1.Y) || (resolution1.X < 300))
                {
                    continue;
                }
                this.VU = 0T.AG("WINSPOOL", text1, IntPtr.Zero, IntPtr.Zero);
                this.VV.X = 0T.AI(this.VU, 88);
                this.VV.Y = 0T.AI(this.VU, 90);
                if (this.VV.X == resolution1.X)
                {
                    return;
                }
                0T.AH(this.VU);
                this.VU = IntPtr.Zero;
                this.VV = Point.Empty;
            }
        }

        [DllImport("gdi32.dll", EntryPoint="CreateIC")]
        private static extern IntPtr AG(string 0EV, string 0EW, IntPtr 0EX, IntPtr 0EY);

        [DllImport("gdi32.dll", EntryPoint="DeleteDC")]
        private static extern IntPtr AH(IntPtr 0EZ);

        [DllImport("gdi32.dll", EntryPoint="GetDeviceCaps")]
        private static extern int AI(IntPtr 0F0, int 0F1);

        public void Dispose()
        {
            if (this.VU != IntPtr.Zero)
            {
                0T.AH(this.VU);
                this.VU = IntPtr.Zero;
                this.VV = Point.Empty;
                0T.VX -= 1;
            }
        }


        // Properties
        public IntPtr Y6
        {
            get
            {
                if (this.VU == IntPtr.Zero)
                {
                    this.AE();
                }
                return this.VU;
            }
        }

        public Point Y7
        {
            get
            {
                if (this.VU == IntPtr.Zero)
                {
                    this.AE();
                }
                return this.VV;
            }
        }


        // Fields
        private const int VS = 88;
        private const int VT = 90;
        private IntPtr VU;
        private Point VV;
        private bool VW;
        private static int VX;
    }
}

