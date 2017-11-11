namespace Altsoft.PDFO
{
    using System;

    public class MediaPlayers : Resource
    {
        // Methods
        public MediaPlayers(PDFDirect direct) : base(direct)
        {
            this.mMU = null;
            this.mA = null;
            this.mNU = null;
        }

        public static MediaPlayers Create()
        {
            return MediaPlayers.Create(true);
        }

        public static MediaPlayers Create(bool indirect)
        {
            PDFDict dict1 = Library.CreateDict();
            if (indirect)
            {
                Library.CreateIndirect(dict1);
            }
            return new MediaPlayers(dict1);
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new MediaPlayers(direct);
        }


        // Properties
        public MediaPlayerInfoCollection MayBeUsed
        {
            get
            {
                if (this.mA != null)
                {
                    return this.mA;
                }
                return new MediaPlayerInfoCollection(this.Dict, "A", false);
            }
            set
            {
                this.mA = value;
                this.Dict["A"] = value.mBaseDict[value.mBaseKeyName];
            }
        }

        public MediaPlayerInfoCollection MustUsed
        {
            get
            {
                if (this.mMU != null)
                {
                    return this.mMU;
                }
                return new MediaPlayerInfoCollection(this.Dict, "MU", false);
            }
            set
            {
                this.mMU = value;
                this.Dict["MU"] = value.mBaseDict[value.mBaseKeyName];
            }
        }

        public MediaPlayerInfoCollection NotUsed
        {
            get
            {
                if (this.mNU != null)
                {
                    return this.mNU;
                }
                return new MediaPlayerInfoCollection(this.Dict, "NU", false);
            }
            set
            {
                this.mNU = value;
                this.Dict["NU"] = value.mBaseDict[value.mBaseKeyName];
            }
        }


        // Fields
        private MediaPlayerInfoCollection mA;
        private MediaPlayerInfoCollection mMU;
        private MediaPlayerInfoCollection mNU;
        public const string Type = "MediaPlayers";
    }
}

