using System;

namespace mdlObservacoes.PE
{
	/// <summary>
	/// Summary description for clsObservacoesPE.
	/// </summary>
	public class clsObservacoesPE : clsObservacoes
	{
		#region Atributos
			private string m_strIdPE = "";
		#endregion
		#region Construtores
			public clsObservacoesPE(ref mdlTratamentoErro.clsTratamentoErro cls_ter_tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB,string strEnderecoExecutavel,int nIdExportador, string strIdPE): base(ref cls_ter_tratadorErro, ref cls_dba_ConnectionDB,strEnderecoExecutavel,nIdExportador)
			{
				m_strIdPE = strIdPE;
				carregaDadosBD();
				m_strCaption = "Observações do PE";
			}
		#endregion

		#region Carregamento de Dados
			protected mdlDataBaseAccess.Tabelas.XsdTbPes GetTbPEs()
			{
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
			
				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("idPE");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdPE);

				return(m_cls_dba_ConnectionBD.GetTbPes(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null));
			}

			private mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow GetDtrwPE()
			{
				mdlDataBaseAccess.Tabelas.XsdTbPes typDatSetPEs = GetTbPEs();
				if (typDatSetPEs.tbPEs.Rows.Count == 0)
					return(null);
				return((mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)typDatSetPEs.tbPEs.Rows[0]);
			}

			protected override void carregaDadosBDEspecifico()
			{
				mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwPE = GetDtrwPE();
				if ((dtrwPE == null) || (dtrwPE.IsmstrObservacoesNull()))
					m_strObservacoes = "";
				else
					m_strObservacoes = dtrwPE.mstrObservacoes;
			}
		#endregion
		#region Salvamento dos Dados
		protected override void salvaDadosBDEspecifico()
		{
			mdlDataBaseAccess.Tabelas.XsdTbPes typDatSetPEs = GetTbPEs();
			if (typDatSetPEs.tbPEs.Rows.Count > 0)
			{
				mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwPE = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)typDatSetPEs.tbPEs.Rows[0];
				dtrwPE.mstrObservacoes = m_strObservacoes;
				m_cls_dba_ConnectionBD.SetTbPes(typDatSetPEs);
			}
		}
		#endregion
	}
}
