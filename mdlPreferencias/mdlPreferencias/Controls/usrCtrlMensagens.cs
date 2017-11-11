using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace mdlPreferencias
{
	/// <summary>
	/// Summary description for usrCtrlMensagens.
	/// </summary>
	public class usrCtrlMensagens : System.Windows.Forms.UserControl
	{
		#region Delegates
			public delegate mdlConstantes.SiscoMensagemInit delCallCarregaDadosSiscoMensagemInicializacao();
			public delegate void delCallSalvaDadosSiscoMensagemInicializacao(mdlConstantes.SiscoMensagemInit enumSiscoMensagemInit);
			public delegate mdlConstantes.SiscoMensagemState delCallCarregaDadosSiscoMensagemEstado();
			public delegate bool delCallSiscoMensagemIniciar();
			public delegate bool delCallSiscoMensagemParar();
			public delegate bool delCallSiscoMensagemContinuar();
			public delegate bool delCallSiscoMensagemPausar();
			public delegate bool delCallSiscoMensagemFechar();
		#endregion
		#region Events
			public event delCallCarregaDadosSiscoMensagemInicializacao eCallCarregaDadosSiscoMensagemInicializacao;
			public event delCallSalvaDadosSiscoMensagemInicializacao eCallSalvaDadosSiscoMensagemInicializacao;
			public event delCallCarregaDadosSiscoMensagemEstado eCallCarregaDadosSiscoMensagemEstado;
			public event delCallSiscoMensagemIniciar eCallSiscoMensagemIniciar;
			public event delCallSiscoMensagemParar eCallSiscoMensagemParar;
			public event delCallSiscoMensagemContinuar eCallSiscoMensagemContinuar;
			public event delCallSiscoMensagemPausar eCallSiscoMensagemPausar;
			public event delCallSiscoMensagemFechar eCallSiscoMensagemFechar;
		#endregion
		#region Events Methods
			public virtual void OnCallCarregaDadosSiscoMensagemInicializacao()
			{
				if (eCallCarregaDadosSiscoMensagemInicializacao != null)
				{
					mdlConstantes.SiscoMensagemInit enumSiscoMensagemInit = eCallCarregaDadosSiscoMensagemInicializacao();
					switch(enumSiscoMensagemInit)
					{
						case mdlConstantes.SiscoMensagemInit.Never:
							m_rbActivateNever.Checked = true;
							break;
						case mdlConstantes.SiscoMensagemInit.Siscobras:
							m_rbActivateSiscobras.Checked = true;
							break;
						case mdlConstantes.SiscoMensagemInit.ComputerStartup:
							m_rbActivateAutomatic.Checked = true;
							break;
					}
				}
			}

			public virtual void OnCallSalvaDadosSiscoMensagemInicializacao()
			{
				if (eCallSalvaDadosSiscoMensagemInicializacao != null)
				{
					if (m_rbActivateNever.Checked)
						eCallSalvaDadosSiscoMensagemInicializacao(mdlConstantes.SiscoMensagemInit.Never);
					if (m_rbActivateSiscobras.Checked)
						eCallSalvaDadosSiscoMensagemInicializacao(mdlConstantes.SiscoMensagemInit.Siscobras);
					if (m_rbActivateAutomatic.Checked)
						eCallSalvaDadosSiscoMensagemInicializacao(mdlConstantes.SiscoMensagemInit.ComputerStartup);
				}
			}

			public virtual void OnCallCarregaDadosSiscoMensagemEstado()
			{
				if (eCallCarregaDadosSiscoMensagemEstado != null)
				{
					bool bNeverInitialize = true;
					if (eCallCarregaDadosSiscoMensagemInicializacao != null)
						bNeverInitialize = (mdlConstantes.SiscoMensagemInit.Never == eCallCarregaDadosSiscoMensagemInicializacao());
					m_gbState.Enabled = true;
					mdlConstantes.SiscoMensagemState enumSiscoMensagemState = eCallCarregaDadosSiscoMensagemEstado();
					switch(enumSiscoMensagemState)
					{
						case mdlConstantes.SiscoMensagemState.Running:
							m_gbState.ForeColor = System.Drawing.Color.Green;
							m_btSiscoMensagemStart.Enabled = false;
							m_btSiscoMensagemPause.Enabled = true;
							m_btSiscoMensagemContinue.Enabled = false;
							m_btSiscoMensagemStop.Enabled = true;
							break;
						case mdlConstantes.SiscoMensagemState.Paused:
							m_gbState.ForeColor = System.Drawing.Color.Coral;
							m_btSiscoMensagemStart.Enabled = false;
							m_btSiscoMensagemPause.Enabled = false;
							m_btSiscoMensagemContinue.Enabled = true;
							m_btSiscoMensagemStop.Enabled = true;
							break;
						case mdlConstantes.SiscoMensagemState.Stoped:
							m_gbState.ForeColor = System.Drawing.Color.Red;
							m_btSiscoMensagemStart.Enabled = true;
							m_btSiscoMensagemPause.Enabled = false;
							m_btSiscoMensagemContinue.Enabled = false;
							m_btSiscoMensagemStop.Enabled = false;
							break;
						case mdlConstantes.SiscoMensagemState.Unknown:
							m_gbState.ForeColor = System.Drawing.Color.Black;
							m_btSiscoMensagemStart.Enabled = true;
							m_btSiscoMensagemPause.Enabled = false;
							m_btSiscoMensagemContinue.Enabled = false;
							m_btSiscoMensagemStop.Enabled = false;
							break;
					}
				}else{
					m_gbState.Enabled = false;
					m_gbState.ForeColor = System.Drawing.Color.Black;
				}
			}

			public virtual bool OnCallSiscoMensagemIniciar()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				bool bReturn = false;
				if (eCallSiscoMensagemIniciar != null)
					bReturn = eCallSiscoMensagemIniciar();
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bReturn);
			}

			public virtual bool OnCallSiscoMensagemParar()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				bool bReturn = false;
				if (eCallSiscoMensagemParar != null)
					bReturn = eCallSiscoMensagemParar();
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bReturn);
			}

			public virtual bool OnCallSiscoMensagemPausar()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				bool bReturn = false;
				if (eCallSiscoMensagemPausar != null)
					bReturn = eCallSiscoMensagemPausar();
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bReturn);
			}

			public virtual bool OnCallSiscoMensagemContinuar()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				bool bReturn = false;
				if (eCallSiscoMensagemContinuar != null)
					bReturn = eCallSiscoMensagemContinuar();
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bReturn);
			}

			public virtual bool OnCallSiscoMensagemFechar()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				bool bReturn = false;
				if (eCallSiscoMensagemFechar != null)
					bReturn = eCallSiscoMensagemFechar();
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bReturn);
			}
		#endregion

		#region Atributes
			private System.Windows.Forms.GroupBox m_gbActivate;
			private System.Windows.Forms.RadioButton m_rbActivateNever;
			private System.Windows.Forms.RadioButton m_rbActivateAutomatic;
			private System.Windows.Forms.RadioButton m_rbActivateSiscobras;
			private System.Windows.Forms.Label m_lbSiscoMensagemInfo;
			private System.Windows.Forms.Label m_lbSiscoMensagem;
			private System.Windows.Forms.GroupBox m_gbState;
			private System.Windows.Forms.Button m_btSiscoMensagemStart;
			private System.Windows.Forms.Button m_btSiscoMensagemStop;
			private System.Windows.Forms.Button m_btSiscoMensagemPause;
			private System.Windows.Forms.ToolTip m_ttDicas;
			private System.Windows.Forms.Button m_btSiscoMensagemContinue;
			private System.ComponentModel.IContainer components;
		#endregion
		#region Constructors and Destructors
			public usrCtrlMensagens()
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(usrCtrlMensagens));
			this.m_gbActivate = new System.Windows.Forms.GroupBox();
			this.m_rbActivateNever = new System.Windows.Forms.RadioButton();
			this.m_rbActivateAutomatic = new System.Windows.Forms.RadioButton();
			this.m_rbActivateSiscobras = new System.Windows.Forms.RadioButton();
			this.m_lbSiscoMensagemInfo = new System.Windows.Forms.Label();
			this.m_lbSiscoMensagem = new System.Windows.Forms.Label();
			this.m_gbState = new System.Windows.Forms.GroupBox();
			this.m_btSiscoMensagemContinue = new System.Windows.Forms.Button();
			this.m_btSiscoMensagemPause = new System.Windows.Forms.Button();
			this.m_btSiscoMensagemStop = new System.Windows.Forms.Button();
			this.m_btSiscoMensagemStart = new System.Windows.Forms.Button();
			this.m_ttDicas = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbActivate.SuspendLayout();
			this.m_gbState.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbActivate
			// 
			this.m_gbActivate.Controls.Add(this.m_rbActivateNever);
			this.m_gbActivate.Controls.Add(this.m_rbActivateAutomatic);
			this.m_gbActivate.Controls.Add(this.m_rbActivateSiscobras);
			this.m_gbActivate.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbActivate.Location = new System.Drawing.Point(56, 80);
			this.m_gbActivate.Name = "m_gbActivate";
			this.m_gbActivate.Size = new System.Drawing.Size(280, 75);
			this.m_gbActivate.TabIndex = 9;
			this.m_gbActivate.TabStop = false;
			this.m_gbActivate.Text = "Ativar";
			// 
			// m_rbActivateNever
			// 
			this.m_rbActivateNever.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_rbActivateNever.Location = new System.Drawing.Point(9, 16);
			this.m_rbActivateNever.Name = "m_rbActivateNever";
			this.m_rbActivateNever.Size = new System.Drawing.Size(248, 16);
			this.m_rbActivateNever.TabIndex = 5;
			this.m_rbActivateNever.Text = "Nunca.";
			this.m_rbActivateNever.CheckedChanged += new System.EventHandler(this.m_rbActivateNever_CheckedChanged);
			// 
			// m_rbActivateAutomatic
			// 
			this.m_rbActivateAutomatic.Checked = true;
			this.m_rbActivateAutomatic.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_rbActivateAutomatic.Location = new System.Drawing.Point(9, 50);
			this.m_rbActivateAutomatic.Name = "m_rbActivateAutomatic";
			this.m_rbActivateAutomatic.Size = new System.Drawing.Size(248, 16);
			this.m_rbActivateAutomatic.TabIndex = 4;
			this.m_rbActivateAutomatic.TabStop = true;
			this.m_rbActivateAutomatic.Text = "Automaticamente ao ligar o computador";
			this.m_rbActivateAutomatic.CheckedChanged += new System.EventHandler(this.m_rbActivateAutomatic_CheckedChanged);
			// 
			// m_rbActivateSiscobras
			// 
			this.m_rbActivateSiscobras.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_rbActivateSiscobras.Location = new System.Drawing.Point(9, 32);
			this.m_rbActivateSiscobras.Name = "m_rbActivateSiscobras";
			this.m_rbActivateSiscobras.Size = new System.Drawing.Size(248, 16);
			this.m_rbActivateSiscobras.TabIndex = 6;
			this.m_rbActivateSiscobras.Text = "Ao iniciar o Siscobras Exporta Fácil";
			this.m_rbActivateSiscobras.CheckedChanged += new System.EventHandler(this.m_rbActivateSiscobras_CheckedChanged);
			// 
			// m_lbSiscoMensagemInfo
			// 
			this.m_lbSiscoMensagemInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbSiscoMensagemInfo.Location = new System.Drawing.Point(38, 48);
			this.m_lbSiscoMensagemInfo.Name = "m_lbSiscoMensagemInfo";
			this.m_lbSiscoMensagemInfo.Size = new System.Drawing.Size(320, 32);
			this.m_lbSiscoMensagemInfo.TabIndex = 8;
			this.m_lbSiscoMensagemInfo.Text = "A Agenda é um recurso do SiscoMensagem. Com ela você gerencia seus compromissos n" +
				"o Siscobras Exporta Fácil.";
			// 
			// m_lbSiscoMensagem
			// 
			this.m_lbSiscoMensagem.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbSiscoMensagem.Location = new System.Drawing.Point(163, 16);
			this.m_lbSiscoMensagem.Name = "m_lbSiscoMensagem";
			this.m_lbSiscoMensagem.Size = new System.Drawing.Size(72, 24);
			this.m_lbSiscoMensagem.TabIndex = 7;
			this.m_lbSiscoMensagem.Text = "Agenda";
			// 
			// m_gbState
			// 
			this.m_gbState.Controls.Add(this.m_btSiscoMensagemContinue);
			this.m_gbState.Controls.Add(this.m_btSiscoMensagemPause);
			this.m_gbState.Controls.Add(this.m_btSiscoMensagemStop);
			this.m_gbState.Controls.Add(this.m_btSiscoMensagemStart);
			this.m_gbState.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbState.Location = new System.Drawing.Point(128, 159);
			this.m_gbState.Name = "m_gbState";
			this.m_gbState.Size = new System.Drawing.Size(128, 60);
			this.m_gbState.TabIndex = 10;
			this.m_gbState.TabStop = false;
			this.m_gbState.Text = "Sisco Mensagem";
			// 
			// m_btSiscoMensagemContinue
			// 
			this.m_btSiscoMensagemContinue.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btSiscoMensagemContinue.Image = ((System.Drawing.Image)(resources.GetObject("m_btSiscoMensagemContinue.Image")));
			this.m_btSiscoMensagemContinue.Location = new System.Drawing.Point(94, 24);
			this.m_btSiscoMensagemContinue.Name = "m_btSiscoMensagemContinue";
			this.m_btSiscoMensagemContinue.Size = new System.Drawing.Size(25, 25);
			this.m_btSiscoMensagemContinue.TabIndex = 3;
			this.m_ttDicas.SetToolTip(this.m_btSiscoMensagemContinue, "Continuar");
			this.m_btSiscoMensagemContinue.Click += new System.EventHandler(this.m_btSiscoMensagemContinue_Click);
			// 
			// m_btSiscoMensagemPause
			// 
			this.m_btSiscoMensagemPause.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btSiscoMensagemPause.Image = ((System.Drawing.Image)(resources.GetObject("m_btSiscoMensagemPause.Image")));
			this.m_btSiscoMensagemPause.Location = new System.Drawing.Point(36, 24);
			this.m_btSiscoMensagemPause.Name = "m_btSiscoMensagemPause";
			this.m_btSiscoMensagemPause.Size = new System.Drawing.Size(25, 25);
			this.m_btSiscoMensagemPause.TabIndex = 2;
			this.m_ttDicas.SetToolTip(this.m_btSiscoMensagemPause, "Pausar");
			this.m_btSiscoMensagemPause.Click += new System.EventHandler(this.m_btSiscoMensagemPause_Click);
			// 
			// m_btSiscoMensagemStop
			// 
			this.m_btSiscoMensagemStop.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btSiscoMensagemStop.Image = ((System.Drawing.Image)(resources.GetObject("m_btSiscoMensagemStop.Image")));
			this.m_btSiscoMensagemStop.Location = new System.Drawing.Point(7, 24);
			this.m_btSiscoMensagemStop.Name = "m_btSiscoMensagemStop";
			this.m_btSiscoMensagemStop.Size = new System.Drawing.Size(25, 25);
			this.m_btSiscoMensagemStop.TabIndex = 1;
			this.m_ttDicas.SetToolTip(this.m_btSiscoMensagemStop, "Parar");
			this.m_btSiscoMensagemStop.Click += new System.EventHandler(this.m_btSiscoMensagemStop_Click);
			// 
			// m_btSiscoMensagemStart
			// 
			this.m_btSiscoMensagemStart.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btSiscoMensagemStart.Image = ((System.Drawing.Image)(resources.GetObject("m_btSiscoMensagemStart.Image")));
			this.m_btSiscoMensagemStart.Location = new System.Drawing.Point(65, 24);
			this.m_btSiscoMensagemStart.Name = "m_btSiscoMensagemStart";
			this.m_btSiscoMensagemStart.Size = new System.Drawing.Size(25, 25);
			this.m_btSiscoMensagemStart.TabIndex = 0;
			this.m_ttDicas.SetToolTip(this.m_btSiscoMensagemStart, "Iniciar");
			this.m_btSiscoMensagemStart.Click += new System.EventHandler(this.m_btSiscoMensagemStart_Click);
			// 
			// m_ttDicas
			// 
			this.m_ttDicas.AutomaticDelay = 100;
			this.m_ttDicas.AutoPopDelay = 5000;
			this.m_ttDicas.InitialDelay = 100;
			this.m_ttDicas.ReshowDelay = 20;
			// 
			// usrCtrlMensagens
			// 
			this.Controls.Add(this.m_gbState);
			this.Controls.Add(this.m_gbActivate);
			this.Controls.Add(this.m_lbSiscoMensagemInfo);
			this.Controls.Add(this.m_lbSiscoMensagem);
			this.Name = "usrCtrlMensagens";
			this.Size = new System.Drawing.Size(394, 368);
			this.Load += new System.EventHandler(this.usrCtrlMensagens_Load);
			this.m_gbActivate.ResumeLayout(false);
			this.m_gbState.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void usrCtrlMensagens_Load(object sender, System.EventArgs e)
				{
					OnCallCarregaDadosSiscoMensagemInicializacao();
					OnCallCarregaDadosSiscoMensagemEstado();
				}
			#endregion
			#region CheckBoxes
				private void m_rbActivateNever_CheckedChanged(object sender, System.EventArgs e)
				{
					if (m_rbActivateNever.Checked)
					{
						OnCallSalvaDadosSiscoMensagemInicializacao();
						OnCallCarregaDadosSiscoMensagemInicializacao();
						OnCallCarregaDadosSiscoMensagemEstado();
					}
				}

				private void m_rbActivateSiscobras_CheckedChanged(object sender, System.EventArgs e)
				{
					if (m_rbActivateSiscobras.Checked)
					{
						OnCallSalvaDadosSiscoMensagemInicializacao();
						OnCallCarregaDadosSiscoMensagemInicializacao();
						OnCallCarregaDadosSiscoMensagemEstado();
					}
				}

				private void m_rbActivateAutomatic_CheckedChanged(object sender, System.EventArgs e)
				{
					if (m_rbActivateAutomatic.Checked)
					{
						OnCallSalvaDadosSiscoMensagemInicializacao();
						OnCallCarregaDadosSiscoMensagemInicializacao();
						OnCallCarregaDadosSiscoMensagemEstado();
					}
				}
			#endregion
			#region Botoes
				private void m_btSiscoMensagemStop_Click(object sender, System.EventArgs e)
				{
					if (OnCallSiscoMensagemFechar())
					{
						OnCallCarregaDadosSiscoMensagemEstado();
						OnCallCarregaDadosSiscoMensagemInicializacao();
					}
				}

				private void m_btSiscoMensagemPause_Click(object sender, System.EventArgs e)
				{
					if (OnCallSiscoMensagemPausar())
					{
						OnCallCarregaDadosSiscoMensagemEstado();
						OnCallCarregaDadosSiscoMensagemInicializacao();
					}
				}

				private void m_btSiscoMensagemStart_Click(object sender, System.EventArgs e)
				{
					if (OnCallSiscoMensagemIniciar())
					{
						OnCallCarregaDadosSiscoMensagemEstado();
						OnCallCarregaDadosSiscoMensagemInicializacao();
					}
				}

				private void m_btSiscoMensagemContinue_Click(object sender, System.EventArgs e)
				{
					if (OnCallSiscoMensagemContinuar())
					{
						OnCallCarregaDadosSiscoMensagemEstado();
						OnCallCarregaDadosSiscoMensagemInicializacao();
					}
				}
			#endregion
		#endregion

	}
}
