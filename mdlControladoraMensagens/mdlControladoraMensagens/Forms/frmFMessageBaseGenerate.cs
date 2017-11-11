using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlControladoraMensagens.Forms
{
	/// <summary>
	/// Summary description for frmFMessageBaseGenerate.
	/// </summary>
	public class frmFMessageBaseGenerate : System.Windows.Forms.Form
	{
		#region Atributes
			public bool m_bModificado = false;
			private bool m_bSchedulerContratoCambio = false;
			private bool m_bSchedulerDeadline = false;
			private bool m_bSchedulerDeadlineChegadaPrevista = false;
			private bool m_bSchedulerDeadlineOutro = false;
			
			private System.Windows.Forms.GroupBox m_gbMain;
			private System.Windows.Forms.GroupBox m_gbBotoes;
			private System.Windows.Forms.GroupBox m_gbMensagemBase;
			private System.Windows.Forms.TextBox m_txtMessageBase;
			private System.Windows.Forms.Button m_btOk;
			private System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.Button m_btDia;
			private System.Windows.Forms.Button m_btMes;
			private System.Windows.Forms.Button m_btAno;
			private System.Windows.Forms.Button m_btHora;
			private System.Windows.Forms.Button m_btMinuto;
			private System.Windows.Forms.Button m_btExportador;
			private System.Windows.Forms.Button m_btPE;
			private System.Windows.Forms.Button m_btNavio;
			private System.Windows.Forms.Label m_lbInformation;
			private System.ComponentModel.Container components = null;
		#endregion
		#region Properties
			public bool ContratoCambio
			{
				set
				{
					m_bSchedulerContratoCambio = value; 
					if (m_bSchedulerContratoCambio)
					{
						m_btPE.Text = "Contrato";
						m_btNavio.Visible = false;
					}
				}
			}
			public bool Deadline
			{
				set
				{
					m_bSchedulerDeadline = value; 
					if (m_bSchedulerDeadline)
					{
						m_btPE.Text = "PE";
						m_btNavio.Visible = false;
					}
				}
			}

			public bool DeadlineChegadaPrevista
			{
				set
				{
					m_bSchedulerDeadlineChegadaPrevista = value;
					if (value)
					{
						
						m_btNavio.Text = "Navio";
						m_btNavio.Visible = true;
					}
					else
					{
						m_btNavio.Visible = false;
					}
				}
			}

			public bool DeadlineOutro
			{
				set
				{
					m_bSchedulerDeadlineOutro = value;
					if (value)
					{
						m_btNavio.Text = "Outro";
						m_btNavio.Visible = true;
					}
					else
					{
						m_btNavio.Visible = false;
					}
				}
			}
		#endregion
		#region Constructors and Destructors
			public frmFMessageBaseGenerate(string strMessageBase)
			{
				InitializeComponent();
				m_txtMessageBase.Text = strMessageBase;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFMessageBaseGenerate));
			this.m_gbMain = new System.Windows.Forms.GroupBox();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbMensagemBase = new System.Windows.Forms.GroupBox();
			this.m_txtMessageBase = new System.Windows.Forms.TextBox();
			this.m_gbBotoes = new System.Windows.Forms.GroupBox();
			this.m_lbInformation = new System.Windows.Forms.Label();
			this.m_btNavio = new System.Windows.Forms.Button();
			this.m_btPE = new System.Windows.Forms.Button();
			this.m_btExportador = new System.Windows.Forms.Button();
			this.m_btMinuto = new System.Windows.Forms.Button();
			this.m_btHora = new System.Windows.Forms.Button();
			this.m_btAno = new System.Windows.Forms.Button();
			this.m_btMes = new System.Windows.Forms.Button();
			this.m_btDia = new System.Windows.Forms.Button();
			this.m_gbMain.SuspendLayout();
			this.m_gbMensagemBase.SuspendLayout();
			this.m_gbBotoes.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbMain
			// 
			this.m_gbMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbMain.Controls.Add(this.m_btOk);
			this.m_gbMain.Controls.Add(this.m_btCancelar);
			this.m_gbMain.Controls.Add(this.m_gbMensagemBase);
			this.m_gbMain.Controls.Add(this.m_gbBotoes);
			this.m_gbMain.Location = new System.Drawing.Point(3, -2);
			this.m_gbMain.Name = "m_gbMain";
			this.m_gbMain.Size = new System.Drawing.Size(274, 352);
			this.m_gbMain.TabIndex = 0;
			this.m_gbMain.TabStop = false;
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(79, 320);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 9;
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(143, 320);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 10;
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbMensagemBase
			// 
			this.m_gbMensagemBase.Controls.Add(this.m_txtMessageBase);
			this.m_gbMensagemBase.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbMensagemBase.Location = new System.Drawing.Point(6, 160);
			this.m_gbMensagemBase.Name = "m_gbMensagemBase";
			this.m_gbMensagemBase.Size = new System.Drawing.Size(264, 158);
			this.m_gbMensagemBase.TabIndex = 1;
			this.m_gbMensagemBase.TabStop = false;
			this.m_gbMensagemBase.Text = "Fórmula da Mensagem";
			// 
			// m_txtMessageBase
			// 
			this.m_txtMessageBase.Location = new System.Drawing.Point(8, 16);
			this.m_txtMessageBase.Multiline = true;
			this.m_txtMessageBase.Name = "m_txtMessageBase";
			this.m_txtMessageBase.Size = new System.Drawing.Size(248, 136);
			this.m_txtMessageBase.TabIndex = 0;
			this.m_txtMessageBase.Text = "";
			// 
			// m_gbBotoes
			// 
			this.m_gbBotoes.Controls.Add(this.m_lbInformation);
			this.m_gbBotoes.Controls.Add(this.m_btNavio);
			this.m_gbBotoes.Controls.Add(this.m_btPE);
			this.m_gbBotoes.Controls.Add(this.m_btExportador);
			this.m_gbBotoes.Controls.Add(this.m_btMinuto);
			this.m_gbBotoes.Controls.Add(this.m_btHora);
			this.m_gbBotoes.Controls.Add(this.m_btAno);
			this.m_gbBotoes.Controls.Add(this.m_btMes);
			this.m_gbBotoes.Controls.Add(this.m_btDia);
			this.m_gbBotoes.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbBotoes.Location = new System.Drawing.Point(5, 10);
			this.m_gbBotoes.Name = "m_gbBotoes";
			this.m_gbBotoes.Size = new System.Drawing.Size(264, 150);
			this.m_gbBotoes.TabIndex = 0;
			this.m_gbBotoes.TabStop = false;
			this.m_gbBotoes.Text = "Campos da Mensagem";
			// 
			// m_lbInformation
			// 
			this.m_lbInformation.Location = new System.Drawing.Point(38, 19);
			this.m_lbInformation.Name = "m_lbInformation";
			this.m_lbInformation.Size = new System.Drawing.Size(200, 32);
			this.m_lbInformation.TabIndex = 9;
			this.m_lbInformation.Text = "Configure a mensagem clicando nos botões abaixo.";
			// 
			// m_btNavio
			// 
			this.m_btNavio.Location = new System.Drawing.Point(172, 117);
			this.m_btNavio.Name = "m_btNavio";
			this.m_btNavio.Size = new System.Drawing.Size(80, 20);
			this.m_btNavio.TabIndex = 8;
			this.m_btNavio.Text = "Navio";
			this.m_btNavio.Click += new System.EventHandler(this.m_btNavio_Click);
			// 
			// m_btPE
			// 
			this.m_btPE.Location = new System.Drawing.Point(90, 117);
			this.m_btPE.Name = "m_btPE";
			this.m_btPE.Size = new System.Drawing.Size(80, 20);
			this.m_btPE.TabIndex = 7;
			this.m_btPE.Text = "PE";
			this.m_btPE.Click += new System.EventHandler(this.m_btPE_Click);
			// 
			// m_btExportador
			// 
			this.m_btExportador.Location = new System.Drawing.Point(8, 117);
			this.m_btExportador.Name = "m_btExportador";
			this.m_btExportador.Size = new System.Drawing.Size(80, 20);
			this.m_btExportador.TabIndex = 6;
			this.m_btExportador.Text = "Exportador";
			this.m_btExportador.Click += new System.EventHandler(this.m_btExportador_Click);
			// 
			// m_btMinuto
			// 
			this.m_btMinuto.Location = new System.Drawing.Point(90, 80);
			this.m_btMinuto.Name = "m_btMinuto";
			this.m_btMinuto.Size = new System.Drawing.Size(80, 20);
			this.m_btMinuto.TabIndex = 4;
			this.m_btMinuto.Text = "Minuto";
			this.m_btMinuto.Click += new System.EventHandler(this.m_btMinuto_Click);
			// 
			// m_btHora
			// 
			this.m_btHora.Location = new System.Drawing.Point(8, 80);
			this.m_btHora.Name = "m_btHora";
			this.m_btHora.Size = new System.Drawing.Size(80, 20);
			this.m_btHora.TabIndex = 3;
			this.m_btHora.Text = "Hora";
			this.m_btHora.Click += new System.EventHandler(this.m_btHora_Click);
			// 
			// m_btAno
			// 
			this.m_btAno.Location = new System.Drawing.Point(172, 56);
			this.m_btAno.Name = "m_btAno";
			this.m_btAno.Size = new System.Drawing.Size(80, 20);
			this.m_btAno.TabIndex = 2;
			this.m_btAno.Text = "Ano";
			this.m_btAno.Click += new System.EventHandler(this.m_btAno_Click);
			// 
			// m_btMes
			// 
			this.m_btMes.Location = new System.Drawing.Point(90, 56);
			this.m_btMes.Name = "m_btMes";
			this.m_btMes.Size = new System.Drawing.Size(80, 20);
			this.m_btMes.TabIndex = 1;
			this.m_btMes.Text = "Mês";
			this.m_btMes.Click += new System.EventHandler(this.m_btMes_Click);
			// 
			// m_btDia
			// 
			this.m_btDia.Location = new System.Drawing.Point(8, 56);
			this.m_btDia.Name = "m_btDia";
			this.m_btDia.Size = new System.Drawing.Size(80, 20);
			this.m_btDia.TabIndex = 0;
			this.m_btDia.Text = "Dia";
			this.m_btDia.Click += new System.EventHandler(this.m_btDia_Click);
			// 
			// frmFMessageBaseGenerate
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(282, 352);
			this.Controls.Add(this.m_gbMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFMessageBaseGenerate";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Configuração da Mensagem";
			this.Load += new System.EventHandler(this.frmFMessageBaseGenerate_Load);
			this.m_gbMain.ResumeLayout(false);
			this.m_gbMensagemBase.ResumeLayout(false);
			this.m_gbBotoes.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFMessageBaseGenerate_Load(object sender, System.EventArgs e)
				{
					vShowColor();
				}
			#endregion
			#region Buttons
				private void m_btDia_Click(object sender, System.EventArgs e)
				{
					vInsertText(clsControladoraMensagens.TAG_DATA_DIA);
				}

				private void m_btMes_Click(object sender, System.EventArgs e)
				{
					vInsertText(clsControladoraMensagens.TAG_DATA_MES);
				}

				private void m_btAno_Click(object sender, System.EventArgs e)
				{
					vInsertText(clsControladoraMensagens.TAG_DATA_ANO);				
				}

				private void m_btHora_Click(object sender, System.EventArgs e)
				{
					vInsertText(clsControladoraMensagens.TAG_DATA_HORA);								
				}

				private void m_btMinuto_Click(object sender, System.EventArgs e)
				{
					vInsertText(clsControladoraMensagens.TAG_DATA_MINUTO);								
				}

				private void m_btSegundo_Click(object sender, System.EventArgs e)
				{
					vInsertText(clsControladoraMensagens.TAG_DATA_SEGUNDO);								
				}

				private void m_btExportador_Click(object sender, System.EventArgs e)
				{
					vInsertText(clsControladoraMensagens.TAG_EXPORTADOR_NOME);								
				}

				private void m_btPE_Click(object sender, System.EventArgs e)
				{
					if (m_bSchedulerContratoCambio)
						vInsertText(clsControladoraMensagens.TAG_CONTRATOCAMBIO_NUMERO);								
					if (m_bSchedulerDeadline)
						vInsertText(clsControladoraMensagens.TAG_PROCESSO_NUMERO);								
				}

				private void m_btNavio_Click(object sender, System.EventArgs e)
				{
					if (m_bSchedulerDeadlineChegadaPrevista)
						vInsertText(clsControladoraMensagens.TAG_PROCESSO_NAVIO);								
					if (m_bSchedulerDeadlineOutro)
						vInsertText(clsControladoraMensagens.TAG_OUTRO_DEADLINE);								
				}

				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					m_bModificado = true;
					this.Close();
				}

				private void m_btCancelar_Click(object sender, System.EventArgs e)
				{
					m_bModificado = false;
					this.Close();
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
					case "System.Windows.Forms.TextBox":
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

		#region InsertText
			private void vInsertText(string strText)
			{
				string strMessageStart = m_txtMessageBase.Text.Substring(0,m_txtMessageBase.SelectionStart);
				string strMessageEnd = m_txtMessageBase.Text.Substring(m_txtMessageBase.SelectionStart);
				m_txtMessageBase.Text = strMessageStart + strText + strMessageEnd;
				m_txtMessageBase.SelectionStart = strMessageStart.Length + strText.Length;
				m_txtMessageBase.Focus();
			}
		#endregion

		#region Return
			public void vReturnValues(out string strMessageBase)
			{
				strMessageBase = m_txtMessageBase.Text;
			}
		#endregion

	}
}
