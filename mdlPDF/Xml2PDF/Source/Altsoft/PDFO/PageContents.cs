namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;
    using System.Collections;
    using System.IO;
    using System.Reflection;

    public class PageContents : ICollection, IEnumerable
    {
        // Methods
        internal PageContents(PDFDict pd)
        {
            this.mPageDict = pd;
        }

        public void AddStream(PDFStream s)
        {
            this.InsertStream(s, this.Count);
        }

        public PDFStream AddStream(Stream s)
        {
            return this.InsertStream(s, this.Count);
        }

        public PDFStream AddStream(string s)
        {
            return this.AddStream(new MemoryStream(Utils.StringToBytes(s)));
        }

        public PDFStream AppendStream(PDFStream s)
        {
            Stream stream2;
            if (this.Count == 0)
            {
                this.AddStream(Stream.Null);
            }
            PDFStream stream1 = this.GetPDFStream(0);
            if (stream1.Dict["Filter"] != null)
            {
                stream2 = stream1.Decode();
                stream1.Dict.Remove("Filter");
                stream1.Dict.Remove("DecodeParms");
                stream1.Encode(stream2);
            }
            return this.AppendStream(s, (this.Count - 1));
        }

        public PDFStream AppendStream(Stream s)
        {
            Stream stream2;
            if (this.Count == 0)
            {
                this.AddStream(Stream.Null);
            }
            PDFStream stream1 = this.GetPDFStream(0);
            if (stream1.Dict["Filter"] != null)
            {
                stream2 = stream1.Decode();
                stream1.Dict.Remove("Filter");
                stream1.Dict.Remove("DecodeParms");
                stream1.Encode(stream2);
            }
            return this.AppendStream(s, (this.Count - 1));
        }

        public PDFStream AppendStream(string s)
        {
            Stream stream2;
            if (this.Count == 0)
            {
                this.AddStream(Stream.Null);
            }
            PDFStream stream1 = this.GetPDFStream(0);
            if (stream1.Dict["Filter"] != null)
            {
                stream2 = stream1.Decode();
                stream1.Dict.Remove("Filter");
                stream1.Dict.Remove("DecodeParms");
                stream1.Encode(stream2);
            }
            return this.AppendStream(s, (this.Count - 1));
        }

        public PDFStream AppendStream(PDFStream s, int nr)
        {
            Stream stream2;
            if (this.Count == 0)
            {
                this.AddStream(Stream.Null);
            }
            PDFStream stream1 = this.GetPDFStream(nr);
            if (stream1.Dict["Filter"] != null)
            {
                stream2 = stream1.Decode();
                stream1.Dict.Remove("Filter");
                stream1.Dict.Remove("DecodeParms");
                stream1.Encode(stream2);
            }
            return this.AppendStream(s.Decode(), nr);
        }

        public PDFStream AppendStream(Stream s, int nr)
        {
            Stream stream2;
            if (this.Count == 0)
            {
                this.AddStream(Stream.Null);
            }
            PDFStream stream1 = this.GetPDFStream(nr);
            if (stream1.Dict["Filter"] != null)
            {
                stream2 = stream1.Decode();
                stream1.Dict.Remove("Filter");
                stream1.Dict.Remove("DecodeParms");
                stream1.Encode(stream2);
            }
            Stream[] streamArray1 = new Stream[2];
            streamArray1[0] = this.GetPDFStream(nr).Decode();
            streamArray1[1] = s;
            this.GetPDFStream(nr).Encode(new InputStreamArray(streamArray1));
            return this.GetPDFStream(nr);
        }

        public PDFStream AppendStream(string s, int nr)
        {
            Stream stream2;
            PDFStream stream1 = this.GetPDFStream(nr);
            if (stream1.Dict["Filter"] != null)
            {
                stream2 = stream1.Decode();
                stream1.Dict.Remove("Filter");
                stream1.Dict.Remove("DecodeParms");
                stream1.Encode(stream2);
            }
            return this.AppendStream(new MemoryStream(Utils.StringToBytes(s)), nr);
        }

        public PDFStream AppendStream(Stream s_before, Stream s_after, int nr)
        {
            Stream stream2;
            InputStreamArray array1;
            Stream[] streamArray1;
            if (this.Count == 0)
            {
                this.AddStream(Stream.Null);
            }
            PDFStream stream1 = this.GetPDFStream(nr);
            if (stream1 == null)
            {
                return null;
            }
            if ((s_before == null) && (s_after == null))
            {
                return stream1;
            }
            if (stream1.Dict["Filter"] != null)
            {
                stream2 = stream1.Decode();
                stream1.Dict.Remove("Filter");
                stream1.Dict.Remove("DecodeParms");
                stream1.Encode(stream2);
            }
            if (s_before != null)
            {
                if (s_after != null)
                {
                    streamArray1 = new Stream[3];
                    streamArray1[0] = s_before;
                    streamArray1[1] = this.GetPDFStream(nr).Decode();
                    streamArray1[2] = s_after;
                    array1 = new InputStreamArray(streamArray1);
                }
                else
                {
                    streamArray1 = new Stream[2];
                    streamArray1[0] = s_before;
                    streamArray1[1] = this.GetPDFStream(nr).Decode();
                    array1 = new InputStreamArray(streamArray1);
                }
            }
            else
            {
                streamArray1 = new Stream[2];
                streamArray1[0] = this.GetPDFStream(nr).Decode();
                streamArray1[1] = s_after;
                array1 = new InputStreamArray(streamArray1);
            }
            this.GetPDFStream(nr).Encode(array1);
            return this.GetPDFStream(nr);
        }

        public PDFStream AppendStream(string s_before, string s_after, int nr)
        {
            MemoryStream stream1 = null;
            MemoryStream stream2 = null;
            if ((s_before != null) && (s_before.Length != 0))
            {
                stream1 = new MemoryStream(Utils.StringToBytes(s_before));
            }
            if ((s_after != null) && (s_after.Length != 0))
            {
                stream2 = new MemoryStream(Utils.StringToBytes(s_after));
            }
            return this.AppendStream(stream1, stream2, nr);
        }

        public void CopyTo(Array array, int index)
        {
            int num1;
            for (num1 = 0; (num1 < this.Count); num1 += 1)
            {
                array.SetValue(this[num1], (index + num1));
            }
        }

        public Stream GetEntireContents()
        {
            Stream[] streamArray1 = new Stream[this.Count];
            this.CopyTo(streamArray1, 0);
            return new InputStreamArray(streamArray1);
        }

        public IEnumerator GetEnumerator()
        {
            return new PageContentsEnumerator(this);
        }

        public PDFStream GetPDFStream(int nr)
        {
            if ((nr < 0) || (nr >= this.Count))
            {
                throw new ArgumentOutOfRangeException("nr", nr, "Stream index out of range");
            }
            PDFObject obj1 = this.mPageDict["Contents"];
            if (obj1.PDFType == PDFObjectType.tPDFStream)
            {
                return ((PDFStream) obj1.Direct);
            }
            return ((PDFStream) ((PDFArray) obj1.Direct)[nr].Direct);
        }

        public void InsertStream(PDFStream s, int nr)
        {
            PDFArray array1;
            PDFObject obj2;
            PDFObject obj1 = this.mPageDict["Contents"];
            if (obj1 == null)
            {
                obj2 = Library.CreateArray(0);
                this.mPageDict["Contents"] = obj2;
                obj1 = obj2;
            }
            if (obj1.PDFType == PDFObjectType.tPDFStream)
            {
                array1 = Library.CreateArray(0);
                if (nr > 1)
                {
                    throw new IndexOutOfRangeException("Invalid contents stream index");
                }
                this.mPageDict["Contents"] = array1;
                array1.Add(((nr == 1) ? obj1 : s));
                array1.Add(((nr == 1) ? s : obj1));
                return;
            }
            if (obj1.PDFType == PDFObjectType.tPDFArray)
            {
                ((PDFArray) obj1).Insert(nr, s);
                return;
            }
            throw new PDFSyntaxException("Invalid CONTENTS entry");
        }

        public PDFStream InsertStream(Stream s, int nr)
        {
            PDFStream stream1 = Library.CreateStream();
            this.InsertStream(stream1, nr);
            stream1.Encode(s);
            return stream1;
        }

        public PDFStream InsertStream(string s, int nr)
        {
            return this.InsertStream(new MemoryStream(Utils.StringToBytes(s)), nr);
        }


        // Properties
        public int Count
        {
            get
            {
                PDFObject obj1 = this.mPageDict["Contents"];
                if (obj1 == null)
                {
                    return 0;
                }
                if (obj1.PDFType == PDFObjectType.tPDFStream)
                {
                    return 1;
                }
                return ((PDFArray) obj1.Direct).Count;
            }
        }

        public bool IsSynchronized
        {
            get
            {
                return false;
            }
        }

        public Stream this[int nr]
        {
            get
            {
                return this.GetPDFStream(nr).Decode();
            }
        }

        public object SyncRoot
        {
            get
            {
                return null;
            }
        }


        // Fields
        private PDFDict mPageDict;
    }
}

