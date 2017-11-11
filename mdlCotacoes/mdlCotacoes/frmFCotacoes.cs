using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlCotacoes
{
	/// <summary>
	/// Summary description for frmFCotacoes.
	/// </summary>
	internal class frmFCotacoes : mdlComponentesGraficos.FormFixo
	{
		#region Atributos
		private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
		protected string m_strEnderecoExecutavel = "";

		internal int m_nIdColunaSelecionada = 0;
		
		private bool m_bModificado = true;
		private System.Windows.Forms.ToolTip m_ttCotacao;
		private System.Windows.Forms.GroupBox m_gbFrame;
		private System.Windows.Forms.Button m_btTrocarCor;
		private mdlComponentesGraficos.ListView m_lvCotacoes;
		private System.Windows.Forms.ColumnHeader m_chFirst;
		private System.Windows.Forms.ColumnHeader m_chSecond;
		private System.Windows.Forms.Button m_btExcluir;
		private System.Windows.Forms.Button m_btEditar;
		private System.Windows.Forms.Button m_btNovo;
		private mdlComponentesGraficos.ComboBox m_cbTipoView;
		private System.Windows.Forms.ImageList m_ilCotacaoGrandes;
		private System.Windows.Forms.ImageList m_ilCotacaoPequenos;
		private System.ComponentModel.IContainer components;
		#endregion

		#region Construtores & Destrutores
		public frmFCotacoes(ref mdlTratamentoErro.clsTratamentoErro clstratadorErro, string strEnderecoExecutavel)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_cls_ter_tratadorErro = clstratadorErro;
			m_strEnderecoExecutavel = strEnderecoExecutavel;
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
		public delegate void delCallCarregaDadosBDCotacoes(ref mdlComponentesGraficos.ListView lvCotacoes);
		public delegate void delCallCarregaDadosInterface(ref mdlComponentesGraficos.ListView lvCotacoes, ref System.Windows.Forms.Button btEditar, ref System.Windows.Forms.Button btExcluir, ref System.Windows.Forms.Button btNovo);
		public delegate void delCallOrdenaItens(ref mdlComponentesGraficos.ListView lvCotacoes);
		public delegate void delCallChecaIntegridadeDados();
		public delegate void delCallSalvaDadosInterface(ref mdlComponentesGraficos.ListView lvCotacoes);
		public delegate void delCallSalvaDadosBD(bool bModificado);
		// Delegate para Editar Cotações
		public delegate void delCallEditaCotacao();
		public delegate void delCallCadastraCotacao();
		public delegate bool delCallRemoveCotacao(ref mdlComponentesGraficos.ListView lvCotacoes);
		public delegate void delCallDuploClique();
		#endregion
		#region Events
		// Eventos BD
		public event delCallCarregaDadosBD eCallCarregaDadosBD;
		public event delCallCarregaDadosBDCotacoes eCallCarregaDadosBDCotacoes;
		public event delCallCarregaDadosInterface eCallCarregaDadosInterface;
		public event delCallOrdenaItens eCallOrdenaItens;
		public event delCallChecaIntegridadeDados eCallChecaIntegridadeDados;
		public event delCallSalvaDadosInterface eCallSalvaDadosInterface;
		public event delCallSalvaDadosBD eCallSalvaDadosBD;
		// Eventos Editar / Cadastrar Cotações
		public event delCallEditaCotacao eCallEditaCotacao;
		public event delCallCadastraCotacao eCallCadastraCotacao;
		public event delCallRemoveCotacao eCallRemoveCotacao;
		public event delCallDuploClique eCallDuploClique;
		#endregion
		#region Events Methods
		protected virtual void OnCallCarregaDadosBD()
		{
			if (eCallCarregaDadosBD != null)
				eCallCarregaDadosBD();
		}
		protected virtual void OnCallCarregaDadosBDCotacoes()
		{
			if (eCallCarregaDadosBDCotacoes != null)
				eCallCarregaDadosBDCotacoes(ref this.m_lvCotacoes);
		} 
		protected virtual void OnCallCarregaDadosInterface()
		{
			if (eCallCarregaDadosInterface != null)
				eCallCarregaDadosInterface(ref this.m_lvCotacoes, ref this.m_btEditar, ref this.m_btExcluir, ref m_btNovo);
		}
		protected virtual void OnCallOrdenaItens()
		{
			if (eCallOrdenaItens != null)
				eCallOrdenaItens(ref m_lvCotacoes);
		}
		protected virtual void OnCallChecaIntegridadeDados()
		{
			if (eCallChecaIntegridadeDados != null)
				eCallChecaIntegridadeDados();
		}
		protected virtual void OnCallSalvaDadosInterface()
		{
			if (eCallSalvaDadosInterface != null)
				eCallSalvaDadosInterface(ref this.m_lvCotacoes);
		} 

		protected virtual void OnCallSalvaDadosBD()
		{
			if (eCallSalvaDadosBD != null)
				eCallSalvaDadosBD(this.m_bModificado);
		}
		protected virtual void OnCallCadastraCotacao()
		{
			if (eCallCadastraCotacao != null)
				eCallCadastraCotacao();
		}
		protected virtual void OnCallEditaCotacao()
		{
			if (eCallEditaCotacao != null)
				eCallEditaCotacao();
		}
		protected virtual bool OnCallRemoveCotacao()
		{
			if (eCallRemoveCotacao != null)
				if (eCallRemoveCotacao(ref this.m_lvCotacoes))
					return true;
			return false;
		}
		protected virtual void OnCallDuploClique()
		{
			if (eCallDuploClique != null)
				eCallDuploClique();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFCotacoes));
			this.m_ttCotacao = new System.Windows.Forms.ToolTip(this.components);
			this.m_btTrocarCor = new System.Windows.Forms.Button();
			this.m_btExcluir = new System.Windows.Forms.Button();
			this.m_btEditar = new System.Windows.Forms.Button();
			this.m_btNovo = new System.Windows.Forms.Button();
			this.m_gbFrame = new System.Windows.Forms.GroupBox();
			this.m_cbTipoView = new mdlComponentesGraficos.ComboBox();
			this.m_lvCotacoes = new mdlComponentesGraficos.ListView();
			this.m_chFirst = new System.Windows.Forms.ColumnHeader();
			this.m_chSecond = new System.Windows.Forms.ColumnHeader();
			this.m_ilCotacaoGrandes = new System.Windows.Forms.ImageList(this.components);
			this.m_ilCotacaoPequenos = new System.Windows.Forms.ImageList(this.components);
			this.m_gbFrame.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_ttCotacao
			// 
			this.m_ttCotacao.AutomaticDelay = 100;
			this.m_ttCotacao.AutoPopDelay = 5000;
			this.m_ttCotacao.InitialDelay = 100;
			this.m_ttCotacao.ReshowDelay = 20;
			// 
			// m_btTrocarCor
			// 
			this.m_btTrocarCor.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_btTrocarCor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btTrocarCor.Location = new System.Drawing.Point(3, 12);
			this.m_btTrocarCor.Name = "m_btTrocarCor";
			this.m_btTrocarCor.Size = new System.Drawing.Size(4, 4);
			this.m_btTrocarCor.TabIndex = 6;
			this.m_ttCotacao.SetToolTip(this.m_btTrocarCor, "Cor");
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
			this.m_btExcluir.TabIndex = 4;
			this.m_btExcluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttCotacao.SetToolTip(this.m_btExcluir, "Excluir");
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
			this.m_btEditar.TabIndex = 3;
			this.m_btEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttCotacao.SetToolTip(this.m_btEditar, "Editar");
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
			this.m_btNovo.TabIndex = 2;
			this.m_btNovo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttCotacao.SetToolTip(this.m_btNovo, "Nova");
			this.m_btNovo.Click += new System.EventHandler(this.m_btNovo_Click);
			// 
			// m_gbFrame
			// 
			this.m_gbFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFrame.Controls.Add(this.m_cbTipoView);
			this.m_gbFrame.Controls.Add(this.m_btTrocarCor);
			this.m_gbFrame.Controls.Add(this.m_lvCotacoes);
			this.m_gbFrame.Controls.Add(this.m_btExcluir);
			this.m_gbFrame.Controls.Add(this.m_btEditar);
			this.m_gbFrame.Controls.Add(this.m_btNovo);
			this.m_gbFrame.Font = new System.Drawing.Font("Arial", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbFrame.Location = new System.Drawing.Point(73, -1);
			this.m_gbFrame.Name = "m_gbFrame";
			this.m_gbFrame.Size = new System.Drawing.Size(949, 567);
			this.m_gbFrame.TabIndex = 1;
			this.m_gbFrame.TabStop = false;
			this.m_gbFrame.Text = "Biblioteca de Cotações";
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
			this.m_cbTipoView.TabIndex = 5;
			this.m_cbTipoView.TextChanged += new System.EventHandler(this.m_cbTipoView_TextChanged);
			// 
			// m_lvCotacoes
			// 
			this.m_lvCotacoes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lvCotacoes.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_lvCotacoes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						   this.m_chFirst,
																						   this.m_chSecond});
			this.m_lvCotacoes.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lvCotacoes.FullRowSelect = true;
			this.m_lvCotacoes.HideSelection = false;
			this.m_lvCotacoes.LargeImageList = this.m_ilCotacaoGrandes;
			this.m_lvCotacoes.Location = new System.Drawing.Point(8, 54);
			this.m_lvCotacoes.Name = "m_lvCotacoes";
			this.m_lvCotacoes.Size = new System.Drawing.Size(933, 505);
			this.m_lvCotacoes.SmallImageList = this.m_ilCotacaoPequenos;
			this.m_lvCotacoes.StateImageList = this.m_ilCotacaoPequenos;
			this.m_lvCotacoes.TabIndex = 1;
			this.m_lvCotacoes.ItemActivate += new System.EventHandler(this.m_lvCotacoes_ItemActivate);
			this.m_lvCotacoes.Click += new System.EventHandler(this.m_lvCotacoes_Click);
			this.m_lvCotacoes.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.m_lvCotacoes_ColumnClick);
			// 
			// m_chFirst
			// 
			this.m_chFirst.Text = "Número da Cotação";
			this.m_chFirst.Width = 200;
			// 
			// m_chSecond
			// 
			this.m_chSecond.Text = "Nome do Importador";
			this.m_chSecond.Width = 680;
			// 
			// m_ilCotacaoGrandes
			// 
			this.m_ilCotacaoGrandes.ImageSize = new System.Drawing.Size(32, 32);
			this.m_ilCotacaoGrandes.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_ilCotacaoGrandes.ImageStream")));
			this.m_ilCotacaoGrandes.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// m_ilCotacaoPequenos
			// 
			this.m_ilCotacaoPequenos.ImageSize = new System.Drawing.Size(16, 16);
			this.m_ilCotacaoPequenos.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_ilCotacaoPequenos.ImageStream")));
			this.m_ilCotacaoPequenos.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// frmFCotacoes
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(1024, 568);
			this.Controls.Add(this.m_gbFrame);
			this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFCotacoes";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Cotacoes";
			this.Load += new System.EventHandler(this.frmFCotacoes_Load);
			this.m_gbFrame.ResumeLayout(false);
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
					if ((this.Controls[cont].GetType().ToString() != "mdlComponentes.compTextBox") && (this.Controls[cont].GetType().ToString() != "mdlComponentes.compTextNumber") &&
						(this.Controls[cont].GetType().ToString() != "mdlComponentesGraficos.ListView"))
					{
						this.Controls[cont].BackColor = this.BackColor;
					}
					for (int cont2 = 0; cont2 < this.Controls[cont].Controls.Count; cont2++)
					{
						if ((this.Controls[cont].Controls[cont2].GetType().ToString() != "mdlComponentes.compTextBox") && (this.Controls[cont].Controls[cont2].GetType().ToString() != "mdlComponentes.compTextNumber") &&
							(this.Controls[cont].Controls[cont2].GetType().ToString() != "mdlComponentesGraficos.ListView") && (this.Controls[cont].Controls[cont2].GetType().ToString() != "mdlComponentesGraficos.ComboBox"))
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
			if (this.m_lvCotacoes.View == System.Windows.Forms.View.LargeIcon)
				this.m_cbTipoView.SelectedIndex = 0;
			else if (this.m_lvCotacoes.View == System.Windows.Forms.View.Details)
				this.m_cbTipoView.SelectedIndex = 1;
			else if (this.m_lvCotacoes.View == System.Windows.Forms.View.SmallIcon)
				this.m_cbTipoView.SelectedIndex = 2;
			else if (this.m_lvCotacoes.View == System.Windows.Forms.View.List)
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

		#region Eventos
		#region Key Up
		private void m_lvCotacoes_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyData == System.Windows.Forms.Keys.Delete)
				{
					m_btExcluir_Click(sender, new System.EventArgs());
				}
//				else if (e.KeyData == System.Windows.Forms.Keys.F2)
//				{
//				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Load
		private void frmFCotacoes_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.mostraCor();
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
		#region Excluir
		private void m_btExcluir_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (m_lvCotacoes.SelectedItems.Count > 0)
				{
					if (OnCallRemoveCotacao())
					{
						OnCallCarregaDadosInterface();
						OnCallOrdenaItens();
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
		#region Novo
		private void m_btNovo_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				OnCallCadastraCotacao();
				this.mostraCor();
				OnCallCarregaDadosBD();
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
				if (m_lvCotacoes.SelectedItems.Count == 1)
				{
					OnCallSalvaDadosInterface();
					OnCallSalvaDadosBD();
					OnCallEditaCotacao();
					OnCallCarregaDadosBD();
					OnCallCarregaDadosInterface();
					OnCallOrdenaItens();
					this.mostraCor();
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
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				m_bModificado = true;
				OnCallSalvaDadosInterface();
				OnCallSalvaDadosBD();
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region List View Click
		private void m_lvCotacoes_Click(object sender, System.EventArgs e)
		{
			try
			{
				OnCallCarregaDadosBDCotacoes();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion		
		#region Duplo Clique
		private void m_lvCotacoes_ItemActivate(object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (m_lvCotacoes.SelectedItems.Count > 0)
                    OnCallDuploClique();
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Tipo View
		private void m_cbTipoView_TextChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (this.m_cbTipoView.SelectedIndex == 0)
					m_lvCotacoes.View = System.Windows.Forms.View.LargeIcon;
				else if (this.m_cbTipoView.SelectedIndex == 1)
					m_lvCotacoes.View = System.Windows.Forms.View.Details;
				else if (this.m_cbTipoView.SelectedIndex == 2)
					m_lvCotacoes.View = System.Windows.Forms.View.SmallIcon;
				else if (this.m_cbTipoView.SelectedIndex == 3)
					m_lvCotacoes.View = System.Windows.Forms.View.List;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Column Click
		private void m_lvCotacoes_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
			m_nIdColunaSelecionada = e.Column;
			if (m_lvCotacoes.Sorting == System.Windows.Forms.SortOrder.Ascending)
				m_lvCotacoes.Sorting = System.Windows.Forms.SortOrder.Descending;
			else
				m_lvCotacoes.Sorting = System.Windows.Forms.SortOrder.Ascending;
			OnCallOrdenaItens();
		}
		#endregion
		#endregion
	}
}