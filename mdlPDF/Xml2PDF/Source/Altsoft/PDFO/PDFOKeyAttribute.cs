namespace Altsoft.PDFO
{
    using System;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Soap;

    [AttributeUsage(AttributeTargets.Assembly)]
    public class PDFOKeyAttribute : Attribute
    {
        // Methods
        public PDFOKeyAttribute(string _key)
        {
            MemoryStream stream1;
            try
            {
                _key = "<SOAP-ENV:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:SOAP-ENC=\"http://schemas.xmlsoap.org/soap/encoding/\" xmlns:SOAP-ENV=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:clr=\"http://schemas.microsoft.com/soap/encoding/clr/1.0\" SOAP-ENV:encodingStyle=\"http://schemas.xmlsoap.org/soap/encoding/\"><SOAP-ENV:Body><SOAP-ENC:Array xsi:type=\"SOAP-ENC:base64\">" + _key;
                _key = _key + "</SOAP-ENC:Array></SOAP-ENV:Body></SOAP-ENV:Envelope>";
                stream1 = new MemoryStream(Encoding.ASCII.GetBytes(_key));
                this.Key = ((byte[]) new SoapFormatter().Deserialize(stream1));
            }
            catch
            {
                this.Key = new byte[1];
            }
        }


        // Fields
        public readonly byte[] Key;
    }
}

