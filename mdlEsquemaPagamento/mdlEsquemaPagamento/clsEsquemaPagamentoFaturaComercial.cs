using System;

namespace mdlEsquemaPagamento
{
	/// <summary>
	/// Summary description for clsEsquemaPagamentoFaturaComercial.
	/// </summary>
	public class clsEsquemaPagamentoFaturaComercial : clsEsquemaPagamento
	{
		#region Atributes
			// ***************************************************************************************************
			// Atributos
			// ***************************************************************************************************
	             private string m_strIdPE = "";
		         private mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais m_typDatSetTbFaturasComerciais;
			// ***************************************************************************************************
		#endregion
		#region Constructor
			public clsEsquemaPagamentoFaturaComercial(ref mdlTratamentoErro.clsTratamentoErro tratadorErro , ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB , string strEnderecoExecutavel, ref System.Windows.Forms.ImageList Bandeiras,int idExportador,string idPe): base(ref tratadorErro,ref ConnectionDB,strEnderecoExecutavel,ref Bandeiras,idExportador) 
			{
				m_strIdPE = idPe;
				this.CarregaDados();
			}
		#endregion

		#region Carregamento do Dados 
			protected override void CarregaDadosEsquemaPagamento()
			{
				System.Collections.ArrayList arlCondicoesNome = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicoesComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicoesValor = new System.Collections.ArrayList();
				arlCondicoesNome.Add("idExportador");
				arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicoesValor.Add(m_nIdExportador);
				arlCondicoesNome.Add("idPe");
				arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicoesValor.Add(m_strIdPE);
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				m_typDatSetTbFaturasComerciais = m_cls_dba_ConnectionDB.GetTbFaturasComerciais(arlCondicoesNome,arlCondicoesComparador,arlCondicoesValor,null,null);

				// Setando os Dados 
				mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwRegistro = m_typDatSetTbFaturasComerciais.tbFaturasComerciais.FindByidExportadoridPE(m_nIdExportador,m_strIdPE);
				if (dtrwRegistro != null)
				{
					#region EsquemaPagamento
						// Esquema Pagamento
						if (!dtrwRegistro.IsmstrEsquemaPagamentoNull())
							m_strEsquemaPagamento = dtrwRegistro.mstrEsquemaPagamento;
						else
							m_strEsquemaPagamento = "";
					#endregion
					#region Idioma
						// Idioma 
						if (!dtrwRegistro.IsidIdiomaNull())
							m_nIdioma = dtrwRegistro.idIdioma;
						else
							m_nIdioma = 1;
						if (m_nIdioma > 3)
							m_nIdioma = 3;
					#endregion
					#region Moeda
						// IdMoeda
						if (!dtrwRegistro.IsidMoedaNull())
							m_nIdMoeda = dtrwRegistro.idMoeda;
						else
							m_nIdMoeda = -1;
						// Mostrar Simbolo Moeda
						if (!dtrwRegistro.IsbMostrarSimboloMoedaNull())
						{
							m_bMostrarSimboloMoeda = dtrwRegistro.bMostrarSimboloMoeda;
						}
					#endregion
					#region Condicoes
						//Antecipado
						if (!dtrwRegistro.IscondAntecipadoNull())
							m_dCondAntecipado = dtrwRegistro.condAntecipado;
						else
							m_dCondAntecipado = 0;
	                    
						// Avista 
						if (!dtrwRegistro.IscondAvistaNull())
							m_dCondAvista = dtrwRegistro.condAvista;
						else
							m_dCondAvista = 0;

						// Postecipado
						if (!dtrwRegistro.IscondPostecipadoNull())
							m_dCondPostecipado = dtrwRegistro.condPostecipado;
						else
							m_dCondPostecipado = 0;

						// Sem Cobertura Cambial 
						if (!dtrwRegistro.IscondSemCoberturaCambialNull())
							m_bCondSemCoberturaCambial = dtrwRegistro.condSemCoberturaCambial;
						else
							m_bCondSemCoberturaCambial = false;

						// Consignacao 
						if (!dtrwRegistro.IscondConsignacaoNull())
							m_bCondConsignacao = dtrwRegistro.condConsignacao;
						else
							m_bCondConsignacao = false;
					#endregion
					#region Modalidade
						// Antecipado
						if (!dtrwRegistro.IsmodAntecipadoNull())
							m_enumModAntecipado = (Modalidade)dtrwRegistro.modAntecipado;
						else
							m_enumModAntecipado = Modalidade.Nenhuma;

						// A Vista
						if (!dtrwRegistro.IsmodAvistaNull())
							m_enumModAvista = (Modalidade)dtrwRegistro.modAvista;
						else
							m_enumModAvista = Modalidade.Nenhuma;

						// Postecipado
						if (!dtrwRegistro.IsmodPostecipadoNull())
							m_enumModPostecipado = (Modalidade)dtrwRegistro.modPostecipado;
						else
							m_enumModPostecipado = Modalidade.Nenhuma;
					#endregion
					#region Postecipado
						// Quantidade de tempo do postecipado
						if (!dtrwRegistro.IspostQuantTempoNull())
							m_nPostQuantTempo = dtrwRegistro.postQuantTempo;
						else
							m_nPostQuantTempo = 0;

						// Unidade de Tempo do Postecipado 
						if (!dtrwRegistro.IspostUnidadeTempoNull())
							m_enumPostUnidadeTempo = (UnidadeTempo)dtrwRegistro.postUnidadeTempo;
						else
							m_enumPostUnidadeTempo = UnidadeTempo.Dia;

 				       // Documento Postecipado
						if (!dtrwRegistro.IspostCondicaoNull())
							m_enumPostCondicao = (DocumentoCondicao)dtrwRegistro.postCondicao;
						else
							m_enumPostCondicao = DocumentoCondicao.Fatura;

						// Quantidadee de Parcelas do Postecipado
						if (!dtrwRegistro.IspostQuantParcelasNull())
							m_nPostQuantParcelas = dtrwRegistro.postQuantParcelas;
						else
							m_nPostQuantParcelas = 0;

					     // Intervalo do Postecipado
						if (!dtrwRegistro.IspostIntervaloNull())
							m_nPostIntervalo = dtrwRegistro.postIntervalo;
						else
							m_nPostIntervalo = 0;
					#endregion

					#region Valor Total
						string strTemp;
						double dTemp;
						bool bTemp;
						double dValorTotal = 0;
						mdlIncoterm.clsIncoterm cls_inc_ValorTotal = new mdlIncoterm.Faturas.clsIncotermComercial(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPE,ref m_typDatSetTbFaturasComerciais);
						cls_inc_ValorTotal.retornaValores(out strTemp,out dTemp,out dTemp,out bTemp,out dTemp,out dTemp,out dTemp,out dTemp,out strTemp,out dTemp,out dValorTotal,out bTemp,out strTemp);
						this.ValorTotal = dValorTotal;
					#endregion
				}
			}
		#endregion
		#region Salvamento do Dados 
			protected override void SalvaDados(string strEsquemaPagamento)
			{
				try
				{
					m_strEsquemaPagamento = strEsquemaPagamento;
					mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwRegistro = m_typDatSetTbFaturasComerciais.tbFaturasComerciais.FindByidExportadoridPE(m_nIdExportador,m_strIdPE);
					if (dtrwRegistro != null)
					{
						if (m_strEsquemaPagamento == "")
							m_strEsquemaPagamento = " ";
						dtrwRegistro.mstrEsquemaPagamento = m_strEsquemaPagamento;
						dtrwRegistro.condAntecipado = m_dCondAntecipado;
						dtrwRegistro.modAntecipado = (int)m_enumModAntecipado;
						dtrwRegistro.condAvista = m_dCondAvista;
						dtrwRegistro.modAvista = (int)m_enumModAvista;  
						dtrwRegistro.condPostecipado = m_dCondPostecipado;
						dtrwRegistro.modPostecipado = (int)m_enumModPostecipado;  
						dtrwRegistro.postQuantTempo = m_nPostQuantTempo;
						dtrwRegistro.postUnidadeTempo = (int)m_enumPostUnidadeTempo;
						dtrwRegistro.postCondicao = (int)m_enumPostCondicao; 
						dtrwRegistro.postQuantParcelas = m_nPostQuantParcelas;
						dtrwRegistro.postIntervalo = m_nPostIntervalo;
												
						dtrwRegistro.condSemCoberturaCambial = m_bCondSemCoberturaCambial;
						dtrwRegistro.condConsignacao = m_bCondConsignacao;

						// Salvando 
						m_cls_dba_ConnectionDB.SetTbFaturasComerciais(m_typDatSetTbFaturasComerciais);

						// Salvando Esquema Pagamento no Bordero
						mdlObservacoes.clsObservacoes cls_obs_Bordero = new mdlObservacoes.Bordero.clsBorderoModalidadePagamento(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPE);
						cls_obs_Bordero.OBSERVACOES = m_strEsquemaPagamento;
						cls_obs_Bordero.SalvaDiretoSemInterface();
						cls_obs_Bordero = null;
					}
				}catch(Exception erro){
					Object obj = erro;
					m_cls_ter_tratadorErro.trataErro(ref obj);
				}
   			}
		#endregion
	}
}
