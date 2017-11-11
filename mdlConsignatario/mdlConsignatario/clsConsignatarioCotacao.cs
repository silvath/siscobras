using System;

namespace mdlConsignatario
{
	/// <summary>
	/// Summary description for clsConsignatarioCotacao.
	/// </summary>
	public class clsConsignatarioCotacao
	{
		#region Atributes
			private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
			private mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB;
			private string m_strEnderecoExecutavel;
			private int m_nIdExportador;
			private string m_strIdCodigo;

			private clsConsignatario m_clsConsignatario = null;

			private int m_nIdImportador = -1;
			private int m_nIdConsignatario = -1;

			private bool m_bModificado = false;
		#endregion
		#region Properties
			private clsConsignatario Consignatario
			{
				get
				{
					if (m_clsConsignatario == null)
					{
						m_clsConsignatario = new clsConsignatario(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,"");
						m_clsConsignatario.DataAccess = false;
						m_clsConsignatario.IdImportador = m_nIdImportador;
						m_clsConsignatario.IdConsignatario = m_nIdConsignatario;
					}
					return(m_clsConsignatario);
				}
			}
		#endregion
		#region Constructors
			public clsConsignatarioCotacao(ref mdlTratamentoErro.clsTratamentoErro cls_ter_tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB,string strEnderecoExecutavel, int nIdExportador, string strIdCodigo)
			{
				m_cls_ter_tratadorErro = cls_ter_tratadorErro;
				m_cls_dba_ConnectionDB = cls_dba_ConnectionDB;
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				m_nIdExportador = nIdExportador;
				m_strIdCodigo = strIdCodigo;
				vCarregaDados();
			}
		#endregion

		#region Carregamento dos Dados
			private mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes dtstReturnFaturasCotacoes()
			{
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);
				arlCondicaoCampo.Add("idCotacao");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdCodigo);

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				return(m_cls_dba_ConnectionDB.GetTbFaturasCotacoes(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null));
			}

			private void vCarregaDados()
			{
				mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes typDatSetFaturasCotacoes = dtstReturnFaturasCotacoes();
				if ((typDatSetFaturasCotacoes != null) && (typDatSetFaturasCotacoes.tbFaturasCotacoes.Rows.Count > 0))
				{
					mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow dtrwFaturaCotacao = (mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow)typDatSetFaturasCotacoes.tbFaturasCotacoes.Rows[0];
					if (!dtrwFaturaCotacao.IsidImportadorNull())
						m_nIdImportador = dtrwFaturaCotacao.idImportador;
					if (!dtrwFaturaCotacao.IsnIdConsignatarioNull())
						m_nIdConsignatario = dtrwFaturaCotacao.nIdConsignatario;
				}
			}
		#endregion
		#region Salvamento dos Dados
			private bool bSalvaDados()
			{
				mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes typDatSetFaturasCotacoes = dtstReturnFaturasCotacoes();
				if ((typDatSetFaturasCotacoes != null) && (typDatSetFaturasCotacoes.tbFaturasCotacoes.Rows.Count > 0))
				{
					mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow dtrwFaturaCotacao = (mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow)typDatSetFaturasCotacoes.tbFaturasCotacoes.Rows[0];
					dtrwFaturaCotacao.nIdConsignatario = m_nIdConsignatario;
					m_cls_dba_ConnectionDB.SetTbFaturasCotacoes(typDatSetFaturasCotacoes);
					return(m_cls_dba_ConnectionDB.Erro == null);
				}else{
					return(false);
				}
			}
		#endregion

		#region ShowDialog
			public bool ShowDialog()
			{
				if (this.m_nIdImportador == -1)
					return(false);
				this.Consignatario.ShowDialog();
				if (m_bModificado = this.Consignatario.m_bModificado)
				{
					m_nIdConsignatario = this.Consignatario.IdConsignatario;
					return(bSalvaDados());
				}else{
					return(false);
				}
			}
		#endregion

		#region Retorna Valores
			public void retornaValores(out string strConsignatario, out string strEnderecoConsignatario, out string strCidade, out string strEstado, out string strPais)
			{
				this.Consignatario.retornaValores(out strConsignatario, out strEnderecoConsignatario, out strCidade, out strEstado, out strPais);
			}
			public void retornaValores(out int nIdConsignatario, out string strConsignatario, out string strEnderecoConsignatario, out string strCidade, out string strEstado, out string strPais)
			{
				this.Consignatario.retornaValores(out nIdConsignatario, out strConsignatario, out strEnderecoConsignatario, out strCidade, out strEstado, out strPais);
			}
		#endregion
	}
}

