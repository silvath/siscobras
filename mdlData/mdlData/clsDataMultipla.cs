using System;

namespace mdlData
{
	/// <summary>
	/// Summary description for clsDataMultipla.
	/// </summary>
	public abstract class clsDataMultipla
	{
		#region Atributos
			protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
			protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionBD = null;
			protected string m_strEnderecoExecutavel = "";

			private string m_strDataMultiplaDefault = null;
			private string m_strDataMultipla = null;
		#endregion
		#region Propriedades
			public string DataMultipla
			{
				get
				{
					if (m_strDataMultipla == null)
						m_strDataMultipla = CarregaDataMultipla();
					return(m_strDataMultipla);
				}
			}
			
			protected string DataMultiplaDefault
			{
				get
				{
					if (m_strDataMultiplaDefault == null)
						m_strDataMultiplaDefault = CarregaDataMultiplaDefault();
					return(m_strDataMultiplaDefault);
				}
			}

			protected string Formato
			{
				get
				{
					return("dd/MMM/yyyy");
				}
			}
		#endregion
		#region Construtores
			public clsDataMultipla(ref mdlTratamentoErro.clsTratamentoErro cls_ter_tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB,string strEnderecoExecutavel)
			{
				m_cls_ter_tratadorErro = cls_ter_tratadorErro;
				m_cls_dba_ConnectionBD = cls_dba_ConnectionDB;
				m_strEnderecoExecutavel = strEnderecoExecutavel;
			}
		#endregion

		#region Carregamento dos Dados
			protected abstract string CarregaDataMultipla();
			protected abstract string CarregaDataMultiplaDefault();
		#endregion
		#region Salvamento dos Dados
			protected abstract bool SalvaDataMultipla(string strDataMultipla);
		#endregion

		#region ShowDialog 
			public bool ShowDialog()
			{
				Formularios.frmFDataMultipla formFDataMultipla = new mdlData.Formularios.frmFDataMultipla(m_strEnderecoExecutavel);
				formFDataMultipla.Personalizada = this.DataMultipla;
				formFDataMultipla.Default = this.DataMultiplaDefault;
				formFDataMultipla.ShowDialog();
				if (formFDataMultipla.Modificado)
				{
					if (this.DataMultipla == formFDataMultipla.Personalizada)
						return(true);
					m_strDataMultipla = formFDataMultipla.Personalizada;
					return(SalvaDataMultipla(this.DataMultipla));
				}
				return(false);
			}
		#endregion
	}
}
