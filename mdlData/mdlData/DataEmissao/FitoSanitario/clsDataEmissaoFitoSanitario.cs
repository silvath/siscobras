using System;

namespace mdlData.DataEmissao.FitoSanitario
{
	/// <summary>
	/// Summary description for clsDataEmissaoFitoSanitario.
	/// </summary>
	public class clsDataEmissaoFitoSanitario : clsData
	{
		#region Atributos
		private mdlDataBaseAccess.Tabelas.XsdTbPes m_typDatSetTbPes = null;
		#endregion
		#region Construtors and Destrutors
			public clsDataEmissaoFitoSanitario(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string idPE): base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador)
			{
				m_strIdPE = idPE;
				carregaTypDatSet();
				vCarregaDadosBD();
				this.EditFormat = false;
				this.Name = "Fito Sanitário";
			}
		#endregion

		#region Carregamento de Dados
			protected void carregaTypDatSet()
			{
				try
				{
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
				
					arlCondicaoCampo.Add("idExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_nIdExportador);

					arlCondicaoCampo.Add("idPE");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_strIdPE);

					m_typDatSetTbPes = m_cls_dba_ConnectionBD.GetTbPes(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
			protected override void carregaDadosBDEspecificos()
			{
				try
				{
					mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwRowTbPes;
					if (m_typDatSetTbPes.tbPEs.Rows.Count > 0)
					{
						dtrwRowTbPes = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetTbPes.tbPEs.Rows[0];
						if (!dtrwRowTbPes.IsdtEmissaoFitoSanitarioNull())
							m_dtData = dtrwRowTbPes.dtEmissaoFitoSanitario;
					}
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
		#endregion
		#region Salvamento de Dados
		protected override void salvaDadosBDEspecifico()
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwRowTbPes;
				if (m_typDatSetTbPes.tbPEs.Rows.Count > 0)
				{
					dtrwRowTbPes = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetTbPes.tbPEs.Rows[0];
					dtrwRowTbPes.dtEmissaoFitoSanitario = m_dtData;
				}
				m_cls_dba_ConnectionBD.SetTbPes(m_typDatSetTbPes);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
	}
}
