using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlContainers.Formularios
{
	/// <summary>
	/// Summary description for frmFContainersEditar.
	/// </summary>
	internal class frmFContainersEditar : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate bool delCallContainersTipo(ref int nIdContainerTipo);
			public delegate bool delCallContainersText(int nIdContainerTipo,out string strContainerText);
			public delegate void delCallRefreshContainersTamanho(int nIdContainerTipo,ref mdlComponentesGraficos.ComboBox cbContainersTamanho);
			public delegate void delCallCarregaDados(int nIdContainer,out string strNumero,out int nIdContainerTipo,out string strContainerTipo,out string strContainerISO,out string strTamanho,out double dTara,out int nUnidadeTara,out string strLacre,out string strLacreArmador,out double dExcessoCargaAltura,out double dExcessoCargaLargura,out double dExcessoCargaComprimento,out int nUnidadeExcessoCargaAltura,out int nUnidadeExcessoCargaLargura,out int nUnidadeExcessoCargaComprimento,out string strTemperaturaMinima,out string strTemperaturaMaxima,out string strIMO,out string strUNO);
			public delegate bool delCallSalvaDados(int nIdContainer,string strNumero,int nIdContainerTipo,string strContainerTipo,string strContainerISO,string strTamanho,double dTara,int nUnidadeTara,string strLacre,string strLacreArmador,double dExcessoCargaAltura,double dExcessoCargaLargura,double dExcessoCargaComprimento,int nUnidadeExcessoCargaAltura,int nUnidadeExcessoCargaLargura,int nUnidadeExcessoCargaComprimento,string strTemperaturaMinima,string strTemperaturaMaxima,string strIMO,string strUNO);
		#endregion
		#region Events
			public event delCallContainersTipo eCallContainersTipo;
			public event delCallContainersText eCallContainersText;
			public event delCallRefreshContainersTamanho eCallRefreshContainersTamanho;
			public event delCallCarregaDados eCallCarregaDados;
			public event delCallSalvaDados eCallSalvaDados;
		#endregion
		#region Events Methods
			public virtual bool OnCallContainersTipo() 
			{
				bool bRetorno = false;
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallContainersTipo != null)
					bRetorno = eCallContainersTipo(ref m_nIdContainerTipo);
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bRetorno);
			}

			public virtual bool OnCallContainersText(bool bOnlyButton) 
			{
				bool bRetorno = false;
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallContainersText != null)
				{
					string strContainerTipo;
					if (bRetorno = eCallContainersText(m_nIdContainerTipo,out strContainerTipo))
					{
						m_btContainerTipo.Text = strContainerTipo;
						if (!bOnlyButton)
							m_txtContainerTipo.Text = strContainerTipo;
					}
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bRetorno);
			}

			public virtual void OnCallRefreshContainersTamanho() 
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallRefreshContainersTamanho != null)
				{
					eCallRefreshContainersTamanho(m_nIdContainerTipo,ref m_cbContainersTamanho);
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			public virtual void OnCallCarregaDados() 
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallCarregaDados != null)
				{
					string strNumero,strContainerTipo,strContainerISO,strTamanho,strLacre,strLacreArmador,strTemperaturaMinima,strTemperaturaMaxima,strIMO,strUNO;
					int nUnidadeTara,nUnidadeExcessoCargaAltura,nUnidadeExcessoCargaLargura,nUnidadeExcessoCargaComprimento;
					double dTara,dExcessoCargaAltura,dExcessoCargaLargura,dExcessoCargaComprimento;
					eCallCarregaDados(m_nIdContainer,out strNumero,out m_nIdContainerTipo,out strContainerTipo,out strContainerISO,out strTamanho,out dTara,out nUnidadeTara,out strLacre,out strLacreArmador,out dExcessoCargaAltura,out dExcessoCargaLargura,out dExcessoCargaComprimento,out nUnidadeExcessoCargaAltura,out nUnidadeExcessoCargaLargura,out nUnidadeExcessoCargaComprimento,out strTemperaturaMinima,out strTemperaturaMaxima,out strIMO,out strUNO);
					m_txtContainerNumero.Text = strNumero;
					m_txtContainerTipo.Text = strContainerTipo;
					m_txtContainerISO.Text = strContainerISO;
					m_cbContainersTamanho.Text = strTamanho;
					m_txtContainerTara.Text = dTara.ToString();
					m_enumUnidadeTara = (mdlConstantes.UnidadeMassa)nUnidadeTara;
					m_txtContainerLacre.Text = strLacre;
					m_txtContainerLacreArmador.Text = strLacreArmador;
					m_txtTemperaturaMinima.Text = strTemperaturaMinima;
					m_txtTemperaturaMaxima.Text = strTemperaturaMaxima;
					if (dExcessoCargaAltura != 0)
						m_txtExcessoCargaAltura.Text = dExcessoCargaAltura.ToString();
					if (dExcessoCargaLargura != 0)
						m_txtExcessoCargaLargura.Text = dExcessoCargaLargura.ToString();
					if (dExcessoCargaComprimento != 0)
						m_txtExcessoCargaComprimento.Text = dExcessoCargaComprimento.ToString();
					m_enumUnidadeAltura = (mdlConstantes.UnidadeMedida)nUnidadeExcessoCargaAltura;
					m_enumUnidadeLargura = (mdlConstantes.UnidadeMedida)nUnidadeExcessoCargaLargura;
					m_enumUnidadeComprimento = (mdlConstantes.UnidadeMedida)nUnidadeExcessoCargaComprimento;
					m_txtImo.Text = strIMO;
					m_txtUno.Text = strUNO;
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}
			
			public virtual bool OnCallSalvaDados() 
			{
				bool bRetorno = false;
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallSalvaDados != null)
				{
					double dAltura = 0,dLargura = 0,dComprimento = 0;
					if (m_txtExcessoCargaAltura.Text.Trim() != "")
						dAltura = double.Parse(m_txtExcessoCargaAltura.Text);
					if (m_txtExcessoCargaLargura.Text.Trim() != "")
						dLargura = double.Parse(m_txtExcessoCargaLargura.Text);
					if (m_txtExcessoCargaComprimento.Text.Trim() != "")
						dComprimento = double.Parse(m_txtExcessoCargaComprimento.Text);
					bRetorno = eCallSalvaDados(m_nIdContainer,m_txtContainerNumero.Text,m_nIdContainerTipo,m_txtContainerTipo.Text,m_txtContainerISO.Text,m_cbContainersTamanho.Text,double.Parse(m_txtContainerTara.Text),(int)m_enumUnidadeTara,m_txtContainerLacre.Text,m_txtContainerLacreArmador.Text,dAltura,dLargura,dComprimento,(int)m_enumUnidadeAltura,(int)m_enumUnidadeLargura,(int)m_enumUnidadeComprimento,m_txtTemperaturaMinima.Text,m_txtTemperaturaMaxima.Text,m_txtImo.Text,m_txtUno.Text);
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bRetorno);
			}
		#endregion

		#region Atributes
			public bool m_bModificado = false;

			private string m_strEnderecoExecutavel = "";

			private int m_nIdContainer = 0;
			private int m_nIdContainerTipo = 0;
			private mdlConstantes.UnidadeMassa m_enumUnidadeTara = mdlConstantes.UnidadeMassa.Kilograma;
			private mdlConstantes.UnidadeMedida m_enumUnidadeAltura = mdlConstantes.UnidadeMedida.Centimetro;
			private mdlConstantes.UnidadeMedida m_enumUnidadeLargura = mdlConstantes.UnidadeMedida.Centimetro;
			private mdlConstantes.UnidadeMedida m_enumUnidadeComprimento = mdlConstantes.UnidadeMedida.Centimetro;


			private System.Windows.Forms.GroupBox m_gbGeral;
			private System.Windows.Forms.GroupBox m_gbContainer;
			internal System.Windows.Forms.Button m_btContainerTaraUnidade;
			private mdlComponentesGraficos.TextBox m_txtContainerTara;
			private System.Windows.Forms.Label m_lbContainerTara;
			private mdlComponentesGraficos.TextBox m_txtContainerLacre;
			private System.Windows.Forms.Label m_lbContainerLacre;
			private System.Windows.Forms.Label m_lbContainerTamanho;
			private System.Windows.Forms.Button m_btContainerTipo;
			private System.Windows.Forms.Label m_lbContainerTipo;
			private mdlComponentesGraficos.TextBox m_txtContainerNumero;
			private System.Windows.Forms.Label m_lbContainerNumero;
			public System.Windows.Forms.Button m_btOk;
			public System.Windows.Forms.Button m_btCancelar;
			private mdlComponentesGraficos.ComboBox m_cbContainersTamanho;
			private mdlComponentesGraficos.TextBox m_txtContainerTipo;
			private System.Windows.Forms.Label m_lbContainerTipoPopular;
			private System.Windows.Forms.Label m_lbLacreArmador;
			private mdlComponentesGraficos.TextBox m_txtContainerLacreArmador;
			private System.Windows.Forms.Label m_lbTemperaturaMinima;
			private mdlComponentesGraficos.TextBox m_txtTemperaturaMinima;
			private mdlComponentesGraficos.TextBox m_txtTemperaturaMaxima;
			private System.Windows.Forms.GroupBox m_gbExcessoCarga;
			private System.Windows.Forms.Label m_lbImo;
			private mdlComponentesGraficos.TextBox m_txtImo;
			private mdlComponentesGraficos.TextBox m_txtUno;
			private System.Windows.Forms.Label m_lbUno;
			private System.Windows.Forms.Label m_lbTemperaturaMaxima;
			private System.Windows.Forms.Label m_lbExcessoCargaAltura;
			private System.Windows.Forms.Label m_lbExcessoCargaLargura;
			private System.Windows.Forms.Label m_lbExcessoCargaComprimento;
			private mdlComponentesGraficos.TextBox m_txtExcessoCargaAltura;
			private mdlComponentesGraficos.TextBox m_txtExcessoCargaLargura;
			private mdlComponentesGraficos.TextBox m_txtExcessoCargaComprimento;
			private System.Windows.Forms.GroupBox m_gbCargaPerigosa;
			internal System.Windows.Forms.Button m_btUnidadeAltura;
			internal System.Windows.Forms.Button m_btUnidadeLargura;
			internal System.Windows.Forms.Button m_btUnidadeComprimento;
		private System.Windows.Forms.GroupBox m_gbTemperatura;
		private mdlComponentesGraficos.TextBox m_txtContainerISO;
		private System.Windows.Forms.Label m_lbContainerISO;
			private System.ComponentModel.Container components = null;
		#endregion
		#region Constructors and Destructors
			public frmFContainersEditar(string strEnderecoExecutavel)
			{
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				m_nIdContainer = -1;
				InitializeComponent();
				this.Text = "Novo Container";
			}

			public frmFContainersEditar(string strEnderecoExecutavel,int nIdContainer)
			{
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				m_nIdContainer = nIdContainer;
				InitializeComponent();
				this.Text = "Edição Container";
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFContainersEditar));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_gbContainer = new System.Windows.Forms.GroupBox();
			this.m_txtContainerISO = new mdlComponentesGraficos.TextBox();
			this.m_lbContainerISO = new System.Windows.Forms.Label();
			this.m_gbCargaPerigosa = new System.Windows.Forms.GroupBox();
			this.m_txtUno = new mdlComponentesGraficos.TextBox();
			this.m_lbUno = new System.Windows.Forms.Label();
			this.m_txtImo = new mdlComponentesGraficos.TextBox();
			this.m_lbImo = new System.Windows.Forms.Label();
			this.m_gbExcessoCarga = new System.Windows.Forms.GroupBox();
			this.m_btUnidadeComprimento = new System.Windows.Forms.Button();
			this.m_btUnidadeLargura = new System.Windows.Forms.Button();
			this.m_btUnidadeAltura = new System.Windows.Forms.Button();
			this.m_txtExcessoCargaComprimento = new mdlComponentesGraficos.TextBox();
			this.m_txtExcessoCargaLargura = new mdlComponentesGraficos.TextBox();
			this.m_txtExcessoCargaAltura = new mdlComponentesGraficos.TextBox();
			this.m_lbExcessoCargaComprimento = new System.Windows.Forms.Label();
			this.m_lbExcessoCargaLargura = new System.Windows.Forms.Label();
			this.m_lbExcessoCargaAltura = new System.Windows.Forms.Label();
			this.m_gbTemperatura = new System.Windows.Forms.GroupBox();
			this.m_lbTemperaturaMaxima = new System.Windows.Forms.Label();
			this.m_txtTemperaturaMaxima = new mdlComponentesGraficos.TextBox();
			this.m_lbTemperaturaMinima = new System.Windows.Forms.Label();
			this.m_txtTemperaturaMinima = new mdlComponentesGraficos.TextBox();
			this.m_txtContainerLacreArmador = new mdlComponentesGraficos.TextBox();
			this.m_lbLacreArmador = new System.Windows.Forms.Label();
			this.m_txtContainerTipo = new mdlComponentesGraficos.TextBox();
			this.m_lbContainerTipoPopular = new System.Windows.Forms.Label();
			this.m_btContainerTaraUnidade = new System.Windows.Forms.Button();
			this.m_txtContainerTara = new mdlComponentesGraficos.TextBox();
			this.m_lbContainerTara = new System.Windows.Forms.Label();
			this.m_txtContainerLacre = new mdlComponentesGraficos.TextBox();
			this.m_lbContainerLacre = new System.Windows.Forms.Label();
			this.m_cbContainersTamanho = new mdlComponentesGraficos.ComboBox();
			this.m_lbContainerTamanho = new System.Windows.Forms.Label();
			this.m_btContainerTipo = new System.Windows.Forms.Button();
			this.m_lbContainerTipo = new System.Windows.Forms.Label();
			this.m_txtContainerNumero = new mdlComponentesGraficos.TextBox();
			this.m_lbContainerNumero = new System.Windows.Forms.Label();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbGeral.SuspendLayout();
			this.m_gbContainer.SuspendLayout();
			this.m_gbCargaPerigosa.SuspendLayout();
			this.m_gbExcessoCarga.SuspendLayout();
			this.m_gbTemperatura.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbGeral.Controls.Add(this.m_gbContainer);
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Location = new System.Drawing.Point(4, -1);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(260, 422);
			this.m_gbGeral.TabIndex = 0;
			this.m_gbGeral.TabStop = false;
			// 
			// m_gbContainer
			// 
			this.m_gbContainer.Controls.Add(this.m_txtContainerISO);
			this.m_gbContainer.Controls.Add(this.m_lbContainerISO);
			this.m_gbContainer.Controls.Add(this.m_gbCargaPerigosa);
			this.m_gbContainer.Controls.Add(this.m_gbExcessoCarga);
			this.m_gbContainer.Controls.Add(this.m_gbTemperatura);
			this.m_gbContainer.Controls.Add(this.m_txtContainerLacreArmador);
			this.m_gbContainer.Controls.Add(this.m_lbLacreArmador);
			this.m_gbContainer.Controls.Add(this.m_txtContainerTipo);
			this.m_gbContainer.Controls.Add(this.m_lbContainerTipoPopular);
			this.m_gbContainer.Controls.Add(this.m_btContainerTaraUnidade);
			this.m_gbContainer.Controls.Add(this.m_txtContainerTara);
			this.m_gbContainer.Controls.Add(this.m_lbContainerTara);
			this.m_gbContainer.Controls.Add(this.m_txtContainerLacre);
			this.m_gbContainer.Controls.Add(this.m_lbContainerLacre);
			this.m_gbContainer.Controls.Add(this.m_cbContainersTamanho);
			this.m_gbContainer.Controls.Add(this.m_lbContainerTamanho);
			this.m_gbContainer.Controls.Add(this.m_btContainerTipo);
			this.m_gbContainer.Controls.Add(this.m_lbContainerTipo);
			this.m_gbContainer.Controls.Add(this.m_txtContainerNumero);
			this.m_gbContainer.Controls.Add(this.m_lbContainerNumero);
			this.m_gbContainer.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbContainer.Location = new System.Drawing.Point(5, 7);
			this.m_gbContainer.Name = "m_gbContainer";
			this.m_gbContainer.Size = new System.Drawing.Size(248, 382);
			this.m_gbContainer.TabIndex = 0;
			this.m_gbContainer.TabStop = false;
			this.m_gbContainer.Text = "Container";
			// 
			// m_txtContainerISO
			// 
			this.m_txtContainerISO.Location = new System.Drawing.Point(72, 89);
			this.m_txtContainerISO.Name = "m_txtContainerISO";
			this.m_txtContainerISO.Size = new System.Drawing.Size(168, 20);
			this.m_txtContainerISO.TabIndex = 3;
			this.m_txtContainerISO.Text = "";
			// 
			// m_lbContainerISO
			// 
			this.m_lbContainerISO.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbContainerISO.Location = new System.Drawing.Point(8, 93);
			this.m_lbContainerISO.Name = "m_lbContainerISO";
			this.m_lbContainerISO.Size = new System.Drawing.Size(56, 16);
			this.m_lbContainerISO.TabIndex = 47;
			this.m_lbContainerISO.Text = "ISO:";
			// 
			// m_gbCargaPerigosa
			// 
			this.m_gbCargaPerigosa.Controls.Add(this.m_txtUno);
			this.m_gbCargaPerigosa.Controls.Add(this.m_lbUno);
			this.m_gbCargaPerigosa.Controls.Add(this.m_txtImo);
			this.m_gbCargaPerigosa.Controls.Add(this.m_lbImo);
			this.m_gbCargaPerigosa.Location = new System.Drawing.Point(5, 336);
			this.m_gbCargaPerigosa.Name = "m_gbCargaPerigosa";
			this.m_gbCargaPerigosa.Size = new System.Drawing.Size(240, 40);
			this.m_gbCargaPerigosa.TabIndex = 45;
			this.m_gbCargaPerigosa.TabStop = false;
			this.m_gbCargaPerigosa.Text = "Carga Perigosa";
			// 
			// m_txtUno
			// 
			this.m_txtUno.Location = new System.Drawing.Point(183, 15);
			this.m_txtUno.Name = "m_txtUno";
			this.m_txtUno.Size = new System.Drawing.Size(48, 20);
			this.m_txtUno.TabIndex = 49;
			this.m_txtUno.Text = "";
			// 
			// m_lbUno
			// 
			this.m_lbUno.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbUno.Location = new System.Drawing.Point(146, 18);
			this.m_lbUno.Name = "m_lbUno";
			this.m_lbUno.Size = new System.Drawing.Size(33, 16);
			this.m_lbUno.TabIndex = 48;
			this.m_lbUno.Text = "UNO:";
			// 
			// m_txtImo
			// 
			this.m_txtImo.Location = new System.Drawing.Point(64, 16);
			this.m_txtImo.Name = "m_txtImo";
			this.m_txtImo.Size = new System.Drawing.Size(48, 20);
			this.m_txtImo.TabIndex = 47;
			this.m_txtImo.Text = "";
			// 
			// m_lbImo
			// 
			this.m_lbImo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbImo.Location = new System.Drawing.Point(8, 18);
			this.m_lbImo.Name = "m_lbImo";
			this.m_lbImo.Size = new System.Drawing.Size(32, 16);
			this.m_lbImo.TabIndex = 44;
			this.m_lbImo.Text = "IMO:";
			// 
			// m_gbExcessoCarga
			// 
			this.m_gbExcessoCarga.Controls.Add(this.m_btUnidadeComprimento);
			this.m_gbExcessoCarga.Controls.Add(this.m_btUnidadeLargura);
			this.m_gbExcessoCarga.Controls.Add(this.m_btUnidadeAltura);
			this.m_gbExcessoCarga.Controls.Add(this.m_txtExcessoCargaComprimento);
			this.m_gbExcessoCarga.Controls.Add(this.m_txtExcessoCargaLargura);
			this.m_gbExcessoCarga.Controls.Add(this.m_txtExcessoCargaAltura);
			this.m_gbExcessoCarga.Controls.Add(this.m_lbExcessoCargaComprimento);
			this.m_gbExcessoCarga.Controls.Add(this.m_lbExcessoCargaLargura);
			this.m_gbExcessoCarga.Controls.Add(this.m_lbExcessoCargaAltura);
			this.m_gbExcessoCarga.Location = new System.Drawing.Point(6, 248);
			this.m_gbExcessoCarga.Name = "m_gbExcessoCarga";
			this.m_gbExcessoCarga.Size = new System.Drawing.Size(238, 88);
			this.m_gbExcessoCarga.TabIndex = 44;
			this.m_gbExcessoCarga.TabStop = false;
			this.m_gbExcessoCarga.Text = "Excesso Carga";
			// 
			// m_btUnidadeComprimento
			// 
			this.m_btUnidadeComprimento.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btUnidadeComprimento.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btUnidadeComprimento.Location = new System.Drawing.Point(201, 58);
			this.m_btUnidadeComprimento.Name = "m_btUnidadeComprimento";
			this.m_btUnidadeComprimento.Size = new System.Drawing.Size(32, 24);
			this.m_btUnidadeComprimento.TabIndex = 54;
			this.m_btUnidadeComprimento.TabStop = false;
			this.m_btUnidadeComprimento.Text = "cm";
			this.m_btUnidadeComprimento.Click += new System.EventHandler(this.m_btUnidadeComprimento_Click);
			// 
			// m_btUnidadeLargura
			// 
			this.m_btUnidadeLargura.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btUnidadeLargura.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btUnidadeLargura.Location = new System.Drawing.Point(201, 34);
			this.m_btUnidadeLargura.Name = "m_btUnidadeLargura";
			this.m_btUnidadeLargura.Size = new System.Drawing.Size(32, 24);
			this.m_btUnidadeLargura.TabIndex = 53;
			this.m_btUnidadeLargura.TabStop = false;
			this.m_btUnidadeLargura.Text = "cm";
			this.m_btUnidadeLargura.Click += new System.EventHandler(this.m_btUnidadeLargura_Click);
			// 
			// m_btUnidadeAltura
			// 
			this.m_btUnidadeAltura.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btUnidadeAltura.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btUnidadeAltura.Location = new System.Drawing.Point(201, 10);
			this.m_btUnidadeAltura.Name = "m_btUnidadeAltura";
			this.m_btUnidadeAltura.Size = new System.Drawing.Size(32, 24);
			this.m_btUnidadeAltura.TabIndex = 52;
			this.m_btUnidadeAltura.TabStop = false;
			this.m_btUnidadeAltura.Text = "cm";
			this.m_btUnidadeAltura.Click += new System.EventHandler(this.m_btUnidadeAltura_Click);
			// 
			// m_txtExcessoCargaComprimento
			// 
			this.m_txtExcessoCargaComprimento.Location = new System.Drawing.Point(96, 60);
			this.m_txtExcessoCargaComprimento.Name = "m_txtExcessoCargaComprimento";
			this.m_txtExcessoCargaComprimento.OnlyNumbers = true;
			this.m_txtExcessoCargaComprimento.Size = new System.Drawing.Size(104, 20);
			this.m_txtExcessoCargaComprimento.TabIndex = 51;
			this.m_txtExcessoCargaComprimento.Text = "";
			// 
			// m_txtExcessoCargaLargura
			// 
			this.m_txtExcessoCargaLargura.Location = new System.Drawing.Point(96, 37);
			this.m_txtExcessoCargaLargura.Name = "m_txtExcessoCargaLargura";
			this.m_txtExcessoCargaLargura.OnlyNumbers = true;
			this.m_txtExcessoCargaLargura.Size = new System.Drawing.Size(104, 20);
			this.m_txtExcessoCargaLargura.TabIndex = 50;
			this.m_txtExcessoCargaLargura.Text = "";
			// 
			// m_txtExcessoCargaAltura
			// 
			this.m_txtExcessoCargaAltura.Location = new System.Drawing.Point(96, 14);
			this.m_txtExcessoCargaAltura.Name = "m_txtExcessoCargaAltura";
			this.m_txtExcessoCargaAltura.OnlyNumbers = true;
			this.m_txtExcessoCargaAltura.Size = new System.Drawing.Size(104, 20);
			this.m_txtExcessoCargaAltura.TabIndex = 49;
			this.m_txtExcessoCargaAltura.Text = "";
			// 
			// m_lbExcessoCargaComprimento
			// 
			this.m_lbExcessoCargaComprimento.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbExcessoCargaComprimento.Location = new System.Drawing.Point(5, 65);
			this.m_lbExcessoCargaComprimento.Name = "m_lbExcessoCargaComprimento";
			this.m_lbExcessoCargaComprimento.Size = new System.Drawing.Size(88, 16);
			this.m_lbExcessoCargaComprimento.TabIndex = 48;
			this.m_lbExcessoCargaComprimento.Text = "Comprimento:";
			// 
			// m_lbExcessoCargaLargura
			// 
			this.m_lbExcessoCargaLargura.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbExcessoCargaLargura.Location = new System.Drawing.Point(7, 38);
			this.m_lbExcessoCargaLargura.Name = "m_lbExcessoCargaLargura";
			this.m_lbExcessoCargaLargura.Size = new System.Drawing.Size(60, 16);
			this.m_lbExcessoCargaLargura.TabIndex = 47;
			this.m_lbExcessoCargaLargura.Text = "Largura:";
			// 
			// m_lbExcessoCargaAltura
			// 
			this.m_lbExcessoCargaAltura.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbExcessoCargaAltura.Location = new System.Drawing.Point(6, 17);
			this.m_lbExcessoCargaAltura.Name = "m_lbExcessoCargaAltura";
			this.m_lbExcessoCargaAltura.Size = new System.Drawing.Size(60, 16);
			this.m_lbExcessoCargaAltura.TabIndex = 46;
			this.m_lbExcessoCargaAltura.Text = "Altura:";
			// 
			// m_gbTemperatura
			// 
			this.m_gbTemperatura.Controls.Add(this.m_lbTemperaturaMaxima);
			this.m_gbTemperatura.Controls.Add(this.m_txtTemperaturaMaxima);
			this.m_gbTemperatura.Controls.Add(this.m_lbTemperaturaMinima);
			this.m_gbTemperatura.Controls.Add(this.m_txtTemperaturaMinima);
			this.m_gbTemperatura.Location = new System.Drawing.Point(4, 208);
			this.m_gbTemperatura.Name = "m_gbTemperatura";
			this.m_gbTemperatura.Size = new System.Drawing.Size(240, 40);
			this.m_gbTemperatura.TabIndex = 43;
			this.m_gbTemperatura.TabStop = false;
			this.m_gbTemperatura.Text = "Temperatura";
			// 
			// m_lbTemperaturaMaxima
			// 
			this.m_lbTemperaturaMaxima.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbTemperaturaMaxima.Location = new System.Drawing.Point(132, 16);
			this.m_lbTemperaturaMaxima.Name = "m_lbTemperaturaMaxima";
			this.m_lbTemperaturaMaxima.Size = new System.Drawing.Size(53, 16);
			this.m_lbTemperaturaMaxima.TabIndex = 45;
			this.m_lbTemperaturaMaxima.Text = "Máxima:";
			// 
			// m_txtTemperaturaMaxima
			// 
			this.m_txtTemperaturaMaxima.Location = new System.Drawing.Point(186, 13);
			this.m_txtTemperaturaMaxima.Name = "m_txtTemperaturaMaxima";
			this.m_txtTemperaturaMaxima.Size = new System.Drawing.Size(48, 20);
			this.m_txtTemperaturaMaxima.TabIndex = 46;
			this.m_txtTemperaturaMaxima.Text = "";
			// 
			// m_lbTemperaturaMinima
			// 
			this.m_lbTemperaturaMinima.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbTemperaturaMinima.Location = new System.Drawing.Point(3, 16);
			this.m_lbTemperaturaMinima.Name = "m_lbTemperaturaMinima";
			this.m_lbTemperaturaMinima.Size = new System.Drawing.Size(53, 16);
			this.m_lbTemperaturaMinima.TabIndex = 43;
			this.m_lbTemperaturaMinima.Text = "Mínima:";
			// 
			// m_txtTemperaturaMinima
			// 
			this.m_txtTemperaturaMinima.Location = new System.Drawing.Point(64, 13);
			this.m_txtTemperaturaMinima.Name = "m_txtTemperaturaMinima";
			this.m_txtTemperaturaMinima.Size = new System.Drawing.Size(48, 20);
			this.m_txtTemperaturaMinima.TabIndex = 44;
			this.m_txtTemperaturaMinima.Text = "";
			// 
			// m_txtContainerLacreArmador
			// 
			this.m_txtContainerLacreArmador.Location = new System.Drawing.Point(104, 187);
			this.m_txtContainerLacreArmador.Name = "m_txtContainerLacreArmador";
			this.m_txtContainerLacreArmador.Size = new System.Drawing.Size(136, 20);
			this.m_txtContainerLacreArmador.TabIndex = 7;
			this.m_txtContainerLacreArmador.Text = "";
			// 
			// m_lbLacreArmador
			// 
			this.m_lbLacreArmador.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbLacreArmador.Location = new System.Drawing.Point(8, 187);
			this.m_lbLacreArmador.Name = "m_lbLacreArmador";
			this.m_lbLacreArmador.Size = new System.Drawing.Size(96, 16);
			this.m_lbLacreArmador.TabIndex = 42;
			this.m_lbLacreArmador.Text = "Lacre Armador:";
			// 
			// m_txtContainerTipo
			// 
			this.m_txtContainerTipo.Location = new System.Drawing.Point(72, 66);
			this.m_txtContainerTipo.Name = "m_txtContainerTipo";
			this.m_txtContainerTipo.Size = new System.Drawing.Size(168, 20);
			this.m_txtContainerTipo.TabIndex = 2;
			this.m_txtContainerTipo.Text = "";
			// 
			// m_lbContainerTipoPopular
			// 
			this.m_lbContainerTipoPopular.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbContainerTipoPopular.Location = new System.Drawing.Point(8, 68);
			this.m_lbContainerTipoPopular.Name = "m_lbContainerTipoPopular";
			this.m_lbContainerTipoPopular.Size = new System.Drawing.Size(56, 16);
			this.m_lbContainerTipoPopular.TabIndex = 40;
			this.m_lbContainerTipoPopular.Text = "Tipo:";
			// 
			// m_btContainerTaraUnidade
			// 
			this.m_btContainerTaraUnidade.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btContainerTaraUnidade.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btContainerTaraUnidade.Location = new System.Drawing.Point(210, 139);
			this.m_btContainerTaraUnidade.Name = "m_btContainerTaraUnidade";
			this.m_btContainerTaraUnidade.Size = new System.Drawing.Size(28, 24);
			this.m_btContainerTaraUnidade.TabIndex = 5;
			this.m_btContainerTaraUnidade.TabStop = false;
			this.m_btContainerTaraUnidade.Text = "Kg";
			this.m_btContainerTaraUnidade.Click += new System.EventHandler(this.m_btContainerTaraUnidade_Click);
			// 
			// m_txtContainerTara
			// 
			this.m_txtContainerTara.Location = new System.Drawing.Point(72, 139);
			this.m_txtContainerTara.Name = "m_txtContainerTara";
			this.m_txtContainerTara.OnlyNumbers = true;
			this.m_txtContainerTara.Size = new System.Drawing.Size(136, 20);
			this.m_txtContainerTara.TabIndex = 5;
			this.m_txtContainerTara.Text = "";
			// 
			// m_lbContainerTara
			// 
			this.m_lbContainerTara.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbContainerTara.Location = new System.Drawing.Point(8, 139);
			this.m_lbContainerTara.Name = "m_lbContainerTara";
			this.m_lbContainerTara.Size = new System.Drawing.Size(56, 16);
			this.m_lbContainerTara.TabIndex = 37;
			this.m_lbContainerTara.Text = "Tara:";
			// 
			// m_txtContainerLacre
			// 
			this.m_txtContainerLacre.Location = new System.Drawing.Point(72, 163);
			this.m_txtContainerLacre.Name = "m_txtContainerLacre";
			this.m_txtContainerLacre.Size = new System.Drawing.Size(168, 20);
			this.m_txtContainerLacre.TabIndex = 6;
			this.m_txtContainerLacre.Text = "";
			// 
			// m_lbContainerLacre
			// 
			this.m_lbContainerLacre.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbContainerLacre.Location = new System.Drawing.Point(8, 163);
			this.m_lbContainerLacre.Name = "m_lbContainerLacre";
			this.m_lbContainerLacre.Size = new System.Drawing.Size(56, 16);
			this.m_lbContainerLacre.TabIndex = 35;
			this.m_lbContainerLacre.Text = "Lacre(s):";
			// 
			// m_cbContainersTamanho
			// 
			this.m_cbContainersTamanho.GoToNextControlWithEnter = true;
			this.m_cbContainersTamanho.Location = new System.Drawing.Point(72, 112);
			this.m_cbContainersTamanho.Name = "m_cbContainersTamanho";
			this.m_cbContainersTamanho.Size = new System.Drawing.Size(168, 22);
			this.m_cbContainersTamanho.TabIndex = 4;
			// 
			// m_lbContainerTamanho
			// 
			this.m_lbContainerTamanho.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbContainerTamanho.Location = new System.Drawing.Point(8, 115);
			this.m_lbContainerTamanho.Name = "m_lbContainerTamanho";
			this.m_lbContainerTamanho.Size = new System.Drawing.Size(63, 16);
			this.m_lbContainerTamanho.TabIndex = 33;
			this.m_lbContainerTamanho.Text = "Tamanho:";
			// 
			// m_btContainerTipo
			// 
			this.m_btContainerTipo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btContainerTipo.Location = new System.Drawing.Point(72, 40);
			this.m_btContainerTipo.Name = "m_btContainerTipo";
			this.m_btContainerTipo.Size = new System.Drawing.Size(167, 24);
			this.m_btContainerTipo.TabIndex = 1;
			this.m_btContainerTipo.TabStop = false;
			this.m_btContainerTipo.Click += new System.EventHandler(this.m_btContainerTipo_Click);
			// 
			// m_lbContainerTipo
			// 
			this.m_lbContainerTipo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbContainerTipo.Location = new System.Drawing.Point(8, 43);
			this.m_lbContainerTipo.Name = "m_lbContainerTipo";
			this.m_lbContainerTipo.Size = new System.Drawing.Size(40, 16);
			this.m_lbContainerTipo.TabIndex = 31;
			this.m_lbContainerTipo.Text = "Tipo:";
			// 
			// m_txtContainerNumero
			// 
			this.m_txtContainerNumero.Location = new System.Drawing.Point(72, 16);
			this.m_txtContainerNumero.Mask = true;
			this.m_txtContainerNumero.MaskText = "CCCCNNNNNNN";
			this.m_txtContainerNumero.Name = "m_txtContainerNumero";
			this.m_txtContainerNumero.Size = new System.Drawing.Size(168, 20);
			this.m_txtContainerNumero.TabIndex = 0;
			this.m_txtContainerNumero.Text = "";
			// 
			// m_lbContainerNumero
			// 
			this.m_lbContainerNumero.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbContainerNumero.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_lbContainerNumero.Location = new System.Drawing.Point(9, 19);
			this.m_lbContainerNumero.Name = "m_lbContainerNumero";
			this.m_lbContainerNumero.Size = new System.Drawing.Size(56, 16);
			this.m_lbContainerNumero.TabIndex = 29;
			this.m_lbContainerNumero.Text = "Número:";
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(68, 392);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 1;
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(132, 392);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 2;
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// frmFContainersEditar
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(266, 423);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFContainersEditar";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Container Edição";
			this.Load += new System.EventHandler(this.frmFContainersEditar_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbContainer.ResumeLayout(false);
			this.m_gbCargaPerigosa.ResumeLayout(false);
			this.m_gbExcessoCarga.ResumeLayout(false);
			this.m_gbTemperatura.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFContainersEditar_Load(object sender, System.EventArgs e)
				{
					vMostraCor();
					OnCallCarregaDados();
					OnCallRefreshContainersTamanho();
					OnCallContainersText(true);
					m_btContainerTaraUnidade.Text = clsContainers.strRetornaUnidade(m_enumUnidadeTara);
					m_btUnidadeAltura.Text = clsContainers.strRetornaUnidade(m_enumUnidadeAltura);
					m_btUnidadeLargura.Text = clsContainers.strRetornaUnidade(m_enumUnidadeLargura);
					m_btUnidadeComprimento.Text = clsContainers.strRetornaUnidade(m_enumUnidadeComprimento);
				}
			#endregion
			#region Botoes
				private void m_btContainerTipo_Click(object sender, System.EventArgs e)
				{
					if (OnCallContainersTipo())
					{
						OnCallContainersText(false);
						OnCallRefreshContainersTamanho();
					}
				}

				private void m_btContainerTaraUnidade_Click(object sender, System.EventArgs e)
				{
                    m_enumUnidadeTara = clsContainers.enumRetornaProximaUnidadeMassa(m_enumUnidadeTara);
					m_btContainerTaraUnidade.Text = clsContainers.strRetornaUnidade(m_enumUnidadeTara);
				}

				private void m_btUnidadeAltura_Click(object sender, System.EventArgs e)
				{
					m_enumUnidadeAltura = clsContainers.enumRetornaProximaUnidadeMedida(m_enumUnidadeAltura);
					m_btUnidadeAltura.Text = clsContainers.strRetornaUnidade(m_enumUnidadeAltura);
				}

				private void m_btUnidadeLargura_Click(object sender, System.EventArgs e)
				{
					m_enumUnidadeLargura = clsContainers.enumRetornaProximaUnidadeMedida(m_enumUnidadeLargura);
					m_btUnidadeLargura.Text = clsContainers.strRetornaUnidade(m_enumUnidadeLargura);
				}

				private void m_btUnidadeComprimento_Click(object sender, System.EventArgs e)
				{
					m_enumUnidadeComprimento = clsContainers.enumRetornaProximaUnidadeMedida(m_enumUnidadeComprimento);
					m_btUnidadeComprimento.Text = clsContainers.strRetornaUnidade(m_enumUnidadeComprimento);
				}

				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					if (m_bModificado = OnCallSalvaDados())
						this.Close();
				}

				private void m_btCancelar_Click(object sender, System.EventArgs e)
				{
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
					case "mdlComponentesGraficos.TextBox":
					case "mdlComponentesGraficos.ComboBox":
					case "System.Windows.Forms.ComboBox":
					case "System.Windows.Forms.TextBox":
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
	}
}
