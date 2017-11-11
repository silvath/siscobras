using System;
using System.Collections;
using System.Windows.Forms;

namespace mdlEmailInterface
{
	/// <summary>
	/// Summary description for frmFEmailInterface.
	/// </summary>
	internal class frmFEmailInterface : mdlComponentesGraficos.FormFlutuante
	{
		#region Atributos
		private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
		private string m_strEnderecoExecutavel = "";

		internal string Remetente
		{
			get
			{
				return m_tbCampoDe.Text;
			}
			set
			{
				m_tbCampoDe.Text = value;
			}
		}
		internal System.Collections.ArrayList Destinatarios
		{
			set
			{
				for (int nCount = 0; nCount < value.Count - 1; nCount++)
                    m_tbCampoPara.Text += value[nCount].ToString() + "; ";
				m_tbCampoPara.Text += value[value.Count - 1].ToString();
			}
		}
		internal string Assunto
		{
			get
			{
				return m_tbCampoAssunto.Text;
			}
			set
			{
				m_tbCampoAssunto.Text = value;
			}
		}
		internal string Mensagem
		{
			get
			{
				return m_tbCampoMensagem.Text;
			}
			set
			{
				m_tbCampoMensagem.Text = value;
			}
		}

		internal System.Collections.ArrayList Arquivos
		{
			get
			{
				System.Collections.ArrayList arlRetorno = new System.Collections.ArrayList();
				for (int nCount = 0; nCount < m_lvArquivos.Items.Count; nCount++)
					arlRetorno.Add(m_lvArquivos.Items[nCount].Text);
				return arlRetorno;
			}
			set
			{
				for (int nCount = 0; nCount < value.Count; nCount++)
					m_lvArquivos.Items.Add(value[nCount].ToString());
			}
		}


		protected mdlComponentesGraficos.MessageBalloon m_mgblBalaoToolTip = null;

		private bool m_bModificado = false;
		private bool m_bMostrarBaloes = true;
		private System.Windows.Forms.GroupBox m_gbFrame;
		internal System.Windows.Forms.Button m_btTrocarCor;
		internal System.Windows.Forms.Button m_btOk;
		internal System.Windows.Forms.Button m_btCancelar;
		private System.Windows.Forms.GroupBox m_gbFields;
		private mdlComponentesGraficos.ListView m_lvArquivos;
		private System.Windows.Forms.Button m_btExcluir;
		private System.Windows.Forms.Button m_btNovo;
		private System.Windows.Forms.Label m_lDe;
		private System.Windows.Forms.Label m_lPara;
		private mdlComponentesGraficos.TextBox m_tbCampoDe;
		private mdlComponentesGraficos.TextBox m_tbCampoPara;
		private System.Windows.Forms.Label m_lAssunto;
		private mdlComponentesGraficos.TextBox m_tbCampoAssunto;
		private System.Windows.Forms.Label m_lArquivos;
		private System.Windows.Forms.Label m_lMensagem;
		private System.Windows.Forms.TextBox m_tbCampoMensagem;
		private System.Windows.Forms.ToolTip m_ttEmailInterface;
		private System.Windows.Forms.OpenFileDialog m_opfdlgAnexos;
		private System.Windows.Forms.ColumnHeader m_chCaminhoDoArquivo;
		private System.Windows.Forms.Button m_btConfigurar;
		private System.Windows.Forms.Timer m_tmEmailInterface;
		private System.ComponentModel.IContainer components = null;
		#endregion

		#region Construtores & Destrutores
		public frmFEmailInterface(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, string EnderecoExecutavel)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_cls_ter_tratadorErro = tratadorErro;
			m_strEnderecoExecutavel = EnderecoExecutavel;
			m_opfdlgAnexos = new System.Windows.Forms.OpenFileDialog();
			m_opfdlgAnexos.Multiselect = true;
		}
		public frmFEmailInterface(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, string EnderecoExecutavel, bool bConfiguracaoOK, bool bVerificarConfiguracao, bool bMostrarBaloes)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_cls_ter_tratadorErro = tratadorErro;
			m_strEnderecoExecutavel = EnderecoExecutavel;
			m_opfdlgAnexos = new System.Windows.Forms.OpenFileDialog();
			m_opfdlgAnexos.Multiselect = true;
			m_btOk.Enabled = bConfiguracaoOK;
			m_bMostrarBaloes = (bVerificarConfiguracao && bMostrarBaloes);
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
		public delegate void delCallCarregaDadosInterface(ref mdlComponentesGraficos.TextBox tbCampoDe);
		public delegate void delCallChecaIntegridadeDados();
		public delegate void delCallSalvaDadosInterface(ref mdlComponentesGraficos.TextBox tbCampoDe);
		public delegate void delCallSalvaDadosBD(bool modificado);
		public delegate bool delCallSetaDadosEnviarEmail(ref mdlComponentesGraficos.TextBox tbCampoPara, ref mdlComponentesGraficos.ListView lvArquivos, ref mdlComponentesGraficos.TextBox tbCampoAssunto, ref System.Windows.Forms.TextBox tbCampoMensagem);
		// Arquivos atachados
		public delegate void delCallInsereNovoArquivo(ref mdlComponentesGraficos.ListView lvArquivos, ref System.Windows.Forms.OpenFileDialog opfdlgAnexos);
		public delegate void delCallExcluiArquivosInseridos(ref mdlComponentesGraficos.ListView lvArquivos);
		// Configuração
		public delegate void delCallConfiguraEmail();
		public delegate void delCallHabilitaBotao(ref System.Windows.Forms.Button btOk);
		#endregion
		#region Events
		// Events BD
		public event delCallCarregaDadosBD eCallCarregaDadosBD;
		public event delCallCarregaDadosInterface eCallCarregaDadosInterface;
		public event delCallChecaIntegridadeDados eCallChecaIntegridadeDados;
		public event delCallSalvaDadosInterface eCallSalvaDadosInterface;
		public event delCallSalvaDadosBD eCallSalvaDadosBD;
		public event delCallSetaDadosEnviarEmail eCallSetaDadosEnviarEmail;
		// Arquivos Atachados
		public event delCallInsereNovoArquivo eCallInsereNovoArquivo;
		public event delCallExcluiArquivosInseridos eCallExcluiArquivosInseridos;
		// Configura E-Mail
		public event delCallConfiguraEmail eCallConfiguraEmail;
		public event delCallHabilitaBotao eCallHabilitaBotao;
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
				eCallCarregaDadosInterface(ref this.m_tbCampoDe);
		}
		protected virtual void OnCallChecaIntegridadeDados()
		{
			if (eCallChecaIntegridadeDados != null)
				eCallChecaIntegridadeDados();
		}

		protected virtual void OnCallSalvaDadosInterface()
		{
			if (eCallSalvaDadosInterface != null)
				eCallSalvaDadosInterface(ref this.m_tbCampoDe);
		} 

		protected virtual void OnCallSalvaDadosBD()
		{
			if (eCallSalvaDadosBD != null)
				eCallSalvaDadosBD(this.m_bModificado);
		}
		protected virtual bool OnCallSetaDadosEnviarEmail()
		{
			if (eCallSetaDadosEnviarEmail != null)
				return (eCallSetaDadosEnviarEmail(ref m_tbCampoPara, ref m_lvArquivos, ref m_tbCampoAssunto, ref m_tbCampoMensagem));
			else
				return false;
		}
		protected virtual void OnCallInsereNovoArquivo()
		{
			if (eCallInsereNovoArquivo != null)
				eCallInsereNovoArquivo(ref m_lvArquivos, ref m_opfdlgAnexos);
		}
		protected virtual void OnCallExcluiArquivosInseridos()
		{
			if (eCallExcluiArquivosInseridos != null)
				eCallExcluiArquivosInseridos(ref m_lvArquivos);
		}
		protected virtual void OnCallConfiguraEmail()
		{
			if (eCallConfiguraEmail != null)
				eCallConfiguraEmail();
		}
		protected virtual void OnCallHabilitaBotao()
		{
			if (eCallHabilitaBotao != null)
				eCallHabilitaBotao(ref m_btOk);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFEmailInterface));
			this.m_gbFrame = new System.Windows.Forms.GroupBox();
			this.m_btTrocarCor = new System.Windows.Forms.Button();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbFields = new System.Windows.Forms.GroupBox();
			this.m_btConfigurar = new System.Windows.Forms.Button();
			this.m_tbCampoMensagem = new System.Windows.Forms.TextBox();
			this.m_lMensagem = new System.Windows.Forms.Label();
			this.m_lArquivos = new System.Windows.Forms.Label();
			this.m_tbCampoAssunto = new mdlComponentesGraficos.TextBox();
			this.m_lAssunto = new System.Windows.Forms.Label();
			this.m_tbCampoPara = new mdlComponentesGraficos.TextBox();
			this.m_tbCampoDe = new mdlComponentesGraficos.TextBox();
			this.m_lPara = new System.Windows.Forms.Label();
			this.m_lDe = new System.Windows.Forms.Label();
			this.m_lvArquivos = new mdlComponentesGraficos.ListView();
			this.m_chCaminhoDoArquivo = new System.Windows.Forms.ColumnHeader();
			this.m_btExcluir = new System.Windows.Forms.Button();
			this.m_btNovo = new System.Windows.Forms.Button();
			this.m_ttEmailInterface = new System.Windows.Forms.ToolTip(this.components);
			this.m_opfdlgAnexos = new System.Windows.Forms.OpenFileDialog();
			this.m_tmEmailInterface = new System.Windows.Forms.Timer(this.components);
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
			this.m_gbFrame.Location = new System.Drawing.Point(4, 0);
			this.m_gbFrame.Name = "m_gbFrame";
			this.m_gbFrame.Size = new System.Drawing.Size(358, 355);
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
			this.m_btTrocarCor.TabIndex = 11;
			this.m_ttEmailInterface.SetToolTip(this.m_btTrocarCor, "Cor");
			this.m_btTrocarCor.Click += new System.EventHandler(this.m_btTrocarCor_Click);
			// 
			// m_btOk
			// 
			this.m_btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(119, 324);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 9;
			this.m_ttEmailInterface.SetToolTip(this.m_btOk, "Enviar E-Mail");
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(183, 324);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 10;
			this.m_ttEmailInterface.SetToolTip(this.m_btCancelar, "Cancelar Mensagem");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbFields
			// 
			this.m_gbFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFields.Controls.Add(this.m_btConfigurar);
			this.m_gbFields.Controls.Add(this.m_tbCampoMensagem);
			this.m_gbFields.Controls.Add(this.m_lMensagem);
			this.m_gbFields.Controls.Add(this.m_lArquivos);
			this.m_gbFields.Controls.Add(this.m_tbCampoAssunto);
			this.m_gbFields.Controls.Add(this.m_lAssunto);
			this.m_gbFields.Controls.Add(this.m_tbCampoPara);
			this.m_gbFields.Controls.Add(this.m_tbCampoDe);
			this.m_gbFields.Controls.Add(this.m_lPara);
			this.m_gbFields.Controls.Add(this.m_lDe);
			this.m_gbFields.Controls.Add(this.m_lvArquivos);
			this.m_gbFields.Controls.Add(this.m_btExcluir);
			this.m_gbFields.Controls.Add(this.m_btNovo);
			this.m_gbFields.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbFields.Location = new System.Drawing.Point(8, 8);
			this.m_gbFields.Name = "m_gbFields";
			this.m_gbFields.Size = new System.Drawing.Size(342, 311);
			this.m_gbFields.TabIndex = 0;
			this.m_gbFields.TabStop = false;
			this.m_gbFields.Text = "Nova Mensagem";
			// 
			// m_btConfigurar
			// 
			this.m_btConfigurar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_btConfigurar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btConfigurar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btConfigurar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btConfigurar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btConfigurar.Image = ((System.Drawing.Image)(resources.GetObject("m_btConfigurar.Image")));
			this.m_btConfigurar.Location = new System.Drawing.Point(309, 70);
			this.m_btConfigurar.Name = "m_btConfigurar";
			this.m_btConfigurar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btConfigurar.Size = new System.Drawing.Size(25, 25);
			this.m_btConfigurar.TabIndex = 9;
			this.m_btConfigurar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttEmailInterface.SetToolTip(this.m_btConfigurar, "Configurar uso do Sisco-M@il");
			this.m_btConfigurar.Click += new System.EventHandler(this.m_btConfigurar_Click);
			// 
			// m_tbCampoMensagem
			// 
			this.m_tbCampoMensagem.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbCampoMensagem.Location = new System.Drawing.Point(8, 181);
			this.m_tbCampoMensagem.Multiline = true;
			this.m_tbCampoMensagem.Name = "m_tbCampoMensagem";
			this.m_tbCampoMensagem.Size = new System.Drawing.Size(326, 123);
			this.m_tbCampoMensagem.TabIndex = 8;
			this.m_tbCampoMensagem.Text = "";
			// 
			// m_lMensagem
			// 
			this.m_lMensagem.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lMensagem.Location = new System.Drawing.Point(8, 163);
			this.m_lMensagem.Name = "m_lMensagem";
			this.m_lMensagem.Size = new System.Drawing.Size(63, 15);
			this.m_lMensagem.TabIndex = 0;
			this.m_lMensagem.Text = "Mensagem:";
			// 
			// m_lArquivos
			// 
			this.m_lArquivos.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lArquivos.Location = new System.Drawing.Point(8, 83);
			this.m_lArquivos.Name = "m_lArquivos";
			this.m_lArquivos.Size = new System.Drawing.Size(104, 15);
			this.m_lArquivos.TabIndex = 0;
			this.m_lArquivos.Text = "Arquivos anexados:";
			// 
			// m_tbCampoAssunto
			// 
			this.m_tbCampoAssunto.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbCampoAssunto.Location = new System.Drawing.Point(56, 139);
			this.m_tbCampoAssunto.Name = "m_tbCampoAssunto";
			this.m_tbCampoAssunto.Size = new System.Drawing.Size(278, 20);
			this.m_tbCampoAssunto.TabIndex = 7;
			this.m_tbCampoAssunto.Text = "";
			// 
			// m_lAssunto
			// 
			this.m_lAssunto.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lAssunto.Location = new System.Drawing.Point(8, 139);
			this.m_lAssunto.Name = "m_lAssunto";
			this.m_lAssunto.Size = new System.Drawing.Size(48, 15);
			this.m_lAssunto.TabIndex = 0;
			this.m_lAssunto.Text = "Assunto:";
			// 
			// m_tbCampoPara
			// 
			this.m_tbCampoPara.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbCampoPara.Location = new System.Drawing.Point(45, 45);
			this.m_tbCampoPara.Name = "m_tbCampoPara";
			this.m_tbCampoPara.Size = new System.Drawing.Size(289, 20);
			this.m_tbCampoPara.TabIndex = 2;
			this.m_tbCampoPara.Text = "";
			this.m_ttEmailInterface.SetToolTip(this.m_tbCampoPara, "Destinatário(s): email@dominio.com;email2@dominio2.com");
			// 
			// m_tbCampoDe
			// 
			this.m_tbCampoDe.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbCampoDe.Location = new System.Drawing.Point(45, 21);
			this.m_tbCampoDe.Name = "m_tbCampoDe";
			this.m_tbCampoDe.Size = new System.Drawing.Size(289, 20);
			this.m_tbCampoDe.TabIndex = 1;
			this.m_tbCampoDe.Text = "";
			this.m_ttEmailInterface.SetToolTip(this.m_tbCampoDe, "Remetente");
			// 
			// m_lPara
			// 
			this.m_lPara.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lPara.Location = new System.Drawing.Point(8, 45);
			this.m_lPara.Name = "m_lPara";
			this.m_lPara.Size = new System.Drawing.Size(31, 15);
			this.m_lPara.TabIndex = 0;
			this.m_lPara.Text = "Para:";
			// 
			// m_lDe
			// 
			this.m_lDe.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lDe.Location = new System.Drawing.Point(8, 21);
			this.m_lDe.Name = "m_lDe";
			this.m_lDe.Size = new System.Drawing.Size(22, 15);
			this.m_lDe.TabIndex = 0;
			this.m_lDe.Text = "De:";
			// 
			// m_lvArquivos
			// 
			this.m_lvArquivos.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.m_lvArquivos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						   this.m_chCaminhoDoArquivo});
			this.m_lvArquivos.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lvArquivos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lvArquivos.HideSelection = false;
			this.m_lvArquivos.Location = new System.Drawing.Point(8, 101);
			this.m_lvArquivos.Name = "m_lvArquivos";
			this.m_lvArquivos.Size = new System.Drawing.Size(326, 33);
			this.m_lvArquivos.TabIndex = 6;
			this.m_ttEmailInterface.SetToolTip(this.m_lvArquivos, "Lista de arquivos anexados");
			this.m_lvArquivos.View = System.Windows.Forms.View.Details;
			// 
			// m_chCaminhoDoArquivo
			// 
			this.m_chCaminhoDoArquivo.Width = 290;
			// 
			// m_btExcluir
			// 
			this.m_btExcluir.BackColor = System.Drawing.SystemColors.Control;
			this.m_btExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btExcluir.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btExcluir.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btExcluir.Image = ((System.Drawing.Image)(resources.GetObject("m_btExcluir.Image")));
			this.m_btExcluir.Location = new System.Drawing.Point(175, 71);
			this.m_btExcluir.Name = "m_btExcluir";
			this.m_btExcluir.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btExcluir.Size = new System.Drawing.Size(25, 25);
			this.m_btExcluir.TabIndex = 5;
			this.m_btExcluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttEmailInterface.SetToolTip(this.m_btExcluir, "Excluir arquivo anexado");
			this.m_btExcluir.Click += new System.EventHandler(this.m_btExcluir_Click);
			// 
			// m_btNovo
			// 
			this.m_btNovo.BackColor = System.Drawing.SystemColors.Control;
			this.m_btNovo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btNovo.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btNovo.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btNovo.Image = ((System.Drawing.Image)(resources.GetObject("m_btNovo.Image")));
			this.m_btNovo.Location = new System.Drawing.Point(143, 71);
			this.m_btNovo.Name = "m_btNovo";
			this.m_btNovo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btNovo.Size = new System.Drawing.Size(25, 25);
			this.m_btNovo.TabIndex = 3;
			this.m_btNovo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttEmailInterface.SetToolTip(this.m_btNovo, "Anexar arquivo");
			this.m_btNovo.Click += new System.EventHandler(this.m_btNovo_Click);
			// 
			// m_ttEmailInterface
			// 
			this.m_ttEmailInterface.AutomaticDelay = 100;
			this.m_ttEmailInterface.AutoPopDelay = 5000;
			this.m_ttEmailInterface.InitialDelay = 100;
			this.m_ttEmailInterface.ReshowDelay = 20;
			// 
			// m_opfdlgAnexos
			// 
			this.m_opfdlgAnexos.InitialDirectory = "C:\\";
			this.m_opfdlgAnexos.Multiselect = true;
			this.m_opfdlgAnexos.Title = "Anexar arquivos";
			// 
			// m_tmEmailInterface
			// 
			this.m_tmEmailInterface.Enabled = true;
			this.m_tmEmailInterface.Interval = 250;
			this.m_tmEmailInterface.Tick += new System.EventHandler(this.m_tmEmailInterface_Tick);
			// 
			// frmFEmailInterface
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(366, 358);
			this.Controls.Add(this.m_gbFrame);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFEmailInterface";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Sisco-M@il";
			this.Load += new System.EventHandler(this.frmFEmailInterface_Load);
			this.Activated += new System.EventHandler(this.frmFEmailInterface_Activated);
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
								"mdlComponentesGraficos.ListView"))
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

		#region Valida Dados da Interface
		private bool validaDadosInterface()
		{
			try
			{
				if (m_tbCampoDe.Text.Trim() != "")
				{
					if (m_tbCampoPara.Text.Trim() != "")
					{
						if (m_tbCampoAssunto.Text.Trim() != "")
						{
							if (m_tbCampoMensagem.Text.Trim() != "")
							{
								return true;
							}
							else
							{
								//mdlMensagens.clsMensagens.ShowInformation("SiscoM@il",mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlEmailInterface_frmFEmailInterface_RemetenteInvalido), System.Windows.Forms.MessageBoxButtons.OK);
								System.Windows.Forms.MessageBox.Show("A Mensagem precisa ser preenchida", this.Text);
								return false;
							}
						}
						else
						{
							//mdlMensagens.clsMensagens.ShowInformation("SiscoM@il",mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlEmailInterface_frmFEmailInterface_RemetenteInvalido), System.Windows.Forms.MessageBoxButtons.OK);
							System.Windows.Forms.MessageBox.Show("O Assunto do E-Mail precisa ser preenchido", this.Text);
							m_tbCampoAssunto.Focus();
							return false;
						}
					}
					else
					{
						mdlMensagens.clsMensagens.ShowInformation(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlEmailInterface_frmFEmailInterface_DestinatarioInvalido));
						//System.Windows.Forms.MessageBox.Show("Destinatário(s) não preenchido(s).", this.Text);
						m_tbCampoPara.Focus();
						return false;
					}
				}
				else
				{
					mdlMensagens.clsMensagens.ShowInformation(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlEmailInterface_frmFEmailInterface_RemetenteInvalido));
					//System.Windows.Forms.MessageBox.Show("Remetente não preenchido.", this.Text);
					m_tbCampoDe.Focus();
					return false;
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
			return false;
		}
		#endregion

		#region Métodos Show Balão
		public void fechaBalao()
		{
			try
			{
				if (m_mgblBalaoToolTip != null)
					m_mgblBalaoToolTip.Close();
			}
			catch
			{
			}
		}
		public void mostraBalao(string strMensagem, System.Windows.Forms.Control ctrlBalao)
		{
			try
			{
				if (m_mgblBalaoToolTip != null)
					m_mgblBalaoToolTip.Close();
				if (m_bMostrarBaloes)
				{
					m_mgblBalaoToolTip = new mdlComponentesGraficos.MessageBalloon();
					m_mgblBalaoToolTip.Caption = mdlConstantes.clsConstantes.BALLONTIP_DEFAULT_CAPTION;
					m_mgblBalaoToolTip.Content = strMensagem;
					m_mgblBalaoToolTip.Icon = System.Drawing.SystemIcons.Information;
					m_mgblBalaoToolTip.CloseOnMouseClick = true;
					m_mgblBalaoToolTip.CloseOnDeactivate = false;
					m_mgblBalaoToolTip.CloseOnKeyPress = false;
					m_mgblBalaoToolTip.ShowBalloon((System.Windows.Forms.Control)ctrlBalao);
				}
			}
			catch (Exception err)
			{
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
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
		private void frmFEmailInterface_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.mostraCor();
				OnCallCarregaDadosInterface();
				m_tmEmailInterface.Start();
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
		#region Ok
		private void m_btOk_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (validaDadosInterface())
				{
					this.m_bModificado = true;
					OnCallSalvaDadosInterface();
					OnCallSalvaDadosBD();
					this.Close();
					if (!OnCallSetaDadosEnviarEmail())
						this.ShowDialog();
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Excluir
		private void m_btExcluir_Click(object sender, System.EventArgs e)
		{
			try
			{
				OnCallExcluiArquivosInseridos();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Novo
		private void m_btNovo_Click(object sender, System.EventArgs e)
		{
			try
			{
				OnCallInsereNovoArquivo();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Configuração
		private void m_btConfigurar_Click(object sender, System.EventArgs e)
		{
			try
			{
				OnCallConfiguraEmail();
				if (m_btOk.Enabled == false)
					OnCallHabilitaBotao();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Activated
		private void frmFEmailInterface_Activated(object sender, System.EventArgs e)
		{
			try
			{
				if (m_tbCampoDe.Text.Trim() == "")
				{
					m_tbCampoDe.Focus();
				}
				else if (m_tbCampoPara.Text.Trim() == "")
				{
					m_tbCampoPara.Focus();
				}
				else if (m_tbCampoAssunto.Text.Trim() == "")
				{
					m_tbCampoAssunto.Focus();
				}
				else if (m_tbCampoMensagem.Text.Trim() == "")
				{
					m_tbCampoMensagem.Focus();
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Timer
		private void m_tmEmailInterface_Tick(object sender, System.EventArgs e)
		{
			m_tmEmailInterface.Stop();
			fechaBalao();
			mostraBalao(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.BALLOONTIP_mdlEmailInterface_frmFEmailInterface_VerificarConfiguracao.ToString()), (System.Windows.Forms.Control)m_btConfigurar);
		}
		#endregion
		#endregion
	}
}
