using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SiscoConfig
{
	/// <summary>
	/// Summary description for frmFConfig.
	/// </summary>
	internal class frmFConfig : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate bool delCallCarregaDadosInternet(out bool bProxy,out string strProxyHost,out string strProxyPort,out bool bProxyAutentication,out string strProxyUser,out string strProxyPassword);
			public delegate bool delCallSalvaDadosInternet(bool bProxy,string strProxyHost,string strProxyPort,bool bProxyAutentication,string strProxyUser,string strProxyPassword);
			public delegate void delCallSiscobras();
		#endregion
		#region Events
			public event delCallCarregaDadosInternet eCallCarregaDadosInternet;
			public event delCallSalvaDadosInternet eCallSalvaDadosInternet;
			public event delCallSiscobras eCallSiscobras;
		#endregion
		#region Events Methods
			public virtual bool OnCallCarregaDadosInternet() 
			{
				bool bRetorno = false;
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallCarregaDadosInternet != null)
				{
					bool bProxy,bProxyAutentication;
					string strProxyHost,strProxyPort,strProxyUser,strProxyPassword = "";
					bRetorno = eCallCarregaDadosInternet(out bProxy,out strProxyHost,out strProxyPort,out bProxyAutentication,out strProxyUser,out strProxyPassword);
					m_ckProxy.Checked = bProxy;
					m_ckProxyAutentication.Checked = bProxyAutentication;
					m_txtProxyHost.Text = strProxyHost;
					m_txtProxyPort.Text = strProxyPort;
					m_txtProxyUser.Text = strProxyUser;
					m_txtProxyPassword.Text = strProxyPassword;
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bRetorno);
			}

			public virtual bool OnCallSalvaDadosInternet() 
			{
				bool bRetorno = false;
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallSalvaDadosInternet != null)
				{
					bool bProxy,bProxyAutentication;
					string strProxyHost,strProxyPort,strProxyUser,strProxyPassword = "";
					bProxy = m_ckProxy.Checked;
					bProxyAutentication = m_ckProxyAutentication.Checked;
					strProxyHost = m_txtProxyHost.Text;
					strProxyPort = m_txtProxyPort.Text;
					strProxyUser = m_txtProxyUser.Text;
					strProxyPassword = m_txtProxyPassword.Text;
					bRetorno = eCallSalvaDadosInternet(bProxy,strProxyHost,strProxyPort,bProxyAutentication,strProxyUser,strProxyPassword);
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bRetorno);
			}

			public virtual void OnCallSiscobras() 
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallSiscobras != null)
					eCallSiscobras();
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}
		#endregion

		#region Atributes
			private System.Windows.Forms.GroupBox m_gbGeral;
			private System.Windows.Forms.PictureBox m_picSiscobras;
			private System.Windows.Forms.GroupBox m_gbInternet;
			private System.Windows.Forms.Label m_lbInformacaoInternet;
			private System.Windows.Forms.CheckBox m_ckProxy;
			private System.Windows.Forms.GroupBox m_gbProxy;
			private System.Windows.Forms.Label m_lbProxyHost;
			private System.Windows.Forms.TextBox m_txtProxyHost;
			private System.Windows.Forms.TextBox m_txtProxyPort;
			private System.Windows.Forms.Label m_lbProxyPort;
			private System.Windows.Forms.CheckBox m_ckProxyAutentication;
			private System.Windows.Forms.GroupBox m_gbProxyAutentication;
		private System.Windows.Forms.Button m_btOk;
		private System.Windows.Forms.Button m_btCancelar;
		private System.Windows.Forms.TextBox m_txtProxyPassword;
		private System.Windows.Forms.Label m_lbProxyPassword;
		private System.Windows.Forms.TextBox m_txtProxyUser;
		private System.Windows.Forms.Label m_lbProxyUser;
		private System.Windows.Forms.CheckBox m_ckSiscobras;
			private System.ComponentModel.Container components = null;
		#endregion
		#region Constructors and Destructors
			public frmFConfig()
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
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFConfig));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_ckSiscobras = new System.Windows.Forms.CheckBox();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbInternet = new System.Windows.Forms.GroupBox();
			this.m_gbProxy = new System.Windows.Forms.GroupBox();
			this.m_gbProxyAutentication = new System.Windows.Forms.GroupBox();
			this.m_txtProxyPassword = new System.Windows.Forms.TextBox();
			this.m_lbProxyPassword = new System.Windows.Forms.Label();
			this.m_txtProxyUser = new System.Windows.Forms.TextBox();
			this.m_lbProxyUser = new System.Windows.Forms.Label();
			this.m_ckProxyAutentication = new System.Windows.Forms.CheckBox();
			this.m_txtProxyPort = new System.Windows.Forms.TextBox();
			this.m_lbProxyPort = new System.Windows.Forms.Label();
			this.m_txtProxyHost = new System.Windows.Forms.TextBox();
			this.m_lbProxyHost = new System.Windows.Forms.Label();
			this.m_ckProxy = new System.Windows.Forms.CheckBox();
			this.m_lbInformacaoInternet = new System.Windows.Forms.Label();
			this.m_picSiscobras = new System.Windows.Forms.PictureBox();
			this.m_gbGeral.SuspendLayout();
			this.m_gbInternet.SuspendLayout();
			this.m_gbProxy.SuspendLayout();
			this.m_gbProxyAutentication.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbGeral.Controls.Add(this.m_ckSiscobras);
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Controls.Add(this.m_gbInternet);
			this.m_gbGeral.Controls.Add(this.m_picSiscobras);
			this.m_gbGeral.Location = new System.Drawing.Point(3, -2);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(337, 393);
			this.m_gbGeral.TabIndex = 0;
			this.m_gbGeral.TabStop = false;
			// 
			// m_ckSiscobras
			// 
			this.m_ckSiscobras.Checked = true;
			this.m_ckSiscobras.CheckState = System.Windows.Forms.CheckState.Checked;
			this.m_ckSiscobras.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_ckSiscobras.Location = new System.Drawing.Point(4, 339);
			this.m_ckSiscobras.Name = "m_ckSiscobras";
			this.m_ckSiscobras.Size = new System.Drawing.Size(312, 16);
			this.m_ckSiscobras.TabIndex = 11;
			this.m_ckSiscobras.Text = "Abrir Siscobras Exporta Fácil após salvar os dados.";
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(107, 360);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 27);
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
			this.m_btCancelar.Location = new System.Drawing.Point(171, 360);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 27);
			this.m_btCancelar.TabIndex = 10;
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbInternet
			// 
			this.m_gbInternet.Controls.Add(this.m_gbProxy);
			this.m_gbInternet.Controls.Add(this.m_ckProxy);
			this.m_gbInternet.Controls.Add(this.m_lbInformacaoInternet);
			this.m_gbInternet.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbInternet.Location = new System.Drawing.Point(4, 145);
			this.m_gbInternet.Name = "m_gbInternet";
			this.m_gbInternet.Size = new System.Drawing.Size(325, 191);
			this.m_gbInternet.TabIndex = 1;
			this.m_gbInternet.TabStop = false;
			this.m_gbInternet.Text = "Internet";
			// 
			// m_gbProxy
			// 
			this.m_gbProxy.Controls.Add(this.m_gbProxyAutentication);
			this.m_gbProxy.Controls.Add(this.m_ckProxyAutentication);
			this.m_gbProxy.Controls.Add(this.m_txtProxyPort);
			this.m_gbProxy.Controls.Add(this.m_lbProxyPort);
			this.m_gbProxy.Controls.Add(this.m_txtProxyHost);
			this.m_gbProxy.Controls.Add(this.m_lbProxyHost);
			this.m_gbProxy.Location = new System.Drawing.Point(6, 58);
			this.m_gbProxy.Name = "m_gbProxy";
			this.m_gbProxy.Size = new System.Drawing.Size(312, 126);
			this.m_gbProxy.TabIndex = 2;
			this.m_gbProxy.TabStop = false;
			// 
			// m_gbProxyAutentication
			// 
			this.m_gbProxyAutentication.Controls.Add(this.m_txtProxyPassword);
			this.m_gbProxyAutentication.Controls.Add(this.m_lbProxyPassword);
			this.m_gbProxyAutentication.Controls.Add(this.m_txtProxyUser);
			this.m_gbProxyAutentication.Controls.Add(this.m_lbProxyUser);
			this.m_gbProxyAutentication.Location = new System.Drawing.Point(8, 66);
			this.m_gbProxyAutentication.Name = "m_gbProxyAutentication";
			this.m_gbProxyAutentication.Size = new System.Drawing.Size(296, 56);
			this.m_gbProxyAutentication.TabIndex = 5;
			this.m_gbProxyAutentication.TabStop = false;
			// 
			// m_txtProxyPassword
			// 
			this.m_txtProxyPassword.Location = new System.Drawing.Point(64, 28);
			this.m_txtProxyPassword.Name = "m_txtProxyPassword";
			this.m_txtProxyPassword.PasswordChar = '*';
			this.m_txtProxyPassword.Size = new System.Drawing.Size(224, 20);
			this.m_txtProxyPassword.TabIndex = 4;
			this.m_txtProxyPassword.Text = "";
			// 
			// m_lbProxyPassword
			// 
			this.m_lbProxyPassword.Location = new System.Drawing.Point(7, 31);
			this.m_lbProxyPassword.Name = "m_lbProxyPassword";
			this.m_lbProxyPassword.Size = new System.Drawing.Size(57, 16);
			this.m_lbProxyPassword.TabIndex = 3;
			this.m_lbProxyPassword.Text = "Senha:";
			// 
			// m_txtProxyUser
			// 
			this.m_txtProxyUser.Location = new System.Drawing.Point(64, 9);
			this.m_txtProxyUser.Name = "m_txtProxyUser";
			this.m_txtProxyUser.Size = new System.Drawing.Size(224, 20);
			this.m_txtProxyUser.TabIndex = 2;
			this.m_txtProxyUser.Text = "";
			// 
			// m_lbProxyUser
			// 
			this.m_lbProxyUser.Location = new System.Drawing.Point(7, 12);
			this.m_lbProxyUser.Name = "m_lbProxyUser";
			this.m_lbProxyUser.Size = new System.Drawing.Size(57, 16);
			this.m_lbProxyUser.TabIndex = 1;
			this.m_lbProxyUser.Text = "Usuário:";
			// 
			// m_ckProxyAutentication
			// 
			this.m_ckProxyAutentication.Location = new System.Drawing.Point(8, 52);
			this.m_ckProxyAutentication.Name = "m_ckProxyAutentication";
			this.m_ckProxyAutentication.Size = new System.Drawing.Size(296, 16);
			this.m_ckProxyAutentication.TabIndex = 4;
			this.m_ckProxyAutentication.Text = "Utilizo Proxy com autenticação.";
			this.m_ckProxyAutentication.CheckedChanged += new System.EventHandler(this.m_ckProxyAutentication_CheckedChanged);
			// 
			// m_txtProxyPort
			// 
			this.m_txtProxyPort.Location = new System.Drawing.Point(48, 30);
			this.m_txtProxyPort.Name = "m_txtProxyPort";
			this.m_txtProxyPort.Size = new System.Drawing.Size(256, 20);
			this.m_txtProxyPort.TabIndex = 3;
			this.m_txtProxyPort.Text = "";
			// 
			// m_lbProxyPort
			// 
			this.m_lbProxyPort.Location = new System.Drawing.Point(7, 32);
			this.m_lbProxyPort.Name = "m_lbProxyPort";
			this.m_lbProxyPort.Size = new System.Drawing.Size(40, 16);
			this.m_lbProxyPort.TabIndex = 2;
			this.m_lbProxyPort.Text = "Porta:";
			// 
			// m_txtProxyHost
			// 
			this.m_txtProxyHost.Location = new System.Drawing.Point(48, 10);
			this.m_txtProxyHost.Name = "m_txtProxyHost";
			this.m_txtProxyHost.Size = new System.Drawing.Size(256, 20);
			this.m_txtProxyHost.TabIndex = 1;
			this.m_txtProxyHost.Text = "";
			// 
			// m_lbProxyHost
			// 
			this.m_lbProxyHost.Location = new System.Drawing.Point(7, 12);
			this.m_lbProxyHost.Name = "m_lbProxyHost";
			this.m_lbProxyHost.Size = new System.Drawing.Size(40, 16);
			this.m_lbProxyHost.TabIndex = 0;
			this.m_lbProxyHost.Text = "Host:";
			// 
			// m_ckProxy
			// 
			this.m_ckProxy.Location = new System.Drawing.Point(6, 44);
			this.m_ckProxy.Name = "m_ckProxy";
			this.m_ckProxy.Size = new System.Drawing.Size(280, 16);
			this.m_ckProxy.TabIndex = 1;
			this.m_ckProxy.Text = "Sim. Utilizo proxy para me conectar a internet.";
			this.m_ckProxy.CheckedChanged += new System.EventHandler(this.m_ckProxy_CheckedChanged);
			// 
			// m_lbInformacaoInternet
			// 
			this.m_lbInformacaoInternet.Location = new System.Drawing.Point(7, 15);
			this.m_lbInformacaoInternet.Name = "m_lbInformacaoInternet";
			this.m_lbInformacaoInternet.Size = new System.Drawing.Size(313, 40);
			this.m_lbInformacaoInternet.TabIndex = 0;
			this.m_lbInformacaoInternet.Text = "Caso você utilize algum proxy para se conectar com a internet, este é o momento d" +
				"e configurá-lo.";
			// 
			// m_picSiscobras
			// 
			this.m_picSiscobras.Image = ((System.Drawing.Image)(resources.GetObject("m_picSiscobras.Image")));
			this.m_picSiscobras.Location = new System.Drawing.Point(5, 9);
			this.m_picSiscobras.Name = "m_picSiscobras";
			this.m_picSiscobras.Size = new System.Drawing.Size(323, 135);
			this.m_picSiscobras.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_picSiscobras.TabIndex = 0;
			this.m_picSiscobras.TabStop = false;
			// 
			// frmFConfig
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(346, 392);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "frmFConfig";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Siscobras";
			this.Load += new System.EventHandler(this.frmFConfig_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbInternet.ResumeLayout(false);
			this.m_gbProxy.ResumeLayout(false);
			this.m_gbProxyAutentication.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Events
			#region Formulario
				private void frmFConfig_Load(object sender, System.EventArgs e)
				{
					OnCallCarregaDadosInternet();
					vRefreshInterface();
				}
			#endregion
			#region CheckBoxes
				private void m_ckProxy_CheckedChanged(object sender, System.EventArgs e)
				{
					vRefreshInterface();
				}

				private void m_ckProxyAutentication_CheckedChanged(object sender, System.EventArgs e)
				{
					vRefreshInterface();
				}
			#endregion
			#region Botoes
				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					if (OnCallSalvaDadosInternet())
					{
						if (m_ckSiscobras.Checked)
							OnCallSiscobras();
						this.Close();
					}
				}

				private void m_btCancelar_Click(object sender, System.EventArgs e)
				{
                    this.Close();				
				}
			#endregion
		#endregion

		#region Refresh
			private void vRefreshInterface()
			{
				if (m_ckProxy.Checked)
				{
					m_gbProxy.Enabled = true;
					if (m_ckProxyAutentication.Checked)
					{
						m_gbProxyAutentication.Enabled = true;
					}else{
						m_gbProxyAutentication.Enabled = false;
					}
				}else{
					m_gbProxy.Enabled = false;
					m_gbProxyAutentication.Enabled = false;
				}
			}
		#endregion
	}
}
