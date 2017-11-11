namespace C1.Win
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Reflection;
    using System.Resources;
    using System.Security;
    using System.Windows.Forms;

    internal class AboutForm : Form
    {
        // Methods
        internal AboutForm() : this(Assembly.GetExecutingAssembly(), null, true)
        {
        }

        internal AboutForm(Assembly asm, object instance, bool designTime)
        {
            8 2;
            int num1;
            int num2;
            Point point1;
            this._memberOfStudio = true;
            this._webProduct = false;
            this._mobileProduct = false;
            this._linkURL = null;
            this._newLicense = null;
            this.InitializeComponent();
            G.2L(this, this.components);
            this._asm = asm;
            2 1 = ((2) Attribute.GetCustomAttribute(asm, typeof(2)));
            if (1 == null)
            {
                goto Label_00B8;
            }
            string text3 = 1.WP;
            if (text3 == null)
            {
                goto Label_00AF;
            }
            text3 = string.IsInterned(text3);
            if (text3 == "21B11D57-9478-420e-A2B2-4C6AAEF98E46")
            {
                goto Label_00BF;
            }
            if (text3 != "08F7D405-7096-4b5f-A288-F749B8C83E6A")
            {
                if (text3 == "5C114645-719C-4545-891F-1DE9152952A4")
                {
                    goto Label_00A6;
                }
                goto Label_00AF;
            }
            this._webProduct = true;
            goto Label_00BF;
        Label_00A6:
            this._mobileProduct = true;
            goto Label_00BF;
        Label_00AF:
            this._memberOfStudio = false;
            goto Label_00BF;
        Label_00B8:
            this._memberOfStudio = false;
        Label_00BF:
            2 = 9.28(asm, instance, designTime);
            bool flag1 = 2.BV;
            string text1 = ((AssemblyProductAttribute) Attribute.GetCustomAttribute(asm, typeof(AssemblyProductAttribute))).Product;
            object[] objArray1 = new object[1];
            objArray1[0] = text1;
            this.Text = string.Format(CultureInfo.InvariantCulture, this.Text, objArray1);
            this.labProductName.Text = text1;
            A a1 = 9.24(asm);
            this.labProductVersion.Text = a1.CG;
            if (!this._memberOfStudio)
            {
                this.labStudioName.Visible = false;
            }
            else if (this._webProduct)
            {
                this.labStudioName.Text = this.labStudioName.Text.Replace(".NET", "ASP.NET");
            }
            else if (this._mobileProduct)
            {
                this.labStudioName.Text = this.labStudioName.Text.Replace(".NET", "Mobile Devices");
            }
            string text2 = a1.CK.ToString(CultureInfo.InvariantCulture);
            if (a1.CK > 2002)
            {
                objArray1 = new object[1];
                objArray1[0] = "-" + text2;
                this.labCopyright.Text = string.Format(CultureInfo.InvariantCulture, this.labCopyright.Text, objArray1);
            }
            else
            {
                objArray1 = new object[1];
                objArray1[0] = ", " + text2;
                this.labCopyright.Text = string.Format(CultureInfo.InvariantCulture, this.labCopyright.Text, objArray1);
            }
            if (designTime || flag1)
            {
                if (flag1 || ((2.BX && (2.BW != 7.BO)) && (2.BW != 7.BN)))
                {
                    this.labCustomerName.Text = 2.BY;
                    this.labCustomerCompany.Text = 2.BZ;
                    if (2.BX)
                    {
                        num1 = (2.C0 + 1);
                        num2 = (2.C1 + 1);
                        if (num2 == 5)
                        {
                            num1 += 1;
                            num2 = 1;
                        }
                        objArray1 = new object[2];
                        objArray1[0] = num2;
                        objArray1[1] = num1;
                        this.labSubscriptionExpired.Text = string.Format(CultureInfo.InvariantCulture, this.labSubscriptionExpired.Text, objArray1);
                        this.labSubscriptionExpired.Visible = true;
                    }
                    this.labEvaluationMsg1.Visible = false;
                    this.labEvaluationMsg2.Visible = false;
                }
                else
                {
                    if (9.29(asm))
                    {
                        this.labEvalExpired.Visible = true;
                    }
                    this.labCustomerName.Visible = false;
                    this.labCustomerCompany.Visible = false;
                }
            }
            else
            {
                this.labLicensedTo.Visible = false;
                this.btnLicense.Visible = false;
                this.btnRegister.Visible = false;
                this.btnPurchase.Visible = false;
                point1 = this.labProductName.Location;
                this.labProductName.Location = new Point(point1.X, 64);
                point1 = this.labVersionCaption.Location;
                this.labVersionCaption.Location = new Point(point1.X, 86);
                point1 = this.labProductVersion.Location;
                this.labProductVersion.Location = new Point(point1.X, 86);
                if (Attribute.GetCustomAttribute(asm, typeof(3)) != null)
                {
                    point1 = this.panel1.Location;
                    this.panel1.Location = new Point(point1.X, 134);
                    this.labCustomerName.Visible = false;
                    this.labCustomerCompany.Visible = false;
                }
                else
                {
                    this.panel1.Visible = false;
                    if (G.CS.Name.StartsWith("de"))
                    {
                        point1 = this.labRuntimeMsg1.Location;
                        this.labRuntimeMsg1.Location = new Point(217, point1.Y);
                        point1 = this.labRuntimeMsg2.Location;
                        this.labRuntimeMsg2.Location = new Point(217, point1.Y);
                    }
                    this.labRuntimeMsg1.Visible = true;
                    this.labRuntimeMsg2.Visible = true;
                }
            }
            this.linkHome.Tag = "http://www.componentone.com/default.aspx";
            5 3 = ((5) Attribute.GetCustomAttribute(asm, typeof(5)));
            if (3.WU.Length > 0)
            {
                this.linkUpdates.Tag = 3.WU;
            }
            else
            {
                this.linkUpdates.Tag = "http://www.componentone.com/Download.aspx?DownloadCode=1";
            }
            if (3.WT.Length > 0)
            {
                this.linkNewsgroup.Tag = 3.WT;
            }
            else
            {
                this.linkNewsgroup.Tag = "http://www.componentone.com/pages.aspx?pagesid=52";
            }
            this.linkWebStore.Tag = "http://www.store.yahoo.com/componentone-llc/";
            this.linkResellers.Tag = "http://www.componentone.com/resellers.aspx?ResellerCode=1";
            this.linkProductSupport.Text = 3.WS;
            string[] textArray1 = new string[7];
            textArray1[0] = "mailto:";
            textArray1[1] = 3.WS;
            textArray1[2] = "?subject=";
            textArray1[3] = text1;
            textArray1[4] = " (version ";
            textArray1[5] = this.labProductVersion.Text;
            textArray1[6] = ")";
            this.linkProductSupport.Tag = textArray1;
            this.linkProductSupport.LinkArea = new LinkArea(0, this.linkProductSupport.Text.Length);
            this.linkContactUs.Tag = "http://www.componentone.com/pages.aspx?pagesID=31";
            this.linkSupportOptions.Tag = "http://www.componentone.com/Support.aspx?SupportCode=1";
        }

        private void btnLicense_Click(object sender, EventArgs e)
        {
            8 1;
            LicensingForm form1 = new LicensingForm(this._asm, this._memberOfStudio, this._webProduct, this._mobileProduct);
            if (form1.ShowDialog() == DialogResult.OK)
            {
                1 = 9.21(form1._licenseKey, this._asm, null, true);
                if (1.BV)
                {
                    this.labCustomerName.Text = 1.BY;
                    this.labCustomerCompany.Text = 1.BZ;
                    this.labCustomerName.Visible = true;
                    this.labCustomerCompany.Visible = true;
                    this.labEvaluationMsg1.Visible = false;
                    this.labEvaluationMsg2.Visible = false;
                    this.labSubscriptionExpired.Visible = false;
                    this.labEvalExpired.Visible = false;
                    if (this._newLicense != null)
                    {
                        this._newLicense.Dispose();
                    }
                    this._newLicense = new 6(form1._licenseKey);
                    MessageBox.Show(form1._info, form1._caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            form1.Dispose();
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.componentone.com/pages.aspx?pagesid=60");
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.componentone.com/userpage/DesktopDefault.aspx?tabindex=0&tabsubindex=2&tabid=9");
        }

        private void Copy_Click(object sender, EventArgs e)
        {
            if (this._linkURL != null)
            {
                Clipboard.SetDataObject(this._linkURL, true);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this._newLicense != null)
                {
                    this._newLicense.Dispose();
                    this._newLicense = null;
                }
                if (this.components != null)
                {
                    this.components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ResourceManager manager1 = new ResourceManager(typeof(AboutForm));
            this.labCustomerCompany = new Label();
            this.btnOk = new Button();
            this.panel1 = new Panel();
            this.labEvaluationMsg1 = new Label();
            this.labEvaluationMsg2 = new Label();
            this.labCustomerName = new Label();
            this.linkHome = new LinkLabel();
            this.contextMenu1 = new ContextMenu();
            this.itemCopy = new MenuItem();
            this.labLicensedTo = new Label();
            this.pictureBox2 = new PictureBox();
            this.pictureBox1 = new PictureBox();
            this.pictureBox3 = new PictureBox();
            this.btnLicense = new Button();
            this.label3 = new Label();
            this.label4 = new Label();
            this.linkSupportOptions = new LinkLabel();
            this.labSupportInfo = new Label();
            this.linkProductSupport = new LinkLabel();
            this.labProductName = new Label();
            this.labCopyright = new Label();
            this.btnRegister = new Button();
            this.btnPurchase = new Button();
            this.labVersionCaption = new Label();
            this.labProductVersion = new Label();
            this.labStudioName = new Label();
            this.linkWebStore = new LinkLabel();
            this.linkUpdates = new LinkLabel();
            this.linkNewsgroup = new LinkLabel();
            this.linkResellers = new LinkLabel();
            this.toolTip1 = new ToolTip(this.components);
            this.labEvalExpired = new Label();
            this.labSubscriptionExpired = new Label();
            this.linkContactUs = new LinkLabel();
            this.label5 = new Label();
            this.labRuntimeMsg1 = new Label();
            this.labRuntimeMsg2 = new Label();
            this.panelGlobalInfo = new Panel();
            this.linkGlobalHome = new LinkLabel();
            this.labGlobalMsg1 = new Label();
            this.labGlobalMsg2 = new Label();
            this.labGlobalMsg3 = new Label();
            this.panel1.SuspendLayout();
            this.panelGlobalInfo.SuspendLayout();
            base.SuspendLayout();
            this.labCustomerCompany.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.labCustomerCompany.ForeColor = Color.Black;
            this.labCustomerCompany.Location = new Point(6, 22);
            this.labCustomerCompany.Name = "labCustomerCompany";
            this.labCustomerCompany.Size = new Size(348, 14);
            this.labCustomerCompany.TabIndex = 1;
            this.labCustomerCompany.Text = "Customer Company";
            this.labCustomerCompany.UseMnemonic = false;
            this.btnOk.BackColor = SystemColors.Control;
            this.btnOk.DialogResult = DialogResult.OK;
            this.btnOk.FlatStyle = FlatStyle.Flat;
            this.btnOk.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnOk.ForeColor = Color.Black;
            this.btnOk.Location = new Point(496, 324);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new Size(76, 24);
            this.btnOk.TabIndex = 11;
            this.btnOk.Text = "OK";
            this.panel1.BorderStyle = BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.labEvaluationMsg1);
            this.panel1.Controls.Add(this.labEvaluationMsg2);
            this.panel1.Controls.Add(this.labCustomerName);
            this.panel1.Controls.Add(this.labCustomerCompany);
            this.panel1.Location = new Point(224, 112);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(348, 42);
            this.panel1.TabIndex = 9;
            this.labEvaluationMsg1.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.labEvaluationMsg1.ForeColor = Color.Red;
            this.labEvaluationMsg1.Location = new Point(6, 4);
            this.labEvaluationMsg1.Name = "labEvaluationMsg1";
            this.labEvaluationMsg1.Size = new Size(340, 14);
            this.labEvaluationMsg1.TabIndex = 28;
            this.labEvaluationMsg1.Text = "NOT LICENSED. THIS IS AN EVALUATION VERSION";
            this.labEvaluationMsg1.TextAlign = ContentAlignment.TopCenter;
            this.labEvaluationMsg1.UseMnemonic = false;
            this.labEvaluationMsg2.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.labEvaluationMsg2.ForeColor = Color.Red;
            this.labEvaluationMsg2.Location = new Point(6, 22);
            this.labEvaluationMsg2.Name = "labEvaluationMsg2";
            this.labEvaluationMsg2.Size = new Size(340, 14);
            this.labEvaluationMsg2.TabIndex = 29;
            this.labEvaluationMsg2.Text = "You can use this product for a 30-day trial period.";
            this.labEvaluationMsg2.TextAlign = ContentAlignment.TopCenter;
            this.labEvaluationMsg2.UseMnemonic = false;
            this.labCustomerName.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.labCustomerName.ForeColor = Color.Black;
            this.labCustomerName.Location = new Point(6, 4);
            this.labCustomerName.Name = "labCustomerName";
            this.labCustomerName.Size = new Size(348, 14);
            this.labCustomerName.TabIndex = 0;
            this.labCustomerName.Text = "Customer Name";
            this.labCustomerName.UseMnemonic = false;
            this.linkHome.ContextMenu = this.contextMenu1;
            this.linkHome.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.linkHome.LinkArea = new LinkArea(0, 27);
            this.linkHome.Location = new Point(172, 216);
            this.linkHome.Name = "linkHome";
            this.linkHome.Size = new Size(188, 16);
            this.linkHome.TabIndex = 3;
            this.linkHome.TabStop = true;
            this.linkHome.Tag = "";
            this.linkHome.Text = "http://www.componentone.com";
            this.linkHome.LinkClicked += new LinkLabelLinkClickedEventHandler(this.link_LinkClicked);
            this.linkHome.MouseEnter += new EventHandler(this.link_MouseEnter);
            this.contextMenu1.MenuItems.Add(this.itemCopy);
            this.itemCopy.Index = 0;
            this.itemCopy.Text = "Copy URL";
            this.itemCopy.Click += new EventHandler(this.Copy_Click);
            this.labLicensedTo.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.labLicensedTo.ForeColor = Color.Black;
            this.labLicensedTo.Location = new Point(224, 96);
            this.labLicensedTo.Name = "labLicensedTo";
            this.labLicensedTo.Size = new Size(320, 16);
            this.labLicensedTo.TabIndex = 8;
            this.labLicensedTo.Text = "This product is licensed to:";
            this.pictureBox2.Image = 9.1J(manager1.GetObject("pictureBox2.Image"));
            this.pictureBox2.Location = new Point(224, 8);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new Size(320, 56);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            this.pictureBox1.Image = 9.1J(manager1.GetObject("pictureBox1.Image"));
            this.pictureBox1.Location = new Point(12, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(192, 160);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox3.Image = 9.1J(manager1.GetObject("pictureBox3.Image"));
            this.pictureBox3.Location = new Point(216, 1);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new Size(175, 19);
            this.pictureBox3.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 30;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Visible = false;
            this.btnLicense.BackColor = SystemColors.Control;
            this.btnLicense.FlatStyle = FlatStyle.Flat;
            this.btnLicense.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnLicense.ForeColor = Color.Black;
            this.btnLicense.Location = new Point(281, 160);
            this.btnLicense.Name = "btnLicense";
            this.btnLicense.Size = new Size(74, 24);
            this.btnLicense.TabIndex = 0;
            this.btnLicense.Text = "License";
            this.toolTip1.SetToolTip(this.btnLicense, "Click here if you purchased the product and already have a license key.");
            this.btnLicense.Click += new EventHandler(this.btnLicense_Click);
            this.label3.BackColor = Color.Black;
            this.label3.BorderStyle = BorderStyle.FixedSingle;
            this.label3.ForeColor = Color.Black;
            this.label3.Location = new Point(12, 309);
            this.label3.Name = "label3";
            this.label3.Size = new Size(560, 3);
            this.label3.TabIndex = 20;
            this.label4.Font = new Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label4.ForeColor = Color.Black;
            this.label4.Location = new Point(12, 216);
            this.label4.Name = "label4";
            this.label4.Size = new Size(140, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Online Resources:";
            this.linkSupportOptions.ContextMenu = this.contextMenu1;
            this.linkSupportOptions.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.linkSupportOptions.LinkArea = new LinkArea(0, 30);
            this.linkSupportOptions.Location = new Point(278, 284);
            this.linkSupportOptions.Name = "linkSupportOptions";
            this.linkSupportOptions.Size = new Size(266, 16);
            this.linkSupportOptions.TabIndex = 10;
            this.linkSupportOptions.TabStop = true;
            this.linkSupportOptions.Tag = "";
            this.linkSupportOptions.Text = "ComponentOne Technical Support";
            this.linkSupportOptions.LinkClicked += new LinkLabelLinkClickedEventHandler(this.link_LinkClicked);
            this.linkSupportOptions.MouseEnter += new EventHandler(this.link_MouseEnter);
            this.labSupportInfo.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.labSupportInfo.ForeColor = Color.Black;
            this.labSupportInfo.Location = new Point(12, 262);
            this.labSupportInfo.Name = "labSupportInfo";
            this.labSupportInfo.Size = new Size(264, 16);
            this.labSupportInfo.TabIndex = 17;
            this.labSupportInfo.Text = "For email support, please write to:";
            this.labSupportInfo.TextAlign = ContentAlignment.TopRight;
            this.linkProductSupport.ContextMenu = this.contextMenu1;
            this.linkProductSupport.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.linkProductSupport.Location = new Point(278, 262);
            this.linkProductSupport.Name = "linkProductSupport";
            this.linkProductSupport.Size = new Size(302, 16);
            this.linkProductSupport.TabIndex = 8;
            this.linkProductSupport.TabStop = true;
            this.linkProductSupport.Tag = "";
            this.linkProductSupport.Text = "Support.C1Product.NET@ComponentOne.com";
            this.linkProductSupport.LinkClicked += new LinkLabelLinkClickedEventHandler(this.link_LinkClicked);
            this.linkProductSupport.MouseEnter += new EventHandler(this.link_MouseEnter);
            this.labProductName.Font = new Font("Verdana", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.labProductName.ForeColor = Color.Black;
            this.labProductName.Location = new Point(223, 60);
            this.labProductName.Name = "labProductName";
            this.labProductName.Size = new Size(361, 16);
            this.labProductName.TabIndex = 0;
            this.labProductName.Text = "ComponentOne Product Name";
            this.labCopyright.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.labCopyright.ForeColor = Color.Black;
            this.labCopyright.Location = new Point(12, 336);
            this.labCopyright.Name = "labCopyright";
            this.labCopyright.Size = new Size(482, 16);
            this.labCopyright.TabIndex = 1;
            this.labCopyright.Text = "Copyright (C) 2001{0} ComponentOne LLC. All rights reserved.";
            this.btnRegister.BackColor = SystemColors.Control;
            this.btnRegister.FlatStyle = FlatStyle.Flat;
            this.btnRegister.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnRegister.ForeColor = Color.Black;
            this.btnRegister.Location = new Point(361, 160);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new Size(74, 24);
            this.btnRegister.TabIndex = 1;
            this.btnRegister.Tag = "";
            this.btnRegister.Text = "Register";
            this.toolTip1.SetToolTip(this.btnRegister, "Click here to register online (so we can send you quarterly updates).");
            this.btnRegister.Click += new EventHandler(this.btnRegister_Click);
            this.btnPurchase.BackColor = SystemColors.Control;
            this.btnPurchase.FlatStyle = FlatStyle.Flat;
            this.btnPurchase.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnPurchase.ForeColor = Color.Black;
            this.btnPurchase.Location = new Point(441, 160);
            this.btnPurchase.Name = "btnPurchase";
            this.btnPurchase.Size = new Size(74, 24);
            this.btnPurchase.TabIndex = 2;
            this.btnPurchase.Tag = "";
            this.btnPurchase.Text = "Purchase";
            this.toolTip1.SetToolTip(this.btnPurchase, "Click here to buy a copy of the product. After you purchase, you should license and register it.");
            this.btnPurchase.Click += new EventHandler(this.btnPurchase_Click);
            this.labVersionCaption.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.labVersionCaption.ForeColor = Color.Black;
            this.labVersionCaption.Location = new Point(224, 78);
            this.labVersionCaption.Name = "labVersionCaption";
            this.labVersionCaption.Size = new Size(64, 16);
            this.labVersionCaption.TabIndex = 15;
            this.labVersionCaption.Text = "Version:";
            this.labProductVersion.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.labProductVersion.ForeColor = Color.Black;
            this.labProductVersion.Location = new Point(296, 78);
            this.labProductVersion.Name = "labProductVersion";
            this.labProductVersion.Size = new Size(248, 15);
            this.labProductVersion.TabIndex = 16;
            this.labProductVersion.Text = "1.1.20021.12345";
            this.labStudioName.Font = new Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.labStudioName.ForeColor = Color.Black;
            this.labStudioName.Location = new Point(12, 318);
            this.labStudioName.Name = "labStudioName";
            this.labStudioName.Size = new Size(482, 16);
            this.labStudioName.TabIndex = 19;
            this.labStudioName.Text = "This product is included in ComponentOne Studio(TM) for .NET";
            this.linkWebStore.ContextMenu = this.contextMenu1;
            this.linkWebStore.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.linkWebStore.LinkArea = new LinkArea(0, 9);
            this.linkWebStore.Location = new Point(278, 238);
            this.linkWebStore.Name = "linkWebStore";
            this.linkWebStore.Size = new Size(98, 16);
            this.linkWebStore.TabIndex = 6;
            this.linkWebStore.TabStop = true;
            this.linkWebStore.Tag = "";
            this.linkWebStore.Text = "Web Store";
            this.linkWebStore.LinkClicked += new LinkLabelLinkClickedEventHandler(this.link_LinkClicked);
            this.linkWebStore.MouseEnter += new EventHandler(this.link_MouseEnter);
            this.linkUpdates.ContextMenu = this.contextMenu1;
            this.linkUpdates.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.linkUpdates.LinkArea = new LinkArea(0, 24);
            this.linkUpdates.Location = new Point(380, 216);
            this.linkUpdates.Name = "linkUpdates";
            this.linkUpdates.Size = new Size(180, 16);
            this.linkUpdates.TabIndex = 4;
            this.linkUpdates.TabStop = true;
            this.linkUpdates.Tag = "";
            this.linkUpdates.Text = "Check for online updates";
            this.linkUpdates.LinkClicked += new LinkLabelLinkClickedEventHandler(this.link_LinkClicked);
            this.linkUpdates.MouseEnter += new EventHandler(this.link_MouseEnter);
            this.linkNewsgroup.ContextMenu = this.contextMenu1;
            this.linkNewsgroup.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.linkNewsgroup.LinkArea = new LinkArea(0, 9);
            this.linkNewsgroup.Location = new Point(172, 238);
            this.linkNewsgroup.Name = "linkNewsgroup";
            this.linkNewsgroup.Size = new Size(104, 16);
            this.linkNewsgroup.TabIndex = 5;
            this.linkNewsgroup.TabStop = true;
            this.linkNewsgroup.Tag = "";
            this.linkNewsgroup.Text = "Newsgroup";
            this.linkNewsgroup.LinkClicked += new LinkLabelLinkClickedEventHandler(this.link_LinkClicked);
            this.linkNewsgroup.MouseEnter += new EventHandler(this.link_MouseEnter);
            this.linkResellers.ContextMenu = this.contextMenu1;
            this.linkResellers.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.linkResellers.LinkArea = new LinkArea(0, 9);
            this.linkResellers.Location = new Point(380, 238);
            this.linkResellers.Name = "linkResellers";
            this.linkResellers.Size = new Size(160, 16);
            this.linkResellers.TabIndex = 7;
            this.linkResellers.TabStop = true;
            this.linkResellers.Tag = "";
            this.linkResellers.Text = "Resellers";
            this.linkResellers.LinkClicked += new LinkLabelLinkClickedEventHandler(this.link_LinkClicked);
            this.linkResellers.MouseEnter += new EventHandler(this.link_MouseEnter);
            this.toolTip1.AutoPopDelay = 20000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            this.labEvalExpired.Font = new Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.labEvalExpired.ForeColor = Color.Red;
            this.labEvalExpired.Location = new Point(224, 188);
            this.labEvalExpired.Name = "labEvalExpired";
            this.labEvalExpired.Size = new Size(352, 16);
            this.labEvalExpired.TabIndex = 10;
            this.labEvalExpired.Text = "This evaluation version has expired.";
            this.toolTip1.SetToolTip(this.labEvalExpired, "Please check our web site for a new version.");
            this.labEvalExpired.Visible = false;
            this.labSubscriptionExpired.Font = new Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.labSubscriptionExpired.ForeColor = Color.Red;
            this.labSubscriptionExpired.Location = new Point(224, 188);
            this.labSubscriptionExpired.Name = "labSubscriptionExpired";
            this.labSubscriptionExpired.Size = new Size(352, 16);
            this.labSubscriptionExpired.TabIndex = 28;
            this.labSubscriptionExpired.Text = "Your subscription has expired since Q{0} {1}.";
            this.toolTip1.SetToolTip(this.labSubscriptionExpired, "Renew your subscription to get a new license key, or keep using the components released while your subscription was valid.");
            this.labSubscriptionExpired.Visible = false;
            this.linkContactUs.ContextMenu = this.contextMenu1;
            this.linkContactUs.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.linkContactUs.Location = new Point(172, 284);
            this.linkContactUs.Name = "linkContactUs";
            this.linkContactUs.Size = new Size(132, 16);
            this.linkContactUs.TabIndex = 9;
            this.linkContactUs.TabStop = true;
            this.linkContactUs.Tag = "";
            this.linkContactUs.Text = "Contact Us";
            this.linkContactUs.LinkClicked += new LinkLabelLinkClickedEventHandler(this.link_LinkClicked);
            this.linkContactUs.MouseEnter += new EventHandler(this.link_MouseEnter);
            this.label5.BackColor = Color.Black;
            this.label5.BorderStyle = BorderStyle.FixedSingle;
            this.label5.ForeColor = Color.Black;
            this.label5.Location = new Point(12, 204);
            this.label5.Name = "label5";
            this.label5.Size = new Size(560, 3);
            this.label5.TabIndex = 24;
            this.labRuntimeMsg1.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.labRuntimeMsg1.ForeColor = Color.Red;
            this.labRuntimeMsg1.Location = new Point(224, 154);
            this.labRuntimeMsg1.Name = "labRuntimeMsg1";
            this.labRuntimeMsg1.Size = new Size(382, 16);
            this.labRuntimeMsg1.TabIndex = 25;
            this.labRuntimeMsg1.Text = "This dialog box will not be shown if you recompile the program";
            this.labRuntimeMsg1.Visible = false;
            this.labRuntimeMsg2.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.labRuntimeMsg2.ForeColor = Color.Red;
            this.labRuntimeMsg2.Location = new Point(224, 176);
            this.labRuntimeMsg2.Name = "labRuntimeMsg2";
            this.labRuntimeMsg2.Size = new Size(362, 16);
            this.labRuntimeMsg2.TabIndex = 26;
            this.labRuntimeMsg2.Text = "using a licensed version of this product.";
            this.labRuntimeMsg2.Visible = false;
            this.panelGlobalInfo.Controls.Add(this.linkGlobalHome);
            this.panelGlobalInfo.Controls.Add(this.labGlobalMsg1);
            this.panelGlobalInfo.Controls.Add(this.labGlobalMsg2);
            this.panelGlobalInfo.Controls.Add(this.labGlobalMsg3);
            this.panelGlobalInfo.Controls.Add(this.pictureBox3);
            this.panelGlobalInfo.Location = new Point(8, 212);
            this.panelGlobalInfo.Name = "panelGlobalInfo";
            this.panelGlobalInfo.Size = new Size(568, 92);
            this.panelGlobalInfo.TabIndex = 27;
            this.panelGlobalInfo.Visible = false;
            this.linkGlobalHome.ContextMenu = this.contextMenu1;
            this.linkGlobalHome.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.linkGlobalHome.Location = new Point(216, 71);
            this.linkGlobalHome.Name = "linkGlobalHome";
            this.linkGlobalHome.Size = new Size(336, 16);
            this.linkGlobalHome.TabIndex = 3;
            this.linkGlobalHome.TabStop = true;
            this.linkGlobalHome.Text = "linkGlobalHome";
            this.linkGlobalHome.LinkClicked += new LinkLabelLinkClickedEventHandler(this.link_LinkClicked);
            this.linkGlobalHome.MouseEnter += new EventHandler(this.link_MouseEnter);
            this.labGlobalMsg1.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.labGlobalMsg1.ForeColor = Color.Black;
            this.labGlobalMsg1.Location = new Point(216, 4);
            this.labGlobalMsg1.Name = "labGlobalMsg1";
            this.labGlobalMsg1.Size = new Size(336, 16);
            this.labGlobalMsg1.TabIndex = 0;
            this.labGlobalMsg1.Text = "msg1";
            this.labGlobalMsg2.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.labGlobalMsg2.ForeColor = Color.Black;
            this.labGlobalMsg2.Location = new Point(216, 28);
            this.labGlobalMsg2.Name = "labGlobalMsg2";
            this.labGlobalMsg2.Size = new Size(336, 16);
            this.labGlobalMsg2.TabIndex = 1;
            this.labGlobalMsg2.Text = "msg2";
            this.labGlobalMsg3.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.labGlobalMsg3.ForeColor = Color.Black;
            this.labGlobalMsg3.Location = new Point(216, 50);
            this.labGlobalMsg3.Name = "labGlobalMsg3";
            this.labGlobalMsg3.Size = new Size(336, 16);
            this.labGlobalMsg3.TabIndex = 2;
            this.labGlobalMsg3.Text = "msg3";
            base.AcceptButton = this.btnOk;
            this.AutoScaleBaseSize = new Size(5, 13);
            this.BackColor = Color.White;
            base.ClientSize = new Size(585, 359);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.panelGlobalInfo);
            base.Controls.Add(this.linkProductSupport);
            base.Controls.Add(this.linkSupportOptions);
            base.Controls.Add(this.labSubscriptionExpired);
            base.Controls.Add(this.label5);
            base.Controls.Add(this.labProductName);
            base.Controls.Add(this.labEvalExpired);
            base.Controls.Add(this.linkContactUs);
            base.Controls.Add(this.linkResellers);
            base.Controls.Add(this.linkNewsgroup);
            base.Controls.Add(this.linkUpdates);
            base.Controls.Add(this.linkWebStore);
            base.Controls.Add(this.labStudioName);
            base.Controls.Add(this.labProductVersion);
            base.Controls.Add(this.labVersionCaption);
            base.Controls.Add(this.btnPurchase);
            base.Controls.Add(this.btnRegister);
            base.Controls.Add(this.labCopyright);
            base.Controls.Add(this.labSupportInfo);
            base.Controls.Add(this.btnOk);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.labLicensedTo);
            base.Controls.Add(this.panel1);
            base.Controls.Add(this.linkHome);
            base.Controls.Add(this.btnLicense);
            base.Controls.Add(this.pictureBox1);
            base.Controls.Add(this.labRuntimeMsg2);
            base.Controls.Add(this.labRuntimeMsg1);
            base.Controls.Add(this.pictureBox2);
            this.ForeColor = Color.Black;
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "AboutForm";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "About {0}";
            this.panel1.ResumeLayout(false);
            this.panelGlobalInfo.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private void link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            e.Link.Visited = true;
            this.SetLinkURL(sender);
            try
            {
                this.SafeNavigate();
            }
            catch (SecurityException)
            {
            }
        }

        private void link_MouseEnter(object sender, EventArgs e)
        {
            this.SetLinkURL(sender);
        }

        private void SafeNavigate()
        {
            if (this._linkURL != null)
            {
                Process.Start(this._linkURL);
            }
        }

        private void SetLinkURL(object sender)
        {
            LinkArea area1;
            LinkLabel label1 = ((LinkLabel) sender);
            string text1 = ((string) label1.Tag);
            if ((text1 == null) || (text1.Length == 0))
            {
                area1 = label1.LinkArea;
                area1 = label1.LinkArea;
                text1 = label1.Text.Substring(area1.Start, area1.Length);
            }
            if (text1.Length > 0)
            {
                this._linkURL = text1;
                return;
            }
            this._linkURL = null;
        }


        // Fields
        private Assembly _asm;
        private string _linkURL;
        private bool _memberOfStudio;
        private bool _mobileProduct;
        internal 6 _newLicense;
        private bool _webProduct;
        private Button btnLicense;
        private Button btnOk;
        private Button btnPurchase;
        private Button btnRegister;
        private IContainer components;
        private ContextMenu contextMenu1;
        private MenuItem itemCopy;
        private Label labCopyright;
        private Label labCustomerCompany;
        private Label labCustomerName;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label labEvalExpired;
        private Label labEvaluationMsg1;
        private Label labEvaluationMsg2;
        private Label labGlobalMsg1;
        private Label labGlobalMsg2;
        private Label labGlobalMsg3;
        private Label labLicensedTo;
        private Label labProductName;
        private Label labProductVersion;
        private Label labRuntimeMsg1;
        private Label labRuntimeMsg2;
        private Label labStudioName;
        private Label labSubscriptionExpired;
        private Label labSupportInfo;
        private Label labVersionCaption;
        private LinkLabel linkContactUs;
        private LinkLabel linkGlobalHome;
        private LinkLabel linkHome;
        private LinkLabel linkNewsgroup;
        private LinkLabel linkProductSupport;
        private LinkLabel linkResellers;
        private LinkLabel linkSupportOptions;
        private LinkLabel linkUpdates;
        private LinkLabel linkWebStore;
        private Panel panel1;
        private Panel panelGlobalInfo;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private ToolTip toolTip1;
    }
}

