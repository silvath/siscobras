namespace C1.C1Zip.ZLib
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    internal class U : ApplicationException
    {
        // Methods
        public U()
        {
        }

        public U(string msg) : base(msg)
        {
        }

        protected U(SerializationInfo si, StreamingContext sc) : base(si, sc)
        {
        }

        public U(string msg, Exception x) : base(msg, x)
        {
        }

    }
}

