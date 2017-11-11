using System;

namespace mdlIdioma
{
	/// <summary>
	/// Summary description for clsPaisIdiomaEnderecoEntregaImportador.
	/// </summary>
	public class clsPaisIdiomaEnderecoEntregaImportador: clsPaisIdioma
	{
		#region Atributos
			protected int m_nIdEndEntrega = -1;
			protected int m_nIdExportador = -1;
			protected int m_nIdImportador = -1;

			private mdlDataBaseAccess.Tabelas.XsdTbImportadoresEndEntrega m_typDatSetTbImportadoresEndEntrega;
		#endregion

		#region Construtores & Destrutores
			public clsPaisIdiomaEnderecoEntregaImportador(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel, int nIdExportador,  int nIdImportador, int nIdEndEntrega, int nIdioma, ref System.Windows.Forms.ImageList bandeiras): base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdioma, ref bandeiras)
			{
				m_nIdExportador = nIdExportador;
				m_nIdImportador = nIdImportador;
				m_nIdEndEntrega = nIdEndEntrega;
				
				this.carregaDadosBD();
			}
		#endregion

		#region Carregamento de Dados
			#region Banco de Dados
			protected override void carregaDadosBDEspecificos()
			{
				try 
				{
					System.Collections.ArrayList arlCondicoesNome = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesValor = new System.Collections.ArrayList();
					arlCondicoesNome.Add("idExportador");
					arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicoesValor.Add(m_nIdExportador);
					arlCondicoesNome.Add("idImportador");
					arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicoesValor.Add(m_nIdImportador);
					arlCondicoesNome.Add("idEndEntrega");
					arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicoesValor.Add(m_nIdEndEntrega);

					m_typDatSetTbImportadoresEndEntrega = m_cls_dba_ConnectionDB.GetTbImportadoresEndEntrega(arlCondicoesNome,arlCondicoesComparador,arlCondicoesValor,null,null);
					if ( m_typDatSetTbImportadoresEndEntrega.tbImportadoresEndEntrega.Rows.Count > 0)
					{
						mdlDataBaseAccess.Tabelas.XsdTbImportadoresEndEntrega.tbImportadoresEndEntregaRow dtrwImportadoresEndEntrega;
						dtrwImportadoresEndEntrega = (mdlDataBaseAccess.Tabelas.XsdTbImportadoresEndEntrega.tbImportadoresEndEntregaRow)m_typDatSetTbImportadoresEndEntrega.tbImportadoresEndEntrega.Rows[0];
						if (!dtrwImportadoresEndEntrega.IsidPaisEntrCliNull()) 
						{
							m_nIdPais = dtrwImportadoresEndEntrega.idPaisEntrCli;
							m_nIdPaisInicial = dtrwImportadoresEndEntrega.idPaisEntrCli;
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
		#region Salvamento de Dados
			#region Banco Dados 
			protected override void SalvaDadosBDEspecificos()
			{
				try 
				{
					if (m_bModificado)
					{
						mdlDataBaseAccess.Tabelas.XsdTbImportadoresEndEntrega.tbImportadoresEndEntregaRow dtrwImportadoresEndEntrega;
						dtrwImportadoresEndEntrega = m_typDatSetTbImportadoresEndEntrega.tbImportadoresEndEntrega.FindByidExportadoridImportadoridEndEntrega(m_nIdExportador,m_nIdImportador,m_nIdEndEntrega);
						if (dtrwImportadoresEndEntrega != null)
						{
							dtrwImportadoresEndEntrega.idPaisEntrCli = m_nIdPais;
							m_cls_dba_ConnectionDB.SetTbImportadoresEndEntrega(m_typDatSetTbImportadoresEndEntrega);
						}						
					}
					if (m_bPaisIdiomaModificado)
					{
						mdlDataBaseAccess.Tabelas.XsdTbPaisesIdiomas.tbPaisesIdiomasRow dtrwPaisesIdiomas;
						dtrwPaisesIdiomas = m_typDatSetTbPaisesIdiomas.tbPaisesIdiomas.FindByidPaisidIdioma(m_nIdPais,m_nIdioma);
						if (dtrwPaisesIdiomas != null)
						{
							dtrwPaisesIdiomas.nmPais = m_strPaisIdioma;
							m_cls_dba_ConnectionDB.SetTbPaisesIdiomas(m_typDatSetTbPaisesIdiomas);
						} 
						else 
						{
							m_typDatSetTbPaisesIdiomas.tbPaisesIdiomas.AddtbPaisesIdiomasRow(m_nIdPais,m_nIdioma,m_strPaisIdioma);
							m_cls_dba_ConnectionDB.SetTbPaisesIdiomas(m_typDatSetTbPaisesIdiomas);
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
