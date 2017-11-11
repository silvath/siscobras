using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;


namespace DrawingCanvasPackage
{
	#region Classe Win32Support
	/// <summary>
	/// Summary description for Win32Support.
	/// Win32Support is a wrapper class that imports all the necessary
	/// functions that are used in old double-buffering technique
	/// for smooth animation.
	/// </summary>
	public class Win32Support
	{
		public enum Bool 
		{
			/// <summary>
			/// 
			/// </summary>
			False= 0,
			/// <summary>
			/// 
			/// </summary>
			True
		};

		/// <summary>
		/// Enumeration for the raster operations used in BitBlt.
		/// In C++ these are actually #define. But to use these
		/// constants with C#, a new enumeration type is defined.
		/// </summary>
		public enum TernaryRasterOperations
		{
			/// <summary>
			/// 
			/// </summary>
			SRCCOPY    	=	0x00CC0020, /* dest = source                   */
			/// <summary>
			/// 
			/// </summary>
			SRCPAINT   	=	0x00EE0086, /* dest = source OR dest           */
			SRCAND     	=	0x008800C6, /* dest = source AND dest          */
			SRCINVERT  	=	0x00660046, /* dest = source XOR dest          */
			SRCERASE   	=	0x00440328, /* dest = source AND (NOT dest )   */
			NOTSRCCOPY 	=	0x00330008, /* dest = (NOT source)             */
			NOTSRCERASE	=	0x001100A6, /* dest = (NOT src) AND (NOT dest) */
			MERGECOPY  	=	0x00C000CA, /* dest = (source AND pattern)     */
			MERGEPAINT 	=	0x00BB0226, /* dest = (NOT source) OR dest     */
			PATCOPY    	=	0x00F00021, /* dest = pattern                  */
			PATPAINT   	=	0x00FB0A09, /* dest = DPSnoo                   */
			PATINVERT  	=	0x005A0049, /* dest = pattern XOR dest         */
			DSTINVERT  	=	0x00550009, /* dest = (NOT dest)               */
			BLACKNESS  	=	0x00000042, /* dest = BLACK                    */
			WHITENESS  	=	0x00FF0062, /* dest = WHITE                    */
		};

		/* Device Parameters for GetDeviceCaps() */
		public enum DeviceParameters
		{
			DRIVERVERSION	=	0,     /* Device driver version				*/
			TECHNOLOGY		=	2,     /* Device classification				*/
			HORZSIZE		=	4,     /* Horizontal size in millimeters	*/
			VERTSIZE		=	6,     /* Vertical size in millimeters		*/
			HORZRES			=	8,     /* Horizontal width in pixels		*/
			VERTRES			=	10,    /* Vertical height in pixels			*/
			BITSPIXEL		=	12,    /* Number of bits per pixel			*/
			PLANES			=	14,    /* Number of planes					*/
			NUMBRUSHES		=	16,    /* Number of brushes the device has         */
			NUMPENS			=	18,    /* Number of pens the device has            */
			NUMMARKERS		=	20,    /* Number of markers the device has         */
			NUMFONTS		=	22,    /* Number of fonts the device has           */
			NUMCOLORS		=	24,    /* Number of colors the device supports     */
			PDEVICESIZE		=	26,    /* Size required for device descriptor      */
			CURVECAPS		=	28,    /* Curve capabilities                       */
			LINECAPS		=	30,    /* Line capabilities                        */
			POLYGONALCAPS	=	32,    /* Polygonal capabilities                   */
			TEXTCAPS		=	34,    /* Text capabilities                        */
			CLIPCAPS		=	36,    /* Clipping capabilities                    */
			RASTERCAPS		=	38,    /* Bitblt capabilities                      */
			ASPECTX			=	40,    /* Length of the X leg                      */
			ASPECTY			=	42,    /* Length of the Y leg                      */
			ASPECTXY		=	44,    /* Length of the hypotenuse                 */

			LOGPIXELSX		=	88,    /* Logical pixels/inch in X                 */
			LOGPIXELSY		=	90,    /* Logical pixels/inch in Y                 */

			SIZEPALETTE		=	104,    /* Number of entries in physical palette    */
			NUMRESERVED		=	106,    /* Number of reserved entries in palette    */
			COLORRES		=	108,    /* Actual color resolution                  */

			// Printing related DeviceCaps. These replace the appropriate Escapes

			PHYSICALWIDTH   =	110, /* Physical Width in device units           */
			PHYSICALHEIGHT  =	111, /* Physical Height in device units          */
			PHYSICALOFFSETX =	112, /* Physical Printable Area x margin         */
			PHYSICALOFFSETY =	113, /* Physical Printable Area y margin         */
			SCALINGFACTORX  =	114, /* Scaling factor x                         */
			SCALINGFACTORY  =	115, /* Scaling factor y                         */

			// Display driver specific

			VREFRESH		=	116,  /* Current vertical refresh rate of the    */
			/* display device (for displays only) in Hz*/
			DESKTOPVERTRES	=	117,  /* Horizontal width of entire desktop in   */
			/* pixels                                  */
			DESKTOPHORZRES	=	118,  /* Vertical height of entire desktop in    */
			/* pixels                                  */
			BLTALIGNMENT	=	119  /* Preferred blt alignment                 */
		};

		/* metrics for GetTextMetrics */
		public class  TEXTMETRIC 
		{ 
			public int tmHeight; 
			public int tmAscent; 
			public int tmDescent; 
			public int tmInternalLeading; 
			public int tmExternalLeading; 
			public int tmAveCharWidth; 
			public int tmMaxCharWidth; 
			public int tmWeight; 
			public int tmOverhang; 
			public int tmDigitizedAspectX; 
			public int tmDigitizedAspectY; 
			public char tmFirstChar; 
			public char tmLastChar; 
			public char tmDefaultChar; 
			public char tmBreakChar; 
			public byte tmItalic; 
			public byte tmUnderlined; 
			public byte tmStruckOut; 
			public byte tmPitchAndFamily; 
			public byte tmCharSet; 
		}; 

		/// <summary>
		/// CreateCompatibleDC
		/// </summary>
		[DllImport("gdi32.dll", ExactSpelling=true, SetLastError=true)]
		public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

		/// <summary>
		/// DeleteDC
		/// </summary>
		[DllImport("gdi32.dll", ExactSpelling=true, SetLastError=true)]
		public static extern Bool DeleteDC(IntPtr hdc);

		/// <summary>
		/// SelectObject
		/// </summary>
		[DllImport("gdi32.dll", ExactSpelling=true)]
		public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

		/// <summary>
		/// DeleteObject
		/// </summary>
		[DllImport("gdi32.dll", ExactSpelling=true, SetLastError=true)]
		public static extern Bool DeleteObject(IntPtr hObject);

		/// <summary>
		/// CreateCompatibleBitmap
		/// </summary>
		[DllImport("gdi32.dll", ExactSpelling=true, SetLastError=true)]
		public static extern IntPtr CreateCompatibleBitmap(IntPtr hObject, int width, int height);

		/// <summary>
		/// BitBlt
		/// </summary>
		[DllImport("gdi32.dll", ExactSpelling=true, SetLastError=true)]
		public static extern Bool BitBlt(IntPtr hObject, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hObjSource, int nXSrc, int nYSrc, TernaryRasterOperations dwRop);

		/// <summary>
		/// GetTextExtentPoint32
		/// </summary>
		[DllImport("gdi32.dll", ExactSpelling=false, SetLastError=true)]
		public static extern bool GetTextExtentPoint32(IntPtr hObject, ref String lpString, int cbString, ref Size lpSize);

		/// <summary>
		/// GetTextCharacterExtra
		/// </summary>
		[DllImport("gdi32.dll", ExactSpelling=true, SetLastError=true)]
		public static extern int GetTextCharacterExtra(IntPtr hObject);

		/// <summary>
		/// GetCharWidth32
		/// </summary>
		[DllImport("gdi32.dll", ExactSpelling=false, SetLastError=true)]
		public static extern bool GetCharWidth32(IntPtr hObject, uint iFirstChar, uint iLastChar, int[] lpBuffer);

		/// <summary>
		/// GetDeviceCaps
		/// </summary>
		[DllImport("gdi32.dll", ExactSpelling=true, SetLastError=true)]
		public static extern int GetDeviceCaps(IntPtr hObject, int nIndex);

		/// <summary>
		/// GetTextMetrics
		/// </summary>
		[DllImport("gdi32.DllImportAttribute", ExactSpelling=true, SetLastError=true)]
		public static extern bool GetTextMetrics(IntPtr hObject, ref TEXTMETRIC tm);
	}
	#endregion 
	#region UnDo/ReDo objects

	public enum AttributeChanged
	{
		Null,
		BackgroundColor,
		OpaqueBkg,
		LineStyle,
		PenColor,
		PenWidth,
		PenStyle,
		Font
	}

	/// <summary>
	/// The type of Undo/Redo operation
	/// </summary>
	public enum UndoOperation
	{
		Null,
		Insert,
		Remove,
		MoveResize,
        ChangeAttribute,
		Group,
		Order
	}

	/// <summary>
	/// UndoRedoObject
	/// </summary>
	public class UndoRedoObject
	{
		public UndoOperation uoType = UndoOperation.Null;

		~UndoRedoObject()
		{
		}
	}

	/// <summary>
	/// UndoMove
	/// </summary>
	public class UndoMoveResize : UndoRedoObject
	{
		public ArrayList arlObjs = new ArrayList(); // lizt of objects
		public ArrayList arlPrevPt1 = new ArrayList(); // list of previous points 1
		public ArrayList arlPrevPt2 = new ArrayList(); // list of previous points 2

		public UndoMoveResize()
		{
			uoType = UndoOperation.MoveResize;
		}
	
		~UndoMoveResize()
		{
			Clear();
		}

		public void Clear()
		{
			arlObjs.Clear();
			arlPrevPt1.Clear();
			arlPrevPt2.Clear();
		}

		public UndoMoveResize Clone()
		{
			UndoMoveResize newUMR = new UndoMoveResize();

			newUMR.arlObjs = (ArrayList)this.arlObjs.Clone();
			newUMR.arlPrevPt1 = (ArrayList)this.arlPrevPt1.Clone();
			newUMR.arlPrevPt2 = (ArrayList)this.arlPrevPt2.Clone();

			return( newUMR );
		}
	}

	public class UndoInsert : UndoRedoObject
	{
		public GraphicObject grpObj; // index of the inserted object
		public int nZIndex; // position at Z-order list

		public UndoInsert()
		{
			uoType = UndoOperation.Insert;
		}

		~UndoInsert()
		{
			Clear();
		}

		public void Clear()
		{
			grpObj = null;
			nZIndex = -1;
			GC.Collect();
		}

		public UndoInsert Clone()
		{
			UndoInsert newUIns = new UndoInsert();
			newUIns.grpObj = this.grpObj.Clone();
			newUIns.nZIndex = this.nZIndex;
			return( newUIns );
		}
	}

	public class UndoRemove : UndoRedoObject 
	{
		public ArrayList arlgrpObjs = new ArrayList();
		public ArrayList arlZIndex = new ArrayList();

		public UndoRemove()
		{
			uoType = UndoOperation.Remove;
		}

		~UndoRemove()
		{
			Clear();
		}

		public void Clear()
		{
			arlgrpObjs.Clear();
			arlZIndex.Clear();
		}

		public UndoRemove Clone()
		{
			UndoRemove newURemove = new UndoRemove();
			newURemove.arlgrpObjs = (ArrayList)this.arlgrpObjs.Clone();
			newURemove.arlZIndex = (ArrayList)this.arlZIndex.Clone();
			return ( newURemove );
		}
	}

	public class UndoOrder : UndoRedoObject
	{
		public ArrayList arlstrObjs = new ArrayList();
		public ArrayList arlOldZIndex = new ArrayList();

		public UndoOrder()
		{
			uoType = UndoOperation.Order;
		}

		~UndoOrder()
		{
			Clear();
		}

		public void Clear()
		{
			arlstrObjs.Clear();
			arlOldZIndex.Clear();
		}

		public UndoOrder Clone()
		{
			UndoOrder newUO = new UndoOrder();
			newUO.arlstrObjs = (ArrayList)this.arlstrObjs.Clone();
			newUO.arlOldZIndex = (ArrayList)this.arlOldZIndex.Clone();
			return( newUO );
		}
	}

	public class UndoAttribute : UndoRedoObject
	{
		public AttributeChanged acType = AttributeChanged.Null;
		public ArrayList arlstrObjs = new ArrayList();
		public ArrayList arlAttributes = new ArrayList();

		public UndoAttribute()
		{
			uoType = UndoOperation.ChangeAttribute;
		}

		~UndoAttribute()
		{
			Clear();
		}

		public void Clear()
		{
			arlstrObjs.Clear();
			arlAttributes.Clear();
			acType = AttributeChanged.Null;
		}

		public UndoAttribute Clone()
		{
			UndoAttribute newUA = new UndoAttribute();
			newUA.arlstrObjs = (ArrayList)this.arlstrObjs.Clone();
			newUA.arlAttributes = (ArrayList)this.arlAttributes.Clone();
			newUA.acType = this.acType;
			return( newUA );
		}
	}

	public class UndoGroup : UndoRedoObject
	{
		public ArrayList arlstrNotGroupedObjNames = new ArrayList(); // array list of not grouped objects
		public ArrayList arlstrGroupObjs = new ArrayList(); // array list of groups of objects

		public UndoGroup()
		{
			uoType = UndoOperation.Group;
		}

		~UndoGroup()
		{
			Clear();
		}

		public void Clear()
		{
			arlstrNotGroupedObjNames.Clear();
			arlstrGroupObjs.Clear();
			GC.Collect();
		}

		public UndoGroup Clone()
		{
			UndoGroup newUG = new UndoGroup();
			newUG.arlstrGroupObjs = (ArrayList)this.arlstrGroupObjs.Clone();
			newUG.arlstrNotGroupedObjNames = (ArrayList)this.arlstrNotGroupedObjNames.Clone();
			return( newUG );
		}
	}

	public class ObjectUndoStatus
	{
		public UndoMoveResize move = new UndoMoveResize();
		public UndoInsert insert = new UndoInsert();
		public UndoRemove remove = new UndoRemove();
		public UndoOrder order = new UndoOrder();
		public UndoAttribute attribute = new UndoAttribute();
		public UndoGroup group = new UndoGroup();
		
		~ObjectUndoStatus()
		{
			move = null;
			insert = null;
			remove = null;
			order = null;
			attribute = null;
			group = null;
			GC.Collect();
		}
	}

	#endregion
	#region Graphic object

	public class GraphicObject
	{
		public String strName = "";
		public int nIndex = -1; // position in array
		public Tool nType = Tool.None;
		public int nSubType = -1; // to be used in derive classes
		public Rectangle rect;
		public Point ptSource;
		public Point ptDestiny;
		public int nGroup = -1; // if the object is in a group, then value is greater than zero
		public bool bResizeable = true; // Do I need to say???
		public bool bVisibleForPrinting = true;
		public bool bVisibleOnScreen = true;
		public bool bHighlighted = false; // wheter the mouse cursor is over this object
		public int nState = 0; // this defines the color used to highlight the object

		~GraphicObject()
		{
		}

		public virtual GraphicObject Clone()
		{
			GraphicObject newObj = new GraphicObject();
			CloneGraphicObjectAttr( ref newObj );
			return( newObj );
		}

		protected void CloneGraphicObjectAttr( ref GraphicObject obj )
		{
			obj.strName = this.strName;
			obj.nIndex = this.nIndex;
			obj.nType = this.nType;
			obj.nSubType = this.nSubType;
			obj.rect = this.rect;
			obj.ptSource = new Point( this.ptSource.X, this.ptSource.Y );
			obj.ptDestiny = new Point( this.ptDestiny.X, this.ptDestiny.Y );
			obj.nGroup = this.nGroup;
			obj.bResizeable = this.bResizeable;
			obj.bVisibleForPrinting = this.bVisibleForPrinting;
			obj.bVisibleOnScreen = this.bVisibleOnScreen;
			obj.bHighlighted = this.bHighlighted;
			obj.nState = this.nState;
		}
	}

	public class TextObject : GraphicObject
	{
		public String strText;
		public Font fntText = null;
		public Color clrText;
		public Size size;
		public Alignment alignment = Alignment.Left;

		public TextObject()
		{
			this.nType = Tool.Text;
			this.bResizeable = false;
		}
		
		~TextObject()
		{
			if ( fntText != null )
				fntText.Dispose();
		}


		public override GraphicObject Clone()
		{
			TextObject newTObj = new TextObject();
			GraphicObject obj = (GraphicObject)newTObj;
			CloneGraphicObjectAttr( ref obj );
			CloneTextObjectAttr( ref newTObj );
			return( newTObj );
		}

		protected void CloneTextObjectAttr( ref TextObject objText )
		{
			objText.strText = this.strText;
			objText.clrText = this.clrText;
			if ( this.fntText != null )
				objText.fntText = new System.Drawing.Font(this.fntText.FontFamily,fntText.Size,fntText.Style,fntText.Unit);
			objText.alignment = this.alignment;
			objText.size = this.size;
			objText.rect = this.rect;
		}
	}

	public class ImageObject : GraphicObject
	{
		public int nImageIndex;
		public int nImageIndexInDB;

		public ImageObject()
		{
			this.nType = Tool.Image;
		}

		public override GraphicObject Clone()
		{
			ImageObject newIObj = new ImageObject();
			GraphicObject obj = (GraphicObject)newIObj;
			CloneGraphicObjectAttr( ref obj );
			CloneImageObjectAttr( ref newIObj );
			return( newIObj );
		}
		protected void CloneImageObjectAttr( ref ImageObject objImg )
		{
            objImg.nImageIndex = this.nImageIndex;
			objImg.nImageIndexInDB = this.nImageIndexInDB;
		}
	}

	public class LineObject : GraphicObject
	{
		public int nPenWidth;
		public DashStyle nPenStyle;
		public Color clrPen;
		public LineStyle nLineStyle;

		public LineObject()
		{
			this.nType = Tool.Line;
		}

		public override GraphicObject Clone()
		{
			LineObject newLObj = new LineObject();
			GraphicObject obj = (GraphicObject)newLObj;
			CloneGraphicObjectAttr( ref obj );
			CloneLineObjectAttr( ref newLObj );
			return( newLObj );
		}

		protected void CloneLineObjectAttr( ref LineObject objLine )
		{
			objLine.nPenWidth = this.nPenWidth;
			objLine.nPenStyle = this.nPenStyle;
			objLine.clrPen = this.clrPen;
			objLine.nLineStyle = this.nLineStyle;
		}
	}

	public class RectangleObject : GraphicObject
	{
		public int nPenWidth;
		public DashStyle nPenStyle;
		public Color clrPen;
		public Color clrBack;
		public bool bOpaque;
		public bool bIsSelection = false;

		public RectangleObject()
		{
			nType = Tool.Rectangle;
		}

		public override GraphicObject Clone()
		{
			RectangleObject newRObj = new RectangleObject();
			GraphicObject obj = (GraphicObject)newRObj;
			CloneGraphicObjectAttr( ref obj );
			CloneRectangleObjectAttr( ref newRObj );
			return( newRObj );
		}

		protected void CloneRectangleObjectAttr( ref RectangleObject objRect )
		{
			objRect.nPenWidth = this.nPenWidth;
			objRect.nPenStyle = this.nPenStyle;
			objRect.clrPen = this.clrPen;
			objRect.clrBack = this.clrBack;
			objRect.bOpaque = this.bOpaque;
			objRect.bIsSelection = this.bIsSelection;
		}
	}

	public class SelectionObject : RectangleObject
	{
		public SelectionObject()
		{
			nType = Tool.Rectangle; // a selection is a rectangle with special properties
		}
	}

	public class CircleObject : GraphicObject
	{
		public int nPenWidth;
		public DashStyle nPenStyle;
		public Color clrPen;
		public Color clrBack;
		public bool bOpaque;

		public CircleObject()
		{
			nType = Tool.Circle;
		}

		public override GraphicObject Clone()
		{
			CircleObject newCObj = new CircleObject();
			GraphicObject obj = (GraphicObject)newCObj;
			CloneGraphicObjectAttr( ref obj );
			CloneCircleObjectAttr( ref newCObj );
			return( newCObj );
		}

		protected void CloneCircleObjectAttr( ref CircleObject objCirc )
		{
			objCirc.nPenWidth = this.nPenWidth;
			objCirc.nPenStyle = this.nPenStyle;
			objCirc.clrPen = this.clrPen;
			objCirc.clrBack = this.clrBack;
			objCirc.bOpaque = this.bOpaque;
		}
	}

	#endregion
	#region Constants

	// constants used for object edges manipulation
	public enum ObjectEdges
	{
		NUM_EDGES = 9,
		NONE = -1,
		UPPER_LEFT_CORNER = 0,
		UPPER_MIDDLE = 1,
		UPPER_RIGHT_CORNER = 2,
		RIGHT_SIDE_MIDDLE = 3,
		LOWER_RIGHT_CORNER = 4,
		LOWER_MIDDLE = 5,
		LOWER_LEFT_CORNER = 6,
		LEFT_SIDE_MIDDLE = 7,
		CENTER = 8
	}
	
	public enum Tool
	{
		None = 0,
		Selection = 1,
		Line = 2,
		Rectangle = 3,
		Circle = 4,
		Text = 5,
		Image = 6
	}
	
	public enum LineStyle
	{
		Free,
		Horizontal,
		Vertical
	}
	
	public enum Alignment
	{
		Left,
		Center,
		Right
	}

	public enum Spacing
	{
		Horizontal,
		Vertical
	}

	public enum Orientation
	{
		Retract = 0,
		Image = 1
	}

	#endregion
	public class DrawingCanvas : System.Windows.Forms.PictureBox
	{
		#region Constants
			private const System.Windows.Forms.Keys CANVAS_LEFT = System.Windows.Forms.Keys.F9;
			private const System.Windows.Forms.Keys CANVAS_UP = System.Windows.Forms.Keys.F10;
			private const System.Windows.Forms.Keys CANVAS_RIGHT = System.Windows.Forms.Keys.F11;
			private const System.Windows.Forms.Keys CANVAS_DOWN = System.Windows.Forms.Keys.F12;
			private const System.Windows.Forms.Keys OBJECTS_LEFT = System.Windows.Forms.Keys.Left;
			private const System.Windows.Forms.Keys OBJECTS_UP = System.Windows.Forms.Keys.Up;
			private const System.Windows.Forms.Keys OBJECTS_RIGHT = System.Windows.Forms.Keys.Right;
			private const System.Windows.Forms.Keys OBJECTS_DOWN = System.Windows.Forms.Keys.Down;
		#endregion
		#region Attributes

		// mouse event handlers
		protected MouseEventHandler m_meDown = null;
		protected MouseEventHandler m_meUp = null;
		protected EventHandler m_meDClick = null;
		protected EventHandler m_meEnter = null;
		protected MouseEventHandler m_meMove = null;
		protected PaintEventHandler m_pePaint = null;

		protected ArrayList m_colGraphObj = new ArrayList(); // the object of the screen
		protected SortedList m_colSelObjs = new SortedList(); // selected objects
		protected ArrayList m_arlObjGroups = new ArrayList(); // list of groups of objects

		protected ObjectUndoStatus m_uosUndoStatus = new ObjectUndoStatus();
		protected Stack m_stackUndo = new Stack(); // contains the UnDo operations available
		protected Stack m_stackRedo = new Stack(); // contains the ReDo operations available
		protected const int UNDO_LIMIT = 30;

		protected Rectangle[] m_arrEdges = new Rectangle[(int)ObjectEdges.NUM_EDGES];
		protected ObjectEdges m_edgSelected = ObjectEdges.NONE; //selected edge of the current selected object(s)
		protected Color m_clrBack = Color.White; //init default back color
		protected Color m_clrPen = Color.Black; // init default pen color

		protected Point m_ptMousePos; // current mouse position
		protected Point m_ptSource; // current source point
		protected Point m_ptDestiny; // current destiny point
		protected Point m_ptReference; // reference point used when moving some object on the screen
		
		protected bool m_bResizingObject = false;
		protected bool m_bMovingObject = false;
		protected bool m_bOpaque = false;
		protected bool m_bShowGrid = false;

		protected Tool m_currTool = Tool.Selection; //current selected tool
		protected Tool m_prevTool; //immediate previous used tool
		protected int m_nPenWidth;
		protected DashStyle m_nPenStyle;

		protected Pen m_pen; // current pen
		protected Pen m_penFocus; // pen used to focus
		protected Pen m_penSelection; // pen used for selection rectangles
		protected SolidBrush m_sbrBrush;
		protected HatchBrush m_hbrBrush; // hatch brush

		protected Rectangle m_rectSelection;

		protected bool m_bObjectPrintable = true;
		protected String m_strText;
		protected Font m_fntText;
		protected Color m_clrText = Color.White;

		protected LineStyle m_nLineStyle = LineStyle.Free;

		protected System.Collections.SortedList m_sortLstImages = new System.Collections.SortedList(); //list of images in the system
		protected int m_nImageIndex; 
		protected System.Drawing.Image m_imgImageToInsert; // name of the current image object

		protected GraphicObject m_grpObject; //temporary object
		protected RectangleObject m_grpFocus = new RectangleObject(); //object used to draw the focus rect

		protected Bitmap m_memBmp = null;
		protected Graphics m_memDC;

		protected int m_nObjectIndexer = 0; // used to name the graphic objects

		protected int m_nOrientation = 0; // Orientation of the Page
		protected Size m_sizePage; // the size of the page (all possible drawing area)
		protected Rectangle m_rectScreen = new System.Drawing.Rectangle(0,0,300,300); // the screen coordinates, where it can be drawn
		protected Rectangle m_rectWindow; // visible part of the world
		protected Rectangle m_rectNormal; // 100% view of the world
		protected bool m_bUseMargin = false; // When he need use Margin    
		protected double m_dZoom = 100; // current zoom
		protected double m_dWindowScale; // scale for zoom
		protected const double ZOOM_STEP = 5.0;
		protected const double ZOOM_MAX = 500.0;
		protected const double ZOOM_MIN = 10.0;
		protected const int MOVE_STEP = 50; // the size of a screen move
		protected bool m_bWindowNotStarted = false;
		protected bool m_bSamePoint = false;

		// these attributes define the visible objects
		protected bool m_bShowRectangles = true;
		protected bool m_bShowCircles = true;
		protected bool m_bShowLines = true;
		protected bool m_bShowTexts = true;
		protected bool m_bShowImages = true;

		// Margins 
		protected int m_nLeftMargin = 0;
		protected int m_nTopMargin = 0;
		protected int m_nRightMargin = 0;
		protected int m_nBottomMargin = 0;


		// color of not printable objects
		protected System.Drawing.Color m_clrNotPrintable = System.Drawing.Color.FromArgb(150,150,150);
		protected Color[] m_clrHighlight = new Color[MAX_HIGHLIGHT_COLORS];// KnownColor.Highlight;

		protected bool m_bViewMode = false;
		protected int m_nPreviousHighlight = -1; // index of previous high lighted object

		protected const int MAX_HIGHLIGHT_COLORS = 2;

		protected const int FIRST_CHAR = 32;
		protected const int LAST_CHAR = 126;
		protected int[] m_nCharsWidth = new int[ LAST_CHAR - FIRST_CHAR + 1];
		protected Font m_fntLastUsed = null;
		protected bool m_bIsPrinting = false;
		protected bool m_bIsCreatingPDF = false;

		public bool m_bCancelActualAction = false;
		protected mdlPDF.clsPDF m_pdfReport = null;

		#endregion
		#region Delegates
		    public delegate void delCallPropertiesBoxObjectLine(object sender, EventArgs e);
			public delegate void delCallPropertiesBoxObjectCircle(object sender, EventArgs e);
			public delegate void delCallPropertiesBoxObjectRectangle(object sender, EventArgs e);
			public delegate void delCallPropertiesBoxObjectText(object sender, EventArgs e);
		    public delegate void delCallPropertiesBoxObjectImage(object sender, EventArgs e);
			public delegate void delCallToolChanged();
		#endregion
		#region Events
			public event delCallPropertiesBoxObjectLine eCallPropertiesBoxObjectLine;
			public event delCallPropertiesBoxObjectCircle eCallPropertiesBoxObjectCircle;
			public event delCallPropertiesBoxObjectRectangle eCallPropertiesBoxObjectRectangle;
			public event delCallPropertiesBoxObjectText eCallPropertiesBoxObjectText;
			public event delCallPropertiesBoxObjectImage eCallPropertiesBoxObjectImage;
			public event delCallToolChanged eCallToolChanged;
		#endregion
		#region Events Methods

			protected virtual void OnCallPropertiesBoxObjectLine(EventArgs e) 
			{
				if (eCallPropertiesBoxObjectLine != null)
					eCallPropertiesBoxObjectLine(this, e);
			}

			protected virtual void OnCallPropertiesBoxObjectCircle(EventArgs e) 
			{
				if (eCallPropertiesBoxObjectCircle != null)
					eCallPropertiesBoxObjectCircle(this, e);
			}

			protected virtual void OnCallPropertiesBoxObjectRectangle(EventArgs e) 
			{
				if (eCallPropertiesBoxObjectRectangle != null)
					eCallPropertiesBoxObjectRectangle(this, e);
			}

			protected virtual void OnCallPropertiesBoxObjectText(EventArgs e) 
			{
				if (eCallPropertiesBoxObjectText != null)
					eCallPropertiesBoxObjectText(this, e);
			}

			protected virtual void OnCallPropertiesBoxObjectImage(EventArgs e) 
			{
				if (eCallPropertiesBoxObjectImage != null)
					eCallPropertiesBoxObjectImage(this, e);
			}

			protected virtual void OnCallToolChanged()
			{
				if (eCallToolChanged != null)
					eCallToolChanged();
			}
		#endregion
		#region Properties

		public bool ObjectPrintable
		{
			get
			{
				return(m_bObjectPrintable);
			}
			set
			{
				m_bObjectPrintable = value; 
			}
		}

		public int Orientation 
		{
			get 
			{
				return(m_nOrientation);
			}
			set
			{
				m_nOrientation = value; 
			}
		}

		public Color HighlightColor
		{
			get
			{
				return( m_clrHighlight[ 0 ] );
			}

			set
			{
				bool bNeedRefresh = (value != m_clrHighlight[ 0 ]) && (bCanHighlight());
				m_clrHighlight[ 0 ] = value;
				if ( bNeedRefresh )
				{
					UpdateHighlightColors( value );
					RepaintScreen();
				}
			}
		}

		public Color NotPrintableColor
		{
			get
			{
				return( m_clrNotPrintable );
			}

			set
			{
				bool bNeedRefresh = (value != m_clrNotPrintable);
				m_clrNotPrintable = value;
				if ( bNeedRefresh && m_bWindowNotStarted )
					RepaintScreen();
			}
		}

		public bool ShowLines
		{
			get
			{
				return( m_bShowLines );
			}

			set
			{
				bool bNeedRefresh = (value != m_bShowLines);
				m_bShowLines = value;

				if ( !m_bShowLines )
				{
					if ( m_currTool == Tool.Line )
						m_currTool = Tool.None;
				}

				if ( bNeedRefresh && m_bWindowNotStarted )
				{
					ClearSelection(false);
					RepaintScreen();
				}
			}
		}

		public bool ShowRectangles
		{
			get
			{
				return( m_bShowRectangles );
			}

			set
			{
				bool bNeedRefresh = (value != m_bShowRectangles);
				m_bShowRectangles = value;

				if ( !m_bShowRectangles )
				{
					if ( m_currTool == Tool.Rectangle )
						m_currTool = Tool.None;
				}

				if ( bNeedRefresh && m_bWindowNotStarted )
				{
					ClearSelection(false);
					RepaintScreen();
				}
			}
		}

		public bool ShowCircles
		{
			get
			{
				return( m_bShowCircles );
			}

			set
			{
				bool bNeedRefresh = (value != m_bShowCircles);
				m_bShowCircles = value;

				if ( !m_bShowCircles )
				{
					if ( m_currTool == Tool.Circle )
						m_currTool = Tool.None;
				}

				if ( bNeedRefresh && m_bWindowNotStarted )
				{
					ClearSelection(false);
					RepaintScreen();
				}
			}
		}

		public bool ShowImage
		{
			get
			{
				return( m_bShowImages );
			}

			set
			{
				bool bNeedRefresh = (value != m_bShowImages);
				m_bShowImages = value;

				if ( !m_bShowImages )
				{
					if ( m_currTool == Tool.Image )
						m_currTool = Tool.None;
				}

				if ( bNeedRefresh && m_bWindowNotStarted )
				{
					ClearSelection(false);
					RepaintScreen();
				}
			}
		}

		public bool ShowText
		{
			get
			{
				return( m_bShowTexts );
			}

			set
			{
				bool bNeedRefresh = (value != m_bShowTexts);
				m_bShowTexts = value;

				if ( !m_bShowTexts )
				{
					if ( m_currTool == Tool.Text )
						m_currTool = Tool.None;
				}

				if ( bNeedRefresh && m_bWindowNotStarted )
				{
					ClearSelection(false);
					RepaintScreen();
				}
			}
		}

		//sets/gets the page size
		public Size PageSize
		{
			get
			{
				return( m_sizePage );
			}

			set
			{
				bool bNeedRefresh = false;				
				bNeedRefresh = !m_sizePage.Equals(value) && m_bWindowNotStarted;
				m_sizePage = value;
				if ( bNeedRefresh )
					RepaintScreen();
			}
		}

		//sets/gets the text color
		public Color TextColor
		{
			get
			{
				try
				{
					if ( m_colSelObjs.Count == 0)
					{
						return( m_clrText );
					}
					else
					{
						IList ilValues = m_colSelObjs.GetValueList();
						int nSel = (int)ilValues[0];
						return( ((TextObject)m_colGraphObj[nSel]).clrText );
					}
				} catch (System.InvalidCastException exc)
				{
					System.Console.WriteLine(exc.ToString());
					return( m_clrText );
				}
			}

			set
			{
				try
				{
					bool bNeedRefresh = false;

					if ( m_colSelObjs.Count == 0 )
					{
						bNeedRefresh = false;//(value != m_clrText);
						m_clrText = value;					
					}
					else
					{
						IList ilValues = m_colSelObjs.GetValueList();
						for ( int i = 0; i < m_colSelObjs.Count; i++ )
						{
							int nIndex = (int)ilValues[i];
							bNeedRefresh = (value != ((TextObject)m_colGraphObj[nIndex]).clrText) || bNeedRefresh;
							((TextObject)m_colGraphObj[nIndex]).clrText = value;
						}
					}

					// paints if needs to
					if (bNeedRefresh) 
						RepaintScreen();
				} catch (System.InvalidCastException exc)
				{
					System.Console.WriteLine(exc.ToString());
					m_clrText = value;
				}
				
			}
		}

		//sets/gets the font for th text
		public Font TextFont
		{
			get
			{
				if ( (m_colSelObjs.Count == 0) )
				{
					return( m_fntText );
				} 
				else
				{
					IList ilValues = m_colSelObjs.GetValueList();
					int nSel = (int)ilValues[0];
					if ( ((GraphicObject)m_colGraphObj[nSel]).nType != Tool.Text )
						return( m_fntText );
					else
						return( ((TextObject)m_colGraphObj[nSel]).fntText );
				}
			}

			set
			{
				Size size = new Size(0, 0);
				TextObject txtObj;
				bool bNeedRefresh = false;

				if ( m_colSelObjs.Count == 0 )
				{
					bNeedRefresh = false; //(value != m_fntText);
					m_fntText = value;					
				}
				else
				{
					IList ilValues = m_colSelObjs.GetValueList();
					addUndoRedoAttributeEntry( ref ilValues, AttributeChanged.Font );
					for ( int i = 0; i < m_colSelObjs.Count; i++ )
					{
						int nIndex = (int)ilValues[i];
						if ( ((GraphicObject)m_colGraphObj[nIndex]).nType != Tool.Text )
							continue;
						txtObj = ((TextObject)m_colGraphObj[nIndex]);
						bNeedRefresh = (value != txtObj.fntText) || bNeedRefresh;
						txtObj.fntText = value;
						if ( !txtObj.bResizeable )
						{
							CheckOffScreenBitmap();
							size = sizeText(ref txtObj );
							txtObj.ptDestiny.X = txtObj.ptSource.X + size.Width;
							txtObj.ptDestiny.Y = txtObj.ptSource.Y + size.Height;
							txtObj.rect = BuildRect( ref txtObj.ptSource, ref txtObj.ptDestiny );
						}
					}
				}

				// paints if needs to
				if (bNeedRefresh) 
					RepaintScreen();
			}
		}

		//sets/gets the string of the text
		public String TextString
		{
			get
			{
				if ( m_colSelObjs.Count == 0 )
				{
					return( m_strText );
				} 
				else
				{
					IList ilValues = m_colSelObjs.GetValueList();
					int nSel = (int)ilValues[0];
					if ( ((GraphicObject)m_colGraphObj[nSel]).nType != Tool.Text )
						return( m_strText );
					else
						return( ((TextObject)m_colGraphObj[nSel]).strText );
				}
			}

			set
			{
				Size size = new Size(0, 0);
				TextObject obj;
				bool bNeedRefresh = false;

				if ( m_colSelObjs.Count == 0 )
				{
					bNeedRefresh = false;//(value != m_strText);
					m_strText = value;					
				}
				else
				{
					IList ilValues = m_colSelObjs.GetValueList();
					for ( int i = 0; i < m_colSelObjs.Count; i++ )
					{
						int nIndex = (int)ilValues[i];
						if ( ((GraphicObject)m_colGraphObj[nIndex]).nType != Tool.Text )
						{
							m_strText = value;
							continue;
						}
						obj = ((TextObject)m_colGraphObj[nIndex]);
						bNeedRefresh = (value != obj.strText) || bNeedRefresh;
						((TextObject)m_colGraphObj[nIndex]).strText = value;
						CheckOffScreenBitmap();
						size = sizeText(ref obj );
						obj.ptDestiny.X = obj.ptSource.X + size.Width;
						obj.ptDestiny.Y = obj.ptSource.Y + size.Height;
						obj.rect = BuildRect( ref obj.ptSource, ref obj.ptDestiny );

					}
				}

				// paints if needs to
				if (bNeedRefresh) 
					RepaintScreen();
			}
		}

		public int ImageToInsertIndex
		{
			get 
			{
				return (m_nImageIndex);
			}
			set 
			{
				m_nImageIndex = value ;
			}
		}

		//sets/gets the name of the image file
		public System.Drawing.Image ImageToInsert
		{
			get
			{
				return( m_imgImageToInsert );
			}

			set
			{
				m_imgImageToInsert = value;
			}
		}

		//sets/gets the line style
		public LineStyle LineType
		{
			get
			{
				if ( m_colSelObjs.Count == 0 )
				{
					return( m_nLineStyle );
				} 
				else
				{
					IList ilValues = m_colSelObjs.GetValueList();
					int nSel = (int)ilValues[0];
					if ( ((GraphicObject)m_colGraphObj[nSel]).nType != Tool.Line )
						return( m_nLineStyle );
					else
						return( ((LineObject)m_colGraphObj[nSel]).nLineStyle );
				}
			}

			set
			{
				bool bNeedRefresh = false;

				if ( m_colSelObjs.Count == 0 )
				{
					bNeedRefresh = false;//(value != m_nLineStyle);
					m_nLineStyle = value;					
				}
				else
				{
					IList ilValues = m_colSelObjs.GetValueList();
					addUndoRedoAttributeEntry( ref ilValues, AttributeChanged.LineStyle );
					for ( int i = 0; i < m_colSelObjs.Count; i++ )
					{
						int nIndex = (int)ilValues[i];
						if ( ((GraphicObject)m_colGraphObj[nIndex]).nType != Tool.Line )
							continue;
						bNeedRefresh = (value != ((LineObject)m_colGraphObj[nIndex]).nLineStyle) || bNeedRefresh;
						((LineObject)m_colGraphObj[nIndex]).nLineStyle = value;
					}
				}

				// paints if needs to
				if (bNeedRefresh) 
					RepaintScreen();
			}
		}

		//sets/gets visibility of the grid
		public bool ShowGrid
		{
			get
			{
				return( m_bShowGrid );
			}

			set
			{
				bool bNeedRefresh = false;
				bNeedRefresh = (m_bShowGrid != value);
				m_bShowGrid = value;

				if (bNeedRefresh)
					RepaintScreen();
			}
		}

		//sets/gets opaque object
		public bool OpaqueObject
		{
			get
			{
				if ( m_colSelObjs.Count == 0 )
				{
					return( m_bOpaque );
				} 
				else
				{
					IList ilValues = m_colSelObjs.GetValueList();
					int nSel = (int)ilValues[0];
					if ( ((GraphicObject)m_colGraphObj[nSel]).nType == Tool.Circle )
						return( ((CircleObject)m_colGraphObj[nSel]).bOpaque );
					else if ( ((GraphicObject)m_colGraphObj[nSel]).nType == Tool.Rectangle )
						return( ((RectangleObject)m_colGraphObj[nSel]).bOpaque );
					else
						return( m_bOpaque );
				}
			}

			set
			{
				bool bNeedRefresh = false;

				if ( m_colSelObjs.Count == 0 )
				{
					bNeedRefresh = false;//(value != m_bOpaque);
					m_bOpaque = value;					
				}
				else
				{
					IList ilValues = m_colSelObjs.GetValueList();
					addUndoRedoAttributeEntry( ref ilValues, AttributeChanged.OpaqueBkg );
					for ( int i = 0; i < m_colSelObjs.Count; i++ )
					{
						int nIndex = (int)ilValues[i];
						switch ( ((GraphicObject)m_colGraphObj[nIndex]).nType )
						{
							case Tool.Circle:
								bNeedRefresh = (value != ((CircleObject)m_colGraphObj[nIndex]).bOpaque) || bNeedRefresh;
								((CircleObject)m_colGraphObj[nIndex]).bOpaque = value;
								break;
							
							case Tool.Rectangle:
								bNeedRefresh = (value != ((RectangleObject)m_colGraphObj[nIndex]).bOpaque) || bNeedRefresh;
								((RectangleObject)m_colGraphObj[nIndex]).bOpaque = value;
								break;

							default:
								break;
						}
					}
				}

				// paints if needs to
				if (bNeedRefresh) 
					RepaintScreen();
			}
		}

		//sets/gets the color of the selection pen
		public Color SelectionColor
		{
			get
			{
				return( m_penSelection.Color );
			}

			set
			{
				m_penSelection.Color = value;
			}
		}

		// sets/gets the pen color
		public Color PenColor
		{
			/* if there is no selected object, it is returned the
			 * screen attribute. Else, the first object selected
			 * returns its value
			*/
			get
			{
				if ( m_colSelObjs.Count == 0 )
				{
					return( m_clrPen );
				} 
				else
				{
					IList ilValues = m_colSelObjs.GetValueList();
					int nSel = (int)ilValues[0];

					switch ( ((GraphicObject)m_colGraphObj[nSel]).nType )
					{
						case Tool.Circle:
							return( ((CircleObject)m_colGraphObj[nSel]).clrPen );
						case Tool.Line:
							return( ((LineObject)m_colGraphObj[nSel]).clrPen );
						case Tool.Rectangle:
							return( ((RectangleObject)m_colGraphObj[nSel]).clrPen );
						default:
							return( m_clrPen );
					}
				}
			}

			/* if there is no selected object, this value applies to
			   the screen pen color. Otherwise, it changes the object(s)
			   attributes */

			set
			{
				bool bNeedRefresh = false;

				if ( m_colSelObjs.Count == 0 )
				{
					bNeedRefresh = false;//(value != m_clrPen);
					m_clrPen = value;					
				}
				else
				{
					IList ilValues = m_colSelObjs.GetValueList();
					addUndoRedoAttributeEntry( ref ilValues, AttributeChanged.PenColor );
					for ( int i = 0; i < m_colSelObjs.Count; i++ )
					{
						int nIndex = (int)ilValues[i];

						switch ( ((GraphicObject)m_colGraphObj[nIndex]).nType )
						{
							case Tool.Circle:
								bNeedRefresh = (value != ((CircleObject)m_colGraphObj[nIndex]).clrPen) || bNeedRefresh;
								((CircleObject)m_colGraphObj[nIndex]).clrPen = value;
								break;
							case Tool.Line:
								bNeedRefresh = (value != ((LineObject)m_colGraphObj[nIndex]).clrPen) || bNeedRefresh;
								((LineObject)m_colGraphObj[nIndex]).clrPen = value;
								break;
							case Tool.Rectangle:
								bNeedRefresh = (value != ((RectangleObject)m_colGraphObj[nIndex]).clrPen) || bNeedRefresh;
								((RectangleObject)m_colGraphObj[nIndex]).clrPen = value;
								break;
							default:
								break;
						}						
					}
				}

				// paints if needs to
				if (bNeedRefresh) 
					RepaintScreen();
			}
		}

		// sets/gets the background color
		public Color BackgroundColor
		{
			/* if there is no selected object, it is returned the
			 * screen attribute. Else, the first object selected
			 * returns its value
			*/
			get
			{
				if ( m_colSelObjs.Count == 0 )
				{
					return( m_clrBack );
				} 
				else
				{
					IList ilValues = m_colSelObjs.GetValueList();
					int nSel = (int)ilValues[0];

					switch ( ((GraphicObject)m_colGraphObj[nSel]).nType )
					{
						case Tool.Circle:
							return( ((CircleObject)m_colGraphObj[nSel]).clrBack );

						case Tool.Rectangle:
							return( ((RectangleObject)m_colGraphObj[nSel]).clrBack );

						default:
							return( m_clrBack );
					}						
				}
			}

			/* if there is no selected object, this value applies to
			   the screen background color. Otherwise, it changes the object(s)
			   attributes */
			set
			{
				bool bNeedRefresh = false;

				if ( m_colSelObjs.Count == 0 )
				{
					bNeedRefresh = (m_clrBack != value);
					m_clrBack = value;
				} 
				else
				{
					IList ilValues = m_colSelObjs.GetValueList();
					addUndoRedoAttributeEntry( ref ilValues, AttributeChanged.BackgroundColor );
					for ( int i = 0; i < m_colSelObjs.Count; i++ )
					{
						int nIndex = (int)ilValues[i];
						switch ( ((GraphicObject)m_colGraphObj[nIndex]).nType )
						{
							case Tool.Circle:
								bNeedRefresh = (value != ((CircleObject)m_colGraphObj[nIndex]).clrBack) || bNeedRefresh;
								((CircleObject)m_colGraphObj[nIndex]).clrBack = value;
								break;
							case Tool.Rectangle:
								bNeedRefresh = (value != ((RectangleObject)m_colGraphObj[nIndex]).clrBack) || bNeedRefresh;
								((RectangleObject)m_colGraphObj[nIndex]).clrBack = value;
								break;
							default:
								break;
						}						
					}
				}

				// paints the screen if needs to
				if (bNeedRefresh)
					RepaintScreen();
			}
		}

		// sets/gets the pen width
		public int PenWidth
		{
			/* if there is no selected object, it is returned the
			 * screen attribute. Else, the first object selected
			 * returns its value
			*/
			get
			{
				if ( m_colSelObjs.Count == 0 )
				{
					return( m_nPenWidth );
				}
				else
				{
					IList ilValues = m_colSelObjs.GetValueList();
					int nSel = (int)ilValues[0];

					switch ( ((GraphicObject)m_colGraphObj[nSel]).nType )
					{
						case Tool.Circle:
							return( ((CircleObject)m_colGraphObj[nSel]).nPenWidth );
						case Tool.Line:
							return( ((LineObject)m_colGraphObj[nSel]).nPenWidth );
						case Tool.Rectangle:
							return( ((RectangleObject)m_colGraphObj[nSel]).nPenWidth );
						default:
							return( m_nPenWidth );
					}											
				}
			}

			/* if there is no selected object, this value applies to
			   the screen pen width. Otherwise, it changes the object(s)
			   attributes */
			set
			{
				bool bNeedRefresh = false;

				m_nPenWidth = value;
				if ( m_colSelObjs.Count == 0 )
				{
					bNeedRefresh = false;//(m_nPenWidth != value);
				}
				else
				{
					IList ilValues = m_colSelObjs.GetValueList();
					addUndoRedoAttributeEntry( ref ilValues, AttributeChanged.PenWidth );
					for ( int i = 0; i < m_colSelObjs.Count; i++ )
					{
						int nIndex = (int)ilValues[i];
						switch ( ((GraphicObject)m_colGraphObj[nIndex]).nType )
						{
							case Tool.Circle:
								bNeedRefresh = (value != ((CircleObject)m_colGraphObj[nIndex]).nPenWidth) || bNeedRefresh;
								((CircleObject)m_colGraphObj[nIndex]).nPenWidth = value;
								break;
							case Tool.Line:
								bNeedRefresh = (value != ((LineObject)m_colGraphObj[nIndex]).nPenWidth) || bNeedRefresh;
								((LineObject)m_colGraphObj[nIndex]).nPenWidth = value;
								break;
							case Tool.Rectangle:
								bNeedRefresh = (value != ((RectangleObject)m_colGraphObj[nIndex]).nPenWidth) || bNeedRefresh;
								((RectangleObject)m_colGraphObj[nIndex]).nPenWidth = value;
								break;
							default:
								break;
						}											

					}
				}

				// paints the screen if needs to
				if (bNeedRefresh)
					RepaintScreen();
			}
		}


		// sets/gets the current tool
		public Tool CurrentTool
		{
			get
			{
				return( m_currTool ) ;
			}
			set
			{
				if ( m_currTool != value )
					m_prevTool = m_currTool;
				m_currTool = value;
				switch (m_currTool)
				{
					case Tool.Line:
						if ( !m_bShowLines )
							m_currTool = Tool.None;
						break;

					case Tool.Circle:
						if ( !m_bShowCircles )
							m_currTool = Tool.None;
						break;

					case Tool.Image:
						if ( !m_bShowImages )
							m_currTool = Tool.None;
						break;

					case Tool.Rectangle:
						if ( !m_bShowRectangles )
							m_currTool = Tool.None;
						break;

					case Tool.Text:
						if ( !m_bShowTexts )
							m_currTool = Tool.None;
						break;

					default:
						break;
				}
				OnCallToolChanged();
			}
		}

		// sets/gets the pen style
		public DashStyle PenStyle
		{
			/* if there is no selected object, it is returned the
			 * screen attribute. Else, the first object selected
			 * returns its value
			*/
			get
			{
				if ( m_colSelObjs.Count == 0 )
				{
					return( m_nPenStyle );
				}
				else
				{
					IList ilValues = m_colSelObjs.GetValueList();
					int nSel = (int)ilValues[0];

					switch ( ((GraphicObject)m_colGraphObj[nSel]).nType )
					{
						case Tool.Line:
							return( ((LineObject)m_colGraphObj[nSel]).nPenStyle );
						case Tool.Rectangle:
							return( ((RectangleObject)m_colGraphObj[nSel]).nPenStyle );
						case Tool.Circle:
							return( ((CircleObject)m_colGraphObj[nSel]).nPenStyle );
						default:
							return( m_nPenStyle );
					}
				}
			}

			/* if there is no selected object, this value applies to
			   the screen pen style. Otherwise, it changes the object(s)
			   attributes */
			set
			{
				bool bNeedRefresh = false;

				m_nPenStyle = value;
				if ( m_colSelObjs.Count == 0 )
				{
					bNeedRefresh = false;//(value != m_nPenStyle);
				}
				else
				{
					IList ilValues = m_colSelObjs.GetValueList();
					addUndoRedoAttributeEntry( ref ilValues, AttributeChanged.PenStyle );
					for ( int i = 0; i < m_colSelObjs.Count; i++ )
					{
						int nIndex = (int)ilValues[i];

						switch ( ((GraphicObject)m_colGraphObj[nIndex]).nType )
						{
							case Tool.Line:
								bNeedRefresh = (value != ((LineObject)m_colGraphObj[nIndex]).nPenStyle) || bNeedRefresh;
								((LineObject)m_colGraphObj[nIndex]).nPenStyle = value;
								break;

							case Tool.Rectangle:
								bNeedRefresh = (value != ((RectangleObject)m_colGraphObj[nIndex]).nPenStyle) || bNeedRefresh;
								((RectangleObject)m_colGraphObj[nIndex]).nPenStyle = value;
								break;

							case Tool.Circle:
								bNeedRefresh = (value != ((CircleObject)m_colGraphObj[nIndex]).nPenStyle) || bNeedRefresh;
								((CircleObject)m_colGraphObj[nIndex]).nPenStyle = value;
								break;

							default:
								break;
						}
					}
				}

				// paints the screen if needs to
				if (bNeedRefresh)
					RepaintScreen();
			}
		}

		// sets/gets the current mouse position over the drawing screen
		public Point MousePos
		{
			get
			{
				return( m_ptMousePos );
			}
			set
			{
				m_ptMousePos = value; // sets the screen value;
				// updates to the world coordinates;
				m_ptMousePos.X = X_Screen2World( m_ptMousePos.X );
				m_ptMousePos.Y = Y_Screen2World( m_ptMousePos.Y );
			}
		}

		// gets the source point of a new object
		public Point SourcePoint
		{
			get
			{
				return( m_ptSource );
			}
		}

		// gets the destiny point of a new object
		public Point DestinyPoint
		{
			get
			{
				return( m_ptDestiny );
			}
		}

		#endregion
		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
		}
		#endregion
		#region Constructors

		public DrawingCanvas(System.ComponentModel.IContainer container)
		{
			/// <summary>
			/// Required for Windows.Forms Class Composition Designer support
			/// </summary>
			container.Add(this);
			InitializeComponent();
			InitState();
		}

		public DrawingCanvas()
		{
			/// <summary>
			/// Required for Windows.Forms Class Composition Designer support
			/// </summary>
			InitializeComponent();
			InitState();
		}
		
		#endregion
		#region Init
		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged (e);
			m_bWindowNotStarted = false;
		}

		protected void vInitWindow()
		{
			// Start Window
			if ( !m_bWindowNotStarted )
			{
				// initializes the screen and window retangles
				m_rectScreen = new Rectangle( 0, 0, this.Size.Width, this.Size.Height );
				m_rectWindow = new Rectangle( m_rectScreen.X, m_rectScreen.Y, m_rectScreen.Width, m_rectScreen.Height );
				m_rectNormal = new Rectangle( m_rectWindow.X, m_rectWindow.Y, m_rectWindow.Width, m_rectWindow.Height );
				m_dZoom = 100.0;
				m_dWindowScale = m_dZoom;
				m_bWindowNotStarted = true;
			}
		}

		protected void InitState()
		{
			m_clrPen = Color.Black;
			m_clrBack = Color.White;
			m_nPenWidth = 1;

			this.BackColor = m_clrBack;

			m_ptSource.X = 0; m_ptSource.Y = 0;
			m_ptDestiny.X = 0; m_ptDestiny.Y = 0;
			m_ptReference.X = 0; m_ptReference.Y = 0;

			m_hbrBrush = new HatchBrush( HatchStyle.LargeGrid, Color.LightGray, m_clrBack);
			m_sbrBrush = new System.Drawing.SolidBrush(m_clrBack);
			this.SetFocusStyle();
			this.CreateHandlers();


			m_penFocus = new Pen( Color.LightGray, 1 );
			m_penFocus.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

			m_penSelection = new Pen( Color.DarkCyan, 1 );
			m_penSelection.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
			
			m_fntText = new Font( "Microsoft Sans Serif", (float)8.25, GraphicsUnit.Point );

			UpdateHighlightColors(System.Drawing.Color.FromArgb(128,255,155));
		}

		protected void SetFocusStyle()
		{
			m_grpFocus.strName = "FocusGraphicObject";
			m_grpFocus.nIndex  = -1;
			m_grpFocus.nType = Tool.Selection;
			m_grpFocus.clrPen = Color.LightGray;
			m_grpFocus.nPenWidth = 1;
			m_grpFocus.nPenStyle = System.Drawing.Drawing2D.DashStyle.Dash;
		}

		protected void CreateHandlers()
		{
			m_meDown = new MouseEventHandler( dcMouseClickDown );
			this.MouseDown += m_meDown;

			m_meUp = new MouseEventHandler( dcMouseClickUp );
			this.MouseUp += m_meUp;

			m_meDClick = new EventHandler(dcMouseDoubleClick);
			this.DoubleClick += m_meDClick;

			m_meEnter = new EventHandler( dcMouseEnter );
			this.MouseEnter += m_meEnter;

			m_meMove = new MouseEventHandler( dcMouseMovement );
			this.MouseMove += m_meMove;

			m_pePaint = new PaintEventHandler( dcPaint );
			this.Paint += m_pePaint;

		}

		#endregion
		#region Mouse Event Handlers
		protected virtual void dcMouseClickDown( Object sender, MouseEventArgs e )
		{
			MousePos = new Point(e.X , e.Y);

			if ( e.Button == MouseButtons.Left && m_currTool != Tool.None)
			{
				if ( m_colSelObjs.Count > 0 )
					SaveObjectStatus();
				m_ptSource.X = MousePos.X;
				m_ptSource.Y = MousePos.Y;
				m_ptReference = m_ptSource;

				//Is the user resizing the object?
				if (m_edgSelected != ObjectEdges.NONE ) 
					m_bResizingObject = true;
				else 
					m_bResizingObject = false;

				if (m_edgSelected == ObjectEdges.CENTER)
					m_bMovingObject = true;
				else
					m_bMovingObject = false;

				switch (m_currTool)
				{
					case Tool.Selection:
						if ( (m_colSelObjs.Count > 0) && m_rectSelection.Contains(MousePos) )
							m_bMovingObject = true;
						else
							m_bMovingObject = false;
						break;

					default:
						break;
				}
			} 
			else if ( (e.Button == MouseButtons.Right) && bCanHighlight() )
			{
				if ( m_nPreviousHighlight != - 1 )
					System.Windows.Forms.MessageBox.Show( "Clicou em " + m_nPreviousHighlight.ToString() );
			}
		}

		protected virtual void dcMouseClickUp( Object sender, MouseEventArgs e )
		{
			if ( e.Button == MouseButtons.Left && m_currTool != Tool.None)
			{
				GraphicObject obj;
				Graphics clientDC;
				int nSel;
				m_ptDestiny.X = MousePos.X;
				m_ptDestiny.Y = MousePos.Y; 

				switch (m_currTool)
				{
					case Tool.Selection:
						// if source and destiny point are the same
						if ( m_ptDestiny.Equals(m_ptSource) )
						{
							m_bSamePoint = true;
							// try to select one object
							if ( (nSel = nSelectedObject(MousePos)) != -1 )
							{
								clientDC = this.CreateGraphics();
								CheckOffScreenBitmap();								

								m_colSelObjs.Clear();

								obj = (GraphicObject)m_colGraphObj[nSel];
								if ( obj.nGroup >= 0 )
								{
									SelectGroup( obj.nGroup );
									m_rectSelection = BuildSelRect();
								}
								else
								{
									m_colSelObjs.Add(obj.nIndex, obj.nIndex );
									m_rectSelection = ((GraphicObject)m_colGraphObj[nSel]).rect;
								}
								SelectObjectList( ref m_memDC, ref m_rectSelection, true );

								//renderiza na tela
								PaintOnScreen( ref clientDC, ref m_memDC );
							} 
							else
							{
								m_bSamePoint = false;
								m_colSelObjs.Clear();
								m_rectSelection.Height = 0;
								m_rectSelection.Width = 0;
								RepaintScreen();
							}
						}
						else
						{
							if ( m_bResizingObject )
							{
								// resets the resizing state
								addUndoMoveResize( true ); // adds an undo entry for this operation
								m_bResizingObject = false;
								m_bMovingObject = false;
								m_edgSelected = ObjectEdges.NONE;
								m_rectSelection = BuildSelRect();
								RepaintScreen();
							}
							else if ( m_bMovingObject == false )
							{
								SetSelectedObjects();
								m_rectSelection = BuildSelRect();

								clientDC = this.CreateGraphics();

								CheckOffScreenBitmap();
								SelectObjectList(ref m_memDC, ref m_rectSelection, true);
								//render on screen
								PaintOnScreen( ref clientDC, ref m_memDC );
							} 
							else // object(s) moved
							{
								addUndoMoveResize( true );
								m_rectSelection = BuildSelRect();								
							}
							clientDC = this.CreateGraphics();

							CheckOffScreenBitmap();
							SelectObjectList(ref m_memDC, ref m_rectSelection, true);
							//render on screen
							PaintOnScreen( ref clientDC, ref m_memDC );
							m_bMovingObject = false;
						}
						break;

					case Tool.Circle: case Tool.Line: case Tool.Rectangle:
						// just create a new object if the points are not the same
						if ( m_bResizingObject ) // resize or moves the object with center edge
						{
							// resets the resizing state
							addUndoMoveResize( true );
							m_bResizingObject = false;
							m_bMovingObject = false;
							m_edgSelected = ObjectEdges.NONE;
							m_rectSelection = BuildSelRect();
							RepaintScreen();
						}
						else if ( !m_ptSource.Equals(m_ptDestiny) )
						{
							CreateNewObject(true);
							RepaintScreen();
							CurrentTool = Tool.Selection;
						}
						break;

					case Tool.Image:
						// to add an image, we need to click down and release the mouse button at the same point
						OnCallPropertiesBoxObjectImage(EventArgs.Empty);
						if (!m_bCancelActualAction) 
							CreateNewObject(true);
						CurrentTool = Tool.Selection;
						RepaintScreen();
						break;

					case Tool.Text:
						this.TextString = "Digite aqui o seu texto.";
						this.TextColor = this.PenColor;
						OnCallPropertiesBoxObjectText(EventArgs.Empty);
						if (!m_bCancelActualAction) 
							CreateNewObject(true);
						CurrentTool = Tool.Selection;
						RepaintScreen();
						break;
					default:
						break;
				}				
			}
		
		}

		/// <summary>
		/// dcMouseDoubleClick - Activate properties from object 
		/// </summary>
		protected virtual void dcMouseDoubleClick(Object sender, EventArgs e )
		{
			if (!m_bViewMode)
			{
				if (m_currTool != Tool.None)
				{
					GraphicObject obj;
					Graphics clientDC;
					int nSel;
					m_ptDestiny.X = MousePos.X;
					m_ptDestiny.Y = MousePos.Y; 

					switch (m_currTool)
					{
						case Tool.Selection:
							// if source and destiny point are the same
							if ( m_ptDestiny.Equals(m_ptSource) )
							{
								m_bSamePoint = true;
								// try to select one object
								if ( (nSel = nSelectedObject(MousePos)) != -1 )
								{
									clientDC = this.CreateGraphics();
									CheckOffScreenBitmap();								
									m_colSelObjs.Clear();

									obj = (GraphicObject)m_colGraphObj[nSel];
									switch(obj.GetType().ToString())
									{
										case "DrawingCanvasPackage.LineObject":
											LineObject objLine = (LineObject)obj;
											ObjectPrintable = objLine.bVisibleForPrinting;
											OnCallPropertiesBoxObjectLine(EventArgs.Empty);
											if (!m_bCancelActualAction)
											{
												objLine.bVisibleForPrinting = ObjectPrintable;
											} 
											break;

										case "DrawingCanvasPackage.CircleObject":
											CircleObject objCircle = (CircleObject)obj;
											ObjectPrintable = objCircle.bVisibleForPrinting;
											OnCallPropertiesBoxObjectCircle(EventArgs.Empty);
											if (!m_bCancelActualAction)
											{
												objCircle.bVisibleForPrinting = ObjectPrintable;
											} 
											break;

										case "DrawingCanvasPackage.RectangleObject":
											RectangleObject objRect = (RectangleObject)obj;
											ObjectPrintable = objRect.bVisibleForPrinting;
											OnCallPropertiesBoxObjectRectangle(EventArgs.Empty);
											if (!m_bCancelActualAction)
											{
												objRect.bVisibleForPrinting = ObjectPrintable;
											} 
											break;

										case "DrawingCanvasPackage.TextObject":
											TextObject objText = (TextObject)obj;
											this.TextString = objText.strText;
											this.TextColor = objText.clrText;
											this.TextFont = objText.fntText;
											this.ObjectPrintable = objText.bVisibleForPrinting;
											OnCallPropertiesBoxObjectText(EventArgs.Empty);
											if (!m_bCancelActualAction)
											{
												objText.strText = this.TextString;
												objText.clrText = this.TextColor;
												objText.fntText = this.TextFont; 
												objText.bVisibleForPrinting = this.ObjectPrintable;
												Size sz = sizeText(ref objText);
												System.Drawing.Point pt = new System.Drawing.Point(objText.ptSource.X + sz.Width,objText.ptSource.Y + sz.Height);
												objText.ptDestiny = pt;
												objText.rect = BuildRect(ref objText.ptSource, ref objText.ptDestiny);
											} 
											break;

										case "DrawingCanvasPackage.ImageObject":
											OnCallPropertiesBoxObjectImage(EventArgs.Empty);
											if (!m_bCancelActualAction)
											{
												int nIndex = 1;
												while (m_sortLstImages.ContainsKey(nIndex))
												{
													nIndex++;
												}
												m_sortLstImages.Add(nIndex,m_imgImageToInsert.Clone());
												((ImageObject)obj).nImageIndex =  nIndex;
												((ImageObject)obj).nImageIndexInDB = this.ImageToInsertIndex;
											} 
											break;
									}
									//renderiza na tela
									PaintOnScreen( ref clientDC, ref m_memDC );
								} 
							}
							break;
					}
				}
			}
	
		}

		protected virtual void dcMouseEnter( Object sender, EventArgs e )
		{
			// Overrided in Derived Class.
		}

		protected virtual void dcMouseMovement( Object sender, MouseEventArgs e )
		{
			MousePos = new Point(e.X, e.Y);
			CheckSelectCursor(MousePos);
			if ( e.Button == MouseButtons.Left && m_currTool != Tool.None)
			{
				m_ptDestiny.X = MousePos.X; m_ptDestiny.Y = MousePos.Y;
				switch (m_currTool)
				{
					case Tool.Circle: case Tool.Line: case Tool.Rectangle:
						if ( m_bResizingObject )
						{
							if ( m_edgSelected == ObjectEdges.CENTER )
								UpdateSelectedObjectsPos();
							else
								ResizeObjects( MousePos );
							RepaintScreen();
						} 
						else
							PaintCurrentObject(MousePos);
						break;

					case Tool.Selection:
						if ( m_bResizingObject )
						{
							if ( m_edgSelected == ObjectEdges.CENTER )
								UpdateSelectedObjectsPos();
							else
								ResizeObjects( MousePos );
							RepaintScreen();
						}
						else if ( /*m_colSelObjs.Count == 0 &&*/ m_bMovingObject == false)
							PaintSelectionRect( MousePos ); 
						else if ( m_colSelObjs.Count > 0 && m_bMovingObject == true )
						{
							UpdateSelectedObjectsPos(); // move objects
							RepaintScreen(); // redraw screen after update
						}
						break;

					default:
						break;
				}
			}
		}
		#endregion
		#region Painting methods

		protected virtual void HighLightObject( int nIndexObj )
		{
			if ( !bCanHighlight() )
				return;

			Graphics clientDC = this.CreateGraphics();
			GraphicObject obj;
			Rectangle rectUpdate;
			Point ptUpdateFrom;
			bool bBackRedrawed;


			bBackRedrawed = false;
			// erases the previous highlighting
			if ( m_nPreviousHighlight != -1 && (nIndexObj != m_nPreviousHighlight) )
			{
				obj = (GraphicObject)m_colGraphObj[ m_nPreviousHighlight ];
				if ( obj.bHighlighted )
				{
					obj.bHighlighted = false;
					PaintBackground( ref m_memDC, ref m_rectScreen );
					PaintObjects(  ref m_memDC );
					PaintOneObject( ref m_memDC, ref obj );
					rectUpdate = obj.rect;
					rectUpdate.Inflate( 10, 10 );
					ptUpdateFrom = new Point( rectUpdate.X, rectUpdate.Y );

					ptWorld2Screen( ref ptUpdateFrom );
					rectWorld2Screen( ref rectUpdate );
					PaintPartialOnScreen( ref clientDC, ref m_memDC, ref rectUpdate, ref ptUpdateFrom );
					bBackRedrawed = true;
				}
			}

			if ( nIndexObj == -1 )
			{
				m_nPreviousHighlight = -1;
				return;
			} 

			// highlight the current object
			m_nPreviousHighlight = nIndexObj;
			obj = (GraphicObject)m_colGraphObj[ nIndexObj ];
			//obj.bHighlighted = true;

			if ( !bBackRedrawed )
			{
				PaintBackground( ref m_memDC, ref m_rectScreen );
				PaintObjects(  ref m_memDC );
			}

			PaintOneObject( ref m_memDC, ref obj );
			rectUpdate = obj.rect;
			rectUpdate.Inflate( 10, 10 );
			ptUpdateFrom = new Point( rectUpdate.X, rectUpdate.Y );
			ptWorld2Screen( ref ptUpdateFrom );
			rectWorld2Screen( ref rectUpdate );

			if ( m_colSelObjs.Contains(obj.nIndex) )
				PaintEdges( ref m_memDC, ref m_rectSelection );
			PaintPartialOnScreen( ref clientDC, ref m_memDC, ref rectUpdate, ref ptUpdateFrom );
		}

		protected void PaintSelectionRect( Point pt )
		{
			Graphics clientDC;
			Rectangle rect;

			m_ptDestiny.X = pt.X; m_ptDestiny.Y = pt.Y;
			CreateNewObject(false);

			rect = new Rectangle(m_rectScreen.X, m_rectScreen.Y, m_rectScreen.Width, m_rectScreen.Height);

			clientDC = this.CreateGraphics();

			CheckOffScreenBitmap();

			PaintBackground(ref m_memDC, ref rect);
			PaintObjects(ref m_memDC);
			
			((SelectionObject)m_grpObject).clrPen = m_penSelection.Color;
			((SelectionObject)m_grpObject).nPenStyle = m_penSelection.DashStyle;
			m_grpObject.rect = BuildRect( ref m_grpObject.ptSource, ref m_grpObject.ptDestiny );
			m_rectSelection = m_grpObject.rect; // sets the selection rectangle


			((SelectionObject)m_grpObject).bIsSelection = true;
			PaintOneObject( ref m_memDC, ref m_grpObject );
			
			PaintOnScreen( ref clientDC, ref m_memDC );
		}

		protected void PaintCurrentObject(Point pt)
		{
			GraphicObject obj;
			Graphics clientDC;
			Rectangle rect;

			m_ptDestiny.X = pt.X; m_ptDestiny.Y = pt.Y;

			CreateNewObject(false);

			rect = new Rectangle(m_rectScreen.X, m_rectScreen.Y, m_rectScreen.Width, m_rectScreen.Height);
			clientDC = this.CreateGraphics();

			CheckOffScreenBitmap();

			PaintBackground(ref m_memDC, ref rect);
 
			obj = m_grpObject;
			PaintObjects(ref m_memDC);
			PaintOneObject(ref m_memDC, ref obj);

			PaintOnScreen( ref clientDC, ref m_memDC );
		}


		protected void PaintOnScreen( ref Graphics clientDC, ref Graphics m_memDC )
		{
			IntPtr hdc = clientDC.GetHdc();
			IntPtr hMemdc = m_memDC.GetHdc();
			Rectangle rectPiece;

			// 1
			rectPiece = new Rectangle(m_rectScreen.X, m_rectScreen.Y, m_rectScreen.Width / 2, m_rectScreen.Height / 2 );
			Win32Support.BitBlt(hdc, rectPiece.X, rectPiece.Y, rectPiece.Width, rectPiece.Height, 
				hMemdc, m_rectScreen.X, m_rectScreen.Y, Win32Support.TernaryRasterOperations.SRCCOPY);

			// 2
			rectPiece.X = m_rectScreen.X + (m_rectScreen.Width / 2);
			rectPiece.Y = m_rectScreen.Y;
			Win32Support.BitBlt(hdc, rectPiece.X, rectPiece.Y, rectPiece.Width, rectPiece.Height, 
				hMemdc, m_rectScreen.X + (m_rectScreen.Width / 2), m_rectScreen.Y, Win32Support.TernaryRasterOperations.SRCCOPY);

			// 3
			rectPiece.X = m_rectScreen.X;
			rectPiece.Y = m_rectScreen.Y + (m_rectScreen.Height / 2);
			Win32Support.BitBlt(hdc, rectPiece.X, rectPiece.Y, rectPiece.Width, rectPiece.Height, 
				hMemdc, m_rectScreen.X, m_rectScreen.Y + (m_rectScreen.Height / 2), Win32Support.TernaryRasterOperations.SRCCOPY);

			// 4
			rectPiece.X = m_rectScreen.X + (m_rectScreen.Width / 2);
			rectPiece.Y = m_rectScreen.Y + (m_rectScreen.Height / 2);
			Win32Support.BitBlt(hdc, rectPiece.X, rectPiece.Y, rectPiece.Width, rectPiece.Height, 
				hMemdc, m_rectScreen.X + (m_rectScreen.Width / 2), m_rectScreen.Y + (m_rectScreen.Height / 2), Win32Support.TernaryRasterOperations.SRCCOPY);

			clientDC.ReleaseHdc(hdc);
			m_memDC.ReleaseHdc(hMemdc);
		}

		protected void PaintPartialOnScreen( ref Graphics clientDC, ref Graphics m_memDC, 
			ref Rectangle rectDest, ref Point ptSrc )
		{
			IntPtr hdc = clientDC.GetHdc();
			IntPtr hMemdc = m_memDC.GetHdc();
			Win32Support.BitBlt(hdc, rectDest.X, rectDest.Y, rectDest.Width, rectDest.Height, 
				hMemdc, ptSrc.X, ptSrc.Y, Win32Support.TernaryRasterOperations.SRCCOPY);
			clientDC.ReleaseHdc(hdc);
			m_memDC.ReleaseHdc(hMemdc);
		}

		protected void PaintOnScreen_Clipped( ref Graphics clientDC, ref Graphics m_memDC, Rectangle rectClip )
		{
			IntPtr hdc = clientDC.GetHdc();
			IntPtr hMemdc = m_memDC.GetHdc();
			Win32Support.BitBlt(hdc, rectClip.X, rectClip.Y, rectClip.Width, rectClip.Height, 
				hMemdc, rectClip.X, rectClip.Y, Win32Support.TernaryRasterOperations.SRCCOPY);
			clientDC.ReleaseHdc(hdc);
			m_memDC.ReleaseHdc(hMemdc);
		}
	

		protected virtual void PaintBackground(ref Graphics e, ref Rectangle r)
		{
			Rectangle rectPage, rectPgShadowRight, rectPgShadowDown/*, rectClip*/;
			
			if ( m_bShowGrid )
			{
				m_hbrBrush = new HatchBrush(HatchStyle.LargeGrid, Color.LightGray, m_clrBack);
				e.FillRectangle( m_hbrBrush, r );
			} 
			else
			{
				m_sbrBrush.Color = m_clrBack;
				e.FillRectangle(m_sbrBrush , r);
			}

			// draws the page
			rectPage = new Rectangle( m_rectScreen.X, m_rectScreen.Y, m_sizePage.Width, m_sizePage.Height );
			rectPgShadowRight = new Rectangle( rectPage.X + rectPage.Width, rectPage.Y + 10, 10, rectPage.Height ); 
			rectPgShadowDown = new Rectangle( rectPage.X + 5, rectPage.Y + rectPage.Height, rectPage.Width, 10 ); 
			rectWorld2Screen( ref rectPage );
			rectWorld2Screen( ref rectPgShadowDown );
			rectWorld2Screen( ref rectPgShadowRight );
			e.DrawRectangle( Pens.Black, rectPage );
			e.FillRectangle( Brushes.Black, rectPgShadowDown );
			e.FillRectangle( Brushes.Black, rectPgShadowRight );
		}

		protected virtual void PaintObjects(ref Graphics graph)
		{
			GraphicObject obj = null; 
			for (int i = 0; i < m_colGraphObj.Count; i++)
			{
				try
				{
					obj = (GraphicObject)m_colGraphObj[i];
					PaintOneObject(ref graph, ref obj);
				}
				catch
				{

				}
			}
		}

		protected virtual void PaintOneObject(ref Graphics graph, ref GraphicObject obj)
		{
			try
			{
				Font fntText;
				float fFontSize;
				Point ptSrc, ptDest;
				Rectangle rectDest, rectSrc;
				Image img;
				Rectangle rect;
				Pen pen;
			
				ptSrc = obj.ptSource;
				ptDest = obj.ptDestiny;

				if ( bIsPrinting() == false )
				{
					ptWorld2Screen( ref ptSrc );
					ptWorld2Screen( ref ptDest );
				}
				rect = BuildRect( ref ptSrc, ref ptDest );

				switch (obj.nType)
				{
					case Tool.Line:
						LineObject objLine = (LineObject)obj;					

						if ( !m_bShowLines )
						{
							objLine.bVisibleOnScreen = false;
							break;
						} 
						else
							objLine.bVisibleOnScreen = true;

					switch (objLine.nLineStyle)
					{
						case LineStyle.Horizontal: // always use source point as base
							objLine.ptDestiny.Y = objLine.ptSource.Y;
							ptDest.Y = ptSrc.Y;
							break;

						case LineStyle.Vertical:
							objLine.ptDestiny.X = objLine.ptSource.X;
							ptDest.X = ptSrc.X;
							break;

						default: // free style
							break;
					}

					
						if ( objLine.bHighlighted && bCanHighlight() )
							pen = new Pen(Color.FromKnownColor(KnownColor.Highlight), objLine.nPenWidth * 2 );        
						else if ( objLine.bVisibleForPrinting )
							pen = new Pen(objLine.clrPen, objLine.nPenWidth );        
						else 
							pen = new Pen(m_clrNotPrintable, objLine.nPenWidth ); // not printable
						
						pen.DashStyle = objLine.nPenStyle;
						if (m_bIsCreatingPDF)
							m_pdfReport.bAdicionaLinha(pen,ptSrc, ptDest);
						else
							graph.DrawLine(pen, ptSrc, ptDest);
						break;

					case Tool.Rectangle:
						RectangleObject objRect = (RectangleObject)obj;

						if ( !m_bShowRectangles && !objRect.bIsSelection  )
						{
							objRect.bVisibleOnScreen = false;
							break;
						} 
						else
							objRect.bVisibleOnScreen = true;

						if ( objRect.bOpaque == true )
						{
							rect.X += 1; rect.Y += 1;
							graph.FillRectangle(new SolidBrush(objRect.clrBack), rect);
							rect.X += -1; rect.Y += -1;
						}

						if ( objRect.bHighlighted && bCanHighlight() )
							pen = new Pen( Color.FromKnownColor(KnownColor.Highlight), objRect.nPenWidth * 2 );        
						else if ( objRect.bVisibleForPrinting )
							pen = new Pen(objRect.clrPen, objRect.nPenWidth );        
						else
							pen = new Pen( m_clrNotPrintable, objRect.nPenWidth );        
						pen.DashStyle = objRect.nPenStyle;
						if (m_bIsCreatingPDF)
							m_pdfReport.bAdicionaRetangulo(pen,rect);
						else
							graph.DrawRectangle(pen, rect);
						break;

					case Tool.Circle:
						CircleObject objCirc = (CircleObject)obj;

						if ( !m_bShowCircles )
						{
							objCirc.bVisibleOnScreen = false;
							break;
						} 
						else
							objCirc.bVisibleOnScreen = true;

						if ( objCirc.bOpaque == true )
						{
							rect.X += 1; rect.Y += 1;
							graph.FillEllipse(new SolidBrush(objCirc.clrBack), rect);
							rect.X += -1; rect.Y += -1;
						}

						if ( objCirc.bHighlighted && bCanHighlight() )
							pen = new Pen(Color.FromKnownColor(KnownColor.Highlight), objCirc.nPenWidth * 2 );
						else if ( objCirc.bVisibleForPrinting )
							pen = new Pen(objCirc.clrPen, objCirc.nPenWidth );        
						else
							pen = new Pen(m_clrNotPrintable, objCirc.nPenWidth );        
						pen.DashStyle = objCirc.nPenStyle;
						if (m_bIsCreatingPDF)
							m_pdfReport.bAdicionaCirculo(pen,rect);
						else
							graph.DrawEllipse(pen, rect);
						break;

					case Tool.Selection: // selection = focus
						rect = rectWorld2Screen( ref obj.rect );
						rect.Inflate(1, 1);
						graph.DrawRectangle(m_penFocus, rect);
						break;

					case Tool.Image:
						ImageObject objImg = (ImageObject)obj;

						if ( !m_bShowImages )
						{
							objImg.bVisibleOnScreen = false;
							break;
						} 
						else
							objImg.bVisibleOnScreen = true;

						// Getting the Image
						if (m_sortLstImages.ContainsKey(objImg.nImageIndexInDB))
						{
							int nIndex = m_sortLstImages.IndexOfKey(objImg.nImageIndexInDB);
							img = (Image)m_sortLstImages.GetByIndex(nIndex);
							rectDest = rect;
							rectSrc = new Rectangle( 0, 0, img.Width, img.Height );
							if (m_bIsCreatingPDF)
								m_pdfReport.bAdicionaImagem(img,rectDest);
							else
								graph.DrawImage(img, rectDest, rectSrc, GraphicsUnit.Pixel );
							if ( objImg.bHighlighted && bCanHighlight() )
								graph.DrawRectangle( new Pen(Color.FromKnownColor(KnownColor.Highlight), 2), objImg.rect );
						}
						break;

					case Tool.Text:
						try
						{
							TextObject objText = (TextObject)obj;

							if ( !m_bShowTexts && (obj.nSubType == -1) )
							{
								objText.bVisibleOnScreen = false;
								break;
							} 
							else
								objText.bVisibleOnScreen = true;

							if (!m_bIsPrinting)
								fFontSize = (objText.fntText.Size * (float)m_dZoom) / (float)100.0;
							else
								fFontSize = (objText.fntText.Size);
							// HACK: Trying take care off the overflow and the underflow 
							fFontSize = (float)System.Math.Round((decimal)fFontSize);

							fntText = new Font( objText.fntText.FontFamily, fFontSize, objText.fntText.Style, objText.fntText.Unit );					
							if ( objText.bHighlighted && bCanHighlight() && !m_bIsPrinting )
							{
								Color clrInv;
								Rectangle rectH = rect;
								rectH.Offset( 1, 1 );
								rectH.Height -= 1; rectH.Width -= 1;
								graph.FillRectangle( new SolidBrush( m_clrHighlight[objText.nState] ), rectH );
								if ( m_clrHighlight[objText.nState].ToKnownColor() == KnownColor.Highlight )
									clrInv = Color.FromKnownColor(KnownColor.HighlightText);
								else
									clrInv = Color.FromArgb( 255 - m_clrHighlight[objText.nState].R, 
										255 - m_clrHighlight[objText.nState].G, 
										255 - m_clrHighlight[objText.nState].B );
								PaintText( ref graph, ref objText, ref fntText, ref ptSrc, ref ptDest, ref objText.size, clrInv );
							}
							else if ( objText.bVisibleForPrinting )
							{
								PaintText( ref graph, ref objText, ref fntText, ref ptSrc, ref ptDest, ref objText.size, objText.clrText );
							}
							else
							{
								PaintText( ref graph, ref objText, ref fntText, ref ptSrc, ref ptDest, ref objText.size, m_clrNotPrintable );
							}
						}catch{
							// HACK: Trying to set the font size to less to resolve the trouble 
							TextObject objText = (TextObject)obj;
							if (objText.fntText.Size > 6)
							{
								objText.fntText = new Font(objText.fntText.FontFamily,((float)System.Math.Round(objText.fntText.Size - 1)),objText.fntText.Style,objText.fntText.Unit);
								PaintOneObject(ref graph,ref obj);
							}
						}
						break;
					default:
						break;
				}
			}
			catch(System.Exception e)
			{
				vHandleException(ref e);
			}
		}

		protected void PaintEdges(ref Graphics graph, ref Rectangle rect)
		{
			System.Drawing.Brush brush;
			System.Drawing.Pen pen;
			Rectangle rectSel = rect;

			rectWorld2Screen( ref rectSel );
			Rectangle /*rectClip,*/ edge = new Rectangle();
			int nCurrEdge, nOffset, nSize; // nOffset => offset from the focus rect

			// if the background is too dark, changes the edge color
			if ((m_clrBack.R < 100) && (m_clrBack.G < 100) && (m_clrBack.B < 100) )
				brush = Brushes.White;
			else
				brush = Brushes.Black;
			pen = new Pen(brush, 2);

			nSize = 5;
			edge.Width = nSize;
			edge.Height = nSize;
			nOffset = 3;
			nCurrEdge = 0;

			//canto superior esquerdo
			edge.X = rectSel.X - nSize - nOffset;
			edge.Y = rectSel.Y - nSize - nOffset;
			graph.FillRectangle(brush, edge);
			m_arrEdges[nCurrEdge] = edge;
			nCurrEdge = nCurrEdge + 1;

			//meio superior
			edge.X = rectSel.X + (rectSel.Width / 2) - (nSize / 2);
			edge.Y = rectSel.Y - nSize - nOffset;
			graph.FillRectangle(brush, edge);
			m_arrEdges[nCurrEdge] = edge;
			nCurrEdge = nCurrEdge + 1;

			//canto superior direito
			edge.X = (rectSel.X + rectSel.Width) + nOffset;
			edge.Y = rectSel.Y - nSize - nOffset;
			// Margin
			graph.FillRectangle(brush, edge);
			m_arrEdges[nCurrEdge] = edge;
			nCurrEdge = nCurrEdge + 1;

			//meio lateral direito
			edge.X = (rectSel.X + rectSel.Width) + nOffset;
			edge.Y = rectSel.Y + (rectSel.Height / 2) - (nSize / 2);
			graph.FillRectangle(brush, edge);
			m_arrEdges[nCurrEdge] = edge;
			nCurrEdge = nCurrEdge + 1;

			//canto inferior direito
			edge.X = (rectSel.X + rectSel.Width) + nOffset;
			edge.Y = (rectSel.Y + rectSel.Height) + nOffset;
			graph.FillRectangle(brush, edge);
			m_arrEdges[nCurrEdge] = edge;
			nCurrEdge = nCurrEdge + 1;

			//meio inferior
			edge.X = rectSel.X + (rectSel.Width / 2) - (nSize /2);
			edge.Y = (rectSel.Y + rectSel.Height) + nOffset;
			graph.FillRectangle(brush, edge);
			m_arrEdges[nCurrEdge] = edge;
			nCurrEdge = nCurrEdge + 1;

			//canto inferior esquerdo
			edge.X = rectSel.X - nSize - nOffset;
			edge.Y = (rectSel.Y + rectSel.Height) + nOffset;
			graph.FillRectangle(brush, edge);
			m_arrEdges[nCurrEdge] = edge;
			nCurrEdge = nCurrEdge + 1;

			//meio lateral esquerdo
			edge.X = rectSel.X - nSize - nOffset;
			edge.Y = rectSel.Y + (rectSel.Height / 2) - (nSize / 2);
			graph.FillRectangle(brush, edge);
			m_arrEdges[nCurrEdge] = edge;
			nCurrEdge = nCurrEdge + 1;

			//central
			edge.X = rectSel.X + (rectSel.Width / 2) - (nSize / 2);
			edge.Y = rectSel.Y + (rectSel.Height / 2) - (nSize / 2);
			edge.Inflate(1, 1);
			//graph.FillEllipse(brush, edge);
			graph.DrawLine(pen, edge.X, edge.Y, (edge.X + edge.Width), (edge.Y + edge.Height));
			graph.DrawLine(pen, edge.X, (edge.Y + edge.Height), (edge.X + edge.Width), edge.Y);
			edge.Inflate(-1, -1);
			m_arrEdges[nCurrEdge] = edge;
			nCurrEdge = nCurrEdge + 1;
		}

		//seleciona os objetos da lista de objetos selecionados
		protected void SelectObjectList(ref Graphics graph, ref Rectangle selRect, bool bRedrawBack)
		{
			GraphicObject obj;
			Rectangle rect;

			rect = new Rectangle( m_rectScreen.X, m_rectScreen.Y, m_rectScreen.Width, m_rectScreen.Height);

			//monta retângulo de foco
			m_grpFocus.rect = selRect;
			m_grpFocus.rect.Inflate(1, 1);

			//renderiza na imagem
			if ( bRedrawBack )
			{
				PaintBackground(ref graph, ref rect);
				PaintObjects(ref graph);
			}

			if ( m_colSelObjs.Count > 0)
			{
				//desenha o retângulo de foco na imagem e desenha suas arestas
				m_grpFocus.nIndex = 1; // there is a single selected object
				m_rectSelection = selRect;				
				obj = m_grpFocus;
				PaintOneObject(ref graph, ref obj);
				if ( !m_bResizingObject || m_bSamePoint )
				{
					m_grpFocus.rect = rectScreen2World( ref m_grpFocus.rect );
					PaintEdges(ref graph, ref m_grpFocus.rect);
				}
			}
		}

		//bitblt repaint
		protected void RepaintScreen()
		{
			// Start Window
			if ( !m_bWindowNotStarted )
			{
				this.dcPaint(this,new System.Windows.Forms.PaintEventArgs(this.CreateGraphics(),new System.Drawing.Rectangle(0,0,this.Width,this.Height)));
				return;
			}

			CheckOffScreenBitmap();
			Rectangle clientRect;
			Graphics clientDC = this.CreateGraphics();

			//Render
			clientRect = new Rectangle(m_rectScreen.X, m_rectScreen.Y, m_rectScreen.Width, m_rectScreen.Height);
			PaintBackground(ref m_memDC, ref clientRect);
			PaintObjects(ref m_memDC);

			if ( m_colSelObjs.Count > 0 && !m_bMovingObject )
			{
				SelectObjectList(ref m_memDC, ref m_rectSelection, false); 
				if ( !m_bResizingObject )
				{
					PaintEdges(ref m_memDC, ref m_rectSelection);
				}
			} 
			if ( m_nPreviousHighlight != -1 )
				HighLightObject( -1 );

			PaintOnScreen( ref clientDC, ref m_memDC );
			clientDC.Dispose();
			GC.Collect();
		}

		// OnPaint event
		protected virtual void dcPaint( Object sender, PaintEventArgs e )
		{
			Graphics g = e.Graphics;
			e.Graphics.Clip = new Region( e.ClipRectangle );
			if ( !m_bWindowNotStarted )
			{
				// initializes the screen and window retangles
				m_rectScreen = new Rectangle( 0, 0, this.Size.Width, this.Size.Height );
				m_rectWindow = new Rectangle( m_rectScreen.X, m_rectScreen.Y, m_rectScreen.Width, m_rectScreen.Height );
				m_rectNormal = new Rectangle( m_rectWindow.X, m_rectWindow.Y, m_rectWindow.Width, m_rectWindow.Height );
				m_dZoom = 100.0;
				m_dWindowScale = m_dZoom;
				m_bWindowNotStarted = true;
			}
			
			PaintBackground(ref g, ref m_rectScreen);
			PaintObjects(ref g);
			if ( m_colSelObjs.Count > 0 )
			{
				SelectObjectList(ref g, ref m_rectSelection, true);
				PaintEdges(ref g, ref m_rectSelection);
			} 
			GC.Collect();
		}

		protected String strNextWord( ref String strText )
		{
			string strReturn = "";
			int nSpaceIndex;
			int nEnterIndex;
			nSpaceIndex = strText.IndexOf(' ');
			if (nSpaceIndex == 0)
			{
				strText = strText.Remove( 0," ".Length);
				return(" ");
			}
			nEnterIndex = strText.IndexOf(System.Environment.NewLine);
			if (nEnterIndex == 0)
			{
				strReturn = System.Environment.NewLine;
				strText = strText.Remove( 0, System.Environment.NewLine.Length);
			}else{
				if ((nEnterIndex < nSpaceIndex) && (nEnterIndex != -1))
				{
					strReturn =  strText.Substring( 0, nEnterIndex );
					strText = strText.Remove( 0, nEnterIndex);
				}
				else
				{
					nSpaceIndex = (nSpaceIndex != -1) ? nSpaceIndex : strText.Length;
					strReturn =  strText.Substring( 0, nSpaceIndex );
					if (nSpaceIndex == 0)
						nSpaceIndex++;
					strText = strText.Remove( 0, nSpaceIndex );
				}
			}
   			return(strReturn);
		}

		protected virtual int PaintText( ref Graphics graph, ref TextObject objText, ref Font fntText, 
			ref Point ptSrc, ref Point ptDest, ref Size size, Color clrText )
		{
			int nLine, nTotalHeight = 0;
			Rectangle rect;
			String strText, strCurrText;
			Point ptSRC = ptSrc;
			Point ptDEST = ptDest;

			rect = BuildRect( ref ptSRC, ref ptDEST );
			Region rgnOld = graph.Clip;
			graph.Clip = new Region( rect );

			nLine = 0;
			if (rect.Size.Width < size.Width)
			{
				Size sizeWord;
				String strWord;
				strText = objText.strText;
				strCurrText = "";
				int nInc, nWordNumber;
				nLine = 0;
				nWordNumber = 0;
				while (  strText.Length > 0 )
				{
					strWord = strNextWord( ref strText );
					nWordNumber++;
					nInc = (strText.Length > 0) ? 1 : 0;
					strCurrText += strWord;
					// HACK: Mod
					//sizeWord = sizeText( ref graph, ref strCurrText, ref fntText );
					sizeWord = sizeText(ref strCurrText, ref fntText );
					if ((strWord.IndexOf(System.Environment.NewLine) == 0) || ((sizeWord.Width > rect.Width) && (nWordNumber != 1)))
					{
						if (strWord.IndexOf(System.Environment.NewLine) != 0)
							strCurrText = strCurrText.Remove( strCurrText.Length - strWord.Length - nInc, strWord.Length + nInc ); 
						else
							strWord = "";
						if (strWord != System.Environment.NewLine)
							strText = strWord + strText;
						else
							strText = strWord + strText;
						nLine++;
						if (m_bIsCreatingPDF)
							m_pdfReport.bAdicionaTexto(strCurrText, fntText,clrText, ptSRC.X,ptSRC.Y);
						else
							graph.DrawString( strCurrText, fntText, new SolidBrush(clrText), ptSRC.X,ptSRC.Y, StringFormat.GenericTypographic );
						ptSRC.Y += fntText.Height + 1;
						strCurrText = "";
						nWordNumber = 0;
						objText.size.Height += fntText.Height + 1;
						
					} 
					else if ( strText.Length == 0 )
					{
						//PaintString( ref graph, ref strCurrText, ref fntText, new SolidBrush(clrText),ref size, ref ptSRC, ref ptDEST, objText.alignment );
						if (m_bIsCreatingPDF)
							m_pdfReport.bAdicionaTexto(strCurrText, fntText,clrText, ptSRC.X,ptSRC.Y);
						else
							graph.DrawString( strCurrText, fntText, new SolidBrush(clrText), ptSRC.X,ptSRC.Y, StringFormat.GenericTypographic );
					} 
					else if ( (nWordNumber == 1) && (sizeWord.Width > rect.Width) )
					{
						graph.Clip = rgnOld;
						return( 0 );
					}
				}
			}
			else 
			{
                PaintString( ref graph, ref objText.strText, ref fntText, clrText,
					ref size, ref ptSrc, ref ptDest, objText.alignment );
			} 
			
			graph.Clip = rgnOld;
			nTotalHeight = ((nLine + 1) * fntText.Height) + nLine;
			return( nTotalHeight );
		}

		protected void PaintString( ref Graphics graph, ref String strText, ref Font fntText,System.Drawing.Color clrColor, ref Size size,
			ref Point pt1, ref Point pt2, Alignment alignment )
		{
			SolidBrush brush = new System.Drawing.SolidBrush(clrColor);
			int nOffsetX, X;
			switch ( alignment )
			{
				case Alignment.Left:
					if (m_bIsCreatingPDF)
						m_pdfReport.bAdicionaTexto(strText, fntText,clrColor, pt1.X,pt1.Y);
					else
						graph.DrawString( strText, fntText, brush, pt1.X, pt1.Y, StringFormat.GenericTypographic );
					break;

				case Alignment.Center:
					nOffsetX = ((pt2.X - pt1.X) / 2) - (size.Width / 2);
					X = pt1.X + nOffsetX;		
					if (m_bIsCreatingPDF)
						m_pdfReport.bAdicionaTexto(strText, fntText,clrColor,X,pt1.Y);
					else
						graph.DrawString( strText, fntText, brush, X, pt1.Y, StringFormat.GenericTypographic );
					break;

				case Alignment.Right:
					nOffsetX = (pt2.X - pt1.X) - size.Width;
					X = pt1.X + nOffsetX;						
					if (m_bIsCreatingPDF)
						m_pdfReport.bAdicionaTexto(strText, fntText,clrColor, X,pt1.Y);
					else
						graph.DrawString( strText, fntText, brush, X, pt1.Y, StringFormat.GenericTypographic );
					break;

				default:
					break;
			}
		}

	#endregion
		#region Public methods

		public bool bSetSpacing( Spacing type, bool bRepaint )
		{
			//TODO: Make the spacing for Texts Object
			if ( m_colSelObjs.Count < 3 )
				return( false );

			Rectangle rect1, rect2;
			int nObjIndex, nAverageSpacing, nWidth, nHeight;
			GraphicObject obj, objRef;
			IList ilValues = m_colSelObjs.GetValueList();

			SortedList sl = new SortedList();
			for ( int i = 0; i < ilValues.Count; i++ )
			{
				nObjIndex = (int)ilValues[ i ];
				obj = (GraphicObject)m_colGraphObj[ nObjIndex ];
				// Only Lines
				if (obj.GetType().ToString() != "DrawingCanvasPackage.LineObject")
					continue;

				if (type == Spacing.Horizontal)
				{
					if ((System.Math.Abs(obj.ptSource.X - obj.ptDestiny.X)) < 5)
						if (!sl.ContainsKey(obj.rect.X))
							sl.Add( obj.rect.X, obj.nIndex );

				}else if(type == Spacing.Vertical){
					if ((System.Math.Abs(obj.ptSource.Y - obj.ptDestiny.Y)) < 5)
						if (!sl.ContainsKey(obj.rect.Y))
							sl.Add( obj.rect.Y, obj.nIndex );
				}
			}

			// calculates the average spacing between the selected objects
			ilValues = sl.GetValueList();
			if (ilValues.Count < 3)
				return(false);
			nObjIndex = (int)ilValues[ 0 ];
			obj = (GraphicObject)m_colGraphObj[ nObjIndex ];
			rect1 = obj.rect;
			nAverageSpacing = 0;
			for ( int i = 1; i < ilValues.Count; i++ )
			{
				nObjIndex = (int)ilValues[ i ];
				obj = (GraphicObject)m_colGraphObj[ nObjIndex ];
				rect2 = obj.rect;

				switch (type)
				{
					case Spacing.Horizontal:
						if ( rect2.X > rect1.X )
							nAverageSpacing += Math.Abs(rect2.X - (rect1.X + rect1.Width));
						else
							nAverageSpacing += Math.Abs(rect1.X - (rect2.X + rect2.Width));
						break;

					case Spacing.Vertical:
						if ( rect2.Y > rect1.Y )
							nAverageSpacing += Math.Abs(rect2.Y - (rect1.Y + rect1.Height));
						else
							nAverageSpacing += Math.Abs(rect1.Y - (rect2.Y + rect2.Height));
						break;

					default:
						break;
				}

				rect1 = rect2;
			}

			nAverageSpacing = (nAverageSpacing / (ilValues.Count - 1));
				
			nObjIndex = (int)ilValues[ 0 ];
			objRef = (GraphicObject)m_colGraphObj[ nObjIndex ];
			for ( int i = 1; i < ilValues.Count; i++ )
			{
				nObjIndex = (int)ilValues[ i ];
				obj = (GraphicObject)m_colGraphObj[ nObjIndex ];

				switch (type)
				{
					case Spacing.Horizontal:
						nWidth = Math.Abs(obj.ptSource.X - obj.ptDestiny.X);
						obj.ptSource.X = (objRef.rect.X + objRef.rect.Width) + nAverageSpacing;
						obj.ptDestiny.X = obj.ptSource.X + nWidth;
						break;

					case Spacing.Vertical:
						if (i == (ilValues.Count - 1))
							break;
						nHeight = Math.Abs(obj.ptSource.Y - obj.ptDestiny.Y);
						obj.ptSource.Y = (objRef.rect.Y + objRef.rect.Height) + nAverageSpacing;
						obj.ptDestiny.Y = obj.ptSource.Y + nHeight;
						break;

					default:
						bRepaint = false;
						break;
				}
				obj.rect = BuildRect( ref obj.ptSource, ref obj.ptDestiny );
				nObjIndex = (int)ilValues[ i ];
				objRef = (GraphicObject)m_colGraphObj[ nObjIndex ];
			}

			m_rectSelection = BuildSelRect();
			if ( bRepaint )
				RepaintScreen();

			return( true );
		}

		public bool bSelectAll( bool bRepaint )
		{
			if ( m_colGraphObj.Count == 0 )
				return( false );

			m_colSelObjs.Clear();

			for ( int i = 0; i < m_colGraphObj.Count; i++ )
				m_colSelObjs.Add(i, i );

			m_rectSelection = BuildSelRect();

			if ( bRepaint )
				RepaintScreen();

			return( true );
		}

		public bool bMoveSelectedObjects(int nX,int nY)
		{
			if ( m_colSelObjs.Count <= 0 )
				return( false );

			int nIndex;
			ArrayList arlObjs = new ArrayList();
			IList ilValues;
			GraphicObject obj;

			ilValues = m_colSelObjs.GetValueList(); //gets the list iterator
			for ( int i = 0; i < ilValues.Count; i++ )
			{
				nIndex = (int)ilValues[i];
				obj = (GraphicObject)m_colGraphObj[nIndex];
				obj.ptSource.X += nX;
				obj.ptSource.Y += nY;
				obj.ptDestiny.X += nX;
				obj.ptDestiny.Y += nY;
				obj.rect = BuildRect( ref obj.ptSource, ref obj.ptDestiny );
			}
			m_rectSelection = BuildSelRect();
			GC.Collect(); // forces the deletion of the objects removed from the list
			RepaintScreen(); // redraws the remaining objects
			return( true );
		}

		public bool bAlignObjects( Alignment alignment, bool bRepaint )
		{
			if ( m_colSelObjs.Count < 2 )
				return( false );
		
			Rectangle rectRef;
			Point ptRef1, ptRef2;
			int nObjIndex, nOffsetX, nWidth, nXRef;
			GraphicObject obj;
            IList ilValues = m_colSelObjs.GetValueList();

			
			SaveObjectStatus();
			addUndoMoveResize( true );

			nObjIndex = (int)ilValues[ 0 ];
			obj = (GraphicObject)m_colGraphObj[ nObjIndex ];
			rectRef = obj.rect;
			ptRef1 = obj.ptSource;
			ptRef2 = obj.ptDestiny;
            nXRef = (obj.ptSource.X > obj.ptDestiny.X) ? obj.ptDestiny.X : obj.ptSource.X;

			for ( int i = 1; i < ilValues.Count; i++ )
			{
				nObjIndex = (int)ilValues[ i ];
				obj = (GraphicObject)m_colGraphObj[ nObjIndex ];
				nWidth = Math.Abs( obj.ptDestiny.X - obj.ptSource.X );
                
				switch (alignment)
				{
					case Alignment.Left:
						nOffsetX = obj.ptSource.X - nXRef;
						obj.ptSource.X -= nOffsetX;
						obj.ptDestiny.X = obj.ptSource.X + nWidth;
						break;

					case Alignment.Right:
						nOffsetX = obj.ptSource.X - (nXRef + rectRef.Width);
						obj.ptSource.X -= (nOffsetX + nWidth);
						obj.ptDestiny.X = obj.ptSource.X + nWidth;
						break;

					case Alignment.Center:
						nXRef = (nXRef + rectRef.Width) / 2;
						nOffsetX = obj.ptSource.X - nXRef;
						obj.ptSource.X -= nOffsetX;
						obj.ptDestiny.X = obj.ptSource.X + nWidth;
						break;

					default:
						break;
				}

				obj.rect = BuildRect( ref obj.ptSource, ref obj.ptDestiny );
			}

			m_rectSelection = BuildSelRect();
			if ( bRepaint )
				RepaintScreen();

			return( true );
		}

		public bool bIsPrinting()
		{
			return( m_bIsPrinting );
		}

		public bool bGetViewMode()
		{
			return( m_bViewMode );
		}

		public virtual void SetViewMode( bool bView )
		{
			bool bNeedRefresh = (bView != m_bViewMode);
			m_bViewMode = bView;

			if ( bNeedRefresh )
				RepaintScreen();
		}

		public void ClearSelection( bool bRepaint )
		{
			m_colSelObjs.Clear();
			m_rectSelection = BuildSelRect();
			if ( bRepaint )
				RepaintScreen();
		}

		public virtual void ClearData( bool bRepaint )
		{
			m_colSelObjs.Clear();
			m_colGraphObj.Clear();
			m_sortLstImages.Clear();
			m_arlObjGroups.Clear();
			GC.Collect();

			if ( bRepaint )
				RepaintScreen();
		}

		public bool bAddObject( ref GraphicObject obj, bool bSelectObject, bool bAddUndoEntry )
		{
			if ( nSearchObject(ref obj.strName) != -1 )
				return( false );


			obj.nIndex = m_colGraphObj.Add(obj);
			// forces the new added object to be selected
			obj.rect = BuildRect( ref obj.ptSource, ref obj.ptDestiny );

			m_colSelObjs.Clear();
			if ( bSelectObject )
			{
				m_rectSelection = obj.rect;
				m_colSelObjs.Add(obj.nIndex, obj.nIndex); // adds to the selection list
			} 
			else
			{
				m_rectSelection = BuildSelRect();
			}

			if ( bAddUndoEntry )
			{
				m_uosUndoStatus.insert.Clear(); // save the status of the operation
				m_uosUndoStatus.insert.grpObj = obj.Clone();
				addUndoInsert( true ); // adds an undo entry for this operation
			}
			m_nObjectIndexer++; // increments the object counter
			
			return( true );
		}

		public bool bMoveWindow( System.Windows.Forms.Keys key, ref bool CantMove )
		{
			switch ( key )
			{
				case Keys.NumPad4:
					if ( (m_rectWindow.Left - MOVE_STEP) >= (m_rectScreen.Left - (m_sizePage.Width * 2)) )
					{
						m_rectWindow.X -= MOVE_STEP;
						CantMove = false;
					}
					else
					{
						//m_rectWindow.X = m_rectScreen.Left;
						CantMove = true;
					}
					RepaintScreen();
					return( true );

				case Keys.NumPad8:
					if ( (m_rectWindow.Top - MOVE_STEP) >= (m_rectScreen.Top - m_sizePage.Height) )
					{
						m_rectWindow.Y -= MOVE_STEP;
						CantMove = false;
					}
					else
					{
						//m_rectWindow.Y = m_rectScreen.Top;
						CantMove = true;
					}
					RepaintScreen();
					return( true );

				case Keys.NumPad6:
					if ( (m_rectWindow.Left + m_rectWindow.Width + MOVE_STEP) <= (m_rectScreen.Left + m_rectWindow.Width/*m_rectScreen.Left*/ + (m_sizePage.Width * 2)) )
					{
						m_rectWindow.X += MOVE_STEP;
						CantMove = false;
					}
					else
					{
						//m_rectWindow.X = (m_rectScreen.Left + m_sizePage.Width) - m_rectWindow.Width;
						CantMove = true;
					}
					RepaintScreen();
					return( true );

				case Keys.NumPad2:
					if ( (m_rectWindow.Top + m_rectWindow.Height + MOVE_STEP) <= (m_rectScreen.Top + (m_sizePage.Height * 2)) )
					{
						m_rectWindow.Y += MOVE_STEP;
						CantMove = false;
					}
					else
					{
						//m_rectWindow.Y = (m_rectScreen.Top + m_sizePage.Height) - m_rectWindow.Height;
						CantMove = true;
					}
					RepaintScreen();
					return( true );

				default:
					return( false );
			}
		}

		public bool bMoveWindow(System.Drawing.Point ponto)
		{
			m_rectWindow.X = ponto.X;
			m_rectWindow.Y = ponto.Y;
			RepaintScreen();
			return (true);
		}

		public double dGetZoom()
		{
			return( m_dZoom );
		}

		public bool bMoreZoom()
		{
			if ( m_dZoom >= ZOOM_MAX )
				return( false ); // overflow of zooming

			//m_dZoom += ZOOM_STEP; // increases zoom
			m_dWindowScale -= ZOOM_STEP;
			m_rectWindow.Width = (int)((m_dWindowScale * (double)m_rectNormal.Width) / 100.0);
			m_rectWindow.Height = (int)((m_dWindowScale * (double)m_rectNormal.Height) / 100.0);

			double dNormalArea, dCurrArea;

			//m_rectWindow.Width -= (int)ZOOM_STEP;
			//m_rectWindow.Height -= (int)ZOOM_STEP;
			dNormalArea = m_rectNormal.Height * m_rectNormal.Width;
			dCurrArea = m_rectWindow.Height * m_rectWindow.Width;
			m_dZoom = (dNormalArea / dCurrArea) * 100;


			RepaintScreen();

			return( true );
		}

		public bool bDefaultZoom()
		{
			m_dWindowScale  = 100;
			m_rectWindow.Width = (int)((m_dWindowScale * (double)m_rectNormal.Width) / 100.0);
			m_rectWindow.Height = (int)((m_dWindowScale * (double)m_rectNormal.Height) / 100.0);
			double dNormalArea, dCurrArea;
			dNormalArea = m_rectNormal.Height * m_rectNormal.Width;
			dCurrArea = m_rectWindow.Height * m_rectWindow.Width;
			m_dZoom = 100;
			RepaintScreen();
			return( true );
		}

		public bool bLessZoom()
		{
			if ( m_dZoom <= ZOOM_MIN )
				return( false ); // underflow of zooming
			
			double dNormalArea, dCurrArea;

			//m_dZoom -= ZOOM_STEP; // decreases zoom
			m_dWindowScale += ZOOM_STEP;
			m_rectWindow.Width = (int)((m_dWindowScale * (double)m_rectNormal.Width) / 100.0);
			m_rectWindow.Height = (int)((m_dWindowScale * (double)m_rectNormal.Height) / 100.0);

			//m_rectWindow.Width += (int)ZOOM_STEP;
			//m_rectWindow.Height += (int)ZOOM_STEP;
			dNormalArea = m_rectNormal.Height * m_rectNormal.Width;
			dCurrArea = m_rectWindow.Height * m_rectWindow.Width;
			m_dZoom = (dNormalArea / dCurrArea) * 100;

			RepaintScreen();

			return( true );
		}

		/// <summary>
		/// bUndo:
		/// Undo the last operation.
		/// </summary>
		/// <returns>True if there is some operation to undo. Otherwise, returns false.</returns>
		public bool bUndo()
		{
			try
			{

				if ( m_stackUndo.Count == 0 )
					return( false );

				UndoMoveResize umUndo;
				UndoInsert uiUndo;
				UndoRemove urUndo;
				UndoOrder uoUndo;
				UndoAttribute uaUndo;
				UndoGroup ugUndo;

				UndoRedoObject urobjUndo = (UndoRedoObject)m_stackUndo.Pop();

				switch (urobjUndo.uoType)
				{
					case UndoOperation.MoveResize:
						umUndo = (UndoMoveResize)urobjUndo;
						UpdateObjectStatus( UndoOperation.MoveResize, ref umUndo.arlObjs );
						addRedoMoveResize();
						RestoreUndoMoveResize( ref umUndo );
						break;

					case UndoOperation.Insert:
						uiUndo = (UndoInsert)urobjUndo;
						m_uosUndoStatus.insert.Clear();
						m_uosUndoStatus.insert = uiUndo.Clone();
						addRedoInsert();
						RestoreUndoInsert( ref uiUndo );
						break;

					case UndoOperation.Remove:
						urUndo = (UndoRemove)urobjUndo;
						SaveUndoRemoveStatus( ref urUndo.arlgrpObjs);
						addRedoRemove();
						RestoreUndoRemove( ref urUndo );
						break;

					case UndoOperation.Order:
						uoUndo = (UndoOrder)urobjUndo;					
						SaveUndoOrderStatus( ref uoUndo.arlstrObjs );
						addRedoOrder();
						RestoreUndoOrder( ref uoUndo );
						break;

					case UndoOperation.ChangeAttribute:
						uaUndo = (UndoAttribute)urobjUndo;
						SaveUndoAttributeStatus( ref uaUndo.arlstrObjs, uaUndo.acType );
						addRedoAttribute();
						RestoreUndoAttribute( ref uaUndo );
						break;

					case UndoOperation.Group:
						ugUndo = (UndoGroup)urobjUndo;
						SaveUndoGroupStatus( ref ugUndo.arlstrGroupObjs, ref ugUndo.arlstrNotGroupedObjNames );
						addRedoGroup();
						RestoreUndoGroup( ref ugUndo );
						break;

					default:
						break;
				}

				return( true );
			}
			catch (System.Exception exc)
			{
				String strMsg = exc.Message;
				strMsg += "\nIf the error persists, contacts the support for this software.";
				System.Windows.Forms.MessageBox.Show( strMsg, "DrawingCanvas",
					System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error );
                return( false );
			}
		}

		/// <summary>
		/// bRedo:
		/// Redo the last operation.
		/// </summary>
		/// <returns>True if there is some operation to redo. Otherwise, returns false.</returns>
		public bool bRedo()
		{
			try 
			{

				if ( m_stackRedo.Count == 0 )
					return( false );

				UndoMoveResize umRedo;
				UndoInsert uiRedo;
				UndoRemove urRedo;
				UndoOrder uoRedo;
				UndoAttribute uaRedo;
				UndoGroup ugRedo;

				UndoRedoObject urobjRedo = (UndoRedoObject)m_stackRedo.Pop();

			
				switch (urobjRedo.uoType)
				{
					case UndoOperation.MoveResize:
						umRedo = (UndoMoveResize)urobjRedo;
						UpdateObjectStatus( UndoOperation.MoveResize, ref umRedo.arlObjs );
						addUndoMoveResize( false );
						RestoreUndoMoveResize( ref umRedo );
						break;

					case UndoOperation.Insert:
						uiRedo = (UndoInsert)urobjRedo;
						m_uosUndoStatus.insert.Clear();
						m_uosUndoStatus.insert = uiRedo.Clone();
						addUndoInsert( false );
						RestoreRedoInsert( ref uiRedo );
						break;

					case UndoOperation.Remove:
						urRedo = (UndoRemove)urobjRedo;
						SaveUndoRemoveStatus( ref urRedo.arlgrpObjs );
						addUndoRemove( false );
						RestoreRedoRemove( ref urRedo );
						break;

					case UndoOperation.Order:
						uoRedo = (UndoOrder)urobjRedo;
						SaveUndoOrderStatus( ref uoRedo.arlstrObjs );
						addUndoOrder( false );
						RestoreUndoOrder( ref uoRedo );//RestoreRedoOrder( ref uoRedo );
						break;

					case UndoOperation.ChangeAttribute:
						uaRedo = (UndoAttribute)urobjRedo;
						SaveUndoAttributeStatus( ref uaRedo.arlstrObjs, uaRedo.acType );
						addUndoAttribute( false );
						RestoreUndoAttribute( ref uaRedo ); //RestoreRedoAttribute( ref uaRedo );
						break;

					case UndoOperation.Group:
						ugRedo = (UndoGroup)urobjRedo;
						SaveUndoGroupStatus( ref ugRedo.arlstrGroupObjs, ref ugRedo.arlstrNotGroupedObjNames );
						addUndoGroup( false );
						RestoreUndoGroup( ref ugRedo );//RestoreRedoGroup( ref ugRedo );
						break;

					default:
						break;
				}

				return( true );
			}
			catch (System.Exception exc)
			{
				String strMsg = exc.Message;
				strMsg += "\nIf the error persists, contacts the support for this software.";
				System.Windows.Forms.MessageBox.Show( strMsg, "DrawingCanvas",
					System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error );
                return( false );
			}
		}

		/// <summary>
		/// bDeleteObj:
		/// Deletes the objects selected.
		/// </summary>
		/// <returns>True if there is at least one object selected. Otherwise, returns false.</returns>
		public bool bDeleteObj()
		{
			if ( m_colSelObjs.Count <= 0 )
				return( false );

			GraphicObject obj;
			int nGroupIndex, nIndex;
			ArrayList arlObjs = new ArrayList();
			IList ilValues;

			ilValues = m_colSelObjs.GetValueList(); //gets the list iterator
			nGroupIndex = ((GraphicObject)m_colGraphObj[ (int)ilValues[0] ]).nGroup; //gets the group of the object. If none, do nothing. Else, deletes the group from the group list.

			for ( int i = 0; i < ilValues.Count; i++ )
			{
				nIndex = (int)ilValues[i];
				obj = (GraphicObject)m_colGraphObj[nIndex];
				arlObjs.Add( obj );
			}

			SaveUndoRemoveStatus( ref arlObjs ); // saves the status for this object
			addUndoRemove( true ); // adds an undo entry for this operation

			for ( int i = 0; i < ilValues.Count; i++ )
			{
				nIndex = (int)ilValues[i];
				try
				{
					obj = (GraphicObject)m_colGraphObj[ nIndex ];
					if ( obj.nIndex < 0 )
						throw( new Exception("Object index cannot be less than zero") );
					m_colGraphObj.RemoveAt( obj.nIndex ); // removes from the list of objects
					UpdateDeletion( obj.nIndex );
				}catch{
				}
			}

			// deletes the group from the list
			if ( nGroupIndex >= 0 )
				DeleteObjGroup( nGroupIndex );

			m_colSelObjs.Clear(); // all objects selected were deleted
			GC.Collect(); // forces the deletion of the objects removed from the list

			RepaintScreen(); // redraws the remaining objects

			return( true );
		}


		/// <summary>
		/// bGroupObjects:
		/// Groups the selected objects.
		/// </summary>
		/// <returns>Returns false if there is no objects selected. Otherwise, returns true</returns>
		public bool bGroupObjects()
		{
			if  ( m_colSelObjs.Count <= 1 )
				return( false );

			GraphicObject obj;
			ArrayList arlNewGroup = new ArrayList();
			ArrayList arlGroupsToDelete = new ArrayList(); //indexes of the undone groups inside the new group
			ArrayList arlstrObj = new ArrayList();
			int nNextGroup;
			IList ilValues = m_colSelObjs.GetValueList();

			for ( int i = 0; i < ilValues.Count; i++ )
			{
				String strObjName = ((GraphicObject)m_colGraphObj[(int)ilValues[i]]).strName;
				arlstrObj.Add( strObjName );
			}
			SaveUndoGroupStatus( ref arlstrObj );
			addUndoGroup( true );

			nNextGroup = m_arlObjGroups.Count; //gets the next index for a new group
			for ( int i = 0; i < ilValues.Count; i++ )
			{
				obj = (GraphicObject)m_colGraphObj[ (int)ilValues[i] ];
				// if obj is already grouped then adds the index of the groups inside arlGroupsToDelete for later exclusion
				if ( (obj.nGroup >= 0) && !arlGroupsToDelete.Contains(obj.nGroup) )
					arlGroupsToDelete.Add( obj.nGroup );
				obj.nGroup = nNextGroup; // sets the index of the new group
				arlNewGroup.Add( obj.nIndex ); // adds the index of the object to the group
			}

			// adds the group to the system
			m_arlObjGroups.Add( arlNewGroup );

			// now deletes the undone groups
			for ( int i = 0; i < arlGroupsToDelete.Count; i++ )
				DeleteObjGroup( (int)arlGroupsToDelete[i] );

			return( true );
		}

		/// <summary>
		/// bUngroupObjects:
		/// Ungroups the selected group.
		/// </summary>
		/// <returns>Returns false if there is no groups (or object) selected. Otherwise, returns true</returns>
		public bool bUngroupObjects()
		{
			if  ( m_colSelObjs.Count <= 1 )
				return( false );

			GraphicObject obj;
			ArrayList arlGroup;
			int nGroupIndex;
			ArrayList arlstrObj = new ArrayList();
			IList ilValues = m_colSelObjs.GetValueList();

			for ( int i = 0; i < ilValues.Count; i++ )
			{
				String strObjName = ((GraphicObject)m_colGraphObj[(int)ilValues[i]]).strName;
				arlstrObj.Add( strObjName );
			}
			SaveUndoGroupStatus( ref arlstrObj );
			addUndoGroup( true );

			nGroupIndex = ((GraphicObject)m_colGraphObj[ (int)ilValues[0] ]).nGroup; // gets the index of the group
			if (nGroupIndex != -1)
			{
				arlGroup = (ArrayList)m_arlObjGroups[ nGroupIndex ];
				for ( int i = 0; i < arlGroup.Count; i++ )
				{
					obj = (GraphicObject)m_colGraphObj[ (int)arlGroup[i] ];
					obj.nGroup = -1; // unsets the group
				}
				// deletes the group from the list
				DeleteObjGroup( nGroupIndex );
			}
			return( true );
		}

		/// <summary>
		/// nSelectionSize:
		/// Returns the number of selected items.
		/// </summary>
		/// <returns>The number of selected objects</returns>
		public int nSelectionSize()
		{
			return( m_colSelObjs.Count );
		}

		#endregion
		#region Métodos Auxiliares
		protected void setPrinting( bool bPrinting )
		{
			m_bIsPrinting = bPrinting;
		}

		protected void setIsCreatingPDF(bool bIsCreatingPDF)
		{
			m_bIsCreatingPDF = bIsCreatingPDF;
			setPrinting(bIsCreatingPDF);
		}

		protected void UpdateCharsWidth( IntPtr hDC, ref Font fntText )
		{
			char chStart, chEnd;
			
			chStart = (char)FIRST_CHAR;
			chEnd = (char)LAST_CHAR;

			if ( m_fntLastUsed == null )
				m_fntLastUsed = fntText;
			else if ( m_fntLastUsed.Equals(fntText) )
				return;
			Win32Support.GetCharWidth32(hDC, chStart, chEnd, m_nCharsWidth );
		}

		protected int nCharSize( char ch )
		{
			if ( ch > LAST_CHAR )
				ch = 'x'; // x is used by windows for calculating the average width of a char
			return( m_nCharsWidth[ch - FIRST_CHAR] );
		}

		protected void UpdateHighlightColors( Color clrNew )
		{
			Color clr;
			int nColor;

			m_clrHighlight[ 0 ] = clrNew;
			for ( int i = 1; i < MAX_HIGHLIGHT_COLORS; i++ )
			{		
				nColor = clrNew.ToArgb();
				nColor = nColor / (i + 1);
				clr = Color.FromArgb( nColor );
				m_clrHighlight[ i ] = clr;
			}
		}

		protected int nAddImage( ref Image img )
		{
			int nImageIndex = 1;
			while (m_sortLstImages.ContainsKey(nImageIndex))
			{
				nImageIndex++;
			}
			m_sortLstImages.Add(nImageIndex,img);
			return( nImageIndex );
		}

		#region "Zoom/Screen mapping methods"

		protected Rectangle rectWorld2Screen( ref Rectangle rect )
		{
			Rectangle rectTemp = new Rectangle( 0, 0, 0, 0 );
			Point ptTemp = new Point(0, 0);

			ptTemp.X = rect.X; 
			ptTemp.Y = rect.Y;
			ptWorld2Screen( ref ptTemp );
			rectTemp.X = ptTemp.X;
			rectTemp.Y = ptTemp.Y;

			ptTemp.X = (rect.X + rect.Width);
			ptTemp.Y = (rect.Y + rect.Height);
			ptWorld2Screen( ref ptTemp );
			rectTemp.Width = (ptTemp.X - rectTemp.X);
			rectTemp.Height = (ptTemp.Y - rectTemp.Y);

			rect = rectTemp;
			return( rect );
		}

		protected Rectangle rectScreen2World( ref Rectangle rect )
		{
			Rectangle rectTemp = new Rectangle( 0, 0, 0, 0 );
			Point ptTemp = new Point(0, 0);

			ptTemp.X = rect.X; 
			ptTemp.Y = rect.Y;
			ptScreen2World( ref ptTemp );
			rectTemp.X = ptTemp.X;
			rectTemp.Y = ptTemp.Y;

			ptTemp.X = (rect.X + rect.Width);
			ptTemp.Y = (rect.Y + rect.Height);
			ptScreen2World( ref ptTemp );
			rectTemp.Width = (ptTemp.X - rectTemp.X);
			rectTemp.Height = (ptTemp.Y - rectTemp.Y);

			rect = rectTemp;
			return( rect );
		}

		protected Point ptWorld2Screen( ref Point pt )
		{
			pt.X = X_World2Screen( pt.X );
			pt.Y = Y_World2Screen( pt.Y );
			return( pt );
		}

		protected Point ptScreen2World( ref Point pt )
		{
			pt.X = X_Screen2World( pt.X );
			pt.Y = Y_Screen2World( pt.Y );
			return( pt );
		}

		/// <summary>
		/// X_World2Screen:
		/// Maps a point from the world to the drawing screen.
		/// </summary>
		/// <param name="x"></param>
		/// <returns>The mapped point to the screen</returns>
		protected int X_World2Screen( int x )
		{
			double x_line, a, b;

			a = m_rectScreen.Width / (double)m_rectWindow.Width;
			b = m_rectScreen.X - (a * m_rectWindow.Left);
			x_line = (a * (double)x) + b;
			return( (int)x_line );
		}

		/// <summary>
		/// X_Screen2World:
		/// Maps a point from the screen to the world.
		/// </summary>
		/// <param name="x_line"></param>
		/// <returns>The mapped point to the world.</returns>
		protected int X_Screen2World( int x_line )
		{
			double x, a, b;

			a = m_rectScreen.Width / (double)m_rectWindow.Width;
			b = m_rectScreen.X - (a * m_rectWindow.Left);
			x = ((double)x_line - b) / a;
			if (m_bUseMargin)
				x = x - m_nLeftMargin;
			return( (int)x );
		}

		/// <summary>
		/// Y_World2Screen:
		/// Maps a point from the world to the drawing screen.
		/// </summary>
		/// <param name="y"></param>
		/// <returns>The mapped point to the screen</returns>
		protected int Y_World2Screen( int y )
		{
			double y_line, c, d;

			c = m_rectScreen.Height / (double)m_rectWindow.Height;
			d = m_rectScreen.Y - (c * m_rectWindow.Y);
			y_line = (c * (double)y) + d;
			return( (int)y_line );
		}

		/// <summary>
		/// Y_Screen2World:
		/// Maps a point from the screen to the world.
		/// </summary>
		/// <param name="y_line"></param>
		/// <returns>The mapped point to the world.</returns>
		protected int Y_Screen2World( int y_line )
		{
			double y, c, d;

			c = m_rectScreen.Height / (double)m_rectWindow.Height;
			d = m_rectScreen.Y - (c * m_rectWindow.Y);
			y = ((double)y_line - d) / c;
			if (m_bUseMargin)
				y = y - m_nTopMargin;
			return( (int)y );
		}

		#endregion

		protected void UpdateObjectStatus( UndoOperation oper, ref ArrayList arlObjects )
		{
			int nIndex;
			GraphicObject obj;

			switch( oper )
			{
				case UndoOperation.MoveResize:
					m_uosUndoStatus.move.Clear();
					//m_uosUndoStatus.move.arlPrevPt1.Clear();
					//m_uosUndoStatus.move.arlPrevPt2.Clear();
					for ( int i = 0; i < arlObjects.Count; i++ )
					{
						nIndex = (int)arlObjects[ i ];
						//DEBUG
						if ( (nIndex < 0) || (nIndex >= m_colGraphObj.Count) )
							continue;
						obj = (GraphicObject)m_colGraphObj[ nIndex ];
						if ( ((i > arlObjects.Count) || (i > m_uosUndoStatus.move.arlObjs.Count))
							|| (i < 0) )
							continue;
						//m_uosUndoStatus.move.arlObjs[ i ] = arlObjects[ i ];
						m_uosUndoStatus.move.arlObjs.Add( arlObjects[ i ] );
						m_uosUndoStatus.move.arlPrevPt1.Add( obj.ptSource );
						m_uosUndoStatus.move.arlPrevPt2.Add( obj.ptDestiny );
					}
					break;

				default:
					break;
			}
		}

		protected void SaveObjectStatus()
		{
			int nObjIndex;
			GraphicObject obj;
			IList ilValues = m_colSelObjs.GetValueList();

			// clear previous stored values
			m_uosUndoStatus.move.Clear();

			for ( int i = 0; i< ilValues.Count; i++ )
			{
				nObjIndex = (int)ilValues[ i ];
				obj = (GraphicObject)m_colGraphObj[ nObjIndex ];
				m_uosUndoStatus.move.arlObjs.Add( obj.nIndex );
				m_uosUndoStatus.move.arlPrevPt1.Add( obj.ptSource );
				m_uosUndoStatus.move.arlPrevPt2.Add( obj.ptDestiny );
			}
		}

		#region "Undo/redo group methods"


		/// <summary>
		/// RestoreUndoGroup:
		/// Restores the previous state before a group operation.
		/// </summary>
		/// <param name="ugUndo"></param>
		protected void RestoreUndoGroup( ref UndoGroup ugUndo )
		{
			GraphicObject obj;
			int nObjIndex, nGroupIndex;
			String strObjName;
			ArrayList currGroup;

			// deletes the group
			if ( ugUndo.arlstrNotGroupedObjNames.Count > 0 )
			{
				strObjName = (String)ugUndo.arlstrNotGroupedObjNames[ 0 ];
				nObjIndex = nSearchObject( ref strObjName );
				obj = (GraphicObject)m_colGraphObj[ nObjIndex ];
				DeleteObjGroup( obj.nGroup );

				// resets the objects group to -1 (no group)
				for ( int i = 0; i < ugUndo.arlstrNotGroupedObjNames.Count; i++ )
				{
					strObjName = (String)ugUndo.arlstrNotGroupedObjNames[ i ];
					nObjIndex = nSearchObject( ref strObjName );
					obj = (GraphicObject)m_colGraphObj[ nObjIndex ];
					obj.nGroup = -1;
				}
			}

			ArrayList arlIndexObjGroup = new ArrayList();
			for ( int i = 0; i < ugUndo.arlstrGroupObjs.Count; i++ )
			{
				currGroup = (ArrayList)ugUndo.arlstrGroupObjs[ i ];
				nGroupIndex = m_arlObjGroups.Count;
				for ( int j = 0; j < currGroup.Count; j++ )
				{
					strObjName = (String)currGroup[ j ];
					nObjIndex = nSearchObject( ref strObjName );
					obj = (GraphicObject)m_colGraphObj[ nObjIndex ];
					obj.nGroup = nGroupIndex;
					arlIndexObjGroup.Add( obj.nIndex );
				}
				m_arlObjGroups.Add( arlIndexObjGroup );
			}

			m_rectSelection = BuildSelRect();
			RepaintScreen();
		}

		/// <summary>
		/// SaveUndoGroupStatus:
		/// Saves the status before grouping some objects
		/// </summary>
		/// <param name="arlstrGroups"></param>
		/// <param name="arlstrNotGroupedObj"></param>
		protected void SaveUndoGroupStatus( ref ArrayList arlstrObjNames )
		{
			GraphicObject obj;
			int nObjIndex, nIndex;
			String strObjName;
			ArrayList arlGroupsNames, arlGroupsIndex = new ArrayList(); // index of groups found inside arlstrObjNames

			m_uosUndoStatus.group.Clear();
			for ( int i = 0; i < arlstrObjNames.Count; i++ )
			{
				strObjName = (String)arlstrObjNames[ i ];
				nObjIndex = nSearchObject( ref strObjName );
				if ( nObjIndex < 0 )
					continue;
				obj = (GraphicObject)m_colGraphObj[ nObjIndex ];
				if ( obj.nGroup >= 0 )
				{
					if ( arlGroupsIndex.Contains(obj.nGroup) )
						nIndex = arlGroupsIndex.IndexOf(obj.nGroup);
					else
					{
						nIndex = arlGroupsIndex.Add( obj.nGroup );
						m_uosUndoStatus.group.arlstrGroupObjs.Add( new ArrayList() );
					}
					arlGroupsNames = (ArrayList)m_uosUndoStatus.group.arlstrGroupObjs[ nIndex ];
					arlGroupsNames.Add( obj.strName );
					
				}
				else
					m_uosUndoStatus.group.arlstrNotGroupedObjNames.Add( obj.strName );
			}
		}

		protected void SaveUndoGroupStatus( ref ArrayList arlstrGroups, ref ArrayList arlstrNotGroupedObjs )
		{
			ArrayList arlTemp;
			ArrayList arlstrObjs = new ArrayList();

			for ( int i = 0; i < m_uosUndoStatus.group.arlstrGroupObjs.Count; i++ )
			{
				arlTemp = (ArrayList)m_uosUndoStatus.group.arlstrGroupObjs[ i ];
				for ( int j = 0; j < arlTemp.Count; j++ )
					arlstrObjs.Add( (String)arlTemp[j]  );
			}

			for ( int i = 0; i < m_uosUndoStatus.group.arlstrNotGroupedObjNames.Count; i++ )
				arlstrObjs.Add( m_uosUndoStatus.group.arlstrNotGroupedObjNames[ i ] );

			SaveUndoGroupStatus( ref arlstrObjs );
		}

		/// <summary>
		/// addRedoGroup:
		/// Creates a redo entry for a group operation
		/// </summary>
		protected void addRedoGroup()
		{
			if ( m_stackRedo.Count >= UNDO_LIMIT )
				RemoveFirstRedo();

			m_stackRedo.Push( m_uosUndoStatus.group.Clone() );
		}

		/// <summary>
		/// addUndoGroup:
		/// Creates an undo entry for a group operation
		/// </summary>
		/// <param name="bNewUndo"></param>
		protected void addUndoGroup( bool bNewUndo )
		{
			if ( m_stackUndo.Count >= UNDO_LIMIT )
				RemoveFirstUndo();

			if ( bNewUndo )
				CleanRedo();

			m_stackUndo.Push( m_uosUndoStatus.group.Clone() );
		}

		
		#endregion

		#region "Undo/Redo attribute methods"

		/// <summary>
		/// SaveUndoAttributeStatus:
		/// Saves the status of objects before changing an attribute
		/// </summary>
		/// <param name="arlstrObjs"></param>
		protected void SaveUndoAttributeStatus( ref ArrayList arlstrObjNames, AttributeChanged acAttribute )
		{
			String strObjName;
			int nObjIndex;
			GraphicObject obj;

			m_uosUndoStatus.attribute.Clear(); //clear the status
			m_uosUndoStatus.attribute.acType = acAttribute; //set the type of the attribute

			//for all objects selected save the status of current attribute
			for ( int i = 0; i < arlstrObjNames.Count; i++ )
			{
				strObjName = (String)arlstrObjNames[ i ];
				nObjIndex = nSearchObject( ref strObjName );
				obj = (GraphicObject)m_colGraphObj[ nObjIndex ];
				m_uosUndoStatus.attribute.arlstrObjs.Add( obj.strName );

				switch (acAttribute)
				{
					case AttributeChanged.BackgroundColor:
						if (obj.nType == Tool.Circle)
						{
							CircleObject objCirc = (CircleObject)obj;
							m_uosUndoStatus.attribute.arlAttributes.Add( objCirc.clrBack );
						}
						else if (obj.nType == Tool.Rectangle)
						{
							RectangleObject objRect = (RectangleObject)obj;
							m_uosUndoStatus.attribute.arlAttributes.Add( objRect.clrBack );
						}						
						break;

					case AttributeChanged.Font:
						if ( obj.nType == Tool.Text )
						{
							TextObject objText = (TextObject)obj;
							FontStyle fs = new FontStyle();
							if ( objText.fntText.Bold )
								fs = fs | FontStyle.Bold;
							if ( objText.fntText.Italic)
								fs = fs | FontStyle.Italic;
							if ( objText.fntText.Strikeout)
								fs = fs | FontStyle.Strikeout;
							if ( objText.fntText.Underline)
								fs = fs | FontStyle.Underline;
							System.Drawing.Font fntText = new System.Drawing.Font(objText.fntText.FontFamily,(int)objText.fntText.Size,fs);
							m_uosUndoStatus.attribute.arlAttributes.Add(fntText);
						}
						break;

					case AttributeChanged.LineStyle:
						if ( obj.nType == Tool.Line )
						{
							LineObject objLine = (LineObject)obj;
							m_uosUndoStatus.attribute.arlAttributes.Add( objLine.nLineStyle );
						}
						break;

					case AttributeChanged.PenColor:
						if ( obj.nType == Tool.Line )
						{
							LineObject objLine = (LineObject)obj;
							m_uosUndoStatus.attribute.arlAttributes.Add( objLine.clrPen );
						} 
						else if ( obj.nType == Tool.Rectangle )
						{
							RectangleObject objRect = (RectangleObject)obj;
							m_uosUndoStatus.attribute.arlAttributes.Add( objRect.clrPen );
						} 
						else if ( obj.nType == Tool.Circle )
						{
							CircleObject objCirc = (CircleObject)obj;
							m_uosUndoStatus.attribute.arlAttributes.Add( objCirc.clrPen );
						}
						break;

					case AttributeChanged.PenStyle:
						if ( obj.nType == Tool.Line )
						{
							LineObject objLine = (LineObject)obj;
							m_uosUndoStatus.attribute.arlAttributes.Add( objLine.nPenStyle );
						} 
						else if ( obj.nType == Tool.Rectangle )
						{
							RectangleObject objRect = (RectangleObject)obj;
							m_uosUndoStatus.attribute.arlAttributes.Add( objRect.nPenStyle );
						} 
						else if ( obj.nType == Tool.Circle )
						{
							CircleObject objCirc = (CircleObject)obj;
							m_uosUndoStatus.attribute.arlAttributes.Add( objCirc.nPenStyle );
						}
						break;

					case AttributeChanged.PenWidth:
						if ( obj.nType == Tool.Line )
						{
							LineObject objLine = (LineObject)obj;
							m_uosUndoStatus.attribute.arlAttributes.Add( objLine.nPenWidth );
						} 
						else if ( obj.nType == Tool.Rectangle )
						{
							RectangleObject objRect = (RectangleObject)obj;
							m_uosUndoStatus.attribute.arlAttributes.Add( objRect.nPenWidth );
						} 
						else if ( obj.nType == Tool.Circle )
						{
							CircleObject objCirc = (CircleObject)obj;
							m_uosUndoStatus.attribute.arlAttributes.Add( objCirc.nPenWidth );
						}
						break;

					case AttributeChanged.OpaqueBkg:
						if ( obj.nType == Tool.Circle )
						{
							CircleObject objCirc = (CircleObject)obj;
							m_uosUndoStatus.attribute.arlAttributes.Add( objCirc.bOpaque );
						} 
						else if ( obj.nType == Tool.Rectangle )
						{
							RectangleObject objRect = (RectangleObject)obj;
							m_uosUndoStatus.attribute.arlAttributes.Add( objRect.bOpaque );
						}
						break;

					default:
						break;
				}
			}            
		}

		/// <summary>
		/// RestoreUndoAttribute:
		/// Restores the previous state of the attributes
		/// </summary>
		protected void RestoreUndoAttribute( ref UndoAttribute uaUndo )
		{
			String strObjName;
			int nObjIndex;
			GraphicObject obj;

			for ( int i = 0; i < uaUndo.arlstrObjs.Count; i++ )
			{
				strObjName = (String)uaUndo.arlstrObjs[ i ];
				nObjIndex = nSearchObject( ref strObjName );
				obj = (GraphicObject)m_colGraphObj[ nObjIndex ];

				switch (uaUndo.acType)
				{
					case AttributeChanged.BackgroundColor:
						if ( obj.nType == Tool.Rectangle )
						{
							RectangleObject objRect = (RectangleObject)obj;
							objRect.clrBack = (Color)uaUndo.arlAttributes[ i ];
						} 
						else if ( obj.nType == Tool.Circle )
						{
							CircleObject objCirc = (CircleObject)obj;
							objCirc.clrBack = (Color)uaUndo.arlAttributes[ i ];
						} 
						break;

					case AttributeChanged.Font:
						if ( obj.nType == Tool.Text )
						{
							TextObject txtObj = (TextObject)obj;
							txtObj.fntText = (Font)uaUndo.arlAttributes[ i ];
						}
						break;

					case AttributeChanged.LineStyle:
						if ( obj.nType == Tool.Line )
						{
							LineObject objLine = (LineObject)obj;
							objLine.nLineStyle = (LineStyle)uaUndo.arlAttributes[ i ];
						}
						break;

					case AttributeChanged.PenColor:
						if ( obj.nType == Tool.Line )
						{
							LineObject objLine = (LineObject)obj;
							objLine.clrPen = (Color)uaUndo.arlAttributes[ i ];
						} 
						else if ( obj.nType == Tool.Rectangle )
						{
							RectangleObject objRect = (RectangleObject)obj;
							objRect.clrPen = (Color)uaUndo.arlAttributes[ i ];
						} 
						else if ( obj.nType == Tool.Circle )
						{
							CircleObject objCirc = (CircleObject)obj;
							objCirc.clrPen = (Color)uaUndo.arlAttributes[ i ];
						}
						break;

					case AttributeChanged.PenStyle:
						if ( obj.nType == Tool.Line )
						{
							LineObject objLine = (LineObject)obj;
							objLine.nPenStyle = (DashStyle)uaUndo.arlAttributes[ i ];
						} 
						else if ( obj.nType == Tool.Rectangle )
						{
							RectangleObject objRect = (RectangleObject)obj;
							objRect.nPenStyle = (DashStyle)uaUndo.arlAttributes[ i ];
						} 
						else if ( obj.nType == Tool.Circle )
						{
							CircleObject objCirc = (CircleObject)obj;
							objCirc.nPenStyle = (DashStyle)uaUndo.arlAttributes[ i ];
						}
						break;

					case AttributeChanged.PenWidth:
						if ( obj.nType == Tool.Line )
						{
							LineObject objLine = (LineObject)obj;
							objLine.nPenWidth = (int)uaUndo.arlAttributes[ i ];
						} 
						else if ( obj.nType == Tool.Rectangle )
						{
							RectangleObject objRect = (RectangleObject)obj;
							objRect.nPenWidth = (int)uaUndo.arlAttributes[ i ];
						} 
						else if ( obj.nType == Tool.Circle )
						{
							CircleObject objCirc = (CircleObject)obj;
							objCirc.nPenWidth = (int)uaUndo.arlAttributes[ i ];
						}
						break;

					case AttributeChanged.OpaqueBkg:
						if ( obj.nType == Tool.Rectangle )
						{
							RectangleObject objRect = (RectangleObject)obj;
							objRect.bOpaque = (bool)uaUndo.arlAttributes[ i ];
						} 
						else if ( obj.nType == Tool.Circle )
						{
							CircleObject objCirc = (CircleObject)obj;
							objCirc.bOpaque = (bool)uaUndo.arlAttributes[ i ];
						}
						break;

					default:
						break;
				}

			}

			m_rectSelection = BuildSelRect();
			RepaintScreen();
		}

		/// <summary>
		/// addUndoRedoAttributeEntry:
		/// Adds an entry for an undo/redo operation
		/// </summary>
		/// <param name="?"></param>
		/// <param name="?"></param>
		protected void addUndoRedoAttributeEntry( ref IList ilValues, AttributeChanged acAttribute )
		{
			int nIndex;
			ArrayList arlstrObjNames = new ArrayList();


			for ( int i = 0; i < ilValues.Count; i++ )
			{
				nIndex = (int)ilValues[ i ];
				arlstrObjNames.Add( ((GraphicObject)m_colGraphObj[nIndex]).strName );
			}
			SaveUndoAttributeStatus( ref arlstrObjNames, acAttribute );
			addUndoAttribute( true );
		}

		/// <summary>
		/// addUndoAttribute:
		/// Creates an undo operation when changing an attribute
		/// </summary>
		protected void addUndoAttribute( bool bNewUndo )
		{
			if ( m_stackUndo.Count >= UNDO_LIMIT )
				RemoveFirstUndo();

			if ( bNewUndo )
				CleanRedo();
			m_stackUndo.Push( m_uosUndoStatus.attribute.Clone() );
		}

		/// <summary>
		/// addRedoAttribute:
		/// Creates a redo operation when changing an attribute
		/// </summary>
		protected void addRedoAttribute()
		{
			if ( m_stackRedo.Count >= UNDO_LIMIT )
				RemoveFirstRedo();

			m_stackRedo.Push( m_uosUndoStatus.attribute.Clone() );
		}

		#endregion

		#region "Undo/Redo order methods"

		/// <summary>
		/// SaveUndoOrderStatus:
		/// Saves the status of the object with changed order.
		/// </summary>
		protected void SaveUndoOrderStatus( ref ArrayList arlstrObjNames )
		{
		}

		protected void addUndoRedoOrderEntry( ref IList ilValues )
		{
			int nIndex;
			ArrayList arlstrObjNames = new ArrayList();


			for ( int i = 0; i < m_colSelObjs.Count; i++ )
			{
				nIndex = (int)ilValues[ i ];
				arlstrObjNames.Add( ((GraphicObject)m_colGraphObj[nIndex]).strName );
			}
			SaveUndoOrderStatus( ref arlstrObjNames );
			addUndoOrder( true );
		}

		/// <summary>
		/// addUndoOrder:
		/// Createa an undo operation of change the order of objects.
		/// </summary>
		protected void addUndoOrder( bool bNewUndo )
		{
			if ( m_stackUndo.Count >= UNDO_LIMIT )
				RemoveFirstUndo();

			if ( bNewUndo )
				CleanRedo();
			m_stackUndo.Push( m_uosUndoStatus.order.Clone() );
		}

		/// <summary>
		/// addRedoOrder:
		/// Createa a redo operation of change the order of objects.
		/// </summary>
		protected void addRedoOrder()
		{
			if ( m_stackRedo.Count >= UNDO_LIMIT )
				RemoveFirstRedo();

			m_stackRedo.Push( m_uosUndoStatus.order.Clone() );
		}

		/// <summary>
		/// RestoreUndoOrder:
		/// Restores an undo order operation.
		/// </summary>
		/// <param name="uoUndo"></param>
		protected void RestoreUndoOrder( ref UndoOrder uoUndo )
		{
			m_rectSelection = BuildSelRect();
			RepaintScreen();
		}

		/*protected void RestoreRedoOrder( ref UndoOrder uoRedo )
		{
		}*/

		#endregion

		#region "Undo/Redo remove methods"

		/// <summary>
		/// SaveUndoRemoveStatus:
		/// Saves the status of the removed object.
		/// </summary>
		protected void SaveUndoRemoveStatus( ref ArrayList arlgrpObjs )
		{
			GraphicObject obj;

			m_uosUndoStatus.remove.Clear(); 
			// save the status of the operation
			for ( int i = 0; i < arlgrpObjs.Count; i++ )
			{
				obj = (GraphicObject)arlgrpObjs[ i ];
				m_uosUndoStatus.remove.arlgrpObjs.Add( obj.Clone() );
			}
		}

		/// <summary>
		/// addUndoRemove:
		/// Createa an undo operation of removeing an object.
		/// </summary>
		protected void addUndoRemove( bool bNewUndo )
		{
			if ( m_stackUndo.Count >= UNDO_LIMIT )
				RemoveFirstUndo();

			if ( bNewUndo )
				CleanRedo();
			m_stackUndo.Push( m_uosUndoStatus.remove.Clone() );
		}

		/// <summary>
		/// addRedoRemove:
		/// Createa an redo operation of removeing an object.
		/// </summary>
		protected void addRedoRemove()
		{
			if ( m_stackRedo.Count >= UNDO_LIMIT )
				RemoveFirstRedo();

			m_stackRedo.Push( m_uosUndoStatus.remove.Clone() );
		}
		
		/// <summary>
		/// RestoreUndoRemove:
		/// Undo a remove operation.
		/// </summary>
		/// <param name="urUndo"></param>
		protected void RestoreUndoRemove( ref UndoRemove urUndo )
		{
			GraphicObject obj;

			for ( int i = 0; i < urUndo.arlgrpObjs.Count; i++ )
			{
				obj = ((GraphicObject)urUndo.arlgrpObjs[i]).Clone();
				obj.nIndex = m_colGraphObj.Add( obj );
				m_colSelObjs.Clear();
			}

			m_rectSelection = BuildSelRect();
			RepaintScreen();
		}

		/// <summary>
		/// RestoreRedoRemove:
		/// Redo a remove operation.
		/// </summary>
		/// <param name="urRedo"></param>
		protected void RestoreRedoRemove( ref UndoRemove urRedo )
		{
			GraphicObject obj;
			int nObjIndex;

			for ( int i = 0; i < urRedo.arlgrpObjs.Count; i++ )
			{
				obj = (GraphicObject)urRedo.arlgrpObjs[ i ];
				nObjIndex = nSearchObject( ref obj.strName );

				if ( nObjIndex != -1 )
				{
					m_colGraphObj.RemoveAt( nObjIndex ); // removes from the list of objects
					UpdateDeletion( nObjIndex );

					if ( ((IList)m_colSelObjs.GetValueList()).Contains( nObjIndex ) )
						m_colSelObjs.Clear();

					m_rectSelection = BuildSelRect();
					RepaintScreen();
				} 
				else
					throw( new Exception("An error has ocurred while attemping to redo a deletion of an object.\nObject not found.") );
			}
		}

		#endregion

		#region "Undo/Redo insert methods"
		/// <summary>
		/// addUndoInsert:
		/// Createa an undo operation of adding an object.
		/// </summary>
		protected void addUndoInsert( bool bNewUndo )
		{
			if ( m_stackUndo.Count >= UNDO_LIMIT )
				RemoveFirstUndo();

			if ( bNewUndo )
				CleanRedo();

			m_stackUndo.Push( m_uosUndoStatus.insert.Clone() );
		}

		/// <summary>
		/// addRedoInsert:
		/// Createa an redo operation of adding an object.
		/// </summary>
		protected void addRedoInsert()
		{
			if ( m_stackRedo.Count >= UNDO_LIMIT )
				RemoveFirstRedo();

			m_stackRedo.Push( m_uosUndoStatus.insert.Clone() );
		}

		/// <summary>
		/// RestoreUndoInsert:
		/// Undo an insert operation.
		/// </summary>
		/// <param name="uiUndo"></param>
		protected void RestoreUndoInsert( ref UndoInsert uiUndo )
		{			
			m_colGraphObj.RemoveAt( uiUndo.grpObj.nIndex ); // removes from the list of objects
			UpdateDeletion( uiUndo.grpObj.nIndex );

			if ( ((IList)m_colSelObjs.GetValueList()).Contains( uiUndo.grpObj.nIndex ) )
				m_colSelObjs.Clear();

			m_rectSelection = BuildSelRect();
			RepaintScreen();
		}

		/// <summary>
		/// RestoreRedoInsert:
		/// Redo an insert operation.
		/// </summary>
		/// <param name="uiUndo"></param>
		protected void RestoreRedoInsert( ref UndoInsert uiRedo )
		{
			GraphicObject obj = uiRedo.grpObj.Clone();

			obj.nIndex = m_colGraphObj.Add( obj );

			if ( ((IList)m_colSelObjs.GetValueList()).Contains( uiRedo.nZIndex ) )
				m_colSelObjs.Clear();

			m_rectSelection = BuildSelRect();
			RepaintScreen();
		}
		#endregion


		#region "Undo/Redo move and resize methods"
		/// <summary>
		/// RestoreUndoMoveResize:
		/// Undo a move operation.
		/// </summary>
		protected void RestoreUndoMoveResize( ref UndoMoveResize umUndo )
		{
			int nObjIndex;
			GraphicObject obj;
			Point ptSrc, ptDst;

			// restores the previous position for each object in umUndo.arlObjs
			for ( int i = 0; i < umUndo.arlObjs.Count; i++ )
			{
				nObjIndex = (int)umUndo.arlObjs[ i ];
				ptSrc = (Point)umUndo.arlPrevPt1[ i ];
				ptDst = (Point)umUndo.arlPrevPt2[ i ];
				obj = (GraphicObject)m_colGraphObj[ nObjIndex ];
				obj.ptSource = ptSrc;
				obj.ptDestiny = ptDst;
				obj.rect = BuildRect( ref ptSrc, ref ptDst );
			}

			m_rectSelection = BuildSelRect();
			RepaintScreen();
		}

		/// <summary>
		/// addUndoMoveResize:
		/// Createa an undo operation from the selected objects for the move or resize operation 
		/// </summary>
		protected void addUndoMoveResize( bool bNewUndo )
		{
			if ( m_stackUndo.Count >= UNDO_LIMIT )
				RemoveFirstUndo();

			if ( bNewUndo )
				CleanRedo();
			m_stackUndo.Push( m_uosUndoStatus.move.Clone() );
		}

		
		protected void addRedoMoveResize()
		{
			if ( m_stackRedo.Count >= UNDO_LIMIT )
				RemoveFirstRedo();

			m_stackRedo.Push( m_uosUndoStatus.move.Clone() );
		}
		#endregion

		/// <summary>
		/// RemoveFirstUndo
		/// </summary>
		protected void RemoveFirstUndo()
		{
			RemoveFirstFromStack( ref m_stackUndo );
		}

		/// <summary>
		/// RemoveFirstRedo
		/// </summary>
		protected void RemoveFirstRedo()
		{
			RemoveFirstFromStack( ref m_stackRedo );
		}


		/// <summary>
		/// RemoveFirstFromStack
		/// </summary>
		protected void RemoveFirstFromStack( ref Stack stack )
		{
			Stack stackTemp = new Stack( stack.Count - 1); // creates a temp stack to holds all elements of undo stack

			while ( stack.Count > 1  )
				stackTemp.Push( stack.Pop() );

			stack.Clear();

			while ( stackTemp.Count > 0 )
				stack.Push( stackTemp.Pop() );
		}


		/// <summary>
		/// CleanRedo:
		/// Cleans the redo stack and collect unused objects from memory.
		/// When a new undo operation is poped-up to the undo stack, the redo stack becomes unuseful
		/// </summary>
		protected void CleanRedo()
		{
			if (m_stackRedo.Count > 0)
			{	
				m_stackRedo.Clear();
				GC.Collect();
			}
		}

		protected int nSearchObject( ref String strObjName )
		{
			GraphicObject obj;
			for ( int i = 0; i < m_colGraphObj.Count; i++ )
			{
				obj = (GraphicObject)m_colGraphObj[ i ];
				if ( obj.strName.Equals(strObjName) )
					return( i ); // found at index i
			}

			return( -1 ); // NOT FOUND!
		}

		/// <summary>
		/// UpdateDeletion:
		/// Since object of index nFromIndex was deleted, the values in z-order and selection lists
		/// must be updated to maintain consistency.
		/// </summary>
		/// <param name="nFromIndex"></param>
		protected void UpdateDeletion( int nFromIndex )
		{
			IList ilValues;
			GraphicObject obj;
			int nOldIndex, nSelIndex;

			for ( int i = nFromIndex; i < m_colGraphObj.Count; i++ )
			{
				obj = (GraphicObject)m_colGraphObj[ i ];
				nOldIndex = obj.nIndex;
				obj.nIndex = i; // sets the new index of the object
			}

			ilValues = m_colSelObjs.GetValueList();
			// updates the values in the selection list
			for ( int i = 0; i < ilValues.Count; i++ )
			{
				if ( (int)ilValues[i] > nFromIndex )
				{
					nSelIndex = m_colSelObjs.IndexOfValue( (int)ilValues[i] );
					m_colSelObjs.SetByIndex( nSelIndex, (int)ilValues[i] - 1 );
				}
			}

		}

		protected bool bCanHighlight()
		{
			return((m_currTool == Tool.None) && m_bViewMode && m_bWindowNotStarted);
		}

		protected Rectangle GetSelectionRect()
		{
			return( m_rectSelection );
		}

		protected Rectangle GetScreenRect()
		{
			return( m_rectScreen );
		}

		protected Graphics GetMemoryDC()
		{
			return( m_memDC );
		}

		protected ArrayList GetGroupList()
		{
			return( m_arlObjGroups );
		}

		protected int nGetPrevioudHighLight()
		{
			return( m_nPreviousHighlight );
		}

		/// <summary>
		/// DeleteObjGroup:
		/// Deletes a group of objects from the list of groups.
		/// </summary>
		/// <param name="nGroupIndex"></param>
		protected void DeleteObjGroup( int nGroupIndex )
		{
			GraphicObject obj;
			ArrayList arlGroup;

			// deletes the group from the list
			m_arlObjGroups.RemoveAt( nGroupIndex );

			// updates the object from the other groups higher than the deleted
			// starts from the position deleted
			for ( int i = nGroupIndex; i < m_arlObjGroups.Count; i++ )
			{
				arlGroup = (ArrayList)m_arlObjGroups[ i ];
				for ( int j = 0; j < arlGroup.Count; j++ )
				{
					obj = (GraphicObject)m_colGraphObj[ (int)arlGroup[j] ];
					obj.nGroup -= 1;
				}
			}
		}

		/// <summary>
		/// IsAllGroupInside:
		/// Checks if all the objects in the group nGroupIndex are inside the rectangle rect.
		/// </summary>
		/// <param name="nGroupIndex"></param>
		/// <param name="rect"></param>
		/// <returns>True if all the objects are inside the rectangle. Otherwise, returns false.</returns>
		protected bool IsAllGroupInside( int nGroupIndex, ref Rectangle rect )
		{
			GraphicObject obj;
			ArrayList arlGroup = (ArrayList)m_arlObjGroups[ nGroupIndex ];

			for ( int i = 0; i < arlGroup.Count; i++ )
			{
				obj = (GraphicObject)m_colGraphObj[ (int)arlGroup[i] ];
				if ( !rect.Contains(obj.rect) )
					return( false );
			}

			return( true );
		}

		protected void SelectGroup( int nIndex )
		{
			int nObjIndex;
			ArrayList arlGroup = (ArrayList)m_arlObjGroups[ nIndex ];
			
			for ( int i = 0; i < arlGroup.Count; i++ )
			{
				nObjIndex = (int)arlGroup[ i ];
				m_colSelObjs.Add( nObjIndex, nObjIndex );
			}
		}

		protected void swapXValues( ref Point ptVal1, ref Point ptVal2 )
		{
			int nTemp = ptVal1.X; //holds one X value
			ptVal1.X = ptVal2.X;
			ptVal2.X = nTemp;
		}

		protected void swapYValues( ref Point ptVal1, ref Point ptVal2 )
		{
			int nTemp = ptVal1.Y; //holds one Y value
			ptVal1.Y = ptVal2.Y;
			ptVal2.Y = nTemp;
		}

		protected void swapPoints( ref Point ptVal1, ref Point ptVal2 )
		{
			Point ptTemp = ptVal1; //holds one point value
			ptVal1 = ptVal2;
			ptVal2 = ptTemp;
		}

//		protected Size sizeText( ref Graphics graph, ref String strText, ref Font fntText )
//		{
//			Size sizeReturn;
//			SizeF sizeF = new SizeF();
//
//			try
//			{
//				sizeF = graph.MeasureString( strText, fntText );
//				sizeReturn = Size.Ceiling( sizeF );
//			}catch{
//				sizeReturn = new Size(0,0);
//			}
//			return( sizeReturn );
//		}

		protected Size sizeText(ref String strText, ref Font fntText )
		{
			Size sizeReturn;
			SizeF sizeF = new SizeF();
			try
			{
				sizeF = System.Drawing.Graphics.FromImage(new System.Drawing.Bitmap(1,1)).MeasureString( strText, fntText);
				sizeReturn = Size.Ceiling( sizeF );
			}
			catch
			{
				sizeReturn = new Size(0,0);
			}
			return( sizeReturn );
		}

//		// calculates the extension of a string
//		protected Size sizeText( ref Graphics graph, ref TextObject obj )
//		{
//			return( sizeText(ref graph, ref obj.strText, ref obj.fntText) );
//		}
//
		// calculates the extension of a string
		protected Size sizeText(ref TextObject obj )
		{
			return( sizeText(ref obj.strText, ref obj.fntText) );
		}



		// resizes all selected object
		protected void ResizeObjects( Point ptNew )
		{
			GraphicObject obj;
			int nIndex;

			IList ilValues = m_colSelObjs.GetValueList();
			for ( int i = 0; i < m_colSelObjs.Count; i++ )
			{
				nIndex = (int)ilValues[i];
				obj = (GraphicObject)m_colGraphObj[nIndex];
				ResizeOneObject( ref obj, ref ptNew );
				obj.rect = BuildRect( ref obj.ptSource, ref obj.ptDestiny );
			}
			m_ptReference = ptNew;

		}

		protected void ResizeOneObject( ref GraphicObject obj, ref Point ptNew )
		{
			if ( obj.bResizeable == false )
				return; // objects that are not resizeable

			switch (m_edgSelected)
			{
				case ObjectEdges.UPPER_LEFT_CORNER:
					if ( obj.ptSource.X < obj.ptDestiny.X )
					{
						obj.ptSource.X  = obj.ptSource.X + (ptNew.X - m_ptReference.X);
						if ( obj.ptSource.X > obj.ptDestiny.X )
						{
							swapXValues( ref obj.ptSource, ref obj.ptDestiny );
							m_edgSelected = ObjectEdges.UPPER_RIGHT_CORNER;
						}
					}
					else
					{
						obj.ptDestiny.X  = obj.ptDestiny.X + (ptNew.X - m_ptReference.X);
						if ( obj.ptSource.X < obj.ptDestiny.X )
						{
							swapXValues( ref obj.ptSource, ref obj.ptDestiny );
							m_edgSelected = ObjectEdges.UPPER_RIGHT_CORNER;
						}
					}

					if ( obj.ptSource.Y < obj.ptDestiny.Y )
					{
						obj.ptSource.Y = obj.ptSource.Y + (ptNew.Y - m_ptReference.Y);
						if ( obj.ptSource.Y > obj.ptDestiny.Y )
						{
							swapYValues( ref obj.ptSource, ref obj.ptDestiny );
							m_edgSelected = ObjectEdges.LOWER_LEFT_CORNER;
						}
					}
					else
					{
						obj.ptDestiny.Y = obj.ptDestiny.Y + (ptNew.Y - m_ptReference.Y);
						if ( obj.ptSource.Y < obj.ptDestiny.Y )
						{
							swapYValues( ref obj.ptSource, ref obj.ptDestiny );
							m_edgSelected = ObjectEdges.LOWER_LEFT_CORNER;
						}
					}
					break;

				case ObjectEdges.UPPER_MIDDLE:
					if ( obj.ptSource.Y < obj.ptDestiny.Y )
					{
						obj.ptSource.Y  = obj.ptSource.Y + (ptNew.Y - m_ptReference.Y);
						if ( obj.ptSource.Y > obj.ptDestiny.Y )
						{
							swapYValues( ref obj.ptSource, ref obj.ptDestiny );
							m_edgSelected = ObjectEdges.LOWER_MIDDLE;
						}
					}
					else
					{
						obj.ptDestiny.Y  = obj.ptDestiny.Y + (ptNew.Y - m_ptReference.Y);
						if ( obj.ptSource.Y < obj.ptDestiny.Y )
						{
							swapYValues( ref obj.ptSource, ref obj.ptDestiny );
							m_edgSelected = ObjectEdges.LOWER_MIDDLE;
						}
					}
					break;

				case ObjectEdges.UPPER_RIGHT_CORNER:
					if ( obj.ptSource.X > obj.ptDestiny.X )
					{
						obj.ptSource.X  = obj.ptSource.X + (ptNew.X - m_ptReference.X);
						if ( obj.ptSource.X < obj.ptDestiny.X )
						{
							swapXValues( ref obj.ptSource, ref obj.ptDestiny );
							m_edgSelected = ObjectEdges.UPPER_LEFT_CORNER;
						}
					}
					else
					{
						obj.ptDestiny.X  = obj.ptDestiny.X + (ptNew.X - m_ptReference.X);
						if ( obj.ptSource.X > obj.ptDestiny.X )
						{
							swapXValues( ref obj.ptSource, ref obj.ptDestiny );
							m_edgSelected = ObjectEdges.UPPER_LEFT_CORNER;
						}
					}

					if ( obj.ptSource.Y < obj.ptDestiny.Y )
					{
						obj.ptSource.Y = obj.ptSource.Y + (ptNew.Y - m_ptReference.Y);
						if ( obj.ptSource.Y > obj.ptDestiny.Y )
						{
							swapYValues( ref obj.ptSource, ref obj.ptDestiny );
							m_edgSelected = ObjectEdges.LOWER_RIGHT_CORNER;
						}
					}
					else
					{
						obj.ptDestiny.Y = obj.ptDestiny.Y + (ptNew.Y - m_ptReference.Y);
						if ( obj.ptSource.Y < obj.ptDestiny.Y )
						{
							swapYValues( ref obj.ptSource, ref obj.ptDestiny );
							m_edgSelected = ObjectEdges.LOWER_RIGHT_CORNER;
						}
					}
					break;

				case ObjectEdges.RIGHT_SIDE_MIDDLE:
					if ( obj.ptSource.X > obj.ptDestiny.X )
					{
						obj.ptSource.X  = obj.ptSource.X + (ptNew.X - m_ptReference.X);
						if ( obj.ptSource.X < obj.ptDestiny.X )
						{
							swapXValues( ref obj.ptSource, ref obj.ptDestiny );
							m_edgSelected = ObjectEdges.LEFT_SIDE_MIDDLE;
						}
					}
					else
					{
						obj.ptDestiny.X  = obj.ptDestiny.X + (ptNew.X - m_ptReference.X);
						if ( obj.ptSource.X > obj.ptDestiny.X )
						{
							swapXValues( ref obj.ptSource, ref obj.ptDestiny );
							m_edgSelected = ObjectEdges.LEFT_SIDE_MIDDLE;
						}
					}
					break;

				case ObjectEdges.LOWER_RIGHT_CORNER:
					if ( obj.ptSource.X > obj.ptDestiny.X )
					{
						obj.ptSource.X  = obj.ptSource.X + (ptNew.X - m_ptReference.X);
						if ( obj.ptSource.X < obj.ptDestiny.X )
						{
							swapXValues( ref obj.ptSource, ref obj.ptDestiny );
							m_edgSelected = ObjectEdges.LOWER_LEFT_CORNER;
						}
					}
					else
					{
						obj.ptDestiny.X  = obj.ptDestiny.X + (ptNew.X - m_ptReference.X);
						if ( obj.ptSource.X  > obj.ptDestiny.X )
						{
							swapXValues( ref obj.ptSource, ref obj.ptDestiny );
							m_edgSelected = ObjectEdges.LOWER_LEFT_CORNER;
						}
					}

					if ( obj.ptSource.Y > obj.ptDestiny.Y )
					{
						obj.ptSource.Y = obj.ptSource.Y + (ptNew.Y - m_ptReference.Y);
						if ( obj.ptSource.Y < obj.ptDestiny.Y )
						{
							swapYValues( ref obj.ptSource, ref obj.ptDestiny );
							m_edgSelected = ObjectEdges.UPPER_RIGHT_CORNER;
						}
					}
					else
					{
						obj.ptDestiny.Y = obj.ptDestiny.Y + (ptNew.Y - m_ptReference.Y);
						if ( obj.ptSource.Y > obj.ptDestiny.Y )
						{
							swapYValues( ref obj.ptSource, ref obj.ptDestiny );
							m_edgSelected = ObjectEdges.UPPER_RIGHT_CORNER;
						}
					}
					break;

				case ObjectEdges.LOWER_MIDDLE:
					if ( obj.ptSource.Y > obj.ptDestiny.Y )
					{
						obj.ptSource.Y  = obj.ptSource.Y + (ptNew.Y - m_ptReference.Y);
						if ( obj.ptSource.Y < obj.ptDestiny.Y )
						{
							swapYValues( ref obj.ptSource, ref obj.ptDestiny );
							m_edgSelected = ObjectEdges.UPPER_MIDDLE;
						}
					}
					else
					{
						obj.ptDestiny.Y  = obj.ptDestiny.Y + (ptNew.Y - m_ptReference.Y);
						if ( obj.ptSource.Y > obj.ptDestiny.Y )
						{
							swapYValues( ref obj.ptSource, ref obj.ptDestiny );
							m_edgSelected = ObjectEdges.UPPER_MIDDLE;
						}
					}
					break;

				case ObjectEdges.LOWER_LEFT_CORNER:
					if ( obj.ptSource.X < obj.ptDestiny.X )
					{
						obj.ptSource.X  = obj.ptSource.X + (ptNew.X - m_ptReference.X);
						if ( obj.ptSource.X > obj.ptDestiny.X )
						{
							swapXValues( ref obj.ptSource, ref obj.ptDestiny );
							m_edgSelected = ObjectEdges.LOWER_RIGHT_CORNER;
						}
					}
					else
					{
						obj.ptDestiny.X  = obj.ptDestiny.X + (ptNew.X - m_ptReference.X);
						if ( obj.ptSource.X < obj.ptDestiny.X )
						{
							swapXValues( ref obj.ptSource, ref obj.ptDestiny );
							m_edgSelected = ObjectEdges.LOWER_RIGHT_CORNER;
						}
					}

					if ( obj.ptSource.Y > obj.ptDestiny.Y )
					{
						obj.ptSource.Y = obj.ptSource.Y + (ptNew.Y - m_ptReference.Y);
						if ( obj.ptSource.Y < obj.ptDestiny.Y )
						{
							swapYValues( ref obj.ptSource, ref obj.ptDestiny );
							m_edgSelected = ObjectEdges.UPPER_LEFT_CORNER;
						}
					}
					else
					{
						obj.ptDestiny.Y = obj.ptDestiny.Y + (ptNew.Y - m_ptReference.Y);
						if ( obj.ptSource.Y > obj.ptDestiny.Y )
						{
							swapYValues( ref obj.ptSource, ref obj.ptDestiny );
							m_edgSelected = ObjectEdges.UPPER_LEFT_CORNER;
						}
					}
					break;

				case ObjectEdges.LEFT_SIDE_MIDDLE:
					if ( obj.ptSource.X < obj.ptDestiny.X )
					{
						obj.ptSource.X  = obj.ptSource.X + (ptNew.X - m_ptReference.X);
						if ( obj.ptSource.X > obj.ptDestiny.X ) // if the new source is greater than destiny
						{
							// swaps the points
							swapXValues( ref obj.ptSource, ref obj.ptDestiny );
							m_edgSelected = ObjectEdges.RIGHT_SIDE_MIDDLE; // and swaps the edge, too
						}							
					}
					else 
					{
						obj.ptDestiny.X  = obj.ptDestiny.X + (ptNew.X - m_ptReference.X);
						if ( obj.ptSource.X < obj.ptDestiny.X ) // if the new source is greater than destiny
						{
							// swap the points
							swapXValues( ref obj.ptSource, ref obj.ptDestiny );
							m_edgSelected = ObjectEdges.RIGHT_SIDE_MIDDLE; // and swaps the edge, too
						}
					}
					break;

				default:
					break;
			}
		}

		protected bool IsVertical(ref Point ptSrc, ref Point ptDest)
		{
			if ( ptSrc.X == ptDest.X )
				return( true );
			else
				return( false );
		}

		protected bool IsHorizontal(ref Point ptSrc, ref Point ptDest)
		{
			if ( ptSrc.Y == ptDest.Y )
				return( true );
			else
				return( false );
		}

		protected void SetSelectedObjects()
		{
			Rectangle rectSel;
			Point ptSrc, ptDest;
			GraphicObject obj;

			rectSel = m_rectSelection;
			rectWorld2Screen( ref rectSel );

			// puts in selection list all objects inside m_rectSelecion
			m_colSelObjs.Clear();
			for ( int i = 0; i < m_colGraphObj.Count; i++ )
			{
				obj = (GraphicObject)m_colGraphObj[i];
				if ( !obj.bVisibleOnScreen )
					continue;

				ptSrc = obj.ptSource;
				ptDest = obj.ptDestiny;
				ptWorld2Screen( ref ptSrc );
				ptWorld2Screen( ref ptDest );

				if ( obj.nGroup >= 0 ) // it's a group of objects
				{
					if ( IsAllGroupInside(obj.nGroup, ref m_rectSelection) )
						m_colSelObjs.Add( obj.nIndex, obj.nIndex);
				} 
				else // it's a single object
				{
					if ( rectSel.Contains(ptSrc) && rectSel.Contains(ptDest) )
						m_colSelObjs.Add( obj.nIndex, obj.nIndex ); // index in m_colGraphObj
				}
			}
		}

		protected void UpdateSelectedObjectsPos()
		{
			IList ilValues;
			int nIndex;
			GraphicObject obj;



			ilValues = m_colSelObjs.GetValueList();

			for ( int i = 0; i < m_colSelObjs.Count; i++ )
			{
				nIndex = (int)ilValues[ i ];
				obj = (GraphicObject)m_colGraphObj[ nIndex ];				
				obj.ptSource.X = obj.ptSource.X + (m_ptDestiny.X - m_ptReference.X);
				obj.ptSource.Y = obj.ptSource.Y + (m_ptDestiny.Y - m_ptReference.Y);
				obj.ptDestiny.X = obj.ptDestiny.X + (m_ptDestiny.X - m_ptReference.X);
				obj.ptDestiny.Y = obj.ptDestiny.Y + (m_ptDestiny.Y - m_ptReference.Y);
				obj.rect = BuildRect(ref obj.ptSource, ref obj.ptDestiny);
			}
			m_ptReference = m_ptDestiny;
		}

		protected void CheckOffScreenBitmap()
		{
			if ( m_memBmp == null )
			{
				m_memBmp = new Bitmap(m_rectScreen.Width, m_rectScreen.Height/*, System.Drawing.Imaging.PixelFormat.Format8bppIndexed*/);
				Graphics clientDC = this.CreateGraphics();
				IntPtr hdc = clientDC.GetHdc();
				IntPtr memdc = Win32Support.CreateCompatibleDC(hdc);
				Win32Support.SelectObject(memdc, m_memBmp.GetHbitmap());
				m_memDC = Graphics.FromHdc(memdc);
				clientDC.ReleaseHdc(hdc);
			}
		}

		protected virtual void CreateNewObject(bool bAddToSystem)
		{
			String strObjName;
			Size size;
			Image newImg;
			GraphicObject newObj;
			
			switch (m_currTool)
			{
				case Tool.Line:
					LineObject newLineObj = new LineObject();
					newLineObj.rect = BuildRect(ref m_ptSource, ref m_ptDestiny);
					newLineObj.ptSource = m_ptSource;
					newLineObj.ptDestiny = m_ptDestiny;
					newLineObj.nPenStyle = m_nPenStyle;
					newLineObj.nPenWidth = m_nPenWidth;
					newLineObj.nLineStyle = m_nLineStyle;
					newLineObj.clrPen = m_clrPen;
					newObj = newLineObj;
					strObjName = "LineObject#";
					break;

				case Tool.Circle: 
					CircleObject newCircleObj = new CircleObject();				
					newCircleObj.rect = BuildRect(ref m_ptSource, ref m_ptDestiny);
					newCircleObj.ptSource = m_ptSource;
					newCircleObj.ptDestiny = m_ptDestiny;
					newCircleObj.clrPen = m_clrPen;
					newCircleObj.clrBack = m_clrBack;
					newCircleObj.nPenStyle = m_nPenStyle;
					newCircleObj.nPenWidth = m_nPenWidth;
					newCircleObj.bOpaque = m_bOpaque;
					newCircleObj.bVisibleForPrinting = m_bObjectPrintable;
					newObj = newCircleObj;
					strObjName = "CircleObject#";
					break;

				case Tool.Rectangle:
					RectangleObject newRectObj = new RectangleObject();				
					newRectObj.rect = BuildRect(ref m_ptSource, ref m_ptDestiny);
					newRectObj.ptSource = m_ptSource;
					newRectObj.ptDestiny = m_ptDestiny;
					newRectObj.clrPen = m_clrPen;
					newRectObj.clrBack = m_clrBack;
					newRectObj.nPenStyle = m_nPenStyle;
					newRectObj.nPenWidth = m_nPenWidth;
					newRectObj.bOpaque = m_bOpaque;
					newRectObj.bVisibleForPrinting = m_bObjectPrintable;
					newObj = newRectObj;
					strObjName = "RectangleObject#";
					break;

				case Tool.Image:
					ImageObject newImgObj = new ImageObject();
                    newImg = (System.Drawing.Image)m_imgImageToInsert.Clone();
					int nIndex = 1;
					while (m_sortLstImages.ContainsKey(nIndex))
					{
						nIndex++;
					}
					m_sortLstImages.Add(nIndex,m_imgImageToInsert.Clone());
					newImgObj.nImageIndex = nIndex;
					newImgObj.nImageIndexInDB = m_nImageIndex;
					newImgObj.ptSource = m_ptSource;
					newImgObj.ptDestiny.X = newImgObj.ptSource.X + newImg.Width;
					newImgObj.ptDestiny.Y = newImgObj.ptSource.Y + newImg.Height;
					newImgObj.bVisibleForPrinting = m_bObjectPrintable;
					newImgObj.rect = BuildRect( ref newImgObj.ptSource, ref newImgObj.ptDestiny );
					newObj = newImgObj;
					strObjName = "ImageObject#";
					break;

				case Tool.Text:
					TextObject newTextObj = new TextObject();
					newTextObj.strText = m_strText;
					newTextObj.fntText = m_fntText;
					newTextObj.clrText = m_clrText;
					CheckOffScreenBitmap();
					size = sizeText(ref newTextObj );
					newTextObj.size = size;
					newTextObj.ptSource = m_ptSource;
					newTextObj.ptDestiny.X = newTextObj.ptSource.X + size.Width;
					newTextObj.ptDestiny.Y = newTextObj.ptSource.Y + size.Height;
					newTextObj.rect = BuildRect( ref newTextObj.ptSource, ref newTextObj.ptDestiny );
					newTextObj.bVisibleForPrinting = m_bObjectPrintable;
					newObj = newTextObj;
					strObjName = "TextObject#";
					break;

				default:
					newObj = new SelectionObject();
					newObj.ptSource = m_ptSource;
					newObj.ptDestiny = m_ptDestiny;
					strObjName = "SelectionObject#";
					break;
			}

			newObj.nGroup = -1; // not grouped

			//if there is no selected object, the object must be added to the system
			if (bAddToSystem == true)
			{
				strObjName = strObjName + m_nObjectIndexer++;
				AddObjToSystem( ref newObj, ref strObjName );
			}
			else
			{
				SetTempObject( ref newObj );
			}
		}

		protected void SetTempObject( ref GraphicObject newObj )
		{
			newObj.strName = "TemporaryGraphicObject";
			newObj.nIndex = -1;
			m_grpObject = newObj;
		}

		protected void AddObjToSystem( ref GraphicObject newObj, ref String strObjName )
		{
			newObj.strName = strObjName;
			newObj.nIndex = m_colGraphObj.Add(newObj);
			// forces the new object to be selected
			m_rectSelection = newObj.rect;
			m_colSelObjs.Clear();
			m_colSelObjs.Add(newObj.nIndex, newObj.nIndex); // adds to the selection list
			m_uosUndoStatus.insert.Clear(); // save the status of the operation
			m_uosUndoStatus.insert.grpObj = newObj.Clone();
			addUndoInsert( true ); // adds an undo entry for this operation
		}

		protected Rectangle BuildSelRect()
		{
			IList ilValues;
			int nIndex;
			GraphicObject obj;
			Rectangle currRect, nextRect;

			ilValues = m_colSelObjs.GetValueList();
			if ( m_colSelObjs.Count > 0 )
			{
				nIndex = (int)ilValues[0];
				obj = ((GraphicObject)m_colGraphObj[nIndex]);
				currRect = obj.rect;
				for ( int i = 1; i < m_colSelObjs.Count; i++ )
				{
					nIndex = (int)ilValues[i];
					obj = ((GraphicObject)m_colGraphObj[nIndex]);
					nextRect = obj.rect;
					currRect = Rectangle.Union(currRect, nextRect);
				}
				
				return( currRect );
			}

			return( m_rectSelection ); //none selection
		}

		protected Rectangle BuildRect(ref Point ptSrc, ref Point ptDest)
		{
			Rectangle rect = new Rectangle();

			//build rectangle occupied by the object, basef on point source and destiny
			if ((ptSrc.X < ptDest.X) && (ptSrc.Y < ptDest.Y))  //inside 2nd quadrant (90 to 180 degrees)
			{
				rect.X = ptSrc.X;
				rect.Y = ptSrc.Y;
				rect.Width = ptDest.X - ptSrc.X;
				rect.Height = ptDest.Y - ptSrc.Y;
			} 
			else if ((ptSrc.X < ptDest.X) && (ptSrc.Y > ptDest.Y)) //between 3rd and 4th quadrant (180 to 270 degrees)
			{
				rect.X = ptSrc.X;
				rect.Y = ptDest.Y;
				rect.Width = ptDest.X - ptSrc.X;
				rect.Height = ptSrc.Y - ptDest.Y;
			} 
			else if ((ptSrc.X > ptDest.X) && (ptSrc.Y > ptDest.Y))    //inside 4th quadrant (270 to 360 degrees)
			{
				rect.X = ptDest.X;
				rect.Y = ptDest.Y;
				rect.Width = ptSrc.X - ptDest.X;
				rect.Height = ptSrc.Y - ptDest.Y;

			} 
			else if ((ptSrc.X > ptDest.X) && (ptSrc.Y < ptDest.Y))    //inside 1st quadrant (0 to 90 degrees)
			{
				rect.X = ptDest.X;
				rect.Y = ptSrc.Y;
				rect.Width = ptSrc.X - ptDest.X;
				rect.Height = ptDest.Y - ptSrc.Y;
			} 
			else
			{
				// its a horizontal or vertical line
				if ( IsVertical(ref ptSrc, ref ptDest) )
				{
					Point tmpS = new Point( ptSrc.X - 1, ptSrc.Y);
					Point tmpD = new Point( ptDest.X + 1,  ptDest.Y );
					rect = BuildRect(ref tmpS, ref tmpD);
					rect.Inflate( 2, 2 );
					return( rect );
				} 
				else if ( IsHorizontal(ref ptSrc, ref ptDest) )
				{
					Point tmpS = new Point( ptSrc.X, ptSrc.Y - 1);
					Point tmpD = new Point( ptDest.X,  ptDest.Y + 1 );
					rect = BuildRect(ref tmpS, ref tmpD);
					rect.Inflate( 2, 2 );
					return( rect );
				}
			}

			return( rect );
		}

		protected int nSelectedObject(Point pt)
		{
			GraphicObject obj;

			for (int i = m_colGraphObj.Count - 1; i >= 0 ; i--)
			{
				obj = (GraphicObject)m_colGraphObj[i];
				if ( obj.bVisibleOnScreen )
				{
					switch(obj.GetType().ToString())
					{
						case "DrawingCanvasPackage.CircleObject":
							// Top 
							if ( (Math.Abs(obj.rect.Y - pt.Y) < 2) && (obj.rect.X <= pt.X ) && ( pt.X <= (obj.rect.X + obj.rect.Width) ))
								return (i);
							// Bottom
							if ( (Math.Abs((obj.rect.Y + obj.rect.Height) - pt.Y) < 2) && (obj.rect.X <= pt.X ) && ( pt.X <= (obj.rect.X + obj.rect.Width) ))
								return (i);
							// Left 
							if ( (Math.Abs(obj.rect.X - pt.X) < 2) && (obj.rect.Y <= pt.Y ) && ( pt.Y <= (obj.rect.Y + obj.rect.Height) ))
								return (i);
							// Right
							if ( (Math.Abs((obj.rect.X + obj.rect.Width) - pt.X) < 2) && (obj.rect.Y <= pt.Y ) && ( pt.Y <= (obj.rect.Y + obj.rect.Height) ))
								return (i);
							break;
						case "DrawingCanvasPackage.RectangleObject":
							// Top 
							if ( (Math.Abs(obj.rect.Y - pt.Y) < 2) && (obj.rect.X <= pt.X ) && ( pt.X <= (obj.rect.X + obj.rect.Width) ))
								return (i);
							// Bottom
							if ( (Math.Abs((obj.rect.Y + obj.rect.Height) - pt.Y) < 2) && (obj.rect.X <= pt.X ) && ( pt.X <= (obj.rect.X + obj.rect.Width) ))
								return (i);
							// Left 
							if ( (Math.Abs(obj.rect.X - pt.X) < 2) && (obj.rect.Y <= pt.Y ) && ( pt.Y <= (obj.rect.Y + obj.rect.Height) ))
								return (i);
							// Right
							if ( (Math.Abs((obj.rect.X + obj.rect.Width) - pt.X) < 2) && (obj.rect.Y <= pt.Y ) && ( pt.Y <= (obj.rect.Y + obj.rect.Height) ))
								return (i);
							break;
						default:
							if ( obj.rect.Contains(pt) )
								return (i);
							break;
					}
				}
			}
			m_grpFocus.nIndex = -1;
			return (-1);  // point isn't inside an object
		}

		//changes the cursor if some selected object edge has the cursor over it
		protected void CheckSelectCursor(Point pt)
		{
			Point ptWorld = pt;
			ptWorld2Screen( ref ptWorld );
			if ( m_colSelObjs.Count > 0 && !m_bResizingObject )  //checks only if there is some selected object
			{
				if (m_arrEdges[ (int)ObjectEdges.UPPER_LEFT_CORNER ].Contains(ptWorld) == true)
				{
					if ( Cursor.Current != Cursors.SizeNWSE )
						System.Windows.Forms.Cursor.Current = Cursors.SizeNWSE;
					m_edgSelected = ObjectEdges.UPPER_LEFT_CORNER;
				} 
				else if (m_arrEdges[ (int)ObjectEdges.UPPER_MIDDLE ].Contains(ptWorld) == true)
				{
					if ( Cursor.Current != Cursors.SizeNS )
						System.Windows.Forms.Cursor.Current = Cursors.SizeNS;
					m_edgSelected = ObjectEdges.UPPER_MIDDLE;
				} 
				else if (m_arrEdges[ (int)ObjectEdges.UPPER_RIGHT_CORNER ].Contains(ptWorld) == true)
				{
					if ( Cursor.Current != Cursors.SizeNESW )
						System.Windows.Forms.Cursor.Current = Cursors.SizeNESW;
					m_edgSelected = ObjectEdges.UPPER_RIGHT_CORNER;
				} 
				else if (m_arrEdges[ (int)ObjectEdges.RIGHT_SIDE_MIDDLE ].Contains(ptWorld) == true)
				{
					if ( Cursor.Current != Cursors.SizeWE )
						System.Windows.Forms.Cursor.Current = Cursors.SizeWE;
					m_edgSelected = ObjectEdges.RIGHT_SIDE_MIDDLE;
				}
				else if (m_arrEdges[ (int)ObjectEdges.LOWER_RIGHT_CORNER ].Contains(ptWorld) == true)
				{
					if ( Cursor.Current != Cursors.SizeNWSE )
						System.Windows.Forms.Cursor.Current = Cursors.SizeNWSE;
					m_edgSelected = ObjectEdges.LOWER_RIGHT_CORNER;
				}
				else if (m_arrEdges[ (int)ObjectEdges.LOWER_MIDDLE ].Contains(ptWorld) == true)
				{
					if ( Cursor.Current != Cursors.SizeNS )
						System.Windows.Forms.Cursor.Current = Cursors.SizeNS;
					m_edgSelected = ObjectEdges.LOWER_MIDDLE;
				}
				else if (m_arrEdges[ (int)ObjectEdges.LOWER_LEFT_CORNER ].Contains(ptWorld) == true) 
				{
					if ( Cursor.Current != Cursors.SizeNESW )
						System.Windows.Forms.Cursor.Current = Cursors.SizeNESW;
					m_edgSelected = ObjectEdges.LOWER_LEFT_CORNER;
				}
				else if (m_arrEdges[ (int)ObjectEdges.LEFT_SIDE_MIDDLE ].Contains(ptWorld) == true) 
				{
					if ( Cursor.Current != Cursors.SizeWE )
						System.Windows.Forms.Cursor.Current = Cursors.SizeWE;
					m_edgSelected = ObjectEdges.LEFT_SIDE_MIDDLE;
				}
				else if (m_arrEdges[ (int)ObjectEdges.CENTER ].Contains(ptWorld) == true)
				{
					if ( Cursor.Current != Cursors.SizeAll )
						System.Windows.Forms.Cursor.Current = Cursors.SizeAll;
					m_edgSelected = ObjectEdges.CENTER;
				}
				else
				{
					m_edgSelected = ObjectEdges.NONE;
				}
			}
		}
	#endregion
		#region Exception Handler
			protected virtual void vHandleException(ref System.Exception e)
			{
			}
		#endregion
	} 
} 