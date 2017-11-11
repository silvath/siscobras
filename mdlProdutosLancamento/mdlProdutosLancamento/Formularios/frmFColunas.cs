using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlProdutosLancamento
{
	/// <summary>
	/// Summary description for fmFColunas.
	/// </summary>
	public class frmFColunas : mdlComponentesGraficos.FormFlutuante
	{
		#region Atributos
		// ***************************************************************************************************
		// Atributos
		// ***************************************************************************************************
		    private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro; 
			private string m_strEnderecoExecutavel = "";
            private System.Drawing.Color m_clrCor;

			private System.Windows.Forms.GroupBox m_gbGeral;
			public System.Windows.Forms.Button m_btOk;
			public System.Windows.Forms.Button m_btCancelar;
			private System.ComponentModel.IContainer components;
			private mdlComponentesGraficos.ListView m_lvColunas;
			private mdlComponentesGraficos.ListView m_lvColunasDisponiveis;
			private System.Windows.Forms.GroupBox m_gbColunasDisponiveis;
			private System.Windows.Forms.GroupBox m_gbColunasAtuais;
			private System.Windows.Forms.ToolTip m_ttDica;

            // Colunas
			protected clsManipuladorColunas m_cls_mac_Colunas;

			private int m_nIdIdioma;
		    private string m_strIdioma;
			private System.Windows.Forms.ContextMenu m_cmColunasAtuais;
			private System.Windows.Forms.MenuItem m_miColunaAtualExcluir;
			private System.Windows.Forms.MenuItem m_miColunasAtuaisMoverEsquerda;
			private System.Windows.Forms.MenuItem m_miColunasAtuaisMoverDireita;
       
			public bool m_bModificado = true;
		    private int m_nColumnIndex = -1;
		// ***************************************************************************************************
		#endregion
		#region Construtores e Destrutores
		public frmFColunas(ref mdlTratamentoErro.clsTratamentoErro tratadorErro,string strEnderecoExecutavel, System.Drawing.Color clrCor,int nIdIdioma,string strIdioma,ref clsManipuladorColunas cls_mac_Colunas)
			{
				m_cls_ter_tratadorErro = tratadorErro;
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				m_clrCor = clrCor;
				m_nIdIdioma = nIdIdioma;
				m_strIdioma = strIdioma;
				m_cls_mac_Colunas = cls_mac_Colunas.Clone();
				InitializeComponent();

			    // Cor
				this.BackColor = m_clrCor;
				for (int nCont = 0 ;nCont < this.Controls.Count; nCont++)
				{
					this.Controls[nCont].BackColor = this.BackColor;
					for (int nCont2 = 0 ;nCont2 < this.Controls[nCont].Controls.Count; nCont2++)
					{
						if ((this.Controls[nCont].Controls[nCont2].GetType().ToString() != "mdlComponentesGraficos.ListView") && (this.Controls[nCont].Controls[nCont2].GetType().ToString() != "System.Windows.Forms.TreeView"))
							this.Controls[nCont].Controls[nCont2].BackColor = this.BackColor;

						for (int nCont3 = 0 ;nCont3 < this.Controls[nCont].Controls[nCont2].Controls.Count; nCont3++)
						{
							if ((this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "mdlComponentesGraficos.ListView") && (this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "System.Windows.Forms.TreeView"))
								this.Controls[nCont].Controls[nCont2].Controls[nCont3].BackColor = this.BackColor;
						}
					}
				}
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFColunas));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_gbColunasAtuais = new System.Windows.Forms.GroupBox();
			this.m_lvColunas = new mdlComponentesGraficos.ListView();
			this.m_gbColunasDisponiveis = new System.Windows.Forms.GroupBox();
			this.m_lvColunasDisponiveis = new mdlComponentesGraficos.ListView();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_ttDica = new System.Windows.Forms.ToolTip(this.components);
			this.m_cmColunasAtuais = new System.Windows.Forms.ContextMenu();
			this.m_miColunasAtuaisMoverEsquerda = new System.Windows.Forms.MenuItem();
			this.m_miColunasAtuaisMoverDireita = new System.Windows.Forms.MenuItem();
			this.m_miColunaAtualExcluir = new System.Windows.Forms.MenuItem();
			this.m_gbGeral.SuspendLayout();
			this.m_gbColunasAtuais.SuspendLayout();
			this.m_gbColunasDisponiveis.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Controls.Add(this.m_gbColunasAtuais);
			this.m_gbGeral.Controls.Add(this.m_gbColunasDisponiveis);
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Location = new System.Drawing.Point(6, 2);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(714, 246);
			this.m_gbGeral.TabIndex = 0;
			this.m_gbGeral.TabStop = false;
			// 
			// m_gbColunasAtuais
			// 
			this.m_gbColunasAtuais.Controls.Add(this.m_lvColunas);
			this.m_gbColunasAtuais.Location = new System.Drawing.Point(8, 9);
			this.m_gbColunasAtuais.Name = "m_gbColunasAtuais";
			this.m_gbColunasAtuais.Size = new System.Drawing.Size(696, 55);
			this.m_gbColunasAtuais.TabIndex = 16;
			this.m_gbColunasAtuais.TabStop = false;
			this.m_gbColunasAtuais.Text = "Ordenação Atual das Colunas";
			// 
			// m_lvColunas
			// 
			this.m_lvColunas.AllowDrop = true;
			this.m_lvColunas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lvColunas.Location = new System.Drawing.Point(9, 20);
			this.m_lvColunas.Name = "m_lvColunas";
			this.m_lvColunas.Size = new System.Drawing.Size(680, 20);
			this.m_lvColunas.TabIndex = 14;
			this.m_lvColunas.View = System.Windows.Forms.View.Details;
			this.m_lvColunas.DragOver += new System.Windows.Forms.DragEventHandler(this.m_lvColunas_DragOver);
			this.m_lvColunas.DragDrop += new System.Windows.Forms.DragEventHandler(this.m_lvColunas_DragDrop);
			this.m_lvColunas.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.m_lvColunas_ColumnClick);
			// 
			// m_gbColunasDisponiveis
			// 
			this.m_gbColunasDisponiveis.Controls.Add(this.m_lvColunasDisponiveis);
			this.m_gbColunasDisponiveis.Location = new System.Drawing.Point(8, 72);
			this.m_gbColunasDisponiveis.Name = "m_gbColunasDisponiveis";
			this.m_gbColunasDisponiveis.Size = new System.Drawing.Size(696, 136);
			this.m_gbColunasDisponiveis.TabIndex = 15;
			this.m_gbColunasDisponiveis.TabStop = false;
			this.m_gbColunasDisponiveis.Text = "Colunas Disponíveis";
			// 
			// m_lvColunasDisponiveis
			// 
			this.m_lvColunasDisponiveis.AllowDrop = true;
			this.m_lvColunasDisponiveis.Location = new System.Drawing.Point(8, 16);
			this.m_lvColunasDisponiveis.Name = "m_lvColunasDisponiveis";
			this.m_lvColunasDisponiveis.Size = new System.Drawing.Size(680, 112);
			this.m_lvColunasDisponiveis.TabIndex = 0;
			this.m_lvColunasDisponiveis.View = System.Windows.Forms.View.List;
			this.m_lvColunasDisponiveis.DoubleClick += new System.EventHandler(this.m_lvColunasDisponiveis_DoubleClick);
			this.m_lvColunasDisponiveis.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.m_lvColunasDisponiveis_ItemDrag);
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(296, 213);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 12;
			this.m_ttDica.SetToolTip(this.m_btOk, "Confirmar");
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(360, 213);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 13;
			this.m_ttDica.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_ttDica
			// 
			this.m_ttDica.AutomaticDelay = 100;
			this.m_ttDica.AutoPopDelay = 5000;
			this.m_ttDica.InitialDelay = 100;
			this.m_ttDica.ReshowDelay = 20;
			// 
			// m_cmColunasAtuais
			// 
			this.m_cmColunasAtuais.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							  this.m_miColunasAtuaisMoverEsquerda,
																							  this.m_miColunasAtuaisMoverDireita,
																							  this.m_miColunaAtualExcluir});
			// 
			// m_miColunasAtuaisMoverEsquerda
			// 
			this.m_miColunasAtuaisMoverEsquerda.Index = 0;
			this.m_miColunasAtuaisMoverEsquerda.Text = "Mover  <=";
			this.m_miColunasAtuaisMoverEsquerda.Click += new System.EventHandler(this.m_miColunasAtuaisMoverEsquerda_Click);
			// 
			// m_miColunasAtuaisMoverDireita
			// 
			this.m_miColunasAtuaisMoverDireita.Index = 1;
			this.m_miColunasAtuaisMoverDireita.Text = "Mover  =>";
			this.m_miColunasAtuaisMoverDireita.Click += new System.EventHandler(this.m_miColunasAtuaisMoverDireita_Click);
			// 
			// m_miColunaAtualExcluir
			// 
			this.m_miColunaAtualExcluir.Index = 2;
			this.m_miColunaAtualExcluir.Text = "Excluir";
			this.m_miColunaAtualExcluir.Click += new System.EventHandler(this.m_miColunaAtualExcluir_Click);
			// 
			// frmFColunas
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(730, 254);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmFColunas";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Ordenação das Colunas";
			this.Load += new System.EventHandler(this.frmFColunas_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbColunasAtuais.ResumeLayout(false);
			this.m_gbColunasDisponiveis.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFColunas_Load(object sender, System.EventArgs e)
				{
					RefreshColunas();
					RefreshColunasDisponiveis();
					vBalloonTip();
				}
			#endregion
			#region Botoes
				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					vReadjustColumnsSize();
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

		#region Refreshs
			private void RefreshColunas()
			{
				m_lvColunas.Columns.Clear();
				for(int i = 0; i < m_cls_mac_Colunas.CountValidas;i++)
				{
					clsColuna objColuna = m_cls_mac_Colunas.GetColunaValidaIndex(i + 1);
					if (objColuna != null)
					{
						System.Windows.Forms.ColumnHeader clhdColuna = m_cls_mac_Colunas.clhdColuna(objColuna);
						if (clhdColuna != null)
							this.m_lvColunas.Columns.Add(clhdColuna);
					}
				}
			}

			private void RefreshColunasDisponiveis()
			{
				m_lvColunasDisponiveis.Items.Clear();
				for(int i = 0; i < m_cls_mac_Colunas.CountInvalidas;i++)
				{
					clsColuna objColuna = m_cls_mac_Colunas.GetColunaInvalida(i);
					if (objColuna != null)
					{
						System.Windows.Forms.ColumnHeader clhdColuna = m_cls_mac_Colunas.clhdColuna(objColuna);
						if ((clhdColuna != null) && (clhdColuna.Text != "Português"))
							this.m_lvColunasDisponiveis.Items.Add(clhdColuna.Text);
					}
				}
			} 
		#endregion
		#region Colunas
			private void GetColumnAtPoint(System.Drawing.Point ptPonto,out int nColumnIndex,out bool bMoreCloseToLeft)
			{
                int nRetorno = -1;
				bool bLeft = false;
				if (ptPonto.Y <= m_lvColunas.Font.Height)
				{
					int nContWidth = 0;
					for (int nCont = 0;nCont < m_lvColunas.Columns.Count;nCont++)
					{
						if ((nContWidth <= ptPonto.X) && (ptPonto.X <= (nContWidth + m_lvColunas.Columns[nCont].Width) ))
						{
							nRetorno = nCont;
							if ((ptPonto.X - nContWidth) > ((nContWidth + m_lvColunas.Columns[nCont].Width) - ptPonto.X ) )
								bLeft = false;
							else
								bLeft = true;
							break;
						}
						nContWidth += m_lvColunas.Columns[nCont].Width;
					}
				}
				nColumnIndex = nRetorno;
				bMoreCloseToLeft = bLeft;
			}

			private void vReadjustColumnsSize()
			{
				foreach(System.Windows.Forms.ColumnHeader clhdColuna in m_lvColunas.Columns)
				{
					m_cls_mac_Colunas.SetTamanho(clhdColuna.Text,clhdColuna.Width);
				}
			}
		#endregion
		#region ContextMenu
			private void m_miColunasAtuaisMoverEsquerda_Click(object sender, System.EventArgs e)
			{
				string strColuna = m_lvColunas.Columns[m_nColumnIndex].Text;
				m_cls_mac_Colunas.SetPosicao(strColuna,m_cls_mac_Colunas.GetPosicao(strColuna) - 1,true);
				RefreshColunas();
			}

			private void m_miColunasAtuaisMoverDireita_Click(object sender, System.EventArgs e)
			{
				string strColuna = m_lvColunas.Columns[m_nColumnIndex + 1].Text;
				m_cls_mac_Colunas.SetPosicao(strColuna,m_cls_mac_Colunas.GetPosicao(strColuna) - 1,true);
				RefreshColunas();
			}

			private void m_miColunaAtualExcluir_Click(object sender, System.EventArgs e)
			{
				string strColuna = m_lvColunas.Columns[m_nColumnIndex].Text;
				m_cls_mac_Colunas.SetPosicao(strColuna,0,true);
				RefreshColunas();
				RefreshColunasDisponiveis();
			}
		#endregion

		#region ListView Colunas
			private void m_lvColunas_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
			{
				if (e.Column > -1)
				{
					string strNomeColuna = m_lvColunas.Columns[e.Column].Text;

					// Excluir
					if ((strNomeColuna != clsLancamentoProdutos.TEXTO_COLUNA_ORDEM_LANCAMENTO) && (m_cls_mac_Colunas.GetReadOnly(strNomeColuna)) || (strNomeColuna == clsLancamentoProdutos.TEXTO_COLUNA_DESCRICAO) || (strNomeColuna == clsLancamentoProdutos.TEXTO_COLUNA_QUANTIDADE) || (strNomeColuna == clsLancamentoProdutos.TEXTO_COLUNA_PRECO_UNITARIO))
					{
						m_miColunaAtualExcluir.Enabled = false;
					}
					else
					{
						m_miColunaAtualExcluir.Enabled = true;
					}
					// Mover Direita 
					if (e.Column == (m_lvColunas.Columns.Count - 1) || ((m_cls_mac_Colunas.GetReadOnly(strNomeColuna) && (strNomeColuna != clsLancamentoProdutos.TEXTO_COLUNA_ORDEM_LANCAMENTO))))
					{
						m_miColunasAtuaisMoverDireita.Enabled = false;
					}
					else
					{
						m_miColunasAtuaisMoverDireita.Enabled = true;
					}

					// Mover Esquerda 
					if (e.Column == 0 )
					{
						m_miColunasAtuaisMoverEsquerda.Enabled = false;
					}
					else
					{
						m_miColunasAtuaisMoverEsquerda.Enabled = true;
					}
					m_nColumnIndex = e.Column;
					m_cmColunasAtuais.Show(m_lvColunas,m_lvColunas.PointToClient(System.Windows.Forms.Form.MousePosition));
				}else{
					m_nColumnIndex = -1;
				}
			}

			private void m_lvColunas_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
			{
				e.Effect = System.Windows.Forms.DragDropEffects.Move;			
			}

			private void m_lvColunas_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
			{
				int nColumnIndex;
				bool bMoreCloseToLeft;
				System.Windows.Forms.ListViewItem lviItem = null;

				// Pegando a coluna que o item foi dropado
				GetColumnAtPoint(m_lvColunas.PointToClient(new System.Drawing.Point(e.X,e.Y)),out nColumnIndex,out bMoreCloseToLeft);
				if (nColumnIndex != -1)
				{
					if (nColumnIndex == 0)
					{
						nColumnIndex++;
					}
					else
					{
						if (!bMoreCloseToLeft)
							nColumnIndex++;
					}
					lviItem = (System.Windows.Forms.ListViewItem)e.Data.GetData("System.Windows.Forms.ListViewItem"); 
					if (lviItem != null)
					{
						m_cls_mac_Colunas.SetPosicao(lviItem.Text,nColumnIndex + 1,true);
						RefreshColunas();
						RefreshColunasDisponiveis();
					}
				}else{
					if (m_lvColunas.Columns.Count == 0)
					{
						lviItem = (System.Windows.Forms.ListViewItem)e.Data.GetData("System.Windows.Forms.ListViewItem"); 
						if (lviItem != null)
						{
							m_cls_mac_Colunas.SetPosicao(lviItem.Text,1,true);
							RefreshColunas();
							RefreshColunasDisponiveis();
						}
					}
				}
			}
		#endregion
		#region ListView ColunasDisponiveis
			private void m_lvColunasDisponiveis_ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
			{
				m_lvColunasDisponiveis.DoDragDrop(e.Item,System.Windows.Forms.DragDropEffects.Move);
			}

			private void m_lvColunasDisponiveis_DoubleClick(object sender, System.EventArgs e)
			{
				if (m_lvColunasDisponiveis.SelectedItems.Count > 0)
				{
					m_cls_mac_Colunas.SetPosicao(m_lvColunasDisponiveis.SelectedItems[0].Text,m_lvColunas.Columns.Count + 1);
					RefreshColunas();
					RefreshColunasDisponiveis();
				} 
			}
		#endregion

		#region BalloonTip
			private void  vBalloonTip()
			{
				mdlManipuladorArquivo.clsManipuladorArquivoIni cls_iniFile = new mdlManipuladorArquivo.clsManipuladorArquivoIni(m_strEnderecoExecutavel + "sisco.ini");
				if (cls_iniFile.retornaValor(mdlConstantes.clsConstantes.SHOW_BALLOONTIP_SESSAO,mdlConstantes.clsConstantes.SHOW_BALLOONTIP_VARIAVEL,true))
				{
					mdlComponentesGraficos.MessageBalloon mb = new mdlComponentesGraficos.MessageBalloon();
					mb.Caption = mdlConstantes.clsConstantes.BALLONTIP_DEFAULT_CAPTION;
					mb.Content = mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.BALLOONTIP_mdlProdutosLancamento_frmFColunas_ComoOrdenarColunas).Replace("\\n",System.Environment.NewLine);
					mb.Icon = System.Drawing.SystemIcons.Information;
					mb.CloseOnMouseClick = true;
					mb.CloseOnDeactivate = true;
					mb.CloseOnKeyPress = true;
					mb.ShowBalloon((System.Windows.Forms.Control)m_lvColunas);
				}
			}
		#endregion

		#region Returns
			public void retornaValores(out clsManipuladorColunas cls_mac_Colunas)
			{
				cls_mac_Colunas = m_cls_mac_Colunas;
			}
		#endregion

	}
}
