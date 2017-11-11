using System;

namespace mdlData.DataEmissao.CO
{
	/// <summary>
	/// Summary description for clsDataEmissaoTODOSCOs.
	/// </summary>
	public class clsDataEmissaoTODOSCOs
	{
		#region Atributos
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
		protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionBD = null;
		protected string m_strEnderecoExecutavel = "";

		protected int m_nIdExportador = -1;
		protected string m_strIdPE = "";
		protected string m_strData = "";
		protected int m_nIdTipoCO = -1;

		private mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem m_typDatSetTbCertificadosOrigem;
		private mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem m_typDatSetTbProdutosCertificadoOrigem;
		#endregion

		#region Construtores & Destrutores
		public clsDataEmissaoTODOSCOs(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string strIdPE)
		{
			m_cls_ter_tratadorErro = tratadorErro;
			m_cls_dba_ConnectionBD = ConnectionDB;
			m_strEnderecoExecutavel = EnderecoExecutavel;
			m_nIdExportador = nIdExportador;
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
			
				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("idPE");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdPE);

				m_typDatSetTbCertificadosOrigem = m_cls_dba_ConnectionBD.GetTbCertificadosOrigem(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				m_typDatSetTbProdutosCertificadoOrigem = m_cls_dba_ConnectionBD.GetTbProdutosCertificadoOrigem(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected void carregaDadosBD()
		{
			try
			{
				m_strData = "";
				System.Collections.ArrayList arlIdsTiposCOs = new System.Collections.ArrayList();
				mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow dtrwRowTbCertificadosOrigem;
				foreach (mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow dtrwRowTbProdutosCertificadoOrigem in m_typDatSetTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigem.Rows)
				{
					if (!arlIdsTiposCOs.Contains(dtrwRowTbProdutosCertificadoOrigem.idTipoCO))
					{
						dtrwRowTbCertificadosOrigem = m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.FindByidExportadoridPEnIdTipoCO(m_nIdExportador, m_strIdPE, dtrwRowTbProdutosCertificadoOrigem.idTipoCO);
						if (dtrwRowTbCertificadosOrigem != null)
						{
							m_strData += (dtrwRowTbCertificadosOrigem.IsdtDataCONull() ? "?, " : dtrwRowTbCertificadosOrigem.dtDataCO.ToString("dd/MM/yyyy") + ", ");
						}
						else
						{
							m_strData += "?, ";
						}
						arlIdsTiposCOs.Add(dtrwRowTbProdutosCertificadoOrigem.idTipoCO);
					}
				}
				if (m_strData.Length > 2)
					m_strData = m_strData.Remove(m_strData.Length - 2, 2);
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
		public void retornaValores(out string strData)
		{
			strData = m_strData;
		}
		#endregion
	}
}
