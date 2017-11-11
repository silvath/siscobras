using System;

namespace mdlObservacoes.Bordero
{
	/// <summary>
	/// Summary description for clsObservacoesBorderoSecundario.
	/// </summary>
	public class clsObservacoesBorderoSecundario : clsObservacoes
	{
		#region Atributos
		private string m_strIdPE = "";
		private int m_nIdBancoExportadorBordero = -1;

		private mdlDataBaseAccess.Tabelas.XsdTbBorderosSecundarios m_typDatSetTbBorderosSecundarios;
		#endregion

		#region Construtores & Destrutores
		public clsObservacoesBorderoSecundario(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string strIdPE, int idBancoExportadorBordero): base(ref tratadorErro, ref ConnectionDB,EnderecoExecutavel,nIdExportador)
		{
			m_strIdPE = strIdPE;
			m_nIdBancoExportadorBordero = idBancoExportadorBordero;
			carregaTypDatSet();
			carregaDadosBD();
			m_strCaption = "Borderô";
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

				arlCondicaoCampo.Add("nIdBancoExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdBancoExportadorBordero);

				m_typDatSetTbBorderosSecundarios = m_cls_dba_ConnectionBD.GetTbBorderosSecundarios(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
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
				mdlDataBaseAccess.Tabelas.XsdTbBorderosSecundarios.tbBorderosSecundariosRow dtrwRowTbBorderosSecundarios;
				if (m_typDatSetTbBorderosSecundarios.tbBorderosSecundarios.Rows.Count > 0)
				{
					dtrwRowTbBorderosSecundarios = (mdlDataBaseAccess.Tabelas.XsdTbBorderosSecundarios.tbBorderosSecundariosRow)m_typDatSetTbBorderosSecundarios.tbBorderosSecundarios.Rows[0];
					if (!dtrwRowTbBorderosSecundarios.IsmstrObservacaoNull())
						m_strObservacoes = dtrwRowTbBorderosSecundarios.mstrObservacao;
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
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbBorderosSecundarios.tbBorderosSecundariosRow dtrwRowTbBorderosSecundarios;
				if (m_typDatSetTbBorderosSecundarios.tbBorderosSecundarios.Rows.Count > 0)
				{
					dtrwRowTbBorderosSecundarios = (mdlDataBaseAccess.Tabelas.XsdTbBorderosSecundarios.tbBorderosSecundariosRow)m_typDatSetTbBorderosSecundarios.tbBorderosSecundarios.Rows[0];
					if (dtrwRowTbBorderosSecundarios != null)
						dtrwRowTbBorderosSecundarios.mstrObservacao = m_strObservacoes;
				}
				m_cls_dba_ConnectionBD.SetTbBorderosSecundarios(m_typDatSetTbBorderosSecundarios);
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#endregion
	}
}
