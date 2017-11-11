using System;

namespace mdlMoeda
{
	/// <summary>
	/// Summary description for clsMoedaProforma.
	/// </summary>
	public class clsMoedaProforma  : clsMoeda
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
			public clsMoedaProforma(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string strEnderecoExecutavel,int nIdExportador,string strIdPe) : base(ref tratadorErro, ref ConnectionDB,strEnderecoExecutavel)
			{
				m_nIdExportador = nIdExportador;
				m_strIdPe = strIdPe;
				this.CarregaMoedaBD();
   			}
		#endregion

		#region Carrega Dados
			protected override void CarregaMoedaBD()
			{
				mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas.tbFaturasProformasRow dtrwTbFaturasProformas = null;
				m_nIdMoeda = -1;
				m_bValorCarregado = true;
				System.Collections.ArrayList arlCondictionField = new System.Collections.ArrayList();
				arlCondictionField.Add("idExportador");
				arlCondictionField.Add("idPe");
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				System.Collections.ArrayList arlCondictionValue = new System.Collections.ArrayList();
				arlCondictionValue.Add(m_nIdExportador);
				arlCondictionValue.Add(m_strIdPe);
				mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas tbFaturasProformas = m_cls_dba_ConnectionDB.GetTbFaturasProformas(arlCondictionField,arlCondicaoComparador,arlCondictionValue,null,null);
				if (tbFaturasProformas.tbFaturasProformas.Rows.Count > 0)
				{
					dtrwTbFaturasProformas = (mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas.tbFaturasProformasRow)tbFaturasProformas.tbFaturasProformas.Rows[0];
					// IdMoeda
					if (!dtrwTbFaturasProformas.IsidMoedaNull())
					{
						m_nIdMoeda = Int32.Parse(dtrwTbFaturasProformas.idMoeda.ToString());
					}
					// bMostrarSimboloMoeda
					if (!dtrwTbFaturasProformas.IsbMostrarSimboloMoedaNull())
					{
						m_bMostrarSimboloMoeda = dtrwTbFaturasProformas.bMostrarSimboloMoeda;
					}

				}
				tbFaturasProformas.Dispose();
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
				mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas tbFaturasProformas = m_cls_dba_ConnectionDB.GetTbFaturasProformas(arlCondictionField,arlCondicaoComparador,arlCondictionValue,null,null);
				if (tbFaturasProformas.tbFaturasProformas.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas.tbFaturasProformasRow dtrwFatura = (mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas.tbFaturasProformasRow)tbFaturasProformas.tbFaturasProformas.Rows[0];
					dtrwFatura.idMoeda = m_nIdMoeda;
					dtrwFatura.bMostrarSimboloMoeda = m_bMostrarSimboloMoeda;
					m_cls_dba_ConnectionDB.SetTbFaturasProformas(tbFaturasProformas);
				}
			}
		#endregion
	}
}
