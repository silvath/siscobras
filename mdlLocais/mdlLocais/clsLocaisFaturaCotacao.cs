using System;

namespace mdlLocais
{
	/// <summary>
	/// Summary description for clsLocaisFaturaCotacao.
	/// </summary>
	public class clsLocaisFaturaCotacao : clsLocais
	{
		#region Atributes
		private string m_strIdCotacao = "";
		// Typed DataSets
		protected mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes m_typDatSetTbFaturasCotacoes = null;
		#endregion

		#region Constructor and Destructors
		public clsLocaisFaturaCotacao(ref mdlTratamentoErro.clsTratamentoErro cls_ter_tratadorErro,ref mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB, string strEnderecoExecutavel, int nIdExportador,string strIdCotacao) : base(ref cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB, strEnderecoExecutavel,nIdExportador) 
		{
			m_strIdCotacao = strIdCotacao;
			carregaTypDatSet();
			carregaDadosBD();
		}
		public clsLocaisFaturaCotacao(ref mdlTratamentoErro.clsTratamentoErro cls_ter_tratadorErro,ref mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB, string strEnderecoExecutavel, int nIdExportador,string strIdCotacao, ref mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes typDatSetTbFaturasCotacoes) : base(ref cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB, strEnderecoExecutavel, nIdExportador) 
		{
			m_strIdCotacao = strIdCotacao;
			m_bBotaoIncotermHabilitado = false;
			m_typDatSetTbFaturasCotacoes = typDatSetTbFaturasCotacoes;
			carregaTypDatSet();
			carregaDadosBD();
		}
		#endregion

		#region Carregamento de Dados
		#region Banco de Dados
		protected new void carregaTypDatSet()
		{
			try 
			{
				if (m_typDatSetTbFaturasCotacoes == null)
				{
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
			
					arlCondicaoCampo.Add("idExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_nIdExportador);

					arlCondicaoCampo.Add("idCotacao");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_strIdCotacao);

					m_typDatSetTbFaturasCotacoes = m_cls_dba_ConectionDB.GetTbFaturasCotacoes(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				}
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected override void carregaDadosBDEspecifico()
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow dtrwRowTbFaturasCotacoes = null;
				if (m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.Rows.Count > 0)
				{
					dtrwRowTbFaturasCotacoes = (mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow)m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.Rows[0];
					if (!dtrwRowTbFaturasCotacoes.IslocalColetaNull())
						m_strLocalColeta = dtrwRowTbFaturasCotacoes.localColeta;
					if (!dtrwRowTbFaturasCotacoes.IslocalDespachoNull())
						m_strLocalDespacho = dtrwRowTbFaturasCotacoes.localDespacho;
					if (!dtrwRowTbFaturasCotacoes.IslocalDestinoNull())
						m_strLocalDestino = dtrwRowTbFaturasCotacoes.localDestino;
					if (!dtrwRowTbFaturasCotacoes.IslocalEmbarqueNull())
						m_strLocalEmbarque = dtrwRowTbFaturasCotacoes.localEmbarque;
					if (!dtrwRowTbFaturasCotacoes.IslocalEntregaNull())
						m_strLocalEntrega = dtrwRowTbFaturasCotacoes.localEntrega;
					if (!dtrwRowTbFaturasCotacoes.IsidIncotermNull())
						m_nIdIncoterm = dtrwRowTbFaturasCotacoes.idIncoterm;
					if (!dtrwRowTbFaturasCotacoes.IsidImportadorNull())
						m_nIdImportador = dtrwRowTbFaturasCotacoes.idImportador;
				}
				base.carregaTypDatSet();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#endregion
		#region Salvamento de Dados
		#region Interface
		protected override void salvaDadosInterfaceEspecifico()
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow dtrwRowTbFaturasCotacoes = null;
				if (m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.Rows.Count > 0)
				{
					dtrwRowTbFaturasCotacoes = (mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow)m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.Rows[0];
					dtrwRowTbFaturasCotacoes.localColeta = m_strLocalColeta;
					dtrwRowTbFaturasCotacoes.localDespacho = m_strLocalDespacho;
					dtrwRowTbFaturasCotacoes.localDestino = m_strLocalDestino;
					dtrwRowTbFaturasCotacoes.localEmbarque = m_strLocalEmbarque;
					dtrwRowTbFaturasCotacoes.localEntrega = m_strLocalEntrega;
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Banco de Dados
		protected override void salvaDadosBDEspecifico()
		{
			try
			{
				if (m_bBotaoIncotermHabilitado)
                    m_cls_dba_ConectionDB.SetTbFaturasCotacoes(m_typDatSetTbFaturasCotacoes);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected override void salvaIncoterm()
		{
			try
			{
				string strLocal = "";
				mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow dtrwRowTbFaturasCotacoes;
				if (m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.Rows.Count > 0)
				{
					#region Switch
					dtrwRowTbFaturasCotacoes = (mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow)m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.Rows[0];
					switch (m_nIdIncoterm)
					{
						case EXW: if (!dtrwRowTbFaturasCotacoes.IslocalColetaNull())
									  strLocal = dtrwRowTbFaturasCotacoes.localColeta;
							dtrwRowTbFaturasCotacoes.mstrIncoterm = "EXW - " + strLocal;
							break;
						case FAS: if (!dtrwRowTbFaturasCotacoes.IslocalDespachoNull())
									  strLocal = dtrwRowTbFaturasCotacoes.localDespacho;
							dtrwRowTbFaturasCotacoes.mstrIncoterm = "FAS - " + strLocal;
							break;
						case FOB: if (!dtrwRowTbFaturasCotacoes.IslocalDespachoNull())
									  strLocal = dtrwRowTbFaturasCotacoes.localDespacho;
							dtrwRowTbFaturasCotacoes.mstrIncoterm = "FOB - " + strLocal;
							break;
						case FCA: if (!dtrwRowTbFaturasCotacoes.IslocalDespachoNull())
									  strLocal = dtrwRowTbFaturasCotacoes.localDespacho;
							dtrwRowTbFaturasCotacoes.mstrIncoterm = "FCA - " + strLocal;
							break;
						case CFR: if (!dtrwRowTbFaturasCotacoes.IslocalDestinoNull())
									  strLocal = dtrwRowTbFaturasCotacoes.localDestino;
							dtrwRowTbFaturasCotacoes.mstrIncoterm = "CFR - " + strLocal;
							break;
						case CIF: if (!dtrwRowTbFaturasCotacoes.IslocalDestinoNull())
									  strLocal = dtrwRowTbFaturasCotacoes.localDestino;
							dtrwRowTbFaturasCotacoes.mstrIncoterm = "CIF - " + strLocal;
							break;
						case CPT: if (!dtrwRowTbFaturasCotacoes.IslocalDestinoNull())
									  strLocal = dtrwRowTbFaturasCotacoes.localDestino;
							dtrwRowTbFaturasCotacoes.mstrIncoterm = "CPT - " + strLocal;
							break;
						case CIP: if (!dtrwRowTbFaturasCotacoes.IslocalDestinoNull())
									  strLocal = dtrwRowTbFaturasCotacoes.localDestino;
							dtrwRowTbFaturasCotacoes.mstrIncoterm = "CIP - " + strLocal;
							break;
						case DES: if (!dtrwRowTbFaturasCotacoes.IslocalDestinoNull())
									  strLocal = dtrwRowTbFaturasCotacoes.localDestino;
							dtrwRowTbFaturasCotacoes.mstrIncoterm = "DES - " + strLocal;
							break;
						case DEQ: if (!dtrwRowTbFaturasCotacoes.IslocalDestinoNull())
									  strLocal = dtrwRowTbFaturasCotacoes.localDestino;
							dtrwRowTbFaturasCotacoes.mstrIncoterm = "DEQ - " + strLocal;
							break;
						case DAF: if (!dtrwRowTbFaturasCotacoes.IslocalDespachoNull())
									  strLocal = dtrwRowTbFaturasCotacoes.localDespacho;
							dtrwRowTbFaturasCotacoes.mstrIncoterm = "DAF - " + strLocal;
							break;
						case DDU: if (!dtrwRowTbFaturasCotacoes.IslocalEntregaNull())
									  strLocal = dtrwRowTbFaturasCotacoes.localEntrega;
							dtrwRowTbFaturasCotacoes.mstrIncoterm = "DDU - " + strLocal;
							break;
						case DDP: if (!dtrwRowTbFaturasCotacoes.IslocalEntregaNull())
									  strLocal = dtrwRowTbFaturasCotacoes.localEntrega;
							dtrwRowTbFaturasCotacoes.mstrIncoterm = "DDP - " + strLocal;
							break;
					}
					#endregion
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#endregion

		#region Altera Incoterm
		protected override void criaIncotermEspecifico()
		{
			try
			{
				m_cls_Incoterm = new mdlIncoterm.Faturas.clsIncotermCotacao(ref m_cls_ter_tratadorErro, ref m_cls_dba_ConectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdCotacao, ref m_typDatSetTbFaturasCotacoes);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region AtualizaTypDatSetEspecifico
		protected override void atualizaTypDatSetEspecifico()
		{
			try
			{
				m_typDatSetTbFaturasCotacoes = (mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes)m_cls_Incoterm.retornaTypDatSetEspecifico();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Retorna TypDatSet
		public override Object retornaTypDatSet()
		{
			return (Object)m_typDatSetTbFaturasCotacoes;
		}
		#endregion
	}
}
