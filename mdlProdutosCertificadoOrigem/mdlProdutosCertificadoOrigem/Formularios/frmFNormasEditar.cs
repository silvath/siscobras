using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlProdutosCertificadoOrigem.Formularios
{
	internal class frmFNormasEditar : System.Windows.Forms.Form
	{
		#region Atributes
			private string m_strEnderecoExecutavel = "";
			public bool m_bModificado = false;

			private string m_strNormaOriginal = "";
			private string m_strNormaDetalhes = "";
			private string m_strNormaPersonalizada = "";

			private System.Windows.Forms.GroupBox m_gbGeral;
			private System.Windows.Forms.Button m_btOk;
			private System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.GroupBox m_gbOriginal;
			private System.Windows.Forms.TextBox m_txtOriginal;
			private System.Windows.Forms.GroupBox m_gbDetalhes;
			private System.Windows.Forms.TextBox m_txtDetalhes;
			private System.Windows.Forms.GroupBox m_gbPersonalizacao;
			private System.Windows.Forms.TextBox m_txtPersonalizada;
			private System.ComponentModel.Container components = null;
		#endregion
		#region Constructors and Destructors
			public frmFNormasEditar(string strEnderecoExecutavel,string strNormaOriginal,string strNormaDetalhes,string strNormaPersonalizada)
			{
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				InitializeComponent();
				m_strNormaOriginal = strNormaOriginal;
				m_strNormaDetalhes = strNormaDetalhes;
				m_strNormaPersonalizada = strNormaPersonalizada;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFNormasEditar));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_gbPersonalizacao = new System.Windows.Forms.GroupBox();
			this.m_txtPersonalizada = new System.Windows.Forms.TextBox();
			this.m_gbDetalhes = new System.Windows.Forms.GroupBox();
			this.m_txtDetalhes = new System.Windows.Forms.TextBox();
			this.m_gbOriginal = new System.Windows.Forms.GroupBox();
			this.m_txtOriginal = new System.Windows.Forms.TextBox();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbGeral.SuspendLayout();
			this.m_gbPersonalizacao.SuspendLayout();
			this.m_gbDetalhes.SuspendLayout();
			this.m_gbOriginal.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Controls.Add(this.m_gbPersonalizacao);
			this.m_gbGeral.Controls.Add(this.m_gbDetalhes);
			this.m_gbGeral.Controls.Add(this.m_gbOriginal);
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Location = new System.Drawing.Point(4, -1);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(486, 441);
			this.m_gbGeral.TabIndex = 0;
			this.m_gbGeral.TabStop = false;
			// 
			// m_gbPersonalizacao
			// 
			this.m_gbPersonalizacao.Controls.Add(this.m_txtPersonalizada);
			this.m_gbPersonalizacao.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbPersonalizacao.Location = new System.Drawing.Point(5, 280);
			this.m_gbPersonalizacao.Name = "m_gbPersonalizacao";
			this.m_gbPersonalizacao.Size = new System.Drawing.Size(475, 127);
			this.m_gbPersonalizacao.TabIndex = 16;
			this.m_gbPersonalizacao.TabStop = false;
			this.m_gbPersonalizacao.Text = "Norma Personalizada";
			// 
			// m_txtPersonalizada
			// 
			this.m_txtPersonalizada.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_txtPersonalizada.Location = new System.Drawing.Point(8, 16);
			this.m_txtPersonalizada.Multiline = true;
			this.m_txtPersonalizada.Name = "m_txtPersonalizada";
			this.m_txtPersonalizada.Size = new System.Drawing.Size(460, 103);
			this.m_txtPersonalizada.TabIndex = 0;
			this.m_txtPersonalizada.Text = "";
			// 
			// m_gbDetalhes
			// 
			this.m_gbDetalhes.Controls.Add(this.m_txtDetalhes);
			this.m_gbDetalhes.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbDetalhes.Location = new System.Drawing.Point(5, 128);
			this.m_gbDetalhes.Name = "m_gbDetalhes";
			this.m_gbDetalhes.Size = new System.Drawing.Size(475, 152);
			this.m_gbDetalhes.TabIndex = 15;
			this.m_gbDetalhes.TabStop = false;
			this.m_gbDetalhes.Text = "Detalhes";
			// 
			// m_txtDetalhes
			// 
			this.m_txtDetalhes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_txtDetalhes.Location = new System.Drawing.Point(8, 16);
			this.m_txtDetalhes.Multiline = true;
			this.m_txtDetalhes.Name = "m_txtDetalhes";
			this.m_txtDetalhes.ReadOnly = true;
			this.m_txtDetalhes.Size = new System.Drawing.Size(458, 128);
			this.m_txtDetalhes.TabIndex = 0;
			this.m_txtDetalhes.Text = "";
			// 
			// m_gbOriginal
			// 
			this.m_gbOriginal.Controls.Add(this.m_txtOriginal);
			this.m_gbOriginal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbOriginal.Location = new System.Drawing.Point(7, 8);
			this.m_gbOriginal.Name = "m_gbOriginal";
			this.m_gbOriginal.Size = new System.Drawing.Size(475, 120);
			this.m_gbOriginal.TabIndex = 14;
			this.m_gbOriginal.TabStop = false;
			this.m_gbOriginal.Text = "Norma Original";
			// 
			// m_txtOriginal
			// 
			this.m_txtOriginal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_txtOriginal.Location = new System.Drawing.Point(8, 16);
			this.m_txtOriginal.Multiline = true;
			this.m_txtOriginal.Name = "m_txtOriginal";
			this.m_txtOriginal.ReadOnly = true;
			this.m_txtOriginal.Size = new System.Drawing.Size(459, 96);
			this.m_txtOriginal.TabIndex = 0;
			this.m_txtOriginal.Text = "";
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(182, 411);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 12;
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(246, 411);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 13;
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// frmFNormasEditar
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(494, 448);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFNormasEditar";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Edição de Norma";
			this.Load += new System.EventHandler(this.frmFNormasEditar_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbPersonalizacao.ResumeLayout(false);
			this.m_gbDetalhes.ResumeLayout(false);
			this.m_gbOriginal.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFNormasEditar_Load(object sender, System.EventArgs e)
				{
					vMostraCor();
					vRefreshInterface();
				}
			#endregion
			#region Botoes
				private void m_btOk_Click(object sender, System.EventArgs e)
				{
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
					case "mdlComponentesGraficos.ComboBox":
					case "mdlComponentesGraficos.TextBox":
					case "System.Windows.Forms.ListView":
					case "System.Windows.Forms.TextBox":
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

		#region Interface
			private void vRefreshInterface()
			{
				m_txtOriginal.Text = m_strNormaOriginal;
				m_txtDetalhes.Text = m_strNormaDetalhes;
				m_txtPersonalizada.Text = m_strNormaPersonalizada;
			}
		#endregion

		#region Retorno
			public void vRetornaValores(out string strNormaPersonalizada)
			{
				strNormaPersonalizada = m_txtPersonalizada.Text;
			}
		#endregion
	}
}
