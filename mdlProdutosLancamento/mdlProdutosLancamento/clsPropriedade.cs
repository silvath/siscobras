using System;

namespace mdlProdutosLancamento
{
	/// <summary>
	/// Summary description for clsPropriedade.
	/// </summary>
	public class clsPropriedade
	{
		#region Atributes
			private int m_nIdPropriedade = -1;
			private int m_nIdIdioma = -1;
			private int m_nIdOrdemProduto = -1;
			private string m_strDescricao = "";
		#endregion
		#region Properties
			public int IdPropriedade
			{
				set
				{
					m_nIdPropriedade = value;
				}
				get
				{
					return(m_nIdPropriedade);
				}
			}

			public int IdOrdemProduto
			{
				set
				{
					m_nIdOrdemProduto = value;
				}
				get
				{
					return(m_nIdOrdemProduto);
				}
			}

			public int IdIdioma
			{
				get
				{
					return(m_nIdIdioma);
				}
			}

			public string Descricao
			{
				set
				{
					m_strDescricao = value;
				}
				get
				{
					return(m_strDescricao);
				}
			}
		#endregion
		#region Constructors
			public clsPropriedade(int nIdPropriedade,int nIdIdioma,int nIdOrdemProduto,string strDescricao)
			{
				m_nIdPropriedade = nIdPropriedade;
				m_nIdIdioma = nIdIdioma;
				m_nIdOrdemProduto = nIdOrdemProduto;
				m_strDescricao = strDescricao;
			}
		#endregion
	}
}
