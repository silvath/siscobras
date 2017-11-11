using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlDataBaseConfig
{
	/// <summary>
	/// Summary description for frmFDataBaseConfigMySql.
	/// </summary>
	public class frmFDataBaseConfigMySql : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate System.Drawing.Color delCallCarregaCor();
			public delegate void delCallConfigBackup();
			public delegate void delCallConfigRestore();
			public delegate void delCallSalvaDados(string strHost,string strPort,string strDataBaseName,string strUser,string strPassword);
			public delegate bool delCallConfiguratedRight();
		#endregion
		#region Events
			public event delCallCarregaCor eCallCarregaCor;
			public event delCallConfigBackup eCallConfigBackup;
			public event delCallConfigRestore eCallConfigRestore;
			public event delCallSalvaDados eCallSalvaDados;
			public event delCallConfiguratedRight eCallConfiguratedRight;
		#endregion
		#region Events Methods
			protected virtual void OnCallCarregaCor()
			{
				if (eCallCarregaCor != null)
				{
					m_clrFundo = eCallCarregaCor();
				}
			}

			protected virtual void OnCallConfigBackup()
			{
				if (eCallConfigBackup != null)
				{
					eCallConfigBackup();
				}
			}

			protected virtual void OnCallConfigRestore()
			{
				if (eCallConfigRestore != null)
				{
					eCallConfigRestore();
				}
			}

			protected virtual void OnCallSalvaDados()
			{
				if (eCallSalvaDados != null)
				{
					eCallSalvaDados(m_strHost,m_strPort,m_strDataBaseName,m_strUser,m_strPassword);
				}
			}

			protected virtual bool OnCallConfiguratedRight()
			{
				bool bRetorno = false;
				if (eCallConfiguratedRight != null)
				{
					bRetorno = eCallConfiguratedRight();
				}
				return(bRetorno);
			}
		#endregion
		#region Atributes
			frmFAguarde m_formFAguarde = null;
			System.Threading.Thread m_thrAguarde = null;

			private mdlTratamentoErro.clsTratamentoErro m_cls_ter_TratadorErro;
			private System.Drawing.Color m_clrFundo = System.Drawing.Color.Green;

			// Configuracoes BD
			private string m_strHost = "";
			private string m_strPort = "";
			private string m_strDataBaseName = "";
			private string m_strUser = "";
			private string m_strPassword = "";	

			public bool m_bModificado = false;

			private System.Windows.Forms.GroupBox m_gbGeral;
			internal System.Windows.Forms.Button m_btOk;
			internal System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.LinkLabel m_llbConfiguracoesAvancadas;
			private System.Windows.Forms.GroupBox m_gbServidores;
			private System.Windows.Forms.LinkLabel m_llbServidores;
			private System.Windows.Forms.ListView m_lvServidores;
			private System.Windows.Forms.ColumnHeader m_colLvServidoresHost;
			private System.Windows.Forms.ColumnHeader m_colLvServidoresIp;
			private System.Windows.Forms.GroupBox m_gbServidorUtilizar;
			private mdlComponentesGraficos.TextBox m_txtServidorUtilizar;
			private System.Windows.Forms.Label m_lbServidorUtilizar;
			private System.Windows.Forms.ColumnHeader m_colLvServidoresPossuiSiscobras;
			private System.Windows.Forms.ToolTip m_ttDica;
		private System.Windows.Forms.LinkLabel m_llbConfig;
			private System.ComponentModel.IContainer components;
		#endregion
		#region Constructors
			public frmFDataBaseConfigMySql(ref mdlTratamentoErro.clsTratamentoErro cls_ter_TratadorErro,string strHost,string strPort,string strDataBaseName,string strUser,string strPassword)
			{
				m_cls_ter_TratadorErro = cls_ter_TratadorErro;
				m_strHost = strHost;
				m_strPort = strPort;
				m_strDataBaseName = strDataBaseName;
				m_strUser = strUser;
				m_strPassword = strPassword;

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFDataBaseConfigMySql));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_gbServidorUtilizar = new System.Windows.Forms.GroupBox();
			this.m_llbConfig = new System.Windows.Forms.LinkLabel();
			this.m_lbServidorUtilizar = new System.Windows.Forms.Label();
			this.m_txtServidorUtilizar = new mdlComponentesGraficos.TextBox();
			this.m_gbServidores = new System.Windows.Forms.GroupBox();
			this.m_llbServidores = new System.Windows.Forms.LinkLabel();
			this.m_lvServidores = new System.Windows.Forms.ListView();
			this.m_colLvServidoresIp = new System.Windows.Forms.ColumnHeader();
			this.m_colLvServidoresHost = new System.Windows.Forms.ColumnHeader();
			this.m_colLvServidoresPossuiSiscobras = new System.Windows.Forms.ColumnHeader();
			this.m_llbConfiguracoesAvancadas = new System.Windows.Forms.LinkLabel();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_ttDica = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbGeral.SuspendLayout();
			this.m_gbServidorUtilizar.SuspendLayout();
			this.m_gbServidores.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbGeral.Controls.Add(this.m_gbServidorUtilizar);
			this.m_gbGeral.Controls.Add(this.m_gbServidores);
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Location = new System.Drawing.Point(4, -2);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(392, 225);
			this.m_gbGeral.TabIndex = 0;
			this.m_gbGeral.TabStop = false;
			// 
			// m_gbServidorUtilizar
			// 
			this.m_gbServidorUtilizar.Controls.Add(this.m_llbConfig);
			this.m_gbServidorUtilizar.Controls.Add(this.m_lbServidorUtilizar);
			this.m_gbServidorUtilizar.Controls.Add(this.m_txtServidorUtilizar);
			this.m_gbServidorUtilizar.Location = new System.Drawing.Point(7, 135);
			this.m_gbServidorUtilizar.Name = "m_gbServidorUtilizar";
			this.m_gbServidorUtilizar.Size = new System.Drawing.Size(378, 56);
			this.m_gbServidorUtilizar.TabIndex = 78;
			this.m_gbServidorUtilizar.TabStop = false;
			// 
			// m_llbConfig
			// 
			this.m_llbConfig.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_llbConfig.Location = new System.Drawing.Point(121, 34);
			this.m_llbConfig.Name = "m_llbConfig";
			this.m_llbConfig.Size = new System.Drawing.Size(138, 16);
			this.m_llbConfig.TabIndex = 77;
			this.m_llbConfig.TabStop = true;
			this.m_llbConfig.Text = "Criar o banco de dados.";
			this.m_llbConfig.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_llbConfig_LinkClicked);
			// 
			// m_lbServidorUtilizar
			// 
			this.m_lbServidorUtilizar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbServidorUtilizar.Location = new System.Drawing.Point(16, 15);
			this.m_lbServidorUtilizar.Name = "m_lbServidorUtilizar";
			this.m_lbServidorUtilizar.Size = new System.Drawing.Size(56, 16);
			this.m_lbServidorUtilizar.TabIndex = 1;
			this.m_lbServidorUtilizar.Text = "Servidor:";
			// 
			// m_txtServidorUtilizar
			// 
			this.m_txtServidorUtilizar.Location = new System.Drawing.Point(80, 12);
			this.m_txtServidorUtilizar.Name = "m_txtServidorUtilizar";
			this.m_txtServidorUtilizar.Size = new System.Drawing.Size(288, 20);
			this.m_txtServidorUtilizar.TabIndex = 0;
			this.m_txtServidorUtilizar.Text = "";
			// 
			// m_gbServidores
			// 
			this.m_gbServidores.Controls.Add(this.m_llbServidores);
			this.m_gbServidores.Controls.Add(this.m_lvServidores);
			this.m_gbServidores.Controls.Add(this.m_llbConfiguracoesAvancadas);
			this.m_gbServidores.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbServidores.Location = new System.Drawing.Point(8, 10);
			this.m_gbServidores.Name = "m_gbServidores";
			this.m_gbServidores.Size = new System.Drawing.Size(376, 125);
			this.m_gbServidores.TabIndex = 77;
			this.m_gbServidores.TabStop = false;
			this.m_gbServidores.Text = "Servidores disponíveis";
			// 
			// m_llbServidores
			// 
			this.m_llbServidores.Enabled = false;
			this.m_llbServidores.Location = new System.Drawing.Point(128, 32);
			this.m_llbServidores.Name = "m_llbServidores";
			this.m_llbServidores.Size = new System.Drawing.Size(125, 16);
			this.m_llbServidores.TabIndex = 78;
			this.m_llbServidores.TabStop = true;
			this.m_llbServidores.Text = "Procurar servidores.";
			this.m_llbServidores.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_llbServidores_LinkClicked);
			// 
			// m_lvServidores
			// 
			this.m_lvServidores.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							 this.m_colLvServidoresIp,
																							 this.m_colLvServidoresHost,
																							 this.m_colLvServidoresPossuiSiscobras});
			this.m_lvServidores.FullRowSelect = true;
			this.m_lvServidores.Location = new System.Drawing.Point(8, 56);
			this.m_lvServidores.Name = "m_lvServidores";
			this.m_lvServidores.Size = new System.Drawing.Size(360, 64);
			this.m_lvServidores.TabIndex = 77;
			this.m_lvServidores.View = System.Windows.Forms.View.List;
			this.m_lvServidores.Click += new System.EventHandler(this.m_lvServidores_Click);
			this.m_lvServidores.KeyUp += new System.Windows.Forms.KeyEventHandler(this.m_lvServidores_KeyUp);
			// 
			// m_colLvServidoresIp
			// 
			this.m_colLvServidoresIp.Text = "Ip";
			this.m_colLvServidoresIp.Width = 81;
			// 
			// m_colLvServidoresHost
			// 
			this.m_colLvServidoresHost.Text = "Servidor";
			this.m_colLvServidoresHost.Width = 203;
			// 
			// m_colLvServidoresPossuiSiscobras
			// 
			this.m_colLvServidoresPossuiSiscobras.Text = "Siscobras";
			this.m_colLvServidoresPossuiSiscobras.Width = 72;
			// 
			// m_llbConfiguracoesAvancadas
			// 
			this.m_llbConfiguracoesAvancadas.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_llbConfiguracoesAvancadas.Location = new System.Drawing.Point(99, 16);
			this.m_llbConfiguracoesAvancadas.Name = "m_llbConfiguracoesAvancadas";
			this.m_llbConfiguracoesAvancadas.Size = new System.Drawing.Size(184, 16);
			this.m_llbConfiguracoesAvancadas.TabIndex = 75;
			this.m_llbConfiguracoesAvancadas.TabStop = true;
			this.m_llbConfiguracoesAvancadas.Text = "Personalizar o banco de dados.";
			this.m_llbConfiguracoesAvancadas.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_llbConfiguracoesAvancadas_LinkClicked);
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(136, 193);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 72;
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
			this.m_btCancelar.Location = new System.Drawing.Point(200, 193);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 73;
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
			// frmFDataBaseConfigMySql
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(402, 224);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFDataBaseConfigMySql";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MySql";
			this.Load += new System.EventHandler(this.frmFDataBaseConfigMySql_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbServidorUtilizar.ResumeLayout(false);
			this.m_gbServidores.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region ShowDialogConfiguracoesAvancadas
		private void ShowDialogConfiguracoesAvancadas()
		{

			frmFDataBaseConfigMySqlConfig formFConfiguracoesAvancadas = new frmFDataBaseConfigMySqlConfig(m_strPort,m_strDataBaseName,m_strUser,m_strPassword);
			vInitializeEventsFormConfiguracoesAvancadas(ref formFConfiguracoesAvancadas);
			formFConfiguracoesAvancadas.ShowDialog();
			if (formFConfiguracoesAvancadas.m_bModificado)
			{
				formFConfiguracoesAvancadas.vRetornaDados(out m_strPort,out m_strDataBaseName,out m_strUser,out m_strPassword);
			}
			formFConfiguracoesAvancadas = null;
		}

		private void vInitializeEventsFormConfiguracoesAvancadas(ref frmFDataBaseConfigMySqlConfig formFConfiguracoesAvancadas)
		{
			// Cor 
			formFConfiguracoesAvancadas.eCallCarregaCor += new mdlDataBaseConfig.frmFDataBaseConfigMySqlConfig.delCallCarregaCor(formFConfiguracoesAvancadas_eCallCarregaCor);
		}

		private System.Drawing.Color formFConfiguracoesAvancadas_eCallCarregaCor()
		{
			return(m_clrFundo);
		}
		#endregion
		#region ShowDialogAdmin
			private void ShowDialogAdmin()
			{
				m_strHost = m_txtServidorUtilizar.Text;
				frmFDataBaseConfigMySqlAdmin formFAdmin = new frmFDataBaseConfigMySqlAdmin(m_strHost,m_strPort,m_strDataBaseName,m_strUser,m_strPassword);
				vInitializeEvents(ref formFAdmin);
				formFAdmin.ShowDialog();
				formFAdmin = null;
			}

			private void vInitializeEvents(ref frmFDataBaseConfigMySqlAdmin formFAdmin)
			{
				// Carrega Dados Admin
				formFAdmin.eCallCarregaDados += new mdlDataBaseConfig.frmFDataBaseConfigMySqlAdmin.delCallCarregaDados(vCarregaDadosAdmin);

				// Carrega Cor
				formFAdmin.eCallCarregaCor += new mdlDataBaseConfig.frmFDataBaseConfigMySqlAdmin.delCallCarregaCor(formFAdmin_eCallCarregaCor);

				// Server
				formFAdmin.eCallServer += new mdlDataBaseConfig.frmFDataBaseConfigMySqlAdmin.delCallServer(bServer);

				// MySql
				formFAdmin.eCallMySql += new mdlDataBaseConfig.frmFDataBaseConfigMySqlAdmin.delCallMySql(bMySql);

				// DataBase
				formFAdmin.eCallDataBase += new mdlDataBaseConfig.frmFDataBaseConfigMySqlAdmin.delCallDataBase(bDataBase);

				// User
				formFAdmin.eCallUser += new mdlDataBaseConfig.frmFDataBaseConfigMySqlAdmin.delCallUser(bUser);

				// User Associated
				formFAdmin.eCallUserAssociated += new mdlDataBaseConfig.frmFDataBaseConfigMySqlAdmin.delCallUserAssociated(bUserAssociated);

				// DataBase Updated
				formFAdmin.eCallDataBaseUpdated += new mdlDataBaseConfig.frmFDataBaseConfigMySqlAdmin.delCallDataBaseUpdated(bDataBaseUpdated);

				// DefaultData
				formFAdmin.eCallDefaultData += new mdlDataBaseConfig.frmFDataBaseConfigMySqlAdmin.delCallDefaultData(bDBDefaultData);
			}

			private Color formFAdmin_eCallCarregaCor()
			{
				return (m_clrFundo);
			}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFDataBaseConfigMySql_Load(object sender, System.EventArgs e)
				{				
					OnCallCarregaCor();
					vMostraCor();
					vCarregaDadosInterface();
				}
			#endregion
			#region Servidores
				private void m_lvServidores_Click(object sender, System.EventArgs e)
				{
					if (m_lvServidores.SelectedItems.Count > 0)
					{
						m_txtServidorUtilizar.Text = m_lvServidores.SelectedItems[0].Text;
					}
				}

				private void m_lvServidores_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
				{
					if (m_lvServidores.SelectedItems.Count > 0)
					{
						m_txtServidorUtilizar.Text = m_lvServidores.SelectedItems[0].Text;
					}
				}

				private void m_llbServidores_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
				{
					m_formFAguarde = new frmFAguarde();
					m_thrAguarde = new System.Threading.Thread(new System.Threading.ThreadStart(vRefreshServidores));
					m_thrAguarde.Start();
					vInitializeFormAguarde(ref m_formFAguarde);
					m_formFAguarde.ShowDialog();
					if (m_thrAguarde != null)
					{
						if (m_thrAguarde.IsAlive)
						{
							m_thrAguarde.Abort();
						}
						m_thrAguarde = null;
					}
				}

				private void vInitializeFormAguarde(ref frmFAguarde formFAguarde)
				{
					formFAguarde.eCallCarregaCor += new mdlDataBaseConfig.frmFAguarde.delCallCarregaCor(formFAguarde_eCallCarregaCor);
				}

				private System.Drawing.Color formFAguarde_eCallCarregaCor()
				{
					return(m_clrFundo);
				}
			#endregion
			#region Configuracoes Avancadas
				private void m_llbConfiguracoesAvancadas_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
				{
					ShowDialogConfiguracoesAvancadas();
				}

				private void m_llbConfig_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
				{
                    ShowDialogAdmin();				
				}
			#endregion
			#region Botoes
				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					vSalvaDadosInterface();
					OnCallConfigBackup();
					OnCallSalvaDados();
					if (OnCallConfiguratedRight())
					{
						m_bModificado = true;
						this.Close();
					}
					else
					{
						OnCallConfigRestore();
						System.Windows.Forms.MessageBox.Show("Configure corretamente o banco de dados MySql!","Siscobras",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Warning);
					}
				}

				private void m_btCancelar_Click(object sender, System.EventArgs e)
				{
					m_bModificado = false;
					this.Close();
				}
			#endregion
		#endregion
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

		#region Carregamento dos Dados
			private void vCarregaDadosInterface()
			{
				m_txtServidorUtilizar.Text = m_strHost;
			}
		#endregion
		#region Salvamento dos Dados
			private void vSalvaDadosInterface()
			{
				m_strHost = m_txtServidorUtilizar.Text;
			}
		#endregion

		#region Servidores
			private void vRefreshServidores()
			{
//				System.Windows.Forms.ListViewItem lviHost;
//				m_lvServidores.Items.Clear();
//				System.Collections.ArrayList arlIpList = clsDataBaseConfig.arlReturnIpList();
//				if (arlIpList.Count > 0)
//				{
//					System.Net.IPAddress ipaMachine;
//
//					string strIp = "";
//					string strHost = "";
//					string strUser = "Siscobras";
//					string strPassword = "Siscobras";
//					string strDataBaseName = "Siscobras";
//
//					mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB = new mdlDataBaseAccess.clsDataBaseAccessMySql(ref m_cls_ter_TratadorErro,strIp,m_strPort,strUser,strPassword,strDataBaseName);
//
//					for (int nIpMachine = 0;nIpMachine < arlIpList.Count ; nIpMachine++)
//					{
//						ipaMachine = (System.Net.IPAddress)arlIpList[nIpMachine];
//						byte[] arrbyBase = ipaMachine.GetAddressBytes();
//						for (byte byIpRange = 1; byIpRange < 255; byIpRange++)
//						{
//							arrbyBase[3] = byIpRange;
//							strIp = arrbyBase[0] + "." + arrbyBase[1] + "." + arrbyBase[2] + "." + arrbyBase[3];
//							try
//							{
//								System.Net.IPHostEntry ipheInfo = System.Net.Dns.GetHostByAddress(strIp);
//								strHost = ipheInfo.HostName;
//								//cls_dba_ConnectionDB.Host = strIp;
//								if (cls_dba_ConnectionDB.bCanOpenConnection())
//								{
//									lviHost = m_lvServidores.Items.Add(strIp);
//									lviHost.SubItems.Add(strHost);
//									if (clsDataBaseConfig.bDataAccessRight(ref cls_dba_ConnectionDB))
//									{
//										lviHost.SubItems.Add("Sim");
//									}else{
//										lviHost.SubItems.Add("Não");
//									}
//									m_lvServidores.Refresh();
//								}
//							}catch{
//							}
//						}
//					}
//				}
//				if (m_formFAguarde != null)
//				{
//					m_formFAguarde.Close();
//					m_formFAguarde = null;
//				}
			}
		#endregion
		#region Admin
			private void vCarregaDadosAdmin(string strAdminUser, string strAdminPassword, out bool bServer, out bool bSqlServer, out bool bDataBase, out bool bUser, out bool bUserAssociated, out bool bDataBaseUpdated, out bool bDefaultData)
			{
				bServer = false;
				bSqlServer = false;
				bDataBase = false;
				bUser = false;
				bUserAssociated = false;
				bDataBaseUpdated = false;
				bDefaultData = false;

				mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB = new mdlDataBaseAccess.clsDataBaseAccessMySql(ref m_cls_ter_TratadorErro,m_strHost,m_strPort,m_strDataBaseName,m_strUser,m_strPassword);
				cls_dba_ConnectionDB.DBHost = m_strHost;
				cls_dba_ConnectionDB.DBPort = m_strPort;
				cls_dba_ConnectionDB.DBDataBaseName = m_strDataBaseName;
				cls_dba_ConnectionDB.DBUser = m_strUser;
				cls_dba_ConnectionDB.DBPassword = m_strPassword;
				cls_dba_ConnectionDB.DBAdminUser = strAdminUser;
				cls_dba_ConnectionDB.DBAdminPassword = strAdminPassword;

				if (bServer = cls_dba_ConnectionDB.bComputerAvailable(m_strHost))
				{
					if (bSqlServer = cls_dba_ConnectionDB.bServerAvailable())
					{
						if (bDataBase = cls_dba_ConnectionDB.bDataBaseAvailable())
						{
							if (bUser = cls_dba_ConnectionDB.bUserAvailable())
							{
								if (bUserAssociated = cls_dba_ConnectionDB.bUserAssociated())
								{
									cls_dba_ConnectionDB.ShowDialogsErrors = false;
									if (bDataBaseUpdated = (cls_dba_ConnectionDB.nUpdateDataBase() >= 0))
									{
										string strTemp; 
										bDefaultData = bDBDefaultData(out strTemp);
									}
								}
							}
						}
					}
				}
			}

			private bool bServer(out string strReturn)
			{
				strReturn = "Não foi possível localizar o servidor indicado.";
				return(false);
			}

			private bool bMySql(string strAdminUser,string strAdminPassword,out string strReturn)
			{
				strReturn = "A máquina escolhida deve possuir uma instalação do MySql.";
				return(false);
			}

			private bool bDataBase(string strAdminUser,string strAdminPassword,out string strReturn)
			{
				bool bReturn = false;
				strReturn = "";
				mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB = new mdlDataBaseAccess.clsDataBaseAccessMySql(ref m_cls_ter_TratadorErro,m_strHost,m_strPort,m_strDataBaseName,m_strUser,m_strPassword);
				cls_dba_ConnectionDB.DBHost = m_strHost;
				cls_dba_ConnectionDB.DBPort = m_strPort;
				cls_dba_ConnectionDB.DBDataBaseName = m_strDataBaseName;
				cls_dba_ConnectionDB.DBUser = m_strUser;
				cls_dba_ConnectionDB.DBPassword = m_strPassword;
				cls_dba_ConnectionDB.DBAdminUser = strAdminUser;
				cls_dba_ConnectionDB.DBAdminPassword = strAdminPassword;
				if (!(bReturn = cls_dba_ConnectionDB.bDataBaseCreate()))
					strReturn = "Não foi possível criar o banco de dados. Verifique se o usuário e senha de administrador estão corretos.";
				return(bReturn);
			}

			private bool bUser(string strAdminUser,string strAdminPassword,out string strReturn)
			{
				bool bReturn = false;
				strReturn = "";
				mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB = new mdlDataBaseAccess.clsDataBaseAccessMySql(ref m_cls_ter_TratadorErro,m_strHost,m_strPort,m_strDataBaseName,m_strUser,m_strPassword);
				cls_dba_ConnectionDB.DBHost = m_strHost;
				cls_dba_ConnectionDB.DBPort = m_strPort;
				cls_dba_ConnectionDB.DBDataBaseName = m_strDataBaseName;
				cls_dba_ConnectionDB.DBUser = m_strUser;
				cls_dba_ConnectionDB.DBPassword = m_strPassword;
				cls_dba_ConnectionDB.DBAdminUser = strAdminUser;
				cls_dba_ConnectionDB.DBAdminPassword = strAdminPassword;
				if (!(bReturn = cls_dba_ConnectionDB.bUserCreate()))
					strReturn = "Não foi possível criar o usuário do banco de dados. Verifique se o usuário e senha de administrador estão corretos.";
				return(bReturn);
			}

			private bool bUserAssociated(string strAdminUser,string strAdminPassword,out string strReturn)
			{
				bool bReturn = false;
				strReturn = "";
				mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB = new mdlDataBaseAccess.clsDataBaseAccessMySql(ref m_cls_ter_TratadorErro,m_strHost,m_strPort,m_strDataBaseName,m_strUser,m_strPassword);
				cls_dba_ConnectionDB.DBHost = m_strHost;
				cls_dba_ConnectionDB.DBPort = m_strPort;
				cls_dba_ConnectionDB.DBDataBaseName = m_strDataBaseName;
				cls_dba_ConnectionDB.DBUser = m_strUser;
				cls_dba_ConnectionDB.DBPassword = m_strPassword;
				cls_dba_ConnectionDB.DBAdminUser = strAdminUser;
				cls_dba_ConnectionDB.DBAdminPassword = strAdminPassword;
				if (!(bReturn = cls_dba_ConnectionDB.bUserAssociate()))
					strReturn = "Não foi possível associar o usuário ao bando de dados. Verifique se o usuário e senha de administrador estão corretos.";
				return(bReturn);
			}

			private bool bDataBaseUpdated(string strAdminUser,string strAdminPassword,out string strReturn)
			{
				bool bReturn = false;
				strReturn = "";
				mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB = new mdlDataBaseAccess.clsDataBaseAccessMySql(ref m_cls_ter_TratadorErro,m_strHost,m_strPort,m_strDataBaseName,m_strUser,m_strPassword);
				cls_dba_ConnectionDB.DBHost = m_strHost;
				cls_dba_ConnectionDB.DBPort = m_strPort;
				cls_dba_ConnectionDB.DBDataBaseName = m_strDataBaseName;
				cls_dba_ConnectionDB.DBUser = m_strUser;
				cls_dba_ConnectionDB.DBPassword = m_strPassword;
				cls_dba_ConnectionDB.DBAdminUser = strAdminUser;
				cls_dba_ConnectionDB.DBAdminPassword = strAdminPassword;
				cls_dba_ConnectionDB.ShowDialogsErrors = false;
				if (!(bReturn = (cls_dba_ConnectionDB.nUpdateDataBase() >= 0)))
					strReturn = "Não foi possível atualizar a estrutura do banco de dados.";
				return(bReturn);
			}

			private bool bDBDefaultData(out string strReturn)
			{
				mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB = new mdlDataBaseAccess.clsDataBaseAccessMySql(ref m_cls_ter_TratadorErro,m_strHost,m_strPort,m_strDataBaseName,m_strUser,m_strPassword);
				return(cls_dba_ConnectionDB.bSetDefaultData(out strReturn));
			}

		#endregion

		#region RetornaValores
			public void vRetornaValores(out string strHost,out string strPort,out string strDataBaseName,out string strUser,out string strPassword)
			{
				strHost = m_strHost; 
				strPort = m_strPort;
				strDataBaseName = m_strDataBaseName;
				strUser = m_strUser;
				strPassword = m_strPassword;	
			}
		#endregion
	}
}
