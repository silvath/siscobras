using System;

namespace mdlObservacoes.Sumario
{
	/// <summary>
	/// Summary description for clsObservacoesSumario.
	/// </summary>
	public class clsObservacoesSumario : clsObservacoes
	{
		#region Atributos
		private string m_strIdPE = "";

		private mdlDataBaseAccess.Tabelas.XsdTbSumarios m_typDatSetTbSumarios;
		#endregion

		#region Construtores & Destrutores
		public clsObservacoesSumario(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string strIdPE): base(ref tratadorErro, ref ConnectionDB,EnderecoExecutavel,nIdExportador)
		{
			m_strIdPE = strIdPE;
			carregaTypDatSet();
			carregaDadosBD();
			m_strCaption = "Sumário";
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

				m_typDatSetTbSumarios = m_cls_dba_ConnectionBD.GetTbSumarios(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
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
				mdlDataBaseAccess.Tabelas.XsdTbSumarios.tbSumariosRow dtrwRowTbSumarios;
				if (m_typDatSetTbSumarios.tbSumarios.Rows.Count > 0)
				{
					dtrwRowTbSumarios = (mdlDataBaseAccess.Tabelas.XsdTbSumarios.tbSumariosRow)m_typDatSetTbSumarios.tbSumarios.Rows[0];
					if (!dtrwRowTbSumarios.IsmstrObservacaoNull())
						m_strObservacoes = dtrwRowTbSumarios.mstrObservacao;
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
				mdlDataBaseAccess.Tabelas.XsdTbSumarios.tbSumariosRow dtrwRowTbSumarios;
				if (m_typDatSetTbSumarios.tbSumarios.Rows.Count > 0)
				{
					dtrwRowTbSumarios = (mdlDataBaseAccess.Tabelas.XsdTbSumarios.tbSumariosRow)m_typDatSetTbSumarios.tbSumarios.Rows[0];
					if (dtrwRowTbSumarios != null)
						dtrwRowTbSumarios.mstrObservacao = m_strObservacoes;
				}
				m_cls_dba_ConnectionBD.SetTbSumarios(m_typDatSetTbSumarios);
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
