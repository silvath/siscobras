using System;

namespace mdlProdutosLancamento
{
	/// <summary>
	/// Summary description for clsColuna.
	/// </summary>
	internal class clsColuna
	{
		#region Atributos
			// ************************************
			// Atributos 
			// ************************************
			private string m_strNome;
			private int m_nPosicao;
			private int m_nTamanho;
			private mdlProdutosLancamento.AlinhamentoHorizontal m_enumAlinhamento;
			private bool m_bSistema;
			private bool m_bReadOnly;
			private bool m_bIsNumeric;
			private clsManipuladorColunas.DataGridColumnStyle m_enumDataGridColumnStyle;
			// ************************************
		#endregion
		#region Properties
                
			public string Nome
			{
				set
				{
					m_strNome = value;
				}
				get
				{
					return(m_strNome);
				}
			}

			public int Posicao
			{
				set
				{
					m_nPosicao = value;
				}
				get
				{
					return(m_nPosicao);
				}
			}

			public int Tamanho
			{
				set
				{
					m_nTamanho = value;
				}
				get
				{
					return(m_nTamanho);
				}
			}

			public bool Sistema
			{
				get
				{
					return(m_bSistema);
				}
			}

			public bool IsNumeric
			{
				get
				{
					return(m_bIsNumeric);
				}
			}

			public bool Inutilizada
			{
				get
				{
					return(m_nPosicao == 0);
				}
			}

			public bool ReadOnly
			{
				get
				{
					return(m_bReadOnly); 
				}
			}

			public mdlProdutosLancamento.AlinhamentoHorizontal Alinhamento
			{
				get
				{
					return(m_enumAlinhamento);
				}
			}
						
			internal clsManipuladorColunas.DataGridColumnStyle ColumnStyle
			{
				get
				{
					return(m_enumDataGridColumnStyle);
				}
			}
		#endregion
		#region Constructor
			public clsColuna(string strNome,int nPosicao,int nTamanho, mdlProdutosLancamento.AlinhamentoHorizontal enumAlinhamento,bool bReadOnly,bool bSistema,bool bIsNumeric,clsManipuladorColunas.DataGridColumnStyle enumDataGridColumnStyle)
			{
				m_strNome = strNome;
				m_nPosicao = nPosicao;
				m_nTamanho = nTamanho;
				m_enumAlinhamento = enumAlinhamento;
				m_bReadOnly = bReadOnly;
				m_bSistema = bSistema;
				m_bIsNumeric = bIsNumeric;
				m_enumDataGridColumnStyle = enumDataGridColumnStyle;
			}
		#endregion
	}
}
