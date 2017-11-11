using System;

namespace mdlImportador
{
	/// <summary>
	/// Summary description for clsImportadorProforma.
	/// </summary>
	public class clsImportadorProforma : clsImportador
	{
		#region Atributos
		protected string m_strIdPE = "";
		protected mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas m_typDatSetTbFaturasProformas;
		#endregion

		#region Construtores & Destrutores
		public clsImportadorProforma(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string strIdPE ,int nIdImportador,ref System.Windows.Forms.ImageList bandeiras): base(ref tratadorErro, ref ConnectionDB,EnderecoExecutavel,nIdExportador,nIdImportador,ref bandeiras)
		{
			m_strIdPE = strIdPE;
			inicializaTypDatSet();
			this.carregaDadosBD();
			this.carregaDadosBDCadEdit();
		}
		public clsImportadorProforma(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string strIdPE ,ref System.Windows.Forms.ImageList bandeiras): base(ref tratadorErro, ref ConnectionDB,EnderecoExecutavel,nIdExportador,ref bandeiras)
		{
			m_strIdPE = strIdPE;
			inicializaTypDatSet();
			this.carregaDadosBD();
			this.carregaDadosBDCadEdit();
		}
		#endregion
		#region Inicializa variáveis TypDatSet
		protected new void inicializaTypDatSet()
		{
			base.inicializaTypDatSet();
			System.Collections.ArrayList arlCondicoesCampo = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicoesComparador = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicoesValor = new System.Collections.ArrayList();
			arlCondicoesCampo.Add("idExportador");
			arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicoesValor.Add(m_nIdExportador);

			m_typDatSetTbFaturasProformas = m_cls_dba_ConnectionDB.GetTbFaturasProformas(arlCondicoesCampo,arlCondicoesComparador,arlCondicoesValor,null,null);
		}
		#endregion

		#region Carregamento de Dados
			#region Banco de Dados
			protected override void carregaDadosBDEspecificos()
			{
				try
				{
					if (m_nIdImportador == -1)
					{
						mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas.tbFaturasProformasRow dtrwRowTbFaturasProformas;
						m_typDatSetTbFaturasProformas = m_cls_dba_ConnectionDB.GetTbFaturasProformas(null,null,null,null,null);
						dtrwRowTbFaturasProformas = m_typDatSetTbFaturasProformas.tbFaturasProformas.FindByidExportadoridPE(m_nIdExportador,m_strIdPE);
						if (dtrwRowTbFaturasProformas == null)
						{
							mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow dtrwRowTbExportadores;
							m_typDatSetTbExportadores = m_cls_dba_ConnectionDB.GetTbExportadores(null,null,null,null,null);
							dtrwRowTbExportadores = m_typDatSetTbExportadores.tbExportadores.FindByidExportador(m_nIdExportador);
							if (dtrwRowTbExportadores != null)
							{
								if (!dtrwRowTbExportadores.IsidImportadorNull())
								{
									m_nIdImportador = dtrwRowTbExportadores.idImportador;
								}
							}
						} 
						else
						{
							if (!dtrwRowTbFaturasProformas.IsidImportadorNull())
							{
								m_nIdImportador = dtrwRowTbFaturasProformas.idImportador;
							}
						}
					}
					mdlDataBaseAccess.Tabelas.XsdTbImportadores.tbImportadoresRow dtrwRowTbImportadores;
					dtrwRowTbImportadores = m_typDatSetTbImportadores.tbImportadores.FindByidExportadoridImportador(m_nIdExportador,m_nIdImportador);
					if ((dtrwRowTbImportadores != null) && (!dtrwRowTbImportadores.IsnmCliNull()))
                        m_strImportador = dtrwRowTbImportadores.nmCli;
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}		
			#endregion
			#region Interface
			protected override void carregaDadosInterfaceEspecifico()
			{
			}
			#endregion
		#endregion
		#region Salvamento dos Dados
			#region Banco de Dados
			protected override void salvaDadosBDEspecifico()
			{
				try
				{
					if (m_bModificado)
					{
						// Atualizando Tabela Exportadores
						mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow dtrwRowExportadores;
						dtrwRowExportadores = m_typDatSetTbExportadores.tbExportadores.FindByidExportador(m_nIdExportador);
						if (dtrwRowExportadores != null)
						{
							dtrwRowExportadores.idImportador = m_nIdImportador;
							m_cls_dba_ConnectionDB.SetTbExportadores(m_typDatSetTbExportadores);
						}
						// Atualizando Tabela Faturas Proformas
						mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas.tbFaturasProformasRow dtrwRowFaturasProformas;
						dtrwRowFaturasProformas = m_typDatSetTbFaturasProformas.tbFaturasProformas.FindByidExportadoridPE(m_nIdExportador,m_strIdPE);
						if (dtrwRowFaturasProformas != null)
						{
							dtrwRowFaturasProformas.idImportador = m_nIdImportador;
							m_cls_dba_ConnectionDB.SetTbFaturasProformas(m_typDatSetTbFaturasProformas);
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
