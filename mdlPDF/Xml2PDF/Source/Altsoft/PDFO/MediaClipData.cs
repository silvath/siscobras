namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;

    public class MediaClipData : MediaClipBase
    {
        // Methods
        public MediaClipData(PDFDirect direct) : base(direct)
        {
        }

        public static MediaClipData Create(FileSpec filespec)
        {
            MediaClipData data1 = MediaClipData.Create(true);
            data1.ExtMediaData = filespec;
            return data1;
        }

        public static MediaClipData Create(XObjectForm data)
        {
            MediaClipData data1 = MediaClipData.Create(true);
            data1.MediaData = data;
            return data1;
        }

        private static MediaClipData Create(bool indirect)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["S"] = Library.CreateName("MCD");
            MediaClipData data1 = (Resources.Get(dict1, typeof(MediaClipData)) as MediaClipData);
            if (indirect)
            {
                Library.CreateIndirect(dict1);
            }
            return data1;
        }

        public static MediaClipData Create(PDFStream str, Rect rect)
        {
            MediaClipData data1 = MediaClipData.Create(true);
            data1.MediaData = XObjectForm.Create(str, rect);
            return data1;
        }

        public static MediaClipData Create(bool indirect, FileSpec filespec)
        {
            MediaClipData data1 = MediaClipData.Create(indirect);
            data1.ExtMediaData = filespec;
            return data1;
        }

        public static MediaClipData Create(bool indirect, XObjectForm data)
        {
            MediaClipData data1 = MediaClipData.Create(indirect);
            data1.MediaData = data;
            return data1;
        }


        // Properties
        public MCD_MHBE BE
        {
            get
            {
                PDFDict dict1 = (this.Dict["BE"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(MCD_MHBE)) as MCD_MHBE);
            }
            set
            {
                this.Dict["BE"] = value.Dict;
            }
        }

        public string ExtDataType
        {
            get
            {
                PDFString text1 = (this.Dict["CT"] as PDFString);
                if (text1 == null)
                {
                    return null;
                }
                return text1.Value;
            }
            set
            {
                this.Dict["CT"] = Library.CreateString(value);
            }
        }

        public FileSpec ExtMediaData
        {
            get
            {
                PDFStream stream1 = (this.Dict["D"] as PDFStream);
                if (stream1 != null)
                {
                    return null;
                }
                return (Resources.Get((this.Dict["D"] as PDFDirect), typeof(FileSpec)) as FileSpec);
            }
            set
            {
                this.Dict["D"] = value.Direct;
            }
        }

        public XObjectForm MediaData
        {
            get
            {
                PDFStream stream1 = (this.Dict["D"] as PDFStream);
                if (stream1 == null)
                {
                    return null;
                }
                return (Resources.Get(stream1.Dict, typeof(XObjectForm)) as XObjectForm);
            }
            set
            {
                this.Dict["D"] = value.Direct;
            }
        }

        public MediaPermissions MediaPermissions
        {
            get
            {
                PDFDict dict1 = (this.Dict["P"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(MediaPermissions)) as MediaPermissions);
            }
            set
            {
                this.Dict["P"] = value.Direct;
            }
        }

        public MediaPlayers MediaPlayers
        {
            get
            {
                PDFDict dict1 = (this.Dict["PL"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(MediaPlayers)) as MediaPlayers);
            }
            set
            {
                this.Dict["PL"] = value.Dict;
            }
        }

        public MCD_MHBE MH
        {
            get
            {
                PDFDict dict1 = (this.Dict["MH"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(MCD_MHBE)) as MCD_MHBE);
            }
            set
            {
                this.Dict["MH"] = value.Dict;
            }
        }

    }
}

