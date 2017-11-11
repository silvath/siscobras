namespace C1.Win
{
    using Microsoft.Win32;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Reflection;
    using System.Resources;
    using System.Text;
    using System.Windows.Forms;

    internal class LicensingForm : Form
    {
        // Methods
        internal LicensingForm() : this(Assembly.GetExecutingAssembly(), true, false, false)
        {
        }

        internal LicensingForm(Assembly asm, bool memberOfStudio, bool webProduct, bool mobileProduct)
        {
            this._licenseKey = "";
            this.InitializeComponent();
            G.2L(this, this.components);
            this._asm = asm;
            this._memberOfStudio = memberOfStudio;
            this._webProduct = webProduct;
            this._mobileProduct = mobileProduct;
            this.labProductName.Text = ((AssemblyProductAttribute) Attribute.GetCustomAttribute(asm, typeof(AssemblyProductAttribute))).Product;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string text1;
            int num1;
            int num4;
            object obj1;
            byte[] numArray1;
            int num5;
            char[] chArray1;
            8 1;
            int num6;
            string text5;
            8 2;
            int num7;
            1 3;
            8 4;
            byte[] numArray2;
            int num8;
            object[] objArray1;
            string text2 = this.edName.Text;
            int num2 = text2.Length;
            if ((num2 == 0) || (num2 > 255))
            {
                this.edName.Focus();
                if (num2 == 0)
                {
                    text1 = this._msgEmptyCustomerName.Text;
                }
                else
                {
                    text1 = this._msgTooLongCustomerName.Text;
                }
                MessageBox.Show(text1, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            string text3 = this.edCompany.Text;
            num2 = text3.Length;
            if ((num2 == 0) || (num2 > 255))
            {
                this.edCompany.Focus();
                if (num2 == 0)
                {
                    text1 = this._msgEmptyCompanyName.Text;
                }
                else
                {
                    text1 = this._msgTooLongCompanyName.Text;
                }
                MessageBox.Show(text1, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            string text4 = this.edSerialNumber.Text;
            int num3 = 0;
            RegistryKey key1 = null;
            if (this._memberOfStudio)
            {
                if (text4.StartsWith("SE"))
                {
                    num4 = 9.2B(text4, this._asm);
                    if (num4 != 0)
                    {
                        this.edSerialNumber.Focus();
                        if (num4 == 1)
                        {
                            text1 = this._msgInvalidSerialNumber.Text;
                        }
                        else
                        {
                            text1 = this._msgSerialNumberHasExpired.Text;
                        }
                        MessageBox.Show(text1, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    num3 = 1;
                    key1 = Registry.ClassesRoot.OpenSubKey(@"Licenses\724E8A91-AF12-4a3b-9AEB-EF89612E692E", true);
                    if (key1 == null)
                    {
                        key1 = Registry.ClassesRoot.CreateSubKey(@"Licenses\724E8A91-AF12-4a3b-9AEB-EF89612E692E");
                    }
                    else
                    {
                        obj1 = key1.GetValue("1");
                        if ((obj1 is byte[]))
                        {
                            numArray1 = ((byte[]) obj1);
                            num5 = (numArray1.Length / 2);
                            chArray1 = ((char[]) Array.CreateInstance(typeof(char), num5));
                            for (num1 = 0; (num1 < num5); num1 += 1)
                            {
                                chArray1[num1] = ((char) ((ushort) ((numArray1[((num1 + num1) + 1)] << 8) + numArray1[(num1 + num1)])));
                            }
                            1 = 9.21(new string(chArray1), this._asm, null, true);
                            if ((1.BW == 7.BR) && this.KeyArchaic(text4, 1))
                            {
                                return;
                            }
                        }
                    }
                }
                else if ((text4.StartsWith("S8") || text4.StartsWith("S9")) || text4.StartsWith("SM"))
                {
                    num6 = 9.2C(text4, this._asm, this._webProduct, this._mobileProduct);
                    if (num6 != 0)
                    {
                        this.edSerialNumber.Focus();
                        if (num6 == 1)
                        {
                            text1 = this._msgInvalidSerialNumber.Text;
                        }
                        else
                        {
                            text1 = this._msgSerialNumberHasExpired.Text;
                        }
                        MessageBox.Show(text1, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    text5 = ((2) Attribute.GetCustomAttribute(this._asm, typeof(2))).WP;
                    num3 = 2;
                    key1 = Registry.ClassesRoot.OpenSubKey(@"Licenses\" + text5, true);
                    if (key1 == null)
                    {
                        key1 = Registry.ClassesRoot.CreateSubKey(@"Licenses\" + text5);
                    }
                    else
                    {
                        text1 = 9.1V(key1.GetValue(""));
                        2 = 9.21(text1, this._asm, null, true);
                        if ((2.BW == 7.BQ) && this.KeyArchaic(text4, 2))
                        {
                            return;
                        }
                    }
                }
            }
            if (num3 == 0)
            {
                num7 = 9.2D(text4, this._asm);
                if (num7 != 0)
                {
                    this.edSerialNumber.Focus();
                    if (num7 == 1)
                    {
                        text1 = this._msgInvalidSerialNumber.Text;
                    }
                    else
                    {
                        text1 = this._msgSerialNumberHasExpired.Text;
                    }
                    MessageBox.Show(text1, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                3 = ((1) Attribute.GetCustomAttribute(this._asm, typeof(1)));
                key1 = Registry.ClassesRoot.OpenSubKey(@"Licenses\" + 3.WN, true);
                if (key1 == null)
                {
                    key1 = Registry.ClassesRoot.CreateSubKey(@"Licenses\" + 3.WN);
                }
                else
                {
                    text1 = 9.1V(key1.GetValue(""));
                    4 = 9.21(text1, this._asm, 3.WM, true);
                    if ((4.BW == 7.BP) && this.KeyArchaic(text4, 4))
                    {
                        return;
                    }
                }
            }
            StringBuilder builder1 = new StringBuilder(text4.Substring(0, 5));
            builder1.Append(((ushort) text2.Length));
            builder1.Append(text2);
            builder1.Append(((ushort) text3.Length));
            builder1.Append(text3);
            this._licenseKey = 9.26(builder1.ToString(), 9.CD);
            if (num3 != 1)
            {
                key1.SetValue("", this._licenseKey);
                if (num3 == 0)
                {
                    objArray1 = new object[1];
                    objArray1[0] = this.labProductName.Text;
                    this._info = string.Format(CultureInfo.InvariantCulture, this._msgLicensedInfo.Text, objArray1);
                }
                else if (this._webProduct)
                {
                    objArray1 = new object[1];
                    objArray1[0] = this._msgStudioForASPdotNET.Text;
                    this._info = string.Format(CultureInfo.InvariantCulture, this._msgLicensedInfo.Text, objArray1);
                }
                else if (this._mobileProduct)
                {
                    objArray1 = new object[1];
                    objArray1[0] = this._msgStudioForMobileDevices.Text;
                    this._info = string.Format(CultureInfo.InvariantCulture, this._msgLicensedInfo.Text, objArray1);
                }
                else
                {
                    objArray1 = new object[1];
                    objArray1[0] = this._msgStudioForDotNET.Text;
                    this._info = string.Format(CultureInfo.InvariantCulture, this._msgLicensedInfo.Text, objArray1);
                }
            }
            else
            {
                num2 = this._licenseKey.Length;
                numArray2 = ((byte[]) Array.CreateInstance(typeof(byte), (num2 + num2)));
                for (num1 = 0; (num1 < num2); num1 += 1)
                {
                    num8 = ((int) this._licenseKey[num1]);
                    numArray2[(num1 + num1)] = ((byte) (num8 & 255));
                    numArray2[((num1 + num1) + 1)] = ((byte) (num8 >> 8));
                }
                key1.SetValue("1", numArray2);
                objArray1 = new object[1];
                objArray1[0] = this._msgStudioEnterprise.Text;
                this._info = string.Format(CultureInfo.InvariantCulture, this._msgLicensedInfo.Text, objArray1);
            }
            this._caption = this._msgCongratulations.Text;
            base.DialogResult = DialogResult.OK;
        }

        private void Copy_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject("http://www.componentone.com/userpage/DesktopDefault.aspx?tabindex=0&tabsubindex=3&tabid=9", true);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ResourceManager manager1 = new ResourceManager(typeof(LicensingForm));
            this.edName = new TextBox();
            this.edCompany = new TextBox();
            this.labName = new Label();
            this.labCompany = new Label();
            this.labSerialNumber = new Label();
            this.labPersonalInfo = new Label();
            this.btnOk = new Button();
            this.btnCancel = new Button();
            this.edSerialNumber = new TextBox();
            this.labHR = new Label();
            this.labProductName = new Label();
            this.pictureBox1 = new PictureBox();
            this.labSNTitle = new Label();
            this.linkEULA = new LinkLabel();
            this.contextMenu1 = new ContextMenu();
            this.itemCopy = new MenuItem();
            this._msgEmptyCustomerName = new Label();
            this._msgEmptyCompanyName = new Label();
            this._msgInvalidSerialNumber = new Label();
            this._msgArchaicProductKey = new TextBox();
            this.toolTip1 = new ToolTip(this.components);
            this._msgSerialNumberHasExpired = new TextBox();
            this._msgTooLongCustomerName = new Label();
            this._msgTooLongCompanyName = new Label();
            this._msgLicensedInfo = new Label();
            this._msgStudioEnterprise = new Label();
            this._msgStudioForDotNET = new Label();
            this._msgStudioForASPdotNET = new Label();
            this._msgStudioForMobileDevices = new Label();
            this._msgCongratulations = new Label();
            base.SuspendLayout();
            this.edName.BackColor = SystemColors.Window;
            this.edName.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.edName.Location = new Point(140, 124);
            this.edName.Name = "edName";
            this.edName.Size = new Size(238, 21);
            this.edName.TabIndex = 7;
            this.edName.Text = "";
            this.edCompany.BackColor = SystemColors.Window;
            this.edCompany.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.edCompany.Location = new Point(140, 150);
            this.edCompany.Name = "edCompany";
            this.edCompany.Size = new Size(238, 21);
            this.edCompany.TabIndex = 9;
            this.edCompany.Text = "";
            this.labName.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.labName.Location = new Point(36, 126);
            this.labName.Name = "labName";
            this.labName.Size = new Size(92, 16);
            this.labName.TabIndex = 6;
            this.labName.Text = "Name:";
            this.labCompany.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.labCompany.Location = new Point(36, 152);
            this.labCompany.Name = "labCompany";
            this.labCompany.Size = new Size(92, 16);
            this.labCompany.TabIndex = 8;
            this.labCompany.Text = "Company:";
            this.labSerialNumber.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.labSerialNumber.Location = new Point(36, 208);
            this.labSerialNumber.Name = "labSerialNumber";
            this.labSerialNumber.Size = new Size(92, 16);
            this.labSerialNumber.TabIndex = 11;
            this.labSerialNumber.Text = "S/N:";
            this.labPersonalInfo.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.labPersonalInfo.Location = new Point(15, 100);
            this.labPersonalInfo.Name = "labPersonalInfo";
            this.labPersonalInfo.Size = new Size(313, 16);
            this.labPersonalInfo.TabIndex = 5;
            this.labPersonalInfo.Text = "Your personal information:";
            this.btnOk.BackColor = SystemColors.Control;
            this.btnOk.FlatStyle = FlatStyle.Flat;
            this.btnOk.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnOk.Location = new Point(120, 259);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new Size(90, 24);
            this.btnOk.TabIndex = 14;
            this.btnOk.Text = "OK";
            this.btnOk.Click += new EventHandler(this.btnOk_Click);
            this.btnCancel.BackColor = SystemColors.Control;
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnCancel.Location = new Point(222, 259);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(90, 24);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.edSerialNumber.BackColor = SystemColors.Window;
            this.edSerialNumber.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.edSerialNumber.Location = new Point(140, 206);
            this.edSerialNumber.Name = "edSerialNumber";
            this.edSerialNumber.Size = new Size(238, 21);
            this.edSerialNumber.TabIndex = 12;
            this.edSerialNumber.Text = "";
            this.labHR.BorderStyle = BorderStyle.FixedSingle;
            this.labHR.Location = new Point(10, 244);
            this.labHR.Name = "labHR";
            this.labHR.Size = new Size(404, 3);
            this.labHR.TabIndex = 13;
            this.labProductName.Font = new Font("Verdana", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.labProductName.Location = new Point(15, 16);
            this.labProductName.Name = "labProductName";
            this.labProductName.Size = new Size(317, 36);
            this.labProductName.TabIndex = 0;
            this.labProductName.Text = "ComponentOne Product Name";
            this.pictureBox1.Image = 9.1J(manager1.GetObject("pictureBox1.Image"));
            this.pictureBox1.Location = new Point(332, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(84, 50);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            this.labSNTitle.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.labSNTitle.Location = new Point(15, 182);
            this.labSNTitle.Name = "labSNTitle";
            this.labSNTitle.Size = new Size(313, 16);
            this.labSNTitle.TabIndex = 10;
            this.labSNTitle.Text = "Studio or product serial number:";
            this.linkEULA.ContextMenu = this.contextMenu1;
            this.linkEULA.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.linkEULA.LinkArea = new LinkArea(16, 26);
            this.linkEULA.Location = new Point(15, 67);
            this.linkEULA.Name = "linkEULA";
            this.linkEULA.Size = new Size(399, 27);
            this.linkEULA.TabIndex = 4;
            this.linkEULA.TabStop = true;
            this.linkEULA.Text = "Please read the END-USER LICENSE AGREEMENT before proceeding.";
            this.linkEULA.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkEULA_LinkClicked);
            this.contextMenu1.MenuItems.Add(this.itemCopy);
            this.itemCopy.Index = 0;
            this.itemCopy.Text = "Copy URL";
            this.itemCopy.Click += new EventHandler(this.Copy_Click);
            this._msgEmptyCustomerName.Enabled = false;
            this._msgEmptyCustomerName.Location = new Point(471, 8);
            this._msgEmptyCustomerName.Name = "_msgEmptyCustomerName";
            this._msgEmptyCustomerName.Size = new Size(277, 16);
            this._msgEmptyCustomerName.TabIndex = 18;
            this._msgEmptyCustomerName.Text = "Customer Name field cannot be empty.";
            this._msgEmptyCustomerName.Visible = false;
            this._msgEmptyCompanyName.Enabled = false;
            this._msgEmptyCompanyName.Location = new Point(471, 40);
            this._msgEmptyCompanyName.Name = "_msgEmptyCompanyName";
            this._msgEmptyCompanyName.Size = new Size(277, 16);
            this._msgEmptyCompanyName.TabIndex = 18;
            this._msgEmptyCompanyName.Text = "Company Name field cannot be empty.";
            this._msgEmptyCompanyName.Visible = false;
            this._msgInvalidSerialNumber.Enabled = false;
            this._msgInvalidSerialNumber.Location = new Point(471, 72);
            this._msgInvalidSerialNumber.Name = "_msgInvalidSerialNumber";
            this._msgInvalidSerialNumber.Size = new Size(277, 16);
            this._msgInvalidSerialNumber.TabIndex = 18;
            this._msgInvalidSerialNumber.Text = "The specified serial number is not valid.";
            this._msgInvalidSerialNumber.Visible = false;
            this._msgArchaicProductKey.Enabled = false;
            this._msgArchaicProductKey.Location = new Point(472, 156);
            this._msgArchaicProductKey.Multiline = true;
            this._msgArchaicProductKey.Name = "_msgArchaicProductKey";
            this._msgArchaicProductKey.ReadOnly = true;
            this._msgArchaicProductKey.Size = new Size(276, 52);
            this._msgArchaicProductKey.TabIndex = 19;
            this._msgArchaicProductKey.Text = "This license key is older than the one currently installed.\r\nYou cannot replace new key with the old one because\r\nsome new products may become unlicensed.";
            this._msgArchaicProductKey.Visible = false;
            this._msgSerialNumberHasExpired.Enabled = false;
            this._msgSerialNumberHasExpired.Location = new Point(472, 96);
            this._msgSerialNumberHasExpired.Multiline = true;
            this._msgSerialNumberHasExpired.Name = "_msgSerialNumberHasExpired";
            this._msgSerialNumberHasExpired.ReadOnly = true;
            this._msgSerialNumberHasExpired.Size = new Size(276, 52);
            this._msgSerialNumberHasExpired.TabIndex = 20;
            this._msgSerialNumberHasExpired.Text = "Sorry, this serial number has expired. You can still use\r\nthe previous builds with the current license, or renew\r\nyour subscription to get a new license key.";
            this._msgSerialNumberHasExpired.Visible = false;
            this._msgTooLongCustomerName.Enabled = false;
            this._msgTooLongCustomerName.Location = new Point(471, 24);
            this._msgTooLongCustomerName.Name = "_msgTooLongCustomerName";
            this._msgTooLongCustomerName.Size = new Size(277, 16);
            this._msgTooLongCustomerName.TabIndex = 21;
            this._msgTooLongCustomerName.Text = "Customer Name is too long.";
            this._msgTooLongCustomerName.Visible = false;
            this._msgTooLongCompanyName.Enabled = false;
            this._msgTooLongCompanyName.Location = new Point(471, 56);
            this._msgTooLongCompanyName.Name = "_msgTooLongCompanyName";
            this._msgTooLongCompanyName.Size = new Size(277, 16);
            this._msgTooLongCompanyName.TabIndex = 22;
            this._msgTooLongCompanyName.Text = "Company Name is too long.";
            this._msgTooLongCompanyName.Visible = false;
            this._msgLicensedInfo.Enabled = false;
            this._msgLicensedInfo.Location = new Point(472, 216);
            this._msgLicensedInfo.Name = "_msgLicensedInfo";
            this._msgLicensedInfo.Size = new Size(276, 16);
            this._msgLicensedInfo.TabIndex = 23;
            this._msgLicensedInfo.Text = "You have licensed {0} !";
            this._msgLicensedInfo.Visible = false;
            this._msgStudioEnterprise.Enabled = false;
            this._msgStudioEnterprise.Location = new Point(472, 232);
            this._msgStudioEnterprise.Name = "_msgStudioEnterprise";
            this._msgStudioEnterprise.Size = new Size(276, 16);
            this._msgStudioEnterprise.TabIndex = 24;
            this._msgStudioEnterprise.Text = "ComponentOne Studio Enterprise(TM)";
            this._msgStudioEnterprise.Visible = false;
            this._msgStudioForDotNET.Enabled = false;
            this._msgStudioForDotNET.Location = new Point(472, 248);
            this._msgStudioForDotNET.Name = "_msgStudioForDotNET";
            this._msgStudioForDotNET.Size = new Size(276, 16);
            this._msgStudioForDotNET.TabIndex = 25;
            this._msgStudioForDotNET.Text = "ComponentOne Studio(TM) for .NET";
            this._msgStudioForDotNET.Visible = false;
            this._msgStudioForASPdotNET.Enabled = false;
            this._msgStudioForASPdotNET.Location = new Point(472, 264);
            this._msgStudioForASPdotNET.Name = "_msgStudioForASPdotNET";
            this._msgStudioForASPdotNET.Size = new Size(276, 16);
            this._msgStudioForASPdotNET.TabIndex = 26;
            this._msgStudioForASPdotNET.Text = "ComponentOne Studio(TM) for ASP.NET";
            this._msgStudioForASPdotNET.Visible = false;
            this._msgStudioForMobileDevices.Enabled = false;
            this._msgStudioForMobileDevices.Location = new Point(472, 280);
            this._msgStudioForMobileDevices.Name = "_msgStudioForMobileDevices";
            this._msgStudioForMobileDevices.Size = new Size(276, 16);
            this._msgStudioForMobileDevices.TabIndex = 27;
            this._msgStudioForMobileDevices.Text = "ComponentOne Studio(TM) for Mobile Devices";
            this._msgStudioForMobileDevices.Visible = false;
            this._msgCongratulations.Enabled = false;
            this._msgCongratulations.Location = new Point(752, 216);
            this._msgCongratulations.Name = "_msgCongratulations";
            this._msgCongratulations.TabIndex = 28;
            this._msgCongratulations.Text = "Congratulations";
            this._msgCongratulations.Visible = false;
            base.AcceptButton = this.btnOk;
            this.AutoScaleBaseSize = new Size(5, 13);
            this.BackColor = Color.White;
            base.CancelButton = this.btnCancel;
            base.ClientSize = new Size(426, 295);
            base.Controls.Add(this._msgCongratulations);
            base.Controls.Add(this._msgStudioForMobileDevices);
            base.Controls.Add(this._msgStudioForASPdotNET);
            base.Controls.Add(this._msgStudioForDotNET);
            base.Controls.Add(this._msgStudioEnterprise);
            base.Controls.Add(this._msgLicensedInfo);
            base.Controls.Add(this._msgTooLongCompanyName);
            base.Controls.Add(this._msgTooLongCustomerName);
            base.Controls.Add(this._msgSerialNumberHasExpired);
            base.Controls.Add(this._msgArchaicProductKey);
            base.Controls.Add(this._msgEmptyCustomerName);
            base.Controls.Add(this.linkEULA);
            base.Controls.Add(this.labSNTitle);
            base.Controls.Add(this.pictureBox1);
            base.Controls.Add(this.labProductName);
            base.Controls.Add(this.labHR);
            base.Controls.Add(this.edSerialNumber);
            base.Controls.Add(this.labSerialNumber);
            base.Controls.Add(this.edName);
            base.Controls.Add(this.labCompany);
            base.Controls.Add(this.labName);
            base.Controls.Add(this.btnCancel);
            base.Controls.Add(this.btnOk);
            base.Controls.Add(this.labPersonalInfo);
            base.Controls.Add(this.edCompany);
            base.Controls.Add(this._msgEmptyCompanyName);
            base.Controls.Add(this._msgInvalidSerialNumber);
            this.ForeColor = Color.Black;
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "LicensingForm";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "ComponentOne Licensing Form";
            base.ResumeLayout(false);
        }

        private bool KeyArchaic(string sn, 8 licInfo)
        {
            int num1 = (int.Parse(sn.Substring(3, 2), CultureInfo.InvariantCulture) + 2000);
            int num2 = int.Parse(sn.Substring(2, 1), CultureInfo.InvariantCulture);
            if (((licInfo.C0 * 4) + licInfo.C1) > ((num1 * 4) + num2))
            {
                this.edSerialNumber.Focus();
                MessageBox.Show(this._msgArchaicProductKey.Text, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }
            return false;
        }

        private void linkEULA_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            e.Link.Visited = true;
            Process.Start("http://www.componentone.com/userpage/DesktopDefault.aspx?tabindex=0&tabsubindex=3&tabid=9");
        }


        // Fields
        private Assembly _asm;
        internal string _caption;
        internal string _info;
        internal string _licenseKey;
        private bool _memberOfStudio;
        private bool _mobileProduct;
        private TextBox _msgArchaicProductKey;
        private Label _msgCongratulations;
        private Label _msgEmptyCompanyName;
        private Label _msgEmptyCustomerName;
        private Label _msgInvalidSerialNumber;
        private Label _msgLicensedInfo;
        private TextBox _msgSerialNumberHasExpired;
        private Label _msgStudioEnterprise;
        private Label _msgStudioForASPdotNET;
        private Label _msgStudioForDotNET;
        private Label _msgStudioForMobileDevices;
        private Label _msgTooLongCompanyName;
        private Label _msgTooLongCustomerName;
        private bool _webProduct;
        private Button btnCancel;
        private Button btnOk;
        private IContainer components;
        private ContextMenu contextMenu1;
        private TextBox edCompany;
        private TextBox edName;
        private TextBox edSerialNumber;
        private MenuItem itemCopy;
        private Label labCompany;
        private Label labHR;
        private Label labName;
        private Label labPersonalInfo;
        private Label labProductName;
        private Label labSerialNumber;
        private Label labSNTitle;
        private LinkLabel linkEULA;
        private PictureBox pictureBox1;
        private ToolTip toolTip1;
    }
}

