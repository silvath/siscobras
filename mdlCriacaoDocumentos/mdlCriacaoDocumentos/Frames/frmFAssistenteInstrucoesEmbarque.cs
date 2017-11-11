using System;
using System.Collections;
using System.Windows.Forms;

namespace mdlCriacaoDocumentos.Frames
{
	/// <summary>
	/// Summary description for frmFAssistenteInstrucoesEmbarque.
	/// </summary>
	internal class frmFAssistenteInstrucoesEmbarque : mdlComponentesGraficos.FormFlutuante
	{
		#region Atributos
		private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
		private string m_strEnderecoExecutavel = "";

		public bool m_bModificado = false;

		private bool m_bLoad = true;

		private bool m_bComecarAssistente = true;

		private enum ORDEM { NUMERO, AGENTE, NUMERORESERVA, DATARESERVA, CONSIGNATARIO, DESCRICAOMERCADORIAS, CLASSIFICACAOTARIFARIA, VEICULO, DESPACHANTE, SISCOMEX, OBSERVACOES };
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
		private System.Windows.Forms.LinkLabel m_llAgente;
		private System.Windows.Forms.PictureBox m_pbNOKAgente;
		private System.Windows.Forms.PictureBox m_pbOkAgente;
		private System.Windows.Forms.LinkLabel m_llNumeroReserva;
		private System.Windows.Forms.PictureBox m_pbNOKNumeroReserva;
		private System.Windows.Forms.PictureBox m_pbOkNumeroReserva;
		private System.Windows.Forms.LinkLabel m_llDataReserva;
		private System.Windows.Forms.PictureBox m_pbNOKDataReserva;
		private System.Windows.Forms.PictureBox m_pbOkDataReserva;
		private System.Windows.Forms.PictureBox m_pbNOKConsignatario;
		private System.Windows.Forms.PictureBox m_pbOkConsignatario;
		private System.Windows.Forms.LinkLabel m_llConsignatario;
		private System.Windows.Forms.LinkLabel m_llDescricaoMercadorias;
		private System.Windows.Forms.PictureBox m_pbNOKDescricaoMercadorias;
		private System.Windows.Forms.PictureBox m_pbOkDescricaoMercadorias;
		private System.Windows.Forms.PictureBox m_pbNOKClassificacaoTarifaria;
		private System.Windows.Forms.PictureBox m_pbOkClassificacaoTarifaria;
		private System.Windows.Forms.LinkLabel m_llClassificacaoTarifaria;
		private System.Windows.Forms.PictureBox m_pbOkVeiculoTransporte;
		private System.Windows.Forms.PictureBox m_pbNOKVeiculoTransporte;
		private System.Windows.Forms.LinkLabel m_llVeiculoTransporte;
		private System.Windows.Forms.PictureBox m_pbNOKDespachante;
		private System.Windows.Forms.PictureBox m_pbOkDespachante;
		private System.Windows.Forms.LinkLabel m_llDespachante;
		private System.Windows.Forms.PictureBox m_pbNOKSiscomex;
		private System.Windows.Forms.PictureBox m_pbOkSiscomex;
		private System.Windows.Forms.LinkLabel m_llSiscomex;
		private System.Windows.Forms.ToolTip m_ttAssistente;
		private System.Windows.Forms.Timer m_tmAssistente;
		private System.Windows.Forms.LinkLabel m_llObservacoes;
		private System.Windows.Forms.PictureBox m_pbOkObservacoes;
		private System.Windows.Forms.PictureBox m_pbNOKObservacoes;
		private System.ComponentModel.IContainer components;
		#endregion

		#region Construtores & Destrutores
		public frmFAssistenteInstrucoesEmbarque(ref mdlTratamentoErro.clsTratamentoErro clstratadorErro, string strEnderecoExecutavel)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_cls_ter_tratadorErro = clstratadorErro;
			m_strEnderecoExecutavel = strEnderecoExecutavel;
		}
		public frmFAssistenteInstrucoesEmbarque(ref mdlTratamentoErro.clsTratamentoErro clstratadorErro, string strEnderecoExecutavel, bool bComecarAssistente, bool bTodosOk)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_cls_ter_tratadorErro = clstratadorErro;
			m_strEnderecoExecutavel = strEnderecoExecutavel;
			m_bComecarAssistente = bComecarAssistente;
			//if (bTodosOk)
			//	todosOkVisiveis();
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
		public delegate void delCallSelecionaAgente(ref System.Windows.Forms.PictureBox pbOkAgente, ref System.Windows.Forms.PictureBox pbNOkAgente);
		public delegate void delCallSelecionaNumeroReserva(ref System.Windows.Forms.PictureBox pbOkNumeroReserva, ref System.Windows.Forms.PictureBox pbNOKNumeroReserva);
		public delegate void delCallSelecionaDataReserva(ref System.Windows.Forms.PictureBox pbOkDataReserva, ref System.Windows.Forms.PictureBox pbNOKDataReserva);
		public delegate void delCallSelecionaConsignatario(ref System.Windows.Forms.PictureBox pbOkConsignatario, ref System.Windows.Forms.PictureBox pbNOKConsignatario);
		public delegate void delCallSelecionaDescricaoMercadorias(ref System.Windows.Forms.PictureBox pbOkDescricaoMercadorias, ref System.Windows.Forms.PictureBox pbNOKDescricaoMercadorias);
		public delegate void delCallSelecionaClassificacaoTarifaria(ref System.Windows.Forms.PictureBox pbOkClassificaoTarifaria, ref System.Windows.Forms.PictureBox pbNOKClassificacaoTarifaria);
		public delegate void delCallSelecionaVeiculo(ref System.Windows.Forms.PictureBox pbOkVeiculo, ref System.Windows.Forms.PictureBox pbNOKVeiculo);
		public delegate void delCallSelecionaDespachante(ref System.Windows.Forms.PictureBox pbOkDespachante, ref System.Windows.Forms.PictureBox pbNOKDespachante);
		public delegate void delCallSelecionaSiscomex(ref System.Windows.Forms.PictureBox pbOkSiscomex, ref System.Windows.Forms.PictureBox pbNOKSiscomex);
		public delegate void delCallSelecionaObservacoes(ref System.Windows.Forms.PictureBox pbOkObservacoes, ref System.Windows.Forms.PictureBox pbNOKObservacoes);
		// Delegate para o Banner
		public delegate void delCallAlteraBanner(ref System.Windows.Forms.PictureBox pbBanner);
		public delegate void delCallClickBanner();
		#endregion
		#region Events
		public event delCallSelecionaNumero eCallSelecionaNumero;
		public event delCallSelecionaAgente eCallSelecionaAgente;
		public event delCallSelecionaNumeroReserva eCallSelecionaNumeroReserva;
		public event delCallSelecionaDataReserva eCallSelecionaDataReserva;
		public event delCallSelecionaConsignatario eCallSelecionaConsignatario;
		public event delCallSelecionaDescricaoMercadorias eCallSelecionaDescricaoMercadorias;
		public event delCallSelecionaClassificacaoTarifaria eCallSelecionaClassificacaoTarifaria;
		public event delCallSelecionaVeiculo eCallSelecionaVeiculo;
		public event delCallSelecionaDespachante eCallSelecionaDespachante;
		public event delCallSelecionaSiscomex eCallSelecionaSiscomex;
		public event delCallSelecionaObservacoes eCallSelecionaObservacoes;
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
		protected virtual void OnCallSelecionaAgente()
		{
			if (eCallSelecionaAgente != null)
				eCallSelecionaAgente(ref m_pbOkAgente, ref m_pbNOKAgente);
		}
		protected virtual void OnCallSelecionaNumeroReserva()
		{
			if (eCallSelecionaNumeroReserva != null)
				eCallSelecionaNumeroReserva(ref m_pbOkNumeroReserva, ref m_pbNOKNumeroReserva);
		}
		protected virtual void OnCallSelecionaDataReserva()
		{
			if (eCallSelecionaDataReserva != null)
				eCallSelecionaDataReserva(ref m_pbOkDataReserva, ref m_pbNOKDataReserva);
		}
		protected virtual void OnCallSelecionaConsignatario()
		{
			if (eCallSelecionaConsignatario != null)
				eCallSelecionaConsignatario(ref m_pbOkConsignatario, ref m_pbNOKConsignatario);
		}
		protected virtual void OnCallSelecionaDescricaoMercadorias()
		{
			if (eCallSelecionaDescricaoMercadorias != null)
				eCallSelecionaDescricaoMercadorias(ref m_pbOkDescricaoMercadorias, ref m_pbNOKDescricaoMercadorias);
		}
		protected virtual void OnCallSelecionaClassificacaoTarifaria()
		{
			if (eCallSelecionaClassificacaoTarifaria != null)
				eCallSelecionaClassificacaoTarifaria(ref m_pbOkClassificacaoTarifaria, ref m_pbNOKClassificacaoTarifaria);
		}
		protected virtual void OnCallSelecionaVeiculo()
		{
			if (eCallSelecionaVeiculo != null)
				eCallSelecionaVeiculo(ref m_pbOkVeiculoTransporte, ref m_pbNOKVeiculoTransporte);
		}
		protected virtual void OnCallSelecionaDespachante()
		{
			if (eCallSelecionaDespachante != null)
				eCallSelecionaDespachante(ref m_pbOkDespachante, ref m_pbNOKDespachante);
		}
		protected virtual void OnCallSelecionaSiscomex()
		{
			if (eCallSelecionaSiscomex != null)
				eCallSelecionaSiscomex(ref m_pbOkSiscomex, ref m_pbNOKSiscomex);
		}
		protected virtual void OnCallSelecionaObservacoes()
		{
			if (eCallSelecionaObservacoes != null)
				eCallSelecionaObservacoes(ref m_pbOkObservacoes, ref m_pbNOKObservacoes);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFAssistenteInstrucoesEmbarque));
			this.m_gbFrame = new System.Windows.Forms.GroupBox();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_btTrocarCor = new System.Windows.Forms.Button();
			this.m_gbFields = new System.Windows.Forms.GroupBox();
			this.m_llObservacoes = new System.Windows.Forms.LinkLabel();
			this.m_pbOkObservacoes = new System.Windows.Forms.PictureBox();
			this.m_llSiscomex = new System.Windows.Forms.LinkLabel();
			this.m_llDespachante = new System.Windows.Forms.LinkLabel();
			this.m_llVeiculoTransporte = new System.Windows.Forms.LinkLabel();
			this.m_llClassificacaoTarifaria = new System.Windows.Forms.LinkLabel();
			this.m_llDescricaoMercadorias = new System.Windows.Forms.LinkLabel();
			this.m_llConsignatario = new System.Windows.Forms.LinkLabel();
			this.m_llDataReserva = new System.Windows.Forms.LinkLabel();
			this.m_llNumeroReserva = new System.Windows.Forms.LinkLabel();
			this.m_llAgente = new System.Windows.Forms.LinkLabel();
			this.m_pbBanner = new System.Windows.Forms.PictureBox();
			this.m_llNumero = new System.Windows.Forms.LinkLabel();
			this.m_pbOkNumero = new System.Windows.Forms.PictureBox();
			this.m_pbOkAgente = new System.Windows.Forms.PictureBox();
			this.m_pbOkNumeroReserva = new System.Windows.Forms.PictureBox();
			this.m_pbOkDataReserva = new System.Windows.Forms.PictureBox();
			this.m_pbOkConsignatario = new System.Windows.Forms.PictureBox();
			this.m_pbOkDescricaoMercadorias = new System.Windows.Forms.PictureBox();
			this.m_pbOkClassificacaoTarifaria = new System.Windows.Forms.PictureBox();
			this.m_pbOkVeiculoTransporte = new System.Windows.Forms.PictureBox();
			this.m_pbOkDespachante = new System.Windows.Forms.PictureBox();
			this.m_pbNOKAgente = new System.Windows.Forms.PictureBox();
			this.m_pbNOKNumero = new System.Windows.Forms.PictureBox();
			this.m_pbNOKNumeroReserva = new System.Windows.Forms.PictureBox();
			this.m_pbNOKDataReserva = new System.Windows.Forms.PictureBox();
			this.m_pbNOKConsignatario = new System.Windows.Forms.PictureBox();
			this.m_pbNOKDescricaoMercadorias = new System.Windows.Forms.PictureBox();
			this.m_pbNOKClassificacaoTarifaria = new System.Windows.Forms.PictureBox();
			this.m_pbNOKVeiculoTransporte = new System.Windows.Forms.PictureBox();
			this.m_pbNOKDespachante = new System.Windows.Forms.PictureBox();
			this.m_pbOkSiscomex = new System.Windows.Forms.PictureBox();
			this.m_pbNOKSiscomex = new System.Windows.Forms.PictureBox();
			this.m_pbNOKObservacoes = new System.Windows.Forms.PictureBox();
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
			this.m_gbFrame.TabIndex = 2;
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
			this.m_ttAssistente.SetToolTip(this.m_btCancelar, "Cancelar");
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
			this.m_btTrocarCor.Click += new System.EventHandler(this.m_btTrocarCor_Click);
			// 
			// m_gbFields
			// 
			this.m_gbFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFields.Controls.Add(this.m_llObservacoes);
			this.m_gbFields.Controls.Add(this.m_pbOkObservacoes);
			this.m_gbFields.Controls.Add(this.m_llSiscomex);
			this.m_gbFields.Controls.Add(this.m_llDespachante);
			this.m_gbFields.Controls.Add(this.m_llVeiculoTransporte);
			this.m_gbFields.Controls.Add(this.m_llClassificacaoTarifaria);
			this.m_gbFields.Controls.Add(this.m_llDescricaoMercadorias);
			this.m_gbFields.Controls.Add(this.m_llConsignatario);
			this.m_gbFields.Controls.Add(this.m_llDataReserva);
			this.m_gbFields.Controls.Add(this.m_llNumeroReserva);
			this.m_gbFields.Controls.Add(this.m_llAgente);
			this.m_gbFields.Controls.Add(this.m_pbBanner);
			this.m_gbFields.Controls.Add(this.m_llNumero);
			this.m_gbFields.Controls.Add(this.m_pbOkNumero);
			this.m_gbFields.Controls.Add(this.m_pbOkAgente);
			this.m_gbFields.Controls.Add(this.m_pbOkNumeroReserva);
			this.m_gbFields.Controls.Add(this.m_pbOkDataReserva);
			this.m_gbFields.Controls.Add(this.m_pbOkConsignatario);
			this.m_gbFields.Controls.Add(this.m_pbOkDescricaoMercadorias);
			this.m_gbFields.Controls.Add(this.m_pbOkClassificacaoTarifaria);
			this.m_gbFields.Controls.Add(this.m_pbOkVeiculoTransporte);
			this.m_gbFields.Controls.Add(this.m_pbOkDespachante);
			this.m_gbFields.Controls.Add(this.m_pbNOKAgente);
			this.m_gbFields.Controls.Add(this.m_pbNOKNumero);
			this.m_gbFields.Controls.Add(this.m_pbNOKNumeroReserva);
			this.m_gbFields.Controls.Add(this.m_pbNOKDataReserva);
			this.m_gbFields.Controls.Add(this.m_pbNOKConsignatario);
			this.m_gbFields.Controls.Add(this.m_pbNOKDescricaoMercadorias);
			this.m_gbFields.Controls.Add(this.m_pbNOKClassificacaoTarifaria);
			this.m_gbFields.Controls.Add(this.m_pbNOKVeiculoTransporte);
			this.m_gbFields.Controls.Add(this.m_pbNOKDespachante);
			this.m_gbFields.Controls.Add(this.m_pbOkSiscomex);
			this.m_gbFields.Controls.Add(this.m_pbNOKSiscomex);
			this.m_gbFields.Controls.Add(this.m_pbNOKObservacoes);
			this.m_gbFields.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbFields.Location = new System.Drawing.Point(8, 8);
			this.m_gbFields.Name = "m_gbFields";
			this.m_gbFields.Size = new System.Drawing.Size(438, 313);
			this.m_gbFields.TabIndex = 0;
			this.m_gbFields.TabStop = false;
			this.m_gbFields.Text = "Selecione";
			// 
			// m_llObservacoes
			// 
			this.m_llObservacoes.ActiveLinkColor = System.Drawing.Color.Black;
			this.m_llObservacoes.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_llObservacoes.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_llObservacoes.LinkColor = System.Drawing.Color.Red;
			this.m_llObservacoes.Location = new System.Drawing.Point(29, 258);
			this.m_llObservacoes.Name = "m_llObservacoes";
			this.m_llObservacoes.Size = new System.Drawing.Size(84, 20);
			this.m_llObservacoes.TabIndex = 65;
			this.m_llObservacoes.TabStop = true;
			this.m_llObservacoes.Text = "Observações";
			this.m_ttAssistente.SetToolTip(this.m_llObservacoes, "Item não visitado");
			this.m_llObservacoes.VisitedLinkColor = System.Drawing.Color.Green;
			this.m_llObservacoes.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_llObservacoes_LinkClicked);
			// 
			// m_pbOkObservacoes
			// 
			this.m_pbOkObservacoes.Image = ((System.Drawing.Image)(resources.GetObject("m_pbOkObservacoes.Image")));
			this.m_pbOkObservacoes.Location = new System.Drawing.Point(8, 260);
			this.m_pbOkObservacoes.Name = "m_pbOkObservacoes";
			this.m_pbOkObservacoes.Size = new System.Drawing.Size(16, 16);
			this.m_pbOkObservacoes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbOkObservacoes.TabIndex = 64;
			this.m_pbOkObservacoes.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbOkObservacoes, "Item Completo");
			this.m_pbOkObservacoes.Visible = false;
			// 
			// m_llSiscomex
			// 
			this.m_llSiscomex.ActiveLinkColor = System.Drawing.Color.Black;
			this.m_llSiscomex.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_llSiscomex.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_llSiscomex.LinkColor = System.Drawing.Color.Red;
			this.m_llSiscomex.Location = new System.Drawing.Point(29, 234);
			this.m_llSiscomex.Name = "m_llSiscomex";
			this.m_llSiscomex.Size = new System.Drawing.Size(63, 20);
			this.m_llSiscomex.TabIndex = 63;
			this.m_llSiscomex.TabStop = true;
			this.m_llSiscomex.Text = "Siscomex";
			this.m_ttAssistente.SetToolTip(this.m_llSiscomex, "Item não visitado");
			this.m_llSiscomex.VisitedLinkColor = System.Drawing.Color.Green;
			this.m_llSiscomex.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_llSiscomex_LinkClicked);
			// 
			// m_llDespachante
			// 
			this.m_llDespachante.ActiveLinkColor = System.Drawing.Color.Black;
			this.m_llDespachante.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_llDespachante.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_llDespachante.LinkColor = System.Drawing.Color.Red;
			this.m_llDespachante.Location = new System.Drawing.Point(29, 210);
			this.m_llDespachante.Name = "m_llDespachante";
			this.m_llDespachante.Size = new System.Drawing.Size(84, 20);
			this.m_llDespachante.TabIndex = 60;
			this.m_llDespachante.TabStop = true;
			this.m_llDespachante.Text = "Despachante";
			this.m_ttAssistente.SetToolTip(this.m_llDespachante, "Item não visitado");
			this.m_llDespachante.VisitedLinkColor = System.Drawing.Color.Green;
			this.m_llDespachante.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_llDespachante_LinkClicked);
			// 
			// m_llVeiculoTransporte
			// 
			this.m_llVeiculoTransporte.ActiveLinkColor = System.Drawing.Color.Black;
			this.m_llVeiculoTransporte.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_llVeiculoTransporte.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_llVeiculoTransporte.LinkColor = System.Drawing.Color.Red;
			this.m_llVeiculoTransporte.Location = new System.Drawing.Point(29, 186);
			this.m_llVeiculoTransporte.Name = "m_llVeiculoTransporte";
			this.m_llVeiculoTransporte.Size = new System.Drawing.Size(137, 20);
			this.m_llVeiculoTransporte.TabIndex = 57;
			this.m_llVeiculoTransporte.TabStop = true;
			this.m_llVeiculoTransporte.Text = "Veículo de Transporte";
			this.m_ttAssistente.SetToolTip(this.m_llVeiculoTransporte, "Item não visitado");
			this.m_llVeiculoTransporte.VisitedLinkColor = System.Drawing.Color.Green;
			this.m_llVeiculoTransporte.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_llVeiculoTransporte_LinkClicked);
			// 
			// m_llClassificacaoTarifaria
			// 
			this.m_llClassificacaoTarifaria.ActiveLinkColor = System.Drawing.Color.Black;
			this.m_llClassificacaoTarifaria.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_llClassificacaoTarifaria.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_llClassificacaoTarifaria.LinkColor = System.Drawing.Color.Red;
			this.m_llClassificacaoTarifaria.Location = new System.Drawing.Point(29, 162);
			this.m_llClassificacaoTarifaria.Name = "m_llClassificacaoTarifaria";
			this.m_llClassificacaoTarifaria.Size = new System.Drawing.Size(139, 20);
			this.m_llClassificacaoTarifaria.TabIndex = 54;
			this.m_llClassificacaoTarifaria.TabStop = true;
			this.m_llClassificacaoTarifaria.Text = "Classificação Tarifária";
			this.m_ttAssistente.SetToolTip(this.m_llClassificacaoTarifaria, "Item não visitado");
			this.m_llClassificacaoTarifaria.VisitedLinkColor = System.Drawing.Color.Green;
			this.m_llClassificacaoTarifaria.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_llClassificacaoTarifaria_LinkClicked);
			// 
			// m_llDescricaoMercadorias
			// 
			this.m_llDescricaoMercadorias.ActiveLinkColor = System.Drawing.Color.Black;
			this.m_llDescricaoMercadorias.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_llDescricaoMercadorias.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_llDescricaoMercadorias.LinkColor = System.Drawing.Color.Red;
			this.m_llDescricaoMercadorias.Location = new System.Drawing.Point(29, 138);
			this.m_llDescricaoMercadorias.Name = "m_llDescricaoMercadorias";
			this.m_llDescricaoMercadorias.Size = new System.Drawing.Size(167, 20);
			this.m_llDescricaoMercadorias.TabIndex = 50;
			this.m_llDescricaoMercadorias.TabStop = true;
			this.m_llDescricaoMercadorias.Text = "Descrição das Mercadorias";
			this.m_ttAssistente.SetToolTip(this.m_llDescricaoMercadorias, "Item não visitado");
			this.m_llDescricaoMercadorias.VisitedLinkColor = System.Drawing.Color.Green;
			this.m_llDescricaoMercadorias.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_llDescricaoMercadorias_LinkClicked);
			// 
			// m_llConsignatario
			// 
			this.m_llConsignatario.ActiveLinkColor = System.Drawing.Color.Black;
			this.m_llConsignatario.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_llConsignatario.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_llConsignatario.LinkColor = System.Drawing.Color.Red;
			this.m_llConsignatario.Location = new System.Drawing.Point(29, 114);
			this.m_llConsignatario.Name = "m_llConsignatario";
			this.m_llConsignatario.Size = new System.Drawing.Size(87, 20);
			this.m_llConsignatario.TabIndex = 48;
			this.m_llConsignatario.TabStop = true;
			this.m_llConsignatario.Text = "Consignatário";
			this.m_ttAssistente.SetToolTip(this.m_llConsignatario, "Item não visitado");
			this.m_llConsignatario.VisitedLinkColor = System.Drawing.Color.Green;
			this.m_llConsignatario.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_llConsignatario_LinkClicked);
			// 
			// m_llDataReserva
			// 
			this.m_llDataReserva.ActiveLinkColor = System.Drawing.Color.Black;
			this.m_llDataReserva.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_llDataReserva.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_llDataReserva.LinkColor = System.Drawing.Color.Red;
			this.m_llDataReserva.Location = new System.Drawing.Point(29, 92);
			this.m_llDataReserva.Name = "m_llDataReserva";
			this.m_llDataReserva.Size = new System.Drawing.Size(105, 20);
			this.m_llDataReserva.TabIndex = 43;
			this.m_llDataReserva.TabStop = true;
			this.m_llDataReserva.Text = "Data da Reserva";
			this.m_ttAssistente.SetToolTip(this.m_llDataReserva, "Item não visitado");
			this.m_llDataReserva.VisitedLinkColor = System.Drawing.Color.Green;
			this.m_llDataReserva.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_llDataReserva_LinkClicked);
			// 
			// m_llNumeroReserva
			// 
			this.m_llNumeroReserva.ActiveLinkColor = System.Drawing.Color.Black;
			this.m_llNumeroReserva.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_llNumeroReserva.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_llNumeroReserva.LinkColor = System.Drawing.Color.Red;
			this.m_llNumeroReserva.Location = new System.Drawing.Point(29, 68);
			this.m_llNumeroReserva.Name = "m_llNumeroReserva";
			this.m_llNumeroReserva.Size = new System.Drawing.Size(125, 20);
			this.m_llNumeroReserva.TabIndex = 40;
			this.m_llNumeroReserva.TabStop = true;
			this.m_llNumeroReserva.Text = "Número da Reserva";
			this.m_ttAssistente.SetToolTip(this.m_llNumeroReserva, "Item não visitado");
			this.m_llNumeroReserva.VisitedLinkColor = System.Drawing.Color.Green;
			this.m_llNumeroReserva.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_llNumeroReserva_LinkClicked);
			// 
			// m_llAgente
			// 
			this.m_llAgente.ActiveLinkColor = System.Drawing.Color.Black;
			this.m_llAgente.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_llAgente.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_llAgente.LinkColor = System.Drawing.Color.Red;
			this.m_llAgente.Location = new System.Drawing.Point(29, 44);
			this.m_llAgente.Name = "m_llAgente";
			this.m_llAgente.Size = new System.Drawing.Size(131, 20);
			this.m_llAgente.TabIndex = 37;
			this.m_llAgente.TabStop = true;
			this.m_llAgente.Text = "Agente de Embarque";
			this.m_ttAssistente.SetToolTip(this.m_llAgente, "Item não visitado");
			this.m_llAgente.VisitedLinkColor = System.Drawing.Color.Green;
			this.m_llAgente.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_llAgente_LinkClicked);
			// 
			// m_pbBanner
			// 
			this.m_pbBanner.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_pbBanner.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.m_pbBanner.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_pbBanner.BackgroundImage")));
			this.m_pbBanner.Location = new System.Drawing.Point(219, 15);
			this.m_pbBanner.Name = "m_pbBanner";
			this.m_pbBanner.Size = new System.Drawing.Size(210, 290);
			this.m_pbBanner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbBanner.TabIndex = 36;
			this.m_pbBanner.TabStop = false;
			this.m_pbBanner.Click += new System.EventHandler(this.m_pbBanner_Click);
			this.m_pbBanner.MouseEnter += new System.EventHandler(this.m_pbBanner_MouseEnter);
			this.m_pbBanner.MouseLeave += new System.EventHandler(this.m_pbBanner_MouseLeave);
			// 
			// m_llNumero
			// 
			this.m_llNumero.ActiveLinkColor = System.Drawing.Color.Black;
			this.m_llNumero.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_llNumero.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_llNumero.LinkColor = System.Drawing.Color.Red;
			this.m_llNumero.Location = new System.Drawing.Point(29, 20);
			this.m_llNumero.Name = "m_llNumero";
			this.m_llNumero.Size = new System.Drawing.Size(52, 20);
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
			this.m_ttAssistente.SetToolTip(this.m_pbOkNumero, "Item Completo");
			this.m_pbOkNumero.Visible = false;
			// 
			// m_pbOkAgente
			// 
			this.m_pbOkAgente.Image = ((System.Drawing.Image)(resources.GetObject("m_pbOkAgente.Image")));
			this.m_pbOkAgente.Location = new System.Drawing.Point(8, 46);
			this.m_pbOkAgente.Name = "m_pbOkAgente";
			this.m_pbOkAgente.Size = new System.Drawing.Size(16, 16);
			this.m_pbOkAgente.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbOkAgente.TabIndex = 39;
			this.m_pbOkAgente.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbOkAgente, "Item Completo");
			this.m_pbOkAgente.Visible = false;
			// 
			// m_pbOkNumeroReserva
			// 
			this.m_pbOkNumeroReserva.Image = ((System.Drawing.Image)(resources.GetObject("m_pbOkNumeroReserva.Image")));
			this.m_pbOkNumeroReserva.Location = new System.Drawing.Point(8, 70);
			this.m_pbOkNumeroReserva.Name = "m_pbOkNumeroReserva";
			this.m_pbOkNumeroReserva.Size = new System.Drawing.Size(16, 16);
			this.m_pbOkNumeroReserva.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbOkNumeroReserva.TabIndex = 42;
			this.m_pbOkNumeroReserva.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbOkNumeroReserva, "Item Completo");
			this.m_pbOkNumeroReserva.Visible = false;
			// 
			// m_pbOkDataReserva
			// 
			this.m_pbOkDataReserva.Image = ((System.Drawing.Image)(resources.GetObject("m_pbOkDataReserva.Image")));
			this.m_pbOkDataReserva.Location = new System.Drawing.Point(8, 94);
			this.m_pbOkDataReserva.Name = "m_pbOkDataReserva";
			this.m_pbOkDataReserva.Size = new System.Drawing.Size(16, 16);
			this.m_pbOkDataReserva.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbOkDataReserva.TabIndex = 45;
			this.m_pbOkDataReserva.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbOkDataReserva, "Item Completo");
			this.m_pbOkDataReserva.Visible = false;
			// 
			// m_pbOkConsignatario
			// 
			this.m_pbOkConsignatario.Image = ((System.Drawing.Image)(resources.GetObject("m_pbOkConsignatario.Image")));
			this.m_pbOkConsignatario.Location = new System.Drawing.Point(8, 116);
			this.m_pbOkConsignatario.Name = "m_pbOkConsignatario";
			this.m_pbOkConsignatario.Size = new System.Drawing.Size(16, 16);
			this.m_pbOkConsignatario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbOkConsignatario.TabIndex = 47;
			this.m_pbOkConsignatario.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbOkConsignatario, "Item Completo");
			this.m_pbOkConsignatario.Visible = false;
			// 
			// m_pbOkDescricaoMercadorias
			// 
			this.m_pbOkDescricaoMercadorias.Image = ((System.Drawing.Image)(resources.GetObject("m_pbOkDescricaoMercadorias.Image")));
			this.m_pbOkDescricaoMercadorias.Location = new System.Drawing.Point(8, 140);
			this.m_pbOkDescricaoMercadorias.Name = "m_pbOkDescricaoMercadorias";
			this.m_pbOkDescricaoMercadorias.Size = new System.Drawing.Size(16, 16);
			this.m_pbOkDescricaoMercadorias.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbOkDescricaoMercadorias.TabIndex = 51;
			this.m_pbOkDescricaoMercadorias.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbOkDescricaoMercadorias, "Item Completo");
			this.m_pbOkDescricaoMercadorias.Visible = false;
			// 
			// m_pbOkClassificacaoTarifaria
			// 
			this.m_pbOkClassificacaoTarifaria.Image = ((System.Drawing.Image)(resources.GetObject("m_pbOkClassificacaoTarifaria.Image")));
			this.m_pbOkClassificacaoTarifaria.Location = new System.Drawing.Point(8, 164);
			this.m_pbOkClassificacaoTarifaria.Name = "m_pbOkClassificacaoTarifaria";
			this.m_pbOkClassificacaoTarifaria.Size = new System.Drawing.Size(16, 16);
			this.m_pbOkClassificacaoTarifaria.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbOkClassificacaoTarifaria.TabIndex = 53;
			this.m_pbOkClassificacaoTarifaria.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbOkClassificacaoTarifaria, "Item Completo");
			this.m_pbOkClassificacaoTarifaria.Visible = false;
			// 
			// m_pbOkVeiculoTransporte
			// 
			this.m_pbOkVeiculoTransporte.Image = ((System.Drawing.Image)(resources.GetObject("m_pbOkVeiculoTransporte.Image")));
			this.m_pbOkVeiculoTransporte.Location = new System.Drawing.Point(8, 188);
			this.m_pbOkVeiculoTransporte.Name = "m_pbOkVeiculoTransporte";
			this.m_pbOkVeiculoTransporte.Size = new System.Drawing.Size(16, 16);
			this.m_pbOkVeiculoTransporte.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbOkVeiculoTransporte.TabIndex = 55;
			this.m_pbOkVeiculoTransporte.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbOkVeiculoTransporte, "Item Completo");
			this.m_pbOkVeiculoTransporte.Visible = false;
			// 
			// m_pbOkDespachante
			// 
			this.m_pbOkDespachante.Image = ((System.Drawing.Image)(resources.GetObject("m_pbOkDespachante.Image")));
			this.m_pbOkDespachante.Location = new System.Drawing.Point(8, 212);
			this.m_pbOkDespachante.Name = "m_pbOkDespachante";
			this.m_pbOkDespachante.Size = new System.Drawing.Size(16, 16);
			this.m_pbOkDespachante.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbOkDespachante.TabIndex = 59;
			this.m_pbOkDespachante.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbOkDespachante, "Item Completo");
			this.m_pbOkDespachante.Visible = false;
			// 
			// m_pbNOKAgente
			// 
			this.m_pbNOKAgente.Image = ((System.Drawing.Image)(resources.GetObject("m_pbNOKAgente.Image")));
			this.m_pbNOKAgente.Location = new System.Drawing.Point(8, 46);
			this.m_pbNOKAgente.Name = "m_pbNOKAgente";
			this.m_pbNOKAgente.Size = new System.Drawing.Size(16, 16);
			this.m_pbNOKAgente.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbNOKAgente.TabIndex = 38;
			this.m_pbNOKAgente.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbNOKAgente, "Item não completo");
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
			// m_pbNOKNumeroReserva
			// 
			this.m_pbNOKNumeroReserva.Image = ((System.Drawing.Image)(resources.GetObject("m_pbNOKNumeroReserva.Image")));
			this.m_pbNOKNumeroReserva.Location = new System.Drawing.Point(8, 70);
			this.m_pbNOKNumeroReserva.Name = "m_pbNOKNumeroReserva";
			this.m_pbNOKNumeroReserva.Size = new System.Drawing.Size(16, 16);
			this.m_pbNOKNumeroReserva.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbNOKNumeroReserva.TabIndex = 41;
			this.m_pbNOKNumeroReserva.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbNOKNumeroReserva, "Item não completo");
			// 
			// m_pbNOKDataReserva
			// 
			this.m_pbNOKDataReserva.Image = ((System.Drawing.Image)(resources.GetObject("m_pbNOKDataReserva.Image")));
			this.m_pbNOKDataReserva.Location = new System.Drawing.Point(8, 94);
			this.m_pbNOKDataReserva.Name = "m_pbNOKDataReserva";
			this.m_pbNOKDataReserva.Size = new System.Drawing.Size(16, 16);
			this.m_pbNOKDataReserva.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbNOKDataReserva.TabIndex = 44;
			this.m_pbNOKDataReserva.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbNOKDataReserva, "Item não completo");
			// 
			// m_pbNOKConsignatario
			// 
			this.m_pbNOKConsignatario.Image = ((System.Drawing.Image)(resources.GetObject("m_pbNOKConsignatario.Image")));
			this.m_pbNOKConsignatario.Location = new System.Drawing.Point(8, 116);
			this.m_pbNOKConsignatario.Name = "m_pbNOKConsignatario";
			this.m_pbNOKConsignatario.Size = new System.Drawing.Size(16, 16);
			this.m_pbNOKConsignatario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbNOKConsignatario.TabIndex = 46;
			this.m_pbNOKConsignatario.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbNOKConsignatario, "Item não completo");
			// 
			// m_pbNOKDescricaoMercadorias
			// 
			this.m_pbNOKDescricaoMercadorias.Image = ((System.Drawing.Image)(resources.GetObject("m_pbNOKDescricaoMercadorias.Image")));
			this.m_pbNOKDescricaoMercadorias.Location = new System.Drawing.Point(8, 140);
			this.m_pbNOKDescricaoMercadorias.Name = "m_pbNOKDescricaoMercadorias";
			this.m_pbNOKDescricaoMercadorias.Size = new System.Drawing.Size(16, 16);
			this.m_pbNOKDescricaoMercadorias.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbNOKDescricaoMercadorias.TabIndex = 49;
			this.m_pbNOKDescricaoMercadorias.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbNOKDescricaoMercadorias, "Item não completo");
			// 
			// m_pbNOKClassificacaoTarifaria
			// 
			this.m_pbNOKClassificacaoTarifaria.Image = ((System.Drawing.Image)(resources.GetObject("m_pbNOKClassificacaoTarifaria.Image")));
			this.m_pbNOKClassificacaoTarifaria.Location = new System.Drawing.Point(8, 164);
			this.m_pbNOKClassificacaoTarifaria.Name = "m_pbNOKClassificacaoTarifaria";
			this.m_pbNOKClassificacaoTarifaria.Size = new System.Drawing.Size(16, 16);
			this.m_pbNOKClassificacaoTarifaria.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbNOKClassificacaoTarifaria.TabIndex = 52;
			this.m_pbNOKClassificacaoTarifaria.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbNOKClassificacaoTarifaria, "Item não completo");
			// 
			// m_pbNOKVeiculoTransporte
			// 
			this.m_pbNOKVeiculoTransporte.Image = ((System.Drawing.Image)(resources.GetObject("m_pbNOKVeiculoTransporte.Image")));
			this.m_pbNOKVeiculoTransporte.Location = new System.Drawing.Point(8, 188);
			this.m_pbNOKVeiculoTransporte.Name = "m_pbNOKVeiculoTransporte";
			this.m_pbNOKVeiculoTransporte.Size = new System.Drawing.Size(16, 16);
			this.m_pbNOKVeiculoTransporte.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbNOKVeiculoTransporte.TabIndex = 56;
			this.m_pbNOKVeiculoTransporte.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbNOKVeiculoTransporte, "Item não completo");
			// 
			// m_pbNOKDespachante
			// 
			this.m_pbNOKDespachante.Image = ((System.Drawing.Image)(resources.GetObject("m_pbNOKDespachante.Image")));
			this.m_pbNOKDespachante.Location = new System.Drawing.Point(8, 212);
			this.m_pbNOKDespachante.Name = "m_pbNOKDespachante";
			this.m_pbNOKDespachante.Size = new System.Drawing.Size(16, 16);
			this.m_pbNOKDespachante.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbNOKDespachante.TabIndex = 58;
			this.m_pbNOKDespachante.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbNOKDespachante, "Item não completo");
			// 
			// m_pbOkSiscomex
			// 
			this.m_pbOkSiscomex.Image = ((System.Drawing.Image)(resources.GetObject("m_pbOkSiscomex.Image")));
			this.m_pbOkSiscomex.Location = new System.Drawing.Point(8, 236);
			this.m_pbOkSiscomex.Name = "m_pbOkSiscomex";
			this.m_pbOkSiscomex.Size = new System.Drawing.Size(16, 16);
			this.m_pbOkSiscomex.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbOkSiscomex.TabIndex = 62;
			this.m_pbOkSiscomex.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbOkSiscomex, "Item Completo");
			this.m_pbOkSiscomex.Visible = false;
			// 
			// m_pbNOKSiscomex
			// 
			this.m_pbNOKSiscomex.Image = ((System.Drawing.Image)(resources.GetObject("m_pbNOKSiscomex.Image")));
			this.m_pbNOKSiscomex.Location = new System.Drawing.Point(8, 236);
			this.m_pbNOKSiscomex.Name = "m_pbNOKSiscomex";
			this.m_pbNOKSiscomex.Size = new System.Drawing.Size(16, 16);
			this.m_pbNOKSiscomex.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbNOKSiscomex.TabIndex = 61;
			this.m_pbNOKSiscomex.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbNOKSiscomex, "Item não completo");
			// 
			// m_pbNOKObservacoes
			// 
			this.m_pbNOKObservacoes.Image = ((System.Drawing.Image)(resources.GetObject("m_pbNOKObservacoes.Image")));
			this.m_pbNOKObservacoes.Location = new System.Drawing.Point(8, 260);
			this.m_pbNOKObservacoes.Name = "m_pbNOKObservacoes";
			this.m_pbNOKObservacoes.Size = new System.Drawing.Size(16, 16);
			this.m_pbNOKObservacoes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbNOKObservacoes.TabIndex = 66;
			this.m_pbNOKObservacoes.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbNOKObservacoes, "Item não completo");
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
			// frmFAssistenteInstrucoesEmbarque
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(458, 359);
			this.Controls.Add(this.m_gbFrame);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFAssistenteInstrucoesEmbarque";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Assistente";
			this.Load += new System.EventHandler(this.frmFAssistenteInstrucoesEmbarque_Load);
			this.Activated += new System.EventHandler(this.frmFAssistenteInstrucoesEmbarque_Activated);
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
			m_pbOkAgente.Visible = true;
			m_pbOkNumeroReserva.Visible = true;
			m_pbOkDataReserva.Visible = true;
			m_pbOkConsignatario.Visible = true;
			m_pbOkDescricaoMercadorias.Visible = true;
			m_pbOkClassificacaoTarifaria.Visible = true;
			m_pbOkVeiculoTransporte.Visible = true;
			m_pbOkDespachante.Visible = true;
			m_pbOkSiscomex.Visible = true;
			// NOK
			m_pbNOKNumero.Visible = false;
			m_pbNOKAgente.Visible = false;
			m_pbNOKNumeroReserva.Visible = false;
			m_pbNOKDataReserva.Visible = false;
			m_pbNOKConsignatario.Visible = false;
			m_pbNOKDescricaoMercadorias.Visible = false;
			m_pbNOKClassificacaoTarifaria.Visible = false;
			m_pbNOKVeiculoTransporte.Visible = false;
			m_pbNOKDespachante.Visible = false;
			m_pbNOKSiscomex.Visible = false;
		}
		#endregion

		#region Get & Set
		public void setaEstadoAssistente(bool bNumero, bool bAgente, bool bNumeroReserva, bool bDataReserva, bool bConsignatario, bool bDescricaoMercadorias, bool bClassificacaoTarifaria, bool bVeiculo, bool bDespachante, bool bSiscomex, bool bObservacoes)
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
				#region Agente
				if (bAgente)
				{
					m_pbNOKAgente.Visible = false;
					m_pbOkAgente.Visible = true;
					m_llAgente.LinkVisited = true;
					m_ttAssistente.SetToolTip(m_llAgente, "Item visitado");
				}
				#endregion
				#region Número Reserva
				if (bNumeroReserva)
				{
					m_pbNOKNumeroReserva.Visible = false;
					m_pbOkNumeroReserva.Visible = true;
					m_llNumeroReserva.LinkVisited = true;
					m_ttAssistente.SetToolTip(m_llNumeroReserva, "Item visitado");
				}
				#endregion
				#region Data Reserva
				if (bDataReserva)
				{
					m_pbNOKDataReserva.Visible = false;
					m_pbOkDataReserva.Visible = true;
					m_llDataReserva.LinkVisited = true;
					m_ttAssistente.SetToolTip(m_llDataReserva, "Item visitado");
				}
				#endregion
				#region Consignatário
				if (bConsignatario)
				{
					m_pbNOKConsignatario.Visible = false;
					m_pbOkConsignatario.Visible = true;
					m_llConsignatario.LinkVisited = true;
					m_ttAssistente.SetToolTip(m_llConsignatario, "Item visitado");
				}
				#endregion
				#region Descrição
				if (bDescricaoMercadorias)
				{
					m_pbNOKDescricaoMercadorias.Visible = false;
					m_pbOkDescricaoMercadorias.Visible = true;
					m_llDescricaoMercadorias.LinkVisited = true;
					m_ttAssistente.SetToolTip(m_llDescricaoMercadorias, "Item visitado");
				}
				#endregion
				#region Classificação
				if (bClassificacaoTarifaria)
				{
					m_pbNOKClassificacaoTarifaria.Visible = false;
					m_pbOkClassificacaoTarifaria.Visible = true;
					m_llClassificacaoTarifaria.LinkVisited = true;
					m_ttAssistente.SetToolTip(m_llClassificacaoTarifaria, "Item visitado");
				}
				#endregion
				#region Veículo
				if (bVeiculo)
				{
					m_pbNOKVeiculoTransporte.Visible = false;
					m_pbOkVeiculoTransporte.Visible = true;
					m_llVeiculoTransporte.LinkVisited = true;
					m_ttAssistente.SetToolTip(m_llVeiculoTransporte, "Item visitado");
				}
				#endregion
				#region Despachante
				if (bDespachante)
				{
					m_pbNOKDespachante.Visible = false;
					m_pbOkDespachante.Visible = true;
					m_llDespachante.LinkVisited = true;
					m_ttAssistente.SetToolTip(m_llDespachante, "Item visitado");
				}
				#endregion
				#region Siscomex
				if (bSiscomex)
				{
					m_pbNOKSiscomex.Visible = false;
					m_pbOkSiscomex.Visible = true;
					m_llSiscomex.LinkVisited = true;
					m_ttAssistente.SetToolTip(m_llSiscomex, "Item visitado");
				}
				#endregion
				#region Observações
				if (bObservacoes)
				{
					m_pbNOKObservacoes.Visible = false;
					m_pbOkObservacoes.Visible = true;
					m_llObservacoes.LinkVisited = true;
					m_ttAssistente.SetToolTip(m_llObservacoes, "Item visitado");
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
		private void frmFAssistenteInstrucoesEmbarque_Load(object sender, System.EventArgs e)
		{
			this.mostraCor();
		}
		#endregion
		#region Links
		#region Número
		private void m_llNumero_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			m_enumOrdem = ORDEM.NUMERO;
			OnCallSelecionaNumero();
			m_llNumero.LinkVisited = true;
			m_ttAssistente.SetToolTip(m_llNumero, "Item visitado");
			this.mostraCor();
			if (m_pbOkNumero.Visible && m_pbNOKAgente.Visible)
				m_llAgente_LinkClicked(sender, m_llevents_Args);
		}
		#endregion
		#region Agente
		private void m_llAgente_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			m_enumOrdem = ORDEM.AGENTE;
			OnCallSelecionaAgente();
			m_llAgente.LinkVisited = true;
			m_ttAssistente.SetToolTip(m_llAgente, "Item visitado");
			this.mostraCor();
			if (m_pbOkAgente.Visible && m_pbNOKNumeroReserva.Visible)
				m_llNumeroReserva_LinkClicked(sender, m_llevents_Args);
		}
		#endregion
		#region Número Reserva
		private void m_llNumeroReserva_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			m_enumOrdem = ORDEM.NUMERORESERVA;
			OnCallSelecionaNumeroReserva();
			m_llNumeroReserva.LinkVisited = true;
			m_ttAssistente.SetToolTip(m_llNumeroReserva, "Item visitado");
			this.mostraCor();
			if (m_pbOkNumeroReserva.Visible && m_pbNOKDataReserva.Visible)
				m_llDataReserva_LinkClicked(sender, m_llevents_Args);
		}
		#endregion
		#region Data Reserva
		private void m_llDataReserva_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			m_enumOrdem = ORDEM.DATARESERVA;
			OnCallSelecionaDataReserva();
			m_llDataReserva.LinkVisited = true;
			m_ttAssistente.SetToolTip(m_llDataReserva, "Item visitado");
			this.mostraCor();
			if (m_pbOkDataReserva.Visible && m_pbNOKConsignatario.Visible)
				m_llConsignatario_LinkClicked(sender, m_llevents_Args);
		}
		#endregion
		#region Consignatário
		private void m_llConsignatario_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			m_enumOrdem = ORDEM.CONSIGNATARIO;
			OnCallSelecionaConsignatario();
			m_llConsignatario.LinkVisited = true;
			m_ttAssistente.SetToolTip(m_llConsignatario, "Item visitado");
			this.mostraCor();
			if (m_pbOkConsignatario.Visible && m_pbNOKDescricaoMercadorias.Visible)
				m_llDescricaoMercadorias_LinkClicked(sender, m_llevents_Args);
		}
		#endregion
		#region Descrição Mercadorias
		private void m_llDescricaoMercadorias_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			m_enumOrdem = ORDEM.DESCRICAOMERCADORIAS;
			OnCallSelecionaDescricaoMercadorias();
			m_llDescricaoMercadorias.LinkVisited = true;
			m_ttAssistente.SetToolTip(m_llDescricaoMercadorias, "Item visitado");
			this.mostraCor();
			if (m_pbOkDescricaoMercadorias.Visible && m_pbNOKClassificacaoTarifaria.Visible)
				m_llClassificacaoTarifaria_LinkClicked(sender, m_llevents_Args);
		}
		#endregion
		#region Classificação Tarifária
		private void m_llClassificacaoTarifaria_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			m_enumOrdem = ORDEM.CLASSIFICACAOTARIFARIA;
			OnCallSelecionaClassificacaoTarifaria();
			m_llClassificacaoTarifaria.LinkVisited = true;
			m_ttAssistente.SetToolTip(m_llClassificacaoTarifaria, "Item visitado");
			this.mostraCor();
			if (m_pbOkClassificacaoTarifaria.Visible && m_pbNOKVeiculoTransporte.Visible)
				m_llVeiculoTransporte_LinkClicked(sender, m_llevents_Args);
		}
		#endregion
		#region Veículo Transporte
		private void m_llVeiculoTransporte_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			m_enumOrdem = ORDEM.VEICULO;
			OnCallSelecionaVeiculo();
			m_llVeiculoTransporte.LinkVisited = true;
			m_ttAssistente.SetToolTip(m_llVeiculoTransporte, "Item visitado");
			this.mostraCor();
			if (m_pbOkVeiculoTransporte.Visible && m_pbNOKDespachante.Visible)
				m_llDespachante_LinkClicked(sender, m_llevents_Args);
		}
		#endregion
		#region Despachante
		private void m_llDespachante_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			m_enumOrdem = ORDEM.DESPACHANTE;
			OnCallSelecionaDespachante();
			m_llDespachante.LinkVisited = true;
			m_ttAssistente.SetToolTip(m_llDespachante, "Item visitado");
			this.mostraCor();
			if (m_pbOkDespachante.Visible && m_pbNOKSiscomex.Visible)
				m_llSiscomex_LinkClicked(sender, m_llevents_Args);
		}
		#endregion
		#region Siscomex
		private void m_llSiscomex_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			m_enumOrdem = ORDEM.SISCOMEX;
			OnCallSelecionaSiscomex();
			m_llSiscomex.LinkVisited = true;
			m_ttAssistente.SetToolTip(m_llSiscomex, "Item visitado");
			this.mostraCor();
			if (m_pbOkSiscomex.Visible && m_pbNOKObservacoes.Visible)
				m_llObservacoes_LinkClicked(sender, m_llevents_Args);
		}
		#endregion
		#region Observações
		private void m_llObservacoes_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			m_enumOrdem = ORDEM.OBSERVACOES;
			OnCallSelecionaObservacoes();
			m_llObservacoes.LinkVisited = true;
			m_ttAssistente.SetToolTip(m_llObservacoes, "Item visitado");
			this.mostraCor();
		}
		#endregion
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
		private void frmFAssistenteInstrucoesEmbarque_Activated(object sender, System.EventArgs e)
		{
			if (m_bLoad == true)
			{
				m_bLoad = false;
				if (m_bComecarAssistente)
				{
					if (m_pbNOKNumero.Visible)
						this.m_llNumero_LinkClicked(sender, m_llevents_Args);
					else if (m_pbNOKAgente.Visible)
						this.m_llAgente_LinkClicked(sender, m_llevents_Args);
					else if (m_pbNOKNumeroReserva.Visible)
						this.m_llNumeroReserva_LinkClicked(sender, m_llevents_Args);
					else if (m_pbNOKDataReserva.Visible)
						this.m_llDataReserva_LinkClicked(sender, m_llevents_Args);
					else if (m_pbNOKConsignatario.Visible)
						this.m_llConsignatario_LinkClicked(sender, m_llevents_Args);
					else if (m_pbNOKDescricaoMercadorias.Visible)
						this.m_llDescricaoMercadorias_LinkClicked(sender, m_llevents_Args);
					else if (m_pbNOKClassificacaoTarifaria.Visible)
						this.m_llClassificacaoTarifaria_LinkClicked(sender, m_llevents_Args);
					else if (m_pbNOKVeiculoTransporte.Visible)
						this.m_llVeiculoTransporte_LinkClicked(sender, m_llevents_Args);
					else if (m_pbNOKDespachante.Visible)
						this.m_llDespachante_LinkClicked(sender, m_llevents_Args);
					else if (m_pbNOKSiscomex.Visible)
						this.m_llSiscomex_LinkClicked(sender, m_llevents_Args);
					else if (m_pbNOKObservacoes.Visible)
						this.m_llObservacoes_LinkClicked(sender, m_llevents_Args);
				}
			}
		}
		#endregion
		#endregion
	}
}
