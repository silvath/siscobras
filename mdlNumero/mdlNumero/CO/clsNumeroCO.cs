using System;

namespace mdlNumero.CO
{
	/// <summary>
	/// Summary description for clsNumeroCO.
	/// </summary>
	public abstract class clsNumeroCO : clsNumero
	{
		#region Atributos
		protected int m_nIdTipoCO = -1;

		private mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem m_typDatSetTbCertificadosOrigem;
		#endregion

		#region Construtores & Destrutores
		public clsNumeroCO(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string strIdPE, int idTipoCO): base(ref tratadorErro, ref ConnectionDB,EnderecoExecutavel,nIdExportador)
		{
			m_nIdTipoCO = idTipoCO;
			m_strIdPE = strIdPE;
			carregaTypDatSet();
			carregaDadosBD();
		}
		#endregion

		#region Carregamento de Dados
		#region Banco de Dados
		protected new void carregaTypDatSet()
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
		protected override void carregaDadosBDEspecificos()
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow dtrwRowTbCertificadosOrigem;
				if (m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.Rows.Count > 0)
				{
					dtrwRowTbCertificadosOrigem = (mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow)m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.Rows[0];
					if (!dtrwRowTbCertificadosOrigem.IsstrNumeroCertificadoOrigemNull())
						m_strNumero = dtrwRowTbCertificadosOrigem.strNumeroCertificadoOrigem.Replace("\0","");
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
		protected override void montaLabelSugestao(ref System.Windows.Forms.Label lSugestao)
		{
			try
			{
				lSugestao.Visible = false;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#endregion
		#region Salvamento dos Dados
		#region Banco de Dados
		protected override void salvaDadosBDEspecifico()
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow dtrwRowTbCertificadosOrigem;
				if (m_strNumero != m_strNumeroNovo)
				{
					if (m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.Rows.Count > 0)
					{
						dtrwRowTbCertificadosOrigem = (mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow)m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.Rows[0];
						if (dtrwRowTbCertificadosOrigem != null)
							dtrwRowTbCertificadosOrigem.strNumeroCertificadoOrigem = m_strNumeroNovo;

						m_cls_dba_ConnectionBD.SetTbCertificadosOrigem(m_typDatSetTbCertificadosOrigem);
					}
				}
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
