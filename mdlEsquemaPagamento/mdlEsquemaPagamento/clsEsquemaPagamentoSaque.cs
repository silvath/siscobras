using System;

namespace mdlEsquemaPagamento
{
	/// <summary>
	/// Summary description for clsEsquemaPagamentoSaque.
	/// </summary>
	public class clsEsquemaPagamentoSaque
	{
		#region Atributes
			private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro; 
			private mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB;
			private string m_strEnderecoExecutavel; 

			private int m_nIdExportador;
			private string m_strIdPe;
			private string m_strCondicaoPagamento = "";
			private string m_strCondicaoPagamentoDefault = null;
		#endregion
		#region Propriedades
			public string CondicaoPagamento
			{
				get
				{
					return(m_strCondicaoPagamento);
				}
			}

			private string CondicaoPagamentoDefault
			{
				get
				{
					if (m_strCondicaoPagamentoDefault == null)
						vCarregaDadosDefault();
					return(m_strCondicaoPagamentoDefault);
				}
			}

		#endregion
		#region Constructors and Destructors
		public clsEsquemaPagamentoSaque(ref mdlTratamentoErro.clsTratamentoErro tratadorErro , ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB , string strEnderecoExecutavel,int idExportador,string idPe)
		{
			m_cls_ter_tratadorErro = tratadorErro; 
			m_cls_dba_ConnectionDB = ConnectionDB;

			m_strEnderecoExecutavel = strEnderecoExecutavel; 
			m_nIdExportador = idExportador;
			m_strIdPe = idPe;

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
				arlCondicaoValor.Add(m_strIdPe);

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				return(m_cls_dba_ConnectionDB.GetTbSaques(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null));
			}

			private void vCarregaDados()
			{
			    mdlDataBaseAccess.Tabelas.XsdTbSaques typDatSetSaque = XsdDatSetSaque();
				if (typDatSetSaque.tbSaques.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbSaques.tbSaquesRow dtrwSaque = (mdlDataBaseAccess.Tabelas.XsdTbSaques.tbSaquesRow)typDatSetSaque.tbSaques.Rows[0];
					if (!dtrwSaque.IsmstrCondicaoPagamentoNull())
					{
						m_strCondicaoPagamento = dtrwSaque.mstrCondicaoPagamento;
					}else{
						m_strCondicaoPagamento = this.CondicaoPagamentoDefault;
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
				clsEsquemaPagamentoFaturaComercial obj = new clsEsquemaPagamentoFaturaComercial(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,ref ilBandeiras,m_nIdExportador,m_strIdPe);
				obj.MostrarPorValores = true;
				obj.MostrarCondicaoAntecipada = false;
				obj.vRetornaValores(nIdIdioma,out m_strCondicaoPagamentoDefault);
			}
		#endregion
		#region Salvamento dos Dados
			private bool bSalvaDados()
			{
				mdlDataBaseAccess.Tabelas.XsdTbSaques typDatSetSaque = XsdDatSetSaque();
				if (typDatSetSaque.tbSaques.Rows.Count == 0)
					return(false);
				mdlDataBaseAccess.Tabelas.XsdTbSaques.tbSaquesRow dtrwSaque = (mdlDataBaseAccess.Tabelas.XsdTbSaques.tbSaquesRow)typDatSetSaque.tbSaques.Rows[0];
				dtrwSaque.mstrCondicaoPagamento = m_strCondicaoPagamento;
				m_cls_dba_ConnectionDB.SetTbSaques(typDatSetSaque);
				return(m_cls_dba_ConnectionDB.Erro == null);
			}
		#endregion

		#region ShowDialog
			public bool ShowDialog()
			{
				mdlPaletaDeCores.clsPaletaDeCores clsPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini","SiscobrasCorSecundaria");
				frmFEsquemaPagamentoAberto formFEsquemaPagamento = new frmFEsquemaPagamentoAberto(clsPaletaCores.retornaCorAtual());
				formFEsquemaPagamento.CondicaoPagamento = m_strCondicaoPagamento;
				formFEsquemaPagamento.CondicaoPagamentoDefault = this.CondicaoPagamentoDefault;
				formFEsquemaPagamento.ShowDialog();
				if (formFEsquemaPagamento.Modificado)
				{
					m_strCondicaoPagamento = formFEsquemaPagamento.CondicaoPagamento;
					return(bSalvaDados());
				}
				return(false);
			}
		#endregion
	}
}
