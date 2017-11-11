using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlArmadores.Formularios
{
	/// <summary>
	/// Summary description for frmFTerminaisEdicao.
	/// </summary>
	internal class frmFTerminaisEdicao : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate void delCallCarregaDadosEstadosBrasileiros(ref mdlComponentesGraficos.ComboBox cbEstadosBrasileiros);
			public delegate void delCallCarregaDados(int nIdTerminal,out string strNome,out string strEndereco,out string strCEP,out string strBairro,out string strCidade,out int nIdEstado,out string strTelefone,out string strFax,out string strEmail,out string strSite);
			public delegate bool delCallSalvaDados(int nIdTerminal,string strNome,string strEndereco,string strCEP,string strBairro,string strCidade,int nIdEstado,string strTelefone,string strFax,string strEmail,string strSite);
		#endregion
		#region Events
			public event delCallCarregaDadosEstadosBrasileiros eCallCarregaDadosEstadosBrasileiros;	
			public event delCallCarregaDados eCallCarregaDados;	
			public event delCallSalvaDados eCallSalvaDados;	
		#endregion
		#region Events Methods
			protected virtual void OnCallCarregaDadosEstadosBrasileiros()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallCarregaDadosEstadosBrasileiros != null)
				{
					eCallCarregaDadosEstadosBrasileiros(ref m_cbEstado);
				}
			}
			protected virtual void OnCallCarregaDados()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallCarregaDados != null)
				{
					string strNome,strEndereco,strCEP,strBairro,strCidade,strTelefone,strFax,strEmail,strSite;
					int nIdEstado;
					eCallCarregaDados(m_nIdTerminal,out strNome,out strEndereco,out strCEP,out strBairro,out strCidade,out nIdEstado,out strTelefone,out strFax,out strEmail,out strSite);
					m_txtNome.Text = strNome;
					m_txtEndereco.Text = strEndereco;
					m_txtCep.Text = strCEP;
					m_txtBairro.Text = strBairro;
					m_txtCidade.Text = strCidade;
					m_cbEstado.SelectItem(nIdEstado);
					m_txtTelefone.Text = strTelefone;
					m_txtFax.Text = strFax;
					m_txtEmail.Text = strEmail;
					m_txtSite.Text = strSite;
				}
			}

			protected virtual bool OnCallSalvaDados()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				bool bRetorno = false;
				if (eCallSalvaDados != null)
				{
					int nIdEstado = -1;
					if (m_cbEstado.Text != "")
						nIdEstado = -2;
					object obj = m_cbEstado.ReturnObjectSelectedItem();
					if (obj != null)
						nIdEstado = Int32.Parse(obj.ToString());
					bRetorno = eCallSalvaDados(m_nIdTerminal,m_txtNome.Text,m_txtEndereco.Text,m_txtCep.Text,m_txtBairro.Text,m_txtCidade.Text,nIdEstado,m_txtTelefone.Text,m_txtFax.Text,m_txtEmail.Text,m_txtSite.Text);
				}
				return(bRetorno);
			}
		#endregion

		#region Atributes
			public bool m_bModificado= false;

			private string m_strEnderecoExecutavel = "";
			private int m_nIdTerminal = -1;

			private System.Windows.Forms.ToolTip m_ttDicas;
			private System.ComponentModel.IContainer components;
			private System.Windows.Forms.GroupBox m_gbGeral;
			private mdlComponentesGraficos.ComboBox m_cbEstado;
			private System.Windows.Forms.Label m_lbEstado;
			private mdlComponentesGraficos.TextBox m_txtSite;
			private mdlComponentesGraficos.TextBox m_txtEmail;
			private System.Windows.Forms.Label m_lbSite;
			private System.Windows.Forms.Label m_lbEmail;
			private mdlComponentesGraficos.TextBox m_txtBairro;
			private System.Windows.Forms.Label m_lbBairro;
			private mdlComponentesGraficos.TextBox m_txtCep;
			private System.Windows.Forms.Label m_lbCep;
			private mdlComponentesGraficos.TextBox m_txtFax;
			private mdlComponentesGraficos.TextBox m_txtTelefone;
			private System.Windows.Forms.Label m_lbFax;
			private System.Windows.Forms.Label m_lbTelefone;
			private mdlComponentesGraficos.TextBox m_txtCidade;
			private mdlComponentesGraficos.TextBox m_txtEndereco;
			private mdlComponentesGraficos.TextBox m_txtNome;
			private System.Windows.Forms.Label m_lbCidade;
			private System.Windows.Forms.Label m_lbEndereco;
			private System.Windows.Forms.Label m_lbNome;
			private System.Windows.Forms.Button m_btOk;
			private System.Windows.Forms.Button m_btCancelar;
		private System.Windows.Forms.GroupBox m_gbTerminal;
		#endregion
		#region Constructors and Destructors
			public frmFTerminaisEdicao(string strEnderecoExecutavel)
			{
				// Cadastro
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				m_nIdTerminal = -1;
				InitializeComponent();
				m_gbTerminal.Text = "Cadastro";
			}

			public frmFTerminaisEdicao(string strEnderecoExecutavel,int nIdTerminal)
			{
				// Editar
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				m_nIdTerminal = nIdTerminal;
				InitializeComponent();
				m_gbTerminal.Text = "Editar";
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFTerminaisEdicao));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_gbTerminal = new System.Windows.Forms.GroupBox();
			this.m_cbEstado = new mdlComponentesGraficos.ComboBox();
			this.m_lbEstado = new System.Windows.Forms.Label();
			this.m_txtSite = new mdlComponentesGraficos.TextBox();
			this.m_txtEmail = new mdlComponentesGraficos.TextBox();
			this.m_lbSite = new System.Windows.Forms.Label();
			this.m_lbEmail = new System.Windows.Forms.Label();
			this.m_txtBairro = new mdlComponentesGraficos.TextBox();
			this.m_lbBairro = new System.Windows.Forms.Label();
			this.m_txtCep = new mdlComponentesGraficos.TextBox();
			this.m_lbCep = new System.Windows.Forms.Label();
			this.m_txtFax = new mdlComponentesGraficos.TextBox();
			this.m_txtTelefone = new mdlComponentesGraficos.TextBox();
			this.m_lbFax = new System.Windows.Forms.Label();
			this.m_lbTelefone = new System.Windows.Forms.Label();
			this.m_txtCidade = new mdlComponentesGraficos.TextBox();
			this.m_txtEndereco = new mdlComponentesGraficos.TextBox();
			this.m_txtNome = new mdlComponentesGraficos.TextBox();
			this.m_lbCidade = new System.Windows.Forms.Label();
			this.m_lbEndereco = new System.Windows.Forms.Label();
			this.m_lbNome = new System.Windows.Forms.Label();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_ttDicas = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbGeral.SuspendLayout();
			this.m_gbTerminal.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Controls.Add(this.m_gbTerminal);
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Location = new System.Drawing.Point(3, 2);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(345, 296);
			this.m_gbGeral.TabIndex = 2;
			this.m_gbGeral.TabStop = false;
			// 
			// m_gbTerminal
			// 
			this.m_gbTerminal.Controls.Add(this.m_cbEstado);
			this.m_gbTerminal.Controls.Add(this.m_lbEstado);
			this.m_gbTerminal.Controls.Add(this.m_txtSite);
			this.m_gbTerminal.Controls.Add(this.m_txtEmail);
			this.m_gbTerminal.Controls.Add(this.m_lbSite);
			this.m_gbTerminal.Controls.Add(this.m_lbEmail);
			this.m_gbTerminal.Controls.Add(this.m_txtBairro);
			this.m_gbTerminal.Controls.Add(this.m_lbBairro);
			this.m_gbTerminal.Controls.Add(this.m_txtCep);
			this.m_gbTerminal.Controls.Add(this.m_lbCep);
			this.m_gbTerminal.Controls.Add(this.m_txtFax);
			this.m_gbTerminal.Controls.Add(this.m_txtTelefone);
			this.m_gbTerminal.Controls.Add(this.m_lbFax);
			this.m_gbTerminal.Controls.Add(this.m_lbTelefone);
			this.m_gbTerminal.Controls.Add(this.m_txtCidade);
			this.m_gbTerminal.Controls.Add(this.m_txtEndereco);
			this.m_gbTerminal.Controls.Add(this.m_txtNome);
			this.m_gbTerminal.Controls.Add(this.m_lbCidade);
			this.m_gbTerminal.Controls.Add(this.m_lbEndereco);
			this.m_gbTerminal.Controls.Add(this.m_lbNome);
			this.m_gbTerminal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbTerminal.Location = new System.Drawing.Point(6, 6);
			this.m_gbTerminal.Name = "m_gbTerminal";
			this.m_gbTerminal.Size = new System.Drawing.Size(334, 258);
			this.m_gbTerminal.TabIndex = 7;
			this.m_gbTerminal.TabStop = false;
			this.m_gbTerminal.Text = "Cadastro / Edição";
			// 
			// m_cbEstado
			// 
			this.m_cbEstado.GoToNextControlWithEnter = true;
			this.m_cbEstado.Location = new System.Drawing.Point(67, 136);
			this.m_cbEstado.Name = "m_cbEstado";
			this.m_cbEstado.Size = new System.Drawing.Size(261, 22);
			this.m_cbEstado.TabIndex = 5;
			// 
			// m_lbEstado
			// 
			this.m_lbEstado.Location = new System.Drawing.Point(10, 137);
			this.m_lbEstado.Name = "m_lbEstado";
			this.m_lbEstado.Size = new System.Drawing.Size(48, 16);
			this.m_lbEstado.TabIndex = 22;
			this.m_lbEstado.Text = "Estado:";
			this.m_lbEstado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_txtSite
			// 
			this.m_txtSite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_txtSite.Location = new System.Drawing.Point(67, 184);
			this.m_txtSite.Name = "m_txtSite";
			this.m_txtSite.Size = new System.Drawing.Size(259, 20);
			this.m_txtSite.TabIndex = 7;
			this.m_txtSite.Text = "";
			// 
			// m_txtEmail
			// 
			this.m_txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_txtEmail.Location = new System.Drawing.Point(67, 160);
			this.m_txtEmail.Name = "m_txtEmail";
			this.m_txtEmail.Size = new System.Drawing.Size(259, 20);
			this.m_txtEmail.TabIndex = 6;
			this.m_txtEmail.Text = "";
			// 
			// m_lbSite
			// 
			this.m_lbSite.Location = new System.Drawing.Point(9, 184);
			this.m_lbSite.Name = "m_lbSite";
			this.m_lbSite.Size = new System.Drawing.Size(32, 16);
			this.m_lbSite.TabIndex = 19;
			this.m_lbSite.Text = "Site:";
			this.m_lbSite.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_lbEmail
			// 
			this.m_lbEmail.Location = new System.Drawing.Point(9, 160);
			this.m_lbEmail.Name = "m_lbEmail";
			this.m_lbEmail.Size = new System.Drawing.Size(48, 16);
			this.m_lbEmail.TabIndex = 18;
			this.m_lbEmail.Text = "E-mail:";
			this.m_lbEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_txtBairro
			// 
			this.m_txtBairro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_txtBairro.Location = new System.Drawing.Point(67, 87);
			this.m_txtBairro.Name = "m_txtBairro";
			this.m_txtBairro.Size = new System.Drawing.Size(259, 20);
			this.m_txtBairro.TabIndex = 3;
			this.m_txtBairro.Text = "";
			// 
			// m_lbBairro
			// 
			this.m_lbBairro.Location = new System.Drawing.Point(9, 87);
			this.m_lbBairro.Name = "m_lbBairro";
			this.m_lbBairro.Size = new System.Drawing.Size(48, 16);
			this.m_lbBairro.TabIndex = 16;
			this.m_lbBairro.Text = "Bairro:";
			this.m_lbBairro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_txtCep
			// 
			this.m_txtCep.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_txtCep.Location = new System.Drawing.Point(67, 63);
			this.m_txtCep.Mask = true;
			this.m_txtCep.MaskText = "NNNNN-NNN";
			this.m_txtCep.Name = "m_txtCep";
			this.m_txtCep.Size = new System.Drawing.Size(259, 20);
			this.m_txtCep.TabIndex = 2;
			this.m_txtCep.Text = "";
			// 
			// m_lbCep
			// 
			this.m_lbCep.Location = new System.Drawing.Point(9, 63);
			this.m_lbCep.Name = "m_lbCep";
			this.m_lbCep.Size = new System.Drawing.Size(48, 16);
			this.m_lbCep.TabIndex = 14;
			this.m_lbCep.Text = "CEP:";
			this.m_lbCep.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_txtFax
			// 
			this.m_txtFax.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_txtFax.Location = new System.Drawing.Point(67, 232);
			this.m_txtFax.Name = "m_txtFax";
			this.m_txtFax.Size = new System.Drawing.Size(259, 20);
			this.m_txtFax.TabIndex = 9;
			this.m_txtFax.Text = "";
			// 
			// m_txtTelefone
			// 
			this.m_txtTelefone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_txtTelefone.Location = new System.Drawing.Point(67, 208);
			this.m_txtTelefone.Name = "m_txtTelefone";
			this.m_txtTelefone.Size = new System.Drawing.Size(259, 20);
			this.m_txtTelefone.TabIndex = 8;
			this.m_txtTelefone.Text = "";
			// 
			// m_lbFax
			// 
			this.m_lbFax.Location = new System.Drawing.Point(9, 232);
			this.m_lbFax.Name = "m_lbFax";
			this.m_lbFax.Size = new System.Drawing.Size(32, 16);
			this.m_lbFax.TabIndex = 11;
			this.m_lbFax.Text = "Fax:";
			this.m_lbFax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_lbTelefone
			// 
			this.m_lbTelefone.Location = new System.Drawing.Point(9, 208);
			this.m_lbTelefone.Name = "m_lbTelefone";
			this.m_lbTelefone.Size = new System.Drawing.Size(56, 16);
			this.m_lbTelefone.TabIndex = 10;
			this.m_lbTelefone.Text = "Telefone:";
			this.m_lbTelefone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_txtCidade
			// 
			this.m_txtCidade.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_txtCidade.Location = new System.Drawing.Point(67, 112);
			this.m_txtCidade.Name = "m_txtCidade";
			this.m_txtCidade.Size = new System.Drawing.Size(259, 20);
			this.m_txtCidade.TabIndex = 4;
			this.m_txtCidade.Text = "";
			// 
			// m_txtEndereco
			// 
			this.m_txtEndereco.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_txtEndereco.Location = new System.Drawing.Point(67, 41);
			this.m_txtEndereco.Name = "m_txtEndereco";
			this.m_txtEndereco.Size = new System.Drawing.Size(259, 20);
			this.m_txtEndereco.TabIndex = 1;
			this.m_txtEndereco.Text = "";
			// 
			// m_txtNome
			// 
			this.m_txtNome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_txtNome.Location = new System.Drawing.Point(67, 17);
			this.m_txtNome.Name = "m_txtNome";
			this.m_txtNome.Size = new System.Drawing.Size(259, 20);
			this.m_txtNome.TabIndex = 0;
			this.m_txtNome.Text = "";
			// 
			// m_lbCidade
			// 
			this.m_lbCidade.Location = new System.Drawing.Point(9, 112);
			this.m_lbCidade.Name = "m_lbCidade";
			this.m_lbCidade.Size = new System.Drawing.Size(48, 16);
			this.m_lbCidade.TabIndex = 2;
			this.m_lbCidade.Text = "Cidade:";
			this.m_lbCidade.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_lbEndereco
			// 
			this.m_lbEndereco.Location = new System.Drawing.Point(9, 43);
			this.m_lbEndereco.Name = "m_lbEndereco";
			this.m_lbEndereco.Size = new System.Drawing.Size(64, 16);
			this.m_lbEndereco.TabIndex = 1;
			this.m_lbEndereco.Text = "Endereço:";
			this.m_lbEndereco.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_lbNome
			// 
			this.m_lbNome.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.m_lbNome.Location = new System.Drawing.Point(9, 21);
			this.m_lbNome.Name = "m_lbNome";
			this.m_lbNome.Size = new System.Drawing.Size(40, 14);
			this.m_lbNome.TabIndex = 0;
			this.m_lbNome.Text = "Nome:";
			this.m_lbNome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(112, 266);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 0;
			this.m_ttDicas.SetToolTip(this.m_btOk, "Confirmar");
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(176, 266);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 1;
			this.m_ttDicas.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_ttDicas
			// 
			this.m_ttDicas.AutomaticDelay = 100;
			this.m_ttDicas.AutoPopDelay = 5000;
			this.m_ttDicas.InitialDelay = 100;
			this.m_ttDicas.ReshowDelay = 20;
			// 
			// frmFTerminaisEdicao
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(352, 302);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFTerminaisEdicao";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Terminal";
			this.Load += new System.EventHandler(this.frmFTerminaisEdicao_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbTerminal.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFTerminaisEdicao_Load(object sender, System.EventArgs e)
				{
					OnCallCarregaDadosEstadosBrasileiros();
					vMostraCor();
					OnCallCarregaDados();
				}
			#endregion
			#region Botoes
				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					if (m_bModificado = OnCallSalvaDados())
						this.Close();
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
				mdlPaletaDeCores.clsPaletaDeCores clsPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini","SiscobrasCorSecundaria");
				this.BackColor = clsPaletaCores.retornaCorAtual();
				System.Windows.Forms.Control ctrControleChild;
				for (int nCont = 0 ;nCont < this.Controls.Count; nCont++)
				{
					ctrControleChild = this.Controls[nCont];
					vPaintControl(ref ctrControleChild,this.BackColor);
				}
			}

			private void vPaintControl(ref System.Windows.Forms.Control ctrControle,System.Drawing.Color clrBackColor)
			{
				switch(ctrControle.GetType().ToString())
				{
					case "mdlComponentesGraficos.ListView":
					case "System.Windows.Forms.ListView":
					case "mdlComponentesGraficos.ComboBox":
					case "mdlComponentesGraficos.TextBox":
						break;

					default:
						ctrControle.BackColor = clrBackColor;
						break;
				}
				System.Windows.Forms.Control ctrControleChild;
				for (int nCont = 0 ;nCont < ctrControle.Controls.Count; nCont++)
				{
					ctrControleChild = ctrControle.Controls[nCont];
					vPaintControl(ref ctrControleChild,clrBackColor);
				}
			}
		#endregion

	}
}
