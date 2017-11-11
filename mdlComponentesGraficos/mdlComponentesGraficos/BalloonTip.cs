using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections;

namespace mdlComponentesGraficos.BalloonTip
{
	#region Enums
		public enum HitTestCodes : int
		{
			Error             = (-2),
			Transparent       = (-1),
			Nowhere           = 0,
			Client            = 1,
			Caption           = 2,
			SysMenu           = 3,
			GrowBox           = 4,
			Size              = GrowBox,
			Menu              = 5,
			HScroll           = 6,
			VScroll           = 7,
			MinButton         = 8,
			MaxButton         = 9,
			Left              = 10,
			Right             = 11,
			Top               = 12,
			TopLeft           = 13,
			TopRight          = 14,
			Bottom            = 15,
			BottomLeft        = 16,
			BottomRight       = 17,
			Border            = 18,
			Reduce            = MinButton,
			Zoom              = MaxButton,
			SizeFirst         = Left,
			SizeLast          = BottomRight,
			Object            = 19,
			Close             = 20,
			Help              = 21,
		}

		public enum MouseMessages
		{
			Unknown		  = 0x0000,
			MouseMove     = 0x0200,
			LButtonDown   = 0x0201,
			LButtonUp     = 0x0202,
			LButtonDblClk = 0x0203,
			RButtonDown   = 0x0204,
			RButtonUp     = 0x0205,
			RButtonDblClk = 0x0206,
			MButtonDown   = 0x0207,
			MButtonUp     = 0x0208,
			MButtonDblClk = 0x0209,
			MouseWheel    = 0x020A,
			XButtonDown   = 0x020B,
			XButtonUP     = 0x020C,
			XButtonDblClk = 0x020D,
		};

		internal enum HookType
		{
			//MsgFilter		= -1,
			//JournalRecord    = 0,
			//JournalPlayback  = 1,
			Keyboard         = 2,
			//GetMessage       = 3,
			CallWndProc      = 4,
			//CBT              = 5,
			//SysMsgFilter     = 6,
			Mouse            = 7,
			//Hardware         = 8,
			//Debug            = 9,
			//Shell           = 10,
			//ForegroundIdle  = 11,
			CallWndProcRet  = 12,
			//KeyboardLL		= 13,
			//MouseLL			= 14,
		};
	#endregion
	#region Delegates
		internal delegate IntPtr HookProc(int code, IntPtr wparam, IntPtr lparam);
	#endregion

	#region BaseHook
		abstract class BaseHook : IDisposable
		{
			IntPtr handle;
			WindowsHook parent;
			GCHandle delegateHandle;

			internal BaseHook()
			{
			}
			
			~BaseHook()
			{
				Dispose(false);
			}

			[DllImport("User32.dll")]
			internal extern static void UnhookWindowsHookEx(IntPtr handle);
			
			[DllImport("User32.dll")]
			internal extern static IntPtr SetWindowsHookEx(int idHook, [MarshalAs(UnmanagedType.FunctionPtr)] HookProc lpfn, IntPtr hinstance, int threadID);
			
			[DllImport("User32.dll")]
			internal extern static IntPtr CallNextHookEx(IntPtr handle, int code, IntPtr wparam, IntPtr lparam);

			IntPtr HookProc(int code, IntPtr wparam, IntPtr lparam)
			{
				if (code >= 0)
				{
					try
					{
						InvokeHookEvent(code, wparam, lparam);
					}
					catch(Exception e)
					{
						System.Diagnostics.Trace.WriteLine(String.Format("Unhandled Exception {0}", e));
					}
				}

				return CallNextHookEx(handle, code, wparam, lparam);
			}

			internal abstract HookType Type
			{
				get;
			}
			
			protected abstract void InvokeHookEvent(int code, IntPtr wparam, IntPtr lparam);

			internal void SetHook(WindowsHook parent, IntPtr hinstance, int threadID)
			{
				if (handle != IntPtr.Zero)
					Dispose(false);
				
				this.parent = parent;
				
				HookProc proc = new HookProc(this.HookProc);

				handle = SetWindowsHookEx((int)Type, proc, hinstance, threadID);
				
				if (handle == IntPtr.Zero)
				{
					GC.SuppressFinalize(this);
					Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
				}
				
				this.delegateHandle = GCHandle.Alloc(proc);
			}
			
			private void Dispose(bool disposing)
			{
				if (handle != IntPtr.Zero)
				{
					UnhookWindowsHookEx(handle);
				}
				
				if (delegateHandle.IsAllocated)
					delegateHandle.Free();

				if (disposing)
					GC.SuppressFinalize(this);
			}

			public void Dispose()
			{
				Dispose(true);			
			}

			protected WindowsHook Parent
			{
				get
				{
					return this.parent;
				}
			}
		}
	#endregion
	#region CallWndProcHookEventArgs
		public class CallWndProcHookEventArgs : EventArgs
		{
			Message message;
			bool sentFromCurrentProcess;

			[StructLayout(LayoutKind.Sequential)]
				internal class CWPSTRUCT
			{
				public IntPtr lparam = System.IntPtr.Zero;
				public IntPtr wparam = System.IntPtr.Zero;
				public int message = 0;
				public IntPtr hwnd = System.IntPtr.Zero;
			};
			
			internal CallWndProcHookEventArgs(IntPtr wparam, IntPtr lparam)
			{
				sentFromCurrentProcess = wparam != IntPtr.Zero;
		
				CWPSTRUCT cwp = (CWPSTRUCT)Marshal.PtrToStructure(lparam, typeof(CWPSTRUCT));
				message = Message.Create(cwp.hwnd, cwp.message, cwp.wparam, cwp.lparam);
			}
		
			public System.Windows.Forms.Message Message
			{
				get
				{
					return message;
				}
			}
		
			public bool SentFromCurrentProcess
			{
				get
				{
					return this.sentFromCurrentProcess;
				}
			}
		}

		public delegate void CallWndProcHookEventHandler(object sender, CallWndProcHookEventArgs e);
		
		/// <summary>
		/// Summary description for CallWndRetProcHook.
		/// </summary>
		class CallWndProcHook : BaseHook
		{
			internal CallWndProcHook()
			{
			}
			
			internal override HookType Type
			{
				get
				{
					return HookType.CallWndProc;
				}
			}

			protected override void InvokeHookEvent(int code, System.IntPtr wparam, System.IntPtr lparam)
			{
				CallWndProcHookEventArgs e = new CallWndProcHookEventArgs(wparam, lparam);
				Parent.OnCallWndProcHook(this, e);
			}
		}	

	#endregion
	#region CallWndProcRetHookEventArgs
		public class CallWndProcRetHookEventArgs : EventArgs
		{
			Message message;
			bool sentFromCurrentProcess;

			[StructLayout(LayoutKind.Sequential)]
				internal class CWPRETSTRUCT
			{
				public IntPtr result = System.IntPtr.Zero;
				public IntPtr lparam = System.IntPtr.Zero;
				public IntPtr wparam = System.IntPtr.Zero;
				public int message = 0;
				public IntPtr hwnd = System.IntPtr.Zero;
			};

			internal CallWndProcRetHookEventArgs(IntPtr wparam, IntPtr lparam)
			{
				sentFromCurrentProcess = wparam != IntPtr.Zero;
		
				CWPRETSTRUCT cwpr = (CWPRETSTRUCT)Marshal.PtrToStructure(lparam, typeof(CWPRETSTRUCT));
				message = Message.Create(cwpr.hwnd, cwpr.message, cwpr.wparam, cwpr.lparam);
				message.Result = cwpr.result;
			}

			public System.Windows.Forms.Message Message
			{
				get
				{
					return message;
				}
			}
		
			public bool SentFromCurrentProcess
			{
				get
				{
					return this.sentFromCurrentProcess;
				}
			}
		};
		
		public delegate void CallWndProcRetHookEventHandler(object sender, CallWndProcRetHookEventArgs e);
		
		/// <summary>
		/// Summary description for CallWndRetProcHook.
		/// </summary>
		class CallWndProcRetHook : BaseHook
		{
			internal CallWndProcRetHook()
			{
			}
			
			internal override HookType Type
			{
				get
				{
					return HookType.CallWndProcRet;
				}
			}

			protected override void InvokeHookEvent(int code, System.IntPtr wparam, System.IntPtr lparam)
			{
				CallWndProcRetHookEventArgs e = new CallWndProcRetHookEventArgs(wparam, lparam);
				Parent.OnCallWndRetProcHook(this, e);
			}
		}

	#endregion
	#region KeyBoardHookEventArgs
		public class KeyBoardHookEventArgs : EventArgs
		{
			const int KF_EXTENDED       = 0x0100;
			const int KF_DLGMODE        = 0x0800;
			const int KF_MENUMODE       = 0x1000;
			const int KF_ALTDOWN        = 0x2000;
			const int KF_REPEAT         = 0x4000;
			const int KF_UP             = 0x8000;
			
			private Keys virtKey;
			private int keyFlags;

			internal KeyBoardHookEventArgs(IntPtr wParam, IntPtr lParam)
			{
				int virtKeyInt = (int)wParam;

				if (!Enum.IsDefined(typeof(Keys), virtKeyInt))
					virtKey = Keys.None;
				else
					virtKey = (Keys)virtKeyInt;
			
				keyFlags = (int)lParam;
			}
		
			public Keys VirtKey
			{
				get
				{
					return virtKey;
				}
			}

			public short Repeat
			{
				get
				{
					return (short)(keyFlags & KF_EXTENDED);
				}
			}

			public bool AltDown
			{
				get
				{
					return (keyFlags & KF_ALTDOWN) != 0;
				}
			}
		
			public bool IsDialogActive
			{
				get
				{
					return (keyFlags & KF_DLGMODE) != 0;
				}
			}
		
			public bool IsMenuActive
			{
				get
				{
					return (keyFlags & KF_MENUMODE) != 0;
				}
			}
		
			public bool IsKeyUp
			{
				get
				{
					return (keyFlags & KF_UP) != 0;
				}
			}
		};
		
		public delegate void KeyBoardHookEventHandler(object sender, KeyBoardHookEventArgs e);

		/// <summary>
		/// Summary description for KeyBoardHook.
		/// </summary>
		class KeyBoardHook : BaseHook
		{
			public KeyBoardHook()
			{
			}

			protected override void InvokeHookEvent(int code, System.IntPtr wparam, System.IntPtr lparam)
			{
				Parent.OnKeyBoardHook(this, new KeyBoardHookEventArgs(wparam, lparam));
			}

			internal override HookType Type
			{
				get
				{
					return HookType.Keyboard;
				}
			}
		}
	#endregion
	#region MouseHookEventArgs
		public class MouseHookEventArgs
		{
			private MouseMessages message;
			private Point point;
			private IntPtr hwnd;
			private HitTestCodes hitTestCode;
			private IntPtr extraInfo;

			[StructLayout(LayoutKind.Sequential)]
				struct POINT
			{
				public int x;
				public int y;
			}

			[StructLayout(LayoutKind.Sequential)]
				class MOUSEHOOKSTRUCT
			{
				public POINT pt = new POINT();
				public IntPtr hwnd = System.IntPtr.Zero;
				public int hitTestCode = 0;
				public IntPtr extraInfo = System.IntPtr.Zero;
			}

			internal MouseHookEventArgs(IntPtr wparam, IntPtr lparam)
			{
				if (!Enum.IsDefined(typeof(MouseMessages), wparam.ToInt32()))
					message = MouseMessages.Unknown;
				else
					message = (MouseMessages)wparam.ToInt32();
			
				MOUSEHOOKSTRUCT hs = (MOUSEHOOKSTRUCT)Marshal.PtrToStructure(lparam, typeof(MOUSEHOOKSTRUCT));
				
				point = new Point(hs.pt.x, hs.pt.y);
				hwnd = hs.hwnd;
				hitTestCode = (HitTestCodes)hs.hitTestCode;
				extraInfo = hs.extraInfo;
			}
		
			public MouseMessages Message
			{
				get
				{
					return message;
				}
			}

			public Point Point
			{
				get
				{
					return point;
				}
			}

			public IntPtr Hwnd
			{
				get
				{
					return hwnd;
				}
			}

			public HitTestCodes HitTestCode
			{
				get
				{
					return hitTestCode;
				}
			}

			public IntPtr ExtraInfo
			{
				get
				{
					return extraInfo;
				}
			}
		};
		
		public delegate void MouseHookEventHandler(object sender, MouseHookEventArgs e);
		
		/// <summary>
		/// Summary description for MouseHook.
		/// </summary>
		class MouseHook : BaseHook
		{
			public MouseHook()
			{
			}
		
			protected override void InvokeHookEvent(int code, System.IntPtr wparam, System.IntPtr lparam)
			{
				Parent.OnMouseHook(this, new MouseHookEventArgs(wparam, lparam));
			}

			internal override HookType Type
			{
				get
				{
					return HookType.Mouse;
				}
			}
		}

	#endregion
	#region WindowsHook
		public class WindowsHook : System.ComponentModel.Component
		{
			private ArrayList hooks;
			private int threadID;
			
			public WindowsHook(System.ComponentModel.IContainer container)
				: this()
			{
				container.Add(this);
			}

			public WindowsHook()
			{
				//Reserve space for atmost 4 hooks
				hooks = new ArrayList(4);
			}
			
			/// <summary>
			/// The thread which needs to be hooked
			/// </summary>
			public int ThreadID
			{
				get
				{
					return threadID;
				}
				set
				{
					threadID = value;
				
					//Start hooking or change the hooks
					foreach(BaseHook hook in hooks)
					{
						hook.SetHook(this, IntPtr.Zero, value);
					}
				}
			}
			
			[DllImport("kernel32.dll")]
			static extern int GetCurrentThreadId();

			public void HookCurrentThread()
			{
				this.ThreadID = GetCurrentThreadId();
			}

			protected override void Dispose(bool disposing)
			{
				if (disposing)
				{
					//dispose individual hooks
					foreach(IDisposable hook in hooks)
					{
						hook.Dispose();
					}
				}
			}

			protected internal virtual void OnMouseHook(object hook, MouseHookEventArgs e)
			{
				MouseHookEventHandler handler = (MouseHookEventHandler)Events[hook];
				handler(this, e);
			}

			protected internal virtual void OnKeyBoardHook(object hook, KeyBoardHookEventArgs e)
			{
				KeyBoardHookEventHandler handler = (KeyBoardHookEventHandler)Events[hook];
				handler(this, e);
			}
			
			protected internal virtual void OnCallWndRetProcHook(object key, CallWndProcRetHookEventArgs e)
			{
				CallWndProcRetHookEventHandler handler = (CallWndProcRetHookEventHandler)Events[key];
				handler(this, e);
			}
		
			protected internal virtual void OnCallWndProcHook(object key, CallWndProcHookEventArgs e)
			{
				CallWndProcHookEventHandler handler = (CallWndProcHookEventHandler)Events[key];
				handler(this, e);
			}

			private BaseHook GetHookObjectForType(HookType type)
			{
				BaseHook ret = null;

				foreach(BaseHook hook in hooks)
				{
					if (hook.Type == type)
					{
						ret = hook;
						break;
					}
				}
				
				return ret;
			}
			
			private void AddHookEventHandler(HookType type, Type classType, Delegate value)
			{
				BaseHook key = GetHookObjectForType(type);

				if (key == null)
				{
					key = (BaseHook)Activator.CreateInstance(classType, true);
					
					if (threadID != 0)
						key.SetHook(this, IntPtr.Zero, threadID);

					hooks.Add(key);
				}
					
				Events.AddHandler(key, value);				
			}

			private void RemoveHookEventHandler(HookType type, Delegate value)
			{
				BaseHook key = GetHookObjectForType(type);
				Events.RemoveHandler(key, value);
					
				if (Events[key] == null)
					key.Dispose();
			
				hooks.Remove(key);	
			}

			public event MouseHookEventHandler MouseHook
			{
				add
				{
					AddHookEventHandler(HookType.Mouse, typeof(MouseHook), value);
				}
				remove
				{
					RemoveHookEventHandler(HookType.Mouse, value);
				}
			}

			public event KeyBoardHookEventHandler KeyBoardHook
			{
				add
				{
					AddHookEventHandler(HookType.Keyboard, typeof(KeyBoardHook), value);
				}
				remove
				{
					RemoveHookEventHandler(HookType.Keyboard, value);
				}
			}

			public event CallWndProcRetHookEventHandler CallWndProcRetHook
			{
				add
				{
					AddHookEventHandler(HookType.CallWndProcRet, typeof(CallWndProcRetHook), value);
				}
				remove
				{
					RemoveHookEventHandler(HookType.CallWndProcRet, value);
				}
			}

			public event CallWndProcHookEventHandler CallWndProcHook
			{
				add
				{
					AddHookEventHandler(HookType.CallWndProc, typeof(CallWndProcHook), value);
				}
				remove
				{
					RemoveHookEventHandler(HookType.CallWndProc, value);
				}
			}
		}
	#endregion

	#region BalloonWindow
		/// <summary>
		/// Summary description for BalloonWindow.
		/// </summary>
		public class BalloonWindow : System.Windows.Forms.Form
		{
			#region Fields
			private Point anchorPoint;
			private GraphicsPath path;
			#endregion

			#region Constants
			public static readonly int TIPMARGIN = SystemInformation.FrameBorderSize.Height;
			public static readonly int TIPTAIL = SystemInformation.ToolWindowCaptionHeight;
			const int WM_NCCALCSIZE = 0x0083;
			const int WM_NCPAINT = 0x0085;
			const int WM_NCHITTEST = 0x0084;
			#endregion
			
			public enum BallonQuadrant
			{
				TopLeft,
				TopRight,
				BottomLeft,
				BottomRight
			}
			
			public BalloonWindow()
			{
				this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
				this.SetStyle(ControlStyles.DoubleBuffer, true);
				this.SetStyle(ControlStyles.ResizeRedraw, true);
				this.TopMost = true;
				this.ShowInTaskbar = false;
				this.ForeColor = System.Drawing.SystemColors.InfoText;
				this.BackColor = System.Drawing.SystemColors.Info;
				this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			}

			#region Public Properties
			public Point AnchorPoint
			{
				get
				{
					return anchorPoint;
				}
				set
				{
					if (!this.DesignMode)
						RepositionWindow(anchorPoint, value);
					
					anchorPoint = value;
				}
			}

			public BallonQuadrant Quadrant
			{
				get
				{
					Rectangle screenBounds = Screen.FromPoint(anchorPoint).Bounds;

					if(anchorPoint.Y < screenBounds.Top + screenBounds.Height/2)
					{
						if(anchorPoint.X < screenBounds.Left + screenBounds.Width/2)
							return BallonQuadrant.TopLeft;
						else
							return BallonQuadrant.TopRight;
					}
					else
					{
						if(anchorPoint.X < screenBounds.Left + screenBounds.Width/2)
							return BallonQuadrant.BottomLeft;
					}

					return BallonQuadrant.BottomRight;
				}
			}
			#endregion

			#region Layout Related
			protected void RecalcLayout()
			{
				if (!this.IsHandleCreated)
					return;

				System.Drawing.Size windowSize = this.Size;
				
				Point[] tailPoints = new Point[3];
				Point topLeftPoint = Point.Empty;
				Point bottomRightPoint = (Point)windowSize;

				switch(this.Quadrant)
				{
					case BallonQuadrant.TopLeft:
						topLeftPoint.Y = TIPTAIL;
						tailPoints[2].X = (windowSize.Width-TIPTAIL)/4 + TIPTAIL;
						tailPoints[2].Y = TIPTAIL;
						tailPoints[0].X = (windowSize.Width-TIPTAIL)/4 + 1;
						tailPoints[0].Y = tailPoints[2].Y;
						tailPoints[1].X = tailPoints[0].X;
						tailPoints[1].Y = 1;
						break;
					case BallonQuadrant.TopRight:
						topLeftPoint.Y = TIPTAIL;
						tailPoints[0].X = (windowSize.Width-TIPTAIL)/4*3;
						tailPoints[0].Y = TIPTAIL;
						tailPoints[2].X = (windowSize.Width-TIPTAIL)/4*3 + TIPTAIL-1;
						tailPoints[2].Y = tailPoints[0].Y;
						tailPoints[1].X = tailPoints[2].X;
						tailPoints[1].Y = 1;
						break;
					case BallonQuadrant.BottomLeft:
						bottomRightPoint.Y = windowSize.Height-TIPTAIL;
						tailPoints[0].X = (windowSize.Width-TIPTAIL)/4 + TIPTAIL - 1;
						tailPoints[0].Y = windowSize.Height-TIPTAIL;
						tailPoints[2].X = (windowSize.Width-TIPTAIL)/4;
						tailPoints[2].Y = tailPoints[0].Y;
						tailPoints[1].X = tailPoints[2].X;
						tailPoints[1].Y = windowSize.Height-1;
						break;
					case BallonQuadrant.BottomRight:
						bottomRightPoint.Y = windowSize.Height-TIPTAIL;
						tailPoints[2].X = (windowSize.Width-TIPTAIL)/4*3;
						tailPoints[2].Y = windowSize.Height-TIPTAIL;
						tailPoints[0].X = (windowSize.Width-TIPTAIL)/4*3 + TIPTAIL - 1;
						tailPoints[0].Y = tailPoints[2].Y;
						tailPoints[1].X = tailPoints[0].X;
						tailPoints[1].Y = windowSize.Height-1;
						break;
				}

				//
				// adjust for very narrow balloons
				//
				if(tailPoints[0].X < TIPMARGIN )
					tailPoints[0].X = TIPMARGIN;

				if(tailPoints[0].X > windowSize.Width - TIPMARGIN)
					tailPoints[0].X = windowSize.Width - TIPMARGIN;

				if(tailPoints[1].X < TIPMARGIN)
					tailPoints[1].X = TIPMARGIN;

				if(tailPoints[1].X > windowSize.Width - TIPMARGIN)
					tailPoints[1].X = windowSize.Width - TIPMARGIN;

				if(tailPoints[2].X < TIPMARGIN)
					tailPoints[2].X = TIPMARGIN;

				if(tailPoints[2].X > windowSize.Width - TIPMARGIN)
					tailPoints[2].X = windowSize.Width - TIPMARGIN;
				
				if (!this.DesignMode)
				{
					// get window position
					Point screenLocation = new Point(anchorPoint.X - tailPoints[1].X, anchorPoint.Y - tailPoints[1].Y);

					// adjust position so all is visible
					Rectangle workArea = Screen.FromPoint(anchorPoint).WorkingArea;

					int adjustX=0;
					int adjustY=0;

					if ( screenLocation.X < workArea.X)
						adjustX = workArea.Left - screenLocation.X;
					else if ( screenLocation.X + windowSize.Width >= workArea.Right )
						adjustX = workArea.Right - (screenLocation.X + windowSize.Width);
					if ( screenLocation.Y + TIPTAIL < workArea.Top )
						adjustY = workArea.Top - (screenLocation.Y + TIPTAIL);
					else if ( screenLocation.Y + windowSize.Height - TIPTAIL >= workArea.Bottom )
						adjustY = workArea.Bottom - (screenLocation.Y + windowSize.Height - TIPTAIL);

					//tailPoints[0].X -= adjustX;
					tailPoints[1].X -= adjustX;
					//tailPoints[2].X -= adjustX;
					screenLocation.X += adjustX;
					screenLocation.Y += adjustY;

					// place window
					this.SetBounds(screenLocation.X, screenLocation.Y, windowSize.Width, windowSize.Height);
				}
				
				if (path != null)
					path.Dispose();

				path = new GraphicsPath(FillMode.Alternate);
				
				int arcRadius = TIPMARGIN*3;
				int arcDia = arcRadius*2;
				int rectX1 = topLeftPoint.X + arcRadius;
				int rectX2 = bottomRightPoint.X - arcRadius;
				int rectY1 = topLeftPoint.Y + arcRadius;
				int rectY2 = bottomRightPoint.Y - arcRadius;
				
				path.StartFigure();

				// apply region
				if ((this.Quadrant == BallonQuadrant.TopLeft) || 
					(this.Quadrant == BallonQuadrant.TopRight))
				{
					path.AddArc(topLeftPoint.X, rectY2 - arcRadius, arcDia, arcDia, 90, 90);
					path.AddLine(topLeftPoint.X, rectY2, topLeftPoint.X, rectY1);
					path.AddArc(topLeftPoint.X, topLeftPoint.Y, arcDia, arcDia, 180, 90);
					path.AddLine(rectX1, topLeftPoint.Y, tailPoints[0].X, topLeftPoint.Y);
					path.AddLines(tailPoints);
					path.AddLine(tailPoints[2].X, topLeftPoint.Y, rectX2, topLeftPoint.Y);
					path.AddArc(rectX2 - arcRadius, topLeftPoint.Y, arcDia, arcDia, 270, 90);
					path.AddLine(bottomRightPoint.X, rectY1, bottomRightPoint.X, rectY2);
					path.AddArc(rectX2 - arcRadius, rectY2 - arcRadius, arcDia, arcDia, 0, 90);
					path.AddLine(rectX2, bottomRightPoint.Y, rectX1, bottomRightPoint.Y);
				}
				else
				{
					path.AddLine(rectX1, topLeftPoint.Y, rectX2, topLeftPoint.Y);
					path.AddArc(rectX2 - arcRadius, topLeftPoint.Y, arcDia, arcDia, 270, 90);
					path.AddLine(bottomRightPoint.X, rectY1, bottomRightPoint.X, rectY2);
					path.AddArc(rectX2 - arcRadius, rectY2 - arcRadius, arcDia, arcDia, 0, 90);
					path.AddLine(rectX2, bottomRightPoint.Y, tailPoints[0].X, bottomRightPoint.Y);
					path.AddLines(tailPoints);
					path.AddLine(tailPoints[2].X, bottomRightPoint.Y, rectX1, bottomRightPoint.Y);
					path.AddArc(topLeftPoint.X, rectY2 - arcRadius, arcDia, arcDia, 90, 90);
					path.AddLine(topLeftPoint.X, rectY2, topLeftPoint.X, rectY1);
					path.AddArc(topLeftPoint.X, topLeftPoint.Y, arcDia, arcDia, 180, 90);
				}

				path.CloseFigure();

				this.Region = new Region(this.path);
			}

			protected void RepositionWindow(Point oldAnchorPoint, Point newAnchorPoint)
			{
				if (!this.IsHandleCreated)
					return;

				this.Location = this.Location + (Size)(newAnchorPoint - (Size)oldAnchorPoint);
			}
			#endregion

			#region Interop Functions
			[DllImport("User32.dll")]
			static extern IntPtr GetWindowDC(IntPtr hwnd);
			
			[StructLayout(LayoutKind.Sequential)]
				struct RECT
			{
				int left;
				int top;
				int right;
				int bottom;
				
				Rectangle ToRectangle()
				{
					return new Rectangle(left, top, right - left, bottom - top);
				}
				
				void FromRectangle(Rectangle rect)
				{
					left = rect.Left;
					right = rect.Right;
					top = rect.Top;
					bottom = rect.Bottom;
				}

				public static implicit operator Rectangle(RECT rc)
				{
					return rc.ToRectangle();
				}
				
				public static implicit operator RECT(Rectangle rect)
				{
					RECT rc = new RECT();
					rc.FromRectangle(rect);

					return rc;
				}
			}

			#endregion
			
			#region NC Messages

			protected virtual Rectangle OnNCCalcSize(Rectangle windowRect)
			{
				windowRect.Inflate(-TIPMARGIN, -TIPMARGIN);

				switch(this.Quadrant)
				{
					case BallonQuadrant.TopLeft:
					case BallonQuadrant.TopRight:
						windowRect.Y += TIPTAIL;
						windowRect.Height -= TIPTAIL;
						break;
					case BallonQuadrant.BottomLeft:
					case BallonQuadrant.BottomRight:
						windowRect.Height -= TIPTAIL;
						break;
				}

				return windowRect;
			}
			
			protected virtual void OnNCPaint(Graphics g)
			{
				Rectangle windowRect = new Rectangle(new Point(0, 0), this.Size);
				Rectangle clientRect = OnNCCalcSize(windowRect);
				
				clientRect.Offset(-windowRect.Left, -windowRect.Top);
				g.ExcludeClip(clientRect);
				windowRect.Offset(-windowRect.Left, -windowRect.Top);
				
				Brush b = new SolidBrush(this.BackColor);
				g.FillRectangle(b, windowRect);
				b.Dispose();
				
				Pen p = new Pen(this.ForeColor, 2);
				g.DrawPath(p, path);
				p.Dispose();
			}

			#endregion	
			
			#region Window messages and crackers
			private void WmNCPaint(ref System.Windows.Forms.Message m)
			{
				using(Graphics g = Graphics.FromHdc(GetWindowDC(this.Handle)))
				{
					OnNCPaint(g);
				}
			}
			
			private void WmNCHitTest(ref System.Windows.Forms.Message m)
			{
				base.WndProc(ref m);
				
				if (m.Result != (IntPtr)(int)HitTestCodes.Client)
					m.Result = (IntPtr)HitTestCodes.Nowhere;
			}

			private void WmNCCalcSize(ref System.Windows.Forms.Message m)
			{
				m.Result = IntPtr.Zero;

				RECT rc = (RECT)Marshal.PtrToStructure(m.LParam, typeof(RECT));
				rc = (RECT)OnNCCalcSize(rc);
				Marshal.StructureToPtr(rc, m.LParam, false);
			}

			protected override void WndProc(ref System.Windows.Forms.Message m)
			{
				switch(m.Msg)
				{
					case WM_NCCALCSIZE:
						WmNCCalcSize(ref m);
						break;
					case WM_NCPAINT:
						WmNCPaint(ref m);
						break;
					case WM_NCHITTEST:
						WmNCHitTest(ref m);
						break;
					default:
						base.WndProc(ref m);
						break;
				}
			}
			#endregion

			#region Protected Overrides
			protected override void OnLoad(System.EventArgs e)
			{
				this.RecalcLayout();
				base.OnLoad(e);
			}

			protected override void OnResize(System.EventArgs e)
			{
				this.RecalcLayout();
				this.RepositionWindow(anchorPoint, anchorPoint);
				base.OnResize(e);
			}

			/// <summary>
			/// Clean up any resources being used.
			/// </summary>
			protected override void Dispose( bool disposing )
			{
				if( disposing )
				{
					if (path != null)
						path.Dispose();
				}
				base.Dispose( disposing );
			}
			#endregion
			
			#region Public Methods
			public static Point AnchorPointFromControl(Control anchorControl)
			{
				if (anchorControl == null)
					throw new ArgumentException();

				Point controlLocation = anchorControl.Location;
				System.Drawing.Size controlSize = anchorControl.Size;
				
				if (anchorControl.Parent != null)
					controlLocation = anchorControl.Parent.PointToScreen(controlLocation);

				return controlLocation + new Size(controlSize.Width/2, controlSize.Height/2);
			}

			public void ShowBalloon(Control anchorControl)
			{
				this.AnchorPoint = AnchorPointFromControl(anchorControl);
				this.Show();
			}

			#endregion
		}
	#endregion
}
