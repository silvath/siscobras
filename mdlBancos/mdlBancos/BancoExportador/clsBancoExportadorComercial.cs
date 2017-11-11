using System;

namespace mdlBancos.BancoExportador
{
	/// <summary>
	/// Summary description for clsBancoExportadorComercial.
	/// </summary>
	public class clsBancoExportadorComercial : clsBancoExportador
	{
		#region Atributos
		protected string m_strIdPE = "";

		protected mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais m_typDatSetTbFaturasComerciais;
		#endregion

		#region Contrutores & Destrutores
		public clsBancoExportadorComercial (ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB, string EnderecoExecutavel, int idExportador, string idPE) : base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, idExportador)
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

			m_typDatSetTbFaturasComerciais = m_cls_dba_ConnectionBD.GetTbFaturasComerciais(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
			base.carregaTypDatSet();
		}
		protected override void carregaBDEspecificos()
		{
			try 
			{
				mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwRowTbFaturasComerciais;
				dtrwRowTbFaturasComerciais = m_typDatSetTbFaturasComerciais.tbFaturasComerciais.FindByidExportadoridPE(m_nIdExportador,m_strIdPE);
				if (dtrwRowTbFaturasComerciais != null)
				{
					if (!dtrwRowTbFaturasComerciais.IsidExportadorBancoNull())
                        m_nIdBanco = dtrwRowTbFaturasComerciais.idExportadorBanco;
					if (!dtrwRowTbFaturasComerciais.IsidExportadorBancoAgenciaNull())
                        m_strIdAgencia = dtrwRowTbFaturasComerciais.idExportadorBancoAgencia;
					if (!dtrwRowTbFaturasComerciais.IsidExportadorBancoContaNull())
                        m_strIdConta = dtrwRowTbFaturasComerciais.idExportadorBancoConta;
					if (!dtrwRowTbFaturasComerciais.IsmstrIdExportadorBancoInstrPgtoNull())
                        m_strInstrucoesPagamento = dtrwRowTbFaturasComerciais.mstrIdExportadorBancoInstrPgto;
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
			mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwRowTbFaturasComerciais;
			dtrwRowTbFaturasComerciais = m_typDatSetTbFaturasComerciais.tbFaturasComerciais.FindByidExportadoridPE(m_nIdExportador,m_strIdPE);
			if (dtrwRowTbFaturasComerciais != null)
			{
				dtrwRowTbFaturasComerciais.idExportadorBanco = m_nIdBanco;
				dtrwRowTbFaturasComerciais.idExportadorBancoAgencia = m_strIdAgencia;
				dtrwRowTbFaturasComerciais.idExportadorBancoConta = m_strIdConta;
				dtrwRowTbFaturasComerciais.mstrIdExportadorBancoInstrPgto = m_strInstrucoesPagamento;
			}
			m_cls_dba_ConnectionBD.SetTbFaturasComerciais(m_typDatSetTbFaturasComerciais);
		}
		#endregion
	}
}
