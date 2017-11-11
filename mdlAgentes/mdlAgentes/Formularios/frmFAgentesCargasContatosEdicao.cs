using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlAgentes.Formularios
{
	/// <summary>
	/// Summary description for frmFAgentesCargasContatosEdicao.
	/// </summary>
	public class frmFAgentesCargasContatosEdicao : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate void delCallCarregaDados(int nIdAgenteCarga,int nIdContato,out string strNome,out string strTelefone,out string strFax,out string strEmail);
			public delegate bool delCallSalvaDados(int nIdAgenteCarga,int nIdContato,string strNome,string strTelefone,string strFax,string strEmail);
		#endregion
		#region Events
			public event delCallCarregaDados eCallCarregaDados;	
			public event delCallSalvaDados eCallSalvaDados;	
		#endregion
		#region Events Methods
			protected virtual void OnCallCarregaDados()
			{
				if (eCallCarregaDados != null)
				{
					string strNome,strTelefone,strFax,strEmail;
					eCallCarregaDados(m_nIdAgenteCarga,m_nIdContato,out strNome,out strTelefone,out strFax,out strEmail);
					m_txtNome.Text = strNome;
					m_txtTelefone.Text = strTelefone;
					m_txtFax.Text = strFax;
					m_txtEmail.Text = strEmail;
				}
			}

			protected virtual bool OnCallSalvaDados()
			{
				bool bRetorno = false;
				if (eCallSalvaDados != null)
					bRetorno = eCallSalvaDados(m_nIdAgenteCarga,m_nIdContato,m_txtNome.Text,m_txtTelefone.Text,m_txtFax.Text,m_txtEmail.Text);
				return(bRetorno);
			}
		#endregion

		#region Atributes
		public bool m_bModificado = false;

		private string m_strEnderecoExecutavel = "";
		private int m_nIdAgenteCarga = -1;
		private int m_nIdContato = -1;

		private System.Windows.Forms.GroupBox m_gbGeral;
		private System.Windows.Forms.GroupBox m_gbContato;
		private mdlComponentesGraficos.TextBox m_txtNome;
		private System.Windows.Forms.Label m_lbNome;
		private System.Windows.Forms.Button m_btOk;
		private System.Windows.Forms.Button m_btCancelar;
		private mdlComponentesGraficos.TextBox m_txtTelefone;
		private System.Windows.Forms.Label m_lbTelefone;
		private mdlComponentesGraficos.TextBox m_txtFax;
		private System.Windows.Forms.Label m_lbFax;
		private mdlComponentesGraficos.TextBox m_txtEmail;
		private System.Windows.Forms.Label m_lbEmail;
		#endregion
		private System.Windows.Forms.ToolTip m_ttDicas;
		private System.ComponentModel.IContainer components;
		#region Constructors and Destructors
		public frmFAgentesCargasContatosEdicao(string strEnderecoExecutavel,int nIdAgenteCarga)
		{
			// Cadastro
			m_strEnderecoExecutavel = strEnderecoExecutavel;
			m_nIdAgenteCarga = nIdAgenteCarga;
			m_nIdContato = -1;
			InitializeComponent();
			m_gbContato.Text = "Cadastro";
		}

		public frmFAgentesCargasContatosEdicao(string strEnderecoExecutavel,int nIdAgenteCarga, int nIdContato)
		{
			// Edicao
			m_strEnderecoExecutavel = strEnderecoExecutavel;
			m_nIdAgenteCarga = nIdAgenteCarga;
			m_nIdContato = nIdContato;
			InitializeComponent();
			m_gbContato.Text = "Edição";
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFAgentesCargasContatosEdicao));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbContato = new System.Windows.Forms.GroupBox();
			this.m_txtEmail = new mdlComponentesGraficos.TextBox();
			this.m_lbEmail = new System.Windows.Forms.Label();
			this.m_txtFax = new mdlComponentesGraficos.TextBox();
			this.m_lbFax = new System.Windows.Forms.Label();
			this.m_txtTelefone = new mdlComponentesGraficos.TextBox();
			this.m_lbTelefone = new System.Windows.Forms.Label();
			this.m_txtNome = new mdlComponentesGraficos.TextBox();
			this.m_lbNome = new System.Windows.Forms.Label();
			this.m_ttDicas = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbGeral.SuspendLayout();
			this.m_gbContato.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Controls.Add(this.m_gbContato);
			this.m_gbGeral.Location = new System.Drawing.Point(5, -2);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(208, 152);
			this.m_gbGeral.TabIndex = 0;
			this.m_gbGeral.TabStop = false;
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(48, 123);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 1;
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
			this.m_btCancelar.Location = new System.Drawing.Point(112, 123);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 2;
			this.m_ttDicas.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbContato
			// 
			this.m_gbContato.Controls.Add(this.m_txtEmail);
			this.m_gbContato.Controls.Add(this.m_lbEmail);
			this.m_gbContato.Controls.Add(this.m_txtFax);
			this.m_gbContato.Controls.Add(this.m_lbFax);
			this.m_gbContato.Controls.Add(this.m_txtTelefone);
			this.m_gbContato.Controls.Add(this.m_lbTelefone);
			this.m_gbContato.Controls.Add(this.m_txtNome);
			this.m_gbContato.Controls.Add(this.m_lbNome);
			this.m_gbContato.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbContato.Location = new System.Drawing.Point(7, 6);
			this.m_gbContato.Name = "m_gbContato";
			this.m_gbContato.Size = new System.Drawing.Size(193, 114);
			this.m_gbContato.TabIndex = 0;
			this.m_gbContato.TabStop = false;
			this.m_gbContato.Text = "Contato";
			// 
			// m_txtEmail
			// 
			this.m_txtEmail.Location = new System.Drawing.Point(65, 84);
			this.m_txtEmail.Name = "m_txtEmail";
			this.m_txtEmail.Size = new System.Drawing.Size(117, 20);
			this.m_txtEmail.TabIndex = 3;
			this.m_txtEmail.Text = "";
			// 
			// m_lbEmail
			// 
			this.m_lbEmail.ForeColor = System.Drawing.Color.Black;
			this.m_lbEmail.Location = new System.Drawing.Point(8, 85);
			this.m_lbEmail.Name = "m_lbEmail";
			this.m_lbEmail.Size = new System.Drawing.Size(62, 14);
			this.m_lbEmail.TabIndex = 12;
			this.m_lbEmail.Text = "E-mail:";
			this.m_lbEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_txtFax
			// 
			this.m_txtFax.Location = new System.Drawing.Point(66, 62);
			this.m_txtFax.Name = "m_txtFax";
			this.m_txtFax.Size = new System.Drawing.Size(117, 20);
			this.m_txtFax.TabIndex = 2;
			this.m_txtFax.Text = "";
			// 
			// m_lbFax
			// 
			this.m_lbFax.ForeColor = System.Drawing.Color.Black;
			this.m_lbFax.Location = new System.Drawing.Point(7, 63);
			this.m_lbFax.Name = "m_lbFax";
			this.m_lbFax.Size = new System.Drawing.Size(62, 14);
			this.m_lbFax.TabIndex = 10;
			this.m_lbFax.Text = "Fax:";
			this.m_lbFax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_txtTelefone
			// 
			this.m_txtTelefone.Location = new System.Drawing.Point(67, 38);
			this.m_txtTelefone.Name = "m_txtTelefone";
			this.m_txtTelefone.Size = new System.Drawing.Size(117, 20);
			this.m_txtTelefone.TabIndex = 1;
			this.m_txtTelefone.Text = "";
			// 
			// m_lbTelefone
			// 
			this.m_lbTelefone.ForeColor = System.Drawing.Color.Black;
			this.m_lbTelefone.Location = new System.Drawing.Point(5, 41);
			this.m_lbTelefone.Name = "m_lbTelefone";
			this.m_lbTelefone.Size = new System.Drawing.Size(62, 14);
			this.m_lbTelefone.TabIndex = 8;
			this.m_lbTelefone.Text = "Telefone:";
			this.m_lbTelefone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_txtNome
			// 
			this.m_txtNome.Location = new System.Drawing.Point(67, 16);
			this.m_txtNome.Name = "m_txtNome";
			this.m_txtNome.Size = new System.Drawing.Size(117, 20);
			this.m_txtNome.TabIndex = 0;
			this.m_txtNome.Text = "";
			// 
			// m_lbNome
			// 
			this.m_lbNome.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.m_lbNome.Location = new System.Drawing.Point(6, 18);
			this.m_lbNome.Name = "m_lbNome";
			this.m_lbNome.Size = new System.Drawing.Size(40, 14);
			this.m_lbNome.TabIndex = 6;
			this.m_lbNome.Text = "Nome:";
			this.m_lbNome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_ttDicas
			// 
			this.m_ttDicas.AutomaticDelay = 100;
			this.m_ttDicas.AutoPopDelay = 5000;
			this.m_ttDicas.InitialDelay = 100;
			this.m_ttDicas.ReshowDelay = 20;
			// 
			// frmFAgentesCargasContatosEdicao
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(218, 152);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFAgentesCargasContatosEdicao";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Contato";
			this.Load += new System.EventHandler(this.frmFAgentesCargasContatosEdicao_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbContato.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFAgentesCargasContatosEdicao_Load(object sender, System.EventArgs e)
				{
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
