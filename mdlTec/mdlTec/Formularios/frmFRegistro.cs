using System;
//using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlTec.Formularios
{
	/// <summary>
	/// Summary description for frmFRegistro.
	/// </summary>
	public class frmFRegistro : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate void delCallCarregaDados(out bool bPessoaFisica,out bool bPessoaJuridica,out string strCPF,out string strCNPJ,out string strEmrpesa,out string strSite,out string strNome,out string strEmail,out string strTelefone);
			public delegate bool delCallSalvaDados(bool bPessoaFisica,bool bPessoaJuridica,string strCPF,string strCNPJ,string strEmpresa,string strSite,string strNome,string strEmail,string strTelefone);
		#endregion
		#region Events 
			public event delCallCarregaDados eCallCarregaDados;
			public event delCallSalvaDados eCallSalvaDados;
		#endregion
		#region Events Methods
			protected void OnCallCarregaDados()
			{
				if (eCallCarregaDados != null)
				{
					bool bPessoaFisica,bPessoaJuridica;
					string strCPF,strCNPJ,strEmpresa,strSite,strNome,strEmail,strTelefone;
					eCallCarregaDados(out bPessoaFisica,out bPessoaJuridica,out strCPF,out strCNPJ,out strEmpresa,out strSite,out strNome,out strEmail,out strTelefone);
					m_rdbtPessoaFisica.Checked = bPessoaFisica;
					m_rdbtPessoaJuridica.Checked = bPessoaJuridica;
					m_txtCPF.Text = strCPF;
					m_txtCNPJ.Text = strCNPJ;
					m_txtEmpresa.Text = strEmpresa;
					m_txtSite.Text  = strSite;
					m_txtNome.Text = strNome;
					m_txtEmail.Text = strEmail;
					m_txtTelefone.Text = strTelefone;
				}
			}

			protected bool OnCallSalvaDados()
			{
				if (eCallSalvaDados == null)
					return(false);
				return(eCallSalvaDados(m_rdbtPessoaFisica.Checked,m_rdbtPessoaJuridica.Checked,m_txtCPF.Text,m_txtCNPJ.Text,m_txtEmpresa.Text.Trim(),m_txtSite.Text.Trim(),m_txtNome.Text.Trim(),m_txtEmail.Text.Trim(),m_txtTelefone.Text.Trim()));
			}
		#endregion

		#region Atributes
			private bool m_bSalva = false;

			private System.Windows.Forms.GroupBox m_gbMain;
			private System.Windows.Forms.GroupBox m_gbBanner;
			private System.Windows.Forms.PictureBox m_pic;
			internal System.Windows.Forms.Button m_btOk;
			internal System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.Label m_lbInformacoes;
			private System.Windows.Forms.RadioButton m_rdbtPessoaFisica;
			private System.Windows.Forms.RadioButton m_rdbtPessoaJuridica;
			private mdlComponentesGraficos.TextBox m_txtCPF;
			private System.Windows.Forms.Label label5;
			private mdlComponentesGraficos.TextBox m_txtTelefone;
			private System.Windows.Forms.Label m_lbTelefone;
			private mdlComponentesGraficos.TextBox m_txtEmail;
			private System.Windows.Forms.Label m_lbEmail;
			private mdlComponentesGraficos.TextBox m_txtNome;
			private System.Windows.Forms.Label m_lbNome;
			private mdlComponentesGraficos.TextBox m_txtSite;
			private System.Windows.Forms.Label m_lbSite;
			private mdlComponentesGraficos.TextBox m_txtEmpresa;
			private System.Windows.Forms.Label m_lbEmpresa;
			private mdlComponentesGraficos.TextBox m_txtCNPJ;
			private System.Windows.Forms.Label m_lbCNJ;
			private System.Windows.Forms.Label m_lbCPF;
		private System.Windows.Forms.Label label1;
			private System.ComponentModel.Container components = null;
		#endregion
		#region Properties
			public bool RegistroRealizado
			{
				get
				{
					return(m_bSalva);
				}
			}
		#endregion
		#region Constructors
			public frmFRegistro(System.Drawing.Image banner,System.Drawing.Color clrBackColor)
			{
				InitializeComponent();
				this.m_pic.Image = banner;
				vMostraCor(clrBackColor);
				RefreshInterface();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFRegistro));
			this.m_gbMain = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.m_txtTelefone = new mdlComponentesGraficos.TextBox();
			this.m_lbTelefone = new System.Windows.Forms.Label();
			this.m_txtEmail = new mdlComponentesGraficos.TextBox();
			this.m_lbEmail = new System.Windows.Forms.Label();
			this.m_txtNome = new mdlComponentesGraficos.TextBox();
			this.m_lbNome = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.m_txtSite = new mdlComponentesGraficos.TextBox();
			this.m_lbSite = new System.Windows.Forms.Label();
			this.m_txtEmpresa = new mdlComponentesGraficos.TextBox();
			this.m_lbEmpresa = new System.Windows.Forms.Label();
			this.m_txtCNPJ = new mdlComponentesGraficos.TextBox();
			this.m_lbCNJ = new System.Windows.Forms.Label();
			this.m_txtCPF = new mdlComponentesGraficos.TextBox();
			this.m_lbCPF = new System.Windows.Forms.Label();
			this.m_rdbtPessoaJuridica = new System.Windows.Forms.RadioButton();
			this.m_rdbtPessoaFisica = new System.Windows.Forms.RadioButton();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbBanner = new System.Windows.Forms.GroupBox();
			this.m_pic = new System.Windows.Forms.PictureBox();
			this.m_lbInformacoes = new System.Windows.Forms.Label();
			this.m_gbMain.SuspendLayout();
			this.m_gbBanner.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbMain
			// 
			this.m_gbMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbMain.Controls.Add(this.label1);
			this.m_gbMain.Controls.Add(this.m_txtTelefone);
			this.m_gbMain.Controls.Add(this.m_lbTelefone);
			this.m_gbMain.Controls.Add(this.m_txtEmail);
			this.m_gbMain.Controls.Add(this.m_lbEmail);
			this.m_gbMain.Controls.Add(this.m_txtNome);
			this.m_gbMain.Controls.Add(this.m_lbNome);
			this.m_gbMain.Controls.Add(this.label5);
			this.m_gbMain.Controls.Add(this.m_txtSite);
			this.m_gbMain.Controls.Add(this.m_lbSite);
			this.m_gbMain.Controls.Add(this.m_txtEmpresa);
			this.m_gbMain.Controls.Add(this.m_lbEmpresa);
			this.m_gbMain.Controls.Add(this.m_txtCNPJ);
			this.m_gbMain.Controls.Add(this.m_lbCNJ);
			this.m_gbMain.Controls.Add(this.m_txtCPF);
			this.m_gbMain.Controls.Add(this.m_lbCPF);
			this.m_gbMain.Controls.Add(this.m_rdbtPessoaJuridica);
			this.m_gbMain.Controls.Add(this.m_rdbtPessoaFisica);
			this.m_gbMain.Controls.Add(this.m_btOk);
			this.m_gbMain.Controls.Add(this.m_btCancelar);
			this.m_gbMain.Controls.Add(this.m_gbBanner);
			this.m_gbMain.Controls.Add(this.m_lbInformacoes);
			this.m_gbMain.Location = new System.Drawing.Point(5, 2);
			this.m_gbMain.Name = "m_gbMain";
			this.m_gbMain.Size = new System.Drawing.Size(424, 520);
			this.m_gbMain.TabIndex = 0;
			this.m_gbMain.TabStop = false;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.label1.Location = new System.Drawing.Point(160, 344);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(224, 48);
			this.label1.TabIndex = 28;
			this.label1.Text = "Informe seus dados corretamente. Dados incorretos sujeitam ao cancelamento do reg" +
				"istro.";
			// 
			// m_txtTelefone
			// 
			this.m_txtTelefone.Location = new System.Drawing.Point(224, 311);
			this.m_txtTelefone.Name = "m_txtTelefone";
			this.m_txtTelefone.Size = new System.Drawing.Size(184, 20);
			this.m_txtTelefone.TabIndex = 27;
			this.m_txtTelefone.Text = "";
			// 
			// m_lbTelefone
			// 
			this.m_lbTelefone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbTelefone.Location = new System.Drawing.Point(128, 308);
			this.m_lbTelefone.Name = "m_lbTelefone";
			this.m_lbTelefone.Size = new System.Drawing.Size(80, 16);
			this.m_lbTelefone.TabIndex = 26;
			this.m_lbTelefone.Text = "Telefone:";
			// 
			// m_txtEmail
			// 
			this.m_txtEmail.Location = new System.Drawing.Point(224, 284);
			this.m_txtEmail.Name = "m_txtEmail";
			this.m_txtEmail.Size = new System.Drawing.Size(184, 20);
			this.m_txtEmail.TabIndex = 25;
			this.m_txtEmail.Text = "";
			// 
			// m_lbEmail
			// 
			this.m_lbEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbEmail.Location = new System.Drawing.Point(128, 282);
			this.m_lbEmail.Name = "m_lbEmail";
			this.m_lbEmail.Size = new System.Drawing.Size(80, 16);
			this.m_lbEmail.TabIndex = 24;
			this.m_lbEmail.Text = "E-mail:";
			// 
			// m_txtNome
			// 
			this.m_txtNome.Location = new System.Drawing.Point(224, 257);
			this.m_txtNome.Name = "m_txtNome";
			this.m_txtNome.Size = new System.Drawing.Size(184, 20);
			this.m_txtNome.TabIndex = 23;
			this.m_txtNome.Text = "";
			// 
			// m_lbNome
			// 
			this.m_lbNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbNome.Location = new System.Drawing.Point(128, 256);
			this.m_lbNome.Name = "m_lbNome";
			this.m_lbNome.Size = new System.Drawing.Size(80, 16);
			this.m_lbNome.TabIndex = 22;
			this.m_lbNome.Text = "Nome:";
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.ForeColor = System.Drawing.Color.Red;
			this.label5.Location = new System.Drawing.Point(160, 416);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(224, 48);
			this.label5.TabIndex = 21;
			this.label5.Text = "Aviso: O TecSiscobras está sendo distribuido gratuitamente por tempo indeterminad" +
				"o";
			// 
			// m_txtSite
			// 
			this.m_txtSite.Location = new System.Drawing.Point(224, 230);
			this.m_txtSite.Name = "m_txtSite";
			this.m_txtSite.Size = new System.Drawing.Size(184, 20);
			this.m_txtSite.TabIndex = 20;
			this.m_txtSite.Text = "";
			// 
			// m_lbSite
			// 
			this.m_lbSite.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbSite.Location = new System.Drawing.Point(128, 230);
			this.m_lbSite.Name = "m_lbSite";
			this.m_lbSite.Size = new System.Drawing.Size(80, 16);
			this.m_lbSite.TabIndex = 19;
			this.m_lbSite.Text = "Site:";
			// 
			// m_txtEmpresa
			// 
			this.m_txtEmpresa.Location = new System.Drawing.Point(224, 203);
			this.m_txtEmpresa.Name = "m_txtEmpresa";
			this.m_txtEmpresa.Size = new System.Drawing.Size(184, 20);
			this.m_txtEmpresa.TabIndex = 18;
			this.m_txtEmpresa.Text = "";
			// 
			// m_lbEmpresa
			// 
			this.m_lbEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbEmpresa.Location = new System.Drawing.Point(128, 204);
			this.m_lbEmpresa.Name = "m_lbEmpresa";
			this.m_lbEmpresa.Size = new System.Drawing.Size(80, 16);
			this.m_lbEmpresa.TabIndex = 17;
			this.m_lbEmpresa.Text = "Empresa:";
			// 
			// m_txtCNPJ
			// 
			this.m_txtCNPJ.Location = new System.Drawing.Point(224, 176);
			this.m_txtCNPJ.Mask = true;
			this.m_txtCNPJ.MaskAutomaticSpecialCharacters = true;
			this.m_txtCNPJ.MaskText = "NN.NNN.NNN/NNNN-NN";
			this.m_txtCNPJ.Name = "m_txtCNPJ";
			this.m_txtCNPJ.Size = new System.Drawing.Size(184, 20);
			this.m_txtCNPJ.TabIndex = 16;
			this.m_txtCNPJ.Text = "";
			// 
			// m_lbCNJ
			// 
			this.m_lbCNJ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbCNJ.Location = new System.Drawing.Point(128, 178);
			this.m_lbCNJ.Name = "m_lbCNJ";
			this.m_lbCNJ.Size = new System.Drawing.Size(80, 16);
			this.m_lbCNJ.TabIndex = 15;
			this.m_lbCNJ.Text = "CNPJ:";
			// 
			// m_txtCPF
			// 
			this.m_txtCPF.Location = new System.Drawing.Point(224, 149);
			this.m_txtCPF.Mask = true;
			this.m_txtCPF.MaskAutomaticSpecialCharacters = true;
			this.m_txtCPF.MaskText = "NNN.NNN.NNN-NN";
			this.m_txtCPF.Name = "m_txtCPF";
			this.m_txtCPF.Size = new System.Drawing.Size(184, 20);
			this.m_txtCPF.TabIndex = 14;
			this.m_txtCPF.Text = "";
			// 
			// m_lbCPF
			// 
			this.m_lbCPF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbCPF.Location = new System.Drawing.Point(128, 152);
			this.m_lbCPF.Name = "m_lbCPF";
			this.m_lbCPF.Size = new System.Drawing.Size(80, 16);
			this.m_lbCPF.TabIndex = 13;
			this.m_lbCPF.Text = "CPF:";
			// 
			// m_rdbtPessoaJuridica
			// 
			this.m_rdbtPessoaJuridica.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_rdbtPessoaJuridica.Location = new System.Drawing.Point(128, 105);
			this.m_rdbtPessoaJuridica.Name = "m_rdbtPessoaJuridica";
			this.m_rdbtPessoaJuridica.Size = new System.Drawing.Size(208, 24);
			this.m_rdbtPessoaJuridica.TabIndex = 12;
			this.m_rdbtPessoaJuridica.Text = "Pessoa Jurídica";
			this.m_rdbtPessoaJuridica.CheckedChanged += new System.EventHandler(this.m_rdbtPessoaJuridica_CheckedChanged);
			// 
			// m_rdbtPessoaFisica
			// 
			this.m_rdbtPessoaFisica.Checked = true;
			this.m_rdbtPessoaFisica.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_rdbtPessoaFisica.Location = new System.Drawing.Point(128, 88);
			this.m_rdbtPessoaFisica.Name = "m_rdbtPessoaFisica";
			this.m_rdbtPessoaFisica.Size = new System.Drawing.Size(208, 24);
			this.m_rdbtPessoaFisica.TabIndex = 11;
			this.m_rdbtPessoaFisica.TabStop = true;
			this.m_rdbtPessoaFisica.Text = "Pessoa Física";
			this.m_rdbtPessoaFisica.CheckedChanged += new System.EventHandler(this.m_rdbtPessoaFisica_CheckedChanged);
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(149, 488);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 8;
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(213, 488);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 9;
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbBanner
			// 
			this.m_gbBanner.Controls.Add(this.m_pic);
			this.m_gbBanner.Location = new System.Drawing.Point(7, 8);
			this.m_gbBanner.Name = "m_gbBanner";
			this.m_gbBanner.Size = new System.Drawing.Size(108, 504);
			this.m_gbBanner.TabIndex = 7;
			this.m_gbBanner.TabStop = false;
			// 
			// m_pic
			// 
			this.m_pic.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_pic.Image = ((System.Drawing.Image)(resources.GetObject("m_pic.Image")));
			this.m_pic.Location = new System.Drawing.Point(6, 12);
			this.m_pic.Name = "m_pic";
			this.m_pic.Size = new System.Drawing.Size(95, 480);
			this.m_pic.TabIndex = 0;
			this.m_pic.TabStop = false;
			this.m_pic.Click += new System.EventHandler(this.m_pic_Click);
			// 
			// m_lbInformacoes
			// 
			this.m_lbInformacoes.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbInformacoes.Location = new System.Drawing.Point(144, 24);
			this.m_lbInformacoes.Name = "m_lbInformacoes";
			this.m_lbInformacoes.Size = new System.Drawing.Size(215, 34);
			this.m_lbInformacoes.TabIndex = 10;
			this.m_lbInformacoes.Text = "Informe seus dados";
			// 
			// frmFRegistro
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(434, 528);
			this.Controls.Add(this.m_gbMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFRegistro";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "TecSiscobras";
			this.Load += new System.EventHandler(this.frmFRegistro_Load);
			this.m_gbMain.ResumeLayout(false);
			this.m_gbBanner.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Form
				private void frmFRegistro_Load(object sender, System.EventArgs e)
				{
					OnCallCarregaDados();
				}
			#endregion
			#region RaddioButtons
				private void m_rdbtPessoaFisica_CheckedChanged(object sender, System.EventArgs e)
				{
					RefreshInterface();
				}

				private void m_rdbtPessoaJuridica_CheckedChanged(object sender, System.EventArgs e)
				{
					RefreshInterface();
				}
			#endregion
			#region PictureBox
				private void m_pic_Click(object sender, System.EventArgs e)
				{
					clsTec.ExecuteLink("http://www.siscobras.com.br");
				}
			#endregion
			#region Botoes
				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					if (m_bSalva = this.OnCallSalvaDados())
						this.Close();
				}

				private void m_btCancelar_Click(object sender, System.EventArgs e)
				{
					this.Close();
				}
			#endregion
		#endregion 

		#region Cores
			private void vMostraCor(System.Drawing.Color clrBackColor)
			{
				this.BackColor = clrBackColor;
				System.Windows.Forms.Control ctrControleChild;
				for (int nCont = 0 ;nCont < this.Controls.Count; nCont++)
				{
					ctrControleChild = this.Controls[nCont];
					vPaintControl(ref ctrControleChild,this.BackColor);
				}
			}

			private void vMostraCor(string strEnderecoExecutavel)
			{
				mdlPaletaDeCores.clsPaletaDeCores clsPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(strEnderecoExecutavel + mdlConstantes.clsConstantes.DEFAULT_CONFIG_FILENAME,"SiscobrasCorSecundaria");
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
					case "System.Windows.Forms.TextBox":
					case "System.Windows.Forms.TreeView":
					case "mdlComponentesGraficos.ComboBox":
					case "mdlComponentesGraficos.TextBox":
					case "mdlComponentesGraficos.TreeView":
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

		#region Refresh
			private void RefreshInterface()
			{
				m_txtCPF.Enabled = m_rdbtPessoaFisica.Checked;
				m_txtCNPJ.Enabled = m_rdbtPessoaJuridica.Checked;
				m_txtEmpresa.Enabled = m_rdbtPessoaJuridica.Checked;
				m_txtSite.Enabled = m_rdbtPessoaJuridica.Checked;
				m_txtTelefone.Enabled = m_rdbtPessoaJuridica.Checked;
			}
		#endregion

	}
}
