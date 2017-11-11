using System;
//using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlProdutosRomaneio
{
	/// <summary>
	/// Summary description for frmFProdutosSimplificadoVincular.
	/// </summary>
	internal class frmFProdutosSimplificadoVincular : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate string delCallRetornaSiglaUnidadeEspaco(int nUnidadeEspaco);
			public delegate string delCallRetornaSiglaUnidadeMassa(int nUnidadeMassa);
			public delegate void delCallCarregaDadosProduto(int nIdOrdemProduto,int nIdOrdemProdutoRomaneio,out string strDescricao,out double dQuantidadeProduto,out double dQuantidadeProdutoMaxima,out string strUnidadeProduto);
			public delegate void delCallCarregaDados(int nIdOrdemProdutoRomaneio,out int nIdTipoVolume,out string strTipoPopular,out double dAltura,out int nUnidadeMetricaAltura,out double dLargura,out int nUnidadeMetricaLargura,out double dComprimento,out int nUnidadeMetricaComprimento,out double dVolumeCubico,out int nUnidadeMetricaVolume,out double dPesoLiquidoUnitario,out int nUnidadeMassaPesoLiquido,out double dPesoBrutoUnitario,out int nUnidadeMassaPesoBruto,out double dQuantidadeVolumes);
			public delegate bool delCallShowDialogVolumeTipo(ref System.Windows.Forms.ImageList ilVolumes,ref int nIdTipoVolume); 
			public delegate void delCallCarregaDadosTipoVolume(int nIdvolumeTipo,out int nIdVolumeImage,out string strDescricao);
			public delegate bool delCallSalvaDados(int nIdOrdemProdutoRomaneio,int nIdOrdemProduto,int nIdTipoVolume,string strTipoPopular,double dAltura,int nUnidadeMetricaAltura,double dLargura,int nUnidadeMetricaLargura,double dComprimento,int nUnidadeMetricaComprimento,double dVolumeCubico,int nUnidadeMetricaVolume,double dPesoLiquidoUnitario,int nUnidadeMassaPesoLiquido,double dPesoBrutoUnitario,int nUnidadeMassaPesoBruto,double dQuantidadeProduto,double dQuantidadeVolumes);
		#endregion
		#region Events
			public event delCallRetornaSiglaUnidadeEspaco eCallRetornaSiglaUnidadeEspaco;
			public event delCallRetornaSiglaUnidadeMassa eCallRetornaSiglaUnidadeMassa;
			public event delCallCarregaDadosProduto eCallCarregaDadosProduto;
			public event delCallCarregaDados eCallCarregaDados;
			public event delCallShowDialogVolumeTipo eCallShowDialogVolumeTipo;
			public event delCallCarregaDadosTipoVolume eCallCarregaDadosTipoVolume;
			public event delCallSalvaDados eCallSalvaDados;
		#endregion
		#region Events Methods
			protected virtual string OnCallRetornaSiglaUnidadeEspaco(int nUnidade)
			{
				string strRetorno = "";
				if (eCallRetornaSiglaUnidadeEspaco!= null)
					strRetorno = eCallRetornaSiglaUnidadeEspaco(nUnidade);
				return(strRetorno);
			}

			protected virtual string OnCallRetornaSiglaUnidadeMassa(int nUnidade)
			{
				string strRetorno = "";
				if (eCallRetornaSiglaUnidadeMassa!= null)
					strRetorno = eCallRetornaSiglaUnidadeMassa(nUnidade);
				return(strRetorno);
			}

			protected virtual void OnCallCarregaDadosProduto()
			{
				if (eCallCarregaDadosProduto!= null)
				{
					string strDescricao = "";
					double dQuantidadeProduto = 0;
					double dQuantidadeProdutoMaxima = 0;
					string strUnidadeProduto = "";
					eCallCarregaDadosProduto(m_nIdOrdemProduto,m_nIdOrdemProdutoRomaneio,out strDescricao,out dQuantidadeProduto,out dQuantidadeProdutoMaxima,out strUnidadeProduto);
					m_txtDescricao.Text = strDescricao;
					m_txtQuantidadeProduto.Text = dQuantidadeProduto.ToString();
					m_dQuantidadeProdutoMaxima = dQuantidadeProdutoMaxima;
					m_lbProdutoUnidade.Text = strUnidadeProduto;
				}
			}

			protected virtual void OnCallCarregaDados()
			{
				if (eCallCarregaDados!= null)
				{
					int nIdTipoVolume = -1;
					string strTipoPopular = "";
					double dAltura = 0;
					double dLargura = 0;
					double dComprimento = 0;
					double dVolumeCubico = 0;
					double dPesoLiquidoUnitario = 0;
					double dPesoBrutoUnitario = 0;
					double dQuantidadeVolumes = 0;
					eCallCarregaDados(m_nIdOrdemProdutoRomaneio,out nIdTipoVolume,out strTipoPopular,out dAltura,out m_nUnidadeMetricaAltura,out dLargura,out m_nUnidadeMetricaLargura,out dComprimento,out m_nUnidadeMetricaComprimento,out dVolumeCubico,out m_nUnidadeMetricaVolume,out dPesoLiquidoUnitario,out m_nUnidadeMassaPesoLiquido,out dPesoBrutoUnitario,out m_nUnidadeMassaPesoBruto,out dQuantidadeVolumes);

					// Volume
					m_nIdTipoVolume = nIdTipoVolume;
					m_txtTipoPopular.Text = strTipoPopular;

					// Medidas
					m_txtAltura.Text = dAltura.ToString();
					m_txtLargura.Text = dLargura.ToString();
					m_txtComprimento.Text = dComprimento.ToString();
					m_txtVolume.Text = dVolumeCubico.ToString();

					// Pesos
					m_txtPesoLiquidoUnitario.Text = dPesoLiquidoUnitario.ToString();
					m_txtPesoBrutoUnitario.Text = dPesoBrutoUnitario.ToString();

					// Quantidades
					m_txtQuantidadeVolumes.Text = dQuantidadeVolumes.ToString();
				}
			}

			protected virtual bool OnCallShowDialogVolumeTipo()
			{
				bool bRetorno = false;
				if (eCallShowDialogVolumeTipo != null)
				{
					bRetorno = eCallShowDialogVolumeTipo(ref m_ilVolumes,ref m_nIdTipoVolume);
				}
				return(bRetorno);
			}

			protected virtual void OnCallCarregaDadosTipoVolume(bool bLoadText)
			{
				if (eCallCarregaDadosTipoVolume != null)
				{
					int nIdImageIndex = 0;
					string strDescricao = "";
					eCallCarregaDadosTipoVolume(m_nIdTipoVolume,out nIdImageIndex,out strDescricao);
					m_btTipo.Image = m_ilVolumes.Images[nIdImageIndex];
					if (bLoadText)
						m_txtTipoPopular.Text = strDescricao;
				}
			}

			protected virtual bool OnCallSalvaDados()
			{
				bool bRetorno = false;
				if (eCallSalvaDados!= null)
				{
					double dAltura = 0,dLargura = 0,dComprimento = 0,dVolumeCubico = 0,dPesoLiquidoUnitario = 0,dPesoBrutoUnitario = 0;
					double dQuantidadeProduto = 0,dQuantidadeVolumes = 0;

					// Altura 
					if (m_txtAltura.Text != "")
						dAltura = double .Parse(m_txtAltura.Text);

					// Largura 
					if (m_txtLargura.Text != "")
						dLargura = double .Parse(m_txtLargura.Text);

					// Comprimento
					if (m_txtComprimento.Text != "")
						dComprimento = double .Parse(m_txtComprimento.Text);

					// Volume 
					if (m_txtVolume.Text != "")
						dVolumeCubico = double .Parse(m_txtVolume.Text);

					// Peso Liquido Unitario
					if (m_txtPesoLiquidoUnitario.Text != "")
						dPesoLiquidoUnitario = double .Parse(m_txtPesoLiquidoUnitario.Text);

					// Peso Bruto Unitario
					if (m_txtPesoBrutoUnitario.Text != "")
						dPesoBrutoUnitario = double .Parse(m_txtPesoBrutoUnitario.Text);

					// Quantidade Produto 
					if (m_txtQuantidadeProduto.Text != "")
						dQuantidadeProduto = double .Parse(m_txtQuantidadeProduto.Text);

					// Quantidade Volumes 
					if (m_txtQuantidadeVolumes.Text != "")
						dQuantidadeVolumes = double .Parse(m_txtQuantidadeVolumes.Text);

					if (dQuantidadeProduto > m_dQuantidadeProdutoMaxima)
					{
						mdlMensagens.clsMensagens.ShowInformation(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlProdutosRomaneio_frmFProdutosSimplificadoVincular_QuantidadeProdutoMaiorMaximoPermitido));
						return(false);
					}
                                       
					bRetorno = eCallSalvaDados(m_nIdOrdemProdutoRomaneio,m_nIdOrdemProduto,m_nIdTipoVolume,m_txtTipoPopular.Text,dAltura,m_nUnidadeMetricaAltura,dLargura,m_nUnidadeMetricaLargura,dComprimento,m_nUnidadeMetricaComprimento,dVolumeCubico,m_nUnidadeMetricaVolume,dPesoLiquidoUnitario,m_nUnidadeMassaPesoLiquido,dPesoBrutoUnitario,m_nUnidadeMassaPesoBruto,dQuantidadeProduto,dQuantidadeVolumes);
				}
				return(bRetorno);
			}
		#endregion

		#region Constants
			private const int MAXDECIMALS = 8;
		#endregion
		#region Atributes
			private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro; 
			private string m_strEnderecoExecutavel;
			private int m_nIdOrdemProduto = -1;
			private int m_nIdOrdemProdutoRomaneio = -1;
			private double m_dQuantidadeProdutoMaxima = 0;

			private int m_nIdTipoVolume = -1;

			private bool m_bDoEvents = true;

			private int m_nUnidadeMetricaAltura = 0;
			private int m_nUnidadeMetricaLargura = 0;
			private int m_nUnidadeMetricaComprimento = 0;
			private int m_nUnidadeMetricaVolume = 0;
			private int m_nUnidadeMassaPesoLiquido = 0;
			private int m_nUnidadeMassaPesoBruto = 0;
		
			public bool m_bModificado = false;

			private System.Windows.Forms.GroupBox m_gbGeral;
			internal System.Windows.Forms.Button m_btOk;
			internal System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.GroupBox m_gbProduto;
			private System.Windows.Forms.Label m_lbDescricao;
			private System.Windows.Forms.TextBox m_txtDescricao;
			private System.Windows.Forms.Label m_lbProduto;
			private mdlComponentesGraficos.TextBox m_txtQuantidadeProduto;
			private System.Windows.Forms.Label m_lbVolumes;
			private System.Windows.Forms.GroupBox m_gbVolumes;
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
			internal System.Windows.Forms.Label m_lbPesoBrutoTotal;
			internal mdlComponentesGraficos.TextBox m_txtPesoBrutoTotal;
			internal mdlComponentesGraficos.TextBox m_txtPesoLiquidoTotal;
			internal System.Windows.Forms.Label m_lbPesoLiquidoTotal;
			internal System.Windows.Forms.Button m_btUnidadePesoLiquidoUnitario;
			internal mdlComponentesGraficos.TextBox m_txtPesoLiquidoUnitario;
			internal System.Windows.Forms.Label m_lbPesoLiquidoUnitario;
			internal System.Windows.Forms.Label m_lbPesoBrutoUnitario;
			internal System.Windows.Forms.Button m_btUnidadePesoBrutoUnitario;
			internal mdlComponentesGraficos.TextBox m_txtPesoBrutoUnitario;
			internal System.Windows.Forms.Button m_btUnidadePesoBrutoTotal;
			internal System.Windows.Forms.Button m_btUnidadePesoLiquidoTotal;
			private mdlComponentesGraficos.TextBox m_txtQuantidadeVolumes;
			internal System.Windows.Forms.ImageList m_ilVolumes;
			private System.Windows.Forms.Label m_lbMult;
			private System.Windows.Forms.Label label1;
			internal mdlComponentesGraficos.TextBox m_txtTipoPopular;
			internal System.Windows.Forms.Label m_lbPE;
			internal System.Windows.Forms.Button m_btTipo;
			private System.Windows.Forms.Label label2;
			private System.Windows.Forms.Label label3;
			private System.Windows.Forms.Label label4;
			private System.Windows.Forms.Label label5;
			private System.Windows.Forms.Label label6;
			private System.Windows.Forms.Label m_lbProdutoUnidade;
			private System.ComponentModel.IContainer components;
		#endregion
		#region Constructors and Destructors
			public frmFProdutosSimplificadoVincular(ref mdlTratamentoErro.clsTratamentoErro TratadorErro, string strEnderecoExecutavel,int nIdOrdemProduto,int nIdOrdemProdutoRomaneio)
			{
				m_cls_ter_tratadorErro = TratadorErro;
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				m_nIdOrdemProduto = nIdOrdemProduto;
				m_nIdOrdemProdutoRomaneio = nIdOrdemProdutoRomaneio;
				InitializeComponent();
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFProdutosSimplificadoVincular));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_gbVolumes = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.m_txtTipoPopular = new mdlComponentesGraficos.TextBox();
			this.m_lbPE = new System.Windows.Forms.Label();
			this.m_btTipo = new System.Windows.Forms.Button();
			this.m_gbMedidas = new System.Windows.Forms.GroupBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
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
			this.m_lbVolumes = new System.Windows.Forms.Label();
			this.m_txtQuantidadeVolumes = new mdlComponentesGraficos.TextBox();
			this.m_txtPesoBrutoUnitario = new mdlComponentesGraficos.TextBox();
			this.m_lbPesoBrutoUnitario = new System.Windows.Forms.Label();
			this.m_txtPesoBrutoTotal = new mdlComponentesGraficos.TextBox();
			this.m_btUnidadePesoBrutoUnitario = new System.Windows.Forms.Button();
			this.m_lbPesoBrutoTotal = new System.Windows.Forms.Label();
			this.m_btUnidadePesoBrutoTotal = new System.Windows.Forms.Button();
			this.m_gbProduto = new System.Windows.Forms.GroupBox();
			this.m_lbProdutoUnidade = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.m_lbMult = new System.Windows.Forms.Label();
			this.m_txtDescricao = new System.Windows.Forms.TextBox();
			this.m_lbDescricao = new System.Windows.Forms.Label();
			this.m_lbProduto = new System.Windows.Forms.Label();
			this.m_txtQuantidadeProduto = new mdlComponentesGraficos.TextBox();
			this.m_lbPesoLiquidoUnitario = new System.Windows.Forms.Label();
			this.m_txtPesoLiquidoUnitario = new mdlComponentesGraficos.TextBox();
			this.m_lbPesoLiquidoTotal = new System.Windows.Forms.Label();
			this.m_btUnidadePesoLiquidoUnitario = new System.Windows.Forms.Button();
			this.m_txtPesoLiquidoTotal = new mdlComponentesGraficos.TextBox();
			this.m_btUnidadePesoLiquidoTotal = new System.Windows.Forms.Button();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_ilVolumes = new System.Windows.Forms.ImageList(this.components);
			this.m_gbGeral.SuspendLayout();
			this.m_gbVolumes.SuspendLayout();
			this.m_gbMedidas.SuspendLayout();
			this.m_gbProduto.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbGeral.Controls.Add(this.m_gbVolumes);
			this.m_gbGeral.Controls.Add(this.m_gbProduto);
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Location = new System.Drawing.Point(5, -2);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(659, 231);
			this.m_gbGeral.TabIndex = 0;
			this.m_gbGeral.TabStop = false;
			// 
			// m_gbVolumes
			// 
			this.m_gbVolumes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbVolumes.Controls.Add(this.label3);
			this.m_gbVolumes.Controls.Add(this.label2);
			this.m_gbVolumes.Controls.Add(this.m_txtTipoPopular);
			this.m_gbVolumes.Controls.Add(this.m_lbPE);
			this.m_gbVolumes.Controls.Add(this.m_btTipo);
			this.m_gbVolumes.Controls.Add(this.m_gbMedidas);
			this.m_gbVolumes.Controls.Add(this.m_lbVolumes);
			this.m_gbVolumes.Controls.Add(this.m_txtQuantidadeVolumes);
			this.m_gbVolumes.Controls.Add(this.m_txtPesoBrutoUnitario);
			this.m_gbVolumes.Controls.Add(this.m_lbPesoBrutoUnitario);
			this.m_gbVolumes.Controls.Add(this.m_txtPesoBrutoTotal);
			this.m_gbVolumes.Controls.Add(this.m_btUnidadePesoBrutoUnitario);
			this.m_gbVolumes.Controls.Add(this.m_lbPesoBrutoTotal);
			this.m_gbVolumes.Controls.Add(this.m_btUnidadePesoBrutoTotal);
			this.m_gbVolumes.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbVolumes.Location = new System.Drawing.Point(4, 72);
			this.m_gbVolumes.Name = "m_gbVolumes";
			this.m_gbVolumes.Size = new System.Drawing.Size(652, 128);
			this.m_gbVolumes.TabIndex = 1;
			this.m_gbVolumes.TabStop = false;
			this.m_gbVolumes.Text = "Volumes";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.label3.Location = new System.Drawing.Point(506, 35);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(16, 16);
			this.label3.TabIndex = 18;
			this.label3.Text = "=";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.label2.Location = new System.Drawing.Point(356, 35);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(16, 16);
			this.label2.TabIndex = 6;
			this.label2.Text = "X";
			// 
			// m_txtTipoPopular
			// 
			this.m_txtTipoPopular.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_txtTipoPopular.Location = new System.Drawing.Point(40, 33);
			this.m_txtTipoPopular.Name = "m_txtTipoPopular";
			this.m_txtTipoPopular.Size = new System.Drawing.Size(200, 20);
			this.m_txtTipoPopular.TabIndex = 1;
			this.m_txtTipoPopular.Text = "";
			// 
			// m_lbPE
			// 
			this.m_lbPE.Location = new System.Drawing.Point(40, 14);
			this.m_lbPE.Name = "m_lbPE";
			this.m_lbPE.Size = new System.Drawing.Size(56, 16);
			this.m_lbPE.TabIndex = 5;
			this.m_lbPE.Text = "Espécie";
			// 
			// m_btTipo
			// 
			this.m_btTipo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btTipo.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.m_btTipo.Location = new System.Drawing.Point(7, 31);
			this.m_btTipo.Name = "m_btTipo";
			this.m_btTipo.Size = new System.Drawing.Size(27, 26);
			this.m_btTipo.TabIndex = 0;
			this.m_btTipo.TabStop = false;
			this.m_btTipo.Click += new System.EventHandler(this.m_btTipo_Click);
			// 
			// m_gbMedidas
			// 
			this.m_gbMedidas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbMedidas.Controls.Add(this.label6);
			this.m_gbMedidas.Controls.Add(this.label5);
			this.m_gbMedidas.Controls.Add(this.label4);
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
			this.m_gbMedidas.Location = new System.Drawing.Point(7, 64);
			this.m_gbMedidas.Name = "m_gbMedidas";
			this.m_gbMedidas.Size = new System.Drawing.Size(641, 64);
			this.m_gbMedidas.TabIndex = 8;
			this.m_gbMedidas.TabStop = false;
			this.m_gbMedidas.Text = "Medidas";
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label6.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.label6.Location = new System.Drawing.Point(406, 35);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(16, 16);
			this.label6.TabIndex = 19;
			this.label6.Text = "=";
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.label5.Location = new System.Drawing.Point(257, 35);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(16, 16);
			this.label5.TabIndex = 9;
			this.label5.Text = "X";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.label4.Location = new System.Drawing.Point(117, 35);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(16, 16);
			this.label4.TabIndex = 8;
			this.label4.Text = "X";
			// 
			// m_btUnidadeVolume
			// 
			this.m_btUnidadeVolume.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btUnidadeVolume.Location = new System.Drawing.Point(507, 31);
			this.m_btUnidadeVolume.Name = "m_btUnidadeVolume";
			this.m_btUnidadeVolume.Size = new System.Drawing.Size(37, 24);
			this.m_btUnidadeVolume.TabIndex = 7;
			this.m_btUnidadeVolume.TabStop = false;
			this.m_btUnidadeVolume.Text = "m3";
			this.m_btUnidadeVolume.Click += new System.EventHandler(this.m_btUnidadeVolume_Click);
			// 
			// m_btUnidadeComprimento
			// 
			this.m_btUnidadeComprimento.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btUnidadeComprimento.Location = new System.Drawing.Point(360, 31);
			this.m_btUnidadeComprimento.Name = "m_btUnidadeComprimento";
			this.m_btUnidadeComprimento.Size = new System.Drawing.Size(37, 24);
			this.m_btUnidadeComprimento.TabIndex = 5;
			this.m_btUnidadeComprimento.TabStop = false;
			this.m_btUnidadeComprimento.Text = "m";
			this.m_btUnidadeComprimento.Click += new System.EventHandler(this.m_btUnidadeComprimento_Click);
			// 
			// m_btUnidadeLargura
			// 
			this.m_btUnidadeLargura.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btUnidadeLargura.Location = new System.Drawing.Point(214, 31);
			this.m_btUnidadeLargura.Name = "m_btUnidadeLargura";
			this.m_btUnidadeLargura.Size = new System.Drawing.Size(37, 24);
			this.m_btUnidadeLargura.TabIndex = 3;
			this.m_btUnidadeLargura.TabStop = false;
			this.m_btUnidadeLargura.Text = "m";
			this.m_btUnidadeLargura.Click += new System.EventHandler(this.m_btUnidadeLargura_Click);
			// 
			// m_btUnidadeAltura
			// 
			this.m_btUnidadeAltura.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btUnidadeAltura.Location = new System.Drawing.Point(77, 31);
			this.m_btUnidadeAltura.Name = "m_btUnidadeAltura";
			this.m_btUnidadeAltura.Size = new System.Drawing.Size(37, 24);
			this.m_btUnidadeAltura.TabIndex = 1;
			this.m_btUnidadeAltura.TabStop = false;
			this.m_btUnidadeAltura.Text = "m";
			this.m_btUnidadeAltura.Click += new System.EventHandler(this.m_btUnidadeAltura_Click);
			// 
			// m_txtVolume
			// 
			this.m_txtVolume.Location = new System.Drawing.Point(434, 33);
			this.m_txtVolume.Name = "m_txtVolume";
			this.m_txtVolume.OnlyNumbers = true;
			this.m_txtVolume.Size = new System.Drawing.Size(71, 20);
			this.m_txtVolume.TabIndex = 6;
			this.m_txtVolume.Text = "";
			this.m_txtVolume.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_txtComprimento
			// 
			this.m_txtComprimento.Location = new System.Drawing.Point(288, 33);
			this.m_txtComprimento.Name = "m_txtComprimento";
			this.m_txtComprimento.OnlyNumbers = true;
			this.m_txtComprimento.Size = new System.Drawing.Size(71, 20);
			this.m_txtComprimento.TabIndex = 4;
			this.m_txtComprimento.Text = "";
			this.m_txtComprimento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.m_txtComprimento.TextChanged += new System.EventHandler(this.m_txtComprimento_TextChanged);
			// 
			// m_txtLargura
			// 
			this.m_txtLargura.Location = new System.Drawing.Point(138, 33);
			this.m_txtLargura.Name = "m_txtLargura";
			this.m_txtLargura.OnlyNumbers = true;
			this.m_txtLargura.Size = new System.Drawing.Size(71, 20);
			this.m_txtLargura.TabIndex = 2;
			this.m_txtLargura.Text = "";
			this.m_txtLargura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.m_txtLargura.TextChanged += new System.EventHandler(this.m_txtLargura_TextChanged);
			// 
			// m_txtAltura
			// 
			this.m_txtAltura.Location = new System.Drawing.Point(5, 33);
			this.m_txtAltura.Name = "m_txtAltura";
			this.m_txtAltura.OnlyNumbers = true;
			this.m_txtAltura.Size = new System.Drawing.Size(71, 20);
			this.m_txtAltura.TabIndex = 0;
			this.m_txtAltura.Text = "";
			this.m_txtAltura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.m_txtAltura.TextChanged += new System.EventHandler(this.m_txtAltura_TextChanged);
			// 
			// m_lbVolume
			// 
			this.m_lbVolume.Location = new System.Drawing.Point(432, 14);
			this.m_lbVolume.Name = "m_lbVolume";
			this.m_lbVolume.Size = new System.Drawing.Size(96, 16);
			this.m_lbVolume.TabIndex = 4;
			this.m_lbVolume.Text = "Cubagem";
			// 
			// m_lbLargura
			// 
			this.m_lbLargura.Location = new System.Drawing.Point(139, 14);
			this.m_lbLargura.Name = "m_lbLargura";
			this.m_lbLargura.Size = new System.Drawing.Size(72, 16);
			this.m_lbLargura.TabIndex = 2;
			this.m_lbLargura.Text = "Largura";
			// 
			// m_lbComprimento
			// 
			this.m_lbComprimento.Location = new System.Drawing.Point(280, 14);
			this.m_lbComprimento.Name = "m_lbComprimento";
			this.m_lbComprimento.Size = new System.Drawing.Size(80, 16);
			this.m_lbComprimento.TabIndex = 1;
			this.m_lbComprimento.Text = "Comprimento";
			// 
			// m_lbAltura
			// 
			this.m_lbAltura.Location = new System.Drawing.Point(7, 14);
			this.m_lbAltura.Name = "m_lbAltura";
			this.m_lbAltura.Size = new System.Drawing.Size(72, 16);
			this.m_lbAltura.TabIndex = 0;
			this.m_lbAltura.Text = "Altura";
			// 
			// m_lbVolumes
			// 
			this.m_lbVolumes.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbVolumes.ForeColor = System.Drawing.Color.Black;
			this.m_lbVolumes.Location = new System.Drawing.Point(248, 14);
			this.m_lbVolumes.Name = "m_lbVolumes";
			this.m_lbVolumes.Size = new System.Drawing.Size(72, 16);
			this.m_lbVolumes.TabIndex = 2;
			this.m_lbVolumes.Text = "Quantidade";
			// 
			// m_txtQuantidadeVolumes
			// 
			this.m_txtQuantidadeVolumes.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_txtQuantidadeVolumes.Location = new System.Drawing.Point(248, 33);
			this.m_txtQuantidadeVolumes.Name = "m_txtQuantidadeVolumes";
			this.m_txtQuantidadeVolumes.OnlyNumbers = true;
			this.m_txtQuantidadeVolumes.Size = new System.Drawing.Size(48, 20);
			this.m_txtQuantidadeVolumes.TabIndex = 2;
			this.m_txtQuantidadeVolumes.Text = "";
			this.m_txtQuantidadeVolumes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_txtPesoBrutoUnitario
			// 
			this.m_txtPesoBrutoUnitario.Location = new System.Drawing.Point(379, 33);
			this.m_txtPesoBrutoUnitario.Name = "m_txtPesoBrutoUnitario";
			this.m_txtPesoBrutoUnitario.OnlyNumbers = true;
			this.m_txtPesoBrutoUnitario.Size = new System.Drawing.Size(72, 20);
			this.m_txtPesoBrutoUnitario.TabIndex = 3;
			this.m_txtPesoBrutoUnitario.Text = "";
			this.m_txtPesoBrutoUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.m_txtPesoBrutoUnitario.Leave += new System.EventHandler(this.m_txtPesoBrutoUnitario_Leave);
			this.m_txtPesoBrutoUnitario.TextChanged += new System.EventHandler(this.m_txtPesoBrutoUnitario_TextChanged);
			// 
			// m_lbPesoBrutoUnitario
			// 
			this.m_lbPesoBrutoUnitario.Location = new System.Drawing.Point(379, 14);
			this.m_lbPesoBrutoUnitario.Name = "m_lbPesoBrutoUnitario";
			this.m_lbPesoBrutoUnitario.Size = new System.Drawing.Size(120, 16);
			this.m_lbPesoBrutoUnitario.TabIndex = 0;
			this.m_lbPesoBrutoUnitario.Text = "Peso Bruto Unitário";
			// 
			// m_txtPesoBrutoTotal
			// 
			this.m_txtPesoBrutoTotal.Location = new System.Drawing.Point(528, 33);
			this.m_txtPesoBrutoTotal.Name = "m_txtPesoBrutoTotal";
			this.m_txtPesoBrutoTotal.OnlyNumbers = true;
			this.m_txtPesoBrutoTotal.Size = new System.Drawing.Size(72, 20);
			this.m_txtPesoBrutoTotal.TabIndex = 5;
			this.m_txtPesoBrutoTotal.Text = "";
			this.m_txtPesoBrutoTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.m_txtPesoBrutoTotal.Leave += new System.EventHandler(this.m_txtPesoBrutoTotal_Leave);
			this.m_txtPesoBrutoTotal.TextChanged += new System.EventHandler(this.m_txtPesoBrutoTotal_TextChanged);
			// 
			// m_btUnidadePesoBrutoUnitario
			// 
			this.m_btUnidadePesoBrutoUnitario.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btUnidadePesoBrutoUnitario.Location = new System.Drawing.Point(458, 31);
			this.m_btUnidadePesoBrutoUnitario.Name = "m_btUnidadePesoBrutoUnitario";
			this.m_btUnidadePesoBrutoUnitario.Size = new System.Drawing.Size(37, 24);
			this.m_btUnidadePesoBrutoUnitario.TabIndex = 4;
			this.m_btUnidadePesoBrutoUnitario.TabStop = false;
			this.m_btUnidadePesoBrutoUnitario.Text = "Kg";
			this.m_btUnidadePesoBrutoUnitario.Click += new System.EventHandler(this.m_btUnidadePesoBrutoUnitario_Click);
			// 
			// m_lbPesoBrutoTotal
			// 
			this.m_lbPesoBrutoTotal.Location = new System.Drawing.Point(528, 14);
			this.m_lbPesoBrutoTotal.Name = "m_lbPesoBrutoTotal";
			this.m_lbPesoBrutoTotal.Size = new System.Drawing.Size(102, 16);
			this.m_lbPesoBrutoTotal.TabIndex = 3;
			this.m_lbPesoBrutoTotal.Text = "Peso Bruto Total";
			// 
			// m_btUnidadePesoBrutoTotal
			// 
			this.m_btUnidadePesoBrutoTotal.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btUnidadePesoBrutoTotal.Location = new System.Drawing.Point(607, 31);
			this.m_btUnidadePesoBrutoTotal.Name = "m_btUnidadePesoBrutoTotal";
			this.m_btUnidadePesoBrutoTotal.Size = new System.Drawing.Size(37, 24);
			this.m_btUnidadePesoBrutoTotal.TabIndex = 6;
			this.m_btUnidadePesoBrutoTotal.TabStop = false;
			this.m_btUnidadePesoBrutoTotal.Text = "Kg";
			this.m_btUnidadePesoBrutoTotal.Click += new System.EventHandler(this.m_btUnidadePesoBrutoTotal_Click);
			// 
			// m_gbProduto
			// 
			this.m_gbProduto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbProduto.Controls.Add(this.m_lbProdutoUnidade);
			this.m_gbProduto.Controls.Add(this.label1);
			this.m_gbProduto.Controls.Add(this.m_lbMult);
			this.m_gbProduto.Controls.Add(this.m_txtDescricao);
			this.m_gbProduto.Controls.Add(this.m_lbDescricao);
			this.m_gbProduto.Controls.Add(this.m_lbProduto);
			this.m_gbProduto.Controls.Add(this.m_txtQuantidadeProduto);
			this.m_gbProduto.Controls.Add(this.m_lbPesoLiquidoUnitario);
			this.m_gbProduto.Controls.Add(this.m_txtPesoLiquidoUnitario);
			this.m_gbProduto.Controls.Add(this.m_lbPesoLiquidoTotal);
			this.m_gbProduto.Controls.Add(this.m_btUnidadePesoLiquidoUnitario);
			this.m_gbProduto.Controls.Add(this.m_txtPesoLiquidoTotal);
			this.m_gbProduto.Controls.Add(this.m_btUnidadePesoLiquidoTotal);
			this.m_gbProduto.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbProduto.Location = new System.Drawing.Point(5, 8);
			this.m_gbProduto.Name = "m_gbProduto";
			this.m_gbProduto.Size = new System.Drawing.Size(651, 64);
			this.m_gbProduto.TabIndex = 0;
			this.m_gbProduto.TabStop = false;
			this.m_gbProduto.Text = "Produto";
			// 
			// m_lbProdutoUnidade
			// 
			this.m_lbProdutoUnidade.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbProdutoUnidade.ForeColor = System.Drawing.Color.Black;
			this.m_lbProdutoUnidade.Location = new System.Drawing.Point(304, 33);
			this.m_lbProdutoUnidade.Name = "m_lbProdutoUnidade";
			this.m_lbProdutoUnidade.Size = new System.Drawing.Size(53, 16);
			this.m_lbProdutoUnidade.TabIndex = 24;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.label1.Location = new System.Drawing.Point(506, 35);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(16, 16);
			this.label1.TabIndex = 17;
			this.label1.Text = "=";
			// 
			// m_lbMult
			// 
			this.m_lbMult.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbMult.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.m_lbMult.Location = new System.Drawing.Point(356, 35);
			this.m_lbMult.Name = "m_lbMult";
			this.m_lbMult.Size = new System.Drawing.Size(16, 16);
			this.m_lbMult.TabIndex = 2;
			this.m_lbMult.Text = "X";
			// 
			// m_txtDescricao
			// 
			this.m_txtDescricao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_txtDescricao.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_txtDescricao.Location = new System.Drawing.Point(8, 33);
			this.m_txtDescricao.Name = "m_txtDescricao";
			this.m_txtDescricao.ReadOnly = true;
			this.m_txtDescricao.Size = new System.Drawing.Size(232, 20);
			this.m_txtDescricao.TabIndex = 15;
			this.m_txtDescricao.TabStop = false;
			this.m_txtDescricao.Text = "";
			// 
			// m_lbDescricao
			// 
			this.m_lbDescricao.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbDescricao.Location = new System.Drawing.Point(7, 14);
			this.m_lbDescricao.Name = "m_lbDescricao";
			this.m_lbDescricao.Size = new System.Drawing.Size(64, 16);
			this.m_lbDescricao.TabIndex = 0;
			this.m_lbDescricao.Text = "Descriçao";
			// 
			// m_lbProduto
			// 
			this.m_lbProduto.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbProduto.ForeColor = System.Drawing.Color.Black;
			this.m_lbProduto.Location = new System.Drawing.Point(248, 14);
			this.m_lbProduto.Name = "m_lbProduto";
			this.m_lbProduto.Size = new System.Drawing.Size(72, 16);
			this.m_lbProduto.TabIndex = 0;
			this.m_lbProduto.Text = "Quantidade";
			// 
			// m_txtQuantidadeProduto
			// 
			this.m_txtQuantidadeProduto.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_txtQuantidadeProduto.Location = new System.Drawing.Point(248, 33);
			this.m_txtQuantidadeProduto.Name = "m_txtQuantidadeProduto";
			this.m_txtQuantidadeProduto.OnlyNumbers = true;
			this.m_txtQuantidadeProduto.Size = new System.Drawing.Size(48, 20);
			this.m_txtQuantidadeProduto.TabIndex = 0;
			this.m_txtQuantidadeProduto.Text = "";
			this.m_txtQuantidadeProduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_lbPesoLiquidoUnitario
			// 
			this.m_lbPesoLiquidoUnitario.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbPesoLiquidoUnitario.Location = new System.Drawing.Point(379, 14);
			this.m_lbPesoLiquidoUnitario.Name = "m_lbPesoLiquidoUnitario";
			this.m_lbPesoLiquidoUnitario.Size = new System.Drawing.Size(128, 16);
			this.m_lbPesoLiquidoUnitario.TabIndex = 16;
			this.m_lbPesoLiquidoUnitario.Text = "Peso Liquido Unitário";
			// 
			// m_txtPesoLiquidoUnitario
			// 
			this.m_txtPesoLiquidoUnitario.Location = new System.Drawing.Point(379, 33);
			this.m_txtPesoLiquidoUnitario.Name = "m_txtPesoLiquidoUnitario";
			this.m_txtPesoLiquidoUnitario.OnlyNumbers = true;
			this.m_txtPesoLiquidoUnitario.Size = new System.Drawing.Size(72, 20);
			this.m_txtPesoLiquidoUnitario.TabIndex = 1;
			this.m_txtPesoLiquidoUnitario.Text = "";
			this.m_txtPesoLiquidoUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.m_txtPesoLiquidoUnitario.TextChanged += new System.EventHandler(this.m_txtPesoLiquidoUnitario_TextChanged);
			// 
			// m_lbPesoLiquidoTotal
			// 
			this.m_lbPesoLiquidoTotal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbPesoLiquidoTotal.Location = new System.Drawing.Point(528, 14);
			this.m_lbPesoLiquidoTotal.Name = "m_lbPesoLiquidoTotal";
			this.m_lbPesoLiquidoTotal.Size = new System.Drawing.Size(110, 16);
			this.m_lbPesoLiquidoTotal.TabIndex = 23;
			this.m_lbPesoLiquidoTotal.Text = "Peso Liquido Total";
			// 
			// m_btUnidadePesoLiquidoUnitario
			// 
			this.m_btUnidadePesoLiquidoUnitario.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btUnidadePesoLiquidoUnitario.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btUnidadePesoLiquidoUnitario.Location = new System.Drawing.Point(458, 31);
			this.m_btUnidadePesoLiquidoUnitario.Name = "m_btUnidadePesoLiquidoUnitario";
			this.m_btUnidadePesoLiquidoUnitario.Size = new System.Drawing.Size(37, 24);
			this.m_btUnidadePesoLiquidoUnitario.TabIndex = 2;
			this.m_btUnidadePesoLiquidoUnitario.TabStop = false;
			this.m_btUnidadePesoLiquidoUnitario.Text = "Kg";
			this.m_btUnidadePesoLiquidoUnitario.Click += new System.EventHandler(this.m_btUnidadePesoLiquidoUnitario_Click);
			// 
			// m_txtPesoLiquidoTotal
			// 
			this.m_txtPesoLiquidoTotal.Location = new System.Drawing.Point(528, 33);
			this.m_txtPesoLiquidoTotal.Name = "m_txtPesoLiquidoTotal";
			this.m_txtPesoLiquidoTotal.OnlyNumbers = true;
			this.m_txtPesoLiquidoTotal.Size = new System.Drawing.Size(72, 20);
			this.m_txtPesoLiquidoTotal.TabIndex = 3;
			this.m_txtPesoLiquidoTotal.Text = "";
			this.m_txtPesoLiquidoTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.m_txtPesoLiquidoTotal.TextChanged += new System.EventHandler(this.m_txtPesoLiquidoTotal_TextChanged);
			// 
			// m_btUnidadePesoLiquidoTotal
			// 
			this.m_btUnidadePesoLiquidoTotal.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btUnidadePesoLiquidoTotal.Location = new System.Drawing.Point(607, 31);
			this.m_btUnidadePesoLiquidoTotal.Name = "m_btUnidadePesoLiquidoTotal";
			this.m_btUnidadePesoLiquidoTotal.Size = new System.Drawing.Size(37, 24);
			this.m_btUnidadePesoLiquidoTotal.TabIndex = 4;
			this.m_btUnidadePesoLiquidoTotal.TabStop = false;
			this.m_btUnidadePesoLiquidoTotal.Text = "Kg";
			this.m_btUnidadePesoLiquidoTotal.Click += new System.EventHandler(this.m_btUnidadePesoLiquidoTotal_Click);
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(270, 202);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 2;
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(334, 202);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 3;
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_ilVolumes
			// 
			this.m_ilVolumes.ImageSize = new System.Drawing.Size(16, 16);
			this.m_ilVolumes.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_ilVolumes.ImageStream")));
			this.m_ilVolumes.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// frmFProdutosSimplificadoVincular
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(666, 232);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFProdutosSimplificadoVincular";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Distribuição dos Produtos";
			this.Load += new System.EventHandler(this.frmFProdutosSimplificadoVincular_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbVolumes.ResumeLayout(false);
			this.m_gbMedidas.ResumeLayout(false);
			this.m_gbProduto.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFProdutosSimplificadoVincular_Load(object sender, System.EventArgs e)
				{
					vMostraCor();
					OnCallCarregaDadosProduto();
					OnCallCarregaDados();
					OnCallCarregaDadosTipoVolume(true);
					vMostraUnidades();
					vRefreshPesoLiquidoTotal();
					vRefreshPesoBrutoTotal(false);
				}
			#endregion
			#region TextBoxes
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

				private void m_txtPesoLiquidoUnitario_TextChanged(object sender, System.EventArgs e)
				{
					if (m_bDoEvents)
					{
						m_bDoEvents = false;
						vRefreshPesoLiquidoTotal();
						m_bDoEvents = true;
					}
				}

				private void m_txtPesoLiquidoTotal_TextChanged(object sender, System.EventArgs e)
				{
					if (m_bDoEvents)
					{
						m_bDoEvents = false;
						vRefreshPesoLiquidoUnitario();
						m_bDoEvents = true;
					}
				}

				private void m_txtPesoBrutoUnitario_TextChanged(object sender, System.EventArgs e)
				{
					if (m_bDoEvents)
					{
						m_bDoEvents = false;
						vRefreshPesoBrutoTotal(false);
						m_bDoEvents = true;
					}
				}

				private void m_txtPesoBrutoTotal_TextChanged(object sender, System.EventArgs e)
				{
					if (m_bDoEvents)
					{
						m_bDoEvents = false;
						vRefreshPesoBrutoUnitario(false);
						m_bDoEvents = true;
					}
				}

				private void m_txtPesoBrutoUnitario_Leave(object sender, System.EventArgs e)
				{
					if (m_bDoEvents)
					{
						m_bDoEvents = false;
						vRefreshPesoBrutoTotal(true);
						m_bDoEvents = true;
					}
				}

				private void m_txtPesoBrutoTotal_Leave(object sender, System.EventArgs e)
				{
					if (m_bDoEvents)
					{
						m_bDoEvents = false;
						vRefreshPesoBrutoUnitario(true);
						m_bDoEvents = true;
					}
				}
			#endregion
			#region Botoes
				private void m_btTipo_Click(object sender, System.EventArgs e)
				{
					if (OnCallShowDialogVolumeTipo())
						OnCallCarregaDadosTipoVolume(true);
				}

				private void m_btUnidadeAltura_Click(object sender, System.EventArgs e)
				{
					vTrocaUnidadeAltura();
					while ( m_nUnidadeMetricaAltura != m_nUnidadeMetricaLargura)
						vTrocaUnidadeLargura();
					while (m_nUnidadeMetricaLargura != m_nUnidadeMetricaComprimento)
						vTrocaUnidadeComprimento();
					while (m_nUnidadeMetricaComprimento != m_nUnidadeMetricaVolume)
						vTrocaUnidadeVolume();
					vRefreshVolumeCubico();
				}

				private void m_btUnidadeLargura_Click(object sender, System.EventArgs e)
				{
					vTrocaUnidadeLargura();
					while (m_nUnidadeMetricaLargura != m_nUnidadeMetricaComprimento)
						vTrocaUnidadeComprimento();
					while (m_nUnidadeMetricaComprimento != m_nUnidadeMetricaVolume)
						vTrocaUnidadeVolume();
					vRefreshVolumeCubico();
				}

				private void m_btUnidadeComprimento_Click(object sender, System.EventArgs e)
				{
					vTrocaUnidadeComprimento();
					while (m_nUnidadeMetricaComprimento != m_nUnidadeMetricaVolume)
						vTrocaUnidadeVolume();
					vRefreshVolumeCubico();
				}

				private void m_btUnidadeVolume_Click(object sender, System.EventArgs e)
				{
                    vTrocaUnidadeVolume();
					vRefreshVolumeCubico();
				}

				private void m_btUnidadePesoLiquidoUnitario_Click(object sender, System.EventArgs e)
				{
					vTrocaUnidadePesoLiquido();
				}

				private void m_btUnidadePesoLiquidoTotal_Click(object sender, System.EventArgs e)
				{
					vTrocaUnidadePesoLiquido();
				}

				private void m_btUnidadePesoBrutoUnitario_Click(object sender, System.EventArgs e)
				{
					vTrocaUnidadePesoBruto();
				}

				private void m_btUnidadePesoBrutoTotal_Click(object sender, System.EventArgs e)
				{
					vTrocaUnidadePesoBruto();
				}

				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					if (m_bModificado = OnCallSalvaDados())
						this.Close();
				}

				private void m_btCancelar_Click(object sender, System.EventArgs e)
				{
					m_bModificado = false;
					this.Close();
				}
			#endregion
		#endregion

		#region Cores
			private void vMostraCor()
			{
				mdlPaletaDeCores.clsPaletaDeCores clsPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini","SiscobrasCorSecundaria");
				this.BackColor = clsPaletaCores.retornaCorAtual();
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
					case "mdlComponentesGraficos.ComboBox":
					case "mdlComponentesGraficos.TreeView":
					case "mdlComponentesGraficos.TextBox":
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
		#region Unidades
			private void vMostraUnidades()
			{
				vMostraUnidadeAltura();
				vMostraUnidadeLargura();
				vMostraUnidadeComprimento();
				vMostraUnidadeVolume();
				vMostraUnidadePesoLiquido();
				vMostraUnidadePesoBruto();
			}

			private void vMostraUnidadeAltura()
			{
				this.m_btUnidadeAltura.Text = OnCallRetornaSiglaUnidadeEspaco(m_nUnidadeMetricaAltura);
			}

			private void vMostraUnidadeLargura()
			{
				this.m_btUnidadeLargura.Text = OnCallRetornaSiglaUnidadeEspaco(m_nUnidadeMetricaLargura);
			}

			private void vMostraUnidadeComprimento()
			{
				this.m_btUnidadeComprimento.Text = OnCallRetornaSiglaUnidadeEspaco(m_nUnidadeMetricaComprimento);
			}

			private void vMostraUnidadeVolume()
			{
				this.m_btUnidadeVolume.Text = OnCallRetornaSiglaUnidadeEspaco(m_nUnidadeMetricaVolume) + "³";			
			}

			private void vMostraUnidadePesoLiquido()
			{
				this.m_btUnidadePesoLiquidoUnitario.Text = OnCallRetornaSiglaUnidadeMassa(m_nUnidadeMassaPesoLiquido);
				this.m_btUnidadePesoLiquidoTotal.Text = this.m_btUnidadePesoLiquidoUnitario.Text;
			}

			private void vMostraUnidadePesoBruto()
			{
				this.m_btUnidadePesoBrutoUnitario.Text = OnCallRetornaSiglaUnidadeMassa(m_nUnidadeMassaPesoBruto);
				this.m_btUnidadePesoBrutoTotal.Text = this.m_btUnidadePesoBrutoUnitario.Text;
			}

			private void vTrocaUnidadeAltura()
			{
				switch((mdlProdutosRomaneio.UnidadeMedida)m_nUnidadeMetricaAltura)
				{
					case mdlProdutosRomaneio.UnidadeMedida.Centimetro:
						m_nUnidadeMetricaAltura = (int)mdlProdutosRomaneio.UnidadeMedida.Metro;
						break;
					case mdlProdutosRomaneio.UnidadeMedida.Metro:
						m_nUnidadeMetricaAltura = (int)mdlProdutosRomaneio.UnidadeMedida.Centimetro;
						break;
				}
				vMostraUnidadeAltura();
			}

			private void vTrocaUnidadeLargura()
			{
				switch((mdlProdutosRomaneio.UnidadeMedida)m_nUnidadeMetricaLargura)
				{
					case mdlProdutosRomaneio.UnidadeMedida.Centimetro:
						m_nUnidadeMetricaLargura = (int)mdlProdutosRomaneio.UnidadeMedida.Metro;
						break;
					case mdlProdutosRomaneio.UnidadeMedida.Metro:
						m_nUnidadeMetricaLargura = (int)mdlProdutosRomaneio.UnidadeMedida.Centimetro;
						break;
				}
				vMostraUnidadeLargura();
			}

			private void vTrocaUnidadeComprimento()
			{
				switch((mdlProdutosRomaneio.UnidadeMedida)m_nUnidadeMetricaComprimento)
				{
					case mdlProdutosRomaneio.UnidadeMedida.Centimetro:
						m_nUnidadeMetricaComprimento = (int)mdlProdutosRomaneio.UnidadeMedida.Metro;
						break;
					case mdlProdutosRomaneio.UnidadeMedida.Metro:
						m_nUnidadeMetricaComprimento = (int)mdlProdutosRomaneio.UnidadeMedida.Centimetro;
						break;
				}
				vMostraUnidadeComprimento();
			}

			private void vTrocaUnidadeVolume()
			{
				switch((mdlProdutosRomaneio.UnidadeMedida)m_nUnidadeMetricaVolume)
				{
					case mdlProdutosRomaneio.UnidadeMedida.Centimetro:
						m_nUnidadeMetricaVolume = (int)mdlProdutosRomaneio.UnidadeMedida.Metro;
						break;
					case mdlProdutosRomaneio.UnidadeMedida.Metro:
						m_nUnidadeMetricaVolume = (int)mdlProdutosRomaneio.UnidadeMedida.Centimetro;
						break;
				}
				vMostraUnidadeVolume();
			}

			private void vTrocaUnidadePesoLiquido()
			{
				switch((mdlProdutosRomaneio.UnidadeMassa)m_nUnidadeMassaPesoLiquido)
				{
					case mdlProdutosRomaneio.UnidadeMassa.Grama:
						m_nUnidadeMassaPesoLiquido = (int)mdlProdutosRomaneio.UnidadeMassa.Kilograma;
						break;
					case mdlProdutosRomaneio.UnidadeMassa.Kilograma:
						m_nUnidadeMassaPesoLiquido = (int)mdlProdutosRomaneio.UnidadeMassa.Tonelada;
						break;
					case mdlProdutosRomaneio.UnidadeMassa.Tonelada:
						m_nUnidadeMassaPesoLiquido = (int)mdlProdutosRomaneio.UnidadeMassa.Grama;
						break;
				}
				vMostraUnidadePesoLiquido();
			}

			private void vTrocaUnidadePesoBruto()
			{
				switch((mdlProdutosRomaneio.UnidadeMassa)m_nUnidadeMassaPesoBruto)
				{
					case mdlProdutosRomaneio.UnidadeMassa.Grama:
						m_nUnidadeMassaPesoBruto = (int)mdlProdutosRomaneio.UnidadeMassa.Kilograma;
						break;
					case mdlProdutosRomaneio.UnidadeMassa.Kilograma:
						m_nUnidadeMassaPesoBruto = (int)mdlProdutosRomaneio.UnidadeMassa.Tonelada;
						break;
					case mdlProdutosRomaneio.UnidadeMassa.Tonelada:
						m_nUnidadeMassaPesoBruto = (int)mdlProdutosRomaneio.UnidadeMassa.Grama;
						break;
				}
				vMostraUnidadePesoBruto();
			}
		#endregion

		#region Altura x Largura x Comprimento = Volume
			private void vRefreshVolumeCubico()
			{
				double dAltura = 0,dLargura = 0,dComprimento = 0;
				try
				{
					dAltura = double.Parse(m_txtAltura.Text);
				}catch{
					dAltura = 0;
				}
				try
				{
					dLargura = double.Parse(m_txtLargura.Text);
				}catch{
					dLargura = 0;
				}
				try
				{
					dComprimento = double.Parse(m_txtComprimento.Text);
				}catch{
					dComprimento = 0;
				}
				if ((dAltura != 0) && (dLargura != 0) && (dComprimento != 0))
				{
					if (m_nUnidadeMetricaVolume != m_nUnidadeMetricaAltura)
						dAltura = dAltura * (clsProdutosRomaneio.dRetornaFatorConversaoEntreUnidadesEspaco(m_nUnidadeMetricaAltura,m_nUnidadeMetricaVolume));
					if (m_nUnidadeMetricaVolume != m_nUnidadeMetricaLargura)
						dLargura = dLargura * (clsProdutosRomaneio.dRetornaFatorConversaoEntreUnidadesEspaco(m_nUnidadeMetricaLargura,m_nUnidadeMetricaVolume));
					if (m_nUnidadeMetricaVolume != m_nUnidadeMetricaComprimento)
						dComprimento = dComprimento * (clsProdutosRomaneio.dRetornaFatorConversaoEntreUnidadesEspaco(m_nUnidadeMetricaComprimento,m_nUnidadeMetricaVolume));
					m_txtVolume.Text = (dAltura * dLargura * dComprimento).ToString();
				}
			}
		#endregion
		#region Peso Liquido
			private void vRefreshPesoLiquidoUnitario()
			{
				double dPesoLiquidoTotal = 0;
				double dQuantidadeProduto = 0;
				try
				{
					dPesoLiquidoTotal = double.Parse(m_txtPesoLiquidoTotal.Text);
				}
				catch
				{
					dPesoLiquidoTotal = 0;
				}
				try
				{
					dQuantidadeProduto = double.Parse(m_txtQuantidadeProduto.Text);
				}
				catch
				{
					dQuantidadeProduto = 0;
				}
				if ((dPesoLiquidoTotal != 0) && (dQuantidadeProduto != 0))
				{
					m_txtPesoLiquidoUnitario.Text =(mdlConversao.clsTruncamento.dTrunca(dPesoLiquidoTotal / dQuantidadeProduto,0.00001d)).ToString();
				}
			}

			private void vRefreshPesoLiquidoTotal()
			{
				double dPesoLiquidoUnitario = 0;
				double dQuantidadeProduto = 0;
				try
				{
					dPesoLiquidoUnitario = double.Parse(m_txtPesoLiquidoUnitario.Text);
				}catch{
					dPesoLiquidoUnitario = 0;
				}
				try
				{
					dQuantidadeProduto = double.Parse(m_txtQuantidadeProduto.Text);
				}catch{
					dQuantidadeProduto = 0;
				}
				if ((dPesoLiquidoUnitario != 0) && (dQuantidadeProduto != 0))
				{
					m_txtPesoLiquidoTotal.Text = mdlConversao.clsTruncamento.dTrunca(dPesoLiquidoUnitario * dQuantidadeProduto,0.00001d).ToString();
				}
			}
  		#endregion
		#region Peso Bruto
			private void vRefreshPesoBrutoUnitario(bool bPodeModificarVolumes)
			{
				double dPesoBrutoTotal = 0;
				double dQuantidadeVolumes = 0;
				try
				{
					dPesoBrutoTotal = double.Parse(m_txtPesoBrutoTotal.Text);
				}
				catch
				{
					dPesoBrutoTotal = 0;
				}
				try
				{
					dQuantidadeVolumes = double.Parse(m_txtQuantidadeVolumes.Text);
				}
				catch
				{
					dQuantidadeVolumes = 0;
				}
				if ((dPesoBrutoTotal != 0) && (dQuantidadeVolumes != 0))
				{
					m_txtPesoBrutoUnitario.Text =(System.Math.Round(dPesoBrutoTotal / dQuantidadeVolumes,MAXDECIMALS)).ToString();
				}else{
					if ((dPesoBrutoTotal != 0) && (dQuantidadeVolumes == 0) && (bPodeModificarVolumes))
					{
						double dPesoBrutoUnitario = 0;
						try
						{
							dPesoBrutoUnitario = double.Parse(m_txtPesoBrutoUnitario.Text);
						}
						catch
						{
							dPesoBrutoUnitario = 0;
						}
						if (dPesoBrutoUnitario != 0)
						{
							m_txtQuantidadeVolumes.Text = (mdlConversao.clsTruncamento.dTrunca(dPesoBrutoTotal / dPesoBrutoUnitario,0.00001d)).ToString();
						}
					}
				}
			}

			private void vRefreshPesoBrutoTotal(bool bPodeModificarVolumes)
			{
				double dPesoBrutoUnitario = 0;
				double dQuantidadeVolumes = 0;
				try
				{
					dPesoBrutoUnitario = double.Parse(m_txtPesoBrutoUnitario.Text);
				}
				catch
				{
					dPesoBrutoUnitario = 0;
				}
				try
				{
					dQuantidadeVolumes = double.Parse(m_txtQuantidadeVolumes.Text);
				}
				catch
				{
					dQuantidadeVolumes = 0;
				}
				if ((dPesoBrutoUnitario != 0) && (dQuantidadeVolumes != 0))
				{
					m_txtPesoBrutoTotal.Text = mdlConversao.clsTruncamento.dTrunca(dPesoBrutoUnitario * dQuantidadeVolumes,0.00001d).ToString();
				}else{
					if ((dPesoBrutoUnitario != 0) && (dQuantidadeVolumes == 0) && (bPodeModificarVolumes))
					{
						double dPesoBrutoTotal = 0;
						try
						{
							dPesoBrutoTotal = double.Parse(m_txtPesoBrutoTotal.Text);
						}
						catch
						{
							dPesoBrutoTotal = 0;
						}
						if (dPesoBrutoTotal != 0)
						{
							m_txtQuantidadeVolumes.Text = (System.Math.Round(dPesoBrutoTotal / dPesoBrutoUnitario,MAXDECIMALS)).ToString();
						}
					}
				}
			}
		#endregion
	}
}
