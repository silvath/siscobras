namespace Altsoft.PDFO
{
    using System;
    using System.Collections;

    public class Action : Resource
    {
        // Methods
        public Action(PDFDirect direct) : base(direct)
        {
        }

        internal static Resource Factory(PDFDirect direct)
        {
            string text1;
            if (<PrivateImplementationDetails>.$$method0x6000047-1 == null)
            {
                Hashtable hashtable1 = new Hashtable(34, 0.5f);
                hashtable1.Add("GoTo", 0);
                Hashtable hashtable2 = new Hashtable(34, 0.5f);
                hashtable2.Add("GoToR", 1);
                Hashtable hashtable3 = new Hashtable(34, 0.5f);
                hashtable3.Add("Launch", 2);
                Hashtable hashtable4 = new Hashtable(34, 0.5f);
                hashtable4.Add("Thread", 3);
                Hashtable hashtable5 = new Hashtable(34, 0.5f);
                hashtable5.Add("URI", 4);
                Hashtable hashtable6 = new Hashtable(34, 0.5f);
                hashtable6.Add("Sound", 5);
                Hashtable hashtable7 = new Hashtable(34, 0.5f);
                hashtable7.Add("Movie", 6);
                Hashtable hashtable8 = new Hashtable(34, 0.5f);
                hashtable8.Add("Hide", 7);
                Hashtable hashtable9 = new Hashtable(34, 0.5f);
                hashtable9.Add("Named", 8);
                Hashtable hashtable10 = new Hashtable(34, 0.5f);
                hashtable10.Add("SubmitForm", 9);
                Hashtable hashtable11 = new Hashtable(34, 0.5f);
                hashtable11.Add("ResetForm", 10);
                Hashtable hashtable12 = new Hashtable(34, 0.5f);
                hashtable12.Add("ImportData", 11);
                Hashtable hashtable13 = new Hashtable(34, 0.5f);
                hashtable13.Add("JavaScript", 12);
                Hashtable hashtable14 = new Hashtable(34, 0.5f);
                hashtable14.Add("SetOCGState", 13);
                Hashtable hashtable15 = new Hashtable(34, 0.5f);
                hashtable15.Add("Rendition", 14);
                Hashtable hashtable16 = new Hashtable(34, 0.5f);
                hashtable16.Add("Trans", 15);
                <PrivateImplementationDetails>.$$method0x6000047-1 = new Hashtable(34, 0.5f);
            }
            PDFDict dict1 = (direct as PDFDict);
            if (direct == null)
            {
                return null;
            }
            PDFName name1 = (dict1["S"] as PDFName);
            if (name1 == null)
            {
                throw new Exception("Requiered parameter missed. Action type.");
            }
            object obj1 = name1.Value;
            if (obj1 == null)
            {
                goto Label_02B2;
            }
            obj1 = <PrivateImplementationDetails>.$$method0x6000047-1[obj1];
            if (obj1 == null)
            {
                goto Label_02B2;
            }
            switch (((int) obj1))
            {
                case 0:
                {
                    goto Label_01D3;
                }
                case 1:
                {
                    goto Label_01DA;
                }
                case 2:
                {
                    goto Label_01E1;
                }
                case 3:
                {
                    goto Label_01E8;
                }
                case 4:
                {
                    goto Label_01EF;
                }
                case 5:
                {
                    goto Label_01F6;
                }
                case 6:
                {
                    goto Label_01FD;
                }
                case 7:
                {
                    goto Label_0204;
                }
                case 8:
                {
                    goto Label_020B;
                }
                case 9:
                {
                    goto Label_0281;
                }
                case 10:
                {
                    goto Label_0288;
                }
                case 11:
                {
                    goto Label_028F;
                }
                case 12:
                {
                    goto Label_0296;
                }
                case 13:
                {
                    goto Label_029D;
                }
                case 14:
                {
                    goto Label_02A4;
                }
                case 15:
                {
                    goto Label_02AB;
                }
            }
            goto Label_02B2;
        Label_01D3:
            return new ActionGoto(direct);
        Label_01DA:
            return new ActionGotoR(direct);
        Label_01E1:
            return new ActionLaunch(direct);
        Label_01E8:
            return new ActionThread(direct);
        Label_01EF:
            return new ActionURI(direct);
        Label_01F6:
            return new ActionSound(direct);
        Label_01FD:
            return new ActionMovie(direct);
        Label_0204:
            return new ActionHide(direct);
        Label_020B:
            goto Label_0221;
        Label_0221:
            text1 = (dict1["N"] as PDFName).Value;
            if (text1 == null)
            {
                goto Label_027F;
            }
            text1 = string.IsInterned(text1);
            if (text1 != "FirstPage")
            {
                if (text1 == "LastPage")
                {
                    goto Label_026A;
                }
                if (text1 == "NextPage")
                {
                    goto Label_0271;
                }
                if (text1 == "PrevPage")
                {
                    goto Label_0278;
                }
                goto Label_027F;
            }
            return new ActionFirstPage(direct);
        Label_026A:
            return new ActionLastPage(direct);
        Label_0271:
            return new ActionNextPage(direct);
        Label_0278:
            return new ActionPrevPage(direct);
        Label_027F:
            return null;
        Label_0281:
            return new ActionSubmitForm(direct);
        Label_0288:
            return new ActionResetForm(direct);
        Label_028F:
            return new ActionImportData(direct);
        Label_0296:
            return new ActionJavaScript(direct);
        Label_029D:
            return new ActionSetOCGState(direct);
        Label_02A4:
            return new ActionRendition(direct);
        Label_02AB:
            return new ActionTransition(direct);
        Label_02B2:
            throw new Exception("Unknown action type found");
        }


        // Properties
        public ActionsCollection Next
        {
            get
            {
                if (this.mNext == null)
                {
                    this.mNext = new ActionsCollection(this.Dict);
                }
                return this.mNext;
            }
            set
            {
                this.mNext = value;
                this.Dict["Next"] = this.mNext.Dict;
            }
        }

        public ActionType SubType
        {
            get
            {
                if (<PrivateImplementationDetails>.$$method0x6000049-1 == null)
                {
                    Hashtable hashtable1 = new Hashtable(32, 0.5f);
                    hashtable1.Add("GoTo", 0);
                    Hashtable hashtable2 = new Hashtable(32, 0.5f);
                    hashtable2.Add("GoToR", 1);
                    Hashtable hashtable3 = new Hashtable(32, 0.5f);
                    hashtable3.Add("Launch", 2);
                    Hashtable hashtable4 = new Hashtable(32, 0.5f);
                    hashtable4.Add("Thread", 3);
                    Hashtable hashtable5 = new Hashtable(32, 0.5f);
                    hashtable5.Add("URI", 4);
                    Hashtable hashtable6 = new Hashtable(32, 0.5f);
                    hashtable6.Add("Sound", 5);
                    Hashtable hashtable7 = new Hashtable(32, 0.5f);
                    hashtable7.Add("Movie", 6);
                    Hashtable hashtable8 = new Hashtable(32, 0.5f);
                    hashtable8.Add("Hide", 7);
                    Hashtable hashtable9 = new Hashtable(32, 0.5f);
                    hashtable9.Add("Named", 8);
                    Hashtable hashtable10 = new Hashtable(32, 0.5f);
                    hashtable10.Add("SubmitForm", 9);
                    Hashtable hashtable11 = new Hashtable(32, 0.5f);
                    hashtable11.Add("ResetForm", 10);
                    Hashtable hashtable12 = new Hashtable(32, 0.5f);
                    hashtable12.Add("ImportData", 11);
                    Hashtable hashtable13 = new Hashtable(32, 0.5f);
                    hashtable13.Add("JavaScript", 12);
                    Hashtable hashtable14 = new Hashtable(32, 0.5f);
                    hashtable14.Add("SetOCGState", 13);
                    Hashtable hashtable15 = new Hashtable(32, 0.5f);
                    hashtable15.Add("Rendition", 14);
                    <PrivateImplementationDetails>.$$method0x6000049-1 = new Hashtable(32, 0.5f);
                }
                object obj1 = (this.Dict["S"] as PDFString).Value;
                if (obj1 == null)
                {
                    goto Label_01C3;
                }
                obj1 = <PrivateImplementationDetails>.$$method0x6000049-1[obj1];
                if (obj1 == null)
                {
                    goto Label_01C3;
                }
                switch (((int) obj1))
                {
                    case 0:
                    {
                        goto Label_019F;
                    }
                    case 1:
                    {
                        goto Label_01A1;
                    }
                    case 2:
                    {
                        goto Label_01A3;
                    }
                    case 3:
                    {
                        goto Label_01A5;
                    }
                    case 4:
                    {
                        goto Label_01A7;
                    }
                    case 5:
                    {
                        goto Label_01A9;
                    }
                    case 6:
                    {
                        goto Label_01AB;
                    }
                    case 7:
                    {
                        goto Label_01AD;
                    }
                    case 8:
                    {
                        goto Label_01AF;
                    }
                    case 9:
                    {
                        goto Label_01B1;
                    }
                    case 10:
                    {
                        goto Label_01B4;
                    }
                    case 11:
                    {
                        goto Label_01B7;
                    }
                    case 12:
                    {
                        goto Label_01BA;
                    }
                    case 13:
                    {
                        goto Label_01BD;
                    }
                    case 14:
                    {
                        goto Label_01C0;
                    }
                }
                goto Label_01C3;
            Label_019F:
                return ActionType.GoTo;
            Label_01A1:
                return ActionType.GoToR;
            Label_01A3:
                return ActionType.Launch;
            Label_01A5:
                return ActionType.Thread;
            Label_01A7:
                return ActionType.URI;
            Label_01A9:
                return ActionType.Sound;
            Label_01AB:
                return ActionType.Movie;
            Label_01AD:
                return ActionType.Hide;
            Label_01AF:
                return ActionType.Named;
            Label_01B1:
                return ActionType.SubmitForm;
            Label_01B4:
                return ActionType.ResetForm;
            Label_01B7:
                return ActionType.ImportData;
            Label_01BA:
                return ActionType.JavaScript;
            Label_01BD:
                return ActionType.SetOCGState;
            Label_01C0:
                return ActionType.Rendition;
            Label_01C3:
                throw new Exception("Unknown Action type");
            }
            set
            {
                string text1 = "";
                ActionType type1 = value;
                switch (type1)
                {
                    case ActionType.GoTo:
                    {
                        text1 = "GoTo";
                        goto Label_00C2;
                    }
                    case ActionType.GoToR:
                    {
                        text1 = "GoToR";
                        goto Label_00C2;
                    }
                    case ActionType.Launch:
                    {
                        text1 = "Launch";
                        goto Label_00C2;
                    }
                    case ActionType.Thread:
                    {
                        text1 = "Thread";
                        goto Label_00C2;
                    }
                    case ActionType.URI:
                    {
                        text1 = "URI";
                        goto Label_00C2;
                    }
                    case ActionType.Sound:
                    {
                        text1 = "Sound";
                        goto Label_00C2;
                    }
                    case ActionType.Movie:
                    {
                        text1 = "Movie";
                        goto Label_00C2;
                    }
                    case ActionType.Hide:
                    {
                        text1 = "Hide";
                        goto Label_00C2;
                    }
                    case ActionType.Named:
                    {
                        text1 = "Named";
                        goto Label_00C2;
                    }
                    case ActionType.SubmitForm:
                    {
                        text1 = "SubmitForm";
                        goto Label_00C2;
                    }
                    case ActionType.ResetForm:
                    {
                        text1 = "ResetForm";
                        goto Label_00C2;
                    }
                    case ActionType.ImportData:
                    {
                        text1 = "ImportData";
                        goto Label_00C2;
                    }
                    case ActionType.JavaScript:
                    {
                        text1 = "JavaScript";
                        goto Label_00C2;
                    }
                    case ActionType.SetOCGState:
                    {
                        text1 = "SetOCGState";
                        goto Label_00C2;
                    }
                    case ActionType.Rendition:
                    {
                        goto Label_00BC;
                    }
                }
                goto Label_00C2;
            Label_00BC:
                text1 = "Rendition";
            Label_00C2:
                this.Dict["S"] = Library.CreateString(text1);
            }
        }


        // Fields
        private ActionsCollection mNext;
    }
}

