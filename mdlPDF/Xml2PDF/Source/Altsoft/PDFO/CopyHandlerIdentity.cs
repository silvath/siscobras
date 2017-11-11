namespace Altsoft.PDFO
{
    using System;
    using System.Collections;

    public class CopyHandlerIdentity
    {
        // Methods
        public CopyHandlerIdentity(Document dst)
        {
            this.mIndirects = new Hashtable();
            this.dstDoc = dst;
        }

        protected internal virtual PDFObject CopyHandler(PDFObject src, CopyHandlerDelegate ch)
        {
            PDFIndirect indirect1;
            if (ch != null)
            {
                src = ch.Invoke(this.dstDoc, src);
            }
            if ((src is PDFIndirect))
            {
                if (this.mIndirects[src] == null)
                {
                    indirect1 = this.dstDoc.Indirects.New();
                    this.mIndirects[src] = ((object) indirect1);
                    indirect1.Direct = this.CopyHandlerDirect(src.Direct, ch);
                }
                return (this.mIndirects[src] as PDFObject);
            }
            return this.CopyHandlerDirect(src.Direct, ch);
        }

        protected internal virtual PDFDirect CopyHandlerDirect(PDFDirect src, CopyHandlerDelegate ch)
        {
            PDFObject obj1;
            PDFArray array1;
            PDFArray array2;
            int num1;
            PDFDict dict1;
            PDFDict dict2;
            PDFStream stream1;
            PDFStream stream2;
            if (ch != null)
            {
                obj1 = ch.Invoke(this.dstDoc, src);
                if ((obj1 is PDFDirect))
                {
                    src = ((PDFDirect) obj1);
                }
                else
                {
                    throw new PDFException("Can\'t convert direct into indirect");
                }
            }
            PDFObjectType type1 = src.PDFType;
            switch (type1)
            {
                case PDFObjectType.tPDFNull:
                {
                    goto Label_0155;
                }
                case PDFObjectType.tPDFInteger:
                {
                    goto Label_0133;
                }
                case PDFObjectType.tPDFFixed:
                {
                    goto Label_0122;
                }
                case PDFObjectType.tPDFBoolean:
                {
                    goto Label_00A2;
                }
                case PDFObjectType.tPDFName:
                {
                    goto Label_0144;
                }
                case PDFObjectType.tPDFString:
                {
                    goto Label_01E7;
                }
                case PDFObjectType.tPDFDict:
                {
                    dict1 = (src as PDFDict);
                    dict2 = Library.CreateDict();
                    foreach (PDFName name1 in dict1.Keys)
                    {
                        dict2[name1.Value] = this.CopyHandler(dict1[name1, 0], ch);
                    }
                    return dict2;
                }
                case PDFObjectType.tPDFArray:
                {
                    array1 = (src as PDFArray);
                    array2 = Library.CreateArray(array1.Count);
                    num1 = 0;
                    goto Label_0097;
                }
                case PDFObjectType.tPDFStream:
                {
                    stream1 = (src as PDFStream);
                    stream2 = Library.CreateStream();
                    foreach (PDFName name2 in stream1.Dict.Keys)
                    {
                        stream2.Dict[name2.Value] = this.CopyHandler(stream1.Dict[name2, 0], ch);
                    }
                    stream2.SetRawStream(stream1.Decrypt());
                    return stream2;
                }
            }
            goto Label_01F8;
        Label_007D:
            array2[num1] = this.CopyHandler(array1[num1, 0], ch);
            num1 += 1;
        Label_0097:
            if (num1 < array1.Count)
            {
                goto Label_007D;
            }
            return array2;
        Label_00A2:
            return Library.CreateBoolean((src as PDFBoolean).Value);
        Label_0122:
            return Library.CreateFixed((src as PDFFixed).Value);
        Label_0133:
            return Library.CreateInteger((src as PDFInteger).Value);
        Label_0144:
            return Library.CreateName((src as PDFName).Value);
        Label_0155:
            return Library.CreateNull();
        Label_01E7:
            return Library.CreateString((src as PDFString).Value);
        Label_01F8:
            throw new Exception("Invalid object type");
        }


        // Fields
        private readonly Document dstDoc;
        private Hashtable mIndirects;
    }
}

