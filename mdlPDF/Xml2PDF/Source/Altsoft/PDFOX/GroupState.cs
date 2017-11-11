namespace Altsoft.PDFO
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class GroupState : Resource, ICollection, IEnumerable
    {
        // Methods
        public GroupState(PDFDirect direct) : base(direct)
        {
            this.mInternalArr = (direct as PDFArray);
        }

        public void Add(OptionalContent value)
        {
            this[this.Count] = value;
        }

        public void CopyTo(Array arr, int offset)
        {
        }

        internal static Resource Factory(PDFDirect d)
        {
            return new GroupState(d);
        }

        public IEnumerator GetEnumerator()
        {
            return new GroupStateEnumerator(this);
        }

        public int ObjectIndex(PDFArray arr)
        {
            int num1;
            for (num1 = 1; (num1 < (this.mInternalArr.Count + 1)); num1 += 1)
            {
                if (this.mInternalArr[num1] == arr)
                {
                    return (num1 - 1);
                }
            }
            return -1;
        }

        public void Remove(OptionalContent value)
        {
            this.mInternalArr.Remove(value.Direct);
        }

        public void RemoveAt(int index)
        {
            this.mInternalArr.RemoveAt((index + 1));
        }


        // Properties
        public int Count
        {
            get
            {
                return (this.mInternalArr.Count - 1);
            }
        }

        public bool IsSynchronized
        {
            get
            {
                return true;
            }
        }

        public OptionalContent this[int index]
        {
            get
            {
                return (Resources.Get(this.mInternalArr[(index + 1)], typeof(OptionalContent)) as OptionalContent);
            }
            set
            {
                this.mInternalArr[(index + 1)] = value.Direct;
            }
        }

        public EOCGState State
        {
            get
            {
                string text1 = (this.mInternalArr[0] as PDFName).Value;
                if (text1 == null)
                {
                    goto Label_0052;
                }
                text1 = string.IsInterned(text1);
                if (text1 != "Off")
                {
                    if (text1 == "On")
                    {
                        goto Label_004E;
                    }
                    if (text1 == "Toggle")
                    {
                        goto Label_0050;
                    }
                    goto Label_0052;
                }
                return EOCGState.Off;
            Label_004E:
                return EOCGState.On;
            Label_0050:
                return EOCGState.Toggle;
            Label_0052:
                throw new Exception("Unknown OCG-state found");
            }
            set
            {
                string text1 = "";
                EOCGState state1 = value;
                switch (state1)
                {
                    case EOCGState.On:
                    {
                        text1 = "On";
                        goto Label_0032;
                    }
                    case EOCGState.Off:
                    {
                        text1 = "Off";
                        goto Label_0032;
                    }
                    case EOCGState.Toggle:
                    {
                        goto Label_002C;
                    }
                }
                goto Label_0032;
            Label_002C:
                text1 = "Toggle";
            Label_0032:
                this.mInternalArr[0] = Library.CreateName(text1);
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
        private PDFArray mInternalArr;

        // Nested Types
        private class GroupStateEnumerator : IEnumerator
        {
            // Methods
            internal GroupStateEnumerator(GroupState coll)
            {
                this.mCurr = 1;
                this.mColl = coll;
            }

            public bool MoveNext()
            {
                int num1 = (this.mCurr + 1);
                this.mCurr = num1;
                if (num1 >= (this.mColl.Count + 1))
                {
                    return false;
                }
                return true;
            }

            public void Reset()
            {
                this.mCurr = 1;
            }


            // Properties
            public object Current
            {
                get
                {
                    return this.mColl[this.mCurr];
                }
            }


            // Fields
            private GroupState mColl;
            private int mCurr;
        }
    }
}

