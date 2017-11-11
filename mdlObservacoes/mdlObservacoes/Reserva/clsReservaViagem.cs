using System;

namespace mdlObservacoes.Reserva
{
	/// <summary>
	/// Summary description for clsReservaViagem.
	/// </summary>
	public class clsReservaViagem : clsObservacoes
	{
		#region Atributes
		private string m_strIdPE = "";

		private mdlDataBaseAccess.Tabelas.XsdTbPes m_typDatSetProcessos;
		#endregion
		#region Constructors and Destructors
			public clsReservaViagem(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string strIdPE): base(ref tratadorErro, ref ConnectionDB,EnderecoExecutavel,nIdExportador)
			{
				this.Multiline = false;
				this.TextForm = "Viagem";
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

					m_typDatSetProcessos = m_cls_dba_ConnectionBD.GetTbPes(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
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
					if (m_typDatSetProcessos.tbPEs.Rows.Count > 0)
					{
						mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwPe = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetProcessos.tbPEs.Rows[0];
						if (!dtrwPe.IsmstrViagemNull())
							m_strObservacoes = dtrwPe.mstrViagem;
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
		#region Salvamento dos Dados
		#region Banco de Dados
		protected override void salvaDadosBDEspecifico()
		{
			if (m_typDatSetProcessos.tbPEs.Rows.Count > 0)
			{
				mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwProcesso = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetProcessos.tbPEs.Rows[0];
				dtrwProcesso.mstrViagem = m_strObservacoes;  
				m_cls_dba_ConnectionBD.SetTbPes(m_typDatSetProcessos);
			}
		}
		#endregion
		#endregion

	}
}
