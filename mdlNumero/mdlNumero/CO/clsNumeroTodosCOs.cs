using System;

namespace mdlNumero.CO
{
	#region Enum
	public enum TIPOSCO
	{
		MERCOSUL = 1,
		MERCOSULBOLIVIA = 2,
		MERCOSULCHILE = 3,
		ALADIAPTR04 = 4,
		ALADIACE39 = 5,
		ANEXO3 = 6,
		COMUM = 7,
		ALADIACE59 = 29,
		FORMA = 30
	}
	#endregion
	/// <summary>
	/// Summary description for clsNumeroTodosCOs.
	/// </summary>
	public class clsNumeroTodosCOs
	{
		#region Atributos
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
		protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionBD = null;
		protected string m_strEnderecoExecutavel = "";

		protected int m_nIdExportador = -1;
		protected int m_nIdImportador = -1;
		protected int m_nIdPais = -1;
		protected string m_strIdPE = "";

		public bool m_bModificado = false;

		protected int m_nIdTipoCO = -1;

		private Frame.frmFTodosCOs m_formFTodosCOs = null;

		private mdlDataBaseAccess.Tabelas.XsdTbImportadores m_typDatSetTbImportadores;
		private mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais m_typDatSetTbFaturasComerciais;
		private mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem m_typDatSetTbCertificadosOrigem;
		#endregion

		#region Construtores & Destrutores
		public clsNumeroTodosCOs(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string strIdPE)
		{
			m_cls_ter_tratadorErro = tratadorErro;
			m_cls_dba_ConnectionBD = ConnectionDB;
			m_strEnderecoExecutavel = EnderecoExecutavel;
			m_nIdExportador = nIdExportador;
			m_strIdPE = strIdPE;
			carregaTypDatSet();
			carregaPaisImportador();
		}
		#endregion

		#region InitializeEventsFormTodosCOs
		private void InitializeEventsFormTodosCOs()
		{
			// Carrega Dados Interface
			m_formFTodosCOs.eCallCarregaDadosInterface += new Frame.frmFTodosCOs.delCallCarregaDadosInterface(carregaDadosInterface);

			// Salva Dados Interface
			m_formFTodosCOs.eCallSalvaDadosInterface += new Frame.frmFTodosCOs.delCallSalvaDadosInterface(salvaDadosInterface);

			// Salva Dados BD
			m_formFTodosCOs.eCallSalvaDadosBD += new Frame.frmFTodosCOs.delCallSalvaDadosBD(salvaDadosBD);
		}
		#endregion

		#region ShowDialog
		public void ShowDialog()
		{
			try
			{
				m_formFTodosCOs = new Frame.frmFTodosCOs(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel);
				InitializeEventsFormTodosCOs();
				m_formFTodosCOs.ShowDialog();
				m_formFTodosCOs = null;
			}
			catch (Exception err)
			{
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion

		#region Carregamento dos Dados
		#region Banco de Dados
		private void carregaTypDatSet()
		{
			try
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

				m_typDatSetTbFaturasComerciais = m_cls_dba_ConnectionBD.GetTbFaturasComerciais(arlCondicaoCampo, arlCondicaoComparador, arlCondicaoValor, null, null);
				m_typDatSetTbCertificadosOrigem = m_cls_dba_ConnectionBD.GetTbCertificadosOrigem(arlCondicaoCampo, arlCondicaoComparador, arlCondicaoValor, null, null);
			}
			catch (Exception err)
			{
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		private void carregaPaisImportador()
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbImportadores.tbImportadoresRow dtrwTbImportadores = null;
				mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwTbFaturasComerciais = null;
				if (m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows.Count > 0)
				{
					dtrwTbFaturasComerciais = (mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow)m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows[0];
					if (!dtrwTbFaturasComerciais.IsidImportadorNull())
						m_nIdImportador = dtrwTbFaturasComerciais.idImportador;
					else
						m_nIdImportador = -1;
				}
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);
				
				arlCondicaoCampo.Add("idImportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdImportador);

				m_typDatSetTbImportadores = m_cls_dba_ConnectionBD.GetTbImportadores(arlCondicaoCampo, arlCondicaoComparador, arlCondicaoValor, null, null);
				if (m_typDatSetTbImportadores.tbImportadores.Rows.Count > 0)
				{
					dtrwTbImportadores = (mdlDataBaseAccess.Tabelas.XsdTbImportadores.tbImportadoresRow)m_typDatSetTbImportadores.tbImportadores.Rows[0];
					if (!dtrwTbImportadores.IsidPaisCliNull())
						m_nIdPais = dtrwTbImportadores.idPaisCli;
					else
						m_nIdPais = -1;
				}
			}
			catch (Exception err)
			{
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion
		#region Interface
		private void carregaDadosInterface(ref System.Windows.Forms.Label lAladiAce39, ref mdlComponentesGraficos.TextBox tbAladiAce39,ref System.Windows.Forms.Label lAladiAce59, ref mdlComponentesGraficos.TextBox tbAladiAce59, ref System.Windows.Forms.Label lAladiAptr04, ref mdlComponentesGraficos.TextBox tbAladiAptr04, ref System.Windows.Forms.Label lAnexo3, ref mdlComponentesGraficos.TextBox tbAnexo3, ref System.Windows.Forms.Label lComum, ref mdlComponentesGraficos.TextBox tbComum, ref System.Windows.Forms.Label lFormA, ref mdlComponentesGraficos.TextBox tbFormA, ref System.Windows.Forms.Label lMercosul, ref mdlComponentesGraficos.TextBox tbMercosul, ref System.Windows.Forms.Label lBolivia, ref mdlComponentesGraficos.TextBox tbBolivia, ref System.Windows.Forms.Label lChile, ref mdlComponentesGraficos.TextBox tbChile)
		{
			try
			{
				lAladiAce59.Enabled = false;
				tbAladiAce59.Enabled = false;

				mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow dtrwTbCertificadosOrigem = null;
				#region Países//Certificados
				switch(m_nIdPais)
				{
					case 63: // Argentina
					case 586: // Paraguai
					case 845: // Uruguai 
						lMercosul.Enabled = true;
						tbMercosul.Enabled = true;
						lAladiAptr04.Enabled = true;
						tbAladiAptr04.Enabled = true;
						lComum.Enabled = true;
						tbComum.Enabled = true;
						/*FORMA*/
						break;
					case 158: // Chile 
						lChile.Enabled = true;
						tbChile.Enabled = true;
						lAladiAptr04.Enabled = true;
						tbAladiAptr04.Enabled = true;
						lComum.Enabled = true;
						tbComum.Enabled = true;
						/*FORMA*/
						break;
					case 97: // Bolivia 
						lBolivia.Enabled = true;
						tbBolivia.Enabled = true;
						lAladiAptr04.Enabled = true;
						tbAladiAptr04.Enabled = true;
						lComum.Enabled = true;
						tbComum.Enabled = true;
						/*FORMA*/
						break;
					case 169: // Colombia
					case 239: // Equador
					case 850: // Venezuela
						lAladiAptr04.Enabled = true;
						tbAladiAptr04.Enabled = true;
						lAladiAce39.Enabled = true;
						tbAladiAce39.Enabled = true;
						lComum.Enabled = true;
						tbComum.Enabled = true;
						lAladiAce59.Enabled = true;
						tbAladiAce59.Enabled = true;
						/*FORMA*/
						break;
					case 589 : // Peru
						lAladiAptr04.Enabled = true;
						tbAladiAptr04.Enabled = true;
						lAladiAce39.Enabled = true;
						tbAladiAce39.Enabled = true;
						lComum.Enabled = true;
						tbComum.Enabled = true;
						break;
					case 199: // Cuba
					case 493: // Mexico 
						lAladiAptr04.Enabled = true;
						tbAladiAptr04.Enabled = true;
						lComum.Enabled = true;
						tbComum.Enabled = true;
						/*FORMA*/
						break;
					case -1: // Nenhum idEscolhido
						break;
					default: // Resto dos Paises
						lComum.Enabled = true;
						tbComum.Enabled = true;
						break;
				}
				lFormA.Enabled = true;
				tbFormA.Enabled = true;
				#endregion
				#region AladiAce39
				if (lAladiAce39.Enabled)
				{
					dtrwTbCertificadosOrigem = m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.FindByidExportadoridPEnIdTipoCO(m_nIdExportador, m_strIdPE, (int)TIPOSCO.ALADIACE39);
					if (dtrwTbCertificadosOrigem != null)
					{
						tbAladiAce39.Text = (dtrwTbCertificadosOrigem.IsstrNumeroCertificadoOrigemNull() ? "" : dtrwTbCertificadosOrigem.strNumeroCertificadoOrigem);
					}
					else
					{
						lAladiAce39.Enabled = false;
						tbAladiAce39.Enabled = false;
					}
					dtrwTbCertificadosOrigem = null;
				}
				#endregion
				#region AladiAce59
				if (lAladiAce59.Enabled)
				{
					dtrwTbCertificadosOrigem = m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.FindByidExportadoridPEnIdTipoCO(m_nIdExportador, m_strIdPE, (int)TIPOSCO.ALADIACE59);
					if (dtrwTbCertificadosOrigem != null)
					{
						tbAladiAce59.Text = (dtrwTbCertificadosOrigem.IsstrNumeroCertificadoOrigemNull() ? "" : dtrwTbCertificadosOrigem.strNumeroCertificadoOrigem);
					}
					else
					{
						lAladiAce59.Enabled = false;
						tbAladiAce59.Enabled = false;
					}
					dtrwTbCertificadosOrigem = null;
				}
				#endregion
				#region AladiAptr04
				if (lAladiAptr04.Enabled)
				{
					dtrwTbCertificadosOrigem = m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.FindByidExportadoridPEnIdTipoCO(m_nIdExportador, m_strIdPE, (int)TIPOSCO.ALADIAPTR04);
					if (dtrwTbCertificadosOrigem != null)
					{
						tbAladiAptr04.Text = (dtrwTbCertificadosOrigem.IsstrNumeroCertificadoOrigemNull() ? "" : dtrwTbCertificadosOrigem.strNumeroCertificadoOrigem);
					}
					else
					{
						lAladiAptr04.Enabled = false;
						tbAladiAptr04.Enabled = false;
					}
					dtrwTbCertificadosOrigem = null;
				}
				#endregion
				#region Anexo3
				if (lAnexo3.Enabled)
				{
					dtrwTbCertificadosOrigem = m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.FindByidExportadoridPEnIdTipoCO(m_nIdExportador, m_strIdPE, (int)TIPOSCO.ANEXO3);
					if (dtrwTbCertificadosOrigem != null)
					{
						tbAnexo3.Text = (dtrwTbCertificadosOrigem.IsstrNumeroCertificadoOrigemNull() ? "" : dtrwTbCertificadosOrigem.strNumeroCertificadoOrigem);
					}
					else
					{
						lAnexo3.Enabled = false;
						tbAnexo3.Enabled = false;
					}
					dtrwTbCertificadosOrigem = null;
				}
				#endregion
				#region Bolivia
				if (lBolivia.Enabled)
				{
					dtrwTbCertificadosOrigem = m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.FindByidExportadoridPEnIdTipoCO(m_nIdExportador, m_strIdPE, (int)TIPOSCO.MERCOSULBOLIVIA);
					if (dtrwTbCertificadosOrigem != null)
					{
						tbBolivia.Text = (dtrwTbCertificadosOrigem.IsstrNumeroCertificadoOrigemNull() ? "" : dtrwTbCertificadosOrigem.strNumeroCertificadoOrigem);
					}
					else
					{
						lBolivia.Enabled = false;
						tbBolivia.Enabled = false;
					}
					dtrwTbCertificadosOrigem = null;
				}
				#endregion
				#region Chile
				if (lChile.Enabled)
				{
					dtrwTbCertificadosOrigem = m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.FindByidExportadoridPEnIdTipoCO(m_nIdExportador, m_strIdPE, (int)TIPOSCO.MERCOSULCHILE);
					if (dtrwTbCertificadosOrigem != null)
					{
						tbChile.Text = (dtrwTbCertificadosOrigem.IsstrNumeroCertificadoOrigemNull() ? "" : dtrwTbCertificadosOrigem.strNumeroCertificadoOrigem);
					}
					else
					{
						lChile.Enabled = false;
						tbChile.Enabled = false;
					}
					dtrwTbCertificadosOrigem = null;
				}
				#endregion
				#region Comum
				if (lComum.Enabled)
				{
					dtrwTbCertificadosOrigem = m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.FindByidExportadoridPEnIdTipoCO(m_nIdExportador, m_strIdPE, (int)TIPOSCO.COMUM);
					if (dtrwTbCertificadosOrigem != null)
					{
						tbComum.Text = (dtrwTbCertificadosOrigem.IsstrNumeroCertificadoOrigemNull() ? "" : dtrwTbCertificadosOrigem.strNumeroCertificadoOrigem);
					}
					else
					{
						lComum.Enabled = false;
						tbComum.Enabled = false;
					}
					dtrwTbCertificadosOrigem = null;
				}
				#endregion
				#region FormA
				if (lFormA.Enabled)
				{
					dtrwTbCertificadosOrigem = m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.FindByidExportadoridPEnIdTipoCO(m_nIdExportador, m_strIdPE, (int)TIPOSCO.FORMA);
					if (dtrwTbCertificadosOrigem != null)
					{
						tbFormA.Text = (dtrwTbCertificadosOrigem.IsstrNumeroCertificadoOrigemNull() ? "" : dtrwTbCertificadosOrigem.strNumeroCertificadoOrigem);
					}
					else
					{
						lFormA.Enabled = false;
						tbFormA.Enabled = false;
					}
					dtrwTbCertificadosOrigem = null;
				}
				#endregion
				#region Mercosul
				if (lMercosul.Enabled)
				{
					dtrwTbCertificadosOrigem = m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.FindByidExportadoridPEnIdTipoCO(m_nIdExportador, m_strIdPE, (int)TIPOSCO.MERCOSUL);
					if (dtrwTbCertificadosOrigem != null)
					{
						tbMercosul.Text = (dtrwTbCertificadosOrigem.IsstrNumeroCertificadoOrigemNull() ? "" : dtrwTbCertificadosOrigem.strNumeroCertificadoOrigem);
					}
					else
					{
						lMercosul.Enabled = false;
						tbMercosul.Enabled = false;
					}
					dtrwTbCertificadosOrigem = null;
				}
				#endregion
			}
			catch (Exception err)
			{
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion
		#endregion
		#region Salvamento dos Dados
		#region Interface
		private void salvaDadosInterface(ref System.Windows.Forms.Label lAladiAce39, ref mdlComponentesGraficos.TextBox tbAladiAce39,ref System.Windows.Forms.Label lAladiAce59, ref mdlComponentesGraficos.TextBox tbAladiAce59, ref System.Windows.Forms.Label lAladiAptr04, ref mdlComponentesGraficos.TextBox tbAladiAptr04, ref System.Windows.Forms.Label lAnexo3, ref mdlComponentesGraficos.TextBox tbAnexo3, ref System.Windows.Forms.Label lComum, ref mdlComponentesGraficos.TextBox tbComum, ref System.Windows.Forms.Label lFormA, ref mdlComponentesGraficos.TextBox tbFormA, ref System.Windows.Forms.Label lMercosul, ref mdlComponentesGraficos.TextBox tbMercosul, ref System.Windows.Forms.Label lBolivia, ref mdlComponentesGraficos.TextBox tbBolivia, ref System.Windows.Forms.Label lChile, ref mdlComponentesGraficos.TextBox tbChile)
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow dtrwTbCertificadosOrigem = null;
				#region AladiAce39
				if (lAladiAce39.Enabled)
				{
					dtrwTbCertificadosOrigem = m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.FindByidExportadoridPEnIdTipoCO(m_nIdExportador, m_strIdPE, (int)TIPOSCO.ALADIACE39);
					if (dtrwTbCertificadosOrigem != null)
					{
						dtrwTbCertificadosOrigem.strNumeroCertificadoOrigem = tbAladiAce39.Text;
					}
					dtrwTbCertificadosOrigem = null;
				}
				#endregion
				#region AladiAce59
				if (lAladiAce59.Enabled)
				{
					dtrwTbCertificadosOrigem = m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.FindByidExportadoridPEnIdTipoCO(m_nIdExportador, m_strIdPE, (int)TIPOSCO.ALADIACE59);
					if (dtrwTbCertificadosOrigem != null)
					{
						dtrwTbCertificadosOrigem.strNumeroCertificadoOrigem = tbAladiAce59.Text;
					}
					dtrwTbCertificadosOrigem = null;
				}
				#endregion
				#region AladiAptr04
				if (lAladiAptr04.Enabled)
				{
					dtrwTbCertificadosOrigem = m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.FindByidExportadoridPEnIdTipoCO(m_nIdExportador, m_strIdPE, (int)TIPOSCO.ALADIAPTR04);
					if (dtrwTbCertificadosOrigem != null)
					{
						dtrwTbCertificadosOrigem.strNumeroCertificadoOrigem = tbAladiAptr04.Text;
					}
					dtrwTbCertificadosOrigem = null;
				}
				#endregion
				#region Anexo3
				if (lAnexo3.Enabled)
				{
					dtrwTbCertificadosOrigem = m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.FindByidExportadoridPEnIdTipoCO(m_nIdExportador, m_strIdPE, (int)TIPOSCO.ANEXO3);
					if (dtrwTbCertificadosOrigem != null)
					{
						dtrwTbCertificadosOrigem.strNumeroCertificadoOrigem = tbAnexo3.Text;
					}
					dtrwTbCertificadosOrigem = null;
				}
				#endregion
				#region Bolivia
				if (lBolivia.Enabled)
				{
					dtrwTbCertificadosOrigem = m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.FindByidExportadoridPEnIdTipoCO(m_nIdExportador, m_strIdPE, (int)TIPOSCO.MERCOSULBOLIVIA);
					if (dtrwTbCertificadosOrigem != null)
					{
						dtrwTbCertificadosOrigem.strNumeroCertificadoOrigem = tbBolivia.Text;
					}
					dtrwTbCertificadosOrigem = null;
				}
				#endregion
				#region Chile
				if (lChile.Enabled)
				{
					dtrwTbCertificadosOrigem = m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.FindByidExportadoridPEnIdTipoCO(m_nIdExportador, m_strIdPE, (int)TIPOSCO.MERCOSULCHILE);
					if (dtrwTbCertificadosOrigem != null)
					{
						dtrwTbCertificadosOrigem.strNumeroCertificadoOrigem = tbChile.Text;
					}
					dtrwTbCertificadosOrigem = null;
				}
				#endregion
				#region Comum
				if (lComum.Enabled)
				{
					dtrwTbCertificadosOrigem = m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.FindByidExportadoridPEnIdTipoCO(m_nIdExportador, m_strIdPE, (int)TIPOSCO.COMUM);
					if (dtrwTbCertificadosOrigem != null)
					{
						dtrwTbCertificadosOrigem.strNumeroCertificadoOrigem = tbComum.Text;
					}
					dtrwTbCertificadosOrigem = null;
				}
				#endregion
				#region FormA
				if (lFormA.Enabled)
				{
					dtrwTbCertificadosOrigem = m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.FindByidExportadoridPEnIdTipoCO(m_nIdExportador, m_strIdPE, (int)TIPOSCO.FORMA);
					if (dtrwTbCertificadosOrigem != null)
					{
						dtrwTbCertificadosOrigem.strNumeroCertificadoOrigem = tbFormA.Text;
					}
					dtrwTbCertificadosOrigem = null;
				}
				#endregion
				#region Mercosul
				if (lMercosul.Enabled)
				{
					dtrwTbCertificadosOrigem = m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.FindByidExportadoridPEnIdTipoCO(m_nIdExportador, m_strIdPE, (int)TIPOSCO.MERCOSUL);
					if (dtrwTbCertificadosOrigem != null)
					{
						dtrwTbCertificadosOrigem.strNumeroCertificadoOrigem = tbMercosul.Text;
					}
					dtrwTbCertificadosOrigem = null;
				}
				#endregion
			}
			catch (Exception err)
			{
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion
		#region Banco de Dados
		private void salvaDadosBD(bool bModificado)
		{
			try
			{
				m_bModificado = bModificado;
				m_cls_dba_ConnectionBD.SetTbCertificadosOrigem(m_typDatSetTbCertificadosOrigem);
			}
			catch (Exception err)
			{
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion
		#endregion
	}
}
