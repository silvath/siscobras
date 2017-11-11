using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Report;
using PdfDocument;
using PdfTypes;

namespace MakeDoc
{
	public class Form1 : System.Windows.Forms.Form
	{
		#region
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private Report.SDPage CoverPage;
		private Report.SDLayoutPanel sdLayoutPanel1;
		private Report.SDLabel sdLabel1;
		private Report.SDText sdText2;
		private Report.SDReport sdReport1;
		private Report.SDPage ContentsPage;
		private Report.SDGridPanel sdGridPanel1;
		private Report.SDRect sdRect4;
		private Report.SDRect sdRect3;
		private Report.SDRect sdRect2;
		private Report.SDRect sdRect1;
		private Report.SDLabel sdLabel3;
		private Report.SDPage sdPage1;
		private Report.SDLayoutPanel sdLayoutPanel3;
		private Report.SDText sdText7;
		private Report.SDText sdText8;
		private Report.SDText sdText5;
		private Report.SDText sdText6;
		private Report.SDText sdText4;
		private Report.SDText sdText9;
		private Report.SDText sdText10;
		private Report.SDRect sdRect5;
		private Report.SDText sdText11;
		private Report.SDLabel sdLabel4;
		private Report.SDRect sdRect6;
		private Report.SDRect sdRect7;
		private Report.SDRect sdRect8;
		private Report.SDRect sdRect9;
		private System.Windows.Forms.TabPage tabPage4;
		private Report.SDPage sdPage2;
		private Report.SDLayoutPanel sdLayoutPanel4;
		private Report.SDText sdText29;
		private Report.SDText sdText30;
		private Report.SDText sdText26;
		private Report.SDText sdText27;
		private Report.SDText sdText23;
		private Report.SDText sdText24;
		private Report.SDText sdText20;
		private Report.SDText sdText21;
		private Report.SDText sdText17;
		private Report.SDText sdText18;
		private Report.SDText sdText14;
		private Report.SDText sdText15;
		private Report.SDText sdText12;
		private Report.SDText sdText13;
		private Report.SDText sdText33;
		private Report.SDText sdText34;
		private Report.SDText sdText36;
		private Report.SDText sdText37;
		private Report.SDText sdText38;
		private Report.SDText sdText39;
		private Report.SDText sdText40;
		private Report.SDText sdText41;
		private Report.SDRect sdRect10;
		private Report.SDText sdText42;
		private Report.SDLabel sdLabel5;
		private Report.SDRect sdRect11;
		private Report.SDRect sdRect12;
		private Report.SDRect sdRect13;
		private Report.SDRect sdRect14;
		private System.Windows.Forms.TabPage tabPage5;
		private Report.SDPage sdPage3;
		private Report.SDLayoutPanel sdLayoutPanel5;
		private Report.SDText sdText43;
		private Report.SDText sdText44;
		private Report.SDText sdText45;
		private Report.SDText sdText46;
		private Report.SDText sdText47;
		private Report.SDText sdText49;
		private Report.SDText sdText50;
		private Report.SDText sdText52;
		private Report.SDText sdText53;
		private Report.SDText sdText55;
		private Report.SDText sdText56;
		private Report.SDText sdText58;
		private Report.SDText sdText59;
		private Report.SDText sdText60;
		private Report.SDText sdText61;
		private Report.SDText sdText62;
		private Report.SDText sdText64;
		private Report.SDText sdText65;
		private Report.SDText sdText66;
		private Report.SDText sdText67;
		private Report.SDText sdText68;
		private Report.SDLabel sdLabel6;
		private Report.SDRect sdRect15;
		private Report.SDRect sdRect16;
		private Report.SDRect sdRect17;
		private Report.SDRect sdRect18;
		private System.Windows.Forms.TabPage tabPage6;
		private Report.SDPage sdPage4;
		private Report.SDLayoutPanel sdLayoutPanel6;
		private Report.SDText sdText70;
		private Report.SDText sdText71;
		private Report.SDText sdText73;
		private Report.SDText sdText74;
		private Report.SDText sdText76;
		private Report.SDText sdText77;
		private Report.SDText sdText79;
		private Report.SDText sdText80;
		private Report.SDText sdText82;
		private Report.SDText sdText83;
		private Report.SDText sdText84;
		private Report.SDLabel sdLabel7;
		private Report.SDRect sdRect19;
		private Report.SDRect sdRect20;
		private Report.SDRect sdRect21;
		private Report.SDRect sdRect22;
		private System.Windows.Forms.TabPage tabPage7;
		private Report.SDPage sdPage5;
		private Report.SDLayoutPanel sdLayoutPanel7;
		private Report.SDText sdText16;
		private Report.SDText sdText19;
		private Report.SDText sdText22;
		private Report.SDText sdText25;
		private Report.SDText sdText28;
		private Report.SDText sdText31;
		private Report.SDText sdText32;
		private Report.SDText sdText35;
		private Report.SDText sdText48;
		private Report.SDText sdText51;
		private Report.SDText sdText54;
		private Report.SDText sdText57;
		private Report.SDText sdText63;
		private Report.SDText sdText69;
		private Report.SDText sdText72;
		private Report.SDText sdText75;
		private Report.SDText sdText78;
		private Report.SDText sdText81;
		private Report.SDText sdText85;
		private Report.SDText sdText86;
		private Report.SDText sdText87;
		private Report.SDText sdText88;
		private Report.SDLabel sdLabel8;
		private Report.SDRect sdRect23;
		private Report.SDRect sdRect24;
		private Report.SDRect sdRect25;
		private Report.SDRect sdRect26;
		private System.Windows.Forms.TabPage tabPage8;
		private Report.SDPage sdPage6;
		private Report.SDLayoutPanel sdLayoutPanel8;
		private Report.SDText sdText89;
		private Report.SDText sdText90;
		private Report.SDText sdText91;
		private Report.SDText sdText92;
		private Report.SDText sdText93;
		private Report.SDText sdText94;
		private Report.SDText sdText95;
		private Report.SDText sdText96;
		private Report.SDText sdText97;
		private Report.SDText sdText98;
		private Report.SDText sdText99;
		private Report.SDText sdText100;
		private Report.SDLabel sdLabel9;
		private Report.SDRect sdRect27;
		private Report.SDRect sdRect28;
		private Report.SDRect sdRect29;
		private Report.SDRect sdRect30;
		private System.Windows.Forms.TabPage tabPage9;
		private Report.SDPage sdPage7;
		private Report.SDLayoutPanel sdLayoutPanel9;
		private Report.SDText sdText101;
		private Report.SDText sdText102;
		private Report.SDText sdText103;
		private Report.SDText sdText104;
		private Report.SDText sdText105;
		private Report.SDText sdText106;
		private Report.SDText sdText107;
		private Report.SDText sdText108;
		private Report.SDText sdText109;
		private Report.SDText sdText110;
		private Report.SDText sdText111;
		private Report.SDText sdText112;
		private Report.SDText sdText113;
		private Report.SDText sdText114;
		private Report.SDText sdText115;
		private Report.SDText sdText116;
		private Report.SDText sdText117;
		private Report.SDText sdText118;
		private Report.SDText sdText119;
		private Report.SDText sdText120;
		private Report.SDText sdText121;
		private Report.SDText sdText122;
		private Report.SDLabel sdLabel10;
		private Report.SDRect sdRect31;
		private Report.SDRect sdRect32;
		private Report.SDRect sdRect33;
		private Report.SDRect sdRect34;
		private System.Windows.Forms.TabPage tabPage10;
		private Report.SDPage sdPage8;
		private Report.SDLayoutPanel sdLayoutPanel10;
		private Report.SDText sdText123;
		private Report.SDText sdText124;
		private Report.SDText sdText125;
		private Report.SDText sdText126;
		private Report.SDLabel sdLabel11;
		private Report.SDText sdText127;
		private Report.SDLabel sdLabel12;
		private Report.SDText sdText128;
		private Report.SDLabel sdLabel13;
		private Report.SDText sdText129;
		private Report.SDLabel sdLabel14;
		private Report.SDText sdText130;
		private Report.SDRect sdRect35;
		private Report.SDText sdText131;
		private Report.SDText sdText134;
		private Report.SDText sdText135;
		private Report.SDText sdText136;
		private Report.SDText sdText137;
		private Report.SDText sdText138;
		private Report.SDText sdText139;
		private Report.SDText sdText140;
		private Report.SDText sdText141;
		private Report.SDText sdText142;
		private Report.SDText sdText143;
		private Report.SDText sdText144;
		private Report.SDLabel sdLabel15;
		private Report.SDRect sdRect36;
		private Report.SDRect sdRect37;
		private Report.SDRect sdRect38;
		private Report.SDRect sdRect39;
		private System.Windows.Forms.TabPage tabPage11;
		private Report.SDPage sdPage9;
		private Report.SDLayoutPanel sdLayoutPanel11;
		private Report.SDText sdText145;
		private Report.SDText sdText146;
		private Report.SDText sdText147;
		private Report.SDText sdText148;
		private Report.SDText sdText149;
		private Report.SDText sdText150;
		private Report.SDText sdText151;
		private Report.SDText sdText152;
		private Report.SDText sdText153;
		private Report.SDText sdText154;
		private Report.SDRect sdRect40;
		private Report.SDText sdText155;
		private Report.SDText sdText156;
		private Report.SDText sdText157;
		private Report.SDLabel sdLabel16;
		private Report.SDRect sdRect41;
		private Report.SDRect sdRect42;
		private Report.SDRect sdRect43;
		private Report.SDRect sdRect44;
		private System.Windows.Forms.TabPage tabPage12;
		private Report.SDPage sdPage10;
		private Report.SDLayoutPanel sdLayoutPanel12;
		private Report.SDText sdText132;
		private Report.SDText sdText133;
		private Report.SDText sdText158;
		private Report.SDText sdText159;
		private Report.SDText sdText160;
		private Report.SDText sdText161;
		private Report.SDText sdText162;
		private Report.SDText sdText163;
		private Report.SDText sdText164;
		private Report.SDText sdText165;
		private Report.SDText sdText166;
		private Report.SDText sdText167;
		private Report.SDText sdText168;
		private Report.SDText sdText169;
		private Report.SDText sdText170;
		private Report.SDText sdText171;
		private Report.SDText sdText172;
		private Report.SDText sdText173;
		private Report.SDText sdText174;
		private Report.SDText sdText175;
		private Report.SDText sdText176;
		private Report.SDText sdText177;
		private Report.SDText sdText178;
		private Report.SDText sdText179;
		private Report.SDText sdText180;
		private Report.SDLabel sdLabel17;
		private Report.SDRect sdRect45;
		private Report.SDRect sdRect46;
		private Report.SDRect sdRect47;
		private Report.SDRect sdRect48;
		private System.Windows.Forms.TabPage tabPage13;
		private Report.SDPage sdPage11;
		private Report.SDLayoutPanel sdLayoutPanel13;
		private Report.SDText sdText181;
		private Report.SDText sdText182;
		private Report.SDText sdText183;
		private Report.SDText sdText184;
		private Report.SDText sdText185;
		private Report.SDText sdText186;
		private Report.SDText sdText187;
		private Report.SDText sdText188;
		private Report.SDText sdText189;
		private Report.SDText sdText190;
		private Report.SDText sdText191;
		private Report.SDText sdText192;
		private Report.SDText sdText193;
		private Report.SDText sdText194;
		private Report.SDText sdText195;
		private Report.SDLabel sdLabel18;
		private Report.SDRect sdRect49;
		private Report.SDRect sdRect50;
		private Report.SDRect sdRect51;
		private Report.SDRect sdRect52;
		private System.Windows.Forms.TabPage tabPage14;
		private Report.SDPage sdPage12;
		private Report.SDLayoutPanel sdLayoutPanel14;
		private Report.SDText sdText196;
		private Report.SDText sdText197;
		private Report.SDText sdText198;
		private Report.SDText sdText199;
		private Report.SDText sdText200;
		private Report.SDText sdText201;
		private Report.SDText sdText202;
		private Report.SDText sdText203;
		private Report.SDText sdText204;
		private Report.SDText sdText205;
		private Report.SDText sdText206;
		private Report.SDText sdText207;
		private Report.SDText sdText208;
		private Report.SDText sdText209;
		private Report.SDText sdText210;
		private Report.SDLabel sdLabel19;
		private Report.SDRect sdRect53;
		private Report.SDRect sdRect54;
		private Report.SDRect sdRect55;
		private Report.SDRect sdRect56;
		private System.Windows.Forms.TabPage tabPage15;
		private Report.SDPage sdPage13;
		private Report.SDLayoutPanel sdLayoutPanel15;
		private Report.SDRect sdRect57;
		private Report.SDRect sdRect58;
		private Report.SDRect sdRect59;
		private Report.SDRect sdRect60;
		private Report.SDText sdText211;
		private Report.SDText sdText212;
		private Report.SDText sdText213;
		private Report.SDText sdText214;
		private Report.SDRect sdRect61;
		private Report.SDText sdText215;
		private Report.SDRect sdRect62;
		private Report.SDText sdText216;
		private Report.SDText sdText217;
		private Report.SDText sdText218;
		private Report.SDText sdText219;
		private Report.SDText sdText220;
		private Report.SDText sdText221;
		private Report.SDText sdText222;
		private Report.SDText sdText223;
		private Report.SDText sdText224;
		private Report.SDText sdText225;
		private Report.SDText sdText226;
		private Report.SDText sdText227;
		private Report.SDText sdText228;
		private Report.SDLabel sdLabel20;
		private Report.SDRect sdRect63;
		private Report.SDRect sdRect64;
		private Report.SDRect sdRect65;
		private Report.SDRect sdRect66;
		private System.Windows.Forms.TabPage tabPage16;
		private Report.SDPage sdPage14;
		private Report.SDLayoutPanel sdLayoutPanel16;
		private Report.SDText sdText229;
		private Report.SDEllipse sdEllipse6;
		private Report.SDEllipse sdEllipse5;
		private Report.SDEllipse sdEllipse4;
		private Report.SDEllipse sdEllipse3;
		private Report.SDEllipse sdEllipse2;
		private Report.SDEllipse sdEllipse1;
		private Report.SDRect sdRect67;
		private Report.SDText sdText230;
		private Report.SDText sdText231;
		private Report.SDText sdText232;
		private Report.SDText sdText233;
		private Report.SDText sdText234;
		private Report.SDText sdText235;
		private Report.SDText sdText236;
		private Report.SDText sdText237;
		private Report.SDText sdText238;
		private Report.SDText sdText239;
		private Report.SDText sdText240;
		private Report.SDLabel sdLabel21;
		private Report.SDRect sdRect68;
		private Report.SDRect sdRect69;
		private Report.SDRect sdRect70;
		private Report.SDRect sdRect71;
		private System.Windows.Forms.TabPage tabPage17;
		private Report.SDPage sdPage15;
		private Report.SDLayoutPanel sdLayoutPanel17;
		private Report.SDAnnotation sdAnnotation2;
		private Report.SDText sdText241;
		private Report.SDText sdText242;
		private Report.SDAnnotation sdAnnotation1;
		private Report.SDText sdText243;
		private Report.SDText sdText244;
		private Report.SDText sdText245;
		private Report.SDText sdText246;
		private Report.SDText sdText247;
		private Report.SDText sdText248;
		private Report.SDText sdText249;
		private Report.SDText sdText250;
		private Report.SDLabel sdLabel22;
		private Report.SDRect sdRect72;
		private Report.SDRect sdRect73;
		private Report.SDRect sdRect74;
		private Report.SDRect sdRect75;
		private System.Windows.Forms.TabPage tabPage18;
		private Report.SDPage sdPage16;
		private Report.SDLayoutPanel sdLayoutPanel18;
		private Report.SDText sdText251;
		private Report.SDText sdText252;
		private Report.SDText sdText253;
		private Report.SDText sdText254;
		private Report.SDText sdText255;
		private Report.SDText sdText256;
		private Report.SDText sdText257;
		private Report.SDText sdText258;
		private Report.SDText sdText259;
		private Report.SDText sdText260;
		private Report.SDText sdText261;
		private Report.SDText sdText262;
		private Report.SDText sdText263;
		private Report.SDText sdText264;
		private Report.SDText sdText265;
		private Report.SDText sdText266;
		private Report.SDText sdText267;
		private Report.SDText sdText268;
		private Report.SDText sdText269;
		private Report.SDText sdText270;
		private Report.SDText sdText271;
		private Report.SDText sdText272;
		private Report.SDLabel sdLabel23;
		private Report.SDRect sdRect76;
		private Report.SDRect sdRect77;
		private Report.SDRect sdRect78;
		private Report.SDRect sdRect79;
		private System.Windows.Forms.TabPage tabPage19;
		private Report.SDPage sdPage17;
		private Report.SDLayoutPanel sdLayoutPanel19;
		private Report.SDText sdText273;
		private Report.SDText sdText274;
		private Report.SDText sdText275;
		private Report.SDText sdText276;
		private Report.SDText sdText277;
		private Report.SDText sdText278;
		private Report.SDText sdText279;
		private Report.SDText sdText280;
		private Report.SDText sdText281;
		private Report.SDText sdText282;
		private Report.SDText sdText283;
		private Report.SDText sdText284;
		private Report.SDText sdText285;
		private Report.SDLabel sdLabel24;
		private Report.SDRect sdRect80;
		private Report.SDRect sdRect81;
		private Report.SDRect sdRect82;
		private Report.SDRect sdRect83;
		private System.Windows.Forms.TabPage tabPage20;
		private Report.SDPage sdPage18;
		private Report.SDLayoutPanel sdLayoutPanel20;
		private Report.SDText sdText286;
		private Report.SDText sdText287;
		private Report.SDLabel sdLabel25;
		private Report.SDRect sdRect84;
		private Report.SDRect sdRect85;
		private Report.SDRect sdRect86;
		private Report.SDRect sdRect87;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		ArrayList FContentsList;
		private Report.SDLayoutPanel sdlayotupanel;
		private Report.SDLabel lblSectionName;
		int FPos;
		private Report.SDText ContentsText;
		private Report.SDText sdText1;
		SDOutlineEntry[] FCurrentOutline=new SDOutlineEntry[6];

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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.CoverPage = new Report.SDPage();
			this.sdLayoutPanel1 = new Report.SDLayoutPanel();
			this.sdText1 = new Report.SDText();
			this.sdLabel1 = new Report.SDLabel();
			this.sdText2 = new Report.SDText();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.ContentsPage = new Report.SDPage();
			this.sdlayotupanel = new Report.SDLayoutPanel();
			this.sdGridPanel1 = new Report.SDGridPanel();
			this.lblSectionName = new Report.SDLabel();
			this.ContentsText = new Report.SDText();
			this.sdRect4 = new Report.SDRect();
			this.sdRect3 = new Report.SDRect();
			this.sdRect2 = new Report.SDRect();
			this.sdRect1 = new Report.SDRect();
			this.sdLabel3 = new Report.SDLabel();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.sdPage1 = new Report.SDPage();
			this.sdLayoutPanel3 = new Report.SDLayoutPanel();
			this.sdText7 = new Report.SDText();
			this.sdText8 = new Report.SDText();
			this.sdText5 = new Report.SDText();
			this.sdText6 = new Report.SDText();
			this.sdText4 = new Report.SDText();
			this.sdText9 = new Report.SDText();
			this.sdText10 = new Report.SDText();
			this.sdRect5 = new Report.SDRect();
			this.sdText11 = new Report.SDText();
			this.sdLabel4 = new Report.SDLabel();
			this.sdRect6 = new Report.SDRect();
			this.sdRect7 = new Report.SDRect();
			this.sdRect8 = new Report.SDRect();
			this.sdRect9 = new Report.SDRect();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.sdPage2 = new Report.SDPage();
			this.sdLayoutPanel4 = new Report.SDLayoutPanel();
			this.sdText29 = new Report.SDText();
			this.sdText30 = new Report.SDText();
			this.sdText26 = new Report.SDText();
			this.sdText27 = new Report.SDText();
			this.sdText23 = new Report.SDText();
			this.sdText24 = new Report.SDText();
			this.sdText20 = new Report.SDText();
			this.sdText21 = new Report.SDText();
			this.sdText17 = new Report.SDText();
			this.sdText18 = new Report.SDText();
			this.sdText14 = new Report.SDText();
			this.sdText15 = new Report.SDText();
			this.sdText12 = new Report.SDText();
			this.sdText13 = new Report.SDText();
			this.sdText33 = new Report.SDText();
			this.sdText34 = new Report.SDText();
			this.sdText36 = new Report.SDText();
			this.sdText37 = new Report.SDText();
			this.sdText38 = new Report.SDText();
			this.sdText39 = new Report.SDText();
			this.sdText40 = new Report.SDText();
			this.sdText41 = new Report.SDText();
			this.sdRect10 = new Report.SDRect();
			this.sdText42 = new Report.SDText();
			this.sdLabel5 = new Report.SDLabel();
			this.sdRect11 = new Report.SDRect();
			this.sdRect12 = new Report.SDRect();
			this.sdRect13 = new Report.SDRect();
			this.sdRect14 = new Report.SDRect();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.sdPage3 = new Report.SDPage();
			this.sdLayoutPanel5 = new Report.SDLayoutPanel();
			this.sdText43 = new Report.SDText();
			this.sdText44 = new Report.SDText();
			this.sdText45 = new Report.SDText();
			this.sdText46 = new Report.SDText();
			this.sdText47 = new Report.SDText();
			this.sdText49 = new Report.SDText();
			this.sdText50 = new Report.SDText();
			this.sdText52 = new Report.SDText();
			this.sdText53 = new Report.SDText();
			this.sdText55 = new Report.SDText();
			this.sdText56 = new Report.SDText();
			this.sdText58 = new Report.SDText();
			this.sdText59 = new Report.SDText();
			this.sdText60 = new Report.SDText();
			this.sdText61 = new Report.SDText();
			this.sdText62 = new Report.SDText();
			this.sdText64 = new Report.SDText();
			this.sdText65 = new Report.SDText();
			this.sdText66 = new Report.SDText();
			this.sdText67 = new Report.SDText();
			this.sdText68 = new Report.SDText();
			this.sdLabel6 = new Report.SDLabel();
			this.sdRect15 = new Report.SDRect();
			this.sdRect16 = new Report.SDRect();
			this.sdRect17 = new Report.SDRect();
			this.sdRect18 = new Report.SDRect();
			this.tabPage6 = new System.Windows.Forms.TabPage();
			this.sdPage4 = new Report.SDPage();
			this.sdLayoutPanel6 = new Report.SDLayoutPanel();
			this.sdText70 = new Report.SDText();
			this.sdText71 = new Report.SDText();
			this.sdText73 = new Report.SDText();
			this.sdText74 = new Report.SDText();
			this.sdText76 = new Report.SDText();
			this.sdText77 = new Report.SDText();
			this.sdText79 = new Report.SDText();
			this.sdText80 = new Report.SDText();
			this.sdText82 = new Report.SDText();
			this.sdText83 = new Report.SDText();
			this.sdText84 = new Report.SDText();
			this.sdLabel7 = new Report.SDLabel();
			this.sdRect19 = new Report.SDRect();
			this.sdRect20 = new Report.SDRect();
			this.sdRect21 = new Report.SDRect();
			this.sdRect22 = new Report.SDRect();
			this.tabPage7 = new System.Windows.Forms.TabPage();
			this.sdPage5 = new Report.SDPage();
			this.sdLayoutPanel7 = new Report.SDLayoutPanel();
			this.sdText16 = new Report.SDText();
			this.sdText19 = new Report.SDText();
			this.sdText22 = new Report.SDText();
			this.sdText25 = new Report.SDText();
			this.sdText28 = new Report.SDText();
			this.sdText31 = new Report.SDText();
			this.sdText32 = new Report.SDText();
			this.sdText35 = new Report.SDText();
			this.sdText48 = new Report.SDText();
			this.sdText51 = new Report.SDText();
			this.sdText54 = new Report.SDText();
			this.sdText57 = new Report.SDText();
			this.sdText63 = new Report.SDText();
			this.sdText69 = new Report.SDText();
			this.sdText72 = new Report.SDText();
			this.sdText75 = new Report.SDText();
			this.sdText78 = new Report.SDText();
			this.sdText81 = new Report.SDText();
			this.sdText85 = new Report.SDText();
			this.sdText86 = new Report.SDText();
			this.sdText87 = new Report.SDText();
			this.sdText88 = new Report.SDText();
			this.sdLabel8 = new Report.SDLabel();
			this.sdRect23 = new Report.SDRect();
			this.sdRect24 = new Report.SDRect();
			this.sdRect25 = new Report.SDRect();
			this.sdRect26 = new Report.SDRect();
			this.tabPage8 = new System.Windows.Forms.TabPage();
			this.sdPage6 = new Report.SDPage();
			this.sdLayoutPanel8 = new Report.SDLayoutPanel();
			this.sdText89 = new Report.SDText();
			this.sdText90 = new Report.SDText();
			this.sdText91 = new Report.SDText();
			this.sdText92 = new Report.SDText();
			this.sdText93 = new Report.SDText();
			this.sdText94 = new Report.SDText();
			this.sdText95 = new Report.SDText();
			this.sdText96 = new Report.SDText();
			this.sdText97 = new Report.SDText();
			this.sdText98 = new Report.SDText();
			this.sdText99 = new Report.SDText();
			this.sdText100 = new Report.SDText();
			this.sdLabel9 = new Report.SDLabel();
			this.sdRect27 = new Report.SDRect();
			this.sdRect28 = new Report.SDRect();
			this.sdRect29 = new Report.SDRect();
			this.sdRect30 = new Report.SDRect();
			this.tabPage9 = new System.Windows.Forms.TabPage();
			this.sdPage7 = new Report.SDPage();
			this.sdLayoutPanel9 = new Report.SDLayoutPanel();
			this.sdText101 = new Report.SDText();
			this.sdText102 = new Report.SDText();
			this.sdText103 = new Report.SDText();
			this.sdText104 = new Report.SDText();
			this.sdText105 = new Report.SDText();
			this.sdText106 = new Report.SDText();
			this.sdText107 = new Report.SDText();
			this.sdText108 = new Report.SDText();
			this.sdText109 = new Report.SDText();
			this.sdText110 = new Report.SDText();
			this.sdText111 = new Report.SDText();
			this.sdText112 = new Report.SDText();
			this.sdText113 = new Report.SDText();
			this.sdText114 = new Report.SDText();
			this.sdText115 = new Report.SDText();
			this.sdText116 = new Report.SDText();
			this.sdText117 = new Report.SDText();
			this.sdText118 = new Report.SDText();
			this.sdText119 = new Report.SDText();
			this.sdText120 = new Report.SDText();
			this.sdText121 = new Report.SDText();
			this.sdText122 = new Report.SDText();
			this.sdLabel10 = new Report.SDLabel();
			this.sdRect31 = new Report.SDRect();
			this.sdRect32 = new Report.SDRect();
			this.sdRect33 = new Report.SDRect();
			this.sdRect34 = new Report.SDRect();
			this.tabPage10 = new System.Windows.Forms.TabPage();
			this.sdPage8 = new Report.SDPage();
			this.sdLayoutPanel10 = new Report.SDLayoutPanel();
			this.sdText123 = new Report.SDText();
			this.sdText124 = new Report.SDText();
			this.sdText125 = new Report.SDText();
			this.sdText126 = new Report.SDText();
			this.sdLabel11 = new Report.SDLabel();
			this.sdText127 = new Report.SDText();
			this.sdLabel12 = new Report.SDLabel();
			this.sdText128 = new Report.SDText();
			this.sdLabel13 = new Report.SDLabel();
			this.sdText129 = new Report.SDText();
			this.sdLabel14 = new Report.SDLabel();
			this.sdText130 = new Report.SDText();
			this.sdRect35 = new Report.SDRect();
			this.sdText131 = new Report.SDText();
			this.sdText134 = new Report.SDText();
			this.sdText135 = new Report.SDText();
			this.sdText136 = new Report.SDText();
			this.sdText137 = new Report.SDText();
			this.sdText138 = new Report.SDText();
			this.sdText139 = new Report.SDText();
			this.sdText140 = new Report.SDText();
			this.sdText141 = new Report.SDText();
			this.sdText142 = new Report.SDText();
			this.sdText143 = new Report.SDText();
			this.sdText144 = new Report.SDText();
			this.sdLabel15 = new Report.SDLabel();
			this.sdRect36 = new Report.SDRect();
			this.sdRect37 = new Report.SDRect();
			this.sdRect38 = new Report.SDRect();
			this.sdRect39 = new Report.SDRect();
			this.tabPage11 = new System.Windows.Forms.TabPage();
			this.sdPage9 = new Report.SDPage();
			this.sdLayoutPanel11 = new Report.SDLayoutPanel();
			this.sdText145 = new Report.SDText();
			this.sdText146 = new Report.SDText();
			this.sdText147 = new Report.SDText();
			this.sdText148 = new Report.SDText();
			this.sdText149 = new Report.SDText();
			this.sdText150 = new Report.SDText();
			this.sdText151 = new Report.SDText();
			this.sdText152 = new Report.SDText();
			this.sdText153 = new Report.SDText();
			this.sdText154 = new Report.SDText();
			this.sdRect40 = new Report.SDRect();
			this.sdText155 = new Report.SDText();
			this.sdText156 = new Report.SDText();
			this.sdText157 = new Report.SDText();
			this.sdLabel16 = new Report.SDLabel();
			this.sdRect41 = new Report.SDRect();
			this.sdRect42 = new Report.SDRect();
			this.sdRect43 = new Report.SDRect();
			this.sdRect44 = new Report.SDRect();
			this.tabPage12 = new System.Windows.Forms.TabPage();
			this.sdPage10 = new Report.SDPage();
			this.sdLayoutPanel12 = new Report.SDLayoutPanel();
			this.sdText132 = new Report.SDText();
			this.sdText133 = new Report.SDText();
			this.sdText158 = new Report.SDText();
			this.sdText159 = new Report.SDText();
			this.sdText160 = new Report.SDText();
			this.sdText161 = new Report.SDText();
			this.sdText162 = new Report.SDText();
			this.sdText163 = new Report.SDText();
			this.sdText164 = new Report.SDText();
			this.sdText165 = new Report.SDText();
			this.sdText166 = new Report.SDText();
			this.sdText167 = new Report.SDText();
			this.sdText168 = new Report.SDText();
			this.sdText169 = new Report.SDText();
			this.sdText170 = new Report.SDText();
			this.sdText171 = new Report.SDText();
			this.sdText172 = new Report.SDText();
			this.sdText173 = new Report.SDText();
			this.sdText174 = new Report.SDText();
			this.sdText175 = new Report.SDText();
			this.sdText176 = new Report.SDText();
			this.sdText177 = new Report.SDText();
			this.sdText178 = new Report.SDText();
			this.sdText179 = new Report.SDText();
			this.sdText180 = new Report.SDText();
			this.sdLabel17 = new Report.SDLabel();
			this.sdRect45 = new Report.SDRect();
			this.sdRect46 = new Report.SDRect();
			this.sdRect47 = new Report.SDRect();
			this.sdRect48 = new Report.SDRect();
			this.tabPage13 = new System.Windows.Forms.TabPage();
			this.sdPage11 = new Report.SDPage();
			this.sdLayoutPanel13 = new Report.SDLayoutPanel();
			this.sdText181 = new Report.SDText();
			this.sdText182 = new Report.SDText();
			this.sdText183 = new Report.SDText();
			this.sdText184 = new Report.SDText();
			this.sdText185 = new Report.SDText();
			this.sdText186 = new Report.SDText();
			this.sdText187 = new Report.SDText();
			this.sdText188 = new Report.SDText();
			this.sdText189 = new Report.SDText();
			this.sdText190 = new Report.SDText();
			this.sdText191 = new Report.SDText();
			this.sdText192 = new Report.SDText();
			this.sdText193 = new Report.SDText();
			this.sdText194 = new Report.SDText();
			this.sdText195 = new Report.SDText();
			this.sdLabel18 = new Report.SDLabel();
			this.sdRect49 = new Report.SDRect();
			this.sdRect50 = new Report.SDRect();
			this.sdRect51 = new Report.SDRect();
			this.sdRect52 = new Report.SDRect();
			this.tabPage14 = new System.Windows.Forms.TabPage();
			this.sdPage12 = new Report.SDPage();
			this.sdLayoutPanel14 = new Report.SDLayoutPanel();
			this.sdText196 = new Report.SDText();
			this.sdText197 = new Report.SDText();
			this.sdText198 = new Report.SDText();
			this.sdText199 = new Report.SDText();
			this.sdText200 = new Report.SDText();
			this.sdText201 = new Report.SDText();
			this.sdText202 = new Report.SDText();
			this.sdText203 = new Report.SDText();
			this.sdText204 = new Report.SDText();
			this.sdText205 = new Report.SDText();
			this.sdText206 = new Report.SDText();
			this.sdText207 = new Report.SDText();
			this.sdText208 = new Report.SDText();
			this.sdText209 = new Report.SDText();
			this.sdText210 = new Report.SDText();
			this.sdLabel19 = new Report.SDLabel();
			this.sdRect53 = new Report.SDRect();
			this.sdRect54 = new Report.SDRect();
			this.sdRect55 = new Report.SDRect();
			this.sdRect56 = new Report.SDRect();
			this.tabPage15 = new System.Windows.Forms.TabPage();
			this.sdPage13 = new Report.SDPage();
			this.sdLayoutPanel15 = new Report.SDLayoutPanel();
			this.sdRect57 = new Report.SDRect();
			this.sdRect58 = new Report.SDRect();
			this.sdRect59 = new Report.SDRect();
			this.sdRect60 = new Report.SDRect();
			this.sdText211 = new Report.SDText();
			this.sdText212 = new Report.SDText();
			this.sdText213 = new Report.SDText();
			this.sdText214 = new Report.SDText();
			this.sdRect61 = new Report.SDRect();
			this.sdText215 = new Report.SDText();
			this.sdRect62 = new Report.SDRect();
			this.sdText216 = new Report.SDText();
			this.sdText217 = new Report.SDText();
			this.sdText218 = new Report.SDText();
			this.sdText219 = new Report.SDText();
			this.sdText220 = new Report.SDText();
			this.sdText221 = new Report.SDText();
			this.sdText222 = new Report.SDText();
			this.sdText223 = new Report.SDText();
			this.sdText224 = new Report.SDText();
			this.sdText225 = new Report.SDText();
			this.sdText226 = new Report.SDText();
			this.sdText227 = new Report.SDText();
			this.sdText228 = new Report.SDText();
			this.sdLabel20 = new Report.SDLabel();
			this.sdRect63 = new Report.SDRect();
			this.sdRect64 = new Report.SDRect();
			this.sdRect65 = new Report.SDRect();
			this.sdRect66 = new Report.SDRect();
			this.tabPage16 = new System.Windows.Forms.TabPage();
			this.sdPage14 = new Report.SDPage();
			this.sdLayoutPanel16 = new Report.SDLayoutPanel();
			this.sdText229 = new Report.SDText();
			this.sdEllipse6 = new Report.SDEllipse();
			this.sdEllipse5 = new Report.SDEllipse();
			this.sdEllipse4 = new Report.SDEllipse();
			this.sdEllipse3 = new Report.SDEllipse();
			this.sdEllipse2 = new Report.SDEllipse();
			this.sdEllipse1 = new Report.SDEllipse();
			this.sdRect67 = new Report.SDRect();
			this.sdText230 = new Report.SDText();
			this.sdText231 = new Report.SDText();
			this.sdText232 = new Report.SDText();
			this.sdText233 = new Report.SDText();
			this.sdText234 = new Report.SDText();
			this.sdText235 = new Report.SDText();
			this.sdText236 = new Report.SDText();
			this.sdText237 = new Report.SDText();
			this.sdText238 = new Report.SDText();
			this.sdText239 = new Report.SDText();
			this.sdText240 = new Report.SDText();
			this.sdLabel21 = new Report.SDLabel();
			this.sdRect68 = new Report.SDRect();
			this.sdRect69 = new Report.SDRect();
			this.sdRect70 = new Report.SDRect();
			this.sdRect71 = new Report.SDRect();
			this.tabPage17 = new System.Windows.Forms.TabPage();
			this.sdPage15 = new Report.SDPage();
			this.sdLayoutPanel17 = new Report.SDLayoutPanel();
			this.sdAnnotation2 = new Report.SDAnnotation();
			this.sdText241 = new Report.SDText();
			this.sdText242 = new Report.SDText();
			this.sdAnnotation1 = new Report.SDAnnotation();
			this.sdText243 = new Report.SDText();
			this.sdText244 = new Report.SDText();
			this.sdText245 = new Report.SDText();
			this.sdText246 = new Report.SDText();
			this.sdText247 = new Report.SDText();
			this.sdText248 = new Report.SDText();
			this.sdText249 = new Report.SDText();
			this.sdText250 = new Report.SDText();
			this.sdLabel22 = new Report.SDLabel();
			this.sdRect72 = new Report.SDRect();
			this.sdRect73 = new Report.SDRect();
			this.sdRect74 = new Report.SDRect();
			this.sdRect75 = new Report.SDRect();
			this.tabPage18 = new System.Windows.Forms.TabPage();
			this.sdPage16 = new Report.SDPage();
			this.sdLayoutPanel18 = new Report.SDLayoutPanel();
			this.sdText251 = new Report.SDText();
			this.sdText252 = new Report.SDText();
			this.sdText253 = new Report.SDText();
			this.sdText254 = new Report.SDText();
			this.sdText255 = new Report.SDText();
			this.sdText256 = new Report.SDText();
			this.sdText257 = new Report.SDText();
			this.sdText258 = new Report.SDText();
			this.sdText259 = new Report.SDText();
			this.sdText260 = new Report.SDText();
			this.sdText261 = new Report.SDText();
			this.sdText262 = new Report.SDText();
			this.sdText263 = new Report.SDText();
			this.sdText264 = new Report.SDText();
			this.sdText265 = new Report.SDText();
			this.sdText266 = new Report.SDText();
			this.sdText267 = new Report.SDText();
			this.sdText268 = new Report.SDText();
			this.sdText269 = new Report.SDText();
			this.sdText270 = new Report.SDText();
			this.sdText271 = new Report.SDText();
			this.sdText272 = new Report.SDText();
			this.sdLabel23 = new Report.SDLabel();
			this.sdRect76 = new Report.SDRect();
			this.sdRect77 = new Report.SDRect();
			this.sdRect78 = new Report.SDRect();
			this.sdRect79 = new Report.SDRect();
			this.tabPage19 = new System.Windows.Forms.TabPage();
			this.sdPage17 = new Report.SDPage();
			this.sdLayoutPanel19 = new Report.SDLayoutPanel();
			this.sdText273 = new Report.SDText();
			this.sdText274 = new Report.SDText();
			this.sdText275 = new Report.SDText();
			this.sdText276 = new Report.SDText();
			this.sdText277 = new Report.SDText();
			this.sdText278 = new Report.SDText();
			this.sdText279 = new Report.SDText();
			this.sdText280 = new Report.SDText();
			this.sdText281 = new Report.SDText();
			this.sdText282 = new Report.SDText();
			this.sdText283 = new Report.SDText();
			this.sdText284 = new Report.SDText();
			this.sdText285 = new Report.SDText();
			this.sdLabel24 = new Report.SDLabel();
			this.sdRect80 = new Report.SDRect();
			this.sdRect81 = new Report.SDRect();
			this.sdRect82 = new Report.SDRect();
			this.sdRect83 = new Report.SDRect();
			this.tabPage20 = new System.Windows.Forms.TabPage();
			this.sdPage18 = new Report.SDPage();
			this.sdLayoutPanel20 = new Report.SDLayoutPanel();
			this.sdText286 = new Report.SDText();
			this.sdText287 = new Report.SDText();
			this.sdLabel25 = new Report.SDLabel();
			this.sdRect84 = new Report.SDRect();
			this.sdRect85 = new Report.SDRect();
			this.sdRect86 = new Report.SDRect();
			this.sdRect87 = new Report.SDRect();
			this.sdReport1 = new Report.SDReport();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.CoverPage.SuspendLayout();
			this.sdLayoutPanel1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.ContentsPage.SuspendLayout();
			this.sdlayotupanel.SuspendLayout();
			this.sdGridPanel1.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.sdPage1.SuspendLayout();
			this.sdLayoutPanel3.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.sdPage2.SuspendLayout();
			this.sdLayoutPanel4.SuspendLayout();
			this.tabPage5.SuspendLayout();
			this.sdPage3.SuspendLayout();
			this.sdLayoutPanel5.SuspendLayout();
			this.tabPage6.SuspendLayout();
			this.sdPage4.SuspendLayout();
			this.sdLayoutPanel6.SuspendLayout();
			this.tabPage7.SuspendLayout();
			this.sdPage5.SuspendLayout();
			this.sdLayoutPanel7.SuspendLayout();
			this.tabPage8.SuspendLayout();
			this.sdPage6.SuspendLayout();
			this.sdLayoutPanel8.SuspendLayout();
			this.tabPage9.SuspendLayout();
			this.sdPage7.SuspendLayout();
			this.sdLayoutPanel9.SuspendLayout();
			this.tabPage10.SuspendLayout();
			this.sdPage8.SuspendLayout();
			this.sdLayoutPanel10.SuspendLayout();
			this.tabPage11.SuspendLayout();
			this.sdPage9.SuspendLayout();
			this.sdLayoutPanel11.SuspendLayout();
			this.tabPage12.SuspendLayout();
			this.sdPage10.SuspendLayout();
			this.sdLayoutPanel12.SuspendLayout();
			this.tabPage13.SuspendLayout();
			this.sdPage11.SuspendLayout();
			this.sdLayoutPanel13.SuspendLayout();
			this.tabPage14.SuspendLayout();
			this.sdPage12.SuspendLayout();
			this.sdLayoutPanel14.SuspendLayout();
			this.tabPage15.SuspendLayout();
			this.sdPage13.SuspendLayout();
			this.sdLayoutPanel15.SuspendLayout();
			this.tabPage16.SuspendLayout();
			this.sdPage14.SuspendLayout();
			this.sdLayoutPanel16.SuspendLayout();
			this.tabPage17.SuspendLayout();
			this.sdPage15.SuspendLayout();
			this.sdLayoutPanel17.SuspendLayout();
			this.tabPage18.SuspendLayout();
			this.sdPage16.SuspendLayout();
			this.sdLayoutPanel18.SuspendLayout();
			this.tabPage19.SuspendLayout();
			this.sdPage17.SuspendLayout();
			this.sdLayoutPanel19.SuspendLayout();
			this.tabPage20.SuspendLayout();
			this.sdPage18.SuspendLayout();
			this.sdLayoutPanel20.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem2,
																					  this.menuItem3});
			this.menuItem1.Text = "&File";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 0;
			this.menuItem2.Text = "Create &Pdf";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.Text = "E&xit";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.Controls.Add(this.tabPage5);
			this.tabControl1.Controls.Add(this.tabPage6);
			this.tabControl1.Controls.Add(this.tabPage7);
			this.tabControl1.Controls.Add(this.tabPage8);
			this.tabControl1.Controls.Add(this.tabPage9);
			this.tabControl1.Controls.Add(this.tabPage10);
			this.tabControl1.Controls.Add(this.tabPage11);
			this.tabControl1.Controls.Add(this.tabPage12);
			this.tabControl1.Controls.Add(this.tabPage13);
			this.tabControl1.Controls.Add(this.tabPage14);
			this.tabControl1.Controls.Add(this.tabPage15);
			this.tabControl1.Controls.Add(this.tabPage16);
			this.tabControl1.Controls.Add(this.tabPage17);
			this.tabControl1.Controls.Add(this.tabPage18);
			this.tabControl1.Controls.Add(this.tabPage19);
			this.tabControl1.Controls.Add(this.tabPage20);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Multiline = true;
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(784, 761);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.AutoScroll = true;
			this.tabPage1.Controls.Add(this.CoverPage);
			this.tabPage1.Location = new System.Drawing.Point(4, 40);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(776, 717);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Cover";
			// 
			// CoverPage
			// 
			this.CoverPage.Controls.Add(this.sdLayoutPanel1);
			this.CoverPage.DockPadding.All = 32;
			this.CoverPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
			this.CoverPage.Location = new System.Drawing.Point(0, 0);
			this.CoverPage.Name = "CoverPage";
			this.CoverPage.Size = new System.Drawing.Size(596, 842);
			this.CoverPage.TabIndex = 2;
			this.CoverPage.Text = "CoverPage";
			this.CoverPage.PrintPage += new Report.SDPrintPageEvent(this.CoverPage_PrintPage);
			// 
			// sdLayoutPanel1
			// 
			this.sdLayoutPanel1.BackColor = System.Drawing.SystemColors.Window;
			this.sdLayoutPanel1.Controls.Add(this.sdText1);
			this.sdLayoutPanel1.Controls.Add(this.sdLabel1);
			this.sdLayoutPanel1.Controls.Add(this.sdText2);
			this.sdLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sdLayoutPanel1.Location = new System.Drawing.Point(32, 32);
			this.sdLayoutPanel1.Name = "sdLayoutPanel1";
			this.sdLayoutPanel1.Size = new System.Drawing.Size(532, 778);
			this.sdLayoutPanel1.TabIndex = 0;
			this.sdLayoutPanel1.Text = "sdLayoutPanel1";
			this.sdLayoutPanel1.BeforePrint += new Report.SDPrintPanelEvent(this.sdlayotupanel_BeforePrint);
			// 
			// sdText1
			// 
			this.sdText1.BackColor = System.Drawing.SystemColors.Window;
			this.sdText1.CharSpace = 0F;
			this.sdText1.FontBold = true;
			this.sdText1.FontColor = System.Drawing.Color.Black;
			this.sdText1.FontName = Report.SdFontName.Arial;
			this.sdText1.FontSize = 48F;
			this.sdText1.Leading = 14F;
			this.sdText1.Lines = new string[] {
												  "PdfCreator Reference"};
			this.sdText1.Location = new System.Drawing.Point(16, 96);
			this.sdText1.Name = "sdText1";
			this.sdText1.NodeValue = null;
			this.sdText1.Size = new System.Drawing.Size(504, 49);
			this.sdText1.TabIndex = 3;
			this.sdText1.Tag = "1";
			this.sdText1.WordSpace = 0F;
			// 
			// sdLabel1
			// 
			this.sdLabel1.Alignment = Report.SDAlignment.RightJustify;
			this.sdLabel1.CharSpace = 0F;
			this.sdLabel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.sdLabel1.FontColor = System.Drawing.Color.Black;
			this.sdLabel1.FontName = Report.SdFontName.Arial;
			this.sdLabel1.FontSize = 8F;
			this.sdLabel1.Location = new System.Drawing.Point(0, 765);
			this.sdLabel1.Name = "sdLabel1";
			this.sdLabel1.Size = new System.Drawing.Size(532, 13);
			this.sdLabel1.TabIndex = 2;
			this.sdLabel1.Tag = "0";
			this.sdLabel1.Text = "copyright (c) 2002-2003 Serdar Dirican";
			this.sdLabel1.WordSpace = 0F;
			// 
			// sdText2
			// 
			this.sdText2.CharSpace = 0F;
			this.sdText2.FontColor = System.Drawing.Color.Black;
			this.sdText2.FontName = Report.SdFontName.Arial;
			this.sdText2.FontSize = 15F;
			this.sdText2.Leading = 14F;
			this.sdText2.Lines = new string[] {
												  "Version 1.0 ()"};
			this.sdText2.Location = new System.Drawing.Point(32, 152);
			this.sdText2.Name = "sdText2";
			this.sdText2.NodeValue = null;
			this.sdText2.Size = new System.Drawing.Size(362, 21);
			this.sdText2.TabIndex = 1;
			this.sdText2.Tag = "0";
			this.sdText2.WordSpace = 0F;
			// 
			// tabPage2
			// 
			this.tabPage2.AutoScroll = true;
			this.tabPage2.Controls.Add(this.ContentsPage);
			this.tabPage2.Location = new System.Drawing.Point(4, 58);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(472, 211);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Contents";
			// 
			// ContentsPage
			// 
			this.ContentsPage.Controls.Add(this.sdlayotupanel);
			this.ContentsPage.DockPadding.All = 32;
			this.ContentsPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
			this.ContentsPage.Location = new System.Drawing.Point(0, 0);
			this.ContentsPage.Name = "ContentsPage";
			this.ContentsPage.Size = new System.Drawing.Size(596, 842);
			this.ContentsPage.TabIndex = 2;
			this.ContentsPage.Text = "ContentsPage";
			// 
			// sdlayotupanel
			// 
			this.sdlayotupanel.BackColor = System.Drawing.SystemColors.Window;
			this.sdlayotupanel.Controls.Add(this.sdGridPanel1);
			this.sdlayotupanel.Controls.Add(this.ContentsText);
			this.sdlayotupanel.Controls.Add(this.sdRect4);
			this.sdlayotupanel.Controls.Add(this.sdRect3);
			this.sdlayotupanel.Controls.Add(this.sdRect2);
			this.sdlayotupanel.Controls.Add(this.sdRect1);
			this.sdlayotupanel.Controls.Add(this.sdLabel3);
			this.sdlayotupanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sdlayotupanel.Location = new System.Drawing.Point(32, 32);
			this.sdlayotupanel.Name = "sdlayotupanel";
			this.sdlayotupanel.Size = new System.Drawing.Size(532, 778);
			this.sdlayotupanel.TabIndex = 0;
			this.sdlayotupanel.Text = "sdLayoutPanel1";
			this.sdlayotupanel.BeforePrint += new Report.SDPrintPanelEvent(this.sdlayotupanel_BeforePrint);
			// 
			// sdGridPanel1
			// 
			this.sdGridPanel1.BackColor = System.Drawing.SystemColors.Window;
			this.sdGridPanel1.Controls.Add(this.lblSectionName);
			this.sdGridPanel1.Location = new System.Drawing.Point(80, 120);
			this.sdGridPanel1.Name = "sdGridPanel1";
			this.sdGridPanel1.Size = new System.Drawing.Size(361, 450);
			this.sdGridPanel1.TabIndex = 8;
			this.sdGridPanel1.TableColCount = 1;
			this.sdGridPanel1.TableRowCount = 30;
			this.sdGridPanel1.Tag = "0";
			this.sdGridPanel1.BeforePrintChild += new Report.SDPrintChildPanelEvent(this.sdGridPanel1_BeforePrintChild);
			// 
			// lblSectionName
			// 
			this.lblSectionName.CharSpace = 0F;
			this.lblSectionName.FontColor = System.Drawing.Color.Black;
			this.lblSectionName.FontName = Report.SdFontName.Arial;
			this.lblSectionName.FontSize = 12F;
			this.lblSectionName.Location = new System.Drawing.Point(0, 0);
			this.lblSectionName.Name = "lblSectionName";
			this.lblSectionName.Size = new System.Drawing.Size(360, 15);
			this.lblSectionName.TabIndex = 1;
			this.lblSectionName.Tag = "0";
			this.lblSectionName.Text = "lblSectionName";
			this.lblSectionName.WordSpace = 0F;
			// 
			// ContentsText
			// 
			this.ContentsText.CharSpace = 0F;
			this.ContentsText.FontBold = true;
			this.ContentsText.FontColor = System.Drawing.Color.Black;
			this.ContentsText.FontName = Report.SdFontName.Arial;
			this.ContentsText.FontSize = 24F;
			this.ContentsText.Leading = 14F;
			this.ContentsText.Lines = new string[] {
													   "Contents"};
			this.ContentsText.Location = new System.Drawing.Point(192, 56);
			this.ContentsText.Name = "ContentsText";
			this.ContentsText.NodeValue = null;
			this.ContentsText.Size = new System.Drawing.Size(112, 30);
			this.ContentsText.TabIndex = 7;
			this.ContentsText.Tag = "2";
			this.ContentsText.WordSpace = 0F;
			// 
			// sdRect4
			// 
			this.sdRect4.FillColor = System.Drawing.Color.Transparent;
			this.sdRect4.LineColor = System.Drawing.Color.Black;
			this.sdRect4.LineStyle = Report.PenStyle.Solid;
			this.sdRect4.LineWidth = 0F;
			this.sdRect4.Location = new System.Drawing.Point(256, 24);
			this.sdRect4.Name = "sdRect4";
			this.sdRect4.Size = new System.Drawing.Size(2, 24);
			this.sdRect4.TabIndex = 6;
			this.sdRect4.Tag = "0";
			this.sdRect4.Text = "sdRect4";
			// 
			// sdRect3
			// 
			this.sdRect3.FillColor = System.Drawing.Color.Transparent;
			this.sdRect3.LineColor = System.Drawing.Color.Black;
			this.sdRect3.LineStyle = Report.PenStyle.Solid;
			this.sdRect3.LineWidth = 0F;
			this.sdRect3.Location = new System.Drawing.Point(440, 24);
			this.sdRect3.Name = "sdRect3";
			this.sdRect3.Size = new System.Drawing.Size(2, 24);
			this.sdRect3.TabIndex = 5;
			this.sdRect3.Tag = "0";
			this.sdRect3.Text = "sdRect3";
			// 
			// sdRect2
			// 
			this.sdRect2.FillColor = System.Drawing.Color.Transparent;
			this.sdRect2.LineColor = System.Drawing.Color.Black;
			this.sdRect2.LineStyle = Report.PenStyle.Solid;
			this.sdRect2.LineWidth = 0F;
			this.sdRect2.Location = new System.Drawing.Point(80, 24);
			this.sdRect2.Name = "sdRect2";
			this.sdRect2.Size = new System.Drawing.Size(2, 24);
			this.sdRect2.TabIndex = 4;
			this.sdRect2.Tag = "0";
			this.sdRect2.Text = "sdRect2";
			// 
			// sdRect1
			// 
			this.sdRect1.DrawLine = true;
			this.sdRect1.FillColor = System.Drawing.Color.Transparent;
			this.sdRect1.LineColor = System.Drawing.Color.Black;
			this.sdRect1.LineStyle = Report.PenStyle.Solid;
			this.sdRect1.LineWidth = 2F;
			this.sdRect1.Location = new System.Drawing.Point(80, 40);
			this.sdRect1.Name = "sdRect1";
			this.sdRect1.Size = new System.Drawing.Size(360, 3);
			this.sdRect1.TabIndex = 3;
			this.sdRect1.Tag = "0";
			this.sdRect1.Text = "sdRect1";
			// 
			// sdLabel3
			// 
			this.sdLabel3.Alignment = Report.SDAlignment.RightJustify;
			this.sdLabel3.CharSpace = 0F;
			this.sdLabel3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.sdLabel3.FontColor = System.Drawing.Color.Black;
			this.sdLabel3.FontName = Report.SdFontName.Arial;
			this.sdLabel3.FontSize = 8F;
			this.sdLabel3.Location = new System.Drawing.Point(0, 765);
			this.sdLabel3.Name = "sdLabel3";
			this.sdLabel3.Size = new System.Drawing.Size(532, 13);
			this.sdLabel3.TabIndex = 2;
			this.sdLabel3.Tag = "0";
			this.sdLabel3.Text = "copyright (c) 2002-2003 Serdar Dirican";
			this.sdLabel3.WordSpace = 0F;
			// 
			// tabPage3
			// 
			this.tabPage3.AutoScroll = true;
			this.tabPage3.Controls.Add(this.sdPage1);
			this.tabPage3.Location = new System.Drawing.Point(4, 58);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(472, 211);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Introduction";
			// 
			// sdPage1
			// 
			this.sdPage1.Controls.Add(this.sdLayoutPanel3);
			this.sdPage1.DockPadding.All = 32;
			this.sdPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
			this.sdPage1.Location = new System.Drawing.Point(0, 0);
			this.sdPage1.Name = "sdPage1";
			this.sdPage1.Size = new System.Drawing.Size(596, 842);
			this.sdPage1.TabIndex = 1;
			this.sdPage1.Text = "sdPage1";
			// 
			// sdLayoutPanel3
			// 
			this.sdLayoutPanel3.BackColor = System.Drawing.SystemColors.Window;
			this.sdLayoutPanel3.Controls.Add(this.sdText7);
			this.sdLayoutPanel3.Controls.Add(this.sdText8);
			this.sdLayoutPanel3.Controls.Add(this.sdText5);
			this.sdLayoutPanel3.Controls.Add(this.sdText6);
			this.sdLayoutPanel3.Controls.Add(this.sdText4);
			this.sdLayoutPanel3.Controls.Add(this.sdText9);
			this.sdLayoutPanel3.Controls.Add(this.sdText10);
			this.sdLayoutPanel3.Controls.Add(this.sdRect5);
			this.sdLayoutPanel3.Controls.Add(this.sdText11);
			this.sdLayoutPanel3.Controls.Add(this.sdLabel4);
			this.sdLayoutPanel3.Controls.Add(this.sdRect6);
			this.sdLayoutPanel3.Controls.Add(this.sdRect7);
			this.sdLayoutPanel3.Controls.Add(this.sdRect8);
			this.sdLayoutPanel3.Controls.Add(this.sdRect9);
			this.sdLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sdLayoutPanel3.Location = new System.Drawing.Point(32, 32);
			this.sdLayoutPanel3.Name = "sdLayoutPanel3";
			this.sdLayoutPanel3.Size = new System.Drawing.Size(532, 778);
			this.sdLayoutPanel3.TabIndex = 0;
			this.sdLayoutPanel3.Text = "sdLayoutPanel1";
			this.sdLayoutPanel3.BeforePrint += new Report.SDPrintPanelEvent(this.sdlayotupanel_BeforePrint);
			// 
			// sdText7
			// 
			this.sdText7.CharSpace = 0F;
			this.sdText7.FontColor = System.Drawing.Color.Black;
			this.sdText7.FontName = Report.SdFontName.TimesRoman;
			this.sdText7.FontSize = 10F;
			this.sdText7.Leading = 12F;
			this.sdText7.Lines = new string[0];
			this.sdText7.Location = new System.Drawing.Point(112, 320);
			this.sdText7.Name = "sdText7";
			this.sdText7.NodeValue = null;
			this.sdText7.Size = new System.Drawing.Size(328, 32);
			this.sdText7.TabIndex = 20;
			this.sdText7.Tag = "0";
			this.sdText7.WordSpace = 0F;
			// 
			// sdText8
			// 
			this.sdText8.CharSpace = 0F;
			this.sdText8.FontBold = true;
			this.sdText8.FontColor = System.Drawing.Color.Black;
			this.sdText8.FontName = Report.SdFontName.Arial;
			this.sdText8.FontSize = 12F;
			this.sdText8.Leading = 14F;
			this.sdText8.Lines = new string[] {
												  "1.3         Installation"};
			this.sdText8.Location = new System.Drawing.Point(64, 304);
			this.sdText8.Name = "sdText8";
			this.sdText8.NodeValue = null;
			this.sdText8.Size = new System.Drawing.Size(360, 16);
			this.sdText8.TabIndex = 19;
			this.sdText8.Tag = "3";
			this.sdText8.WordSpace = 0F;
			// 
			// sdText5
			// 
			this.sdText5.CharSpace = 0F;
			this.sdText5.FontColor = System.Drawing.Color.Black;
			this.sdText5.FontName = Report.SdFontName.TimesRoman;
			this.sdText5.FontSize = 10F;
			this.sdText5.Leading = 12F;
			this.sdText5.Lines = new string[] {
												  ".Net Framework and Visual Studio.Net"};
			this.sdText5.Location = new System.Drawing.Point(112, 280);
			this.sdText5.Name = "sdText5";
			this.sdText5.NodeValue = null;
			this.sdText5.Size = new System.Drawing.Size(328, 24);
			this.sdText5.TabIndex = 18;
			this.sdText5.Tag = "0";
			this.sdText5.WordSpace = 0F;
			// 
			// sdText6
			// 
			this.sdText6.CharSpace = 0F;
			this.sdText6.FontBold = true;
			this.sdText6.FontColor = System.Drawing.Color.Black;
			this.sdText6.FontName = Report.SdFontName.Arial;
			this.sdText6.FontSize = 12F;
			this.sdText6.Leading = 14F;
			this.sdText6.Lines = new string[] {
												  "1.2         Requires"};
			this.sdText6.Location = new System.Drawing.Point(64, 264);
			this.sdText6.Name = "sdText6";
			this.sdText6.NodeValue = null;
			this.sdText6.Size = new System.Drawing.Size(360, 16);
			this.sdText6.TabIndex = 17;
			this.sdText6.Tag = "3";
			this.sdText6.WordSpace = 0F;
			// 
			// sdText4
			// 
			this.sdText4.CharSpace = 0F;
			this.sdText4.FontColor = System.Drawing.Color.Black;
			this.sdText4.FontName = Report.SdFontName.TimesRoman;
			this.sdText4.FontSize = 10F;
			this.sdText4.Leading = 12F;
			this.sdText4.Lines = new string[] {
												  "PdfCreator is Visual Studio.Net component to create Pdf Document visually.",
												  "You can design Pdf document easily on Visual Studio IDE."};
			this.sdText4.Location = new System.Drawing.Point(112, 232);
			this.sdText4.Name = "sdText4";
			this.sdText4.NodeValue = null;
			this.sdText4.Size = new System.Drawing.Size(328, 32);
			this.sdText4.TabIndex = 16;
			this.sdText4.Tag = "0";
			this.sdText4.WordSpace = 0F;
			// 
			// sdText9
			// 
			this.sdText9.CharSpace = 0F;
			this.sdText9.FontBold = true;
			this.sdText9.FontColor = System.Drawing.Color.Black;
			this.sdText9.FontName = Report.SdFontName.Arial;
			this.sdText9.FontSize = 12F;
			this.sdText9.Leading = 14F;
			this.sdText9.Lines = new string[] {
												  "1.1         What is PdfCreator"};
			this.sdText9.Location = new System.Drawing.Point(64, 216);
			this.sdText9.Name = "sdText9";
			this.sdText9.NodeValue = null;
			this.sdText9.Size = new System.Drawing.Size(360, 16);
			this.sdText9.TabIndex = 15;
			this.sdText9.Tag = "3";
			this.sdText9.WordSpace = 0F;
			// 
			// sdText10
			// 
			this.sdText10.CharSpace = 0F;
			this.sdText10.FontBold = true;
			this.sdText10.FontColor = System.Drawing.Color.Black;
			this.sdText10.FontName = Report.SdFontName.Arial;
			this.sdText10.FontSize = 24F;
			this.sdText10.Leading = 14F;
			this.sdText10.Lines = new string[] {
												   "Introduction"};
			this.sdText10.Location = new System.Drawing.Point(192, 144);
			this.sdText10.Name = "sdText10";
			this.sdText10.NodeValue = null;
			this.sdText10.Size = new System.Drawing.Size(144, 30);
			this.sdText10.TabIndex = 14;
			this.sdText10.Tag = "2";
			this.sdText10.WordSpace = 0F;
			// 
			// sdRect5
			// 
			this.sdRect5.DrawLine = true;
			this.sdRect5.FillColor = System.Drawing.Color.Transparent;
			this.sdRect5.LineColor = System.Drawing.Color.Black;
			this.sdRect5.LineStyle = Report.PenStyle.Solid;
			this.sdRect5.LineWidth = 0F;
			this.sdRect5.Location = new System.Drawing.Point(224, 112);
			this.sdRect5.Name = "sdRect5";
			this.sdRect5.Size = new System.Drawing.Size(72, 1);
			this.sdRect5.TabIndex = 13;
			this.sdRect5.Tag = "0";
			this.sdRect5.Text = "sdRect5";
			// 
			// sdText11
			// 
			this.sdText11.CharSpace = 0F;
			this.sdText11.FontBold = true;
			this.sdText11.FontColor = System.Drawing.Color.Black;
			this.sdText11.FontName = Report.SdFontName.Arial;
			this.sdText11.FontSize = 12F;
			this.sdText11.Leading = 14F;
			this.sdText11.Lines = new string[] {
												   "CHAPTER 1"};
			this.sdText11.Location = new System.Drawing.Point(224, 96);
			this.sdText11.Name = "sdText11";
			this.sdText11.NodeValue = null;
			this.sdText11.Size = new System.Drawing.Size(72, 16);
			this.sdText11.TabIndex = 12;
			this.sdText11.Tag = "0";
			this.sdText11.WordSpace = 0F;
			// 
			// sdLabel4
			// 
			this.sdLabel4.Alignment = Report.SDAlignment.RightJustify;
			this.sdLabel4.CharSpace = 0F;
			this.sdLabel4.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.sdLabel4.FontColor = System.Drawing.Color.Black;
			this.sdLabel4.FontName = Report.SdFontName.Arial;
			this.sdLabel4.FontSize = 8F;
			this.sdLabel4.Location = new System.Drawing.Point(0, 765);
			this.sdLabel4.Name = "sdLabel4";
			this.sdLabel4.Size = new System.Drawing.Size(532, 13);
			this.sdLabel4.TabIndex = 11;
			this.sdLabel4.Tag = "0";
			this.sdLabel4.Text = "copyright (c) 2002-2003 Serdar Dirican";
			this.sdLabel4.WordSpace = 0F;
			// 
			// sdRect6
			// 
			this.sdRect6.FillColor = System.Drawing.Color.Transparent;
			this.sdRect6.LineColor = System.Drawing.Color.Black;
			this.sdRect6.LineStyle = Report.PenStyle.Solid;
			this.sdRect6.LineWidth = 0F;
			this.sdRect6.Location = new System.Drawing.Point(256, 24);
			this.sdRect6.Name = "sdRect6";
			this.sdRect6.Size = new System.Drawing.Size(2, 24);
			this.sdRect6.TabIndex = 10;
			this.sdRect6.Tag = "0";
			this.sdRect6.Text = "sdRect4";
			// 
			// sdRect7
			// 
			this.sdRect7.FillColor = System.Drawing.Color.Transparent;
			this.sdRect7.LineColor = System.Drawing.Color.Black;
			this.sdRect7.LineStyle = Report.PenStyle.Solid;
			this.sdRect7.LineWidth = 0F;
			this.sdRect7.Location = new System.Drawing.Point(440, 24);
			this.sdRect7.Name = "sdRect7";
			this.sdRect7.Size = new System.Drawing.Size(2, 24);
			this.sdRect7.TabIndex = 9;
			this.sdRect7.Tag = "0";
			this.sdRect7.Text = "sdRect3";
			// 
			// sdRect8
			// 
			this.sdRect8.FillColor = System.Drawing.Color.Transparent;
			this.sdRect8.LineColor = System.Drawing.Color.Black;
			this.sdRect8.LineStyle = Report.PenStyle.Solid;
			this.sdRect8.LineWidth = 0F;
			this.sdRect8.Location = new System.Drawing.Point(80, 24);
			this.sdRect8.Name = "sdRect8";
			this.sdRect8.Size = new System.Drawing.Size(2, 24);
			this.sdRect8.TabIndex = 8;
			this.sdRect8.Tag = "0";
			this.sdRect8.Text = "sdRect2";
			// 
			// sdRect9
			// 
			this.sdRect9.DrawLine = true;
			this.sdRect9.FillColor = System.Drawing.Color.Transparent;
			this.sdRect9.LineColor = System.Drawing.Color.Black;
			this.sdRect9.LineStyle = Report.PenStyle.Solid;
			this.sdRect9.LineWidth = 2F;
			this.sdRect9.Location = new System.Drawing.Point(80, 40);
			this.sdRect9.Name = "sdRect9";
			this.sdRect9.Size = new System.Drawing.Size(360, 3);
			this.sdRect9.TabIndex = 7;
			this.sdRect9.Tag = "0";
			this.sdRect9.Text = "sdRect1";
			// 
			// tabPage4
			// 
			this.tabPage4.AutoScroll = true;
			this.tabPage4.Controls.Add(this.sdPage2);
			this.tabPage4.Location = new System.Drawing.Point(4, 58);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Size = new System.Drawing.Size(472, 211);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "SDReport";
			// 
			// sdPage2
			// 
			this.sdPage2.Controls.Add(this.sdLayoutPanel4);
			this.sdPage2.DockPadding.All = 32;
			this.sdPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
			this.sdPage2.Location = new System.Drawing.Point(0, 0);
			this.sdPage2.Name = "sdPage2";
			this.sdPage2.Size = new System.Drawing.Size(596, 842);
			this.sdPage2.TabIndex = 1;
			this.sdPage2.Text = "sdPage2";
			// 
			// sdLayoutPanel4
			// 
			this.sdLayoutPanel4.BackColor = System.Drawing.SystemColors.Window;
			this.sdLayoutPanel4.Controls.Add(this.sdText29);
			this.sdLayoutPanel4.Controls.Add(this.sdText30);
			this.sdLayoutPanel4.Controls.Add(this.sdText26);
			this.sdLayoutPanel4.Controls.Add(this.sdText27);
			this.sdLayoutPanel4.Controls.Add(this.sdText23);
			this.sdLayoutPanel4.Controls.Add(this.sdText24);
			this.sdLayoutPanel4.Controls.Add(this.sdText20);
			this.sdLayoutPanel4.Controls.Add(this.sdText21);
			this.sdLayoutPanel4.Controls.Add(this.sdText17);
			this.sdLayoutPanel4.Controls.Add(this.sdText18);
			this.sdLayoutPanel4.Controls.Add(this.sdText14);
			this.sdLayoutPanel4.Controls.Add(this.sdText15);
			this.sdLayoutPanel4.Controls.Add(this.sdText12);
			this.sdLayoutPanel4.Controls.Add(this.sdText13);
			this.sdLayoutPanel4.Controls.Add(this.sdText33);
			this.sdLayoutPanel4.Controls.Add(this.sdText34);
			this.sdLayoutPanel4.Controls.Add(this.sdText36);
			this.sdLayoutPanel4.Controls.Add(this.sdText37);
			this.sdLayoutPanel4.Controls.Add(this.sdText38);
			this.sdLayoutPanel4.Controls.Add(this.sdText39);
			this.sdLayoutPanel4.Controls.Add(this.sdText40);
			this.sdLayoutPanel4.Controls.Add(this.sdText41);
			this.sdLayoutPanel4.Controls.Add(this.sdRect10);
			this.sdLayoutPanel4.Controls.Add(this.sdText42);
			this.sdLayoutPanel4.Controls.Add(this.sdLabel5);
			this.sdLayoutPanel4.Controls.Add(this.sdRect11);
			this.sdLayoutPanel4.Controls.Add(this.sdRect12);
			this.sdLayoutPanel4.Controls.Add(this.sdRect13);
			this.sdLayoutPanel4.Controls.Add(this.sdRect14);
			this.sdLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sdLayoutPanel4.Location = new System.Drawing.Point(32, 32);
			this.sdLayoutPanel4.Name = "sdLayoutPanel4";
			this.sdLayoutPanel4.Size = new System.Drawing.Size(532, 778);
			this.sdLayoutPanel4.TabIndex = 0;
			this.sdLayoutPanel4.Text = "sdLayoutPanel1";
			this.sdLayoutPanel4.BeforePrint += new Report.SDPrintPanelEvent(this.sdlayotupanel_BeforePrint);
			// 
			// sdText29
			// 
			this.sdText29.CharSpace = 0F;
			this.sdText29.FontColor = System.Drawing.Color.Black;
			this.sdText29.FontName = Report.SdFontName.TimesRoman;
			this.sdText29.FontSize = 10F;
			this.sdText29.Leading = 12F;
			this.sdText29.Lines = new string[] {
												   "Set Title to specify the title of the document."};
			this.sdText29.Location = new System.Drawing.Point(112, 664);
			this.sdText29.Name = "sdText29";
			this.sdText29.NodeValue = null;
			this.sdText29.Size = new System.Drawing.Size(368, 24);
			this.sdText29.TabIndex = 43;
			this.sdText29.Tag = "0";
			this.sdText29.WordSpace = 0F;
			// 
			// sdText30
			// 
			this.sdText30.CharSpace = 0F;
			this.sdText30.FontColor = System.Drawing.Color.Black;
			this.sdText30.FontName = Report.SdFontName.Arial;
			this.sdText30.FontSize = 10F;
			this.sdText30.Leading = 12F;
			this.sdText30.Lines = new string[] {
												   "public string Title [  get,  set ]"};
			this.sdText30.Location = new System.Drawing.Point(112, 648);
			this.sdText30.Name = "sdText30";
			this.sdText30.NodeValue = null;
			this.sdText30.Size = new System.Drawing.Size(320, 16);
			this.sdText30.TabIndex = 42;
			this.sdText30.Tag = "0";
			this.sdText30.WordSpace = 0F;
			// 
			// sdText26
			// 
			this.sdText26.CharSpace = 0F;
			this.sdText26.FontColor = System.Drawing.Color.Black;
			this.sdText26.FontName = Report.SdFontName.TimesRoman;
			this.sdText26.FontSize = 10F;
			this.sdText26.Leading = 12F;
			this.sdText26.Lines = new string[] {
												   "Set Subject to specify the subject of the document."};
			this.sdText26.Location = new System.Drawing.Point(112, 624);
			this.sdText26.Name = "sdText26";
			this.sdText26.NodeValue = null;
			this.sdText26.Size = new System.Drawing.Size(368, 24);
			this.sdText26.TabIndex = 40;
			this.sdText26.Tag = "0";
			this.sdText26.WordSpace = 0F;
			// 
			// sdText27
			// 
			this.sdText27.CharSpace = 0F;
			this.sdText27.FontColor = System.Drawing.Color.Black;
			this.sdText27.FontName = Report.SdFontName.Arial;
			this.sdText27.FontSize = 10F;
			this.sdText27.Leading = 12F;
			this.sdText27.Lines = new string[] {
												   "public string Subject [  get,  set ]"};
			this.sdText27.Location = new System.Drawing.Point(112, 608);
			this.sdText27.Name = "sdText27";
			this.sdText27.NodeValue = null;
			this.sdText27.Size = new System.Drawing.Size(320, 16);
			this.sdText27.TabIndex = 39;
			this.sdText27.Tag = "0";
			this.sdText27.WordSpace = 0F;
			// 
			// sdText23
			// 
			this.sdText23.CharSpace = 0F;
			this.sdText23.FontColor = System.Drawing.Color.Black;
			this.sdText23.FontName = Report.SdFontName.TimesRoman;
			this.sdText23.FontSize = 10F;
			this.sdText23.Leading = 12F;
			this.sdText23.Lines = new string[] {
												   "Set Keywords to specify the date and time when the document was last modified."};
			this.sdText23.Location = new System.Drawing.Point(112, 584);
			this.sdText23.Name = "sdText23";
			this.sdText23.NodeValue = null;
			this.sdText23.Size = new System.Drawing.Size(368, 24);
			this.sdText23.TabIndex = 37;
			this.sdText23.Tag = "0";
			this.sdText23.WordSpace = 0F;
			// 
			// sdText24
			// 
			this.sdText24.CharSpace = 0F;
			this.sdText24.FontColor = System.Drawing.Color.Black;
			this.sdText24.FontName = Report.SdFontName.Arial;
			this.sdText24.FontSize = 10F;
			this.sdText24.Leading = 12F;
			this.sdText24.Lines = new string[] {
												   "public System.DateTime ModDate [  get,  set ]"};
			this.sdText24.Location = new System.Drawing.Point(112, 568);
			this.sdText24.Name = "sdText24";
			this.sdText24.NodeValue = null;
			this.sdText24.Size = new System.Drawing.Size(320, 16);
			this.sdText24.TabIndex = 36;
			this.sdText24.Tag = "0";
			this.sdText24.WordSpace = 0F;
			// 
			// sdText20
			// 
			this.sdText20.CharSpace = 0F;
			this.sdText20.FontColor = System.Drawing.Color.Black;
			this.sdText20.FontName = Report.SdFontName.TimesRoman;
			this.sdText20.FontSize = 10F;
			this.sdText20.Leading = 12F;
			this.sdText20.Lines = new string[] {
												   "Set Keywords to specify keywords of the document."};
			this.sdText20.Location = new System.Drawing.Point(112, 544);
			this.sdText20.Name = "sdText20";
			this.sdText20.NodeValue = null;
			this.sdText20.Size = new System.Drawing.Size(368, 24);
			this.sdText20.TabIndex = 34;
			this.sdText20.Tag = "0";
			this.sdText20.WordSpace = 0F;
			// 
			// sdText21
			// 
			this.sdText21.CharSpace = 0F;
			this.sdText21.FontColor = System.Drawing.Color.Black;
			this.sdText21.FontName = Report.SdFontName.Arial;
			this.sdText21.FontSize = 10F;
			this.sdText21.Leading = 12F;
			this.sdText21.Lines = new string[] {
												   "public string Keywords [  get,  set ]"};
			this.sdText21.Location = new System.Drawing.Point(112, 528);
			this.sdText21.Name = "sdText21";
			this.sdText21.NodeValue = null;
			this.sdText21.Size = new System.Drawing.Size(320, 16);
			this.sdText21.TabIndex = 33;
			this.sdText21.Tag = "0";
			this.sdText21.WordSpace = 0F;
			// 
			// sdText17
			// 
			this.sdText17.CharSpace = 0F;
			this.sdText17.FontColor = System.Drawing.Color.Black;
			this.sdText17.FontName = Report.SdFontName.TimesRoman;
			this.sdText17.FontSize = 10F;
			this.sdText17.Leading = 12F;
			this.sdText17.Lines = new string[] {
												   "Set Creator to specify the creator of the document."};
			this.sdText17.Location = new System.Drawing.Point(112, 504);
			this.sdText17.Name = "sdText17";
			this.sdText17.NodeValue = null;
			this.sdText17.Size = new System.Drawing.Size(368, 24);
			this.sdText17.TabIndex = 31;
			this.sdText17.Tag = "0";
			this.sdText17.WordSpace = 0F;
			// 
			// sdText18
			// 
			this.sdText18.CharSpace = 0F;
			this.sdText18.FontColor = System.Drawing.Color.Black;
			this.sdText18.FontName = Report.SdFontName.Arial;
			this.sdText18.FontSize = 10F;
			this.sdText18.Leading = 12F;
			this.sdText18.Lines = new string[] {
												   "public string Creator [  get,  set ]"};
			this.sdText18.Location = new System.Drawing.Point(112, 488);
			this.sdText18.Name = "sdText18";
			this.sdText18.NodeValue = null;
			this.sdText18.Size = new System.Drawing.Size(320, 16);
			this.sdText18.TabIndex = 30;
			this.sdText18.Tag = "0";
			this.sdText18.WordSpace = 0F;
			// 
			// sdText14
			// 
			this.sdText14.CharSpace = 0F;
			this.sdText14.FontColor = System.Drawing.Color.Black;
			this.sdText14.FontName = Report.SdFontName.TimesRoman;
			this.sdText14.FontSize = 10F;
			this.sdText14.Leading = 12F;
			this.sdText14.Lines = new string[] {
												   "Set CreationDate to specify the date and time when the document was created."};
			this.sdText14.Location = new System.Drawing.Point(112, 464);
			this.sdText14.Name = "sdText14";
			this.sdText14.NodeValue = null;
			this.sdText14.Size = new System.Drawing.Size(368, 24);
			this.sdText14.TabIndex = 28;
			this.sdText14.Tag = "0";
			this.sdText14.WordSpace = 0F;
			// 
			// sdText15
			// 
			this.sdText15.CharSpace = 0F;
			this.sdText15.FontColor = System.Drawing.Color.Black;
			this.sdText15.FontName = Report.SdFontName.Arial;
			this.sdText15.FontSize = 10F;
			this.sdText15.Leading = 12F;
			this.sdText15.Lines = new string[] {
												   "public System.DateTime CreationDate [  get,  set ]"};
			this.sdText15.Location = new System.Drawing.Point(112, 448);
			this.sdText15.Name = "sdText15";
			this.sdText15.NodeValue = null;
			this.sdText15.Size = new System.Drawing.Size(320, 16);
			this.sdText15.TabIndex = 27;
			this.sdText15.Tag = "0";
			this.sdText15.WordSpace = 0F;
			// 
			// sdText12
			// 
			this.sdText12.CharSpace = 0F;
			this.sdText12.FontColor = System.Drawing.Color.Black;
			this.sdText12.FontName = Report.SdFontName.TimesRoman;
			this.sdText12.FontSize = 10F;
			this.sdText12.Leading = 12F;
			this.sdText12.Lines = new string[] {
												   "Set Author to specify the author of the document."};
			this.sdText12.Location = new System.Drawing.Point(112, 424);
			this.sdText12.Name = "sdText12";
			this.sdText12.NodeValue = null;
			this.sdText12.Size = new System.Drawing.Size(368, 24);
			this.sdText12.TabIndex = 25;
			this.sdText12.Tag = "0";
			this.sdText12.WordSpace = 0F;
			// 
			// sdText13
			// 
			this.sdText13.CharSpace = 0F;
			this.sdText13.FontColor = System.Drawing.Color.Black;
			this.sdText13.FontName = Report.SdFontName.Arial;
			this.sdText13.FontSize = 10F;
			this.sdText13.Leading = 12F;
			this.sdText13.Lines = new string[] {
												   "public string Author [  get,  set ]"};
			this.sdText13.Location = new System.Drawing.Point(112, 408);
			this.sdText13.Name = "sdText13";
			this.sdText13.NodeValue = null;
			this.sdText13.Size = new System.Drawing.Size(320, 16);
			this.sdText13.TabIndex = 24;
			this.sdText13.Tag = "0";
			this.sdText13.WordSpace = 0F;
			// 
			// sdText33
			// 
			this.sdText33.CharSpace = 0F;
			this.sdText33.FontColor = System.Drawing.Color.Black;
			this.sdText33.FontName = Report.SdFontName.TimesRoman;
			this.sdText33.FontSize = 10F;
			this.sdText33.Leading = 12F;
			this.sdText33.Lines = new string[] {
												   "Set FileName to specify the file name to save document."};
			this.sdText33.Location = new System.Drawing.Point(112, 384);
			this.sdText33.Name = "sdText33";
			this.sdText33.NodeValue = null;
			this.sdText33.Size = new System.Drawing.Size(368, 24);
			this.sdText33.TabIndex = 22;
			this.sdText33.Tag = "0";
			this.sdText33.WordSpace = 0F;
			// 
			// sdText34
			// 
			this.sdText34.CharSpace = 0F;
			this.sdText34.FontColor = System.Drawing.Color.Black;
			this.sdText34.FontName = Report.SdFontName.Arial;
			this.sdText34.FontSize = 10F;
			this.sdText34.Leading = 12F;
			this.sdText34.Lines = new string[] {
												   "public string FileName [  get,  set ]"};
			this.sdText34.Location = new System.Drawing.Point(112, 368);
			this.sdText34.Name = "sdText34";
			this.sdText34.NodeValue = null;
			this.sdText34.Size = new System.Drawing.Size(320, 16);
			this.sdText34.TabIndex = 21;
			this.sdText34.Tag = "0";
			this.sdText34.WordSpace = 0F;
			// 
			// sdText36
			// 
			this.sdText36.CharSpace = 0F;
			this.sdText36.FontBold = true;
			this.sdText36.FontColor = System.Drawing.Color.Black;
			this.sdText36.FontName = Report.SdFontName.Arial;
			this.sdText36.FontSize = 12F;
			this.sdText36.Leading = 14F;
			this.sdText36.Lines = new string[] {
												   "2.1.1      SDReport Properties"};
			this.sdText36.Location = new System.Drawing.Point(64, 352);
			this.sdText36.Name = "sdText36";
			this.sdText36.NodeValue = null;
			this.sdText36.Size = new System.Drawing.Size(360, 16);
			this.sdText36.TabIndex = 19;
			this.sdText36.Tag = "4";
			this.sdText36.WordSpace = 0F;
			// 
			// sdText37
			// 
			this.sdText37.CharSpace = 0F;
			this.sdText37.FontColor = System.Drawing.Color.Black;
			this.sdText37.FontName = Report.SdFontName.TimesRoman;
			this.sdText37.FontSize = 10F;
			this.sdText37.Leading = 12F;
			this.sdText37.Lines = new string[] {
												   "Use SDReport to create pdf document. To start print job, call the BeginDoc",
												   "method.To print page, call the Print method. And call the EndDoc method to termin" +
												   "ate",
												   "print job.If you want to terminate print job unless saving document, call the Abo" +
												   "rt method."};
			this.sdText37.Location = new System.Drawing.Point(112, 272);
			this.sdText37.Name = "sdText37";
			this.sdText37.NodeValue = null;
			this.sdText37.Size = new System.Drawing.Size(368, 40);
			this.sdText37.TabIndex = 18;
			this.sdText37.Tag = "0";
			this.sdText37.WordSpace = 0F;
			// 
			// sdText38
			// 
			this.sdText38.CharSpace = 0F;
			this.sdText38.FontBold = true;
			this.sdText38.FontColor = System.Drawing.Color.Black;
			this.sdText38.FontName = Report.SdFontName.Arial;
			this.sdText38.FontSize = 12F;
			this.sdText38.Leading = 14F;
			this.sdText38.Lines = new string[] {
												   "Description"};
			this.sdText38.Location = new System.Drawing.Point(112, 256);
			this.sdText38.Name = "sdText38";
			this.sdText38.NodeValue = null;
			this.sdText38.Size = new System.Drawing.Size(328, 16);
			this.sdText38.TabIndex = 17;
			this.sdText38.Tag = "0";
			this.sdText38.WordSpace = 0F;
			// 
			// sdText39
			// 
			this.sdText39.CharSpace = 0F;
			this.sdText39.FontColor = System.Drawing.Color.Black;
			this.sdText39.FontName = Report.SdFontName.TimesRoman;
			this.sdText39.FontSize = 10F;
			this.sdText39.Leading = 12F;
			this.sdText39.Lines = new string[] {
												   "SDReport encapsulates the mechanism for creating pdf document."};
			this.sdText39.Location = new System.Drawing.Point(112, 232);
			this.sdText39.Name = "sdText39";
			this.sdText39.NodeValue = null;
			this.sdText39.Size = new System.Drawing.Size(328, 24);
			this.sdText39.TabIndex = 16;
			this.sdText39.Tag = "0";
			this.sdText39.WordSpace = 0F;
			// 
			// sdText40
			// 
			this.sdText40.CharSpace = 0F;
			this.sdText40.FontBold = true;
			this.sdText40.FontColor = System.Drawing.Color.Black;
			this.sdText40.FontName = Report.SdFontName.Arial;
			this.sdText40.FontSize = 12F;
			this.sdText40.Leading = 14F;
			this.sdText40.Lines = new string[] {
												   "2.1         SDReport"};
			this.sdText40.Location = new System.Drawing.Point(64, 216);
			this.sdText40.Name = "sdText40";
			this.sdText40.NodeValue = null;
			this.sdText40.Size = new System.Drawing.Size(360, 16);
			this.sdText40.TabIndex = 15;
			this.sdText40.Tag = "3";
			this.sdText40.WordSpace = 0F;
			// 
			// sdText41
			// 
			this.sdText41.CharSpace = 0F;
			this.sdText41.FontBold = true;
			this.sdText41.FontColor = System.Drawing.Color.Black;
			this.sdText41.FontName = Report.SdFontName.Arial;
			this.sdText41.FontSize = 24F;
			this.sdText41.Leading = 14F;
			this.sdText41.Lines = new string[] {
												   "Component Reference"};
			this.sdText41.Location = new System.Drawing.Point(128, 136);
			this.sdText41.Name = "sdText41";
			this.sdText41.NodeValue = null;
			this.sdText41.Size = new System.Drawing.Size(264, 30);
			this.sdText41.TabIndex = 14;
			this.sdText41.Tag = "2";
			this.sdText41.WordSpace = 0F;
			// 
			// sdRect10
			// 
			this.sdRect10.DrawLine = true;
			this.sdRect10.FillColor = System.Drawing.Color.Transparent;
			this.sdRect10.LineColor = System.Drawing.Color.Black;
			this.sdRect10.LineStyle = Report.PenStyle.Solid;
			this.sdRect10.LineWidth = 0F;
			this.sdRect10.Location = new System.Drawing.Point(224, 112);
			this.sdRect10.Name = "sdRect10";
			this.sdRect10.Size = new System.Drawing.Size(72, 1);
			this.sdRect10.TabIndex = 13;
			this.sdRect10.Tag = "0";
			this.sdRect10.Text = "sdRect5";
			// 
			// sdText42
			// 
			this.sdText42.CharSpace = 0F;
			this.sdText42.FontBold = true;
			this.sdText42.FontColor = System.Drawing.Color.Black;
			this.sdText42.FontName = Report.SdFontName.Arial;
			this.sdText42.FontSize = 12F;
			this.sdText42.Leading = 14F;
			this.sdText42.Lines = new string[] {
												   "CHAPTER 2"};
			this.sdText42.Location = new System.Drawing.Point(224, 96);
			this.sdText42.Name = "sdText42";
			this.sdText42.NodeValue = null;
			this.sdText42.Size = new System.Drawing.Size(72, 16);
			this.sdText42.TabIndex = 12;
			this.sdText42.Tag = "0";
			this.sdText42.WordSpace = 0F;
			// 
			// sdLabel5
			// 
			this.sdLabel5.Alignment = Report.SDAlignment.RightJustify;
			this.sdLabel5.CharSpace = 0F;
			this.sdLabel5.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.sdLabel5.FontColor = System.Drawing.Color.Black;
			this.sdLabel5.FontName = Report.SdFontName.Arial;
			this.sdLabel5.FontSize = 8F;
			this.sdLabel5.Location = new System.Drawing.Point(0, 765);
			this.sdLabel5.Name = "sdLabel5";
			this.sdLabel5.Size = new System.Drawing.Size(532, 13);
			this.sdLabel5.TabIndex = 11;
			this.sdLabel5.Tag = "0";
			this.sdLabel5.Text = "copyright (c) 2002-2003 Serdar Dirican";
			this.sdLabel5.WordSpace = 0F;
			// 
			// sdRect11
			// 
			this.sdRect11.FillColor = System.Drawing.Color.Transparent;
			this.sdRect11.LineColor = System.Drawing.Color.Black;
			this.sdRect11.LineStyle = Report.PenStyle.Solid;
			this.sdRect11.LineWidth = 0F;
			this.sdRect11.Location = new System.Drawing.Point(256, 24);
			this.sdRect11.Name = "sdRect11";
			this.sdRect11.Size = new System.Drawing.Size(2, 24);
			this.sdRect11.TabIndex = 10;
			this.sdRect11.Tag = "0";
			this.sdRect11.Text = "sdRect4";
			// 
			// sdRect12
			// 
			this.sdRect12.FillColor = System.Drawing.Color.Transparent;
			this.sdRect12.LineColor = System.Drawing.Color.Black;
			this.sdRect12.LineStyle = Report.PenStyle.Solid;
			this.sdRect12.LineWidth = 0F;
			this.sdRect12.Location = new System.Drawing.Point(440, 24);
			this.sdRect12.Name = "sdRect12";
			this.sdRect12.Size = new System.Drawing.Size(2, 24);
			this.sdRect12.TabIndex = 9;
			this.sdRect12.Tag = "0";
			this.sdRect12.Text = "sdRect3";
			// 
			// sdRect13
			// 
			this.sdRect13.FillColor = System.Drawing.Color.Transparent;
			this.sdRect13.LineColor = System.Drawing.Color.Black;
			this.sdRect13.LineStyle = Report.PenStyle.Solid;
			this.sdRect13.LineWidth = 0F;
			this.sdRect13.Location = new System.Drawing.Point(80, 24);
			this.sdRect13.Name = "sdRect13";
			this.sdRect13.Size = new System.Drawing.Size(2, 24);
			this.sdRect13.TabIndex = 8;
			this.sdRect13.Tag = "0";
			this.sdRect13.Text = "sdRect2";
			// 
			// sdRect14
			// 
			this.sdRect14.DrawLine = true;
			this.sdRect14.FillColor = System.Drawing.Color.Transparent;
			this.sdRect14.LineColor = System.Drawing.Color.Black;
			this.sdRect14.LineStyle = Report.PenStyle.Solid;
			this.sdRect14.LineWidth = 2F;
			this.sdRect14.Location = new System.Drawing.Point(80, 40);
			this.sdRect14.Name = "sdRect14";
			this.sdRect14.Size = new System.Drawing.Size(360, 3);
			this.sdRect14.TabIndex = 7;
			this.sdRect14.Tag = "0";
			this.sdRect14.Text = "sdRect1";
			// 
			// tabPage5
			// 
			this.tabPage5.AutoScroll = true;
			this.tabPage5.Controls.Add(this.sdPage3);
			this.tabPage5.Location = new System.Drawing.Point(4, 58);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Size = new System.Drawing.Size(472, 211);
			this.tabPage5.TabIndex = 4;
			this.tabPage5.Text = "SDReport(2)";
			// 
			// sdPage3
			// 
			this.sdPage3.Controls.Add(this.sdLayoutPanel5);
			this.sdPage3.DockPadding.All = 32;
			this.sdPage3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
			this.sdPage3.Location = new System.Drawing.Point(0, 0);
			this.sdPage3.Name = "sdPage3";
			this.sdPage3.Size = new System.Drawing.Size(596, 842);
			this.sdPage3.TabIndex = 1;
			this.sdPage3.Text = "sdPage3";
			// 
			// sdLayoutPanel5
			// 
			this.sdLayoutPanel5.BackColor = System.Drawing.SystemColors.Window;
			this.sdLayoutPanel5.Controls.Add(this.sdText43);
			this.sdLayoutPanel5.Controls.Add(this.sdText44);
			this.sdLayoutPanel5.Controls.Add(this.sdText45);
			this.sdLayoutPanel5.Controls.Add(this.sdText46);
			this.sdLayoutPanel5.Controls.Add(this.sdText47);
			this.sdLayoutPanel5.Controls.Add(this.sdText49);
			this.sdLayoutPanel5.Controls.Add(this.sdText50);
			this.sdLayoutPanel5.Controls.Add(this.sdText52);
			this.sdLayoutPanel5.Controls.Add(this.sdText53);
			this.sdLayoutPanel5.Controls.Add(this.sdText55);
			this.sdLayoutPanel5.Controls.Add(this.sdText56);
			this.sdLayoutPanel5.Controls.Add(this.sdText58);
			this.sdLayoutPanel5.Controls.Add(this.sdText59);
			this.sdLayoutPanel5.Controls.Add(this.sdText60);
			this.sdLayoutPanel5.Controls.Add(this.sdText61);
			this.sdLayoutPanel5.Controls.Add(this.sdText62);
			this.sdLayoutPanel5.Controls.Add(this.sdText64);
			this.sdLayoutPanel5.Controls.Add(this.sdText65);
			this.sdLayoutPanel5.Controls.Add(this.sdText66);
			this.sdLayoutPanel5.Controls.Add(this.sdText67);
			this.sdLayoutPanel5.Controls.Add(this.sdText68);
			this.sdLayoutPanel5.Controls.Add(this.sdLabel6);
			this.sdLayoutPanel5.Controls.Add(this.sdRect15);
			this.sdLayoutPanel5.Controls.Add(this.sdRect16);
			this.sdLayoutPanel5.Controls.Add(this.sdRect17);
			this.sdLayoutPanel5.Controls.Add(this.sdRect18);
			this.sdLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sdLayoutPanel5.Location = new System.Drawing.Point(32, 32);
			this.sdLayoutPanel5.Name = "sdLayoutPanel5";
			this.sdLayoutPanel5.Size = new System.Drawing.Size(532, 778);
			this.sdLayoutPanel5.TabIndex = 0;
			this.sdLayoutPanel5.Tag = "0";
			this.sdLayoutPanel5.Text = "sdLayoutPanel1";
			this.sdLayoutPanel5.BeforePrint += new Report.SDPrintPanelEvent(this.sdlayotupanel_BeforePrint);
			// 
			// sdText43
			// 
			this.sdText43.CharSpace = 0F;
			this.sdText43.FontColor = System.Drawing.Color.Black;
			this.sdText43.FontName = Report.SdFontName.TimesRoman;
			this.sdText43.FontSize = 10F;
			this.sdText43.Leading = 12F;
			this.sdText43.Lines = new string[] {
												   "Specifies that the toolbar should be hidden.",
												   "Specifies that the menubar should be hidden.",
												   "Specifies that the interfeces of the document window should ",
												   "be hidden.",
												   "Specifies that the viewer should resize the document-window ",
												   "to the size of the first displayed page of the document.",
												   "Specifies that the viewer-window positioned in the center of ",
												   "the screen."};
			this.sdText43.Location = new System.Drawing.Point(232, 480);
			this.sdText43.Name = "sdText43";
			this.sdText43.NodeValue = null;
			this.sdText43.Size = new System.Drawing.Size(248, 96);
			this.sdText43.TabIndex = 46;
			this.sdText43.Tag = "0";
			this.sdText43.WordSpace = 0F;
			// 
			// sdText44
			// 
			this.sdText44.CharSpace = 0F;
			this.sdText44.FontColor = System.Drawing.Color.Black;
			this.sdText44.FontName = Report.SdFontName.TimesRoman;
			this.sdText44.FontSize = 10F;
			this.sdText44.Leading = 12F;
			this.sdText44.Lines = new string[] {
												   "HideToolbar",
												   "HideMenubar",
												   "HideWindowUI",
												   "",
												   "",
												   "FitWindow",
												   "",
												   "",
												   "CenterWindow"};
			this.sdText44.Location = new System.Drawing.Point(152, 480);
			this.sdText44.Name = "sdText44";
			this.sdText44.NodeValue = null;
			this.sdText44.Size = new System.Drawing.Size(80, 96);
			this.sdText44.TabIndex = 45;
			this.sdText44.Tag = "0";
			this.sdText44.WordSpace = 0F;
			// 
			// sdText45
			// 
			this.sdText45.CharSpace = 0F;
			this.sdText45.FontColor = System.Drawing.Color.Black;
			this.sdText45.FontName = Report.SdFontName.Arial;
			this.sdText45.FontSize = 10F;
			this.sdText45.Leading = 12F;
			this.sdText45.Lines = new string[] {
												   "public class SDViewerPreference"};
			this.sdText45.Location = new System.Drawing.Point(104, 456);
			this.sdText45.Name = "sdText45";
			this.sdText45.NodeValue = null;
			this.sdText45.Size = new System.Drawing.Size(368, 24);
			this.sdText45.TabIndex = 44;
			this.sdText45.Tag = "0";
			this.sdText45.WordSpace = 0F;
			// 
			// sdText46
			// 
			this.sdText46.CharSpace = 0F;
			this.sdText46.FontColor = System.Drawing.Color.Black;
			this.sdText46.FontName = Report.SdFontName.TimesRoman;
			this.sdText46.FontSize = 10F;
			this.sdText46.Leading = 12F;
			this.sdText46.Lines = new string[] {
												   "Specifies the style when the document is opened."};
			this.sdText46.Location = new System.Drawing.Point(104, 432);
			this.sdText46.Name = "sdText46";
			this.sdText46.NodeValue = null;
			this.sdText46.Size = new System.Drawing.Size(368, 24);
			this.sdText46.TabIndex = 43;
			this.sdText46.Tag = "0";
			this.sdText46.WordSpace = 0F;
			// 
			// sdText47
			// 
			this.sdText47.CharSpace = 0F;
			this.sdText47.FontColor = System.Drawing.Color.Black;
			this.sdText47.FontName = Report.SdFontName.Arial;
			this.sdText47.FontSize = 10F;
			this.sdText47.Leading = 12F;
			this.sdText47.Lines = new string[] {
												   "public Report.SDViewerPreference ViewerPreference [  get]"};
			this.sdText47.Location = new System.Drawing.Point(104, 416);
			this.sdText47.Name = "sdText47";
			this.sdText47.NodeValue = null;
			this.sdText47.Size = new System.Drawing.Size(320, 16);
			this.sdText47.TabIndex = 42;
			this.sdText47.Tag = "0";
			this.sdText47.WordSpace = 0F;
			// 
			// sdText49
			// 
			this.sdText49.CharSpace = 0F;
			this.sdText49.FontColor = System.Drawing.Color.Black;
			this.sdText49.FontName = Report.SdFontName.TimesRoman;
			this.sdText49.FontSize = 10F;
			this.sdText49.Leading = 12F;
			this.sdText49.Lines = new string[] {
												   "UseOutline determine whether using outlines or not. This property can be set only" +
												   " before",
												   "BeginDoc() method called."};
			this.sdText49.Location = new System.Drawing.Point(104, 392);
			this.sdText49.Name = "sdText49";
			this.sdText49.NodeValue = null;
			this.sdText49.Size = new System.Drawing.Size(368, 24);
			this.sdText49.TabIndex = 40;
			this.sdText49.Tag = "0";
			this.sdText49.WordSpace = 0F;
			// 
			// sdText50
			// 
			this.sdText50.CharSpace = 0F;
			this.sdText50.FontColor = System.Drawing.Color.Black;
			this.sdText50.FontName = Report.SdFontName.Arial;
			this.sdText50.FontSize = 10F;
			this.sdText50.Leading = 12F;
			this.sdText50.Lines = new string[] {
												   "public bool UseOutlines [  get,  set ]"};
			this.sdText50.Location = new System.Drawing.Point(104, 376);
			this.sdText50.Name = "sdText50";
			this.sdText50.NodeValue = null;
			this.sdText50.Size = new System.Drawing.Size(320, 16);
			this.sdText50.TabIndex = 39;
			this.sdText50.Tag = "0";
			this.sdText50.WordSpace = 0F;
			// 
			// sdText52
			// 
			this.sdText52.CharSpace = 0F;
			this.sdText52.FontColor = System.Drawing.Color.Black;
			this.sdText52.FontName = Report.SdFontName.TimesRoman;
			this.sdText52.FontSize = 10F;
			this.sdText52.Leading = 12F;
			this.sdText52.Lines = new string[] {
												   "OutlineRoot returns the root of the outline-entries.",
												   "If UseOutline property set to false, OutlineRoot peoperty returns null."};
			this.sdText52.Location = new System.Drawing.Point(104, 352);
			this.sdText52.Name = "sdText52";
			this.sdText52.NodeValue = null;
			this.sdText52.Size = new System.Drawing.Size(368, 24);
			this.sdText52.TabIndex = 37;
			this.sdText52.Tag = "0";
			this.sdText52.WordSpace = 0F;
			// 
			// sdText53
			// 
			this.sdText53.CharSpace = 0F;
			this.sdText53.FontColor = System.Drawing.Color.Black;
			this.sdText53.FontName = Report.SdFontName.Arial;
			this.sdText53.FontSize = 10F;
			this.sdText53.Leading = 12F;
			this.sdText53.Lines = new string[] {
												   "public Report.SDOutlineRoot OutlineRoot [  get]"};
			this.sdText53.Location = new System.Drawing.Point(104, 336);
			this.sdText53.Name = "sdText53";
			this.sdText53.NodeValue = null;
			this.sdText53.Size = new System.Drawing.Size(320, 16);
			this.sdText53.TabIndex = 36;
			this.sdText53.Tag = "0";
			this.sdText53.WordSpace = 0F;
			// 
			// sdText55
			// 
			this.sdText55.CharSpace = 0F;
			this.sdText55.FontColor = System.Drawing.Color.Black;
			this.sdText55.FontName = Report.SdFontName.TimesRoman;
			this.sdText55.FontSize = 10F;
			this.sdText55.Leading = 12F;
			this.sdText55.Lines = new string[] {
												   "PageNumber contains the current page number being printed."};
			this.sdText55.Location = new System.Drawing.Point(104, 312);
			this.sdText55.Name = "sdText55";
			this.sdText55.NodeValue = null;
			this.sdText55.Size = new System.Drawing.Size(368, 24);
			this.sdText55.TabIndex = 34;
			this.sdText55.Tag = "0";
			this.sdText55.WordSpace = 0F;
			// 
			// sdText56
			// 
			this.sdText56.CharSpace = 0F;
			this.sdText56.FontColor = System.Drawing.Color.Black;
			this.sdText56.FontName = Report.SdFontName.Arial;
			this.sdText56.FontSize = 10F;
			this.sdText56.Leading = 12F;
			this.sdText56.Lines = new string[] {
												   "public int PageNumber [  get]"};
			this.sdText56.Location = new System.Drawing.Point(104, 296);
			this.sdText56.Name = "sdText56";
			this.sdText56.NodeValue = null;
			this.sdText56.Size = new System.Drawing.Size(320, 16);
			this.sdText56.TabIndex = 33;
			this.sdText56.Tag = "0";
			this.sdText56.WordSpace = 0F;
			// 
			// sdText58
			// 
			this.sdText58.CharSpace = 0F;
			this.sdText58.FontColor = System.Drawing.Color.Black;
			this.sdText58.FontName = Report.SdFontName.Arial;
			this.sdText58.FontSize = 10F;
			this.sdText58.Leading = 12F;
			this.sdText58.Lines = new string[] {
												   "public sealed enum SDPageLayout : System.Enum"};
			this.sdText58.Location = new System.Drawing.Point(104, 224);
			this.sdText58.Name = "sdText58";
			this.sdText58.NodeValue = null;
			this.sdText58.Size = new System.Drawing.Size(368, 24);
			this.sdText58.TabIndex = 31;
			this.sdText58.Tag = "0";
			this.sdText58.WordSpace = 0F;
			// 
			// sdText59
			// 
			this.sdText59.CharSpace = 0F;
			this.sdText59.FontColor = System.Drawing.Color.Black;
			this.sdText59.FontName = Report.SdFontName.TimesRoman;
			this.sdText59.FontSize = 10F;
			this.sdText59.Leading = 12F;
			this.sdText59.Lines = new string[] {
												   "Display the pages one page at a time.",
												   "Display the pages in one column.",
												   "Display the pages in two columns, with odd-numbered pages on the left.",
												   "Display the pages in two columns, with odd-numbered pages on the right."};
			this.sdText59.Location = new System.Drawing.Point(232, 248);
			this.sdText59.Name = "sdText59";
			this.sdText59.NodeValue = null;
			this.sdText59.Size = new System.Drawing.Size(312, 48);
			this.sdText59.TabIndex = 30;
			this.sdText59.Tag = "0";
			this.sdText59.WordSpace = 0F;
			// 
			// sdText60
			// 
			this.sdText60.CharSpace = 0F;
			this.sdText60.FontColor = System.Drawing.Color.Black;
			this.sdText60.FontName = Report.SdFontName.TimesRoman;
			this.sdText60.FontSize = 10F;
			this.sdText60.Leading = 12F;
			this.sdText60.Lines = new string[] {
												   "SinglePage",
												   "OneColumn",
												   "TwoColumnLeft",
												   "TwoColumnRight"};
			this.sdText60.Location = new System.Drawing.Point(152, 248);
			this.sdText60.Name = "sdText60";
			this.sdText60.NodeValue = null;
			this.sdText60.Size = new System.Drawing.Size(80, 48);
			this.sdText60.TabIndex = 29;
			this.sdText60.Tag = "0";
			this.sdText60.WordSpace = 0F;
			// 
			// sdText61
			// 
			this.sdText61.CharSpace = 0F;
			this.sdText61.FontColor = System.Drawing.Color.Black;
			this.sdText61.FontName = Report.SdFontName.TimesRoman;
			this.sdText61.FontSize = 10F;
			this.sdText61.Leading = 12F;
			this.sdText61.Lines = new string[] {
												   "PageLayout specifies the layout for the page when the document is opened."};
			this.sdText61.Location = new System.Drawing.Point(104, 200);
			this.sdText61.Name = "sdText61";
			this.sdText61.NodeValue = null;
			this.sdText61.Size = new System.Drawing.Size(368, 24);
			this.sdText61.TabIndex = 28;
			this.sdText61.Tag = "0";
			this.sdText61.WordSpace = 0F;
			// 
			// sdText62
			// 
			this.sdText62.CharSpace = 0F;
			this.sdText62.FontColor = System.Drawing.Color.Black;
			this.sdText62.FontName = Report.SdFontName.Arial;
			this.sdText62.FontSize = 10F;
			this.sdText62.Leading = 12F;
			this.sdText62.Lines = new string[] {
												   "public Report.SDPageLayout PageLayout [  get,  set ]"};
			this.sdText62.Location = new System.Drawing.Point(104, 184);
			this.sdText62.Name = "sdText62";
			this.sdText62.NodeValue = null;
			this.sdText62.Size = new System.Drawing.Size(320, 16);
			this.sdText62.TabIndex = 27;
			this.sdText62.Tag = "0";
			this.sdText62.WordSpace = 0F;
			// 
			// sdText64
			// 
			this.sdText64.CharSpace = 0F;
			this.sdText64.FontColor = System.Drawing.Color.Black;
			this.sdText64.FontName = Report.SdFontName.Arial;
			this.sdText64.FontSize = 10F;
			this.sdText64.Leading = 12F;
			this.sdText64.Lines = new string[] {
												   "public sealed enum SDPageMode : System.Enum"};
			this.sdText64.Location = new System.Drawing.Point(104, 112);
			this.sdText64.Name = "sdText64";
			this.sdText64.NodeValue = null;
			this.sdText64.Size = new System.Drawing.Size(368, 24);
			this.sdText64.TabIndex = 25;
			this.sdText64.Tag = "0";
			this.sdText64.WordSpace = 0F;
			// 
			// sdText65
			// 
			this.sdText65.CharSpace = 0F;
			this.sdText65.FontColor = System.Drawing.Color.Black;
			this.sdText65.FontName = Report.SdFontName.TimesRoman;
			this.sdText65.FontSize = 10F;
			this.sdText65.Leading = 12F;
			this.sdText65.Lines = new string[] {
												   "Both of outline and thumbnail images invisible",
												   "Document outline visible",
												   "Thumbnail images visible",
												   "Full-screen mode, with no menu bar."};
			this.sdText65.Location = new System.Drawing.Point(216, 136);
			this.sdText65.Name = "sdText65";
			this.sdText65.NodeValue = null;
			this.sdText65.Size = new System.Drawing.Size(256, 48);
			this.sdText65.TabIndex = 24;
			this.sdText65.Tag = "0";
			this.sdText65.WordSpace = 0F;
			// 
			// sdText66
			// 
			this.sdText66.CharSpace = 0F;
			this.sdText66.FontColor = System.Drawing.Color.Black;
			this.sdText66.FontName = Report.SdFontName.TimesRoman;
			this.sdText66.FontSize = 10F;
			this.sdText66.Leading = 12F;
			this.sdText66.Lines = new string[] {
												   "UseNone",
												   "UseOutlines",
												   "UseThumbs",
												   "FullScreen"};
			this.sdText66.Location = new System.Drawing.Point(152, 136);
			this.sdText66.Name = "sdText66";
			this.sdText66.NodeValue = null;
			this.sdText66.Size = new System.Drawing.Size(64, 48);
			this.sdText66.TabIndex = 23;
			this.sdText66.Tag = "0";
			this.sdText66.WordSpace = 0F;
			// 
			// sdText67
			// 
			this.sdText67.CharSpace = 0F;
			this.sdText67.FontColor = System.Drawing.Color.Black;
			this.sdText67.FontName = Report.SdFontName.TimesRoman;
			this.sdText67.FontSize = 10F;
			this.sdText67.Leading = 12F;
			this.sdText67.Lines = new string[] {
												   "PageMode property specifies how the document should be displayed when opened."};
			this.sdText67.Location = new System.Drawing.Point(104, 88);
			this.sdText67.Name = "sdText67";
			this.sdText67.NodeValue = null;
			this.sdText67.Size = new System.Drawing.Size(368, 24);
			this.sdText67.TabIndex = 22;
			this.sdText67.Tag = "0";
			this.sdText67.WordSpace = 0F;
			// 
			// sdText68
			// 
			this.sdText68.CharSpace = 0F;
			this.sdText68.FontColor = System.Drawing.Color.Black;
			this.sdText68.FontName = Report.SdFontName.Arial;
			this.sdText68.FontSize = 10F;
			this.sdText68.Leading = 12F;
			this.sdText68.Lines = new string[] {
												   "public Report.SDPageMode PageMode [  get,  set ]"};
			this.sdText68.Location = new System.Drawing.Point(104, 72);
			this.sdText68.Name = "sdText68";
			this.sdText68.NodeValue = null;
			this.sdText68.Size = new System.Drawing.Size(320, 16);
			this.sdText68.TabIndex = 21;
			this.sdText68.Tag = "0";
			this.sdText68.WordSpace = 0F;
			// 
			// sdLabel6
			// 
			this.sdLabel6.Alignment = Report.SDAlignment.RightJustify;
			this.sdLabel6.CharSpace = 0F;
			this.sdLabel6.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.sdLabel6.FontColor = System.Drawing.Color.Black;
			this.sdLabel6.FontName = Report.SdFontName.Arial;
			this.sdLabel6.FontSize = 8F;
			this.sdLabel6.Location = new System.Drawing.Point(0, 765);
			this.sdLabel6.Name = "sdLabel6";
			this.sdLabel6.Size = new System.Drawing.Size(532, 13);
			this.sdLabel6.TabIndex = 11;
			this.sdLabel6.Tag = "0";
			this.sdLabel6.Text = "copyright (c) 2002-2003 Serdar Dirican";
			this.sdLabel6.WordSpace = 0F;
			// 
			// sdRect15
			// 
			this.sdRect15.FillColor = System.Drawing.Color.Transparent;
			this.sdRect15.LineColor = System.Drawing.Color.Black;
			this.sdRect15.LineStyle = Report.PenStyle.Solid;
			this.sdRect15.LineWidth = 0F;
			this.sdRect15.Location = new System.Drawing.Point(256, 24);
			this.sdRect15.Name = "sdRect15";
			this.sdRect15.Size = new System.Drawing.Size(2, 24);
			this.sdRect15.TabIndex = 10;
			this.sdRect15.Tag = "0";
			this.sdRect15.Text = "sdRect4";
			// 
			// sdRect16
			// 
			this.sdRect16.FillColor = System.Drawing.Color.Transparent;
			this.sdRect16.LineColor = System.Drawing.Color.Black;
			this.sdRect16.LineStyle = Report.PenStyle.Solid;
			this.sdRect16.LineWidth = 0F;
			this.sdRect16.Location = new System.Drawing.Point(440, 24);
			this.sdRect16.Name = "sdRect16";
			this.sdRect16.Size = new System.Drawing.Size(2, 24);
			this.sdRect16.TabIndex = 9;
			this.sdRect16.Tag = "0";
			this.sdRect16.Text = "sdRect3";
			// 
			// sdRect17
			// 
			this.sdRect17.FillColor = System.Drawing.Color.Transparent;
			this.sdRect17.LineColor = System.Drawing.Color.Black;
			this.sdRect17.LineStyle = Report.PenStyle.Solid;
			this.sdRect17.LineWidth = 0F;
			this.sdRect17.Location = new System.Drawing.Point(80, 24);
			this.sdRect17.Name = "sdRect17";
			this.sdRect17.Size = new System.Drawing.Size(2, 24);
			this.sdRect17.TabIndex = 8;
			this.sdRect17.Tag = "0";
			this.sdRect17.Text = "sdRect2";
			// 
			// sdRect18
			// 
			this.sdRect18.DrawLine = true;
			this.sdRect18.FillColor = System.Drawing.Color.Transparent;
			this.sdRect18.LineColor = System.Drawing.Color.Black;
			this.sdRect18.LineStyle = Report.PenStyle.Solid;
			this.sdRect18.LineWidth = 2F;
			this.sdRect18.Location = new System.Drawing.Point(80, 40);
			this.sdRect18.Name = "sdRect18";
			this.sdRect18.Size = new System.Drawing.Size(360, 3);
			this.sdRect18.TabIndex = 7;
			this.sdRect18.Tag = "0";
			this.sdRect18.Text = "sdRect1";
			// 
			// tabPage6
			// 
			this.tabPage6.AutoScroll = true;
			this.tabPage6.Controls.Add(this.sdPage4);
			this.tabPage6.Location = new System.Drawing.Point(4, 58);
			this.tabPage6.Name = "tabPage6";
			this.tabPage6.Size = new System.Drawing.Size(472, 211);
			this.tabPage6.TabIndex = 5;
			this.tabPage6.Text = "SDReport(3)";
			// 
			// sdPage4
			// 
			this.sdPage4.Controls.Add(this.sdLayoutPanel6);
			this.sdPage4.DockPadding.All = 32;
			this.sdPage4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
			this.sdPage4.Location = new System.Drawing.Point(0, 0);
			this.sdPage4.Name = "sdPage4";
			this.sdPage4.Size = new System.Drawing.Size(596, 842);
			this.sdPage4.TabIndex = 1;
			this.sdPage4.Text = "sdPage4";
			// 
			// sdLayoutPanel6
			// 
			this.sdLayoutPanel6.BackColor = System.Drawing.SystemColors.Window;
			this.sdLayoutPanel6.Controls.Add(this.sdText70);
			this.sdLayoutPanel6.Controls.Add(this.sdText71);
			this.sdLayoutPanel6.Controls.Add(this.sdText73);
			this.sdLayoutPanel6.Controls.Add(this.sdText74);
			this.sdLayoutPanel6.Controls.Add(this.sdText76);
			this.sdLayoutPanel6.Controls.Add(this.sdText77);
			this.sdLayoutPanel6.Controls.Add(this.sdText79);
			this.sdLayoutPanel6.Controls.Add(this.sdText80);
			this.sdLayoutPanel6.Controls.Add(this.sdText82);
			this.sdLayoutPanel6.Controls.Add(this.sdText83);
			this.sdLayoutPanel6.Controls.Add(this.sdText84);
			this.sdLayoutPanel6.Controls.Add(this.sdLabel7);
			this.sdLayoutPanel6.Controls.Add(this.sdRect19);
			this.sdLayoutPanel6.Controls.Add(this.sdRect20);
			this.sdLayoutPanel6.Controls.Add(this.sdRect21);
			this.sdLayoutPanel6.Controls.Add(this.sdRect22);
			this.sdLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sdLayoutPanel6.Location = new System.Drawing.Point(32, 32);
			this.sdLayoutPanel6.Name = "sdLayoutPanel6";
			this.sdLayoutPanel6.Size = new System.Drawing.Size(532, 778);
			this.sdLayoutPanel6.TabIndex = 0;
			this.sdLayoutPanel6.Text = "sdLayoutPanel1";
			this.sdLayoutPanel6.BeforePrint += new Report.SDPrintPanelEvent(this.sdlayotupanel_BeforePrint);
			// 
			// sdText70
			// 
			this.sdText70.CharSpace = 0F;
			this.sdText70.FontColor = System.Drawing.Color.Black;
			this.sdText70.FontName = Report.SdFontName.TimesRoman;
			this.sdText70.FontSize = 10F;
			this.sdText70.Leading = 12F;
			this.sdText70.Lines = new string[] {
												   "OpenAction determins the location of the display window and zoom level when the f" +
												   "irst",
												   "page appears. If null, the top of the first page appears with default zoom level." +
												   ""};
			this.sdText70.Location = new System.Drawing.Point(112, 264);
			this.sdText70.Name = "sdText70";
			this.sdText70.NodeValue = null;
			this.sdText70.Size = new System.Drawing.Size(368, 32);
			this.sdText70.TabIndex = 35;
			this.sdText70.Tag = "0";
			this.sdText70.WordSpace = 0F;
			// 
			// sdText71
			// 
			this.sdText71.CharSpace = 0F;
			this.sdText71.FontColor = System.Drawing.Color.Black;
			this.sdText71.FontName = Report.SdFontName.Arial;
			this.sdText71.FontSize = 10F;
			this.sdText71.Leading = 12F;
			this.sdText71.Lines = new string[] {
												   "public void OpenAction ( Report.SDDestination Value )"};
			this.sdText71.Location = new System.Drawing.Point(112, 248);
			this.sdText71.Name = "sdText71";
			this.sdText71.NodeValue = null;
			this.sdText71.Size = new System.Drawing.Size(312, 16);
			this.sdText71.TabIndex = 34;
			this.sdText71.Tag = "0";
			this.sdText71.WordSpace = 0F;
			// 
			// sdText73
			// 
			this.sdText73.CharSpace = 0F;
			this.sdText73.FontColor = System.Drawing.Color.Black;
			this.sdText73.FontName = Report.SdFontName.TimesRoman;
			this.sdText73.FontSize = 10F;
			this.sdText73.Leading = 12F;
			this.sdText73.Lines = new string[] {
												   "Abort terminates the current print job, dropping all data."};
			this.sdText73.Location = new System.Drawing.Point(112, 224);
			this.sdText73.Name = "sdText73";
			this.sdText73.NodeValue = null;
			this.sdText73.Size = new System.Drawing.Size(368, 24);
			this.sdText73.TabIndex = 32;
			this.sdText73.Tag = "0";
			this.sdText73.WordSpace = 0F;
			// 
			// sdText74
			// 
			this.sdText74.CharSpace = 0F;
			this.sdText74.FontColor = System.Drawing.Color.Black;
			this.sdText74.FontName = Report.SdFontName.Arial;
			this.sdText74.FontSize = 10F;
			this.sdText74.Leading = 12F;
			this.sdText74.Lines = new string[] {
												   "public void Abort (  )"};
			this.sdText74.Location = new System.Drawing.Point(112, 208);
			this.sdText74.Name = "sdText74";
			this.sdText74.NodeValue = null;
			this.sdText74.Size = new System.Drawing.Size(312, 16);
			this.sdText74.TabIndex = 31;
			this.sdText74.Tag = "0";
			this.sdText74.WordSpace = 0F;
			// 
			// sdText76
			// 
			this.sdText76.CharSpace = 0F;
			this.sdText76.FontColor = System.Drawing.Color.Black;
			this.sdText76.FontName = Report.SdFontName.TimesRoman;
			this.sdText76.FontSize = 10F;
			this.sdText76.Leading = 12F;
			this.sdText76.Lines = new string[] {
												   "EndDoc ends the current print job and outputs PDF document to the file."};
			this.sdText76.Location = new System.Drawing.Point(112, 184);
			this.sdText76.Name = "sdText76";
			this.sdText76.NodeValue = null;
			this.sdText76.Size = new System.Drawing.Size(368, 24);
			this.sdText76.TabIndex = 29;
			this.sdText76.Tag = "0";
			this.sdText76.WordSpace = 0F;
			// 
			// sdText77
			// 
			this.sdText77.CharSpace = 0F;
			this.sdText77.FontColor = System.Drawing.Color.Black;
			this.sdText77.FontName = Report.SdFontName.Arial;
			this.sdText77.FontSize = 10F;
			this.sdText77.Leading = 12F;
			this.sdText77.Lines = new string[] {
												   "public void EndDoc (  )"};
			this.sdText77.Location = new System.Drawing.Point(112, 168);
			this.sdText77.Name = "sdText77";
			this.sdText77.NodeValue = null;
			this.sdText77.Size = new System.Drawing.Size(312, 16);
			this.sdText77.TabIndex = 28;
			this.sdText77.Tag = "0";
			this.sdText77.WordSpace = 0F;
			// 
			// sdText79
			// 
			this.sdText79.CharSpace = 0F;
			this.sdText79.FontColor = System.Drawing.Color.Black;
			this.sdText79.FontName = Report.SdFontName.TimesRoman;
			this.sdText79.FontSize = 10F;
			this.sdText79.Leading = 12F;
			this.sdText79.Lines = new string[] {
												   "Print add the page that specified APage parameter to the PDF document."};
			this.sdText79.Location = new System.Drawing.Point(112, 144);
			this.sdText79.Name = "sdText79";
			this.sdText79.NodeValue = null;
			this.sdText79.Size = new System.Drawing.Size(368, 24);
			this.sdText79.TabIndex = 26;
			this.sdText79.Tag = "0";
			this.sdText79.WordSpace = 0F;
			// 
			// sdText80
			// 
			this.sdText80.CharSpace = 0F;
			this.sdText80.FontColor = System.Drawing.Color.Black;
			this.sdText80.FontName = Report.SdFontName.Arial;
			this.sdText80.FontSize = 10F;
			this.sdText80.Leading = 12F;
			this.sdText80.Lines = new string[] {
												   "public void Print ( Report.SDPage APage )"};
			this.sdText80.Location = new System.Drawing.Point(112, 128);
			this.sdText80.Name = "sdText80";
			this.sdText80.NodeValue = null;
			this.sdText80.Size = new System.Drawing.Size(312, 16);
			this.sdText80.TabIndex = 25;
			this.sdText80.Tag = "0";
			this.sdText80.WordSpace = 0F;
			// 
			// sdText82
			// 
			this.sdText82.CharSpace = 0F;
			this.sdText82.FontBold = true;
			this.sdText82.FontColor = System.Drawing.Color.Black;
			this.sdText82.FontName = Report.SdFontName.Arial;
			this.sdText82.FontSize = 12F;
			this.sdText82.Leading = 14F;
			this.sdText82.Lines = new string[] {
												   "2.1.2      SDReport Methods"};
			this.sdText82.Location = new System.Drawing.Point(64, 72);
			this.sdText82.Name = "sdText82";
			this.sdText82.NodeValue = null;
			this.sdText82.Size = new System.Drawing.Size(360, 16);
			this.sdText82.TabIndex = 23;
			this.sdText82.Tag = "4";
			this.sdText82.WordSpace = 0F;
			// 
			// sdText83
			// 
			this.sdText83.CharSpace = 0F;
			this.sdText83.FontColor = System.Drawing.Color.Black;
			this.sdText83.FontName = Report.SdFontName.TimesRoman;
			this.sdText83.FontSize = 10F;
			this.sdText83.Leading = 12F;
			this.sdText83.Lines = new string[] {
												   "BeginDoc starts to create PDF document."};
			this.sdText83.Location = new System.Drawing.Point(112, 104);
			this.sdText83.Name = "sdText83";
			this.sdText83.NodeValue = null;
			this.sdText83.Size = new System.Drawing.Size(368, 24);
			this.sdText83.TabIndex = 22;
			this.sdText83.Tag = "0";
			this.sdText83.WordSpace = 0F;
			// 
			// sdText84
			// 
			this.sdText84.CharSpace = 0F;
			this.sdText84.FontColor = System.Drawing.Color.Black;
			this.sdText84.FontName = Report.SdFontName.Arial;
			this.sdText84.FontSize = 10F;
			this.sdText84.Leading = 12F;
			this.sdText84.Lines = new string[] {
												   "public void BeginDoc (  )"};
			this.sdText84.Location = new System.Drawing.Point(112, 88);
			this.sdText84.Name = "sdText84";
			this.sdText84.NodeValue = null;
			this.sdText84.Size = new System.Drawing.Size(312, 16);
			this.sdText84.TabIndex = 21;
			this.sdText84.Tag = "0";
			this.sdText84.WordSpace = 0F;
			// 
			// sdLabel7
			// 
			this.sdLabel7.Alignment = Report.SDAlignment.RightJustify;
			this.sdLabel7.CharSpace = 0F;
			this.sdLabel7.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.sdLabel7.FontColor = System.Drawing.Color.Black;
			this.sdLabel7.FontName = Report.SdFontName.Arial;
			this.sdLabel7.FontSize = 8F;
			this.sdLabel7.Location = new System.Drawing.Point(0, 765);
			this.sdLabel7.Name = "sdLabel7";
			this.sdLabel7.Size = new System.Drawing.Size(532, 13);
			this.sdLabel7.TabIndex = 11;
			this.sdLabel7.Tag = "0";
			this.sdLabel7.Text = "copyright (c) 2002-2003 Serdar Dirican";
			this.sdLabel7.WordSpace = 0F;
			// 
			// sdRect19
			// 
			this.sdRect19.FillColor = System.Drawing.Color.Transparent;
			this.sdRect19.LineColor = System.Drawing.Color.Black;
			this.sdRect19.LineStyle = Report.PenStyle.Solid;
			this.sdRect19.LineWidth = 0F;
			this.sdRect19.Location = new System.Drawing.Point(256, 24);
			this.sdRect19.Name = "sdRect19";
			this.sdRect19.Size = new System.Drawing.Size(2, 24);
			this.sdRect19.TabIndex = 10;
			this.sdRect19.Tag = "0";
			this.sdRect19.Text = "sdRect4";
			// 
			// sdRect20
			// 
			this.sdRect20.FillColor = System.Drawing.Color.Transparent;
			this.sdRect20.LineColor = System.Drawing.Color.Black;
			this.sdRect20.LineStyle = Report.PenStyle.Solid;
			this.sdRect20.LineWidth = 0F;
			this.sdRect20.Location = new System.Drawing.Point(440, 24);
			this.sdRect20.Name = "sdRect20";
			this.sdRect20.Size = new System.Drawing.Size(2, 24);
			this.sdRect20.TabIndex = 9;
			this.sdRect20.Tag = "0";
			this.sdRect20.Text = "sdRect3";
			// 
			// sdRect21
			// 
			this.sdRect21.FillColor = System.Drawing.Color.Transparent;
			this.sdRect21.LineColor = System.Drawing.Color.Black;
			this.sdRect21.LineStyle = Report.PenStyle.Solid;
			this.sdRect21.LineWidth = 0F;
			this.sdRect21.Location = new System.Drawing.Point(80, 24);
			this.sdRect21.Name = "sdRect21";
			this.sdRect21.Size = new System.Drawing.Size(2, 24);
			this.sdRect21.TabIndex = 8;
			this.sdRect21.Tag = "0";
			this.sdRect21.Text = "sdRect2";
			// 
			// sdRect22
			// 
			this.sdRect22.DrawLine = true;
			this.sdRect22.FillColor = System.Drawing.Color.Transparent;
			this.sdRect22.LineColor = System.Drawing.Color.Black;
			this.sdRect22.LineStyle = Report.PenStyle.Solid;
			this.sdRect22.LineWidth = 2F;
			this.sdRect22.Location = new System.Drawing.Point(80, 40);
			this.sdRect22.Name = "sdRect22";
			this.sdRect22.Size = new System.Drawing.Size(360, 3);
			this.sdRect22.TabIndex = 7;
			this.sdRect22.Tag = "0";
			this.sdRect22.Text = "sdRect1";
			// 
			// tabPage7
			// 
			this.tabPage7.AutoScroll = true;
			this.tabPage7.Controls.Add(this.sdPage5);
			this.tabPage7.Location = new System.Drawing.Point(4, 58);
			this.tabPage7.Name = "tabPage7";
			this.tabPage7.Size = new System.Drawing.Size(472, 211);
			this.tabPage7.TabIndex = 6;
			this.tabPage7.Text = "SDPage";
			// 
			// sdPage5
			// 
			this.sdPage5.Controls.Add(this.sdLayoutPanel7);
			this.sdPage5.DockPadding.All = 32;
			this.sdPage5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
			this.sdPage5.Location = new System.Drawing.Point(0, 0);
			this.sdPage5.Name = "sdPage5";
			this.sdPage5.Size = new System.Drawing.Size(596, 842);
			this.sdPage5.TabIndex = 1;
			this.sdPage5.Text = "sdPage5";
			// 
			// sdLayoutPanel7
			// 
			this.sdLayoutPanel7.BackColor = System.Drawing.SystemColors.Window;
			this.sdLayoutPanel7.Controls.Add(this.sdText16);
			this.sdLayoutPanel7.Controls.Add(this.sdText19);
			this.sdLayoutPanel7.Controls.Add(this.sdText22);
			this.sdLayoutPanel7.Controls.Add(this.sdText25);
			this.sdLayoutPanel7.Controls.Add(this.sdText28);
			this.sdLayoutPanel7.Controls.Add(this.sdText31);
			this.sdLayoutPanel7.Controls.Add(this.sdText32);
			this.sdLayoutPanel7.Controls.Add(this.sdText35);
			this.sdLayoutPanel7.Controls.Add(this.sdText48);
			this.sdLayoutPanel7.Controls.Add(this.sdText51);
			this.sdLayoutPanel7.Controls.Add(this.sdText54);
			this.sdLayoutPanel7.Controls.Add(this.sdText57);
			this.sdLayoutPanel7.Controls.Add(this.sdText63);
			this.sdLayoutPanel7.Controls.Add(this.sdText69);
			this.sdLayoutPanel7.Controls.Add(this.sdText72);
			this.sdLayoutPanel7.Controls.Add(this.sdText75);
			this.sdLayoutPanel7.Controls.Add(this.sdText78);
			this.sdLayoutPanel7.Controls.Add(this.sdText81);
			this.sdLayoutPanel7.Controls.Add(this.sdText85);
			this.sdLayoutPanel7.Controls.Add(this.sdText86);
			this.sdLayoutPanel7.Controls.Add(this.sdText87);
			this.sdLayoutPanel7.Controls.Add(this.sdText88);
			this.sdLayoutPanel7.Controls.Add(this.sdLabel8);
			this.sdLayoutPanel7.Controls.Add(this.sdRect23);
			this.sdLayoutPanel7.Controls.Add(this.sdRect24);
			this.sdLayoutPanel7.Controls.Add(this.sdRect25);
			this.sdLayoutPanel7.Controls.Add(this.sdRect26);
			this.sdLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sdLayoutPanel7.Location = new System.Drawing.Point(32, 32);
			this.sdLayoutPanel7.Name = "sdLayoutPanel7";
			this.sdLayoutPanel7.Size = new System.Drawing.Size(532, 778);
			this.sdLayoutPanel7.TabIndex = 0;
			this.sdLayoutPanel7.Text = "sdLayoutPanel1";
			this.sdLayoutPanel7.BeforePrint += new Report.SDPrintPanelEvent(this.sdlayotupanel_BeforePrint);
			// 
			// sdText16
			// 
			this.sdText16.CharSpace = 0F;
			this.sdText16.FontColor = System.Drawing.Color.Black;
			this.sdText16.FontName = Report.SdFontName.TimesRoman;
			this.sdText16.FontSize = 10F;
			this.sdText16.Leading = 12F;
			this.sdText16.Lines = new string[] {
												   "OnPrintPage is called when a page is printed. You can use it to initialize any lo" +
												   "cal",
												   "variables."};
			this.sdText16.Location = new System.Drawing.Point(112, 568);
			this.sdText16.Name = "sdText16";
			this.sdText16.NodeValue = null;
			this.sdText16.Size = new System.Drawing.Size(368, 24);
			this.sdText16.TabIndex = 45;
			this.sdText16.Tag = "0";
			this.sdText16.WordSpace = 0F;
			// 
			// sdText19
			// 
			this.sdText19.CharSpace = 0F;
			this.sdText19.FontColor = System.Drawing.Color.Black;
			this.sdText19.FontName = Report.SdFontName.Arial;
			this.sdText19.FontSize = 10F;
			this.sdText19.Leading = 12F;
			this.sdText19.Lines = new string[] {
												   "public event Report.SDPrintPageEvent PrintPage"};
			this.sdText19.Location = new System.Drawing.Point(112, 552);
			this.sdText19.Name = "sdText19";
			this.sdText19.NodeValue = null;
			this.sdText19.Size = new System.Drawing.Size(320, 16);
			this.sdText19.TabIndex = 44;
			this.sdText19.Tag = "0";
			this.sdText19.WordSpace = 0F;
			// 
			// sdText22
			// 
			this.sdText22.CharSpace = 0F;
			this.sdText22.FontBold = true;
			this.sdText22.FontColor = System.Drawing.Color.Black;
			this.sdText22.FontName = Report.SdFontName.Arial;
			this.sdText22.FontSize = 12F;
			this.sdText22.Leading = 14F;
			this.sdText22.Lines = new string[] {
												   "2.2.2      SDPage Events"};
			this.sdText22.Location = new System.Drawing.Point(64, 536);
			this.sdText22.Name = "sdText22";
			this.sdText22.NodeValue = null;
			this.sdText22.Size = new System.Drawing.Size(360, 16);
			this.sdText22.TabIndex = 43;
			this.sdText22.Tag = "4";
			this.sdText22.WordSpace = 0F;
			// 
			// sdText25
			// 
			this.sdText25.CharSpace = 0F;
			this.sdText25.FontColor = System.Drawing.Color.Black;
			this.sdText25.FontName = Report.SdFontName.TimesRoman;
			this.sdText25.FontSize = 10F;
			this.sdText25.Leading = 12F;
			this.sdText25.Lines = new string[] {
												   "Set Width to specify the width of the page."};
			this.sdText25.Location = new System.Drawing.Point(112, 472);
			this.sdText25.Name = "sdText25";
			this.sdText25.NodeValue = null;
			this.sdText25.Size = new System.Drawing.Size(368, 24);
			this.sdText25.TabIndex = 42;
			this.sdText25.Tag = "0";
			this.sdText25.WordSpace = 0F;
			// 
			// sdText28
			// 
			this.sdText28.CharSpace = 0F;
			this.sdText28.FontColor = System.Drawing.Color.Black;
			this.sdText28.FontName = Report.SdFontName.Arial;
			this.sdText28.FontSize = 10F;
			this.sdText28.Leading = 12F;
			this.sdText28.Lines = new string[] {
												   "public int Width [  get,  set ]"};
			this.sdText28.Location = new System.Drawing.Point(112, 456);
			this.sdText28.Name = "sdText28";
			this.sdText28.NodeValue = null;
			this.sdText28.Size = new System.Drawing.Size(320, 16);
			this.sdText28.TabIndex = 41;
			this.sdText28.Tag = "0";
			this.sdText28.WordSpace = 0F;
			// 
			// sdText31
			// 
			this.sdText31.CharSpace = 0F;
			this.sdText31.FontColor = System.Drawing.Color.Black;
			this.sdText31.FontName = Report.SdFontName.TimesRoman;
			this.sdText31.FontSize = 10F;
			this.sdText31.Leading = 12F;
			this.sdText31.Lines = new string[] {
												   "Set Height to specify the height of the page."};
			this.sdText31.Location = new System.Drawing.Point(112, 432);
			this.sdText31.Name = "sdText31";
			this.sdText31.NodeValue = null;
			this.sdText31.Size = new System.Drawing.Size(368, 24);
			this.sdText31.TabIndex = 40;
			this.sdText31.Tag = "0";
			this.sdText31.WordSpace = 0F;
			// 
			// sdText32
			// 
			this.sdText32.CharSpace = 0F;
			this.sdText32.FontColor = System.Drawing.Color.Black;
			this.sdText32.FontName = Report.SdFontName.Arial;
			this.sdText32.FontSize = 10F;
			this.sdText32.Leading = 12F;
			this.sdText32.Lines = new string[] {
												   "public int Height [  get,  set ]"};
			this.sdText32.Location = new System.Drawing.Point(112, 416);
			this.sdText32.Name = "sdText32";
			this.sdText32.NodeValue = null;
			this.sdText32.Size = new System.Drawing.Size(320, 16);
			this.sdText32.TabIndex = 39;
			this.sdText32.Tag = "0";
			this.sdText32.WordSpace = 0F;
			// 
			// sdText35
			// 
			this.sdText35.CharSpace = 0F;
			this.sdText35.FontColor = System.Drawing.Color.Black;
			this.sdText35.FontName = Report.SdFontName.TimesRoman;
			this.sdText35.FontSize = 10F;
			this.sdText35.Leading = 12F;
			this.sdText35.Lines = new string[] {
												   "Gets or sets the padding width for the top edge of a SDPage."};
			this.sdText35.Location = new System.Drawing.Point(112, 392);
			this.sdText35.Name = "sdText35";
			this.sdText35.NodeValue = null;
			this.sdText35.Size = new System.Drawing.Size(368, 24);
			this.sdText35.TabIndex = 38;
			this.sdText35.Tag = "0";
			this.sdText35.WordSpace = 0F;
			// 
			// sdText48
			// 
			this.sdText48.CharSpace = 0F;
			this.sdText48.FontColor = System.Drawing.Color.Black;
			this.sdText48.FontName = Report.SdFontName.Arial;
			this.sdText48.FontSize = 10F;
			this.sdText48.Leading = 12F;
			this.sdText48.Lines = new string[] {
												   "public int DockPadding.Top"};
			this.sdText48.Location = new System.Drawing.Point(112, 376);
			this.sdText48.Name = "sdText48";
			this.sdText48.NodeValue = null;
			this.sdText48.Size = new System.Drawing.Size(320, 16);
			this.sdText48.TabIndex = 37;
			this.sdText48.Tag = "0";
			this.sdText48.WordSpace = 0F;
			// 
			// sdText51
			// 
			this.sdText51.CharSpace = 0F;
			this.sdText51.FontColor = System.Drawing.Color.Black;
			this.sdText51.FontName = Report.SdFontName.TimesRoman;
			this.sdText51.FontSize = 10F;
			this.sdText51.Leading = 12F;
			this.sdText51.Lines = new string[] {
												   "Gets or sets the padding width for the right edge of a SDPage."};
			this.sdText51.Location = new System.Drawing.Point(112, 352);
			this.sdText51.Name = "sdText51";
			this.sdText51.NodeValue = null;
			this.sdText51.Size = new System.Drawing.Size(368, 24);
			this.sdText51.TabIndex = 36;
			this.sdText51.Tag = "0";
			this.sdText51.WordSpace = 0F;
			// 
			// sdText54
			// 
			this.sdText54.CharSpace = 0F;
			this.sdText54.FontColor = System.Drawing.Color.Black;
			this.sdText54.FontName = Report.SdFontName.Arial;
			this.sdText54.FontSize = 10F;
			this.sdText54.Leading = 12F;
			this.sdText54.Lines = new string[] {
												   "public int DockPadding.Right"};
			this.sdText54.Location = new System.Drawing.Point(112, 336);
			this.sdText54.Name = "sdText54";
			this.sdText54.NodeValue = null;
			this.sdText54.Size = new System.Drawing.Size(320, 16);
			this.sdText54.TabIndex = 35;
			this.sdText54.Tag = "0";
			this.sdText54.WordSpace = 0F;
			// 
			// sdText57
			// 
			this.sdText57.CharSpace = 0F;
			this.sdText57.FontColor = System.Drawing.Color.Black;
			this.sdText57.FontName = Report.SdFontName.TimesRoman;
			this.sdText57.FontSize = 10F;
			this.sdText57.Leading = 12F;
			this.sdText57.Lines = new string[] {
												   "Gets or sets the padding width for the left edge of a SDPage."};
			this.sdText57.Location = new System.Drawing.Point(112, 312);
			this.sdText57.Name = "sdText57";
			this.sdText57.NodeValue = null;
			this.sdText57.Size = new System.Drawing.Size(368, 24);
			this.sdText57.TabIndex = 34;
			this.sdText57.Tag = "0";
			this.sdText57.WordSpace = 0F;
			// 
			// sdText63
			// 
			this.sdText63.CharSpace = 0F;
			this.sdText63.FontColor = System.Drawing.Color.Black;
			this.sdText63.FontName = Report.SdFontName.Arial;
			this.sdText63.FontSize = 10F;
			this.sdText63.Leading = 12F;
			this.sdText63.Lines = new string[] {
												   "public int DockPadding.Left"};
			this.sdText63.Location = new System.Drawing.Point(112, 296);
			this.sdText63.Name = "sdText63";
			this.sdText63.NodeValue = null;
			this.sdText63.Size = new System.Drawing.Size(320, 16);
			this.sdText63.TabIndex = 33;
			this.sdText63.Tag = "0";
			this.sdText63.WordSpace = 0F;
			// 
			// sdText69
			// 
			this.sdText69.CharSpace = 0F;
			this.sdText69.FontColor = System.Drawing.Color.Black;
			this.sdText69.FontName = Report.SdFontName.TimesRoman;
			this.sdText69.FontSize = 10F;
			this.sdText69.Leading = 12F;
			this.sdText69.Lines = new string[] {
												   "Gets or sets the padding width for the bottom edge of a SDPage."};
			this.sdText69.Location = new System.Drawing.Point(112, 272);
			this.sdText69.Name = "sdText69";
			this.sdText69.NodeValue = null;
			this.sdText69.Size = new System.Drawing.Size(368, 24);
			this.sdText69.TabIndex = 32;
			this.sdText69.Tag = "0";
			this.sdText69.WordSpace = 0F;
			// 
			// sdText72
			// 
			this.sdText72.CharSpace = 0F;
			this.sdText72.FontColor = System.Drawing.Color.Black;
			this.sdText72.FontName = Report.SdFontName.Arial;
			this.sdText72.FontSize = 10F;
			this.sdText72.Leading = 12F;
			this.sdText72.Lines = new string[] {
												   "public int DockPadding.Bottom"};
			this.sdText72.Location = new System.Drawing.Point(112, 256);
			this.sdText72.Name = "sdText72";
			this.sdText72.NodeValue = null;
			this.sdText72.Size = new System.Drawing.Size(320, 16);
			this.sdText72.TabIndex = 31;
			this.sdText72.Tag = "0";
			this.sdText72.WordSpace = 0F;
			// 
			// sdText75
			// 
			this.sdText75.CharSpace = 0F;
			this.sdText75.FontColor = System.Drawing.Color.Black;
			this.sdText75.FontName = Report.SdFontName.TimesRoman;
			this.sdText75.FontSize = 10F;
			this.sdText75.Leading = 12F;
			this.sdText75.Lines = new string[] {
												   "Gets or sets the padding width for all edges of a SDPage."};
			this.sdText75.Location = new System.Drawing.Point(112, 232);
			this.sdText75.Name = "sdText75";
			this.sdText75.NodeValue = null;
			this.sdText75.Size = new System.Drawing.Size(368, 24);
			this.sdText75.TabIndex = 30;
			this.sdText75.Tag = "0";
			this.sdText75.WordSpace = 0F;
			// 
			// sdText78
			// 
			this.sdText78.CharSpace = 0F;
			this.sdText78.FontColor = System.Drawing.Color.Black;
			this.sdText78.FontName = Report.SdFontName.Arial;
			this.sdText78.FontSize = 10F;
			this.sdText78.Leading = 12F;
			this.sdText78.Lines = new string[] {
												   "public int DockPadding.All"};
			this.sdText78.Location = new System.Drawing.Point(112, 216);
			this.sdText78.Name = "sdText78";
			this.sdText78.NodeValue = null;
			this.sdText78.Size = new System.Drawing.Size(320, 16);
			this.sdText78.TabIndex = 29;
			this.sdText78.Tag = "0";
			this.sdText78.WordSpace = 0F;
			// 
			// sdText81
			// 
			this.sdText81.CharSpace = 0F;
			this.sdText81.FontBold = true;
			this.sdText81.FontColor = System.Drawing.Color.Black;
			this.sdText81.FontName = Report.SdFontName.Arial;
			this.sdText81.FontSize = 12F;
			this.sdText81.Leading = 14F;
			this.sdText81.Lines = new string[] {
												   "2.2.1      SDPage properties"};
			this.sdText81.Location = new System.Drawing.Point(64, 200);
			this.sdText81.Name = "sdText81";
			this.sdText81.NodeValue = null;
			this.sdText81.Size = new System.Drawing.Size(360, 16);
			this.sdText81.TabIndex = 27;
			this.sdText81.Tag = "4";
			this.sdText81.WordSpace = 0F;
			// 
			// sdText85
			// 
			this.sdText85.CharSpace = 0F;
			this.sdText85.FontColor = System.Drawing.Color.Black;
			this.sdText85.FontName = Report.SdFontName.TimesRoman;
			this.sdText85.FontSize = 10F;
			this.sdText85.Leading = 12F;
			this.sdText85.Lines = new string[] {
												   "Use SDPage to create a page to print. To create a page, To print a page, call pri" +
												   "nt method",
												   "of SDReport with SDPage object.",
												   "Use Width and Height property to determine the physical size of the page."};
			this.sdText85.Location = new System.Drawing.Point(112, 120);
			this.sdText85.Name = "sdText85";
			this.sdText85.NodeValue = null;
			this.sdText85.Size = new System.Drawing.Size(368, 40);
			this.sdText85.TabIndex = 26;
			this.sdText85.Tag = "0";
			this.sdText85.WordSpace = 0F;
			// 
			// sdText86
			// 
			this.sdText86.CharSpace = 0F;
			this.sdText86.FontBold = true;
			this.sdText86.FontColor = System.Drawing.Color.Black;
			this.sdText86.FontName = Report.SdFontName.Arial;
			this.sdText86.FontSize = 12F;
			this.sdText86.Leading = 14F;
			this.sdText86.Lines = new string[] {
												   "Description"};
			this.sdText86.Location = new System.Drawing.Point(112, 104);
			this.sdText86.Name = "sdText86";
			this.sdText86.NodeValue = null;
			this.sdText86.Size = new System.Drawing.Size(328, 16);
			this.sdText86.TabIndex = 25;
			this.sdText86.Tag = "0";
			this.sdText86.WordSpace = 0F;
			// 
			// sdText87
			// 
			this.sdText87.CharSpace = 0F;
			this.sdText87.FontColor = System.Drawing.Color.Black;
			this.sdText87.FontName = Report.SdFontName.TimesRoman;
			this.sdText87.FontSize = 10F;
			this.sdText87.Leading = 12F;
			this.sdText87.Lines = new string[] {
												   "SDPage represents a page to print."};
			this.sdText87.Location = new System.Drawing.Point(112, 80);
			this.sdText87.Name = "sdText87";
			this.sdText87.NodeValue = null;
			this.sdText87.Size = new System.Drawing.Size(328, 24);
			this.sdText87.TabIndex = 24;
			this.sdText87.Tag = "0";
			this.sdText87.WordSpace = 0F;
			// 
			// sdText88
			// 
			this.sdText88.CharSpace = 0F;
			this.sdText88.FontBold = true;
			this.sdText88.FontColor = System.Drawing.Color.Black;
			this.sdText88.FontName = Report.SdFontName.Arial;
			this.sdText88.FontSize = 12F;
			this.sdText88.Leading = 14F;
			this.sdText88.Lines = new string[] {
												   "2.2         SDPage"};
			this.sdText88.Location = new System.Drawing.Point(64, 64);
			this.sdText88.Name = "sdText88";
			this.sdText88.NodeValue = null;
			this.sdText88.Size = new System.Drawing.Size(360, 16);
			this.sdText88.TabIndex = 23;
			this.sdText88.Tag = "3";
			this.sdText88.WordSpace = 0F;
			// 
			// sdLabel8
			// 
			this.sdLabel8.Alignment = Report.SDAlignment.RightJustify;
			this.sdLabel8.CharSpace = 0F;
			this.sdLabel8.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.sdLabel8.FontColor = System.Drawing.Color.Black;
			this.sdLabel8.FontName = Report.SdFontName.Arial;
			this.sdLabel8.FontSize = 8F;
			this.sdLabel8.Location = new System.Drawing.Point(0, 765);
			this.sdLabel8.Name = "sdLabel8";
			this.sdLabel8.Size = new System.Drawing.Size(532, 13);
			this.sdLabel8.TabIndex = 11;
			this.sdLabel8.Tag = "0";
			this.sdLabel8.Text = "copyright (c) 2002-2003 Serdar Dirican";
			this.sdLabel8.WordSpace = 0F;
			// 
			// sdRect23
			// 
			this.sdRect23.FillColor = System.Drawing.Color.Transparent;
			this.sdRect23.LineColor = System.Drawing.Color.Black;
			this.sdRect23.LineStyle = Report.PenStyle.Solid;
			this.sdRect23.LineWidth = 0F;
			this.sdRect23.Location = new System.Drawing.Point(256, 24);
			this.sdRect23.Name = "sdRect23";
			this.sdRect23.Size = new System.Drawing.Size(2, 24);
			this.sdRect23.TabIndex = 10;
			this.sdRect23.Tag = "0";
			this.sdRect23.Text = "sdRect4";
			// 
			// sdRect24
			// 
			this.sdRect24.FillColor = System.Drawing.Color.Transparent;
			this.sdRect24.LineColor = System.Drawing.Color.Black;
			this.sdRect24.LineStyle = Report.PenStyle.Solid;
			this.sdRect24.LineWidth = 0F;
			this.sdRect24.Location = new System.Drawing.Point(440, 24);
			this.sdRect24.Name = "sdRect24";
			this.sdRect24.Size = new System.Drawing.Size(2, 24);
			this.sdRect24.TabIndex = 9;
			this.sdRect24.Tag = "0";
			this.sdRect24.Text = "sdRect3";
			// 
			// sdRect25
			// 
			this.sdRect25.FillColor = System.Drawing.Color.Transparent;
			this.sdRect25.LineColor = System.Drawing.Color.Black;
			this.sdRect25.LineStyle = Report.PenStyle.Solid;
			this.sdRect25.LineWidth = 0F;
			this.sdRect25.Location = new System.Drawing.Point(80, 24);
			this.sdRect25.Name = "sdRect25";
			this.sdRect25.Size = new System.Drawing.Size(2, 24);
			this.sdRect25.TabIndex = 8;
			this.sdRect25.Tag = "0";
			this.sdRect25.Text = "sdRect2";
			// 
			// sdRect26
			// 
			this.sdRect26.DrawLine = true;
			this.sdRect26.FillColor = System.Drawing.Color.Transparent;
			this.sdRect26.LineColor = System.Drawing.Color.Black;
			this.sdRect26.LineStyle = Report.PenStyle.Solid;
			this.sdRect26.LineWidth = 2F;
			this.sdRect26.Location = new System.Drawing.Point(80, 40);
			this.sdRect26.Name = "sdRect26";
			this.sdRect26.Size = new System.Drawing.Size(360, 3);
			this.sdRect26.TabIndex = 7;
			this.sdRect26.Tag = "0";
			this.sdRect26.Text = "sdRect1";
			// 
			// tabPage8
			// 
			this.tabPage8.AutoScroll = true;
			this.tabPage8.Controls.Add(this.sdPage6);
			this.tabPage8.Location = new System.Drawing.Point(4, 58);
			this.tabPage8.Name = "tabPage8";
			this.tabPage8.Size = new System.Drawing.Size(472, 211);
			this.tabPage8.TabIndex = 7;
			this.tabPage8.Text = "SDLayoutPanel";
			// 
			// sdPage6
			// 
			this.sdPage6.Controls.Add(this.sdLayoutPanel8);
			this.sdPage6.DockPadding.All = 32;
			this.sdPage6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
			this.sdPage6.Location = new System.Drawing.Point(0, 0);
			this.sdPage6.Name = "sdPage6";
			this.sdPage6.Size = new System.Drawing.Size(596, 842);
			this.sdPage6.TabIndex = 1;
			this.sdPage6.Text = "sdPage6";
			// 
			// sdLayoutPanel8
			// 
			this.sdLayoutPanel8.BackColor = System.Drawing.SystemColors.Window;
			this.sdLayoutPanel8.Controls.Add(this.sdText89);
			this.sdLayoutPanel8.Controls.Add(this.sdText90);
			this.sdLayoutPanel8.Controls.Add(this.sdText91);
			this.sdLayoutPanel8.Controls.Add(this.sdText92);
			this.sdLayoutPanel8.Controls.Add(this.sdText93);
			this.sdLayoutPanel8.Controls.Add(this.sdText94);
			this.sdLayoutPanel8.Controls.Add(this.sdText95);
			this.sdLayoutPanel8.Controls.Add(this.sdText96);
			this.sdLayoutPanel8.Controls.Add(this.sdText97);
			this.sdLayoutPanel8.Controls.Add(this.sdText98);
			this.sdLayoutPanel8.Controls.Add(this.sdText99);
			this.sdLayoutPanel8.Controls.Add(this.sdText100);
			this.sdLayoutPanel8.Controls.Add(this.sdLabel9);
			this.sdLayoutPanel8.Controls.Add(this.sdRect27);
			this.sdLayoutPanel8.Controls.Add(this.sdRect28);
			this.sdLayoutPanel8.Controls.Add(this.sdRect29);
			this.sdLayoutPanel8.Controls.Add(this.sdRect30);
			this.sdLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sdLayoutPanel8.Location = new System.Drawing.Point(32, 32);
			this.sdLayoutPanel8.Name = "sdLayoutPanel8";
			this.sdLayoutPanel8.Size = new System.Drawing.Size(532, 778);
			this.sdLayoutPanel8.TabIndex = 0;
			this.sdLayoutPanel8.Text = "sdLayoutPanel1";
			this.sdLayoutPanel8.BeforePrint += new Report.SDPrintPanelEvent(this.sdlayotupanel_BeforePrint);
			// 
			// sdText89
			// 
			this.sdText89.CharSpace = 0F;
			this.sdText89.FontColor = System.Drawing.Color.Black;
			this.sdText89.FontName = Report.SdFontName.TimesRoman;
			this.sdText89.FontSize = 10F;
			this.sdText89.Leading = 12F;
			this.sdText89.Lines = new string[] {
												   "AfterPrint is called after a page was printed."};
			this.sdText89.Location = new System.Drawing.Point(112, 368);
			this.sdText89.Name = "sdText89";
			this.sdText89.NodeValue = null;
			this.sdText89.Size = new System.Drawing.Size(368, 24);
			this.sdText89.TabIndex = 47;
			this.sdText89.Tag = "0";
			this.sdText89.WordSpace = 0F;
			// 
			// sdText90
			// 
			this.sdText90.CharSpace = 0F;
			this.sdText90.FontColor = System.Drawing.Color.Black;
			this.sdText90.FontName = Report.SdFontName.Arial;
			this.sdText90.FontSize = 10F;
			this.sdText90.Leading = 12F;
			this.sdText90.Lines = new string[] {
												   "public event Report.SDPrintPanelEvent AfterPrint"};
			this.sdText90.Location = new System.Drawing.Point(112, 352);
			this.sdText90.Name = "sdText90";
			this.sdText90.NodeValue = null;
			this.sdText90.Size = new System.Drawing.Size(320, 16);
			this.sdText90.TabIndex = 46;
			this.sdText90.Tag = "0";
			this.sdText90.WordSpace = 0F;
			// 
			// sdText91
			// 
			this.sdText91.CharSpace = 0F;
			this.sdText91.FontColor = System.Drawing.Color.Black;
			this.sdText91.FontName = Report.SdFontName.TimesRoman;
			this.sdText91.FontSize = 10F;
			this.sdText91.Leading = 12F;
			this.sdText91.Lines = new string[] {
												   "BeforePrint is called before a page is about to be printed. Typical use of this e" +
												   "vent",
												   "is to set any variables(SDText, SDImage)."};
			this.sdText91.Location = new System.Drawing.Point(112, 328);
			this.sdText91.Name = "sdText91";
			this.sdText91.NodeValue = null;
			this.sdText91.Size = new System.Drawing.Size(368, 24);
			this.sdText91.TabIndex = 45;
			this.sdText91.Tag = "0";
			this.sdText91.WordSpace = 0F;
			// 
			// sdText92
			// 
			this.sdText92.CharSpace = 0F;
			this.sdText92.FontColor = System.Drawing.Color.Black;
			this.sdText92.FontName = Report.SdFontName.Arial;
			this.sdText92.FontSize = 10F;
			this.sdText92.Leading = 12F;
			this.sdText92.Lines = new string[] {
												   "public event Report.SDPrintPanelEvent BeforePrint"};
			this.sdText92.Location = new System.Drawing.Point(112, 312);
			this.sdText92.Name = "sdText92";
			this.sdText92.NodeValue = null;
			this.sdText92.Size = new System.Drawing.Size(320, 16);
			this.sdText92.TabIndex = 44;
			this.sdText92.Tag = "0";
			this.sdText92.WordSpace = 0F;
			// 
			// sdText93
			// 
			this.sdText93.CharSpace = 0F;
			this.sdText93.FontBold = true;
			this.sdText93.FontColor = System.Drawing.Color.Black;
			this.sdText93.FontName = Report.SdFontName.Arial;
			this.sdText93.FontSize = 12F;
			this.sdText93.Leading = 14F;
			this.sdText93.Lines = new string[] {
												   "2.3.2      SDLayoutPanel Events"};
			this.sdText93.Location = new System.Drawing.Point(64, 296);
			this.sdText93.Name = "sdText93";
			this.sdText93.NodeValue = null;
			this.sdText93.Size = new System.Drawing.Size(360, 16);
			this.sdText93.TabIndex = 43;
			this.sdText93.Tag = "4";
			this.sdText93.WordSpace = 0F;
			// 
			// sdText94
			// 
			this.sdText94.CharSpace = 0F;
			this.sdText94.FontColor = System.Drawing.Color.Black;
			this.sdText94.FontName = Report.SdFontName.TimesRoman;
			this.sdText94.FontSize = 10F;
			this.sdText94.Leading = 12F;
			this.sdText94.Lines = new string[] {
												   "Align determines how the SDLayoutPanel aligns within SDPage (or SDPanel)."};
			this.sdText94.Location = new System.Drawing.Point(112, 232);
			this.sdText94.Name = "sdText94";
			this.sdText94.NodeValue = null;
			this.sdText94.Size = new System.Drawing.Size(368, 24);
			this.sdText94.TabIndex = 30;
			this.sdText94.Tag = "0";
			this.sdText94.WordSpace = 0F;
			// 
			// sdText95
			// 
			this.sdText95.CharSpace = 0F;
			this.sdText95.FontColor = System.Drawing.Color.Black;
			this.sdText95.FontName = Report.SdFontName.Arial;
			this.sdText95.FontSize = 10F;
			this.sdText95.Leading = 12F;
			this.sdText95.Lines = new string[] {
												   "public System.Windows.Forms.DockStyle Dock [  get,  set ]"};
			this.sdText95.Location = new System.Drawing.Point(112, 216);
			this.sdText95.Name = "sdText95";
			this.sdText95.NodeValue = null;
			this.sdText95.Size = new System.Drawing.Size(320, 16);
			this.sdText95.TabIndex = 29;
			this.sdText95.Tag = "0";
			this.sdText95.WordSpace = 0F;
			// 
			// sdText96
			// 
			this.sdText96.CharSpace = 0F;
			this.sdText96.FontBold = true;
			this.sdText96.FontColor = System.Drawing.Color.Black;
			this.sdText96.FontName = Report.SdFontName.Arial;
			this.sdText96.FontSize = 12F;
			this.sdText96.Leading = 14F;
			this.sdText96.Lines = new string[] {
												   "2.3.1      SDLayoutPanel properties"};
			this.sdText96.Location = new System.Drawing.Point(64, 200);
			this.sdText96.Name = "sdText96";
			this.sdText96.NodeValue = null;
			this.sdText96.Size = new System.Drawing.Size(360, 16);
			this.sdText96.TabIndex = 27;
			this.sdText96.Tag = "4";
			this.sdText96.WordSpace = 0F;
			// 
			// sdText97
			// 
			this.sdText97.CharSpace = 0F;
			this.sdText97.FontColor = System.Drawing.Color.Black;
			this.sdText97.FontName = Report.SdFontName.TimesRoman;
			this.sdText97.FontSize = 10F;
			this.sdText97.Leading = 12F;
			this.sdText97.Lines = new string[] {
												   "To make a page, put SDPanel on the SDPage component and put Item component",
												   "(SDItem, SDImage and so on) on the SDPanel."};
			this.sdText97.Location = new System.Drawing.Point(112, 120);
			this.sdText97.Name = "sdText97";
			this.sdText97.NodeValue = null;
			this.sdText97.Size = new System.Drawing.Size(368, 40);
			this.sdText97.TabIndex = 26;
			this.sdText97.Tag = "0";
			this.sdText97.WordSpace = 0F;
			// 
			// sdText98
			// 
			this.sdText98.CharSpace = 0F;
			this.sdText98.FontBold = true;
			this.sdText98.FontColor = System.Drawing.Color.Black;
			this.sdText98.FontName = Report.SdFontName.Arial;
			this.sdText98.FontSize = 12F;
			this.sdText98.Leading = 14F;
			this.sdText98.Lines = new string[] {
												   "Description"};
			this.sdText98.Location = new System.Drawing.Point(112, 104);
			this.sdText98.Name = "sdText98";
			this.sdText98.NodeValue = null;
			this.sdText98.Size = new System.Drawing.Size(328, 16);
			this.sdText98.TabIndex = 25;
			this.sdText98.Tag = "0";
			this.sdText98.WordSpace = 0F;
			// 
			// sdText99
			// 
			this.sdText99.CharSpace = 0F;
			this.sdText99.FontColor = System.Drawing.Color.Black;
			this.sdText99.FontName = Report.SdFontName.TimesRoman;
			this.sdText99.FontSize = 10F;
			this.sdText99.Leading = 12F;
			this.sdText99.Lines = new string[] {
												   "SDLayoutPanel is main building block of a page."};
			this.sdText99.Location = new System.Drawing.Point(112, 80);
			this.sdText99.Name = "sdText99";
			this.sdText99.NodeValue = null;
			this.sdText99.Size = new System.Drawing.Size(328, 24);
			this.sdText99.TabIndex = 24;
			this.sdText99.Tag = "0";
			this.sdText99.WordSpace = 0F;
			// 
			// sdText100
			// 
			this.sdText100.CharSpace = 0F;
			this.sdText100.FontBold = true;
			this.sdText100.FontColor = System.Drawing.Color.Black;
			this.sdText100.FontName = Report.SdFontName.Arial;
			this.sdText100.FontSize = 12F;
			this.sdText100.Leading = 14F;
			this.sdText100.Lines = new string[] {
													"2.3         SDLayoutPanel"};
			this.sdText100.Location = new System.Drawing.Point(64, 64);
			this.sdText100.Name = "sdText100";
			this.sdText100.NodeValue = null;
			this.sdText100.Size = new System.Drawing.Size(360, 16);
			this.sdText100.TabIndex = 23;
			this.sdText100.Tag = "3";
			this.sdText100.WordSpace = 0F;
			// 
			// sdLabel9
			// 
			this.sdLabel9.Alignment = Report.SDAlignment.RightJustify;
			this.sdLabel9.CharSpace = 0F;
			this.sdLabel9.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.sdLabel9.FontColor = System.Drawing.Color.Black;
			this.sdLabel9.FontName = Report.SdFontName.Arial;
			this.sdLabel9.FontSize = 8F;
			this.sdLabel9.Location = new System.Drawing.Point(0, 765);
			this.sdLabel9.Name = "sdLabel9";
			this.sdLabel9.Size = new System.Drawing.Size(532, 13);
			this.sdLabel9.TabIndex = 11;
			this.sdLabel9.Tag = "0";
			this.sdLabel9.Text = "copyright (c) 2002-2003 Serdar Dirican";
			this.sdLabel9.WordSpace = 0F;
			// 
			// sdRect27
			// 
			this.sdRect27.FillColor = System.Drawing.Color.Transparent;
			this.sdRect27.LineColor = System.Drawing.Color.Black;
			this.sdRect27.LineStyle = Report.PenStyle.Solid;
			this.sdRect27.LineWidth = 0F;
			this.sdRect27.Location = new System.Drawing.Point(256, 24);
			this.sdRect27.Name = "sdRect27";
			this.sdRect27.Size = new System.Drawing.Size(2, 24);
			this.sdRect27.TabIndex = 10;
			this.sdRect27.Tag = "0";
			this.sdRect27.Text = "sdRect4";
			// 
			// sdRect28
			// 
			this.sdRect28.FillColor = System.Drawing.Color.Transparent;
			this.sdRect28.LineColor = System.Drawing.Color.Black;
			this.sdRect28.LineStyle = Report.PenStyle.Solid;
			this.sdRect28.LineWidth = 0F;
			this.sdRect28.Location = new System.Drawing.Point(440, 24);
			this.sdRect28.Name = "sdRect28";
			this.sdRect28.Size = new System.Drawing.Size(2, 24);
			this.sdRect28.TabIndex = 9;
			this.sdRect28.Tag = "0";
			this.sdRect28.Text = "sdRect3";
			// 
			// sdRect29
			// 
			this.sdRect29.FillColor = System.Drawing.Color.Transparent;
			this.sdRect29.LineColor = System.Drawing.Color.Black;
			this.sdRect29.LineStyle = Report.PenStyle.Solid;
			this.sdRect29.LineWidth = 0F;
			this.sdRect29.Location = new System.Drawing.Point(80, 24);
			this.sdRect29.Name = "sdRect29";
			this.sdRect29.Size = new System.Drawing.Size(2, 24);
			this.sdRect29.TabIndex = 8;
			this.sdRect29.Tag = "0";
			this.sdRect29.Text = "sdRect2";
			// 
			// sdRect30
			// 
			this.sdRect30.DrawLine = true;
			this.sdRect30.FillColor = System.Drawing.Color.Transparent;
			this.sdRect30.LineColor = System.Drawing.Color.Black;
			this.sdRect30.LineStyle = Report.PenStyle.Solid;
			this.sdRect30.LineWidth = 2F;
			this.sdRect30.Location = new System.Drawing.Point(80, 40);
			this.sdRect30.Name = "sdRect30";
			this.sdRect30.Size = new System.Drawing.Size(360, 3);
			this.sdRect30.TabIndex = 7;
			this.sdRect30.Tag = "0";
			this.sdRect30.Text = "sdRect1";
			// 
			// tabPage9
			// 
			this.tabPage9.AutoScroll = true;
			this.tabPage9.Controls.Add(this.sdPage7);
			this.tabPage9.Location = new System.Drawing.Point(4, 58);
			this.tabPage9.Name = "tabPage9";
			this.tabPage9.Size = new System.Drawing.Size(472, 211);
			this.tabPage9.TabIndex = 8;
			this.tabPage9.Text = "SDGridPanel";
			// 
			// sdPage7
			// 
			this.sdPage7.Controls.Add(this.sdLayoutPanel9);
			this.sdPage7.DockPadding.All = 32;
			this.sdPage7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
			this.sdPage7.Location = new System.Drawing.Point(0, 0);
			this.sdPage7.Name = "sdPage7";
			this.sdPage7.Size = new System.Drawing.Size(596, 842);
			this.sdPage7.TabIndex = 1;
			this.sdPage7.Text = "sdPage7";
			// 
			// sdLayoutPanel9
			// 
			this.sdLayoutPanel9.BackColor = System.Drawing.SystemColors.Window;
			this.sdLayoutPanel9.Controls.Add(this.sdText101);
			this.sdLayoutPanel9.Controls.Add(this.sdText102);
			this.sdLayoutPanel9.Controls.Add(this.sdText103);
			this.sdLayoutPanel9.Controls.Add(this.sdText104);
			this.sdLayoutPanel9.Controls.Add(this.sdText105);
			this.sdLayoutPanel9.Controls.Add(this.sdText106);
			this.sdLayoutPanel9.Controls.Add(this.sdText107);
			this.sdLayoutPanel9.Controls.Add(this.sdText108);
			this.sdLayoutPanel9.Controls.Add(this.sdText109);
			this.sdLayoutPanel9.Controls.Add(this.sdText110);
			this.sdLayoutPanel9.Controls.Add(this.sdText111);
			this.sdLayoutPanel9.Controls.Add(this.sdText112);
			this.sdLayoutPanel9.Controls.Add(this.sdText113);
			this.sdLayoutPanel9.Controls.Add(this.sdText114);
			this.sdLayoutPanel9.Controls.Add(this.sdText115);
			this.sdLayoutPanel9.Controls.Add(this.sdText116);
			this.sdLayoutPanel9.Controls.Add(this.sdText117);
			this.sdLayoutPanel9.Controls.Add(this.sdText118);
			this.sdLayoutPanel9.Controls.Add(this.sdText119);
			this.sdLayoutPanel9.Controls.Add(this.sdText120);
			this.sdLayoutPanel9.Controls.Add(this.sdText121);
			this.sdLayoutPanel9.Controls.Add(this.sdText122);
			this.sdLayoutPanel9.Controls.Add(this.sdLabel10);
			this.sdLayoutPanel9.Controls.Add(this.sdRect31);
			this.sdLayoutPanel9.Controls.Add(this.sdRect32);
			this.sdLayoutPanel9.Controls.Add(this.sdRect33);
			this.sdLayoutPanel9.Controls.Add(this.sdRect34);
			this.sdLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sdLayoutPanel9.Location = new System.Drawing.Point(32, 32);
			this.sdLayoutPanel9.Name = "sdLayoutPanel9";
			this.sdLayoutPanel9.Size = new System.Drawing.Size(532, 778);
			this.sdLayoutPanel9.TabIndex = 0;
			this.sdLayoutPanel9.Text = "sdLayoutPanel1";
			this.sdLayoutPanel9.BeforePrint += new Report.SDPrintPanelEvent(this.sdlayotupanel_BeforePrint);
			// 
			// sdText101
			// 
			this.sdText101.CharSpace = 0F;
			this.sdText101.FontColor = System.Drawing.Color.Black;
			this.sdText101.FontName = Report.SdFontName.TimesRoman;
			this.sdText101.FontSize = 10F;
			this.sdText101.Leading = 12F;
			this.sdText101.Lines = new string[] {
													"AfterPrint is called every after panels were printed."};
			this.sdText101.Location = new System.Drawing.Point(112, 584);
			this.sdText101.Name = "sdText101";
			this.sdText101.NodeValue = null;
			this.sdText101.Size = new System.Drawing.Size(368, 24);
			this.sdText101.TabIndex = 57;
			this.sdText101.Tag = "0";
			this.sdText101.WordSpace = 0F;
			// 
			// sdText102
			// 
			this.sdText102.CharSpace = 0F;
			this.sdText102.FontColor = System.Drawing.Color.Black;
			this.sdText102.FontName = Report.SdFontName.Arial;
			this.sdText102.FontSize = 10F;
			this.sdText102.Leading = 12F;
			this.sdText102.Lines = new string[] {
													"public event Report.SDPrintChildPanelEvent AfterPrintChild"};
			this.sdText102.Location = new System.Drawing.Point(112, 568);
			this.sdText102.Name = "sdText102";
			this.sdText102.NodeValue = null;
			this.sdText102.Size = new System.Drawing.Size(320, 16);
			this.sdText102.TabIndex = 56;
			this.sdText102.Tag = "0";
			this.sdText102.WordSpace = 0F;
			// 
			// sdText103
			// 
			this.sdText103.CharSpace = 0F;
			this.sdText103.FontColor = System.Drawing.Color.Black;
			this.sdText103.FontName = Report.SdFontName.TimesRoman;
			this.sdText103.FontSize = 10F;
			this.sdText103.Leading = 12F;
			this.sdText103.Lines = new string[] {
													"BeforePrintChild is called every before child panels are about to be printed. Typ" +
													"ical",
													"use of this event is to set any variables(SDText, SDImage)."};
			this.sdText103.Location = new System.Drawing.Point(112, 536);
			this.sdText103.Name = "sdText103";
			this.sdText103.NodeValue = null;
			this.sdText103.Size = new System.Drawing.Size(368, 32);
			this.sdText103.TabIndex = 55;
			this.sdText103.Tag = "0";
			this.sdText103.WordSpace = 0F;
			// 
			// sdText104
			// 
			this.sdText104.CharSpace = 0F;
			this.sdText104.FontColor = System.Drawing.Color.Black;
			this.sdText104.FontName = Report.SdFontName.Arial;
			this.sdText104.FontSize = 10F;
			this.sdText104.Leading = 12F;
			this.sdText104.Lines = new string[] {
													"public event Report.SDPrintChildPanelEvent BeforePrintChild"};
			this.sdText104.Location = new System.Drawing.Point(112, 520);
			this.sdText104.Name = "sdText104";
			this.sdText104.NodeValue = null;
			this.sdText104.Size = new System.Drawing.Size(320, 16);
			this.sdText104.TabIndex = 54;
			this.sdText104.Tag = "0";
			this.sdText104.WordSpace = 0F;
			// 
			// sdText105
			// 
			this.sdText105.CharSpace = 0F;
			this.sdText105.FontColor = System.Drawing.Color.Black;
			this.sdText105.FontName = Report.SdFontName.TimesRoman;
			this.sdText105.FontSize = 10F;
			this.sdText105.Leading = 12F;
			this.sdText105.Lines = new string[] {
													"PrintDirection determins the direction of printing grid."};
			this.sdText105.Location = new System.Drawing.Point(112, 352);
			this.sdText105.Name = "sdText105";
			this.sdText105.NodeValue = null;
			this.sdText105.Size = new System.Drawing.Size(368, 24);
			this.sdText105.TabIndex = 53;
			this.sdText105.Tag = "0";
			this.sdText105.WordSpace = 0F;
			// 
			// sdText106
			// 
			this.sdText106.CharSpace = 0F;
			this.sdText106.FontColor = System.Drawing.Color.Black;
			this.sdText106.FontName = Report.SdFontName.Arial;
			this.sdText106.FontSize = 10F;
			this.sdText106.Leading = 12F;
			this.sdText106.Lines = new string[] {
													"public Report.PrintDirection PrintDirection [  get,  set ]"};
			this.sdText106.Location = new System.Drawing.Point(112, 336);
			this.sdText106.Name = "sdText106";
			this.sdText106.NodeValue = null;
			this.sdText106.Size = new System.Drawing.Size(320, 16);
			this.sdText106.TabIndex = 52;
			this.sdText106.Tag = "0";
			this.sdText106.WordSpace = 0F;
			// 
			// sdText107
			// 
			this.sdText107.CharSpace = 0F;
			this.sdText107.FontColor = System.Drawing.Color.Black;
			this.sdText107.FontName = Report.SdFontName.TimesRoman;
			this.sdText107.FontSize = 10F;
			this.sdText107.Leading = 12F;
			this.sdText107.Lines = new string[] {
													"TableRowCount determines how many numbers of rows in this panel."};
			this.sdText107.Location = new System.Drawing.Point(112, 312);
			this.sdText107.Name = "sdText107";
			this.sdText107.NodeValue = null;
			this.sdText107.Size = new System.Drawing.Size(368, 24);
			this.sdText107.TabIndex = 51;
			this.sdText107.Tag = "0";
			this.sdText107.WordSpace = 0F;
			// 
			// sdText108
			// 
			this.sdText108.CharSpace = 0F;
			this.sdText108.FontColor = System.Drawing.Color.Black;
			this.sdText108.FontName = Report.SdFontName.Arial;
			this.sdText108.FontSize = 10F;
			this.sdText108.Leading = 12F;
			this.sdText108.Lines = new string[] {
													"public int TableRowCount [  get,  set ]"};
			this.sdText108.Location = new System.Drawing.Point(112, 296);
			this.sdText108.Name = "sdText108";
			this.sdText108.NodeValue = null;
			this.sdText108.Size = new System.Drawing.Size(320, 16);
			this.sdText108.TabIndex = 50;
			this.sdText108.Tag = "0";
			this.sdText108.WordSpace = 0F;
			// 
			// sdText109
			// 
			this.sdText109.CharSpace = 0F;
			this.sdText109.FontColor = System.Drawing.Color.Black;
			this.sdText109.FontName = Report.SdFontName.TimesRoman;
			this.sdText109.FontSize = 10F;
			this.sdText109.Leading = 12F;
			this.sdText109.Lines = new string[] {
													"TableColCount determines how many numbers of columns in this panel."};
			this.sdText109.Location = new System.Drawing.Point(112, 272);
			this.sdText109.Name = "sdText109";
			this.sdText109.NodeValue = null;
			this.sdText109.Size = new System.Drawing.Size(368, 24);
			this.sdText109.TabIndex = 49;
			this.sdText109.Tag = "0";
			this.sdText109.WordSpace = 0F;
			// 
			// sdText110
			// 
			this.sdText110.CharSpace = 0F;
			this.sdText110.FontColor = System.Drawing.Color.Black;
			this.sdText110.FontName = Report.SdFontName.Arial;
			this.sdText110.FontSize = 10F;
			this.sdText110.Leading = 12F;
			this.sdText110.Lines = new string[] {
													"public int TableColCount [  get,  set ]"};
			this.sdText110.Location = new System.Drawing.Point(112, 256);
			this.sdText110.Name = "sdText110";
			this.sdText110.NodeValue = null;
			this.sdText110.Size = new System.Drawing.Size(320, 16);
			this.sdText110.TabIndex = 48;
			this.sdText110.Tag = "0";
			this.sdText110.WordSpace = 0F;
			// 
			// sdText111
			// 
			this.sdText111.CharSpace = 0F;
			this.sdText111.FontColor = System.Drawing.Color.Black;
			this.sdText111.FontName = Report.SdFontName.TimesRoman;
			this.sdText111.FontSize = 10F;
			this.sdText111.Leading = 12F;
			this.sdText111.Lines = new string[] {
													"AfterPrint is called after a page was printed."};
			this.sdText111.Location = new System.Drawing.Point(112, 496);
			this.sdText111.Name = "sdText111";
			this.sdText111.NodeValue = null;
			this.sdText111.Size = new System.Drawing.Size(368, 24);
			this.sdText111.TabIndex = 47;
			this.sdText111.Tag = "0";
			this.sdText111.WordSpace = 0F;
			// 
			// sdText112
			// 
			this.sdText112.CharSpace = 0F;
			this.sdText112.FontColor = System.Drawing.Color.Black;
			this.sdText112.FontName = Report.SdFontName.Arial;
			this.sdText112.FontSize = 10F;
			this.sdText112.Leading = 12F;
			this.sdText112.Lines = new string[] {
													"public event Report.SDPrintPanelEvent AfterPrint"};
			this.sdText112.Location = new System.Drawing.Point(112, 480);
			this.sdText112.Name = "sdText112";
			this.sdText112.NodeValue = null;
			this.sdText112.Size = new System.Drawing.Size(320, 16);
			this.sdText112.TabIndex = 46;
			this.sdText112.Tag = "0";
			this.sdText112.WordSpace = 0F;
			// 
			// sdText113
			// 
			this.sdText113.CharSpace = 0F;
			this.sdText113.FontColor = System.Drawing.Color.Black;
			this.sdText113.FontName = Report.SdFontName.TimesRoman;
			this.sdText113.FontSize = 10F;
			this.sdText113.Leading = 12F;
			this.sdText113.Lines = new string[] {
													"BeforePrint is called before a page is about to be printed. Typical use of this e" +
													"vent",
													"is to set any variables(SDText, SDImage)."};
			this.sdText113.Location = new System.Drawing.Point(112, 448);
			this.sdText113.Name = "sdText113";
			this.sdText113.NodeValue = null;
			this.sdText113.Size = new System.Drawing.Size(368, 32);
			this.sdText113.TabIndex = 45;
			this.sdText113.Tag = "0";
			this.sdText113.WordSpace = 0F;
			// 
			// sdText114
			// 
			this.sdText114.CharSpace = 0F;
			this.sdText114.FontColor = System.Drawing.Color.Black;
			this.sdText114.FontName = Report.SdFontName.Arial;
			this.sdText114.FontSize = 10F;
			this.sdText114.Leading = 12F;
			this.sdText114.Lines = new string[] {
													"public event Report.SDPrintPanelEvent BeforePrint"};
			this.sdText114.Location = new System.Drawing.Point(112, 432);
			this.sdText114.Name = "sdText114";
			this.sdText114.NodeValue = null;
			this.sdText114.Size = new System.Drawing.Size(320, 16);
			this.sdText114.TabIndex = 44;
			this.sdText114.Tag = "0";
			this.sdText114.WordSpace = 0F;
			// 
			// sdText115
			// 
			this.sdText115.CharSpace = 0F;
			this.sdText115.FontBold = true;
			this.sdText115.FontColor = System.Drawing.Color.Black;
			this.sdText115.FontName = Report.SdFontName.Arial;
			this.sdText115.FontSize = 12F;
			this.sdText115.Leading = 14F;
			this.sdText115.Lines = new string[] {
													"2.4.2      SDGridPanel Events"};
			this.sdText115.Location = new System.Drawing.Point(64, 416);
			this.sdText115.Name = "sdText115";
			this.sdText115.NodeValue = null;
			this.sdText115.Size = new System.Drawing.Size(360, 16);
			this.sdText115.TabIndex = 43;
			this.sdText115.Tag = "4";
			this.sdText115.WordSpace = 0F;
			// 
			// sdText116
			// 
			this.sdText116.CharSpace = 0F;
			this.sdText116.FontColor = System.Drawing.Color.Black;
			this.sdText116.FontName = Report.SdFontName.TimesRoman;
			this.sdText116.FontSize = 10F;
			this.sdText116.Leading = 12F;
			this.sdText116.Lines = new string[] {
													"Align determines how the SDGridPanel aligns within SDPage (or SDPanel)."};
			this.sdText116.Location = new System.Drawing.Point(112, 232);
			this.sdText116.Name = "sdText116";
			this.sdText116.NodeValue = null;
			this.sdText116.Size = new System.Drawing.Size(368, 24);
			this.sdText116.TabIndex = 30;
			this.sdText116.Tag = "0";
			this.sdText116.WordSpace = 0F;
			// 
			// sdText117
			// 
			this.sdText117.CharSpace = 0F;
			this.sdText117.FontColor = System.Drawing.Color.Black;
			this.sdText117.FontName = Report.SdFontName.Arial;
			this.sdText117.FontSize = 10F;
			this.sdText117.Leading = 12F;
			this.sdText117.Lines = new string[] {
													"public System.Windows.Forms.DockStyle Dock [  get,  set ]"};
			this.sdText117.Location = new System.Drawing.Point(112, 216);
			this.sdText117.Name = "sdText117";
			this.sdText117.NodeValue = null;
			this.sdText117.Size = new System.Drawing.Size(320, 16);
			this.sdText117.TabIndex = 29;
			this.sdText117.Tag = "0";
			this.sdText117.WordSpace = 0F;
			// 
			// sdText118
			// 
			this.sdText118.CharSpace = 0F;
			this.sdText118.FontBold = true;
			this.sdText118.FontColor = System.Drawing.Color.Black;
			this.sdText118.FontName = Report.SdFontName.Arial;
			this.sdText118.FontSize = 12F;
			this.sdText118.Leading = 14F;
			this.sdText118.Lines = new string[] {
													"2.4.1      SDGridPanel properties"};
			this.sdText118.Location = new System.Drawing.Point(64, 200);
			this.sdText118.Name = "sdText118";
			this.sdText118.NodeValue = null;
			this.sdText118.Size = new System.Drawing.Size(360, 16);
			this.sdText118.TabIndex = 27;
			this.sdText118.Tag = "4";
			this.sdText118.WordSpace = 0F;
			// 
			// sdText119
			// 
			this.sdText119.CharSpace = 0F;
			this.sdText119.FontColor = System.Drawing.Color.Black;
			this.sdText119.FontName = Report.SdFontName.TimesRoman;
			this.sdText119.FontSize = 10F;
			this.sdText119.Leading = 12F;
			this.sdText119.Lines = new string[] {
													"A typical use of SDGridPanel is to print a table(like a database data). set Table" +
													"RowCount and",
													"TableColCount property to define row count and column count."};
			this.sdText119.Location = new System.Drawing.Point(112, 120);
			this.sdText119.Name = "sdText119";
			this.sdText119.NodeValue = null;
			this.sdText119.Size = new System.Drawing.Size(376, 40);
			this.sdText119.TabIndex = 26;
			this.sdText119.Tag = "0";
			this.sdText119.WordSpace = 0F;
			// 
			// sdText120
			// 
			this.sdText120.CharSpace = 0F;
			this.sdText120.FontBold = true;
			this.sdText120.FontColor = System.Drawing.Color.Black;
			this.sdText120.FontName = Report.SdFontName.Arial;
			this.sdText120.FontSize = 12F;
			this.sdText120.Leading = 14F;
			this.sdText120.Lines = new string[] {
													"Description"};
			this.sdText120.Location = new System.Drawing.Point(112, 104);
			this.sdText120.Name = "sdText120";
			this.sdText120.NodeValue = null;
			this.sdText120.Size = new System.Drawing.Size(328, 16);
			this.sdText120.TabIndex = 25;
			this.sdText120.Tag = "0";
			this.sdText120.WordSpace = 0F;
			// 
			// sdText121
			// 
			this.sdText121.CharSpace = 0F;
			this.sdText121.FontColor = System.Drawing.Color.Black;
			this.sdText121.FontName = Report.SdFontName.TimesRoman;
			this.sdText121.FontSize = 10F;
			this.sdText121.Leading = 12F;
			this.sdText121.Lines = new string[] {
													"SDGridPanel is used to print a table."};
			this.sdText121.Location = new System.Drawing.Point(112, 80);
			this.sdText121.Name = "sdText121";
			this.sdText121.NodeValue = null;
			this.sdText121.Size = new System.Drawing.Size(328, 24);
			this.sdText121.TabIndex = 24;
			this.sdText121.Tag = "0";
			this.sdText121.WordSpace = 0F;
			// 
			// sdText122
			// 
			this.sdText122.CharSpace = 0F;
			this.sdText122.FontBold = true;
			this.sdText122.FontColor = System.Drawing.Color.Black;
			this.sdText122.FontName = Report.SdFontName.Arial;
			this.sdText122.FontSize = 12F;
			this.sdText122.Leading = 14F;
			this.sdText122.Lines = new string[] {
													"2.4         SDGridPanel"};
			this.sdText122.Location = new System.Drawing.Point(64, 64);
			this.sdText122.Name = "sdText122";
			this.sdText122.NodeValue = null;
			this.sdText122.Size = new System.Drawing.Size(360, 16);
			this.sdText122.TabIndex = 23;
			this.sdText122.Tag = "3";
			this.sdText122.WordSpace = 0F;
			// 
			// sdLabel10
			// 
			this.sdLabel10.Alignment = Report.SDAlignment.RightJustify;
			this.sdLabel10.CharSpace = 0F;
			this.sdLabel10.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.sdLabel10.FontColor = System.Drawing.Color.Black;
			this.sdLabel10.FontName = Report.SdFontName.Arial;
			this.sdLabel10.FontSize = 8F;
			this.sdLabel10.Location = new System.Drawing.Point(0, 765);
			this.sdLabel10.Name = "sdLabel10";
			this.sdLabel10.Size = new System.Drawing.Size(532, 13);
			this.sdLabel10.TabIndex = 11;
			this.sdLabel10.Tag = "0";
			this.sdLabel10.Text = "copyright (c) 2002-2003 Serdar Dirican";
			this.sdLabel10.WordSpace = 0F;
			// 
			// sdRect31
			// 
			this.sdRect31.FillColor = System.Drawing.Color.Transparent;
			this.sdRect31.LineColor = System.Drawing.Color.Black;
			this.sdRect31.LineStyle = Report.PenStyle.Solid;
			this.sdRect31.LineWidth = 0F;
			this.sdRect31.Location = new System.Drawing.Point(256, 24);
			this.sdRect31.Name = "sdRect31";
			this.sdRect31.Size = new System.Drawing.Size(2, 24);
			this.sdRect31.TabIndex = 10;
			this.sdRect31.Tag = "0";
			this.sdRect31.Text = "sdRect4";
			// 
			// sdRect32
			// 
			this.sdRect32.FillColor = System.Drawing.Color.Transparent;
			this.sdRect32.LineColor = System.Drawing.Color.Black;
			this.sdRect32.LineStyle = Report.PenStyle.Solid;
			this.sdRect32.LineWidth = 0F;
			this.sdRect32.Location = new System.Drawing.Point(440, 24);
			this.sdRect32.Name = "sdRect32";
			this.sdRect32.Size = new System.Drawing.Size(2, 24);
			this.sdRect32.TabIndex = 9;
			this.sdRect32.Tag = "0";
			this.sdRect32.Text = "sdRect3";
			// 
			// sdRect33
			// 
			this.sdRect33.FillColor = System.Drawing.Color.Transparent;
			this.sdRect33.LineColor = System.Drawing.Color.Black;
			this.sdRect33.LineStyle = Report.PenStyle.Solid;
			this.sdRect33.LineWidth = 0F;
			this.sdRect33.Location = new System.Drawing.Point(80, 24);
			this.sdRect33.Name = "sdRect33";
			this.sdRect33.Size = new System.Drawing.Size(2, 24);
			this.sdRect33.TabIndex = 8;
			this.sdRect33.Tag = "0";
			this.sdRect33.Text = "sdRect2";
			// 
			// sdRect34
			// 
			this.sdRect34.DrawLine = true;
			this.sdRect34.FillColor = System.Drawing.Color.Transparent;
			this.sdRect34.LineColor = System.Drawing.Color.Black;
			this.sdRect34.LineStyle = Report.PenStyle.Solid;
			this.sdRect34.LineWidth = 2F;
			this.sdRect34.Location = new System.Drawing.Point(80, 40);
			this.sdRect34.Name = "sdRect34";
			this.sdRect34.Size = new System.Drawing.Size(360, 3);
			this.sdRect34.TabIndex = 7;
			this.sdRect34.Tag = "0";
			this.sdRect34.Text = "sdRect1";
			// 
			// tabPage10
			// 
			this.tabPage10.AutoScroll = true;
			this.tabPage10.Controls.Add(this.sdPage8);
			this.tabPage10.Location = new System.Drawing.Point(4, 58);
			this.tabPage10.Name = "tabPage10";
			this.tabPage10.Size = new System.Drawing.Size(472, 211);
			this.tabPage10.TabIndex = 9;
			this.tabPage10.Text = "SDLabel";
			// 
			// sdPage8
			// 
			this.sdPage8.Controls.Add(this.sdLayoutPanel10);
			this.sdPage8.DockPadding.All = 32;
			this.sdPage8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
			this.sdPage8.Location = new System.Drawing.Point(0, 0);
			this.sdPage8.Name = "sdPage8";
			this.sdPage8.Size = new System.Drawing.Size(596, 842);
			this.sdPage8.TabIndex = 1;
			this.sdPage8.Text = "sdPage8";
			// 
			// sdLayoutPanel10
			// 
			this.sdLayoutPanel10.BackColor = System.Drawing.SystemColors.Window;
			this.sdLayoutPanel10.Controls.Add(this.sdText123);
			this.sdLayoutPanel10.Controls.Add(this.sdText124);
			this.sdLayoutPanel10.Controls.Add(this.sdText125);
			this.sdLayoutPanel10.Controls.Add(this.sdText126);
			this.sdLayoutPanel10.Controls.Add(this.sdLabel11);
			this.sdLayoutPanel10.Controls.Add(this.sdText127);
			this.sdLayoutPanel10.Controls.Add(this.sdLabel12);
			this.sdLayoutPanel10.Controls.Add(this.sdText128);
			this.sdLayoutPanel10.Controls.Add(this.sdLabel13);
			this.sdLayoutPanel10.Controls.Add(this.sdText129);
			this.sdLayoutPanel10.Controls.Add(this.sdLabel14);
			this.sdLayoutPanel10.Controls.Add(this.sdText130);
			this.sdLayoutPanel10.Controls.Add(this.sdRect35);
			this.sdLayoutPanel10.Controls.Add(this.sdText131);
			this.sdLayoutPanel10.Controls.Add(this.sdText134);
			this.sdLayoutPanel10.Controls.Add(this.sdText135);
			this.sdLayoutPanel10.Controls.Add(this.sdText136);
			this.sdLayoutPanel10.Controls.Add(this.sdText137);
			this.sdLayoutPanel10.Controls.Add(this.sdText138);
			this.sdLayoutPanel10.Controls.Add(this.sdText139);
			this.sdLayoutPanel10.Controls.Add(this.sdText140);
			this.sdLayoutPanel10.Controls.Add(this.sdText141);
			this.sdLayoutPanel10.Controls.Add(this.sdText142);
			this.sdLayoutPanel10.Controls.Add(this.sdText143);
			this.sdLayoutPanel10.Controls.Add(this.sdText144);
			this.sdLayoutPanel10.Controls.Add(this.sdLabel15);
			this.sdLayoutPanel10.Controls.Add(this.sdRect36);
			this.sdLayoutPanel10.Controls.Add(this.sdRect37);
			this.sdLayoutPanel10.Controls.Add(this.sdRect38);
			this.sdLayoutPanel10.Controls.Add(this.sdRect39);
			this.sdLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sdLayoutPanel10.Location = new System.Drawing.Point(32, 32);
			this.sdLayoutPanel10.Name = "sdLayoutPanel10";
			this.sdLayoutPanel10.Size = new System.Drawing.Size(532, 778);
			this.sdLayoutPanel10.TabIndex = 0;
			this.sdLayoutPanel10.Text = "sdLayoutPanel1";
			this.sdLayoutPanel10.BeforePrint += new Report.SDPrintPanelEvent(this.sdlayotupanel_BeforePrint);
			// 
			// sdText123
			// 
			this.sdText123.CharSpace = 0F;
			this.sdText123.FontColor = System.Drawing.Color.Black;
			this.sdText123.FontName = Report.SdFontName.TimesRoman;
			this.sdText123.FontSize = 10F;
			this.sdText123.Leading = 12F;
			this.sdText123.Lines = new string[] {
													"Specifies the color of the text."};
			this.sdText123.Location = new System.Drawing.Point(112, 552);
			this.sdText123.Name = "sdText123";
			this.sdText123.NodeValue = null;
			this.sdText123.Size = new System.Drawing.Size(368, 24);
			this.sdText123.TabIndex = 67;
			this.sdText123.Tag = "0";
			this.sdText123.WordSpace = 0F;
			// 
			// sdText124
			// 
			this.sdText124.CharSpace = 0F;
			this.sdText124.FontColor = System.Drawing.Color.Black;
			this.sdText124.FontName = Report.SdFontName.Arial;
			this.sdText124.FontSize = 10F;
			this.sdText124.Leading = 12F;
			this.sdText124.Lines = new string[] {
													"public System.Drawing.Color FontColor [  get,  set ]"};
			this.sdText124.Location = new System.Drawing.Point(112, 536);
			this.sdText124.Name = "sdText124";
			this.sdText124.NodeValue = null;
			this.sdText124.Size = new System.Drawing.Size(320, 16);
			this.sdText124.TabIndex = 66;
			this.sdText124.Tag = "0";
			this.sdText124.WordSpace = 0F;
			// 
			// sdText125
			// 
			this.sdText125.CharSpace = 0F;
			this.sdText125.FontColor = System.Drawing.Color.Black;
			this.sdText125.FontName = Report.SdFontName.TimesRoman;
			this.sdText125.FontSize = 10F;
			this.sdText125.Leading = 12F;
			this.sdText125.Lines = new string[] {
													"Determines whether the control will be printed or not."};
			this.sdText125.Location = new System.Drawing.Point(112, 512);
			this.sdText125.Name = "sdText125";
			this.sdText125.NodeValue = null;
			this.sdText125.Size = new System.Drawing.Size(368, 24);
			this.sdText125.TabIndex = 65;
			this.sdText125.Tag = "0";
			this.sdText125.WordSpace = 0F;
			// 
			// sdText126
			// 
			this.sdText126.CharSpace = 0F;
			this.sdText126.FontColor = System.Drawing.Color.Black;
			this.sdText126.FontName = Report.SdFontName.Arial;
			this.sdText126.FontSize = 10F;
			this.sdText126.Leading = 12F;
			this.sdText126.Lines = new string[] {
													"public bool Printable [  get,  set ]"};
			this.sdText126.Location = new System.Drawing.Point(112, 496);
			this.sdText126.Name = "sdText126";
			this.sdText126.NodeValue = null;
			this.sdText126.Size = new System.Drawing.Size(320, 16);
			this.sdText126.TabIndex = 64;
			this.sdText126.Tag = "0";
			this.sdText126.WordSpace = 0F;
			// 
			// sdLabel11
			// 
			this.sdLabel11.AlignJustified = true;
			this.sdLabel11.Alignment = Report.SDAlignment.Center;
			this.sdLabel11.CharSpace = 0F;
			this.sdLabel11.FontColor = System.Drawing.Color.Green;
			this.sdLabel11.FontName = Report.SdFontName.Arial;
			this.sdLabel11.FontSize = 14F;
			this.sdLabel11.Location = new System.Drawing.Point(120, 456);
			this.sdLabel11.Name = "sdLabel11";
			this.sdLabel11.Size = new System.Drawing.Size(344, 16);
			this.sdLabel11.TabIndex = 63;
			this.sdLabel11.Tag = "0";
			this.sdLabel11.Text = "The quick brown fox ate the lazy mouse";
			this.sdLabel11.WordSpace = 0F;
			// 
			// sdText127
			// 
			this.sdText127.CharSpace = 0F;
			this.sdText127.FontColor = System.Drawing.Color.Black;
			this.sdText127.FontName = Report.SdFontName.TimesRoman;
			this.sdText127.FontSize = 10F;
			this.sdText127.Leading = 12F;
			this.sdText127.Lines = new string[] {
													"AlignJustified"};
			this.sdText127.Location = new System.Drawing.Point(120, 440);
			this.sdText127.Name = "sdText127";
			this.sdText127.NodeValue = null;
			this.sdText127.Size = new System.Drawing.Size(336, 16);
			this.sdText127.TabIndex = 62;
			this.sdText127.Tag = "0";
			this.sdText127.WordSpace = 0F;
			// 
			// sdLabel12
			// 
			this.sdLabel12.Alignment = Report.SDAlignment.Center;
			this.sdLabel12.CharSpace = 0F;
			this.sdLabel12.FontColor = System.Drawing.Color.Green;
			this.sdLabel12.FontName = Report.SdFontName.Arial;
			this.sdLabel12.FontSize = 14F;
			this.sdLabel12.Location = new System.Drawing.Point(120, 424);
			this.sdLabel12.Name = "sdLabel12";
			this.sdLabel12.Size = new System.Drawing.Size(344, 16);
			this.sdLabel12.TabIndex = 61;
			this.sdLabel12.Tag = "0";
			this.sdLabel12.Text = "The quick brown fox ate the lazy mouse";
			this.sdLabel12.WordSpace = 0F;
			// 
			// sdText128
			// 
			this.sdText128.CharSpace = 0F;
			this.sdText128.FontColor = System.Drawing.Color.Black;
			this.sdText128.FontName = Report.SdFontName.TimesRoman;
			this.sdText128.FontSize = 10F;
			this.sdText128.Leading = 12F;
			this.sdText128.Lines = new string[] {
													"Alignment Center"};
			this.sdText128.Location = new System.Drawing.Point(120, 408);
			this.sdText128.Name = "sdText128";
			this.sdText128.NodeValue = null;
			this.sdText128.Size = new System.Drawing.Size(336, 16);
			this.sdText128.TabIndex = 60;
			this.sdText128.Tag = "0";
			this.sdText128.WordSpace = 0F;
			// 
			// sdLabel13
			// 
			this.sdLabel13.Alignment = Report.SDAlignment.RightJustify;
			this.sdLabel13.CharSpace = 0F;
			this.sdLabel13.FontColor = System.Drawing.Color.Green;
			this.sdLabel13.FontName = Report.SdFontName.Arial;
			this.sdLabel13.FontSize = 14F;
			this.sdLabel13.Location = new System.Drawing.Point(120, 392);
			this.sdLabel13.Name = "sdLabel13";
			this.sdLabel13.Size = new System.Drawing.Size(352, 16);
			this.sdLabel13.TabIndex = 59;
			this.sdLabel13.Tag = "0";
			this.sdLabel13.Text = "The quick brown fox ate the lazy mouse";
			this.sdLabel13.WordSpace = 0F;
			// 
			// sdText129
			// 
			this.sdText129.CharSpace = 0F;
			this.sdText129.FontColor = System.Drawing.Color.Black;
			this.sdText129.FontName = Report.SdFontName.TimesRoman;
			this.sdText129.FontSize = 10F;
			this.sdText129.Leading = 12F;
			this.sdText129.Lines = new string[] {
													"Alignment RightJustify"};
			this.sdText129.Location = new System.Drawing.Point(120, 376);
			this.sdText129.Name = "sdText129";
			this.sdText129.NodeValue = null;
			this.sdText129.Size = new System.Drawing.Size(336, 16);
			this.sdText129.TabIndex = 58;
			this.sdText129.Tag = "0";
			this.sdText129.WordSpace = 0F;
			// 
			// sdLabel14
			// 
			this.sdLabel14.CharSpace = 0F;
			this.sdLabel14.FontColor = System.Drawing.Color.Green;
			this.sdLabel14.FontName = Report.SdFontName.Arial;
			this.sdLabel14.FontSize = 14F;
			this.sdLabel14.Location = new System.Drawing.Point(120, 360);
			this.sdLabel14.Name = "sdLabel14";
			this.sdLabel14.Size = new System.Drawing.Size(344, 16);
			this.sdLabel14.TabIndex = 57;
			this.sdLabel14.Tag = "0";
			this.sdLabel14.Text = "The quick brown fox ate the lazy mouse";
			this.sdLabel14.WordSpace = 0F;
			// 
			// sdText130
			// 
			this.sdText130.CharSpace = 0F;
			this.sdText130.FontColor = System.Drawing.Color.Black;
			this.sdText130.FontName = Report.SdFontName.TimesRoman;
			this.sdText130.FontSize = 10F;
			this.sdText130.Leading = 12F;
			this.sdText130.Lines = new string[] {
													"Alignment LeftJustify"};
			this.sdText130.Location = new System.Drawing.Point(120, 344);
			this.sdText130.Name = "sdText130";
			this.sdText130.NodeValue = null;
			this.sdText130.Size = new System.Drawing.Size(336, 16);
			this.sdText130.TabIndex = 56;
			this.sdText130.Tag = "0";
			this.sdText130.WordSpace = 0F;
			// 
			// sdRect35
			// 
			this.sdRect35.FillColor = System.Drawing.Color.Transparent;
			this.sdRect35.LineColor = System.Drawing.Color.Black;
			this.sdRect35.LineStyle = Report.PenStyle.Solid;
			this.sdRect35.LineWidth = 0F;
			this.sdRect35.Location = new System.Drawing.Point(112, 344);
			this.sdRect35.Name = "sdRect35";
			this.sdRect35.Size = new System.Drawing.Size(368, 136);
			this.sdRect35.TabIndex = 55;
			this.sdRect35.Tag = "0";
			this.sdRect35.Text = "sdRect5";
			// 
			// sdText131
			// 
			this.sdText131.CharSpace = 0F;
			this.sdText131.FontColor = System.Drawing.Color.Black;
			this.sdText131.FontName = Report.SdFontName.TimesRoman;
			this.sdText131.FontSize = 10F;
			this.sdText131.Leading = 12F;
			this.sdText131.Lines = new string[] {
													"The samples of the alignment"};
			this.sdText131.Location = new System.Drawing.Point(112, 328);
			this.sdText131.Name = "sdText131";
			this.sdText131.NodeValue = null;
			this.sdText131.Size = new System.Drawing.Size(368, 16);
			this.sdText131.TabIndex = 54;
			this.sdText131.Tag = "0";
			this.sdText131.WordSpace = 0F;
			// 
			// sdText134
			// 
			this.sdText134.CharSpace = 0F;
			this.sdText134.FontColor = System.Drawing.Color.Black;
			this.sdText134.FontName = Report.SdFontName.TimesRoman;
			this.sdText134.FontSize = 10F;
			this.sdText134.Leading = 12F;
			this.sdText134.Lines = new string[] {
													"Controls the horizontal placement of the text within the label."};
			this.sdText134.Location = new System.Drawing.Point(112, 288);
			this.sdText134.Name = "sdText134";
			this.sdText134.NodeValue = null;
			this.sdText134.Size = new System.Drawing.Size(368, 24);
			this.sdText134.TabIndex = 51;
			this.sdText134.Tag = "0";
			this.sdText134.WordSpace = 0F;
			// 
			// sdText135
			// 
			this.sdText135.CharSpace = 0F;
			this.sdText135.FontColor = System.Drawing.Color.Black;
			this.sdText135.FontName = Report.SdFontName.Arial;
			this.sdText135.FontSize = 10F;
			this.sdText135.Leading = 12F;
			this.sdText135.Lines = new string[] {
													"public Report.SDAlignment Alignment [  get,  set ]"};
			this.sdText135.Location = new System.Drawing.Point(112, 272);
			this.sdText135.Name = "sdText135";
			this.sdText135.NodeValue = null;
			this.sdText135.Size = new System.Drawing.Size(320, 16);
			this.sdText135.TabIndex = 50;
			this.sdText135.Tag = "0";
			this.sdText135.WordSpace = 0F;
			// 
			// sdText136
			// 
			this.sdText136.CharSpace = 0F;
			this.sdText136.FontColor = System.Drawing.Color.Black;
			this.sdText136.FontName = Report.SdFontName.TimesRoman;
			this.sdText136.FontSize = 10F;
			this.sdText136.Leading = 12F;
			this.sdText136.Lines = new string[] {
													"Determines whether adjustment the char width to fit the text to full-justified."};
			this.sdText136.Location = new System.Drawing.Point(112, 248);
			this.sdText136.Name = "sdText136";
			this.sdText136.NodeValue = null;
			this.sdText136.Size = new System.Drawing.Size(368, 24);
			this.sdText136.TabIndex = 49;
			this.sdText136.Tag = "0";
			this.sdText136.WordSpace = 0F;
			// 
			// sdText137
			// 
			this.sdText137.CharSpace = 0F;
			this.sdText137.FontColor = System.Drawing.Color.Black;
			this.sdText137.FontName = Report.SdFontName.Arial;
			this.sdText137.FontSize = 10F;
			this.sdText137.Leading = 12F;
			this.sdText137.Lines = new string[] {
													"public bool AlignJustified [  get,  set ]"};
			this.sdText137.Location = new System.Drawing.Point(112, 232);
			this.sdText137.Name = "sdText137";
			this.sdText137.NodeValue = null;
			this.sdText137.Size = new System.Drawing.Size(320, 16);
			this.sdText137.TabIndex = 48;
			this.sdText137.Tag = "0";
			this.sdText137.WordSpace = 0F;
			// 
			// sdText138
			// 
			this.sdText138.CharSpace = 0F;
			this.sdText138.FontColor = System.Drawing.Color.Black;
			this.sdText138.FontName = Report.SdFontName.TimesRoman;
			this.sdText138.FontSize = 10F;
			this.sdText138.Leading = 12F;
			this.sdText138.Lines = new string[] {
													"Determines how the control aligns within its container (or parent control)."};
			this.sdText138.Location = new System.Drawing.Point(112, 208);
			this.sdText138.Name = "sdText138";
			this.sdText138.NodeValue = null;
			this.sdText138.Size = new System.Drawing.Size(368, 24);
			this.sdText138.TabIndex = 30;
			this.sdText138.Tag = "0";
			this.sdText138.WordSpace = 0F;
			// 
			// sdText139
			// 
			this.sdText139.CharSpace = 0F;
			this.sdText139.FontColor = System.Drawing.Color.Black;
			this.sdText139.FontName = Report.SdFontName.Arial;
			this.sdText139.FontSize = 10F;
			this.sdText139.Leading = 12F;
			this.sdText139.Lines = new string[] {
													"public System.Windows.Forms.DockStyle Dock [  get,  set ]"};
			this.sdText139.Location = new System.Drawing.Point(112, 192);
			this.sdText139.Name = "sdText139";
			this.sdText139.NodeValue = null;
			this.sdText139.Size = new System.Drawing.Size(320, 16);
			this.sdText139.TabIndex = 29;
			this.sdText139.Tag = "0";
			this.sdText139.WordSpace = 0F;
			// 
			// sdText140
			// 
			this.sdText140.CharSpace = 0F;
			this.sdText140.FontBold = true;
			this.sdText140.FontColor = System.Drawing.Color.Black;
			this.sdText140.FontName = Report.SdFontName.Arial;
			this.sdText140.FontSize = 12F;
			this.sdText140.Leading = 14F;
			this.sdText140.Lines = new string[] {
													"2.5.1      SDLabel properties"};
			this.sdText140.Location = new System.Drawing.Point(64, 176);
			this.sdText140.Name = "sdText140";
			this.sdText140.NodeValue = null;
			this.sdText140.Size = new System.Drawing.Size(360, 16);
			this.sdText140.TabIndex = 27;
			this.sdText140.Tag = "4";
			this.sdText140.WordSpace = 0F;
			// 
			// sdText141
			// 
			this.sdText141.CharSpace = 0F;
			this.sdText141.FontColor = System.Drawing.Color.Black;
			this.sdText141.FontName = Report.SdFontName.TimesRoman;
			this.sdText141.FontSize = 10F;
			this.sdText141.Leading = 12F;
			this.sdText141.Lines = new string[] {
													"Use SDLabel to print single line text."};
			this.sdText141.Location = new System.Drawing.Point(112, 120);
			this.sdText141.Name = "sdText141";
			this.sdText141.NodeValue = null;
			this.sdText141.Size = new System.Drawing.Size(376, 24);
			this.sdText141.TabIndex = 26;
			this.sdText141.Tag = "0";
			this.sdText141.WordSpace = 0F;
			// 
			// sdText142
			// 
			this.sdText142.CharSpace = 0F;
			this.sdText142.FontBold = true;
			this.sdText142.FontColor = System.Drawing.Color.Black;
			this.sdText142.FontName = Report.SdFontName.Arial;
			this.sdText142.FontSize = 12F;
			this.sdText142.Leading = 14F;
			this.sdText142.Lines = new string[] {
													"Description"};
			this.sdText142.Location = new System.Drawing.Point(112, 104);
			this.sdText142.Name = "sdText142";
			this.sdText142.NodeValue = null;
			this.sdText142.Size = new System.Drawing.Size(328, 16);
			this.sdText142.TabIndex = 25;
			this.sdText142.Tag = "0";
			this.sdText142.WordSpace = 0F;
			// 
			// sdText143
			// 
			this.sdText143.CharSpace = 0F;
			this.sdText143.FontColor = System.Drawing.Color.Black;
			this.sdText143.FontName = Report.SdFontName.TimesRoman;
			this.sdText143.FontSize = 10F;
			this.sdText143.Leading = 12F;
			this.sdText143.Lines = new string[] {
													"SDLabel is used to print a single line text."};
			this.sdText143.Location = new System.Drawing.Point(112, 80);
			this.sdText143.Name = "sdText143";
			this.sdText143.NodeValue = null;
			this.sdText143.Size = new System.Drawing.Size(328, 24);
			this.sdText143.TabIndex = 24;
			this.sdText143.Tag = "0";
			this.sdText143.WordSpace = 0F;
			// 
			// sdText144
			// 
			this.sdText144.CharSpace = 0F;
			this.sdText144.FontBold = true;
			this.sdText144.FontColor = System.Drawing.Color.Black;
			this.sdText144.FontName = Report.SdFontName.Arial;
			this.sdText144.FontSize = 12F;
			this.sdText144.Leading = 14F;
			this.sdText144.Lines = new string[] {
													"2.5         SDLabel"};
			this.sdText144.Location = new System.Drawing.Point(64, 64);
			this.sdText144.Name = "sdText144";
			this.sdText144.NodeValue = null;
			this.sdText144.Size = new System.Drawing.Size(360, 16);
			this.sdText144.TabIndex = 23;
			this.sdText144.Tag = "3";
			this.sdText144.WordSpace = 0F;
			// 
			// sdLabel15
			// 
			this.sdLabel15.Alignment = Report.SDAlignment.RightJustify;
			this.sdLabel15.CharSpace = 0F;
			this.sdLabel15.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.sdLabel15.FontColor = System.Drawing.Color.Black;
			this.sdLabel15.FontName = Report.SdFontName.Arial;
			this.sdLabel15.FontSize = 8F;
			this.sdLabel15.Location = new System.Drawing.Point(0, 765);
			this.sdLabel15.Name = "sdLabel15";
			this.sdLabel15.Size = new System.Drawing.Size(532, 13);
			this.sdLabel15.TabIndex = 11;
			this.sdLabel15.Tag = "0";
			this.sdLabel15.Text = "copyright (c) 2002-2003 Serdar Dirican";
			this.sdLabel15.WordSpace = 0F;
			// 
			// sdRect36
			// 
			this.sdRect36.FillColor = System.Drawing.Color.Transparent;
			this.sdRect36.LineColor = System.Drawing.Color.Black;
			this.sdRect36.LineStyle = Report.PenStyle.Solid;
			this.sdRect36.LineWidth = 0F;
			this.sdRect36.Location = new System.Drawing.Point(256, 24);
			this.sdRect36.Name = "sdRect36";
			this.sdRect36.Size = new System.Drawing.Size(2, 24);
			this.sdRect36.TabIndex = 10;
			this.sdRect36.Tag = "0";
			this.sdRect36.Text = "sdRect4";
			// 
			// sdRect37
			// 
			this.sdRect37.FillColor = System.Drawing.Color.Transparent;
			this.sdRect37.LineColor = System.Drawing.Color.Black;
			this.sdRect37.LineStyle = Report.PenStyle.Solid;
			this.sdRect37.LineWidth = 0F;
			this.sdRect37.Location = new System.Drawing.Point(440, 24);
			this.sdRect37.Name = "sdRect37";
			this.sdRect37.Size = new System.Drawing.Size(2, 24);
			this.sdRect37.TabIndex = 9;
			this.sdRect37.Tag = "0";
			this.sdRect37.Text = "sdRect3";
			// 
			// sdRect38
			// 
			this.sdRect38.FillColor = System.Drawing.Color.Transparent;
			this.sdRect38.LineColor = System.Drawing.Color.Black;
			this.sdRect38.LineStyle = Report.PenStyle.Solid;
			this.sdRect38.LineWidth = 0F;
			this.sdRect38.Location = new System.Drawing.Point(80, 24);
			this.sdRect38.Name = "sdRect38";
			this.sdRect38.Size = new System.Drawing.Size(2, 24);
			this.sdRect38.TabIndex = 8;
			this.sdRect38.Tag = "0";
			this.sdRect38.Text = "sdRect2";
			// 
			// sdRect39
			// 
			this.sdRect39.DrawLine = true;
			this.sdRect39.FillColor = System.Drawing.Color.Transparent;
			this.sdRect39.LineColor = System.Drawing.Color.Black;
			this.sdRect39.LineStyle = Report.PenStyle.Solid;
			this.sdRect39.LineWidth = 2F;
			this.sdRect39.Location = new System.Drawing.Point(80, 40);
			this.sdRect39.Name = "sdRect39";
			this.sdRect39.Size = new System.Drawing.Size(360, 3);
			this.sdRect39.TabIndex = 7;
			this.sdRect39.Tag = "0";
			this.sdRect39.Text = "sdRect1";
			// 
			// tabPage11
			// 
			this.tabPage11.AutoScroll = true;
			this.tabPage11.Controls.Add(this.sdPage9);
			this.tabPage11.Location = new System.Drawing.Point(4, 58);
			this.tabPage11.Name = "tabPage11";
			this.tabPage11.Size = new System.Drawing.Size(472, 211);
			this.tabPage11.TabIndex = 10;
			this.tabPage11.Text = "SDLabel(2)";
			// 
			// sdPage9
			// 
			this.sdPage9.Controls.Add(this.sdLayoutPanel11);
			this.sdPage9.DockPadding.All = 32;
			this.sdPage9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
			this.sdPage9.Location = new System.Drawing.Point(0, 0);
			this.sdPage9.Name = "sdPage9";
			this.sdPage9.Size = new System.Drawing.Size(596, 842);
			this.sdPage9.TabIndex = 1;
			this.sdPage9.Text = "sdPage9";
			// 
			// sdLayoutPanel11
			// 
			this.sdLayoutPanel11.BackColor = System.Drawing.SystemColors.Window;
			this.sdLayoutPanel11.Controls.Add(this.sdText145);
			this.sdLayoutPanel11.Controls.Add(this.sdText146);
			this.sdLayoutPanel11.Controls.Add(this.sdText147);
			this.sdLayoutPanel11.Controls.Add(this.sdText148);
			this.sdLayoutPanel11.Controls.Add(this.sdText149);
			this.sdLayoutPanel11.Controls.Add(this.sdText150);
			this.sdLayoutPanel11.Controls.Add(this.sdText151);
			this.sdLayoutPanel11.Controls.Add(this.sdText152);
			this.sdLayoutPanel11.Controls.Add(this.sdText153);
			this.sdLayoutPanel11.Controls.Add(this.sdText154);
			this.sdLayoutPanel11.Controls.Add(this.sdRect40);
			this.sdLayoutPanel11.Controls.Add(this.sdText155);
			this.sdLayoutPanel11.Controls.Add(this.sdText156);
			this.sdLayoutPanel11.Controls.Add(this.sdText157);
			this.sdLayoutPanel11.Controls.Add(this.sdLabel16);
			this.sdLayoutPanel11.Controls.Add(this.sdRect41);
			this.sdLayoutPanel11.Controls.Add(this.sdRect42);
			this.sdLayoutPanel11.Controls.Add(this.sdRect43);
			this.sdLayoutPanel11.Controls.Add(this.sdRect44);
			this.sdLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sdLayoutPanel11.Location = new System.Drawing.Point(32, 32);
			this.sdLayoutPanel11.Name = "sdLayoutPanel11";
			this.sdLayoutPanel11.Size = new System.Drawing.Size(532, 778);
			this.sdLayoutPanel11.TabIndex = 0;
			this.sdLayoutPanel11.Text = "sdLayoutPanel1";
			this.sdLayoutPanel11.BeforePrint += new Report.SDPrintPanelEvent(this.sdlayotupanel_BeforePrint);
			// 
			// sdText145
			// 
			this.sdText145.CharSpace = 0F;
			this.sdText145.FontColor = System.Drawing.Color.Black;
			this.sdText145.FontName = Report.SdFontName.TimesRoman;
			this.sdText145.FontSize = 10F;
			this.sdText145.Leading = 12F;
			this.sdText145.Lines = new string[] {
													"Specifies whether the font is boldfaced or not."};
			this.sdText145.Location = new System.Drawing.Point(112, 320);
			this.sdText145.Name = "sdText145";
			this.sdText145.NodeValue = null;
			this.sdText145.Size = new System.Drawing.Size(368, 24);
			this.sdText145.TabIndex = 42;
			this.sdText145.Tag = "0";
			this.sdText145.WordSpace = 0F;
			// 
			// sdText146
			// 
			this.sdText146.CharSpace = 0F;
			this.sdText146.FontColor = System.Drawing.Color.Black;
			this.sdText146.FontName = Report.SdFontName.Arial;
			this.sdText146.FontSize = 10F;
			this.sdText146.Leading = 12F;
			this.sdText146.Lines = new string[] {
													"public bool FontBold [  get,  set ]"};
			this.sdText146.Location = new System.Drawing.Point(112, 304);
			this.sdText146.Name = "sdText146";
			this.sdText146.NodeValue = null;
			this.sdText146.Size = new System.Drawing.Size(320, 16);
			this.sdText146.TabIndex = 41;
			this.sdText146.Tag = "0";
			this.sdText146.WordSpace = 0F;
			// 
			// sdText147
			// 
			this.sdText147.CharSpace = 0F;
			this.sdText147.FontColor = System.Drawing.Color.Black;
			this.sdText147.FontName = Report.SdFontName.TimesRoman;
			this.sdText147.FontSize = 10F;
			this.sdText147.Leading = 12F;
			this.sdText147.Lines = new string[] {
													"Specifies the height of the font in points."};
			this.sdText147.Location = new System.Drawing.Point(112, 280);
			this.sdText147.Name = "sdText147";
			this.sdText147.NodeValue = null;
			this.sdText147.Size = new System.Drawing.Size(368, 24);
			this.sdText147.TabIndex = 40;
			this.sdText147.Tag = "0";
			this.sdText147.WordSpace = 0F;
			// 
			// sdText148
			// 
			this.sdText148.CharSpace = 0F;
			this.sdText148.FontColor = System.Drawing.Color.Black;
			this.sdText148.FontName = Report.SdFontName.Arial;
			this.sdText148.FontSize = 10F;
			this.sdText148.Leading = 12F;
			this.sdText148.Lines = new string[] {
													"public float FontSize [  get,  set ]"};
			this.sdText148.Location = new System.Drawing.Point(112, 264);
			this.sdText148.Name = "sdText148";
			this.sdText148.NodeValue = null;
			this.sdText148.Size = new System.Drawing.Size(320, 16);
			this.sdText148.TabIndex = 39;
			this.sdText148.Tag = "0";
			this.sdText148.WordSpace = 0F;
			// 
			// sdText149
			// 
			this.sdText149.CharSpace = 0F;
			this.sdText149.FontColor = System.Drawing.Color.Black;
			this.sdText149.FontName = Report.SdFontName.FixedWidth;
			this.sdText149.FontSize = 14F;
			this.sdText149.Leading = 12F;
			this.sdText149.Lines = new string[] {
													"ABCDEFGabcdefg12345"};
			this.sdText149.Location = new System.Drawing.Point(120, 224);
			this.sdText149.Name = "sdText149";
			this.sdText149.NodeValue = null;
			this.sdText149.Size = new System.Drawing.Size(192, 16);
			this.sdText149.TabIndex = 38;
			this.sdText149.Tag = "0";
			this.sdText149.WordSpace = 0F;
			// 
			// sdText150
			// 
			this.sdText150.CharSpace = 0F;
			this.sdText150.FontColor = System.Drawing.Color.Black;
			this.sdText150.FontName = Report.SdFontName.Arial;
			this.sdText150.FontSize = 9F;
			this.sdText150.Leading = 12F;
			this.sdText150.Lines = new string[] {
													"FixedWidth"};
			this.sdText150.Location = new System.Drawing.Point(120, 208);
			this.sdText150.Name = "sdText150";
			this.sdText150.NodeValue = null;
			this.sdText150.Size = new System.Drawing.Size(192, 16);
			this.sdText150.TabIndex = 37;
			this.sdText150.Tag = "0";
			this.sdText150.WordSpace = 0F;
			// 
			// sdText151
			// 
			this.sdText151.CharSpace = 0F;
			this.sdText151.FontColor = System.Drawing.Color.Black;
			this.sdText151.FontName = Report.SdFontName.TimesRoman;
			this.sdText151.FontSize = 14F;
			this.sdText151.Leading = 12F;
			this.sdText151.Lines = new string[] {
													"ABCDEFGabcdefg12345"};
			this.sdText151.Location = new System.Drawing.Point(120, 192);
			this.sdText151.Name = "sdText151";
			this.sdText151.NodeValue = null;
			this.sdText151.Size = new System.Drawing.Size(192, 16);
			this.sdText151.TabIndex = 36;
			this.sdText151.Tag = "0";
			this.sdText151.WordSpace = 0F;
			// 
			// sdText152
			// 
			this.sdText152.CharSpace = 0F;
			this.sdText152.FontColor = System.Drawing.Color.Black;
			this.sdText152.FontName = Report.SdFontName.Arial;
			this.sdText152.FontSize = 9F;
			this.sdText152.Leading = 12F;
			this.sdText152.Lines = new string[] {
													"TimesRoman"};
			this.sdText152.Location = new System.Drawing.Point(120, 176);
			this.sdText152.Name = "sdText152";
			this.sdText152.NodeValue = null;
			this.sdText152.Size = new System.Drawing.Size(192, 16);
			this.sdText152.TabIndex = 35;
			this.sdText152.Tag = "0";
			this.sdText152.WordSpace = 0F;
			// 
			// sdText153
			// 
			this.sdText153.CharSpace = 0F;
			this.sdText153.FontColor = System.Drawing.Color.Black;
			this.sdText153.FontName = Report.SdFontName.Arial;
			this.sdText153.FontSize = 14F;
			this.sdText153.Leading = 12F;
			this.sdText153.Lines = new string[] {
													"ABCDEFGabcdefg12345"};
			this.sdText153.Location = new System.Drawing.Point(120, 160);
			this.sdText153.Name = "sdText153";
			this.sdText153.NodeValue = null;
			this.sdText153.Size = new System.Drawing.Size(192, 16);
			this.sdText153.TabIndex = 34;
			this.sdText153.Tag = "0";
			this.sdText153.WordSpace = 0F;
			// 
			// sdText154
			// 
			this.sdText154.CharSpace = 0F;
			this.sdText154.FontColor = System.Drawing.Color.Black;
			this.sdText154.FontName = Report.SdFontName.Arial;
			this.sdText154.FontSize = 9F;
			this.sdText154.Leading = 12F;
			this.sdText154.Lines = new string[] {
													"Arial"};
			this.sdText154.Location = new System.Drawing.Point(120, 144);
			this.sdText154.Name = "sdText154";
			this.sdText154.NodeValue = null;
			this.sdText154.Size = new System.Drawing.Size(192, 16);
			this.sdText154.TabIndex = 33;
			this.sdText154.Tag = "0";
			this.sdText154.WordSpace = 0F;
			// 
			// sdRect40
			// 
			this.sdRect40.FillColor = System.Drawing.Color.Transparent;
			this.sdRect40.LineColor = System.Drawing.Color.Black;
			this.sdRect40.LineStyle = Report.PenStyle.Solid;
			this.sdRect40.LineWidth = 0F;
			this.sdRect40.Location = new System.Drawing.Point(112, 136);
			this.sdRect40.Name = "sdRect40";
			this.sdRect40.Size = new System.Drawing.Size(208, 112);
			this.sdRect40.TabIndex = 32;
			this.sdRect40.Tag = "0";
			this.sdRect40.Text = "sdRect5";
			// 
			// sdText155
			// 
			this.sdText155.CharSpace = 0F;
			this.sdText155.FontColor = System.Drawing.Color.Black;
			this.sdText155.FontName = Report.SdFontName.Arial;
			this.sdText155.FontSize = 10F;
			this.sdText155.Leading = 12F;
			this.sdText155.Lines = new string[] {
													"SDFontName = (FixedWidth, Arial, TimesRoman);"};
			this.sdText155.Location = new System.Drawing.Point(112, 112);
			this.sdText155.Name = "sdText155";
			this.sdText155.NodeValue = null;
			this.sdText155.Size = new System.Drawing.Size(320, 16);
			this.sdText155.TabIndex = 31;
			this.sdText155.Tag = "0";
			this.sdText155.WordSpace = 0F;
			// 
			// sdText156
			// 
			this.sdText156.CharSpace = 0F;
			this.sdText156.FontColor = System.Drawing.Color.Black;
			this.sdText156.FontName = Report.SdFontName.TimesRoman;
			this.sdText156.FontSize = 10F;
			this.sdText156.Leading = 12F;
			this.sdText156.Lines = new string[] {
													"Identifies the typeface of the font."};
			this.sdText156.Location = new System.Drawing.Point(112, 80);
			this.sdText156.Name = "sdText156";
			this.sdText156.NodeValue = null;
			this.sdText156.Size = new System.Drawing.Size(368, 24);
			this.sdText156.TabIndex = 30;
			this.sdText156.Tag = "0";
			this.sdText156.WordSpace = 0F;
			// 
			// sdText157
			// 
			this.sdText157.CharSpace = 0F;
			this.sdText157.FontColor = System.Drawing.Color.Black;
			this.sdText157.FontName = Report.SdFontName.Arial;
			this.sdText157.FontSize = 10F;
			this.sdText157.Leading = 12F;
			this.sdText157.Lines = new string[] {
													"public Report.SdFontName FontName [  get,  set ]"};
			this.sdText157.Location = new System.Drawing.Point(112, 64);
			this.sdText157.Name = "sdText157";
			this.sdText157.NodeValue = null;
			this.sdText157.Size = new System.Drawing.Size(320, 16);
			this.sdText157.TabIndex = 29;
			this.sdText157.Tag = "0";
			this.sdText157.WordSpace = 0F;
			// 
			// sdLabel16
			// 
			this.sdLabel16.Alignment = Report.SDAlignment.RightJustify;
			this.sdLabel16.CharSpace = 0F;
			this.sdLabel16.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.sdLabel16.FontColor = System.Drawing.Color.Black;
			this.sdLabel16.FontName = Report.SdFontName.Arial;
			this.sdLabel16.FontSize = 8F;
			this.sdLabel16.Location = new System.Drawing.Point(0, 765);
			this.sdLabel16.Name = "sdLabel16";
			this.sdLabel16.Size = new System.Drawing.Size(532, 13);
			this.sdLabel16.TabIndex = 11;
			this.sdLabel16.Tag = "0";
			this.sdLabel16.Text = "copyright (c) 2002-2003 Serdar Dirican";
			this.sdLabel16.WordSpace = 0F;
			// 
			// sdRect41
			// 
			this.sdRect41.FillColor = System.Drawing.Color.Transparent;
			this.sdRect41.LineColor = System.Drawing.Color.Black;
			this.sdRect41.LineStyle = Report.PenStyle.Solid;
			this.sdRect41.LineWidth = 0F;
			this.sdRect41.Location = new System.Drawing.Point(256, 24);
			this.sdRect41.Name = "sdRect41";
			this.sdRect41.Size = new System.Drawing.Size(2, 24);
			this.sdRect41.TabIndex = 10;
			this.sdRect41.Tag = "0";
			this.sdRect41.Text = "sdRect4";
			// 
			// sdRect42
			// 
			this.sdRect42.FillColor = System.Drawing.Color.Transparent;
			this.sdRect42.LineColor = System.Drawing.Color.Black;
			this.sdRect42.LineStyle = Report.PenStyle.Solid;
			this.sdRect42.LineWidth = 0F;
			this.sdRect42.Location = new System.Drawing.Point(440, 24);
			this.sdRect42.Name = "sdRect42";
			this.sdRect42.Size = new System.Drawing.Size(2, 24);
			this.sdRect42.TabIndex = 9;
			this.sdRect42.Tag = "0";
			this.sdRect42.Text = "sdRect3";
			// 
			// sdRect43
			// 
			this.sdRect43.FillColor = System.Drawing.Color.Transparent;
			this.sdRect43.LineColor = System.Drawing.Color.Black;
			this.sdRect43.LineStyle = Report.PenStyle.Solid;
			this.sdRect43.LineWidth = 0F;
			this.sdRect43.Location = new System.Drawing.Point(80, 24);
			this.sdRect43.Name = "sdRect43";
			this.sdRect43.Size = new System.Drawing.Size(2, 24);
			this.sdRect43.TabIndex = 8;
			this.sdRect43.Tag = "0";
			this.sdRect43.Text = "sdRect2";
			// 
			// sdRect44
			// 
			this.sdRect44.DrawLine = true;
			this.sdRect44.FillColor = System.Drawing.Color.Transparent;
			this.sdRect44.LineColor = System.Drawing.Color.Black;
			this.sdRect44.LineStyle = Report.PenStyle.Solid;
			this.sdRect44.LineWidth = 2F;
			this.sdRect44.Location = new System.Drawing.Point(80, 40);
			this.sdRect44.Name = "sdRect44";
			this.sdRect44.Size = new System.Drawing.Size(360, 3);
			this.sdRect44.TabIndex = 7;
			this.sdRect44.Tag = "0";
			this.sdRect44.Text = "sdRect1";
			// 
			// tabPage12
			// 
			this.tabPage12.AutoScroll = true;
			this.tabPage12.Controls.Add(this.sdPage10);
			this.tabPage12.Location = new System.Drawing.Point(4, 58);
			this.tabPage12.Name = "tabPage12";
			this.tabPage12.Size = new System.Drawing.Size(472, 211);
			this.tabPage12.TabIndex = 11;
			this.tabPage12.Text = "SDText";
			// 
			// sdPage10
			// 
			this.sdPage10.Controls.Add(this.sdLayoutPanel12);
			this.sdPage10.DockPadding.All = 32;
			this.sdPage10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
			this.sdPage10.Location = new System.Drawing.Point(0, 0);
			this.sdPage10.Name = "sdPage10";
			this.sdPage10.Size = new System.Drawing.Size(596, 842);
			this.sdPage10.TabIndex = 3;
			this.sdPage10.Text = "sdPage10";
			// 
			// sdLayoutPanel12
			// 
			this.sdLayoutPanel12.BackColor = System.Drawing.SystemColors.Window;
			this.sdLayoutPanel12.Controls.Add(this.sdText132);
			this.sdLayoutPanel12.Controls.Add(this.sdText133);
			this.sdLayoutPanel12.Controls.Add(this.sdText158);
			this.sdLayoutPanel12.Controls.Add(this.sdText159);
			this.sdLayoutPanel12.Controls.Add(this.sdText160);
			this.sdLayoutPanel12.Controls.Add(this.sdText161);
			this.sdLayoutPanel12.Controls.Add(this.sdText162);
			this.sdLayoutPanel12.Controls.Add(this.sdText163);
			this.sdLayoutPanel12.Controls.Add(this.sdText164);
			this.sdLayoutPanel12.Controls.Add(this.sdText165);
			this.sdLayoutPanel12.Controls.Add(this.sdText166);
			this.sdLayoutPanel12.Controls.Add(this.sdText167);
			this.sdLayoutPanel12.Controls.Add(this.sdText168);
			this.sdLayoutPanel12.Controls.Add(this.sdText169);
			this.sdLayoutPanel12.Controls.Add(this.sdText170);
			this.sdLayoutPanel12.Controls.Add(this.sdText171);
			this.sdLayoutPanel12.Controls.Add(this.sdText172);
			this.sdLayoutPanel12.Controls.Add(this.sdText173);
			this.sdLayoutPanel12.Controls.Add(this.sdText174);
			this.sdLayoutPanel12.Controls.Add(this.sdText175);
			this.sdLayoutPanel12.Controls.Add(this.sdText176);
			this.sdLayoutPanel12.Controls.Add(this.sdText177);
			this.sdLayoutPanel12.Controls.Add(this.sdText178);
			this.sdLayoutPanel12.Controls.Add(this.sdText179);
			this.sdLayoutPanel12.Controls.Add(this.sdText180);
			this.sdLayoutPanel12.Controls.Add(this.sdLabel17);
			this.sdLayoutPanel12.Controls.Add(this.sdRect45);
			this.sdLayoutPanel12.Controls.Add(this.sdRect46);
			this.sdLayoutPanel12.Controls.Add(this.sdRect47);
			this.sdLayoutPanel12.Controls.Add(this.sdRect48);
			this.sdLayoutPanel12.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sdLayoutPanel12.Location = new System.Drawing.Point(32, 32);
			this.sdLayoutPanel12.Name = "sdLayoutPanel12";
			this.sdLayoutPanel12.Size = new System.Drawing.Size(532, 778);
			this.sdLayoutPanel12.TabIndex = 0;
			this.sdLayoutPanel12.Text = "sdLayoutPanel1";
			this.sdLayoutPanel12.BeforePrint += new Report.SDPrintPanelEvent(this.sdlayotupanel_BeforePrint);
			// 
			// sdText132
			// 
			this.sdText132.CharSpace = 0F;
			this.sdText132.FontColor = System.Drawing.Color.Black;
			this.sdText132.FontName = Report.SdFontName.TimesRoman;
			this.sdText132.FontSize = 10F;
			this.sdText132.Leading = 12F;
			this.sdText132.Lines = new string[] {
													"Determines whether the text inserts soft carriage returns so text wraps at the ri" +
													"ght",
													"margin."};
			this.sdText132.Location = new System.Drawing.Point(112, 568);
			this.sdText132.Name = "sdText132";
			this.sdText132.NodeValue = null;
			this.sdText132.Size = new System.Drawing.Size(368, 24);
			this.sdText132.TabIndex = 81;
			this.sdText132.Tag = "0";
			this.sdText132.WordSpace = 0F;
			// 
			// sdText133
			// 
			this.sdText133.CharSpace = 0F;
			this.sdText133.FontColor = System.Drawing.Color.Black;
			this.sdText133.FontName = Report.SdFontName.Arial;
			this.sdText133.FontSize = 10F;
			this.sdText133.Leading = 12F;
			this.sdText133.Lines = new string[] {
													"public bool WordWrap [  get,  set ]"};
			this.sdText133.Location = new System.Drawing.Point(112, 552);
			this.sdText133.Name = "sdText133";
			this.sdText133.NodeValue = null;
			this.sdText133.Size = new System.Drawing.Size(320, 16);
			this.sdText133.TabIndex = 80;
			this.sdText133.Tag = "0";
			this.sdText133.WordSpace = 0F;
			// 
			// sdText158
			// 
			this.sdText158.CharSpace = 0F;
			this.sdText158.FontColor = System.Drawing.Color.Black;
			this.sdText158.FontName = Report.SdFontName.TimesRoman;
			this.sdText158.FontSize = 10F;
			this.sdText158.Leading = 12F;
			this.sdText158.Lines = new string[] {
													"Specifies the word spacing of the text."};
			this.sdText158.Location = new System.Drawing.Point(112, 528);
			this.sdText158.Name = "sdText158";
			this.sdText158.NodeValue = null;
			this.sdText158.Size = new System.Drawing.Size(368, 24);
			this.sdText158.TabIndex = 79;
			this.sdText158.Tag = "0";
			this.sdText158.WordSpace = 0F;
			// 
			// sdText159
			// 
			this.sdText159.CharSpace = 0F;
			this.sdText159.FontColor = System.Drawing.Color.Black;
			this.sdText159.FontName = Report.SdFontName.Arial;
			this.sdText159.FontSize = 10F;
			this.sdText159.Leading = 12F;
			this.sdText159.Lines = new string[] {
													"public float WordSpace [  get,  set ]"};
			this.sdText159.Location = new System.Drawing.Point(112, 512);
			this.sdText159.Name = "sdText159";
			this.sdText159.NodeValue = null;
			this.sdText159.Size = new System.Drawing.Size(320, 16);
			this.sdText159.TabIndex = 78;
			this.sdText159.Tag = "0";
			this.sdText159.WordSpace = 0F;
			// 
			// sdText160
			// 
			this.sdText160.CharSpace = 0F;
			this.sdText160.FontColor = System.Drawing.Color.Black;
			this.sdText160.FontName = Report.SdFontName.TimesRoman;
			this.sdText160.FontSize = 10F;
			this.sdText160.Leading = 12F;
			this.sdText160.Lines = new string[] {
													"Contains the individual lines of text."};
			this.sdText160.Location = new System.Drawing.Point(112, 488);
			this.sdText160.Name = "sdText160";
			this.sdText160.NodeValue = null;
			this.sdText160.Size = new System.Drawing.Size(368, 24);
			this.sdText160.TabIndex = 77;
			this.sdText160.Tag = "0";
			this.sdText160.WordSpace = 0F;
			// 
			// sdText161
			// 
			this.sdText161.CharSpace = 0F;
			this.sdText161.FontColor = System.Drawing.Color.Black;
			this.sdText161.FontName = Report.SdFontName.Arial;
			this.sdText161.FontSize = 10F;
			this.sdText161.Leading = 12F;
			this.sdText161.Lines = new string[] {
													"public string[] Lines [  get,  set ]"};
			this.sdText161.Location = new System.Drawing.Point(112, 472);
			this.sdText161.Name = "sdText161";
			this.sdText161.NodeValue = null;
			this.sdText161.Size = new System.Drawing.Size(320, 16);
			this.sdText161.TabIndex = 76;
			this.sdText161.Tag = "0";
			this.sdText161.WordSpace = 0F;
			// 
			// sdText162
			// 
			this.sdText162.CharSpace = 0F;
			this.sdText162.FontColor = System.Drawing.Color.Black;
			this.sdText162.FontName = Report.SdFontName.TimesRoman;
			this.sdText162.FontSize = 10F;
			this.sdText162.Leading = 12F;
			this.sdText162.Lines = new string[] {
													"Specifies the text leading."};
			this.sdText162.Location = new System.Drawing.Point(112, 448);
			this.sdText162.Name = "sdText162";
			this.sdText162.NodeValue = null;
			this.sdText162.Size = new System.Drawing.Size(368, 24);
			this.sdText162.TabIndex = 75;
			this.sdText162.Tag = "0";
			this.sdText162.WordSpace = 0F;
			// 
			// sdText163
			// 
			this.sdText163.CharSpace = 0F;
			this.sdText163.FontColor = System.Drawing.Color.Black;
			this.sdText163.FontName = Report.SdFontName.Arial;
			this.sdText163.FontSize = 10F;
			this.sdText163.Leading = 12F;
			this.sdText163.Lines = new string[] {
													"public float Leading [  get,  set ]"};
			this.sdText163.Location = new System.Drawing.Point(112, 432);
			this.sdText163.Name = "sdText163";
			this.sdText163.NodeValue = null;
			this.sdText163.Size = new System.Drawing.Size(320, 16);
			this.sdText163.TabIndex = 74;
			this.sdText163.Tag = "0";
			this.sdText163.WordSpace = 0F;
			// 
			// sdText164
			// 
			this.sdText164.CharSpace = 0F;
			this.sdText164.FontColor = System.Drawing.Color.Black;
			this.sdText164.FontName = Report.SdFontName.TimesRoman;
			this.sdText164.FontSize = 10F;
			this.sdText164.Leading = 12F;
			this.sdText164.Lines = new string[] {
													"Specifies whether the font is boldfaced or not."};
			this.sdText164.Location = new System.Drawing.Point(112, 408);
			this.sdText164.Name = "sdText164";
			this.sdText164.NodeValue = null;
			this.sdText164.Size = new System.Drawing.Size(368, 24);
			this.sdText164.TabIndex = 73;
			this.sdText164.Tag = "0";
			this.sdText164.WordSpace = 0F;
			// 
			// sdText165
			// 
			this.sdText165.CharSpace = 0F;
			this.sdText165.FontColor = System.Drawing.Color.Black;
			this.sdText165.FontName = Report.SdFontName.Arial;
			this.sdText165.FontSize = 10F;
			this.sdText165.Leading = 12F;
			this.sdText165.Lines = new string[] {
													"public bool FontBold [  get,  set ]"};
			this.sdText165.Location = new System.Drawing.Point(112, 392);
			this.sdText165.Name = "sdText165";
			this.sdText165.NodeValue = null;
			this.sdText165.Size = new System.Drawing.Size(320, 16);
			this.sdText165.TabIndex = 72;
			this.sdText165.Tag = "0";
			this.sdText165.WordSpace = 0F;
			// 
			// sdText166
			// 
			this.sdText166.CharSpace = 0F;
			this.sdText166.FontColor = System.Drawing.Color.Black;
			this.sdText166.FontName = Report.SdFontName.TimesRoman;
			this.sdText166.FontSize = 10F;
			this.sdText166.Leading = 12F;
			this.sdText166.Lines = new string[] {
													"Specifies the height of the font in points."};
			this.sdText166.Location = new System.Drawing.Point(112, 368);
			this.sdText166.Name = "sdText166";
			this.sdText166.NodeValue = null;
			this.sdText166.Size = new System.Drawing.Size(368, 24);
			this.sdText166.TabIndex = 71;
			this.sdText166.Tag = "0";
			this.sdText166.WordSpace = 0F;
			// 
			// sdText167
			// 
			this.sdText167.CharSpace = 0F;
			this.sdText167.FontColor = System.Drawing.Color.Black;
			this.sdText167.FontName = Report.SdFontName.Arial;
			this.sdText167.FontSize = 10F;
			this.sdText167.Leading = 12F;
			this.sdText167.Lines = new string[] {
													"public float FontSize [  get,  set ]"};
			this.sdText167.Location = new System.Drawing.Point(112, 352);
			this.sdText167.Name = "sdText167";
			this.sdText167.NodeValue = null;
			this.sdText167.Size = new System.Drawing.Size(320, 16);
			this.sdText167.TabIndex = 70;
			this.sdText167.Tag = "0";
			this.sdText167.WordSpace = 0F;
			// 
			// sdText168
			// 
			this.sdText168.CharSpace = 0F;
			this.sdText168.FontColor = System.Drawing.Color.Black;
			this.sdText168.FontName = Report.SdFontName.TimesRoman;
			this.sdText168.FontSize = 10F;
			this.sdText168.Leading = 12F;
			this.sdText168.Lines = new string[] {
													"Identifies the typeface of the font."};
			this.sdText168.Location = new System.Drawing.Point(112, 328);
			this.sdText168.Name = "sdText168";
			this.sdText168.NodeValue = null;
			this.sdText168.Size = new System.Drawing.Size(368, 24);
			this.sdText168.TabIndex = 69;
			this.sdText168.Tag = "0";
			this.sdText168.WordSpace = 0F;
			// 
			// sdText169
			// 
			this.sdText169.CharSpace = 0F;
			this.sdText169.FontColor = System.Drawing.Color.Black;
			this.sdText169.FontName = Report.SdFontName.Arial;
			this.sdText169.FontSize = 10F;
			this.sdText169.Leading = 12F;
			this.sdText169.Lines = new string[] {
													"public Report.SdFontName FontName [  get,  set ]"};
			this.sdText169.Location = new System.Drawing.Point(112, 312);
			this.sdText169.Name = "sdText169";
			this.sdText169.NodeValue = null;
			this.sdText169.Size = new System.Drawing.Size(320, 16);
			this.sdText169.TabIndex = 68;
			this.sdText169.Tag = "0";
			this.sdText169.WordSpace = 0F;
			// 
			// sdText170
			// 
			this.sdText170.CharSpace = 0F;
			this.sdText170.FontColor = System.Drawing.Color.Black;
			this.sdText170.FontName = Report.SdFontName.TimesRoman;
			this.sdText170.FontSize = 10F;
			this.sdText170.Leading = 12F;
			this.sdText170.Lines = new string[] {
													"Specifies the color of the text."};
			this.sdText170.Location = new System.Drawing.Point(112, 288);
			this.sdText170.Name = "sdText170";
			this.sdText170.NodeValue = null;
			this.sdText170.Size = new System.Drawing.Size(368, 24);
			this.sdText170.TabIndex = 67;
			this.sdText170.Tag = "0";
			this.sdText170.WordSpace = 0F;
			// 
			// sdText171
			// 
			this.sdText171.CharSpace = 0F;
			this.sdText171.FontColor = System.Drawing.Color.Black;
			this.sdText171.FontName = Report.SdFontName.Arial;
			this.sdText171.FontSize = 10F;
			this.sdText171.Leading = 12F;
			this.sdText171.Lines = new string[] {
													"public System.Drawing.Color FontColor [  get,  set ]"};
			this.sdText171.Location = new System.Drawing.Point(112, 272);
			this.sdText171.Name = "sdText171";
			this.sdText171.NodeValue = null;
			this.sdText171.Size = new System.Drawing.Size(320, 16);
			this.sdText171.TabIndex = 66;
			this.sdText171.Tag = "0";
			this.sdText171.WordSpace = 0F;
			// 
			// sdText172
			// 
			this.sdText172.CharSpace = 0F;
			this.sdText172.FontColor = System.Drawing.Color.Black;
			this.sdText172.FontName = Report.SdFontName.TimesRoman;
			this.sdText172.FontSize = 10F;
			this.sdText172.Leading = 12F;
			this.sdText172.Lines = new string[] {
													"Determines whether the control will be printed or not."};
			this.sdText172.Location = new System.Drawing.Point(112, 248);
			this.sdText172.Name = "sdText172";
			this.sdText172.NodeValue = null;
			this.sdText172.Size = new System.Drawing.Size(368, 24);
			this.sdText172.TabIndex = 65;
			this.sdText172.Tag = "0";
			this.sdText172.WordSpace = 0F;
			// 
			// sdText173
			// 
			this.sdText173.CharSpace = 0F;
			this.sdText173.FontColor = System.Drawing.Color.Black;
			this.sdText173.FontName = Report.SdFontName.Arial;
			this.sdText173.FontSize = 10F;
			this.sdText173.Leading = 12F;
			this.sdText173.Lines = new string[] {
													"public bool Printable [  get,  set ]"};
			this.sdText173.Location = new System.Drawing.Point(112, 232);
			this.sdText173.Name = "sdText173";
			this.sdText173.NodeValue = null;
			this.sdText173.Size = new System.Drawing.Size(320, 16);
			this.sdText173.TabIndex = 64;
			this.sdText173.Tag = "0";
			this.sdText173.WordSpace = 0F;
			// 
			// sdText174
			// 
			this.sdText174.CharSpace = 0F;
			this.sdText174.FontColor = System.Drawing.Color.Black;
			this.sdText174.FontName = Report.SdFontName.TimesRoman;
			this.sdText174.FontSize = 10F;
			this.sdText174.Leading = 12F;
			this.sdText174.Lines = new string[] {
													"Determines how the control aligns within its container (or parent control)."};
			this.sdText174.Location = new System.Drawing.Point(112, 208);
			this.sdText174.Name = "sdText174";
			this.sdText174.NodeValue = null;
			this.sdText174.Size = new System.Drawing.Size(368, 24);
			this.sdText174.TabIndex = 30;
			this.sdText174.Tag = "0";
			this.sdText174.WordSpace = 0F;
			// 
			// sdText175
			// 
			this.sdText175.CharSpace = 0F;
			this.sdText175.FontColor = System.Drawing.Color.Black;
			this.sdText175.FontName = Report.SdFontName.Arial;
			this.sdText175.FontSize = 10F;
			this.sdText175.Leading = 12F;
			this.sdText175.Lines = new string[] {
													"public System.Windows.Forms.DockStyle Dock [  get,  set ]"};
			this.sdText175.Location = new System.Drawing.Point(112, 192);
			this.sdText175.Name = "sdText175";
			this.sdText175.NodeValue = null;
			this.sdText175.Size = new System.Drawing.Size(320, 16);
			this.sdText175.TabIndex = 29;
			this.sdText175.Tag = "0";
			this.sdText175.WordSpace = 0F;
			// 
			// sdText176
			// 
			this.sdText176.CharSpace = 0F;
			this.sdText176.FontBold = true;
			this.sdText176.FontColor = System.Drawing.Color.Black;
			this.sdText176.FontName = Report.SdFontName.Arial;
			this.sdText176.FontSize = 12F;
			this.sdText176.Leading = 14F;
			this.sdText176.Lines = new string[] {
													"2.6.1      SDText properties"};
			this.sdText176.Location = new System.Drawing.Point(64, 176);
			this.sdText176.Name = "sdText176";
			this.sdText176.NodeValue = null;
			this.sdText176.Size = new System.Drawing.Size(360, 16);
			this.sdText176.TabIndex = 27;
			this.sdText176.Tag = "4";
			this.sdText176.WordSpace = 0F;
			// 
			// sdText177
			// 
			this.sdText177.CharSpace = 0F;
			this.sdText177.FontColor = System.Drawing.Color.Black;
			this.sdText177.FontName = Report.SdFontName.TimesRoman;
			this.sdText177.FontSize = 10F;
			this.sdText177.Leading = 12F;
			this.sdText177.Lines = new string[] {
													"Use SDText to print text."};
			this.sdText177.Location = new System.Drawing.Point(112, 120);
			this.sdText177.Name = "sdText177";
			this.sdText177.NodeValue = null;
			this.sdText177.Size = new System.Drawing.Size(376, 24);
			this.sdText177.TabIndex = 26;
			this.sdText177.Tag = "0";
			this.sdText177.WordSpace = 0F;
			// 
			// sdText178
			// 
			this.sdText178.CharSpace = 0F;
			this.sdText178.FontBold = true;
			this.sdText178.FontColor = System.Drawing.Color.Black;
			this.sdText178.FontName = Report.SdFontName.Arial;
			this.sdText178.FontSize = 12F;
			this.sdText178.Leading = 14F;
			this.sdText178.Lines = new string[] {
													"Description"};
			this.sdText178.Location = new System.Drawing.Point(112, 104);
			this.sdText178.Name = "sdText178";
			this.sdText178.NodeValue = null;
			this.sdText178.Size = new System.Drawing.Size(328, 16);
			this.sdText178.TabIndex = 25;
			this.sdText178.Tag = "0";
			this.sdText178.WordSpace = 0F;
			// 
			// sdText179
			// 
			this.sdText179.CharSpace = 0F;
			this.sdText179.FontColor = System.Drawing.Color.Black;
			this.sdText179.FontName = Report.SdFontName.TimesRoman;
			this.sdText179.FontSize = 10F;
			this.sdText179.Leading = 12F;
			this.sdText179.Lines = new string[] {
													"SDText is used to print a text."};
			this.sdText179.Location = new System.Drawing.Point(112, 80);
			this.sdText179.Name = "sdText179";
			this.sdText179.NodeValue = null;
			this.sdText179.Size = new System.Drawing.Size(328, 24);
			this.sdText179.TabIndex = 24;
			this.sdText179.Tag = "0";
			this.sdText179.WordSpace = 0F;
			// 
			// sdText180
			// 
			this.sdText180.CharSpace = 0F;
			this.sdText180.FontBold = true;
			this.sdText180.FontColor = System.Drawing.Color.Black;
			this.sdText180.FontName = Report.SdFontName.Arial;
			this.sdText180.FontSize = 12F;
			this.sdText180.Leading = 14F;
			this.sdText180.Lines = new string[] {
													"2.6         SDText"};
			this.sdText180.Location = new System.Drawing.Point(64, 64);
			this.sdText180.Name = "sdText180";
			this.sdText180.NodeValue = null;
			this.sdText180.Size = new System.Drawing.Size(360, 16);
			this.sdText180.TabIndex = 23;
			this.sdText180.Tag = "3";
			this.sdText180.WordSpace = 0F;
			// 
			// sdLabel17
			// 
			this.sdLabel17.Alignment = Report.SDAlignment.RightJustify;
			this.sdLabel17.CharSpace = 0F;
			this.sdLabel17.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.sdLabel17.FontColor = System.Drawing.Color.Black;
			this.sdLabel17.FontName = Report.SdFontName.Arial;
			this.sdLabel17.FontSize = 8F;
			this.sdLabel17.Location = new System.Drawing.Point(0, 765);
			this.sdLabel17.Name = "sdLabel17";
			this.sdLabel17.Size = new System.Drawing.Size(532, 13);
			this.sdLabel17.TabIndex = 11;
			this.sdLabel17.Tag = "0";
			this.sdLabel17.Text = "copyright (c) 2002-2003 Serdar Dirican";
			this.sdLabel17.WordSpace = 0F;
			// 
			// sdRect45
			// 
			this.sdRect45.FillColor = System.Drawing.Color.Transparent;
			this.sdRect45.LineColor = System.Drawing.Color.Black;
			this.sdRect45.LineStyle = Report.PenStyle.Solid;
			this.sdRect45.LineWidth = 0F;
			this.sdRect45.Location = new System.Drawing.Point(256, 24);
			this.sdRect45.Name = "sdRect45";
			this.sdRect45.Size = new System.Drawing.Size(2, 24);
			this.sdRect45.TabIndex = 10;
			this.sdRect45.Tag = "0";
			this.sdRect45.Text = "sdRect4";
			// 
			// sdRect46
			// 
			this.sdRect46.FillColor = System.Drawing.Color.Transparent;
			this.sdRect46.LineColor = System.Drawing.Color.Black;
			this.sdRect46.LineStyle = Report.PenStyle.Solid;
			this.sdRect46.LineWidth = 0F;
			this.sdRect46.Location = new System.Drawing.Point(440, 24);
			this.sdRect46.Name = "sdRect46";
			this.sdRect46.Size = new System.Drawing.Size(2, 24);
			this.sdRect46.TabIndex = 9;
			this.sdRect46.Tag = "0";
			this.sdRect46.Text = "sdRect3";
			// 
			// sdRect47
			// 
			this.sdRect47.FillColor = System.Drawing.Color.Transparent;
			this.sdRect47.LineColor = System.Drawing.Color.Black;
			this.sdRect47.LineStyle = Report.PenStyle.Solid;
			this.sdRect47.LineWidth = 0F;
			this.sdRect47.Location = new System.Drawing.Point(80, 24);
			this.sdRect47.Name = "sdRect47";
			this.sdRect47.Size = new System.Drawing.Size(2, 24);
			this.sdRect47.TabIndex = 8;
			this.sdRect47.Tag = "0";
			this.sdRect47.Text = "sdRect2";
			// 
			// sdRect48
			// 
			this.sdRect48.DrawLine = true;
			this.sdRect48.FillColor = System.Drawing.Color.Transparent;
			this.sdRect48.LineColor = System.Drawing.Color.Black;
			this.sdRect48.LineStyle = Report.PenStyle.Solid;
			this.sdRect48.LineWidth = 2F;
			this.sdRect48.Location = new System.Drawing.Point(80, 40);
			this.sdRect48.Name = "sdRect48";
			this.sdRect48.Size = new System.Drawing.Size(360, 3);
			this.sdRect48.TabIndex = 7;
			this.sdRect48.Tag = "0";
			this.sdRect48.Text = "sdRect1";
			// 
			// tabPage13
			// 
			this.tabPage13.AutoScroll = true;
			this.tabPage13.Controls.Add(this.sdPage11);
			this.tabPage13.Location = new System.Drawing.Point(4, 58);
			this.tabPage13.Name = "tabPage13";
			this.tabPage13.Size = new System.Drawing.Size(472, 211);
			this.tabPage13.TabIndex = 12;
			this.tabPage13.Text = "SDImage";
			// 
			// sdPage11
			// 
			this.sdPage11.Controls.Add(this.sdLayoutPanel13);
			this.sdPage11.DockPadding.All = 32;
			this.sdPage11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
			this.sdPage11.Location = new System.Drawing.Point(0, 0);
			this.sdPage11.Name = "sdPage11";
			this.sdPage11.Size = new System.Drawing.Size(596, 842);
			this.sdPage11.TabIndex = 3;
			this.sdPage11.Text = "sdPage11";
			// 
			// sdLayoutPanel13
			// 
			this.sdLayoutPanel13.BackColor = System.Drawing.SystemColors.Window;
			this.sdLayoutPanel13.Controls.Add(this.sdText181);
			this.sdLayoutPanel13.Controls.Add(this.sdText182);
			this.sdLayoutPanel13.Controls.Add(this.sdText183);
			this.sdLayoutPanel13.Controls.Add(this.sdText184);
			this.sdLayoutPanel13.Controls.Add(this.sdText185);
			this.sdLayoutPanel13.Controls.Add(this.sdText186);
			this.sdLayoutPanel13.Controls.Add(this.sdText187);
			this.sdLayoutPanel13.Controls.Add(this.sdText188);
			this.sdLayoutPanel13.Controls.Add(this.sdText189);
			this.sdLayoutPanel13.Controls.Add(this.sdText190);
			this.sdLayoutPanel13.Controls.Add(this.sdText191);
			this.sdLayoutPanel13.Controls.Add(this.sdText192);
			this.sdLayoutPanel13.Controls.Add(this.sdText193);
			this.sdLayoutPanel13.Controls.Add(this.sdText194);
			this.sdLayoutPanel13.Controls.Add(this.sdText195);
			this.sdLayoutPanel13.Controls.Add(this.sdLabel18);
			this.sdLayoutPanel13.Controls.Add(this.sdRect49);
			this.sdLayoutPanel13.Controls.Add(this.sdRect50);
			this.sdLayoutPanel13.Controls.Add(this.sdRect51);
			this.sdLayoutPanel13.Controls.Add(this.sdRect52);
			this.sdLayoutPanel13.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sdLayoutPanel13.Location = new System.Drawing.Point(32, 32);
			this.sdLayoutPanel13.Name = "sdLayoutPanel13";
			this.sdLayoutPanel13.Size = new System.Drawing.Size(532, 778);
			this.sdLayoutPanel13.TabIndex = 0;
			this.sdLayoutPanel13.Text = "sdLayoutPanel1";
			this.sdLayoutPanel13.BeforePrint += new Report.SDPrintPanelEvent(this.sdlayotupanel_BeforePrint);
			// 
			// sdText181
			// 
			this.sdText181.CharSpace = 0F;
			this.sdText181.FontColor = System.Drawing.Color.Black;
			this.sdText181.FontName = Report.SdFontName.TimesRoman;
			this.sdText181.FontSize = 10F;
			this.sdText181.Leading = 12F;
			this.sdText181.Lines = new string[] {
													"Determines whether the image data will be shared in the document or not.",
													"if this property is set true, the PDF file has only one image, This means disk ca" +
													"pacity",
													"can be saved.",
													"But if the image of each page is different, SharedImage property must be set fals" +
													"e."};
			this.sdText181.Location = new System.Drawing.Point(112, 376);
			this.sdText181.Name = "sdText181";
			this.sdText181.NodeValue = null;
			this.sdText181.Size = new System.Drawing.Size(368, 56);
			this.sdText181.TabIndex = 71;
			this.sdText181.Tag = "0";
			this.sdText181.WordSpace = 0F;
			// 
			// sdText182
			// 
			this.sdText182.CharSpace = 0F;
			this.sdText182.FontColor = System.Drawing.Color.Black;
			this.sdText182.FontName = Report.SdFontName.Arial;
			this.sdText182.FontSize = 10F;
			this.sdText182.Leading = 12F;
			this.sdText182.Lines = new string[] {
													"public bool SharedImage [  get,  set ]"};
			this.sdText182.Location = new System.Drawing.Point(112, 360);
			this.sdText182.Name = "sdText182";
			this.sdText182.NodeValue = null;
			this.sdText182.Size = new System.Drawing.Size(320, 16);
			this.sdText182.TabIndex = 70;
			this.sdText182.Tag = "0";
			this.sdText182.WordSpace = 0F;
			// 
			// sdText183
			// 
			this.sdText183.CharSpace = 0F;
			this.sdText183.FontColor = System.Drawing.Color.Black;
			this.sdText183.FontName = Report.SdFontName.TimesRoman;
			this.sdText183.FontSize = 10F;
			this.sdText183.Leading = 12F;
			this.sdText183.Lines = new string[] {
													"Determines whether resizing the height and width of the image to fit to the clien" +
													"t area or",
													"not."};
			this.sdText183.Location = new System.Drawing.Point(112, 328);
			this.sdText183.Name = "sdText183";
			this.sdText183.NodeValue = null;
			this.sdText183.Size = new System.Drawing.Size(368, 32);
			this.sdText183.TabIndex = 69;
			this.sdText183.Tag = "0";
			this.sdText183.WordSpace = 0F;
			// 
			// sdText184
			// 
			this.sdText184.CharSpace = 0F;
			this.sdText184.FontColor = System.Drawing.Color.Black;
			this.sdText184.FontName = Report.SdFontName.Arial;
			this.sdText184.FontSize = 10F;
			this.sdText184.Leading = 12F;
			this.sdText184.Lines = new string[] {
													"public bool Stretch [  get,  set ]"};
			this.sdText184.Location = new System.Drawing.Point(112, 312);
			this.sdText184.Name = "sdText184";
			this.sdText184.NodeValue = null;
			this.sdText184.Size = new System.Drawing.Size(320, 16);
			this.sdText184.TabIndex = 68;
			this.sdText184.Tag = "0";
			this.sdText184.WordSpace = 0F;
			// 
			// sdText185
			// 
			this.sdText185.CharSpace = 0F;
			this.sdText185.FontColor = System.Drawing.Color.Black;
			this.sdText185.FontName = Report.SdFontName.TimesRoman;
			this.sdText185.FontSize = 10F;
			this.sdText185.Leading = 12F;
			this.sdText185.Lines = new string[] {
													"Specifies the image that appears on the control."};
			this.sdText185.Location = new System.Drawing.Point(112, 288);
			this.sdText185.Name = "sdText185";
			this.sdText185.NodeValue = null;
			this.sdText185.Size = new System.Drawing.Size(368, 24);
			this.sdText185.TabIndex = 67;
			this.sdText185.Tag = "0";
			this.sdText185.WordSpace = 0F;
			// 
			// sdText186
			// 
			this.sdText186.CharSpace = 0F;
			this.sdText186.FontColor = System.Drawing.Color.Black;
			this.sdText186.FontName = Report.SdFontName.Arial;
			this.sdText186.FontSize = 10F;
			this.sdText186.Leading = 12F;
			this.sdText186.Lines = new string[] {
													"public System.Drawing.Bitmap Picture [  get,  set ]"};
			this.sdText186.Location = new System.Drawing.Point(112, 272);
			this.sdText186.Name = "sdText186";
			this.sdText186.NodeValue = null;
			this.sdText186.Size = new System.Drawing.Size(320, 16);
			this.sdText186.TabIndex = 66;
			this.sdText186.Tag = "0";
			this.sdText186.WordSpace = 0F;
			// 
			// sdText187
			// 
			this.sdText187.CharSpace = 0F;
			this.sdText187.FontColor = System.Drawing.Color.Black;
			this.sdText187.FontName = Report.SdFontName.TimesRoman;
			this.sdText187.FontSize = 10F;
			this.sdText187.Leading = 12F;
			this.sdText187.Lines = new string[] {
													"Determines whether the control will be printed or not."};
			this.sdText187.Location = new System.Drawing.Point(112, 248);
			this.sdText187.Name = "sdText187";
			this.sdText187.NodeValue = null;
			this.sdText187.Size = new System.Drawing.Size(368, 24);
			this.sdText187.TabIndex = 65;
			this.sdText187.Tag = "0";
			this.sdText187.WordSpace = 0F;
			// 
			// sdText188
			// 
			this.sdText188.CharSpace = 0F;
			this.sdText188.FontColor = System.Drawing.Color.Black;
			this.sdText188.FontName = Report.SdFontName.Arial;
			this.sdText188.FontSize = 10F;
			this.sdText188.Leading = 12F;
			this.sdText188.Lines = new string[] {
													"public bool Printable [  get,  set ]"};
			this.sdText188.Location = new System.Drawing.Point(112, 232);
			this.sdText188.Name = "sdText188";
			this.sdText188.NodeValue = null;
			this.sdText188.Size = new System.Drawing.Size(320, 16);
			this.sdText188.TabIndex = 64;
			this.sdText188.Tag = "0";
			this.sdText188.WordSpace = 0F;
			// 
			// sdText189
			// 
			this.sdText189.CharSpace = 0F;
			this.sdText189.FontColor = System.Drawing.Color.Black;
			this.sdText189.FontName = Report.SdFontName.TimesRoman;
			this.sdText189.FontSize = 10F;
			this.sdText189.Leading = 12F;
			this.sdText189.Lines = new string[] {
													"Determines how the control aligns within its container (or parent control)."};
			this.sdText189.Location = new System.Drawing.Point(112, 208);
			this.sdText189.Name = "sdText189";
			this.sdText189.NodeValue = null;
			this.sdText189.Size = new System.Drawing.Size(368, 24);
			this.sdText189.TabIndex = 30;
			this.sdText189.Tag = "0";
			this.sdText189.WordSpace = 0F;
			// 
			// sdText190
			// 
			this.sdText190.CharSpace = 0F;
			this.sdText190.FontColor = System.Drawing.Color.Black;
			this.sdText190.FontName = Report.SdFontName.Arial;
			this.sdText190.FontSize = 10F;
			this.sdText190.Leading = 12F;
			this.sdText190.Lines = new string[] {
													"public System.Windows.Forms.DockStyle Dock [  get,  set ]"};
			this.sdText190.Location = new System.Drawing.Point(112, 192);
			this.sdText190.Name = "sdText190";
			this.sdText190.NodeValue = null;
			this.sdText190.Size = new System.Drawing.Size(320, 16);
			this.sdText190.TabIndex = 29;
			this.sdText190.Tag = "0";
			this.sdText190.WordSpace = 0F;
			// 
			// sdText191
			// 
			this.sdText191.CharSpace = 0F;
			this.sdText191.FontBold = true;
			this.sdText191.FontColor = System.Drawing.Color.Black;
			this.sdText191.FontName = Report.SdFontName.Arial;
			this.sdText191.FontSize = 12F;
			this.sdText191.Leading = 14F;
			this.sdText191.Lines = new string[] {
													"2.7.1      SDImage properties"};
			this.sdText191.Location = new System.Drawing.Point(64, 176);
			this.sdText191.Name = "sdText191";
			this.sdText191.NodeValue = null;
			this.sdText191.Size = new System.Drawing.Size(360, 16);
			this.sdText191.TabIndex = 27;
			this.sdText191.Tag = "4";
			this.sdText191.WordSpace = 0F;
			// 
			// sdText192
			// 
			this.sdText192.CharSpace = 0F;
			this.sdText192.FontColor = System.Drawing.Color.Black;
			this.sdText192.FontName = Report.SdFontName.TimesRoman;
			this.sdText192.FontSize = 10F;
			this.sdText192.Leading = 12F;
			this.sdText192.Lines = new string[] {
													"Use of SDImage to print a image. SDImage only support bitmap image."};
			this.sdText192.Location = new System.Drawing.Point(112, 120);
			this.sdText192.Name = "sdText192";
			this.sdText192.NodeValue = null;
			this.sdText192.Size = new System.Drawing.Size(376, 24);
			this.sdText192.TabIndex = 26;
			this.sdText192.Tag = "0";
			this.sdText192.WordSpace = 0F;
			// 
			// sdText193
			// 
			this.sdText193.CharSpace = 0F;
			this.sdText193.FontBold = true;
			this.sdText193.FontColor = System.Drawing.Color.Black;
			this.sdText193.FontName = Report.SdFontName.Arial;
			this.sdText193.FontSize = 12F;
			this.sdText193.Leading = 14F;
			this.sdText193.Lines = new string[] {
													"Description"};
			this.sdText193.Location = new System.Drawing.Point(112, 104);
			this.sdText193.Name = "sdText193";
			this.sdText193.NodeValue = null;
			this.sdText193.Size = new System.Drawing.Size(328, 16);
			this.sdText193.TabIndex = 25;
			this.sdText193.Tag = "0";
			this.sdText193.WordSpace = 0F;
			// 
			// sdText194
			// 
			this.sdText194.CharSpace = 0F;
			this.sdText194.FontColor = System.Drawing.Color.Black;
			this.sdText194.FontName = Report.SdFontName.TimesRoman;
			this.sdText194.FontSize = 10F;
			this.sdText194.Leading = 12F;
			this.sdText194.Lines = new string[] {
													"SDImage is uses to print a image."};
			this.sdText194.Location = new System.Drawing.Point(112, 80);
			this.sdText194.Name = "sdText194";
			this.sdText194.NodeValue = null;
			this.sdText194.Size = new System.Drawing.Size(328, 24);
			this.sdText194.TabIndex = 24;
			this.sdText194.Tag = "0";
			this.sdText194.WordSpace = 0F;
			// 
			// sdText195
			// 
			this.sdText195.CharSpace = 0F;
			this.sdText195.FontBold = true;
			this.sdText195.FontColor = System.Drawing.Color.Black;
			this.sdText195.FontName = Report.SdFontName.Arial;
			this.sdText195.FontSize = 12F;
			this.sdText195.Leading = 14F;
			this.sdText195.Lines = new string[] {
													"2.7         SDImage"};
			this.sdText195.Location = new System.Drawing.Point(64, 64);
			this.sdText195.Name = "sdText195";
			this.sdText195.NodeValue = null;
			this.sdText195.Size = new System.Drawing.Size(360, 16);
			this.sdText195.TabIndex = 23;
			this.sdText195.Tag = "3";
			this.sdText195.WordSpace = 0F;
			// 
			// sdLabel18
			// 
			this.sdLabel18.Alignment = Report.SDAlignment.RightJustify;
			this.sdLabel18.CharSpace = 0F;
			this.sdLabel18.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.sdLabel18.FontColor = System.Drawing.Color.Black;
			this.sdLabel18.FontName = Report.SdFontName.Arial;
			this.sdLabel18.FontSize = 8F;
			this.sdLabel18.Location = new System.Drawing.Point(0, 765);
			this.sdLabel18.Name = "sdLabel18";
			this.sdLabel18.Size = new System.Drawing.Size(532, 13);
			this.sdLabel18.TabIndex = 11;
			this.sdLabel18.Tag = "0";
			this.sdLabel18.Text = "copyright (c) 2002-2003 Serdar Dirican";
			this.sdLabel18.WordSpace = 0F;
			// 
			// sdRect49
			// 
			this.sdRect49.FillColor = System.Drawing.Color.Transparent;
			this.sdRect49.LineColor = System.Drawing.Color.Black;
			this.sdRect49.LineStyle = Report.PenStyle.Solid;
			this.sdRect49.LineWidth = 0F;
			this.sdRect49.Location = new System.Drawing.Point(256, 24);
			this.sdRect49.Name = "sdRect49";
			this.sdRect49.Size = new System.Drawing.Size(2, 24);
			this.sdRect49.TabIndex = 10;
			this.sdRect49.Tag = "0";
			this.sdRect49.Text = "sdRect4";
			// 
			// sdRect50
			// 
			this.sdRect50.FillColor = System.Drawing.Color.Transparent;
			this.sdRect50.LineColor = System.Drawing.Color.Black;
			this.sdRect50.LineStyle = Report.PenStyle.Solid;
			this.sdRect50.LineWidth = 0F;
			this.sdRect50.Location = new System.Drawing.Point(440, 24);
			this.sdRect50.Name = "sdRect50";
			this.sdRect50.Size = new System.Drawing.Size(2, 24);
			this.sdRect50.TabIndex = 9;
			this.sdRect50.Tag = "0";
			this.sdRect50.Text = "sdRect3";
			// 
			// sdRect51
			// 
			this.sdRect51.FillColor = System.Drawing.Color.Transparent;
			this.sdRect51.LineColor = System.Drawing.Color.Black;
			this.sdRect51.LineStyle = Report.PenStyle.Solid;
			this.sdRect51.LineWidth = 0F;
			this.sdRect51.Location = new System.Drawing.Point(80, 24);
			this.sdRect51.Name = "sdRect51";
			this.sdRect51.Size = new System.Drawing.Size(2, 24);
			this.sdRect51.TabIndex = 8;
			this.sdRect51.Tag = "0";
			this.sdRect51.Text = "sdRect2";
			// 
			// sdRect52
			// 
			this.sdRect52.DrawLine = true;
			this.sdRect52.FillColor = System.Drawing.Color.Transparent;
			this.sdRect52.LineColor = System.Drawing.Color.Black;
			this.sdRect52.LineStyle = Report.PenStyle.Solid;
			this.sdRect52.LineWidth = 2F;
			this.sdRect52.Location = new System.Drawing.Point(80, 40);
			this.sdRect52.Name = "sdRect52";
			this.sdRect52.Size = new System.Drawing.Size(360, 3);
			this.sdRect52.TabIndex = 7;
			this.sdRect52.Tag = "0";
			this.sdRect52.Text = "sdRect1";
			// 
			// tabPage14
			// 
			this.tabPage14.AutoScroll = true;
			this.tabPage14.Controls.Add(this.sdPage12);
			this.tabPage14.Location = new System.Drawing.Point(4, 58);
			this.tabPage14.Name = "tabPage14";
			this.tabPage14.Size = new System.Drawing.Size(472, 211);
			this.tabPage14.TabIndex = 13;
			this.tabPage14.Text = "SDJpegImage";
			// 
			// sdPage12
			// 
			this.sdPage12.Controls.Add(this.sdLayoutPanel14);
			this.sdPage12.DockPadding.All = 32;
			this.sdPage12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
			this.sdPage12.Location = new System.Drawing.Point(0, 0);
			this.sdPage12.Name = "sdPage12";
			this.sdPage12.Size = new System.Drawing.Size(596, 842);
			this.sdPage12.TabIndex = 3;
			this.sdPage12.Text = "sdPage12";
			// 
			// sdLayoutPanel14
			// 
			this.sdLayoutPanel14.BackColor = System.Drawing.SystemColors.Window;
			this.sdLayoutPanel14.Controls.Add(this.sdText196);
			this.sdLayoutPanel14.Controls.Add(this.sdText197);
			this.sdLayoutPanel14.Controls.Add(this.sdText198);
			this.sdLayoutPanel14.Controls.Add(this.sdText199);
			this.sdLayoutPanel14.Controls.Add(this.sdText200);
			this.sdLayoutPanel14.Controls.Add(this.sdText201);
			this.sdLayoutPanel14.Controls.Add(this.sdText202);
			this.sdLayoutPanel14.Controls.Add(this.sdText203);
			this.sdLayoutPanel14.Controls.Add(this.sdText204);
			this.sdLayoutPanel14.Controls.Add(this.sdText205);
			this.sdLayoutPanel14.Controls.Add(this.sdText206);
			this.sdLayoutPanel14.Controls.Add(this.sdText207);
			this.sdLayoutPanel14.Controls.Add(this.sdText208);
			this.sdLayoutPanel14.Controls.Add(this.sdText209);
			this.sdLayoutPanel14.Controls.Add(this.sdText210);
			this.sdLayoutPanel14.Controls.Add(this.sdLabel19);
			this.sdLayoutPanel14.Controls.Add(this.sdRect53);
			this.sdLayoutPanel14.Controls.Add(this.sdRect54);
			this.sdLayoutPanel14.Controls.Add(this.sdRect55);
			this.sdLayoutPanel14.Controls.Add(this.sdRect56);
			this.sdLayoutPanel14.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sdLayoutPanel14.Location = new System.Drawing.Point(32, 32);
			this.sdLayoutPanel14.Name = "sdLayoutPanel14";
			this.sdLayoutPanel14.Size = new System.Drawing.Size(532, 778);
			this.sdLayoutPanel14.TabIndex = 0;
			this.sdLayoutPanel14.Text = "sdLayoutPanel1";
			this.sdLayoutPanel14.BeforePrint += new Report.SDPrintPanelEvent(this.sdlayotupanel_BeforePrint);
			// 
			// sdText196
			// 
			this.sdText196.CharSpace = 0F;
			this.sdText196.FontColor = System.Drawing.Color.Black;
			this.sdText196.FontName = Report.SdFontName.TimesRoman;
			this.sdText196.FontSize = 10F;
			this.sdText196.Leading = 12F;
			this.sdText196.Lines = new string[] {
													"Determines whether the image data will be shared in the document or not.",
													"if this property is set true, the PDF file has only one image, This means disk ca" +
													"pacity",
													"can be saved.",
													"But if the image of each page is different, SharedImage property must be set fals" +
													"e."};
			this.sdText196.Location = new System.Drawing.Point(112, 376);
			this.sdText196.Name = "sdText196";
			this.sdText196.NodeValue = null;
			this.sdText196.Size = new System.Drawing.Size(368, 56);
			this.sdText196.TabIndex = 71;
			this.sdText196.Tag = "0";
			this.sdText196.WordSpace = 0F;
			// 
			// sdText197
			// 
			this.sdText197.CharSpace = 0F;
			this.sdText197.FontColor = System.Drawing.Color.Black;
			this.sdText197.FontName = Report.SdFontName.Arial;
			this.sdText197.FontSize = 10F;
			this.sdText197.Leading = 12F;
			this.sdText197.Lines = new string[] {
													"public bool SharedImage [  get,  set ]"};
			this.sdText197.Location = new System.Drawing.Point(112, 360);
			this.sdText197.Name = "sdText197";
			this.sdText197.NodeValue = null;
			this.sdText197.Size = new System.Drawing.Size(320, 16);
			this.sdText197.TabIndex = 70;
			this.sdText197.Tag = "0";
			this.sdText197.WordSpace = 0F;
			// 
			// sdText198
			// 
			this.sdText198.CharSpace = 0F;
			this.sdText198.FontColor = System.Drawing.Color.Black;
			this.sdText198.FontName = Report.SdFontName.TimesRoman;
			this.sdText198.FontSize = 10F;
			this.sdText198.Leading = 12F;
			this.sdText198.Lines = new string[] {
													"Determines whether resizing the height and width of the image to fit to the clien" +
													"t area or",
													"not."};
			this.sdText198.Location = new System.Drawing.Point(112, 328);
			this.sdText198.Name = "sdText198";
			this.sdText198.NodeValue = null;
			this.sdText198.Size = new System.Drawing.Size(368, 32);
			this.sdText198.TabIndex = 69;
			this.sdText198.Tag = "0";
			this.sdText198.WordSpace = 0F;
			// 
			// sdText199
			// 
			this.sdText199.CharSpace = 0F;
			this.sdText199.FontColor = System.Drawing.Color.Black;
			this.sdText199.FontName = Report.SdFontName.Arial;
			this.sdText199.FontSize = 10F;
			this.sdText199.Leading = 12F;
			this.sdText199.Lines = new string[] {
													"public bool Stretch [  get,  set ]"};
			this.sdText199.Location = new System.Drawing.Point(112, 312);
			this.sdText199.Name = "sdText199";
			this.sdText199.NodeValue = null;
			this.sdText199.Size = new System.Drawing.Size(320, 16);
			this.sdText199.TabIndex = 68;
			this.sdText199.Tag = "0";
			this.sdText199.WordSpace = 0F;
			// 
			// sdText200
			// 
			this.sdText200.CharSpace = 0F;
			this.sdText200.FontColor = System.Drawing.Color.Black;
			this.sdText200.FontName = Report.SdFontName.TimesRoman;
			this.sdText200.FontSize = 10F;
			this.sdText200.Leading = 12F;
			this.sdText200.Lines = new string[] {
													"Specifies the image that appears on the control. Only Jpeg image is allowed."};
			this.sdText200.Location = new System.Drawing.Point(112, 288);
			this.sdText200.Name = "sdText200";
			this.sdText200.NodeValue = null;
			this.sdText200.Size = new System.Drawing.Size(368, 24);
			this.sdText200.TabIndex = 67;
			this.sdText200.Tag = "0";
			this.sdText200.WordSpace = 0F;
			// 
			// sdText201
			// 
			this.sdText201.CharSpace = 0F;
			this.sdText201.FontColor = System.Drawing.Color.Black;
			this.sdText201.FontName = Report.SdFontName.Arial;
			this.sdText201.FontSize = 10F;
			this.sdText201.Leading = 12F;
			this.sdText201.Lines = new string[] {
													"public System.Drawing.Bitmap Picture [  get,  set ]"};
			this.sdText201.Location = new System.Drawing.Point(112, 272);
			this.sdText201.Name = "sdText201";
			this.sdText201.NodeValue = null;
			this.sdText201.Size = new System.Drawing.Size(320, 16);
			this.sdText201.TabIndex = 66;
			this.sdText201.Tag = "0";
			this.sdText201.WordSpace = 0F;
			// 
			// sdText202
			// 
			this.sdText202.CharSpace = 0F;
			this.sdText202.FontColor = System.Drawing.Color.Black;
			this.sdText202.FontName = Report.SdFontName.TimesRoman;
			this.sdText202.FontSize = 10F;
			this.sdText202.Leading = 12F;
			this.sdText202.Lines = new string[] {
													"Determines whether the control will be printed or not."};
			this.sdText202.Location = new System.Drawing.Point(112, 248);
			this.sdText202.Name = "sdText202";
			this.sdText202.NodeValue = null;
			this.sdText202.Size = new System.Drawing.Size(368, 24);
			this.sdText202.TabIndex = 65;
			this.sdText202.Tag = "0";
			this.sdText202.WordSpace = 0F;
			// 
			// sdText203
			// 
			this.sdText203.CharSpace = 0F;
			this.sdText203.FontColor = System.Drawing.Color.Black;
			this.sdText203.FontName = Report.SdFontName.Arial;
			this.sdText203.FontSize = 10F;
			this.sdText203.Leading = 12F;
			this.sdText203.Lines = new string[] {
													"public bool Printable [  get,  set ]"};
			this.sdText203.Location = new System.Drawing.Point(112, 232);
			this.sdText203.Name = "sdText203";
			this.sdText203.NodeValue = null;
			this.sdText203.Size = new System.Drawing.Size(320, 16);
			this.sdText203.TabIndex = 64;
			this.sdText203.Tag = "0";
			this.sdText203.WordSpace = 0F;
			// 
			// sdText204
			// 
			this.sdText204.CharSpace = 0F;
			this.sdText204.FontColor = System.Drawing.Color.Black;
			this.sdText204.FontName = Report.SdFontName.TimesRoman;
			this.sdText204.FontSize = 10F;
			this.sdText204.Leading = 12F;
			this.sdText204.Lines = new string[] {
													"Determines how the control aligns within its container (or parent control)."};
			this.sdText204.Location = new System.Drawing.Point(112, 208);
			this.sdText204.Name = "sdText204";
			this.sdText204.NodeValue = null;
			this.sdText204.Size = new System.Drawing.Size(368, 24);
			this.sdText204.TabIndex = 30;
			this.sdText204.Tag = "0";
			this.sdText204.WordSpace = 0F;
			// 
			// sdText205
			// 
			this.sdText205.CharSpace = 0F;
			this.sdText205.FontColor = System.Drawing.Color.Black;
			this.sdText205.FontName = Report.SdFontName.Arial;
			this.sdText205.FontSize = 10F;
			this.sdText205.Leading = 12F;
			this.sdText205.Lines = new string[] {
													"public System.Windows.Forms.DockStyle Dock [  get,  set ]"};
			this.sdText205.Location = new System.Drawing.Point(112, 192);
			this.sdText205.Name = "sdText205";
			this.sdText205.NodeValue = null;
			this.sdText205.Size = new System.Drawing.Size(320, 16);
			this.sdText205.TabIndex = 29;
			this.sdText205.Tag = "0";
			this.sdText205.WordSpace = 0F;
			// 
			// sdText206
			// 
			this.sdText206.CharSpace = 0F;
			this.sdText206.FontBold = true;
			this.sdText206.FontColor = System.Drawing.Color.Black;
			this.sdText206.FontName = Report.SdFontName.Arial;
			this.sdText206.FontSize = 12F;
			this.sdText206.Leading = 14F;
			this.sdText206.Lines = new string[] {
													"2.8.1      SDJpegImage properties"};
			this.sdText206.Location = new System.Drawing.Point(64, 176);
			this.sdText206.Name = "sdText206";
			this.sdText206.NodeValue = null;
			this.sdText206.Size = new System.Drawing.Size(360, 16);
			this.sdText206.TabIndex = 27;
			this.sdText206.Tag = "4";
			this.sdText206.WordSpace = 0F;
			// 
			// sdText207
			// 
			this.sdText207.CharSpace = 0F;
			this.sdText207.FontColor = System.Drawing.Color.Black;
			this.sdText207.FontName = Report.SdFontName.TimesRoman;
			this.sdText207.FontSize = 10F;
			this.sdText207.Leading = 12F;
			this.sdText207.Lines = new string[] {
													"Use of SDJpegImage to print a image with JPEG encoding."};
			this.sdText207.Location = new System.Drawing.Point(112, 120);
			this.sdText207.Name = "sdText207";
			this.sdText207.NodeValue = null;
			this.sdText207.Size = new System.Drawing.Size(376, 24);
			this.sdText207.TabIndex = 26;
			this.sdText207.Tag = "0";
			this.sdText207.WordSpace = 0F;
			// 
			// sdText208
			// 
			this.sdText208.CharSpace = 0F;
			this.sdText208.FontBold = true;
			this.sdText208.FontColor = System.Drawing.Color.Black;
			this.sdText208.FontName = Report.SdFontName.Arial;
			this.sdText208.FontSize = 12F;
			this.sdText208.Leading = 14F;
			this.sdText208.Lines = new string[] {
													"Description"};
			this.sdText208.Location = new System.Drawing.Point(112, 104);
			this.sdText208.Name = "sdText208";
			this.sdText208.NodeValue = null;
			this.sdText208.Size = new System.Drawing.Size(328, 16);
			this.sdText208.TabIndex = 25;
			this.sdText208.Tag = "0";
			this.sdText208.WordSpace = 0F;
			// 
			// sdText209
			// 
			this.sdText209.CharSpace = 0F;
			this.sdText209.FontColor = System.Drawing.Color.Black;
			this.sdText209.FontName = Report.SdFontName.TimesRoman;
			this.sdText209.FontSize = 10F;
			this.sdText209.Leading = 12F;
			this.sdText209.Lines = new string[] {
													"SDJpegImage is uses to print a JpegImage."};
			this.sdText209.Location = new System.Drawing.Point(112, 80);
			this.sdText209.Name = "sdText209";
			this.sdText209.NodeValue = null;
			this.sdText209.Size = new System.Drawing.Size(328, 24);
			this.sdText209.TabIndex = 24;
			this.sdText209.Tag = "0";
			this.sdText209.WordSpace = 0F;
			// 
			// sdText210
			// 
			this.sdText210.CharSpace = 0F;
			this.sdText210.FontBold = true;
			this.sdText210.FontColor = System.Drawing.Color.Black;
			this.sdText210.FontName = Report.SdFontName.Arial;
			this.sdText210.FontSize = 12F;
			this.sdText210.Leading = 14F;
			this.sdText210.Lines = new string[] {
													"2.8         SDJpegImage"};
			this.sdText210.Location = new System.Drawing.Point(64, 64);
			this.sdText210.Name = "sdText210";
			this.sdText210.NodeValue = null;
			this.sdText210.Size = new System.Drawing.Size(360, 16);
			this.sdText210.TabIndex = 23;
			this.sdText210.Tag = "3";
			this.sdText210.WordSpace = 0F;
			// 
			// sdLabel19
			// 
			this.sdLabel19.Alignment = Report.SDAlignment.RightJustify;
			this.sdLabel19.CharSpace = 0F;
			this.sdLabel19.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.sdLabel19.FontColor = System.Drawing.Color.Black;
			this.sdLabel19.FontName = Report.SdFontName.Arial;
			this.sdLabel19.FontSize = 8F;
			this.sdLabel19.Location = new System.Drawing.Point(0, 765);
			this.sdLabel19.Name = "sdLabel19";
			this.sdLabel19.Size = new System.Drawing.Size(532, 13);
			this.sdLabel19.TabIndex = 11;
			this.sdLabel19.Tag = "0";
			this.sdLabel19.Text = "copyright (c) 2002-2003 Serdar Dirican";
			this.sdLabel19.WordSpace = 0F;
			// 
			// sdRect53
			// 
			this.sdRect53.FillColor = System.Drawing.Color.Transparent;
			this.sdRect53.LineColor = System.Drawing.Color.Black;
			this.sdRect53.LineStyle = Report.PenStyle.Solid;
			this.sdRect53.LineWidth = 0F;
			this.sdRect53.Location = new System.Drawing.Point(256, 24);
			this.sdRect53.Name = "sdRect53";
			this.sdRect53.Size = new System.Drawing.Size(2, 24);
			this.sdRect53.TabIndex = 10;
			this.sdRect53.Tag = "0";
			this.sdRect53.Text = "sdRect4";
			// 
			// sdRect54
			// 
			this.sdRect54.FillColor = System.Drawing.Color.Transparent;
			this.sdRect54.LineColor = System.Drawing.Color.Black;
			this.sdRect54.LineStyle = Report.PenStyle.Solid;
			this.sdRect54.LineWidth = 0F;
			this.sdRect54.Location = new System.Drawing.Point(440, 24);
			this.sdRect54.Name = "sdRect54";
			this.sdRect54.Size = new System.Drawing.Size(2, 24);
			this.sdRect54.TabIndex = 9;
			this.sdRect54.Tag = "0";
			this.sdRect54.Text = "sdRect3";
			// 
			// sdRect55
			// 
			this.sdRect55.FillColor = System.Drawing.Color.Transparent;
			this.sdRect55.LineColor = System.Drawing.Color.Black;
			this.sdRect55.LineStyle = Report.PenStyle.Solid;
			this.sdRect55.LineWidth = 0F;
			this.sdRect55.Location = new System.Drawing.Point(80, 24);
			this.sdRect55.Name = "sdRect55";
			this.sdRect55.Size = new System.Drawing.Size(2, 24);
			this.sdRect55.TabIndex = 8;
			this.sdRect55.Tag = "0";
			this.sdRect55.Text = "sdRect2";
			// 
			// sdRect56
			// 
			this.sdRect56.DrawLine = true;
			this.sdRect56.FillColor = System.Drawing.Color.Transparent;
			this.sdRect56.LineColor = System.Drawing.Color.Black;
			this.sdRect56.LineStyle = Report.PenStyle.Solid;
			this.sdRect56.LineWidth = 2F;
			this.sdRect56.Location = new System.Drawing.Point(80, 40);
			this.sdRect56.Name = "sdRect56";
			this.sdRect56.Size = new System.Drawing.Size(360, 3);
			this.sdRect56.TabIndex = 7;
			this.sdRect56.Tag = "0";
			this.sdRect56.Text = "sdRect1";
			// 
			// tabPage15
			// 
			this.tabPage15.AutoScroll = true;
			this.tabPage15.Controls.Add(this.sdPage13);
			this.tabPage15.Location = new System.Drawing.Point(4, 58);
			this.tabPage15.Name = "tabPage15";
			this.tabPage15.Size = new System.Drawing.Size(472, 211);
			this.tabPage15.TabIndex = 14;
			this.tabPage15.Text = "SDRect";
			// 
			// sdPage13
			// 
			this.sdPage13.Controls.Add(this.sdLayoutPanel15);
			this.sdPage13.DockPadding.All = 32;
			this.sdPage13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
			this.sdPage13.Location = new System.Drawing.Point(0, 0);
			this.sdPage13.Name = "sdPage13";
			this.sdPage13.Size = new System.Drawing.Size(596, 842);
			this.sdPage13.TabIndex = 3;
			this.sdPage13.Text = "sdPage13";
			// 
			// sdLayoutPanel15
			// 
			this.sdLayoutPanel15.BackColor = System.Drawing.SystemColors.Window;
			this.sdLayoutPanel15.Controls.Add(this.sdRect57);
			this.sdLayoutPanel15.Controls.Add(this.sdRect58);
			this.sdLayoutPanel15.Controls.Add(this.sdRect59);
			this.sdLayoutPanel15.Controls.Add(this.sdRect60);
			this.sdLayoutPanel15.Controls.Add(this.sdText211);
			this.sdLayoutPanel15.Controls.Add(this.sdText212);
			this.sdLayoutPanel15.Controls.Add(this.sdText213);
			this.sdLayoutPanel15.Controls.Add(this.sdText214);
			this.sdLayoutPanel15.Controls.Add(this.sdRect61);
			this.sdLayoutPanel15.Controls.Add(this.sdText215);
			this.sdLayoutPanel15.Controls.Add(this.sdRect62);
			this.sdLayoutPanel15.Controls.Add(this.sdText216);
			this.sdLayoutPanel15.Controls.Add(this.sdText217);
			this.sdLayoutPanel15.Controls.Add(this.sdText218);
			this.sdLayoutPanel15.Controls.Add(this.sdText219);
			this.sdLayoutPanel15.Controls.Add(this.sdText220);
			this.sdLayoutPanel15.Controls.Add(this.sdText221);
			this.sdLayoutPanel15.Controls.Add(this.sdText222);
			this.sdLayoutPanel15.Controls.Add(this.sdText223);
			this.sdLayoutPanel15.Controls.Add(this.sdText224);
			this.sdLayoutPanel15.Controls.Add(this.sdText225);
			this.sdLayoutPanel15.Controls.Add(this.sdText226);
			this.sdLayoutPanel15.Controls.Add(this.sdText227);
			this.sdLayoutPanel15.Controls.Add(this.sdText228);
			this.sdLayoutPanel15.Controls.Add(this.sdLabel20);
			this.sdLayoutPanel15.Controls.Add(this.sdRect63);
			this.sdLayoutPanel15.Controls.Add(this.sdRect64);
			this.sdLayoutPanel15.Controls.Add(this.sdRect65);
			this.sdLayoutPanel15.Controls.Add(this.sdRect66);
			this.sdLayoutPanel15.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sdLayoutPanel15.Location = new System.Drawing.Point(32, 32);
			this.sdLayoutPanel15.Name = "sdLayoutPanel15";
			this.sdLayoutPanel15.Size = new System.Drawing.Size(532, 778);
			this.sdLayoutPanel15.TabIndex = 0;
			this.sdLayoutPanel15.Tag = "0";
			this.sdLayoutPanel15.Text = "sdLayoutPanel1";
			this.sdLayoutPanel15.BeforePrint += new Report.SDPrintPanelEvent(this.sdlayotupanel_BeforePrint);
			// 
			// sdRect57
			// 
			this.sdRect57.DrawLine = true;
			this.sdRect57.FillColor = System.Drawing.Color.Transparent;
			this.sdRect57.LineColor = System.Drawing.Color.Black;
			this.sdRect57.LineStyle = Report.PenStyle.Dot;
			this.sdRect57.LineWidth = 0F;
			this.sdRect57.Location = new System.Drawing.Point(192, 456);
			this.sdRect57.Name = "sdRect57";
			this.sdRect57.Size = new System.Drawing.Size(100, 1);
			this.sdRect57.TabIndex = 49;
			this.sdRect57.Tag = "0";
			this.sdRect57.Text = "sdRect6";
			// 
			// sdRect58
			// 
			this.sdRect58.DrawLine = true;
			this.sdRect58.FillColor = System.Drawing.Color.Transparent;
			this.sdRect58.LineColor = System.Drawing.Color.Black;
			this.sdRect58.LineStyle = Report.PenStyle.DashDotDot;
			this.sdRect58.LineWidth = 0F;
			this.sdRect58.Location = new System.Drawing.Point(192, 440);
			this.sdRect58.Name = "sdRect58";
			this.sdRect58.Size = new System.Drawing.Size(100, 1);
			this.sdRect58.TabIndex = 48;
			this.sdRect58.Tag = "0";
			this.sdRect58.Text = "sdRect5";
			// 
			// sdRect59
			// 
			this.sdRect59.DrawLine = true;
			this.sdRect59.FillColor = System.Drawing.Color.Transparent;
			this.sdRect59.LineColor = System.Drawing.Color.Black;
			this.sdRect59.LineStyle = Report.PenStyle.DashDot;
			this.sdRect59.LineWidth = 0F;
			this.sdRect59.Location = new System.Drawing.Point(192, 424);
			this.sdRect59.Name = "sdRect59";
			this.sdRect59.Size = new System.Drawing.Size(100, 1);
			this.sdRect59.TabIndex = 47;
			this.sdRect59.Tag = "0";
			this.sdRect59.Text = "sdRect4";
			// 
			// sdRect60
			// 
			this.sdRect60.DrawLine = true;
			this.sdRect60.FillColor = System.Drawing.Color.Transparent;
			this.sdRect60.LineColor = System.Drawing.Color.Black;
			this.sdRect60.LineStyle = Report.PenStyle.Dash;
			this.sdRect60.LineWidth = 0F;
			this.sdRect60.Location = new System.Drawing.Point(192, 408);
			this.sdRect60.Name = "sdRect60";
			this.sdRect60.Size = new System.Drawing.Size(100, 1);
			this.sdRect60.TabIndex = 46;
			this.sdRect60.Tag = "0";
			this.sdRect60.Text = "sdRect3";
			// 
			// sdText211
			// 
			this.sdText211.CharSpace = 0F;
			this.sdText211.FontColor = System.Drawing.Color.Black;
			this.sdText211.FontName = Report.SdFontName.Arial;
			this.sdText211.FontSize = 9F;
			this.sdText211.Leading = 14F;
			this.sdText211.Lines = new string[] {
													"Dot"};
			this.sdText211.Location = new System.Drawing.Point(120, 448);
			this.sdText211.Name = "sdText211";
			this.sdText211.NodeValue = null;
			this.sdText211.Size = new System.Drawing.Size(56, 16);
			this.sdText211.TabIndex = 45;
			this.sdText211.Tag = "0";
			this.sdText211.WordSpace = 0F;
			// 
			// sdText212
			// 
			this.sdText212.CharSpace = 0F;
			this.sdText212.FontColor = System.Drawing.Color.Black;
			this.sdText212.FontName = Report.SdFontName.Arial;
			this.sdText212.FontSize = 9F;
			this.sdText212.Leading = 14F;
			this.sdText212.Lines = new string[] {
													"DashDotDot"};
			this.sdText212.Location = new System.Drawing.Point(120, 432);
			this.sdText212.Name = "sdText212";
			this.sdText212.NodeValue = null;
			this.sdText212.Size = new System.Drawing.Size(56, 16);
			this.sdText212.TabIndex = 44;
			this.sdText212.Tag = "0";
			this.sdText212.WordSpace = 0F;
			// 
			// sdText213
			// 
			this.sdText213.CharSpace = 0F;
			this.sdText213.FontColor = System.Drawing.Color.Black;
			this.sdText213.FontName = Report.SdFontName.Arial;
			this.sdText213.FontSize = 9F;
			this.sdText213.Leading = 14F;
			this.sdText213.Lines = new string[] {
													"DashDot"};
			this.sdText213.Location = new System.Drawing.Point(120, 416);
			this.sdText213.Name = "sdText213";
			this.sdText213.NodeValue = null;
			this.sdText213.Size = new System.Drawing.Size(56, 16);
			this.sdText213.TabIndex = 43;
			this.sdText213.Tag = "0";
			this.sdText213.WordSpace = 0F;
			// 
			// sdText214
			// 
			this.sdText214.CharSpace = 0F;
			this.sdText214.FontColor = System.Drawing.Color.Black;
			this.sdText214.FontName = Report.SdFontName.Arial;
			this.sdText214.FontSize = 9F;
			this.sdText214.Leading = 14F;
			this.sdText214.Lines = new string[] {
													"Dash"};
			this.sdText214.Location = new System.Drawing.Point(120, 400);
			this.sdText214.Name = "sdText214";
			this.sdText214.NodeValue = null;
			this.sdText214.Size = new System.Drawing.Size(56, 19);
			this.sdText214.TabIndex = 42;
			this.sdText214.Tag = "0";
			this.sdText214.WordSpace = 0F;
			// 
			// sdRect61
			// 
			this.sdRect61.DrawLine = true;
			this.sdRect61.FillColor = System.Drawing.Color.Transparent;
			this.sdRect61.LineColor = System.Drawing.Color.Black;
			this.sdRect61.LineStyle = Report.PenStyle.Solid;
			this.sdRect61.LineWidth = 0F;
			this.sdRect61.Location = new System.Drawing.Point(192, 392);
			this.sdRect61.Name = "sdRect61";
			this.sdRect61.Size = new System.Drawing.Size(100, 1);
			this.sdRect61.TabIndex = 41;
			this.sdRect61.Tag = "0";
			this.sdRect61.Text = "sdRect2";
			// 
			// sdText215
			// 
			this.sdText215.CharSpace = 0F;
			this.sdText215.FontColor = System.Drawing.Color.Black;
			this.sdText215.FontName = Report.SdFontName.Arial;
			this.sdText215.FontSize = 9F;
			this.sdText215.Leading = 14F;
			this.sdText215.Lines = new string[] {
													"Solid"};
			this.sdText215.Location = new System.Drawing.Point(120, 384);
			this.sdText215.Name = "sdText215";
			this.sdText215.NodeValue = null;
			this.sdText215.Size = new System.Drawing.Size(56, 16);
			this.sdText215.TabIndex = 40;
			this.sdText215.Tag = "0";
			this.sdText215.WordSpace = 0F;
			// 
			// sdRect62
			// 
			this.sdRect62.FillColor = System.Drawing.Color.Transparent;
			this.sdRect62.LineColor = System.Drawing.Color.Black;
			this.sdRect62.LineStyle = Report.PenStyle.Solid;
			this.sdRect62.LineWidth = 0F;
			this.sdRect62.Location = new System.Drawing.Point(112, 376);
			this.sdRect62.Name = "sdRect62";
			this.sdRect62.Size = new System.Drawing.Size(216, 96);
			this.sdRect62.TabIndex = 39;
			this.sdRect62.Tag = "0";
			this.sdRect62.Text = "sdRect1";
			// 
			// sdText216
			// 
			this.sdText216.CharSpace = 0F;
			this.sdText216.FontColor = System.Drawing.Color.Black;
			this.sdText216.FontName = Report.SdFontName.TimesRoman;
			this.sdText216.FontSize = 10F;
			this.sdText216.Leading = 12F;
			this.sdText216.Lines = new string[] {
													"LineStyle determines the style in which the pen draws lines."};
			this.sdText216.Location = new System.Drawing.Point(112, 336);
			this.sdText216.Name = "sdText216";
			this.sdText216.NodeValue = null;
			this.sdText216.Size = new System.Drawing.Size(368, 24);
			this.sdText216.TabIndex = 38;
			this.sdText216.Tag = "0";
			this.sdText216.WordSpace = 0F;
			// 
			// sdText217
			// 
			this.sdText217.CharSpace = 0F;
			this.sdText217.FontColor = System.Drawing.Color.Black;
			this.sdText217.FontName = Report.SdFontName.Arial;
			this.sdText217.FontSize = 10F;
			this.sdText217.Leading = 12F;
			this.sdText217.Lines = new string[] {
													"public Report.PenStyle LineStyle [  get,  set ]"};
			this.sdText217.Location = new System.Drawing.Point(112, 320);
			this.sdText217.Name = "sdText217";
			this.sdText217.NodeValue = null;
			this.sdText217.Size = new System.Drawing.Size(320, 16);
			this.sdText217.TabIndex = 37;
			this.sdText217.Tag = "0";
			this.sdText217.WordSpace = 0F;
			// 
			// sdText218
			// 
			this.sdText218.CharSpace = 0F;
			this.sdText218.FontColor = System.Drawing.Color.Black;
			this.sdText218.FontName = Report.SdFontName.TimesRoman;
			this.sdText218.FontSize = 10F;
			this.sdText218.Leading = 12F;
			this.sdText218.Lines = new string[] {
													"LineColor determines color of the lines for the Rectangle."};
			this.sdText218.Location = new System.Drawing.Point(112, 296);
			this.sdText218.Name = "sdText218";
			this.sdText218.NodeValue = null;
			this.sdText218.Size = new System.Drawing.Size(368, 24);
			this.sdText218.TabIndex = 36;
			this.sdText218.Tag = "0";
			this.sdText218.WordSpace = 0F;
			// 
			// sdText219
			// 
			this.sdText219.CharSpace = 0F;
			this.sdText219.FontColor = System.Drawing.Color.Black;
			this.sdText219.FontName = Report.SdFontName.Arial;
			this.sdText219.FontSize = 10F;
			this.sdText219.Leading = 12F;
			this.sdText219.Lines = new string[] {
													"public System.Drawing.Color LineColor [  get,  set ]"};
			this.sdText219.Location = new System.Drawing.Point(112, 280);
			this.sdText219.Name = "sdText219";
			this.sdText219.NodeValue = null;
			this.sdText219.Size = new System.Drawing.Size(320, 16);
			this.sdText219.TabIndex = 35;
			this.sdText219.Tag = "0";
			this.sdText219.WordSpace = 0F;
			// 
			// sdText220
			// 
			this.sdText220.CharSpace = 0F;
			this.sdText220.FontColor = System.Drawing.Color.Black;
			this.sdText220.FontName = Report.SdFontName.TimesRoman;
			this.sdText220.FontSize = 10F;
			this.sdText220.Leading = 12F;
			this.sdText220.Lines = new string[] {
													"FillColor determines fill style for the Rectangle."};
			this.sdText220.Location = new System.Drawing.Point(112, 256);
			this.sdText220.Name = "sdText220";
			this.sdText220.NodeValue = null;
			this.sdText220.Size = new System.Drawing.Size(368, 24);
			this.sdText220.TabIndex = 34;
			this.sdText220.Tag = "0";
			this.sdText220.WordSpace = 0F;
			// 
			// sdText221
			// 
			this.sdText221.CharSpace = 0F;
			this.sdText221.FontColor = System.Drawing.Color.Black;
			this.sdText221.FontName = Report.SdFontName.Arial;
			this.sdText221.FontSize = 10F;
			this.sdText221.Leading = 12F;
			this.sdText221.Lines = new string[] {
													"public System.Drawing.Color FillColor [  get,  set ]"};
			this.sdText221.Location = new System.Drawing.Point(112, 240);
			this.sdText221.Name = "sdText221";
			this.sdText221.NodeValue = null;
			this.sdText221.Size = new System.Drawing.Size(320, 16);
			this.sdText221.TabIndex = 33;
			this.sdText221.Tag = "0";
			this.sdText221.WordSpace = 0F;
			// 
			// sdText222
			// 
			this.sdText222.CharSpace = 0F;
			this.sdText222.FontColor = System.Drawing.Color.Black;
			this.sdText222.FontName = Report.SdFontName.TimesRoman;
			this.sdText222.FontSize = 10F;
			this.sdText222.Leading = 12F;
			this.sdText222.Lines = new string[] {
													"Draw vertical lines"};
			this.sdText222.Location = new System.Drawing.Point(112, 216);
			this.sdText222.Name = "sdText222";
			this.sdText222.NodeValue = null;
			this.sdText222.Size = new System.Drawing.Size(368, 24);
			this.sdText222.TabIndex = 32;
			this.sdText222.Tag = "0";
			this.sdText222.WordSpace = 0F;
			// 
			// sdText223
			// 
			this.sdText223.CharSpace = 0F;
			this.sdText223.FontColor = System.Drawing.Color.Black;
			this.sdText223.FontName = Report.SdFontName.Arial;
			this.sdText223.FontSize = 10F;
			this.sdText223.Leading = 12F;
			this.sdText223.Lines = new string[] {
													"public bool DrawLine [  get,  set ]"};
			this.sdText223.Location = new System.Drawing.Point(112, 200);
			this.sdText223.Name = "sdText223";
			this.sdText223.NodeValue = null;
			this.sdText223.Size = new System.Drawing.Size(320, 16);
			this.sdText223.TabIndex = 31;
			this.sdText223.Tag = "0";
			this.sdText223.WordSpace = 0F;
			// 
			// sdText224
			// 
			this.sdText224.CharSpace = 0F;
			this.sdText224.FontColor = System.Drawing.Color.Black;
			this.sdText224.FontName = Report.SdFontName.TimesRoman;
			this.sdText224.FontSize = 10F;
			this.sdText224.Leading = 12F;
			this.sdText224.Lines = new string[] {
													"Determines how the control aligns within its container (or parent control)."};
			this.sdText224.Location = new System.Drawing.Point(112, 176);
			this.sdText224.Name = "sdText224";
			this.sdText224.NodeValue = null;
			this.sdText224.Size = new System.Drawing.Size(368, 24);
			this.sdText224.TabIndex = 30;
			this.sdText224.Tag = "0";
			this.sdText224.WordSpace = 0F;
			// 
			// sdText225
			// 
			this.sdText225.CharSpace = 0F;
			this.sdText225.FontColor = System.Drawing.Color.Black;
			this.sdText225.FontName = Report.SdFontName.Arial;
			this.sdText225.FontSize = 10F;
			this.sdText225.Leading = 12F;
			this.sdText225.Lines = new string[] {
													"public System.Windows.Forms.DockStyle Dock [  get,  set ]"};
			this.sdText225.Location = new System.Drawing.Point(112, 160);
			this.sdText225.Name = "sdText225";
			this.sdText225.NodeValue = null;
			this.sdText225.Size = new System.Drawing.Size(320, 16);
			this.sdText225.TabIndex = 29;
			this.sdText225.Tag = "0";
			this.sdText225.WordSpace = 0F;
			// 
			// sdText226
			// 
			this.sdText226.CharSpace = 0F;
			this.sdText226.FontBold = true;
			this.sdText226.FontColor = System.Drawing.Color.Black;
			this.sdText226.FontName = Report.SdFontName.Arial;
			this.sdText226.FontSize = 12F;
			this.sdText226.Leading = 14F;
			this.sdText226.Lines = new string[] {
													"2.9.1      SDRect properties"};
			this.sdText226.Location = new System.Drawing.Point(64, 144);
			this.sdText226.Name = "sdText226";
			this.sdText226.NodeValue = null;
			this.sdText226.Size = new System.Drawing.Size(360, 16);
			this.sdText226.TabIndex = 27;
			this.sdText226.Tag = "4";
			this.sdText226.WordSpace = 0F;
			// 
			// sdText227
			// 
			this.sdText227.CharSpace = 0F;
			this.sdText227.FontColor = System.Drawing.Color.Black;
			this.sdText227.FontName = Report.SdFontName.TimesRoman;
			this.sdText227.FontSize = 10F;
			this.sdText227.Leading = 12F;
			this.sdText227.Lines = new string[] {
													"SDRect is used to draw rectangles and lines on a report."};
			this.sdText227.Location = new System.Drawing.Point(112, 80);
			this.sdText227.Name = "sdText227";
			this.sdText227.NodeValue = null;
			this.sdText227.Size = new System.Drawing.Size(328, 24);
			this.sdText227.TabIndex = 24;
			this.sdText227.Tag = "0";
			this.sdText227.WordSpace = 0F;
			// 
			// sdText228
			// 
			this.sdText228.CharSpace = 0F;
			this.sdText228.FontBold = true;
			this.sdText228.FontColor = System.Drawing.Color.Black;
			this.sdText228.FontName = Report.SdFontName.Arial;
			this.sdText228.FontSize = 12F;
			this.sdText228.Leading = 14F;
			this.sdText228.Lines = new string[] {
													"2.9         SDRect"};
			this.sdText228.Location = new System.Drawing.Point(64, 64);
			this.sdText228.Name = "sdText228";
			this.sdText228.NodeValue = null;
			this.sdText228.Size = new System.Drawing.Size(360, 16);
			this.sdText228.TabIndex = 23;
			this.sdText228.Tag = "3";
			this.sdText228.WordSpace = 0F;
			// 
			// sdLabel20
			// 
			this.sdLabel20.Alignment = Report.SDAlignment.RightJustify;
			this.sdLabel20.CharSpace = 0F;
			this.sdLabel20.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.sdLabel20.FontColor = System.Drawing.Color.Black;
			this.sdLabel20.FontName = Report.SdFontName.Arial;
			this.sdLabel20.FontSize = 8F;
			this.sdLabel20.Location = new System.Drawing.Point(0, 765);
			this.sdLabel20.Name = "sdLabel20";
			this.sdLabel20.Size = new System.Drawing.Size(532, 13);
			this.sdLabel20.TabIndex = 11;
			this.sdLabel20.Tag = "0";
			this.sdLabel20.Text = "copyright (c) 2002-2003 Serdar Dirican";
			this.sdLabel20.WordSpace = 0F;
			// 
			// sdRect63
			// 
			this.sdRect63.FillColor = System.Drawing.Color.Transparent;
			this.sdRect63.LineColor = System.Drawing.Color.Black;
			this.sdRect63.LineStyle = Report.PenStyle.Solid;
			this.sdRect63.LineWidth = 0F;
			this.sdRect63.Location = new System.Drawing.Point(256, 24);
			this.sdRect63.Name = "sdRect63";
			this.sdRect63.Size = new System.Drawing.Size(2, 24);
			this.sdRect63.TabIndex = 10;
			this.sdRect63.Tag = "0";
			this.sdRect63.Text = "sdRect4";
			// 
			// sdRect64
			// 
			this.sdRect64.FillColor = System.Drawing.Color.Transparent;
			this.sdRect64.LineColor = System.Drawing.Color.Black;
			this.sdRect64.LineStyle = Report.PenStyle.Solid;
			this.sdRect64.LineWidth = 0F;
			this.sdRect64.Location = new System.Drawing.Point(440, 24);
			this.sdRect64.Name = "sdRect64";
			this.sdRect64.Size = new System.Drawing.Size(2, 24);
			this.sdRect64.TabIndex = 9;
			this.sdRect64.Tag = "0";
			this.sdRect64.Text = "sdRect3";
			// 
			// sdRect65
			// 
			this.sdRect65.FillColor = System.Drawing.Color.Transparent;
			this.sdRect65.LineColor = System.Drawing.Color.Black;
			this.sdRect65.LineStyle = Report.PenStyle.Solid;
			this.sdRect65.LineWidth = 0F;
			this.sdRect65.Location = new System.Drawing.Point(80, 24);
			this.sdRect65.Name = "sdRect65";
			this.sdRect65.Size = new System.Drawing.Size(2, 24);
			this.sdRect65.TabIndex = 8;
			this.sdRect65.Tag = "0";
			this.sdRect65.Text = "sdRect2";
			// 
			// sdRect66
			// 
			this.sdRect66.DrawLine = true;
			this.sdRect66.FillColor = System.Drawing.Color.Transparent;
			this.sdRect66.LineColor = System.Drawing.Color.Black;
			this.sdRect66.LineStyle = Report.PenStyle.Solid;
			this.sdRect66.LineWidth = 2F;
			this.sdRect66.Location = new System.Drawing.Point(80, 40);
			this.sdRect66.Name = "sdRect66";
			this.sdRect66.Size = new System.Drawing.Size(360, 3);
			this.sdRect66.TabIndex = 7;
			this.sdRect66.Tag = "0";
			this.sdRect66.Text = "sdRect1";
			// 
			// tabPage16
			// 
			this.tabPage16.AutoScroll = true;
			this.tabPage16.Controls.Add(this.sdPage14);
			this.tabPage16.Location = new System.Drawing.Point(4, 58);
			this.tabPage16.Name = "tabPage16";
			this.tabPage16.Size = new System.Drawing.Size(472, 211);
			this.tabPage16.TabIndex = 15;
			this.tabPage16.Text = "SDEllipse";
			// 
			// sdPage14
			// 
			this.sdPage14.Controls.Add(this.sdLayoutPanel16);
			this.sdPage14.DockPadding.All = 32;
			this.sdPage14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
			this.sdPage14.Location = new System.Drawing.Point(0, 0);
			this.sdPage14.Name = "sdPage14";
			this.sdPage14.Size = new System.Drawing.Size(596, 842);
			this.sdPage14.TabIndex = 3;
			this.sdPage14.Text = "sdPage14";
			// 
			// sdLayoutPanel16
			// 
			this.sdLayoutPanel16.BackColor = System.Drawing.SystemColors.Window;
			this.sdLayoutPanel16.Controls.Add(this.sdText229);
			this.sdLayoutPanel16.Controls.Add(this.sdEllipse6);
			this.sdLayoutPanel16.Controls.Add(this.sdEllipse5);
			this.sdLayoutPanel16.Controls.Add(this.sdEllipse4);
			this.sdLayoutPanel16.Controls.Add(this.sdEllipse3);
			this.sdLayoutPanel16.Controls.Add(this.sdEllipse2);
			this.sdLayoutPanel16.Controls.Add(this.sdEllipse1);
			this.sdLayoutPanel16.Controls.Add(this.sdRect67);
			this.sdLayoutPanel16.Controls.Add(this.sdText230);
			this.sdLayoutPanel16.Controls.Add(this.sdText231);
			this.sdLayoutPanel16.Controls.Add(this.sdText232);
			this.sdLayoutPanel16.Controls.Add(this.sdText233);
			this.sdLayoutPanel16.Controls.Add(this.sdText234);
			this.sdLayoutPanel16.Controls.Add(this.sdText235);
			this.sdLayoutPanel16.Controls.Add(this.sdText236);
			this.sdLayoutPanel16.Controls.Add(this.sdText237);
			this.sdLayoutPanel16.Controls.Add(this.sdText238);
			this.sdLayoutPanel16.Controls.Add(this.sdText239);
			this.sdLayoutPanel16.Controls.Add(this.sdText240);
			this.sdLayoutPanel16.Controls.Add(this.sdLabel21);
			this.sdLayoutPanel16.Controls.Add(this.sdRect68);
			this.sdLayoutPanel16.Controls.Add(this.sdRect69);
			this.sdLayoutPanel16.Controls.Add(this.sdRect70);
			this.sdLayoutPanel16.Controls.Add(this.sdRect71);
			this.sdLayoutPanel16.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sdLayoutPanel16.Location = new System.Drawing.Point(32, 32);
			this.sdLayoutPanel16.Name = "sdLayoutPanel16";
			this.sdLayoutPanel16.Size = new System.Drawing.Size(532, 778);
			this.sdLayoutPanel16.TabIndex = 0;
			this.sdLayoutPanel16.Text = "sdLayoutPanel1";
			this.sdLayoutPanel16.BeforePrint += new Report.SDPrintPanelEvent(this.sdlayotupanel_BeforePrint);
			// 
			// sdText229
			// 
			this.sdText229.CharSpace = 0F;
			this.sdText229.FontColor = System.Drawing.Color.Black;
			this.sdText229.FontName = Report.SdFontName.Arial;
			this.sdText229.FontSize = 10F;
			this.sdText229.Leading = 12F;
			this.sdText229.Lines = new string[] {
													"The samples of the SDEllipse"};
			this.sdText229.Location = new System.Drawing.Point(112, 360);
			this.sdText229.Name = "sdText229";
			this.sdText229.NodeValue = null;
			this.sdText229.Size = new System.Drawing.Size(320, 16);
			this.sdText229.TabIndex = 46;
			this.sdText229.Tag = "0";
			this.sdText229.WordSpace = 0F;
			// 
			// sdEllipse6
			// 
			this.sdEllipse6.FillColor = System.Drawing.Color.Transparent;
			this.sdEllipse6.LineColor = System.Drawing.Color.Red;
			this.sdEllipse6.LineStyle = Report.PenStyle.Solid;
			this.sdEllipse6.LineWidth = 2F;
			this.sdEllipse6.Location = new System.Drawing.Point(352, 456);
			this.sdEllipse6.Name = "sdEllipse6";
			this.sdEllipse6.Size = new System.Drawing.Size(100, 80);
			this.sdEllipse6.TabIndex = 45;
			this.sdEllipse6.Tag = "0";
			this.sdEllipse6.Text = "sdEllipse6";
			// 
			// sdEllipse5
			// 
			this.sdEllipse5.FillColor = System.Drawing.Color.Aqua;
			this.sdEllipse5.LineColor = System.Drawing.Color.Transparent;
			this.sdEllipse5.LineStyle = Report.PenStyle.Solid;
			this.sdEllipse5.LineWidth = 0F;
			this.sdEllipse5.Location = new System.Drawing.Point(240, 456);
			this.sdEllipse5.Name = "sdEllipse5";
			this.sdEllipse5.Size = new System.Drawing.Size(100, 80);
			this.sdEllipse5.TabIndex = 44;
			this.sdEllipse5.Tag = "0";
			this.sdEllipse5.Text = "sdEllipse5";
			// 
			// sdEllipse4
			// 
			this.sdEllipse4.FillColor = System.Drawing.Color.Transparent;
			this.sdEllipse4.LineColor = System.Drawing.Color.Black;
			this.sdEllipse4.LineStyle = Report.PenStyle.Dash;
			this.sdEllipse4.LineWidth = 0F;
			this.sdEllipse4.Location = new System.Drawing.Point(128, 456);
			this.sdEllipse4.Name = "sdEllipse4";
			this.sdEllipse4.Size = new System.Drawing.Size(100, 80);
			this.sdEllipse4.TabIndex = 43;
			this.sdEllipse4.Tag = "0";
			this.sdEllipse4.Text = "sdEllipse4";
			// 
			// sdEllipse3
			// 
			this.sdEllipse3.FillColor = System.Drawing.Color.Green;
			this.sdEllipse3.LineColor = System.Drawing.Color.Black;
			this.sdEllipse3.LineStyle = Report.PenStyle.Solid;
			this.sdEllipse3.LineWidth = 2F;
			this.sdEllipse3.Location = new System.Drawing.Point(352, 392);
			this.sdEllipse3.Name = "sdEllipse3";
			this.sdEllipse3.Size = new System.Drawing.Size(100, 30);
			this.sdEllipse3.TabIndex = 42;
			this.sdEllipse3.Tag = "0";
			this.sdEllipse3.Text = "sdEllipse3";
			// 
			// sdEllipse2
			// 
			this.sdEllipse2.FillColor = System.Drawing.Color.Yellow;
			this.sdEllipse2.LineColor = System.Drawing.Color.Transparent;
			this.sdEllipse2.LineStyle = Report.PenStyle.Solid;
			this.sdEllipse2.LineWidth = 0F;
			this.sdEllipse2.Location = new System.Drawing.Point(240, 392);
			this.sdEllipse2.Name = "sdEllipse2";
			this.sdEllipse2.Size = new System.Drawing.Size(100, 30);
			this.sdEllipse2.TabIndex = 41;
			this.sdEllipse2.Tag = "0";
			this.sdEllipse2.Text = "sdEllipse2";
			// 
			// sdEllipse1
			// 
			this.sdEllipse1.FillColor = System.Drawing.Color.Transparent;
			this.sdEllipse1.LineColor = System.Drawing.Color.Black;
			this.sdEllipse1.LineStyle = Report.PenStyle.Solid;
			this.sdEllipse1.LineWidth = 0F;
			this.sdEllipse1.Location = new System.Drawing.Point(128, 392);
			this.sdEllipse1.Name = "sdEllipse1";
			this.sdEllipse1.Size = new System.Drawing.Size(100, 30);
			this.sdEllipse1.TabIndex = 40;
			this.sdEllipse1.Tag = "0";
			this.sdEllipse1.Text = "sdEllipse1";
			// 
			// sdRect67
			// 
			this.sdRect67.FillColor = System.Drawing.Color.Transparent;
			this.sdRect67.LineColor = System.Drawing.Color.Black;
			this.sdRect67.LineStyle = Report.PenStyle.Solid;
			this.sdRect67.LineWidth = 0F;
			this.sdRect67.Location = new System.Drawing.Point(112, 376);
			this.sdRect67.Name = "sdRect67";
			this.sdRect67.Size = new System.Drawing.Size(352, 176);
			this.sdRect67.TabIndex = 39;
			this.sdRect67.Tag = "0";
			this.sdRect67.Text = "sdRect1";
			// 
			// sdText230
			// 
			this.sdText230.CharSpace = 0F;
			this.sdText230.FontColor = System.Drawing.Color.Black;
			this.sdText230.FontName = Report.SdFontName.TimesRoman;
			this.sdText230.FontSize = 10F;
			this.sdText230.Leading = 12F;
			this.sdText230.Lines = new string[] {
													"LineStyle determines the style in which the pen draws lines."};
			this.sdText230.Location = new System.Drawing.Point(112, 296);
			this.sdText230.Name = "sdText230";
			this.sdText230.NodeValue = null;
			this.sdText230.Size = new System.Drawing.Size(368, 24);
			this.sdText230.TabIndex = 38;
			this.sdText230.Tag = "0";
			this.sdText230.WordSpace = 0F;
			// 
			// sdText231
			// 
			this.sdText231.CharSpace = 0F;
			this.sdText231.FontColor = System.Drawing.Color.Black;
			this.sdText231.FontName = Report.SdFontName.Arial;
			this.sdText231.FontSize = 10F;
			this.sdText231.Leading = 12F;
			this.sdText231.Lines = new string[] {
													"public Report.PenStyle LineStyle [  get,  set ]"};
			this.sdText231.Location = new System.Drawing.Point(112, 280);
			this.sdText231.Name = "sdText231";
			this.sdText231.NodeValue = null;
			this.sdText231.Size = new System.Drawing.Size(320, 16);
			this.sdText231.TabIndex = 37;
			this.sdText231.Tag = "0";
			this.sdText231.WordSpace = 0F;
			// 
			// sdText232
			// 
			this.sdText232.CharSpace = 0F;
			this.sdText232.FontColor = System.Drawing.Color.Black;
			this.sdText232.FontName = Report.SdFontName.TimesRoman;
			this.sdText232.FontSize = 10F;
			this.sdText232.Leading = 12F;
			this.sdText232.Lines = new string[] {
													"LineColor determines color of the lines for the Ellipse."};
			this.sdText232.Location = new System.Drawing.Point(112, 256);
			this.sdText232.Name = "sdText232";
			this.sdText232.NodeValue = null;
			this.sdText232.Size = new System.Drawing.Size(368, 24);
			this.sdText232.TabIndex = 36;
			this.sdText232.Tag = "0";
			this.sdText232.WordSpace = 0F;
			// 
			// sdText233
			// 
			this.sdText233.CharSpace = 0F;
			this.sdText233.FontColor = System.Drawing.Color.Black;
			this.sdText233.FontName = Report.SdFontName.Arial;
			this.sdText233.FontSize = 10F;
			this.sdText233.Leading = 12F;
			this.sdText233.Lines = new string[] {
													"public System.Drawing.Color LineColor [  get,  set ]"};
			this.sdText233.Location = new System.Drawing.Point(112, 240);
			this.sdText233.Name = "sdText233";
			this.sdText233.NodeValue = null;
			this.sdText233.Size = new System.Drawing.Size(320, 16);
			this.sdText233.TabIndex = 35;
			this.sdText233.Tag = "0";
			this.sdText233.WordSpace = 0F;
			// 
			// sdText234
			// 
			this.sdText234.CharSpace = 0F;
			this.sdText234.FontColor = System.Drawing.Color.Black;
			this.sdText234.FontName = Report.SdFontName.TimesRoman;
			this.sdText234.FontSize = 10F;
			this.sdText234.Leading = 12F;
			this.sdText234.Lines = new string[] {
													"FillColor determines fill style for the Ellipse."};
			this.sdText234.Location = new System.Drawing.Point(112, 216);
			this.sdText234.Name = "sdText234";
			this.sdText234.NodeValue = null;
			this.sdText234.Size = new System.Drawing.Size(368, 24);
			this.sdText234.TabIndex = 34;
			this.sdText234.Tag = "0";
			this.sdText234.WordSpace = 0F;
			// 
			// sdText235
			// 
			this.sdText235.CharSpace = 0F;
			this.sdText235.FontColor = System.Drawing.Color.Black;
			this.sdText235.FontName = Report.SdFontName.Arial;
			this.sdText235.FontSize = 10F;
			this.sdText235.Leading = 12F;
			this.sdText235.Lines = new string[] {
													"public System.Drawing.Color FillColor [  get,  set ]"};
			this.sdText235.Location = new System.Drawing.Point(112, 200);
			this.sdText235.Name = "sdText235";
			this.sdText235.NodeValue = null;
			this.sdText235.Size = new System.Drawing.Size(320, 16);
			this.sdText235.TabIndex = 33;
			this.sdText235.Tag = "0";
			this.sdText235.WordSpace = 0F;
			// 
			// sdText236
			// 
			this.sdText236.CharSpace = 0F;
			this.sdText236.FontColor = System.Drawing.Color.Black;
			this.sdText236.FontName = Report.SdFontName.TimesRoman;
			this.sdText236.FontSize = 10F;
			this.sdText236.Leading = 12F;
			this.sdText236.Lines = new string[] {
													"Determines how the control aligns within its container (or parent control)."};
			this.sdText236.Location = new System.Drawing.Point(112, 176);
			this.sdText236.Name = "sdText236";
			this.sdText236.NodeValue = null;
			this.sdText236.Size = new System.Drawing.Size(368, 24);
			this.sdText236.TabIndex = 30;
			this.sdText236.Tag = "0";
			this.sdText236.WordSpace = 0F;
			// 
			// sdText237
			// 
			this.sdText237.CharSpace = 0F;
			this.sdText237.FontColor = System.Drawing.Color.Black;
			this.sdText237.FontName = Report.SdFontName.Arial;
			this.sdText237.FontSize = 10F;
			this.sdText237.Leading = 12F;
			this.sdText237.Lines = new string[] {
													"public System.Windows.Forms.DockStyle Dock [  get,  set ]"};
			this.sdText237.Location = new System.Drawing.Point(112, 160);
			this.sdText237.Name = "sdText237";
			this.sdText237.NodeValue = null;
			this.sdText237.Size = new System.Drawing.Size(320, 16);
			this.sdText237.TabIndex = 29;
			this.sdText237.Tag = "0";
			this.sdText237.WordSpace = 0F;
			// 
			// sdText238
			// 
			this.sdText238.CharSpace = 0F;
			this.sdText238.FontBold = true;
			this.sdText238.FontColor = System.Drawing.Color.Black;
			this.sdText238.FontName = Report.SdFontName.Arial;
			this.sdText238.FontSize = 12F;
			this.sdText238.Leading = 14F;
			this.sdText238.Lines = new string[] {
													"2.10.1    SDEllipse properties"};
			this.sdText238.Location = new System.Drawing.Point(64, 144);
			this.sdText238.Name = "sdText238";
			this.sdText238.NodeValue = null;
			this.sdText238.Size = new System.Drawing.Size(360, 16);
			this.sdText238.TabIndex = 27;
			this.sdText238.Tag = "4";
			this.sdText238.WordSpace = 0F;
			// 
			// sdText239
			// 
			this.sdText239.CharSpace = 0F;
			this.sdText239.FontColor = System.Drawing.Color.Black;
			this.sdText239.FontName = Report.SdFontName.TimesRoman;
			this.sdText239.FontSize = 10F;
			this.sdText239.Leading = 12F;
			this.sdText239.Lines = new string[] {
													"SDEllipse is used to draw ellipse on a report."};
			this.sdText239.Location = new System.Drawing.Point(112, 80);
			this.sdText239.Name = "sdText239";
			this.sdText239.NodeValue = null;
			this.sdText239.Size = new System.Drawing.Size(328, 24);
			this.sdText239.TabIndex = 24;
			this.sdText239.Tag = "0";
			this.sdText239.WordSpace = 0F;
			// 
			// sdText240
			// 
			this.sdText240.CharSpace = 0F;
			this.sdText240.FontBold = true;
			this.sdText240.FontColor = System.Drawing.Color.Black;
			this.sdText240.FontName = Report.SdFontName.Arial;
			this.sdText240.FontSize = 12F;
			this.sdText240.Leading = 14F;
			this.sdText240.Lines = new string[] {
													"2.10       SDEllipse"};
			this.sdText240.Location = new System.Drawing.Point(64, 64);
			this.sdText240.Name = "sdText240";
			this.sdText240.NodeValue = null;
			this.sdText240.Size = new System.Drawing.Size(360, 16);
			this.sdText240.TabIndex = 23;
			this.sdText240.Tag = "3";
			this.sdText240.WordSpace = 0F;
			// 
			// sdLabel21
			// 
			this.sdLabel21.Alignment = Report.SDAlignment.RightJustify;
			this.sdLabel21.CharSpace = 0F;
			this.sdLabel21.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.sdLabel21.FontColor = System.Drawing.Color.Black;
			this.sdLabel21.FontName = Report.SdFontName.Arial;
			this.sdLabel21.FontSize = 8F;
			this.sdLabel21.Location = new System.Drawing.Point(0, 765);
			this.sdLabel21.Name = "sdLabel21";
			this.sdLabel21.Size = new System.Drawing.Size(532, 13);
			this.sdLabel21.TabIndex = 11;
			this.sdLabel21.Tag = "0";
			this.sdLabel21.Text = "copyright (c) 2002-2003 Serdar Dirican";
			this.sdLabel21.WordSpace = 0F;
			// 
			// sdRect68
			// 
			this.sdRect68.FillColor = System.Drawing.Color.Transparent;
			this.sdRect68.LineColor = System.Drawing.Color.Black;
			this.sdRect68.LineStyle = Report.PenStyle.Solid;
			this.sdRect68.LineWidth = 0F;
			this.sdRect68.Location = new System.Drawing.Point(256, 24);
			this.sdRect68.Name = "sdRect68";
			this.sdRect68.Size = new System.Drawing.Size(2, 24);
			this.sdRect68.TabIndex = 10;
			this.sdRect68.Tag = "0";
			this.sdRect68.Text = "sdRect4";
			// 
			// sdRect69
			// 
			this.sdRect69.FillColor = System.Drawing.Color.Transparent;
			this.sdRect69.LineColor = System.Drawing.Color.Black;
			this.sdRect69.LineStyle = Report.PenStyle.Solid;
			this.sdRect69.LineWidth = 0F;
			this.sdRect69.Location = new System.Drawing.Point(440, 24);
			this.sdRect69.Name = "sdRect69";
			this.sdRect69.Size = new System.Drawing.Size(2, 24);
			this.sdRect69.TabIndex = 9;
			this.sdRect69.Tag = "0";
			this.sdRect69.Text = "sdRect3";
			// 
			// sdRect70
			// 
			this.sdRect70.FillColor = System.Drawing.Color.Transparent;
			this.sdRect70.LineColor = System.Drawing.Color.Black;
			this.sdRect70.LineStyle = Report.PenStyle.Solid;
			this.sdRect70.LineWidth = 0F;
			this.sdRect70.Location = new System.Drawing.Point(80, 24);
			this.sdRect70.Name = "sdRect70";
			this.sdRect70.Size = new System.Drawing.Size(2, 24);
			this.sdRect70.TabIndex = 8;
			this.sdRect70.Tag = "0";
			this.sdRect70.Text = "sdRect2";
			// 
			// sdRect71
			// 
			this.sdRect71.DrawLine = true;
			this.sdRect71.FillColor = System.Drawing.Color.Transparent;
			this.sdRect71.LineColor = System.Drawing.Color.Black;
			this.sdRect71.LineStyle = Report.PenStyle.Solid;
			this.sdRect71.LineWidth = 2F;
			this.sdRect71.Location = new System.Drawing.Point(80, 40);
			this.sdRect71.Name = "sdRect71";
			this.sdRect71.Size = new System.Drawing.Size(360, 3);
			this.sdRect71.TabIndex = 7;
			this.sdRect71.Tag = "0";
			this.sdRect71.Text = "sdRect1";
			// 
			// tabPage17
			// 
			this.tabPage17.AutoScroll = true;
			this.tabPage17.Controls.Add(this.sdPage15);
			this.tabPage17.Location = new System.Drawing.Point(4, 58);
			this.tabPage17.Name = "tabPage17";
			this.tabPage17.Size = new System.Drawing.Size(472, 211);
			this.tabPage17.TabIndex = 16;
			this.tabPage17.Text = "SDAnnotation";
			// 
			// sdPage15
			// 
			this.sdPage15.Controls.Add(this.sdLayoutPanel17);
			this.sdPage15.DockPadding.All = 32;
			this.sdPage15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
			this.sdPage15.Location = new System.Drawing.Point(0, 0);
			this.sdPage15.Name = "sdPage15";
			this.sdPage15.Size = new System.Drawing.Size(596, 842);
			this.sdPage15.TabIndex = 3;
			this.sdPage15.Text = "sdPage15";
			// 
			// sdLayoutPanel17
			// 
			this.sdLayoutPanel17.BackColor = System.Drawing.SystemColors.Window;
			this.sdLayoutPanel17.Controls.Add(this.sdAnnotation2);
			this.sdLayoutPanel17.Controls.Add(this.sdText241);
			this.sdLayoutPanel17.Controls.Add(this.sdText242);
			this.sdLayoutPanel17.Controls.Add(this.sdAnnotation1);
			this.sdLayoutPanel17.Controls.Add(this.sdText243);
			this.sdLayoutPanel17.Controls.Add(this.sdText244);
			this.sdLayoutPanel17.Controls.Add(this.sdText245);
			this.sdLayoutPanel17.Controls.Add(this.sdText246);
			this.sdLayoutPanel17.Controls.Add(this.sdText247);
			this.sdLayoutPanel17.Controls.Add(this.sdText248);
			this.sdLayoutPanel17.Controls.Add(this.sdText249);
			this.sdLayoutPanel17.Controls.Add(this.sdText250);
			this.sdLayoutPanel17.Controls.Add(this.sdLabel22);
			this.sdLayoutPanel17.Controls.Add(this.sdRect72);
			this.sdLayoutPanel17.Controls.Add(this.sdRect73);
			this.sdLayoutPanel17.Controls.Add(this.sdRect74);
			this.sdLayoutPanel17.Controls.Add(this.sdRect75);
			this.sdLayoutPanel17.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sdLayoutPanel17.Location = new System.Drawing.Point(32, 32);
			this.sdLayoutPanel17.Name = "sdLayoutPanel17";
			this.sdLayoutPanel17.Size = new System.Drawing.Size(532, 778);
			this.sdLayoutPanel17.TabIndex = 0;
			this.sdLayoutPanel17.Text = "sdLayoutPanel1";
			this.sdLayoutPanel17.BeforePrint += new Report.SDPrintPanelEvent(this.sdlayotupanel_BeforePrint);
			// 
			// sdAnnotation2
			// 
			this.sdAnnotation2.Caption = "sdAnnotation1";
			this.sdAnnotation2.Lines = new string[] {
														"The quick brown fox ate the lazy mouse"};
			this.sdAnnotation2.Location = new System.Drawing.Point(256, 312);
			this.sdAnnotation2.Name = "sdAnnotation2";
			this.sdAnnotation2.Opened = false;
			this.sdAnnotation2.Rect = new System.Drawing.Rectangle(256, 312, 96, 96);
			this.sdAnnotation2.Size = new System.Drawing.Size(40, 40);
			this.sdAnnotation2.TabIndex = 42;
			this.sdAnnotation2.Tag = "0";
			// 
			// sdText241
			// 
			this.sdText241.CharSpace = 0F;
			this.sdText241.FontColor = System.Drawing.Color.Black;
			this.sdText241.FontName = Report.SdFontName.TimesRoman;
			this.sdText241.FontSize = 10F;
			this.sdText241.Leading = 12F;
			this.sdText241.Lines = new string[] {
													"SDAnnotation with Open",
													"property set to false."};
			this.sdText241.Location = new System.Drawing.Point(256, 280);
			this.sdText241.Name = "sdText241";
			this.sdText241.NodeValue = null;
			this.sdText241.Size = new System.Drawing.Size(112, 30);
			this.sdText241.TabIndex = 41;
			this.sdText241.Tag = "0";
			this.sdText241.WordSpace = 0F;
			// 
			// sdText242
			// 
			this.sdText242.CharSpace = 0F;
			this.sdText242.FontColor = System.Drawing.Color.Black;
			this.sdText242.FontName = Report.SdFontName.TimesRoman;
			this.sdText242.FontSize = 10F;
			this.sdText242.Leading = 12F;
			this.sdText242.Lines = new string[] {
													"SDAnnotation with Open",
													"property set to true."};
			this.sdText242.Location = new System.Drawing.Point(112, 280);
			this.sdText242.Name = "sdText242";
			this.sdText242.NodeValue = null;
			this.sdText242.Size = new System.Drawing.Size(112, 30);
			this.sdText242.TabIndex = 40;
			this.sdText242.Tag = "0";
			this.sdText242.WordSpace = 0F;
			// 
			// sdAnnotation1
			// 
			this.sdAnnotation1.Caption = "sdAnnotation1";
			this.sdAnnotation1.Lines = new string[] {
														"The quick brown fox ate the lazy mouse"};
			this.sdAnnotation1.Location = new System.Drawing.Point(112, 312);
			this.sdAnnotation1.Name = "sdAnnotation1";
			this.sdAnnotation1.Opened = true;
			this.sdAnnotation1.Rect = new System.Drawing.Rectangle(112, 312, 96, 96);
			this.sdAnnotation1.Size = new System.Drawing.Size(96, 96);
			this.sdAnnotation1.TabIndex = 39;
			this.sdAnnotation1.Tag = "0";
			// 
			// sdText243
			// 
			this.sdText243.CharSpace = 0F;
			this.sdText243.FontColor = System.Drawing.Color.Black;
			this.sdText243.FontName = Report.SdFontName.TimesRoman;
			this.sdText243.FontSize = 10F;
			this.sdText243.Leading = 12F;
			this.sdText243.Lines = new string[] {
													"Lines determines the text to be displayed in a pop-up window."};
			this.sdText243.Location = new System.Drawing.Point(112, 216);
			this.sdText243.Name = "sdText243";
			this.sdText243.NodeValue = null;
			this.sdText243.Size = new System.Drawing.Size(368, 24);
			this.sdText243.TabIndex = 36;
			this.sdText243.Tag = "0";
			this.sdText243.WordSpace = 0F;
			// 
			// sdText244
			// 
			this.sdText244.CharSpace = 0F;
			this.sdText244.FontColor = System.Drawing.Color.Black;
			this.sdText244.FontName = Report.SdFontName.Arial;
			this.sdText244.FontSize = 10F;
			this.sdText244.Leading = 12F;
			this.sdText244.Lines = new string[] {
													"public bool Opened [  get,  set ]"};
			this.sdText244.Location = new System.Drawing.Point(112, 240);
			this.sdText244.Name = "sdText244";
			this.sdText244.NodeValue = null;
			this.sdText244.Size = new System.Drawing.Size(320, 16);
			this.sdText244.TabIndex = 35;
			this.sdText244.Tag = "0";
			this.sdText244.WordSpace = 0F;
			// 
			// sdText245
			// 
			this.sdText245.CharSpace = 0F;
			this.sdText245.FontColor = System.Drawing.Color.Black;
			this.sdText245.FontName = Report.SdFontName.Arial;
			this.sdText245.FontSize = 10F;
			this.sdText245.Leading = 12F;
			this.sdText245.Lines = new string[] {
													"public string[] Lines [  get,  set ]"};
			this.sdText245.Location = new System.Drawing.Point(112, 200);
			this.sdText245.Name = "sdText245";
			this.sdText245.NodeValue = null;
			this.sdText245.Size = new System.Drawing.Size(320, 16);
			this.sdText245.TabIndex = 33;
			this.sdText245.Tag = "0";
			this.sdText245.WordSpace = 0F;
			// 
			// sdText246
			// 
			this.sdText246.CharSpace = 0F;
			this.sdText246.FontColor = System.Drawing.Color.Black;
			this.sdText246.FontName = Report.SdFontName.TimesRoman;
			this.sdText246.FontSize = 10F;
			this.sdText246.Leading = 12F;
			this.sdText246.Lines = new string[] {
													"Caption determines the title of annotation window."};
			this.sdText246.Location = new System.Drawing.Point(112, 176);
			this.sdText246.Name = "sdText246";
			this.sdText246.NodeValue = null;
			this.sdText246.Size = new System.Drawing.Size(368, 24);
			this.sdText246.TabIndex = 30;
			this.sdText246.Tag = "0";
			this.sdText246.WordSpace = 0F;
			// 
			// sdText247
			// 
			this.sdText247.CharSpace = 0F;
			this.sdText247.FontColor = System.Drawing.Color.Black;
			this.sdText247.FontName = Report.SdFontName.Arial;
			this.sdText247.FontSize = 10F;
			this.sdText247.Leading = 12F;
			this.sdText247.Lines = new string[] {
													"public string Caption [  get,  set ]"};
			this.sdText247.Location = new System.Drawing.Point(112, 160);
			this.sdText247.Name = "sdText247";
			this.sdText247.NodeValue = null;
			this.sdText247.Size = new System.Drawing.Size(320, 16);
			this.sdText247.TabIndex = 29;
			this.sdText247.Tag = "0";
			this.sdText247.WordSpace = 0F;
			// 
			// sdText248
			// 
			this.sdText248.CharSpace = 0F;
			this.sdText248.FontBold = true;
			this.sdText248.FontColor = System.Drawing.Color.Black;
			this.sdText248.FontName = Report.SdFontName.Arial;
			this.sdText248.FontSize = 12F;
			this.sdText248.Leading = 14F;
			this.sdText248.Lines = new string[] {
													"2.11.1    SDAnnotation properties"};
			this.sdText248.Location = new System.Drawing.Point(64, 144);
			this.sdText248.Name = "sdText248";
			this.sdText248.NodeValue = null;
			this.sdText248.Size = new System.Drawing.Size(360, 16);
			this.sdText248.TabIndex = 27;
			this.sdText248.Tag = "4";
			this.sdText248.WordSpace = 0F;
			// 
			// sdText249
			// 
			this.sdText249.CharSpace = 0F;
			this.sdText249.FontColor = System.Drawing.Color.Black;
			this.sdText249.FontName = Report.SdFontName.TimesRoman;
			this.sdText249.FontSize = 10F;
			this.sdText249.Leading = 12F;
			this.sdText249.Lines = new string[] {
													"SDAnnotation is used to add annotations to a page"};
			this.sdText249.Location = new System.Drawing.Point(112, 80);
			this.sdText249.Name = "sdText249";
			this.sdText249.NodeValue = null;
			this.sdText249.Size = new System.Drawing.Size(328, 24);
			this.sdText249.TabIndex = 24;
			this.sdText249.Tag = "0";
			this.sdText249.WordSpace = 0F;
			// 
			// sdText250
			// 
			this.sdText250.CharSpace = 0F;
			this.sdText250.FontBold = true;
			this.sdText250.FontColor = System.Drawing.Color.Black;
			this.sdText250.FontName = Report.SdFontName.Arial;
			this.sdText250.FontSize = 12F;
			this.sdText250.Leading = 14F;
			this.sdText250.Lines = new string[] {
													"2.11       SDAnnotation"};
			this.sdText250.Location = new System.Drawing.Point(64, 64);
			this.sdText250.Name = "sdText250";
			this.sdText250.NodeValue = null;
			this.sdText250.Size = new System.Drawing.Size(360, 16);
			this.sdText250.TabIndex = 23;
			this.sdText250.Tag = "3";
			this.sdText250.WordSpace = 0F;
			// 
			// sdLabel22
			// 
			this.sdLabel22.Alignment = Report.SDAlignment.RightJustify;
			this.sdLabel22.CharSpace = 0F;
			this.sdLabel22.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.sdLabel22.FontColor = System.Drawing.Color.Black;
			this.sdLabel22.FontName = Report.SdFontName.Arial;
			this.sdLabel22.FontSize = 8F;
			this.sdLabel22.Location = new System.Drawing.Point(0, 765);
			this.sdLabel22.Name = "sdLabel22";
			this.sdLabel22.Size = new System.Drawing.Size(532, 13);
			this.sdLabel22.TabIndex = 11;
			this.sdLabel22.Tag = "0";
			this.sdLabel22.Text = "copyright (c) 2002-2003 Serdar Dirican";
			this.sdLabel22.WordSpace = 0F;
			// 
			// sdRect72
			// 
			this.sdRect72.FillColor = System.Drawing.Color.Transparent;
			this.sdRect72.LineColor = System.Drawing.Color.Black;
			this.sdRect72.LineStyle = Report.PenStyle.Solid;
			this.sdRect72.LineWidth = 0F;
			this.sdRect72.Location = new System.Drawing.Point(256, 24);
			this.sdRect72.Name = "sdRect72";
			this.sdRect72.Size = new System.Drawing.Size(2, 24);
			this.sdRect72.TabIndex = 10;
			this.sdRect72.Tag = "0";
			this.sdRect72.Text = "sdRect4";
			// 
			// sdRect73
			// 
			this.sdRect73.FillColor = System.Drawing.Color.Transparent;
			this.sdRect73.LineColor = System.Drawing.Color.Black;
			this.sdRect73.LineStyle = Report.PenStyle.Solid;
			this.sdRect73.LineWidth = 0F;
			this.sdRect73.Location = new System.Drawing.Point(440, 24);
			this.sdRect73.Name = "sdRect73";
			this.sdRect73.Size = new System.Drawing.Size(2, 24);
			this.sdRect73.TabIndex = 9;
			this.sdRect73.Tag = "0";
			this.sdRect73.Text = "sdRect3";
			// 
			// sdRect74
			// 
			this.sdRect74.FillColor = System.Drawing.Color.Transparent;
			this.sdRect74.LineColor = System.Drawing.Color.Black;
			this.sdRect74.LineStyle = Report.PenStyle.Solid;
			this.sdRect74.LineWidth = 0F;
			this.sdRect74.Location = new System.Drawing.Point(80, 24);
			this.sdRect74.Name = "sdRect74";
			this.sdRect74.Size = new System.Drawing.Size(2, 24);
			this.sdRect74.TabIndex = 8;
			this.sdRect74.Tag = "0";
			this.sdRect74.Text = "sdRect2";
			// 
			// sdRect75
			// 
			this.sdRect75.DrawLine = true;
			this.sdRect75.FillColor = System.Drawing.Color.Transparent;
			this.sdRect75.LineColor = System.Drawing.Color.Black;
			this.sdRect75.LineStyle = Report.PenStyle.Solid;
			this.sdRect75.LineWidth = 2F;
			this.sdRect75.Location = new System.Drawing.Point(80, 40);
			this.sdRect75.Name = "sdRect75";
			this.sdRect75.Size = new System.Drawing.Size(360, 3);
			this.sdRect75.TabIndex = 7;
			this.sdRect75.Tag = "0";
			this.sdRect75.Text = "sdRect1";
			// 
			// tabPage18
			// 
			this.tabPage18.AutoScroll = true;
			this.tabPage18.Controls.Add(this.sdPage16);
			this.tabPage18.Location = new System.Drawing.Point(4, 58);
			this.tabPage18.Name = "tabPage18";
			this.tabPage18.Size = new System.Drawing.Size(472, 211);
			this.tabPage18.TabIndex = 17;
			this.tabPage18.Text = "SDOutlineEntry";
			// 
			// sdPage16
			// 
			this.sdPage16.Controls.Add(this.sdLayoutPanel18);
			this.sdPage16.DockPadding.All = 32;
			this.sdPage16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
			this.sdPage16.Location = new System.Drawing.Point(0, 0);
			this.sdPage16.Name = "sdPage16";
			this.sdPage16.Size = new System.Drawing.Size(596, 842);
			this.sdPage16.TabIndex = 3;
			this.sdPage16.Text = "sdPage16";
			// 
			// sdLayoutPanel18
			// 
			this.sdLayoutPanel18.BackColor = System.Drawing.SystemColors.Window;
			this.sdLayoutPanel18.Controls.Add(this.sdText251);
			this.sdLayoutPanel18.Controls.Add(this.sdText252);
			this.sdLayoutPanel18.Controls.Add(this.sdText253);
			this.sdLayoutPanel18.Controls.Add(this.sdText254);
			this.sdLayoutPanel18.Controls.Add(this.sdText255);
			this.sdLayoutPanel18.Controls.Add(this.sdText256);
			this.sdLayoutPanel18.Controls.Add(this.sdText257);
			this.sdLayoutPanel18.Controls.Add(this.sdText258);
			this.sdLayoutPanel18.Controls.Add(this.sdText259);
			this.sdLayoutPanel18.Controls.Add(this.sdText260);
			this.sdLayoutPanel18.Controls.Add(this.sdText261);
			this.sdLayoutPanel18.Controls.Add(this.sdText262);
			this.sdLayoutPanel18.Controls.Add(this.sdText263);
			this.sdLayoutPanel18.Controls.Add(this.sdText264);
			this.sdLayoutPanel18.Controls.Add(this.sdText265);
			this.sdLayoutPanel18.Controls.Add(this.sdText266);
			this.sdLayoutPanel18.Controls.Add(this.sdText267);
			this.sdLayoutPanel18.Controls.Add(this.sdText268);
			this.sdLayoutPanel18.Controls.Add(this.sdText269);
			this.sdLayoutPanel18.Controls.Add(this.sdText270);
			this.sdLayoutPanel18.Controls.Add(this.sdText271);
			this.sdLayoutPanel18.Controls.Add(this.sdText272);
			this.sdLayoutPanel18.Controls.Add(this.sdLabel23);
			this.sdLayoutPanel18.Controls.Add(this.sdRect76);
			this.sdLayoutPanel18.Controls.Add(this.sdRect77);
			this.sdLayoutPanel18.Controls.Add(this.sdRect78);
			this.sdLayoutPanel18.Controls.Add(this.sdRect79);
			this.sdLayoutPanel18.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sdLayoutPanel18.Location = new System.Drawing.Point(32, 32);
			this.sdLayoutPanel18.Name = "sdLayoutPanel18";
			this.sdLayoutPanel18.Size = new System.Drawing.Size(532, 778);
			this.sdLayoutPanel18.TabIndex = 0;
			this.sdLayoutPanel18.Text = "sdLayoutPanel1";
			this.sdLayoutPanel18.BeforePrint += new Report.SDPrintPanelEvent(this.sdlayotupanel_BeforePrint);
			// 
			// sdText251
			// 
			this.sdText251.CharSpace = 0F;
			this.sdText251.FontColor = System.Drawing.Color.Black;
			this.sdText251.FontName = Report.SdFontName.TimesRoman;
			this.sdText251.FontSize = 10F;
			this.sdText251.Leading = 12F;
			this.sdText251.Lines = new string[] {
													"AddChild function add a new outline-entry at the last sibling of the entry and re" +
													"turn",
													"the new outline-entry."};
			this.sdText251.Location = new System.Drawing.Point(112, 576);
			this.sdText251.Name = "sdText251";
			this.sdText251.NodeValue = null;
			this.sdText251.Size = new System.Drawing.Size(368, 24);
			this.sdText251.TabIndex = 47;
			this.sdText251.Tag = "0";
			this.sdText251.WordSpace = 0F;
			// 
			// sdText252
			// 
			this.sdText252.CharSpace = 0F;
			this.sdText252.FontColor = System.Drawing.Color.Black;
			this.sdText252.FontName = Report.SdFontName.Arial;
			this.sdText252.FontSize = 10F;
			this.sdText252.Leading = 12F;
			this.sdText252.Lines = new string[] {
													"public Report.SDOutlineEntry AddChild (  )"};
			this.sdText252.Location = new System.Drawing.Point(112, 560);
			this.sdText252.Name = "sdText252";
			this.sdText252.NodeValue = null;
			this.sdText252.Size = new System.Drawing.Size(320, 16);
			this.sdText252.TabIndex = 46;
			this.sdText252.Tag = "0";
			this.sdText252.WordSpace = 0F;
			// 
			// sdText253
			// 
			this.sdText253.CharSpace = 0F;
			this.sdText253.FontBold = true;
			this.sdText253.FontColor = System.Drawing.Color.Black;
			this.sdText253.FontName = Report.SdFontName.Arial;
			this.sdText253.FontSize = 12F;
			this.sdText253.Leading = 14F;
			this.sdText253.Lines = new string[] {
													"2.12.2    SDOutlineEntry methods"};
			this.sdText253.Location = new System.Drawing.Point(64, 544);
			this.sdText253.Name = "sdText253";
			this.sdText253.NodeValue = null;
			this.sdText253.Size = new System.Drawing.Size(360, 16);
			this.sdText253.TabIndex = 45;
			this.sdText253.Tag = "4";
			this.sdText253.WordSpace = 0F;
			// 
			// sdText254
			// 
			this.sdText254.CharSpace = 0F;
			this.sdText254.FontColor = System.Drawing.Color.Black;
			this.sdText254.FontName = Report.SdFontName.TimesRoman;
			this.sdText254.FontSize = 10F;
			this.sdText254.Leading = 12F;
			this.sdText254.Lines = new string[] {
													"Use the Opened property to set whether the entry is opened or not when the",
													"document is displaied."};
			this.sdText254.Location = new System.Drawing.Point(112, 480);
			this.sdText254.Name = "sdText254";
			this.sdText254.NodeValue = null;
			this.sdText254.Size = new System.Drawing.Size(368, 24);
			this.sdText254.TabIndex = 44;
			this.sdText254.Tag = "0";
			this.sdText254.WordSpace = 0F;
			// 
			// sdText255
			// 
			this.sdText255.CharSpace = 0F;
			this.sdText255.FontColor = System.Drawing.Color.Black;
			this.sdText255.FontName = Report.SdFontName.Arial;
			this.sdText255.FontSize = 10F;
			this.sdText255.Leading = 12F;
			this.sdText255.Lines = new string[] {
													"public bool Opened [  get,  set ]"};
			this.sdText255.Location = new System.Drawing.Point(112, 464);
			this.sdText255.Name = "sdText255";
			this.sdText255.NodeValue = null;
			this.sdText255.Size = new System.Drawing.Size(320, 16);
			this.sdText255.TabIndex = 43;
			this.sdText255.Tag = "0";
			this.sdText255.WordSpace = 0F;
			// 
			// sdText256
			// 
			this.sdText256.CharSpace = 0F;
			this.sdText256.FontColor = System.Drawing.Color.Black;
			this.sdText256.FontName = Report.SdFontName.TimesRoman;
			this.sdText256.FontSize = 10F;
			this.sdText256.Leading = 12F;
			this.sdText256.Lines = new string[] {
													"Use the Title property to modify the name of this entry."};
			this.sdText256.Location = new System.Drawing.Point(112, 440);
			this.sdText256.Name = "sdText256";
			this.sdText256.NodeValue = null;
			this.sdText256.Size = new System.Drawing.Size(368, 24);
			this.sdText256.TabIndex = 42;
			this.sdText256.Tag = "0";
			this.sdText256.WordSpace = 0F;
			// 
			// sdText257
			// 
			this.sdText257.CharSpace = 0F;
			this.sdText257.FontColor = System.Drawing.Color.Black;
			this.sdText257.FontName = Report.SdFontName.Arial;
			this.sdText257.FontSize = 10F;
			this.sdText257.Leading = 12F;
			this.sdText257.Lines = new string[] {
													"public string Title [  get,  set ]"};
			this.sdText257.Location = new System.Drawing.Point(112, 424);
			this.sdText257.Name = "sdText257";
			this.sdText257.NodeValue = null;
			this.sdText257.Size = new System.Drawing.Size(320, 16);
			this.sdText257.TabIndex = 41;
			this.sdText257.Tag = "0";
			this.sdText257.WordSpace = 0F;
			// 
			// sdText258
			// 
			this.sdText258.CharSpace = 0F;
			this.sdText258.FontColor = System.Drawing.Color.Black;
			this.sdText258.FontName = Report.SdFontName.TimesRoman;
			this.sdText258.FontSize = 10F;
			this.sdText258.Leading = 12F;
			this.sdText258.Lines = new string[] {
													"Dest property is a SDDestination object which linkes to the entry."};
			this.sdText258.Location = new System.Drawing.Point(112, 400);
			this.sdText258.Name = "sdText258";
			this.sdText258.NodeValue = null;
			this.sdText258.Size = new System.Drawing.Size(368, 24);
			this.sdText258.TabIndex = 40;
			this.sdText258.Tag = "0";
			this.sdText258.WordSpace = 0F;
			// 
			// sdText259
			// 
			this.sdText259.CharSpace = 0F;
			this.sdText259.FontColor = System.Drawing.Color.Black;
			this.sdText259.FontName = Report.SdFontName.Arial;
			this.sdText259.FontSize = 10F;
			this.sdText259.Leading = 12F;
			this.sdText259.Lines = new string[] {
													"public Report.SDDestination Dest [  get,  set ]"};
			this.sdText259.Location = new System.Drawing.Point(112, 384);
			this.sdText259.Name = "sdText259";
			this.sdText259.NodeValue = null;
			this.sdText259.Size = new System.Drawing.Size(320, 16);
			this.sdText259.TabIndex = 39;
			this.sdText259.Tag = "0";
			this.sdText259.WordSpace = 0F;
			// 
			// sdText260
			// 
			this.sdText260.CharSpace = 0F;
			this.sdText260.FontColor = System.Drawing.Color.Black;
			this.sdText260.FontName = Report.SdFontName.TimesRoman;
			this.sdText260.FontSize = 10F;
			this.sdText260.Leading = 12F;
			this.sdText260.Lines = new string[] {
													"Indicates the last entry of the children.",
													"If the entry has no child entry, First property indicates null."};
			this.sdText260.Location = new System.Drawing.Point(112, 352);
			this.sdText260.Name = "sdText260";
			this.sdText260.NodeValue = null;
			this.sdText260.Size = new System.Drawing.Size(368, 32);
			this.sdText260.TabIndex = 38;
			this.sdText260.Tag = "0";
			this.sdText260.WordSpace = 0F;
			// 
			// sdText261
			// 
			this.sdText261.CharSpace = 0F;
			this.sdText261.FontColor = System.Drawing.Color.Black;
			this.sdText261.FontName = Report.SdFontName.Arial;
			this.sdText261.FontSize = 10F;
			this.sdText261.Leading = 12F;
			this.sdText261.Lines = new string[] {
													"public Report.SDOutlineEntry Last [  get]"};
			this.sdText261.Location = new System.Drawing.Point(112, 336);
			this.sdText261.Name = "sdText261";
			this.sdText261.NodeValue = null;
			this.sdText261.Size = new System.Drawing.Size(320, 16);
			this.sdText261.TabIndex = 37;
			this.sdText261.Tag = "0";
			this.sdText261.WordSpace = 0F;
			// 
			// sdText262
			// 
			this.sdText262.CharSpace = 0F;
			this.sdText262.FontColor = System.Drawing.Color.Black;
			this.sdText262.FontName = Report.SdFontName.TimesRoman;
			this.sdText262.FontSize = 10F;
			this.sdText262.Leading = 12F;
			this.sdText262.Lines = new string[] {
													"Indicates the first entry of the children.",
													"If the entry has no child entry, First property indicates null."};
			this.sdText262.Location = new System.Drawing.Point(112, 304);
			this.sdText262.Name = "sdText262";
			this.sdText262.NodeValue = null;
			this.sdText262.Size = new System.Drawing.Size(368, 32);
			this.sdText262.TabIndex = 36;
			this.sdText262.Tag = "0";
			this.sdText262.WordSpace = 0F;
			// 
			// sdText263
			// 
			this.sdText263.CharSpace = 0F;
			this.sdText263.FontColor = System.Drawing.Color.Black;
			this.sdText263.FontName = Report.SdFontName.Arial;
			this.sdText263.FontSize = 10F;
			this.sdText263.Leading = 12F;
			this.sdText263.Lines = new string[] {
													"public Report.SDOutlineEntry First [  get]"};
			this.sdText263.Location = new System.Drawing.Point(112, 288);
			this.sdText263.Name = "sdText263";
			this.sdText263.NodeValue = null;
			this.sdText263.Size = new System.Drawing.Size(320, 16);
			this.sdText263.TabIndex = 35;
			this.sdText263.Tag = "0";
			this.sdText263.WordSpace = 0F;
			// 
			// sdText264
			// 
			this.sdText264.CharSpace = 0F;
			this.sdText264.FontColor = System.Drawing.Color.Black;
			this.sdText264.FontName = Report.SdFontName.TimesRoman;
			this.sdText264.FontSize = 10F;
			this.sdText264.Leading = 12F;
			this.sdText264.Lines = new string[] {
													"Indicates the previous sibiling entry of this entry.",
													"If the entry has no previous entry, Prev property indicates null."};
			this.sdText264.Location = new System.Drawing.Point(112, 256);
			this.sdText264.Name = "sdText264";
			this.sdText264.NodeValue = null;
			this.sdText264.Size = new System.Drawing.Size(368, 32);
			this.sdText264.TabIndex = 34;
			this.sdText264.Tag = "0";
			this.sdText264.WordSpace = 0F;
			// 
			// sdText265
			// 
			this.sdText265.CharSpace = 0F;
			this.sdText265.FontColor = System.Drawing.Color.Black;
			this.sdText265.FontName = Report.SdFontName.Arial;
			this.sdText265.FontSize = 10F;
			this.sdText265.Leading = 12F;
			this.sdText265.Lines = new string[] {
													"public Report.SDOutlineEntry Prev [  get]"};
			this.sdText265.Location = new System.Drawing.Point(112, 240);
			this.sdText265.Name = "sdText265";
			this.sdText265.NodeValue = null;
			this.sdText265.Size = new System.Drawing.Size(320, 16);
			this.sdText265.TabIndex = 33;
			this.sdText265.Tag = "0";
			this.sdText265.WordSpace = 0F;
			// 
			// sdText266
			// 
			this.sdText266.CharSpace = 0F;
			this.sdText266.FontColor = System.Drawing.Color.Black;
			this.sdText266.FontName = Report.SdFontName.TimesRoman;
			this.sdText266.FontSize = 10F;
			this.sdText266.Leading = 12F;
			this.sdText266.Lines = new string[] {
													"Indicates the next sibiling entry of this entry."};
			this.sdText266.Location = new System.Drawing.Point(112, 216);
			this.sdText266.Name = "sdText266";
			this.sdText266.NodeValue = null;
			this.sdText266.Size = new System.Drawing.Size(368, 24);
			this.sdText266.TabIndex = 32;
			this.sdText266.Tag = "0";
			this.sdText266.WordSpace = 0F;
			// 
			// sdText267
			// 
			this.sdText267.CharSpace = 0F;
			this.sdText267.FontColor = System.Drawing.Color.Black;
			this.sdText267.FontName = Report.SdFontName.Arial;
			this.sdText267.FontSize = 10F;
			this.sdText267.Leading = 12F;
			this.sdText267.Lines = new string[] {
													"public Report.SDOutlineEntry Next [  get]"};
			this.sdText267.Location = new System.Drawing.Point(112, 200);
			this.sdText267.Name = "sdText267";
			this.sdText267.NodeValue = null;
			this.sdText267.Size = new System.Drawing.Size(320, 16);
			this.sdText267.TabIndex = 31;
			this.sdText267.Tag = "0";
			this.sdText267.WordSpace = 0F;
			// 
			// sdText268
			// 
			this.sdText268.CharSpace = 0F;
			this.sdText268.FontColor = System.Drawing.Color.Black;
			this.sdText268.FontName = Report.SdFontName.TimesRoman;
			this.sdText268.FontSize = 10F;
			this.sdText268.Leading = 12F;
			this.sdText268.Lines = new string[] {
													"Indicates the parent entry of this entry."};
			this.sdText268.Location = new System.Drawing.Point(112, 176);
			this.sdText268.Name = "sdText268";
			this.sdText268.NodeValue = null;
			this.sdText268.Size = new System.Drawing.Size(368, 24);
			this.sdText268.TabIndex = 30;
			this.sdText268.Tag = "0";
			this.sdText268.WordSpace = 0F;
			// 
			// sdText269
			// 
			this.sdText269.CharSpace = 0F;
			this.sdText269.FontColor = System.Drawing.Color.Black;
			this.sdText269.FontName = Report.SdFontName.Arial;
			this.sdText269.FontSize = 10F;
			this.sdText269.Leading = 12F;
			this.sdText269.Lines = new string[] {
													"public Report.SDOutlineEntry Parent [  get]"};
			this.sdText269.Location = new System.Drawing.Point(112, 160);
			this.sdText269.Name = "sdText269";
			this.sdText269.NodeValue = null;
			this.sdText269.Size = new System.Drawing.Size(320, 16);
			this.sdText269.TabIndex = 29;
			this.sdText269.Tag = "0";
			this.sdText269.WordSpace = 0F;
			// 
			// sdText270
			// 
			this.sdText270.CharSpace = 0F;
			this.sdText270.FontBold = true;
			this.sdText270.FontColor = System.Drawing.Color.Black;
			this.sdText270.FontName = Report.SdFontName.Arial;
			this.sdText270.FontSize = 12F;
			this.sdText270.Leading = 14F;
			this.sdText270.Lines = new string[] {
													"2.12.1    SDOutlineEntry properties"};
			this.sdText270.Location = new System.Drawing.Point(64, 144);
			this.sdText270.Name = "sdText270";
			this.sdText270.NodeValue = null;
			this.sdText270.Size = new System.Drawing.Size(360, 16);
			this.sdText270.TabIndex = 27;
			this.sdText270.Tag = "4";
			this.sdText270.WordSpace = 0F;
			// 
			// sdText271
			// 
			this.sdText271.CharSpace = 0F;
			this.sdText271.FontColor = System.Drawing.Color.Black;
			this.sdText271.FontName = Report.SdFontName.TimesRoman;
			this.sdText271.FontSize = 10F;
			this.sdText271.Leading = 12F;
			this.sdText271.Lines = new string[] {
													"SDAnnotation is used to make outline tree of the document."};
			this.sdText271.Location = new System.Drawing.Point(112, 80);
			this.sdText271.Name = "sdText271";
			this.sdText271.NodeValue = null;
			this.sdText271.Size = new System.Drawing.Size(328, 24);
			this.sdText271.TabIndex = 24;
			this.sdText271.Tag = "0";
			this.sdText271.WordSpace = 0F;
			// 
			// sdText272
			// 
			this.sdText272.CharSpace = 0F;
			this.sdText272.FontBold = true;
			this.sdText272.FontColor = System.Drawing.Color.Black;
			this.sdText272.FontName = Report.SdFontName.Arial;
			this.sdText272.FontSize = 12F;
			this.sdText272.Leading = 14F;
			this.sdText272.Lines = new string[] {
													"2.12       SDOutlineEntry"};
			this.sdText272.Location = new System.Drawing.Point(64, 64);
			this.sdText272.Name = "sdText272";
			this.sdText272.NodeValue = null;
			this.sdText272.Size = new System.Drawing.Size(360, 16);
			this.sdText272.TabIndex = 23;
			this.sdText272.Tag = "3";
			this.sdText272.WordSpace = 0F;
			// 
			// sdLabel23
			// 
			this.sdLabel23.Alignment = Report.SDAlignment.RightJustify;
			this.sdLabel23.CharSpace = 0F;
			this.sdLabel23.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.sdLabel23.FontColor = System.Drawing.Color.Black;
			this.sdLabel23.FontName = Report.SdFontName.Arial;
			this.sdLabel23.FontSize = 8F;
			this.sdLabel23.Location = new System.Drawing.Point(0, 765);
			this.sdLabel23.Name = "sdLabel23";
			this.sdLabel23.Size = new System.Drawing.Size(532, 13);
			this.sdLabel23.TabIndex = 11;
			this.sdLabel23.Tag = "0";
			this.sdLabel23.Text = "copyright (c) 2002-2003 Serdar Dirican";
			this.sdLabel23.WordSpace = 0F;
			// 
			// sdRect76
			// 
			this.sdRect76.FillColor = System.Drawing.Color.Transparent;
			this.sdRect76.LineColor = System.Drawing.Color.Black;
			this.sdRect76.LineStyle = Report.PenStyle.Solid;
			this.sdRect76.LineWidth = 0F;
			this.sdRect76.Location = new System.Drawing.Point(256, 24);
			this.sdRect76.Name = "sdRect76";
			this.sdRect76.Size = new System.Drawing.Size(2, 24);
			this.sdRect76.TabIndex = 10;
			this.sdRect76.Tag = "0";
			this.sdRect76.Text = "sdRect4";
			// 
			// sdRect77
			// 
			this.sdRect77.FillColor = System.Drawing.Color.Transparent;
			this.sdRect77.LineColor = System.Drawing.Color.Black;
			this.sdRect77.LineStyle = Report.PenStyle.Solid;
			this.sdRect77.LineWidth = 0F;
			this.sdRect77.Location = new System.Drawing.Point(440, 24);
			this.sdRect77.Name = "sdRect77";
			this.sdRect77.Size = new System.Drawing.Size(2, 24);
			this.sdRect77.TabIndex = 9;
			this.sdRect77.Tag = "0";
			this.sdRect77.Text = "sdRect3";
			// 
			// sdRect78
			// 
			this.sdRect78.FillColor = System.Drawing.Color.Transparent;
			this.sdRect78.LineColor = System.Drawing.Color.Black;
			this.sdRect78.LineStyle = Report.PenStyle.Solid;
			this.sdRect78.LineWidth = 0F;
			this.sdRect78.Location = new System.Drawing.Point(80, 24);
			this.sdRect78.Name = "sdRect78";
			this.sdRect78.Size = new System.Drawing.Size(2, 24);
			this.sdRect78.TabIndex = 8;
			this.sdRect78.Tag = "0";
			this.sdRect78.Text = "sdRect2";
			// 
			// sdRect79
			// 
			this.sdRect79.DrawLine = true;
			this.sdRect79.FillColor = System.Drawing.Color.Transparent;
			this.sdRect79.LineColor = System.Drawing.Color.Black;
			this.sdRect79.LineStyle = Report.PenStyle.Solid;
			this.sdRect79.LineWidth = 2F;
			this.sdRect79.Location = new System.Drawing.Point(80, 40);
			this.sdRect79.Name = "sdRect79";
			this.sdRect79.Size = new System.Drawing.Size(360, 3);
			this.sdRect79.TabIndex = 7;
			this.sdRect79.Tag = "0";
			this.sdRect79.Text = "sdRect1";
			// 
			// tabPage19
			// 
			this.tabPage19.AutoScroll = true;
			this.tabPage19.Controls.Add(this.sdPage17);
			this.tabPage19.Location = new System.Drawing.Point(4, 58);
			this.tabPage19.Name = "tabPage19";
			this.tabPage19.Size = new System.Drawing.Size(472, 211);
			this.tabPage19.TabIndex = 18;
			this.tabPage19.Text = "SDDestination";
			// 
			// sdPage17
			// 
			this.sdPage17.Controls.Add(this.sdLayoutPanel19);
			this.sdPage17.DockPadding.All = 32;
			this.sdPage17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
			this.sdPage17.Location = new System.Drawing.Point(0, 0);
			this.sdPage17.Name = "sdPage17";
			this.sdPage17.Size = new System.Drawing.Size(596, 842);
			this.sdPage17.TabIndex = 3;
			this.sdPage17.Text = "sdPage17";
			// 
			// sdLayoutPanel19
			// 
			this.sdLayoutPanel19.BackColor = System.Drawing.SystemColors.Window;
			this.sdLayoutPanel19.Controls.Add(this.sdText273);
			this.sdLayoutPanel19.Controls.Add(this.sdText274);
			this.sdLayoutPanel19.Controls.Add(this.sdText275);
			this.sdLayoutPanel19.Controls.Add(this.sdText276);
			this.sdLayoutPanel19.Controls.Add(this.sdText277);
			this.sdLayoutPanel19.Controls.Add(this.sdText278);
			this.sdLayoutPanel19.Controls.Add(this.sdText279);
			this.sdLayoutPanel19.Controls.Add(this.sdText280);
			this.sdLayoutPanel19.Controls.Add(this.sdText281);
			this.sdLayoutPanel19.Controls.Add(this.sdText282);
			this.sdLayoutPanel19.Controls.Add(this.sdText283);
			this.sdLayoutPanel19.Controls.Add(this.sdText284);
			this.sdLayoutPanel19.Controls.Add(this.sdText285);
			this.sdLayoutPanel19.Controls.Add(this.sdLabel24);
			this.sdLayoutPanel19.Controls.Add(this.sdRect80);
			this.sdLayoutPanel19.Controls.Add(this.sdRect81);
			this.sdLayoutPanel19.Controls.Add(this.sdRect82);
			this.sdLayoutPanel19.Controls.Add(this.sdRect83);
			this.sdLayoutPanel19.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sdLayoutPanel19.Location = new System.Drawing.Point(32, 32);
			this.sdLayoutPanel19.Name = "sdLayoutPanel19";
			this.sdLayoutPanel19.Size = new System.Drawing.Size(532, 778);
			this.sdLayoutPanel19.TabIndex = 0;
			this.sdLayoutPanel19.Text = "sdLayoutPanel1";
			this.sdLayoutPanel19.BeforePrint += new Report.SDPrintPanelEvent(this.sdlayotupanel_BeforePrint);
			// 
			// sdText273
			// 
			this.sdText273.CharSpace = 0F;
			this.sdText273.FontColor = System.Drawing.Color.Black;
			this.sdText273.FontName = Report.SdFontName.Arial;
			this.sdText273.FontSize = 10F;
			this.sdText273.Leading = 12F;
			this.sdText273.Lines = new string[] {
													"public float Zoom [  get,  set ]"};
			this.sdText273.Location = new System.Drawing.Point(112, 440);
			this.sdText273.Name = "sdText273";
			this.sdText273.NodeValue = null;
			this.sdText273.Size = new System.Drawing.Size(320, 16);
			this.sdText273.TabIndex = 38;
			this.sdText273.Tag = "0";
			this.sdText273.WordSpace = 0F;
			// 
			// sdText274
			// 
			this.sdText274.CharSpace = 0F;
			this.sdText274.FontColor = System.Drawing.Color.Black;
			this.sdText274.FontName = Report.SdFontName.Arial;
			this.sdText274.FontSize = 10F;
			this.sdText274.Leading = 12F;
			this.sdText274.Lines = new string[] {
													"public long Top [  get,  set ]"};
			this.sdText274.Location = new System.Drawing.Point(112, 424);
			this.sdText274.Name = "sdText274";
			this.sdText274.NodeValue = null;
			this.sdText274.Size = new System.Drawing.Size(320, 16);
			this.sdText274.TabIndex = 37;
			this.sdText274.Tag = "0";
			this.sdText274.WordSpace = 0F;
			// 
			// sdText275
			// 
			this.sdText275.CharSpace = 0F;
			this.sdText275.FontColor = System.Drawing.Color.Black;
			this.sdText275.FontName = Report.SdFontName.Arial;
			this.sdText275.FontSize = 10F;
			this.sdText275.Leading = 12F;
			this.sdText275.Lines = new string[] {
													"public long Right [  get,  set ]"};
			this.sdText275.Location = new System.Drawing.Point(112, 408);
			this.sdText275.Name = "sdText275";
			this.sdText275.NodeValue = null;
			this.sdText275.Size = new System.Drawing.Size(320, 16);
			this.sdText275.TabIndex = 36;
			this.sdText275.Tag = "0";
			this.sdText275.WordSpace = 0F;
			// 
			// sdText276
			// 
			this.sdText276.CharSpace = 0F;
			this.sdText276.FontColor = System.Drawing.Color.Black;
			this.sdText276.FontName = Report.SdFontName.Arial;
			this.sdText276.FontSize = 10F;
			this.sdText276.Leading = 12F;
			this.sdText276.Lines = new string[] {
													"public long Left [  get,  set ]"};
			this.sdText276.Location = new System.Drawing.Point(112, 392);
			this.sdText276.Name = "sdText276";
			this.sdText276.NodeValue = null;
			this.sdText276.Size = new System.Drawing.Size(320, 16);
			this.sdText276.TabIndex = 35;
			this.sdText276.Tag = "0";
			this.sdText276.WordSpace = 0F;
			// 
			// sdText277
			// 
			this.sdText277.CharSpace = 0F;
			this.sdText277.FontColor = System.Drawing.Color.Black;
			this.sdText277.FontName = Report.SdFontName.Arial;
			this.sdText277.FontSize = 10F;
			this.sdText277.Leading = 12F;
			this.sdText277.Lines = new string[] {
													"public long Bottom [  get,  set ]"};
			this.sdText277.Location = new System.Drawing.Point(112, 376);
			this.sdText277.Name = "sdText277";
			this.sdText277.NodeValue = null;
			this.sdText277.Size = new System.Drawing.Size(320, 16);
			this.sdText277.TabIndex = 34;
			this.sdText277.Tag = "0";
			this.sdText277.WordSpace = 0F;
			// 
			// sdText278
			// 
			this.sdText278.CharSpace = 0F;
			this.sdText278.FontColor = System.Drawing.Color.Black;
			this.sdText278.FontName = Report.SdFontName.TimesRoman;
			this.sdText278.FontSize = 10F;
			this.sdText278.Leading = 12F;
			this.sdText278.Lines = new string[] {
													"Display the page with position and size indicated by Left,Top and ",
													"Zoom properties.",
													"Fit the page to the window.",
													"Fit the width of the page to the window. Only the Top property is ",
													"used to determine the top position. ",
													"Fit the height of the page to the window. Only the Left property is ",
													"used to determine the position of the left edge of the window. ",
													"Fit the rectangle specified by Left Top, Right,Bottom properties.",
													"Fit the pageÅfs bounding box to the window.",
													"Fit the width of the pageÅfs bounding box to the window.",
													"Fit the height of the pageÅfs bounding box to the window."};
			this.sdText278.Location = new System.Drawing.Point(152, 224);
			this.sdText278.Name = "sdText278";
			this.sdText278.NodeValue = null;
			this.sdText278.Size = new System.Drawing.Size(280, 136);
			this.sdText278.TabIndex = 33;
			this.sdText278.Tag = "0";
			this.sdText278.WordSpace = 0F;
			// 
			// sdText279
			// 
			this.sdText279.CharSpace = 0F;
			this.sdText279.FontColor = System.Drawing.Color.Black;
			this.sdText279.FontName = Report.SdFontName.TimesRoman;
			this.sdText279.FontSize = 10F;
			this.sdText279.Leading = 12F;
			this.sdText279.Lines = new string[] {
													"XYZ",
													"",
													"",
													"Fit",
													"FitH",
													"",
													"",
													"FitV",
													"",
													"",
													"FitR",
													"FitB",
													"FitBH",
													"FitBV"};
			this.sdText279.Location = new System.Drawing.Point(112, 224);
			this.sdText279.Name = "sdText279";
			this.sdText279.NodeValue = null;
			this.sdText279.Size = new System.Drawing.Size(40, 136);
			this.sdText279.TabIndex = 32;
			this.sdText279.Tag = "0";
			this.sdText279.WordSpace = 0F;
			// 
			// sdText280
			// 
			this.sdText280.CharSpace = 0F;
			this.sdText280.FontColor = System.Drawing.Color.Black;
			this.sdText280.FontName = Report.SdFontName.Arial;
			this.sdText280.FontSize = 10F;
			this.sdText280.Leading = 12F;
			this.sdText280.Lines = new string[] {
													"public sealed enum PdfDestinationType : System.Enum"};
			this.sdText280.Location = new System.Drawing.Point(112, 200);
			this.sdText280.Name = "sdText280";
			this.sdText280.NodeValue = null;
			this.sdText280.Size = new System.Drawing.Size(320, 16);
			this.sdText280.TabIndex = 31;
			this.sdText280.Tag = "0";
			this.sdText280.WordSpace = 0F;
			// 
			// sdText281
			// 
			this.sdText281.CharSpace = 0F;
			this.sdText281.FontColor = System.Drawing.Color.Black;
			this.sdText281.FontName = Report.SdFontName.TimesRoman;
			this.sdText281.FontSize = 10F;
			this.sdText281.Leading = 12F;
			this.sdText281.Lines = new string[] {
													"The DestinationType property determines the type of destination."};
			this.sdText281.Location = new System.Drawing.Point(112, 176);
			this.sdText281.Name = "sdText281";
			this.sdText281.NodeValue = null;
			this.sdText281.Size = new System.Drawing.Size(368, 24);
			this.sdText281.TabIndex = 30;
			this.sdText281.Tag = "0";
			this.sdText281.WordSpace = 0F;
			// 
			// sdText282
			// 
			this.sdText282.CharSpace = 0F;
			this.sdText282.FontColor = System.Drawing.Color.Black;
			this.sdText282.FontName = Report.SdFontName.Arial;
			this.sdText282.FontSize = 10F;
			this.sdText282.Leading = 12F;
			this.sdText282.Lines = new string[] {
													"public Report.PdfDestinationType DestinationType [  get,  set ]"};
			this.sdText282.Location = new System.Drawing.Point(112, 160);
			this.sdText282.Name = "sdText282";
			this.sdText282.NodeValue = null;
			this.sdText282.Size = new System.Drawing.Size(320, 16);
			this.sdText282.TabIndex = 29;
			this.sdText282.Tag = "0";
			this.sdText282.WordSpace = 0F;
			// 
			// sdText283
			// 
			this.sdText283.CharSpace = 0F;
			this.sdText283.FontBold = true;
			this.sdText283.FontColor = System.Drawing.Color.Black;
			this.sdText283.FontName = Report.SdFontName.Arial;
			this.sdText283.FontSize = 12F;
			this.sdText283.Leading = 14F;
			this.sdText283.Lines = new string[] {
													"2.13.1    SDDestination properties"};
			this.sdText283.Location = new System.Drawing.Point(64, 144);
			this.sdText283.Name = "sdText283";
			this.sdText283.NodeValue = null;
			this.sdText283.Size = new System.Drawing.Size(360, 16);
			this.sdText283.TabIndex = 27;
			this.sdText283.Tag = "4";
			this.sdText283.WordSpace = 0F;
			// 
			// sdText284
			// 
			this.sdText284.CharSpace = 0F;
			this.sdText284.FontColor = System.Drawing.Color.Black;
			this.sdText284.FontName = Report.SdFontName.TimesRoman;
			this.sdText284.FontSize = 10F;
			this.sdText284.Leading = 12F;
			this.sdText284.Lines = new string[] {
													"Use the SDDestination class to set the location of the display window on that",
													"page, and the zoom level."};
			this.sdText284.Location = new System.Drawing.Point(112, 80);
			this.sdText284.Name = "sdText284";
			this.sdText284.NodeValue = null;
			this.sdText284.Size = new System.Drawing.Size(328, 24);
			this.sdText284.TabIndex = 24;
			this.sdText284.Tag = "0";
			this.sdText284.WordSpace = 0F;
			// 
			// sdText285
			// 
			this.sdText285.CharSpace = 0F;
			this.sdText285.FontBold = true;
			this.sdText285.FontColor = System.Drawing.Color.Black;
			this.sdText285.FontName = Report.SdFontName.Arial;
			this.sdText285.FontSize = 12F;
			this.sdText285.Leading = 14F;
			this.sdText285.Lines = new string[] {
													"2.13       SDDestination"};
			this.sdText285.Location = new System.Drawing.Point(64, 64);
			this.sdText285.Name = "sdText285";
			this.sdText285.NodeValue = null;
			this.sdText285.Size = new System.Drawing.Size(360, 16);
			this.sdText285.TabIndex = 23;
			this.sdText285.Tag = "3";
			this.sdText285.WordSpace = 0F;
			// 
			// sdLabel24
			// 
			this.sdLabel24.Alignment = Report.SDAlignment.RightJustify;
			this.sdLabel24.CharSpace = 0F;
			this.sdLabel24.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.sdLabel24.FontColor = System.Drawing.Color.Black;
			this.sdLabel24.FontName = Report.SdFontName.Arial;
			this.sdLabel24.FontSize = 8F;
			this.sdLabel24.Location = new System.Drawing.Point(0, 765);
			this.sdLabel24.Name = "sdLabel24";
			this.sdLabel24.Size = new System.Drawing.Size(532, 13);
			this.sdLabel24.TabIndex = 11;
			this.sdLabel24.Tag = "0";
			this.sdLabel24.Text = "copyright (c) 2002-2003 Serdar Dirican";
			this.sdLabel24.WordSpace = 0F;
			// 
			// sdRect80
			// 
			this.sdRect80.FillColor = System.Drawing.Color.Transparent;
			this.sdRect80.LineColor = System.Drawing.Color.Black;
			this.sdRect80.LineStyle = Report.PenStyle.Solid;
			this.sdRect80.LineWidth = 0F;
			this.sdRect80.Location = new System.Drawing.Point(256, 24);
			this.sdRect80.Name = "sdRect80";
			this.sdRect80.Size = new System.Drawing.Size(2, 24);
			this.sdRect80.TabIndex = 10;
			this.sdRect80.Tag = "0";
			this.sdRect80.Text = "sdRect4";
			// 
			// sdRect81
			// 
			this.sdRect81.FillColor = System.Drawing.Color.Transparent;
			this.sdRect81.LineColor = System.Drawing.Color.Black;
			this.sdRect81.LineStyle = Report.PenStyle.Solid;
			this.sdRect81.LineWidth = 0F;
			this.sdRect81.Location = new System.Drawing.Point(440, 24);
			this.sdRect81.Name = "sdRect81";
			this.sdRect81.Size = new System.Drawing.Size(2, 24);
			this.sdRect81.TabIndex = 9;
			this.sdRect81.Tag = "0";
			this.sdRect81.Text = "sdRect3";
			// 
			// sdRect82
			// 
			this.sdRect82.FillColor = System.Drawing.Color.Transparent;
			this.sdRect82.LineColor = System.Drawing.Color.Black;
			this.sdRect82.LineStyle = Report.PenStyle.Solid;
			this.sdRect82.LineWidth = 0F;
			this.sdRect82.Location = new System.Drawing.Point(80, 24);
			this.sdRect82.Name = "sdRect82";
			this.sdRect82.Size = new System.Drawing.Size(2, 24);
			this.sdRect82.TabIndex = 8;
			this.sdRect82.Tag = "0";
			this.sdRect82.Text = "sdRect2";
			// 
			// sdRect83
			// 
			this.sdRect83.DrawLine = true;
			this.sdRect83.FillColor = System.Drawing.Color.Transparent;
			this.sdRect83.LineColor = System.Drawing.Color.Black;
			this.sdRect83.LineStyle = Report.PenStyle.Solid;
			this.sdRect83.LineWidth = 2F;
			this.sdRect83.Location = new System.Drawing.Point(80, 40);
			this.sdRect83.Name = "sdRect83";
			this.sdRect83.Size = new System.Drawing.Size(360, 3);
			this.sdRect83.TabIndex = 7;
			this.sdRect83.Tag = "0";
			this.sdRect83.Text = "sdRect1";
			// 
			// tabPage20
			// 
			this.tabPage20.AutoScroll = true;
			this.tabPage20.Controls.Add(this.sdPage18);
			this.tabPage20.Location = new System.Drawing.Point(4, 58);
			this.tabPage20.Name = "tabPage20";
			this.tabPage20.Size = new System.Drawing.Size(472, 211);
			this.tabPage20.TabIndex = 19;
			this.tabPage20.Text = "Copyright";
			// 
			// sdPage18
			// 
			this.sdPage18.Controls.Add(this.sdLayoutPanel20);
			this.sdPage18.DockPadding.All = 32;
			this.sdPage18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
			this.sdPage18.Location = new System.Drawing.Point(0, 0);
			this.sdPage18.Name = "sdPage18";
			this.sdPage18.Size = new System.Drawing.Size(596, 842);
			this.sdPage18.TabIndex = 3;
			this.sdPage18.Text = "sdPage18";
			// 
			// sdLayoutPanel20
			// 
			this.sdLayoutPanel20.BackColor = System.Drawing.SystemColors.Window;
			this.sdLayoutPanel20.Controls.Add(this.sdText286);
			this.sdLayoutPanel20.Controls.Add(this.sdText287);
			this.sdLayoutPanel20.Controls.Add(this.sdLabel25);
			this.sdLayoutPanel20.Controls.Add(this.sdRect84);
			this.sdLayoutPanel20.Controls.Add(this.sdRect85);
			this.sdLayoutPanel20.Controls.Add(this.sdRect86);
			this.sdLayoutPanel20.Controls.Add(this.sdRect87);
			this.sdLayoutPanel20.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sdLayoutPanel20.Location = new System.Drawing.Point(32, 32);
			this.sdLayoutPanel20.Name = "sdLayoutPanel20";
			this.sdLayoutPanel20.Size = new System.Drawing.Size(532, 778);
			this.sdLayoutPanel20.TabIndex = 0;
			this.sdLayoutPanel20.Text = "sdLayoutPanel1";
			this.sdLayoutPanel20.BeforePrint += new Report.SDPrintPanelEvent(this.sdlayotupanel_BeforePrint);
			// 
			// sdText286
			// 
			this.sdText286.CharSpace = 0F;
			this.sdText286.FontColor = System.Drawing.Color.Black;
			this.sdText286.FontName = Report.SdFontName.Arial;
			this.sdText286.FontSize = 10F;
			this.sdText286.Leading = 12F;
			this.sdText286.Lines = new string[] {
													"Copyright (C) 2002-2003 Serdar Dirican",
													"",
													"",
													"This library is free software; you can redistribute it and/or modify it under the" +
													"",
													"terms of the GNU Library General Public License as published by the Free",
													"Software Foundation; either version 2 of the License, or any later version.",
													"",
													"",
													"This library is distributed in the hope that it will be useful, but WITHOUT ANY",
													"WARRANTY; without even the implied warranty of MERCHANTABILITY or",
													"FITNESS FOR A PARTICULAR PURPOSE. See the GNU Library general Public",
													"License for more details."};
			this.sdText286.Location = new System.Drawing.Point(80, 136);
			this.sdText286.Name = "sdText286";
			this.sdText286.NodeValue = null;
			this.sdText286.Size = new System.Drawing.Size(368, 128);
			this.sdText286.TabIndex = 13;
			this.sdText286.Tag = "0";
			this.sdText286.WordSpace = 0F;
			// 
			// sdText287
			// 
			this.sdText287.CharSpace = 0F;
			this.sdText287.FontBold = true;
			this.sdText287.FontColor = System.Drawing.Color.Black;
			this.sdText287.FontName = Report.SdFontName.Arial;
			this.sdText287.FontSize = 24F;
			this.sdText287.Leading = 14F;
			this.sdText287.Lines = new string[] {
													"Copyright"};
			this.sdText287.Location = new System.Drawing.Point(192, 80);
			this.sdText287.Name = "sdText287";
			this.sdText287.NodeValue = null;
			this.sdText287.Size = new System.Drawing.Size(120, 30);
			this.sdText287.TabIndex = 12;
			this.sdText287.Tag = "2";
			this.sdText287.WordSpace = 0F;
			// 
			// sdLabel25
			// 
			this.sdLabel25.Alignment = Report.SDAlignment.RightJustify;
			this.sdLabel25.CharSpace = 0F;
			this.sdLabel25.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.sdLabel25.FontColor = System.Drawing.Color.Black;
			this.sdLabel25.FontName = Report.SdFontName.Arial;
			this.sdLabel25.FontSize = 8F;
			this.sdLabel25.Location = new System.Drawing.Point(0, 765);
			this.sdLabel25.Name = "sdLabel25";
			this.sdLabel25.Size = new System.Drawing.Size(532, 13);
			this.sdLabel25.TabIndex = 11;
			this.sdLabel25.Tag = "0";
			this.sdLabel25.Text = "copyright (c) 2002-2003 Serdar Dirican";
			this.sdLabel25.WordSpace = 0F;
			// 
			// sdRect84
			// 
			this.sdRect84.FillColor = System.Drawing.Color.Transparent;
			this.sdRect84.LineColor = System.Drawing.Color.Black;
			this.sdRect84.LineStyle = Report.PenStyle.Solid;
			this.sdRect84.LineWidth = 0F;
			this.sdRect84.Location = new System.Drawing.Point(256, 24);
			this.sdRect84.Name = "sdRect84";
			this.sdRect84.Size = new System.Drawing.Size(2, 24);
			this.sdRect84.TabIndex = 10;
			this.sdRect84.Tag = "0";
			this.sdRect84.Text = "sdRect4";
			// 
			// sdRect85
			// 
			this.sdRect85.FillColor = System.Drawing.Color.Transparent;
			this.sdRect85.LineColor = System.Drawing.Color.Black;
			this.sdRect85.LineStyle = Report.PenStyle.Solid;
			this.sdRect85.LineWidth = 0F;
			this.sdRect85.Location = new System.Drawing.Point(440, 24);
			this.sdRect85.Name = "sdRect85";
			this.sdRect85.Size = new System.Drawing.Size(2, 24);
			this.sdRect85.TabIndex = 9;
			this.sdRect85.Tag = "06";
			this.sdRect85.Text = "sdRect3";
			// 
			// sdRect86
			// 
			this.sdRect86.FillColor = System.Drawing.Color.Transparent;
			this.sdRect86.LineColor = System.Drawing.Color.Black;
			this.sdRect86.LineStyle = Report.PenStyle.Solid;
			this.sdRect86.LineWidth = 0F;
			this.sdRect86.Location = new System.Drawing.Point(80, 24);
			this.sdRect86.Name = "sdRect86";
			this.sdRect86.Size = new System.Drawing.Size(2, 24);
			this.sdRect86.TabIndex = 8;
			this.sdRect86.Tag = "0";
			this.sdRect86.Text = "sdRect2";
			// 
			// sdRect87
			// 
			this.sdRect87.DrawLine = true;
			this.sdRect87.FillColor = System.Drawing.Color.Transparent;
			this.sdRect87.LineColor = System.Drawing.Color.Black;
			this.sdRect87.LineStyle = Report.PenStyle.Solid;
			this.sdRect87.LineWidth = 2F;
			this.sdRect87.Location = new System.Drawing.Point(80, 40);
			this.sdRect87.Name = "sdRect87";
			this.sdRect87.Size = new System.Drawing.Size(360, 3);
			this.sdRect87.TabIndex = 7;
			this.sdRect87.Tag = "0";
			this.sdRect87.Text = "sdRect1";
			// 
			// sdReport1
			// 
			this.sdReport1.Author = "Serdar Dirican";
			this.sdReport1.CreationDate = new System.DateTime(2003, 1, 26, 14, 11, 12, 487);
			this.sdReport1.Creator = "MakeDoc Demo";
			this.sdReport1.FileName = "default.pdf";
			this.sdReport1.Keywords = null;
			this.sdReport1.ModDate = new System.DateTime(((long)(0)));
			this.sdReport1.PageLayout = Report.SDPageLayout.OneColumn;
			this.sdReport1.PageMode = Report.SDPageMode.UseOutlines;
			this.sdReport1.Subject = null;
			this.sdReport1.Title = "PdfCreator Reference";
			this.sdReport1.UseOutlines = true;
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.DefaultExt = "pdf";
			this.saveFileDialog1.FileName = "PdfCreatorRef.pdf";
			this.saveFileDialog1.Filter = "PDF Files|*.pdf|All Files|*.*";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(784, 761);
			this.Controls.Add(this.tabControl1);
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.CoverPage.ResumeLayout(false);
			this.sdLayoutPanel1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.ContentsPage.ResumeLayout(false);
			this.sdlayotupanel.ResumeLayout(false);
			this.sdGridPanel1.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.sdPage1.ResumeLayout(false);
			this.sdLayoutPanel3.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			this.sdPage2.ResumeLayout(false);
			this.sdLayoutPanel4.ResumeLayout(false);
			this.tabPage5.ResumeLayout(false);
			this.sdPage3.ResumeLayout(false);
			this.sdLayoutPanel5.ResumeLayout(false);
			this.tabPage6.ResumeLayout(false);
			this.sdPage4.ResumeLayout(false);
			this.sdLayoutPanel6.ResumeLayout(false);
			this.tabPage7.ResumeLayout(false);
			this.sdPage5.ResumeLayout(false);
			this.sdLayoutPanel7.ResumeLayout(false);
			this.tabPage8.ResumeLayout(false);
			this.sdPage6.ResumeLayout(false);
			this.sdLayoutPanel8.ResumeLayout(false);
			this.tabPage9.ResumeLayout(false);
			this.sdPage7.ResumeLayout(false);
			this.sdLayoutPanel9.ResumeLayout(false);
			this.tabPage10.ResumeLayout(false);
			this.sdPage8.ResumeLayout(false);
			this.sdLayoutPanel10.ResumeLayout(false);
			this.tabPage11.ResumeLayout(false);
			this.sdPage9.ResumeLayout(false);
			this.sdLayoutPanel11.ResumeLayout(false);
			this.tabPage12.ResumeLayout(false);
			this.sdPage10.ResumeLayout(false);
			this.sdLayoutPanel12.ResumeLayout(false);
			this.tabPage13.ResumeLayout(false);
			this.sdPage11.ResumeLayout(false);
			this.sdLayoutPanel13.ResumeLayout(false);
			this.tabPage14.ResumeLayout(false);
			this.sdPage12.ResumeLayout(false);
			this.sdLayoutPanel14.ResumeLayout(false);
			this.tabPage15.ResumeLayout(false);
			this.sdPage13.ResumeLayout(false);
			this.sdLayoutPanel15.ResumeLayout(false);
			this.tabPage16.ResumeLayout(false);
			this.sdPage14.ResumeLayout(false);
			this.sdLayoutPanel16.ResumeLayout(false);
			this.tabPage17.ResumeLayout(false);
			this.sdPage15.ResumeLayout(false);
			this.sdLayoutPanel17.ResumeLayout(false);
			this.tabPage18.ResumeLayout(false);
			this.sdPage16.ResumeLayout(false);
			this.sdLayoutPanel18.ResumeLayout(false);
			this.tabPage19.ResumeLayout(false);
			this.sdPage17.ResumeLayout(false);
			this.sdLayoutPanel19.ResumeLayout(false);
			this.tabPage20.ResumeLayout(false);
			this.sdPage18.ResumeLayout(false);
			this.sdLayoutPanel20.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			FContentsList=new ArrayList();
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void CoverPage_PrintPage(object sender, Report.SDPrintPageEventArgs arg)
		{
			SDDestination dest;
			dest=sdReport1.CreateDestination();
			dest.DestinationType=PdfDestinationType.XYZ;
			sdReport1.OpenAction(dest);
		}

		private void sdGridPanel1_BeforePrintChild(object sender, Report.SDPrintChildPanelEventArgs arg)
		{
			ContentsElement Felement;
			
			if(FPos<FContentsList.Count)
			{
				Felement=(ContentsElement)FContentsList[FPos];
				if((Felement.Title=="Chapter1 Introduction")||(Felement.Title=="Chapter2 Component Reference"))
				{
					lblSectionName.FontBold=true;					
					lblSectionName.FontSize=12;
					lblSectionName.Top=0;
				}
				else
				{
					lblSectionName.FontBold=false;					
					lblSectionName.FontSize=11;					
					lblSectionName.Top=3;
				}
				lblSectionName.Text=Felement.Title;
				Felement.Data=arg.ACanvas.PdfCanvas.Doc.CreateAnnotation
					(PdfAnnotationSubType.asLink,Generic._PdfRect
					(arg.Rect.Left,arg.ACanvas.PageHeight-arg.Rect.Top,
					arg.Rect.Right,arg.ACanvas.PageHeight-arg.Rect.Bottom));
				int[] i={0,0,0};
				Felement.Data.AddItem("Border",new PdfArray(null,i));
			}
			else
			{
				lblSectionName.Text="";
			}
			FPos++;
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			SDPage APage;

			if(saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				sdReport1.FileName=saveFileDialog1.FileName;
				sdReport1.BeginDoc();
				FCurrentOutline[0]=sdReport1.OutlineRoot;
				sdReport1.OutlineRoot.Opened=true;
				sdReport1.Print(CoverPage);

				CreateContentsList();

				FPos=0;
				while(FPos<FContentsList.Count)
				{
					sdReport1.Print(ContentsPage);
					ContentsText.Lines[0]="";
					ContentsText.Tag=0;
				}
				for(int i=2;i<tabControl1.TabCount;i++)
				{
					APage=(SDPage)(tabControl1.TabPages[i].Controls[0]);
					if(APage!=null)
						sdReport1.Print(APage);
				}
				sdReport1.EndDoc();
			}
		}

		void CreateContentsList()
		{
			int FChapterIndex;
			SDPage APage;
			SDPanel APanel;
			Control AControl;
			ContentsElement FContestElement;
			SDText FText;
			SDLabel FLabel;

			FChapterIndex=0;
			for(int i=0;i<tabControl1.TabCount;i++)
			{
				APage=(SDPage)(tabControl1.TabPages[i].Controls[0]);
				if((APage!=null)&&(APage.Controls[0] is SDPanel))
				{
					APanel=(SDPanel)(APage.Controls[0]);
					for(int j=APanel.Controls.Count-1;j>-1;j--)
					{
						AControl=APanel.Controls[j];
						if(AControl.Tag.ToString()=="2")
						{
							FContestElement=new ContentsElement();
							if(AControl is SDText)
							{
								FText=(SDText)AControl;
								FContestElement.Title=FText.Lines[0];
							}
							if(AControl is SDLabel)
							{
								FLabel=(SDLabel)AControl;
								FContestElement.Title=FLabel.Text;
							}
							if((FContestElement.Title!="Contents")&&(FContestElement.Title!="Copyright"))
							{
								FChapterIndex++;
								FContentsList.Add(new ContentsElement());
								FContestElement.Title="Chapter"+FChapterIndex.ToString()+" "+FContestElement.Title;
								FContestElement.Target=(SDItem)AControl;
								FContentsList.Add(FContestElement);
							}
						}
						else if((AControl.Tag.ToString()=="3")||(AControl.Tag.ToString()=="4"))
						{
							FContestElement=new ContentsElement();
							if(AControl is SDText)
							{
								FText=(SDText)AControl;
								FContestElement.Title=FText.Lines[0];
							}
							if(AControl is SDLabel)
							{
								FLabel=(SDLabel)AControl;
								FContestElement.Title=FLabel.Text;
							}
							FContestElement.Target=(SDItem)AControl;
							FContentsList.Add(FContestElement);
						}
					}				
				}
			}
		}

		private void sdlayotupanel_BeforePrint(object sender, Report.SDPrintPanelEventArgs arg)
		{
			float FTextWidth;
			int w;
			ArrayList FControlList;
			SDPanel FPanel=(SDPanel)sender;
			int tmpYPos;
			int ItemIndex;
			Control FControl;
			SDText FText;
			int FLevel;
			SDDestination FDestination;
			ContentsElement Element;

			if(sdReport1.PageNumber>1)
			{
				arg.ACanvas.SetFont("Times-Roman",8);
				w=sdReport1.PageNumber-1;
				FTextWidth=arg.ACanvas.TextWidth(w.ToString());
				arg.ACanvas.TextOut((arg.ACanvas.PageWidth-FTextWidth)/2-9,
					40,w.ToString());
			}
			FControlList=new ArrayList();
			for(int i=0;i<FPanel.Controls.Count;i++)			
				if((FPanel.Controls[i] is SDText)&&(FPanel.Controls[i].Tag.ToString()!="0"))
				{
					tmpYPos=FPanel.Controls[i].Top;
					ItemIndex=-1;
					for(int j=0;j<FControlList.Count;j++)
					{
						FControl=(Control)FControlList[j];
						if(FControl.Top>tmpYPos)
						{
							ItemIndex=j;
							break;
						}
					}
					if(ItemIndex==-1)
						FControlList.Add(FPanel.Controls[i]);
					else
						FControlList.Insert(ItemIndex,FPanel.Controls[i]);
				}

			for(int i=0;i<FControlList.Count;i++)
			{
				FText=(SDText)FControlList[i];
				if(FText.Tag.ToString()!="0")
				{
					FLevel=Convert.ToInt32(FText.Tag.ToString());
					if(FCurrentOutline[FLevel-1]!=null)
					{
						FCurrentOutline[FLevel]=FCurrentOutline[FLevel-1].AddChild();
						if(FLevel==1)
							FCurrentOutline[FLevel].Opened=true;
						FCurrentOutline[FLevel].Title=FText.Lines[0];
						FDestination=sdReport1.CreateDestination();
						FCurrentOutline[FLevel].Dest=FDestination;

						FDestination.DestinationType=PdfDestinationType.XYZ;
						FDestination.Top=FText.Top;
						FDestination.Left=FText.Left;
						FDestination.Zoom=0;

						Element=FindLink((SDText)FControlList[i]);
						if(Element!=null)
							Element.Data.AddItem("Dest",FDestination.FData.GetValue());

					}
				}
			}
		}

		ContentsElement FindLink(SDItem AItem)
		{
			ContentsElement Element;

			for(int i=FContentsList.Count-1;i>-1;i--)
			{
				Element=(ContentsElement)FContentsList[i];
				if(Element.Target==AItem)
					return Element;
			}
			return null;
		}
	}
}
