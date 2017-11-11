using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Siscobras
{
	/// <summary>
	/// Summary description for frmFConsole.
	/// </summary>
	public class frmFConsole : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate string delCallExecuteCommand(ref frmFConsole Sender,string strCommand);
		#endregion
		#region Events
			public event delCallExecuteCommand eCallExecuteCommand;
		#endregion
		#region Events Methods
			protected void OnCallExecuteCommand(string strCommand)
			{
				if (eCallExecuteCommand != null)
				{
					frmFConsole formFConsole = this;
					string strRetorno = eCallExecuteCommand(ref formFConsole,strCommand);
					m_txtOutPut.Text = strRetorno + System.Environment.NewLine + m_txtOutPut.Text;
				}
			}
		#endregion

		#region Constantes
			private const int MAX_HISTORY = 30;
		#endregion
		#region Atributes
			System.Collections.ArrayList m_arlHistory = new ArrayList();
			private System.Windows.Forms.GroupBox m_gbGeral;
			private System.Windows.Forms.TextBox m_txtOutPut;
			private System.Windows.Forms.TextBox m_txtInput;
			private System.ComponentModel.Container components = null;
			private int m_nIdHistory = -1;
		#endregion
		#region Constructors and Destructors
			public frmFConsole()
			{
				InitializeComponent();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFConsole));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_txtInput = new System.Windows.Forms.TextBox();
			this.m_txtOutPut = new System.Windows.Forms.TextBox();
			this.m_gbGeral.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Controls.Add(this.m_txtInput);
			this.m_gbGeral.Controls.Add(this.m_txtOutPut);
			this.m_gbGeral.Location = new System.Drawing.Point(4, -3);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(480, 351);
			this.m_gbGeral.TabIndex = 0;
			this.m_gbGeral.TabStop = false;
			// 
			// m_txtInput
			// 
			this.m_txtInput.BackColor = System.Drawing.Color.Black;
			this.m_txtInput.ForeColor = System.Drawing.Color.White;
			this.m_txtInput.Location = new System.Drawing.Point(8, 326);
			this.m_txtInput.Name = "m_txtInput";
			this.m_txtInput.Size = new System.Drawing.Size(464, 20);
			this.m_txtInput.TabIndex = 0;
			this.m_txtInput.Text = "";
			this.m_txtInput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.m_txtInput_KeyUp);
			// 
			// m_txtOutPut
			// 
			this.m_txtOutPut.BackColor = System.Drawing.Color.Black;
			this.m_txtOutPut.ForeColor = System.Drawing.Color.White;
			this.m_txtOutPut.Location = new System.Drawing.Point(8, 16);
			this.m_txtOutPut.Multiline = true;
			this.m_txtOutPut.Name = "m_txtOutPut";
			this.m_txtOutPut.ReadOnly = true;
			this.m_txtOutPut.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.m_txtOutPut.Size = new System.Drawing.Size(464, 312);
			this.m_txtOutPut.TabIndex = 0;
			this.m_txtOutPut.Text = "";
			// 
			// frmFConsole
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(490, 352);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "frmFConsole";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Siscobras -  Console";
			this.Load += new System.EventHandler(this.frmFConsole_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFConsole_Load(object sender, System.EventArgs e)
				{
					OnCallExecuteCommand("INIT");
				}
			#endregion
			#region TextBox
				private void m_txtInput_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
				{
					string strCommand = m_txtInput.Text.Trim();
					switch(e.KeyCode)
					{
						case System.Windows.Forms.Keys.Enter:
							OnCallExecuteCommand(strCommand);
							m_txtInput.Text = "";
							vHistoryNew(strCommand);
							break;
						case System.Windows.Forms.Keys.Up:
							string strUp = strHistoryUp();
							if (strUp != "")
								m_txtInput.Text = strUp;
							break;
						case System.Windows.Forms.Keys.Down:
							string strDown = strHistoryDown();
							if (strDown != "")
								m_txtInput.Text = strDown;
							break;
					}
				}
			#endregion
		#endregion

		#region History
			private void vHistoryNew(string strCommand)
			{
				if (strCommand != "")
				{
					// Verificando se eh igual ao ultimo
					if (m_arlHistory.Count > 0)
					{
						if (strCommand !=  m_arlHistory[m_arlHistory.Count - 1].ToString())
						{
							m_arlHistory.Add(strCommand);
						}
					}else{
						m_arlHistory.Add(strCommand);
					}
					// Removendo se existir mais do que X Historicos
					while (m_arlHistory.Count > MAX_HISTORY)
						m_arlHistory.RemoveAt(0);
				}
				m_nIdHistory = m_arlHistory.Count - 1;
			}

			private string strHistoryUp()
			{
				string strRetorno = "";
				if (m_nIdHistory >= m_arlHistory.Count)
					m_nIdHistory = m_arlHistory.Count - 1;
				if ((m_nIdHistory > -1) && (m_arlHistory.Count > m_nIdHistory))
				{
					strRetorno = m_arlHistory[m_nIdHistory].ToString();
					m_nIdHistory--;
				}
				return(strRetorno);
			}

			private string strHistoryDown()
			{
				string strRetorno = "";
				m_nIdHistory++;
				if ((m_nIdHistory > -1) && (m_arlHistory.Count > m_nIdHistory))
				{
					strRetorno = m_arlHistory[m_nIdHistory].ToString();
				}
				return(strRetorno);
			}
		#endregion
		#region Commandos
			public void vClear()
			{
				m_txtOutPut.Text = "";
			}
		#endregion
	}
}
