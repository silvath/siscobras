using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace mdlContainers.Formularios
{
	/// <summary>
	/// Summary description for frmFContainers.
	/// </summary>
	internal class frmFContainers : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate void delCallCarregaDadosContainersInformacao(out string strContainersNumero,out string strContainersTipo,out string strContainersISO,out string strContainersTamanho,out string strContainersTara,out string strContainersLacre,out string strContainersLacreArmador,out string strContainerExcessoCargaAltura,out string strContainerExcessoCargaLargura,out string strContainerExcessoCargaComprimento,out string strContainerTemperaturaMinima,out string strContainerTemperaturaMaxima,out string strContainerIMO,out string strContainerUNO);
			public delegate void delCallSalvaDadosContainersInformacao(string strContainersNumero,string strContainersTipo,string strContainersISO,string strContainersTamanho,string strContainersTara,string strContainersLacre,string strContainersLacreArmador,string strContainerExcessoCargaAltura,string strContainerExcessoCargaLargura,string strContainerExcessoCargaComprimento,string strContainerTemperaturaMinima,string strContainerTemperaturaMaxima,string strContainerIMO,string strContainerUNO);
			public delegate void delCallContainersRefresh(ref System.Windows.Forms.ListView lvContainers);
			public delegate bool delCallContainersNovo();
			public delegate bool delCallContainersEdicao(int nIdContainer);
			public delegate bool delCallContainersExclui(System.Collections.ArrayList arlContainers,bool bSilent);
			public delegate bool delCallSalvaDados();
		#endregion
		#region Events
			public event delCallCarregaDadosContainersInformacao eCallCarregaDadosContainersInformacao;
			public event delCallSalvaDadosContainersInformacao eCallSalvaDadosContainersInformacao;
			public event delCallContainersRefresh eCallContainersRefresh;
			public event delCallContainersNovo eCallContainersNovo;
			public event delCallContainersEdicao eCallContainersEdicao;
			public event delCallContainersExclui eCallContainersExclui;
			public event delCallSalvaDados eCallSalvaDados;
		#endregion
		#region Events Methods
			public virtual void OnCallCarregaDadosContainersInformacao() 
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallCarregaDadosContainersInformacao != null)
				{
					string strContainersNumero,strContainersTipo,strContainersISO,strContainersTamanho,strContainersTara,strContainersLacre,strContainersLacreArmador,strContainerExcessoCargaAltura,strContainerExcessoCargaLargura,strContainerExcessoCargaComprimento,strContainerTemperaturaMinima,strContainerTemperaturaMaxima,strContainerIMO,strContainerUNO;
					eCallCarregaDadosContainersInformacao(out strContainersNumero,out strContainersTipo,out strContainersISO,out strContainersTamanho,out strContainersTara,out strContainersLacre,out strContainersLacreArmador,out strContainerExcessoCargaAltura,out strContainerExcessoCargaLargura,out strContainerExcessoCargaComprimento,out strContainerTemperaturaMinima,out strContainerTemperaturaMaxima,out strContainerIMO,out strContainerUNO);
					m_txtContainerNumero.Text = strContainersNumero;
					m_txtContainerTipo.Text = strContainersTipo;
					m_txtContainerISO.Text = strContainersISO;
					m_txtContainersTamanho.Text = strContainersTamanho;
					m_txtContainerTara.Text = strContainersTara;
					m_txtContainerLacre.Text = strContainersLacre;
					m_txtContainerLacreArmador.Text = strContainersLacreArmador;
					m_txtContainerExcessoCargaAltura.Text = strContainerExcessoCargaAltura;
					m_txtContainerExcessoCargaLargura.Text = strContainerExcessoCargaLargura;
					m_txtContainerExcessoCargaComprimento.Text = strContainerExcessoCargaComprimento;
					m_txtContainerTemperaturaMinima.Text = strContainerTemperaturaMinima;
					m_txtContainerTemperaturaMaxima.Text = strContainerTemperaturaMaxima;
					m_txtContainerImo.Text = strContainerIMO;
					m_txtContainerUno.Text = strContainerUNO;
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			public virtual void OnCallSalvaDadosContainersInformacao() 
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallCarregaDadosContainersInformacao != null)
					eCallSalvaDadosContainersInformacao(m_txtContainerNumero.Text,m_txtContainerTipo.Text,m_txtContainerISO.Text,m_txtContainersTamanho.Text,m_txtContainerTara.Text,m_txtContainerLacre.Text,m_txtContainerLacreArmador.Text,m_txtContainerExcessoCargaAltura.Text,m_txtContainerExcessoCargaLargura.Text,m_txtContainerExcessoCargaComprimento.Text,m_txtContainerTemperaturaMinima.Text,m_txtContainerTemperaturaMaxima.Text,m_txtContainerImo.Text,m_txtContainerUno.Text);
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			public virtual void OnCallContainersRefresh() 
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallContainersRefresh != null)
				{
					eCallContainersRefresh(ref m_lvContainers);
					if (m_lvContainers.Items.Count > 1)
					{
						m_gbInformacoes.Enabled = true;
					}else{
						m_gbInformacoes.Enabled = false;
					}
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}
			
			public virtual bool OnCallContainersNovo()
			{
				bool bRetorno = false;
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallContainersNovo != null)
				{
					bRetorno = eCallContainersNovo();
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bRetorno);
			}

			public virtual bool OnCallContainersEdicao()
			{
				bool bRetorno = false;
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if ((eCallContainersEdicao != null) && (m_lvContainers.SelectedItems.Count > 0))
				{
					bRetorno = eCallContainersEdicao(Int32.Parse(m_lvContainers.SelectedItems[0].Tag.ToString()));
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bRetorno);
			}

			public virtual bool OnCallContainersExclui()
			{
				bool bRetorno = false;
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if ((eCallContainersExclui != null) && (m_lvContainers.SelectedItems.Count > 0))
				{
					System.Collections.ArrayList arlContainers = new ArrayList();
					foreach(System.Windows.Forms.ListViewItem lviContainer in m_lvContainers.SelectedItems)
						arlContainers.Add(lviContainer.Tag);
					bRetorno = eCallContainersExclui(arlContainers,false);
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bRetorno);
			}

			public virtual bool OnCallSalvaDados()
			{
				bool bRetorno = false;
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallSalvaDados != null)
				{
					bRetorno = eCallSalvaDados();
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bRetorno);
			}
		#endregion

		#region Atributes
			private string m_strEnderecoExecutavel = "";

			private System.Windows.Forms.GroupBox m_gbGeral;
			public System.Windows.Forms.Button m_btOk;
			public System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.GroupBox m_gbContainers;
			private System.Windows.Forms.ListView m_lvContainers;
			private System.Windows.Forms.Button m_btContainerExcluir;
			private System.Windows.Forms.Button m_btContainerEditar;
			private System.Windows.Forms.Button m_btContainerNovo;
		private System.Windows.Forms.ColumnHeader m_colhNumero;
		private System.Windows.Forms.ColumnHeader m_colhTipo;
		private System.Windows.Forms.GroupBox m_gbInformacoes;
		private mdlComponentesGraficos.TextBox m_txtContainerNumero;
		private System.Windows.Forms.Label m_lbContainerNumero;
		private mdlComponentesGraficos.TextBox m_txtContainerLacreArmador;
		private System.Windows.Forms.Label m_lbLacreArmador;
		private mdlComponentesGraficos.TextBox m_txtContainerTipo;
		private System.Windows.Forms.Label m_lbContainerTipoPopular;
		private mdlComponentesGraficos.TextBox m_txtContainerTara;
		private System.Windows.Forms.Label m_lbContainerTara;
		private mdlComponentesGraficos.TextBox m_txtContainerLacre;
		private System.Windows.Forms.Label m_lbContainerLacre;
		private System.Windows.Forms.Label m_lbContainerTamanho;
		private mdlComponentesGraficos.TextBox m_txtContainersTamanho;
		private System.Windows.Forms.GroupBox m_gbCargaPerigosa;
		private System.Windows.Forms.Label m_lbUno;
		private System.Windows.Forms.Label m_lbImo;
		private System.Windows.Forms.GroupBox m_gbExcessoCarga;
		private System.Windows.Forms.Label m_lbExcessoCargaComprimento;
		private System.Windows.Forms.Label m_lbExcessoCargaLargura;
		private System.Windows.Forms.Label m_lbExcessoCargaAltura;
		private System.Windows.Forms.Label m_lbTemperaturaMaxima;
		private System.Windows.Forms.Label m_lbTemperaturaMinima;
		private mdlComponentesGraficos.TextBox m_txtContainerUno;
		private mdlComponentesGraficos.TextBox m_txtContainerImo;
		private mdlComponentesGraficos.TextBox m_txtContainerExcessoCargaComprimento;
		private mdlComponentesGraficos.TextBox m_txtContainerExcessoCargaLargura;
		private mdlComponentesGraficos.TextBox m_txtContainerExcessoCargaAltura;
		private mdlComponentesGraficos.TextBox m_txtContainerTemperaturaMaxima;
		private mdlComponentesGraficos.TextBox m_txtContainerTemperaturaMinima;
		private System.Windows.Forms.GroupBox m_gbTemperatura;
		private mdlComponentesGraficos.TextBox m_txtContainerISO;
		private System.Windows.Forms.Label m_lbContainerISO;
			private System.ComponentModel.Container components = null;
		#endregion
		#region Constructors and Destructors
			public frmFContainers(string strEnderecoExecutavel)
			{
				m_strEnderecoExecutavel = strEnderecoExecutavel;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFContainers));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_gbInformacoes = new System.Windows.Forms.GroupBox();
			this.m_txtContainerISO = new mdlComponentesGraficos.TextBox();
			this.m_lbContainerISO = new System.Windows.Forms.Label();
			this.m_gbCargaPerigosa = new System.Windows.Forms.GroupBox();
			this.m_txtContainerUno = new mdlComponentesGraficos.TextBox();
			this.m_lbUno = new System.Windows.Forms.Label();
			this.m_txtContainerImo = new mdlComponentesGraficos.TextBox();
			this.m_lbImo = new System.Windows.Forms.Label();
			this.m_gbExcessoCarga = new System.Windows.Forms.GroupBox();
			this.m_txtContainerExcessoCargaComprimento = new mdlComponentesGraficos.TextBox();
			this.m_txtContainerExcessoCargaLargura = new mdlComponentesGraficos.TextBox();
			this.m_txtContainerExcessoCargaAltura = new mdlComponentesGraficos.TextBox();
			this.m_lbExcessoCargaComprimento = new System.Windows.Forms.Label();
			this.m_lbExcessoCargaLargura = new System.Windows.Forms.Label();
			this.m_lbExcessoCargaAltura = new System.Windows.Forms.Label();
			this.m_gbTemperatura = new System.Windows.Forms.GroupBox();
			this.m_lbTemperaturaMaxima = new System.Windows.Forms.Label();
			this.m_txtContainerTemperaturaMaxima = new mdlComponentesGraficos.TextBox();
			this.m_lbTemperaturaMinima = new System.Windows.Forms.Label();
			this.m_txtContainerTemperaturaMinima = new mdlComponentesGraficos.TextBox();
			this.m_txtContainersTamanho = new mdlComponentesGraficos.TextBox();
			this.m_txtContainerLacreArmador = new mdlComponentesGraficos.TextBox();
			this.m_lbLacreArmador = new System.Windows.Forms.Label();
			this.m_txtContainerTipo = new mdlComponentesGraficos.TextBox();
			this.m_lbContainerTipoPopular = new System.Windows.Forms.Label();
			this.m_txtContainerTara = new mdlComponentesGraficos.TextBox();
			this.m_lbContainerTara = new System.Windows.Forms.Label();
			this.m_txtContainerLacre = new mdlComponentesGraficos.TextBox();
			this.m_lbContainerLacre = new System.Windows.Forms.Label();
			this.m_lbContainerTamanho = new System.Windows.Forms.Label();
			this.m_txtContainerNumero = new mdlComponentesGraficos.TextBox();
			this.m_lbContainerNumero = new System.Windows.Forms.Label();
			this.m_gbContainers = new System.Windows.Forms.GroupBox();
			this.m_btContainerExcluir = new System.Windows.Forms.Button();
			this.m_btContainerEditar = new System.Windows.Forms.Button();
			this.m_btContainerNovo = new System.Windows.Forms.Button();
			this.m_lvContainers = new System.Windows.Forms.ListView();
			this.m_colhNumero = new System.Windows.Forms.ColumnHeader();
			this.m_colhTipo = new System.Windows.Forms.ColumnHeader();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbGeral.SuspendLayout();
			this.m_gbInformacoes.SuspendLayout();
			this.m_gbCargaPerigosa.SuspendLayout();
			this.m_gbExcessoCarga.SuspendLayout();
			this.m_gbTemperatura.SuspendLayout();
			this.m_gbContainers.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbGeral.Controls.Add(this.m_gbInformacoes);
			this.m_gbGeral.Controls.Add(this.m_gbContainers);
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Location = new System.Drawing.Point(3, 0);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(284, 520);
			this.m_gbGeral.TabIndex = 0;
			this.m_gbGeral.TabStop = false;
			// 
			// m_gbInformacoes
			// 
			this.m_gbInformacoes.Controls.Add(this.m_txtContainerISO);
			this.m_gbInformacoes.Controls.Add(this.m_lbContainerISO);
			this.m_gbInformacoes.Controls.Add(this.m_gbCargaPerigosa);
			this.m_gbInformacoes.Controls.Add(this.m_gbExcessoCarga);
			this.m_gbInformacoes.Controls.Add(this.m_gbTemperatura);
			this.m_gbInformacoes.Controls.Add(this.m_txtContainersTamanho);
			this.m_gbInformacoes.Controls.Add(this.m_txtContainerLacreArmador);
			this.m_gbInformacoes.Controls.Add(this.m_lbLacreArmador);
			this.m_gbInformacoes.Controls.Add(this.m_txtContainerTipo);
			this.m_gbInformacoes.Controls.Add(this.m_lbContainerTipoPopular);
			this.m_gbInformacoes.Controls.Add(this.m_txtContainerTara);
			this.m_gbInformacoes.Controls.Add(this.m_lbContainerTara);
			this.m_gbInformacoes.Controls.Add(this.m_txtContainerLacre);
			this.m_gbInformacoes.Controls.Add(this.m_lbContainerLacre);
			this.m_gbInformacoes.Controls.Add(this.m_lbContainerTamanho);
			this.m_gbInformacoes.Controls.Add(this.m_txtContainerNumero);
			this.m_gbInformacoes.Controls.Add(this.m_lbContainerNumero);
			this.m_gbInformacoes.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbInformacoes.Location = new System.Drawing.Point(8, 128);
			this.m_gbInformacoes.Name = "m_gbInformacoes";
			this.m_gbInformacoes.Size = new System.Drawing.Size(272, 360);
			this.m_gbInformacoes.TabIndex = 15;
			this.m_gbInformacoes.TabStop = false;
			this.m_gbInformacoes.Text = "Informações Visuais";
			// 
			// m_txtContainerISO
			// 
			this.m_txtContainerISO.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_txtContainerISO.Location = new System.Drawing.Point(71, 64);
			this.m_txtContainerISO.Name = "m_txtContainerISO";
			this.m_txtContainerISO.Size = new System.Drawing.Size(193, 20);
			this.m_txtContainerISO.TabIndex = 57;
			this.m_txtContainerISO.Text = "";
			// 
			// m_lbContainerISO
			// 
			this.m_lbContainerISO.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbContainerISO.Location = new System.Drawing.Point(7, 65);
			this.m_lbContainerISO.Name = "m_lbContainerISO";
			this.m_lbContainerISO.Size = new System.Drawing.Size(56, 16);
			this.m_lbContainerISO.TabIndex = 58;
			this.m_lbContainerISO.Text = "ISO:";
			// 
			// m_gbCargaPerigosa
			// 
			this.m_gbCargaPerigosa.Controls.Add(this.m_txtContainerUno);
			this.m_gbCargaPerigosa.Controls.Add(this.m_lbUno);
			this.m_gbCargaPerigosa.Controls.Add(this.m_txtContainerImo);
			this.m_gbCargaPerigosa.Controls.Add(this.m_lbImo);
			this.m_gbCargaPerigosa.Location = new System.Drawing.Point(5, 304);
			this.m_gbCargaPerigosa.Name = "m_gbCargaPerigosa";
			this.m_gbCargaPerigosa.Size = new System.Drawing.Size(259, 48);
			this.m_gbCargaPerigosa.TabIndex = 56;
			this.m_gbCargaPerigosa.TabStop = false;
			this.m_gbCargaPerigosa.Text = "Carga Perigosa";
			// 
			// m_txtContainerUno
			// 
			this.m_txtContainerUno.Location = new System.Drawing.Point(189, 16);
			this.m_txtContainerUno.Name = "m_txtContainerUno";
			this.m_txtContainerUno.Size = new System.Drawing.Size(64, 20);
			this.m_txtContainerUno.TabIndex = 49;
			this.m_txtContainerUno.Text = "";
			// 
			// m_lbUno
			// 
			this.m_lbUno.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbUno.Location = new System.Drawing.Point(157, 19);
			this.m_lbUno.Name = "m_lbUno";
			this.m_lbUno.Size = new System.Drawing.Size(33, 16);
			this.m_lbUno.TabIndex = 48;
			this.m_lbUno.Text = "UNO:";
			// 
			// m_txtContainerImo
			// 
			this.m_txtContainerImo.Location = new System.Drawing.Point(64, 16);
			this.m_txtContainerImo.Name = "m_txtContainerImo";
			this.m_txtContainerImo.Size = new System.Drawing.Size(64, 20);
			this.m_txtContainerImo.TabIndex = 47;
			this.m_txtContainerImo.Text = "";
			// 
			// m_lbImo
			// 
			this.m_lbImo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbImo.Location = new System.Drawing.Point(10, 19);
			this.m_lbImo.Name = "m_lbImo";
			this.m_lbImo.Size = new System.Drawing.Size(32, 16);
			this.m_lbImo.TabIndex = 44;
			this.m_lbImo.Text = "IMO:";
			// 
			// m_gbExcessoCarga
			// 
			this.m_gbExcessoCarga.Controls.Add(this.m_txtContainerExcessoCargaComprimento);
			this.m_gbExcessoCarga.Controls.Add(this.m_txtContainerExcessoCargaLargura);
			this.m_gbExcessoCarga.Controls.Add(this.m_txtContainerExcessoCargaAltura);
			this.m_gbExcessoCarga.Controls.Add(this.m_lbExcessoCargaComprimento);
			this.m_gbExcessoCarga.Controls.Add(this.m_lbExcessoCargaLargura);
			this.m_gbExcessoCarga.Controls.Add(this.m_lbExcessoCargaAltura);
			this.m_gbExcessoCarga.Location = new System.Drawing.Point(5, 216);
			this.m_gbExcessoCarga.Name = "m_gbExcessoCarga";
			this.m_gbExcessoCarga.Size = new System.Drawing.Size(259, 88);
			this.m_gbExcessoCarga.TabIndex = 55;
			this.m_gbExcessoCarga.TabStop = false;
			this.m_gbExcessoCarga.Text = "Excesso Carga";
			// 
			// m_txtContainerExcessoCargaComprimento
			// 
			this.m_txtContainerExcessoCargaComprimento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_txtContainerExcessoCargaComprimento.Location = new System.Drawing.Point(96, 60);
			this.m_txtContainerExcessoCargaComprimento.Name = "m_txtContainerExcessoCargaComprimento";
			this.m_txtContainerExcessoCargaComprimento.Size = new System.Drawing.Size(157, 20);
			this.m_txtContainerExcessoCargaComprimento.TabIndex = 51;
			this.m_txtContainerExcessoCargaComprimento.Text = "";
			// 
			// m_txtContainerExcessoCargaLargura
			// 
			this.m_txtContainerExcessoCargaLargura.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_txtContainerExcessoCargaLargura.Location = new System.Drawing.Point(96, 37);
			this.m_txtContainerExcessoCargaLargura.Name = "m_txtContainerExcessoCargaLargura";
			this.m_txtContainerExcessoCargaLargura.Size = new System.Drawing.Size(157, 20);
			this.m_txtContainerExcessoCargaLargura.TabIndex = 50;
			this.m_txtContainerExcessoCargaLargura.Text = "";
			// 
			// m_txtContainerExcessoCargaAltura
			// 
			this.m_txtContainerExcessoCargaAltura.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_txtContainerExcessoCargaAltura.Location = new System.Drawing.Point(96, 14);
			this.m_txtContainerExcessoCargaAltura.Name = "m_txtContainerExcessoCargaAltura";
			this.m_txtContainerExcessoCargaAltura.Size = new System.Drawing.Size(157, 20);
			this.m_txtContainerExcessoCargaAltura.TabIndex = 49;
			this.m_txtContainerExcessoCargaAltura.Text = "";
			// 
			// m_lbExcessoCargaComprimento
			// 
			this.m_lbExcessoCargaComprimento.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbExcessoCargaComprimento.Location = new System.Drawing.Point(5, 64);
			this.m_lbExcessoCargaComprimento.Name = "m_lbExcessoCargaComprimento";
			this.m_lbExcessoCargaComprimento.Size = new System.Drawing.Size(88, 16);
			this.m_lbExcessoCargaComprimento.TabIndex = 48;
			this.m_lbExcessoCargaComprimento.Text = "Comprimento:";
			// 
			// m_lbExcessoCargaLargura
			// 
			this.m_lbExcessoCargaLargura.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbExcessoCargaLargura.Location = new System.Drawing.Point(7, 39);
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
			this.m_gbTemperatura.Controls.Add(this.m_txtContainerTemperaturaMaxima);
			this.m_gbTemperatura.Controls.Add(this.m_lbTemperaturaMinima);
			this.m_gbTemperatura.Controls.Add(this.m_txtContainerTemperaturaMinima);
			this.m_gbTemperatura.Location = new System.Drawing.Point(5, 175);
			this.m_gbTemperatura.Name = "m_gbTemperatura";
			this.m_gbTemperatura.Size = new System.Drawing.Size(259, 41);
			this.m_gbTemperatura.TabIndex = 54;
			this.m_gbTemperatura.TabStop = false;
			this.m_gbTemperatura.Text = "Temperatura";
			// 
			// m_lbTemperaturaMaxima
			// 
			this.m_lbTemperaturaMaxima.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbTemperaturaMaxima.Location = new System.Drawing.Point(136, 16);
			this.m_lbTemperaturaMaxima.Name = "m_lbTemperaturaMaxima";
			this.m_lbTemperaturaMaxima.Size = new System.Drawing.Size(53, 16);
			this.m_lbTemperaturaMaxima.TabIndex = 45;
			this.m_lbTemperaturaMaxima.Text = "Máxima:";
			// 
			// m_txtContainerTemperaturaMaxima
			// 
			this.m_txtContainerTemperaturaMaxima.Location = new System.Drawing.Point(189, 14);
			this.m_txtContainerTemperaturaMaxima.Name = "m_txtContainerTemperaturaMaxima";
			this.m_txtContainerTemperaturaMaxima.Size = new System.Drawing.Size(64, 20);
			this.m_txtContainerTemperaturaMaxima.TabIndex = 46;
			this.m_txtContainerTemperaturaMaxima.Text = "";
			// 
			// m_lbTemperaturaMinima
			// 
			this.m_lbTemperaturaMinima.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbTemperaturaMinima.Location = new System.Drawing.Point(3, 17);
			this.m_lbTemperaturaMinima.Name = "m_lbTemperaturaMinima";
			this.m_lbTemperaturaMinima.Size = new System.Drawing.Size(53, 16);
			this.m_lbTemperaturaMinima.TabIndex = 43;
			this.m_lbTemperaturaMinima.Text = "Mínima:";
			// 
			// m_txtContainerTemperaturaMinima
			// 
			this.m_txtContainerTemperaturaMinima.Location = new System.Drawing.Point(64, 14);
			this.m_txtContainerTemperaturaMinima.Name = "m_txtContainerTemperaturaMinima";
			this.m_txtContainerTemperaturaMinima.Size = new System.Drawing.Size(64, 20);
			this.m_txtContainerTemperaturaMinima.TabIndex = 44;
			this.m_txtContainerTemperaturaMinima.Text = "";
			// 
			// m_txtContainersTamanho
			// 
			this.m_txtContainersTamanho.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_txtContainersTamanho.Location = new System.Drawing.Point(70, 85);
			this.m_txtContainersTamanho.Name = "m_txtContainersTamanho";
			this.m_txtContainersTamanho.OnlyNumbers = true;
			this.m_txtContainersTamanho.Size = new System.Drawing.Size(194, 20);
			this.m_txtContainersTamanho.TabIndex = 53;
			this.m_txtContainersTamanho.Text = "";
			// 
			// m_txtContainerLacreArmador
			// 
			this.m_txtContainerLacreArmador.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_txtContainerLacreArmador.Location = new System.Drawing.Point(102, 155);
			this.m_txtContainerLacreArmador.Name = "m_txtContainerLacreArmador";
			this.m_txtContainerLacreArmador.Size = new System.Drawing.Size(162, 20);
			this.m_txtContainerLacreArmador.TabIndex = 51;
			this.m_txtContainerLacreArmador.Text = "";
			// 
			// m_lbLacreArmador
			// 
			this.m_lbLacreArmador.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbLacreArmador.Location = new System.Drawing.Point(7, 157);
			this.m_lbLacreArmador.Name = "m_lbLacreArmador";
			this.m_lbLacreArmador.Size = new System.Drawing.Size(96, 16);
			this.m_lbLacreArmador.TabIndex = 52;
			this.m_lbLacreArmador.Text = "Lacre Armador:";
			// 
			// m_txtContainerTipo
			// 
			this.m_txtContainerTipo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_txtContainerTipo.Location = new System.Drawing.Point(70, 40);
			this.m_txtContainerTipo.Name = "m_txtContainerTipo";
			this.m_txtContainerTipo.Size = new System.Drawing.Size(194, 20);
			this.m_txtContainerTipo.TabIndex = 43;
			this.m_txtContainerTipo.Text = "";
			// 
			// m_lbContainerTipoPopular
			// 
			this.m_lbContainerTipoPopular.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbContainerTipoPopular.Location = new System.Drawing.Point(7, 42);
			this.m_lbContainerTipoPopular.Name = "m_lbContainerTipoPopular";
			this.m_lbContainerTipoPopular.Size = new System.Drawing.Size(56, 16);
			this.m_lbContainerTipoPopular.TabIndex = 50;
			this.m_lbContainerTipoPopular.Text = "Tipo:";
			// 
			// m_txtContainerTara
			// 
			this.m_txtContainerTara.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_txtContainerTara.Location = new System.Drawing.Point(70, 109);
			this.m_txtContainerTara.Name = "m_txtContainerTara";
			this.m_txtContainerTara.OnlyNumbers = true;
			this.m_txtContainerTara.Size = new System.Drawing.Size(194, 20);
			this.m_txtContainerTara.TabIndex = 45;
			this.m_txtContainerTara.Text = "";
			// 
			// m_lbContainerTara
			// 
			this.m_lbContainerTara.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbContainerTara.Location = new System.Drawing.Point(7, 114);
			this.m_lbContainerTara.Name = "m_lbContainerTara";
			this.m_lbContainerTara.Size = new System.Drawing.Size(56, 16);
			this.m_lbContainerTara.TabIndex = 49;
			this.m_lbContainerTara.Text = "Tara:";
			// 
			// m_txtContainerLacre
			// 
			this.m_txtContainerLacre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_txtContainerLacre.Location = new System.Drawing.Point(70, 132);
			this.m_txtContainerLacre.Name = "m_txtContainerLacre";
			this.m_txtContainerLacre.Size = new System.Drawing.Size(194, 20);
			this.m_txtContainerLacre.TabIndex = 46;
			this.m_txtContainerLacre.Text = "";
			// 
			// m_lbContainerLacre
			// 
			this.m_lbContainerLacre.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbContainerLacre.Location = new System.Drawing.Point(7, 135);
			this.m_lbContainerLacre.Name = "m_lbContainerLacre";
			this.m_lbContainerLacre.Size = new System.Drawing.Size(56, 16);
			this.m_lbContainerLacre.TabIndex = 48;
			this.m_lbContainerLacre.Text = "Lacre(s):";
			// 
			// m_lbContainerTamanho
			// 
			this.m_lbContainerTamanho.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbContainerTamanho.Location = new System.Drawing.Point(7, 89);
			this.m_lbContainerTamanho.Name = "m_lbContainerTamanho";
			this.m_lbContainerTamanho.Size = new System.Drawing.Size(63, 16);
			this.m_lbContainerTamanho.TabIndex = 47;
			this.m_lbContainerTamanho.Text = "Tamanho:";
			// 
			// m_txtContainerNumero
			// 
			this.m_txtContainerNumero.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_txtContainerNumero.Location = new System.Drawing.Point(71, 16);
			this.m_txtContainerNumero.Name = "m_txtContainerNumero";
			this.m_txtContainerNumero.Size = new System.Drawing.Size(193, 20);
			this.m_txtContainerNumero.TabIndex = 30;
			this.m_txtContainerNumero.Text = "";
			// 
			// m_lbContainerNumero
			// 
			this.m_lbContainerNumero.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbContainerNumero.Location = new System.Drawing.Point(7, 16);
			this.m_lbContainerNumero.Name = "m_lbContainerNumero";
			this.m_lbContainerNumero.Size = new System.Drawing.Size(56, 16);
			this.m_lbContainerNumero.TabIndex = 31;
			this.m_lbContainerNumero.Text = "Número:";
			// 
			// m_gbContainers
			// 
			this.m_gbContainers.Controls.Add(this.m_btContainerExcluir);
			this.m_gbContainers.Controls.Add(this.m_btContainerEditar);
			this.m_gbContainers.Controls.Add(this.m_btContainerNovo);
			this.m_gbContainers.Controls.Add(this.m_lvContainers);
			this.m_gbContainers.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbContainers.Location = new System.Drawing.Point(8, 8);
			this.m_gbContainers.Name = "m_gbContainers";
			this.m_gbContainers.Size = new System.Drawing.Size(272, 120);
			this.m_gbContainers.TabIndex = 14;
			this.m_gbContainers.TabStop = false;
			this.m_gbContainers.Text = "Containers";
			// 
			// m_btContainerExcluir
			// 
			this.m_btContainerExcluir.BackColor = System.Drawing.SystemColors.Control;
			this.m_btContainerExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btContainerExcluir.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btContainerExcluir.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btContainerExcluir.Image = ((System.Drawing.Image)(resources.GetObject("m_btContainerExcluir.Image")));
			this.m_btContainerExcluir.Location = new System.Drawing.Point(155, 12);
			this.m_btContainerExcluir.Name = "m_btContainerExcluir";
			this.m_btContainerExcluir.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btContainerExcluir.Size = new System.Drawing.Size(25, 25);
			this.m_btContainerExcluir.TabIndex = 6;
			this.m_btContainerExcluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_btContainerExcluir.Click += new System.EventHandler(this.m_btContainerExcluir_Click);
			// 
			// m_btContainerEditar
			// 
			this.m_btContainerEditar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btContainerEditar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btContainerEditar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btContainerEditar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btContainerEditar.Image = ((System.Drawing.Image)(resources.GetObject("m_btContainerEditar.Image")));
			this.m_btContainerEditar.Location = new System.Drawing.Point(123, 12);
			this.m_btContainerEditar.Name = "m_btContainerEditar";
			this.m_btContainerEditar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btContainerEditar.Size = new System.Drawing.Size(25, 25);
			this.m_btContainerEditar.TabIndex = 5;
			this.m_btContainerEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_btContainerEditar.Click += new System.EventHandler(this.m_btContainerEditar_Click);
			// 
			// m_btContainerNovo
			// 
			this.m_btContainerNovo.BackColor = System.Drawing.SystemColors.Control;
			this.m_btContainerNovo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btContainerNovo.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btContainerNovo.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btContainerNovo.Image = ((System.Drawing.Image)(resources.GetObject("m_btContainerNovo.Image")));
			this.m_btContainerNovo.Location = new System.Drawing.Point(91, 12);
			this.m_btContainerNovo.Name = "m_btContainerNovo";
			this.m_btContainerNovo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btContainerNovo.Size = new System.Drawing.Size(25, 25);
			this.m_btContainerNovo.TabIndex = 4;
			this.m_btContainerNovo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_btContainerNovo.Click += new System.EventHandler(this.m_btContainerNovo_Click);
			// 
			// m_lvContainers
			// 
			this.m_lvContainers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lvContainers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							 this.m_colhNumero,
																							 this.m_colhTipo});
			this.m_lvContainers.FullRowSelect = true;
			this.m_lvContainers.HideSelection = false;
			this.m_lvContainers.Location = new System.Drawing.Point(8, 40);
			this.m_lvContainers.Name = "m_lvContainers";
			this.m_lvContainers.Size = new System.Drawing.Size(256, 72);
			this.m_lvContainers.TabIndex = 0;
			this.m_lvContainers.View = System.Windows.Forms.View.Details;
			// 
			// m_colhNumero
			// 
			this.m_colhNumero.Text = "Número";
			this.m_colhNumero.Width = 94;
			// 
			// m_colhTipo
			// 
			this.m_colhTipo.Text = "Tipo";
			this.m_colhTipo.Width = 130;
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(87, 489);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 12;
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(151, 489);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 13;
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// frmFContainers
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(290, 523);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFContainers";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Containers";
			this.Load += new System.EventHandler(this.frmFContainers_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbInformacoes.ResumeLayout(false);
			this.m_gbCargaPerigosa.ResumeLayout(false);
			this.m_gbExcessoCarga.ResumeLayout(false);
			this.m_gbTemperatura.ResumeLayout(false);
			this.m_gbContainers.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFContainers_Load(object sender, System.EventArgs e)
				{
					vMostraCor();
					OnCallCarregaDadosContainersInformacao();
					OnCallContainersRefresh();
				}
			#endregion
			#region Botoes
				private void m_btContainerNovo_Click(object sender, System.EventArgs e)
				{
					if (OnCallContainersNovo())
					{
						OnCallContainersRefresh();
						OnCallCarregaDadosContainersInformacao();
					}
				}

				private void m_btContainerEditar_Click(object sender, System.EventArgs e)
				{
					if (OnCallContainersEdicao())
					{
						OnCallContainersRefresh();
						OnCallCarregaDadosContainersInformacao();
					}
				}

				private void m_btContainerExcluir_Click(object sender, System.EventArgs e)
				{
					if (OnCallContainersExclui())
					{
						OnCallContainersRefresh();
						OnCallCarregaDadosContainersInformacao();
					}
				}

				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					OnCallSalvaDadosContainersInformacao();
					if (OnCallSalvaDados())
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
					case "System.Windows.Forms.ListView":
					case "mdlComponentesGraficos.ComboBox":
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
	}
}
