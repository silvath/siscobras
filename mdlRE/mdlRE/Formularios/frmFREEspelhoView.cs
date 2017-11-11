using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlRE.Formularios
{
	/// <summary>
	/// Summary description for frmFREEspelhoView.
	/// </summary>
	public class frmFREEspelhoView : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate void delCallCarregaDadosEspelhoRE(int nIdREEspelho,out string strRENumero,out string strREDataRegistro,out string strRESituacao,out string strREREspRegistro,out string strREOperador,out string strREDataHora,out string strExportadorCPF,out string strExportadorNome,out string strEOCodigo1,out string strEOCodigo2,out string strEOCodigo3,out string strEOCodigo4,out string strEOCodigo5,out string strEOCodigo6,out string strEONumRV,out string strEONumAtoConc,out string strEONumRC,out string strEODataLimiteOperacao,out string strEOGEDERE,out string strEOMargemNaoSacada,out string strEODIRIVinc,out string strEONumProcesso,out string strEOSGPVinc,out string strUnidadeRFDespacho,out string strUnidadeRFEmbarque,out string strImportadorNome,out string strImportadorEndereco,out string strImportadorPais);
		#endregion
		#region Events
			public event delCallCarregaDadosEspelhoRE eCallCarregaDadosEspelhoRE;
		#endregion
		#region Events Methods
			public virtual void OnCallCarregaDadosEspelhoRE()
			{
				if (eCallCarregaDadosEspelhoRE == null)
					return;
				string strRENumero,strREDataRegistro,strRESituacao,strREREspRegistro,strREOperador,strREDataHora,strExportadorCPF,strExportadorNome,strEOCodigo1,strEOCodigo2,strEOCodigo3,strEOCodigo4,strEOCodigo5,strEOCodigo6,strEONumRV,strEONumAtoConc,strEONumRC,strEODataLimiteOperacao,strEOGEDERE,strEOMargemNaoSacada,strEODIRIVinc,strEONumProcesso,strEOSGPVinc,strUnidadeRFDespacho,strUnidadeRFEmbarque,strImportadorNome,strImportadorEndereco,strImportadorPais;
                eCallCarregaDadosEspelhoRE(m_nIdREEspelho,out strRENumero,out strREDataRegistro,out strRESituacao,out strREREspRegistro,out strREOperador,out strREDataHora,out strExportadorCPF,out strExportadorNome,out strEOCodigo1,out strEOCodigo2,out strEOCodigo3,out strEOCodigo4,out strEOCodigo5,out strEOCodigo6,out strEONumRV,out strEONumAtoConc,out strEONumRC,out strEODataLimiteOperacao,out strEOGEDERE,out strEOMargemNaoSacada,out strEODIRIVinc,out strEONumProcesso,out strEOSGPVinc,out strUnidadeRFDespacho,out strUnidadeRFEmbarque,out strImportadorNome,out strImportadorEndereco,out strImportadorPais);

				// Tela 01
				m_txtRENumero.Text = strRENumero;
				m_txtREDataRegistro.Text  = strREDataRegistro;
				m_txtRESituacao.Text = strRESituacao;
				m_txtRespReg.Text = strREREspRegistro;
				m_txtOperador.Text = strREOperador;
				m_txtDataHora.Text = strREDataHora;
				m_txtExportadorCPF.Text = strExportadorCPF;
				m_txtExportadorNome.Text = strExportadorNome;
				m_txtEOCodigo1.Text = strEOCodigo1;
				m_txtEOCodigo2.Text = strEOCodigo2;
				m_txtEOCodigo3.Text = strEOCodigo3;
				m_txtEOCodigo4.Text = strEOCodigo4;
				m_txtEOCodigo5.Text = strEOCodigo5;
				m_txtEOCodigo6.Text = strEOCodigo6;
				m_txtEONumRV.Text = strEONumRV;
				m_txtEONumAtoConc.Text = strEONumAtoConc;
				m_txtEONumRC.Text = strEONumRC;
				m_txtEODataLimiteOperacao.Text = strEODataLimiteOperacao;
				m_txtEOGEDERE.Text = strEOGEDERE;
				m_txtEOMargemNaoSacada.Text = strEOMargemNaoSacada;
				m_txtEODIRIVinculado.Text = strEODIRIVinc;
				m_txtEONumProcesso.Text = strEONumProcesso;
				m_txtEOSGPVinculado.Text = strEOSGPVinc;
				m_txtUnidadeRFDespacho.Text = strUnidadeRFDespacho;
				m_txtUnidadeRFEmbarque.Text = strUnidadeRFEmbarque;
				m_txtImportadorNome.Text =  strImportadorNome;
				m_txtImportadorEndereco.Text = strImportadorEndereco;
				m_txtImportadorPais.Text = strImportadorPais;

				// Tela 02
			}
		#endregion

		#region Atributes
				private int m_nIdREEspelho = -1;

				private bool m_bConfirmed = false;

				private System.Windows.Forms.GroupBox m_gbMain;
				internal mdlComponentesGraficos.Button m_btCancelar;
				internal mdlComponentesGraficos.Button m_btOk;
				private System.Windows.Forms.TabControl tabControl1;
				private System.Windows.Forms.TabPage m_tpTela01;
				private System.Windows.Forms.TabPage m_tpTela02;
				private System.Windows.Forms.TabPage m_tpAnexos;
				private System.Windows.Forms.GroupBox m_gbTela001;
				private System.Windows.Forms.Label label18;
				private System.Windows.Forms.Label label17;
				private System.Windows.Forms.Label label16;
				private System.Windows.Forms.Label label15;
				private System.Windows.Forms.Label label14;
				private System.Windows.Forms.Label label13;
				private System.Windows.Forms.Label label12;
				private System.Windows.Forms.Label label11;
				private System.Windows.Forms.Label label10;
				private System.Windows.Forms.Label label9;
				private System.Windows.Forms.Label label8;
				private System.Windows.Forms.Label label7;
				private System.Windows.Forms.Label label6;
				private System.Windows.Forms.Label label5;
				private System.Windows.Forms.Label label4;
				private System.Windows.Forms.Label label3;
				private System.Windows.Forms.Label label2;
				private mdlComponentesGraficos.TextBox m_txtRENumero;
				private System.Windows.Forms.Label label1;
				private System.Windows.Forms.GroupBox groupBox1;
				private System.Windows.Forms.Label label28;
				private System.Windows.Forms.Label label27;
				private System.Windows.Forms.Label label26;
				private System.Windows.Forms.Label label25;
				private System.Windows.Forms.Label label24;
				private System.Windows.Forms.Label label23;
				private System.Windows.Forms.Label label22;
				private System.Windows.Forms.Label label21;
				private System.Windows.Forms.Label label20;
				private System.Windows.Forms.Label label19;
				private System.Windows.Forms.Label label29;
				private System.Windows.Forms.Label label30;
				private System.Windows.Forms.Label label31;
				private System.Windows.Forms.Label label32;
				private System.Windows.Forms.Label label33;
				private System.Windows.Forms.Label label34;
				private System.Windows.Forms.Label label35;
				private System.Windows.Forms.Label label36;
				private mdlComponentesGraficos.TextBox textBox28;
				private System.Windows.Forms.Label label37;
				private mdlComponentesGraficos.TextBox textBox29;
				private System.Windows.Forms.Label label38;
				private mdlComponentesGraficos.TextBox textBox30;
				private mdlComponentesGraficos.TextBox textBox31;
				private mdlComponentesGraficos.TextBox textBox32;
				private mdlComponentesGraficos.TextBox textBox33;
				private System.Windows.Forms.Label label39;
				private System.Windows.Forms.Label label40;
				private System.Windows.Forms.Label label41;
				private System.Windows.Forms.Label label42;
				private System.Windows.Forms.Label label43;
				private System.Windows.Forms.Label label44;
				private mdlComponentesGraficos.TextBox textBox34;
				private mdlComponentesGraficos.TextBox textBox35;
				private mdlComponentesGraficos.TextBox textBox36;
				private mdlComponentesGraficos.TextBox textBox37;
				private mdlComponentesGraficos.TextBox textBox38;
				private mdlComponentesGraficos.TextBox textBox39;
				private mdlComponentesGraficos.TextBox textBox40;
				private mdlComponentesGraficos.TextBox textBox41;
				private mdlComponentesGraficos.TextBox textBox42;
				private mdlComponentesGraficos.TextBox textBox43;
				private mdlComponentesGraficos.TextBox textBox44;
		private mdlComponentesGraficos.TextBox m_txtExportadorCPF;
		private mdlComponentesGraficos.TextBox m_txtExportadorNome;
		private mdlComponentesGraficos.TextBox m_txtDataHora;
		private mdlComponentesGraficos.TextBox m_txtOperador;
		private mdlComponentesGraficos.TextBox m_txtRespReg;
		private mdlComponentesGraficos.TextBox m_txtREDataRegistro;
		private mdlComponentesGraficos.TextBox m_txtRESituacao;
		private mdlComponentesGraficos.TextBox m_txtEONumAtoConc;
		private mdlComponentesGraficos.TextBox m_txtEONumRC;
		private mdlComponentesGraficos.TextBox m_txtEONumRV;
		private mdlComponentesGraficos.TextBox m_txtEOCodigo6;
		private mdlComponentesGraficos.TextBox m_txtEOCodigo5;
		private mdlComponentesGraficos.TextBox m_txtEOCodigo4;
		private mdlComponentesGraficos.TextBox m_txtEOCodigo3;
		private mdlComponentesGraficos.TextBox m_txtEOCodigo2;
		private mdlComponentesGraficos.TextBox m_txtEOCodigo1;
		private mdlComponentesGraficos.TextBox m_txtEONumProcesso;
		private mdlComponentesGraficos.TextBox m_txtEOMargemNaoSacada;
		private mdlComponentesGraficos.TextBox m_txtEODataLimiteOperacao;
		private mdlComponentesGraficos.TextBox m_txtImportadorPais;
		private mdlComponentesGraficos.TextBox m_txtImportadorEndereco;
		private mdlComponentesGraficos.TextBox m_txtImportadorNome;
		private mdlComponentesGraficos.TextBox m_txtUnidadeRFEmbarque;
		private mdlComponentesGraficos.TextBox m_txtUnidadeRFDespacho;
		private mdlComponentesGraficos.TextBox m_txtEOSGPVinculado;
		private mdlComponentesGraficos.TextBox m_txtEODIRIVinculado;
		private mdlComponentesGraficos.TextBox m_txtEOGEDERE;
				private System.ComponentModel.Container components = null;
		#endregion
		#region Properties
			public bool Confirmed
			{
				get
				{
					return(m_bConfirmed);
				}
			}
		#endregion
		#region Constructors
			public frmFREEspelhoView(int nIdREEspelho)
			{
				m_nIdREEspelho = nIdREEspelho;
				InitializeComponent();
				vMostraCor();
			}

			/// <summary>
			/// Clean up any resources being used.
			/// </summary>
			protected override void Dispose( bool disposing )
			{
				if( disposing )
				{
					if(components != null)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFREEspelhoView));
			this.m_gbMain = new System.Windows.Forms.GroupBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.m_tpTela01 = new System.Windows.Forms.TabPage();
			this.m_gbTela001 = new System.Windows.Forms.GroupBox();
			this.m_txtEONumProcesso = new mdlComponentesGraficos.TextBox();
			this.m_txtEOMargemNaoSacada = new mdlComponentesGraficos.TextBox();
			this.m_txtEODataLimiteOperacao = new mdlComponentesGraficos.TextBox();
			this.m_txtEONumAtoConc = new mdlComponentesGraficos.TextBox();
			this.m_txtImportadorPais = new mdlComponentesGraficos.TextBox();
			this.m_txtImportadorEndereco = new mdlComponentesGraficos.TextBox();
			this.m_txtImportadorNome = new mdlComponentesGraficos.TextBox();
			this.m_txtUnidadeRFEmbarque = new mdlComponentesGraficos.TextBox();
			this.m_txtUnidadeRFDespacho = new mdlComponentesGraficos.TextBox();
			this.m_txtEOSGPVinculado = new mdlComponentesGraficos.TextBox();
			this.m_txtEODIRIVinculado = new mdlComponentesGraficos.TextBox();
			this.m_txtEOGEDERE = new mdlComponentesGraficos.TextBox();
			this.m_txtEONumRC = new mdlComponentesGraficos.TextBox();
			this.m_txtEONumRV = new mdlComponentesGraficos.TextBox();
			this.m_txtEOCodigo6 = new mdlComponentesGraficos.TextBox();
			this.m_txtEOCodigo5 = new mdlComponentesGraficos.TextBox();
			this.m_txtEOCodigo4 = new mdlComponentesGraficos.TextBox();
			this.m_txtEOCodigo3 = new mdlComponentesGraficos.TextBox();
			this.m_txtEOCodigo2 = new mdlComponentesGraficos.TextBox();
			this.m_txtEOCodigo1 = new mdlComponentesGraficos.TextBox();
			this.m_txtExportadorCPF = new mdlComponentesGraficos.TextBox();
			this.m_txtExportadorNome = new mdlComponentesGraficos.TextBox();
			this.m_txtDataHora = new mdlComponentesGraficos.TextBox();
			this.label36 = new System.Windows.Forms.Label();
			this.m_txtOperador = new mdlComponentesGraficos.TextBox();
			this.label35 = new System.Windows.Forms.Label();
			this.m_txtRespReg = new mdlComponentesGraficos.TextBox();
			this.label34 = new System.Windows.Forms.Label();
			this.m_txtREDataRegistro = new mdlComponentesGraficos.TextBox();
			this.label33 = new System.Windows.Forms.Label();
			this.label32 = new System.Windows.Forms.Label();
			this.label31 = new System.Windows.Forms.Label();
			this.label30 = new System.Windows.Forms.Label();
			this.label29 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.m_txtRESituacao = new mdlComponentesGraficos.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.m_txtRENumero = new mdlComponentesGraficos.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.m_tpTela02 = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.textBox44 = new mdlComponentesGraficos.TextBox();
			this.textBox43 = new mdlComponentesGraficos.TextBox();
			this.textBox42 = new mdlComponentesGraficos.TextBox();
			this.textBox41 = new mdlComponentesGraficos.TextBox();
			this.textBox40 = new mdlComponentesGraficos.TextBox();
			this.textBox39 = new mdlComponentesGraficos.TextBox();
			this.textBox38 = new mdlComponentesGraficos.TextBox();
			this.textBox37 = new mdlComponentesGraficos.TextBox();
			this.textBox36 = new mdlComponentesGraficos.TextBox();
			this.textBox35 = new mdlComponentesGraficos.TextBox();
			this.textBox34 = new mdlComponentesGraficos.TextBox();
			this.label44 = new System.Windows.Forms.Label();
			this.label43 = new System.Windows.Forms.Label();
			this.label42 = new System.Windows.Forms.Label();
			this.label41 = new System.Windows.Forms.Label();
			this.label40 = new System.Windows.Forms.Label();
			this.label39 = new System.Windows.Forms.Label();
			this.textBox33 = new mdlComponentesGraficos.TextBox();
			this.textBox32 = new mdlComponentesGraficos.TextBox();
			this.textBox31 = new mdlComponentesGraficos.TextBox();
			this.textBox30 = new mdlComponentesGraficos.TextBox();
			this.textBox28 = new mdlComponentesGraficos.TextBox();
			this.label37 = new System.Windows.Forms.Label();
			this.textBox29 = new mdlComponentesGraficos.TextBox();
			this.label38 = new System.Windows.Forms.Label();
			this.label28 = new System.Windows.Forms.Label();
			this.label27 = new System.Windows.Forms.Label();
			this.label26 = new System.Windows.Forms.Label();
			this.label25 = new System.Windows.Forms.Label();
			this.label24 = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.m_tpAnexos = new System.Windows.Forms.TabPage();
			this.m_btCancelar = new mdlComponentesGraficos.Button();
			this.m_btOk = new mdlComponentesGraficos.Button();
			this.m_gbMain.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.m_tpTela01.SuspendLayout();
			this.m_gbTela001.SuspendLayout();
			this.m_tpTela02.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbMain
			// 
			this.m_gbMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbMain.Controls.Add(this.tabControl1);
			this.m_gbMain.Controls.Add(this.m_btCancelar);
			this.m_gbMain.Controls.Add(this.m_btOk);
			this.m_gbMain.Location = new System.Drawing.Point(5, -3);
			this.m_gbMain.Name = "m_gbMain";
			this.m_gbMain.Size = new System.Drawing.Size(536, 456);
			this.m_gbMain.TabIndex = 0;
			this.m_gbMain.TabStop = false;
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.m_tpTela01);
			this.tabControl1.Controls.Add(this.m_tpTela02);
			this.tabControl1.Controls.Add(this.m_tpAnexos);
			this.tabControl1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tabControl1.Location = new System.Drawing.Point(9, 12);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(519, 412);
			this.tabControl1.TabIndex = 17;
			// 
			// m_tpTela01
			// 
			this.m_tpTela01.Controls.Add(this.m_gbTela001);
			this.m_tpTela01.Location = new System.Drawing.Point(4, 23);
			this.m_tpTela01.Name = "m_tpTela01";
			this.m_tpTela01.Size = new System.Drawing.Size(511, 385);
			this.m_tpTela01.TabIndex = 0;
			this.m_tpTela01.Text = "Tela01";
			// 
			// m_gbTela001
			// 
			this.m_gbTela001.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbTela001.Controls.Add(this.m_txtEONumProcesso);
			this.m_gbTela001.Controls.Add(this.m_txtEOMargemNaoSacada);
			this.m_gbTela001.Controls.Add(this.m_txtEODataLimiteOperacao);
			this.m_gbTela001.Controls.Add(this.m_txtEONumAtoConc);
			this.m_gbTela001.Controls.Add(this.m_txtImportadorPais);
			this.m_gbTela001.Controls.Add(this.m_txtImportadorEndereco);
			this.m_gbTela001.Controls.Add(this.m_txtImportadorNome);
			this.m_gbTela001.Controls.Add(this.m_txtUnidadeRFEmbarque);
			this.m_gbTela001.Controls.Add(this.m_txtUnidadeRFDespacho);
			this.m_gbTela001.Controls.Add(this.m_txtEOSGPVinculado);
			this.m_gbTela001.Controls.Add(this.m_txtEODIRIVinculado);
			this.m_gbTela001.Controls.Add(this.m_txtEOGEDERE);
			this.m_gbTela001.Controls.Add(this.m_txtEONumRC);
			this.m_gbTela001.Controls.Add(this.m_txtEONumRV);
			this.m_gbTela001.Controls.Add(this.m_txtEOCodigo6);
			this.m_gbTela001.Controls.Add(this.m_txtEOCodigo5);
			this.m_gbTela001.Controls.Add(this.m_txtEOCodigo4);
			this.m_gbTela001.Controls.Add(this.m_txtEOCodigo3);
			this.m_gbTela001.Controls.Add(this.m_txtEOCodigo2);
			this.m_gbTela001.Controls.Add(this.m_txtEOCodigo1);
			this.m_gbTela001.Controls.Add(this.m_txtExportadorCPF);
			this.m_gbTela001.Controls.Add(this.m_txtExportadorNome);
			this.m_gbTela001.Controls.Add(this.m_txtDataHora);
			this.m_gbTela001.Controls.Add(this.label36);
			this.m_gbTela001.Controls.Add(this.m_txtOperador);
			this.m_gbTela001.Controls.Add(this.label35);
			this.m_gbTela001.Controls.Add(this.m_txtRespReg);
			this.m_gbTela001.Controls.Add(this.label34);
			this.m_gbTela001.Controls.Add(this.m_txtREDataRegistro);
			this.m_gbTela001.Controls.Add(this.label33);
			this.m_gbTela001.Controls.Add(this.label32);
			this.m_gbTela001.Controls.Add(this.label31);
			this.m_gbTela001.Controls.Add(this.label30);
			this.m_gbTela001.Controls.Add(this.label29);
			this.m_gbTela001.Controls.Add(this.label18);
			this.m_gbTela001.Controls.Add(this.label17);
			this.m_gbTela001.Controls.Add(this.label16);
			this.m_gbTela001.Controls.Add(this.label15);
			this.m_gbTela001.Controls.Add(this.label14);
			this.m_gbTela001.Controls.Add(this.label13);
			this.m_gbTela001.Controls.Add(this.label12);
			this.m_gbTela001.Controls.Add(this.label11);
			this.m_gbTela001.Controls.Add(this.label10);
			this.m_gbTela001.Controls.Add(this.label9);
			this.m_gbTela001.Controls.Add(this.label8);
			this.m_gbTela001.Controls.Add(this.label7);
			this.m_gbTela001.Controls.Add(this.label6);
			this.m_gbTela001.Controls.Add(this.label5);
			this.m_gbTela001.Controls.Add(this.label4);
			this.m_gbTela001.Controls.Add(this.label3);
			this.m_gbTela001.Controls.Add(this.m_txtRESituacao);
			this.m_gbTela001.Controls.Add(this.label2);
			this.m_gbTela001.Controls.Add(this.m_txtRENumero);
			this.m_gbTela001.Controls.Add(this.label1);
			this.m_gbTela001.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbTela001.Location = new System.Drawing.Point(0, 0);
			this.m_gbTela001.Name = "m_gbTela001";
			this.m_gbTela001.Size = new System.Drawing.Size(503, 376);
			this.m_gbTela001.TabIndex = 17;
			this.m_gbTela001.TabStop = false;
			// 
			// m_txtEONumProcesso
			// 
			this.m_txtEONumProcesso.Location = new System.Drawing.Point(402, 207);
			this.m_txtEONumProcesso.Name = "m_txtEONumProcesso";
			this.m_txtEONumProcesso.Size = new System.Drawing.Size(96, 20);
			this.m_txtEONumProcesso.TabIndex = 53;
			this.m_txtEONumProcesso.Text = "";
			// 
			// m_txtEOMargemNaoSacada
			// 
			this.m_txtEOMargemNaoSacada.Location = new System.Drawing.Point(402, 188);
			this.m_txtEOMargemNaoSacada.Name = "m_txtEOMargemNaoSacada";
			this.m_txtEOMargemNaoSacada.Size = new System.Drawing.Size(96, 20);
			this.m_txtEOMargemNaoSacada.TabIndex = 52;
			this.m_txtEOMargemNaoSacada.Text = "";
			// 
			// m_txtEODataLimiteOperacao
			// 
			this.m_txtEODataLimiteOperacao.Location = new System.Drawing.Point(402, 169);
			this.m_txtEODataLimiteOperacao.Name = "m_txtEODataLimiteOperacao";
			this.m_txtEODataLimiteOperacao.Size = new System.Drawing.Size(96, 20);
			this.m_txtEODataLimiteOperacao.TabIndex = 51;
			this.m_txtEODataLimiteOperacao.Text = "";
			// 
			// m_txtEONumAtoConc
			// 
			this.m_txtEONumAtoConc.Location = new System.Drawing.Point(402, 150);
			this.m_txtEONumAtoConc.Name = "m_txtEONumAtoConc";
			this.m_txtEONumAtoConc.Size = new System.Drawing.Size(96, 20);
			this.m_txtEONumAtoConc.TabIndex = 50;
			this.m_txtEONumAtoConc.Text = "";
			// 
			// m_txtImportadorPais
			// 
			this.m_txtImportadorPais.Location = new System.Drawing.Point(166, 338);
			this.m_txtImportadorPais.Name = "m_txtImportadorPais";
			this.m_txtImportadorPais.Size = new System.Drawing.Size(96, 20);
			this.m_txtImportadorPais.TabIndex = 49;
			this.m_txtImportadorPais.Text = "";
			// 
			// m_txtImportadorEndereco
			// 
			this.m_txtImportadorEndereco.Location = new System.Drawing.Point(166, 318);
			this.m_txtImportadorEndereco.Name = "m_txtImportadorEndereco";
			this.m_txtImportadorEndereco.Size = new System.Drawing.Size(330, 20);
			this.m_txtImportadorEndereco.TabIndex = 48;
			this.m_txtImportadorEndereco.Text = "";
			// 
			// m_txtImportadorNome
			// 
			this.m_txtImportadorNome.Location = new System.Drawing.Point(166, 299);
			this.m_txtImportadorNome.Name = "m_txtImportadorNome";
			this.m_txtImportadorNome.Size = new System.Drawing.Size(330, 20);
			this.m_txtImportadorNome.TabIndex = 47;
			this.m_txtImportadorNome.Text = "";
			// 
			// m_txtUnidadeRFEmbarque
			// 
			this.m_txtUnidadeRFEmbarque.Location = new System.Drawing.Point(167, 267);
			this.m_txtUnidadeRFEmbarque.Name = "m_txtUnidadeRFEmbarque";
			this.m_txtUnidadeRFEmbarque.Size = new System.Drawing.Size(96, 20);
			this.m_txtUnidadeRFEmbarque.TabIndex = 46;
			this.m_txtUnidadeRFEmbarque.Text = "";
			// 
			// m_txtUnidadeRFDespacho
			// 
			this.m_txtUnidadeRFDespacho.Location = new System.Drawing.Point(167, 248);
			this.m_txtUnidadeRFDespacho.Name = "m_txtUnidadeRFDespacho";
			this.m_txtUnidadeRFDespacho.Size = new System.Drawing.Size(96, 20);
			this.m_txtUnidadeRFDespacho.TabIndex = 45;
			this.m_txtUnidadeRFDespacho.Text = "";
			// 
			// m_txtEOSGPVinculado
			// 
			this.m_txtEOSGPVinculado.Location = new System.Drawing.Point(112, 226);
			this.m_txtEOSGPVinculado.Name = "m_txtEOSGPVinculado";
			this.m_txtEOSGPVinculado.Size = new System.Drawing.Size(96, 20);
			this.m_txtEOSGPVinculado.TabIndex = 44;
			this.m_txtEOSGPVinculado.Text = "";
			// 
			// m_txtEODIRIVinculado
			// 
			this.m_txtEODIRIVinculado.Location = new System.Drawing.Point(112, 207);
			this.m_txtEODIRIVinculado.Name = "m_txtEODIRIVinculado";
			this.m_txtEODIRIVinculado.Size = new System.Drawing.Size(96, 20);
			this.m_txtEODIRIVinculado.TabIndex = 43;
			this.m_txtEODIRIVinculado.Text = "";
			// 
			// m_txtEOGEDERE
			// 
			this.m_txtEOGEDERE.Location = new System.Drawing.Point(112, 188);
			this.m_txtEOGEDERE.Name = "m_txtEOGEDERE";
			this.m_txtEOGEDERE.Size = new System.Drawing.Size(96, 20);
			this.m_txtEOGEDERE.TabIndex = 42;
			this.m_txtEOGEDERE.Text = "";
			// 
			// m_txtEONumRC
			// 
			this.m_txtEONumRC.Location = new System.Drawing.Point(112, 169);
			this.m_txtEONumRC.Name = "m_txtEONumRC";
			this.m_txtEONumRC.Size = new System.Drawing.Size(96, 20);
			this.m_txtEONumRC.TabIndex = 41;
			this.m_txtEONumRC.Text = "";
			// 
			// m_txtEONumRV
			// 
			this.m_txtEONumRV.Location = new System.Drawing.Point(112, 150);
			this.m_txtEONumRV.Name = "m_txtEONumRV";
			this.m_txtEONumRV.Size = new System.Drawing.Size(96, 20);
			this.m_txtEONumRV.TabIndex = 40;
			this.m_txtEONumRV.Text = "";
			// 
			// m_txtEOCodigo6
			// 
			this.m_txtEOCodigo6.Location = new System.Drawing.Point(434, 130);
			this.m_txtEOCodigo6.Name = "m_txtEOCodigo6";
			this.m_txtEOCodigo6.Size = new System.Drawing.Size(64, 20);
			this.m_txtEOCodigo6.TabIndex = 39;
			this.m_txtEOCodigo6.Text = "";
			// 
			// m_txtEOCodigo5
			// 
			this.m_txtEOCodigo5.Location = new System.Drawing.Point(370, 130);
			this.m_txtEOCodigo5.Name = "m_txtEOCodigo5";
			this.m_txtEOCodigo5.Size = new System.Drawing.Size(64, 20);
			this.m_txtEOCodigo5.TabIndex = 38;
			this.m_txtEOCodigo5.Text = "";
			// 
			// m_txtEOCodigo4
			// 
			this.m_txtEOCodigo4.Location = new System.Drawing.Point(306, 130);
			this.m_txtEOCodigo4.Name = "m_txtEOCodigo4";
			this.m_txtEOCodigo4.Size = new System.Drawing.Size(64, 20);
			this.m_txtEOCodigo4.TabIndex = 37;
			this.m_txtEOCodigo4.Text = "";
			// 
			// m_txtEOCodigo3
			// 
			this.m_txtEOCodigo3.Location = new System.Drawing.Point(241, 130);
			this.m_txtEOCodigo3.Name = "m_txtEOCodigo3";
			this.m_txtEOCodigo3.Size = new System.Drawing.Size(64, 20);
			this.m_txtEOCodigo3.TabIndex = 36;
			this.m_txtEOCodigo3.Text = "";
			// 
			// m_txtEOCodigo2
			// 
			this.m_txtEOCodigo2.Location = new System.Drawing.Point(176, 130);
			this.m_txtEOCodigo2.Name = "m_txtEOCodigo2";
			this.m_txtEOCodigo2.Size = new System.Drawing.Size(64, 20);
			this.m_txtEOCodigo2.TabIndex = 35;
			this.m_txtEOCodigo2.Text = "";
			// 
			// m_txtEOCodigo1
			// 
			this.m_txtEOCodigo1.Location = new System.Drawing.Point(112, 130);
			this.m_txtEOCodigo1.Name = "m_txtEOCodigo1";
			this.m_txtEOCodigo1.Size = new System.Drawing.Size(64, 20);
			this.m_txtEOCodigo1.TabIndex = 34;
			this.m_txtEOCodigo1.Text = "";
			// 
			// m_txtExportadorCPF
			// 
			this.m_txtExportadorCPF.Location = new System.Drawing.Point(112, 71);
			this.m_txtExportadorCPF.Name = "m_txtExportadorCPF";
			this.m_txtExportadorCPF.ReadOnly = true;
			this.m_txtExportadorCPF.Size = new System.Drawing.Size(96, 20);
			this.m_txtExportadorCPF.TabIndex = 33;
			this.m_txtExportadorCPF.Text = "";
			// 
			// m_txtExportadorNome
			// 
			this.m_txtExportadorNome.Location = new System.Drawing.Point(112, 93);
			this.m_txtExportadorNome.Name = "m_txtExportadorNome";
			this.m_txtExportadorNome.ReadOnly = true;
			this.m_txtExportadorNome.Size = new System.Drawing.Size(384, 20);
			this.m_txtExportadorNome.TabIndex = 32;
			this.m_txtExportadorNome.Text = "";
			// 
			// m_txtDataHora
			// 
			this.m_txtDataHora.Location = new System.Drawing.Point(401, 72);
			this.m_txtDataHora.Name = "m_txtDataHora";
			this.m_txtDataHora.ReadOnly = true;
			this.m_txtDataHora.Size = new System.Drawing.Size(96, 20);
			this.m_txtDataHora.TabIndex = 31;
			this.m_txtDataHora.Text = "";
			// 
			// label36
			// 
			this.label36.Location = new System.Drawing.Point(296, 78);
			this.label36.Name = "label36";
			this.label36.Size = new System.Drawing.Size(104, 16);
			this.label36.TabIndex = 30;
			this.label36.Text = "DATA/HORA:";
			// 
			// m_txtOperador
			// 
			this.m_txtOperador.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_txtOperador.Location = new System.Drawing.Point(401, 52);
			this.m_txtOperador.Name = "m_txtOperador";
			this.m_txtOperador.ReadOnly = true;
			this.m_txtOperador.Size = new System.Drawing.Size(96, 20);
			this.m_txtOperador.TabIndex = 29;
			this.m_txtOperador.Text = "";
			// 
			// label35
			// 
			this.label35.Location = new System.Drawing.Point(295, 57);
			this.label35.Name = "label35";
			this.label35.Size = new System.Drawing.Size(104, 16);
			this.label35.TabIndex = 28;
			this.label35.Text = "OPERADOR.:";
			// 
			// m_txtRespReg
			// 
			this.m_txtRespReg.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_txtRespReg.Location = new System.Drawing.Point(401, 32);
			this.m_txtRespReg.Name = "m_txtRespReg";
			this.m_txtRespReg.ReadOnly = true;
			this.m_txtRespReg.Size = new System.Drawing.Size(96, 20);
			this.m_txtRespReg.TabIndex = 27;
			this.m_txtRespReg.Text = "";
			// 
			// label34
			// 
			this.label34.Location = new System.Drawing.Point(297, 37);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(104, 16);
			this.label34.TabIndex = 26;
			this.label34.Text = "RESP REG.:";
			// 
			// m_txtREDataRegistro
			// 
			this.m_txtREDataRegistro.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_txtREDataRegistro.Location = new System.Drawing.Point(401, 12);
			this.m_txtREDataRegistro.Name = "m_txtREDataRegistro";
			this.m_txtREDataRegistro.ReadOnly = true;
			this.m_txtREDataRegistro.Size = new System.Drawing.Size(96, 20);
			this.m_txtREDataRegistro.TabIndex = 25;
			this.m_txtREDataRegistro.Text = "";
			// 
			// label33
			// 
			this.label33.Location = new System.Drawing.Point(297, 16);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(104, 16);
			this.label33.TabIndex = 24;
			this.label33.Text = "DATA REG.:";
			// 
			// label32
			// 
			this.label32.Location = new System.Drawing.Point(232, 208);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(165, 16);
			this.label32.TabIndex = 23;
			this.label32.Text = "i-NUM DO PROCESSO";
			// 
			// label31
			// 
			this.label31.Location = new System.Drawing.Point(232, 190);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(168, 16);
			this.label31.TabIndex = 22;
			this.label31.Text = "h-MARGEM NAO SACADA (%)";
			// 
			// label30
			// 
			this.label30.Location = new System.Drawing.Point(232, 172);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(165, 16);
			this.label30.TabIndex = 21;
			this.label30.Text = "g-DATA LIMITE OPERACAO";
			// 
			// label29
			// 
			this.label29.Location = new System.Drawing.Point(232, 152);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(165, 16);
			this.label29.TabIndex = 20;
			this.label29.Text = "f-NUM ATO CONCESSORIO";
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(32, 339);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(80, 16);
			this.label18.TabIndex = 19;
			this.label18.Text = "c-PAIS";
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(32, 322);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(80, 16);
			this.label17.TabIndex = 18;
			this.label17.Text = "b-ENDERECO";
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(32, 304);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(72, 16);
			this.label16.TabIndex = 17;
			this.label16.Text = "a-NOME";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(13, 289);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(123, 16);
			this.label15.TabIndex = 16;
			this.label15.Text = "05-IMPORTADOR:";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(12, 270);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(165, 16);
			this.label14.TabIndex = 15;
			this.label14.Text = "04-UNIDADE RF EMBARQUE:";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(11, 250);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(165, 16);
			this.label13.TabIndex = 14;
			this.label13.Text = "03-UNIDADE RF DESPACHO:";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(16, 229);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(112, 16);
			this.label12.TabIndex = 13;
			this.label12.Text = "j-SGP Vinculado";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(16, 208);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(112, 16);
			this.label11.TabIndex = 12;
			this.label11.Text = "e-DI/RI Vinculado";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(16, 190);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(128, 16);
			this.label10.TabIndex = 11;
			this.label10.Text = "d-GE/DE/RE Vin.";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(16, 172);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(88, 16);
			this.label9.TabIndex = 10;
			this.label9.Text = "c-Num do RC";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(16, 152);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(88, 16);
			this.label8.TabIndex = 9;
			this.label8.Text = "b-Num do RV";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(16, 131);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(88, 16);
			this.label7.TabIndex = 8;
			this.label7.Text = "a-Codigo";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 114);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(224, 16);
			this.label6.TabIndex = 7;
			this.label6.Text = "02-ENQUADRAMENTO DA OPERACAO:";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 96);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(80, 16);
			this.label5.TabIndex = 6;
			this.label5.Text = "b-NOME:";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 76);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(80, 16);
			this.label4.TabIndex = 5;
			this.label4.Text = "a-CFC/CPF:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 57);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(104, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "01-EXPORTADOR:";
			// 
			// m_txtRESituacao
			// 
			this.m_txtRESituacao.Location = new System.Drawing.Point(112, 36);
			this.m_txtRESituacao.Name = "m_txtRESituacao";
			this.m_txtRESituacao.ReadOnly = true;
			this.m_txtRESituacao.Size = new System.Drawing.Size(96, 20);
			this.m_txtRESituacao.TabIndex = 3;
			this.m_txtRESituacao.Text = "";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(8, 37);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(104, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Situação do RE:";
			// 
			// m_txtRENumero
			// 
			this.m_txtRENumero.Location = new System.Drawing.Point(112, 16);
			this.m_txtRENumero.Name = "m_txtRENumero";
			this.m_txtRENumero.ReadOnly = true;
			this.m_txtRENumero.Size = new System.Drawing.Size(96, 20);
			this.m_txtRENumero.TabIndex = 1;
			this.m_txtRENumero.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(104, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Numero-Registro:";
			// 
			// m_tpTela02
			// 
			this.m_tpTela02.Controls.Add(this.groupBox1);
			this.m_tpTela02.Location = new System.Drawing.Point(4, 23);
			this.m_tpTela02.Name = "m_tpTela02";
			this.m_tpTela02.Size = new System.Drawing.Size(511, 385);
			this.m_tpTela02.TabIndex = 1;
			this.m_tpTela02.Text = "Tela02";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.textBox44);
			this.groupBox1.Controls.Add(this.textBox43);
			this.groupBox1.Controls.Add(this.textBox42);
			this.groupBox1.Controls.Add(this.textBox41);
			this.groupBox1.Controls.Add(this.textBox40);
			this.groupBox1.Controls.Add(this.textBox39);
			this.groupBox1.Controls.Add(this.textBox38);
			this.groupBox1.Controls.Add(this.textBox37);
			this.groupBox1.Controls.Add(this.textBox36);
			this.groupBox1.Controls.Add(this.textBox35);
			this.groupBox1.Controls.Add(this.textBox34);
			this.groupBox1.Controls.Add(this.label44);
			this.groupBox1.Controls.Add(this.label43);
			this.groupBox1.Controls.Add(this.label42);
			this.groupBox1.Controls.Add(this.label41);
			this.groupBox1.Controls.Add(this.label40);
			this.groupBox1.Controls.Add(this.label39);
			this.groupBox1.Controls.Add(this.textBox33);
			this.groupBox1.Controls.Add(this.textBox32);
			this.groupBox1.Controls.Add(this.textBox31);
			this.groupBox1.Controls.Add(this.textBox30);
			this.groupBox1.Controls.Add(this.textBox28);
			this.groupBox1.Controls.Add(this.label37);
			this.groupBox1.Controls.Add(this.textBox29);
			this.groupBox1.Controls.Add(this.label38);
			this.groupBox1.Controls.Add(this.label28);
			this.groupBox1.Controls.Add(this.label27);
			this.groupBox1.Controls.Add(this.label26);
			this.groupBox1.Controls.Add(this.label25);
			this.groupBox1.Controls.Add(this.label24);
			this.groupBox1.Controls.Add(this.label23);
			this.groupBox1.Controls.Add(this.label22);
			this.groupBox1.Controls.Add(this.label21);
			this.groupBox1.Controls.Add(this.label20);
			this.groupBox1.Controls.Add(this.label19);
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(632, 440);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// textBox44
			// 
			this.textBox44.Location = new System.Drawing.Point(421, 236);
			this.textBox44.Name = "textBox44";
			this.textBox44.Size = new System.Drawing.Size(24, 20);
			this.textBox44.TabIndex = 64;
			this.textBox44.Text = "M";
			// 
			// textBox43
			// 
			this.textBox43.Location = new System.Drawing.Point(229, 336);
			this.textBox43.Name = "textBox43";
			this.textBox43.Size = new System.Drawing.Size(107, 20);
			this.textBox43.TabIndex = 63;
			this.textBox43.Text = "";
			// 
			// textBox42
			// 
			this.textBox42.Location = new System.Drawing.Point(229, 316);
			this.textBox42.Name = "textBox42";
			this.textBox42.Size = new System.Drawing.Size(107, 20);
			this.textBox42.TabIndex = 62;
			this.textBox42.Text = "";
			// 
			// textBox41
			// 
			this.textBox41.Location = new System.Drawing.Point(229, 296);
			this.textBox41.Name = "textBox41";
			this.textBox41.Size = new System.Drawing.Size(107, 20);
			this.textBox41.TabIndex = 61;
			this.textBox41.Text = "";
			// 
			// textBox40
			// 
			this.textBox40.Location = new System.Drawing.Point(229, 276);
			this.textBox40.Name = "textBox40";
			this.textBox40.ReadOnly = true;
			this.textBox40.Size = new System.Drawing.Size(107, 20);
			this.textBox40.TabIndex = 60;
			this.textBox40.Text = "";
			// 
			// textBox39
			// 
			this.textBox39.Location = new System.Drawing.Point(229, 256);
			this.textBox39.Name = "textBox39";
			this.textBox39.Size = new System.Drawing.Size(107, 20);
			this.textBox39.TabIndex = 59;
			this.textBox39.Text = "";
			// 
			// textBox38
			// 
			this.textBox38.Location = new System.Drawing.Point(229, 236);
			this.textBox38.Name = "textBox38";
			this.textBox38.Size = new System.Drawing.Size(107, 20);
			this.textBox38.TabIndex = 58;
			this.textBox38.Text = "";
			// 
			// textBox37
			// 
			this.textBox37.Location = new System.Drawing.Point(229, 216);
			this.textBox37.Name = "textBox37";
			this.textBox37.Size = new System.Drawing.Size(107, 20);
			this.textBox37.TabIndex = 57;
			this.textBox37.Text = "";
			// 
			// textBox36
			// 
			this.textBox36.Location = new System.Drawing.Point(229, 196);
			this.textBox36.Name = "textBox36";
			this.textBox36.Size = new System.Drawing.Size(107, 20);
			this.textBox36.TabIndex = 56;
			this.textBox36.Text = "";
			// 
			// textBox35
			// 
			this.textBox35.Location = new System.Drawing.Point(229, 176);
			this.textBox35.Name = "textBox35";
			this.textBox35.Size = new System.Drawing.Size(107, 20);
			this.textBox35.TabIndex = 55;
			this.textBox35.Text = "";
			// 
			// textBox34
			// 
			this.textBox34.Location = new System.Drawing.Point(229, 156);
			this.textBox34.Name = "textBox34";
			this.textBox34.Size = new System.Drawing.Size(43, 20);
			this.textBox34.TabIndex = 54;
			this.textBox34.Text = "";
			// 
			// label44
			// 
			this.label44.Location = new System.Drawing.Point(344, 239);
			this.label44.Name = "label44";
			this.label44.Size = new System.Drawing.Size(80, 16);
			this.label44.TabIndex = 53;
			this.label44.Text = "g-INDICADOR";
			// 
			// label43
			// 
			this.label43.Location = new System.Drawing.Point(24, 340);
			this.label43.Name = "label43";
			this.label43.Size = new System.Drawing.Size(190, 16);
			this.label43.TabIndex = 52;
			this.label43.Text = "m-VALOR FINACIAMENTO RC";
			// 
			// label42
			// 
			this.label42.Location = new System.Drawing.Point(24, 319);
			this.label42.Name = "label42";
			this.label42.Size = new System.Drawing.Size(190, 16);
			this.label42.TabIndex = 51;
			this.label42.Text = "l-VALOR S/ COBERTURA CAMBIO";
			// 
			// label41
			// 
			this.label41.Location = new System.Drawing.Point(26, 300);
			this.label41.Name = "label41";
			this.label41.Size = new System.Drawing.Size(165, 16);
			this.label41.TabIndex = 50;
			this.label41.Text = "j-VALOR EM CONSIGNACAO";
			// 
			// label40
			// 
			this.label40.Location = new System.Drawing.Point(26, 279);
			this.label40.Name = "label40";
			this.label40.Size = new System.Drawing.Size(200, 16);
			this.label40.TabIndex = 49;
			this.label40.Text = "i-VALOR MARGEM NAO SACADA";
			// 
			// label39
			// 
			this.label39.Location = new System.Drawing.Point(24, 258);
			this.label39.Name = "label39";
			this.label39.Size = new System.Drawing.Size(165, 16);
			this.label39.TabIndex = 48;
			this.label39.Text = "h-VALOR DA PARCELA";
			// 
			// textBox33
			// 
			this.textBox33.Location = new System.Drawing.Point(229, 136);
			this.textBox33.Name = "textBox33";
			this.textBox33.Size = new System.Drawing.Size(43, 20);
			this.textBox33.TabIndex = 47;
			this.textBox33.Text = "";
			// 
			// textBox32
			// 
			this.textBox32.Location = new System.Drawing.Point(230, 95);
			this.textBox32.Name = "textBox32";
			this.textBox32.Size = new System.Drawing.Size(42, 20);
			this.textBox32.TabIndex = 46;
			this.textBox32.Text = "";
			// 
			// textBox31
			// 
			this.textBox31.Location = new System.Drawing.Point(230, 74);
			this.textBox31.Name = "textBox31";
			this.textBox31.Size = new System.Drawing.Size(42, 20);
			this.textBox31.TabIndex = 45;
			this.textBox31.Text = "";
			// 
			// textBox30
			// 
			this.textBox30.Location = new System.Drawing.Point(230, 54);
			this.textBox30.Name = "textBox30";
			this.textBox30.Size = new System.Drawing.Size(42, 20);
			this.textBox30.TabIndex = 44;
			this.textBox30.Text = "";
			// 
			// textBox28
			// 
			this.textBox28.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.textBox28.Location = new System.Drawing.Point(401, 12);
			this.textBox28.Name = "textBox28";
			this.textBox28.ReadOnly = true;
			this.textBox28.Size = new System.Drawing.Size(96, 20);
			this.textBox28.TabIndex = 43;
			this.textBox28.Text = "";
			// 
			// label37
			// 
			this.label37.Location = new System.Drawing.Point(297, 16);
			this.label37.Name = "label37";
			this.label37.Size = new System.Drawing.Size(104, 16);
			this.label37.TabIndex = 42;
			this.label37.Text = "DATA REG.:";
			// 
			// textBox29
			// 
			this.textBox29.Location = new System.Drawing.Point(112, 16);
			this.textBox29.Name = "textBox29";
			this.textBox29.ReadOnly = true;
			this.textBox29.Size = new System.Drawing.Size(96, 20);
			this.textBox29.TabIndex = 41;
			this.textBox29.Text = "";
			// 
			// label38
			// 
			this.label38.Location = new System.Drawing.Point(8, 18);
			this.label38.Name = "label38";
			this.label38.Size = new System.Drawing.Size(104, 16);
			this.label38.TabIndex = 40;
			this.label38.Text = "Numero-Registro:";
			// 
			// label28
			// 
			this.label28.Location = new System.Drawing.Point(24, 239);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(165, 16);
			this.label28.TabIndex = 39;
			this.label28.Text = "f-PERIODICIDADE";
			// 
			// label27
			// 
			this.label27.Location = new System.Drawing.Point(24, 219);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(165, 16);
			this.label27.TabIndex = 38;
			this.label27.Text = "e-NUMERO DE PARCELAS";
			// 
			// label26
			// 
			this.label26.Location = new System.Drawing.Point(24, 198);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(165, 16);
			this.label26.TabIndex = 37;
			this.label26.Text = "d-VALOR PAGTO A VISTA";
			// 
			// label25
			// 
			this.label25.Location = new System.Drawing.Point(24, 178);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(192, 16);
			this.label25.TabIndex = 36;
			this.label25.Text = "c-VALOR PAGTO ANTECIPADO";
			// 
			// label24
			// 
			this.label24.Location = new System.Drawing.Point(24, 158);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(165, 16);
			this.label24.TabIndex = 35;
			this.label24.Text = "b-MOEDA";
			// 
			// label23
			// 
			this.label23.Location = new System.Drawing.Point(24, 136);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(168, 16);
			this.label23.TabIndex = 34;
			this.label23.Text = "a-MODALIDADE TRANSACAO";
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(8, 120);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(217, 16);
			this.label22.TabIndex = 33;
			this.label22.Text = "09-ESQUEMA DE PAGAMENTO TOTAL";
			// 
			// label21
			// 
			this.label21.Location = new System.Drawing.Point(8, 97);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(216, 16);
			this.label21.TabIndex = 32;
			this.label21.Text = "08-CODIGO CONDICAO DE VENDA";
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(8, 78);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(216, 16);
			this.label20.TabIndex = 31;
			this.label20.Text = "07-INSTRUMENTO DE NEGOCIACAO";
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(8, 57);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(165, 16);
			this.label19.TabIndex = 30;
			this.label19.Text = "06-PAIS DE DESTINO FINAL";
			// 
			// m_tpAnexos
			// 
			this.m_tpAnexos.Location = new System.Drawing.Point(4, 23);
			this.m_tpAnexos.Name = "m_tpAnexos";
			this.m_tpAnexos.Size = new System.Drawing.Size(511, 385);
			this.m_tpAnexos.TabIndex = 2;
			this.m_tpAnexos.Text = "Anexos";
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.GradiendColorEnd = System.Drawing.Color.Black;
			this.m_btCancelar.GradiendColorStart = System.Drawing.Color.White;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(272, 427);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 15;
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_btOk
			// 
			this.m_btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.GradiendColorEnd = System.Drawing.Color.Black;
			this.m_btOk.GradiendColorStart = System.Drawing.Color.White;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(208, 427);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 14;
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// frmFREEspelhoView
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(546, 455);
			this.Controls.Add(this.m_gbMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFREEspelhoView";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "SiscoRE - RE";
			this.m_gbMain.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.m_tpTela01.ResumeLayout(false);
			this.m_gbTela001.ResumeLayout(false);
			this.m_tpTela02.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Cores
			private void vMostraCor()
			{
				this.BackColor = mdlConstantes.clsConfig.FirstColor;
				System.Windows.Forms.Control ctrControleChild;
				for (int nCont = 0 ;nCont < this.Controls.Count; nCont++)
				{
					ctrControleChild = this.Controls[nCont];
					vPaintControl(ref ctrControleChild,this.BackColor);
				}
			}

			private void vPaintControl(ref System.Windows.Forms.Control ctrControle,System.Drawing.Color clrBackColor)
			{
				switch(ctrControle.GetType().ToString())
				{
					case "mdlComponentesGraficos.ListView":
					case "System.Windows.Forms.ListView":
					case "System.Windows.Forms.TextBox":
					case "mdlComponentesGraficos.ComboBox":
					case "mdlComponentesGraficos.TextBox":
					case "mdlComponentesGraficos.TreeView":
						break;

					default:
						ctrControle.BackColor = clrBackColor;
						break;
				}
				System.Windows.Forms.Control ctrControleChild;
				for (int nCont = 0 ;nCont < ctrControle.Controls.Count; nCont++)
				{
					ctrControleChild = ctrControle.Controls[nCont];
					vPaintControl(ref ctrControleChild,clrBackColor);
				}
			}
		#endregion

		#region Events
			#region Buttons
				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					m_bConfirmed = true;
					this.Close();
				}

				private void m_btCancelar_Click(object sender, System.EventArgs e)
				{
					m_bConfirmed = false;
					this.Close();
				}
			#endregion
		#endregion
	}
}
