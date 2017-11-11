using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlAgentes.Frames
{
	/// <summary>
	/// Summary description for frmFCadastroAgentesVendasBancos.
	/// </summary>
	internal class frmFCadastroAgentesVendasBancos : mdlComponentesGraficos.FormFlutuante
	{
		#region Delegate
			public delegate void delCallCarregaDadosInterface(ref mdlComponentesGraficos.TextBox tbNome, ref mdlComponentesGraficos.TextBox tbEndereco, ref mdlComponentesGraficos.TextBox tbCidade, ref mdlComponentesGraficos.ComboBox cbPais, ref mdlComponentesGraficos.TextBox tbInstrPagam);
			public delegate void delCallSalvaDadosInterface(ref mdlComponentesGraficos.TextBox tbNome, ref mdlComponentesGraficos.TextBox tbEndereco, ref mdlComponentesGraficos.TextBox tbCidade, ref mdlComponentesGraficos.ComboBox cbPais, ref mdlComponentesGraficos.TextBox tbInstrPagam);
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
					eCallCarregaDadosInterface(ref m_tbNomeBanco, ref m_tbEnderecoBanco, ref m_tbCidadeBanco, ref m_cbPaisesBanco, ref m_tbInstrucoesPagamento);
			}
			protected virtual void OnCallSalvaDadosInterface()
			{
				if (eCallSalvaDadosInterface != null)
					eCallSalvaDadosInterface(ref m_tbNomeBanco, ref m_tbEnderecoBanco, ref m_tbCidadeBanco, ref m_cbPaisesBanco, ref m_tbInstrucoesPagamento);
			}
			protected virtual void OnCallSalvaDadosBD()
			{
				if (eCallSalvaDadosBD != null)
					eCallSalvaDadosBD(m_bModificado);
			}
		#endregion

		#region Atributos
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
		protected string m_strEnderecoExecutavel;

		public bool m_bModificado = false;

		private bool m_bCadastroNovo = false;

		private System.Windows.Forms.GroupBox m_gbFrame;
		private System.Windows.Forms.GroupBox m_gbFields;
		private mdlComponentesGraficos.ComboBox m_cbPaisesBanco;
		private mdlComponentesGraficos.TextBox m_tbCidadeBanco;
		private mdlComponentesGraficos.TextBox m_tbEnderecoBanco;
		private mdlComponentesGraficos.TextBox m_tbNomeBanco;
		private System.Windows.Forms.Label m_lPaisBanco;
		private System.Windows.Forms.Label m_lCidadeBanco;
		private System.Windows.Forms.Label m_lEnderecoBanco;
		private System.Windows.Forms.Label m_lNomeBanco;
		private System.Windows.Forms.Button m_btOk;
		private System.Windows.Forms.Button m_btCancelar;
		private System.Windows.Forms.ToolTip m_ttCadastroBancos;
		private System.Windows.Forms.Label m_lInstrucoesPagamento;
		private mdlComponentesGraficos.TextBox m_tbInstrucoesPagamento;
		private System.ComponentModel.IContainer components;
		#endregion
		#region Construtores & Destrutores
		public frmFCadastroAgentesVendasBancos(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, string EnderecoExecutavel, bool bCadastroNovo)
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
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFCadastroAgentesVendasBancos));
			this.m_gbFrame = new System.Windows.Forms.GroupBox();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbFields = new System.Windows.Forms.GroupBox();
			this.m_tbInstrucoesPagamento = new mdlComponentesGraficos.TextBox();
			this.m_lInstrucoesPagamento = new System.Windows.Forms.Label();
			this.m_cbPaisesBanco = new mdlComponentesGraficos.ComboBox();
			this.m_tbCidadeBanco = new mdlComponentesGraficos.TextBox();
			this.m_tbEnderecoBanco = new mdlComponentesGraficos.TextBox();
			this.m_tbNomeBanco = new mdlComponentesGraficos.TextBox();
			this.m_lPaisBanco = new System.Windows.Forms.Label();
			this.m_lCidadeBanco = new System.Windows.Forms.Label();
			this.m_lEnderecoBanco = new System.Windows.Forms.Label();
			this.m_lNomeBanco = new System.Windows.Forms.Label();
			this.m_ttCadastroBancos = new System.Windows.Forms.ToolTip(this.components);
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
			this.m_gbFrame.Size = new System.Drawing.Size(230, 212);
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
			this.m_btOk.Location = new System.Drawing.Point(55, 181);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 7;
			this.m_ttCadastroBancos.SetToolTip(this.m_btOk, "Confirmar");
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
			this.m_btCancelar.Location = new System.Drawing.Point(119, 181);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 8;
			this.m_ttCadastroBancos.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbFields
			// 
			this.m_gbFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFields.Controls.Add(this.m_tbInstrucoesPagamento);
			this.m_gbFields.Controls.Add(this.m_lInstrucoesPagamento);
			this.m_gbFields.Controls.Add(this.m_cbPaisesBanco);
			this.m_gbFields.Controls.Add(this.m_tbCidadeBanco);
			this.m_gbFields.Controls.Add(this.m_tbEnderecoBanco);
			this.m_gbFields.Controls.Add(this.m_tbNomeBanco);
			this.m_gbFields.Controls.Add(this.m_lPaisBanco);
			this.m_gbFields.Controls.Add(this.m_lCidadeBanco);
			this.m_gbFields.Controls.Add(this.m_lEnderecoBanco);
			this.m_gbFields.Controls.Add(this.m_lNomeBanco);
			this.m_gbFields.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbFields.Location = new System.Drawing.Point(8, 8);
			this.m_gbFields.Name = "m_gbFields";
			this.m_gbFields.Size = new System.Drawing.Size(214, 168);
			this.m_gbFields.TabIndex = 0;
			this.m_gbFields.TabStop = false;
			this.m_gbFields.Text = "Cadastro / Edição";
			// 
			// m_tbInstrucoesPagamento
			// 
			this.m_tbInstrucoesPagamento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_tbInstrucoesPagamento.Location = new System.Drawing.Point(67, 112);
			this.m_tbInstrucoesPagamento.Multiline = true;
			this.m_tbInstrucoesPagamento.Name = "m_tbInstrucoesPagamento";
			this.m_tbInstrucoesPagamento.Size = new System.Drawing.Size(139, 49);
			this.m_tbInstrucoesPagamento.TabIndex = 19;
			this.m_tbInstrucoesPagamento.Text = "";
			// 
			// m_lInstrucoesPagamento
			// 
			this.m_lInstrucoesPagamento.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lInstrucoesPagamento.Location = new System.Drawing.Point(8, 115);
			this.m_lInstrucoesPagamento.Name = "m_lInstrucoesPagamento";
			this.m_lInstrucoesPagamento.Size = new System.Drawing.Size(42, 27);
			this.m_lInstrucoesPagamento.TabIndex = 18;
			this.m_lInstrucoesPagamento.Text = "Inst. de Pag.:";
			// 
			// m_cbPaisesBanco
			// 
			this.m_cbPaisesBanco.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_cbPaisesBanco.AutoCompleteCaseSensitive = false;
			this.m_cbPaisesBanco.GoToNextControlWithEnter = true;
			this.m_cbPaisesBanco.Location = new System.Drawing.Point(67, 88);
			this.m_cbPaisesBanco.Name = "m_cbPaisesBanco";
			this.m_cbPaisesBanco.Size = new System.Drawing.Size(139, 22);
			this.m_cbPaisesBanco.TabIndex = 17;
			this.m_ttCadastroBancos.SetToolTip(this.m_cbPaisesBanco, "Selecione o país");
			// 
			// m_tbCidadeBanco
			// 
			this.m_tbCidadeBanco.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_tbCidadeBanco.Location = new System.Drawing.Point(67, 64);
			this.m_tbCidadeBanco.Name = "m_tbCidadeBanco";
			this.m_tbCidadeBanco.Size = new System.Drawing.Size(139, 20);
			this.m_tbCidadeBanco.TabIndex = 16;
			this.m_tbCidadeBanco.Text = "";
			// 
			// m_tbEnderecoBanco
			// 
			this.m_tbEnderecoBanco.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_tbEnderecoBanco.Location = new System.Drawing.Point(67, 40);
			this.m_tbEnderecoBanco.Name = "m_tbEnderecoBanco";
			this.m_tbEnderecoBanco.Size = new System.Drawing.Size(139, 20);
			this.m_tbEnderecoBanco.TabIndex = 15;
			this.m_tbEnderecoBanco.Text = "";
			// 
			// m_tbNomeBanco
			// 
			this.m_tbNomeBanco.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_tbNomeBanco.Location = new System.Drawing.Point(67, 16);
			this.m_tbNomeBanco.Name = "m_tbNomeBanco";
			this.m_tbNomeBanco.Size = new System.Drawing.Size(139, 20);
			this.m_tbNomeBanco.TabIndex = 14;
			this.m_tbNomeBanco.Text = "";
			// 
			// m_lPaisBanco
			// 
			this.m_lPaisBanco.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lPaisBanco.Location = new System.Drawing.Point(8, 91);
			this.m_lPaisBanco.Name = "m_lPaisBanco";
			this.m_lPaisBanco.Size = new System.Drawing.Size(30, 16);
			this.m_lPaisBanco.TabIndex = 13;
			this.m_lPaisBanco.Text = "País:";
			this.m_lPaisBanco.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_lCidadeBanco
			// 
			this.m_lCidadeBanco.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lCidadeBanco.Location = new System.Drawing.Point(8, 67);
			this.m_lCidadeBanco.Name = "m_lCidadeBanco";
			this.m_lCidadeBanco.Size = new System.Drawing.Size(43, 16);
			this.m_lCidadeBanco.TabIndex = 12;
			this.m_lCidadeBanco.Text = "Cidade:";
			this.m_lCidadeBanco.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_lEnderecoBanco
			// 
			this.m_lEnderecoBanco.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lEnderecoBanco.Location = new System.Drawing.Point(8, 43);
			this.m_lEnderecoBanco.Name = "m_lEnderecoBanco";
			this.m_lEnderecoBanco.Size = new System.Drawing.Size(56, 16);
			this.m_lEnderecoBanco.TabIndex = 11;
			this.m_lEnderecoBanco.Text = "Endereço:";
			this.m_lEnderecoBanco.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_lNomeBanco
			// 
			this.m_lNomeBanco.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lNomeBanco.Location = new System.Drawing.Point(8, 19);
			this.m_lNomeBanco.Name = "m_lNomeBanco";
			this.m_lNomeBanco.Size = new System.Drawing.Size(38, 14);
			this.m_lNomeBanco.TabIndex = 10;
			this.m_lNomeBanco.Text = "Nome:";
			this.m_lNomeBanco.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_ttCadastroBancos
			// 
			this.m_ttCadastroBancos.AutomaticDelay = 100;
			this.m_ttCadastroBancos.AutoPopDelay = 5000;
			this.m_ttCadastroBancos.InitialDelay = 100;
			this.m_ttCadastroBancos.ReshowDelay = 20;
			// 
			// frmFCadastroAgentesVendasBancos
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(234, 214);
			this.Controls.Add(this.m_gbFrame);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFCadastroAgentesVendasBancos";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Agente de Venda Bancos";
			this.Load += new System.EventHandler(this.frmFCadastroAgentesVendasBancos_Load);
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
								"mdlComponentesGraficos.TextBox") && (this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.ComboBox") ||
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

		#region Get & Set
		public void setTextoGroupBox(string strTexto)
		{
			m_gbFields.Text = strTexto;
		}
		#endregion

		#region Eventos
		#region Load
		private void frmFCadastroAgentesVendasBancos_Load(object sender, System.EventArgs e)
		{
			mostraCor();
			OnCallCarregaDadosInterface();
			if (m_bCadastroNovo == false)
			{
				this.Text = "Edição Banco";
			}
			else
			{
				this.Text = "Cadastro Banco";
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
			if (m_cbPaisesBanco.ReturnObjectSelectedItem() != null)
			{
				if (m_tbNomeBanco.Text.Trim() != "")
				{
					if (m_tbEnderecoBanco.Text.Trim() != "")
					{
						m_bModificado = true;
						OnCallSalvaDadosInterface();
						OnCallSalvaDadosBD();
						this.Close();
					}
				}
			}
		}
		#endregion
		#endregion
	}
}
