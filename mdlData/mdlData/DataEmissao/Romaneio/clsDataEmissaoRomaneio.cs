using System;

namespace mdlData.DataEmissao.Romaneio
{
	/// <summary>
	/// Summary description for clsDataEmissaoRomaneio.
	/// </summary>
	public class clsDataEmissaoRomaneio : clsData
	{
		#region Atributos
		private mdlDataBaseAccess.Tabelas.XsdTbRomaneios m_typDatSetTbRomaneios = null;
		private mdlDataBaseAccess.Tabelas.XsdTbExportadores m_typDatSetTbExportadores = null;
		#endregion
		#region Construtors and Destrutors
		public clsDataEmissaoRomaneio(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string idPE): base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador)
		{
			this.Format = "dd/MMM/aaaa";
			m_strIdPE = idPE;
			carregaTypDatSet();
			vCarregaDadosBD();
			this.Name = "Romaneio";
		}
		#endregion

		#region Carregamento de Dados
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

					m_typDatSetTbExportadores = m_cls_dba_ConnectionBD.GetTbExportadores(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

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
			protected override void carregaDadosBDEspecificos()
			{
				try
				{
					mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow dtrwRowTbRomaneios;
					if (m_typDatSetTbRomaneios.tbRomaneios.Rows.Count > 0)
					{
						dtrwRowTbRomaneios = (mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow)m_typDatSetTbRomaneios.tbRomaneios.Rows[0];
						if (!dtrwRowTbRomaneios.IsdtDataEmissaoNull())
							m_dtData = dtrwRowTbRomaneios.dtDataEmissao;
						if (!dtrwRowTbRomaneios.IsstrFormatoDataEmissaoNull())
							m_strFormat = dtrwRowTbRomaneios.strFormatoDataEmissao;
					}
					if (!bFormatValid())
						m_strFormat = "dd/MMM/aaaa";					
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
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow dtrwRowTbRomaneios;
				if (m_typDatSetTbRomaneios.tbRomaneios.Rows.Count > 0)
				{
					dtrwRowTbRomaneios = (mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow)m_typDatSetTbRomaneios.tbRomaneios.Rows[0];
					dtrwRowTbRomaneios.dtDataEmissao = m_dtData;
					dtrwRowTbRomaneios.strFormatoDataEmissao = m_strFormat;
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
	}
}
