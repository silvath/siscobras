using System;

namespace mdlNumero.Saque
{
	/// <summary>
	/// Summary description for clsSaque.
	/// </summary>
	public class clsSaque : clsNumero
	{
		#region Atributos
		private mdlDataBaseAccess.Tabelas.XsdTbSaques m_typDatSetTbSaques = null;
		private mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais m_typDatSetTbFaturasComerciais = null;
		private mdlDataBaseAccess.Tabelas.XsdTbExportadores m_typDatSetTbExportadores = null;
		private mdlDataBaseAccess.Tabelas.XsdTbImportadores m_typDatSetTbImportadores = null;
		#endregion

		#region Construtores & Destrutores
		public clsSaque(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string idPE): base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador)
		{
			m_strIdPE = idPE;
			carregaTypDatSet();
			carregaDadosBD();
			criaDiaMesAno();
			criaAleatorio();
			m_bMascaraEditavel = true;
		}
		#endregion

		#region Monta Label Instru��o IDPE
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
				mdlDataBaseAccess.Tabelas.XsdTbSaques.tbSaquesRow dtrwRowTbSaque;
				mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwRowTbFaturasComerciais;
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

				m_typDatSetTbSaques = m_cls_dba_ConnectionBD.GetTbSaques(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				m_typDatSetTbFaturasComerciais = m_cls_dba_ConnectionBD.GetTbFaturasComerciais(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);;
				if (m_typDatSetTbSaques.tbSaques.Rows.Count > 0)
				{
					dtrwRowTbSaque = (mdlDataBaseAccess.Tabelas.XsdTbSaques.tbSaquesRow)m_typDatSetTbSaques.tbSaques.Rows[0];
					if (!dtrwRowTbSaque.IsdtDataEmissaoNull())
						m_dtData = dtrwRowTbSaque.dtDataEmissao;
					if (!dtrwRowTbSaque.IsstrNumeroSaqueNull())
						m_strNumero = dtrwRowTbSaque.strNumeroSaque.Replace("\0","");
					if (m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows.Count > 0)
					{
						dtrwRowTbFaturasComerciais = (mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow)m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows[0];
						if (!dtrwRowTbFaturasComerciais.IsidImportadorNull())
							m_nIdImportador = dtrwRowTbFaturasComerciais.idImportador;
					}
				}
				else if (m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows.Count > 0)
				{
					dtrwRowTbFaturasComerciais = (mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow)m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows[0];
					if (!dtrwRowTbFaturasComerciais.IsidImportadorNull())
						m_nIdImportador = dtrwRowTbFaturasComerciais.idImportador;
				}

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
				if (m_typDatSetTbExportadores.tbExportadores.Rows.Count > 0)
				{
					dtrwRowTbExportadores = (mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow)m_typDatSetTbExportadores.tbExportadores.Rows[0];
					if (!dtrwRowTbExportadores.IsformatoNumeroSaqueNull())
						m_strFormatoNumero = dtrwRowTbExportadores.formatoNumeroSaque.Replace("\0","");
					else
						m_strFormatoNumero = "\"DR\"" + (dtrwRowTbExportadores.IsformatoNumeroNull() ? "PPP.MMDD.NNN" : dtrwRowTbExportadores.formatoNumero);
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
					m_strFormatoNumero = "\"DR\"PPP.MMDD.NNN";
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
				gbFields.Text = "Saque";
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
				mdlDataBaseAccess.Tabelas.XsdTbSaques.tbSaquesRow dtrwRowTbSaques;
				mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow dtrwRowTbExportadores;
				if (m_strNumero != m_strNumeroNovo)
				{
					if (m_typDatSetTbSaques.tbSaques.Rows.Count > 0)
					{
						dtrwRowTbSaques = (mdlDataBaseAccess.Tabelas.XsdTbSaques.tbSaquesRow)m_typDatSetTbSaques.tbSaques.Rows[0];
						if (dtrwRowTbSaques != null)
							dtrwRowTbSaques.strNumeroSaque = m_strNumeroNovo;

						m_cls_dba_ConnectionBD.SetTbSaques(m_typDatSetTbSaques);
					}
				}
				if (m_typDatSetTbExportadores.tbExportadores.Rows.Count > 0)
				{
					dtrwRowTbExportadores = (mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow)m_typDatSetTbExportadores.tbExportadores.Rows[0];
					if (dtrwRowTbExportadores != null)
                        dtrwRowTbExportadores.formatoNumeroSaque = m_strFormatoNumeroNovo;

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
