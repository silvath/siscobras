using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlProdutosRomaneio
{
	/// <summary>
	/// Summary description for frmFVolumeNovo.
	/// </summary>
	internal class frmFVolumeNovo : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate void delCallCarregaDadosInterfaceVolumeTipo(ref int nIdEmbalagemTipo,out int nIdVolumeImage,out string strDescricao,out string strDescricaoPopular);
			public delegate bool delCallVolumesInexistentes(ref System.Collections.ArrayList arlVolumes);
			public delegate void delCallShowDialogVolumeTipo(ref int nIdVolumeTipo,ref System.Windows.Forms.ImageList ilVolumes);
			public delegate string delCallRetornaSiglaUnidadeEspaco(int nUnidadeEspaco);
			public delegate string delCallRetornaSiglaUnidadeMassa(int nUnidadeMassa);
		#endregion
		#region Events
			public event delCallCarregaDadosInterfaceVolumeTipo eCallCarregaDadosInterfaceVolumeTipo;
			public event delCallVolumesInexistentes eCallVolumesInexistentes;
			public event delCallShowDialogVolumeTipo eCallShowDialogVolumeTipo;
			public event delCallRetornaSiglaUnidadeEspaco eCallRetornaSiglaUnidadeEspaco;
			public event delCallRetornaSiglaUnidadeMassa eCallRetornaSiglaUnidadeMassa;
		#endregion
		#region Events Methods
			protected virtual void OnCallCarregaDadosInterfaceVolumeTipo()
			{
				if (eCallCarregaDadosInterfaceVolumeTipo != null)
				{
					int nVolumeImage;
					string strDescricao;
					string strDescricaoPopular;
					eCallCarregaDadosInterfaceVolumeTipo(ref m_nIdVolumeTipo,out nVolumeImage,out strDescricao,out strDescricaoPopular);
					m_btTipo.Image = (System.Drawing.Image)m_ilVolumes.Images[nVolumeImage].Clone();
					m_txtTipoPopular.Text = strDescricao;
				}
			}

			protected virtual bool OnCallVolumesInexistentes(ref System.Collections.ArrayList arlVolumes)
			{
				bool bRetorno = false;
				if (eCallVolumesInexistentes != null)
				{
					bRetorno = eCallVolumesInexistentes(ref arlVolumes);
				}
				return (bRetorno);
			}

			protected virtual void OnCallShowDialogVolumeTipo()
			{
				if (eCallShowDialogVolumeTipo != null)
				{
					int nIdVolumeTipo = m_nIdVolumeTipo;
					eCallShowDialogVolumeTipo(ref nIdVolumeTipo,ref m_ilVolumes);
					if (m_nIdVolumeTipo != nIdVolumeTipo)
					{
						m_nIdVolumeTipo = nIdVolumeTipo;
						OnCallCarregaDadosInterfaceVolumeTipo();
					}
				}
			}

			protected virtual string OnCallRetornaSiglaUnidadeEspaco(int nUnidadeEspaco)
			{
				string strRetorno = "";
				if (eCallRetornaSiglaUnidadeEspaco != null)
				{
					strRetorno = eCallRetornaSiglaUnidadeEspaco(nUnidadeEspaco);
				}
				return(strRetorno);
			}

			protected virtual string OnCallRetornaSiglaUnidadeMassa(int nUnidadeMassa)
			{
				string strRetorno = "";
				if (eCallRetornaSiglaUnidadeMassa != null)
				{
					strRetorno = eCallRetornaSiglaUnidadeMassa(nUnidadeMassa);
				}
				return(strRetorno);
			}
		#endregion

		#region Constantes
			private const string TEXTO_UNIDADE_MEDIDA_CM = "cm";
			private const string TEXTO_UNIDADE_MEDIDA_CM3 = "cm3";
			private const string TEXTO_UNIDADE_MEDIDA_M = "m";
			private const string TEXTO_UNIDADE_MEDIDA_M3 = "m3";
			private const string TEXTO_UNIDADE_PESO_G = "g";
			private const string TEXTO_UNIDADE_PESO_KG = "Kg";
		#endregion
		#region Atributes
			private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro; 
			private string m_strEnderecoExecutavel;
			private System.Windows.Forms.ImageList m_ilVolumes;

			public bool m_bModificado = false;
			private int m_nIdVolumeTipo = -1;
			private string m_strDescricaoPopular = "";

		    // Retorno
			private System.Collections.ArrayList m_arlVolumes = null;
			private System.Collections.ArrayList m_arlAltura = null;
			private mdlProdutosRomaneio.UnidadeMedida m_enumUnidadeAltura = mdlProdutosRomaneio.UnidadeMedida.Centimetro; 
			private System.Collections.ArrayList m_arlLargura = null;
			private mdlProdutosRomaneio.UnidadeMedida m_enumUnidadeLargura = mdlProdutosRomaneio.UnidadeMedida.Centimetro; 
			private System.Collections.ArrayList m_arlComprimento = null;
			private mdlProdutosRomaneio.UnidadeMedida m_enumUnidadeComprimento = mdlProdutosRomaneio.UnidadeMedida.Centimetro; 
			private System.Collections.ArrayList m_arlVolume = null;
			private mdlProdutosRomaneio.UnidadeMedida m_enumUnidadeVolume = mdlProdutosRomaneio.UnidadeMedida.Metro; 
			private System.Collections.ArrayList m_arlPesoLiquido = null;
			private int m_nUnidadeMassaPesoLiquido = (int)mdlProdutosRomaneio.UnidadeMassa.Kilograma; 
			private System.Collections.ArrayList m_arlPesoBruto = null;
			private int m_nUnidadeMassaPesoBruto = (int)mdlProdutosRomaneio.UnidadeMassa.Kilograma; 

		    internal System.Windows.Forms.GroupBox m_gbGeral;
			internal System.Windows.Forms.GroupBox m_gbMedidas;
			internal System.Windows.Forms.Button m_btUnidadeVolume;
			internal System.Windows.Forms.Button m_btUnidadeComprimento;
			internal System.Windows.Forms.Button m_btUnidadeLargura;
			internal System.Windows.Forms.Button m_btUnidadeAltura;
			internal mdlComponentesGraficos.TextBox m_txtVolume;
			internal mdlComponentesGraficos.TextBox m_txtComprimento;
			internal mdlComponentesGraficos.TextBox m_txtLargura;
			internal mdlComponentesGraficos.TextBox m_txtAltura;
			internal System.Windows.Forms.Label m_lbVolume;
			internal System.Windows.Forms.Label m_lbLargura;
			internal System.Windows.Forms.Label m_lbComprimento;
			internal System.Windows.Forms.Label m_lbAltura;
			internal System.Windows.Forms.GroupBox m_gbTipo;
			internal mdlComponentesGraficos.TextBox m_txtTipoPopular;
			internal System.Windows.Forms.Label m_lbPE;
			internal System.Windows.Forms.Button m_btTipo;
			internal System.Windows.Forms.GroupBox m_gbIntervalo;
			internal System.Windows.Forms.Label m_lbInfo;
			internal System.Windows.Forms.Label m_lbIntervalo;
			internal mdlComponentesGraficos.TextBox m_txtIntervalo;
			internal System.Windows.Forms.Button m_btOk;
			internal System.Windows.Forms.Button m_btCancelar;
			internal System.Windows.Forms.Button m_btUnidadePesoLiquido;
			internal mdlComponentesGraficos.TextBox m_txtPesoLiquido;
			internal System.Windows.Forms.Label m_lbPesoLiquido;
			internal System.Windows.Forms.Button m_btUnidadePesoBruto;
			internal mdlComponentesGraficos.TextBox m_txtPesoBruto;
			internal System.Windows.Forms.Label m_lbPesoBruto;
			public System.Windows.Forms.Button m_btEditarAltura;
			public System.Windows.Forms.Button m_btEditarLargura;
			public System.Windows.Forms.Button m_btEditarComprimento;
			public System.Windows.Forms.Button m_btEditarVolume;
			public System.Windows.Forms.Button m_btEditarPesoLiquido;
			public System.Windows.Forms.Button m_btEditarPesoBruto;
			private System.Windows.Forms.ToolTip m_ttDica;
		private System.Windows.Forms.LinkLabel m_llbIntervalos;
		internal mdlComponentesGraficos.TextBox m_txtPrefixo;
		internal System.Windows.Forms.Label m_lbSufixo;
		internal mdlComponentesGraficos.TextBox m_txtSufixo;
		internal System.Windows.Forms.Label m_lbPrefixo;
			private System.ComponentModel.IContainer components;
		#endregion
		#region Constructors and Destructors
			public frmFVolumeNovo(ref mdlTratamentoErro.clsTratamentoErro TratadorErro, string strEnderecoExecutavel,ref System.Windows.Forms.ImageList ilVolumes)
			{
				m_cls_ter_tratadorErro = TratadorErro;
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				m_ilVolumes = ilVolumes;
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFVolumeNovo));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_gbMedidas = new System.Windows.Forms.GroupBox();
			this.m_btEditarPesoBruto = new System.Windows.Forms.Button();
			this.m_btEditarPesoLiquido = new System.Windows.Forms.Button();
			this.m_btEditarVolume = new System.Windows.Forms.Button();
			this.m_btEditarComprimento = new System.Windows.Forms.Button();
			this.m_btEditarLargura = new System.Windows.Forms.Button();
			this.m_btEditarAltura = new System.Windows.Forms.Button();
			this.m_btUnidadePesoBruto = new System.Windows.Forms.Button();
			this.m_txtPesoBruto = new mdlComponentesGraficos.TextBox();
			this.m_lbPesoBruto = new System.Windows.Forms.Label();
			this.m_btUnidadePesoLiquido = new System.Windows.Forms.Button();
			this.m_txtPesoLiquido = new mdlComponentesGraficos.TextBox();
			this.m_lbPesoLiquido = new System.Windows.Forms.Label();
			this.m_btUnidadeVolume = new System.Windows.Forms.Button();
			this.m_btUnidadeComprimento = new System.Windows.Forms.Button();
			this.m_btUnidadeLargura = new System.Windows.Forms.Button();
			this.m_btUnidadeAltura = new System.Windows.Forms.Button();
			this.m_txtVolume = new mdlComponentesGraficos.TextBox();
			this.m_txtComprimento = new mdlComponentesGraficos.TextBox();
			this.m_txtLargura = new mdlComponentesGraficos.TextBox();
			this.m_txtAltura = new mdlComponentesGraficos.TextBox();
			this.m_lbVolume = new System.Windows.Forms.Label();
			this.m_lbLargura = new System.Windows.Forms.Label();
			this.m_lbComprimento = new System.Windows.Forms.Label();
			this.m_lbAltura = new System.Windows.Forms.Label();
			this.m_gbTipo = new System.Windows.Forms.GroupBox();
			this.m_txtTipoPopular = new mdlComponentesGraficos.TextBox();
			this.m_lbPE = new System.Windows.Forms.Label();
			this.m_btTipo = new System.Windows.Forms.Button();
			this.m_gbIntervalo = new System.Windows.Forms.GroupBox();
			this.m_txtSufixo = new mdlComponentesGraficos.TextBox();
			this.m_txtPrefixo = new mdlComponentesGraficos.TextBox();
			this.m_llbIntervalos = new System.Windows.Forms.LinkLabel();
			this.m_lbInfo = new System.Windows.Forms.Label();
			this.m_lbIntervalo = new System.Windows.Forms.Label();
			this.m_txtIntervalo = new mdlComponentesGraficos.TextBox();
			this.m_lbPrefixo = new System.Windows.Forms.Label();
			this.m_lbSufixo = new System.Windows.Forms.Label();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_ttDica = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbGeral.SuspendLayout();
			this.m_gbMedidas.SuspendLayout();
			this.m_gbTipo.SuspendLayout();
			this.m_gbIntervalo.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbGeral.Controls.Add(this.m_gbMedidas);
			this.m_gbGeral.Controls.Add(this.m_gbTipo);
			this.m_gbGeral.Controls.Add(this.m_gbIntervalo);
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Location = new System.Drawing.Point(2, -3);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(285, 406);
			this.m_gbGeral.TabIndex = 1;
			this.m_gbGeral.TabStop = false;
			// 
			// m_gbMedidas
			// 
			this.m_gbMedidas.Controls.Add(this.m_btEditarPesoBruto);
			this.m_gbMedidas.Controls.Add(this.m_btEditarPesoLiquido);
			this.m_gbMedidas.Controls.Add(this.m_btEditarVolume);
			this.m_gbMedidas.Controls.Add(this.m_btEditarComprimento);
			this.m_gbMedidas.Controls.Add(this.m_btEditarLargura);
			this.m_gbMedidas.Controls.Add(this.m_btEditarAltura);
			this.m_gbMedidas.Controls.Add(this.m_btUnidadePesoBruto);
			this.m_gbMedidas.Controls.Add(this.m_txtPesoBruto);
			this.m_gbMedidas.Controls.Add(this.m_lbPesoBruto);
			this.m_gbMedidas.Controls.Add(this.m_btUnidadePesoLiquido);
			this.m_gbMedidas.Controls.Add(this.m_txtPesoLiquido);
			this.m_gbMedidas.Controls.Add(this.m_lbPesoLiquido);
			this.m_gbMedidas.Controls.Add(this.m_btUnidadeVolume);
			this.m_gbMedidas.Controls.Add(this.m_btUnidadeComprimento);
			this.m_gbMedidas.Controls.Add(this.m_btUnidadeLargura);
			this.m_gbMedidas.Controls.Add(this.m_btUnidadeAltura);
			this.m_gbMedidas.Controls.Add(this.m_txtVolume);
			this.m_gbMedidas.Controls.Add(this.m_txtComprimento);
			this.m_gbMedidas.Controls.Add(this.m_txtLargura);
			this.m_gbMedidas.Controls.Add(this.m_txtAltura);
			this.m_gbMedidas.Controls.Add(this.m_lbVolume);
			this.m_gbMedidas.Controls.Add(this.m_lbLargura);
			this.m_gbMedidas.Controls.Add(this.m_lbComprimento);
			this.m_gbMedidas.Controls.Add(this.m_lbAltura);
			this.m_gbMedidas.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbMedidas.Location = new System.Drawing.Point(6, 208);
			this.m_gbMedidas.Name = "m_gbMedidas";
			this.m_gbMedidas.Size = new System.Drawing.Size(273, 165);
			this.m_gbMedidas.TabIndex = 6;
			this.m_gbMedidas.TabStop = false;
			this.m_gbMedidas.Text = "Medidas";
			// 
			// m_btEditarPesoBruto
			// 
			this.m_btEditarPesoBruto.BackColor = System.Drawing.SystemColors.Control;
			this.m_btEditarPesoBruto.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btEditarPesoBruto.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btEditarPesoBruto.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btEditarPesoBruto.Image = ((System.Drawing.Image)(resources.GetObject("m_btEditarPesoBruto.Image")));
			this.m_btEditarPesoBruto.Location = new System.Drawing.Point(242, 134);
			this.m_btEditarPesoBruto.Name = "m_btEditarPesoBruto";
			this.m_btEditarPesoBruto.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btEditarPesoBruto.Size = new System.Drawing.Size(22, 22);
			this.m_btEditarPesoBruto.TabIndex = 27;
			this.m_btEditarPesoBruto.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDica.SetToolTip(this.m_btEditarPesoBruto, "Preenchimento fácil dos pesos brutos das embalagens");
			this.m_btEditarPesoBruto.Click += new System.EventHandler(this.m_btEditarPesoBruto_Click);
			// 
			// m_btEditarPesoLiquido
			// 
			this.m_btEditarPesoLiquido.BackColor = System.Drawing.SystemColors.Control;
			this.m_btEditarPesoLiquido.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btEditarPesoLiquido.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btEditarPesoLiquido.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btEditarPesoLiquido.Image = ((System.Drawing.Image)(resources.GetObject("m_btEditarPesoLiquido.Image")));
			this.m_btEditarPesoLiquido.Location = new System.Drawing.Point(242, 110);
			this.m_btEditarPesoLiquido.Name = "m_btEditarPesoLiquido";
			this.m_btEditarPesoLiquido.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btEditarPesoLiquido.Size = new System.Drawing.Size(22, 22);
			this.m_btEditarPesoLiquido.TabIndex = 26;
			this.m_btEditarPesoLiquido.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDica.SetToolTip(this.m_btEditarPesoLiquido, "Preenchimento fácil dos pesos liquidos das embalagens");
			this.m_btEditarPesoLiquido.Click += new System.EventHandler(this.m_btEditarPesoLiquido_Click);
			// 
			// m_btEditarVolume
			// 
			this.m_btEditarVolume.BackColor = System.Drawing.SystemColors.Control;
			this.m_btEditarVolume.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btEditarVolume.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btEditarVolume.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btEditarVolume.Image = ((System.Drawing.Image)(resources.GetObject("m_btEditarVolume.Image")));
			this.m_btEditarVolume.Location = new System.Drawing.Point(242, 86);
			this.m_btEditarVolume.Name = "m_btEditarVolume";
			this.m_btEditarVolume.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btEditarVolume.Size = new System.Drawing.Size(22, 22);
			this.m_btEditarVolume.TabIndex = 25;
			this.m_btEditarVolume.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDica.SetToolTip(this.m_btEditarVolume, "Preenchimento fácil dos volumes cúbicos das embalagens");
			this.m_btEditarVolume.Click += new System.EventHandler(this.m_btEditarVolume_Click);
			// 
			// m_btEditarComprimento
			// 
			this.m_btEditarComprimento.BackColor = System.Drawing.SystemColors.Control;
			this.m_btEditarComprimento.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btEditarComprimento.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btEditarComprimento.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btEditarComprimento.Image = ((System.Drawing.Image)(resources.GetObject("m_btEditarComprimento.Image")));
			this.m_btEditarComprimento.Location = new System.Drawing.Point(243, 63);
			this.m_btEditarComprimento.Name = "m_btEditarComprimento";
			this.m_btEditarComprimento.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btEditarComprimento.Size = new System.Drawing.Size(22, 22);
			this.m_btEditarComprimento.TabIndex = 24;
			this.m_btEditarComprimento.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDica.SetToolTip(this.m_btEditarComprimento, "Preenchimento fácil dos comprimentos das embalagens");
			this.m_btEditarComprimento.Click += new System.EventHandler(this.m_btEditarComprimento_Click);
			// 
			// m_btEditarLargura
			// 
			this.m_btEditarLargura.BackColor = System.Drawing.SystemColors.Control;
			this.m_btEditarLargura.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btEditarLargura.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btEditarLargura.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btEditarLargura.Image = ((System.Drawing.Image)(resources.GetObject("m_btEditarLargura.Image")));
			this.m_btEditarLargura.Location = new System.Drawing.Point(243, 39);
			this.m_btEditarLargura.Name = "m_btEditarLargura";
			this.m_btEditarLargura.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btEditarLargura.Size = new System.Drawing.Size(22, 22);
			this.m_btEditarLargura.TabIndex = 23;
			this.m_btEditarLargura.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDica.SetToolTip(this.m_btEditarLargura, "Preenchimento fácil das larguras das embalagens");
			this.m_btEditarLargura.Click += new System.EventHandler(this.m_btEditarLargura_Click);
			// 
			// m_btEditarAltura
			// 
			this.m_btEditarAltura.BackColor = System.Drawing.SystemColors.Control;
			this.m_btEditarAltura.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btEditarAltura.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btEditarAltura.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btEditarAltura.Image = ((System.Drawing.Image)(resources.GetObject("m_btEditarAltura.Image")));
			this.m_btEditarAltura.Location = new System.Drawing.Point(243, 15);
			this.m_btEditarAltura.Name = "m_btEditarAltura";
			this.m_btEditarAltura.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btEditarAltura.Size = new System.Drawing.Size(22, 22);
			this.m_btEditarAltura.TabIndex = 22;
			this.m_btEditarAltura.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDica.SetToolTip(this.m_btEditarAltura, "Preenchimento fácil das alturas das embalagens");
			this.m_btEditarAltura.Click += new System.EventHandler(this.m_btEditarAltura_Click);
			// 
			// m_btUnidadePesoBruto
			// 
			this.m_btUnidadePesoBruto.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btUnidadePesoBruto.Location = new System.Drawing.Point(204, 132);
			this.m_btUnidadePesoBruto.Name = "m_btUnidadePesoBruto";
			this.m_btUnidadePesoBruto.Size = new System.Drawing.Size(37, 24);
			this.m_btUnidadePesoBruto.TabIndex = 21;
			this.m_btUnidadePesoBruto.Text = "Kg";
			this.m_ttDica.SetToolTip(this.m_btUnidadePesoBruto, "Troca a unidade do peso bruto");
			this.m_btUnidadePesoBruto.Click += new System.EventHandler(this.m_btUnidadePesoBruto_Click);
			// 
			// m_txtPesoBruto
			// 
			this.m_txtPesoBruto.Location = new System.Drawing.Point(89, 131);
			this.m_txtPesoBruto.Name = "m_txtPesoBruto";
			this.m_txtPesoBruto.Size = new System.Drawing.Size(111, 20);
			this.m_txtPesoBruto.TabIndex = 12;
			this.m_txtPesoBruto.Text = "";
			// 
			// m_lbPesoBruto
			// 
			this.m_lbPesoBruto.Location = new System.Drawing.Point(8, 136);
			this.m_lbPesoBruto.Name = "m_lbPesoBruto";
			this.m_lbPesoBruto.Size = new System.Drawing.Size(80, 16);
			this.m_lbPesoBruto.TabIndex = 19;
			this.m_lbPesoBruto.Text = "Peso Bruto:";
			// 
			// m_btUnidadePesoLiquido
			// 
			this.m_btUnidadePesoLiquido.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btUnidadePesoLiquido.Location = new System.Drawing.Point(204, 109);
			this.m_btUnidadePesoLiquido.Name = "m_btUnidadePesoLiquido";
			this.m_btUnidadePesoLiquido.Size = new System.Drawing.Size(37, 24);
			this.m_btUnidadePesoLiquido.TabIndex = 18;
			this.m_btUnidadePesoLiquido.Text = "Kg";
			this.m_ttDica.SetToolTip(this.m_btUnidadePesoLiquido, "Troca a unidade do peso líquido");
			this.m_btUnidadePesoLiquido.Click += new System.EventHandler(this.m_btUnidadePesoLiquido_Click);
			// 
			// m_txtPesoLiquido
			// 
			this.m_txtPesoLiquido.Location = new System.Drawing.Point(89, 108);
			this.m_txtPesoLiquido.Name = "m_txtPesoLiquido";
			this.m_txtPesoLiquido.Size = new System.Drawing.Size(111, 20);
			this.m_txtPesoLiquido.TabIndex = 11;
			this.m_txtPesoLiquido.Text = "";
			// 
			// m_lbPesoLiquido
			// 
			this.m_lbPesoLiquido.Location = new System.Drawing.Point(8, 113);
			this.m_lbPesoLiquido.Name = "m_lbPesoLiquido";
			this.m_lbPesoLiquido.Size = new System.Drawing.Size(80, 16);
			this.m_lbPesoLiquido.TabIndex = 16;
			this.m_lbPesoLiquido.Text = "Peso Liquido:";
			// 
			// m_btUnidadeVolume
			// 
			this.m_btUnidadeVolume.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btUnidadeVolume.Location = new System.Drawing.Point(205, 86);
			this.m_btUnidadeVolume.Name = "m_btUnidadeVolume";
			this.m_btUnidadeVolume.Size = new System.Drawing.Size(37, 24);
			this.m_btUnidadeVolume.TabIndex = 15;
			this.m_btUnidadeVolume.Text = "m3";
			this.m_ttDica.SetToolTip(this.m_btUnidadeVolume, "Troca a unidade do volume cúbico");
			this.m_btUnidadeVolume.Click += new System.EventHandler(this.m_btUnidadeVolume_Click);
			// 
			// m_btUnidadeComprimento
			// 
			this.m_btUnidadeComprimento.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btUnidadeComprimento.Location = new System.Drawing.Point(205, 62);
			this.m_btUnidadeComprimento.Name = "m_btUnidadeComprimento";
			this.m_btUnidadeComprimento.Size = new System.Drawing.Size(37, 24);
			this.m_btUnidadeComprimento.TabIndex = 14;
			this.m_btUnidadeComprimento.Text = "cm";
			this.m_ttDica.SetToolTip(this.m_btUnidadeComprimento, "Troca a unidade do comprimento");
			this.m_btUnidadeComprimento.Click += new System.EventHandler(this.m_btUnidadeComprimento_Click);
			// 
			// m_btUnidadeLargura
			// 
			this.m_btUnidadeLargura.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btUnidadeLargura.Location = new System.Drawing.Point(205, 38);
			this.m_btUnidadeLargura.Name = "m_btUnidadeLargura";
			this.m_btUnidadeLargura.Size = new System.Drawing.Size(37, 24);
			this.m_btUnidadeLargura.TabIndex = 13;
			this.m_btUnidadeLargura.Text = "cm";
			this.m_ttDica.SetToolTip(this.m_btUnidadeLargura, "Troca a unidade da largura");
			this.m_btUnidadeLargura.Click += new System.EventHandler(this.m_btUnidadeLargura_Click);
			// 
			// m_btUnidadeAltura
			// 
			this.m_btUnidadeAltura.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btUnidadeAltura.Location = new System.Drawing.Point(205, 14);
			this.m_btUnidadeAltura.Name = "m_btUnidadeAltura";
			this.m_btUnidadeAltura.Size = new System.Drawing.Size(37, 24);
			this.m_btUnidadeAltura.TabIndex = 12;
			this.m_btUnidadeAltura.Text = "cm";
			this.m_ttDica.SetToolTip(this.m_btUnidadeAltura, "Troca a unidade da altura");
			this.m_btUnidadeAltura.Click += new System.EventHandler(this.m_btUnidadeAltura_Click);
			// 
			// m_txtVolume
			// 
			this.m_txtVolume.Location = new System.Drawing.Point(89, 85);
			this.m_txtVolume.Name = "m_txtVolume";
			this.m_txtVolume.Size = new System.Drawing.Size(111, 20);
			this.m_txtVolume.TabIndex = 10;
			this.m_txtVolume.Text = "";
			// 
			// m_txtComprimento
			// 
			this.m_txtComprimento.Location = new System.Drawing.Point(89, 62);
			this.m_txtComprimento.Name = "m_txtComprimento";
			this.m_txtComprimento.Size = new System.Drawing.Size(111, 20);
			this.m_txtComprimento.TabIndex = 9;
			this.m_txtComprimento.Text = "";
			this.m_txtComprimento.TextChanged += new System.EventHandler(this.m_txtComprimento_TextChanged);
			// 
			// m_txtLargura
			// 
			this.m_txtLargura.Location = new System.Drawing.Point(89, 39);
			this.m_txtLargura.Name = "m_txtLargura";
			this.m_txtLargura.Size = new System.Drawing.Size(111, 20);
			this.m_txtLargura.TabIndex = 8;
			this.m_txtLargura.Text = "";
			this.m_txtLargura.TextChanged += new System.EventHandler(this.m_txtLargura_TextChanged);
			// 
			// m_txtAltura
			// 
			this.m_txtAltura.Location = new System.Drawing.Point(89, 16);
			this.m_txtAltura.Name = "m_txtAltura";
			this.m_txtAltura.Size = new System.Drawing.Size(111, 20);
			this.m_txtAltura.TabIndex = 7;
			this.m_txtAltura.Text = "";
			this.m_txtAltura.TextChanged += new System.EventHandler(this.m_txtAltura_TextChanged);
			// 
			// m_lbVolume
			// 
			this.m_lbVolume.Location = new System.Drawing.Point(8, 90);
			this.m_lbVolume.Name = "m_lbVolume";
			this.m_lbVolume.Size = new System.Drawing.Size(72, 16);
			this.m_lbVolume.TabIndex = 4;
			this.m_lbVolume.Text = "Volume cub:";
			// 
			// m_lbLargura
			// 
			this.m_lbLargura.Location = new System.Drawing.Point(8, 44);
			this.m_lbLargura.Name = "m_lbLargura";
			this.m_lbLargura.Size = new System.Drawing.Size(72, 16);
			this.m_lbLargura.TabIndex = 2;
			this.m_lbLargura.Text = "Largura:";
			// 
			// m_lbComprimento
			// 
			this.m_lbComprimento.Location = new System.Drawing.Point(8, 67);
			this.m_lbComprimento.Name = "m_lbComprimento";
			this.m_lbComprimento.Size = new System.Drawing.Size(80, 16);
			this.m_lbComprimento.TabIndex = 1;
			this.m_lbComprimento.Text = "Comprimento:";
			// 
			// m_lbAltura
			// 
			this.m_lbAltura.Location = new System.Drawing.Point(8, 21);
			this.m_lbAltura.Name = "m_lbAltura";
			this.m_lbAltura.Size = new System.Drawing.Size(72, 16);
			this.m_lbAltura.TabIndex = 0;
			this.m_lbAltura.Text = "Altura:";
			// 
			// m_gbTipo
			// 
			this.m_gbTipo.Controls.Add(this.m_txtTipoPopular);
			this.m_gbTipo.Controls.Add(this.m_lbPE);
			this.m_gbTipo.Controls.Add(this.m_btTipo);
			this.m_gbTipo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbTipo.Location = new System.Drawing.Point(7, 160);
			this.m_gbTipo.Name = "m_gbTipo";
			this.m_gbTipo.Size = new System.Drawing.Size(273, 48);
			this.m_gbTipo.TabIndex = 3;
			this.m_gbTipo.TabStop = false;
			this.m_gbTipo.Text = "Volume";
			// 
			// m_txtTipoPopular
			// 
			this.m_txtTipoPopular.Location = new System.Drawing.Point(104, 18);
			this.m_txtTipoPopular.Name = "m_txtTipoPopular";
			this.m_txtTipoPopular.Size = new System.Drawing.Size(160, 20);
			this.m_txtTipoPopular.TabIndex = 5;
			this.m_txtTipoPopular.Text = "";
			// 
			// m_lbPE
			// 
			this.m_lbPE.Location = new System.Drawing.Point(51, 21);
			this.m_lbPE.Name = "m_lbPE";
			this.m_lbPE.Size = new System.Drawing.Size(53, 16);
			this.m_lbPE.TabIndex = 71;
			this.m_lbPE.Text = "Espécie:";
			// 
			// m_btTipo
			// 
			this.m_btTipo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btTipo.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.m_btTipo.Location = new System.Drawing.Point(15, 17);
			this.m_btTipo.Name = "m_btTipo";
			this.m_btTipo.Size = new System.Drawing.Size(27, 26);
			this.m_btTipo.TabIndex = 4;
			this.m_ttDica.SetToolTip(this.m_btTipo, "Troca o tipo de Volume");
			this.m_btTipo.Click += new System.EventHandler(this.m_btTipo_Click);
			// 
			// m_gbIntervalo
			// 
			this.m_gbIntervalo.Controls.Add(this.m_txtSufixo);
			this.m_gbIntervalo.Controls.Add(this.m_txtPrefixo);
			this.m_gbIntervalo.Controls.Add(this.m_llbIntervalos);
			this.m_gbIntervalo.Controls.Add(this.m_lbInfo);
			this.m_gbIntervalo.Controls.Add(this.m_lbIntervalo);
			this.m_gbIntervalo.Controls.Add(this.m_txtIntervalo);
			this.m_gbIntervalo.Controls.Add(this.m_lbPrefixo);
			this.m_gbIntervalo.Controls.Add(this.m_lbSufixo);
			this.m_gbIntervalo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbIntervalo.Location = new System.Drawing.Point(7, 13);
			this.m_gbIntervalo.Name = "m_gbIntervalo";
			this.m_gbIntervalo.Size = new System.Drawing.Size(273, 147);
			this.m_gbIntervalo.TabIndex = 1;
			this.m_gbIntervalo.TabStop = false;
			this.m_gbIntervalo.Text = "Identificação do(s) Volume(s)";
			// 
			// m_txtSufixo
			// 
			this.m_txtSufixo.Location = new System.Drawing.Point(191, 40);
			this.m_txtSufixo.Name = "m_txtSufixo";
			this.m_txtSufixo.Size = new System.Drawing.Size(72, 20);
			this.m_txtSufixo.TabIndex = 102;
			this.m_txtSufixo.Text = "";
			// 
			// m_txtPrefixo
			// 
			this.m_txtPrefixo.Location = new System.Drawing.Point(64, 40);
			this.m_txtPrefixo.Name = "m_txtPrefixo";
			this.m_txtPrefixo.Size = new System.Drawing.Size(72, 20);
			this.m_txtPrefixo.TabIndex = 100;
			this.m_txtPrefixo.Text = "";
			// 
			// m_llbIntervalos
			// 
			this.m_llbIntervalos.Location = new System.Drawing.Point(41, 112);
			this.m_llbIntervalos.Name = "m_llbIntervalos";
			this.m_llbIntervalos.Size = new System.Drawing.Size(214, 27);
			this.m_llbIntervalos.TabIndex = 99;
			this.m_llbIntervalos.TabStop = true;
			this.m_llbIntervalos.Text = "Clique aqui caso não tenha entendido como montar os intervalos.";
			this.m_llbIntervalos.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_llbIntervalos_LinkClicked);
			// 
			// m_lbInfo
			// 
			this.m_lbInfo.ForeColor = System.Drawing.Color.Red;
			this.m_lbInfo.Location = new System.Drawing.Point(9, 67);
			this.m_lbInfo.Name = "m_lbInfo";
			this.m_lbInfo.Size = new System.Drawing.Size(255, 40);
			this.m_lbInfo.TabIndex = 13;
			this.m_lbInfo.Text = "Separe com ponto-e-vírgula os números e/ou  intervalos de volumes a serem adicion" +
				"ados. Ex.: 1;3;5-12;4";
			// 
			// m_lbIntervalo
			// 
			this.m_lbIntervalo.Location = new System.Drawing.Point(5, 21);
			this.m_lbIntervalo.Name = "m_lbIntervalo";
			this.m_lbIntervalo.Size = new System.Drawing.Size(59, 16);
			this.m_lbIntervalo.TabIndex = 11;
			this.m_lbIntervalo.Text = "Intervalo:";
			// 
			// m_txtIntervalo
			// 
			this.m_txtIntervalo.Location = new System.Drawing.Point(64, 17);
			this.m_txtIntervalo.Name = "m_txtIntervalo";
			this.m_txtIntervalo.Size = new System.Drawing.Size(200, 20);
			this.m_txtIntervalo.TabIndex = 2;
			this.m_txtIntervalo.Text = "";
			this.m_txtIntervalo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtIntervalo_KeyDown);
			// 
			// m_lbPrefixo
			// 
			this.m_lbPrefixo.Location = new System.Drawing.Point(6, 44);
			this.m_lbPrefixo.Name = "m_lbPrefixo";
			this.m_lbPrefixo.Size = new System.Drawing.Size(51, 16);
			this.m_lbPrefixo.TabIndex = 101;
			this.m_lbPrefixo.Text = "Prefixo:";
			// 
			// m_lbSufixo
			// 
			this.m_lbSufixo.Location = new System.Drawing.Point(143, 43);
			this.m_lbSufixo.Name = "m_lbSufixo";
			this.m_lbSufixo.Size = new System.Drawing.Size(51, 16);
			this.m_lbSufixo.TabIndex = 103;
			this.m_lbSufixo.Text = "Sufixo:";
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(84, 376);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 13;
			this.m_ttDica.SetToolTip(this.m_btOk, "Confirmar");
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(148, 376);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 14;
			this.m_ttDica.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_ttDica
			// 
			this.m_ttDica.AutomaticDelay = 100;
			this.m_ttDica.AutoPopDelay = 5000;
			this.m_ttDica.InitialDelay = 100;
			this.m_ttDica.ReshowDelay = 20;
			// 
			// frmFVolumeNovo
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(290, 408);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmFVolumeNovo";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Adicionando Volumes";
			this.Load += new System.EventHandler(this.frmFEmbalagemNova_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbMedidas.ResumeLayout(false);
			this.m_gbTipo.ResumeLayout(false);
			this.m_gbIntervalo.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region ShowDialogUnidade
			private bool ShowDialogUnidade(string strFormText,string strIntervaloVolumes,string strPrefixo,string strSufixo,string strUnidade,ref string strIntervaloUnidade,string strUnidadeMetrica)
			{
				bool bRetorno = false;
				System.Collections.ArrayList arlVolumes,arlUnidades;
				arlVolumes = clsProdutosRomaneio.arlRetornaIntervalo(strIntervaloVolumes,strPrefixo,strSufixo);
				if (arlVolumes != null)
				{
					if (arlVolumes.Count > 0)
					{
						arlUnidades = clsProdutosRomaneio.arlRetornaIntervaloNumerico(strIntervaloUnidade,arlVolumes.Count);
						frmFVolumeNovaUnidade formFUnidade = new frmFVolumeNovaUnidade(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel,arlVolumes,strUnidade,arlUnidades,strUnidadeMetrica);
						formFUnidade.Text = strFormText;
						formFUnidade.ShowDialog();
						if (bRetorno = formFUnidade.m_bModificado)
						{
							formFUnidade.RetornaValores(out arlUnidades);
							strIntervaloUnidade = clsProdutosRomaneio.strRetornaIntervaloNumerico(arlUnidades);
						}
						formFUnidade.Dispose();
						formFUnidade = null;
						m_txtAltura.Focus();
					}else{
						mdlMensagens.clsMensagens.ShowInformation("Siscobras.NET",mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlProdutosRomaneio_frmFVolumeNovo_SetarIntervalo));
					}
				}else{
					mdlMensagens.clsMensagens.ShowInformation("Siscobras.NET",mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlProdutosRomaneio_frmFVolumeNovo_SetarIntervalo));
   				}
				return (bRetorno);
			}
		#endregion
		#region ShowDialogInformacoesIntervalo
			private void ShowDialogInformacoesIntervalo()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				frmFVolumeNovoInformacaoIntervalo formFInformacoesIntervalo = new frmFVolumeNovoInformacaoIntervalo(m_strEnderecoExecutavel);
				formFInformacoesIntervalo.ShowDialog();
				string strInvervalo = "";
				string strPrefixo = "";
				string strSufixo = "";
				formFInformacoesIntervalo.vRetornaValores(out strInvervalo,out strPrefixo,out strSufixo);
				m_txtIntervalo.Text = strInvervalo;
				m_txtPrefixo.Text = strPrefixo;
				m_txtSufixo.Text = strSufixo;
				formFInformacoesIntervalo = null;
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFEmbalagemNova_Load(object sender, System.EventArgs e)
				{
					MostraCor();
					OnCallCarregaDadosInterfaceVolumeTipo();
				}
			#endregion
			#region Botoes
				private void m_btTipo_Click(object sender, System.EventArgs e)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					OnCallShowDialogVolumeTipo();
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}

				private void m_btUnidadeAltura_Click(object sender, System.EventArgs e)
				{
					TrocarUnidadeMedidaAltura();
					while ( m_enumUnidadeAltura != m_enumUnidadeLargura)
						TrocarUnidadeMedidaLargura();
					while (m_enumUnidadeLargura != m_enumUnidadeComprimento)
						TrocarUnidadeMedidaComprimento();
					while (m_enumUnidadeComprimento != m_enumUnidadeVolume)
						TrocarUnidadeMedidaVolume();
					vRefreshVolumeCubico();
				}

				private void m_btUnidadeLargura_Click(object sender, System.EventArgs e)
				{
					TrocarUnidadeMedidaLargura();
					while (m_enumUnidadeLargura != m_enumUnidadeComprimento)
						TrocarUnidadeMedidaComprimento();
					while (m_enumUnidadeComprimento != m_enumUnidadeVolume)
						TrocarUnidadeMedidaVolume();
					vRefreshVolumeCubico();
				}

				private void m_btUnidadeComprimento_Click(object sender, System.EventArgs e)
				{
					TrocarUnidadeMedidaComprimento();
					while (m_enumUnidadeComprimento != m_enumUnidadeVolume)
						TrocarUnidadeMedidaVolume();
					vRefreshVolumeCubico();
				}

				private void m_btUnidadeVolume_Click(object sender, System.EventArgs e)
				{
					TrocarUnidadeMedidaVolume();
					vRefreshVolumeCubico();
				}

				private void m_btUnidadePesoLiquido_Click(object sender, System.EventArgs e)
				{
					TrocarUnidadePesoLiquido();
					while (m_nUnidadeMassaPesoLiquido != m_nUnidadeMassaPesoBruto)
						TrocarUnidadePesoBruto();
				}

				private void m_btUnidadePesoBruto_Click(object sender, System.EventArgs e)
				{
					TrocarUnidadePesoBruto();
				}

				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					System.Collections.ArrayList arlVolumes = clsProdutosRomaneio.arlRetornaIntervalo(m_txtIntervalo.Text,m_txtPrefixo.Text,m_txtSufixo.Text);
					if (arlVolumes != null)
					{
						System.Collections.ArrayList arlAltura = clsProdutosRomaneio.arlRetornaIntervaloNumerico(m_txtAltura.Text,arlVolumes.Count);
						System.Collections.ArrayList arlLargura = clsProdutosRomaneio.arlRetornaIntervaloNumerico(m_txtLargura.Text,arlVolumes.Count);
						System.Collections.ArrayList arlComprimento = clsProdutosRomaneio.arlRetornaIntervaloNumerico(m_txtComprimento.Text,arlVolumes.Count);
						System.Collections.ArrayList arlVolume = clsProdutosRomaneio.arlRetornaIntervaloNumerico(m_txtVolume.Text,arlVolumes.Count);
						System.Collections.ArrayList arlPesoLiquido = clsProdutosRomaneio.arlRetornaIntervaloNumerico(m_txtPesoLiquido.Text,arlVolumes.Count);
						System.Collections.ArrayList arlPesoBruto = clsProdutosRomaneio.arlRetornaIntervaloNumerico(m_txtPesoBruto.Text,arlVolumes.Count);
						if (OnCallVolumesInexistentes(ref arlVolumes))
						{
							if (m_nIdVolumeTipo != -1)
							{
								if ((arlAltura == null) && (m_txtAltura.Text.Trim() != ""))
								{
									mdlMensagens.clsMensagens.ShowInformation("Siscobras.NET",mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlProdutosRomaneio_frmFVolumeNovo_AlturaInvalida));
								}
								else
								{
									if ((arlLargura == null) && (m_txtLargura.Text.Trim() != "") )
									{
										mdlMensagens.clsMensagens.ShowInformation("Siscobras.NET",mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlProdutosRomaneio_frmFVolumeNovo_LarguraInvalida));
									}
									else
									{
										if ((arlComprimento == null) && (m_txtComprimento.Text.Trim() != "") )
										{
											mdlMensagens.clsMensagens.ShowInformation("Siscobras.NET",mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlProdutosRomaneio_frmFVolumeNovo_ComprimentoInvalido));
										}
										else
										{
											if ((arlVolume == null) && (m_txtVolume.Text.Trim() != ""))
											{
												mdlMensagens.clsMensagens.ShowInformation("Siscobras.NET",mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlProdutosRomaneio_frmFVolumeNovo_VolumeInvalido));
											}
											else
											{
												if ((arlPesoLiquido == null) && (m_txtPesoLiquido.Text.Trim() != ""))
												{
													mdlMensagens.clsMensagens.ShowInformation("Siscobras.NET",mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlProdutosRomaneio_frmFVolumeNovo_PesoLiquidoInvalido));
												}
												else
												{
													if ((arlPesoBruto == null) && (m_txtPesoBruto.Text.Trim() != ""))
													{
														mdlMensagens.clsMensagens.ShowInformation("Siscobras.NET",mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlProdutosRomaneio_frmFVolumeNovo_PesoBrutoInvalido));
													}
													else
													{
														m_strDescricaoPopular = m_txtTipoPopular.Text;
														m_arlVolumes = arlVolumes;
														m_arlAltura = arlAltura;
														m_arlLargura = arlLargura;
														m_arlComprimento = arlComprimento;
														m_arlVolume = arlVolume;
														m_arlPesoLiquido = arlPesoLiquido;
														m_arlPesoBruto = arlPesoBruto;
														m_bModificado = true;
														this.Close();
													}
												}
											}
										}
									}
								}
							}else{
								mdlMensagens.clsMensagens.ShowInformation("Siscobras",mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlProdutosRomaneio_frmFVolumeNovo_EscolhaTipoVolume));
							}
						}else{
							mdlMensagens.clsMensagens.ShowInformation("Siscobras",mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlProdutosRomaneio_frmFVolumeNovo_EmbalagemDuplicada));
						}
					}else{
						mdlMensagens.clsMensagens.ShowInformation("Siscobras",mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlProdutosRomaneio_frmFVolumeNovo_IntervaloInvalido));
					}
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}

				private void m_btCancelar_Click(object sender, System.EventArgs e)
				{
					m_bModificado = false;
					this.Close();
				}
			#endregion
			#region TextBoxes
				private void m_txtIntervalo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
				{
					switch(e.KeyCode)
					{
						case System.Windows.Forms.Keys.Enter:
						case System.Windows.Forms.Keys.Tab:
							if (m_nIdVolumeTipo == -1)
							{
								this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
								OnCallShowDialogVolumeTipo();
								this.Cursor = System.Windows.Forms.Cursors.Default;
							}
							break;
					}
				}

				private void m_txtAltura_TextChanged(object sender, System.EventArgs e)
				{
					vRefreshVolumeCubico();
				}

				private void m_txtLargura_TextChanged(object sender, System.EventArgs e)
				{
					vRefreshVolumeCubico();
				}

				private void m_txtComprimento_TextChanged(object sender, System.EventArgs e)
				{
					vRefreshVolumeCubico();
				}
			#endregion
			#region LinkLabels
				private void m_llbIntervalos_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
				{
					ShowDialogInformacoesIntervalo();
				}
			#endregion
		#endregion
		#region Cores Formulario
			private void MostraCor()
			{
				try
				{
					mdlPaletaDeCores.clsPaletaDeCores clsPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini","SiscobrasCorSecundaria");
					this.BackColor = clsPaletaCores.retornaCorAtual();
					for (int nCont = 0 ;nCont < this.Controls.Count; nCont++)
					{
						this.Controls[nCont].BackColor = this.BackColor;
						for (int nCont2 = 0 ;nCont2 < this.Controls[nCont].Controls.Count; nCont2++)
						{
							if ((this.Controls[nCont].Controls[nCont2].GetType().ToString() != "mdlComponentesGraficos.TextBox") && (this.Controls[nCont].Controls[nCont2].GetType().ToString() != "mdlComponentesGraficos.TreeView"))
								this.Controls[nCont].Controls[nCont2].BackColor = this.BackColor;

							for (int nCont3 = 0 ;nCont3 < this.Controls[nCont].Controls[nCont2].Controls.Count; nCont3++)
							{
								if ((this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "mdlComponentesGraficos.TextBox") && (this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "mdlComponentesGraficos.TreeView"))
									this.Controls[nCont].Controls[nCont2].Controls[nCont3].BackColor = this.BackColor;
							}
						}
					}
				}
				catch (Exception erro)
				{
					Object err = (Object)erro;
					m_cls_ter_tratadorErro.trataErro(ref err);
				}
			}
		#endregion

		#region Unidades
			#region MostrarUnidades
				private void MostraUnidades()
				{
					MostraUnidadeAltura();
					MostraUnidadeLargura();
					MostraUnidadeComprimento();
					MostraUnidadeVolume();
					MostraUnidadePesoLiquido();
					MostraUnidadePesoBruto();
				}

				private void MostraUnidadeAltura()
				{
					string strUnidade = "";
					// Adquirindo a String da Unidade
					switch(m_enumUnidadeAltura)
					{
						case mdlProdutosRomaneio.UnidadeMedida.Centimetro:
							strUnidade = TEXTO_UNIDADE_MEDIDA_CM;
							break;
						case mdlProdutosRomaneio.UnidadeMedida.Metro:
							strUnidade = TEXTO_UNIDADE_MEDIDA_M;
							break;
					}
					// Inserindo a Unidade
					this.m_btUnidadeAltura.Text = strUnidade;
				}

				private void MostraUnidadeLargura()
				{
					string strUnidade = "";
					// Adquirindo a String da Unidade
					switch(m_enumUnidadeLargura)
					{
						case mdlProdutosRomaneio.UnidadeMedida.Centimetro:
							strUnidade = TEXTO_UNIDADE_MEDIDA_CM;
							break;
						case mdlProdutosRomaneio.UnidadeMedida.Metro:
							strUnidade = TEXTO_UNIDADE_MEDIDA_M;
							break;
					}
					// Inserindo a Unidade
					this.m_btUnidadeLargura.Text = strUnidade;
				}

				private void MostraUnidadeComprimento()
				{
					string strUnidade = "";
					// Adquirindo a String da Unidade
					switch(m_enumUnidadeComprimento)
					{
						case mdlProdutosRomaneio.UnidadeMedida.Centimetro:
							strUnidade = TEXTO_UNIDADE_MEDIDA_CM;
							break;
						case mdlProdutosRomaneio.UnidadeMedida.Metro:
							strUnidade = TEXTO_UNIDADE_MEDIDA_M;
							break;
					}
					// Inserindo a Unidade
					this.m_btUnidadeComprimento.Text = strUnidade;
				}

				private void MostraUnidadeVolume()
				{
					string strUnidade = "";
					// Adquirindo a String da Unidade
					switch(m_enumUnidadeVolume)
					{
						case mdlProdutosRomaneio.UnidadeMedida.Centimetro:
							strUnidade = TEXTO_UNIDADE_MEDIDA_CM3;
							break;
						case mdlProdutosRomaneio.UnidadeMedida.Metro:
							strUnidade = TEXTO_UNIDADE_MEDIDA_M3;
							break;
					}
					// Inserindo a Unidade
					this.m_btUnidadeVolume.Text = strUnidade;
				}

				private void MostraUnidadePesoLiquido()
				{
					string strUnidade = "";
					strUnidade = OnCallRetornaSiglaUnidadeMassa(m_nUnidadeMassaPesoLiquido);
					this.m_btUnidadePesoLiquido.Text = strUnidade;
				}

				private void MostraUnidadePesoBruto()
				{
					string strUnidade = "";
					strUnidade = OnCallRetornaSiglaUnidadeMassa(m_nUnidadeMassaPesoBruto);					
					this.m_btUnidadePesoBruto.Text = strUnidade;
				}
			#endregion
			#region TrocarUnidades
				private void TrocarUnidadeMedidaAltura()
				{
					switch(m_enumUnidadeAltura)
					{
						case mdlProdutosRomaneio.UnidadeMedida.Centimetro:
							m_enumUnidadeAltura = mdlProdutosRomaneio.UnidadeMedida.Metro;
							break;
						case mdlProdutosRomaneio.UnidadeMedida.Metro:
							m_enumUnidadeAltura = mdlProdutosRomaneio.UnidadeMedida.Centimetro;
							break;
					}
					MostraUnidadeAltura();
				}

				private void TrocarUnidadeMedidaLargura()
				{
					switch(m_enumUnidadeLargura)
					{
						case mdlProdutosRomaneio.UnidadeMedida.Centimetro:
							m_enumUnidadeLargura = mdlProdutosRomaneio.UnidadeMedida.Metro;
							break;
						case mdlProdutosRomaneio.UnidadeMedida.Metro:
							m_enumUnidadeLargura = mdlProdutosRomaneio.UnidadeMedida.Centimetro;
							break;
					}
					MostraUnidadeLargura();
				}

				private void TrocarUnidadeMedidaComprimento()
				{
					switch(m_enumUnidadeComprimento)
					{
						case mdlProdutosRomaneio.UnidadeMedida.Centimetro:
							m_enumUnidadeComprimento = mdlProdutosRomaneio.UnidadeMedida.Metro;
							break;
						case mdlProdutosRomaneio.UnidadeMedida.Metro:
							m_enumUnidadeComprimento = mdlProdutosRomaneio.UnidadeMedida.Centimetro;
							break;
					}
					MostraUnidadeComprimento();
				}

				private void TrocarUnidadeMedidaVolume()
				{
					switch(m_enumUnidadeVolume)
					{
						case mdlProdutosRomaneio.UnidadeMedida.Centimetro:
							m_enumUnidadeVolume = mdlProdutosRomaneio.UnidadeMedida.Metro;
							break;
						case mdlProdutosRomaneio.UnidadeMedida.Metro:
							m_enumUnidadeVolume = mdlProdutosRomaneio.UnidadeMedida.Centimetro;
							break;
					}
					MostraUnidadeVolume();
				}

				private void TrocarUnidadePesoLiquido()
				{
					m_nUnidadeMassaPesoLiquido = clsProdutosRomaneio.nRetornaProximaUnidadeMassa(m_nUnidadeMassaPesoLiquido);
					MostraUnidadePesoLiquido();
				}

				private void TrocarUnidadePesoBruto()
				{
					m_nUnidadeMassaPesoBruto = clsProdutosRomaneio.nRetornaProximaUnidadeMassa(m_nUnidadeMassaPesoBruto);				
					MostraUnidadePesoBruto();
				}

			#endregion
		#endregion
		#region EdicaoUnidadesMedidasEPesos
			private void m_btEditarAltura_Click(object sender, System.EventArgs e)
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				string strIntervaloUnidade = m_txtAltura.Text;
				if (ShowDialogUnidade("Altura",m_txtIntervalo.Text,m_txtPrefixo.Text,m_txtSufixo.Text,"Altura",ref strIntervaloUnidade,m_btUnidadeAltura.Text))
				{
					m_txtAltura.Text = strIntervaloUnidade;
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			private void m_btEditarLargura_Click(object sender, System.EventArgs e)
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				string strIntervaloUnidade = m_txtLargura.Text;
				if (ShowDialogUnidade("Largura",m_txtIntervalo.Text,m_txtPrefixo.Text,m_txtSufixo.Text,"Largura",ref strIntervaloUnidade,m_btUnidadeLargura.Text))
				{
					m_txtLargura.Text = strIntervaloUnidade;
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			private void m_btEditarComprimento_Click(object sender, System.EventArgs e)
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				string strIntervaloUnidade = m_txtComprimento.Text;
				if (ShowDialogUnidade("Comprimento",m_txtIntervalo.Text,m_txtPrefixo.Text,m_txtSufixo.Text,"Comprimento",ref strIntervaloUnidade,m_btUnidadeComprimento.Text))
				{
					m_txtComprimento.Text = strIntervaloUnidade;
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			private void m_btEditarVolume_Click(object sender, System.EventArgs e)
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				string strIntervaloUnidade = m_txtVolume.Text;
				if (ShowDialogUnidade("Volume",m_txtIntervalo.Text,m_txtPrefixo.Text,m_txtSufixo.Text,"Volume",ref strIntervaloUnidade,m_btUnidadeVolume.Text))
				{
					m_txtVolume.Text = strIntervaloUnidade;
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			private void m_btEditarPesoLiquido_Click(object sender, System.EventArgs e)
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				string strIntervaloUnidade = m_txtPesoLiquido.Text;
				if (ShowDialogUnidade("Peso Líquido",m_txtIntervalo.Text,m_txtPrefixo.Text,m_txtSufixo.Text,"Peso Liquido",ref strIntervaloUnidade,m_btUnidadePesoLiquido.Text))
				{
					m_txtPesoLiquido.Text = strIntervaloUnidade;
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			private void m_btEditarPesoBruto_Click(object sender, System.EventArgs e)
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				string strIntervaloUnidade = m_txtPesoBruto.Text;
				if (ShowDialogUnidade("Peso Bruto",m_txtIntervalo.Text,m_txtPrefixo.Text,m_txtSufixo.Text,"Peso Bruto",ref strIntervaloUnidade,m_btUnidadePesoBruto.Text))
				{
					m_txtPesoBruto.Text = strIntervaloUnidade;
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}
		#endregion
		#region Refresh
			private void vRefreshVolumeCubico()
			{
				double dAltura = 0,dLargura = 0,dComprimento = 0;
				try
				{
					dAltura = double.Parse(m_txtAltura.Text);
				}catch{
				}
				try
				{
					dLargura = double.Parse(m_txtLargura.Text);
				}
				catch
				{
				}
				try
				{
					dComprimento = double.Parse(m_txtComprimento.Text);
				}
				catch
				{
				}
				if ((dAltura != 0) && (dLargura != 0) && (dComprimento != 0))
				{
					if (((int)m_enumUnidadeVolume) != ((int)m_enumUnidadeAltura))
						dAltura = dAltura * (clsProdutosRomaneio.dRetornaFatorConversaoEntreUnidadesEspaco(((int)m_enumUnidadeAltura),((int)m_enumUnidadeVolume)));
					if (((int)m_enumUnidadeVolume) != ((int)m_enumUnidadeLargura))
						dLargura = dLargura * (clsProdutosRomaneio.dRetornaFatorConversaoEntreUnidadesEspaco(((int)m_enumUnidadeLargura),((int)m_enumUnidadeVolume)));
					if (((int)m_enumUnidadeVolume) != ((int)m_enumUnidadeComprimento))
						dComprimento = dComprimento * (clsProdutosRomaneio.dRetornaFatorConversaoEntreUnidadesEspaco(((int)m_enumUnidadeComprimento),((int)m_enumUnidadeVolume)));
					m_txtVolume.Text = (dAltura * dLargura * dComprimento).ToString();
				}
			}
		#endregion

		#region Retorno
			public void RetornaValores(out System.Collections.ArrayList arlVolumes,out int nIdEmbalagemTipo,out string strDescricaoPopular,out System.Collections.ArrayList arlAltura, out System.Collections.ArrayList arlLargura, out System.Collections.ArrayList arlComprimento,out System.Collections.ArrayList arlVolume,out System.Collections.ArrayList arlPesoLiquido,out System.Collections.ArrayList arlPesoBruto,out mdlProdutosRomaneio.UnidadeMedida enumUnidadeAltura,out mdlProdutosRomaneio.UnidadeMedida enumUnidadeLargura,out mdlProdutosRomaneio.UnidadeMedida enumUnidadeComprimento,out mdlProdutosRomaneio.UnidadeMedida enumUnidadeVolume,out int nUnidadeMassaPesoLiquido,out int nUnidadeMassaPesoBruto)
			{
				arlVolumes = m_arlVolumes;
				nIdEmbalagemTipo = m_nIdVolumeTipo;
				strDescricaoPopular = m_strDescricaoPopular;
				arlAltura = m_arlAltura;
				arlLargura = m_arlLargura;
				arlComprimento = m_arlComprimento;
				arlVolume = m_arlVolume;
				arlPesoLiquido = m_arlPesoLiquido;
				arlPesoBruto = m_arlPesoBruto;
				enumUnidadeAltura = m_enumUnidadeAltura;
				enumUnidadeLargura = m_enumUnidadeLargura;
				enumUnidadeComprimento = m_enumUnidadeComprimento;
				enumUnidadeVolume = m_enumUnidadeVolume;
				nUnidadeMassaPesoLiquido = m_nUnidadeMassaPesoLiquido;
				nUnidadeMassaPesoBruto = m_nUnidadeMassaPesoBruto;
			}
		#endregion

	}
}
