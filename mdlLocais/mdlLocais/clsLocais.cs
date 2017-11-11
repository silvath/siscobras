using System;

namespace mdlLocais
{
	/// <summary>
	/// Summary description for clsLocais.
	/// </summary>
	public abstract class clsLocais
	{
		#region Atributos
		protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConectionDB = null;
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
		protected string m_strEnderecoExecutavel = "";

		protected int m_nIdExportador = -1;
		protected int m_nIdImportador = -1;
		protected int m_nIdIncoterm = -1;
		protected int m_nIdPaisDestino = -1;
		protected string m_strIncoterm = "";
		protected string m_strLocalColeta = "";
		protected string m_strLocalDespacho = "";
		protected string m_strLocalEmbarque = "";
		protected string m_strLocalDestino = "";
		protected string m_strLocalEntrega = "";
		protected string m_strPaisDestino = "País do Importador";

		protected bool m_bBotaoIncotermHabilitado = true;

		public bool m_bModificado = false;

		private frmFLocais m_formFLocais = null;
		protected mdlIncoterm.clsIncoterm m_cls_Incoterm = null;

		internal const int EXW = 1;
		internal const int FCA = 2;
		internal const int FAS = 3;
		internal const int FOB = 4;
		internal const int CFR = 5;
		internal const int CIF = 6;
		internal const int CPT = 7;
		internal const int CIP = 8;
		internal const int DAF = 9;
		internal const int DES = 10;
		internal const int DEQ = 11;
		internal const int DDU = 12;
		internal const int DDP = 13;

		private mdlDataBaseAccess.Tabelas.XsdTbImportadores m_typDatSetTbImportadores = null;
		private mdlDataBaseAccess.Tabelas.XsdTbPaises m_typDatSetTbPaises = null;
		#endregion
		#region Properties
			public bool Incoterm
			{
				set
				{
					m_bBotaoIncotermHabilitado = value;
				}
				get
				{
					return(m_bBotaoIncotermHabilitado);
				}
			}	
		#endregion

		#region Constructor and Destructors
		public clsLocais(ref mdlTratamentoErro.clsTratamentoErro cls_ter_tratadorErro,ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConectionDB, string strEnderecoExecutavel, int nIdExportador)
		{
			m_cls_dba_ConectionDB = cls_dba_ConectionDB;
			m_cls_ter_tratadorErro = cls_ter_tratadorErro;
			m_strEnderecoExecutavel = strEnderecoExecutavel;
			m_nIdExportador = nIdExportador;
		}
		#endregion

		#region InitializeEventsFormLocais
		private void InitializeEventsFormLocais()
		{
			// Carrega Dados BD
			m_formFLocais.eCallCarregaDadosBD += new frmFLocais.delCallCarregaDadosBD(carregaDadosBD);

			// Carrega Dados Interface
			m_formFLocais.eCallCarregaDadosInterface += new frmFLocais.delCallCarregaDadosInterface(carregaDadosInterface);

			// Salva Dados Interface
			m_formFLocais.eCallSalvaDadosInterface += new frmFLocais.delCallSalvaDadosInterface(salvaDadosInterface);

			// Salva Dados BD
			m_formFLocais.eCallSalvaDadosBD += new frmFLocais.delCallSalvaDadosBD(salvaDadosBD);

			// Local Embarque
			m_formFLocais.eCallLocalEmbarqueTextChanged += new frmFLocais.delCallLocalEmbarqueTextChanged(localEmbarqueTextChanged);

			// Local Despacho
			m_formFLocais.eCallLocalDespachoTextChanged += new frmFLocais.delCallLocalDespachoTextChanged(localDespachoTextChanged);

			// Altera Incoterm
			m_formFLocais.eCallAlteraIncoterm += new frmFLocais.delCallAlteraIncoterm(alteraIncoterm);
		}
		#endregion

		#region ShowDialog
		public void ShowDialog()
		{
			try
			{
				m_formFLocais = new frmFLocais(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel, m_bBotaoIncotermHabilitado);
				InitializeEventsFormLocais();
				m_formFLocais.ShowDialog();
				m_formFLocais = null;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Show Dialog Incoterm
		private void ShowDialogIncoterm()
		{
			try
			{
				m_cls_Incoterm.ShowDialog();
				m_cls_Incoterm.retornaIdIncoterm(out m_nIdIncoterm);
				atualizaTypDatSetEspecifico();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Altera Incoterm
		private void alteraIncoterm()
		{
			try
			{
				criaIncotermEspecifico();
				ShowDialogIncoterm();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected abstract void criaIncotermEspecifico();
		#endregion

		#region AtualizaTypDatSet
		protected abstract void atualizaTypDatSetEspecifico();
		#endregion

		#region Carregamento dos Dados
		#region Banco de Dados
		protected void carregaTypDatSet()
		{
			try
			{
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdencaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdencaoTipo = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("idImportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdImportador);

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				m_typDatSetTbImportadores = m_cls_dba_ConectionDB.GetTbImportadores(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				arlOrdencaoCampo.Add("nmPais");
				arlOrdencaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente);
				
				m_cls_dba_ConectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
				m_typDatSetTbPaises = m_cls_dba_ConectionDB.GetTbPaises(null,null,null,/*arlOrdencaoCampo,arlOrdencaoTipo*/null,null);
				m_cls_dba_ConectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
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
				carregaDadosBDEspecifico();
				carregaDadosBDPaises();
				carregaStrIncoterm();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected abstract void carregaDadosBDEspecifico();
		protected void carregaDadosBDPaises()
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbImportadores.tbImportadoresRow dtrwRowTbImportadores = null;
				mdlDataBaseAccess.Tabelas.XsdTbPaises.tbPaisesRow dtrwRowTbPaises = null;
				if (m_typDatSetTbImportadores.tbImportadores.Rows.Count > 0)
				{
					dtrwRowTbImportadores = (mdlDataBaseAccess.Tabelas.XsdTbImportadores.tbImportadoresRow)m_typDatSetTbImportadores.tbImportadores.Rows[0];
					if (!dtrwRowTbImportadores.IsidPaisCliNull())
						m_nIdPaisDestino = dtrwRowTbImportadores.idPaisCli;
					else
						m_nIdPaisDestino = -1;
				}
				if (m_typDatSetTbPaises.tbPaises.Rows.Count > 0)
					dtrwRowTbPaises = m_typDatSetTbPaises.tbPaises.FindByidPais(m_nIdPaisDestino);
				if (dtrwRowTbPaises != null)
					m_strPaisDestino = dtrwRowTbPaises.nmPais;

			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void carregaStrIncoterm()
		{
			try
			{
				switch (m_nIdIncoterm)
				{
					case EXW: m_strIncoterm = "EXW";
					break;
					case FAS: m_strIncoterm = "FAS";
					break;
					case FOB: m_strIncoterm = "FOB";
					break;
					case FCA: m_strIncoterm = "FCA";
					break;
					case CFR: m_strIncoterm = "CFR";
					break;
					case CIF: m_strIncoterm = "CIF";
					break;
					case CPT: m_strIncoterm = "CPT";
					break;
					case CIP: m_strIncoterm = "CIP";
					break;
					case DES: m_strIncoterm = "DES";
					break;
					case DEQ: m_strIncoterm = "DEQ";
					break;
					case DAF: m_strIncoterm = "DAF";
					break;
					case DDU: m_strIncoterm = "DDU";
					break;
					case DDP: m_strIncoterm = "DDP";
					break;
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
		protected void carregaDadosInterface(ref mdlComponentesGraficos.TextBox tbLocalColeta, ref mdlComponentesGraficos.TextBox tbLocalDespacho, ref mdlComponentesGraficos.TextBox tbLocalDestino, ref mdlComponentesGraficos.TextBox tbLocalEmbarque, ref mdlComponentesGraficos.TextBox tbLocalEntrega, ref System.Windows.Forms.Button btIncoterm, ref System.Windows.Forms.GroupBox gbPaisOrigem, ref System.Windows.Forms.GroupBox gbPaisDestino, ref System.Windows.Forms.Label lLocalColeta, ref System.Windows.Forms.Label lLocalDespacho, ref System.Windows.Forms.Label lLocalDestino, ref System.Windows.Forms.Label lLocalEmbarque, ref System.Windows.Forms.Label lLocalEntrega)
		{
			try
			{
				carregaStrIncoterm();
				btIncoterm.Text = m_strIncoterm;
				tbLocalColeta.Text = m_strLocalColeta;
				tbLocalDespacho.Text = m_strLocalDespacho;
				tbLocalDestino.Text = m_strLocalDestino;
				tbLocalEmbarque.Text = m_strLocalEmbarque;
				tbLocalEntrega.Text = m_strLocalEntrega;
				gbPaisDestino.Text = m_strPaisDestino;
				habilitaTextBoxesInterface(ref tbLocalColeta, ref tbLocalDespacho, ref tbLocalDestino, ref tbLocalEmbarque, ref tbLocalEntrega, ref lLocalColeta, ref lLocalDespacho, ref lLocalDestino, ref lLocalEmbarque, ref lLocalEntrega);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void habilitaTextBoxesInterface(ref mdlComponentesGraficos.TextBox tbLocalColeta, ref mdlComponentesGraficos.TextBox tbLocalDespacho, ref mdlComponentesGraficos.TextBox tbLocalDestino, ref mdlComponentesGraficos.TextBox tbLocalEmbarque, ref mdlComponentesGraficos.TextBox tbLocalEntrega, ref System.Windows.Forms.Label lLocalColeta, ref System.Windows.Forms.Label lLocalDespacho, ref System.Windows.Forms.Label lLocalDestino, ref System.Windows.Forms.Label lLocalEmbarque, ref System.Windows.Forms.Label lLocalEntrega)
		{
			try
			{
				switch (m_nIdIncoterm)
				{
					case EXW:	
						tbLocalColeta.Enabled = true;
						lLocalColeta.Enabled = true;
						tbLocalEntrega.Enabled = true;
						lLocalEntrega.Enabled = true;
					    break;
					case FAS:
						tbLocalColeta.Enabled = true;
						lLocalColeta.Enabled = true;
						tbLocalEntrega.Enabled = true;
						lLocalEntrega.Enabled = true;
						break;
					case FOB:
						tbLocalColeta.Enabled = true;
						lLocalColeta.Enabled = true;
						tbLocalEntrega.Enabled = true;
						lLocalEntrega.Enabled = true;
						break;
					case FCA:
						tbLocalColeta.Enabled = true;
						lLocalColeta.Enabled = true;
						tbLocalEntrega.Enabled = true;
						lLocalEntrega.Enabled = true;
						break;
					case CFR:
						tbLocalColeta.Enabled = true;
						lLocalColeta.Enabled = true;
						tbLocalEntrega.Enabled = true;
						lLocalEntrega.Enabled = true;
						break;
					case CIF:
						tbLocalColeta.Enabled = true;
						lLocalColeta.Enabled = true;
						tbLocalEntrega.Enabled = true;
						lLocalEntrega.Enabled = true;
						break;
					case CPT:
						tbLocalColeta.Enabled = true;
						lLocalColeta.Enabled = true;
						tbLocalEntrega.Enabled = true;
						lLocalEntrega.Enabled = true;
						break;
					case CIP:
						tbLocalColeta.Enabled = true;
						lLocalColeta.Enabled = true;
						tbLocalEntrega.Enabled = true;
						lLocalEntrega.Enabled = true;
						break;
					case DES:
						tbLocalColeta.Enabled = true;
						lLocalColeta.Enabled = true;
						tbLocalEntrega.Enabled = true;
						lLocalEntrega.Enabled = true;
						break;
					case DEQ:
						tbLocalColeta.Enabled = true;
						lLocalColeta.Enabled = true;
						tbLocalEntrega.Enabled = true;
						lLocalEntrega.Enabled = true;
						break;
					case DAF:
						tbLocalColeta.Enabled = true;
						lLocalColeta.Enabled = true;
						tbLocalEntrega.Enabled = true;
						lLocalEntrega.Enabled = true;
						break;
					case DDU:	
						tbLocalColeta.Enabled = true;
						lLocalColeta.Enabled = true;
						tbLocalEntrega.Enabled = true;
						lLocalEntrega.Enabled = true;
					break;
					case DDP:	
						tbLocalColeta.Enabled = true;
						lLocalColeta.Enabled = true;
						tbLocalEntrega.Enabled = true;
						lLocalEntrega.Enabled = true;
					break;
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
		#region Salvamento dos Dados
		#region Interface
		private void salvaDadosInterface(ref mdlComponentesGraficos.TextBox tbLocalColeta, ref mdlComponentesGraficos.TextBox tbLocalDespacho, ref mdlComponentesGraficos.TextBox tbLocalDestino, ref mdlComponentesGraficos.TextBox tbLocalEmbarque, ref mdlComponentesGraficos.TextBox tbLocalEntrega)
		{
			try
			{
				m_strLocalColeta = tbLocalColeta.Text;
				m_strLocalDespacho = tbLocalDespacho.Text;
				m_strLocalDestino = tbLocalDestino.Text;
				m_strLocalEmbarque = tbLocalEmbarque.Text;
				m_strLocalEntrega = tbLocalEntrega.Text;
				salvaDadosInterfaceEspecifico();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected abstract void salvaDadosInterfaceEspecifico();
		#endregion
		#region Banco de Dados
		protected void salvaDadosBD(bool bModificado)
		{
			try
			{
				m_bModificado = bModificado;
				salvaIncoterm();
				salvaDadosBDEspecifico();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected abstract void salvaDadosBDEspecifico();
		protected abstract void salvaIncoterm();
		#endregion
		#endregion

		#region Local Embarque, Local Despacho
		private void localEmbarqueTextChanged(ref mdlComponentesGraficos.TextBox tbLocalEmbarque, ref mdlComponentesGraficos.TextBox tbLocalDespacho)
		{
			try
			{
				switch (m_nIdIncoterm)
				{
					case EXW:
					case FAS:
					case FOB:
					case CFR:
					case CIF:
					case CPT:
					case DES:
					case DEQ:
					case DDU:
					case DDP:	tbLocalDespacho.Text = tbLocalEmbarque.Text;
					break;
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void localDespachoTextChanged(ref mdlComponentesGraficos.TextBox tbLocalDespacho, ref mdlComponentesGraficos.TextBox tbLocalEmbarque)
		{
			try
			{
				switch (m_nIdIncoterm)
				{
					case EXW:
					case FCA:
					case FAS:
					case FOB:
					case CFR:
					case CIF:
					case CPT:
					case CIP:
					case DAF:
					case DES:
					case DEQ:
					case DDU:
					case DDP:	tbLocalEmbarque.Text = tbLocalDespacho.Text;
					break;
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region RetornaValores
		public abstract Object retornaTypDatSet();
		public void retornaValores(out string strLocalColeta, out string strLocalDespacho, out string strLocalEmbarque, out string strLocalDestino, out string strLocalEntrega, out string strPaisDestino)
		{
			strLocalColeta = m_strLocalColeta;
			strLocalDespacho = m_strLocalDespacho;
			strLocalEmbarque = m_strLocalEmbarque;
			strLocalDestino = m_strLocalDestino;
			strLocalEntrega = m_strLocalEntrega;
			strPaisDestino = m_strPaisDestino;
		}
		#endregion

	}
}
