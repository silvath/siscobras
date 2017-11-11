using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlTransportadoras.Formularios
{
	/// <summary>
	/// Summary description for frmFVeiculosEdicao.
	/// </summary>
	public class frmFVeiculosEdicao : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate void delCallCarregaDados(int nIdTransportadora,int nIdVeiculo,out string strDescricao,out string strIdentificacao);
			public delegate bool delCallSalvaDados(int nIdTransportadora,int nIdVeiculo,string strDescricao,string strIdentificacao);
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
					string strDescricao,strIdentificacao;
					eCallCarregaDados(m_nIdTransportadora,m_nIdVeiculo,out strDescricao,out strIdentificacao);
					m_txtDescricao.Text = strDescricao;
					m_txtIdentificacao.Text = strIdentificacao;
				}
			}

			protected virtual bool OnCallSalvaDados()
			{
				bool bRetorno = false;
				if (eCallSalvaDados != null)
					bRetorno = eCallSalvaDados(m_nIdTransportadora,m_nIdVeiculo,m_txtDescricao.Text,m_txtIdentificacao.Text);
				return(bRetorno);
			}
		#endregion

		#region Atributes
			public bool m_bModificado = false;

			private string m_strEnderecoExecutavel = "";
			private int m_nIdTransportadora = -1;
			private int m_nIdVeiculo = -1;

			private System.Windows.Forms.GroupBox m_gbGeral;
			private System.Windows.Forms.Button m_btOk;
			private System.Windows.Forms.Button m_btCancelar;
			private mdlComponentesGraficos.TextBox m_txtIdentificacao;
			private System.Windows.Forms.Label m_lbIdentificacao;
			private mdlComponentesGraficos.TextBox m_txtDescricao;
			private System.Windows.Forms.Label m_lbDescricao;
			private mdlComponentesGraficos.ComboBox m_cbEstado;
			private System.Windows.Forms.Label label1;
			private System.Windows.Forms.GroupBox m_gbVeiculo;
			private System.Windows.Forms.ToolTip m_ttDicas;
			private System.ComponentModel.IContainer components;
		#endregion
		#region Constructors and Destructors
			public frmFVeiculosEdicao(string strEnderecoExecutavel,int nIdTransportadora)
			{
				// Cadastro
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				m_nIdTransportadora = nIdTransportadora;
				m_nIdVeiculo = -1;
				InitializeComponent();
				m_gbVeiculo.Text = "Cadastro";
			}

			public frmFVeiculosEdicao(string strEnderecoExecutavel,int nIdTransportadora,int nIdVeiculo)
			{
				// Cadastro
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				m_nIdTransportadora = nIdTransportadora;
				m_nIdVeiculo = nIdVeiculo;
				InitializeComponent();
				m_gbVeiculo.Text = "Edição;";
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFVeiculosEdicao));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbVeiculo = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.m_cbEstado = new mdlComponentesGraficos.ComboBox();
			this.m_txtIdentificacao = new mdlComponentesGraficos.TextBox();
			this.m_lbIdentificacao = new System.Windows.Forms.Label();
			this.m_txtDescricao = new mdlComponentesGraficos.TextBox();
			this.m_lbDescricao = new System.Windows.Forms.Label();
			this.m_ttDicas = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbGeral.SuspendLayout();
			this.m_gbVeiculo.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Controls.Add(this.m_gbVeiculo);
			this.m_gbGeral.Location = new System.Drawing.Point(3, -1);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(237, 100);
			this.m_gbGeral.TabIndex = 3;
			this.m_gbGeral.TabStop = false;
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(59, 69);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 7;
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
			this.m_btCancelar.Location = new System.Drawing.Point(123, 69);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 8;
			this.m_ttDicas.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbVeiculo
			// 
			this.m_gbVeiculo.Controls.Add(this.label1);
			this.m_gbVeiculo.Controls.Add(this.m_cbEstado);
			this.m_gbVeiculo.Controls.Add(this.m_txtIdentificacao);
			this.m_gbVeiculo.Controls.Add(this.m_lbIdentificacao);
			this.m_gbVeiculo.Controls.Add(this.m_txtDescricao);
			this.m_gbVeiculo.Controls.Add(this.m_lbDescricao);
			this.m_gbVeiculo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbVeiculo.Location = new System.Drawing.Point(7, 6);
			this.m_gbVeiculo.Name = "m_gbVeiculo";
			this.m_gbVeiculo.Size = new System.Drawing.Size(225, 60);
			this.m_gbVeiculo.TabIndex = 0;
			this.m_gbVeiculo.TabStop = false;
			this.m_gbVeiculo.Text = "Caminhão";
			// 
			// label1
			// 
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(5, 88);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 14);
			this.label1.TabIndex = 11;
			this.label1.Text = "Tipo:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label1.Visible = false;
			// 
			// m_cbEstado
			// 
			this.m_cbEstado.Enabled = false;
			this.m_cbEstado.Location = new System.Drawing.Point(80, 80);
			this.m_cbEstado.Name = "m_cbEstado";
			this.m_cbEstado.Size = new System.Drawing.Size(136, 22);
			this.m_cbEstado.TabIndex = 10;
			this.m_cbEstado.Text = "Caminhão";
			this.m_cbEstado.Visible = false;
			// 
			// m_txtIdentificacao
			// 
			this.m_txtIdentificacao.Location = new System.Drawing.Point(80, 34);
			this.m_txtIdentificacao.Name = "m_txtIdentificacao";
			this.m_txtIdentificacao.Size = new System.Drawing.Size(136, 20);
			this.m_txtIdentificacao.TabIndex = 9;
			this.m_txtIdentificacao.Text = "";
			// 
			// m_lbIdentificacao
			// 
			this.m_lbIdentificacao.ForeColor = System.Drawing.Color.Black;
			this.m_lbIdentificacao.Location = new System.Drawing.Point(5, 34);
			this.m_lbIdentificacao.Name = "m_lbIdentificacao";
			this.m_lbIdentificacao.Size = new System.Drawing.Size(51, 14);
			this.m_lbIdentificacao.TabIndex = 8;
			this.m_lbIdentificacao.Text = "Placa:";
			this.m_lbIdentificacao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_txtDescricao
			// 
			this.m_txtDescricao.Location = new System.Drawing.Point(80, 13);
			this.m_txtDescricao.Name = "m_txtDescricao";
			this.m_txtDescricao.Size = new System.Drawing.Size(136, 20);
			this.m_txtDescricao.TabIndex = 7;
			this.m_txtDescricao.Text = "";
			// 
			// m_lbDescricao
			// 
			this.m_lbDescricao.ForeColor = System.Drawing.Color.Black;
			this.m_lbDescricao.Location = new System.Drawing.Point(5, 17);
			this.m_lbDescricao.Name = "m_lbDescricao";
			this.m_lbDescricao.Size = new System.Drawing.Size(66, 14);
			this.m_lbDescricao.TabIndex = 6;
			this.m_lbDescricao.Text = "Descrição:";
			this.m_lbDescricao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_ttDicas
			// 
			this.m_ttDicas.AutomaticDelay = 100;
			this.m_ttDicas.AutoPopDelay = 5000;
			this.m_ttDicas.InitialDelay = 100;
			this.m_ttDicas.ReshowDelay = 20;
			// 
			// frmFVeiculosEdicao
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(242, 103);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFVeiculosEdicao";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Veiculo";
			this.Load += new System.EventHandler(this.frmFVeiculosEdicao_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbVeiculo.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFVeiculosEdicao_Load(object sender, System.EventArgs e)
				{
					vMostraCor();
					OnCallCarregaDados();
				}
			#endregion
			#region Botoes
				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					if(m_bModificado = OnCallSalvaDados())
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
