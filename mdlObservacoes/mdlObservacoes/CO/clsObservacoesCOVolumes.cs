using System;

namespace mdlObservacoes.CO
{
	/// <summary>
	/// Summary description for clsObservacoesCOVolumes.
	/// </summary>
	public class clsObservacoesCOVolumes : clsObservacoes
	{
		#region Atributes
			private string m_strIdPE = "";
			private int m_nIdTipoRelatorio = 0;
		#endregion
		#region Constructor
			public clsObservacoesCOVolumes(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string strIdPE,int nIdTipoRelatorio): base(ref tratadorErro, ref ConnectionDB,EnderecoExecutavel,nIdExportador)
			{
				m_bFormPadrao = true;
				m_strIdPE = strIdPE;
				m_nIdTipoRelatorio = nIdTipoRelatorio;
				carregaDadosBD();
				m_bMostrarLabel = false;
				m_strCaption = "Volumes";
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
					if (!dtrwCertificado.IsmstrVolumesNull())
						m_strObservacoes = dtrwCertificado.mstrVolumes;
					else
						m_strObservacoes = this.Default;
				}else{
					m_strObservacoes = this.Default;
				}
			}

			protected override void vCarregaDadosDefault()
			{
				string strRetorno = "";

				// Tipo Romaneio
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);
				arlCondicaoCampo.Add("idPe");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdPE);


				m_cls_dba_ConnectionBD.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				mdlDataBaseAccess.Tabelas.XsdTbRomaneios typDatSetRomaneios = m_cls_dba_ConnectionBD.GetTbRomaneios(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				if (typDatSetRomaneios.tbRomaneios.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow dtrwRomaneio = (mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow)typDatSetRomaneios.tbRomaneios.Rows[0];
					if (!dtrwRomaneio.IsnTipoOrdenacaoNull())
					{
						System.Collections.ArrayList arlEmbalagens = null, arlTemp = new System.Collections.ArrayList();
						switch(dtrwRomaneio.nTipoOrdenacao)
						{
							case 11:
							case 25:
								mdlProdutosRomaneio.clsProdutosRomaneio obj = new mdlProdutosRomaneio.clsProdutosRomaneio(ref m_cls_ter_tratadorErro, ref m_cls_dba_ConnectionBD, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE);
								obj.vRetornaValores(out arlEmbalagens);
								break;
							case 26:
								mdlProdutosRomaneio.clsProdutosRomaneioSimplificado objSim = new mdlProdutosRomaneio.clsProdutosRomaneioSimplificado(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionBD,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPE);
								objSim.vRetornaValores(out arlEmbalagens);
								break;
						}
						if ((arlEmbalagens != null) && (arlEmbalagens.Count > 0))
						{
							int nCont = 0;
							string strVolumeAnterior = "";
							foreach(string strVolume in arlEmbalagens)
							{
								if (strVolumeAnterior != strVolume)
								{
									if (strVolumeAnterior != "")
										strRetorno += nCont.ToString() + " " + strVolumeAnterior + ", ";
									strVolumeAnterior = strVolume;
									nCont = 1;
								}
								else
								{
									nCont++;
								}
							}
							strRetorno += nCont.ToString() + " " + strVolumeAnterior;
						}
					}
				}
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
						dtrwCertificado.mstrVolumes = m_strObservacoes;
						m_cls_dba_ConnectionBD.SetTbCertificadosOrigem(typDatSetCertificadosOrigem);
					}
				}
			}
		#endregion
	}
}
