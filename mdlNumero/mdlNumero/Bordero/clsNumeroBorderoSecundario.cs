using System;

namespace mdlNumero.Bordero
{
	/// <summary>
	/// Summary description for clsNumeroBorderoSecundario.
	/// </summary>
	public class clsNumeroBorderoSecundario : clsNumero
	{
		#region Atributos
		private int m_nIdBancoExportadorBordero = -1;

		private mdlDataBaseAccess.Tabelas.XsdTbBorderos m_typDatSetTbBorderos = null;
		private mdlDataBaseAccess.Tabelas.XsdTbBorderosSecundarios m_typDatSetTbBorderosSecundarios = null;
		private mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais m_typDatSetTbFaturasComerciais = null;
		private mdlDataBaseAccess.Tabelas.XsdTbExportadores m_typDatSetTbExportadores = null;
		private mdlDataBaseAccess.Tabelas.XsdTbImportadores m_typDatSetTbImportadores = null;
		#endregion

		#region Construtores & Destrutores
		public clsNumeroBorderoSecundario(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string idPE, int idBanco): base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador)
		{
            m_strIdPE = idPE;
			m_nIdBancoExportadorBordero = idBanco;
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
				mdlDataBaseAccess.Tabelas.XsdTbBorderos.tbBorderosRow dtrwTbBorderos;
				mdlDataBaseAccess.Tabelas.XsdTbBorderosSecundarios.tbBorderosSecundariosRow dtrwTbBorderosSecundarios;
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

				m_typDatSetTbBorderos = m_cls_dba_ConnectionBD.GetTbBorderos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				m_typDatSetTbFaturasComerciais = m_cls_dba_ConnectionBD.GetTbFaturasComerciais(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				arlCondicaoCampo.Clear();
				arlCondicaoComparador.Clear();
				arlCondicaoValor.Clear();

				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);
				arlCondicaoCampo.Add("strIdPE");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdPE);
				arlCondicaoCampo.Add("nIdBancoExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdBancoExportadorBordero);

				m_typDatSetTbBorderosSecundarios = m_cls_dba_ConnectionBD.GetTbBorderosSecundarios(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				if (m_typDatSetTbBorderosSecundarios.tbBorderosSecundarios.Rows.Count > 0)
				{
					dtrwTbBorderosSecundarios = (mdlDataBaseAccess.Tabelas.XsdTbBorderosSecundarios.tbBorderosSecundariosRow)m_typDatSetTbBorderosSecundarios.tbBorderosSecundarios.Rows[0];
					if (!dtrwTbBorderosSecundarios.IsstrNumeroNull())
						m_strNumero = dtrwTbBorderosSecundarios.strNumero.Replace("\0","");
					if (!dtrwTbBorderosSecundarios.IsdtEmissaoNull())
						m_dtData = dtrwTbBorderosSecundarios.dtEmissao;
					if (m_typDatSetTbBorderos.tbBorderos.Rows.Count > 0)
					{
						dtrwTbBorderos = (mdlDataBaseAccess.Tabelas.XsdTbBorderos.tbBorderosRow)m_typDatSetTbBorderos.tbBorderos.Rows[0];
						if (!dtrwTbBorderos.IsstrFormatoNumeroNull())
							m_strFormatoNumero = dtrwTbBorderos.strFormatoNumero.Replace("\0","");
					}
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
				if (m_strNumero == "")
					m_strNumeroNovo = m_strIdPE;

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
				mdlDataBaseAccess.Tabelas.XsdTbImportadores.tbImportadoresRow dtrwRowTbImportadores;
				if (m_typDatSetTbImportadores.tbImportadores.Rows.Count > 0)
				{
					dtrwRowTbImportadores = (mdlDataBaseAccess.Tabelas.XsdTbImportadores.tbImportadoresRow)m_typDatSetTbImportadores.tbImportadores.Rows[0];
					if (!dtrwRowTbImportadores.IsidPaisCliNull())
					{
						m_nIdPais = dtrwRowTbImportadores.idPaisCli;
						base.carregaTypDatSet();
					}
				}
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
				gbFields.Text = "Borderô";
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
				int nIndex = 0;
				System.Exception erro = new System.Exception("Erro: Não é possível inserir duas faturas comerciais com o mesmo número");
				mdlDataBaseAccess.Tabelas.XsdTbBorderosSecundarios.tbBorderosSecundariosRow dtrwTbBorderosSecundarios;
				if (m_strNumero != m_strNumeroNovo)
				{
					if (m_typDatSetTbBorderosSecundarios.tbBorderosSecundarios.Rows.Count > 0)
					{
					
						while (nIndex < m_typDatSetTbBorderosSecundarios.tbBorderosSecundarios.Rows.Count)
						{
							dtrwTbBorderosSecundarios = (mdlDataBaseAccess.Tabelas.XsdTbBorderosSecundarios.tbBorderosSecundariosRow)m_typDatSetTbBorderosSecundarios.tbBorderosSecundarios.Rows[nIndex];
							if (!dtrwTbBorderosSecundarios.IsstrNumeroNull())
							{
								if (dtrwTbBorderosSecundarios.strNumero != m_strNumeroNovo)
									nIndex++;
								else
									throw erro;
							}
							else
							{
								nIndex++;
							}

						}
						dtrwTbBorderosSecundarios = (mdlDataBaseAccess.Tabelas.XsdTbBorderosSecundarios.tbBorderosSecundariosRow)m_typDatSetTbBorderosSecundarios.tbBorderosSecundarios.Rows[0];
						if (dtrwTbBorderosSecundarios != null)
						{
							dtrwTbBorderosSecundarios.strNumero = m_strNumeroNovo;
							//dtrwTbBorderosSecundarios.strFormatoNumero = m_strFormatoNumeroNovo;
						}
					
						m_cls_dba_ConnectionBD.SetTbBorderosSecundarios(m_typDatSetTbBorderosSecundarios);
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
	}
}
