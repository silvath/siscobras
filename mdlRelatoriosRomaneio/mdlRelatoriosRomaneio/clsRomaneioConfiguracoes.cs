using System;

namespace mdlRelatoriosRomaneio
{
	/// <summary>
	/// Summary description for clsRomaneioConfiguracoes.
	/// </summary>
	public class clsRomaneioConfiguracoes
	{
		#region Atributes
			private mdlTratamentoErro.clsTratamentoErro m_cls_ter_TratadorErro = null;
			private mdlDataBaseAccess.clsDataBaseAccess	m_cls_dba_ConnectionDB = null;
			private string m_strEnderecoExecutavel = "";

			private int m_nIdExportador = -1;
			private string m_strIdCodigo = "";

			private int m_nIdTipoRelatorio = -1;

			public bool m_bModificado = false;
			private bool m_bModificadoAssistente = false;
		#endregion
		#region Properties
			public bool ModificadoAssistente
			{
				get
				{
					return(m_bModificadoAssistente);
				}
			}

			public int TipoRelatorio
			{
				get
				{
					return(m_nIdTipoRelatorio);
				}
			}
		#endregion
		#region Constructors and Destructors
			public clsRomaneioConfiguracoes(ref mdlTratamentoErro.clsTratamentoErro cls_ter_TratadorErro,ref mdlDataBaseAccess.clsDataBaseAccess	cls_dba_ConnectionDB,string strEnderecoExecutavel,int nIdExportador,string strIdCodigo)
			{
				m_cls_ter_TratadorErro = cls_ter_TratadorErro;
				m_cls_dba_ConnectionDB = cls_dba_ConnectionDB;
				m_strEnderecoExecutavel = strEnderecoExecutavel;

				m_nIdExportador = nIdExportador;
				m_strIdCodigo = strIdCodigo;
  			}
		#endregion

		#region ShowDialog
			public bool HasConfig()
			{
				int nIdTipoRelatorio;
				vCarregaDadosRomaneio(out nIdTipoRelatorio);
				return((nIdTipoRelatorio == (int)mdlConstantes.Relatorio.Romaneio) || (nIdTipoRelatorio == (int)mdlConstantes.Relatorio.RomaneioVolumes));
			}

			public bool ShowDialog()
			{
				bool bReturn = false;
				bool bEmbalagensIntermediarias,bMostrarVolumes,bMostrarEmbalagens;
				bool bOtimizarEspaco,bReplicarInformacoesVolumes;
				vCarregaDadosRomaneio(out m_nIdTipoRelatorio,out bEmbalagensIntermediarias,out bMostrarVolumes,out bMostrarEmbalagens,out bOtimizarEspaco,out bReplicarInformacoesVolumes);
				Formularios.frmFTipoRomaneio formFTipoRomaneio = new mdlRelatoriosRomaneio.Formularios.frmFTipoRomaneio(m_strEnderecoExecutavel);
				switch(m_nIdTipoRelatorio)
				{
					case (int)mdlConstantes.Relatorio.Romaneio:
						bReturn = ShowDialogConfiguracoesProdutos(ref bReplicarInformacoesVolumes,ref bMostrarVolumes,ref bMostrarEmbalagens);
						break;
					case (int)mdlConstantes.Relatorio.RomaneioVolumes:
						bReturn = ShowDialogConfiguracoesVolumes(ref bOtimizarEspaco);
						break;
					case (int)mdlConstantes.Relatorio.RomaneioSimplificado:
						break;
				}
				if (bReturn)
					bReturn = bSalvaDadosRomaneio(bMostrarVolumes,bMostrarEmbalagens,bOtimizarEspaco,bReplicarInformacoesVolumes);
				return(bReturn);
			}
			
			private bool ShowDialogConfiguracoesProdutos(ref bool bReplicarInformacoesVolumes,ref bool bMostrarVolumesconsecutivos,ref bool bMostrarEmbalagensConsecutivas)
			{
				Formularios.frmFConfiguracoesProdutos formFProdutos = new mdlRelatoriosRomaneio.Formularios.frmFConfiguracoesProdutos(m_strEnderecoExecutavel);
				formFProdutos.ReplicarInformacoesVolumes = bReplicarInformacoesVolumes;
				formFProdutos.MostrarVolumesConsecutivos = bMostrarVolumesconsecutivos;
				formFProdutos.MostrarEmbalagensConsecutivos = bMostrarEmbalagensConsecutivas;
				formFProdutos.ShowDialog();
				if (formFProdutos.Modificado)
				{
					bReplicarInformacoesVolumes = formFProdutos.ReplicarInformacoesVolumes;
					bMostrarVolumesconsecutivos = formFProdutos.MostrarVolumesConsecutivos;
					bMostrarEmbalagensConsecutivas = formFProdutos.MostrarEmbalagensConsecutivos;
				}
				return(formFProdutos.Modificado);
			}

			private bool ShowDialogConfiguracoesVolumes(ref bool bOtimizarEspaco)
			{
				Formularios.frmFConfiguracoesVolumes formFVolumes = new mdlRelatoriosRomaneio.Formularios.frmFConfiguracoesVolumes(m_strEnderecoExecutavel);
				formFVolumes.OtimizarEspaco = bOtimizarEspaco;
				formFVolumes.ShowDialog();
				if (formFVolumes.Modificado)
					bOtimizarEspaco = formFVolumes.OtimizarEspaco;
				return(formFVolumes.Modificado);
			}
		#endregion
		#region ShowDialogTipo
			public bool ShowDialogTipo()
			{
				return(ShowDialogTipo(true));
			}

			public bool ShowDialogTipo(bool bAutomatic)
			{
				int nIdTipoRomaneio;
				bool bEmbalagensIntermediarias,bMostrarVolumes,bMostrarEmbalagens;
				vCarregaDadosRomaneio(out nIdTipoRomaneio,out bEmbalagensIntermediarias,out bMostrarVolumes,out bMostrarEmbalagens);
				Formularios.frmFTipoRomaneio formFTipoRomaneio = new mdlRelatoriosRomaneio.Formularios.frmFTipoRomaneio(m_strEnderecoExecutavel);
				m_nIdTipoRelatorio = formFTipoRomaneio.TipoRomaneio = nIdTipoRomaneio;
				formFTipoRomaneio.ShowDialog();
				if (formFTipoRomaneio.Modificado)
				{
					if (formFTipoRomaneio.TipoRomaneio != nIdTipoRomaneio)
					{
						if (bSalvaDadosRomaneio(formFTipoRomaneio.TipoRomaneio,bEmbalagensIntermediarias,bMostrarVolumes,bMostrarEmbalagens))
						{
							if (bAutomatic)
							{
								if (formFTipoRomaneio.TipoRomaneio != (int)mdlConstantes.Relatorio.RomaneioSimplificado)
								{
									ShowDialogVolumes();
									return(true);
								}else{
									ShowDialogAssistente();
									return(true);
								}
							}
							return(true);
						}else{
							return(false);
						}
					}else{
						if (bAutomatic)
						{
							if (formFTipoRomaneio.TipoRomaneio != (int)mdlConstantes.Relatorio.RomaneioSimplificado)
							{
								ShowDialogVolumes();
								return(true);
							}
							else
							{
								ShowDialogAssistente();
								return(true);
							}
						} 
					}
				}
				return(false);
			}
		#endregion
		#region ShowDialogVolumes
			public bool ShowDialogVolumes()
			{
				return(ShowDialogVolumes(true));
			}

			public bool ShowDialogVolumes(bool bAutomatic)
			{
				int nIdTipoRomaneio;
				bool bEmbalagensIntermediarias,bMostrarVolumes,bMostrarEmbalagens;
				vCarregaDadosRomaneio(out nIdTipoRomaneio,out bEmbalagensIntermediarias,out bMostrarVolumes,out bMostrarEmbalagens);
				Formularios.frmFVolumeConfiguracoes formFRomaneioVolumes = new mdlRelatoriosRomaneio.Formularios.frmFVolumeConfiguracoes(m_strEnderecoExecutavel);
				formFRomaneioVolumes.Embalagens = bEmbalagensIntermediarias;
				formFRomaneioVolumes.ShowDialog();
				if (formFRomaneioVolumes.Modificado)
				{
					if (formFRomaneioVolumes.Embalagens != bEmbalagensIntermediarias)
					{
						if (bSalvaDadosRomaneio(nIdTipoRomaneio,formFRomaneioVolumes.Embalagens,bMostrarVolumes,bMostrarEmbalagens))
						{
							if (bAutomatic)
								m_bModificadoAssistente = ShowDialogAssistente();
							return(true);
						}else{
							return(false);
						}
					}else{
						if (bAutomatic)
						{
							ShowDialogAssistente();
							return(false);
						}
						return(false);
					}
				}else{
					return(false);
				}
			}
		#endregion
		#region Assistente
			private bool ShowDialogAssistente()
			{
				return(ShowDialogAssistente(true));
			}

			private bool ShowDialogAssistente(bool bOnlyIfNecessary)
			{
				int nIdTipoRomaneio;
				bool bEmbalagensIntermediarias,bMostrarVolumes,bMostrarEmbalagens;
				vCarregaDadosRomaneio(out nIdTipoRomaneio,out bEmbalagensIntermediarias,out bMostrarVolumes,out bMostrarEmbalagens);
				mdlCriacaoDocumentos.Assistentes.clsAssistente cls_Assistente = null;
				switch(nIdTipoRomaneio)
				{
					case (int)mdlConstantes.Relatorio.Romaneio:
						cls_Assistente = new mdlCriacaoDocumentos.Assistentes.clsAssistenteRomaneioProdutos(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdCodigo);
						break;
					case (int)mdlConstantes.Relatorio.RomaneioVolumes:
						cls_Assistente = new mdlCriacaoDocumentos.Assistentes.clsAssistenteRomaneioVolumes(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdCodigo);
						break;
					case (int)mdlConstantes.Relatorio.RomaneioSimplificado:
						cls_Assistente = new mdlCriacaoDocumentos.Assistentes.clsAssistenteRomaneioSimplificado(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdCodigo);
						break;
				}
				if (cls_Assistente != null)
				{
					if ((bOnlyIfNecessary) && (!cls_Assistente.HasItensToFill))
						return(true);
					cls_Assistente.Automatic = true;
					m_bModificadoAssistente = cls_Assistente.ShowDialog();
				}
				return(m_bModificadoAssistente);
			}
		#endregion

		#region Carrega Dados
			private void vCarregaDadosRomaneio(out int nTipoOrdenacao)
			{
				bool bEmbalagensIntermediarias,bMostrarVolumes,bMostrarEmbalagens;
				vCarregaDadosRomaneio(out nTipoOrdenacao,out bEmbalagensIntermediarias,out bMostrarVolumes,out bMostrarEmbalagens);
			}

			private void vCarregaDadosRomaneio(out int nTipoOrdenacao,out bool bEmbalagensIntermediarias,out bool bMostrarVolumes,out bool bMostrarEmbalagens)
			{
				bool bOtimizarEspaco,bReplicarInformacoesVolumes;
				vCarregaDadosRomaneio(out nTipoOrdenacao,out bEmbalagensIntermediarias,out bMostrarVolumes,out bMostrarEmbalagens,out bOtimizarEspaco,out bReplicarInformacoesVolumes);
			}

			private void vCarregaDadosRomaneio(out int nTipoOrdenacao,out bool bEmbalagensIntermediarias,out bool bMostrarVolumes,out bool bMostrarEmbalagens,out bool bOtimizarEspaco,out bool bReplicarInformacoesVolumes)
			{
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoTipo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("idPE");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdCodigo);

				mdlDataBaseAccess.Tabelas.XsdTbRomaneios m_typDatSetTbRomaneios = m_cls_dba_ConnectionDB.GetTbRomaneios(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
				if (m_typDatSetTbRomaneios.tbRomaneios.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow dtrwRowTbRomaneios = (mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow)m_typDatSetTbRomaneios.tbRomaneios.Rows[0];
					if (!dtrwRowTbRomaneios.IsnTipoOrdenacaoNull())
						nTipoOrdenacao = dtrwRowTbRomaneios.nTipoOrdenacao;
					else
						nTipoOrdenacao = 1;
					if (!dtrwRowTbRomaneios.IsbEmbalagensIntermediariasNull())
						bEmbalagensIntermediarias = dtrwRowTbRomaneios.bEmbalagensIntermediarias;
					else
						bEmbalagensIntermediarias = false;
					if (!dtrwRowTbRomaneios.IsbMostrarEmbalagensConsecutivasNull())
						bMostrarEmbalagens = dtrwRowTbRomaneios.bMostrarEmbalagensConsecutivas;
					else
						bMostrarEmbalagens = false;
					if (!dtrwRowTbRomaneios.IsbMostrarVolumesConsecutivosNull())
						bMostrarVolumes = dtrwRowTbRomaneios.bMostrarVolumesConsecutivos;
					else
						bMostrarVolumes = false;
					if (!dtrwRowTbRomaneios.IsbOtimizarEspacoNull())
						bOtimizarEspaco = dtrwRowTbRomaneios.bOtimizarEspaco;
					else
						bOtimizarEspaco = true;
					if (!dtrwRowTbRomaneios.IsbReplicarInformacoesVolumesNull())
						bReplicarInformacoesVolumes = dtrwRowTbRomaneios.bReplicarInformacoesVolumes;
					else
						bReplicarInformacoesVolumes = false;
				}
				else
				{
					nTipoOrdenacao = 1;
					bEmbalagensIntermediarias = false;
					bMostrarVolumes = false;
					bMostrarEmbalagens = false;
					bOtimizarEspaco = true;
					bReplicarInformacoesVolumes = false;
				}
			}
		#endregion
		#region Salva Dados 
			private bool bSalvaDadosRomaneio(bool bMostrarVolumesconsecutivos,bool bMostrarEmbalagensConsecutivas,bool bOtimizarEspaco,bool bReplicarInformacoesVolumes)
			{
				bool bRetorno = false;
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoTipo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("idPE");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdCodigo);

				mdlDataBaseAccess.Tabelas.XsdTbRomaneios m_typDatSetTbRomaneios = m_cls_dba_ConnectionDB.GetTbRomaneios(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
				if (m_typDatSetTbRomaneios.tbRomaneios.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow dtrwRowTbRomaneios = (mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow)m_typDatSetTbRomaneios.tbRomaneios.Rows[0];
					dtrwRowTbRomaneios.bMostrarVolumesConsecutivos = bMostrarVolumesconsecutivos;
					dtrwRowTbRomaneios.bMostrarEmbalagensConsecutivas = bMostrarEmbalagensConsecutivas;
					dtrwRowTbRomaneios.bOtimizarEspaco = bOtimizarEspaco;
					dtrwRowTbRomaneios.bReplicarInformacoesVolumes = bReplicarInformacoesVolumes;
					if (m_typDatSetTbRomaneios.GetChanges() != null)
					{
						try
						{
							m_cls_dba_ConnectionDB.SetTbRomaneios(m_typDatSetTbRomaneios);
							bRetorno = true;
						}
						catch
						{
							bRetorno = false;
						}
					}
					else
					{
						bRetorno = true;
					}
				}
				return(bRetorno);
			}

			private bool bSalvaDadosRomaneio(int nTipoOrdenacao,bool bMostrarVolumes,bool bMostrarEmbalagens)
			{
				bool bRetorno = false;
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoTipo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("idPE");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdCodigo);

				mdlDataBaseAccess.Tabelas.XsdTbRomaneios m_typDatSetTbRomaneios = m_cls_dba_ConnectionDB.GetTbRomaneios(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
				if (m_typDatSetTbRomaneios.tbRomaneios.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow dtrwRowTbRomaneios = (mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow)m_typDatSetTbRomaneios.tbRomaneios.Rows[0];
				    m_nIdTipoRelatorio = dtrwRowTbRomaneios.nTipoOrdenacao = nTipoOrdenacao;
					dtrwRowTbRomaneios.bMostrarVolumesConsecutivos = bMostrarVolumes;
					dtrwRowTbRomaneios.bMostrarEmbalagensConsecutivas = bMostrarEmbalagens;
					if (m_typDatSetTbRomaneios.GetChanges() != null)
					{
						try
						{
							m_cls_dba_ConnectionDB.SetTbRomaneios(m_typDatSetTbRomaneios);
							bRetorno = true;
						}
						catch
						{
							bRetorno = false;
						}
					}
					else
					{
						bRetorno = true;
					}
				}
				return(bRetorno);
			}

			private bool bSalvaDadosRomaneio(int nTipoOrdenacao,bool bEmbalagensIntermediarias,bool bMostrarVolumes,bool bMostrarEmbalagens)
			{
				bool bRetorno = false;
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoTipo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("idPE");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdCodigo);

				mdlDataBaseAccess.Tabelas.XsdTbRomaneios m_typDatSetTbRomaneios = m_cls_dba_ConnectionDB.GetTbRomaneios(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
				if (m_typDatSetTbRomaneios.tbRomaneios.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow dtrwRowTbRomaneios = (mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow)m_typDatSetTbRomaneios.tbRomaneios.Rows[0];
					m_nIdTipoRelatorio = dtrwRowTbRomaneios.nTipoOrdenacao = nTipoOrdenacao;
					dtrwRowTbRomaneios.bEmbalagensIntermediarias = bEmbalagensIntermediarias;
					dtrwRowTbRomaneios.bMostrarVolumesConsecutivos = bMostrarVolumes;
					dtrwRowTbRomaneios.bMostrarEmbalagensConsecutivas = bMostrarEmbalagens;
					if (m_typDatSetTbRomaneios.GetChanges() != null)
					{
						try
						{
							m_cls_dba_ConnectionDB.SetTbRomaneios(m_typDatSetTbRomaneios);
							bRetorno = true;
						}
						catch
						{
							bRetorno = false;
						}
					}
					else
					{
						bRetorno = true;
					}
				}
				return(bRetorno);
			}
		#endregion
	}
}
