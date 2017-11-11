using System;

namespace mdlCriacaoDocumentos.Assistentes
{
	/// <summary>
	/// Summary description for clsAssistenteItem.
	/// </summary>
	public class clsAssistenteItem
	{
		#region Delegates
			public delegate bool delCallPreenchido();
			public delegate bool delCallShowDialog();
		#endregion
		#region Events
			public event delCallPreenchido eCallPreenchido;	
			public event delCallShowDialog eCallShowDialog;	
		#endregion
		#region Events Methods
			public bool OnCallPreenchido()
			{
				if (eCallPreenchido != null)
					return(eCallPreenchido());
				else
					return(false);
			}

			public bool OnCallShowDialog()
			{
				if (eCallShowDialog != null)
					return(eCallShowDialog());
				else
					return(false);
			}
		#endregion

		#region Atributos
				private string m_strNome = "";
		#endregion
		#region Propriedades
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
		#endregion

		#region Contructors and Destructors
			public clsAssistenteItem()
			{
			}
		#endregion
	}
}
