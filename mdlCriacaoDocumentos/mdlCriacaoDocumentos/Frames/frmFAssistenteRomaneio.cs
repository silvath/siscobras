using System;
using System.Collections;
using System.Windows.Forms;

namespace mdlCriacaoDocumentos.Frames
{
	/// <summary>
	/// Summary description for frmFAssistenteRomaneio.
	/// </summary>
	public class frmFAssistenteRomaneio : mdlComponentesGraficos.FormFlutuante
	{
		#region Atributos
		private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
		private string m_strEnderecoExecutavel = "";

		public bool m_bModificado = false;

		private bool m_bLoad = true;

		private bool m_bComecarAssistente = true;

		private enum ORDEM { NUMERO, PRODUTOSROMANEIO };
		private ORDEM m_enumOrdem = ORDEM.NUMERO;

		private System.Windows.Forms.LinkLabelLinkClickedEventArgs m_llevents_Args = new System.Windows.Forms.LinkLabelLinkClickedEventArgs(null);

		private System.Windows.Forms.GroupBox m_gbFrame;
		private System.Windows.Forms.Button m_btOk;
		private System.Windows.Forms.Button m_btCancelar;
		internal System.Windows.Forms.Button m_btTrocarCor;
		private System.Windows.Forms.GroupBox m_gbFields;
		private System.Windows.Forms.PictureBox m_pbBanner;
		private System.Windows.Forms.LinkLabel m_llNumero;
		private System.Windows.Forms.PictureBox m_pbNOKNumero;
		private System.Windows.Forms.PictureBox m_pbOkNumero;
		private System.Windows.Forms.ToolTip m_ttAssistente;
		private System.Windows.Forms.Timer m_tmAssistente;
		private System.Windows.Forms.PictureBox m_pbOkProdutosRomaneio;
		private System.Windows.Forms.PictureBox m_pbNOKProdutosRomaneio;
		private System.Windows.Forms.LinkLabel m_llProdutosRomaneio;
		private System.ComponentModel.IContainer components;
		#endregion

		#region Construtores & Destrutores
		public frmFAssistenteRomaneio(ref mdlTratamentoErro.clsTratamentoErro clstratadorErro, string strEnderecoExecutavel)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_cls_ter_tratadorErro = clstratadorErro;
			m_strEnderecoExecutavel = strEnderecoExecutavel;
		}
		public frmFAssistenteRomaneio(ref mdlTratamentoErro.clsTratamentoErro clstratadorErro, string strEnderecoExecutavel, bool bComecarAssistente, bool bTodosOk)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_cls_ter_tratadorErro = clstratadorErro;
			m_strEnderecoExecutavel = strEnderecoExecutavel;
			m_bComecarAssistente = bComecarAssistente;
			if (bTodosOk)
				todosOkVisiveis();
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

		#region Delegates
		// Cliques
		public delegate void delCallSelecionaNumero(ref System.Windows.Forms.PictureBox pbOkNumero, ref System.Windows.Forms.PictureBox pbNOKNumero);
		public delegate void delCallSelecionaProdutosRomaneio(ref System.Windows.Forms.PictureBox pbOkProdutosRomaneio, ref System.Windows.Forms.PictureBox pbNOkProdutosRomaneio);
		// Delegate para o Banner
		public delegate void delCallAlteraBanner(ref System.Windows.Forms.PictureBox pbBanner);
		public delegate void delCallClickBanner();
		#endregion
		#region Events
		public event delCallSelecionaNumero eCallSelecionaNumero;
		public event delCallSelecionaProdutosRomaneio eCallSelecionaProdutosRomaneio;
		// Eventos Alterar Banner
		public event delCallAlteraBanner eCallAlteraBanner;
		public event delCallClickBanner eCallClickBanner;
		#endregion
		#region Events Methods
		protected virtual void OnCallSelecionaNumero()
		{
			if (eCallSelecionaNumero != null)
				eCallSelecionaNumero(ref m_pbOkNumero, ref m_pbNOKNumero);
		}
		protected virtual void OnCallSelecionaProdutosRomaneio()
		{
			if (eCallSelecionaProdutosRomaneio != null)
				eCallSelecionaProdutosRomaneio(ref m_pbOkProdutosRomaneio, ref m_pbNOKProdutosRomaneio);
		}
		protected virtual void OnCallAlteraBanner()
		{
			if (eCallAlteraBanner != null)
				eCallAlteraBanner(ref this.m_pbBanner);
		}
		protected virtual void OnCallClickBanner()
		{
			if (eCallClickBanner != null)
				eCallClickBanner();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFAssistenteRomaneio));
			this.m_gbFrame = new System.Windows.Forms.GroupBox();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_btTrocarCor = new System.Windows.Forms.Button();
			this.m_gbFields = new System.Windows.Forms.GroupBox();
			this.m_pbBanner = new System.Windows.Forms.PictureBox();
			this.m_llProdutosRomaneio = new System.Windows.Forms.LinkLabel();
			this.m_llNumero = new System.Windows.Forms.LinkLabel();
			this.m_pbOkNumero = new System.Windows.Forms.PictureBox();
			this.m_pbNOKNumero = new System.Windows.Forms.PictureBox();
			this.m_pbOkProdutosRomaneio = new System.Windows.Forms.PictureBox();
			this.m_pbNOKProdutosRomaneio = new System.Windows.Forms.PictureBox();
			this.m_ttAssistente = new System.Windows.Forms.ToolTip(this.components);
			this.m_tmAssistente = new System.Windows.Forms.Timer(this.components);
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
			this.m_gbFrame.Controls.Add(this.m_btTrocarCor);
			this.m_gbFrame.Controls.Add(this.m_gbFields);
			this.m_gbFrame.Location = new System.Drawing.Point(2, 0);
			this.m_gbFrame.Name = "m_gbFrame";
			this.m_gbFrame.Size = new System.Drawing.Size(454, 357);
			this.m_gbFrame.TabIndex = 1;
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
			this.m_btOk.Location = new System.Drawing.Point(199, 326);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 10;
			this.m_ttAssistente.SetToolTip(this.m_btOk, "Confirmar");
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
			this.m_btCancelar.Location = new System.Drawing.Point(231, 326);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 11;
			this.m_ttAssistente.SetToolTip(this.m_btCancelar, "Fechar");
			this.m_btCancelar.Visible = false;
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_btTrocarCor
			// 
			this.m_btTrocarCor.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_btTrocarCor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btTrocarCor.Location = new System.Drawing.Point(4, 9);
			this.m_btTrocarCor.Name = "m_btTrocarCor";
			this.m_btTrocarCor.Size = new System.Drawing.Size(4, 4);
			this.m_btTrocarCor.TabIndex = 12;
			this.m_ttAssistente.SetToolTip(this.m_btTrocarCor, "Cor");
			this.m_btTrocarCor.Click += new System.EventHandler(this.m_btTrocarCor_Click);
			// 
			// m_gbFields
			// 
			this.m_gbFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFields.Controls.Add(this.m_pbBanner);
			this.m_gbFields.Controls.Add(this.m_llProdutosRomaneio);
			this.m_gbFields.Controls.Add(this.m_llNumero);
			this.m_gbFields.Controls.Add(this.m_pbOkNumero);
			this.m_gbFields.Controls.Add(this.m_pbNOKNumero);
			this.m_gbFields.Controls.Add(this.m_pbOkProdutosRomaneio);
			this.m_gbFields.Controls.Add(this.m_pbNOKProdutosRomaneio);
			this.m_gbFields.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbFields.Location = new System.Drawing.Point(8, 8);
			this.m_gbFields.Name = "m_gbFields";
			this.m_gbFields.Size = new System.Drawing.Size(438, 313);
			this.m_gbFields.TabIndex = 0;
			this.m_gbFields.TabStop = false;
			this.m_gbFields.Text = "Selecione";
			// 
			// m_pbBanner
			// 
			this.m_pbBanner.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_pbBanner.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.m_pbBanner.Image = ((System.Drawing.Image)(resources.GetObject("m_pbBanner.Image")));
			this.m_pbBanner.Location = new System.Drawing.Point(219, 15);
			this.m_pbBanner.Name = "m_pbBanner";
			this.m_pbBanner.Size = new System.Drawing.Size(210, 290);
			this.m_pbBanner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbBanner.TabIndex = 36;
			this.m_pbBanner.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbBanner, "www.portaldoexportador.com.br");
			this.m_pbBanner.Click += new System.EventHandler(this.m_pbBanner_Click);
			this.m_pbBanner.MouseEnter += new System.EventHandler(this.m_pbBanner_MouseEnter);
			this.m_pbBanner.MouseLeave += new System.EventHandler(this.m_pbBanner_MouseLeave);
			// 
			// m_llProdutosRomaneio
			// 
			this.m_llProdutosRomaneio.ActiveLinkColor = System.Drawing.Color.Black;
			this.m_llProdutosRomaneio.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_llProdutosRomaneio.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_llProdutosRomaneio.LinkColor = System.Drawing.Color.Red;
			this.m_llProdutosRomaneio.Location = new System.Drawing.Point(29, 44);
			this.m_llProdutosRomaneio.Name = "m_llProdutosRomaneio";
			this.m_llProdutosRomaneio.Size = new System.Drawing.Size(142, 20);
			this.m_llProdutosRomaneio.TabIndex = 3;
			this.m_llProdutosRomaneio.TabStop = true;
			this.m_llProdutosRomaneio.Text = "Produtos do Romaneio";
			this.m_ttAssistente.SetToolTip(this.m_llProdutosRomaneio, "Item não visitado");
			this.m_llProdutosRomaneio.VisitedLinkColor = System.Drawing.Color.Green;
			this.m_llProdutosRomaneio.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_llProdutosRomaneio_LinkClicked);
			// 
			// m_llNumero
			// 
			this.m_llNumero.ActiveLinkColor = System.Drawing.Color.Black;
			this.m_llNumero.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_llNumero.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_llNumero.LinkColor = System.Drawing.Color.Red;
			this.m_llNumero.Location = new System.Drawing.Point(29, 20);
			this.m_llNumero.Name = "m_llNumero";
			this.m_llNumero.Size = new System.Drawing.Size(106, 20);
			this.m_llNumero.TabIndex = 1;
			this.m_llNumero.TabStop = true;
			this.m_llNumero.Text = "Número";
			this.m_ttAssistente.SetToolTip(this.m_llNumero, "Item não visitado");
			this.m_llNumero.VisitedLinkColor = System.Drawing.Color.Green;
			this.m_llNumero.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_llNumero_LinkClicked);
			// 
			// m_pbOkNumero
			// 
			this.m_pbOkNumero.Image = ((System.Drawing.Image)(resources.GetObject("m_pbOkNumero.Image")));
			this.m_pbOkNumero.Location = new System.Drawing.Point(8, 22);
			this.m_pbOkNumero.Name = "m_pbOkNumero";
			this.m_pbOkNumero.Size = new System.Drawing.Size(16, 16);
			this.m_pbOkNumero.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbOkNumero.TabIndex = 0;
			this.m_pbOkNumero.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbOkNumero, "Item completo");
			this.m_pbOkNumero.Visible = false;
			// 
			// m_pbNOKNumero
			// 
			this.m_pbNOKNumero.Image = ((System.Drawing.Image)(resources.GetObject("m_pbNOKNumero.Image")));
			this.m_pbNOKNumero.Location = new System.Drawing.Point(8, 22);
			this.m_pbNOKNumero.Name = "m_pbNOKNumero";
			this.m_pbNOKNumero.Size = new System.Drawing.Size(16, 16);
			this.m_pbNOKNumero.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbNOKNumero.TabIndex = 24;
			this.m_pbNOKNumero.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbNOKNumero, "Item não completo");
			// 
			// m_pbOkProdutosRomaneio
			// 
			this.m_pbOkProdutosRomaneio.Image = ((System.Drawing.Image)(resources.GetObject("m_pbOkProdutosRomaneio.Image")));
			this.m_pbOkProdutosRomaneio.Location = new System.Drawing.Point(8, 46);
			this.m_pbOkProdutosRomaneio.Name = "m_pbOkProdutosRomaneio";
			this.m_pbOkProdutosRomaneio.Size = new System.Drawing.Size(16, 16);
			this.m_pbOkProdutosRomaneio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbOkProdutosRomaneio.TabIndex = 2;
			this.m_pbOkProdutosRomaneio.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbOkProdutosRomaneio, "Item completo");
			this.m_pbOkProdutosRomaneio.Visible = false;
			// 
			// m_pbNOKProdutosRomaneio
			// 
			this.m_pbNOKProdutosRomaneio.Image = ((System.Drawing.Image)(resources.GetObject("m_pbNOKProdutosRomaneio.Image")));
			this.m_pbNOKProdutosRomaneio.Location = new System.Drawing.Point(8, 46);
			this.m_pbNOKProdutosRomaneio.Name = "m_pbNOKProdutosRomaneio";
			this.m_pbNOKProdutosRomaneio.Size = new System.Drawing.Size(16, 16);
			this.m_pbNOKProdutosRomaneio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbNOKProdutosRomaneio.TabIndex = 25;
			this.m_pbNOKProdutosRomaneio.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbNOKProdutosRomaneio, "Item não completo");
			// 
			// m_ttAssistente
			// 
			this.m_ttAssistente.AutomaticDelay = 100;
			this.m_ttAssistente.AutoPopDelay = 5000;
			this.m_ttAssistente.InitialDelay = 100;
			this.m_ttAssistente.ReshowDelay = 20;
			// 
			// m_tmAssistente
			// 
			this.m_tmAssistente.Enabled = true;
			this.m_tmAssistente.Interval = 2000;
			this.m_tmAssistente.Tick += new System.EventHandler(this.m_tmAssistente_Tick);
			// 
			// frmFAssistenteRomaneio
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(458, 359);
			this.Controls.Add(this.m_gbFrame);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFAssistenteRomaneio";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Assistente";
			this.Load += new System.EventHandler(this.frmFAssistenteRomaneio_Load);
			this.Activated += new System.EventHandler(this.frmFAssistenteRomaneio_Activated);
			this.m_gbFrame.ResumeLayout(false);
			this.m_gbFields.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Procedimentos Para Troca de Cor
		#region Trocar Cor
		/// <summary>
		/// Troca a cor do Formulario Controlado
		/// </summary>
		private void trocaCor()
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

		#region Todos OK
		private void todosOkVisiveis()
		{
			m_pbOkNumero.Visible = true;
			m_pbOkProdutosRomaneio.Visible = true;
			// NOK
			m_pbNOKNumero.Visible = false;
			m_pbNOKProdutosRomaneio.Visible = false;
		}
		#endregion

		#region Get & Set
		public void setaEstadoAssistente(bool bNumero, bool bProdutosRomaneio)
		{
			try
			{
				#region Número
				if (bNumero)
				{
					m_pbNOKNumero.Visible = false;
					m_pbOkNumero.Visible = true;
					m_llNumero.LinkVisited = true;
					m_ttAssistente.SetToolTip(m_llNumero, "Item visitado");
				}
				#endregion
				#region Produtos Romaneio
				if (bProdutosRomaneio)
				{
					m_pbNOKProdutosRomaneio.Visible = false;
					m_pbOkProdutosRomaneio.Visible = true;
					m_llProdutosRomaneio.LinkVisited = true;
					m_ttAssistente.SetToolTip(m_llProdutosRomaneio, "Item visitado");
				}
				#endregion
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		public void setToolTipBanner(string strToolTip)
		{
			m_ttAssistente.SetToolTip(m_pbBanner, strToolTip);
		}
		#endregion
		
		#region Eventos
		#region Links
		#region Número
		private void m_llNumero_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			m_enumOrdem = ORDEM.NUMERO;
			OnCallSelecionaNumero();
			m_llNumero.LinkVisited = true;
			m_ttAssistente.SetToolTip(m_llNumero, "Item visitado");
			this.mostraCor();
			if (m_pbOkNumero.Visible && m_pbNOKProdutosRomaneio.Visible)
				m_llProdutosRomaneio_LinkClicked(sender, m_llevents_Args);
		}
		#endregion
		#region Produtos Romaneio
		private void m_llProdutosRomaneio_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			m_enumOrdem = ORDEM.PRODUTOSROMANEIO;
			OnCallSelecionaProdutosRomaneio();
			m_llProdutosRomaneio.LinkVisited = true;
			m_ttAssistente.SetToolTip(m_llProdutosRomaneio, "Item visitado");
			this.mostraCor();
		}
		#endregion
		#endregion
		#region Cancelar
		private void m_btCancelar_Click(object sender, System.EventArgs e)
		{
			m_bModificado = false;
			this.Close();
		}
		#endregion
		#region Ok
		private void m_btOk_Click(object sender, System.EventArgs e)
		{
			m_bModificado = true;
			this.Close();
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
		#region Load
		private void frmFAssistenteRomaneio_Load(object sender, System.EventArgs e)
		{
			this.mostraCor();
		}
		#endregion
		#region Tick
		private void m_tmAssistente_Tick(object sender, System.EventArgs e)
		{
			try
			{
				OnCallAlteraBanner();
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
				if ((m_tmAssistente != null) && (m_tmAssistente.Enabled))
					this.m_tmAssistente.Stop();
				//this.m_tmContas.Enabled = false;
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
				if (m_tmAssistente != null)
					this.m_tmAssistente.Start();
				//this.m_tmContas.Enabled = true;
			}
			catch
			{
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
		#region Activated
		private void frmFAssistenteRomaneio_Activated(object sender, System.EventArgs e)
		{
			if (m_bLoad == true)
			{
				m_bLoad = false;
				if (m_bComecarAssistente)
				{
					if (m_pbNOKNumero.Visible)
						this.m_llNumero_LinkClicked(sender, m_llevents_Args);
					else if (m_pbNOKProdutosRomaneio.Visible)
						this.m_llProdutosRomaneio_LinkClicked(sender, m_llevents_Args);
				}
			}
		}
		#endregion
		#endregion
	}
}
