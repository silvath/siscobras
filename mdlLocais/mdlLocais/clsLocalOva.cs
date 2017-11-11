using System;

namespace mdlLocais
{
	/// <summary>
	/// Summary description for clsLocalOva.
	/// </summary>
	public class clsLocalOva : clsLocal
	{
		#region Atributes
			private int m_nIdExportador = -1;
			private string m_strIdPe = "";
		#endregion
		#region Constructors and Destructors
			public clsLocalOva(ref mdlTratamentoErro.clsTratamentoErro cls_ter_tratadorErro,ref mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB, string strEnderecoExecutavel, int nIdExportador,string strIdPe) : base(ref cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB, strEnderecoExecutavel) 
			{
				m_nIdExportador = nIdExportador;
				m_strIdPe = strIdPe;
			}
		#endregion

		#region Carregamento dos Dados
			protected override void vCarregaInterface(out string strFormText,out string strGroupboxText)
			{
				strFormText = "Local de Unitização";
				strGroupboxText = "";
			}

			private mdlDataBaseAccess.Tabelas.XsdTbPes GetTypDatSetPes()
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

				m_cls_dba_ConectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				return(m_cls_dba_ConectionDB.GetTbPes(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null));
			}

			protected override void vCarregaDados(out string strLocal)
			{
				strLocal = "";
				mdlDataBaseAccess.Tabelas.XsdTbPes typDatSetPes = GetTypDatSetPes();
				if (typDatSetPes.tbPEs.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwPes = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)typDatSetPes.tbPEs.Rows[0];
					if (!dtrwPes.IsmstrLocalOvaNull())
						strLocal = dtrwPes.mstrLocalOva;
				}
			}
		#endregion
		#region Salvamento dos Dados
			protected override bool bSalvaDados(string strLocal)
			{
				mdlDataBaseAccess.Tabelas.XsdTbPes typDatSetPes = GetTypDatSetPes();
				if (typDatSetPes.tbPEs.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwPes = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)typDatSetPes.tbPEs.Rows[0];
					dtrwPes.mstrLocalOva = strLocal;
					m_cls_dba_ConectionDB.SetTbPes(typDatSetPes);
					return(m_bModificado = (m_cls_dba_ConectionDB.Erro == null));
				}else{
					return(false);
				}
			}
		#endregion

	}
}
