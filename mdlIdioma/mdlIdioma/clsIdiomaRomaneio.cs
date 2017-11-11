using System;

namespace mdlIdioma
{
	/// <summary>
	/// Summary description for clsIdiomaRomaneio.
	/// </summary>
	public class clsIdiomaRomaneio: clsIdioma
	{
		#region Atributos
			private mdlDataBaseAccess.Tabelas.XsdTbRomaneios m_typDatSetTbRomaneios;
		#endregion
		#region Construtores e Destrutores
		public clsIdiomaRomaneio(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel, int Exportador, string Codigo, ref System.Windows.Forms.ImageList bandeiras): base(ref tratadorErro, ref ConnectionDB,EnderecoExecutavel,Exportador,Codigo, ref bandeiras)
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
						lviIdioma = lvListView.Items.Add("Espanhol");
						lviIdioma.Tag = 2;
						lviIdioma.ImageIndex = (2 - 1);
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
						System.Collections.ArrayList arlCondicoesNome = new System.Collections.ArrayList();
						System.Collections.ArrayList arlCondicoesComparador = new System.Collections.ArrayList();
						System.Collections.ArrayList arlCondicoesValor = new System.Collections.ArrayList();
						arlCondicoesNome.Add("idExportador");
						arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
						arlCondicoesValor.Add(m_nIdExportador);
						arlCondicoesNome.Add("idPE");
						arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
						arlCondicoesValor.Add(m_strCodigo);
						m_typDatSetTbRomaneios = m_cls_dba_ConnectionDB.GetTbRomaneios(arlCondicoesNome,arlCondicoesComparador,arlCondicoesValor,null,null);
						if ( m_typDatSetTbRomaneios.tbRomaneios.Rows.Count > 0)
						{
							mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow dtrwRomaneios;
							for (int nCount = 0; nCount < m_typDatSetTbRomaneios.tbRomaneios.Rows.Count; nCount++)
							{
								dtrwRomaneios = (mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow)m_typDatSetTbRomaneios.tbRomaneios.Rows[nCount];
								if (!dtrwRomaneios.IsnIdIdiomaNull())
									m_nIdioma = dtrwRomaneios.nIdIdioma;
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
					gbFields.Text = "Romaneio";
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
						if (m_typDatSetTbRomaneios.tbRomaneios.Rows.Count > 0)
						{
							mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow dtrwRomaneios = m_typDatSetTbRomaneios.tbRomaneios.FindByidExportadoridPE(m_nIdExportador,m_strCodigo);
							if (dtrwRomaneios != null)
							{
								dtrwRomaneios.nIdIdioma = m_nIdioma;
								m_cls_dba_ConnectionDB.SetTbRomaneios(m_typDatSetTbRomaneios);
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
