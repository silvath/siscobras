using System;
using System.Collections;
using System.Windows.Forms;

namespace mdlIdioma
{
	/// <summary>
	/// Summary description for frmFIdioma.
	/// </summary>
	internal class frmFIdiomas : mdlComponentesGraficos.FormFlutuante
	{
		#region Delegate
			public delegate void delCallCarregaDadosBD();
			public delegate void delCallCarregaDadosInterface(ref System.Windows.Forms.ListView lvListView, ref System.Windows.Forms.GroupBox gbFields);
			public delegate void delCallChecaIntegridadeDados();
			public delegate void delCallSalvaDadosInterface(ref System.Windows.Forms.ListView lvListView, bool bModificado);
			public delegate void delCallSalvaDadosBD();
			public delegate bool delCallIdiomasInstaladosVisivel();
			public delegate void delCallIdiomasInstaladosShow();
		#endregion
		#region Events
			public event delCallCarregaDadosBD eCallCarregaDadosBD;
			public event delCallCarregaDadosInterface eCallCarregaDadosInterface;
			public event delCallChecaIntegridadeDados eCallChecaIntegridadeDados;
			public event delCallSalvaDadosInterface eCallSalvaDadosInterface;
			public event delCallSalvaDadosBD eCallSalvaDadosBD;
			public event delCallIdiomasInstaladosVisivel eCallIdiomasInstaladosVisivel;
			public event delCallIdiomasInstaladosShow eCallIdiomasInstaladosShow;
		#endregion
		#region Events Methods
			protected virtual void OnCallCarregaDadosBD()
			{
				if (eCallCarregaDadosBD != null)
					eCallCarregaDadosBD();
			} 

			protected virtual void OnCallCarregaDadosInterface()
			{
				if (eCallCarregaDadosInterface != null)
					eCallCarregaDadosInterface(ref this.m_lvListaIdiomas, ref m_gbGroupList);
			} 

			protected virtual void OnCallChecaIntegridadeDados()
			{
				if (eCallChecaIntegridadeDados != null)
					eCallChecaIntegridadeDados();
			}

			protected virtual void OnCallSalvaDadosInterface()
			{
				if (eCallSalvaDadosInterface != null)
					eCallSalvaDadosInterface(ref this.m_lvListaIdiomas, this.m_bModificado);
			} 

			protected virtual void OnCallSalvaDadosBD()
			{
				if (eCallSalvaDadosBD != null)
					eCallSalvaDadosBD();
			} 

			protected virtual bool OnCallIdiomasInstaladosVisivel()
			{
				bool bRetorno = false;
				if (eCallIdiomasInstaladosVisivel != null)
					bRetorno = eCallIdiomasInstaladosVisivel();
				return(bRetorno);
			} 

			protected virtual void OnCallIdiomasInstaladosShow()
			{
				if (eCallIdiomasInstaladosShow != null)
					eCallIdiomasInstaladosShow();
			} 
		#endregion

		#region Atributos

		private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
		private string m_strEnderecoExecutavel;

		public bool m_bModificado = false;

		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.GroupBox m_gbFrame;
		private System.Windows.Forms.GroupBox m_gbGroupList;
		private System.Windows.Forms.ToolTip m_ttDicaFrmFIdioma;
		private System.Windows.Forms.Button m_btOk;
		private System.Windows.Forms.Button m_btTrocarCor;
		private System.Windows.Forms.Button m_btCancelar;
		private System.Windows.Forms.Button m_btIdiomasInstalados;
		public System.Windows.Forms.ImageList m_ilBandeiras;
		internal System.Windows.Forms.ListView m_lvListaIdiomas;

		#endregion
		#region Properties
			public System.Windows.Forms.ImageList Bandeiras
			{
				set
				{
					m_ilBandeiras = value;
					m_lvListaIdiomas.SmallImageList = m_ilBandeiras;
					m_lvListaIdiomas.LargeImageList = m_ilBandeiras;
				}
				get
				{
					return(m_ilBandeiras);
				}
			}
		#endregion
		#region Construtores & Destrutores
		public frmFIdiomas()
		{

		}

		public frmFIdiomas(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, string EnderecoExecutavel)
		{
			try 
			{
				m_cls_ter_tratadorErro = tratadorErro;
				m_strEnderecoExecutavel = EnderecoExecutavel;

				InitializeComponent();
				this.Bandeiras = new frmFIdiomasIndisponiveis(m_strEnderecoExecutavel).Bandeiras;
			} 
			catch (Exception err) 
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFIdiomas));
			System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("77777", 10);
			this.m_gbFrame = new System.Windows.Forms.GroupBox();
			this.m_btIdiomasInstalados = new System.Windows.Forms.Button();
			this.m_btTrocarCor = new System.Windows.Forms.Button();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_gbGroupList = new System.Windows.Forms.GroupBox();
			this.m_lvListaIdiomas = new System.Windows.Forms.ListView();
			this.m_ilBandeiras = new System.Windows.Forms.ImageList(this.components);
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_ttDicaFrmFIdioma = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbFrame.SuspendLayout();
			this.m_gbGroupList.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbFrame
			// 
			this.m_gbFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFrame.Controls.Add(this.m_btIdiomasInstalados);
			this.m_gbFrame.Controls.Add(this.m_btTrocarCor);
			this.m_gbFrame.Controls.Add(this.m_btOk);
			this.m_gbFrame.Controls.Add(this.m_gbGroupList);
			this.m_gbFrame.Controls.Add(this.m_btCancelar);
			this.m_gbFrame.Location = new System.Drawing.Point(2, 0);
			this.m_gbFrame.Name = "m_gbFrame";
			this.m_gbFrame.Size = new System.Drawing.Size(246, 365);
			this.m_gbFrame.TabIndex = 0;
			this.m_gbFrame.TabStop = false;
			// 
			// m_btIdiomasInstalados
			// 
			this.m_btIdiomasInstalados.Image = ((System.Drawing.Image)(resources.GetObject("m_btIdiomasInstalados.Image")));
			this.m_btIdiomasInstalados.Location = new System.Drawing.Point(9, 331);
			this.m_btIdiomasInstalados.Name = "m_btIdiomasInstalados";
			this.m_btIdiomasInstalados.Size = new System.Drawing.Size(25, 25);
			this.m_btIdiomasInstalados.TabIndex = 9;
			this.m_btIdiomasInstalados.Click += new System.EventHandler(this.m_btIdiomasInstalados_Click);
			// 
			// m_btTrocarCor
			// 
			this.m_btTrocarCor.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_btTrocarCor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btTrocarCor.Location = new System.Drawing.Point(3, 8);
			this.m_btTrocarCor.Name = "m_btTrocarCor";
			this.m_btTrocarCor.Size = new System.Drawing.Size(4, 4);
			this.m_btTrocarCor.TabIndex = 7;
			this.m_ttDicaFrmFIdioma.SetToolTip(this.m_btTrocarCor, "Cor");
			this.m_btTrocarCor.Click += new System.EventHandler(this.m_btTrocarCor_Click);
			// 
			// m_btOk
			// 
			this.m_btOk.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(63, 332);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 27);
			this.m_btOk.TabIndex = 5;
			this.m_ttDicaFrmFIdioma.SetToolTip(this.m_btOk, "Confirmar");
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_gbGroupList
			// 
			this.m_gbGroupList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbGroupList.Controls.Add(this.m_lvListaIdiomas);
			this.m_gbGroupList.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbGroupList.Location = new System.Drawing.Point(8, 8);
			this.m_gbGroupList.Name = "m_gbGroupList";
			this.m_gbGroupList.Size = new System.Drawing.Size(230, 320);
			this.m_gbGroupList.TabIndex = 0;
			this.m_gbGroupList.TabStop = false;
			this.m_gbGroupList.Text = "Faturas";
			// 
			// m_lvListaIdiomas
			// 
			this.m_lvListaIdiomas.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.m_lvListaIdiomas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lvListaIdiomas.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lvListaIdiomas.HideSelection = false;
			this.m_lvListaIdiomas.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
																							 listViewItem1});
			this.m_lvListaIdiomas.LargeImageList = this.m_ilBandeiras;
			this.m_lvListaIdiomas.Location = new System.Drawing.Point(11, 17);
			this.m_lvListaIdiomas.Name = "m_lvListaIdiomas";
			this.m_lvListaIdiomas.Size = new System.Drawing.Size(209, 293);
			this.m_lvListaIdiomas.SmallImageList = this.m_ilBandeiras;
			this.m_lvListaIdiomas.TabIndex = 1;
			this.m_ttDicaFrmFIdioma.SetToolTip(this.m_lvListaIdiomas, "Selecione o idioma desejado");
			this.m_lvListaIdiomas.View = System.Windows.Forms.View.List;
			this.m_lvListaIdiomas.DoubleClick += new System.EventHandler(this.m_lvListaIdiomas_DoubleClick);
			this.m_lvListaIdiomas.SelectedIndexChanged += new System.EventHandler(this.m_lvListaIdiomas_SelectedIndexChanged);
			// 
			// m_ilBandeiras
			// 
			this.m_ilBandeiras.ImageSize = new System.Drawing.Size(16, 16);
			this.m_ilBandeiras.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_ilBandeiras.ImageStream")));
			this.m_ilBandeiras.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(128, 332);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 27);
			this.m_btCancelar.TabIndex = 8;
			this.m_ttDicaFrmFIdioma.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_ttDicaFrmFIdioma
			// 
			this.m_ttDicaFrmFIdioma.AutomaticDelay = 100;
			this.m_ttDicaFrmFIdioma.AutoPopDelay = 5000;
			this.m_ttDicaFrmFIdioma.InitialDelay = 100;
			this.m_ttDicaFrmFIdioma.ReshowDelay = 20;
			// 
			// frmFIdiomas
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(250, 367);
			this.Controls.Add(this.m_gbFrame);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFIdiomas";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Idioma";
			this.Load += new System.EventHandler(this.frmFIdioma_Load);
			this.m_gbFrame.ResumeLayout(false);
			this.m_gbGroupList.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Cores
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
								"System.Windows.Forms.DateTimePicker") &&
								(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"System.Windows.Forms.ListView"))
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

		#region Métodos para manipulação da ImageList
		public void mostraBandeiraAtual()
		{
			try
			{

				if (this.m_lvListaIdiomas.SelectedItems.Count > 0)
				{
					int nIdIdioma;
					System.Drawing.Bitmap bmpBandeira;
					nIdIdioma = Int32.Parse(this.m_lvListaIdiomas.SelectedItems[0].Tag.ToString());
					bmpBandeira = (System.Drawing.Bitmap)m_ilBandeiras.Images[nIdIdioma - 1];
					this.Icon = System.Drawing.Icon.FromHandle(bmpBandeira.GetHicon());
				}
			} 
			catch (Exception erro) 
			{
				Object err = erro;
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFIdioma_Load(object sender, System.EventArgs e)
				{
					try 
					{
						this.mostraCor();
						this.mostraBandeiraAtual();
						OnCallCarregaDadosInterface();
						this.m_lvListaIdiomas.Focus();
						m_btIdiomasInstalados.Visible = OnCallIdiomasInstaladosVisivel();
					} 
					catch (Exception err) 
					{
						Object erro = err;
						m_cls_ter_tratadorErro.trataErro(ref erro);
					}
				}
			#endregion
			#region Cor
		private void m_btTrocarCor_Click(object sender, System.EventArgs e)
		{
			try 
			{
				this.trocaCor();
				this.mostraCor();
			} 
			catch (Exception err) 
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
			#region Index Changed
		private void m_lvListaIdiomas_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try 
			{
				this.mostraBandeiraAtual();
			} 
			catch (Exception err) 
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
			#region Double Click
		private void m_lvListaIdiomas_DoubleClick(object sender, System.EventArgs e)
		{
			try
			{
				m_btOk_Click(sender, e);
			}
			catch
			{
			}
		}
		#endregion
			#region Botoes
				private void m_btIdiomasInstalados_Click(object sender, System.EventArgs e)
				{
					OnCallIdiomasInstaladosShow();
				}

				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					try 
					{
						if (m_lvListaIdiomas.SelectedItems.Count == 1)
						{
							this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
							this.m_bModificado = true;
							OnCallSalvaDadosInterface();
							OnCallSalvaDadosBD();
							this.Cursor = System.Windows.Forms.Cursors.Default;
							this.Close();
						} 
						else 
						{
							mdlMensagens.clsMensagens.ShowInformation(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlIdioma_frmFIdioma_SelecionarUmIdioma));
							//MessageBox.Show("Você precisa selecionar 1(UM) idioma.",this.Text);
						}
					} 
					catch (Exception err) 
					{
						Object erro = err;
						m_cls_ter_tratadorErro.trataErro(ref erro);
					}
				}

				private void m_btCancelar_Click(object sender, System.EventArgs e)
				{
                    this.Close();				
				}
			#endregion
		#endregion
	}
}
