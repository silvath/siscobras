using System;

namespace mdlData.Siscomex
{
	/// <summary>
	/// Summary description for clsDataMultiplaDSE.
	/// </summary>
	public class clsDataMultiplaDSE : clsDataMultipla
	{
		#region Atributos
			private int m_nIdExportador = -1;
			private string m_strIdPE = "";
		#endregion
		#region Construtores
			public clsDataMultiplaDSE(ref mdlTratamentoErro.clsTratamentoErro cls_ter_tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB,string strEnderecoExecutavel,int nIdExportador, string strIdPE): base(ref cls_ter_tratadorErro, ref cls_dba_ConnectionDB,strEnderecoExecutavel)
			{
				m_nIdExportador = nIdExportador;
				m_strIdPE = strIdPE;
			}
		#endregion

		#region Carregamento dos Dados
			private mdlDataBaseAccess.Tabelas.XsdTbPes GetTbPE()
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

				m_cls_dba_ConnectionBD.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				return(m_cls_dba_ConnectionBD.GetTbPes(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null));
			}

			private mdlDataBaseAccess.Tabelas.XsdTbDSEs GetTbDSEs()
			{
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				m_cls_dba_ConnectionBD.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				return(m_cls_dba_ConnectionBD.GetTbDSEs(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null));
			}

			private mdlDataBaseAccess.Tabelas.XsdTbDSEsPEs GetTbDSEsPEs()
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

				m_cls_dba_ConnectionBD.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				return(m_cls_dba_ConnectionBD.GetTbDSEsPEs(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null));
			}

			private mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow GetDtrwPE()
			{
				mdlDataBaseAccess.Tabelas.XsdTbPes typDatSetPEs = GetTbPE();
				if (typDatSetPEs.tbPEs.Rows.Count > 0)
					return(typDatSetPEs.tbPEs[0]);
				else
					return(null);
			} 


			protected override string CarregaDataMultipla()
			{
				mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwPE = GetDtrwPE();
				if ((dtrwPE == null) || (dtrwPE.IsmstrDataEmissaoDSENull()))
					return(CarregaDataMultiplaDefault());
				return(dtrwPE.mstrDataEmissaoDSE);
			}

			protected override string CarregaDataMultiplaDefault()
			{
				mdlDataBaseAccess.Tabelas.XsdTbDSEs typDatSetDSEs = GetTbDSEs();
				mdlDataBaseAccess.Tabelas.XsdTbDSEsPEs typDatSetDSEsPEs = GetTbDSEsPEs();
				System.Text.StringBuilder strbDefault = new System.Text.StringBuilder();
				// Ordernando
				System.Collections.SortedList srtlstDSE = new System.Collections.SortedList(new mdlComponentesColecoes.clsComparerNumbersTexts());
				for(int i = 0; i < typDatSetDSEsPEs.tbDSEsPEs.Rows.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbDSEsPEs.tbDSEsPEsRow dtrwDSEPE = (mdlDataBaseAccess.Tabelas.XsdTbDSEsPEs.tbDSEsPEsRow)typDatSetDSEsPEs.tbDSEsPEs.Rows[i];
					if ((dtrwDSEPE.nIdExportador == m_nIdExportador) && (dtrwDSEPE.strIdPE == m_strIdPE))
					{
						mdlDataBaseAccess.Tabelas.XsdTbDSEs.tbDSEsRow dtrwDSE = typDatSetDSEs.tbDSEs.FindBynIdExportadornIdDSE(m_nIdExportador,dtrwDSEPE.nIdDSE);
						if ((dtrwDSE != null) && (!srtlstDSE.Contains(dtrwDSE.mstrNumero)))
							srtlstDSE.Add(dtrwDSE.mstrNumero,dtrwDSE);
					} 
				}
				// Inserindo
				for(int i = 0; i < srtlstDSE.Count; i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbDSEs.tbDSEsRow dtrwDSE = (mdlDataBaseAccess.Tabelas.XsdTbDSEs.tbDSEsRow)srtlstDSE.GetByIndex(i);
					if (strbDefault.ToString() != "")
						strbDefault.Append(" - ");
					if (!dtrwDSE.IsdtEmissaoNull())
						strbDefault.Append(dtrwDSE.dtEmissao.ToString(this.Formato));
					else
						strbDefault.Append(" ");
				}
				return(strbDefault.ToString());
			}
		#endregion
		#region Salvamento dos Dados
			protected override bool SalvaDataMultipla(string strDataMultipla)
			{
				mdlDataBaseAccess.Tabelas.XsdTbPes typDatSetPE = GetTbPE();
				if (typDatSetPE.tbPEs.Rows.Count == 0)
					return(false);
				mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwPE = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)typDatSetPE.tbPEs.Rows[0];
				dtrwPE.mstrDataEmissaoDSE = strDataMultipla;
				m_cls_dba_ConnectionBD.SetTbPes(typDatSetPE);
				return(m_cls_dba_ConnectionBD.Erro == null);
			}
		#endregion
	}
}
