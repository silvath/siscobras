using System;

namespace mdlNumero.PEs
{
	/// <summary>
	/// Summary description for clsRE.
	/// </summary>
	public class clsRE : clsNumero
	{
		#region Atributos
		private mdlDataBaseAccess.Tabelas.XsdTbPes m_typDatSetTbPEs = null;
		#endregion

		#region Construtores & Destrutores
		public clsRE(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string idPE): base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador)
		{
			m_strIdPE = idPE;
			carregaTypDatSet();
			carregaDadosBD();
			m_bMascaraEditavel = false;
			m_bMascaraPEs = true;
			m_strMascaraPES = "NN/NNNNNNN-NNN";
			m_enumMascara = frmFNumero.MASCARAS.RE;
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

				m_typDatSetTbPEs = m_cls_dba_ConnectionBD.GetTbPes(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
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
				mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwRowTbPEs;
				if (m_typDatSetTbPEs.tbPEs.Rows.Count > 0)
				{
					dtrwRowTbPEs = m_typDatSetTbPEs.tbPEs.FindByidExportadoridPE(m_nIdExportador, m_strIdPE);
					if (dtrwRowTbPEs != null)
					{
						if (!dtrwRowTbPEs.IsmstrRENull())
						{
							m_strNumero = dtrwRowTbPEs.mstrRE.Replace("\0","");
							m_strNumeroNovo = dtrwRowTbPEs.mstrRE.Replace("\0","");
						}
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
		#region Interface
		protected override void carregaDadosInterfaceTextGroupBox(ref System.Windows.Forms.GroupBox gbFields)
		{
			try
			{
				gbFields.Text = "RE";
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
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
		#region Salvamento de Dados
		protected override void salvaDadosBDEspecifico()
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwRowTbPEs;
				if (m_strNumero != m_strNumeroNovo)
				{
					if (m_typDatSetTbPEs.tbPEs.Rows.Count > 0)
					{
						dtrwRowTbPEs = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetTbPEs.tbPEs.Rows[0];
						if (dtrwRowTbPEs != null)
						{
							dtrwRowTbPEs.mstrRE = m_strNumeroNovo;
							dtrwRowTbPEs.mstrDSE = "";
						}

						m_cls_dba_ConnectionBD.SetTbPes(m_typDatSetTbPEs);
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
	}
}
