using System;

namespace mdlPesos
{
	/// <summary>
	/// Summary description for clsPesosCertificadosOrigem.
	/// </summary>
	public class clsPesosCertificadosOrigem : clsPesos
	{
		#region Atributes
			private string m_strIdPe = "";
			private int m_nIdTipoCertificadoOrigem = -1;
		#endregion
		#region Constructor
			public clsPesosCertificadosOrigem(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string strEnderecoExecutavel, int nIdExportador, string strIdPe,int nIdTipoCertificadoOrigem):base(ref tratadorErro, ref ConnectionDB, strEnderecoExecutavel, nIdExportador)
			{
				m_strIdPe = strIdPe;
				m_nIdTipoCertificadoOrigem = nIdTipoCertificadoOrigem;
				m_strLabelFrame = "Certificado Origem";
				m_nIdioma = 1;
				this.carregaDadosBD();
			}
		#endregion

		#region Carregamento dos Dados
			private mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem GetTypDatSetCertificadoOrigem()
			{
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("idPe");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdPe);

				arlCondicaoCampo.Add("nIdTipoCO");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdTipoCertificadoOrigem);

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem typDatSetCertificadosOrigem = m_cls_dba_ConnectionDB.GetTbCertificadosOrigem(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				if (m_cls_dba_ConnectionDB.Erro == null)
					return(typDatSetCertificadosOrigem);
				else
					return(null);
			}

			private bool bCarregaDadosCertificadoOrigem(out double dPesoLiquido,out double dPesoBruto,out int nUnidadePesoLiquido,out int nUnidadePesoBruto)
			{
				dPesoLiquido = 0;
				dPesoBruto = 0;
				nUnidadePesoLiquido = 0;
				nUnidadePesoBruto = 0;
				mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem tyDatSetCertificadosOrigem = GetTypDatSetCertificadoOrigem();
				if ((tyDatSetCertificadosOrigem != null) && (tyDatSetCertificadosOrigem.tbCertificadosOrigem.Rows.Count > 0))
				{
					mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow dtrwCertificadoOrigem = (mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow)tyDatSetCertificadosOrigem.tbCertificadosOrigem.Rows[0];
					if (!dtrwCertificadoOrigem.IsdPesoLiquidoNull())
					{
						dPesoLiquido = dtrwCertificadoOrigem.dPesoLiquido;
						dPesoBruto = dtrwCertificadoOrigem.dPesoBruto;
						nUnidadePesoLiquido = dtrwCertificadoOrigem.nUnidadeMassaPesoLiquido;
						nUnidadePesoBruto = dtrwCertificadoOrigem.nUnidadeMassaPesoBruto;
						return(true);
					}
				}
				return(false);
			}

			private void vCarregaDadosFaturaComercial(out double dPesoLiquido,out double dPesoBruto,out int nUnidadePesoLiquido,out int nUnidadePesoBruto)
			{
				clsPesos cls_FatCom = new clsPesosFaturasComercias(ref m_cls_ter_tratadorErro, ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPe);
				dPesoLiquido = cls_FatCom.PesoLiquido;
				dPesoBruto = cls_FatCom.PesoBruto;
				nUnidadePesoLiquido = cls_FatCom.UnidadePesoLiquido;
				nUnidadePesoBruto = cls_FatCom.UnidadePesoBruto;
			}

			protected override void carregaDadosBDEspecificos()
			{
				if (!bCarregaDadosCertificadoOrigem(out m_dPesoLiquido,out m_dPesoBruto,out m_nUnidadeLiquido,out m_nUnidadeBruto))
					vCarregaDadosFaturaComercial(out m_dPesoLiquido,out m_dPesoBruto,out m_nUnidadeLiquido,out m_nUnidadeBruto);
			}
		#endregion
		#region Salvamento de Dados
			protected override void SalvaDadosBDEspecificos()
			{
				if (m_bModificado)
				{
					double dPesoLiquido;
					double dPesoBruto;
					int nUnidadePesoLiquido;
					int nUnidadePesoBruto;
					if (!bCarregaDadosCertificadoOrigem(out dPesoLiquido,out dPesoBruto,out nUnidadePesoLiquido,out nUnidadePesoBruto))
						vCarregaDadosFaturaComercial(out dPesoLiquido,out dPesoBruto,out nUnidadePesoLiquido,out nUnidadePesoBruto);
					if ((dPesoLiquido != m_dPesoLiquido) || (dPesoBruto != m_dPesoBruto) || (nUnidadePesoLiquido != m_nUnidadeLiquido) || (nUnidadePesoBruto != m_dPesoBruto))
					{
						mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem tyDatSetCertificadosOrigem = GetTypDatSetCertificadoOrigem();
						if ((tyDatSetCertificadosOrigem != null) && (tyDatSetCertificadosOrigem.tbCertificadosOrigem.Rows.Count > 0))
						{
							mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow dtrwCertificadoOrigem = (mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow)tyDatSetCertificadosOrigem.tbCertificadosOrigem.Rows[0];
							dtrwCertificadoOrigem.dPesoLiquido = m_dPesoLiquido;
							dtrwCertificadoOrigem.dPesoBruto = m_dPesoBruto;
							dtrwCertificadoOrigem.nUnidadeMassaPesoLiquido = m_nUnidadeLiquido;
							dtrwCertificadoOrigem.nUnidadeMassaPesoBruto = m_nUnidadeBruto;
							m_cls_dba_ConnectionDB.SetTbCertificadosOrigem(tyDatSetCertificadosOrigem);
						}
					} 
				}
			}
		#endregion
	}
}
