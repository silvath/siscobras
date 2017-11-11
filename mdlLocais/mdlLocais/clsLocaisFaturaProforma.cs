using System;

namespace mdlLocais
{
	/// <summary>
	/// Summary description for clsLocaisFaturaProforma.
	/// </summary>
	public class clsLocaisFaturaProforma : clsLocais
	{
		#region Atributes
		private string m_strIdPE = "";
		// Typed DataSets
		protected mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas m_typDatSetTbFaturasProformas = null;
		#endregion

		#region Constructor and Destructors
		public clsLocaisFaturaProforma(ref mdlTratamentoErro.clsTratamentoErro cls_ter_tratadorErro,ref mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB, string strEnderecoExecutavel, int nIdExportador,string strIdPE) : base(ref cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB, strEnderecoExecutavel,nIdExportador) 
		{
			m_strIdPE = strIdPE;
			carregaTypDatSet();
			carregaDadosBD();
		}
		public clsLocaisFaturaProforma(ref mdlTratamentoErro.clsTratamentoErro cls_ter_tratadorErro,ref mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB, string strEnderecoExecutavel, int nIdExportador,string strIdPE, ref mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas typDatSetTbFaturasProformas) : base(ref cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB, strEnderecoExecutavel, nIdExportador) 
		{
			m_strIdPE = strIdPE;
			m_bBotaoIncotermHabilitado = false;
			m_typDatSetTbFaturasProformas = typDatSetTbFaturasProformas;
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
				if (m_typDatSetTbFaturasProformas == null)
				{
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
			
					arlCondicaoCampo.Add("idExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_nIdExportador);

					arlCondicaoCampo.Add("idPE");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_strIdPE);

					m_typDatSetTbFaturasProformas = m_cls_dba_ConectionDB.GetTbFaturasProformas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
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
				mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas.tbFaturasProformasRow dtrwRowTbFaturasProformas = null;
				if (m_typDatSetTbFaturasProformas.tbFaturasProformas.Rows.Count > 0)
				{
					dtrwRowTbFaturasProformas = (mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas.tbFaturasProformasRow)m_typDatSetTbFaturasProformas.tbFaturasProformas.Rows[0];
					if (!dtrwRowTbFaturasProformas.IslocalColetaNull())
						m_strLocalColeta = dtrwRowTbFaturasProformas.localColeta;
					if (!dtrwRowTbFaturasProformas.IslocalDespachoNull())
						m_strLocalDespacho = dtrwRowTbFaturasProformas.localDespacho;
					if (!dtrwRowTbFaturasProformas.IslocalDestinoNull())
						m_strLocalDestino = dtrwRowTbFaturasProformas.localDestino;
					if (!dtrwRowTbFaturasProformas.IslocalEmbarqueNull())
						m_strLocalEmbarque = dtrwRowTbFaturasProformas.localEmbarque;
					if (!dtrwRowTbFaturasProformas.IslocalEntregaNull())
						m_strLocalEntrega = dtrwRowTbFaturasProformas.localEntrega;
					if (!dtrwRowTbFaturasProformas.IsidIncotermNull())
						m_nIdIncoterm = dtrwRowTbFaturasProformas.idIncoterm;
					if (!dtrwRowTbFaturasProformas.IsidImportadorNull())
						m_nIdImportador = dtrwRowTbFaturasProformas.idImportador;
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
				mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas.tbFaturasProformasRow dtrwRowTbFaturasProformas = null;
				if (m_typDatSetTbFaturasProformas.tbFaturasProformas.Rows.Count > 0)
				{
					dtrwRowTbFaturasProformas = (mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas.tbFaturasProformasRow)m_typDatSetTbFaturasProformas.tbFaturasProformas.Rows[0];
					dtrwRowTbFaturasProformas.localColeta = m_strLocalColeta;
					dtrwRowTbFaturasProformas.localDespacho = m_strLocalDespacho;
					dtrwRowTbFaturasProformas.localDestino = m_strLocalDestino;
					dtrwRowTbFaturasProformas.localEmbarque = m_strLocalEmbarque;
					dtrwRowTbFaturasProformas.localEntrega = m_strLocalEntrega;
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
                    m_cls_dba_ConectionDB.SetTbFaturasProformas(m_typDatSetTbFaturasProformas);
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
				mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas.tbFaturasProformasRow dtrwRowTbFaturasProformas;
				if (m_typDatSetTbFaturasProformas.tbFaturasProformas.Rows.Count > 0)
				{
					#region Switch
					dtrwRowTbFaturasProformas = (mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas.tbFaturasProformasRow)m_typDatSetTbFaturasProformas.tbFaturasProformas.Rows[0];
					switch (m_nIdIncoterm)
					{
						case EXW: if (!dtrwRowTbFaturasProformas.IslocalColetaNull())
									  strLocal = dtrwRowTbFaturasProformas.localColeta;
							dtrwRowTbFaturasProformas.mstrIncoterm = "EXW - " + strLocal;
							break;
						case FAS: if (!dtrwRowTbFaturasProformas.IslocalDespachoNull())
									  strLocal = dtrwRowTbFaturasProformas.localDespacho;
							dtrwRowTbFaturasProformas.mstrIncoterm = "FAS - " + strLocal;
							break;
						case FOB: if (!dtrwRowTbFaturasProformas.IslocalDespachoNull())
									  strLocal = dtrwRowTbFaturasProformas.localDespacho;
							dtrwRowTbFaturasProformas.mstrIncoterm = "FOB - " + strLocal;
							break;
						case FCA: if (!dtrwRowTbFaturasProformas.IslocalDespachoNull())
									  strLocal = dtrwRowTbFaturasProformas.localDespacho;
							dtrwRowTbFaturasProformas.mstrIncoterm = "FCA - " + strLocal;
							break;
						case CFR: if (!dtrwRowTbFaturasProformas.IslocalDestinoNull())
									  strLocal = dtrwRowTbFaturasProformas.localDestino;
							dtrwRowTbFaturasProformas.mstrIncoterm = "CFR - " + strLocal;
							break;
						case CIF: if (!dtrwRowTbFaturasProformas.IslocalDestinoNull())
									  strLocal = dtrwRowTbFaturasProformas.localDestino;
							dtrwRowTbFaturasProformas.mstrIncoterm = "CIF - " + strLocal;
							break;
						case CPT: if (!dtrwRowTbFaturasProformas.IslocalDestinoNull())
									  strLocal = dtrwRowTbFaturasProformas.localDestino;
							dtrwRowTbFaturasProformas.mstrIncoterm = "CPT - " + strLocal;
							break;
						case CIP: if (!dtrwRowTbFaturasProformas.IslocalDestinoNull())
									  strLocal = dtrwRowTbFaturasProformas.localDestino;
							dtrwRowTbFaturasProformas.mstrIncoterm = "CIP - " + strLocal;
							break;
						case DES: if (!dtrwRowTbFaturasProformas.IslocalDestinoNull())
									  strLocal = dtrwRowTbFaturasProformas.localDestino;
							dtrwRowTbFaturasProformas.mstrIncoterm = "DES - " + strLocal;
							break;
						case DEQ: if (!dtrwRowTbFaturasProformas.IslocalDestinoNull())
									  strLocal = dtrwRowTbFaturasProformas.localDestino;
							dtrwRowTbFaturasProformas.mstrIncoterm = "DEQ - " + strLocal;
							break;
						case DAF: if (!dtrwRowTbFaturasProformas.IslocalDespachoNull())
									  strLocal = dtrwRowTbFaturasProformas.localDespacho;
							dtrwRowTbFaturasProformas.mstrIncoterm = "DAF - " + strLocal;
							break;
						case DDU: if (!dtrwRowTbFaturasProformas.IslocalEntregaNull())
									  strLocal = dtrwRowTbFaturasProformas.localEntrega;
							dtrwRowTbFaturasProformas.mstrIncoterm = "DDU - " + strLocal;
							break;
						case DDP: if (!dtrwRowTbFaturasProformas.IslocalEntregaNull())
									  strLocal = dtrwRowTbFaturasProformas.localEntrega;
							dtrwRowTbFaturasProformas.mstrIncoterm = "DDP - " + strLocal;
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
				m_cls_Incoterm = new mdlIncoterm.Faturas.clsIncotermProforma(ref m_cls_ter_tratadorErro, ref m_cls_dba_ConectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE, ref m_typDatSetTbFaturasProformas);
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
				m_typDatSetTbFaturasProformas = (mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas)m_cls_Incoterm.retornaTypDatSetEspecifico();
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
			return (Object)m_typDatSetTbFaturasProformas;
		}
		#endregion
	}
}
