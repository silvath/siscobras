using System;
//using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlProdutosGeral
{
	/// <summary>
	/// Summary description for frmFAtributos.
	/// </summary>
	public class frmFAtributos : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate bool delCallCarregaDados(int nIdProduto,out string strDescricao,out double dPesoLiquido,out int nUnidadePesoLiquido,out double dPesoBruto,out int nUnidadePesoBruto,out double dLargura,out int nUnidadeLargura,out double dComprimento,out int nUnidadeComprimento,out double dAltura,out int nUnidadeAlgura,out int nIdVolumeTipo,out string strVolumeTipoPopular,out double dQuantidadeVolume,out double dVolumeLargura,out int nVolumeUnidadeLargura,out double dVolumeComprimento,out int nVolumeUnidadeComprimento,out double dVolumeAltura,out int nVolumeUnidadeAlgura,out double dQuantidadeEmbalagens,out double dEmbalagensVolume,out bool bPossuiMaterialImportado,out double dPorcentagemValorNacional);
			public delegate bool delCallSalvaDados(int nIdProduto,string strDescricao,double dPesoLiquido,int nUnidadePesoLiquido,double dPesoBruto,int nUnidadePesoBruto,double dLargura,int nUnidadeLargura,double dComprimento,int nUnidadeComprimento,double dAltura,int nUnidadeAlgura,int nIdVolumeTipo,string strVolumeTipoPopular,double dQuantidadeVolume,double dVolumeLargura,int nVolumeUnidadeLargura,double dVolumeComprimento,int nVolumeUnidadeComprimento,double dVolumeAltura,int nVolumeUnidadeAlgura,double dQuantidadeEmbalagens,double dEmbalagensVolume,bool bPossuiMaterialImportado,double dPorcentagemValorNacional);
			public delegate bool delCallShowVolumeTipo(ref int nIdVolumeTipo);
			public delegate bool delCallCarregaVolumeTipo(int nIdVolumeTipo,out string strVolumeTipo);
		#endregion
		#region Events
			public event delCallCarregaDados eCallCarregaDados;
			public event delCallSalvaDados eCallSalvaDados;
			public event delCallShowVolumeTipo eCallShowVolumeTipo;
			public event delCallCarregaVolumeTipo eCallCarregaVolumeTipo;
		#endregion
		#region Events Methods
			protected virtual void OnCallCarregaDados() 
			{
				if (eCallCarregaDados != null)
				{
					string strDescricao,strVolumeTipoPopular;
					double dPesoLiquido,dPesoBruto,dLargura,dComprimento,dAltura,dQuantidadeVolume,dVolumeLargura,dVolumeComprimento,dVolumeAltura,dQuantidadeEmbalagens,dEmbalagensVolume;
					int nUnidadePesoLiquido,nUnidadePesoBruto,nUnidadeLargura,nUnidadeComprimento,nUnidadeAltura,nIdVolumeTipo,nVolumeUnidadeLargura,nVolumeUnidadeComprimento,nVolumeUnidadeAltura;
					bool bPossuiMaterialImportado = false;
					double dPorcentagemValorNacional = 0;
					eCallCarregaDados(m_nIdProduto,out strDescricao,out dPesoLiquido,out nUnidadePesoLiquido,out dPesoBruto,out nUnidadePesoBruto,out dLargura,out nUnidadeLargura,out dComprimento,out nUnidadeComprimento,out dAltura,out nUnidadeAltura,out nIdVolumeTipo,out strVolumeTipoPopular,out dQuantidadeVolume,out dVolumeLargura,out nVolumeUnidadeLargura,out dVolumeComprimento,out nVolumeUnidadeComprimento,out dVolumeAltura,out nVolumeUnidadeAltura,out dQuantidadeEmbalagens,out dEmbalagensVolume,out bPossuiMaterialImportado,out dPorcentagemValorNacional);
					//Produto
					m_txtDescricao.Text = strDescricao;
					m_txtPesoLiquidoUnitario.Text = dPesoLiquido.ToString();
					m_nUnidadePesoLiquido = nUnidadePesoLiquido;
					m_btUnidadePesoLiquido.Text = clsProdutos.strRetornaSiglaUnidadeMassa(m_nUnidadePesoLiquido);
					m_txtPesoBrutoUnitario.Text = dPesoBruto.ToString();
					m_nUnidadePesoBruto = nUnidadePesoBruto;
					m_btUnidadePesoBruto.Text = clsProdutos.strRetornaSiglaUnidadeMassa(m_nUnidadePesoBruto);
					m_txtLargura.Text = dLargura.ToString();
					m_nUnidadeLargura = nUnidadeLargura;
					m_btUnidadeLargura.Text = clsProdutos.strRetornaSiglaUnidadeMetrica(m_nUnidadeLargura);
					m_txtComprimento.Text = dComprimento.ToString();
					m_nUnidadeComprimento = nUnidadeComprimento;
					m_btUnidadeComprimento.Text = clsProdutos.strRetornaSiglaUnidadeMetrica(m_nUnidadeComprimento);
					m_txtAltura.Text = dAltura.ToString();
					m_nUnidadeAltura = nUnidadeAltura;
					m_btUnidadeAltura.Text = clsProdutos.strRetornaSiglaUnidadeMetrica(m_nUnidadeAltura);
					m_nIdVolumeTipo = nIdVolumeTipo;
					m_txtVolumeTipoPopular.Text = strVolumeTipoPopular;
					m_txtQuantidadeVolume.Text = dQuantidadeVolume.ToString();
					m_txtVolumeLargura.Text = dVolumeLargura.ToString();
					m_nVolumeUnidadeLargura = nVolumeUnidadeLargura;
					m_btVolumeUnidadeLargura.Text = clsProdutos.strRetornaSiglaUnidadeMetrica(m_nVolumeUnidadeLargura);
					m_txtVolumeComprimento.Text = dVolumeComprimento.ToString();
					m_nVolumeUnidadeComprimento = nVolumeUnidadeComprimento;
					m_btVolumeUnidadeComprimento.Text = clsProdutos.strRetornaSiglaUnidadeMetrica(m_nVolumeUnidadeComprimento);
					m_txtVolumeAltura.Text = dVolumeAltura.ToString();
					m_nVolumeUnidadeAltura = nVolumeUnidadeAltura;
                    m_txtQuantidadeEmbalagem.Text = dQuantidadeEmbalagens.ToString();
					m_txtEmbalagensVolume.Text = dEmbalagensVolume.ToString();
					m_rdbtSim.Checked = bPossuiMaterialImportado;
					m_rdbtNao.Checked = !bPossuiMaterialImportado;
					m_txtPercentagem.Text = dPorcentagemValorNacional.ToString();
					RefreshInterface();
				}
			}

			protected bool OnCallSalvaDados()
			{
				if (eCallSalvaDados == null)
					return(false);
				string strDescricao = "",strVolumeTipoPopular = "";
				double dPesoLiquido = 0,dPesoBruto = 0,dLargura = 0,dComprimento = 0,dAltura = 0,dQuantidadeVolume = 0,dVolumeLargura = 0,dVolumeComprimento = 0,dVolumeAltura = 0,dQuantidadeEmbalagens = 0,dEmbalagensVolume = 0;
				int nUnidadePesoLiquido = 0,nUnidadePesoBruto = 0,nUnidadeLargura = 0,nUnidadeComprimento = 0,nUnidadeAltura = 0,nIdVolumeTipo = 0,nVolumeUnidadeLargura = 0,nVolumeUnidadeComprimento = 0,nVolumeUnidadeAltura = 0;
				double dPorcentagemValorNacional = 0;

				//Produto
				strDescricao = m_txtDescricao.Text;
				try
				{
					dPesoLiquido = double.Parse(m_txtPesoLiquidoUnitario.Text);
				}catch{
					dPesoLiquido = 0;
				}
				nUnidadePesoLiquido = m_nUnidadePesoLiquido;
				try
				{
					dPesoBruto = double.Parse(m_txtPesoBrutoUnitario.Text);
				}catch{
					dPesoBruto = 0;
				}
				nUnidadePesoBruto = m_nUnidadePesoBruto;
				try
				{
					dLargura = double.Parse(m_txtLargura.Text);
				}catch{
					dLargura = 0;
				}
				nUnidadeLargura = m_nUnidadeLargura;
				try
				{
					dComprimento = double.Parse(m_txtComprimento.Text);
				}catch{
					dComprimento = 0;
				}
				nUnidadeComprimento = m_nUnidadeComprimento;
				try
				{
					dAltura = double.Parse(m_txtAltura.Text);
				}catch{
					dAltura = 0;
				}
				nUnidadeAltura = m_nUnidadeAltura;
				nIdVolumeTipo = m_nIdVolumeTipo;
				strVolumeTipoPopular = m_txtVolumeTipoPopular.Text;
				try
				{
					dQuantidadeVolume = double.Parse(m_txtQuantidadeVolume.Text);
				}catch{
					dQuantidadeVolume = 0;
				}
				try
				{
					dVolumeLargura = double.Parse(m_txtVolumeLargura.Text);
				}catch{
					dVolumeLargura = 0;
				}
				nVolumeUnidadeLargura = m_nVolumeUnidadeLargura;
				try
				{
					dVolumeComprimento = double.Parse(m_txtVolumeComprimento.Text);
				}catch{
					dVolumeComprimento = 0;
				}
				nVolumeUnidadeComprimento = m_nVolumeUnidadeComprimento;
				try
				{
					dVolumeAltura = double.Parse(m_txtVolumeAltura.Text);
				}catch{
					dVolumeAltura = 0;

				}
				nVolumeUnidadeAltura = m_nVolumeUnidadeAltura;
				try
				{
					dQuantidadeEmbalagens = double.Parse(m_txtQuantidadeEmbalagem.Text);
				}catch{
					dQuantidadeEmbalagens = 0;
				} 
				try
				{
					dEmbalagensVolume = double.Parse(m_txtEmbalagensVolume.Text);
				}catch{
					dEmbalagensVolume = 0;
				}
				try
				{
					dPorcentagemValorNacional = double.Parse(m_txtPercentagem.Text);
				}catch{
					dPorcentagemValorNacional = 0;
				}
				return(eCallSalvaDados(m_nIdProduto,strDescricao,dPesoLiquido,nUnidadePesoLiquido,dPesoBruto,nUnidadePesoBruto,dLargura,nUnidadeLargura,dComprimento,nUnidadeComprimento,dAltura,nUnidadeAltura,nIdVolumeTipo,strVolumeTipoPopular,dQuantidadeVolume,dVolumeLargura,nVolumeUnidadeLargura,dVolumeComprimento,nVolumeUnidadeComprimento,dVolumeAltura,nVolumeUnidadeAltura,dQuantidadeEmbalagens,dEmbalagensVolume,m_rdbtSim.Checked,dPorcentagemValorNacional));
			} 

			protected virtual bool OnCallShowVolumeTipo() 
			{
				if (eCallShowVolumeTipo == null)
					return(false);
				return(eCallShowVolumeTipo(ref m_nIdVolumeTipo));
			}


			protected virtual bool OnCallCarregaVolumeTipo() 
			{
				if (eCallCarregaVolumeTipo == null)
					return(false);
				string strVolumeDescricao;
				if (eCallCarregaVolumeTipo(m_nIdVolumeTipo,out strVolumeDescricao))
				{
					m_txtVolumeTipoPopular.Text = strVolumeDescricao;
					return(true);
				}
				return(false);

			}
		#endregion

		#region Atributes
			private bool m_bConfirmed = false;

			private int m_nIdProduto = -1;

			private int m_nUnidadePesoLiquido = 0;
			private int m_nUnidadePesoBruto = 0;

			private int m_nUnidadeLargura = 0;
			private int m_nUnidadeComprimento = 0;
			private int m_nUnidadeAltura = 0;

			private int m_nIdVolumeTipo = -1;

			private int m_nVolumeUnidadeLargura = 0;
			private int m_nVolumeUnidadeComprimento = 0;
			private int m_nVolumeUnidadeAltura = 0;

			private System.Windows.Forms.GroupBox m_gbMain;
			private System.Windows.Forms.Button m_btOk;
			private System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.GroupBox m_gbProdutos;
			private System.Windows.Forms.Label m_lbDescricao;
			private System.Windows.Forms.TextBox m_txtDescricao;
			private System.Windows.Forms.GroupBox m_gbPesos;
			private System.Windows.Forms.Label m_lbPesoLiquidoUnitario;
			private mdlComponentesGraficos.TextBox m_txtPesoLiquidoUnitario;
			private System.Windows.Forms.Button m_btUnidadePesoLiquido;
			private System.Windows.Forms.Button m_btUnidadePesoBruto;
			private mdlComponentesGraficos.TextBox m_txtPesoBrutoUnitario;
			private System.Windows.Forms.Label m_lbPesoBrutoUnitario;
			private System.Windows.Forms.Label m_lbLargura;
			private System.Windows.Forms.Button m_btUnidadeLargura;
			private System.Windows.Forms.Label m_lbComprimento;
			private System.Windows.Forms.Label m_lbQuantidadeVolume;
			private System.Windows.Forms.GroupBox m_gbTamanho;
			private System.Windows.Forms.Button m_btUnidadeAltura;
			private mdlComponentesGraficos.TextBox m_txtAltura;
			private System.Windows.Forms.Label m_lbAltura;
			private System.Windows.Forms.Button m_btUnidadeComprimento;
			private mdlComponentesGraficos.TextBox m_txtComprimento;
			private mdlComponentesGraficos.TextBox m_txtLargura;
			private System.Windows.Forms.GroupBox m_gbVolume;
			internal mdlComponentesGraficos.TextBox m_txtVolumeTipoPopular;
			internal System.Windows.Forms.Button m_btUnidadeVolume;
			private mdlComponentesGraficos.TextBox m_txtQuantidadeVolume;
			private System.Windows.Forms.GroupBox m_gbVolumeTamanho;
			private System.Windows.Forms.GroupBox m_gbEmbalagem;
			private mdlComponentesGraficos.TextBox m_txtEmbalagensVolume;
			private System.Windows.Forms.Label m_lbEmbalagensVolume;
			private mdlComponentesGraficos.TextBox m_txtQuantidadeEmbalagem;
			private System.Windows.Forms.Label m_lbQuantidadeEmbalagem;
			private System.Windows.Forms.Button m_btVolumeUnidadeAltura;
			private mdlComponentesGraficos.TextBox m_txtVolumeAltura;
			private System.Windows.Forms.Label m_lbVolumeAltura;
			private System.Windows.Forms.Button m_btVolumeUnidadeComprimento;
			private mdlComponentesGraficos.TextBox m_txtVolumeComprimento;
			private System.Windows.Forms.Label m_lbVolumeComprimento;
			private System.Windows.Forms.Button m_btVolumeUnidadeLargura;
			private mdlComponentesGraficos.TextBox m_txtVolumeLargura;
			private System.Windows.Forms.Label m_lbVolumeLargura;
			private System.Windows.Forms.ImageList m_ilVolumes;
		private System.Windows.Forms.GroupBox m_gbComposicao;
		private System.Windows.Forms.GroupBox m_gbNacionalidade;
		private System.Windows.Forms.Label m_lbProdutoNacional2;
		private mdlComponentesGraficos.TextBox m_txtPercentagem;
		private System.Windows.Forms.Label m_lbProdutoNacional1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton m_rdbtNao;
		private System.Windows.Forms.RadioButton m_rdbtSim;
			private System.ComponentModel.IContainer components;
		#endregion
		#region Propriedades
			public bool Confirmed
			{
				get
				{
					return(m_bConfirmed);
				}
			}
		#endregion
		#region Constructors
		public frmFAtributos(string strEnderecoExecutavel,int nIdProduto)
		{
			m_nIdProduto = nIdProduto;
			InitializeComponent();
			vMostraCor(strEnderecoExecutavel);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFAtributos));
			this.m_gbMain = new System.Windows.Forms.GroupBox();
			this.m_gbVolume = new System.Windows.Forms.GroupBox();
			this.m_gbVolumeTamanho = new System.Windows.Forms.GroupBox();
			this.m_btVolumeUnidadeAltura = new System.Windows.Forms.Button();
			this.m_txtVolumeAltura = new mdlComponentesGraficos.TextBox();
			this.m_lbVolumeAltura = new System.Windows.Forms.Label();
			this.m_btVolumeUnidadeComprimento = new System.Windows.Forms.Button();
			this.m_txtVolumeComprimento = new mdlComponentesGraficos.TextBox();
			this.m_lbVolumeComprimento = new System.Windows.Forms.Label();
			this.m_btVolumeUnidadeLargura = new System.Windows.Forms.Button();
			this.m_txtVolumeLargura = new mdlComponentesGraficos.TextBox();
			this.m_lbVolumeLargura = new System.Windows.Forms.Label();
			this.m_txtVolumeTipoPopular = new mdlComponentesGraficos.TextBox();
			this.m_btUnidadeVolume = new System.Windows.Forms.Button();
			this.m_ilVolumes = new System.Windows.Forms.ImageList(this.components);
			this.m_lbQuantidadeVolume = new System.Windows.Forms.Label();
			this.m_txtQuantidadeVolume = new mdlComponentesGraficos.TextBox();
			this.m_gbEmbalagem = new System.Windows.Forms.GroupBox();
			this.m_txtEmbalagensVolume = new mdlComponentesGraficos.TextBox();
			this.m_lbEmbalagensVolume = new System.Windows.Forms.Label();
			this.m_txtQuantidadeEmbalagem = new mdlComponentesGraficos.TextBox();
			this.m_lbQuantidadeEmbalagem = new System.Windows.Forms.Label();
			this.m_gbTamanho = new System.Windows.Forms.GroupBox();
			this.m_btUnidadeAltura = new System.Windows.Forms.Button();
			this.m_txtAltura = new mdlComponentesGraficos.TextBox();
			this.m_lbAltura = new System.Windows.Forms.Label();
			this.m_btUnidadeComprimento = new System.Windows.Forms.Button();
			this.m_txtComprimento = new mdlComponentesGraficos.TextBox();
			this.m_lbComprimento = new System.Windows.Forms.Label();
			this.m_btUnidadeLargura = new System.Windows.Forms.Button();
			this.m_txtLargura = new mdlComponentesGraficos.TextBox();
			this.m_lbLargura = new System.Windows.Forms.Label();
			this.m_gbPesos = new System.Windows.Forms.GroupBox();
			this.m_btUnidadePesoBruto = new System.Windows.Forms.Button();
			this.m_txtPesoBrutoUnitario = new mdlComponentesGraficos.TextBox();
			this.m_lbPesoBrutoUnitario = new System.Windows.Forms.Label();
			this.m_btUnidadePesoLiquido = new System.Windows.Forms.Button();
			this.m_txtPesoLiquidoUnitario = new mdlComponentesGraficos.TextBox();
			this.m_lbPesoLiquidoUnitario = new System.Windows.Forms.Label();
			this.m_gbProdutos = new System.Windows.Forms.GroupBox();
			this.m_txtDescricao = new System.Windows.Forms.TextBox();
			this.m_lbDescricao = new System.Windows.Forms.Label();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbComposicao = new System.Windows.Forms.GroupBox();
			this.m_gbNacionalidade = new System.Windows.Forms.GroupBox();
			this.m_lbProdutoNacional2 = new System.Windows.Forms.Label();
			this.m_txtPercentagem = new mdlComponentesGraficos.TextBox();
			this.m_lbProdutoNacional1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.m_rdbtNao = new System.Windows.Forms.RadioButton();
			this.m_rdbtSim = new System.Windows.Forms.RadioButton();
			this.m_gbMain.SuspendLayout();
			this.m_gbVolume.SuspendLayout();
			this.m_gbVolumeTamanho.SuspendLayout();
			this.m_gbEmbalagem.SuspendLayout();
			this.m_gbTamanho.SuspendLayout();
			this.m_gbPesos.SuspendLayout();
			this.m_gbProdutos.SuspendLayout();
			this.m_gbComposicao.SuspendLayout();
			this.m_gbNacionalidade.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbMain
			// 
			this.m_gbMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbMain.Controls.Add(this.m_gbComposicao);
			this.m_gbMain.Controls.Add(this.m_gbVolume);
			this.m_gbMain.Controls.Add(this.m_gbEmbalagem);
			this.m_gbMain.Controls.Add(this.m_gbTamanho);
			this.m_gbMain.Controls.Add(this.m_gbPesos);
			this.m_gbMain.Controls.Add(this.m_gbProdutos);
			this.m_gbMain.Controls.Add(this.m_btOk);
			this.m_gbMain.Controls.Add(this.m_btCancelar);
			this.m_gbMain.Location = new System.Drawing.Point(3, -1);
			this.m_gbMain.Name = "m_gbMain";
			this.m_gbMain.Size = new System.Drawing.Size(587, 468);
			this.m_gbMain.TabIndex = 0;
			this.m_gbMain.TabStop = false;
			// 
			// m_gbVolume
			// 
			this.m_gbVolume.Controls.Add(this.m_gbVolumeTamanho);
			this.m_gbVolume.Controls.Add(this.m_txtVolumeTipoPopular);
			this.m_gbVolume.Controls.Add(this.m_btUnidadeVolume);
			this.m_gbVolume.Controls.Add(this.m_lbQuantidadeVolume);
			this.m_gbVolume.Controls.Add(this.m_txtQuantidadeVolume);
			this.m_gbVolume.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbVolume.Location = new System.Drawing.Point(6, 151);
			this.m_gbVolume.Name = "m_gbVolume";
			this.m_gbVolume.Size = new System.Drawing.Size(578, 97);
			this.m_gbVolume.TabIndex = 10;
			this.m_gbVolume.TabStop = false;
			this.m_gbVolume.Text = "Volume";
			// 
			// m_gbVolumeTamanho
			// 
			this.m_gbVolumeTamanho.Controls.Add(this.m_btVolumeUnidadeAltura);
			this.m_gbVolumeTamanho.Controls.Add(this.m_txtVolumeAltura);
			this.m_gbVolumeTamanho.Controls.Add(this.m_lbVolumeAltura);
			this.m_gbVolumeTamanho.Controls.Add(this.m_btVolumeUnidadeComprimento);
			this.m_gbVolumeTamanho.Controls.Add(this.m_txtVolumeComprimento);
			this.m_gbVolumeTamanho.Controls.Add(this.m_lbVolumeComprimento);
			this.m_gbVolumeTamanho.Controls.Add(this.m_btVolumeUnidadeLargura);
			this.m_gbVolumeTamanho.Controls.Add(this.m_txtVolumeLargura);
			this.m_gbVolumeTamanho.Controls.Add(this.m_lbVolumeLargura);
			this.m_gbVolumeTamanho.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbVolumeTamanho.Location = new System.Drawing.Point(4, 43);
			this.m_gbVolumeTamanho.Name = "m_gbVolumeTamanho";
			this.m_gbVolumeTamanho.Size = new System.Drawing.Size(570, 48);
			this.m_gbVolumeTamanho.TabIndex = 79;
			this.m_gbVolumeTamanho.TabStop = false;
			this.m_gbVolumeTamanho.Text = "Tamanho";
			// 
			// m_btVolumeUnidadeAltura
			// 
			this.m_btVolumeUnidadeAltura.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btVolumeUnidadeAltura.Location = new System.Drawing.Point(529, 9);
			this.m_btVolumeUnidadeAltura.Name = "m_btVolumeUnidadeAltura";
			this.m_btVolumeUnidadeAltura.Size = new System.Drawing.Size(32, 32);
			this.m_btVolumeUnidadeAltura.TabIndex = 11;
			this.m_btVolumeUnidadeAltura.Text = "cm";
			this.m_btVolumeUnidadeAltura.Click += new System.EventHandler(this.m_btVolumeUnidadeAltura_Click);
			// 
			// m_txtVolumeAltura
			// 
			this.m_txtVolumeAltura.Location = new System.Drawing.Point(457, 17);
			this.m_txtVolumeAltura.Name = "m_txtVolumeAltura";
			this.m_txtVolumeAltura.OnlyNumbers = true;
			this.m_txtVolumeAltura.Size = new System.Drawing.Size(62, 20);
			this.m_txtVolumeAltura.TabIndex = 10;
			this.m_txtVolumeAltura.Text = "";
			this.m_txtVolumeAltura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_lbVolumeAltura
			// 
			this.m_lbVolumeAltura.Location = new System.Drawing.Point(402, 19);
			this.m_lbVolumeAltura.Name = "m_lbVolumeAltura";
			this.m_lbVolumeAltura.Size = new System.Drawing.Size(56, 16);
			this.m_lbVolumeAltura.TabIndex = 9;
			this.m_lbVolumeAltura.Text = "Altura:";
			// 
			// m_btVolumeUnidadeComprimento
			// 
			this.m_btVolumeUnidadeComprimento.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btVolumeUnidadeComprimento.Location = new System.Drawing.Point(352, 11);
			this.m_btVolumeUnidadeComprimento.Name = "m_btVolumeUnidadeComprimento";
			this.m_btVolumeUnidadeComprimento.Size = new System.Drawing.Size(32, 32);
			this.m_btVolumeUnidadeComprimento.TabIndex = 8;
			this.m_btVolumeUnidadeComprimento.Text = "cm";
			this.m_btVolumeUnidadeComprimento.Click += new System.EventHandler(this.m_btVolumeUnidadeComprimento_Click);
			// 
			// m_txtVolumeComprimento
			// 
			this.m_txtVolumeComprimento.Location = new System.Drawing.Point(285, 18);
			this.m_txtVolumeComprimento.Name = "m_txtVolumeComprimento";
			this.m_txtVolumeComprimento.OnlyNumbers = true;
			this.m_txtVolumeComprimento.Size = new System.Drawing.Size(62, 20);
			this.m_txtVolumeComprimento.TabIndex = 7;
			this.m_txtVolumeComprimento.Text = "";
			this.m_txtVolumeComprimento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_lbVolumeComprimento
			// 
			this.m_lbVolumeComprimento.Location = new System.Drawing.Point(200, 20);
			this.m_lbVolumeComprimento.Name = "m_lbVolumeComprimento";
			this.m_lbVolumeComprimento.Size = new System.Drawing.Size(87, 16);
			this.m_lbVolumeComprimento.TabIndex = 6;
			this.m_lbVolumeComprimento.Text = "Comprimento:";
			// 
			// m_btVolumeUnidadeLargura
			// 
			this.m_btVolumeUnidadeLargura.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btVolumeUnidadeLargura.Location = new System.Drawing.Point(124, 11);
			this.m_btVolumeUnidadeLargura.Name = "m_btVolumeUnidadeLargura";
			this.m_btVolumeUnidadeLargura.Size = new System.Drawing.Size(32, 32);
			this.m_btVolumeUnidadeLargura.TabIndex = 5;
			this.m_btVolumeUnidadeLargura.Text = "cm";
			this.m_btVolumeUnidadeLargura.Click += new System.EventHandler(this.m_btVolumeUnidadeLargura_Click);
			// 
			// m_txtVolumeLargura
			// 
			this.m_txtVolumeLargura.Location = new System.Drawing.Point(57, 18);
			this.m_txtVolumeLargura.Name = "m_txtVolumeLargura";
			this.m_txtVolumeLargura.OnlyNumbers = true;
			this.m_txtVolumeLargura.Size = new System.Drawing.Size(62, 20);
			this.m_txtVolumeLargura.TabIndex = 4;
			this.m_txtVolumeLargura.Text = "";
			this.m_txtVolumeLargura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_lbVolumeLargura
			// 
			this.m_lbVolumeLargura.Location = new System.Drawing.Point(6, 21);
			this.m_lbVolumeLargura.Name = "m_lbVolumeLargura";
			this.m_lbVolumeLargura.Size = new System.Drawing.Size(56, 16);
			this.m_lbVolumeLargura.TabIndex = 3;
			this.m_lbVolumeLargura.Text = "Largura:";
			// 
			// m_txtVolumeTipoPopular
			// 
			this.m_txtVolumeTipoPopular.Location = new System.Drawing.Point(41, 17);
			this.m_txtVolumeTipoPopular.Name = "m_txtVolumeTipoPopular";
			this.m_txtVolumeTipoPopular.Size = new System.Drawing.Size(255, 20);
			this.m_txtVolumeTipoPopular.TabIndex = 78;
			this.m_txtVolumeTipoPopular.Text = "";
			// 
			// m_btUnidadeVolume
			// 
			this.m_btUnidadeVolume.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btUnidadeVolume.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.m_btUnidadeVolume.ImageIndex = 0;
			this.m_btUnidadeVolume.ImageList = this.m_ilVolumes;
			this.m_btUnidadeVolume.Location = new System.Drawing.Point(8, 16);
			this.m_btUnidadeVolume.Name = "m_btUnidadeVolume";
			this.m_btUnidadeVolume.Size = new System.Drawing.Size(27, 26);
			this.m_btUnidadeVolume.TabIndex = 77;
			this.m_btUnidadeVolume.Click += new System.EventHandler(this.m_btUnidadeVolume_Click);
			// 
			// m_ilVolumes
			// 
			this.m_ilVolumes.ImageSize = new System.Drawing.Size(16, 16);
			this.m_ilVolumes.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_ilVolumes.ImageStream")));
			this.m_ilVolumes.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// m_lbQuantidadeVolume
			// 
			this.m_lbQuantidadeVolume.Location = new System.Drawing.Point(305, 18);
			this.m_lbQuantidadeVolume.Name = "m_lbQuantidadeVolume";
			this.m_lbQuantidadeVolume.Size = new System.Drawing.Size(184, 16);
			this.m_lbQuantidadeVolume.TabIndex = 5;
			this.m_lbQuantidadeVolume.Text = "Quantidade produto por Volume:";
			// 
			// m_txtQuantidadeVolume
			// 
			this.m_txtQuantidadeVolume.Location = new System.Drawing.Point(496, 15);
			this.m_txtQuantidadeVolume.Name = "m_txtQuantidadeVolume";
			this.m_txtQuantidadeVolume.OnlyNumbers = true;
			this.m_txtQuantidadeVolume.Size = new System.Drawing.Size(62, 20);
			this.m_txtQuantidadeVolume.TabIndex = 6;
			this.m_txtQuantidadeVolume.Text = "";
			this.m_txtQuantidadeVolume.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_gbEmbalagem
			// 
			this.m_gbEmbalagem.Controls.Add(this.m_txtEmbalagensVolume);
			this.m_gbEmbalagem.Controls.Add(this.m_lbEmbalagensVolume);
			this.m_gbEmbalagem.Controls.Add(this.m_txtQuantidadeEmbalagem);
			this.m_gbEmbalagem.Controls.Add(this.m_lbQuantidadeEmbalagem);
			this.m_gbEmbalagem.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbEmbalagem.Location = new System.Drawing.Point(6, 250);
			this.m_gbEmbalagem.Name = "m_gbEmbalagem";
			this.m_gbEmbalagem.Size = new System.Drawing.Size(576, 48);
			this.m_gbEmbalagem.TabIndex = 9;
			this.m_gbEmbalagem.TabStop = false;
			this.m_gbEmbalagem.Text = "Embalagem";
			// 
			// m_txtEmbalagensVolume
			// 
			this.m_txtEmbalagensVolume.Location = new System.Drawing.Point(497, 15);
			this.m_txtEmbalagensVolume.Name = "m_txtEmbalagensVolume";
			this.m_txtEmbalagensVolume.OnlyNumbers = true;
			this.m_txtEmbalagensVolume.Size = new System.Drawing.Size(62, 20);
			this.m_txtEmbalagensVolume.TabIndex = 10;
			this.m_txtEmbalagensVolume.Text = "";
			this.m_txtEmbalagensVolume.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_lbEmbalagensVolume
			// 
			this.m_lbEmbalagensVolume.Location = new System.Drawing.Point(346, 19);
			this.m_lbEmbalagensVolume.Name = "m_lbEmbalagensVolume";
			this.m_lbEmbalagensVolume.Size = new System.Drawing.Size(147, 16);
			this.m_lbEmbalagensVolume.TabIndex = 9;
			this.m_lbEmbalagensVolume.Text = "Embalagens por Volume:";
			// 
			// m_txtQuantidadeEmbalagem
			// 
			this.m_txtQuantidadeEmbalagem.Location = new System.Drawing.Point(214, 16);
			this.m_txtQuantidadeEmbalagem.Name = "m_txtQuantidadeEmbalagem";
			this.m_txtQuantidadeEmbalagem.OnlyNumbers = true;
			this.m_txtQuantidadeEmbalagem.Size = new System.Drawing.Size(62, 20);
			this.m_txtQuantidadeEmbalagem.TabIndex = 8;
			this.m_txtQuantidadeEmbalagem.Text = "";
			this.m_txtQuantidadeEmbalagem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_lbQuantidadeEmbalagem
			// 
			this.m_lbQuantidadeEmbalagem.Location = new System.Drawing.Point(6, 19);
			this.m_lbQuantidadeEmbalagem.Name = "m_lbQuantidadeEmbalagem";
			this.m_lbQuantidadeEmbalagem.Size = new System.Drawing.Size(208, 16);
			this.m_lbQuantidadeEmbalagem.TabIndex = 7;
			this.m_lbQuantidadeEmbalagem.Text = "Quantidade Produto Por Embalagem:";
			// 
			// m_gbTamanho
			// 
			this.m_gbTamanho.Controls.Add(this.m_btUnidadeAltura);
			this.m_gbTamanho.Controls.Add(this.m_txtAltura);
			this.m_gbTamanho.Controls.Add(this.m_lbAltura);
			this.m_gbTamanho.Controls.Add(this.m_btUnidadeComprimento);
			this.m_gbTamanho.Controls.Add(this.m_txtComprimento);
			this.m_gbTamanho.Controls.Add(this.m_lbComprimento);
			this.m_gbTamanho.Controls.Add(this.m_btUnidadeLargura);
			this.m_gbTamanho.Controls.Add(this.m_txtLargura);
			this.m_gbTamanho.Controls.Add(this.m_lbLargura);
			this.m_gbTamanho.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbTamanho.Location = new System.Drawing.Point(6, 104);
			this.m_gbTamanho.Name = "m_gbTamanho";
			this.m_gbTamanho.Size = new System.Drawing.Size(577, 48);
			this.m_gbTamanho.TabIndex = 8;
			this.m_gbTamanho.TabStop = false;
			this.m_gbTamanho.Text = "Tamanho";
			// 
			// m_btUnidadeAltura
			// 
			this.m_btUnidadeAltura.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btUnidadeAltura.Location = new System.Drawing.Point(529, 9);
			this.m_btUnidadeAltura.Name = "m_btUnidadeAltura";
			this.m_btUnidadeAltura.Size = new System.Drawing.Size(32, 32);
			this.m_btUnidadeAltura.TabIndex = 11;
			this.m_btUnidadeAltura.Text = "cm";
			this.m_btUnidadeAltura.Click += new System.EventHandler(this.m_btUnidadeAltura_Click);
			// 
			// m_txtAltura
			// 
			this.m_txtAltura.Location = new System.Drawing.Point(457, 17);
			this.m_txtAltura.Name = "m_txtAltura";
			this.m_txtAltura.OnlyNumbers = true;
			this.m_txtAltura.Size = new System.Drawing.Size(62, 20);
			this.m_txtAltura.TabIndex = 10;
			this.m_txtAltura.Text = "";
			this.m_txtAltura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_lbAltura
			// 
			this.m_lbAltura.Location = new System.Drawing.Point(402, 19);
			this.m_lbAltura.Name = "m_lbAltura";
			this.m_lbAltura.Size = new System.Drawing.Size(56, 16);
			this.m_lbAltura.TabIndex = 9;
			this.m_lbAltura.Text = "Altura:";
			// 
			// m_btUnidadeComprimento
			// 
			this.m_btUnidadeComprimento.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btUnidadeComprimento.Location = new System.Drawing.Point(352, 11);
			this.m_btUnidadeComprimento.Name = "m_btUnidadeComprimento";
			this.m_btUnidadeComprimento.Size = new System.Drawing.Size(32, 32);
			this.m_btUnidadeComprimento.TabIndex = 8;
			this.m_btUnidadeComprimento.Text = "cm";
			this.m_btUnidadeComprimento.Click += new System.EventHandler(this.m_btUnidadeComprimento_Click);
			// 
			// m_txtComprimento
			// 
			this.m_txtComprimento.Location = new System.Drawing.Point(285, 18);
			this.m_txtComprimento.Name = "m_txtComprimento";
			this.m_txtComprimento.OnlyNumbers = true;
			this.m_txtComprimento.Size = new System.Drawing.Size(62, 20);
			this.m_txtComprimento.TabIndex = 7;
			this.m_txtComprimento.Text = "";
			this.m_txtComprimento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_lbComprimento
			// 
			this.m_lbComprimento.Location = new System.Drawing.Point(200, 20);
			this.m_lbComprimento.Name = "m_lbComprimento";
			this.m_lbComprimento.Size = new System.Drawing.Size(87, 16);
			this.m_lbComprimento.TabIndex = 6;
			this.m_lbComprimento.Text = "Comprimento:";
			// 
			// m_btUnidadeLargura
			// 
			this.m_btUnidadeLargura.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btUnidadeLargura.Location = new System.Drawing.Point(124, 11);
			this.m_btUnidadeLargura.Name = "m_btUnidadeLargura";
			this.m_btUnidadeLargura.Size = new System.Drawing.Size(32, 32);
			this.m_btUnidadeLargura.TabIndex = 5;
			this.m_btUnidadeLargura.Text = "cm";
			this.m_btUnidadeLargura.Click += new System.EventHandler(this.m_btUnidadeLargura_Click);
			// 
			// m_txtLargura
			// 
			this.m_txtLargura.Location = new System.Drawing.Point(57, 18);
			this.m_txtLargura.Name = "m_txtLargura";
			this.m_txtLargura.OnlyNumbers = true;
			this.m_txtLargura.Size = new System.Drawing.Size(62, 20);
			this.m_txtLargura.TabIndex = 4;
			this.m_txtLargura.Text = "";
			this.m_txtLargura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_lbLargura
			// 
			this.m_lbLargura.Location = new System.Drawing.Point(6, 21);
			this.m_lbLargura.Name = "m_lbLargura";
			this.m_lbLargura.Size = new System.Drawing.Size(56, 16);
			this.m_lbLargura.TabIndex = 3;
			this.m_lbLargura.Text = "Largura:";
			// 
			// m_gbPesos
			// 
			this.m_gbPesos.Controls.Add(this.m_btUnidadePesoBruto);
			this.m_gbPesos.Controls.Add(this.m_txtPesoBrutoUnitario);
			this.m_gbPesos.Controls.Add(this.m_lbPesoBrutoUnitario);
			this.m_gbPesos.Controls.Add(this.m_btUnidadePesoLiquido);
			this.m_gbPesos.Controls.Add(this.m_txtPesoLiquidoUnitario);
			this.m_gbPesos.Controls.Add(this.m_lbPesoLiquidoUnitario);
			this.m_gbPesos.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbPesos.Location = new System.Drawing.Point(6, 56);
			this.m_gbPesos.Name = "m_gbPesos";
			this.m_gbPesos.Size = new System.Drawing.Size(577, 48);
			this.m_gbPesos.TabIndex = 7;
			this.m_gbPesos.TabStop = false;
			this.m_gbPesos.Text = "Pesos";
			// 
			// m_btUnidadePesoBruto
			// 
			this.m_btUnidadePesoBruto.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btUnidadePesoBruto.Location = new System.Drawing.Point(529, 10);
			this.m_btUnidadePesoBruto.Name = "m_btUnidadePesoBruto";
			this.m_btUnidadePesoBruto.Size = new System.Drawing.Size(32, 32);
			this.m_btUnidadePesoBruto.TabIndex = 6;
			this.m_btUnidadePesoBruto.Text = "Kg";
			this.m_btUnidadePesoBruto.Click += new System.EventHandler(this.m_btUnidadePesoBruto_Click);
			// 
			// m_txtPesoBrutoUnitario
			// 
			this.m_txtPesoBrutoUnitario.Location = new System.Drawing.Point(433, 16);
			this.m_txtPesoBrutoUnitario.Name = "m_txtPesoBrutoUnitario";
			this.m_txtPesoBrutoUnitario.OnlyNumbers = true;
			this.m_txtPesoBrutoUnitario.Size = new System.Drawing.Size(95, 20);
			this.m_txtPesoBrutoUnitario.TabIndex = 5;
			this.m_txtPesoBrutoUnitario.Text = "";
			this.m_txtPesoBrutoUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_lbPesoBrutoUnitario
			// 
			this.m_lbPesoBrutoUnitario.Location = new System.Drawing.Point(337, 19);
			this.m_lbPesoBrutoUnitario.Name = "m_lbPesoBrutoUnitario";
			this.m_lbPesoBrutoUnitario.Size = new System.Drawing.Size(104, 16);
			this.m_lbPesoBrutoUnitario.TabIndex = 4;
			this.m_lbPesoBrutoUnitario.Text = "Bruto Unitário:";
			// 
			// m_btUnidadePesoLiquido
			// 
			this.m_btUnidadePesoLiquido.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btUnidadePesoLiquido.Location = new System.Drawing.Point(202, 10);
			this.m_btUnidadePesoLiquido.Name = "m_btUnidadePesoLiquido";
			this.m_btUnidadePesoLiquido.Size = new System.Drawing.Size(32, 32);
			this.m_btUnidadePesoLiquido.TabIndex = 3;
			this.m_btUnidadePesoLiquido.Text = "Kg";
			this.m_btUnidadePesoLiquido.Click += new System.EventHandler(this.m_btUnidadePesoLiquido_Click);
			// 
			// m_txtPesoLiquidoUnitario
			// 
			this.m_txtPesoLiquidoUnitario.Location = new System.Drawing.Point(101, 15);
			this.m_txtPesoLiquidoUnitario.Name = "m_txtPesoLiquidoUnitario";
			this.m_txtPesoLiquidoUnitario.OnlyNumbers = true;
			this.m_txtPesoLiquidoUnitario.Size = new System.Drawing.Size(95, 20);
			this.m_txtPesoLiquidoUnitario.TabIndex = 2;
			this.m_txtPesoLiquidoUnitario.Text = "";
			this.m_txtPesoLiquidoUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_lbPesoLiquidoUnitario
			// 
			this.m_lbPesoLiquidoUnitario.Location = new System.Drawing.Point(5, 18);
			this.m_lbPesoLiquidoUnitario.Name = "m_lbPesoLiquidoUnitario";
			this.m_lbPesoLiquidoUnitario.Size = new System.Drawing.Size(104, 16);
			this.m_lbPesoLiquidoUnitario.TabIndex = 1;
			this.m_lbPesoLiquidoUnitario.Text = "Liquido Unitário:";
			// 
			// m_gbProdutos
			// 
			this.m_gbProdutos.Controls.Add(this.m_txtDescricao);
			this.m_gbProdutos.Controls.Add(this.m_lbDescricao);
			this.m_gbProdutos.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbProdutos.Location = new System.Drawing.Point(6, 9);
			this.m_gbProdutos.Name = "m_gbProdutos";
			this.m_gbProdutos.Size = new System.Drawing.Size(577, 47);
			this.m_gbProdutos.TabIndex = 6;
			this.m_gbProdutos.TabStop = false;
			this.m_gbProdutos.Text = "Produto";
			// 
			// m_txtDescricao
			// 
			this.m_txtDescricao.Location = new System.Drawing.Point(72, 14);
			this.m_txtDescricao.Name = "m_txtDescricao";
			this.m_txtDescricao.ReadOnly = true;
			this.m_txtDescricao.Size = new System.Drawing.Size(496, 20);
			this.m_txtDescricao.TabIndex = 1;
			this.m_txtDescricao.Text = "";
			// 
			// m_lbDescricao
			// 
			this.m_lbDescricao.Location = new System.Drawing.Point(8, 17);
			this.m_lbDescricao.Name = "m_lbDescricao";
			this.m_lbDescricao.Size = new System.Drawing.Size(64, 16);
			this.m_lbDescricao.TabIndex = 0;
			this.m_lbDescricao.Text = "Descrição:";
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(234, 435);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 4;
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(298, 435);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 5;
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbComposicao
			// 
			this.m_gbComposicao.Controls.Add(this.m_gbNacionalidade);
			this.m_gbComposicao.Controls.Add(this.groupBox1);
			this.m_gbComposicao.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbComposicao.Location = new System.Drawing.Point(6, 298);
			this.m_gbComposicao.Name = "m_gbComposicao";
			this.m_gbComposicao.Size = new System.Drawing.Size(576, 128);
			this.m_gbComposicao.TabIndex = 11;
			this.m_gbComposicao.TabStop = false;
			this.m_gbComposicao.Text = "Composição";
			// 
			// m_gbNacionalidade
			// 
			this.m_gbNacionalidade.Controls.Add(this.m_lbProdutoNacional2);
			this.m_gbNacionalidade.Controls.Add(this.m_txtPercentagem);
			this.m_gbNacionalidade.Controls.Add(this.m_lbProdutoNacional1);
			this.m_gbNacionalidade.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbNacionalidade.Location = new System.Drawing.Point(5, 70);
			this.m_gbNacionalidade.Name = "m_gbNacionalidade";
			this.m_gbNacionalidade.Size = new System.Drawing.Size(555, 48);
			this.m_gbNacionalidade.TabIndex = 21;
			this.m_gbNacionalidade.TabStop = false;
			this.m_gbNacionalidade.Text = "Composição do Produto";
			// 
			// m_lbProdutoNacional2
			// 
			this.m_lbProdutoNacional2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbProdutoNacional2.Location = new System.Drawing.Point(221, 18);
			this.m_lbProdutoNacional2.Name = "m_lbProdutoNacional2";
			this.m_lbProdutoNacional2.Size = new System.Drawing.Size(167, 16);
			this.m_lbProdutoNacional2.TabIndex = 2;
			this.m_lbProdutoNacional2.Text = "% de material nacional.";
			// 
			// m_txtPercentagem
			// 
			this.m_txtPercentagem.Location = new System.Drawing.Point(171, 15);
			this.m_txtPercentagem.MaxDecimalNumbers = 2;
			this.m_txtPercentagem.Name = "m_txtPercentagem";
			this.m_txtPercentagem.OnlyNumbers = true;
			this.m_txtPercentagem.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.m_txtPercentagem.Size = new System.Drawing.Size(45, 20);
			this.m_txtPercentagem.TabIndex = 1;
			this.m_txtPercentagem.Text = "100";
			// 
			// m_lbProdutoNacional1
			// 
			this.m_lbProdutoNacional1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbProdutoNacional1.Location = new System.Drawing.Point(9, 18);
			this.m_lbProdutoNacional1.Name = "m_lbProdutoNacional1";
			this.m_lbProdutoNacional1.Size = new System.Drawing.Size(167, 16);
			this.m_lbProdutoNacional1.TabIndex = 0;
			this.m_lbProdutoNacional1.Text = "Este produto é composto de ";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.m_rdbtNao);
			this.groupBox1.Controls.Add(this.m_rdbtSim);
			this.groupBox1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(5, 13);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(555, 56);
			this.groupBox1.TabIndex = 20;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Este produto foi produzido utilizando material importado ?";
			// 
			// m_rdbtNao
			// 
			this.m_rdbtNao.Location = new System.Drawing.Point(8, 32);
			this.m_rdbtNao.Name = "m_rdbtNao";
			this.m_rdbtNao.Size = new System.Drawing.Size(152, 16);
			this.m_rdbtNao.TabIndex = 1;
			this.m_rdbtNao.Text = "Não";
			// 
			// m_rdbtSim
			// 
			this.m_rdbtSim.Location = new System.Drawing.Point(8, 16);
			this.m_rdbtSim.Name = "m_rdbtSim";
			this.m_rdbtSim.Size = new System.Drawing.Size(152, 16);
			this.m_rdbtSim.TabIndex = 0;
			this.m_rdbtSim.Text = "Sim";
			this.m_rdbtSim.CheckedChanged += new System.EventHandler(this.m_rdbtSim_CheckedChanged);
			// 
			// frmFAtributos
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(594, 468);
			this.Controls.Add(this.m_gbMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFAtributos";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Atributos";
			this.Load += new System.EventHandler(this.frmFAtributos_Load);
			this.m_gbMain.ResumeLayout(false);
			this.m_gbVolume.ResumeLayout(false);
			this.m_gbVolumeTamanho.ResumeLayout(false);
			this.m_gbEmbalagem.ResumeLayout(false);
			this.m_gbTamanho.ResumeLayout(false);
			this.m_gbPesos.ResumeLayout(false);
			this.m_gbProdutos.ResumeLayout(false);
			this.m_gbComposicao.ResumeLayout(false);
			this.m_gbNacionalidade.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Cores
			private void vMostraCor(string strEnderecoExecutavel)
			{
				mdlPaletaDeCores.clsPaletaDeCores clsPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(strEnderecoExecutavel + mdlConstantes.clsConstantes.DEFAULT_CONFIG_FILENAME,"SiscobrasCorSecundaria");
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
			#region Formulario
				private void frmFAtributos_Load(object sender, System.EventArgs e)
				{
					OnCallCarregaDados();
				}
			#endregion
			#region RadioButtons
			private void m_rdbtSim_CheckedChanged(object sender, System.EventArgs e)
			{
				RefreshInterface();
			}
			#endregion
			#region Buttons
				private void m_btUnidadePesoLiquido_Click(object sender, System.EventArgs e)
				{
					m_nUnidadePesoLiquido = clsProdutos.nRetornaProximaUnidadeMassa(m_nUnidadePesoLiquido);
					m_btUnidadePesoLiquido.Text = clsProdutos.strRetornaSiglaUnidadeMassa(m_nUnidadePesoLiquido);
				}

				private void m_btUnidadePesoBruto_Click(object sender, System.EventArgs e)
				{
					m_nUnidadePesoBruto = clsProdutos.nRetornaProximaUnidadeMassa(m_nUnidadePesoBruto);
					m_btUnidadePesoBruto.Text = clsProdutos.strRetornaSiglaUnidadeMassa(m_nUnidadePesoBruto);
				}

				private void m_btUnidadeLargura_Click(object sender, System.EventArgs e)
				{
					m_nUnidadeLargura = clsProdutos.nRetornaProximaUnidadeMetrica(m_nUnidadeLargura);
					m_btUnidadeLargura.Text = clsProdutos.strRetornaSiglaUnidadeMetrica(m_nUnidadeLargura);
				}

				private void m_btUnidadeComprimento_Click(object sender, System.EventArgs e)
				{
					m_nUnidadeComprimento = clsProdutos.nRetornaProximaUnidadeMetrica(m_nUnidadeComprimento);
					m_btUnidadeComprimento.Text = clsProdutos.strRetornaSiglaUnidadeMetrica(m_nUnidadeComprimento);
				}

				private void m_btUnidadeAltura_Click(object sender, System.EventArgs e)
				{
					m_nUnidadeAltura = clsProdutos.nRetornaProximaUnidadeMetrica(m_nUnidadeAltura);
					m_btUnidadeAltura.Text = clsProdutos.strRetornaSiglaUnidadeMetrica(m_nUnidadeAltura);
				}

				private void m_btUnidadeVolume_Click(object sender, System.EventArgs e)
				{
					if (OnCallShowVolumeTipo())
						OnCallCarregaVolumeTipo();
				}

				private void m_btVolumeUnidadeLargura_Click(object sender, System.EventArgs e)
				{
					m_nVolumeUnidadeLargura = clsProdutos.nRetornaProximaUnidadeMetrica(m_nVolumeUnidadeLargura);
					m_btVolumeUnidadeLargura.Text = clsProdutos.strRetornaSiglaUnidadeMetrica(m_nVolumeUnidadeLargura);
				}

				private void m_btVolumeUnidadeComprimento_Click(object sender, System.EventArgs e)
				{
					m_nVolumeUnidadeComprimento = clsProdutos.nRetornaProximaUnidadeMetrica(m_nVolumeUnidadeComprimento);
					m_btVolumeUnidadeComprimento.Text = clsProdutos.strRetornaSiglaUnidadeMetrica(m_nVolumeUnidadeComprimento);
				}

				private void m_btVolumeUnidadeAltura_Click(object sender, System.EventArgs e)
				{
					m_nVolumeUnidadeAltura = clsProdutos.nRetornaProximaUnidadeMetrica(m_nVolumeUnidadeAltura);
					m_btVolumeUnidadeAltura.Text = clsProdutos.strRetornaSiglaUnidadeMetrica(m_nVolumeUnidadeAltura);
				}

				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					if (OnCallSalvaDados())
					{
						m_bConfirmed = true;
						this.Close();
					}
				}

				private void m_btCancelar_Click(object sender, System.EventArgs e)
				{
					this.Close();
				}
			#endregion
		#endregion

		#region Refresh
		private void RefreshInterface()
		{
			m_gbNacionalidade.Enabled = m_rdbtSim.Checked;
			if (!m_rdbtSim.Checked)
			{
				m_txtPercentagem.Text = "100";	
			}
		}
		#endregion
	}
}
