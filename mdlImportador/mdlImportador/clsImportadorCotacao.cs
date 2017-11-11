using System;

namespace mdlImportador
{
	/// <summary>
	/// Summary description for clsImportadorCotacao.
	/// </summary>
	public class clsImportadorCotacao : clsImportador
	{
		
		#region Atributos
		protected string m_strIdCotacao = "";
		protected mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes m_typDatSetTbFaturasCotacoes;
		#endregion

		#region Construtores & Destrutores
		public clsImportadorCotacao(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string strIdCotacao ,int nIdImportador,ref System.Windows.Forms.ImageList bandeiras): base(ref tratadorErro, ref ConnectionDB,EnderecoExecutavel,nIdExportador,nIdImportador,ref bandeiras)
		{
			m_strIdCotacao = strIdCotacao;
			inicializaTypDatSet();
			this.carregaDadosBD();
			this.carregaDadosBDCadEdit();
		}
		public clsImportadorCotacao(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string strIdCotacao ,ref System.Windows.Forms.ImageList bandeiras): base(ref tratadorErro, ref ConnectionDB,EnderecoExecutavel,nIdExportador,ref bandeiras)
		{
			m_strIdCotacao = strIdCotacao;
			inicializaTypDatSet();
			this.carregaDadosBD();
			this.carregaDadosBDCadEdit();
		}
		#endregion
		#region Iniciliaza variáveis TypDatSet
		protected new void inicializaTypDatSet()
		{
			base.inicializaTypDatSet();
			System.Collections.ArrayList arlCondicoesCampo = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicoesComparador = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicoesValor = new System.Collections.ArrayList();
			arlCondicoesCampo.Add("idExportador");
			arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicoesValor.Add(m_nIdExportador);

			m_typDatSetTbFaturasCotacoes = m_cls_dba_ConnectionDB.GetTbFaturasCotacoes(arlCondicoesCampo,arlCondicoesComparador,arlCondicoesValor,null,null);
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
						mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow dtrwRowTbFaturasCotacoes;
						dtrwRowTbFaturasCotacoes = m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.FindByidExportadoridCotacao(m_nIdExportador,m_strIdCotacao);
						if (dtrwRowTbFaturasCotacoes == null)
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
							if (!dtrwRowTbFaturasCotacoes.IsidImportadorNull())
							{
								m_nIdImportador = dtrwRowTbFaturasCotacoes.idImportador;
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
						// Atualizando Tabela Faturas Cotações
						mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow dtrwRowFaturasCotacoes;
						dtrwRowFaturasCotacoes = m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.FindByidExportadoridCotacao(m_nIdExportador,m_strIdCotacao);
						if (dtrwRowFaturasCotacoes != null)
						{
							dtrwRowFaturasCotacoes.idImportador = m_nIdImportador;
							m_cls_dba_ConnectionDB.SetTbFaturasCotacoes(m_typDatSetTbFaturasCotacoes);
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
