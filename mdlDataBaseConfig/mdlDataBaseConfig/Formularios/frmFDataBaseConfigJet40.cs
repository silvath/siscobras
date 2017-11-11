using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlDataBaseConfig
{
	/// <summary>
	/// Summary description for frmFDataBaseConfigJet40.
	/// </summary>
	public class frmFDataBaseConfigJet40 : mdlComponentesGraficos.FormFlutuante
	{
		#region Delegates
			public delegate System.Drawing.Color delCallCarregaCor();
			public delegate void delCallConfigBackup();
			public delegate void delCallConfigRestore();
			public delegate void delCallSalvaDados(string strPath,string strUser,string strPassword);
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
					eCallSalvaDados(m_strPath,m_strUser,m_strPassword);
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
			private mdlTratamentoErro.clsTratamentoErro m_cls_ter_TratadorErro;
			private System.Drawing.Color m_clrFundo = System.Drawing.Color.Green;
			
			// Configuracoes BD
			private string m_strPath = "";
			private string m_strUser = "";
			private string m_strPassword = "";	

			public bool m_bModificado = false;

			private System.Windows.Forms.GroupBox m_gbGeral;
			private System.Windows.Forms.GroupBox m_gbServidorUtilizar;
			private System.Windows.Forms.Label m_lbServidorUtilizar;
			private mdlComponentesGraficos.TextBox m_txtServidorUtilizar;
			private System.Windows.Forms.LinkLabel m_llbConfiguracoesAvancadas;
			private System.Windows.Forms.PictureBox pictureBox1;
			internal System.Windows.Forms.Button m_btOk;
			internal System.Windows.Forms.Button m_btCancelar;
			internal System.Windows.Forms.Button m_btBD;
			private System.Windows.Forms.ToolTip m_ttDica;
			private System.ComponentModel.IContainer components;
		#endregion
		#region Constructors and Destructors
			public frmFDataBaseConfigJet40(ref mdlTratamentoErro.clsTratamentoErro cls_ter_TratadorErro,string strPath,string strUser,string strPassword)
			{
				m_cls_ter_TratadorErro = cls_ter_TratadorErro;
				m_strPath = strPath;
				m_strUser = strUser;
				m_strPassword = strPassword;

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFDataBaseConfigJet40));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_gbServidorUtilizar = new System.Windows.Forms.GroupBox();
			this.m_btBD = new System.Windows.Forms.Button();
			this.m_lbServidorUtilizar = new System.Windows.Forms.Label();
			this.m_txtServidorUtilizar = new mdlComponentesGraficos.TextBox();
			this.m_llbConfiguracoesAvancadas = new System.Windows.Forms.LinkLabel();
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
			this.m_gbGeral.Controls.Add(this.m_llbConfiguracoesAvancadas);
			this.m_gbGeral.Controls.Add(this.pictureBox1);
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Location = new System.Drawing.Point(5, 0);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(392, 192);
			this.m_gbGeral.TabIndex = 1;
			this.m_gbGeral.TabStop = false;
			// 
			// m_gbServidorUtilizar
			// 
			this.m_gbServidorUtilizar.Controls.Add(this.m_btBD);
			this.m_gbServidorUtilizar.Controls.Add(this.m_lbServidorUtilizar);
			this.m_gbServidorUtilizar.Controls.Add(this.m_txtServidorUtilizar);
			this.m_gbServidorUtilizar.Location = new System.Drawing.Point(8, 82);
			this.m_gbServidorUtilizar.Name = "m_gbServidorUtilizar";
			this.m_gbServidorUtilizar.Size = new System.Drawing.Size(378, 49);
			this.m_gbServidorUtilizar.TabIndex = 78;
			this.m_gbServidorUtilizar.TabStop = false;
			// 
			// m_btBD
			// 
			this.m_btBD.BackColor = System.Drawing.SystemColors.Control;
			this.m_btBD.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btBD.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btBD.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btBD.Image = ((System.Drawing.Image)(resources.GetObject("m_btBD.Image")));
			this.m_btBD.Location = new System.Drawing.Point(343, 14);
			this.m_btBD.Name = "m_btBD";
			this.m_btBD.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btBD.Size = new System.Drawing.Size(25, 25);
			this.m_btBD.TabIndex = 73;
			this.m_ttDica.SetToolTip(this.m_btBD, "Procurar Banco de Dados");
			this.m_btBD.Click += new System.EventHandler(this.m_btBD_Click);
			// 
			// m_lbServidorUtilizar
			// 
			this.m_lbServidorUtilizar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbServidorUtilizar.Location = new System.Drawing.Point(7, 19);
			this.m_lbServidorUtilizar.Name = "m_lbServidorUtilizar";
			this.m_lbServidorUtilizar.Size = new System.Drawing.Size(56, 16);
			this.m_lbServidorUtilizar.TabIndex = 1;
			this.m_lbServidorUtilizar.Text = "Servidor:";
			// 
			// m_txtServidorUtilizar
			// 
			this.m_txtServidorUtilizar.Location = new System.Drawing.Point(71, 16);
			this.m_txtServidorUtilizar.Name = "m_txtServidorUtilizar";
			this.m_txtServidorUtilizar.Size = new System.Drawing.Size(265, 20);
			this.m_txtServidorUtilizar.TabIndex = 0;
			this.m_txtServidorUtilizar.Text = "";
			// 
			// m_llbConfiguracoesAvancadas
			// 
			this.m_llbConfiguracoesAvancadas.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_llbConfiguracoesAvancadas.Location = new System.Drawing.Point(47, 137);
			this.m_llbConfiguracoesAvancadas.Name = "m_llbConfiguracoesAvancadas";
			this.m_llbConfiguracoesAvancadas.Size = new System.Drawing.Size(298, 16);
			this.m_llbConfiguracoesAvancadas.TabIndex = 75;
			this.m_llbConfiguracoesAvancadas.TabStop = true;
			this.m_llbConfiguracoesAvancadas.Text = "Clique aqui para ajustar as configuracoes avançadas.";
			this.m_llbConfiguracoesAvancadas.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_llbConfiguracoesAvancadas_LinkClicked);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(8, 15);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(376, 64);
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
			this.m_btOk.Location = new System.Drawing.Point(136, 160);
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
			this.m_btCancelar.Location = new System.Drawing.Point(200, 160);
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
			// frmFDataBaseConfigJet40
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(400, 198);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.HelpButton = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFDataBaseConfigJet40";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Access";
			this.Load += new System.EventHandler(this.frmFDataBaseConfigJet40_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbServidorUtilizar.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region ShowDialogConfiguracoesAvancadas
			private void ShowDialogConfiguracoesAvancadas()
			{

				frmFDataBaseConfigJet40Config formFConfiguracoesAvancadas = new frmFDataBaseConfigJet40Config(m_strUser,m_strPassword);
				vInitializeEventsFormConfiguracoesAvancadas(ref formFConfiguracoesAvancadas);
				formFConfiguracoesAvancadas.ShowDialog();
				if (formFConfiguracoesAvancadas.m_bModificado)
				{
					formFConfiguracoesAvancadas.vRetornaDados(out m_strUser,out m_strPassword);
				}
				formFConfiguracoesAvancadas = null;
			}

			private void vInitializeEventsFormConfiguracoesAvancadas(ref frmFDataBaseConfigJet40Config formFConfiguracoesAvancadas)
			{

				// Cor 
				formFConfiguracoesAvancadas.eCallCarregaCor += new mdlDataBaseConfig.frmFDataBaseConfigJet40Config.delCallCarregaCor(formFConfiguracoesAvancadas_eCallCarregaCor);
			}

			private System.Drawing.Color formFConfiguracoesAvancadas_eCallCarregaCor()
			{
				return(m_clrFundo);
			}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFDataBaseConfigJet40_Load(object sender, System.EventArgs e)
				{
					OnCallCarregaCor();
					vMostraCor();
					vCarregaDadosInterface();
				}
			#endregion
			#region LinkLabels
				private void m_llbConfiguracoesAvancadas_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
				{
					ShowDialogConfiguracoesAvancadas();
				}
			#endregion
			#region Botoes
				private void m_btBD_Click(object sender, System.EventArgs e)
				{
                    System.Windows.Forms.OpenFileDialog dlgfoDataBase = new OpenFileDialog();
					if ((System.IO.File.Exists(m_txtServidorUtilizar.Text)) && (m_txtServidorUtilizar.Text.ToUpper().EndsWith(".MDB")))
					{
						dlgfoDataBase.FileName = m_txtServidorUtilizar.Text;
					}
					dlgfoDataBase.Filter = "Bancos de dados Access 2000 |*.mdb";

					if (dlgfoDataBase.ShowDialog() == System.Windows.Forms.DialogResult.OK)
					{
						m_txtServidorUtilizar.Text = dlgfoDataBase.FileName;
					}
				}

				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					vSalvaDadosInterface();
					OnCallConfigBackup();
					OnCallSalvaDados();
					if (OnCallConfiguratedRight())
					{
						m_bModificado = true;
						this.Close();
					}else{
						OnCallConfigRestore();
						System.Windows.Forms.MessageBox.Show("O endereço do banco de dados não é válido!","Siscobras",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Warning);
					}
				}
				private void m_btCancelar_Click(object sender, System.EventArgs e)
				{
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
				m_txtServidorUtilizar.Text = m_strPath;
			}
		#endregion
		#region Salvamento dos Dados
			private void vSalvaDadosInterface()
			{
				m_strPath = m_txtServidorUtilizar.Text;
			}
		#endregion
	}
}
