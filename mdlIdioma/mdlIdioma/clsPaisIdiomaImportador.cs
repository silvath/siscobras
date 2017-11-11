using System;

namespace mdlIdioma
{
	/// <summary>
	/// Summary description for clsPaisIdiomaImportador.
	/// </summary>
	public class clsPaisIdiomaImportador: clsPaisIdioma
	{
		#region Atributos
			protected int m_nIdExportador = -1;
			protected int m_nIdImportador = -1;

			private mdlDataBaseAccess.Tabelas.XsdTbImportadores m_typDatSetTbImportadores;
		#endregion

		#region Construtores & Destrutores
			public clsPaisIdiomaImportador(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel, int nIdExportador, int nIdImportador, int nIdioma, ref System.Windows.Forms.ImageList bandeiras): base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdioma, ref bandeiras)
			{
				m_nIdExportador = nIdExportador;
				m_nIdImportador = nIdImportador;
					
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
					
					m_typDatSetTbImportadores = m_cls_dba_ConnectionDB.GetTbImportadores(arlCondicoesNome,arlCondicoesComparador,arlCondicoesValor,null,null);
					if ( m_typDatSetTbImportadores.tbImportadores.Rows.Count > 0)
					{
						mdlDataBaseAccess.Tabelas.XsdTbImportadores.tbImportadoresRow dtrwImportadores;
						dtrwImportadores = (mdlDataBaseAccess.Tabelas.XsdTbImportadores.tbImportadoresRow)m_typDatSetTbImportadores.tbImportadores.Rows[0];
						if (!dtrwImportadores.IsidPaisCliNull()) 
						{
							m_nIdPais = dtrwImportadores.idPaisCli;
							m_nIdPaisInicial = dtrwImportadores.idPaisCli;
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
					mdlDataBaseAccess.Tabelas.XsdTbImportadores.tbImportadoresRow dtrwImportadores;
					dtrwImportadores = m_typDatSetTbImportadores.tbImportadores.FindByidExportadoridImportador(m_nIdExportador,m_nIdImportador);
					if (dtrwImportadores != null)
					{
						dtrwImportadores.idPaisCli = m_nIdPais;
						m_cls_dba_ConnectionDB.SetTbImportadores(m_typDatSetTbImportadores);
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
