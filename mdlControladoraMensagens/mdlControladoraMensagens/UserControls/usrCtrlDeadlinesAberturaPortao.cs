using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace mdlControladoraMensagens.UserControls
{
	/// <summary>
	/// Summary description for usrCtrlDeadlinesAberturaPortao.
	/// </summary>
	public class usrCtrlDeadlinesAberturaPortao : System.Windows.Forms.UserControl
	{
		#region Delegates
			public delegate void delCallLoadMessageBase(int nIdSubTypeDeadline,out string strMessageBase);
			public delegate bool delCallShowMessageBase(int nIdSubTypeDeadline);
			public delegate void delCallLoadMinutesBeforeShow(int nIdSubTypeDeadline,out double dMinutes);
			public delegate void delCallSaveMinutesBeforeShow(int nIdSubTypeDeadline,double dMinutes);
		#endregion
		#region Events
			public event delCallLoadMessageBase eCallLoadMessageBase;
			public event delCallShowMessageBase eCallShowMessageBase;
			public event delCallLoadMinutesBeforeShow eCallLoadMinutesBeforeShow;
			public event delCallSaveMinutesBeforeShow eCallSaveMinutesBeforeShow;
		#endregion
		#region Events Methods
			protected virtual void OnCallLoadMessageBase()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				string strMessageBase = "";
				if (eCallLoadMessageBase != null)
					eCallLoadMessageBase(mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_ABERTURAPORTAO,out strMessageBase);
				m_txtMessageBase.Text = strMessageBase;
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			protected virtual bool OnCallShowMessageBase()
			{
				bool bReturn = false;
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallShowMessageBase != null)
					bReturn = eCallShowMessageBase(mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_ABERTURAPORTAO);
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bReturn);
			}

			protected virtual void OnCallLoadMinutesBeforeShow()
			{
				double dMinutes = 0;
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallLoadMinutesBeforeShow != null)
					eCallLoadMinutesBeforeShow(mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_ABERTURAPORTAO,out dMinutes);
				m_txtTempo.Text = mdlControladoraMensagens.clsControladoraMensagens.dConvertTime(mdlControladoraMensagens.Time.Minuto,m_enumTime,dMinutes).ToString();
				m_btTime.Text = mdlControladoraMensagens.clsControladoraMensagens.strTextTime(m_enumTime);
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			protected virtual void OnCallSaveMinutesBeforeShow()
			{
				double dMinutes = 0;
				if (m_txtTempo.Text != "")
					dMinutes = double.Parse(m_txtTempo.Text);
				dMinutes = mdlControladoraMensagens.clsControladoraMensagens.dConvertTime(m_enumTime,mdlControladoraMensagens.Time.Minuto,dMinutes);
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallSaveMinutesBeforeShow != null)
					eCallSaveMinutesBeforeShow(mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_ABERTURAPORTAO,dMinutes);
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}
		#endregion

		#region Atributes
			private Time m_enumTime = Time.Dia;
			private System.Windows.Forms.Label m_lbDeadlines;
			private System.Windows.Forms.Label m_lbAntesDataPrevista;
			private System.Windows.Forms.Label m_lbMostrarMensagens;
			private System.Windows.Forms.Button m_btMensagemBase;
			private System.Windows.Forms.TextBox m_txtMessageBase;
			private System.Windows.Forms.Label m_lbMensagemBase;
			private mdlComponentesGraficos.TextBox m_txtTempo;
		private System.Windows.Forms.Button m_btTime;
			private System.ComponentModel.Container components = null;
		#endregion
		#region Constructors and Destructors
		public usrCtrlDeadlinesAberturaPortao()
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
		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(usrCtrlDeadlinesAberturaPortao));
			this.m_lbDeadlines = new System.Windows.Forms.Label();
			this.m_lbAntesDataPrevista = new System.Windows.Forms.Label();
			this.m_txtTempo = new mdlComponentesGraficos.TextBox();
			this.m_lbMostrarMensagens = new System.Windows.Forms.Label();
			this.m_btMensagemBase = new System.Windows.Forms.Button();
			this.m_txtMessageBase = new System.Windows.Forms.TextBox();
			this.m_lbMensagemBase = new System.Windows.Forms.Label();
			this.m_btTime = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// m_lbDeadlines
			// 
			this.m_lbDeadlines.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbDeadlines.Location = new System.Drawing.Point(32, 18);
			this.m_lbDeadlines.Name = "m_lbDeadlines";
			this.m_lbDeadlines.Size = new System.Drawing.Size(216, 24);
			this.m_lbDeadlines.TabIndex = 1;
			this.m_lbDeadlines.Text = "Deadline Abertura Portões";
			// 
			// m_lbAntesDataPrevista
			// 
			this.m_lbAntesDataPrevista.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
			this.m_lbAntesDataPrevista.Location = new System.Drawing.Point(8, 96);
			this.m_lbAntesDataPrevista.Name = "m_lbAntesDataPrevista";
			this.m_lbAntesDataPrevista.Size = new System.Drawing.Size(128, 16);
			this.m_lbAntesDataPrevista.TabIndex = 14;
			this.m_lbAntesDataPrevista.Text = "antes da data prevista.";
			// 
			// m_txtTempo
			// 
			this.m_txtTempo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
			this.m_txtTempo.Location = new System.Drawing.Point(144, 80);
			this.m_txtTempo.Name = "m_txtTempo";
			this.m_txtTempo.OnlyNumbers = true;
			this.m_txtTempo.Size = new System.Drawing.Size(40, 20);
			this.m_txtTempo.TabIndex = 12;
			this.m_txtTempo.Text = "";
			this.m_txtTempo.Leave += new System.EventHandler(this.m_txtTempo_Leave);
			// 
			// m_lbMostrarMensagens
			// 
			this.m_lbMostrarMensagens.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbMostrarMensagens.Location = new System.Drawing.Point(8, 80);
			this.m_lbMostrarMensagens.Name = "m_lbMostrarMensagens";
			this.m_lbMostrarMensagens.Size = new System.Drawing.Size(128, 16);
			this.m_lbMostrarMensagens.TabIndex = 11;
			this.m_lbMostrarMensagens.Text = "Mostrar as mensagens";
			// 
			// m_btMensagemBase
			// 
			this.m_btMensagemBase.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btMensagemBase.Image = ((System.Drawing.Image)(resources.GetObject("m_btMensagemBase.Image")));
			this.m_btMensagemBase.Location = new System.Drawing.Point(232, 176);
			this.m_btMensagemBase.Name = "m_btMensagemBase";
			this.m_btMensagemBase.Size = new System.Drawing.Size(25, 25);
			this.m_btMensagemBase.TabIndex = 10;
			this.m_btMensagemBase.Click += new System.EventHandler(this.m_btMensagemBase_Click);
			// 
			// m_txtMessageBase
			// 
			this.m_txtMessageBase.Enabled = false;
			this.m_txtMessageBase.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
			this.m_txtMessageBase.Location = new System.Drawing.Point(16, 202);
			this.m_txtMessageBase.Multiline = true;
			this.m_txtMessageBase.Name = "m_txtMessageBase";
			this.m_txtMessageBase.Size = new System.Drawing.Size(240, 104);
			this.m_txtMessageBase.TabIndex = 8;
			this.m_txtMessageBase.Text = "";
			// 
			// m_lbMensagemBase
			// 
			this.m_lbMensagemBase.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
			this.m_lbMensagemBase.Location = new System.Drawing.Point(16, 184);
			this.m_lbMensagemBase.Name = "m_lbMensagemBase";
			this.m_lbMensagemBase.Size = new System.Drawing.Size(144, 16);
			this.m_lbMensagemBase.TabIndex = 9;
			this.m_lbMensagemBase.Text = "Fórmula da Mensagem:";
			// 
			// m_btTime
			// 
			this.m_btTime.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btTime.Location = new System.Drawing.Point(192, 80);
			this.m_btTime.Name = "m_btTime";
			this.m_btTime.Size = new System.Drawing.Size(72, 20);
			this.m_btTime.TabIndex = 17;
			this.m_btTime.Text = "dias";
			this.m_btTime.Click += new System.EventHandler(this.m_btTime_Click);
			// 
			// usrCtrlDeadlinesAberturaPortao
			// 
			this.Controls.Add(this.m_btTime);
			this.Controls.Add(this.m_lbAntesDataPrevista);
			this.Controls.Add(this.m_txtTempo);
			this.Controls.Add(this.m_lbMostrarMensagens);
			this.Controls.Add(this.m_btMensagemBase);
			this.Controls.Add(this.m_txtMessageBase);
			this.Controls.Add(this.m_lbMensagemBase);
			this.Controls.Add(this.m_lbDeadlines);
			this.Name = "usrCtrlDeadlinesAberturaPortao";
			this.Size = new System.Drawing.Size(280, 448);
			this.Load += new System.EventHandler(this.usrCtrlDeadlinesChegadaPrevista_Load);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
		private void usrCtrlDeadlinesChegadaPrevista_Load(object sender, System.EventArgs e)
		{
			OnCallLoadMessageBase();
			OnCallLoadMinutesBeforeShow();
		}
		#endregion
			#region TextBoxes
				private void m_txtTempo_Leave(object sender, System.EventArgs e)
				{
					OnCallSaveMinutesBeforeShow();
				}
			#endregion
			#region Buttons
				private void m_btMensagemBase_Click(object sender, System.EventArgs e)
				{
					if (OnCallShowMessageBase())
						OnCallLoadMessageBase();
				}

				private void m_btTime_Click(object sender, System.EventArgs e)
				{
					Time enumTime = m_enumTime;
					m_enumTime = mdlControladoraMensagens.clsControladoraMensagens.enumNextTime(m_enumTime);
					m_btTime.Text = mdlControladoraMensagens.clsControladoraMensagens.strTextTime(m_enumTime);
					if (m_txtTempo.Text.Trim() == "")
						m_txtTempo.Text = "0";
					m_txtTempo.Text = mdlControladoraMensagens.clsControladoraMensagens.dConvertTime(enumTime,m_enumTime,double.Parse(m_txtTempo.Text)).ToString();
				}
		#endregion
		#endregion
	}
}
