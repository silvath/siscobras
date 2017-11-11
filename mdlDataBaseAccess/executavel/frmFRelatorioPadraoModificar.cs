using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace executavel
{
	/// <summary>
	/// Summary description for frmFRelatorioPadraoModificar.
	/// </summary>
	public class frmFRelatorioPadraoModificar : System.Windows.Forms.Form
	{
		#region Atributes
			public bool m_bModificado = false;

			private System.Windows.Forms.GroupBox m_gbGeral;
			private System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.Button m_btOk;
			private System.Windows.Forms.Label m_lbTipoAtual;
			private System.Windows.Forms.GroupBox m_gbAtual;
			private System.Windows.Forms.TextBox m_txtTipoAtual;
			private System.Windows.Forms.TextBox m_txtRelatorioAtual;
			private System.Windows.Forms.Label m_lbRelatorioAtual;
			private System.Windows.Forms.TextBox m_txtExportadorAtual;
			private System.Windows.Forms.Label m_lbExportadorAtual;
			private System.Windows.Forms.Label m_lbNomeAtual;
			private System.Windows.Forms.GroupBox m_gbModificacao;
			private System.Windows.Forms.TextBox m_txtNomeAtual;
			private System.Windows.Forms.TextBox m_txtNomeModificado;
			private System.Windows.Forms.Label m_lbNomeModificado;
			private System.Windows.Forms.Label m_lbExportadorModificado;
			private System.Windows.Forms.Label m_lbRelatorioModificado;
			private System.Windows.Forms.TextBox m_txtTipoModificado;
			private System.Windows.Forms.Label m_lbTipoModificado;
			private System.Windows.Forms.TextBox m_txtExportadorModificado;
			private System.Windows.Forms.TextBox m_txtRelatorioModificado;
			/// <summary>
			/// Required designer variable.
			/// </summary>
			private System.ComponentModel.Container components = null;
		#endregion
		#region Contructors and Destructors
			public frmFRelatorioPadraoModificar(int nIdTipo,int nIdRelatorio,int nIdExportador,string strNome)
			{
				InitializeComponent();
				// Atual
				m_txtExportadorAtual.Text = nIdExportador.ToString();
				m_txtTipoAtual.Text = nIdTipo.ToString();
				m_txtRelatorioAtual.Text = nIdRelatorio.ToString();
				m_txtNomeAtual.Text = strNome;

				// Modificado
				m_txtExportadorModificado.Text = "0";
				m_txtTipoModificado.Text = nIdTipo.ToString();
				m_txtRelatorioModificado.Text = nIdRelatorio.ToString();
				m_txtNomeModificado.Text = strNome;
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
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_gbModificacao = new System.Windows.Forms.GroupBox();
			this.m_txtNomeModificado = new System.Windows.Forms.TextBox();
			this.m_lbNomeModificado = new System.Windows.Forms.Label();
			this.m_txtExportadorModificado = new System.Windows.Forms.TextBox();
			this.m_lbExportadorModificado = new System.Windows.Forms.Label();
			this.m_txtRelatorioModificado = new System.Windows.Forms.TextBox();
			this.m_lbRelatorioModificado = new System.Windows.Forms.Label();
			this.m_txtTipoModificado = new System.Windows.Forms.TextBox();
			this.m_lbTipoModificado = new System.Windows.Forms.Label();
			this.m_gbAtual = new System.Windows.Forms.GroupBox();
			this.m_txtNomeAtual = new System.Windows.Forms.TextBox();
			this.m_lbNomeAtual = new System.Windows.Forms.Label();
			this.m_txtExportadorAtual = new System.Windows.Forms.TextBox();
			this.m_lbExportadorAtual = new System.Windows.Forms.Label();
			this.m_txtRelatorioAtual = new System.Windows.Forms.TextBox();
			this.m_lbRelatorioAtual = new System.Windows.Forms.Label();
			this.m_txtTipoAtual = new System.Windows.Forms.TextBox();
			this.m_lbTipoAtual = new System.Windows.Forms.Label();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_gbGeral.SuspendLayout();
			this.m_gbModificacao.SuspendLayout();
			this.m_gbAtual.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Controls.Add(this.m_gbModificacao);
			this.m_gbGeral.Controls.Add(this.m_gbAtual);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Location = new System.Drawing.Point(4, -2);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(308, 266);
			this.m_gbGeral.TabIndex = 0;
			this.m_gbGeral.TabStop = false;
			// 
			// m_gbModificacao
			// 
			this.m_gbModificacao.Controls.Add(this.m_txtNomeModificado);
			this.m_gbModificacao.Controls.Add(this.m_lbNomeModificado);
			this.m_gbModificacao.Controls.Add(this.m_txtExportadorModificado);
			this.m_gbModificacao.Controls.Add(this.m_lbExportadorModificado);
			this.m_gbModificacao.Controls.Add(this.m_txtRelatorioModificado);
			this.m_gbModificacao.Controls.Add(this.m_lbRelatorioModificado);
			this.m_gbModificacao.Controls.Add(this.m_txtTipoModificado);
			this.m_gbModificacao.Controls.Add(this.m_lbTipoModificado);
			this.m_gbModificacao.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbModificacao.Location = new System.Drawing.Point(6, 121);
			this.m_gbModificacao.Name = "m_gbModificacao";
			this.m_gbModificacao.Size = new System.Drawing.Size(296, 112);
			this.m_gbModificacao.TabIndex = 6;
			this.m_gbModificacao.TabStop = false;
			this.m_gbModificacao.Text = "Modificação";
			// 
			// m_txtNomeModificado
			// 
			this.m_txtNomeModificado.Location = new System.Drawing.Point(96, 86);
			this.m_txtNomeModificado.Name = "m_txtNomeModificado";
			this.m_txtNomeModificado.Size = new System.Drawing.Size(192, 20);
			this.m_txtNomeModificado.TabIndex = 11;
			this.m_txtNomeModificado.Text = "";
			// 
			// m_lbNomeModificado
			// 
			this.m_lbNomeModificado.Location = new System.Drawing.Point(13, 89);
			this.m_lbNomeModificado.Name = "m_lbNomeModificado";
			this.m_lbNomeModificado.Size = new System.Drawing.Size(60, 16);
			this.m_lbNomeModificado.TabIndex = 10;
			this.m_lbNomeModificado.Text = "Nome:";
			// 
			// m_txtExportadorModificado
			// 
			this.m_txtExportadorModificado.Location = new System.Drawing.Point(96, 63);
			this.m_txtExportadorModificado.Name = "m_txtExportadorModificado";
			this.m_txtExportadorModificado.Size = new System.Drawing.Size(192, 20);
			this.m_txtExportadorModificado.TabIndex = 9;
			this.m_txtExportadorModificado.Text = "";
			// 
			// m_lbExportadorModificado
			// 
			this.m_lbExportadorModificado.Location = new System.Drawing.Point(12, 66);
			this.m_lbExportadorModificado.Name = "m_lbExportadorModificado";
			this.m_lbExportadorModificado.Size = new System.Drawing.Size(68, 16);
			this.m_lbExportadorModificado.TabIndex = 8;
			this.m_lbExportadorModificado.Text = "Exportador:";
			// 
			// m_txtRelatorioModificado
			// 
			this.m_txtRelatorioModificado.Location = new System.Drawing.Point(95, 39);
			this.m_txtRelatorioModificado.Name = "m_txtRelatorioModificado";
			this.m_txtRelatorioModificado.Size = new System.Drawing.Size(192, 20);
			this.m_txtRelatorioModificado.TabIndex = 7;
			this.m_txtRelatorioModificado.Text = "";
			// 
			// m_lbRelatorioModificado
			// 
			this.m_lbRelatorioModificado.Location = new System.Drawing.Point(12, 42);
			this.m_lbRelatorioModificado.Name = "m_lbRelatorioModificado";
			this.m_lbRelatorioModificado.Size = new System.Drawing.Size(68, 16);
			this.m_lbRelatorioModificado.TabIndex = 6;
			this.m_lbRelatorioModificado.Text = "Relatorio:";
			// 
			// m_txtTipoModificado
			// 
			this.m_txtTipoModificado.Location = new System.Drawing.Point(96, 15);
			this.m_txtTipoModificado.Name = "m_txtTipoModificado";
			this.m_txtTipoModificado.Size = new System.Drawing.Size(192, 20);
			this.m_txtTipoModificado.TabIndex = 5;
			this.m_txtTipoModificado.Text = "";
			// 
			// m_lbTipoModificado
			// 
			this.m_lbTipoModificado.Location = new System.Drawing.Point(13, 18);
			this.m_lbTipoModificado.Name = "m_lbTipoModificado";
			this.m_lbTipoModificado.Size = new System.Drawing.Size(51, 16);
			this.m_lbTipoModificado.TabIndex = 4;
			this.m_lbTipoModificado.Text = "Tipo:";
			// 
			// m_gbAtual
			// 
			this.m_gbAtual.Controls.Add(this.m_txtNomeAtual);
			this.m_gbAtual.Controls.Add(this.m_lbNomeAtual);
			this.m_gbAtual.Controls.Add(this.m_txtExportadorAtual);
			this.m_gbAtual.Controls.Add(this.m_lbExportadorAtual);
			this.m_gbAtual.Controls.Add(this.m_txtRelatorioAtual);
			this.m_gbAtual.Controls.Add(this.m_lbRelatorioAtual);
			this.m_gbAtual.Controls.Add(this.m_txtTipoAtual);
			this.m_gbAtual.Controls.Add(this.m_lbTipoAtual);
			this.m_gbAtual.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbAtual.Location = new System.Drawing.Point(6, 8);
			this.m_gbAtual.Name = "m_gbAtual";
			this.m_gbAtual.Size = new System.Drawing.Size(296, 112);
			this.m_gbAtual.TabIndex = 5;
			this.m_gbAtual.TabStop = false;
			this.m_gbAtual.Text = "Atual";
			// 
			// m_txtNomeAtual
			// 
			this.m_txtNomeAtual.Location = new System.Drawing.Point(96, 86);
			this.m_txtNomeAtual.Name = "m_txtNomeAtual";
			this.m_txtNomeAtual.ReadOnly = true;
			this.m_txtNomeAtual.Size = new System.Drawing.Size(192, 20);
			this.m_txtNomeAtual.TabIndex = 11;
			this.m_txtNomeAtual.Text = "";
			// 
			// m_lbNomeAtual
			// 
			this.m_lbNomeAtual.Location = new System.Drawing.Point(13, 89);
			this.m_lbNomeAtual.Name = "m_lbNomeAtual";
			this.m_lbNomeAtual.Size = new System.Drawing.Size(60, 16);
			this.m_lbNomeAtual.TabIndex = 10;
			this.m_lbNomeAtual.Text = "Nome:";
			// 
			// m_txtExportadorAtual
			// 
			this.m_txtExportadorAtual.Location = new System.Drawing.Point(96, 63);
			this.m_txtExportadorAtual.Name = "m_txtExportadorAtual";
			this.m_txtExportadorAtual.ReadOnly = true;
			this.m_txtExportadorAtual.Size = new System.Drawing.Size(192, 20);
			this.m_txtExportadorAtual.TabIndex = 9;
			this.m_txtExportadorAtual.Text = "";
			// 
			// m_lbExportadorAtual
			// 
			this.m_lbExportadorAtual.Location = new System.Drawing.Point(12, 66);
			this.m_lbExportadorAtual.Name = "m_lbExportadorAtual";
			this.m_lbExportadorAtual.Size = new System.Drawing.Size(68, 16);
			this.m_lbExportadorAtual.TabIndex = 8;
			this.m_lbExportadorAtual.Text = "Exportador:";
			// 
			// m_txtRelatorioAtual
			// 
			this.m_txtRelatorioAtual.Location = new System.Drawing.Point(95, 39);
			this.m_txtRelatorioAtual.Name = "m_txtRelatorioAtual";
			this.m_txtRelatorioAtual.ReadOnly = true;
			this.m_txtRelatorioAtual.Size = new System.Drawing.Size(192, 20);
			this.m_txtRelatorioAtual.TabIndex = 7;
			this.m_txtRelatorioAtual.Text = "";
			// 
			// m_lbRelatorioAtual
			// 
			this.m_lbRelatorioAtual.Location = new System.Drawing.Point(12, 42);
			this.m_lbRelatorioAtual.Name = "m_lbRelatorioAtual";
			this.m_lbRelatorioAtual.Size = new System.Drawing.Size(68, 16);
			this.m_lbRelatorioAtual.TabIndex = 6;
			this.m_lbRelatorioAtual.Text = "Relatorio:";
			// 
			// m_txtTipoAtual
			// 
			this.m_txtTipoAtual.Location = new System.Drawing.Point(96, 15);
			this.m_txtTipoAtual.Name = "m_txtTipoAtual";
			this.m_txtTipoAtual.ReadOnly = true;
			this.m_txtTipoAtual.Size = new System.Drawing.Size(192, 20);
			this.m_txtTipoAtual.TabIndex = 5;
			this.m_txtTipoAtual.Text = "";
			// 
			// m_lbTipoAtual
			// 
			this.m_lbTipoAtual.Location = new System.Drawing.Point(13, 18);
			this.m_lbTipoAtual.Name = "m_lbTipoAtual";
			this.m_lbTipoAtual.Size = new System.Drawing.Size(51, 16);
			this.m_lbTipoAtual.TabIndex = 4;
			this.m_lbTipoAtual.Text = "Tipo:";
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.Location = new System.Drawing.Point(159, 236);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.Size = new System.Drawing.Size(72, 24);
			this.m_btCancelar.TabIndex = 3;
			this.m_btCancelar.Text = "Cancelar";
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_btOk
			// 
			this.m_btOk.Location = new System.Drawing.Point(79, 236);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.Size = new System.Drawing.Size(72, 24);
			this.m_btOk.TabIndex = 2;
			this.m_btOk.Text = "Ok";
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// frmFRelatorioPadraoModificar
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(314, 272);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFRelatorioPadraoModificar";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Modificar Relatorio";
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbModificacao.ResumeLayout(false);
			this.m_gbAtual.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Botoes
				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					m_bModificado = true;
					this.Close();
				}

				private void m_btCancelar_Click(object sender, System.EventArgs e)
				{
					this.Close();
				}
			#endregion
		#endregion

		#region Retorno
			public void vRetornoValores(out int nIdExportador,out int nIdTipo,out int nIdRelatorio,out string strNome)
			{
				nIdExportador = Int32.Parse(m_txtExportadorModificado.Text);
				nIdTipo = Int32.Parse(m_txtTipoModificado.Text);
				nIdRelatorio = Int32.Parse(m_txtRelatorioModificado.Text);
				strNome = m_txtNomeModificado.Text;
			}
		#endregion
	}
}
