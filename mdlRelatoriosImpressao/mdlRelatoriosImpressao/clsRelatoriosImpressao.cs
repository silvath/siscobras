using System;

namespace mdlRelatoriosImpressao
{
	/// <summary>
	/// Summary description for clsRelatoriosImpressao.
	/// </summary>
	public class clsRelatoriosImpressao
	{
		#region Atributes
			private mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB = null;
			private mdlTratamentoErro.clsTratamentoErro m_cls_ter_TratadorErro = null;
			private string m_strEnderecoExecutavel = "";
		
			private int m_nIdExportador = -1;
			private string m_strIdCodigo = "";
			mdlConstantes.Relatorio m_enumRelatorio; 
		#endregion
		#region Constructors
			public clsRelatoriosImpressao(ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB,ref mdlTratamentoErro.clsTratamentoErro cls_ter_TratadorErro,string strEnderecoExecutavel,int nIdExportador,string strIdCodigo,mdlConstantes.Relatorio enumRelatorio)
			{
				m_cls_dba_ConnectionDB = cls_dba_ConnectionDB;
				m_cls_ter_TratadorErro = cls_ter_TratadorErro;
				m_strEnderecoExecutavel = strEnderecoExecutavel;

				m_nIdExportador = nIdExportador;
				m_strIdCodigo = strIdCodigo;
				m_enumRelatorio = enumRelatorio;
			}
		#endregion

		#region Imprime
			public mdlRelatoriosBase.frmRelatoriosBase RelatorioBase()
			{
				System.Windows.Forms.Form formFTemp = null;
				mdlRelatoriosBase.frmRelatoriosBase formRelatoriosBase = null;
				switch(m_enumRelatorio)
				{
					case mdlConstantes.Relatorio.FaturaCotacao:
						formRelatoriosBase = new mdlRelatoriosCotacao.frmRelatoriosCotacao(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnectionDB,ref formFTemp,m_strEnderecoExecutavel,m_nIdExportador,m_strIdCodigo);
					break;
					case mdlConstantes.Relatorio.FaturaProforma:
						formRelatoriosBase = new mdlRelatoriosFaturaProforma.frmRelatoriosFaturaProforma(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnectionDB,ref formFTemp,m_strEnderecoExecutavel,m_nIdExportador,m_strIdCodigo);
					break;
					case mdlConstantes.Relatorio.FaturaComercial:
						formRelatoriosBase = new mdlRelatoriosFaturaComercial.frmRelatoriosFaturaComercial(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnectionDB,ref formFTemp,m_strEnderecoExecutavel,m_nIdExportador,m_strIdCodigo);
					break;
					case mdlConstantes.Relatorio.CertificadoOrigemMercosul:
						formRelatoriosBase = new mdlRelatoriosCertificadosOrigem.frmRelatoriosCertificadosOrigem(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnectionDB,ref formFTemp,m_strEnderecoExecutavel,m_nIdExportador,m_strIdCodigo);
						((mdlRelatoriosCertificadosOrigem.frmRelatoriosCertificadosOrigem)formRelatoriosBase).TIPOCERTIFICADO = (int)mdlConstantes.Relatorio.CertificadoOrigemMercosul;
					break;
					case mdlConstantes.Relatorio.CertificadoOrigemMercosulBO:
						formRelatoriosBase = new mdlRelatoriosCertificadosOrigem.frmRelatoriosCertificadosOrigem(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnectionDB,ref formFTemp,m_strEnderecoExecutavel,m_nIdExportador,m_strIdCodigo);
						((mdlRelatoriosCertificadosOrigem.frmRelatoriosCertificadosOrigem)formRelatoriosBase).TIPOCERTIFICADO = (int)mdlConstantes.Relatorio.CertificadoOrigemMercosulBO;
					break;
					case mdlConstantes.Relatorio.CertificadoOrigemMercosulCH:
						formRelatoriosBase = new mdlRelatoriosCertificadosOrigem.frmRelatoriosCertificadosOrigem(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnectionDB,ref formFTemp,m_strEnderecoExecutavel,m_nIdExportador,m_strIdCodigo);
						((mdlRelatoriosCertificadosOrigem.frmRelatoriosCertificadosOrigem)formRelatoriosBase).TIPOCERTIFICADO = (int)mdlConstantes.Relatorio.CertificadoOrigemMercosulCH;
					break;
					case mdlConstantes.Relatorio.CertificadoOrigemAladiAptr04:
						formRelatoriosBase = new mdlRelatoriosCertificadosOrigem.frmRelatoriosCertificadosOrigem(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnectionDB,ref formFTemp,m_strEnderecoExecutavel,m_nIdExportador,m_strIdCodigo);
						((mdlRelatoriosCertificadosOrigem.frmRelatoriosCertificadosOrigem)formRelatoriosBase).TIPOCERTIFICADO = (int)mdlConstantes.Relatorio.CertificadoOrigemAladiAptr04;
					break;
					case mdlConstantes.Relatorio.CertificadoOrigemAladiAce39:
						formRelatoriosBase = new mdlRelatoriosCertificadosOrigem.frmRelatoriosCertificadosOrigem(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnectionDB,ref formFTemp,m_strEnderecoExecutavel,m_nIdExportador,m_strIdCodigo);
						((mdlRelatoriosCertificadosOrigem.frmRelatoriosCertificadosOrigem)formRelatoriosBase).TIPOCERTIFICADO = (int)mdlConstantes.Relatorio.CertificadoOrigemAladiAce39;
					break;
					case mdlConstantes.Relatorio.CertificadoOrigemAnexoIII:
						formRelatoriosBase = new mdlRelatoriosCertificadosOrigem.frmRelatoriosCertificadosOrigem(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnectionDB,ref formFTemp,m_strEnderecoExecutavel,m_nIdExportador,m_strIdCodigo);
						((mdlRelatoriosCertificadosOrigem.frmRelatoriosCertificadosOrigem)formRelatoriosBase).TIPOCERTIFICADO = (int)mdlConstantes.Relatorio.CertificadoOrigemAnexoIII;
					break;
					case mdlConstantes.Relatorio.CertificadoOrigemComum:
						formRelatoriosBase = new mdlRelatoriosCertificadosOrigem.frmRelatoriosCertificadosOrigem(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnectionDB,ref formFTemp,m_strEnderecoExecutavel,m_nIdExportador,m_strIdCodigo);
						((mdlRelatoriosCertificadosOrigem.frmRelatoriosCertificadosOrigem)formRelatoriosBase).TIPOCERTIFICADO = (int)mdlConstantes.Relatorio.CertificadoOrigemComum;
					break;
					case mdlConstantes.Relatorio.Romaneio:
						formRelatoriosBase = new mdlRelatoriosRomaneio.frmRelatoriosRomaneio(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnectionDB,ref formFTemp,m_strEnderecoExecutavel,m_nIdExportador,m_strIdCodigo);
						formRelatoriosBase.TipoRelatorio = (int)mdlConstantes.Relatorio.Romaneio;
					break;
					case mdlConstantes.Relatorio.RomaneioVolumes:
						formRelatoriosBase = new mdlRelatoriosRomaneio.frmRelatoriosRomaneio(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnectionDB,ref formFTemp,m_strEnderecoExecutavel,m_nIdExportador,m_strIdCodigo);
						formRelatoriosBase.TipoRelatorio = (int)mdlConstantes.Relatorio.RomaneioVolumes;
						break;
					case mdlConstantes.Relatorio.RomaneioSimplificado:
						formRelatoriosBase = new mdlRelatoriosRomaneio.frmRelatoriosRomaneio(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnectionDB,ref formFTemp,m_strEnderecoExecutavel,m_nIdExportador,m_strIdCodigo);
						formRelatoriosBase.TipoRelatorio = (int)mdlConstantes.Relatorio.RomaneioSimplificado;
						break;
					case mdlConstantes.Relatorio.Bordero:
						formRelatoriosBase = new mdlRelatoriosBordero.frmRelatoriosBordero(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnectionDB,ref formFTemp,m_strEnderecoExecutavel,m_nIdExportador,m_strIdCodigo);
					break;
					case mdlConstantes.Relatorio.BorderoSecundario:
						formRelatoriosBase = new mdlRelatoriosBordero.frmRelatoriosBordero(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnectionDB,ref formFTemp,m_strEnderecoExecutavel,m_nIdExportador,m_strIdCodigo);
						formRelatoriosBase.TipoRelatorio = (int)mdlConstantes.Relatorio.BorderoSecundario;
						break;
					case mdlConstantes.Relatorio.Saque:
						formRelatoriosBase = new mdlRelatoriosSaque.frmRelatoriosSaque(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnectionDB,ref formFTemp,m_strEnderecoExecutavel,m_nIdExportador,m_strIdCodigo);
					break;
					case mdlConstantes.Relatorio.Reserva:
						formRelatoriosBase = new mdlRelatoriosInstrucaoEmbarque.frmRelatoriosInstrucaoEmbarque(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnectionDB,ref formFTemp,m_strEnderecoExecutavel,m_nIdExportador,m_strIdCodigo);
						formRelatoriosBase.TipoRelatorio = (int)mdlConstantes.Relatorio.Reserva;
						break;
					case mdlConstantes.Relatorio.InstrucaoEmbarque:
						formRelatoriosBase = new mdlRelatoriosInstrucaoEmbarque.frmRelatoriosInstrucaoEmbarque(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnectionDB,ref formFTemp,m_strEnderecoExecutavel,m_nIdExportador,m_strIdCodigo);
					break;
					case mdlConstantes.Relatorio.GuiaEntrada:
						formRelatoriosBase = new mdlRelatoriosInstrucaoEmbarque.frmRelatoriosInstrucaoEmbarque(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnectionDB,ref formFTemp,m_strEnderecoExecutavel,m_nIdExportador,m_strIdCodigo);
						formRelatoriosBase.TipoRelatorio = (int)mdlConstantes.Relatorio.GuiaEntrada;
						break;
					case mdlConstantes.Relatorio.Sumario:
						formRelatoriosBase = new mdlRelatoriosSumario.frmRelatoriosSumario(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnectionDB,ref formFTemp,m_strEnderecoExecutavel,m_nIdExportador,m_strIdCodigo);
					break;
					case mdlConstantes.Relatorio.RelatorioIndefinido:
						formRelatoriosBase = new mdlRelatoriosIndefinido.frmFRelatoriosIndefinido(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnectionDB,ref formFTemp,m_strEnderecoExecutavel,m_nIdExportador,m_strIdCodigo);
					break;
				}
				return(formRelatoriosBase);
			}


			public bool bImprime(bool bShowDialog)
			{
				mdlRelatoriosBase.frmRelatoriosBase frmRelBase = RelatorioBase();
				if (frmRelBase == null)
					return(false);
				return(frmRelBase.bImprimeRelatorio(bShowDialog));
			}
		#endregion
		#region Manipulador
			public ReportCanvasPackage.ReportCanvas ManipuladorGrafico()
			{
				mdlRelatoriosBase.frmRelatoriosBase frmRelBase = RelatorioBase();
				if (frmRelBase == null)
					return(null);
				return(frmRelBase.ManipuladorGrafico);
			}
		#endregion
	}
}
