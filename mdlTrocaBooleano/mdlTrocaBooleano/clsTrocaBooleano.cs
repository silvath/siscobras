using System;

namespace mdlTrocaBooleano
{
	/// <summary>
	/// Summary description for clsTrocaBooleano.
	/// </summary>
	public abstract class clsTrocaBooleano
	{
		#region Atributos
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
		protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB;
		protected string m_strEnderecoExecutavel;

		protected bool m_bValorBooleano = false;
		#endregion

		#region Construtores & Destrutores
		public clsTrocaBooleano(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB, string EnderecoExecutavel)
		{
			m_cls_ter_tratadorErro = tratadorErro;
			m_cls_dba_ConnectionDB = ConnectionDB;
			m_strEnderecoExecutavel = EnderecoExecutavel;
		}
		#endregion

		#region Carregamento dos Dados
		protected abstract void carregaTypDatSet();
		protected abstract void carregaDadosBD();
		#endregion

		#region Salvamento dos Dados
		protected void salvaDadosBD()
		{
			try
			{
				m_bValorBooleano = !m_bValorBooleano;
				salvaDadosBDEspecificos();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected abstract void salvaDadosBDEspecificos();
		public void trocaValor()
		{
			salvaDadosBD();
		}
		public void setaValor(bool bValor)
		{
			try
			{
				m_bValorBooleano = bValor;
				salvaDadosBDEspecificos();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Retorna Valores
		public void retornaValores(out bool bValorBooleano)
		{
			bValorBooleano = m_bValorBooleano;
		}
		#endregion
	}
}
