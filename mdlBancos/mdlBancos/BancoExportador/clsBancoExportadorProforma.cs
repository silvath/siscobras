using System;

namespace mdlBancos.BancoExportador
{
	/// <summary>
	/// Summary description for clsBancoExportadorProforma.
	/// </summary>
	public class clsBancoExportadorProforma : clsBancoExportador
	{
		#region Atributos
		protected string m_strIdPE = "";

		protected mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas m_typDatSetTbFaturasProformas;
		#endregion

		#region Contrutores & Destrutores
		public clsBancoExportadorProforma (ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB, string EnderecoExecutavel, int idExportador, string idPE) : base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, idExportador)
		{
			m_bDocumento = true;
			m_strIdPE = idPE;
			carregaTypDatSet();
			carregaDadosBD();
		}
		#endregion

		#region Carregamento de Dados
		protected new void carregaTypDatSet()
		{
			System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
			System.Collections.ArrayList arlOrdenacaoCampo = new System.Collections.ArrayList();
			System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();

			arlCondicaoCampo.Add("idExportador");
			arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicaoValor.Add(m_nIdExportador);
			arlCondicaoCampo.Add("idPE");
			arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicaoValor.Add(m_strIdPE);

			m_typDatSetTbFaturasProformas = m_cls_dba_ConnectionBD.GetTbFaturasProformas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
			base.carregaTypDatSet();
		}
		protected override void carregaBDEspecificos()
		{
			try 
			{
				mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas.tbFaturasProformasRow dtrwRowTbFaturasProformas;
				dtrwRowTbFaturasProformas = m_typDatSetTbFaturasProformas.tbFaturasProformas.FindByidExportadoridPE(m_nIdExportador,m_strIdPE);
				if (dtrwRowTbFaturasProformas != null)
				{
					if (!dtrwRowTbFaturasProformas.IsidExportadorBancoNull())
                        m_nIdBanco = dtrwRowTbFaturasProformas.idExportadorBanco;
					if (!dtrwRowTbFaturasProformas.IsidExportadorBancoAgenciaNull())
                        m_strIdAgencia = dtrwRowTbFaturasProformas.idExportadorBancoAgencia;
					if (!dtrwRowTbFaturasProformas.IsidExportadorBancoContaNull())
                        m_strIdConta = dtrwRowTbFaturasProformas.idExportadorBancoConta;
					if (!dtrwRowTbFaturasProformas.IsmstrIdExportadorBancoInstrPgtoNull())
                        m_strInstrucoesPagamento = dtrwRowTbFaturasProformas.mstrIdExportadorBancoInstrPgto;
				}
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Salvamento de Dados
		protected override void salvaDadosBDEspecifico()
		{
			mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas.tbFaturasProformasRow dtrwRowTbFaturasProformas;
			dtrwRowTbFaturasProformas = m_typDatSetTbFaturasProformas.tbFaturasProformas.FindByidExportadoridPE(m_nIdExportador,m_strIdPE);
			if (dtrwRowTbFaturasProformas != null)
			{
				dtrwRowTbFaturasProformas.idExportadorBanco = m_nIdBanco;
				dtrwRowTbFaturasProformas.idExportadorBancoAgencia = m_strIdAgencia;
				dtrwRowTbFaturasProformas.idExportadorBancoConta = m_strIdConta;
				dtrwRowTbFaturasProformas.mstrIdExportadorBancoInstrPgto = m_strInstrucoesPagamento;
			}
			m_cls_dba_ConnectionBD.SetTbFaturasProformas(m_typDatSetTbFaturasProformas);
		}
		#endregion
	}
}
