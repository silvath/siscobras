using System;

namespace mdlNormas
{
	/// <summary>
	/// Summary description for clsNormas.
	/// </summary>
	public abstract class clsNormas
	{
		#region Atributos
			protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro; 
			protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB;
			protected string m_strEnderecoExecutavel;

			protected int m_nIdExportador = -1;
			protected string m_strIdPE = "";

			protected System.Collections.ArrayList m_arlNormasCOs = null;
			private System.Collections.ArrayList m_arlStrNormasCOs = null;
			protected System.Collections.ArrayList m_arlIdOrdemCOs = null;

			private int m_nIdNorma = 0;

			private int m_nIdTipoCO;

			private string m_strDescricao = "";
			private string m_strNome = "";

			public bool m_bModificado = false;

			private Frames.frmFNormas m_formFNormas = null;

			private mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigemNormas m_typDatSetNormasResource = null;
			private mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigemNormas m_typDatSetNormasDataBase = null;
			protected  mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem m_typDatSetTbProdutosCertificadoOrigem = null;
		#endregion
		#region Construtors and Destrutors
		public clsNormas(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess conexaoBD,string EnderecoExecutavel, int TipoCO)
		{
			m_cls_ter_tratadorErro = tratadorErro;
			m_cls_dba_ConnectionDB = conexaoBD;
			m_strEnderecoExecutavel = EnderecoExecutavel;
			m_nIdTipoCO = TipoCO;
			m_arlNormasCOs = new System.Collections.ArrayList();
			m_arlStrNormasCOs = new System.Collections.ArrayList();
			m_arlIdOrdemCOs = new System.Collections.ArrayList();
		}
		#endregion

		#region ShowDialog
		public void ShowDialog()
		{
			try
			{
				m_formFNormas = new Frames.frmFNormas(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel);
				vInitializeEvents(ref m_formFNormas);
				m_formFNormas.ShowDialog();
				m_formFNormas = null;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}

		private void vInitializeEvents(ref Frames.frmFNormas formFNormas)
		{
			// Carrega Dados BD
			formFNormas.eCallCarregaDadosBD += new Frames.frmFNormas.delCallCarregaDadosBD(carregaDadosBD);

			// Carrega BD Normas
			formFNormas.eCallCarregaDadosBDNormas += new Frames.frmFNormas.delCallCarregaDadosBDNormas(carregaDadosBDNormas);

			// Carrega Dados Interface
			formFNormas.eCallCarregaDadosInterface += new Frames.frmFNormas.delCallCarregaDadosInterface(carregaDadosInterface);

			// Carrreda Dados Normas Interface
			formFNormas.eCallCarregaDadosNormasInterface += new Frames.frmFNormas.delCallCarregaDadosNormasInterface(carregaDadosNormasInterface);

			// Salva Dados BD
			formFNormas.eCallSalvaDadosBD += new Frames.frmFNormas.delCallSalvaDadosBD(SalvaDadosBD);
		}
		#endregion

		#region Carregamento de Dados
		#region Banco de Dados
			protected virtual bool bCarregaDados()
			{
				// Normas
				return(bCarregaDadosNormas());
			}

			private bool bCarregaDadosNormas()
			{
				// Normas
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("nIdTipoCO");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdTipoCO);

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
				m_typDatSetNormasResource = m_cls_dba_ConnectionDB.GetTbCertificadosOrigemNormas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				m_typDatSetNormasDataBase = m_cls_dba_ConnectionDB.GetTbCertificadosOrigemNormas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				return(m_cls_dba_ConnectionDB.Erro == null);
			}	

		protected void carregaDadosBD()
		{
			try
			{
				m_arlStrNormasCOs.Clear();
				bool bPrimeiro = true;
				m_strDescricao = "";
				m_strNome = "";
				carregaDadosBDEspecificos();
				mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigemNormas.tbCertificadosOrigemNormasRow dtrwTbCertificadosOrigemNormas;
				foreach(int nIdNorma in m_arlNormasCOs)
				{
					dtrwTbCertificadosOrigemNormas = m_typDatSetNormasResource.tbCertificadosOrigemNormas.FindBynIdTipoCOnIdNorma(m_nIdTipoCO,nIdNorma);
					if (dtrwTbCertificadosOrigemNormas != null)
					{
						if (bPrimeiro == false)
						{
							m_strDescricao += ", ";
							m_strNome += ", ";
						}
						else
						{
							bPrimeiro = false;
						}
						m_strDescricao += dtrwTbCertificadosOrigemNormas.mstrDescricao;
						m_strNome += dtrwTbCertificadosOrigemNormas.mstrNome;
						m_arlStrNormasCOs.Add(dtrwTbCertificadosOrigemNormas.mstrNome);
					}
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected abstract void carregaDadosBDEspecificos();
		private void carregaDadosBDNormas(ref mdlComponentesGraficos.ListView lvNormas)
		{
			try
			{
				if (lvNormas.SelectedItems.Count > 0)
					m_nIdNorma = (int)lvNormas.SelectedItems[0].Tag;
				mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigemNormas.tbCertificadosOrigemNormasRow dtrwTbCertificadosOrigemNormas;
				dtrwTbCertificadosOrigemNormas = m_typDatSetNormasResource.tbCertificadosOrigemNormas.FindBynIdTipoCOnIdNorma(m_nIdTipoCO, m_nIdNorma);
				if (dtrwTbCertificadosOrigemNormas != null)
				{
					if (!dtrwTbCertificadosOrigemNormas.IsmstrDescricaoNull())
					{
						m_strDescricao = dtrwTbCertificadosOrigemNormas.mstrDescricao;
					}
					else
					{
						m_strDescricao = "";
					}
					if (!dtrwTbCertificadosOrigemNormas.IsmstrNomeNull())
					{
						m_strNome = dtrwTbCertificadosOrigemNormas.mstrNome;
					}
					else
					{
						m_strNome = "";
					}
				}
				else
				{
					m_strDescricao = "";
					m_strNome = "";
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
		protected void carregaDadosInterface(ref mdlComponentesGraficos.ListView lvNormas,ref System.Windows.Forms.Form formNorma)
		{
			try
			{
				m_strDescricao = "";
				m_strNome = "";
				bool bPrimeiro = true;
				System.Windows.Forms.ListViewItem lvItemNorma;
				mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigemNormas.tbCertificadosOrigemNormasRow dtrwTbCertificadosOrigemNormas;
				for (int nCount = 0; nCount < m_typDatSetNormasResource.tbCertificadosOrigemNormas.Rows.Count; nCount++)
				{
					dtrwTbCertificadosOrigemNormas = (mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigemNormas.tbCertificadosOrigemNormasRow)m_typDatSetNormasResource.tbCertificadosOrigemNormas.Rows[nCount];
					lvItemNorma = lvNormas.Items.Add(dtrwTbCertificadosOrigemNormas.mstrNome);
					lvItemNorma.Tag = dtrwTbCertificadosOrigemNormas.nIdNorma;
					if (m_arlNormasCOs.Contains(dtrwTbCertificadosOrigemNormas.nIdNorma))
					{
						if (bPrimeiro == false)
						{
							m_strDescricao += ", ";
							m_strNome += ", ";
						}
						else
						{
							bPrimeiro = false;
						}
						lvItemNorma.Selected = true;
						m_strDescricao += dtrwTbCertificadosOrigemNormas.mstrDescricao;
						m_strNome += dtrwTbCertificadosOrigemNormas.mstrNome;
					}
				}
				carregaDadosInterfaceEspecificos(ref formNorma);
				if (m_strDescricao.Length > 0)
					lvNormas.Columns[0].Width = m_strDescricao.Length;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected abstract void carregaDadosInterfaceEspecificos(ref System.Windows.Forms.Form formNorma);
		protected void carregaDadosNormasInterface(ref System.Windows.Forms.RichTextBox rtbDadosNormas)
		{
			try
			{
				#region Cria Variáveis RichTextBox
				// Limpa os Items da Rich Text Box
				rtbDadosNormas.Clear();
				#endregion
				
				#region Adicionando Items à Rich Text Box
				#region Denominação
				rtbDadosNormas.Font = new System.Drawing.Font(rtbDadosNormas.Font, System.Drawing.FontStyle.Bold);
				rtbDadosNormas.SelectionColor = System.Drawing.Color.Black;
				rtbDadosNormas.AppendText(m_strDescricao);
				#endregion
				#endregion
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
		private void SalvaDadosBD(bool bModificado)
		{
			try
			{
				m_bModificado = bModificado;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Retorna Valores
			public void retornaValores(out int nIdNorma, out string strNomeNorma)
			{
				nIdNorma = m_nIdNorma;
				strNomeNorma = m_strNome;
			}
			public void retornaValores(out int nIdNorma, out string strNomeNorma, out string strDescricaoNorma)
			{
				nIdNorma = m_nIdNorma;
				strNomeNorma = m_strNome;
				strDescricaoNorma = m_strDescricao;
			}
			public void retornaValores(out System.Collections.ArrayList arlIdOrdemCOs, out System.Collections.ArrayList arlStrNormasCOs)
			{
				arlIdOrdemCOs = m_arlIdOrdemCOs;
				arlStrNormasCOs = m_arlStrNormasCOs;
			}
		#endregion
	}
}
