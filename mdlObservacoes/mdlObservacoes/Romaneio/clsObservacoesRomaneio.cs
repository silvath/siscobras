using System;

namespace mdlObservacoes.Romaneio
{
	/// <summary>
	/// Summary description for clsObservacoesRomaneio.
	/// </summary>
	public class clsObservacoesRomaneio : clsObservacoes
	{
		#region Atributos
		private string m_strIdPE = "";

		private mdlDataBaseAccess.Tabelas.XsdTbRomaneios m_typDatSetTbRomaneios;
		#endregion

		#region Construtores & Destrutores
		public clsObservacoesRomaneio(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string strIdPE): base(ref tratadorErro, ref ConnectionDB,EnderecoExecutavel,nIdExportador)
		{
			m_strIdPE = strIdPE;
			carregaTypDatSet();
			carregaDadosBD();
			m_strCaption = "Romaneio";
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

				m_typDatSetTbRomaneios = m_cls_dba_ConnectionBD.GetTbRomaneios(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
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
				mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow dtrwRowTbRomaneios;
				if (m_typDatSetTbRomaneios.tbRomaneios.Rows.Count > 0)
				{
					dtrwRowTbRomaneios = (mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow)m_typDatSetTbRomaneios.tbRomaneios.Rows[0];
					if (!dtrwRowTbRomaneios.IsmstrObservacaoNull())
						m_strObservacoes = dtrwRowTbRomaneios.mstrObservacao;
					else
						if (!dtrwRowTbRomaneios.IsstrObservacaoNull())
							m_strObservacoes = dtrwRowTbRomaneios.strObservacao;
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
				mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow dtrwRowTbRomaneios;
				if (m_typDatSetTbRomaneios.tbRomaneios.Rows.Count > 0)
				{
					dtrwRowTbRomaneios = (mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow)m_typDatSetTbRomaneios.tbRomaneios.Rows[0];
					if (dtrwRowTbRomaneios != null)
						dtrwRowTbRomaneios.mstrObservacao = m_strObservacoes;
				}
				m_cls_dba_ConnectionBD.SetTbRomaneios(m_typDatSetTbRomaneios);
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
