using System;

namespace mdlProdutosLancamento
{
	/// <summary>
	/// Summary description for clsPropriedadeCollection.
	/// </summary>
	public class clsPropriedadeCollection
	{
		#region Atributos
				private System.Collections.ArrayList m_propriedades;
		#endregion
		#region Propriedades
			private System.Collections.ArrayList Propriedades
			{
				get
				{
					if (m_propriedades == null)
						m_propriedades = new System.Collections.ArrayList();
					return(m_propriedades);
				}
			}

			public int Count
			{
				get
				{
					return(this.Propriedades.Count);
				}
			}

			public clsPropriedade this[int index]
			{
				set
				{
					if ((index > 0) && (index < this.Count))
						this.Propriedades[index] = value ;
				}
				get
				{
					if ((index < 0) || (index >= this.Count))
						return(null);
					return(this.Propriedades[index] as clsPropriedade);
				}
			}

			public clsPropriedade this[string descricao]
			{
				get
				{
					for(int i = 0; i < this.Propriedades.Count; i++)
						if (((clsPropriedade)this.Propriedades[i]).Descricao == descricao)
							return ((clsPropriedade)this.Propriedades[i]);
					return(null);
				}
			}
		#endregion
		#region Constructors
			public clsPropriedadeCollection()
			{
			}
		#endregion

		#region Clear
			public void Clear()
			{
				this.Propriedades.Clear();
			}
		#endregion
		#region Add
			public bool Add(int nIdIdioma,int nIdPropriedade,int nIdOrdemProduto,string strDescricao)
			{
				clsPropriedade obj = new clsPropriedade(nIdPropriedade,nIdIdioma,nIdOrdemProduto,strDescricao);
				this.Propriedades.Add(obj);
				return(true);
			}
		#endregion
		#region Remove
			public bool Remove(int index)
			{
				if ((index < 0) || (index >= this.Propriedades.Count))
					return(false);
				this.Propriedades.RemoveAt(index);
				return(true);
			}
		#endregion
		#region Delete
			public bool Delete(int nIdIdioma,int nIdPropriedade,int nIdOrdemProduto)
			{
				for(int i = (this.Count - 1); i >=0 ;i--)
				{
					clsPropriedade obj = this[i];
					if ((obj.IdIdioma == nIdIdioma) && (obj.IdPropriedade == nIdPropriedade) && (obj.IdOrdemProduto == nIdOrdemProduto))
					{
						this.Remove(i);
						return(true);
					}
				}
				return(false);
			}
		#endregion
		#region Get
			public clsPropriedade GetPropriedade(int nIdIdioma,int nIdPropriedade,int nIdOrdemProduto)
			{
				for(int i = 0; i < this.Count;i++)
				{
					clsPropriedade obj = this[i];
					if ((obj.IdIdioma == nIdIdioma) && (obj.IdPropriedade == nIdPropriedade) && (obj.IdOrdemProduto == nIdOrdemProduto))
						return(obj);
				}
				return(null);
			}
		#endregion
	}
}
