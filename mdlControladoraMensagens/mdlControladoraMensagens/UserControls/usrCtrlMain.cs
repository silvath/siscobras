using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace mdlControladoraMensagens.UserControls
{
	/// <summary>
	/// Summary description for usrCtrlMain.
	/// </summary>
	public class usrCtrlMain : System.Windows.Forms.UserControl
	{
		#region Delegates
			public delegate void delCallMessageRefresh(bool bReloadMessages);
			public delegate void delCallLoadConfigurations(out double dWaitingTime,out int nTimeToUp,out int nTimeToStay,out int nTimeToDown,out double dTimeToRemark);
			public delegate void delCallSaveConfigurations(double dWaitingTime,int nTimeToUp,int nTimeToStay,int nTimeToDown,double dTimeToRemark);
		#endregion
		#region Events
			public event delCallMessageRefresh eCallMessageRefresh;
			public event delCallLoadConfigurations eCallLoadConfigurations;
			public event delCallSaveConfigurations eCallSaveConfigurations;
		#endregion
		#region Events Methods
			protected virtual void OnCallMessageRefresh()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallMessageRefresh != null)
					eCallMessageRefresh(true);
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			protected virtual void OnCallLoadConfigurations()
			{
				if (m_bEnabled)
				{
					m_bEnabled = false;
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					if (eCallLoadConfigurations != null)
					{
						int nTimeToUp,nTimeToStay,nTimeToDown;
						double dWaitingTime,dTimeToRemark;
						eCallLoadConfigurations(out dWaitingTime,out nTimeToUp,out nTimeToStay,out nTimeToDown,out dTimeToRemark);
						m_txtWaitingTime.Text = dWaitingTime.ToString();
						if (nTimeToUp != 0)
							m_txtToUp.Text = (((double)(nTimeToUp)) / 1000).ToString();
						else
							m_txtToUp.Text = nTimeToUp.ToString();
						if (nTimeToStay != 0)
							m_txtToStay.Text = (((double)(nTimeToStay)) / 1000).ToString();
						else
							m_txtToStay.Text = nTimeToStay.ToString();
						if (nTimeToDown != 0)
							m_txtToDown.Text = (((double)(nTimeToDown)) / 1000).ToString();
						else
							m_txtToDown.Text = nTimeToDown.ToString();
						m_txtToRemark.Text = dTimeToRemark.ToString();
					}
					this.Cursor = System.Windows.Forms.Cursors.Default;
					m_bEnabled = true;
				}
			}

			protected virtual void OnCallSaveConfigurations()
			{
				if (m_bEnabled)
				{
					m_bEnabled = false;
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					if (eCallSaveConfigurations != null)
					{
						int nTimeToUp = 0,nTimeToStay = 0,nTimeToDown = 0;
						double dWaitingTime = 0,dTimeToRemark = 0;
						try
						{
							dWaitingTime = double.Parse(m_txtWaitingTime.Text);
						}
						catch
						{
							dWaitingTime = 1;
						}
						try
						{
							nTimeToUp = ((int)(double.Parse(m_txtToUp.Text) * 1000));
						}
						catch
						{
							nTimeToUp = 1;
						}
						try
						{
							nTimeToStay = ((int)(double.Parse(m_txtToStay.Text) * 1000));
						}
						catch
						{
							nTimeToStay = 1;
						}
						try
						{
							nTimeToDown = ((int)(double.Parse(m_txtToDown.Text) * 1000));
						}
						catch
						{
							nTimeToDown = 1;
						}
						try
						{
							dTimeToRemark = double.Parse(m_txtToRemark.Text);
						}
						catch
						{
							dTimeToRemark = 1;
						}
						if (nTimeToUp <= 0)
							nTimeToUp = 500;
						if (nTimeToStay <= 0)
							nTimeToStay = 500;
						if (nTimeToDown <= 0)
							nTimeToDown = 500;
						eCallSaveConfigurations(dWaitingTime,nTimeToUp,nTimeToStay,nTimeToDown,dTimeToRemark);
					}
					this.Cursor = System.Windows.Forms.Cursors.Default;
					m_bEnabled = true;
				}
			}
		#endregion

		#region Atributes
			private bool m_bEnabled = true;
			private System.Windows.Forms.Label m_lbSiscoMensagem;
			private System.Windows.Forms.Label m_lbWaitingTime;
			private mdlComponentesGraficos.TextBox m_txtWaitingTime;
			private System.Windows.Forms.GroupBox m_gbTimes;
			private System.Windows.Forms.Label m_lbToStaySegs;
			private mdlComponentesGraficos.TextBox m_txtToStay;
			private System.Windows.Forms.Label m_lbToStay;
			private System.Windows.Forms.Label m_lbToDownSegs;
			private mdlComponentesGraficos.TextBox m_txtToDown;
			private System.Windows.Forms.Label m_lbToDown;
			private System.Windows.Forms.Label m_lbToUpSegs;
			private mdlComponentesGraficos.TextBox m_txtToUp;
			private System.Windows.Forms.Label m_lbToUp;
			private System.Windows.Forms.Label m_lbWaitingTimeSegs;
			private System.Windows.Forms.Label m_lbToRemark;
			private mdlComponentesGraficos.TextBox m_txtToRemark;
			private System.Windows.Forms.Label m_lbToRemarkMin;
			private System.ComponentModel.Container components = null;
		#endregion
		#region Constructors and Destructors
			public usrCtrlMain()
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
			this.m_lbSiscoMensagem = new System.Windows.Forms.Label();
			this.m_lbWaitingTime = new System.Windows.Forms.Label();
			this.m_txtWaitingTime = new mdlComponentesGraficos.TextBox();
			this.m_gbTimes = new System.Windows.Forms.GroupBox();
			this.m_lbToRemarkMin = new System.Windows.Forms.Label();
			this.m_lbToStaySegs = new System.Windows.Forms.Label();
			this.m_txtToStay = new mdlComponentesGraficos.TextBox();
			this.m_lbToStay = new System.Windows.Forms.Label();
			this.m_lbToDownSegs = new System.Windows.Forms.Label();
			this.m_txtToDown = new mdlComponentesGraficos.TextBox();
			this.m_lbToDown = new System.Windows.Forms.Label();
			this.m_lbToUpSegs = new System.Windows.Forms.Label();
			this.m_txtToUp = new mdlComponentesGraficos.TextBox();
			this.m_lbToUp = new System.Windows.Forms.Label();
			this.m_lbWaitingTimeSegs = new System.Windows.Forms.Label();
			this.m_txtToRemark = new mdlComponentesGraficos.TextBox();
			this.m_lbToRemark = new System.Windows.Forms.Label();
			this.m_gbTimes.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_lbSiscoMensagem
			// 
			this.m_lbSiscoMensagem.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbSiscoMensagem.Location = new System.Drawing.Point(89, 15);
			this.m_lbSiscoMensagem.Name = "m_lbSiscoMensagem";
			this.m_lbSiscoMensagem.Size = new System.Drawing.Size(104, 24);
			this.m_lbSiscoMensagem.TabIndex = 1;
			this.m_lbSiscoMensagem.Text = "Intervalos";
			// 
			// m_lbWaitingTime
			// 
			this.m_lbWaitingTime.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbWaitingTime.Location = new System.Drawing.Point(7, 19);
			this.m_lbWaitingTime.Name = "m_lbWaitingTime";
			this.m_lbWaitingTime.Size = new System.Drawing.Size(99, 16);
			this.m_lbWaitingTime.TabIndex = 4;
			this.m_lbWaitingTime.Text = "Entre varreduras";
			// 
			// m_txtWaitingTime
			// 
			this.m_txtWaitingTime.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_txtWaitingTime.Location = new System.Drawing.Point(127, 16);
			this.m_txtWaitingTime.Name = "m_txtWaitingTime";
			this.m_txtWaitingTime.OnlyNumbers = true;
			this.m_txtWaitingTime.Size = new System.Drawing.Size(40, 20);
			this.m_txtWaitingTime.TabIndex = 2;
			this.m_txtWaitingTime.Text = "";
			this.m_txtWaitingTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.m_txtWaitingTime.TextChanged += new System.EventHandler(this.m_txtWaitingTime_TextChanged);
			// 
			// m_gbTimes
			// 
			this.m_gbTimes.Controls.Add(this.m_lbToRemarkMin);
			this.m_gbTimes.Controls.Add(this.m_lbToStaySegs);
			this.m_gbTimes.Controls.Add(this.m_txtToStay);
			this.m_gbTimes.Controls.Add(this.m_lbToStay);
			this.m_gbTimes.Controls.Add(this.m_lbToDownSegs);
			this.m_gbTimes.Controls.Add(this.m_txtToDown);
			this.m_gbTimes.Controls.Add(this.m_lbToDown);
			this.m_gbTimes.Controls.Add(this.m_lbToUpSegs);
			this.m_gbTimes.Controls.Add(this.m_txtToUp);
			this.m_gbTimes.Controls.Add(this.m_lbToUp);
			this.m_gbTimes.Controls.Add(this.m_lbWaitingTimeSegs);
			this.m_gbTimes.Controls.Add(this.m_lbWaitingTime);
			this.m_gbTimes.Controls.Add(this.m_txtWaitingTime);
			this.m_gbTimes.Controls.Add(this.m_txtToRemark);
			this.m_gbTimes.Controls.Add(this.m_lbToRemark);
			this.m_gbTimes.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbTimes.Location = new System.Drawing.Point(33, 55);
			this.m_gbTimes.Name = "m_gbTimes";
			this.m_gbTimes.Size = new System.Drawing.Size(224, 128);
			this.m_gbTimes.TabIndex = 6;
			this.m_gbTimes.TabStop = false;
			// 
			// m_lbToRemarkMin
			// 
			this.m_lbToRemarkMin.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbToRemarkMin.Location = new System.Drawing.Point(176, 102);
			this.m_lbToRemarkMin.Name = "m_lbToRemarkMin";
			this.m_lbToRemarkMin.Size = new System.Drawing.Size(40, 16);
			this.m_lbToRemarkMin.TabIndex = 17;
			this.m_lbToRemarkMin.Text = "min";
			// 
			// m_lbToStaySegs
			// 
			this.m_lbToStaySegs.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbToStaySegs.Location = new System.Drawing.Point(176, 58);
			this.m_lbToStaySegs.Name = "m_lbToStaySegs";
			this.m_lbToStaySegs.Size = new System.Drawing.Size(40, 16);
			this.m_lbToStaySegs.TabIndex = 15;
			this.m_lbToStaySegs.Text = "seg";
			// 
			// m_txtToStay
			// 
			this.m_txtToStay.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_txtToStay.Location = new System.Drawing.Point(127, 57);
			this.m_txtToStay.Name = "m_txtToStay";
			this.m_txtToStay.OnlyNumbers = true;
			this.m_txtToStay.Size = new System.Drawing.Size(40, 20);
			this.m_txtToStay.TabIndex = 4;
			this.m_txtToStay.Text = "";
			this.m_txtToStay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.m_txtToStay.TextChanged += new System.EventHandler(this.m_txtToStay_TextChanged);
			// 
			// m_lbToStay
			// 
			this.m_lbToStay.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbToStay.Location = new System.Drawing.Point(8, 60);
			this.m_lbToStay.Name = "m_lbToStay";
			this.m_lbToStay.Size = new System.Drawing.Size(96, 16);
			this.m_lbToStay.TabIndex = 13;
			this.m_lbToStay.Text = "De permanência";
			// 
			// m_lbToDownSegs
			// 
			this.m_lbToDownSegs.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbToDownSegs.Location = new System.Drawing.Point(176, 77);
			this.m_lbToDownSegs.Name = "m_lbToDownSegs";
			this.m_lbToDownSegs.Size = new System.Drawing.Size(40, 16);
			this.m_lbToDownSegs.TabIndex = 12;
			this.m_lbToDownSegs.Text = "seg";
			// 
			// m_txtToDown
			// 
			this.m_txtToDown.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_txtToDown.Location = new System.Drawing.Point(127, 78);
			this.m_txtToDown.Name = "m_txtToDown";
			this.m_txtToDown.OnlyNumbers = true;
			this.m_txtToDown.Size = new System.Drawing.Size(40, 20);
			this.m_txtToDown.TabIndex = 5;
			this.m_txtToDown.Text = "";
			this.m_txtToDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.m_txtToDown.TextChanged += new System.EventHandler(this.m_txtToDown_TextChanged);
			// 
			// m_lbToDown
			// 
			this.m_lbToDown.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbToDown.Location = new System.Drawing.Point(9, 80);
			this.m_lbToDown.Name = "m_lbToDown";
			this.m_lbToDown.Size = new System.Drawing.Size(79, 16);
			this.m_lbToDown.TabIndex = 10;
			this.m_lbToDown.Text = "De descida";
			// 
			// m_lbToUpSegs
			// 
			this.m_lbToUpSegs.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbToUpSegs.Location = new System.Drawing.Point(176, 38);
			this.m_lbToUpSegs.Name = "m_lbToUpSegs";
			this.m_lbToUpSegs.Size = new System.Drawing.Size(40, 16);
			this.m_lbToUpSegs.TabIndex = 9;
			this.m_lbToUpSegs.Text = "seg";
			// 
			// m_txtToUp
			// 
			this.m_txtToUp.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_txtToUp.Location = new System.Drawing.Point(127, 36);
			this.m_txtToUp.Name = "m_txtToUp";
			this.m_txtToUp.OnlyNumbers = true;
			this.m_txtToUp.Size = new System.Drawing.Size(40, 20);
			this.m_txtToUp.TabIndex = 3;
			this.m_txtToUp.Text = "";
			this.m_txtToUp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.m_txtToUp.TextChanged += new System.EventHandler(this.m_txtToUp_TextChanged);
			// 
			// m_lbToUp
			// 
			this.m_lbToUp.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbToUp.Location = new System.Drawing.Point(8, 40);
			this.m_lbToUp.Name = "m_lbToUp";
			this.m_lbToUp.Size = new System.Drawing.Size(106, 16);
			this.m_lbToUp.TabIndex = 7;
			this.m_lbToUp.Text = "De subida";
			// 
			// m_lbWaitingTimeSegs
			// 
			this.m_lbWaitingTimeSegs.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbWaitingTimeSegs.Location = new System.Drawing.Point(176, 19);
			this.m_lbWaitingTimeSegs.Name = "m_lbWaitingTimeSegs";
			this.m_lbWaitingTimeSegs.Size = new System.Drawing.Size(40, 16);
			this.m_lbWaitingTimeSegs.TabIndex = 6;
			this.m_lbWaitingTimeSegs.Text = "min";
			// 
			// m_txtToRemark
			// 
			this.m_txtToRemark.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_txtToRemark.Location = new System.Drawing.Point(127, 100);
			this.m_txtToRemark.Name = "m_txtToRemark";
			this.m_txtToRemark.OnlyNumbers = true;
			this.m_txtToRemark.Size = new System.Drawing.Size(40, 20);
			this.m_txtToRemark.TabIndex = 7;
			this.m_txtToRemark.Text = "";
			this.m_txtToRemark.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.m_txtToRemark.TextChanged += new System.EventHandler(this.m_txtToRemark_TextChanged);
			// 
			// m_lbToRemark
			// 
			this.m_lbToRemark.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbToRemark.Location = new System.Drawing.Point(8, 102);
			this.m_lbToRemark.Name = "m_lbToRemark";
			this.m_lbToRemark.Size = new System.Drawing.Size(128, 16);
			this.m_lbToRemark.TabIndex = 16;
			this.m_lbToRemark.Text = "De reapresentação";
			// 
			// usrCtrlMain
			// 
			this.Controls.Add(this.m_gbTimes);
			this.Controls.Add(this.m_lbSiscoMensagem);
			this.Name = "usrCtrlMain";
			this.Size = new System.Drawing.Size(280, 448);
			this.Load += new System.EventHandler(this.usrCtrlMain_Load);
			this.m_gbTimes.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void usrCtrlMain_Load(object sender, System.EventArgs e)
				{
					OnCallLoadConfigurations();
				}
			#endregion
			#region TextBoxes
				private void m_txtWaitingTime_TextChanged(object sender, System.EventArgs e)
				{
					OnCallSaveConfigurations();
				}

				private void m_txtToUp_TextChanged(object sender, System.EventArgs e)
				{
					OnCallSaveConfigurations();
				}

				private void m_txtToStay_TextChanged(object sender, System.EventArgs e)
				{
					OnCallSaveConfigurations();
				}

				private void m_txtToDown_TextChanged(object sender, System.EventArgs e)
				{
					OnCallSaveConfigurations();
				}

				private void m_txtToRemark_TextChanged(object sender, System.EventArgs e)
				{
					OnCallSaveConfigurations();
				}
			#endregion
			#region Buttons
				private void m_btMessageRefresh_Click(object sender, System.EventArgs e)
				{
					OnCallMessageRefresh();
				}
			#endregion
		#endregion
	}
}
