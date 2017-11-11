using System;
using System.Collections;
using System.Windows.Forms;

namespace mdlAgentes.Frames
{
	/// <summary>
	/// Summary description for frmFCadastroAgentes.
	/// </summary>
	internal class frmFCadastroAgentes : mdlComponentesGraficos.FormFlutuante
	{
		#region Atributos
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
		protected string m_strEnderecoExecutavel;

		public bool m_bModificado = false;

		private bool m_bCadastroNovo = false;

		private System.Windows.Forms.GroupBox m_gbFrame;
		private System.Windows.Forms.GroupBox m_gbFields;
		private System.Windows.Forms.Button m_btOk;
		private System.Windows.Forms.Button m_btCancelar;
		private mdlComponentesGraficos.TextBox m_tbNome;
		private System.Windows.Forms.Label m_lSite;
		private mdlComponentesGraficos.TextBox m_tbSite;
		private System.Windows.Forms.Label m_lNome;
		private System.Windows.Forms.Label m_lContato;
		private mdlComponentesGraficos.TextBox m_tbContato;
		private System.Windows.Forms.Label m_lEmail;
		private mdlComponentesGraficos.TextBox m_tbEmail;
		private System.Windows.Forms.Label m_lTelefone;
		private mdlComponentesGraficos.TextBox m_tbTelefone;
		private System.Windows.Forms.Label m_lFax;
		private mdlComponentesGraficos.TextBox m_tbFax;
		private System.Windows.Forms.ToolTip m_ttCadastroAgentes;
		private System.ComponentModel.IContainer components;
		#endregion

		#region Construtores & Destrutores
		public frmFCadastroAgentes(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, string EnderecoExecutavel, bool bCadastroNovo)
		{
			InitializeComponent();

			m_cls_ter_tratadorErro = tratadorErro;
			m_strEnderecoExecutavel = EnderecoExecutavel;
			m_bCadastroNovo = bCadastroNovo;
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
		public delegate void delCallCarregaDadosInterface(ref mdlComponentesGraficos.TextBox tbNome, ref mdlComponentesGraficos.TextBox tbSite, ref mdlComponentesGraficos.TextBox tbContato, ref mdlComponentesGraficos.TextBox tbEmail, ref mdlComponentesGraficos.TextBox tbTelefone, ref mdlComponentesGraficos.TextBox tbFax);
		public delegate void delCallSalvaDadosInterface(ref mdlComponentesGraficos.TextBox tbNome, ref mdlComponentesGraficos.TextBox tbSite, ref mdlComponentesGraficos.TextBox tbContato, ref mdlComponentesGraficos.TextBox tbEmail, ref mdlComponentesGraficos.TextBox tbTelefone, ref mdlComponentesGraficos.TextBox tbFax);
		public delegate void delCallSalvaDadosBD(bool bModificado);
		#endregion
		#region Events
		public event delCallCarregaDadosInterface eCallCarregaDadosInterface;
		public event delCallSalvaDadosInterface eCallSalvaDadosInterface;
		public event delCallSalvaDadosBD eCallSalvaDadosBD;
		#endregion
		#region Events Methods
		protected virtual void OnCallCarregaDadosInterface()
		{
			if (eCallCarregaDadosInterface != null)
				eCallCarregaDadosInterface(ref m_tbNome, ref m_tbSite, ref m_tbContato, ref m_tbEmail, ref m_tbTelefone, ref m_tbFax);
		}
		protected virtual void OnCallSalvaDadosInterface()
		{
			if (eCallSalvaDadosInterface != null)
				eCallSalvaDadosInterface(ref m_tbNome, ref m_tbSite, ref m_tbContato, ref m_tbEmail, ref m_tbTelefone, ref m_tbFax);
		}
		protected virtual void OnCallSalvaDadosBD()
		{
			if (eCallSalvaDadosBD != null)
				eCallSalvaDadosBD(m_bModificado);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFCadastroAgentes));
			this.m_gbFrame = new System.Windows.Forms.GroupBox();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbFields = new System.Windows.Forms.GroupBox();
			this.m_lFax = new System.Windows.Forms.Label();
			this.m_tbFax = new mdlComponentesGraficos.TextBox();
			this.m_tbTelefone = new mdlComponentesGraficos.TextBox();
			this.m_lEmail = new System.Windows.Forms.Label();
			this.m_tbEmail = new mdlComponentesGraficos.TextBox();
			this.m_lContato = new System.Windows.Forms.Label();
			this.m_tbContato = new mdlComponentesGraficos.TextBox();
			this.m_tbNome = new mdlComponentesGraficos.TextBox();
			this.m_lNome = new System.Windows.Forms.Label();
			this.m_lSite = new System.Windows.Forms.Label();
			this.m_tbSite = new mdlComponentesGraficos.TextBox();
			this.m_lTelefone = new System.Windows.Forms.Label();
			this.m_ttCadastroAgentes = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbFrame.SuspendLayout();
			this.m_gbFields.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbFrame
			// 
			this.m_gbFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFrame.Controls.Add(this.m_btOk);
			this.m_gbFrame.Controls.Add(this.m_btCancelar);
			this.m_gbFrame.Controls.Add(this.m_gbFields);
			this.m_gbFrame.Location = new System.Drawing.Point(2, 0);
			this.m_gbFrame.Name = "m_gbFrame";
			this.m_gbFrame.Size = new System.Drawing.Size(198, 213);
			this.m_gbFrame.TabIndex = 0;
			this.m_gbFrame.TabStop = false;
			// 
			// m_btOk
			// 
			this.m_btOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(39, 182);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 3;
			this.m_ttCadastroAgentes.SetToolTip(this.m_btOk, "Confirmar");
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(103, 182);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 4;
			this.m_ttCadastroAgentes.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbFields
			// 
			this.m_gbFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFields.Controls.Add(this.m_lFax);
			this.m_gbFields.Controls.Add(this.m_tbFax);
			this.m_gbFields.Controls.Add(this.m_tbTelefone);
			this.m_gbFields.Controls.Add(this.m_lEmail);
			this.m_gbFields.Controls.Add(this.m_tbEmail);
			this.m_gbFields.Controls.Add(this.m_lContato);
			this.m_gbFields.Controls.Add(this.m_tbContato);
			this.m_gbFields.Controls.Add(this.m_tbNome);
			this.m_gbFields.Controls.Add(this.m_lNome);
			this.m_gbFields.Controls.Add(this.m_lSite);
			this.m_gbFields.Controls.Add(this.m_tbSite);
			this.m_gbFields.Controls.Add(this.m_lTelefone);
			this.m_gbFields.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbFields.Location = new System.Drawing.Point(8, 8);
			this.m_gbFields.Name = "m_gbFields";
			this.m_gbFields.Size = new System.Drawing.Size(182, 169);
			this.m_gbFields.TabIndex = 0;
			this.m_gbFields.TabStop = false;
			this.m_gbFields.Text = "Cadastro / Edição";
			// 
			// m_lFax
			// 
			this.m_lFax.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lFax.Location = new System.Drawing.Point(8, 144);
			this.m_lFax.Name = "m_lFax";
			this.m_lFax.Size = new System.Drawing.Size(27, 16);
			this.m_lFax.TabIndex = 12;
			this.m_lFax.Text = "Fax:";
			this.m_lFax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_tbFax
			// 
			this.m_tbFax.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_tbFax.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbFax.Location = new System.Drawing.Point(55, 137);
			this.m_tbFax.Name = "m_tbFax";
			this.m_tbFax.Size = new System.Drawing.Size(119, 20);
			this.m_tbFax.TabIndex = 11;
			this.m_tbFax.Text = "";
			// 
			// m_tbTelefone
			// 
			this.m_tbTelefone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_tbTelefone.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbTelefone.Location = new System.Drawing.Point(55, 113);
			this.m_tbTelefone.Name = "m_tbTelefone";
			this.m_tbTelefone.Size = new System.Drawing.Size(119, 20);
			this.m_tbTelefone.TabIndex = 9;
			this.m_tbTelefone.Text = "";
			// 
			// m_lEmail
			// 
			this.m_lEmail.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lEmail.Location = new System.Drawing.Point(8, 96);
			this.m_lEmail.Name = "m_lEmail";
			this.m_lEmail.Size = new System.Drawing.Size(40, 16);
			this.m_lEmail.TabIndex = 8;
			this.m_lEmail.Text = "E-Mail:";
			this.m_lEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_tbEmail
			// 
			this.m_tbEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_tbEmail.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbEmail.Location = new System.Drawing.Point(55, 89);
			this.m_tbEmail.Name = "m_tbEmail";
			this.m_tbEmail.Size = new System.Drawing.Size(119, 20);
			this.m_tbEmail.TabIndex = 7;
			this.m_tbEmail.Text = "";
			// 
			// m_lContato
			// 
			this.m_lContato.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lContato.Location = new System.Drawing.Point(8, 72);
			this.m_lContato.Name = "m_lContato";
			this.m_lContato.Size = new System.Drawing.Size(47, 16);
			this.m_lContato.TabIndex = 6;
			this.m_lContato.Text = "Contato:";
			this.m_lContato.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_tbContato
			// 
			this.m_tbContato.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_tbContato.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbContato.Location = new System.Drawing.Point(55, 65);
			this.m_tbContato.Name = "m_tbContato";
			this.m_tbContato.Size = new System.Drawing.Size(119, 20);
			this.m_tbContato.TabIndex = 5;
			this.m_tbContato.Text = "";
			// 
			// m_tbNome
			// 
			this.m_tbNome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_tbNome.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbNome.Location = new System.Drawing.Point(43, 17);
			this.m_tbNome.Name = "m_tbNome";
			this.m_tbNome.Size = new System.Drawing.Size(131, 20);
			this.m_tbNome.TabIndex = 1;
			this.m_tbNome.Text = "";
			// 
			// m_lNome
			// 
			this.m_lNome.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lNome.Location = new System.Drawing.Point(8, 24);
			this.m_lNome.Name = "m_lNome";
			this.m_lNome.Size = new System.Drawing.Size(38, 16);
			this.m_lNome.TabIndex = 4;
			this.m_lNome.Text = "Nome:";
			this.m_lNome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_lSite
			// 
			this.m_lSite.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lSite.Location = new System.Drawing.Point(8, 48);
			this.m_lSite.Name = "m_lSite";
			this.m_lSite.Size = new System.Drawing.Size(27, 16);
			this.m_lSite.TabIndex = 3;
			this.m_lSite.Text = "Site:";
			this.m_lSite.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_tbSite
			// 
			this.m_tbSite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_tbSite.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbSite.Location = new System.Drawing.Point(43, 41);
			this.m_tbSite.Name = "m_tbSite";
			this.m_tbSite.Size = new System.Drawing.Size(131, 20);
			this.m_tbSite.TabIndex = 2;
			this.m_tbSite.Text = "";
			// 
			// m_lTelefone
			// 
			this.m_lTelefone.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lTelefone.Location = new System.Drawing.Point(8, 120);
			this.m_lTelefone.Name = "m_lTelefone";
			this.m_lTelefone.Size = new System.Drawing.Size(51, 16);
			this.m_lTelefone.TabIndex = 10;
			this.m_lTelefone.Text = "Telefone:";
			this.m_lTelefone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_ttCadastroAgentes
			// 
			this.m_ttCadastroAgentes.AutomaticDelay = 100;
			this.m_ttCadastroAgentes.AutoPopDelay = 5000;
			this.m_ttCadastroAgentes.InitialDelay = 100;
			this.m_ttCadastroAgentes.ReshowDelay = 20;
			// 
			// frmFCadastroAgentes
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(202, 215);
			this.Controls.Add(this.m_gbFrame);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFCadastroAgentes";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Agentes";
			this.Load += new System.EventHandler(this.frmFCadastroAgentes_Load);
			this.m_gbFrame.ResumeLayout(false);
			this.m_gbFields.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Procedimentos Para Troca de Cor
		/// <summary>
		/// Troca a cor do Formulario Controlado
		/// </summary>
		private void trocaCor()
		{
			try
			{
				mdlPaletaDeCores.clsPaletaDeCores controlPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini", "SiscobrasCorSecundaria");
				controlPaletaCores.mostraCorAtual();
				mostraCor();
			} 
			catch (Exception erro) 
			{
				Object err = (Object)erro;
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		/// <summary>
		/// Mostra a cor do Formulario Controlado
		/// </summary>
		private void mostraCor()
		{
			try
			{
				mdlPaletaDeCores.clsPaletaDeCores controlPaletaDeCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini", "SiscobrasCorSecundaria");
				this.BackColor = controlPaletaDeCores.retornaCorAtual();
				for (int cont = 0; cont < this.Controls.Count; cont++) 
				{
					this.Controls[cont].BackColor = this.BackColor;
					for (int cont2 = 0; cont2 < this.Controls[cont].Controls.Count; cont2++)
					{
						if ((this.Controls[cont].Controls[cont2].GetType().ToString() != "System.Windows.Forms.ListView") && (this.Controls[cont].Controls[cont2].GetType().ToString() != "mdlComponentes.compTextNumber"))
						{
							this.Controls[cont].Controls[cont2].BackColor = this.BackColor;
						}
						for (int cont3 = 0; cont3 < this.Controls[cont].Controls[cont2].Controls.Count; cont3++)
						{
							if ((this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.TextBox") ||
								((this.Controls[cont].Controls[cont2].Controls[cont3].Name == "m_lvDadosImportadores") &&
								(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() == 
								"mdlComponentesGraficos.ListView")))
							{
								this.Controls[cont].Controls[cont2].Controls[cont3].BackColor = this.BackColor;
							}
						}
					}
				}
				setaCor();
			} 
			catch (Exception erro) 
			{ 
				Object err = (Object)erro;
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}

		#endregion

		#region Get & Set
		public void setTextoGroupBox(string strTexto)
		{
			m_gbFields.Text = strTexto;
		}
		private void setaCor()
		{
			if (m_bCadastroNovo)
			{
				m_lNome.ForeColor = System.Drawing.Color.Red;
				m_lContato.ForeColor = System.Drawing.Color.Red;
			}
		}
		#endregion

		#region Eventos
		#region Load
		private void frmFCadastroAgentes_Load(object sender, System.EventArgs e)
		{
			mostraCor();
			if (m_bCadastroNovo == false)
			{
				OnCallCarregaDadosInterface();
				this.Text = "Edição Agente";
			}
			else
			{
				this.Text = "Cadastro Agente";
			}
		}
		#endregion
		#region Cancelar
		private void m_btCancelar_Click(object sender, System.EventArgs e)
		{
			m_bModificado = false;
			this.Close();		
		}
		#endregion
		#region Ok
		private void m_btOk_Click(object sender, System.EventArgs e)
		{
			if (m_tbNome.Text.Trim() != "")
			{
				if (m_tbContato.Text.Trim() != "")
				{
					m_bModificado = true;
					OnCallSalvaDadosInterface();
					OnCallSalvaDadosBD();
					this.Close();
				}
				else
				{
					mdlMensagens.clsMensagens.ShowInformation("Siscobras", mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlAgentes_frmFCadastroAgentes_ContatoInvalido.ToString()), System.Windows.Forms.MessageBoxButtons.OK);
					m_tbContato.Focus();
				}
			}
			else
			{
				mdlMensagens.clsMensagens.ShowInformation("Siscobras", mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlAgentes_frmFCadastroAgentes_NomeInvalido.ToString()), System.Windows.Forms.MessageBoxButtons.OK);
				m_tbNome.Focus();
			}
		}
		#endregion
		#endregion
	}
}
