using System;
using System.Collections;
using System.Windows.Forms;

namespace mdlProdutosVinculacao.Frames
{
	/// <summary>
	/// Summary description for frmFProdutosVinculacao.
	/// </summary>
	internal class frmFProdutosVinculacao : mdlComponentesGraficos.FormFlutuante
	{		
		#region Atributos
		private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
		private string m_strEnderecoExecutavel = "";

		private bool m_bMostrarSemClassificacao = false;

		private bool m_bModificado = false;

		private System.Windows.Forms.GroupBox m_gbFrame;
		private System.Windows.Forms.GroupBox m_gbFields;
		private System.Windows.Forms.Button btTrocarCor;
		private System.Windows.Forms.Button m_btOk;
		private mdlComponentesGraficos.TreeView m_treeVProdutos;
		private System.Windows.Forms.CheckBox m_chbxMostrar;
		private System.Windows.Forms.Button m_btProdutosGeral;
		private System.Windows.Forms.ToolTip m_ttVinculacao;
		private System.Windows.Forms.Button m_btCancelar;
		private System.ComponentModel.IContainer components;
		#endregion

		#region Construtores & Destrutores
		public frmFProdutosVinculacao(ref mdlTratamentoErro.clsTratamentoErro clstratadorErro, string strEnderecoExecutavel)
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
		public delegate void delCallCarregaDadosBD();
		public delegate void delCallCarregaDadosInterface(ref System.Windows.Forms.Form formProdutos, ref mdlComponentesGraficos.TreeView treeVProdutos, bool bMostrarSemClassificacao);
		public delegate void delCallRefreshInterface(ref mdlComponentesGraficos.TreeView treeVProdutos, bool bMostrarSemClassificacao);
		public delegate void delCallSalvaDadosBD(bool bModificado);
		public delegate void delCallSetaNcm(ref System.Windows.Forms.TreeNode tnProduto);
		public delegate void delCallSetaNaladi(ref System.Windows.Forms.TreeNode tnProduto);
		public delegate void delCallProdutosGeral();
		#endregion
		#region Events
		public event delCallCarregaDadosBD eCallCarregaDadosBD;
		public event delCallCarregaDadosInterface eCallCarregaDadosInterface;
		public event delCallRefreshInterface eCallRefreshInterface;
		public event delCallSalvaDadosBD eCallSalvaDadosBD;
		public event delCallSetaNcm eCallSetaNcm;
		public event delCallSetaNaladi eCallSetaNaladi;
		public event delCallProdutosGeral eCallProdutosGeral;
		#endregion
		#region Events Methods
		protected virtual void OnCallCarregaDadosBD()
		{
			if (eCallCarregaDadosBD != null)
				eCallCarregaDadosBD();
		}
		protected virtual void OnCallCarregaDadosInterface()
		{
			System.Windows.Forms.Form frmReferencia = (System.Windows.Forms.Form)this;
			if (eCallCarregaDadosInterface != null)
				eCallCarregaDadosInterface(ref frmReferencia, ref m_treeVProdutos, m_bMostrarSemClassificacao);
		}
		protected virtual void OnCallRefreshInterface()
		{
			if (eCallRefreshInterface != null)
				eCallRefreshInterface(ref m_treeVProdutos, m_bMostrarSemClassificacao);
		}
		protected virtual void OnCallSalvaDadosBD()
		{
			if (eCallSalvaDadosBD != null)
				eCallSalvaDadosBD(m_bModificado);
		}
		protected virtual void OnCallSetaNcm(ref System.Windows.Forms.TreeNode tnProduto)
		{
			if (eCallSetaNcm != null)
				eCallSetaNcm(ref tnProduto);
		}
		protected virtual void OnCallSetaNaladi(ref System.Windows.Forms.TreeNode tnProduto)
		{
			if (eCallSetaNaladi != null)
				eCallSetaNaladi(ref tnProduto);
		}
		protected virtual void OnCallProdutosGeral()
		{
			if (eCallProdutosGeral != null)
				eCallProdutosGeral();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFProdutosVinculacao));
			this.m_gbFrame = new System.Windows.Forms.GroupBox();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbFields = new System.Windows.Forms.GroupBox();
			this.m_treeVProdutos = new mdlComponentesGraficos.TreeView();
			this.m_chbxMostrar = new System.Windows.Forms.CheckBox();
			this.m_btProdutosGeral = new System.Windows.Forms.Button();
			this.m_btOk = new System.Windows.Forms.Button();
			this.btTrocarCor = new System.Windows.Forms.Button();
			this.m_ttVinculacao = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbFrame.SuspendLayout();
			this.m_gbFields.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbFrame
			// 
			this.m_gbFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFrame.Controls.Add(this.m_btCancelar);
			this.m_gbFrame.Controls.Add(this.m_gbFields);
			this.m_gbFrame.Controls.Add(this.m_btProdutosGeral);
			this.m_gbFrame.Controls.Add(this.m_btOk);
			this.m_gbFrame.Controls.Add(this.btTrocarCor);
			this.m_gbFrame.Location = new System.Drawing.Point(2, 0);
			this.m_gbFrame.Name = "m_gbFrame";
			this.m_gbFrame.Size = new System.Drawing.Size(362, 270);
			this.m_gbFrame.TabIndex = 0;
			this.m_gbFrame.TabStop = false;
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(217, 239);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 34;
			this.m_ttVinculacao.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbFields
			// 
			this.m_gbFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFields.Controls.Add(this.m_treeVProdutos);
			this.m_gbFields.Controls.Add(this.m_chbxMostrar);
			this.m_gbFields.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbFields.Location = new System.Drawing.Point(8, 8);
			this.m_gbFields.Name = "m_gbFields";
			this.m_gbFields.Size = new System.Drawing.Size(345, 226);
			this.m_gbFields.TabIndex = 0;
			this.m_gbFields.TabStop = false;
			this.m_gbFields.Text = "Produtos";
			// 
			// m_treeVProdutos
			// 
			this.m_treeVProdutos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_treeVProdutos.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_treeVProdutos.ImageIndex = -1;
			this.m_treeVProdutos.Location = new System.Drawing.Point(8, 15);
			this.m_treeVProdutos.Name = "m_treeVProdutos";
			this.m_treeVProdutos.SelectedImageIndex = -1;
			this.m_treeVProdutos.Size = new System.Drawing.Size(328, 188);
			this.m_treeVProdutos.TabIndex = 0;
			this.m_treeVProdutos.DoubleClick += new System.EventHandler(this.m_treeVProdutos_DoubleClick);
			// 
			// m_chbxMostrar
			// 
			this.m_chbxMostrar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_chbxMostrar.Location = new System.Drawing.Point(8, 205);
			this.m_chbxMostrar.Name = "m_chbxMostrar";
			this.m_chbxMostrar.Size = new System.Drawing.Size(329, 19);
			this.m_chbxMostrar.TabIndex = 2;
			this.m_chbxMostrar.Text = "Mostrar apenas os produtos sem classificação tarifária";
			this.m_chbxMostrar.CheckedChanged += new System.EventHandler(this.m_chbxMostrar_CheckedChanged);
			// 
			// m_btProdutosGeral
			// 
			this.m_btProdutosGeral.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.m_btProdutosGeral.BackColor = System.Drawing.SystemColors.Control;
			this.m_btProdutosGeral.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btProdutosGeral.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btProdutosGeral.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btProdutosGeral.Image = ((System.Drawing.Image)(resources.GetObject("m_btProdutosGeral.Image")));
			this.m_btProdutosGeral.Location = new System.Drawing.Point(153, 239);
			this.m_btProdutosGeral.Name = "m_btProdutosGeral";
			this.m_btProdutosGeral.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btProdutosGeral.Size = new System.Drawing.Size(57, 25);
			this.m_btProdutosGeral.TabIndex = 33;
			this.m_ttVinculacao.SetToolTip(this.m_btProdutosGeral, "Vincular NCM/NALADI");
			this.m_btProdutosGeral.Click += new System.EventHandler(this.m_btProdutosGeral_Click);
			// 
			// m_btOk
			// 
			this.m_btOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(89, 239);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 32;
			this.m_ttVinculacao.SetToolTip(this.m_btOk, "Confirmar");
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// btTrocarCor
			// 
			this.btTrocarCor.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.btTrocarCor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btTrocarCor.Location = new System.Drawing.Point(4, 10);
			this.btTrocarCor.Name = "btTrocarCor";
			this.btTrocarCor.Size = new System.Drawing.Size(4, 4);
			this.btTrocarCor.TabIndex = 31;
			this.m_ttVinculacao.SetToolTip(this.btTrocarCor, "Cor");
			this.btTrocarCor.Click += new System.EventHandler(this.m_btTrocarCor_Click);
			// 
			// m_ttVinculacao
			// 
			this.m_ttVinculacao.AutomaticDelay = 100;
			this.m_ttVinculacao.AutoPopDelay = 5000;
			this.m_ttVinculacao.InitialDelay = 100;
			this.m_ttVinculacao.ReshowDelay = 20;
			// 
			// frmFProdutosVinculacao
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(366, 272);
			this.Controls.Add(this.m_gbFrame);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFProdutosVinculacao";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Código de Classificação Tarifária";
			this.Load += new System.EventHandler(this.frmFProdutosVinculacao_Load);
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
							if ((this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.TreeView") &&
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

		#region Eventos
		#region Cor
		private void m_btTrocarCor_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.trocaCor();
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				this.mostraCor();
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Load
		private void frmFProdutosVinculacao_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.mostraCor();
				OnCallCarregaDadosInterface();
				m_bMostrarSemClassificacao = m_chbxMostrar.Checked;

			}
			catch (Exception err)
			{
				Object erro = err;
			}
		}
		#endregion
		#region Check Box Checked Changed
		private void m_chbxMostrar_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
				m_bMostrarSemClassificacao = m_chbxMostrar.Checked;
				OnCallRefreshInterface();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Produtos Geral
		private void m_btProdutosGeral_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				OnCallProdutosGeral();
				OnCallRefreshInterface();
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Produtos Double Click
		private void m_treeVProdutos_DoubleClick(object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if ((m_treeVProdutos.SelectedNode != null) && (m_treeVProdutos.SelectedNode.Text.Length > 5))
				{
					System.Windows.Forms.TreeNode tnProduto = m_treeVProdutos.SelectedNode;
					if (m_treeVProdutos.SelectedNode.Text.Substring(0,3) == "NCM")
					{
						OnCallSetaNcm(ref tnProduto);
						OnCallRefreshInterface();
					}
					else if (m_treeVProdutos.SelectedNode.Text.Substring(0,6) == "NALADI")
					{
						OnCallSetaNaladi(ref tnProduto);
						OnCallRefreshInterface();
					}
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		
		}
		#endregion
		#region Ok
		private void m_btOk_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				m_bModificado = true;
				OnCallSalvaDadosBD();
				this.Close();
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
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
		#endregion
	}
}
