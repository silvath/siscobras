using System;

namespace mdlIdioma
{
	/// <summary>
	/// Summary description for clsIdiomaSaque.
	/// </summary>
	public class clsIdiomaSaque: clsIdioma
	{
		#region Atributos
			private mdlDataBaseAccess.Tabelas.XsdTbSaques m_typDatSetTbSaques;
		#endregion
		#region Construtores e Destrutores
		public clsIdiomaSaque(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel, int Exportador, string Codigo, ref System.Windows.Forms.ImageList bandeiras): base(ref tratadorErro, ref ConnectionDB,EnderecoExecutavel,Exportador,Codigo, ref bandeiras)
		{
			try 
			{
				this.carregaDadosBD();
			} 
			catch (Exception err) 
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Carregamento de Dados
			#region Banco de Dados
			protected override void carregaDadosInterface(ref System.Windows.Forms.ListView lvListView, ref System.Windows.Forms.GroupBox gbFields)
			{
				try 
				{
					System.Windows.Forms.ListViewItem lviIdioma;

					lvListView.Items.Clear();
					
					lviIdioma = lvListView.Items.Add("Português");
					lviIdioma.Tag = 1;
					lviIdioma.ImageIndex = (1 - 1);
					if ((int)lviIdioma.Tag == m_nIdioma)
					{
						lviIdioma.Selected = true;
						m_strIdioma = lviIdioma.Text;
					}
					lviIdioma = lvListView.Items.Add("Inglês");
					lviIdioma.Tag = 3;
					lviIdioma.ImageIndex = (3 - 1);
					if ((int)lviIdioma.Tag == m_nIdioma)
					{
						lviIdioma.Selected = true;
						m_strIdioma = lviIdioma.Text;
					}
					carregaDadosInterfaceEspecificos(ref gbFields);
				}catch (Exception err){ 
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}

			protected override void carregaDadosBDEspecificos()
			{
				try 
				{
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;

					System.Collections.ArrayList arlCondicoesNome = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesValor = new System.Collections.ArrayList();
					arlCondicoesNome.Add("idExportador");
					arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicoesValor.Add(m_nIdExportador);
					arlCondicoesNome.Add("idPE");
					arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicoesValor.Add(m_strCodigo);
					m_typDatSetTbSaques = m_cls_dba_ConnectionDB.GetTbSaques(arlCondicoesNome,arlCondicoesComparador,arlCondicoesValor,null,null);
					if ( m_typDatSetTbSaques.tbSaques.Rows.Count > 0)
					{
						mdlDataBaseAccess.Tabelas.XsdTbSaques.tbSaquesRow dtrwSaques;
						for (int nCount = 0; nCount < m_typDatSetTbSaques.tbSaques.Rows.Count; nCount++)
						{
							dtrwSaques = (mdlDataBaseAccess.Tabelas.XsdTbSaques.tbSaquesRow)m_typDatSetTbSaques.tbSaques.Rows[nCount];
							if (!dtrwSaques.IsnIdIdiomaNull())
								m_nIdioma = dtrwSaques.nIdIdioma;
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
			protected override void carregaDadosInterfaceEspecificos(ref System.Windows.Forms.GroupBox gbFields)
			{
				try
				{
					gbFields.Text = "Saque";
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
			#region Banco Dados 
			protected override void SalvaDadosBDEspecificos()
			{
				try 
				{
					if (m_bModificado)
					{
						if (m_typDatSetTbSaques.tbSaques.Rows.Count > 0)
						{
							mdlDataBaseAccess.Tabelas.XsdTbSaques.tbSaquesRow dtrwSaques = m_typDatSetTbSaques.tbSaques.FindByidExportadoridPE(m_nIdExportador,m_strCodigo);
							if (dtrwSaques != null)
							{
								dtrwSaques.nIdIdioma = m_nIdioma;
								m_cls_dba_ConnectionDB.SetTbSaques(m_typDatSetTbSaques);
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
		#endregion
	}
}
