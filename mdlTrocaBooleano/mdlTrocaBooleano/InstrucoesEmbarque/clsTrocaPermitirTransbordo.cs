using System;

namespace mdlTrocaBooleano.InstrucoesEmbarque
{
	/// <summary>
	/// Summary description for clsTrocaPermitirTransbordo.
	/// </summary>
	public class clsTrocaPermitirTransbordo : clsTrocaBooleano
	{
		#region Atributos
			private int m_nIdExportador = -1;
			private string m_strIdPE = "";
		#endregion

		#region Construtors and Destrutors
			public clsTrocaPermitirTransbordo(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB, string EnderecoExecutavel, int idExportador, string strIdPE) : base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel)
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
		}

		private mdlDataBaseAccess.Tabelas.XsdTbPes GetTypDatSetPes()
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

			return(m_cls_dba_ConnectionDB.GetTbPes(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null));
		}

		private mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque GetTypDatSetInstrucoesEmbarque()
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

			return(m_cls_dba_ConnectionDB.GetTbInstrucoesEmbarque(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null));
		}

		protected override void carregaDadosBD()
		{
			mdlDataBaseAccess.Tabelas.XsdTbPes typDatSetPes = GetTypDatSetPes();
			if (typDatSetPes.tbPEs.Rows.Count > 0)
			{
				mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwPe = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)typDatSetPes.tbPEs.Rows[0];
				if (!dtrwPe.IsbTransbordoNull())
				{
					m_bValorBooleano = dtrwPe.bTransbordo;
					if (!dtrwPe.IsmstrLocalTransbordoNull() && (dtrwPe.mstrLocalTransbordo.Trim() != ""))
						m_bValorBooleano = true;
				}
				else
				{
					mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque typDatSetInstrucoesEmbarque = GetTypDatSetInstrucoesEmbarque();
					if (typDatSetInstrucoesEmbarque.tbInstrucoesEmbarque.Rows.Count > 0)
					{
						mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque.tbInstrucoesEmbarqueRow dtrwTbInstrucoesEmbarque = (mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque.tbInstrucoesEmbarqueRow)typDatSetInstrucoesEmbarque.tbInstrucoesEmbarque.Rows[0];
						if (!dtrwTbInstrucoesEmbarque.IsbPermitirTransbordoNull())
							m_bValorBooleano = dtrwTbInstrucoesEmbarque.bPermitirTransbordo;
					}
				}
			}
		}
		#endregion
		#region Salvamento dos Dados
		protected override void salvaDadosBDEspecificos()
		{
			mdlDataBaseAccess.Tabelas.XsdTbPes typDatSetPes = GetTypDatSetPes();
			if (typDatSetPes.tbPEs.Rows.Count > 0)
			{
				mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwPe = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)typDatSetPes.tbPEs.Rows[0];
				dtrwPe.bTransbordo = m_bValorBooleano;
				m_cls_dba_ConnectionDB.SetTbPes(typDatSetPes);
			}
		}
		#endregion
	}
}
