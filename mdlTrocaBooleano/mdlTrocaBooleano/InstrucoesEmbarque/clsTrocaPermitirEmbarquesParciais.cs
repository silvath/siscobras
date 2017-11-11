using System;

namespace mdlTrocaBooleano.InstrucoesEmbarque
{
	/// <summary>
	/// Summary description for clsTrocaPermitirEmbarquesParciais.
	/// </summary>
	public class clsTrocaPermitirEmbarquesParciais : clsTrocaBooleano
	{
		#region Atributos
		private int m_nIdExportador = -1;
		private string m_strIdPE = "";

		private mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque m_typDatSetTbInstrucoesEmbarque = null;
		#endregion

		#region Construtores & Destrutores
		public clsTrocaPermitirEmbarquesParciais(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB, string EnderecoExecutavel, int idExportador, string strIdPE) : base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel)
		{
			m_bValorBooleano = true;
			m_nIdExportador = idExportador;
			m_strIdPE = strIdPE;
			this.carregaTypDatSet();
			this.carregaDadosBD();
		}
		#endregion

		#region Carregamento dos Dados
		protected override void carregaTypDatSet()
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

				m_typDatSetTbInstrucoesEmbarque = m_cls_dba_ConnectionDB.GetTbInstrucoesEmbarque(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected override void carregaDadosBD()
		{
			try
			{
				if (m_typDatSetTbInstrucoesEmbarque != null)
				{
					if (m_typDatSetTbInstrucoesEmbarque.tbInstrucoesEmbarque.Rows.Count > 0)
					{
						mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque.tbInstrucoesEmbarqueRow dtrwTbInstrucoesEmbarque = (mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque.tbInstrucoesEmbarqueRow)m_typDatSetTbInstrucoesEmbarque.tbInstrucoesEmbarque.Rows[0];
						if (!dtrwTbInstrucoesEmbarque.IsbPermitirEmbarquesParciaisNull())
							m_bValorBooleano = dtrwTbInstrucoesEmbarque.bPermitirEmbarquesParciais;
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

		#region Salvamento dos Dados
		protected override void salvaDadosBDEspecificos()
		{
			try
			{
				if (m_typDatSetTbInstrucoesEmbarque != null)
				{
					if (m_typDatSetTbInstrucoesEmbarque.tbInstrucoesEmbarque.Rows.Count > 0)
					{
						mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque.tbInstrucoesEmbarqueRow dtrwTbInstrucoesEmbarque = (mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque.tbInstrucoesEmbarqueRow)m_typDatSetTbInstrucoesEmbarque.tbInstrucoesEmbarque.Rows[0];
						if (!dtrwTbInstrucoesEmbarque.IsbPermitirEmbarquesParciaisNull())
							dtrwTbInstrucoesEmbarque.bPermitirEmbarquesParciais = m_bValorBooleano;
					}
					m_cls_dba_ConnectionDB.SetTbInstrucoesEmbarque(m_typDatSetTbInstrucoesEmbarque);
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
