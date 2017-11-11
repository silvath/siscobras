using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;

namespace mdlProdutosGeral
{
	/// <summary>
	/// Summary description for frmFProdutos.
	/// </summary>
	internal class frmFProdutos : mdlComponentesGraficos.FormFlutuante
	{
		#region Delegates
			public delegate void delCallRefreshIdioma();
			public delegate void delCallTrocarIdioma();
			public delegate void delCallRefreshTvCategorias(ref System.Windows.Forms.TreeView tvCategorias);
			public delegate void delCallTrocarSuperCategoriaDaCategoria(int nIdCategoria,int nNovaSuperCategoria);
			public delegate void delCallInformarMostrarCodigo(int nCategoria);
			public delegate void delCallTrocarMostrarCodigoDaCategoria(int nIdCategoria,bool bMostrarCodigo);
			public delegate void delCallNovaCategoria(System.Windows.Forms.TreeNode tvnNodoPai);
			public delegate void delCallEditarCategoria(System.Windows.Forms.TreeNode tvnNodo);
			public delegate void delCallExcluirCategoria(System.Windows.Forms.TreeNode tvnNodo);
			public delegate void delCallRefreshTreeVProdutos(int nCategoria,ref mdlComponentesGraficos.TreeView treeVProdutos,bool bMostrarNcm,bool bMostrarNaladi);
			public delegate void delCallRefreshListVProdutos(int nCategoria,ref mdlComponentesGraficos.ListView ListViewProdutos,bool bMostrarNcm,bool bMostrarNaladi);
			public delegate void delCallTrocarCategoriaArrayListProdutos(System.Collections.ArrayList arlProdutos, int nNovaCategoria);
			public delegate void delCallSelecionaProdutosAPartirTreeView(ref System.Windows.Forms.TreeView tvCategorias, ref mdlComponentesGraficos.TreeView tvProdutos, ref mdlComponentesGraficos.ListView lvProdutos);
			public delegate void delCallSelecionaProdutosAPartirListView(ref System.Windows.Forms.TreeView tvCategorias, ref mdlComponentesGraficos.TreeView tvProdutos, ref mdlComponentesGraficos.ListView lvProdutos, int X, int Y);
			public delegate void delCallProdutosSelecionadosComoProdutosFilhos(System.Collections.ArrayList arlProdutosSelecionados, ref System.Windows.Forms.ListViewItem lvItemProdutoPai);
			public delegate void delCallExcluirProdutosFilhos(ref System.Windows.Forms.ListViewItem lvItemProdutoPai);
			    
			public delegate void delCallNovosProdutos(int nCategoria,ref mdlComponentesGraficos.ListView lvProdutos,bool bMostrarNcm,bool bMostrarNaladi);
			public delegate void delCallEditarProdutos(int nCategoria,System.Collections.ArrayList arlProdutos);
			public delegate void delCallExcluirProdutos(System.Collections.ArrayList arlProdutos);

			public delegate void delCallRefreshLvNcm(ref mdlComponentesGraficos.ListView lvNcm);
			public delegate void delCallTrocarNcmArrayListProdutos(System.Collections.ArrayList arlProdutos,System.Windows.Forms.ListViewItem lviNcm,bool bMostrarNcm,bool bMostrarNaladi);
			public delegate void delCallNovaNcm(ref mdlComponentesGraficos.ListView lvNcm);
			public delegate void delCallEditarNcm(System.Collections.ArrayList arlNcm, ref mdlComponentesGraficos.ListView lvProdutos);
			public delegate void delCallExcluirNcm(System.Collections.ArrayList arlNcm, ref mdlComponentesGraficos.ListView lvProdutos);
			public delegate void delCallCriarNovaNcm(string Codigo, string Denominacao);
			public delegate void delCallEditarAntigaNcm(string Codigo, string Denominacao);
			
			public delegate void delCallRefreshLvNaladi(ref mdlComponentesGraficos.ListView lvNaladi);
			public delegate void delCallTrocarNaladiArrayListProdutos(System.Collections.ArrayList arlProdutos,System.Windows.Forms.ListViewItem lviNaladi,bool bMostrarNcm,bool bMostrarNaladi);
			public delegate void delCallNovaNaladi(ref mdlComponentesGraficos.ListView lvNaladi);
			public delegate void delCallEditarNaladi(System.Collections.ArrayList arlNaladi, ref mdlComponentesGraficos.ListView lvProdutos);
			public delegate void delCallExcluirNaladi(System.Collections.ArrayList arlNaladi, ref mdlComponentesGraficos.ListView lvProdutos);
			public delegate void delCallCriarNovaNaladi(string Codigo, string Denominacao);
			public delegate void delCallEditarAntigaNaladi(string Codigo, string Denominacao);

			public delegate bool delCallMostrarApenasProdutosCodigo();
			public delegate bool delCallApenasProdutosCodigo(bool bApenasProdutosCodigo);

			public delegate void delCallSalvaDados();
			public delegate void delCallSalvaDadosSemSair();

			public delegate void delCallProcurar();
			public delegate bool delCallShowDialogAtributos(int nIdProduto);
			public delegate bool delCallShowDialogPropriedades();
			public delegate bool delCallShowDialogPequisaClassificacaoTarifaria();
		#endregion
		#region Events
			public event delCallRefreshIdioma eCallRefreshIdioma;
			public event delCallTrocarIdioma eCallTrocarIdioma;

			public event delCallRefreshTvCategorias eCallRefreshTvCategorias;
			public event delCallTrocarSuperCategoriaDaCategoria eCallTrocarSuperCategoriaDaCategoria;
			public event delCallInformarMostrarCodigo eCallInformarMostrarCodigo;
			public event delCallTrocarMostrarCodigoDaCategoria eCallTrocarMostrarCodigoDaCategoria;
			public event delCallNovaCategoria eCallNovaCategoria;    
			public event delCallEditarCategoria eCallEditarCategoria;    
			public event delCallExcluirCategoria eCallExcluirCategoria;    

			public event delCallRefreshTreeVProdutos eCallRefreshTreeVProdutos;
			public event delCallRefreshListVProdutos eCallRefreshListVProdutos;
			public event delCallTrocarCategoriaArrayListProdutos eCallTrocarCategoriaArrayListProdutos;
			public event delCallSelecionaProdutosAPartirTreeView eCallSelecionaProdutosAPartirTreeView;
			public event delCallSelecionaProdutosAPartirListView eCallSelecionaProdutosAPartirListView;
			public event delCallProdutosSelecionadosComoProdutosFilhos eCallProdutosSelecionadosComoProdutosFilhos;
			public event delCallExcluirProdutosFilhos eCallExcluirProdutosFilhos;

			public event delCallNovosProdutos eCallNovosProdutos;
			public event delCallEditarProdutos eCallEditarProdutos;
			public event delCallExcluirProdutos eCallExcluirProdutos;

			public event delCallRefreshLvNcm eCallRefreshLvNcm;
			public event delCallTrocarNcmArrayListProdutos eCallTrocarNcmArrayListProdutos;
			public event delCallNovaNcm eCallNovaNcm;
			public event delCallEditarNcm eCallEditarNcm;
			public event delCallExcluirNcm eCallExcluirNcm;
			public event delCallCriarNovaNcm eCallCriarNovaNcm;
			public event delCallEditarAntigaNcm eCallEditarAntigaNcm;

			public event delCallRefreshLvNaladi eCallRefreshLvNaladi;
			public event delCallTrocarNaladiArrayListProdutos eCallTrocarNaladiArrayListProdutos;
			public event delCallNovaNaladi eCallNovaNaladi;
			public event delCallEditarNaladi eCallEditarNaladi;
			public event delCallExcluirNaladi eCallExcluirNaladi;
			public event delCallCriarNovaNaladi eCallCriarNovaNaladi;
			public event delCallEditarAntigaNaladi eCallEditarAntigaNaladi;

			public event delCallMostrarApenasProdutosCodigo eCallMostrarApenasProdutosCodigo;
			public event delCallApenasProdutosCodigo eCallApenasProdutosCodigo;

			public event delCallSalvaDados eCallSalvaDados;
			public event delCallSalvaDadosSemSair eCallSalvaDadosSemSair;

			public event delCallProcurar eCallProcurar;

			public event delCallShowDialogAtributos eCallShowDialogAtributos;
			public event delCallShowDialogPropriedades eCallShowDialogPropriedades;
			public event delCallShowDialogPequisaClassificacaoTarifaria eCallShowDialogPequisaClassificacaoTarifaria;
		#endregion
		#region Events Methods
		#region Idiomas
		protected virtual void OnCallRefreshIdioma() 
		{
			if (eCallRefreshIdioma != null)
				eCallRefreshIdioma();
		}

		protected virtual void OnCallTrocarIdioma() 
		{
			if (eCallTrocarIdioma != null)
				eCallTrocarIdioma();
		}
		#endregion
		#region Categorias 
		protected virtual void OnCallRefreshTvCategorias() 
		{
			if (eCallRefreshTvCategorias != null)
				eCallRefreshTvCategorias(ref m_tvCategoria);
		}

		protected virtual void OnCallTrocarSuperCategoriaDaCategoria(int nCategoria,int nNovaSuperCategoria) 
		{
			if (eCallTrocarSuperCategoriaDaCategoria != null)
				eCallTrocarSuperCategoriaDaCategoria(nCategoria,nNovaSuperCategoria);
		}

		protected virtual void OnCallInformarMostrarCodigo(int nCategoria) 
		{
			if (eCallInformarMostrarCodigo != null)
				eCallInformarMostrarCodigo(nCategoria);
		}

		protected virtual void OnCallTrocarMostrarCodigoDaCategoria(int nCategoria, bool bMostrarCodigo)
		{
			if (eCallTrocarMostrarCodigoDaCategoria != null)
				eCallTrocarMostrarCodigoDaCategoria(nCategoria,bMostrarCodigo);
		}

		protected virtual void OnCallNovaCategoria(System.Windows.Forms.TreeNode tvnNodoPai)
		{
			if (eCallNovaCategoria != null)
				eCallNovaCategoria(tvnNodoPai);
		}

		protected virtual void OnCallEditarCategoria(System.Windows.Forms.TreeNode tvnNodo)
		{
			if (eCallEditarCategoria != null)
				eCallEditarCategoria(tvnNodo);
		}

		protected virtual void OnCallExcluirCategoria(System.Windows.Forms.TreeNode tvnNodo)
		{
			if (eCallExcluirCategoria != null)
				eCallExcluirCategoria(tvnNodo);
		}

		#endregion
		#region Produtos
		protected virtual void OnCallRefreshTreeVProdutos(int nCategoria) 
		{
			if (eCallRefreshTreeVProdutos != null)
				eCallRefreshTreeVProdutos(nCategoria,ref m_treeVProdutos,m_ckNcm.Checked,m_ckNaladi.Checked);
		}

		protected virtual void OnCallRefreshListVProdutos(int nCategoria)
		{
			if (eCallRefreshListVProdutos != null)
				eCallRefreshListVProdutos(nCategoria, ref m_lvProdutos, m_ckNcm.Checked, m_ckNaladi.Checked);
		}

		protected virtual void OnCallTrocarCategoriaArrayListProdutos(System.Collections.ArrayList arlProdutos,int nNovaCategoria) 
		{
			if (eCallTrocarCategoriaArrayListProdutos != null)
				eCallTrocarCategoriaArrayListProdutos(arlProdutos,nNovaCategoria);
		}

		protected virtual void OnCallSelecionaProdutosAPartirTreeView()
		{
			if (eCallSelecionaProdutosAPartirTreeView != null)
				eCallSelecionaProdutosAPartirTreeView(ref m_tvCategoria, ref m_treeVProdutos, ref m_lvProdutos);
		}

		protected virtual void OnCallSelecionaProdutosAPartirListView(int X, int Y)
		{
			if (eCallSelecionaProdutosAPartirListView != null)
				eCallSelecionaProdutosAPartirListView(ref m_tvCategoria, ref m_treeVProdutos, ref m_lvProdutos, X, Y);
		}

		protected virtual void OnCallProdutosSelecionadosComoProdutosFilhos(System.Collections.ArrayList arlProdutosSelecionados, ref System.Windows.Forms.ListViewItem lvItemProdutoPai)
		{
			if (eCallProdutosSelecionadosComoProdutosFilhos != null)
				eCallProdutosSelecionadosComoProdutosFilhos(arlProdutosSelecionados, ref lvItemProdutoPai);
		}

		protected virtual void OnCallExcluirProdutosFilhos(ref System.Windows.Forms.ListViewItem lvItemProdutoPai)
		{
			if (eCallExcluirProdutosFilhos != null)
				eCallExcluirProdutosFilhos(ref lvItemProdutoPai);
		}

		protected virtual void OnCallNovosProdutos(int nCategoria) 
		{
			if (eCallNovosProdutos != null)
				eCallNovosProdutos(nCategoria,ref m_lvProdutos,m_ckNcm.Checked,m_ckNaladi.Checked);
		}

		protected virtual void OnCallEditarProdutos(int nCategoria,System.Collections.ArrayList arlProdutos) 
		{
			if (eCallEditarProdutos != null)
				eCallEditarProdutos(nCategoria,arlProdutos);
		}

		protected virtual void OnCallExcluirProdutos(System.Collections.ArrayList arlProdutos) 
		{
			if (eCallExcluirProdutos != null)
				eCallExcluirProdutos(arlProdutos);
		}
		#endregion
		#region Ncm 
		protected virtual void OnCallRefreshLvNcm() 
		{
			if (eCallRefreshLvNcm != null)
				eCallRefreshLvNcm(ref m_lvNcm);
		}

		protected virtual void OnCallTrocarNcmArrayListProdutos(System.Collections.ArrayList arlProdutos,System.Windows.Forms.ListViewItem lviNcm) 
		{
			if (eCallTrocarNcmArrayListProdutos != null)
				eCallTrocarNcmArrayListProdutos(arlProdutos,lviNcm,m_ckNcm.Checked,m_ckNaladi.Checked);
		}

		protected virtual void OnCallNovaNcm()
		{
			if (eCallNovaNcm != null)
				eCallNovaNcm(ref m_lvNcm);
		}

		protected virtual void OnCallEditarNcm(System.Collections.ArrayList arlNcm)
		{
			if (eCallEditarNcm != null)
				eCallEditarNcm(arlNcm,ref m_lvProdutos);
		}
		
		protected virtual void OnCallExcluirNcm(System.Collections.ArrayList arlNcm)
		{
			if (eCallExcluirNcm != null)
				eCallExcluirNcm(arlNcm,ref m_lvProdutos);
		}

		protected virtual void OnCallCriarNovaNcm(string Codigo, string Denominacao)
		{
			if (eCallCriarNovaNcm != null)
				eCallCriarNovaNcm(Codigo,Denominacao);
		}

		protected virtual void OnCallEditarAntigaNcm(string Codigo, string Denominacao)
		{
			if (eCallEditarAntigaNcm != null)
				eCallEditarAntigaNcm(Codigo,Denominacao);
		}

		#endregion
			protected virtual void OnCallRefreshLvNaladi() 
			{
				if (eCallRefreshLvNaladi != null)
					eCallRefreshLvNaladi(ref m_lvNaladi);
			}

			protected virtual void OnCallTrocarNaladiArrayListProdutos(System.Collections.ArrayList arlProdutos,System.Windows.Forms.ListViewItem lviNaladi) 
			{
				if (eCallTrocarNaladiArrayListProdutos != null)
					eCallTrocarNaladiArrayListProdutos(arlProdutos,lviNaladi,m_ckNcm.Checked,m_ckNaladi.Checked);
			}

			protected virtual void OnCallNovaNaladi()
			{
				if (eCallNovaNaladi != null)
					eCallNovaNaladi(ref m_lvNaladi);
			}

			protected virtual void OnCallEditarNaladi(System.Collections.ArrayList arlNaladi)
			{
				if (eCallEditarNaladi != null)
					eCallEditarNaladi(arlNaladi,ref m_lvProdutos);
			}
					
			protected virtual void OnCallExcluirNaladi(System.Collections.ArrayList arlNaladi)
			{
				if (eCallExcluirNaladi != null)
					eCallExcluirNaladi(arlNaladi,ref m_lvProdutos);
			}

			protected virtual void OnCallCriarNovaNaladi(string Codigo, string Denominacao)
			{
				if (eCallCriarNovaNaladi != null)
					eCallCriarNovaNaladi(Codigo,Denominacao);
			}

			protected virtual void OnCallEditarAntigaNaladi(string Codigo, string Denominacao)
			{
				if (eCallEditarAntigaNaladi != null)
					eCallEditarAntigaNaladi(Codigo,Denominacao);
			}

			protected virtual bool OnCallMostrarApenasProdutosCodigo() 
			{
				bool bRetorno = false;
				if (eCallMostrarApenasProdutosCodigo != null)
					bRetorno = eCallMostrarApenasProdutosCodigo();
				return(bRetorno);
			}

			protected virtual bool OnCallApenasProdutosCodigo() 
			{
				bool bRetorno = false;
				if (eCallApenasProdutosCodigo != null)
					bRetorno = eCallApenasProdutosCodigo(m_ckApenasProdutosCodigo.Checked);
				return(bRetorno);
			}

			protected virtual void OnCallSalvaDados() 
			{
				if (eCallSalvaDados != null)
					eCallSalvaDados();
			}
			protected virtual void OnCallSalvaDadosSemSair()
			{
				if (eCallSalvaDadosSemSair != null)
					eCallSalvaDadosSemSair();
			}

			protected virtual void OnCallProcurar()
			{
				if (eCallProcurar != null)
					eCallProcurar();
			}

			protected virtual bool OnCallShowDialogAtributos()
			{
				if (eCallShowDialogAtributos != null)
				{
					if (m_lvProdutos.SelectedItems.Count > 0)
						return(eCallShowDialogAtributos(Int32.Parse(m_lvProdutos.SelectedItems[0].Tag.ToString())));
					else
						mdlMensagens.clsMensagens.ShowInformation("Você deve primeiro selecionar um produto para modificar seus atributos.");
				}
				return(false);
			}

			protected virtual bool OnCallShowDialogPropriedades()
			{
				if (eCallShowDialogPropriedades == null)
					return(false);
				return(eCallShowDialogPropriedades());
			}

			protected bool OnCallShowDialogPequisaClassificacaoTarifaria()
			{
				if (eCallShowDialogPequisaClassificacaoTarifaria == null)
					return(false);
				return(eCallShowDialogPequisaClassificacaoTarifaria());
			}
		#endregion

		#region Atributos
		// ***************************************************************************************************
		// Atributos
		// ***************************************************************************************************
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
		private string m_strEnderecoExecutavel;

		protected mdlComponentesGraficos.MessageBalloon m_mgblBalaoToolTip = null;
		private bool m_bMostrarBaloes = true;

		private static int m_nContadorCategoriaBalao = 0;
		private static int m_nContadorProdutoBalao = 0;
		private static int m_nContadorNcmBalao = 0;
		private static int m_nContadorNaladiBalao = 0;
		private static int m_nContadorGeralBalao = 0;

		private System.Windows.Forms.GroupBox m_gbCategoria;
		private System.Windows.Forms.TreeView m_tvCategoria;
		private System.Windows.Forms.GroupBox m_gbGeral;
		internal System.Windows.Forms.Button m_btOk;
		internal System.Windows.Forms.Button m_btCancelar;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.GroupBox m_gbProdutos;
		private System.Windows.Forms.Label m_lbIdioma;
		private System.Windows.Forms.Button m_btBandeira;
		private System.Windows.Forms.GroupBox m_gbNcm;
		private System.Windows.Forms.GroupBox m_gbNaladi;
		private mdlComponentesGraficos.ListView m_lvNcm;
		private mdlComponentesGraficos.ListView m_lvNaladi;
		private System.Windows.Forms.ToolTip m_ttDica;
		private System.Windows.Forms.CheckBox m_ckNcm;
		private System.Windows.Forms.CheckBox m_ckNaladi;

		private string m_strControleOndeSaiuObjeto;
		private System.Windows.Forms.ContextMenu m_cmCategoria;
		private System.Windows.Forms.MenuItem menuItem2;

		private bool m_bAtivado = true;
		public bool m_bModificado = false;
		private bool m_bMostrarCodigo = false;
		private System.Windows.Forms.MenuItem m_miCategoriaVisualizarCodigo;
		private System.Windows.Forms.MenuItem m_miCategoriaNova;
		private System.Windows.Forms.MenuItem m_miCategoriaEditar;
		private System.Windows.Forms.MenuItem m_miCategoriaExcluir;
		private System.Windows.Forms.ContextMenu m_cmNcm;
		private System.Windows.Forms.ContextMenu m_cmNaladi;
		private System.Windows.Forms.MenuItem m_miNcmNova;
		private System.Windows.Forms.MenuItem m_miNcmEditar;
		private System.Windows.Forms.MenuItem m_miNcmExcluir;
		private System.Windows.Forms.MenuItem m_miNaladiNova;
		private System.Windows.Forms.MenuItem m_miNaladiEditar;
		private System.Windows.Forms.MenuItem m_miNaladiExcluir;
		private mdlComponentesGraficos.TreeView m_treeVProdutos;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox m_ckCategorias;
		private mdlComponentesGraficos.ListView m_lvProdutos;
		private System.Windows.Forms.ColumnHeader m_chCodigo;
		private System.Windows.Forms.ColumnHeader m_chDescricao;
		private System.Windows.Forms.ColumnHeader m_chNCM;
		private System.Windows.Forms.ColumnHeader m_chNALADI;
		private System.Windows.Forms.ColumnHeader m_chIdioma;
		private System.Windows.Forms.ContextMenu m_cmLvProdutos;
		private System.Windows.Forms.MenuItem m_miLvProdutosNovo;
		private System.Windows.Forms.MenuItem m_miLvProdutosEditar;
		private System.Windows.Forms.MenuItem m_miLvProdutosExcluir;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem m_miLvProdutosDesvinvularNcm;
		private System.Windows.Forms.MenuItem m_miLvProdutosDesvinvularNaladi;
		private System.Windows.Forms.CheckBox m_ckTreeView;
		private System.Windows.Forms.MenuItem m_miLvDesvincularNcmENaladi;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem m_miLvDesvincularProdutosFilhos;
		internal System.Windows.Forms.Button m_btSalvar;
		private System.Windows.Forms.ImageList m_ilCategorias;
		private System.Windows.Forms.ImageList m_ilProdutos;
		private System.Windows.Forms.Timer m_tmProdutos;
		private System.Windows.Forms.CheckBox m_ckApenasProdutosCodigo;
		private System.Windows.Forms.Button m_btLocalizar;
		private System.Windows.Forms.Button m_btAtributos;
		private System.Windows.Forms.Button m_btPropriedades;
		private System.Windows.Forms.Button m_btClassificacaoTarifaria;

		private System.Drawing.Point m_ptMouse;
		// ***************************************************************************************************
		#endregion
		#region Properties
			public bool MostrarCodigo
			{
				get
				{
					return( m_bMostrarCodigo);
				}

				set
				{
					m_bMostrarCodigo = value;
				}
			}

			public bool VisibilidadeNCM
			{
				get
				{
					return( m_ckNcm.Checked);
				}
				set
				{
					m_ckNcm.Checked = value;
				}
			}

			public bool VisibilidadeNaladi
			{
				get
				{
					return( m_ckNaladi.Checked);
				}
				set
				{
					m_ckNaladi.Checked = value;
				}
			}

			internal mdlComponentesGraficos.ListView ListaProdutos
			{
				get
				{
					return(m_lvProdutos);
				}
			}

			public bool ApenasProdutosCodigo
			{
				set
				{
					m_ckApenasProdutosCodigo.Checked = value;
				}
				get
				{
					return(m_ckApenasProdutosCodigo.Checked);
				}
			}
		#endregion
		#region Construtores e Destrutores
			public frmFProdutos(ref mdlTratamentoErro.clsTratamentoErro tratadorErro,string EnderecoExecutavel)
			{
				m_cls_ter_tratadorErro = tratadorErro;
				m_strEnderecoExecutavel = EnderecoExecutavel;
				InitializeComponent();
			}
			public frmFProdutos(ref mdlTratamentoErro.clsTratamentoErro tratadorErro,string EnderecoExecutavel, bool bMostrarBaloes)
			{
				m_cls_ter_tratadorErro = tratadorErro;
				m_strEnderecoExecutavel = EnderecoExecutavel;
				InitializeComponent();
				m_bMostrarBaloes = bMostrarBaloes;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFProdutos));
			this.m_gbCategoria = new System.Windows.Forms.GroupBox();
			this.m_tvCategoria = new System.Windows.Forms.TreeView();
			this.m_ilCategorias = new System.Windows.Forms.ImageList(this.components);
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_btClassificacaoTarifaria = new System.Windows.Forms.Button();
			this.m_ilProdutos = new System.Windows.Forms.ImageList(this.components);
			this.m_btPropriedades = new System.Windows.Forms.Button();
			this.m_btAtributos = new System.Windows.Forms.Button();
			this.m_btLocalizar = new System.Windows.Forms.Button();
			this.m_btSalvar = new System.Windows.Forms.Button();
			this.m_ckTreeView = new System.Windows.Forms.CheckBox();
			this.m_ckCategorias = new System.Windows.Forms.CheckBox();
			this.m_ckNaladi = new System.Windows.Forms.CheckBox();
			this.m_ckNcm = new System.Windows.Forms.CheckBox();
			this.m_gbNaladi = new System.Windows.Forms.GroupBox();
			this.m_lvNaladi = new mdlComponentesGraficos.ListView();
			this.m_gbNcm = new System.Windows.Forms.GroupBox();
			this.m_lvNcm = new mdlComponentesGraficos.ListView();
			this.m_btBandeira = new System.Windows.Forms.Button();
			this.m_lbIdioma = new System.Windows.Forms.Label();
			this.m_gbProdutos = new System.Windows.Forms.GroupBox();
			this.m_lvProdutos = new mdlComponentesGraficos.ListView();
			this.m_chCodigo = new System.Windows.Forms.ColumnHeader();
			this.m_chDescricao = new System.Windows.Forms.ColumnHeader();
			this.m_chNCM = new System.Windows.Forms.ColumnHeader();
			this.m_chNALADI = new System.Windows.Forms.ColumnHeader();
			this.m_chIdioma = new System.Windows.Forms.ColumnHeader();
			this.m_treeVProdutos = new mdlComponentesGraficos.TreeView();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_ckApenasProdutosCodigo = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.m_ttDica = new System.Windows.Forms.ToolTip(this.components);
			this.m_cmCategoria = new System.Windows.Forms.ContextMenu();
			this.m_miCategoriaVisualizarCodigo = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.m_miCategoriaNova = new System.Windows.Forms.MenuItem();
			this.m_miCategoriaEditar = new System.Windows.Forms.MenuItem();
			this.m_miCategoriaExcluir = new System.Windows.Forms.MenuItem();
			this.m_cmNcm = new System.Windows.Forms.ContextMenu();
			this.m_miNcmNova = new System.Windows.Forms.MenuItem();
			this.m_miNcmEditar = new System.Windows.Forms.MenuItem();
			this.m_miNcmExcluir = new System.Windows.Forms.MenuItem();
			this.m_cmNaladi = new System.Windows.Forms.ContextMenu();
			this.m_miNaladiNova = new System.Windows.Forms.MenuItem();
			this.m_miNaladiEditar = new System.Windows.Forms.MenuItem();
			this.m_miNaladiExcluir = new System.Windows.Forms.MenuItem();
			this.m_cmLvProdutos = new System.Windows.Forms.ContextMenu();
			this.m_miLvProdutosNovo = new System.Windows.Forms.MenuItem();
			this.m_miLvProdutosEditar = new System.Windows.Forms.MenuItem();
			this.m_miLvProdutosExcluir = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.m_miLvProdutosDesvinvularNcm = new System.Windows.Forms.MenuItem();
			this.m_miLvProdutosDesvinvularNaladi = new System.Windows.Forms.MenuItem();
			this.m_miLvDesvincularNcmENaladi = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.m_miLvDesvincularProdutosFilhos = new System.Windows.Forms.MenuItem();
			this.m_tmProdutos = new System.Windows.Forms.Timer(this.components);
			this.m_gbCategoria.SuspendLayout();
			this.m_gbGeral.SuspendLayout();
			this.m_gbNaladi.SuspendLayout();
			this.m_gbNcm.SuspendLayout();
			this.m_gbProdutos.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbCategoria
			// 
			this.m_gbCategoria.Controls.Add(this.m_tvCategoria);
			this.m_gbCategoria.Location = new System.Drawing.Point(9, 8);
			this.m_gbCategoria.Name = "m_gbCategoria";
			this.m_gbCategoria.Size = new System.Drawing.Size(186, 448);
			this.m_gbCategoria.TabIndex = 0;
			this.m_gbCategoria.TabStop = false;
			this.m_gbCategoria.Text = "Categoria";
			// 
			// m_tvCategoria
			// 
			this.m_tvCategoria.AllowDrop = true;
			this.m_tvCategoria.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_tvCategoria.HideSelection = false;
			this.m_tvCategoria.ImageList = this.m_ilCategorias;
			this.m_tvCategoria.Location = new System.Drawing.Point(8, 17);
			this.m_tvCategoria.Name = "m_tvCategoria";
			this.m_tvCategoria.SelectedImageIndex = 2;
			this.m_tvCategoria.Size = new System.Drawing.Size(168, 423);
			this.m_tvCategoria.TabIndex = 1;
			this.m_ttDica.SetToolTip(this.m_tvCategoria, "Categorias disponíveis");
			this.m_tvCategoria.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_tvCategoria_MouseUp);
			this.m_tvCategoria.DragOver += new System.Windows.Forms.DragEventHandler(this.m_tvCategoria_DragOver);
			this.m_tvCategoria.KeyUp += new System.Windows.Forms.KeyEventHandler(this.m_tvCategoria_KeyUp);
			this.m_tvCategoria.DoubleClick += new System.EventHandler(this.m_tvCategoria_DoubleClick);
			this.m_tvCategoria.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_tvCategoria_AfterSelect);
			this.m_tvCategoria.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.m_tvCategoria_ItemDrag);
			this.m_tvCategoria.DragDrop += new System.Windows.Forms.DragEventHandler(this.m_tvCategoria_DragDrop);
			// 
			// m_ilCategorias
			// 
			this.m_ilCategorias.ImageSize = new System.Drawing.Size(16, 16);
			this.m_ilCategorias.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_ilCategorias.ImageStream")));
			this.m_ilCategorias.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbGeral.Controls.Add(this.m_btClassificacaoTarifaria);
			this.m_gbGeral.Controls.Add(this.m_btPropriedades);
			this.m_gbGeral.Controls.Add(this.m_btAtributos);
			this.m_gbGeral.Controls.Add(this.m_btLocalizar);
			this.m_gbGeral.Controls.Add(this.m_btSalvar);
			this.m_gbGeral.Controls.Add(this.m_ckTreeView);
			this.m_gbGeral.Controls.Add(this.m_ckCategorias);
			this.m_gbGeral.Controls.Add(this.m_ckNaladi);
			this.m_gbGeral.Controls.Add(this.m_ckNcm);
			this.m_gbGeral.Controls.Add(this.m_gbNaladi);
			this.m_gbGeral.Controls.Add(this.m_gbNcm);
			this.m_gbGeral.Controls.Add(this.m_btBandeira);
			this.m_gbGeral.Controls.Add(this.m_lbIdioma);
			this.m_gbGeral.Controls.Add(this.m_gbProdutos);
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Controls.Add(this.m_gbCategoria);
			this.m_gbGeral.Controls.Add(this.m_ckApenasProdutosCodigo);
			this.m_gbGeral.Location = new System.Drawing.Point(5, 1);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(731, 521);
			this.m_gbGeral.TabIndex = 1;
			this.m_gbGeral.TabStop = false;
			// 
			// m_btClassificacaoTarifaria
			// 
			this.m_btClassificacaoTarifaria.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btClassificacaoTarifaria.ImageIndex = 4;
			this.m_btClassificacaoTarifaria.ImageList = this.m_ilProdutos;
			this.m_btClassificacaoTarifaria.Location = new System.Drawing.Point(104, 487);
			this.m_btClassificacaoTarifaria.Name = "m_btClassificacaoTarifaria";
			this.m_btClassificacaoTarifaria.Size = new System.Drawing.Size(28, 28);
			this.m_btClassificacaoTarifaria.TabIndex = 81;
			this.m_ttDica.SetToolTip(this.m_btClassificacaoTarifaria, "Pequisa Classificacao Tarifária");
			this.m_btClassificacaoTarifaria.Click += new System.EventHandler(this.m_btClassificacaoTarifaria_Click);
			// 
			// m_ilProdutos
			// 
			this.m_ilProdutos.ImageSize = new System.Drawing.Size(16, 16);
			this.m_ilProdutos.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_ilProdutos.ImageStream")));
			this.m_ilProdutos.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// m_btPropriedades
			// 
			this.m_btPropriedades.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btPropriedades.ImageIndex = 3;
			this.m_btPropriedades.ImageList = this.m_ilProdutos;
			this.m_btPropriedades.Location = new System.Drawing.Point(41, 487);
			this.m_btPropriedades.Name = "m_btPropriedades";
			this.m_btPropriedades.Size = new System.Drawing.Size(28, 28);
			this.m_btPropriedades.TabIndex = 80;
			this.m_ttDica.SetToolTip(this.m_btPropriedades, "Propriedades Dinâmicas");
			this.m_btPropriedades.Click += new System.EventHandler(this.m_btPropriedades_Click);
			// 
			// m_btAtributos
			// 
			this.m_btAtributos.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btAtributos.ImageIndex = 2;
			this.m_btAtributos.ImageList = this.m_ilProdutos;
			this.m_btAtributos.Location = new System.Drawing.Point(73, 487);
			this.m_btAtributos.Name = "m_btAtributos";
			this.m_btAtributos.Size = new System.Drawing.Size(28, 28);
			this.m_btAtributos.TabIndex = 79;
			this.m_ttDica.SetToolTip(this.m_btAtributos, "Atributos");
			this.m_btAtributos.Click += new System.EventHandler(this.m_btAtributos_Click);
			// 
			// m_btLocalizar
			// 
			this.m_btLocalizar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btLocalizar.ImageIndex = 1;
			this.m_btLocalizar.ImageList = this.m_ilProdutos;
			this.m_btLocalizar.Location = new System.Drawing.Point(11, 487);
			this.m_btLocalizar.Name = "m_btLocalizar";
			this.m_btLocalizar.Size = new System.Drawing.Size(28, 28);
			this.m_btLocalizar.TabIndex = 78;
			this.m_ttDica.SetToolTip(this.m_btLocalizar, "Procurar");
			this.m_btLocalizar.Click += new System.EventHandler(this.m_btLocalizar_Click);
			// 
			// m_btSalvar
			// 
			this.m_btSalvar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btSalvar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btSalvar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btSalvar.Image = ((System.Drawing.Image)(resources.GetObject("m_btSalvar.Image")));
			this.m_btSalvar.Location = new System.Drawing.Point(270, 488);
			this.m_btSalvar.Name = "m_btSalvar";
			this.m_btSalvar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btSalvar.Size = new System.Drawing.Size(57, 25);
			this.m_btSalvar.TabIndex = 76;
			this.m_ttDica.SetToolTip(this.m_btSalvar, "Salvar");
			this.m_btSalvar.Click += new System.EventHandler(this.m_btSalvar_Click);
			// 
			// m_ckTreeView
			// 
			this.m_ckTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_ckTreeView.Location = new System.Drawing.Point(482, 460);
			this.m_ckTreeView.Name = "m_ckTreeView";
			this.m_ckTreeView.Size = new System.Drawing.Size(114, 16);
			this.m_ckTreeView.TabIndex = 75;
			this.m_ckTreeView.Text = "Detalhar Produtos";
			this.m_ttDica.SetToolTip(this.m_ckTreeView, "Visualizar Composição dos Produtos");
			this.m_ckTreeView.CheckedChanged += new System.EventHandler(this.m_ckTreeView_CheckedChanged);
			// 
			// m_ckCategorias
			// 
			this.m_ckCategorias.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_ckCategorias.Checked = true;
			this.m_ckCategorias.CheckState = System.Windows.Forms.CheckState.Checked;
			this.m_ckCategorias.Location = new System.Drawing.Point(482, 478);
			this.m_ckCategorias.Name = "m_ckCategorias";
			this.m_ckCategorias.Size = new System.Drawing.Size(94, 18);
			this.m_ckCategorias.TabIndex = 73;
			this.m_ckCategorias.Text = "Categorias";
			this.m_ttDica.SetToolTip(this.m_ckCategorias, "Visualizar Categorias");
			this.m_ckCategorias.CheckedChanged += new System.EventHandler(this.m_ckCategorias_CheckedChanged);
			// 
			// m_ckNaladi
			// 
			this.m_ckNaladi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_ckNaladi.Checked = true;
			this.m_ckNaladi.CheckState = System.Windows.Forms.CheckState.Checked;
			this.m_ckNaladi.Location = new System.Drawing.Point(595, 478);
			this.m_ckNaladi.Name = "m_ckNaladi";
			this.m_ckNaladi.Size = new System.Drawing.Size(128, 18);
			this.m_ckNaladi.TabIndex = 72;
			this.m_ckNaladi.Text = "Naladi";
			this.m_ttDica.SetToolTip(this.m_ckNaladi, "Visualizar Naladi\'s");
			this.m_ckNaladi.CheckedChanged += new System.EventHandler(this.m_ckNaladi_CheckedChanged);
			// 
			// m_ckNcm
			// 
			this.m_ckNcm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_ckNcm.Checked = true;
			this.m_ckNcm.CheckState = System.Windows.Forms.CheckState.Checked;
			this.m_ckNcm.Location = new System.Drawing.Point(595, 460);
			this.m_ckNcm.Name = "m_ckNcm";
			this.m_ckNcm.Size = new System.Drawing.Size(130, 18);
			this.m_ckNcm.TabIndex = 71;
			this.m_ckNcm.Text = "Ncm";
			this.m_ttDica.SetToolTip(this.m_ckNcm, "Visualizar Ncm\'s");
			this.m_ckNcm.CheckedChanged += new System.EventHandler(this.m_ckNcm_CheckedChanged);
			// 
			// m_gbNaladi
			// 
			this.m_gbNaladi.Controls.Add(this.m_lvNaladi);
			this.m_gbNaladi.Location = new System.Drawing.Point(200, 359);
			this.m_gbNaladi.Name = "m_gbNaladi";
			this.m_gbNaladi.Size = new System.Drawing.Size(520, 97);
			this.m_gbNaladi.TabIndex = 70;
			this.m_gbNaladi.TabStop = false;
			this.m_gbNaladi.Text = "Naladi";
			// 
			// m_lvNaladi
			// 
			this.m_lvNaladi.AllowColumnReorder = true;
			this.m_lvNaladi.AllowDrop = true;
			this.m_lvNaladi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lvNaladi.FullRowSelect = true;
			this.m_lvNaladi.HideSelection = false;
			this.m_lvNaladi.Location = new System.Drawing.Point(8, 12);
			this.m_lvNaladi.MultiSelect = false;
			this.m_lvNaladi.Name = "m_lvNaladi";
			this.m_lvNaladi.Size = new System.Drawing.Size(504, 72);
			this.m_lvNaladi.TabIndex = 3;
			this.m_ttDica.SetToolTip(this.m_lvNaladi, "Naladi(s) disponível(is)");
			this.m_lvNaladi.View = System.Windows.Forms.View.Details;
			this.m_lvNaladi.DoubleClick += new System.EventHandler(this.m_lvNaladi_DoubleClick);
			this.m_lvNaladi.DragOver += new System.Windows.Forms.DragEventHandler(this.m_lvNaladi_DragOver);
			this.m_lvNaladi.DragDrop += new System.Windows.Forms.DragEventHandler(this.m_lvNaladi_DragDrop);
			this.m_lvNaladi.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.m_lvNaladi_ColumnClick);
			this.m_lvNaladi.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_lvNaladi_MouseUp);
			this.m_lvNaladi.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.m_lvNaladi_ItemDrag);
			this.m_lvNaladi.KeyUp += new System.Windows.Forms.KeyEventHandler(this.m_lvNaladi_KeyUp);
			// 
			// m_gbNcm
			// 
			this.m_gbNcm.Controls.Add(this.m_lvNcm);
			this.m_gbNcm.Location = new System.Drawing.Point(200, 264);
			this.m_gbNcm.Name = "m_gbNcm";
			this.m_gbNcm.Size = new System.Drawing.Size(520, 97);
			this.m_gbNcm.TabIndex = 69;
			this.m_gbNcm.TabStop = false;
			this.m_gbNcm.Text = "Ncm";
			// 
			// m_lvNcm
			// 
			this.m_lvNcm.AllowColumnReorder = true;
			this.m_lvNcm.AllowDrop = true;
			this.m_lvNcm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lvNcm.FullRowSelect = true;
			this.m_lvNcm.HideSelection = false;
			this.m_lvNcm.Location = new System.Drawing.Point(8, 16);
			this.m_lvNcm.MultiSelect = false;
			this.m_lvNcm.Name = "m_lvNcm";
			this.m_lvNcm.Size = new System.Drawing.Size(504, 72);
			this.m_lvNcm.TabIndex = 2;
			this.m_ttDica.SetToolTip(this.m_lvNcm, "Ncm(s) disponível(is)");
			this.m_lvNcm.View = System.Windows.Forms.View.Details;
			this.m_lvNcm.DoubleClick += new System.EventHandler(this.m_lvNcm_DoubleClick);
			this.m_lvNcm.DragOver += new System.Windows.Forms.DragEventHandler(this.m_lvNcm_DragOver);
			this.m_lvNcm.DragDrop += new System.Windows.Forms.DragEventHandler(this.m_lvNcm_DragDrop);
			this.m_lvNcm.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.m_lvNcm_ColumnClick);
			this.m_lvNcm.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_lvNcm_MouseUp);
			this.m_lvNcm.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.m_lvNcm_ItemDrag);
			this.m_lvNcm.KeyUp += new System.Windows.Forms.KeyEventHandler(this.m_lvNcm_KeyUp);
			// 
			// m_btBandeira
			// 
			this.m_btBandeira.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btBandeira.Image = ((System.Drawing.Image)(resources.GetObject("m_btBandeira.Image")));
			this.m_btBandeira.Location = new System.Drawing.Point(11, 456);
			this.m_btBandeira.Name = "m_btBandeira";
			this.m_btBandeira.Size = new System.Drawing.Size(28, 28);
			this.m_btBandeira.TabIndex = 68;
			this.m_ttDica.SetToolTip(this.m_btBandeira, "Idioma do produto");
			this.m_btBandeira.Click += new System.EventHandler(this.m_btBandeira_Click);
			// 
			// m_lbIdioma
			// 
			this.m_lbIdioma.Location = new System.Drawing.Point(47, 464);
			this.m_lbIdioma.Name = "m_lbIdioma";
			this.m_lbIdioma.Size = new System.Drawing.Size(169, 16);
			this.m_lbIdioma.TabIndex = 67;
			this.m_lbIdioma.Text = "Idioma";
			// 
			// m_gbProdutos
			// 
			this.m_gbProdutos.Controls.Add(this.m_lvProdutos);
			this.m_gbProdutos.Controls.Add(this.m_treeVProdutos);
			this.m_gbProdutos.Location = new System.Drawing.Point(200, 8);
			this.m_gbProdutos.Name = "m_gbProdutos";
			this.m_gbProdutos.Size = new System.Drawing.Size(520, 256);
			this.m_gbProdutos.TabIndex = 74;
			this.m_gbProdutos.TabStop = false;
			this.m_gbProdutos.Text = "Produto";
			// 
			// m_lvProdutos
			// 
			this.m_lvProdutos.AllowColumnReorder = true;
			this.m_lvProdutos.AllowDrop = true;
			this.m_lvProdutos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lvProdutos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						   this.m_chCodigo,
																						   this.m_chDescricao,
																						   this.m_chNCM,
																						   this.m_chNALADI,
																						   this.m_chIdioma});
			this.m_lvProdutos.FullRowSelect = true;
			this.m_lvProdutos.HideSelection = false;
			this.m_lvProdutos.Location = new System.Drawing.Point(8, 13);
			this.m_lvProdutos.Name = "m_lvProdutos";
			this.m_lvProdutos.Size = new System.Drawing.Size(249, 235);
			this.m_lvProdutos.TabIndex = 0;
			this.m_ttDica.SetToolTip(this.m_lvProdutos, "Lista de produtos da categoria selecionada");
			this.m_lvProdutos.View = System.Windows.Forms.View.Details;
			this.m_lvProdutos.DoubleClick += new System.EventHandler(this.m_lvProdutos_DoubleClick);
			this.m_lvProdutos.DragOver += new System.Windows.Forms.DragEventHandler(this.m_lvProdutos_DragOver);
			this.m_lvProdutos.DragDrop += new System.Windows.Forms.DragEventHandler(this.m_lvProdutos_DragDrop);
			this.m_lvProdutos.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.m_lvProdutos_ColumnClick);
			this.m_lvProdutos.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_lvProdutos_MouseUp);
			this.m_lvProdutos.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.m_lvProdutos_ItemDrag);
			this.m_lvProdutos.KeyUp += new System.Windows.Forms.KeyEventHandler(this.m_lvProdutos_KeyUp);
			// 
			// m_chCodigo
			// 
			this.m_chCodigo.Text = "Código";
			this.m_chCodigo.Width = 50;
			// 
			// m_chDescricao
			// 
			this.m_chDescricao.Text = "Descrição do Produto";
			this.m_chDescricao.Width = 150;
			// 
			// m_chNCM
			// 
			this.m_chNCM.Text = "NCM";
			this.m_chNCM.Width = 70;
			// 
			// m_chNALADI
			// 
			this.m_chNALADI.Text = "NALADI";
			this.m_chNALADI.Width = 70;
			// 
			// m_chIdioma
			// 
			this.m_chIdioma.Text = "Idioma";
			// 
			// m_treeVProdutos
			// 
			this.m_treeVProdutos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_treeVProdutos.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_treeVProdutos.HideSelection = false;
			this.m_treeVProdutos.ImageList = this.m_ilProdutos;
			this.m_treeVProdutos.Location = new System.Drawing.Point(262, 13);
			this.m_treeVProdutos.Name = "m_treeVProdutos";
			this.m_treeVProdutos.Size = new System.Drawing.Size(249, 235);
			this.m_treeVProdutos.TabIndex = 0;
			this.m_ttDica.SetToolTip(this.m_treeVProdutos, "Composição dos produtos da categoria selecionada");
			this.m_treeVProdutos.DoubleClick += new System.EventHandler(this.m_treeVProdutos_DoubleClick);
			this.m_treeVProdutos.KeyUp += new System.Windows.Forms.KeyEventHandler(this.m_treeVProdutos_KeyUp);
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(334, 488);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 64;
			this.m_ttDica.SetToolTip(this.m_btOk, "Salvar e sair");
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(398, 488);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 65;
			this.m_ttDica.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_ckApenasProdutosCodigo
			// 
			this.m_ckApenasProdutosCodigo.Location = new System.Drawing.Point(482, 496);
			this.m_ckApenasProdutosCodigo.Name = "m_ckApenasProdutosCodigo";
			this.m_ckApenasProdutosCodigo.Size = new System.Drawing.Size(200, 16);
			this.m_ckApenasProdutosCodigo.TabIndex = 77;
			this.m_ckApenasProdutosCodigo.Text = "Apenas produtos da fatura.";
			this.m_ckApenasProdutosCodigo.CheckedChanged += new System.EventHandler(this.m_ckApenasProdutosCodigo_CheckedChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(312, 24);
			this.label1.TabIndex = 1;
			this.label1.Text = "<IDIOMA> <NCM> <NALADI> <CODIGO> PRODUTO";
			// 
			// m_ttDica
			// 
			this.m_ttDica.AutomaticDelay = 100;
			this.m_ttDica.AutoPopDelay = 5000;
			this.m_ttDica.InitialDelay = 100;
			this.m_ttDica.ReshowDelay = 20;
			// 
			// m_cmCategoria
			// 
			this.m_cmCategoria.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						  this.m_miCategoriaVisualizarCodigo,
																						  this.menuItem2,
																						  this.m_miCategoriaNova,
																						  this.m_miCategoriaEditar,
																						  this.m_miCategoriaExcluir});
			// 
			// m_miCategoriaVisualizarCodigo
			// 
			this.m_miCategoriaVisualizarCodigo.Index = 0;
			this.m_miCategoriaVisualizarCodigo.Text = "Visualizar Código";
			this.m_miCategoriaVisualizarCodigo.Click += new System.EventHandler(this.m_miCategoriaVisualizarCodigo_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.Text = "-";
			// 
			// m_miCategoriaNova
			// 
			this.m_miCategoriaNova.Index = 2;
			this.m_miCategoriaNova.Text = "Nova";
			this.m_miCategoriaNova.Click += new System.EventHandler(this.m_miCategoriaNova_Click);
			// 
			// m_miCategoriaEditar
			// 
			this.m_miCategoriaEditar.Index = 3;
			this.m_miCategoriaEditar.Text = "Editar";
			this.m_miCategoriaEditar.Click += new System.EventHandler(this.m_miCategoriaEditar_Click);
			// 
			// m_miCategoriaExcluir
			// 
			this.m_miCategoriaExcluir.Index = 4;
			this.m_miCategoriaExcluir.Text = "Excluir";
			this.m_miCategoriaExcluir.Click += new System.EventHandler(this.m_miCategoriaExcluir_Click);
			// 
			// m_cmNcm
			// 
			this.m_cmNcm.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.m_miNcmNova,
																					this.m_miNcmEditar,
																					this.m_miNcmExcluir});
			// 
			// m_miNcmNova
			// 
			this.m_miNcmNova.Index = 0;
			this.m_miNcmNova.Text = "Nova";
			this.m_miNcmNova.Click += new System.EventHandler(this.m_miNcmNova_Click);
			// 
			// m_miNcmEditar
			// 
			this.m_miNcmEditar.Index = 1;
			this.m_miNcmEditar.Text = "Editar";
			this.m_miNcmEditar.Click += new System.EventHandler(this.m_miNcmEditar_Click);
			// 
			// m_miNcmExcluir
			// 
			this.m_miNcmExcluir.Index = 2;
			this.m_miNcmExcluir.Text = "Excluir";
			this.m_miNcmExcluir.Click += new System.EventHandler(this.m_miNcmExcluir_Click);
			// 
			// m_cmNaladi
			// 
			this.m_cmNaladi.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.m_miNaladiNova,
																					   this.m_miNaladiEditar,
																					   this.m_miNaladiExcluir});
			// 
			// m_miNaladiNova
			// 
			this.m_miNaladiNova.Index = 0;
			this.m_miNaladiNova.Text = "Nova";
			this.m_miNaladiNova.Click += new System.EventHandler(this.m_miNaladiNova_Click);
			// 
			// m_miNaladiEditar
			// 
			this.m_miNaladiEditar.Index = 1;
			this.m_miNaladiEditar.Text = "Editar";
			this.m_miNaladiEditar.Click += new System.EventHandler(this.m_miNaladiEditar_Click);
			// 
			// m_miNaladiExcluir
			// 
			this.m_miNaladiExcluir.Index = 2;
			this.m_miNaladiExcluir.Text = "Excluir";
			this.m_miNaladiExcluir.Click += new System.EventHandler(this.m_miNaladiExcluir_Click);
			// 
			// m_cmLvProdutos
			// 
			this.m_cmLvProdutos.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						   this.m_miLvProdutosNovo,
																						   this.m_miLvProdutosEditar,
																						   this.m_miLvProdutosExcluir,
																						   this.menuItem3,
																						   this.m_miLvProdutosDesvinvularNcm,
																						   this.m_miLvProdutosDesvinvularNaladi,
																						   this.m_miLvDesvincularNcmENaladi,
																						   this.menuItem1,
																						   this.m_miLvDesvincularProdutosFilhos});
			// 
			// m_miLvProdutosNovo
			// 
			this.m_miLvProdutosNovo.Index = 0;
			this.m_miLvProdutosNovo.Text = "Novo";
			this.m_miLvProdutosNovo.Click += new System.EventHandler(this.m_miLvProdutosNovo_Click);
			// 
			// m_miLvProdutosEditar
			// 
			this.m_miLvProdutosEditar.Index = 1;
			this.m_miLvProdutosEditar.Text = "Editar";
			this.m_miLvProdutosEditar.Click += new System.EventHandler(this.m_miLvProdutosEditar_Click);
			// 
			// m_miLvProdutosExcluir
			// 
			this.m_miLvProdutosExcluir.Index = 2;
			this.m_miLvProdutosExcluir.Text = "Excluir";
			this.m_miLvProdutosExcluir.Click += new System.EventHandler(this.m_miLvProdutosExcluir_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 3;
			this.menuItem3.Text = "-";
			// 
			// m_miLvProdutosDesvinvularNcm
			// 
			this.m_miLvProdutosDesvinvularNcm.Index = 4;
			this.m_miLvProdutosDesvinvularNcm.Text = "Desvincular Ncm";
			this.m_miLvProdutosDesvinvularNcm.Click += new System.EventHandler(this.m_miLvProdutosDesvinvularNcm_Click);
			// 
			// m_miLvProdutosDesvinvularNaladi
			// 
			this.m_miLvProdutosDesvinvularNaladi.Index = 5;
			this.m_miLvProdutosDesvinvularNaladi.Text = "Desvincular Naladi";
			this.m_miLvProdutosDesvinvularNaladi.Click += new System.EventHandler(this.m_miLvProdutosDesvinvularNaladi_Click);
			// 
			// m_miLvDesvincularNcmENaladi
			// 
			this.m_miLvDesvincularNcmENaladi.Index = 6;
			this.m_miLvDesvincularNcmENaladi.Text = "Desvincular Ncm e Naladi";
			this.m_miLvDesvincularNcmENaladi.Click += new System.EventHandler(this.m_miLvDesvincularNcmENaladi_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 7;
			this.menuItem1.Text = "-";
			// 
			// m_miLvDesvincularProdutosFilhos
			// 
			this.m_miLvDesvincularProdutosFilhos.Index = 8;
			this.m_miLvDesvincularProdutosFilhos.Text = "Desvincular Produtos Filhos";
			this.m_miLvDesvincularProdutosFilhos.Click += new System.EventHandler(this.m_miLvDesvincularProdutosFilhos_Click);
			// 
			// m_tmProdutos
			// 
			this.m_tmProdutos.Enabled = true;
			this.m_tmProdutos.Interval = 500;
			this.m_tmProdutos.Tick += new System.EventHandler(this.m_tmProdutos_Tick);
			// 
			// frmFProdutos
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(744, 528);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFProdutos";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Cadastro de Produtos";
			this.Load += new System.EventHandler(this.frmFProdutos_Load);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmFProdutos_KeyUp);
			this.m_gbCategoria.ResumeLayout(false);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbNaladi.ResumeLayout(false);
			this.m_gbNcm.ResumeLayout(false);
			this.m_gbProdutos.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFProdutos_Load(object sender, System.EventArgs e)
				{
					mostraCor();
					OnCallRefreshIdioma();
					OnCallRefreshLvNcm();
					OnCallRefreshLvNaladi();
					OnCallRefreshTvCategorias();
					RefreshInterface();
					m_tvCategoria.SelectedNode = m_tvCategoria.Nodes[0];
					m_ckApenasProdutosCodigo.Visible = OnCallMostrarApenasProdutosCodigo();
					OnCallRefreshTreeVProdutos((int)m_tvCategoria.SelectedNode.Tag);
					OnCallRefreshListVProdutos((int)m_tvCategoria.SelectedNode.Tag);
					m_tmProdutos.Start();
				}

				private void frmFProdutos_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
				{
					if (e.KeyCode == System.Windows.Forms.Keys.L)
						if (e.Control)
							OnCallProcurar();
				}
			#endregion
			#region ListView
				private void m_lvProdutos_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
				{
					this.m_lvProdutos.Sorting = ((this.m_lvProdutos.Sorting.Equals(SortOrder.Ascending)) ? SortOrder.Descending: SortOrder.Ascending );
					this.m_lvProdutos.ListViewItemSorter = new mdlComponentesColecoes.ListViewOrder(this.m_lvProdutos.Sorting,e.Column);
					this.m_lvProdutos.Sort();
				}
			#endregion
			#region Botoes
				private void m_btLocalizar_Click(object sender, System.EventArgs e)
				{
					OnCallProcurar();
				}

				private void m_btAtributos_Click(object sender, System.EventArgs e)
				{
					OnCallShowDialogAtributos();
				}

				private void m_btPropriedades_Click(object sender, System.EventArgs e)
				{
					OnCallShowDialogPropriedades();
				}

				private void m_btClassificacaoTarifaria_Click(object sender, System.EventArgs e)
				{
					if (OnCallShowDialogPequisaClassificacaoTarifaria())
						OnCallRefreshLvNcm();
				}
			#endregion
			#region CheckBoxes
				private void m_ckApenasProdutosCodigo_CheckedChanged(object sender, System.EventArgs e)
				{
					if (OnCallApenasProdutosCodigo())
						OnCallRefreshListVProdutos((int)m_tvCategoria.SelectedNode.Tag);
				}
			#endregion
		#endregion

		#region Eventos do Formulário
			private void m_ckNcm_CheckedChanged(object sender, System.EventArgs e)
			{
				Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (m_tvCategoria.SelectedNode != null)
				{
					OnCallRefreshTreeVProdutos((int)m_tvCategoria.SelectedNode.Tag);
					OnCallRefreshListVProdutos((int)m_tvCategoria.SelectedNode.Tag);
				}
				else
				{
					OnCallRefreshTreeVProdutos(-2);
					OnCallRefreshListVProdutos(-2);
				}
				RefreshInterface();
				if (m_ckNcm.Checked)
				{
					this.m_ttDica.SetToolTip(this.m_ckNcm,"Ocultar Ncm's");
				}
				else
				{
					this.m_ttDica.SetToolTip(this.m_ckNcm,"Visualizar Ncm's");
					mostraBalao();
				}
				Cursor = System.Windows.Forms.Cursors.Default;
			}

			private void m_ckNaladi_CheckedChanged(object sender, System.EventArgs e)
			{
				Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (m_tvCategoria.SelectedNode != null)
				{
					OnCallRefreshTreeVProdutos((int)m_tvCategoria.SelectedNode.Tag);
					OnCallRefreshListVProdutos((int)m_tvCategoria.SelectedNode.Tag);
				}
				else
				{
					OnCallRefreshTreeVProdutos(-2);
					OnCallRefreshListVProdutos(-2);
				}
				if (m_ckNaladi.Checked)
				{
					this.m_ttDica.SetToolTip(this.m_ckNaladi,"Ocultar Naladi's");
				}
				else
				{
					this.m_ttDica.SetToolTip(this.m_ckNaladi,"Visualizar Naladi's");
					mostraBalao();
				}
				RefreshInterface();
				Cursor = System.Windows.Forms.Cursors.Default;
			}

			private void m_ckCategorias_CheckedChanged(object sender, System.EventArgs e)
			{
				Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (m_tvCategoria.SelectedNode != null)
				{
					OnCallRefreshTreeVProdutos((int)m_tvCategoria.SelectedNode.Tag);
					OnCallRefreshListVProdutos((int)m_tvCategoria.SelectedNode.Tag);
				}
				else
				{
					OnCallRefreshTreeVProdutos(-2);
					OnCallRefreshListVProdutos(-2);
				}
				if (m_ckCategorias.Checked)
				{
					this.m_ttDica.SetToolTip(this.m_ckCategorias,"Ocultar Categorias");
				}
				else
				{
					this.m_ttDica.SetToolTip(this.m_ckCategorias,"Visualizar Categorias");
					mostraBalao();
				}
				RefreshInterface();
				Cursor = System.Windows.Forms.Cursors.Default;
			}

			private void m_ckTreeView_CheckedChanged(object sender, System.EventArgs e)
			{
				Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (m_tvCategoria.SelectedNode != null)
				{
					OnCallRefreshTreeVProdutos((int)m_tvCategoria.SelectedNode.Tag);
					OnCallRefreshListVProdutos((int)m_tvCategoria.SelectedNode.Tag);
				}
				else
				{
					OnCallRefreshTreeVProdutos(-2);
					OnCallRefreshListVProdutos(-2);
				}
				if (m_ckTreeView.Checked)
				{
					this.m_ttDica.SetToolTip(this.m_ckTreeView,"Ocultar Composição dos Produtos");
				}
				else
				{
					this.m_ttDica.SetToolTip(this.m_ckTreeView,"Visualizar Composição dos Produtos");
					mostraBalao();
				}
				RefreshInterface();
				Cursor = System.Windows.Forms.Cursors.Default;
			}
			private void m_btOk_Click(object sender, System.EventArgs e)
			{
				Cursor = System.Windows.Forms.Cursors.WaitCursor;
				OnCallSalvaDados();
				Cursor = System.Windows.Forms.Cursors.Default;
				this.Close();
			}

			private void m_btCancelar_Click(object sender, System.EventArgs e)
			{
				m_bModificado = false;
				this.Close();
			}
			private void m_btSalvar_Click(object sender, System.EventArgs e)
			{
				Cursor = System.Windows.Forms.Cursors.WaitCursor;
				OnCallSalvaDadosSemSair();
				// Recarrega
				OnCallRefreshIdioma();
				OnCallRefreshLvNcm();
				OnCallRefreshLvNaladi();
				OnCallRefreshTvCategorias();
				RefreshInterface();
				// Selecionando o Nodo da Categoria "Sem Categoria"
				m_tvCategoria.SelectedNode = m_tvCategoria.Nodes[0]/*.Nodes[0]*/;//soh comentado para rodar.......
				OnCallRefreshTreeVProdutos((int)m_tvCategoria.SelectedNode.Tag);
				OnCallRefreshListVProdutos((int)m_tvCategoria.SelectedNode.Tag);
				Cursor = System.Windows.Forms.Cursors.Default;
			}
			private void m_tmProdutos_Tick(object sender, System.EventArgs e)
			{
				m_tmProdutos.Stop();
				mostraBalao();
			}
		#endregion
		#region Eventos da Tree View Categoria

			private void m_tvCategoria_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
			{
				if (m_bAtivado == true)
				{
					m_bAtivado = false;
					if (m_tvCategoria.SelectedNode != null)
					{
						Cursor = System.Windows.Forms.Cursors.WaitCursor;
						OnCallRefreshTreeVProdutos((int)m_tvCategoria.SelectedNode.Tag);
						OnCallRefreshListVProdutos((int)m_tvCategoria.SelectedNode.Tag);
						m_tvCategoria.SelectedNode.Expand();
						Cursor = System.Windows.Forms.Cursors.Default;
					}
					m_bAtivado = true;
				}
			}

			private void m_tvCategoria_ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
			{
				System.Windows.Forms.TreeNode tvnNodo;
				tvnNodo = (System.Windows.Forms.TreeNode)e.Item;
				if (((int)tvnNodo.Tag != 0) && (int)tvnNodo.Tag != -1)
				{
					m_strControleOndeSaiuObjeto = "m_tvCategoria";
					m_tvCategoria.DoDragDrop(e.Item,System.Windows.Forms.DragDropEffects.Move);
				}
			}

			private void m_tvCategoria_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
			{
				System.Windows.Forms.TreeNode tvnNodoMouse;
				tvnNodoMouse = m_tvCategoria.GetNodeAt(m_tvCategoria.PointToClient(new System.Drawing.Point(e.X,e.Y)));
				if (tvnNodoMouse != null)
				{
					switch(m_strControleOndeSaiuObjeto)
					{
						case "m_tvCategoria":
							// Tree View Categoria 
							if ((int)tvnNodoMouse.Tag != -1)
							{
								System.Windows.Forms.TreeNode tvnNodoMover;
								tvnNodoMover = (System.Windows.Forms.TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode"); 
								if (((int)tvnNodoMouse.Tag != (int)tvnNodoMover.Tag) && (!bNodoFilho(tvnNodoMover,tvnNodoMouse)) && ((int)tvnNodoMouse.Tag != (int)tvnNodoMover.Parent.Tag))
									e.Effect = System.Windows.Forms.DragDropEffects.Move;
								else
									e.Effect = System.Windows.Forms.DragDropEffects.None;
							}
							else
							{
								e.Effect = System.Windows.Forms.DragDropEffects.None;
							}
							break;
						case "m_treeVProdutos":
							// List View dos Produtos 
							if ((int)tvnNodoMouse.Tag != 0)
								e.Effect = System.Windows.Forms.DragDropEffects.Move;
							else
								e.Effect = System.Windows.Forms.DragDropEffects.None;
							break;
						case "m_lvProdutos":
							// List View dos Produtos
							if ((int)tvnNodoMouse.Tag != 0)
								e.Effect = System.Windows.Forms.DragDropEffects.Move;
							else
								e.Effect = System.Windows.Forms.DragDropEffects.None;
							break;
						default:
							e.Effect = System.Windows.Forms.DragDropEffects.None;
							break;
					}
				}else{
					e.Effect = System.Windows.Forms.DragDropEffects.None;
				}
			}

			private bool bNodoFilho(System.Windows.Forms.TreeNode tvnNodoPai,System.Windows.Forms.TreeNode tvnNodoFilho)
			{
                bool bRetorno = false;
				while (tvnNodoFilho.Parent != null)
				{
					if (tvnNodoFilho.Equals(tvnNodoPai))
						return(true);
					tvnNodoFilho = tvnNodoFilho.Parent;                    						
				}
				return(bRetorno);
			}

			private void m_tvCategoria_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
			{
				if (m_bAtivado == true)
				{
					m_bAtivado = false;
					System.Windows.Forms.TreeNode tvnNodoMouse;
					tvnNodoMouse = m_tvCategoria.GetNodeAt(m_tvCategoria.PointToClient(new System.Drawing.Point(e.X,e.Y)));
					if ((tvnNodoMouse != null) && (e.Effect == System.Windows.Forms.DragDropEffects.Move))
					{
						switch(m_strControleOndeSaiuObjeto)
						{
							case "m_tvCategoria":
								System.Windows.Forms.TreeNode tvnNodoMover;
								tvnNodoMover = (System.Windows.Forms.TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode"); 
								System.Windows.Forms.TreeNode tvnNodoClone;
								tvnNodoClone = (System.Windows.Forms.TreeNode)tvnNodoMover.Clone();
								tvnNodoMover.Remove();
								tvnNodoMouse.Nodes.Add(tvnNodoClone);
								OnCallTrocarSuperCategoriaDaCategoria((int)tvnNodoClone.Tag,(int)tvnNodoMouse.Tag);
								break;
							case "m_treeVProdutos":
								m_bAtivado = false;
								System.Collections.ArrayList arlProdutos;
								arlProdutos = (System.Collections.ArrayList)e.Data.GetData("System.Collections.ArrayList"); 
								OnCallTrocarCategoriaArrayListProdutos(arlProdutos,(int)tvnNodoMouse.Tag);
								m_tvCategoria.Focus();
								m_bAtivado = true;
								if (m_tvCategoria.SelectedNode != null)
								{
									OnCallRefreshTreeVProdutos((int)m_tvCategoria.SelectedNode.Tag);
									OnCallRefreshListVProdutos((int)m_tvCategoria.SelectedNode.Tag);
								}
								break;
							case "m_lvProdutos":
								System.Collections.ArrayList arlProdutosLista;
								arlProdutosLista = (System.Collections.ArrayList)e.Data.GetData("System.Collections.ArrayList");
								m_tvCategoria.Focus();
								OnCallTrocarCategoriaArrayListProdutos(arlProdutosLista,(int)tvnNodoMouse.Tag);
								m_bAtivado = true;
								if (m_tvCategoria.SelectedNode != null)
								{
									OnCallRefreshTreeVProdutos((int)m_tvCategoria.SelectedNode.Tag);
									OnCallRefreshListVProdutos((int)m_tvCategoria.SelectedNode.Tag);
								}
								break;
						}
					}
					m_bAtivado = true;
				}
			}

			/// <summary>
			/// Acionando o Context Menu 
			/// </summary>
			/// <param name="sender"></param>
			/// <param name="e"></param>
			private void m_tvCategoria_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
			{
				if (e.Button == System.Windows.Forms.MouseButtons.Right)
				{
					System.Windows.Forms.TreeNode tvnNodoMouse;
					m_ptMouse = new System.Drawing.Point(e.X,e.Y);
					tvnNodoMouse = m_tvCategoria.GetNodeAt(m_ptMouse);
					if (tvnNodoMouse != null)
					{
						m_tvCategoria.SelectedNode = tvnNodoMouse;
						OnCallInformarMostrarCodigo((int)tvnNodoMouse.Tag);
						m_miCategoriaVisualizarCodigo.Checked = m_bMostrarCodigo;
						if (((int)tvnNodoMouse.Tag != 0) && ((int)tvnNodoMouse.Tag != -1))
						{
							m_miCategoriaVisualizarCodigo.Enabled = true;
							m_miCategoriaEditar.Enabled = true;
							m_miCategoriaExcluir.Enabled = true;
						}
						else
						{
							m_miCategoriaVisualizarCodigo.Enabled = true;
							m_miCategoriaEditar.Enabled = false;
							m_miCategoriaExcluir.Enabled = false;
						}
						if ((int)tvnNodoMouse.Tag != -1)
							m_miCategoriaNova.Enabled = true;	
						else
							m_miCategoriaNova.Enabled = false;	
					}
					else
					{						
						m_miCategoriaNova.Enabled = true;	
						m_miCategoriaVisualizarCodigo.Checked = false;	
						m_miCategoriaVisualizarCodigo.Enabled = false;
						m_miCategoriaEditar.Enabled = false;
						m_miCategoriaExcluir.Enabled = false;
					}
					m_cmCategoria.Show(m_tvCategoria,new System.Drawing.Point(e.X,e.Y));
				}
				else if (e.Button == System.Windows.Forms.MouseButtons.Left)
				{
					System.Windows.Forms.TreeNode tvnNodoMouse;
					m_ptMouse = new System.Drawing.Point(e.X,e.Y);
					tvnNodoMouse = m_tvCategoria.GetNodeAt(m_ptMouse);
					if (tvnNodoMouse == null)
					{
						m_miCategoriaNova_Click(sender, e);
					}
				}
			}

			private void m_tvCategoria_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
			{
				switch(e.KeyData)
				{
					case System.Windows.Forms.Keys.Insert:
						m_miCategoriaNova_Click(sender,new System.EventArgs());
						break;
					case System.Windows.Forms.Keys.F2:
						if (m_tvCategoria.SelectedNode != null)
						{
							m_miCategoriaEditar_Click(sender,new System.EventArgs());
						}
						break;
					case System.Windows.Forms.Keys.Delete:
						if (m_tvCategoria.SelectedNode != null)
						{
							if (m_tvCategoria.SelectedNode.Text == "Todas")
							{
								mdlMensagens.clsMensagens.ShowInformation("Siscobras", mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlProdutosGeral_frmFProdutos_ExcluirTodas), System.Windows.Forms.MessageBoxButtons.OK);
							}
							else if (m_tvCategoria.SelectedNode.Text == "Sem Categoria")
							{
								mdlMensagens.clsMensagens.ShowInformation("Siscobras", mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlProdutosGeral_frmFProdutos_ExcluirSemCategoria), System.Windows.Forms.MessageBoxButtons.OK);
							}
							else
							{
								m_miCategoriaExcluir_Click(sender,new System.EventArgs());
							}
						}
						break;
				}
			}
			private void m_tvCategoria_DoubleClick(object sender, System.EventArgs e)
			{
				m_miCategoriaEditar_Click(sender, e);
			}
		#endregion
		#region Eventos da Tree View Produtos
		private void m_treeVProdutos_DoubleClick(object sender, System.EventArgs e)
		{
			if (m_bAtivado == true)
			{
				m_bAtivado = false;
				if (m_treeVProdutos.SelectedNode != null)
				{
					OnCallSelecionaProdutosAPartirTreeView();
				}
				m_bAtivado = true;
			}
		}
		private void m_treeVProdutos_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				switch(e.KeyData)
				{
					case System.Windows.Forms.Keys.Insert:
						m_miLvProdutosNovo_Click(sender,new System.EventArgs());
						break;
					case System.Windows.Forms.Keys.F2:
						if (m_lvProdutos.SelectedItems.Count == 1)
						{
							m_miLvProdutosEditar_Click(sender,new System.EventArgs());
						}
						break;
					case System.Windows.Forms.Keys.Delete:
						if (m_lvProdutos.SelectedItems.Count > 0)
						{
							m_miLvProdutosExcluir_Click(sender,new System.EventArgs());
						}
						break;
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Eventos da ListView Ncm
			private void m_lvNcm_ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
			{
				if (m_lvNcm.SelectedItems.Count > 0)
				{
					m_strControleOndeSaiuObjeto = "m_lvNcm";
					m_lvNcm.DoDragDrop(m_lvNcm.SelectedItems[0],System.Windows.Forms.DragDropEffects.Copy);
				}
			}

			private void m_lvNcm_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
			{
				if (e.Button == System.Windows.Forms.MouseButtons.Left)
				{
					if (m_lvNcm.SelectedItems.Count == 0 )
					{
						m_miNcmNova_Click(sender,new System.EventArgs());
					}
				}
				else if (e.Button == System.Windows.Forms.MouseButtons.Right)
				{
					System.Windows.Forms.ListViewItem lviMouse;
					m_ptMouse = new System.Drawing.Point(e.X,e.Y);
					lviMouse = m_lvNcm.GetItemAt(m_ptMouse.X,m_ptMouse.Y);
					if (lviMouse != null)
					{
						m_miNcmEditar.Enabled = true;
						m_miNcmExcluir.Enabled = true;
					}
					else
					{
						m_miNcmEditar.Enabled = false;
						m_miNcmExcluir.Enabled = false;
					}
					m_cmNcm.Show(m_lvNcm,new System.Drawing.Point(e.X,e.Y));
				}
			}

			private void m_lvNcm_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
			{
				switch(e.KeyData)
				{
					case System.Windows.Forms.Keys.Insert:
						m_miNcmNova_Click(sender,new System.EventArgs());
						break;
					case System.Windows.Forms.Keys.F2:
						if (m_lvNcm.SelectedItems.Count >= 0 )
						{
							m_miNcmEditar_Click(sender,new System.EventArgs());
						}
						break;
					case System.Windows.Forms.Keys.Delete:
						if (m_lvNcm.SelectedItems.Count >= 0 )
						{
							m_miNcmExcluir_Click(sender,new System.EventArgs());
						}
						break;
				}
			}

			private void m_lvNcm_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
			{
				switch(m_strControleOndeSaiuObjeto)
				{
					case "m_lvNaladi":
						e.Effect = System.Windows.Forms.DragDropEffects.Copy;
						break;
					default:
						e.Effect = System.Windows.Forms.DragDropEffects.None;
						break;
				}
			}

			private void m_lvNcm_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
			{
				switch(m_strControleOndeSaiuObjeto)
				{
					case "m_lvNaladi":
						System.Windows.Forms.ListViewItem lviNcm = null;
						System.Windows.Forms.ListViewItem lviNaladi = null;
                         
						lviNaladi = (System.Windows.Forms.ListViewItem)e.Data.GetData("System.Windows.Forms.ListViewItem"); 
						for (int nCont = 0 ; nCont < m_lvNcm.Items.Count;nCont++)
						{
							if (lviNaladi.Text == m_lvNcm.Items[nCont].Text)
							{
								lviNcm = m_lvNcm.Items[nCont];
								break;
							}
						}
						if (lviNcm == null)
						{
							// Criando a Ncm
							OnCallCriarNovaNcm(lviNaladi.Text,lviNaladi.SubItems[1].Text);
							// List view Item
							lviNcm = m_lvNcm.Items.Add(lviNaladi.Text);
							lviNcm.SubItems.Add(lviNaladi.SubItems[1].Text);
						}else{
							if (lviNaladi.SubItems[1].Text != lviNcm.SubItems[1].Text)
							{
								if (mdlMensagens.clsMensagens.ShowQuestion(this.Text, mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlProdutosGeral_frmFProdutos_TrocarDenominacaoNCM).Replace("\\n","\n"),System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
								{
									//if (MessageBox.Show("Já existe uma Ncm com este código. Porém, ela possui uma denominação diferente. Deseja substituí-la ?","Siscobras.NET",System.Windows.Forms.MessageBoxButtons.YesNo,System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
									//{
										// Troca a Denominação do Codigo Existente
										OnCallEditarAntigaNcm(lviNaladi.Text,lviNaladi.SubItems[1].Text);
										lviNcm.SubItems[1].Text = lviNaladi.SubItems[1].Text;
									//}
								}
							} 
						}
						break;
				}
			}
			private void m_lvNcm_DoubleClick(object sender, System.EventArgs e)
			{
				if (m_lvNcm.SelectedItems.Count >= 0 )
				{
					m_miNcmEditar_Click(sender,new System.EventArgs());
				}
			}


			/// <summary>
			/// Reordenando as Ncm's de acordo com a coluna clicada
			/// </summary>
			/// <param name="sender"></param>
			/// <param name="e"></param>
			private void m_lvNcm_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
			{
				if (m_lvNcm.Sorting == System.Windows.Forms.SortOrder.Ascending)
					m_lvNcm.Sorting = System.Windows.Forms.SortOrder.Descending;
				else
					m_lvNcm.Sorting = System.Windows.Forms.SortOrder.Ascending;
				m_lvNcm.Sort();
			}
		#endregion
		#region Eventos da ListView Naladi
			private void m_lvNaladi_ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
			{
				if (m_lvNaladi.SelectedItems.Count > 0)
				{
					m_strControleOndeSaiuObjeto = "m_lvNaladi";
					m_lvNaladi.DoDragDrop(m_lvNaladi.SelectedItems[0],System.Windows.Forms.DragDropEffects.Copy);
				}
			}
			private void m_lvNaladi_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
			{
				if (e.Button == System.Windows.Forms.MouseButtons.Left)
				{
					if (m_lvNaladi.SelectedItems.Count == 0 )
					{
						m_miNaladiNova_Click(sender,new System.EventArgs());
					}
				}
				else if (e.Button == System.Windows.Forms.MouseButtons.Right)
				{
					System.Windows.Forms.ListViewItem lviMouse;
					m_ptMouse = new System.Drawing.Point(e.X,e.Y);
					lviMouse = m_lvNaladi.GetItemAt(m_ptMouse.X,m_ptMouse.Y);
					if (lviMouse != null)
					{
						m_miNaladiEditar.Enabled = true;
						m_miNaladiExcluir.Enabled = true;
					}
					else
					{
						m_miNaladiEditar.Enabled = false;
						m_miNaladiExcluir.Enabled = false;
					}
					m_cmNaladi.Show(m_lvNaladi,new System.Drawing.Point(e.X,e.Y));
				}
			}

			private void m_lvNaladi_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
			{
				switch(e.KeyData)
				{
					case System.Windows.Forms.Keys.Insert:
						m_miNaladiNova_Click(sender,new System.EventArgs());
						break;
					case System.Windows.Forms.Keys.F2:
						if (m_lvNaladi.SelectedItems.Count >= 0 )
						{
							m_miNaladiEditar_Click(sender,new System.EventArgs());
						}
						break;
					case System.Windows.Forms.Keys.Delete:
						if (m_lvNaladi.SelectedItems.Count >= 0 )
						{
							m_miNaladiExcluir_Click(sender,new System.EventArgs());
						}
						break;
				}
			}

			private void m_lvNaladi_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
			{
				switch(m_strControleOndeSaiuObjeto)
				{
					case "m_lvNcm":
						e.Effect = System.Windows.Forms.DragDropEffects.Copy;
						break;
					default:
						e.Effect = System.Windows.Forms.DragDropEffects.None;
						break;
				}
			}

			private void m_lvNaladi_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
			{
				switch(m_strControleOndeSaiuObjeto)
				{
					case "m_lvNcm":
						System.Windows.Forms.ListViewItem lviNcm = null;
						System.Windows.Forms.ListViewItem lviNaladi = null;
	                        
						lviNcm = (System.Windows.Forms.ListViewItem)e.Data.GetData("System.Windows.Forms.ListViewItem"); 
						for (int nCont = 0 ; nCont < m_lvNaladi.Items.Count;nCont++)
						{
							if (lviNcm.Text == m_lvNaladi.Items[nCont].Text)
							{
								lviNaladi = m_lvNaladi.Items[nCont];
								break;
							}
						}
						if (lviNaladi == null)
						{
							// Criando a Naladi
							OnCallCriarNovaNaladi(lviNcm.Text,lviNcm.SubItems[1].Text);
							// List view Item
							lviNaladi = m_lvNaladi.Items.Add(lviNcm.Text);
							lviNaladi.SubItems.Add(lviNcm.SubItems[1].Text);
						}
						else
						{
							if (lviNcm.SubItems[1].Text != lviNaladi.SubItems[1].Text)
							{
								if (mdlMensagens.clsMensagens.ShowQuestion(this.Text, mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlProdutosGeral_frmFProdutos_TrocarDenominacaoNALADI).Replace("\\n","\n"),System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
								{
									//if (MessageBox.Show("Já existe uma Naladi com este código. Porém, ela possui uma denominação diferente. Deseja substituí-la ?","Siscobras.NET",System.Windows.Forms.MessageBoxButtons.YesNo,System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
									//{
										// Troca a Denominação do Codigo Existente
										OnCallEditarAntigaNaladi(lviNcm.Text,lviNcm.SubItems[1].Text);
										lviNaladi.SubItems[1].Text = lviNcm.SubItems[1].Text;
									//}
								}
							} 
						}
						break;
				}
			}

			private void m_lvNaladi_DoubleClick(object sender, System.EventArgs e)
			{
				if (m_lvNaladi.SelectedItems.Count >= 0 )
				{
					m_miNaladiEditar_Click(sender,new System.EventArgs());
				}
			}


			/// <summary>
			/// Reordenando as Naladi's de acordo com a coluna clicada
			/// </summary>
			/// <param name="sender"></param>
			/// <param name="e"></param>
			private void m_lvNaladi_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
			{
				if (m_lvNaladi.Sorting == System.Windows.Forms.SortOrder.Ascending)
					m_lvNaladi.Sorting = System.Windows.Forms.SortOrder.Descending;
				else
					m_lvNaladi.Sorting = System.Windows.Forms.SortOrder.Ascending;
				m_lvNaladi.Sort();
			}
		#endregion
		#region Eventos da ListView Produtos
		private void m_lvProdutos_ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
		{
			try
			{
				System.Collections.ArrayList arlItems = new  System.Collections.ArrayList();
				for (int nCount = 0; nCount < m_lvProdutos.SelectedItems.Count; nCount++)
				{
					arlItems.Add((int)m_lvProdutos.SelectedItems[nCount].Tag);
				}
				m_strControleOndeSaiuObjeto = "m_lvProdutos";
				m_lvProdutos.DoDragDrop(arlItems,System.Windows.Forms.DragDropEffects.Move);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void m_lvProdutos_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
		{
			try
			{
				System.Windows.Forms.ListViewItem ItemMouse/*, ItemSelecionado*/;
				System.Drawing.Point ptMouse = m_lvProdutos.PointToClient(new System.Drawing.Point(e.X,e.Y));
				ItemMouse = m_lvProdutos.GetItemAt(ptMouse.X,ptMouse.Y);
				if ((ItemMouse != null) || (m_lvProdutos.SelectedItems.Count > 0))
				{
					switch(m_strControleOndeSaiuObjeto)
					{
						case "m_lvNcm":
							e.Effect = System.Windows.Forms.DragDropEffects.Copy;
							break;
					
						case "m_lvNaladi":
							e.Effect = System.Windows.Forms.DragDropEffects.Copy;
							break;

						case "m_lvProdutos":
							e.Effect = System.Windows.Forms.DragDropEffects.Move;
							break;
					
						default:
							e.Effect = System.Windows.Forms.DragDropEffects.None;
							break;
					}
				}
			}				
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}

		private void m_lvProdutos_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			try
			{
				int nCategoria = 0;
				if (m_tvCategoria.SelectedNode != null)
                    nCategoria = (int)m_tvCategoria.SelectedNode.Tag;
				if (e.Effect == System.Windows.Forms.DragDropEffects.Copy)
				{
					System.Windows.Forms.ListViewItem ItemMouse;
					System.Drawing.Point ptMouse = m_lvProdutos.PointToClient(new System.Drawing.Point(e.X,e.Y));
					ItemMouse = m_lvProdutos.GetItemAt(ptMouse.X,ptMouse.Y);
					switch(m_strControleOndeSaiuObjeto)
					{
						case "m_lvNcm":
							// NCM 
							if ((ItemMouse != null) || m_lvProdutos.SelectedItems.Count > 0)
							{
								System.Collections.ArrayList arlProdutos = new System.Collections.ArrayList();
								if (ItemMouse != null)
									arlProdutos.Add(ItemMouse);
								foreach(System.Windows.Forms.ListViewItem lvItemProduto in m_lvProdutos.SelectedItems)
									arlProdutos.Add(lvItemProduto);
								// Adquirindo a Ncm 
								System.Windows.Forms.ListViewItem lviItem;
								lviItem = (System.Windows.Forms.ListViewItem)e.Data.GetData("System.Windows.Forms.ListViewItem"); 
								if (lviItem != null)
									OnCallTrocarNcmArrayListProdutos(arlProdutos,lviItem);
							}
							break;
						case "m_lvNaladi":
							// Naladi
							if ((ItemMouse != null) || m_lvProdutos.SelectedItems.Count > 0)
							{
								System.Collections.ArrayList arlProdutos = new System.Collections.ArrayList();
								if (ItemMouse != null)
									arlProdutos.Add(ItemMouse);
								foreach(System.Windows.Forms.ListViewItem lvItemProduto in m_lvProdutos.SelectedItems)
									arlProdutos.Add(lvItemProduto);
								// Adquirindo a Naladi 
								System.Windows.Forms.ListViewItem lviItem;
								lviItem = (System.Windows.Forms.ListViewItem)e.Data.GetData("System.Windows.Forms.ListViewItem"); 
								if (lviItem != null)
									OnCallTrocarNaladiArrayListProdutos(arlProdutos,lviItem);
							}
							break;
					}
				}
				else if (e.Effect == System.Windows.Forms.DragDropEffects.Move)
				{
					System.Windows.Forms.ListViewItem ItemMouse;
					System.Drawing.Point ptMouse = m_lvProdutos.PointToClient(new System.Drawing.Point(e.X,e.Y));
					ItemMouse = m_lvProdutos.GetItemAt(ptMouse.X,ptMouse.Y);
					switch (m_strControleOndeSaiuObjeto)
					{
						case "m_lvProdutos":
							// Produtos
							if ((ItemMouse != null) || m_lvProdutos.SelectedItems.Count > 0)
							{
								System.Collections.ArrayList arlProdutosSelecionados = new System.Collections.ArrayList();
								for (int nCount = 0; nCount < m_lvProdutos.SelectedItems.Count; nCount++)
								{
									arlProdutosSelecionados.Add(m_lvProdutos.SelectedItems[nCount]);
								}
								if ((ItemMouse != null) && (!arlProdutosSelecionados.Contains(ItemMouse)))
									OnCallProdutosSelecionadosComoProdutosFilhos(arlProdutosSelecionados, ref ItemMouse);
								else
									mdlMensagens.clsMensagens.ShowInformation("Siscobras",mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlProdutosGeral_frmFProdutos_IncluirComoProdutoFilho),System.Windows.Forms.MessageBoxButtons.OK);
							}
							break;
					}
				}
				OnCallRefreshListVProdutos(nCategoria);
				OnCallRefreshTreeVProdutos(nCategoria);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void m_lvProdutos_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			try
			{
				#region Botão Esquerdo
				if (e.Button == System.Windows.Forms.MouseButtons.Left)
				{
					if (m_lvProdutos.GetItemAt(e.X,e.Y) != null)
					{
						m_lvProdutos.GetItemAt(e.X,e.Y).Selected = true;
						if (m_bAtivado)
							OnCallSelecionaProdutosAPartirListView(e.X, e.Y);
					}
					else if (m_lvProdutos.SelectedItems.Count == 0)
					{
						m_miLvProdutosNovo_Click(sender,new System.EventArgs());
					}
				}
				#endregion
				#region Botão Direito
				else if (e.Button == System.Windows.Forms.MouseButtons.Right)
				{
					m_ptMouse = new System.Drawing.Point(e.X,e.Y);
					if (m_lvProdutos.GetItemAt(m_ptMouse.X,m_ptMouse.Y) != null)
					{
						m_miLvProdutosEditar.Enabled = true;
						m_miLvProdutosExcluir.Enabled = true;
						m_miLvProdutosDesvinvularNcm.Enabled = true;
						m_miLvProdutosDesvinvularNaladi.Enabled = true;
						m_miLvDesvincularNcmENaladi.Enabled = true;
						m_miLvDesvincularProdutosFilhos.Enabled = true;
					}
					else
					{
						m_miLvProdutosEditar.Enabled = false;
						m_miLvProdutosExcluir.Enabled = false;
						m_miLvProdutosDesvinvularNcm.Enabled = false;
						m_miLvProdutosDesvinvularNaladi.Enabled = false;
						m_miLvDesvincularNcmENaladi.Enabled = false;
						m_miLvDesvincularProdutosFilhos.Enabled = false;
					}
					m_cmLvProdutos.Show(m_lvProdutos,new System.Drawing.Point(e.X,e.Y));
				}
				#endregion
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void m_lvProdutos_DoubleClick(object sender, System.EventArgs e)
		{
			try
			{
				if (m_lvProdutos.SelectedItems.Count == 1)
				{
					m_miLvProdutosEditar_Click(sender,new System.EventArgs());
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void m_lvProdutos_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				switch(e.KeyData)
				{
					case System.Windows.Forms.Keys.Insert:
						m_miLvProdutosNovo_Click(sender,new System.EventArgs());
						break;
					case System.Windows.Forms.Keys.F2:
						if (m_lvProdutos.SelectedItems.Count == 1)
						{
							m_miLvProdutosEditar_Click(sender,new System.EventArgs());
						}
						break;
					case System.Windows.Forms.Keys.Delete:
						if (m_lvProdutos.SelectedItems.Count > 0)
						{
							m_miLvProdutosExcluir_Click(sender,new System.EventArgs());
						}
						break;
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Métodos Referentes as Cores do Formulário
		private void mostraCor()
		{
			mdlPaletaDeCores.clsPaletaDeCores clsPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini","SiscobrasCorSecundaria");
            this.BackColor = clsPaletaCores.retornaCorAtual();
			for (int nCont = 0 ;nCont < this.Controls.Count; nCont++)
			{
				this.Controls[nCont].BackColor = this.BackColor;
				for (int nCont2 = 0 ;nCont2 < this.Controls[nCont].Controls.Count; nCont2++)
				{
					if ((this.Controls[nCont].Controls[nCont2].GetType().ToString() != "mdlComponentesGraficos.ListView") && (this.Controls[nCont].Controls[nCont2].GetType().ToString() != "System.Windows.Forms.TreeView"))
						this.Controls[nCont].Controls[nCont2].BackColor = this.BackColor;

					for (int nCont3 = 0 ;nCont3 < this.Controls[nCont].Controls[nCont2].Controls.Count; nCont3++)
					{
						if ((this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "mdlComponentesGraficos.ListView") && (this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "System.Windows.Forms.TreeView") && (this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "mdlComponentesGraficos.TreeView"))
							this.Controls[nCont].Controls[nCont2].Controls[nCont3].BackColor = this.BackColor;
					}
				}
			}
		}
		#endregion
		#region Métodos Referentes ao Idioma
			public void mostraIdioma(string strIdioma,System.Drawing.Image imgIdioma)
			{
                m_lbIdioma.Text = strIdioma;
				m_btBandeira.Image = imgIdioma;
			}

			private void m_btBandeira_Click(object sender, System.EventArgs e)
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                OnCallTrocarIdioma();		
				this.Cursor = System.Windows.Forms.Cursors.Default;
				m_lvProdutos.Focus();
			}
		#endregion
		#region Métodos Referentes aos Produtos
			public void RecarregaProdutosCasoNecessario()
			{
				if (m_tvCategoria.SelectedNode != null)
				{
					Cursor = System.Windows.Forms.Cursors.WaitCursor;
					OnCallRefreshTreeVProdutos((int)m_tvCategoria.SelectedNode.Tag);
					OnCallRefreshListVProdutos((int)m_tvCategoria.SelectedNode.Tag);
					Cursor = System.Windows.Forms.Cursors.Default;
				}
			}
		#endregion 
		#region Métodos Referentes a Interface
			private void RefreshInterface()
			{
				bool bMostrarNcm ,bMostrarNaladi, bMostrasCategorias, bMostrarTreeView;
				bMostrarNcm = m_ckNcm.Checked;
				bMostrarNaladi = m_ckNaladi.Checked;
				bMostrasCategorias = m_ckCategorias.Checked;
				bMostrarTreeView = m_ckTreeView.Checked;

				if (bMostrarTreeView)
				{
					m_treeVProdutos.Visible = true;
					m_lvProdutos.SetBounds(8,13,m_gbProdutos.Width - m_treeVProdutos.Width - 21,m_gbProdutos.Height - 21);
				}
				else
				{
					m_treeVProdutos.Visible = false;
					m_lvProdutos.SetBounds(m_lvProdutos.Location.X, m_lvProdutos.Location.Y, m_gbProdutos.Width - 16, m_gbProdutos.Height - 21);
				}

				if ((bMostrarNcm) && (bMostrarNaladi) && (bMostrasCategorias)) //OK
				{
					// Mostrar NCM e NALADI
					m_gbProdutos.Height = m_gbCategoria.Height - (m_gbNcm.Height + m_gbNaladi.Height );
					m_gbProdutos.Width = m_gbGeral.Width - (m_gbCategoria.Width + m_gbCategoria.Location.X + 16);
					m_gbNcm.Width = m_gbGeral.Width - (m_gbCategoria.Width + m_gbCategoria.Location.X + 16);
					m_gbNaladi.Width = m_gbGeral.Width - (m_gbCategoria.Width + m_gbCategoria.Location.X + 16);
					m_gbProdutos.Location = new System.Drawing.Point(m_gbCategoria.Width + m_gbCategoria.Location.X + 8,m_gbProdutos.Location.Y);

					m_gbNcm.Location = new System.Drawing.Point(m_gbCategoria.Width + m_gbCategoria.Location.X + 8,m_gbProdutos.Location.Y + m_gbProdutos.Height);
					m_gbNaladi.Location = new System.Drawing.Point(m_gbCategoria.Width + m_gbCategoria.Location.X + 8,m_gbNcm.Top + m_gbNcm.Height);
					m_gbCategoria.Top = m_gbProdutos.Top;

					m_gbNcm.Visible = true;
					m_gbNaladi.Visible = true;
					m_gbCategoria.Visible = true;
				}else{
					if ((!bMostrarNcm) && (!bMostrarNaladi) && (!bMostrasCategorias))//OK
					{
						// Nao Mostrar Nenhum dos 3

						m_gbNcm.Visible = false;
						m_gbNaladi.Visible = false;
						m_gbCategoria.Visible = false;

						m_gbProdutos.Location = m_gbCategoria.Location;
						m_gbProdutos.Width = m_gbGeral.Width - 16;
						m_gbProdutos.Height = m_gbCategoria.Height;
					}else{
						if (bMostrarNcm && bMostrarNaladi)//OK
						{
							// Mostrar Somente Ncm & Naladi
							m_gbNcm.Visible = true;
							m_gbNaladi.Visible = true;
							m_gbCategoria.Visible = false;

							m_gbProdutos.Width = m_gbGeral.Width - 16;
							m_gbNcm.Width = m_gbProdutos.Width;
							m_gbNaladi.Width = m_gbProdutos.Width;

							m_gbProdutos.Height = m_gbCategoria.Height - (m_gbNcm.Height + m_gbNaladi.Height);
							m_gbProdutos.Left = 8;

							m_gbNcm.Location = new System.Drawing.Point(m_gbProdutos.Location.X,m_gbProdutos.Top + m_gbProdutos.Height);
							m_gbNaladi.Location = new System.Drawing.Point(m_gbProdutos.Location.X,m_gbNcm.Top + m_gbNcm.Height);
						}
						else if (bMostrarNcm && bMostrasCategorias)//OK
						{
							// Mostrar Somente Ncm & Categorias
							m_gbNcm.Visible = true;
							m_gbNaladi.Visible = false;
							m_gbCategoria.Visible = true;

							m_gbProdutos.Width = m_gbGeral.Width - (m_gbCategoria.Width + m_gbCategoria.Location.X + 16);
							m_gbProdutos.Height = m_gbCategoria.Height - (m_gbNcm.Height);
							m_gbNcm.Width = m_gbProdutos.Width;

							m_gbProdutos.Location = new System.Drawing.Point(m_gbCategoria.Width + m_gbCategoria.Location.X + 8,m_gbProdutos.Location.Y);

							m_gbNcm.Location = new System.Drawing.Point(m_gbCategoria.Location.X + m_gbCategoria.Width + 8,m_gbProdutos.Top + m_gbProdutos.Height); 
						} 
						else if (bMostrarNaladi && bMostrasCategorias) //OK
						{
							// Mostrar Somente Ncm & Categorias
							m_gbNcm.Visible = false;
							m_gbNaladi.Visible = true;
							m_gbCategoria.Visible = true;

							m_gbProdutos.Width = m_gbGeral.Width - (m_gbCategoria.Width + m_gbCategoria.Location.X + 16);
							m_gbProdutos.Height = m_gbCategoria.Height - (m_gbNaladi.Height);
							m_gbNaladi.Width = m_gbProdutos.Width;

							m_gbProdutos.Location = new System.Drawing.Point(m_gbCategoria.Width + m_gbCategoria.Location.X + 8,m_gbProdutos.Location.Y);

							m_gbNaladi.Location = new System.Drawing.Point(m_gbCategoria.Location.X + m_gbCategoria.Width + 8,m_gbProdutos.Top + m_gbProdutos.Height); 
						}
						else
						{
							if (bMostrarNcm)//OK
							{
								// Mostrar Somente Ncm
								m_gbNcm.Visible = true;
								m_gbNaladi.Visible = false;
								m_gbCategoria.Visible = false;

								m_gbProdutos.Height = m_gbCategoria.Height - (m_gbNcm.Height);

								m_gbProdutos.Location = m_gbCategoria.Location;
								m_gbNcm.Location = new System.Drawing.Point(m_gbCategoria.Location.X,m_gbProdutos.Top + m_gbProdutos.Height);
								m_gbProdutos.Width = m_gbGeral.Width - 16;
								m_gbNcm.Width = m_gbProdutos.Width;
							}
							else if (bMostrarNaladi)//OK
							{
								// Mostrar Somente Naladi
								m_gbNcm.Visible = false;
								m_gbNaladi.Visible = true;
								m_gbCategoria.Visible = false;

								m_gbProdutos.Height = m_gbCategoria.Height - (m_gbNaladi.Height);

								m_gbProdutos.Location = m_gbCategoria.Location;
								m_gbNaladi.Location = new System.Drawing.Point(m_gbCategoria.Location.X,m_gbProdutos.Top + m_gbProdutos.Height);
								m_gbProdutos.Width = m_gbGeral.Width - 16;
								m_gbNaladi.Width = m_gbProdutos.Width;
							} 
							else //OK
							{
								// Mostrar Somente Categorias
								m_gbNcm.Visible = false;
								m_gbNaladi.Visible = false;
								m_gbCategoria.Visible = true;

								m_gbProdutos.Width = m_gbGeral.Width - (m_gbCategoria.Width + m_gbCategoria.Location.X + 16);
								m_gbProdutos.Height = m_gbCategoria.Height;

								m_gbProdutos.Location = new System.Drawing.Point(m_gbCategoria.Width + m_gbCategoria.Location.X + 8,m_gbProdutos.Location.Y);
							}
						}
					}
				}
				this.Refresh();
			}
		#endregion

		#region Métodos Referentes aos Menu Contexts
			#region Categoria
				/// <summary>
				/// Trocando a Propriedade Mostrar codigo da Categoria 
				/// </summary>
				/// <param name="sender"></param>
				/// <param name="e"></param>
				private void m_miCategoriaVisualizarCodigo_Click(object sender, System.EventArgs e)
				{
					System.Windows.Forms.TreeNode tvnNodoMouse;
					tvnNodoMouse = m_tvCategoria.GetNodeAt(m_ptMouse);
					if (tvnNodoMouse != null)
					{
						this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
						m_miCategoriaVisualizarCodigo.Checked = !m_miCategoriaVisualizarCodigo.Checked;
						OnCallTrocarMostrarCodigoDaCategoria((int)tvnNodoMouse.Tag,m_miCategoriaVisualizarCodigo.Checked);
						OnCallRefreshTreeVProdutos((int)tvnNodoMouse.Tag);
						OnCallRefreshListVProdutos((int)tvnNodoMouse.Tag);
						this.Cursor = System.Windows.Forms.Cursors.Default;
					}
				}

				/// <summary>
				/// Inserindo uma Nova Categoria
				/// </summary>
				/// <param name="sender"></param>
				/// <param name="e"></param>
				private void m_miCategoriaNova_Click(object sender, System.EventArgs e)
				{
					System.Windows.Forms.TreeNode tvnNodoMouse;
					tvnNodoMouse = m_tvCategoria.SelectedNode;
					if ((tvnNodoMouse != null) && (tvnNodoMouse.Text != "Sem Categoria"))
					{
						this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
						OnCallNovaCategoria(tvnNodoMouse);
						mostraBalao();
						this.Cursor = System.Windows.Forms.Cursors.Default;
					}
					else
					{
						tvnNodoMouse = m_tvCategoria.Nodes[0];
						this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
						OnCallNovaCategoria(tvnNodoMouse);
						this.Cursor = System.Windows.Forms.Cursors.Default;
					}
				}

		        /// <summary>
		        /// Editando uma Categoria
		        /// </summary>
		        /// <param name="sender"></param>
		        /// <param name="e"></param>
 
				private void m_miCategoriaEditar_Click(object sender, System.EventArgs e)
				{
					System.Windows.Forms.TreeNode tvnNodoMouse;
					tvnNodoMouse = m_tvCategoria.SelectedNode;
					if ((tvnNodoMouse != null) && (tvnNodoMouse.Text != "Sem Categoria"))
					{
						this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
						OnCallEditarCategoria(tvnNodoMouse);
						this.Cursor = System.Windows.Forms.Cursors.Default;
					}
				}

				/// <summary>
				/// Excluindo uma Categoria 
				/// </summary>
				/// <param name="sender"></param>
				/// <param name="e"></param>
				private void m_miCategoriaExcluir_Click(object sender, System.EventArgs e)
				{
					System.Windows.Forms.TreeNode tvnNodoMouse;
					tvnNodoMouse = m_tvCategoria.SelectedNode;
					if (tvnNodoMouse != null)
					{
						this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
						OnCallExcluirCategoria(tvnNodoMouse);
						this.Cursor = System.Windows.Forms.Cursors.Default;
					}
				}
			#endregion
			#region Produto
				/// <summary>
				/// Insere um novo Produto
				/// </summary>
				/// <param name="sender"></param>
				/// <param name="e"></param>
				private void m_miLvProdutosNovo_Click(object sender, System.EventArgs e)
				{
					try
					{
						if (m_tvCategoria.SelectedNode != null)
						{
							this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
							int nCategoria = (int)m_tvCategoria.SelectedNode.Tag;
							if (nCategoria == 0)
							{
								nCategoria = -1;
								OnCallNovosProdutos(nCategoria);
								nCategoria = 0;
							}
							else
							{
								OnCallNovosProdutos(nCategoria);
							}
							OnCallRefreshTreeVProdutos(nCategoria);
							OnCallRefreshListVProdutos(nCategoria);
							mostraBalao();
							this.Cursor = System.Windows.Forms.Cursors.Default;
						}
					}
					catch (Exception err)
					{
						Object erro = err;
						m_cls_ter_tratadorErro.trataErro(ref erro);
					}
				}
				private void m_miProdutoNovo_Click(object sender, System.EventArgs e)
				{					
				}

				/// <summary>
				/// Edita um produto
				/// </summary>
				/// <param name="sender"></param>
				/// <param name="e"></param>
				private void m_miLvProdutosEditar_Click(object sender, System.EventArgs e)
				{
					try
					{
						if (m_tvCategoria.SelectedNode != null)
						{
							this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
							System.Collections.ArrayList arlProdutos = new System.Collections.ArrayList();
							for (int nCount = 0; nCount < m_lvProdutos.SelectedItems.Count; nCount++)
							{
								arlProdutos.Add(m_lvProdutos.SelectedItems[nCount]);
							}
							int nCategoria = (int)m_tvCategoria.SelectedNode.Tag;
							OnCallEditarProdutos(nCategoria,arlProdutos);
							OnCallRefreshTreeVProdutos(nCategoria);
							OnCallRefreshListVProdutos(nCategoria);
							this.Cursor = System.Windows.Forms.Cursors.Default;
						}
					}
					catch (Exception err)
					{
						Object erro = err;
						m_cls_ter_tratadorErro.trataErro(ref erro);
					}
				}
				private void m_miProdutoEditar_Click(object sender, System.EventArgs e)
				{
				}

				/// <summary>
				/// Desvincular Produtos Filhos
				/// </summary>
				/// <param name="sender"></param>
				/// <param name="e"></param>
				private void m_miLvDesvincularProdutosFilhos_Click(object sender, System.EventArgs e)
				{
					try
					{
						if ((m_tvCategoria.SelectedNode != null) && (m_lvProdutos.SelectedItems.Count > 0))
						{
							this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
							int nCategoria = (int)m_tvCategoria.SelectedNode.Tag;
							System.Windows.Forms.ListViewItem lvItemProduto = m_lvProdutos.SelectedItems[0];
							OnCallExcluirProdutosFilhos(ref lvItemProduto);
							OnCallRefreshTreeVProdutos(nCategoria);
							OnCallRefreshListVProdutos(nCategoria);
							this.Cursor = System.Windows.Forms.Cursors.Default;
						}
					}
					catch (Exception err)
					{
						Object erro = err;
						m_cls_ter_tratadorErro.trataErro(ref erro);
					}
				}
				/// <summary>
				/// Excluir Produtos
				/// </summary>
				/// <param name="sender"></param>
				/// <param name="e"></param>
				private void m_miLvProdutosExcluir_Click(object sender, System.EventArgs e)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					System.Collections.ArrayList arlProdutos = new System.Collections.ArrayList();
					int nCategoria = 0;
					if (m_tvCategoria.SelectedNode != null)
						nCategoria = (int)m_tvCategoria.SelectedNode.Tag;
					for (int nCount = 0; nCount < m_lvProdutos.SelectedItems.Count; nCount++)
						arlProdutos.Add(m_lvProdutos.SelectedItems[nCount]);
					if (m_lvProdutos.SelectedItems.Count > 0)
					{
						if (mdlMensagens.clsMensagens.ShowQuestion(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlProdutosGeral_frmFProdutos_ExcluirProdutos).Replace("TAG",arlProdutos.Count.ToString()),System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
						{
							//if (MessageBox.Show("Deseja mesmo excluir este(s) " + arlProdutos.Count + " produto(s) ?","Siscobras.NET",System.Windows.Forms.MessageBoxButtons.YesNo,System.Windows.Forms.MessageBoxIcon.Question,System.Windows.Forms.MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
							//{
								OnCallExcluirProdutos(arlProdutos);
								OnCallRefreshTreeVProdutos(nCategoria);
							//}
						}
					}
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}
				private void m_miProdutoExcluir_Click(object sender, System.EventArgs e)
				{					
				}

				/// <summary>
				/// Desvinculando a Ncm dos Produtos Selecionados 
				/// </summary>
				/// <param name="sender"></param>
				/// <param name="e"></param>
				private void m_miLvProdutosDesvinvularNcm_Click(object sender, System.EventArgs e)
				{
					try
					{
						System.Windows.Forms.ListViewItem ItemProduto;
						ItemProduto = m_lvProdutos.GetItemAt(m_ptMouse.X,m_ptMouse.Y);
						System.Collections.ArrayList arlProdutos = new System.Collections.ArrayList();
						if (ItemProduto != null)
							arlProdutos.Add(ItemProduto);
						foreach(System.Windows.Forms.ListViewItem lvItemProduto in m_lvProdutos.SelectedItems)
						{
							if (lvItemProduto != ItemProduto)
								arlProdutos.Add(lvItemProduto);
						}
						OnCallTrocarNcmArrayListProdutos(arlProdutos,null);
					}
					catch (Exception err)
					{
						Object erro = err;
						m_cls_ter_tratadorErro.trataErro(ref erro);
					}
				}
				private void m_miProdutoDesvinculaNcm_Click(object sender, System.EventArgs e)
				{
				}

				/// <summary>
				/// Desvinculando a Naladi dos Produtos Selecionados 
				/// </summary>
				/// <param name="sender"></param>
				/// <param name="e"></param>
				private void m_miLvProdutosDesvinvularNaladi_Click(object sender, System.EventArgs e)
				{
					try
					{
						System.Windows.Forms.ListViewItem ItemProduto;
						ItemProduto = m_lvProdutos.GetItemAt(m_ptMouse.X,m_ptMouse.Y);
						System.Collections.ArrayList arlProdutos = new System.Collections.ArrayList();
						if (ItemProduto != null)
							arlProdutos.Add(ItemProduto);
						foreach(System.Windows.Forms.ListViewItem lvItemProduto in m_lvProdutos.SelectedItems)
						{
							if (lvItemProduto != ItemProduto)
								arlProdutos.Add(lvItemProduto);
						}
						OnCallTrocarNaladiArrayListProdutos(arlProdutos,null);
					}
					catch (Exception err)
					{
						Object erro = err;
						m_cls_ter_tratadorErro.trataErro(ref erro);
					}
				}
				private void m_miProdutoDesvinculaNaladi_Click(object sender, System.EventArgs e)
				{
				}

				/// <summary>
				/// Desvinculando a Ncm e Naladi dos Produtos Selecionados 
				/// </summary>
				/// <param name="sender"></param>
				/// <param name="e"></param>
				private void m_miLvDesvincularNcmENaladi_Click(object sender, System.EventArgs e)
				{
					try
					{
						System.Windows.Forms.ListViewItem ItemProduto;
						ItemProduto = m_lvProdutos.GetItemAt(m_ptMouse.X,m_ptMouse.Y);
						System.Collections.ArrayList arlProdutos = new System.Collections.ArrayList();
						if (ItemProduto != null)
							arlProdutos.Add(ItemProduto);
						foreach(System.Windows.Forms.ListViewItem lvItemProduto in m_lvProdutos.SelectedItems)
						{
							if (lvItemProduto != ItemProduto)
								arlProdutos.Add(lvItemProduto);
						}
						OnCallTrocarNcmArrayListProdutos(arlProdutos,null);
						OnCallTrocarNaladiArrayListProdutos(arlProdutos,null);
					}
					catch (Exception err)
					{
						Object erro = err;
						m_cls_ter_tratadorErro.trataErro(ref erro);
					}
				}
				private void m_miProdutoDesvincilaNcmENaladi_Click(object sender, System.EventArgs e)
				{
				}
			#endregion
			#region Ncm
				private void m_miNcmNova_Click(object sender, System.EventArgs e)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					OnCallNovaNcm();
					mostraBalao();
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}

				private void m_miNcmEditar_Click(object sender, System.EventArgs e)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					System.Collections.ArrayList arlNcm = new System.Collections.ArrayList();
					for (int nCont = 0 ; nCont < m_lvNcm.SelectedItems.Count; nCont++)
						arlNcm.Add(m_lvNcm.SelectedItems[nCont]);
					OnCallEditarNcm(arlNcm);
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}

				private void m_miNcmExcluir_Click(object sender, System.EventArgs e)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					System.Collections.ArrayList arlNcm = new System.Collections.ArrayList();
					for (int nCont = 0 ; nCont < m_lvNcm.SelectedItems.Count; nCont++)
						arlNcm.Add(m_lvNcm.SelectedItems[nCont]);
					if (mdlMensagens.clsMensagens.ShowQuestion(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlProdutosGeral_frmFProdutos_ExcluirNCM), System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
					{
						//if (MessageBox.Show("Deseja mesmo excluir esta NCM?","Siscobras.NET",System.Windows.Forms.MessageBoxButtons.YesNo,System.Windows.Forms.MessageBoxIcon.Question,System.Windows.Forms.MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
						//{
							OnCallExcluirNcm(arlNcm);
						//}
					}
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}
			#endregion
			#region Naladi
				private void m_miNaladiNova_Click(object sender, System.EventArgs e)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					OnCallNovaNaladi();
					mostraBalao();
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}

				private void m_miNaladiEditar_Click(object sender, System.EventArgs e)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					System.Collections.ArrayList arlNaladi = new System.Collections.ArrayList();
					for (int nCont = 0 ; nCont < m_lvNaladi.SelectedItems.Count; nCont++)
						arlNaladi.Add(m_lvNaladi.SelectedItems[nCont]);
					OnCallEditarNaladi(arlNaladi);
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}

				private void m_miNaladiExcluir_Click(object sender, System.EventArgs e)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					System.Collections.ArrayList arlNaladi = new System.Collections.ArrayList();
					for (int nCont = 0 ; nCont < m_lvNaladi.SelectedItems.Count; nCont++)
						arlNaladi.Add(m_lvNaladi.SelectedItems[nCont]);
					if (mdlMensagens.clsMensagens.ShowQuestion(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlProdutosGeral_frmFProdutos_ExcluirNALADI), System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
					{
						//if (MessageBox.Show("Deseja mesmo excluir esta NALADI ?","Siscobras.NET",System.Windows.Forms.MessageBoxButtons.YesNo,System.Windows.Forms.MessageBoxIcon.Question,System.Windows.Forms.MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
						//{
							OnCallExcluirNaladi(arlNaladi);
						//}
					}
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}
			#endregion
		#endregion

		#region Métodos Show Balão
		public void fechaBalao()
		{
			try
			{
				if (m_mgblBalaoToolTip != null)
					m_mgblBalaoToolTip.Close();
			}
			catch
			{
			}
		}
		public void mostraBalao(string strMensagem, System.Windows.Forms.Control ctrlBalao)
		{
			try
			{
//				if (m_mgblBalaoToolTip != null)
//					m_mgblBalaoToolTip.Close();
//				if (m_bMostrarBaloes)
//				{
//					m_mgblBalaoToolTip = new mdlComponentesGraficos.MessageBalloon();
//					m_mgblBalaoToolTip.Caption = mdlConstantes.clsConstantes.BALLONTIP_DEFAULT_CAPTION;
//					m_mgblBalaoToolTip.Content = strMensagem;
//					m_mgblBalaoToolTip.Icon = System.Drawing.SystemIcons.Information;
//					m_mgblBalaoToolTip.CloseOnMouseClick = true;
//					m_mgblBalaoToolTip.CloseOnDeactivate = false;
//					m_mgblBalaoToolTip.CloseOnKeyPress = false;
//					m_mgblBalaoToolTip.ShowBalloon((System.Windows.Forms.Control)ctrlBalao);
//				}
			}
			catch (Exception err)
			{
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}

		private void mostraBalao()
		{
			try
			{
				fechaBalao();
				if ((m_tvCategoria.Nodes.Count > 0) && (m_tvCategoria.Nodes[0].Nodes.Count == 1) && (m_ckCategorias.Checked) && (m_nContadorCategoriaBalao == 0))
				{
					mostraBalao(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.BALLOONTIP_mdlProdutosGeral_frmFProdutos_CadastrarCategoria.ToString()), (System.Windows.Forms.Control)m_tvCategoria);
					m_nContadorCategoriaBalao++;
				}
				else if ((m_lvProdutos.Items.Count == 0) && (m_nContadorProdutoBalao == 0))
				{
					mostraBalao(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.BALLOONTIP_mdlProdutosGeral_frmFProdutos_CadastrarProduto.ToString()), (System.Windows.Forms.Control)m_lvProdutos);
					m_nContadorProdutoBalao++;
				}
				else if ((m_lvNcm.Items.Count == 0) && (m_ckNcm.Checked) && (m_nContadorNcmBalao == 0))
				{
					mostraBalao(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.BALLOONTIP_mdlProdutosGeral_frmFProdutos_CadastrarNcm.ToString()), (System.Windows.Forms.Control)m_lvNcm);
					m_nContadorNcmBalao++;
				}
				else if ((m_lvNaladi.Items.Count == 0) && (m_ckNaladi.Checked) && (m_nContadorNaladiBalao == 0))
				{
					mostraBalao(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.BALLOONTIP_mdlProdutosGeral_frmFProdutos_CadastrarNaladi.ToString()), (System.Windows.Forms.Control)m_lvNaladi);
					m_nContadorNaladiBalao++;
				}
				else if (m_nContadorGeralBalao == 0)
				{
					mostraBalao(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.BALLOONTIP_mdlProdutosGeral_frmFProdutos_MensagemGeral.ToString()).Replace("TAG",System.Environment.NewLine), (System.Windows.Forms.Control)m_btOk);
					m_nContadorGeralBalao++;
				}
			}
			catch (Exception err)
			{
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion
	}
}
