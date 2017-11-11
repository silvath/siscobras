using System;

namespace Siscobras.Icones
{
	/// <summary>
	/// Summary description for clsManipuladorIcones.
	/// </summary>
	public class clsManipuladorIcones
	{
		private static System.Drawing.Bitmap bmpIcone(string strIcone)
		{
			System.Drawing.Bitmap bmpRetorno = null;
			System.Reflection.Assembly assCurrent = System.Reflection.Assembly.GetExecutingAssembly();
			string[] arrStrAssembly = assCurrent.GetManifestResourceNames();
			foreach(string strCurrent in arrStrAssembly)
			{
				if (strIcone == strCurrent)
				{
					System.IO.Stream stmResource = assCurrent.GetManifestResourceStream(strCurrent);
					bmpRetorno = (System.Drawing.Bitmap)System.Drawing.Image.FromStream(stmResource);
					break;
				}
			}
			return(bmpRetorno);
		}

		public static System.Drawing.Bitmap bmpIconeRelatorio(mdlConstantes.Relatorio enumRelatorio)
		{
			return(bmpIconeRelatorio((int)enumRelatorio));
		}

		public static System.Drawing.Bitmap bmpIconeRelatorio(int nIdRelatorio)
		{
			System.Drawing.Bitmap bmpRetorno = new System.Drawing.Bitmap(16,16);
			switch(nIdRelatorio)
			{
				case (int)mdlConstantes.Relatorio.Bordero:
				case (int)mdlConstantes.Relatorio.BorderoSecundario:
					bmpRetorno = bmpIcone("mdlIcones.Siscobras.Icones.Relatorios.Bordero.ico");
					break;
				case (int)mdlConstantes.Relatorio.CertificadoOrigemAladiAce39:
				case (int)mdlConstantes.Relatorio.CertificadoOrigemAladiAptr04:
				case (int)mdlConstantes.Relatorio.CertificadoOrigemAnexoIII:
				case (int)mdlConstantes.Relatorio.CertificadoOrigemComum:
				case (int)mdlConstantes.Relatorio.CertificadoOrigemMercosul:
				case (int)mdlConstantes.Relatorio.CertificadoOrigemMercosulCH:
				case (int)mdlConstantes.Relatorio.CertificadoOrigemMercosulBO:
					bmpRetorno = bmpIcone("mdlIcones.Siscobras.Icones.Relatorios.CertificadoOrigem.ico");
					break;
				case (int)mdlConstantes.Relatorio.FaturaComercial:
					bmpRetorno = bmpIcone("mdlIcones.Siscobras.Icones.Relatorios.FaturaComercial.ico");
					break;
				case (int)mdlConstantes.Relatorio.FaturaProforma:
					bmpRetorno = bmpIcone("mdlIcones.Siscobras.Icones.Relatorios.FaturaProforma.ico");
					break;
				case (int)mdlConstantes.Relatorio.GuiaEntrada:
					bmpRetorno = bmpIcone("mdlIcones.Siscobras.Icones.Relatorios.InstrucoesEmbarque.ico");
					break;
				case (int)mdlConstantes.Relatorio.InstrucaoEmbarque:
					bmpRetorno = bmpIcone("mdlIcones.Siscobras.Icones.Relatorios.InstrucoesEmbarque.ico");
					break;
				case (int)mdlConstantes.Relatorio.RelatorioIndefinido:
					bmpRetorno = bmpIcone("mdlIcones.Siscobras.Icones.Relatorios.Personalizavel.ico");
					break;
				case (int)mdlConstantes.Relatorio.Reserva:
					bmpRetorno = bmpIcone("mdlIcones.Siscobras.Icones.Relatorios.InstrucoesEmbarque.ico");
					break;
				case (int)mdlConstantes.Relatorio.Romaneio:
				case (int)mdlConstantes.Relatorio.RomaneioSimplificado:
				case (int)mdlConstantes.Relatorio.RomaneioVolumes:
					bmpRetorno = bmpIcone("mdlIcones.Siscobras.Icones.Relatorios.Romaneio.ico");
					break;
				case (int)mdlConstantes.Relatorio.Saque:
					bmpRetorno = bmpIcone("mdlIcones.Siscobras.Icones.Relatorios.Saque.ico");
					break;
				case (int)mdlConstantes.Relatorio.Sumario:
					bmpRetorno = bmpIcone("mdlIcones.Siscobras.Icones.Relatorios.Sumario.ico");
					break;
			}
			return(bmpRetorno);
		}
	}
}
