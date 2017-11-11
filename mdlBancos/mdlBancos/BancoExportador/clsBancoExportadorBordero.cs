using System;

namespace mdlBancos.BancoExportador
{
	/// <summary>
	/// Summary description for clsBancoExportadorBordero.
	/// </summary>
	public class clsBancoExportadorBordero : clsBancoExportador
	{
		#region Atributos
		protected string m_strIdPE = "";

		private mdlDataBaseAccess.Tabelas.XsdTbBorderos m_typDatSetTbBorderos = null;
		#endregion

		#region Construtores & Destrutores
		public clsBancoExportadorBordero(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB, string EnderecoExecutavel, int idExportador, string idPE) : base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, idExportador)
		{
			m_bDocumento = false;
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

			m_typDatSetTbBorderos = m_cls_dba_ConnectionBD.GetTbBorderos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
			base.carregaTypDatSet();
		}
		protected override void carregaBDEspecificos()
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbBorderos.tbBorderosRow dtrwRowTbBorderos;
				dtrwRowTbBorderos = m_typDatSetTbBorderos.tbBorderos.FindByidExportadoridPE(m_nIdExportador,m_strIdPE);
				if (dtrwRowTbBorderos != null)
				{
					if (!dtrwRowTbBorderos.IsnIdBancoExportadorAtualNull())
						m_nIdBanco = dtrwRowTbBorderos.nIdBancoExportadorAtual;
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
			mdlDataBaseAccess.Tabelas.XsdTbBorderos.tbBorderosRow dtrwRowTbBorderos;
			dtrwRowTbBorderos = m_typDatSetTbBorderos.tbBorderos.FindByidExportadoridPE(m_nIdExportador,m_strIdPE);
			if (dtrwRowTbBorderos != null)
			{
				dtrwRowTbBorderos.nIdBancoExportadorAtual = m_nIdBanco;
			}
			m_cls_dba_ConnectionBD.SetTbBorderos(m_typDatSetTbBorderos);
		}
		#endregion
	}
}
