using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlControladoraMensagens.Forms
{
	/// <summary>
	/// Summary description for frmMessages.
	/// </summary>
	public class frmMessages : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate void delCallCarregaConfiguracaoCores(out System.Drawing.Color clrScheduleContratosCambio,out System.Drawing.Color clrScheduleDeadlines,out System.Drawing.Color clrSchedulePersonalized);
			public delegate void delCallCarregaConfiguracao(out System.DateTime dtMessagesSelectStart,out System.DateTime dtMessagesSelectEnd,out bool bMessagesShowDeadlines,out bool bMessagesShowContratosCambio,out bool bMessagesShowPersonalized,out bool bMessagesShowed,out bool bMessagesShow,out Intervalo enumIntervalo);
			public delegate void delCallSalvaConfiguracao(System.DateTime dtMessagesSelectStart,System.DateTime dtMessagesSelectEnd,bool bMessagesShowDeadlines,bool bMessagesShowContratosCambio,bool bMessagesShowPersonalized,bool bMessagesShowed,bool bMessagesShow,Intervalo enumIntervalo);
			public delegate void delCallMessagesRefresh(ref System.Windows.Forms.ListView lvMessages);
			public delegate bool delCallMessageNew();
			public delegate bool delCallShowMessage(string strIdMessage);
			public delegate bool delCallMessageDelete(ref System.Collections.ArrayList arlMessages);
		#endregion
		#region Events
			public event delCallCarregaConfiguracaoCores eCallCarregaConfiguracaoCores;
			public event delCallCarregaConfiguracao eCallCarregaConfiguracao;
			public event delCallSalvaConfiguracao eCallSalvaConfiguracao;
			public event delCallMessagesRefresh eCallMessagesRefresh;
			public event delCallMessageNew eCallMessageNew;
			public event delCallShowMessage eCallShowMessage;
			public event delCallMessageDelete eCallMessageDelete;
		#endregion
		#region Events Methods
			protected virtual void OnCallCarregaConfiguracaoCores()
			{
				if (eCallCarregaConfiguracaoCores != null)
				{
					System.Drawing.Color clrScheduleContratosCambio,clrScheduleDeadlines,clrSchedulePersonalized;
					eCallCarregaConfiguracaoCores(out clrScheduleContratosCambio,out clrScheduleDeadlines,out clrSchedulePersonalized);
					m_ckMessageTypeContratosCambio.ForeColor = clrScheduleContratosCambio;
					m_ckMessageTypeDeadline.ForeColor = clrScheduleDeadlines;
					m_ckMessageTypePersonalized.ForeColor = clrSchedulePersonalized;
				}
			}

			protected virtual void OnCallCarregaConfiguracao()
			{
				if (eCallCarregaConfiguracao != null)
				{
					System.DateTime dtMessagesSelectStart,dtMessagesSelectEnd;
					bool bMessagesShowDeadlines,bMessagesShowContratosCambio,bMessagesShowPersonalized,bMessagesShowed,bMessagesShow;
					Intervalo enumIntervalo;
					eCallCarregaConfiguracao(out dtMessagesSelectStart,out dtMessagesSelectEnd,out bMessagesShowDeadlines,out bMessagesShowContratosCambio,out bMessagesShowPersonalized,out bMessagesShowed,out bMessagesShow,out enumIntervalo);

					m_mcDate.SelectionStart = dtMessagesSelectStart;
					m_mcDate.SelectionEnd = dtMessagesSelectEnd;
					m_ckMessageTypeDeadline.Checked = bMessagesShowDeadlines;
					m_ckMessageTypeContratosCambio.Checked = bMessagesShowContratosCambio;
					m_ckMessageTypePersonalized.Checked = bMessagesShowPersonalized;
					m_ckMessagesShowed.Checked = bMessagesShowed;
					m_ckMessagesShow.Checked = bMessagesShow;
					switch(enumIntervalo)
					{
						case Intervalo.Dia:
							m_rbPeriodoDia.Checked = true;
							break;
						case Intervalo.Semana:
							m_rbPeriodoSemana.Checked = true;
							break;
						case Intervalo.Mes:
							m_rbPeriodoMes.Checked = true;
							break;
						case Intervalo.Ano:
							m_rbPeriodoAno.Checked = true;
							break;
						case Intervalo.Tudo:
							m_rbPeriodoTodasDatas.Checked = true;
							break;
					}
				}
			}

			protected virtual void OnCallSalvaConfiguracao()
			{
				if (eCallSalvaConfiguracao != null)
				{
					Intervalo enumIntervalo = Intervalo.Dia;
					if (m_rbPeriodoDia.Checked)
						enumIntervalo = Intervalo.Dia;
					if (m_rbPeriodoSemana.Checked)
						enumIntervalo = Intervalo.Semana;
					if (m_rbPeriodoMes.Checked)
						enumIntervalo = Intervalo.Mes;
					if (m_rbPeriodoAno.Checked)
						enumIntervalo = Intervalo.Ano;
					if (m_rbPeriodoTodasDatas.Checked)
						enumIntervalo = Intervalo.Tudo;
					eCallSalvaConfiguracao(m_mcDate.SelectionStart,m_mcDate.SelectionEnd,m_ckMessageTypeDeadline.Checked,m_ckMessageTypeContratosCambio.Checked,m_ckMessageTypePersonalized.Checked,m_ckMessagesShowed.Checked,m_ckMessagesShow.Checked,enumIntervalo);
				}
			}

			public virtual void OnCallMessagesRefresh()
			{
				if (eCallMessagesRefresh != null)
					eCallMessagesRefresh(ref m_lvMessages);
			}

			public virtual bool OnCallMessageNew()
			{
				bool bReturn = false;
				if (eCallMessageNew != null)
					bReturn = eCallMessageNew();
				return(bReturn);
			}

			public virtual bool OnCallShowMessage()
			{
				bool bReturn = false;
				if ((eCallShowMessage != null) && (m_lvMessages.SelectedItems.Count > 0))
					bReturn = eCallShowMessage(m_lvMessages.SelectedItems[0].Tag.ToString());
				return(bReturn);
			}

			public virtual bool OnCallMessageDelete()
			{
				bool bReturn = false;
				if ((eCallMessageDelete != null) && (m_lvMessages.SelectedItems.Count > 0))
				{
					System.Collections.ArrayList arlMessages = new ArrayList();
					foreach(System.Windows.Forms.ListViewItem lviItemSelected in m_lvMessages.SelectedItems)
						arlMessages.Add(lviItemSelected.Tag);
					bReturn = eCallMessageDelete(ref arlMessages);
				}
				return(bReturn);
			}
		#endregion

		#region Atributes
			private bool m_bActivated = true;
			private System.Windows.Forms.GroupBox m_gbGeral;
			private System.Windows.Forms.GroupBox m_gbMensagens;
			private System.Windows.Forms.GroupBox m_gbFiltro;
			private System.Windows.Forms.GroupBox m_gbMessagesType;
			private System.Windows.Forms.CheckBox m_ckMessageTypeDeadline;
			private System.Windows.Forms.CheckBox m_ckMessageTypeContratosCambio;
			private System.Windows.Forms.CheckBox m_ckMessageTypePersonalized;
			private System.Windows.Forms.GroupBox m_gbOpcoes;
			private System.Windows.Forms.CheckBox m_ckMessagesShowed;
			private System.Windows.Forms.MonthCalendar m_mcDate;
			private System.Windows.Forms.ListView m_lvMessages;
			private System.Windows.Forms.ColumnHeader m_colhDate;
			private System.Windows.Forms.ColumnHeader m_colhMessage;
		private System.Windows.Forms.CheckBox m_ckMessagesShow;
		private System.Windows.Forms.Button m_btExcluir;
		private System.Windows.Forms.Button m_btEditar;
		private System.Windows.Forms.Button m_btNova;
		private System.Windows.Forms.GroupBox m_gbCalendario;
		private System.Windows.Forms.GroupBox m_gbPeriodo;
		private System.Windows.Forms.RadioButton m_rbPeriodoDia;
		private System.Windows.Forms.GroupBox m_gbFiltros;
		private System.Windows.Forms.RadioButton m_rbPeriodoSemana;
		private System.Windows.Forms.RadioButton m_rbPeriodoMes;
		private System.Windows.Forms.RadioButton m_rbPeriodoAno;
		private System.Windows.Forms.RadioButton m_rbPeriodoTodasDatas;
			private System.ComponentModel.Container components = null;
		#endregion
		#region Constructors and Destructors
			public frmMessages()
			{
				InitializeComponent();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMessages));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_gbFiltros = new System.Windows.Forms.GroupBox();
			this.m_gbOpcoes = new System.Windows.Forms.GroupBox();
			this.m_ckMessagesShow = new System.Windows.Forms.CheckBox();
			this.m_ckMessagesShowed = new System.Windows.Forms.CheckBox();
			this.m_gbMessagesType = new System.Windows.Forms.GroupBox();
			this.m_ckMessageTypePersonalized = new System.Windows.Forms.CheckBox();
			this.m_ckMessageTypeContratosCambio = new System.Windows.Forms.CheckBox();
			this.m_ckMessageTypeDeadline = new System.Windows.Forms.CheckBox();
			this.m_gbFiltro = new System.Windows.Forms.GroupBox();
			this.m_gbPeriodo = new System.Windows.Forms.GroupBox();
			this.m_rbPeriodoTodasDatas = new System.Windows.Forms.RadioButton();
			this.m_rbPeriodoAno = new System.Windows.Forms.RadioButton();
			this.m_rbPeriodoMes = new System.Windows.Forms.RadioButton();
			this.m_rbPeriodoSemana = new System.Windows.Forms.RadioButton();
			this.m_rbPeriodoDia = new System.Windows.Forms.RadioButton();
			this.m_gbCalendario = new System.Windows.Forms.GroupBox();
			this.m_mcDate = new System.Windows.Forms.MonthCalendar();
			this.m_gbMensagens = new System.Windows.Forms.GroupBox();
			this.m_btExcluir = new System.Windows.Forms.Button();
			this.m_btEditar = new System.Windows.Forms.Button();
			this.m_btNova = new System.Windows.Forms.Button();
			this.m_lvMessages = new System.Windows.Forms.ListView();
			this.m_colhDate = new System.Windows.Forms.ColumnHeader();
			this.m_colhMessage = new System.Windows.Forms.ColumnHeader();
			this.m_gbGeral.SuspendLayout();
			this.m_gbFiltros.SuspendLayout();
			this.m_gbOpcoes.SuspendLayout();
			this.m_gbMessagesType.SuspendLayout();
			this.m_gbFiltro.SuspendLayout();
			this.m_gbPeriodo.SuspendLayout();
			this.m_gbCalendario.SuspendLayout();
			this.m_gbMensagens.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbGeral.Controls.Add(this.m_gbFiltros);
			this.m_gbGeral.Controls.Add(this.m_gbFiltro);
			this.m_gbGeral.Controls.Add(this.m_gbMensagens);
			this.m_gbGeral.Location = new System.Drawing.Point(4, -2);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(483, 674);
			this.m_gbGeral.TabIndex = 0;
			this.m_gbGeral.TabStop = false;
			// 
			// m_gbFiltros
			// 
			this.m_gbFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFiltros.Controls.Add(this.m_gbOpcoes);
			this.m_gbFiltros.Controls.Add(this.m_gbMessagesType);
			this.m_gbFiltros.Location = new System.Drawing.Point(4, 207);
			this.m_gbFiltros.Name = "m_gbFiltros";
			this.m_gbFiltros.Size = new System.Drawing.Size(476, 85);
			this.m_gbFiltros.TabIndex = 3;
			this.m_gbFiltros.TabStop = false;
			// 
			// m_gbOpcoes
			// 
			this.m_gbOpcoes.Controls.Add(this.m_ckMessagesShow);
			this.m_gbOpcoes.Controls.Add(this.m_ckMessagesShowed);
			this.m_gbOpcoes.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbOpcoes.Location = new System.Drawing.Point(8, 6);
			this.m_gbOpcoes.Name = "m_gbOpcoes";
			this.m_gbOpcoes.Size = new System.Drawing.Size(208, 74);
			this.m_gbOpcoes.TabIndex = 2;
			this.m_gbOpcoes.TabStop = false;
			this.m_gbOpcoes.Text = "Vencimento";
			// 
			// m_ckMessagesShow
			// 
			this.m_ckMessagesShow.Location = new System.Drawing.Point(8, 34);
			this.m_ckMessagesShow.Name = "m_ckMessagesShow";
			this.m_ckMessagesShow.Size = new System.Drawing.Size(160, 16);
			this.m_ckMessagesShow.TabIndex = 3;
			this.m_ckMessagesShow.Text = "A Vencer";
			this.m_ckMessagesShow.CheckedChanged += new System.EventHandler(this.m_ckMessagesShow_CheckedChanged);
			// 
			// m_ckMessagesShowed
			// 
			this.m_ckMessagesShowed.Location = new System.Drawing.Point(8, 18);
			this.m_ckMessagesShowed.Name = "m_ckMessagesShowed";
			this.m_ckMessagesShowed.Size = new System.Drawing.Size(176, 16);
			this.m_ckMessagesShowed.TabIndex = 1;
			this.m_ckMessagesShowed.Text = "Vencidas";
			this.m_ckMessagesShowed.CheckedChanged += new System.EventHandler(this.m_ckMessagesShowed_CheckedChanged);
			// 
			// m_gbMessagesType
			// 
			this.m_gbMessagesType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbMessagesType.Controls.Add(this.m_ckMessageTypePersonalized);
			this.m_gbMessagesType.Controls.Add(this.m_ckMessageTypeContratosCambio);
			this.m_gbMessagesType.Controls.Add(this.m_ckMessageTypeDeadline);
			this.m_gbMessagesType.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbMessagesType.Location = new System.Drawing.Point(218, 7);
			this.m_gbMessagesType.Name = "m_gbMessagesType";
			this.m_gbMessagesType.Size = new System.Drawing.Size(254, 72);
			this.m_gbMessagesType.TabIndex = 1;
			this.m_gbMessagesType.TabStop = false;
			this.m_gbMessagesType.Text = "Categoria";
			// 
			// m_ckMessageTypePersonalized
			// 
			this.m_ckMessageTypePersonalized.Location = new System.Drawing.Point(8, 48);
			this.m_ckMessageTypePersonalized.Name = "m_ckMessageTypePersonalized";
			this.m_ckMessageTypePersonalized.Size = new System.Drawing.Size(144, 16);
			this.m_ckMessageTypePersonalized.TabIndex = 2;
			this.m_ckMessageTypePersonalized.Text = "Personalizadas";
			this.m_ckMessageTypePersonalized.CheckedChanged += new System.EventHandler(this.m_ckMessageTypePersonalized_CheckedChanged);
			// 
			// m_ckMessageTypeContratosCambio
			// 
			this.m_ckMessageTypeContratosCambio.Location = new System.Drawing.Point(8, 32);
			this.m_ckMessageTypeContratosCambio.Name = "m_ckMessageTypeContratosCambio";
			this.m_ckMessageTypeContratosCambio.Size = new System.Drawing.Size(144, 16);
			this.m_ckMessageTypeContratosCambio.TabIndex = 1;
			this.m_ckMessageTypeContratosCambio.Text = "Contratos Câmbio";
			this.m_ckMessageTypeContratosCambio.CheckedChanged += new System.EventHandler(this.m_ckMessageTypeContratosCambio_CheckedChanged);
			// 
			// m_ckMessageTypeDeadline
			// 
			this.m_ckMessageTypeDeadline.Location = new System.Drawing.Point(8, 16);
			this.m_ckMessageTypeDeadline.Name = "m_ckMessageTypeDeadline";
			this.m_ckMessageTypeDeadline.Size = new System.Drawing.Size(168, 16);
			this.m_ckMessageTypeDeadline.TabIndex = 0;
			this.m_ckMessageTypeDeadline.Text = "Datas Limites (DeadLines)";
			this.m_ckMessageTypeDeadline.CheckedChanged += new System.EventHandler(this.m_ckMessageTypeDeadline_CheckedChanged);
			// 
			// m_gbFiltro
			// 
			this.m_gbFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFiltro.Controls.Add(this.m_gbPeriodo);
			this.m_gbFiltro.Controls.Add(this.m_gbCalendario);
			this.m_gbFiltro.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbFiltro.Location = new System.Drawing.Point(5, 8);
			this.m_gbFiltro.Name = "m_gbFiltro";
			this.m_gbFiltro.Size = new System.Drawing.Size(475, 200);
			this.m_gbFiltro.TabIndex = 1;
			this.m_gbFiltro.TabStop = false;
			// 
			// m_gbPeriodo
			// 
			this.m_gbPeriodo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbPeriodo.Controls.Add(this.m_rbPeriodoTodasDatas);
			this.m_gbPeriodo.Controls.Add(this.m_rbPeriodoAno);
			this.m_gbPeriodo.Controls.Add(this.m_rbPeriodoMes);
			this.m_gbPeriodo.Controls.Add(this.m_rbPeriodoSemana);
			this.m_gbPeriodo.Controls.Add(this.m_rbPeriodoDia);
			this.m_gbPeriodo.Location = new System.Drawing.Point(218, 7);
			this.m_gbPeriodo.Name = "m_gbPeriodo";
			this.m_gbPeriodo.Size = new System.Drawing.Size(254, 185);
			this.m_gbPeriodo.TabIndex = 2;
			this.m_gbPeriodo.TabStop = false;
			this.m_gbPeriodo.Text = "Período";
			// 
			// m_rbPeriodoTodasDatas
			// 
			this.m_rbPeriodoTodasDatas.Location = new System.Drawing.Point(8, 80);
			this.m_rbPeriodoTodasDatas.Name = "m_rbPeriodoTodasDatas";
			this.m_rbPeriodoTodasDatas.Size = new System.Drawing.Size(136, 16);
			this.m_rbPeriodoTodasDatas.TabIndex = 4;
			this.m_rbPeriodoTodasDatas.Text = "Todas as Datas";
			this.m_rbPeriodoTodasDatas.CheckedChanged += new System.EventHandler(this.m_rbPeriodoTodasDatas_CheckedChanged);
			// 
			// m_rbPeriodoAno
			// 
			this.m_rbPeriodoAno.Location = new System.Drawing.Point(8, 64);
			this.m_rbPeriodoAno.Name = "m_rbPeriodoAno";
			this.m_rbPeriodoAno.Size = new System.Drawing.Size(136, 16);
			this.m_rbPeriodoAno.TabIndex = 3;
			this.m_rbPeriodoAno.Text = "Ano";
			this.m_rbPeriodoAno.CheckedChanged += new System.EventHandler(this.m_rbPeriodoAno_CheckedChanged);
			// 
			// m_rbPeriodoMes
			// 
			this.m_rbPeriodoMes.Location = new System.Drawing.Point(8, 48);
			this.m_rbPeriodoMes.Name = "m_rbPeriodoMes";
			this.m_rbPeriodoMes.Size = new System.Drawing.Size(136, 16);
			this.m_rbPeriodoMes.TabIndex = 2;
			this.m_rbPeriodoMes.Text = "Mês";
			this.m_rbPeriodoMes.CheckedChanged += new System.EventHandler(this.m_rbPeriodoMes_CheckedChanged);
			// 
			// m_rbPeriodoSemana
			// 
			this.m_rbPeriodoSemana.Location = new System.Drawing.Point(8, 32);
			this.m_rbPeriodoSemana.Name = "m_rbPeriodoSemana";
			this.m_rbPeriodoSemana.Size = new System.Drawing.Size(136, 16);
			this.m_rbPeriodoSemana.TabIndex = 1;
			this.m_rbPeriodoSemana.Text = "Semana";
			this.m_rbPeriodoSemana.CheckedChanged += new System.EventHandler(this.m_rbPeriodoSemana_CheckedChanged);
			// 
			// m_rbPeriodoDia
			// 
			this.m_rbPeriodoDia.Checked = true;
			this.m_rbPeriodoDia.Location = new System.Drawing.Point(7, 16);
			this.m_rbPeriodoDia.Name = "m_rbPeriodoDia";
			this.m_rbPeriodoDia.Size = new System.Drawing.Size(136, 16);
			this.m_rbPeriodoDia.TabIndex = 0;
			this.m_rbPeriodoDia.TabStop = true;
			this.m_rbPeriodoDia.Text = "Dia";
			this.m_rbPeriodoDia.CheckedChanged += new System.EventHandler(this.m_rbPeriodoDia_CheckedChanged);
			// 
			// m_gbCalendario
			// 
			this.m_gbCalendario.Controls.Add(this.m_mcDate);
			this.m_gbCalendario.Location = new System.Drawing.Point(8, 7);
			this.m_gbCalendario.Name = "m_gbCalendario";
			this.m_gbCalendario.Size = new System.Drawing.Size(208, 184);
			this.m_gbCalendario.TabIndex = 1;
			this.m_gbCalendario.TabStop = false;
			this.m_gbCalendario.Text = "Calendário";
			// 
			// m_mcDate
			// 
			this.m_mcDate.Location = new System.Drawing.Point(8, 16);
			this.m_mcDate.Name = "m_mcDate";
			this.m_mcDate.TabIndex = 0;
			this.m_mcDate.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.m_mcDate_DateSelected);
			// 
			// m_gbMensagens
			// 
			this.m_gbMensagens.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbMensagens.Controls.Add(this.m_btExcluir);
			this.m_gbMensagens.Controls.Add(this.m_btEditar);
			this.m_gbMensagens.Controls.Add(this.m_btNova);
			this.m_gbMensagens.Controls.Add(this.m_lvMessages);
			this.m_gbMensagens.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbMensagens.Location = new System.Drawing.Point(5, 292);
			this.m_gbMensagens.Name = "m_gbMensagens";
			this.m_gbMensagens.Size = new System.Drawing.Size(475, 372);
			this.m_gbMensagens.TabIndex = 0;
			this.m_gbMensagens.TabStop = false;
			this.m_gbMensagens.Text = "Mensagens";
			// 
			// m_btExcluir
			// 
			this.m_btExcluir.BackColor = System.Drawing.SystemColors.Control;
			this.m_btExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btExcluir.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btExcluir.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btExcluir.Image = ((System.Drawing.Image)(resources.GetObject("m_btExcluir.Image")));
			this.m_btExcluir.Location = new System.Drawing.Point(72, 17);
			this.m_btExcluir.Name = "m_btExcluir";
			this.m_btExcluir.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btExcluir.Size = new System.Drawing.Size(25, 25);
			this.m_btExcluir.TabIndex = 2;
			this.m_btExcluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_btExcluir.Click += new System.EventHandler(this.m_btExcluir_Click);
			// 
			// m_btEditar
			// 
			this.m_btEditar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btEditar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btEditar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btEditar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btEditar.Image = ((System.Drawing.Image)(resources.GetObject("m_btEditar.Image")));
			this.m_btEditar.Location = new System.Drawing.Point(40, 17);
			this.m_btEditar.Name = "m_btEditar";
			this.m_btEditar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btEditar.Size = new System.Drawing.Size(25, 25);
			this.m_btEditar.TabIndex = 1;
			this.m_btEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_btEditar.Click += new System.EventHandler(this.m_btEditar_Click);
			// 
			// m_btNova
			// 
			this.m_btNova.BackColor = System.Drawing.SystemColors.Control;
			this.m_btNova.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btNova.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btNova.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btNova.Image = ((System.Drawing.Image)(resources.GetObject("m_btNova.Image")));
			this.m_btNova.Location = new System.Drawing.Point(8, 17);
			this.m_btNova.Name = "m_btNova";
			this.m_btNova.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btNova.Size = new System.Drawing.Size(25, 25);
			this.m_btNova.TabIndex = 0;
			this.m_btNova.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_btNova.Click += new System.EventHandler(this.m_btNova_Click);
			// 
			// m_lvMessages
			// 
			this.m_lvMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lvMessages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						   this.m_colhDate,
																						   this.m_colhMessage});
			this.m_lvMessages.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lvMessages.FullRowSelect = true;
			this.m_lvMessages.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.m_lvMessages.HideSelection = false;
			this.m_lvMessages.Location = new System.Drawing.Point(8, 48);
			this.m_lvMessages.MultiSelect = false;
			this.m_lvMessages.Name = "m_lvMessages";
			this.m_lvMessages.Size = new System.Drawing.Size(460, 316);
			this.m_lvMessages.TabIndex = 3;
			this.m_lvMessages.View = System.Windows.Forms.View.Details;
			this.m_lvMessages.DoubleClick += new System.EventHandler(this.m_lvMessages_DoubleClick);
			// 
			// m_colhDate
			// 
			this.m_colhDate.Text = "Data";
			this.m_colhDate.Width = 115;
			// 
			// m_colhMessage
			// 
			this.m_colhMessage.Text = "Mensagem";
			this.m_colhMessage.Width = 330;
			// 
			// frmMessages
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(490, 680);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmMessages";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Agenda";
			this.Load += new System.EventHandler(this.frmMessages_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbFiltros.ResumeLayout(false);
			this.m_gbOpcoes.ResumeLayout(false);
			this.m_gbMessagesType.ResumeLayout(false);
			this.m_gbFiltro.ResumeLayout(false);
			this.m_gbPeriodo.ResumeLayout(false);
			this.m_gbCalendario.ResumeLayout(false);
			this.m_gbMensagens.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmMessages_Load(object sender, System.EventArgs e)
				{
					vShowColor();
					OnCallCarregaConfiguracaoCores();
					m_bActivated = false;
					OnCallCarregaConfiguracao();
					m_bActivated = true;
					OnCallMessagesRefresh();
					vResize();
				}
			#endregion
			#region Month Calendar
				private void m_mcDate_DateSelected(object sender, System.Windows.Forms.DateRangeEventArgs e)
				{
					if (m_bActivated)
					{
						OnCallSalvaConfiguracao();
						OnCallMessagesRefresh();
					}
				}
			#endregion
			#region Check Boxes
				private void m_ckMessageTypeDeadline_CheckedChanged(object sender, System.EventArgs e)
				{
					if (m_bActivated)
					{
						OnCallSalvaConfiguracao();
						OnCallMessagesRefresh();
					}
				}
				private void m_ckMessageTypeContratosCambio_CheckedChanged(object sender, System.EventArgs e)
				{
					if (m_bActivated)
					{
						OnCallSalvaConfiguracao();
						OnCallMessagesRefresh();
					}
				}

				private void m_ckMessageTypePersonalized_CheckedChanged(object sender, System.EventArgs e)
				{
					if (m_bActivated)
					{
						OnCallSalvaConfiguracao();
						OnCallMessagesRefresh();
					}
				}

				private void m_ckMessagesShowed_CheckedChanged(object sender, System.EventArgs e)
				{
					if (m_bActivated)
					{
						OnCallSalvaConfiguracao();
						OnCallMessagesRefresh();
					}
				}

				private void m_ckMessagesShowing_CheckedChanged(object sender, System.EventArgs e)
				{
					if (m_bActivated)
					{
						OnCallSalvaConfiguracao();
						OnCallMessagesRefresh();
					}
				}

				private void m_ckMessagesShow_CheckedChanged(object sender, System.EventArgs e)
				{
					if (m_bActivated)
					{
						OnCallSalvaConfiguracao();
						OnCallMessagesRefresh();
					}
				}

				private void m_ckMessagesAll_CheckedChanged(object sender, System.EventArgs e)
				{
					if (m_bActivated)
					{
						OnCallSalvaConfiguracao();
						OnCallMessagesRefresh();
					}
				}
			#endregion
			#region ListView
				private void m_lvMessages_DoubleClick(object sender, System.EventArgs e)
				{
					if (OnCallShowMessage())
						OnCallMessagesRefresh();
				}
			#endregion
			#region RadioButtons
				private void m_rbPeriodoDia_CheckedChanged(object sender, System.EventArgs e)
				{
					if ((m_bActivated) && (m_rbPeriodoDia.Checked))
					{
						OnCallSalvaConfiguracao();
						OnCallMessagesRefresh();
					}
				}

				private void m_rbPeriodoSemana_CheckedChanged(object sender, System.EventArgs e)
				{
					if ((m_bActivated) && (m_rbPeriodoSemana.Checked))
					{
						OnCallSalvaConfiguracao();
						OnCallMessagesRefresh();
					}
				}

				private void m_rbPeriodoMes_CheckedChanged(object sender, System.EventArgs e)
				{
					if ((m_bActivated) && (m_rbPeriodoMes.Checked))
					{
						OnCallSalvaConfiguracao();
						OnCallMessagesRefresh();
					}
				}

				private void m_rbPeriodoAno_CheckedChanged(object sender, System.EventArgs e)
				{
					if ((m_bActivated) && (m_rbPeriodoAno.Checked))
					{
						OnCallSalvaConfiguracao();
						OnCallMessagesRefresh();
					}
				}

				private void m_rbPeriodoTodasDatas_CheckedChanged(object sender, System.EventArgs e)
				{
					if ((m_bActivated) && (m_rbPeriodoTodasDatas.Checked))
					{
						OnCallSalvaConfiguracao();
						OnCallMessagesRefresh();
					}
				}
			#endregion
			#region Botoes
				private void m_btNova_Click(object sender, System.EventArgs e)
				{
					if (OnCallMessageNew())
						OnCallMessagesRefresh();
				}

				private void m_btEditar_Click(object sender, System.EventArgs e)
				{
					if (OnCallShowMessage())
						OnCallMessagesRefresh();
				}

				private void m_btExcluir_Click(object sender, System.EventArgs e)
				{
					if (OnCallMessageDelete())
						OnCallMessagesRefresh();
				}
			#endregion
		#endregion

		#region Cores
			private void vShowColor()
			{
				System.Windows.Forms.Control ctrControleChild;
				for (int nCont = 0 ;nCont < this.Controls.Count; nCont++)
				{
					ctrControleChild = this.Controls[nCont];
					vPaintControl(ref ctrControleChild,clsControladoraMensagens.BackColor);
				}
			}

			private void vPaintControl(ref System.Windows.Forms.Control ctrControle,System.Drawing.Color clrBackColor)
			{
				switch(ctrControle.GetType().ToString())
				{
					case "mdlComponentesGraficos.ListView":
					case "System.Windows.Forms.ListView":
					case "System.Windows.Forms.TreeView":
					case "mdlComponentesGraficos.TextBox":
					case "System.Windows.Forms.MonthCalendar":
						break;

					default:
						ctrControle.BackColor = clrBackColor;
						break;
				}
				System.Windows.Forms.Control ctrControleChild;
				for (int nCont = 0 ;nCont < ctrControle.Controls.Count; nCont++)
				{
					ctrControleChild = ctrControle.Controls[nCont];
					vPaintControl(ref ctrControleChild,clrBackColor);
				}
			}
		#endregion
		#region Resize
			private void vResize()
			{
				this.Width = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Size.Width;
				this.Height = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Size.Height;

				// Cols
				m_lvMessages.Columns[1].Width = m_lvMessages.Width - (m_lvMessages.Columns[0].Width + 20);
			}
		#endregion
	}
}
