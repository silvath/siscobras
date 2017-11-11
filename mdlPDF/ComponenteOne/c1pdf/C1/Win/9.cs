namespace C1.Win
{
    using Microsoft.Win32;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Globalization;
    using System.IO;
    using System.Reflection;
    using System.Reflection.Emit;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Security;
    using System.Security.Permissions;
    using System.Text;

    internal class 9
    {
        // Methods
        static 9()
        {
            int num1;
            9.C5 = false;
            9.C6 = null;
            9.C7 = null;
            9.C8 = null;
            9.C9 = null;
            9.CA = 0;
            9.CB = new uint[256] { 0, 49345, 49537, 320, 49921, 960, 640, 49729, 50689, 1728, 1920, 51009, 1280, 50625, 50305, 1088, 52225, 3264, 3456, 52545, 3840, 53185, 52865, 3648, 2560, 51905, 52097, 2880, 51457, 2496, 2176, 51265, 55297, 6336, 6528, 55617, 6912, 56257, 55937, 6720, 7680, 57025, 57217, 8000, 56577, 7616, 7296, 56385, 5120, 54465, 54657, 5440, 55041, 6080, 5760, 54849, 53761, 4800, 4992, 54081, 4352, 53697, 53377, 4160, 61441, 12480, 12672, 61761, 13056, 62401, 62081, 12864, 13824, 63169, 63361, 14144, 62721, 13760, 13440, 62529, 15360, 64705, 64897, 15680, 65281, 16320, 16000, 65089, 64001, 15040, 15232, 64321, 14592, 63937, 63617, 14400, 10240, 59585, 59777, 10560, 60161, 11200, 10880, 59969, 60929, 11968, 12160, 61249, 11520, 60865, 60545, 11328, 58369, 9408, 9600, 58689, 9984, 59329, 59009, 9792, 8704, 58049, 58241, 9024, 57601, 8640, 8320, 57409, 40961, 24768, 24960, 41281, 25344, 41921, 41601, 25152, 26112, 42689, 42881, 26432, 42241, 26048, 25728, 42049, 27648, 44225, 44417, 27968, 44801, 28608, 28288, 44609, 43521, 27328, 27520, 43841, 26880, 43457, 43137, 26688, 30720, 47297, 47489, 31040, 47873, 31680, 31360, 47681, 48641, 32448, 32640, 48961, 32000, 48577, 48257, 31808, 46081, 29888, 30080, 46401, 30464, 47041, 46721, 30272, 29184, 45761, 45953, 29504, 45313, 29120, 28800, 45121, 20480, 37057, 37249, 20800, 37633, 21440, 21120, 37441, 38401, 22208, 22400, 38721, 21760, 38337, 38017, 21568, 39937, 23744, 23936, 40257, 24320, 40897, 40577, 24128, 23040, 39617, 39809, 23360, 39169, 22976, 22656, 38977, 34817, 18624, 18816, 35137, 19200, 35777, 35457, 19008, 19968, 36545, 36737, 20288, 36097, 19904, 19584, 35905, 17408, 33985, 34177, 17728, 34561, 18368, 18048, 34369, 33281, 17088, 17280, 33601, 16640, 33217, 32897, 16448 };
            9.CC = new uint[256] { 0, 1996959894, 3993919788, 2567524794, 124634137, 1886057615, 3915621685, 2657392035, 249268274, 2044508324, 3772115230, 2547177864, 162941995, 2125561021, 3887607047, 2428444049, 498536548, 1789927666, 4089016648, 2227061214, 450548861, 1843258603, 4107580753, 2211677639, 325883990, 1684777152, 4251122042, 2321926636, 335633487, 1661365465, 4195302755, 2366115317, 997073096, 1281953886, 3579855332, 2724688242, 1006888145, 1258607687, 3524101629, 2768942443, 901097722, 1119000684, 3686517206, 2898065728, 853044451, 1172266101, 3705015759, 2882616665, 651767980, 1373503546, 3369554304, 3218104598, 565507253, 1454621731, 3485111705, 3099436303, 671266974, 1594198024, 3322730930, 2970347812, 795835527, 1483230225, 3244367275, 3060149565, 1994146192, 31158534, 2563907772, 4023717930, 1907459465, 112637215, 2680153253, 3904427059, 2013776290, 251722036, 2517215374, 3775830040, 2137656763, 141376813, 2439277719, 3865271297, 1802195444, 476864866, 2238001368, 4066508878, 1812370925, 453092731, 2181625025, 4111451223, 1706088902, 314042704, 2344532202, 4240017532, 1658658271, 366619977, 2362670323, 4224994405, 1303535960, 984961486, 2747007092, 3569037538, 1256170817, 1037604311, 2765210733, 3554079995, 1131014506, 879679996, 2909243462, 3663771856, 1141124467, 855842277, 2852801631, 3708648649, 1342533948, 654459306, 3188396048, 3373015174, 1466479909, 544179635, 3110523913, 3462522015, 1591671054, 702138776, 2966460450, 3352799412, 1504918807, 783551873, 3082640443, 3233442989, 3988292384, 2596254646, 62317068, 1957810842, 3939845945, 2647816111, 81470997, 1943803523, 3814918930, 2489596804, 225274430, 2053790376, 3826175755, 2466906013, 167816743, 2097651377, 4027552580, 2265490386, 503444072, 1762050814, 4150417245, 2154129355, 426522225, 1852507879, 4275313526, 2312317920, 282753626, 1742555852, 4189708143, 2394877945, 397917763, 1622183637, 3604390888, 2714866558, 953729732, 1340076626, 3518719985, 2797360999, 1068828381, 1219638859, 3624741850, 2936675148, 906185462, 1090812512, 3747672003, 2825379669, 829329135, 1181335161, 3412177804, 3160834842, 628085408, 1382605366, 3423369109, 3138078467, 570562233, 1426400815, 3317316542, 2998733608, 733239954, 1555261956, 3268935591, 3050360625, 752459403, 1541320221, 2607071920, 3965973030, 1969922972, 40735498, 2617837225, 3943577151, 1913087877, 83908371, 2512341634, 3803740692, 2075208622, 213261112, 2463272603, 3855990285, 2094854071, 198958881, 2262029012, 4057260610, 1759359992, 534414190, 2176718541, 4139329115, 1873836001, 414664567, 2282248934, 4279200368, 1711684554, 285281116, 2405801727, 4167216745, 1634467795, 376229701, 2685067896, 3608007406, 1308918612, 956543938, 2808555105, 3495958263, 1231636301, 1047427035, 2932959818, 3654703836, 1088359270, 936918000, 2847714899, 3736837829, 1202900863, 817233897, 3183342108, 3401237130, 1404277552, 615818150, 3134207493, 3453421203, 1423857449, 601450431, 3009837614, 3294710456, 1567103746, 711928724, 3020668471, 3272380065, 1510334235, 755167117 };
            9.CD = "53087483046183F702FCF30639C89CB4";
            9.CE = null;
            9.CF = 0;
            char[] chArray1 = 9.CD.ToCharArray();
            for (num1 = 0; (num1 < chArray1.Length); num1 += 1)
            {
                chArray1[num1] = ((char) ((ushort) (chArray1[num1] - '-')));
            }
            9.CD = new string(chArray1);
        }

        public 9()
        {
        }

        internal static Image 1J(object Y8)
        {
            MethodInfo[] infoArray1;
            int num1;
            ParameterInfo[] infoArray2;
            if (9.CA == 0)
            {
                if (!typeof(Bitmap).Assembly.FullName.StartsWith("System.CF.Drawing"))
                {
                    9.CA = -1;
                }
                else
                {
                    9.CA = 1;
                }
            }
            if (9.CA == -1)
            {
                return ((Image) Y8);
            }
            if (9.C7 == null)
            {
                infoArray1 = Y8.GetType().GetMethods();
                for (num1 = 0; (num1 < infoArray1.Length); num1 += 1)
                {
                    if (infoArray1[num1].Name == "Save")
                    {
                        infoArray2 = infoArray1[num1].GetParameters();
                        if (((infoArray2.Length == 2) && (infoArray2[0].Name == "stream")) && (infoArray2[1].Name == "format"))
                        {
                            9.C7 = infoArray1[num1];
                            9.C8 = infoArray2[1].ParameterType.GetProperty("Png", (BindingFlags.Public | BindingFlags.Static)).GetValue(null, new object[0]);
                            break;
                        }
                    }
                }
                9.C9 = new MemoryStream();
            }
            object[] objArray1 = new object[2];
            objArray1[0] = 9.C9;
            objArray1[1] = 9.C8;
            9.C7.Invoke(Y8, objArray1);
            return Image.FromStream(9.C9);
        }

        private static 6 1K(object Y9, 1 YA)
        {
            string text1;
            byte[] numArray1;
            char[] chArray1;
            int num1;
            int num2;
            string text2;
            string text3;
            double num3;
            if ((Y9 is C))
            {
                text1 = ((C) Y9).2G();
                if ((text1 != null) && (text1.Length == 24))
                {
                    numArray1 = Convert.FromBase64String(text1);
                    chArray1 = ((char[]) Array.CreateInstance(typeof(char), (numArray1.Length / 2)));
                    num2 = 0;
                    for (num1 = 0; (num1 < numArray1.Length); num1 += 2)
                    {
                        chArray1[num2] = ((char) ((ushort) (numArray1[num1] + (numArray1[(num1 + 1)] << 8))));
                        num2 += 1;
                    }
                    text2 = YA.WM;
                    num3 = 0.86525597943226507f;
                    text3 = num3.ToString(CultureInfo.InvariantCulture).Substring(2, 8);
                    if (9.27(new string(chArray1), text3, ref text1) && text1.Substring(0, 2).Equals(text2.Substring(0, 2)))
                    {
                        return new 6("int");
                    }
                }
            }
            return null;
        }

        private static Hashtable 1L(Stream YB, string YC)
        {
            object[] objArray1;
            IFormatter formatter1 = new BinaryFormatter();
            object obj1 = formatter1.Deserialize(YB);
            if ((obj1 is object[]))
            {
                objArray1 = ((object[]) obj1);
                if ((objArray1[0] is string) && (((string) objArray1[0]) == YC))
                {
                    return ((Hashtable) objArray1[1]);
                }
            }
            return null;
        }

        private static Hashtable 1M(Assembly YD, Type YE, string YF, string YG)
        {
            string text1;
            CompareInfo info1;
            string[] textArray1;
            int num1;
            Stream stream1 = null;
            if (YG != null)
            {
                stream1 = YD.GetManifestResourceStream(YG);
            }
            else
            {
                text1 = YF + ".licenses";
                stream1 = YD.GetManifestResourceStream(text1);
                if (stream1 == null)
                {
                    info1 = CultureInfo.InvariantCulture.CompareInfo;
                    textArray1 = YD.GetManifestResourceNames();
                    for (num1 = 0; (num1 < textArray1.Length); num1 += 1)
                    {
                        if (info1.Compare(textArray1[num1], text1, CompareOptions.IgnoreCase) == 0)
                        {
                            stream1 = YD.GetManifestResourceStream(textArray1[num1]);
                            break;
                        }
                    }
                }
            }
            if (stream1 != null)
            {
                return 9.1L(stream1, YF.ToUpper(CultureInfo.InvariantCulture));
            }
            return null;
        }

        internal static Hashtable 1N(Assembly YH, Type YI, bool YJ)
        {
            string text1;
            if ((YH != null) && !(YH is AssemblyBuilder))
            {
                text1 = YH.FullName;
                text1 = text1.Substring(0, text1.IndexOf(", Version="));
                if (YJ)
                {
                    text1 = text1 + ".exe";
                }
                else
                {
                    text1 = text1 + ".dll";
                }
                return 9.1M(YH, YI, text1, null);
            }
            return null;
        }

        internal static Hashtable 1O(Assembly YK, Type YL, object YM)
        {
            Assembly assembly1;
            AssemblyName[] nameArray1;
            AssemblyName name1;
            string text2;
            string text3;
            string text4;
            string[] textArray1;
            int num1;
            Hashtable hashtable1;
            Assembly[] assemblyArray2;
            int num2;
            AssemblyName[] nameArray2;
            int num3;
            CompareInfo info1 = CultureInfo.InvariantCulture.CompareInfo;
            Assembly[] assemblyArray1 = Thread.GetDomain().GetAssemblies();
            string text1 = YK.GetName().Name;
            try
            {
                assemblyArray2 = assemblyArray1;
                for (num2 = 0; (num2 < assemblyArray2.Length); num2 += 1)
                {
                    assembly1 = assemblyArray2[num2];
                    if (!(assembly1 is AssemblyBuilder) && !9.1R(YM, assembly1, false))
                    {
                        nameArray1 = assembly1.GetReferencedAssemblies();
                        nameArray2 = nameArray1;
                        for (num3 = 0; (num3 < nameArray2.Length); num3 += 1)
                        {
                            name1 = nameArray2[num3];
                            if (info1.Compare(name1.Name, text1, CompareOptions.IgnoreCase) == 0)
                            {
                                text2 = assembly1.CodeBase;
                                text3 = text2.Substring((text2.LastIndexOf('/') + 1));
                                text4 = text3 + ".licenses";
                                textArray1 = assembly1.GetManifestResourceNames();
                                for (num1 = 0; (num1 < textArray1.Length); num1 += 1)
                                {
                                    if (info1.Compare(textArray1[num1], text4, CompareOptions.IgnoreCase) == 0)
                                    {
                                        hashtable1 = 9.1M(assembly1, YL, text3, textArray1[num1]);
                                        if (hashtable1 == null)
                                        {
                                            break;
                                        }
                                        return hashtable1;
                                    }
                                }
                                break;
                            }
                        }
                    }
                }
            }
            catch (SecurityException)
            {
            }
            return null;
        }

        private static 6 1P(string YN, Assembly YO)
        {
            if (YN == null)
            {
                goto Label_0035;
            }
            8 1 = 9.21(YN, YO, null, false);
            7 2 = 1.BW;
            switch (2)
            {
                case 7.BP:
                case 7.BS:
                case 7.BR:
                case 7.BQ:
                {
                    goto Label_002E;
                }
            }
            goto Label_0035;
        Label_002E:
            return new 6(YN);
        Label_0035:
            return null;
        }

        private static 6 1Q(string YP, Assembly YQ, object YR, Assembly YS, Assembly YT)
        {
            AboutForm form1;
            6 1 = 9.1P(YP, YQ);
            if (1 != null)
            {
                return 1;
            }
            if (!9.C5 && ((YS != null) || ((YT != null) && YT.Equals(Assembly.GetAssembly(typeof(object))))))
            {
                form1 = new AboutForm(YQ, YR, false);
                9.C5 = true;
                form1.ShowDialog();
                form1.Dispose();
            }
            return new 6("eval");
        }

        private static bool 1R(object YU, Assembly YV, bool YW)
        {
            Assembly assembly1;
            AssemblyCompanyAttribute attribute1;
            if (YU != null)
            {
                assembly1 = YU.GetType().Assembly;
                if (assembly1.Equals(YV))
                {
                    if (!YW)
                    {
                        return true;
                    }
                    attribute1 = ((AssemblyCompanyAttribute) Attribute.GetCustomAttribute(assembly1, typeof(AssemblyCompanyAttribute)));
                    if (attribute1 != null)
                    {
                        return !"ComponentOne LLC".Equals(attribute1.Company);
                    }
                    return true;
                }
            }
            return false;
        }

        private static string 1S(string YX)
        {
            int num4;
            int num1 = YX.IndexOf(", Version=");
            if (num1 == -1)
            {
                return YX;
            }
            int num2 = YX.IndexOf(',', (num1 + 10));
            if (num2 == -1)
            {
                num2 = YX.Length;
            }
            int num3 = 0;
            for (num4 = (num1 + 10); (num4 < num2); num4 += 1)
            {
                if (YX[num4] == '.')
                {
                    num3 += 1;
                    if (num3 == 3)
                    {
                        return YX.Remove(num4, (num2 - num4));
                    }
                }
            }
            return YX;
        }

        private static string 1T(string YY, Hashtable YZ)
        {
            string text1;
            IDictionaryEnumerator enumerator1 = YZ.GetEnumerator();
            while (enumerator1.MoveNext())
            {
                if (!(enumerator1.Key is string))
                {
                    continue;
                }
                text1 = 9.1S(((string) enumerator1.Key));
                if (text1 == YY)
                {
                    return ((string) enumerator1.Value);
                }
            }
            return null;
        }

        private static 6 1U(LicenseContext Z0, Assembly Z1, Type Z2, object Z3, bool Z4)
        {
            AppDomain domain1;
            string text3;
            Hashtable hashtable1;
            string text1 = null;
            string text2 = 9.1S(Z2.AssemblyQualifiedName);
            Assembly assembly1 = Assembly.GetEntryAssembly();
            Assembly assembly2 = null;
            if ((Z3 is B))
            {
                assembly2 = ((B) Z3).GetCallingAssembly();
            }
            bool flag1 = false;
            Type type1 = typeof(9);
            lock (type1)
            {
                if (9.C6 != null)
                {
                    text1 = 9.1T(text2, 9.C6);
                    if (text1 != null)
                    {
                        flag1 = true;
                    }
                }
                else
                {
                    domain1 = AppDomain.CurrentDomain;
                    if (domain1.SetupInformation.LicenseFile != null)
                    {
                        text1 = Z0.GetSavedLicenseKey(Z2, null);
                        flag1 = true;
                    }
                    else if (Attribute.GetCustomAttribute(Z1, typeof(3)) != null)
                    {
                        text3 = ConfigurationSettings.AppSettings["License File"];
                        if (text3 != null)
                        {
                            try
                            {
                                domain1.SetData("LICENSE_FILE", text3);
                                text1 = Z0.GetSavedLicenseKey(Z2, null);
                            }
                            finally
                            {
                                domain1.SetData("LICENSE_FILE", null);
                            }
                        }
                        flag1 = true;
                    }
                }
                if (flag1)
                {
                    goto Label_0180;
                }
                if ((9.C6 == null) && (assembly1 != null))
                {
                    9.C6 = 9.1N(assembly1, Z2, true);
                    if (9.C6 != null)
                    {
                        text1 = 9.1T(text2, 9.C6);
                        if (text1 != null)
                        {
                            flag1 = true;
                        }
                    }
                    else
                    {
                        9.C6 = new Hashtable();
                    }
                }
                if (flag1)
                {
                    goto Label_0180;
                }
                if ((assembly2 != null) && !9.1R(Z3, assembly2, true))
                {
                    hashtable1 = 9.1N(assembly2, Z2, false);
                    if (hashtable1 != null)
                    {
                        text1 = 9.1T(text2, hashtable1);
                        if (text1 != null)
                        {
                            flag1 = true;
                        }
                    }
                }
                if (flag1 || (9.C6 != null))
                {
                    goto Label_0180;
                }
                9.C6 = 9.1O(Z1, Z2, Z3);
                if (9.C6 != null)
                {
                    text1 = 9.1T(text2, 9.C6);
                    goto Label_0180;
                }
                9.C6 = new Hashtable();
            }
        Label_0180:
            if (Z4)
            {
                return 9.1P(text1, Z1);
            }
            return 9.1Q(text1, Z1, Z3, assembly1, assembly2);
        }

        internal static string 1V(object Z5)
        {
            if ((Z5 is string))
            {
                return ((string) Z5);
            }
            return null;
        }

        private static void 1W(ref 6 Z6, string Z7, int Z8, int Z9)
        {
            if ((Z6 != null) && ((Z6.WW > Z8) || ((Z6.WW == Z8) && (Z6.WX >= Z9))))
            {
                return;
            }
            Z6 = new 6(Z7, Z8, Z9);
        }

        private static 6 1X(Assembly ZA, 1 ZB)
        {
            string text1;
            RegistryKey key2;
            string text2;
            object obj1;
            byte[] numArray1;
            int num1;
            char[] chArray1;
            int num2;
            8 3;
            8 4;
            8 5;
            4 6;
            8 7;
            int num3;
            RegistryKey key1 = Registry.ClassesRoot.OpenSubKey("Licenses");
            if (key1 == null)
            {
                return null;
            }
            6 1 = null;
            2 2 = ((2) Attribute.GetCustomAttribute(ZA, typeof(2)));
            if (2 != null)
            {
                text2 = 2.WP;
            }
            else
            {
                text2 = string.Empty;
            }
            if ((text2.Equals("21B11D57-9478-420e-A2B2-4C6AAEF98E46") || text2.Equals("08F7D405-7096-4b5f-A288-F749B8C83E6A")) || text2.Equals("5C114645-719C-4545-891F-1DE9152952A4"))
            {
                key2 = key1.OpenSubKey("724E8A91-AF12-4a3b-9AEB-EF89612E692E");
                if (key2 != null)
                {
                    obj1 = key2.GetValue("1");
                    if ((obj1 is byte[]))
                    {
                        numArray1 = ((byte[]) obj1);
                        num1 = (numArray1.Length / 2);
                        chArray1 = ((char[]) Array.CreateInstance(typeof(char), num1));
                        for (num2 = 0; (num2 < num1); num2 += 1)
                        {
                            chArray1[num2] = ((char) ((ushort) ((numArray1[((num2 + num2) + 1)] << 8) + numArray1[(num2 + num2)])));
                        }
                        text1 = new string(chArray1);
                        3 = 9.21(text1, ZA, null, true);
                        if (3.BW == 7.BR)
                        {
                            if (!3.BX)
                            {
                                return new 6(text1);
                            }
                            1 = new 6(text1, 3.C0, 3.C1);
                        }
                    }
                }
                key2 = key1.OpenSubKey(text2);
                if (key2 != null)
                {
                    text1 = 9.1V(key2.GetValue(""));
                    if (text1 != null)
                    {
                        4 = 9.21(text1, ZA, null, true);
                        if (4.BW == 7.BQ)
                        {
                            if (!4.BX)
                            {
                                return new 6(text1);
                            }
                            9.1W(ref 1, text1, 4.C0, 4.C1);
                        }
                    }
                }
            }
            key2 = key1.OpenSubKey(ZB.WN);
            if (key2 != null)
            {
                text1 = 9.1V(key2.GetValue(""));
                if (text1 != null)
                {
                    5 = 9.21(text1, ZA, ZB.WM, true);
                    if (5.BW == 7.BP)
                    {
                        if (!5.BX)
                        {
                            return new 6(text1);
                        }
                        9.1W(ref 1, text1, 5.C0, 5.C1);
                    }
                }
            }
            4[] Array2 = ((4[]) ZA.GetCustomAttributes(typeof(4), false));
            for (num3 = 0; (num3 < Array2.Length); num3 += 1)
            {
                6 = Array2[num3];
                key2 = key1.OpenSubKey(6.WR);
                if (key2 != null)
                {
                    text1 = 9.1V(key2.GetValue(""));
                    if (text1 != null)
                    {
                        7 = 9.21(text1, ZA, 6.WQ, true);
                        if (7.BW == 7.BS)
                        {
                            if (!7.BX)
                            {
                                return new 6(text1);
                            }
                            9.1W(ref 1, text1, 7.C0, 7.C1);
                        }
                    }
                }
            }
            return 1;
        }

        internal static 6 1Y(Assembly ZC, Type ZD, object ZE)
        {
            Hashtable hashtable1;
            string text1 = null;
            Type type1 = typeof(9);
            lock (type1)
            {
                hashtable1 = 9.1N(((B) ZE).GetCallingAssembly(), ZD, false);
                if (hashtable1 == null)
                {
                    goto Label_0044;
                }
                text1 = 9.1T(9.1S(ZD.AssemblyQualifiedName), hashtable1);
            }
        Label_0044:
            return 9.1P(text1, ZC);
        }

        internal static bool 1Z(Assembly ZF, LicenseContext ZG, 1 ZH)
        {
            string text2;
            if (ZH.WO || (ZG.UsageMode == LicenseUsageMode.Designtime))
            {
                return true;
            }
            string text1 = "";
            try
            {
                text1 = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
            }
            catch (SecurityException)
            {
            }
            int num1 = text1.LastIndexOf('\\');
            if (num1 != -1)
            {
                text2 = text1.Substring((num1 + 1)).ToLower(CultureInfo.InvariantCulture);
                if (text2 != null)
                {
                    text2 = string.IsInterned(text2);
                    if (((text2 == "devenv.exe.config") || (text2 == "webmatrix.exe.config")) || (text2 == "bds.exe.config"))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        internal static 6 20(Assembly ZI, LicenseContext ZJ, Type ZK, object ZL)
        {
            RegistryPermission permission1;
            6 3;
            AboutForm form1;
            string text1;
            6 1 = null;
            1 2 = ((1) Attribute.GetCustomAttribute(ZI, typeof(1)));
            bool flag1 = 9.1Z(ZI, ZJ, 2);
            1 = 9.1K(ZL, 2);
            if (1 != null)
            {
                return 1;
            }
            if (!flag1)
            {
                return 9.1U(ZJ, ZI, ZK, ZL, false);
            }
            try
            {
                permission1 = new RegistryPermission(PermissionState.Unrestricted);
                permission1.Demand();
            }
            catch (SecurityException)
            {
                return null;
            }
            1 = 9.1X(ZI, 2);
            bool flag2 = (1 == null);
            if (!flag2)
            {
                flag2 |= 1.WV;
            }
            if (flag2)
            {
                if ((ZL is B) && !9.1R(ZL, ZI, true))
                {
                    3 = 9.1Y(ZI, ZK, ZL);
                    if (3 != null)
                    {
                        return 3;
                    }
                }
                if (!9.C5)
                {
                    form1 = new AboutForm(ZI, ZL, true);
                    9.C5 = true;
                    form1.ShowDialog();
                    if (form1._newLicense != null)
                    {
                        1 = form1._newLicense;
                        form1._newLicense = null;
                        flag2 = false;
                    }
                    form1.Dispose();
                }
                if (1 == null)
                {
                    1 = new 6("eval");
                }
            }
            if ((ZL is D))
            {
                text1 = "";
                if (!flag2)
                {
                    text1 = 1.LicenseKey;
                }
                ((D) ZL).2H(text1);
                return 1;
            }
            if (!flag2)
            {
                ZJ.SetSavedLicenseKey(ZK, 1.LicenseKey);
            }
            return 1;
        }

        internal static 8 21(string ZM, Assembly ZN, string ZO, bool ZP)
        {
            A a1;
            bool flag2;
            bool flag3;
            bool flag4;
            2 2;
            string text2;
            4[] Array1;
            4 3;
            int num1;
            4[] Array2;
            int num2;
            8 1 = new 8();
            if (((ZM == null) || (ZM.Length == 0)) || ZM.Equals("eval"))
            {
                1.BV = false;
                1.BW = 7.BO;
                1.BX = 9.29(ZN);
                1.BY = "";
                1.BZ = "";
                return 1;
            }
            if (ZM.Equals("int"))
            {
                1.BV = true;
                1.BW = 7.BT;
                1.BX = false;
                1.BY = "(unknown)";
                1.BZ = "ComponentOne LLC";
                return 1;
            }
            string text1 = "";
            bool flag1 = false;
            if (9.27(ZM, 9.CD, ref text1) && (text1.Length >= 9))
            {
                a1 = 9.24(ZN);
                1.C0 = (int.Parse(text1.Substring(3, 2), CultureInfo.InvariantCulture) + 2000);
                1.C1 = int.Parse(text1.Substring(2, 1), CultureInfo.InvariantCulture);
                flag2 = true;
                flag3 = false;
                flag4 = false;
                2 = ((2) Attribute.GetCustomAttribute(ZN, typeof(2)));
                if (2 == null)
                {
                    flag2 = false;
                }
                else if ("08F7D405-7096-4b5f-A288-F749B8C83E6A".Equals(2.WP))
                {
                    flag3 = true;
                }
                else if ("5C114645-719C-4545-891F-1DE9152952A4".Equals(2.WP))
                {
                    flag4 = true;
                }
                else if (!"21B11D57-9478-420e-A2B2-4C6AAEF98E46".Equals(2.WP))
                {
                    flag2 = false;
                }
                if (((ZO == null) && flag2) && ((text1.StartsWith("SE") || ((!flag3 && !flag4) && text1.StartsWith("S8"))) || ((flag3 && text1.StartsWith("S9")) || (flag4 && text1.StartsWith("SM")))))
                {
                    if (text1.StartsWith("SE"))
                    {
                        1.BW = 7.BR;
                    }
                    else
                    {
                        1.BW = 7.BQ;
                    }
                    flag1 = true;
                }
                else
                {
                    text2 = ((1) Attribute.GetCustomAttribute(ZN, typeof(1))).WM;
                    if (text1.Substring(0, 2).Equals(text2.Substring(0, 2)) && ((ZO == null) || text1.Substring(0, 2).Equals(ZO.Substring(0, 2))))
                    {
                        1.BW = 7.BP;
                        flag1 = true;
                    }
                }
                if (!flag1)
                {
                    Array1 = ((4[]) ZN.GetCustomAttributes(typeof(4), false));
                    Array2 = Array1;
                    for (num2 = 0; (num2 < Array2.Length); num2 += 1)
                    {
                        3 = Array2[num2];
                        if (text1.Substring(0, 2).Equals(3.WQ.Substring(0, 2)) && ((ZO == null) || text1.Substring(0, 2).Equals(ZO.Substring(0, 2))))
                        {
                            1.BW = 7.BS;
                            flag1 = true;
                            break;
                        }
                    }
                }
                if (flag1)
                {
                    1.BX = ((bool) (!ZP ? 0 : (((a1.CK * 4) + a1.CL) > (((1.C0 * 4) + 1.C1) + 4))));
                    1.BV = !1.BX;
                    num1 = 5;
                    1.BY = text1.Substring((num1 + 1), text1[num1]);
                    num1 += (text1[num1] + '\x01');
                    1.BZ = text1.Substring((num1 + 1), text1[num1]);
                }
            }
            if (!flag1)
            {
                1.BV = false;
                1.BW = 7.BO;
                1.BX = 9.29(ZN);
                1.BY = "";
                1.BZ = "";
            }
            return 1;
        }

        internal static 8 22(Type ZQ, object ZR)
        {
            Assembly assembly1 = Assembly.GetExecutingAssembly();
            LicenseContext context1 = LicenseManager.CurrentContext;
            6 1 = 9.20(assembly1, context1, ZQ, ZR);
            if (1 == null)
            {
                throw new LicenseException(ZQ, ZR);
            }
            1 2 = ((1) Attribute.GetCustomAttribute(assembly1, typeof(1)));
            bool flag1 = 9.1Z(assembly1, context1, 2);
            8 3 = 9.21(1.LicenseKey, assembly1, null, flag1);
            1.Dispose();
            if (flag1)
            {
                return 3;
            }
            Assembly assembly2 = Assembly.GetEntryAssembly();
            Assembly assembly3 = null;
            if ((ZR is B))
            {
                assembly3 = ((B) ZR).GetCallingAssembly();
            }
            3.C2 = ((bool) (((assembly2 != null) || (assembly3 == null)) ? 0 : assembly3.Equals(Assembly.GetAssembly(typeof(object)))));
            3.C3 = ((bool) ((assembly2 != null) ? 0 : !3.C2));
            return 3;
        }

        internal static void 23(object ZS)
        {
            RegistryPermission permission1;
            Assembly assembly1 = Assembly.GetExecutingAssembly();
            try
            {
                permission1 = new RegistryPermission(PermissionState.Unrestricted);
                permission1.Demand();
            }
            catch (SecurityException)
            {
                return;
            }
            AboutForm form1 = new AboutForm(assembly1, ZS, true);
            form1.ShowDialog();
            form1.Dispose();
        }

        internal static A 24(Assembly ZT)
        {
            A a1;
            a1 = new A();
            a1.CG = ((AssemblyFileVersionAttribute) Attribute.GetCustomAttribute(ZT, typeof(AssemblyFileVersionAttribute))).Version;
            char[] chArray1 = new char[2];
            chArray1[0] = '.';
            chArray1[1] = ' ';
            string[] textArray1 = a1.CG.Split(chArray1);
            a1.CH = int.Parse(textArray1[0], CultureInfo.InvariantCulture);
            a1.CI = int.Parse(textArray1[1], CultureInfo.InvariantCulture);
            a1.CJ = int.Parse(textArray1[3], CultureInfo.InvariantCulture);
            int num1 = int.Parse(textArray1[2], CultureInfo.InvariantCulture);
            a1.CK = (num1 / 10);
            a1.CL = (num1 % 10);
            return a1;
        }

        internal static void 25(string ZU, out uint ZV, out uint ZW)
        {
            int num3;
            uint num4;
            uint num1 = 65535;
            uint num2 = -1;
            if (ZU != null)
            {
                for (num3 = 0; (num3 < ZU.Length); num3 += 1)
                {
                    num4 = ((uint) ZU[num3]);
                    num1 = ((num1 >> 8) ^ 9.CB[((num4 ^ num1) & 255)]);
                    num1 = ((num1 >> 8) ^ 9.CB[(((num4 >> 8) ^ num1) & 255)]);
                    num2 = ((num2 >> 8) ^ 9.CC[((num4 ^ num2) & 255)]);
                    num2 = ((num2 >> 8) ^ 9.CC[(((num4 >> 8) ^ num2) & 255)]);
                }
            }
            ZV = (~num1 & 65535);
            ZW = ~num2;
        }

        internal static string 26(string ZX, string ZY)
        {
            uint[] numArray1;
            uint num1;
            uint num2;
            uint num3;
            uint num4;
            uint num5;
            uint num6;
            char[] chArray1;
            uint[] numArray2;
            uint num7;
            uint num8;
            StringBuilder builder1;
            if ((ZX != null) && (ZX.Length > 0))
            {
                numArray1 = ((uint[]) Array.CreateInstance(typeof(uint), 256));
                num3 = 0;
                num4 = 0;
                num5 = 6;
                num6 = 0;
                chArray1 = ((char[]) Array.CreateInstance(typeof(char), 6));
                numArray2 = ((uint[]) Array.CreateInstance(typeof(uint), 6));
                num1 = 0;
                while ((num1 < 256))
                {
                    numArray1[num1] = num1;
                    num1 += 1;
                }
                num1 = 0;
                while ((num1 < 256))
                {
                    num2 = numArray1[num1];
                    num4 = ((uint) (((ZY[num3] + numArray1[num1]) + num4) & '\u00ff'));
                    numArray1[num1] = numArray1[num4];
                    numArray1[num4] = num2;
                    num3 = ((num3 + 1) % ZY.Length);
                    num1 += 1;
                }
                9.25(ZX, ref num7, ref num8);
                numArray2[0] = (num7 & 255);
                numArray2[1] = (num7 >> 8);
                numArray2[2] = (num8 & 255);
                numArray2[3] = ((num8 >> 8) & 255);
                numArray2[4] = ((num8 >> 16) & 255);
                numArray2[5] = (num8 >> 24);
                chArray1[0] = ((char) ((ushort) (numArray2[0] + 1)));
                chArray1[1] = ((char) ((ushort) (numArray2[1] + 1)));
                chArray1[2] = ((char) ((ushort) (numArray2[2] + 1)));
                chArray1[3] = ((char) ((ushort) (numArray2[3] + 1)));
                chArray1[4] = ((char) ((ushort) (numArray2[4] + 1)));
                chArray1[5] = ((char) ((ushort) (numArray2[5] + 1)));
                num1 = 0;
                while ((num1 < 6))
                {
                    num3 = numArray1[(num1 + 1)];
                    num6 = ((num3 + num6) & 255);
                    num4 = numArray1[num6];
                    numArray1[(num1 + 1)] = num4;
                    numArray1[num6] = num3;
                    chArray1[num1] = ((char) ((ushort) (chArray1[num1] + numArray1[((num3 + num4) & 255)])));
                    num1 += 1;
                }
                num3 = 0;
                num4 = 0;
                num1 = 0;
                while ((num1 < 256))
                {
                    num2 = numArray1[num1];
                    num4 = (((numArray2[num3] + numArray1[num1]) + num4) & 255);
                    numArray1[num1] = numArray1[num4];
                    numArray1[num4] = num2;
                    num3 = ((num3 + 1) % 6);
                    num1 += 1;
                }
                builder1 = new StringBuilder(ZX.Length);
                builder1.Length = ZX.Length;
                num1 = 0;
                while ((((ulong) num1) < ((long) builder1.Length)))
                {
                    num5 = ((num5 + 1) & 255);
                    num3 = numArray1[num5];
                    num6 = ((num3 + num6) & 255);
                    num4 = numArray1[num6];
                    numArray1[num5] = num4;
                    numArray1[num6] = num3;
                    num3 = ((num3 + num4) & 255);
                    num2 = ((uint) ZX[num1]);
                    if (num2 < 43776)
                    {
                        builder1[num1] = ((char) ((ushort) (num2 + numArray1[num3])));
                    }
                    else if (num2 >= 44032)
                    {
                        builder1[num1] = ((char) ((ushort) (num2 ^ numArray1[num3])));
                    }
                    else
                    {
                        throw new Exception("Invalid character has occured!");
                    }
                    num1 += 1;
                }
                for (num1 = 0; (num1 < 256); num1 += 1)
                {
                    numArray1[num1] = 0;
                }
                return new string(chArray1) + builder1.ToString();
            }
            return "";
        }

        internal static bool 27(string ZZ, string 000, ref string 001)
        {
            uint[] numArray1;
            uint num1;
            uint num2;
            uint num3;
            uint num4;
            uint num5;
            uint num6;
            uint[] numArray2;
            StringBuilder builder1;
            if ((ZZ != null) && (ZZ.Length > 6))
            {
                numArray1 = ((uint[]) Array.CreateInstance(typeof(uint), 256));
                num3 = 0;
                num4 = 0;
                num5 = 6;
                num6 = 0;
                numArray2 = ((uint[]) Array.CreateInstance(typeof(uint), 6));
                num1 = 0;
                while ((num1 < 256))
                {
                    numArray1[num1] = num1;
                    num1 += 1;
                }
                num1 = 0;
                while ((num1 < 256))
                {
                    num2 = numArray1[num1];
                    num4 = ((uint) (((000[num3] + numArray1[num1]) + num4) & '\u00ff'));
                    numArray1[num1] = numArray1[num4];
                    numArray1[num4] = num2;
                    num3 = ((num3 + 1) % 000.Length);
                    num1 += 1;
                }
                num1 = 0;
                while ((num1 < 6))
                {
                    num3 = numArray1[(num1 + 1)];
                    num6 = ((num3 + num6) & 255);
                    num4 = numArray1[num6];
                    numArray1[(num1 + 1)] = num4;
                    numArray1[num6] = num3;
                    numArray2[num1] = ((uint) ((ZZ[num1] - numArray1[((num3 + num4) & 255)]) - '\x01'));
                    num1 += 1;
                }
                num3 = 0;
                num4 = 0;
                num1 = 0;
                while ((num1 < 256))
                {
                    num2 = numArray1[num1];
                    num4 = (((numArray2[num3] + numArray1[num1]) + num4) & 255);
                    numArray1[num1] = numArray1[num4];
                    numArray1[num4] = num2;
                    num3 = ((num3 + 1) % 6);
                    num1 += 1;
                }
                builder1 = new StringBuilder(ZZ.Substring(6));
                num1 = 0;
                while ((((ulong) num1) < ((long) builder1.Length)))
                {
                    num5 = ((num5 + 1) & 255);
                    num3 = numArray1[num5];
                    num6 = ((num3 + num6) & 255);
                    num4 = numArray1[num6];
                    numArray1[num5] = num4;
                    numArray1[num6] = num3;
                    num3 = ((num3 + num4) & 255);
                    num2 = ((uint) builder1[num1]);
                    if (num2 < 44032)
                    {
                        builder1[num1] = ((char) ((ushort) (num2 - numArray1[num3])));
                    }
                    else
                    {
                        builder1[num1] = ((char) ((ushort) (num2 ^ numArray1[num3])));
                    }
                    num1 += 1;
                }
                for (num1 = 0; (num1 < 256); num1 += 1)
                {
                    numArray1[num1] = 0;
                }
                001 = builder1.ToString();
                9.25(001, ref num3, ref num4);
                if (num3 == (numArray2[0] + (numArray2[1] << 8)))
                {
                    return (num4 == (((numArray2[2] + (numArray2[3] << 8)) + (numArray2[4] << 16)) + (numArray2[5] << 24)));
                }
                return false;
            }
            001 = "";
            if (ZZ != null)
            {
                return (ZZ.Length == 0);
            }
            return true;
        }

        internal static 8 28(Assembly 002, object 003, bool 004)
        {
            1 3;
            bool flag1;
            6 4;
            8 1 = 9.21("eval", 002, null, 004);
            if (1.BW == 7.BN)
            {
                return 1;
            }
            6 2 = null;
            if (!004)
            {
                if (003 != null)
                {
                    2 = 9.1U(LicenseManager.CurrentContext, 002, 003.GetType(), 003, true);
                }
            }
            else
            {
                3 = ((1) Attribute.GetCustomAttribute(002, typeof(1)));
                2 = 9.1X(002, 3);
                flag1 = (2 == null);
                if (!flag1)
                {
                    flag1 |= 2.WV;
                }
                if ((flag1 && (003 is B)) && !9.1R(003, 002, true))
                {
                    4 = 9.1Y(002, 003.GetType(), 003);
                    if (4 != null)
                    {
                        return 9.21(4.LicenseKey, 002, null, 004);
                    }
                }
            }
            if (2 != null)
            {
                return 9.21(2.LicenseKey, 002, null, 004);
            }
            return 1;
        }

        internal static bool 29(Assembly 005)
        {
            DateTime time1;
            A a1 = 9.24(005);
            if (((a1.CK > 2000) && (a1.CK < 3000)) && ((a1.CL >= 1) && (a1.CL <= 4)))
            {
                time1 = DateTime.Now;
                return (((time1.Year * 12) + time1.Month) > (((a1.CK * 12) + (a1.CL * 3)) + 2));
            }
            return false;
        }

        internal static bool 2A(string 006)
        {
            CompareInfo info1 = CultureInfo.InvariantCulture.CompareInfo;
            string text1 = 006.Substring(2, 1);
            if ((info1.Compare(text1, "1") < 0) || (info1.Compare(text1, "4") > 0))
            {
                return false;
            }
            text1 = 006.Substring(3, 1);
            if ((info1.Compare(text1, "0") < 0) || (info1.Compare(text1, "9") > 0))
            {
                return false;
            }
            text1 = 006.Substring(4, 1);
            if ((info1.Compare(text1, "0") < 0) || (info1.Compare(text1, "9") > 0))
            {
                return false;
            }
            return 006.Substring(8, 2).Equals(9.2E(006.Substring(0, 7), 006.Substring(11, 6)));
        }

        internal static int 2B(string 007, Assembly 008)
        {
            A a1;
            int num1;
            int num2;
            if (((007.Length == 17) && 007.StartsWith("SE")) && 9.2A(007))
            {
                a1 = 9.24(008);
                num1 = (int.Parse(007.Substring(3, 2), CultureInfo.InvariantCulture) + 2000);
                num2 = int.Parse(007.Substring(2, 1), CultureInfo.InvariantCulture);
                if (((a1.CK * 4) + a1.CL) <= (((num1 * 4) + num2) + 4))
                {
                    return 0;
                }
                return 2;
            }
            return 1;
        }

        internal static int 2C(string 009, Assembly 00A, bool 00B, bool 00C)
        {
            A a1;
            int num1;
            int num2;
            if (((009.Length == 17) && ((((!00B && !00C) && 009.StartsWith("S8")) || (00B && 009.StartsWith("S9"))) || (00C && 009.StartsWith("SM")))) && 9.2A(009))
            {
                a1 = 9.24(00A);
                num1 = (int.Parse(009.Substring(3, 2), CultureInfo.InvariantCulture) + 2000);
                num2 = int.Parse(009.Substring(2, 1), CultureInfo.InvariantCulture);
                if (((a1.CK * 4) + a1.CL) <= (((num1 * 4) + num2) + 4))
                {
                    return 0;
                }
                return 2;
            }
            return 1;
        }

        internal static int 2D(string 00D, Assembly 00E)
        {
            A a1;
            int num1;
            int num2;
            string text1 = ((1) Attribute.GetCustomAttribute(00E, typeof(1))).WM;
            if (((00D.Length == 17) && 00D.Substring(0, 2).Equals(text1.Substring(0, 2))) && 9.2A(00D))
            {
                a1 = 9.24(00E);
                num1 = (int.Parse(00D.Substring(3, 2), CultureInfo.InvariantCulture) + 2000);
                num2 = int.Parse(00D.Substring(2, 1), CultureInfo.InvariantCulture);
                if (((a1.CK * 4) + a1.CL) <= (((num1 * 4) + num2) + 4))
                {
                    return 0;
                }
                return 2;
            }
            return 1;
        }

        internal static string 2E(string 00F, string 00G)
        {
            int num1;
            int num2;
            int num3;
            StringBuilder builder1 = new StringBuilder(00F);
            builder1.Append(00G);
            StringBuilder builder2 = new StringBuilder();
            if (9.CE == null)
            {
                9.2F();
            }
            for (num2 = 0; (num2 < 2); num2 += 1)
            {
                num3 = 0;
                for (num1 = 0; (num1 < builder1.Length); num1 += 1)
                {
                    num3 += ((num1 ^ (num2 + 1)) * builder1[num1]);
                }
                builder2.Append(9.CE[(num3 % 9.CE.Length)]);
            }
            return builder2.ToString();
        }

        private static void 2F()
        {
            int num1;
            int num2;
            int num3;
            char ch1;
            9.CE = new StringBuilder("23456789ABCDEFGHJKLMNPQRSTUVWXY");
            int num4 = 9.CE.Length;
            for (num1 = 1; (num1 < num4); num1 += 1)
            {
                ch1 = 9.CE[(num1 - 1)];
                num2 = 0;
                for (num3 = 1; (num3 < num4); num3 += 1)
                {
                    if (((num1 * num3) % num4) == 1)
                    {
                        num2 = num3;
                        break;
                    }
                }
                if (num1 < num2)
                {
                    9.CE[(num1 - 1)] = 9.CE[(num2 - 1)];
                    9.CE[(num2 - 1)] = ch1;
                }
            }
        }


        // Fields
        private const int C4 = 2;
        private static bool C5;
        private static Hashtable C6;
        private static MethodInfo C7;
        private static object C8;
        private static MemoryStream C9;
        private static int CA;
        private static uint[] CB;
        private static uint[] CC;
        internal static string CD;
        private static StringBuilder CE;
        internal static int CF;

        // Nested Types
        [StructLayout(LayoutKind.Sequential)]
        internal struct A
        {
            // Fields
            public string CG;
            public int CH;
            public int CI;
            public int CJ;
            public int CK;
            public int CL;
        }
    }
}

