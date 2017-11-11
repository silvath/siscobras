using System;

namespace mdlData.Siscomex
{
	/// <summary>
	/// Summary description for clsDataMultiplaRE.
	/// </summary>
	public class clsDataMultiplaRE : clsDataMultipla
	{
		#region Atributos
			private int m_nIdExportador = -1;
			private string m_strIdPE = "";
		#endregion
		#region Construtores
			public clsDataMultiplaRE(ref mdlTratamentoErro.clsTratamentoErro cls_ter_tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB,string strEnderecoExecutavel,int nIdExportador, string strIdPE): base(ref cls_ter_tratadorErro, ref cls_dba_ConnectionDB,strEnderecoExecutavel)
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

			private mdlDataBaseAccess.Tabelas.XsdTbREs GetTbREs()
			{
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				m_cls_dba_ConnectionBD.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				return(m_cls_dba_ConnectionBD.GetTbREs(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null));
			}

			private mdlDataBaseAccess.Tabelas.XsdTbREsPEs GetTbREsPEs()
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
				return(m_cls_dba_ConnectionBD.GetTbREsPEs(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null));
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
				if ((dtrwPE == null) || (dtrwPE.IsmstrDataEmissaoRENull()))
					return(CarregaDataMultiplaDefault());
				return(dtrwPE.mstrDataEmissaoRE);
			}

			protected override string CarregaDataMultiplaDefault()
			{
				mdlDataBaseAccess.Tabelas.XsdTbREs typDatSetREs = GetTbREs();
				mdlDataBaseAccess.Tabelas.XsdTbREsPEs typDatSetREsPEs = GetTbREsPEs();
				System.Text.StringBuilder strbDefault = new System.Text.StringBuilder();
				// Ordernando
				System.Collections.SortedList srtlstRE = new System.Collections.SortedList(new mdlComponentesColecoes.clsComparerNumbersTexts());
				for(int i = 0; i < typDatSetREsPEs.tbREsPEs.Rows.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbREsPEs.tbREsPEsRow dtrwREPE = (mdlDataBaseAccess.Tabelas.XsdTbREsPEs.tbREsPEsRow)typDatSetREsPEs.tbREsPEs.Rows[i];
					if ((dtrwREPE.nIdExportador == m_nIdExportador) && (dtrwREPE.strIdPE == m_strIdPE))
					{
						mdlDataBaseAccess.Tabelas.XsdTbREs.tbREsRow dtrwRE = typDatSetREs.tbREs.FindBynIdExportadornIdRe(m_nIdExportador,dtrwREPE.nIdRe);
						if ((dtrwRE != null) && (!srtlstRE.Contains(dtrwRE.mstrNumero)))
							srtlstRE.Add(dtrwRE.mstrNumero,dtrwRE);
					} 
				}
				// Inserindo
				for(int i = 0; i < srtlstRE.Count; i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbREs.tbREsRow dtrwRE = (mdlDataBaseAccess.Tabelas.XsdTbREs.tbREsRow)srtlstRE.GetByIndex(i);
					if (strbDefault.ToString() != "")
						strbDefault.Append(" - ");
					if (!dtrwRE.IsdtEmissaoNull())
						strbDefault.Append(dtrwRE.dtEmissao.ToString(this.Formato));
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
				dtrwPE.mstrDataEmissaoRE = strDataMultipla;
				m_cls_dba_ConnectionBD.SetTbPes(typDatSetPE);
				return(m_cls_dba_ConnectionBD.Erro == null);
			}
		#endregion
	}
}
