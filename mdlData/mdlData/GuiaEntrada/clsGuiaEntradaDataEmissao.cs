using System;

namespace mdlData.GuiaEntrada
{
	/// <summary>
	/// Summary description for clsGuiaEntradaDataEmissao.
	/// </summary>
	public class clsGuiaEntradaDataEmissao : clsData
	{
		#region Atributos
			private mdlDataBaseAccess.Tabelas.XsdTbGuiasEntrada m_typDatSetTbGuiasEntrada = null;
		#endregion
		#region Constructors and Destructors
			public clsGuiaEntradaDataEmissao(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string idPE): base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador)
			{
				m_strIdPE = idPE;
				carregaTypDatSet();
				vCarregaDadosBD();
				this.EditFormat = false;
				this.Name = "Data Emissão";
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

					m_typDatSetTbGuiasEntrada = m_cls_dba_ConnectionBD.GetTbGuiasEntrada(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
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
					if (m_typDatSetTbGuiasEntrada.tbGuiasEntrada.Rows.Count > 0)
					{
						mdlDataBaseAccess.Tabelas.XsdTbGuiasEntrada.tbGuiasEntradaRow dtrwGuiaEntrada = (mdlDataBaseAccess.Tabelas.XsdTbGuiasEntrada.tbGuiasEntradaRow)m_typDatSetTbGuiasEntrada.tbGuiasEntrada.Rows[0];
						if (!dtrwGuiaEntrada.IsdtEmissaoNull())
							m_dtData = dtrwGuiaEntrada.dtEmissao;
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
					if (m_typDatSetTbGuiasEntrada.tbGuiasEntrada.Rows.Count > 0)
					{
						mdlDataBaseAccess.Tabelas.XsdTbGuiasEntrada.tbGuiasEntradaRow dtrwGuiaEntrada = (mdlDataBaseAccess.Tabelas.XsdTbGuiasEntrada.tbGuiasEntradaRow)m_typDatSetTbGuiasEntrada.tbGuiasEntrada.Rows[0];
						dtrwGuiaEntrada.dtEmissao = m_dtData;
					}
					m_cls_dba_ConnectionBD.SetTbGuiasEntrada(m_typDatSetTbGuiasEntrada);
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
