using System;

namespace mdlObservacoes.CartaCredito
{
	/// <summary>
	/// Summary description for clsObservacoesCartaCredito.
	/// </summary>
	public class clsObservacoesCartaCredito : clsObservacoes
	{
		#region Atributos
			private string m_strIdPE = "";
		#endregion
		#region Construtores
			public clsObservacoesCartaCredito(ref mdlTratamentoErro.clsTratamentoErro cls_ter_tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB,string strEnderecoExecutavel,int nIdExportador, string strIdPE): base(ref cls_ter_tratadorErro, ref cls_dba_ConnectionDB,strEnderecoExecutavel,nIdExportador)
			{
				m_strIdPE = strIdPE;
				carregaDadosBD();
				m_strCaption = "Observações da Carta Crédito";
				this.MessageEnableShowDialog = "Este PE não possui uma Carta de Credito vinculada.";
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

				m_cls_dba_ConnectionBD.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				return(m_cls_dba_ConnectionBD.GetTbPes(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null));
			}

			private mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow GetDtrwPE()
			{
				mdlDataBaseAccess.Tabelas.XsdTbPes typDatSetPEs = GetTbPEs();
				if (typDatSetPEs.tbPEs.Rows.Count == 0)
					return(null);
				return((mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)typDatSetPEs.tbPEs.Rows[0]);
			}

			protected mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais GetTbFaturasComerciais()
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
				return(m_cls_dba_ConnectionBD.GetTbFaturasComerciais(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null));
			}

			private mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow GetDtrwFaturaComerical()
			{
				mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais typDatSetFaturasComerciais = GetTbFaturasComerciais();
				if (typDatSetFaturasComerciais.tbFaturasComerciais.Rows.Count == 0)
					return(null);
				return((mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow)typDatSetFaturasComerciais.tbFaturasComerciais.Rows[0]);
			}

			private mdlDataBaseAccess.Tabelas.XsdTbCartasCredito GetTbCartasCredito()
			{
				mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwPE = GetDtrwPE();	
				if ((dtrwPE == null) || (dtrwPE.IsnIdCartaCreditoNull()))
					return(null);
				mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwFaturaComercial = GetDtrwFaturaComerical();	
				if ((dtrwFaturaComercial == null) || (dtrwFaturaComercial.IsidImportadorNull()))
					return(null);

				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
				
				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("nIdCartaCredito");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(dtrwPE.nIdCartaCredito);

				arlCondicaoCampo.Add("nIdImportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(dtrwFaturaComercial.idImportador);

				m_cls_dba_ConnectionBD.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				return(m_cls_dba_ConnectionBD.GetTbCartasCredito(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null));
			}

			private mdlDataBaseAccess.Tabelas.XsdTbCartasCredito.tbCartasCreditoRow GetDtrwCartasCredito()
			{
				mdlDataBaseAccess.Tabelas.XsdTbCartasCredito typDatSetCartasCredito = GetTbCartasCredito();
				if ((typDatSetCartasCredito == null) || (typDatSetCartasCredito.tbCartasCredito.Rows.Count == 0))
					return(null);
				return((mdlDataBaseAccess.Tabelas.XsdTbCartasCredito.tbCartasCreditoRow)typDatSetCartasCredito.tbCartasCredito.Rows[0]);
			}

			protected override void carregaDadosBDEspecifico()
			{
				mdlDataBaseAccess.Tabelas.XsdTbCartasCredito.tbCartasCreditoRow dtrwCartaCredito = GetDtrwCartasCredito();
				if (dtrwCartaCredito == null)
				{
					EnableShowDialog = false;
					m_strObservacoes = ""; 
					return;
				}
				if (dtrwCartaCredito.IsmstrObservacoesNull())
					m_strObservacoes = "";
				else
					m_strObservacoes = dtrwCartaCredito.mstrObservacoes;
			}
		#endregion
		#region Salvamento dos Dados
		protected override void salvaDadosBDEspecifico()
		{
			mdlDataBaseAccess.Tabelas.XsdTbCartasCredito typDatSetCartasCredito = GetTbCartasCredito();
			if ((typDatSetCartasCredito == null) || (typDatSetCartasCredito.tbCartasCredito.Rows.Count == 0))
				return;
			mdlDataBaseAccess.Tabelas.XsdTbCartasCredito.tbCartasCreditoRow dtrwCartaCredito = (mdlDataBaseAccess.Tabelas.XsdTbCartasCredito.tbCartasCreditoRow)typDatSetCartasCredito.tbCartasCredito.Rows[0];
			dtrwCartaCredito.mstrObservacoes = m_strObservacoes;
			m_cls_dba_ConnectionBD.SetTbCartasCredito(typDatSetCartasCredito);
		}
		#endregion
	}
}
