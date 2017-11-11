using System;
using System.ComponentModel;

namespace mdlComponentesGraficos
{
	/// <summary>
	/// Summary description for Button.
	/// </summary>
	public class Button : System.Windows.Forms.Button
	{
		#region Enum
			public enum ButtonType
			{
				None,
				Ok,
				Cancel
			}

			public enum VisualFormat
			{
				Default,
				Circle
			}

			public enum GradientSource
			{
				None,
				Color,
				Image
			}
		#endregion
		#region Atributos
			private Button.VisualFormat m_enumVisualFormat = Button.VisualFormat.Default;
			private Button.GradientSource m_enumGradientSource = Button.GradientSource.None;
			private static System.Drawing.StringFormat m_s_strfFormat = new System.Drawing.StringFormat();
			private System.Drawing.Color m_clrGradientStart = System.Drawing.Color.White;
		    private System.Drawing.Color m_clrGradientEnd = System.Drawing.Color.Black;
			private System.Drawing.Drawing2D.LinearGradientMode m_2dMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;

			private ButtonType m_enumButtonType = ButtonType.None;
		#endregion
		#region Properties
			[DefaultValue(ButtonType.None)]
			public ButtonType Type
			{
				get
				{
					return(m_enumButtonType);
				}
				set
				{
					m_enumButtonType = value;
					switch(m_enumButtonType)
					{
						case ButtonType.Ok:
							this.Image = new FormResources().ImageOkLeave;
							break;
						case ButtonType.Cancel:
							this.Image = new FormResources().ImageCancelLeave;
							break;
					}
				}
			}

			[DefaultValue(VisualFormat.Default)]
			public Button.VisualFormat VisualForm
			{
				get
				{
					return (m_enumVisualFormat);
				}
				set
				{
					m_enumVisualFormat = value;
					if (this.IsHandleCreated && this.Visible) 
					{
						Invalidate();
					}
				}
			}  

			[DefaultValue(GradientSource.None)]
			public Button.GradientSource Gradient
			{
				get
				{
					return(m_enumGradientSource);
				}
				set
				{
					m_enumGradientSource = value;
					if (this.IsHandleCreated && this.Visible) 
					{
						Invalidate();
					}
				}
			}

			[DefaultValue(System.Drawing.Drawing2D.LinearGradientMode.Horizontal)]
			public System.Drawing.Drawing2D.LinearGradientMode GradientMode
			{
				get
				{
					return(m_2dMode);
				}
				set
				{
					m_2dMode = value;
					if (this.IsHandleCreated && this.Visible) 
					{
						Invalidate();
					}
				}
			}

			public System.Drawing.Color GradiendColorStart
			{
				get
				{
					return(m_clrGradientStart);
				}
				set
				{
					m_clrGradientStart = value;
					if (this.IsHandleCreated && this.Visible) 
					{
						Invalidate();
					}
				}
			}

			public System.Drawing.Color GradiendColorEnd
			{
				get
				{
					return(m_clrGradientEnd);
				}
				set
				{
					m_clrGradientEnd = value;
					if (this.IsHandleCreated && this.Visible) 
					{
						Invalidate();
					}
				}
			}
		#endregion
		#region Constructor and Destructors
		public Button() : base() 
		{
			// initialize our colors 
			m_s_strfFormat.Alignment = System.Drawing.StringAlignment.Center;
			m_s_strfFormat.LineAlignment = System.Drawing.StringAlignment.Center;
		}

		#endregion

		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter (e);
			if (this.Type == ButtonType.Ok)
			{
				this.Image = new FormResources().ImageOkEnter;
			}
			else if (this.Type == ButtonType.Cancel)
			{
				this.Image = new FormResources().ImageCancelEnter;
			}
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave (e);
			if (this.Type == ButtonType.Ok)
			{
				this.Image = new FormResources().ImageOkLeave;
			}
			else if (this.Type == ButtonType.Cancel)
			{
				this.Image = new FormResources().ImageCancelLeave;
			}
		}

		#region OnPaint
		protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
		{
//			if (this.Type != ButtonType.None)
//			{
//				if (this.Parent != null)
//					e.Graphics.DrawRectangle(new System.Drawing.Pen(this.Parent.BackColor),this.Location.X,this.Location.Y,this.Width,this.Height);
//				e.Graphics.DrawImage(this.Image,this.Location.X,this.Location.Y,this.Width,this.Height);
//				return;
//			}
			base.OnPaint(e);
			if (m_enumGradientSource != Button.GradientSource.None)
			{
				System.Drawing.Graphics g = e.Graphics;
				System.Drawing.Rectangle clientRect = this.ClientRectangle;
				clientRect.Inflate(-1,-1);
				System.Drawing.Brush backgroundBrush;
				switch (m_enumGradientSource)
				{
					case Button.GradientSource.Color:
						backgroundBrush = new System.Drawing.Drawing2D.LinearGradientBrush(new System.Drawing.Rectangle(clientRect.X,clientRect.Y,clientRect.Width,clientRect.Height),this.m_clrGradientStart,this.m_clrGradientEnd,this.m_2dMode);
						g.FillRectangle(backgroundBrush, clientRect);
						g.DrawString(this.Text,this.Font,new System.Drawing.SolidBrush(this.ForeColor),clientRect,m_s_strfFormat);
						break;
					case Button.GradientSource.Image:
						if (this.BackgroundImage != null)
						{
							backgroundBrush = new System.Drawing.TextureBrush(this.BackgroundImage);
							g.FillRectangle(backgroundBrush, clientRect);
							g.DrawString(this.Text,this.Font,new System.Drawing.SolidBrush(this.ForeColor),clientRect,m_s_strfFormat);
						}
						break;
				}
			}
		}
		#endregion
	}
}
