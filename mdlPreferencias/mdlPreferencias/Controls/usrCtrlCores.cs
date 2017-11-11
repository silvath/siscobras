using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace mdlPreferencias.Cores
{
	/// <summary>
	/// Summary description for usrCtrlCores.
	/// </summary>
	internal class usrCtrlCores : System.Windows.Forms.UserControl
	{
		#region Atributos
		private System.Windows.Forms.Button m_btCoresPrimarias;
		private System.Windows.Forms.Button m_btCoresSecundarias;
		private System.Windows.Forms.Label m_lCoresPrimarias;
		private System.Windows.Forms.Label m_lCoresSecundarias;
		private System.Windows.Forms.PictureBox m_pcbxBanner;
		private System.Windows.Forms.GroupBox m_gbPictureBox;
		private System.Windows.Forms.Timer m_tmCores;
		private System.Windows.Forms.ToolTip m_ttCores;
		private System.ComponentModel.IContainer components;
		#endregion		

		#region Construtores & Destrutores
		public usrCtrlCores()
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

		#region Delegate
		public delegate void delCallCarregaDadosInterface(ref System.Windows.Forms.Button btPrimaria, ref System.Windows.Forms.Button btSecundaria);
		public delegate void delCallAlteraCorPrimaria(ref System.Windows.Forms.Button btPrimaria);
		public delegate void delCallAlteraCorSecundaria(ref System.Windows.Forms.Button btSecundaria);
		// Banner
		public delegate void delCallAlteraBanner(ref System.Windows.Forms.PictureBox pbBanner);
		public delegate void delCallClickBanner();
		#endregion
		#region Events
		public event delCallCarregaDadosInterface eCallCarregaDadosInterface;
		public event delCallAlteraCorPrimaria eCallAlteraCorPrimaria;
		public event delCallAlteraCorSecundaria eCallAlteraCorSecundaria;
		// Banner
		public event delCallAlteraBanner eCallAlteraBanner;
		public event delCallClickBanner eCallClickBanner;
		#endregion
		#region Events Methods
		protected virtual void OnCallCarregaDadosInterface()
		{
			if (eCallCarregaDadosInterface != null)
				eCallCarregaDadosInterface(ref m_btCoresPrimarias, ref m_btCoresSecundarias);
		}
		protected virtual void OnCallAlteraCorPrimaria()
		{
			if (eCallAlteraCorPrimaria != null)
				eCallAlteraCorPrimaria(ref m_btCoresPrimarias);
		}
		protected virtual void OnCallAlteraCorSecundaria()
		{
			if (eCallAlteraCorSecundaria != null)
				eCallAlteraCorSecundaria(ref m_btCoresSecundarias);
		}
		protected virtual void OnCallAlteraBanner()
		{
			if (eCallAlteraBanner != null)
				eCallAlteraBanner(ref m_pcbxBanner);
		}
		protected virtual void OnCallClickBanner()
		{
			if (eCallClickBanner != null)
				eCallClickBanner();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(usrCtrlCores));
			this.m_btCoresPrimarias = new System.Windows.Forms.Button();
			this.m_btCoresSecundarias = new System.Windows.Forms.Button();
			this.m_lCoresPrimarias = new System.Windows.Forms.Label();
			this.m_lCoresSecundarias = new System.Windows.Forms.Label();
			this.m_gbPictureBox = new System.Windows.Forms.GroupBox();
			this.m_pcbxBanner = new System.Windows.Forms.PictureBox();
			this.m_tmCores = new System.Windows.Forms.Timer(this.components);
			this.m_ttCores = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbPictureBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_btCoresPrimarias
			// 
			this.m_btCoresPrimarias.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCoresPrimarias.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCoresPrimarias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_btCoresPrimarias.Location = new System.Drawing.Point(32, 16);
			this.m_btCoresPrimarias.Name = "m_btCoresPrimarias";
			this.m_btCoresPrimarias.Size = new System.Drawing.Size(25, 25);
			this.m_btCoresPrimarias.TabIndex = 1;
			this.m_ttCores.SetToolTip(this.m_btCoresPrimarias, "Cor");
			this.m_btCoresPrimarias.Click += new System.EventHandler(this.m_btCoresPrimarias_Click);
			// 
			// m_btCoresSecundarias
			// 
			this.m_btCoresSecundarias.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCoresSecundarias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_btCoresSecundarias.Location = new System.Drawing.Point(32, 56);
			this.m_btCoresSecundarias.Name = "m_btCoresSecundarias";
			this.m_btCoresSecundarias.Size = new System.Drawing.Size(25, 25);
			this.m_btCoresSecundarias.TabIndex = 2;
			this.m_ttCores.SetToolTip(this.m_btCoresSecundarias, "Cor");
			this.m_btCoresSecundarias.Click += new System.EventHandler(this.m_btCoresSecundarias_Click);
			// 
			// m_lCoresPrimarias
			// 
			this.m_lCoresPrimarias.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lCoresPrimarias.Location = new System.Drawing.Point(64, 16);
			this.m_lCoresPrimarias.Name = "m_lCoresPrimarias";
			this.m_lCoresPrimarias.Size = new System.Drawing.Size(119, 25);
			this.m_lCoresPrimarias.TabIndex = 0;
			this.m_lCoresPrimarias.Text = "Painel de Ferramentas";
			this.m_lCoresPrimarias.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_lCoresSecundarias
			// 
			this.m_lCoresSecundarias.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lCoresSecundarias.Location = new System.Drawing.Point(64, 56);
			this.m_lCoresSecundarias.Name = "m_lCoresSecundarias";
			this.m_lCoresSecundarias.Size = new System.Drawing.Size(97, 25);
			this.m_lCoresSecundarias.TabIndex = 0;
			this.m_lCoresSecundarias.Text = "Painéis Dinâmicos";
			this.m_lCoresSecundarias.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_gbPictureBox
			// 
			this.m_gbPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbPictureBox.Controls.Add(this.m_pcbxBanner);
			this.m_gbPictureBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_gbPictureBox.Location = new System.Drawing.Point(0, 91);
			this.m_gbPictureBox.Name = "m_gbPictureBox";
			this.m_gbPictureBox.Size = new System.Drawing.Size(393, 277);
			this.m_gbPictureBox.TabIndex = 5;
			this.m_gbPictureBox.TabStop = false;
			// 
			// m_pcbxBanner
			// 
			this.m_pcbxBanner.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_pcbxBanner.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_pcbxBanner.Image = ((System.Drawing.Image)(resources.GetObject("m_pcbxBanner.Image")));
			this.m_pcbxBanner.Location = new System.Drawing.Point(2, 8);
			this.m_pcbxBanner.Name = "m_pcbxBanner";
			this.m_pcbxBanner.Size = new System.Drawing.Size(387, 265);
			this.m_pcbxBanner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pcbxBanner.TabIndex = 5;
			this.m_pcbxBanner.TabStop = false;
			this.m_pcbxBanner.Click += new System.EventHandler(this.m_pcbxBanner_Click);
			this.m_pcbxBanner.MouseEnter += new System.EventHandler(this.m_pcbxBanner_MouseEnter);
			this.m_pcbxBanner.MouseLeave += new System.EventHandler(this.m_pcbxBanner_MouseLeave);
			// 
			// m_tmCores
			// 
			this.m_tmCores.Enabled = true;
			this.m_tmCores.Interval = 2000;
			this.m_tmCores.Tick += new System.EventHandler(this.m_tmCores_Tick);
			// 
			// m_ttCores
			// 
			this.m_ttCores.AutomaticDelay = 100;
			this.m_ttCores.AutoPopDelay = 5000;
			this.m_ttCores.InitialDelay = 100;
			this.m_ttCores.ReshowDelay = 20;
			// 
			// usrCtrlCores
			// 
			this.Controls.Add(this.m_gbPictureBox);
			this.Controls.Add(this.m_lCoresSecundarias);
			this.Controls.Add(this.m_lCoresPrimarias);
			this.Controls.Add(this.m_btCoresSecundarias);
			this.Controls.Add(this.m_btCoresPrimarias);
			this.Name = "usrCtrlCores";
			this.Size = new System.Drawing.Size(394, 368);
			this.Load += new System.EventHandler(this.usrCtrlCores_Load);
			this.m_gbPictureBox.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Refresh
		public void refreshCores()
		{
			OnCallCarregaDadosInterface();
		}
		#endregion

		#region Get & Set
		public void setToolTipBanner(string strToolTip)
		{
			try
			{
				m_ttCores.SetToolTip(m_pcbxBanner, strToolTip);
			}
			catch
			{
			}
		}
		#endregion

		#region Eventos
		#region Cores
		private void m_btCoresPrimarias_Click(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			OnCallAlteraCorPrimaria();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}
        private void m_btCoresSecundarias_Click(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			OnCallAlteraCorSecundaria();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}
		#endregion
		#region Load
		private void usrCtrlCores_Load(object sender, System.EventArgs e)
		{
			this.m_tmCores.Enabled = true;
			this.m_tmCores.Start();
			OnCallAlteraBanner();
			OnCallCarregaDadosInterface();
		}
		#endregion
		#region Click
		private void m_pcbxBanner_Click(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			OnCallClickBanner();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}
		#endregion
		#region Tick
		private void m_tmCores_Tick(object sender, System.EventArgs e)
		{
			OnCallAlteraBanner();
		}
		#endregion
		#region Mouse Enter
		private void m_pcbxBanner_MouseEnter(object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor = System.Windows.Forms.Cursors.Hand;
				if ((m_tmCores != null) && (m_tmCores.Enabled))
					this.m_tmCores.Stop();
				//this.m_tmContas.Enabled = false;
			}
			catch
			{
			}
		}
		#endregion
		#region Mouse Leave
		private void m_pcbxBanner_MouseLeave(object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor = System.Windows.Forms.Cursors.Default;
				if (m_tmCores != null)
					this.m_tmCores.Start();
				//this.m_tmContas.Enabled = true;
			}
			catch
			{
			}
		}
		#endregion
		#endregion
	}
}
