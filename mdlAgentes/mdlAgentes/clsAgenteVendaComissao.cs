using System;

namespace mdlAgentes
{
	/// <summary>
	/// Summary description for clsAgenteVendaComissao.
	/// </summary>
	public class clsAgenteVendaComissao
	{
		#region Atributes
			protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
			protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB;
			protected string m_strEnderecoExecutavel;
		#endregion
		#region Properties

		#endregion
		#region Constructors and Destructors 
			public clsAgenteVendaComissao(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB, string EnderecoExecutavel)
			{
				m_cls_ter_tratadorErro = tratadorErro;
				m_cls_dba_ConnectionDB = ConnectionDB;
				m_strEnderecoExecutavel = EnderecoExecutavel;
			}
		#endregion

		#region Comissao Conta Grafica
			public decimal GetComissaoContaGrafica(int nIdExportador, string strIdPE)
			{
				decimal dcValorComissao = 0;
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdExportador);
				arlCondicaoCampo.Add("idPE");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(strIdPE);

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				mdlDataBaseAccess.Tabelas.XsdTbPes typDatSetTbPEs = m_cls_dba_ConnectionDB.GetTbPes(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				if (typDatSetTbPEs.tbPEs.Rows.Count == 0)
					return(0);
				mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwPE = typDatSetTbPEs.tbPEs[0];
				if ((dtrwPE.IsnAgenteVendaFormaPagamentoNull() ? clsAgentesVenda.FORMAPAGAMENTOCOMISSAO.REMETER : (clsAgentesVenda.FORMAPAGAMENTOCOMISSAO)dtrwPE.nAgenteVendaFormaPagamento) == clsAgentesVenda.FORMAPAGAMENTOCOMISSAO.REMETER)
					return(0);
				dcValorComissao = (dtrwPE.IsdAgenteVendaValorComissaoNull() ? 0 : (decimal)dtrwPE.dAgenteVendaValorComissao);
				decimal dcValorComissaoPorcentagem = (dtrwPE.IsdAgenteVendaValorComissaoPorcentagemNull() ? 0 : (decimal)dtrwPE.dAgenteVendaValorComissaoPorcentagem);
				if ((dcValorComissaoPorcentagem != 0) && (dcValorComissao == 0))
				{
					mdlIncoterm.clsIncoterm obj = new mdlIncoterm.Faturas.clsIncotermComercial(ref m_cls_ter_tratadorErro, ref m_cls_dba_ConnectionDB, m_strEnderecoExecutavel, nIdExportador, strIdPE);
					string strNull;
					double dNull;
					bool bNull;
					double dValorSubTotalCDesconto = 0;
					obj.retornaValores(out strNull, out dNull, out dNull, out bNull, out dValorSubTotalCDesconto, out dNull, out dNull, out dNull, out strNull, out dNull, out dNull, out bNull, out strNull);
					dcValorComissao = ((decimal)dValorSubTotalCDesconto * dcValorComissaoPorcentagem);  
				}
				dcValorComissao = System.Math.Round(dcValorComissao,2);
				return(dcValorComissao);
			}
		#endregion
	}
}
