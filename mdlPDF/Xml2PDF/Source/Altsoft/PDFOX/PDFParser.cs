namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;
    using System.IO;

    public class PDFParser : AbstractParser
    {
        // Methods
        public PDFParser(Stream pdfStream, Document doc) : base(pdfStream)
        {
            this.m_doc = doc;
            this.m_iArrCounter = 0;
            this.m_iDictCounter = 0;
        }

        public PDFObject ReadNextObject()
        {
            int num1;
            PDFArray array1;
            PDFObject obj1;
            bool flag1;
            int num2;
            int num3;
            int num4;
            PDFObject obj3;
            PDFObject obj4;
            PDFObject obj5;
            TokenType type1 = base.GetNextToken();
            switch (type1)
            {
                case ((TokenType) 0):
                {
                    goto Label_00DC;
                }
                case ((TokenType) 1):
                {
                    if (this.m_sName == "null")
                    {
                        return Library.CreateNull();
                    }
                    goto Label_009E;
                }
                case ((TokenType) 2):
                case ((TokenType) 11):
                {
                    goto Label_006E;
                }
                case ((TokenType) 3):
                {
                    goto Label_0230;
                }
                case ((TokenType) 4):
                {
                    if (this.m_iDictCounter == 0)
                    {
                        throw new PDFParserException("Invalid end of dict found!");
                    }
                    this.m_iDictCounter -= 1;
                    return Library.CreateDict();
                }
                case ((TokenType) 5):
                {
                    this.m_iArrCounter += 1;
                    num1 = this.m_iArrCounter;
                    array1 = Library.CreateArray(0);
                    flag1 = true;
                    do
                    {
                        obj1 = this.ReadNextObject();
                        if (num1 != this.m_iArrCounter)
                        {
                            flag1 = false;
                        }
                        else if (obj1.PDFType == PDFObjectType.tPDFName)
                        {
                            num2 = array1.Count;
                            if (((((PDFName) obj1).Value == "R") || (((PDFName) obj1).Value == "r")) && (((num2 >= 2) && (array1[(num2 - 1)].PDFType == PDFObjectType.tPDFInteger)) && (array1[(num2 - 2)].PDFType == PDFObjectType.tPDFInteger)))
                            {
                                num3 = ((PDFInteger) array1[(num2 - 2)]).Int32Value;
                                num4 = ((PDFInteger) array1[(num2 - 1)]).Int32Value;
                                array1.Add(this.m_doc.CreateIndirectObject(num3, num4));
                                array1.RemoveAt((num2 - 1));
                                array1.RemoveAt((num2 - 2));
                            }
                            else
                            {
                                array1.Add(obj1);
                            }
                        }
                        else
                        {
                            array1.Add(obj1);
                        }
                    }
                    while (flag1);
                    return array1;
                }
                case ((TokenType) 6):
                {
                    if (this.m_iArrCounter == 0)
                    {
                        throw new PDFParserException("Invalid end of array found!");
                    }
                    this.m_iArrCounter -= 1;
                    return Library.CreateArray(0);
                }
                case ((TokenType) 7):
                {
                    goto Label_00E8;
                }
                case ((TokenType) 8):
                {
                    goto Label_007A;
                }
                case ((TokenType) 9):
                {
                    goto Label_036E;
                }
                case ((TokenType) 10):
                {
                    goto Label_0053;
                }
                case ((TokenType) 12):
                {
                    goto Label_0048;
                }
            }
            goto Label_0379;
        Label_0048:
            throw new PDFParserException("Invalid token encountered");
        Label_0053:
            if (this.SkipComments)
            {
                return this.ReadNextObject();
            }
            return Library.CreateString(this.m_sName);
        Label_006E:
            return Library.CreateString(this.m_sName);
        Label_007A:
            return Library.CreateFixed(this.m_dReal);
        Label_009E:
            if (this.m_sName == "false")
            {
                return Library.CreateBoolean(false);
            }
            if (this.m_sName == "true")
            {
                return Library.CreateBoolean(true);
            }
            return Library.CreateName(this.m_sName);
        Label_00DC:
            return Library.CreateName(this.m_sName);
        Label_00E8:
            return Library.CreateInteger(this.m_iInteger);
        Label_0230:
            this.m_iDictCounter += 1;
            PDFDict dict1 = Library.CreateDict();
            bool flag2 = true;
            PDFObject obj2 = this.ReadNextObject();
        Label_0250:
            if (obj2.PDFType == PDFObjectType.tPDFDict)
            {
                flag2 = false;
            }
            else
            {
                if (obj2.PDFType != PDFObjectType.tPDFName)
                {
                    throw new PDFParserException("Invalid key entry found!");
                }
                obj3 = this.ReadNextObject();
                obj4 = this.ReadNextObject();
                if ((obj4.PDFType == PDFObjectType.tPDFInteger) && (obj3.PDFType == PDFObjectType.tPDFInteger))
                {
                    obj5 = this.ReadNextObject();
                    if ((obj5.PDFType == PDFObjectType.tPDFName) && ((((PDFName) obj5).Value == "R") || (((PDFName) obj5).Value == "r")))
                    {
                        dict1[((PDFName) obj2)] = this.m_doc.CreateIndirectObject(((PDFInteger) obj3).Int32Value, ((PDFInteger) obj4).Int32Value);
                        obj2 = this.ReadNextObject();
                        goto Label_033D;
                    }
                    throw new PDFParserException("Invalid dict entry!");
                }
                dict1[((PDFName) obj2)] = obj3;
                obj2 = obj4;
            }
        Label_033D:
            if (flag2)
            {
                goto Label_0250;
            }
            return dict1;
        Label_036E:
            throw new PDFParserException("Unexpected end of file found!");
        Label_0379:
            throw new PDFParserException("Fatal ERROR!");
        }


        // Fields
        private Document m_doc;
        private int m_iArrCounter;
        private int m_iDictCounter;
    }
}

