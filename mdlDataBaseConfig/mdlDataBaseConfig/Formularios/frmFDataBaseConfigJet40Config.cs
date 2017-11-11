using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlDataBaseConfig
{
	/// <summary>
	/// Summary description for frmFDataBaseConfigJet40Config.
	/// </summary>
	public class frmFDataBaseConfigJet40Config : System.Windows.Forms.Form
	{
		#region Delegates
		public delegate System.Drawing.Color delCallCarregaCor();
		#endregion
		#region Events
		public event delCallCarregaCor eCallCarregaCor;
		#endregion
		#region Events Methods
		protected virtual void OnCallCarregaCor()
		{
			if (eCallCarregaCor != null)
			{
				m_clrFundo = eCallCarregaCor();
			}
		}
		#endregion
		#region Atributes
			private System.Drawing.Color m_clrFundo = System.Drawing.Color.Green;
			private string m_strUser;
			private string m_strPassword;

			public bool m_bModificado = false;

			private System.Windows.Forms.GroupBox m_gbGeral;
			private System.Windows.Forms.GroupBox m_gbServidorUtilizar;
			private System.Windows.Forms.PictureBox pictureBox1;
			internal System.Windows.Forms.Button m_btOk;
			internal System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.Label m_lbUser;
			private mdlComponentesGraficos.TextBox m_txtUser;
			private System.Windows.Forms.Label m_lbPassword;
			private mdlComponentesGraficos.TextBox m_txtPassword;
		#endregion
		private System.Windows.Forms.ToolTip m_ttDica;
		private System.ComponentModel.IContainer components;
		#region Constructors and Destructors
			public frmFDataBaseConfigJet40Config(string strUser,string strPassword)
			{
				m_strUser = strUser;
				m_strPassword = strPassword;
				//
				// Required for Windows Form Designer support
				//
				InitializeComponent();

				//
				// TODO: Add any constructor code after InitializeComponent call
				//
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFDataBaseConfigJet40Config));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_gbServidorUtilizar = new System.Windows.Forms.GroupBox();
			this.m_lbPassword = new System.Windows.Forms.Label();
			this.m_txtPassword = new mdlComponentesGraficos.TextBox();
			this.m_lbUser = new System.Windows.Forms.Label();
			this.m_txtUser = new mdlComponentesGraficos.TextBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_ttDica = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbGeral.SuspendLayout();
			this.m_gbServidorUtilizar.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Controls.Add(this.m_gbServidorUtilizar);
			this.m_gbGeral.Controls.Add(this.pictureBox1);
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Location = new System.Drawing.Point(5, 0);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(275, 184);
			this.m_gbGeral.TabIndex = 2;
			this.m_gbGeral.TabStop = false;
			// 
			// m_gbServidorUtilizar
			// 
			this.m_gbServidorUtilizar.Controls.Add(this.m_lbPassword);
			this.m_gbServidorUtilizar.Controls.Add(this.m_txtPassword);
			this.m_gbServidorUtilizar.Controls.Add(this.m_lbUser);
			this.m_gbServidorUtilizar.Controls.Add(this.m_txtUser);
			this.m_gbServidorUtilizar.Location = new System.Drawing.Point(4, 82);
			this.m_gbServidorUtilizar.Name = "m_gbServidorUtilizar";
			this.m_gbServidorUtilizar.Size = new System.Drawing.Size(260, 70);
			this.m_gbServidorUtilizar.TabIndex = 78;
			this.m_gbServidorUtilizar.TabStop = false;
			// 
			// m_lbPassword
			// 
			this.m_lbPassword.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbPassword.Location = new System.Drawing.Point(8, 40);
			this.m_lbPassword.Name = "m_lbPassword";
			this.m_lbPassword.Size = new System.Drawing.Size(56, 16);
			this.m_lbPassword.TabIndex = 3;
			this.m_lbPassword.Text = "Senha:";
			// 
			// m_txtPassword
			// 
			this.m_txtPassword.Location = new System.Drawing.Point(70, 40);
			this.m_txtPassword.Name = "m_txtPassword";
			this.m_txtPassword.PasswordChar = '*';
			this.m_txtPassword.Size = new System.Drawing.Size(178, 20);
			this.m_txtPassword.TabIndex = 2;
			this.m_txtPassword.Text = "";
			// 
			// m_lbUser
			// 
			this.m_lbUser.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbUser.Location = new System.Drawing.Point(7, 16);
			this.m_lbUser.Name = "m_lbUser";
			this.m_lbUser.Size = new System.Drawing.Size(56, 16);
			this.m_lbUser.TabIndex = 1;
			this.m_lbUser.Text = "Usuário:";
			// 
			// m_txtUser
			// 
			this.m_txtUser.Location = new System.Drawing.Point(71, 13);
			this.m_txtUser.Name = "m_txtUser";
			this.m_txtUser.Size = new System.Drawing.Size(177, 20);
			this.m_txtUser.TabIndex = 1;
			this.m_txtUser.Text = "";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(8, 15);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(248, 64);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 74;
			this.pictureBox1.TabStop = false;
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(80, 154);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 3;
			this.m_ttDica.SetToolTip(this.m_btOk, "Confirmar");
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(144, 154);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 4;
			this.m_ttDica.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_ttDica
			// 
			this.m_ttDica.AutomaticDelay = 100;
			this.m_ttDica.AutoPopDelay = 5000;
			this.m_ttDica.InitialDelay = 100;
			this.m_ttDica.ReshowDelay = 20;
			// 
			// frmFDataBaseConfigJet40Config
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(288, 190);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFDataBaseConfigJet40Config";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Access";
			this.Load += new System.EventHandler(this.frmFDataBaseConfigJet40Config_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbServidorUtilizar.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFDataBaseConfigJet40Config_Load(object sender, System.EventArgs e)
				{
					OnCallCarregaCor();
					vMostraCor();
					vCarregaDadosInterface();
				}
			#endregion
			#region Botoes
				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					vSalvaDadosInterface();
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
		#region Metodos
			#region Cores
				private void vMostraCor()
				{
					this.BackColor = m_clrFundo;
					for (int nCont = 0 ;nCont < this.Controls.Count; nCont++)
					{
						this.Controls[nCont].BackColor = this.BackColor;
						for (int nCont2 = 0 ;nCont2 < this.Controls[nCont].Controls.Count; nCont2++)
						{
							if ((this.Controls[nCont].Controls[nCont2].GetType().ToString() != "mdlComponentesGraficos.TextBox") && (this.Controls[nCont].Controls[nCont2].GetType().ToString() != "System.Windows.Forms.Label"))
								this.Controls[nCont].Controls[nCont2].BackColor = this.BackColor;

							for (int nCont3 = 0 ;nCont3 < this.Controls[nCont].Controls[nCont2].Controls.Count; nCont3++)
							{
								if ((this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "mdlComponentesGraficos.TextBox") && (this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "System.Windows.Forms.ListView"))
									this.Controls[nCont].Controls[nCont2].Controls[nCont3].BackColor = this.BackColor;

								for (int nCont4 = 0 ;nCont4 < this.Controls[nCont].Controls[nCont2].Controls[nCont3].Controls.Count; nCont4++)
								{
									if ((this.Controls[nCont].Controls[nCont2].Controls[nCont3].Controls[nCont4].GetType().ToString() != "mdlComponentesGraficos.TextBox") && (this.Controls[nCont].Controls[nCont2].Controls[nCont3].Controls[nCont4].GetType().ToString() != "System.Windows.Forms.ListView"))
										this.Controls[nCont].Controls[nCont2].Controls[nCont3].Controls[nCont4].BackColor = this.BackColor;
								}

							}
						}
					}
				}
			#endregion
		#endregion

		#region Carregamento dos Dados
			private void vCarregaDadosInterface()
			{
				m_txtUser.Text = m_strUser;
				m_txtPassword.Text = m_strPassword;
			}
		#endregion
		#region Salvamento dos Dados 
			private void vSalvaDadosInterface()
			{
				m_strUser = m_txtUser.Text;
				m_strPassword = m_txtPassword.Text;
			}
		#endregion

		#region RetornoDados
			public void vRetornaDados(out string strUser,out string strPassword)
			{
				strUser = m_strUser;
				strPassword = m_strPassword;
			}
		#endregion
	}
}
