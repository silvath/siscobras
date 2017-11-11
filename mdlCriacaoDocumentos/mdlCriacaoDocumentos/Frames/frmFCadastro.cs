using System;
using System.Collections;
using System.Windows.Forms;

namespace mdlCriacaoDocumentos.Frames
{
	/// <summary>
	/// Summary description for frmFCadastro.
	/// </summary>
	internal class frmFCadastro : mdlComponentesGraficos.FormFlutuante
	{
		#region Atributos
		private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
		private string m_strEnderecoExecutavel = "";

		public bool m_bModificado = false;

		private TIPOCRIACAO m_enumTipoCriacao;

		private System.Windows.Forms.GroupBox m_gbFrame;
		private System.Windows.Forms.GroupBox m_gbFields;
		private System.Windows.Forms.Button m_btOk;
		private System.Windows.Forms.Button m_btCancelar;
		internal System.Windows.Forms.Button m_btTrocarCor;
		private System.Windows.Forms.RadioButton m_rbComercial;
		private System.Windows.Forms.RadioButton m_rbProforma;
		private System.Windows.Forms.RadioButton m_rbAjuda;
		private System.Windows.Forms.RadioButton m_rbBranco;
		#endregion
		private System.Windows.Forms.ToolTip m_ttCadastro;
		private System.ComponentModel.IContainer components;

		#region Construtores & Destrutores
		public frmFCadastro(ref mdlTratamentoErro.clsTratamentoErro clstratadorErro, string strEnderecoExecutavel)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_cls_ter_tratadorErro = clstratadorErro;
			m_strEnderecoExecutavel = strEnderecoExecutavel;
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

		#region Delegates
		public delegate void delCallCarregaDadosInterface(ref System.Windows.Forms.GroupBox gbFields, out string strCadastroText, ref System.Windows.Forms.RadioButton rbProforma, ref System.Windows.Forms.RadioButton rbComercial);
		public delegate void delCallSelecionaTipoCriacao(TIPOCRIACAO enumTipoCriacao);
		#endregion
		#region Events
		public event delCallCarregaDadosInterface eCallCarregaDadosInterface;
		public event delCallSelecionaTipoCriacao eCallSelecionaTipoCriacao;
		#endregion
		#region EventsMethods
		protected virtual void OnCallCarregaDadosInterface()
		{
			string strNomeJanela;
			if (eCallCarregaDadosInterface != null)
			{
				eCallCarregaDadosInterface(ref m_gbFields, out strNomeJanela, ref m_rbProforma, ref m_rbComercial);
				this.Text = strNomeJanela;
			}
		}
		protected virtual void OnCallSelecionaTipoCriacao()
		{
			if (eCallSelecionaTipoCriacao != null)
				eCallSelecionaTipoCriacao(m_enumTipoCriacao);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFCadastro));
			this.m_gbFrame = new System.Windows.Forms.GroupBox();
			this.m_btTrocarCor = new System.Windows.Forms.Button();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbFields = new System.Windows.Forms.GroupBox();
			this.m_rbBranco = new System.Windows.Forms.RadioButton();
			this.m_rbComercial = new System.Windows.Forms.RadioButton();
			this.m_rbAjuda = new System.Windows.Forms.RadioButton();
			this.m_rbProforma = new System.Windows.Forms.RadioButton();
			this.m_ttCadastro = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbFrame.SuspendLayout();
			this.m_gbFields.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbFrame
			// 
			this.m_gbFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFrame.Controls.Add(this.m_btTrocarCor);
			this.m_gbFrame.Controls.Add(this.m_btOk);
			this.m_gbFrame.Controls.Add(this.m_btCancelar);
			this.m_gbFrame.Controls.Add(this.m_gbFields);
			this.m_gbFrame.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbFrame.Location = new System.Drawing.Point(2, 0);
			this.m_gbFrame.Name = "m_gbFrame";
			this.m_gbFrame.Size = new System.Drawing.Size(382, 173);
			this.m_gbFrame.TabIndex = 0;
			this.m_gbFrame.TabStop = false;
			// 
			// m_btTrocarCor
			// 
			this.m_btTrocarCor.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_btTrocarCor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btTrocarCor.Location = new System.Drawing.Point(4, 9);
			this.m_btTrocarCor.Name = "m_btTrocarCor";
			this.m_btTrocarCor.Size = new System.Drawing.Size(4, 4);
			this.m_btTrocarCor.TabIndex = 7;
			this.m_ttCadastro.SetToolTip(this.m_btTrocarCor, "Cor");
			this.m_btTrocarCor.Click += new System.EventHandler(this.m_btTrocarCor_Click);
			// 
			// m_btOk
			// 
			this.m_btOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(133, 142);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 5;
			this.m_ttCadastro.SetToolTip(this.m_btOk, "Confirmar");
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
			this.m_btCancelar.Location = new System.Drawing.Point(197, 142);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 6;
			this.m_ttCadastro.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbFields
			// 
			this.m_gbFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFields.Controls.Add(this.m_rbBranco);
			this.m_gbFields.Controls.Add(this.m_rbComercial);
			this.m_gbFields.Controls.Add(this.m_rbAjuda);
			this.m_gbFields.Controls.Add(this.m_rbProforma);
			this.m_gbFields.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbFields.Location = new System.Drawing.Point(8, 7);
			this.m_gbFields.Name = "m_gbFields";
			this.m_gbFields.Size = new System.Drawing.Size(366, 129);
			this.m_gbFields.TabIndex = 0;
			this.m_gbFields.TabStop = false;
			this.m_gbFields.Text = "Processo";
			// 
			// m_rbBranco
			// 
			this.m_rbBranco.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_rbBranco.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_rbBranco.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_rbBranco.ForeColor = System.Drawing.Color.OrangeRed;
			this.m_rbBranco.Location = new System.Drawing.Point(8, 23);
			this.m_rbBranco.Name = "m_rbBranco";
			this.m_rbBranco.Size = new System.Drawing.Size(108, 18);
			this.m_rbBranco.TabIndex = 4;
			this.m_rbBranco.Text = "Em branco";
			this.m_ttCadastro.SetToolTip(this.m_rbBranco, "Selecione uma opção");
			this.m_rbBranco.CheckedChanged += new System.EventHandler(this.m_rbBranco_CheckedChanged);
			// 
			// m_rbComercial
			// 
			this.m_rbComercial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_rbComercial.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_rbComercial.Enabled = false;
			this.m_rbComercial.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_rbComercial.ForeColor = System.Drawing.Color.OrangeRed;
			this.m_rbComercial.Location = new System.Drawing.Point(8, 98);
			this.m_rbComercial.Name = "m_rbComercial";
			this.m_rbComercial.Size = new System.Drawing.Size(310, 18);
			this.m_rbComercial.TabIndex = 4;
			this.m_rbComercial.TabStop = true;
			this.m_rbComercial.Text = "Baseado em um PE";
			this.m_ttCadastro.SetToolTip(this.m_rbComercial, "Selecione uma opção");
			this.m_rbComercial.CheckedChanged += new System.EventHandler(this.m_rbComercial_CheckedChanged);
			// 
			// m_rbAjuda
			// 
			this.m_rbAjuda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_rbAjuda.Checked = true;
			this.m_rbAjuda.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_rbAjuda.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_rbAjuda.ForeColor = System.Drawing.Color.Green;
			this.m_rbAjuda.Location = new System.Drawing.Point(8, 48);
			this.m_rbAjuda.Name = "m_rbAjuda";
			this.m_rbAjuda.Size = new System.Drawing.Size(202, 18);
			this.m_rbAjuda.TabIndex = 2;
			this.m_rbAjuda.TabStop = true;
			this.m_rbAjuda.Text = "Com a ajuda do assistente";
			this.m_ttCadastro.SetToolTip(this.m_rbAjuda, "Selecione uma opção");
			this.m_rbAjuda.CheckedChanged += new System.EventHandler(this.m_rbAjuda_CheckedChanged);
			// 
			// m_rbProforma
			// 
			this.m_rbProforma.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_rbProforma.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_rbProforma.Enabled = false;
			this.m_rbProforma.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_rbProforma.ForeColor = System.Drawing.Color.OrangeRed;
			this.m_rbProforma.Location = new System.Drawing.Point(8, 73);
			this.m_rbProforma.Name = "m_rbProforma";
			this.m_rbProforma.Size = new System.Drawing.Size(350, 18);
			this.m_rbProforma.TabIndex = 3;
			this.m_rbProforma.TabStop = true;
			this.m_rbProforma.Text = "Baseado em uma Cotação (Fatura Proforma)";
			this.m_ttCadastro.SetToolTip(this.m_rbProforma, "Selecione uma opção");
			this.m_rbProforma.CheckedChanged += new System.EventHandler(this.m_rbProforma_CheckedChanged);
			// 
			// m_ttCadastro
			// 
			this.m_ttCadastro.AutomaticDelay = 100;
			this.m_ttCadastro.AutoPopDelay = 5000;
			this.m_ttCadastro.InitialDelay = 100;
			this.m_ttCadastro.ReshowDelay = 20;
			// 
			// frmFCadastro
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(8, 18);
			this.ClientSize = new System.Drawing.Size(386, 175);
			this.Controls.Add(this.m_gbFrame);
			this.Font = new System.Drawing.Font("Arial", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFCadastro";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Cadastro de Processo";
			this.Load += new System.EventHandler(this.frmFCadastro_Load);
			this.Activated += new System.EventHandler(this.frmFCadastro_Activated);
			this.m_gbFrame.ResumeLayout(false);
			this.m_gbFields.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Procedimentos Para Troca de Cor
		#region Trocar Cor
		/// <summary>
		/// Troca a cor do Formulario Controlado
		/// </summary>
		private void trocaCor()
		{
			try
			{
				mdlPaletaDeCores.clsPaletaDeCores controlPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini", "SiscobrasCorSecundaria");
				controlPaletaCores.mostraCorAtual();
				vMostraCor();
			} 
			catch (Exception erro) 
			{
				Object err = (Object)erro;
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion
		#region Mostrar Cor

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
					break;

				default:
					if (ctrControle.Enabled)
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

		/// <summary>
		/// Mostra a cor do Formulario Controlado
		/// </summary>
		public void mostraCor6()
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
						if ((this.Controls[cont].Controls[cont2].GetType().ToString() != "mdlComponentes.compTextBox") && (this.Controls[cont].Controls[cont2].GetType().ToString() != "mdlComponentes.compTextNumber"))
						{
							this.Controls[cont].Controls[cont2].BackColor = this.BackColor;
						}
						for (int cont3 = 0; cont3 < this.Controls[cont].Controls[cont2].Controls.Count; cont3++)
						{
							if ((this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.ListView") &&
								(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.ComboBox") &&
								(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.TextBox"))
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
		#endregion

		#region Verifica Coloração
		private void verificaCores()
		{
			try
			{
				m_rbBranco.ForeColor = System.Drawing.Color.OrangeRed;
				m_rbAjuda.ForeColor = System.Drawing.Color.OrangeRed;
				m_rbComercial.ForeColor = System.Drawing.Color.OrangeRed;
				m_rbProforma.ForeColor = System.Drawing.Color.OrangeRed;
				if (m_rbBranco.Checked)
				{
					m_rbBranco.ForeColor = System.Drawing.Color.Green;
					m_enumTipoCriacao = TIPOCRIACAO.NULO;
				}
				else if (m_rbAjuda.Checked)
				{
					m_rbAjuda.ForeColor = System.Drawing.Color.Green;
					m_enumTipoCriacao = TIPOCRIACAO.ASSISTENTE;
				}
				else if (m_rbComercial.Checked)
				{
					m_rbComercial.ForeColor = System.Drawing.Color.Green;
					m_enumTipoCriacao = TIPOCRIACAO.MODELO2;
				}
				else if (m_rbProforma.Checked)
				{
					m_rbProforma.ForeColor = System.Drawing.Color.Green;
					m_enumTipoCriacao = TIPOCRIACAO.MODELO1;
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Eventos
		#region Cor
		private void m_btTrocarCor_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.trocaCor();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Load
		private void frmFCadastro_Load(object sender, System.EventArgs e)
		{
			this.vMostraCor();
			OnCallCarregaDadosInterface();
		}
		#endregion
		#region OK
		private void m_btOk_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (m_rbAjuda.Checked || m_rbProforma.Checked || m_rbComercial.Checked || m_rbBranco.Checked)
				{
					m_bModificado = true;
					OnCallSelecionaTipoCriacao();
					this.Close();
				}
				else
				{
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Checked Changed
		private void m_rbAjuda_CheckedChanged(object sender, System.EventArgs e)
		{
			if (m_rbAjuda.Checked)
			{
				m_enumTipoCriacao = TIPOCRIACAO.ASSISTENTE;
				m_rbProforma.ForeColor = System.Drawing.Color.OrangeRed;
				m_rbComercial.ForeColor = System.Drawing.Color.OrangeRed;
				m_rbBranco.ForeColor = System.Drawing.Color.OrangeRed;
				m_rbAjuda.ForeColor = System.Drawing.Color.Green;
			}
		}
		private void m_rbProforma_CheckedChanged(object sender, System.EventArgs e)
		{
			if (m_rbProforma.Checked)
			{
				m_enumTipoCriacao = TIPOCRIACAO.MODELO1;
				m_rbAjuda.ForeColor = System.Drawing.Color.OrangeRed;
				m_rbComercial.ForeColor = System.Drawing.Color.OrangeRed;
				m_rbBranco.ForeColor = System.Drawing.Color.OrangeRed;
				m_rbProforma.ForeColor = System.Drawing.Color.Green;
			}
		}
		private void m_rbComercial_CheckedChanged(object sender, System.EventArgs e)
		{
			if (m_rbComercial.Checked)
			{
				m_enumTipoCriacao = TIPOCRIACAO.MODELO2;
				m_rbAjuda.ForeColor = System.Drawing.Color.OrangeRed;
				m_rbProforma.ForeColor = System.Drawing.Color.OrangeRed;
				m_rbBranco.ForeColor = System.Drawing.Color.OrangeRed;
				m_rbComercial.ForeColor = System.Drawing.Color.Green;
			}
		}
		private void m_rbBranco_CheckedChanged(object sender, System.EventArgs e)
		{
			if (m_rbBranco.Checked)
			{
				m_enumTipoCriacao = TIPOCRIACAO.NULO;
				m_rbAjuda.ForeColor = System.Drawing.Color.OrangeRed;
				m_rbProforma.ForeColor = System.Drawing.Color.OrangeRed;
				m_rbComercial.ForeColor = System.Drawing.Color.OrangeRed;
				m_rbBranco.ForeColor = System.Drawing.Color.Green;
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
		#region Activated
		private void frmFCadastro_Activated(object sender, System.EventArgs e)
		{
			verificaCores();
		}
		#endregion
		#endregion
	}
}
