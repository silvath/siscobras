using System;

namespace mdlNormas.CO
{
	/// <summary>
	/// Summary description for clsNormasAladiAce39.
	/// </summary>
	public class clsNormasAladiAce39 : clsNormas
	{
		#region Constants
			private const int CERTIFICADO_ALADI_ACE39 = 5;
		#endregion
		#region Construtors and Destructors
			public clsNormasAladiAce39(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess conexaoBD,string EnderecoExecutavel, int nIdExportador, string strIdPE): base (ref tratadorErro, ref conexaoBD,EnderecoExecutavel, CERTIFICADO_ALADI_ACE39)
			{
				m_nIdExportador = nIdExportador;
				m_strIdPE = strIdPE;
				base.bCarregaDados();
				this.carregaTypDatSet();
				base.carregaDadosBD();
			}
		#endregion
		#region Carregamento dos Dados
		#region Banco de Dados
		protected void carregaTypDatSet()
		{
			try
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

				arlCondicaoCampo.Add("idTipoCO");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(CERTIFICADO_ALADI_ACE39);

				arlOrdenacaoCampo.Add("idOrdem");
				arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente);

				m_typDatSetTbProdutosCertificadoOrigem = m_cls_dba_ConnectionDB.GetTbProdutosCertificadoOrigem(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected override void carregaDadosBDEspecificos()
		{
			try
			{
				m_arlIdOrdemCOs.Clear();
				m_arlNormasCOs.Clear();
				foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow dtrwTbProdutosCertificadoOrigem in m_typDatSetTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigem.Rows)
				{
					if (!m_arlIdOrdemCOs.Contains(dtrwTbProdutosCertificadoOrigem.idOrdem))
					{
						m_arlNormasCOs.Add(dtrwTbProdutosCertificadoOrigem.idNorma);
						m_arlIdOrdemCOs.Add(dtrwTbProdutosCertificadoOrigem.idOrdem);
					}
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Interface
		protected override void carregaDadosInterfaceEspecificos(ref System.Windows.Forms.Form formNorma)
		{
			try
			{
				formNorma.Text = "Aladi Ace 39";
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
