using System;

namespace mdlData.DataEmissao.Bordero
{
	/// <summary>
	/// Summary description for clsEmissaoBorderoSecundario.
	/// </summary>
	public class clsEmissaoBorderoSecundario : clsData
	{
		#region Atributos
		private int m_nIdBancoExportadorBordero = -1;
		private mdlDataBaseAccess.Tabelas.XsdTbBorderosSecundarios m_typDatSetTbBorderosSecundarios = null;
		#endregion
		#region Construtors and Destrutores
		public clsEmissaoBorderoSecundario(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string idPE, int idBancoExportadorBordero): base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador)
		{
			m_strIdPE = idPE;
			m_nIdBancoExportadorBordero = idBancoExportadorBordero;
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
				
					arlCondicaoCampo.Add("nIdExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_nIdExportador);

					arlCondicaoCampo.Add("strIdPE");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_strIdPE);

					arlCondicaoCampo.Add("nIdBancoExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_nIdBancoExportadorBordero);

					m_typDatSetTbBorderosSecundarios = m_cls_dba_ConnectionBD.GetTbBorderosSecundarios(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
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
					mdlDataBaseAccess.Tabelas.XsdTbBorderosSecundarios.tbBorderosSecundariosRow dtrwRowTbBorderosSecundarios;
					if (m_typDatSetTbBorderosSecundarios.tbBorderosSecundarios.Rows.Count > 0)
					{
						dtrwRowTbBorderosSecundarios = (mdlDataBaseAccess.Tabelas.XsdTbBorderosSecundarios.tbBorderosSecundariosRow)m_typDatSetTbBorderosSecundarios.tbBorderosSecundarios.Rows[0];
						if (!dtrwRowTbBorderosSecundarios.IsdtEmissaoNull())
							m_dtData = dtrwRowTbBorderosSecundarios.dtEmissao;
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
				mdlDataBaseAccess.Tabelas.XsdTbBorderosSecundarios.tbBorderosSecundariosRow dtrwRowTbBorderosSecundarios;
				if (m_typDatSetTbBorderosSecundarios.tbBorderosSecundarios.Rows.Count > 0)
				{
					dtrwRowTbBorderosSecundarios = (mdlDataBaseAccess.Tabelas.XsdTbBorderosSecundarios.tbBorderosSecundariosRow)m_typDatSetTbBorderosSecundarios.tbBorderosSecundarios.Rows[0];
					dtrwRowTbBorderosSecundarios.dtEmissao = m_dtData;
				}
				m_cls_dba_ConnectionBD.SetTbBorderosSecundarios(m_typDatSetTbBorderosSecundarios);
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
