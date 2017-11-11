using System;

namespace mdlLocais
{
	/// <summary>
	/// Summary description for clsLocaisFaturaComercial.
	/// </summary>
	public class clsLocaisFaturaComercial : clsLocais
	{
		#region Atributes
		private string m_strIdPE = "";
		// Typed DataSets
		protected mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais m_typDatSetTbFaturasComerciais = null;
		#endregion
		#region Constructor and Destructors
		public clsLocaisFaturaComercial(ref mdlTratamentoErro.clsTratamentoErro cls_ter_tratadorErro,ref mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB, string strEnderecoExecutavel, int nIdExportador,string strIdPE) : base(ref cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB, strEnderecoExecutavel,nIdExportador) 
		{
			m_strIdPE = strIdPE;
			carregaTypDatSet();
			carregaDadosBD();
		}
		public clsLocaisFaturaComercial(ref mdlTratamentoErro.clsTratamentoErro cls_ter_tratadorErro,ref mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB, string strEnderecoExecutavel, int nIdExportador,string strIdPE, ref mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais typDatSetTbFaturasComerciais) : base(ref cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB, strEnderecoExecutavel, nIdExportador) 
		{
			m_strIdPE = strIdPE;
			m_bBotaoIncotermHabilitado = false;
			m_typDatSetTbFaturasComerciais = typDatSetTbFaturasComerciais;
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
				if (m_typDatSetTbFaturasComerciais == null)
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

					m_typDatSetTbFaturasComerciais = m_cls_dba_ConectionDB.GetTbFaturasComerciais(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
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
				mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwRowTbFaturasComerciais = null;
				if (m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows.Count > 0)
				{
					dtrwRowTbFaturasComerciais = (mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow)m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows[0];
					if (!dtrwRowTbFaturasComerciais.IslocalColetaNull())
						m_strLocalColeta = dtrwRowTbFaturasComerciais.localColeta;
					if (!dtrwRowTbFaturasComerciais.IslocalDespachoNull())
						m_strLocalDespacho = dtrwRowTbFaturasComerciais.localDespacho;
					if (!dtrwRowTbFaturasComerciais.IslocalDestinoNull())
						m_strLocalDestino = dtrwRowTbFaturasComerciais.localDestino;
					if (!dtrwRowTbFaturasComerciais.IslocalEmbarqueNull())
						m_strLocalEmbarque = dtrwRowTbFaturasComerciais.localEmbarque;
					if (!dtrwRowTbFaturasComerciais.IslocalEntregaNull())
						m_strLocalEntrega = dtrwRowTbFaturasComerciais.localEntrega;
					if (!dtrwRowTbFaturasComerciais.IsidIncotermNull())
						m_nIdIncoterm = dtrwRowTbFaturasComerciais.idIncoterm;
					if (!dtrwRowTbFaturasComerciais.IsidImportadorNull())
						m_nIdImportador = dtrwRowTbFaturasComerciais.idImportador;
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
				mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwRowTbFaturasComerciais = null;
				if (m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows.Count > 0)
				{
					dtrwRowTbFaturasComerciais = (mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow)m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows[0];
					dtrwRowTbFaturasComerciais.localColeta = m_strLocalColeta;
					dtrwRowTbFaturasComerciais.localDespacho = m_strLocalDespacho;
					dtrwRowTbFaturasComerciais.localDestino = m_strLocalDestino;
					dtrwRowTbFaturasComerciais.localEmbarque = m_strLocalEmbarque;
					dtrwRowTbFaturasComerciais.localEntrega = m_strLocalEntrega;
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
               m_cls_dba_ConectionDB.SetTbFaturasComerciais(m_typDatSetTbFaturasComerciais);
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
				mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwRowTbFaturasComerciais;
				if (m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows.Count > 0)
				{
					#region Switch
					dtrwRowTbFaturasComerciais = (mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow)m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows[0];
					switch (m_nIdIncoterm)
					{
						case EXW: if (!dtrwRowTbFaturasComerciais.IslocalColetaNull())
									  strLocal = dtrwRowTbFaturasComerciais.localColeta;
							dtrwRowTbFaturasComerciais.mstrIncoterm = "EXW - " + strLocal;
							break;
						case FAS: if (!dtrwRowTbFaturasComerciais.IslocalDespachoNull())
									  strLocal = dtrwRowTbFaturasComerciais.localDespacho;
							dtrwRowTbFaturasComerciais.mstrIncoterm = "FAS - " + strLocal;
							break;
						case FOB: if (!dtrwRowTbFaturasComerciais.IslocalDespachoNull())
									  strLocal = dtrwRowTbFaturasComerciais.localDespacho;
							dtrwRowTbFaturasComerciais.mstrIncoterm = "FOB - " + strLocal;
							break;
						case FCA: if (!dtrwRowTbFaturasComerciais.IslocalDespachoNull())
									  strLocal = dtrwRowTbFaturasComerciais.localDespacho;
							dtrwRowTbFaturasComerciais.mstrIncoterm = "FCA - " + strLocal;
							break;
						case CFR: if (!dtrwRowTbFaturasComerciais.IslocalDestinoNull())
									  strLocal = dtrwRowTbFaturasComerciais.localDestino;
							dtrwRowTbFaturasComerciais.mstrIncoterm = "CFR - " + strLocal;
							break;
						case CIF: if (!dtrwRowTbFaturasComerciais.IslocalDestinoNull())
									  strLocal = dtrwRowTbFaturasComerciais.localDestino;
							dtrwRowTbFaturasComerciais.mstrIncoterm = "CIF - " + strLocal;
							break;
						case CPT: if (!dtrwRowTbFaturasComerciais.IslocalDestinoNull())
									  strLocal = dtrwRowTbFaturasComerciais.localDestino;
							dtrwRowTbFaturasComerciais.mstrIncoterm = "CPT - " + strLocal;
							break;
						case CIP: if (!dtrwRowTbFaturasComerciais.IslocalDestinoNull())
									  strLocal = dtrwRowTbFaturasComerciais.localDestino;
							dtrwRowTbFaturasComerciais.mstrIncoterm = "CIP - " + strLocal;
							break;
						case DES: if (!dtrwRowTbFaturasComerciais.IslocalDestinoNull())
									  strLocal = dtrwRowTbFaturasComerciais.localDestino;
							dtrwRowTbFaturasComerciais.mstrIncoterm = "DES - " + strLocal;
							break;
						case DEQ: if (!dtrwRowTbFaturasComerciais.IslocalDestinoNull())
									  strLocal = dtrwRowTbFaturasComerciais.localDestino;
							dtrwRowTbFaturasComerciais.mstrIncoterm = "DEQ - " + strLocal;
							break;
						case DAF: if (!dtrwRowTbFaturasComerciais.IslocalDespachoNull())
									  strLocal = dtrwRowTbFaturasComerciais.localDespacho;
							dtrwRowTbFaturasComerciais.mstrIncoterm = "DAF - " + strLocal;
							break;
						case DDU: if (!dtrwRowTbFaturasComerciais.IslocalEntregaNull())
									  strLocal = dtrwRowTbFaturasComerciais.localEntrega;
							dtrwRowTbFaturasComerciais.mstrIncoterm = "DDU - " + strLocal;
							break;
						case DDP: if (!dtrwRowTbFaturasComerciais.IslocalEntregaNull())
									  strLocal = dtrwRowTbFaturasComerciais.localEntrega;
							dtrwRowTbFaturasComerciais.mstrIncoterm = "DDP - " + strLocal;
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
				m_cls_Incoterm = new mdlIncoterm.Faturas.clsIncotermComercial(ref m_cls_ter_tratadorErro, ref m_cls_dba_ConectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE, ref m_typDatSetTbFaturasComerciais);
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
				m_typDatSetTbFaturasComerciais = (mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais)m_cls_Incoterm.retornaTypDatSetEspecifico();
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
			return (Object)m_typDatSetTbFaturasComerciais;
		}
		#endregion
	}
}
