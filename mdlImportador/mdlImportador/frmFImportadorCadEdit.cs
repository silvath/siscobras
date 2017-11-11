using System;
using System.Collections;

namespace mdlImportador
{
	/// <summary>
	/// Summary description for frmFImportadorCadEdit.
	/// </summary>
	internal class frmFImportadorCadEdit : mdlComponentesGraficos.FormFlutuante
	{
		#region Atributos
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
		protected string m_strEnderecoExecutavel;

		public bool m_bModificado = false;

		protected bool m_bCadastraNovo = false;

		protected frmFImportador m_formFImportador = null;

		protected int m_nCount = -1;

		// Bandeiras
		private System.Windows.Forms.ImageList m_ilBandeiras;

		private System.Windows.Forms.GroupBox m_gbFrame;
		private System.Windows.Forms.GroupBox m_gbFields;
		private mdlComponentesGraficos.TextBox m_ctbNome;
		private System.Windows.Forms.Label m_lNome;
		private System.Windows.Forms.Label m_lEndereco;
		private mdlComponentesGraficos.TextBox m_ctbEndereco;
		private mdlComponentesGraficos.TextBox m_ctbCidade;
		private mdlComponentesGraficos.TextBox m_ctbEstado;
		private mdlComponentesGraficos.TextBox m_ctbTelefone;
		private mdlComponentesGraficos.TextBox m_ctbFax;
		private System.Windows.Forms.Label m_lTelefone;
		private System.Windows.Forms.Label m_lFax;
		private System.Windows.Forms.Label m_lPais;
		private System.Windows.Forms.Label m_lEstado;
		private System.Windows.Forms.Label m_lCidade;
		private mdlComponentesGraficos.ComboBox m_cbPais;
		private System.Windows.Forms.Label m_lObs;
		private mdlComponentesGraficos.TextBox m_ctbSite;
		private System.Windows.Forms.Label m_lSite;
		private mdlComponentesGraficos.TextBox m_ctbEMail;
		private System.Windows.Forms.Label m_lEMail;
		internal System.Windows.Forms.Button m_btOk;
		internal System.Windows.Forms.Button m_btCancelar;
		internal System.Windows.Forms.Button m_btTrocarCor;
		private System.Windows.Forms.ToolTip m_ttImportadorCadEdit;
		private System.Windows.Forms.TextBox m_ctbObs;
		private System.ComponentModel.IContainer components;
		#endregion

		#region Construtores & Destrutores
		public frmFImportadorCadEdit(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, string EnderecoExecutavel,ref System.Windows.Forms.ImageList ilBandeiras, ref frmFImportador formFImportador)
		{
			InitializeComponent();

			m_cls_ter_tratadorErro = tratadorErro;
			m_strEnderecoExecutavel = EnderecoExecutavel;
			m_ilBandeiras = ilBandeiras;
			m_formFImportador = formFImportador;

		}
		public frmFImportadorCadEdit(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, string EnderecoExecutavel,ref System.Windows.Forms.ImageList ilBandeiras, ref frmFImportador formFImportador, bool cadastraNovo)
		{
			InitializeComponent();

			m_cls_ter_tratadorErro = tratadorErro;
			m_strEnderecoExecutavel = EnderecoExecutavel;
			m_ilBandeiras = ilBandeiras;
			m_formFImportador = formFImportador;
			m_bCadastraNovo = cadastraNovo;
		}
		public frmFImportadorCadEdit(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, string EnderecoExecutavel)
		{
			InitializeComponent();

			m_cls_ter_tratadorErro = tratadorErro;
			m_strEnderecoExecutavel = EnderecoExecutavel;
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
		public delegate void delCallCarregaDadosInterface(ref mdlComponentesGraficos.TextBox ctbNome,ref mdlComponentesGraficos.TextBox ctbEndereco,ref mdlComponentesGraficos.TextBox ctbCidade,ref mdlComponentesGraficos.TextBox ctbEstado,ref mdlComponentesGraficos.ComboBox cbPaises,ref mdlComponentesGraficos.TextBox ctbTelefone,ref mdlComponentesGraficos.TextBox ctbFax,ref mdlComponentesGraficos.TextBox ctbEMail,ref mdlComponentesGraficos.TextBox ctbSite,ref System.Windows.Forms.TextBox ctbObs);
		public delegate void delCallCarregaDadosInterfacePaises(ref mdlComponentesGraficos.ComboBox cbPaises);
		public delegate void delCallChecaIntegridadeDados();
		public delegate void delCallSalvaDadosInterface(ref mdlComponentesGraficos.TextBox ctbNome,ref mdlComponentesGraficos.TextBox ctbEndereco,ref mdlComponentesGraficos.TextBox ctbCidade,ref mdlComponentesGraficos.TextBox ctbEstado,ref mdlComponentesGraficos.ComboBox cbPaises,ref mdlComponentesGraficos.TextBox ctbTelefone,ref mdlComponentesGraficos.TextBox ctbFax,ref mdlComponentesGraficos.TextBox ctbEMail,ref mdlComponentesGraficos.TextBox ctbSite,ref System.Windows.Forms.TextBox ctbObs);
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
				eCallCarregaDadosInterface(ref this.m_ctbNome,ref this.m_ctbEndereco,ref this.m_ctbCidade,ref this.m_ctbEstado,ref this.m_cbPais,ref this.m_ctbTelefone,ref this.m_ctbFax,ref this.m_ctbEMail,ref this.m_ctbSite,ref this.m_ctbObs);
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
				eCallSalvaDadosInterface(ref this.m_ctbNome,ref this.m_ctbEndereco,ref this.m_ctbCidade,ref this.m_ctbEstado,ref this.m_cbPais,ref this.m_ctbTelefone,ref this.m_ctbFax,ref this.m_ctbEMail,ref this.m_ctbSite,ref this.m_ctbObs);
		} 

		protected virtual void OnCallSalvaDadosBD()
		{
			if (eCallSalvaDadosBD != null)
				eCallSalvaDadosBD(this.m_bCadastraNovo);
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
								"mdlComponentesGraficos.TextBox") &&
								(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"System.Windows.Forms.TextBox"))
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
		private void pintaCorLabelsCadastro()
		{
			try
			{
				m_lNome.ForeColor = System.Drawing.Color.Red;
				m_lPais.ForeColor = System.Drawing.Color.Red;
			}
			catch (Exception err)
			{
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFImportadorCadEdit));
			this.m_gbFrame = new System.Windows.Forms.GroupBox();
			this.m_btTrocarCor = new System.Windows.Forms.Button();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbFields = new System.Windows.Forms.GroupBox();
			this.m_ctbObs = new System.Windows.Forms.TextBox();
			this.m_lObs = new System.Windows.Forms.Label();
			this.m_ctbSite = new mdlComponentesGraficos.TextBox();
			this.m_lSite = new System.Windows.Forms.Label();
			this.m_ctbEMail = new mdlComponentesGraficos.TextBox();
			this.m_lEMail = new System.Windows.Forms.Label();
			this.m_cbPais = new mdlComponentesGraficos.ComboBox();
			this.m_lTelefone = new System.Windows.Forms.Label();
			this.m_ctbFax = new mdlComponentesGraficos.TextBox();
			this.m_lFax = new System.Windows.Forms.Label();
			this.m_ctbTelefone = new mdlComponentesGraficos.TextBox();
			this.m_ctbEstado = new mdlComponentesGraficos.TextBox();
			this.m_lPais = new System.Windows.Forms.Label();
			this.m_lEstado = new System.Windows.Forms.Label();
			this.m_ctbCidade = new mdlComponentesGraficos.TextBox();
			this.m_lCidade = new System.Windows.Forms.Label();
			this.m_ctbEndereco = new mdlComponentesGraficos.TextBox();
			this.m_lEndereco = new System.Windows.Forms.Label();
			this.m_ctbNome = new mdlComponentesGraficos.TextBox();
			this.m_lNome = new System.Windows.Forms.Label();
			this.m_ttImportadorCadEdit = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbFrame.SuspendLayout();
			this.m_gbFields.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbFrame
			// 
			this.m_gbFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFrame.Controls.Add(this.m_btTrocarCor);
			this.m_gbFrame.Controls.Add(this.m_btOk);
			this.m_gbFrame.Controls.Add(this.m_btCancelar);
			this.m_gbFrame.Controls.Add(this.m_gbFields);
			this.m_gbFrame.Location = new System.Drawing.Point(3, 0);
			this.m_gbFrame.Name = "m_gbFrame";
			this.m_gbFrame.Size = new System.Drawing.Size(380, 300);
			this.m_gbFrame.TabIndex = 0;
			this.m_gbFrame.TabStop = false;
			// 
			// m_btTrocarCor
			// 
			this.m_btTrocarCor.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_btTrocarCor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btTrocarCor.Location = new System.Drawing.Point(4, 9);
			this.m_btTrocarCor.Name = "m_btTrocarCor";
			this.m_btTrocarCor.Size = new System.Drawing.Size(4, 4);
			this.m_btTrocarCor.TabIndex = 13;
			this.m_ttImportadorCadEdit.SetToolTip(this.m_btTrocarCor, "Cor");
			this.m_btTrocarCor.Click += new System.EventHandler(this.m_btTrocarCor_Click);
			// 
			// m_btOk
			// 
			this.m_btOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(130, 269);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 11;
			this.m_ttImportadorCadEdit.SetToolTip(this.m_btOk, "Confirmar");
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(194, 269);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 12;
			this.m_ttImportadorCadEdit.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbFields
			// 
			this.m_gbFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFields.Controls.Add(this.m_ctbObs);
			this.m_gbFields.Controls.Add(this.m_lObs);
			this.m_gbFields.Controls.Add(this.m_ctbSite);
			this.m_gbFields.Controls.Add(this.m_lSite);
			this.m_gbFields.Controls.Add(this.m_ctbEMail);
			this.m_gbFields.Controls.Add(this.m_lEMail);
			this.m_gbFields.Controls.Add(this.m_cbPais);
			this.m_gbFields.Controls.Add(this.m_lTelefone);
			this.m_gbFields.Controls.Add(this.m_ctbFax);
			this.m_gbFields.Controls.Add(this.m_lFax);
			this.m_gbFields.Controls.Add(this.m_ctbTelefone);
			this.m_gbFields.Controls.Add(this.m_ctbEstado);
			this.m_gbFields.Controls.Add(this.m_lPais);
			this.m_gbFields.Controls.Add(this.m_lEstado);
			this.m_gbFields.Controls.Add(this.m_ctbCidade);
			this.m_gbFields.Controls.Add(this.m_lCidade);
			this.m_gbFields.Controls.Add(this.m_ctbEndereco);
			this.m_gbFields.Controls.Add(this.m_lEndereco);
			this.m_gbFields.Controls.Add(this.m_ctbNome);
			this.m_gbFields.Controls.Add(this.m_lNome);
			this.m_gbFields.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbFields.Location = new System.Drawing.Point(8, 8);
			this.m_gbFields.Name = "m_gbFields";
			this.m_gbFields.Size = new System.Drawing.Size(364, 257);
			this.m_gbFields.TabIndex = 0;
			this.m_gbFields.TabStop = false;
			this.m_gbFields.Text = "Cadastro / Edição";
			// 
			// m_ctbObs
			// 
			this.m_ctbObs.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_ctbObs.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_ctbObs.Location = new System.Drawing.Point(71, 188);
			this.m_ctbObs.Multiline = true;
			this.m_ctbObs.Name = "m_ctbObs";
			this.m_ctbObs.Size = new System.Drawing.Size(284, 61);
			this.m_ctbObs.TabIndex = 10;
			this.m_ctbObs.Text = "";
			// 
			// m_lObs
			// 
			this.m_lObs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.m_lObs.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lObs.Location = new System.Drawing.Point(8, 189);
			this.m_lObs.Name = "m_lObs";
			this.m_lObs.Size = new System.Drawing.Size(34, 19);
			this.m_lObs.TabIndex = 0;
			this.m_lObs.Text = "Obs.:";
			// 
			// m_ctbSite
			// 
			this.m_ctbSite.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_ctbSite.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_ctbSite.Location = new System.Drawing.Point(71, 164);
			this.m_ctbSite.Name = "m_ctbSite";
			this.m_ctbSite.Size = new System.Drawing.Size(284, 20);
			this.m_ctbSite.TabIndex = 9;
			this.m_ctbSite.Text = "";
			// 
			// m_lSite
			// 
			this.m_lSite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.m_lSite.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lSite.Location = new System.Drawing.Point(8, 165);
			this.m_lSite.Name = "m_lSite";
			this.m_lSite.Size = new System.Drawing.Size(29, 19);
			this.m_lSite.TabIndex = 0;
			this.m_lSite.Text = "Site:";
			// 
			// m_ctbEMail
			// 
			this.m_ctbEMail.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_ctbEMail.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_ctbEMail.Location = new System.Drawing.Point(71, 140);
			this.m_ctbEMail.Name = "m_ctbEMail";
			this.m_ctbEMail.Size = new System.Drawing.Size(284, 20);
			this.m_ctbEMail.TabIndex = 8;
			this.m_ctbEMail.Text = "";
			// 
			// m_lEMail
			// 
			this.m_lEMail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.m_lEMail.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lEMail.Location = new System.Drawing.Point(8, 141);
			this.m_lEMail.Name = "m_lEMail";
			this.m_lEMail.Size = new System.Drawing.Size(43, 19);
			this.m_lEMail.TabIndex = 0;
			this.m_lEMail.Text = "E-mail:";
			// 
			// m_cbPais
			// 
			this.m_cbPais.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_cbPais.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_cbPais.GoToNextControlWithEnter = true;
			this.m_cbPais.Location = new System.Drawing.Point(219, 92);
			this.m_cbPais.Name = "m_cbPais";
			this.m_cbPais.Size = new System.Drawing.Size(136, 22);
			this.m_cbPais.TabIndex = 5;
			this.m_ttImportadorCadEdit.SetToolTip(this.m_cbPais, "Selecione o país");
			// 
			// m_lTelefone
			// 
			this.m_lTelefone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.m_lTelefone.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lTelefone.Location = new System.Drawing.Point(8, 117);
			this.m_lTelefone.Name = "m_lTelefone";
			this.m_lTelefone.Size = new System.Drawing.Size(56, 19);
			this.m_lTelefone.TabIndex = 0;
			this.m_lTelefone.Text = "Telefone:";
			// 
			// m_ctbFax
			// 
			this.m_ctbFax.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_ctbFax.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_ctbFax.Location = new System.Drawing.Point(219, 116);
			this.m_ctbFax.Name = "m_ctbFax";
			this.m_ctbFax.Size = new System.Drawing.Size(136, 20);
			this.m_ctbFax.TabIndex = 7;
			this.m_ctbFax.Text = "";
			// 
			// m_lFax
			// 
			this.m_lFax.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.m_lFax.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lFax.Location = new System.Drawing.Point(186, 117);
			this.m_lFax.Name = "m_lFax";
			this.m_lFax.Size = new System.Drawing.Size(29, 19);
			this.m_lFax.TabIndex = 0;
			this.m_lFax.Text = "Fax:";
			// 
			// m_ctbTelefone
			// 
			this.m_ctbTelefone.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_ctbTelefone.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_ctbTelefone.Location = new System.Drawing.Point(71, 116);
			this.m_ctbTelefone.Name = "m_ctbTelefone";
			this.m_ctbTelefone.Size = new System.Drawing.Size(110, 20);
			this.m_ctbTelefone.TabIndex = 6;
			this.m_ctbTelefone.Text = "";
			// 
			// m_ctbEstado
			// 
			this.m_ctbEstado.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_ctbEstado.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_ctbEstado.Location = new System.Drawing.Point(71, 92);
			this.m_ctbEstado.Name = "m_ctbEstado";
			this.m_ctbEstado.Size = new System.Drawing.Size(110, 20);
			this.m_ctbEstado.TabIndex = 4;
			this.m_ctbEstado.Text = "";
			// 
			// m_lPais
			// 
			this.m_lPais.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.m_lPais.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lPais.Location = new System.Drawing.Point(186, 93);
			this.m_lPais.Name = "m_lPais";
			this.m_lPais.Size = new System.Drawing.Size(33, 19);
			this.m_lPais.TabIndex = 0;
			this.m_lPais.Text = "País:";
			// 
			// m_lEstado
			// 
			this.m_lEstado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.m_lEstado.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lEstado.Location = new System.Drawing.Point(8, 93);
			this.m_lEstado.Name = "m_lEstado";
			this.m_lEstado.Size = new System.Drawing.Size(48, 19);
			this.m_lEstado.TabIndex = 0;
			this.m_lEstado.Text = "Estado:";
			// 
			// m_ctbCidade
			// 
			this.m_ctbCidade.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_ctbCidade.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_ctbCidade.Location = new System.Drawing.Point(71, 68);
			this.m_ctbCidade.Name = "m_ctbCidade";
			this.m_ctbCidade.Size = new System.Drawing.Size(284, 20);
			this.m_ctbCidade.TabIndex = 3;
			this.m_ctbCidade.Text = "";
			// 
			// m_lCidade
			// 
			this.m_lCidade.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.m_lCidade.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lCidade.Location = new System.Drawing.Point(8, 69);
			this.m_lCidade.Name = "m_lCidade";
			this.m_lCidade.Size = new System.Drawing.Size(48, 19);
			this.m_lCidade.TabIndex = 0;
			this.m_lCidade.Text = "Cidade:";
			// 
			// m_ctbEndereco
			// 
			this.m_ctbEndereco.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_ctbEndereco.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_ctbEndereco.Location = new System.Drawing.Point(71, 44);
			this.m_ctbEndereco.Name = "m_ctbEndereco";
			this.m_ctbEndereco.Size = new System.Drawing.Size(284, 20);
			this.m_ctbEndereco.TabIndex = 2;
			this.m_ctbEndereco.Text = "";
			// 
			// m_lEndereco
			// 
			this.m_lEndereco.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.m_lEndereco.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lEndereco.Location = new System.Drawing.Point(8, 45);
			this.m_lEndereco.Name = "m_lEndereco";
			this.m_lEndereco.Size = new System.Drawing.Size(61, 19);
			this.m_lEndereco.TabIndex = 0;
			this.m_lEndereco.Text = "Endereço:";
			// 
			// m_ctbNome
			// 
			this.m_ctbNome.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_ctbNome.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_ctbNome.Location = new System.Drawing.Point(71, 20);
			this.m_ctbNome.Name = "m_ctbNome";
			this.m_ctbNome.Size = new System.Drawing.Size(284, 20);
			this.m_ctbNome.TabIndex = 1;
			this.m_ctbNome.Text = "";
			// 
			// m_lNome
			// 
			this.m_lNome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.m_lNome.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lNome.Location = new System.Drawing.Point(8, 22);
			this.m_lNome.Name = "m_lNome";
			this.m_lNome.Size = new System.Drawing.Size(41, 19);
			this.m_lNome.TabIndex = 0;
			this.m_lNome.Text = "Nome:";
			// 
			// m_ttImportadorCadEdit
			// 
			this.m_ttImportadorCadEdit.AutomaticDelay = 100;
			this.m_ttImportadorCadEdit.AutoPopDelay = 5000;
			this.m_ttImportadorCadEdit.InitialDelay = 100;
			this.m_ttImportadorCadEdit.ReshowDelay = 20;
			// 
			// frmFImportadorCadEdit
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(386, 303);
			this.Controls.Add(this.m_gbFrame);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFImportadorCadEdit";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Importadores";
			this.Load += new System.EventHandler(this.frmFImportadorCadEdit_Load);
			this.m_gbFrame.ResumeLayout(false);
			this.m_gbFields.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Get & Set
		public void setTextoGroupBox(string strTexto)
		{
			m_gbFields.Text = strTexto;
		}
		#endregion
		
		#region Eventos
		#region Cor
		private void m_btTrocarCor_Click(object sender, System.EventArgs e)
		{
			try 
			{
				this.trocaCor();
				this.mostraCor();
				if (m_formFImportador != null)
                    m_formFImportador.mostraCor();
			} 
			catch (Exception err) 
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Load
		private void frmFImportadorCadEdit_Load(object sender, System.EventArgs e)
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
					OnCallCarregaDadosInterfacePaises();
					pintaCorLabelsCadastro();
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
		#region OK
		private void m_btOk_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (m_ctbNome.Text.Trim() != "")
				{
					if (this.m_cbPais.ReturnObjectSelectedItem() != null)
					{
						this.m_bModificado = true;
						this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
						OnCallSalvaDadosInterface();
						OnCallSalvaDadosBD();
						if (m_formFImportador != null)
							this.m_formFImportador.refreshAll();
						this.Cursor = System.Windows.Forms.Cursors.Default;
						this.Close();
					}
					else
					{
						mdlMensagens.clsMensagens.ShowInformation(this.Text, mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlImportador_frmFImportadorCadEdit_PaisNaoSelecionado));
						this.m_cbPais.SelectedIndex = 0;
						this.m_cbPais.Focus();
					}
				} 
				else 
				{
					mdlMensagens.clsMensagens.ShowInformation(this.Text, mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlImportador_frmFImportadorCadEdit_NomeImportadorInvalido));
					this.m_ctbNome.Focus();
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
			this.Close();
		}
		#endregion
		#endregion
	}
}
