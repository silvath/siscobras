using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using DrawingCanvasPackage;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.IO;
using mdlRelatoriosCallBack;
using mdlTratamentoErro;
using mdlRelatoriosCallBackAreaProdutos;
using System.Drawing.Printing;

namespace ReportCanvasPackage
{
	#region Enums
	public enum SubTool
	{
		None = 0,
		DBText = 1,
		ProductArea = 2
	}

	public enum CallbackStatus
	{
		NaoFazerNada = -1,
		RecarregarTudo = 1,
		RecaregarLista = 2,
		RecarregarAreaDeProdutos = 4
	}
	#endregion
	#region DBTextObject
	public class DBTextObject : TextObject
	{
		public static int MAX_FUNCTIONS = 2;
		public bool bBelongsProdutctArea;
		public bool bCallback = false;
		public int nIdDBField = -1;
		public bool bPrintOnlyLastPage = false;
		public Color clrBack = Color.LemonChiffon;
		public int nFunction = 0;
		public ArrayList arlProducts = null; // valid only if bBelongsProductArea is true

		public DBTextObject()
		{
			nType = Tool.Text;
			nSubType = (int)SubTool.DBText;
			bResizeable = true;
		}

		public int NextFunction()
		{
			nFunction = (nFunction + 1) % MAX_FUNCTIONS;
			this.nState = nFunction;
			return( nFunction );
		}

		public override GraphicObject Clone()
		{
			DBTextObject objDBT = new DBTextObject();
			GraphicObject obj = (GraphicObject)objDBT;
			TextObject objText = (TextObject)objDBT;
			CloneGraphicObjectAttr( ref obj );
			CloneTextObjectAttr( ref objText );
			CloneDBTextObjectAttr( ref objDBT );
			return( objDBT );
		}
		protected void CloneDBTextObjectAttr( ref DBTextObject objDBT )
		{
			objDBT.bCallback = this.bCallback;
			objDBT.nIdDBField = this.nIdDBField;
			objDBT.bBelongsProdutctArea = this.bBelongsProdutctArea;
			objDBT.clrBack = this.clrBack;
			objDBT.nFunction = this.nFunction;
			objDBT.bPrintOnlyLastPage = this.bPrintOnlyLastPage;
			objDBT.size = this.size;
			if ( this.arlProducts != null )
				objDBT.arlProducts = (ArrayList)this.arlProducts.Clone();
		}
	}
	#endregion
	/// <summary>
	/// Summary description for ReportCanvas.
	/// </summary>
	public class ReportCanvas : DrawingCanvas
	{
		#region Delegates
			public delegate void delCallPropertiesBoxObjectTextDB(object sender, EventArgs e);
			public delegate void delPageNumberChanged(object sender, EventArgs e);
			public delegate void delPageCountChanged(object sender, EventArgs e);
			public delegate void delCallProductsChanged();
		#endregion
		#region Events
			public event delCallPropertiesBoxObjectTextDB eCallPropertiesBoxObjectTextDB;
			public event delPageNumberChanged ePageNumberChanged;
			public event delPageCountChanged ePageCountChanged;
			public event delCallProductsChanged eCallProductsChanged;
		#endregion 
		#region Events Methods
			protected virtual void OnCallPropertiesBoxObjectTextDB(EventArgs e) 
			{
				if (eCallPropertiesBoxObjectTextDB != null)
					eCallPropertiesBoxObjectTextDB(this, e);
			}
			protected virtual void OnPageNumberChanged(EventArgs e)
			{
				if (m_callback != null)
					m_callback.Pagina = m_nCurrPage;
				if (ePageNumberChanged != null)
					ePageNumberChanged(this, e);
			}
			protected virtual void OnPageCountChanged(EventArgs e)
			{
				if (ePageCountChanged != null)
					ePageCountChanged(this, e);
			}

			protected virtual void OnCallProductsChanged()
			{
				if (eCallProductsChanged != null)
					eCallProductsChanged();
			}
		#endregion

		#region Constants
			private const int REPORT_FATURAPROFORMA = 2;
			private const int REPORT_SUMARIO = 21;
		#endregion

		#region Attributes

		protected SubTool m_currSubTool = SubTool.None;
		protected SubTool m_prevSubTool = SubTool.None;

		protected int m_nCurrPage = -1; // current report page
		protected int m_nSavedCurrPage = -1; // usado durante a impressão para manter o valor da página atual
		protected int m_nTotalPages = -1; // report total pages
		protected int m_nTotalPagesBefore = -1; // report total pages before
		protected int m_nTotalPagesForced = -1; // report total pages forced

		protected bool m_bShowRestrictions = true;

		protected bool m_bShowMargins = false;
		protected Color m_clrMargin = System.Drawing.Color.FromArgb(255,255,255);

		protected bool m_bShowProductArea = true;
		protected Color m_clrProductArea = System.Drawing.Color.FromArgb(150,255,150);
		protected Rectangle m_rectProductArea;

		protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB = null;
		protected string m_strEnderecoExecutavel = System.Windows.Forms.Application.ExecutablePath;
		protected bool m_bDrawingProductArea = false;
		protected Color m_clrBackDBText = System.Drawing.Color.FromArgb(0,0,255);
		protected Color m_clrOldBackDBText = System.Drawing.Color.FromArgb(0,0,255);
		protected Color m_clrBackDBTextOnlyText = Color.LightGreen;
		protected bool m_bShowDBText = true; // are DB text visible on screen
		protected bool m_bShowDBTextDados = true; 
		protected String m_strReportName = "No name";

		protected ArrayList m_arlRectObj = null;
		protected ArrayList m_arlCircObj = null;
		protected ArrayList m_arlLineObj = null;
		protected ArrayList m_arlTextObj = null;
		protected ArrayList m_arlImgObj = null;
		protected ArrayList m_arlDBTextObj = null;

		protected int m_nIdExportador = -1;
		protected string m_strIdCodigo = "1";
		protected int m_nIdIdioma = 3;
		protected int m_nIdTipo = -1;
		protected int m_nIdRelatorio = -1;
		protected System.Windows.Forms.ImageList m_ilBandeiras = null;

		// Flag que identifica se o Relatorio foi modificado ou nao
		protected bool m_bModificado = false;

		// Propriedades do Relatorio 
		protected bool m_bVerGrade = false;
		protected bool m_bVerMargens = false;
		protected bool m_bVerAreaProdutos = false;
		protected bool m_bVerLinhas = false;
		protected bool m_bVerCirculos = false;
		protected bool m_bVerRetangulos = false;
		protected bool m_bVerImagens = false;
		protected bool m_bVerEtiquetas = false;
		protected bool m_bVerCamposBD = false;
		protected bool m_bVerCamposBDDados = false;

		// Atributos Relacionados aos Campos de BD 
		protected int m_nIdCampoBD;
		protected bool m_bObjetoCallBackBD;
		protected bool m_bObjetoVisivelImpressao;
		protected bool m_bObjetoPertenceAreaProdutos;
		protected bool m_bObjetoAlinhamentoInferiorAreaProdutos;
		protected int m_nObjetoAlinhamento;
		protected bool m_bObjetoImprimirSomenteUltimaPagina;
		protected int m_nObjetoFormatoNumero;

		protected clsRelatoriosCallBack m_callback = null;
		protected clsTratamentoErro m_tratadorErro = null;

		protected clsRelatoriosCallBackAreaProdutos m_callbackAreaDeProdutos = null;

		protected SortedList m_slsIDField = null;

		protected ArrayList m_arlProdutos = null; // produtos retornados por m_callbackAreaDeProdutos
		protected ArrayList m_arlColunasProdutos = null; // colunas que serão impressas da área de produtos
		//protected int m_nYAtualProdutos = -1;
		protected ArrayList m_arlUltimoProdutoInserido = null;
		protected bool m_bHasProductArea = false;

		protected PrintPageEventHandler  m_pePrint = null;
		protected PrintEventHandler m_peBeginPrint = null;
		protected PrintEventHandler m_peEndPrint = null;
		protected PrintDocument m_pd = null;

		#endregion
		#region Properties
			public int Report
			{
				get
				{
					return(m_nIdRelatorio);
				}
			}

			public int TotalPages
			{
				set
				{
					if (value >= -1) 
						m_nTotalPagesForced = value;
				}
			}

			public bool ShowDBTextDados
			{
				get
				{
					return( m_bShowDBTextDados );
				}

				set
				{
					bool bNeedRefresh = (value != m_bShowDBTextDados);
					m_bShowDBTextDados = value;

					if ( !m_bShowDBTextDados )
					{
						if ( (m_currTool == Tool.Text) && (m_currSubTool == SubTool.DBText) )
						{
							m_currTool = Tool.None;
							m_currSubTool = SubTool.None;
						}
					}

					if ( bNeedRefresh && m_bWindowNotStarted )
					{
						ClearSelection(false);
						RepaintScreen();
					}
				}
			}
			
			public bool ShowDBText
			{
				get
				{
					return( m_bShowDBText );
				}

				set
				{
					bool bNeedRefresh = (value != m_bShowDBText);
					m_bShowDBText = value;

					if ( !m_bShowDBText )
					{
						if ( (m_currTool == Tool.Text) && (m_currSubTool == SubTool.DBText) )
						{
							m_currTool = Tool.None;
							m_currSubTool = SubTool.None;
						}
					}

					if ( bNeedRefresh && m_bWindowNotStarted )
					{
						ClearSelection(false);
						RepaintScreen();
					}
				}
			}

			public int DBIdCampo
			{
				get
				{
					return (m_nIdCampoBD);
				}
				set 
				{
					m_nIdCampoBD = value;
				}
			}

			public bool ObjetoVisivelImpressao
			{
				get
				{
					return (m_bObjetoVisivelImpressao);
				}
				set
				{
					m_bObjetoVisivelImpressao = value;
				}
			}

			public bool DBCallBack
			{
				get
				{
					return (m_bObjetoCallBackBD);
				}
				set
				{
					m_bObjetoCallBackBD = value;
				}
			}

			public bool DBPertenceAreaProdutos
			{
				get
				{
					return (m_bObjetoPertenceAreaProdutos);
				}
				set
				{
					m_bObjetoPertenceAreaProdutos = value;
				}
			}

			public bool DBAlinhamentoInferiorAreaProdutos
			{
				get
				{
					return (m_bObjetoAlinhamentoInferiorAreaProdutos);
				}
				set
				{
					m_bObjetoAlinhamentoInferiorAreaProdutos = value;
				}
			}

			public int DBAlinhamento
			{
				get
				{
					return (m_nObjetoAlinhamento);
				}
				set
				{
					m_nObjetoAlinhamento = value;
				}
			}

			public bool DBImprimirSomenteUltimaPagina
			{
				get
				{
					return (m_bObjetoImprimirSomenteUltimaPagina);
				}
				set
				{
					m_bObjetoImprimirSomenteUltimaPagina = value;
				}
			}

			public int DBFormatoNumero
			{
				get
				{
					return (m_nObjetoFormatoNumero);
				}
				set
				{
					m_nObjetoFormatoNumero = value;
				}
			}

			public Color DBTextColor
			{
				get
				{
					return( m_clrBackDBText );
				}

				set
				{
					bool bNeedRefresh = (value != m_clrBackDBText);
					m_clrBackDBText = value;
					// Recolocando a cor de fundo dos Textos Dinâmicos
					DBTextObject objDB;
					for (int nCont = 0 ; nCont < m_colGraphObj.Count; nCont++)
					{ 
						if (m_colGraphObj[nCont].GetType().ToString() == "ReportCanvasPackage.DBTextObject") 
						{
							objDB = (DBTextObject)m_colGraphObj[nCont];
							if (!objDB.nIdDBField.ToString().EndsWith("00"))
								objDB.clrBack = value;
						} 
					}

					if ( bNeedRefresh && m_bWindowNotStarted )
						RepaintScreen();

				}

			}

			public System.Drawing.Color BackgroundColorLabel
			{
				get
				{
					return(m_clrBackDBTextOnlyText);
				}
				set
				{
					m_clrBackDBTextOnlyText = value ;
				}

			}

			public Rectangle ProductArea
			{
				get
				{
					return( m_rectProductArea );
				}
			}

			public bool ShowProductArea
			{
				get
				{
					return( m_bShowProductArea );
				}

				set
				{
					bool bNeedRefresh = (value != m_bShowProductArea);
					m_bShowProductArea = value;
					if ( bNeedRefresh && m_bWindowNotStarted )
						RepaintScreen();
				}
			}

			public Color ProductAreaColor
			{
				get
				{
					return( m_clrProductArea );
				}

				set
				{
					bool bNeedRefresh = (value != m_clrProductArea);
					m_clrProductArea = value;
					if ( bNeedRefresh && m_bWindowNotStarted )
						RepaintScreen();
				}
			}

			public SubTool CurrentSubTool
			{
				get
				{				
					return( m_currSubTool );
				}

				set
				{
					if ( m_currSubTool != value )
						m_prevSubTool = m_currSubTool;
					m_currSubTool = value;
					OnCallToolChanged();
				}
			}

			public Color MarginColor
			{
				get
				{
					return( m_clrMargin );
				}

				set
				{
					bool bNeedRefresh = m_clrMargin != value;
					m_clrMargin = value;
					if ( bNeedRefresh && m_bWindowNotStarted )
						RepaintScreen();
				}
			}

			public bool ShowMargins
			{
				get
				{
					return( m_bShowMargins );
				}

				set
				{
					bool bNeedRefresh = m_bShowMargins != value;
					m_bShowMargins = value;
					if ( bNeedRefresh && m_bWindowNotStarted )
						RepaintScreen();
				}
			}

			public string IdCodigo
			{
				get
				{
					return m_strIdCodigo;
				}
				set
				{
					m_strIdCodigo = value;
				}
			}
		#endregion

		#region Constructor e Destructor
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ReportCanvas(System.ComponentModel.IContainer container)
		{
			/// <summary>
			/// Required for Windows.Forms Class Composition Designer support
			/// </summary>
			container.Add(this);
			InitializeComponent();
			SetStartPage();
		}

		public ReportCanvas()
		{
			/// <summary>
			/// Required for Windows.Forms Class Composition Designer support
			/// </summary>
			InitializeComponent();
			SetStartPage();
		}
		#endregion 
		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion
		#region Init functions
			protected void SetStartPage()
			{
				m_pePrint = new PrintPageEventHandler( dcPrint );
				m_pd = new PrintDocument();
				m_pd.PrintPage += m_pePrint;

				m_peBeginPrint = new PrintEventHandler( dcBeginPrint );
				m_pd.BeginPrint += m_peBeginPrint;			

				m_peEndPrint = new PrintEventHandler( dcEndPrint );
				m_pd.EndPrint += m_peEndPrint;

				m_nTotalPages = 1;
				m_nCurrPage = 0;
			}
		#endregion

		#region Overrided/Painting methods

		protected void dcBeginPrint( Object sender, PrintEventArgs pe )
		{
			setPrinting( true );
			pe.Cancel = (m_colGraphObj.Count == 0);
			m_nSavedCurrPage = m_nCurrPage;
			m_nCurrPage = -1;
		}

		protected void dcEndPrint( Object sender, PrintEventArgs pe )
		{
			m_nCurrPage = m_nSavedCurrPage;
			refreshFieldPageNumber();
			setPrinting( false );
		}

		protected void dcPrint( Object sender, PrintPageEventArgs pe )
		{
			try
			{
				// Hack: Test in v9: Margin
				pe.PageSettings.Margins = new Margins(pe.PageBounds.Left,pe.PageBounds.Right,pe.PageBounds.Top,pe.PageBounds.Bottom);
				Graphics graph = pe.Graphics;
				if (m_nCurrPage == -1)
				{
					switch(pe.PageSettings.PrinterSettings.PrintRange)
					{
						case System.Drawing.Printing.PrintRange.AllPages:
							m_nCurrPage = 0;
							break;
						case System.Drawing.Printing.PrintRange.SomePages:
							m_nCurrPage = pe.PageSettings.PrinterSettings.FromPage - 1;
							break;
					}
				}
				refreshFieldPageNumber();
				PaintObjects( ref graph );
				m_nCurrPage++;
				pe.HasMorePages = m_nCurrPage < pe.PageSettings.PrinterSettings.ToPage;
			}catch(System.Exception e){
				throw(e);
			}
		}

		protected override void HighLightObject( int nIndexObj )
		{
			if ( bCanHighlight() && m_bHasProductArea )
			{
				if ((new System.Drawing.Rectangle(m_rectProductArea.X,m_rectProductArea.Y + m_nTopMargin,m_rectProductArea.Width,m_rectProductArea.Height)).Contains(MousePos) )
				{
					// HighLight Products Area
					if ( System.Windows.Forms.Cursor.Current != Cursors.Hand )
						System.Windows.Forms.Cursor.Current = Cursors.Hand;
					switch(m_nIdTipo)
					{
						case REPORT_FATURAPROFORMA:
						case REPORT_SUMARIO:
							break;
						default:
							HighLightProductArea(true);
							break;
					}
				}else{
					HighLightProductArea(false);
					base.HighLightObject( nIndexObj );
				}
			} 
			else
				base.HighLightObject( nIndexObj );
		}

		protected void HighLightProductArea(bool bHighLight)
		{
			Graphics clientDC = this.CreateGraphics();
			PaintBackground( ref m_memDC, ref m_rectScreen );

			Rectangle rectProdAreaScreen = m_rectProductArea;
			rectProdAreaScreen.X += 1;
			rectProdAreaScreen.Width -= 1;
			rectProdAreaScreen.Y += (m_nTopMargin + 1);
			rectProdAreaScreen.Height -= 1;
			rectWorld2Screen( ref rectProdAreaScreen );
			if (bHighLight)
				m_memDC.FillRectangle( new SolidBrush(this.HighlightColor), rectProdAreaScreen );
			PaintObjects(  ref m_memDC );

			Point ptUpdateFrom = new Point( rectProdAreaScreen.X, rectProdAreaScreen.Y );;
			PaintPartialOnScreen( ref clientDC, ref m_memDC, ref rectProdAreaScreen, ref ptUpdateFrom );
		}

		// OnPaint event
		protected override void dcPaint( Object sender, PaintEventArgs e )
		{
			base.dcPaint( sender, e );
		}

		protected override void dcMouseEnter( Object sender, EventArgs e )
		{
			switch(CurrentTool)
			{
				case Tool.Selection:
					switch(CurrentSubTool)
					{
						case SubTool.None:
							Cursor = curReturnCursorFromResource("CurHandi.cur",System.Windows.Forms.Cursors.Hand);
							break;
						case SubTool.ProductArea:
							Cursor = curReturnCursorFromResource("CurProductArea.cur",System.Windows.Forms.Cursors.Cross);
							break;
					}
					break;
				case Tool.Line:
					Cursor = curReturnCursorFromResource("CurLine.cur",System.Windows.Forms.Cursors.Cross);
					break;
				case Tool.Circle:
					Cursor = curReturnCursorFromResource("CurCircle.cur",System.Windows.Forms.Cursors.Cross);
					break;
				case Tool.Rectangle:
					Cursor = curReturnCursorFromResource("CurRetangle.cur",System.Windows.Forms.Cursors.Cross);
					break;
				case Tool.Image:
					Cursor = curReturnCursorFromResource("CurImage.cur",System.Windows.Forms.Cursors.Cross);
					break;
				case Tool.Text:
					switch(CurrentSubTool)
					{
						case SubTool.None:
							Cursor = curReturnCursorFromResource("CurText.cur",System.Windows.Forms.Cursors.Cross);
							break;
						case SubTool.DBText:
							Cursor = curReturnCursorFromResource("CurDBText.cur",System.Windows.Forms.Cursors.Cross);
							break;
					}
					break;
				default:
					Cursor = System.Windows.Forms.Cursors.Default;
					break;
			}
		}

		protected override void dcMouseMovement( Object sender, MouseEventArgs e )
		{
			MousePos = new Point(e.X, e.Y);
			if ( e.Button == MouseButtons.None )
			{
				if ( bCanHighlight() )
				{
					int nIndex = nSelectedObject(MousePos);
					if ( nIndex != -1 )
					{
						GraphicObject obj = (GraphicObject)m_colGraphObj[ nIndex ];
						if ( ((GraphicObject)obj).nType == Tool.Text && ((GraphicObject)obj).nSubType == (int)SubTool.DBText )
							if ( ((DBTextObject)obj).bCallback )
								((GraphicObject)obj).bHighlighted = true;
					}
					HighLightObject( nIndex );
				}
				base.dcMouseMovement( sender, e );
			} 
			else	if ( m_bDrawingProductArea )
			{
				Graphics memDC = GetMemoryDC();
				m_nTotalPages = nCalculaNumeroDePaginas( ref memDC );
				BuildProdAreaRect( m_ptReference, MousePos );
				m_bShowProductArea = true;
				RepaintScreen();
				return;
			} 
			if ((e.Button == MouseButtons.Left ) && (m_currTool == Tool.Text) && (m_currSubTool == SubTool.DBText))
			{
				PaintCurrentObject(MousePos);
			}
			else
			{
				base.dcMouseMovement( sender, e );						
			}
		}

		protected override void dcMouseClickUp( Object sender, MouseEventArgs e )
		{
			if ( e.Button == MouseButtons.Left )
			{
				if ( m_bDrawingProductArea )
				{
					m_bDrawingProductArea = false;
					m_currTool = Tool.Selection; 
					m_currSubTool = SubTool.None;
					Cursor = curReturnCursorFromResource("CurHand.cur",System.Windows.Forms.Cursors.Hand);
				}
				else
				{
					if ((m_currTool == Tool.Text) && m_currSubTool == SubTool.DBText)
					{
						//DBTextColor = m_clrOldBackDBText;
						OnCallPropertiesBoxObjectTextDB(EventArgs.Empty);
						if (!m_bCancelActualAction)
						{ 
							CreateNewObject(true);
							CurrentTool = Tool.Selection;
							CurrentSubTool = SubTool.None;
							refreshCursor();
						}
						// DesSelecionar o Objeto Criado 
						m_colSelObjs.Clear();

						RepaintScreen();
					}
					else
					{
						if ((m_currTool == Tool.Selection) && m_currSubTool == SubTool.ProductArea)
						{
							if (m_nTotalPagesBefore != m_nTotalPages)
							{
								OnPageCountChanged(EventArgs.Empty);
								if (m_nCurrPage > m_nTotalPages)
								{
									m_nCurrPage = m_nTotalPages;
									OnPageNumberChanged(EventArgs.Empty);
								}
							}
							RepaintScreen();
						}
						else
						{
							base.dcMouseClickUp( sender, e );
							CurrentSubTool = SubTool.None;
							refreshCursor();
						}
					}
				}
			}else{
				if (!m_bViewMode)
				{
					if ( e.Button == MouseButtons.Right)
					{
						bool bChangeCursor = false;
						if (bChangeCursor = (m_currTool != m_prevTool))
							m_currTool = m_prevTool;
						if (m_currSubTool != m_prevSubTool)
							m_currSubTool = m_prevSubTool;
						if (bChangeCursor)
							refreshCursor();
						this.ClearSelection(true);
						OnCallToolChanged();
					}
				}
			}
		}

		protected override void dcMouseClickDown( Object sender, MouseEventArgs e )
		{
			if ( e.Button == MouseButtons.Left )
			{
				
				m_bDrawingProductArea = ((m_currTool == Tool.Selection) && (m_currSubTool == SubTool.ProductArea));
				if ( bCanHighlight() )
					MostrarJanela( m_nPreviousHighlight );
				if (m_bDrawingProductArea)
				{
					m_nTotalPagesBefore = m_nTotalPages;
				}
				base.dcMouseClickDown( sender, e );
			} 
			else if (e.Button == MouseButtons.Right && bCanHighlight() )
			{
				if ( bCanHighlight() && (m_nPreviousHighlight != -1) 
					&& (((GraphicObject)(m_colGraphObj[m_nPreviousHighlight])).nType == Tool.Text)
					&& (((GraphicObject)(m_colGraphObj[m_nPreviousHighlight])).nSubType == (int)SubTool.DBText))
				{
					((DBTextObject)m_colGraphObj[m_nPreviousHighlight]).NextFunction();                 
				}
			}
		}

		protected override void dcMouseDoubleClick(Object sender, EventArgs e)
		{
			if (!m_bViewMode)
			{
				if (m_currTool != Tool.None)
				{
					GraphicObject obj;
					int nSel;
					System.Drawing.Point ptDestiny = new System.Drawing.Point(MousePos.X,MousePos.Y);

					if (m_currTool == Tool.Selection)
					{
						// if source and destiny point are the same
						if ( ptDestiny.Equals(m_ptSource) )
						{
							m_bSamePoint = true;
							// try to select one object
							if ( (nSel = nSelectedObject(MousePos)) != -1 )
							{
								obj = (GraphicObject)m_colGraphObj[nSel];
								switch(obj.GetType().ToString())
								{
									case "ReportCanvasPackage.DBTextObject":
										this.DBAlinhamento = (int)((DBTextObject)obj).alignment;
										// this.DBAlinhamentoInferiorAreaProdutos = ((DBTextObject)obj).alignment;
										this.DBIdCampo = ((DBTextObject)obj).nIdDBField;
										this.TextFont = ((DBTextObject)obj).fntText;
										this.ObjectPrintable = ((DBTextObject)obj).bVisibleForPrinting;

										OnCallPropertiesBoxObjectTextDB(EventArgs.Empty);
										if (!m_bCancelActualAction)
										{
											((DBTextObject)obj).alignment = (DrawingCanvasPackage.Alignment)this.DBAlinhamento;  
											((DBTextObject)obj).nIdDBField = this.m_nIdCampoBD;  
											((DBTextObject)obj).fntText = this.TextFont;
											((DBTextObject)obj).bVisibleForPrinting = this.ObjectPrintable;
											((DBTextObject)obj).bCallback = this.DBCallBack; 
											if ( (this.m_nIdCampoBD.ToString().Length >= 2) && (this.m_nIdCampoBD.ToString().EndsWith("00")) )
												((DBTextObject)obj).clrBack = m_clrBackDBTextOnlyText;
											else
												((DBTextObject)obj).clrBack = m_clrBackDBText;

											((DBTextObject)obj).strText = m_strText;
											((DBTextObject)obj).fntText = m_fntText;
											((DBTextObject)obj).clrText = m_clrText;
											
										} 
										base.dcMouseDoubleClick(sender,e);
										break;
									default:
										base.dcMouseDoubleClick(sender,e);
										break;
								}
							} 
						}
					}
				}
			}
		}

		protected override void PaintOneObject(ref Graphics graph, ref GraphicObject obj)
		{
			try
			{
				if ( m_bViewMode && bIsPrinting() )
					if ( !obj.bVisibleForPrinting )
						return;

				if ( (obj.nType == Tool.Text) )
				{
					switch ( obj.nSubType )
					{
						case (int)SubTool.DBText:
							DBTextObject objDBText = (DBTextObject)obj;
							if ( (!m_bShowDBTextDados) && ( !((string)(objDBText.nIdDBField.ToString())).EndsWith("00")) )
							{
								obj.bVisibleOnScreen = false;
								break;
							} 

							if ( (!m_bShowDBText) && ( ((string)(objDBText.nIdDBField.ToString())).EndsWith("00")) )
							{
								obj.bVisibleOnScreen = false;
								break;
							} 
							else
								obj.bVisibleOnScreen = true;
							Rectangle rect = obj.rect;
							rect.Offset( 1, 1 );
							rect.Height -= 1; rect.Width -= 1;
                            
							rectWorld2Screen( ref rect );
							if ( !obj.bHighlighted && !m_bViewMode)
								graph.FillRectangle( new SolidBrush(((DBTextObject)obj).clrBack), rect);
							if ( objDBText.bBelongsProdutctArea && m_bViewMode ) // se está em modo de visualização e pertence à area de produtos
								break;
							else
								if (objDBText.bPrintOnlyLastPage && m_bViewMode)
								{
									if ((m_nCurrPage + 1) == m_nTotalPages)
										base.PaintOneObject( ref graph, ref obj );
								}
								else
								{
									base.PaintOneObject( ref graph, ref obj );
								}
							break;
						default:
							base.PaintOneObject( ref graph, ref obj );
							break;
					}
				}
				else
				{
					base.PaintOneObject( ref graph, ref obj );
				}
			}catch(System.Exception eErro){
                m_tratadorErro.trataErro(ref eErro);                
			}
		}


		protected override void PaintBackground(ref Graphics e, ref Rectangle r)
		{
			base.PaintBackground( ref e, ref r );
			if ( m_bShowProductArea )
				PaintProductArea( ref e );
			if ( m_bShowMargins )
				PaintMargins( ref e );
		}

		/// <summary>
		/// Restrictions off the Siscobras Exporta Facil
		/// </summary>
		/// <param name="e"></param>
		/// <param name="r"></param>
		private void PaintRestrictions(ref Graphics e)
		{
			if (m_bShowRestrictions)
			{
				string strNonComercial1 = "Using this document for";
				string strNonComercial2 = "commercial or customs house";
				string strNonComercial3 = "purpose is illegal";
				string strNonComercial4 = "Siscobras Trainning Version";
				string strSite = "http://www.siscobras.com.br";
				int nHeight = 30;
				
				System.Drawing.Point ptPoint;

				// Non Comercial1
				ptPoint = new Point((PageSize.Width /2) - 150,PageSize.Height / 2);
				if (!this.bIsPrinting())
					ptWorld2Screen(ref ptPoint);
				if (!m_bIsCreatingPDF)
				{
					e.DrawString(strNonComercial1,new Font("ARIAL",18,System.Drawing.FontStyle.Bold),new SolidBrush(System.Drawing.Color.Red),ptPoint.X,ptPoint.Y);
					e.DrawString(strNonComercial1,new Font("ARIAL",18,System.Drawing.FontStyle.Bold),new SolidBrush(System.Drawing.Color.Green),ptPoint.X,ptPoint.Y);
					e.DrawString(strNonComercial1,new Font("ARIAL",18,System.Drawing.FontStyle.Bold),new SolidBrush(System.Drawing.Color.Blue),ptPoint.X,ptPoint.Y);
					e.DrawString(strNonComercial1,new Font("ARIAL",18,System.Drawing.FontStyle.Bold),new SolidBrush(System.Drawing.Color.Black),ptPoint.X,ptPoint.Y);			
				}else{
					m_pdfReport.bAdicionaTexto(strNonComercial1,new Font("ARIAL",18,System.Drawing.FontStyle.Bold),System.Drawing.Color.Red,ptPoint.X,ptPoint.Y);
					m_pdfReport.bAdicionaTexto(strNonComercial1,new Font("ARIAL",18,System.Drawing.FontStyle.Bold),System.Drawing.Color.Green,ptPoint.X,ptPoint.Y);
					m_pdfReport.bAdicionaTexto(strNonComercial1,new Font("ARIAL",18,System.Drawing.FontStyle.Bold),System.Drawing.Color.Blue,ptPoint.X,ptPoint.Y);
					m_pdfReport.bAdicionaTexto(strNonComercial1,new Font("ARIAL",18,System.Drawing.FontStyle.Bold),System.Drawing.Color.Black,ptPoint.X,ptPoint.Y);			
				}

				// Non Comercial2
				ptPoint = new Point((PageSize.Width /2) - 150,(PageSize.Height / 2) + nHeight);
				if (!this.bIsPrinting())
					ptWorld2Screen(ref ptPoint);
				if (!m_bIsCreatingPDF)
				{
					e.DrawString(strNonComercial2,new Font("ARIAL",18,System.Drawing.FontStyle.Bold),new SolidBrush(System.Drawing.Color.Red),ptPoint.X,ptPoint.Y);
					e.DrawString(strNonComercial2,new Font("ARIAL",18,System.Drawing.FontStyle.Bold),new SolidBrush(System.Drawing.Color.Green),ptPoint.X,ptPoint.Y);
					e.DrawString(strNonComercial2,new Font("ARIAL",18,System.Drawing.FontStyle.Bold),new SolidBrush(System.Drawing.Color.Blue),ptPoint.X,ptPoint.Y);
					e.DrawString(strNonComercial2,new Font("ARIAL",18,System.Drawing.FontStyle.Bold),new SolidBrush(System.Drawing.Color.Black),ptPoint.X,ptPoint.Y);
				}else{
					m_pdfReport.bAdicionaTexto(strNonComercial2,new Font("ARIAL",18,System.Drawing.FontStyle.Bold),System.Drawing.Color.Red,ptPoint.X,ptPoint.Y);
					m_pdfReport.bAdicionaTexto(strNonComercial2,new Font("ARIAL",18,System.Drawing.FontStyle.Bold),System.Drawing.Color.Green,ptPoint.X,ptPoint.Y);
					m_pdfReport.bAdicionaTexto(strNonComercial2,new Font("ARIAL",18,System.Drawing.FontStyle.Bold),System.Drawing.Color.Blue,ptPoint.X,ptPoint.Y);
					m_pdfReport.bAdicionaTexto(strNonComercial2,new Font("ARIAL",18,System.Drawing.FontStyle.Bold),System.Drawing.Color.Black,ptPoint.X,ptPoint.Y);
				}

				// Non Comercial3
				ptPoint = new Point((PageSize.Width /2) - 150,(PageSize.Height / 2) + (nHeight * 2));
				if (!this.bIsPrinting())
					ptWorld2Screen(ref ptPoint);
				if (!m_bIsCreatingPDF)
				{
					e.DrawString(strNonComercial3,new Font("ARIAL",18,System.Drawing.FontStyle.Bold),new SolidBrush(System.Drawing.Color.Red),ptPoint.X,ptPoint.Y);
					e.DrawString(strNonComercial3,new Font("ARIAL",18,System.Drawing.FontStyle.Bold),new SolidBrush(System.Drawing.Color.Green),ptPoint.X,ptPoint.Y);
					e.DrawString(strNonComercial3,new Font("ARIAL",18,System.Drawing.FontStyle.Bold),new SolidBrush(System.Drawing.Color.Blue),ptPoint.X,ptPoint.Y);
					e.DrawString(strNonComercial3,new Font("ARIAL",18,System.Drawing.FontStyle.Bold),new SolidBrush(System.Drawing.Color.Black),ptPoint.X,ptPoint.Y);
				}else{
					m_pdfReport.bAdicionaTexto(strNonComercial3,new Font("ARIAL",18,System.Drawing.FontStyle.Bold),System.Drawing.Color.Red,ptPoint.X,ptPoint.Y);
					m_pdfReport.bAdicionaTexto(strNonComercial3,new Font("ARIAL",18,System.Drawing.FontStyle.Bold),System.Drawing.Color.Green,ptPoint.X,ptPoint.Y);
					m_pdfReport.bAdicionaTexto(strNonComercial3,new Font("ARIAL",18,System.Drawing.FontStyle.Bold),System.Drawing.Color.Blue,ptPoint.X,ptPoint.Y);
					m_pdfReport.bAdicionaTexto(strNonComercial3,new Font("ARIAL",18,System.Drawing.FontStyle.Bold),System.Drawing.Color.Black,ptPoint.X,ptPoint.Y);
				}

				// Non Comercial4
				ptPoint = new Point((PageSize.Width /2) - 50,(PageSize.Height / 2) + (nHeight * 3));
				if (!this.bIsPrinting())
					ptWorld2Screen(ref ptPoint);
				if (!m_bIsCreatingPDF)
				{
					e.DrawString(strNonComercial4,new Font("ARIAL",8,System.Drawing.FontStyle.Bold),new SolidBrush(System.Drawing.Color.Red),ptPoint.X,ptPoint.Y);
					e.DrawString(strNonComercial4,new Font("ARIAL",8,System.Drawing.FontStyle.Bold),new SolidBrush(System.Drawing.Color.Green),ptPoint.X,ptPoint.Y);
					e.DrawString(strNonComercial4,new Font("ARIAL",8,System.Drawing.FontStyle.Bold),new SolidBrush(System.Drawing.Color.Blue),ptPoint.X,ptPoint.Y);
					e.DrawString(strNonComercial4,new Font("ARIAL",8,System.Drawing.FontStyle.Bold),new SolidBrush(System.Drawing.Color.Black),ptPoint.X,ptPoint.Y);
				}else{
					m_pdfReport.bAdicionaTexto(strNonComercial4,new Font("ARIAL",8,System.Drawing.FontStyle.Bold),System.Drawing.Color.Red,ptPoint.X,ptPoint.Y);
					m_pdfReport.bAdicionaTexto(strNonComercial4,new Font("ARIAL",8,System.Drawing.FontStyle.Bold),System.Drawing.Color.Green,ptPoint.X,ptPoint.Y);
					m_pdfReport.bAdicionaTexto(strNonComercial4,new Font("ARIAL",8,System.Drawing.FontStyle.Bold),System.Drawing.Color.Blue,ptPoint.X,ptPoint.Y);
					m_pdfReport.bAdicionaTexto(strNonComercial4,new Font("ARIAL",8,System.Drawing.FontStyle.Bold),System.Drawing.Color.Black,ptPoint.X,ptPoint.Y);
				}

				// Site
				ptPoint = new Point((PageSize.Width /2) - 150,PageSize.Height - 60);
				if (!this.bIsPrinting())
					ptWorld2Screen(ref ptPoint);
				if (!m_bIsCreatingPDF)
				{
					e.DrawString(strSite,new Font("ARIAL",14,System.Drawing.FontStyle.Bold),new SolidBrush(System.Drawing.Color.Red),ptPoint.X,ptPoint.Y);
					e.DrawString(strSite,new Font("ARIAL",14,System.Drawing.FontStyle.Bold),new SolidBrush(System.Drawing.Color.Green),ptPoint.X,ptPoint.Y);
					e.DrawString(strSite,new Font("ARIAL",14,System.Drawing.FontStyle.Bold),new SolidBrush(System.Drawing.Color.Blue),ptPoint.X,ptPoint.Y);
					e.DrawString(strSite,new Font("ARIAL",14,System.Drawing.FontStyle.Bold),new SolidBrush(System.Drawing.Color.Black),ptPoint.X,ptPoint.Y);
				}else{
					m_pdfReport.bAdicionaTexto(strSite,new Font("ARIAL",14,System.Drawing.FontStyle.Bold),System.Drawing.Color.Red,ptPoint.X,ptPoint.Y);
					m_pdfReport.bAdicionaTexto(strSite,new Font("ARIAL",14,System.Drawing.FontStyle.Bold),System.Drawing.Color.Green,ptPoint.X,ptPoint.Y);
					m_pdfReport.bAdicionaTexto(strSite,new Font("ARIAL",14,System.Drawing.FontStyle.Bold),System.Drawing.Color.Blue,ptPoint.X,ptPoint.Y);
					m_pdfReport.bAdicionaTexto(strSite,new Font("ARIAL",14,System.Drawing.FontStyle.Bold),System.Drawing.Color.Black,ptPoint.X,ptPoint.Y);
				}
			}
		}

		protected override void PaintObjects(ref Graphics graph)
		{
			try
			{
				base.PaintObjects( ref graph );

				if ( m_bHasProductArea && m_bViewMode )
					PaintProducts( ref graph );
				PaintRestrictions(ref graph);
			}catch{
			}
		}

		protected void PaintProducts( ref Graphics graph )
		{
			try
			{
				if ( !m_bHasProductArea || (m_arlProdutos == null)
					|| (m_arlProdutos.Count == 0) )
					return;

				if (m_bIsPrinting)
					m_bIsPrinting = true;


				ArrayList arlProdutos;
				int nAltura, nIndiceCol, nNumeroDeProdutos;
				int nCurrHeight;
				GraphicObject obj;
				TextObject objTextAtual = null;
				mdlRelatoriosCallBackAreaProdutos.DataStruct estrProd;

				arlProdutos = (ArrayList)m_arlProdutos[ 0 ];
				nNumeroDeProdutos = arlProdutos.Count;

				int nYAreaProd = m_rectProductArea.Y + m_nTopMargin;

				if (m_nCurrPage >= m_arlUltimoProdutoInserido.Count)
					return;
				int n = (int)m_arlUltimoProdutoInserido[ m_nCurrPage ];
			
				for ( int i = (n + 1); i < nNumeroDeProdutos; i++ )
				{
					estrProd.nHeight = 0;
					nAltura = 0;
					nCurrHeight = 0;
					GraphicObject[] arrgraobjPaint = new GraphicObject[m_arlColunasProdutos.Count];
					for ( int j = 0; j < m_arlColunasProdutos.Count; j++ )
					{
						nIndiceCol = nIndiceListaDeProdutos(((DBTextObject)m_arlColunasProdutos[j]).nIdDBField);
						arlProdutos = (ArrayList)m_arlProdutos[ nIndiceCol ];
						estrProd = (mdlRelatoriosCallBackAreaProdutos.DataStruct)arlProdutos[ i ];

						objTextAtual = (TextObject)((DBTextObject)m_arlColunasProdutos[j]).Clone();
						objTextAtual.strText = estrProd.strText;
						objTextAtual.fntText = (estrProd.fntText != null) ? (new Font(estrProd.fntText,estrProd.fntText.Style)) : (new Font(objTextAtual.fntText,objTextAtual.fntText.Style));
						objTextAtual.ptSource.Y = nYAreaProd;
						objTextAtual.ptSource.X = objTextAtual.ptSource.X + estrProd.nWidth;
						objTextAtual.ptDestiny.Y = m_rectProductArea.Y + m_rectProductArea.Height + m_nTopMargin;
						objTextAtual.size = sizeText(ref objTextAtual.strText, ref objTextAtual.fntText );
						objTextAtual.rect = BuildRect( ref objTextAtual.ptSource, ref objTextAtual.ptDestiny );
						obj = (GraphicObject)objTextAtual;

						TextObject objClone = (TextObject)objTextAtual.Clone();
						System.Drawing.Graphics gra = System.Drawing.Graphics.FromImage(new System.Drawing.Bitmap(1,1));
						this.PaintText(ref gra,ref objClone,ref objClone.fntText,ref objClone.ptSource,ref objClone.ptDestiny,ref objClone.size,objClone.clrText);
						nCurrHeight = objClone.size.Height;
						if (nCurrHeight > nAltura)
							nAltura = nCurrHeight;
						if ((nYAreaProd + nCurrHeight) > (m_rectProductArea.Y + m_rectProductArea.Height + m_nTopMargin))
						{
							if ( (m_nCurrPage + 2) > m_arlUltimoProdutoInserido.Count )
								m_arlUltimoProdutoInserido.Add( i - 1);
							break;
						}
						arrgraobjPaint[j] = obj.Clone();
						nAltura = (nAltura > objTextAtual.size.Height) ? nAltura : objTextAtual.size.Height;
					}
					nYAreaProd += nAltura;
					if ( nYAreaProd > (m_rectProductArea.Y + m_rectProductArea.Height + m_nTopMargin) )
					{
						if ( (m_nCurrPage + 2) > m_arlUltimoProdutoInserido.Count )
						{
							m_arlUltimoProdutoInserido.Add( i );
						}
						break; 
					}
					for(int k = 0; k < arrgraobjPaint.Length;k++)
					{
						GraphicObject objgra = (GraphicObject)arrgraobjPaint[k];
						base.PaintOneObject(ref graph, ref objgra);
					}
				}
				nYAreaProd = m_rectProductArea.Y + m_nTopMargin;
			}
			catch
			{
			}
		}

		protected int nCalculaNumeroDePaginas( ref Graphics graph )
		{
			// Total Pages Forced
			if (m_nTotalPagesForced != -1)
				return(m_nTotalPagesForced);

			if ( !m_bHasProductArea || (m_arlProdutos == null)
				|| (m_arlProdutos.Count == 0) )
				return( 1 );

			ArrayList arlProdutos;
			int nAltura, nIndiceCol, nNumeroDeProdutos;
			GraphicObject obj;
			TextObject objTextAtual = null;
			mdlRelatoriosCallBackAreaProdutos.DataStruct estrProd;

			m_nCurrPage = 0;
			m_arlUltimoProdutoInserido.Clear();
			m_arlUltimoProdutoInserido.Add( 0 );

			arlProdutos = (ArrayList)m_arlProdutos[ 0 ];
			nNumeroDeProdutos = arlProdutos.Count;

			int nNumPags = 1;
			int nYAreaProd = m_rectProductArea.Y + m_nTopMargin;

			for ( int i = 1; i < nNumeroDeProdutos; i++ )
			{
				estrProd.nHeight = 0;
				nAltura = 0;
				for ( int j = 0; j < m_arlColunasProdutos.Count; j++ )
				{
					nIndiceCol = nIndiceListaDeProdutos(((DBTextObject)m_arlColunasProdutos[j]).nIdDBField);
					arlProdutos = (ArrayList)m_arlProdutos[ nIndiceCol ];
					estrProd = (mdlRelatoriosCallBackAreaProdutos.DataStruct)arlProdutos[ i ];

					objTextAtual = (TextObject)((DBTextObject)m_arlColunasProdutos[j]).Clone();
					objTextAtual.strText = estrProd.strText;
					objTextAtual.fntText = (estrProd.fntText != null) ? estrProd.fntText : objTextAtual.fntText;
					objTextAtual.ptSource.Y = nYAreaProd;
					objTextAtual.ptSource.X = objTextAtual.ptSource.X + estrProd.nWidth;
					objTextAtual.ptDestiny.Y = nYAreaProd + (((DBTextObject)m_arlColunasProdutos[j]).ptDestiny.Y - ((DBTextObject)m_arlColunasProdutos[j]).ptSource.Y);
					objTextAtual.size = sizeText(ref objTextAtual.strText, ref objTextAtual.fntText );
					TextObject objClone = (TextObject)objTextAtual.Clone();
					this.PaintText(ref graph,ref objClone,ref objClone.fntText,ref objClone.ptSource,ref objClone.ptDestiny,ref objClone.size,objClone.clrText);
					if (objClone.size.Height > nAltura)
						nAltura = objClone.size.Height;
					obj = (GraphicObject)objTextAtual;

					nAltura = (nAltura > objTextAtual.size.Height) ? nAltura : objTextAtual.size.Height;
					base.PaintOneObject( ref graph, ref obj );
				}
				nYAreaProd += nAltura;
				if ( (nYAreaProd > (m_rectProductArea.Y + m_rectProductArea.Height + m_nTopMargin)) && (i <= (nNumeroDeProdutos - 1)) )
				{
					nNumPags++;
					nYAreaProd = m_rectProductArea.Y + m_nTopMargin;
					if (m_rectProductArea.Height > nAltura)
						i--;
				}
			}
			return( nNumPags );
		}

		protected void PaintProductArea( ref Graphics graph )
		{
			Rectangle rectProdAreaScreen = m_rectProductArea;
			rectProdAreaScreen.X += 1;
			rectProdAreaScreen.Width -= 1;
			rectProdAreaScreen.Y += (m_nTopMargin + 1);
			rectProdAreaScreen.Height -= 1;
			rectWorld2Screen( ref rectProdAreaScreen );
			graph.FillRectangle( new SolidBrush(m_clrProductArea), rectProdAreaScreen );
		}

		protected void PaintMargins( ref Graphics graph )
		{
			Point pt1 = new Point(0, 0);
			Point pt2 = new Point(0, 0);
			Size size = PageSize;
			Pen marginPen = new Pen( m_clrMargin, 0.5F );
			marginPen.DashStyle = DashStyle.DashDotDot;

			pt1.X = m_nLeftMargin; pt1.Y = 0;
			pt2.X = m_nLeftMargin; pt2.Y = size.Height;
			ptWorld2Screen( ref pt1 );
			ptWorld2Screen( ref pt2 );
			graph.DrawLine( marginPen, pt1, pt2 );

			pt1.X = size.Width - m_nRightMargin; pt1.Y = 0;
			pt2.X = size.Width - m_nRightMargin; pt2.Y = size.Height;
			ptWorld2Screen( ref pt1 );
			ptWorld2Screen( ref pt2 );
			graph.DrawLine( marginPen, pt1, pt2 );

			pt1.X = 0; pt1.Y = m_nTopMargin;
			pt2.X = size.Width; pt2.Y = m_nTopMargin;
			ptWorld2Screen( ref pt1 );
			ptWorld2Screen( ref pt2 );
			graph.DrawLine( marginPen, pt1, pt2 );

			pt1.X = 0; pt1.Y = size.Height - m_nBottomMargin - 1;
			pt2.X = size.Width; pt2.Y = size.Height - m_nBottomMargin - 1;
			ptWorld2Screen( ref pt1 );
			ptWorld2Screen( ref pt2 );
			graph.DrawLine( marginPen, pt1, pt2 );
		}


		protected override void CreateNewObject(bool bAddToSystem)
		{
			// Setando o relatorio como nao modificado
			if (bAddToSystem)
				m_bModificado = true;

			GraphicObject newObj;
			switch (CurrentTool)
			{
				case Tool.Text:
				switch (CurrentSubTool)
				{
					case SubTool.DBText:
						Size size;
						String strObjName;
						DBTextObject newDBText = new DBTextObject();
						newDBText.nIdDBField = m_nIdCampoBD;
						newDBText.bVisibleForPrinting = m_bObjetoVisivelImpressao;
						newDBText.bCallback = m_bObjetoCallBackBD;
						switch (m_nObjetoAlinhamento)
						{
							case 0:
								newDBText.alignment = Alignment.Left;
								break;
							case 1:
								newDBText.alignment = Alignment.Center;
								break;
							case 2:
								newDBText.alignment = Alignment.Right;
								break;
						}
						newDBText.strText = m_strText;
						newDBText.clrText = m_clrText;
						newDBText.fntText = m_fntText;

						Graphics memDC = GetMemoryDC();
						if ((newDBText.strText != null) && (newDBText.strText != ""))
							newDBText.size = sizeText(ref newDBText.strText, ref newDBText.fntText );

						if (bAddToSystem)
						{
							if ( (newDBText.nIdDBField.ToString().Length >= 2)
								&& (newDBText.nIdDBField.ToString().EndsWith("00")) )
								newDBText.clrBack = m_clrBackDBTextOnlyText;
							else
								newDBText.clrBack = m_clrBackDBText;
						}
						else
						{
							newDBText.clrBack = System.Drawing.Color.LightGray;
							newDBText.strText = "Escolha o tamanho do campo";
							newDBText.clrText = System.Drawing.Color.White;
						}
						newDBText.ptSource = m_ptSource;
						if ( newDBText.ptSource.Equals(m_ptDestiny) )
						{
							TextObject objText = (TextObject)newDBText;
							CheckOffScreenBitmap();
							memDC = GetMemoryDC();
//							size = sizeText( ref memDC, ref objText );
							size = sizeText(ref objText );
							newDBText.size = size;
							newDBText.ptDestiny.X = newDBText.ptSource.X + size.Width;
							newDBText.ptDestiny.Y = newDBText.ptSource.Y + size.Height;
						} 
						else
							newDBText.ptDestiny = m_ptDestiny;
						newDBText.rect = BuildRect( ref newDBText.ptSource, ref newDBText.ptDestiny );
						strObjName = "DBTextObject#" + m_nObjectIndexer++;
						newObj = (GraphicObject)newDBText;
						if  ( bAddToSystem )
							AddObjToSystem( ref newObj, ref strObjName );
						else
							SetTempObject( ref newObj );							
						break;

					default:
						base.CreateNewObject( bAddToSystem );
						break;
				}
					break;

				default:
					base.CreateNewObject( bAddToSystem );
					break;
			}
		}

		#endregion
		#region CallBack & CallBackAreaProdutos
			public void vLoadFields(ref ArrayList arlListDeIDs)
			{
				RecarregaListaDeIDs(ref arlListDeIDs);  
			}

		protected void RecarregaListaDeIDs( ref ArrayList arlListDeIDs )
		{	
			try
			{
				ArrayList arlObjIndex;
				IList ilValues;
				DBTextObject objDBText;
				int nIDDBField, nIndexOfValue, nIndexObj;

				System.Windows.Forms.Cursor curOld = System.Windows.Forms.Cursor.Current;
				System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;

				Graphics memDC = GetMemoryDC();
				Size size;

				m_cls_dba_ConnectionDB.DataPersist = true;

				for ( int i = 0; i < arlListDeIDs.Count; i++ )
				{
					nIDDBField = (int)arlListDeIDs[ i ];
					nIndexOfValue = m_slsIDField.IndexOfKey( nIDDBField );
					if (nIndexOfValue != -1)
					{
						ilValues = m_slsIDField.GetValueList();
						arlObjIndex = (ArrayList)ilValues[ nIndexOfValue ];
						for ( int j = 0; j < arlObjIndex.Count; j++ )
						{
							nIndexObj = (int)arlObjIndex[ j ];
							objDBText = (DBTextObject)m_colGraphObj[ nIndexObj ];
							objDBText.strText = m_callback.strCarregaDados( objDBText.nIdDBField ); 
							// Redimensiona o tamanho do texto ocupado
							TextObject objText = (TextObject)objDBText;
							size = sizeText(ref objText );
							objDBText.size = size;
						}
					}
				}
				m_cls_dba_ConnectionDB.DataPersist = false;
				System.Windows.Forms.Cursor.Current = curOld;
			}
			catch (System.Exception objExp)
			{
				m_tratadorErro.trataErro(ref objExp);
			}
		}

		public void MostrarAreaProdutos()
		{
			m_ptMousePos = new System.Drawing.Point(m_rectProductArea.X + 1,m_rectProductArea.Y + 1);
			MostrarJanela(-1);
		}

		protected void MostrarJanela( int nIndexObj )
		{
			int nStat = -1, nCod;
			DBTextObject objDBText;
			ArrayList arlRetorno;

			if ( m_bHasProductArea && (new System.Drawing.Rectangle(m_rectProductArea.X,m_rectProductArea.Y + m_nTopMargin ,m_rectProductArea.Width,m_rectProductArea.Height)).Contains(MousePos) )
			{
				// Mostrando a Area de Produtos 
				System.Windows.Forms.Cursor curAntigo = Cursor;
				Cursor = System.Windows.Forms.Cursors.WaitCursor;
				m_cls_dba_ConnectionDB.DataPersist = true;
				arlRetorno = m_callbackAreaDeProdutos.arlShowDialog(m_nIdExportador,m_strIdCodigo,m_nIdTipo,ref nStat);
				if ( nStat != (int)CallbackStatus.NaoFazerNada )
				{
					if ( nStat == (int)CallbackStatus.RecarregarTudo )
					{
						m_callback.vDataPersistClear();
						bAbrirRelatorio(m_nIdExportador,m_nIdTipo,m_nIdRelatorio);
						OnPageCountChanged(EventArgs.Empty);
						OnPageNumberChanged(EventArgs.Empty);
						OnCallProductsChanged();
					}
					else
					{
						nCod = nStat & 0x4;
						if ( nCod == (int)CallbackStatus.RecarregarAreaDeProdutos )
						{
							m_callbackAreaDeProdutos.Idioma = m_nIdIdioma;
							m_arlProdutos =  GetDadosAreaProdutos( m_nIdExportador,m_strIdCodigo,m_nIdTipo);
							Graphics memDC = GetMemoryDC();
							int nTotalPagesBefore = m_nTotalPages;
							m_nTotalPages = nCalculaNumeroDePaginas( ref memDC );
							OnPageCountChanged(EventArgs.Empty);
							OnPageNumberChanged(EventArgs.Empty);
							OnCallProductsChanged();
							m_callback.vDataPersistClear();
						}
						nCod = nStat & (int)CallbackStatus.RecaregarLista;
						if ( nCod == (int)CallbackStatus.RecaregarLista )
							RecarregaListaDeIDs( ref arlRetorno );
						RepaintScreen();
					}
				}
				Cursor = curAntigo;
				return;
			}

			if ( nIndexObj != -1 )
			{
				if ( (((GraphicObject)m_colGraphObj[nIndexObj]).nType == Tool.Text)
					&& (((GraphicObject)m_colGraphObj[nIndexObj]).nSubType == (int)SubTool.DBText)
					&& ((GraphicObject)m_colGraphObj[nIndexObj]).bHighlighted )
				{
					
					System.Windows.Forms.Cursor curOld = System.Windows.Forms.Cursor.Current;
					System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;

					objDBText = (DBTextObject)m_colGraphObj[ nIndexObj ];
					m_cls_dba_ConnectionDB.DataPersist = false;
					arlRetorno = m_callback.arlShowDialog( objDBText.nIdDBField, objDBText.nFunction, ref nStat );

					if ( nStat != (int)CallbackStatus.NaoFazerNada )
					{
						if ( nStat == (int)CallbackStatus.RecarregarTudo )
						{
							m_callback.vDataPersistClear();
							bAbrirRelatorio(m_nIdExportador,m_nIdTipo,m_nIdRelatorio);
							OnPageCountChanged(EventArgs.Empty);
							OnPageNumberChanged(EventArgs.Empty);
							OnCallProductsChanged();
						}
						else
						{
							nCod = nStat & 0x4;
							if ( nCod == (int)CallbackStatus.RecarregarAreaDeProdutos )
							{
								m_callbackAreaDeProdutos.Idioma = m_nIdIdioma;
								m_arlProdutos =  GetDadosAreaProdutos( m_nIdExportador,m_strIdCodigo,m_nIdTipo);
								OnPageCountChanged(EventArgs.Empty);
								OnPageNumberChanged(EventArgs.Empty);
								OnCallProductsChanged();
								m_callback.vDataPersistClear();
							}
							nCod = nStat & (int)CallbackStatus.RecaregarLista;
							if ( nCod == (int)CallbackStatus.RecaregarLista )
								RecarregaListaDeIDs( ref arlRetorno );
						}
					}
					System.Windows.Forms.Cursor.Current = curOld;
				}
			}
		}

		protected void BuildProdAreaRect( Point pt1, Point pt2 )
		{
			Point ptSrc = pt1;
			Point ptDest = pt2;

			ptSrc.Y = (ptSrc.Y > m_nTopMargin) ? ptSrc.Y : m_nTopMargin;
			ptSrc.Y = (ptSrc.Y < (PageSize.Height - m_nBottomMargin)) ? ptSrc.Y : (PageSize.Height - m_nBottomMargin);

			ptDest.Y = (ptDest.Y < (PageSize.Height - m_nBottomMargin)) ? ptDest.Y : (PageSize.Height - m_nBottomMargin);
			ptDest.Y = (ptDest.Y > m_nTopMargin) ? ptDest.Y : m_nTopMargin;

			ptSrc.X = m_nLeftMargin;
			ptDest.X = (PageSize.Width - m_nRightMargin);

			m_rectProductArea = BuildRect( ref ptSrc, ref ptDest );
			m_rectProductArea.Offset( 0, -m_nTopMargin );
		}

		private int[] GetListaIDCamposAreaProdutos()
		{
			System.Collections.ArrayList arlIdCampos = new ArrayList();
			if (m_colGraphObj != null)
			{
				for (int i = 0; i < m_colGraphObj.Count; i++)
				{
					GraphicObject obj = (GraphicObject)m_colGraphObj[i];
					if ((obj.nType == Tool.Text) && (obj.nSubType == (int)SubTool.DBText))
					{
						DBTextObject objDB = (DBTextObject)obj;
						if (objDB.bBelongsProdutctArea)
							arlIdCampos.Add(objDB.nIdDBField);
					}
				}
			}
			int[] anIDCampos = new int[arlIdCampos.Count];
			for(int i = 0;i < arlIdCampos.Count;i++)
				anIDCampos[i] = Int32.Parse(arlIdCampos[i].ToString());
			return(anIDCampos);
		}

		private System.Collections.ArrayList GetDadosAreaProdutos(int nIdExportador,string strIdCodigo,int nIdTipo)
		{
			m_callbackAreaDeProdutos.ListaIDsCamposAreaProdutos = this.GetListaIDCamposAreaProdutos();
			return(m_callbackAreaDeProdutos.arlRetornaDadosAreaProdutos(nIdExportador,strIdCodigo,nIdTipo));
		}

		#endregion
		#region Especial Fields
		private void refreshFieldPageNumber()
		{
			if (m_bViewMode)
			{
				for (int i = 0; i < m_colGraphObj.Count; i++)
				{
					if (((GraphicObject)m_colGraphObj[i]).GetType().ToString() == "ReportCanvasPackage.DBTextObject" )
					{
						switch(((ReportCanvasPackage.DBTextObject)m_colGraphObj[i]).nIdDBField)
						{
							case 199:
								((ReportCanvasPackage.DBTextObject)m_colGraphObj[i]).strText = (m_nCurrPage + 1).ToString() + "/" + m_nTotalPages.ToString();
								break;
							case 399:
								((ReportCanvasPackage.DBTextObject)m_colGraphObj[i]).strText = m_strReportName;
								break;
						}
					}
				}
			}
		}
		#endregion
		#region ClipBoard
		#region ToClipBoard
		public bool bCopyToClipBoard()
		{
			string strTextToSend = "";

			if (m_colSelObjs.Count == 0)
				return false;
	               
			GraphicObject obj;
			int nPos;
			for (int nCont = 0 ; nCont < m_colSelObjs.Count ; nCont++)
			{
				if (strTextToSend != "")
					strTextToSend = strTextToSend + System.Environment.NewLine;
				nPos = (int)m_colSelObjs.GetByIndex(nCont);
				obj = (GraphicObject)m_colGraphObj[nPos];
				strTextToSend = strTextToSend + strReturnTextOffObject(obj);
			}
			System.Windows.Forms.Clipboard.SetDataObject(strTextToSend,true);
			return (true);
		}

		private string strReturnTextOffObject(GraphicObject objeto)
		{
			string strTextoRetorno = "";
			switch(objeto.GetType().ToString())
			{
				case "DrawingCanvasPackage.LineObject":
					strTextoRetorno = strRetornaStringLinha((LineObject)objeto);
					break;

				case "DrawingCanvasPackage.CircleObject":
					strTextoRetorno = strRetornaStringCirculo((CircleObject)objeto);
					break;

				case "DrawingCanvasPackage.RectangleObject":
					strTextoRetorno = strRetornaStringRetangulo((RectangleObject)objeto);
					break;

				case "DrawingCanvasPackage.TextObject":
					strTextoRetorno = strRetornaStringTexto((TextObject)objeto);
					break;
			}              
			return (strTextoRetorno);
		} 
		#region Retornando a String Correspondente aos Objetos
		private string strRetornaStringLinha(LineObject objeto)
		{
			string strTextoRetorno = "";

			strTextoRetorno = "#LineObject#";
			// X1 
			strTextoRetorno = strTextoRetorno + " #X1 " + (objeto.ptSource.X - m_nLeftMargin) + "#";
			// Y1
			strTextoRetorno = strTextoRetorno + " #Y1 " + (objeto.ptSource.Y - m_nTopMargin) + "#";
			// X2 
			strTextoRetorno = strTextoRetorno + " #X2 " + (objeto.ptDestiny.X - m_nLeftMargin) + "#";
			// Y2 
			strTextoRetorno = strTextoRetorno + " #Y2 " + (objeto.ptDestiny.Y - m_nTopMargin) + "#";
			// Espessura 
			strTextoRetorno = strTextoRetorno + " #ESP " + (objeto.nPenWidth) + "#";
			// visivel Impressao
			strTextoRetorno = strTextoRetorno + " #VIS " + (objeto.bVisibleForPrinting) + "#";
			// estilo_caneta 
			strTextoRetorno = strTextoRetorno + " #ESTC " + ((int)objeto.nPenStyle) + "#";
			// estilo_linha 
			strTextoRetorno = strTextoRetorno + " #ESTL " + ((int)objeto.nType) + "#";
			// corRGB
			strTextoRetorno = strTextoRetorno + " #RGB " + (objeto.clrPen.ToArgb()) + "#";

			return (strTextoRetorno);
		}

		private string strRetornaStringCirculo(CircleObject objeto)
		{
			string strTextoRetorno = "";

			strTextoRetorno = "#CircleObject#";
			// X1 
			strTextoRetorno = strTextoRetorno + " #X1 " + (objeto.ptSource.X - m_nLeftMargin) + "#";
			// Y1
			strTextoRetorno = strTextoRetorno + " #Y1 " + (objeto.ptSource.Y - m_nTopMargin) + "#";
			// X2 
			strTextoRetorno = strTextoRetorno + " #X2 " + (objeto.ptDestiny.X - m_nLeftMargin) + "#";
			// Y2 
			strTextoRetorno = strTextoRetorno + " #Y2 " + (objeto.ptDestiny.Y - m_nTopMargin) + "#";
			// Espessura 
			strTextoRetorno = strTextoRetorno + " #ESP " + (objeto.nPenWidth) + "#";
			// visivel Impressao
			strTextoRetorno = strTextoRetorno + " #VIS " + (objeto.bVisibleForPrinting) + "#";
			// estilo_caneta 
			strTextoRetorno = strTextoRetorno + " #ESTC " + ((int)objeto.nPenStyle) + "#";
			// corRGB
			strTextoRetorno = strTextoRetorno + " #RGB " + (objeto.clrPen.ToArgb()) + "#";
			// corRGB Fundo
			strTextoRetorno = strTextoRetorno + " #RGF " + (objeto.clrBack.ToArgb()) + "#";
			// Opaco 
			strTextoRetorno = strTextoRetorno + " #OPA " + (objeto.bOpaque) + "#";
			return (strTextoRetorno);
		}

		private string strRetornaStringRetangulo(RectangleObject objeto)
		{
			string strTextoRetorno = "";

			strTextoRetorno = "#RectangleObject#";
			// X1 
			strTextoRetorno = strTextoRetorno + " #X1 " + (objeto.ptSource.X - m_nLeftMargin) + "#";
			// Y1
			strTextoRetorno = strTextoRetorno + " #Y1 " + (objeto.ptSource.Y - m_nTopMargin) + "#";
			// X2 
			strTextoRetorno = strTextoRetorno + " #X2 " + (objeto.ptDestiny.X - m_nLeftMargin) + "#";
			// Y2 
			strTextoRetorno = strTextoRetorno + " #Y2 " + (objeto.ptDestiny.Y - m_nTopMargin) + "#";
			// Espessura 
			strTextoRetorno = strTextoRetorno + " #ESP " + (objeto.nPenWidth) + "#";
			// visivel Impressao
			strTextoRetorno = strTextoRetorno + " #VIS " + (objeto.bVisibleForPrinting) + "#";
			// estilo_caneta 
			strTextoRetorno = strTextoRetorno + " #ESTC " + ((int)objeto.nPenStyle) + "#";
			// corRGB
			strTextoRetorno = strTextoRetorno + " #RGB " + (objeto.clrPen.ToArgb()) + "#";
			// corRGB Fundo
			strTextoRetorno = strTextoRetorno + " #RGF " + (objeto.clrBack.ToArgb()) + "#";
			// Opaco 
			strTextoRetorno = strTextoRetorno + " #OPA " + (objeto.bOpaque) + "#";
			return (strTextoRetorno);
		}

		private string strRetornaStringTexto(TextObject objeto)
		{
			string strTextoRetorno = "";

			strTextoRetorno = "#TextObject#";
			// X1 
			strTextoRetorno = strTextoRetorno + " #X1 " + (objeto.ptSource.X - m_nLeftMargin) + "#";
			// Y1
			strTextoRetorno = strTextoRetorno + " #Y1 " + (objeto.ptSource.Y - m_nTopMargin) + "#";
			// visivel Impressao
			strTextoRetorno = strTextoRetorno + " #VIS " + (objeto.bVisibleForPrinting) + "#";
			// corRGB
			strTextoRetorno = strTextoRetorno + " #RGB " + (objeto.clrText.ToArgb()) + "#";
			// Texto 
			strTextoRetorno = strTextoRetorno + " #TEXT " + (objeto.strText) + "#";
			// Nome Fonte
			strTextoRetorno = strTextoRetorno + " #FNT " + (objeto.fntText.Name.ToString()) + "#";
			// Tamanho Fonte 
			strTextoRetorno = strTextoRetorno + " #TFONT " + (objeto.fntText.Size) + "#";
			// Negrito 
			strTextoRetorno = strTextoRetorno + " #NFON " + (objeto.fntText.Bold.ToString()) + "#";
			// Italico 
			strTextoRetorno = strTextoRetorno + " #IFON " + (objeto.fntText.Italic.ToString()) + "#";
			// StrikeOut 
			strTextoRetorno = strTextoRetorno + " #STFON " + (objeto.fntText.Strikeout.ToString()) + "#";
			// Sublinhada 
			strTextoRetorno = strTextoRetorno + " #SUFON " + (objeto.fntText.Underline.ToString()) + "#";

			return (strTextoRetorno);
		}
		
		#endregion
		#endregion
		#region FromClipBoard
		public bool bCopyFromClipBoard()
		{
			System.Windows.Forms.IDataObject idtObjeto;
			string strTextoInserir = "";
			idtObjeto = System.Windows.Forms.Clipboard.GetDataObject();
			strTextoInserir = (string)idtObjeto.GetData(System.Windows.Forms.DataFormats.Text);

			int nQuant = m_colGraphObj.Count;
			int nPos;
			while((strTextoInserir != "") && (strTextoInserir != null))
			{
				nPos = strTextoInserir.IndexOf(System.Environment.NewLine);                                       
				if (nPos != -1)
				{
					InsertObject(strTextoInserir.Substring(0,nPos));
					strTextoInserir = strTextoInserir.Substring(nPos + 2);
				}
				else
				{
					InsertObject(strTextoInserir);
					strTextoInserir = "";
				}
			}
			ClearSelection(false);
			// Seleciondo os Objetos Inseridos 
			for(int nCont = nQuant; nCont < m_colGraphObj.Count;nCont++)
			{
				m_colSelObjs.Add(nCont,nCont);       
			}
			if (nQuant != m_colGraphObj.Count)
			{
				m_rectSelection = BuildSelRect();
				RefreshRelatorio();
			}
			return (true);
		}

		private void InsertObject(string strTextoObjetoGrafico)
		{
			string strCabecalhoObjeto = "";
			string strCorpoObjeto = "";
			int nPos;
			if ((strTextoObjetoGrafico != null ) && (strTextoObjetoGrafico != "" ) && (strTextoObjetoGrafico.Substring(0,1) == "#") )
			{
				nPos = strTextoObjetoGrafico.IndexOf("#",1);
				if (nPos > 0)
				{
					strCabecalhoObjeto = strTextoObjetoGrafico.Substring(1,nPos - 1);
					strCorpoObjeto = strTextoObjetoGrafico.Substring(nPos + 1);
				}
				DrawingCanvasPackage.Tool oldTool = m_currTool;
				ReportCanvasPackage.SubTool oldSubTool = m_currSubTool;
				switch(strCabecalhoObjeto)
				{
					case"LineObject":
						m_currTool = DrawingCanvasPackage.Tool.Line;
						m_currSubTool = ReportCanvasPackage.SubTool.None;
						InsertObjectLine(strCorpoObjeto);
						break;
					case "CircleObject":
						m_currTool = DrawingCanvasPackage.Tool.Circle;
						m_currSubTool = ReportCanvasPackage.SubTool.None;
						InsertObjectLine(strCorpoObjeto);
						break;
					case "RectangleObject":
						m_currTool = DrawingCanvasPackage.Tool.Rectangle;
						m_currSubTool = ReportCanvasPackage.SubTool.None;
						InsertObjectLine(strCorpoObjeto);
						break;
					case "TextObject":
						m_currTool = DrawingCanvasPackage.Tool.Text;
						m_currSubTool = ReportCanvasPackage.SubTool.None;
						InsertObjectText(strCorpoObjeto);
						break;
				}
				m_currTool = oldTool;
				m_currSubTool = oldSubTool;
			}
		}

		private string strRetornaPropriedadeObjetoString(string strObjeto,string Sessao, string ValorDefault)
		{
			string strRetorno = ValorDefault;
			int nPos, nPosFinal;

			nPos = strObjeto.IndexOf(Sessao);
			if (nPos != -1)
			{
				nPosFinal = (strObjeto.Substring(nPos)).IndexOf("#");
				if (nPosFinal != -1)
				{
					nPosFinal = nPos + nPosFinal ;
					nPos++;
					strRetorno = strObjeto.Substring(nPos + Sessao.Length,nPosFinal  - (nPos + Sessao.Length));
				}
			}
			return (strRetorno);
		}

		#region Retornando o Objeto Referente a String
		private void InsertObjectLine(string strLinha)
		{
			LineObject obj = null;
			obj = new LineObject();

			// Grupo da Linha
			obj.nGroup = -1;

			obj.bResizeable = true;

			// X1
			int X1 = Int32.Parse(strRetornaPropriedadeObjetoString(strLinha,"X1","0"));
			X1 = X1 + m_nLeftMargin;
			// Y1
			int Y1 = Int32.Parse(strRetornaPropriedadeObjetoString(strLinha,"Y1","0"));
			Y1 = Y1 + m_nTopMargin;
			m_ptSource = new System.Drawing.Point(X1,Y1);
			// X2
			int X2 = Int32.Parse(strRetornaPropriedadeObjetoString(strLinha,"X2","0"));
			X2 = X2 + m_nLeftMargin;
			// Y2
			int Y2 = Int32.Parse(strRetornaPropriedadeObjetoString(strLinha,"Y2","0"));
			Y2 = Y2 + m_nTopMargin;
			m_ptDestiny = new System.Drawing.Point(X2,Y2);
			// Estilo Caneta 
			m_nPenStyle = (System.Drawing.Drawing2D.DashStyle)Int32.Parse(strRetornaPropriedadeObjetoString(strLinha,"ESTC","1"));
			// Espessura da Caneta 
			m_nPenWidth = Int32.Parse(strRetornaPropriedadeObjetoString(strLinha,"ESP","1"));
			// Estilo Linha 
			switch(Int32.Parse(strRetornaPropriedadeObjetoString(strLinha,"ESTL","1")))
			{
				case 0:
					m_nLineStyle = DrawingCanvasPackage.LineStyle.Horizontal;
					break;
				case 1:
					m_nLineStyle = DrawingCanvasPackage.LineStyle.Vertical;
					break;
				case 2:
					m_nLineStyle = DrawingCanvasPackage.LineStyle.Free; 
					break;
			}
			// Cor Linha 
			m_clrPen = System.Drawing.Color.FromArgb(Int32.Parse(strRetornaPropriedadeObjetoString(strLinha,"RGB","1")));

			// Visivel na Impressao 
			if (strRetornaPropriedadeObjetoString(strLinha,"VIS","True") == "True")
				m_bObjectPrintable = true;
			else
				m_bObjectPrintable = false;

			CreateNewObject(true);
		}

		private void InsertObjectCircle(string strCirculo)
		{
			CircleObject obj = null;
			obj = new CircleObject();

			// Grupo do Circulo
			obj.nGroup = -1;

			obj.bResizeable = true;

			// X1
			int X1 = Int32.Parse(strRetornaPropriedadeObjetoString(strCirculo,"X1","0"));
			X1 = X1 + m_nLeftMargin;
			// Y1
			int Y1 = Int32.Parse(strRetornaPropriedadeObjetoString(strCirculo,"Y1","0"));
			Y1 = Y1 + m_nTopMargin;
			m_ptSource = new System.Drawing.Point(X1,Y1);
			// X2
			int X2 = Int32.Parse(strRetornaPropriedadeObjetoString(strCirculo,"X2","0"));
			X2 = X2 + m_nLeftMargin;
			// Y2
			int Y2 = Int32.Parse(strRetornaPropriedadeObjetoString(strCirculo,"Y2","0"));
			Y2 = Y2 + m_nTopMargin;
			m_ptDestiny = new System.Drawing.Point(X2,Y2);
			// Estilo Caneta 
			m_nPenStyle = (System.Drawing.Drawing2D.DashStyle)Int32.Parse(strRetornaPropriedadeObjetoString(strCirculo,"ESTC","1"));
			// Espessura da Caneta 
			m_nPenWidth = Int32.Parse(strRetornaPropriedadeObjetoString(strCirculo,"ESP","1"));
			// Cor 
			m_clrPen = System.Drawing.Color.FromArgb(Int32.Parse(strRetornaPropriedadeObjetoString(strCirculo,"RGB","1")));
			// Visivel na Impressao 
			if (strRetornaPropriedadeObjetoString(strCirculo,"VIS","True") == "True")
				m_bObjectPrintable = true;
			else
				m_bObjectPrintable = false;
			// corRGB Fundo
			m_clrBack = System.Drawing.Color.FromArgb(Int32.Parse(strRetornaPropriedadeObjetoString(strCirculo,"RGF","1")));
			// Opaco 
			if (strRetornaPropriedadeObjetoString(strCirculo,"OPA","True") == "True")
				m_bOpaque = true;
			else
				m_bOpaque = false;
			CreateNewObject(true);
		}

		private void InsertObjectRectangle(string strRetangulo)
		{
			RectangleObject obj = null;
			obj = new RectangleObject();

			// Grupo do Retangulo
			obj.nGroup = -1;

			obj.bResizeable = true;

			// X1
			int X1 = Int32.Parse(strRetornaPropriedadeObjetoString(strRetangulo,"X1","0"));
			X1 = X1 + m_nLeftMargin;
			// Y1
			int Y1 = Int32.Parse(strRetornaPropriedadeObjetoString(strRetangulo,"Y1","0"));
			Y1 = Y1 + m_nTopMargin;
			m_ptSource = new System.Drawing.Point(X1,Y1);
			// X2
			int X2 = Int32.Parse(strRetornaPropriedadeObjetoString(strRetangulo,"X2","0"));
			X2 = X2 + m_nLeftMargin;
			// Y2
			int Y2 = Int32.Parse(strRetornaPropriedadeObjetoString(strRetangulo,"Y2","0"));
			Y2 = Y2 + m_nTopMargin;
			m_ptDestiny = new System.Drawing.Point(X2,Y2);
			// Estilo Caneta 
			m_nPenStyle = (System.Drawing.Drawing2D.DashStyle)Int32.Parse(strRetornaPropriedadeObjetoString(strRetangulo,"ESTC","1"));
			// Espessura da Caneta 
			m_nPenWidth = Int32.Parse(strRetornaPropriedadeObjetoString(strRetangulo,"ESP","1"));
			// Cor 
			m_clrPen = System.Drawing.Color.FromArgb(Int32.Parse(strRetornaPropriedadeObjetoString(strRetangulo,"RGB","1")));
			// Visivel na Impressao 
			if (strRetornaPropriedadeObjetoString(strRetangulo,"VIS","True") == "True")
				m_bObjectPrintable = true;
			else
				m_bObjectPrintable = false;
			// corRGB Fundo
			m_clrBack = System.Drawing.Color.FromArgb(Int32.Parse(strRetornaPropriedadeObjetoString(strRetangulo,"RGF","1")));
			// Opaco 
			if (strRetornaPropriedadeObjetoString(strRetangulo,"OPA","True") == "True")
				m_bOpaque = true;
			else
				m_bOpaque = false;
			CreateNewObject(true);
		}

		private void InsertObjectText(string strTexto)
		{
			TextObject obj = null;
			obj = new TextObject();

			// Grupo do Retangulo
			obj.nGroup = -1;

			obj.bResizeable = true;

			// X1
			int X1 = Int32.Parse(strRetornaPropriedadeObjetoString(strTexto,"X1","0"));
			X1 = X1 + m_nLeftMargin;
			// Y1
			int Y1 = Int32.Parse(strRetornaPropriedadeObjetoString(strTexto,"Y1","0"));
			Y1 = Y1 + m_nTopMargin;
			m_ptSource = new System.Drawing.Point(X1,Y1);
			// Cor 
			m_clrText = System.Drawing.Color.FromArgb(Int32.Parse(strRetornaPropriedadeObjetoString(strTexto,"RGB","1")));
			// Visivel na Impressao 
			if (strRetornaPropriedadeObjetoString(strTexto,"VIS","True") == "True")
			{
				m_bObjectPrintable = true;
			}
			else
			{
				m_bObjectPrintable = false;
			}

			// Texto 
			m_strText = strRetornaPropriedadeObjetoString(strTexto,"TEXT","Indefinido");

			// Fonte
			string strNomeFonte = strRetornaPropriedadeObjetoString(strTexto,"FNT","Arial");
			float dTamanhoFonte = float.Parse(strRetornaPropriedadeObjetoString(strTexto,"TFONT","8"));
			m_fntText = new System.Drawing.Font(strNomeFonte,dTamanhoFonte);
			if (strRetornaPropriedadeObjetoString(strTexto,"NFON","False") == "True")
				m_fntText = new System.Drawing.Font(m_fntText,m_fntText.Style & System.Drawing.FontStyle.Bold);
			if (strRetornaPropriedadeObjetoString(strTexto,"IFON","False") == "True")
				m_fntText = new System.Drawing.Font(m_fntText,m_fntText.Style & System.Drawing.FontStyle.Italic);
			if (strRetornaPropriedadeObjetoString(strTexto,"STFON","False") == "True")
				m_fntText = new System.Drawing.Font(m_fntText,m_fntText.Style & System.Drawing.FontStyle.Strikeout);
			if (strRetornaPropriedadeObjetoString(strTexto,"SUFON","False") == "True")
				m_fntText = new System.Drawing.Font(m_fntText,m_fntText.Style & System.Drawing.FontStyle.Underline);

			CreateNewObject(true);
		}

		#endregion
		#endregion
		#endregion
		#region Resource
			private System.Windows.Forms.Cursor curReturnCursorFromResource(string strCursorName,System.Windows.Forms.Cursor curDefault)
			{
				System.Reflection.Assembly assCurrent = System.Reflection.Assembly.GetAssembly((this.GetType()));
				System.Windows.Forms.Cursor curReturn = curDefault;
				string[] arrStrAssembly = assCurrent.GetManifestResourceNames();
				foreach(string strCurrent in arrStrAssembly)
				{
					if (("MDLMANIPULADORGRAFICO.CURSORS." + strCursorName.ToUpper()) == strCurrent.ToUpper())
					{
						System.IO.Stream stmResource = assCurrent.GetManifestResourceStream(strCurrent);
						curReturn = new System.Windows.Forms.Cursor(stmResource);
						break;
					}
				}
				return(curReturn);
			} 
		#endregion
		#region Id's Methods
			private int nReturnNextId(int nIdExportador, int nIdTipo)
			{
				int nId = 1;
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdExportador);
				arlCondicaoCampo.Add("nIdTipo");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdTipo);
				mdlDataBaseAccess.Tabelas.XsdTbRelatorios typDatSetTbRelatorios = m_cls_dba_ConnectionDB.GetTbRelatorios(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				while(typDatSetTbRelatorios.tbRelatorios.FindBynIdExportadornIdTiponIdRelatorio(m_nIdExportador,m_nIdTipo,nId) != null)
				{
					nId++;
				}
				return(nId);
			}

			private int nReturnNextIdDefault(int nIdTipo)
			{
				int nId = 0;
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(0);
				arlCondicaoCampo.Add("nIdTipo");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdTipo);
				mdlDataBaseAccess.Tabelas.XsdTbRelatorios typDatSetTbRelatorios = m_cls_dba_ConnectionDB.GetTbRelatorios(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				while(typDatSetTbRelatorios.tbRelatorios.FindBynIdExportadornIdTiponIdRelatorio(m_nIdExportador,m_nIdTipo,nId) != null)
				{
					nId--;
				}
				return(nId);
			}
		#endregion
		#region Public methods
			#region SetViewMode
				public override void SetViewMode( bool bView )
				{
					m_bModificado = false;
					this.Cursor = System.Windows.Forms.Cursors.Default;
					m_currTool = Tool.None;
					m_currSubTool = SubTool.None;
					m_prevTool = Tool.None;
					m_prevSubTool = SubTool.None;
					base.SetViewMode(bView);
				}
			#endregion
			#region ClearData
				public override void ClearData( bool bRepaint )
				{
					m_strReportName = "";
					SetMargins(0,0,0,0,false);
					RemoveProductArea( false );
					base.ClearData(bRepaint);
				}
			#endregion
			#region RefreshRelatorio
				public void RefreshRelatorio()
				{
					RepaintScreen();
				}
			#endregion
			#region RefreshCursor
				public void refreshCursor()
				{
					dcMouseEnter(null,null);
				}
			#endregion
			#region ReportModified
				public bool bReportModified()
				{
					return (m_bModificado);
				}

        		public void SetReportAsModified()
				{
					m_bModificado = true;
				}
			#endregion
			#region RefreshFormatoRelatorio
				public void refreshFormatoRelatorio()
				{
					m_rectScreen = new System.Drawing.Rectangle(0,0,Width,Height);
					m_memBmp = null;
					RepaintScreen();
				}
			#endregion
			#region ReturnPageImage
				public bool bReturnPageImage(int nPageToReturn,ref System.Drawing.Image imgPage) 
				{
					if ((nPageToReturn >= 0) && (nPageToReturn < m_nTotalPages))
					{
						setPrinting(true);
						m_nSavedCurrPage = m_nCurrPage;
						m_nCurrPage = nPageToReturn;
						System.Drawing.Size szPage;
						szPage = m_sizePage;
						refreshFieldPageNumber();
						imgPage = (System.Drawing.Image)new System.Drawing.Bitmap(szPage.Width,szPage.Height);
						Graphics graph = System.Drawing.Graphics.FromImage(imgPage);
						graph.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.White),0,0,szPage.Width,szPage.Height);
						PaintObjects( ref graph );
						m_nCurrPage = m_nSavedCurrPage;
						setPrinting(false);
						return true;
					}
					else
					{
						return false;
					}
				}
			#endregion
			#region PDF
				public bool bReturnPage(int nPageToReturn,ref mdlPDF.clsPDF pdfReport)
				{
					if ((nPageToReturn >= 0) && (nPageToReturn < m_nTotalPages))
					{
						setIsCreatingPDF(true);
						m_pdfReport = pdfReport;
						m_nSavedCurrPage = m_nCurrPage;
						m_nCurrPage = nPageToReturn;
						System.Drawing.Size szPage;
						szPage = m_sizePage;
						refreshFieldPageNumber();
						System.Drawing.Graphics graph = this.GetMemoryDC();
						PaintObjects(ref graph );
						m_nCurrPage = m_nSavedCurrPage;
						setIsCreatingPDF(false);
						return true;
					}
					else
					{
						return false;
					}
				}
			#endregion
			#region VerificaLimitesImpressao
				public bool bVerificaLimitesDeImpressao()
				{
					//GraphicObject obj;
//					Rectangle rectPagina;

					// Desativado temporariamente ....
					return(true);
					
//					rectPagina = new Rectangle( m_nLeftMargin, m_nTopMargin, 
//						(PageSize.Width - m_nLeftMargin - m_nRightMargin), (PageSize.Height - m_nTopMargin - m_nBottomMargin) );
//
//					for ( int i = 0; i < m_colGraphObj.Count; i++ )
//					{
//						obj = (GraphicObject)m_colGraphObj[ i ];
//						if ( rectPagina.Contains(obj.rect) == false )
//							return( false );
//					}
//
//					return( true );
				}
			#endregion
			#region PrintReport
				public bool bPrintReport( bool bShowDialog )
				{
					if (m_pd == null)
						return( false );

					if ( bVerificaLimitesDeImpressao() == false )
					{
						if ( MessageBox.Show( "Existem objetos fora dos limites de impressão. Você quer prosseguir assim mesmo?", "Siscobras",
							MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No )
							return( false );
					}

					m_pd.DocumentName = m_strReportName;
					m_pd.PrinterSettings.FromPage = 1;
					if (m_nTotalPages < 1)
						m_nTotalPages = 1;
					m_pd.PrinterSettings.ToPage = m_nTotalPages;
					switch( m_nOrientation)
					{
						case (int)DrawingCanvasPackage.Orientation.Retract:
							m_pd.DefaultPageSettings.Landscape = false;
							break;
						case (int)DrawingCanvasPackage.Orientation.Image:
							m_pd.DefaultPageSettings.Landscape = true;
							break;
					}

					try
					{
						if ( bShowDialog )
						{
							PrintDialog dlgPrint = new PrintDialog();
							dlgPrint.AllowSomePages = true;
							dlgPrint.Document = m_pd;
							if ( dlgPrint.ShowDialog() == DialogResult.OK )
							{
								m_pd.Print();
								return( true );
							}
						} 
						else
						{
							try
							{
								if (m_pd.PrinterSettings.IsDefaultPrinter)
									m_pd.Print();
							}
							catch
							{
								return(false);
							}
						}
					}catch{
						mdlMensagens.clsMensagens.ShowError("Ocorreu um problema ao tentar imprimir o documento." + System.Environment.NewLine + "Verifique se sua impressora esta ligada.");
					}
					setPrinting(false);

					return( true );
				}
			#endregion
			#region Pages 
				public bool bNextPage()
				{
					bool bNeedRefresh = false;

					if ( m_nCurrPage < (m_nTotalPages - 1) )
					{
						m_nCurrPage++;
						refreshFieldPageNumber();
						bNeedRefresh = true;
						OnPageNumberChanged(null);
					}

					if (bNeedRefresh)
						RepaintScreen();
					return( bNeedRefresh );
				}

				public bool bPreviousPage()
				{
					bool bNeedRefresh = false;

					if ( m_nCurrPage > 0 )
					{
						m_nCurrPage--;
						refreshFieldPageNumber();
						bNeedRefresh = true;
						OnPageNumberChanged(null);
					}

					if ( bNeedRefresh )
						RepaintScreen();

					return( bNeedRefresh );
				}

				public bool bLastPage()
				{
					bool bNeedRefresh = (m_nCurrPage < (m_nTotalPages - 1) );
					refreshFieldPageNumber();
					m_nCurrPage = (m_nTotalPages - 1);
					if (m_arlUltimoProdutoInserido.Count < m_nCurrPage)
					{
						int nCurrPage = m_nCurrPage;
						System.Drawing.Graphics gra = System.Drawing.Graphics.FromImage(((System.Drawing.Image)(new System.Drawing.Bitmap(100,100)))); 
						while(m_arlUltimoProdutoInserido.Count <= nCurrPage)
						{
							m_nCurrPage = m_arlUltimoProdutoInserido.Count - 1;
							PaintProducts(ref gra);
						}
						m_nCurrPage = nCurrPage;
						OnPageNumberChanged(null);
					}
					if ( bNeedRefresh )
						RepaintScreen();

					return( bNeedRefresh );
				}

				public bool bFirstPage()
				{
					bool bNeedRefresh = (m_nCurrPage > 0 );
					m_nCurrPage = 0;
					refreshFieldPageNumber();
					OnPageNumberChanged(null);

					if ( bNeedRefresh )
						RepaintScreen();

					return( bNeedRefresh );
				}

				public bool bSetPage( int nPage )
				{
					bool bNeedRefresh = (nPage >= 0) || (nPage < m_nTotalPages);

					if ( bNeedRefresh )
					{
						m_nCurrPage = nPage;
						refreshFieldPageNumber();
						RepaintScreen();
						OnPageNumberChanged(null);
					}

					return( bNeedRefresh );
				}

				public int nTotalPages()
				{
					return( m_nTotalPages );
				}

				public int nCurrentPage()
				{
					return( m_nCurrPage );
				}
			#endregion
			#region ReportName 
				public String GetReportName()
				{
					return( m_strReportName );
				}
			#endregion
			#region RemoveProductArea
				public void RemoveProductArea( bool bRepaint )
				{
					m_rectProductArea.X = 0;
					m_rectProductArea.Y = 0;
					m_rectProductArea.Width = 0;
					m_rectProductArea.Height = 0;
					m_bShowProductArea = false;

					if ( bRepaint )
						RepaintScreen();
				}
			#endregion	
			#region Margins 

				public int GetLeftMargin()
				{
					return( m_nLeftMargin );
				}

				public int GetRightMargin()
				{
					return( m_nRightMargin );
				}

				public int GetTopMargin()
				{
					return( m_nTopMargin );
				}

				public int GetBottomMargin()
				{
					return( m_nBottomMargin );
				}
			#endregion
			#region Sets 
				public void SetFlagsList(ref System.Windows.Forms.ImageList listaImagens)
				{
					this.m_ilBandeiras = listaImagens;
				}

				public void SetMargins( int nL, int nT, int nR, int nB, bool bRepaint )
				{
					m_nLeftMargin = nL;
					m_nTopMargin = nT;
					m_nRightMargin = nR;
					m_nBottomMargin = nB;
					if ( m_bShowMargins && bRepaint )
						RepaintScreen();
				}

				public void SetProductArea( int nStart, int nEnd, bool bRepaint )
				{
					m_rectProductArea.X = m_nLeftMargin;
					m_rectProductArea.Y = nStart;
					m_rectProductArea.Width = PageSize.Width - m_nRightMargin - m_nLeftMargin;
					m_rectProductArea.Height = nEnd - nStart;
					if ( m_bShowProductArea && bRepaint )
						RepaintScreen();
				}

				public void SetDataBaseAccess( ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB)
				{
					m_cls_dba_ConnectionDB = cls_dba_ConnectionDB;
					m_bShowRestrictions = true;
					if (m_cls_dba_ConnectionDB != null)
					{
						string strCodigoCliente = m_cls_dba_ConnectionDB.GetConfiguracao("STRIDCLIENTE","");
						if (strCodigoCliente != "")
						{
							switch(strCodigoCliente.Substring(0,1))
							{
								case "1": // Pessoa Juridica
									m_bShowRestrictions = false;
									break;
								case "2": // Pessoa Fisica
									m_bShowRestrictions = true;
									break;
							}
						}
					}
				}

				public void SetTratadorDeErro( ref clsTratamentoErro te )
				{
					m_tratadorErro = te;
				}

				public void SetEnderecoExecutavel(string strEnderecoExecutavel)
				{
					m_strEnderecoExecutavel = strEnderecoExecutavel;
				}

				public void SetIdCodigo(string codigo)
				{
					m_strIdCodigo = codigo;
				}

				public void SetIdIdioma(int idioma)
				{
					m_nIdIdioma = idioma;
					m_callbackAreaDeProdutos = null;
				}
		#endregion
			#region Abrir Relatório

		public bool bAbrirRelatorio( int nIdExportador, int nIdTipo, int nIdRelatorio )
		{
			if ( m_cls_dba_ConnectionDB == null )
				return( false );

			m_nPreviousHighlight = -1;

			System.Windows.Forms.Cursor curOld = System.Windows.Forms.Cursor.Current;
			System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;

			ArrayList arlOrdemZ = null;
			int nMaiorGrupo; // valor que indica quantos grupos de objetos o relatório possui
			int nInicioAreaProd, nFimAreaProd;
			Point pt = new Point(0);
			Size size;
			
			mdlDataBaseAccess.Tabelas.XsdTbRelatorios typDatSetTbRelatorios;
			mdlDataBaseAccess.Tabelas.XsdTbRelatorios.tbRelatoriosRow dtrwRelatorio;
			System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
			if (nIdRelatorio > 0)
			{
				// Relatorio Normal
				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdExportador);
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
			}else{
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
			}
			arlCondicaoCampo.Add("nIdTipo");
			arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicaoValor.Add(nIdTipo);
			arlCondicaoCampo.Add("nIdRelatorio");
			arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicaoValor.Add(nIdRelatorio);

			typDatSetTbRelatorios = m_cls_dba_ConnectionDB.GetTbRelatorios(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

			if ( typDatSetTbRelatorios.tbRelatorios.Rows.Count == 0 )
				return( false );

			// Setando a Linha do Relatorio
			dtrwRelatorio = (mdlDataBaseAccess.Tabelas.XsdTbRelatorios.tbRelatoriosRow)typDatSetTbRelatorios.tbRelatorios[0];

			m_nIdExportador = nIdExportador;
			m_nIdTipo = nIdTipo;
			m_nIdRelatorio = nIdRelatorio;

			// limpa a "prancheta" de desenho atual
			ClearData( false );

			// carrega relatório
			m_strReportName = dtrwRelatorio.strNomeRelatorio;
			size = new Size( dtrwRelatorio.nWidth, dtrwRelatorio.nHeight);
			// Orientacao
			m_nOrientation = dtrwRelatorio.nOrientacao;

			// Colocando o Tamanho da Pagina de acordo com a Orientacao
			switch(m_nOrientation)
			{
				case (int)DrawingCanvasPackage.Orientation.Retract:
					this.m_sizePage = size;
					break;
					
				case (int)DrawingCanvasPackage.Orientation.Image:
					this.m_sizePage = new System.Drawing.Size(size.Height,size.Width);
					break;
			}
			
			m_nLeftMargin = dtrwRelatorio.nMargemEsquerda;
			m_nTopMargin = dtrwRelatorio.nMargemAcima;
			m_nRightMargin = dtrwRelatorio.nMargemDireita;
			m_nBottomMargin = dtrwRelatorio.nMargemAbaixo;

			m_rectScreen = new System.Drawing.Rectangle(0,0,Width,Height);
			m_memBmp = null;

			// Propriedades Visualizacao do Relatorio
			m_bVerGrade = dtrwRelatorio.bVerGrade;
			m_bVerMargens = dtrwRelatorio.bVerMargens;
			m_bVerAreaProdutos = dtrwRelatorio.bVerAreaProdutos;
			m_bVerLinhas = dtrwRelatorio.bVerLinhas;
			m_bVerCirculos = dtrwRelatorio.bVerCirculos;
			m_bVerRetangulos = dtrwRelatorio.bVerRetangulos;
			m_bVerImagens = dtrwRelatorio.bVerImagens;
			m_bVerEtiquetas = dtrwRelatorio.bVerEtiquetas;
			m_bVerCamposBD = dtrwRelatorio.bVerCamposBD;
			m_bVerCamposBDDados = dtrwRelatorio.bVerCamposBDDados;

			// Ajustando as Propriedades
			if (m_bViewMode)
			{
				ShowLines = true;
				ShowCircles = true;
				ShowRectangles = true;
				ShowImage = true;
				ShowText = true;
				ShowDBText = true;
				ShowDBTextDados = true;
			}
			else
			{
				this.ShowGrid =  m_bVerGrade;  
				this.ShowMargins =  m_bVerMargens; 
				this.ShowProductArea = m_bVerAreaProdutos; 
				this.ShowLines = m_bVerLinhas; 
				this.ShowCircles = m_bVerCirculos; 
				this.ShowRectangles = m_bVerRetangulos; 
				this.ShowImage = m_bVerImagens; 
				this.ShowText = m_bVerEtiquetas; 
				this.ShowDBText = m_bVerCamposBD; 
				this.ShowDBTextDados = m_bVerCamposBDDados;
			}

			// Propriedades Cores do Relatorio
				
			if (!dtrwRelatorio.IsnlCorCampoBDNull())
				this.DBTextColor = System.Drawing.Color.FromArgb(dtrwRelatorio.nlCorCampoBD);

			if (!dtrwRelatorio.IsnlCorObjetosFocadosNull())
				this.HighlightColor = System.Drawing.Color.FromArgb(dtrwRelatorio.nlCorObjetosFocados);
			if (!dtrwRelatorio.IsnlCorObjetosNaoImpressosNull())
				this.NotPrintableColor = System.Drawing.Color.FromArgb(dtrwRelatorio.nlCorObjetosNaoImpressos);
			if (!dtrwRelatorio.IsnlCorAreaProdutosNull())
				this.ProductAreaColor = System.Drawing.Color.FromArgb(dtrwRelatorio.nlCorAreaProdutos);
			if (!dtrwRelatorio.IsnlCorMargemNull())
				this.MarginColor = System.Drawing.Color.FromArgb(dtrwRelatorio.nlCorMargem);
			if (!dtrwRelatorio.IsnlCorFundoNull())
				this.BackgroundColor = System.Drawing.Color.FromArgb(dtrwRelatorio.nlCorFundo);

			nInicioAreaProd = dtrwRelatorio.nAreaProdutosInicio;
			nFimAreaProd = dtrwRelatorio.nAreaProdutosFinal;
			SetProductArea( nInicioAreaProd, nFimAreaProd, false );

			nMaiorGrupo = -1;

			if ( m_bViewMode )
			{
				if ( (m_callbackAreaDeProdutos == null) )
				{
					m_callbackAreaDeProdutos = new clsRelatoriosCallBackAreaProdutos( ref m_tratadorErro, ref m_cls_dba_ConnectionDB, m_strEnderecoExecutavel);
					m_callbackAreaDeProdutos.Bandeiras = m_ilBandeiras;
				}
				m_callbackAreaDeProdutos.Idioma = m_nIdIdioma;

				if ( m_arlProdutos != null  )
					m_arlProdutos.Clear();

				if ( m_arlColunasProdutos != null )
					m_arlColunasProdutos.Clear();
				else
					m_arlColunasProdutos = new ArrayList();
				m_arlProdutos =  GetDadosAreaProdutos( nIdExportador, m_strIdCodigo, nIdTipo );
			}

			arlOrdemZ = new ArrayList();
			if (nIdRelatorio > 0)
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
			else
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
			CarregarLinhas( nIdExportador, nIdTipo, nIdRelatorio, ref nMaiorGrupo, ref arlOrdemZ );
			CarregarRetangulos( nIdExportador, nIdTipo, nIdRelatorio, ref nMaiorGrupo, ref arlOrdemZ );
			CarregarCirculos( nIdExportador, nIdTipo, nIdRelatorio, ref nMaiorGrupo, ref arlOrdemZ );
			CarregarTextos( nIdExportador, nIdTipo, nIdRelatorio, ref nMaiorGrupo, ref arlOrdemZ );
			CarregarImagens( nIdExportador, nIdTipo, nIdRelatorio, ref nMaiorGrupo, ref arlOrdemZ );
			CarregarTextosBD( nIdExportador, nIdTipo, nIdRelatorio, ref nMaiorGrupo, ref arlOrdemZ );
			CriaGruposDeObjetos( nMaiorGrupo );

			if (m_bViewMode)
				m_arlProdutos =  GetDadosAreaProdutos( nIdExportador, m_strIdCodigo, nIdTipo );

			m_nCurrPage = 0;
			m_nTotalPages = 1;
			if ( m_arlUltimoProdutoInserido == null )
				m_arlUltimoProdutoInserido = new ArrayList();
			else
				m_arlUltimoProdutoInserido.Clear();
			m_arlUltimoProdutoInserido.Add( 0 ); // ultimo produto inserido inicialmente foi o zero, ou seja, nenhum

			Graphics memDC = GetMemoryDC();
			if ( !m_bViewMode )
				m_nTotalPages = 1;
			else
				m_nTotalPages = nCalculaNumeroDePaginas( ref memDC );

			refreshFieldPageNumber();

			RepaintScreen();
			//GC
			GC.Collect();
			GC.WaitForPendingFinalizers();
			
			System.Windows.Forms.Cursor.Current = curOld;

			// Setando o relatorio como nao modificado
			m_bModificado = false;
			return( true );
		}

		protected void CriaGruposDeObjetos( int nMaiorGrupo )
		{
			GraphicObject obj;
			int nGrupoAtual;
			ArrayList arlGrupo, arlTodosGrupos = GetGroupList();

			for ( int i = 0; i <= nMaiorGrupo; i++ )
			{
				arlGrupo = new ArrayList();
				arlTodosGrupos.Add( arlGrupo );
			}

			for ( int i = 0; i < m_colGraphObj.Count; i++ )
			{
				obj = (GraphicObject)m_colGraphObj[ i ];
				nGrupoAtual = obj.nGroup;
				if ( nGrupoAtual > -1 )
					((ArrayList)arlTodosGrupos[ nGrupoAtual ]).Add( obj.nIndex );
			}
		}

		protected void CarregarLinhas( int nIdExportador, int nIdTipo, int nIdRelatorio, ref int nMaiorGrupo, ref ArrayList arlOrdemZ )
		{
			GraphicObject obj;
			Point pt;
			int cont;
			String strZ;

			mdlDataBaseAccess.Tabelas.XsdTbRelatorioLinhas typDatSetTbRelatorioLinhas;
			mdlDataBaseAccess.Tabelas.XsdTbRelatorioLinhas.tbRelatorioLinhasRow dtrwLinha;
			System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
			if (nIdRelatorio > 0)
			{
				// Relatorio Normal
				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdExportador);
			}
			arlCondicaoCampo.Add("nIdTipo");
			arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicaoValor.Add(nIdTipo);
			arlCondicaoCampo.Add("nIdRelatorio");
			arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicaoValor.Add(nIdRelatorio);

			typDatSetTbRelatorioLinhas = m_cls_dba_ConnectionDB.GetTbRelatorioLinhas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

			pt = new Point( 0 );
			cont = 0;
			LineObject objLine = new LineObject();
			for (int nCont = 0; nCont < typDatSetTbRelatorioLinhas.tbRelatorioLinhas.Rows.Count;nCont++)
			{
				dtrwLinha = (mdlDataBaseAccess.Tabelas.XsdTbRelatorioLinhas.tbRelatorioLinhasRow)typDatSetTbRelatorioLinhas.tbRelatorioLinhas[nCont];
				objLine.bVisibleForPrinting = dtrwLinha.bVisivelImpressao;
				objLine.strName = "LineObject#" + cont++;
				pt.X = dtrwLinha.nX1;
				pt.Y = dtrwLinha.nY1;
				pt.Offset( m_nLeftMargin, m_nTopMargin );
				objLine.ptSource = pt;

				pt.X = dtrwLinha.nX2;
				pt.Y = dtrwLinha.nY2;
				pt.Offset( m_nLeftMargin, m_nTopMargin );
				objLine.ptDestiny = pt;

				objLine.nPenWidth = (int)dtrwLinha.nEspessura;
				objLine.clrPen = Color.FromArgb(dtrwLinha.nCorRGB);
				objLine.nGroup = dtrwLinha.nGrupo;

				objLine.nPenStyle = (DashStyle)dtrwLinha.nEstilo_caneta;
				objLine.nLineStyle = (LineStyle)dtrwLinha.nEstilo_linha;

				nMaiorGrupo = (objLine.nGroup > nMaiorGrupo) ? objLine.nGroup : nMaiorGrupo;

				obj = (GraphicObject)objLine.Clone();
				bAddObject( ref obj, false, false );

				// monta string de ordenamento Z e adiciona a lista de ordenamento
				strZ = obj.nIndex.ToString() + "#" + dtrwLinha.nIdLinha;
				arlOrdemZ.Add( strZ );				
			}
		}

		protected void CarregarRetangulos( int nIdExportador, int nIdTipo, int nIdRelatorio, ref int nMaiorGrupo, ref ArrayList arlOrdemZ )
		{
			GraphicObject obj;
			Point pt;
			int cont;
			String strZ; 

			mdlDataBaseAccess.Tabelas.XsdTbRelatorioRetangulos typDatSetTbRelatorioRetangulos;
			mdlDataBaseAccess.Tabelas.XsdTbRelatorioRetangulos.tbRelatorioRetangulosRow dtrwRetangulo;
			System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
			if (nIdRelatorio > 0)
			{
				// Relatorio Normal
				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdExportador);
			}
			arlCondicaoCampo.Add("nIdTipo");
			arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicaoValor.Add(nIdTipo);
			arlCondicaoCampo.Add("nIdRelatorio");
			arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicaoValor.Add(nIdRelatorio);

			typDatSetTbRelatorioRetangulos = m_cls_dba_ConnectionDB.GetTbRelatorioRetangulos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

			pt = new Point( 0 );
			cont = 0;
			RectangleObject objRect = new RectangleObject();

			for (int nCont = 0; nCont < typDatSetTbRelatorioRetangulos.tbRelatorioRetangulos.Rows.Count;nCont++)
			{
				dtrwRetangulo = (mdlDataBaseAccess.Tabelas.XsdTbRelatorioRetangulos.tbRelatorioRetangulosRow)typDatSetTbRelatorioRetangulos.tbRelatorioRetangulos.Rows[nCont];

				objRect.bVisibleForPrinting = dtrwRetangulo.bVisivelImpressao;
				objRect.strName = "RectangleObject#" + cont++;
				pt.X = dtrwRetangulo.nX1;
				pt.Y = dtrwRetangulo.nY1;
				pt.Offset( m_nLeftMargin, m_nTopMargin );
				objRect.ptSource = pt;

				pt.X = dtrwRetangulo.nX2;
				pt.Y = dtrwRetangulo.nY2;
				pt.Offset( m_nLeftMargin, m_nTopMargin );
				objRect.ptDestiny = pt;

				objRect.nPenWidth = (int)dtrwRetangulo.nEspessura;

				objRect.clrPen = Color.FromArgb( dtrwRetangulo.nCorRGB_linha);
				objRect.clrBack = Color.FromArgb( dtrwRetangulo.nCorRGB_fundo);

				objRect.nGroup = dtrwRetangulo.nGrupo;
				objRect.nPenStyle = (DashStyle)dtrwRetangulo.nEstilo_caneta; 
				objRect.bOpaque = dtrwRetangulo.bOpaco;

				nMaiorGrupo = (objRect.nGroup > nMaiorGrupo) ? objRect.nGroup : nMaiorGrupo;

				obj = (GraphicObject)objRect.Clone();
				bAddObject( ref obj, false, false );

				// monta string de ordenamento Z e adiciona a lista de ordenamento
				strZ = obj.nIndex.ToString() + "#" + dtrwRetangulo.nIdRetangulo;
				arlOrdemZ.Add( strZ );				

			}
		}

		protected void CarregarTextos( int nIdExportador, int nIdTipo, int nIdRelatorio, ref int nMaiorGrupo, ref ArrayList arlOrdemZ )
		{
			GraphicObject obj;
			Point pt;
			int cont; 
			int nFontSize;
			String strFontFamily, strZ;
			bool bFontBold, bFontItalic, bFontStrikeout, bFontSublinhado;

			mdlDataBaseAccess.Tabelas.XsdTbRelatorioEtiquetas typDatSetTbRelatorioEtiquetas;
			mdlDataBaseAccess.Tabelas.XsdTbRelatorioEtiquetas.tbRelatorioEtiquetasRow dtrwEtiqueta;
			System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
			if (nIdRelatorio > 0)
			{
				// Relatorio Normal
				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdExportador);
			}
			arlCondicaoCampo.Add("nIdTipo");
			arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicaoValor.Add(nIdTipo);
			arlCondicaoCampo.Add("nIdRelatorio");
			arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicaoValor.Add(nIdRelatorio);

			typDatSetTbRelatorioEtiquetas = m_cls_dba_ConnectionDB.GetTbRelatorioEtiquetas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

			pt = new Point( 0 );
			cont = 0;
			TextObject objText = new TextObject();
			for (int nCont = 0; nCont < typDatSetTbRelatorioEtiquetas.tbRelatorioEtiquetas.Rows.Count;nCont++)
			{
				dtrwEtiqueta = (mdlDataBaseAccess.Tabelas.XsdTbRelatorioEtiquetas.tbRelatorioEtiquetasRow)typDatSetTbRelatorioEtiquetas.tbRelatorioEtiquetas.Rows[nCont];

				objText.bVisibleForPrinting =  dtrwEtiqueta.bVisivelImpressao;
				objText.strName = "TextObject#" + cont++;
				pt.X = dtrwEtiqueta.nX1;
				pt.Y = dtrwEtiqueta.nY1;
				pt.Offset( m_nLeftMargin, m_nTopMargin );
				objText.ptSource = pt;

				objText.clrText = Color.FromArgb( dtrwEtiqueta.nCorRGB);

				objText.strText = dtrwEtiqueta.mstrTexto;
				strFontFamily = dtrwEtiqueta.strFonteFamilia;
				nFontSize = dtrwEtiqueta.nFonteSize;
				bFontBold = dtrwEtiqueta.bFonteNegrito;
				bFontItalic = dtrwEtiqueta.bFonteItalico;
				bFontStrikeout = dtrwEtiqueta.bFonteStrikeOut;
				bFontSublinhado = dtrwEtiqueta.bFonteSublinhada;

				FontStyle fs = new FontStyle();
				if ( bFontBold )
					fs = fs | FontStyle.Bold;
				if ( bFontItalic )
					fs = fs | FontStyle.Italic;

				if ( bFontStrikeout )
					fs = fs | FontStyle.Strikeout;

				if ( bFontSublinhado )
					fs = fs | FontStyle.Underline;
				objText.fntText = new Font( strFontFamily, (float)nFontSize, fs );

				CheckOffScreenBitmap();
				Graphics memDC = GetMemoryDC();
				Size sz = sizeText(ref objText );
				pt.X = objText.ptSource.X + sz.Width;
				pt.Y = objText.ptSource.Y + sz.Height;
				objText.ptDestiny = pt;

				objText.rect = BuildRect(ref objText.ptSource, ref objText.ptDestiny);

				objText.nGroup = dtrwEtiqueta.nGrupo;
				nMaiorGrupo = (objText.nGroup > nMaiorGrupo) ? objText.nGroup : nMaiorGrupo;

				TextObject clonado = (TextObject)objText.Clone();
				obj = (GraphicObject)clonado;
				bAddObject( ref obj, false, false );

				// monta string de ordenamento Z e adiciona a lista de ordenamento
				strZ = obj.nIndex.ToString() + "#" + dtrwEtiqueta.nIdEtiqueta;
				arlOrdemZ.Add( strZ );				

			}
		}

		protected void CarregarTextosBD( int nIdExportador, int nIdTipo, int nIdRelatorio, ref int nMaiorGrupo, ref ArrayList arlOrdemZ )
		{
			GraphicObject obj;
			Point pt;
			int cont, nKeyIndex;
			int nFontSize;
			String strFontFamily, strZ, strIdDBField;
			bool bFontBold, bFontItalic, bFontStrikeout, bFontSublinhado;
			
			if ( m_slsIDField == null )
				m_slsIDField = new SortedList();
			else
				m_slsIDField.Clear();

			if ( (m_callback == null) && m_bViewMode )
			{
				m_callback = new clsRelatoriosCallBack( ref m_tratadorErro, ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel, nIdExportador, m_strIdCodigo );
			}
			if (m_callback != null)
			{
				m_callback.Idioma = m_nIdIdioma; // Setando o idioma do carregador de dados
				m_callback.Pagina = m_nCurrPage;  
				m_callback.ListaBandeiras = m_ilBandeiras;
				m_callback.TipoRelatorio = m_nIdTipo;
			}

			// tbRelatorioCamposBD
			mdlDataBaseAccess.Tabelas.XsdTbRelatorioCamposBD typDatSetTbRelatorioCamposBD;
			mdlDataBaseAccess.Tabelas.XsdTbRelatorioCamposBD.tbRelatorioCamposBDRow dtrwCamposBD;
			System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
			if (nIdRelatorio > 0)
			{
				// Relatorio Normal
				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdExportador);
			}
			arlCondicaoCampo.Add("nIdTipo");
			arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicaoValor.Add(nIdTipo);
			arlCondicaoCampo.Add("nIdRelatorio");
			arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicaoValor.Add(nIdRelatorio);
			typDatSetTbRelatorioCamposBD = m_cls_dba_ConnectionDB.GetTbRelatorioCamposBD(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

			m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
			// tbRelatoriosTodosCamposBD
			mdlDataBaseAccess.Tabelas.XsdTbRelatoriosTodosCamposBD typDatSetTbRelatoriosTodosCamposBD;
			mdlDataBaseAccess.Tabelas.XsdTbRelatoriosTodosCamposBD.tbRelatoriosTodosCamposBDRow dtrwTodosCamposBD;
			typDatSetTbRelatoriosTodosCamposBD = m_cls_dba_ConnectionDB.GetTbRelatoriosTodosCamposBD(null,null,null,null,null);

			// tbRelatoriosCamposBDRelatorios
			mdlDataBaseAccess.Tabelas.XsdTbRelatoriosCamposBDRelatorios typDatSetTbRelatoriosCamposBDRelatorios;
			mdlDataBaseAccess.Tabelas.XsdTbRelatoriosCamposBDRelatorios.tbRelatoriosCamposBDRelatoriosRow dtrwCamposBDRelatorio;
			typDatSetTbRelatoriosCamposBDRelatorios = m_cls_dba_ConnectionDB.GetTbRelatoriosCamposBDRelatorios(null,null,null,null,null);
			if (m_callback == null)
				m_callback = new clsRelatoriosCallBack(ref m_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdCodigo);
			m_callback.InsertTextosDinamicos(m_nIdTipo,ref typDatSetTbRelatoriosCamposBDRelatorios);
			if (m_callbackAreaDeProdutos == null)
				m_callbackAreaDeProdutos = new clsRelatoriosCallBackAreaProdutos(ref m_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel);
			m_callbackAreaDeProdutos.InsertCamposBDDinamicos(m_nIdExportador,m_nIdTipo,ref typDatSetTbRelatoriosCamposBDRelatorios);

			m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;

			cont = 0;
			pt = new Point( 0 );
			DBTextObject objDBText = new DBTextObject();

			m_cls_dba_ConnectionDB.DataPersist = false;
			for (int nCont = 0; nCont < typDatSetTbRelatorioCamposBD.tbRelatorioCamposBD.Rows.Count;nCont++)
			{
				dtrwCamposBD = (mdlDataBaseAccess.Tabelas.XsdTbRelatorioCamposBD.tbRelatorioCamposBDRow)typDatSetTbRelatorioCamposBD.tbRelatorioCamposBD.Rows[nCont];
				dtrwTodosCamposBD = typDatSetTbRelatoriosTodosCamposBD.tbRelatoriosTodosCamposBD.FindBynIdCampoBD(dtrwCamposBD.nIdCampoBD);
				dtrwCamposBDRelatorio  = typDatSetTbRelatoriosCamposBDRelatorios.tbRelatoriosCamposBDRelatorios.FindBynIdTipoRelatorionIdCampoBD(m_nIdTipo,dtrwCamposBD.nIdCampoBD);

				if ((dtrwCamposBDRelatorio != null) && (dtrwCamposBDRelatorio.nIdCampoBD.ToString().EndsWith("98")) && (dtrwTodosCamposBD == null))
				{
					//EtiquetasDinamicas
					dtrwTodosCamposBD = typDatSetTbRelatoriosTodosCamposBD.tbRelatoriosTodosCamposBD.NewtbRelatoriosTodosCamposBDRow();
					dtrwTodosCamposBD.nIdCampoBD = dtrwCamposBDRelatorio.nIdCampoBD;
					dtrwTodosCamposBD.strNomeCampoBD = dtrwCamposBDRelatorio.strNomeCampoNoRelatorio;
					dtrwTodosCamposBD.bPertenceAreaProdutos = false;
					dtrwTodosCamposBD.bAlinhamentoInferiorAreaProdutos = false;
					dtrwTodosCamposBD.bImprimirSomenteUltimaPagina = false;
					dtrwTodosCamposBD.nFormatoNumero = 0;
					dtrwTodosCamposBD.bAlinhamentoDireita = false;
				}

				if ((dtrwCamposBDRelatorio != null) && (dtrwCamposBDRelatorio.nIdCampoBD.ToString().EndsWith("97")) && (dtrwTodosCamposBD == null))
				{
					//Propriedades dos Produtos Area de Produtos
					dtrwTodosCamposBD = typDatSetTbRelatoriosTodosCamposBD.tbRelatoriosTodosCamposBD.NewtbRelatoriosTodosCamposBDRow();
					dtrwTodosCamposBD.nIdCampoBD = dtrwCamposBDRelatorio.nIdCampoBD;
					dtrwTodosCamposBD.strNomeCampoBD = dtrwCamposBDRelatorio.strNomeCampoNoRelatorio;
					dtrwTodosCamposBD.bPertenceAreaProdutos = true;
					dtrwTodosCamposBD.bAlinhamentoInferiorAreaProdutos = false;
					dtrwTodosCamposBD.bImprimirSomenteUltimaPagina = false;
					dtrwTodosCamposBD.nFormatoNumero = 0;
					dtrwTodosCamposBD.bAlinhamentoDireita = false;
				}

				if ((dtrwTodosCamposBD == null) || (dtrwCamposBDRelatorio == null))
					continue;

				objDBText.bBelongsProdutctArea = dtrwTodosCamposBD.bPertenceAreaProdutos;
				objDBText.bCallback = dtrwCamposBDRelatorio.bCallbackClicavel;
				objDBText.bCallback = objDBText.bCallback && !objDBText.bBelongsProdutctArea;
				objDBText.nIdDBField = dtrwCamposBD.nIdCampoBD;
				objDBText.bResizeable = true;
				objDBText.bPrintOnlyLastPage = dtrwTodosCamposBD.bImprimirSomenteUltimaPagina;
				switch (dtrwCamposBDRelatorio.nAlinhamento)
				{
					case 0:
						objDBText.alignment = Alignment.Left;
						break;
					case 1:
						objDBText.alignment = Alignment.Center;
						break;
					case 2:
						objDBText.alignment = Alignment.Right;
						break;
				}
				objDBText.bVisibleForPrinting = dtrwCamposBD.bVisivelImpressao;
				objDBText.strName = "DBTextObject#" + cont++;
				pt.X = dtrwCamposBD.nX1;
				pt.Y = dtrwCamposBD.nY1;
				pt.Offset( m_nLeftMargin, m_nTopMargin );
				objDBText.ptSource = pt;

				objDBText.clrText = Color.FromArgb(dtrwCamposBD.nCorRGB);

				strIdDBField = objDBText.nIdDBField.ToString();
				if ( (strIdDBField.Length >= 2) && (strIdDBField.EndsWith("00")) )
					objDBText.clrBack = m_clrBackDBTextOnlyText;
				else
					objDBText.clrBack = m_clrBackDBText;

				if ( m_bViewMode && !objDBText.bBelongsProdutctArea )
					objDBText.strText = m_callback.strCarregaDados( objDBText.nIdDBField );
				else
					objDBText.strText = dtrwCamposBDRelatorio.strNomeCampoNoRelatorio;

				strFontFamily = dtrwCamposBD.strFonteFamilia;
				nFontSize = dtrwCamposBD.nFonteSize;
				bFontBold = dtrwCamposBD.bFonteNegrito;
				bFontItalic = dtrwCamposBD.bFonteItalico;
				bFontStrikeout = dtrwCamposBD.bFonteStrikeOut;
				bFontSublinhado = dtrwCamposBD.bFonteSublinhada;

				FontStyle fs = new FontStyle();
				if ( bFontBold )
					fs = fs | FontStyle.Bold;
				if ( bFontItalic )
					fs = fs | FontStyle.Italic;

				if ( bFontStrikeout )
					fs = fs | FontStyle.Strikeout;

				if ( bFontSublinhado )
					fs = fs | FontStyle.Underline;
				objDBText.fntText = new Font( strFontFamily, (float)nFontSize, fs );
				CheckOffScreenBitmap();
				Graphics memDC = GetMemoryDC();
				objDBText.size = sizeText(ref objDBText.strText, ref objDBText.fntText );
				pt.X = dtrwCamposBD.nX2;
				pt.Y = dtrwCamposBD.nY2;
				pt.Offset( m_nLeftMargin, m_nTopMargin );
				objDBText.ptDestiny = pt;

				objDBText.nGroup = dtrwCamposBD.nGrupo;

				nMaiorGrupo = (objDBText.nGroup > nMaiorGrupo) ? objDBText.nGroup : nMaiorGrupo;

				DBTextObject clonado = (DBTextObject)objDBText.Clone();

				// se objeto é da área de produtos, então deve-se carregar a lista de produtos para o objeto
				if ( m_bViewMode && objDBText.bBelongsProdutctArea && (m_arlProdutos != null) )
				{
					m_bHasProductArea = true;
					m_arlColunasProdutos.Add( clonado ); // coluna da área de produtos que deve ser impressa;
					//CarregaProdutosParaObjeto( ref objDBText );
				}

				obj = (GraphicObject)clonado;
				bAddObject( ref obj, false, false );

				// adiciona um item na lista de idCampoBD
				if ( (nKeyIndex = m_slsIDField.IndexOfKey(objDBText.nIdDBField)) == -1 )
				{
					// cria uma lista de índice de objetos que usam este campo do bd
					ArrayList arlNewObjIndex = new ArrayList( 4 );
					arlNewObjIndex.Add( obj.nIndex );
					m_slsIDField.Add( objDBText.nIdDBField, arlNewObjIndex );
				}
				else
				{
					// já foram inseridos objetos que usam este campo de bd, portanto deve-se adicionar a lista
					IList ilObjIndex = m_slsIDField.GetValueList();
					ArrayList arl = (ArrayList)ilObjIndex[ nKeyIndex ];
					arl.Add( obj.nIndex );
				}

				// monta string de ordenamento Z e adiciona a lista de ordenamento
				strZ = obj.nIndex.ToString() + "#" + dtrwCamposBD.nZIndex;
				arlOrdemZ.Add( strZ );				

			}
			m_cls_dba_ConnectionDB.DataPersist = false;
		}

		protected void CarregarCirculos( int nIdExportador, int nIdTipo, int nIdRelatorio, ref int nMaiorGrupo, ref ArrayList arlOrdemZ )
		{
			GraphicObject obj;
			Point pt;
			int cont;
			String strZ;

			mdlDataBaseAccess.Tabelas.XsdTbRelatorioCirculos typDatSetTbRelatorioCirculos;
			mdlDataBaseAccess.Tabelas.XsdTbRelatorioCirculos.tbRelatorioCirculosRow dtrwCirculo;
			System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
			if (nIdRelatorio > 0)
			{
				// Relatorio Normal
				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdExportador);
			}
			arlCondicaoCampo.Add("nIdTipo");
			arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicaoValor.Add(nIdTipo);
			arlCondicaoCampo.Add("nIdRelatorio");
			arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicaoValor.Add(nIdRelatorio);

			typDatSetTbRelatorioCirculos = m_cls_dba_ConnectionDB.GetTbRelatorioCirculos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

			pt = new Point( 0 );
			cont = 0;
			CircleObject objCirc = new CircleObject();
			for (int nCont = 0; nCont < typDatSetTbRelatorioCirculos.tbRelatorioCirculos.Rows.Count;nCont++)
			{
				dtrwCirculo = (mdlDataBaseAccess.Tabelas.XsdTbRelatorioCirculos.tbRelatorioCirculosRow)typDatSetTbRelatorioCirculos.tbRelatorioCirculos.Rows[nCont];

				objCirc.bVisibleForPrinting = dtrwCirculo.bVisivelImpressao;
				objCirc.strName = "CircleObject#" + cont++;
				pt.X = dtrwCirculo.nX1;
				pt.Y = dtrwCirculo.nY1;
				pt.Offset( m_nLeftMargin, m_nTopMargin );
				objCirc.ptSource = pt;

				pt.X = dtrwCirculo.nX2;
				pt.Y = dtrwCirculo.nY2;
				pt.Offset( m_nLeftMargin, m_nTopMargin );
				objCirc.ptDestiny = pt;

				objCirc.nPenWidth = (int)dtrwCirculo.nEspessura;
				objCirc.clrPen = Color.FromArgb( dtrwCirculo.nCorRGB);
				objCirc.clrBack = Color.FromArgb( dtrwCirculo.nCorRGB);
				objCirc.bOpaque = false;
				objCirc.nPenStyle = (DashStyle)(dtrwCirculo.nEstilo_caneta);
				objCirc.nGroup = dtrwCirculo.nGrupo;
				
				nMaiorGrupo = (objCirc.nGroup > nMaiorGrupo) ? objCirc.nGroup : nMaiorGrupo;

				obj = (GraphicObject)objCirc.Clone();
				bAddObject( ref obj, false, false );

				// monta string de ordenamento Z e adiciona a lista de ordenamento
				strZ = obj.nIndex.ToString() + "#" + dtrwCirculo.nIdCirculo;
				arlOrdemZ.Add( strZ );				

			}
		}

		private void vLoadSystemImages()
		{
			// Clear the Sorted List 
			m_sortLstImages.Clear();

			mdlDataBaseAccess.Tabelas.XsdTbImagens typDatSetTbImagens;
			mdlDataBaseAccess.Tabelas.XsdTbImagens.tbImagensRow dtrwImagemBD;
			System.Drawing.Image imgSystem = null;  
			System.Byte[] byDados;
			string strImagemDados;
			typDatSetTbImagens = m_cls_dba_ConnectionDB.GetTbImagens(null,null,null,null,null);
			for (int nCont = 0;nCont < typDatSetTbImagens.tbImagens.Rows.Count;nCont++)
			{
				dtrwImagemBD = (mdlDataBaseAccess.Tabelas.XsdTbImagens.tbImagensRow)typDatSetTbImagens.tbImagens.Rows[nCont];
				strImagemDados = dtrwImagemBD.mstrDados;
				byDados = System.Convert.FromBase64CharArray(strImagemDados.ToCharArray(), 0, strImagemDados.Length);
				System.IO.Stream strDados = new System.IO.MemoryStream(byDados);
				imgSystem = System.Drawing.Image.FromStream(strDados);
				m_sortLstImages.Add(((Int32)dtrwImagemBD.nIdImagem),imgSystem);
			}
		}

		protected void CarregarImagens( int nIdExportador, int nIdTipo, int nIdRelatorio, ref int nMaiorGrupo, ref ArrayList arlOrdemZ )
		{
			GraphicObject obj;
			Point pt;
			int cont;
			String strZ;

			mdlDataBaseAccess.Tabelas.XsdTbRelatorioImagens typDatSetTbRelatorioImagens;
			mdlDataBaseAccess.Tabelas.XsdTbRelatorioImagens.tbRelatorioImagensRow dtrwImagem;
			System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

			if (nIdRelatorio > 0)
			{
				// Relatorio Normal
				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdExportador);
			}
			arlCondicaoCampo.Add("nIdTipo");
			arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicaoValor.Add(nIdTipo);
			arlCondicaoCampo.Add("nIdRelatorio");
			arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicaoValor.Add(nIdRelatorio);

			typDatSetTbRelatorioImagens = m_cls_dba_ConnectionDB.GetTbRelatorioImagens(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
			vLoadSystemImages();

			pt = new Point( 0 );
			cont = 0;
			ImageObject objImg = new ImageObject();
			for (int nCont = 0; nCont < typDatSetTbRelatorioImagens.tbRelatorioImagens.Rows.Count;nCont++)
			{
				dtrwImagem = (mdlDataBaseAccess.Tabelas.XsdTbRelatorioImagens.tbRelatorioImagensRow)typDatSetTbRelatorioImagens.tbRelatorioImagens.Rows[nCont];

				objImg.bVisibleForPrinting = dtrwImagem.bVisivelImpressao;
				objImg.strName = "ImageObject#" + cont++;
				pt.X = dtrwImagem.nX1;
				pt.Y = dtrwImagem.nY1;
				pt.Offset( m_nLeftMargin, m_nTopMargin );
				objImg.ptSource = pt;

				pt.X = dtrwImagem.nX2;
				pt.Y = dtrwImagem.nY2;
				pt.Offset( m_nLeftMargin, m_nTopMargin );
				objImg.ptDestiny = pt;

				objImg.nImageIndex = dtrwImagem.nIdimagem;
				objImg.nImageIndexInDB = dtrwImagem.nIdImagemIndex;

				objImg.nGroup = dtrwImagem.nGrupo;
				nMaiorGrupo = (objImg.nGroup > nMaiorGrupo) ? objImg.nGroup : nMaiorGrupo;

				obj = (GraphicObject)objImg.Clone();
				bAddObject( ref obj, false, false );

				// monta string de ordenamento Z e adiciona a lista de ordenamento
				strZ = obj.nIndex.ToString() + "#" + dtrwImagem.nIdimagem;
				arlOrdemZ.Add( strZ );				

			}
		}

		protected int nIndiceListaDeProdutos( int nIdCampoBD )
		{
			ArrayList arlProdObj = null; // produtos do objeto
			String strIdCampoBD; // campo do bd para a coluna

			// primeiro encontra qual ArrayList possui seus produtos
			for ( int i = 0; i < m_arlProdutos.Count; i ++ )
			{
				arlProdObj = (ArrayList)m_arlProdutos[ i ];
				strIdCampoBD = (String)arlProdObj[ 0 ]; // o primeiro item identifica o ID campo BD
				if ( Int32.Parse(strIdCampoBD) == nIdCampoBD )
					return( i ); // se ids forem iguais, a lista foi encontrada. retorna este valor
			}

			return( -1 ); // não encontrador
		}

		#endregion
			#region Salvar relatório

		public bool bSalvarRelatorio( int nIdExportador, int nIdTipo, int nIdRelatorio )
		{
			try
			{
				if ( (m_cls_dba_ConnectionDB == null) || (m_colGraphObj.Count == 0) )
					return( false );

				if (nIdRelatorio <= 0)
					nIdRelatorio = nReturnNextId(nIdExportador,nIdTipo);

				// Linpando a lista de objetos selecionados 
				m_colSelObjs.Clear();
				RepaintScreen();

				System.Windows.Forms.Cursor curOld = System.Windows.Forms.Cursor.Current;
				System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;

				bool bPossuiAreaProd;
				int nInicioAP, nFimAP, nTipoFolha = 0;

				bPossuiAreaProd = (m_rectProductArea.Height > 0);
				nInicioAP = m_rectProductArea.Y;
				nFimAP = m_rectProductArea.Height + m_rectProductArea.Y;

				// Procura pelo atual relatório na base de dados
				mdlDataBaseAccess.Tabelas.XsdTbRelatorios typDatSetTbRelatorios;
				mdlDataBaseAccess.Tabelas.XsdTbRelatorios.tbRelatoriosRow dtrwRelatorio;
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdExportador);
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;

				arlCondicaoCampo.Add("nIdTipo");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdTipo);

				arlCondicaoCampo.Add("nIdRelatorio");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdRelatorio);

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				typDatSetTbRelatorios = m_cls_dba_ConnectionDB.GetTbRelatorios(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				//if (typDatSetTbRelatorios.tbRelatorios.Rows.Count > 0)
				bDeleteReport( nIdExportador, nIdTipo, nIdRelatorio,false);

				typDatSetTbRelatorios = m_cls_dba_ConnectionDB.GetTbRelatorios(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				m_bVerGrade = this.ShowGrid;
				m_bVerMargens = this.ShowMargins;
				m_bVerAreaProdutos = this.ShowProductArea;
				m_bVerLinhas = this.ShowLines;
				m_bVerCirculos = this.ShowCircles;
				m_bVerRetangulos = this.ShowRectangles;
				m_bVerImagens = this.ShowImage;
				m_bVerEtiquetas = this.ShowText;
				m_bVerCamposBD = this.ShowDBText;
				m_bVerCamposBDDados = this.ShowDBTextDados;

				// Orientacao 
				int pageWidth = 0;
				int pageHeight = 0;
				if (m_nOrientation == 0) 
				{
					pageWidth = PageSize.Width;
					pageHeight = PageSize.Height;
				}
				else
				{
					pageWidth = PageSize.Height;
					pageHeight = PageSize.Width;
				}

				dtrwRelatorio = typDatSetTbRelatorios.tbRelatorios.NewtbRelatoriosRow();
				dtrwRelatorio.nIdExportador = nIdExportador;
				dtrwRelatorio.nIdTipo = nIdTipo;	
				dtrwRelatorio.nIdRelatorio = nIdRelatorio;
				dtrwRelatorio.strNomeRelatorio = m_strReportName;
				dtrwRelatorio.nWidth = pageWidth;
				dtrwRelatorio.nHeight = pageHeight;
				dtrwRelatorio.nOrientacao = (short)m_nOrientation;
				dtrwRelatorio.nMargemAcima = m_nTopMargin;
				dtrwRelatorio.nMargemDireita = m_nRightMargin;
				dtrwRelatorio.nMargemAbaixo = m_nBottomMargin;
				dtrwRelatorio.nMargemEsquerda = m_nLeftMargin;
				dtrwRelatorio.nTipoFolha = nTipoFolha;
				dtrwRelatorio.bPossuiAreaProdutos = bPossuiAreaProd;
				dtrwRelatorio.nAreaProdutosInicio = nInicioAP;
				dtrwRelatorio.nAreaProdutosFinal = nFimAP;
				dtrwRelatorio.bVerGrade = m_bVerGrade;
				dtrwRelatorio.bVerMargens = m_bVerMargens;
				dtrwRelatorio.bVerAreaProdutos = m_bVerAreaProdutos;
				dtrwRelatorio.bVerLinhas = m_bVerLinhas;
				dtrwRelatorio.bVerCirculos = m_bVerCirculos;
				dtrwRelatorio.bVerRetangulos = m_bVerRetangulos;
				dtrwRelatorio.bVerImagens = m_bVerImagens;
				dtrwRelatorio.bVerEtiquetas = m_bVerEtiquetas;
				dtrwRelatorio.bVerCamposBD = m_bVerCamposBD;
				dtrwRelatorio.bVerCamposBDDados = m_bVerCamposBDDados;
				dtrwRelatorio.nlCorCampoBD = this.DBTextColor.ToArgb();
				dtrwRelatorio.nlCorObjetosFocados = this.HighlightColor.ToArgb();
				dtrwRelatorio.nlCorObjetosNaoImpressos = this.NotPrintableColor.ToArgb();
				dtrwRelatorio.nlCorAreaProdutos = this.ProductAreaColor.ToArgb();
				dtrwRelatorio.nlCorMargem = this.MarginColor.ToArgb();
				dtrwRelatorio.nlCorFundo = this.BackgroundColor.ToArgb();
				typDatSetTbRelatorios.tbRelatorios.AddtbRelatoriosRow(dtrwRelatorio);

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;

				CarregaListas();
			
				m_cls_dba_ConnectionDB.AddTbRelatorioLinhas(typDatSetTbRelatorios,arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				m_cls_dba_ConnectionDB.AddTbRelatorioRetangulos(typDatSetTbRelatorios,arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				m_cls_dba_ConnectionDB.AddTbRelatorioCirculos(typDatSetTbRelatorios,arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				m_cls_dba_ConnectionDB.AddTbRelatorioEtiquetas(typDatSetTbRelatorios,arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				m_cls_dba_ConnectionDB.AddTbRelatorioImagens(typDatSetTbRelatorios,arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				m_cls_dba_ConnectionDB.AddTbRelatorioCamposBD(typDatSetTbRelatorios,arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				vSalvaLinhas(typDatSetTbRelatorios.Tables[1],nIdExportador, nIdTipo, nIdRelatorio );
				vSalvaRetangulos(typDatSetTbRelatorios.Tables[2], nIdExportador, nIdTipo, nIdRelatorio );
				vSalvaCirculos(typDatSetTbRelatorios.Tables[3], nIdExportador, nIdTipo, nIdRelatorio );
				vSalvaTextos(typDatSetTbRelatorios.Tables[4], nIdExportador, nIdTipo, nIdRelatorio );
				vSalvaImagens(typDatSetTbRelatorios.Tables[5], nIdExportador, nIdTipo, nIdRelatorio );
				vSalvaTextosBD(typDatSetTbRelatorios.Tables[6], nIdExportador, nIdTipo, nIdRelatorio );

				// Updating the DataBase
				m_cls_dba_ConnectionDB.SetDataSetMultiTable(typDatSetTbRelatorios);

				System.Windows.Forms.Cursor.Current = curOld;
				// Setando o relatorio como nao modificado
				m_bModificado = false;
				return( true );
			}catch (System.Exception eExp){
				m_tratadorErro.trataErro(ref eExp);
			}
			return(false);
		}

		public bool bSalvarRelatorioComo( int nIdExportador, int nIdTipo, bool bReportDefault, String strNomeRelatorio )
		{
			try
			{
				// Linpando a lista de objetos selecionados 
				m_colSelObjs.Clear();
				RepaintScreen();
				m_strReportName = strNomeRelatorio;
				int nIdReport = -1;
				nIdReport = nReturnNextId(nIdExportador,nIdTipo);
				m_nIdRelatorio = nIdReport;
				return (bSalvarRelatorio(nIdExportador,nIdTipo,nIdReport));
			}catch (System.Exception eExp){
                m_tratadorErro.trataErro(ref eExp);
			}
			return(false);
		}

		protected void CarregaListas()
		{
			GraphicObject obj;

			if ( m_arlCircObj == null )
				m_arlCircObj = new ArrayList();
			else
				m_arlCircObj.Clear();

			if ( m_arlRectObj == null )
				m_arlRectObj = new ArrayList();
			else
				m_arlRectObj.Clear();

			if ( m_arlImgObj == null )
				m_arlImgObj = new ArrayList();
			else
				m_arlImgObj.Clear();

			if ( m_arlTextObj == null )
				m_arlTextObj = new ArrayList();
			else
				m_arlTextObj.Clear();

			if ( m_arlDBTextObj == null )
				m_arlDBTextObj = new ArrayList();
			else
				m_arlDBTextObj.Clear();

			if ( m_arlLineObj == null )
				m_arlLineObj = new ArrayList();
			else
				m_arlLineObj.Clear();

			for ( int i = 0; i < m_colGraphObj.Count; i++ )
			{
				obj = (GraphicObject)m_colGraphObj[ i ];

				switch ( obj.nType )
				{
					case Tool.Circle:
						m_arlCircObj.Add( obj );
						break;

					case Tool.Image:
						m_arlImgObj.Add( obj );
						break;

					case Tool.Line:
						m_arlLineObj.Add( obj );
						break;

					case Tool.Rectangle:
						m_arlRectObj.Add( obj );
						break;

					case Tool.Text:
						if ( obj.nSubType == (int)SubTool.DBText )
							m_arlDBTextObj.Add ( obj );
						else
							m_arlTextObj.Add( obj );
						break;
					default:
						break;
				}
				
			}
		}

		protected void  vSalvaLinhas(System.Data.DataTable dttbTabela, int nIdExportador, int nIdTipo, int nIdRelatorio )
		{
			mdlDataBaseAccess.Tabelas.XsdTbRelatorioLinhas.tbRelatorioLinhasDataTable dttbRelatorioLinhas = (mdlDataBaseAccess.Tabelas.XsdTbRelatorioLinhas.tbRelatorioLinhasDataTable)dttbTabela;
			LineObject objLine;
			int nZIndex;

			mdlDataBaseAccess.Tabelas.XsdTbRelatorioLinhas.tbRelatorioLinhasRow dtrwLinha;

			for ( int i = 0; i < m_arlLineObj.Count; i++ )
			{
				objLine = (LineObject)m_arlLineObj[ i ];
				nZIndex = objLine.nIndex;

				dtrwLinha = dttbRelatorioLinhas.NewtbRelatorioLinhasRow();
				dtrwLinha.nIdExportador = nIdExportador;
				dtrwLinha.nIdTipo = nIdTipo;
				dtrwLinha.nIdRelatorio = nIdRelatorio;
				dtrwLinha.nIdLinha = nZIndex;
				dtrwLinha.nX1 = objLine.ptSource.X - m_nLeftMargin;
				dtrwLinha.nY1 = objLine.ptSource.Y - m_nTopMargin;
				dtrwLinha.nX2 = objLine.ptDestiny.X - m_nLeftMargin;
				dtrwLinha.nY2 = objLine.ptDestiny.Y - m_nTopMargin;
				dtrwLinha.nEspessura = objLine.nPenWidth;
				dtrwLinha.nCorRGB = objLine.clrPen.ToArgb();
				dtrwLinha.bVisivelImpressao = objLine.bVisibleForPrinting;
				dtrwLinha.nGrupo = (short)objLine.nGroup;
				dtrwLinha.nEstilo_caneta = (short)objLine.nPenStyle;
				dtrwLinha.nEstilo_linha = (short)objLine.nLineStyle;

				dttbRelatorioLinhas.AddtbRelatorioLinhasRow(dtrwLinha);
			}
		}

		protected void vSalvaRetangulos(System.Data.DataTable dttbTabela, int nIdExportador, int nIdTipo, int nIdRelatorio )
		{
			mdlDataBaseAccess.Tabelas.XsdTbRelatorioRetangulos.tbRelatorioRetangulosDataTable dttbRelatorioRetangulos = (mdlDataBaseAccess.Tabelas.XsdTbRelatorioRetangulos.tbRelatorioRetangulosDataTable)dttbTabela;

			RectangleObject objRect;
			int nZIndex;

			mdlDataBaseAccess.Tabelas.XsdTbRelatorioRetangulos.tbRelatorioRetangulosRow dtrwRetangulo;

			for ( int i = 0; i < m_arlRectObj.Count; i++ )
			{
				objRect = (RectangleObject)m_arlRectObj[ i ];
				nZIndex = objRect.nIndex;

				dtrwRetangulo = dttbRelatorioRetangulos.NewtbRelatorioRetangulosRow();
				dtrwRetangulo.nIdExportador = nIdExportador;
				dtrwRetangulo.nIdRetangulo = nZIndex;
				dtrwRetangulo.nIdRelatorio = nIdRelatorio;
				dtrwRetangulo.nIdTipo = nIdTipo;
				dtrwRetangulo.nX1 = objRect.ptSource.X - m_nLeftMargin;
				dtrwRetangulo.nY1 = objRect.ptSource.Y - m_nTopMargin;
				dtrwRetangulo.nX2 = objRect.ptDestiny.X - m_nLeftMargin;
				dtrwRetangulo.nY2 = objRect.ptDestiny.Y - m_nTopMargin;
				dtrwRetangulo.nEspessura = objRect.nPenWidth;
				dtrwRetangulo.nCorRGB_linha = objRect.clrPen.ToArgb();
				dtrwRetangulo.bVisivelImpressao = objRect.bVisibleForPrinting;
				dtrwRetangulo.nGrupo = (short)objRect.nGroup;
				dtrwRetangulo.nEstilo_caneta = (short)objRect.nPenStyle; 
				dtrwRetangulo.nCorRGB_fundo = (short)objRect.clrBack.ToArgb();
				dtrwRetangulo.bOpaco = objRect.bOpaque;

				dttbRelatorioRetangulos.AddtbRelatorioRetangulosRow(dtrwRetangulo);
			}
		}

		protected void vSalvaCirculos(System.Data.DataTable dttbTabela, int nIdExportador, int nIdTipo, int nIdRelatorio )
		{
			mdlDataBaseAccess.Tabelas.XsdTbRelatorioCirculos.tbRelatorioCirculosDataTable dttbRelatorioCirculos = (mdlDataBaseAccess.Tabelas.XsdTbRelatorioCirculos.tbRelatorioCirculosDataTable)dttbTabela;

			CircleObject ObjCirc;
			int nZIndex;

			mdlDataBaseAccess.Tabelas.XsdTbRelatorioCirculos.tbRelatorioCirculosRow dtrwCirculo;

			for ( int i = 0; i < m_arlCircObj.Count; i++ )
			{
				ObjCirc = (CircleObject)m_arlCircObj[ i ];
				nZIndex = ObjCirc.nIndex;

				dtrwCirculo = dttbRelatorioCirculos.NewtbRelatorioCirculosRow();	
				dtrwCirculo.nIdExportador = nIdExportador;
				dtrwCirculo.nIdCirculo = nZIndex;
				dtrwCirculo.nIdRelatorio = nIdRelatorio;
				dtrwCirculo.nIdTipo = nIdTipo;
				dtrwCirculo.nX1 = ObjCirc.ptSource.X - m_nLeftMargin;
				dtrwCirculo.nY1 = ObjCirc.ptSource.Y - m_nTopMargin;
				dtrwCirculo.nX2 = ObjCirc.ptDestiny.X - m_nLeftMargin;
				dtrwCirculo.nY2 = ObjCirc.ptDestiny.Y - m_nTopMargin;
				dtrwCirculo.nEspessura = ObjCirc.nPenWidth;
				dtrwCirculo.nCorRGB = ObjCirc.clrPen.ToArgb();
				dtrwCirculo.bVisivelImpressao = ObjCirc.bVisibleForPrinting;
				dtrwCirculo.nGrupo = (short)ObjCirc.nGroup;
				dtrwCirculo.nEstilo_caneta = (short)ObjCirc.nPenStyle;

				dttbRelatorioCirculos.AddtbRelatorioCirculosRow(dtrwCirculo);
			}
		}

		protected void vSalvaTextos(System.Data.DataTable dttbTabela,int nIdExportador, int nIdTipo, int nIdRelatorio )
		{
			mdlDataBaseAccess.Tabelas.XsdTbRelatorioEtiquetas.tbRelatorioEtiquetasDataTable dttbRelatorioEtiquetas = (mdlDataBaseAccess.Tabelas.XsdTbRelatorioEtiquetas.tbRelatorioEtiquetasDataTable)dttbTabela;

			TextObject objText;
			String strFontSize;
			int nZIndex;

			mdlDataBaseAccess.Tabelas.XsdTbRelatorioEtiquetas.tbRelatorioEtiquetasRow dtrwEtiqueta;

			for ( int i = 0; i < m_arlTextObj.Count; i++ )
			{
				objText = (TextObject)m_arlTextObj[ i ];
				nZIndex = objText.nIndex;
				strFontSize = objText.fntText.Size.ToString();
				strFontSize = strFontSize.Replace( ",", "." );

				dtrwEtiqueta = dttbRelatorioEtiquetas.NewtbRelatorioEtiquetasRow();
				dtrwEtiqueta.nIdExportador = nIdExportador;
				dtrwEtiqueta.nIdEtiqueta = nZIndex;
				dtrwEtiqueta.nIdRelatorio = nIdRelatorio;
				dtrwEtiqueta.nIdTipo = nIdTipo;
				dtrwEtiqueta.nX1 = objText.ptSource.X - m_nLeftMargin;
				dtrwEtiqueta.nY1 = objText.ptSource.Y - m_nTopMargin;
				dtrwEtiqueta.nCorRGB = objText.clrText.ToArgb();
				dtrwEtiqueta.mstrTexto = objText.strText;
				dtrwEtiqueta.strFonteFamilia = objText.fntText.FontFamily.Name;
				dtrwEtiqueta.nFonteSize = Int32.Parse(strFontSize);
				dtrwEtiqueta.bFonteNegrito = objText.fntText.Bold;
				dtrwEtiqueta.bFonteItalico = objText.fntText.Italic;
				dtrwEtiqueta.bFonteStrikeOut = objText.fntText.Strikeout;
				dtrwEtiqueta.bFonteSublinhada =  objText.fntText.Underline;
				dtrwEtiqueta.bVisivelImpressao = objText.bVisibleForPrinting;
				dtrwEtiqueta.nGrupo = (short)objText.nGroup;
				dttbRelatorioEtiquetas.AddtbRelatorioEtiquetasRow(dtrwEtiqueta);
			}
		}

		protected void vSalvaImagens(System.Data.DataTable dttbTabela, int nIdExportador, int nIdTipo, int nIdRelatorio )
		{
			mdlDataBaseAccess.Tabelas.XsdTbRelatorioImagens.tbRelatorioImagensDataTable dttbRelatorioImagens = (mdlDataBaseAccess.Tabelas.XsdTbRelatorioImagens.tbRelatorioImagensDataTable)dttbTabela;

			ImageObject objImg;
			int nZIndex;

			mdlDataBaseAccess.Tabelas.XsdTbRelatorioImagens.tbRelatorioImagensRow dtrwImagem;

			for ( int i = 0; i < m_arlImgObj.Count; i++ )
			{
				objImg = (ImageObject)m_arlImgObj[ i ];
				nZIndex = objImg.nIndex;

				dtrwImagem = dttbRelatorioImagens.NewtbRelatorioImagensRow();
				dtrwImagem.nIdExportador = nIdExportador;
				dtrwImagem.nIdimagem = nZIndex;
				dtrwImagem.nIdRelatorio = nIdRelatorio;
				dtrwImagem.nIdTipo = nIdTipo;
				dtrwImagem.nX1 = objImg.ptSource.X - m_nLeftMargin;
				dtrwImagem.nY1 = objImg.ptSource.Y - m_nTopMargin;
				dtrwImagem.nX2 = objImg.ptDestiny.X - m_nLeftMargin;
				dtrwImagem.nY2 = objImg.ptDestiny.Y - m_nTopMargin;
				dtrwImagem.bVisivelImpressao = objImg.bVisibleForPrinting;
				dtrwImagem.nGrupo = (short)objImg.nGroup;
				dtrwImagem.nIdImagemIndex = (short)objImg.nImageIndexInDB;
				dttbRelatorioImagens.AddtbRelatorioImagensRow(dtrwImagem);
			}
		}

		protected void vSalvaTextosBD(System.Data.DataTable dttbTabela, int nIdExportador, int nIdTipo, int nIdRelatorio )
		{
			mdlDataBaseAccess.Tabelas.XsdTbRelatorioCamposBD.tbRelatorioCamposBDDataTable dttbRelatorioCamposBD = (mdlDataBaseAccess.Tabelas.XsdTbRelatorioCamposBD.tbRelatorioCamposBDDataTable)dttbTabela;

			DBTextObject objDBText;
			String strFontSize;
			int nZIndex;

			mdlDataBaseAccess.Tabelas.XsdTbRelatorioCamposBD.tbRelatorioCamposBDRow dtrwCampoBD;

			for ( int i = 0; i < m_arlDBTextObj.Count; i++ )
			{
				objDBText = (DBTextObject)m_arlDBTextObj[ i ];
				nZIndex = objDBText.nIndex;
				strFontSize = objDBText.fntText.Size.ToString();
				strFontSize = strFontSize.Replace( ",", "." );

				dtrwCampoBD = dttbRelatorioCamposBD.NewtbRelatorioCamposBDRow();
				dtrwCampoBD.nIdExportador = nIdExportador;
				dtrwCampoBD.nIdCampoBD = objDBText.nIdDBField;
				dtrwCampoBD.nIdRelatorio = nIdRelatorio;
				dtrwCampoBD.nIdTipo = nIdTipo;
				dtrwCampoBD.nX1 = objDBText.ptSource.X - m_nLeftMargin;
				dtrwCampoBD.nY1 = objDBText.ptSource.Y - m_nTopMargin;
				dtrwCampoBD.nX2 = objDBText.ptDestiny.X - m_nLeftMargin;
				dtrwCampoBD.nY2 = objDBText.ptDestiny.Y - m_nTopMargin;
				dtrwCampoBD.nCorRGB = objDBText.clrText.ToArgb();
				dtrwCampoBD.strFonteFamilia = objDBText.fntText.FontFamily.Name;
				dtrwCampoBD.nFonteSize = int.Parse(strFontSize);
				dtrwCampoBD.bFonteNegrito = objDBText.fntText.Bold;
				dtrwCampoBD.bFonteItalico = objDBText.fntText.Italic;
				dtrwCampoBD.bFonteStrikeOut = objDBText.fntText.Strikeout;
				dtrwCampoBD.bFonteSublinhada = objDBText.fntText.Underline;
				dtrwCampoBD.bVisivelImpressao = objDBText.bVisibleForPrinting;
				dtrwCampoBD.nGrupo = (short)objDBText.nGroup;
				dtrwCampoBD.nZIndex = nZIndex;

				dttbRelatorioCamposBD.AddtbRelatorioCamposBDRow(dtrwCampoBD);

			}
		}
		#endregion
			#region Excluir relatório

		public bool bDeleteReport()
		{
			bool ret = bDeleteReport(m_nIdExportador, m_nIdTipo, m_nIdRelatorio, true );
			if ( ret )
			{
				m_nIdExportador = -1;
				m_nIdTipo = -1;
				m_nIdRelatorio = -1;
				ClearData( true );
			}
			return( ret );
		}

		public bool bDeleteReport( int nIdExportador, int nIdTipo, int nIdRelatorio, bool bRemoveProdArea )
		{
			if ( (m_cls_dba_ConnectionDB == null) )
				return( false );

			System.Windows.Forms.Cursor curOld = System.Windows.Forms.Cursor.Current;
			System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;

			System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
			if (nIdRelatorio > 0)
			{
				// Relatorio Normal
				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdExportador);
			}else{
				// Relatorio Padrao
				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(0);
				return(true);
			}
			arlCondicaoCampo.Add("nIdTipo");
			arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicaoValor.Add(nIdTipo);
			arlCondicaoCampo.Add("nIdRelatorio");
			arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicaoValor.Add(nIdRelatorio);

			// Verificando se o relatorio existe
			mdlDataBaseAccess.Tabelas.XsdTbRelatorios typDatSetTbRelatorios = m_cls_dba_ConnectionDB.GetTbRelatorios(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
			if (typDatSetTbRelatorios.tbRelatorios.Rows.Count != 0)
			{
				// Relatorio
				typDatSetTbRelatorios.tbRelatorios.Rows[0].Delete();
				m_cls_dba_ConnectionDB.SetTbRelatorios(typDatSetTbRelatorios);
			}

			// Linhas
			mdlDataBaseAccess.Tabelas.XsdTbRelatorioLinhas typDatSetTbRelatorioLinhas = m_cls_dba_ConnectionDB.GetTbRelatorioLinhas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
			for (int nCont = 0; nCont < typDatSetTbRelatorioLinhas.tbRelatorioLinhas.Rows.Count;nCont++)
				typDatSetTbRelatorioLinhas.tbRelatorioLinhas.Rows[nCont].Delete();
			m_cls_dba_ConnectionDB.SetTbRelatorioLinhas(typDatSetTbRelatorioLinhas);

			// Retangulos
			mdlDataBaseAccess.Tabelas.XsdTbRelatorioRetangulos typDatSetTbRelatorioRetangulos = m_cls_dba_ConnectionDB.GetTbRelatorioRetangulos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
			for (int nCont = 0; nCont < typDatSetTbRelatorioRetangulos.tbRelatorioRetangulos.Rows.Count;nCont++)
				typDatSetTbRelatorioRetangulos.tbRelatorioRetangulos.Rows[nCont].Delete();
			m_cls_dba_ConnectionDB.SetTbRelatorioRetangulos(typDatSetTbRelatorioRetangulos);

			// Circulos
			mdlDataBaseAccess.Tabelas.XsdTbRelatorioCirculos typDatSetTbRelatorioCirculos = m_cls_dba_ConnectionDB.GetTbRelatorioCirculos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
			for (int nCont = 0; nCont < typDatSetTbRelatorioCirculos.tbRelatorioCirculos.Rows.Count;nCont++)
				typDatSetTbRelatorioCirculos.tbRelatorioCirculos.Rows[nCont].Delete();
			m_cls_dba_ConnectionDB.SetTbRelatorioCirculos(typDatSetTbRelatorioCirculos);

			// Imagens
			mdlDataBaseAccess.Tabelas.XsdTbRelatorioImagens typDatSetTbRelatorioImagens = m_cls_dba_ConnectionDB.GetTbRelatorioImagens(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
			for (int nCont = 0; nCont < typDatSetTbRelatorioImagens.tbRelatorioImagens.Rows.Count;nCont++)
				typDatSetTbRelatorioImagens.tbRelatorioImagens.Rows[nCont].Delete();
			m_cls_dba_ConnectionDB.SetTbRelatorioImagens(typDatSetTbRelatorioImagens);

			// Etiquetas
			mdlDataBaseAccess.Tabelas.XsdTbRelatorioEtiquetas typDatSetTbRelatorioEtiquetas = m_cls_dba_ConnectionDB.GetTbRelatorioEtiquetas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
			for (int nCont = 0; nCont < typDatSetTbRelatorioEtiquetas.tbRelatorioEtiquetas.Rows.Count;nCont++)
				typDatSetTbRelatorioEtiquetas.tbRelatorioEtiquetas.Rows[nCont].Delete();
			m_cls_dba_ConnectionDB.SetTbRelatorioEtiquetas(typDatSetTbRelatorioEtiquetas);

			// CamposBD
			mdlDataBaseAccess.Tabelas.XsdTbRelatorioCamposBD typDatSetTbRelatorioCamposBD = m_cls_dba_ConnectionDB.GetTbRelatorioCamposBD(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
			for (int nCont = 0; nCont < typDatSetTbRelatorioCamposBD.tbRelatorioCamposBD.Rows.Count;nCont++)
				typDatSetTbRelatorioCamposBD.tbRelatorioCamposBD.Rows[nCont].Delete();
			m_cls_dba_ConnectionDB.SetTbRelatorioCamposBD(typDatSetTbRelatorioCamposBD);

			if ( bRemoveProdArea )
				RemoveProductArea( false );

			System.Windows.Forms.Cursor.Current = curOld;

			// Setando o relatorio como nao modificado
			m_bModificado = false;

			return( true );
		}

		#endregion
			#region Exception Handler
			protected override void vHandleException(ref System.Exception e)
			{
				m_tratadorErro.trataErro(ref e);
			}
		#endregion
		#endregion
	}
}
