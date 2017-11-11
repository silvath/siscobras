using System;
using System.Collections;
using System.Windows.Forms;

namespace mdlAgentes.Frames
{
	/// <summary>
	/// Summary description for frmFAgenteVendaComissao.
	/// </summary>
	internal class frmFAgenteVendaComissao : mdlComponentesGraficos.FormFlutuante
	{
		#region Delegate
			public delegate void delCallCarregaDadosInterface(ref bool bPorcentagem,ref mdlComponentesGraficos.TextBox tbPorcentagem, ref System.Windows.Forms.Label lMoeda, ref mdlComponentesGraficos.TextBox tbComissao, ref System.Windows.Forms.RadioButton rbRemeter, ref System.Windows.Forms.RadioButton rbGrafica, ref System.Windows.Forms.RadioButton rbFatura, ref System.Windows.Forms.Label lValorSubTotal);
			public delegate void delCallSalvaDadosInterface(ref bool bPorcentagem,ref mdlComponentesGraficos.TextBox tbPorcentagem, ref mdlComponentesGraficos.TextBox tbComissao, ref System.Windows.Forms.RadioButton rbRemeter, ref System.Windows.Forms.RadioButton rbGrafica, ref System.Windows.Forms.RadioButton rbFatura);
			public delegate void delCallAlteraComissaoPorcentagem(ref mdlComponentesGraficos.TextBox tbPorcentagem, ref mdlComponentesGraficos.TextBox tbComissao);
			public delegate void delCallAlteraComissaoValor(ref mdlComponentesGraficos.TextBox tbComissao, ref mdlComponentesGraficos.TextBox tbPorcentagem);
		#endregion
		#region Events
			public event delCallCarregaDadosInterface eCallCarregaDadosInterface;
			public event delCallSalvaDadosInterface eCallSalvaDadosInterface;
			public event delCallAlteraComissaoPorcentagem eCallAlteraComissaoPorcentagem;
			public event delCallAlteraComissaoValor eCallAlteraComissaoValor;
		#endregion
		#region Events Methods
			protected virtual void OnCallCarregaDadosInterface()
			{
				bool bAtivado = m_bAtivado;
				m_bAtivado = false;
				if (eCallCarregaDadosInterface != null)
					eCallCarregaDadosInterface(ref m_bPorcentagem,ref m_tbComissaoPorcentagem, ref m_lSimboloMoeda, ref m_tbValorComissao, ref m_rbRemeter, ref m_rbGrafica, ref m_rbFatura, ref m_lValorSubTotal);
				m_bAtivado = bAtivado;
			}
			protected virtual void OnCallSalvaDadosInterface()
			{
				if (eCallSalvaDadosInterface != null)
					eCallSalvaDadosInterface(ref m_bPorcentagem,ref m_tbComissaoPorcentagem, ref m_tbValorComissao, ref m_rbRemeter, ref m_rbGrafica, ref m_rbFatura);
			}
			protected virtual void OnCallAlteraComissaoPorcentagem()
			{
				if (eCallAlteraComissaoPorcentagem != null)
					eCallAlteraComissaoPorcentagem(ref m_tbComissaoPorcentagem, ref m_tbValorComissao);
			}
			protected virtual void OnCallAlteraComissaoValor()
			{
				if (eCallAlteraComissaoValor != null)
					eCallAlteraComissaoValor(ref m_tbValorComissao, ref m_tbComissaoPorcentagem);
			}
		#endregion

		#region Atributos
			protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
			protected string m_strEnderecoExecutavel;

			public bool m_bModificado = false;

			private bool m_bAtivado = true;
			
			private bool m_bPorcentagem = false;

			private System.Windows.Forms.GroupBox m_gbFrame;
			private System.Windows.Forms.GroupBox m_gbFields;
			private System.Windows.Forms.Button m_btOk;
			private System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.Label m_lComissao;
			private mdlComponentesGraficos.TextBox m_tbComissaoPorcentagem;
			private System.Windows.Forms.Label m_lSimboloPorcentagem;
			private mdlComponentesGraficos.TextBox m_tbValorComissao;
			private System.Windows.Forms.Label m_lSimboloMoeda;
			private System.Windows.Forms.RadioButton m_rbRemeter;
			private System.Windows.Forms.Label m_lFormaComissao;
			private System.Windows.Forms.RadioButton m_rbFatura;
			private System.Windows.Forms.RadioButton m_rbGrafica;
			private System.Windows.Forms.Label m_lSubTexto;
			private System.Windows.Forms.Label m_lValorSubTotal;
			private System.Windows.Forms.ToolTip m_ttAgenteVenda;
			private System.ComponentModel.IContainer components;
		#endregion
		#region Properties
			public bool Porcentagem
			{
				get
				{
					return(m_bPorcentagem);
				}
			}
		#endregion
		#region Construtors and Destrutors
			public frmFAgenteVendaComissao(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, string EnderecoExecutavel)
			{
				InitializeComponent();

				m_cls_ter_tratadorErro = tratadorErro;
				m_strEnderecoExecutavel = EnderecoExecutavel;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFAgenteVendaComissao));
			this.m_gbFrame = new System.Windows.Forms.GroupBox();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbFields = new System.Windows.Forms.GroupBox();
			this.m_lValorSubTotal = new System.Windows.Forms.Label();
			this.m_lSubTexto = new System.Windows.Forms.Label();
			this.m_lFormaComissao = new System.Windows.Forms.Label();
			this.m_rbFatura = new System.Windows.Forms.RadioButton();
			this.m_rbGrafica = new System.Windows.Forms.RadioButton();
			this.m_rbRemeter = new System.Windows.Forms.RadioButton();
			this.m_lSimboloMoeda = new System.Windows.Forms.Label();
			this.m_tbValorComissao = new mdlComponentesGraficos.TextBox();
			this.m_lSimboloPorcentagem = new System.Windows.Forms.Label();
			this.m_tbComissaoPorcentagem = new mdlComponentesGraficos.TextBox();
			this.m_lComissao = new System.Windows.Forms.Label();
			this.m_ttAgenteVenda = new System.Windows.Forms.ToolTip(this.components);
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
			this.m_gbFrame.Size = new System.Drawing.Size(302, 197);
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
			this.m_btOk.Location = new System.Drawing.Point(91, 166);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 5;
			this.m_ttAgenteVenda.SetToolTip(this.m_btOk, "Confirmar");
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
			this.m_btCancelar.Location = new System.Drawing.Point(155, 166);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 6;
			this.m_ttAgenteVenda.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbFields
			// 
			this.m_gbFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFields.Controls.Add(this.m_lValorSubTotal);
			this.m_gbFields.Controls.Add(this.m_lSubTexto);
			this.m_gbFields.Controls.Add(this.m_lFormaComissao);
			this.m_gbFields.Controls.Add(this.m_rbFatura);
			this.m_gbFields.Controls.Add(this.m_rbGrafica);
			this.m_gbFields.Controls.Add(this.m_rbRemeter);
			this.m_gbFields.Controls.Add(this.m_lSimboloMoeda);
			this.m_gbFields.Controls.Add(this.m_tbValorComissao);
			this.m_gbFields.Controls.Add(this.m_lSimboloPorcentagem);
			this.m_gbFields.Controls.Add(this.m_tbComissaoPorcentagem);
			this.m_gbFields.Controls.Add(this.m_lComissao);
			this.m_gbFields.Font = new System.Drawing.Font("Arial", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbFields.Location = new System.Drawing.Point(8, 8);
			this.m_gbFields.Name = "m_gbFields";
			this.m_gbFields.Size = new System.Drawing.Size(286, 153);
			this.m_gbFields.TabIndex = 0;
			this.m_gbFields.TabStop = false;
			// 
			// m_lValorSubTotal
			// 
			this.m_lValorSubTotal.Enabled = false;
			this.m_lValorSubTotal.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lValorSubTotal.Location = new System.Drawing.Point(128, 21);
			this.m_lValorSubTotal.Name = "m_lValorSubTotal";
			this.m_lValorSubTotal.Size = new System.Drawing.Size(96, 16);
			this.m_lValorSubTotal.TabIndex = 10;
			this.m_lValorSubTotal.Text = "SubTotalValor";
			this.m_lValorSubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_lSubTexto
			// 
			this.m_lSubTexto.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lSubTexto.Location = new System.Drawing.Point(59, 21);
			this.m_lSubTexto.Name = "m_lSubTexto";
			this.m_lSubTexto.Size = new System.Drawing.Size(57, 16);
			this.m_lSubTexto.TabIndex = 9;
			this.m_lSubTexto.Text = "SubTotal:";
			this.m_lSubTexto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_lFormaComissao
			// 
			this.m_lFormaComissao.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lFormaComissao.Location = new System.Drawing.Point(8, 76);
			this.m_lFormaComissao.Name = "m_lFormaComissao";
			this.m_lFormaComissao.Size = new System.Drawing.Size(44, 16);
			this.m_lFormaComissao.TabIndex = 8;
			this.m_lFormaComissao.Text = "Forma:";
			this.m_lFormaComissao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_rbFatura
			// 
			this.m_rbFatura.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_rbFatura.Location = new System.Drawing.Point(8, 128);
			this.m_rbFatura.Name = "m_rbFatura";
			this.m_rbFatura.Size = new System.Drawing.Size(96, 16);
			this.m_rbFatura.TabIndex = 7;
			this.m_rbFatura.Text = "Na Fatura - F";
			this.m_ttAgenteVenda.SetToolTip(this.m_rbFatura, "Seleciona a forma de pagamento da comissão");
			// 
			// m_rbGrafica
			// 
			this.m_rbGrafica.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_rbGrafica.Location = new System.Drawing.Point(8, 112);
			this.m_rbGrafica.Name = "m_rbGrafica";
			this.m_rbGrafica.Size = new System.Drawing.Size(119, 16);
			this.m_rbGrafica.TabIndex = 6;
			this.m_rbGrafica.Text = "Conta Gráfica - G";
			this.m_ttAgenteVenda.SetToolTip(this.m_rbGrafica, "Seleciona a forma de pagamento da comissão");
			// 
			// m_rbRemeter
			// 
			this.m_rbRemeter.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_rbRemeter.Location = new System.Drawing.Point(8, 96);
			this.m_rbRemeter.Name = "m_rbRemeter";
			this.m_rbRemeter.Size = new System.Drawing.Size(104, 16);
			this.m_rbRemeter.TabIndex = 5;
			this.m_rbRemeter.Text = "A Remeter - R";
			this.m_ttAgenteVenda.SetToolTip(this.m_rbRemeter, "Seleciona a forma de pagamento da comissão");
			// 
			// m_lSimboloMoeda
			// 
			this.m_lSimboloMoeda.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lSimboloMoeda.Location = new System.Drawing.Point(160, 49);
			this.m_lSimboloMoeda.Name = "m_lSimboloMoeda";
			this.m_lSimboloMoeda.Size = new System.Drawing.Size(31, 16);
			this.m_lSimboloMoeda.TabIndex = 4;
			this.m_lSimboloMoeda.Text = "Moeda";
			this.m_lSimboloMoeda.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_tbValorComissao
			// 
			this.m_tbValorComissao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_tbValorComissao.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbValorComissao.Location = new System.Drawing.Point(194, 46);
			this.m_tbValorComissao.Name = "m_tbValorComissao";
			this.m_tbValorComissao.OnlyNumbers = true;
			this.m_tbValorComissao.Size = new System.Drawing.Size(84, 21);
			this.m_tbValorComissao.TabIndex = 3;
			this.m_tbValorComissao.Text = "";
			this.m_tbValorComissao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.m_ttAgenteVenda.SetToolTip(this.m_tbValorComissao, "Valor");
			this.m_tbValorComissao.Leave += new System.EventHandler(this.m_tbValorComissao_Leave);
			this.m_tbValorComissao.TextChanged += new System.EventHandler(this.m_tbValorComissao_TextChanged);
			// 
			// m_lSimboloPorcentagem
			// 
			this.m_lSimboloPorcentagem.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lSimboloPorcentagem.Location = new System.Drawing.Point(127, 49);
			this.m_lSimboloPorcentagem.Name = "m_lSimboloPorcentagem";
			this.m_lSimboloPorcentagem.Size = new System.Drawing.Size(33, 16);
			this.m_lSimboloPorcentagem.TabIndex = 2;
			this.m_lSimboloPorcentagem.Text = "% ou";
			this.m_lSimboloPorcentagem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_tbComissaoPorcentagem
			// 
			this.m_tbComissaoPorcentagem.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbComissaoPorcentagem.Location = new System.Drawing.Point(80, 46);
			this.m_tbComissaoPorcentagem.Name = "m_tbComissaoPorcentagem";
			this.m_tbComissaoPorcentagem.OnlyNumbers = true;
			this.m_tbComissaoPorcentagem.Size = new System.Drawing.Size(44, 21);
			this.m_tbComissaoPorcentagem.TabIndex = 1;
			this.m_tbComissaoPorcentagem.Text = "";
			this.m_tbComissaoPorcentagem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.m_ttAgenteVenda.SetToolTip(this.m_tbComissaoPorcentagem, "Porcentagem sobre o SubTotal");
			this.m_tbComissaoPorcentagem.Leave += new System.EventHandler(this.m_tbComissaoPorcentagem_Leave);
			this.m_tbComissaoPorcentagem.TextChanged += new System.EventHandler(this.m_tbComissaoPorcentagem_TextChanged);
			// 
			// m_lComissao
			// 
			this.m_lComissao.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lComissao.Location = new System.Drawing.Point(8, 49);
			this.m_lComissao.Name = "m_lComissao";
			this.m_lComissao.Size = new System.Drawing.Size(64, 16);
			this.m_lComissao.TabIndex = 0;
			this.m_lComissao.Text = "Comissão:";
			this.m_lComissao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_ttAgenteVenda
			// 
			this.m_ttAgenteVenda.AutomaticDelay = 100;
			this.m_ttAgenteVenda.AutoPopDelay = 5000;
			this.m_ttAgenteVenda.InitialDelay = 100;
			this.m_ttAgenteVenda.ReshowDelay = 20;
			// 
			// frmFAgenteVendaComissao
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(306, 199);
			this.Controls.Add(this.m_gbFrame);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFAgenteVendaComissao";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Agente de Venda";
			this.Load += new System.EventHandler(this.frmFAgenteVendaComissao_Load);
			this.m_gbFrame.ResumeLayout(false);
			this.m_gbFields.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Cores
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
			} 
			catch (Exception erro) 
			{ 
				Object err = (Object)erro;
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}

		#endregion
		#region Eventos
			#region Load
			private void frmFAgenteVendaComissao_Load(object sender, System.EventArgs e)
			{
				if (m_bAtivado)
				{
					m_bAtivado = false;
					OnCallCarregaDadosInterface();
					this.mostraCor();
					m_bAtivado = true;
				}
			}
			#endregion
			#region Ok
			private void m_btOk_Click(object sender, System.EventArgs e)
			{
				if (m_bAtivado)
				{
					m_bAtivado = false;
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					OnCallSalvaDadosInterface();
					this.Close();
					this.Cursor = System.Windows.Forms.Cursors.Default;
					m_bAtivado = true;
				}
			}
			#endregion
			#region Cancelar
			private void m_btCancelar_Click(object sender, System.EventArgs e)
			{
				this.Close();
			}
			#endregion
			#region Leave
			private void m_tbComissaoPorcentagem_Leave(object sender, System.EventArgs e)
			{
				if (m_bAtivado)
				{
					m_bAtivado = false;
					OnCallAlteraComissaoPorcentagem();
					m_bAtivado = true;
				}
			}
			private void m_tbValorComissao_Leave(object sender, System.EventArgs e)
			{
				if (m_bAtivado)
				{
					m_bAtivado = false;
					OnCallAlteraComissaoValor();
					m_bAtivado = true;
				}
			}
			#endregion
			#region TextBoxes
				private void m_tbComissaoPorcentagem_TextChanged(object sender, System.EventArgs e)
				{
					if (m_bAtivado)
						m_bPorcentagem = true;
				}

				private void m_tbValorComissao_TextChanged(object sender, System.EventArgs e)
				{
					if (m_bAtivado)
						m_bPorcentagem = false;
				}
			#endregion
		#endregion
	}
}
