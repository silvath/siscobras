using System;

namespace mdlNumero.Faturas
{
	/// <summary>
	/// Summary description for clsNumeroProforma.
	/// </summary>
	public class clsNumeroProforma : clsNumero
	{
		#region Atributos
		private mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas m_typDatSetTbFaturasProformas = null;
		#endregion

		#region Construtores & Destrutores
		public clsNumeroProforma(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string idPE): base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador)
		{
			m_strIdPE = idPE;
			carregaTypDatSet();
			carregaDadosBD();
			m_bMascaraEditavel = false;
		}
		#endregion

		#region Carregamento de Dados
		#region Banco de Dados
		protected new void carregaTypDatSet()
		{
			try
			{
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
			
				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				m_typDatSetTbFaturasProformas = m_cls_dba_ConnectionBD.GetTbFaturasProformas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
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
				mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas.tbFaturasProformasRow dtrwRowTbFaturasProformas;
				if (m_typDatSetTbFaturasProformas.tbFaturasProformas.Rows.Count > 0)
				{
					dtrwRowTbFaturasProformas = m_typDatSetTbFaturasProformas.tbFaturasProformas.FindByidExportadoridPE(m_nIdExportador,m_strIdPE);
					if (dtrwRowTbFaturasProformas != null)
					{
						if (!dtrwRowTbFaturasProformas.IsnumeroFaturaNull())
						{
							m_strNumero = dtrwRowTbFaturasProformas.numeroFatura.Replace("\0","");
						}
						else
						{
							//m_strNumero = m_strIdPE;
							m_strNumero = "";
						}
					}
					else
					{
						//m_strNumero = m_strIdPE;
						m_strNumero = "";
					}
				}
				else
				{
					//m_strNumero = m_strIdPE;
					m_strNumero = "";
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Interface
		protected override void carregaDadosInterfaceTextGroupBox(ref System.Windows.Forms.GroupBox gbFields)
		{
			try
			{
				gbFields.Text = "Fatura Proforma";
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected override void montaLabelSugestao(ref System.Windows.Forms.Label lSugestao)
		{
			try
			{
				lSugestao.Visible = false;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#endregion
		#region Salvamento de Dados
		protected override void salvaDadosBDEspecifico()
		{
			try
			{
				int nIndex = 0;
				System.Exception erro = new System.Exception("Erro: Não é possível inserir duas faturas proformas com o mesmo número");
				mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas.tbFaturasProformasRow dtrwRowTbFaturasProformas;
				if (m_strNumero != m_strNumeroNovo)
				{
					if (m_typDatSetTbFaturasProformas.tbFaturasProformas.Rows.Count > 0)
					{
						while (nIndex < m_typDatSetTbFaturasProformas.tbFaturasProformas.Rows.Count)
						{
							dtrwRowTbFaturasProformas = (mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas.tbFaturasProformasRow)m_typDatSetTbFaturasProformas.tbFaturasProformas.Rows[nIndex];
							if (!dtrwRowTbFaturasProformas.IsnumeroFaturaNull())
							{
								if (dtrwRowTbFaturasProformas.numeroFatura != m_strNumeroNovo)
									nIndex++;
								else
									throw erro;
							}
							else
							{
								nIndex++;
							}
						}
						dtrwRowTbFaturasProformas = m_typDatSetTbFaturasProformas.tbFaturasProformas.FindByidExportadoridPE(m_nIdExportador,m_strIdPE);
						if (dtrwRowTbFaturasProformas != null)
							dtrwRowTbFaturasProformas.numeroFatura = m_strNumeroNovo;

						m_cls_dba_ConnectionBD.SetTbFaturasProformas(m_typDatSetTbFaturasProformas);
					}
				}
			}
			catch (Exception err)
			{
				throw err;
			}
		}
		#endregion
	}
}
