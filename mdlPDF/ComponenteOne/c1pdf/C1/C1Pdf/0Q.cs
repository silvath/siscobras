namespace C1.C1Pdf
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    internal class 0Q : RichTextBox
    {
        // Methods
        public 0Q()
        {
            this.V1 = new 0T(true);
        }

        internal float 9U(float 0E1)
        {
            RectangleF ef1 = RectangleF.Empty;
            ef1.Width = 0E1;
            return this.9W(this.V1.Y6, ef1, true);
        }

        internal Metafile 9V(SizeF 0E2)
        {
            RectangleF ef1;
            IntPtr ptr1;
            Metafile metafile1 = null;
            ef1 = new RectangleF(PointF.Empty, 0E2);
            metafile1 = new Metafile(this.V1.Y6, ef1, MetafileFrameUnit.Point, EmfType.EmfOnly);
            using (Graphics graphics1 = Graphics.FromImage(metafile1))
            {
                ptr1 = graphics1.GetHdc();
                this.9W(ptr1, ef1, false);
                graphics1.ReleaseHdc(ptr1);
                return metafile1;
            }
            return metafile1;
        }

        internal float 9W(IntPtr 0E3, RectangleF 0E4, bool 0E5)
        {
            0S s1;
            RectangleF* efPtr1 = &0E4;
            0E4.X = (efPtr1.X * 20f);
            RectangleF* efPtr2 = &0E4;
            0E4.Y = (efPtr2.Y * 20f);
            RectangleF* efPtr3 = &0E4;
            0E4.Width = (efPtr3.Width * 20f);
            RectangleF* efPtr4 = &0E4;
            0E4.Height = (efPtr4.Height * 20f);
            s1 = new 0S();
            IntPtr ptr1 = 0E3;
            s1.V7 = ptr1;
            s1.V6 = ptr1;
            s1.V8.V2 = ((int) 0E4.X);
            s1.V8.V3 = ((int) 0E4.Y);
            s1.V8.V4 = ((int) 0E4.Right);
            s1.V8.V5 = (0E5 ? 32000 : ((int) 0E4.Bottom));
            s1.V9 = s1.V8;
            s1.VA = 0;
            s1.VB = -1;
            float single1 = ((float) this.9X(ref s1, 0E5));
            return (single1 / 20f);
        }

        private int 9X(ref 0S 0E6, bool 0E7)
        {
            IntPtr ptr1 = ((IntPtr) (0E7 ? 0 : 1));
            0Q.9Y(base.Handle, 1081, ptr1, 0E6);
            Message message1 = Message.Create(base.Handle, 1081, IntPtr.Zero, IntPtr.Zero);
            this.WndProc(ref message1);
            return (0E6.V8.V5 - 0E6.V8.V3);
        }

        [DllImport("USER32.DLL", EntryPoint="SendMessage", CharSet=CharSet.Auto)]
        private static extern IntPtr 9Y(IntPtr 0E8, uint 0E9, IntPtr 0EA, ref 0S 0EB);

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            this.V1.Dispose();
        }


        // Fields
        private const int UX = 1024;
        private const int UY = 1081;
        private const int UZ = 1226;
        private const int V0 = 1;
        private 0T V1;

        // Nested Types
        [StructLayout(LayoutKind.Sequential)]
        private struct 0R
        {
            // Fields
            internal int V2;
            internal int V3;
            internal int V4;
            internal int V5;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct 0S
        {
            // Fields
            internal IntPtr V6;
            internal IntPtr V7;
            internal 0R V8;
            internal 0R V9;
            internal int VA;
            internal int VB;
        }
    }
}

