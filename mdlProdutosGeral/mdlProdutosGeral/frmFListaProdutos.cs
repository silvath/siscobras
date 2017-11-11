using System;
using System.Collections;

namespace mdlProdutosGeral
{
	/// <summary>
	/// Summary description for frmFListaProdutos.
	/// </summary>
	internal class frmFListaProdutos : mdlComponentesGraficos.FormFlutuante
	{
		#region Atributos
		// ***************************************************************************************************
		// Atributos
		// ***************************************************************************************************
		private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
		private string m_strEnderecoExecutavel = "";
		public bool m_bModificado =	false;

		private int m_nIdExportador = -1;
		private int m_nIdIdioma = -1;

		private string m_strDescricao = "";
		private string m_strIdioma = "";

		private mdlDataBaseAccess.Tabelas.XsdTbProdutos m_typDatSetTbProdutos = null;
		private mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas m_typDatSetTbProdutosIdiomas = null;
		private System.Windows.Forms.GroupBox m_gbFrame;
		private System.Windows.Forms.GroupBox m_gbFields;
		private System.Windows.Forms.Button m_btOk;
		private System.Windows.Forms.Button m_btCancelar;
		private System.Windows.Forms.ToolTip m_ttProdutos;
		private mdlComponentesGraficos.ListView m_lvProdutos;
		private System.Windows.Forms.ColumnHeader m_chFirst;
		private System.ComponentModel.IContainer components;
		#endregion

		#region Construtores & Destrutores
		public frmFListaProdutos(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, string enderecoExecutavel, int idExportador, int idIdioma, ref mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetTbProdutos, ref mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas typDatSetTbProdutosIdiomas)
		{
			InitializeComponent();

			m_cls_ter_tratadorErro = tratadorErro;
			m_strEnderecoExecutavel = enderecoExecutavel;
			m_nIdExportador = idExportador;
			m_nIdIdioma = idIdioma;
			m_typDatSetTbProdutos = (mdlDataBaseAccess.Tabelas.XsdTbProdutos)typDatSetTbProdutos.Copy();
			m_typDatSetTbProdutosIdiomas = (mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas)typDatSetTbProdutosIdiomas.Copy();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFListaProdutos));
			this.m_gbFrame = new System.Windows.Forms.GroupBox();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbFields = new System.Windows.Forms.GroupBox();
			this.m_lvProdutos = new mdlComponentesGraficos.ListView();
			this.m_chFirst = new System.Windows.Forms.ColumnHeader();
			this.m_ttProdutos = new System.Windows.Forms.ToolTip(this.components);
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
			this.m_gbFrame.Size = new System.Drawing.Size(372, 413);
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
			this.m_btOk.Location = new System.Drawing.Point(126, 382);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 7;
			this.m_ttProdutos.SetToolTip(this.m_btOk, "Confirmar");
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
			this.m_btCancelar.Location = new System.Drawing.Point(190, 382);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 8;
			this.m_ttProdutos.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbFields
			// 
			this.m_gbFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFields.Controls.Add(this.m_lvProdutos);
			this.m_gbFields.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbFields.Location = new System.Drawing.Point(8, 8);
			this.m_gbFields.Name = "m_gbFields";
			this.m_gbFields.Size = new System.Drawing.Size(355, 369);
			this.m_gbFields.TabIndex = 0;
			this.m_gbFields.TabStop = false;
			// 
			// m_lvProdutos
			// 
			this.m_lvProdutos.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.m_lvProdutos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lvProdutos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						   this.m_chFirst});
			this.m_lvProdutos.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lvProdutos.FullRowSelect = true;
			this.m_lvProdutos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.m_lvProdutos.HideSelection = false;
			this.m_lvProdutos.Location = new System.Drawing.Point(8, 22);
			this.m_lvProdutos.MultiSelect = false;
			this.m_lvProdutos.Name = "m_lvProdutos";
			this.m_lvProdutos.Size = new System.Drawing.Size(339, 339);
			this.m_lvProdutos.TabIndex = 1;
			this.m_ttProdutos.SetToolTip(this.m_lvProdutos, "Selecione um produto para copiar sua descrição");
			this.m_lvProdutos.View = System.Windows.Forms.View.Details;
			// 
			// m_chFirst
			// 
			this.m_chFirst.Text = "Descrição";
			this.m_chFirst.Width = 325;
			// 
			// m_ttProdutos
			// 
			this.m_ttProdutos.AutomaticDelay = 100;
			this.m_ttProdutos.AutoPopDelay = 5000;
			this.m_ttProdutos.InitialDelay = 100;
			this.m_ttProdutos.ReshowDelay = 20;
			// 
			// frmFListaProdutos
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(376, 415);
			this.Controls.Add(this.m_gbFrame);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFListaProdutos";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Produtos";
			this.Load += new System.EventHandler(this.frmFListaProdutos_Load);
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
								"System.Windows.Forms.TextBox") &&
								(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.TextBox") &&
								(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.ListView"))
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

		#region RefreshLista
		private void refreshProdutos()
		{
			try
			{
				System.Windows.Forms.ListViewItem lvItemProduto = null;
				m_lvProdutos.Items.Clear();
				System.Data.DataRow[] dtRwColecao = m_typDatSetTbProdutos.tbProdutos.Select(null,"mstrDescricao");
				foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwTbProdutos in dtRwColecao)
				{
					lvItemProduto = m_lvProdutos.Items.Add(dtrwTbProdutos.mstrDescricao);
					lvItemProduto.Tag = dtrwTbProdutos.idProduto;
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region CopiaDescricaoProduto
		private void copiaDescricaoProdutoSelecionado()
		{
			try
			{
				if (m_lvProdutos.SelectedItems.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwTbProdutos = m_typDatSetTbProdutos.tbProdutos.FindByidExportadoridProduto(m_nIdExportador,(int)m_lvProdutos.SelectedItems[0].Tag);
					if (dtrwTbProdutos != null)
					{
						m_strDescricao = (dtrwTbProdutos.IsmstrDescricaoNull() ? "" : dtrwTbProdutos.mstrDescricao);
						mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas.tbProdutosIdiomasRow dtrwTbProdutosIdiomas = m_typDatSetTbProdutosIdiomas.tbProdutosIdiomas.FindByidExportadoridIdiomaidProduto(m_nIdExportador, m_nIdIdioma, (int)m_lvProdutos.SelectedItems[0].Tag);
						if (dtrwTbProdutosIdiomas != null)
						{
							m_strIdioma = (dtrwTbProdutosIdiomas.IsstrDescricaoNull() ? "" : dtrwTbProdutosIdiomas.strDescricao);
						}
						else
						{
							m_strIdioma = "";
						}
					}
					else
					{
						m_strDescricao = "";
						m_strIdioma = "";
					}
				}
				else
				{
					m_strDescricao = "";
					m_strIdioma = "";
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region RetornaValores
		public void retornaValores(out string strDescricao, out string strIdioma)
		{
			strDescricao = m_strDescricao;
			strIdioma = m_strIdioma;
		}
		#endregion

		#region Eventos
		#region Load
		private void frmFListaProdutos_Load(object sender, System.EventArgs e)
		{
			this.mostraCor();
			refreshProdutos();
		}
		#endregion
		#region Cancelar
		private void m_btCancelar_Click(object sender, System.EventArgs e)
		{
			this.m_bModificado = false;
			this.Close();
		}
		#endregion
		#region Ok
		private void m_btOk_Click(object sender, System.EventArgs e)
		{
			this.m_bModificado = true;
			copiaDescricaoProdutoSelecionado();
			this.Close();
		}
		#endregion
		#endregion
	}
}
