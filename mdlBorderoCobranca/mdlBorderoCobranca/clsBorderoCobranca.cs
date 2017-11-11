using System;

namespace mdlBorderoCobranca
{
	public enum ENTREGARDOCUMENTOS { ACEITE = 1, PAGAMENTO = 2 };
	/// <summary>
	/// Summary description for clsBorderoCobranca.
	/// </summary>
	public class clsBorderoCobranca
	{
		#region Atributos
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
		protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB;
		protected string m_strEnderecoExecutavel;

		public bool m_bModificado = false;

		protected int m_nIdExportador = -1;
		protected string m_strIdPE = "";
		protected ENTREGARDOCUMENTOS m_enumEntregaDocumentos = ENTREGARDOCUMENTOS.ACEITE;
		protected bool m_bProtestar = true;
		protected int m_nDiasProtestar = 15;

		private Frames.frmFBorderoCobranca m_formFBorderoCobranca = null;

		private mdlDataBaseAccess.Tabelas.XsdTbBorderos m_typDatSetTbBorderos = null;
		#endregion

		#region Construtores & Destrutores
		public clsBorderoCobranca(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB, string EnderecoExecutavel, int idExportador, string strIdPE)
		{
			m_cls_ter_tratadorErro = tratadorErro;
			m_cls_dba_ConnectionDB = ConnectionDB;
			m_strEnderecoExecutavel = EnderecoExecutavel;
			m_nIdExportador = idExportador;
			m_strIdPE = strIdPE;
			carregaTypDatSet();
			carregaDadosBDCobranca();
		}
		#endregion

		#region ShowDialog
		private void InitializeEventsFormBorderoCobranca()
		{
			// Carrega Dados Interface
			m_formFBorderoCobranca.eCallCarregaDadosInterface += new Frames.frmFBorderoCobranca.delCallCarregaDadosInterface(carregaDadosInterface);

			// Trocar Protesto
			m_formFBorderoCobranca.eCallTrocarProtesto += new Frames.frmFBorderoCobranca.delCallTrocarProtesto(trocarProtesto);

			// Salva Dados Interface
			m_formFBorderoCobranca.eCallSalvaDadosInterface += new Frames.frmFBorderoCobranca.delCallSalvaDadosInterface(salvaDadosInterface);

			// Salva Dados BD
			m_formFBorderoCobranca.eCallSalvaDadosBD += new Frames.frmFBorderoCobranca.delCallSalvaDadosBD(salvaDadosBD);
		}

		public void ShowDialog()
		{
			try
			{
				m_formFBorderoCobranca = new Frames.frmFBorderoCobranca(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel);
				InitializeEventsFormBorderoCobranca();
				m_formFBorderoCobranca.ShowDialog();
				m_formFBorderoCobranca = null;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
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

				m_typDatSetTbBorderos = m_cls_dba_ConnectionDB.GetTbBorderos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void carregaDadosBDCobranca()
		{
			try
			{
				if ((m_typDatSetTbBorderos != null) && (m_typDatSetTbBorderos.tbBorderos.Rows.Count > 0))
				{
					mdlDataBaseAccess.Tabelas.XsdTbBorderos.tbBorderosRow dtrwTbBorderos = (mdlDataBaseAccess.Tabelas.XsdTbBorderos.tbBorderosRow)m_typDatSetTbBorderos.tbBorderos.Rows[0];
					if (dtrwTbBorderos != null)
					{
						m_enumEntregaDocumentos = (dtrwTbBorderos.IsnEntregaDocumentosNull() ? ENTREGARDOCUMENTOS.ACEITE : (ENTREGARDOCUMENTOS)dtrwTbBorderos.nEntregaDocumentos);
						m_bProtestar = (dtrwTbBorderos.IsbCobrancaProtestarNull() ? true : dtrwTbBorderos.bCobrancaProtestar);
						m_nDiasProtestar = (dtrwTbBorderos.IsnCobrancaDiasVencimentoNull() ? 15 : dtrwTbBorderos.nCobrancaDiasVencimento);
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
		private void carregaDadosInterface(ref mdlComponentesGraficos.ComboBox cbEntregar, ref System.Windows.Forms.Label lProtestar, ref mdlComponentesGraficos.TextBox tbDias, ref System.Windows.Forms.Label lTextoProtestar, ref System.Windows.Forms.Label lTextoDias)
		{
			try
			{
				carregaDadosComboBox(ref cbEntregar);
				lProtestar.Text = (m_bProtestar ? "Sim" : "Não");
				tbDias.Text = m_nDiasProtestar.ToString();
				switch (m_enumEntregaDocumentos)
				{
					case ENTREGARDOCUMENTOS.ACEITE:
						lProtestar.Visible = true;
						lTextoDias.Visible = m_bProtestar;
						lTextoProtestar.Visible = true;
						tbDias.Visible = m_bProtestar;
						break;
					case ENTREGARDOCUMENTOS.PAGAMENTO:
						lProtestar.Visible = false;
						lTextoDias.Visible = false;
						lTextoProtestar.Visible = false;
						tbDias.Visible = false;
						break;
					default:
						lProtestar.Visible = false;
						lTextoDias.Visible = false;
						lTextoProtestar.Visible = false;
						tbDias.Visible = false;
						break;
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void carregaDadosComboBox(ref mdlComponentesGraficos.ComboBox cbEntregar)
		{
			try
			{
				cbEntregar.Items.Clear();
				cbEntregar.AddItem("Contra Aceite", ENTREGARDOCUMENTOS.ACEITE);
				cbEntregar.AddItem("Contra Pagamento", ENTREGARDOCUMENTOS.PAGAMENTO);
				cbEntregar.SelectItem(m_enumEntregaDocumentos);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#endregion
		#region Salvamento dos Dados
		private void trocarProtesto(ref System.Windows.Forms.Label lProtestar)
		{
			try
			{
				m_bProtestar = !m_bProtestar;
				lProtestar.Text = (m_bProtestar ? "Sim" : "Não");
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void salvaDadosInterface(ref mdlComponentesGraficos.ComboBox cbEntregar, ref System.Windows.Forms.Label lProtestar, ref mdlComponentesGraficos.TextBox tbDias)
		{
			try
			{
				if (cbEntregar.ReturnObjectSelectedItem() != null)
				{
					m_enumEntregaDocumentos = (ENTREGARDOCUMENTOS)cbEntregar.ReturnObjectSelectedItem();
					m_bProtestar = (lProtestar.Text == "Sim" ? true : false);
					m_nDiasProtestar = Int32.Parse(tbDias.Text);
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void salvaDadosBD()
		{
			try
			{
				if ((m_typDatSetTbBorderos != null) && (m_typDatSetTbBorderos.tbBorderos.Rows.Count > 0))
				{
					mdlDataBaseAccess.Tabelas.XsdTbBorderos.tbBorderosRow dtrwTbBorderos = (mdlDataBaseAccess.Tabelas.XsdTbBorderos.tbBorderosRow)m_typDatSetTbBorderos.tbBorderos.Rows[0];
					if (dtrwTbBorderos != null)
					{
						dtrwTbBorderos.bCobrancaProtestar = m_bProtestar;
						dtrwTbBorderos.nEntregaDocumentos = (int)m_enumEntregaDocumentos;
						dtrwTbBorderos.nCobrancaDiasVencimento = m_nDiasProtestar;
					}
					m_cls_dba_ConnectionDB.SetTbBorderos(m_typDatSetTbBorderos);
					m_bModificado = true;
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Retorna Valores
		public void retornaValores(out ENTREGARDOCUMENTOS enumEntregaDocumentos, out bool bProtestar, out int nDiasVencimento)
		{
			enumEntregaDocumentos = m_enumEntregaDocumentos;
			bProtestar = m_bProtestar;
			nDiasVencimento = m_nDiasProtestar;
		}
		#endregion
	}
}
