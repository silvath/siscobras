namespace Altsoft.PDFO
{
    using System;

    public class ActionSound : Action
    {
        // Methods
        public ActionSound(PDFDirect direct) : base(direct)
        {
        }

        public static ActionSound Create(Sound Sound)
        {
            ActionSound sound1 = ActionSound.Create(true);
            sound1.SoundObj = Sound;
            return sound1;
        }

        private static ActionSound Create(bool indirect)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["S"] = Library.CreateName("Sound");
            ActionSound sound1 = (Resources.Get(dict1, typeof(ActionSound)) as ActionSound);
            if (indirect)
            {
                Library.CreateIndirect(dict1);
            }
            return sound1;
        }

        public static ActionSound Create(bool indirect, Sound Sound)
        {
            ActionSound sound1 = ActionSound.Create(indirect);
            sound1.SoundObj = Sound;
            return sound1;
        }

        public static ActionSound Create(Sound Sound, double volume, bool sync, bool repeat, bool mix)
        {
            ActionSound sound1 = ActionSound.Create(true);
            sound1.SoundObj = Sound;
            sound1.Volume = volume;
            sound1.Synchronous = sync;
            sound1.Repeat = repeat;
            sound1.Mix = mix;
            return sound1;
        }

        public static ActionSound Create(bool indirect, Sound Sound, double volume, bool sync, bool repeat, bool mix)
        {
            ActionSound sound1 = ActionSound.Create(indirect);
            sound1.SoundObj = Sound;
            sound1.Volume = volume;
            sound1.Synchronous = sync;
            sound1.Repeat = repeat;
            sound1.Mix = mix;
            return sound1;
        }


        // Properties
        public bool Mix
        {
            get
            {
                PDFBoolean flag1 = (this.Dict["Mix"] as PDFBoolean);
                if (flag1 == null)
                {
                    return false;
                }
                return flag1.Value;
            }
            set
            {
                this.Dict["Mix"] = Library.CreateBoolean(value);
            }
        }

        public bool Repeat
        {
            get
            {
                PDFBoolean flag1 = (this.Dict["Repeat"] as PDFBoolean);
                if (flag1 == null)
                {
                    return false;
                }
                return flag1.Value;
            }
            set
            {
                this.Dict["Repeat"] = Library.CreateBoolean(value);
            }
        }

        public Sound SoundObj
        {
            get
            {
                PDFStream stream1 = (this.Dict["Sound"] as PDFStream);
                if (stream1 == null)
                {
                    return null;
                }
                return (Resources.Get(stream1, typeof(Sound)) as Sound);
            }
            set
            {
                this.Dict["Sound"] = value.Direct;
            }
        }

        public bool Synchronous
        {
            get
            {
                PDFBoolean flag1 = (this.Dict["Synchronous"] as PDFBoolean);
                if (flag1 == null)
                {
                    return false;
                }
                return flag1.Value;
            }
            set
            {
                this.Dict["Synchronous"] = Library.CreateBoolean(value);
            }
        }

        public double Volume
        {
            get
            {
                PDFFixed fixed1 = (this.Dict["Volume"] as PDFFixed);
                if (fixed1 == null)
                {
                    return 1f;
                }
                if ((fixed1.Value < -1f) || (fixed1.Value > 1f))
                {
                    throw new Exception("Illegal volume value");
                }
                return fixed1.Value;
            }
            set
            {
                if ((value < -1f) || (value > 1f))
                {
                    throw new Exception("Illegal volume value");
                }
                this.Dict["Volume"] = Library.CreateFixed(value);
            }
        }


        // Fields
        public const string Type = "Sound";
    }
}

