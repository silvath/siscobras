using System;

namespace mdlMoeda
{
	/// <summary>
	/// Summary description for clsMoedaComercial.
	/// </summary>
	public class clsMoedaComercial : clsMoeda
	{
		#region Atributos
			// ***************************************************************************************************
			// Atributos 
			// ***************************************************************************************************
		    private int m_nIdExportador;
			private string m_strIdPe;
			// ***************************************************************************************************
		#endregion
		#region Constructor
			public clsMoedaComercial(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string strEnderecoExecutavel,int nIdExportador,string strIdPe) : base(ref tratadorErro, ref ConnectionDB,strEnderecoExecutavel)
			{
				m_nIdExportador = nIdExportador;
				m_strIdPe = strIdPe;
				this.CarregaMoedaBD();
   			}
		#endregion

		#region Carrega Dados
			protected override void CarregaMoedaBD()
			{
				mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwTbFaturasComerciais = null;
				m_nIdMoeda = -1;
				m_bValorCarregado = true;
				System.Collections.ArrayList arlCondictionField = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondictionValue = new System.Collections.ArrayList();

				arlCondictionField.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondictionValue.Add(m_nIdExportador);

				arlCondictionField.Add("idPe");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondictionValue.Add(m_strIdPe);

				mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais tbFaturasComerciais = m_cls_dba_ConnectionDB.GetTbFaturasComerciais(arlCondictionField,arlCondicaoComparador,arlCondictionValue,null,null);
				if (tbFaturasComerciais.tbFaturasComerciais.Rows.Count > 0)
				{
					// IdMoeda
					dtrwTbFaturasComerciais = (mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow)tbFaturasComerciais.tbFaturasComerciais.Rows[0];
					if (m_bHasValue = !dtrwTbFaturasComerciais.IsidMoedaNull())
						m_nIdMoeda = dtrwTbFaturasComerciais.idMoeda;
					// bMostrarSimboloMoeda
					if (!dtrwTbFaturasComerciais.IsbMostrarSimboloMoedaNull())
					{
						m_bMostrarSimboloMoeda = dtrwTbFaturasComerciais.bMostrarSimboloMoeda;
					}
				}
				tbFaturasComerciais.Dispose();
			}
		#endregion
		#region Salva Dados
			protected override void SalvaMoedaBD()
			{
				System.Collections.ArrayList arlCondictionField = new System.Collections.ArrayList();
				arlCondictionField.Add("idExportador");
				arlCondictionField.Add("idPe");
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				System.Collections.ArrayList arlCondictionValue = new System.Collections.ArrayList();
				arlCondictionValue.Add(m_nIdExportador);
				arlCondictionValue.Add(m_strIdPe);
				mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais tbFaturasComerciais = m_cls_dba_ConnectionDB.GetTbFaturasComerciais(arlCondictionField,arlCondicaoComparador,arlCondictionValue,null,null);
				if (tbFaturasComerciais.tbFaturasComerciais.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwFatura = (mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow)tbFaturasComerciais.tbFaturasComerciais.Rows[0];
					dtrwFatura.idMoeda = m_nIdMoeda;
					dtrwFatura.bMostrarSimboloMoeda = m_bMostrarSimboloMoeda;
					m_cls_dba_ConnectionDB.SetTbFaturasComerciais(tbFaturasComerciais);
				}
			}
		#endregion
	}
}
