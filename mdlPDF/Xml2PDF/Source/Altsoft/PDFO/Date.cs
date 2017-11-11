namespace Altsoft.PDFO
{
    using System;
    using System.Text.RegularExpressions;

    public class Date
    {
        // Methods
        public Date() : this(new DateTime(((long) 0)))
        {
        }

        public Date(PDFString s)
        {
            this.mStr = s;
            this.mDateTime = new DateTime(((long) 0));
            this.ParseString();
        }

        public Date(DateTime dt)
        {
            this.mDateTime = dt;
            this.mStr = Library.CreateString("");
            this.BuildString();
        }

        private void BuildString()
        {
            this.mStr = Library.CreateString(Date.GetPDFString(this.mDateTime));
        }

        public static string GetPDFString(DateTime local_t)
        {
            int num5;
            DateTime time1 = DateTime.UtcNow;
            TimeSpan span1 = DateTime.op_Subtraction(local_t, time1);
            double num1 = span1.TotalMinutes;
            double num2 = 5f;
            int num6 = local_t.Year;
            string text1 = "D:" + num6.ToString();
            text1 = text1 + Date.Int2Str(local_t.Month);
            text1 = text1 + Date.Int2Str(local_t.Day);
            text1 = text1 + Date.Int2Str(local_t.Hour);
            text1 = text1 + Date.Int2Str(local_t.Minute);
            text1 = text1 + Date.Int2Str(local_t.Second);
            if (Math.Abs(num1) < num2)
            {
                return text1 + 90;
            }
            if (num1 < 0f)
            {
                text1 = text1 + 45;
            }
            else
            {
                text1 = text1 + 43;
            }
            int num3 = (((int) (Math.Abs(num1) + num2)) / 60);
            int num4 = ((int) Math.Abs((num1 - ((double) (num3 * 60)))));
            if (((double) num4) < num2)
            {
                num4 = 0;
            }
            else
            {
                num5 = (((int) (((double) num4) + num2)) / 15);
                num4 = (num5 * 15);
            }
            text1 = text1 + Date.Int2Str(num3);
            text1 = text1 + "\'";
            text1 = text1 + Date.Int2Str(num4);
            return text1 + "\'";
        }

        private static string Int2Str(int nr)
        {
            string text1 = nr.ToString();
            if (text1.Length < 2)
            {
                text1 = 48 + text1;
            }
            return text1;
        }

        private void ParseString()
        {
            int num1;
            int num2;
            int num3;
            int num4;
            int num5;
            string text1 = this.mStr.Value;
            if (text1.Substring(0, 2) == "D:")
            {
                text1 = text1.Substring(2);
            }
            if (!new Regex(@"\d\d\d\d").Match(text1).Success)
            {
                throw new InvalidOperationException("Invalid date format - missing year");
            }
            this.mDateTime.Subtract(new TimeSpan(this.mDateTime.Ticks));
            try
            {
                for (num1 = 0; (num1 < 6); num1 += 1)
                {
                    num2 = int.Parse(text1.Substring(0, ((num1 == 0) ? 4 : 2)), NumberStyles.None);
                    num5 = num1;
                    switch (num5)
                    {
                        case 0:
                        {
                            this.mDateTime.AddYears(num2);
                            goto Label_0102;
                        }
                        case 1:
                        {
                            this.mDateTime.AddMonths(num2);
                            goto Label_0102;
                        }
                        case 2:
                        {
                            this.mDateTime.AddDays(((double) num2));
                            goto Label_0102;
                        }
                        case 3:
                        {
                            this.mDateTime.AddHours(((double) num2));
                            goto Label_0102;
                        }
                        case 4:
                        {
                            this.mDateTime.AddMinutes(((double) num2));
                            goto Label_0102;
                        }
                        case 5:
                        {
                            goto Label_00F4;
                        }
                    }
                    goto Label_0102;
                Label_00F4:
                    this.mDateTime.AddSeconds(((double) num2));
                Label_0102:
                    text1 = text1.Substring(((num1 == 0) ? 4 : 2));
                    if (text1.Length == 0)
                    {
                        text1 = ((num1 < 3) ? "01" : "00");
                    }
                }
                if (text1 == "Z")
                {
                    return;
                }
                if (text1 == "")
                {
                    return;
                }
                num3 = int.Parse(text1.Substring(0, 3), NumberStyles.AllowLeadingSign);
                if (text1.Length == 3)
                {
                    return;
                }
                text1 = text1.Substring(4, 2);
                num4 = (int.Parse(text1, NumberStyles.None) * Math.Sign(this.mUTCOffset.Hours));
                this.mUTCOffset = new TimeSpan(0, num3, num4, 0, 0);
            }
            catch (FormatException)
            {
                throw new InvalidOperationException("Invalid date format - invalid numeric format");
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException("Invalid date format");
            }
        }


        // Properties
        public DateTime DateTime
        {
            get
            {
                return this.mDateTime;
            }
            set
            {
                this.mDateTime = value;
                this.BuildString();
            }
        }

        public PDFString PDFString
        {
            get
            {
                return this.mStr;
            }
        }

        public string String
        {
            get
            {
                return this.mStr.Value;
            }
            set
            {
                this.mStr.Value = value;
                this.ParseString();
            }
        }

        public TimeSpan UTCOffset
        {
            get
            {
                return this.mUTCOffset;
            }
            set
            {
                this.mUTCOffset = value;
                this.BuildString();
            }
        }


        // Fields
        private DateTime mDateTime;
        private PDFString mStr;
        private TimeSpan mUTCOffset;
    }
}

