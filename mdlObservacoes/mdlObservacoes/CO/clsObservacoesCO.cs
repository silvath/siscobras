using System;

namespace mdlObservacoes.CO
{
	/// <summary>
	/// Summary description for clsObservacoesCO.
	/// </summary>
	public abstract class clsObservacoesCO : clsObservacoes
	{
		#region Atributos
		private string m_strIdPE = "";
		protected int m_nIdTipoCO = -1;

		private mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem m_typDatSetTbCertificadosOrigem;
		#endregion

		#region Construtores & Destrutores
		public clsObservacoesCO(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string strIdPE, int idTipoCO): base(ref tratadorErro, ref ConnectionDB,EnderecoExecutavel,nIdExportador)
		{
			m_nIdTipoCO = idTipoCO;
			m_strIdPE = strIdPE;
			carregaTypDatSet();
			carregaDadosBD();
		}
		#endregion

		#region Carregamento de Dados
		#region Banco de Dados
		protected void carregaTypDatSet()
		{
			try 
			{
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
			
				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("idPE");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdPE);

				arlCondicaoCampo.Add("nIdTipoCO");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdTipoCO);

				m_typDatSetTbCertificadosOrigem = m_cls_dba_ConnectionBD.GetTbCertificadosOrigem(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected override void carregaDadosBDEspecifico()
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow dtrwRowTbCertificadosOrigem;
				if (m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.Rows.Count > 0)
				{
					dtrwRowTbCertificadosOrigem = (mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow)m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.Rows[0];
					if (!dtrwRowTbCertificadosOrigem.IsmstrObsCONull())
						m_strObservacoes = dtrwRowTbCertificadosOrigem.mstrObsCO;
				}
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Interface
//		protected override void carregaDadosInterfaceGroupBoxText(ref System.Windows.Forms.GroupBox gbFields)
//		{
//			try
//			{
//				gbFields.Text = "Observações da Fatura Cotação";
//			}
//			catch (Exception err)
//			{
//				Object erro = err;
//				m_cls_ter_tratadorErro.trataErro(ref erro);
//			}
//		}
		#endregion
		#endregion
		#region Salvamento dos Dados
		#region Banco de Dados
		protected override void salvaDadosBDEspecifico()
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow dtrwRowTbCertificadosOrigem;
				if (m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.Rows.Count > 0)
				{
					dtrwRowTbCertificadosOrigem = (mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow)m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.Rows[0];
					if (dtrwRowTbCertificadosOrigem != null)
						dtrwRowTbCertificadosOrigem.mstrObsCO = m_strObservacoes;
				}
				m_cls_dba_ConnectionBD.SetTbCertificadosOrigem(m_typDatSetTbCertificadosOrigem);
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#endregion
	}
}
