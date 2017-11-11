using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace executavel
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		#region MAIN
			[STAThread]
			static void Main() 
			{
				Application.Run(new Form1());
			}
		#endregion

		#region Atributes
			private System.Windows.Forms.GroupBox m_gbGeral;
			private System.Windows.Forms.GroupBox m_gbComboBox;
			private System.Windows.Forms.Button m_btCBFill;
			private System.Windows.Forms.Button m_btCBClear;
			private System.Windows.Forms.TextBox m_txtCBOutput;
			private System.Windows.Forms.Label m_lbCBOutput;
			private System.Windows.Forms.CheckBox m_ckCBAutoComplete;
			private System.Windows.Forms.GroupBox m_gbPictureBox;
			private System.Windows.Forms.Button m_btRefresh;
			private mdlComponentesGraficos.PictureBox m_picPictureBox;
			private System.Windows.Forms.Button m_btPictureBoxTeste;
			private mdlComponentesGraficos.Button m_btButton;
			private System.Windows.Forms.GroupBox m_gbTaskBarNotifier;
			private System.Windows.Forms.Button m_btTaskBarNotifier;
			private System.Windows.Forms.GroupBox m_gbFormSkin;
			private System.Windows.Forms.Button m_btFormSkin;
			private System.Windows.Forms.GroupBox m_dgTextBox;
			private System.Windows.Forms.Label m_lbMask;
			private mdlComponentesGraficos.TextBox m_txtTextBox;
			private mdlComponentesGraficos.TextBox m_txtMask;
			private System.Windows.Forms.Label label1;
			private System.Windows.Forms.Button m_btAtivarMascara;
			private System.Windows.Forms.Button m_btTextBoxCheck;
			private mdlComponentesGraficos.TextBox m_txtTextBoxRetorno;
			private System.Windows.Forms.Label m_lbTextBoxRetorno;
			private mdlComponentesGraficos.TabControl m_tcTabControl;
			private System.Windows.Forms.TabPage tabPage1;
			private System.Windows.Forms.GroupBox groupBox1;
			private mdlComponentesGraficos.ComboBox m_cbComboBox;
			private System.Windows.Forms.CheckBox m_ckTextBoxShadow;
			private System.Windows.Forms.CheckBox m_ckAutoCompleteCaseSensitive;
			private System.Windows.Forms.CheckBox m_ckAutoCompleteSpecialCharacters;
			private System.Windows.Forms.GroupBox m_gbTextBoxDateTime;
			private mdlComponentesGraficos.TextBoxDateTime m_txtdtTextBoxDateTime;
			private System.Windows.Forms.Button m_btGetData;
			private System.Windows.Forms.Button m_btSetData;
			private System.Windows.Forms.DateTimePicker m_dpTextBoxDateTime;
			private System.Windows.Forms.GroupBox m_gbMessageBalloon;
			private System.Windows.Forms.Button m_btMessageBalloon;
			private System.Windows.Forms.GroupBox m_gbDateTimePicker;
			private mdlComponentesGraficos.DateTimePicker m_dtpDate;
		private System.Windows.Forms.TextBox m_txtDataTimePickerFormat;
		private System.Windows.Forms.GroupBox m_gbPainter;
		private System.Windows.Forms.Button m_btFirstColor;
		private System.Windows.Forms.Button m_btFirstColorHits;
		private System.Windows.Forms.TextBox m_txtPainter;
		private System.Windows.Forms.TextBox m_txtPainterRetorno;
		private mdlComponentesGraficos.AnimatedPictureBox m_apicSample;
		private System.Windows.Forms.Button m_btAnimatedPictureBoxStart;
		private System.Windows.Forms.GroupBox groupBox2;
			private mdlComponentesGraficos.Button m_btBotao;
		private mdlComponentesGraficos.Button button1;
			private System.ComponentModel.Container components = null;
		#endregion
		#region Constructor and Destructor
			public Form1()
			{
				InitializeComponent();
			}
			protected override void Dispose( bool disposing )
			{
				if( disposing )
				{
					if (components != null) 
					{
						components.Dispose();
					}
				}
				base.Dispose( disposing );
			}
		#endregion
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.m_dgTextBox = new System.Windows.Forms.GroupBox();
			this.m_ckAutoCompleteSpecialCharacters = new System.Windows.Forms.CheckBox();
			this.m_ckTextBoxShadow = new System.Windows.Forms.CheckBox();
			this.m_lbTextBoxRetorno = new System.Windows.Forms.Label();
			this.m_btTextBoxCheck = new System.Windows.Forms.Button();
			this.m_btAtivarMascara = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.m_lbMask = new System.Windows.Forms.Label();
			this.m_txtMask = new mdlComponentesGraficos.TextBox();
			this.m_txtTextBoxRetorno = new mdlComponentesGraficos.TextBox();
			this.m_txtTextBox = new mdlComponentesGraficos.TextBox();
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.button1 = new mdlComponentesGraficos.Button();
			this.m_btBotao = new mdlComponentesGraficos.Button();
			this.m_gbPainter = new System.Windows.Forms.GroupBox();
			this.m_txtPainterRetorno = new System.Windows.Forms.TextBox();
			this.m_txtPainter = new System.Windows.Forms.TextBox();
			this.m_btFirstColorHits = new System.Windows.Forms.Button();
			this.m_btFirstColor = new System.Windows.Forms.Button();
			this.m_gbDateTimePicker = new System.Windows.Forms.GroupBox();
			this.m_txtDataTimePickerFormat = new System.Windows.Forms.TextBox();
			this.m_dtpDate = new mdlComponentesGraficos.DateTimePicker();
			this.m_gbMessageBalloon = new System.Windows.Forms.GroupBox();
			this.m_btMessageBalloon = new System.Windows.Forms.Button();
			this.m_gbTextBoxDateTime = new System.Windows.Forms.GroupBox();
			this.m_dpTextBoxDateTime = new System.Windows.Forms.DateTimePicker();
			this.m_btSetData = new System.Windows.Forms.Button();
			this.m_btGetData = new System.Windows.Forms.Button();
			this.m_txtdtTextBoxDateTime = new mdlComponentesGraficos.TextBoxDateTime();
			this.m_gbFormSkin = new System.Windows.Forms.GroupBox();
			this.m_btFormSkin = new System.Windows.Forms.Button();
			this.m_gbTaskBarNotifier = new System.Windows.Forms.GroupBox();
			this.m_btTaskBarNotifier = new System.Windows.Forms.Button();
			this.m_gbPictureBox = new System.Windows.Forms.GroupBox();
			this.m_btAnimatedPictureBoxStart = new System.Windows.Forms.Button();
			this.m_apicSample = new mdlComponentesGraficos.AnimatedPictureBox();
			this.m_btPictureBoxTeste = new System.Windows.Forms.Button();
			this.m_btRefresh = new System.Windows.Forms.Button();
			this.m_gbComboBox = new System.Windows.Forms.GroupBox();
			this.m_ckAutoCompleteCaseSensitive = new System.Windows.Forms.CheckBox();
			this.m_ckCBAutoComplete = new System.Windows.Forms.CheckBox();
			this.m_lbCBOutput = new System.Windows.Forms.Label();
			this.m_txtCBOutput = new System.Windows.Forms.TextBox();
			this.m_btCBClear = new System.Windows.Forms.Button();
			this.m_btCBFill = new System.Windows.Forms.Button();
			this.m_picPictureBox = new mdlComponentesGraficos.PictureBox();
			this.m_cbComboBox = new mdlComponentesGraficos.ComboBox();
			this.m_tcTabControl = new mdlComponentesGraficos.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.m_btButton = new mdlComponentesGraficos.Button();
			this.m_dgTextBox.SuspendLayout();
			this.m_gbGeral.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.m_gbPainter.SuspendLayout();
			this.m_gbDateTimePicker.SuspendLayout();
			this.m_gbMessageBalloon.SuspendLayout();
			this.m_gbTextBoxDateTime.SuspendLayout();
			this.m_gbFormSkin.SuspendLayout();
			this.m_gbTaskBarNotifier.SuspendLayout();
			this.m_gbPictureBox.SuspendLayout();
			this.m_gbComboBox.SuspendLayout();
			this.m_tcTabControl.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_dgTextBox
			// 
			this.m_dgTextBox.Controls.Add(this.m_ckAutoCompleteSpecialCharacters);
			this.m_dgTextBox.Controls.Add(this.m_ckTextBoxShadow);
			this.m_dgTextBox.Controls.Add(this.m_lbTextBoxRetorno);
			this.m_dgTextBox.Controls.Add(this.m_btTextBoxCheck);
			this.m_dgTextBox.Controls.Add(this.m_btAtivarMascara);
			this.m_dgTextBox.Controls.Add(this.label1);
			this.m_dgTextBox.Controls.Add(this.m_lbMask);
			this.m_dgTextBox.Controls.Add(this.m_txtMask);
			this.m_dgTextBox.Controls.Add(this.m_txtTextBoxRetorno);
			this.m_dgTextBox.Location = new System.Drawing.Point(280, 9);
			this.m_dgTextBox.Name = "m_dgTextBox";
			this.m_dgTextBox.Size = new System.Drawing.Size(240, 224);
			this.m_dgTextBox.TabIndex = 0;
			this.m_dgTextBox.TabStop = false;
			this.m_dgTextBox.Text = "Text Box";
			// 
			// m_ckAutoCompleteSpecialCharacters
			// 
			this.m_ckAutoCompleteSpecialCharacters.Location = new System.Drawing.Point(89, 18);
			this.m_ckAutoCompleteSpecialCharacters.Name = "m_ckAutoCompleteSpecialCharacters";
			this.m_ckAutoCompleteSpecialCharacters.Size = new System.Drawing.Size(143, 16);
			this.m_ckAutoCompleteSpecialCharacters.TabIndex = 13;
			this.m_ckAutoCompleteSpecialCharacters.Text = "AutoCompSpecialCharacters";
			// 
			// m_ckTextBoxShadow
			// 
			this.m_ckTextBoxShadow.Location = new System.Drawing.Point(16, 19);
			this.m_ckTextBoxShadow.Name = "m_ckTextBoxShadow";
			this.m_ckTextBoxShadow.Size = new System.Drawing.Size(64, 16);
			this.m_ckTextBoxShadow.TabIndex = 12;
			this.m_ckTextBoxShadow.Text = "Shadow";
			this.m_ckTextBoxShadow.CheckedChanged += new System.EventHandler(this.m_ckTextBoxShadow_CheckedChanged);
			// 
			// m_lbTextBoxRetorno
			// 
			this.m_lbTextBoxRetorno.Location = new System.Drawing.Point(12, 144);
			this.m_lbTextBoxRetorno.Name = "m_lbTextBoxRetorno";
			this.m_lbTextBoxRetorno.Size = new System.Drawing.Size(48, 16);
			this.m_lbTextBoxRetorno.TabIndex = 11;
			this.m_lbTextBoxRetorno.Text = "Retorno";
			// 
			// m_btTextBoxCheck
			// 
			this.m_btTextBoxCheck.Location = new System.Drawing.Point(100, 115);
			this.m_btTextBoxCheck.Name = "m_btTextBoxCheck";
			this.m_btTextBoxCheck.Size = new System.Drawing.Size(80, 24);
			this.m_btTextBoxCheck.TabIndex = 9;
			this.m_btTextBoxCheck.Text = "Check";
			this.m_btTextBoxCheck.Click += new System.EventHandler(this.m_btTextBoxCheck_Click);
			// 
			// m_btAtivarMascara
			// 
			this.m_btAtivarMascara.Location = new System.Drawing.Point(97, 63);
			this.m_btAtivarMascara.Name = "m_btAtivarMascara";
			this.m_btAtivarMascara.Size = new System.Drawing.Size(80, 24);
			this.m_btAtivarMascara.TabIndex = 8;
			this.m_btAtivarMascara.Text = "v";
			this.m_btAtivarMascara.Click += new System.EventHandler(this.m_btAtivarMascara_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(10, 44);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 16);
			this.label1.TabIndex = 7;
			this.label1.Text = "Mask";
			// 
			// m_lbMask
			// 
			this.m_lbMask.Location = new System.Drawing.Point(8, 93);
			this.m_lbMask.Name = "m_lbMask";
			this.m_lbMask.Size = new System.Drawing.Size(48, 16);
			this.m_lbMask.TabIndex = 5;
			this.m_lbMask.Text = "TextBox";
			// 
			// m_txtMask
			// 
			this.m_txtMask.Location = new System.Drawing.Point(64, 40);
			this.m_txtMask.Name = "m_txtMask";
			this.m_txtMask.Size = new System.Drawing.Size(160, 20);
			this.m_txtMask.TabIndex = 6;
			this.m_txtMask.Text = "";
			// 
			// m_txtTextBoxRetorno
			// 
			this.m_txtTextBoxRetorno.Location = new System.Drawing.Point(68, 144);
			this.m_txtTextBoxRetorno.Name = "m_txtTextBoxRetorno";
			this.m_txtTextBoxRetorno.Size = new System.Drawing.Size(160, 20);
			this.m_txtTextBoxRetorno.TabIndex = 10;
			this.m_txtTextBoxRetorno.Text = "";
			// 
			// m_txtTextBox
			// 
			this.m_txtTextBox.Location = new System.Drawing.Point(64, 89);
			this.m_txtTextBox.Name = "m_txtTextBox";
			this.m_txtTextBox.Size = new System.Drawing.Size(160, 20);
			this.m_txtTextBox.TabIndex = 0;
			this.m_txtTextBox.Text = "";
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Controls.Add(this.groupBox2);
			this.m_gbGeral.Controls.Add(this.m_gbPainter);
			this.m_gbGeral.Controls.Add(this.m_gbDateTimePicker);
			this.m_gbGeral.Controls.Add(this.m_gbMessageBalloon);
			this.m_gbGeral.Controls.Add(this.m_gbTextBoxDateTime);
			this.m_gbGeral.Controls.Add(this.m_gbFormSkin);
			this.m_gbGeral.Controls.Add(this.m_gbTaskBarNotifier);
			this.m_gbGeral.Controls.Add(this.m_gbPictureBox);
			this.m_gbGeral.Controls.Add(this.m_gbComboBox);
			this.m_gbGeral.Controls.Add(this.m_dgTextBox);
			this.m_gbGeral.Location = new System.Drawing.Point(4, -1);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(836, 641);
			this.m_gbGeral.TabIndex = 1;
			this.m_gbGeral.TabStop = false;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.button1);
			this.groupBox2.Controls.Add(this.m_btBotao);
			this.groupBox2.Location = new System.Drawing.Point(688, 16);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(144, 216);
			this.groupBox2.TabIndex = 14;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Button";
			// 
			// button1
			// 
			this.button1.GradiendColorEnd = System.Drawing.Color.Black;
			this.button1.GradiendColorStart = System.Drawing.Color.DarkGray;
			this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
			this.button1.Location = new System.Drawing.Point(8, 118);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(128, 88);
			this.button1.TabIndex = 1;
			this.button1.Type = mdlComponentesGraficos.Button.ButtonType.Cancel;
			// 
			// m_btBotao
			// 
			this.m_btBotao.GradiendColorEnd = System.Drawing.Color.Black;
			this.m_btBotao.GradiendColorStart = System.Drawing.Color.DarkGray;
			this.m_btBotao.Image = ((System.Drawing.Image)(resources.GetObject("m_btBotao.Image")));
			this.m_btBotao.Location = new System.Drawing.Point(8, 19);
			this.m_btBotao.Name = "m_btBotao";
			this.m_btBotao.Size = new System.Drawing.Size(128, 88);
			this.m_btBotao.TabIndex = 0;
			this.m_btBotao.Type = mdlComponentesGraficos.Button.ButtonType.Ok;
			// 
			// m_gbPainter
			// 
			this.m_gbPainter.Controls.Add(this.m_txtPainterRetorno);
			this.m_gbPainter.Controls.Add(this.m_txtPainter);
			this.m_gbPainter.Controls.Add(this.m_btFirstColorHits);
			this.m_gbPainter.Controls.Add(this.m_btFirstColor);
			this.m_gbPainter.Location = new System.Drawing.Point(662, 248);
			this.m_gbPainter.Name = "m_gbPainter";
			this.m_gbPainter.Size = new System.Drawing.Size(162, 248);
			this.m_gbPainter.TabIndex = 13;
			this.m_gbPainter.TabStop = false;
			this.m_gbPainter.Text = "Painter";
			// 
			// m_txtPainterRetorno
			// 
			this.m_txtPainterRetorno.Location = new System.Drawing.Point(9, 216);
			this.m_txtPainterRetorno.Name = "m_txtPainterRetorno";
			this.m_txtPainterRetorno.Size = new System.Drawing.Size(144, 20);
			this.m_txtPainterRetorno.TabIndex = 3;
			this.m_txtPainterRetorno.Text = "";
			// 
			// m_txtPainter
			// 
			this.m_txtPainter.Location = new System.Drawing.Point(8, 24);
			this.m_txtPainter.Name = "m_txtPainter";
			this.m_txtPainter.Size = new System.Drawing.Size(144, 20);
			this.m_txtPainter.TabIndex = 2;
			this.m_txtPainter.Text = "C:\\Fabio.jpg";
			// 
			// m_btFirstColorHits
			// 
			this.m_btFirstColorHits.Location = new System.Drawing.Point(7, 136);
			this.m_btFirstColorHits.Name = "m_btFirstColorHits";
			this.m_btFirstColorHits.Size = new System.Drawing.Size(104, 40);
			this.m_btFirstColorHits.TabIndex = 1;
			this.m_btFirstColorHits.Text = "FirstColorHits";
			this.m_btFirstColorHits.Click += new System.EventHandler(this.m_btFirstColorHits_Click);
			// 
			// m_btFirstColor
			// 
			this.m_btFirstColor.Location = new System.Drawing.Point(7, 88);
			this.m_btFirstColor.Name = "m_btFirstColor";
			this.m_btFirstColor.Size = new System.Drawing.Size(104, 40);
			this.m_btFirstColor.TabIndex = 0;
			this.m_btFirstColor.Text = "FirstColor";
			this.m_btFirstColor.Click += new System.EventHandler(this.m_btFirstColor_Click);
			// 
			// m_gbDateTimePicker
			// 
			this.m_gbDateTimePicker.Controls.Add(this.m_txtDataTimePickerFormat);
			this.m_gbDateTimePicker.Controls.Add(this.m_dtpDate);
			this.m_gbDateTimePicker.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbDateTimePicker.Location = new System.Drawing.Point(6, 544);
			this.m_gbDateTimePicker.Name = "m_gbDateTimePicker";
			this.m_gbDateTimePicker.Size = new System.Drawing.Size(466, 80);
			this.m_gbDateTimePicker.TabIndex = 12;
			this.m_gbDateTimePicker.TabStop = false;
			this.m_gbDateTimePicker.Text = "dateTimePicker";
			// 
			// m_txtDataTimePickerFormat
			// 
			this.m_txtDataTimePickerFormat.Location = new System.Drawing.Point(8, 18);
			this.m_txtDataTimePickerFormat.Name = "m_txtDataTimePickerFormat";
			this.m_txtDataTimePickerFormat.Size = new System.Drawing.Size(264, 20);
			this.m_txtDataTimePickerFormat.TabIndex = 12;
			this.m_txtDataTimePickerFormat.Text = "dd/MMM/yyyy";
			this.m_txtDataTimePickerFormat.TextChanged += new System.EventHandler(this.m_txtDataTimePickerFormat_TextChanged);
			// 
			// m_dtpDate
			// 
			this.m_dtpDate.CustomFormat = "MMM/yyyy/dd";
			this.m_dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.m_dtpDate.Location = new System.Drawing.Point(8, 48);
			this.m_dtpDate.Name = "m_dtpDate";
			this.m_dtpDate.Size = new System.Drawing.Size(264, 20);
			this.m_dtpDate.TabIndex = 11;
			// 
			// m_gbMessageBalloon
			// 
			this.m_gbMessageBalloon.Controls.Add(this.m_btMessageBalloon);
			this.m_gbMessageBalloon.Location = new System.Drawing.Point(488, 456);
			this.m_gbMessageBalloon.Name = "m_gbMessageBalloon";
			this.m_gbMessageBalloon.Size = new System.Drawing.Size(176, 152);
			this.m_gbMessageBalloon.TabIndex = 10;
			this.m_gbMessageBalloon.TabStop = false;
			this.m_gbMessageBalloon.Text = "MessageBalloon";
			// 
			// m_btMessageBalloon
			// 
			this.m_btMessageBalloon.Location = new System.Drawing.Point(24, 40);
			this.m_btMessageBalloon.Name = "m_btMessageBalloon";
			this.m_btMessageBalloon.Size = new System.Drawing.Size(128, 48);
			this.m_btMessageBalloon.TabIndex = 1;
			this.m_btMessageBalloon.Text = "MessageBalloon";
			this.m_btMessageBalloon.Click += new System.EventHandler(this.m_btMessageBalloon_Click);
			// 
			// m_gbTextBoxDateTime
			// 
			this.m_gbTextBoxDateTime.Controls.Add(this.m_dpTextBoxDateTime);
			this.m_gbTextBoxDateTime.Controls.Add(this.m_btSetData);
			this.m_gbTextBoxDateTime.Controls.Add(this.m_btGetData);
			this.m_gbTextBoxDateTime.Controls.Add(this.m_txtdtTextBoxDateTime);
			this.m_gbTextBoxDateTime.Location = new System.Drawing.Point(528, 16);
			this.m_gbTextBoxDateTime.Name = "m_gbTextBoxDateTime";
			this.m_gbTextBoxDateTime.Size = new System.Drawing.Size(152, 216);
			this.m_gbTextBoxDateTime.TabIndex = 9;
			this.m_gbTextBoxDateTime.TabStop = false;
			this.m_gbTextBoxDateTime.Text = "TextBoxDateTime";
			// 
			// m_dpTextBoxDateTime
			// 
			this.m_dpTextBoxDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.m_dpTextBoxDateTime.Location = new System.Drawing.Point(8, 104);
			this.m_dpTextBoxDateTime.Name = "m_dpTextBoxDateTime";
			this.m_dpTextBoxDateTime.Size = new System.Drawing.Size(136, 20);
			this.m_dpTextBoxDateTime.TabIndex = 3;
			// 
			// m_btSetData
			// 
			this.m_btSetData.Location = new System.Drawing.Point(80, 72);
			this.m_btSetData.Name = "m_btSetData";
			this.m_btSetData.Size = new System.Drawing.Size(25, 25);
			this.m_btSetData.TabIndex = 2;
			this.m_btSetData.Text = "^";
			this.m_btSetData.Click += new System.EventHandler(this.m_btSetData_Click);
			// 
			// m_btGetData
			// 
			this.m_btGetData.Location = new System.Drawing.Point(48, 72);
			this.m_btGetData.Name = "m_btGetData";
			this.m_btGetData.Size = new System.Drawing.Size(25, 25);
			this.m_btGetData.TabIndex = 1;
			this.m_btGetData.Text = "v";
			this.m_btGetData.Click += new System.EventHandler(this.m_btGetData_Click);
			// 
			// m_txtdtTextBoxDateTime
			// 
			this.m_txtdtTextBoxDateTime.Location = new System.Drawing.Point(8, 32);
			this.m_txtdtTextBoxDateTime.Name = "m_txtdtTextBoxDateTime";
			this.m_txtdtTextBoxDateTime.Size = new System.Drawing.Size(128, 20);
			this.m_txtdtTextBoxDateTime.TabIndex = 0;
			this.m_txtdtTextBoxDateTime.Text = "1/11/2002";
			this.m_txtdtTextBoxDateTime.Value = new System.DateTime(2002, 11, 23, 15, 42, 57, 807);
			// 
			// m_gbFormSkin
			// 
			this.m_gbFormSkin.Controls.Add(this.m_btFormSkin);
			this.m_gbFormSkin.Location = new System.Drawing.Point(480, 328);
			this.m_gbFormSkin.Name = "m_gbFormSkin";
			this.m_gbFormSkin.Size = new System.Drawing.Size(176, 112);
			this.m_gbFormSkin.TabIndex = 6;
			this.m_gbFormSkin.TabStop = false;
			this.m_gbFormSkin.Text = "FormSkin";
			// 
			// m_btFormSkin
			// 
			this.m_btFormSkin.Location = new System.Drawing.Point(24, 26);
			this.m_btFormSkin.Name = "m_btFormSkin";
			this.m_btFormSkin.Size = new System.Drawing.Size(128, 48);
			this.m_btFormSkin.TabIndex = 0;
			this.m_btFormSkin.Text = "FormSkin";
			// 
			// m_gbTaskBarNotifier
			// 
			this.m_gbTaskBarNotifier.Controls.Add(this.m_btTaskBarNotifier);
			this.m_gbTaskBarNotifier.Location = new System.Drawing.Point(480, 248);
			this.m_gbTaskBarNotifier.Name = "m_gbTaskBarNotifier";
			this.m_gbTaskBarNotifier.Size = new System.Drawing.Size(176, 80);
			this.m_gbTaskBarNotifier.TabIndex = 5;
			this.m_gbTaskBarNotifier.TabStop = false;
			this.m_gbTaskBarNotifier.Text = "TaskBarNotifier";
			// 
			// m_btTaskBarNotifier
			// 
			this.m_btTaskBarNotifier.Location = new System.Drawing.Point(24, 23);
			this.m_btTaskBarNotifier.Name = "m_btTaskBarNotifier";
			this.m_btTaskBarNotifier.Size = new System.Drawing.Size(128, 48);
			this.m_btTaskBarNotifier.TabIndex = 0;
			this.m_btTaskBarNotifier.Text = "TaskBarNotifier";
			this.m_btTaskBarNotifier.Click += new System.EventHandler(this.m_btTaskBarNotifier_Click);
			// 
			// m_gbPictureBox
			// 
			this.m_gbPictureBox.Controls.Add(this.m_btAnimatedPictureBoxStart);
			this.m_gbPictureBox.Controls.Add(this.m_apicSample);
			this.m_gbPictureBox.Controls.Add(this.m_btPictureBoxTeste);
			this.m_gbPictureBox.Controls.Add(this.m_btRefresh);
			this.m_gbPictureBox.Location = new System.Drawing.Point(16, 240);
			this.m_gbPictureBox.Name = "m_gbPictureBox";
			this.m_gbPictureBox.Size = new System.Drawing.Size(456, 288);
			this.m_gbPictureBox.TabIndex = 3;
			this.m_gbPictureBox.TabStop = false;
			this.m_gbPictureBox.Text = "PictureBox";
			// 
			// m_btAnimatedPictureBoxStart
			// 
			this.m_btAnimatedPictureBoxStart.Location = new System.Drawing.Point(376, 132);
			this.m_btAnimatedPictureBoxStart.Name = "m_btAnimatedPictureBoxStart";
			this.m_btAnimatedPictureBoxStart.Size = new System.Drawing.Size(72, 24);
			this.m_btAnimatedPictureBoxStart.TabIndex = 7;
			this.m_btAnimatedPictureBoxStart.Text = "Start";
			this.m_btAnimatedPictureBoxStart.Click += new System.EventHandler(this.m_btAnimatedPictureBoxStart_Click);
			// 
			// m_apicSample
			// 
			this.m_apicSample.AnimationLoops = 1;
			this.m_apicSample.Image = ((System.Drawing.Image)(resources.GetObject("m_apicSample.Image")));
			this.m_apicSample.Location = new System.Drawing.Point(24, 24);
			this.m_apicSample.Name = "m_apicSample";
			this.m_apicSample.Size = new System.Drawing.Size(320, 240);
			this.m_apicSample.TabIndex = 6;
			this.m_apicSample.TabStop = false;
			// 
			// m_btPictureBoxTeste
			// 
			this.m_btPictureBoxTeste.Location = new System.Drawing.Point(376, 56);
			this.m_btPictureBoxTeste.Name = "m_btPictureBoxTeste";
			this.m_btPictureBoxTeste.Size = new System.Drawing.Size(72, 24);
			this.m_btPictureBoxTeste.TabIndex = 5;
			this.m_btPictureBoxTeste.Text = "0 a 100";
			this.m_btPictureBoxTeste.Click += new System.EventHandler(this.m_btPictureBoxTeste_Click);
			// 
			// m_btRefresh
			// 
			this.m_btRefresh.Location = new System.Drawing.Point(376, 24);
			this.m_btRefresh.Name = "m_btRefresh";
			this.m_btRefresh.Size = new System.Drawing.Size(72, 24);
			this.m_btRefresh.TabIndex = 3;
			this.m_btRefresh.Text = "Refresh";
			this.m_btRefresh.Click += new System.EventHandler(this.m_btRefresh_Click);
			// 
			// m_gbComboBox
			// 
			this.m_gbComboBox.Controls.Add(this.m_ckAutoCompleteCaseSensitive);
			this.m_gbComboBox.Controls.Add(this.m_ckCBAutoComplete);
			this.m_gbComboBox.Controls.Add(this.m_lbCBOutput);
			this.m_gbComboBox.Controls.Add(this.m_txtCBOutput);
			this.m_gbComboBox.Controls.Add(this.m_btCBClear);
			this.m_gbComboBox.Controls.Add(this.m_btCBFill);
			this.m_gbComboBox.Location = new System.Drawing.Point(9, 9);
			this.m_gbComboBox.Name = "m_gbComboBox";
			this.m_gbComboBox.Size = new System.Drawing.Size(263, 215);
			this.m_gbComboBox.TabIndex = 1;
			this.m_gbComboBox.TabStop = false;
			this.m_gbComboBox.Text = "Combo Box";
			// 
			// m_ckAutoCompleteCaseSensitive
			// 
			this.m_ckAutoCompleteCaseSensitive.Checked = true;
			this.m_ckAutoCompleteCaseSensitive.CheckState = System.Windows.Forms.CheckState.Checked;
			this.m_ckAutoCompleteCaseSensitive.Location = new System.Drawing.Point(8, 38);
			this.m_ckAutoCompleteCaseSensitive.Name = "m_ckAutoCompleteCaseSensitive";
			this.m_ckAutoCompleteCaseSensitive.Size = new System.Drawing.Size(240, 16);
			this.m_ckAutoCompleteCaseSensitive.TabIndex = 7;
			this.m_ckAutoCompleteCaseSensitive.Text = "Case Sensitive";
			this.m_ckAutoCompleteCaseSensitive.CheckedChanged += new System.EventHandler(this.m_ckAutoCompleteCaseSensitive_CheckedChanged);
			// 
			// m_ckCBAutoComplete
			// 
			this.m_ckCBAutoComplete.Checked = true;
			this.m_ckCBAutoComplete.CheckState = System.Windows.Forms.CheckState.Checked;
			this.m_ckCBAutoComplete.Location = new System.Drawing.Point(8, 21);
			this.m_ckCBAutoComplete.Name = "m_ckCBAutoComplete";
			this.m_ckCBAutoComplete.Size = new System.Drawing.Size(240, 16);
			this.m_ckCBAutoComplete.TabIndex = 5;
			this.m_ckCBAutoComplete.Text = "Auto Complete";
			this.m_ckCBAutoComplete.CheckedChanged += new System.EventHandler(this.m_ckCBAutoComplete_CheckedChanged);
			// 
			// m_lbCBOutput
			// 
			this.m_lbCBOutput.Location = new System.Drawing.Point(8, 167);
			this.m_lbCBOutput.Name = "m_lbCBOutput";
			this.m_lbCBOutput.Size = new System.Drawing.Size(48, 16);
			this.m_lbCBOutput.TabIndex = 4;
			this.m_lbCBOutput.Text = "Output";
			// 
			// m_txtCBOutput
			// 
			this.m_txtCBOutput.Location = new System.Drawing.Point(8, 184);
			this.m_txtCBOutput.Name = "m_txtCBOutput";
			this.m_txtCBOutput.Size = new System.Drawing.Size(248, 20);
			this.m_txtCBOutput.TabIndex = 58;
			this.m_txtCBOutput.Text = "";
			// 
			// m_btCBClear
			// 
			this.m_btCBClear.Location = new System.Drawing.Point(88, 61);
			this.m_btCBClear.Name = "m_btCBClear";
			this.m_btCBClear.Size = new System.Drawing.Size(72, 24);
			this.m_btCBClear.TabIndex = 3;
			this.m_btCBClear.Text = "Clear";
			this.m_btCBClear.Click += new System.EventHandler(this.m_btCBClear_Click);
			// 
			// m_btCBFill
			// 
			this.m_btCBFill.Location = new System.Drawing.Point(8, 61);
			this.m_btCBFill.Name = "m_btCBFill";
			this.m_btCBFill.Size = new System.Drawing.Size(72, 24);
			this.m_btCBFill.TabIndex = 1;
			this.m_btCBFill.Text = "Fill";
			this.m_btCBFill.Click += new System.EventHandler(this.m_btCBFill_Click);
			// 
			// m_picPictureBox
			// 
			this.m_picPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("m_picPictureBox.Image")));
			this.m_picPictureBox.Location = new System.Drawing.Point(13, 18);
			this.m_picPictureBox.Name = "m_picPictureBox";
			this.m_picPictureBox.Percentage = 0;
			this.m_picPictureBox.Size = new System.Drawing.Size(267, 150);
			this.m_picPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_picPictureBox.TabIndex = 4;
			this.m_picPictureBox.TabStop = false;
			// 
			// m_cbComboBox
			// 
			this.m_cbComboBox.Location = new System.Drawing.Point(8, 96);
			this.m_cbComboBox.Name = "m_cbComboBox";
			this.m_cbComboBox.Size = new System.Drawing.Size(232, 21);
			this.m_cbComboBox.TabIndex = 59;
			// 
			// m_tcTabControl
			// 
			this.m_tcTabControl.Controls.Add(this.tabPage1);
			this.m_tcTabControl.Location = new System.Drawing.Point(16, 24);
			this.m_tcTabControl.Name = "m_tcTabControl";
			this.m_tcTabControl.SelectedIndex = 0;
			this.m_tcTabControl.ShowTabNames = true;
			this.m_tcTabControl.Size = new System.Drawing.Size(344, 128);
			this.m_tcTabControl.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.groupBox1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(336, 102);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "tabPage1";
			// 
			// groupBox1
			// 
			this.groupBox1.Location = new System.Drawing.Point(1, -3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(87, 75);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// m_btButton
			// 
			this.m_btButton.ForeColor = System.Drawing.Color.Black;
			this.m_btButton.GradiendColorEnd = System.Drawing.Color.Black;
			this.m_btButton.GradiendColorStart = System.Drawing.Color.White;
			this.m_btButton.Location = new System.Drawing.Point(24, 40);
			this.m_btButton.Name = "m_btButton";
			this.m_btButton.Size = new System.Drawing.Size(112, 48);
			this.m_btButton.TabIndex = 0;
			this.m_btButton.Text = "Ok";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(856, 646);
			this.Controls.Add(this.m_gbGeral);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Componentes Gráficos";
			this.m_dgTextBox.ResumeLayout(false);
			this.m_gbGeral.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.m_gbPainter.ResumeLayout(false);
			this.m_gbDateTimePicker.ResumeLayout(false);
			this.m_gbMessageBalloon.ResumeLayout(false);
			this.m_gbTextBoxDateTime.ResumeLayout(false);
			this.m_gbFormSkin.ResumeLayout(false);
			this.m_gbTaskBarNotifier.ResumeLayout(false);
			this.m_gbPictureBox.ResumeLayout(false);
			this.m_gbComboBox.ResumeLayout(false);
			this.m_tcTabControl.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Combo Box
			private void m_ckCBAutoComplete_CheckedChanged(object sender, System.EventArgs e)
			{
                m_cbComboBox.AutoComplete = m_ckCBAutoComplete.Checked;			
			}

			private void m_ckAutoCompleteCaseSensitive_CheckedChanged(object sender, System.EventArgs e)
			{
				m_cbComboBox.AutoCompleteCaseSensitive = m_ckAutoCompleteCaseSensitive.Checked;			
			}

			private void m_btCBFill_Click(object sender, System.EventArgs e)
			{
				m_cbComboBox.AddItem("Thiago",1);
				m_cbComboBox.AddItem("Silvio",2);
				m_cbComboBox.AddItem("Paulo",3);
			}

			private void m_btCBClear_Click(object sender, System.EventArgs e)
			{
				m_cbComboBox.Clear();			
			}
		#endregion
		#region PictureBox
			private void m_btRefresh_Click(object sender, System.EventArgs e)
			{
				m_picPictureBox.ApplyEffects();
			}

			private void m_btPictureBoxTeste_Click(object sender, System.EventArgs e)
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				for(int nCont = 1; nCont <= 100;nCont++)
				{
					nCont = nCont + 4;
					m_picPictureBox.Percentage = nCont;
					m_picPictureBox.ApplyEffects();
					m_picPictureBox.Refresh();
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}
		#endregion
		#region TaskBarNotifier
		private void m_btTaskBarNotifier_Click(object sender, System.EventArgs e)
		{
			mdlComponentesGraficos.TaskbarNotifier formTask = new mdlComponentesGraficos.TaskbarNotifier();
			formTask.SetBackgroundBitmap(System.Drawing.Image.FromFile("F:\\Projetos\\Siscobras\\Resources\\Imagens\\discrepancia.jpg"),System.Drawing.Color.White);
			formTask.TitleRectangle = new System.Drawing.Rectangle(50,20,200,200);
			formTask.ContentRectangle = new System.Drawing.Rectangle(50,50,200,200);
			formTask.Content2Rectangle = new System.Drawing.Rectangle(50,70,200,200);
			formTask.Font = new System.Drawing.Font("Arial",12);
			formTask.Show("Siscobras.NET","Deseja mesmo atualizar o seu siscobras ?","Testando um novo notify",500,2000,500);
		}
		#endregion
		#region Mask
		private void m_btAtivarMascara_Click(object sender, System.EventArgs e)
		{
			m_txtTextBox.MaskText = m_txtMask.Text;
			m_txtTextBox.MaskAutomaticSpecialCharacters = m_ckAutoCompleteSpecialCharacters.Checked;
			m_txtTextBox.Mask = true;
		}

		private void m_btTextBoxCheck_Click(object sender, System.EventArgs e)
		{
			if (!m_ckTextBoxShadow.Checked)
				m_txtTextBoxRetorno.Text = m_txtTextBox.bTextValidWithTheMask().ToString();
			else
				m_txtTextBoxRetorno.Text = m_txtTextBox.Text;
		}
		#endregion
		#region Shadow 
		private void m_ckTextBoxShadow_CheckedChanged(object sender, System.EventArgs e)
		{
            m_txtTextBox.Shadow = m_ckTextBoxShadow.Checked;		
		}
		#endregion
		#region TextBoxDataTime
			private void m_btGetData_Click(object sender, System.EventArgs e)
			{
				m_dpTextBoxDateTime.Value = m_txtdtTextBoxDateTime.Value;
			}

			private void m_btSetData_Click(object sender, System.EventArgs e)
			{
				m_txtdtTextBoxDateTime.Value = m_dpTextBoxDateTime.Value;
			}
		#endregion
		#region MessageBalloon
			private void m_btMessageBalloon_Click(object sender, System.EventArgs e)
			{
				mdlComponentesGraficos.MessageBalloon bal = new mdlComponentesGraficos.MessageBalloon();
				bal.Caption = "Siscobras";
				bal.Content = "aquiiii";
				bal.Icon = System.Drawing.SystemIcons.Information;
				bal.ShowBalloon((System.Windows.Forms.Control)m_btMessageBalloon);
			}
		#endregion
		#region DataTimePicker
			private void m_txtDataTimePickerFormat_TextChanged(object sender, System.EventArgs e)
			{
				m_dtpDate.CustomFormat = m_txtDataTimePickerFormat.Text;
			}
		#endregion

		#region Painter
			private void m_btFirstColor_Click(object sender, System.EventArgs e)
			{
				System.Drawing.Color clrCurrent = mdlComponentesGraficos.Painter.GetFirstColor(System.Drawing.Image.FromFile(m_txtPainter.Text));
				m_txtPainterRetorno.Text = clrCurrent.ToString();
			}

			private void m_btFirstColorHits_Click(object sender, System.EventArgs e)
			{
				System.Drawing.Color clrCurrent = mdlComponentesGraficos.Painter.GetFirstColorHits(System.Drawing.Image.FromFile(m_txtPainter.Text));
				m_txtPainterRetorno.Text = clrCurrent.ToString();
			}
		#endregion

		#region AnimatedPictureBox
			private void m_btAnimatedPictureBoxStart_Click(object sender, System.EventArgs e)
			{
				if (m_apicSample.SetAnimationLoopsFromImage())
				{
					m_apicSample.AnimationLoops = 1;
					m_apicSample.Start();
				}
			}
		#endregion
	}
}
