using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlRelatoriosJanelas
{
	/// <summary>
	/// Summary description for frmFRelatoriosPropriedadesRelatorio.
	/// </summary>
	public class frmFRelatoriosPropriedadesRelatorio : mdlComponentesGraficos.FormFlutuante
	{
		#region Constantes
			private const int DISPOSICAO_RETRATO = 0;
			private const int DISPOSICAO_PAISAGEM = 1;

			private const double CONVERSOR_PIXELS_POR_CM = 39;
			private const double TAMANHO_A4_ALTURA_EM_CM = 29.7;
			private const double TAMANHO_A4_LARGURA_EM_CM = 21;
			private const double TAMANHO_CARTA_ALTURA_EM_CM = 27.94;
			private const double TAMANHO_CARTA_LARGURA_EM_CM = 21.59;
		#endregion
		#region Atributos
			private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro; 
			private string m_strEnderecoExecutavel; 
			// Cores
			private System.Drawing.Color m_clrCorFundo; 
			private System.Drawing.Color m_clrCorMargem; 
			// Margens
			private int m_nAcima; 
			private int m_nDireita;
			private int m_nAbaixo; 
			private int m_nEsquerda;
			// Tamanho 
			private int m_nLargura;
			private int  m_nAltura; 
			private double m_dLargura;
			private double m_dAltura; 
			// Disposição
			private int m_nDisposicao; 
			private bool m_bAtivado = true;

			public bool m_bModificado;

			internal System.Windows.Forms.GroupBox m_gbGeral;
			internal System.Windows.Forms.GroupBox m_gbVisualizar;
			internal System.Windows.Forms.Panel m_pnFormato;
			internal System.Windows.Forms.PictureBox m_picRelatorio;
			internal System.Windows.Forms.TabControl m_tcOpcoes;
			internal System.Windows.Forms.TabPage m_tpMargens;
			internal System.Windows.Forms.GroupBox m_gbMargens;
			internal System.Windows.Forms.Panel m_pnRelatorio;
			internal System.Windows.Forms.Panel m_pnFolha;
			internal System.Windows.Forms.TabPage m_tbTamanho;
			internal System.Windows.Forms.GroupBox m_gbTamanho;
			internal System.Windows.Forms.Label m_lbCm2;
			internal System.Windows.Forms.Label m_lbCm;
			internal System.Windows.Forms.Label m_lbAltura;
			internal System.Windows.Forms.Label m_lbLargura;
			internal System.Windows.Forms.RadioButton m_rbPersonalizado;
			internal System.Windows.Forms.RadioButton m_rbA4;
			internal System.Windows.Forms.RadioButton m_rbCarta;
			internal System.Windows.Forms.TabPage m_tbDisposicao;
			internal System.Windows.Forms.GroupBox m_gbDisposicao;
			internal System.Windows.Forms.CheckBox m_ckPaisagem;
			internal System.Windows.Forms.CheckBox m_ckRetrato;
			internal System.Windows.Forms.Panel m_pnRetrato;
			internal System.Windows.Forms.Panel m_pnPaisagem;
			internal System.Windows.Forms.Button m_btOk;
			internal System.Windows.Forms.Button m_btCancelar;
			private mdlComponentesGraficos.TextBox m_txtAcima;
			private mdlComponentesGraficos.TextBox m_txtDireita;
			private mdlComponentesGraficos.TextBox m_txtAbaixo;
			private mdlComponentesGraficos.TextBox m_txtEsquerda;
			private mdlComponentesGraficos.TextBox m_txtLargura;
			private mdlComponentesGraficos.TextBox m_txtAltura;
			private System.ComponentModel.Container components = null;
		#endregion
		#region Constructor and Destructors
		public frmFRelatoriosPropriedadesRelatorio(ref mdlTratamentoErro.clsTratamentoErro cls_ter_tratadorErro,string strEnderecoExecutavel,System.Drawing.Color clrFundo,System.Drawing.Color clrMargem,int nAcima, int nDireita, int nAbaixo, int nEsquerda, int nLargura, int nAltura, int nDisposicao)
		{
			m_cls_ter_tratadorErro = cls_ter_tratadorErro;
			m_strEnderecoExecutavel = strEnderecoExecutavel;

			m_nAcima = nAcima;
			m_nDireita = nDireita;
			m_nAbaixo = nAbaixo;
			m_nEsquerda = nEsquerda;

			// Cores
			m_clrCorFundo = clrFundo;
			m_clrCorMargem = clrMargem;

			// Tamanho 
			m_nLargura = nLargura;
			m_nAltura = nAltura;

			// Disposição
			m_nDisposicao = nDisposicao;

			InitializeComponent();

		}

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFRelatoriosPropriedadesRelatorio));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_gbVisualizar = new System.Windows.Forms.GroupBox();
			this.m_pnFormato = new System.Windows.Forms.Panel();
			this.m_picRelatorio = new System.Windows.Forms.PictureBox();
			this.m_tcOpcoes = new System.Windows.Forms.TabControl();
			this.m_tpMargens = new System.Windows.Forms.TabPage();
			this.m_gbMargens = new System.Windows.Forms.GroupBox();
			this.m_txtEsquerda = new mdlComponentesGraficos.TextBox();
			this.m_txtAbaixo = new mdlComponentesGraficos.TextBox();
			this.m_txtDireita = new mdlComponentesGraficos.TextBox();
			this.m_txtAcima = new mdlComponentesGraficos.TextBox();
			this.m_pnRelatorio = new System.Windows.Forms.Panel();
			this.m_pnFolha = new System.Windows.Forms.Panel();
			this.m_tbTamanho = new System.Windows.Forms.TabPage();
			this.m_gbTamanho = new System.Windows.Forms.GroupBox();
			this.m_txtAltura = new mdlComponentesGraficos.TextBox();
			this.m_txtLargura = new mdlComponentesGraficos.TextBox();
			this.m_lbCm2 = new System.Windows.Forms.Label();
			this.m_lbCm = new System.Windows.Forms.Label();
			this.m_lbAltura = new System.Windows.Forms.Label();
			this.m_lbLargura = new System.Windows.Forms.Label();
			this.m_rbPersonalizado = new System.Windows.Forms.RadioButton();
			this.m_rbA4 = new System.Windows.Forms.RadioButton();
			this.m_rbCarta = new System.Windows.Forms.RadioButton();
			this.m_tbDisposicao = new System.Windows.Forms.TabPage();
			this.m_gbDisposicao = new System.Windows.Forms.GroupBox();
			this.m_ckPaisagem = new System.Windows.Forms.CheckBox();
			this.m_ckRetrato = new System.Windows.Forms.CheckBox();
			this.m_pnRetrato = new System.Windows.Forms.Panel();
			this.m_pnPaisagem = new System.Windows.Forms.Panel();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbGeral.SuspendLayout();
			this.m_gbVisualizar.SuspendLayout();
			this.m_pnFormato.SuspendLayout();
			this.m_tcOpcoes.SuspendLayout();
			this.m_tpMargens.SuspendLayout();
			this.m_gbMargens.SuspendLayout();
			this.m_pnRelatorio.SuspendLayout();
			this.m_tbTamanho.SuspendLayout();
			this.m_gbTamanho.SuspendLayout();
			this.m_tbDisposicao.SuspendLayout();
			this.m_gbDisposicao.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Controls.Add(this.m_gbVisualizar);
			this.m_gbGeral.Controls.Add(this.m_tcOpcoes);
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Location = new System.Drawing.Point(4, -1);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(504, 344);
			this.m_gbGeral.TabIndex = 3;
			this.m_gbGeral.TabStop = false;
			// 
			// m_gbVisualizar
			// 
			this.m_gbVisualizar.Controls.Add(this.m_pnFormato);
			this.m_gbVisualizar.Location = new System.Drawing.Point(257, 9);
			this.m_gbVisualizar.Name = "m_gbVisualizar";
			this.m_gbVisualizar.Size = new System.Drawing.Size(240, 296);
			this.m_gbVisualizar.TabIndex = 22;
			this.m_gbVisualizar.TabStop = false;
			this.m_gbVisualizar.Text = "Relatorio";
			// 
			// m_pnFormato
			// 
			this.m_pnFormato.BackColor = System.Drawing.Color.Gainsboro;
			this.m_pnFormato.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_pnFormato.Controls.Add(this.m_picRelatorio);
			this.m_pnFormato.Location = new System.Drawing.Point(11, 16);
			this.m_pnFormato.Name = "m_pnFormato";
			this.m_pnFormato.Size = new System.Drawing.Size(217, 272);
			this.m_pnFormato.TabIndex = 20;
			// 
			// m_picRelatorio
			// 
			this.m_picRelatorio.BackColor = System.Drawing.Color.White;
			this.m_picRelatorio.Location = new System.Drawing.Point(15, 70);
			this.m_picRelatorio.Name = "m_picRelatorio";
			this.m_picRelatorio.Size = new System.Drawing.Size(180, 125);
			this.m_picRelatorio.TabIndex = 0;
			this.m_picRelatorio.TabStop = false;
			// 
			// m_tcOpcoes
			// 
			this.m_tcOpcoes.Controls.Add(this.m_tpMargens);
			this.m_tcOpcoes.Controls.Add(this.m_tbTamanho);
			this.m_tcOpcoes.Controls.Add(this.m_tbDisposicao);
			this.m_tcOpcoes.Location = new System.Drawing.Point(8, 17);
			this.m_tcOpcoes.Name = "m_tcOpcoes";
			this.m_tcOpcoes.SelectedIndex = 0;
			this.m_tcOpcoes.Size = new System.Drawing.Size(240, 288);
			this.m_tcOpcoes.TabIndex = 21;
			// 
			// m_tpMargens
			// 
			this.m_tpMargens.Controls.Add(this.m_gbMargens);
			this.m_tpMargens.Location = new System.Drawing.Point(4, 22);
			this.m_tpMargens.Name = "m_tpMargens";
			this.m_tpMargens.Size = new System.Drawing.Size(232, 262);
			this.m_tpMargens.TabIndex = 0;
			this.m_tpMargens.Text = "Margens";
			// 
			// m_gbMargens
			// 
			this.m_gbMargens.Controls.Add(this.m_txtEsquerda);
			this.m_gbMargens.Controls.Add(this.m_txtAbaixo);
			this.m_gbMargens.Controls.Add(this.m_txtDireita);
			this.m_gbMargens.Controls.Add(this.m_txtAcima);
			this.m_gbMargens.Controls.Add(this.m_pnRelatorio);
			this.m_gbMargens.Location = new System.Drawing.Point(7, 2);
			this.m_gbMargens.Name = "m_gbMargens";
			this.m_gbMargens.Size = new System.Drawing.Size(218, 254);
			this.m_gbMargens.TabIndex = 26;
			this.m_gbMargens.TabStop = false;
			// 
			// m_txtEsquerda
			// 
			this.m_txtEsquerda.Location = new System.Drawing.Point(12, 117);
			this.m_txtEsquerda.Mask = false;
			this.m_txtEsquerda.MaskText = "";
			this.m_txtEsquerda.Name = "m_txtEsquerda";
			this.m_txtEsquerda.OnlyNumbers = false;
			this.m_txtEsquerda.Size = new System.Drawing.Size(39, 20);
			this.m_txtEsquerda.TabIndex = 34;
			this.m_txtEsquerda.Text = "";
			this.m_txtEsquerda.TextChanged += new System.EventHandler(this.m_txtEsquerda_TextChanged);
			// 
			// m_txtAbaixo
			// 
			this.m_txtAbaixo.Location = new System.Drawing.Point(91, 194);
			this.m_txtAbaixo.Mask = false;
			this.m_txtAbaixo.MaskText = "";
			this.m_txtAbaixo.Name = "m_txtAbaixo";
			this.m_txtAbaixo.OnlyNumbers = false;
			this.m_txtAbaixo.Size = new System.Drawing.Size(39, 20);
			this.m_txtAbaixo.TabIndex = 33;
			this.m_txtAbaixo.Text = "";
			this.m_txtAbaixo.TextChanged += new System.EventHandler(this.m_txtAbaixo_TextChanged);
			// 
			// m_txtDireita
			// 
			this.m_txtDireita.Location = new System.Drawing.Point(169, 117);
			this.m_txtDireita.Mask = false;
			this.m_txtDireita.MaskText = "";
			this.m_txtDireita.Name = "m_txtDireita";
			this.m_txtDireita.OnlyNumbers = false;
			this.m_txtDireita.Size = new System.Drawing.Size(39, 20);
			this.m_txtDireita.TabIndex = 32;
			this.m_txtDireita.Text = "";
			this.m_txtDireita.TextChanged += new System.EventHandler(this.m_txtDireita_TextChanged);
			// 
			// m_txtAcima
			// 
			this.m_txtAcima.Location = new System.Drawing.Point(91, 42);
			this.m_txtAcima.Mask = false;
			this.m_txtAcima.MaskText = "";
			this.m_txtAcima.Name = "m_txtAcima";
			this.m_txtAcima.OnlyNumbers = false;
			this.m_txtAcima.Size = new System.Drawing.Size(39, 20);
			this.m_txtAcima.TabIndex = 31;
			this.m_txtAcima.Text = "";
			this.m_txtAcima.TextChanged += new System.EventHandler(this.m_txtAcima_TextChanged);
			// 
			// m_pnRelatorio
			// 
			this.m_pnRelatorio.BackColor = System.Drawing.Color.Gainsboro;
			this.m_pnRelatorio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_pnRelatorio.Controls.Add(this.m_pnFolha);
			this.m_pnRelatorio.Location = new System.Drawing.Point(60, 69);
			this.m_pnRelatorio.Name = "m_pnRelatorio";
			this.m_pnRelatorio.Size = new System.Drawing.Size(104, 120);
			this.m_pnRelatorio.TabIndex = 30;
			// 
			// m_pnFolha
			// 
			this.m_pnFolha.BackColor = System.Drawing.Color.White;
			this.m_pnFolha.ForeColor = System.Drawing.Color.Yellow;
			this.m_pnFolha.Location = new System.Drawing.Point(12, 12);
			this.m_pnFolha.Name = "m_pnFolha";
			this.m_pnFolha.Size = new System.Drawing.Size(77, 96);
			this.m_pnFolha.TabIndex = 21;
			// 
			// m_tbTamanho
			// 
			this.m_tbTamanho.Controls.Add(this.m_gbTamanho);
			this.m_tbTamanho.Location = new System.Drawing.Point(4, 22);
			this.m_tbTamanho.Name = "m_tbTamanho";
			this.m_tbTamanho.Size = new System.Drawing.Size(232, 262);
			this.m_tbTamanho.TabIndex = 1;
			this.m_tbTamanho.Text = "Tamanho";
			this.m_tbTamanho.Visible = false;
			// 
			// m_gbTamanho
			// 
			this.m_gbTamanho.Controls.Add(this.m_txtAltura);
			this.m_gbTamanho.Controls.Add(this.m_txtLargura);
			this.m_gbTamanho.Controls.Add(this.m_lbCm2);
			this.m_gbTamanho.Controls.Add(this.m_lbCm);
			this.m_gbTamanho.Controls.Add(this.m_lbAltura);
			this.m_gbTamanho.Controls.Add(this.m_lbLargura);
			this.m_gbTamanho.Controls.Add(this.m_rbPersonalizado);
			this.m_gbTamanho.Controls.Add(this.m_rbA4);
			this.m_gbTamanho.Controls.Add(this.m_rbCarta);
			this.m_gbTamanho.Location = new System.Drawing.Point(7, 2);
			this.m_gbTamanho.Name = "m_gbTamanho";
			this.m_gbTamanho.Size = new System.Drawing.Size(218, 254);
			this.m_gbTamanho.TabIndex = 3;
			this.m_gbTamanho.TabStop = false;
			// 
			// m_txtAltura
			// 
			this.m_txtAltura.Location = new System.Drawing.Point(108, 112);
			this.m_txtAltura.Mask = false;
			this.m_txtAltura.MaskText = "";
			this.m_txtAltura.Name = "m_txtAltura";
			this.m_txtAltura.OnlyNumbers = false;
			this.m_txtAltura.Size = new System.Drawing.Size(39, 20);
			this.m_txtAltura.TabIndex = 33;
			this.m_txtAltura.Text = "";
			this.m_txtAltura.TextChanged += new System.EventHandler(this.m_txtAltura_TextChanged);
			// 
			// m_txtLargura
			// 
			this.m_txtLargura.Location = new System.Drawing.Point(109, 87);
			this.m_txtLargura.Mask = false;
			this.m_txtLargura.MaskText = "";
			this.m_txtLargura.Name = "m_txtLargura";
			this.m_txtLargura.OnlyNumbers = false;
			this.m_txtLargura.Size = new System.Drawing.Size(39, 20);
			this.m_txtLargura.TabIndex = 32;
			this.m_txtLargura.Text = "";
			this.m_txtLargura.TextChanged += new System.EventHandler(this.m_txtLargura_TextChanged);
			// 
			// m_lbCm2
			// 
			this.m_lbCm2.Location = new System.Drawing.Point(154, 116);
			this.m_lbCm2.Name = "m_lbCm2";
			this.m_lbCm2.Size = new System.Drawing.Size(48, 16);
			this.m_lbCm2.TabIndex = 9;
			this.m_lbCm2.Text = "cm";
			// 
			// m_lbCm
			// 
			this.m_lbCm.Location = new System.Drawing.Point(154, 93);
			this.m_lbCm.Name = "m_lbCm";
			this.m_lbCm.Size = new System.Drawing.Size(48, 16);
			this.m_lbCm.TabIndex = 8;
			this.m_lbCm.Text = "cm";
			// 
			// m_lbAltura
			// 
			this.m_lbAltura.Location = new System.Drawing.Point(48, 115);
			this.m_lbAltura.Name = "m_lbAltura";
			this.m_lbAltura.Size = new System.Drawing.Size(48, 16);
			this.m_lbAltura.TabIndex = 7;
			this.m_lbAltura.Text = "Altura";
			// 
			// m_lbLargura
			// 
			this.m_lbLargura.Location = new System.Drawing.Point(48, 92);
			this.m_lbLargura.Name = "m_lbLargura";
			this.m_lbLargura.Size = new System.Drawing.Size(48, 16);
			this.m_lbLargura.TabIndex = 5;
			this.m_lbLargura.Text = "Largura";
			// 
			// m_rbPersonalizado
			// 
			this.m_rbPersonalizado.Location = new System.Drawing.Point(24, 68);
			this.m_rbPersonalizado.Name = "m_rbPersonalizado";
			this.m_rbPersonalizado.Size = new System.Drawing.Size(128, 16);
			this.m_rbPersonalizado.TabIndex = 2;
			this.m_rbPersonalizado.Text = "Personalizado";
			this.m_rbPersonalizado.CheckedChanged += new System.EventHandler(this.m_rbPersonalizado_CheckedChanged);
			// 
			// m_rbA4
			// 
			this.m_rbA4.Location = new System.Drawing.Point(24, 24);
			this.m_rbA4.Name = "m_rbA4";
			this.m_rbA4.Size = new System.Drawing.Size(128, 16);
			this.m_rbA4.TabIndex = 0;
			this.m_rbA4.Text = "A4";
			this.m_rbA4.CheckedChanged += new System.EventHandler(this.m_rbA4_CheckedChanged);
			// 
			// m_rbCarta
			// 
			this.m_rbCarta.Location = new System.Drawing.Point(24, 46);
			this.m_rbCarta.Name = "m_rbCarta";
			this.m_rbCarta.Size = new System.Drawing.Size(128, 16);
			this.m_rbCarta.TabIndex = 1;
			this.m_rbCarta.Text = "Carta";
			this.m_rbCarta.CheckedChanged += new System.EventHandler(this.m_rbCarta_CheckedChanged);
			// 
			// m_tbDisposicao
			// 
			this.m_tbDisposicao.Controls.Add(this.m_gbDisposicao);
			this.m_tbDisposicao.Location = new System.Drawing.Point(4, 22);
			this.m_tbDisposicao.Name = "m_tbDisposicao";
			this.m_tbDisposicao.Size = new System.Drawing.Size(232, 262);
			this.m_tbDisposicao.TabIndex = 2;
			this.m_tbDisposicao.Text = "Orientação";
			this.m_tbDisposicao.Visible = false;
			// 
			// m_gbDisposicao
			// 
			this.m_gbDisposicao.Controls.Add(this.m_ckPaisagem);
			this.m_gbDisposicao.Controls.Add(this.m_ckRetrato);
			this.m_gbDisposicao.Controls.Add(this.m_pnRetrato);
			this.m_gbDisposicao.Controls.Add(this.m_pnPaisagem);
			this.m_gbDisposicao.Location = new System.Drawing.Point(7, 2);
			this.m_gbDisposicao.Name = "m_gbDisposicao";
			this.m_gbDisposicao.Size = new System.Drawing.Size(218, 254);
			this.m_gbDisposicao.TabIndex = 4;
			this.m_gbDisposicao.TabStop = false;
			// 
			// m_ckPaisagem
			// 
			this.m_ckPaisagem.Appearance = System.Windows.Forms.Appearance.Button;
			this.m_ckPaisagem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_ckPaisagem.Image = ((System.Drawing.Image)(resources.GetObject("m_ckPaisagem.Image")));
			this.m_ckPaisagem.Location = new System.Drawing.Point(112, 104);
			this.m_ckPaisagem.Name = "m_ckPaisagem";
			this.m_ckPaisagem.Size = new System.Drawing.Size(56, 40);
			this.m_ckPaisagem.TabIndex = 3;
			this.m_ckPaisagem.CheckedChanged += new System.EventHandler(this.m_ckPaisagem_CheckedChanged);
			// 
			// m_ckRetrato
			// 
			this.m_ckRetrato.Appearance = System.Windows.Forms.Appearance.Button;
			this.m_ckRetrato.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_ckRetrato.Image = ((System.Drawing.Image)(resources.GetObject("m_ckRetrato.Image")));
			this.m_ckRetrato.Location = new System.Drawing.Point(38, 104);
			this.m_ckRetrato.Name = "m_ckRetrato";
			this.m_ckRetrato.Size = new System.Drawing.Size(56, 40);
			this.m_ckRetrato.TabIndex = 2;
			this.m_ckRetrato.CheckedChanged += new System.EventHandler(this.m_ckRetrato_CheckedChanged);
			// 
			// m_pnRetrato
			// 
			this.m_pnRetrato.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(192)), ((System.Byte)(0)));
			this.m_pnRetrato.Location = new System.Drawing.Point(31, 95);
			this.m_pnRetrato.Name = "m_pnRetrato";
			this.m_pnRetrato.Size = new System.Drawing.Size(72, 59);
			this.m_pnRetrato.TabIndex = 4;
			// 
			// m_pnPaisagem
			// 
			this.m_pnPaisagem.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(192)), ((System.Byte)(0)));
			this.m_pnPaisagem.Location = new System.Drawing.Point(104, 96);
			this.m_pnPaisagem.Name = "m_pnPaisagem";
			this.m_pnPaisagem.Size = new System.Drawing.Size(72, 59);
			this.m_pnPaisagem.TabIndex = 5;
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(192, 312);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 5;
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(256, 312);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 6;
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// frmFRelatoriosPropriedadesRelatorio
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(512, 350);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.HelpButton = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFRelatoriosPropriedadesRelatorio";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Configurar Relatório";
			this.Load += new System.EventHandler(this.frmFRelatoriosPropriedadesRelatorio_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbVisualizar.ResumeLayout(false);
			this.m_pnFormato.ResumeLayout(false);
			this.m_tcOpcoes.ResumeLayout(false);
			this.m_tpMargens.ResumeLayout(false);
			this.m_gbMargens.ResumeLayout(false);
			this.m_pnRelatorio.ResumeLayout(false);
			this.m_tbTamanho.ResumeLayout(false);
			this.m_gbTamanho.ResumeLayout(false);
			this.m_tbDisposicao.ResumeLayout(false);
			this.m_gbDisposicao.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos 
			#region Formulario
				private void frmFRelatoriosPropriedadesRelatorio_Load(object sender, System.EventArgs e)
				{
					MostraCor();
					RefreshInterface();
					RefreshInterfaceRelatorio();
				}
			#endregion
			#region Botoes
				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					// Margens 
					m_nAcima = (int)(double.Parse(m_txtAcima.Text) * CONVERSOR_PIXELS_POR_CM);
                    m_nDireita = (int)(double.Parse(m_txtDireita.Text) * CONVERSOR_PIXELS_POR_CM);
					m_nAbaixo = (int)(double.Parse(m_txtAbaixo.Text) * CONVERSOR_PIXELS_POR_CM);
					m_nEsquerda = (int)(double.Parse(m_txtEsquerda.Text)* CONVERSOR_PIXELS_POR_CM);
					if (m_rbA4.Checked)
					{
						m_nLargura = (int)(TAMANHO_A4_LARGURA_EM_CM * CONVERSOR_PIXELS_POR_CM);
						m_nAltura = (int)(TAMANHO_A4_ALTURA_EM_CM * CONVERSOR_PIXELS_POR_CM);
					}else{
						if (m_rbCarta.Checked)
						{
							m_nLargura = (int)(TAMANHO_CARTA_LARGURA_EM_CM * CONVERSOR_PIXELS_POR_CM);
							m_nAltura = (int)(TAMANHO_CARTA_ALTURA_EM_CM * CONVERSOR_PIXELS_POR_CM);
						}else{
							m_nLargura = (int)(double.Parse(m_txtLargura.Text)* CONVERSOR_PIXELS_POR_CM);
							m_nAltura = (int)(double.Parse(m_txtAltura.Text)* CONVERSOR_PIXELS_POR_CM);
						}
					}
					m_bModificado = true;
					this.Close();
				}

				private void m_btCancelar_Click(object sender, System.EventArgs e)
				{
					m_bModificado = false;
					this.Close();
				}
			#endregion
			#region Margens
			private void m_txtAcima_TextChanged(object sender, System.EventArgs e)
			{
				if (m_bAtivado)
				{
					double dValor;
					if (m_txtAcima.Text.Trim() != "")
					{
						try
						{
							dValor = double.Parse(m_txtAcima.Text);
							if (dValor > m_dAltura)
								m_txtAcima.Text = m_dAltura.ToString();
							RefreshInterfaceRelatorio();
						}catch{
							m_txtAcima.Text = m_dAltura.ToString();
							RefreshInterfaceRelatorio();
						}
					}
				}
			}

			private void m_txtDireita_TextChanged(object sender, System.EventArgs e)
			{
				if (m_bAtivado)
				{
					double dValor;
					if (m_txtDireita.Text.Trim() != "")
					{
						try
						{
							dValor = double.Parse(m_txtDireita.Text);
							if (dValor > m_dLargura)
								m_txtDireita.Text = m_dLargura.ToString();
							RefreshInterfaceRelatorio();
						}
						catch
						{
							m_txtDireita.Text = m_dLargura.ToString();
							RefreshInterfaceRelatorio();
						}
					}
				}
			}

			private void m_txtAbaixo_TextChanged(object sender, System.EventArgs e)
			{
				if (m_bAtivado)
				{
					double dValor;
					if (m_txtAbaixo.Text.Trim() != "")
					{
						try
						{
							dValor = double.Parse(m_txtAbaixo.Text);
							if (dValor > m_dAltura)
								m_txtAbaixo.Text = m_dAltura.ToString();
							RefreshInterfaceRelatorio();
						}
						catch
						{
							m_txtAbaixo.Text = m_dAltura.ToString();
							RefreshInterfaceRelatorio();
						}
					}
				}
			}

			private void m_txtEsquerda_TextChanged(object sender, System.EventArgs e)
			{
				if (m_bAtivado)
				{
					double dValor;
					if (m_txtEsquerda.Text.Trim() != "")
					{
						try
						{
							dValor = double.Parse(m_txtEsquerda.Text);
							if (dValor > m_dLargura)
								m_txtEsquerda.Text = m_dLargura.ToString();
							RefreshInterfaceRelatorio();
						}
						catch
						{
							m_txtEsquerda.Text = m_dLargura.ToString();
							RefreshInterfaceRelatorio();
						}
					}
				}
			}
		#endregion
			#region Tamanho
				private void m_rbA4_CheckedChanged(object sender, System.EventArgs e)
				{
					if (m_bAtivado)
					{
						m_bAtivado = !m_bAtivado;
						if (m_rbA4.Checked)
						{
							m_txtAltura.Enabled = false;
							m_txtAltura.Text = TAMANHO_A4_ALTURA_EM_CM.ToString();
							m_txtLargura.Enabled = false;
							m_txtLargura.Text = TAMANHO_A4_LARGURA_EM_CM.ToString();
							m_dLargura = TAMANHO_A4_LARGURA_EM_CM;
							m_dAltura = TAMANHO_A4_ALTURA_EM_CM;
							RefreshInterfaceRelatorio();
						}
						m_bAtivado = !m_bAtivado;
					}
				}

				private void m_rbCarta_CheckedChanged(object sender, System.EventArgs e)
				{
					if (m_bAtivado)
					{
						m_bAtivado = !m_bAtivado;
						if (m_rbCarta.Checked)
						{
							m_txtAltura.Enabled = false;
							m_txtAltura.Text = TAMANHO_CARTA_ALTURA_EM_CM.ToString();
							m_txtLargura.Enabled = false;
							m_txtLargura.Text = TAMANHO_CARTA_LARGURA_EM_CM.ToString();
							m_dLargura = TAMANHO_CARTA_LARGURA_EM_CM;
							m_dAltura = TAMANHO_CARTA_ALTURA_EM_CM;
							RefreshInterfaceRelatorio();
						}
						m_bAtivado = !m_bAtivado;
					}
				}

				private void m_rbPersonalizado_CheckedChanged(object sender, System.EventArgs e)
				{
					if (m_bAtivado)
					{
						m_bAtivado = !m_bAtivado;
						if (m_rbPersonalizado.Checked)
						{
		                    m_txtAltura.Enabled = true;
			                m_txtLargura.Enabled = true;
					        RefreshInterfaceRelatorio();
						}
						m_bAtivado = !m_bAtivado;
					}
				}

				private void m_txtLargura_TextChanged(object sender, System.EventArgs e)
				{
					try
					{
						m_dLargura = double.Parse(m_txtLargura.Text);
					}catch{}
			        RefreshInterfaceRelatorio();
				}

				private void m_txtAltura_TextChanged(object sender, System.EventArgs e)
				{
					try
					{
						m_dAltura = double.Parse(m_txtAltura.Text);
					}catch{}
			        RefreshInterfaceRelatorio();
				}
			#endregion
			#region Disposicao
				private void m_ckRetrato_CheckedChanged(object sender, System.EventArgs e)
				{
					if (m_bAtivado)
					{
						m_bAtivado = !m_bAtivado;
						if (m_ckRetrato.Checked)
						{
							m_pnRetrato.BackColor = System.Drawing.Color.Green;
							m_pnPaisagem.BackColor = this.BackColor;
							m_ckPaisagem.Checked = false;
							m_nDisposicao = DISPOSICAO_RETRATO;
							RefreshInterfaceRelatorio();
						}else{
							m_ckRetrato.Checked = true;
						}
						m_bAtivado = !m_bAtivado;
					}
				}

				private void m_ckPaisagem_CheckedChanged(object sender, System.EventArgs e)
				{
					if (m_bAtivado)
					{
						m_bAtivado = !m_bAtivado;
						if (m_ckPaisagem.Checked)
						{
							m_ckRetrato.Checked = false;
							m_pnRetrato.BackColor = this.BackColor;
							m_pnPaisagem.BackColor = System.Drawing.Color.Green;
							m_nDisposicao = DISPOSICAO_PAISAGEM;
							RefreshInterfaceRelatorio();
						}
						else
						{
							m_ckPaisagem.Checked = true;
						}
						m_bAtivado = !m_bAtivado;
					}
			
				}
			#endregion
		#endregion
		#region Cores
		private void MostraCor()
		{
			mdlPaletaDeCores.clsPaletaDeCores clsPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini","SiscobrasCorSecundaria");
			this.BackColor = clsPaletaCores.retornaCorAtual();
			for (int nCont = 0 ;nCont < this.Controls.Count; nCont++)
			{
				this.Controls[nCont].BackColor = this.BackColor;
				for (int nCont2 = 0 ;nCont2 < this.Controls[nCont].Controls.Count; nCont2++)
				{
					if ((this.Controls[nCont].Controls[nCont2].GetType().ToString() != "mdlComponentesGraficos.TextBox") && (this.Controls[nCont].Controls[nCont2].GetType().ToString() != "System.Windows.Forms.Label"))
						this.Controls[nCont].Controls[nCont2].BackColor = this.BackColor;

					for (int nCont3 = 0 ;nCont3 < this.Controls[nCont].Controls[nCont2].Controls.Count; nCont3++)
					{
						if ((this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "System.Windows.Forms.ListView") && (this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "System.Windows.Forms.Panel"))
							this.Controls[nCont].Controls[nCont2].Controls[nCont3].BackColor = this.BackColor;
					}
				}
			}
	        m_pnFormato.BackColor = System.Drawing.Color.Gainsboro;
	        m_picRelatorio.BackColor = m_clrCorFundo;
		    m_pnFolha.BackColor = m_clrCorFundo;

		}
		#endregion

		#region Refresh
		private void RefreshInterface()
		{
            m_bAtivado = false;

            // Margens 
            m_txtAcima.Text = (m_nAcima / CONVERSOR_PIXELS_POR_CM).ToString();
            m_txtDireita.Text = (m_nDireita / CONVERSOR_PIXELS_POR_CM).ToString();
            m_txtAbaixo.Text = (m_nAbaixo / CONVERSOR_PIXELS_POR_CM).ToString();
            m_txtEsquerda.Text = (m_nEsquerda / CONVERSOR_PIXELS_POR_CM).ToString();

            // Tamanho
            if (m_nLargura == 819) 
			{
				if (m_nAltura == 1158)
				{
					m_rbA4.Checked = true;
					m_txtLargura.Text = TAMANHO_A4_LARGURA_EM_CM.ToString();
					m_dLargura = TAMANHO_A4_LARGURA_EM_CM;
					m_txtLargura.Enabled = false;
					m_txtAltura.Text = TAMANHO_A4_ALTURA_EM_CM.ToString();
					m_dAltura = TAMANHO_A4_ALTURA_EM_CM;
					m_txtAltura.Enabled = false;
				}else{
                    m_rbPersonalizado.Checked = true;
                    m_txtLargura.Text = (m_nLargura / CONVERSOR_PIXELS_POR_CM).ToString();
                    m_txtAltura.Text = (m_nAltura / CONVERSOR_PIXELS_POR_CM).ToString();
                    m_dLargura = (m_nLargura / CONVERSOR_PIXELS_POR_CM);
                    m_dAltura = (m_nAltura / CONVERSOR_PIXELS_POR_CM);
				}
			}else{
				if (m_nLargura == 842)
				{ 
					if (m_nAltura == 1089)
					{
						m_rbCarta.Checked = true;
						m_txtLargura.Text = TAMANHO_CARTA_LARGURA_EM_CM.ToString();
						m_dLargura = TAMANHO_CARTA_LARGURA_EM_CM;
						m_txtLargura.Enabled = false;
						m_txtAltura.Text = TAMANHO_CARTA_ALTURA_EM_CM.ToString();
						m_dAltura = TAMANHO_CARTA_ALTURA_EM_CM;
						m_txtAltura.Enabled = false;
					}else{
                        m_rbPersonalizado.Checked = true;
                        m_txtLargura.Text = (m_nLargura / CONVERSOR_PIXELS_POR_CM).ToString();
                        m_txtAltura.Text = (m_nAltura / CONVERSOR_PIXELS_POR_CM).ToString();
                        m_dLargura = (m_nLargura / CONVERSOR_PIXELS_POR_CM);
						m_dAltura = (m_nAltura / CONVERSOR_PIXELS_POR_CM);
					}
				}else{
                    m_rbPersonalizado.Checked = true;
                    m_txtLargura.Text = (m_nLargura / CONVERSOR_PIXELS_POR_CM).ToString();
                    m_txtAltura.Text = (m_nAltura / CONVERSOR_PIXELS_POR_CM).ToString();
                    m_dLargura = (m_nLargura / CONVERSOR_PIXELS_POR_CM);
					m_dAltura = (m_nAltura / CONVERSOR_PIXELS_POR_CM);
				}
			}

            // Disposicao 
			switch(m_nDisposicao)
			{
				case DISPOSICAO_RETRATO:
                    m_ckRetrato.Checked = true;
                    m_ckRetrato.BackColor = System.Drawing.Color.Green;
                    m_pnRetrato.BackColor = System.Drawing.Color.Green;
                    m_pnPaisagem.BackColor = this.BackColor;
                    m_ckPaisagem.Checked = false;
                    m_ckPaisagem.BackColor = System.Drawing.Color.Red;
					break;
				case DISPOSICAO_PAISAGEM:
                    m_ckRetrato.Checked = false;
                    m_ckRetrato.BackColor = System.Drawing.Color.Red;
                    m_pnRetrato.BackColor = this.BackColor;
                    m_pnPaisagem.BackColor = System.Drawing.Color.Green;
                    m_ckPaisagem.Checked = true;
                    m_ckPaisagem.BackColor = System.Drawing.Color.Green;
					break;
		    }
            m_bAtivado = true;
		}

		private void RefreshInterfaceRelatorio()
		{
            System.Drawing.Bitmap bmpImagem; 
            if (m_ckRetrato.Checked) //Retrato
			{
                m_picRelatorio.Location = new System.Drawing.Point(45, 45);
                m_picRelatorio.Size = new System.Drawing.Size(125, 180);
			    bmpImagem = new System.Drawing.Bitmap(125, 180);
			}else{ // Paisagem 
                m_picRelatorio.Location = new System.Drawing.Point(15, 70);
                m_picRelatorio.Size = new System.Drawing.Size(180, 125);
                bmpImagem = new System.Drawing.Bitmap(180, 125);
            }

            // Criando a caneta 
            System.Drawing.Graphics graf = System.Drawing.Graphics.FromImage(bmpImagem);
            // Pintando o Fundo 
            graf.FillRectangle(new System.Drawing.SolidBrush(m_clrCorFundo), 0, 0, bmpImagem.Width, bmpImagem.Height);
            // Fonte a Utilizar
	        System.Drawing.Font fntFonte = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular | System.Drawing.FontStyle.Bold);
            // Altura
            graf.DrawString("Altura: " + m_dAltura, fntFonte, new System.Drawing.SolidBrush(System.Drawing.Color.Black), 25, 30);
            // Largura 
            graf.DrawString("Largura: " + m_dLargura, fntFonte, new System.Drawing.SolidBrush(System.Drawing.Color.Black), 25, 45);

            double dNumero;
			// Acima 
            if (m_txtAcima.Text.Trim() != "")
			{
				try
				{
					if ((dNumero = double .Parse(m_txtAcima.Text)) > 0)
					{
						dNumero = dNumero * 3;
						graf.DrawLine(new System.Drawing.Pen(m_clrCorMargem), 0, (int)dNumero, bmpImagem.Width, (int)dNumero);
					}
				}catch{}
            }

            // Direita 
			if (m_txtDireita.Text.Trim() != "")
			{
				try
				{
					if ((dNumero = double .Parse(m_txtDireita.Text)) > 0)
					{
						dNumero = dNumero * 3;
						graf.DrawLine(new System.Drawing.Pen(m_clrCorMargem), bmpImagem.Width - (int)dNumero, 0, bmpImagem.Width - (int)dNumero, bmpImagem.Height);
					}
				}
				catch{}
			}

            // Abaixo 
			if (m_txtAbaixo.Text.Trim() != "")
			{
				try
				{
					if ((dNumero = double .Parse(m_txtAbaixo.Text)) > 0)
					{
						dNumero = dNumero * 3;
						graf.DrawLine(new System.Drawing.Pen(m_clrCorMargem), 0, bmpImagem.Height - (int)dNumero, bmpImagem.Width, bmpImagem.Height - (int)dNumero);
					}
				}
				catch{}
			}

            // Esquerda 
			if (m_txtEsquerda.Text.Trim() != "")
			{
				try
				{
					if ((dNumero = double .Parse(m_txtEsquerda.Text)) > 0)
					{
						dNumero = dNumero * 3;
						graf.DrawLine(new System.Drawing.Pen(m_clrCorMargem), (int)dNumero, 0, (int)dNumero, bmpImagem.Height);
					}
				}
				catch{}
			}

            // Destruindo a caneta  
            graf = null;

            // Colando a Imagem na Tela
            m_picRelatorio.BackgroundImage = bmpImagem;
            this.Refresh();
		}


		#endregion

		#region Retorno
			public void RetornaValores(out int nAcima, out int nDireita, out int nAbaixo, out int nEsquerda,out int nLargura ,out int nAltura, out int nDisposicao)
			{
				// Margens 
				nAcima = m_nAcima;
				nDireita = m_nDireita;
				nAbaixo = m_nAbaixo;
				nEsquerda = m_nEsquerda;

				// Tamanho 
				nAltura = m_nAltura;
				nLargura = m_nLargura;

				// Disposicao 
				nDisposicao = m_nDisposicao;
			}
		#endregion

	}
}
