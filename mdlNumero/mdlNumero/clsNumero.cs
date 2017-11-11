using System;

namespace mdlNumero
{
	/// <summary>
	/// Summary description for clsNumero.
	/// </summary>
	public abstract class clsNumero
	{
		#region Atributos
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
		protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionBD = null;
		protected string m_strEnderecoExecutavel = "";

		protected bool m_bPermitirVazio = false;

		protected int m_nIdExportador = -1;
		protected int m_nIdImportador = -1;
		protected int m_nIdPais = -1;
		protected string m_strPais = "";
		protected string m_strIdPE = "";
		protected string m_strNumero = "";
		protected string m_strNumeroNovo = "";
		protected string m_strFormatoNumero = "";
		protected string m_strFormatoNumeroNovo = "";
		protected bool m_bMascaraEditavel = false;
		protected bool m_bMascaraPEs = false;
		protected string m_strMascaraPES = "";
		internal frmFNumero.MASCARAS m_enumMascara;
		private bool m_bFormatoModificado = false;

		protected System.DateTime m_dtData = System.DateTime.Now;

		private frmFNumero m_formFNumero = null;
		private frmFNumeroConfiguracao m_formFNumeroConfiguracao = null;

		protected string m_strDia = "";
		protected string m_strMes = "";
		protected string m_strMesAbreviado = "";
		protected string m_strMesExtenso = "";
		protected string m_strAno = "";
		protected string m_strAleatorio = "";

		public bool m_bModificado = false;

		private int m_nContadorP = 0; // Contador para número de P no formato do número
		private int m_nContadorM = 0; // Contador para número de M no formato do número
		private int m_nContadorD = 0; // Contador para número de D no formato do número
		private int m_nContadorN = 0; // Contador para número de N no formato do número
		private int m_nContadorA = 0; // Contador para número de A no formato do número

		protected mdlDataBaseAccess.Tabelas.XsdTbPaises m_typDatSetTbPaises = null;
		#endregion

		#region Construtores & Destrutores
		public clsNumero(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador)
		{
			m_cls_ter_tratadorErro = tratadorErro;
			m_cls_dba_ConnectionBD = ConnectionDB;
			m_strEnderecoExecutavel = EnderecoExecutavel;
			m_nIdExportador = nIdExportador;
		}
		#endregion

		#region ShowDialog
			public void ShowDialog()
			{
				try
				{
					if ((m_bMascaraPEs) && (m_strMascaraPES.Trim() != ""))
						m_formFNumero = new frmFNumero(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel, m_bMascaraEditavel, m_strMascaraPES, m_enumMascara, m_bPermitirVazio);
					else
						m_formFNumero = new frmFNumero(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel, m_bMascaraEditavel, m_bPermitirVazio);
					vInitializeEvents(ref m_formFNumero);
					m_formFNumero.ShowDialog();
					m_formFNumero = null;
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}

			private void vInitializeEvents(ref frmFNumero formFNumero)
			{
				// Carrega Dados BD
				formFNumero.eCallCarregaDadosBD += new frmFNumero.delCallCarregaDadosBD(carregaDadosBD);

				// Carrega Dados Interface
				formFNumero.eCallCarregaDadosInterface += new frmFNumero.delCallCarregaDadosInterface(carregaDadosInterface);

				// Edita Formato
				formFNumero.eCallEditaFormato += new frmFNumero.delCallEditaFormato(editaFormato);

				// Salva Dados Interface
				formFNumero.eCallSalvaDadosInterface += new frmFNumero.delCallSalvaDadosInterface(salvaDadosInterface);

				// Salva Dados BD
				formFNumero.eCallSalvaDadosBD += new frmFNumero.delCallSalvaDadosBD(salvaDadosBD);
			}
		#endregion
		#region ShowDialogConfiguracao
			public void ShowDialogConfiguracao()
			{
				try
				{
					m_formFNumeroConfiguracao = new frmFNumeroConfiguracao(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel, ref this.m_formFNumero);
					vInitializeEvents(ref m_formFNumeroConfiguracao);
					m_formFNumeroConfiguracao.ShowDialog();
					this.m_bModificado = m_formFNumeroConfiguracao.m_bModificado;
					m_formFNumeroConfiguracao.Dispose();
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
				
			private void vInitializeEvents(ref frmFNumeroConfiguracao formFNumeroConfiguracao)
			{
				// Carrega Labels de Instruções
				formFNumeroConfiguracao.eCallCarregaDadosInterface += new frmFNumeroConfiguracao.delCallCarregaDadosInterface(carregaDadosInterfaceConfiguracao);

				// Manipula Formato Atual
				formFNumeroConfiguracao.eCallManipulaFormato += new frmFNumeroConfiguracao.delCallManipulaFormato(manipulaFormato);

				// Salva Dados Interface
				formFNumeroConfiguracao.eCallSalvaDadosInterface += new frmFNumeroConfiguracao.delCallSalvaDadosInterface(salvaDadosInterfaceConfiguracao);
			}
		#endregion

		#region Edita Formato
		protected bool editaFormato()
		{
			try
			{
				ShowDialogConfiguracao();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
			return m_bModificado;
		}
		#endregion

		#region Delegate Frame Numero Configuracao
		#region Carregamento de Dados
		#region Interface
		protected void carregaDadosInterfaceConfiguracao(ref mdlComponentesGraficos.TextBox ctbFormato, ref mdlComponentesGraficos.TextBox ctbVisualizacao,ref System.Windows.Forms.Label lPais, ref System.Windows.Forms.Label lMesNumero, ref System.Windows.Forms.Label lMesAbreviado, ref System.Windows.Forms.Label lDia, ref System.Windows.Forms.Label lPE, ref System.Windows.Forms.Label lAleatorio, ref System.Windows.Forms.Label lSugestao)
		{
			try
			{
				montaLabelInstrucoes(ref lPais, ref lMesNumero, ref lMesAbreviado, ref lDia, ref lPE, ref lAleatorio);
				ctbFormato.Text = m_strFormatoNumeroNovo;
				ctbVisualizacao.Text = m_strNumeroNovo;
				montaLabelSugestao(ref lSugestao);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected abstract void montaLabelSugestao(ref System.Windows.Forms.Label lSugestao);
		#region Monta Labels Intrucoes
		protected void montaLabelInstrucoes(ref System.Windows.Forms.Label lPais, ref System.Windows.Forms.Label lMesNumero, ref System.Windows.Forms.Label lMesAbreviado, ref System.Windows.Forms.Label lDia, ref System.Windows.Forms.Label lPE, ref System.Windows.Forms.Label lAleatorio)
		{
			if (m_strPais.Length > 3)
                lPais.Text = "PPP - " + m_strPais.Substring(0,3).ToUpper() + " (" + m_strPais + ")";
			else
				lPais.Text = "PPP - BRA (Brazil)";
			if (m_strMes.Length > 1 && m_strMesExtenso.Length > 1)
                lMesNumero.Text = "MM - " + m_strMes + " (" + m_strMesExtenso + ")";
			else
				lMesNumero.Text = "MM - 06 (Junho)";
			if (m_strMesAbreviado.Length > 1 && m_strMesExtenso.Length > 1)
                lMesAbreviado.Text = "MMM - " + m_strMesAbreviado + " (" + m_strMesExtenso + ")";
			else
				lMesAbreviado.Text = "MMM - Jun (Junho)";
			if (m_strDia.Length > 1 && m_strMes.Length > 1 && m_strAno.Length > 1)
                lDia.Text = "DD - " + m_strDia + " (" + m_strDia + "/" + m_strMes + "/" + m_strAno + ")";
			else
				lDia.Text = "DD - 20 (20/06/2003)";
			if (m_strAleatorio.Length > 1)
                lAleatorio.Text = "AAA - " + m_strAleatorio;
			else
				lAleatorio.Text = "AAA - 456";
			montaLabel(ref lPE);
		}
		protected virtual void montaLabel(ref System.Windows.Forms.Label lIdPE){}
		#endregion
		#endregion
		#endregion
		#region Manipula Formato
		protected void manipulaFormato(ref mdlComponentesGraficos.TextBox ctbFormato, ref mdlComponentesGraficos.TextBox ctbVisualizar)
		{
			#region Variáveis
			bool bAspas = false;
			int nTamanhoFormato = 0, nContM = 0, nIndex = 0, nIndexOriginal = 0, nContAspas = 0;
			System.Collections.ArrayList arlIndicesAspas = new System.Collections.ArrayList();
			string strNumeroTemp = ctbFormato.Text;
			#region ContaM e ContaAspas
			while ((nIndex = strNumeroTemp.IndexOf('"')) != -1)
			{
				nIndexOriginal += nIndex;
				strNumeroTemp = strNumeroTemp.Substring(nIndex + 1);
				nContAspas++;
				arlIndicesAspas.Add(nIndexOriginal);
				nIndexOriginal++;
			}
			strNumeroTemp = ctbFormato.Text;
			nIndexOriginal = 0;
			while ((nIndex = strNumeroTemp.IndexOf('M')) != -1)
			{
				nIndexOriginal += nIndex;
				if (!verificaIntervaloAspas(ref arlIndicesAspas, nIndexOriginal))
				{
					strNumeroTemp = strNumeroTemp.Substring(nIndex + 1);
					nContM++;
					nIndexOriginal += nIndex;
				}
				else
				{
					strNumeroTemp = strNumeroTemp.Substring(nIndex + 1);
					nIndexOriginal += nIndex;
				}
			}
			#endregion
			strNumeroTemp = "";
			m_nContadorP = 0;
			m_nContadorM = 0;
			m_nContadorD = 0;
			m_nContadorN = 0;
			m_nContadorA = 0;
			#endregion

			#region While
			while (nTamanhoFormato < ctbFormato.Text.Length)
			{
				switch (ctbFormato.Text.Substring(nTamanhoFormato,1))
				{
					case "P":
					case "p":	if (bAspas)
								{
									strNumeroTemp += ctbFormato.Text.Substring(nTamanhoFormato,1);
								}
								else
								{
									substituiP(ref strNumeroTemp);
								}
						break;
					case "M": 
					case "m":	if (bAspas)
								{
									strNumeroTemp += ctbFormato.Text.Substring(nTamanhoFormato,1);
								}
								else
								{
									if (nContM > 2)
										substituiMExtenso(ref strNumeroTemp);
									else
										substituiMNumero(ref strNumeroTemp);
								}
						break;
					case "D": 
					case "d":	if (bAspas)
								{
									strNumeroTemp += ctbFormato.Text.Substring(nTamanhoFormato,1);
								}
								else
								{
									substituiD(ref strNumeroTemp);
								}
						break;
					case "N": 
					case "n":	if (bAspas)
								{
									strNumeroTemp += ctbFormato.Text.Substring(nTamanhoFormato,1);
								}
								else
								{
										substituiN(ref strNumeroTemp);
								}
						break;
					case "A": 
					case "a":	if (bAspas)
								{
									strNumeroTemp += ctbFormato.Text.Substring(nTamanhoFormato,1);
								}
								else
								{
										substituiA(ref strNumeroTemp);
								}
						break;
					case "\"": bAspas = !bAspas;
						break;
					default :	strNumeroTemp += ctbFormato.Text.Substring(nTamanhoFormato,1);
						break;
				}
				nTamanhoFormato++;
			}
			#endregion
			m_strNumeroNovo = strNumeroTemp;
			ctbVisualizar.Text = m_strNumeroNovo;
			m_strFormatoNumeroNovo = ctbFormato.Text;
		}
		#region Verificar Intervalos Aspas
		private bool verificaIntervaloAspas(ref System.Collections.ArrayList arlAspas, int nIndice)
		{
			try
			{
				int nIterator = 0;
				while((nIterator < arlAspas.Count) && ((nIterator + 1) < arlAspas.Count))
				{
					if (((int)arlAspas[nIterator] < nIndice) && ((int)arlAspas[nIterator + 1] > nIndice))
					{
						return true;
					}
					else
					{
						if ((nIterator + 2) < arlAspas.Count)
						{
							if ((int)arlAspas[nIterator + 2] > nIndice)
							{
								return false;
							}
						}
					}
					nIterator += 2;
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
			return false;
		}
		#endregion
		#region Substitui
		#region P
		private void substituiP(ref string strNumeroTemp)
		{
			if (m_nContadorP < m_strPais.Length)
			{
				strNumeroTemp += m_strPais.Substring(m_nContadorP,1).ToUpper();
				m_nContadorP++;
			}
		}
		#endregion
		#region M Extenso
		private void substituiMExtenso(ref string strNumeroTemp)
		{
			if (m_nContadorM < m_strMesAbreviado.Length)
			{
				strNumeroTemp += m_strMesAbreviado.Substring(m_nContadorM,1).ToUpper();
				m_nContadorM++;
			}
		}
		#endregion
		#region M Numero
		private void substituiMNumero(ref string strNumeroTemp)
		{
			if (m_nContadorM < m_strMes.Length)
			{
				strNumeroTemp += m_strMes.Substring(m_nContadorM,1).ToUpper();
				m_nContadorM++;
			}
		}
		#endregion
		#region D
		private void substituiD(ref string strNumeroTemp)
		{
			if (m_nContadorD < m_strDia.Length)
			{
				strNumeroTemp += m_strDia.Substring(m_nContadorD,1).ToUpper();
				m_nContadorD++;
			}
		}
		#endregion
		#region N
		private void substituiN(ref string strNumeroTemp)
		{
			if (m_nContadorN < m_strIdPE.Length)
			{
				strNumeroTemp += m_strIdPE.Substring(m_nContadorN,1).ToUpper();
				m_nContadorN++;
			}
		}
		#endregion
		#region A
		private void substituiA(ref string strNumeroTemp)
		{
			if (m_nContadorA < m_strAleatorio.Length)
			{
				strNumeroTemp += m_strAleatorio.Substring(m_nContadorA,1).ToUpper();
				m_nContadorA++;
			}
		}
		#endregion
		#endregion
		#endregion
		#region Salvamento de Dados
		#region Interface
		protected void salvaDadosInterfaceConfiguracao(ref mdlComponentesGraficos.TextBox ctbFormato, ref mdlComponentesGraficos.TextBox ctbVisualizar)
		{
			m_strFormatoNumeroNovo = ctbFormato.Text;
			m_strNumeroNovo = ctbVisualizar.Text;
			m_bFormatoModificado = true;
		}
		#endregion
		#endregion
		#endregion

		#region Formato
			public void vAjustaNumeroAcordoFormato()
			{
				mdlComponentesGraficos.TextBox txtFormato = new mdlComponentesGraficos.TextBox();
				mdlComponentesGraficos.TextBox txtVisualizar = new mdlComponentesGraficos.TextBox();
				txtFormato.Text = m_strFormatoNumero;
				manipulaFormato(ref txtFormato,ref txtVisualizar);
				if (txtVisualizar.Text != "")
					m_strNumero = txtVisualizar.Text;
			}
		#endregion

		#region Procedimento para Criar Strings Dia & Mês & Ano & Aleatório
		#region Dia & Mes & Ano
		protected void criaDiaMesAno()
		{
			try
			{
				int dia = 0, mes = 0, ano = 0;
				dia = m_dtData.Day;
				mes = m_dtData.Month;
				ano = m_dtData.Year;
				if (dia < 10)
					m_strDia = "0" + dia.ToString();
				else
					m_strDia = dia.ToString();
				if (mes < 10)
					m_strMes = "0" + mes.ToString();
				else
					m_strMes = mes.ToString();
				m_strAno = ano.ToString();
				criaMesExtenso(mes);
			}
			catch
			{
			}
		}
		private void criaMesExtenso(int mes)
		{
			switch (mes)
			{
				case 1: m_strMesExtenso = "Janeiro";
					m_strMesAbreviado = "jan";
					break;
				case 2: m_strMesExtenso = "Fevereiro";
					m_strMesAbreviado = "fev";
					break;
				case 3: m_strMesExtenso = "Março";
					m_strMesAbreviado = "mar";
					break;
				case 4: m_strMesExtenso = "Abril";
					m_strMesAbreviado = "abr";
					break;
				case 5: m_strMesExtenso = "Maio";
					m_strMesAbreviado = "mai";
					break;
				case 6: m_strMesExtenso = "Junho";
					m_strMesAbreviado = "jun";
					break;
				case 7: m_strMesExtenso = "Julho";
					m_strMesAbreviado = "jul";
					break;
				case 8: m_strMesExtenso = "Agosto";
					m_strMesAbreviado = "ago";
					break;
				case 9: m_strMesExtenso = "Setembro";
					m_strMesAbreviado = "set";
					break;
				case 10:m_strMesExtenso = "Outubro";
					m_strMesAbreviado = "out"; 
					break;
				case 11:m_strMesExtenso = "Novembro";
					m_strMesAbreviado = "nov"; 
					break;
				case 12:m_strMesExtenso = "Dezembro";
					m_strMesAbreviado = "dez"; 
					break;
			}
		}
		#endregion
		#region Aleatório
		protected void criaAleatorio()
		{
			try
			{
				Random rand = new Random();
				int aleatorio = rand.Next(1,999);
				if (aleatorio < 10)
					m_strAleatorio = "00" + aleatorio.ToString();
				else if (aleatorio < 100)
					m_strAleatorio = "0" + aleatorio.ToString();
				else
					m_strAleatorio = aleatorio.ToString();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#endregion

		#region Delegate Frame Numero
		#region Carregamento de Dados
		#region Banco de Dados
		protected void carregaTypDatSet()
		{
			System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
			
			arlCondicaoCampo.Add("idPais");
			arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicaoValor.Add(m_nIdPais);

			m_cls_dba_ConnectionBD.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
			m_typDatSetTbPaises = m_cls_dba_ConnectionBD.GetTbPaises(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
			m_cls_dba_ConnectionBD.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
		}
		public void carregaDadosBD()
		{
			try
			{
				carregaDadosBDEspecificos();
				if (m_nIdPais >= 0)
					carregaDadosBDPaises();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void carregaDadosBDPaises()
		{
			mdlDataBaseAccess.Tabelas.XsdTbPaises.tbPaisesRow dtrwRowTbPaises;
			if (m_typDatSetTbPaises.tbPaises.Rows.Count > 0)
			{
				dtrwRowTbPaises = m_typDatSetTbPaises.tbPaises.FindByidPais(m_nIdPais);
				if(dtrwRowTbPaises != null)
					m_strPais = dtrwRowTbPaises.nmPais;
			}
		}
		protected abstract void carregaDadosBDEspecificos();
		#endregion
		#region Interface
		protected void carregaDadosInterface(ref mdlComponentesGraficos.TextBox ctbNumero, ref System.Windows.Forms.GroupBox gbFields)
		{
			try
			{
				if (((m_strNumero.Replace("\0","").Trim() == "") && (m_strFormatoNumero.Replace("\0","").Trim() != "")) && (m_bFormatoModificado == false))
				{
					manipulaFormato(m_strFormatoNumero);
					ctbNumero.Text = m_strNumeroNovo;
				}
				else if (m_bFormatoModificado)
				{
					ctbNumero.Text = m_strNumeroNovo;
					m_bFormatoModificado = false;
				}
				else if ((m_strNumero.Replace("\0","").Trim() == "") && (m_strFormatoNumero.Replace("\0","").Trim() == ""))
				{
					ctbNumero.Text = m_strNumeroNovo;
					m_bFormatoModificado = false;
				}
				else
				{
					ctbNumero.Text = m_strNumero;
				}
				carregaDadosInterfaceTextGroupBox(ref gbFields);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected abstract void carregaDadosInterfaceTextGroupBox(ref System.Windows.Forms.GroupBox gbFields);
		#endregion
		#endregion
		#region Manipulação pra caso especial
		protected void manipulaFormato(string strFormato)
		{
			#region Variáveis
			bool bAspas = false;
			int nTamanhoFormato = 0, nContM = 0, nIndex = 0, nIndexOriginal = 0, nContAspas = 0;
			System.Collections.ArrayList arlIndicesAspas = new System.Collections.ArrayList();
			string strNumeroTemp = strFormato;
			#region ContaM e ContaAspas
			while ((nIndex = strNumeroTemp.IndexOf('"')) != -1)
			{
				nIndexOriginal += nIndex;
				strNumeroTemp = strNumeroTemp.Substring(nIndex + 1);
				nContAspas++;
				arlIndicesAspas.Add(nIndexOriginal);
				nIndexOriginal++;
			}
			strNumeroTemp = strFormato;
			nIndexOriginal = 0;
			while ((nIndex = strNumeroTemp.IndexOf('M')) != -1)
			{
				nIndexOriginal += nIndex;
				if (!verificaIntervaloAspas(ref arlIndicesAspas, nIndexOriginal))
				{
					strNumeroTemp = strNumeroTemp.Substring(nIndex + 1);
					nContM++;
					nIndexOriginal += nIndex;
				}
				else
				{
					strNumeroTemp = strNumeroTemp.Substring(nIndex + 1);
					nIndexOriginal += nIndex;
				}
			}
			#endregion
			strNumeroTemp = "";
			m_nContadorP = 0;
			m_nContadorM = 0;
			m_nContadorD = 0;
			m_nContadorN = 0;
			m_nContadorA = 0;
			#endregion

			#region While
			while (nTamanhoFormato < strFormato.Length)
			{
				switch (strFormato.Substring(nTamanhoFormato,1))
				{
					case "P":
					case "p":	if (bAspas)
								{
									strNumeroTemp += strFormato.Substring(nTamanhoFormato,1);
								}
								else
								{
									substituiP(ref strNumeroTemp);
								}
						break;
					case "M": 
					case "m":	if (bAspas)
								{
									strNumeroTemp += strFormato.Substring(nTamanhoFormato,1);
								}
								else
								{
									if (nContM > 2)
										substituiMExtenso(ref strNumeroTemp);
									else
										substituiMNumero(ref strNumeroTemp);
								}
						break;
					case "D": 
					case "d":	if (bAspas)
								{
									strNumeroTemp += strFormato.Substring(nTamanhoFormato,1);
								}
								else
								{
									substituiD(ref strNumeroTemp);
								}
						break;
					case "N": 
					case "n":	if (bAspas)
								{
									strNumeroTemp += strFormato.Substring(nTamanhoFormato,1);
								}
								else
								{
									substituiN(ref strNumeroTemp);
								}
						break;
					case "A": 
					case "a":	if (bAspas)
								{
									strNumeroTemp += strFormato.Substring(nTamanhoFormato,1);
								}
								else
								{
									substituiA(ref strNumeroTemp);
								}
						break;
					case "\"": bAspas = !bAspas;
						break;
					default :	strNumeroTemp += strFormato.Substring(nTamanhoFormato,1);
						break;
				}
				nTamanhoFormato++;
			}
			#endregion
			m_strNumeroNovo = strNumeroTemp;
			m_strFormatoNumeroNovo = strFormato;
		}
		#endregion
		#region Salvamento de Dados
		#region Interface
		protected void salvaDadosInterface(ref mdlComponentesGraficos.TextBox ctbNumeroFatura)
		{
			try
			{
				m_strNumeroNovo = ctbNumeroFatura.Text;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Banco de Dados
		protected void salvaDadosBD(bool bModificado)
		{
			try
			{
				this.m_bModificado = bModificado;
				salvaDadosBDEspecifico();
				m_strFormatoNumero = m_strFormatoNumeroNovo;
				m_strNumero = m_strNumeroNovo;
			}catch (Exception err){
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		protected abstract void salvaDadosBDEspecifico();
		#endregion
		#endregion
		#endregion

		#region Retorna Valores
		public void retornaValores(out string strNumero)
		{
			strNumero = m_strNumero;
		}
		#endregion

		#region Salva Direto Sem Mostrar Frame
		public void salvaDiretoSemMostrarInterface()
		{
			try
			{
				if (((m_strNumero.Replace("\0","").Trim() == "") && (m_strFormatoNumero.Replace("\0","").Trim() != "")))
				{
					manipulaFormato(m_strFormatoNumero);
					salvaDadosBD(true);
				}
				else if (m_strNumero.Replace("\0","").Trim() != "")
				{
					m_strNumeroNovo = m_strNumero;
					m_strNumero = "";
					salvaDadosBD(true);
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
