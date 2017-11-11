using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlDataBaseConfig
{
	/// <summary>
	/// Summary description for frmFDataBaseConfig.
	/// </summary>
	internal class frmFDataBaseConfig : mdlComponentesGraficos.FormFlutuante
	{
		#region Delegates
			public delegate System.Drawing.Color delCallCarregaCor();
			public delegate mdlDataBaseConfig.TiposBancoDados delCallCarregaBaseDados();
			public delegate void delCallSalvaBaseDados();
			public delegate void delCallChangeDataBase(mdlDataBaseConfig.TiposBancoDados enumDataBaseType);
			public delegate bool delCallShowDialogConfigEspecific();
			public delegate bool delCallDataBaseConfiguratedRight();
		#endregion
		#region Events
			public event delCallCarregaCor eCallCarregaCor;
			public event delCallCarregaBaseDados eCallCarregaBaseDados;
			public event delCallChangeDataBase eCallChangeDataBase;
			public event delCallSalvaBaseDados eCallSalvaBaseDados;
			public event delCallShowDialogConfigEspecific eCallShowDialogConfigEspecific;
			public event delCallDataBaseConfiguratedRight eCallDataBaseConfiguratedRight;
		#endregion
		#region Events Methods
			protected virtual void OnCallCarregaCor()
			{
				if (eCallCarregaCor != null)
				{
					m_clrFundo = eCallCarregaCor();
				}
			}

			protected virtual void OnCallCarregaBaseDados()
			{
				if (eCallCarregaBaseDados != null)
				{
					m_enumTipoBancoDados = eCallCarregaBaseDados();
				}
			}

			protected virtual void OnCallChangeDataBase()
			{
				if (eCallChangeDataBase != null)
				{
					eCallChangeDataBase(m_enumTipoBancoDados);
				}
			}

			protected virtual void OnCallSalvaBaseDados()
			{
				if (eCallSalvaBaseDados != null)
				{
					eCallSalvaBaseDados();
				}
			}

			protected virtual void OnCallShowDialogConfigEspecific()
			{
				if (eCallShowDialogConfigEspecific != null)
				{
					eCallShowDialogConfigEspecific();
				}
			}

			protected virtual bool OnCallDataBaseConfiguratedRight()
			{
				bool bRetorno = false;
				if (eCallDataBaseConfiguratedRight != null)
				{
					bRetorno = eCallDataBaseConfiguratedRight();
				}
				return(bRetorno);
			}
		#endregion
		#region Atributes
			private System.Drawing.Color m_clrFundo = System.Drawing.Color.Green;
			private System.Drawing.Color m_clrSelecionado = System.Drawing.Color.Green;
			private TiposBancoDados m_enumTipoBancoDados;
			public bool m_bModificado = false;

			private System.ComponentModel.IContainer components;
			internal System.Windows.Forms.Button m_btOk;
			internal System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.GroupBox m_gbBaseDados;
			private System.Windows.Forms.RadioButton m_rbJet40;
			private System.Windows.Forms.RadioButton m_rbMySql;
			private System.Windows.Forms.RadioButton m_rbFireBird;
			private System.Windows.Forms.ToolTip m_ttDica;
			private mdlComponentesGraficos.TextBox textBox1;
			private System.Windows.Forms.GroupBox m_gbInformacoes;
			private System.Windows.Forms.Panel m_pnMysql;
			private System.Windows.Forms.Panel m_pnFirebird;
			private System.Windows.Forms.Panel m_pnJet40;
			private System.Windows.Forms.TextBox m_txtInformacao;
			private System.Windows.Forms.LinkLabel m_llbConfigura;
		private System.Windows.Forms.Panel m_pnSqlServer;
		private System.Windows.Forms.RadioButton m_rbSqlServer;
			private System.Windows.Forms.GroupBox m_gbGeral;
		#endregion
		#region Constructors and Destructors
			public frmFDataBaseConfig()
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFDataBaseConfig));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_gbInformacoes = new System.Windows.Forms.GroupBox();
			this.m_llbConfigura = new System.Windows.Forms.LinkLabel();
			this.m_txtInformacao = new System.Windows.Forms.TextBox();
			this.m_gbBaseDados = new System.Windows.Forms.GroupBox();
			this.m_pnFirebird = new System.Windows.Forms.Panel();
			this.m_rbFireBird = new System.Windows.Forms.RadioButton();
			this.m_pnSqlServer = new System.Windows.Forms.Panel();
			this.m_rbSqlServer = new System.Windows.Forms.RadioButton();
			this.m_pnMysql = new System.Windows.Forms.Panel();
			this.m_rbMySql = new System.Windows.Forms.RadioButton();
			this.m_pnJet40 = new System.Windows.Forms.Panel();
			this.m_rbJet40 = new System.Windows.Forms.RadioButton();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.textBox1 = new mdlComponentesGraficos.TextBox();
			this.m_ttDica = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbGeral.SuspendLayout();
			this.m_gbInformacoes.SuspendLayout();
			this.m_gbBaseDados.SuspendLayout();
			this.m_pnFirebird.SuspendLayout();
			this.m_pnSqlServer.SuspendLayout();
			this.m_pnMysql.SuspendLayout();
			this.m_pnJet40.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbGeral.Controls.Add(this.m_gbInformacoes);
			this.m_gbGeral.Controls.Add(this.m_gbBaseDados);
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Location = new System.Drawing.Point(4, 0);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(452, 240);
			this.m_gbGeral.TabIndex = 0;
			this.m_gbGeral.TabStop = false;
			// 
			// m_gbInformacoes
			// 
			this.m_gbInformacoes.Controls.Add(this.m_llbConfigura);
			this.m_gbInformacoes.Controls.Add(this.m_txtInformacao);
			this.m_gbInformacoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbInformacoes.Location = new System.Drawing.Point(6, 155);
			this.m_gbInformacoes.Name = "m_gbInformacoes";
			this.m_gbInformacoes.Size = new System.Drawing.Size(434, 53);
			this.m_gbInformacoes.TabIndex = 74;
			this.m_gbInformacoes.TabStop = false;
			this.m_gbInformacoes.Text = "Informações";
			// 
			// m_llbConfigura
			// 
			this.m_llbConfigura.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.m_llbConfigura.Location = new System.Drawing.Point(106, 35);
			this.m_llbConfigura.Name = "m_llbConfigura";
			this.m_llbConfigura.Size = new System.Drawing.Size(222, 16);
			this.m_llbConfigura.TabIndex = 1;
			this.m_llbConfigura.TabStop = true;
			this.m_llbConfigura.Text = "Configurar banco de dados selecionado. ";
			this.m_llbConfigura.Visible = false;
			this.m_llbConfigura.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_llbConfigura_LinkClicked);
			// 
			// m_txtInformacao
			// 
			this.m_txtInformacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txtInformacao.Location = new System.Drawing.Point(9, 17);
			this.m_txtInformacao.Multiline = true;
			this.m_txtInformacao.Name = "m_txtInformacao";
			this.m_txtInformacao.ReadOnly = true;
			this.m_txtInformacao.Size = new System.Drawing.Size(415, 15);
			this.m_txtInformacao.TabIndex = 0;
			this.m_txtInformacao.Text = "Escolha um dos bancos de dados acima.";
			// 
			// m_gbBaseDados
			// 
			this.m_gbBaseDados.Controls.Add(this.m_pnFirebird);
			this.m_gbBaseDados.Controls.Add(this.m_pnSqlServer);
			this.m_gbBaseDados.Controls.Add(this.m_pnMysql);
			this.m_gbBaseDados.Controls.Add(this.m_pnJet40);
			this.m_gbBaseDados.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbBaseDados.Location = new System.Drawing.Point(6, 10);
			this.m_gbBaseDados.Name = "m_gbBaseDados";
			this.m_gbBaseDados.Size = new System.Drawing.Size(434, 142);
			this.m_gbBaseDados.TabIndex = 72;
			this.m_gbBaseDados.TabStop = false;
			this.m_gbBaseDados.Text = "Bancos de dados disponíveis";
			// 
			// m_pnFirebird
			// 
			this.m_pnFirebird.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(192)), ((System.Byte)(192)));
			this.m_pnFirebird.Controls.Add(this.m_rbFireBird);
			this.m_pnFirebird.Location = new System.Drawing.Point(8, 78);
			this.m_pnFirebird.Name = "m_pnFirebird";
			this.m_pnFirebird.Size = new System.Drawing.Size(208, 58);
			this.m_pnFirebird.TabIndex = 1;
			// 
			// m_rbFireBird
			// 
			this.m_rbFireBird.Appearance = System.Windows.Forms.Appearance.Button;
			this.m_rbFireBird.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_rbFireBird.Enabled = false;
			this.m_rbFireBird.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.m_rbFireBird.Location = new System.Drawing.Point(4, 4);
			this.m_rbFireBird.Name = "m_rbFireBird";
			this.m_rbFireBird.Size = new System.Drawing.Size(200, 50);
			this.m_rbFireBird.TabIndex = 4;
			this.m_rbFireBird.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.m_ttDica.SetToolTip(this.m_rbFireBird, "Utilizar uma base de dados FireBird");
			this.m_rbFireBird.CheckedChanged += new System.EventHandler(this.m_rbFireBird_CheckedChanged);
			// 
			// m_pnSqlServer
			// 
			this.m_pnSqlServer.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(192)), ((System.Byte)(192)));
			this.m_pnSqlServer.Controls.Add(this.m_rbSqlServer);
			this.m_pnSqlServer.Location = new System.Drawing.Point(217, 17);
			this.m_pnSqlServer.Name = "m_pnSqlServer";
			this.m_pnSqlServer.Size = new System.Drawing.Size(208, 58);
			this.m_pnSqlServer.TabIndex = 2;
			// 
			// m_rbSqlServer
			// 
			this.m_rbSqlServer.Appearance = System.Windows.Forms.Appearance.Button;
			this.m_rbSqlServer.BackColor = System.Drawing.Color.White;
			this.m_rbSqlServer.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_rbSqlServer.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_rbSqlServer.Location = new System.Drawing.Point(4, 4);
			this.m_rbSqlServer.Name = "m_rbSqlServer";
			this.m_rbSqlServer.Size = new System.Drawing.Size(200, 50);
			this.m_rbSqlServer.TabIndex = 5;
			this.m_rbSqlServer.Text = "SqlServer / MSDE";
			this.m_rbSqlServer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.m_ttDica.SetToolTip(this.m_rbSqlServer, "Utilizar uma base de dados PortgreSQL");
			this.m_rbSqlServer.CheckedChanged += new System.EventHandler(this.m_rbPostgreSQL_CheckedChanged);
			// 
			// m_pnMysql
			// 
			this.m_pnMysql.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(192)), ((System.Byte)(192)));
			this.m_pnMysql.Controls.Add(this.m_rbMySql);
			this.m_pnMysql.Location = new System.Drawing.Point(218, 78);
			this.m_pnMysql.Name = "m_pnMysql";
			this.m_pnMysql.Size = new System.Drawing.Size(208, 58);
			this.m_pnMysql.TabIndex = 0;
			// 
			// m_rbMySql
			// 
			this.m_rbMySql.Appearance = System.Windows.Forms.Appearance.Button;
			this.m_rbMySql.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_rbMySql.Enabled = true;
			this.m_rbMySql.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_rbMySql.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.m_rbMySql.Location = new System.Drawing.Point(4, 5);
			this.m_rbMySql.Name = "m_rbMySql";
			this.m_rbMySql.Size = new System.Drawing.Size(200, 50);
			this.m_rbMySql.TabIndex = 3;
			this.m_rbMySql.Text = "MySql";
			this.m_rbMySql.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.m_ttDica.SetToolTip(this.m_rbMySql, "Utilizar uma base de dados MySql");
			this.m_rbMySql.CheckedChanged += new System.EventHandler(this.m_rbMySql_CheckedChanged);
			// 
			// m_pnJet40
			// 
			this.m_pnJet40.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(192)), ((System.Byte)(192)));
			this.m_pnJet40.Controls.Add(this.m_rbJet40);
			this.m_pnJet40.Location = new System.Drawing.Point(7, 17);
			this.m_pnJet40.Name = "m_pnJet40";
			this.m_pnJet40.Size = new System.Drawing.Size(208, 58);
			this.m_pnJet40.TabIndex = 3;
			// 
			// m_rbJet40
			// 
			this.m_rbJet40.Appearance = System.Windows.Forms.Appearance.Button;
			this.m_rbJet40.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_rbJet40.Image = ((System.Drawing.Image)(resources.GetObject("m_rbJet40.Image")));
			this.m_rbJet40.Location = new System.Drawing.Point(4, 4);
			this.m_rbJet40.Name = "m_rbJet40";
			this.m_rbJet40.Size = new System.Drawing.Size(200, 50);
			this.m_rbJet40.TabIndex = 2;
			this.m_rbJet40.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.m_ttDica.SetToolTip(this.m_rbJet40, "Utilizar uma base de dados Microsoft Access 2000");
			this.m_rbJet40.CheckedChanged += new System.EventHandler(this.m_rbJet40_CheckedChanged);
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(162, 210);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 70;
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
			this.m_btCancelar.Location = new System.Drawing.Point(226, 210);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 71;
			this.m_ttDica.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			this.m_btCancelar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_btCancelar_KeyDown);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(0, 0);
			this.textBox1.Name = "textBox1";
			this.textBox1.TabIndex = 0;
			this.textBox1.Text = "";
			// 
			// m_ttDica
			// 
			this.m_ttDica.AutomaticDelay = 100;
			this.m_ttDica.AutoPopDelay = 5000;
			this.m_ttDica.InitialDelay = 100;
			this.m_ttDica.ReshowDelay = 20;
			// 
			// frmFDataBaseConfig
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(466, 248);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.HelpButton = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFDataBaseConfig";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Configurando o banco de dados";
			this.Load += new System.EventHandler(this.frmFDataBaseConfig_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbInformacoes.ResumeLayout(false);
			this.m_gbBaseDados.ResumeLayout(false);
			this.m_pnFirebird.ResumeLayout(false);
			this.m_pnSqlServer.ResumeLayout(false);
			this.m_pnMysql.ResumeLayout(false);
			this.m_pnJet40.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFDataBaseConfig_Load(object sender, System.EventArgs e)
				{
					OnCallCarregaCor();
					vMostraCor();
					OnCallCarregaBaseDados();
					vSelecionaBaseDadosCarregada();
				}
			#endregion
			#region RadioButtons

				private void m_rbMySql_CheckedChanged(object sender, System.EventArgs e)
				{
					if (m_rbMySql.Checked)
					{
						m_rbJet40.Checked = false;
						m_rbFireBird.Checked = false;
						m_rbSqlServer.Checked = false;
						AdquiriBancoDadosSelecionado();
						RefreshCorBancosDados();
					}
				}

				private void m_rbJet40_CheckedChanged(object sender, System.EventArgs e)
				{
					if (m_rbJet40.Checked)
					{
						m_rbMySql.Checked = false;
						m_rbFireBird.Checked = false;
						m_rbSqlServer.Checked = false;
						AdquiriBancoDadosSelecionado();
						RefreshCorBancosDados();
					}
				}

				private void m_rbFireBird_CheckedChanged(object sender, System.EventArgs e)
				{
					if (m_rbFireBird.Checked)
					{
						m_rbMySql.Checked = false;
						m_rbJet40.Checked = false;
						m_rbSqlServer.Checked = false;
						AdquiriBancoDadosSelecionado();
						RefreshCorBancosDados();
					}
				}

				private void m_rbPostgreSQL_CheckedChanged(object sender, System.EventArgs e)
				{
					if (m_rbSqlServer.Checked)
					{
						m_rbMySql.Checked = false;
						m_rbJet40.Checked = false;
						m_rbFireBird.Checked = false;
						AdquiriBancoDadosSelecionado();
						RefreshCorBancosDados();
					}
				}
			#endregion
			#region Link Configuracao
				private void m_llbConfigura_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
				{
					OnCallChangeDataBase();
					OnCallShowDialogConfigEspecific();
				}
			#endregion
			#region Botoes
				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					OnCallChangeDataBase();
					if (OnCallDataBaseConfiguratedRight())
					{
						OnCallSalvaBaseDados();
						m_bModificado = true;
						this.Close();
					}else{
						mdlMensagens.clsMensagens.ShowInformation("Você precisa configurar o banco de dados corretamente.");
					}
				}

				private void m_btCancelar_Click(object sender, System.EventArgs e)
				{
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

			private void RefreshCorBancosDados()
			{
				m_pnMysql.BackColor = this.BackColor;
				m_pnJet40.BackColor = this.BackColor;
				m_pnFirebird.BackColor = this.BackColor;
				m_pnSqlServer.BackColor = this.BackColor;
				switch(m_enumTipoBancoDados)
				{
					case TiposBancoDados.MySql:
						m_pnMysql.BackColor = m_clrSelecionado;
						m_txtInformacao.Text = "Banco de Dados Mysql";
						break;
					case TiposBancoDados.Jet40:
						m_pnJet40.BackColor = m_clrSelecionado;
						m_txtInformacao.Text = "Banco de Dados Access 2000";
						break;
					case TiposBancoDados.Firebird:
						m_pnFirebird.BackColor = m_clrSelecionado;
						m_txtInformacao.Text = "Banco de Dados FireBird";
						break;
					case TiposBancoDados.SqlServer:
						m_pnSqlServer.BackColor = m_clrSelecionado;
						m_txtInformacao.Text = "Banco de Dados SqlServer";
						break;
				}
			}
		#endregion

		#region Metodos
			private void AdquiriBancoDadosSelecionado()
			{
				m_llbConfigura.Visible = false;

				if (m_rbMySql.Checked)
				{
					m_enumTipoBancoDados = TiposBancoDados.MySql;
					m_llbConfigura.Visible = true;
				}
				if (m_rbJet40.Checked)
				{
					m_enumTipoBancoDados = TiposBancoDados.Jet40;
					m_llbConfigura.Visible = true;
				}
				if (m_rbFireBird.Checked)
				{
					m_enumTipoBancoDados = TiposBancoDados.Firebird;
					m_llbConfigura.Visible = true;
				}
				if (m_rbSqlServer.Checked)
				{
					m_enumTipoBancoDados = TiposBancoDados.SqlServer;
					m_llbConfigura.Visible = true;
				}
			}

			private void vSelecionaBaseDadosCarregada()
			{
				switch(m_enumTipoBancoDados)
				{
                    case mdlDataBaseConfig.TiposBancoDados.Jet40:
						m_rbJet40.Checked = true;
						break;
					case mdlDataBaseConfig.TiposBancoDados.SqlServer:
						m_rbSqlServer.Checked = true;
						break;
					case mdlDataBaseConfig.TiposBancoDados.MySql:
						m_rbMySql.Checked = true;
						break;
					default:
						break;
				}
			}
		#endregion

		private void m_btCancelar_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			//TODO: Remove this later
			if (e.Alt && e.Control)
			{
				m_rbMySql.Text = "MySql";
				m_rbMySql.Enabled = true;
			}
		}
	}
}
