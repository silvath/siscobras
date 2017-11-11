using System;	
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlControladoraMensagens.Forms
{
	/// <summary>
	/// Summary description for frmMessage.
	/// </summary>
	public class frmMessage : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate void delCallLoadConfigurationMessageType(string strIdMessage,out System.Drawing.Color clrMessageType,out string strMessageType);
			public delegate void delCallLoadData(string strIdMessage,out System.DateTime dtShow,out bool bShow,out System.DateTime dtEvent,out string strMessage);
			public delegate bool delCallMessageDelete(string strIdMessage,bool bSilent);
			public delegate bool delCallMessageSave(string strIdMessage,System.DateTime dtShow,bool bShow,System.DateTime dtEvent,string strMessage);
		#endregion
		#region Events
			public event delCallLoadConfigurationMessageType eCallLoadConfigurationMessageType;
			public event delCallLoadData eCallLoadData;
			public event delCallMessageDelete eCallMessageDelete;
			public event delCallMessageSave eCallMessageSave;
		#endregion
		#region Events Methods
			protected virtual void OnCallLoadConfigurationMessageType()
			{
				if (eCallLoadConfigurationMessageType != null)
				{
					System.Drawing.Color clrMessageType;
					string strMessageType;
					eCallLoadConfigurationMessageType(m_strIdMessage,out clrMessageType,out strMessageType);
					m_gbMessageType.Text = strMessageType;
					m_gbMessageType.ForeColor = clrMessageType;
				}
			}

			protected virtual void OnCallLoadData()
			{
				if (eCallLoadData != null)
				{
					System.DateTime dtShow,dtEvent;
					bool bShow;
					string strMessage;
					eCallLoadData(m_strIdMessage,out dtShow,out bShow,out dtEvent,out strMessage);
					m_dpEvent.Value = dtEvent;
					m_dpShow.Value = dtShow;
					m_txtMessage.Text = strMessage;
				}
			}

			protected virtual bool OnCallMessageDelete()
			{
				bool bReturn = false;
				if (eCallMessageDelete != null)
					bReturn = eCallMessageDelete(m_strIdMessage,false);
				return(bReturn);
			}

			protected virtual bool OnCallMessageSave()
			{
				bool bReturn = false;
				if (eCallMessageSave != null)
					bReturn = eCallMessageSave(m_strIdMessage,m_dpShow.Value,true,m_dpEvent.Value,m_txtMessage.Text);
				return(bReturn);
			}
		#endregion

		#region Atributes
			private string m_strIdMessage = "";
			
			public bool m_bModificado = false;

			private System.Windows.Forms.GroupBox m_gbMain;
			private System.Windows.Forms.GroupBox m_gbMessageType;
			private System.Windows.Forms.TextBox m_txtMessage;
			private System.Windows.Forms.Label m_lbDateEvent;
			private System.Windows.Forms.Label m_lbMessage;
			private System.Windows.Forms.Label m_lbDateShow;
			private System.Windows.Forms.Button m_btDiscard;
			private System.Windows.Forms.Button m_btOk;
			private System.Windows.Forms.Button m_btCancel;
			private mdlComponentesGraficos.DateTimePicker m_dpShow;
			private mdlComponentesGraficos.DateTimePicker m_dpEvent;
			private System.ComponentModel.Container components = null;
		#endregion
		#region Properties
			public bool VisibleDiscardButton
			{
				get
				{
					return(m_btDiscard.Visible);
				}
				set
				{
					m_btDiscard.Visible = value;
					if (m_btDiscard.Visible == true)
					{
						m_btOk.Location = new Point(187,227);
						m_btCancel.Location = new Point(252,227);
					}else{
						m_btOk.Location = new Point(165,227);
						m_btCancel.Location = new Point(230,227);
					}
				}
			}
		#endregion
		#region Constructors and Destructors
			public frmMessage(string strIdMessage)
			{
				m_strIdMessage = strIdMessage;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMessage));
			this.m_gbMain = new System.Windows.Forms.GroupBox();
			this.m_gbMessageType = new System.Windows.Forms.GroupBox();
			this.m_btCancel = new System.Windows.Forms.Button();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btDiscard = new System.Windows.Forms.Button();
			this.m_dpShow = new mdlComponentesGraficos.DateTimePicker();
			this.m_lbDateShow = new System.Windows.Forms.Label();
			this.m_lbMessage = new System.Windows.Forms.Label();
			this.m_txtMessage = new System.Windows.Forms.TextBox();
			this.m_dpEvent = new mdlComponentesGraficos.DateTimePicker();
			this.m_lbDateEvent = new System.Windows.Forms.Label();
			this.m_gbMain.SuspendLayout();
			this.m_gbMessageType.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbMain
			// 
			this.m_gbMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbMain.Controls.Add(this.m_gbMessageType);
			this.m_gbMain.Location = new System.Drawing.Point(3, -1);
			this.m_gbMain.Name = "m_gbMain";
			this.m_gbMain.Size = new System.Drawing.Size(443, 271);
			this.m_gbMain.TabIndex = 0;
			this.m_gbMain.TabStop = false;
			// 
			// m_gbMessageType
			// 
			this.m_gbMessageType.Controls.Add(this.m_btCancel);
			this.m_gbMessageType.Controls.Add(this.m_btOk);
			this.m_gbMessageType.Controls.Add(this.m_btDiscard);
			this.m_gbMessageType.Controls.Add(this.m_dpShow);
			this.m_gbMessageType.Controls.Add(this.m_lbDateShow);
			this.m_gbMessageType.Controls.Add(this.m_lbMessage);
			this.m_gbMessageType.Controls.Add(this.m_txtMessage);
			this.m_gbMessageType.Controls.Add(this.m_dpEvent);
			this.m_gbMessageType.Controls.Add(this.m_lbDateEvent);
			this.m_gbMessageType.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbMessageType.Location = new System.Drawing.Point(5, 10);
			this.m_gbMessageType.Name = "m_gbMessageType";
			this.m_gbMessageType.Size = new System.Drawing.Size(435, 256);
			this.m_gbMessageType.TabIndex = 5;
			this.m_gbMessageType.TabStop = false;
			// 
			// m_btCancel
			// 
			this.m_btCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancel.ForeColor = System.Drawing.Color.Olive;
			this.m_btCancel.Location = new System.Drawing.Point(252, 227);
			this.m_btCancel.Name = "m_btCancel";
			this.m_btCancel.Size = new System.Drawing.Size(64, 25);
			this.m_btCancel.TabIndex = 12;
			this.m_btCancel.Text = "Cancelar";
			this.m_btCancel.Click += new System.EventHandler(this.m_btCancel_Click);
			// 
			// m_btOk
			// 
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Enabled = false;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_btOk.Location = new System.Drawing.Point(186, 227);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.Size = new System.Drawing.Size(64, 25);
			this.m_btOk.TabIndex = 11;
			this.m_btOk.Text = "Aplicar";
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btDiscard
			// 
			this.m_btDiscard.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btDiscard.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btDiscard.ForeColor = System.Drawing.Color.Maroon;
			this.m_btDiscard.Location = new System.Drawing.Point(120, 227);
			this.m_btDiscard.Name = "m_btDiscard";
			this.m_btDiscard.Size = new System.Drawing.Size(64, 25);
			this.m_btDiscard.TabIndex = 10;
			this.m_btDiscard.Text = "Excluir";
			this.m_btDiscard.Click += new System.EventHandler(this.m_btDiscard_Click);
			// 
			// m_dpShow
			// 
			this.m_dpShow.CustomFormat = "dd/MM/yyyy HH:mm";
			this.m_dpShow.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_dpShow.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.m_dpShow.Location = new System.Drawing.Point(304, 20);
			this.m_dpShow.Name = "m_dpShow";
			this.m_dpShow.Size = new System.Drawing.Size(128, 20);
			this.m_dpShow.TabIndex = 5;
			this.m_dpShow.ValueChanged += new System.EventHandler(this.m_dpShow_ValueChanged);
			// 
			// m_lbDateShow
			// 
			this.m_lbDateShow.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbDateShow.ForeColor = System.Drawing.Color.Black;
			this.m_lbDateShow.Location = new System.Drawing.Point(248, 22);
			this.m_lbDateShow.Name = "m_lbDateShow";
			this.m_lbDateShow.Size = new System.Drawing.Size(60, 16);
			this.m_lbDateShow.TabIndex = 6;
			this.m_lbDateShow.Text = "Lembrar:";
			// 
			// m_lbMessage
			// 
			this.m_lbMessage.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbMessage.ForeColor = System.Drawing.Color.Black;
			this.m_lbMessage.Location = new System.Drawing.Point(11, 42);
			this.m_lbMessage.Name = "m_lbMessage";
			this.m_lbMessage.Size = new System.Drawing.Size(72, 16);
			this.m_lbMessage.TabIndex = 4;
			this.m_lbMessage.Text = "Mensagem:";
			// 
			// m_txtMessage
			// 
			this.m_txtMessage.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_txtMessage.Location = new System.Drawing.Point(8, 57);
			this.m_txtMessage.Multiline = true;
			this.m_txtMessage.Name = "m_txtMessage";
			this.m_txtMessage.Size = new System.Drawing.Size(422, 168);
			this.m_txtMessage.TabIndex = 1;
			this.m_txtMessage.Text = "";
			this.m_txtMessage.TextChanged += new System.EventHandler(this.m_txtMessage_TextChanged);
			// 
			// m_dpEvent
			// 
			this.m_dpEvent.CustomFormat = "dd/MM/yyyy HH:mm";
			this.m_dpEvent.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_dpEvent.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.m_dpEvent.Location = new System.Drawing.Point(81, 18);
			this.m_dpEvent.Name = "m_dpEvent";
			this.m_dpEvent.Size = new System.Drawing.Size(128, 20);
			this.m_dpEvent.TabIndex = 0;
			this.m_dpEvent.ValueChanged += new System.EventHandler(this.m_dpEvent_ValueChanged);
			// 
			// m_lbDateEvent
			// 
			this.m_lbDateEvent.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbDateEvent.ForeColor = System.Drawing.Color.Black;
			this.m_lbDateEvent.Location = new System.Drawing.Point(11, 21);
			this.m_lbDateEvent.Name = "m_lbDateEvent";
			this.m_lbDateEvent.Size = new System.Drawing.Size(80, 16);
			this.m_lbDateEvent.TabIndex = 3;
			this.m_lbDateEvent.Text = "Data Evento:";
			// 
			// frmMessage
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(450, 272);
			this.Controls.Add(this.m_gbMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmMessage";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Mensagem";
			this.Load += new System.EventHandler(this.frmMessage_Load);
			this.m_gbMain.ResumeLayout(false);
			this.m_gbMessageType.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmMessage_Load(object sender, System.EventArgs e)
				{
					vShowColor();
					OnCallLoadConfigurationMessageType();
					OnCallLoadData();
					m_btOk.Enabled = false;
				}
			#endregion
			#region Buttons	
				private void m_btDiscard_Click(object sender, System.EventArgs e)
				{
					if (m_bModificado = OnCallMessageDelete())
						this.Close();
				}

				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					if (m_bModificado = OnCallMessageSave())
						this.Close();
				}

				private void m_btCancel_Click(object sender, System.EventArgs e)
				{
					this.Close();
				}
			#endregion
			#region DataPickers
				private void m_dpShow_ValueChanged(object sender, System.EventArgs e)
				{
					m_btOk.Enabled = true;
				}

				private void m_dpEvent_ValueChanged(object sender, System.EventArgs e)
				{
					m_dpShow.Value = m_dpEvent.Value;
					m_btOk.Enabled = true;
				}
			#endregion
			#region CheckBoxes
				private void m_ckShow_CheckedChanged(object sender, System.EventArgs e)
				{
					m_btOk.Enabled = true;
				}
			#endregion
			#region TextBoxes
				private void m_txtMessage_TextChanged(object sender, System.EventArgs e)
				{
					m_btOk.Enabled = true;
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
	}
}
