namespace C1.Util.Localization
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Globalization;
    using System.Windows.Forms;

    internal class G
    {
        // Methods
        static G()
        {
            G.CO = null;
            G.CP = null;
            G.CQ = null;
            G.CR = null;
            G.CS = CultureInfo.CurrentCulture;
        }

        public G()
        {
        }

        internal static string 2I(string 00I)
        {
            if (G.CO == null)
            {
                G.2Q();
            }
            if ((G.CO != null) && G.CO.Contains(00I))
            {
                return ((string) G.CO[00I]);
            }
            return null;
        }

        internal static string 2J(string 00J)
        {
            if (G.CP == null)
            {
                G.2Q();
            }
            if ((G.CP != null) && G.CP.Contains(00J))
            {
                return ((string) G.CP[00J]);
            }
            return null;
        }

        internal static string 2K(string 00K)
        {
            if (G.CQ == null)
            {
                G.2Q();
            }
            if ((G.CQ != null) && G.CQ.Contains(00K))
            {
                return ((string) G.CQ[00K]);
            }
            return 00K;
        }

        internal static void 2L(Control 00L, IContainer 00M)
        {
            Hashtable hashtable1;
            if (G.CR == null)
            {
                G.2Q();
            }
            if ((G.CR != null) && G.CR.Contains(00L.Name))
            {
                hashtable1 = ((Hashtable) G.CR[00L.Name]);
                G.2N(00L, 00M, hashtable1);
            }
        }

        internal static void 2M(Control 00N, IContainer 00O)
        {
            Hashtable hashtable1;
            if (G.CR == null)
            {
                G.2Q();
            }
            if (G.CR == null)
            {
                return;
            }
            Type type1 = 00N.GetType();
            string text1 = 00N.Name;
        Label_0021:
            if (G.CR.Contains(text1))
            {
                hashtable1 = ((Hashtable) G.CR[text1]);
                G.2N(00N, 00O, hashtable1);
            }
            type1 = type1.BaseType;
            if (typeof(Control).IsAssignableFrom(type1))
            {
                text1 = type1.FullName.Replace(type1.Namespace + ".", "");
                goto Label_0021;
            }
        }

        internal static void 2N(Control 00P, IContainer 00Q, Hashtable 00R)
        {
            ToolTip tip1;
            LinkLabel label1;
            int num1;
            int num2;
            TabPage page1;
            string text1 = G.2P(00P.Text, 00R);
            if (text1 != null)
            {
                00P.Text = text1;
            }
            if (00P.ContextMenu != null)
            {
                G.2O(00P.ContextMenu.MenuItems, 00R);
            }
            if (00Q != null)
            {
                foreach (Component component1 in 00Q.Components)
                {
                    tip1 = null;
                    if ((component1 is ToolTip))
                    {
                        tip1 = ((ToolTip) component1);
                    }
                    if (tip1 == null)
                    {
                        continue;
                    }
                    text1 = tip1.GetToolTip(00P);
                    text1 = G.2P(text1, 00R);
                    if (text1 == null)
                    {
                        continue;
                    }
                    tip1.SetToolTip(00P, text1);
                }
            }
            if ((00P is LinkLabel))
            {
                text1 = 00P.Text;
                label1 = null;
                if ((00P is LinkLabel))
                {
                    label1 = ((LinkLabel) 00P);
                }
                num1 = text1.IndexOf('<');
                num2 = text1.IndexOf('>');
                if (((num1 > -1) && (num2 > -1)) && (num2 > num1))
                {
                    text1 = text1.Replace("<", "");
                    text1 = text1.Replace(">", "");
                    label1.Text = text1;
                    label1.LinkArea = new LinkArea(num1, ((num2 - num1) - 1));
                }
                else
                {
                    label1.LinkArea = new LinkArea(0, text1.Length);
                }
            }
            if ((00P is ToolBar))
            {
                foreach (ToolBarButton button1 in ((ToolBar) 00P).Buttons)
                {
                    text1 = G.2P(button1.Text, 00R);
                    if (text1 != null)
                    {
                        button1.Text = text1;
                    }
                    text1 = G.2P(button1.ToolTipText, 00R);
                    if (text1 == null)
                    {
                        continue;
                    }
                    button1.ToolTipText = text1;
                }
            }
            if ((00P is TabPage))
            {
                page1 = null;
                if ((00P is TabPage))
                {
                    page1 = ((TabPage) 00P);
                }
                text1 = G.2P(page1.ToolTipText, 00R);
                if (text1 != null)
                {
                    page1.ToolTipText = text1;
                }
            }
            Form form1 = (00P as Form);
            if ((form1 != null) && (form1.Menu != null))
            {
                G.2O(form1.Menu.MenuItems, 00R);
            }
            foreach (Control control1 in 00P.Controls)
            {
                G.2N(control1, 00Q, 00R);
            }
        }

        internal static void 2O(MenuItemCollection 00S, Hashtable 00T)
        {
            string text1;
            foreach (MenuItem item1 in 00S)
            {
                text1 = G.2P(item1.Text, 00T);
                if (text1 != null)
                {
                    item1.Text = text1;
                }
                if (item1.MenuItems == null)
                {
                    continue;
                }
                G.2O(item1.MenuItems, 00T);
            }
        }

        internal static string 2P(string 00U, Hashtable 00V)
        {
            if ((00U == null) || (00U.Length == 0))
            {
                return null;
            }
            return ((string) 00V[00U]);
        }

        private static void 2Q()
        {
            Hashtable hashtable1;
            Hashtable hashtable2;
            G.CO = new Hashtable();
            G.CP = new Hashtable();
            G.CQ = new Hashtable();
            G.CR = new Hashtable();
            string text1 = G.CS.Name;
            if (text1.StartsWith("de"))
            {
                hashtable1 = new Hashtable();
                hashtable1.Add("About {0}", "Info zu {0}");
                hashtable1.Add("Check for online updates", "Suche nach Online-Updates");
                hashtable1.Add("Click here if you purchased the product and already have a license key.", "Klicken Sie hier, wenn Sie das Produkt gekauft haben und bereits \u00fcber einen Lizenzschl\u00fcssel verf\u00fcgen.");
                hashtable1.Add("Click here to buy a copy of the product. After you purchase, you should license and register it.", "Klicken Sie hier, um eine Kopie des Produkts zu kaufen. Nachdem Sie es gekauft haben, sollten Sie es lizenzieren und registrieren.");
                hashtable1.Add("Click here to register online (so we can send you quarterly updates).", "Klicken Sie hier, um sich online zu registrieren (damit wir Ihnen die Quartals-Updates schicken k\u00f6nnen).");
                hashtable1.Add("ComponentOne Technical Support", "ComponentOne Technischer Support");
                hashtable1.Add("Contact Us", "Kontaktieren Sie uns");
                hashtable1.Add("Copy URL", "URL kopieren");
                hashtable1.Add("Copyright (C) 2001{0} ComponentOne LLC. All rights reserved.", "Copyright (C) 2001{0} ComponentOne LLC. All rights reserved.");
                hashtable1.Add("For email support, please write to:", "F\u00fcr Support per Email schreiben Sie bitte an:");
                hashtable1.Add("License", "Lizenz");
                hashtable1.Add("Newsgroup", "Newsgroup");
                hashtable1.Add("NOT LICENSED. THIS IS AN EVALUATION VERSION", "NICHT LIZENZIERT. DIES IST EINE TESTVERSION. Sie k\u00f6nnen");
                hashtable1.Add("Online Resources:", "Online Resourcen:");
                hashtable1.Add("Please check our web site for a new version.", "Bitte erkundigen Sie sich auf unserer Website nach einer neuen Version.");
                hashtable1.Add("Purchase", "Kaufen");
                hashtable1.Add("Register", "Registrieren");
                hashtable1.Add("Renew your subscription to get a new license key, or keep using the components released while your subscription was valid.", "Verl\u00e4ngern Sie Ihr Abonnement, um einen neuen Lizenzschl\u00fcssel zu bekommen; oder verwenden\r\nSie weiterhin die Komponenten, die ver\u00f6ffentlicht wurden, w\u00e4hrend Ihr Abonnement noch lief.");
                hashtable1.Add("Resellers", "Fachh\u00e4ndler");
                hashtable1.Add("using a licensed version of this product.", "Verwendung einer lizenzierten Version dieses Produktes rekompilieren.");
                hashtable1.Add("This dialog box will not be shown if you recompile the program", "Dieses Dialogfenster wird nicht angezeigt, wenn Sie das Programm unter");
                hashtable1.Add("This evaluation version has expired.", "Diese Testversion ist abgelaufen.");
                hashtable1.Add("This product is included in ComponentOne Studio(TM) for .NET", "Dieses Produkt ist Bestandteil von ComponentOne Studio(TM) for .NET");
                hashtable1.Add("This product is licensed to:", "Dieses Produkt ist lizenziert f\u00fcr:");
                hashtable1.Add("You can use this product for a 30-day trial period.", "dieses Produkt w\u00e4hrend einer 30-t\u00e4gigen Testphase verwenden.");
                hashtable1.Add("Your subscription has expired since Q{0} {1}.", "Ihr Abonnement ist abgelaufen seit Q{0} {1}.");
                hashtable1.Add("Web Store", "Online-Shop");
                G.CR.Add("AboutForm", hashtable1);
                hashtable2 = new Hashtable();
                hashtable2.Add("Cancel", "Abbrechen");
                hashtable2.Add("Company Name field cannot be empty.", "Das Firmennamen-Feld darf nicht leer sein.");
                hashtable2.Add("Company Name is too long.", "Der Firmenname ist zu lang.");
                hashtable2.Add("Company:", "Firma:");
                hashtable2.Add("ComponentOne Licensing Form", "ComponentOne Lizenzierungs-Formular");
                hashtable2.Add("Congratulations", "Herzlichen Gl\u00fcckwunsch");
                hashtable2.Add("Copy URL", "URL kopieren");
                hashtable2.Add("Customer Name field cannot be empty.", "Das Kundenname-Feld darf nicht leer sein.");
                hashtable2.Add("Customer Name is too long.", "Der Kundenname ist zu lang.");
                hashtable2.Add("Name:", "Name:");
                hashtable2.Add("OK", "OK");
                hashtable2.Add("Please read the END-USER LICENSE AGREEMENT before proceeding.", "Bitte lesen Sie das <END-USER LICENSE AGREEMENT> bevor Sie fortfahren.");
                hashtable2.Add("S/N:", "S/N:");
                hashtable2.Add("Sorry, this serial number has expired. You can still use\r\nthe previous builds with the current license, or renew\r\nyour subscription to get a new license key.", "Diese Seriennummer ist leider abgelaufen. Sie k\u00f6nnen mit Ihrer Lizenz weiterhin\r\ndie fr\u00fcheren Versionen verwenden oder Ihr Abonnement verl\u00e4ngern, um einen\r\nneuen Lizenzierungsschl\u00fcssel zu bekommen.");
                hashtable2.Add("Studio or product serial number:", "Seriennummer des Studios oder eines Einzelprodukts:");
                hashtable2.Add("The specified serial number is not valid.", "Die eingegebene Seriennummer ist nicht g\u00fcltig.");
                hashtable2.Add("This license key is older than the one currently installed.\r\nYou cannot replace new key with the old one because\r\nsome new products may become unlicensed.", "Dieser Lizenzierungsschl\u00fcssel ist \u00e4lter als der momentan installierte. Sie k\u00f6nnen\r\neinen neuen Schl\u00fcssel nicht mit einem \u00e4lteren ersetzen, da sonst neuere Produkte\r\nnicht mehr lizenziert sein k\u00f6nnten.");
                hashtable2.Add("You have licensed {0} !", "Sie haben {0} lizenziert!");
                hashtable2.Add("Your personal information:", "Ihre pers\u00f6nlichen Informationen:");
                G.CR.Add("LicensingForm", hashtable2);
            }
            H.2S(G.CO, G.CP, G.CQ, G.CR, text1);
        }


        // Fields
        private static Hashtable CO;
        private static Hashtable CP;
        private static Hashtable CQ;
        private static Hashtable CR;
        internal static CultureInfo CS;
    }
}

