using System;

namespace mdlMoeda
{
	/// <summary>
	/// Summary description for clsMoedaGeral.
	/// </summary>
	public class clsMoedaGeral : clsMoeda
	{
		#region Atributos
			// ***************************************************************************************************
			// Atributos 
			// ***************************************************************************************************
			// ***************************************************************************************************
		#endregion
		#region Constructor
			public clsMoedaGeral(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string strEnderecoExecutavel) : base(ref tratadorErro, ref ConnectionDB,strEnderecoExecutavel)
			{
   			}
		#endregion

		#region Carrega Dados
			protected override void CarregaMoedaBD()
			{
			}
		#endregion
		#region Salva Dados
			protected override void SalvaMoedaBD()
			{
			}
		#endregion
	}
}
