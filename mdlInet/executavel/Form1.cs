using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace executavel
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		/// <summary>
		/// Summary description for Form1.
		/// </summary>
		#region MAIN
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}
		#endregion

		#region Atributos

		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.GroupBox m_gbParametros;
		private System.Windows.Forms.GroupBox m_btnStart;
		private System.Windows.Forms.TextBox m_txtTempoResposta;
		private System.Windows.Forms.TextBox m_txtHost;
		private System.Windows.Forms.Label m_lbTempoResposta;
		private System.Windows.Forms.Label m_lbHost;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox m_txtPSTR;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button m_btnPSStart;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label m_lbFile;
		private System.Windows.Forms.Button m_btnDownloadStart;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label m_TotalFile;
		private System.Windows.Forms.Label m_lbTotal;
		private System.Windows.Forms.ProgressBar m_pgrFile;
		private System.Windows.Forms.ProgressBar m_prgTotal;
		private System.Windows.Forms.Label m_lbTransferencia;
		private System.Windows.Forms.Label m_lbTempoEstimado;
		private System.Windows.Forms.Label m_lbTempoTotalEstimado;
		private System.Windows.Forms.GroupBox m_gbConnected;
		private System.Windows.Forms.Button m_btIsConnected;
		private System.Windows.Forms.TextBox m_txtIsConnected;
		private System.Windows.Forms.GroupBox m_gbProxy;
		private System.Windows.Forms.Button m_btSetProxy;
		private System.Windows.Forms.Label m_lbProxyPathXml;
		private System.Windows.Forms.TextBox m_txtPathXmlFile;
		private System.Windows.Forms.Button m_btStart;
		#endregion
		#region Constructor e Destructor
		public Form1()
		{
			InitializeComponent();
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
			this.m_btnStart = new System.Windows.Forms.GroupBox();
			this.m_gbProxy = new System.Windows.Forms.GroupBox();
			this.m_lbProxyPathXml = new System.Windows.Forms.Label();
			this.m_txtPathXmlFile = new System.Windows.Forms.TextBox();
			this.m_btSetProxy = new System.Windows.Forms.Button();
			this.m_gbConnected = new System.Windows.Forms.GroupBox();
			this.m_txtIsConnected = new System.Windows.Forms.TextBox();
			this.m_btIsConnected = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.m_lbTempoTotalEstimado = new System.Windows.Forms.Label();
			this.m_lbTempoEstimado = new System.Windows.Forms.Label();
			this.m_lbTransferencia = new System.Windows.Forms.Label();
			this.m_lbTotal = new System.Windows.Forms.Label();
			this.m_TotalFile = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.m_prgTotal = new System.Windows.Forms.ProgressBar();
			this.m_btnDownloadStart = new System.Windows.Forms.Button();
			this.m_lbFile = new System.Windows.Forms.Label();
			this.m_pgrFile = new System.Windows.Forms.ProgressBar();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.m_btnPSStart = new System.Windows.Forms.Button();
			this.m_txtPSTR = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.m_gbParametros = new System.Windows.Forms.GroupBox();
			this.m_txtTempoResposta = new System.Windows.Forms.TextBox();
			this.m_txtHost = new System.Windows.Forms.TextBox();
			this.m_lbTempoResposta = new System.Windows.Forms.Label();
			this.m_lbHost = new System.Windows.Forms.Label();
			this.m_btStart = new System.Windows.Forms.Button();
			this.m_btnStart.SuspendLayout();
			this.m_gbProxy.SuspendLayout();
			this.m_gbConnected.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.m_gbParametros.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_btnStart
			// 
			this.m_btnStart.Controls.Add(this.m_gbProxy);
			this.m_btnStart.Controls.Add(this.m_gbConnected);
			this.m_btnStart.Controls.Add(this.groupBox2);
			this.m_btnStart.Controls.Add(this.groupBox1);
			this.m_btnStart.Controls.Add(this.m_gbParametros);
			this.m_btnStart.Location = new System.Drawing.Point(5, -1);
			this.m_btnStart.Name = "m_btnStart";
			this.m_btnStart.Size = new System.Drawing.Size(615, 441);
			this.m_btnStart.TabIndex = 2;
			this.m_btnStart.TabStop = false;
			// 
			// m_gbProxy
			// 
			this.m_gbProxy.Controls.Add(this.m_lbProxyPathXml);
			this.m_gbProxy.Controls.Add(this.m_txtPathXmlFile);
			this.m_gbProxy.Controls.Add(this.m_btSetProxy);
			this.m_gbProxy.Location = new System.Drawing.Point(8, 8);
			this.m_gbProxy.Name = "m_gbProxy";
			this.m_gbProxy.Size = new System.Drawing.Size(600, 48);
			this.m_gbProxy.TabIndex = 7;
			this.m_gbProxy.TabStop = false;
			this.m_gbProxy.Text = "Proxy";
			// 
			// m_lbProxyPathXml
			// 
			this.m_lbProxyPathXml.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbProxyPathXml.Location = new System.Drawing.Point(124, 20);
			this.m_lbProxyPathXml.Name = "m_lbProxyPathXml";
			this.m_lbProxyPathXml.Size = new System.Drawing.Size(88, 16);
			this.m_lbProxyPathXml.TabIndex = 5;
			this.m_lbProxyPathXml.Text = "Path XML File:";
			// 
			// m_txtPathXmlFile
			// 
			this.m_txtPathXmlFile.Location = new System.Drawing.Point(208, 16);
			this.m_txtPathXmlFile.Name = "m_txtPathXmlFile";
			this.m_txtPathXmlFile.Size = new System.Drawing.Size(376, 20);
			this.m_txtPathXmlFile.TabIndex = 1;
			this.m_txtPathXmlFile.Text = "";
			// 
			// m_btSetProxy
			// 
			this.m_btSetProxy.Location = new System.Drawing.Point(16, 16);
			this.m_btSetProxy.Name = "m_btSetProxy";
			this.m_btSetProxy.Size = new System.Drawing.Size(104, 24);
			this.m_btSetProxy.TabIndex = 0;
			this.m_btSetProxy.Text = "SetProxy";
			this.m_btSetProxy.Click += new System.EventHandler(this.m_btSetProxy_Click);
			// 
			// m_gbConnected
			// 
			this.m_gbConnected.Controls.Add(this.m_txtIsConnected);
			this.m_gbConnected.Controls.Add(this.m_btIsConnected);
			this.m_gbConnected.Location = new System.Drawing.Point(8, 368);
			this.m_gbConnected.Name = "m_gbConnected";
			this.m_gbConnected.Size = new System.Drawing.Size(600, 64);
			this.m_gbConnected.TabIndex = 6;
			this.m_gbConnected.TabStop = false;
			this.m_gbConnected.Text = "Connected";
			// 
			// m_txtIsConnected
			// 
			this.m_txtIsConnected.Location = new System.Drawing.Point(102, 25);
			this.m_txtIsConnected.Name = "m_txtIsConnected";
			this.m_txtIsConnected.Size = new System.Drawing.Size(87, 20);
			this.m_txtIsConnected.TabIndex = 7;
			this.m_txtIsConnected.Text = "";
			// 
			// m_btIsConnected
			// 
			this.m_btIsConnected.Location = new System.Drawing.Point(8, 24);
			this.m_btIsConnected.Name = "m_btIsConnected";
			this.m_btIsConnected.Size = new System.Drawing.Size(88, 23);
			this.m_btIsConnected.TabIndex = 3;
			this.m_btIsConnected.Text = "IsConnected";
			this.m_btIsConnected.Click += new System.EventHandler(this.m_btIsConnected_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.m_lbTempoTotalEstimado);
			this.groupBox2.Controls.Add(this.m_lbTempoEstimado);
			this.groupBox2.Controls.Add(this.m_lbTransferencia);
			this.groupBox2.Controls.Add(this.m_lbTotal);
			this.groupBox2.Controls.Add(this.m_TotalFile);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.m_prgTotal);
			this.groupBox2.Controls.Add(this.m_btnDownloadStart);
			this.groupBox2.Controls.Add(this.m_lbFile);
			this.groupBox2.Controls.Add(this.m_pgrFile);
			this.groupBox2.Location = new System.Drawing.Point(8, 208);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(600, 160);
			this.groupBox2.TabIndex = 5;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "DownloadFiles";
			// 
			// m_lbTempoTotalEstimado
			// 
			this.m_lbTempoTotalEstimado.Location = new System.Drawing.Point(48, 136);
			this.m_lbTempoTotalEstimado.Name = "m_lbTempoTotalEstimado";
			this.m_lbTempoTotalEstimado.Size = new System.Drawing.Size(280, 16);
			this.m_lbTempoTotalEstimado.TabIndex = 10;
			this.m_lbTempoTotalEstimado.Text = "label6";
			// 
			// m_lbTempoEstimado
			// 
			this.m_lbTempoEstimado.Location = new System.Drawing.Point(48, 120);
			this.m_lbTempoEstimado.Name = "m_lbTempoEstimado";
			this.m_lbTempoEstimado.Size = new System.Drawing.Size(280, 16);
			this.m_lbTempoEstimado.TabIndex = 9;
			this.m_lbTempoEstimado.Text = "label5";
			// 
			// m_lbTransferencia
			// 
			this.m_lbTransferencia.Location = new System.Drawing.Point(48, 104);
			this.m_lbTransferencia.Name = "m_lbTransferencia";
			this.m_lbTransferencia.Size = new System.Drawing.Size(280, 16);
			this.m_lbTransferencia.TabIndex = 8;
			this.m_lbTransferencia.Text = "label4";
			// 
			// m_lbTotal
			// 
			this.m_lbTotal.Location = new System.Drawing.Point(392, 96);
			this.m_lbTotal.Name = "m_lbTotal";
			this.m_lbTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.m_lbTotal.Size = new System.Drawing.Size(184, 14);
			this.m_lbTotal.TabIndex = 7;
			this.m_lbTotal.Text = "0";
			// 
			// m_TotalFile
			// 
			this.m_TotalFile.Location = new System.Drawing.Point(392, 56);
			this.m_TotalFile.Name = "m_TotalFile";
			this.m_TotalFile.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.m_TotalFile.Size = new System.Drawing.Size(184, 14);
			this.m_TotalFile.TabIndex = 6;
			this.m_TotalFile.Text = "0";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(13, 93);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(16, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "0";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(14, 54);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(16, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "0";
			// 
			// m_prgTotal
			// 
			this.m_prgTotal.Location = new System.Drawing.Point(16, 80);
			this.m_prgTotal.Name = "m_prgTotal";
			this.m_prgTotal.Size = new System.Drawing.Size(560, 8);
			this.m_prgTotal.TabIndex = 3;
			// 
			// m_btnDownloadStart
			// 
			this.m_btnDownloadStart.Location = new System.Drawing.Point(504, 128);
			this.m_btnDownloadStart.Name = "m_btnDownloadStart";
			this.m_btnDownloadStart.TabIndex = 2;
			this.m_btnDownloadStart.Text = "Start";
			this.m_btnDownloadStart.Click += new System.EventHandler(this.m_btnDownloadStart_Click);
			// 
			// m_lbFile
			// 
			this.m_lbFile.Location = new System.Drawing.Point(19, 24);
			this.m_lbFile.Name = "m_lbFile";
			this.m_lbFile.Size = new System.Drawing.Size(557, 16);
			this.m_lbFile.TabIndex = 1;
			this.m_lbFile.Text = "Arquivo:";
			// 
			// m_pgrFile
			// 
			this.m_pgrFile.Location = new System.Drawing.Point(16, 44);
			this.m_pgrFile.Name = "m_pgrFile";
			this.m_pgrFile.Size = new System.Drawing.Size(560, 8);
			this.m_pgrFile.TabIndex = 0;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.m_btnPSStart);
			this.groupBox1.Controls.Add(this.m_txtPSTR);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(8, 144);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(600, 59);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "PingList";
			// 
			// m_btnPSStart
			// 
			this.m_btnPSStart.Location = new System.Drawing.Point(496, 23);
			this.m_btnPSStart.Name = "m_btnPSStart";
			this.m_btnPSStart.Size = new System.Drawing.Size(96, 24);
			this.m_btnPSStart.TabIndex = 10;
			this.m_btnPSStart.Text = "Start";
			this.m_btnPSStart.Click += new System.EventHandler(this.m_btnPSStart_Click);
			// 
			// m_txtPSTR
			// 
			this.m_txtPSTR.Location = new System.Drawing.Point(56, 24);
			this.m_txtPSTR.Name = "m_txtPSTR";
			this.m_txtPSTR.ReadOnly = true;
			this.m_txtPSTR.Size = new System.Drawing.Size(431, 20);
			this.m_txtPSTR.TabIndex = 9;
			this.m_txtPSTR.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(27, 16);
			this.label1.TabIndex = 8;
			this.label1.Text = "TR:";
			// 
			// m_gbParametros
			// 
			this.m_gbParametros.Controls.Add(this.m_txtTempoResposta);
			this.m_gbParametros.Controls.Add(this.m_txtHost);
			this.m_gbParametros.Controls.Add(this.m_lbTempoResposta);
			this.m_gbParametros.Controls.Add(this.m_lbHost);
			this.m_gbParametros.Controls.Add(this.m_btStart);
			this.m_gbParametros.Location = new System.Drawing.Point(8, 56);
			this.m_gbParametros.Name = "m_gbParametros";
			this.m_gbParametros.Size = new System.Drawing.Size(600, 80);
			this.m_gbParametros.TabIndex = 3;
			this.m_gbParametros.TabStop = false;
			this.m_gbParametros.Text = "Ping";
			// 
			// m_txtTempoResposta
			// 
			this.m_txtTempoResposta.Location = new System.Drawing.Point(57, 47);
			this.m_txtTempoResposta.Name = "m_txtTempoResposta";
			this.m_txtTempoResposta.ReadOnly = true;
			this.m_txtTempoResposta.Size = new System.Drawing.Size(431, 20);
			this.m_txtTempoResposta.TabIndex = 7;
			this.m_txtTempoResposta.Text = "";
			// 
			// m_txtHost
			// 
			this.m_txtHost.Location = new System.Drawing.Point(57, 23);
			this.m_txtHost.Name = "m_txtHost";
			this.m_txtHost.Size = new System.Drawing.Size(535, 20);
			this.m_txtHost.TabIndex = 6;
			this.m_txtHost.Text = "http://Siscobras.europe.webmatrixhosting.net/wbsvSiscoWebServices.asmx";
			// 
			// m_lbTempoResposta
			// 
			this.m_lbTempoResposta.Location = new System.Drawing.Point(24, 48);
			this.m_lbTempoResposta.Name = "m_lbTempoResposta";
			this.m_lbTempoResposta.Size = new System.Drawing.Size(27, 16);
			this.m_lbTempoResposta.TabIndex = 5;
			this.m_lbTempoResposta.Text = "TR:";
			// 
			// m_lbHost
			// 
			this.m_lbHost.Location = new System.Drawing.Point(16, 24);
			this.m_lbHost.Name = "m_lbHost";
			this.m_lbHost.Size = new System.Drawing.Size(34, 16);
			this.m_lbHost.TabIndex = 4;
			this.m_lbHost.Text = "Host:";
			// 
			// m_btStart
			// 
			this.m_btStart.Location = new System.Drawing.Point(497, 45);
			this.m_btStart.Name = "m_btStart";
			this.m_btStart.Size = new System.Drawing.Size(96, 24);
			this.m_btStart.TabIndex = 2;
			this.m_btStart.Text = "Start";
			this.m_btStart.Click += new System.EventHandler(this.m_btStart_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(624, 446);
			this.Controls.Add(this.m_btnStart);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Internet";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.m_btnStart.ResumeLayout(false);
			this.m_gbProxy.ResumeLayout(false);
			this.m_gbConnected.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.m_gbParametros.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
		private void Form1_Load(object sender, System.EventArgs e)
		{
			m_txtPathXmlFile.Text = System.Environment.CurrentDirectory + "\\";
		}
		#endregion

		#region Negocio 
			#region Proxy
				private void m_btSetProxy_Click(object sender, System.EventArgs e)
				{
					mdlInet.clsProxy cls_proxy = new mdlInet.clsProxy(m_txtPathXmlFile.Text);
					cls_proxy.vSetProxy();
				}
			#endregion


		private void m_btStart_Click(object sender, System.EventArgs e)
		{
			mdlInet.clsPing.ICMPErrors error;
			int nResponse;

			if (m_txtHost.Text.Length > 0) 
			{
				error = mdlInet.clsPing.PingHostHttp (m_txtHost.Text, out nResponse);
				if (error != mdlInet.clsPing.ICMPErrors.ERROR_NONE) 
				{
					m_txtTempoResposta.Text = printError (error);
				} 
				else 
				{
					m_txtTempoResposta.Text = nResponse.ToString();
				}
			}
		}

		private string printError (mdlInet.clsPing.ICMPErrors error) 
		{
			switch (error) 
			{
				case mdlInet.clsPing.ICMPErrors.ERROR_CANNOT_SEND_PACKET:
					return "Não foi possível enviar o pacote";
				case mdlInet.clsPing.ICMPErrors.ERROR_CONSTRUCTING_PACKET:
					return "Não foi possível construir o pacote";
				case mdlInet.clsPing.ICMPErrors.ERROR_HOST_TIMEOUT:
					return "Tempo de espera esgotado";
				case mdlInet.clsPing.ICMPErrors.ERROR_INVALID_HOST:
					return "Host inválido";
				case mdlInet.clsPing.ICMPErrors.ERROR_UNKNOW:
					return "Erro desconhecido";
			}
			return "";
		}

		private void m_btnPSStart_Click(object sender, System.EventArgs e)
		{
			mdlInet.clsPing.ICMPErrors error;
			System.Collections.ArrayList arrURIListIn = new ArrayList();
			System.Collections.SortedList arrURIListOut;

			arrURIListIn.Add ("http://CRON/wbsvSiscoWebServices/wbsvSiscoWebServices.asmx");
			arrURIListIn.Add ("http://www.palmsoft.com.br/webmail/");
			arrURIListIn.Add ("http://www.inf.ufsc.br/");
			arrURIListIn.Add ("http://www.cade.com.br/");
			arrURIListIn.Add ("http://www.google.com.br");

			error = mdlInet.clsPing.PingListHttp (ref arrURIListIn, out arrURIListOut);
			if (error != mdlInet.clsPing.ICMPErrors.ERROR_NONE) 
			{
				m_txtPSTR.Text = printError (error);
			} 
			else 
			{
				m_txtPSTR.Text = "";

				for (int i = 0; i < arrURIListOut.Count; i++) 
				{
					m_txtPSTR.Text += (String) arrURIListOut.GetByIndex (i) + ", ";
				}
			}
		}

		private void m_btnDownloadStart_Click(object sender, System.EventArgs e)
		{
			Cursor = System.Windows.Forms.Cursors.WaitCursor;
			mdlInet.clsDownloadManager downloadManager = new mdlInet.clsDownloadManager();
			mdlInet.clsDownloadManager.structDownloadFile[] arquivos = new mdlInet.clsDownloadManager.structDownloadFile[2];

			arquivos[0].m_nFileSize = -1;
			arquivos[0].m_strFilename = "C:\\2002-12-01-20-55_CopiarArquivos.zip";
			arquivos[0].m_arrMirrorURL = new ArrayList();
			arquivos[0].m_arrMirrorURL.Add ("http://www.siscobras.com.br/Siscobras/Versoes/2002-12-01-20-55_CopiarArquivos.zip");

			arquivos[1].m_nFileSize = -1;
			arquivos[1].m_strFilename = "C:\\2004-06-19-03-06_mdlValidacao.zip";
			arquivos[1].m_arrMirrorURL = new ArrayList();
			arquivos[1].m_arrMirrorURL.Add ("http://www.siscobras.com.br/Siscobras/Versoes/2004-06-19-03-06_mdlValidacao.zip");

			downloadManager.eCallError += new mdlInet.clsDownloadManager.delCallError (OnCallError);
			downloadManager.eCallFeedback += new mdlInet.clsDownloadManager.delCallFeedback(OnCallFeedback);
			downloadManager.eCallTimeFeedback += new mdlInet.clsDownloadManager.delCallTimeFeedback(OnCallTimeFeedback);

			downloadManager.DownloadFiles (ref arquivos);

			Cursor = System.Windows.Forms.Cursors.Default;
		}

		private void OnCallFeedback (long nTotalBytes, long nTotalBytesTransfered, string strFilename, long nFileTotalBytes, long nFileBytesTransfered)
		{
			if (nFileBytesTransfered == 0) 
			{
				m_lbFile.Text = "Arquivo: " + strFilename;
				m_TotalFile.Text = nFileTotalBytes.ToString();
				m_lbFile.Refresh();
				m_TotalFile.Refresh();
			}

			if (nTotalBytesTransfered == 0) 
			{
				m_lbTotal.Text = nTotalBytes.ToString();
				m_lbTotal.Refresh();
			}

			m_pgrFile.Value = (int) ((nFileBytesTransfered * 100) / nFileTotalBytes);
			m_prgTotal.Value = (int) ((nTotalBytesTransfered * 100) / nTotalBytes);

		}

		private bool OnCallError (string strFilename)
		{
			return false;
		}

		private void OnCallTimeFeedback (double dTxTransferencia, double nTempoEstimado, double nTempoTotalEstimado) 
		{
			double txReal = dTxTransferencia / 1024;

			if (txReal != System.Double.PositiveInfinity) 
			{
				m_lbTransferencia.Text = "Taxa: " + txReal.ToString() + " Kbps";
				m_lbTransferencia.Refresh();
			}

			System.TimeSpan blah1 = System.TimeSpan.FromSeconds (nTempoEstimado);
			m_lbTempoEstimado.Text = "Tempo: " + blah1.ToString();
			m_lbTempoEstimado.Refresh();

			System.TimeSpan blah2 = System.TimeSpan.FromSeconds (nTempoTotalEstimado);
			m_lbTempoTotalEstimado.Text = "Tempo total: " + blah2.ToString();
			m_lbTempoTotalEstimado.Refresh();
		}

			private void m_btIsConnected_Click(object sender, System.EventArgs e)
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				m_txtIsConnected.Text = "";
				m_txtIsConnected.Text = mdlInet.clsPing.bEstaConectado().ToString();
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}
		#endregion	
	}
}
