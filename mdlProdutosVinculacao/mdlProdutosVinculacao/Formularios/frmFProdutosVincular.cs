using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlProdutosVinculacao.Formularios
{
	/// <summary>
	/// Summary description for frmFProdutosVincular.
	/// </summary>
	public class frmFProdutosVincular : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate void delCallCarregaCaption(out string strCaption);
			public delegate bool delCallCarregaDadosClassificacao();
			public delegate void delCallCarregaConfiguracao(out bool bMostrarProdutosAssociados);
			public delegate void delCallSalvaConfiguracao(bool bMostrarProdutosAssociados);
			public delegate void delCallRefreshClassificacao(ref System.Windows.Forms.ListView lvClassificacao);
			public delegate void delCallRefreshProdutos(ref System.Windows.Forms.ListView lvProdutos);
			public delegate bool delCallAssociaClassificacaoProdutos(string strClassificacao,string strDenominacao,ref System.Collections.ArrayList arlProdutosFatura);
			public delegate bool delCallShowDialogClassificacao();
			public delegate bool delCallShowDialogTecSiscobras();
			public delegate bool delCallSalvaDados();
		#endregion 
		#region Events
			public event delCallCarregaCaption eCallCarregaCaption;
			public event delCallCarregaDadosClassificacao eCallCarregaDadosClassificacao;
			public event delCallCarregaConfiguracao eCallCarregaConfiguracao;
			public event delCallSalvaConfiguracao eCallSalvaConfiguracao;
			public event delCallRefreshClassificacao eCallRefreshClassificacao;
			public event delCallRefreshProdutos eCallRefreshProdutos;
			public event delCallAssociaClassificacaoProdutos eCallAssociaClassificacaoProdutos;
			public event delCallShowDialogClassificacao eCallShowDialogClassificacao;
			public event delCallShowDialogTecSiscobras eCallShowDialogTecSiscobras;
			public event delCallSalvaDados eCallSalvaDados;
		#endregion 
		#region Events Methods
			protected virtual void OnCallCarregaCaption()
			{
				if (eCallCarregaCaption != null)
				{
					string strCaption;
					eCallCarregaCaption(out strCaption);
					m_gbClassificacao.Text = strCaption;
				}
			}

			protected virtual bool OnCallCarregaDadosClassificacao()
			{
				bool bRetorno = false;
				if (eCallCarregaDadosClassificacao != null)
					bRetorno = eCallCarregaDadosClassificacao();
				return(bRetorno);
			}

			protected virtual void OnCallCarregaConfiguracao()
			{
				if (eCallCarregaConfiguracao != null)
				{
					m_bEnabled = false;
					bool bMostrarProdutosAssociados;
					eCallCarregaConfiguracao(out bMostrarProdutosAssociados);
					m_ckMostrarProdutosVinculados.Checked = bMostrarProdutosAssociados;
					m_bEnabled = true;
				}
			}

			protected virtual void OnCallSalvaConfiguracao()
			{
				if (eCallSalvaConfiguracao != null)
					eCallSalvaConfiguracao(m_ckMostrarProdutosVinculados.Checked);
			}

			protected virtual void OnCallRefreshClassificacao()
			{
				if (eCallRefreshClassificacao != null)
					eCallRefreshClassificacao(ref m_lvClassificacao);
			}

			protected virtual void OnCallRefreshProdutos()
			{
				if (eCallRefreshProdutos != null)
					eCallRefreshProdutos(ref m_lvProdutos);
			}

			protected virtual bool OnCallAssociaClassificacaoProdutos()
			{
				bool bRetorno = false;
				if (eCallAssociaClassificacaoProdutos != null)
				{
					if ((m_lvClassificacao.SelectedItems.Count > 0) && (m_lvProdutos.SelectedItems.Count > 0))
					{
						System.Collections.ArrayList arlProdutosFatura = new ArrayList();
						foreach(System.Windows.Forms.ListViewItem lviProdutoFatura in m_lvProdutos.SelectedItems)
							arlProdutosFatura.Add(Int32.Parse(lviProdutoFatura.Tag.ToString()));
						bRetorno = eCallAssociaClassificacaoProdutos(m_lvClassificacao.SelectedItems[0].Text,m_lvClassificacao.SelectedItems[0].SubItems[1].Text,ref arlProdutosFatura);
					}
				}
				return(bRetorno);
			}

			protected virtual bool OnCallShowDialogClassificacao()
			{
				bool bRetorno = false;
				if (eCallShowDialogClassificacao != null)
					bRetorno = eCallShowDialogClassificacao();
				vBalloonTipComoVincular();
				return(bRetorno);
			}

			protected virtual bool OnCallShowDialogTecSiscobras()
			{
				if (eCallShowDialogTecSiscobras == null)
					return(false);
				return(eCallShowDialogTecSiscobras());
			}

			protected virtual bool OnCallSalvaDados()
			{
				bool bRetorno = false;
				if (eCallSalvaDados != null)
					bRetorno = eCallSalvaDados();
				return(bRetorno);
			}
		#endregion 

		#region Atributes
			private string m_strEnderecoExecutavel = "";

			private bool m_bEnabled = true;

			private bool m_bBalloonTipComoVincular = false;
			public bool m_bModificado = false;

			private System.Windows.Forms.GroupBox m_gbGeral;
			private System.Windows.Forms.Button m_btOk;
			private System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.GroupBox m_gbClassificacao;
			private System.Windows.Forms.GroupBox m_gbProdutos;
			private System.Windows.Forms.ListView m_lvClassificacao;
			private System.Windows.Forms.ListView m_lvProdutos;
			private System.Windows.Forms.ColumnHeader m_colhDescricao;
			private System.Windows.Forms.ColumnHeader m_colhClassificacao;
			private System.Windows.Forms.ColumnHeader m_colhDenominacao;
			private System.Windows.Forms.Button m_btEditar;
			private System.Windows.Forms.ToolTip m_ttDicas;
		private System.Windows.Forms.CheckBox m_ckMostrarProdutosVinculados;
		private System.Windows.Forms.Button m_btTecSiscobras;
		private System.Windows.Forms.ImageList m_ilIcones;
			private System.ComponentModel.IContainer components;
		#endregion
		#region Constructors and Destructors
			public frmFProdutosVincular(string strEnderecoExecutavel)
			{
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				InitializeComponent();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFProdutosVincular));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_gbProdutos = new System.Windows.Forms.GroupBox();
			this.m_ckMostrarProdutosVinculados = new System.Windows.Forms.CheckBox();
			this.m_lvProdutos = new System.Windows.Forms.ListView();
			this.m_colhDescricao = new System.Windows.Forms.ColumnHeader();
			this.m_gbClassificacao = new System.Windows.Forms.GroupBox();
			this.m_btEditar = new System.Windows.Forms.Button();
			this.m_lvClassificacao = new System.Windows.Forms.ListView();
			this.m_colhClassificacao = new System.Windows.Forms.ColumnHeader();
			this.m_colhDenominacao = new System.Windows.Forms.ColumnHeader();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_ttDicas = new System.Windows.Forms.ToolTip(this.components);
			this.m_btTecSiscobras = new System.Windows.Forms.Button();
			this.m_ilIcones = new System.Windows.Forms.ImageList(this.components);
			this.m_gbGeral.SuspendLayout();
			this.m_gbProdutos.SuspendLayout();
			this.m_gbClassificacao.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Controls.Add(this.m_gbProdutos);
			this.m_gbGeral.Controls.Add(this.m_gbClassificacao);
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbGeral.Location = new System.Drawing.Point(4, -1);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(484, 465);
			this.m_gbGeral.TabIndex = 0;
			this.m_gbGeral.TabStop = false;
			// 
			// m_gbProdutos
			// 
			this.m_gbProdutos.Controls.Add(this.m_ckMostrarProdutosVinculados);
			this.m_gbProdutos.Controls.Add(this.m_lvProdutos);
			this.m_gbProdutos.Location = new System.Drawing.Point(7, 8);
			this.m_gbProdutos.Name = "m_gbProdutos";
			this.m_gbProdutos.Size = new System.Drawing.Size(473, 248);
			this.m_gbProdutos.TabIndex = 15;
			this.m_gbProdutos.TabStop = false;
			this.m_gbProdutos.Text = "Produtos ";
			// 
			// m_ckMostrarProdutosVinculados
			// 
			this.m_ckMostrarProdutosVinculados.Location = new System.Drawing.Point(8, 226);
			this.m_ckMostrarProdutosVinculados.Name = "m_ckMostrarProdutosVinculados";
			this.m_ckMostrarProdutosVinculados.Size = new System.Drawing.Size(391, 16);
			this.m_ckMostrarProdutosVinculados.TabIndex = 1;
			this.m_ckMostrarProdutosVinculados.Text = "Mostrar somente produtos sem vínculo.";
			this.m_ckMostrarProdutosVinculados.CheckedChanged += new System.EventHandler(this.m_ckMostrarProdutosVinculados_CheckedChanged);
			// 
			// m_lvProdutos
			// 
			this.m_lvProdutos.AllowDrop = true;
			this.m_lvProdutos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lvProdutos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						   this.m_colhDescricao});
			this.m_lvProdutos.HideSelection = false;
			this.m_lvProdutos.Location = new System.Drawing.Point(8, 14);
			this.m_lvProdutos.Name = "m_lvProdutos";
			this.m_lvProdutos.Size = new System.Drawing.Size(457, 210);
			this.m_lvProdutos.TabIndex = 0;
			this.m_lvProdutos.View = System.Windows.Forms.View.Details;
			this.m_lvProdutos.DragOver += new System.Windows.Forms.DragEventHandler(this.m_lvProdutos_DragOver);
			this.m_lvProdutos.DragDrop += new System.Windows.Forms.DragEventHandler(this.m_lvProdutos_DragDrop);
			// 
			// m_colhDescricao
			// 
			this.m_colhDescricao.Text = "Descricao";
			this.m_colhDescricao.Width = 452;
			// 
			// m_gbClassificacao
			// 
			this.m_gbClassificacao.Controls.Add(this.m_btTecSiscobras);
			this.m_gbClassificacao.Controls.Add(this.m_btEditar);
			this.m_gbClassificacao.Controls.Add(this.m_lvClassificacao);
			this.m_gbClassificacao.Location = new System.Drawing.Point(6, 256);
			this.m_gbClassificacao.Name = "m_gbClassificacao";
			this.m_gbClassificacao.Size = new System.Drawing.Size(474, 169);
			this.m_gbClassificacao.TabIndex = 14;
			this.m_gbClassificacao.TabStop = false;
			this.m_gbClassificacao.Text = "Ncm/Naladi";
			// 
			// m_btEditar
			// 
			this.m_btEditar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btEditar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btEditar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btEditar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btEditar.Image = ((System.Drawing.Image)(resources.GetObject("m_btEditar.Image")));
			this.m_btEditar.Location = new System.Drawing.Point(239, 11);
			this.m_btEditar.Name = "m_btEditar";
			this.m_btEditar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btEditar.Size = new System.Drawing.Size(25, 25);
			this.m_btEditar.TabIndex = 9;
			this.m_btEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDicas.SetToolTip(this.m_btEditar, "Clique aqui para modificar as classificações tarifárias existentes.");
			this.m_btEditar.Click += new System.EventHandler(this.m_btEditar_Click);
			// 
			// m_lvClassificacao
			// 
			this.m_lvClassificacao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lvClassificacao.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																								this.m_colhClassificacao,
																								this.m_colhDenominacao});
			this.m_lvClassificacao.FullRowSelect = true;
			this.m_lvClassificacao.HideSelection = false;
			this.m_lvClassificacao.Location = new System.Drawing.Point(8, 40);
			this.m_lvClassificacao.MultiSelect = false;
			this.m_lvClassificacao.Name = "m_lvClassificacao";
			this.m_lvClassificacao.Size = new System.Drawing.Size(457, 120);
			this.m_lvClassificacao.TabIndex = 0;
			this.m_lvClassificacao.View = System.Windows.Forms.View.Details;
			this.m_lvClassificacao.DoubleClick += new System.EventHandler(this.m_lvClassificacao_DoubleClick);
			this.m_lvClassificacao.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.m_lvClassificacao_ItemDrag);
			// 
			// m_colhClassificacao
			// 
			this.m_colhClassificacao.Text = "Classificacao";
			this.m_colhClassificacao.Width = 85;
			// 
			// m_colhDenominacao
			// 
			this.m_colhDenominacao.Text = "Denominacao";
			this.m_colhDenominacao.Width = 367;
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(182, 434);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 12;
			this.m_ttDicas.SetToolTip(this.m_btOk, "Confirmar");
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(246, 434);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 13;
			this.m_ttDicas.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_ttDicas
			// 
			this.m_ttDicas.AutomaticDelay = 100;
			this.m_ttDicas.AutoPopDelay = 5000;
			this.m_ttDicas.InitialDelay = 100;
			this.m_ttDicas.ReshowDelay = 20;
			// 
			// m_btTecSiscobras
			// 
			this.m_btTecSiscobras.BackColor = System.Drawing.SystemColors.Control;
			this.m_btTecSiscobras.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btTecSiscobras.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btTecSiscobras.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btTecSiscobras.ImageIndex = 0;
			this.m_btTecSiscobras.ImageList = this.m_ilIcones;
			this.m_btTecSiscobras.Location = new System.Drawing.Point(207, 11);
			this.m_btTecSiscobras.Name = "m_btTecSiscobras";
			this.m_btTecSiscobras.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btTecSiscobras.Size = new System.Drawing.Size(25, 25);
			this.m_btTecSiscobras.TabIndex = 10;
			this.m_btTecSiscobras.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDicas.SetToolTip(this.m_btTecSiscobras, "Tec Siscobras");
			this.m_btTecSiscobras.Click += new System.EventHandler(this.m_btTecSiscobras_Click);
			// 
			// m_ilIcones
			// 
			this.m_ilIcones.ImageSize = new System.Drawing.Size(16, 16);
			this.m_ilIcones.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_ilIcones.ImageStream")));
			this.m_ilIcones.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// frmFProdutosVincular
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(492, 466);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFProdutosVincular";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Produtos fatura comercial sem vinculos";
			this.Load += new System.EventHandler(this.frmFProdutosVincular_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbProdutos.ResumeLayout(false);
			this.m_gbClassificacao.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFProdutosVincular_Load(object sender, System.EventArgs e)
				{
					OnCallCarregaCaption();
					OnCallRefreshClassificacao();
					OnCallCarregaConfiguracao();
					OnCallRefreshProdutos();
					vMostraCor();
					vBalloonTipInicial();
				}
			#endregion
			#region CheckBoxes
				private void m_ckMostrarProdutosVinculados_CheckedChanged(object sender, System.EventArgs e)
				{
					if (m_bEnabled)
					{
						OnCallSalvaConfiguracao();
						OnCallRefreshProdutos();
					}
				}
			#endregion
			#region lvClassificacao
		private void m_lvClassificacao_ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
		{
			m_lvClassificacao.DoDragDrop(m_lvClassificacao,System.Windows.Forms.DragDropEffects.Copy);
		}

		private void m_lvClassificacao_DoubleClick(object sender, System.EventArgs e)
		{
			if (OnCallShowDialogClassificacao())
			{
				OnCallCarregaDadosClassificacao();
				OnCallRefreshClassificacao();
			}
		}
		#endregion
			#region lvProdutos
		private void m_lvProdutos_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
		{
			System.Windows.Forms.ListViewItem lviItemMouse;
			System.Drawing.Point ptMouse = m_lvProdutos.PointToClient(new System.Drawing.Point(e.X,e.Y));
			lviItemMouse = m_lvProdutos.GetItemAt(ptMouse.X,ptMouse.Y);
			if (lviItemMouse != null)
				e.Effect = System.Windows.Forms.DragDropEffects.Copy;
			else
				e.Effect = System.Windows.Forms.DragDropEffects.None;
		}

		private void m_lvProdutos_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			if (e.Effect == System.Windows.Forms.DragDropEffects.Copy)
			{
				System.Windows.Forms.ListViewItem lviItemMouse;
				System.Drawing.Point ptMouse = m_lvProdutos.PointToClient(new System.Drawing.Point(e.X,e.Y));
				lviItemMouse = m_lvProdutos.GetItemAt(ptMouse.X,ptMouse.Y);
				if (lviItemMouse != null)
					lviItemMouse.Selected = true;
				if (OnCallAssociaClassificacaoProdutos())
					OnCallRefreshProdutos();
				vBalloonTipAposVincular();
			}
		}
		#endregion
			#region Botoes
			private void m_btEditar_Click(object sender, System.EventArgs e)
			{
				if (OnCallShowDialogClassificacao())
				{
					OnCallCarregaDadosClassificacao();
					OnCallRefreshClassificacao();
				}
			}

			private void m_btTecSiscobras_Click(object sender, System.EventArgs e)
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (OnCallShowDialogTecSiscobras())
					OnCallRefreshClassificacao();
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			private void m_btOk_Click(object sender, System.EventArgs e)
			{
				if (m_bModificado = OnCallSalvaDados())
					this.Close();
			}

			private void m_btCancelar_Click(object sender, System.EventArgs e)
			{
				this.Close();
			}
		#endregion
		#endregion

		#region Cores
		private void vMostraCor()
		{
			mdlPaletaDeCores.clsPaletaDeCores clsPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini","SiscobrasCorSecundaria");
			this.BackColor = clsPaletaCores.retornaCorAtual();
			System.Windows.Forms.Control ctrControleChild;
			for (int nCont = 0 ;nCont < this.Controls.Count; nCont++)
			{
				ctrControleChild = this.Controls[nCont];
				vPaintControl(ref ctrControleChild,this.BackColor);
			}
		}

		private void vPaintControl(ref System.Windows.Forms.Control ctrControle,System.Drawing.Color clrBackColor)
		{
			switch(ctrControle.GetType().ToString())
			{
				case "mdlComponentesGraficos.ListView":
				case "mdlComponentesGraficos.ComboBox":
				case "mdlComponentesGraficos.TextBox":
				case "System.Windows.Forms.ListView":
					break;
				default:
					ctrControle.BackColor = clrBackColor;
					break;
			}
			System.Windows.Forms.Control ctrControleChild;
			for (int nCont = 0 ;nCont < ctrControle.Controls.Count; nCont++)
			{
				ctrControleChild = ctrControle.Controls[nCont];
				vPaintControl(ref ctrControleChild,clrBackColor);
			}
		}
		#endregion
		#region BalloonTip
		private void  vBalloonTipInicial()
		{
			if (m_lvClassificacao.Items.Count == 0)
			{
				vBalloonTipCriarClassificacaoTarifaria();
			}
			else
			{
				vBalloonTipComoVincular();
			}
		}

		private void vBalloonTipCriarClassificacaoTarifaria()
		{
			mdlManipuladorArquivo.clsManipuladorArquivoIni cls_iniFile = new mdlManipuladorArquivo.clsManipuladorArquivoIni(m_strEnderecoExecutavel + "sisco.ini");
			if (cls_iniFile.retornaValor(mdlConstantes.clsConstantes.SHOW_BALLOONTIP_SESSAO,mdlConstantes.clsConstantes.SHOW_BALLOONTIP_VARIAVEL,true))
			{
				mdlComponentesGraficos.MessageBalloon mb = new mdlComponentesGraficos.MessageBalloon();
				mb.Caption = mdlConstantes.clsConstantes.BALLONTIP_DEFAULT_CAPTION;
				//mb.Content = mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.BALLOONTIP_mdlProdutosBordero_frmFProdutosBordero_CrieUmContratoCambio);
				mb.Content = "A primeira coisa a se fazer aqui é criar uma classificação tarifária." + System.Environment.NewLine + "Clique aqui para criar uma classificação tarifária.";
				mb.Icon = System.Drawing.SystemIcons.Information;
				mb.CloseOnMouseClick = true;
				mb.CloseOnDeactivate = true;
				mb.CloseOnKeyPress = true;
				mb.ShowBalloon((System.Windows.Forms.Control)m_btEditar);
			}
		}

		private void  vBalloonTipComoVincular()
		{
			if (!m_bBalloonTipComoVincular)
			{
				mdlManipuladorArquivo.clsManipuladorArquivoIni cls_iniFile = new mdlManipuladorArquivo.clsManipuladorArquivoIni(m_strEnderecoExecutavel + "sisco.ini");
				if (cls_iniFile.retornaValor(mdlConstantes.clsConstantes.SHOW_BALLOONTIP_SESSAO,mdlConstantes.clsConstantes.SHOW_BALLOONTIP_VARIAVEL,true))
				{
					mdlComponentesGraficos.MessageBalloon mb = new mdlComponentesGraficos.MessageBalloon();
					mb.Caption = mdlConstantes.clsConstantes.BALLONTIP_DEFAULT_CAPTION;
					//mb.Content = mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.BALLOONTIP_mdlProdutosBordero_frmFProdutosBordero_CrieUmContratoCambio);
					mb.Content = "É hora de vincular as classificações tarifárias aos produtos." + System.Environment.NewLine + "Para vincular a classificação tarifária basta clicar com o mouse sobre a mesma," + System.Environment.NewLine + "arrastá-la sobre o produto desejado e soltar o botão do mouse";
					mb.Icon = System.Drawing.SystemIcons.Information;
					mb.CloseOnMouseClick = true;
					mb.CloseOnDeactivate = true;
					mb.CloseOnKeyPress = true;
					mb.ShowBalloon((System.Windows.Forms.Control)m_lvClassificacao);
				}
				m_bBalloonTipComoVincular = true;
			}
		}

		private void  vBalloonTipAposVincular()
		{
			mdlManipuladorArquivo.clsManipuladorArquivoIni cls_iniFile = new mdlManipuladorArquivo.clsManipuladorArquivoIni(m_strEnderecoExecutavel + "sisco.ini");
			if (cls_iniFile.retornaValor(mdlConstantes.clsConstantes.SHOW_BALLOONTIP_SESSAO,mdlConstantes.clsConstantes.SHOW_BALLOONTIP_VARIAVEL,true))
			{
				mdlComponentesGraficos.MessageBalloon mb = new mdlComponentesGraficos.MessageBalloon();
				mb.Caption = mdlConstantes.clsConstantes.BALLONTIP_DEFAULT_CAPTION;
				//mb.Content = mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.BALLOONTIP_mdlProdutosBordero_frmFProdutosBordero_CrieUmContratoCambio);
				mb.Content = "Após vincular todos os produtos sem classificação tarifária basta clicar aqui.";
				mb.Icon = System.Drawing.SystemIcons.Information;
				mb.CloseOnMouseClick = true;
				mb.CloseOnDeactivate = true;
				mb.CloseOnKeyPress = true;
				mb.ShowBalloon((System.Windows.Forms.Control)m_btOk);
			}
		}
		#endregion

	}
}
