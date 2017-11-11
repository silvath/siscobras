/*
 * Author: Marcus Lorentzon, 2001
 *         d98malor@dtek.chalmers.se
 * 
 * Freeware: Please do not remove this header
 * 
 * File: clsSerialStream.cs
 * 
 * Description: Implements a Stream for asynchronous
 *              transfers and COMM. Stream version.
 *
 * Version: 2.3
 * 
 */

#region Using

using System;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;
using System.ComponentModel;

#endregion Using

namespace mdlModem
{
	/// <summary>
	/// Summary description for clsSerialStream.
	/// </summary>
	internal class clsSerialStream : Stream 
	{
		
		#region Attributes

		private IOCompletionCallback m_IOCompletionCallback;
		private IntPtr m_hFile = IntPtr.Zero;
		private string m_sPort;
		private bool m_bRead;
		private bool m_bWrite;

		#endregion Attributes

		#region Delegates
		// Testando delegate
		public delegate void delCallSetaWaitHandle(ref WaitHandle waitHandleAssincrono);
		public event delCallSetaWaitHandle eCallSetaWaitHandle;
		// Testando delegate
		#endregion

		#region Properties

		public string Port 
		{
			get 
			{
				return m_sPort;
			}
			set 
			{
				if (m_sPort != value) 
				{
					Close();
					Open(value);
				}
			}
		}

		public override bool CanRead 
		{
			get 
			{
				return m_bRead;
			}
		}

		public override bool CanWrite 
		{
			get 
			{
				return m_bWrite;
			}
		}

		public override bool CanSeek 
		{
			get 
			{
				return false;
			}
		}

		public bool Closed  
		{
			get 
			{
				return m_hFile.ToInt32() <= 0;
			}
		}

		public override long Length 
		{
			get 
			{
				throw new NotSupportedException("Propriedade Length n�o suportado em portas seriais.");
			}
		}

		public override long Position 
		{
			get 
			{ 
				throw new NotSupportedException("Propriedade posi��o n�o suportada em portas seriais.");
			}
			set 
			{
				throw new NotSupportedException("Propriedade posi��o n�o suportada em portas seriais.");
			}
		}

		public bool Dtr 
		{
			set 
			{
				if (!EscapeCommFunction(m_hFile, value ? SETDTR : CLRDTR)) 
				{
					throw new Win32Exception();
				}
			}
		}

		public bool Rts 
		{
			set 
			{
				if (!EscapeCommFunction(m_hFile, value ? SETRTS : CLRRTS)) 
				{
					throw new Win32Exception();
				}
			}
		}

		public bool Break 
		{
			set 
			{
				if (!EscapeCommFunction(m_hFile, value ? SETBREAK : CLRBREAK)) 
				{
					throw new Win32Exception();
				}
			}
		}

		public bool Cts 
		{
			get 
			{
				uint status;
				if (!GetCommModemStatus(m_hFile, out status)) 
				{
					throw new Win32Exception();
				}
				return (status & MS_CTS_ON) > 0;
			}
		}

		public bool Dsr 
		{
			get 
			{
				uint status;
				if (!GetCommModemStatus(m_hFile, out status)) 
				{
					throw new Win32Exception();
				}
				return (status & MS_DSR_ON) > 0;
			}
		}

		public bool Ring 
		{
			get 
			{
				uint status;
				if (!GetCommModemStatus(m_hFile, out status)) 
				{
					throw new Win32Exception();
				}
				return (status & MS_RING_ON) > 0;
			}
		}

		public bool Rlsd 
		{
			get 
			{
				uint status;
				if (!GetCommModemStatus(m_hFile, out status)) 
				{
					throw new Win32Exception();
				}
				return (status & MS_RLSD_ON) > 0;
			}
		}

		#endregion Properties

		#region Constructors

		public clsSerialStream() : this(FileAccess.ReadWrite) 
		{
		}

		public clsSerialStream(FileAccess access) 
		{
			m_bRead  = ((int)access & (int)FileAccess.Read) != 0;
			m_bWrite = ((int)access & (int)FileAccess.Write) != 0;
			unsafe 
			{
				m_IOCompletionCallback += new IOCompletionCallback(AsyncFSCallback);
			}
		}

		public clsSerialStream(string port) : this(FileAccess.ReadWrite) 
		{
			Open(port);
		}

		public clsSerialStream(string port, FileAccess access) : this(access) 
		{
			Open(port);
		}

		#endregion Constructors

		#region Methods

		public void Open(string port) 
		{
			if (m_hFile != IntPtr.Zero) 
			{
				throw new IOException("Stream j� aberto.");
			}
			m_sPort = port;
			m_hFile = CreateFile(port, (uint)((m_bRead?GENERIC_READ:0)|(m_bWrite?GENERIC_WRITE:0)), 0, 0, OPEN_EXISTING, FILE_FLAG_OVERLAPPED, 0);
			if (m_hFile.ToInt32() == INVALID_HANDLE_VALUE) 
			{
				m_hFile = IntPtr.Zero;
				throw new FileNotFoundException("N�o foi poss�vel abrir " + port);
			}

			ThreadPool.BindHandle(m_hFile);

			SetTimeouts(0, 0, 0, 0, 0);
		}

		public override void Close() 
		{
			CloseHandle(m_hFile);
			m_hFile = IntPtr.Zero;
			m_sPort = null;
		}

		public IAsyncResult BeginRead(byte[] buffer) 
		{
			return BeginRead(buffer, 0, buffer.Length, null, null);
		}

		public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state) 
		{
			GCHandle gchBuffer = GCHandle.Alloc(buffer, GCHandleType.Pinned);
			SerialAsyncResult sar = new SerialAsyncResult(this, state, callback, true, gchBuffer);
			Overlapped ov = new Overlapped(0, 0, sar.AsyncWaitHandle.Handle.ToInt32(), sar);
			unsafe 
			{
				NativeOverlapped* nov = ov.Pack(m_IOCompletionCallback);
				byte* data = (byte*)((int)gchBuffer.AddrOfPinnedObject() + offset);

				uint read = 0;
				if (ReadFile(m_hFile, data, (uint)count, out read, nov)) 
				{
					sar.m_bCompletedSynchronously = true;
					return sar;
				}
				else if (GetLastError() == ERROR_IO_PENDING) 
				{
					return sar;
				}
				else
					throw new Exception("N�o foi poss�vel inicializar leitura. C�digo de erro: " + GetLastError().ToString());
			}
		}

		public IAsyncResult BeginWrite(byte[] buffer) 
		{
			return BeginWrite(buffer, 0, buffer.Length, null, null);
		}

		public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state) 
		{
			GCHandle gchBuffer = GCHandle.Alloc(buffer, GCHandleType.Pinned);
			SerialAsyncResult sar = new SerialAsyncResult(this, state, callback, false, gchBuffer);
			Overlapped ov = new Overlapped(0, 0, sar.AsyncWaitHandle.Handle.ToInt32(), sar);
			unsafe 
			{
				NativeOverlapped* nov = ov.Pack(m_IOCompletionCallback);
				byte* data = (byte*)((int)gchBuffer.AddrOfPinnedObject() + offset);

				uint written = 0;
				if (WriteFile(m_hFile, data, (uint)count, out written, nov)) 
				{
					sar.m_bCompletedSynchronously = true;
					return sar;
				}
				else if (GetLastError() == ERROR_IO_PENDING) 
				{
					return sar;
				}
				else
					throw new Exception("N�o foi poss�vel inicializar escrita. C�digo de erro: " + GetLastError().ToString());
			}
		}

		private int EndOperation(IAsyncResult asyncResult, bool isRead) 
		{
			SerialAsyncResult sar = (SerialAsyncResult)asyncResult;
			if (sar.m_bIsRead != isRead)
				throw new IOException("Par�metro inv�lido: IAsyncResult n�o � para " + (isRead ? "leitura" : "escrita"));
			if (sar.EndOperationCalled) 
			{
				throw new IOException("Fim" + (isRead ? "Leitura" : "Escrita") + " invocado duas vezes para a mesma opera��o.");
			}
			else 
			{
				sar.m_bEndOperationCalled = true;
				WaitHandle waitTemp = sar.AsyncWaitHandle;
				if (eCallSetaWaitHandle != null)
					eCallSetaWaitHandle(ref waitTemp);
			}

			while (!sar.m_bCompleted) 
			{
				System.Console.WriteLine("Entrou no while que espera o Handle");//Testando
				try
				{
					sar.AsyncWaitHandle.WaitOne();
				}
				catch
				{
					break;
				}
			}
			System.Console.WriteLine("Saiu do while que espera o Handle");//Testando

			sar.Dispose();

			if (sar.m_nErrorCode != ERROR_SUCCESS && sar.m_nErrorCode != ERROR_OPERATION_ABORTED) 
			{
				throw new IOException("Opera��o terminado com c�digo de erro: " + sar.m_nErrorCode);
			}

			return sar.m_nReadWritten;
		}
		
		public override int EndRead(IAsyncResult asyncResult) 
		{
			return EndOperation(asyncResult, true);
		}
		
		public override void EndWrite(IAsyncResult asyncResult) 
		{
			EndOperation(asyncResult, false);
		}

		public int EndWriteEx(IAsyncResult asyncResult) 
		{
			return EndOperation(asyncResult, false);
		}

		public override int Read(byte[] buffer, int offset, int count) 
		{
			return EndRead(BeginRead(buffer, offset, count, null, null));
		}

		public override void Write(byte[] buffer, int offset, int count) 
		{
			EndWrite(BeginWrite(buffer, offset, count, null, null));
		}

		public int WriteEx(byte[] buffer, int offset, int count) 
		{
			return EndWriteEx(BeginWrite(buffer, offset, count, null, null));
		}

		public int Read(byte[] buffer) 
		{
			return EndRead(BeginRead(buffer, 0, buffer.Length, null, null));
		}

		public int Write(byte[] buffer) 
		{
			return EndOperation(BeginWrite(buffer, 0, buffer.Length, null, null), false);
		}

		public override void Flush() 
		{
			FlushFileBuffers(m_hFile);
		}

		public bool PurgeRead() 
		{
			return PurgeComm(m_hFile, PURGE_RXCLEAR);
		}

		public bool PurgeWrite() 
		{
			return PurgeComm(m_hFile, PURGE_TXCLEAR);
		}

		public bool Purge() 
		{
			return PurgeRead() && PurgeWrite();
		}

		public bool CancelRead() 
		{
			return PurgeComm(m_hFile, PURGE_RXABORT);
		}

		public bool CancelWrite() 
		{
			return PurgeComm(m_hFile, PURGE_TXABORT);
		}

		public bool CancelAll() 
		{
			return CancelRead() && CancelWrite();
		}

		public override void SetLength(long nLength) 
		{
			throw new NotSupportedException("SetLength n�o suportado em portas seriais.");
		}

		public override long Seek(long offset, SeekOrigin origin) 
		{
			throw new NotSupportedException("Seek n�o suportado em portas seriais.");
		}

		public void SetTimeouts(int ReadIntervalTimeout,
			int ReadTotalTimeoutMultiplier,
			int ReadTotalTimeoutConstant, 
			int WriteTotalTimeoutMultiplier,
			int WriteTotalTimeoutConstant) 
		{
			SerialTimeouts Timeouts = new SerialTimeouts(ReadIntervalTimeout,
				ReadTotalTimeoutMultiplier,
				ReadTotalTimeoutConstant, 
				WriteTotalTimeoutMultiplier,
				WriteTotalTimeoutConstant);
			unsafe { SetCommTimeouts(m_hFile, ref Timeouts); }
		}

		public bool SetPortSettings(uint baudrate) 
		{
			return SetPortSettings(baudrate, FlowControl.Hardware);
		}

		public bool SetPortSettings(uint baudrate, FlowControl flowControl) 
		{
			return SetPortSettings(baudrate, flowControl, Parity.None);
		}

		public bool SetPortSettings(uint baudrate, FlowControl flowControl, Parity parity) 
		{
			return SetPortSettings(baudrate, flowControl, parity, 8, StopBits.One);
		}

		public bool SetPortSettings(uint baudrate, FlowControl flowControl, Parity parity, byte databits, StopBits stopbits) 
		{
			unsafe 
			{
				DCB dcb = new DCB();
				dcb.DCBlength = sizeof(DCB);
				dcb.BaudRate = baudrate;
				dcb.ByteSize = databits;
				dcb.StopBits = (byte)stopbits;
				dcb.Parity = (byte)parity;
				dcb.fParity = (parity > 0)? 1U : 0U;
				dcb.fBinary = dcb.fDtrControl = dcb.fTXContinueOnXoff = 1;
				dcb.fOutxCtsFlow = dcb.fAbortOnError = (flowControl == FlowControl.Hardware)? 1U : 0U;
				dcb.fOutX = dcb.fInX = (flowControl == FlowControl.XOnXOff)? 1U : 0U;
				dcb.fRtsControl = (flowControl == FlowControl.Hardware)? 2U : 1U;
				dcb.XonLim = 2048;
				dcb.XoffLim = 512;
				dcb.XonChar = 0x11; // Ctrl-Q
				dcb.XoffChar = 0x13; // Ctrl-S
				return SetCommState(m_hFile, ref dcb);
			}
		}

		public bool SetPortSettings(DCB dcb) 
		{
			return SetCommState(m_hFile, ref dcb);
		}

		public bool GetPortSettings(out DCB dcb) 
		{
			unsafe 
			{
				DCB dcb2 = new DCB();
				dcb2.DCBlength = sizeof(DCB);
				bool ret = GetCommState(m_hFile, ref dcb2);
				dcb = dcb2;
				return ret;
			}
		}

		public bool SetXOn() 
		{
			return EscapeCommFunction(m_hFile, SETXON);
		}

		public bool SetXOff() 
		{
			return EscapeCommFunction(m_hFile, SETXOFF);
		}

		private unsafe void AsyncFSCallback(uint errorCode, uint numBytes, NativeOverlapped* pOverlapped) 
		{
			SerialAsyncResult sar = (SerialAsyncResult)Overlapped.Unpack(pOverlapped).AsyncResult;

			sar.m_nErrorCode = errorCode;
			sar.m_nReadWritten = (int)numBytes;
			sar.m_bCompleted = true;

			if (sar.Callback != null)
				sar.Callback.Invoke(sar);

			Overlapped.Free(pOverlapped);
		}

		#endregion Methods

		#region Constants

		private const uint PURGE_TXABORT = 0x0001;  // Destr�i escritas pendentes/correntas na porta COM.
		private const uint PURGE_RXABORT = 0x0002;  // Destr�i leituras pendentes/correntas na porta COM.
		private const uint PURGE_TXCLEAR = 0x0004;  // Destr�i fila de transmiss�o caso exista.
		private const uint PURGE_RXCLEAR = 0x0008;  // Destr�i typeahead buffer caso exista.

		private const uint SETXOFF  = 1;	// Simula recep��o XOFF.
		private const uint SETXON   = 2;	// Simula recep��o XON.
		private const uint SETRTS	= 3;	// Seta RTS alto.
		private const uint CLRRTS	= 4;	// Seta RTS baixo.
		private const uint SETDTR	= 5;	// Seta DTR alto.
		private const uint CLRDTR	= 6;	// Seta DTR baixo.
		private const uint SETBREAK	= 8;	// Seta a quebra de linha do dispositivo.
		private const uint CLRBREAK	= 9;	// Limpa a quebra de linha do dispositivo.

		private const uint MS_CTS_ON  = 0x0010;
		private const uint MS_DSR_ON  = 0x0020;
		private const uint MS_RING_ON = 0x0040;
		private const uint MS_RLSD_ON = 0x0080;

		private const uint FILE_FLAG_OVERLAPPED = 0x40000000;

		private const uint OPEN_EXISTING = 3;

		private const int  INVALID_HANDLE_VALUE = -1;

		private const uint GENERIC_READ = 0x80000000;
		private const uint GENERIC_WRITE = 0x40000000;

		private const uint ERROR_SUCCESS = 0;
		private const uint ERROR_OPERATION_ABORTED = 995;
		private const uint ERROR_IO_PENDING = 997;

		#endregion Constants

		#region Enums

		public enum Parity {None, Odd, Even, Mark, Space};
		public enum StopBits {One, OneAndHalf, Two};
		public enum FlowControl {None, XOnXOff, Hardware};

		#endregion Enums

		#region Classes

		[StructLayout(LayoutKind.Sequential)]
		public struct DCB 
		{

			#region Attributes

			public int DCBlength;
			public uint BaudRate;
			public uint Flags;
			public ushort wReserved;
			public ushort XonLim;
			public ushort XoffLim;
			public byte ByteSize;
			public byte Parity;
			public byte StopBits;
			public sbyte XonChar;
			public sbyte XoffChar;
			public sbyte ErrorChar;
			public sbyte EofChar;
			public sbyte EvtChar;
			public ushort wReserved1;

			#endregion Attributes

			#region Properties

			public uint fBinary { get { return Flags&0x0001; } 
				set { Flags = Flags & ~1U | value; } 
			}
			public uint fParity { get { return (Flags>>1)&1; }
				set { Flags = Flags & ~(1U << 1) | (value << 1); } 
			}
			public uint fOutxCtsFlow { get { return (Flags>>2)&1; }
				set { Flags = Flags & ~(1U << 2) | (value << 2); } 
			}
			public uint fOutxDsrFlow { get { return (Flags>>3)&1; }
				set { Flags = Flags & ~(1U << 3) | (value << 3); } 
			}
			public uint fDtrControl { get { return (Flags>>4)&3; }
				set { Flags = Flags & ~(3U << 4) | (value << 4); } 
			}
			public uint fDsrSensitivity { get { return (Flags>>6)&1; }
				set { Flags = Flags & ~(1U << 6) | (value << 6); } 
			}
			public uint fTXContinueOnXoff { get { return (Flags>>7)&1; }
				set { Flags = Flags & ~(1U << 7) | (value << 7); } 
			}
			public uint fOutX { get { return (Flags>>8)&1; }
				set { Flags = Flags & ~(1U << 8) | (value << 8); } 
			}
			public uint fInX { get { return (Flags>>9)&1; }
				set { Flags = Flags & ~(1U << 9) | (value << 9); } 
			}
			public uint fErrorChar { get { return (Flags>>10)&1; }
				set { Flags = Flags & ~(1U << 10) | (value << 10); } 
			}
			public uint fNull { get { return (Flags>>11)&1; }
				set { Flags = Flags & ~(1U << 11) | (value << 11); } 
			}
			public uint fRtsControl { get { return (Flags>>12)&3; }
				set { Flags = Flags & ~(3U << 12) | (value << 12); } 
			}
			public uint fAbortOnError { get { return (Flags>>13)&1; }
				set { Flags = Flags & ~(1U << 13) | (value << 13); } 
			}

			#endregion Properties

			#region Methods

			public override string ToString() 
			{
				return "DCBlength: " + DCBlength + "\r\n" +
					"BaudRate: " + BaudRate + "\r\n" +
					"fBinary: " + fBinary + "\r\n" +
					"fParity: " + fParity + "\r\n" +
					"fOutxCtsFlow: " + fOutxCtsFlow + "\r\n" +
					"fOutxDsrFlow: " + fOutxDsrFlow + "\r\n" +
					"fDtrControl: " + fDtrControl + "\r\n" +
					"fDsrSensitivity: " + fDsrSensitivity + "\r\n" +
					"fTXContinueOnXoff: " + fTXContinueOnXoff + "\r\n" +
					"fOutX: " + fOutX + "\r\n" +
					"fInX: " + fInX + "\r\n" +
					"fErrorChar: " + fErrorChar + "\r\n" +
					"fNull: " + fNull + "\r\n" +
					"fRtsControl: " + fRtsControl + "\r\n" +
					"fAbortOnError: " + fAbortOnError + "\r\n" +
					"XonLim: " + XonLim + "\r\n" +
					"XoffLim: " + XoffLim + "\r\n" +
					"ByteSize: " + ByteSize + "\r\n" +
					"Parity: " + Parity + "\r\n" +
					"StopBits: " + StopBits + "\r\n" +
					"XonChar: " + XonChar + "\r\n" +
					"XoffChar: " + XoffChar + "\r\n" +
					"EofChar: " + EofChar + "\r\n" +
					"EvtChar: " + EvtChar + "\r\n";
			}

			#endregion Methods
		}

		private class SerialAsyncResult : IAsyncResult, IDisposable 
		{

			#region Attributes

			internal bool m_bEndOperationCalled = false;
			internal bool m_bIsRead;
			internal int m_nReadWritten = 0;
			internal bool m_bCompleted = false;
			internal bool m_bCompletedSynchronously = false;
			internal uint m_nErrorCode = ERROR_SUCCESS;

			private object m_AsyncObject;
			private object m_StateObject;
			internal ManualResetEvent m_WaitHandle = new ManualResetEvent(false);
			private AsyncCallback m_Callback;
			private GCHandle m_gchBuffer;

			#endregion Attributes

			#region Properties

			internal bool EndOperationCalled { get { return m_bEndOperationCalled; } }

			public bool IsCompleted { get { return m_bCompleted; } }

			public bool CompletedSynchronously { get { return m_bCompletedSynchronously; } }

			public object AsyncObject { get { return m_AsyncObject; } }

			public object AsyncState { get { return m_StateObject; } }

			public WaitHandle AsyncWaitHandle { get { return m_WaitHandle; } }
			internal ManualResetEvent WaitHandle { get { return m_WaitHandle; } }

			public AsyncCallback Callback { get { return m_Callback; } }

			#endregion Properties

			#region Constructors

			public SerialAsyncResult(object asyncObject,
				object stateObject, 
				AsyncCallback callback, 
				bool bIsRead, 
				GCHandle gchBuffer) 
			{

				m_AsyncObject = asyncObject;
				m_StateObject = stateObject;
				m_Callback = callback;
				m_bIsRead = bIsRead;
				m_gchBuffer = gchBuffer;
			}

			#endregion Constructors

			#region Methods

			public void Dispose() 
			{
				m_WaitHandle.Close();
				m_gchBuffer.Free();
			}

			#endregion Methods
		}

		#endregion Classes

		#region Imports

		[DllImport("kernel32.dll", EntryPoint="CreateFileW",  SetLastError=true,
			 CharSet=CharSet.Unicode, ExactSpelling=true)]
		static extern IntPtr CreateFile(string filename, uint access, uint sharemode, uint security_attributes, uint creation, uint flags, uint template);

		[DllImport("kernel32.dll", SetLastError=true)]
		static extern bool CloseHandle(IntPtr handle);

		[DllImport("kernel32.dll", SetLastError=true)]
		static extern unsafe bool ReadFile(IntPtr hFile, byte* lpBuffer, uint nNumberOfBytesToRead, out uint lpNumberOfBytesRead, NativeOverlapped* lpOverlapped);

		[DllImport("kernel32.dll", SetLastError=true)]
		static extern unsafe bool WriteFile(IntPtr hFile, byte* lpBuffer, uint nNumberOfBytesToWrite, out uint lpNumberOfBytesWritten, NativeOverlapped* lpOverlapped);

		[DllImport("kernel32.dll", SetLastError=true)]
		static extern bool SetCommTimeouts(IntPtr hFile, ref SerialTimeouts lpCommTimeouts);

		[DllImport("kernel32.dll", SetLastError=true)]
		static extern bool SetCommState(IntPtr hFile, ref DCB lpDCB);

		[DllImport("kernel32.dll", SetLastError=true)]
		static extern bool GetCommState(IntPtr hFile, ref DCB lpDCB);

		[DllImport("kernel32.dll", SetLastError=true)]
		static extern bool BuildCommDCB(string def, ref DCB lpDCB);

		[DllImport("kernel32.dll", SetLastError=true)]
		static extern int GetLastError();

		[DllImport("kernel32.dll", SetLastError=true)]
		static extern bool FlushFileBuffers(IntPtr hFile);

		[DllImport("kernel32.dll", SetLastError=true)]
		static extern bool PurgeComm(IntPtr hFile, uint dwFlags);

		[DllImport("kernel32.dll", SetLastError=true)]
		static extern bool EscapeCommFunction(IntPtr hFile, uint dwFunc);

		[DllImport("kernel32.dll", SetLastError=true)]
		static extern bool GetCommModemStatus(IntPtr hFile, out uint modemStat);

		#endregion Imports
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct SerialTimeouts 
	{

		#region Attributes

		public int ReadIntervalTimeout;
		public int ReadTotalTimeoutMultiplier;
		public int ReadTotalTimeoutConstant;
		public int WriteTotalTimeoutMultiplier;
		public int WriteTotalTimeoutConstant;

		#endregion Attributes

		#region Constructors

		public SerialTimeouts(int r1, int r2, int r3, int w1, int w2) 
		{
			ReadIntervalTimeout = r1;
			ReadTotalTimeoutMultiplier = r2;
			ReadTotalTimeoutConstant = r3;
			WriteTotalTimeoutMultiplier = w1;
			WriteTotalTimeoutConstant = w2;
		}

		#endregion Constructors

		#region Methods

		public override string ToString() 
		{
			return "ReadIntervalTimeout: " + ReadIntervalTimeout + "\r\n" +
				"ReadTotalTimeoutMultiplier: " + ReadTotalTimeoutMultiplier + "\r\n" +
				"ReadTotalTimeoutConstant: " + ReadTotalTimeoutConstant + "\r\n" +
				"WriteTotalTimeoutMultiplier: " + WriteTotalTimeoutMultiplier + "\r\n" +
				"WriteTotalTimeoutConstant: " + WriteTotalTimeoutConstant + "\r\n";
		}

		#endregion Methods
	}
}
