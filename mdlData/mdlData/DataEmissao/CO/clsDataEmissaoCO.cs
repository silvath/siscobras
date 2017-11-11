using System;

namespace mdlData.DataEmissao.CO
{
	/// <summary>
	/// Summary description for clsDataCO.
	/// </summary>
	public abstract class clsDataEmissaoCO : clsData
	{
		#region Atributos
		protected int m_nIdTipoCO = -1;

		private mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem m_typDatSetTbCertificadosOrigem;
		private mdlDataBaseAccess.Tabelas.XsdTbExportadores m_typDatSetTbExportadores;
		#endregion

		#region Construtores & Destrutores
		public clsDataEmissaoCO(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string strIdPE, int idTipoCO): base(ref tratadorErro, ref ConnectionDB,EnderecoExecutavel,nIdExportador)
		{
			m_nIdTipoCO = idTipoCO;
			m_strIdPE = strIdPE;
			carregaTypDatSet();
			vCarregaDadosBD();
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

				m_typDatSetTbExportadores = m_cls_dba_ConnectionBD.GetTbExportadores(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				arlCondicaoCampo.Add("idPE");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdPE);

				arlCondicaoCampo.Add("nIdTipoCO");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdTipoCO);

				m_typDatSetTbCertificadosOrigem = m_cls_dba_ConnectionBD.GetTbCertificadosOrigem(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
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
				mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow dtrwRowTbCertificadosOrigem;
				mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow dtrwRowTbExportadores;
				if (m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.Rows.Count > 0)
				{
					dtrwRowTbCertificadosOrigem = (mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow)m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.Rows[0];
					if (!dtrwRowTbCertificadosOrigem.IsdtDataCONull())
						m_dtData = dtrwRowTbCertificadosOrigem.dtDataCO;
					if (!dtrwRowTbCertificadosOrigem.IsstrFormatoDatasNull())
						m_strFormat = dtrwRowTbCertificadosOrigem.strFormatoDatas;
					else if (m_typDatSetTbExportadores.tbExportadores.Rows.Count > 0)
					{
						dtrwRowTbExportadores = (mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow)m_typDatSetTbExportadores.tbExportadores.Rows[0];
						if (!dtrwRowTbExportadores.IsformatoDataCONull())
							m_strFormat = dtrwRowTbExportadores.formatoDataCO;
					}
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
		#region Interface
//		protected override void carregaDadosInterfaceGroupBoxText(ref System.Windows.Forms.GroupBox gbFields)
//		{
//			try
//			{
//				gbFields.Text = "Observações da Fatura Cotação";
//			}
//			catch (Exception err)
//			{
//				Object erro = err;
//				m_cls_ter_tratadorErro.trataErro(ref erro);
//			}
//		}
		#endregion
		#endregion
		#region Salvamento dos Dados
		#region Banco de Dados
		protected override void salvaDadosBDEspecifico()
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow dtrwRowTbCertificadosOrigem;
				mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow dtrwRowTbExportadores;
				if (m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.Rows.Count > 0)
				{
					dtrwRowTbCertificadosOrigem = (mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow)m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.Rows[0];
					if (dtrwRowTbCertificadosOrigem != null)
					{
						dtrwRowTbCertificadosOrigem.dtDataCO = m_dtData;
						dtrwRowTbCertificadosOrigem.strFormatoDatas = m_strFormat;
					}
				}
				if (m_typDatSetTbExportadores.tbExportadores.Rows.Count > 0)
				{
					dtrwRowTbExportadores = (mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow)m_typDatSetTbExportadores.tbExportadores.Rows[0];
					if (dtrwRowTbExportadores != null)
						dtrwRowTbExportadores.formatoDataCO = m_strFormat;
				}
				m_cls_dba_ConnectionBD.SetTbExportadores(m_typDatSetTbExportadores);
				m_cls_dba_ConnectionBD.SetTbCertificadosOrigem(m_typDatSetTbCertificadosOrigem);
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
