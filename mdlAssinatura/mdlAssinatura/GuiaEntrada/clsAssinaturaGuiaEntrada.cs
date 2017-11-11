using System;

namespace mdlAssinatura.GuiaEntrada
{
	/// <summary>
	/// Summary description for clsAssinaturaGuiaEntrada.
	/// </summary>
	public class clsAssinaturaGuiaEntrada : clsAssinatura
	{
		#region Atributos
			private string m_strIdPE = "";

			protected mdlDataBaseAccess.Tabelas.XsdTbGuiasEntrada m_typDatSetGuiasEntrada;
		#endregion
		#region Constructors and Destructors
			public clsAssinaturaGuiaEntrada(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string idPE) : base(ref tratadorErro, ref ConnectionDB,EnderecoExecutavel,nIdExportador)
			{
				m_strIdPE = idPE;
				this.carregaTypDatSet();
				carregaDadosBD();
			}
		#endregion

		#region Carregamento de Dados
		#region Banco de Dados
		protected new void carregaTypDatSet()
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

				m_typDatSetGuiasEntrada = m_cls_dba_ConnectionBD.GetTbGuiasEntrada(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				base.carregaTypDatSet();
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
				if (m_typDatSetGuiasEntrada.tbGuiasEntrada.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbGuiasEntrada.tbGuiasEntradaRow dtrwGuiasEntrada = (mdlDataBaseAccess.Tabelas.XsdTbGuiasEntrada.tbGuiasEntradaRow)m_typDatSetGuiasEntrada.tbGuiasEntrada.Rows[0];
					if (!dtrwGuiasEntrada.IsnIdAssinaturaNull())
						m_nIdAssinatura = dtrwGuiasEntrada.nIdAssinatura;
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
		#region Banco de Dados
		protected override void salvaDadosBDEspecifico()
		{
			try
			{
				if (m_typDatSetGuiasEntrada.tbGuiasEntrada.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbGuiasEntrada.tbGuiasEntradaRow dtrwGuiasEntrada = (mdlDataBaseAccess.Tabelas.XsdTbGuiasEntrada.tbGuiasEntradaRow)m_typDatSetGuiasEntrada.tbGuiasEntrada.Rows[0];
					dtrwGuiasEntrada.nIdAssinatura = m_nIdAssinatura;
				}
				m_cls_dba_ConnectionBD.SetTbGuiasEntrada(m_typDatSetGuiasEntrada);
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
