using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlBiblioteca
{
	/// <summary>
	/// Summary description for frmFBiblioteca.
	/// </summary>
	internal class frmFBiblioteca : mdlComponentesGraficos.FormFixo
	{
		#region Delegate
		// Delegate para BD
		public delegate void delCallCarregaDadosBD();
		public delegate void delCallCarregaDadosBDPEs(ref mdlComponentesGraficos.ListView lvPEs, int nIndiceIcone);
		public delegate void delCallCarregaDadosInterface(ref mdlComponentesGraficos.ListView lvPEs, ref System.Windows.Forms.Button btEditar, ref System.Windows.Forms.Button btExcluir, ref System.Windows.Forms.Button btNovo,out int nIdView);
		public delegate void delCallOrdenaItens(ref mdlComponentesGraficos.ListView lvPEs);
		public delegate void delCallRefreshDadosInterfaceEdicao(ref mdlComponentesGraficos.ListView lvPEs);
		public delegate void delCallChecaIntegridadeDados();
		public delegate void delCallSalvaDadosInterface(ref mdlComponentesGraficos.ListView lvPEs);
		public delegate void delCallSalvaDadosInterfaceView(int nIdView);
		public delegate void delCallSalvaDadosBD(bool bModificado);
		// Delegate para Editar Contas
		public delegate bool delCallShowEditaProcessoExportacao(string strIdPe);
		public delegate void delCallCadastraPE();
		public delegate bool delCallRemovePE(ref mdlComponentesGraficos.ListView lvPEs);
		public delegate void delCallDuploClique();
		// Delegate para seta como PE Concluído
		public delegate void delCallSetaConcluido(ref mdlComponentesGraficos.ListView lvPEs, bool bConcluido);
		// Delegate para o Banner
		public delegate void delCallAlteraBanner(ref System.Windows.Forms.PictureBox pbBanner);
		public delegate void delCallClickBanner();
		#endregion
		#region Events
		// Eventos BD
		public event delCallCarregaDadosBD eCallCarregaDadosBD;
		public event delCallCarregaDadosBDPEs eCallCarregaDadosBDPEs;
		public event delCallCarregaDadosInterface eCallCarregaDadosInterface;
		public event delCallOrdenaItens eCallOrdenaItens;
		public event delCallRefreshDadosInterfaceEdicao eCallRefreshDadosInterfaceEdicao;
		public event delCallChecaIntegridadeDados eCallChecaIntegridadeDados;
		public event delCallSalvaDadosInterface eCallSalvaDadosInterface;
		public event delCallSalvaDadosInterfaceView eCallSalvaDadosInterfaceView;
		public event delCallSalvaDadosBD eCallSalvaDadosBD;
		// Eventos Editar / Cadastrar Importadores
		public event delCallShowEditaProcessoExportacao eCallShowEditaProcessoExportacao;
		public event delCallCadastraPE eCallCadastraPE;
		public event delCallRemovePE eCallRemovePE;
		public event delCallDuploClique eCallDuploClique;
		// Delegate para seta como PE Concluído
		public event delCallSetaConcluido eCallSetaConcluido;
		// Eventos Alterar Banner
		public event delCallAlteraBanner eCallAlteraBanner;
		public event delCallClickBanner eCallClickBanner;
		#endregion
		#region Events Methods
		protected virtual void OnCallCarregaDadosBD()
		{
			if (eCallCarregaDadosBD != null)
				eCallCarregaDadosBD();
		}
		protected virtual void OnCallCarregaDadosBDPEs()
		{
			if (eCallCarregaDadosBDPEs != null && this.m_lvPEs.SelectedItems.Count > 0)
				eCallCarregaDadosBDPEs(ref this.m_lvPEs, this.m_lvPEs.SelectedItems[0].ImageIndex);
		} 
		protected virtual void OnCallCarregaDadosInterface()
		{
			if (eCallCarregaDadosInterface != null)
			{
				int nIdView = 0;
				eCallCarregaDadosInterface(ref this.m_lvPEs, ref this.m_btEditar, ref this.m_btExcluir, ref m_btNovo,out nIdView);
				m_cbTipoView.SelectedIndex = nIdView;
			}
		}
		protected virtual void OnCallOrdenaItens()
		{
			if (eCallOrdenaItens != null)
				eCallOrdenaItens(ref m_lvPEs);
		}
		protected virtual void OnCallRefreshDadosInterfaceEdicao()
		{
			if (eCallRefreshDadosInterfaceEdicao != null)
				eCallRefreshDadosInterfaceEdicao(ref m_lvPEs);
		}
		protected virtual void OnCallChecaIntegridadeDados()
		{
			if (eCallChecaIntegridadeDados != null)
				eCallChecaIntegridadeDados();
		}
		protected virtual void OnCallSalvaDadosInterface()
		{
			if (eCallSalvaDadosInterface != null)
				eCallSalvaDadosInterface(ref this.m_lvPEs);
		} 

		protected virtual void OnCallSalvaDadosInterfaceView()
		{
			if (eCallSalvaDadosInterfaceView != null)
				eCallSalvaDadosInterfaceView(m_cbTipoView.SelectedIndex);
		} 

		protected virtual void OnCallSalvaDadosBD()
		{
			if (eCallSalvaDadosBD != null)
				eCallSalvaDadosBD(this.m_bModificado);
		}
		protected virtual void OnCallCadastraPE()
		{
			if (eCallCadastraPE != null)
				eCallCadastraPE();
		}
		protected virtual bool OnCallShowEditaProcessoExportacao()
		{
			bool bRetorno = false;
			if ((eCallShowEditaProcessoExportacao != null) && (m_lvPEs.SelectedItems.Count > 0))
				bRetorno = eCallShowEditaProcessoExportacao(m_lvPEs.SelectedItems[0].Text);
			return(bRetorno);
		}
		protected virtual bool OnCallRemovePE()
		{
			if (eCallRemovePE != null)
				if (eCallRemovePE(ref this.m_lvPEs))
					return true;
			return false;
		}
		protected virtual void OnCallDuploClique()
		{
			if (eCallDuploClique != null)
				eCallDuploClique();
		}
		protected virtual void OnCallSetaConcluido(bool bConcluido)
		{
			if (eCallSetaConcluido != null)
				eCallSetaConcluido(ref m_lvPEs, bConcluido);
		}
		protected virtual void OnCallAlteraBanner()
		{
//			if (eCallAlteraBanner != null)
//				eCallAlteraBanner(ref this.m_pbBanner);
		}
		protected virtual void OnCallClickBanner()
		{
			if (eCallClickBanner != null)
				eCallClickBanner();
		}
		#endregion

		#region Atributos
		private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
		private string m_strEnderecoExecutavel = "";

		//private System.Windows.Forms.SortOrder m_enumSort = System.Windows.Forms.SortOrder.Ascending;
		internal int m_nIdColunaSelecionada = 0;

		private bool m_bModificado = true;
		private System.Windows.Forms.ToolTip m_ttBiblioteca;
		private System.Windows.Forms.Timer m_tmBiblioteca;
		private System.Windows.Forms.ImageList m_ilBibliotecaGrandes;
		private System.Windows.Forms.ImageList m_ilBibliotecaPequenos;
		private System.Windows.Forms.GroupBox groupBox1;
		private mdlComponentesGraficos.AnimatedPictureBox m_pbBanner;
		private mdlComponentesGraficos.ComboBox m_cbTipoView;
		private System.Windows.Forms.Button m_btTrocarCor;
		private System.Windows.Forms.Button m_btExcluir;
		private System.Windows.Forms.Button m_btEditar;
		private System.Windows.Forms.Button m_btNovo;
		private mdlComponentesGraficos.ListView m_lvPEs;
		private System.Windows.Forms.ColumnHeader m_chPES;
		private System.Windows.Forms.ColumnHeader m_chDataCriacao;
		private System.Windows.Forms.ColumnHeader m_chDataConclusao;
		private System.Windows.Forms.ColumnHeader m_chNomeImportador;
		private System.Windows.Forms.ColumnHeader m_chNumeroFaturaComercial;
		private System.Windows.Forms.ContextMenu m_cnmnPEConcluido;
		private System.Windows.Forms.MenuItem m_mnitPEConcluido;
		private System.Windows.Forms.ColumnHeader m_colhValorFatura;
		private System.ComponentModel.IContainer components = null;
		#endregion
		#region Properties
			public string PE
			{
				set
				{
					m_lvPEs.SelectedItems.Clear();
					foreach(System.Windows.Forms.ListViewItem lviItem in m_lvPEs.Items)
					{
						if (lviItem.Text == value)
						{
							lviItem.Selected = true;
							break;
						}
					}
				}
			}
		#endregion
		#region Construtors and Destrutores
		public frmFBiblioteca(ref mdlTratamentoErro.clsTratamentoErro clstratadorErro, string strEnderecoExecutavel)
		{
			InitializeComponent();
			m_cls_ter_tratadorErro = clstratadorErro;
			m_strEnderecoExecutavel = strEnderecoExecutavel;
			vInitializeBanners();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			try
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
			catch
			{
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFBiblioteca));
			this.m_ilBibliotecaGrandes = new System.Windows.Forms.ImageList(this.components);
			this.m_ilBibliotecaPequenos = new System.Windows.Forms.ImageList(this.components);
			this.m_ttBiblioteca = new System.Windows.Forms.ToolTip(this.components);
			this.m_cbTipoView = new mdlComponentesGraficos.ComboBox();
			this.m_btTrocarCor = new System.Windows.Forms.Button();
			this.m_btExcluir = new System.Windows.Forms.Button();
			this.m_btEditar = new System.Windows.Forms.Button();
			this.m_btNovo = new System.Windows.Forms.Button();
			this.m_tmBiblioteca = new System.Windows.Forms.Timer(this.components);
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.m_pbBanner = new mdlComponentesGraficos.AnimatedPictureBox();
			this.m_lvPEs = new mdlComponentesGraficos.ListView();
			this.m_chPES = new System.Windows.Forms.ColumnHeader();
			this.m_chDataCriacao = new System.Windows.Forms.ColumnHeader();
			this.m_chDataConclusao = new System.Windows.Forms.ColumnHeader();
			this.m_chNomeImportador = new System.Windows.Forms.ColumnHeader();
			this.m_chNumeroFaturaComercial = new System.Windows.Forms.ColumnHeader();
			this.m_colhValorFatura = new System.Windows.Forms.ColumnHeader();
			this.m_cnmnPEConcluido = new System.Windows.Forms.ContextMenu();
			this.m_mnitPEConcluido = new System.Windows.Forms.MenuItem();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_ilBibliotecaGrandes
			// 
			this.m_ilBibliotecaGrandes.ImageSize = new System.Drawing.Size(32, 32);
			this.m_ilBibliotecaGrandes.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_ilBibliotecaGrandes.ImageStream")));
			this.m_ilBibliotecaGrandes.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// m_ilBibliotecaPequenos
			// 
			this.m_ilBibliotecaPequenos.ImageSize = new System.Drawing.Size(16, 16);
			this.m_ilBibliotecaPequenos.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_ilBibliotecaPequenos.ImageStream")));
			this.m_ilBibliotecaPequenos.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// m_ttBiblioteca
			// 
			this.m_ttBiblioteca.AutomaticDelay = 100;
			this.m_ttBiblioteca.AutoPopDelay = 5000;
			this.m_ttBiblioteca.InitialDelay = 100;
			this.m_ttBiblioteca.ReshowDelay = 20;
			// 
			// m_cbTipoView
			// 
			this.m_cbTipoView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_cbTipoView.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_cbTipoView.Items.AddRange(new object[] {
															  "Ícones Grandes",
															  "Detalhes",
															  "Ícones Pequenos",
															  "Lista"});
			this.m_cbTipoView.Location = new System.Drawing.Point(777, 27);
			this.m_cbTipoView.Name = "m_cbTipoView";
			this.m_cbTipoView.Size = new System.Drawing.Size(164, 22);
			this.m_cbTipoView.TabIndex = 21;
			this.m_ttBiblioteca.SetToolTip(this.m_cbTipoView, "Tipos de visualização");
			this.m_cbTipoView.TextChanged += new System.EventHandler(this.m_cbTipoView_TextChanged);
			// 
			// m_btTrocarCor
			// 
			this.m_btTrocarCor.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_btTrocarCor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btTrocarCor.Location = new System.Drawing.Point(3, 12);
			this.m_btTrocarCor.Name = "m_btTrocarCor";
			this.m_btTrocarCor.Size = new System.Drawing.Size(4, 4);
			this.m_btTrocarCor.TabIndex = 20;
			this.m_ttBiblioteca.SetToolTip(this.m_btTrocarCor, "Cor");
			this.m_btTrocarCor.Click += new System.EventHandler(this.m_btTrocarCor_Click);
			// 
			// m_btExcluir
			// 
			this.m_btExcluir.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.m_btExcluir.BackColor = System.Drawing.SystemColors.Control;
			this.m_btExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btExcluir.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btExcluir.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btExcluir.Image = ((System.Drawing.Image)(resources.GetObject("m_btExcluir.Image")));
			this.m_btExcluir.Location = new System.Drawing.Point(494, 16);
			this.m_btExcluir.Name = "m_btExcluir";
			this.m_btExcluir.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btExcluir.Size = new System.Drawing.Size(25, 25);
			this.m_btExcluir.TabIndex = 18;
			this.m_btExcluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttBiblioteca.SetToolTip(this.m_btExcluir, "Excluir");
			this.m_btExcluir.Click += new System.EventHandler(this.m_btExcluir_Click);
			// 
			// m_btEditar
			// 
			this.m_btEditar.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.m_btEditar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btEditar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btEditar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btEditar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btEditar.Image = ((System.Drawing.Image)(resources.GetObject("m_btEditar.Image")));
			this.m_btEditar.Location = new System.Drawing.Point(462, 16);
			this.m_btEditar.Name = "m_btEditar";
			this.m_btEditar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btEditar.Size = new System.Drawing.Size(25, 25);
			this.m_btEditar.TabIndex = 17;
			this.m_btEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttBiblioteca.SetToolTip(this.m_btEditar, "Editar");
			this.m_btEditar.Click += new System.EventHandler(this.m_btEditar_Click);
			// 
			// m_btNovo
			// 
			this.m_btNovo.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.m_btNovo.BackColor = System.Drawing.SystemColors.Control;
			this.m_btNovo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btNovo.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btNovo.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btNovo.Image = ((System.Drawing.Image)(resources.GetObject("m_btNovo.Image")));
			this.m_btNovo.Location = new System.Drawing.Point(430, 16);
			this.m_btNovo.Name = "m_btNovo";
			this.m_btNovo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btNovo.Size = new System.Drawing.Size(25, 25);
			this.m_btNovo.TabIndex = 16;
			this.m_btNovo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttBiblioteca.SetToolTip(this.m_btNovo, "Novo");
			this.m_btNovo.Click += new System.EventHandler(this.m_btNovo_Click);
			// 
			// m_tmBiblioteca
			// 
			this.m_tmBiblioteca.Enabled = true;
			this.m_tmBiblioteca.Interval = 2000;
			this.m_tmBiblioteca.Tick += new System.EventHandler(this.m_tmBiblioteca_Tick);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.m_pbBanner);
			this.groupBox1.Controls.Add(this.m_cbTipoView);
			this.groupBox1.Controls.Add(this.m_btTrocarCor);
			this.groupBox1.Controls.Add(this.m_btExcluir);
			this.groupBox1.Controls.Add(this.m_btEditar);
			this.groupBox1.Controls.Add(this.m_btNovo);
			this.groupBox1.Controls.Add(this.m_lvPEs);
			this.groupBox1.Font = new System.Drawing.Font("Arial", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(73, -1);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(949, 567);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Biblioteca de Processos de Exportação";
			// 
			// m_pbBanner
			// 
			this.m_pbBanner.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.m_pbBanner.AnimationLoops = 1;
			this.m_pbBanner.Image = ((System.Drawing.Image)(resources.GetObject("m_pbBanner.Image")));
			this.m_pbBanner.Location = new System.Drawing.Point(191, 488);
			this.m_pbBanner.Name = "m_pbBanner";
			this.m_pbBanner.Size = new System.Drawing.Size(567, 70);
			this.m_pbBanner.TabIndex = 19;
			this.m_pbBanner.TabStop = false;
			this.m_pbBanner.Click += new System.EventHandler(this.m_pbBanner_Click);
			this.m_pbBanner.MouseEnter += new System.EventHandler(this.m_pbBanner_MouseEnter);
			this.m_pbBanner.MouseLeave += new System.EventHandler(this.m_pbBanner_MouseLeave);
			// 
			// m_lvPEs
			// 
			this.m_lvPEs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lvPEs.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_lvPEs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																					  this.m_chPES,
																					  this.m_chDataCriacao,
																					  this.m_chDataConclusao,
																					  this.m_chNomeImportador,
																					  this.m_chNumeroFaturaComercial,
																					  this.m_colhValorFatura});
			this.m_lvPEs.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lvPEs.FullRowSelect = true;
			this.m_lvPEs.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.m_lvPEs.HideSelection = false;
			this.m_lvPEs.LargeImageList = this.m_ilBibliotecaGrandes;
			this.m_lvPEs.Location = new System.Drawing.Point(8, 54);
			this.m_lvPEs.Name = "m_lvPEs";
			this.m_lvPEs.Size = new System.Drawing.Size(933, 426);
			this.m_lvPEs.SmallImageList = this.m_ilBibliotecaPequenos;
			this.m_lvPEs.StateImageList = this.m_ilBibliotecaPequenos;
			this.m_lvPEs.TabIndex = 15;
			this.m_lvPEs.ItemActivate += new System.EventHandler(this.m_lvPEs_ItemActivate);
			this.m_lvPEs.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.m_lvPEs_ColumnClick);
			this.m_lvPEs.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_lvPEs_MouseUp);
			this.m_lvPEs.KeyUp += new System.Windows.Forms.KeyEventHandler(this.m_lvPEs_KeyUp);
			// 
			// m_chPES
			// 
			this.m_chPES.Text = "PE";
			this.m_chPES.Width = 100;
			// 
			// m_chDataCriacao
			// 
			this.m_chDataCriacao.Text = "Criação";
			this.m_chDataCriacao.Width = 90;
			// 
			// m_chDataConclusao
			// 
			this.m_chDataConclusao.Text = "Conclusão";
			this.m_chDataConclusao.Width = 90;
			// 
			// m_chNomeImportador
			// 
			this.m_chNomeImportador.Text = "Importador";
			this.m_chNomeImportador.Width = 220;
			// 
			// m_chNumeroFaturaComercial
			// 
			this.m_chNumeroFaturaComercial.Text = "Fatura Comercial";
			this.m_chNumeroFaturaComercial.Width = 212;
			// 
			// m_colhValorFatura
			// 
			this.m_colhValorFatura.Text = "Valor da Fatura";
			this.m_colhValorFatura.Width = 100;
			// 
			// m_cnmnPEConcluido
			// 
			this.m_cnmnPEConcluido.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							  this.m_mnitPEConcluido});
			// 
			// m_mnitPEConcluido
			// 
			this.m_mnitPEConcluido.Index = 0;
			this.m_mnitPEConcluido.Text = "PE Concluído";
			this.m_mnitPEConcluido.Click += new System.EventHandler(this.m_mnitPEConcluido_Click);
			// 
			// frmFBiblioteca
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(1024, 568);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmFBiblioteca";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Load += new System.EventHandler(this.frmFBiblioteca_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Procedimentos Para Troca de Cor
		#region Trocar Cor
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
		#endregion
		#region Mostrar Cor
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
					if ((this.Controls[cont].GetType().ToString() != 
						"mdlComponentesGraficos.ListView") &&
						(this.Controls[cont].GetType().ToString() != 
						"mdlComponentesGraficos.ComboBox") &&
						(this.Controls[cont].GetType().ToString() != 
						"mdlComponentesGraficos.TextBox"))
					{
						this.Controls[cont].BackColor = this.BackColor;
					}
					for (int cont2 = 0; cont2 < this.Controls[cont].Controls.Count; cont2++)
					{
						if ((this.Controls[cont].Controls[cont2].GetType().ToString() != 
								"mdlComponentesGraficos.ListView") &&
								(this.Controls[cont].Controls[cont2].GetType().ToString() != 
								"mdlComponentesGraficos.ComboBox") &&
								(this.Controls[cont].Controls[cont2].GetType().ToString() != 
								"mdlComponentesGraficos.TextBox"))
							{
								this.Controls[cont].Controls[cont2].BackColor = this.BackColor;
							}
						for (int cont3 = 0; cont3 < this.Controls[cont].Controls[cont2].Controls.Count; cont3++)
						{
							if ((this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.ListView") &&
								(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
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
		#endregion

		#region selecionaItemDaComboBox
		private void selecionaItemDaComboBox()
		{
			if (this.m_lvPEs.View == System.Windows.Forms.View.LargeIcon)
					this.m_cbTipoView.SelectedIndex = 0;
			else if (this.m_lvPEs.View == System.Windows.Forms.View.Details)
				this.m_cbTipoView.SelectedIndex = 1;
			else if (this.m_lvPEs.View == System.Windows.Forms.View.SmallIcon)
				this.m_cbTipoView.SelectedIndex = 2;
			else if (this.m_lvPEs.View == System.Windows.Forms.View.List)
				this.m_cbTipoView.SelectedIndex = 3;
		}
		#endregion

		#region Refresh
		public void refreshAll()
		{
			try
			{
				OnCallCarregaDadosInterface();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Get & Set
		public void setToolTipBanner(string strToolTip)
		{
			try
			{
				m_ttBiblioteca.SetToolTip(m_pbBanner, strToolTip);
			}
			catch (Exception err)
			{
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion

		#region Eventos
		#region Key Up
		private void m_lvPEs_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyData == System.Windows.Forms.Keys.Delete)
				{
					m_btExcluir_Click(sender, new System.EventArgs());
				}
				else if (e.KeyData == System.Windows.Forms.Keys.F2)
				{
					m_btEditar_Click(sender, new System.EventArgs());
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Load
		private void frmFBiblioteca_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.mostraCor();
				OnCallAlteraBanner();
				OnCallCarregaDadosInterface();
				OnCallOrdenaItens();
				this.SetBounds(this.MdiParent.Bounds.X,this.MdiParent.Bounds.Y,this.MdiParent.Bounds.Width - 13,this.MdiParent.Bounds.Height - 40);
				selecionaItemDaComboBox();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
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
		#region Tick
		private void m_tmBiblioteca_Tick(object sender, System.EventArgs e)
		{
			try
			{
				m_pbBanner.Enabled = false;
				if (m_pbBanner.SetAnimationLoopsFromImage())
				{
					m_pbBanner.AnimationLoops = 2;
					m_pbBanner.Start();
				}
				//OnCallAlteraBanner();
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
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				this.Refresh();
				if (OnCallRemovePE())
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					this.Refresh();
					OnCallCarregaDadosInterface();
					OnCallOrdenaItens();
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					this.Refresh();
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
		#region Novo
		private void m_btNovo_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				OnCallCadastraPE();
				OnCallCarregaDadosInterface();
				OnCallOrdenaItens();
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Editar
		private void m_btEditar_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (m_lvPEs.SelectedItems.Count > 0)
				{
					OnCallCarregaDadosBDPEs();
					if (OnCallShowEditaProcessoExportacao())
					{
						OnCallCarregaDadosInterface();
					}
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
		#region Closing
		private void frmFBiblioteca_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{
				//this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				//OnCallSalvaDadosInterface();
				//OnCallSalvaDadosBD();
				//this.Cursor = System.Windows.Forms.Cursors.Default;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Banner Mouse Enter
		private void m_pbBanner_MouseEnter(object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor = System.Windows.Forms.Cursors.Hand;
				if ((m_tmBiblioteca != null) && (m_tmBiblioteca.Enabled))
					this.m_tmBiblioteca.Stop();
				//this.m_tmBiblioteca.Enabled = false;
			}
			catch
			{
			}
		}
		#endregion
		#region Banner Mouse Leave
		private void m_pbBanner_MouseLeave(object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor = System.Windows.Forms.Cursors.Default;
				if (m_tmBiblioteca != null)
					this.m_tmBiblioteca.Start();
				//this.m_tmBiblioteca.Enabled = true;
			}
			catch
			{
			}
		}
		#endregion
		#region Tipo View
		private void m_cbTipoView_TextChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (this.m_cbTipoView.SelectedIndex == 0)
					m_lvPEs.View = System.Windows.Forms.View.LargeIcon;
				else if (this.m_cbTipoView.SelectedIndex == 1)
					m_lvPEs.View = System.Windows.Forms.View.Details;
				else if (this.m_cbTipoView.SelectedIndex == 2)
					m_lvPEs.View = System.Windows.Forms.View.SmallIcon;
				else if (this.m_cbTipoView.SelectedIndex == 3)
					m_lvPEs.View = System.Windows.Forms.View.List;
				OnCallSalvaDadosInterfaceView();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Duplo Clique
		private void m_lvPEs_ItemActivate(object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (m_lvPEs.SelectedItems.Count > 0)
				{
					OnCallCarregaDadosBDPEs();
					OnCallDuploClique();
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
		#region Mouse Up
		private void m_lvPEs_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			try
			{
				System.Windows.Forms.ListViewItem lvItemSelecionado = m_lvPEs.GetItemAt(e.X, e.Y);
				if ((lvItemSelecionado != null) && (e.Button == System.Windows.Forms.MouseButtons.Right))
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					bool bConcluido = false;
					int nQdeConcluidos = 0;
					foreach(System.Windows.Forms.ListViewItem lvItemPEs in m_lvPEs.SelectedItems)
					{
						if (lvItemPEs.ImageIndex == 0)
							nQdeConcluidos++;
					}
					if (nQdeConcluidos > (int)(m_lvPEs.SelectedItems.Count / 2))
						bConcluido = true;
					m_mnitPEConcluido.Checked = bConcluido;
					m_cnmnPEConcluido.Show(m_lvPEs, new System.Drawing.Point(e.X,e.Y));
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region PE Concluído
		private void m_mnitPEConcluido_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				OnCallSetaConcluido(!m_mnitPEConcluido.Checked);
				OnCallCarregaDadosInterface();
				if (m_lvPEs.SelectedItems.Count > 0)
					OnCallCarregaDadosBDPEs();
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Banner Click
		private void m_pbBanner_Click(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			OnCallClickBanner();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}
		#endregion
		#region Column Click
		private void m_lvPEs_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
			try
			{
				if (m_lvPEs.Sorting == System.Windows.Forms.SortOrder.Ascending)
					m_lvPEs.Sorting = System.Windows.Forms.SortOrder.Descending;
				else
					m_lvPEs.Sorting = System.Windows.Forms.SortOrder.Ascending;
			}catch (System.Exception eExcp){
				m_cls_ter_tratadorErro.trataErro(ref eExcp);
			}
		}
		#endregion
		#endregion

		#region Banners
			private void vInitializeBanners()
			{
				mdlManipuladorArquivo.clsManipuladorArquivoIni objIni = new mdlManipuladorArquivo.clsManipuladorArquivoIni(m_strEnderecoExecutavel + mdlConstantes.clsConstantes.DEFAULT_CONFIG_FILENAME);
				if (!objIni.retornaValor("Siscobras","Banners",true))
				{
					m_tmBiblioteca.Enabled = false;
					m_pbBanner.Visible = false;
					m_lvPEs.Height = (groupBox1.Height - m_lvPEs.Top) - 10;
				}
			}
		#endregion
	}
}

