using System;

namespace mdlProdutosCertificadoOrigem
{
	/// <summary>
	/// Summary description for clsEspacamento.
	/// </summary>
	public class clsEspacamento
	{
		#region Atributes
			protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
			protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB;
			protected string m_strEnderecoExecutavel;

			protected int m_nIdExportador = -1;
			protected string m_strIdPE = "";
			protected int m_nIdTipoCO = -1;

			private int m_nEspacamento = -1;
			private string m_strEspacamento = "";
			protected string m_strNorma = "";

		#endregion
		#region Properties
		public string Normas
		{
			get
			{
				if (m_strNorma == "")
					m_strNorma = strCarregaDadosNormaDeOrigem();
				return(m_strNorma);
			}
		}

		private string TextoEspacamento
		{
			get
			{
				if(m_strEspacamento == "")
					m_strEspacamento = strTextoEspacamento();
				return(m_strEspacamento);
			}
		}

		private int Espacamento
		{
			set
			{
				if (m_nEspacamento != value)
				{
					m_nEspacamento = value;
					bSalvaEspacamento();
				}
			}
			get
			{
				if (m_nEspacamento == -1)
					vCarregaEspacamento();
				return(m_nEspacamento);
			}
		}
		#endregion
		#region Constructors and Destructors
			public clsEspacamento(ref mdlTratamentoErro.clsTratamentoErro cls_ter_tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB,string strEnderecoExecutavel,int nIdExportador,string strIdPE, int nIdTipoCO)
			{
				m_cls_ter_tratadorErro = cls_ter_tratadorErro;
				m_cls_dba_ConnectionDB = cls_dba_ConnectionDB;
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				m_nIdExportador = nIdExportador;
				m_strIdPE = strIdPE;
				m_nIdTipoCO = nIdTipoCO;
			}
		#endregion

		#region ShowDialog
			public bool ShowDialog()
			{
				Formularios.frmFEspacamento formFEspacamento = new mdlProdutosCertificadoOrigem.Formularios.frmFEspacamento(m_strEnderecoExecutavel);
				formFEspacamento.Espacamento = this.Espacamento;
				formFEspacamento.ShowDialog();
				if (formFEspacamento.Modificado)
					this.Espacamento = formFEspacamento.Espacamento;
				return(formFEspacamento.Modificado);
			}
		#endregion

		#region Normas
			private void vCarregaNormas(int nIdTipoCO,out System.Collections.ArrayList arlNormOrder,out System.Collections.ArrayList arlNormDescription)
			{
				arlNormOrder = new System.Collections.ArrayList();
				arlNormDescription = new System.Collections.ArrayList();

				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();

				// Typed Dat Sets
				arlCondicaoCampo.Add("nIdTipoCO");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdTipoCO);

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
				mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigemNormas typDatSetNormasResource = m_cls_dba_ConnectionDB.GetTbCertificadosOrigemNormas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigemNormas typDatSetNormasDataBase = m_cls_dba_ConnectionDB.GetTbCertificadosOrigemNormas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				arlCondicaoCampo.Clear();
				arlCondicaoCampo.Add("idTipoCO");

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);
				arlCondicaoCampo.Add("idPe");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdPE);

				arlOrdenacaoCampo.Add("idOrdem"); 
				arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente);

				mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem typDatSetProdutosCertificadoOrigem = m_cls_dba_ConnectionDB.GetTbProdutosCertificadoOrigem(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);

				// Inserindo Normas
				foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow dtrwProdutoCertificado in typDatSetProdutosCertificadoOrigem.tbProdutosCertificadoOrigem.Rows)
				{
					if (!arlNormOrder.Contains(dtrwProdutoCertificado.idOrdem))
					{
						arlNormOrder.Add(dtrwProdutoCertificado.idOrdem);
						if ((!dtrwProdutoCertificado.IsmstrNormaNull()) && (dtrwProdutoCertificado.mstrNorma.Trim() != ""))
						{
							arlNormDescription.Add(dtrwProdutoCertificado.mstrNorma.Trim());
						}
						else
						{
							mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigemNormas.tbCertificadosOrigemNormasRow dtrwNorma = typDatSetNormasDataBase.tbCertificadosOrigemNormas.FindBynIdTipoCOnIdNorma(nIdTipoCO,dtrwProdutoCertificado.idNorma);
							if ((dtrwNorma != null) && (dtrwNorma.mstrNome.Trim() != ""))
							{
								arlNormDescription.Add(dtrwNorma.mstrNome.Trim());
							}
							else
							{
								dtrwNorma = typDatSetNormasResource.tbCertificadosOrigemNormas.FindBynIdTipoCOnIdNorma(nIdTipoCO,dtrwProdutoCertificado.idNorma);
								if ((dtrwNorma != null) && (dtrwNorma.mstrNome.Trim() != ""))
								{
									arlNormDescription.Add(dtrwNorma.mstrNome.Trim());
								}
								else
								{
									arlNormDescription.Add("");
								}
							}
						}
					}
				}
			}
		#endregion
		#region Espacamento
			private string strTextoEspacamento()
			{
				string strReturn = "";
				for(int i = 0; i < this.Espacamento;i++)
					strReturn += " ";
				return(strReturn);
			}

			private void vCarregaEspacamento()
			{
				m_nEspacamento = 10;
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();
				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);
				arlCondicaoCampo.Add("idPE");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdPE);
				arlCondicaoCampo.Add("nIdTipoCO");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdTipoCO);
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem typDatSetCertificadosOrigem = m_cls_dba_ConnectionDB.GetTbCertificadosOrigem(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				if (typDatSetCertificadosOrigem.tbCertificadosOrigem.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow dtrwCertificado = (mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow)typDatSetCertificadosOrigem.tbCertificadosOrigem.Rows[0];
					if (!dtrwCertificado.IsnEspacamentoNull())
						m_nEspacamento = dtrwCertificado.nEspacamento;
				}
			}

			private bool bSalvaEspacamento()
			{
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();
				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);
				arlCondicaoCampo.Add("idPE");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdPE);
				arlCondicaoCampo.Add("nIdTipoCO");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdTipoCO);
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem typDatSetCertificadosOrigem = m_cls_dba_ConnectionDB.GetTbCertificadosOrigem(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				if (typDatSetCertificadosOrigem.tbCertificadosOrigem.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow dtrwCertificado = (mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow)typDatSetCertificadosOrigem.tbCertificadosOrigem.Rows[0];
					dtrwCertificado.nEspacamento = this.Espacamento;
					m_cls_dba_ConnectionDB.SetTbCertificadosOrigem(typDatSetCertificadosOrigem);
					return(m_cls_dba_ConnectionDB.Erro == null);
				}
				return(false);
			}
		#endregion
		#region Retorno
		private string strCarregaDadosNormaDeOrigem()
		{
			System.Collections.ArrayList arlNormasStr, arlNormasStrCopia = new System.Collections.ArrayList(), arlIdOrdem;
			string strRetorno = "";
			vCarregaNormas(m_nIdTipoCO,out arlIdOrdem, out arlNormasStr);
			foreach(string strNorma in arlNormasStr)
			{
				arlNormasStrCopia.Add(strNorma);
			}
			int nIdOrdem = 0, nPrimeiroIdIntervalo = 0, nIdAtualIntervalo = 0;
			for(int nCount = 0; nCount < arlNormasStr.Count; nCount++)
			{
				nIdOrdem = nPrimeiroIdIntervalo = nIdAtualIntervalo = 0;
				if (arlNormasStrCopia.LastIndexOf(arlNormasStr[nCount]) == arlNormasStrCopia.IndexOf(arlNormasStr[nCount]))
					strRetorno += arlIdOrdem[nCount].ToString() + this.TextoEspacamento + arlNormasStr[nCount].ToString() + System.Environment.NewLine;
				else if (strRetorno.IndexOf(arlNormasStr[nCount].ToString()) == -1)
				{
					nIdOrdem = nCount;
					while(nIdOrdem != -1)
					{
						nIdOrdem = arlNormasStr.IndexOf(arlNormasStr[nCount], nIdOrdem);
						if (nIdOrdem != -1)
						{
							if (nPrimeiroIdIntervalo == 0)
							{
								nPrimeiroIdIntervalo = nIdAtualIntervalo = (int)arlIdOrdem[nIdOrdem];
								strRetorno += nPrimeiroIdIntervalo.ToString() + "-" + nIdAtualIntervalo.ToString();
							}
							else
							{
								if ((nIdAtualIntervalo + 1) == (int)arlIdOrdem[nIdOrdem])
								{
									string strAntiga = nPrimeiroIdIntervalo.ToString() + "-" + nIdAtualIntervalo.ToString();
									nIdAtualIntervalo++;
									string strNova = nPrimeiroIdIntervalo.ToString() + "-" + nIdAtualIntervalo.ToString();
									strRetorno = strRetorno.Replace(strAntiga ,strNova);									
								}
								else
								{
									nPrimeiroIdIntervalo = nIdAtualIntervalo = (int)arlIdOrdem[nIdOrdem];
									strRetorno += "; " + nPrimeiroIdIntervalo.ToString() + "-" + nIdAtualIntervalo.ToString();
								}
							}
							nIdOrdem++;
						}
					}
					strRetorno += this.TextoEspacamento + arlNormasStr[nCount].ToString() + System.Environment.NewLine;
				}
			}
			if (strRetorno.Length > 2)
				strRetorno = strRetorno.Substring(0, strRetorno.Length - 2);
			return(strRetorno);
		}
		#endregion
	}
}
