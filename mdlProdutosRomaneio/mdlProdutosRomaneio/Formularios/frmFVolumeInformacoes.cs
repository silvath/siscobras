using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlProdutosRomaneio
{
	/// <summary>
	/// Summary description for frmFVolumeInformacoes.
	/// </summary>
	internal class frmFVolumeInformacoes : System.Windows.Forms.Form
	{
		#region Atributes
			private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro; 
			private string m_strEnderecoExecutavel;

			private System.Collections.ArrayList m_arlVolumes;
			private System.Windows.Forms.ImageList m_ilVolumes;
			private System.Windows.Forms.ImageList m_ilEmbalagens;

			// Typed DataSets Clones
			private mdlDataBaseAccess.Tabelas.XsdTbVolumes m_typDatSetTbVolumesCopy;
			private mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes m_typDatSetTbProdutosRomaneioVolumesCopy;
			private mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos m_typDatSetTbProdutosRomaneioVolumesProdutosCopy;
			private mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens m_typDatSetTbProdutosRomaneioEmbalagensCopy;
			private mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos m_typDatSetTbProdutosRomaneioEmbalagensProdutosCopy;

			private string m_strUltimoVolume = "";

			private int m_nTipoVolume = 0;
			private int m_nUnidadeMetricaAltura = 0;
			private int m_nUnidadeMetricaLargura = 0;
			private int m_nUnidadeMetricaComprimento = 0;
			private int m_nUnidadeMetricaVolume = 0;
			private int m_nUnidadeMassaPesoLiquido = 0;
			private int m_nUnidadeMassaPesoBruto = 0;
                
			public bool m_bModificado = false;
		
			internal System.Windows.Forms.GroupBox m_gbGeral;
			internal System.Windows.Forms.Button m_btOk;
			internal System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.GroupBox m_gbVolume;
			private System.Windows.Forms.GroupBox m_gbInformacoesVolume;
			private System.Windows.Forms.GroupBox m_gbInformacoes;
			internal System.Windows.Forms.Button m_btUnidadePesoBruto;
			internal mdlComponentesGraficos.TextBox m_txtPesoBruto;
			internal System.Windows.Forms.Label m_lbPesoBruto;
			internal System.Windows.Forms.Button m_btUnidadePesoLiquido;
			internal mdlComponentesGraficos.TextBox m_txtPesoLiquido;
			internal System.Windows.Forms.Label m_lbPesoLiquido;
			internal System.Windows.Forms.Button m_btUnidadeVolume;
			internal System.Windows.Forms.Button m_btUnidadeComprimento;
			internal System.Windows.Forms.Button m_btUnidadeLargura;
			internal System.Windows.Forms.Button m_btUnidadeAltura;
			internal mdlComponentesGraficos.TextBox m_txtVolume;
			internal mdlComponentesGraficos.TextBox m_txtComprimento;
			internal mdlComponentesGraficos.TextBox m_txtLargura;
			internal mdlComponentesGraficos.TextBox m_txtAltura;
			internal System.Windows.Forms.Label m_lbVolume;
			internal System.Windows.Forms.Label m_lbLargura;
			internal System.Windows.Forms.Label m_lbComprimento;
			internal System.Windows.Forms.Label m_lbAltura;
			internal mdlComponentesGraficos.TextBox m_txtTipoPopular;
			internal System.Windows.Forms.Label m_lbPE;
			internal System.Windows.Forms.Button m_btTipo;
			private System.Windows.Forms.Label m_lbNumeroVolume;
			private System.Windows.Forms.GroupBox groupBox1;
			private mdlComponentesGraficos.ListView m_lvVolumes;
			internal mdlComponentesGraficos.TextBox m_txtNumeroVolume;
			private System.Windows.Forms.GroupBox m_gbConteudo;
			public System.Windows.Forms.Button m_btConteudoExcluir;
			public System.Windows.Forms.Button m_btConteudoEditar;
			private mdlComponentesGraficos.ListView m_lvConteudo;
			private System.Windows.Forms.ColumnHeader m_colConteudoQuantidade;
			private System.Windows.Forms.ColumnHeader m_colConteudoDescricao;
			private System.Windows.Forms.ColumnHeader m_colConteudoPesoLiquido;
			private System.Windows.Forms.ToolTip m_ttDica;
			private System.ComponentModel.IContainer components;
		#endregion

		#region Delegates
			#region Carregamento dos Dados
				public delegate void delCallCarregaDadosVolumes(ref mdlDataBaseAccess.Tabelas.XsdTbVolumes typDatSetTbVolumes,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetTbProdutosRomaneioVolumes,ref mdlComponentesGraficos.ListView lvVolumes,ref System.Collections.ArrayList arlVolumes);
				public delegate void delCallCarregaInformacoesTipoVolume(int nTipoVolume,out string strDescricaoTipoVolume,out string strDescricaoPopularTipoVolume,out int nIndiceImagemTipoVolume);
				public delegate void delCallCarregaDadosVolumeSelecionado(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetTbProdutosRomaneioVolumes,string strNumeroVolume,out int nTipoVolume,out string strTipoPopular,out double dAltura,out int nUnidadeMetricaAltura,out double dLargura,out int nUnidadeMetricaLargura,out double dComprimento,out int nUnidadeMetricaComprimento,out double dVolume,out int nUnidadeMetricaVolume,out double dPesoLiquido, out int nUnidadeMassaPesoLiquido,out double dPesoBruto, out int nUnidadeMassaPesoBruto);
				public delegate void delCallCarregaDadosVolumeProdutos(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos typDatSetTbProdutosRomaneioVolumesProdutos,string strNumeroVolume, ref mdlComponentesGraficos.ListView lvProdutos);
				public delegate void delCallCarregaDadosVolumeEmbalagens(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens typDatSetTbProdutosRomaneioEmbalagens,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos typDatSetTbProdutosRomaneioEmbalagensProdutos,string strNumeroVolume, ref mdlComponentesGraficos.ListView lvEmbalagens);
				public delegate string delCallRetornaSiglaUnidadeEspaco(int nUnidadeEspaco);
				public delegate string delCallRetornaSiglaUnidadeMassa(int nUnidadeMassa);
			#endregion
			#region	Produtos
				public delegate bool delCallShowDialogProdutos(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens typDatSetTbProdutosRomaneioEmbalagens, ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos typDatSetTbProdutosRomaneioEmbalagensProdutos,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos typDatSetTbProdutosRomaneioVolumesProdutos,ref System.Collections.ArrayList arlProdutos,ref System.Collections.ArrayList arlVolumes);
				public delegate bool delCallExcluiVolumeProdutos(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos typDatSetTbProdutosRomaneioVolumesProdutos,string strNumeroVolume,ref System.Collections.ArrayList arlProdutos);
			#endregion
			#region	Embalagens 
				public delegate bool delCallShowDialogEmbalagens(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens typDatSetTbProdutosRomaneioEmbalagens,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos typDatSetTbProdutosRomaneioEmbalagensProdutos, ref System.Windows.Forms.ImageList ilEmbalagens, ref System.Collections.ArrayList arlEmbalagems);				
				public delegate bool delCallExcluiVolumeEmbalagens(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens typDatSetTbProdutosRomaneioEmbalagens,string strNumeroVolume,ref System.Collections.ArrayList arlProdutos);
			#endregion
			#region Volume 
				public delegate void delCallShowDialogVolumeTipo(ref int nIdVolumeTipo,ref System.Windows.Forms.ImageList ilVolumes);
			#endregion
			#region Salvamento dos Dados
				public delegate bool delCallVolumeInexistente(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetTbProdutosRomaneioVolumes,string strNumeroVolume);
				// Numero Volume
				public delegate void delCallSalvaDadosVolumeNumeroVolume(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetTbProdutosRomaneioVolumes,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos typDatSetTbProdutosRomaneioVolumesProdutos,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens typDatSetTbProdutosRomaneioEmbalagens,string strNumeroVolumeAntigo,string strNumeroVolumeNovo);
				public delegate void delCallSalvaDadosVolumeTipo(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetTbProdutosRomaneioVolumes,string strNumeroVolume,int nTipoVolume);
				public delegate void delCallSalvaDadosVolumeDescricaoPopular(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetTbProdutosRomaneioVolumes,string strNumeroVolume,string strDescricaoPopular);

				public delegate void delCallSalvaDadosVolumeAltura(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetTbProdutosRomaneioVolumes,string strNumeroVolume,double dAltura);
				public delegate void delCallSalvaDadosVolumeLargura(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetTbProdutosRomaneioVolumes,string strNumeroVolume,double dLargura);
				public delegate void delCallSalvaDadosVolumeComprimento(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetTbProdutosRomaneioVolumes,string strNumeroVolume,double dComprimento);
				public delegate void delCallSalvaDadosVolumeVolume(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetTbProdutosRomaneioVolumes,string strNumeroVolume,double dVolume);
				public delegate void delCallSalvaDadosVolumePesoLiquido(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetTbProdutosRomaneioVolumes,string strNumeroVolume,double dPesoLiquido);
				public delegate void delCallSalvaDadosVolumePesoBruto(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetTbProdutosRomaneioVolumes,string strNumeroVolume,double dPesoBruto);

				public delegate void delCallSalvaDadosVolumeAlturaUnidade(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetTbProdutosRomaneioVolumes,string strNumeroVolume,int nUnidadeAltura);
				public delegate void delCallSalvaDadosVolumeLarguraUnidade(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetTbProdutosRomaneioVolumes,string strNumeroVolume,int nUnidadeLargura);
				public delegate void delCallSalvaDadosVolumeComprimentoUnidade(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetTbProdutosRomaneioVolumes,string strNumeroVolume,int nUnidadeComprimento);
				public delegate void delCallSalvaDadosVolumeVolumeUnidade(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetTbProdutosRomaneioVolumes,string strNumeroVolume,int nUnidadeVolume);
				public delegate void delCallSalvaDadosVolumePesoLiquidoUnidade(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetTbProdutosRomaneioVolumes,string strNumeroVolume,int nUnidadePesoLiquido);
				public delegate void delCallSalvaDadosVolumePesoBrutoUnidade(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetTbProdutosRomaneioVolumes,string strNumeroVolume,int nUnidadePesoBruto);
			#endregion
		#endregion
		#region Events
			#region Carregamento dos Dados
				public event delCallCarregaDadosVolumes eCallCarregaDadosVolumes;
				public event delCallCarregaInformacoesTipoVolume eCallCarregaInformacoesTipoVolume;
				public event delCallCarregaDadosVolumeSelecionado eCallCarregaDadosVolumeSelecionado;
				public event delCallCarregaDadosVolumeProdutos eCallCarregaDadosVolumeProdutos;
				public event delCallCarregaDadosVolumeEmbalagens eCallCarregaDadosVolumeEmbalagens;
				public event delCallRetornaSiglaUnidadeEspaco eCallRetornaSiglaUnidadeEspaco;
				public event delCallRetornaSiglaUnidadeMassa eCallRetornaSiglaUnidadeMassa;
			#endregion
			#region	Produtos
				public event delCallShowDialogProdutos eCallShowDialogProdutos;
				public event delCallExcluiVolumeProdutos eCallExcluiVolumeProdutos;
			#endregion
			#region	Embalagens 
				public event delCallShowDialogEmbalagens eCallShowDialogEmbalagens;
				public event delCallExcluiVolumeEmbalagens eCallExcluiVolumeEmbalagens;
			#endregion
			#region Volume
				public event delCallShowDialogVolumeTipo eCallShowDialogVolumeTipo;
			#endregion
			#region Salvamento dos Dados
				public event delCallVolumeInexistente eCallVolumeInexistente;

				public event delCallSalvaDadosVolumeNumeroVolume eCallSalvaDadosVolumeNumeroVolume;
				public event delCallSalvaDadosVolumeTipo eCallSalvaDadosVolumeTipo;
				public event delCallSalvaDadosVolumeDescricaoPopular eCallSalvaDadosVolumeDescricaoPopular;
				
				public event delCallSalvaDadosVolumeAltura eCallSalvaDadosVolumeAltura;
				public event delCallSalvaDadosVolumeLargura eCallSalvaDadosVolumeLargura;
				public event delCallSalvaDadosVolumeComprimento eCallSalvaDadosVolumeComprimento;
				public event delCallSalvaDadosVolumeVolume eCallSalvaDadosVolumeVolume;
				public event delCallSalvaDadosVolumePesoLiquido eCallSalvaDadosVolumePesoLiquido;
				public event delCallSalvaDadosVolumePesoBruto eCallSalvaDadosVolumePesoBruto;

				public event delCallSalvaDadosVolumeAlturaUnidade eCallSalvaDadosVolumeAlturaUnidade;
				public event delCallSalvaDadosVolumeLarguraUnidade eCallSalvaDadosVolumeLarguraUnidade;
				public event delCallSalvaDadosVolumeComprimentoUnidade eCallSalvaDadosVolumeComprimentoUnidade;
				public event delCallSalvaDadosVolumeVolumeUnidade eCallSalvaDadosVolumeVolumeUnidade;
				public event delCallSalvaDadosVolumePesoLiquidoUnidade eCallSalvaDadosVolumePesoLiquidoUnidade;
				public event delCallSalvaDadosVolumePesoBrutoUnidade eCallSalvaDadosVolumePesoBrutoUnidade;

			#endregion
		#endregion
		#region Events Methods
			#region Carregamento dos Dados
				protected virtual void OnCallCarregaDadosVolumes()
				{
					if (eCallCarregaDadosVolumes != null)
						eCallCarregaDadosVolumes(ref m_typDatSetTbVolumesCopy,ref m_typDatSetTbProdutosRomaneioVolumesCopy,ref m_lvVolumes,ref m_arlVolumes);
				}

				protected virtual void OnCallCarregaInformacoesTipoVolume(int nTipoVolume,out string strDescricaoTipoVolume,out string strDescricaoPopularTipoVolume,out int nIndiceImagemTipoVolume)
				{
					strDescricaoTipoVolume = "";
					strDescricaoPopularTipoVolume = "";
					nIndiceImagemTipoVolume = 0;
					if (eCallCarregaInformacoesTipoVolume != null)
					{
						eCallCarregaInformacoesTipoVolume(nTipoVolume,out strDescricaoTipoVolume,out strDescricaoPopularTipoVolume,out nIndiceImagemTipoVolume);
					}
				}

				protected virtual void OnCallCarregaDadosVolumeSelecionado(bool bForceLoad)
				{
					if (eCallCarregaDadosVolumeSelecionado != null)
					{
						string strNumeroVolume = "";
						if (m_lvVolumes.SelectedItems.Count > 0)
						{
							m_strUltimoVolume = strNumeroVolume = m_lvVolumes.SelectedItems[0].Text.Trim();
							if ((strNumeroVolume != m_txtNumeroVolume.Text.Trim()) || (bForceLoad))
							{
								m_lvConteudo.Items.Clear();
								m_txtNumeroVolume.Text = strNumeroVolume;
								int nTipoVolume,nIndiceImagemTipo;
								string strTipo,strTipoPopular;
								double dAltura,dLargura,dComprimento,dVolume,dPesoLiquido,dPesoBruto;
								int nUnidadeMetricaAltura,nUnidadeMetricaLargura,nUnidadeMetricaComprimento,nUnidadeMetricaVolume,nUnidadeMassaPesoLiquido,nUnidadeMassaPesoBruto;
								eCallCarregaDadosVolumeSelecionado(ref m_typDatSetTbProdutosRomaneioVolumesCopy,strNumeroVolume,out nTipoVolume,out strTipoPopular,out dAltura,out nUnidadeMetricaAltura,out dLargura,out nUnidadeMetricaLargura,out dComprimento,out nUnidadeMetricaComprimento,out dVolume,out nUnidadeMetricaVolume,out dPesoLiquido,out nUnidadeMassaPesoLiquido,out dPesoBruto, out nUnidadeMassaPesoBruto);

								// Setando o Tipo
								string strDescricaoPopularExportador = "";
								OnCallCarregaInformacoesTipoVolume(nTipoVolume,out strTipo,out strDescricaoPopularExportador,out nIndiceImagemTipo);
								m_nTipoVolume = nTipoVolume;
								m_btTipo.Image = m_ilVolumes.Images[nIndiceImagemTipo];
                                
								// strTipoPopular
								m_txtTipoPopular.Text = strTipoPopular;

								// dAltura 
								m_txtAltura.Text = dAltura.ToString();

								// nUnidadeMetricaAltura
								m_nUnidadeMetricaAltura = nUnidadeMetricaAltura;
								m_btUnidadeAltura.Text = OnCallRetornaSiglaUnidadeEspaco(nUnidadeMetricaAltura);

								// dLargura 
								m_txtLargura.Text = dLargura.ToString();

								// nUnidadeMetricaLargura 
								m_nUnidadeMetricaLargura = nUnidadeMetricaLargura;
								m_btUnidadeLargura.Text = OnCallRetornaSiglaUnidadeEspaco(nUnidadeMetricaLargura);

								// dComprimento 
								m_txtComprimento.Text = dComprimento.ToString();

								// nUnidadeMetricaComprimento 
								m_nUnidadeMetricaComprimento = nUnidadeMetricaComprimento;
								m_btUnidadeComprimento.Text = OnCallRetornaSiglaUnidadeEspaco(nUnidadeMetricaComprimento);

								// dVolume 
								m_txtVolume.Text = dVolume.ToString();

								// nUnidadeMetricaVolume 
								m_nUnidadeMetricaVolume = nUnidadeMetricaVolume;
								m_btUnidadeVolume.Text = OnCallRetornaSiglaUnidadeEspaco(nUnidadeMetricaVolume) + "3";

								// dPesoLiquido 
								m_txtPesoLiquido.Text = dPesoLiquido.ToString();

								// nUnidadeMassaPesoLiquido 
								m_nUnidadeMassaPesoLiquido = nUnidadeMassaPesoLiquido;
								m_btUnidadePesoLiquido.Text = OnCallRetornaSiglaUnidadeMassa(nUnidadeMassaPesoLiquido);

								// dPesoBruto 
								m_txtPesoBruto.Text = dPesoBruto.ToString();

								// nUnidadeMassaPesoBruto 
								m_nUnidadeMassaPesoBruto = nUnidadeMassaPesoBruto;
								m_btUnidadePesoBruto.Text = OnCallRetornaSiglaUnidadeMassa(nUnidadeMassaPesoBruto);

								// Carregando os Produtos do Volume 
								OnCallCarregaDadosVolumeProdutos(strNumeroVolume);

								// Carregando as Embalagens do Volume
								OnCallCarregaDadosVolumeEmbalagens(strNumeroVolume);
							}
						}else{
							m_lvConteudo.Items.Clear();
						}
					}
				}

				protected virtual void OnCallCarregaDadosVolumeProdutos(string strNumeroVolume)
				{
					if (eCallCarregaDadosVolumeProdutos != null)
					{
						eCallCarregaDadosVolumeProdutos(ref m_typDatSetTbProdutosRomaneioVolumesProdutosCopy,strNumeroVolume,ref m_lvConteudo);
					}
				}

				protected virtual void OnCallCarregaDadosVolumeEmbalagens(string strNumeroVolume)
				{
					if (eCallCarregaDadosVolumeEmbalagens != null)
					{
						eCallCarregaDadosVolumeEmbalagens(ref m_typDatSetTbProdutosRomaneioEmbalagensCopy,ref m_typDatSetTbProdutosRomaneioEmbalagensProdutosCopy,strNumeroVolume,ref m_lvConteudo);
					}
				}

				protected virtual string OnCallRetornaSiglaUnidadeEspaco(int nUnidadeEspaco)
				{
					string strRetorno = "";
					if (eCallRetornaSiglaUnidadeEspaco != null)
					{
						strRetorno = eCallRetornaSiglaUnidadeEspaco(nUnidadeEspaco);
					}
					return(strRetorno);
				}

				protected virtual string OnCallRetornaSiglaUnidadeMassa(int nUnidadeMassa)
				{
					string strRetorno = "";
					if (eCallRetornaSiglaUnidadeMassa != null)
					{
						strRetorno = eCallRetornaSiglaUnidadeMassa(nUnidadeMassa);
					}
					return(strRetorno);
				}
			#endregion
			#region	Produtos
			protected virtual void OnCallShowDialogProdutos(ref System.Collections.ArrayList arlProdutos)
			{
				if (eCallShowDialogProdutos != null)
				{
					if (m_lvVolumes.SelectedItems.Count > 0)
					{
						System.Collections.ArrayList arlVolumes = new System.Collections.ArrayList();
						arlVolumes.Add(m_lvVolumes.SelectedItems[0].Text);
						if (eCallShowDialogProdutos(ref m_typDatSetTbProdutosRomaneioEmbalagensCopy,ref m_typDatSetTbProdutosRomaneioEmbalagensProdutosCopy,ref m_typDatSetTbProdutosRomaneioVolumesProdutosCopy,ref arlProdutos,ref arlVolumes))
						{
							m_lvConteudo.Items.Clear();

							// Carregando os Produtos do Volume 
							OnCallCarregaDadosVolumeProdutos(m_lvVolumes.SelectedItems[0].Text);

							// Carregando as Embalagens do Volume
							OnCallCarregaDadosVolumeEmbalagens(m_lvVolumes.SelectedItems[0].Text);
						}
					}
				}
			}

			protected virtual void OnCallExcluiVolumeProdutos(string strNumeroVolume, ref System.Collections.ArrayList arlProdutos)
			{
				if (eCallExcluiVolumeProdutos != null)
				{
					eCallExcluiVolumeProdutos(ref m_typDatSetTbProdutosRomaneioVolumesProdutosCopy,strNumeroVolume,ref arlProdutos);
					mdlProdutosRomaneio.clsProdutosRomaneio.bRecalculaPesoLiquidoVolume(ref m_typDatSetTbProdutosRomaneioVolumesCopy,ref m_typDatSetTbProdutosRomaneioVolumesProdutosCopy,ref m_typDatSetTbProdutosRomaneioEmbalagensCopy,ref m_typDatSetTbProdutosRomaneioEmbalagensProdutosCopy,strNumeroVolume,true);
					OnCallCarregaDadosVolumeSelecionado(true);
				}
			}
			#endregion
			#region	Embalagens 
				protected virtual void OnCallShowDialogEmbalagens(ref System.Collections.ArrayList arlEmbalagens)
				{
					if (eCallShowDialogEmbalagens != null)
					{
						if (eCallShowDialogEmbalagens(ref m_typDatSetTbProdutosRomaneioEmbalagensCopy, ref m_typDatSetTbProdutosRomaneioEmbalagensProdutosCopy,ref m_ilEmbalagens,ref arlEmbalagens))
						{
							m_lvConteudo.Items.Clear();
							if (m_lvVolumes.SelectedItems.Count > 0)
							{
								string strNumeroVolume = m_lvVolumes.SelectedItems[0].Text;
								// Carregando os Produtos do Volume 
								OnCallCarregaDadosVolumeProdutos(strNumeroVolume);

								// Carregando as Embalagens do Volume
								OnCallCarregaDadosVolumeEmbalagens(strNumeroVolume);
							} 
						}
					}
				}
			#endregion
			#region Conteudo
				protected virtual void OnCallShowDialogConteudo()
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					bool bInseriuProduto = false;
					bool bInseriuEmbalagem = false;
					System.Collections.ArrayList arlConteudo = new System.Collections.ArrayList();
					for (int nCont = 0 ;nCont < m_lvConteudo.SelectedItems.Count;nCont++)
					{
						if (m_lvConteudo.SelectedItems[nCont].ImageIndex == 2)
						{
							// Produto
							bInseriuProduto = true;
							arlConteudo.Add(m_lvConteudo.SelectedItems[nCont].Tag);
						}else{
							// Embalagem
							bInseriuEmbalagem = true;
							arlConteudo.Add(m_lvConteudo.SelectedItems[nCont].SubItems[1].Text.ToString());
						}
                        
						// Checando
						if (bInseriuProduto && bInseriuEmbalagem)
						{
							mdlMensagens.clsMensagens.ShowInformation("Siscobras.NET",mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlProdutosRomaneio_frmFVolumeInformacoes_EdicaoMultipla));
							//MessageBox.Show("Você não pode editar produtos e embalagens(intermediárias) ao mesmo tempo.","Siscobras.NET",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
							arlConteudo = null;
							break;
						}
					}
					// ShowDialog
					if ((arlConteudo != null) && (arlConteudo.Count > 0))
					{
						if (bInseriuProduto &&  !bInseriuEmbalagem)
						{
							OnCallShowDialogProdutos(ref arlConteudo);
						}
						if (!bInseriuProduto &&  bInseriuEmbalagem)
						{
							OnCallShowDialogEmbalagens(ref arlConteudo);
						}
					}
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}

				protected virtual void OnCallExcluiConteudo()
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

					if (m_lvVolumes.SelectedItems.Count > 0)
					{
						string strNumeroVolume = m_lvVolumes.SelectedItems[0].Text;
						string strPergunta = "";

						System.Collections.ArrayList arlProdutos = new System.Collections.ArrayList();
						System.Collections.ArrayList arlEmbalagens = new System.Collections.ArrayList();
						for (int nCont = 0 ;nCont < m_lvConteudo.SelectedItems.Count;nCont++)
						{
							if (m_lvConteudo.SelectedItems[nCont].ImageIndex == 2)
							{
								// Produto
								arlProdutos.Add(m_lvConteudo.SelectedItems[nCont].Tag);
							}
							else
							{
								// Embalagem
								arlEmbalagens.Add(m_lvConteudo.SelectedItems[nCont].SubItems[1].Text.ToString());
							}
						}

						if (arlProdutos.Count > 0)
						{
							if (arlEmbalagens.Count > 0)
							{
								strPergunta = "Deseja mesmo exlcuir o(s) produto(s) e a(s) embalagem(ns) selecionadas ?";
							}else{
								strPergunta = "Deseja mesmo exlcuir o(s) produto(s) selecionados ?";
							}
						}else{
							if (arlEmbalagens.Count > 0)
							{
								strPergunta = "Deseja mesmo exlcuir a(s) embalagem(ns) selecionadas ?";
							}
						}
						
						if (strPergunta != "")
						{
							if (mdlMensagens.clsMensagens.ShowQuestion("Siscobras.NET",mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlProdutosRomaneio_frmFVolumeInformacoes_PerguntaGeral).Replace("TAG",strPergunta),System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
							{
								if (arlProdutos.Count > 0)
									OnCallExcluiVolumeProdutos(strNumeroVolume,ref arlProdutos);

								if (arlEmbalagens.Count > 0)
									OnCallExcluiVolumeEmbalagens(strNumeroVolume,ref arlEmbalagens);

								m_lvConteudo.Items.Clear();

								// Carregando os Produtos do Volume 
								OnCallCarregaDadosVolumeProdutos(strNumeroVolume);

								// Carregando as Embalagens do Volume
								OnCallCarregaDadosVolumeEmbalagens(strNumeroVolume);

								OnCallCarregaDadosVolumeSelecionado(true);
							}
						}
					}

					this.Cursor = System.Windows.Forms.Cursors.Default;
				}
			#endregion
			#region Volume
				protected virtual void OnCallShowDialogVolumeTipo()
				{
					if ((m_lvVolumes.SelectedItems.Count > 0) && (eCallShowDialogVolumeTipo != null))
					{
						string strNumeroVolume = m_lvVolumes.SelectedItems[0].Text;
						int nTipoVolume = m_nTipoVolume;
						eCallShowDialogVolumeTipo(ref nTipoVolume,ref m_ilVolumes);
						if (m_nTipoVolume != nTipoVolume)
						{
							m_nTipoVolume = nTipoVolume;
							OnCallSalvaDadosVolumeTipo(strNumeroVolume,m_nTipoVolume);
							string strDescricaoTipoVolume;
							string strDescricaoPopularTipoVolume;
							int nIndiceImagemTipoVolume;
							OnCallCarregaInformacoesTipoVolume(m_nTipoVolume,out strDescricaoTipoVolume,out strDescricaoPopularTipoVolume,out nIndiceImagemTipoVolume);
							m_nTipoVolume = nTipoVolume;
							m_txtTipoPopular.Text = strDescricaoTipoVolume;
							m_btTipo.Image = m_ilVolumes.Images[nIndiceImagemTipoVolume];
						}
					}
				}

				protected virtual void OnCallExcluiVolumeEmbalagens(string strNumeroVolume, ref System.Collections.ArrayList arlEmbalagens)
				{
					if (eCallExcluiVolumeEmbalagens != null)
					{
						eCallExcluiVolumeEmbalagens(ref m_typDatSetTbProdutosRomaneioEmbalagensCopy,strNumeroVolume,ref arlEmbalagens);
						mdlProdutosRomaneio.clsProdutosRomaneio.bRecalculaPesoLiquidoVolume(ref m_typDatSetTbProdutosRomaneioVolumesCopy,ref m_typDatSetTbProdutosRomaneioVolumesProdutosCopy,ref m_typDatSetTbProdutosRomaneioEmbalagensCopy,ref m_typDatSetTbProdutosRomaneioEmbalagensProdutosCopy,strNumeroVolume,true);
						OnCallCarregaDadosVolumeSelecionado(true);
					}
				}
			#endregion
			#region Salvamento dos Dados
				protected virtual bool OnCallVolumeInexistente(string strNumeroVolume)
				{
					bool bRetorno = false;
					if (eCallVolumeInexistente != null)
						bRetorno = eCallVolumeInexistente(ref m_typDatSetTbProdutosRomaneioVolumesCopy,strNumeroVolume);
					return(bRetorno);
				}

				protected virtual void OnCallSalvaDadosVolumeNumeroVolume(string strNumeroVolumeAntigo,string strNumeroVolumeNovo)
				{
					if (eCallSalvaDadosVolumeNumeroVolume != null)
						eCallSalvaDadosVolumeNumeroVolume(ref m_typDatSetTbProdutosRomaneioVolumesCopy,ref m_typDatSetTbProdutosRomaneioVolumesProdutosCopy,ref m_typDatSetTbProdutosRomaneioEmbalagensCopy,strNumeroVolumeAntigo,strNumeroVolumeNovo);
				}

				protected virtual void OnCallSalvaDadosVolumeTipo(string strNumeroVolume,int nTipoVolume)
				{
					if (eCallSalvaDadosVolumeTipo != null)
						eCallSalvaDadosVolumeTipo(ref m_typDatSetTbProdutosRomaneioVolumesCopy,strNumeroVolume,nTipoVolume);
				}

				protected virtual void OnCallSalvaDadosVolumeDescricaoPopular(string strNumeroVolume,string strDescricaoPopular)
				{
					if (eCallSalvaDadosVolumeDescricaoPopular != null)
						eCallSalvaDadosVolumeDescricaoPopular(ref m_typDatSetTbProdutosRomaneioVolumesCopy,strNumeroVolume,strDescricaoPopular);
				}

				protected virtual void OnCallSalvaDadosVolumeAltura(string strNumeroVolume,double dAltura)
				{
					if (eCallSalvaDadosVolumeAltura != null)
						eCallSalvaDadosVolumeAltura(ref m_typDatSetTbProdutosRomaneioVolumesCopy,strNumeroVolume,dAltura);
				}

				protected virtual void OnCallSalvaDadosVolumeLargura(string strNumeroVolume,double dLargura)
				{
					if (eCallSalvaDadosVolumeLargura != null)
						eCallSalvaDadosVolumeLargura(ref m_typDatSetTbProdutosRomaneioVolumesCopy,strNumeroVolume,dLargura);
				}

				protected virtual void OnCallSalvaDadosVolumeComprimento(string strNumeroVolume,double dComprimento)
				{
					if (eCallSalvaDadosVolumeComprimento != null)
						eCallSalvaDadosVolumeComprimento(ref m_typDatSetTbProdutosRomaneioVolumesCopy,strNumeroVolume,dComprimento);
				}

				protected virtual void OnCallSalvaDadosVolumeVolume(string strNumeroVolume,double dVolume)
				{
					if (eCallSalvaDadosVolumeVolume != null)
						eCallSalvaDadosVolumeVolume(ref m_typDatSetTbProdutosRomaneioVolumesCopy,strNumeroVolume,dVolume);
				}

				protected virtual void OnCallSalvaDadosVolumePesoLiquido(string strNumeroVolume,double dPesoLiquido)
				{
					if (eCallSalvaDadosVolumePesoLiquido != null)
						eCallSalvaDadosVolumePesoLiquido(ref m_typDatSetTbProdutosRomaneioVolumesCopy,strNumeroVolume,dPesoLiquido);
				}

				protected virtual void OnCallSalvaDadosVolumePesoBruto(string strNumeroVolume,double dPesoBruto)
				{
					if (eCallSalvaDadosVolumePesoBruto != null)
						eCallSalvaDadosVolumePesoBruto(ref m_typDatSetTbProdutosRomaneioVolumesCopy,strNumeroVolume,dPesoBruto);
				}

				protected virtual void OnCallSalvaDadosVolumeAlturaUnidade(string strNumeroVolume,int nUnidadeAltura)
				{
					if (eCallSalvaDadosVolumeAlturaUnidade != null)
						eCallSalvaDadosVolumeAlturaUnidade(ref m_typDatSetTbProdutosRomaneioVolumesCopy,strNumeroVolume,nUnidadeAltura);
				}

				protected virtual void OnCallSalvaDadosVolumeLarguraUnidade(string strNumeroVolume,int nUnidadeLargura)
				{
					if (eCallSalvaDadosVolumeLarguraUnidade != null)
						eCallSalvaDadosVolumeLarguraUnidade(ref m_typDatSetTbProdutosRomaneioVolumesCopy,strNumeroVolume,nUnidadeLargura);
				}

				protected virtual void OnCallSalvaDadosVolumeComprimentoUnidade(string strNumeroVolume,int nUnidadeComprimento)
				{
					if (eCallSalvaDadosVolumeComprimentoUnidade != null)
						eCallSalvaDadosVolumeComprimentoUnidade(ref m_typDatSetTbProdutosRomaneioVolumesCopy,strNumeroVolume,nUnidadeComprimento);
				}

				protected virtual void OnCallSalvaDadosVolumeVolumeUnidade(string strNumeroVolume,int nUnidadeVolume)
				{
					if (eCallSalvaDadosVolumeVolumeUnidade != null)
						eCallSalvaDadosVolumeVolumeUnidade(ref m_typDatSetTbProdutosRomaneioVolumesCopy,strNumeroVolume,nUnidadeVolume);
				}

				protected virtual void OnCallSalvaDadosVolumePesoLiquidoUnidade(string strNumeroVolume,int nUnidadePesoLiquido)
				{
					if (eCallSalvaDadosVolumePesoLiquidoUnidade != null)
						eCallSalvaDadosVolumePesoLiquidoUnidade(ref m_typDatSetTbProdutosRomaneioVolumesCopy,strNumeroVolume,nUnidadePesoLiquido);
				}

				protected virtual void OnCallSalvaDadosVolumePesoBrutoUnidade(string strNumeroVolume,int nUnidadePesoBruto)
				{
					if (eCallSalvaDadosVolumePesoBrutoUnidade != null)
						eCallSalvaDadosVolumePesoBrutoUnidade(ref m_typDatSetTbProdutosRomaneioVolumesCopy,strNumeroVolume,nUnidadePesoBruto);
				}
			#endregion
		#endregion

		#region Constructor and Destructors
			public frmFVolumeInformacoes(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, string strEnderecoExecutavel,mdlDataBaseAccess.Tabelas.XsdTbVolumes typDatSetTbVolumes,mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetTbProdutosRomaneioVolumes,mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos typDatSetTbProdutosRomaneioVolumesProdutos,mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens typDatSetTbProdutosRomaneioEmbalagens,mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos typDatSetTbProdutosRomaneioEmbalagensProdutos,ref System.Windows.Forms.ImageList ilVolumes,ref System.Windows.Forms.ImageList ilEmbalagens,ref System.Collections.ArrayList arlVolumes)
			{
				m_cls_ter_tratadorErro = tratadorErro;
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				m_arlVolumes = arlVolumes;
				m_ilVolumes = ilVolumes;
				m_ilEmbalagens = ilEmbalagens;

				// Typed DataSets Clones
				m_typDatSetTbVolumesCopy = (mdlDataBaseAccess.Tabelas.XsdTbVolumes)typDatSetTbVolumes.Copy();
				m_typDatSetTbProdutosRomaneioVolumesCopy = (mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes)typDatSetTbProdutosRomaneioVolumes.Copy();
				m_typDatSetTbProdutosRomaneioVolumesProdutosCopy = (mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos)typDatSetTbProdutosRomaneioVolumesProdutos.Copy();
				m_typDatSetTbProdutosRomaneioEmbalagensCopy = (mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens)typDatSetTbProdutosRomaneioEmbalagens.Copy();
				m_typDatSetTbProdutosRomaneioEmbalagensProdutosCopy = (mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos)typDatSetTbProdutosRomaneioEmbalagensProdutos.Copy();

				InitializeComponent();

				m_lvVolumes.SmallImageList = m_ilVolumes;
				m_lvVolumes.LargeImageList = m_ilVolumes;
				m_lvConteudo.SmallImageList = m_ilEmbalagens;
				m_lvConteudo.LargeImageList = m_ilEmbalagens;
			}

			protected override void Dispose( bool disposing )
			{
				if( disposing )
				{
					if(components != null)
					{
						components.Dispose();
					}
				}
				base.Dispose( disposing );
			}
			#endregion
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFVolumeInformacoes));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_gbInformacoesVolume = new System.Windows.Forms.GroupBox();
			this.m_gbInformacoes = new System.Windows.Forms.GroupBox();
			this.m_txtNumeroVolume = new mdlComponentesGraficos.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.m_txtTipoPopular = new mdlComponentesGraficos.TextBox();
			this.m_lbPE = new System.Windows.Forms.Label();
			this.m_btTipo = new System.Windows.Forms.Button();
			this.m_lbNumeroVolume = new System.Windows.Forms.Label();
			this.m_btUnidadePesoBruto = new System.Windows.Forms.Button();
			this.m_txtPesoBruto = new mdlComponentesGraficos.TextBox();
			this.m_lbPesoBruto = new System.Windows.Forms.Label();
			this.m_btUnidadePesoLiquido = new System.Windows.Forms.Button();
			this.m_txtPesoLiquido = new mdlComponentesGraficos.TextBox();
			this.m_lbPesoLiquido = new System.Windows.Forms.Label();
			this.m_btUnidadeVolume = new System.Windows.Forms.Button();
			this.m_btUnidadeComprimento = new System.Windows.Forms.Button();
			this.m_btUnidadeLargura = new System.Windows.Forms.Button();
			this.m_btUnidadeAltura = new System.Windows.Forms.Button();
			this.m_txtVolume = new mdlComponentesGraficos.TextBox();
			this.m_txtComprimento = new mdlComponentesGraficos.TextBox();
			this.m_txtLargura = new mdlComponentesGraficos.TextBox();
			this.m_txtAltura = new mdlComponentesGraficos.TextBox();
			this.m_lbVolume = new System.Windows.Forms.Label();
			this.m_lbLargura = new System.Windows.Forms.Label();
			this.m_lbComprimento = new System.Windows.Forms.Label();
			this.m_lbAltura = new System.Windows.Forms.Label();
			this.m_gbConteudo = new System.Windows.Forms.GroupBox();
			this.m_btConteudoExcluir = new System.Windows.Forms.Button();
			this.m_btConteudoEditar = new System.Windows.Forms.Button();
			this.m_lvConteudo = new mdlComponentesGraficos.ListView();
			this.m_colConteudoQuantidade = new System.Windows.Forms.ColumnHeader();
			this.m_colConteudoDescricao = new System.Windows.Forms.ColumnHeader();
			this.m_colConteudoPesoLiquido = new System.Windows.Forms.ColumnHeader();
			this.m_gbVolume = new System.Windows.Forms.GroupBox();
			this.m_lvVolumes = new mdlComponentesGraficos.ListView();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_ttDica = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbGeral.SuspendLayout();
			this.m_gbInformacoesVolume.SuspendLayout();
			this.m_gbInformacoes.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.m_gbConteudo.SuspendLayout();
			this.m_gbVolume.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Controls.Add(this.m_gbInformacoesVolume);
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Location = new System.Drawing.Point(5, -1);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(555, 441);
			this.m_gbGeral.TabIndex = 0;
			this.m_gbGeral.TabStop = false;
			// 
			// m_gbInformacoesVolume
			// 
			this.m_gbInformacoesVolume.Controls.Add(this.m_gbInformacoes);
			this.m_gbInformacoesVolume.Controls.Add(this.m_gbVolume);
			this.m_gbInformacoesVolume.Location = new System.Drawing.Point(8, 8);
			this.m_gbInformacoesVolume.Name = "m_gbInformacoesVolume";
			this.m_gbInformacoesVolume.Size = new System.Drawing.Size(536, 392);
			this.m_gbInformacoesVolume.TabIndex = 0;
			this.m_gbInformacoesVolume.TabStop = false;
			// 
			// m_gbInformacoes
			// 
			this.m_gbInformacoes.Controls.Add(this.m_txtNumeroVolume);
			this.m_gbInformacoes.Controls.Add(this.groupBox1);
			this.m_gbInformacoes.Controls.Add(this.m_lbNumeroVolume);
			this.m_gbInformacoes.Controls.Add(this.m_btUnidadePesoBruto);
			this.m_gbInformacoes.Controls.Add(this.m_txtPesoBruto);
			this.m_gbInformacoes.Controls.Add(this.m_lbPesoBruto);
			this.m_gbInformacoes.Controls.Add(this.m_btUnidadePesoLiquido);
			this.m_gbInformacoes.Controls.Add(this.m_txtPesoLiquido);
			this.m_gbInformacoes.Controls.Add(this.m_lbPesoLiquido);
			this.m_gbInformacoes.Controls.Add(this.m_btUnidadeVolume);
			this.m_gbInformacoes.Controls.Add(this.m_btUnidadeComprimento);
			this.m_gbInformacoes.Controls.Add(this.m_btUnidadeLargura);
			this.m_gbInformacoes.Controls.Add(this.m_btUnidadeAltura);
			this.m_gbInformacoes.Controls.Add(this.m_txtVolume);
			this.m_gbInformacoes.Controls.Add(this.m_txtComprimento);
			this.m_gbInformacoes.Controls.Add(this.m_txtLargura);
			this.m_gbInformacoes.Controls.Add(this.m_txtAltura);
			this.m_gbInformacoes.Controls.Add(this.m_lbVolume);
			this.m_gbInformacoes.Controls.Add(this.m_lbLargura);
			this.m_gbInformacoes.Controls.Add(this.m_lbComprimento);
			this.m_gbInformacoes.Controls.Add(this.m_lbAltura);
			this.m_gbInformacoes.Controls.Add(this.m_gbConteudo);
			this.m_gbInformacoes.Location = new System.Drawing.Point(8, 88);
			this.m_gbInformacoes.Name = "m_gbInformacoes";
			this.m_gbInformacoes.Size = new System.Drawing.Size(520, 296);
			this.m_gbInformacoes.TabIndex = 1;
			this.m_gbInformacoes.TabStop = false;
			this.m_gbInformacoes.Text = "Informações";
			// 
			// m_txtNumeroVolume
			// 
			this.m_txtNumeroVolume.Location = new System.Drawing.Point(93, 17);
			this.m_txtNumeroVolume.Name = "m_txtNumeroVolume";
			this.m_txtNumeroVolume.Size = new System.Drawing.Size(115, 20);
			this.m_txtNumeroVolume.TabIndex = 0;
			this.m_txtNumeroVolume.Text = "";
			this.m_txtNumeroVolume.Leave += new System.EventHandler(this.m_txtNumeroVolume_Leave);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.m_txtTipoPopular);
			this.groupBox1.Controls.Add(this.m_lbPE);
			this.groupBox1.Controls.Add(this.m_btTipo);
			this.groupBox1.Location = new System.Drawing.Point(253, 7);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(259, 73);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Volume";
			// 
			// m_txtTipoPopular
			// 
			this.m_txtTipoPopular.Location = new System.Drawing.Point(88, 26);
			this.m_txtTipoPopular.Name = "m_txtTipoPopular";
			this.m_txtTipoPopular.Size = new System.Drawing.Size(160, 20);
			this.m_txtTipoPopular.TabIndex = 1;
			this.m_txtTipoPopular.Text = "";
			this.m_txtTipoPopular.Leave += new System.EventHandler(this.m_txtTipoPopular_Leave);
			// 
			// m_lbPE
			// 
			this.m_lbPE.Location = new System.Drawing.Point(41, 32);
			this.m_lbPE.Name = "m_lbPE";
			this.m_lbPE.Size = new System.Drawing.Size(55, 16);
			this.m_lbPE.TabIndex = 76;
			this.m_lbPE.Text = "Espécie:";
			// 
			// m_btTipo
			// 
			this.m_btTipo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btTipo.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.m_btTipo.Location = new System.Drawing.Point(9, 25);
			this.m_btTipo.Name = "m_btTipo";
			this.m_btTipo.Size = new System.Drawing.Size(27, 26);
			this.m_btTipo.TabIndex = 0;
			this.m_ttDica.SetToolTip(this.m_btTipo, "Troca o tipo de embalagem ");
			this.m_btTipo.Click += new System.EventHandler(this.m_btTipo_Click);
			// 
			// m_lbNumeroVolume
			// 
			this.m_lbNumeroVolume.Location = new System.Drawing.Point(13, 20);
			this.m_lbNumeroVolume.Name = "m_lbNumeroVolume";
			this.m_lbNumeroVolume.Size = new System.Drawing.Size(48, 16);
			this.m_lbNumeroVolume.TabIndex = 77;
			this.m_lbNumeroVolume.Text = "Número:";
			// 
			// m_btUnidadePesoBruto
			// 
			this.m_btUnidadePesoBruto.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btUnidadePesoBruto.Location = new System.Drawing.Point(453, 104);
			this.m_btUnidadePesoBruto.Name = "m_btUnidadePesoBruto";
			this.m_btUnidadePesoBruto.Size = new System.Drawing.Size(37, 20);
			this.m_btUnidadePesoBruto.TabIndex = 13;
			this.m_btUnidadePesoBruto.Text = "kg";
			this.m_ttDica.SetToolTip(this.m_btUnidadePesoBruto, "Troca a unidade do peso bruto");
			this.m_btUnidadePesoBruto.Click += new System.EventHandler(this.m_btUnidadePesoBruto_Click);
			// 
			// m_txtPesoBruto
			// 
			this.m_txtPesoBruto.Location = new System.Drawing.Point(334, 104);
			this.m_txtPesoBruto.Name = "m_txtPesoBruto";
			this.m_txtPesoBruto.OnlyNumbers = true;
			this.m_txtPesoBruto.Size = new System.Drawing.Size(111, 20);
			this.m_txtPesoBruto.TabIndex = 12;
			this.m_txtPesoBruto.Text = "";
			this.m_txtPesoBruto.Leave += new System.EventHandler(this.m_txtPesoBruto_Leave);
			// 
			// m_lbPesoBruto
			// 
			this.m_lbPesoBruto.Location = new System.Drawing.Point(256, 104);
			this.m_lbPesoBruto.Name = "m_lbPesoBruto";
			this.m_lbPesoBruto.Size = new System.Drawing.Size(80, 16);
			this.m_lbPesoBruto.TabIndex = 37;
			this.m_lbPesoBruto.Text = "Peso Bruto:";
			// 
			// m_btUnidadePesoLiquido
			// 
			this.m_btUnidadePesoLiquido.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btUnidadePesoLiquido.Location = new System.Drawing.Point(211, 104);
			this.m_btUnidadePesoLiquido.Name = "m_btUnidadePesoLiquido";
			this.m_btUnidadePesoLiquido.Size = new System.Drawing.Size(37, 20);
			this.m_btUnidadePesoLiquido.TabIndex = 8;
			this.m_btUnidadePesoLiquido.Text = "kg";
			this.m_ttDica.SetToolTip(this.m_btUnidadePesoLiquido, "Troca a unidade do peso liquido");
			this.m_btUnidadePesoLiquido.Click += new System.EventHandler(this.m_btUnidadePesoLiquido_Click);
			// 
			// m_txtPesoLiquido
			// 
			this.m_txtPesoLiquido.Location = new System.Drawing.Point(94, 103);
			this.m_txtPesoLiquido.Name = "m_txtPesoLiquido";
			this.m_txtPesoLiquido.OnlyNumbers = true;
			this.m_txtPesoLiquido.Size = new System.Drawing.Size(111, 20);
			this.m_txtPesoLiquido.TabIndex = 7;
			this.m_txtPesoLiquido.Text = "";
			this.m_txtPesoLiquido.Leave += new System.EventHandler(this.m_txtPesoLiquido_Leave);
			// 
			// m_lbPesoLiquido
			// 
			this.m_lbPesoLiquido.Location = new System.Drawing.Point(16, 104);
			this.m_lbPesoLiquido.Name = "m_lbPesoLiquido";
			this.m_lbPesoLiquido.Size = new System.Drawing.Size(80, 16);
			this.m_lbPesoLiquido.TabIndex = 34;
			this.m_lbPesoLiquido.Text = "Peso Liquido:";
			// 
			// m_btUnidadeVolume
			// 
			this.m_btUnidadeVolume.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btUnidadeVolume.Location = new System.Drawing.Point(453, 84);
			this.m_btUnidadeVolume.Name = "m_btUnidadeVolume";
			this.m_btUnidadeVolume.Size = new System.Drawing.Size(37, 20);
			this.m_btUnidadeVolume.TabIndex = 11;
			this.m_btUnidadeVolume.Text = "cm3";
			this.m_ttDica.SetToolTip(this.m_btUnidadeVolume, "Troca a unidade do volume cúbico");
			this.m_btUnidadeVolume.Click += new System.EventHandler(this.m_btUnidadeVolume_Click);
			// 
			// m_btUnidadeComprimento
			// 
			this.m_btUnidadeComprimento.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btUnidadeComprimento.Location = new System.Drawing.Point(211, 82);
			this.m_btUnidadeComprimento.Name = "m_btUnidadeComprimento";
			this.m_btUnidadeComprimento.Size = new System.Drawing.Size(37, 20);
			this.m_btUnidadeComprimento.TabIndex = 6;
			this.m_btUnidadeComprimento.Text = "cm";
			this.m_ttDica.SetToolTip(this.m_btUnidadeComprimento, "Troca a unidade do comprimento");
			this.m_btUnidadeComprimento.Click += new System.EventHandler(this.m_btUnidadeComprimento_Click);
			// 
			// m_btUnidadeLargura
			// 
			this.m_btUnidadeLargura.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btUnidadeLargura.Location = new System.Drawing.Point(211, 60);
			this.m_btUnidadeLargura.Name = "m_btUnidadeLargura";
			this.m_btUnidadeLargura.Size = new System.Drawing.Size(37, 20);
			this.m_btUnidadeLargura.TabIndex = 4;
			this.m_btUnidadeLargura.Text = "cm";
			this.m_ttDica.SetToolTip(this.m_btUnidadeLargura, "Troca a unidade da largura");
			this.m_btUnidadeLargura.Click += new System.EventHandler(this.m_btUnidadeLargura_Click);
			// 
			// m_btUnidadeAltura
			// 
			this.m_btUnidadeAltura.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btUnidadeAltura.Location = new System.Drawing.Point(211, 39);
			this.m_btUnidadeAltura.Name = "m_btUnidadeAltura";
			this.m_btUnidadeAltura.Size = new System.Drawing.Size(37, 20);
			this.m_btUnidadeAltura.TabIndex = 2;
			this.m_btUnidadeAltura.Text = "cm";
			this.m_ttDica.SetToolTip(this.m_btUnidadeAltura, "Troca a unidade da altura");
			this.m_btUnidadeAltura.Click += new System.EventHandler(this.m_btUnidadeAltura_Click);
			// 
			// m_txtVolume
			// 
			this.m_txtVolume.Location = new System.Drawing.Point(334, 83);
			this.m_txtVolume.Name = "m_txtVolume";
			this.m_txtVolume.OnlyNumbers = true;
			this.m_txtVolume.Size = new System.Drawing.Size(111, 20);
			this.m_txtVolume.TabIndex = 10;
			this.m_txtVolume.Text = "";
			this.m_txtVolume.Leave += new System.EventHandler(this.m_txtVolume_Leave);
			// 
			// m_txtComprimento
			// 
			this.m_txtComprimento.Location = new System.Drawing.Point(94, 80);
			this.m_txtComprimento.Name = "m_txtComprimento";
			this.m_txtComprimento.OnlyNumbers = true;
			this.m_txtComprimento.Size = new System.Drawing.Size(111, 20);
			this.m_txtComprimento.TabIndex = 5;
			this.m_txtComprimento.Text = "";
			this.m_txtComprimento.Leave += new System.EventHandler(this.m_txtComprimento_Leave);
			this.m_txtComprimento.TextChanged += new System.EventHandler(this.m_txtComprimento_TextChanged);
			// 
			// m_txtLargura
			// 
			this.m_txtLargura.Location = new System.Drawing.Point(94, 58);
			this.m_txtLargura.Name = "m_txtLargura";
			this.m_txtLargura.OnlyNumbers = true;
			this.m_txtLargura.Size = new System.Drawing.Size(114, 20);
			this.m_txtLargura.TabIndex = 3;
			this.m_txtLargura.Text = "";
			this.m_txtLargura.Leave += new System.EventHandler(this.m_txtLargura_Leave);
			this.m_txtLargura.TextChanged += new System.EventHandler(this.m_txtLargura_TextChanged);
			// 
			// m_txtAltura
			// 
			this.m_txtAltura.Location = new System.Drawing.Point(93, 39);
			this.m_txtAltura.Name = "m_txtAltura";
			this.m_txtAltura.OnlyNumbers = true;
			this.m_txtAltura.Size = new System.Drawing.Size(115, 20);
			this.m_txtAltura.TabIndex = 1;
			this.m_txtAltura.Text = "";
			this.m_txtAltura.Leave += new System.EventHandler(this.m_txtAltura_Leave);
			this.m_txtAltura.TextChanged += new System.EventHandler(this.m_txtAltura_TextChanged);
			// 
			// m_lbVolume
			// 
			this.m_lbVolume.Location = new System.Drawing.Point(256, 85);
			this.m_lbVolume.Name = "m_lbVolume";
			this.m_lbVolume.Size = new System.Drawing.Size(72, 16);
			this.m_lbVolume.TabIndex = 9;
			this.m_lbVolume.Text = "Volume cub:";
			// 
			// m_lbLargura
			// 
			this.m_lbLargura.Location = new System.Drawing.Point(15, 59);
			this.m_lbLargura.Name = "m_lbLargura";
			this.m_lbLargura.Size = new System.Drawing.Size(72, 16);
			this.m_lbLargura.TabIndex = 24;
			this.m_lbLargura.Text = "Largura:";
			// 
			// m_lbComprimento
			// 
			this.m_lbComprimento.Location = new System.Drawing.Point(13, 79);
			this.m_lbComprimento.Name = "m_lbComprimento";
			this.m_lbComprimento.Size = new System.Drawing.Size(80, 16);
			this.m_lbComprimento.TabIndex = 23;
			this.m_lbComprimento.Text = "Comprimento:";
			// 
			// m_lbAltura
			// 
			this.m_lbAltura.Location = new System.Drawing.Point(14, 39);
			this.m_lbAltura.Name = "m_lbAltura";
			this.m_lbAltura.Size = new System.Drawing.Size(72, 16);
			this.m_lbAltura.TabIndex = 22;
			this.m_lbAltura.Text = "Altura:";
			// 
			// m_gbConteudo
			// 
			this.m_gbConteudo.Controls.Add(this.m_btConteudoExcluir);
			this.m_gbConteudo.Controls.Add(this.m_btConteudoEditar);
			this.m_gbConteudo.Controls.Add(this.m_lvConteudo);
			this.m_gbConteudo.Location = new System.Drawing.Point(8, 128);
			this.m_gbConteudo.Name = "m_gbConteudo";
			this.m_gbConteudo.Size = new System.Drawing.Size(504, 160);
			this.m_gbConteudo.TabIndex = 14;
			this.m_gbConteudo.TabStop = false;
			this.m_gbConteudo.Text = "Conteúdo";
			// 
			// m_btConteudoExcluir
			// 
			this.m_btConteudoExcluir.BackColor = System.Drawing.SystemColors.Control;
			this.m_btConteudoExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btConteudoExcluir.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btConteudoExcluir.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btConteudoExcluir.Image = ((System.Drawing.Image)(resources.GetObject("m_btConteudoExcluir.Image")));
			this.m_btConteudoExcluir.Location = new System.Drawing.Point(254, 13);
			this.m_btConteudoExcluir.Name = "m_btConteudoExcluir";
			this.m_btConteudoExcluir.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btConteudoExcluir.Size = new System.Drawing.Size(25, 25);
			this.m_btConteudoExcluir.TabIndex = 1;
			this.m_btConteudoExcluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDica.SetToolTip(this.m_btConteudoExcluir, "Exclui os produtos/embalagens selecionados");
			this.m_btConteudoExcluir.Click += new System.EventHandler(this.m_btEmbalagemExcluir_Click);
			// 
			// m_btConteudoEditar
			// 
			this.m_btConteudoEditar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btConteudoEditar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btConteudoEditar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btConteudoEditar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btConteudoEditar.Image = ((System.Drawing.Image)(resources.GetObject("m_btConteudoEditar.Image")));
			this.m_btConteudoEditar.Location = new System.Drawing.Point(222, 13);
			this.m_btConteudoEditar.Name = "m_btConteudoEditar";
			this.m_btConteudoEditar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btConteudoEditar.Size = new System.Drawing.Size(25, 25);
			this.m_btConteudoEditar.TabIndex = 0;
			this.m_btConteudoEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDica.SetToolTip(this.m_btConteudoEditar, "Edita os produtos/embalagens selecionados");
			this.m_btConteudoEditar.Click += new System.EventHandler(this.m_btEmbalagemEditar_Click);
			// 
			// m_lvConteudo
			// 
			this.m_lvConteudo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						   this.m_colConteudoQuantidade,
																						   this.m_colConteudoDescricao,
																						   this.m_colConteudoPesoLiquido});
			this.m_lvConteudo.FullRowSelect = true;
			this.m_lvConteudo.HideSelection = false;
			this.m_lvConteudo.Location = new System.Drawing.Point(6, 40);
			this.m_lvConteudo.Name = "m_lvConteudo";
			this.m_lvConteudo.Size = new System.Drawing.Size(490, 112);
			this.m_lvConteudo.TabIndex = 2;
			this.m_lvConteudo.View = System.Windows.Forms.View.Details;
			this.m_lvConteudo.DoubleClick += new System.EventHandler(this.m_lvEmbalagens_DoubleClick);
			// 
			// m_colConteudoQuantidade
			// 
			this.m_colConteudoQuantidade.Text = "Quantidade";
			this.m_colConteudoQuantidade.Width = 77;
			// 
			// m_colConteudoDescricao
			// 
			this.m_colConteudoDescricao.Text = "Descrição";
			this.m_colConteudoDescricao.Width = 311;
			// 
			// m_colConteudoPesoLiquido
			// 
			this.m_colConteudoPesoLiquido.Text = "Peso Liquido";
			this.m_colConteudoPesoLiquido.Width = 98;
			// 
			// m_gbVolume
			// 
			this.m_gbVolume.Controls.Add(this.m_lvVolumes);
			this.m_gbVolume.Location = new System.Drawing.Point(8, 8);
			this.m_gbVolume.Name = "m_gbVolume";
			this.m_gbVolume.Size = new System.Drawing.Size(520, 72);
			this.m_gbVolume.TabIndex = 0;
			this.m_gbVolume.TabStop = false;
			this.m_gbVolume.Text = "Volumes";
			// 
			// m_lvVolumes
			// 
			this.m_lvVolumes.HideSelection = false;
			this.m_lvVolumes.Location = new System.Drawing.Point(8, 13);
			this.m_lvVolumes.Name = "m_lvVolumes";
			this.m_lvVolumes.Size = new System.Drawing.Size(504, 51);
			this.m_lvVolumes.TabIndex = 0;
			this.m_lvVolumes.SelectedIndexChanged += new System.EventHandler(this.m_lvVolumes_SelectedIndexChanged);
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(216, 406);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 1;
			this.m_ttDica.SetToolTip(this.m_btOk, "Confirmar");
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(280, 406);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 2;
			this.m_ttDica.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_ttDica
			// 
			this.m_ttDica.AutomaticDelay = 100;
			this.m_ttDica.AutoPopDelay = 5000;
			this.m_ttDica.InitialDelay = 100;
			this.m_ttDica.ReshowDelay = 20;
			// 
			// frmFVolumeInformacoes
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(570, 448);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmFVolumeInformacoes";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Informações do Volume";
			this.Load += new System.EventHandler(this.frmFVolumeInformacoes_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbInformacoesVolume.ResumeLayout(false);
			this.m_gbInformacoes.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.m_gbConteudo.ResumeLayout(false);
			this.m_gbVolume.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFVolumeInformacoes_Load(object sender, System.EventArgs e)
				{
					MostraCor();
					OnCallCarregaDadosVolumes();
					if (m_lvVolumes.Items.Count > 0)
					{
						m_lvVolumes.Items[0].Selected = true;
						OnCallCarregaDadosVolumeSelecionado(false);
					}
				}
			#endregion
			#region Botoes
				private void m_btUnidadeAltura_Click(object sender, System.EventArgs e)
				{
					if (m_lvVolumes.SelectedItems.Count > 0)
					{
						string strNumeroVolumeListView = m_lvVolumes.SelectedItems[0].Text.Trim();
	                    m_nUnidadeMetricaAltura = clsProdutosRomaneio.nRetornaProximaUnidadeMetrica(m_nUnidadeMetricaAltura);
						m_btUnidadeAltura.Text = OnCallRetornaSiglaUnidadeEspaco(m_nUnidadeMetricaAltura);
						OnCallSalvaDadosVolumeAlturaUnidade(strNumeroVolumeListView,m_nUnidadeMetricaAltura);
						vRefreshVolumeCubico();
					}
				}

				private void m_btUnidadeLargura_Click(object sender, System.EventArgs e)
				{
					if (m_lvVolumes.SelectedItems.Count > 0)
					{
						string strNumeroVolumeListView = m_lvVolumes.SelectedItems[0].Text.Trim();
						m_nUnidadeMetricaLargura = clsProdutosRomaneio.nRetornaProximaUnidadeMetrica(m_nUnidadeMetricaLargura);
						m_btUnidadeLargura.Text = OnCallRetornaSiglaUnidadeEspaco(m_nUnidadeMetricaLargura);
						OnCallSalvaDadosVolumeLarguraUnidade(strNumeroVolumeListView,m_nUnidadeMetricaLargura);
						vRefreshVolumeCubico();
					}
				}

				private void m_btUnidadeComprimento_Click(object sender, System.EventArgs e)
				{
					if (m_lvVolumes.SelectedItems.Count > 0)
					{
						string strNumeroVolumeListView = m_lvVolumes.SelectedItems[0].Text.Trim();
						m_nUnidadeMetricaComprimento = clsProdutosRomaneio.nRetornaProximaUnidadeMetrica(m_nUnidadeMetricaComprimento);
						m_btUnidadeComprimento.Text = OnCallRetornaSiglaUnidadeEspaco(m_nUnidadeMetricaComprimento);
						OnCallSalvaDadosVolumeComprimentoUnidade(strNumeroVolumeListView,m_nUnidadeMetricaComprimento);
						vRefreshVolumeCubico();
					}
				}

				private void m_btUnidadeVolume_Click(object sender, System.EventArgs e)
				{
					if (m_lvVolumes.SelectedItems.Count > 0)
					{
						string strNumeroVolumeListView = m_lvVolumes.SelectedItems[0].Text.Trim();
						m_nUnidadeMetricaVolume = clsProdutosRomaneio.nRetornaProximaUnidadeMetrica(m_nUnidadeMetricaVolume);
						m_btUnidadeVolume.Text = OnCallRetornaSiglaUnidadeEspaco(m_nUnidadeMetricaVolume) + 3;
						OnCallSalvaDadosVolumeVolumeUnidade(strNumeroVolumeListView,m_nUnidadeMetricaVolume);
						vRefreshVolumeCubico();
					}
				}

				private void m_btUnidadePesoLiquido_Click(object sender, System.EventArgs e)
				{
					if (m_lvVolumes.SelectedItems.Count > 0)
					{
						string strNumeroVolumeListView = m_lvVolumes.SelectedItems[0].Text.Trim();
						m_nUnidadeMassaPesoLiquido = clsProdutosRomaneio.nRetornaProximaUnidadeMassa(m_nUnidadeMassaPesoLiquido);
						m_btUnidadePesoLiquido.Text = OnCallRetornaSiglaUnidadeMassa(m_nUnidadeMassaPesoLiquido);
						OnCallSalvaDadosVolumePesoLiquidoUnidade(strNumeroVolumeListView,m_nUnidadeMassaPesoLiquido);
					}
				}

				private void m_btUnidadePesoBruto_Click(object sender, System.EventArgs e)
				{
					if (m_lvVolumes.SelectedItems.Count > 0)
					{
						string strNumeroVolumeListView = m_lvVolumes.SelectedItems[0].Text.Trim();
						m_nUnidadeMassaPesoBruto = clsProdutosRomaneio.nRetornaProximaUnidadeMassa(m_nUnidadeMassaPesoBruto);
						m_btUnidadePesoBruto.Text = OnCallRetornaSiglaUnidadeMassa(m_nUnidadeMassaPesoBruto);
						OnCallSalvaDadosVolumePesoBrutoUnidade(strNumeroVolumeListView,m_nUnidadeMassaPesoBruto);
					}
				}

				private void m_btTipo_Click(object sender, System.EventArgs e)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					OnCallShowDialogVolumeTipo();
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}

				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					m_bModificado = true;
					this.Close();
				}

				private void m_btCancelar_Click(object sender, System.EventArgs e)
				{
					m_bModificado = false;
					this.Close();
				}
			#endregion
			#region TextBoxes
		        /// <summary>
		        /// Salva o novo numero do Volume
		        /// </summary>
		        /// <param name="sender"></param>
		        /// <param name="e"></param>
				private void m_txtNumeroVolume_Leave(object sender, System.EventArgs e)
				{
					if (m_lvVolumes.SelectedItems.Count > 0)
					{
						string strNumeroVolumeListView = m_lvVolumes.SelectedItems[0].Text.Trim();
						string strNumeroVolumeTextBox = m_txtNumeroVolume.Text.Trim();
						if (strNumeroVolumeTextBox == "")
						{
							m_txtNumeroVolume.Text = strNumeroVolumeListView;
							mdlMensagens.clsMensagens.ShowInformation("Siscobras.NET",mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlProdutosRomaneio_frmFVolumeInformacoes_IdentificarEmbalagem));
							m_txtNumeroVolume.Focus();
						}else{
							if (strNumeroVolumeTextBox != strNumeroVolumeListView)
							{
								if (!OnCallVolumeInexistente(strNumeroVolumeTextBox))
								{
									m_txtNumeroVolume.Text = strNumeroVolumeListView;
									mdlMensagens.clsMensagens.ShowInformation("Siscobras.NET",mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlProdutosRomaneio_frmFVolumeInformacoes_EmbalagemDuplicada));
									m_txtNumeroVolume.Focus();
								}else{
									OnCallSalvaDadosVolumeNumeroVolume(strNumeroVolumeListView,strNumeroVolumeTextBox);
									for(int nCont = 0;nCont < m_arlVolumes.Count;nCont++)
									{
										if (m_arlVolumes[nCont].ToString() == strNumeroVolumeListView)
										{
											m_arlVolumes[nCont] = strNumeroVolumeTextBox;
											break;
										}
									}
									OnCallCarregaDadosVolumes();
									for (int nCont = 0; nCont < m_lvVolumes.Items.Count;nCont++)
									{
										if (m_lvVolumes.Items[nCont].Text == strNumeroVolumeTextBox)
										{
											m_lvVolumes.Items[nCont].Selected = true;
											OnCallCarregaDadosVolumeSelecionado(false);
											break;
										}
									}
								}
							}
						}
					}
				}

				private void m_txtTipoPopular_Leave(object sender, System.EventArgs e)
				{
					if (m_lvVolumes.SelectedItems.Count > 0)
					{
						string strNumeroVolumeListView = m_lvVolumes.SelectedItems[0].Text.Trim();
						string strDado = m_txtTipoPopular.Text.Trim();
						OnCallSalvaDadosVolumeDescricaoPopular(strNumeroVolumeListView,strDado);
					}
				}

				private void m_txtAltura_Leave(object sender, System.EventArgs e)
				{
					if (m_lvVolumes.SelectedItems.Count > 0)
					{
						string strNumeroVolumeListView = m_lvVolumes.SelectedItems[0].Text.Trim();
						string strDado = m_txtAltura.Text.Trim();
						if (strDado == "")
							strDado = "0";
						OnCallSalvaDadosVolumeAltura(strNumeroVolumeListView,Double.Parse(strDado));
					}
				}

				private void m_txtLargura_Leave(object sender, System.EventArgs e)
				{
					if (m_lvVolumes.SelectedItems.Count > 0)
					{
						string strNumeroVolumeListView = m_lvVolumes.SelectedItems[0].Text.Trim();
						string strDado = m_txtLargura.Text.Trim();
						if (strDado == "")
							strDado = "0";
						OnCallSalvaDadosVolumeLargura(strNumeroVolumeListView,Double.Parse(strDado));
					}
				}

				private void m_txtComprimento_Leave(object sender, System.EventArgs e)
				{
					if (m_lvVolumes.SelectedItems.Count > 0)
					{
						string strNumeroVolumeListView = m_lvVolumes.SelectedItems[0].Text.Trim();
						string strDado = m_txtComprimento.Text.Trim();
						if (strDado == "")
							strDado = "0";
						OnCallSalvaDadosVolumeComprimento(strNumeroVolumeListView,Double.Parse(strDado));
					}
				}

				private void m_txtPesoLiquido_Leave(object sender, System.EventArgs e)
				{
					if (m_lvVolumes.SelectedItems.Count > 0)
					{
						string strNumeroVolumeListView = m_lvVolumes.SelectedItems[0].Text.Trim();
						string strDado = m_txtPesoLiquido.Text.Trim();
						if (strDado == "")
							strDado = "0";
						OnCallSalvaDadosVolumePesoLiquido(strNumeroVolumeListView,Double.Parse(strDado));
					}
				}

				private void m_txtVolume_Leave(object sender, System.EventArgs e)
				{
					if (m_lvVolumes.SelectedItems.Count > 0)
					{
						string strNumeroVolumeListView = m_lvVolumes.SelectedItems[0].Text.Trim();
						string strDado = m_txtVolume.Text.Trim();
						if (strDado == "")
							strDado = "0";
						OnCallSalvaDadosVolumeVolume(strNumeroVolumeListView,Double.Parse(strDado));
					}
				}

				private void m_txtPesoBruto_Leave(object sender, System.EventArgs e)
				{
					if (m_lvVolumes.SelectedItems.Count > 0)
					{
						string strNumeroVolumeListView = m_lvVolumes.SelectedItems[0].Text.Trim();
						string strDado = m_txtPesoBruto.Text.Trim();
						if (strDado == "")
							strDado = "0";
						OnCallSalvaDadosVolumePesoBruto(strNumeroVolumeListView,Double.Parse(strDado));
					}
				}

				private void m_txtAltura_TextChanged(object sender, System.EventArgs e)
				{
					vRefreshVolumeCubico();
				}

				private void m_txtLargura_TextChanged(object sender, System.EventArgs e)
				{
					vRefreshVolumeCubico();
				}

				private void m_txtComprimento_TextChanged(object sender, System.EventArgs e)
				{
					vRefreshVolumeCubico();
				}
			#endregion
			#region Volumes
				private void m_lvVolumes_SelectedIndexChanged(object sender, System.EventArgs e)
				{
					if (m_strUltimoVolume != "")
					{
						string strDado;

						// Tipo Popular
						strDado = m_txtTipoPopular.Text.Trim();
						OnCallSalvaDadosVolumeDescricaoPopular(m_strUltimoVolume,strDado);

						// Altura
						strDado = m_txtAltura.Text.Trim();
						if (strDado == "")
							strDado = "0";
						OnCallSalvaDadosVolumeAltura(m_strUltimoVolume,Double.Parse(strDado));

						// Largura
						strDado = m_txtLargura.Text.Trim();
						if (strDado == "")
							strDado = "0";
						OnCallSalvaDadosVolumeLargura(m_strUltimoVolume,Double.Parse(strDado));

						// Comprimento
						strDado = m_txtComprimento.Text.Trim();
						if (strDado == "")
							strDado = "0";
						OnCallSalvaDadosVolumeComprimento(m_strUltimoVolume,Double.Parse(strDado));

						// Peso Liquido 
						strDado = m_txtPesoLiquido.Text.Trim();
						if (strDado == "")
							strDado = "0";
						OnCallSalvaDadosVolumePesoLiquido(m_strUltimoVolume,Double.Parse(strDado));

						// Volume 
						strDado = m_txtVolume.Text.Trim();
						if (strDado == "")
							strDado = "0";
						OnCallSalvaDadosVolumeVolume(m_strUltimoVolume,Double.Parse(strDado));

						// PesoBruto;
						strDado = m_txtPesoBruto.Text.Trim();
						if (strDado == "")
							strDado = "0";
						OnCallSalvaDadosVolumePesoBruto(m_strUltimoVolume,Double.Parse(strDado));
					}
					OnCallCarregaDadosVolumeSelecionado(false);				
				}
			#endregion
			#region lvConteudo 
				private void m_btEmbalagemEditar_Click(object sender, System.EventArgs e)
				{
					OnCallShowDialogConteudo();
				}

				private void m_lvEmbalagens_DoubleClick(object sender, System.EventArgs e)
				{
					OnCallShowDialogConteudo();
				}

				private void m_btEmbalagemExcluir_Click(object sender, System.EventArgs e)
				{
					OnCallExcluiConteudo();
				}
			#endregion
		#endregion
		#region Cores Formulario
			private void MostraCor()
			{
				try
				{
					mdlPaletaDeCores.clsPaletaDeCores clsPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini","SiscobrasCorSecundaria");
					this.BackColor = clsPaletaCores.retornaCorAtual();
					for (int nCont = 0 ;nCont < this.Controls.Count; nCont++)
					{
						this.Controls[nCont].BackColor = this.BackColor;
						for (int nCont2 = 0 ;nCont2 < this.Controls[nCont].Controls.Count; nCont2++)
						{
							if ((this.Controls[nCont].Controls[nCont2].GetType().ToString() != "mdlComponentesGraficos.TextBox") && (this.Controls[nCont].Controls[nCont2].GetType().ToString() != "mdlComponentesGraficos.ListView"))
								this.Controls[nCont].Controls[nCont2].BackColor = this.BackColor;

							for (int nCont3 = 0 ;nCont3 < this.Controls[nCont].Controls[nCont2].Controls.Count; nCont3++)
							{
								if ((this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "mdlComponentesGraficos.TextBox") && (this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "mdlComponentesGraficos.ListView"))
									this.Controls[nCont].Controls[nCont2].Controls[nCont3].BackColor = this.BackColor;

								for (int nCont4 = 0 ;nCont4 < this.Controls[nCont].Controls[nCont2].Controls[nCont3].Controls.Count; nCont4++)
								{
									if ((this.Controls[nCont].Controls[nCont2].Controls[nCont3].Controls[nCont4].GetType().ToString() != "mdlComponentesGraficos.TextBox") && (this.Controls[nCont].Controls[nCont2].Controls[nCont3].Controls[nCont4].GetType().ToString() != "mdlComponentesGraficos.ListView"))
										this.Controls[nCont].Controls[nCont2].Controls[nCont3].Controls[nCont4].BackColor = this.BackColor;

									for (int nCont5 = 0 ;nCont5 < this.Controls[nCont].Controls[nCont2].Controls[nCont3].Controls[nCont4].Controls.Count; nCont5++)
									{
										if ((this.Controls[nCont].Controls[nCont2].Controls[nCont3].Controls[nCont4].Controls[nCont5].GetType().ToString() != "mdlComponentesGraficos.TextBox") && (this.Controls[nCont].Controls[nCont2].Controls[nCont3].Controls[nCont4].Controls[nCont5].GetType().ToString() != "mdlComponentesGraficos.ListView"))
											this.Controls[nCont].Controls[nCont2].Controls[nCont3].Controls[nCont4].Controls[nCont5].BackColor = this.BackColor;
									}
								}
							}
						}
					}
				}
				catch (Exception erro)
				{
					Object err = (Object)erro;
					m_cls_ter_tratadorErro.trataErro(ref err);
				}
			}
		#endregion

		#region Refresh
			private void vRefreshVolumeCubico()
			{
				double dAltura = 0,dLargura = 0,dComprimento = 0;
				try
				{
					dAltura = double.Parse(m_txtAltura.Text);
				}
				catch
				{
				}
				try
				{
					dLargura = double.Parse(m_txtLargura.Text);
				}
				catch
				{
				}
				try
				{
					dComprimento = double.Parse(m_txtComprimento.Text);
				}
				catch
				{
				}
				if ((dAltura != 0) && (dLargura != 0) && (dComprimento != 0))
				{
					if (m_nUnidadeMetricaVolume != m_nUnidadeMetricaAltura)
						dAltura = dAltura * (clsProdutosRomaneio.dRetornaFatorConversaoEntreUnidadesEspaco(m_nUnidadeMetricaAltura,m_nUnidadeMetricaVolume));
					if (m_nUnidadeMetricaVolume != m_nUnidadeMetricaLargura)
						dLargura = dLargura * (clsProdutosRomaneio.dRetornaFatorConversaoEntreUnidadesEspaco(m_nUnidadeMetricaLargura,m_nUnidadeMetricaVolume));
					if (m_nUnidadeMetricaVolume != m_nUnidadeMetricaComprimento)
						dComprimento = dComprimento * (clsProdutosRomaneio.dRetornaFatorConversaoEntreUnidadesEspaco(m_nUnidadeMetricaComprimento,m_nUnidadeMetricaVolume));
					m_txtVolume.Text = (dAltura * dLargura * dComprimento).ToString();
					if (m_lvVolumes.SelectedItems.Count > 0)
					{
						string strNumeroVolumeListView = m_lvVolumes.SelectedItems[0].Text.Trim();
						string strDado = m_txtVolume.Text.Trim();
						if (strDado == "")
							strDado = "0";
						OnCallSalvaDadosVolumeVolume(strNumeroVolumeListView,Double.Parse(strDado));
					}
				}
			}
		#endregion

		#region Retorno
			public void RetornaValores(out mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetTbProdutosRomaneioVolumes,out mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos typDatSetTbProdutosRomaneioVolumesProdutos,out mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens typDatSetTbProdutosRomaneioEmbalagens,out mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos typDatSetTbProdutosRomaneioEmbalagensProdutos)
			{
				// Typed DataSets Retornando
				typDatSetTbProdutosRomaneioVolumes = m_typDatSetTbProdutosRomaneioVolumesCopy;
				typDatSetTbProdutosRomaneioVolumesProdutos = m_typDatSetTbProdutosRomaneioVolumesProdutosCopy;
				typDatSetTbProdutosRomaneioEmbalagens = m_typDatSetTbProdutosRomaneioEmbalagensCopy;
				typDatSetTbProdutosRomaneioEmbalagensProdutos = m_typDatSetTbProdutosRomaneioEmbalagensProdutosCopy;
				GC.Collect();
				GC.WaitForPendingFinalizers();
			}
		#endregion
	}
}
