namespace C1.Win
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Reflection;
    using System.Windows.Forms;

    internal class ProviderInfo : LicenseProvider
    {
        // Methods
        public ProviderInfo()
        {
        }

        internal static string ChangeString(string s, Control c)
        {
            if ((s == null) || (c == null))
            {
                return "";
            }
            Size size1 = c.Size;
            long num1 = ((long) size1.Height);
            Point point1 = c.Location;
            num1 = ((num1 * ((long) 256)) + ((long) point1.Y));
            size1 = c.Size;
            num1 = ((num1 * ((long) 256)) + ((long) size1.Width));
            point1 = c.Location;
            num1 = ((num1 * ((long) 256)) + ((long) point1.X));
            byte[] numArray1 = ((byte[]) Array.CreateInstance(typeof(byte), 8));
            int num2 = 0;
            while ((num2 < 8))
            {
                numArray1[num2] = ((byte) (num1 & ((long) 15)));
                num1 /= ((long) 16);
                num2 += 1;
            }
            byte[] numArray2 = ((byte[]) Array.CreateInstance(typeof(byte), (s.Length * 2)));
            int num3 = 0;
            for (num2 = 0; (num2 < s.Length); num2 += 1)
            {
                numArray2[num3] = ((byte) ((s[num2] & '\u00ff') ^ numArray1[(num3 % 8)]));
                num3 += 1;
                numArray2[num3] = ((byte) ((s[num2] >> '\b') ^ numArray1[(num3 % 8)]));
                num3 += 1;
            }
            return Convert.ToBase64String(numArray2);
        }

        public override License GetLicense(LicenseContext context, Type type, object instance, bool allowExceptions)
        {
            return 9.20(Assembly.GetExecutingAssembly(), LicenseManager.CurrentContext, type, instance);
        }

        internal static 8 ParseLicenseKey(string licenseKey)
        {
            Assembly assembly1 = Assembly.GetExecutingAssembly();
            1 1 = ((1) Attribute.GetCustomAttribute(assembly1, typeof(1)));
            bool flag1 = 9.1Z(assembly1, LicenseManager.CurrentContext, 1);
            8 2 = 9.21(licenseKey, assembly1, null, flag1);
            2.C3 = ((bool) (flag1 ? 0 : (Assembly.GetEntryAssembly() == null)));
            return 2;
        }

        internal static void ShowAboutBox(object instance)
        {
            9.23(instance);
        }

        internal static 8 Validate(Type type, object instance)
        {
            return 9.22(type, instance);
        }

    }
}

