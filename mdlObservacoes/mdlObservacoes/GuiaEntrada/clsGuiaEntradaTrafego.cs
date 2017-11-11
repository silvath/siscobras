using System;

namespace mdlObservacoes.GuiaEntrada
{
	/// <summary>
	/// Summary description for clsGuiaEntradaTrafego.
	/// </summary>
	public class clsGuiaEntradaTrafego : clsObservacoes
	{
		#region Atributes
		private string m_strIdPE = "";

		private mdlDataBaseAccess.Tabelas.XsdTbGuiasEntrada m_typDatSetGuiasEntradas;
		#endregion
		#region Constructors and Destructors
			public clsGuiaEntradaTrafego(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string strIdPE): base(ref tratadorErro, ref ConnectionDB,EnderecoExecutavel,nIdExportador)
			{
				this.Multiline = false;
				this.TextForm = "Tráfego";
				m_strIdPE = strIdPE;
				carregaTypDatSet();
				carregaDadosBD();
			}
		#endregion

		#region Carregamento de Dados
		#region Banco de Dados
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

					m_typDatSetGuiasEntradas = m_cls_dba_ConnectionBD.GetTbGuiasEntrada(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				} 
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
			protected override void carregaDadosBDEspecifico()
			{
				try
				{
					if (m_typDatSetGuiasEntradas.tbGuiasEntrada.Rows.Count > 0)
					{
						mdlDataBaseAccess.Tabelas.XsdTbGuiasEntrada.tbGuiasEntradaRow dtrwGuiasEntrada = (mdlDataBaseAccess.Tabelas.XsdTbGuiasEntrada.tbGuiasEntradaRow)m_typDatSetGuiasEntradas.tbGuiasEntrada.Rows[0];
						if (!dtrwGuiasEntrada.IsmstrTrafegoNull())
							m_strObservacoes = dtrwGuiasEntrada.mstrTrafego;
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
		#region Salvamento dos Dados
		#region Banco de Dados
		protected override void salvaDadosBDEspecifico()
		{
			if (m_typDatSetGuiasEntradas.tbGuiasEntrada.Rows.Count > 0)
			{
				mdlDataBaseAccess.Tabelas.XsdTbGuiasEntrada.tbGuiasEntradaRow dtrwGuiaEntrada = (mdlDataBaseAccess.Tabelas.XsdTbGuiasEntrada.tbGuiasEntradaRow)m_typDatSetGuiasEntradas.tbGuiasEntrada.Rows[0];
				dtrwGuiaEntrada.mstrTrafego = m_strObservacoes;  
				m_cls_dba_ConnectionBD.SetTbGuiasEntrada(m_typDatSetGuiasEntradas);
			}
		}
		#endregion
		#endregion
	}
}
