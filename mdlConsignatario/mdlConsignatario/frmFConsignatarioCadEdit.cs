using System;
using System.Collections;
using System.Windows.Forms;

namespace mdlConsignatario
{
	/// <summary>
	/// Summary description for frmFConsignatarioCadEdit.
	/// </summary>
	internal class frmFConsignatarioCadEdit : mdlComponentesGraficos.FormFlutuante
	{
		#region Atributos
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
		protected string m_strEnderecoExecutavel;

		private frmFConsignatario m_formFConsignatario = null;

		public bool m_bModificado = false;
		protected bool m_bCadastraNovo = false;

		private System.Windows.Forms.GroupBox m_gbFrame;
		private System.Windows.Forms.GroupBox m_gbFields;
		private mdlComponentesGraficos.ComboBox m_cbPais;
		private mdlComponentesGraficos.TextBox m_ctbEstado;
		private System.Windows.Forms.Label m_lPais;
		private System.Windows.Forms.Label m_lEstado;
		private mdlComponentesGraficos.TextBox m_ctbCidade;
		private System.Windows.Forms.Label m_lCidade;
		private mdlComponentesGraficos.TextBox m_ctbEndereco;
		private System.Windows.Forms.Label m_lEndereco;
		internal System.Windows.Forms.Button m_btTrocarCor;
		internal System.Windows.Forms.Button m_btOk;
		internal System.Windows.Forms.Button m_btCancelar;
		private mdlComponentesGraficos.TextBox m_ctbNome;
		private System.Windows.Forms.Label m_lNome;
		private System.Windows.Forms.ToolTip m_ttConsignatarioCadEdit;
		private System.ComponentModel.IContainer components;
		#endregion

		#region Construtores & Destrutores
		public frmFConsignatarioCadEdit(ref mdlTratamentoErro.clsTratamentoErro tratadorErro,string EnderecoExecutavel)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_cls_ter_tratadorErro = tratadorErro;
			m_strEnderecoExecutavel = EnderecoExecutavel;
		}
		public frmFConsignatarioCadEdit(ref mdlTratamentoErro.clsTratamentoErro tratadorErro,string EnderecoExecutavel, ref frmFConsignatario frmConsignatario)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_cls_ter_tratadorErro = tratadorErro;
			m_strEnderecoExecutavel = EnderecoExecutavel;
			m_formFConsignatario = frmConsignatario;
		}
		public frmFConsignatarioCadEdit(ref mdlTratamentoErro.clsTratamentoErro tratadorErro,string EnderecoExecutavel, ref frmFConsignatario frmConsignatario, bool cadastraNovo)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_cls_ter_tratadorErro = tratadorErro;
			m_strEnderecoExecutavel = EnderecoExecutavel;
			m_formFConsignatario = frmConsignatario;
			m_bCadastraNovo = cadastraNovo;
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

		#region Delegate
		// Delegate para BD
		public delegate void delCallCarregaDadosBD();
		public delegate void delCallCarregaDadosInterface(ref mdlComponentesGraficos.TextBox ctbNome, ref mdlComponentesGraficos.TextBox ctbEndereco,ref mdlComponentesGraficos.TextBox ctbCidade,ref mdlComponentesGraficos.TextBox ctbEstado,ref mdlComponentesGraficos.ComboBox cbPaises);
		public delegate void delCallCarregaDadosInterfacePaises(ref mdlComponentesGraficos.ComboBox cbPaises);
		public delegate void delCallChecaIntegridadeDados();
		public delegate void delCallSalvaDadosInterface(ref mdlComponentesGraficos.TextBox ctbNome, ref mdlComponentesGraficos.TextBox ctbEndereco,ref mdlComponentesGraficos.TextBox ctbCidade,ref mdlComponentesGraficos.TextBox ctbEstado,ref mdlComponentesGraficos.ComboBox cbPaises);
		public delegate void delCallSalvaDadosBD(bool cadastraNovo);
		#endregion
		#region Events
		// Events BD
		public event delCallCarregaDadosBD eCallCarregaDadosBD;
		public event delCallCarregaDadosInterface eCallCarregaDadosInterface;
		public event delCallCarregaDadosInterfacePaises eCallCarregaDadosInterfacePaises;
		public event delCallChecaIntegridadeDados eCallChecaIntegridadeDados;
		public event delCallSalvaDadosInterface eCallSalvaDadosInterface;
		public event delCallSalvaDadosBD eCallSalvaDadosBD;
		#endregion
		#region Events Methods
		protected virtual void OnCallCarregaDadosBD()
		{
			if (eCallCarregaDadosBD != null)
				eCallCarregaDadosBD();
		}
 
		protected virtual void OnCallCarregaDadosInterface()
		{
			if (eCallCarregaDadosInterface != null)
				eCallCarregaDadosInterface(ref this.m_ctbNome,ref this.m_ctbEndereco,ref this.m_ctbCidade,ref this.m_ctbEstado,ref this.m_cbPais);
		}
		protected virtual void OnCallCarregaDadosInterfacePaises()
		{
			if (eCallCarregaDadosInterfacePaises != null)
				eCallCarregaDadosInterfacePaises(ref this.m_cbPais);
		}
		protected virtual void OnCallChecaIntegridadeDados()
		{
			if (eCallChecaIntegridadeDados != null)
				eCallChecaIntegridadeDados();
		}

		protected virtual void OnCallSalvaDadosInterface()
		{
			if (eCallSalvaDadosInterface != null)
				eCallSalvaDadosInterface(ref this.m_ctbNome,ref this.m_ctbEndereco,ref this.m_ctbCidade,ref this.m_ctbEstado,ref this.m_cbPais);
		} 

		protected virtual void OnCallSalvaDadosBD()
		{
			if (eCallSalvaDadosBD != null)
				eCallSalvaDadosBD(this.m_bCadastraNovo);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFConsignatarioCadEdit));
			this.m_gbFrame = new System.Windows.Forms.GroupBox();
			this.m_gbFields = new System.Windows.Forms.GroupBox();
			this.m_ctbNome = new mdlComponentesGraficos.TextBox();
			this.m_lNome = new System.Windows.Forms.Label();
			this.m_cbPais = new mdlComponentesGraficos.ComboBox();
			this.m_ctbEstado = new mdlComponentesGraficos.TextBox();
			this.m_lPais = new System.Windows.Forms.Label();
			this.m_lEstado = new System.Windows.Forms.Label();
			this.m_ctbCidade = new mdlComponentesGraficos.TextBox();
			this.m_lCidade = new System.Windows.Forms.Label();
			this.m_ctbEndereco = new mdlComponentesGraficos.TextBox();
			this.m_lEndereco = new System.Windows.Forms.Label();
			this.m_btTrocarCor = new System.Windows.Forms.Button();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_ttConsignatarioCadEdit = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbFrame.SuspendLayout();
			this.m_gbFields.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbFrame
			// 
			this.m_gbFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFrame.Controls.Add(this.m_gbFields);
			this.m_gbFrame.Controls.Add(this.m_btTrocarCor);
			this.m_gbFrame.Controls.Add(this.m_btOk);
			this.m_gbFrame.Controls.Add(this.m_btCancelar);
			this.m_gbFrame.Location = new System.Drawing.Point(2, 0);
			this.m_gbFrame.Name = "m_gbFrame";
			this.m_gbFrame.Size = new System.Drawing.Size(383, 165);
			this.m_gbFrame.TabIndex = 0;
			this.m_gbFrame.TabStop = false;
			// 
			// m_gbFields
			// 
			this.m_gbFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFields.Controls.Add(this.m_ctbNome);
			this.m_gbFields.Controls.Add(this.m_lNome);
			this.m_gbFields.Controls.Add(this.m_cbPais);
			this.m_gbFields.Controls.Add(this.m_ctbEstado);
			this.m_gbFields.Controls.Add(this.m_lPais);
			this.m_gbFields.Controls.Add(this.m_lEstado);
			this.m_gbFields.Controls.Add(this.m_ctbCidade);
			this.m_gbFields.Controls.Add(this.m_lCidade);
			this.m_gbFields.Controls.Add(this.m_ctbEndereco);
			this.m_gbFields.Controls.Add(this.m_lEndereco);
			this.m_gbFields.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbFields.Location = new System.Drawing.Point(8, 9);
			this.m_gbFields.Name = "m_gbFields";
			this.m_gbFields.Size = new System.Drawing.Size(367, 120);
			this.m_gbFields.TabIndex = 0;
			this.m_gbFields.TabStop = false;
			this.m_gbFields.Text = "Cadastro / Edição";
			// 
			// m_ctbNome
			// 
			this.m_ctbNome.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_ctbNome.AutoSize = false;
			this.m_ctbNome.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_ctbNome.Location = new System.Drawing.Point(71, 19);
			this.m_ctbNome.Name = "m_ctbNome";
			this.m_ctbNome.Size = new System.Drawing.Size(287, 19);
			this.m_ctbNome.TabIndex = 1;
			this.m_ctbNome.Text = "";
			// 
			// m_lNome
			// 
			this.m_lNome.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lNome.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lNome.Location = new System.Drawing.Point(8, 22);
			this.m_lNome.Name = "m_lNome";
			this.m_lNome.Size = new System.Drawing.Size(63, 15);
			this.m_lNome.TabIndex = 0;
			this.m_lNome.Text = "Nome:";
			// 
			// m_cbPais
			// 
			this.m_cbPais.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_cbPais.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_cbPais.Location = new System.Drawing.Point(213, 94);
			this.m_cbPais.Name = "m_cbPais";
			this.m_cbPais.Size = new System.Drawing.Size(145, 22);
			this.m_cbPais.TabIndex = 5;
			this.m_ttConsignatarioCadEdit.SetToolTip(this.m_cbPais, "Selecione o país");
			// 
			// m_ctbEstado
			// 
			this.m_ctbEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_ctbEstado.AutoSize = false;
			this.m_ctbEstado.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_ctbEstado.Location = new System.Drawing.Point(71, 94);
			this.m_ctbEstado.Name = "m_ctbEstado";
			this.m_ctbEstado.Size = new System.Drawing.Size(106, 19);
			this.m_ctbEstado.TabIndex = 4;
			this.m_ctbEstado.Text = "";
			// 
			// m_lPais
			// 
			this.m_lPais.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lPais.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lPais.Location = new System.Drawing.Point(180, 96);
			this.m_lPais.Name = "m_lPais";
			this.m_lPais.Size = new System.Drawing.Size(33, 15);
			this.m_lPais.TabIndex = 0;
			this.m_lPais.Text = "País:";
			// 
			// m_lEstado
			// 
			this.m_lEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lEstado.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lEstado.Location = new System.Drawing.Point(8, 96);
			this.m_lEstado.Name = "m_lEstado";
			this.m_lEstado.Size = new System.Drawing.Size(70, 15);
			this.m_lEstado.TabIndex = 0;
			this.m_lEstado.Text = "Estado:";
			// 
			// m_ctbCidade
			// 
			this.m_ctbCidade.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_ctbCidade.AutoSize = false;
			this.m_ctbCidade.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_ctbCidade.Location = new System.Drawing.Point(71, 69);
			this.m_ctbCidade.Name = "m_ctbCidade";
			this.m_ctbCidade.Size = new System.Drawing.Size(287, 19);
			this.m_ctbCidade.TabIndex = 3;
			this.m_ctbCidade.Text = "";
			// 
			// m_lCidade
			// 
			this.m_lCidade.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lCidade.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lCidade.Location = new System.Drawing.Point(8, 72);
			this.m_lCidade.Name = "m_lCidade";
			this.m_lCidade.Size = new System.Drawing.Size(70, 15);
			this.m_lCidade.TabIndex = 0;
			this.m_lCidade.Text = "Cidade:";
			// 
			// m_ctbEndereco
			// 
			this.m_ctbEndereco.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_ctbEndereco.AutoSize = false;
			this.m_ctbEndereco.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_ctbEndereco.Location = new System.Drawing.Point(71, 44);
			this.m_ctbEndereco.Name = "m_ctbEndereco";
			this.m_ctbEndereco.Size = new System.Drawing.Size(287, 19);
			this.m_ctbEndereco.TabIndex = 2;
			this.m_ctbEndereco.Text = "";
			// 
			// m_lEndereco
			// 
			this.m_lEndereco.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lEndereco.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lEndereco.Location = new System.Drawing.Point(8, 47);
			this.m_lEndereco.Name = "m_lEndereco";
			this.m_lEndereco.Size = new System.Drawing.Size(83, 15);
			this.m_lEndereco.TabIndex = 0;
			this.m_lEndereco.Text = "Endereço:";
			// 
			// m_btTrocarCor
			// 
			this.m_btTrocarCor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.m_btTrocarCor.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_btTrocarCor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btTrocarCor.Location = new System.Drawing.Point(4, 9);
			this.m_btTrocarCor.Name = "m_btTrocarCor";
			this.m_btTrocarCor.Size = new System.Drawing.Size(4, 4);
			this.m_btTrocarCor.TabIndex = 8;
			this.m_ttConsignatarioCadEdit.SetToolTip(this.m_btTrocarCor, "Cor");
			this.m_btTrocarCor.Click += new System.EventHandler(this.m_btTrocarCor_Click);
			// 
			// m_btOk
			// 
			this.m_btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(131, 134);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 6;
			this.m_ttConsignatarioCadEdit.SetToolTip(this.m_btOk, "Confirmar");
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(195, 134);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 7;
			this.m_ttConsignatarioCadEdit.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_ttConsignatarioCadEdit
			// 
			this.m_ttConsignatarioCadEdit.AutomaticDelay = 100;
			this.m_ttConsignatarioCadEdit.AutoPopDelay = 5000;
			this.m_ttConsignatarioCadEdit.InitialDelay = 100;
			this.m_ttConsignatarioCadEdit.ReshowDelay = 20;
			// 
			// frmFConsignatarioCadEdit
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(386, 166);
			this.Controls.Add(this.m_gbFrame);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFConsignatarioCadEdit";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Consignatário";
			this.Load += new System.EventHandler(this.frmFConsignatarioCadEdit_Load);
			this.m_gbFrame.ResumeLayout(false);
			this.m_gbFields.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Procedimentos Para Troca de Cor
		/// <summary>
		/// Troca a cor do Formulario Controlado
		/// </summary>
		public void trocaCor()
		{
			try
			{
				mdlPaletaDeCores.clsPaletaDeCores controlPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini", "SiscobrasCorSecundaria");
				controlPaletaCores.mostraCorAtual();
				mostraCor();
			} 
			catch (Exception erro) 
			{
				Object err = (Object)erro;
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		/// <summary>
		/// Mostra a cor do Formulario Controlado
		/// </summary>
		public void mostraCor()
		{
			try
			{
				mdlPaletaDeCores.clsPaletaDeCores controlPaletaDeCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini", "SiscobrasCorSecundaria");
				this.BackColor = controlPaletaDeCores.retornaCorAtual();
				for (int cont = 0; cont < this.Controls.Count; cont++) 
				{
					this.Controls[cont].BackColor = this.BackColor;
					for (int cont2 = 0; cont2 < this.Controls[cont].Controls.Count; cont2++)
					{
						if ((this.Controls[cont].Controls[cont2].GetType().ToString() != "mdlComponentesGraficos.TextBox") && (this.Controls[cont].Controls[cont2].GetType().ToString() != "mdlComponentes.compTextNumber"))
						{
							this.Controls[cont].Controls[cont2].BackColor = this.BackColor;
						}
						for (int cont3 = 0; cont3 < this.Controls[cont].Controls[cont2].Controls.Count; cont3++)
						{
							if ((this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.ComboBox") &&
								(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.TextBox"))
							{
								this.Controls[cont].Controls[cont2].Controls[cont3].BackColor = this.BackColor;
							}
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

		#region Get & Set
		public void setTextoGroupBox(string strTexto)
		{
			m_gbFields.Text = strTexto;
		}
		private void setaCoresCadastro()
		{
			m_lNome.ForeColor = System.Drawing.Color.Red;
			m_lPais.ForeColor = System.Drawing.Color.Red;
		}
		#endregion

		#region Eventos
		#region Cor
		private void m_btTrocarCor_Click(object sender, System.EventArgs e)
		{
			try 
			{
				this.trocaCor();
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				this.mostraCor();
				if (m_formFConsignatario != null)
					m_formFConsignatario.mostraCor();
				this.Cursor = System.Windows.Forms.Cursors.Default;
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Load
		private void frmFConsignatarioCadEdit_Load(object sender, System.EventArgs e)
		{
			try 
			{
				this.mostraCor();
				if (this.m_bCadastraNovo == false)
				{
					OnCallCarregaDadosBD();
					OnCallCarregaDadosInterface();
				} 
				else 
				{
					setaCoresCadastro();
					OnCallCarregaDadosInterfacePaises();
				}
				this.m_ctbNome.Focus();
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Ok
		private void m_btOk_Click(object sender, System.EventArgs e)
		{
			try 
			{
				if (m_ctbNome.Text.Trim() == "")
				{
					mdlMensagens.clsMensagens.ShowInformation(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlConsignatario_frmFConsignatarioCadEdit_NomeConsignatarioInvalido));
					//MessageBox.Show("Digite o nome do consignatário.",this.Text);
					this.m_ctbNome.Focus();
				}
				else if (m_cbPais.ReturnObjectSelectedItem() == null)
				{
					mdlMensagens.clsMensagens.ShowInformation(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlConsignatario_frmFConsignatarioCadEdit_SelecionarPais));
					//MessageBox.Show("Selecione um país.",this.Text);
					this.m_cbPais.SelectedIndex = 0;
					this.m_cbPais.Focus();
				}
				else 
				{
					OnCallSalvaDadosInterface();
					OnCallSalvaDadosBD();
					this.Close();
				}
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Cancelar
		private void m_btCancelar_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.Close();
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#endregion
	}
}
