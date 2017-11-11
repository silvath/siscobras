using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Report;
using PdfDocument;
using PdfTypes;

namespace mdlPDF
{
	/// <summary>
	/// Summary description for clsPDF.
	/// </summary>
	public class clsPDF
	{
		#region Constantes
			private const float FATORCONVERSAOLOCALIZACAO = .754f;
			private const float FATORCONVERSAOTAMANHO = .76f;
			private const float FATORCONVERSAOTAMANHOLINHAS = .7f;
		#endregion

		#region Atributes
			private Report.SDReport m_pdfRelatorio = new Report.SDReport();
			System.Collections.ArrayList m_arlPaginas = new System.Collections.ArrayList();
			System.Collections.ArrayList m_arlMarcadoresTitulo = new System.Collections.ArrayList();
			System.Collections.ArrayList m_arlMarcadoresPai = new System.Collections.ArrayList();
			System.Collections.ArrayList m_arlMarcadoresPagina = new System.Collections.ArrayList();
			System.Collections.ArrayList m_arlMarcadoresEntrada = new System.Collections.ArrayList();
		#endregion
		#region Properties
			private Report.SDReport Relatorio
			{
				get
				{
					return(m_pdfRelatorio);
				}
			}

			private Report.SDPage Pagina
			{
				get
				{
					if (m_arlPaginas.Count > 0)
					{
						return((Report.SDPage)m_arlPaginas[m_arlPaginas.Count - 1]);
					}else{
						return(null);
					}
				}
			}

			private Report.SDLayoutPanel Panel
			{
				get
				{
					if (this.Pagina == null)
						return(null);
					return((Report.SDLayoutPanel)this.Pagina.Controls[0]);
				}
			}
		#endregion
		#region Construtor
		public clsPDF()
		{
			this.Relatorio.Author = "Siscobras Exporta Fácil";
			this.Relatorio.CreationDate = System.DateTime.Now;
			this.Relatorio.Creator = "Siscobras Exporta Fácil";
			this.Relatorio.Keywords = "Siscobras Exporta Fácil";
			this.Relatorio.ModDate = System.DateTime.Now;
			this.Relatorio.Subject = "Siscobras Exporta Fácil";
			this.Relatorio.Title = "Siscobras Exporta Fácil";
		}
		#endregion

		#region Relatorio
			public bool bSalvar(string strArquivo)
			{
				try
				{
					this.Relatorio.UseOutlines = true;
					this.Relatorio.FileName = strArquivo;
					this.Relatorio.BeginDoc();
					this.Relatorio.OutlineRoot.Opened=true;
					for(int i = 0;i < m_arlPaginas.Count;i++)
						this.Relatorio.Print((Report.SDPage)m_arlPaginas[i]);
					this.Relatorio.EndDoc();
					return(true);
				}catch{
					return(false);
				}
			}
		#endregion
		#region Pagina
			public bool bAdicionaPagina()
			{
				return(bAdicionaPagina(new System.Drawing.Size(596, 842)));
			}

			public bool bAdicionaPagina(System.Drawing.Size size)
			{
				try
				{
					size = ConversaoTamanho(size);

					// Layout
					Report.SDLayoutPanel sdLayoutPanel = new SDLayoutPanel();
					sdLayoutPanel.BackColor = System.Drawing.SystemColors.Window;
					sdLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
					sdLayoutPanel.Location = new System.Drawing.Point(0, 0);
					sdLayoutPanel.Name = "sdLayoutPanel1";
					sdLayoutPanel.Size = new System.Drawing.Size(size.Width - 64,size.Height - 64);
					sdLayoutPanel.TabIndex = 0;
					sdLayoutPanel.Text = (m_arlPaginas.Count + 1).ToString();
					sdLayoutPanel.BeforePrint += new SDPrintPanelEvent(this.Antes_Imprimir_Pagina);

					// Pagina
					Report.SDPage sdpageInsert = new SDPage();
					sdpageInsert.Controls.Add(sdLayoutPanel);
					sdpageInsert.DockPadding.All = 32;
					sdpageInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
					sdpageInsert.Location = new System.Drawing.Point(0, 0);
					sdpageInsert.Name = "CoverPage";
					sdpageInsert.Size = size;
					sdpageInsert.TabIndex = 2;
					sdpageInsert.Text = (m_arlPaginas.Count + 1).ToString();
					if (m_arlPaginas.Count == 0)
					sdpageInsert.PrintPage += new Report.SDPrintPageEvent(this.Imprime_Pagina);
					m_arlPaginas.Add(sdpageInsert);
					return(true);
				}catch{
					return(false);
				}
			}

			private void Antes_Imprimir_Pagina(object sender, SDPrintPanelEventArgs arg)
			{
				// Cria os Marcadores
				SDPanel FPanel=(SDPanel)sender;
				int nPaginaAtual = Int32.Parse(FPanel.Text);
				for(int i = 0; i < m_arlMarcadoresPagina.Count; i++)
				{
					if (Int32.Parse(m_arlMarcadoresPagina[i].ToString()) == nPaginaAtual)
					{
						SDOutlineEntry marcadorInserir = null;
						int nMarcadorPai = Int32.Parse(m_arlMarcadoresPai[i].ToString());
						if (nMarcadorPai == 0)
						{
							marcadorInserir = this.Relatorio.OutlineRoot.AddChild();
						}else{
							marcadorInserir = ((SDOutlineEntry)m_arlMarcadoresEntrada[nMarcadorPai - 1]).AddChild();
						}
						marcadorInserir.Opened = true;
						marcadorInserir.Title = m_arlMarcadoresTitulo[i].ToString();
						marcadorInserir.Dest = this.Relatorio.CreateDestination();
						marcadorInserir.Dest.DestinationType=PdfDestinationType.XYZ;
						marcadorInserir.Dest.Top=0;
						marcadorInserir.Dest.Left=0;
						marcadorInserir.Dest.Zoom=0;
						m_arlMarcadoresEntrada[i] = marcadorInserir;
					}
				}
			}

			private void Imprime_Pagina(object sender, Report.SDPrintPageEventArgs arg)
			{
				SDDestination dest;
				dest= this.Relatorio.CreateDestination();
				dest.DestinationType=PdfDestinationType.XYZ;
				this.Relatorio.OpenAction(dest);
			}
		#endregion
		#region Marcadores
			public int nAdicionaMarcador(string strTitulo)
			{
				return(nAdicionaMarcador(strTitulo,0));
			}

			public int nAdicionaMarcador(string strTitulo,int nMarcadorPai)
			{
				return(nAdicionaMarcador(strTitulo,nMarcadorPai,m_arlPaginas.Count));
			}

			public int nAdicionaMarcador(string strTitulo,int nMarcadorPai,int nIndicePagina)
			{
				try
				{
					m_arlMarcadoresTitulo.Add(strTitulo);
					m_arlMarcadoresPai.Add(nMarcadorPai);
					m_arlMarcadoresPagina.Add(nIndicePagina);
					m_arlMarcadoresEntrada.Add(null);
					return(m_arlMarcadoresPagina.Count);
				}catch{
					return(-1);
				}
			}
		#endregion

		#region Linha
			private void vInvertePontosCasoNecessario(ref System.Drawing.Point ptFonte,ref System.Drawing.Point ptDestino)
			{
				if (ptDestino.X < ptFonte.Y)
				{
					System.Drawing.Point ptTemp = ptFonte;
					ptFonte = ptDestino;
					ptDestino = ptTemp;
				}
			}

			public bool bAdicionaLinha(System.Drawing.Pen pen,System.Drawing.Point ptFonte,System.Drawing.Point ptDestino)
			{
				return(bAdicionaLinha(pen,ptFonte,ptDestino,true));
			}

			private bool bAdicionaLinha(System.Drawing.Pen pen,System.Drawing.Point ptFonte,System.Drawing.Point ptDestino,bool bLinha)
			{
				try
				{
					Report.SDRect obj = new SDRect();
					obj.DrawLine = bLinha;

					if (bLinha)
						vInvertePontosCasoNecessario(ref ptFonte,ref ptDestino);

					obj.Location = ConversaoLocalizacao(ptFonte);
					obj.Width = ConversaoTamanho(ptDestino.X - ptFonte.X);
					obj.Height = ConversaoTamanho(ptDestino.Y - ptFonte.Y);
					obj.LineWidth = ConversaoTamanhoLinhas(pen.Width);
					obj.LineColor = pen.Color;
					obj.TabIndex = 0;
					switch(pen.DashStyle)
					{
						case System.Drawing.Drawing2D.DashStyle.Dash:
							obj.LineStyle = PenStyle.Dash;
							break;
						case System.Drawing.Drawing2D.DashStyle.DashDot:
							obj.LineStyle = PenStyle.DashDot;
							break;
						case System.Drawing.Drawing2D.DashStyle.DashDotDot:
							obj.LineStyle = PenStyle.DashDotDot;
							break;
						case System.Drawing.Drawing2D.DashStyle.Dot:
							obj.LineStyle = PenStyle.Dot;
							break;
						default:
							obj.LineStyle = PenStyle.Solid;
							break;
					}
					this.Panel.Controls.Add(obj);
					return(true);
				}
				catch
				{
					return(false);
				}
			}
		#endregion
		#region Retangulo
			public bool bAdicionaRetangulo(System.Drawing.Pen pen,System.Drawing.Rectangle rect)
			{
				try
				{
					bAdicionaLinha(pen,new System.Drawing.Point(rect.X,rect.Y),new System.Drawing.Point(rect.X,rect.Y + rect.Height),false);
					bAdicionaLinha(pen,new System.Drawing.Point(rect.X,rect.Y),new System.Drawing.Point(rect.X + rect.Width,rect.Y),false);

					bAdicionaLinha(pen,new System.Drawing.Point(rect.X,rect.Y + rect.Height),new System.Drawing.Point(rect.X + rect.Width,rect.Y + rect.Height),false);
					bAdicionaLinha(pen,new System.Drawing.Point(rect.X + rect.Width,rect.Y),new System.Drawing.Point(rect.X + rect.Width,rect.Y + rect.Height),false);
					return(true);
				}
				catch
				{
					return(false);
				}
			}
		#endregion
		#region Circulo
			public bool bAdicionaCirculo(System.Drawing.Pen pen,System.Drawing.Rectangle rect)
			{
				try
				{
					Report.SDEllipse obj = new SDEllipse();
					obj.Location = ConversaoLocalizacao(rect.Location);
					obj.Width = ConversaoTamanho(rect.Width);
					obj.Height = ConversaoTamanho(rect.Height);
					obj.LineWidth = pen.Width;
					obj.LineColor = pen.Color;
					switch(pen.DashStyle)
					{
						case System.Drawing.Drawing2D.DashStyle.Dash:
							obj.LineStyle = PenStyle.Dash;
							break;
						case System.Drawing.Drawing2D.DashStyle.DashDot:
							obj.LineStyle = PenStyle.DashDot;
							break;
						case System.Drawing.Drawing2D.DashStyle.DashDotDot:
							obj.LineStyle = PenStyle.DashDotDot;
							break;
						case System.Drawing.Drawing2D.DashStyle.Dot:
							obj.LineStyle = PenStyle.Dot;
							break;
						default:
							obj.LineStyle = PenStyle.Solid;
							break;
					}
					this.Panel.Controls.Add(obj);
					return(true);
				}
				catch
				{
					return(false);
				}
			}
		#endregion
		#region Texto
			public bool bAdicionaTexto(string strTexto,System.Drawing.Font fntFonte,System.Drawing.Color clrCor,double dX,double dY)
			{
				try
				{
					Report.SDLabel obj = new SDLabel();
					
					int nIndex = strTexto.IndexOf(System.Environment.NewLine);
					if (nIndex != -1)
					{
						bAdicionaTexto(strTexto.Substring(nIndex + 2),fntFonte,clrCor,dX,dY + fntFonte.GetHeight());
						strTexto = strTexto.Substring(0,nIndex);
					}

					int nHeightIncrease = fntFonte.Height - (new System.Drawing.Font("Arial",fntFonte.Size,fntFonte.Style)).Height;
					if (nHeightIncrease > 0)
						dY += nHeightIncrease;
					obj.Text = strTexto;
					obj.ForeColor = clrCor;
					obj.FontSize = fntFonte.Size;
					obj.FontBold = fntFonte.Bold;
					obj.FontItalic = fntFonte.Italic;
					obj.Font = fntFonte;
					obj.Location = ConversaoLocalizacao(new System.Drawing.Point((Int32)dX,(Int32)dY));
					obj.Size = new Size(this.Pagina.Width - obj.Location.X,this.Pagina.Height - obj.Location.Y);
					obj.Tag = "0";
					this.Panel.Controls.Add(obj);
					return(true);
				}
				catch
				{
					return(false);
				}
			}
		#endregion
		#region Imagem
			private System.Drawing.Bitmap imgImagemJPG(System.Drawing.Image imgImagem)
			{
				System.Drawing.Bitmap imgReturn = (System.Drawing.Bitmap)imgImagem;
				if (imgReturn.RawFormat.Guid !=System.Drawing.Imaging.ImageFormat.Jpeg.Guid)
				{					
					System.IO.Stream stmJPG = new System.IO.MemoryStream();
					imgReturn.Save(stmJPG,System.Drawing.Imaging.ImageFormat.Jpeg);
					System.Drawing.Bitmap imbJpg = (System.Drawing.Bitmap)System.Drawing.Image.FromStream(stmJPG);
					imgReturn = imbJpg;
				}
				return(imgReturn);
			}

			public bool bAdicionaImagem(System.Drawing.Image imgImagem,System.Drawing.Rectangle rect)
			{
				try
				{
					Report.SDJPegImage obj = new SDJPegImage();
					obj.Picture = imgImagemJPG(imgImagem);
					obj.Location = ConversaoLocalizacao(rect.Location);
					obj.Size = new Size(ConversaoTamanho(rect.Width),ConversaoTamanho(rect.Height));
					obj.Stretch = true;
					obj.SharedImage = false;
					this.Panel.Controls.Add(obj);
					return(true);
				}catch(System.Exception e){
					return(false);
				}
			}
		#endregion

		#region Conversao
			private float TaxaConversaoTamanho(int Valor)
			{
				return(FATORCONVERSAOTAMANHO - ((float)((Valor / (33 * 5)) * 0.001)));
			}

			private int ConversaoLocalizacao(int Valor)
			{
				return((int)(Valor * FATORCONVERSAOLOCALIZACAO));
			} 

			private System.Drawing.Size ConversaoTamanho(System.Drawing.Size size)
			{
				return(new System.Drawing.Size(ConversaoLocalizacao(size.Width),ConversaoLocalizacao(size.Height)));
			}

			private int ConversaoTamanho(int Valor)
			{
				return((int)(Valor * TaxaConversaoTamanho(Valor)));
			} 

			private float ConversaoTamanhoLinhas(float Valor)
			{
				return((float)(Valor * FATORCONVERSAOTAMANHOLINHAS));
			} 

			private System.Drawing.Point ConversaoLocalizacao(System.Drawing.Point ponto)
			{
				return(new System.Drawing.Point(ConversaoLocalizacao(ponto.X),ConversaoLocalizacao(ponto.Y)));
			}
		#endregion
	}
}
