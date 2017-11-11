using System;

namespace mdlObservacoes.GuiaEntrada
{
	/// <summary>
	/// Summary description for clsGuiaEntradaObservacoes.
	/// </summary>
	public class clsGuiaEntradaObservacoes : clsObservacoes
	{
		#region Atributes
			private string m_strIdPE = "";

			private mdlDataBaseAccess.Tabelas.XsdTbGuiasEntrada m_typDatSetGuiasEntrada;
		#endregion
		#region Constructors and Destructors
			public clsGuiaEntradaObservacoes(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string strIdPE): base(ref tratadorErro, ref ConnectionDB,EnderecoExecutavel,nIdExportador)
			{
				m_strIdPE = strIdPE;
				carregaTypDatSet();
				carregaDadosBD();
				m_strCaption = "Observações";
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

				m_typDatSetGuiasEntrada = m_cls_dba_ConnectionBD.GetTbGuiasEntrada(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
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
				if (m_typDatSetGuiasEntrada.tbGuiasEntrada.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbGuiasEntrada.tbGuiasEntradaRow dtrwGuiaEntrada = (mdlDataBaseAccess.Tabelas.XsdTbGuiasEntrada.tbGuiasEntradaRow)m_typDatSetGuiasEntrada.tbGuiasEntrada.Rows[0];;
					if (!dtrwGuiaEntrada.IsmstrObservacaoNull())
						m_strObservacoes = dtrwGuiaEntrada.mstrObservacao;
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
			if (m_typDatSetGuiasEntrada.tbGuiasEntrada.Rows.Count > 0)
			{
				mdlDataBaseAccess.Tabelas.XsdTbGuiasEntrada.tbGuiasEntradaRow dtrwGuiaEntrada = (mdlDataBaseAccess.Tabelas.XsdTbGuiasEntrada.tbGuiasEntradaRow)m_typDatSetGuiasEntrada.tbGuiasEntrada.Rows[0];;
				dtrwGuiaEntrada.mstrObservacao = m_strObservacoes;
				m_cls_dba_ConnectionBD.SetTbGuiasEntrada(m_typDatSetGuiasEntrada);
			}
		}
		#endregion
		#endregion
	}
}
