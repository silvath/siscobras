using System;

namespace mdlObservacoes.Bordero
{
	/// <summary>
	/// Summary description for clsObservacoesBordero.
	/// </summary>
	public class clsObservacoesBordero : clsObservacoes
	{
		#region Atributos
		private string m_strIdPE = "";

		private mdlDataBaseAccess.Tabelas.XsdTbBorderos m_typDatSetTbBorderos;
		#endregion

		#region Construtores & Destrutores
		public clsObservacoesBordero(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string strIdPE): base(ref tratadorErro, ref ConnectionDB,EnderecoExecutavel,nIdExportador)
		{
			m_strIdPE = strIdPE;
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
			
				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("idPE");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdPE);

				m_typDatSetTbBorderos = m_cls_dba_ConnectionBD.GetTbBorderos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
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
				mdlDataBaseAccess.Tabelas.XsdTbBorderos.tbBorderosRow dtrwRowTbBorderos;
				if (m_typDatSetTbBorderos.tbBorderos.Rows.Count > 0)
				{
					dtrwRowTbBorderos = (mdlDataBaseAccess.Tabelas.XsdTbBorderos.tbBorderosRow)m_typDatSetTbBorderos.tbBorderos.Rows[0];
					if (!dtrwRowTbBorderos.IsmstrObservacaoNull())
						m_strObservacoes = dtrwRowTbBorderos.mstrObservacao;
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
				mdlDataBaseAccess.Tabelas.XsdTbBorderos.tbBorderosRow dtrwRowTbBorderos;
				if (m_typDatSetTbBorderos.tbBorderos.Rows.Count > 0)
				{
					dtrwRowTbBorderos = (mdlDataBaseAccess.Tabelas.XsdTbBorderos.tbBorderosRow)m_typDatSetTbBorderos.tbBorderos.Rows[0];
					if (dtrwRowTbBorderos != null)
						dtrwRowTbBorderos.mstrObservacao = m_strObservacoes;
				}
				m_cls_dba_ConnectionBD.SetTbBorderos(m_typDatSetTbBorderos);
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
