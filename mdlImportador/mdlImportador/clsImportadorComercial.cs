using System;

namespace mdlImportador
{
	/// <summary>
	/// Summary description for clsImportadorComercial.
	/// </summary>
	public class clsImportadorComercial : clsImportador
	{
		#region Atributos
		protected string m_strIdPE = "";
		protected mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais m_typDatSetTbFaturasComerciais;
		#endregion

		#region Construtores & Destrutores
		public clsImportadorComercial(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string strIdPE ,int nIdImportador,ref System.Windows.Forms.ImageList bandeiras): base(ref tratadorErro, ref ConnectionDB,EnderecoExecutavel,nIdExportador,nIdImportador,ref bandeiras)
		{
			m_strIdPE = strIdPE;
			this.inicializaTypDatSet();
			this.carregaDadosBD();
			this.carregaDadosBDCadEdit();
		}
		public clsImportadorComercial(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string strIdPE ,ref System.Windows.Forms.ImageList bandeiras): base(ref tratadorErro, ref ConnectionDB,EnderecoExecutavel,nIdExportador,ref bandeiras)
		{
			m_strIdPE = strIdPE;
			this.inicializaTypDatSet();
			this.carregaDadosBD();
			this.carregaDadosBDCadEdit();
		}
		#endregion

		#region Inicializa variável TypDatSet
		protected new void inicializaTypDatSet()
		{
			base.inicializaTypDatSet();
			System.Collections.ArrayList arlCondicoesCampo = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicoesComparador = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicoesValor = new System.Collections.ArrayList();
			arlCondicoesCampo.Add("idExportador");
			arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicoesValor.Add(m_nIdExportador);

			m_typDatSetTbFaturasComerciais = m_cls_dba_ConnectionDB.GetTbFaturasComerciais(arlCondicoesCampo,arlCondicoesComparador,arlCondicoesValor,null,null);
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
						mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwRowTbFaturasComerciais;
						dtrwRowTbFaturasComerciais = m_typDatSetTbFaturasComerciais.tbFaturasComerciais.FindByidExportadoridPE(m_nIdExportador,m_strIdPE);
						if (dtrwRowTbFaturasComerciais == null)
						{
							mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow dtrwRowTbExportadores;
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
							if (!dtrwRowTbFaturasComerciais.IsidImportadorNull())
							{
								m_nIdImportador = dtrwRowTbFaturasComerciais.idImportador;
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
						// Atualizando Tabela Faturas Comerciais
						mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwRowFaturasComerciais;
						dtrwRowFaturasComerciais = m_typDatSetTbFaturasComerciais.tbFaturasComerciais.FindByidExportadoridPE(m_nIdExportador,m_strIdPE);
						if (dtrwRowFaturasComerciais != null)
						{
							dtrwRowFaturasComerciais.idImportador = m_nIdImportador;
							m_cls_dba_ConnectionDB.SetTbFaturasComerciais(m_typDatSetTbFaturasComerciais);
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
