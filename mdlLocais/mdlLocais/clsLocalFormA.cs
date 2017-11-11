using System;

namespace mdlLocais
{
	/// <summary>
	/// Summary description for clsLocalFormA.
	/// </summary>
	public class clsLocalFormA
	{
		#region Atributes
			protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
			protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionBD;
			protected string m_strEnderecoExecutavel;

			protected int m_nIdExportador = -1;
			protected string m_strIdPe = "";

			private string m_strDefault = null;
			private string m_strPersonalizavel = null;

			private string m_strDataEmissaoFormA = null;

			private mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow m_dtrwExportador = null;
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

			private mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow Exportador
			{
				get
				{
					if (m_dtrwExportador != null)
						return(m_dtrwExportador);
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
					arlCondicaoCampo.Add("idExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_nIdExportador);
					m_cls_dba_ConnectionBD.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					mdlDataBaseAccess.Tabelas.XsdTbExportadores typDataSetExportadores = m_cls_dba_ConnectionBD.GetTbExportadores(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					if (typDataSetExportadores.tbExportadores.Count == 0)
						return(null);
					return(typDataSetExportadores.tbExportadores[0]);
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
			public clsLocalFormA(ref mdlTratamentoErro.clsTratamentoErro cls_ter_tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB,string strEnderecoExecutavel,int nIdExportador,string strIdPe)
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
				string strRetorno = this.GetCidadeExportador();
				string strData = GetDataEmissaoFormA();
				if ((strRetorno != "") && (strData != ""))
					strRetorno = strRetorno + " , " + strData;
				else
					strRetorno = strRetorno + strData;
				return(strRetorno);
			}

			private string GetCidadeExportador()
			{
				mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow dtrwExportador = this.Exportador;
				if (dtrwExportador == null)
					return("");
				if (!dtrwExportador.IsmstrCidadeEmpNull())
					return(dtrwExportador.mstrCidadeEmp);
				return("");
			}

			private string GetDataEmissaoFormA()
			{
				if (m_strDataEmissaoFormA != null)
					return(m_strDataEmissaoFormA);
				mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem typDatSetCertificadosOrigem = this.TypDatSetCertificadosOrigem;
				if (typDatSetCertificadosOrigem.tbCertificadosOrigem.Rows.Count == 0)
					return("");
				mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow dtrwCertificadoOrigem = typDatSetCertificadosOrigem.tbCertificadosOrigem[0];
				if (dtrwCertificadoOrigem.IsdtDataCONull())
					return("");
				return(dtrwCertificadoOrigem.dtDataCO.ToString("dd MMM yyy",new System.Globalization.CultureInfo("en-US")));
			}

			private string strCarregaPersonalizavel()
			{
				mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem typDatSetCertificadosOrigem = this.TypDatSetCertificadosOrigem;
				if (typDatSetCertificadosOrigem.tbCertificadosOrigem.Count == 0)
					return(null);
				mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow dtrwCertificado = typDatSetCertificadosOrigem.tbCertificadosOrigem[0];
				if (dtrwCertificado.IsmstrLocalDataNull())
					return(null);
				return(dtrwCertificado.mstrLocalData);
			}
		#endregion
		#region Salvamento dos Dados
			private bool SalvaPersonalizavel(string strPersonalizavel)
			{
				mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem typDatSetCertificadosOrigem = this.TypDatSetCertificadosOrigem;
				if (typDatSetCertificadosOrigem.tbCertificadosOrigem.Count == 0)
					return(false);
				mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow dtrwCertificado = typDatSetCertificadosOrigem.tbCertificadosOrigem[0];
				dtrwCertificado.mstrLocalData = strPersonalizavel;
				m_cls_dba_ConnectionBD.SetTbCertificadosOrigem(typDatSetCertificadosOrigem);
				return(m_cls_dba_ConnectionBD.Erro == null);
			}			
		#endregion

		#region ShowDialog
			public bool ShowDialog()
			{
				Formularios.frmFLocalFormA form = new mdlLocais.Formularios.frmFLocalFormA(m_strEnderecoExecutavel);
				form.Default = this.Default;
				form.Personalizavel = this.Personalizavel;
				form.ShowDialog	();
				if (form.Confirmed)
				{
					m_strPersonalizavel = form.Personalizavel;
					return(SalvaPersonalizavel(m_strPersonalizavel));
				}
				return(false);
			}
		#endregion

		#region Return
			public string GetFormALocalData()
			{
				return(this.Personalizavel);
			}
		#endregion
	}
}
