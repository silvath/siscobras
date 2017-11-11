using System;

namespace mdlNumero.Romaneio
{
	/// <summary>
	/// Summary description for clsNumeroRomaneio.
	/// </summary>
	public class clsNumeroRomaneio : clsNumero
	{
		#region Atributos
		private mdlDataBaseAccess.Tabelas.XsdTbRomaneios m_typDatSetTbRomaneios = null;
		private mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais m_typDatSetTbFaturasComerciais = null;
		private mdlDataBaseAccess.Tabelas.XsdTbExportadores m_typDatSetTbExportadores = null;
		private mdlDataBaseAccess.Tabelas.XsdTbImportadores m_typDatSetTbImportadores = null;
		#endregion

		#region Construtores & Destrutores
		public clsNumeroRomaneio(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string idPE): base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador)
		{
			m_strIdPE = idPE;
			carregaTypDatSet();
			carregaDadosBD();
			criaDiaMesAno();
			criaAleatorio();
			m_bMascaraEditavel = true;
		}
		#endregion

		#region Monta Label Instrução IDPE
		protected override void montaLabel(ref System.Windows.Forms.Label lIdPE)
		{
			if (m_strIdPE.Length >= 3)
                lIdPE.Text = "NNN - " + m_strIdPE.Substring(0,3).ToUpper() + " (PE" + m_strIdPE + ")";
			else
				lIdPE.Text = "NNN - 879 (PE 879)";
		}
		#endregion

		#region Carregamento de Dados
		#region Banco de Dados
		protected new void carregaTypDatSet()
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwRowTbFaturasComerciais;
				mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow dtrwTbRomaneios;
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
			
				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				m_typDatSetTbExportadores = m_cls_dba_ConnectionBD.GetTbExportadores(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				arlCondicaoCampo.Add("idPE");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdPE);

				m_typDatSetTbRomaneios = m_cls_dba_ConnectionBD.GetTbRomaneios(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				m_typDatSetTbFaturasComerciais = m_cls_dba_ConnectionBD.GetTbFaturasComerciais(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				if (m_typDatSetTbRomaneios.tbRomaneios.Rows.Count > 0)
				{
					dtrwTbRomaneios = (mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow)m_typDatSetTbRomaneios.tbRomaneios.Rows[0];
					if (!dtrwTbRomaneios.IsstrNumeroNull())
						m_strNumero = dtrwTbRomaneios.strNumero.Replace("\0","");
					if (!dtrwTbRomaneios.IsdtDataEmissaoNull())
						m_dtData = dtrwTbRomaneios.dtDataEmissao;
					if (m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows.Count > 0)
					{
						dtrwRowTbFaturasComerciais = (mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow)m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows[0];
//						if ((!dtrwRowTbFaturasComerciais.IsnumeroFaturaNull()) && (m_strNumero == ""))
//							m_strNumero += "PL" + dtrwRowTbFaturasComerciais.numeroFatura.Replace("\0","");
						if (!dtrwRowTbFaturasComerciais.IsidImportadorNull())
							m_nIdImportador = dtrwRowTbFaturasComerciais.idImportador;
					}
				}
//				else if (m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows.Count > 0)
//				{
//					dtrwRowTbFaturasComerciais = (mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow)m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows[0];
//					if ((!dtrwRowTbFaturasComerciais.IsnumeroFaturaNull()) && (m_strNumero == ""))
//						m_strNumero += "PL" + dtrwRowTbFaturasComerciais.numeroFatura.Replace("\0","");
//					if (!dtrwRowTbFaturasComerciais.IsidImportadorNull())
//						m_nIdImportador = dtrwRowTbFaturasComerciais.idImportador;
//				}

				arlCondicaoCampo.Clear();
				arlCondicaoComparador.Clear();
				arlCondicaoValor.Clear();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);
				arlCondicaoCampo.Add("idImportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdImportador);

				m_typDatSetTbImportadores = m_cls_dba_ConnectionBD.GetTbImportadores(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
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
				mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow dtrwRowTbExportadores;
				mdlDataBaseAccess.Tabelas.XsdTbImportadores.tbImportadoresRow dtrwRowTbImportadores;
				if ((m_typDatSetTbExportadores.tbExportadores.Rows.Count > 0) && (m_strFormatoNumero.Trim() == ""))
				{
					dtrwRowTbExportadores = (mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow)m_typDatSetTbExportadores.tbExportadores.Rows[0];
					if (!dtrwRowTbExportadores.IsstrFormatoNumeroRomaneioNull())
                        m_strFormatoNumero = dtrwRowTbExportadores.strFormatoNumeroRomaneio.Replace("\0","");
				}
				if (m_typDatSetTbImportadores.tbImportadores.Rows.Count > 0)
				{
					dtrwRowTbImportadores = (mdlDataBaseAccess.Tabelas.XsdTbImportadores.tbImportadoresRow)m_typDatSetTbImportadores.tbImportadores.Rows[0];
					if (!dtrwRowTbImportadores.IsidPaisCliNull())
					{
						m_nIdPais = dtrwRowTbImportadores.idPaisCli;
						base.carregaTypDatSet();
					}
				}
				if (m_strFormatoNumero.Trim() == "")
					m_strFormatoNumero = "\"PL\"PPP.MMDD.NNN";
				m_strFormatoNumeroNovo = m_strFormatoNumero;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Interface
		protected override void carregaDadosInterfaceTextGroupBox(ref System.Windows.Forms.GroupBox gbFields)
		{
			try
			{
				gbFields.Text = "Romaneio";
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected override void montaLabelSugestao(ref System.Windows.Forms.Label lSugestao)
		{
			try
			{
				lSugestao.Visible = false;
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
		protected override void salvaDadosBDEspecifico()
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow dtrwTbRomaneios;
				mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow dtrwRowTbExportadores;
				if (m_typDatSetTbRomaneios.tbRomaneios.Rows.Count > 0)
				{
				
					dtrwTbRomaneios = (mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow)m_typDatSetTbRomaneios.tbRomaneios.Rows[0];
					if (dtrwTbRomaneios != null)
						dtrwTbRomaneios.strNumero = m_strNumeroNovo;
				
					m_cls_dba_ConnectionBD.SetTbRomaneios(m_typDatSetTbRomaneios);
				}
				if (m_typDatSetTbExportadores.tbExportadores.Rows.Count > 0)
				{
					dtrwRowTbExportadores = (mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow)m_typDatSetTbExportadores.tbExportadores.Rows[0];
					if (dtrwRowTbExportadores != null)
                        dtrwRowTbExportadores.strFormatoNumeroRomaneio = m_strFormatoNumeroNovo;

					m_cls_dba_ConnectionBD.SetTbExportadores(m_typDatSetTbExportadores);
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
	}
}
