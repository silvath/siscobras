using System;

namespace mdlNumero.PEs
{
	/// <summary>
	/// Summary description for clsNumeroSiscomex.
	/// </summary>
	public class clsNumeroSiscomex
	{
		#region Atributos
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
		protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionBD = null;
		protected string m_strEnderecoExecutavel = "";

		public bool m_bModificado = false;

		protected int m_nIdExportador = -1;
		private string m_strIdPE = "";

		private string m_strDSE = "";
		private System.DateTime m_dtDataDSE = System.DateTime.Now;
		private string m_strRE = "";
		private System.DateTime m_dtDataRE = System.DateTime.Now;
		private string m_strSD = "";
		private System.DateTime m_dtDataSD = System.DateTime.Now;

		private bool m_bRE = false;

		private frmFNumeroSiscomex m_formFNumeroSiscomex = null;

		private mdlDataBaseAccess.Tabelas.XsdTbPes m_typDatSetTbPEs = null;
		#endregion

		#region Construtores & Destrutores
		public clsNumeroSiscomex(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string idPE)
		{
			m_cls_ter_tratadorErro = tratadorErro;
			m_cls_dba_ConnectionBD = ConnectionDB;
			m_strEnderecoExecutavel = EnderecoExecutavel;
			m_nIdExportador = nIdExportador;
			m_strIdPE = idPE;
			carregaTypDatSet();
			carregaDadosBD();
		}
		#endregion

		#region InitializeEventsFormNumeroSiscomex
		private void InitializeEventsFormNumeroSiscomex()
		{
			// Carrega Dados Interface
			m_formFNumeroSiscomex.eCallCarregaDadosInterface += new frmFNumeroSiscomex.delCallCarregaDadosInterface(carregaDadosInterface);

			// Salva Dados Interface
			m_formFNumeroSiscomex.eCallSalvaDadosInterface += new frmFNumeroSiscomex.delCallSalvaDadosInterface(salvaDadosInterface);

			// Salva Dados BD
			m_formFNumeroSiscomex.eCallSalvaDadosBD += new frmFNumeroSiscomex.delCallSalvaDadosBD(salvaDadosBD);
		}
		#endregion

		#region Carregamento de Dados
		#region Banco de Dados
		protected void carregaTypDatSet()
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

				m_typDatSetTbPEs = m_cls_dba_ConnectionBD.GetTbPes(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected void carregaDadosBD()
		{
			try
			{
				if (m_typDatSetTbPEs.tbPEs.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwTbPEs = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetTbPEs.tbPEs.Rows[0];
					m_strRE = (dtrwTbPEs.IsmstrRENull() ? "" : dtrwTbPEs.mstrRE);
					m_dtDataRE = (!dtrwTbPEs.IsdtEmissaoRENull() ? dtrwTbPEs.dtEmissaoRE : System.DateTime.Now);
					m_strSD = (dtrwTbPEs.IsmstrSDNull() ? "" : dtrwTbPEs.mstrSD);
					m_dtDataSD = (!dtrwTbPEs.IsdtEmissaoSDNull() ? dtrwTbPEs.dtEmissaoSD : System.DateTime.Now);
					m_strDSE = (dtrwTbPEs.IsmstrDSENull() ? "" : dtrwTbPEs.mstrDSE);
					m_dtDataDSE = (!dtrwTbPEs.IsdtEmissaoDSENull() ? dtrwTbPEs.dtEmissaoDSE : System.DateTime.Now);
					if (m_strRE.Trim() != "")
						m_bRE = true;
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
		private void carregaDadosInterface(ref System.Windows.Forms.RadioButton rbRE, ref mdlComponentesGraficos.TextBox tbRE, ref System.Windows.Forms.DateTimePicker dtpkRE, ref System.Windows.Forms.Label lSD, ref mdlComponentesGraficos.TextBox tbSD, ref System.Windows.Forms.DateTimePicker dtpkSD, ref System.Windows.Forms.RadioButton rbDSE, ref mdlComponentesGraficos.TextBox tbDSE, ref System.Windows.Forms.DateTimePicker dtpkDSE)
		{
			try
			{
				if (m_strRE.Trim() != "")
				{
					rbRE.Checked = true;
					tbRE.Text = m_strRE;
					tbRE.Enabled = true;
					dtpkRE.Enabled = true;
					dtpkRE.Value = m_dtDataRE;
					lSD.Enabled = true;
					tbSD.Text = m_strSD;
					dtpkSD.Enabled = true;
					dtpkSD.Value = m_dtDataSD;
					tbSD.Enabled = true;
					rbDSE.Checked = false;
					tbDSE.Text = m_strDSE;
					tbDSE.Enabled = false;
					dtpkDSE.Enabled = false;
					dtpkDSE.Value = m_dtDataDSE;
				}
				else if (m_strDSE.Trim() != "")
				{
					rbRE.Checked = false;
					tbRE.Text = m_strRE;
					tbRE.Enabled = false;
					dtpkRE.Enabled = false;
					dtpkRE.Value = m_dtDataRE;
					lSD.Enabled = false;
					tbSD.Text = m_strSD;
					tbSD.Enabled = false;
					dtpkSD.Enabled = false;
					dtpkSD.Value = m_dtDataSD;
					rbDSE.Checked = true;
					tbDSE.Text = m_strDSE;
					tbDSE.Enabled = true;
					dtpkDSE.Enabled = true;
					dtpkDSE.Value = m_dtDataDSE;
				}
				else
				{
					tbRE.Enabled = false;
					dtpkRE.Enabled = false;
					lSD.Enabled = false;
					tbSD.Enabled = false;
					dtpkSD.Enabled = false;
					tbDSE.Enabled = false;
					dtpkDSE.Enabled = false;
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
		#region Salvamento de Dados
		#region Interface
		private void salvaDadosInterface(ref System.Windows.Forms.RadioButton rbRE, ref mdlComponentesGraficos.TextBox tbRE, ref System.Windows.Forms.DateTimePicker dtpkRE, ref System.Windows.Forms.Label lSD, ref mdlComponentesGraficos.TextBox tbSD, ref System.Windows.Forms.DateTimePicker dtpkSD, ref System.Windows.Forms.RadioButton rbDSE, ref mdlComponentesGraficos.TextBox tbDSE, ref System.Windows.Forms.DateTimePicker dtpkDSE)
		{
			try
			{
				if (rbRE.Checked)
				{
					m_bRE = true;
					m_strRE = tbRE.Text;
					tbRE.Enabled = true;
					m_dtDataRE = dtpkRE.Value;
					dtpkRE.Enabled = true;
					lSD.Enabled = true;
					m_strSD = tbSD.Text;
					tbSD.Enabled = true;
					m_dtDataSD = dtpkSD.Value;
					dtpkSD.Enabled = true;
					rbDSE.Checked = false;
					m_strDSE = tbDSE.Text;
					tbDSE.Enabled = false;
					m_dtDataDSE = dtpkDSE.Value;
					dtpkDSE.Enabled = false;
				}
				else if (rbDSE.Checked)
				{
					m_bRE = false;
					m_strRE = tbRE.Text;
					tbRE.Enabled = false;
					m_dtDataRE = dtpkRE.Value;
					dtpkRE.Enabled = false;
					lSD.Enabled = false;
					m_strSD = tbSD.Text;
					tbSD.Enabled = false;
					m_dtDataSD = dtpkSD.Value;
					dtpkSD.Enabled = false;
					m_strDSE = tbDSE.Text;
					tbDSE.Enabled = true;
					m_dtDataDSE = dtpkDSE.Value;
					dtpkDSE.Enabled = true;
				}
				else
				{
					tbRE.Enabled = false;
					dtpkRE.Enabled = false;
					lSD.Enabled = false;
					tbSD.Enabled = false;
					dtpkSD.Enabled = false;
					tbDSE.Enabled = false;
					dtpkDSE.Enabled = false;
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
		protected void salvaDadosBD()
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwRowTbPEs;
				if (m_typDatSetTbPEs.tbPEs.Rows.Count > 0)
				{
					dtrwRowTbPEs = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetTbPEs.tbPEs.Rows[0];
					if (dtrwRowTbPEs != null)
					{
						dtrwRowTbPEs.mstrDSE = (m_bRE ? "" : m_strDSE);
						if (m_bRE)
							dtrwRowTbPEs.SetdtEmissaoDSENull();
						else
							dtrwRowTbPEs.dtEmissaoDSE = m_dtDataDSE;
						dtrwRowTbPEs.mstrRE = (m_bRE ? m_strRE : "");
						if (m_bRE)
							dtrwRowTbPEs.dtEmissaoRE = m_dtDataRE;
						else
							dtrwRowTbPEs.SetdtEmissaoRENull();
						dtrwRowTbPEs.mstrSD = (m_bRE ? m_strSD : "");
						if (m_bRE)
							dtrwRowTbPEs.dtEmissaoSD = m_dtDataSD;
						else
							dtrwRowTbPEs.SetdtEmissaoSDNull();
					}

					m_cls_dba_ConnectionBD.SetTbPes(m_typDatSetTbPEs);
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

		#region Show Dialog
		public void ShowDialog()
		{
			try
			{
				m_formFNumeroSiscomex = new frmFNumeroSiscomex(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel);
				InitializeEventsFormNumeroSiscomex();
				m_formFNumeroSiscomex.ShowDialog();
				m_bModificado = m_formFNumeroSiscomex.m_bModificado;
				m_formFNumeroSiscomex = null;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Retorna Valores
		public void retornaValores(out string strRE, out string strEmissaoRE, out string strSD, out string strEmissaoSD, out string strDSE, out string strEmissaoDSE)
		{
			strDSE = (!m_bRE ? m_strDSE : "");
			strEmissaoDSE = (((!m_bRE) && (m_strDSE.Trim() != "")) ? m_dtDataDSE.ToString("dd/MM/yyyy") : "");
			strRE = (m_bRE ? m_strRE : "");
			strEmissaoRE = (((m_bRE) && (m_strRE.Trim() != "")) ? m_dtDataRE.ToString("dd/MM/yyyy") : "");
			strSD = (((m_bRE) && (m_strRE.Trim() != "")) ? m_strSD : "");
			strEmissaoSD = (((m_bRE) && (m_strSD.Trim() != "") && (m_strRE.Trim() != "")) ? m_dtDataSD.ToString("dd/MM/yyyy") : "");
		}
		#endregion
	}
}
