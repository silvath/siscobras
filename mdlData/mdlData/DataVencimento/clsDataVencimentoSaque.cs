using System;

namespace mdlData.DataVencimento
{
	/// <summary>
	/// Summary description for clsDataVencimentoSaque.
	/// </summary>
	public class clsDataVencimentoSaque 
	{
		#region Atributos
			private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
			private mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB;
			private string m_strEnderecoExecutavel = "";
			private int m_nIdExportador;
			private string m_strIdPE;

			private string m_strData = "";
			private string m_strDataDefault = null;
		#endregion
		#region Propriedades
			public string Data
			{
				get
				{
					return(m_strData);
				}
			}

			private string DataDefault
			{
				get
				{
					if (m_strDataDefault == null)
						vCarregaDadosDefault();
					return(m_strDataDefault);
				}
			}
		#endregion
		#region Construtors and Destrutors
			public clsDataVencimentoSaque(ref mdlTratamentoErro.clsTratamentoErro tratadorErro,ref mdlDataBaseAccess.clsDataBaseAccess conexaoBD,string strEnderecoExecutavel,int nIdExportador,string strIdPE)
			{
				m_cls_ter_tratadorErro = tratadorErro;
				m_cls_dba_ConnectionDB = conexaoBD;
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				m_nIdExportador = nIdExportador;
				m_strIdPE = strIdPE;
				vCarregaDados();
			}
		#endregion

		#region Carregamento dos Dados
			private mdlDataBaseAccess.Tabelas.XsdTbSaques XsdDatSetSaque()
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

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				return(m_cls_dba_ConnectionDB.GetTbSaques(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null));
			}

			private void vCarregaDados()
			{
				mdlDataBaseAccess.Tabelas.XsdTbSaques typDatSetSaque = XsdDatSetSaque();
				if (typDatSetSaque.tbSaques.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbSaques.tbSaquesRow dtrwSaque = (mdlDataBaseAccess.Tabelas.XsdTbSaques.tbSaquesRow)typDatSetSaque.tbSaques.Rows[0];
					if (!dtrwSaque.IsmstrDataVencimentoNull())
					{
						m_strData = dtrwSaque.mstrDataVencimento;
					}else{
						m_strData = this.DataDefault;
					}
				}
			}

			private void vCarregaDadosDefault()
			{
				mdlDataBaseAccess.Tabelas.XsdTbSaques typDatSetSaque = XsdDatSetSaque();
				if (typDatSetSaque.tbSaques.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbSaques.tbSaquesRow dtrwSaque = (mdlDataBaseAccess.Tabelas.XsdTbSaques.tbSaquesRow)typDatSetSaque.tbSaques.Rows[0];
					vCarregaDadosDefault(ref dtrwSaque);
				}
			}

			private void vCarregaDadosDefault(ref mdlDataBaseAccess.Tabelas.XsdTbSaques.tbSaquesRow dtrwSaque)
			{
				// Idioma
				int nIdIdioma = 3;
				if (!dtrwSaque.IsnIdIdiomaNull())
					nIdIdioma = dtrwSaque.nIdIdioma;
				System.Windows.Forms.ImageList ilBandeiras = null;
				mdlEsquemaPagamento.clsEsquemaPagamento objEsq = new mdlEsquemaPagamento.clsEsquemaPagamentoFaturaComercial(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,ref ilBandeiras,m_nIdExportador,m_strIdPE);
				System.Text.StringBuilder strbData = new System.Text.StringBuilder();
				if ((objEsq.CondicaoAvista) > 0)
				{
					switch(nIdIdioma)
					{
						case (int)mdlConstantes.Idioma.Portugues:
							strbData.Append("A Vista");
							break;
						case (int)mdlConstantes.Idioma.Ingles:
							strbData.Append("At Sight");
							break;
					}
				}

				if (((objEsq.CondicaoPostecipado) > 0) && (objEsq.PostecipadoCondicao != mdlEsquemaPagamento.DocumentoCondicao.Aceite))
				{
					System.DateTime dtData = System.DateTime.Now;
					string strFormato = "dd/MMM/yyyy"; 
					switch(objEsq.PostecipadoCondicao)
					{
						case mdlEsquemaPagamento.DocumentoCondicao.Conhecimento:
							mdlData.clsData objDataConhecimento = new mdlData.DataEmbarque.Faturas.clsDataEmbarqueComercial(ref m_cls_ter_tratadorErro, ref m_cls_dba_ConnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE);
							dtData = objDataConhecimento.Data;
							if (dtData.Equals(mdlConstantes.clsConstantes.DATANULA))
							{
								m_strDataDefault = "";
								return;
							}
							break;
						case mdlEsquemaPagamento.DocumentoCondicao.Fatura:
							mdlData.clsData objData = new mdlData.DataEmissao.Faturas.clsDataEmissaoComercial(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPE);
							dtData = objData.Data;
							break;
						case mdlEsquemaPagamento.DocumentoCondicao.Saque:
							if (!dtrwSaque.IsdtDataEmissaoNull())
								dtData = dtrwSaque.dtDataEmissao;
							break;
					}
					vIncrementaData(ref dtData,objEsq.PostecipadoUnidadeTempo,objEsq.PostecipadoQuantTempo);
					if (strbData.Length != 0)
						strbData.Append(" , ");
					strbData.Append(dtData.ToString(strFormato));
					for(int i = 1; i < objEsq.PostecipadoQuantidadeParcelas;i++)
					{
						vIncrementaData(ref dtData,objEsq.PostecipadoUnidadeTempo,objEsq.PostecipadoIntervalo);
						strbData.Append(" , ");
						strbData.Append(dtData.ToString(strFormato));
					}
				}
				m_strDataDefault = strbData.ToString();
			}

			private void vIncrementaData(ref System.DateTime dtData,mdlEsquemaPagamento.UnidadeTempo enumUnidadeTempo,int nIncremento)
			{
				if (enumUnidadeTempo == mdlEsquemaPagamento.UnidadeTempo.Dia)
					dtData = dtData.AddDays(nIncremento);
				else
					dtData = dtData.AddMonths(nIncremento);
			}
		#endregion
		#region Salvamento dos Dados
			private bool bSalvaDados()
			{
				mdlDataBaseAccess.Tabelas.XsdTbSaques typDatSetSaque = XsdDatSetSaque();
				if (typDatSetSaque.tbSaques.Rows.Count == 0)
					return(false);
				mdlDataBaseAccess.Tabelas.XsdTbSaques.tbSaquesRow dtrwSaque = (mdlDataBaseAccess.Tabelas.XsdTbSaques.tbSaquesRow)typDatSetSaque.tbSaques.Rows[0];
				dtrwSaque.mstrDataVencimento = m_strData;
				m_cls_dba_ConnectionDB.SetTbSaques(typDatSetSaque);
				return(m_cls_dba_ConnectionDB.Erro == null);
			}
		#endregion

		#region ShowDialog
			public bool bShowDialog()
			{
				mdlPaletaDeCores.clsPaletaDeCores clsPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini","SiscobrasCorSecundaria");
				frmFDataAberta formFAberta = new frmFDataAberta(clsPaletaCores.retornaCorAtual());
				formFAberta.Data = this.Data;
				formFAberta.DataDefault = this.DataDefault;
				formFAberta.ShowDialog();
				if (formFAberta.Modificado)
				{
					m_strData = formFAberta.Data;
					return(bSalvaDados());
				}
				return(false);
			}
		#endregion
	}
}
