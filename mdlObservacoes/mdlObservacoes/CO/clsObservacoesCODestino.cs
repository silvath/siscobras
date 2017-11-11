using System;

namespace mdlObservacoes.CO
{
	/// <summary>
	/// Summary description for clsObservacoesCODestino.
	/// </summary>
	public class clsObservacoesCODestino : clsObservacoes
	{
		#region Atributes
			private string m_strIdPE = "";
			private int m_nIdTipoRelatorio = 0;
		#endregion
		#region Constructor
			public clsObservacoesCODestino(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string strIdPE,int nIdTipoRelatorio): base(ref tratadorErro, ref ConnectionDB,EnderecoExecutavel,nIdExportador)
			{
				m_bFormPadrao = true;
				m_strIdPE = strIdPE;
				m_nIdTipoRelatorio = nIdTipoRelatorio;
				carregaDadosBD();
				m_bMostrarLabel = false;
				m_strCaption = "Destino";
			}
		#endregion

		#region Carregamento Dados
			private mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem GetTypDatSetCertificadoOrigem()
			{
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("idPe");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdPE);

				arlCondicaoCampo.Add("nIdTipoCO");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdTipoRelatorio);

				m_cls_dba_ConnectionBD.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem typDatSetCertificadosOrigem = m_cls_dba_ConnectionBD.GetTbCertificadosOrigem(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				if (m_cls_dba_ConnectionBD.Erro == null)
					return(typDatSetCertificadosOrigem);
				else
					return(null);
			}

			protected override void carregaDadosBDEspecifico()
			{
				mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem typDatSetCertificadosOrigem = GetTypDatSetCertificadoOrigem();
				if (typDatSetCertificadosOrigem.tbCertificadosOrigem.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow dtrwCertificado = (mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow)typDatSetCertificadosOrigem.tbCertificadosOrigem.Rows[0];
					if (!dtrwCertificado.IsmstrDestinoNull())
						m_strObservacoes = dtrwCertificado.mstrDestino;
					else
						m_strObservacoes = this.Default;
				}else{
					m_strObservacoes = this.Default;
				}
			}

			protected override void vCarregaDadosDefault()
			{
				string strRetorno = "";
				mdlLocais.clsLocais objLocal = new mdlLocais.clsLocaisFaturaComercial(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionBD,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPE);
				string strLocalEntrega,strPaisDestino,strTemp;
				objLocal.retornaValores(out strTemp,out strTemp,out strTemp,out strTemp,out strLocalEntrega,out strPaisDestino);
				strRetorno = strLocalEntrega;
				if ((strRetorno != "") && (strPaisDestino != ""))
					strRetorno += " - ";
				strRetorno += strPaisDestino;
				this.Default = strRetorno;
			}
		#endregion
		#region Salvamento Dados
			protected override void salvaDadosBDEspecifico()
			{
				if (m_strObservacoes != this.Default)
				{
					mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem typDatSetCertificadosOrigem = GetTypDatSetCertificadoOrigem();
					if (typDatSetCertificadosOrigem.tbCertificadosOrigem.Rows.Count > 0)
					{
						mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow dtrwCertificado = (mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow)typDatSetCertificadosOrigem.tbCertificadosOrigem.Rows[0];
						dtrwCertificado.mstrDestino = m_strObservacoes;
						m_cls_dba_ConnectionBD.SetTbCertificadosOrigem(typDatSetCertificadosOrigem);
					}
				}
			}
		#endregion
	}
}
