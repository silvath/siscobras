using System;

namespace mdlObservacoes.InstrucoesEmbarque
{
	/// <summary>
	/// Summary description for clsInstrucoesEmbarqueNotificar1.
	/// </summary>
	public class clsInstrucoesEmbarqueNotificar1 : clsObservacoes
	{
		#region Atributos
		private string m_strIdPE = "";

		private mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque m_typDatSetTbInstrucoesEmbarque;
		#endregion
		#region Construtores & Destrutores
		public clsInstrucoesEmbarqueNotificar1(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string strIdPE): base(ref tratadorErro, ref ConnectionDB,EnderecoExecutavel,nIdExportador)
		{
			m_bFormPadrao = true;
			m_strIdPE = strIdPE;
			carregaTypDatSet();
			carregaDadosBD();
			m_bMostrarLabel = false;
			m_strCaption = "Notificar";
		}
		#endregion

		#region Carregamento de Dados
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

					m_typDatSetTbInstrucoesEmbarque = m_cls_dba_ConnectionBD.GetTbInstrucoesEmbarque(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
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
					mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque.tbInstrucoesEmbarqueRow dtrwRowTbInstrucoesEmbarque;
					if (m_typDatSetTbInstrucoesEmbarque.tbInstrucoesEmbarque.Rows.Count > 0)
					{
						dtrwRowTbInstrucoesEmbarque = (mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque.tbInstrucoesEmbarqueRow)m_typDatSetTbInstrucoesEmbarque.tbInstrucoesEmbarque.Rows[0];
						if (!dtrwRowTbInstrucoesEmbarque.IsstrNotificacao1Null())
							m_strObservacoes = dtrwRowTbInstrucoesEmbarque.strNotificacao1;
						else
							m_strObservacoes = this.Default;
					}
				} 
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}

			protected override void vCarregaDadosDefault()
			{
				System.Windows.Forms.ImageList ilBandeiras = new System.Windows.Forms.ImageList();
				mdlImportador.clsImportador obj = new mdlImportador.clsImportadorComercial(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionBD,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPE,ref ilBandeiras);
				int nIdImportador;
				string strTemp,strImportador,strEndereco,strCidade,strEstado,strPais,strTelefone,strEmail,strSite;
				obj.retornaValores(out nIdImportador,out strImportador,out strEndereco,out strCidade,out strEstado,out strPais,out strTelefone,out strTemp,out strEmail,out strSite,out strTemp);
				System.Text.StringBuilder stbDefault = new System.Text.StringBuilder();
				stbDefault.Append(strImportador);
				stbDefault.Append(System.Environment.NewLine);
				stbDefault.Append(strEndereco);
				stbDefault.Append(System.Environment.NewLine);
				stbDefault.Append(strCidade);
				stbDefault.Append(" - ");
				stbDefault.Append(strEstado);
				stbDefault.Append(" - ");
				stbDefault.Append(strPais);
				stbDefault.Append(System.Environment.NewLine);
				stbDefault.Append(strTelefone);
				stbDefault.Append(" - ");
				stbDefault.Append(strEmail);
				stbDefault.Append(" - ");
				stbDefault.Append(strSite);
				this.Default = stbDefault.ToString();
			}
		#endregion
		#region Salvamento dos Dados
		#region Banco de Dados
		protected override void salvaDadosBDEspecifico()
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque.tbInstrucoesEmbarqueRow dtrwRowTbInstrucoesEmbarque;
				if (m_typDatSetTbInstrucoesEmbarque.tbInstrucoesEmbarque.Rows.Count > 0)
				{
					dtrwRowTbInstrucoesEmbarque = (mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque.tbInstrucoesEmbarqueRow)m_typDatSetTbInstrucoesEmbarque.tbInstrucoesEmbarque.Rows[0];
					if (dtrwRowTbInstrucoesEmbarque != null)
						dtrwRowTbInstrucoesEmbarque.strNotificacao1 = m_strObservacoes;
				}
				m_cls_dba_ConnectionBD.SetTbInstrucoesEmbarque(m_typDatSetTbInstrucoesEmbarque);
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
