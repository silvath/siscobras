using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlRelatoriosJanelas
{
	/// <summary>
	/// Summary description for frmFRelatoriosImagens.
	/// </summary>
	public class frmFRelatoriosImagens : mdlComponentesGraficos.FormFlutuante
	{
		#region Atributos
		private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro; 
		private mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB;
		private string m_strEnderecoExecutavel; 
		private System.Windows.Forms.ImageList m_ilImagens; 
		private int m_nIdImagem = 0; 
		public bool m_bModificado; 

		// TypedDataSet
		private mdlDataBaseAccess.Tabelas.XsdTbImagens m_typDatSetTbImagens;

		internal System.Windows.Forms.GroupBox m_gbGeral;
		internal System.Windows.Forms.GroupBox m_gbImagem;
		internal System.Windows.Forms.PictureBox m_picImagem;
		internal System.Windows.Forms.GroupBox m_gbPreview;
		public System.Windows.Forms.Button m_btExcluirImagem;
		public System.Windows.Forms.Button m_btNovaImagem;
		internal System.Windows.Forms.ListView m_lvImagens;
		internal System.Windows.Forms.Button m_btOk;
		internal System.Windows.Forms.Button m_btCancelar;
		private System.ComponentModel.Container components = null;
		#endregion
		#region Constructors and Destructors 
		public frmFRelatoriosImagens(ref mdlTratamentoErro.clsTratamentoErro tratadorErro,ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string enderecoExecutavel)
		{
	        m_cls_ter_tratadorErro = tratadorErro;
	        m_strEnderecoExecutavel = enderecoExecutavel;
		    m_cls_dba_ConnectionDB = ConnectionDB;
			InitializeComponent();
			CarregaDados();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFRelatoriosImagens));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_gbImagem = new System.Windows.Forms.GroupBox();
			this.m_picImagem = new System.Windows.Forms.PictureBox();
			this.m_gbPreview = new System.Windows.Forms.GroupBox();
			this.m_btExcluirImagem = new System.Windows.Forms.Button();
			this.m_btNovaImagem = new System.Windows.Forms.Button();
			this.m_lvImagens = new System.Windows.Forms.ListView();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbGeral.SuspendLayout();
			this.m_gbImagem.SuspendLayout();
			this.m_gbPreview.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Controls.Add(this.m_gbImagem);
			this.m_gbGeral.Controls.Add(this.m_gbPreview);
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Location = new System.Drawing.Point(3, 1);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(612, 369);
			this.m_gbGeral.TabIndex = 3;
			this.m_gbGeral.TabStop = false;
			// 
			// m_gbImagem
			// 
			this.m_gbImagem.Controls.Add(this.m_picImagem);
			this.m_gbImagem.Location = new System.Drawing.Point(172, 8);
			this.m_gbImagem.Name = "m_gbImagem";
			this.m_gbImagem.Size = new System.Drawing.Size(436, 320);
			this.m_gbImagem.TabIndex = 10;
			this.m_gbImagem.TabStop = false;
			this.m_gbImagem.Text = "Imagem";
			// 
			// m_picImagem
			// 
			this.m_picImagem.BackColor = System.Drawing.Color.White;
			this.m_picImagem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.m_picImagem.Location = new System.Drawing.Point(11, 21);
			this.m_picImagem.Name = "m_picImagem";
			this.m_picImagem.Size = new System.Drawing.Size(413, 291);
			this.m_picImagem.TabIndex = 9;
			this.m_picImagem.TabStop = false;
			// 
			// m_gbPreview
			// 
			this.m_gbPreview.Controls.Add(this.m_btExcluirImagem);
			this.m_gbPreview.Controls.Add(this.m_btNovaImagem);
			this.m_gbPreview.Controls.Add(this.m_lvImagens);
			this.m_gbPreview.Location = new System.Drawing.Point(8, 9);
			this.m_gbPreview.Name = "m_gbPreview";
			this.m_gbPreview.Size = new System.Drawing.Size(160, 319);
			this.m_gbPreview.TabIndex = 9;
			this.m_gbPreview.TabStop = false;
			this.m_gbPreview.Text = "Lista ";
			// 
			// m_btExcluirImagem
			// 
			this.m_btExcluirImagem.BackColor = System.Drawing.SystemColors.Control;
			this.m_btExcluirImagem.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btExcluirImagem.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btExcluirImagem.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btExcluirImagem.Image = ((System.Drawing.Image)(resources.GetObject("m_btExcluirImagem.Image")));
			this.m_btExcluirImagem.Location = new System.Drawing.Point(81, 12);
			this.m_btExcluirImagem.Name = "m_btExcluirImagem";
			this.m_btExcluirImagem.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btExcluirImagem.Size = new System.Drawing.Size(25, 25);
			this.m_btExcluirImagem.TabIndex = 11;
			this.m_btExcluirImagem.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_btExcluirImagem.Click += new System.EventHandler(this.m_btExcluirImagem_Click);
			// 
			// m_btNovaImagem
			// 
			this.m_btNovaImagem.BackColor = System.Drawing.SystemColors.Control;
			this.m_btNovaImagem.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btNovaImagem.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btNovaImagem.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btNovaImagem.Image = ((System.Drawing.Image)(resources.GetObject("m_btNovaImagem.Image")));
			this.m_btNovaImagem.Location = new System.Drawing.Point(52, 12);
			this.m_btNovaImagem.Name = "m_btNovaImagem";
			this.m_btNovaImagem.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btNovaImagem.Size = new System.Drawing.Size(25, 25);
			this.m_btNovaImagem.TabIndex = 10;
			this.m_btNovaImagem.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_btNovaImagem.Click += new System.EventHandler(this.m_btNovaImagem_Click);
			// 
			// m_lvImagens
			// 
			this.m_lvImagens.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lvImagens.HideSelection = false;
			this.m_lvImagens.Location = new System.Drawing.Point(8, 40);
			this.m_lvImagens.Name = "m_lvImagens";
			this.m_lvImagens.Size = new System.Drawing.Size(144, 272);
			this.m_lvImagens.TabIndex = 7;
			this.m_lvImagens.Click += new System.EventHandler(this.m_lvImagens_Click);
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(248, 338);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 5;
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(312, 338);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 6;
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// frmFRelatoriosImagens
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(624, 375);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFRelatoriosImagens";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Imagens";
			this.Load += new System.EventHandler(this.frmFRelatoriosImagens_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbImagem.ResumeLayout(false);
			this.m_gbPreview.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
	
		#region Eventos 
			#region Formularios
			private void frmFRelatoriosImagens_Load(object sender, System.EventArgs e)
			{
				MostraCor();
				RefreshImagens();
			}
		#endregion
			#region Imagens
		private void m_lvImagens_Click(object sender, System.EventArgs e)
		{
			if (m_lvImagens.SelectedItems.Count > 0)
			{
				mdlDataBaseAccess.Tabelas.XsdTbImagens.tbImagensRow dtrwImagem;
				for (int nCont = 0; nCont < m_typDatSetTbImagens.tbImagens.Rows.Count;nCont++)
				{
					dtrwImagem = (mdlDataBaseAccess.Tabelas.XsdTbImagens.tbImagensRow)m_typDatSetTbImagens.tbImagens.Rows[nCont];
					if (dtrwImagem.RowState != System.Data.DataRowState.Deleted)
					{
						if (dtrwImagem.nIdImagem == Int32.Parse(m_lvImagens.SelectedItems[0].Tag.ToString()))
						{
							System.Drawing.Image imgImagem;
							imgImagem = imgBase64ToImage(dtrwImagem.mstrDados);
							if ((imgImagem.Width > m_picImagem.Width) || (imgImagem.Height > m_picImagem.Height))
							{
								m_picImagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
							}
							else
							{
								m_picImagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
							}
							m_picImagem.Image = imgImagem;
						}
					}
				}
			}
		}
		#endregion
			#region Botoes
			private void m_btNovaImagem_Click(object sender, System.EventArgs e)
			{
	            System.Windows.Forms.OpenFileDialog dlgAbrir = new System.Windows.Forms.OpenFileDialog();
				dlgAbrir.Multiselect = false;
				dlgAbrir.Title = "Escolha a imagem";
				dlgAbrir.CheckFileExists = true;
				dlgAbrir.Filter = "JPEG - Formato .JPG (*.jpg)|*.jpg|CompuServe GIF (*.gif)|*.gif|Portable Network Graphics (*.png)|*.png|Windows Bitmap (*.bmp)|*.bmp";
				if (dlgAbrir.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					string strImagemNome; 
					string strImagemDados; 
					System.Drawing.Image imgImagem;  
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					strImagemNome = dlgAbrir.FileName;
					int nPos = strImagemNome.LastIndexOf("\\");
					if (nPos != 0)
					{
						strImagemNome = strImagemNome.Substring(nPos + 1);
					}
					strImagemDados = strRetornaDadosArquivoEmBase64(dlgAbrir.FileName);
					imgImagem = System.Drawing.Image.FromFile(dlgAbrir.FileName);
					int nIndice = 1;
					while(m_typDatSetTbImagens.tbImagens.FindBynIdImagem((short)nIndice) != null)
					{
						nIndice++;
					}
                    mdlDataBaseAccess.Tabelas.XsdTbImagens.tbImagensRow dtrwImagem = m_typDatSetTbImagens.tbImagens.NewtbImagensRow();
					dtrwImagem.nIdImagem = (short)nIndice;
					dtrwImagem.strNome = strImagemNome;
					dtrwImagem.mstrDados = strImagemDados;
					dtrwImagem.bVisivelRelatorios = true;
					m_typDatSetTbImagens.tbImagens.AddtbImagensRow(dtrwImagem);
					                    
					RefreshImagens();
					Cursor = System.Windows.Forms.Cursors.Default;

					// Selecionando a Imagem inserida 
					for (int nCont = 0;nCont < m_lvImagens.Items.Count;nCont++)
					{
						if (Int32.Parse(m_lvImagens.Items[nCont].Tag.ToString()) == nIndice)
						{
							m_lvImagens.Items[nCont].Selected = true;
							break;
						}
					}
				}
			}

			private void m_btExcluirImagem_Click(object sender, System.EventArgs e)
			{
				if (m_lvImagens.SelectedItems.Count > 0)
				{
					if (mdlMensagens.clsMensagens.ShowQuestion("Siscobras.NET",mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlRelatoriosJanelas_frmFRelatoriosImagens_ApagarImagem),System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
					{
						bool bImagensUtilizadas = false;
						int nIdImagem = Int32.Parse(m_lvImagens.SelectedItems[0].Tag.ToString());
						mdlDataBaseAccess.Tabelas.XsdTbImagens.tbImagensRow dtrwImagem;
						for(int nCont = 0; nCont < m_typDatSetTbImagens.tbImagens.Rows.Count;nCont++)
						{
							dtrwImagem = (mdlDataBaseAccess.Tabelas.XsdTbImagens.tbImagensRow)m_typDatSetTbImagens.tbImagens.Rows[nCont];
							if (dtrwImagem.RowState != System.Data.DataRowState.Deleted)
							{
								if (dtrwImagem.nIdImagem == nIdImagem)
								{
									if (!bImagemVinculadoRelatorios(nIdImagem))
									{
										dtrwImagem.Delete();
										m_picImagem.Image = null;
									}else{
										bImagensUtilizadas = true;
									}
								}
							}
						} 
						if (bImagensUtilizadas)
							mdlMensagens.clsMensagens.ShowQuestion("Siscobras.NET","Algumas imagens não puderam ser excluídas, pois estão sendo utilizadas em algum documento.",System.Windows.Forms.MessageBoxButtons.OK); 
                        RefreshImagens();
					} 
				}
			}

			private bool bImagemVinculadoRelatorios(int nIdImagem)
			{
				System.Collections.ArrayList arlCondicaoCampo = new ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new ArrayList();
				arlCondicaoCampo.Add("nIdImagemIndex");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdImagem);
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				mdlDataBaseAccess.Tabelas.XsdTbRelatorioImagens typDatSetRelatorioImagens = m_cls_dba_ConnectionDB.GetTbRelatorioImagens(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				return((typDatSetRelatorioImagens.tbRelatorioImagens.Rows.Count > 0));
			}

			private void m_btOk_Click(object sender, System.EventArgs e)
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				SalvaDados();
				if (m_lvImagens.SelectedItems.Count > 0)
				{
					m_nIdImagem = Int32.Parse(m_lvImagens.SelectedItems[0].Tag.ToString());
				}
				m_bModificado = true;
				this.Cursor = System.Windows.Forms.Cursors.Default;
				this.Close();
			}

			private void m_btCancelar_Click(object sender, System.EventArgs e)
			{
				m_bModificado = false;
				this.Close();
			}
		#endregion
		#endregion
		#region Cores
		private void MostraCor()
		{
			mdlPaletaDeCores.clsPaletaDeCores clsPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini","SiscobrasCorSecundaria");
			this.BackColor = clsPaletaCores.retornaCorAtual();
			for (int nCont = 0 ;nCont < this.Controls.Count; nCont++)
			{
				this.Controls[nCont].BackColor = this.BackColor;
				for (int nCont2 = 0 ;nCont2 < this.Controls[nCont].Controls.Count; nCont2++)
				{
					if ((this.Controls[nCont].Controls[nCont2].GetType().ToString() != "System.Windows.Forms.ListView") && (this.Controls[nCont].Controls[nCont2].GetType().ToString() != "System.Windows.Forms.PictureBox"))
						this.Controls[nCont].Controls[nCont2].BackColor = this.BackColor;

					for (int nCont3 = 0 ;nCont3 < this.Controls[nCont].Controls[nCont2].Controls.Count; nCont3++)
					{
						if ((this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "System.Windows.Forms.ListView") && (this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "System.Windows.Forms.PictureBox"))
							this.Controls[nCont].Controls[nCont2].Controls[nCont3].BackColor = this.BackColor;
					}
				}
			}
		}
		#endregion

		#region Carregamento dos Dados 
			private void CarregaDados()
			{
				m_typDatSetTbImagens = m_cls_dba_ConnectionDB.GetTbImagens(null,null,null,null,null);	
			}
		#endregion 
		#region Salvamento dos Dados 
			private void SalvaDados()
			{
				m_cls_dba_ConnectionDB.SetTbImagens(m_typDatSetTbImagens);
			}
		#endregion

		#region Refreshs
			private void RefreshImagens()
			{
				System.Windows.Forms.ListViewItem lviItem; 
				m_ilImagens = new System.Windows.Forms.ImageList();
				m_lvImagens.LargeImageList = m_ilImagens;
				m_lvImagens.Items.Clear();

				mdlDataBaseAccess.Tabelas.XsdTbImagens.tbImagensRow dtrwImagem;
				for (int nCont = 0; nCont < m_typDatSetTbImagens.tbImagens.Rows.Count;nCont++)
				{
					dtrwImagem = (mdlDataBaseAccess.Tabelas.XsdTbImagens.tbImagensRow)m_typDatSetTbImagens.tbImagens.Rows[nCont];
					if (dtrwImagem.RowState != System.Data.DataRowState.Deleted)
					{
						if (dtrwImagem.bVisivelRelatorios == true)
						{
							m_ilImagens.Images.Add(imgBase64ToImage(dtrwImagem.mstrDados));
							lviItem = m_lvImagens.Items.Add(""); 
							lviItem.Tag = dtrwImagem.nIdImagem;
							lviItem.ImageIndex = m_ilImagens.Images.Count - 1;
						}
					}
				}
			}
		#endregion

		#region Imagem
			private string strRetornaDadosArquivoEmBase64(string strPathArquivo)
			{
				// Verificando se o arquivo existe 
				if (System.IO.File.Exists(strPathArquivo))
				{
					// Adquirindo os bytes do arquivo binario 
					System.IO.FileStream strfArquivo;
					strfArquivo = new System.IO.FileStream(strPathArquivo, System.IO.FileMode.Open, System.IO.FileAccess.Read);
					Byte[] byDados = new Byte[strfArquivo.Length];
					int nBytesRead = strfArquivo.Read(byDados, 0, (int)(strfArquivo.Length));
					strfArquivo.Close();

					// Convertendo 
					long nlArrayLength;
					nlArrayLength =  byDados.Length * 4;
					nlArrayLength = (int)(nlArrayLength / 3);
					//nlArrayLength = (int)((4 / 3) * byDados.Length);
					if (nlArrayLength % 4 != 0 )
					{
						nlArrayLength = nlArrayLength + 4 - nlArrayLength % 4;
					}
					char[] base64CharArray = new char[nlArrayLength];
					System.Convert.ToBase64CharArray(byDados, 0, byDados.Length, base64CharArray, 0);
					return (new System.String(base64CharArray));
				}else{
					return("");
				}
			}

			private System.Drawing.Image imgBase64ToImage(string strImagemBase64)
			{
				Byte[] byDados;
				byDados = System.Convert.FromBase64CharArray(strImagemBase64.ToCharArray(), 0, strImagemBase64.Length);
				System.IO.Stream strDados = new System.IO.MemoryStream(byDados);
				return(System.Drawing.Image.FromStream(strDados));
			}

		#endregion

		#region Retorno
			public void RetornaValores(out int idImagem,out System.Drawing.Image Imagem)
			{
	            idImagem = m_nIdImagem;
		        Imagem = m_picImagem.Image;
			}
		#endregion

	}
}
