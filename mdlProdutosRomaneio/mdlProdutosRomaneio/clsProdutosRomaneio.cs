using System;

namespace mdlProdutosRomaneio
{
	#region Enuns
		public enum Ordenacao
		{
			Volumes = 1,
			Produtos = 2,
			Simplificado = 3
		}

		public enum UnidadeMedida
		{
			Milimetro = 1,
			Centimetro = 2,
			Decimetro = 3,
			Metro = 4,
			Kilometro = 5
		}
		
		internal enum UnidadeMassa
		{
			Miligrama = 1,
			Grama = 2,	
			Kilograma = 3, 
			Tonelada = 4,
			Libra = 5
		}
	#endregion
	/// <summary>
	/// Summary description for clsProdutosRomaneio.
	/// </summary>
	public class clsProdutosRomaneio
	{
		#region Static
			#region Methods
				#region Carregamento dos Dados da Interface
					#region Volumes
					static internal void CarregaDadosInterfaceVolumes(ref mdlDataBaseAccess.Tabelas.XsdTbVolumes typDatSetTbVolumes,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetTbProdutosRomaneioVolumesClone,ref mdlComponentesGraficos.ListView lvVolumes,ref System.Collections.ArrayList arlVolumes)
					{
						System.Collections.SortedList sortLstVolumes = new System.Collections.SortedList(new mdlComponentesColecoes.clsComparerNumbersTexts());  
						mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumesRow dtrwVolume;
						System.Windows.Forms.ListViewItem lviVolume;

						lvVolumes.Clear();

						// Ordenando os Volumes
						for(int nCont = 0 ; nCont < typDatSetTbProdutosRomaneioVolumesClone.tbProdutosRomaneioVolumes.Rows.Count; nCont++)
						{
							dtrwVolume = (mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumesRow)typDatSetTbProdutosRomaneioVolumesClone.tbProdutosRomaneioVolumes.Rows[nCont];
							if (dtrwVolume.RowState != System.Data.DataRowState.Deleted)
								if (arlVolumes.Contains(dtrwVolume.strNumeroVolume))
									sortLstVolumes.Add(dtrwVolume.strNumeroVolume,dtrwVolume);
						}

						// Inserindo os Volumes
						for(int nCont = 0;nCont < sortLstVolumes.Count;nCont++)
						{
							dtrwVolume = (mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumesRow)sortLstVolumes.GetByIndex(nCont);
							lviVolume = lvVolumes.Items.Add(dtrwVolume.strNumeroVolume);
							lviVolume.Tag = dtrwVolume.strNumeroVolume;
							lviVolume.ImageIndex = nRetornaIndiceImagemVolume(ref typDatSetTbVolumes,dtrwVolume.nlTipoVolume);
						} 
					}
					#endregion
					#region Embalagens
						static internal void CarregaDadosInterfaceVolumesEmbalagens(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens typDatSetTbProdutosRomaneioEmbalagens,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos typDatSetTbProdutosRomaneioEmbalagensProdutos,string strNumeroVolume, ref mdlComponentesGraficos.ListView lvEmbalagens)
						{
							System.Collections.ArrayList arlEmbalagens = null;
							arlEmbalagens = arlRetornaEmbalagensVolume(ref typDatSetTbProdutosRomaneioEmbalagens,strNumeroVolume);
							if (arlEmbalagens.Count > 0)
							{
								CarregaDadosInterfaceEmbalagens(ref typDatSetTbProdutosRomaneioEmbalagens,ref typDatSetTbProdutosRomaneioEmbalagensProdutos,ref lvEmbalagens,ref arlEmbalagens,true);
							}
						}

						static internal void CarregaDadosInterfaceEmbalagens(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens typDatSetTbProdutosRomaneioEmbalagens,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos typDatSetTbProdutosRomaneioEmbalagensProdutos, ref mdlComponentesGraficos.ListView lvEmbalagens,ref System.Collections.ArrayList arlEmbalagens,bool bDetalhado)
						{
							mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagensRow dtrwEmbalagem;
							System.Collections.SortedList sortlstEmbalagens = new System.Collections.SortedList(new mdlComponentesColecoes.clsComparerNumbersTexts());
							System.Windows.Forms.ListViewItem lviEmbalagem;

							// Ordenando as Embalagens 
							for(int nCont = 0 ; nCont < typDatSetTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagens.Rows.Count; nCont++)
							{
								dtrwEmbalagem = (mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagensRow)typDatSetTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagens.Rows[nCont];
								if (dtrwEmbalagem.RowState != System.Data.DataRowState.Deleted)
									if (arlEmbalagens.Contains(dtrwEmbalagem.strIdEmbalagem))
										sortlstEmbalagens.Add(dtrwEmbalagem.strIdEmbalagem,dtrwEmbalagem);
							}

							// Inserindo as Embalagens 
							for(int nCont = 0;nCont < sortlstEmbalagens.Count;nCont++)
							{
								dtrwEmbalagem = (mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagensRow)sortlstEmbalagens.GetByIndex(nCont);
								if (bDetalhado)
								{
									lviEmbalagem = lvEmbalagens.Items.Add("1");
									lviEmbalagem.SubItems.Add(dtrwEmbalagem.strIdEmbalagem);
									lviEmbalagem.SubItems.Add(dRetornaPesoLiquidoEmbalagem(ref typDatSetTbProdutosRomaneioEmbalagensProdutos,dtrwEmbalagem.strIdEmbalagem,3).ToString() + " Kg");
								}else{
									lviEmbalagem = lvEmbalagens.Items.Add(dtrwEmbalagem.strIdEmbalagem);
								}

								if (bEmbalagemVazia(ref typDatSetTbProdutosRomaneioEmbalagensProdutos,dtrwEmbalagem.strIdEmbalagem))
								{
									lviEmbalagem.ImageIndex = 0;
								}
								else
								{
									lviEmbalagem.ImageIndex = 1;
								}
							} 
						}
					#endregion
					#region Produtos
						static void CarregaDadosInterfaceEmbalagensProdutos(ref mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassa typDatSetTbUnidadesMassa,ref mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassaIdioma typDatSetTbUnidadesMassaIdioma,ref mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetTbProdutos,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas typDatSetTbProdutosIdiomas,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial typDatSetTbProdutosFaturaComercial,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos typDatSetTbProdutosRomaneioEmbalagensProdutos,int nIdExportador,int nIdIdioma, string strIdEmbalagem,ref mdlComponentesGraficos.ListView lvConteudo)
						{
							mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutosRow dtrwProdutos;
							System.Collections.SortedList sortlstProdutos = new System.Collections.SortedList(new mdlComponentesColecoes.clsComparerNumbersTexts());
							System.Windows.Forms.ListViewItem lviProduto;

							// Ordenando os Produtos pela Ordem Lancamento
							for(int nCont = 0 ; nCont < typDatSetTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutos.Rows.Count; nCont++)
							{
								dtrwProdutos = (mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutosRow)typDatSetTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutos.Rows[nCont];
								if (dtrwProdutos.RowState != System.Data.DataRowState.Deleted)
								{
									if (dtrwProdutos.strIdEmbalagem == strIdEmbalagem)
									{
										sortlstProdutos.Add(dtrwProdutos.nIdOrdemProduto,dtrwProdutos);
									}
								}
							}

							// Inserindo os Produtos
							for(int nCont = 0;nCont < sortlstProdutos.Count;nCont++)
							{
								dtrwProdutos = (mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutosRow)sortlstProdutos.GetByIndex(nCont);
								lviProduto = lvConteudo.Items.Add(dtrwProdutos.dQuantidade.ToString() + " " + strRetornaUnidadeQuantidadeProdutoFatura(ref typDatSetTbProdutosFaturaComercial,dtrwProdutos.nIdOrdemProduto));
								lviProduto.SubItems.Add(strRetornaDescricaoProdutoFatura(ref typDatSetTbProdutos,ref typDatSetTbProdutosIdiomas,ref typDatSetTbProdutosFaturaComercial,nIdExportador,nIdIdioma,dtrwProdutos.nIdOrdemProduto));
								lviProduto.SubItems.Add(dtrwProdutos.dPesoLiquido.ToString() + " " + strRetornaSiglaUnidadeMassa(ref typDatSetTbUnidadesMassa,ref typDatSetTbUnidadesMassaIdioma,dtrwProdutos.nUnidadeMassaPesoLiquido,nIdIdioma));
								lviProduto.ImageIndex = 2;
								lviProduto.Tag = dtrwProdutos.nIdOrdemProduto;
							} 
						}

						static void CarregaDadosInterfaceVolumesProdutos(ref mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassa typDatSetTbUnidadesMassa,ref mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassaIdioma typDatSetTbUnidadesMassaIdioma,ref mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetTbProdutos,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas typDatSetTbProdutosIdiomas,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial typDatSetTbProdutosFaturaComercial,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos typDatSetTbProdutosRomaneioVolumesProdutos,int nIdExportador,int nIdIdioma, string strNumeroVolume,ref mdlComponentesGraficos.ListView lvConteudo)
						{
							mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutosRow dtrwProdutos;
							System.Collections.SortedList sortlstProdutos = new System.Collections.SortedList(new mdlComponentesColecoes.clsComparerNumbersTexts());
							System.Windows.Forms.ListViewItem lviProduto;

							// Ordenando os Produtos pela Ordem Lancamento
							for(int nCont = 0 ; nCont < typDatSetTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutos.Rows.Count; nCont++)
							{
								dtrwProdutos = (mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutosRow)typDatSetTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutos.Rows[nCont];
								if (dtrwProdutos.RowState != System.Data.DataRowState.Deleted)
								{
									if ((dtrwProdutos.idExportador == nIdExportador) && (dtrwProdutos.strNumeroVolume == strNumeroVolume))
									{
										sortlstProdutos.Add(dtrwProdutos.nIdOrdemProduto,dtrwProdutos);
									}
								}
							}

							// Inserindo os Produtos
							for(int nCont = 0;nCont < sortlstProdutos.Count;nCont++)
							{
								dtrwProdutos = (mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutosRow)sortlstProdutos.GetByIndex(nCont);
								int nIdProduto = nRetornaIdProduto(ref typDatSetTbProdutosFaturaComercial,dtrwProdutos.nIdOrdemProduto);
								if (nIdProduto != -1)
								{
									lviProduto = lvConteudo.Items.Add(dtrwProdutos.dQuantidade.ToString() + " " + strRetornaUnidadeQuantidadeProdutoFatura(ref typDatSetTbProdutosFaturaComercial,dtrwProdutos.nIdOrdemProduto));
									lviProduto.SubItems.Add(strRetornaDescricaoProdutoFatura(ref typDatSetTbProdutos,ref typDatSetTbProdutosIdiomas,ref typDatSetTbProdutosFaturaComercial,nIdExportador,nIdIdioma,dtrwProdutos.nIdOrdemProduto));
									lviProduto.SubItems.Add(dtrwProdutos.dPesoLiquido.ToString() + " " + strRetornaSiglaUnidadeMassa(ref typDatSetTbUnidadesMassa,ref typDatSetTbUnidadesMassaIdioma,dtrwProdutos.nUnidadeMassaPesoLiquido,nIdIdioma));
									lviProduto.ImageIndex = 2;
									lviProduto.Tag = dtrwProdutos.nIdOrdemProduto;
								}
							} 
						}
					#endregion
				#endregion
				#region Intervalos
					static internal System.Collections.ArrayList arlRetornaIntervalo(string strIntervalo,string strPrefixo,string strSufixo)
					{
						System.Collections.ArrayList arlRetorno = new System.Collections.ArrayList();
						int nPosVirgula;
						string strIntervaloManipular;
						string strIntervaloInicio;
						string strIntervaloFim;
						int nIntervaloInicio;
						int nIntervaloFim;

						strIntervalo = strIntervalo.Trim().Replace(" ","");
						if (strIntervalo != "")
						{
							while (strIntervalo.Length > 0)
							{
								nPosVirgula = strIntervalo.IndexOf(";");
								if (nPosVirgula >= 0)
								{
									strIntervaloManipular = strIntervalo.Substring(0, nPosVirgula);
									strIntervalo = strIntervalo.Substring(nPosVirgula + 1);
								}
								else
								{
									strIntervaloManipular = strIntervalo;
									strIntervalo = "";
								}
								nPosVirgula = strIntervaloManipular.IndexOf("-");
								if (nPosVirgula < 0) // Nao eh intervalo
								{
									if (!arlRetorno.Contains(strIntervaloManipular))
									{
										arlRetorno.Add(strIntervaloManipular);
									}
									else
									{
										arlRetorno = null;
										break;
									}
								}
								else
								{ // Intervalo
									strIntervaloInicio = strIntervaloManipular.Substring(0, nPosVirgula);
									try
									{ 
										nIntervaloInicio = Int32.Parse(strIntervaloInicio);
										strIntervaloFim = strIntervaloManipular.Substring(nPosVirgula + 1);
										try
										{
											nIntervaloFim = Int32.Parse(strIntervaloFim);
											if (nIntervaloInicio < nIntervaloFim)
											{
												for (int nCont = nIntervaloInicio; nCont <= nIntervaloFim;nCont++)
												{
													if (!arlRetorno.Contains(strPrefixo + nCont.ToString() + strSufixo))
													{
														arlRetorno.Add(strPrefixo + nCont.ToString() + strSufixo);
													}
													else
													{
														arlRetorno = null;
														break;
													}
												}
											}
											else
											{
												arlRetorno = null;
												break;
											}
										}
										catch
										{
											arlRetorno = null;
											break;
										}
									}
									catch
									{
										arlRetorno = null;
										break;
									}
								}
							}
						}
						else
						{
							arlRetorno = null;
						}
						return (arlRetorno);
					}

					static internal System.Collections.ArrayList arlRetornaIntervaloNumerico(string strIntervalo,int nQuantEmbalagens)
					{
						System.Collections.ArrayList arlRetorno = new System.Collections.ArrayList();
						int nPosPontoVirgula;
						string strIntervaloManipular;
						double dNumber;
							
						strIntervalo = strIntervalo.Trim().Replace(" ","");
						if (strIntervalo != "")
						{
							nPosPontoVirgula = strIntervalo.IndexOf(";");
							if (nPosPontoVirgula < 0)
							{
								try
								{
									dNumber = Double.Parse(strIntervalo);
									for(int nCont = 0; nCont < nQuantEmbalagens;nCont++)
									{
										arlRetorno.Add(dNumber);
									}
								}
								catch
								{
									arlRetorno = null;
								}
							}
							else
							{
								while (strIntervalo.Length > 0)
								{
									nPosPontoVirgula = strIntervalo.IndexOf(";");
									if(nPosPontoVirgula == -1)
									{
										strIntervaloManipular = strIntervalo;
										strIntervalo = "";
									}
									else
									{
										strIntervaloManipular = strIntervalo.Substring(0,nPosPontoVirgula);
										strIntervalo = strIntervalo.Substring(nPosPontoVirgula + 1);
									}
									try
									{
										if (strIntervaloManipular != "")
										{
											dNumber = Double.Parse(strIntervaloManipular);
											arlRetorno.Add(dNumber);
										}
										else
										{
											arlRetorno.Add(null);
										}
									}
									catch
									{
										arlRetorno = null;
										break;
									}
								}
							}
						}
						else
						{
							arlRetorno = null;
						}
						return (arlRetorno);
					}

					static internal string strRetornaIntervaloNumerico(System.Collections.ArrayList arlIntervaloNumerico)
					{
						string strRetorno = "";
						if (arlIntervaloNumerico != null)
						{
							bool bTodosNumerosSaoIguais = true;
							// Verificando se todos os numeros são iguais
							for(int nCont = 1;nCont < arlIntervaloNumerico.Count;nCont++)
							{
								if ((arlIntervaloNumerico[nCont - 1] == null) || (arlIntervaloNumerico[nCont] == null) || (arlIntervaloNumerico[nCont - 1].ToString() != arlIntervaloNumerico[nCont].ToString()))
								{
									bTodosNumerosSaoIguais = false;
									break;
								}
							} 
							if (bTodosNumerosSaoIguais)
							{
								strRetorno = arlIntervaloNumerico[0].ToString();
							}
							else
							{
								for (int nCont = 0;nCont < arlIntervaloNumerico.Count;nCont++)
								{
									if (nCont != 0)
										strRetorno += ";";
									if (arlIntervaloNumerico[nCont] != null)
										strRetorno += arlIntervaloNumerico[nCont].ToString();
								}

								// Removendo os ; finais 
								for(int nCont = (strRetorno.Length - 1) ; nCont > 0;nCont--)
								{
									if ((strRetorno[nCont] == ';') && (strRetorno.IndexOf(";") != nCont))
										strRetorno = strRetorno.Substring(0,nCont);
									else
										break;
								}
							}
			                           
						}
						return(strRetorno);
					}
				#endregion
				#region UnidadeMetrica
					static internal int nRetornaProximaUnidadeMetrica(int nUnidadeMetricaAtual)
					{
						int nRetorno = 0;
						switch(nUnidadeMetricaAtual)
						{
							case (int)mdlProdutosRomaneio.UnidadeMedida.Centimetro:
								nRetorno = (int)mdlProdutosRomaneio.UnidadeMedida.Metro;
								break;
							case (int)mdlProdutosRomaneio.UnidadeMedida.Metro:
								nRetorno = (int)mdlProdutosRomaneio.UnidadeMedida.Centimetro;
								break;
						}
						return(nRetorno);
					}
				#endregion	
				#region UnidadeMassa
					static internal int nRetornaProximaUnidadeMassa(int nUnidadeMassaAtual)
					{
						int nRetorno = 0;
						switch(nUnidadeMassaAtual)
						{
							case 2: // Grama
								nRetorno = 3;
								break;
							case 3: // KiloGrama
								nRetorno = 4;
								break;
							case 4: // Tonelada
								nRetorno = 2;
								break;
							default:
								nRetorno = 2;
								break;
						}
						return (nRetorno);
					}
				#endregion
				#region Conversao 
					#region UnidadeEspaco
						static internal double dRetornaFatorConversaoEntreUnidadesEspaco(int nUnidadeInicial,int nUnidadeFinal)
						{
							double dRetorno = 1;
							// Convertendo Unidade Inicial para Metro
							switch(nUnidadeInicial)
							{
								case 1: // Milimetro
									dRetorno = 0.001;
									break;
								case 2: // Centrimetro
									dRetorno = 0.01;
									break;
								case 3: // Decimetro
									dRetorno = 0.1;
									break;
								case 4: // Metro
									dRetorno = 1;
									break;
								case 5: // Kilometro
									dRetorno = 1000;
									break;
							}

							// Convertendo Metro para Unidade Final
							switch(nUnidadeFinal)
							{
								case 1: // Milimetro
									dRetorno = dRetorno * 1000;
									break;
								case 2: // Centimetro
									dRetorno = dRetorno * 100;
									break;
								case 3: // Decimetro
									dRetorno = dRetorno * 10;
									break;
								case 4: // Metro
									dRetorno = dRetorno * 1;
									break;
								case 5: // Kilometro
									dRetorno = dRetorno * 0.001;
									break;
							}
							return(dRetorno);
						}

						static internal decimal dcRetornaFatorConversaoEntreUnidadesEspaco(int nUnidadeInicial,int nUnidadeFinal)
						{
							decimal dRetorno = 1;
							// Convertendo Unidade Inicial para Metro
							switch(nUnidadeInicial)
							{
								case 1: // Milimetro
									dRetorno = 0.001m;
									break;
								case 2: // Centrimetro
									dRetorno = 0.01m;
									break;
								case 3: // Decimetro
									dRetorno = 0.1m;
									break;
								case 4: // Metro
									dRetorno = 1m;
									break;
								case 5: // Kilometro
									dRetorno = 1000;
									break;
							}

							// Convertendo Metro para Unidade Final
							switch(nUnidadeFinal)
							{
								case 1: // Milimetro
									dRetorno = dRetorno * 1000;
									break;
								case 2: // Centimetro
									dRetorno = dRetorno * 100;
									break;
								case 3: // Decimetro
									dRetorno = dRetorno * 10;
									break;
								case 4: // Metro
									dRetorno = dRetorno * 1;
									break;
								case 5: // Kilometro
									dRetorno = dRetorno * 0.001m;
									break;
							}
							return(dRetorno);
						}
					#endregion
					#region UnidadeMassa
						static internal double dRetornaFatorConversaoEntreUnidadesMassa(int nUnidadeInicial,int nUnidadeFinal)
						{
							double dRetorno = 1;
							// Convertendo Unidade Inicial para Kilo
							switch(nUnidadeInicial)
							{
								case 1: // Miligrama
									dRetorno = 0.000001;
									break;
								case 2: // Grama 
									dRetorno = 0.001;
									break;
								case 3: // KiloGrama
									dRetorno = 1;
									break;
								case 4: // Tonelada 
									dRetorno = 1000;
									break;
								case 5: // Libra
									dRetorno = 0.453;
									break;
							}

							// Convertendo Kilo para Unidade Final
							switch(nUnidadeFinal)
							{
								case 1: // Miligrama
									dRetorno = dRetorno * 1000000;
									break;
								case 2: // Grama 
									dRetorno = dRetorno * 1000;
									break;
								case 3: // KiloGrama
									dRetorno = dRetorno * 1;
									break;
								case 4: // Tonelada 
									dRetorno = dRetorno * 0.001;
									break;
								case 5: // Libra
									dRetorno = dRetorno * 2.207;
									break;
							}
							return(dRetorno);
						}
					#endregion
				#endregion
				#region Salvamento dos Dados da Interface
					static internal void SalvaDadosEmbalagemNumeroEmbalagem(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens typDatSetTbProdutosRomaneioEmbalagens,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos typDatSetTbProdutosRomaneioEmbalagensProdutos,string strIdEmbalagemAntigo,string strIdEmbalagemNovo)
					{
						// Embalagens 
						mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagensRow dtrwEmbalagem;
						for (int nCont = 0; nCont < typDatSetTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagens.Rows.Count;nCont++)
						{
							dtrwEmbalagem = (mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagensRow)typDatSetTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagens.Rows[nCont];
							if ((dtrwEmbalagem.RowState != System.Data.DataRowState.Deleted) && (dtrwEmbalagem.strIdEmbalagem == strIdEmbalagemAntigo))
								dtrwEmbalagem.strIdEmbalagem = strIdEmbalagemNovo;
						}

						// Embalagens Produtos
						mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutosRow dtrwProdutos;
						for (int nCont = 0; nCont < typDatSetTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutos.Rows.Count;nCont++)
						{
							dtrwProdutos = (mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutosRow)typDatSetTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutos.Rows[nCont];
							if ((dtrwProdutos.RowState != System.Data.DataRowState.Deleted) && (dtrwProdutos.strIdEmbalagem == strIdEmbalagemAntigo))
								dtrwProdutos.strIdEmbalagem = strIdEmbalagemNovo;
						}

					}
					static internal void SalvaDadosVolumeNumeroVolume(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetTbProdutosRomaneioVolumes,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos typDatSetTbProdutosRomaneioVolumesProdutos,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens typDatSetTbProdutosRomaneioEmbalagens,string strNumeroVolumeAntigo,string strNumeroVolumeNovo)
					{
						// Volumes
						mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumesRow dtrwVolume;
						for (int nCont = 0; nCont < typDatSetTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumes.Rows.Count;nCont++)
						{
							dtrwVolume = (mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumesRow)typDatSetTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumes.Rows[nCont];
							if ((dtrwVolume.RowState != System.Data.DataRowState.Deleted) && (dtrwVolume.strNumeroVolume == strNumeroVolumeAntigo))
								dtrwVolume.strNumeroVolume = strNumeroVolumeNovo;
						}
                        
						// Volumes - Produtos
						mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutosRow dtrwVolumeProdutos;
						for (int nCont = 0; nCont < typDatSetTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutos.Rows.Count;nCont++)
						{
							dtrwVolumeProdutos = (mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutosRow)typDatSetTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutos.Rows[nCont];
							if ((dtrwVolumeProdutos.RowState != System.Data.DataRowState.Deleted) && (dtrwVolumeProdutos.strNumeroVolume == strNumeroVolumeAntigo))
								dtrwVolumeProdutos.strNumeroVolume = strNumeroVolumeNovo;
						}
                        
						// Volumes - Embalagens 
						mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagensRow dtrwEmbalagem;
						for (int nCont = 0; nCont < typDatSetTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagens.Rows.Count;nCont++)
						{
							dtrwEmbalagem = (mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagensRow)typDatSetTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagens.Rows[nCont];
							if ((dtrwEmbalagem.RowState != System.Data.DataRowState.Deleted) && (!dtrwEmbalagem.IsstrNumeroVolumeNull()) && (dtrwEmbalagem.strNumeroVolume == strNumeroVolumeAntigo))
								dtrwEmbalagem.strNumeroVolume = strNumeroVolumeNovo;
						}

					}

					static internal void SalvaDadosVolumeTipo(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetTbProdutosRomaneioVolumes,int nIdExportador, string strIdPe,string strNumeroVolume,int nTipoVolume)
					{
						mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumesRow dtrwVolume;
						dtrwVolume = typDatSetTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumes.FindByidExportadoridPEstrNumeroVolume(nIdExportador,strIdPe,strNumeroVolume);
						if ((dtrwVolume != null) && (dtrwVolume.RowState != System.Data.DataRowState.Deleted))
						{
							dtrwVolume.nlTipoVolume = nTipoVolume;
						}
					}

					static internal void SalvaDadosVolumeDescricaoPopular(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetTbProdutosRomaneioVolumes,int nIdExportador, string strIdPe,string strNumeroVolume,string strDescricaoPopular)
					{
						mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumesRow dtrwVolume;
						dtrwVolume = typDatSetTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumes.FindByidExportadoridPEstrNumeroVolume(nIdExportador,strIdPe,strNumeroVolume);
						if ((dtrwVolume != null) && (dtrwVolume.RowState != System.Data.DataRowState.Deleted))
						{
							dtrwVolume.strTipoPopular = strDescricaoPopular;
						}
					}

					static internal void SalvaDadosVolumeAltura(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetTbProdutosRomaneioVolumes,int nIdExportador, string strIdPe,string strNumeroVolume,double dAltura)
					{
						mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumesRow dtrwVolume;
						dtrwVolume = typDatSetTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumes.FindByidExportadoridPEstrNumeroVolume(nIdExportador,strIdPe,strNumeroVolume);
						if ((dtrwVolume != null) && (dtrwVolume.RowState != System.Data.DataRowState.Deleted))
						{
							dtrwVolume.dAltura = dAltura;
						}
					}

					static internal void SalvaDadosVolumeLargura(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetTbProdutosRomaneioVolumes,int nIdExportador, string strIdPe,string strNumeroVolume,double dLargura)
					{
						mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumesRow dtrwVolume;
						dtrwVolume = typDatSetTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumes.FindByidExportadoridPEstrNumeroVolume(nIdExportador,strIdPe,strNumeroVolume);
						if ((dtrwVolume != null) && (dtrwVolume.RowState != System.Data.DataRowState.Deleted))
						{
							dtrwVolume.dLargura = dLargura;
						}
					}

					static internal void SalvaDadosVolumeComprimento(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetTbProdutosRomaneioVolumes,int nIdExportador, string strIdPe,string strNumeroVolume,double dComprimento)
					{
						mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumesRow dtrwVolume;
						dtrwVolume = typDatSetTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumes.FindByidExportadoridPEstrNumeroVolume(nIdExportador,strIdPe,strNumeroVolume);
						if ((dtrwVolume != null) && (dtrwVolume.RowState != System.Data.DataRowState.Deleted))
						{
							dtrwVolume.dComprimento = dComprimento;
						}
					}

					static internal void SalvaDadosVolumeVolume(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetTbProdutosRomaneioVolumes,int nIdExportador, string strIdPe,string strNumeroVolume,double dVolume)
					{
						mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumesRow dtrwVolume;
						dtrwVolume = typDatSetTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumes.FindByidExportadoridPEstrNumeroVolume(nIdExportador,strIdPe,strNumeroVolume);
						if ((dtrwVolume != null) && (dtrwVolume.RowState != System.Data.DataRowState.Deleted))
						{
							dtrwVolume.dVolume = dVolume;
						}
					}

					static internal void SalvaDadosVolumePesoLiquido(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetTbProdutosRomaneioVolumes,int nIdExportador, string strIdPe,string strNumeroVolume,double dPesoLiquido)
					{
						mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumesRow dtrwVolume;
						dtrwVolume = typDatSetTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumes.FindByidExportadoridPEstrNumeroVolume(nIdExportador,strIdPe,strNumeroVolume);
						if ((dtrwVolume != null) && (dtrwVolume.RowState != System.Data.DataRowState.Deleted))
						{
							dtrwVolume.dPesoLiquido = dPesoLiquido;
						}
					}

					static internal void SalvaDadosVolumePesoBruto(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetTbProdutosRomaneioVolumes,int nIdExportador, string strIdPe,string strNumeroVolume,double dPesoBruto)
					{
						mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumesRow dtrwVolume;
						dtrwVolume = typDatSetTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumes.FindByidExportadoridPEstrNumeroVolume(nIdExportador,strIdPe,strNumeroVolume);
						if ((dtrwVolume != null) && (dtrwVolume.RowState != System.Data.DataRowState.Deleted))
						{
							dtrwVolume.dPesoBruto = dPesoBruto;
						}
					}

					static internal void SalvaDadosVolumeAlturaUnidade(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetTbProdutosRomaneioVolumes,int nIdExportador, string strIdPe,string strNumeroVolume,int nUnidadeAltura)
					{
						mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumesRow dtrwVolume;
						dtrwVolume = typDatSetTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumes.FindByidExportadoridPEstrNumeroVolume(nIdExportador,strIdPe,strNumeroVolume);
						if ((dtrwVolume != null) && (dtrwVolume.RowState != System.Data.DataRowState.Deleted))
						{
							dtrwVolume.nUnidadeAltura = nUnidadeAltura;
						}
					}

					static internal void SalvaDadosVolumeLarguraUnidade(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetTbProdutosRomaneioVolumes,int nIdExportador, string strIdPe,string strNumeroVolume,int nUnidadeLargura)
					{
						mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumesRow dtrwVolume;
						dtrwVolume = typDatSetTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumes.FindByidExportadoridPEstrNumeroVolume(nIdExportador,strIdPe,strNumeroVolume);
						if ((dtrwVolume != null) && (dtrwVolume.RowState != System.Data.DataRowState.Deleted))
						{
							dtrwVolume.nUnidadeLargura = nUnidadeLargura;
						}
					}

					static internal void SalvaDadosVolumeComprimentoUnidade(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetTbProdutosRomaneioVolumes,int nIdExportador, string strIdPe,string strNumeroVolume,int nUnidadeComprimento)
					{
						mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumesRow dtrwVolume;
						dtrwVolume = typDatSetTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumes.FindByidExportadoridPEstrNumeroVolume(nIdExportador,strIdPe,strNumeroVolume);
						if ((dtrwVolume != null) && (dtrwVolume.RowState != System.Data.DataRowState.Deleted))
						{
							dtrwVolume.nUnidadeComprimento = nUnidadeComprimento;
						}
					}

					static internal void SalvaDadosVolumeVolumeUnidade(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetTbProdutosRomaneioVolumes,int nIdExportador, string strIdPe,string strNumeroVolume,int nUnidadeVolume)
					{
						mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumesRow dtrwVolume;
						dtrwVolume = typDatSetTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumes.FindByidExportadoridPEstrNumeroVolume(nIdExportador,strIdPe,strNumeroVolume);
						if ((dtrwVolume != null) && (dtrwVolume.RowState != System.Data.DataRowState.Deleted))
						{
							dtrwVolume.nUnidadeVolume = nUnidadeVolume;
						}
					}

					static internal void SalvaDadosVolumePesoLiquidoUnidade(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetTbProdutosRomaneioVolumes,int nIdExportador, string strIdPe,string strNumeroVolume,int nUnidadePesoLiquido)
					{
						mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumesRow dtrwVolume;
						dtrwVolume = typDatSetTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumes.FindByidExportadoridPEstrNumeroVolume(nIdExportador,strIdPe,strNumeroVolume);
						if ((dtrwVolume != null) && (dtrwVolume.RowState != System.Data.DataRowState.Deleted))
						{
							dtrwVolume.nUnidadeMassaPesoLiquido = nUnidadePesoLiquido;
						}
					}

					static internal void SalvaDadosVolumePesoBrutoUnidade(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetTbProdutosRomaneioVolumes,int nIdExportador, string strIdPe,string strNumeroVolume,int nUnidadePesoBruto)
					{
						mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumesRow dtrwVolume;
						dtrwVolume = typDatSetTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumes.FindByidExportadoridPEstrNumeroVolume(nIdExportador,strIdPe,strNumeroVolume);
						if ((dtrwVolume != null) && (dtrwVolume.RowState != System.Data.DataRowState.Deleted))
						{
							dtrwVolume.nUnidadeMassaPesoBruto = nUnidadePesoBruto;
						}
					}


				#endregion

				#region Configuracoes
					static internal void vRomaneioCarregaPreferencias(ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB,out int nRomaneioPrecisaoPesoLiquidoTotal,out int nRomaneioPrecisaoPesoBrutoTotal,out bool bRomaneioPrecisaoPesoLiquidoTotalArredondar,out bool bRomaneioPrecisaoPesoBrutoTotalArredondar)
					{
						nRomaneioPrecisaoPesoLiquidoTotal = cls_dba_ConnectionDB.GetConfiguracao(mdlConstantes.clsConstantes.CAMPO_ROMANEIO_CASAS_DECIMAIS_PESOLIQUIDO_TOTAL,2);
						nRomaneioPrecisaoPesoBrutoTotal = cls_dba_ConnectionDB.GetConfiguracao(mdlConstantes.clsConstantes.CAMPO_ROMANEIO_CASAS_DECIMAIS_PESOBRUTO_TOTAL,2);
						bRomaneioPrecisaoPesoLiquidoTotalArredondar = cls_dba_ConnectionDB.GetConfiguracao(mdlConstantes.clsConstantes.CAMPO_ROMANEIO_CASAS_DECIMAIS_PESOLIQUIDO_TOTAL_ARREDONDAR,true);
						bRomaneioPrecisaoPesoBrutoTotalArredondar = cls_dba_ConnectionDB.GetConfiguracao(mdlConstantes.clsConstantes.CAMPO_ROMANEIO_CASAS_DECIMAIS_PESOBRUTO_TOTAL_ARREDONDAR,true);
					}

					static internal string strRetornaFormato(int nDecimals)
					{
						string strRetorno = "###,###,###,##0";
						if (nDecimals > 0)
							strRetorno += ".";
						for(int i = 0; i < nDecimals;i++)
							strRetorno += "0";
						return(strRetorno);
					}
				#endregion

				#region Volumes

					static internal bool bVolumeExiste(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetTbProdutosRomaneioVolumes,int nIdExportador,string strIdPe,string strNumeroVolume)
					{
						return(typDatSetTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumes.FindByidExportadoridPEstrNumeroVolume(nIdExportador,strIdPe,strNumeroVolume) != null);
					}

					static internal bool bVolumeVazio(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos typDatSetTbProdutosRomaneioVolumesProdutos,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens typDatSetTbProdutosRomaneioEmbalagens,string strNumeroVolume)
					{
						bool bRetorno = true;
						// Produtos Volumes
						foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutosRow dtrwProdutoVolume in typDatSetTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutos.Rows)
						{
							if (dtrwProdutoVolume.RowState != System.Data.DataRowState.Deleted)
								if (dtrwProdutoVolume.strNumeroVolume == strNumeroVolume)
									return(false);
						}
						// Embalagens Volume
						foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagensRow dtrwEmbalagemVolume in typDatSetTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagens.Rows)
						{
							if (dtrwEmbalagemVolume.RowState != System.Data.DataRowState.Deleted)
								if ((!dtrwEmbalagemVolume.IsstrNumeroVolumeNull()) && (dtrwEmbalagemVolume.strNumeroVolume == strNumeroVolume))
									return(false);
						}
						return(bRetorno);
					}

					static internal bool bVolumeCubagem(UnidadeMedida enumUnidadeMedica,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumesRow dtrwVolume,out double dCubagem)
					{
						bool bReturn = false;
						dCubagem = 0;
						if (dtrwVolume.RowState != System.Data.DataRowState.Deleted)
						{
							if ((!dtrwVolume.IsdVolumeNull()) && (!dtrwVolume.IsnUnidadeVolumeNull()))
							{
								dCubagem = dtrwVolume.dVolume;
								if ((int)enumUnidadeMedica != dtrwVolume.nUnidadeVolume)
								{
									double dFatorConversao = dRetornaFatorConversaoEntreUnidadesEspaco(dtrwVolume.nUnidadeVolume,(int)enumUnidadeMedica);
									dCubagem = dCubagem * dFatorConversao * dFatorConversao * dFatorConversao;
								}
								bReturn = true;
							}
						}
						return(bReturn);
					}

					static internal int nRetornaIndiceImagemVolume(ref mdlDataBaseAccess.Tabelas.XsdTbVolumes typDatSetTbVolumes,int nIdVolume)
					{
						int nRetorno = 2;
						mdlDataBaseAccess.Tabelas.XsdTbVolumes.tbVolumesRow dtrwVolume;
						for (int nCont = 0;nCont < typDatSetTbVolumes.tbVolumes.Rows.Count;nCont++)
						{
							dtrwVolume = (mdlDataBaseAccess.Tabelas.XsdTbVolumes.tbVolumesRow)typDatSetTbVolumes.tbVolumes.Rows[nCont];
							if (dtrwVolume.nIdVolume == nIdVolume)
							{
								if (!dtrwVolume.IsnIdImagemNull())
									nRetorno = dtrwVolume.nIdImagem;
								break;
							}
						}
						return(nRetorno);
					}

					static internal System.Collections.ArrayList arlRetornaEmbalagensVolume(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens typDatSetTbProdutosRomaneioEmbalagens,string strNumeroVolume)
					{
						System.Collections.ArrayList arlRetorno = new System.Collections.ArrayList();
						mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagensRow dtrwEmbalagem;
						for(int nCont = 0; nCont < typDatSetTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagens.Rows.Count;nCont++)
						{
							dtrwEmbalagem = (mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagensRow)typDatSetTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagens.Rows[nCont];
							if (dtrwEmbalagem.RowState != System.Data.DataRowState.Deleted)
							{
								if (!dtrwEmbalagem.IsstrNumeroVolumeNull())
								{
									if (dtrwEmbalagem.strNumeroVolume == strNumeroVolume)
									{
										arlRetorno.Add(dtrwEmbalagem.strIdEmbalagem);
									}
								}
							}
						} 
						return(arlRetorno);
					}

					static internal bool bRemoveEmbalagensVolume(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens typDatSetTbProdutosRomaneioEmbalagens,string strNumeroVolume,ref System.Collections.ArrayList arlEmbalagens)
					{
						bool bRetorno = true;
						string strIdEmbalagem = "";
						mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagensRow dtrwEmbalagem;
						for(int nCont = 0; nCont < arlEmbalagens.Count;nCont++)
						{
							strIdEmbalagem = arlEmbalagens[nCont].ToString();
							for (int nRow = 0 ; nRow < typDatSetTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagens.Rows.Count;nRow++)
							{
								dtrwEmbalagem = (mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagensRow)typDatSetTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagens.Rows[nRow];
								if (dtrwEmbalagem.RowState != System.Data.DataRowState.Deleted)
								{
									if (!dtrwEmbalagem.IsstrNumeroVolumeNull())
									{
										if ((dtrwEmbalagem.strNumeroVolume == strNumeroVolume) && (dtrwEmbalagem.strIdEmbalagem == strIdEmbalagem))
										{
											dtrwEmbalagem.strNumeroVolume = "";
										}
									}
								}
							}
						}
						return(bRetorno);
					}

					static internal bool bRecalculaPesoLiquidoVolumes(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetTbProdutosRomaneioVolumes,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos typDatSetTbProdutosRomaneioVolumesProdutos,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens typDatSetTbProdutosRomaneioEmbalagens,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos typDatSetTbProdutosRomaneioEmbalagensProdutos)
					{
						foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumesRow dtrwVolume in typDatSetTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumes.Rows)
						{
							if (!bRecalculaPesoLiquidoVolume(ref typDatSetTbProdutosRomaneioVolumes,ref typDatSetTbProdutosRomaneioVolumesProdutos,ref typDatSetTbProdutosRomaneioEmbalagens,ref typDatSetTbProdutosRomaneioEmbalagensProdutos,dtrwVolume.strNumeroVolume,false))
								return(false);
						}
						return(true);
					}

					static internal bool bRecalculaPesoLiquidoVolume(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetTbProdutosRomaneioVolumes,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos typDatSetTbProdutosRomaneioVolumesProdutos,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens typDatSetTbProdutosRomaneioEmbalagens,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos typDatSetTbProdutosRomaneioEmbalagensProdutos,string strNumeroVolume,bool bForceRecalc)
					{
						bool bRetorno = false;
						double dPesoLiquido = 0;
						mdlProdutosRomaneio.UnidadeMassa enumUnidadeMassaPesoLiquido = mdlProdutosRomaneio.UnidadeMassa.Kilograma;
						mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumesRow dtrwVolume = null;
						foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumesRow dtrwVolumeCurrent in typDatSetTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumes.Rows)
						{
							if ((dtrwVolumeCurrent.RowState != System.Data.DataRowState.Deleted) && (dtrwVolumeCurrent.strNumeroVolume == strNumeroVolume)) 
							{
								dtrwVolume = dtrwVolumeCurrent;
								break;
							}
						}

						if (dtrwVolume == null)
							return (false);

						enumUnidadeMassaPesoLiquido = (mdlProdutosRomaneio.UnidadeMassa)dtrwVolume.nUnidadeMassaPesoLiquido;

						// Volumes Produtos
						foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutosRow dtrwVolumeProduto in typDatSetTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutos.Rows)
						{
							if ((dtrwVolumeProduto.RowState != System.Data.DataRowState.Deleted) && (dtrwVolumeProduto.strNumeroVolume == strNumeroVolume))
							{
								dPesoLiquido = dPesoLiquido + (dtrwVolumeProduto.dPesoLiquido * dRetornaFatorConversaoEntreUnidadesMassa(dtrwVolumeProduto.nUnidadeMassaPesoLiquido,(int)enumUnidadeMassaPesoLiquido));
							}
						}

						// Embalagens
						System.Collections.ArrayList arlEmbalagens = new System.Collections.ArrayList();
						foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagensRow dtrwEmbalagem in typDatSetTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagens.Rows)
						{
							if ((dtrwEmbalagem.RowState != System.Data.DataRowState.Deleted) && (!dtrwEmbalagem.IsstrNumeroVolumeNull()) && (dtrwEmbalagem.strNumeroVolume == strNumeroVolume))
							{
								if (!arlEmbalagens.Contains(dtrwEmbalagem.strIdEmbalagem))
									arlEmbalagens.Add(dtrwEmbalagem.strIdEmbalagem);
							}
						}

						// Embalagens Produtos
						foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutosRow dtrwEmbalagemProduto in typDatSetTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutos.Rows)
						{
							if ((dtrwEmbalagemProduto.RowState != System.Data.DataRowState.Deleted) && (!arlEmbalagens.Contains(dtrwEmbalagemProduto.strIdEmbalagem)))
							{
								dPesoLiquido = dPesoLiquido + (dtrwEmbalagemProduto.dPesoLiquido * dRetornaFatorConversaoEntreUnidadesMassa(dtrwEmbalagemProduto.nUnidadeMassaPesoLiquido,(int)enumUnidadeMassaPesoLiquido));
							}
						}

						if ((dPesoLiquido != 0) || (bForceRecalc))
							dtrwVolume.dPesoLiquido = dPesoLiquido;
						return(bRetorno);
					}
				#endregion
				#region Embalagem

					static internal bool bEmbalagemExiste(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens typDatSetTbProdutosRomaneioEmbalagens,int nIdExportador, string strIdPe,string strIdEmbalagem)
					{
						return(typDatSetTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagens.FindByidExportadoridPEstrIdEmbalagem(nIdExportador,strIdPe,strIdEmbalagem) != null);
					}

					static internal bool bEmbalagemVazia(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos typDatSetTbProdutosRomaneioEmbalagensProdutos,string strIdEmbalagem)
					{
						bool bRetorno = true;
						mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutosRow dtrwEmbalagemProdutos;
						for(int nCont = 0 ; nCont < typDatSetTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutos.Rows.Count;nCont++)
						{
							dtrwEmbalagemProdutos = (mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutosRow)typDatSetTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutos.Rows[nCont];
							if (dtrwEmbalagemProdutos.RowState != System.Data.DataRowState.Deleted)
							{
								if (dtrwEmbalagemProdutos.strIdEmbalagem == strIdEmbalagem)
								{
									bRetorno = false;
									break;
								} 
							}
						}
						return(bRetorno);
					}

					static internal double dRetornaPesoLiquidoEmbalagem(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos typDatSetTbProdutosRomaneioEmbalagensProdutos,string strIdEmbalagem,int nUnidadePesoLiquido)
					{
						double dRetorno = 0;
						mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutosRow dtrwProdutosEmbalagem;
						for(int nCont = 0;nCont < typDatSetTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutos.Rows.Count;nCont++)
						{
							dtrwProdutosEmbalagem = (mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutosRow)typDatSetTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutos.Rows[nCont];
							if (dtrwProdutosEmbalagem.RowState != System.Data.DataRowState.Deleted)
							{
								if (dtrwProdutosEmbalagem.strIdEmbalagem == strIdEmbalagem)
								{
									if (!dtrwProdutosEmbalagem.IsdPesoLiquidoNull())
									{
										if (!dtrwProdutosEmbalagem.IsnUnidadeMassaPesoLiquidoNull())
										{
											dRetorno += (dtrwProdutosEmbalagem.dPesoLiquido * clsProdutosRomaneio.dRetornaFatorConversaoEntreUnidadesMassa(dtrwProdutosEmbalagem.nUnidadeMassaPesoLiquido,nUnidadePesoLiquido));                            
										}
									}
								}
							}
						}
						return(dRetorno);
					}


				#endregion
				#region Produto Fatura
					static internal string strRetornaUnidadeQuantidadeProdutoFatura(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial typDatSetTbProdutosFaturaComercial,int nIdOrdemProduto)
					{
						string strRetorno = "";
						mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFaturaComercial;
						for (int nCont = 0;nCont < typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows.Count;nCont++)
						{
							dtrwProdutoFaturaComercial = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow)typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows[nCont];
							if (dtrwProdutoFaturaComercial.idOrdem == nIdOrdemProduto)
							{
								if (!dtrwProdutoFaturaComercial.IsstrUnidadeNull())
									strRetorno = dtrwProdutoFaturaComercial.strUnidade;
								break;
							}
						}
						return(strRetorno);
					}
				#endregion
				#region Produtos
					static internal int nRetornaIdProduto(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial typDatSetTbProdutosFaturaComercial, int nIdOrdemProduto)
					{
						int nRetorno = -1;
						mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFaturaComercial;
						for (int nCont = 0;nCont < typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows.Count;nCont++)
						{
							dtrwProdutoFaturaComercial = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow)typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows[nCont];
							if (dtrwProdutoFaturaComercial.idOrdem == nIdOrdemProduto)
							{
								if (!dtrwProdutoFaturaComercial.IsidProdutoNull())
									nRetorno = dtrwProdutoFaturaComercial.idProduto;
								break;
							}
						}
						return(nRetorno);
					} 

					static internal string strRetornaDescricaoProdutoFatura(ref mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetTbProdutos,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas typDatSetTbProdutosIdiomas,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial typDatSetTbProdutosFaturaComercial,int nIdExportador,int nIdIdioma,int nIdOrdemProduto)
					{
						mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFaturaComercial;
						for (int nCont = 0;nCont < typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows.Count;nCont++)
						{
							dtrwProdutoFaturaComercial = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow)typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows[nCont];
							if ((dtrwProdutoFaturaComercial.idOrdem == nIdOrdemProduto) && (!dtrwProdutoFaturaComercial.IsidProdutoNull()))
							{
								if (!dtrwProdutoFaturaComercial.IsmstrDescricaoNull())
									return(dtrwProdutoFaturaComercial.mstrDescricao);
                                return(strRetornaDescricaoProduto(ref typDatSetTbProdutos,ref typDatSetTbProdutosIdiomas,nIdExportador,nIdIdioma,dtrwProdutoFaturaComercial.idProduto));
							}
						}
						return("");
					}

					static internal string strRetornaDescricaoProduto(ref mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetTbProdutos,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas typDatSetTbProdutosIdiomas,int nIdExportador,int nIdIdioma,int nIdProduto)
					{
						string strRetorno = strRetornaDescricaoProdutoIdioma(ref typDatSetTbProdutosIdiomas,nIdExportador,nIdIdioma,nIdProduto);
						if (strRetorno.Trim() == "")
						{
							mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwProduto = (mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow)typDatSetTbProdutos.tbProdutos.FindByidExportadoridProduto(nIdExportador,nIdProduto);                    
							if (dtrwProduto != null)
							{
								if (!dtrwProduto.IsmstrDescricaoNull())
									strRetorno = dtrwProduto.mstrDescricao;	
							}
						}
						return(strRetorno);
					}

					static internal string strRetornaDescricaoProdutoIdioma(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas typDatSetTbProdutosIdiomas,int nIdExportador,int nIdIdioma,int nIdProduto)
					{
						string strRetorno = "";
						mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas.tbProdutosIdiomasRow dtrwProdutoIdioma = (mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas.tbProdutosIdiomasRow)typDatSetTbProdutosIdiomas.tbProdutosIdiomas.FindByidExportadoridIdiomaidProduto(nIdExportador,nIdIdioma,nIdProduto);                    
						if (dtrwProdutoIdioma != null)
						{
							if (!dtrwProdutoIdioma.IsmstrDescricaoNull())
								strRetorno = dtrwProdutoIdioma.mstrDescricao;	
							else if (!dtrwProdutoIdioma.IsstrDescricaoNull())
								strRetorno = dtrwProdutoIdioma.strDescricao;	
						}
						return (strRetorno);
					}
				#endregion
				#region UnidadeMassa
					static internal string strRetornaSiglaUnidadeMassa(ref mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassa typDatSetTbUnidadesMassa,ref mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassaIdioma typDatSetTbUnidadesMassaIdioma,int nIdUnidadeMassa,int nIdIdioma)
					{
						string strRetorno = strRetornaSiglaUnidadeMassaIdioma(ref typDatSetTbUnidadesMassaIdioma,nIdUnidadeMassa,nIdIdioma);
						if (strRetorno.Trim() == "")
						{
							mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassa.tbUnidadesMassaRow dtrwUnidadesMassa = (mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassa.tbUnidadesMassaRow)typDatSetTbUnidadesMassa.tbUnidadesMassa.FindBynIdUnidadeMassa(nIdUnidadeMassa);                    
							if (dtrwUnidadesMassa != null)
							{
								strRetorno = dtrwUnidadesMassa.strSigla;	
							}
						}
						return(strRetorno);
					}

					static internal string strRetornaSiglaUnidadeMassaIdioma(ref mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassaIdioma typDatSetTbUnidadesMassaIdioma,int nIdUnidadeMassa,int nIdIdioma)
					{
						string strRetorno = "";
						mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassaIdioma.tbUnidadesMassaIdiomaRow dtrwUnidadeMassaIdioma = (mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassaIdioma.tbUnidadesMassaIdiomaRow)typDatSetTbUnidadesMassaIdioma.tbUnidadesMassaIdioma.FindBynIdUnidadeMassanIdIdioma(nIdUnidadeMassa,nIdIdioma);                    
						if (dtrwUnidadeMassaIdioma != null)
						{
							strRetorno = dtrwUnidadeMassaIdioma.strSigla;	
						}
						return (strRetorno);
					}
				#endregion
				#region UnidadeMetrica
					static internal string strRetornaSiglaUnidadeMetrica(ref mdlDataBaseAccess.Tabelas.XsdTbUnidadesEspaco typDatSetTbUnidadesEspaco,ref mdlDataBaseAccess.Tabelas.XsdTbUnidadesEspacoIdioma typDatSetTbUnidadesEspacoIdioma,int nIdUnidadeEspaco,int nIdIdioma)
					{
						string strRetorno = strRetornaSiglaUnidadeMetricaIdioma(ref typDatSetTbUnidadesEspacoIdioma,nIdUnidadeEspaco,nIdIdioma);
						if (strRetorno.Trim() == "")
						{
							mdlDataBaseAccess.Tabelas.XsdTbUnidadesEspaco.tbUnidadesEspacoRow dtrwUnidadesEspaco = (mdlDataBaseAccess.Tabelas.XsdTbUnidadesEspaco.tbUnidadesEspacoRow)typDatSetTbUnidadesEspaco.tbUnidadesEspaco.FindBynIdUnidadeEspaco(nIdUnidadeEspaco);                    
							if (dtrwUnidadesEspaco != null)
							{
								strRetorno = dtrwUnidadesEspaco.strSigla;	
							}
						}
						return(strRetorno);
					}

					static internal string strRetornaSiglaUnidadeMetricaIdioma(ref mdlDataBaseAccess.Tabelas.XsdTbUnidadesEspacoIdioma typDatSetTbUnidadesEspacoIdioma,int nIdUnidadeEspaco,int nIdIdioma)
					{
						string strRetorno = "";
						mdlDataBaseAccess.Tabelas.XsdTbUnidadesEspacoIdioma.tbUnidadesEspacoIdiomaRow dtrwUnidadeEspacoIdioma = (mdlDataBaseAccess.Tabelas.XsdTbUnidadesEspacoIdioma.tbUnidadesEspacoIdiomaRow)typDatSetTbUnidadesEspacoIdioma.tbUnidadesEspacoIdioma.FindBynIdUnidadeEspaconIdIdioma(nIdUnidadeEspaco,nIdIdioma);                    
						if (dtrwUnidadeEspacoIdioma != null)
						{
							strRetorno = dtrwUnidadeEspacoIdioma.strSigla;	
						}
						return (strRetorno);
					}
				#endregion
			#endregion
		#endregion

		#region Constants
			internal const double PRECISAO_PESOLIQUIDO_TOTAL = 0.001;
		#endregion
		#region Atributes
		// ***************************************************************************************************
		// Atributos
		// ***************************************************************************************************
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro; 
		protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB;
		protected string m_strEnderecoExecutavel; 

		private int m_nIdExportador;
		private string m_strIdPe;

		private int m_nIdIdioma = -1;

		//Default
		private int m_nIdTipoVolumeDefault = -1;
		private string m_strDescricaoVolumeDefault = "";

		// Formularios 
		frmFProdutos m_formFProdutos = null;

		// Ordenacao Produtos 
		private Ordenacao m_enumOrdenacao = Ordenacao.Volumes;

		// Fatura Comercial 
		private double m_dFaturaPesoLiquido = 0;
		private double m_dFaturaPesoBruto = 0;
		private int m_nIdUnidadeMassaFaturaPesoLiquido = 0;
		private int m_nIdUnidadeMassaFaturaPesoBruto = 0;

		// Romaneio
		private bool m_bMostrarEmbalagensIntermediarias = false;
		private bool m_bMostrarQuantidadeTotal = false;
		private bool m_bMostrarVolumesConsecutivos = false;
		private bool m_bMostrarEmbalagensConsecutivas = false;
		private int m_nQtdeVolume = 0;

		// Typed DataSets
		protected mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassa m_typDatSetTbUnidadesMassa;
		protected mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassaIdioma m_typDatSetTbUnidadesMassaIdioma;

		protected mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais m_typDatSetTbFaturasComerciais;

		protected mdlDataBaseAccess.Tabelas.XsdTbRomaneios m_typDatSetTbRomaneios;

		protected mdlDataBaseAccess.Tabelas.XsdTbProdutos m_typDatSetTbProdutos;
		protected mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas m_typDatSetTbProdutosIdiomas;
		protected mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial m_typDatSetTbProdutosFaturaComercial;

		protected mdlDataBaseAccess.Tabelas.XsdTbVolumes m_typDatSetTbVolumes;
		protected mdlDataBaseAccess.Tabelas.XsdTbExportadoresVolumes m_typDatSetTbExportadoresVolumes;

		protected mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens m_typDatSetTbProdutosRomaneioEmbalagens;
		protected mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos m_typDatSetTbProdutosRomaneioEmbalagensProdutos;
		protected mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes m_typDatSetTbProdutosRomaneioVolumes;
		protected mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos m_typDatSetTbProdutosRomaneioVolumesProdutos;

		private System.Drawing.Color m_clrQuantidadeInteira = System.Drawing.Color.Red;
		private System.Drawing.Color m_clrQuantidadeMetade = System.Drawing.Color.Orange;
		private System.Drawing.Color m_clrQuantidadeNada = System.Drawing.Color.Green;

		public bool m_bModificado = false;
		// ***************************************************************************************************
		#endregion
		#region Properties
			public int TOTALVOLUMES
			{
				get
				{
					return m_nQtdeVolume;
				}
			}

			public bool HasProducts
			{
				get
				{
					if (m_typDatSetTbProdutosRomaneioVolumesProdutos == null)
						return(false);
					return(m_typDatSetTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutos.Rows.Count > 0);
				}
			}
		#endregion
		#region Constructors and Destructors
		public clsProdutosRomaneio(ref mdlTratamentoErro.clsTratamentoErro tratadorErro , ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB , string strEnderecoExecutavel,int idExportador, string idPe)
		{
			m_cls_ter_tratadorErro = tratadorErro; 
			m_cls_dba_ConnectionDB = ConnectionDB;
			m_strEnderecoExecutavel = strEnderecoExecutavel; 

			m_strIdPe = idPe;
			m_nIdExportador = idExportador;

			this.CarregaDadosBD();
		}
		#endregion

		#region ShowDialog
		public void ShowDialog()
		{
			m_formFProdutos = new frmFProdutos(ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel);
			m_formFProdutos.UsarEmbalagemIntermediaria = m_bMostrarEmbalagensIntermediarias;
			InitializeEventsFormProdutosRomaneio();
			m_formFProdutos.ShowDialog();
			m_bModificado = m_formFProdutos.m_bModificado;
			m_formFProdutos = null;
		}

		private void InitializeEventsFormProdutosRomaneio()
		{
				#region Carregamento dos Dados
					// Carrega os Dados na Interface
					m_formFProdutos.eCallCarregaDadosInterface += new frmFProdutos.delCallCarregaDadosInterface(CarregaDadosInterface);

					// Carrega os Dados na Interface Produtos Fatura
					m_formFProdutos.eCallCarregaDadosInterfaceProdutosFatura += new frmFProdutos.delCallCarregaDadosInterfaceProdutosFatura(CarregaDadosInterfaceProdutosFatura);

					// Carrega os Dados na Interface Embalagens
					m_formFProdutos.eCallCarregaDadosInterfaceEmbalagens += new frmFProdutos.delCallCarregaDadosInterfaceEmbalagens(CarregaDadosInterfaceEmbalagens);

					// Carrega os Dados na Interface Volumes
					m_formFProdutos.eCallCarregaDadosInterfaceVolumes += new frmFProdutos.delCallCarregaDadosInterfaceVolumes(CarregaDadosInterfaceVolumes);

					// Carrega os Dados da Fatura Comercial
					m_formFProdutos.eCallCarregaDadosFaturaComercial += new frmFProdutos.delCallCarregaDadosFaturaComercial(vCarregaDadosFaturaComercial);
				
					// Carrega os Dados do Romaneio
					m_formFProdutos.eCallCarregaDadosRomaneio += new frmFProdutos.delCallCarregaDadosRomaneio(vCarregaDadosRomaneio);

					// Carrega os Dados Mostrar Quantidade Total
					m_formFProdutos.eCallCarregaDadosMostrarQuantidadeTotal += new mdlProdutosRomaneio.frmFProdutos.delCallCarregaDadosMostrarQuantidadeTotal(bMostrarQuantidadeTotal);
				#endregion
				#region Embalagens
					// Show Dialog de uma Nova Embalagem
					m_formFProdutos.eCallEmbalagemNova += new frmFProdutos.delCallEmbalagemNova(ShowDialogEmbalagemNova);

					// Excluindo Embalagens
					m_formFProdutos.eCallEmbalagemExclui += new frmFProdutos.delCallEmbalagemExclui(bEmbalagensExclui);

					// Show Dialog das Informacoes da Embalagem 
					m_formFProdutos.eCallEmbalagemInformacoes += new frmFProdutos.delCallEmbalagemInformacoes(ShowDialogEmbalagemInformacoes);

					// Show Dialog DragDrop vindo dos Produtos
					m_formFProdutos.eCallEmbalagemDragDropProdutos += new frmFProdutos.delCallEmbalagemDragDropProdutos(ShowDialogFormProdutosProdutosEmbalagens);
				#endregion
				#region Volumes
					// Show Dialog de um Novo Volume
					m_formFProdutos.eCallVolumeNovo += new frmFProdutos.delCallVolumeNovo(ShowDialogVolumeNovo);

					// Excluindo Embalagens
					m_formFProdutos.eCallVolumeExclui += new frmFProdutos.delCallVolumeExclui(bVolumesExclui);

					// Show Dialog das Informacoes Volume
					m_formFProdutos.eCallVolumeInformacoes += new frmFProdutos.delCallVolumeInformacoes(ShowDialogVolumeInformacoes);

					// Set Quantidade Total 
					m_formFProdutos.eCallSetMostrarQuantidadeTotal += new frmFProdutos.delCallSetMostrarQuantidadeTotal(bSetMostrarQuantidadeTotal);

					// Show Dialog DragDrop vindo dos Produtos
					m_formFProdutos.eCallVolumeDragDropProdutos += new frmFProdutos.delCallVolumeDragDropProdutos(ShowDialogFormProdutosProdutosVolumes);

					// Drag Drop das Embalagens em cima de um volume
					m_formFProdutos.eCallVolumeDragDropEmbalagens += new frmFProdutos.delCallVolumeDragDropEmbalagens(bInsereEmbalagensNoVolume);
				#endregion
				#region ShowDialog
					// Show Dialog Configuracoes
					m_formFProdutos.eCallShowDialogConfiguracoes += new frmFProdutos.delCallShowDialogConfiguracoes(ShowDialogConfiguracoes);
				#endregion
				#region Salvamento dos Dados
					// Salva os Dados no BD
					m_formFProdutos.eCallSalvaDadosBD += new frmFProdutos.delCallSalvaDadosBD(SalvaDadosBD);
				#endregion
					
				m_formFProdutos.eCallShowDialogAutomatico += new mdlProdutosRomaneio.frmFProdutos.delCallShowDialogAutomatico(ShowDialogAutomatico);
				
		}

		#region Fatura Comercial
			private void vCarregaDadosFaturaComercial(out string strPesoLiquido,out string strPesoBruto)
			{
				strPesoLiquido = m_dFaturaPesoLiquido.ToString() + " " + strRetornaSiglaUnidadeMassa(ref m_typDatSetTbUnidadesMassa,ref m_typDatSetTbUnidadesMassaIdioma,m_nIdUnidadeMassaFaturaPesoLiquido,m_nIdIdioma);
				strPesoBruto = m_dFaturaPesoBruto.ToString() + " " + strRetornaSiglaUnidadeMassa(ref m_typDatSetTbUnidadesMassa,ref m_typDatSetTbUnidadesMassaIdioma,m_nIdUnidadeMassaFaturaPesoBruto,m_nIdIdioma);
			}
		#endregion
		#region Romaneio
			private void vCarregaDadosRomaneio(out string strPesoLiquido,out string strPesoBruto)
			{
				double dPesoLiquido = 0;
				double dPesoBruto = 0;
				int nRomaneioPrecisaoPesoLiquidoTotal,nRomaneioPrecisaoPesoBrutoTotal;
				bool bRomaneioPrecisaoPesoLiquidoTotalArredondar,bRomaneioPrecisaoPesoBrutoTotalArredondar;
				vRomaneioCarregaPreferencias(ref m_cls_dba_ConnectionDB,out nRomaneioPrecisaoPesoLiquidoTotal,out nRomaneioPrecisaoPesoBrutoTotal,out bRomaneioPrecisaoPesoLiquidoTotalArredondar,out bRomaneioPrecisaoPesoBrutoTotalArredondar);
				foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumesRow dtrwVolume in m_typDatSetTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumes.Rows)
				{
					if (dtrwVolume.RowState != System.Data.DataRowState.Deleted)
					{
						if ((!dtrwVolume.IsdPesoLiquidoNull()) && (!dtrwVolume.IsnUnidadeMassaPesoLiquidoNull()))
						{
							if (m_nIdUnidadeMassaFaturaPesoLiquido == dtrwVolume.nUnidadeMassaPesoLiquido)
							{
								dPesoLiquido = System.Math.Round(dPesoLiquido + dtrwVolume.dPesoLiquido,8);
							}
							else
							{
								dPesoLiquido = System.Math.Round(dPesoLiquido + ((dRetornaFatorConversaoEntreUnidadesMassa(dtrwVolume.nUnidadeMassaPesoLiquido,m_nIdUnidadeMassaFaturaPesoLiquido)) * dtrwVolume.dPesoLiquido),8);
							}
						}
						if ((!dtrwVolume.IsdPesoBrutoNull()) && (!dtrwVolume.IsnUnidadeMassaPesoBrutoNull()))
						{
							if (m_nIdUnidadeMassaFaturaPesoBruto == dtrwVolume.nUnidadeMassaPesoBruto)
							{
								dPesoBruto = System.Math.Round(dPesoBruto + dtrwVolume.dPesoBruto,8);
							}
							else
							{
								dPesoBruto = System.Math.Round(dPesoBruto + ((dRetornaFatorConversaoEntreUnidadesMassa(dtrwVolume.nUnidadeMassaPesoBruto,m_nIdUnidadeMassaFaturaPesoBruto)) * dtrwVolume.dPesoBruto),8);
							}
						}
					}
				}
				if (bRomaneioPrecisaoPesoLiquidoTotalArredondar)
					strPesoLiquido = System.Math.Round(dPesoLiquido,nRomaneioPrecisaoPesoLiquidoTotal).ToString(strRetornaFormato(nRomaneioPrecisaoPesoLiquidoTotal));
				else
					strPesoLiquido = mdlConversao.clsTruncamento.dRound(dPesoLiquido,nRomaneioPrecisaoPesoLiquidoTotal).ToString(strRetornaFormato(nRomaneioPrecisaoPesoLiquidoTotal));
				if (bRomaneioPrecisaoPesoBrutoTotalArredondar)
					strPesoBruto = System.Math.Round(dPesoBruto,nRomaneioPrecisaoPesoBrutoTotal).ToString(strRetornaFormato(nRomaneioPrecisaoPesoBrutoTotal));
				else
					strPesoBruto = mdlConversao.clsTruncamento.dRound(dPesoLiquido,nRomaneioPrecisaoPesoBrutoTotal).ToString(strRetornaFormato(nRomaneioPrecisaoPesoBrutoTotal));
			}

			private void vCarregaDadosRomaneio(out string strPesoLiquido,out string strPesoBruto,out double dDiferencaPesoLiquido,out double dDiferencaPesoBruto)
			{
				decimal dcPesoLiquido = 0;
				decimal dcPesoBruto = 0;
				foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumesRow dtrwVolume in m_typDatSetTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumes.Rows)
				{
					if (dtrwVolume.RowState != System.Data.DataRowState.Deleted)
					{
						if ((!dtrwVolume.IsdPesoLiquidoNull()) && (!dtrwVolume.IsnUnidadeMassaPesoLiquidoNull()))
						{
							if (m_nIdUnidadeMassaFaturaPesoLiquido == dtrwVolume.nUnidadeMassaPesoLiquido)
							{
								dcPesoLiquido = System.Math.Round(dcPesoLiquido + (decimal)dtrwVolume.dPesoLiquido,8);
							}
							else
							{
								dcPesoLiquido = System.Math.Round(dcPesoLiquido + (decimal)((dRetornaFatorConversaoEntreUnidadesMassa(dtrwVolume.nUnidadeMassaPesoLiquido,m_nIdUnidadeMassaFaturaPesoLiquido)) * dtrwVolume.dPesoLiquido),8);
							}
						}
						if ((!dtrwVolume.IsdPesoBrutoNull()) && (!dtrwVolume.IsnUnidadeMassaPesoBrutoNull()))
						{
							if (m_nIdUnidadeMassaFaturaPesoBruto == dtrwVolume.nUnidadeMassaPesoBruto)
							{
								dcPesoBruto = System.Math.Round(dcPesoBruto + (decimal)dtrwVolume.dPesoBruto,8);
							}
							else
							{
								dcPesoBruto = System.Math.Round(dcPesoBruto + (decimal)((dRetornaFatorConversaoEntreUnidadesMassa(dtrwVolume.nUnidadeMassaPesoBruto,m_nIdUnidadeMassaFaturaPesoBruto)) * dtrwVolume.dPesoBruto),8);
							}
						}
					}
				}
				strPesoLiquido = dcPesoLiquido.ToString() + " " + strRetornaSiglaUnidadeMassa(ref m_typDatSetTbUnidadesMassa,ref m_typDatSetTbUnidadesMassaIdioma,m_nIdUnidadeMassaFaturaPesoLiquido,m_nIdIdioma);
				strPesoBruto = dcPesoBruto.ToString() + " " + strRetornaSiglaUnidadeMassa(ref m_typDatSetTbUnidadesMassa,ref m_typDatSetTbUnidadesMassaIdioma,m_nIdUnidadeMassaFaturaPesoBruto,m_nIdIdioma);
				dDiferencaPesoLiquido = (double)((decimal)m_dFaturaPesoLiquido - dcPesoLiquido);
				dDiferencaPesoBruto = (double)((decimal)m_dFaturaPesoBruto - dcPesoBruto);
			}
		#endregion

		private bool bEmbalagensExclui(ref System.Collections.ArrayList arlEmbalagensExcluir)
		{
			return(bEmbalagensExclui(ref m_typDatSetTbProdutosRomaneioEmbalagens,ref m_typDatSetTbProdutosRomaneioEmbalagensProdutos, ref arlEmbalagensExcluir));
		}

		private bool ShowDialogFormProdutosProdutosEmbalagens(ref System.Collections.ArrayList arlProdutos,ref System.Collections.ArrayList arlEmbalagens)
		{
            return(ShowDialogProdutosEmbalagens(ref m_typDatSetTbProdutosRomaneioEmbalagens,ref m_typDatSetTbProdutosRomaneioEmbalagensProdutos,ref m_typDatSetTbProdutosRomaneioVolumesProdutos,ref arlProdutos,ref arlEmbalagens,false));
		}

		private bool ShowDialogFormProdutosProdutosVolumes(ref System.Collections.ArrayList arlProdutos,ref System.Collections.ArrayList arlVolumes)
		{
			return(ShowDialogProdutosVolumes(ref m_typDatSetTbProdutosRomaneioEmbalagens,ref m_typDatSetTbProdutosRomaneioEmbalagensProdutos,ref m_typDatSetTbProdutosRomaneioVolumesProdutos,ref arlProdutos,ref arlVolumes,false));
		}

		#endregion
		#region ShowDialogProdutos
			private bool ShowDialogProdutosEmbalagens(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens typDatSetTbProdutosRomaneioEmbalagens, ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos typDatSetTbProdutosRomaneioEmbalagensProdutos,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos typDatSetTbProdutosRomaneioVolumesProdutos, ref System.Collections.ArrayList arlProdutos,ref System.Collections.ArrayList arlEmbalagens,bool bEdicao)
			{
				bool bRetorno = false;
				if (arlProdutos.Count == 1)
				{
					// Produtos = 1
					if (arlEmbalagens.Count == 1)
					{
						// Produtos = 1 // Embalagens = 1
						double dQuantidade;
						double dPesoLiquido;
						int nUnidadeMassaPesoLiquido;
						if (bRetorno = ShowDialogProdutosConteudoP1E1(ref typDatSetTbProdutosRomaneioEmbalagensProdutos,ref typDatSetTbProdutosRomaneioVolumesProdutos,Int32.Parse(arlProdutos[0].ToString()),arlEmbalagens[0].ToString(),bEdicao,false,out dQuantidade,out dPesoLiquido,out nUnidadeMassaPesoLiquido))
						{
							mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutosRow dtrwProduto = null;
							if (!bEdicao)
							{
								// Novo
								dtrwProduto = typDatSetTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutos.NewtbProdutosRomaneioEmbalagensProdutosRow();
								dtrwProduto.idExportador = m_nIdExportador;
								dtrwProduto.idPE = m_strIdPe;
								dtrwProduto.strIdEmbalagem = arlEmbalagens[0].ToString();
								dtrwProduto.nIdOrdemProduto = Int32.Parse(arlProdutos[0].ToString());
								dtrwProduto.dQuantidade = dQuantidade;
								dtrwProduto.dPesoLiquido = dPesoLiquido;
								dtrwProduto.nUnidadeMassaPesoLiquido = nUnidadeMassaPesoLiquido;
								typDatSetTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutos.AddtbProdutosRomaneioEmbalagensProdutosRow(dtrwProduto);
								bReCalculaPesoLiquidoVolumeEmbalagem(dtrwProduto.strIdEmbalagem);
							}else{
								// Edicao
								dtrwProduto = typDatSetTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutos.FindByidExportadoridPEstrIdEmbalagemnIdOrdemProduto(m_nIdExportador,m_strIdPe,arlEmbalagens[0].ToString(),Int32.Parse(arlProdutos[0].ToString()));
								if (dtrwProduto != null)
								{
									dtrwProduto.dQuantidade = dQuantidade;
									dtrwProduto.dPesoLiquido = dPesoLiquido;
									dtrwProduto.nUnidadeMassaPesoLiquido = nUnidadeMassaPesoLiquido;
									bReCalculaPesoLiquidoVolumeEmbalagem(dtrwProduto.strIdEmbalagem);
									dtrwProduto = null;
								}
							}
						}
					}
					else
					{
						// Produtos = 1 // Embalagens = N
					}
				}
				else
				{
					// Produtos = N
					if (arlEmbalagens.Count == 1)
					{
						// Produtos = N // Embalagens = 1
					}
					else
					{
						// Produtos = N // Embalagens = N
					}
				}
				return(bRetorno);
			}

			private bool ShowDialogProdutosVolumes(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens typDatSetTbProdutosRomaneioEmbalagens, ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos typDatSetTbProdutosRomaneioEmbalagensProdutos,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos typDatSetTbProdutosRomaneioVolumesProdutos,ref System.Collections.ArrayList arlProdutos,ref System.Collections.ArrayList arlVolumes,bool bEdicao)
			{
				bool bRetorno = false;
				if (arlProdutos.Count == 1)
				{
					// Produtos = 1
					if (arlVolumes.Count == 1)
					{
						double dQuantidade;
						double dPesoLiquido;
						int nUnidadeMassaPesoLiquido;
						// Produtos = 1 // Volumes = 1
						if (bRetorno = ShowDialogProdutosConteudoP1E1(ref typDatSetTbProdutosRomaneioEmbalagensProdutos,ref typDatSetTbProdutosRomaneioVolumesProdutos,Int32.Parse(arlProdutos[0].ToString()),arlVolumes[0].ToString(),bEdicao,true,out dQuantidade,out dPesoLiquido,out nUnidadeMassaPesoLiquido))
						{
							mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutosRow dtrwProduto = null;
							if (!bEdicao)
							{
								// Novo
								dtrwProduto = typDatSetTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutos.NewtbProdutosRomaneioVolumesProdutosRow();
								dtrwProduto.idExportador = m_nIdExportador;
								dtrwProduto.idPE = m_strIdPe;
								dtrwProduto.strNumeroVolume = arlVolumes[0].ToString();
								dtrwProduto.nIdOrdemProduto = Int32.Parse(arlProdutos[0].ToString());
							}
							else
							{
								// Edicao
								dtrwProduto = typDatSetTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutos.FindByidExportadoridPEstrNumeroVolumenIdOrdemProduto(m_nIdExportador,m_strIdPe,arlVolumes[0].ToString(),Int32.Parse(arlProdutos[0].ToString()));
								if (dtrwProduto != null)
								{
									dtrwProduto.dQuantidade = dQuantidade;
									dtrwProduto.dPesoLiquido = dPesoLiquido;
									dtrwProduto.nUnidadeMassaPesoLiquido = nUnidadeMassaPesoLiquido;
									bRecalculaPesoLiquidoVolume(dtrwProduto.strNumeroVolume);
									dtrwProduto = null;
								}
							}
							if (dtrwProduto != null)
							{
								dtrwProduto.dQuantidade = dQuantidade;
								dtrwProduto.dPesoLiquido = dPesoLiquido;
								dtrwProduto.nUnidadeMassaPesoLiquido = nUnidadeMassaPesoLiquido;
								typDatSetTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutos.AddtbProdutosRomaneioVolumesProdutosRow(dtrwProduto);
								bRecalculaPesoLiquidoVolume(dtrwProduto.strNumeroVolume);
							}
						}
					}
					else
					{
						// Produtos = 1 // Volumes = N
						if (bRetorno = ShowDialogProdutosConteudoP1EN(ref typDatSetTbProdutosRomaneioEmbalagensProdutos,ref typDatSetTbProdutosRomaneioVolumesProdutos,Int32.Parse(arlProdutos[0].ToString()),ref arlVolumes,true))
						{

						}
					}
				}
				else
				{
					// Produtos = N
					if (arlVolumes.Count == 1)
					{
						// Produtos = N // Volumes = 1
					}
					else
					{
						// Produtos = N // Volumes = N
					}
				}
				return(bRetorno);
			}

			#region ShowDialogProdutosConteudoP1E1
				private bool ShowDialogProdutosConteudoP1E1(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos typDatSetTbProdutosRomaneioEmbalagensProdutos,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos typDatSetTbProdutosRomaneioVolumesProdutos,int nIdOrdemProduto,string strConteudo,bool bEdicao,bool bVolume,out double dQuantidade,out double dPesoLiquido,out int nUnidadeMassaPesoLiquido)
				{
					bool bRetorno = false;
					double dQuantidadeDefault;
					double dQuantidadeRestante;
					string strUnidadeQuantidade = strRetornaUnidadeQuantidadeProdutoFatura(ref m_typDatSetTbProdutosFaturaComercial,nIdOrdemProduto);
					double dQuantidadeTotal;

					dQuantidade = 0;
					dPesoLiquido = 0;
					nUnidadeMassaPesoLiquido = m_nIdUnidadeMassaFaturaPesoLiquido;
					if (nUnidadeMassaPesoLiquido == 0)
						nUnidadeMassaPesoLiquido = 1;

					RetornaQuantidadeRestante(ref typDatSetTbProdutosRomaneioEmbalagensProdutos,ref typDatSetTbProdutosRomaneioVolumesProdutos,nIdOrdemProduto,out dQuantidadeRestante,out dQuantidadeTotal);
					dQuantidadeDefault = dQuantidadeRestante;
					if (bEdicao)
					{
						if (!bVolume)
						{
							// Procurando nas Embalagens
							mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutosRow dtrwProdutoEmbalagem;
							for (int nCont = 0; nCont < typDatSetTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutos.Rows.Count;nCont++)
							{
								dtrwProdutoEmbalagem = (mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutosRow)typDatSetTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutos.Rows[nCont];
								if (dtrwProdutoEmbalagem.RowState != System.Data.DataRowState.Deleted)
								{
									if ((dtrwProdutoEmbalagem.strIdEmbalagem == strConteudo) && (dtrwProdutoEmbalagem.nIdOrdemProduto == nIdOrdemProduto))
									{
										dQuantidadeDefault = dtrwProdutoEmbalagem.dQuantidade;
										dQuantidadeRestante = System.Math.Round(dQuantidadeRestante + dtrwProdutoEmbalagem.dQuantidade,8);
										dPesoLiquido = dtrwProdutoEmbalagem.dPesoLiquido;
										nUnidadeMassaPesoLiquido = dtrwProdutoEmbalagem.nUnidadeMassaPesoLiquido;
										break;
									} 
								}
							}
						}else{
							// Procurando nos Volumes
							mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutosRow dtrwProdutoVolume;
							for (int nCont = 0; nCont < typDatSetTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutos.Rows.Count;nCont++)
							{
								dtrwProdutoVolume = (mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutosRow)typDatSetTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutos.Rows[nCont];
								if (dtrwProdutoVolume.RowState != System.Data.DataRowState.Deleted)
								{
									if ((dtrwProdutoVolume.strNumeroVolume == strConteudo) && (dtrwProdutoVolume.nIdOrdemProduto == nIdOrdemProduto))
									{
										dQuantidadeDefault = dtrwProdutoVolume.dQuantidade;
										dQuantidadeRestante = System.Math.Round(dQuantidadeRestante + dtrwProdutoVolume.dQuantidade);
										dPesoLiquido = dtrwProdutoVolume.dPesoLiquido;
										nUnidadeMassaPesoLiquido = dtrwProdutoVolume.nUnidadeMassaPesoLiquido;
										break;
									} 
								}
							}
						}
					}

					if (dQuantidadeRestante > 0)
					{
						string strDescricaoProduto = strRetornaDescricaoProduto(ref m_typDatSetTbProdutos,ref m_typDatSetTbProdutosIdiomas,m_nIdExportador,m_nIdIdioma,nRetornaIdProduto(ref m_typDatSetTbProdutosFaturaComercial,nIdOrdemProduto));
						frmFProdutosConteudoP1C1 formFProdutosConteudoP1C1 = new frmFProdutosConteudoP1C1(ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel,strDescricaoProduto,strConteudo,dQuantidadeDefault,dQuantidadeRestante,strUnidadeQuantidade,dPesoLiquido,nUnidadeMassaPesoLiquido);
						InitializeEventsFormEmbalagemInserindoProdutosP1E1(ref formFProdutosConteudoP1C1);
						formFProdutosConteudoP1C1.Icon = m_formFProdutos.Icon;
						formFProdutosConteudoP1C1.ShowDialog();
						if (bRetorno = formFProdutosConteudoP1C1.m_bModificado)
						{
							formFProdutosConteudoP1C1.RetornaValores(out dQuantidade,out dPesoLiquido, out nUnidadeMassaPesoLiquido);
						}
						formFProdutosConteudoP1C1 = null;
					}
					return(bRetorno);
				}

				private void InitializeEventsFormEmbalagemInserindoProdutosP1E1(ref frmFProdutosConteudoP1C1 formFProdutosConteudoP1C1)
				{
					// Carregando a Unidade Massa do Peso Liquido
					formFProdutosConteudoP1C1.eCallCarregaDadosInterfaceUnidadeMassaPesoLiquido += new frmFProdutosConteudoP1C1.delCallCarregaDadosInterfaceUnidadeMassaPesoLiquido(strRetornaSiglaUnidadeMassa);
				}
			#endregion
			#region ShowDialogProdutosConteudoP1EN
				private bool ShowDialogProdutosConteudoP1EN(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos typDatSetTbProdutosRomaneioEmbalagensProdutos,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos typDatSetTbProdutosRomaneioVolumesProdutos,int nIdOrdemProduto,ref System.Collections.ArrayList arlEmbalagens,bool bVolume)
				{
					bool bRetorno = false;
					string strUnidadeQuantidade = strRetornaUnidadeQuantidadeProdutoFatura(ref m_typDatSetTbProdutosFaturaComercial,nIdOrdemProduto);
					string strDescricaoProduto = strRetornaDescricaoProduto(ref m_typDatSetTbProdutos,ref m_typDatSetTbProdutosIdiomas,m_nIdExportador,m_nIdIdioma,nRetornaIdProduto(ref m_typDatSetTbProdutosFaturaComercial,nIdOrdemProduto));
					double dQuantidadeRestante,dQuantidadeTotal;
					RetornaQuantidadeRestante(ref typDatSetTbProdutosRomaneioEmbalagensProdutos,ref typDatSetTbProdutosRomaneioVolumesProdutos,nIdOrdemProduto,out dQuantidadeRestante,out dQuantidadeTotal);
					frmFProdutosConteudoP1CN formFProdutosConteudoP1CN = null;
					mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos typDatSetTbProdutosRomaneioEmbalagensProdutosTemp = (mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos)typDatSetTbProdutosRomaneioEmbalagensProdutos.Copy();;
					mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos typDatSetTbProdutosRomaneioVolumesProdutosTemp = (mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos)typDatSetTbProdutosRomaneioVolumesProdutos.Copy();
					if (!bVolume)
					{
						// Embalagem

					}else{
						// Volume
						formFProdutosConteudoP1CN = new frmFProdutosConteudoP1CN(ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPe,true,nIdOrdemProduto,strDescricaoProduto,dQuantidadeTotal,ref arlEmbalagens,ref typDatSetTbProdutosRomaneioEmbalagensProdutosTemp,ref typDatSetTbProdutosRomaneioVolumesProdutosTemp);
					}
					InitializeEvents(ref formFProdutosConteudoP1CN);

					formFProdutosConteudoP1CN.Icon = m_formFProdutos.Icon;
					formFProdutosConteudoP1CN.ShowDialog();
					if (bRetorno = formFProdutosConteudoP1CN.m_bModificado)
					{
						typDatSetTbProdutosRomaneioEmbalagensProdutos = typDatSetTbProdutosRomaneioEmbalagensProdutosTemp;
						typDatSetTbProdutosRomaneioVolumesProdutos = typDatSetTbProdutosRomaneioVolumesProdutosTemp;
					}
					formFProdutosConteudoP1CN = null;
					return(bRetorno);
				}

				private void InitializeEvents(ref frmFProdutosConteudoP1CN formFProdutosConteudoP1CN)
				{
					// Carregando a Unidade Massa do Peso Liquido
					formFProdutosConteudoP1CN.eCallCarregaDadosInterfaceUnidadeMassaPesoLiquido += new frmFProdutosConteudoP1CN.delCallCarregaDadosInterfaceUnidadeMassaPesoLiquido(strRetornaSiglaUnidadeMassa);
				}
			#endregion
			#region ShowDialogProdutosConteudoPNE1
			#endregion
			#region ShowDialogProdutosConteudoPNEN
			#endregion

			#region ShowDialogProdutosEdita	
				private bool ShowDialogProdutosEmbalagensEdita(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens typDatSetTbProdutosRomaneioEmbalagens,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos typDatSetTbProdutosRomaneioEmbalagensProdutos,ref System.Collections.ArrayList arlProdutos,ref System.Collections.ArrayList arlEmbalagens)
				{
					return(ShowDialogProdutosEmbalagens(ref typDatSetTbProdutosRomaneioEmbalagens,ref typDatSetTbProdutosRomaneioEmbalagensProdutos,ref m_typDatSetTbProdutosRomaneioVolumesProdutos,ref arlProdutos,ref arlEmbalagens,true));
				}

				private bool ShowDialogProdutosVolumes(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens typDatSetTbProdutosRomaneioEmbalagens, ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos typDatSetTbProdutosRomaneioEmbalagensProdutos,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos typDatSetTbProdutosRomaneioVolumesProdutos,ref System.Collections.ArrayList arlProdutos,ref System.Collections.ArrayList arlVolumes)
				{
					return(ShowDialogProdutosVolumes(ref typDatSetTbProdutosRomaneioEmbalagens,ref typDatSetTbProdutosRomaneioEmbalagensProdutos,ref typDatSetTbProdutosRomaneioVolumesProdutos,ref arlProdutos,ref arlVolumes,true));
				}
			#endregion
		#endregion
		#region ShowDialogConfiguracoes
			private bool ShowDialogConfiguracoes()
			{
				bool bReturno = false;
				Formularios.frmFProdutosConfiguracoes formFConfiguracoes = new mdlProdutosRomaneio.Formularios.frmFProdutosConfiguracoes(m_strEnderecoExecutavel);
				formFConfiguracoes.MostrarQuantidadesVolumes = m_bMostrarQuantidadeTotal;
				formFConfiguracoes.MostrarVolumesConsecutivos = m_bMostrarVolumesConsecutivos;
				formFConfiguracoes.MostrarEmbalagensConsecutivas = m_bMostrarEmbalagensConsecutivas;
				formFConfiguracoes.ShowDialog();
				if (bReturno = formFConfiguracoes.Modificado)
				{
					bSetMostrarQuantidadeTotal(formFConfiguracoes.MostrarQuantidadesVolumes);
					bSetConfiguracoesRomaneio(formFConfiguracoes.MostrarVolumesConsecutivos,formFConfiguracoes.MostrarEmbalagensConsecutivas);
				}
				return(bReturno);
			}
		#endregion
		#region ShowDialogAutomatico
			private bool ShowDialogAutomatico()
			{
				SalvaDadosBD();
				clsProdutosRomaneioAutomacao clsAutomacao = new clsProdutosRomaneioAutomacao(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPe);
				if (clsAutomacao.ShowDialog())
				{
					CarregaDadosBD();
					return(true);
				}
				return(false);
			}
		#endregion

		#region ShowDialogEmbalagemNova
		private bool ShowDialogEmbalagemNova()
		{
			bool bRetorno = false;
			frmFEmbalagemNova formFEmbalagemNova = new frmFEmbalagemNova(ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel);
			InitializeEventsFormEmbalagemNova(ref formFEmbalagemNova);
			formFEmbalagemNova.Icon = m_formFProdutos.Icon;
			formFEmbalagemNova.ShowDialog();
			if (bRetorno = formFEmbalagemNova.m_bModificado)
			{
				System.Collections.ArrayList arlEmbalagensNovas;
				formFEmbalagemNova.RetornaValores(out arlEmbalagensNovas);
				for (int nCont = 0; nCont < arlEmbalagensNovas.Count;nCont++)
				{
					m_typDatSetTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagens.AddtbProdutosRomaneioEmbalagensRow(m_nIdExportador,m_strIdPe,arlEmbalagensNovas[nCont].ToString(),"");
				}
			}
			formFEmbalagemNova = null;
			return(bRetorno); 
		}

		private void InitializeEventsFormEmbalagemNova(ref frmFEmbalagemNova formFEmbalagemNova)
		{
			// Retornando uma quantidade de Embalagens novas
			formFEmbalagemNova.eCallArlRetornaEmbalagens += new frmFEmbalagemNova.delCallArlRetornaEmbalagens(arlRetornaEmbalagensNovas);

			// Checando se as Embalagens sao inexistentes 
			formFEmbalagemNova.eCallEmbalagensInexistentes += new frmFEmbalagemNova.delCallEmbalagensInexistentes(bEmbalagensInexistentes);
		}

		#endregion
		#region ShowDialogEmbalagemInformacoes
		private bool ShowDialogEmbalagemInformacoes(ref System.Windows.Forms.ImageList ilEmbalagens, ref System.Collections.ArrayList arlEmbalagems)
		{
			bool bRetorno = false;
			frmFEmbalagemInformacoes formFEmbalagemInformacoes = new frmFEmbalagemInformacoes(ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel,m_typDatSetTbProdutosRomaneioEmbalagens,m_typDatSetTbProdutosRomaneioEmbalagensProdutos,ref ilEmbalagens, ref arlEmbalagems);
			InitializeEventsFormEmbalagemInformacoes(ref formFEmbalagemInformacoes);
			formFEmbalagemInformacoes.Icon = m_formFProdutos.Icon;
			formFEmbalagemInformacoes.ShowDialog();
			if (bRetorno = formFEmbalagemInformacoes.m_bModificado)
			{
				formFEmbalagemInformacoes.RetornaValores(out m_typDatSetTbProdutosRomaneioEmbalagens,out m_typDatSetTbProdutosRomaneioEmbalagensProdutos);
			}
			formFEmbalagemInformacoes = null;
			return(bRetorno); 
		}

		private bool ShowDialogEmbalagemInformacoes(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens typDatSetTbProdutosRomaneioEmbalagens,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos typDatSetTbProdutosRomaneioEmbalagensProdutos,ref System.Windows.Forms.ImageList ilEmbalagens, ref System.Collections.ArrayList arlEmbalagems)
		{
			bool bRetorno = false;
			frmFEmbalagemInformacoes formFEmbalagemInformacoes = new frmFEmbalagemInformacoes(ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel,typDatSetTbProdutosRomaneioEmbalagens,typDatSetTbProdutosRomaneioEmbalagensProdutos, ref ilEmbalagens, ref arlEmbalagems);
			InitializeEventsFormEmbalagemInformacoes(ref formFEmbalagemInformacoes);
			formFEmbalagemInformacoes.Icon = m_formFProdutos.Icon;
			formFEmbalagemInformacoes.ShowDialog();
			if (bRetorno = formFEmbalagemInformacoes.m_bModificado)
			{
				formFEmbalagemInformacoes.RetornaValores(out typDatSetTbProdutosRomaneioEmbalagens,out typDatSetTbProdutosRomaneioEmbalagensProdutos);
			}
			formFEmbalagemInformacoes = null;
			return(bRetorno); 
		}

		private void InitializeEventsFormEmbalagemInformacoes(ref frmFEmbalagemInformacoes formFEmbalagemInformacoes)
		{
			// Carregando as Embalagens 
			formFEmbalagemInformacoes.eCallCarregaDadosEmbalagens += new frmFEmbalagemInformacoes.delCallCarregaDadosEmbalagens(CarregaDadosInterfaceEmbalagens);

			// Carregandos os Dados da Embalagem Selecionada 
			formFEmbalagemInformacoes.eCallCarregaDadosEmbalagemSelecionada += new frmFEmbalagemInformacoes.delCallCarregaDadosEmbalagemSelecionada(RetornaInformacoesEmbalagem);

			// Carregando os produtos da Embalagem 
			formFEmbalagemInformacoes.eCallCarregaProdutosEmbalagem += new frmFEmbalagemInformacoes.delCallCarregaProdutosEmbalagem(CarregaDadosInterfaceEmbalagensProdutos);

			// Carrega Dados do Produto da Embalagem
			formFEmbalagemInformacoes.eCallShowDialogProdutoEmbalagem += new frmFEmbalagemInformacoes.delCallShowDialogProdutoEmbalagem(ShowDialogProdutosEmbalagensEdita);

			// Excluindo os Produtos da Embalagem
			formFEmbalagemInformacoes.eCallProdutosEmbalagemExclui += new frmFEmbalagemInformacoes.delCallProdutosEmbalagemExclui(bExcluiProdutosEmbalagem);

			// Verificando se a embalagem existe 
			formFEmbalagemInformacoes.eCallEmbalagemExistente += new frmFEmbalagemInformacoes.delCallEmbalagemExistente(bEmbalagemExiste);

			// Salvando o novo numero da embalagem
			formFEmbalagemInformacoes.eCallSalvaDadosEmbalagemNumeroEmbalagem += new frmFEmbalagemInformacoes.delCallSalvaDadosEmbalagemNumeroEmbalagem(clsProdutosRomaneio.SalvaDadosEmbalagemNumeroEmbalagem);
		}
		#endregion
		#region ShowDialogEmbalagemProdutos

		#endregion

		#region ShowDialogVolumeNovo
		private bool ShowDialogVolumeNovo(ref System.Windows.Forms.ImageList ilEmbalagens)
		{
			bool bRetorno = false;
			frmFVolumeNovo formFVolumeNovo = new frmFVolumeNovo(ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel,ref ilEmbalagens);
			InitializeEventsFormVolumeNovo(ref formFVolumeNovo);
			formFVolumeNovo.Icon = m_formFProdutos.Icon;
			formFVolumeNovo.ShowDialog();
			if (bRetorno = formFVolumeNovo.m_bModificado)
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumesRow dtrwVolume;
				System.Collections.ArrayList arlVolumesInserir,arlAltura,arlLargura,arlComprimento,arlVolume,arlPesoLiquido,arlPesoBruto;;
				int nIdVolumeTipo;
				string strDescricaoPopular;
				mdlProdutosRomaneio.UnidadeMedida enumUnidadeAltura,enumUnidadeLargura,enumUnidadeComprimento,enumUnidadeVolume;
				int nUnidadeMassaPesoLiquido,nUnidadeMassaPesoBruto;

				formFVolumeNovo.RetornaValores(out arlVolumesInserir,out nIdVolumeTipo,out strDescricaoPopular,out arlAltura,out arlLargura,out arlComprimento,out arlVolume,out arlPesoLiquido,out arlPesoBruto,out enumUnidadeAltura,out enumUnidadeLargura,out enumUnidadeComprimento,out enumUnidadeVolume,out nUnidadeMassaPesoLiquido,out nUnidadeMassaPesoBruto);
				for (int nCont = 0; nCont < arlVolumesInserir.Count;nCont++)
				{
					// Inserindo o Volume no Romaneio
					dtrwVolume = m_typDatSetTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumes.NewtbProdutosRomaneioVolumesRow();
					// Preenchendo os dados 
					dtrwVolume.idExportador = m_nIdExportador;
					dtrwVolume.idPE = m_strIdPe;
					dtrwVolume.strNumeroVolume = arlVolumesInserir[nCont].ToString();
					dtrwVolume.nlTipoVolume = nIdVolumeTipo;
					dtrwVolume.strTipoPopular = strDescricaoPopular;
					//Default
					m_nIdTipoVolumeDefault = nIdVolumeTipo;
					m_strDescricaoVolumeDefault = strDescricaoPopular;
					// dAltura
					if ((arlAltura != null) && (arlAltura[nCont] != null))
						dtrwVolume.dAltura = (double)arlAltura[nCont];
					// dLargura
					if ((arlLargura != null) && (arlLargura[nCont] != null))
						dtrwVolume.dLargura = (double)arlLargura[nCont];
					// dComprimento
					if ((arlComprimento != null) && (arlComprimento[nCont] != null))
						dtrwVolume.dComprimento = (double)arlComprimento[nCont];
					// dVolume
					if ((arlVolume != null) && (arlVolume[nCont] != null))
						dtrwVolume.dVolume = (double)arlVolume[nCont];
					// dPesoLiquido
					if ((arlPesoLiquido != null) && (arlPesoLiquido[nCont] != null))
						dtrwVolume.dPesoLiquido = (double)arlPesoLiquido[nCont];
					// dPesoBruto
					if ((arlPesoBruto != null) && (arlPesoBruto[nCont] != null))
						dtrwVolume.dPesoBruto = (double)arlPesoBruto[nCont];

					dtrwVolume.nUnidadeAltura = (int)enumUnidadeAltura;
					dtrwVolume.nUnidadeLargura = (int)enumUnidadeLargura;
					dtrwVolume.nUnidadeComprimento = (int)enumUnidadeComprimento;
					dtrwVolume.nUnidadeVolume = (int)enumUnidadeVolume;
					dtrwVolume.nUnidadeMassaPesoLiquido = nUnidadeMassaPesoLiquido;
					dtrwVolume.nUnidadeMassaPesoBruto = nUnidadeMassaPesoBruto;

					// Inserindo a linha
					m_typDatSetTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumes.AddtbProdutosRomaneioVolumesRow(dtrwVolume);
				}
			}
			formFVolumeNovo = null;
			return(bRetorno);
		}

		private void InitializeEventsFormVolumeNovo(ref frmFVolumeNovo formFVolumeNovo)
		{
			// Carregando os dados do Volume
			formFVolumeNovo.eCallCarregaDadosInterfaceVolumeTipo += new frmFVolumeNovo.delCallCarregaDadosInterfaceVolumeTipo(CarregaDadosInterfaceEmbalagemTipo);

			// Checando a Integridade dos Volumes
			formFVolumeNovo.eCallVolumesInexistentes += new frmFVolumeNovo.delCallVolumesInexistentes(bVolumesInexistentes);

			// ShowDialog do tipo do Volume
			formFVolumeNovo.eCallShowDialogVolumeTipo += new frmFVolumeNovo.delCallShowDialogVolumeTipo(ShowDialogVolumeTipo);

			// Retorna Sigla Unidade Espaco
			formFVolumeNovo.eCallRetornaSiglaUnidadeEspaco += new frmFVolumeNovo.delCallRetornaSiglaUnidadeEspaco(strRetornaSiglaUnidadeEspaco);

			// Retorna Sigla Unidade Massa
			formFVolumeNovo.eCallRetornaSiglaUnidadeMassa += new frmFVolumeNovo.delCallRetornaSiglaUnidadeMassa(strRetornaSiglaUnidadeMassa);
		}

			#region Eventos
				private void CarregaDadosInterfaceEmbalagemTipo(ref int nIdVolumeTipo,out int nIdVolumeImage,out string strDescricao,out string strDescricaoPopular)
				{
					if (nIdVolumeTipo != -1)
					{
						nIdVolumeImage = nRetornaIndiceImagemVolume(ref m_typDatSetTbVolumes,nIdVolumeTipo);
						strDescricao = strRetornaDescricaoVolume(nIdVolumeTipo);
						strDescricaoPopular = strRetornaDescricaoPopularVolume(nIdVolumeTipo);
					}else{
						nIdVolumeTipo = m_nIdTipoVolumeDefault;
						nIdVolumeImage = nRetornaIndiceImagemVolume(ref m_typDatSetTbVolumes,nIdVolumeTipo);
						strDescricao = strRetornaDescricaoVolume(nIdVolumeTipo);
						strDescricaoPopular = m_strDescricaoVolumeDefault;
					}
				}
			#endregion
		#endregion
		#region ShowDialogVolumeInformacoes
		private bool ShowDialogVolumeInformacoes(ref System.Windows.Forms.ImageList ilVolumes,ref System.Windows.Forms.ImageList ilEmbalagens, ref System.Collections.ArrayList arlVolumes)
		{
			bool bRetorno = false;
			frmFVolumeInformacoes formFVolumeInformacoes = new frmFVolumeInformacoes(ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel,m_typDatSetTbVolumes,m_typDatSetTbProdutosRomaneioVolumes,m_typDatSetTbProdutosRomaneioVolumesProdutos,m_typDatSetTbProdutosRomaneioEmbalagens,m_typDatSetTbProdutosRomaneioEmbalagensProdutos,ref ilVolumes,ref ilEmbalagens,ref arlVolumes);
			InitializeEventsFormVolumeInformacoes(ref formFVolumeInformacoes);
			formFVolumeInformacoes.Icon = m_formFProdutos.Icon;
			formFVolumeInformacoes.ShowDialog();
			if (bRetorno = formFVolumeInformacoes.m_bModificado)
			{
				formFVolumeInformacoes.RetornaValores(out m_typDatSetTbProdutosRomaneioVolumes,out m_typDatSetTbProdutosRomaneioVolumesProdutos,out m_typDatSetTbProdutosRomaneioEmbalagens,out m_typDatSetTbProdutosRomaneioEmbalagensProdutos);
			}
			formFVolumeInformacoes = null;
			return(bRetorno); 
		}

		private void InitializeEventsFormVolumeInformacoes(ref frmFVolumeInformacoes formFVolumeInformacoes)
		{
			#region Carregamento dos Dados
				//Carregando os Volumes
				formFVolumeInformacoes.eCallCarregaDadosVolumes += new frmFVolumeInformacoes.delCallCarregaDadosVolumes(CarregaDadosInterfaceVolumes);

				formFVolumeInformacoes.eCallCarregaInformacoesTipoVolume += new frmFVolumeInformacoes.delCallCarregaInformacoesTipoVolume(RetornaInformacoesTipoVolume);

				// Carregando as Informacoes do Volume Selecinado 
				formFVolumeInformacoes.eCallCarregaDadosVolumeSelecionado += new frmFVolumeInformacoes.delCallCarregaDadosVolumeSelecionado(RetornaInformacoesVolume);
	                
				// Carregendo os Produtos do Volume
				formFVolumeInformacoes.eCallCarregaDadosVolumeProdutos += new frmFVolumeInformacoes.delCallCarregaDadosVolumeProdutos(CarregaDadosInterfaceVolumesProdutos);

				// Carregando as Embalagens do Volume 
				formFVolumeInformacoes.eCallCarregaDadosVolumeEmbalagens += new frmFVolumeInformacoes.delCallCarregaDadosVolumeEmbalagens(CarregaDadosInterfaceVolumesEmbalagens);

				// Retorna Sigla Unidade Espaco
				formFVolumeInformacoes.eCallRetornaSiglaUnidadeEspaco += new frmFVolumeInformacoes.delCallRetornaSiglaUnidadeEspaco(strRetornaSiglaUnidadeEspaco);

				// Retorna Sigla Unidade Massa
				formFVolumeInformacoes.eCallRetornaSiglaUnidadeMassa += new frmFVolumeInformacoes.delCallRetornaSiglaUnidadeMassa(strRetornaSiglaUnidadeMassa);
			#endregion
			#region Produtos
				// Show Dialog dos Produtos do Volume
				formFVolumeInformacoes.eCallShowDialogProdutos += new frmFVolumeInformacoes.delCallShowDialogProdutos(ShowDialogProdutosVolumes);

				// Excluindo os Produtos do Volume
				formFVolumeInformacoes.eCallExcluiVolumeProdutos += new frmFVolumeInformacoes.delCallExcluiVolumeProdutos(bExcluiProdutosVolume);
			#endregion
			#region Embalagens
				// Show Dialog das Embalagens do Volume 
				formFVolumeInformacoes.eCallShowDialogEmbalagens += new frmFVolumeInformacoes.delCallShowDialogEmbalagens(ShowDialogEmbalagemInformacoes);

				// Exclui as embalagens do volume
				formFVolumeInformacoes.eCallExcluiVolumeEmbalagens += new frmFVolumeInformacoes.delCallExcluiVolumeEmbalagens(clsProdutosRomaneio.bRemoveEmbalagensVolume);
			
			#endregion
			#region Volume
			// ShowDialog do tipo do Volume
			formFVolumeInformacoes.eCallShowDialogVolumeTipo += new frmFVolumeInformacoes.delCallShowDialogVolumeTipo(ShowDialogVolumeTipo);

			// Salvando o Novo tipo de Volume 
			formFVolumeInformacoes.eCallSalvaDadosVolumeTipo += new frmFVolumeInformacoes.delCallSalvaDadosVolumeTipo(SalvaDadosVolumeTipo);
			#endregion
			#region Salvamento dos Dados
				// Show Dialog das Embalagens do Volume 
				formFVolumeInformacoes.eCallVolumeInexistente += new frmFVolumeInformacoes.delCallVolumeInexistente(bVolumeExiste);
				
				// Salva Novo Numero Volume
				formFVolumeInformacoes.eCallSalvaDadosVolumeNumeroVolume +=  new frmFVolumeInformacoes.delCallSalvaDadosVolumeNumeroVolume(SalvaDadosVolumeNumeroVolume);

				// Descricao Popular	
				formFVolumeInformacoes.eCallSalvaDadosVolumeDescricaoPopular += new frmFVolumeInformacoes.delCallSalvaDadosVolumeDescricaoPopular(SalvaDadosVolumeDescricaoPopular);

				// Altura
				formFVolumeInformacoes.eCallSalvaDadosVolumeAltura +=  new frmFVolumeInformacoes.delCallSalvaDadosVolumeAltura(SalvaDadosVolumeAltura);
				// Largura
				formFVolumeInformacoes.eCallSalvaDadosVolumeLargura +=  new frmFVolumeInformacoes.delCallSalvaDadosVolumeLargura(SalvaDadosVolumeLargura);
				// Comprimento
				formFVolumeInformacoes.eCallSalvaDadosVolumeComprimento +=  new frmFVolumeInformacoes.delCallSalvaDadosVolumeComprimento(SalvaDadosVolumeComprimento);
				// Volume
				formFVolumeInformacoes.eCallSalvaDadosVolumeVolume +=  new frmFVolumeInformacoes.delCallSalvaDadosVolumeVolume(SalvaDadosVolumeVolume);
				// Peso Liquido
				formFVolumeInformacoes.eCallSalvaDadosVolumePesoLiquido +=  new frmFVolumeInformacoes.delCallSalvaDadosVolumePesoLiquido(SalvaDadosVolumePesoLiquido);
				// Peso Bruto
				formFVolumeInformacoes.eCallSalvaDadosVolumePesoBruto +=  new frmFVolumeInformacoes.delCallSalvaDadosVolumePesoBruto(SalvaDadosVolumePesoBruto);

				// Altura Unidade
				formFVolumeInformacoes.eCallSalvaDadosVolumeAlturaUnidade +=  new frmFVolumeInformacoes.delCallSalvaDadosVolumeAlturaUnidade(SalvaDadosVolumeAlturaUnidade);
				// Largura Unidade
				formFVolumeInformacoes.eCallSalvaDadosVolumeLarguraUnidade +=  new frmFVolumeInformacoes.delCallSalvaDadosVolumeLarguraUnidade(SalvaDadosVolumeLarguraUnidade);
				// Comprimento Unidade
				formFVolumeInformacoes.eCallSalvaDadosVolumeComprimentoUnidade +=  new frmFVolumeInformacoes.delCallSalvaDadosVolumeComprimentoUnidade(SalvaDadosVolumeComprimentoUnidade);
				// Volume Unidade
				formFVolumeInformacoes.eCallSalvaDadosVolumeVolumeUnidade +=  new frmFVolumeInformacoes.delCallSalvaDadosVolumeVolumeUnidade(SalvaDadosVolumeVolumeUnidade);
				// Peso Liquido Unidade
				formFVolumeInformacoes.eCallSalvaDadosVolumePesoLiquidoUnidade +=  new frmFVolumeInformacoes.delCallSalvaDadosVolumePesoLiquidoUnidade(SalvaDadosVolumePesoLiquidoUnidade);
				// Peso Bruto Unidade
				formFVolumeInformacoes.eCallSalvaDadosVolumePesoBrutoUnidade +=  new frmFVolumeInformacoes.delCallSalvaDadosVolumePesoBrutoUnidade(SalvaDadosVolumePesoBrutoUnidade);
			#endregion
		}
		#endregion
		#region ShowDialogVolumeTipo
		private void ShowDialogVolumeTipo(ref int nIdEmbalagemTipo,ref System.Windows.Forms.ImageList ilEmbalagens)
		{
			frmFVolumeTipo formFVolumeTipo = new frmFVolumeTipo(ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel,ref ilEmbalagens);
			InitializeEventsFormVolumeTipo(ref formFVolumeTipo);
			formFVolumeTipo.Icon = m_formFProdutos.Icon;
			formFVolumeTipo.EspecieSelect = nIdEmbalagemTipo;
			formFVolumeTipo.ShowDialog();
			if (formFVolumeTipo.m_bModificado)
			{
				formFVolumeTipo.RetornaValores(out nIdEmbalagemTipo);
			}
			formFVolumeTipo = null;
		}
			
		private void InitializeEventsFormVolumeTipo(ref frmFVolumeTipo formFVolumeTipo)
		{
			// Carregando os dados da Embalagem
			formFVolumeTipo.eCallCarregaDadosInterfaceVolumeTipo += new frmFVolumeTipo.delCallCarregaDadosInterfaceVolumeTipo(CarregaDadosInterfaceEmbalagemTipoFormVolumes);
		}

		private void CarregaDadosInterfaceEmbalagemTipoFormVolumes(ref mdlComponentesGraficos.ListView lvTiposVolumes, ref System.Windows.Forms.ImageList ilVolumes)
		{
			lvTiposVolumes.Columns[0].Width = lvTiposVolumes.Width - 25;
			mdlDataBaseAccess.Tabelas.XsdTbVolumes.tbVolumesRow dtrwTipoVolume;
			System.Windows.Forms.ListViewItem lviVolume;

			lvTiposVolumes.Items.Clear();
			for (int nCont = 0 ;nCont < m_typDatSetTbVolumes.tbVolumes.Rows.Count;nCont++)
			{
				dtrwTipoVolume = (mdlDataBaseAccess.Tabelas.XsdTbVolumes.tbVolumesRow)m_typDatSetTbVolumes.tbVolumes.Rows[nCont];
				lviVolume = lvTiposVolumes.Items.Add(dtrwTipoVolume.strDescricao);
				lviVolume.Tag = dtrwTipoVolume.nIdVolume;
				lviVolume.ImageIndex = dtrwTipoVolume.nIdImagem;
			}
		}
		#endregion
		#region ShowDialogVolumeProdutos
		#endregion

		#region Carregamento dos Dados
			#region Carrega Dados do BD
				private void CarregaDadosBD()
				{
					CarregaDadosBDUnidadesMassa();
					CarregaDadosBDUnidadesMassaIdioma();

					CarregaDadosBDFaturasComerciais();
					CarregaDadosBDRomaneios();
					CarregaDadosBDProdutos();
					CarregaDadosBDProdutosIdiomas();
					CarregaDadosBDProdutosFaturaComercial();

					CarregaDadosBDVolumes();
					CarregaDadosBDExportadoresVolumes();

					CarregaDadosBDProdutosRomaneioEmbalagens();
					CarregaDadosBDProdutosRomaneioEmbalagensProdutos();
					CarregaDadosBDProdutosRomaneioVolumes();
					CarregaDadosBDProdutosRomaneioVolumesProdutos();
				}

				private void CarregaDadosBDUnidadesMassa()
				{
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
					m_typDatSetTbUnidadesMassa = m_cls_dba_ConnectionDB.GetTbUnidadesMassa(null,null,null,null,null);
				}

				private void CarregaDadosBDUnidadesMassaIdioma()
				{
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
					m_typDatSetTbUnidadesMassaIdioma = m_cls_dba_ConnectionDB.GetTbUnidadesMassaIdioma(null,null,null,null,null);
				}

				private void CarregaDadosBDFaturasComerciais()
				{
					System.Collections.ArrayList arlCondicoesNome = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesValor = new System.Collections.ArrayList();
					arlCondicoesNome.Add("idExportador");
					arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicoesValor.Add(m_nIdExportador);
					arlCondicoesNome.Add("idPe");
					arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicoesValor.Add(m_strIdPe);
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					m_typDatSetTbFaturasComerciais = m_cls_dba_ConnectionDB.GetTbFaturasComerciais(arlCondicoesNome,arlCondicoesComparador,arlCondicoesValor,null,null);

					// Selecionando a Linha
					mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwFaturaComercial = (mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow)m_typDatSetTbFaturasComerciais.tbFaturasComerciais.FindByidExportadoridPE(m_nIdExportador,m_strIdPe);
					if (dtrwFaturaComercial != null)
					{
						// Idioma
						if (!dtrwFaturaComercial.IsidIdiomaNull())
							m_nIdIdioma = dtrwFaturaComercial.idIdioma;

						// Peso Liquido 
						if (!dtrwFaturaComercial.IspesoLiquidoNull())
							m_dFaturaPesoLiquido = dtrwFaturaComercial.pesoLiquido;

						// Peso Bruto
						if (!dtrwFaturaComercial.IspesoBrutoNull())
							m_dFaturaPesoBruto = dtrwFaturaComercial.pesoBruto;

						// Unidade Peso Liquido
						if (!dtrwFaturaComercial.IsnUnidadeMassaPesoLiquidoNull())
							m_nIdUnidadeMassaFaturaPesoLiquido = dtrwFaturaComercial.nUnidadeMassaPesoLiquido;

						// Unidade Peso Bruto 
						if (!dtrwFaturaComercial.IsnUnidadeMassaPesoBrutoNull())
							m_nIdUnidadeMassaFaturaPesoBruto = dtrwFaturaComercial.nUnidadeMassaPesoBruto;
					}
				}

				private void CarregaDadosBDRomaneios()
				{
					System.Collections.ArrayList arlCondicoesNome = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesValor = new System.Collections.ArrayList();
					arlCondicoesNome.Add("idExportador");
					arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicoesValor.Add(m_nIdExportador);
					arlCondicoesNome.Add("idPe");
					arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicoesValor.Add(m_strIdPe);
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					m_typDatSetTbRomaneios = m_cls_dba_ConnectionDB.GetTbRomaneios(arlCondicoesNome,arlCondicoesComparador,arlCondicoesValor,null,null);
					if (m_typDatSetTbRomaneios.tbRomaneios.Rows.Count > 0)
					{
						mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow dtrwRomaneio = (mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow)m_typDatSetTbRomaneios.tbRomaneios.Rows[0];
						// Tipo Ordenacao
						if (!dtrwRomaneio.IsnTipoOrdenacaoNull())
						{
							m_enumOrdenacao = (Ordenacao)dtrwRomaneio.nTipoOrdenacao;
						}else{
							dtrwRomaneio.nTipoOrdenacao = (int)m_enumOrdenacao;
						}
						// Mostrar Embalagens Intermediarias
						m_bMostrarEmbalagensIntermediarias = ((!dtrwRomaneio.IsbEmbalagensIntermediariasNull()) && (dtrwRomaneio.bEmbalagensIntermediarias));

						// Mostrar Quantidade Total
						m_bMostrarQuantidadeTotal = ((!dtrwRomaneio.IsbMostrarTotalVolumesNull()) && (dtrwRomaneio.bMostrarTotalVolumes));

						// Mostrar Volumes Consecutivos
						m_bMostrarVolumesConsecutivos = ((!dtrwRomaneio.IsbMostrarVolumesConsecutivosNull()) && (dtrwRomaneio.bMostrarVolumesConsecutivos));

						// Mostrar Embalagens Consecutivos
						m_bMostrarEmbalagensConsecutivas = ((!dtrwRomaneio.IsbMostrarEmbalagensConsecutivasNull()) && (dtrwRomaneio.bMostrarEmbalagensConsecutivas));
					}
				}

				private void CarregaDadosBDProdutos()
				{
					System.Collections.ArrayList arlCondicoesNome = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesValor = new System.Collections.ArrayList();
					arlCondicoesNome.Add("idExportador");
					arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicoesValor.Add(m_nIdExportador);
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					m_typDatSetTbProdutos = m_cls_dba_ConnectionDB.GetTbProdutos(arlCondicoesNome,arlCondicoesComparador,arlCondicoesValor,null,null);
				}

				private void CarregaDadosBDProdutosIdiomas()
				{
					System.Collections.ArrayList arlCondicoesNome = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesValor = new System.Collections.ArrayList();
					arlCondicoesNome.Add("idExportador");
					arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicoesValor.Add(m_nIdExportador);
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					m_typDatSetTbProdutosIdiomas = m_cls_dba_ConnectionDB.GetTbProdutosIdiomas(arlCondicoesNome,arlCondicoesComparador,arlCondicoesValor,null,null);
				}

				private void CarregaDadosBDProdutosFaturaComercial()
				{
					System.Collections.ArrayList arlCondicoesNome = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesValor = new System.Collections.ArrayList();
					System.Collections.ArrayList arlOrdenacaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();
					arlCondicoesNome.Add("idExportador");
					arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicoesValor.Add(m_nIdExportador);
					arlCondicoesNome.Add("idPe");
					arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicoesValor.Add(m_strIdPe);
					arlOrdenacaoCampo.Add("idOrdem");
					arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente);
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					m_typDatSetTbProdutosFaturaComercial = m_cls_dba_ConnectionDB.GetTbProdutosFaturaComercial(arlCondicoesNome,arlCondicoesComparador,arlCondicoesValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
				}

				private void CarregaDadosBDVolumes()
				{
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
					m_typDatSetTbVolumes = m_cls_dba_ConnectionDB.GetTbVolumes(null,null,null,null,null);
				}
							
				private void CarregaDadosBDExportadoresVolumes()
				{
					System.Collections.ArrayList arlCondicoesNome = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesValor = new System.Collections.ArrayList();
					arlCondicoesNome.Add("idExportador");
					arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicoesValor.Add(m_nIdExportador);
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					m_typDatSetTbExportadoresVolumes = m_cls_dba_ConnectionDB.GetTbExportadoresVolumes(arlCondicoesNome,arlCondicoesComparador,arlCondicoesValor,null,null);
				}
		        
				private void CarregaDadosBDProdutosRomaneioEmbalagens()
				{
					System.Collections.ArrayList arlCondicoesNome = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesValor = new System.Collections.ArrayList();
					arlCondicoesNome.Add("idExportador");
					arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicoesValor.Add(m_nIdExportador);
					arlCondicoesNome.Add("idPe");
					arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicoesValor.Add(m_strIdPe);
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					m_typDatSetTbProdutosRomaneioEmbalagens = m_cls_dba_ConnectionDB.GetTbProdutosRomaneioEmbalagens(arlCondicoesNome,arlCondicoesComparador,arlCondicoesValor,null,null);
				}

				private void CarregaDadosBDProdutosRomaneioEmbalagensProdutos()
				{
					System.Collections.ArrayList arlCondicoesNome = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesValor = new System.Collections.ArrayList();
					arlCondicoesNome.Add("idExportador");
					arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicoesValor.Add(m_nIdExportador);
					arlCondicoesNome.Add("idPe");
					arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicoesValor.Add(m_strIdPe);
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					m_typDatSetTbProdutosRomaneioEmbalagensProdutos = m_cls_dba_ConnectionDB.GetTbProdutosRomaneioEmbalagensProdutos(arlCondicoesNome,arlCondicoesComparador,arlCondicoesValor,null,null);
				}

				private void CarregaDadosBDProdutosRomaneioVolumes()
				{
					System.Collections.ArrayList arlCondicoesNome = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesValor = new System.Collections.ArrayList();
					arlCondicoesNome.Add("idExportador");
					arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicoesValor.Add(m_nIdExportador);
					arlCondicoesNome.Add("idPe");
					arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicoesValor.Add(m_strIdPe);
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					m_typDatSetTbProdutosRomaneioVolumes = m_cls_dba_ConnectionDB.GetTbProdutosRomaneioVolumes(arlCondicoesNome,arlCondicoesComparador,arlCondicoesValor,null,null);
					m_nQtdeVolume = m_typDatSetTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumes.Rows.Count;
				}

				private void CarregaDadosBDProdutosRomaneioVolumesProdutos()
				{
					System.Collections.ArrayList arlCondicoesNome = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesValor = new System.Collections.ArrayList();
					arlCondicoesNome.Add("idExportador");
					arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicoesValor.Add(m_nIdExportador);
					arlCondicoesNome.Add("idPe");
					arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicoesValor.Add(m_strIdPe);
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					m_typDatSetTbProdutosRomaneioVolumesProdutos = m_cls_dba_ConnectionDB.GetTbProdutosRomaneioVolumesProdutos(arlCondicoesNome,arlCondicoesComparador,arlCondicoesValor,null,null);
				}
			#endregion
			#region Carrega Dados na Interface
				#region CarregaDadosInterface
					private void CarregaDadosInterface(ref mdlComponentesGraficos.TreeView tvProdutosFatura,ref mdlComponentesGraficos.ListView lvEmbalagens,ref mdlComponentesGraficos.ListView lvVolumes,out int nOrdenacao)
					{
						CarregaDadosInterfaceProdutosFatura(ref tvProdutosFatura);
						CarregaDadosInterfaceEmbalagens(ref lvEmbalagens);
						CarregaDadosInterfaceVolumes(ref lvVolumes);
						nOrdenacao = (int)m_enumOrdenacao;
					}
				#endregion
				#region CarregaDadosInterfaceProdutosFatura
					private void CarregaDadosInterfaceProdutosFatura(ref mdlComponentesGraficos.TreeView tvProdutosFatura)
					{
						string strLabelProduto = "";
						double dQuantidadeRestante = 0;
						double dQuantidadeTotal = 0;
						System.Windows.Forms.TreeNode tvnNodo = null;
						System.Windows.Forms.TreeNode tvnNodoChild = null;
						mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFatura;

						// Limpando a TreeView 
						tvProdutosFatura.Nodes.Clear();
								
						// Inserindo o Primeiro Nivel de Produtos
						for(int nCont = 0;nCont < m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows.Count;nCont++)
						{
							dtrwProdutoFatura = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow)m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows[nCont];
							if ((!dtrwProdutoFatura.IsidProdutoNull()) && ((dtrwProdutoFatura.IsnIdOrdemProdutoParentNull()) || (dtrwProdutoFatura.nIdOrdemProdutoParent <= 0)))
							{
								RetornaQuantidadeRestante(ref m_typDatSetTbProdutosRomaneioEmbalagensProdutos, ref m_typDatSetTbProdutosRomaneioVolumesProdutos,dtrwProdutoFatura.idOrdem,out dQuantidadeRestante,out dQuantidadeTotal);
								if (!dtrwProdutoFatura.IsstrUnidadeNull())
								{
									strLabelProduto = "(" + dQuantidadeRestante.ToString() + " " + dtrwProdutoFatura.strUnidade + ") ";
									if (!dtrwProdutoFatura.IsmstrDescricaoNull())
										strLabelProduto += dtrwProdutoFatura.mstrDescricao;
									else
										strLabelProduto += strRetornaDescricaoProduto(ref m_typDatSetTbProdutos,ref m_typDatSetTbProdutosIdiomas,m_nIdExportador,m_nIdIdioma,dtrwProdutoFatura.idProduto); 
									tvnNodo = tvProdutosFatura.Nodes.Add(strLabelProduto);
									tvnNodo.Tag = dtrwProdutoFatura.idOrdem; 
									if (dQuantidadeRestante == dQuantidadeTotal)
									{
										tvnNodo.ForeColor = m_clrQuantidadeInteira;
									}
									else
									{
										if (dQuantidadeRestante == 0)
											tvnNodo.ForeColor = m_clrQuantidadeNada;
										else
											tvnNodo.ForeColor = m_clrQuantidadeMetade;
									}
								}
							}
						}

						if (tvnNodo != null)
						{

							// Fica percorrendo os niveis até nao inserir mais nenhum nodo
							bool bInseriuProduto = true;
							int nLevelAnterior = 0;
							int nLevel = 0;
							tvnNodo = null;
							while ((bInseriuProduto) || (nLevel == nLevelAnterior))
							{
								bInseriuProduto = false;
								// Adquirindo o proximo nodo a vasculhar childs 
								if (tvnNodo == null)
								{
									// Primeiro Nodo
									if (tvProdutosFatura.TopNode != null)
										tvnNodo = tvProdutosFatura.TopNode;
								}
								else
								{
									if (NextNodeSameLevel(tvnNodo) != null)
									{
										//Procurando o Proximo Nodo deste Nivel
										nLevelAnterior = nLevel;
										tvnNodo = NextNodeSameLevel(tvnNodo);
									}
									else
									{
										// Voltando ao Primeiro do Level
										while (tvnNodo.PrevNode != null)
										{
											tvnNodo = tvnNodo.PrevNode;
										}
										nLevel++;
										// Procurando o primeiro filho de alguem deste level
										while(tvnNodo.FirstNode == null)
										{
											if (tvnNodo.NextNode != null)
												tvnNodo = tvnNodo.NextNode;
											else
												break;
										} 
										if (tvnNodo.FirstNode != null)
										{
											tvnNodo = tvnNodo.FirstNode;
											nLevelAnterior = nLevel;
										}
										else
										{
											tvnNodo = null;
										}
									}
								}

								// Inserindo os Produtos Childs
								if (tvnNodo != null)
								{
									for(int nCont = 0;nCont < m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows.Count;nCont++)
									{
										dtrwProdutoFatura = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow)m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows[nCont];
										if (!dtrwProdutoFatura.IsnIdOrdemProdutoParentNull() && (dtrwProdutoFatura.nIdOrdemProdutoParent == Int32.Parse(tvnNodo.Tag.ToString())))
										{
											RetornaQuantidadeRestante(ref m_typDatSetTbProdutosRomaneioEmbalagensProdutos, ref m_typDatSetTbProdutosRomaneioVolumesProdutos,dtrwProdutoFatura.idOrdem,out dQuantidadeRestante,out dQuantidadeTotal);
											if (!dtrwProdutoFatura.IsstrUnidadeNull())
											{
												strLabelProduto = "(" + dQuantidadeRestante.ToString() + " " + dtrwProdutoFatura.strUnidade + ") ";
												if (!dtrwProdutoFatura.IsmstrDescricaoNull())
													strLabelProduto += dtrwProdutoFatura.mstrDescricao; 
												else
													strLabelProduto += strRetornaDescricaoProduto(ref m_typDatSetTbProdutos,ref m_typDatSetTbProdutosIdiomas,m_nIdExportador,m_nIdIdioma,dtrwProdutoFatura.idProduto); 
												tvnNodoChild  = tvnNodo.Nodes.Add(strLabelProduto);
												tvnNodoChild.Tag = dtrwProdutoFatura.idOrdem; 
												bInseriuProduto = true;
												nLevelAnterior = nLevel;
												if (dQuantidadeRestante == dQuantidadeTotal)
												{
													tvnNodoChild.ForeColor = m_clrQuantidadeInteira;
												}
												else
												{
													if (dQuantidadeRestante == 0)
														tvnNodoChild.ForeColor = m_clrQuantidadeNada;
													else
														tvnNodoChild.ForeColor = m_clrQuantidadeMetade;
												}
											}
										}
									}
								}
							}
						}
						vRemoveProdutosSemSaldo(ref tvProdutosFatura);
					}

					private void vRemoveProdutosSemSaldo(ref mdlComponentesGraficos.TreeView tvProdutosFatura)
					{
						System.Windows.Forms.TreeNode tvnCurrent;
						for(int i = tvProdutosFatura.Nodes.Count - 1; i >= 0; i--)
						{
							tvnCurrent = tvProdutosFatura.Nodes[i];
							vRemoveProdutoSemSaldo(ref tvnCurrent);
						}
					}

					private void vRemoveProdutoSemSaldo(ref System.Windows.Forms.TreeNode tvnNodo)
					{
						for(int i = tvnNodo.Nodes.Count - 1; i >= 0; i--)
						{							
							System.Windows.Forms.TreeNode tvnCurrent = tvnNodo.Nodes[i];
							vRemoveProdutoSemSaldo(ref tvnCurrent);
						}
						if ((tvnNodo.Nodes.Count == 0) && (tvnNodo.ForeColor.Equals(m_clrQuantidadeNada)))
							tvnNodo.Remove();
					}
				#endregion
				#region	CarregaDadosInterfaceEmbalagens
					private void CarregaDadosInterfaceEmbalagens(ref mdlComponentesGraficos.ListView lvEmbalagens)
					{
						mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagensRow dtrwEmbalagem;
						System.Collections.SortedList sortlstEmbalagens = new System.Collections.SortedList(new mdlComponentesColecoes.clsComparerNumbersTexts());
						System.Windows.Forms.ListViewItem lviEmbalagem;

						lvEmbalagens.Clear();

						// Ordenando as Embalagens 
						for(int nCont = 0 ; nCont < m_typDatSetTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagens.Rows.Count; nCont++)
						{
							dtrwEmbalagem = (mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagensRow)m_typDatSetTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagens.Rows[nCont];
							if (dtrwEmbalagem.RowState != System.Data.DataRowState.Deleted)
								if (!bEmbalagemInseridaEmVolume(dtrwEmbalagem.strIdEmbalagem))
									if (!sortlstEmbalagens.ContainsKey(dtrwEmbalagem.strIdEmbalagem))
										sortlstEmbalagens.Add(dtrwEmbalagem.strIdEmbalagem,dtrwEmbalagem);
						}

						// Inserindo as Embalagens 
						for(int nCont = 0;nCont < sortlstEmbalagens.Count;nCont++)
						{
							dtrwEmbalagem = (mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagensRow)sortlstEmbalagens.GetByIndex(nCont);
							lviEmbalagem = lvEmbalagens.Items.Add(dtrwEmbalagem.strIdEmbalagem);
							if (bEmbalagemVazia(ref m_typDatSetTbProdutosRomaneioEmbalagensProdutos,dtrwEmbalagem.strIdEmbalagem))
							{
								lviEmbalagem.ImageIndex = 0;
							}
							else
							{
								lviEmbalagem.ImageIndex = 1;
							}
						} 
					}
				#endregion
				#region CarregaDadosInterfaceEmbalagensProdutos
				private void CarregaDadosInterfaceEmbalagensProdutos(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos typDatSetTbProdutosRomaneioEmbalagensProdutos,string strIdEmbalagem,ref mdlComponentesGraficos.ListView lvProdutos)
				{
					clsProdutosRomaneio.CarregaDadosInterfaceEmbalagensProdutos(ref m_typDatSetTbUnidadesMassa,ref m_typDatSetTbUnidadesMassaIdioma,ref m_typDatSetTbProdutos,ref m_typDatSetTbProdutosIdiomas,ref m_typDatSetTbProdutosFaturaComercial,ref typDatSetTbProdutosRomaneioEmbalagensProdutos,m_nIdExportador,m_nIdIdioma,strIdEmbalagem,ref lvProdutos);	
				}
				#endregion
				#region CarregaDadosInterfaceVolumes
				private void CarregaDadosInterfaceVolumes(ref mdlComponentesGraficos.ListView lvVolumes)
				{
					System.Collections.SortedList sortLstVolumes = new System.Collections.SortedList(new mdlComponentesColecoes.clsComparerNumbersTexts());  
					mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumesRow dtrwVolume;
					System.Windows.Forms.ListViewItem lviVolume;

					lvVolumes.Clear();

					// Ordenando os Volumes
					for(int nCont = 0 ; nCont < m_typDatSetTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumes.Rows.Count;nCont++)
					{
						dtrwVolume = (mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumesRow)m_typDatSetTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumes.Rows[nCont];
						if (dtrwVolume.RowState != System.Data.DataRowState.Deleted)
						{
							string strNumero = dtrwVolume.strNumeroVolume;
							while (sortLstVolumes.ContainsKey(strNumero))
								strNumero += "X";
							sortLstVolumes.Add(strNumero,dtrwVolume);
						}
					}

					// Inserindo os Volumes
					for(int nCont = 0;nCont < sortLstVolumes.Count;nCont++)
					{
						dtrwVolume = (mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumesRow)sortLstVolumes.GetByIndex(nCont);
						lviVolume = lvVolumes.Items.Add(dtrwVolume.strNumeroVolume);
						if (m_bMostrarQuantidadeTotal)
							lviVolume.Text += "/" + sortLstVolumes.Count.ToString();
						lviVolume.Tag = dtrwVolume.strNumeroVolume;
						if (bVolumeVazio(ref m_typDatSetTbProdutosRomaneioVolumesProdutos,ref m_typDatSetTbProdutosRomaneioEmbalagens,dtrwVolume.strNumeroVolume))
							lviVolume.ImageIndex = 0;
						else
							lviVolume.ImageIndex = 1;
					} 
				}

				private void CarregaDadosInterfaceVolumesEmbalagens(string strNumeroVolume, ref mdlComponentesGraficos.ListView lvEmbalagens)
				{
					System.Collections.ArrayList arlEmbalagens = null;
					arlEmbalagens = arlRetornaEmbalagensVolume(ref m_typDatSetTbProdutosRomaneioEmbalagens, strNumeroVolume);
					lvEmbalagens.Items.Clear();	
					if (arlEmbalagens.Count > 0)
					{
						CarregaDadosInterfaceEmbalagens(ref m_typDatSetTbProdutosRomaneioEmbalagens,ref m_typDatSetTbProdutosRomaneioEmbalagensProdutos, ref lvEmbalagens,ref arlEmbalagens,true);
					}
				}
				#endregion
				#region CarregaDadosInterfaceVolumesProdutos
					private void CarregaDadosInterfaceVolumesProdutos(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos typDatSetTbProdutosRomaneioVolumesProdutos,string strNumeroVolume,ref mdlComponentesGraficos.ListView lvProdutos)
					{
						clsProdutosRomaneio.CarregaDadosInterfaceVolumesProdutos(ref m_typDatSetTbUnidadesMassa,ref m_typDatSetTbUnidadesMassaIdioma,ref m_typDatSetTbProdutos,ref m_typDatSetTbProdutosIdiomas,ref m_typDatSetTbProdutosFaturaComercial,ref typDatSetTbProdutosRomaneioVolumesProdutos,m_nIdExportador,m_nIdIdioma,strNumeroVolume,ref lvProdutos);	
					}
				#endregion
			#endregion
		#endregion
		#region Salvamento dos Dados
			#region Salva dados da Interface
				private void vSalvaOrdenacao(int nOrdenacao)
				{
					m_enumOrdenacao = (Ordenacao)nOrdenacao;
					if (m_typDatSetTbRomaneios.tbRomaneios.Rows.Count > 0)
					{
						mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow dtrwRomaneio = (mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow)m_typDatSetTbRomaneios.tbRomaneios.Rows[0];
						dtrwRomaneio.nTipoOrdenacao = nOrdenacao;
					}
				}

				private void SalvaDadosVolumeTipo(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetTbProdutosRomaneioVolumes,string strNumeroVolume,int nTipoVolume)
				{
					clsProdutosRomaneio.SalvaDadosVolumeTipo(ref typDatSetTbProdutosRomaneioVolumes,m_nIdExportador,m_strIdPe,strNumeroVolume,nTipoVolume);
				}

				private void SalvaDadosVolumeDescricaoPopular(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetTbProdutosRomaneioVolumes,string strNumeroVolume,string strDescricaoPopular)
				{
					clsProdutosRomaneio.SalvaDadosVolumeDescricaoPopular(ref typDatSetTbProdutosRomaneioVolumes,m_nIdExportador,m_strIdPe,strNumeroVolume,strDescricaoPopular);
				}

				private void SalvaDadosVolumeAltura(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetTbProdutosRomaneioVolumes,string strNumeroVolume,double dAltura)
				{
					clsProdutosRomaneio.SalvaDadosVolumeAltura(ref typDatSetTbProdutosRomaneioVolumes,m_nIdExportador,m_strIdPe,strNumeroVolume,dAltura);
				}

				private void SalvaDadosVolumeLargura(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetTbProdutosRomaneioVolumes,string strNumeroVolume,double dLargura)
				{
					clsProdutosRomaneio.SalvaDadosVolumeLargura(ref typDatSetTbProdutosRomaneioVolumes,m_nIdExportador,m_strIdPe,strNumeroVolume,dLargura);
				}

				private void SalvaDadosVolumeComprimento(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetTbProdutosRomaneioVolumes,string strNumeroVolume,double dComprimento)
				{
					clsProdutosRomaneio.SalvaDadosVolumeComprimento(ref typDatSetTbProdutosRomaneioVolumes,m_nIdExportador,m_strIdPe,strNumeroVolume,dComprimento);
				}

				private void SalvaDadosVolumeVolume(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetTbProdutosRomaneioVolumes,string strNumeroVolume,double dVolume)
				{
					clsProdutosRomaneio.SalvaDadosVolumeVolume(ref typDatSetTbProdutosRomaneioVolumes,m_nIdExportador,m_strIdPe,strNumeroVolume,dVolume);
				}

				private void SalvaDadosVolumePesoLiquido(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetTbProdutosRomaneioVolumes,string strNumeroVolume,double dPesoLiquido)
				{
					clsProdutosRomaneio.SalvaDadosVolumePesoLiquido(ref typDatSetTbProdutosRomaneioVolumes,m_nIdExportador,m_strIdPe,strNumeroVolume,dPesoLiquido);
				}

				private void SalvaDadosVolumePesoBruto(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetTbProdutosRomaneioVolumes,string strNumeroVolume,double dPesoBruto)
				{
					clsProdutosRomaneio.SalvaDadosVolumePesoBruto(ref typDatSetTbProdutosRomaneioVolumes,m_nIdExportador,m_strIdPe,strNumeroVolume,dPesoBruto);
				}

				private void SalvaDadosVolumeAlturaUnidade(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetTbProdutosRomaneioVolumes,string strNumeroVolume,int nUnidadeAltura)
				{
					clsProdutosRomaneio.SalvaDadosVolumeAlturaUnidade(ref typDatSetTbProdutosRomaneioVolumes,m_nIdExportador,m_strIdPe,strNumeroVolume,nUnidadeAltura);
				}

				private void SalvaDadosVolumeLarguraUnidade(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetTbProdutosRomaneioVolumes,string strNumeroVolume,int nUnidadeLargura)
				{
					clsProdutosRomaneio.SalvaDadosVolumeLarguraUnidade(ref typDatSetTbProdutosRomaneioVolumes,m_nIdExportador,m_strIdPe,strNumeroVolume,nUnidadeLargura);
				}

				private void SalvaDadosVolumeComprimentoUnidade(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetTbProdutosRomaneioVolumes,string strNumeroVolume,int nUnidadeComprimento)
				{
					clsProdutosRomaneio.SalvaDadosVolumeComprimentoUnidade(ref typDatSetTbProdutosRomaneioVolumes,m_nIdExportador,m_strIdPe,strNumeroVolume,nUnidadeComprimento);
				}

				private void SalvaDadosVolumeVolumeUnidade(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetTbProdutosRomaneioVolumes,string strNumeroVolume,int nUnidadeVolume)
				{
					clsProdutosRomaneio.SalvaDadosVolumeVolumeUnidade(ref typDatSetTbProdutosRomaneioVolumes,m_nIdExportador,m_strIdPe,strNumeroVolume,nUnidadeVolume);
				}

				private void SalvaDadosVolumePesoLiquidoUnidade(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetTbProdutosRomaneioVolumes,string strNumeroVolume,int nUnidadePesoLiquido)
				{
					clsProdutosRomaneio.SalvaDadosVolumePesoLiquidoUnidade(ref typDatSetTbProdutosRomaneioVolumes,m_nIdExportador,m_strIdPe,strNumeroVolume,nUnidadePesoLiquido);
				}

				private void SalvaDadosVolumePesoBrutoUnidade(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetTbProdutosRomaneioVolumes,string strNumeroVolume,int nUnidadePesoBruto)
				{
					clsProdutosRomaneio.SalvaDadosVolumePesoBrutoUnidade(ref typDatSetTbProdutosRomaneioVolumes,m_nIdExportador,m_strIdPe,strNumeroVolume,nUnidadePesoBruto);
				}
			#endregion
			#region Salva dados no BD
				private void SalvaDadosBD()
				{
					SalvaDadosBDRomaneios();
					SalvaDadosBDExportadoresVolumes();
					SalvaDadosBDProdutosRomaneioEmbalagens();
					SalvaDadosBDProdutosRomaneioEmbalagensProdutos();
					SalvaDadosBDProdutosRomaneioVolumes();
					SalvaDadosBDProdutosRomaneioVolumesProdutos();
				}

				private void SalvaDadosBDRomaneios()
				{
					m_cls_dba_ConnectionDB.SetTbRomaneios(m_typDatSetTbRomaneios);
				}
				private void SalvaDadosBDExportadoresVolumes()
				{
					m_cls_dba_ConnectionDB.SetTbExportadoresVolumes(m_typDatSetTbExportadoresVolumes);
				}
				private void SalvaDadosBDProdutosRomaneioEmbalagens()
				{
					m_cls_dba_ConnectionDB.SetTbProdutosRomaneioEmbalagens(m_typDatSetTbProdutosRomaneioEmbalagens);
				}
				private void SalvaDadosBDProdutosRomaneioEmbalagensProdutos()
				{
					m_cls_dba_ConnectionDB.SetTbProdutosRomaneioEmbalagensProdutos(m_typDatSetTbProdutosRomaneioEmbalagensProdutos);
				}
				private void SalvaDadosBDProdutosRomaneioVolumes()
				{
					m_cls_dba_ConnectionDB.SetTbProdutosRomaneioVolumes(m_typDatSetTbProdutosRomaneioVolumes);
				}
				private void SalvaDadosBDProdutosRomaneioVolumesProdutos()
				{
					m_cls_dba_ConnectionDB.SetTbProdutosRomaneioVolumesProdutos(m_typDatSetTbProdutosRomaneioVolumesProdutos);
				}
			#endregion
		#endregion

		#region UnidadeEspaco
			private string strRetornaSiglaUnidadeEspaco(int nIdUnidadeEspaco)
			{
				string strRetorno = strRetornaSiglaUnidadeEspacoIdioma(nIdUnidadeEspaco);
				if (strRetorno.Trim() == "")
				{
//					mdlDataBaseAccess.Tabelas.XsdTbUnidadesEspaco.tbUnidadesEspacoRow dtrwUnidadesEspaco = (mdlDataBaseAccess.Tabelas.XsdTbUnidadesEspaco.tbUnidadesEspacoRow)m_typDatSetTbUnidadesEsMassa.tbUnidadesMassa.FindBynIdUnidadeMassa(nIdUnidadeMassa);                    
//					if (dtrwUnidadesMassa != null)
//					{
//						strRetorno = dtrwUnidadesMassa.strSigla;	
//					}
					// TODO: Arrumar, tem q puxar do banco de dados e nao do codigo 
					switch(nIdUnidadeEspaco)
					{
						case 1:
							strRetorno = "mm";
							break;
						case 2:
							strRetorno = "cm";
							break;
						case 3:
							strRetorno = "dm";
							break;
						case 4:
							strRetorno = "m";
							break;
						case 5:
							strRetorno = "km";
							break;
					}
				}
				return(strRetorno);
			}

			private string strRetornaSiglaUnidadeEspacoIdioma(int nIdUnidadeMassa)
			{
				string strRetorno = "";
				return(strRetorno);
			}
		#endregion
		#region UnidadeMassa
			private string strRetornaSiglaUnidadeMassa(int nUnidadeMassa)
			{
				return(strRetornaSiglaUnidadeMassa(ref m_typDatSetTbUnidadesMassa,ref m_typDatSetTbUnidadesMassaIdioma,nUnidadeMassa,m_nIdIdioma));
			}
		#endregion

		#region Romaneio
			private void bSetMostrarQuantidadeTotal(bool bMostrarQuantidadeTotal)
			{
				m_bMostrarQuantidadeTotal = bMostrarQuantidadeTotal;
				if (m_typDatSetTbRomaneios.tbRomaneios.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow dtrwRomaneio = (mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow)m_typDatSetTbRomaneios.tbRomaneios.Rows[0];
					dtrwRomaneio.bMostrarTotalVolumes = m_bMostrarQuantidadeTotal;
				}
			}

			private void bSetConfiguracoesRomaneio(bool bMostrarVolumesConsecutivos,bool bMostrarEmbalagensConsecutivas)
			{
				m_bMostrarVolumesConsecutivos = bMostrarVolumesConsecutivos;
				m_bMostrarEmbalagensConsecutivas = bMostrarEmbalagensConsecutivas;
				if (m_typDatSetTbRomaneios.tbRomaneios.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow dtrwRomaneio = (mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow)m_typDatSetTbRomaneios.tbRomaneios.Rows[0];
					// Mostrar Volumes Consecutivos
					dtrwRomaneio.bMostrarVolumesConsecutivos = bMostrarVolumesConsecutivos;

					// Mostrar Embalagens Consecutivos
					dtrwRomaneio.bMostrarEmbalagensConsecutivas = bMostrarEmbalagensConsecutivas;
				}
			}

			private void bMostrarQuantidadeTotal(out bool bMostrarQuantidadeTotal)
			{
				bMostrarQuantidadeTotal = m_bMostrarQuantidadeTotal;
			}
		#endregion
		#region ProdutosFatura
			private void RetornaQuantidadeRestante(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos typDatSetTbProdutosRomaneioEmbalagensProdutos,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos typDatSetTbProdutosRomaneioVolumesProdutos, int idOrdemProduto,out double dQuantidadeRestante,out double dQuantidadeTotal)
			{
				dQuantidadeRestante = 0;
				dQuantidadeTotal = 0;

				// Calcular Quantidade Total do Produto
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutosFatura = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow)m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.FindByidExportadoridPEidOrdem(m_nIdExportador,m_strIdPe,idOrdemProduto);
				if (dtrwProdutosFatura != null)
				{
					if (!dtrwProdutosFatura.IsdQuantidadeNull())
						dQuantidadeTotal = dtrwProdutosFatura.dQuantidade; 
				}

				// Calculando Quantidade Produtos em Embalagens
				mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutosRow dtrwProdutosEmbalagens;
				for (int nCont = 0; nCont < m_typDatSetTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutos.Rows.Count;nCont++)
				{
					dtrwProdutosEmbalagens = (mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutosRow)m_typDatSetTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutos.Rows[nCont];
					if (dtrwProdutosEmbalagens.RowState != System.Data.DataRowState.Deleted)
					{
						if (dtrwProdutosEmbalagens.nIdOrdemProduto == idOrdemProduto)
						{
							if (!dtrwProdutosEmbalagens.IsdQuantidadeNull())
								dQuantidadeRestante = System.Math.Round(dQuantidadeRestante + dtrwProdutosEmbalagens.dQuantidade,8);  
						}
					}
				}

				// Calculando Quantidade Produtos em Volumes
				mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutosRow dtrwProdutosVolumes;
				for (int nCont = 0; nCont < m_typDatSetTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutos.Rows.Count;nCont++)
				{
					dtrwProdutosVolumes = (mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutosRow)m_typDatSetTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutos.Rows[nCont];
					if (dtrwProdutosVolumes.RowState != System.Data.DataRowState.Deleted)
					{
						if (dtrwProdutosVolumes.nIdOrdemProduto == idOrdemProduto)
						{
							if (!dtrwProdutosVolumes.IsdQuantidadeNull())
								dQuantidadeRestante = System.Math.Round(dQuantidadeRestante + dtrwProdutosVolumes.dQuantidade,8);  
						}
					}
				}

				// Calculando 
				dQuantidadeRestante = System.Math.Round(dQuantidadeTotal - dQuantidadeRestante,8);
			}
		#endregion
		#region Produto Embalagem
			private bool bExcluiProdutosEmbalagem(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos typDatSetTbProdutosRomaneioEmbalagensProdutos,string strIdEmbalagem,ref System.Collections.ArrayList arlProdutos)
			{
				bool bRetorno = true;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutosRow dtrwProduto;
				for (int nCont = 0; nCont < typDatSetTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutos.Rows.Count;nCont++)
				{
					dtrwProduto = (mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutosRow)typDatSetTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutos.Rows[nCont];
					if (dtrwProduto.RowState != System.Data.DataRowState.Deleted)
					{
						if (dtrwProduto.strIdEmbalagem == strIdEmbalagem)
						{
							if (arlProdutos.Contains(dtrwProduto.nIdOrdemProduto))
							{
								dtrwProduto.Delete();
								bReCalculaPesoLiquidoVolumeEmbalagem(strIdEmbalagem);
							}
						}
					}
				}
				return(bRetorno);
			}
		#endregion
		#region Produto Volume 
			private bool bExcluiProdutosVolume(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos typDatSetTbProdutosRomaneioVolumesProdutos,string strNumeroVolume,ref System.Collections.ArrayList arlProdutos)
			{
				bool bRetorno = true;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutosRow dtrwProduto;
				for (int nCont = 0; nCont < typDatSetTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutos.Rows.Count;nCont++)
				{
					dtrwProduto = (mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutosRow)typDatSetTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutos.Rows[nCont];
					if (dtrwProduto.RowState != System.Data.DataRowState.Deleted)
					{
						if (dtrwProduto.strNumeroVolume == strNumeroVolume)
						{
							if (arlProdutos.Contains(dtrwProduto.nIdOrdemProduto))
							{
								dtrwProduto.Delete();
								bRecalculaPesoLiquidoVolume(strNumeroVolume);
							}
						}
					}
				}
				return(bRetorno);
			}
		#endregion
		#region Embalagens

			private bool bEmbalagemExiste(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens typDatSetTbProdutosRomaneioEmbalagens, string strIdEmbalagem)
			{
				return(clsProdutosRomaneio.bEmbalagemExiste(ref typDatSetTbProdutosRomaneioEmbalagens,m_nIdExportador,m_strIdPe,strIdEmbalagem));
			}

			private bool bEmbalagemInseridaEmVolume(string strIdEmbalagem)
			{
                bool bRetorno = false;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagensRow dtrwEmbalagem;
				dtrwEmbalagem = m_typDatSetTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagens.FindByidExportadoridPEstrIdEmbalagem(m_nIdExportador,m_strIdPe,strIdEmbalagem);
				if ((dtrwEmbalagem != null) && (dtrwEmbalagem.RowState != System.Data.DataRowState.Deleted))
				{
					string strNumeroVolume = "";
					if (!dtrwEmbalagem.IsstrNumeroVolumeNull())
					{
						strNumeroVolume = dtrwEmbalagem.strNumeroVolume;
	                    mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumesRow dtrwVolume;
						dtrwVolume = m_typDatSetTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumes.FindByidExportadoridPEstrNumeroVolume(m_nIdExportador,m_strIdPe,strNumeroVolume);
						if ((dtrwVolume != null) && (dtrwVolume.RowState != System.Data.DataRowState.Deleted))
						{
							bRetorno = true;
						}else{
							dtrwEmbalagem.strNumeroVolume = "";
						}
					}
				}
				return(bRetorno);
			}

			private System.Collections.ArrayList arlRetornaEmbalagensNovas(int nQuantidadeEmbalagens)
			{
				System.Collections.ArrayList arlRetorno = new System.Collections.ArrayList();
				for (int nCont = 0; nCont < nQuantidadeEmbalagens; nCont++)
					arlRetorno.Add(strRetornaEmbalagenNova(ref arlRetorno));
				return(arlRetorno);
			}

			private string strRetornaEmbalagenNova(ref System.Collections.ArrayList arlColecaoEmbalagens)
			{
				int nProximaEmbalagem = 1;
				bool bExiste = true;
				while (bExiste)
				{
					bExiste = m_typDatSetTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagens.FindByidExportadoridPEstrIdEmbalagem(m_nIdExportador,m_strIdPe,nProximaEmbalagem.ToString()) != null;
					if ((!bExiste) && (arlColecaoEmbalagens != null))
						bExiste = arlColecaoEmbalagens.Contains(nProximaEmbalagem.ToString());
					if (bExiste)
						nProximaEmbalagem++;
				}
				return(nProximaEmbalagem.ToString());
			}

			private bool bEmbalagensInexistentes(ref System.Collections.ArrayList arlEmbalagens)
			{
				bool bRetorno = true;
				for(int nCont = 0; nCont < arlEmbalagens.Count; nCont++)
				{
					if (m_typDatSetTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagens.FindByidExportadoridPEstrIdEmbalagem(m_nIdExportador,m_strIdPe,arlEmbalagens[nCont].ToString()) != null)
					{
						bRetorno = false;
						break;
					}
				} 
				return(bRetorno);
			}

			private bool bEmbalagensExclui(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens typDatSetTbProdutosRomaneioEmbalagens,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos typDatSetTbProdutosRomaneioEmbalagensProdutos,ref System.Collections.ArrayList arlEmbalagensExcluir)
			{
				bool bRetorno = false;
				if (mdlMensagens.clsMensagens.ShowQuestion("Siscobras.NET",mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlProdutosRomaneio_clsProdutosRomaneio_ExcluirEmbalagem),System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)/*System.Windows.Forms.MessageBox.Show("Deseja mesmo exlcuir esta(s) embalagen(s)?","Siscobras.NET",System.Windows.Forms.MessageBoxButtons.YesNo,System.Windows.Forms.MessageBoxIcon.Question,System.Windows.Forms.MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)*/
				{
					bRetorno = true;
					mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagensRow dtrwEmbalagens;
					mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutosRow dtrwEmbalagensProdutos;
					for(int nCont = 0 ;nCont < arlEmbalagensExcluir.Count ;nCont++)
					{
						dtrwEmbalagens = typDatSetTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagens.FindByidExportadoridPEstrIdEmbalagem(m_nIdExportador,m_strIdPe,arlEmbalagensExcluir[nCont].ToString());
						if (dtrwEmbalagens != null)
						{
							for(int nContProd = 0;nContProd < typDatSetTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutos.Rows.Count;nContProd++)
							{
								dtrwEmbalagensProdutos = (mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutosRow)typDatSetTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutos.Rows[nContProd];
								if (dtrwEmbalagensProdutos.RowState != System.Data.DataRowState.Deleted)
								{
									if (dtrwEmbalagensProdutos.strIdEmbalagem == dtrwEmbalagens.strIdEmbalagem)
									{
										dtrwEmbalagensProdutos.Delete();
										bReCalculaPesoLiquidoVolumeEmbalagem(dtrwEmbalagens.strIdEmbalagem);
									}
								}
							}
							dtrwEmbalagens.Delete();
						}
					}
				}
				return (bRetorno);
			}

			private void RetornaInformacoesEmbalagem(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens typDatSetTbProdutosRomaneioEmbalagens,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos typDatSetTbProdutosRomaneioEmbalagensProdutos,string strIdEmbalagem,out double dPesoLiquido,out string strSiglaUnidadePesoLiquido,out string strNumeroVolume)
			{
			  	int nUnidadePesoLiquido = 3;
				dPesoLiquido = dRetornaPesoLiquidoEmbalagem(ref typDatSetTbProdutosRomaneioEmbalagensProdutos,strIdEmbalagem,nUnidadePesoLiquido);
				strSiglaUnidadePesoLiquido = strRetornaSiglaUnidadeMassa(nUnidadePesoLiquido);
				strNumeroVolume = strRetornaNumeroVolumeEmbalagem(ref typDatSetTbProdutosRomaneioEmbalagens,strIdEmbalagem);
			}

			private void RetornaProdutoFaturaEmbalagem(string strIdEmbalagem,int nIdOrdemProduto,out double dQuantidade,out double dPesoLiquido,out int nUnidadeMassaPesoLiquido)
			{
				dQuantidade = 0;
				dPesoLiquido = 0;
				nUnidadeMassaPesoLiquido = 0;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutosRow dtrwProdutosEmbalagem;
			    dtrwProdutosEmbalagem = m_typDatSetTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutos.FindByidExportadoridPEstrIdEmbalagemnIdOrdemProduto(m_nIdExportador,m_strIdPe,strIdEmbalagem,nIdOrdemProduto);
				if (dtrwProdutosEmbalagem != null)
				{   
					// Quantidade 
					if (!dtrwProdutosEmbalagem.IsdQuantidadeNull())
						dQuantidade = dtrwProdutosEmbalagem.dQuantidade;
					// Peso Liquido
					if (!dtrwProdutosEmbalagem.IsdPesoLiquidoNull())
						dPesoLiquido = dtrwProdutosEmbalagem.dPesoLiquido;
					// Unidade Massa Peso Liquido
					if (!dtrwProdutosEmbalagem.IsnUnidadeMassaPesoLiquidoNull())
						nUnidadeMassaPesoLiquido = dtrwProdutosEmbalagem.nUnidadeMassaPesoLiquido;
				}
			}

			private bool bReCalculaPesoLiquidoVolumeEmbalagem(string strIdEmbalagem)
			{
				bool bRetorno = false;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagensRow dtrwEmbalagem = m_typDatSetTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagens.FindByidExportadoridPEstrIdEmbalagem(m_nIdExportador,m_strIdPe,strIdEmbalagem);
				if ((dtrwEmbalagem != null) && (dtrwEmbalagem.RowState != System.Data.DataRowState.Deleted) && (!dtrwEmbalagem.IsstrNumeroVolumeNull())) 
					return(bRecalculaPesoLiquidoVolume(dtrwEmbalagem.strNumeroVolume));
				return(bRetorno);
			}
		#endregion
		#region Volumes
			private bool bVolumeExiste(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetTbProdutosRomaneioVolumes,string strNumeroVolume)
			{
				return(!clsProdutosRomaneio.bVolumeExiste(ref typDatSetTbProdutosRomaneioVolumes,m_nIdExportador,m_strIdPe,strNumeroVolume));
			}

			private string strRetornaDescricaoVolume(int nIdVolume)
			{
				string strRetorno = "";
				mdlDataBaseAccess.Tabelas.XsdTbVolumes.tbVolumesRow dtrwVolume;
				for (int nCont = 0;nCont < m_typDatSetTbVolumes.tbVolumes.Rows.Count;nCont++)
				{
					dtrwVolume = (mdlDataBaseAccess.Tabelas.XsdTbVolumes.tbVolumesRow)m_typDatSetTbVolumes.tbVolumes.Rows[nCont];
					if (dtrwVolume.nIdVolume == nIdVolume)
					{
						if (!dtrwVolume.IsstrDescricaoNull())
							strRetorno = dtrwVolume.strDescricao;
						break;
					}
				}
				return (strRetorno);
			}

			private string strRetornaDescricaoPopularVolume(int nIdVolume)
			{
				string strRetorno = "";
				mdlDataBaseAccess.Tabelas.XsdTbExportadoresVolumes.tbExportadoresVolumesRow dtrwExportadorVolume;
				dtrwExportadorVolume = m_typDatSetTbExportadoresVolumes.tbExportadoresVolumes.FindByidExportadornIdVolume(m_nIdExportador,nIdVolume);
				if (dtrwExportadorVolume != null)
				{
					if (!dtrwExportadorVolume.IsstrDescricaoPopularNull())
						strRetorno = dtrwExportadorVolume.strDescricaoPopular; 
				}
				return (strRetorno);
			}

			private bool bVolumesInexistentes(ref System.Collections.ArrayList arlVolumes)
			{
				bool bRetorno = true;
				foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumesRow dtrwVolume in m_typDatSetTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumes.Rows)
				{
					if (dtrwVolume.RowState != System.Data.DataRowState.Deleted)
					{
						if (arlVolumes.Contains(dtrwVolume.strNumeroVolume))
						{
							bRetorno = false;
							break;
						}
					}
				}
				return(bRetorno);
			}

			private bool bVolumesExclui(System.Collections.ArrayList arlVolumesExcluir)
			{
				bool bRetorno = false;
				if (mdlMensagens.clsMensagens.ShowQuestion("Siscobras.NET",mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlProdutosRomaneio_clsProdutosRomaneio_ExcluirVolume),System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)/*if (System.Windows.Forms.MessageBox.Show("Deseja mesmo exlcuir este(s) volume(s)?","Siscobras.NET",System.Windows.Forms.MessageBoxButtons.YesNo,System.Windows.Forms.MessageBoxIcon.Question,System.Windows.Forms.MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)*/
				{
					bRetorno = true;
					mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumesRow dtrwVolumes;
					mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutosRow dtrwVolumesProdutos = null;
					mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagensRow dtrwVolumesEmbalagens = null;
					System.Collections.ArrayList arlEmbalagens;
					// Volumes
					for(int nCont = 0 ;nCont < arlVolumesExcluir.Count ;nCont++)
					{
						dtrwVolumes = m_typDatSetTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumes.FindByidExportadoridPEstrNumeroVolume(m_nIdExportador,m_strIdPe,arlVolumesExcluir[nCont].ToString());
						if (dtrwVolumes != null)
						{
							// Volumes Produtos
							for (int nContProd = (m_typDatSetTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutos.Rows.Count - 1); nContProd >= 0 ;nContProd--)
							{
								dtrwVolumesProdutos = (mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutosRow)m_typDatSetTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutos.Rows[nContProd];
								if (dtrwVolumesProdutos.RowState != System.Data.DataRowState.Deleted)
								{
									if ((dtrwVolumesProdutos.idExportador == m_nIdExportador) && (dtrwVolumesProdutos.idPE == m_strIdPe) && (dtrwVolumesProdutos.strNumeroVolume == dtrwVolumes.strNumeroVolume))
									{
										dtrwVolumesProdutos.Delete();
									}                                     
								}
							}

							// Embalagens 
							arlEmbalagens = new System.Collections.ArrayList();
							for (int nContEmb = (m_typDatSetTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagens.Rows.Count - 1) ;nContEmb >= 0;nContEmb--)
							{
								dtrwVolumesEmbalagens = (mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagensRow)m_typDatSetTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagens.Rows[nContEmb];
								if (dtrwVolumesEmbalagens.RowState != System.Data.DataRowState.Deleted)
								{
									if ((dtrwVolumesEmbalagens.idExportador == m_nIdExportador) && (dtrwVolumesEmbalagens.idPE == m_strIdPe) && (dtrwVolumesEmbalagens.strNumeroVolume == dtrwVolumes.strNumeroVolume))
									{
										dtrwVolumesEmbalagens.strNumeroVolume = "";
									}                                     
								}
							}
							dtrwVolumes.Delete();
						}
					}
				}
				return (bRetorno);
			}

			private string strRetornaNumeroVolumeEmbalagem(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens typDatSetTbProdutosRomaneioEmbalagens,string strIdEmbalagem)
			{
				string strRetorno = "";
				mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagensRow dtrwEmbalagem;
				for (int nCont = 0;nCont < typDatSetTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagens.Rows.Count;nCont++)
				{
					dtrwEmbalagem = (mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagensRow)typDatSetTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagens.Rows[nCont];
					if ((dtrwEmbalagem.RowState != System.Data.DataRowState.Deleted) && (dtrwEmbalagem.strIdEmbalagem == strIdEmbalagem))
					{
						if (!dtrwEmbalagem.IsstrNumeroVolumeNull())
							strRetorno = dtrwEmbalagem.strNumeroVolume;
						break;
					}
				}
				return(strRetorno);
			}

			private bool bInsereEmbalagensNoVolume(string strNumeroVolume,ref System.Collections.ArrayList arlEmbalagens)
			{
				bool bRetorno = true;
				string strIdEmbalagem = "";
				mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagensRow dtrwEmbalagem;
				for(int nCont = 0 ; nCont < arlEmbalagens.Count;nCont++)
				{
					strIdEmbalagem = arlEmbalagens[nCont].ToString();
					dtrwEmbalagem = m_typDatSetTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagens.FindByidExportadoridPEstrIdEmbalagem(m_nIdExportador,m_strIdPe,strIdEmbalagem);
					if ((dtrwEmbalagem != null) && (dtrwEmbalagem.RowState != System.Data.DataRowState.Deleted))
					{
						dtrwEmbalagem.strNumeroVolume = strNumeroVolume;
					}
				}
                return(bRetorno);
			}

			private void RetornaInformacoesVolume(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetTbProdutosRomaneioVolumes,string strNumeroVolume,out int nTipoVolume,out string strTipoPopular,out double dAltura,out int nUnidadeMetricaAltura,out double dLargura,out int nUnidadeMetricaLargura,out double dComprimento,out int nUnidadeMetricaComprimento,out double dVolume,out int nUnidadeMetricaVolume,out double dPesoLiquido,out int nUnidadeMassaPesoLiquido,out double dPesoBruto, out int nUnidadeMassaPesoBruto)
			{
				nTipoVolume = 0;
				strTipoPopular = "";
				dAltura = 0;
				nUnidadeMetricaAltura = 0;
				dLargura = 0;
				nUnidadeMetricaLargura = 0;
				dComprimento = 0;
				nUnidadeMetricaComprimento = 0;
				dVolume = 0;
				nUnidadeMetricaVolume = 0;
				dPesoLiquido = 0;
				nUnidadeMassaPesoLiquido = 0;
				dPesoBruto = 0;
				nUnidadeMassaPesoBruto = 0;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumesRow dtrwVolume;
				for (int nCont = 0; nCont < typDatSetTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumes.Rows.Count;nCont++)
				{
					dtrwVolume = (mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumesRow)typDatSetTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumes.Rows[nCont];
					if (dtrwVolume.RowState != System.Data.DataRowState.Deleted)
					{
						if (dtrwVolume.strNumeroVolume == strNumeroVolume)
						{
							// nTipoVolume
							if (!dtrwVolume.IsnlTipoVolumeNull())
							{
								nTipoVolume = dtrwVolume.nlTipoVolume;
							}
							// strTipoPopular
							if (!dtrwVolume.IsstrTipoPopularNull())
							{
								strTipoPopular = dtrwVolume.strTipoPopular;
							}
							// dAltura 
							if (!dtrwVolume.IsdAlturaNull())
							{
								dAltura = dtrwVolume.dAltura;
							}
							// nUnidadeMetricaAltura 
							if (!dtrwVolume.IsnUnidadeAlturaNull())
							{
								nUnidadeMetricaAltura = dtrwVolume.nUnidadeAltura;
							}
							// dLargura
							if (!dtrwVolume.IsdLarguraNull())
							{
								dLargura = dtrwVolume.dLargura;
							}
							// nUnidadeMetricaLargura
							if (!dtrwVolume.IsnUnidadeLarguraNull())
							{
								nUnidadeMetricaLargura = dtrwVolume.nUnidadeLargura;
							}
							// dComprimento
							if (!dtrwVolume.IsdComprimentoNull())
							{
								dComprimento = dtrwVolume.dComprimento;
							}
							// nUnidadeMetricaComprimento 
							if (!dtrwVolume.IsnUnidadeComprimentoNull())
							{
								nUnidadeMetricaComprimento = dtrwVolume.nUnidadeComprimento;
							}
							// dVolume
							if (!dtrwVolume.IsdVolumeNull())
							{
								dVolume = dtrwVolume.dVolume;
							}
							// nUnidadeMetricaVolume
							if (!dtrwVolume.IsnUnidadeVolumeNull())
							{
								nUnidadeMetricaVolume = dtrwVolume.nUnidadeVolume;
							}
							// dPesoLiquido
							if (!dtrwVolume.IsdPesoLiquidoNull())
							{
								dPesoLiquido = dtrwVolume.dPesoLiquido;
							}
							// nUnidadeMassaPesoLiquido
							if (!dtrwVolume.IsnUnidadeMassaPesoLiquidoNull())
							{
								nUnidadeMassaPesoLiquido = dtrwVolume.nUnidadeMassaPesoLiquido;
							}
							// dPesoBruto
							if (!dtrwVolume.IsdPesoBrutoNull())
							{
								dPesoBruto = dtrwVolume.dPesoBruto;
							}
							// nUnidadeMassaPesoBruto
							if (!dtrwVolume.IsnUnidadeMassaPesoBrutoNull())
							{
								nUnidadeMassaPesoBruto = dtrwVolume.nUnidadeMassaPesoBruto;
							}
						}
					}
				}
			}

			private bool bRecalculaPesoLiquidoVolumes()
			{
				return(bRecalculaPesoLiquidoVolumes(ref m_typDatSetTbProdutosRomaneioVolumes,ref m_typDatSetTbProdutosRomaneioVolumesProdutos,ref m_typDatSetTbProdutosRomaneioEmbalagens,ref m_typDatSetTbProdutosRomaneioEmbalagensProdutos));
			}

			private bool bRecalculaPesoLiquidoVolume(string strNumeroVolume)
			{
				return(bRecalculaPesoLiquidoVolume(ref m_typDatSetTbProdutosRomaneioVolumes,ref m_typDatSetTbProdutosRomaneioVolumesProdutos,ref m_typDatSetTbProdutosRomaneioEmbalagens,ref m_typDatSetTbProdutosRomaneioEmbalagensProdutos,strNumeroVolume,false));
			}

		#endregion
		#region TipoVolume
			private void RetornaInformacoesTipoVolume(int nTipoVolume,out string strDescricaoTipoVolume,out string strDescricaoPopularTipoVolume,out int nIndiceImagemTipoVolume)
			{
				strDescricaoTipoVolume = "";
				strDescricaoPopularTipoVolume = "";
				nIndiceImagemTipoVolume = 2;
				mdlDataBaseAccess.Tabelas.XsdTbVolumes.tbVolumesRow dtrwVolume = m_typDatSetTbVolumes.tbVolumes.FindBynIdVolume(nTipoVolume);
				if (dtrwVolume != null)
				{
					// Descricao do Tipo
					if (!dtrwVolume.IsstrDescricaoNull())
						strDescricaoTipoVolume = dtrwVolume.strDescricao;

					// Indice da Imagem
					if (!dtrwVolume.IsnIdImagemNull())
						nIndiceImagemTipoVolume = dtrwVolume.nIdImagem;

					strDescricaoPopularTipoVolume = strRetornaInformacoesTipoVolumeExportador(m_nIdExportador,nTipoVolume);
				}
			}

			private string strRetornaInformacoesTipoVolumeExportador(int nTipoVolume,int nIdExportador)
			{
				string strRetorno = "";
				mdlDataBaseAccess.Tabelas.XsdTbExportadoresVolumes.tbExportadoresVolumesRow dtrwVolumeExportador = m_typDatSetTbExportadoresVolumes.tbExportadoresVolumes.FindByidExportadornIdVolume(nIdExportador,nTipoVolume);
				if (dtrwVolumeExportador != null)
				{
					// Descricao Popular do Tipo
					if (!dtrwVolumeExportador.IsstrDescricaoPopularNull())
						strRetorno = dtrwVolumeExportador.strDescricaoPopular;
				}
				return(strRetorno);
			}
		#endregion

		#region TreeView
			#region TreeNode
				private System.Windows.Forms.TreeNode NextNodeSameLevel(System.Windows.Forms.TreeNode tvnNodo)
				{
					System.Windows.Forms.TreeNode tvnRetorno = null;
					System.Windows.Forms.TreeNode tvnNodoLastOne = null; 
					int nLevel = 0;
					if (tvnNodo.NextNode != null)
					{
						tvnRetorno = tvnNodo.NextNode;
					}else{
						while (tvnRetorno == null)
						{
							if ((tvnNodo.FirstNode != null) && ((tvnNodoLastOne == null) || ((tvnNodoLastOne != null) && (tvnNodo.LastNode != tvnNodoLastOne) ) ) )
							{
								tvnNodoLastOne = tvnNodo;
								tvnNodo = tvnNodo.FirstNode;
							}else{
								if (tvnNodo.NextNode != null)
								{
									tvnNodoLastOne = tvnNodo;
									tvnNodo = tvnNodo.NextNode;
								}
								else
								{
									if (tvnNodo.Parent != null)
									{
										tvnNodoLastOne = tvnNodo;
										tvnNodo = tvnNodo.Parent;
										nLevel--;
									}
									else
									{
										break;
									}
								}
							}
							if (nLevel == 0)
							{
								tvnRetorno = tvnNodo;
							}
						}
					}
					return(tvnRetorno);
				}
			#endregion
		#endregion

		#region Retorno
			public void vRetornaValores(out System.Collections.ArrayList arlVolumes)
			{
				System.Collections.SortedList srtLstVolumes = new System.Collections.SortedList();
				foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumesRow dtrwVolume in m_typDatSetTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumes.Rows)
				{
					if (dtrwVolume.RowState != System.Data.DataRowState.Deleted)
					{
						string strTipo = "";
						if (!dtrwVolume.IsstrTipoPopularNull())
							strTipo = dtrwVolume.strTipoPopular;
						if (strTipo == "")
						{
							if (!dtrwVolume.IsnlTipoVolumeNull())
							{
								mdlDataBaseAccess.Tabelas.XsdTbVolumes.tbVolumesRow dtrwVolumes = m_typDatSetTbVolumes.tbVolumes.FindBynIdVolume(dtrwVolume.nlTipoVolume);
								if (dtrwVolumes != null)
								{
									strTipo = dtrwVolumes.strDescricao;
								}
							}
						}
						if (strTipo != "")
						{
							string strOriginal = strTipo;
							while(srtLstVolumes.Contains(strTipo))
								strTipo += "x";
							srtLstVolumes.Add(strTipo,strOriginal);
						}
					}
				}
				arlVolumes = new System.Collections.ArrayList();
				for(int i = 0;i < srtLstVolumes.Count;i++)
					arlVolumes.Add(srtLstVolumes.GetByIndex(i).ToString());
			}

			public void vRetornaValores(UnidadeMedida enumUnidadeMedida,out double dCubagemTotal,out string strUnidadeCubagem)
			{
				dCubagemTotal = 0;
				double dVolume = 0;
				strUnidadeCubagem = strRetornaSiglaUnidadeEspaco((int)enumUnidadeMedida) + "³";
				for(int i = 0; i < m_typDatSetTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumes.Rows.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumesRow dtrwVolume = (mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumesRow)m_typDatSetTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumes.Rows[i];
					if (bVolumeCubagem(enumUnidadeMedida,ref dtrwVolume,out dVolume))
						dCubagemTotal = dCubagemTotal + dVolume;
				}
			}

			public void vRetornaValores(mdlConstantes.UnidadeMassa enumUnidadeMassaPesoLiquido,out string strPesoLiquido,mdlConstantes.UnidadeMassa enumUnidadeMassaPesoBruto,out string strPesoBruto)
			{
				int nUnidadeMassaPesoLiquidoFatura,nUnidadeMassaPesoBrutoFatura;
				nUnidadeMassaPesoLiquidoFatura = m_nIdUnidadeMassaFaturaPesoLiquido;
				nUnidadeMassaPesoBrutoFatura = m_nIdUnidadeMassaFaturaPesoBruto;
				m_nIdUnidadeMassaFaturaPesoLiquido = (int)enumUnidadeMassaPesoLiquido;
				m_nIdUnidadeMassaFaturaPesoBruto = (int)enumUnidadeMassaPesoBruto;
				vCarregaDadosRomaneio(out strPesoLiquido,out strPesoBruto);
				m_nIdUnidadeMassaFaturaPesoLiquido = nUnidadeMassaPesoLiquidoFatura;
				m_nIdUnidadeMassaFaturaPesoBruto = nUnidadeMassaPesoBrutoFatura;
			}
		#endregion
	}
}
