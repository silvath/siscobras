using System;

namespace mdlData.DataEmissao.Saque
{
	/// <summary>
	/// Summary description for clsDataEmissaoSaque.
	/// </summary>
	public class clsDataEmissaoSaque : clsData
	{
		#region Atributos
		private mdlDataBaseAccess.Tabelas.XsdTbSaques m_typDatSetTbSaques = null;
		private mdlDataBaseAccess.Tabelas.XsdTbExportadores m_typDatSetTbExportadores = null;
		#endregion
		#region Construtors and Destrutors
			public clsDataEmissaoSaque(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string idPE): base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador)
			{
				m_strIdPE = idPE;
				carregaTypDatSet();
				vCarregaDadosBD();
				this.Name = "Saque";
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

					m_typDatSetTbSaques = m_cls_dba_ConnectionBD.GetTbSaques(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
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
					mdlDataBaseAccess.Tabelas.XsdTbSaques.tbSaquesRow dtrwRowTbSaques;
					mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow dtrwRowTbExportadores;
					if (m_typDatSetTbSaques.tbSaques.Rows.Count > 0)
					{
						dtrwRowTbSaques = (mdlDataBaseAccess.Tabelas.XsdTbSaques.tbSaquesRow)m_typDatSetTbSaques.tbSaques.Rows[0];
						// Idioma 
						if (!dtrwRowTbSaques.IsnIdIdiomaNull())
							this.Idioma = dtrwRowTbSaques.nIdIdioma;
						if (!dtrwRowTbSaques.IsdtDataEmissaoNull())
							m_dtData = dtrwRowTbSaques.dtDataEmissao;
						if (!dtrwRowTbSaques.IsstrFormatoDataEmissaoNull())
							m_strFormat = dtrwRowTbSaques.strFormatoDataEmissao;
					}
					if ((m_typDatSetTbExportadores.tbExportadores.Rows.Count > 0) && (m_strFormat == ""))
					{
						dtrwRowTbExportadores = (mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow)m_typDatSetTbExportadores.tbExportadores.Rows[0];
						if (!dtrwRowTbExportadores.IsformatoDataFaturaNull())
							m_strFormat = dtrwRowTbExportadores.formatoDataFatura;
					}
					if (!bFormatValid())
						m_strFormat = "dd/MM/aaaa";					
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
				mdlDataBaseAccess.Tabelas.XsdTbSaques.tbSaquesRow dtrwRowTbSaques;
				mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow dtrwRowTbExportadores;
				if (m_typDatSetTbSaques.tbSaques.Rows.Count > 0)
				{
					dtrwRowTbSaques = (mdlDataBaseAccess.Tabelas.XsdTbSaques.tbSaquesRow)m_typDatSetTbSaques.tbSaques.Rows[0];
					dtrwRowTbSaques.dtDataEmissao = m_dtData;
					dtrwRowTbSaques.strFormatoDataEmissao = m_strFormat;
				}
				if (m_typDatSetTbExportadores.tbExportadores.Rows.Count > 0)
				{
					dtrwRowTbExportadores = (mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow)m_typDatSetTbExportadores.tbExportadores.Rows[0];
					dtrwRowTbExportadores.formatoDataFatura = m_strFormat;
				}
				m_cls_dba_ConnectionBD.SetTbSaques(m_typDatSetTbSaques);
				m_cls_dba_ConnectionBD.SetTbExportadores(m_typDatSetTbExportadores);
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
