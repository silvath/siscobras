using System;

namespace mdlAssinatura
{
	/// <summary>
	/// Summary description for clsAssinatura.
	/// </summary>
	public abstract class clsAssinatura
	{
		#region Atributos
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
		protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionBD;
		protected string m_strEnderecoExecutavel;

		private bool m_bMostrarBaloes = true;

		protected mdlComponentesGraficos.MessageBalloon m_mgblBalaoToolTip = null;

		protected int m_nIdExportador = -1;
		protected int m_nIdAssinatura = -1;
		protected string m_strAssinatura = "";

		public bool m_bModificado = false;

		private frmFAssinatura m_formFAssinatura = null;
		private frmFAssinaturaCadEdit m_formFAssinaturaCadEdit = null;

		protected mdlDataBaseAccess.Tabelas.XsdTbExportadores m_typDatSetTbExportadores;
		protected mdlDataBaseAccess.Tabelas.XsdTbAssinaturas m_typDatSetTbAssinaturas;
		#endregion

		#region Construtores & Destrutores
		public clsAssinatura(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador)
		{
			m_cls_ter_tratadorErro = tratadorErro;
			m_cls_dba_ConnectionBD = ConnectionDB;
			m_strEnderecoExecutavel = EnderecoExecutavel;
			m_nIdExportador = nIdExportador;
			mdlManipuladorArquivo.clsManipuladorArquivoIni obj = new mdlManipuladorArquivo.clsManipuladorArquivoIni(m_strEnderecoExecutavel + "sisco.ini");
			m_bMostrarBaloes = obj.retornaValor(mdlConstantes.clsConstantes.SHOW_BALLOONTIP_SESSAO, mdlConstantes.clsConstantes.SHOW_BALLOONTIP_VARIAVEL, true);
		}
		#endregion

		#region InitializeEventsFormAssinatura
		protected void InitializeEventsFormAssinatura()
		{
			// Carrega Dados BD
			m_formFAssinatura.eCallCarregaDadosBD += new frmFAssinatura.delCallCarregaDadosBD(carregaDadosBD);

			// Carrega Dados Interface
			m_formFAssinatura.eCallCarregaDadosInterface += new frmFAssinatura.delCallCarregaDadosInterface(carregaDadosInterfaceAssinaturas);

			// Salva Dados Interface
			m_formFAssinatura.eCallSalvaDadosInterface += new frmFAssinatura.delCallSalvaDadosInterface(salvaDadosInterface);

			// Salva Dados BD
			m_formFAssinatura.eCallSalvaDadosBD += new frmFAssinatura.delCallSalvaDadosBD(salvaDadosBD);

			// Edição de Assinatura
			m_formFAssinatura.eCallEditaAssinatura += new frmFAssinatura.delCallEditaAssinatura(editaAssinatura);

			// Cadastro de Assinatura
			m_formFAssinatura.eCallCadastraAssinatura += new frmFAssinatura.delCallCadastraAssinatura(cadastraAssinatura);

			// Remoção de Assinatura
			m_formFAssinatura.eCallRemoveAssinatura += new frmFAssinatura.delCallRemoveAssinatura(removeAssinatura);
		}
		#endregion

		#region Show Dialog
		public void ShowDialog()
		{
			try
			{
				m_formFAssinatura = new frmFAssinatura(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel);
				InitializeEventsFormAssinatura();
				m_formFAssinatura.ShowDialog();
				m_formFAssinatura.Dispose();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region InitializeEventsFormAssinaturaCadEdit
		protected void InitializeEventsFormAssinaturaCadEdit()
		{
			// Carrega Dados Interface
			m_formFAssinaturaCadEdit.eCallCarregaDadosInterface += new frmFAssinaturaCadEdit.delCallCarregaDadosInterface(carregaDadosInterfaceCadEdit);

			// Salva Dados Interface
			m_formFAssinaturaCadEdit.eCallSalvaDadosInterface += new frmFAssinaturaCadEdit.delCallSalvaDadosInterface(salvaDadosInterfaceCadEdit);

			// Salva Dados BD
			m_formFAssinaturaCadEdit.eCallSalvaDadosBD += new frmFAssinaturaCadEdit.delCallSalvaDadosBD(salvaDadosBDCadEdit);
		}
		#endregion

		#region Show Dialog CadEdit
		public void ShowDialogCadEdit()
		{
			try
			{
				m_formFAssinaturaCadEdit = new frmFAssinaturaCadEdit(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel);
				InitializeEventsFormAssinaturaCadEdit();
				m_formFAssinaturaCadEdit.ShowDialog();
				m_formFAssinaturaCadEdit.Dispose();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Edita Assinatura
		protected void editaAssinatura()
		{
			try
			{
				m_formFAssinaturaCadEdit = new frmFAssinaturaCadEdit(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel, ref this.m_formFAssinatura);
				InitializeEventsFormAssinaturaCadEdit();
				m_formFAssinaturaCadEdit.setTextoGroupBox("Edição");
				m_formFAssinaturaCadEdit.ShowDialog();
				m_formFAssinaturaCadEdit.Dispose();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Cadastra Assinatura
		protected void cadastraAssinatura()
		{
			try
			{
				m_formFAssinaturaCadEdit = new frmFAssinaturaCadEdit(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel, true, ref this.m_formFAssinatura);
				InitializeEventsFormAssinaturaCadEdit();
				m_formFAssinaturaCadEdit.setTextoGroupBox("Cadastro");
				m_formFAssinaturaCadEdit.ShowDialog();
				m_formFAssinaturaCadEdit.Dispose();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Remove Assinatura
		protected void removeAssinatura(ref mdlComponentesGraficos.ListView lvAssinaturas)
		{
			mdlDataBaseAccess.Tabelas.XsdTbAssinaturas.tbAssinaturasRow dtrwRowTbAssinatura = null;
			int nIdAssinatura = 0;
			if (lvAssinaturas.SelectedItems.Count > 0)
			{
				System.Windows.Forms.DialogResult drApaga = mdlMensagens.clsMensagens.ShowQuestion("Assinaturas",mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlAssinatura_clsAssinatura_ApagarAssinaturas).Replace("TAG",lvAssinaturas.SelectedItems.Count.ToString()), System.Windows.Forms.MessageBoxButtons.YesNo);
				//System.Windows.Forms.DialogResult drApaga = System.Windows.Forms.MessageBox.Show("Você tem certeza que deseja excluir " + lvAssinaturas.SelectedItems.Count.ToString() + " assinatura(s)?","Assinaturas",System.Windows.Forms.MessageBoxButtons.YesNo);
				while (lvAssinaturas.SelectedItems.Count > 0 && drApaga == System.Windows.Forms.DialogResult.Yes)
				{
					nIdAssinatura = Int32.Parse(lvAssinaturas.SelectedItems[0].Tag.ToString());
					dtrwRowTbAssinatura = m_typDatSetTbAssinaturas.tbAssinaturas.FindBynIdAssinatura(nIdAssinatura);
					if (dtrwRowTbAssinatura != null)
					{
						dtrwRowTbAssinatura.Delete();
						dtrwRowTbAssinatura = null;
					}
					lvAssinaturas.SelectedItems[0].Selected = false;
				}
				if (drApaga == System.Windows.Forms.DialogResult.Yes)
				{
					m_strAssinatura = "";
					m_nIdAssinatura = -1;
				}
			}
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
				System.Collections.ArrayList arlOrdenacaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlOrdenacaoCampo.Add("strNomeAssinante");
				arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente);

				m_typDatSetTbAssinaturas = m_cls_dba_ConnectionBD.GetTbAssinaturas(null,null,null,arlOrdenacaoCampo,arlOrdenacaoTipo);
				m_typDatSetTbExportadores = m_cls_dba_ConnectionBD.GetTbExportadores(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected void carregaDadosBD()
		{
			try
			{
				carregaDadosBDEspecifico();
				carregaDadosBDAssinatura();
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected void carregaDadosBDAssinatura()
		{
			mdlDataBaseAccess.Tabelas.XsdTbAssinaturas.tbAssinaturasRow dtrwRowTbAssinaturas = null;
			if (m_typDatSetTbAssinaturas != null)
				dtrwRowTbAssinaturas = m_typDatSetTbAssinaturas.tbAssinaturas.FindBynIdAssinatura(m_nIdAssinatura);
			if (dtrwRowTbAssinaturas != null)
				m_strAssinatura = dtrwRowTbAssinaturas.strNomeAssinante;
		}
		protected abstract void carregaDadosBDEspecifico();
		#endregion
		#region Interface
		protected void carregaDadosInterfaceAssinaturas(ref mdlComponentesGraficos.ListView lvAssinaturas,ref System.Windows.Forms.Button btEditar, ref System.Windows.Forms.Button btExcluir, ref System.Windows.Forms.Button btNovo)
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbAssinaturas.tbAssinaturasRow dtrwRowTbAssinaturas;
				System.Windows.Forms.ListViewItem lvItemAssinatura;

				if (lvAssinaturas.SelectedItems.Count > 0)
				{
					m_nIdAssinatura = Int32.Parse(lvAssinaturas.SelectedItems[0].Tag.ToString());
					m_strAssinatura = lvAssinaturas.SelectedItems[0].Text;
				}
				lvAssinaturas.Items.Clear();
				for (int nCount = 0; nCount < m_typDatSetTbAssinaturas.tbAssinaturas.Rows.Count; nCount++)
				{
					dtrwRowTbAssinaturas = (mdlDataBaseAccess.Tabelas.XsdTbAssinaturas.tbAssinaturasRow)m_typDatSetTbAssinaturas.tbAssinaturas.Rows[nCount];
					if (dtrwRowTbAssinaturas.RowState != System.Data.DataRowState.Deleted)
					{
						lvItemAssinatura = lvAssinaturas.Items.Add(dtrwRowTbAssinaturas.strNomeAssinante);
						lvItemAssinatura.Tag = dtrwRowTbAssinaturas.nIdAssinatura;
						if (dtrwRowTbAssinaturas.nIdAssinatura == m_nIdAssinatura)
						{
							lvItemAssinatura.Selected = true;
							m_strAssinatura = dtrwRowTbAssinaturas.strNomeAssinante;
						}
					}
				}
				if (lvAssinaturas.Items.Count <= 0)
				{
					btEditar.Enabled = false;
					btExcluir.Enabled = false;
					if (m_bMostrarBaloes)
					{
						m_mgblBalaoToolTip = new mdlComponentesGraficos.MessageBalloon();
						m_mgblBalaoToolTip.Caption = mdlConstantes.clsConstantes.BALLONTIP_DEFAULT_CAPTION;
						m_mgblBalaoToolTip.Content = mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.BALLOONTIP_mdlAssinatura_clsAssinatura_NovaAssinatura.ToString());
						m_mgblBalaoToolTip.Icon = System.Drawing.SystemIcons.Information;
						m_mgblBalaoToolTip.CloseOnMouseClick = true;
						m_mgblBalaoToolTip.CloseOnDeactivate = true;
						m_mgblBalaoToolTip.CloseOnKeyPress = true;
						m_mgblBalaoToolTip.ShowBalloon((System.Windows.Forms.Control)btNovo);
					}
				}
				else 
				{
					btEditar.Enabled = true;
					btExcluir.Enabled = true;
					if (lvAssinaturas.SelectedItems.Count == 0)
					{
						lvItemAssinatura = lvAssinaturas.Items[0];
						lvItemAssinatura.Selected = true;
						m_nIdAssinatura = (int)lvItemAssinatura.Tag;
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
		#region Salvamento de Dados
		#region Interface
		protected void salvaDadosInterface(ref mdlComponentesGraficos.ListView lvAssinaturas, bool bModificado)
		{
			this.m_bModificado = bModificado;
			if (lvAssinaturas.SelectedItems.Count > 0)
			{
				m_strAssinatura = lvAssinaturas.SelectedItems[0].Text;
				m_nIdAssinatura = Int32.Parse(lvAssinaturas.SelectedItems[0].Tag.ToString());
			}
		}
		#endregion
		#region Banco de Dados
		protected void salvaDadosBD()
		{
			try
			{
				salvaDadosBDEspecifico();
				salvaDadosBDAssinaturaExportador();
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void salvaDadosBDAssinaturaExportador()
		{
			try
			{
				m_cls_dba_ConnectionBD.SetTbAssinaturas(m_typDatSetTbAssinaturas);
				m_cls_dba_ConnectionBD.SetTbExportadores(m_typDatSetTbExportadores);
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected abstract void salvaDadosBDEspecifico();
		#endregion
		#endregion

		#region Carregamento de Dados CadEdit
		#region Interface
		protected void carregaDadosInterfaceCadEdit(ref mdlComponentesGraficos.TextBox tbAssinatura)
		{
			try
			{
				tbAssinatura.Text = m_strAssinatura;
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#endregion
		#region Salvamento de Dados CadEdit
		#region Interface
		protected void salvaDadosInterfaceCadEdit(ref mdlComponentesGraficos.TextBox tbAssinatura)
		{
			try
			{
				m_strAssinatura = tbAssinatura.Text;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Banco de Dados
		protected void salvaDadosBDCadEdit(bool cadastraNovo, bool modificado)
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbAssinaturas.tbAssinaturasRow dtrwRowTbAssinaturas;
				int nIdAssinatura = 1;
				this.m_bModificado = modificado;
				if (cadastraNovo == true)
				{
					while(m_typDatSetTbAssinaturas.tbAssinaturas.FindBynIdAssinatura(nIdAssinatura) != null)
						nIdAssinatura++;
					m_nIdAssinatura = nIdAssinatura;
					dtrwRowTbAssinaturas = m_typDatSetTbAssinaturas.tbAssinaturas.NewtbAssinaturasRow();
				} 
				else 
				{
					dtrwRowTbAssinaturas = m_typDatSetTbAssinaturas.tbAssinaturas.FindBynIdAssinatura(m_nIdAssinatura);
				}
				dtrwRowTbAssinaturas.nIdAssinatura = m_nIdAssinatura;
				dtrwRowTbAssinaturas.strNomeAssinante = m_strAssinatura;
				if (cadastraNovo == true)
					m_typDatSetTbAssinaturas.tbAssinaturas.AddtbAssinaturasRow(dtrwRowTbAssinaturas);
				m_cls_dba_ConnectionBD.SetTbAssinaturas(m_typDatSetTbAssinaturas);
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#endregion

		#region Retorna Valores
		public void retornaValores(out string strAssinatura)
		{
			strAssinatura = m_strAssinatura;
		}
		#endregion
	}
}
