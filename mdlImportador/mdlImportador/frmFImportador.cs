using System;
using System.Collections;

namespace mdlImportador
{
	/// <summary>
	/// Summary description for frmFImportador.
	/// </summary>
	internal class frmFImportador : mdlComponentesGraficos.FormFlutuante
	{		
		#region Atributos
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
		protected string m_strEnderecoExecutavel;

		public bool m_bModificado = false;
		protected bool m_bAtiva = true;

		protected int m_nCount = -1;

		// Bandeiras
		private System.Windows.Forms.ImageList m_ilBandeiras;

		private System.Windows.Forms.GroupBox m_gbFrame;
		private System.Windows.Forms.GroupBox m_gbInformacoes;
		private System.Windows.Forms.Button m_btOk;
		private System.Windows.Forms.Button m_btCancelar;
		private mdlComponentesGraficos.ListView m_lvImportadores;
		private mdlComponentesGraficos.ListView m_lvDadosImportadores;
		private System.Windows.Forms.Button m_btExcluir;
		private System.Windows.Forms.Button m_btEditar;
		private System.Windows.Forms.Button m_btNovo;
		private System.Windows.Forms.Button m_btBancos;
		private System.Windows.Forms.Button m_btEnderecoEntrega;
		private System.Windows.Forms.CheckBox m_cbMostraDadosImportador;
		private System.Windows.Forms.Label m_lDadosImportador;
		private System.Windows.Forms.ColumnHeader m_chFirst;
		private System.Windows.Forms.ToolTip m_ttImportadores;
		private System.Windows.Forms.ColumnHeader m_chImportador;
		private System.Windows.Forms.Button m_btTrocarCor;

		private System.ComponentModel.IContainer components;
		#endregion

		#region Construtores & Destrutores
		public frmFImportador(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, string EnderecoExecutavel,ref System.Windows.Forms.ImageList ilBandeiras)
		{
			InitializeComponent();

			m_cls_ter_tratadorErro = tratadorErro;
			m_strEnderecoExecutavel = EnderecoExecutavel;
			m_ilBandeiras = ilBandeiras;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFImportador));
			this.m_gbFrame = new System.Windows.Forms.GroupBox();
			this.m_btTrocarCor = new System.Windows.Forms.Button();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbInformacoes = new System.Windows.Forms.GroupBox();
			this.m_cbMostraDadosImportador = new System.Windows.Forms.CheckBox();
			this.m_btBancos = new System.Windows.Forms.Button();
			this.m_btEnderecoEntrega = new System.Windows.Forms.Button();
			this.m_btExcluir = new System.Windows.Forms.Button();
			this.m_btEditar = new System.Windows.Forms.Button();
			this.m_btNovo = new System.Windows.Forms.Button();
			this.m_lDadosImportador = new System.Windows.Forms.Label();
			this.m_lvDadosImportadores = new mdlComponentesGraficos.ListView();
			this.m_chFirst = new System.Windows.Forms.ColumnHeader();
			this.m_lvImportadores = new mdlComponentesGraficos.ListView();
			this.m_chImportador = new System.Windows.Forms.ColumnHeader();
			this.m_ttImportadores = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbFrame.SuspendLayout();
			this.m_gbInformacoes.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbFrame
			// 
			this.m_gbFrame.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_gbFrame.Controls.Add(this.m_btTrocarCor);
			this.m_gbFrame.Controls.Add(this.m_btOk);
			this.m_gbFrame.Controls.Add(this.m_btCancelar);
			this.m_gbFrame.Controls.Add(this.m_gbInformacoes);
			this.m_gbFrame.Location = new System.Drawing.Point(4, 0);
			this.m_gbFrame.Name = "m_gbFrame";
			this.m_gbFrame.Size = new System.Drawing.Size(358, 355);
			this.m_gbFrame.TabIndex = 0;
			this.m_gbFrame.TabStop = false;
			// 
			// m_btTrocarCor
			// 
			this.m_btTrocarCor.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_btTrocarCor.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_btTrocarCor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btTrocarCor.Location = new System.Drawing.Point(4, 9);
			this.m_btTrocarCor.Name = "m_btTrocarCor";
			this.m_btTrocarCor.Size = new System.Drawing.Size(4, 4);
			this.m_btTrocarCor.TabIndex = 11;
			this.m_ttImportadores.SetToolTip(this.m_btTrocarCor, "Cor");
			this.m_btTrocarCor.Click += new System.EventHandler(this.m_btTrocarCor_Click);
			// 
			// m_btOk
			// 
			this.m_btOk.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(119, 325);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 8;
			this.m_ttImportadores.SetToolTip(this.m_btOk, "Confirmar");
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(183, 325);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 9;
			this.m_ttImportadores.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbInformacoes
			// 
			this.m_gbInformacoes.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_gbInformacoes.Controls.Add(this.m_cbMostraDadosImportador);
			this.m_gbInformacoes.Controls.Add(this.m_btBancos);
			this.m_gbInformacoes.Controls.Add(this.m_btEnderecoEntrega);
			this.m_gbInformacoes.Controls.Add(this.m_btExcluir);
			this.m_gbInformacoes.Controls.Add(this.m_btEditar);
			this.m_gbInformacoes.Controls.Add(this.m_btNovo);
			this.m_gbInformacoes.Controls.Add(this.m_lDadosImportador);
			this.m_gbInformacoes.Controls.Add(this.m_lvDadosImportadores);
			this.m_gbInformacoes.Controls.Add(this.m_lvImportadores);
			this.m_gbInformacoes.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbInformacoes.Location = new System.Drawing.Point(8, 8);
			this.m_gbInformacoes.Name = "m_gbInformacoes";
			this.m_gbInformacoes.Size = new System.Drawing.Size(342, 311);
			this.m_gbInformacoes.TabIndex = 0;
			this.m_gbInformacoes.TabStop = false;
			// 
			// m_cbMostraDadosImportador
			// 
			this.m_cbMostraDadosImportador.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_cbMostraDadosImportador.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_cbMostraDadosImportador.Location = new System.Drawing.Point(10, 46);
			this.m_cbMostraDadosImportador.Name = "m_cbMostraDadosImportador";
			this.m_cbMostraDadosImportador.Size = new System.Drawing.Size(182, 24);
			this.m_cbMostraDadosImportador.TabIndex = 11;
			this.m_cbMostraDadosImportador.Text = "Detalhes do importador";
			this.m_ttImportadores.SetToolTip(this.m_cbMostraDadosImportador, "Mostra detalhes do importador selecionado");
			this.m_cbMostraDadosImportador.CheckedChanged += new System.EventHandler(this.m_cbMostraDadosImportador_CheckedChanged);
			// 
			// m_btBancos
			// 
			this.m_btBancos.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_btBancos.BackColor = System.Drawing.SystemColors.Control;
			this.m_btBancos.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btBancos.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btBancos.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btBancos.Image = ((System.Drawing.Image)(resources.GetObject("m_btBancos.Image")));
			this.m_btBancos.Location = new System.Drawing.Point(278, 22);
			this.m_btBancos.Name = "m_btBancos";
			this.m_btBancos.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btBancos.Size = new System.Drawing.Size(25, 25);
			this.m_btBancos.TabIndex = 4;
			this.m_btBancos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttImportadores.SetToolTip(this.m_btBancos, "Banco(s)");
			this.m_btBancos.Click += new System.EventHandler(this.m_btBancos_Click);
			// 
			// m_btEnderecoEntrega
			// 
			this.m_btEnderecoEntrega.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_btEnderecoEntrega.BackColor = System.Drawing.SystemColors.Control;
			this.m_btEnderecoEntrega.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btEnderecoEntrega.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btEnderecoEntrega.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btEnderecoEntrega.Image = ((System.Drawing.Image)(resources.GetObject("m_btEnderecoEntrega.Image")));
			this.m_btEnderecoEntrega.Location = new System.Drawing.Point(310, 22);
			this.m_btEnderecoEntrega.Name = "m_btEnderecoEntrega";
			this.m_btEnderecoEntrega.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btEnderecoEntrega.Size = new System.Drawing.Size(25, 25);
			this.m_btEnderecoEntrega.TabIndex = 5;
			this.m_btEnderecoEntrega.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttImportadores.SetToolTip(this.m_btEnderecoEntrega, "Endereço(s) de entrega");
			this.m_btEnderecoEntrega.Click += new System.EventHandler(this.m_btEnderecoEntrega_Click);
			// 
			// m_btExcluir
			// 
			this.m_btExcluir.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_btExcluir.BackColor = System.Drawing.SystemColors.Control;
			this.m_btExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btExcluir.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btExcluir.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btExcluir.Image = ((System.Drawing.Image)(resources.GetObject("m_btExcluir.Image")));
			this.m_btExcluir.Location = new System.Drawing.Point(191, 21);
			this.m_btExcluir.Name = "m_btExcluir";
			this.m_btExcluir.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btExcluir.Size = new System.Drawing.Size(25, 25);
			this.m_btExcluir.TabIndex = 3;
			this.m_btExcluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttImportadores.SetToolTip(this.m_btExcluir, "Excluir");
			this.m_btExcluir.Click += new System.EventHandler(this.m_btExcluir_Click);
			// 
			// m_btEditar
			// 
			this.m_btEditar.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_btEditar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btEditar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btEditar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btEditar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btEditar.Image = ((System.Drawing.Image)(resources.GetObject("m_btEditar.Image")));
			this.m_btEditar.Location = new System.Drawing.Point(159, 21);
			this.m_btEditar.Name = "m_btEditar";
			this.m_btEditar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btEditar.Size = new System.Drawing.Size(25, 25);
			this.m_btEditar.TabIndex = 2;
			this.m_btEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttImportadores.SetToolTip(this.m_btEditar, "Editar");
			this.m_btEditar.Click += new System.EventHandler(this.m_btEditar_Click);
			// 
			// m_btNovo
			// 
			this.m_btNovo.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_btNovo.BackColor = System.Drawing.SystemColors.Control;
			this.m_btNovo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btNovo.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btNovo.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btNovo.Image = ((System.Drawing.Image)(resources.GetObject("m_btNovo.Image")));
			this.m_btNovo.Location = new System.Drawing.Point(127, 21);
			this.m_btNovo.Name = "m_btNovo";
			this.m_btNovo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btNovo.Size = new System.Drawing.Size(25, 25);
			this.m_btNovo.TabIndex = 1;
			this.m_btNovo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttImportadores.SetToolTip(this.m_btNovo, "Novo");
			this.m_btNovo.Click += new System.EventHandler(this.m_btNovo_Click);
			// 
			// m_lDadosImportador
			// 
			this.m_lDadosImportador.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_lDadosImportador.Font = new System.Drawing.Font("Arial", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lDadosImportador.Location = new System.Drawing.Point(6, 202);
			this.m_lDadosImportador.Name = "m_lDadosImportador";
			this.m_lDadosImportador.Size = new System.Drawing.Size(167, 18);
			this.m_lDadosImportador.TabIndex = 2;
			this.m_lDadosImportador.Text = "Dados do importador:";
			this.m_lDadosImportador.Visible = false;
			// 
			// m_lvDadosImportadores
			// 
			this.m_lvDadosImportadores.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_lvDadosImportadores.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_lvDadosImportadores.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																									this.m_chFirst});
			this.m_lvDadosImportadores.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lvDadosImportadores.FullRowSelect = true;
			this.m_lvDadosImportadores.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lvDadosImportadores.HideSelection = false;
			this.m_lvDadosImportadores.Location = new System.Drawing.Point(8, 229);
			this.m_lvDadosImportadores.Name = "m_lvDadosImportadores";
			this.m_lvDadosImportadores.Size = new System.Drawing.Size(326, 74);
			this.m_lvDadosImportadores.TabIndex = 7;
			this.m_lvDadosImportadores.View = System.Windows.Forms.View.Details;
			this.m_lvDadosImportadores.Visible = false;
			// 
			// m_chFirst
			// 
			this.m_chFirst.Width = 306;
			// 
			// m_lvImportadores
			// 
			this.m_lvImportadores.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.m_lvImportadores.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_lvImportadores.CausesValidation = false;
			this.m_lvImportadores.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							   this.m_chImportador});
			this.m_lvImportadores.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lvImportadores.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lvImportadores.HideSelection = false;
			this.m_lvImportadores.Location = new System.Drawing.Point(8, 71);
			this.m_lvImportadores.Name = "m_lvImportadores";
			this.m_lvImportadores.Size = new System.Drawing.Size(326, 232);
			this.m_lvImportadores.TabIndex = 6;
			this.m_ttImportadores.SetToolTip(this.m_lvImportadores, "Selecionar Importador");
			this.m_lvImportadores.View = System.Windows.Forms.View.Details;
			this.m_lvImportadores.DoubleClick += new System.EventHandler(this.m_lvImportadores_DoubleClick);
			this.m_lvImportadores.Click += new System.EventHandler(this.m_lvImportadores_Click);
			// 
			// m_chImportador
			// 
			this.m_chImportador.Width = 300;
			// 
			// m_ttImportadores
			// 
			this.m_ttImportadores.AutomaticDelay = 100;
			this.m_ttImportadores.AutoPopDelay = 5000;
			this.m_ttImportadores.InitialDelay = 100;
			this.m_ttImportadores.ReshowDelay = 20;
			// 
			// frmFImportador
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(366, 358);
			this.Controls.Add(this.m_gbFrame);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFImportador";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Importadores";
			this.Load += new System.EventHandler(this.frmFImportador_Load);
			this.m_gbFrame.ResumeLayout(false);
			this.m_gbInformacoes.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Delegate
		// Delegate para BD
		public delegate void delCallCarregaDadosBD();
		public delegate void delCallCarregaDadosBDImportadores(ref mdlComponentesGraficos.ListView lvImportadores);
		public delegate void delCallCarregaDadosInterface(ref mdlComponentesGraficos.ListView lvImportadores, ref System.Windows.Forms.Button btEditar, ref System.Windows.Forms.Button btExcluir, ref System.Windows.Forms.Button btNovo);
		public delegate void delCallCarregaDadosImportadorInterface(ref mdlComponentesGraficos.ListView lvDadosImportadores);
		public delegate void delCallChecaIntegridadeDados();
		public delegate void delCallSalvaDadosInterface();
		public delegate void delCallSalvaDadosBD(bool bModificado);
		// Delegate para Editar Importadores
		public delegate void delCallEditaImportador();
		public delegate void delCallCadastraImportador();
		public delegate void delCallRemoveImportador(ref mdlComponentesGraficos.ListView lvImportadores);
		// Delegate para Mostrar os Endereços de Entrega
		public delegate void delCallMostraEnderecoEntrega();
		// Delegate para Mostrar os Bancos dos Importadores
		public delegate void delCallMostraBancoImportador();
		#endregion
		#region Events
		// Eventos BD
		public event delCallCarregaDadosBD eCallCarregaDadosBD;
		public event delCallCarregaDadosBDImportadores eCallCarregaDadosBDImportadores;
		public event delCallCarregaDadosInterface eCallCarregaDadosInterface;
		public event delCallCarregaDadosImportadorInterface eCallCarregaDadosImportadorInterface;
		public event delCallChecaIntegridadeDados eCallChecaIntegridadeDados;
		public event delCallSalvaDadosInterface eCallSalvaDadosInterface;
		public event delCallSalvaDadosBD eCallSalvaDadosBD;
		// Eventos Editar / Cadastrar Importadores
		public event delCallEditaImportador eCallEditaImportador;
		public event delCallCadastraImportador eCallCadastraImportador;
		public event delCallRemoveImportador eCallRemoveImportador;
		// Evento Mostrar Endereços de Entrega
		public event delCallMostraEnderecoEntrega eCallMostraEnderecoEntrega;
		// Evento Mostrar Banco do Importador
		public event delCallMostraBancoImportador eCallMostraBancoImportador;
		#endregion
		#region Events Methods
		protected virtual void OnCallCarregaDadosBD()
		{
			if (eCallCarregaDadosBD != null)
				eCallCarregaDadosBD();
		}
		protected virtual void OnCallCarregaDadosBDImportadores()
		{
			if (eCallCarregaDadosBDImportadores != null)
				eCallCarregaDadosBDImportadores(ref this.m_lvImportadores);
		} 
		protected virtual void OnCallCarregaDadosImportadorInterface()
		{
			if (eCallCarregaDadosImportadorInterface != null)
				eCallCarregaDadosImportadorInterface(ref this.m_lvDadosImportadores);
		}
		protected virtual void OnCallCarregaDadosInterface()
		{
			if (eCallCarregaDadosInterface != null)
				eCallCarregaDadosInterface(ref this.m_lvImportadores, ref this.m_btEditar, ref this.m_btExcluir, ref this.m_btNovo);
		}
		protected virtual void OnCallChecaIntegridadeDados()
		{
			if (eCallChecaIntegridadeDados != null)
				eCallChecaIntegridadeDados();
		}
		protected virtual void OnCallSalvaDadosInterface()
		{
			if (eCallSalvaDadosInterface != null)
				eCallSalvaDadosInterface();
		} 

		protected virtual void OnCallSalvaDadosBD()
		{
			if (eCallSalvaDadosBD != null)
				eCallSalvaDadosBD(this.m_bModificado);
		}
		protected virtual void OnCallCadastraImportador()
		{
			if (eCallCadastraImportador != null)
				eCallCadastraImportador();
		}
		protected virtual void OnCallEditaImportador()
		{
			if (eCallEditaImportador != null)
				eCallEditaImportador();
		}
		protected virtual void OnCallRemoveImportador()
		{
			if (eCallRemoveImportador != null)
				eCallRemoveImportador(ref this.m_lvImportadores);
		}
		protected virtual void OnCallMostraEnderecoEntrega()
		{
			if (eCallMostraEnderecoEntrega != null)
				eCallMostraEnderecoEntrega();
		}
		protected virtual void OncallMostraBancoImportador()
		{
			if (eCallMostraBancoImportador != null)
				eCallMostraBancoImportador();
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
								"mdlComponentesGraficos.ListView") ||
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
		
		#region Refresh Lista e Dados dos Importadores
		public void refreshAll()
		{
			try 
			{
				this.mostraCor();
				OnCallCarregaDadosInterface();
				OnCallCarregaDadosImportadorInterface();
				this.m_lvImportadores.Focus();
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		public void refresh()
		{
			try
			{
				this.mostraCor();
				OnCallCarregaDadosInterface();
				this.m_lvImportadores.Focus();
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Métodos para manipulação da ImageList
		public void mostraBandeiraAtual()
		{
			try
			{
				if (m_ilBandeiras != null)
				{
					//if (this.m_lvListaIdiomas.SelectedItems.Count > 0)
					//{
						int nIdIdioma;
						System.Drawing.Bitmap bmpBandeira;
						nIdIdioma = 1;
						bmpBandeira = (System.Drawing.Bitmap)m_ilBandeiras.Images[nIdIdioma - 1];
						this.Icon = System.Drawing.Icon.FromHandle(bmpBandeira.GetHicon());
					//}
				}
			} 
			catch (Exception erro) 
			{
				Object err = erro;
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion

		#region Get & Set
		public void setaCaptionFrame(string strCaption)
		{
			this.Text = strCaption;
		}
		#endregion

		#region Eventos
		#region Cor
		private void m_btTrocarCor_Click(object sender, System.EventArgs e)
		{
			try 
			{
				this.trocaCor();
			} 
			catch (Exception err) 
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Mostra Dados
		private void m_cbMostraDadosImportador_CheckedChanged(object sender, System.EventArgs e)
		{
			if (!m_cbMostraDadosImportador.Checked)
			{
				m_lvDadosImportadores.Visible = false;
				m_lDadosImportador.Visible = false;
				m_lvImportadores.SetBounds(m_lvImportadores.Bounds.Location.X,m_lvImportadores.Bounds.Location.Y,m_lvImportadores.Size.Width, 232);
			} 
			else if (m_cbMostraDadosImportador.Checked)
			{
				m_lvDadosImportadores.Visible = true;
				m_lDadosImportador.Visible = false;
				m_lvImportadores.SetBounds(m_lvImportadores.Bounds.Location.X,m_lvImportadores.Bounds.Location.Y,m_lvImportadores.Size.Width, 148);
			}
		}
		#endregion
		#region Load
		private void frmFImportador_Load(object sender, System.EventArgs e)
		{
			try 
			{
				this.mostraCor();
				OnCallCarregaDadosBD();
				OnCallCarregaDadosBDImportadores();
				OnCallCarregaDadosInterface();
				OnCallCarregaDadosImportadorInterface();
				this.m_lvImportadores.Focus();
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
				this.m_bModificado = true;
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				OnCallSalvaDadosInterface();
				OnCallSalvaDadosBD();
				this.Cursor = System.Windows.Forms.Cursors.Default;
				this.Close();
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
		#region Editar
		private void m_btEditar_Click(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			if (m_lvImportadores.SelectedItems.Count > 0)
			{
				OnCallEditaImportador();
			}
			else
			{
				mdlMensagens.clsMensagens.ShowInformation(this.Text, mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlImportador_frmFImportador_ImportadorNaoSelecionadoEdicao));
				//System.Windows.Forms.MessageBox.Show("Você precisa selecionar o importador que deseja editar!",this.Text);
			}
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}
		#endregion
		#region Novo
		private void m_btNovo_Click(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			OnCallCadastraImportador();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}
		#endregion
		#region Excluir
		private void m_btExcluir_Click(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			if (m_lvImportadores.SelectedItems.Count > 0)
			{
				OnCallRemoveImportador();
				this.refreshAll();
			}
			else
			{
				mdlMensagens.clsMensagens.ShowInformation(this.Text, mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlImportador_frmFImportador_ImportadorNaoSelecionadoExclusao));
				//System.Windows.Forms.MessageBox.Show("Você precisa selecionar o importador que deseja excluir!",this.Text);
			}
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}
		#endregion
		#region Endereço de Entrega
		private void m_btEnderecoEntrega_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				OnCallMostraEnderecoEntrega();
				this.Cursor = System.Windows.Forms.Cursors.Default;
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Bancos
		private void m_btBancos_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				OncallMostraBancoImportador();
				this.Cursor = System.Windows.Forms.Cursors.Default;
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region List View Clique
		private void m_lvImportadores_Click(object sender, System.EventArgs e)
		{
			if (m_bAtiva == true)
			{
				m_bAtiva = false;
				OnCallCarregaDadosBDImportadores();
				OnCallCarregaDadosImportadorInterface();
				m_bAtiva = true;
			}
		}
		#endregion
		#region List View Duplo Clique
		private void m_lvImportadores_DoubleClick(object sender, System.EventArgs e)
		{
			try 
			{
				m_btEditar_Click(sender, e);
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
