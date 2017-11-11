using System;
using System.Net;

namespace mdlInet
{
	#region clsPing
	public class clsPing
	{
		#region Constructor
		public clsPing()
		{
		}

		static clsPing() 
		{
			m_Comparer = new mdlComponentesColecoes.clsComparerNumbersTexts();
		}
		#endregion

		#region ICMP Protocol
			#region Atributos
			internal static System.Collections.IComparer m_Comparer;
			#endregion
			#region ICMP Errors
			public enum ICMPErrors 
			{
				ERROR_NONE = 0,
				ERROR_UNKNOW = -1,
				ERROR_INVALID_HOST = -2,
				ERROR_CONSTRUCTING_PACKET = -3,
				ERROR_CANNOT_SEND_PACKET = -4,
				ERROR_HOST_TIMEOUT = -5,
				ERROR_NO_MEMORY_AVAIBLE = -6,
				ERROR_NO_HOST_AVAIBLE = -7
			}
			#endregion
			#region Constants
			internal const int SOCKET_ERROR = -1;
			internal const int ICMP_ECHO = 8;
			internal const string HOST_TO_TEST = "www.google.com.br";
			internal const string URL_TO_TEST = "http://www.siscobras.com.br/index.htm";
			#endregion
			#region IcmpPacket
			internal class IcmpPacket
			{
				public Byte Type;
				public Byte SubCode;
				public UInt16 CheckSum;
				public UInt16 Identifier;
				public UInt16 SequenceNumber;
				public Byte[] Data;
			}
			#endregion
			#region Utilities
			internal static Int32 Serialize( IcmpPacket packet, Byte [] Buffer, Int32 PacketSize, Int32 PingData )
			{
				Int32 cbReturn = 0;
				int Index=0;

				Byte [] b_type = new Byte[1];
				b_type[0] = (packet.Type);

				Byte [] b_code = new Byte[1];
				b_code[0] = (packet.SubCode);

				Byte [] b_cksum = BitConverter.GetBytes(packet.CheckSum);
				Byte [] b_id = BitConverter.GetBytes(packet.Identifier);
				Byte [] b_seq = BitConverter.GetBytes(packet.SequenceNumber);

				Array.Copy( b_type, 0, Buffer, Index, b_type.Length );
				Index += b_type.Length;

				Array.Copy( b_code, 0, Buffer, Index, b_code.Length );
				Index += b_code.Length;

				Array.Copy( b_cksum, 0, Buffer, Index, b_cksum.Length );
				Index += b_cksum.Length;

				Array.Copy( b_id, 0, Buffer, Index, b_id.Length );
				Index += b_id.Length;

				Array.Copy( b_seq, 0, Buffer, Index, b_seq.Length );
				Index += b_seq.Length;

				Array.Copy( packet.Data, 0, Buffer, Index, PingData );
				Index += PingData;
				if( Index != PacketSize/* sizeof(IcmpPacket) */)
				{
					cbReturn = -1;
					return cbReturn;
				}

				cbReturn = Index;
				return cbReturn;
			}

			internal static UInt16 checksum( UInt16[] buffer, int size )
			{
				Int32 cksum = 0;
				int counter;

				counter = 0;

				while ( size > 0 )
				{

					UInt16 val = buffer[counter];

					cksum += Convert.ToInt32( buffer[counter] );
					counter += 1;
					size -= 1;
				}

				cksum = (cksum >> 16) + (cksum & 0xffff);
				cksum += (cksum >> 16);
				return (UInt16)(~cksum);
			}
			#endregion
			#region PingHost
			public static ICMPErrors PingHost(string host, out int dwStop)
			{
				System.Net.IPHostEntry serverHE, fromHE;
				int nBytes = 0;
				int dwStart = 0;
				dwStop = 0;

				try 
				{
					System.Net.Sockets.Socket socket = new System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Raw, System.Net.Sockets.ProtocolType.Icmp);

					try
					{
						serverHE = System.Net.Dns.GetHostByName(host);
					}
					catch(Exception)
					{
						return ICMPErrors.ERROR_INVALID_HOST;
					}

					System.Net.IPEndPoint ipepServer = new System.Net.IPEndPoint(serverHE.AddressList[0], 0);
					System.Net.EndPoint epServer = (ipepServer);

					fromHE = System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName());
					System.Net.IPEndPoint ipEndPointFrom = new System.Net.IPEndPoint(fromHE.AddressList[0], 0);
					System.Net.EndPoint EndPointFrom = (ipEndPointFrom);

					int PacketSize = 0;
					IcmpPacket packet = new IcmpPacket();

					packet.Type = ICMP_ECHO;
					packet.SubCode = 0;
					packet.CheckSum = UInt16.Parse("0");
					packet.Identifier = UInt16.Parse("45");
					packet.SequenceNumber = UInt16.Parse("0");
					int PingData = 32;
					packet.Data = new Byte[PingData];

					for (int i = 0; i < PingData; i++)
					{
						packet.Data[i] = (byte)'#';
					}

					PacketSize = PingData + 8;
					Byte [] icmp_pkt_buffer = new Byte[ PacketSize ];
					Int32 Index = 0;

					Index = Serialize (packet, icmp_pkt_buffer, PacketSize, PingData);
					if( Index == -1 )
					{
						return ICMPErrors.ERROR_CONSTRUCTING_PACKET;
					}

					Double double_length = Convert.ToDouble(Index);
					Double dtemp = System.Math.Ceiling( double_length / 2);
					int cksum_buffer_length = Convert.ToInt32(dtemp);
					UInt16 [] cksum_buffer = new UInt16[cksum_buffer_length];
					int icmp_header_buffer_index = 0;
					for( int i = 0; i < cksum_buffer_length; i++ )
					{
						cksum_buffer[i] = BitConverter.ToUInt16(icmp_pkt_buffer,icmp_header_buffer_index);
						icmp_header_buffer_index += 2;
					}

					UInt16 u_cksum = checksum(cksum_buffer, cksum_buffer_length);
					packet.CheckSum = u_cksum;

					Byte [] sendbuf = new Byte[ PacketSize ];
					Index = Serialize(packet, sendbuf, PacketSize, PingData );
					if( Index == -1 )
					{
						return ICMPErrors.ERROR_CONSTRUCTING_PACKET;
					}

					dwStart = System.Environment.TickCount;
					if ((nBytes = socket.SendTo(sendbuf, PacketSize, 0, epServer)) == SOCKET_ERROR)
					{
						return ICMPErrors.ERROR_CANNOT_SEND_PACKET;
					}

					System.Collections.ArrayList arrSocket = new System.Collections.ArrayList();

					for (int i = 0; i < 5; i++) 
					{
						arrSocket.Add (socket);

						System.Net.Sockets.Socket.Select (arrSocket, null, null, 1000000);
						if (socket.Available > 0) 
						{
							dwStop = System.Environment.TickCount - dwStart;
							socket.Close();
							return ICMPErrors.ERROR_NONE;
						}
					}
				}
				catch (System.Exception) 
				{
					dwStop = -1;
					return ICMPErrors.ERROR_UNKNOW;
				}

				dwStop = -1;
				return ICMPErrors.ERROR_HOST_TIMEOUT;
			}
			#endregion
			#region PingList
			public static ICMPErrors PingList (ref System.Collections.ArrayList arrLstURLIn, out System.Collections.SortedList arrLstURLOut) 
			{
				return PingList (ref arrLstURLIn, out arrLstURLOut, false, null);
			}

			public static ICMPErrors PingList (ref System.Collections.ArrayList arrLstURLIn, out System.Collections.SortedList arrLstURLOut, bool bLog, string strName) 
			{
				int nResponse;

				arrLstURLOut = new System.Collections.SortedList (m_Comparer);
				if (arrLstURLOut == null) 
				{
					return ICMPErrors.ERROR_NO_MEMORY_AVAIBLE;
				}

				if (bLog) 
				{
					object[] arrParametros = new object[3];
					arrParametros[0] = "URL";
					arrParametros[1] = "Host";
					arrParametros[2] = "TR";
					mdlMedidorTempo.clsMedidorTempo.IniciaMedicao (strName, arrParametros);
				}

				for (int i = 0; i < arrLstURLIn.Count; i++) 
				{
					System.Uri uri = new Uri ((String) arrLstURLIn[i], false);
					if (PingHost (uri.Host, out nResponse) == ICMPErrors.ERROR_NONE) 
					{
						try 
						{
							arrLstURLOut.Add (nResponse, arrLstURLIn[i]);

							if (bLog) 
							{
								object[] arrValores = new object[3];
								arrValores[0] = arrLstURLIn[i];
								arrValores[1] = uri.Host;
								arrValores[2] = nResponse;
								mdlMedidorTempo.clsMedidorTempo.FinalizaMedicao (strName, (i+1) == arrLstURLIn.Count, arrValores);
							}
						} 
						catch (System.Exception) 
						{
						}
					} 
					else 
					{
						if (bLog) 
						{
							object[] arrValores = new object[3];
							arrValores[0] = arrLstURLIn[i];
							arrValores[1] = uri.Host;
							arrValores[2] = "TIMEOUT";
							mdlMedidorTempo.clsMedidorTempo.FinalizaMedicao ("TR WS", (i+1) == arrLstURLIn.Count, arrValores);
						}
					}
				}

				if (arrLstURLOut.Count > 0) 
				{
					return ICMPErrors.ERROR_NONE;
				} 
				else 
				{
					return ICMPErrors.ERROR_NO_HOST_AVAIBLE;
				}
			}
			#endregion
			#region PingHostHttp
				public static ICMPErrors PingHostHttp(string url, out int dwStop)
				{
					dwStop = -1;
					try
					{
						int dtInicio, dtFim;
						System.Net.HttpWebRequest hwrReq = null;
						System.Net.HttpWebResponse hwrRes = null;
						dtInicio = System.Environment.TickCount;
						try 
						{
							hwrReq = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(new System.Uri(url));
							hwrRes = (System.Net.HttpWebResponse)hwrReq.GetResponse();
						} 
						catch 
						{
							return ICMPErrors.ERROR_UNKNOW;
						}
						finally 
						{
							if (hwrRes != null)
								hwrRes.Close();
						}
						dtFim = System.Environment.TickCount;
						dwStop = dtFim - dtInicio;
						return (ICMPErrors.ERROR_NONE);
					}
					catch
					{
						return (ICMPErrors.ERROR_UNKNOW);
					}
				}
			#endregion
			#region PingListHttp
			public static ICMPErrors PingListHttp (ref System.Collections.ArrayList arrLstURLIn, out System.Collections.SortedList arrLstURLOut) 
			{
				return PingListHttp (ref arrLstURLIn, out arrLstURLOut, false, null);
			}

			public static ICMPErrors PingListHttp (ref System.Collections.ArrayList arrLstURLIn, out System.Collections.SortedList arrLstURLOut, bool bLog, string strName) 
			{
				int nResponse;

				arrLstURLOut = new System.Collections.SortedList (m_Comparer);
				if (arrLstURLOut == null) 
				{
					return ICMPErrors.ERROR_NO_MEMORY_AVAIBLE;
				}

				if (bLog) 
				{
					object[] arrParametros = new object[3];
					arrParametros[0] = "URL";
					arrParametros[1] = "Host";
					arrParametros[2] = "TR";
					mdlMedidorTempo.clsMedidorTempo.IniciaMedicao (strName, arrParametros);
				}

				for (int i = 0; i < arrLstURLIn.Count; i++) 
				{
					try
					{
						if (PingHostHttp ((String) arrLstURLIn[i], out nResponse) == ICMPErrors.ERROR_NONE) 
						{
							try 
							{
								arrLstURLOut.Add (nResponse, arrLstURLIn[i]);

								if (bLog) 
								{
									object[] arrValores = new object[3];
									arrValores[0] = arrLstURLIn[i];
									arrValores[1] = arrLstURLIn[i];
									arrValores[2] = nResponse;
									mdlMedidorTempo.clsMedidorTempo.FinalizaMedicao (strName, (i+1) == arrLstURLIn.Count, arrValores);
								}
							} 
							catch (System.Exception) 
							{
							}
						} 
						else 
						{
							if (bLog) 
							{
								object[] arrValores = new object[3];
								arrValores[0] = arrLstURLIn[i];
								arrValores[1] = arrLstURLIn[i];
								arrValores[2] = "TIMEOUT";
								mdlMedidorTempo.clsMedidorTempo.FinalizaMedicao ("TR WS", (i+1) == arrLstURLIn.Count, arrValores);
							}
						}
					}catch{

					}
				}

				if (arrLstURLOut.Count > 0) 
				{
					return ICMPErrors.ERROR_NONE;
				} 
				else 
				{
					return ICMPErrors.ERROR_NO_HOST_AVAIBLE;
				}
			}
			#endregion
			#region bEstaConectado
			public static bool bEstaConectado() 
			{
				int dwStop;
				return PingHostHttp(URL_TO_TEST, out dwStop) == mdlInet.clsPing.ICMPErrors.ERROR_NONE;
			}
			#endregion
		#endregion
	}
	#endregion

	#region clsDownloadManager
	public class clsDownloadManager 
	{
		#region structDownloadFile
		public struct structDownloadFile 
		{
			public System.Collections.ArrayList m_arrMirrorURL;
			public string m_strFilename;
			public long m_nFileSize;
			public int m_nIdModulo;
		}
		#endregion
		#region clsDownloadFile
		internal class clsDownloadFile 
		{
			#region Atributos
			private System.Collections.ArrayList m_arrURLs;
			private System.Collections.SortedList m_arrURLSorted;
			private string m_strFile;
			private long m_nFileSize;
			private int m_nTentaivas;
			private bool m_bOK;
			#endregion
			#region Propriedades
				public long Size
				{
					set
					{
						m_nFileSize = value;
					}
				}
			#endregion
			#region Constructor
			public clsDownloadFile (ref System.Collections.ArrayList strURLs, string strFile, long nFileSize)
			{
				m_arrURLs = strURLs;
				m_strFile = strFile;
				m_arrURLSorted = null;
				m_nFileSize = nFileSize;
				m_nTentaivas = 0;
				m_bOK = false;
			}
			#endregion

			#region Public
			public bool DownloadFile (long nFileSize) 
			{
				System.Net.WebClient webClient = null;
				System.IO.Stream stream = null;
				System.IO.BinaryWriter m_strmFileWriter = null;
				byte[] strBuffer = new byte[1025];
				int length = 1024, bytesread;
				long fileSize = 0, contentLength, nTotalBytesPerInterval;
				System.DateTime dtTempoAnterior, dtTempoAtual;
				double dTaxa;

				m_nTentaivas++;

				if (m_arrURLSorted == null) 
				{
					if (SetupURLList() == false) 
					{
						return false;
					}
					if (m_arrURLSorted == null || m_arrURLSorted.Count == 0)
					{
						return false;
					}
				}

				webClient = new System.Net.WebClient();

				for (int i = 0; i < m_arrURLSorted.Count; i++) 
				{
					try 
					{
						try 
						{
							stream = webClient.OpenRead ((string) m_arrURLSorted.GetByIndex(i));
						} 
						catch (System.Net.WebException) 
						{
							continue;
						} 
						catch (System.Exception) 
						{
							webClient = null;
							return false;
						}
						contentLength = System.Int64.Parse (webClient.ResponseHeaders.Get("Content-Length"));

						if (nFileSize >= 0) 
						{
							if (System.IO.File.Exists (m_strFile)) 
							{
								System.IO.FileInfo tmpFile = new System.IO.FileInfo (m_strFile);
								long nDiscFileSize = tmpFile.Length;

								if (nFileSize == contentLength && nDiscFileSize == contentLength) 
								{
									OnCallFeedback (nFileSize, nFileSize);
									m_bOK = true;
									return true;
								}

								if (nFileSize != contentLength) 
								{
									fileSize = contentLength;
								} 
								else 
								{
									fileSize = nFileSize;
								}

								if (fileSize != nDiscFileSize) 
								{
									System.IO.File.Delete (m_strFile);
								}
							} 
							else 
							{
								fileSize = contentLength;
							}
						} 
						else 
						{
							m_nFileSize = fileSize;
							fileSize = contentLength;
						}

						try 
						{
							m_strmFileWriter = new System.IO.BinaryWriter (new System.IO.FileStream (m_strFile, System.IO.FileMode.CreateNew, System.IO.FileAccess.Write, System.IO.FileShare.None));
							if (m_strmFileWriter == null) 
							{
								webClient = null;
								return false;
							}
						} 
						catch (System.Exception) 
						{
							webClient = null;
							return false;
						}

						dtTempoAnterior = System.DateTime.Now;
						nTotalBytesPerInterval = 0;
						do 
						{
							bytesread = stream.Read (strBuffer, 0, length);
							if (bytesread > 0) 
							{
								dtTempoAtual = System.DateTime.Now;

								m_strmFileWriter.Write (strBuffer, 0, bytesread);
								fileSize -= bytesread;
								nTotalBytesPerInterval += bytesread;

								OnCallFeedback (nFileSize, nFileSize - fileSize);

								System.TimeSpan tDiff = dtTempoAtual.Subtract (dtTempoAnterior);
								if (tDiff.TotalSeconds >= 0.5) 
								{
									dTaxa = nTotalBytesPerInterval / tDiff.TotalSeconds;
									OnCallTimeFeedback (dTaxa, fileSize / dTaxa, nFileSize - fileSize);

									dtTempoAnterior = dtTempoAtual;
									nTotalBytesPerInterval = 0;
								}
							}
						} while (bytesread > 0);
					} 
					finally 
					{
						if (m_strmFileWriter != null) 
						{
							m_strmFileWriter.Close();
						}
						if (stream != null) 
						{
							stream.Close();
						}
					}

					if (fileSize == 0) 
					{
						webClient = null;
						m_bOK = true;
						return true;
					}
				}

				webClient = null;
				return false;
			}

			public bool RequestFileSize (out long nFileSize) 
			{
				System.Net.HttpWebRequest webRequest = null;
				System.Net.HttpWebResponse webResponse = null;

				nFileSize = 0;

				if (m_arrURLSorted == null) 
				{
					if (SetupURLList() == false) 
					{
						return false;
					}
					if (m_arrURLSorted == null || m_arrURLSorted.Count == 0)
					{
						return false;
					}
				}

				for (int i = 0; i < m_arrURLSorted.Count; i++) 
				{
					try 
					{
						webRequest = (System.Net.HttpWebRequest) System.Net.WebRequest.Create((string) m_arrURLSorted.GetByIndex(i));
						webRequest.Timeout = 10000;
						webResponse = (System.Net.HttpWebResponse) webRequest.GetResponse();

						nFileSize = webResponse.ContentLength;

						webResponse.Close();
						break;
					} 
					catch (System.Net.WebException) 
					{
						continue;
					} 
					catch (System.Exception) 
					{
						nFileSize = -1;
						return false;
					}
				}

				return true;
			}
			#endregion
			#region Get & Set
			public long GetFileSize() 
			{
				return m_nFileSize;
			}

			public string GetFileName() 
			{
				return m_strFile;
			}

			public void SetFileSize (long nSize) 
			{
				m_nFileSize = nSize;
			}

			public int GetTentativas() 
			{
				return m_nTentaivas;
			}

			public bool GetOK() 
			{
				return m_bOK;
			}
			#endregion
			#region Private
			private bool SetupURLList() 
			{
				m_arrURLSorted = null;

				if (mdlInet.clsPing.PingListHttp (ref m_arrURLs, out m_arrURLSorted) == mdlInet.clsPing.ICMPErrors.ERROR_NONE) 
				{
					return true;
				} 
				else
				{
					return false;
				}
			}
			#endregion

			#region Delegate
			public delegate void delCallFeedback (long nTotalBytes, long nTotalBytesTransfered);
			public delegate void delCallTimeFeedback (double dTxTransferencia, double nTempoEstimado, long nTotalBytesTransfered);
			#endregion
			#region Event
			public event delCallFeedback eCallFeedback;
			public event delCallTimeFeedback eCallTimeFeedback;
			#endregion
			#region Event Method
			private void OnCallFeedback (long nTotalBytes, long nTotalBytesTransfered) 
			{
				if (eCallFeedback != null) 
				{
					eCallFeedback (nTotalBytes, nTotalBytesTransfered);
				}
			}

			private void OnCallTimeFeedback (double dTxTransferencia, double dTempoEstimado, long nTotalBytesTransfered) 
			{
				if (eCallTimeFeedback != null) 
				{
					eCallTimeFeedback (dTxTransferencia, dTempoEstimado, nTotalBytesTransfered);
				}
			}
			#endregion
		}
		#endregion

		#region Atributos
		private mdlInet.clsDownloadManager.clsDownloadFile m_CurDownload;
		private long m_TotalBytes;
		private long m_TotalBytesTransfered;
		#endregion
		#region Constructor
		public clsDownloadManager() 
		{
		}
		#endregion

		#region Public
		public bool DownloadFile (ref structDownloadFile downloadFile) 
		{
			clsDownloadFile cls_DownloadFile = new clsDownloadFile (ref downloadFile.m_arrMirrorURL, downloadFile.m_strFilename, 0);
			cls_DownloadFile.eCallFeedback += new clsDownloadFile.delCallFeedback (OnCallFeedbackFile);
			cls_DownloadFile.eCallTimeFeedback += new clsDownloadFile.delCallTimeFeedback(OnCallTimeFeedbackFile);

			m_TotalBytesTransfered = 0;

			if (downloadFile.m_nFileSize >= 0) 
			{
				m_TotalBytes = downloadFile.m_nFileSize;
				cls_DownloadFile.SetFileSize (m_TotalBytes);
			} 
			else 
			{
				if (cls_DownloadFile.RequestFileSize (out m_TotalBytes) == false) 
				{
					cls_DownloadFile = null;
					return false;
				}
				cls_DownloadFile.SetFileSize (m_TotalBytes);
			}

			m_CurDownload = cls_DownloadFile;

			OnCallFeedback (m_TotalBytes, 0, cls_DownloadFile.GetFileName(), m_TotalBytes, 0);

			if (cls_DownloadFile.DownloadFile (m_TotalBytes) == false) 
			{
				return false;
			}

			OnCallTimeFeedback (0.0, 0.0, 0.0);

			return true;
		}

		public bool DownloadFiles (ref structDownloadFile[] arrDownloadFile) 
		{
			System.Collections.ArrayList arrFiles = new System.Collections.ArrayList();
			bool bError;

			m_TotalBytes = 0;

//			for (int i = 0; i < arrDownloadFile.Length; i++) 
//			{
//				if (arrDownloadFile[i].m_nFileSize < 0) 
//				{
//
//					if (((clsDownloadFile) arrFiles[i]).RequestFileSize (out arrDownloadFile[i].m_nFileSize) == false) 
//					{
//						return false;
//					}
//				} 
//			}

			for (int i = 0; i < arrDownloadFile.Length; i++) 
			{
				if (System.IO.File.Exists (arrDownloadFile[i].m_strFilename)) 
				{
					if (arrDownloadFile[i].m_nFileSize >= 0) 
					{
						System.IO.FileInfo fileInfo = new System.IO.FileInfo (arrDownloadFile[i].m_strFilename);
						if (fileInfo.Length == arrDownloadFile[i].m_nFileSize) 
						{
							fileInfo = null;
							continue;
						}
						fileInfo = null;
					} 
					else 
					{
						continue;
					}
				}

				clsDownloadFile cls_DownloadFile = new clsDownloadFile (ref arrDownloadFile[i].m_arrMirrorURL, arrDownloadFile[i].m_strFilename, arrDownloadFile[i].m_nFileSize);
				cls_DownloadFile.RequestFileSize(out arrDownloadFile[i].m_nFileSize);
				cls_DownloadFile.Size =	arrDownloadFile[i].m_nFileSize;

				cls_DownloadFile.eCallFeedback += new clsDownloadFile.delCallFeedback (OnCallFeedbackFile);
				cls_DownloadFile.eCallTimeFeedback += new clsDownloadFile.delCallTimeFeedback(OnCallTimeFeedbackFile);

				arrFiles.Add (cls_DownloadFile);
			}

			if (arrFiles.Count == 0) 
			{
				return true;
			}

			for (int i = 0; i < arrFiles.Count; i++) 
			{
				clsDownloadFile cls_File = (clsDownloadFile) arrFiles[i];
				m_TotalBytes += cls_File.GetFileSize();
			}

			m_TotalBytesTransfered = 0;

			for (int tent = 0; tent < 3; tent++) 
			{
				for (int i = 0; i < arrFiles.Count; i++) 
				{
					m_CurDownload = (clsDownloadFile) arrFiles[i];
					bError = false;

					if (m_CurDownload.GetOK()) 
					{
						continue;
					}

					OnCallFeedback (m_TotalBytes, m_TotalBytesTransfered, m_CurDownload.GetFileName(), m_CurDownload.GetFileSize(), 0);

					if (m_CurDownload.DownloadFile (m_CurDownload.GetFileSize()) == false) 
					{
						bError = true;
						if (m_CurDownload.GetTentativas() == 3) 
						{
							OnCallFeedback (m_TotalBytes, m_TotalBytesTransfered + m_CurDownload.GetFileSize(), "", m_CurDownload.GetFileSize(), m_CurDownload.GetFileSize());
							if (OnCallError (m_CurDownload.GetFileName())) 
							{
								return false;
							}
						} 
						else 
						{
							continue;
						}
					}

					m_TotalBytesTransfered += m_CurDownload.GetFileSize();

					if (bError == false) 
					{
						OnCallFeedback (m_TotalBytes, m_TotalBytesTransfered, m_CurDownload.GetFileName(), m_CurDownload.GetFileSize(), m_CurDownload.GetFileSize());
					} 
				}

				for (int i = arrFiles.Count - 1; i >= 0; i--) 
				{
					m_CurDownload = (clsDownloadFile) arrFiles[i];
					if (m_CurDownload.GetOK()) 
					{
						arrFiles.RemoveAt (i);
					}
				}

				if (arrFiles.Count == 0) 
				{
					break;
				}

				System.Threading.Thread.Sleep (5000);
			}

			OnCallTimeFeedback (0.0, 0.0, 0.0);

			return true;
		}
		#endregion

		#region Delegate
		public delegate void delCallFeedback (long nTotalBytes, long nTotalBytesTransfered, string strFilename, long nFileTotalBytes, long nFileBytesTransfered);
		public delegate bool delCallError (string strFilename);
		public delegate void delCallTimeFeedback (double dTxTransferencia, double dTempoEstimado, double dTempoTotalEstimado);
		#endregion
		#region Event
		public event delCallFeedback eCallFeedback;
		public event delCallError eCallError;
		public event delCallTimeFeedback eCallTimeFeedback;
		#endregion
		#region Event Method
		private void OnCallFeedbackFile (long nFileTotalBytes, long nFileBytesTransfered) 
		{
			OnCallFeedback (m_TotalBytes, m_TotalBytesTransfered + nFileBytesTransfered, "", nFileTotalBytes, nFileBytesTransfered);
		}

		private void OnCallFeedback (long nTotalBytes, long nTotalBytesTransfered, string strFilename, long nFileTotalBytes, long nFileBytesTransfered) 
		{
			if (eCallFeedback != null) 
			{
				eCallFeedback (nTotalBytes, nTotalBytesTransfered, strFilename, nFileTotalBytes, nFileBytesTransfered);
			}
		}

		private void OnCallTimeFeedbackFile (double dTxTransferencia, double dTempoEstimado, long nTotalBytesTransfered) 
		{
			OnCallTimeFeedback (dTxTransferencia, dTempoEstimado, (m_TotalBytes - m_TotalBytesTransfered - nTotalBytesTransfered) / dTxTransferencia);
		}

		private void OnCallTimeFeedback (double dTxTransferencia, double dTempoEstimado, double dTempoTotalEstimado) 
		{
			if (eCallTimeFeedback != null) 
			{
				eCallTimeFeedback (dTxTransferencia, dTempoEstimado, dTempoTotalEstimado);
			}
		}

		private bool OnCallError (string strFilename) 
		{
			if (eCallError != null) 
			{
				return eCallError (strFilename);
			} 
			else 
			{
				return false;
			}
		}
		#endregion
	}
	#endregion
}
