using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlArmadores.Formularios
{
	/// <summary>
	/// Summary description for frmFNaviosEdicao.
	/// </summary>
	internal class frmFNaviosEdicao : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate void delCallCarregaDados(int nIdArmador,int nIdNavio,out string strNome);
			public delegate bool delCallSalvaDados(int nIdArmador,int nIdNavio,string strNome);
		#endregion
		#region Events
			public event delCallCarregaDados eCallCarregaDados;	
			public event delCallSalvaDados eCallSalvaDados;	
		#endregion
		#region Events Methods
			protected virtual void OnCallCarregaDados()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallCarregaDados != null)
				{
					string strNome;
					eCallCarregaDados(m_nIdArmador,m_nIdNavio,out strNome);
					m_txtNome.Text = strNome;
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			protected virtual bool OnCallSalvaDados()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				bool bRetorno = false;
				if (eCallSalvaDados != null)
					bRetorno = eCallSalvaDados(m_nIdArmador,m_nIdNavio,m_txtNome.Text);
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bRetorno);
			}
		#endregion

		#region Atributes
			private string m_strEnderecoExecutavel = "";
			public bool m_bModificado = false;

			private System.Windows.Forms.ToolTip m_ttDicas;
			private System.ComponentModel.IContainer components;
			private int m_nIdArmador = -1;
			private int m_nIdNavio = -1;
			private System.Windows.Forms.GroupBox m_gbGeral;
			private System.Windows.Forms.Button m_btOk;
			private System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.GroupBox m_gbNavio;
			private mdlComponentesGraficos.TextBox m_txtNome;
			private System.Windows.Forms.Label m_lbNome;
		#endregion
		#region Constructors and Destructors
			public frmFNaviosEdicao(string strEnderecoExecutavel,int nIdArmador)
			{
				// Edicao
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				m_nIdArmador = nIdArmador;
				m_nIdNavio = -1;
				InitializeComponent();
				m_gbNavio.Text = "Cadastro";
			}

			public frmFNaviosEdicao(string strEnderecoExecutavel,int nIdArmador,int nIdNavio)
			{
				// Edicao
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				m_nIdArmador = nIdArmador;
				m_nIdNavio = nIdNavio;
				InitializeComponent();
				m_gbNavio.Text = "Edição";
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFNaviosEdicao));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbNavio = new System.Windows.Forms.GroupBox();
			this.m_txtNome = new mdlComponentesGraficos.TextBox();
			this.m_lbNome = new System.Windows.Forms.Label();
			this.m_ttDicas = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbGeral.SuspendLayout();
			this.m_gbNavio.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Controls.Add(this.m_gbNavio);
			this.m_gbGeral.Location = new System.Drawing.Point(3, 0);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(208, 81);
			this.m_gbGeral.TabIndex = 2;
			this.m_gbGeral.TabStop = false;
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(48, 50);
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
			this.m_btCancelar.Location = new System.Drawing.Point(112, 50);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 1;
			this.m_ttDicas.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbNavio
			// 
			this.m_gbNavio.Controls.Add(this.m_txtNome);
			this.m_gbNavio.Controls.Add(this.m_lbNome);
			this.m_gbNavio.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbNavio.Location = new System.Drawing.Point(7, 6);
			this.m_gbNavio.Name = "m_gbNavio";
			this.m_gbNavio.Size = new System.Drawing.Size(193, 42);
			this.m_gbNavio.TabIndex = 0;
			this.m_gbNavio.TabStop = false;
			this.m_gbNavio.Text = "Navio";
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
			// frmFNaviosEdicao
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(216, 86);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFNaviosEdicao";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Navio";
			this.Load += new System.EventHandler(this.frmFNaviosEdicao_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbNavio.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFNaviosEdicao_Load(object sender, System.EventArgs e)
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
