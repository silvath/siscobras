using System;

namespace mdlPaletaDeCores
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class clsPaletaDeCores
	{
		#region Constantes
			const int RED_PADRAO_PRIMARIA = 220;
			const int GREEN_PADRAO_PRIMARIA = 240;
			const int BLUE_PADRAO_PRIMARIA = 220;

			const int RED_PADRAO_SECUNDARIA = 220;
			const int GREEN_PADRAO_SECUNDARIA = 240;
			const int BLUE_PADRAO_SECUNDARIA = 220;

			const string TEXTO_CORES_SECUNDARIAS = "CORESSECUNDARIAS";
		#endregion
		#region Atributos
		private string m_strSessao = "";
		private string m_strArquivoConfiguracao = "";
		private bool m_bApenasRetornaCor = false;

		private bool m_bComCorPadrao = false;

		private System.Drawing.Color m_clCorAtual;
		public System.Drawing.Color COR
		{
			set
			{
				m_clCorAtual = value;
				if (!m_bApenasRetornaCor)
					salvaCorArquivoConfiguracao(m_strSessao, m_clCorAtual);
			}
		}

		private System.Windows.Forms.ColorDialog m_cldgPaletaDeCores = null;
		#endregion

		#region Construtores & Destrutores
		public clsPaletaDeCores(System.Drawing.Color clCor)
		{
			m_clCorAtual = clCor;
			m_bApenasRetornaCor = true;
			m_cldgPaletaDeCores = new System.Windows.Forms.ColorDialog();
			m_cldgPaletaDeCores.FullOpen = true;
		}
		public clsPaletaDeCores(string strArquivoConfiguracao, string strSessao)
		{
			m_strArquivoConfiguracao = strArquivoConfiguracao;
			m_strSessao = strSessao;
			m_cldgPaletaDeCores = new System.Windows.Forms.ColorDialog();
			m_cldgPaletaDeCores.FullOpen = true;
		}
		public clsPaletaDeCores(string strArquivoConfiguracao, string strSessao, System.Drawing.Color clCor)
		{
			m_bComCorPadrao = true;
			m_clCorAtual = clCor;
			m_strArquivoConfiguracao = strArquivoConfiguracao;
			m_strSessao = strSessao;
			m_cldgPaletaDeCores = new System.Windows.Forms.ColorDialog();
			m_cldgPaletaDeCores.FullOpen = true;
		}
		#endregion

		#region Troca Cor
		public void mostraCorAtual()
		{
			System.Drawing.Color clCor;
			if (m_bApenasRetornaCor)
				clCor = m_clCorAtual;
			else
				clCor = carregaCorArquivoConfiguracao(m_strSessao);
            m_cldgPaletaDeCores.Color = clCor;
			if (m_cldgPaletaDeCores.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				colocaCorAtual(m_cldgPaletaDeCores.Color);
		}
		private void colocaCorAtual(System.Drawing.Color clCor)
		{
			try
			{
				if (m_bApenasRetornaCor)
					m_clCorAtual = clCor;
				else
					salvaCorArquivoConfiguracao(m_strSessao, clCor);
			}
			catch (Exception err)
			{
				Object erro = err;
			}
		}
		#endregion

		#region Retorno
		public System.Drawing.Color retornaCorAtual()
		{
			try
			{
				if (m_bApenasRetornaCor)
					return m_cldgPaletaDeCores.Color;
				else
					return this.carregaCorArquivoConfiguracao(m_strSessao);
			}
			catch (Exception err)
			{
				Object erro = err;
			}
			return System.Drawing.Color.LightBlue;

		}
		#endregion

		#region Carregar
		private System.Drawing.Color carregaCorArquivoConfiguracao(string strSessao)
		{
			try
			{
				string strValorRGBRetorno = "";
				int nRed = RED_PADRAO_PRIMARIA, nGreen = GREEN_PADRAO_PRIMARIA, nBlue = BLUE_PADRAO_PRIMARIA, nValorTemp = -1;
				if (strSessao.ToUpper() == TEXTO_CORES_SECUNDARIAS)
				{
					nRed = RED_PADRAO_SECUNDARIA;
					nGreen = GREEN_PADRAO_SECUNDARIA;
					nBlue = BLUE_PADRAO_SECUNDARIA;
				}
				if (m_bComCorPadrao)
				{
					nRed = Int32.Parse(m_clCorAtual.R.ToString());
					nGreen = Int32.Parse(m_clCorAtual.G.ToString());
					nBlue = Int32.Parse(m_clCorAtual.B.ToString());
				}
				mdlManipuladorArquivo.clsManipuladorArquivoIni clsmaManipuladorDeArquivo = new mdlManipuladorArquivo.clsManipuladorArquivoIni(m_strArquivoConfiguracao);
                
				strValorRGBRetorno = clsmaManipuladorDeArquivo.retornaValor(strSessao, "red", nRed.ToString());
				if (strValorRGBRetorno.Trim() != "")
				{
					nValorTemp = Int32.Parse(strValorRGBRetorno);
					if (nValorTemp >= 0 && nValorTemp <= 256)
						nRed = nValorTemp;
				}

				strValorRGBRetorno = clsmaManipuladorDeArquivo.retornaValor(strSessao, "green", nGreen.ToString());
				if (strValorRGBRetorno.Trim() != "")
				{
					nValorTemp = Int32.Parse(strValorRGBRetorno);
					if (nValorTemp >= 0 && nValorTemp <= 256)
						nGreen = nValorTemp;
				}

				strValorRGBRetorno = clsmaManipuladorDeArquivo.retornaValor(strSessao, "blue", nBlue.ToString());
				if (strValorRGBRetorno.Trim() != "")
				{
					nValorTemp = Int32.Parse(strValorRGBRetorno);
					if (nValorTemp >= 0 && nValorTemp <= 256)
						nBlue = nValorTemp;
				}
				if (nRed == 0 && nGreen == 0 && nBlue == 0)
				{
					if (strSessao.ToUpper() == TEXTO_CORES_SECUNDARIAS)
					{
						nRed = RED_PADRAO_SECUNDARIA;
						nGreen = GREEN_PADRAO_SECUNDARIA;
						nBlue = BLUE_PADRAO_SECUNDARIA;
					}else{
						nRed = RED_PADRAO_PRIMARIA;
						nGreen = GREEN_PADRAO_PRIMARIA;
						nBlue = BLUE_PADRAO_PRIMARIA;
					}
				}
				return System.Drawing.Color.FromArgb(nRed, nGreen, nBlue);
			}
			catch (Exception err)
			{
				Object erro = err;
			}

			return System.Drawing.Color.Blue;
		}
		#endregion

		#region Salvar
		private bool salvaCorArquivoConfiguracao(string strSessao, System.Drawing.Color clCor)
		{
			try
			{
				mdlManipuladorArquivo.clsManipuladorArquivoIni clsmaManipuladorDeArquivo = new mdlManipuladorArquivo.clsManipuladorArquivoIni(m_strArquivoConfiguracao);
				if (clsmaManipuladorDeArquivo.colocaValor(strSessao, "red", clCor.R.ToString()))
					if (clsmaManipuladorDeArquivo.colocaValor(strSessao, "green", clCor.G.ToString()))
						if (clsmaManipuladorDeArquivo.colocaValor(strSessao, "blue", clCor.B.ToString()))
							return true;
			}
			catch (Exception err)
			{
				Object erro = err;
			}
			return false;
		}
		#endregion
	}
}
