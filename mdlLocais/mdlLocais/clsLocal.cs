using System;

namespace mdlLocais
{
	/// <summary>
	/// Summary description for clsLocal.
	/// </summary>
	public abstract class clsLocal
	{
		#region Atributes
			protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConectionDB = null;
			protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
			protected string m_strEnderecoExecutavel = "";

			public bool m_bModificado = false;
		#endregion
		#region Constructors and Destructors
			internal clsLocal(ref mdlTratamentoErro.clsTratamentoErro cls_ter_tratadorErro,ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB, string strEnderecoExecutavel)
			{
				m_cls_dba_ConectionDB = cls_dba_ConnectionDB;
				m_cls_ter_tratadorErro = cls_ter_tratadorErro;
				m_strEnderecoExecutavel = strEnderecoExecutavel;
			}
		#endregion

		#region Carregamento dos Dados
			protected abstract void vCarregaInterface(out string strFormText,out string strGroupboxText);
			protected abstract void vCarregaDados(out string strLocal);
		#endregion
		#region Salvamento dos Dados
			protected abstract bool bSalvaDados(string strLocal);
		#endregion

		#region ShowDialog
			public void ShowDialog()
			{
				Formularios.frmFLocal formFLocal = new mdlLocais.Formularios.frmFLocal(m_strEnderecoExecutavel);
				vInitializeEvents(ref formFLocal);
				formFLocal.ShowDialog();
			}
			
			private void vInitializeEvents(ref Formularios.frmFLocal formFLocal)
			{
				// Carrega Interface
				formFLocal.eCallCarregaInterface += new mdlLocais.Formularios.frmFLocal.delCallCarregaInterface(vCarregaInterface);

				// Carrega Dados 
				formFLocal.eCallCarregaDados += new mdlLocais.Formularios.frmFLocal.delCallCarregaDados(vCarregaDados);

				// Salva Dados 
				formFLocal.eCallSalvaDados += new mdlLocais.Formularios.frmFLocal.delCallSalvaDados(bSalvaDados);
			}
		#endregion

		#region Retorno
			public void vRetornaValores(out string strLocal)
			{
				vCarregaDados(out strLocal);
			}
		#endregion
	}
}
