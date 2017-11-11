using System;

namespace mdlPesos
{
	/// <summary>
	/// Summary description for clsPesosRomaneio.
	/// </summary>
	public class clsPesosRomaneio
	{
		#region Atributes
			private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro; 
			private mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB;
			private string m_strEnderecoExecutavel; 

			private int m_nIdExportador;
			private string m_strIdPe;

			private bool m_bModificado = false;

			private int m_nIdTipoRomaneio = -1;
			private string m_strPesoLiquido = "";
			private string m_strPesoBruto = "";
			private mdlConstantes.UnidadeMassa m_enumUnidadeMassaPesoLiquido = mdlConstantes.UnidadeMassa.Kilograma;
			private mdlConstantes.UnidadeMassa m_enumUnidadeMassaPesoBruto = mdlConstantes.UnidadeMassa.Kilograma;

			private mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassa m_typDatSetUnidadesMassa = null;
			private mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassaIdioma m_typDatSetUnidadesMassaIdioma = null;

			private frmFPesosUnidade m_formFPesos = null;
		#endregion
		#region Properties
			public bool Modificado
			{
				get
				{
					return(m_bModificado);
				}
			}
		#endregion
		#region Constructors and Destructors
			public clsPesosRomaneio(ref mdlTratamentoErro.clsTratamentoErro cls_ter_tratadorErro , ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB , string strEnderecoExecutavel,int nIdExportador, string strIdPe)
			{
				m_cls_ter_tratadorErro = cls_ter_tratadorErro; 
				m_cls_dba_ConnectionDB = cls_dba_ConnectionDB;
				m_strEnderecoExecutavel = strEnderecoExecutavel; 

				m_nIdExportador = nIdExportador;
				m_strIdPe = strIdPe;

				vCarregaDados();
			}
		#endregion

		#region Carregamento dos Dados
			private void vCarregaDados()
			{
				vCarregaDadosUnidades();
				vCarregaDadosRomaneio();
				vCarregaDadosRomaneioProdutos();
			}

			private mdlDataBaseAccess.Tabelas.XsdTbRomaneios GetTypdatSettbRomaneios()
			{
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);
				arlCondicaoCampo.Add("idPE");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdPe);

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				return(m_cls_dba_ConnectionDB.GetTbRomaneios(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null));
			}

			private void vCarregaDadosRomaneio()
			{
				mdlDataBaseAccess.Tabelas.XsdTbRomaneios typDatSetTbRomaneios = GetTypdatSettbRomaneios();
				if (typDatSetTbRomaneios.tbRomaneios.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow dtrwRomaneio = (mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow)typDatSetTbRomaneios.tbRomaneios.Rows[0];
					// Tipo
					if (!dtrwRomaneio.IsnTipoOrdenacaoNull())
						m_nIdTipoRomaneio = dtrwRomaneio.nTipoOrdenacao;

					// Unidade Peso Liquido
					if (!dtrwRomaneio.IsnUnidadeMassaPesoLiquidoNull())
						m_enumUnidadeMassaPesoLiquido = (mdlConstantes.UnidadeMassa)dtrwRomaneio.nUnidadeMassaPesoLiquido;

					// Unidade Peso Bruto
					if (!dtrwRomaneio.IsnUnidadeMassaPesoBrutoNull())
						m_enumUnidadeMassaPesoBruto = (mdlConstantes.UnidadeMassa)dtrwRomaneio.nUnidadeMassaPesoBruto;
				}
			}

			private void vCarregaDadosRomaneioProdutos()
			{
				switch(m_nIdTipoRomaneio)
				{
                    case (int)mdlConstantes.Relatorio.Romaneio:
					case (int)mdlConstantes.Relatorio.RomaneioVolumes:
						vCarregaDadosRomaneioProdutosVolume();
						break;
					case (int)mdlConstantes.Relatorio.RomaneioSimplificado:
						vCarregaDadosRomaneioProdutosSimplificado();
						break;
				}
			}

			private void vCarregaDadosRomaneioProdutosVolume()
			{
				mdlProdutosRomaneio.clsProdutosRomaneio produtos = new mdlProdutosRomaneio.clsProdutosRomaneio(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPe);
				produtos.vRetornaValores(m_enumUnidadeMassaPesoLiquido,out m_strPesoLiquido,m_enumUnidadeMassaPesoBruto,out m_strPesoBruto);
			}

			private void vCarregaDadosRomaneioProdutosSimplificado()
			{
				mdlProdutosRomaneio.clsProdutosRomaneioSimplificado produtos = new mdlProdutosRomaneio.clsProdutosRomaneioSimplificado(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPe);
				produtos.vRetornaValores(m_enumUnidadeMassaPesoLiquido,out m_strPesoLiquido,m_enumUnidadeMassaPesoBruto,out m_strPesoBruto);
			}

			private void vCarregaDadosUnidades()
			{
				// Loading DataSets 
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
				m_typDatSetUnidadesMassa = m_cls_dba_ConnectionDB.GetTbUnidadesMassa(null,null,null,null,null);

				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
				arlCondicaoCampo.Add("nIdIdioma");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add((int)mdlConstantes.Idioma.Portugues);
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
				m_typDatSetUnidadesMassaIdioma = m_cls_dba_ConnectionDB.GetTbUnidadesMassaIdioma(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
			}
		#endregion
		#region Salvamento dos Dados
			private bool bSalvaDados()
			{
				return(bSalvaDadosRomaneio());
			}

			private bool bSalvaDadosRomaneio()
			{
				mdlDataBaseAccess.Tabelas.XsdTbRomaneios typDatSetTbRomaneios = GetTypdatSettbRomaneios();
				if (typDatSetTbRomaneios.tbRomaneios.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow dtrwRomaneio = (mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow)typDatSetTbRomaneios.tbRomaneios.Rows[0];
					// Unidade Peso Liquido
					dtrwRomaneio.nUnidadeMassaPesoLiquido = (int)m_enumUnidadeMassaPesoLiquido;

					// Unidade Peso Bruto
					dtrwRomaneio.nUnidadeMassaPesoBruto = (int)m_enumUnidadeMassaPesoBruto;
				}
				m_cls_dba_ConnectionDB.SetTbRomaneios(typDatSetTbRomaneios);
				return(m_cls_dba_ConnectionDB.Erro == null);
			}


		#endregion

		#region ShowDialog
			public bool ShowDialog()
			{
				m_formFPesos = new frmFPesosUnidade(m_strEnderecoExecutavel);
				vInitializeEvents(ref m_formFPesos);
				vUpdatePesoLiquido();
				vUpdatePesoBruto();
				m_formFPesos.ShowDialog();
				if (m_bModificado = m_formFPesos.Modificado)
					return(bSalvaDados());
				else
					return(false);
			}

			private void vInitializeEvents(ref frmFPesosUnidade formFPesos)
			{
				formFPesos.eCallModificaPesoLiquido += new frmFPesosUnidade.delCallModificaPesoLiquido(vModifyPesoLiquido); 
				formFPesos.eCallModificaPesoBruto += new frmFPesosUnidade.delCallModificaPesoBruto(vModifyPesoBruto);
			}
		#endregion

		#region Pesos
			private void vModifyPesoLiquido()
			{
				m_enumUnidadeMassaPesoLiquido = (mdlConstantes.UnidadeMassa)clsPesos.nRetornaProximaUnidadeMassa((int)m_enumUnidadeMassaPesoLiquido);
				vCarregaDadosRomaneioProdutos();
				vUpdatePesoLiquido();

			}
        
			private void vModifyPesoBruto()
			{
				m_enumUnidadeMassaPesoBruto = (mdlConstantes.UnidadeMassa)clsPesos.nRetornaProximaUnidadeMassa((int)m_enumUnidadeMassaPesoBruto);
				vCarregaDadosRomaneioProdutos();
				vUpdatePesoBruto();
			}

			private void vUpdatePesoLiquido()
			{
				if (m_formFPesos != null)
				{
					m_formFPesos.PesoLiquido = m_strPesoLiquido;
					m_formFPesos.PesoLiquidoUnidade = clsPesos.strSiglaUnidadeMassa(ref m_typDatSetUnidadesMassa,ref m_typDatSetUnidadesMassaIdioma,(int)m_enumUnidadeMassaPesoLiquido);
				}
			}

			private void vUpdatePesoBruto()
			{
				if (m_formFPesos != null)
				{
					m_formFPesos.PesoBruto = m_strPesoBruto;
					m_formFPesos.PesoBrutoUnidade = clsPesos.strSiglaUnidadeMassa(ref m_typDatSetUnidadesMassa,ref m_typDatSetUnidadesMassaIdioma,(int)m_enumUnidadeMassaPesoBruto);
				}
			}
		#endregion

		#region Retorno
			public void vRetornaValores(out string strPesoLiquido,out string strPesoBruto)
			{
				strPesoLiquido = m_strPesoLiquido;
				if (strPesoLiquido != "")
					strPesoLiquido += " " +  clsPesos.strSiglaUnidadeMassa(ref m_typDatSetUnidadesMassa,ref m_typDatSetUnidadesMassaIdioma,(int)m_enumUnidadeMassaPesoLiquido);
				strPesoBruto = m_strPesoBruto;
				if (strPesoBruto != "")
					strPesoBruto += " " +  clsPesos.strSiglaUnidadeMassa(ref m_typDatSetUnidadesMassa,ref m_typDatSetUnidadesMassaIdioma,(int)m_enumUnidadeMassaPesoBruto);
			}
		#endregion
	}
}
