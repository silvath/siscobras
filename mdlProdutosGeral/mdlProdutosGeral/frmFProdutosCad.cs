using System;
using System.Collections;

namespace mdlProdutosGeral
{
	/// <summary>
	/// Summary description for frmFProdutosCad.
	/// </summary>
	internal class frmFProdutosCad : mdlComponentesGraficos.FormFlutuante
	{
		#region Atributos
			// ***************************************************************************************************
			// Atributos
			// ***************************************************************************************************
			private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
			private string m_strEnderecoExecutavel = "";
		    public bool m_bModificado =	false; 
		    private bool m_bCadatro = false;
			private bool m_bAtivado = true;

			private mdlDataBaseAccess.Tabelas.XsdTbProdutos m_typDatSetTbProdutos = null;
			private mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas m_typDatSetTbProdutosIdiomas = null;

			private string m_strTextoDefaultDescricao = "";
			private string m_strTextoDefaultDescricaoLinguaEstrangeira = "";
		    private int m_nIdProdutoEditando = -1;
			private int m_nIdExportador = -1;

			private frmFListaProdutos m_formFListaProdutos = null;

			private int m_nIdioma;
			private string m_strIdioma;
			private int m_nIdCategoria;
			private bool m_bMostrarCodigo;
		    private bool m_bMostrarLinguaEstrangeira;
		    private System.Collections.ArrayList m_arlProdutos;
		    private System.Collections.ArrayList m_arlProdutosInserir;
			private System.Collections.ArrayList m_arlProdutosLinguaEstrangeiraInserir;
		    private System.Collections.ArrayList m_arlProdutosEditar;
			private System.ComponentModel.IContainer components;
			private System.Windows.Forms.GroupBox m_gbGeral;
		private System.Windows.Forms.Button m_btOk;
		private System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.ContextMenu m_cmProduto;
			private System.Windows.Forms.MenuItem m_miProdutosExcluir;
			private System.Windows.Forms.GroupBox m_gbFields;
			private System.Windows.Forms.Label m_lbCodigo;
			private System.Windows.Forms.Label m_lbLinguaEstrangeira;
			private System.Windows.Forms.Label m_lbPortugues;
			private System.Windows.Forms.PictureBox m_picLinguaEstrangeira;
			private System.Windows.Forms.PictureBox m_picBandeiraBrasil;
			private System.Windows.Forms.GroupBox m_gbListaProdutos;
			private System.Windows.Forms.ListView m_lvProdutos;
			private mdlComponentesGraficos.TextBox m_tbCodigo;
			private mdlComponentesGraficos.TextBox m_tbPortugues;
			private mdlComponentesGraficos.TextBox m_tbEstrangeira;
			private System.Windows.Forms.Button m_btTrocarCor;
			private mdlComponentesGraficos.Button m_btDescricao;
			private System.Windows.Forms.ToolTip m_ttProdutosCad;
		    private System.Drawing.Image m_imgIdioma;
			// ***************************************************************************************************
		#endregion
		#region Construtores e Destrutores
			/// <summary>
			/// Constructor utilizado para quando for Cadastro
			/// </summary>
			/// <param name="CorFundo"></param>
			/// <param name="nIdioma"></param>
			/// <param name="strIdioma"></param>
			/// <param name="imgIdioma"></param>
			public frmFProdutosCad(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, string enderecoExecutavel, int nIdExportador,int nIdioma,string strIdioma, int nCategoria, System.Drawing.Image imgIdioma,bool bMostrarCodigo,ref System.Collections.ArrayList arlProdutos, ref mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetTbProdutos, ref mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas typDatSetTbProdutosIdiomas)
			{
				m_cls_ter_tratadorErro = tratadorErro;
				m_strEnderecoExecutavel = enderecoExecutavel;
				m_nIdioma = nIdioma;
				m_strIdioma = strIdioma;
				m_nIdCategoria = nCategoria;
				m_imgIdioma = imgIdioma;
				m_bMostrarCodigo = bMostrarCodigo;
				m_typDatSetTbProdutos = (mdlDataBaseAccess.Tabelas.XsdTbProdutos)typDatSetTbProdutos.Copy();
				m_typDatSetTbProdutosIdiomas = (mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas)typDatSetTbProdutosIdiomas.Copy();
				m_nIdExportador = nIdExportador;

				m_arlProdutos = arlProdutos;
				m_arlProdutosInserir = new System.Collections.ArrayList();
				m_arlProdutosLinguaEstrangeiraInserir = new System.Collections.ArrayList();

				InitializeComponent();
				m_lvProdutos.BackColor = this.BackColor;
				if (!m_bMostrarCodigo)
				{
					m_lbCodigo.Visible = false;
					m_tbCodigo.Visible = false;
				}

				if (m_nIdioma == 1)
				{
					// Portugues como Lingua Estrangeira 
					m_picLinguaEstrangeira.Visible = false;
					m_lbLinguaEstrangeira.Visible = false;
					m_tbEstrangeira.Visible = false;
					m_bMostrarLinguaEstrangeira = false;
				}else{
					// Lingua Estrangeira existente 
					m_picLinguaEstrangeira.Image = imgIdioma;
					m_lbLinguaEstrangeira.Text = strIdioma;
					m_bMostrarLinguaEstrangeira = true;
				}
				RefreshInterfaceGraficaListViewProdutos();
				m_bCadatro = true;
				m_tbCodigo.Text = strRetornaProximoCodigoUtilizar();
				m_strTextoDefaultDescricao = "Digite aqui a descrição e pressione <Enter>";
				m_strTextoDefaultDescricaoLinguaEstrangeira = "Digite aqui a descrição em " + m_strIdioma + " e pressione <Enter>";
				RefreshTextBoxesDescricao();
			}

			/// <summary>
			/// Constructor utilizado para quando for Edição
			/// </summary>
			/// <param name="CorFundo"></param>
			/// <param name="nIdioma"></param>
			/// <param name="strIdioma"></param>
			/// <param name="imgIdioma"></param>
			/// <param name="bMostrarCodigo"></param>
			/// <param name="arlProdutos"></param>
			public frmFProdutosCad(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, string enderecoExecutavel, int nIdExportador,int nIdioma,string strIdioma, int nCategoria,System.Drawing.Image imgIdioma,bool bMostrarCodigo,bool bEditar,ref System.Collections.ArrayList arlProdutos,ref System.Collections.ArrayList arlProdutosEdicao, ref mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetTbProdutos, ref mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas typDatSetTbProdutosIdiomas)
			{
				m_cls_ter_tratadorErro = tratadorErro;
				m_strEnderecoExecutavel = enderecoExecutavel;
				m_nIdioma = nIdioma;
				m_strIdioma = strIdioma;
				m_nIdCategoria = nCategoria;
				m_imgIdioma = imgIdioma;
				m_bMostrarCodigo = bMostrarCodigo;
				m_typDatSetTbProdutos = (mdlDataBaseAccess.Tabelas.XsdTbProdutos)typDatSetTbProdutos.Copy();
				m_typDatSetTbProdutosIdiomas = (mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas)typDatSetTbProdutosIdiomas.Copy();
				m_nIdExportador = nIdExportador;

				m_arlProdutos = arlProdutos;
				m_arlProdutosEditar = arlProdutosEdicao;
				
				InitializeComponent();
				this.Text = "Edição de Produtos";
				if (!m_bMostrarCodigo)
				{
					m_lbCodigo.Visible = false;
					m_tbCodigo.Visible = false;
				}

				if (m_nIdioma == 1)
				{
					// Portugues como Lingua Estrangeira 
					m_picLinguaEstrangeira.Visible = false;
					m_lbLinguaEstrangeira.Visible = false;
					m_tbEstrangeira.Visible = false;
					m_bMostrarLinguaEstrangeira = false;
				}
				else
				{
					// Lingua Estrangeira existente 
					m_picLinguaEstrangeira.Image = imgIdioma;
					m_lbLinguaEstrangeira.Text = strIdioma;
					m_bMostrarLinguaEstrangeira = true;
				}
				RefreshInterfaceGraficaListViewProdutos();
				m_bCadatro = false;
				RefreshTextBoxesDescricao();
				RefreshLvProdutosComProdutosEditar();
				if (m_lvProdutos.Items.Count > 0) 
					m_lvProdutos.Items[0].Selected = true;	
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFProdutosCad));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_btTrocarCor = new System.Windows.Forms.Button();
			this.m_gbFields = new System.Windows.Forms.GroupBox();
			this.m_btDescricao = new mdlComponentesGraficos.Button();
			this.m_tbEstrangeira = new mdlComponentesGraficos.TextBox();
			this.m_tbPortugues = new mdlComponentesGraficos.TextBox();
			this.m_tbCodigo = new mdlComponentesGraficos.TextBox();
			this.m_lbCodigo = new System.Windows.Forms.Label();
			this.m_lbLinguaEstrangeira = new System.Windows.Forms.Label();
			this.m_lbPortugues = new System.Windows.Forms.Label();
			this.m_picLinguaEstrangeira = new System.Windows.Forms.PictureBox();
			this.m_picBandeiraBrasil = new System.Windows.Forms.PictureBox();
			this.m_gbListaProdutos = new System.Windows.Forms.GroupBox();
			this.m_lvProdutos = new System.Windows.Forms.ListView();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_cmProduto = new System.Windows.Forms.ContextMenu();
			this.m_miProdutosExcluir = new System.Windows.Forms.MenuItem();
			this.m_ttProdutosCad = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbGeral.SuspendLayout();
			this.m_gbFields.SuspendLayout();
			this.m_gbListaProdutos.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbGeral.Controls.Add(this.m_btTrocarCor);
			this.m_gbGeral.Controls.Add(this.m_gbFields);
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Location = new System.Drawing.Point(2, 0);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(740, 238);
			this.m_gbGeral.TabIndex = 0;
			this.m_gbGeral.TabStop = false;
			// 
			// m_btTrocarCor
			// 
			this.m_btTrocarCor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.m_btTrocarCor.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_btTrocarCor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btTrocarCor.Location = new System.Drawing.Point(3, 8);
			this.m_btTrocarCor.Name = "m_btTrocarCor";
			this.m_btTrocarCor.Size = new System.Drawing.Size(4, 4);
			this.m_btTrocarCor.TabIndex = 3;
			this.m_ttProdutosCad.SetToolTip(this.m_btTrocarCor, "Cor");
			this.m_btTrocarCor.Click += new System.EventHandler(this.m_btTrocarCor_Click);
			// 
			// m_gbFields
			// 
			this.m_gbFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFields.Controls.Add(this.m_btDescricao);
			this.m_gbFields.Controls.Add(this.m_tbEstrangeira);
			this.m_gbFields.Controls.Add(this.m_tbPortugues);
			this.m_gbFields.Controls.Add(this.m_tbCodigo);
			this.m_gbFields.Controls.Add(this.m_lbCodigo);
			this.m_gbFields.Controls.Add(this.m_lbLinguaEstrangeira);
			this.m_gbFields.Controls.Add(this.m_lbPortugues);
			this.m_gbFields.Controls.Add(this.m_picLinguaEstrangeira);
			this.m_gbFields.Controls.Add(this.m_picBandeiraBrasil);
			this.m_gbFields.Controls.Add(this.m_gbListaProdutos);
			this.m_gbFields.Location = new System.Drawing.Point(8, 8);
			this.m_gbFields.Name = "m_gbFields";
			this.m_gbFields.Size = new System.Drawing.Size(723, 194);
			this.m_gbFields.TabIndex = 0;
			this.m_gbFields.TabStop = false;
			// 
			// m_btDescricao
			// 
			this.m_btDescricao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_btDescricao.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btDescricao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_btDescricao.GradiendColorEnd = System.Drawing.Color.Black;
			this.m_btDescricao.GradiendColorStart = System.Drawing.Color.White;
			this.m_btDescricao.Image = ((System.Drawing.Image)(resources.GetObject("m_btDescricao.Image")));
			this.m_btDescricao.Location = new System.Drawing.Point(690, 114);
			this.m_btDescricao.Name = "m_btDescricao";
			this.m_btDescricao.Size = new System.Drawing.Size(25, 25);
			this.m_btDescricao.TabIndex = 5;
			this.m_ttProdutosCad.SetToolTip(this.m_btDescricao, "Copiar Texto Similar de Outro Produto");
			this.m_btDescricao.Click += new System.EventHandler(this.m_btDescricao_Click);
			// 
			// m_tbEstrangeira
			// 
			this.m_tbEstrangeira.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_tbEstrangeira.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbEstrangeira.Location = new System.Drawing.Point(116, 167);
			this.m_tbEstrangeira.Name = "m_tbEstrangeira";
			this.m_tbEstrangeira.Size = new System.Drawing.Size(599, 20);
			this.m_tbEstrangeira.TabIndex = 4;
			this.m_tbEstrangeira.Text = "";
			this.m_ttProdutosCad.SetToolTip(this.m_tbEstrangeira, "Digite aqui a descrição do produto e tecle <Enter>");
			this.m_tbEstrangeira.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_tbEstrangeira_KeyDown);
			this.m_tbEstrangeira.KeyUp += new System.Windows.Forms.KeyEventHandler(this.m_tbLinguaEstrangeira_KeyUp);
			this.m_tbEstrangeira.Enter += new System.EventHandler(this.m_tbEstrangeira_Enter);
			// 
			// m_tbPortugues
			// 
			this.m_tbPortugues.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_tbPortugues.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbPortugues.Location = new System.Drawing.Point(116, 141);
			this.m_tbPortugues.Name = "m_tbPortugues";
			this.m_tbPortugues.Size = new System.Drawing.Size(599, 20);
			this.m_tbPortugues.TabIndex = 3;
			this.m_tbPortugues.Text = "";
			this.m_ttProdutosCad.SetToolTip(this.m_tbPortugues, "Digite aqui a descrição do produto e tecle <Enter>");
			this.m_tbPortugues.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_tbPortugues_KeyDown);
			this.m_tbPortugues.KeyUp += new System.Windows.Forms.KeyEventHandler(this.m_tbPortugues_KeyUp);
			this.m_tbPortugues.Enter += new System.EventHandler(this.m_tbPortugues_Enter);
			// 
			// m_tbCodigo
			// 
			this.m_tbCodigo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.m_tbCodigo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbCodigo.Location = new System.Drawing.Point(116, 115);
			this.m_tbCodigo.Name = "m_tbCodigo";
			this.m_tbCodigo.Size = new System.Drawing.Size(252, 20);
			this.m_tbCodigo.TabIndex = 2;
			this.m_tbCodigo.Text = "";
			this.m_ttProdutosCad.SetToolTip(this.m_tbCodigo, "Còdigo do produto");
			this.m_tbCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_tbCodigo_KeyDown);
			this.m_tbCodigo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.m_tbCodigo_KeyUp);
			// 
			// m_lbCodigo
			// 
			this.m_lbCodigo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.m_lbCodigo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbCodigo.Location = new System.Drawing.Point(40, 119);
			this.m_lbCodigo.Name = "m_lbCodigo";
			this.m_lbCodigo.Size = new System.Drawing.Size(47, 16);
			this.m_lbCodigo.TabIndex = 0;
			this.m_lbCodigo.Text = "Código:";
			// 
			// m_lbLinguaEstrangeira
			// 
			this.m_lbLinguaEstrangeira.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.m_lbLinguaEstrangeira.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbLinguaEstrangeira.Location = new System.Drawing.Point(40, 169);
			this.m_lbLinguaEstrangeira.Name = "m_lbLinguaEstrangeira";
			this.m_lbLinguaEstrangeira.Size = new System.Drawing.Size(71, 16);
			this.m_lbLinguaEstrangeira.TabIndex = 0;
			this.m_lbLinguaEstrangeira.Text = "Estrangeira:";
			// 
			// m_lbPortugues
			// 
			this.m_lbPortugues.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.m_lbPortugues.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbPortugues.Location = new System.Drawing.Point(40, 143);
			this.m_lbPortugues.Name = "m_lbPortugues";
			this.m_lbPortugues.Size = new System.Drawing.Size(64, 16);
			this.m_lbPortugues.TabIndex = 0;
			this.m_lbPortugues.Text = "Português:";
			// 
			// m_picLinguaEstrangeira
			// 
			this.m_picLinguaEstrangeira.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.m_picLinguaEstrangeira.Image = ((System.Drawing.Image)(resources.GetObject("m_picLinguaEstrangeira.Image")));
			this.m_picLinguaEstrangeira.Location = new System.Drawing.Point(8, 164);
			this.m_picLinguaEstrangeira.Name = "m_picLinguaEstrangeira";
			this.m_picLinguaEstrangeira.Size = new System.Drawing.Size(24, 24);
			this.m_picLinguaEstrangeira.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.m_picLinguaEstrangeira.TabIndex = 82;
			this.m_picLinguaEstrangeira.TabStop = false;
			// 
			// m_picBandeiraBrasil
			// 
			this.m_picBandeiraBrasil.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.m_picBandeiraBrasil.Image = ((System.Drawing.Image)(resources.GetObject("m_picBandeiraBrasil.Image")));
			this.m_picBandeiraBrasil.Location = new System.Drawing.Point(8, 137);
			this.m_picBandeiraBrasil.Name = "m_picBandeiraBrasil";
			this.m_picBandeiraBrasil.Size = new System.Drawing.Size(24, 24);
			this.m_picBandeiraBrasil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.m_picBandeiraBrasil.TabIndex = 81;
			this.m_picBandeiraBrasil.TabStop = false;
			// 
			// m_gbListaProdutos
			// 
			this.m_gbListaProdutos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbListaProdutos.Controls.Add(this.m_lvProdutos);
			this.m_gbListaProdutos.Location = new System.Drawing.Point(8, 8);
			this.m_gbListaProdutos.Name = "m_gbListaProdutos";
			this.m_gbListaProdutos.Size = new System.Drawing.Size(707, 104);
			this.m_gbListaProdutos.TabIndex = 80;
			this.m_gbListaProdutos.TabStop = false;
			this.m_gbListaProdutos.Text = "Lista Produtos Inserir";
			// 
			// m_lvProdutos
			// 
			this.m_lvProdutos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lvProdutos.FullRowSelect = true;
			this.m_lvProdutos.HideSelection = false;
			this.m_lvProdutos.Location = new System.Drawing.Point(8, 16);
			this.m_lvProdutos.MultiSelect = false;
			this.m_lvProdutos.Name = "m_lvProdutos";
			this.m_lvProdutos.Size = new System.Drawing.Size(691, 80);
			this.m_lvProdutos.TabIndex = 1;
			this.m_lvProdutos.View = System.Windows.Forms.View.Details;
			this.m_lvProdutos.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_lvProdutos_MouseUp);
			this.m_lvProdutos.SelectedIndexChanged += new System.EventHandler(this.m_lvProdutos_SelectedIndexChanged);
			// 
			// m_btOk
			// 
			this.m_btOk.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(310, 207);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 1;
			this.m_ttProdutosCad.SetToolTip(this.m_btOk, "Confirmar");
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(374, 207);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 2;
			this.m_ttProdutosCad.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_cmProduto
			// 
			this.m_cmProduto.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						this.m_miProdutosExcluir});
			// 
			// m_miProdutosExcluir
			// 
			this.m_miProdutosExcluir.Index = 0;
			this.m_miProdutosExcluir.Text = "Excluir";
			this.m_miProdutosExcluir.Click += new System.EventHandler(this.m_miProdutosExcluir_Click);
			// 
			// m_ttProdutosCad
			// 
			this.m_ttProdutosCad.AutomaticDelay = 100;
			this.m_ttProdutosCad.AutoPopDelay = 5000;
			this.m_ttProdutosCad.InitialDelay = 100;
			this.m_ttProdutosCad.ReshowDelay = 20;
			// 
			// frmFProdutosCad
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(744, 240);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFProdutosCad";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Descrição dos Produtos";
			this.Load += new System.EventHandler(this.frmFProdutosCad_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbFields.ResumeLayout(false);
			this.m_gbListaProdutos.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		#region Eventos do Formulario
			private void m_lvProdutos_SelectedIndexChanged(object sender, System.EventArgs e)
			{
				if (!m_bCadatro)
				{
					if (m_lvProdutos.SelectedItems.Count > 0)
					{
						if (m_nIdProdutoEditando == -1)
						{
								m_nIdProdutoEditando = m_lvProdutos.SelectedItems[0].Index;
								RefreshTextBoxesComProdutoEditar(m_nIdProdutoEditando);
						}else{
							EditaProdutoListView(false);
							m_nIdProdutoEditando = m_lvProdutos.SelectedItems[0].Index;
							RefreshTextBoxesComProdutoEditar(m_nIdProdutoEditando);
						}
					}
				}			
			}

			private void m_tbCodigo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
			{
				if (m_bAtivado)
				{
					m_bAtivado = false;
					if (e.KeyCode == System.Windows.Forms.Keys.F2)
					{
						m_tbCodigo.Select(0,0);
					}
                				
//					if ((e.KeyCode == System.Windows.Forms.Keys.Tab) || (e.KeyCode == System.Windows.Forms.Keys.Enter))
//					{
//						m_tbPortugues.Focus();
//					}
					m_bAtivado = true;
				}
			}

			private void m_tbPortugues_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
			{
				if (m_bAtivado)
				{
					m_bAtivado = false;
					if (e.KeyCode == System.Windows.Forms.Keys.F2)
					{
						m_tbPortugues.Select(0,0);
					}
					if (!m_bMostrarLinguaEstrangeira)
					{
						if ((e.KeyCode == System.Windows.Forms.Keys.Tab) || (e.KeyCode == System.Windows.Forms.Keys.Enter))
						{
							if (m_bCadatro)
								InsereNovoProdutoListView();
							else
								EditaProdutoListView(true);
						}
					}
					else
					{
//						if (e.KeyCode == System.Windows.Forms.Keys.Enter)
//						{
//							if (m_bCadatro)
//								InsereNovoProdutoListView();
//							else
//								EditaProdutoListView(true);
//							m_tbEstrangeira.Focus();
//						}
					}
					m_bAtivado = true;
				}
			}

			private void m_tbEstrangeira_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
			{
				if (m_bAtivado)
				{
					m_bAtivado = false;
					if (e.KeyCode == System.Windows.Forms.Keys.F2)
					{
						m_tbEstrangeira.Select(0,0);
					}
					if ((e.KeyData == System.Windows.Forms.Keys.Tab) || (e.KeyData == System.Windows.Forms.Keys.Enter))
					{
						if (m_bCadatro)
							InsereNovoProdutoListView();
						else
							EditaProdutoListView(true);
						m_tbCodigo.Focus();
					}
					m_bAtivado = true;
				}
				}
			private void m_tbCodigo_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
			{
				
			}

			private void m_tbPortugues_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
			{
			}

			private void m_tbLinguaEstrangeira_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
			{
			}

			private void m_lvProdutos_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
			{
				if (m_bCadatro)
				{
					if (e.Button == System.Windows.Forms.MouseButtons.Right)
					{
						if (m_lvProdutos.SelectedItems.Count > 0 )
							m_miProdutosExcluir.Enabled = true;
						else
							m_miProdutosExcluir.Enabled = false;
						m_cmProduto.Show(m_lvProdutos,new System.Drawing.Point(e.X,e.Y));                			
					}
				}else{
					if (e.Button == System.Windows.Forms.MouseButtons.Left)
					{
						if (m_lvProdutos.SelectedItems.Count > 0)
						{
							if (m_bMostrarCodigo)
								m_tbCodigo.Focus();
							else
								m_tbPortugues.Focus();
						}
					}
				}
			}

			private void m_btOk_Click(object sender, System.EventArgs e)
			{
				if (m_bCadatro)
				{
					if (m_tbPortugues.Text != "")
					{
						InsereNovoProdutoListView();
					}
					if (m_tbPortugues.Text == "")
					{
						m_bModificado = true;
						this.Close();
					}
				}else{
					if (m_nIdProdutoEditando != -1)
					{
						EditaProdutoListView(false);
						if (m_tbPortugues.Text == "")
						{
							m_bModificado = true;
							this.Close();
						}
					}else{
						m_bModificado = true;
						this.Close();
					}
				}
			}
			private void m_btCancelar_Click(object sender, System.EventArgs e)
			{
				m_bModificado = false;
				this.Close();
			}
			private void m_btTrocarCor_Click(object sender, System.EventArgs e)
			{
				try
				{
					this.trocaCor();
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
			private void frmFProdutosCad_Load(object sender, System.EventArgs e)
			{
				try
				{
					this.mostraCor();
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
			private void m_tbPortugues_Enter(object sender, System.EventArgs e)
			{
				try
				{
					if (m_tbPortugues.Text == "Digite aqui a descrição e pressione <Enter>")
					{
						m_tbPortugues.Text = "";
						m_tbPortugues.SelectionStart = m_tbPortugues.Text.Length;
					}
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
			private void m_tbEstrangeira_Enter(object sender, System.EventArgs e)
			{
				try
				{
					if (m_tbEstrangeira.Text == "Digite aqui a descrição em " + m_strIdioma + " e pressione <Enter>")
					{
						m_tbEstrangeira.Text = "";
						m_tbEstrangeira.SelectionStart = m_tbEstrangeira.Text.Length;
					}
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
			private void m_btDescricao_Click(object sender, System.EventArgs e)
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				m_formFListaProdutos = new frmFListaProdutos(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel, m_nIdExportador, m_nIdioma, ref m_typDatSetTbProdutos, ref m_typDatSetTbProdutosIdiomas);
				m_formFListaProdutos.ShowDialog();
				string strDescricao, strIdioma;
				if (m_formFListaProdutos.m_bModificado)
				{
					m_formFListaProdutos.retornaValores(out strDescricao, out strIdioma);
					this.m_tbPortugues.Text = strDescricao;
					this.m_tbEstrangeira.Text = strIdioma;
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}
		#endregion
		#region Procedimentos Para Troca de Cor
		#region Trocar Cor
		/// <summary>
		/// Troca a cor do Formulario Controlado
		/// </summary>
		public void trocaCor()
		{
			try
			{
				mdlPaletaDeCores.clsPaletaDeCores controlPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini", "SiscobrasCorSecundaria");
				controlPaletaCores.mostraCorAtual();
				mostraCor();
			} 
			catch (Exception erro) 
			{
				Object err = (Object)erro;
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion
		#region Mostrar Cor
		/// <summary>
		/// Mostra a cor do Formulario Controlado
		/// </summary>
		public void mostraCor()
		{
			try
			{
				mdlPaletaDeCores.clsPaletaDeCores controlPaletaDeCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini", "SiscobrasCorSecundaria");
				this.BackColor = controlPaletaDeCores.retornaCorAtual();
				for (int cont = 0; cont < this.Controls.Count; cont++) 
				{
					this.Controls[cont].BackColor = this.BackColor;
					for (int cont2 = 0; cont2 < this.Controls[cont].Controls.Count; cont2++)
					{
						if ((this.Controls[cont].Controls[cont2].GetType().ToString() != "mdlComponentes.compTextBox") && (this.Controls[cont].Controls[cont2].GetType().ToString() != "mdlComponentes.compTextNumber"))
						{
							this.Controls[cont].Controls[cont2].BackColor = this.BackColor;
						}
						for (int cont3 = 0; cont3 < this.Controls[cont].Controls[cont2].Controls.Count; cont3++)
						{
							if ((this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"System.Windows.Forms.TextBox") &&
								(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.TextBox") &&
								(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.ComboBox"))
							{
								this.Controls[cont].Controls[cont2].Controls[cont3].BackColor = this.BackColor;
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
		#endregion
		#region Métodos do Formulário

			private void RefreshInterfaceGraficaListViewProdutos()
			{
                m_lvProdutos.Columns.Clear();
				if (m_bMostrarCodigo)
					m_lvProdutos.Columns.Add("Código",80,System.Windows.Forms.HorizontalAlignment.Left);
				if (m_bMostrarLinguaEstrangeira)
				{
					m_lvProdutos.Columns.Add("Portugues",250,System.Windows.Forms.HorizontalAlignment.Left);
					m_lvProdutos.Columns.Add(m_strIdioma,250,System.Windows.Forms.HorizontalAlignment.Left);
				}else{
					m_lvProdutos.Columns.Add("Portugues",500,System.Windows.Forms.HorizontalAlignment.Left);
				}
			}

			private void RefreshTextBoxesDescricao()
			{
				m_tbPortugues.Text = m_strTextoDefaultDescricao;
				m_tbEstrangeira.Text = m_strTextoDefaultDescricaoLinguaEstrangeira;
			}

		#endregion
		#region Métodos do Formulário Referentes ao Cadastro de Produtos
			/// <summary>
			/// Retorna o proximo Id a utilizar nos produtos
			/// </summary>
			/// <returns></returns>
			private int nRetornaProximoIdUtilizar()
			{
				int nProximoCodigo = 1;
				try
				{
					bool bCodigoExiste = true;
					mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwTbProdutos;
					mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas.tbProdutosIdiomasRow dtrwTbProdutosIdiomas;
					
					while (bCodigoExiste)
					{
						bCodigoExiste = false;
						// Verificando na lista de produtos gerais
						dtrwTbProdutos = m_typDatSetTbProdutos.tbProdutos.FindByidExportadoridProduto(m_nIdExportador, nProximoCodigo);
						if ((dtrwTbProdutos != null) && (dtrwTbProdutos.RowState != System.Data.DataRowState.Deleted))
							bCodigoExiste = nProximoCodigo == dtrwTbProdutos.idProduto;
						if (!bCodigoExiste)
						{
							// Verificando na lista de produtos idioma
							dtrwTbProdutosIdiomas = m_typDatSetTbProdutosIdiomas.tbProdutosIdiomas.FindByidExportadoridIdiomaidProduto(m_nIdExportador, m_nIdioma, nProximoCodigo);
                            if ((dtrwTbProdutosIdiomas != null) && (dtrwTbProdutosIdiomas.RowState != System.Data.DataRowState.Deleted))
								bCodigoExiste = nProximoCodigo == dtrwTbProdutosIdiomas.idProduto;
						}
						if (bCodigoExiste)
							nProximoCodigo++;
					}
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
				return (nProximoCodigo);
			}
           
			/// <summary>
			/// Retorna o proximo codigo a utilizar nos produtos
			/// </summary>
			/// <returns></returns>
			private string strRetornaProximoCodigoUtilizar()
			{
				int nProximoCodigo = 1;
				int nCodigoAtual;
				bool bCodigoExiste = true;
				try
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwTbProdutos;
					
					while (bCodigoExiste)
					{
						bCodigoExiste = false;
						// Verificando na lista de produtos gerais
						for(int nCont = 0; nCont < m_typDatSetTbProdutos.tbProdutos.Rows.Count;nCont++)
						{
							dtrwTbProdutos = (mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow)m_typDatSetTbProdutos.tbProdutos.Rows[nCont];
							if (dtrwTbProdutos.RowState != System.Data.DataRowState.Deleted)
							{
								try
								{
									try
									{
										nCodigoAtual = Int32.Parse(dtrwTbProdutos.mstrCodigoProduto);
									}
									catch
									{
										nCodigoAtual = 1;
									}
									bCodigoExiste = nProximoCodigo == nCodigoAtual;
									if (bCodigoExiste)
										break;
								}
								catch (Exception err)
								{
									Object erro = err;
									m_cls_ter_tratadorErro.trataErro(ref erro);
								}
							}
						}
						if (bCodigoExiste)
							nProximoCodigo++;
					}
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
				return (nProximoCodigo.ToString());
			}

			/// <summary>
			///  Verificando se o produto Descrito nas TextBoxes pode ser inserido 
			/// </summary>
			/// <returns></returns>
			private bool bProdutoJaInserido()
			{
				bool bRetorno = false;
				try
				{
					string strCodigoProduto = m_tbCodigo.Text;
					string strNomeProduto = m_tbPortugues.Text;                    
					mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwTbProdutos;
					
					// Verificando na lista de produtos gerais
					for(int nCont = 0; nCont < m_typDatSetTbProdutos.tbProdutos.Rows.Count;nCont++)
					{
						dtrwTbProdutos = (mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow)m_typDatSetTbProdutos.tbProdutos.Rows[nCont];
						if (dtrwTbProdutos.RowState != System.Data.DataRowState.Deleted)
						{
							if (strCodigoProduto == dtrwTbProdutos.mstrCodigoProduto)
							{
								mdlMensagens.clsMensagens.ShowInformation(this.Text, mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlProdutosGeral_frmFProdutosCad_CodigoDoProdutoDuplicado));
								//MessageBox.Show("O código do produto que você deseja inserir já existe!","Siscobras.NET",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
								m_tbCodigo.SelectAll();
								m_tbCodigo.Focus();
								bRetorno = true;
								break;
							}
							if (strNomeProduto == dtrwTbProdutos.mstrDescricao)
							{
								mdlMensagens.clsMensagens.ShowInformation(this.Text, mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlProdutosGeral_frmFProdutosCad_DescricaoDoProdutoDuplicada));
								//MessageBox.Show("A descrição do produto que você deseja inserir já existe!","Siscobras.NET",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
								m_tbCodigo.SelectAll();
								m_tbCodigo.Focus();
								bRetorno = true;
								break;
							}
						}
					}
					
					// Verificando na lista de produtos a Inserir 
					if (!bRetorno)
					{
						for(int nCont = 0; nCont < m_arlProdutosInserir.Count;nCont++)
						{
							dtrwTbProdutos = (mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow)m_arlProdutosInserir[nCont];
							if (strCodigoProduto == dtrwTbProdutos.mstrCodigoProduto)
							{
								mdlMensagens.clsMensagens.ShowInformation(this.Text, mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlProdutosGeral_frmFProdutosCad_CodigoDoProdutoDuplicado));
								//MessageBox.Show("O código do produto que você deseja inserir já existe!","Siscobras.NET",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
								m_tbCodigo.SelectAll();
								m_tbCodigo.Focus();
								bRetorno = true;
								break;
							}
							if (strNomeProduto == dtrwTbProdutos.mstrDescricao)
							{
								mdlMensagens.clsMensagens.ShowInformation(this.Text, mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlProdutosGeral_frmFProdutosCad_DescricaoDoProdutoDuplicada));
								//MessageBox.Show("A descrição do produto que você deseja inserir já existe!","Siscobras.NET",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
								m_tbPortugues.SelectAll();
								m_tbPortugues.Focus();
								bRetorno = true;
								break;
							}
						}
					}
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
				return(bRetorno);
			}

			private void InsereNovoProdutoListaProdutosInserir()
			{
				try
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwTbProdutos;
					mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas.tbProdutosIdiomasRow dtrwTbProdutosIdiomas;
					int nIdProduto;
					
					// Adquirindo o Proximo idUtilizar; 
					nIdProduto = nRetornaProximoIdUtilizar();
					#region Produto
					// Produto
					dtrwTbProdutos = m_typDatSetTbProdutos.tbProdutos.NewtbProdutosRow();
					dtrwTbProdutos.idProduto = nIdProduto;
					dtrwTbProdutos.mstrCodigoProduto = m_tbCodigo.Text;
					dtrwTbProdutos.mstrDescricao = m_tbPortugues.Text;
					dtrwTbProdutos.idExportador = m_nIdExportador;
					dtrwTbProdutos.idCategoria = m_nIdCategoria;
					dtrwTbProdutos.strNaladi = "";
					dtrwTbProdutos.strNcm = "";
					dtrwTbProdutos.bDetalharChilds = true;
					m_typDatSetTbProdutos.tbProdutos.AddtbProdutosRow(dtrwTbProdutos);
					m_arlProdutosInserir.Add(dtrwTbProdutos);
					#endregion
					
					#region Produto na Lingua Estrangeira
					// Produto na Lingua Estrangeira
					if (m_nIdioma != 1)
					{
						dtrwTbProdutosIdiomas = m_typDatSetTbProdutosIdiomas.tbProdutosIdiomas.NewtbProdutosIdiomasRow();
						dtrwTbProdutosIdiomas.idProduto = nIdProduto;
						dtrwTbProdutosIdiomas.mstrDescricao = m_tbEstrangeira.Text;
						dtrwTbProdutosIdiomas.idIdioma = m_nIdioma;
						dtrwTbProdutosIdiomas.idExportador = m_nIdExportador;
						m_typDatSetTbProdutosIdiomas.tbProdutosIdiomas.AddtbProdutosIdiomasRow(dtrwTbProdutosIdiomas);
						m_arlProdutosLinguaEstrangeiraInserir.Add(dtrwTbProdutosIdiomas);
					}
					#endregion
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
			    
			private void InsereNovoProdutoListView()
			{
				try
				{
					if (m_tbPortugues.Text.Trim() == m_strTextoDefaultDescricao)
						m_tbPortugues.Text = "";
					
					if (m_tbEstrangeira.Text.Trim() == m_strTextoDefaultDescricaoLinguaEstrangeira)
						m_tbEstrangeira.Text = "";
					
					if ((m_tbPortugues.Text.Trim() == "") && (m_tbEstrangeira.Text.Trim() == ""))
					{
						m_btOk.Focus();
					}
					else
					{
						if (!bProdutoJaInserido())
						{
							System.Windows.Forms.ListViewItem lviItem;
							if (m_bMostrarCodigo)
							{
								lviItem = m_lvProdutos.Items.Add(m_tbCodigo.Text);
								lviItem.SubItems.Add(m_tbPortugues.Text);
							}
							else
							{
								lviItem = m_lvProdutos.Items.Add(m_tbPortugues.Text);
							}
							if(m_bMostrarLinguaEstrangeira)
								lviItem.SubItems.Add(m_tbEstrangeira.Text);
							InsereNovoProdutoListaProdutosInserir();
							m_tbCodigo.Text = "";
							m_tbPortugues.Text = m_strTextoDefaultDescricao;
							m_tbEstrangeira.Text = m_strTextoDefaultDescricaoLinguaEstrangeira;
							m_tbCodigo.Text = strRetornaProximoCodigoUtilizar();
							if (m_bMostrarCodigo)
								m_tbCodigo.Focus();
							else
								m_tbPortugues.Focus();
						}
					}
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
			public void retornaValoresCadastro(out System.Collections.ArrayList arlProdutosInserir, out System.Collections.ArrayList arlProdutosLinguaEstrangeiraInserir)
			{
				arlProdutosInserir = m_arlProdutosInserir;
				arlProdutosLinguaEstrangeiraInserir = m_arlProdutosLinguaEstrangeiraInserir;
			}
		#endregion
		#region Métodos do Formulário Referentes a Edição de Produtos

			private void RefreshLvProdutosComProdutosEditar()
			{
				try
				{
					System.Windows.Forms.ListViewItem lviItem;
					mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwTbProdutos;
					mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas.tbProdutosIdiomasRow dtrwTbProdutosIdiomas;
					m_lvProdutos.Items.Clear();
					for (int nCont = 0 ; nCont < m_arlProdutosEditar.Count;nCont++)
					{
						if (m_typDatSetTbProdutos.tbProdutos.Rows.Count > 0)
						{
							dtrwTbProdutos = (mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow)m_arlProdutosEditar[nCont];
							if (dtrwTbProdutos.RowState != System.Data.DataRowState.Deleted)
							{
								if (m_bMostrarCodigo)
								{
									lviItem = m_lvProdutos.Items.Add(dtrwTbProdutos.mstrCodigoProduto);
									lviItem.SubItems.Add(dtrwTbProdutos.mstrDescricao);
								}
								else
								{
									lviItem = m_lvProdutos.Items.Add(dtrwTbProdutos.mstrDescricao);
								}						
								if (m_typDatSetTbProdutosIdiomas.tbProdutosIdiomas.Rows.Count > 0)
								{
									if (m_bMostrarLinguaEstrangeira)
									{
										dtrwTbProdutosIdiomas = m_typDatSetTbProdutosIdiomas.tbProdutosIdiomas.FindByidExportadoridIdiomaidProduto(m_nIdExportador,m_nIdioma,dtrwTbProdutos.idProduto);
										if (dtrwTbProdutosIdiomas != null)
										{
											if (!dtrwTbProdutosIdiomas.IsmstrDescricaoNull())
												lviItem.SubItems.Add(dtrwTbProdutosIdiomas.mstrDescricao);
											else
												lviItem.SubItems.Add(dtrwTbProdutosIdiomas.strDescricao);
										}
										else
										{						
											lviItem.SubItems.Add("");
										}
									}
								}
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
		 
			private void RefreshTextBoxesComProdutoEditar(int nIdProduto)
			{
				try
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwTbProdutos = (mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow)m_arlProdutosEditar[m_nIdProdutoEditando];
					m_tbCodigo.Text = dtrwTbProdutos.mstrCodigoProduto;
					m_tbPortugues.Text = dtrwTbProdutos.mstrDescricao;
					mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas.tbProdutosIdiomasRow dtrwTbProdutosIdiomas = m_typDatSetTbProdutosIdiomas.tbProdutosIdiomas.FindByidExportadoridIdiomaidProduto(m_nIdExportador,m_nIdioma,dtrwTbProdutos.idProduto);
					if (dtrwTbProdutosIdiomas != null)
					{
						if (!dtrwTbProdutosIdiomas.IsmstrDescricaoNull())
							m_tbEstrangeira.Text = dtrwTbProdutosIdiomas.mstrDescricao;
						else
							m_tbEstrangeira.Text = dtrwTbProdutosIdiomas.strDescricao;
					}
					else
					{
						m_tbEstrangeira.Text = "";
					}
					if (m_bMostrarCodigo)
						m_tbCodigo.Focus();
					else
						m_tbPortugues.Focus();
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}

			private bool bProdutoPertenceListaProdutosEditar(int nIdProduto)
			{
				bool bRetorno =	false;
				try
				{
					for(int nCont = 0 ; nCont < m_arlProdutos.Count;nCont++)
					{
						if (nIdProduto == ((int)((System.Windows.Forms.ListViewItem)(m_arlProdutos[nCont])).Tag))
						{
							bRetorno = true;
							break;
						}
					}
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
                return(bRetorno);
			}

			private bool bExisteOutroProdutoComEstesDados()
			{
				bool bRetorno = false;
				try
				{
					string strCodigoProduto = m_tbCodigo.Text;
					string strNomeProduto = m_tbPortugues.Text;
					mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwTbProdutos;
					
					// Verificando na lista de produtos gerais
					for(int nCont = 0; nCont < m_typDatSetTbProdutos.tbProdutos.Rows.Count;nCont++)
					{
						dtrwTbProdutos = (mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow)m_typDatSetTbProdutos.tbProdutos.Rows[nCont];
						if (dtrwTbProdutos.RowState != System.Data.DataRowState.Deleted)
						{
							if (!bProdutoPertenceListaProdutosEditar(dtrwTbProdutos.idProduto))
							{
								if (strCodigoProduto == dtrwTbProdutos.mstrCodigoProduto)
								{
									mdlMensagens.clsMensagens.ShowInformation(this.Text, mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlProdutosGeral_frmFProdutosCad_CodigoDoProdutoDuplicado));
									//MessageBox.Show("O código do produto que você deseja inserir já existe!","Siscobras.NET",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
									m_tbCodigo.SelectAll();
									m_tbCodigo.Focus();
									bRetorno = true;
									break;
								}
								if (strNomeProduto == dtrwTbProdutos.mstrDescricao)
								{
									mdlMensagens.clsMensagens.ShowInformation(this.Text, mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlProdutosGeral_frmFProdutosCad_DescricaoDoProdutoDuplicada));
									//MessageBox.Show("A descrição do produto que você deseja inserir já existe!","Siscobras.NET",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
									m_tbPortugues.SelectAll();
									m_tbPortugues.Focus();
									bRetorno = true;
									break;
								}
							}
						}
					}
					
					// Verificando na lista de produtos a Editar
					if (!bRetorno)
					{
						for(int nCont = 0; nCont < m_arlProdutosEditar.Count;nCont++)
						{
							dtrwTbProdutos = (mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow)m_arlProdutosEditar[nCont];
							if (dtrwTbProdutos.idProduto != ((mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow)(m_arlProdutosEditar[m_nIdProdutoEditando])).idProduto)
							{
								if (strCodigoProduto == dtrwTbProdutos.mstrCodigoProduto)
								{
									mdlMensagens.clsMensagens.ShowInformation(this.Text, mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlProdutosGeral_frmFProdutosCad_CodigoDoProdutoDuplicado));
									//MessageBox.Show("O código do produto que você deseja inserir já existe!","Siscobras.NET",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
									m_tbCodigo.SelectAll();
									m_tbCodigo.Focus();
									bRetorno = true;
									break;
								}
								if (strNomeProduto == dtrwTbProdutos.mstrDescricao)
								{
									mdlMensagens.clsMensagens.ShowInformation(this.Text, mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlProdutosGeral_frmFProdutosCad_DescricaoDoProdutoDuplicada));
									//MessageBox.Show("A descrição do produto que você deseja inserir já existe!","Siscobras.NET",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
									m_tbPortugues.SelectAll();
									m_tbPortugues.Focus();
									bRetorno = true;
									break;
								}
							}
						}
					}
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
                return(bRetorno);
			}

			private void EditaProdutoListView(bool bMoverFoco)
			{
				try
				{
					if (m_nIdProdutoEditando != -1)
					{
						if (!bExisteOutroProdutoComEstesDados())
						{
							// Atualizando Array List Produtos Editar 
							mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwTbProdutos;
							mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas.tbProdutosIdiomasRow dtrwTbProdutosIdiomas;
							dtrwTbProdutos = (mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow)m_arlProdutosEditar[m_nIdProdutoEditando];
							dtrwTbProdutos.mstrCodigoProduto = m_tbCodigo.Text;
							dtrwTbProdutos.mstrDescricao = m_tbPortugues.Text;
							dtrwTbProdutosIdiomas = m_typDatSetTbProdutosIdiomas.tbProdutosIdiomas.FindByidExportadoridIdiomaidProduto(m_nIdExportador,m_nIdioma,dtrwTbProdutos.idProduto);
							if (m_bMostrarLinguaEstrangeira)
							{
								if (dtrwTbProdutosIdiomas == null)
								{
									dtrwTbProdutosIdiomas = m_typDatSetTbProdutosIdiomas.tbProdutosIdiomas.NewtbProdutosIdiomasRow();
									dtrwTbProdutosIdiomas.idExportador = m_nIdExportador;
									dtrwTbProdutosIdiomas.idIdioma = m_nIdioma;
									dtrwTbProdutosIdiomas.idProduto = dtrwTbProdutos.idProduto;
									dtrwTbProdutosIdiomas.mstrDescricao = m_tbEstrangeira.Text;
									m_typDatSetTbProdutosIdiomas.tbProdutosIdiomas.AddtbProdutosIdiomasRow(dtrwTbProdutosIdiomas);
								}
								else
								{
									dtrwTbProdutosIdiomas.mstrDescricao = m_tbEstrangeira.Text;
								}
							}
							
							// Atualizando List View 
							System.Windows.Forms.ListViewItem lviProduto;
							lviProduto = m_lvProdutos.Items[m_nIdProdutoEditando];
							int nPos = 0;
							if (m_bMostrarCodigo)
							{
								lviProduto.SubItems[nPos].Text = dtrwTbProdutos.mstrCodigoProduto;
								//lviProduto.Text = dtrwTbProdutos.mstrCodigoProduto;
								nPos++;
							}
							lviProduto.SubItems[nPos].Text = dtrwTbProdutos.mstrDescricao;
							nPos++;
							if (m_bMostrarLinguaEstrangeira)
							{
								string strLinguaEstrangeira = "";
								if (!dtrwTbProdutosIdiomas.IsmstrDescricaoNull())
									strLinguaEstrangeira = dtrwTbProdutosIdiomas.mstrDescricao;
								if ((strLinguaEstrangeira == "") && (!dtrwTbProdutosIdiomas.IsstrDescricaoNull()))
									strLinguaEstrangeira = dtrwTbProdutosIdiomas.strDescricao;
								if (dtrwTbProdutosIdiomas != null)
								{
									if (lviProduto.SubItems.Count > nPos)
									{
										lviProduto.SubItems[nPos].Text = strLinguaEstrangeira;
									}
									else
									{
										lviProduto.SubItems.Add(strLinguaEstrangeira);
									}
								}
							}
							
							//m_nIdProdutoEditando = -1;
							if (bMoverFoco)
							{
								if (m_lvProdutos.SelectedItems.Count > 0)
								{
									if ((m_lvProdutos.SelectedItems[0].Index + 1) < m_lvProdutos.Items.Count)
									{
										m_lvProdutos.Items[m_lvProdutos.SelectedItems[0].Index + 1].Selected = true;
										if (m_bMostrarCodigo)
											m_tbCodigo.Focus();
										else
											m_tbPortugues.Focus();
									}
									else
									{
										m_btOk.Focus();
									}
								}
								else
								{
									m_btOk.Focus();
								}
							}
							else
							{
								m_tbPortugues.Text = "";					
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

			public void retornaValoresEdicao(out System.Collections.ArrayList arlProdutosEditados)
			{
				arlProdutosEditados = m_arlProdutosEditar;
			}
		#endregion

		#region Métodos Referentes ao Menu Context
			private void m_miProdutosExcluir_Click(object sender, System.EventArgs e)
			{
				while (m_lvProdutos.SelectedItems.Count > 0)
				{
					int nIndex = m_lvProdutos.SelectedItems.Count - 1;
                    m_arlProdutosInserir.RemoveAt(nIndex);     
                    m_arlProdutosLinguaEstrangeiraInserir.RemoveAt(nIndex);                    
					m_lvProdutos.Items.RemoveAt(nIndex);
				}
			}
		#endregion

		#region Retorno de TypDatSet
		public void retornaTypDatSets(out mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetTbProdutos, out mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas typDatSetTbProdutosIdiomas)
		{
			typDatSetTbProdutos = m_typDatSetTbProdutos;
			typDatSetTbProdutosIdiomas = m_typDatSetTbProdutosIdiomas;
		}
		// Método criado em 09/10/2003 para funcionar a edição de produtos!
		public void retornaTypDatSetIdioma(out mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas typDatSetTbProdutosIdiomas)
		{
			typDatSetTbProdutosIdiomas = m_typDatSetTbProdutosIdiomas;
		}
		#endregion
	}
}
