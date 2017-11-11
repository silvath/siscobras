using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlBancos
{
	/// <summary>
	/// Summary description for frmFBancoExportador.
	/// </summary>
	internal class frmFBancoExportador : mdlComponentesGraficos.FormFlutuante
	{
		#region Delegate
			// Delegate para BD
			public delegate void delCallHabilitaBotaoAnularSelecao(ref System.Windows.Forms.Button btAnular);
			public delegate void delCallCarregaDadosBD();
			public delegate void delCallCarregaDadosBDBancos();
			public delegate void delCallCarregaDadosBDAgencias();
			public delegate void delCallCarregaDadosBDContas();
			public delegate void delCallCarregaDadosBancoSelecionado(ref mdlComponentesGraficos.ListView lvBancos, ref mdlComponentesGraficos.ListView lvAgencias, ref mdlComponentesGraficos.ListView lvContas);
			public delegate void delCallAnularSelecao(ref mdlComponentesGraficos.ListView lvBancos, ref mdlComponentesGraficos.ListView lvAgencias, ref mdlComponentesGraficos.ListView lvContas);
			public delegate void delCallCarregaDadosAgenciaSelecionada(ref mdlComponentesGraficos.ListView lvBancos, ref mdlComponentesGraficos.ListView lvAgencias, ref mdlComponentesGraficos.ListView lvContas);
			public delegate void delCallCarregaDadosContaSelecionada(ref mdlComponentesGraficos.ListView lvContas);
			public delegate void delCallCarregaDadosInterface(ref mdlComponentesGraficos.ListView lvBancos, ref mdlComponentesGraficos.ListView lvAgencias, ref mdlComponentesGraficos.ListView lvContas, ref System.Windows.Forms.RichTextBox rtbInformacoes,ref System.Windows.Forms.Button btEditar, ref System.Windows.Forms.Button btExcluir, ref System.Windows.Forms.Button btNovo);
			public delegate void delCallCarregaDadosInterfaceAgencia(ref mdlComponentesGraficos.ListView lvAgencias);
			public delegate void delCallCarregaDadosInterfaceConta(ref mdlComponentesGraficos.ListView lvAgencias, ref mdlComponentesGraficos.ListView lvContas);
			public delegate void delCallCarregaDadosInterfaceInformacoes(ref System.Windows.Forms.RichTextBox rtbInformacoes);
			//		public delegate void delCallCarregaDadosBancoInterface(ref mdlComponentesGraficos.ListView lvDadosBancos);
			//		public delegate void delCallChecaIntegridadeDados();
			public delegate void delCallSalvaDadosInterface(ref mdlComponentesGraficos.ListView lvBancos,ref mdlComponentesGraficos.ListView lvAgencias,ref mdlComponentesGraficos.ListView lvContas);
			public delegate void delCallSalvaDadosBD(bool bModificado);
			//		// Delegate para Editar / Cadastrar Bancos
			public delegate void delCallEditaBanco();
			public delegate void delCallCadastraBanco();
			public delegate void delCallRemoveBanco(ref mdlComponentesGraficos.ListView lvBancos);
			public delegate void delCallRemoveAgencia(ref mdlComponentesGraficos.ListView lvAgencias);
			public delegate void delCallRemoveConta(ref mdlComponentesGraficos.ListView lvContas);
		#endregion
		#region Events
			//		// Events BD
			public event delCallHabilitaBotaoAnularSelecao eCallHabilitaBotaoAnularSelecao;
			public event delCallCarregaDadosBD eCallCarregaDadosBD;
			public event delCallCarregaDadosBDBancos eCallCarregaDadosBDBancos;
			public event delCallCarregaDadosBDAgencias eCallCarregaDadosBDAgencias;
			public event delCallCarregaDadosBDContas eCallCarregaDadosBDContas;
			public event delCallCarregaDadosBancoSelecionado eCallCarregaDadosBancoSelecionado;
			public event delCallAnularSelecao eCallAnularSelecao;
			public event delCallCarregaDadosAgenciaSelecionada eCallCarregaDadosAgenciaSelecionada;
			public event delCallCarregaDadosContaSelecionada eCallCarregaDadosContaSelecionada;
			public event delCallCarregaDadosInterface eCallCarregaDadosInterface;
			public event delCallCarregaDadosInterfaceAgencia eCallCarregaDadosInterfaceAgencia;
			public event delCallCarregaDadosInterfaceConta eCallCarregaDadosInterfaceConta;
			public event delCallCarregaDadosInterfaceInformacoes eCallCarregaDadosInterfaceInformacoes;
			//		public event delCallCarregaDadosBancoInterface eCallCarregaDadosBancoInterface;
			//		public event delCallChecaIntegridadeDados eCallChecaIntegridadeDados;
			public event delCallSalvaDadosInterface eCallSalvaDadosInterface;
			public event delCallSalvaDadosBD eCallSalvaDadosBD;
			//		// Events Editar / Cadastrar Bancos
			public event delCallEditaBanco eCallEditaBanco;
			public event delCallCadastraBanco eCallCadastraBanco;
			public event delCallRemoveBanco eCallRemoveBanco;
			public event delCallRemoveAgencia eCallRemoveAgencia;
			public event delCallRemoveConta eCallRemoveConta;
		#endregion
		#region Events Methods
			protected virtual void OnCallHabilitaBotaoAnularSelecao()
			{
				if (eCallHabilitaBotaoAnularSelecao != null)
					eCallHabilitaBotaoAnularSelecao(ref m_btAnularSelecao);
			}

			protected virtual void OnCallCarregaDadosBD()
			{
				if (eCallCarregaDadosBD != null)
					eCallCarregaDadosBD();
			}

			protected virtual void OnCallCarregaDadosBDBancos()
			{
				if (eCallCarregaDadosBDBancos != null)
					eCallCarregaDadosBDBancos();
			}

			protected virtual void OnCallCarregaDadosBDAgencias()
			{
				if (eCallCarregaDadosBDAgencias != null)
					eCallCarregaDadosBDAgencias();
			}

			protected virtual void OnCallCarregaDadosBDContas()
			{
				if (eCallCarregaDadosBDContas != null)
					eCallCarregaDadosBDContas();
			}

			protected virtual void OnCallCarregaDadosBancoSelecionado()
			{
				if (eCallCarregaDadosBancoSelecionado != null)
					eCallCarregaDadosBancoSelecionado(ref this.m_lvBancos,ref this.m_lvAgencias,ref this.m_lvContas);
			}

			protected virtual void OnCallAnularSelecao()
			{
				if (eCallAnularSelecao != null)
					eCallAnularSelecao(ref this.m_lvBancos,ref this.m_lvAgencias,ref this.m_lvContas);
			}
	 
			protected virtual void OnCallCarregaDadosAgenciaSelecionada()
			{
				if (eCallCarregaDadosAgenciaSelecionada != null)
					eCallCarregaDadosAgenciaSelecionada(ref this.m_lvBancos, ref this.m_lvAgencias,ref this.m_lvContas);
			}
			protected virtual void OnCallCarregaDadosContaSelecionada()
			{
				if (eCallCarregaDadosContaSelecionada != null)
					eCallCarregaDadosContaSelecionada(ref this.m_lvContas);
			}
			protected virtual void OnCallCarregaDadosInterface()
			{
				if (eCallCarregaDadosInterface != null)
					eCallCarregaDadosInterface(ref this.m_lvBancos,ref this.m_lvAgencias,ref this.m_lvContas, ref this.m_rtbInformacoes, ref this.m_btEditar,ref this.m_btExcluir, ref this.m_btNovo);
			}

			protected virtual void OnCallCarregaDadosInterfaceAgencia()
			{
				if  (eCallCarregaDadosInterfaceAgencia != null)
					eCallCarregaDadosInterfaceAgencia(ref this.m_lvAgencias);
			}

			protected virtual void OnCallCarregaDadosInterfaceConta()
			{
				if (eCallCarregaDadosInterfaceConta != null)
					eCallCarregaDadosInterfaceConta(ref this.m_lvAgencias, ref this.m_lvContas);
			}
			protected virtual void OnCallCarregaDadosInterfaceInformacoes()
			{
				if (eCallCarregaDadosInterfaceInformacoes != null)
					eCallCarregaDadosInterfaceInformacoes(ref this.m_rtbInformacoes);
			}
			protected virtual void OnCallSalvaDadosInterface()
			{
				if (eCallSalvaDadosInterface != null)
					eCallSalvaDadosInterface(ref this.m_lvBancos,ref this.m_lvAgencias,ref this.m_lvContas);
			} 
			protected virtual void OnCallSalvaDadosBD()
			{
				if (eCallSalvaDadosBD != null)
					eCallSalvaDadosBD(this.m_bModificado);
			}
			protected virtual void OnCallCadastraBanco()
			{
				if (eCallCadastraBanco != null)
					eCallCadastraBanco();
			}
			protected virtual void OnCallEditaBanco()
			{
				if (eCallEditaBanco != null)
					eCallEditaBanco();
			}
			protected virtual void OnCallRemoveBanco()
			{
				if (eCallRemoveBanco != null)
					eCallRemoveBanco(ref this.m_lvBancos);
			}
			protected virtual void OnCallRemoveAgencia()
			{
				if (eCallRemoveAgencia != null)
					eCallRemoveAgencia(ref this.m_lvAgencias);
			}
			protected virtual void OnCallRemoveConta()
			{
				if (eCallRemoveConta != null)
					eCallRemoveConta(ref this.m_lvContas);
			}
		#endregion

		#region Atributos
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
		protected string m_strEnderecoExecutavel;

		public bool m_bModificado = false;

		private enum m_enum_ultimoClique { CONTA = 1, AGENCIA, BANCO };
		private m_enum_ultimoClique m_ultimoClique = m_enum_ultimoClique.CONTA;
		
		private System.Windows.Forms.GroupBox m_gbFrame;
		private System.Windows.Forms.GroupBox m_gbBancos;
		private System.Windows.Forms.GroupBox m_gbInformacoes;
		internal System.Windows.Forms.Button m_btOk;
		internal System.Windows.Forms.Button m_btCancelar;
		internal System.Windows.Forms.Button m_btTrocarCor;
		private mdlComponentesGraficos.ListView m_lvBancos;
		private System.Windows.Forms.Button m_btExcluir;
		private System.Windows.Forms.Button m_btEditar;
		private System.Windows.Forms.Button m_btNovo;
		private mdlComponentesGraficos.ListView m_lvAgencias;
		private mdlComponentesGraficos.ListView m_lvContas;
		private System.Windows.Forms.Label m_lAgencia;
		private System.Windows.Forms.Label m_lConta;
		private System.Windows.Forms.ToolTip m_ttBancoExportador;
		private System.Windows.Forms.ColumnHeader m_chBancos;
		private System.Windows.Forms.ColumnHeader m_chAgencias;
		private System.Windows.Forms.ColumnHeader m_chContas;
		private System.Windows.Forms.RichTextBox m_rtbInformacoes;
		private System.Windows.Forms.Button m_btAnularSelecao;
		private System.ComponentModel.IContainer components;
		#endregion
		#region Construtors and Destrutors
			public frmFBancoExportador(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, string EnderecoExecutavel)
			{
				InitializeComponent();
				m_cls_ter_tratadorErro = tratadorErro;
				m_strEnderecoExecutavel = EnderecoExecutavel;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFBancoExportador));
			this.m_gbFrame = new System.Windows.Forms.GroupBox();
			this.m_btTrocarCor = new System.Windows.Forms.Button();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbInformacoes = new System.Windows.Forms.GroupBox();
			this.m_rtbInformacoes = new System.Windows.Forms.RichTextBox();
			this.m_gbBancos = new System.Windows.Forms.GroupBox();
			this.m_lConta = new System.Windows.Forms.Label();
			this.m_lAgencia = new System.Windows.Forms.Label();
			this.m_lvContas = new mdlComponentesGraficos.ListView();
			this.m_chContas = new System.Windows.Forms.ColumnHeader();
			this.m_lvAgencias = new mdlComponentesGraficos.ListView();
			this.m_chAgencias = new System.Windows.Forms.ColumnHeader();
			this.m_btExcluir = new System.Windows.Forms.Button();
			this.m_btEditar = new System.Windows.Forms.Button();
			this.m_btNovo = new System.Windows.Forms.Button();
			this.m_lvBancos = new mdlComponentesGraficos.ListView();
			this.m_chBancos = new System.Windows.Forms.ColumnHeader();
			this.m_btAnularSelecao = new System.Windows.Forms.Button();
			this.m_ttBancoExportador = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbFrame.SuspendLayout();
			this.m_gbInformacoes.SuspendLayout();
			this.m_gbBancos.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbFrame
			// 
			this.m_gbFrame.Controls.Add(this.m_btTrocarCor);
			this.m_gbFrame.Controls.Add(this.m_btOk);
			this.m_gbFrame.Controls.Add(this.m_btCancelar);
			this.m_gbFrame.Controls.Add(this.m_gbInformacoes);
			this.m_gbFrame.Controls.Add(this.m_gbBancos);
			this.m_gbFrame.Location = new System.Drawing.Point(3, 0);
			this.m_gbFrame.Name = "m_gbFrame";
			this.m_gbFrame.Size = new System.Drawing.Size(634, 323);
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
			this.m_btTrocarCor.TabIndex = 10;
			this.m_ttBancoExportador.SetToolTip(this.m_btTrocarCor, "Cor");
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
			this.m_btOk.Location = new System.Drawing.Point(257, 292);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 4;
			this.m_ttBancoExportador.SetToolTip(this.m_btOk, "Confirmar");
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
			this.m_btCancelar.Location = new System.Drawing.Point(321, 292);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 5;
			this.m_ttBancoExportador.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbInformacoes
			// 
			this.m_gbInformacoes.Controls.Add(this.m_rtbInformacoes);
			this.m_gbInformacoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbInformacoes.Location = new System.Drawing.Point(302, 8);
			this.m_gbInformacoes.Name = "m_gbInformacoes";
			this.m_gbInformacoes.Size = new System.Drawing.Size(324, 279);
			this.m_gbInformacoes.TabIndex = 0;
			this.m_gbInformacoes.TabStop = false;
			// 
			// m_rtbInformacoes
			// 
			this.m_rtbInformacoes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_rtbInformacoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_rtbInformacoes.Location = new System.Drawing.Point(8, 15);
			this.m_rtbInformacoes.Name = "m_rtbInformacoes";
			this.m_rtbInformacoes.ReadOnly = true;
			this.m_rtbInformacoes.Size = new System.Drawing.Size(308, 256);
			this.m_rtbInformacoes.TabIndex = 9;
			this.m_rtbInformacoes.Text = "";
			// 
			// m_gbBancos
			// 
			this.m_gbBancos.Controls.Add(this.m_lConta);
			this.m_gbBancos.Controls.Add(this.m_lAgencia);
			this.m_gbBancos.Controls.Add(this.m_lvContas);
			this.m_gbBancos.Controls.Add(this.m_lvAgencias);
			this.m_gbBancos.Controls.Add(this.m_btExcluir);
			this.m_gbBancos.Controls.Add(this.m_btEditar);
			this.m_gbBancos.Controls.Add(this.m_btNovo);
			this.m_gbBancos.Controls.Add(this.m_lvBancos);
			this.m_gbBancos.Controls.Add(this.m_btAnularSelecao);
			this.m_gbBancos.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbBancos.Location = new System.Drawing.Point(8, 8);
			this.m_gbBancos.Name = "m_gbBancos";
			this.m_gbBancos.Size = new System.Drawing.Size(288, 279);
			this.m_gbBancos.TabIndex = 0;
			this.m_gbBancos.TabStop = false;
			this.m_gbBancos.Text = "Bancos";
			// 
			// m_lConta
			// 
			this.m_lConta.Location = new System.Drawing.Point(7, 200);
			this.m_lConta.Name = "m_lConta";
			this.m_lConta.Size = new System.Drawing.Size(61, 18);
			this.m_lConta.TabIndex = 0;
			this.m_lConta.Text = "Contas:";
			// 
			// m_lAgencia
			// 
			this.m_lAgencia.Location = new System.Drawing.Point(7, 122);
			this.m_lAgencia.Name = "m_lAgencia";
			this.m_lAgencia.Size = new System.Drawing.Size(76, 18);
			this.m_lAgencia.TabIndex = 0;
			this.m_lAgencia.Text = "Agências:";
			// 
			// m_lvContas
			// 
			this.m_lvContas.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.m_lvContas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						 this.m_chContas});
			this.m_lvContas.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lvContas.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lvContas.HideSelection = false;
			this.m_lvContas.Location = new System.Drawing.Point(7, 221);
			this.m_lvContas.Name = "m_lvContas";
			this.m_lvContas.Size = new System.Drawing.Size(273, 50);
			this.m_lvContas.TabIndex = 3;
			this.m_ttBancoExportador.SetToolTip(this.m_lvContas, "Selecionar conta");
			this.m_lvContas.View = System.Windows.Forms.View.Details;
			this.m_lvContas.DoubleClick += new System.EventHandler(this.m_lvContas_DoubleClick);
			this.m_lvContas.Click += new System.EventHandler(this.m_lvContas_Click);
			// 
			// m_chContas
			// 
			this.m_chContas.Width = 250;
			// 
			// m_lvAgencias
			// 
			this.m_lvAgencias.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.m_lvAgencias.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						   this.m_chAgencias});
			this.m_lvAgencias.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lvAgencias.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lvAgencias.HideSelection = false;
			this.m_lvAgencias.Location = new System.Drawing.Point(7, 143);
			this.m_lvAgencias.Name = "m_lvAgencias";
			this.m_lvAgencias.Size = new System.Drawing.Size(273, 50);
			this.m_lvAgencias.TabIndex = 2;
			this.m_ttBancoExportador.SetToolTip(this.m_lvAgencias, "Selecionar agência");
			this.m_lvAgencias.View = System.Windows.Forms.View.Details;
			this.m_lvAgencias.DoubleClick += new System.EventHandler(this.m_lvAgencias_DoubleClick);
			this.m_lvAgencias.Click += new System.EventHandler(this.m_lvAgencias_Click);
			this.m_lvAgencias.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_lvAgencias_MouseUp);
			// 
			// m_chAgencias
			// 
			this.m_chAgencias.Width = 250;
			// 
			// m_btExcluir
			// 
			this.m_btExcluir.BackColor = System.Drawing.SystemColors.Control;
			this.m_btExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btExcluir.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btExcluir.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btExcluir.Image = ((System.Drawing.Image)(resources.GetObject("m_btExcluir.Image")));
			this.m_btExcluir.Location = new System.Drawing.Point(148, 18);
			this.m_btExcluir.Name = "m_btExcluir";
			this.m_btExcluir.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btExcluir.Size = new System.Drawing.Size(25, 25);
			this.m_btExcluir.TabIndex = 8;
			this.m_btExcluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttBancoExportador.SetToolTip(this.m_btExcluir, "Excluir");
			this.m_btExcluir.Click += new System.EventHandler(this.m_btExcluir_Click);
			// 
			// m_btEditar
			// 
			this.m_btEditar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btEditar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btEditar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btEditar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btEditar.Image = ((System.Drawing.Image)(resources.GetObject("m_btEditar.Image")));
			this.m_btEditar.Location = new System.Drawing.Point(116, 18);
			this.m_btEditar.Name = "m_btEditar";
			this.m_btEditar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btEditar.Size = new System.Drawing.Size(25, 25);
			this.m_btEditar.TabIndex = 7;
			this.m_btEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttBancoExportador.SetToolTip(this.m_btEditar, "Editar");
			this.m_btEditar.Click += new System.EventHandler(this.m_btEditar_Click);
			// 
			// m_btNovo
			// 
			this.m_btNovo.BackColor = System.Drawing.SystemColors.Control;
			this.m_btNovo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btNovo.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btNovo.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btNovo.Image = ((System.Drawing.Image)(resources.GetObject("m_btNovo.Image")));
			this.m_btNovo.Location = new System.Drawing.Point(84, 18);
			this.m_btNovo.Name = "m_btNovo";
			this.m_btNovo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btNovo.Size = new System.Drawing.Size(25, 25);
			this.m_btNovo.TabIndex = 6;
			this.m_btNovo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttBancoExportador.SetToolTip(this.m_btNovo, "Novo");
			this.m_btNovo.Click += new System.EventHandler(this.m_btNovo_Click);
			// 
			// m_lvBancos
			// 
			this.m_lvBancos.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.m_lvBancos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						 this.m_chBancos});
			this.m_lvBancos.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lvBancos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lvBancos.HideSelection = false;
			this.m_lvBancos.Location = new System.Drawing.Point(7, 52);
			this.m_lvBancos.Name = "m_lvBancos";
			this.m_lvBancos.Size = new System.Drawing.Size(273, 63);
			this.m_lvBancos.TabIndex = 1;
			this.m_ttBancoExportador.SetToolTip(this.m_lvBancos, "Selecionar banco");
			this.m_lvBancos.View = System.Windows.Forms.View.Details;
			this.m_lvBancos.DoubleClick += new System.EventHandler(this.m_lvBancos_DoubleClick);
			this.m_lvBancos.Click += new System.EventHandler(this.m_lvBancos_Click);
			this.m_lvBancos.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_lvBancos_MouseUp);
			// 
			// m_chBancos
			// 
			this.m_chBancos.Width = 250;
			// 
			// m_btAnularSelecao
			// 
			this.m_btAnularSelecao.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.m_btAnularSelecao.BackColor = System.Drawing.SystemColors.Control;
			this.m_btAnularSelecao.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btAnularSelecao.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btAnularSelecao.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btAnularSelecao.Image = ((System.Drawing.Image)(resources.GetObject("m_btAnularSelecao.Image")));
			this.m_btAnularSelecao.Location = new System.Drawing.Point(180, 18);
			this.m_btAnularSelecao.Name = "m_btAnularSelecao";
			this.m_btAnularSelecao.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btAnularSelecao.Size = new System.Drawing.Size(25, 25);
			this.m_btAnularSelecao.TabIndex = 9;
			this.m_btAnularSelecao.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttBancoExportador.SetToolTip(this.m_btAnularSelecao, "Não incluir banco");
			this.m_btAnularSelecao.Click += new System.EventHandler(this.m_btAnularSelecao_Click);
			// 
			// m_ttBancoExportador
			// 
			this.m_ttBancoExportador.AutomaticDelay = 100;
			this.m_ttBancoExportador.AutoPopDelay = 5000;
			this.m_ttBancoExportador.InitialDelay = 100;
			this.m_ttBancoExportador.ReshowDelay = 20;
			// 
			// frmFBancoExportador
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(640, 326);
			this.Controls.Add(this.m_gbFrame);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFBancoExportador";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Banco do Exportador";
			this.Load += new System.EventHandler(this.frmFBancoExportador_Load);
			this.Activated += new System.EventHandler(this.frmFBancoExportador_Activated);
			this.m_gbFrame.ResumeLayout(false);
			this.m_gbInformacoes.ResumeLayout(false);
			this.m_gbBancos.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFBancoExportador_Load(object sender, System.EventArgs e)
				{
					try
					{
						this.mostraCor();
						OnCallHabilitaBotaoAnularSelecao();
						OnCallCarregaDadosInterface();
						ajustaBotoes();
						this.m_lvBancos.Focus();
					} 
					catch (Exception err)
					{
						Object erro = err;
						m_cls_ter_tratadorErro.trataErro(ref erro);
					}
				}
			#endregion
			#region Botoes
				private void m_btTrocarCor_Click(object sender, System.EventArgs e)
				{
					try
					{
						this.trocaCor();
						this.mostraCor();
					} 
					catch (Exception err)
					{
						Object erro = err;
						m_cls_ter_tratadorErro.trataErro(ref erro);
					}
				}
			#endregion
			#region ListView
				private void m_lvBancos_Click(object sender, System.EventArgs e)
				{
					m_ultimoClique = m_enum_ultimoClique.BANCO;
					OnCallCarregaDadosBancoSelecionado();
					OnCallCarregaDadosInterface();
				}

				private void m_lvBancos_DoubleClick(object sender, System.EventArgs e)
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

				private void m_lvBancos_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
				{
					m_ultimoClique = m_enum_ultimoClique.BANCO;
					System.Windows.Forms.ListViewItem lvItemBanco = m_lvBancos.GetItemAt(e.X, e.Y);
					if (lvItemBanco != null)
					{
						OnCallCarregaDadosBancoSelecionado();
						OnCallCarregaDadosInterface();
					}
					else
					{
						int nTotal = m_lvBancos.SelectedItems.Count;
						for(int nCount = 0; nCount < nTotal; nCount++)
						{
							lvItemBanco = m_lvBancos.SelectedItems[0];
							lvItemBanco.Selected = false;
						}
						OnCallCarregaDadosBancoSelecionado();
						OnCallCarregaDadosInterface();
					}
				}

				private void m_lvAgencias_Click(object sender, System.EventArgs e)
				{
					m_ultimoClique = m_enum_ultimoClique.AGENCIA;
					try
					{
						OnCallCarregaDadosAgenciaSelecionada();
						OnCallCarregaDadosInterfaceConta();
						OnCallCarregaDadosInterfaceInformacoes();
					} 
					catch (Exception err)
					{
						Object erro = err;
						m_cls_ter_tratadorErro.trataErro(ref erro);
					}
				}

				private void m_lvAgencias_DoubleClick(object sender, System.EventArgs e)
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

				private void m_lvAgencias_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
				{			
					m_ultimoClique = m_enum_ultimoClique.AGENCIA;
					System.Windows.Forms.ListViewItem lvItemAgencia = m_lvAgencias.GetItemAt(e.X, e.Y);
					if (lvItemAgencia != null)
					{
						OnCallCarregaDadosAgenciaSelecionada();
						OnCallCarregaDadosInterfaceConta();
						OnCallCarregaDadosInterfaceInformacoes();
					}
					else
					{
						int nTotal = m_lvAgencias.SelectedItems.Count;
						for(int nCount = 0; nCount < nTotal; nCount++)
						{
							lvItemAgencia = m_lvAgencias.SelectedItems[0];
							lvItemAgencia.Selected = false;
						}
						OnCallCarregaDadosAgenciaSelecionada();
						OnCallCarregaDadosInterfaceConta();
						OnCallCarregaDadosInterfaceInformacoes();
					}
				}

				private void m_lvContas_Click(object sender, System.EventArgs e)
				{
					m_ultimoClique = m_enum_ultimoClique.CONTA;
					try
					{
						OnCallCarregaDadosContaSelecionada();
						OnCallCarregaDadosInterfaceConta();
						OnCallCarregaDadosInterfaceInformacoes();
					} 
					catch (Exception err)
					{
						Object erro = err;
						m_cls_ter_tratadorErro.trataErro(ref erro);
					}
				}

				private void m_lvContas_DoubleClick(object sender, System.EventArgs e)
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
		#region Excluir
		private void m_btExcluir_Click(object sender, System.EventArgs e)
		{
			try
			{
				#region CONTA
				if ((m_ultimoClique == m_enum_ultimoClique.CONTA) && (m_lvBancos.SelectedItems.Count > 0))
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					OnCallRemoveConta();
					OnCallCarregaDadosInterfaceConta();
					OnCallCarregaDadosInterfaceInformacoes();
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}
				#endregion
				#region AGENCIA
				else if ((m_ultimoClique == m_enum_ultimoClique.AGENCIA) && (m_lvBancos.SelectedItems.Count > 0) && (m_lvAgencias.SelectedItems.Count > 0))
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					OnCallRemoveAgencia();
					OnCallCarregaDadosInterfaceAgencia();
					OnCallCarregaDadosInterfaceConta();
					OnCallCarregaDadosInterfaceInformacoes();
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}
				#endregion
				#region BANCO
				else if ((m_ultimoClique == m_enum_ultimoClique.BANCO) && (m_lvBancos.SelectedItems.Count > 0) && (m_lvAgencias.SelectedItems.Count > 0) && (m_lvContas.SelectedItems.Count > 0))
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					OnCallRemoveBanco();
					OnCallCarregaDadosBancoSelecionado();
					OnCallCarregaDadosInterface();
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}
				#endregion
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
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (this.m_lvBancos.SelectedItems.Count > 1)
				{
					mdlMensagens.clsMensagens.ShowInformation(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlBancos_frmFBancoExportador_SelecionarApenasUmBanco));
					//MessageBox.Show("Selecione apenas 1(UM) banco",this.Text);
					this.m_lvBancos.Focus();
				}
				else if (this.m_lvAgencias.SelectedItems.Count > 1)
				{
					mdlMensagens.clsMensagens.ShowInformation(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlBancos_frmFBancoExportador_SelecionarApenasUmaAgencia));
					//MessageBox.Show("Selecione apenas 1(UMA) agência",this.Text);
					this.m_lvAgencias.Focus();
				}
				else if (this.m_lvContas.SelectedItems.Count > 1)
				{
					mdlMensagens.clsMensagens.ShowInformation(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlBancos_frmFBancoExportador_SelecionarApenasUmaConta));
					//MessageBox.Show("Selecione apenas 1(UMA) conta",this.Text);
					this.m_lvContas.Focus();
				}
				else/* if ((this.m_lvContas.SelectedItems.Count == 1) && (this.m_lvAgencias.SelectedItems.Count == 1) && (this.m_lvBancos.SelectedItems.Count == 1))*/
				{
					this.m_bModificado = true;
					OnCallSalvaDadosInterface();
					OnCallSalvaDadosBD();
					this.Close();
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
		#region Cancelar
		private void m_btCancelar_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		#endregion
		#region Editar
		private void m_btEditar_Click(object sender, System.EventArgs e)
		{
			if (this.m_lvBancos.SelectedItems.Count > 0 &&
				this.m_lvAgencias.SelectedItems.Count > 0 &&
				this.m_lvContas.SelectedItems.Count > 0)
			{
				OnCallEditaBanco();
				OnCallCarregaDadosInterface();
			} 
			else
			{
				mdlMensagens.clsMensagens.ShowInformation(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlBancos_frmFBancoExportador_SelecionarTodosItensParaEdicao));
				//MessageBox.Show("Você precisa selecionar todos os itens(BANCO, AGÊNCIA, CONTA)",this.Text);
			}
		}
		#endregion
		#region Novo
		private void m_btNovo_Click(object sender, System.EventArgs e)
		{
			try 
			{
				OnCallCadastraBanco();
				OnCallCarregaDadosInterface();
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Activated
        private void frmFBancoExportador_Activated(object sender, System.EventArgs e)
		{
			m_lvBancos.Focus();
		}
		#endregion
		#region Anular Selecao
		private void m_btAnularSelecao_Click(object sender, System.EventArgs e)
		{
			m_ultimoClique = m_enum_ultimoClique.BANCO;
			OnCallAnularSelecao();
			OnCallCarregaDadosBancoSelecionado();
			OnCallCarregaDadosInterface();
		}
		#endregion
		#endregion

		#region Cores
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
									"mdlComponentesGraficos.ListView")/* &&
										(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
										"System.Windows.Forms.RichTextBox")*/)
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
		#region Ajusta Botoes
			private void ajustaBotoes()
			{
				try
				{
					if (m_btAnularSelecao.Visible == false)
					{
						m_btNovo.SetBounds(m_btNovo.Location.X + 16, m_btNovo.Location.Y, m_btNovo.Width, m_btNovo.Height);
						m_btEditar.SetBounds(m_btEditar.Location.X + 16, m_btEditar.Location.Y, m_btEditar.Width, m_btEditar.Height);
						m_btExcluir.SetBounds(m_btExcluir.Location.X + 16, m_btExcluir.Location.Y, m_btExcluir.Width, m_btExcluir.Height);
					}
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
		#endregion

	}
}
