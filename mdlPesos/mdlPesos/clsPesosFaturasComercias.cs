using System;

namespace mdlPesos
{
	/// <summary>
	/// Summary description for clsPesosFaturasComercias.
	/// </summary>
	public class clsPesosFaturasComercias: clsPesos
	{
		#region Atributos
			private mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais m_typDatSetTbFaturasComerciais = null;
			private string m_strIdCotacao = "";
		#endregion
		#region Construtors and Destrutors
		public clsPesosFaturasComercias(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel, int Exportador, string strIdCotacao):base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, Exportador)
		{
			try 
			{
				m_strIdCotacao = strIdCotacao;
				m_strLabelFrame = "Fatura Comercial";
				carregaTypDatSetEspecificos();
				this.carregaDadosBD();
			} 
			catch (Exception err) 
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Carregamento dos Dados
			#region Banco Dados
			private void carregaTypDatSetEspecificos()
			{
				try
				{
					System.Collections.ArrayList arlCondicoesNome = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesValor = new System.Collections.ArrayList();
					arlCondicoesNome.Add("idExportador");
					arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicoesValor.Add(m_nIdExportador);
					arlCondicoesNome.Add("idPE");
					arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicoesValor.Add(m_strIdCotacao);
					m_typDatSetTbFaturasComerciais = m_cls_dba_ConnectionDB.GetTbFaturasComerciais(arlCondicoesNome,arlCondicoesComparador,arlCondicoesValor,null,null);
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
					if (m_typDatSetTbFaturasComerciais == null)
						carregaTypDatSetEspecificos();
					if (m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows.Count > 0)
					{
						mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwFaturas = (mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow)m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows[0];
						if (!dtrwFaturas.IspesoBrutoNull())
							m_dPesoBruto = dtrwFaturas.pesoBruto;
						if (!dtrwFaturas.IspesoLiquidoNull())
							m_dPesoLiquido = dtrwFaturas.pesoLiquido;
						if (!dtrwFaturas.IsnUnidadeMassaPesoBrutoNull())
							m_nUnidadeBruto = dtrwFaturas.nUnidadeMassaPesoBruto;
						else
							m_nUnidadeBruto = 3;
						if (!dtrwFaturas.IsnUnidadeMassaPesoLiquidoNull())
							m_nUnidadeLiquido = dtrwFaturas.nUnidadeMassaPesoLiquido;
						else
							m_nUnidadeLiquido = 3;
						if (!dtrwFaturas.IsidIdiomaNull())
							m_nIdioma = dtrwFaturas.idIdioma;
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
		#region Salvamento de Dados
			#region Banco Dados 
			protected override void SalvaDadosBDEspecificos()
			{
				try 
				{
					if (m_bModificado)
					{
						if (m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows.Count > 0)
						{
							mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwFaturas = m_typDatSetTbFaturasComerciais.tbFaturasComerciais.FindByidExportadoridPE(m_nIdExportador,m_strIdCotacao);//(mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow)m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows[0];
							if (dtrwFaturas != null)
							{
								dtrwFaturas.pesoBruto = m_dPesoBruto;
								dtrwFaturas.pesoLiquido = m_dPesoLiquido;
								dtrwFaturas.nUnidadeMassaPesoBruto = m_nUnidadeBruto;
								dtrwFaturas.nUnidadeMassaPesoLiquido = m_nUnidadeLiquido;
								m_cls_dba_ConnectionDB.SetTbFaturasComerciais(m_typDatSetTbFaturasComerciais);
							}
						}
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
	}
}
