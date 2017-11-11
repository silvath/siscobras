using System;

namespace mdlClassificacao
{
	/// <summary>
	/// Summary description for clsNaladi.
	/// </summary>
	public class clsNaladi : clsClassificao
	{
		#region Atributos
		private string m_strNaladi = "";

		private mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi m_typDatSetTbProdutosNaladi = null;
		#endregion

		#region Construtores & Destrutores
		public clsNaladi(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel, int Exportador, int Produto, ref System.Windows.Forms.ImageList ilBandeiras): base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, Exportador, Produto, ref ilBandeiras)
		{
			carregaTypDatSet();
			carregaDadosBD();
		}
		public clsNaladi(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel, int Exportador, int Produto, ref mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetTbProdutos, ref mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi typDatSetTbProdutosNaladi, bool bNaoGravarTabela, ref System.Windows.Forms.ImageList ilBandeiras): base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, Exportador, Produto, ref typDatSetTbProdutos, bNaoGravarTabela, ref ilBandeiras)
		{
			m_typDatSetTbProdutosNaladi = (mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi)typDatSetTbProdutosNaladi.Copy();
			carregaTypDatSet();
			carregaDadosBD();
		}
		#endregion

		#region Cadastra Classificacao
		protected override void cadastraClassificacao()
		{
			try
			{
				bool bModificado;
				m_clsProdutosGeral = new mdlProdutosGeral.clsProdutos(ref m_cls_ter_tratadorErro, ref m_cls_dba_ConnectionDB, m_strEnderecoExecutavel, m_nIdExportador, 1, ref m_ilBandeiras, ref m_typDatSetTbProdutosNaladi);
				m_clsProdutosGeral.ShowDialogClassificacoesTarifariasCadastroNALADI(out m_strNaladi, out m_strDenominacao, out bModificado);
				m_clsProdutosGeral = null;
				if (bModificado)
                    salvaDadosInterfaceCadastroClassificacao();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Edita Classificacao
		protected override void editaClassificacao()
		{
			try
			{
				bool bModificado;
				string strClassificacao, strDenominacaoEditada;
				m_clsProdutosGeral = new mdlProdutosGeral.clsProdutos(ref m_cls_ter_tratadorErro, ref m_cls_dba_ConnectionDB, m_strEnderecoExecutavel, m_nIdExportador, 1, ref m_ilBandeiras, ref m_typDatSetTbProdutosNaladi);
				m_clsProdutosGeral.ShowDialogClassificacoesTarifariasEdicaoNALADI(m_strNaladi, m_strDenominacao,out strClassificacao, out strDenominacaoEditada, out bModificado);
				m_clsProdutosGeral = null;
				if (bModificado)
                    salvaDadosInterfaceEdicaoClassificacao(strClassificacao, strDenominacaoEditada);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Remove Classificacao
		protected override void removeClassificacaoEspecifico(ref mdlComponentesGraficos.ListView lvClassificacao)
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwRowTbProdutos;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi.tbProdutosNaladiRow dtrwRowTbProdutosNaladi;
				string strClassificacao = "";
				if (lvClassificacao.SelectedItems.Count > 0)
				{
					System.Windows.Forms.DialogResult drApaga = mdlMensagens.clsMensagens.ShowQuestion("Classificação",mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlClassificacao_clsNaladi_ApagarNaladi).Replace("TAG",lvClassificacao.SelectedItems.Count.ToString()),System.Windows.Forms.MessageBoxButtons.YesNo);
					//System.Windows.Forms.DialogResult drApaga = System.Windows.Forms.MessageBox.Show("Você tem certeza que deseja excluir " + lvClassificacao.SelectedItems.Count.ToString() + " classificação(ões)?","Classificação",System.Windows.Forms.MessageBoxButtons.YesNo);
					while (lvClassificacao.SelectedItems.Count > 0 && drApaga == System.Windows.Forms.DialogResult.Yes)
					{
						strClassificacao = lvClassificacao.SelectedItems[0].Text;
						for (int nCount = 0; nCount < m_typDatSetTbProdutos.tbProdutos.Rows.Count; nCount++)
						{
							dtrwRowTbProdutos = (mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow)m_typDatSetTbProdutos.tbProdutos.Rows[nCount];
							if ((!dtrwRowTbProdutos.IsstrNaladiNull()) && (dtrwRowTbProdutos.strNaladi == strClassificacao))
							{
								dtrwRowTbProdutos.strNaladi = "";
							}							
						}
						lvClassificacao.SelectedItems[0].Selected = false;
						dtrwRowTbProdutosNaladi = m_typDatSetTbProdutosNaladi.tbProdutosNaladi.FindBynIdExportadorstrNaladi(m_nIdExportador,strClassificacao);
						if (dtrwRowTbProdutosNaladi != null)
							dtrwRowTbProdutosNaladi.Delete();
					}
					if (drApaga == System.Windows.Forms.DialogResult.Yes)
					{
						m_strNaladi = "";
						m_strDenominacao = "";					
					}
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Carregamento dos Dados
		#region Banco de Dados
		private void carregaTypDatSet()
		{
			try
			{
				if (m_typDatSetTbProdutosNaladi == null)
				{
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
				
					arlCondicaoCampo.Add("nIdExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_nIdExportador);

					m_typDatSetTbProdutosNaladi = m_cls_dba_ConnectionDB.GetTbProdutosNaladi(arlCondicaoCampo, arlCondicaoComparador, arlCondicaoValor, null, null);
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected override void carregaDadosBDEspecificos()
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwTbProdutos;
				dtrwTbProdutos = m_typDatSetTbProdutos.tbProdutos.FindByidExportadoridProduto(m_nIdExportador,m_nIdProduto);
				if (dtrwTbProdutos != null)
				{
					if (!dtrwTbProdutos.IsstrNaladiNull())
						m_strNaladi = dtrwTbProdutos.strNaladi;
					else
						m_strNaladi = "";
				}
				else
				{
					m_strNaladi = "";
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected override void carregaDadosBDClassificacaoEspecifico(ref mdlComponentesGraficos.ListView lvClassificacao)
		{
			try
			{
				if (lvClassificacao.SelectedItems.Count > 0)
					m_strNaladi = lvClassificacao.SelectedItems[0].Text;
				// Cria a variável para conter o registro corrente
				mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi.tbProdutosNaladiRow dtrwRowTbProdutosNaladi = null;
				dtrwRowTbProdutosNaladi = m_typDatSetTbProdutosNaladi.tbProdutosNaladi.FindBynIdExportadorstrNaladi(m_nIdExportador, m_strNaladi);
				if (dtrwRowTbProdutosNaladi != null )
				{
					if (!dtrwRowTbProdutosNaladi.IsmstrDenominacaoNull())
					{
						m_strDenominacao = dtrwRowTbProdutosNaladi.mstrDenominacao;
					}
				}
				else
				{
					m_strDenominacao = "";
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Interface
		protected override void carregaDadosInterfaceEspecifico(ref mdlComponentesGraficos.ListView lvClassificacao, ref System.Windows.Forms.Form formClassificacao)
		{
			try
			{
				formClassificacao.Text = "Classificação NALADI";
				// List View Item
				System.Windows.Forms.ListViewItem lvItemClassificacao;
				// Limpa os Items da List View
				lvClassificacao.Items.Clear();
				mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi.tbProdutosNaladiRow dtrwRowTbProdutosNaladi;
				// Preenche os itens da List View
				for (int nCont = 0 ; nCont < m_typDatSetTbProdutosNaladi.tbProdutosNaladi.Rows.Count ; nCont++)
				{
					dtrwRowTbProdutosNaladi = (mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi.tbProdutosNaladiRow)m_typDatSetTbProdutosNaladi.tbProdutosNaladi.Rows[nCont];
					if (dtrwRowTbProdutosNaladi.RowState != System.Data.DataRowState.Deleted)
					{
						lvItemClassificacao = lvClassificacao.Items.Add(dtrwRowTbProdutosNaladi.strNaladi);
						lvItemClassificacao.Tag = dtrwRowTbProdutosNaladi.nIdExportador;
						if (lvItemClassificacao.Text == m_strNaladi)
						{
							lvItemClassificacao.Selected = true;
							m_strDenominacao = dtrwRowTbProdutosNaladi.mstrDenominacao;
						}
					}
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected override void carregaDadosClassificacaoInterfaceEspecifico(ref System.Windows.Forms.RichTextBox rtbDadosClassificacao)
		{
			try
			{
				#region Cria Variáveis RichTextBox
				// Limpa os Items da Rich Text Box
				rtbDadosClassificacao.Clear();
				#endregion
				
				#region Adicionando Items à Rich Text Box
				#region Denominação
				rtbDadosClassificacao.Font = new System.Drawing.Font(rtbDadosClassificacao.Font, System.Drawing.FontStyle.Bold);
				rtbDadosClassificacao.SelectionColor = System.Drawing.Color.Black;
				rtbDadosClassificacao.AppendText(m_strDenominacao);
				#endregion
//				#region Denominação
//				lvItemDadosClassificacao = lvDadosClassificacao.Items.Add("Denominação: ");
//				lvItemDadosClassificacao.ForeColor = System.Drawing.Color.Red;
//				lvItemDadosClassificacao.UseItemStyleForSubItems = false;
//				lvItemDadosClassificacao.Font = new System.Drawing.Font(lvItemDadosClassificacao.Font, System.Drawing.FontStyle.Bold);
//				if (m_strDenominacao.Length > 15)
//				{
//					lvItemDadosClassificacao.SubItems.Add(strDenominacaoSemNovaLinha.Substring(0,25));
//					lvItemDadosClassificacao.SubItems[1].Font = new System.Drawing.Font(lvItemDadosClassificacao.Font, System.Drawing.FontStyle.Bold);
//					lvItemDadosClassificacao = null;
//					for (int nCount = 25; nCount < strDenominacaoSemNovaLinha.Length; nCount += 25)
//					{
//						lvItemDadosClassificacao = lvDadosClassificacao.Items.Add("");
//						lvItemDadosClassificacao.ForeColor = System.Drawing.Color.Red;
//						lvItemDadosClassificacao.UseItemStyleForSubItems = false;
//						if ((nCount + 25) < strDenominacaoSemNovaLinha.Length)
//                            lvItemDadosClassificacao.SubItems.Add(strDenominacaoSemNovaLinha.Substring(nCount,25));
//						else
//							lvItemDadosClassificacao.SubItems.Add(strDenominacaoSemNovaLinha.Substring(nCount,(strDenominacaoSemNovaLinha.Length - nCount - 1)));
//						lvItemDadosClassificacao.SubItems[1].Font = new System.Drawing.Font(lvItemDadosClassificacao.Font, System.Drawing.FontStyle.Bold);
//						lvItemDadosClassificacao = null;
//					}
//				}
//				else
//				{
//					lvItemDadosClassificacao.SubItems.Add(strDenominacaoSemNovaLinha);
//					lvItemDadosClassificacao.SubItems[1].Font = new System.Drawing.Font(lvItemDadosClassificacao.Font, System.Drawing.FontStyle.Bold);
//					lvItemDadosClassificacao = null;
//				}
//				#endregion
				#endregion
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#endregion
		#region Salvamento dos Dados
		#region Interface
		protected override void salvaDadosInterfaceCadastroClassificacao()
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi.tbProdutosNaladiRow dtrwTbProdutosNaladi;
				dtrwTbProdutosNaladi = m_typDatSetTbProdutosNaladi.tbProdutosNaladi.NewtbProdutosNaladiRow();
				dtrwTbProdutosNaladi.nIdExportador = m_nIdExportador;
				dtrwTbProdutosNaladi.strNaladi = m_strNaladi;
				dtrwTbProdutosNaladi.mstrDenominacao = m_strDenominacao;
				m_typDatSetTbProdutosNaladi.tbProdutosNaladi.AddtbProdutosNaladiRow(dtrwTbProdutosNaladi);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected override void salvaDadosInterfaceEdicaoClassificacao(string strClassificacao, string strDenominacao)
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi.tbProdutosNaladiRow dtrwTbProdutosNaladi;
				dtrwTbProdutosNaladi = m_typDatSetTbProdutosNaladi.tbProdutosNaladi.FindBynIdExportadorstrNaladi(m_nIdExportador,m_strNaladi);
				if (dtrwTbProdutosNaladi != null)
				{
					dtrwTbProdutosNaladi.strNaladi = strClassificacao;
					dtrwTbProdutosNaladi.mstrDenominacao = strDenominacao;					
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Banco de Dados
		protected override void salvaDadosBDEspecifico()
		{
			try
			{
				if (m_bModificado)
				{
					// Atualizando Tabela Produtos
					mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwRowProdutos;
					dtrwRowProdutos = m_typDatSetTbProdutos.tbProdutos.FindByidExportadoridProduto(m_nIdExportador,m_nIdProduto);
					if (dtrwRowProdutos != null)
					{
						dtrwRowProdutos.strNaladi = m_strNaladi;
						if (!m_bNaoGravarTabelas)
							m_cls_dba_ConnectionDB.SetTbProdutos(m_typDatSetTbProdutos);
					}
					if (m_typDatSetTbProdutosNaladi != null && !m_bNaoGravarTabelas)
						m_cls_dba_ConnectionDB.SetTbProdutosNaladi(m_typDatSetTbProdutosNaladi);
				}
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
				
		}
		#endregion
		#endregion

		#region Retorna Valores
		public override void retornaValores(out string strClassificacao)
		{
			strClassificacao = m_strNaladi;
		}
		public void retornaTypDatSetsTbs(out mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetTbProdutos, out mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi typDatSetTbProdutosNaladi)
		{
			retornaTypDatSetTbProdutos(out typDatSetTbProdutos);
			typDatSetTbProdutosNaladi = m_typDatSetTbProdutosNaladi;
		}
		#endregion
	}
}
