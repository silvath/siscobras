using System;

namespace mdlTransportes
{
	/// <summary>
	/// Summary description for clsFormAMeioTransporte.
	/// </summary>
	public class clsFormAMeioTransporte
	{
		#region Atributes
			protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
			protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionBD;
			protected string m_strEnderecoExecutavel;

			protected int m_nIdExportador = -1;
			protected string m_strIdPe = "";

			private string m_strDefault = null;
			private string m_strPersonalizavel = null;

			private mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais m_typDatSetFaturasComerciais = null;
			private mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem m_typDatSetCertificadosOrigem = null;
		#endregion
		#region Properties	
			private string Default
			{
				get
				{
					if (m_strDefault != null)
						return(m_strDefault);
					m_strDefault = strCarregaDefault();
					return(m_strDefault);
				}
			}

			public string Personalizavel
			{
				get
				{
					if (m_strPersonalizavel != null)
						return(m_strPersonalizavel); 
					m_strPersonalizavel = strCarregaPersonalizavel();
					if (m_strPersonalizavel == null)
						m_strPersonalizavel = this.Default;
					return(m_strPersonalizavel);
				}
			}

			private mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow FaturaComercial
			{
				get
				{
					mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais typDatSetFaturasComerciais = this.TypDatSetFaturasComerciais;
					if (typDatSetFaturasComerciais.tbFaturasComerciais.Rows.Count == 0)
						return(null);
					return(typDatSetFaturasComerciais.tbFaturasComerciais[0]);
				}
			}

			private mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais TypDatSetFaturasComerciais
			{
				get
				{
					if (m_typDatSetFaturasComerciais != null)
						return(m_typDatSetFaturasComerciais);
					m_cls_dba_ConnectionBD.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
					arlCondicaoCampo.Add("idExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_nIdExportador);
					arlCondicaoCampo.Add("idPE");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_strIdPe);
					m_typDatSetFaturasComerciais = m_cls_dba_ConnectionBD.GetTbFaturasComerciais(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					return(m_typDatSetFaturasComerciais);
				}
			}

			private mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem TypDatSetCertificadosOrigem
			{
				get
				{
					if (m_typDatSetCertificadosOrigem != null)
						return(m_typDatSetCertificadosOrigem);
					m_cls_dba_ConnectionBD.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
					arlCondicaoCampo.Add("idExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_nIdExportador);
					arlCondicaoCampo.Add("idPE");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_strIdPe);
					arlCondicaoCampo.Add("nIdTipoCO");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(30);
					m_typDatSetCertificadosOrigem = m_cls_dba_ConnectionBD.GetTbCertificadosOrigem(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					return(m_typDatSetCertificadosOrigem);
				}
			}
		#endregion
		#region Constructors
			public clsFormAMeioTransporte(ref mdlTratamentoErro.clsTratamentoErro cls_ter_tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB,string strEnderecoExecutavel,int nIdExportador,string strIdPe)
			{
				m_cls_ter_tratadorErro = cls_ter_tratadorErro;
				m_cls_dba_ConnectionBD = cls_dba_ConnectionDB;
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				m_nIdExportador = nIdExportador;
				m_strIdPe = strIdPe;
			}
		#endregion

		#region Carregamento dos Dados
			private string strCarregaDefault()
			{
				string strRetorno = "";
				mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais typDatSetFaturasComerciais = this.TypDatSetFaturasComerciais;
				if (typDatSetFaturasComerciais.tbFaturasComerciais.Rows.Count == 0)
					return(null);
				mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwFatura = typDatSetFaturasComerciais.tbFaturasComerciais[0];
				int nIdMeioTransporte = -1;
				if (dtrwFatura.IsidMeioTransporteNull())
					return(null);
				nIdMeioTransporte = dtrwFatura.idMeioTransporte;
				strRetorno = GetMeioTranporte(nIdMeioTransporte) + " ";
				string strLocalOrigem = GetLocalOrigem();
				if (strLocalOrigem != "")
					strRetorno += "FROM " + GetLocalOrigem() + " ";
				string strLocalDestino = GetLocalDestino();
				if (strLocalDestino != "")
					strRetorno += "TO " + GetLocalDestino();
				return(strRetorno);
			}

			private string GetMeioTranporte(int nIdMeioTransporte)
			{
				string strRetorno = "";
				switch(nIdMeioTransporte)
				{
					case mdlConstantes.clsConstantes.MEIOTRANSPORTE_AEREO:
						strRetorno = "by Air";
						break;
					case mdlConstantes.clsConstantes.MEIOTRANSPORTE_CORREIO:
						strRetorno = "by Post/Courrier";
						break;
					case mdlConstantes.clsConstantes.MEIOTRANSPORTE_FERROVIARIO:
						strRetorno = "by Rail";
						break;
					case mdlConstantes.clsConstantes.MEIOTRANSPORTE_MARITIMO:
						strRetorno = "by Sea";
						break;
					case mdlConstantes.clsConstantes.MEIOTRANSPORTE_RODOVIARIO:
						strRetorno = "by Road";
						break;
				}
				return(strRetorno);
			}

			private string GetLocalOrigem()
			{
				mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwFatura = this.FaturaComercial;
				if (dtrwFatura == null)
					return("");
				if (dtrwFatura.IslocalEmbarqueNull())
					return("");
				return(dtrwFatura.localEmbarque);
			}

			private string GetLocalDestino()
			{
				mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwFatura = this.FaturaComercial;
				if (dtrwFatura == null)
					return("");
				if (dtrwFatura.IslocalDestinoNull())
					return("");
				return(dtrwFatura.localDestino);
			}

			private string strCarregaPersonalizavel()
			{
				mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem typDatSetCertificadosOrigem = this.TypDatSetCertificadosOrigem;
				if (typDatSetCertificadosOrigem.tbCertificadosOrigem.Count == 0)
					return(null);
				mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow dtrwCertificado = typDatSetCertificadosOrigem.tbCertificadosOrigem[0];
				if (dtrwCertificado.IsmstrMeioTransporteNull())
					return(null);
				return(dtrwCertificado.mstrMeioTransporte);
			}
		#endregion
		#region Salvamento dos Dados
			private bool SalvaPersonalizavel(string strPersonalizavel)
			{
				mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem typDatSetCertificadosOrigem = this.TypDatSetCertificadosOrigem;
				if (typDatSetCertificadosOrigem.tbCertificadosOrigem.Count == 0)
					return(false);
				mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow dtrwCertificado = typDatSetCertificadosOrigem.tbCertificadosOrigem[0];
				dtrwCertificado.mstrMeioTransporte = strPersonalizavel;
				m_cls_dba_ConnectionBD.SetTbCertificadosOrigem(typDatSetCertificadosOrigem);
				return(m_cls_dba_ConnectionBD.Erro == null);
			}			
		#endregion

		#region ShowDialog
			public bool ShowDialog()
			{
				frmFFormAMeioTransporte form = new frmFFormAMeioTransporte(m_strEnderecoExecutavel);
				form.Default = this.Default;
				form.Personalizavel = this.Personalizavel;
				form.ShowDialog	();
				if (form.Confirmed)
					return(SalvaPersonalizavel(form.Personalizavel));
				return(false);
			}
		#endregion

		#region Return
			public string GetFormAMeioTransporte()
			{
				return(this.Personalizavel);
			}
		#endregion
	}
}
