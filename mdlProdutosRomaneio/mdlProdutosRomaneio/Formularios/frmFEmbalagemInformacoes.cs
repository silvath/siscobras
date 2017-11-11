using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlProdutosRomaneio
{
	/// <summary>
	/// Summary description for frmFEmbalagemInformacoes.
	/// </summary>
	internal class frmFEmbalagemInformacoes : System.Windows.Forms.Form
	{
		#region Atributes
			private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro; 
			private string m_strEnderecoExecutavel;

			System.Collections.ArrayList m_arlEmbalagens;

			// Typed DataSets
			private mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens m_typDatSetTbProdutosRomaneioEmbalagensCopy;
			private mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos m_typDatSetTbProdutosRomaneioEmbalagensProdutosCopy;

			public bool m_bModificado = false;

			internal System.Windows.Forms.GroupBox m_gbGeral;
			internal System.Windows.Forms.Button m_btOk;
			internal System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.GroupBox m_gbInformacoesEmbalagem;
			private System.Windows.Forms.GroupBox m_gbEmbalagens;
			private System.Windows.Forms.GroupBox m_gbInformacoes;
			private System.Windows.Forms.GroupBox m_gbProdutos;
			private System.Windows.Forms.Label m_lbNumero;
			private System.Windows.Forms.TextBox m_txtNumero;
			private System.Windows.Forms.Label m_lbVolume;
			private System.Windows.Forms.Label m_lbPesoLiquido;
			private System.Windows.Forms.TextBox m_txtPesoLiquido;
			private System.Windows.Forms.TextBox m_txtVolume;
			private mdlComponentesGraficos.ListView m_lvProdutos;
			private mdlComponentesGraficos.ListView m_lvEmbalagem;
			private System.Windows.Forms.ColumnHeader m_colProdutosQuantidade;
			private System.Windows.Forms.ColumnHeader m_colProdutosPesoLiquido;
			private System.Windows.Forms.ColumnHeader m_colProdutosDescricao;
			public System.Windows.Forms.Button m_btProdutoExcluir;
			public System.Windows.Forms.Button m_btProdutoEditar;
			private System.Windows.Forms.ToolTip m_ttDica;
			private System.ComponentModel.IContainer components;
		#endregion
		#region Delegates
			#region Carregamento dos Dados
				public delegate void delCallCarregaDadosEmbalagens(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens typDatSetTbProdutosRomaneioEmbalagens,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos typDatSetTbProdutosRomaneioEmbalagensProdutos,ref mdlComponentesGraficos.ListView lvEmbalagens,ref System.Collections.ArrayList arlEmbalagens,bool bDetalhado);
				public delegate void delCallCarregaDadosEmbalagemSelecionada(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens typDatSetTbProdutosRomaneioEmbalagens,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos typDatSetTbProdutosRomaneioEmbalagensProdutos,string strIdEmbalagem,out double dPesoLiquido, out string strSiglaUnidadeMassaPesoLiquido,out string strNumeroVolume);
		        public delegate void delCallCarregaProdutosEmbalagem(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos typDatSetTbProdutosRomaneioEmbalagensProdutos,string strIdEmbalagem,ref mdlComponentesGraficos.ListView lvProdutos);
			#endregion
			#region Produtos
				public delegate bool delCallShowDialogProdutoEmbalagem(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens typDatSetTbProdutosRomaneioEmbalagens,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos typDatSetTbProdutosRomaneioEmbalagensProdutos,ref System.Collections.ArrayList arlProdutos,ref System.Collections.ArrayList arlEmbalagens);
				public delegate bool delCallProdutosEmbalagemExclui(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos typDatSetTbProdutosRomaneioEmbalagensProdutos,string strIdEmbalagem,ref System.Collections.ArrayList arlProdutos);
			#endregion
			#region Embalagens
				public delegate bool delCallEmbalagemExistente(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens typDatSetTbProdutosRomaneioEmbalagens,string strIdEmbalagem);
			#endregion
			#region Salvamento dos dados 
				public delegate void delCallSalvaDadosEmbalagemNumeroEmbalagem(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens typDatSetTbProdutosRomaneioEmbalagens,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos typDatSetTbProdutosRomaneioEmbalagensProdutos,string strIdEmbalagemAnterior,string strIdEmbalagemNova);
			#endregion
		#endregion
		#region Events
			#region Carregamento dos Dados
				public event delCallCarregaDadosEmbalagens eCallCarregaDadosEmbalagens;
				public event delCallCarregaDadosEmbalagemSelecionada eCallCarregaDadosEmbalagemSelecionada;
				public event delCallCarregaProdutosEmbalagem eCallCarregaProdutosEmbalagem;
			#endregion
			#region Produtos
				public event delCallShowDialogProdutoEmbalagem eCallShowDialogProdutoEmbalagem;
				public event delCallProdutosEmbalagemExclui eCallProdutosEmbalagemExclui;
			#endregion
			#region Embalagens
				public event delCallEmbalagemExistente eCallEmbalagemExistente;
			#endregion
			#region Salvamento dos dados 
				public event delCallSalvaDadosEmbalagemNumeroEmbalagem eCallSalvaDadosEmbalagemNumeroEmbalagem;
			#endregion
		#endregion
		#region Events Methods
			#region Carregamento dos Dados
				protected virtual void OnCallCarregaDadosEmbalagens()
				{
					m_lvEmbalagem.Items.Clear();
					if (eCallCarregaDadosEmbalagens != null)
						eCallCarregaDadosEmbalagens(ref m_typDatSetTbProdutosRomaneioEmbalagensCopy,ref m_typDatSetTbProdutosRomaneioEmbalagensProdutosCopy ,ref m_lvEmbalagem,ref m_arlEmbalagens,false);
				}

				protected virtual void OnCallCarregaDadosEmbalagemSelecionada(bool bForcaAtualizacaoDados)
				{
					if (eCallCarregaDadosEmbalagemSelecionada != null)
					{
						string strIdEmbalagem = "";
						if (m_lvEmbalagem.SelectedItems.Count > 0)
						{
							strIdEmbalagem = m_lvEmbalagem.SelectedItems[0].Text.Trim();
							if ((strIdEmbalagem != m_txtNumero.Text.Trim()) || (bForcaAtualizacaoDados))
							{
								m_txtNumero.Text = strIdEmbalagem;
								double dPesoLiquido;
								string strSiglaUnidadeMassaPesoLiquido;
								string strNumeroVolume; 
								eCallCarregaDadosEmbalagemSelecionada(ref m_typDatSetTbProdutosRomaneioEmbalagensCopy,ref m_typDatSetTbProdutosRomaneioEmbalagensProdutosCopy,strIdEmbalagem,out dPesoLiquido,out strSiglaUnidadeMassaPesoLiquido,out strNumeroVolume);
								m_txtPesoLiquido.Text = dPesoLiquido.ToString() + " " + strSiglaUnidadeMassaPesoLiquido;
								m_txtVolume.Text = strNumeroVolume;
								OnCallCarregaProdutosEmbalagem(strIdEmbalagem);
							}
						}
					}
				}

				protected virtual void OnCallCarregaProdutosEmbalagem(string strIdEmbalagem)
				{
					if (eCallCarregaProdutosEmbalagem != null)
					{
						m_lvProdutos.Items.Clear();
						eCallCarregaProdutosEmbalagem(ref m_typDatSetTbProdutosRomaneioEmbalagensProdutosCopy,strIdEmbalagem,ref m_lvProdutos);
					}
				}
			#endregion
			#region Produtos
				protected virtual void OnCallShowDialogProdutoEmbalagem()
				{
					if (eCallShowDialogProdutoEmbalagem != null)
					{	
						this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
						string strIdEmbalagem = "";
						if (m_lvEmbalagem.SelectedItems.Count > 0)
						{
							strIdEmbalagem = m_lvEmbalagem.SelectedItems[0].Text;
							if (m_lvProdutos.SelectedItems.Count > 0)
							{
								int nIdOrdemProduto = Int32.Parse(m_lvProdutos.SelectedItems[0].Tag.ToString());
								System.Collections.ArrayList arlProdutos = new System.Collections.ArrayList();
								arlProdutos.Add(nIdOrdemProduto);
								System.Collections.ArrayList arlEmbalagens = new System.Collections.ArrayList();
								arlEmbalagens.Add(strIdEmbalagem);
								if (eCallShowDialogProdutoEmbalagem(ref m_typDatSetTbProdutosRomaneioEmbalagensCopy, ref m_typDatSetTbProdutosRomaneioEmbalagensProdutosCopy,ref arlProdutos,ref arlEmbalagens))
								{
									OnCallCarregaDadosEmbalagemSelecionada(true);
								}
							}
						}
						this.Cursor = System.Windows.Forms.Cursors.Default;
					}
				}

				protected virtual bool OnCallProdutosEmbalagemExclui()
				{
					bool bRetorno = false;
					if (eCallProdutosEmbalagemExclui != null)
					{
						if (m_lvEmbalagem.SelectedItems.Count > 0)
						{
							string strIdEmbalagem = m_lvEmbalagem.SelectedItems[0].Text; 
							if (m_lvProdutos.SelectedItems.Count > 0)
							{
								System.Collections.ArrayList arlProdutos = new System.Collections.ArrayList();
								for (int nCont = 0 ; nCont < m_lvProdutos.SelectedItems.Count;nCont++)
								{
									arlProdutos.Add(m_lvProdutos.SelectedItems[nCont].Tag);
								}
								if (mdlMensagens.clsMensagens.ShowQuestion("Siscobras.NET",mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlProdutosRomaneio_frmFEmbalagemInformacoes_ExcluirProdutosDaEmbalagem).Replace("TAG",arlProdutos.Count.ToString()),System.Windows.Forms.MessageBoxButtons.YesNo) ==  System.Windows.Forms.DialogResult.Yes)
								{
									//if (MessageBox.Show("Deseja mesmo excluir estes " + arlProdutos.Count + " produto(s) da embalagem ?","Siscobras.NET",System.Windows.Forms.MessageBoxButtons.YesNo,System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
									//{
										if (bRetorno = eCallProdutosEmbalagemExclui(ref m_typDatSetTbProdutosRomaneioEmbalagensProdutosCopy,strIdEmbalagem,ref arlProdutos))
										{
											OnCallCarregaDadosEmbalagemSelecionada(true);
										}
									//}
								}
							}
						}
					}
					return(bRetorno);
				}
			#endregion
			#region Embalagens
				protected virtual bool OnCallEmbalagemExistente(string strIdEmbalagem)
				{
					bool bRetorno = false;
					if (eCallEmbalagemExistente != null)
						bRetorno = eCallEmbalagemExistente(ref m_typDatSetTbProdutosRomaneioEmbalagensCopy,strIdEmbalagem);
					return(bRetorno);
				}
			#endregion
			#region Salvamento dos dados 
				protected virtual void OnCallSalvaDadosEmbalagemNumeroEmbalagem(string strIdEmbalagemAntiga,string strIdEmbalagemNova)
				{
					if (eCallSalvaDadosEmbalagemNumeroEmbalagem != null)
						eCallSalvaDadosEmbalagemNumeroEmbalagem(ref m_typDatSetTbProdutosRomaneioEmbalagensCopy,ref m_typDatSetTbProdutosRomaneioEmbalagensProdutosCopy ,strIdEmbalagemAntiga,strIdEmbalagemNova);
				}
			#endregion
		#endregion
		#region Constructors and Destructors
			public frmFEmbalagemInformacoes(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, string strEnderecoExecutavel,mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens typDatSetTbProdutosRomaneioEmbalagens,mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos typDatSetTbProdutosRomaneioEmbalagensProdutos, ref System.Windows.Forms.ImageList ilEmbalagens,ref System.Collections.ArrayList arlEmbalagens)
			{
				m_cls_ter_tratadorErro = tratadorErro;
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				m_arlEmbalagens = arlEmbalagens;

				// Typed DataSets Clones
				m_typDatSetTbProdutosRomaneioEmbalagensCopy = (mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens)typDatSetTbProdutosRomaneioEmbalagens.Copy();
				m_typDatSetTbProdutosRomaneioEmbalagensProdutosCopy = (mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos)typDatSetTbProdutosRomaneioEmbalagensProdutos.Copy();

				InitializeComponent();

				m_lvEmbalagem.SmallImageList = ilEmbalagens;
				m_lvEmbalagem.LargeImageList = ilEmbalagens;
				m_lvProdutos.SmallImageList = ilEmbalagens;
				m_lvProdutos.LargeImageList = ilEmbalagens;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFEmbalagemInformacoes));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbInformacoesEmbalagem = new System.Windows.Forms.GroupBox();
			this.m_gbInformacoes = new System.Windows.Forms.GroupBox();
			this.m_txtVolume = new System.Windows.Forms.TextBox();
			this.m_lbVolume = new System.Windows.Forms.Label();
			this.m_txtNumero = new System.Windows.Forms.TextBox();
			this.m_lbNumero = new System.Windows.Forms.Label();
			this.m_gbProdutos = new System.Windows.Forms.GroupBox();
			this.m_btProdutoExcluir = new System.Windows.Forms.Button();
			this.m_btProdutoEditar = new System.Windows.Forms.Button();
			this.m_lvProdutos = new mdlComponentesGraficos.ListView();
			this.m_colProdutosQuantidade = new System.Windows.Forms.ColumnHeader();
			this.m_colProdutosDescricao = new System.Windows.Forms.ColumnHeader();
			this.m_colProdutosPesoLiquido = new System.Windows.Forms.ColumnHeader();
			this.m_txtPesoLiquido = new System.Windows.Forms.TextBox();
			this.m_lbPesoLiquido = new System.Windows.Forms.Label();
			this.m_gbEmbalagens = new System.Windows.Forms.GroupBox();
			this.m_lvEmbalagem = new mdlComponentesGraficos.ListView();
			this.m_ttDica = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbGeral.SuspendLayout();
			this.m_gbInformacoesEmbalagem.SuspendLayout();
			this.m_gbInformacoes.SuspendLayout();
			this.m_gbProdutos.SuspendLayout();
			this.m_gbEmbalagens.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Controls.Add(this.m_gbInformacoesEmbalagem);
			this.m_gbGeral.Location = new System.Drawing.Point(4, 1);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(556, 369);
			this.m_gbGeral.TabIndex = 3;
			this.m_gbGeral.TabStop = false;
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(199, 340);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 68;
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
			this.m_btCancelar.Location = new System.Drawing.Point(263, 340);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 69;
			this.m_ttDica.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbInformacoesEmbalagem
			// 
			this.m_gbInformacoesEmbalagem.Controls.Add(this.m_gbInformacoes);
			this.m_gbInformacoesEmbalagem.Controls.Add(this.m_gbEmbalagens);
			this.m_gbInformacoesEmbalagem.Location = new System.Drawing.Point(5, 10);
			this.m_gbInformacoesEmbalagem.Name = "m_gbInformacoesEmbalagem";
			this.m_gbInformacoesEmbalagem.Size = new System.Drawing.Size(539, 326);
			this.m_gbInformacoesEmbalagem.TabIndex = 3;
			this.m_gbInformacoesEmbalagem.TabStop = false;
			// 
			// m_gbInformacoes
			// 
			this.m_gbInformacoes.Controls.Add(this.m_txtVolume);
			this.m_gbInformacoes.Controls.Add(this.m_lbVolume);
			this.m_gbInformacoes.Controls.Add(this.m_txtNumero);
			this.m_gbInformacoes.Controls.Add(this.m_lbNumero);
			this.m_gbInformacoes.Controls.Add(this.m_gbProdutos);
			this.m_gbInformacoes.Controls.Add(this.m_txtPesoLiquido);
			this.m_gbInformacoes.Controls.Add(this.m_lbPesoLiquido);
			this.m_gbInformacoes.Location = new System.Drawing.Point(8, 128);
			this.m_gbInformacoes.Name = "m_gbInformacoes";
			this.m_gbInformacoes.Size = new System.Drawing.Size(520, 192);
			this.m_gbInformacoes.TabIndex = 2;
			this.m_gbInformacoes.TabStop = false;
			this.m_gbInformacoes.Text = "Informações";
			// 
			// m_txtVolume
			// 
			this.m_txtVolume.Location = new System.Drawing.Point(407, 16);
			this.m_txtVolume.Name = "m_txtVolume";
			this.m_txtVolume.ReadOnly = true;
			this.m_txtVolume.Size = new System.Drawing.Size(104, 20);
			this.m_txtVolume.TabIndex = 5;
			this.m_txtVolume.Text = "";
			// 
			// m_lbVolume
			// 
			this.m_lbVolume.Location = new System.Drawing.Point(306, 19);
			this.m_lbVolume.Name = "m_lbVolume";
			this.m_lbVolume.Size = new System.Drawing.Size(102, 16);
			this.m_lbVolume.TabIndex = 4;
			this.m_lbVolume.Text = "Embalagem Final:";
			// 
			// m_txtNumero
			// 
			this.m_txtNumero.Location = new System.Drawing.Point(64, 17);
			this.m_txtNumero.Name = "m_txtNumero";
			this.m_txtNumero.Size = new System.Drawing.Size(56, 20);
			this.m_txtNumero.TabIndex = 3;
			this.m_txtNumero.Text = "";
			this.m_txtNumero.Leave += new System.EventHandler(this.m_txtNumero_Leave);
			// 
			// m_lbNumero
			// 
			this.m_lbNumero.Location = new System.Drawing.Point(7, 19);
			this.m_lbNumero.Name = "m_lbNumero";
			this.m_lbNumero.Size = new System.Drawing.Size(54, 16);
			this.m_lbNumero.TabIndex = 2;
			this.m_lbNumero.Text = "Número:";
			// 
			// m_gbProdutos
			// 
			this.m_gbProdutos.Controls.Add(this.m_btProdutoExcluir);
			this.m_gbProdutos.Controls.Add(this.m_btProdutoEditar);
			this.m_gbProdutos.Controls.Add(this.m_lvProdutos);
			this.m_gbProdutos.Location = new System.Drawing.Point(8, 40);
			this.m_gbProdutos.Name = "m_gbProdutos";
			this.m_gbProdutos.Size = new System.Drawing.Size(504, 144);
			this.m_gbProdutos.TabIndex = 1;
			this.m_gbProdutos.TabStop = false;
			this.m_gbProdutos.Text = "Produtos";
			// 
			// m_btProdutoExcluir
			// 
			this.m_btProdutoExcluir.BackColor = System.Drawing.SystemColors.Control;
			this.m_btProdutoExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btProdutoExcluir.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btProdutoExcluir.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btProdutoExcluir.Image = ((System.Drawing.Image)(resources.GetObject("m_btProdutoExcluir.Image")));
			this.m_btProdutoExcluir.Location = new System.Drawing.Point(239, 11);
			this.m_btProdutoExcluir.Name = "m_btProdutoExcluir";
			this.m_btProdutoExcluir.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btProdutoExcluir.Size = new System.Drawing.Size(25, 25);
			this.m_btProdutoExcluir.TabIndex = 16;
			this.m_btProdutoExcluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDica.SetToolTip(this.m_btProdutoExcluir, "Edita os produtos selecionados");
			this.m_btProdutoExcluir.Click += new System.EventHandler(this.m_btProdutoExcluir_Click);
			// 
			// m_btProdutoEditar
			// 
			this.m_btProdutoEditar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btProdutoEditar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btProdutoEditar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btProdutoEditar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btProdutoEditar.Image = ((System.Drawing.Image)(resources.GetObject("m_btProdutoEditar.Image")));
			this.m_btProdutoEditar.Location = new System.Drawing.Point(208, 11);
			this.m_btProdutoEditar.Name = "m_btProdutoEditar";
			this.m_btProdutoEditar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btProdutoEditar.Size = new System.Drawing.Size(25, 25);
			this.m_btProdutoEditar.TabIndex = 15;
			this.m_btProdutoEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDica.SetToolTip(this.m_btProdutoEditar, "Exclui os produtos selecionados");
			// 
			// m_lvProdutos
			// 
			this.m_lvProdutos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						   this.m_colProdutosQuantidade,
																						   this.m_colProdutosDescricao,
																						   this.m_colProdutosPesoLiquido});
			this.m_lvProdutos.FullRowSelect = true;
			this.m_lvProdutos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.m_lvProdutos.HideSelection = false;
			this.m_lvProdutos.Location = new System.Drawing.Point(8, 40);
			this.m_lvProdutos.MultiSelect = false;
			this.m_lvProdutos.Name = "m_lvProdutos";
			this.m_lvProdutos.Size = new System.Drawing.Size(488, 96);
			this.m_lvProdutos.TabIndex = 0;
			this.m_lvProdutos.View = System.Windows.Forms.View.Details;
			this.m_lvProdutos.DoubleClick += new System.EventHandler(this.m_lvProdutos_DoubleClick);
			// 
			// m_colProdutosQuantidade
			// 
			this.m_colProdutosQuantidade.Text = "Quantidade";
			this.m_colProdutosQuantidade.Width = 100;
			// 
			// m_colProdutosDescricao
			// 
			this.m_colProdutosDescricao.Text = "Descrição";
			this.m_colProdutosDescricao.Width = 280;
			// 
			// m_colProdutosPesoLiquido
			// 
			this.m_colProdutosPesoLiquido.Text = "Peso Liquido";
			this.m_colProdutosPesoLiquido.Width = 100;
			// 
			// m_txtPesoLiquido
			// 
			this.m_txtPesoLiquido.Location = new System.Drawing.Point(208, 16);
			this.m_txtPesoLiquido.Name = "m_txtPesoLiquido";
			this.m_txtPesoLiquido.ReadOnly = true;
			this.m_txtPesoLiquido.Size = new System.Drawing.Size(88, 20);
			this.m_txtPesoLiquido.TabIndex = 6;
			this.m_txtPesoLiquido.Text = "";
			// 
			// m_lbPesoLiquido
			// 
			this.m_lbPesoLiquido.Location = new System.Drawing.Point(131, 20);
			this.m_lbPesoLiquido.Name = "m_lbPesoLiquido";
			this.m_lbPesoLiquido.Size = new System.Drawing.Size(80, 16);
			this.m_lbPesoLiquido.TabIndex = 1;
			this.m_lbPesoLiquido.Text = "Peso Liquido:";
			// 
			// m_gbEmbalagens
			// 
			this.m_gbEmbalagens.Controls.Add(this.m_lvEmbalagem);
			this.m_gbEmbalagens.Location = new System.Drawing.Point(8, 16);
			this.m_gbEmbalagens.Name = "m_gbEmbalagens";
			this.m_gbEmbalagens.Size = new System.Drawing.Size(520, 112);
			this.m_gbEmbalagens.TabIndex = 1;
			this.m_gbEmbalagens.TabStop = false;
			this.m_gbEmbalagens.Text = "Embalagens";
			// 
			// m_lvEmbalagem
			// 
			this.m_lvEmbalagem.HideSelection = false;
			this.m_lvEmbalagem.Location = new System.Drawing.Point(8, 16);
			this.m_lvEmbalagem.Name = "m_lvEmbalagem";
			this.m_lvEmbalagem.Size = new System.Drawing.Size(504, 88);
			this.m_lvEmbalagem.TabIndex = 0;
			this.m_lvEmbalagem.View = System.Windows.Forms.View.List;
			this.m_lvEmbalagem.Click += new System.EventHandler(this.m_lvEmbalagem_Click);
			// 
			// m_ttDica
			// 
			this.m_ttDica.AutomaticDelay = 100;
			this.m_ttDica.AutoPopDelay = 5000;
			this.m_ttDica.InitialDelay = 100;
			this.m_ttDica.ReshowDelay = 20;
			// 
			// frmFEmbalagemInformacoes
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
			this.ClientSize = new System.Drawing.Size(570, 376);
			this.Controls.Add(this.m_gbGeral);
			this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmFEmbalagemInformacoes";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Informações da Embalagem";
			this.Load += new System.EventHandler(this.frmFEmbalagemInformacoes_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbInformacoesEmbalagem.ResumeLayout(false);
			this.m_gbInformacoes.ResumeLayout(false);
			this.m_gbProdutos.ResumeLayout(false);
			this.m_gbEmbalagens.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formularios
				private void frmFEmbalagemInformacoes_Load(object sender, System.EventArgs e)
				{
					MostraCor();
					OnCallCarregaDadosEmbalagens();
					if (m_lvEmbalagem.Items.Count > 0)
					{
						m_lvEmbalagem.Items[0].Selected = true;
						m_lvEmbalagem_Click(sender,e);
					}
				}
			#endregion
			#region Botoes
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
			#region lvEmbalagem
				private void m_txtNumero_Leave(object sender, System.EventArgs e)
				{
					if (m_lvEmbalagem.SelectedItems.Count > 0)
					{
						string strIdEmbalagemListView = m_lvEmbalagem.SelectedItems[0].Text.Trim();
						string strIdEmbalagemTextBox = m_txtNumero.Text.Trim();
						if (strIdEmbalagemTextBox == "")
						{
							m_txtNumero.Text = strIdEmbalagemListView;
							mdlMensagens.clsMensagens.ShowInformation("Siscobras.NET",mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlProdutosRomaneio_frmFEmbalagemInformacoes_IdentificarEmbalagem));
							//MessageBox.Show("Você precisa colocar uma identificação para a embalagem.","Siscobras.NET",System.Windows.Forms.MessageBoxButtons.OK);
							m_txtNumero.Focus();
						}
						else
						{
							if (strIdEmbalagemTextBox != strIdEmbalagemListView)
							{
								if (OnCallEmbalagemExistente(strIdEmbalagemTextBox)) 
								{
									m_txtNumero.Text = strIdEmbalagemListView;
									mdlMensagens.clsMensagens.ShowInformation("Siscobras.NET",mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlProdutosRomaneio_frmFEmbalagemInformacoes_EmbalagemDuplicada));
									//MessageBox.Show("Já existe uma embalagem (intermediária) com esta identificação.","Siscobras.NET",System.Windows.Forms.MessageBoxButtons.OK);
									m_txtNumero.Focus();
								}
								else
								{
									OnCallSalvaDadosEmbalagemNumeroEmbalagem(strIdEmbalagemListView,strIdEmbalagemTextBox); 
									for(int nCont = 0;nCont < m_arlEmbalagens.Count;nCont++)
									{
										if (m_arlEmbalagens[nCont].ToString() == strIdEmbalagemListView)
										{
											m_arlEmbalagens[nCont] = strIdEmbalagemTextBox;
											break;
										}
									}
									OnCallCarregaDadosEmbalagens();
									for (int nCont = 0; nCont < m_lvEmbalagem.Items.Count;nCont++)
									{
										if (m_lvEmbalagem.Items[nCont].Text == strIdEmbalagemTextBox)
										{
											m_lvEmbalagem.Items[nCont].Selected = true;
											m_lvEmbalagem_Click(sender,e);
											break;
										}
									}
								}
							}
						}
					}
				}

				private void m_lvEmbalagem_Click(object sender, System.EventArgs e)
				{
					OnCallCarregaDadosEmbalagemSelecionada(false);
				}
			#endregion
			#region lvProdutos
				private void m_lvProdutos_DoubleClick(object sender, System.EventArgs e)
				{
					OnCallShowDialogProdutoEmbalagem();
				}

				private void m_btProdutoExcluir_Click(object sender, System.EventArgs e)
				{
					OnCallProdutosEmbalagemExclui();
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

		#region Retorno
			public void RetornaValores(out mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens typDatSetTbProdutosRomaneioEmbalagens,out mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos typDatSetTbProdutosRomaneioEmbalagensProdutos)
			{
				// Typed DataSets Retornando
				typDatSetTbProdutosRomaneioEmbalagens = m_typDatSetTbProdutosRomaneioEmbalagensCopy;
				typDatSetTbProdutosRomaneioEmbalagensProdutos = m_typDatSetTbProdutosRomaneioEmbalagensProdutosCopy;
				GC.Collect();
				GC.WaitForPendingFinalizers();
			}
		#endregion

	}
}
