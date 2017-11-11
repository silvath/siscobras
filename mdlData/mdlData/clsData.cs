using System;

namespace mdlData
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public abstract class clsData
	{
		#region Atributos
			protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
			protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionBD = null;
			protected string m_strEnderecoExecutavel = "";

			protected int m_nIdExportador = -1;
			protected string m_strIdPE = "";

			private string m_strName = "Data";

			protected System.DateTime m_dtData;
			protected string m_strFormat = "dd/MM/aaaa";
			protected string m_strDate = "";
			private int m_nIdIdioma = 1;
			private System.Globalization.CultureInfo m_ciIdioma;
			private bool m_bEditFormat = true;
			public bool m_bModificado = false;
		#endregion
		#region Properties
			protected string Name
			{
				set
				{
					m_strName = value;
				}
			}

			protected bool EditFormat
			{
				set
				{
					m_bEditFormat = value; 
				}
			}

			public int Idioma
			{
				set
				{
					m_nIdIdioma = value;
					if ((int)mdlConstantes.Idioma.ChinesSimplificado == m_nIdIdioma)
						m_nIdIdioma = (int)mdlConstantes.Idioma.Ingles;
					m_ciIdioma = mdlIdioma.clsIdioma.ciIdioma(m_nIdIdioma);
				}
			}

			public string Format
			{
				set
				{
					m_strFormat = value;
					bReturnDate(m_dtData,m_strFormat,out m_strDate);
				}
			}

			public System.DateTime Data
			{
				get
				{
					return(m_dtData);
				}
			}
		#endregion
		#region Construtors and Destructors
			public clsData(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador)
			{
				m_cls_ter_tratadorErro = tratadorErro;
				m_cls_dba_ConnectionBD = ConnectionDB;
				m_strEnderecoExecutavel = EnderecoExecutavel;
				m_nIdExportador = nIdExportador;
			}
		#endregion

		#region Carrega Dados
			protected void vCarregaDadosBD()
			{
				try
				{
					carregaDadosBDEspecificos();

					// Idioma
					m_ciIdioma = mdlIdioma.clsIdioma.ciIdioma(m_nIdIdioma);
					if (!bFormatValid(m_strFormat))
						m_strFormat = mdlConstantes.clsConstantes.DATEFORMATDEFAULT;
					bReturnDate(m_dtData,m_strFormat,out m_strDate);

					// Data Null
					if (m_dtData == mdlConstantes.clsConstantes.DATANULA)
						m_strDate = "";
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}		
			protected abstract void carregaDadosBDEspecificos();
		#endregion
		#region Salva Dados
			protected void vSalvaDadosBD()
			{
				salvaDadosBDEspecifico();
			}
			protected abstract void salvaDadosBDEspecifico();
		#endregion
		#region SiscoMensagem
			protected void vSiscoMensagemUpdate()
			{
				mdlControladoraWindowsServices.clsManagerWSSiscoMensagem objSiscoMensagem = new mdlControladoraWindowsServices.clsManagerWSSiscoMensagem(m_strEnderecoExecutavel);
				objSiscoMensagem.vUpdate();
		}
		#endregion

		#region ShowDialog
			public void ShowDialog()
			{
				try
				{
					frmFData formFData = new frmFData(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel, m_bEditFormat);
					int nIdIdiomaSiscobras = mdlIdioma.clsIdioma.nIdioma();
					formFData.ImageIdiom = mdlIdioma.clsIdioma.imBandeira(nIdIdiomaSiscobras);
					if (nIdIdiomaSiscobras == m_nIdIdioma)
					{
						formFData.EnableSecondIdiom = false;
					}else{
						formFData.EnableSecondIdiom = true;
						formFData.ImageIdiomSecondary = mdlIdioma.clsIdioma.imBandeira(m_nIdIdioma);
					}
					vInitializeEvents(ref formFData);
					formFData.ShowDialog();
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}

			private void vInitializeEvents(ref frmFData formFData)
			{
				// Load Interface
				formFData.eCallLoadInterface += new mdlData.frmFData.delCallLoadInterface(formFData_eCallLoadInterface);

				// Show Format
				formFData.eCallShowFormat += new mdlData.frmFData.delCallShowFormat(ShowDialogConfiguracao);

				// Save Interface
				formFData.eCallSaveInterface += new mdlData.frmFData.delCallSaveInterface(formFData_eCallSaveInterface);
			}

			private void formFData_eCallLoadInterface(out DateTime dtDate, out string strFormat,out System.Globalization.CultureInfo ciIdiom, out string strName)
			{
				vReturnConfigurationsProgrammer(out dtDate, out strFormat);
				// Data Null
				if (m_dtData == mdlConstantes.clsConstantes.DATANULA)
					dtDate = new System.DateTime(System.DateTime.Now.Year,System.DateTime.Now.Month,System.DateTime.Now.Day,0,0,0);
				strName = m_strName;
				ciIdiom = m_ciIdioma;
			}

			private bool formFData_eCallSaveInterface(DateTime dtDate)
			{
				m_dtData = dtDate;
				vSalvaDadosBD();
				m_bModificado = true;
				return (true);
			}
		#endregion
		#region ShowDialogConfiguracao
			public bool ShowDialogConfiguracao()
			{
				try
				{
					frmFDataConfiguracao formFDataConfiguracao = new frmFDataConfiguracao(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel);
					vInitializeEvents(ref formFDataConfiguracao);
					formFDataConfiguracao.ShowDialog();
					this.m_bModificado = formFDataConfiguracao.m_bModificado;
					return(formFDataConfiguracao.m_bModificado);
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
					return(false);
				}
			}

			private void vInitializeEvents(ref frmFDataConfiguracao formFDataConfiguracao)
			{
				// Load Interface
				formFDataConfiguracao.eCallLoadInterface += new mdlData.frmFDataConfiguracao.delCallLoadInterface(vReturnConfigurationsUser);

				// Load Date
				formFDataConfiguracao.eCallLoadDate += new mdlData.frmFDataConfiguracao.delCallLoadDate(bReturnDate);

				// Save Interface
				formFDataConfiguracao.eCallSaveInterface += new mdlData.frmFDataConfiguracao.delCallSaveInterface(formFDataConfiguracao_eCallSaveInterface);

			}

			private void vReturnConfigurationsUser(out DateTime dtDate, out string strFormat)
			{
				dtDate = m_dtData;
				strFormat = m_strFormat;
			}

			private void vReturnConfigurationsProgrammer(out DateTime dtDate, out string strFormat)
			{
				dtDate = m_dtData;
				strFormat = m_strFormat.Replace("y","");
				strFormat = strFormat.Replace("a","y");
			}

			private bool formFDataConfiguracao_eCallSaveInterface(string strFormat)
			{
				if (bFormatValid(strFormat))
				{
					m_strFormat = strFormat;
					return(true);
				}else{
					return(false);
				}
			}
		#endregion

		#region Format
			protected bool bFormatValid()
			{
				return(bFormatValid(m_strFormat));
			}

			protected bool bFormatValid(string strFormat)
			{
				try
				{
					m_dtData.ToString(strFormat,m_ciIdioma);
					return(true);
				}catch{
					return(false);
				}
			}

			private bool bReturnDate(DateTime dtDate, string strFormat, out string strDate)
			{
				if (bFormatValid(strFormat))
				{
					strFormat = strFormat.Replace("y","");
					strFormat = strFormat.Replace("a","y");
					strDate = m_dtData.ToString(strFormat,m_ciIdioma);
					return(true);
				}else{
					strDate = "";
					return(false);
				}
			}
		#endregion

		#region Retorna Valores
		public void retornaValores(out string strData)
		{
			strData = m_strDate;
		}
		#endregion
	}
}
