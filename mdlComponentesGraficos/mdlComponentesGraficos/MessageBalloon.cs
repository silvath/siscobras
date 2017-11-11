using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections;
using mdlComponentesGraficos.BalloonTip;

namespace mdlComponentesGraficos
{
	public class MessageBalloon : mdlComponentesGraficos.BalloonTip.BalloonWindow
	{
		private WindowsHook windowsHook;
		private System.ComponentModel.IContainer components = null;

		#region Constants
		const int CLOSEBUTTON_WIDTH = 14;
		const int CLOSEBUTTON_HEIGHT = 14;
		const uint SHOWCLOSEBUTTON = 0x1;
		const uint CLOSEONMOUSECLICK = 0x2;
		const uint CLOSEONKEYPRESS = 0x4;
		const uint CLOSEONMOUSEMOVE = 0x10;
		const uint CLOSEONDEACTIVATE = 0x20;
		const uint ENABLETIMEOUT = 0x40;
		const int WM_ACTIVATEAPP = 0x001C;
		#endregion
		
		#region Fields
		private uint flags = CLOSEONMOUSECLICK | CLOSEONKEYPRESS | CLOSEONDEACTIVATE;
		private string content = String.Empty;
		private Font captionFont;
		private Size headerSize;
		private System.Windows.Forms.Button closeButton;
		private System.Windows.Forms.Timer timer1;
		#endregion

		public MessageBalloon()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}
		
		#region Utility functions
		private void SetBoolProp(uint prop, bool b)
		{
			if(b)
				flags |= prop;
			else
				flags &= ~prop;
		}
		
		private bool GetBoolProp(uint prop)
		{
			return (flags & prop) != 0;
		}
		#endregion
		
		#region Public Properties
		
		[Category("Balloon")]
		public int Timeout
		{
			get
			{
				return timer1.Interval;
			}
			set
			{
				timer1.Interval = value;
			}
		}
		
		[Category("Balloon")]
		public bool ShowCloseButton
		{
			get
			{
				return Controls.Contains(closeButton);
			}
			set
			{
				if (!value)
				{
					if (Controls.Contains(closeButton))
						Controls.Remove(closeButton);
				}
				else
				{
					if (!Controls.Contains(closeButton))
						Controls.Add(closeButton);
				}

				SetBoolProp(SHOWCLOSEBUTTON, value);
			}
		}

		[Category("Balloon")]
		public bool EnableTimeout
		{
			get
			{
				return GetBoolProp(ENABLETIMEOUT);
			}
			set
			{
				SetBoolProp(ENABLETIMEOUT, value);
			}
		}

		[Category("Balloon")]
		public bool CloseOnMouseClick
		{
			get
			{
				return GetBoolProp(CLOSEONMOUSECLICK);
			}
			set
			{
				SetBoolProp(CLOSEONMOUSECLICK, value);
			}
		}

		[Category("Balloon")]
		public bool CloseOnKeyPress
		{
			get
			{
				return GetBoolProp(CLOSEONKEYPRESS);
			}
			set
			{
				SetBoolProp(CLOSEONKEYPRESS, value);
			}
		}

		[Category("Balloon")]
		public bool CloseOnMouseMove
		{
			get
			{
				return GetBoolProp(CLOSEONMOUSEMOVE);
			}
			set
			{
				SetBoolProp(CLOSEONMOUSEMOVE, value);
			}
		}
		
		[Category("Balloon")]
		public bool CloseOnDeactivate
		{
			get
			{
				return GetBoolProp(CLOSEONDEACTIVATE);
			}
			set
			{
				SetBoolProp(CLOSEONDEACTIVATE, value);
			}
		}

		[Category("Balloon")]
		public string Content
		{
			get
			{
				return content;
			}
			set
			{
				content = value;
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
			}
		}

		[Category("Balloon")]
		public string Caption
		{
			get
			{
				string ret = this.Text;
				return (ret == null) ? String.Empty : ret;
			}
			set
			{
				this.Text = value;
			}
		}
	
		[Category("Balloon")]
		public Font CaptionFont
		{
			get
			{
				if (captionFont == null)
					captionFont = new Font(this.Font, FontStyle.Bold);

				return captionFont;
			}
			set
			{
				captionFont = value;
			}
		}
		#endregion

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Calculate size
		protected Size CalcClientSize()
		{
			System.Drawing.Size size = Size.Empty;

			using(System.Drawing.Graphics g = this.CreateGraphics())
			{
				if (this.Icon != null)
					size = this.Icon.Size;

				if (this.ShowCloseButton)
				{
					if (size.Width != 0)
						size.Width += TIPMARGIN;
					
					size.Width += (CLOSEBUTTON_WIDTH + TIPMARGIN);
					size.Height = Math.Max(size.Height, CLOSEBUTTON_HEIGHT);
				}
				
				if (this.Caption.Length != 0)
				{
					if (size.Width != 0)
						size.Width += TIPMARGIN;
					
					System.Drawing.Size captionSize = Size.Ceiling(g.MeasureString(Caption, this.CaptionFont));
					size.Width += captionSize.Width;
					size.Height = Math.Max(captionSize.Height, size.Height);
				}
				
				headerSize = size;

				string text = this.Content;
				
				if ((text != null) && (text.Length != 0))
				{
					size.Height += TIPMARGIN;

					System.Drawing.Size textSize = Size.Ceiling(g.MeasureString(text, this.Font));
					size.Height += textSize.Height;
					size.Width = Math.Max(textSize.Width, headerSize.Width);
					headerSize.Width = size.Width;
				}
			}

			return size;
		}
		#endregion

		#region Client Area Drawing
		
		private void Draw(Graphics g)
		{
			Rectangle drawingRect = this.ClientRectangle;

			string content = this.Content;

			if (content.Length != 0)
			{
				RectangleF textRect = new RectangleF(0, headerSize.Height + TIPMARGIN, drawingRect.Width, drawingRect.Height - headerSize.Height - TIPMARGIN);
				Brush b = new SolidBrush(this.ForeColor);
				g.DrawString(content, this.Font, b, textRect);
				b.Dispose();
			}

			// calc & draw icon
			if(this.Icon != null)
			{	
				g.DrawIcon(this.Icon, 0, 0);
				drawingRect.X += (this.Icon.Width);
				drawingRect.Width -= (this.Icon.Width);
			}

			// calc & draw close button
			if(this.ShowCloseButton)
			{
				drawingRect.Width -= (CLOSEBUTTON_WIDTH);
			}
			
			string caption = this.Caption;

			if (caption.Length != 0)
			{
				drawingRect.X += TIPMARGIN;
				drawingRect.Width -= TIPMARGIN;

				//StringFormat sf = new StringFormat();
				//sf.Alignment = StringAlignment.Center;

				Brush b = new SolidBrush(this.ForeColor);
				
				g.DrawString(caption, this.CaptionFont, b, (RectangleF)drawingRect);//, sf); 

				b.Dispose();
				//sf.Dispose();
			}
		}
		
		protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
		{
			Draw(e.Graphics);
		}

		#endregion

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MessageBalloon));
			this.windowsHook = new mdlComponentesGraficos.BalloonTip.WindowsHook(this.components);
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.closeButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// windowsHook
			// 
			this.windowsHook.ThreadID = 0;
			// 
			// timer1
			// 
			this.timer1.Interval = 5000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// closeButton
			// 
			this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.closeButton.Image = ((System.Drawing.Image)(resources.GetObject("closeButton.Image")));
			this.closeButton.Location = new System.Drawing.Point(136, 0);
			this.closeButton.Name = "closeButton";
			this.closeButton.Size = new System.Drawing.Size(14, 14);
			this.closeButton.TabIndex = 1;
			// 
			// MessageBalloon
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(152, 94);
			this.Controls.Add(this.closeButton);
			this.Name = "MessageBalloon";
			this.ResumeLayout(false);

		}
		#endregion
		
		protected override void OnLoad(System.EventArgs e)
		{
			this.ClientSize = CalcClientSize();
			
			if ((this.flags != 0) && (this.flags != SHOWCLOSEBUTTON))
			{	
				if (this.CloseOnKeyPress)
					this.windowsHook.KeyBoardHook += new KeyBoardHookEventHandler(this.windowsHook_KeyBoardHook);
				
				if ((this.CloseOnMouseClick) || (this.CloseOnMouseMove))
					this.windowsHook.MouseHook += new MouseHookEventHandler(this.windowsHook_MouseHook);
				
				windowsHook.HookCurrentThread();
			}
			
			if (this.EnableTimeout)
				timer1.Start();

			base.OnLoad(e);
		}
	
		private void windowsHook_KeyBoardHook(object sender, KeyBoardHookEventArgs e)
		{
			this.Close();
		}

		private void windowsHook_MouseHook(object sender, MouseHookEventArgs e)
		{
			switch(e.Message)
			{
				case MouseMessages.LButtonDblClk:
				case MouseMessages.LButtonDown:
				case MouseMessages.LButtonUp:
				case MouseMessages.MButtonDblClk:
				case MouseMessages.MButtonDown:
				case MouseMessages.MButtonUp:
				case MouseMessages.RButtonDblClk:
				case MouseMessages.RButtonDown:
				case MouseMessages.RButtonUp:
				case MouseMessages.XButtonDblClk:
				case MouseMessages.XButtonDown:
					if (this.CloseOnMouseClick)
						Close();
					break;
				case MouseMessages.MouseMove:
					if (this.CloseOnMouseMove)
						Close();
					break;
			}
		}

		protected virtual void OnDeactivateApp(System.EventArgs e)
		{
			if (this.CloseOnDeactivate)
				Close();
		}
		
		protected override void WndProc(ref Message m)
		{
			if ((m.Msg == WM_ACTIVATEAPP) && (m.WParam == IntPtr.Zero))
			{
				OnDeactivateApp(EventArgs.Empty);
			}
			else
				base.WndProc(ref m);
		}

		protected override void OnClosed(System.EventArgs e)
		{
			windowsHook.Dispose();
			base.OnClosed(e);
		}

		private void closeButton_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			Close();
		}
	}
}
