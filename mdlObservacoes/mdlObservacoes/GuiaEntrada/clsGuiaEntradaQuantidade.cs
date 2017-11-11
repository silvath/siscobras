using System;

namespace mdlObservacoes.GuiaEntrada
{
	/// <summary>
	/// Summary description for clsGuiaEntradaQuantidade.
	/// </summary>
	public class clsGuiaEntradaQuantidade : clsObservacoes
	{
		#region Atributes
		private string m_strIdPE = "";

		private mdlDataBaseAccess.Tabelas.XsdTbGuiasEntrada m_typDatSetGuiasEntradas;
		#endregion
		#region Constructors and Destructors
			public clsGuiaEntradaQuantidade(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string strIdPE): base(ref tratadorErro, ref ConnectionDB,EnderecoExecutavel,nIdExportador)
			{
				this.Multiline = false;
				this.TextForm = "Quantidade";
				m_strIdPE = strIdPE;
				carregaTypDatSet();
				carregaDadosBD();
			}
		#endregion

		#region Carregamento de Dados
		#region Banco de Dados
			protected void carregaTypDatSet()
			{
				try 
				{
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
				
					arlCondicaoCampo.Add("nIdExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_nIdExportador);

					arlCondicaoCampo.Add("strIdPE");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_strIdPE);

					m_typDatSetGuiasEntradas = m_cls_dba_ConnectionBD.GetTbGuiasEntrada(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				} 
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
			protected override void carregaDadosBDEspecifico()
			{
				try
				{
					if (m_typDatSetGuiasEntradas.tbGuiasEntrada.Rows.Count > 0)
					{
						mdlDataBaseAccess.Tabelas.XsdTbGuiasEntrada.tbGuiasEntradaRow dtrwGuiasEntrada = (mdlDataBaseAccess.Tabelas.XsdTbGuiasEntrada.tbGuiasEntradaRow)m_typDatSetGuiasEntradas.tbGuiasEntrada.Rows[0];
						if (!dtrwGuiasEntrada.IsmstrQuantidadeNull())
							m_strObservacoes = dtrwGuiasEntrada.mstrQuantidade;
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
		#region Salvamento dos Dados
		#region Banco de Dados
		protected override void salvaDadosBDEspecifico()
		{
			if (m_typDatSetGuiasEntradas.tbGuiasEntrada.Rows.Count > 0)
			{
				mdlDataBaseAccess.Tabelas.XsdTbGuiasEntrada.tbGuiasEntradaRow dtrwGuiaEntrada = (mdlDataBaseAccess.Tabelas.XsdTbGuiasEntrada.tbGuiasEntradaRow)m_typDatSetGuiasEntradas.tbGuiasEntrada.Rows[0];
				dtrwGuiaEntrada.mstrQuantidade = m_strObservacoes;  
				m_cls_dba_ConnectionBD.SetTbGuiasEntrada(m_typDatSetGuiasEntradas);
			}
		}
		#endregion
		#endregion
	}
}
