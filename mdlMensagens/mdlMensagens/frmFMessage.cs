using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlMensagens
{
	internal class frmFMessage : System.Windows.Forms.Form
	{
		#region Atributos
		#region Negocio
		string m_strText;
		int m_nMinSize, m_nNumButtons;
		MessageBoxIcon m_Icon;
		#endregion
		#region Formulario
		private System.Windows.Forms.Button m_btn1;
		private System.Windows.Forms.Button m_btn2;
		private System.Windows.Forms.Label m_lbMsg;
		private System.Windows.Forms.Button m_btn3;
		#endregion
		#endregion
		#region Constructor & Destructor
		public frmFMessage()
		{
			InitializeComponent();
		}

		protected override void Dispose( bool disposing )
		{
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
			this.m_btn1 = new System.Windows.Forms.Button();
			this.m_btn2 = new System.Windows.Forms.Button();
			this.m_lbMsg = new System.Windows.Forms.Label();
			this.m_btn3 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// m_btn1
			// 
			this.m_btn1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.m_btn1.Location = new System.Drawing.Point(251, 65);
			this.m_btn1.Name = "m_btn1";
			this.m_btn1.Size = new System.Drawing.Size(76, 23);
			this.m_btn1.TabIndex = 0;
			this.m_btn1.Text = "btn1";
			// 
			// m_btn2
			// 
			this.m_btn2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.m_btn2.Location = new System.Drawing.Point(331, 65);
			this.m_btn2.Name = "m_btn2";
			this.m_btn2.Size = new System.Drawing.Size(76, 23);
			this.m_btn2.TabIndex = 1;
			this.m_btn2.Text = "btn2";
			// 
			// m_lbMsg
			// 
			this.m_lbMsg.Location = new System.Drawing.Point(65, 16);
			this.m_lbMsg.Name = "m_lbMsg";
			this.m_lbMsg.Size = new System.Drawing.Size(423, 16);
			this.m_lbMsg.TabIndex = 2;
			this.m_lbMsg.Text = "Message";
			// 
			// m_btn3
			// 
			this.m_btn3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.m_btn3.Location = new System.Drawing.Point(411, 65);
			this.m_btn3.Name = "m_btn3";
			this.m_btn3.Size = new System.Drawing.Size(76, 23);
			this.m_btn3.TabIndex = 4;
			this.m_btn3.Text = "btn3";
			// 
			// frmFMessage
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(490, 90);
			this.ControlBox = false;
			this.Controls.Add(this.m_btn3);
			this.Controls.Add(this.m_lbMsg);
			this.Controls.Add(this.m_btn2);
			this.Controls.Add(this.m_btn1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "frmFMessage";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Titulo";
			this.TopMost = true;
			this.ResumeLayout(false);

		}
		#endregion

		#region Show´s
		public DialogResult Show (string strTitulo, string strTexto, MessageBoxButtons Buttons, MessageBoxIcon Icon) 
		{
			bool ret = SetupIcon (Icon);

			Text = strTitulo;
			m_strText = strTexto;

			FormatText();
			if (ret) 
			{
				SetupText (65, 423);
			} 
			else 
			{
				SetupText (16, 472);
			}

			SetupButtons (Buttons);

			return ShowDialog();
		}
		#endregion
		#region Private
		private bool SetupIcon (MessageBoxIcon Icon) 
		{
			switch (Icon) 
			{
				case MessageBoxIcon.Error:
				case MessageBoxIcon.Exclamation:
				case MessageBoxIcon.Question:
				case MessageBoxIcon.Information:
					m_Icon = Icon;
					break;

				case MessageBoxIcon.None:
					m_Icon = Icon;
					return false;
			}

			return true;
		}

		private void SetupText (int nLeft, int nWidth)
		{
			m_lbMsg.Left = nLeft;
			m_lbMsg.Width = nWidth;
		}

		private void SetupButtons (MessageBoxButtons Buttons) 
		{
			switch (Buttons) 
			{
				case MessageBoxButtons.AbortRetryIgnore:
					m_nMinSize = 268;
					m_nNumButtons = 3;

					m_btn1.Text = "&Abortar";
					m_btn2.Text = "&Tentar";
					m_btn3.Text = "&Ignorar";

					m_btn1.Visible = true;
					m_btn2.Visible = true;
					m_btn3.Visible = true;

					m_btn1.DialogResult = DialogResult.Abort;
					m_btn2.DialogResult = DialogResult.Retry;
					m_btn3.DialogResult = DialogResult.Ignore;

					AcceptButton = m_btn1;
					CancelButton = null;
					break;

				case MessageBoxButtons.OK:
					m_nMinSize = 108;
					m_nNumButtons = 1;

					m_btn3.Text = "&OK";

					m_btn1.Visible = false;
					m_btn2.Visible = false;
					m_btn3.Visible = true;

					AcceptButton = m_btn3;
					m_btn3.DialogResult = DialogResult.OK;

					CancelButton = null;
					break;

				case MessageBoxButtons.OKCancel:
					m_nMinSize = 188;
					m_nNumButtons = 2;

					m_btn2.Text = "&OK";
					m_btn3.Text = "&Cancelar";

					m_btn1.Visible = false;
					m_btn2.Visible = true;
					m_btn3.Visible = true;

					m_btn2.DialogResult = DialogResult.OK;
					m_btn3.DialogResult = DialogResult.Cancel;

					AcceptButton = m_btn2;
					CancelButton = m_btn3;
					break;

				case MessageBoxButtons.RetryCancel:
					m_nMinSize = 188;
					m_nNumButtons = 2;

					m_btn2.Text = "&Tentar";
					m_btn3.Text = "&Cancelar";

					m_btn1.Visible = false;
					m_btn2.Visible = true;
					m_btn3.Visible = true;

					m_btn2.DialogResult = DialogResult.Retry;
					m_btn3.DialogResult = DialogResult.Cancel;

					AcceptButton = m_btn2;
					CancelButton = m_btn3;
					break;

				case MessageBoxButtons.YesNo:
					m_nMinSize = 188;
					m_nNumButtons = 2;

					m_btn2.Text = "&Sim";
					m_btn3.Text = "&Não";

					m_btn1.Visible = false;
					m_btn2.Visible = true;
					m_btn3.Visible = true;

					m_btn2.DialogResult = DialogResult.Yes;
					m_btn3.DialogResult = DialogResult.No;

					AcceptButton = m_btn2;
					CancelButton = m_btn3;
					break;

				case MessageBoxButtons.YesNoCancel:
					m_nMinSize = 268;
					m_nNumButtons = 3;

					m_btn1.Text = "&Sim";
					m_btn2.Text = "&Não";
					m_btn3.Text = "&Cancelar";

					m_btn1.Visible = true;
					m_btn2.Visible = true;
					m_btn3.Visible = true;

					m_btn1.DialogResult = DialogResult.Yes;
					m_btn2.DialogResult = DialogResult.No;
					m_btn3.DialogResult = DialogResult.Cancel;

					AcceptButton = m_btn1;
					CancelButton = m_btn3;
					break;
			}
		}

		private void FormatText() 
		{
			m_strText = m_strText.Replace ("\\n", "\n");
			m_strText = m_strText.Trim();
		}
		#endregion
		#region Overloaded Methods
		protected override void OnPaint(PaintEventArgs e)
		{
			Region[] regions;
			RectangleF layoutRect = new RectangleF (m_lbMsg.Left, m_lbMsg.Top, m_lbMsg.Width, 500);
			CharacterRange[] characterRanges = {
												   new CharacterRange(0, m_strText.Length)
											   };
			StringFormat stringFormat = new StringFormat();
			stringFormat.FormatFlags = StringFormatFlags.FitBlackBox;
			stringFormat.SetMeasurableCharacterRanges(characterRanges);
			int size;

			regions = e.Graphics.MeasureCharacterRanges (m_strText, m_lbMsg.Font, layoutRect, stringFormat);

			layoutRect = regions[0].GetBounds (e.Graphics);
			layoutRect.Inflate(0,2);

			m_lbMsg.Height = (int) layoutRect.Height;
			m_lbMsg.Text = m_strText;
			Height = 112 + (m_lbMsg.Height - 16);

			switch (m_nNumButtons) 
			{
				case 1:
					m_btn3.Left = Width / 2 - 38;
					break;

				case 2:
					m_btn2.Left = Width / 2 - 78;
					m_btn3.Left = Width / 2 + 4;
					break;

				case 3:
					m_btn2.Left = Width / 2 - 38;
					m_btn1.Left = m_btn2.Left - 80;
					m_btn3.Left = m_btn2.Left + m_btn2.Width + 4;
					break;
			}

			size = (int) layoutRect.Left + (int) layoutRect.Width + 16;
			if (size < m_nMinSize) 
			{
				if (Width != m_nMinSize) 
				{
					Left = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width / 2 - (m_nMinSize / 2);
				}
				Width = m_nMinSize;
			} 
			else if (size > 500) 
			{
				if (Width != 500) 
				{
					Left = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width / 2 - 250;
				}
				Width = 500;
			} 
			else 
			{
				if (Width != size) 
				{
					Left = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width / 2 - (size / 2);
				}
				Width = size;
			}

			switch (m_Icon) 
			{
				case MessageBoxIcon.Error:
					e.Graphics.DrawIcon (System.Drawing.SystemIcons.Error, 16, 16);
					break;
				case MessageBoxIcon.Exclamation:
					e.Graphics.DrawIcon (System.Drawing.SystemIcons.Exclamation, 16, 16);
					break;
				case MessageBoxIcon.Question:
					e.Graphics.DrawIcon (System.Drawing.SystemIcons.Question, 16, 16);
					break;
				case MessageBoxIcon.Information:
					e.Graphics.DrawIcon (System.Drawing.SystemIcons.Information, 16, 16);
					break;
			}

			base.OnPaint (e);
		}
		#endregion
	}
}
