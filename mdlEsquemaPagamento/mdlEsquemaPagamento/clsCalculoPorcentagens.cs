using System;

namespace mdlEsquemaPagamento
{
	/// <summary>
	/// Summary description for clsCalculoPorcentagens.
	/// </summary>
	public class clsCalculoPorcentagens
	{
		#region Atributos
			private double m_dValorTotal = 0;
			private int m_nCasasDecimaisPorcentagem = 2;
			private System.Collections.ArrayList m_arlNomes = new System.Collections.ArrayList();
			private System.Collections.ArrayList m_arlValores = new System.Collections.ArrayList();
			private System.Collections.ArrayList m_arlPorcentagemExata = new System.Collections.ArrayList();
			private System.Collections.ArrayList m_arlPorcentagem = new System.Collections.ArrayList();
		#endregion
		#region Properties
			public double ValorTotal
			{
				get
				{
					return(m_dValorTotal);
				}
			}

			public double Saldo
			{
				get
				{
					return(dSaldo());
				}
			}

			public int CasasDecimaisPorcentagem
			{
				get
				{
					return(m_nCasasDecimaisPorcentagem);
				}
			}					
		#endregion
		#region Constructors
			public clsCalculoPorcentagens(double dValorTotal)
			{
				m_dValorTotal = dValorTotal;
			}
		#endregion

		#region Saldo
			private double dSaldo()
			{
				double dRetorno = m_dValorTotal;
				for(int i = 0; i < m_arlValores.Count;i++)
					dRetorno -= (double)m_arlValores[i];
				if (dRetorno < 0)
					dRetorno = 0;
				return(dRetorno);
			}
		#endregion
		#region Calculo Porcentagem
			private void vCalculaPorcentagemExata(int nIndex)
			{
				m_arlPorcentagemExata[nIndex] = ((double)m_arlValores[nIndex] / m_dValorTotal) * 100;
			}

			private void vCalculaPorcentagemExata()
			{
				for(int i = 0; i < m_arlNomes.Count;i++)
					vCalculaPorcentagemExata(i);
			}

			private void vCalculaPorcentagem()
			{
				double dTotal = 100;
				for(int i = 0; i < m_arlPorcentagemExata.Count;i++)
				{
					double dAtual = System.Math.Round((double)m_arlPorcentagemExata[i],m_nCasasDecimaisPorcentagem);
					if (i == m_arlPorcentagemExata.Count - 1)
						if (System.Math.Abs(System.Math.Round((dTotal - dAtual),m_nCasasDecimaisPorcentagem)) < 0.01f)
							dAtual = dTotal;  
					dTotal -= dAtual;
					m_arlPorcentagem[i] = dAtual;
				}
			}
		#endregion
		#region Adiciona
			public bool bAdiciona(string strNome,double dValor)
			{
				dValor = System.Math.Round(dValor,4);
				if (dValor == 0)
					return(false);
				if (m_arlNomes.Contains(strNome))
					return(false);
				double dSaldoAtual = dSaldo();
				dSaldoAtual = System.Math.Round(dSaldoAtual,2);
				if (dValor > dSaldoAtual)
					return(false);
				m_arlNomes.Add(strNome);
				m_arlValores.Add(dValor);
				m_arlPorcentagemExata.Add(null);
				vCalculaPorcentagemExata(m_arlPorcentagemExata.Count - 1); 
				m_arlPorcentagem.Add(null);
				vCalculaPorcentagem();
				return(true);
			}

			public bool bAdiciona(string strNome,double dValor,int nQuantidade)
			{
				dValor = System.Math.Round(dValor,4);
				if (dValor == 0)
					return(false);
				if (nQuantidade <= 0)
					return(false);
				double dValorAdicionar = System.Math.Round(dValor / nQuantidade,2);
				for(int i = 0; i < nQuantidade;i++)
					if (i == nQuantidade - 1)
					{
						if (!bAdiciona(strNome + i.ToString(),dValor))
							return(false);
					}else{
						if (!bAdiciona(strNome + i.ToString(),dValorAdicionar))
							return(false);
						else
							dValor = System.Math.Round(dValor - dValorAdicionar,4);
					}
				return(true);
			}
		#endregion
		#region Remove
			public bool bRemove(string strNome)
			{
				if (!m_arlNomes.Contains(strNome))
					return(false);
				int nIndex = m_arlNomes.IndexOf(strNome);
				m_arlNomes.RemoveAt(nIndex);
				m_arlValores.RemoveAt(nIndex);
				m_arlPorcentagemExata.RemoveAt(nIndex);
				m_arlPorcentagem.RemoveAt(nIndex);
				return(true);
			}
		#endregion

		#region Valor
			public double dValor(string strNome)
			{
				if (!m_arlNomes.Contains(strNome))
					return(0);
				return((double)m_arlValores[m_arlNomes.IndexOf(strNome)]);
			}
		#endregion
		#region PorcentagemExata
			public double dPorcentagemExata(string strNome)
			{
				if (!m_arlNomes.Contains(strNome))
					return(0);
				return((double)m_arlPorcentagemExata[m_arlNomes.IndexOf(strNome)]);
			}
		#endregion
		#region Porcentagem
			public double dPorcentagem(string strNome)
			{
				if (!m_arlNomes.Contains(strNome))
					return(0);
				return((double)m_arlPorcentagem[m_arlNomes.IndexOf(strNome)]);
			}
		#endregion
	}
}
