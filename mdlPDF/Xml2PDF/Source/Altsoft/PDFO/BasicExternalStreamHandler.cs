namespace Altsoft.PDFO
{
    using System;
    using System.IO;

    public class BasicExternalStreamHandler : IExternalStreamHandler
    {
        // Methods
        static BasicExternalStreamHandler()
        {
            BasicExternalStreamHandler.Instance = new BasicExternalStreamHandler();
        }

        private BasicExternalStreamHandler()
        {
        }

        public Stream GetReadStream(Document doc, FileSpec fs)
        {
            string text1 = Path.GetDirectoryName(doc.Path);
            string text2 = fs.Path;
            if (File.Exists(text2))
            {
                return File.OpenRead(text2);
            }
            text2 = text1 + Path.DirectorySeparatorChar + fs.Path;
            if (File.Exists(text2))
            {
                return File.OpenRead(text2);
            }
            return Stream.Null;
        }

        public void WriteStream(Document doc, FileSpec fs, Stream stm)
        {
            string text1 = Path.GetDirectoryName(doc.Path);
            string text2 = text1 + Path.DirectorySeparatorChar + fs.Path;
            Stream stream1 = File.Open(text2, FileMode.Create, FileAccess.Write, FileShare.Read);
            byte[] numArray1 = new byte[4096];
            int num1 = 0;
            goto Label_0047;
        Label_003D:
            stream1.Write(numArray1, 0, num1);
        Label_0047:
            num1 = stm.Read(numArray1, 0, numArray1.Length);
            if (num1 != 0)
            {
                goto Label_003D;
            }
            stream1.Close();
        }


        // Fields
        public static readonly BasicExternalStreamHandler Instance;
    }
}

