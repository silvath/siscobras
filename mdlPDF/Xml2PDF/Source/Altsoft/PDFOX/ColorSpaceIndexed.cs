namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;
    using System.Collections;
    using System.IO;
    using System.Reflection;

    public class ColorSpaceIndexed : ColorSpaceSpecial, ICollection, IEnumerable
    {
        // Methods
        internal ColorSpaceIndexed(PDFDirect d) : base(d)
        {
            PDFString text1;
            int num2;
            int num5;
            byte[] numArray3;
            int num6;
            int num7;
            this.mColors = new ArrayList();
            this.Count;
            PDFObject obj1 = ((PDFArray) d)[3];
            byte[] numArray1 = null;
            int num1 = base.Base.NrOfChannels;
            if (obj1.PDFType == PDFObjectType.tPDFString)
            {
                text1 = ((PDFString) obj1);
                numArray1 = Encoding.ASCII.GetBytes(text1.Value);
                for (num2 = 0; (num2 < this.Count); num2 += 1)
                {
                    this.mColors.Add(new PDFIndexedCSDoubleArrayString(text1, num2, num1, numArray1, (num2 * num1)));
                }
                return;
            }
            if (obj1.PDFType != PDFObjectType.tPDFStream)
            {
                goto Label_01CC;
            }
            PDFStream stream1 = ((PDFStream) obj1);
            Stream stream2 = stream1.Decode();
            if (stream2.Length != ((long) -1))
            {
                numArray1 = new byte[((IntPtr) stream2.Length)];
                stream2.Read(numArray1, 0, ((int) stream2.Length));
                stream2.Close();
                goto Label_019B;
            }
            ArrayList list1 = new ArrayList();
            byte[] numArray2 = new byte[16384];
            int num3 = 0;
            int num4 = 0;
            goto Label_010A;
        Label_00F4:
            num3 += num4;
            list1.Add(numArray2.Clone());
        Label_010A:
            num4 = stream2.Read(numArray2, 0, numArray2.Length);
            if (num4 > 0)
            {
                goto Label_00F4;
            }
            numArray1 = new byte[num3];
            for (num5 = 0; (num5 < list1.Count); num5 += 1)
            {
                numArray3 = ((byte[]) list1[num5]);
                if (num5 != (list1.Count - 1))
                {
                    numArray3.CopyTo(numArray1, (num5 * numArray2.Length));
                }
                else
                {
                    for (num6 = 0; (num6 < (num3 % numArray2.Length)); num6 += 1)
                    {
                        numArray1[(((num5 * numArray2.Length) * (list1.Count - 1)) + num6)] = numArray3[num6];
                    }
                }
            }
        Label_019B:
            num7 = 0;
            while ((num7 < this.Count))
            {
                this.mColors.Add(new PDFIndexedCSDoubleArrayStream(stream1, num7, num1, numArray1, (num7 * num1)));
                num7 += 1;
            }
            return;
        Label_01CC:
            throw new PDFSyntaxException(d, "Invalid Indexed colorsace: Invalid LOOKUP");
        }

        public void Add(params DoubleArray[] val)
        {
            PDFString text1;
            int num2;
            int num3;
            PDFStream stream1;
            Stream stream2;
            int num4;
            int num5;
            PDFObject obj1 = ((PDFArray) this.mDirect)[3];
            int num1 = base.Base.NrOfChannels;
            byte[] numArray1 = new byte[((this.Count + val.Length) * num1)];
            if (obj1.PDFType == PDFObjectType.tPDFString)
            {
                text1 = ((PDFString) obj1);
                Encoding.ASCII.GetBytes(text1.Value).CopyTo(numArray1, 0);
                for (num2 = 0; (num2 < val.Length); num2 += 1)
                {
                    for (num3 = 0; (num3 < num1); num3 += 1)
                    {
                        numArray1[((num2 * num1) + num3)] = ((byte) val[num2][num3]);
                    }
                    this.mColors.Add(new PDFIndexedCSDoubleArrayString(text1, this.Count, num1, numArray1, (this.Count * num1)));
                }
                text1.Value = Encoding.ASCII.GetString(numArray1);
                return;
            }
            if (obj1.PDFType == PDFObjectType.tPDFStream)
            {
                stream1 = ((PDFStream) obj1);
                stream2 = stream1.Decode();
                stream2.Read(numArray1, 0, ((int) stream2.Length));
                stream2.Close();
                for (num4 = 0; (num4 < val.Length); num4 += 1)
                {
                    for (num5 = 0; (num5 < num1); num5 += 1)
                    {
                        numArray1[((num4 * num1) + num5)] = ((byte) val[num4][num5]);
                    }
                    this.mColors.Add(new PDFIndexedCSDoubleArrayStream(stream1, this.Count, num1, numArray1, (this.Count * num1)));
                }
                stream1.Encode(new MemoryStream(numArray1));
                return;
            }
            throw new PDFSyntaxException(this.mDirect, "Invalid Indexed colorsace: Invalid LOOKUP");
        }

        public void Add(params double[][] val)
        {
            PDFString text1;
            int num2;
            int num3;
            PDFStream stream1;
            Stream stream2;
            int num4;
            int num5;
            PDFObject obj1 = ((PDFArray) this.mDirect)[3];
            int num1 = base.Base.NrOfChannels;
            byte[] numArray1 = new byte[((this.Count + val.Length) * num1)];
            if (obj1.PDFType == PDFObjectType.tPDFString)
            {
                text1 = ((PDFString) obj1);
                Encoding.ASCII.GetBytes(text1.Value).CopyTo(numArray1, 0);
                for (num2 = 0; (num2 < val.Length); num2 += 1)
                {
                    for (num3 = 0; (num3 < num1); num3 += 1)
                    {
                        numArray1[((num2 * num1) + num3)] = ((byte) val[num2][num3]);
                    }
                    this.mColors.Add(new PDFIndexedCSDoubleArrayString(text1, this.Count, num1, numArray1, (this.Count * num1)));
                }
                text1.Value = Encoding.ASCII.GetString(numArray1);
                return;
            }
            if (obj1.PDFType == PDFObjectType.tPDFStream)
            {
                stream1 = ((PDFStream) obj1);
                stream2 = stream1.Decode();
                stream2.Read(numArray1, 0, ((int) stream2.Length));
                stream2.Close();
                for (num4 = 0; (num4 < val.Length); num4 += 1)
                {
                    for (num5 = 0; (num5 < num1); num5 += 1)
                    {
                        numArray1[((num4 * num1) + num5)] = ((byte) val[num4][num5]);
                    }
                    this.mColors.Add(new PDFIndexedCSDoubleArrayStream(stream1, this.Count, num1, numArray1, (this.Count * num1)));
                }
                stream1.Encode(new MemoryStream(numArray1, false));
                return;
            }
            throw new PDFSyntaxException(this.mDirect, "Invalid Indexed colorsace: Invalid LOOKUP");
        }

        public void Clear()
        {
            PDFString text1;
            PDFStream stream1;
            PDFObject obj1 = ((PDFArray) this.mDirect)[3];
            this.mColors.Clear();
            if (obj1.PDFType == PDFObjectType.tPDFString)
            {
                text1 = ((PDFString) obj1);
                text1.Value = "";
                return;
            }
            if (obj1.PDFType == PDFObjectType.tPDFStream)
            {
                stream1 = ((PDFStream) obj1);
                stream1.Encode(Stream.Null);
                return;
            }
            throw new PDFSyntaxException(this.mDirect, "Invalid Indexed colorsace: Invalid LOOKUP");
        }

        public void CopyTo(Array array, int index)
        {
            this.mColors.CopyTo(array, index);
        }

        public static ColorSpaceIndexed Create(bool indirect, ColorSpace baseCS)
        {
            PDFArray array1 = Library.CreateArray(4);
            array1[0] = PDF.N("Indexed");
            array1[1] = baseCS.Direct;
            array1[2] = PDF.O(0);
            array1[3] = PDF.O("");
            ColorSpaceIndexed indexed1 = (Resources.Get(array1, typeof(ColorSpaceIndexed)) as ColorSpaceIndexed);
            if (indirect)
            {
                Library.CreateIndirect(indexed1.Direct);
            }
            return indexed1;
        }

        public IEnumerator GetEnumerator()
        {
            return this.mColors.GetEnumerator();
        }

        public void Insert(int index, double[] val)
        {
            byte[] numArray1;
            PDFString text1;
            int num2;
            byte[] numArray2;
            PDFStream stream1;
            Stream stream2;
            int num3;
            int num4;
            PDFObject obj1 = ((PDFArray) this.mDirect)[3];
            int num1 = base.Base.NrOfChannels;
            if (obj1.PDFType == PDFObjectType.tPDFString)
            {
                numArray1 = new byte[val.Length];
                text1 = ((PDFString) obj1);
                for (num2 = 0; (num2 < val.Length); num2 += 1)
                {
                    numArray1[num2] = ((byte) val[num2]);
                }
                text1.Value = text1.Value.Substring(0, (index * num1)) + Encoding.ASCII.GetString(numArray1) + text1.Value.Substring((index * num1));
                this.mColors.Insert(index, new PDFIndexedCSDoubleArrayString(text1, index, num1, numArray1, (index * num1)));
            }
            else if (obj1.PDFType == PDFObjectType.tPDFStream)
            {
                numArray2 = new byte[((this.Count + 1) * num1)];
                stream1 = ((PDFStream) obj1);
                stream2 = stream1.Decode();
                stream2.Read(numArray2, 0, (index * num1));
                for (num3 = 0; (num3 < val.Length); num3 += 1)
                {
                    numArray2[((index * num1) + num3)] = ((byte) val[num3]);
                }
                stream2.Read(numArray2, ((index + 1) * num1), (num1 * (this.Count - index)));
                stream2.Close();
                stream1.Encode(new MemoryStream(numArray2));
                this.mColors.Insert(index, new PDFIndexedCSDoubleArrayStream(stream1, index, num1, numArray2, (index * num1)));
            }
            else
            {
                throw new PDFSyntaxException(this.mDirect, "Invalid Indexed colorsace: Invalid LOOKUP");
            }
            for (num4 = index; (num4 < this.Count); num4 += 1)
            {
                ((PDFIndexedCSDoubleArrayString) this.mColors[num4]).Position = num4;
            }
        }

        public void RemoveAt(int index)
        {
            PDFString text1;
            byte[] numArray1;
            PDFStream stream1;
            Stream stream2;
            int num2;
            PDFObject obj1 = ((PDFArray) this.mDirect)[3];
            int num1 = base.Base.NrOfChannels;
            this.mColors.RemoveAt(index);
            if (obj1.PDFType == PDFObjectType.tPDFString)
            {
                text1 = ((PDFString) obj1);
                text1.Value = text1.Value.Substring(0, (index * num1)) + text1.Value.Substring(((index + 1) * num1));
            }
            else if (obj1.PDFType == PDFObjectType.tPDFStream)
            {
                numArray1 = new byte[((this.Count - 1) * num1)];
                stream1 = ((PDFStream) obj1);
                stream2 = stream1.Decode();
                stream2.Read(numArray1, 0, (index * num1));
                Stream stream3 = stream2;
                stream2.Position = (stream3.Position + ((long) num1));
                stream2.Read(numArray1, (index * num1), (num1 * (this.Count - index)));
                stream2.Close();
                stream1.Encode(new MemoryStream(numArray1));
            }
            else
            {
                throw new PDFSyntaxException(this.mDirect, "Invalid Indexed colorsace: Invalid LOOKUP");
            }
            for (num2 = index; (num2 < this.Count); num2 += 1)
            {
                ((PDFIndexedCSDoubleArrayString) this.mColors[num2]).Position = num2;
            }
        }


        // Properties
        public int Count
        {
            get
            {
                return ((PDFInteger) ((PDFArray) this.mDirect)[2]).Int32Value;
            }
        }

        public bool IsSynchronized
        {
            get
            {
                return true;
            }
        }

        public DoubleArray this[int nr]
        {
            get
            {
                return ((DoubleArray) this.mColors[nr]);
            }
            set
            {
                DoubleArray array1 = ((DoubleArray) this.mColors[nr]);
                array1.Set(value);
            }
        }

        protected override int mBaseCSIndex
        {
            get
            {
                return 1;
            }
        }

        public override int NrOfChannels
        {
            get
            {
                return 1;
            }
        }

        public override string SubType
        {
            get
            {
                return "Indexed";
            }
        }

        public object SyncRoot
        {
            get
            {
                return this;
            }
        }


        // Fields
        private ArrayList mColors;
    }
}

