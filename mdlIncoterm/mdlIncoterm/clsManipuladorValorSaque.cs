using System;

namespace mdlIncoterm
{
	/// <summary>
	/// Summary description for clsManipuladorValorSaque.
	/// </summary>
	public class clsManipuladorValorSaque
	{
		#region Atributes
			private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
			private mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB;
			private string m_strEnderecoExecutavel = "";
			private int m_nIdExportador;
			private string m_strIdPE;

			private double m_dValor = -1;
			private string m_strValorExtenso = null;
			private string m_strValorExtensoDefault = null;

		#endregion
		#region Properties
		private double Valor
		{
			get
			{
				if (m_dValor == -1)
				{
					mdlIncoterm.clsManipuladorValor objManValor = new mdlIncoterm.clsManipuladorValor(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_nIdExportador,m_strIdPE);
					m_dValor = objManValor.dCarregaValorSaque();
				}
				return(m_dValor);
			}
		}


		public string ValorExtenso
		{
			get
			{
				if (m_strValorExtenso == null)
					vCaregaDadosValorExtenso();
				return(m_strValorExtenso);
			}
		}

		private string ValorExtensoDefault
		{
			get
			{
				if (m_strValorExtensoDefault == null)
					vCaregaDadosValorExtensoDefault();
				return(m_strValorExtensoDefault);
			}
		}
		#endregion
		#region Constructors e Destrutores
		public clsManipuladorValorSaque(ref mdlTratamentoErro.clsTratamentoErro tratadorErro,ref mdlDataBaseAccess.clsDataBaseAccess conexaoBD,string strEnderecoExecutavel,int nIdExportador,string strIdPE)
		{
			m_cls_ter_tratadorErro = tratadorErro;
			m_cls_dba_ConnectionDB = conexaoBD;
			m_strEnderecoExecutavel = strEnderecoExecutavel;
			m_nIdExportador = nIdExportador;
			m_strIdPE = strIdPE;
		}
		#endregion

		#region Carregamento Dados
			private void vCarregaDados(out string strSimboloMoeda,out double dValorFatura,out double dValorAntecipado,out double dValorSaque)
			{
				int nTemp;
				string strTemp;
				bool bTemp;
				mdlMoeda.clsMoeda objMoeda = new mdlMoeda.clsMoedaComercial(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPE);
				objMoeda.retornaValores(out nTemp,out strTemp,out strSimboloMoeda,out bTemp);
				mdlIncoterm.clsManipuladorValor objManValor = new mdlIncoterm.clsManipuladorValor(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_nIdExportador,m_strIdPE);
				dValorSaque = objManValor.dCarregaValorSaque();
				objManValor.vRetornaValores(out dValorFatura);
				dValorAntecipado = objManValor.dValorFaturaSomenteAntecipado();
			}

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


			private void vCaregaDadosValorExtenso()
			{
				mdlDataBaseAccess.Tabelas.XsdTbSaques typDatSetSaque = XsdDatSetSaque();
				if (typDatSetSaque.tbSaques.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbSaques.tbSaquesRow dtrwSaque = (mdlDataBaseAccess.Tabelas.XsdTbSaques.tbSaquesRow)typDatSetSaque.tbSaques.Rows[0];
					if (!dtrwSaque.IsmstrValorNull())
					{
						m_strValorExtenso = dtrwSaque.mstrValor;
					}else{
						m_strValorExtenso = this.ValorExtensoDefault;
					}
				}
			}

			private void vCaregaDadosValorExtensoDefault()
			{
				mdlDataBaseAccess.Tabelas.XsdTbSaques typDatSetSaque = XsdDatSetSaque();
				if (typDatSetSaque.tbSaques.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbSaques.tbSaquesRow dtrwSaque = (mdlDataBaseAccess.Tabelas.XsdTbSaques.tbSaquesRow)typDatSetSaque.tbSaques.Rows[0];

					// Idioma
					int nIdIdioma = 3;
					if (!dtrwSaque.IsnIdIdiomaNull())
						nIdIdioma = dtrwSaque.nIdIdioma;
					// Moeda
					int nIdMoeda = 28;
					string strTemp;
					bool bTemp;
					mdlMoeda.clsMoeda objMoeda = new mdlMoeda.clsMoedaComercial(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPE);
					objMoeda.retornaValores(out nIdMoeda,out strTemp,out strTemp,out bTemp);
					m_strValorExtensoDefault = mdlConversao.clsValorExtenso.strRetornaValorExtenso(this.Valor,nIdIdioma,nIdMoeda);
				}
			}
		#endregion
		#region Salva Dados
			private bool bSalvaDadosSaque(double dValorSaque)
			{
				mdlIncoterm.clsManipuladorValor objManValor = new mdlIncoterm.clsManipuladorValor(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_nIdExportador,m_strIdPE);
				return(objManValor.bSalvaValorSaque(dValorSaque));
			}

			private bool bSalvaValorExtensoSaque(string strValorExtenso)
			{
				mdlDataBaseAccess.Tabelas.XsdTbSaques typDatSetSaque = XsdDatSetSaque();
				if (typDatSetSaque.tbSaques.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbSaques.tbSaquesRow dtrwSaque = (mdlDataBaseAccess.Tabelas.XsdTbSaques.tbSaquesRow)typDatSetSaque.tbSaques.Rows[0];
					dtrwSaque.mstrValor = strValorExtenso;
					m_cls_dba_ConnectionDB.SetTbSaques(typDatSetSaque);
					return(m_cls_dba_ConnectionDB.Erro == null);
				}else{
					return(false);
				}
			}
		#endregion

		#region ShowDialog
			public bool bShowDialogValor()
			{
				bool bRetorno = false;
				string strSimboloMoeda;
				double dValorFatura,dValorAntecipado,dValorSaque;
				vCarregaDados(out strSimboloMoeda,out dValorFatura,out dValorAntecipado,out dValorSaque);
				frmFValorSaque formFValorSaque = new frmFValorSaque(m_strEnderecoExecutavel,strSimboloMoeda,dValorFatura,dValorAntecipado,dValorSaque);
				formFValorSaque.ShowDialog();
				if (formFValorSaque.Modified)
				{
					dValorSaque = 0;
					formFValorSaque.vRetornaValores(out dValorSaque);
					bRetorno = bSalvaDadosSaque(dValorSaque);
				}
				return(bRetorno);
			}
		#endregion
		#region ShowDialogValorExtenso
			public bool bShowDialogValorExtenso()
			{
				bool bRetorno = false;
				mdlPaletaDeCores.clsPaletaDeCores clsPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini","SiscobrasCorSecundaria");
				frmFValorSaqueExtenso formFValorExtenso = new frmFValorSaqueExtenso(clsPaletaCores.retornaCorAtual());
				formFValorExtenso.ValorExtenso = this.ValorExtenso;
				formFValorExtenso.ValorExtensoDefault = this.ValorExtensoDefault;
				formFValorExtenso.ShowDialog();
				if (formFValorExtenso.Modificado)
					bRetorno = bSalvaValorExtensoSaque(formFValorExtenso.ValorExtenso);
				return(bRetorno);
			}
		#endregion

	}
}
