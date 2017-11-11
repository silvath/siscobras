using System;

namespace mdlAssinatura.Romaneio
{
	/// <summary>
	/// Summary description for clsAssinaturaRomaneio.
	/// </summary>
	public class clsAssinaturaRomaneio : clsAssinatura
	{
		#region Atributos
		private string m_strIdPE = "";

		protected mdlDataBaseAccess.Tabelas.XsdTbRomaneios m_typDatSetTbRomaneios;
		#endregion

		#region Construtores & Destrutores
		public clsAssinaturaRomaneio(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string idPE) : base(ref tratadorErro, ref ConnectionDB,EnderecoExecutavel,nIdExportador)
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
			
				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("idPE");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdPE);

				m_typDatSetTbRomaneios = m_cls_dba_ConnectionBD.GetTbRomaneios(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
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
				mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow dtrwRowTbRomaneios;
				mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow dtrwRowTbExportadores;
				if (m_typDatSetTbRomaneios.tbRomaneios.Rows.Count > 0)
				{
					dtrwRowTbRomaneios = (mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow)m_typDatSetTbRomaneios.tbRomaneios.Rows[0];
					if (!dtrwRowTbRomaneios.IsnIdAssinaturaNull())
						m_nIdAssinatura = dtrwRowTbRomaneios.nIdAssinatura;
				}
				if (m_nIdAssinatura == -1 && m_typDatSetTbExportadores.tbExportadores.Rows.Count > 0)
				{
					dtrwRowTbExportadores = (mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow)m_typDatSetTbExportadores.tbExportadores.Rows[0];
					if (!dtrwRowTbExportadores.IsidUltimaAssinaturaNull())
						m_nIdAssinatura = dtrwRowTbExportadores.idUltimaAssinatura;
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
				mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow dtrwRowTbRomaneios;
				mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow dtrwRowTbExportadores;
				if (m_typDatSetTbRomaneios.tbRomaneios.Rows.Count > 0)
				{
					dtrwRowTbRomaneios = (mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow)m_typDatSetTbRomaneios.tbRomaneios.Rows[0];
					if (dtrwRowTbRomaneios != null)
						dtrwRowTbRomaneios.nIdAssinatura = m_nIdAssinatura;
				}
				if (m_typDatSetTbExportadores.tbExportadores.Rows.Count > 0)
				{
					dtrwRowTbExportadores = (mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow)m_typDatSetTbExportadores.tbExportadores.Rows[0];
					if (dtrwRowTbExportadores != null)
						dtrwRowTbExportadores.idUltimaAssinatura = m_nIdAssinatura;
				}
				m_cls_dba_ConnectionBD.SetTbRomaneios(m_typDatSetTbRomaneios);
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
