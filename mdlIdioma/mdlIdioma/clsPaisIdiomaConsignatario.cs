using System;

namespace mdlIdioma
{
	/// <summary>
	/// Summary description for clsPaisIdiomaConsignatario.
	/// </summary>
	public class clsPaisIdiomaConsignatario: clsPaisIdioma
	{
		#region Atributos
		protected int m_nIdConsignatario = -1;
		protected int m_nIdPaisConsignatario = -1;
		protected int m_nIdExportador = -1;
		protected int m_nIdImportador = -1;


		private mdlDataBaseAccess.Tabelas.XsdTbImportadoresConsignatarios m_typDatSetTbImportadoresConsignatarios;
		#endregion

		#region Construtores & Destrutores
		public clsPaisIdiomaConsignatario(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel, int nIdExportador, int nIdImportador, int nIdConsignatario, int nIdioma, ref System.Windows.Forms.ImageList bandeiras): base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdioma, ref bandeiras)
		{
			m_nIdExportador = nIdExportador;
			m_nIdImportador = nIdImportador;
			m_nIdConsignatario = nIdConsignatario;
			
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
					arlCondicoesNome.Add("nIdExportador");
					arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicoesValor.Add(m_nIdExportador);
					arlCondicoesNome.Add("nIdImportador");
					arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicoesValor.Add(m_nIdImportador);
					arlCondicoesNome.Add("nIdConsignatario");
					arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicoesValor.Add(m_nIdConsignatario);

					m_typDatSetTbImportadoresConsignatarios = m_cls_dba_ConnectionDB.GetTbImportadoresConsignatarios(arlCondicoesNome,arlCondicoesComparador,arlCondicoesValor,null,null);
					if ( m_typDatSetTbImportadoresConsignatarios.tbImportadoresConsignatarios.Rows.Count > 0)
					{
						mdlDataBaseAccess.Tabelas.XsdTbImportadoresConsignatarios.tbImportadoresConsignatariosRow dtrwImportadores;
						dtrwImportadores = (mdlDataBaseAccess.Tabelas.XsdTbImportadoresConsignatarios.tbImportadoresConsignatariosRow)m_typDatSetTbImportadoresConsignatarios.tbImportadoresConsignatarios.Rows[0];
						if (!dtrwImportadores.IsnIdPaisNull()) 
						{
							m_nIdPais = dtrwImportadores.nIdPais;
							m_nIdPaisInicial = dtrwImportadores.nIdPais;
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
						mdlDataBaseAccess.Tabelas.XsdTbImportadoresConsignatarios.tbImportadoresConsignatariosRow dtrwImportadoresConsignatarios;
						dtrwImportadoresConsignatarios = m_typDatSetTbImportadoresConsignatarios.tbImportadoresConsignatarios.FindBynIdExportadornIdImportadornIdConsignatario(m_nIdExportador,m_nIdImportador,m_nIdConsignatario);
						if (dtrwImportadoresConsignatarios != null)
						{
							dtrwImportadoresConsignatarios.nIdPais = m_nIdPais;
							m_cls_dba_ConnectionDB.SetTbImportadoresConsignatarios(m_typDatSetTbImportadoresConsignatarios);
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
