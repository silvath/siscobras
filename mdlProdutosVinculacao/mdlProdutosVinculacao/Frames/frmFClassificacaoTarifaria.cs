using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlProdutosVinculacao.Frames
{
	/// <summary>
	/// Summary description for frmFClassificacaoTarifaria.
	/// </summary>
	internal class frmFClassificacaoTarifaria : mdlComponentesGraficos.FormFlutuante
	{
		#region Atributos
		private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
		private string m_strEnderecoExecutavel = "";

		public bool m_bModificado = false;

		private System.Windows.Forms.GroupBox m_gbFrame;
		private System.Windows.Forms.Button m_btOk;
		private System.Windows.Forms.Button m_btCancelar;
		private System.Windows.Forms.Button m_btTrocarCor;
		private System.Windows.Forms.GroupBox m_gbFields;
		private System.Windows.Forms.Label m_lSugestao;
		private System.Windows.Forms.TextBox m_tbClassificacao;
		private System.Windows.Forms.Label m_lClassificacao;
		private System.Windows.Forms.Button m_btCopiarSugestao;
		private System.Windows.Forms.ToolTip m_ttClassificacao;
		private System.Windows.Forms.TextBox m_tbSugestao;
		private System.ComponentModel.IContainer components;
		#endregion

		#region Construtores & Destrutores
		public frmFClassificacaoTarifaria(ref mdlTratamentoErro.clsTratamentoErro clstratadorErro, string strEnderecoExecutavel)
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

		#region Delegate
		public delegate void delCallCarregaDadosInterface(ref System.Windows.Forms.TextBox tbSugestao, ref System.Windows.Forms.TextBox tbClassificacao);
		public delegate void delCallCopiaSugestao(ref System.Windows.Forms.TextBox tbClassificacao);
		public delegate void delCallSalvaDadosInterface(ref System.Windows.Forms.TextBox tbClassificacao);
		#endregion
		#region Events
		public event delCallCarregaDadosInterface eCallCarregaDadosInterface;
		public event delCallCopiaSugestao eCallCopiaSugestao;
		public event delCallSalvaDadosInterface eCallSalvaDadosInterface;
		#endregion
		#region Events Methods
		protected virtual void OnCallCarregaDadosInterface()
		{
			if (eCallCarregaDadosInterface != null)
				eCallCarregaDadosInterface(ref m_tbSugestao, ref m_tbClassificacao);
		}
		protected virtual void OnCallCopiaSugestao()
		{
			if (eCallCopiaSugestao != null)
				eCallCopiaSugestao(ref m_tbClassificacao);
		}
		protected virtual void OnCallSalvaDadosInterface()
		{
			if (eCallSalvaDadosInterface != null)
				eCallSalvaDadosInterface(ref m_tbClassificacao);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFClassificacaoTarifaria));
			this.m_gbFrame = new System.Windows.Forms.GroupBox();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_btTrocarCor = new System.Windows.Forms.Button();
			this.m_gbFields = new System.Windows.Forms.GroupBox();
			this.m_btCopiarSugestao = new System.Windows.Forms.Button();
			this.m_tbClassificacao = new System.Windows.Forms.TextBox();
			this.m_lClassificacao = new System.Windows.Forms.Label();
			this.m_tbSugestao = new System.Windows.Forms.TextBox();
			this.m_lSugestao = new System.Windows.Forms.Label();
			this.m_ttClassificacao = new System.Windows.Forms.ToolTip(this.components);
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
			this.m_gbFrame.Controls.Add(this.m_btTrocarCor);
			this.m_gbFrame.Controls.Add(this.m_gbFields);
			this.m_gbFrame.Location = new System.Drawing.Point(2, 0);
			this.m_gbFrame.Name = "m_gbFrame";
			this.m_gbFrame.Size = new System.Drawing.Size(382, 263);
			this.m_gbFrame.TabIndex = 1;
			this.m_gbFrame.TabStop = false;
			// 
			// m_btOk
			// 
			this.m_btOk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(131, 231);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 27);
			this.m_btOk.TabIndex = 1;
			this.m_ttClassificacao.SetToolTip(this.m_btOk, "Confirmar");
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(195, 231);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 27);
			this.m_btCancelar.TabIndex = 2;
			this.m_ttClassificacao.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_btTrocarCor
			// 
			this.m_btTrocarCor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_btTrocarCor.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_btTrocarCor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btTrocarCor.Location = new System.Drawing.Point(4, 9);
			this.m_btTrocarCor.Name = "m_btTrocarCor";
			this.m_btTrocarCor.Size = new System.Drawing.Size(4, 4);
			this.m_btTrocarCor.TabIndex = 3;
			this.m_ttClassificacao.SetToolTip(this.m_btTrocarCor, "Cor");
			this.m_btTrocarCor.Click += new System.EventHandler(this.m_btTrocarCor_Click);
			// 
			// m_gbFields
			// 
			this.m_gbFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFields.Controls.Add(this.m_btCopiarSugestao);
			this.m_gbFields.Controls.Add(this.m_tbClassificacao);
			this.m_gbFields.Controls.Add(this.m_lClassificacao);
			this.m_gbFields.Controls.Add(this.m_tbSugestao);
			this.m_gbFields.Controls.Add(this.m_lSugestao);
			this.m_gbFields.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbFields.Location = new System.Drawing.Point(8, 8);
			this.m_gbFields.Name = "m_gbFields";
			this.m_gbFields.Size = new System.Drawing.Size(366, 218);
			this.m_gbFields.TabIndex = 0;
			this.m_gbFields.TabStop = false;
			// 
			// m_btCopiarSugestao
			// 
			this.m_btCopiarSugestao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_btCopiarSugestao.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCopiarSugestao.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCopiarSugestao.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCopiarSugestao.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCopiarSugestao.Image = ((System.Drawing.Image)(resources.GetObject("m_btCopiarSugestao.Image")));
			this.m_btCopiarSugestao.Location = new System.Drawing.Point(171, 100);
			this.m_btCopiarSugestao.Name = "m_btCopiarSugestao";
			this.m_btCopiarSugestao.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCopiarSugestao.Size = new System.Drawing.Size(25, 25);
			this.m_btCopiarSugestao.TabIndex = 2;
			this.m_ttClassificacao.SetToolTip(this.m_btCopiarSugestao, "Aplicar Sugestão");
			this.m_btCopiarSugestao.Click += new System.EventHandler(this.m_btCopiarSugestao_Click);
			// 
			// m_tbClassificacao
			// 
			this.m_tbClassificacao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_tbClassificacao.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbClassificacao.Location = new System.Drawing.Point(96, 128);
			this.m_tbClassificacao.Multiline = true;
			this.m_tbClassificacao.Name = "m_tbClassificacao";
			this.m_tbClassificacao.Size = new System.Drawing.Size(261, 80);
			this.m_tbClassificacao.TabIndex = 1;
			this.m_tbClassificacao.Text = "";
			// 
			// m_lClassificacao
			// 
			this.m_lClassificacao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lClassificacao.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lClassificacao.Location = new System.Drawing.Point(8, 128);
			this.m_lClassificacao.Name = "m_lClassificacao";
			this.m_lClassificacao.Size = new System.Drawing.Size(85, 18);
			this.m_lClassificacao.TabIndex = 0;
			this.m_lClassificacao.Text = "Classificação:";
			this.m_lClassificacao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_tbSugestao
			// 
			this.m_tbSugestao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_tbSugestao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_tbSugestao.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbSugestao.Location = new System.Drawing.Point(96, 17);
			this.m_tbSugestao.Multiline = true;
			this.m_tbSugestao.Name = "m_tbSugestao";
			this.m_tbSugestao.ReadOnly = true;
			this.m_tbSugestao.Size = new System.Drawing.Size(261, 80);
			this.m_tbSugestao.TabIndex = 1;
			this.m_tbSugestao.Text = "";
			// 
			// m_lSugestao
			// 
			this.m_lSugestao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lSugestao.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lSugestao.Location = new System.Drawing.Point(8, 17);
			this.m_lSugestao.Name = "m_lSugestao";
			this.m_lSugestao.Size = new System.Drawing.Size(85, 18);
			this.m_lSugestao.TabIndex = 0;
			this.m_lSugestao.Text = "Sugestão:";
			this.m_lSugestao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_ttClassificacao
			// 
			this.m_ttClassificacao.AutomaticDelay = 100;
			this.m_ttClassificacao.AutoPopDelay = 5000;
			this.m_ttClassificacao.InitialDelay = 100;
			this.m_ttClassificacao.ReshowDelay = 20;
			// 
			// frmFClassificacaoTarifaria
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(386, 265);
			this.Controls.Add(this.m_gbFrame);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFClassificacaoTarifaria";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Classificação Tarifária";
			this.Load += new System.EventHandler(this.frmFClassificacaoTarifaria_Load);
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
		public void trocaCor()
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
		#endregion
		#region Mostrar Cor
		/// <summary>
		/// Mostra a cor do Formulario Controlado
		/// </summary>
		public void mostraCor()
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
							if (((this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"System.Windows.Forms.TextBox") &&
								(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.ComboBox") &&
								(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.TextBox")) || (this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() == 
								"System.Windows.Forms.TextBox") && (this.Controls[cont].Controls[cont2].Controls[cont3].Name == 
								"m_tbSugestao"))
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

		#region Eventos
		#region Load
		private void frmFClassificacaoTarifaria_Load(object sender, System.EventArgs e)
		{
			this.mostraCor();
			OnCallCarregaDadosInterface();
		}
		#endregion
		#region Copiar Sugestão
		private void m_btCopiarSugestao_Click(object sender, System.EventArgs e)
		{
			OnCallCopiaSugestao();
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
			m_bModificado = true;
			OnCallSalvaDadosInterface();
			this.Close();
		}
		#endregion
		#region Cor
		private void m_btTrocarCor_Click(object sender, System.EventArgs e)
		{
			this.trocaCor();
		}
		#endregion
		#endregion
	}
}
