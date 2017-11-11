using System;
using System.Collections;
using System.Windows.Forms;

namespace mdlEmailInterface
{
	/// <summary>
	/// Summary description for frmFEmailConfiguracao.
	/// </summary>
	internal class frmFEmailConfiguracao : mdlComponentesGraficos.FormFlutuante
	{
		#region Atributos
		private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
		private string m_strEnderecoExecutavel = "";

		public bool m_bModificado = false;

		private bool m_bAtivado = true;

		private bool m_bConfiguracaoInicial = false;

		private frmFEmailInterface m_formFEmailInterface = null;

		private System.Windows.Forms.GroupBox m_gbFrame;
		private System.Windows.Forms.GroupBox m_gbFields;
		private System.Windows.Forms.Label m_lSMTP;
		private System.Windows.Forms.Label m_lUsuario;
		private System.Windows.Forms.Label m_lSenha;
		private mdlComponentesGraficos.TextBox m_tbSMTP;
		private mdlComponentesGraficos.TextBox m_tbUsuario;
		private mdlComponentesGraficos.TextBox m_tbSenha;
		private System.Windows.Forms.Button m_btOk;
		private System.Windows.Forms.Button m_btCancelar;
		private System.Windows.Forms.Button m_btTrocarCor;
		private System.Windows.Forms.ToolTip m_ttConfiguracao;
		private System.Windows.Forms.Label m_lMensagem;
		private mdlComponentesGraficos.ComboBox m_cbTipoAutenticacao;
		private System.Windows.Forms.Label label1;
		private System.ComponentModel.IContainer components = null;
		#endregion

		#region Construtores & Destrutores
		public frmFEmailConfiguracao(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, string EnderecoExecutavel, bool configInicial)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_cls_ter_tratadorErro = tratadorErro;
			m_strEnderecoExecutavel = EnderecoExecutavel;
			m_bConfiguracaoInicial = configInicial;
		}

		public frmFEmailConfiguracao(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, string EnderecoExecutavel, ref frmFEmailInterface formFEmailInterface, bool configInicial)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_cls_ter_tratadorErro = tratadorErro;
			m_strEnderecoExecutavel = EnderecoExecutavel;
			m_formFEmailInterface = formFEmailInterface;
			m_bConfiguracaoInicial = configInicial;
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
		public delegate void delCallCarregaDadosBD();
		public delegate void delCallCarregaDadosInterface(ref mdlComponentesGraficos.TextBox tbSMTP, ref mdlComponentesGraficos.TextBox tbUsuario, ref mdlComponentesGraficos.TextBox tbSenha, ref mdlComponentesGraficos.ComboBox cbAuth);
		public delegate void delCallAlteraDadosInterface(ref mdlComponentesGraficos.TextBox tbSMTP, ref mdlComponentesGraficos.TextBox tbUsuario, ref mdlComponentesGraficos.TextBox tbSenha, ref mdlComponentesGraficos.ComboBox cbAuth);
		public delegate void delCallSalvaDadosInterface(ref mdlComponentesGraficos.TextBox tbSMTP, ref mdlComponentesGraficos.TextBox tbUsuario, ref mdlComponentesGraficos.TextBox tbSenha, ref mdlComponentesGraficos.ComboBox cbAuth);
		public delegate void delCallSalvaDadosBD(bool bModificado);
		#endregion
		#region Events
		public event delCallCarregaDadosBD eCallCarregaDadosBD;
		public event delCallCarregaDadosInterface eCallCarregaDadosInterface;
		public event delCallAlteraDadosInterface eCallAlteraDadosInterface;
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
				eCallCarregaDadosInterface(ref m_tbSMTP, ref m_tbUsuario, ref m_tbSenha, ref m_cbTipoAutenticacao);
		}
		protected virtual void OnCallAlteraDadosInterface()
		{
			if (eCallAlteraDadosInterface != null)
				eCallAlteraDadosInterface(ref m_tbSMTP, ref m_tbUsuario, ref m_tbSenha, ref m_cbTipoAutenticacao);
		}
		protected virtual void OnCallSalvaDadosInterface()
		{
			if (eCallSalvaDadosInterface != null)
				eCallSalvaDadosInterface(ref m_tbSMTP, ref m_tbUsuario, ref m_tbSenha, ref m_cbTipoAutenticacao);
		}
		protected virtual void OnCallSalvaDadosBD()
		{
			if (eCallSalvaDadosBD != null)
				eCallSalvaDadosBD(m_bModificado);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFEmailConfiguracao));
			this.m_gbFrame = new System.Windows.Forms.GroupBox();
			this.m_btTrocarCor = new System.Windows.Forms.Button();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbFields = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.m_cbTipoAutenticacao = new mdlComponentesGraficos.ComboBox();
			this.m_lMensagem = new System.Windows.Forms.Label();
			this.m_tbSenha = new mdlComponentesGraficos.TextBox();
			this.m_tbUsuario = new mdlComponentesGraficos.TextBox();
			this.m_tbSMTP = new mdlComponentesGraficos.TextBox();
			this.m_lSenha = new System.Windows.Forms.Label();
			this.m_lUsuario = new System.Windows.Forms.Label();
			this.m_lSMTP = new System.Windows.Forms.Label();
			this.m_ttConfiguracao = new System.Windows.Forms.ToolTip(this.components);
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
			this.m_gbFrame.Location = new System.Drawing.Point(2, 0);
			this.m_gbFrame.Name = "m_gbFrame";
			this.m_gbFrame.Size = new System.Drawing.Size(236, 237);
			this.m_gbFrame.TabIndex = 0;
			this.m_gbFrame.TabStop = false;
			// 
			// m_btTrocarCor
			// 
			this.m_btTrocarCor.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_btTrocarCor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btTrocarCor.Location = new System.Drawing.Point(3, 9);
			this.m_btTrocarCor.Name = "m_btTrocarCor";
			this.m_btTrocarCor.Size = new System.Drawing.Size(4, 4);
			this.m_btTrocarCor.TabIndex = 7;
			this.m_ttConfiguracao.SetToolTip(this.m_btTrocarCor, "Cor");
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
			this.m_btOk.Location = new System.Drawing.Point(58, 206);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 5;
			this.m_ttConfiguracao.SetToolTip(this.m_btOk, "Confirmar");
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
			this.m_btCancelar.Location = new System.Drawing.Point(122, 206);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 6;
			this.m_ttConfiguracao.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbFields
			// 
			this.m_gbFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFields.Controls.Add(this.label1);
			this.m_gbFields.Controls.Add(this.m_cbTipoAutenticacao);
			this.m_gbFields.Controls.Add(this.m_lMensagem);
			this.m_gbFields.Controls.Add(this.m_tbSenha);
			this.m_gbFields.Controls.Add(this.m_tbUsuario);
			this.m_gbFields.Controls.Add(this.m_tbSMTP);
			this.m_gbFields.Controls.Add(this.m_lSenha);
			this.m_gbFields.Controls.Add(this.m_lUsuario);
			this.m_gbFields.Controls.Add(this.m_lSMTP);
			this.m_gbFields.Font = new System.Drawing.Font("Arial", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbFields.Location = new System.Drawing.Point(8, 8);
			this.m_gbFields.Name = "m_gbFields";
			this.m_gbFields.Size = new System.Drawing.Size(220, 193);
			this.m_gbFields.TabIndex = 0;
			this.m_gbFields.TabStop = false;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(8, 91);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(42, 18);
			this.label1.TabIndex = 0;
			this.label1.Text = "Auth:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_cbTipoAutenticacao
			// 
			this.m_cbTipoAutenticacao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_cbTipoAutenticacao.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_cbTipoAutenticacao.GoToNextControlWithEnter = true;
			this.m_cbTipoAutenticacao.Items.AddRange(new object[] {
																	  "Automático",
																	  "Autenticação Plana",
																	  "Autenticação Cifrada",
																	  "Sem Autenticação"});
			this.m_cbTipoAutenticacao.Location = new System.Drawing.Point(65, 88);
			this.m_cbTipoAutenticacao.Name = "m_cbTipoAutenticacao";
			this.m_cbTipoAutenticacao.Size = new System.Drawing.Size(147, 22);
			this.m_cbTipoAutenticacao.TabIndex = 1;
			this.m_ttConfiguracao.SetToolTip(this.m_cbTipoAutenticacao, "Selecione o tipo de autenticação requerida pelo seu servidor SMTP");
			this.m_cbTipoAutenticacao.SelectedIndexChanged += new System.EventHandler(this.m_cbTipoAutenticacao_SelectedIndexChanged);
			// 
			// m_lMensagem
			// 
			this.m_lMensagem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lMensagem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_lMensagem.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lMensagem.Location = new System.Drawing.Point(8, 16);
			this.m_lMensagem.Name = "m_lMensagem";
			this.m_lMensagem.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_lMensagem.Size = new System.Drawing.Size(204, 69);
			this.m_lMensagem.TabIndex = 0;
			this.m_lMensagem.Text = "Para enviar seus documentos pelo Siscomail, informe os dados abaixo. Em caso de d" +
				"úvida, fale com seu Provedor de Internet.";
			this.m_lMensagem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_tbSenha
			// 
			this.m_tbSenha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_tbSenha.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbSenha.Location = new System.Drawing.Point(65, 162);
			this.m_tbSenha.Name = "m_tbSenha";
			this.m_tbSenha.PasswordChar = '*';
			this.m_tbSenha.Size = new System.Drawing.Size(147, 20);
			this.m_tbSenha.TabIndex = 4;
			this.m_tbSenha.Text = "";
			this.m_ttConfiguracao.SetToolTip(this.m_tbSenha, "Senha do usuário");
			// 
			// m_tbUsuario
			// 
			this.m_tbUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_tbUsuario.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbUsuario.Location = new System.Drawing.Point(65, 138);
			this.m_tbUsuario.Name = "m_tbUsuario";
			this.m_tbUsuario.Size = new System.Drawing.Size(147, 20);
			this.m_tbUsuario.TabIndex = 3;
			this.m_tbUsuario.Text = "";
			this.m_ttConfiguracao.SetToolTip(this.m_tbUsuario, "Usuario autorizado a enviar e-mail no servidor indicado");
			// 
			// m_tbSMTP
			// 
			this.m_tbSMTP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_tbSMTP.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbSMTP.Location = new System.Drawing.Point(65, 114);
			this.m_tbSMTP.Name = "m_tbSMTP";
			this.m_tbSMTP.Size = new System.Drawing.Size(147, 20);
			this.m_tbSMTP.TabIndex = 2;
			this.m_tbSMTP.Text = "";
			this.m_ttConfiguracao.SetToolTip(this.m_tbSMTP, "Servidor para envio de e-mail");
			// 
			// m_lSenha
			// 
			this.m_lSenha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lSenha.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lSenha.Location = new System.Drawing.Point(8, 165);
			this.m_lSenha.Name = "m_lSenha";
			this.m_lSenha.Size = new System.Drawing.Size(44, 18);
			this.m_lSenha.TabIndex = 0;
			this.m_lSenha.Text = "Senha:";
			this.m_lSenha.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_lUsuario
			// 
			this.m_lUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lUsuario.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lUsuario.Location = new System.Drawing.Point(8, 141);
			this.m_lUsuario.Name = "m_lUsuario";
			this.m_lUsuario.Size = new System.Drawing.Size(51, 18);
			this.m_lUsuario.TabIndex = 0;
			this.m_lUsuario.Text = "Usuário:";
			this.m_lUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_lSMTP
			// 
			this.m_lSMTP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lSMTP.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lSMTP.Location = new System.Drawing.Point(8, 117);
			this.m_lSMTP.Name = "m_lSMTP";
			this.m_lSMTP.Size = new System.Drawing.Size(42, 18);
			this.m_lSMTP.TabIndex = 0;
			this.m_lSMTP.Text = "SMTP:";
			this.m_lSMTP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_ttConfiguracao
			// 
			this.m_ttConfiguracao.AutomaticDelay = 100;
			this.m_ttConfiguracao.AutoPopDelay = 5000;
			this.m_ttConfiguracao.InitialDelay = 100;
			this.m_ttConfiguracao.ReshowDelay = 20;
			// 
			// frmFEmailConfiguracao
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(240, 239);
			this.Controls.Add(this.m_gbFrame);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFEmailConfiguracao";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Sisco-M@il";
			this.Load += new System.EventHandler(this.frmFEmailConfiguracao_Load);
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
						if ((this.Controls[cont].Controls[cont2].GetType().ToString() != "mdlComponentes.compTextBox") && (this.Controls[cont].Controls[cont2].GetType().ToString() != "mdlComponentes.compTextNumber"))
						{
							this.Controls[cont].Controls[cont2].BackColor = this.BackColor;
						}
						for (int cont3 = 0; cont3 < this.Controls[cont].Controls[cont2].Controls.Count; cont3++)
						{
							if ((this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"System.Windows.Forms.TextBox") &&
								(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.TextBox") &&
								(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.ListView") &&
								(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.ComboBox"))
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

		#region Verifica textos
		private bool verificaTextos()
		{
			try
			{
				if (m_tbSMTP.Text.Trim() == "")
				{
					mdlMensagens.clsMensagens.ShowInformation(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlEmailInterface_frmFEmailConfiguracao_SMTPInvalido));
					//MessageBox.Show("Digite o nome do servidor SMTP.",this.Text);
					m_tbSMTP.Focus();
					return false;
				}
				else if ((m_tbUsuario.Enabled) && (m_tbUsuario.Text.Trim() == ""))
				{
					mdlMensagens.clsMensagens.ShowInformation(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlEmailInterface_frmFEmailConfiguracao_UsuarioInvalido));
					//MessageBox.Show("Digite o nome do usuário.",this.Text);
					m_tbUsuario.Focus();
					return false;
				}
				else if ((m_tbSenha.Enabled) && (m_tbSenha.Text.Trim() == ""))
				{
					mdlMensagens.clsMensagens.ShowInformation(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlEmailInterface_frmFEmailConfiguracao_SenhaInvalida));
					//MessageBox.Show("Digite a senha para o usuário cadastrado.",this.Text);
					m_tbSenha.Focus();
					return false;
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
			return true;
		}
		#endregion

		#region Eventos
		#region OK
		private void m_btOk_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (verificaTextos())
				{
					m_bModificado = true;
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
			this.Close();
		}
		#endregion
		#region Cor
		private void m_btTrocarCor_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				this.trocaCor();
				if (m_formFEmailInterface != null)
					m_formFEmailInterface.mostraCor();
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
		private void frmFEmailConfiguracao_Load(object sender, System.EventArgs e)
		{
			if (m_bAtivado)
			{
				m_bAtivado = false;
				try
				{
					this.mostraCor();
					if (!m_bConfiguracaoInicial)
					{
						OnCallCarregaDadosBD();
						OnCallCarregaDadosInterface();
					}
					else
					{
						OnCallCarregaDadosInterface();
						//m_btCancelar.Visible = false;
						//m_btOk.SetBounds(90, m_btOk.Bounds.Y, m_btOk.Bounds.Width, m_btOk.Bounds.Height);
					}
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
				m_bAtivado = true;
			}
		}
		#endregion
		#region CbAuth Selected Index Changed
		private void m_cbTipoAutenticacao_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (m_bAtivado)
			{
				m_bAtivado = false;
				try
				{
					//OnCallSalvaDadosInterface();
					OnCallAlteraDadosInterface();
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
				m_bAtivado = true;
			}
		}
		#endregion
		#endregion
	}
}
