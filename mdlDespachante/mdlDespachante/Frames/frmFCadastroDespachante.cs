using System;
using System.Collections;

namespace mdlDespachante.Frames
{
	/// <summary>
	/// Summary description for frmFCadastroDespachante.
	/// </summary>
	internal class frmFCadastroDespachante : mdlComponentesGraficos.FormFlutuante
	{
		#region Atributos
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
		protected string m_strEnderecoExecutavel = "";

//		private bool m_bModificado = false;
//		private bool m_bAtivado = true;
		private bool m_bCadastroNovo = false;
		private System.Windows.Forms.GroupBox m_gbFrame;
		private System.Windows.Forms.GroupBox m_gbFields;
		private System.Windows.Forms.Button m_btOk;
		private System.Windows.Forms.Button m_btCancelar;
		private System.Windows.Forms.Label m_lNome;
		private mdlComponentesGraficos.TextBox m_tbNomeDespachante;
		private System.Windows.Forms.Label m_lTelefone;
		private System.Windows.Forms.Label m_lEmail;
		private mdlComponentesGraficos.TextBox m_tbEmailDespachante;
		private mdlComponentesGraficos.TextBox m_tbTelefoneDespachante;
		private System.Windows.Forms.ToolTip m_ttCadastroDespachante;
		private mdlComponentesGraficos.TextBox m_tbCidade;
		private System.Windows.Forms.Label m_lCidade;
		private System.Windows.Forms.Label m_lEstado;
		private mdlComponentesGraficos.ComboBox m_cbEstado;
		private System.Windows.Forms.Label m_lCEP;
		private mdlComponentesGraficos.TextBox m_tbCEP;
		private mdlComponentesGraficos.TextBox m_tbEndereco;
		private System.Windows.Forms.Label m_lEndereco;
		private System.ComponentModel.IContainer components;
		#endregion

		#region Construtores & Destrutores
		public frmFCadastroDespachante(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, string EnderecoExecutavel)
		{
			InitializeComponent();

			m_cls_ter_tratadorErro = tratadorErro;
			m_strEnderecoExecutavel = EnderecoExecutavel;
		}
		public frmFCadastroDespachante(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, string EnderecoExecutavel, bool bCadastroNovo)
		{
			InitializeComponent();

			m_cls_ter_tratadorErro = tratadorErro;
			m_strEnderecoExecutavel = EnderecoExecutavel;
			m_bCadastroNovo = bCadastroNovo;
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
		public delegate void delCallCarregaDadosInterface(ref mdlComponentesGraficos.TextBox tbNome, ref mdlComponentesGraficos.TextBox tbEndereco, ref mdlComponentesGraficos.TextBox tbCidade, ref mdlComponentesGraficos.ComboBox cbEstado, ref mdlComponentesGraficos.TextBox tbCEP,ref mdlComponentesGraficos.TextBox tbEmail,ref mdlComponentesGraficos.TextBox tbTelefone);
		public delegate void delCallCarregaDadosEstadosParaCadastro(ref mdlComponentesGraficos.ComboBox cbEstado);
		public delegate void delCallChecaIntegridadeDados();
		public delegate void delCallSalvaDadosInterface(ref mdlComponentesGraficos.TextBox tbNome, ref mdlComponentesGraficos.TextBox tbEndereco, ref mdlComponentesGraficos.TextBox tbCidade, ref mdlComponentesGraficos.ComboBox cbEstado, ref mdlComponentesGraficos.TextBox tbCEP,ref mdlComponentesGraficos.TextBox tbEmail,ref mdlComponentesGraficos.TextBox tbTelefone);
		public delegate void delCallSalvaDadosBD(bool cadastraNovo);
		#endregion
		#region Events
		// Events BD
		public event delCallCarregaDadosBD eCallCarregaDadosBD;
		public event delCallCarregaDadosInterface eCallCarregaDadosInterface;
		public event delCallCarregaDadosEstadosParaCadastro eCallCarregaDadosEstadosParaCadastro;
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
				eCallCarregaDadosInterface(ref this.m_tbNomeDespachante, ref m_tbEndereco, ref m_tbCidade, ref m_cbEstado, ref m_tbCEP,ref this.m_tbEmailDespachante,ref this.m_tbTelefoneDespachante);
		}
		protected virtual void OnCallCarregaDadosEstadosParaCadastro()
		{
			if (eCallCarregaDadosEstadosParaCadastro != null)
				eCallCarregaDadosEstadosParaCadastro(ref m_cbEstado);
		}
		protected virtual void OnCallChecaIntegridadeDados()
		{
			if (eCallChecaIntegridadeDados != null)
				eCallChecaIntegridadeDados();
		}

		protected virtual void OnCallSalvaDadosInterface()
		{
			if (eCallSalvaDadosInterface != null)
				eCallSalvaDadosInterface(ref this.m_tbNomeDespachante, ref m_tbEndereco, ref m_tbCidade, ref m_cbEstado, ref m_tbCEP,ref this.m_tbEmailDespachante,ref this.m_tbTelefoneDespachante);
		} 

		protected virtual void OnCallSalvaDadosBD()
		{
			if (eCallSalvaDadosBD != null)
				eCallSalvaDadosBD(this.m_bCadastroNovo);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFCadastroDespachante));
			this.m_gbFrame = new System.Windows.Forms.GroupBox();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbFields = new System.Windows.Forms.GroupBox();
			this.m_tbEndereco = new mdlComponentesGraficos.TextBox();
			this.m_tbCEP = new mdlComponentesGraficos.TextBox();
			this.m_lCEP = new System.Windows.Forms.Label();
			this.m_cbEstado = new mdlComponentesGraficos.ComboBox();
			this.m_lEstado = new System.Windows.Forms.Label();
			this.m_tbCidade = new mdlComponentesGraficos.TextBox();
			this.m_lCidade = new System.Windows.Forms.Label();
			this.m_tbEmailDespachante = new mdlComponentesGraficos.TextBox();
			this.m_lEmail = new System.Windows.Forms.Label();
			this.m_tbTelefoneDespachante = new mdlComponentesGraficos.TextBox();
			this.m_lTelefone = new System.Windows.Forms.Label();
			this.m_tbNomeDespachante = new mdlComponentesGraficos.TextBox();
			this.m_lNome = new System.Windows.Forms.Label();
			this.m_lEndereco = new System.Windows.Forms.Label();
			this.m_ttCadastroDespachante = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbFrame.SuspendLayout();
			this.m_gbFields.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbFrame
			// 
			this.m_gbFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFrame.Controls.Add(this.m_btOk);
			this.m_gbFrame.Controls.Add(this.m_btCancelar);
			this.m_gbFrame.Controls.Add(this.m_gbFields);
			this.m_gbFrame.Location = new System.Drawing.Point(2, 0);
			this.m_gbFrame.Name = "m_gbFrame";
			this.m_gbFrame.Size = new System.Drawing.Size(288, 217);
			this.m_gbFrame.TabIndex = 0;
			this.m_gbFrame.TabStop = false;
			// 
			// m_btOk
			// 
			this.m_btOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(84, 186);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 1;
			this.m_ttCadastroDespachante.SetToolTip(this.m_btOk, "Confirmar");
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
			this.m_btCancelar.Location = new System.Drawing.Point(148, 186);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 2;
			this.m_ttCadastroDespachante.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbFields
			// 
			this.m_gbFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFields.Controls.Add(this.m_tbEndereco);
			this.m_gbFields.Controls.Add(this.m_tbCEP);
			this.m_gbFields.Controls.Add(this.m_lCEP);
			this.m_gbFields.Controls.Add(this.m_cbEstado);
			this.m_gbFields.Controls.Add(this.m_lEstado);
			this.m_gbFields.Controls.Add(this.m_tbCidade);
			this.m_gbFields.Controls.Add(this.m_lCidade);
			this.m_gbFields.Controls.Add(this.m_tbEmailDespachante);
			this.m_gbFields.Controls.Add(this.m_lEmail);
			this.m_gbFields.Controls.Add(this.m_tbTelefoneDespachante);
			this.m_gbFields.Controls.Add(this.m_lTelefone);
			this.m_gbFields.Controls.Add(this.m_tbNomeDespachante);
			this.m_gbFields.Controls.Add(this.m_lNome);
			this.m_gbFields.Controls.Add(this.m_lEndereco);
			this.m_gbFields.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbFields.Location = new System.Drawing.Point(8, 8);
			this.m_gbFields.Name = "m_gbFields";
			this.m_gbFields.Size = new System.Drawing.Size(272, 173);
			this.m_gbFields.TabIndex = 0;
			this.m_gbFields.TabStop = false;
			this.m_gbFields.Text = "Cadastro / Edição";
			// 
			// m_tbEndereco
			// 
			this.m_tbEndereco.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.m_tbEndereco.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbEndereco.Location = new System.Drawing.Point(65, 47);
			this.m_tbEndereco.Name = "m_tbEndereco";
			this.m_tbEndereco.Size = new System.Drawing.Size(199, 20);
			this.m_tbEndereco.TabIndex = 2;
			this.m_tbEndereco.Text = "";
			// 
			// m_tbCEP
			// 
			this.m_tbCEP.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.m_tbCEP.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbCEP.Location = new System.Drawing.Point(144, 95);
			this.m_tbCEP.Mask = true;
			this.m_tbCEP.MaskAutomaticSpecialCharacters = true;
			this.m_tbCEP.MaskText = "NNNNN-NNN";
			this.m_tbCEP.Name = "m_tbCEP";
			this.m_tbCEP.Size = new System.Drawing.Size(58, 20);
			this.m_tbCEP.TabIndex = 5;
			this.m_tbCEP.Text = "";
			// 
			// m_lCEP
			// 
			this.m_lCEP.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.m_lCEP.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lCEP.Location = new System.Drawing.Point(109, 97);
			this.m_lCEP.Name = "m_lCEP";
			this.m_lCEP.Size = new System.Drawing.Size(31, 16);
			this.m_lCEP.TabIndex = 0;
			this.m_lCEP.Text = "CEP:";
			this.m_lCEP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_cbEstado
			// 
			this.m_cbEstado.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.m_cbEstado.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_cbEstado.Location = new System.Drawing.Point(65, 94);
			this.m_cbEstado.Name = "m_cbEstado";
			this.m_cbEstado.Size = new System.Drawing.Size(37, 22);
			this.m_cbEstado.TabIndex = 4;
			this.m_ttCadastroDespachante.SetToolTip(this.m_cbEstado, "Selecione o estado");
			// 
			// m_lEstado
			// 
			this.m_lEstado.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.m_lEstado.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lEstado.Location = new System.Drawing.Point(8, 97);
			this.m_lEstado.Name = "m_lEstado";
			this.m_lEstado.Size = new System.Drawing.Size(43, 16);
			this.m_lEstado.TabIndex = 0;
			this.m_lEstado.Text = "Estado:";
			this.m_lEstado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_tbCidade
			// 
			this.m_tbCidade.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.m_tbCidade.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbCidade.Location = new System.Drawing.Point(65, 71);
			this.m_tbCidade.Name = "m_tbCidade";
			this.m_tbCidade.Size = new System.Drawing.Size(199, 20);
			this.m_tbCidade.TabIndex = 3;
			this.m_tbCidade.Text = "";
			// 
			// m_lCidade
			// 
			this.m_lCidade.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.m_lCidade.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lCidade.Location = new System.Drawing.Point(8, 73);
			this.m_lCidade.Name = "m_lCidade";
			this.m_lCidade.Size = new System.Drawing.Size(43, 16);
			this.m_lCidade.TabIndex = 0;
			this.m_lCidade.Text = "Cidade:";
			this.m_lCidade.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_tbEmailDespachante
			// 
			this.m_tbEmailDespachante.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.m_tbEmailDespachante.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbEmailDespachante.Location = new System.Drawing.Point(65, 143);
			this.m_tbEmailDespachante.Name = "m_tbEmailDespachante";
			this.m_tbEmailDespachante.Size = new System.Drawing.Size(199, 20);
			this.m_tbEmailDespachante.TabIndex = 7;
			this.m_tbEmailDespachante.Text = "";
			// 
			// m_lEmail
			// 
			this.m_lEmail.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.m_lEmail.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lEmail.Location = new System.Drawing.Point(8, 145);
			this.m_lEmail.Name = "m_lEmail";
			this.m_lEmail.Size = new System.Drawing.Size(39, 16);
			this.m_lEmail.TabIndex = 0;
			this.m_lEmail.Text = "E-mail:";
			this.m_lEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_tbTelefoneDespachante
			// 
			this.m_tbTelefoneDespachante.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.m_tbTelefoneDespachante.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbTelefoneDespachante.Location = new System.Drawing.Point(65, 119);
			this.m_tbTelefoneDespachante.Name = "m_tbTelefoneDespachante";
			this.m_tbTelefoneDespachante.Size = new System.Drawing.Size(199, 20);
			this.m_tbTelefoneDespachante.TabIndex = 6;
			this.m_tbTelefoneDespachante.Text = "";
			// 
			// m_lTelefone
			// 
			this.m_lTelefone.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.m_lTelefone.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lTelefone.Location = new System.Drawing.Point(8, 121);
			this.m_lTelefone.Name = "m_lTelefone";
			this.m_lTelefone.Size = new System.Drawing.Size(51, 16);
			this.m_lTelefone.TabIndex = 0;
			this.m_lTelefone.Text = "Telefone:";
			this.m_lTelefone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_tbNomeDespachante
			// 
			this.m_tbNomeDespachante.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.m_tbNomeDespachante.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbNomeDespachante.Location = new System.Drawing.Point(48, 21);
			this.m_tbNomeDespachante.Name = "m_tbNomeDespachante";
			this.m_tbNomeDespachante.Size = new System.Drawing.Size(216, 20);
			this.m_tbNomeDespachante.TabIndex = 1;
			this.m_tbNomeDespachante.Text = "";
			// 
			// m_lNome
			// 
			this.m_lNome.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.m_lNome.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lNome.Location = new System.Drawing.Point(8, 23);
			this.m_lNome.Name = "m_lNome";
			this.m_lNome.Size = new System.Drawing.Size(38, 16);
			this.m_lNome.TabIndex = 0;
			this.m_lNome.Text = "Nome:";
			this.m_lNome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_lEndereco
			// 
			this.m_lEndereco.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.m_lEndereco.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lEndereco.Location = new System.Drawing.Point(8, 49);
			this.m_lEndereco.Name = "m_lEndereco";
			this.m_lEndereco.Size = new System.Drawing.Size(56, 16);
			this.m_lEndereco.TabIndex = 7;
			this.m_lEndereco.Text = "Endereço:";
			this.m_lEndereco.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_ttCadastroDespachante
			// 
			this.m_ttCadastroDespachante.AutomaticDelay = 100;
			this.m_ttCadastroDespachante.AutoPopDelay = 5000;
			this.m_ttCadastroDespachante.InitialDelay = 100;
			this.m_ttCadastroDespachante.ReshowDelay = 20;
			// 
			// frmFCadastroDespachante
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 219);
			this.Controls.Add(this.m_gbFrame);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFCadastroDespachante";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Despachantes";
			this.Load += new System.EventHandler(this.frmFCadastroDespachante_Load);
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
						if ((this.Controls[cont].Controls[cont2].GetType().ToString() != "System.Windows.Forms.ListView") && (this.Controls[cont].Controls[cont2].GetType().ToString() != "mdlComponentes.compTextNumber"))
						{
							this.Controls[cont].Controls[cont2].BackColor = this.BackColor;
						}
						for (int cont3 = 0; cont3 < this.Controls[cont].Controls[cont2].Controls.Count; cont3++)
						{
							if ((this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.TextBox") && (this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.ComboBox") ||
								((this.Controls[cont].Controls[cont2].Controls[cont3].Name == "m_lvDadosImportadores") &&
								(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() == 
								"mdlComponentesGraficos.ListView")))
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
		#endregion

		#region Eventos
		#region Load
		private void frmFCadastroDespachante_Load(object sender, System.EventArgs e)
		{
			try 
			{
				this.mostraCor();
				if (this.m_bCadastroNovo == false)
				{
					OnCallCarregaDadosBD();
					OnCallCarregaDadosInterface();
				} 
				else
				{
					OnCallCarregaDadosEstadosParaCadastro();
				}
				this.m_tbNomeDespachante.Focus();
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
				if (this.m_tbNomeDespachante.Text.Trim() != "")
				{
					//this.m_bModificado = true;
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					OnCallSalvaDadosInterface();
					OnCallSalvaDadosBD();
					this.Cursor = System.Windows.Forms.Cursors.Default;
					this.Close();
				} 
				//else 
				//{
					//mdlMensagens.clsMensagens.ShowInformation(this.Text, mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlImportador_frmFImportadorCadEdit_PaisNaoSelecionado));
					//System.Windows.Forms.MessageBox.Show("Não há nenhum item País selecionado.......Selecione",this.Text);
					//this.m_cbPais.SelectedIndex = 0;
					//this.m_cbPais.Focus();
				//}
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
