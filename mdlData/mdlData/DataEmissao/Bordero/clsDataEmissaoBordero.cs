using System;

namespace mdlData.DataEmissao.Bordero
{
	/// <summary>
	/// Summary description for clsDataEmissaoBordero.
	/// </summary>
	public class clsDataEmissaoBordero : clsData
	{
		#region Atributos
		private mdlDataBaseAccess.Tabelas.XsdTbBorderos m_typDatSetTbBorderos = null;
//		private mdlDataBaseAccess.Tabelas.XsdTbExportadores m_typDatSetTbExportadores = null;
		#endregion

		#region Construtors and Destrutors
		public clsDataEmissaoBordero(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string idPE): base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador)
		{
			m_strIdPE = idPE;
			carregaTypDatSet();
			vCarregaDadosBD();
			this.EditFormat = false;
			this.Name = "Borderô";
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

					//m_typDatSetTbExportadores = m_cls_dba_ConnectionBD.GetTbExportadores(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

					arlCondicaoCampo.Add("idPE");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_strIdPE);

					m_typDatSetTbBorderos = m_cls_dba_ConnectionBD.GetTbBorderos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
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
					mdlDataBaseAccess.Tabelas.XsdTbBorderos.tbBorderosRow dtrwRowTbBorderos;
					if (m_typDatSetTbBorderos.tbBorderos.Rows.Count > 0)
					{
						dtrwRowTbBorderos = (mdlDataBaseAccess.Tabelas.XsdTbBorderos.tbBorderosRow)m_typDatSetTbBorderos.tbBorderos.Rows[0];
						if (!dtrwRowTbBorderos.IsdtDataEmissaoNull())
							m_dtData = dtrwRowTbBorderos.dtDataEmissao;
					}
					if (!bFormatValid())
						m_strFormat = "dd/MM/aaaa";					
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
				mdlDataBaseAccess.Tabelas.XsdTbBorderos.tbBorderosRow dtrwRowTbBorderos;
				if (m_typDatSetTbBorderos.tbBorderos.Rows.Count > 0)
				{
					dtrwRowTbBorderos = (mdlDataBaseAccess.Tabelas.XsdTbBorderos.tbBorderosRow)m_typDatSetTbBorderos.tbBorderos.Rows[0];
					dtrwRowTbBorderos.dtDataEmissao = m_dtData;
				}
				m_cls_dba_ConnectionBD.SetTbBorderos(m_typDatSetTbBorderos);
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
