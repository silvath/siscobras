using System;

namespace mdlClassificacao
{
	/// <summary>
	/// Summary description for clsNcm.
	/// </summary>
	public class clsNcm : clsClassificao
	{
		#region Atributos
		private string m_strNcm = "";

		private mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm m_typDatSetTbProdutosNcm = null;
		#endregion

		#region Construtores & Destrutores
		public clsNcm(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel, int Exportador, int Produto, ref System.Windows.Forms.ImageList ilBandeiras): base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, Exportador, Produto, ref ilBandeiras)
		{
			carregaTypDatSet();
			carregaDadosBD();
		}
		public clsNcm(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel, int Exportador, int Produto, ref mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetTbProdutos, ref mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm typDatSetTbProdutosNcm, bool bNaoGravarTabela, ref System.Windows.Forms.ImageList ilBandeiras): base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, Exportador, Produto, ref typDatSetTbProdutos, bNaoGravarTabela, ref ilBandeiras)
		{
			m_typDatSetTbProdutosNcm = (mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm)typDatSetTbProdutosNcm.Copy();
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
				m_clsProdutosGeral = new mdlProdutosGeral.clsProdutos(ref m_cls_ter_tratadorErro, ref m_cls_dba_ConnectionDB, m_strEnderecoExecutavel, m_nIdExportador, 1, ref m_ilBandeiras, ref m_typDatSetTbProdutosNcm);
				m_clsProdutosGeral.ShowDialogClassificacoesTarifariasCadastroNCM(out m_strNcm, out m_strDenominacao, out bModificado);
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
				m_clsProdutosGeral = new mdlProdutosGeral.clsProdutos(ref m_cls_ter_tratadorErro, ref m_cls_dba_ConnectionDB, m_strEnderecoExecutavel, m_nIdExportador, 1, ref m_ilBandeiras, ref m_typDatSetTbProdutosNcm);
				m_clsProdutosGeral.ShowDialogClassificacoesTarifariasEdicaoNCM(m_strNcm, m_strDenominacao, out strClassificacao, out strDenominacaoEditada, out bModificado);
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
				mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm.tbProdutosNcmRow dtrwRowTbProdutosNcm;
				string strClassificacao = "";
				if (lvClassificacao.SelectedItems.Count > 0)
				{
					System.Windows.Forms.DialogResult drApaga = mdlMensagens.clsMensagens.ShowQuestion("Classificação",mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlClassificacao_clsNcm_ApagarNcm).Replace("TAG",lvClassificacao.SelectedItems.Count.ToString()),System.Windows.Forms.MessageBoxButtons.YesNo);
					//System.Windows.Forms.DialogResult drApaga = System.Windows.Forms.MessageBox.Show("Você tem certeza que deseja excluir " + lvClassificacao.SelectedItems.Count.ToString() + " classificação(ões)?","Classificação",System.Windows.Forms.MessageBoxButtons.YesNo);
					while (lvClassificacao.SelectedItems.Count > 0 && drApaga == System.Windows.Forms.DialogResult.Yes)
					{
						strClassificacao = lvClassificacao.SelectedItems[0].Text;
						for (int nCount = 0; nCount < m_typDatSetTbProdutos.tbProdutos.Rows.Count; nCount++)
						{
							dtrwRowTbProdutos = (mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow)m_typDatSetTbProdutos.tbProdutos.Rows[nCount];
							if ((!dtrwRowTbProdutos.IsstrNcmNull()) && (dtrwRowTbProdutos.strNcm == strClassificacao))
							{
								dtrwRowTbProdutos.strNcm = "";
							}
						}
						lvClassificacao.SelectedItems[0].Selected = false;
						dtrwRowTbProdutosNcm = m_typDatSetTbProdutosNcm.tbProdutosNcm.FindBynIdExportadorstrNcm(m_nIdExportador,strClassificacao);
						if (dtrwRowTbProdutosNcm != null)
							dtrwRowTbProdutosNcm.Delete();
					}
					if (drApaga == System.Windows.Forms.DialogResult.Yes)
					{
						m_strNcm = "";
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
				if (m_typDatSetTbProdutosNcm == null)
				{
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
				
					arlCondicaoCampo.Add("nIdExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_nIdExportador);

					m_typDatSetTbProdutosNcm = m_cls_dba_ConnectionDB.GetTbProdutosNcm(arlCondicaoCampo, arlCondicaoComparador, arlCondicaoValor, null, null);
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
					if (!dtrwTbProdutos.IsstrNcmNull())
						m_strNcm = dtrwTbProdutos.strNcm;
					else
						m_strNcm = "";
				}
				else
				{
					m_strNcm = "";
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
					m_strNcm = lvClassificacao.SelectedItems[0].Text;
				// Cria a variável para conter o registro corrente
				mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm.tbProdutosNcmRow dtrwRowTbProdutosNcm = null;
				dtrwRowTbProdutosNcm = m_typDatSetTbProdutosNcm.tbProdutosNcm.FindBynIdExportadorstrNcm(m_nIdExportador, m_strNcm);
				if (dtrwRowTbProdutosNcm != null )
				{
					if (!dtrwRowTbProdutosNcm.IsmstrDenominacaoNull())
					{
						m_strDenominacao = dtrwRowTbProdutosNcm.mstrDenominacao;
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
				formClassificacao.Text = "Classificação NCM";
				// List View Item
				System.Windows.Forms.ListViewItem lvItemClassificacao;
				// Limpa os Items da List View
				lvClassificacao.Items.Clear();
				mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm.tbProdutosNcmRow dtrwRowTbProdutosNcm;
				// Preenche os itens da List View
				for (int nCont = 0 ; nCont < m_typDatSetTbProdutosNcm.tbProdutosNcm.Rows.Count ; nCont++)
				{
					dtrwRowTbProdutosNcm = (mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm.tbProdutosNcmRow)m_typDatSetTbProdutosNcm.tbProdutosNcm.Rows[nCont];
					if (dtrwRowTbProdutosNcm.RowState != System.Data.DataRowState.Deleted)
					{
						lvItemClassificacao = lvClassificacao.Items.Add(dtrwRowTbProdutosNcm.strNcm);
						lvItemClassificacao.Tag = dtrwRowTbProdutosNcm.nIdExportador;
						if (lvItemClassificacao.Text == m_strNcm)
						{
							lvItemClassificacao.Selected = true;
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
				//							lvItemDadosClassificacao.SubItems.Add(strDenominacaoSemNovaLinha.Substring(nCount,25));
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
				mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm.tbProdutosNcmRow dtrwTbProdutosNcm;
				dtrwTbProdutosNcm = m_typDatSetTbProdutosNcm.tbProdutosNcm.NewtbProdutosNcmRow();
				dtrwTbProdutosNcm.nIdExportador = m_nIdExportador;
				dtrwTbProdutosNcm.strNcm = m_strNcm;
				dtrwTbProdutosNcm.mstrDenominacao = m_strDenominacao;
				m_typDatSetTbProdutosNcm.tbProdutosNcm.AddtbProdutosNcmRow(dtrwTbProdutosNcm);
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
				mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm.tbProdutosNcmRow dtrwTbProdutosNcm;
				dtrwTbProdutosNcm = m_typDatSetTbProdutosNcm.tbProdutosNcm.FindBynIdExportadorstrNcm(m_nIdExportador,m_strNcm);
				if (dtrwTbProdutosNcm != null)
				{
					dtrwTbProdutosNcm.strNcm = strClassificacao;
					dtrwTbProdutosNcm.mstrDenominacao = strDenominacao;					
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
						dtrwRowProdutos.strNcm = m_strNcm;
						if (!m_bNaoGravarTabelas)
							m_cls_dba_ConnectionDB.SetTbProdutos(m_typDatSetTbProdutos);
					}
					if (m_typDatSetTbProdutosNcm != null && !m_bNaoGravarTabelas)
						m_cls_dba_ConnectionDB.SetTbProdutosNcm(m_typDatSetTbProdutosNcm);
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
			strClassificacao = m_strNcm;
		}
		public void retornaTypDatSetsTbs(out mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetTbProdutos, out mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm typDatSetTbProdutosNcm)
		{
			retornaTypDatSetTbProdutos(out typDatSetTbProdutos);
			typDatSetTbProdutosNcm = m_typDatSetTbProdutosNcm;
		}
		#endregion
	}
}
