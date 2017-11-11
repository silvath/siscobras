using System;
using System.Collections;

namespace mdlCriacaoDocumentos.Frames
{
	/// <summary>
	/// Summary description for frmFLista.
	/// </summary>
	internal class frmFLista : mdlComponentesGraficos.FormFlutuante
	{
		#region Delegates
			public delegate void delCallCarregaDadosInterface(ref mdlComponentesGraficos.ListView lvListaModelos, ref System.Windows.Forms.GroupBox gbFields);
			public delegate void delCallSelecionaItemLista(string strIdCodigo);
		#endregion
		#region Events
			public event delCallCarregaDadosInterface eCallCarregaDadosInterface;
			public event delCallSelecionaItemLista eCallSelecionaItemLista;
		#endregion
		#region Events Methods
			protected virtual void OnCallCarregaDadosInterface()
			{
				if (eCallCarregaDadosInterface != null)
					eCallCarregaDadosInterface(ref m_lvListaModelos, ref m_gbFields);
			}
			protected virtual void OnCallSelecionaItemLista()
			{
				if (eCallSelecionaItemLista != null)
					eCallSelecionaItemLista(m_lvListaModelos.SelectedItems[0].Tag.ToString());
			}
		#endregion

		#region Atributos
			private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
			private string m_strEnderecoExecutavel = "";

			public bool m_bModificado = false;

			private System.Windows.Forms.GroupBox m_gbFrame;
			private System.Windows.Forms.GroupBox m_gbFields;
			private System.Windows.Forms.Button m_btOk;
			private System.Windows.Forms.Button m_btCancelar;
			internal System.Windows.Forms.Button m_btTrocarCor;
			private System.Windows.Forms.ColumnHeader m_chFirst;
			private System.Windows.Forms.ColumnHeader m_chSecond;
			private mdlComponentesGraficos.ListView m_lvListaModelos;
			private System.Windows.Forms.ToolTip m_ttLista;
			private System.ComponentModel.IContainer components;
		#endregion
		#region Construtors and Destructors
			public frmFLista(ref mdlTratamentoErro.clsTratamentoErro clstratadorErro, string strEnderecoExecutavel)
			{
				InitializeComponent();
				m_cls_ter_tratadorErro = clstratadorErro;
				m_strEnderecoExecutavel = strEnderecoExecutavel;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFLista));
			this.m_gbFrame = new System.Windows.Forms.GroupBox();
			this.m_btTrocarCor = new System.Windows.Forms.Button();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbFields = new System.Windows.Forms.GroupBox();
			this.m_lvListaModelos = new mdlComponentesGraficos.ListView();
			this.m_chFirst = new System.Windows.Forms.ColumnHeader();
			this.m_chSecond = new System.Windows.Forms.ColumnHeader();
			this.m_ttLista = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbFrame.SuspendLayout();
			this.m_gbFields.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbFrame
			// 
			this.m_gbFrame.AccessibleDescription = resources.GetString("m_gbFrame.AccessibleDescription");
			this.m_gbFrame.AccessibleName = resources.GetString("m_gbFrame.AccessibleName");
			this.m_gbFrame.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("m_gbFrame.Anchor")));
			this.m_gbFrame.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_gbFrame.BackgroundImage")));
			this.m_gbFrame.Controls.Add(this.m_btTrocarCor);
			this.m_gbFrame.Controls.Add(this.m_btOk);
			this.m_gbFrame.Controls.Add(this.m_btCancelar);
			this.m_gbFrame.Controls.Add(this.m_gbFields);
			this.m_gbFrame.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("m_gbFrame.Dock")));
			this.m_gbFrame.Enabled = ((bool)(resources.GetObject("m_gbFrame.Enabled")));
			this.m_gbFrame.Font = ((System.Drawing.Font)(resources.GetObject("m_gbFrame.Font")));
			this.m_gbFrame.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("m_gbFrame.ImeMode")));
			this.m_gbFrame.Location = ((System.Drawing.Point)(resources.GetObject("m_gbFrame.Location")));
			this.m_gbFrame.Name = "m_gbFrame";
			this.m_gbFrame.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("m_gbFrame.RightToLeft")));
			this.m_gbFrame.Size = ((System.Drawing.Size)(resources.GetObject("m_gbFrame.Size")));
			this.m_gbFrame.TabIndex = ((int)(resources.GetObject("m_gbFrame.TabIndex")));
			this.m_gbFrame.TabStop = false;
			this.m_gbFrame.Text = resources.GetString("m_gbFrame.Text");
			this.m_ttLista.SetToolTip(this.m_gbFrame, resources.GetString("m_gbFrame.ToolTip"));
			this.m_gbFrame.Visible = ((bool)(resources.GetObject("m_gbFrame.Visible")));
			// 
			// m_btTrocarCor
			// 
			this.m_btTrocarCor.AccessibleDescription = resources.GetString("m_btTrocarCor.AccessibleDescription");
			this.m_btTrocarCor.AccessibleName = resources.GetString("m_btTrocarCor.AccessibleName");
			this.m_btTrocarCor.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("m_btTrocarCor.Anchor")));
			this.m_btTrocarCor.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_btTrocarCor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_btTrocarCor.BackgroundImage")));
			this.m_btTrocarCor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btTrocarCor.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("m_btTrocarCor.Dock")));
			this.m_btTrocarCor.Enabled = ((bool)(resources.GetObject("m_btTrocarCor.Enabled")));
			this.m_btTrocarCor.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("m_btTrocarCor.FlatStyle")));
			this.m_btTrocarCor.Font = ((System.Drawing.Font)(resources.GetObject("m_btTrocarCor.Font")));
			this.m_btTrocarCor.Image = ((System.Drawing.Image)(resources.GetObject("m_btTrocarCor.Image")));
			this.m_btTrocarCor.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("m_btTrocarCor.ImageAlign")));
			this.m_btTrocarCor.ImageIndex = ((int)(resources.GetObject("m_btTrocarCor.ImageIndex")));
			this.m_btTrocarCor.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("m_btTrocarCor.ImeMode")));
			this.m_btTrocarCor.Location = ((System.Drawing.Point)(resources.GetObject("m_btTrocarCor.Location")));
			this.m_btTrocarCor.Name = "m_btTrocarCor";
			this.m_btTrocarCor.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("m_btTrocarCor.RightToLeft")));
			this.m_btTrocarCor.Size = ((System.Drawing.Size)(resources.GetObject("m_btTrocarCor.Size")));
			this.m_btTrocarCor.TabIndex = ((int)(resources.GetObject("m_btTrocarCor.TabIndex")));
			this.m_btTrocarCor.Text = resources.GetString("m_btTrocarCor.Text");
			this.m_btTrocarCor.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("m_btTrocarCor.TextAlign")));
			this.m_ttLista.SetToolTip(this.m_btTrocarCor, resources.GetString("m_btTrocarCor.ToolTip"));
			this.m_btTrocarCor.Visible = ((bool)(resources.GetObject("m_btTrocarCor.Visible")));
			this.m_btTrocarCor.Click += new System.EventHandler(this.m_btTrocarCor_Click);
			// 
			// m_btOk
			// 
			this.m_btOk.AccessibleDescription = resources.GetString("m_btOk.AccessibleDescription");
			this.m_btOk.AccessibleName = resources.GetString("m_btOk.AccessibleName");
			this.m_btOk.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("m_btOk.Anchor")));
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_btOk.BackgroundImage")));
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("m_btOk.Dock")));
			this.m_btOk.Enabled = ((bool)(resources.GetObject("m_btOk.Enabled")));
			this.m_btOk.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("m_btOk.FlatStyle")));
			this.m_btOk.Font = ((System.Drawing.Font)(resources.GetObject("m_btOk.Font")));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("m_btOk.ImageAlign")));
			this.m_btOk.ImageIndex = ((int)(resources.GetObject("m_btOk.ImageIndex")));
			this.m_btOk.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("m_btOk.ImeMode")));
			this.m_btOk.Location = ((System.Drawing.Point)(resources.GetObject("m_btOk.Location")));
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("m_btOk.RightToLeft")));
			this.m_btOk.Size = ((System.Drawing.Size)(resources.GetObject("m_btOk.Size")));
			this.m_btOk.TabIndex = ((int)(resources.GetObject("m_btOk.TabIndex")));
			this.m_btOk.Text = resources.GetString("m_btOk.Text");
			this.m_btOk.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("m_btOk.TextAlign")));
			this.m_ttLista.SetToolTip(this.m_btOk, resources.GetString("m_btOk.ToolTip"));
			this.m_btOk.Visible = ((bool)(resources.GetObject("m_btOk.Visible")));
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.AccessibleDescription = resources.GetString("m_btCancelar.AccessibleDescription");
			this.m_btCancelar.AccessibleName = resources.GetString("m_btCancelar.AccessibleName");
			this.m_btCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("m_btCancelar.Anchor")));
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.BackgroundImage")));
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("m_btCancelar.Dock")));
			this.m_btCancelar.Enabled = ((bool)(resources.GetObject("m_btCancelar.Enabled")));
			this.m_btCancelar.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("m_btCancelar.FlatStyle")));
			this.m_btCancelar.Font = ((System.Drawing.Font)(resources.GetObject("m_btCancelar.Font")));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("m_btCancelar.ImageAlign")));
			this.m_btCancelar.ImageIndex = ((int)(resources.GetObject("m_btCancelar.ImageIndex")));
			this.m_btCancelar.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("m_btCancelar.ImeMode")));
			this.m_btCancelar.Location = ((System.Drawing.Point)(resources.GetObject("m_btCancelar.Location")));
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("m_btCancelar.RightToLeft")));
			this.m_btCancelar.Size = ((System.Drawing.Size)(resources.GetObject("m_btCancelar.Size")));
			this.m_btCancelar.TabIndex = ((int)(resources.GetObject("m_btCancelar.TabIndex")));
			this.m_btCancelar.Text = resources.GetString("m_btCancelar.Text");
			this.m_btCancelar.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("m_btCancelar.TextAlign")));
			this.m_ttLista.SetToolTip(this.m_btCancelar, resources.GetString("m_btCancelar.ToolTip"));
			this.m_btCancelar.Visible = ((bool)(resources.GetObject("m_btCancelar.Visible")));
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbFields
			// 
			this.m_gbFields.AccessibleDescription = resources.GetString("m_gbFields.AccessibleDescription");
			this.m_gbFields.AccessibleName = resources.GetString("m_gbFields.AccessibleName");
			this.m_gbFields.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("m_gbFields.Anchor")));
			this.m_gbFields.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_gbFields.BackgroundImage")));
			this.m_gbFields.Controls.Add(this.m_lvListaModelos);
			this.m_gbFields.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("m_gbFields.Dock")));
			this.m_gbFields.Enabled = ((bool)(resources.GetObject("m_gbFields.Enabled")));
			this.m_gbFields.Font = ((System.Drawing.Font)(resources.GetObject("m_gbFields.Font")));
			this.m_gbFields.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("m_gbFields.ImeMode")));
			this.m_gbFields.Location = ((System.Drawing.Point)(resources.GetObject("m_gbFields.Location")));
			this.m_gbFields.Name = "m_gbFields";
			this.m_gbFields.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("m_gbFields.RightToLeft")));
			this.m_gbFields.Size = ((System.Drawing.Size)(resources.GetObject("m_gbFields.Size")));
			this.m_gbFields.TabIndex = ((int)(resources.GetObject("m_gbFields.TabIndex")));
			this.m_gbFields.TabStop = false;
			this.m_gbFields.Text = resources.GetString("m_gbFields.Text");
			this.m_ttLista.SetToolTip(this.m_gbFields, resources.GetString("m_gbFields.ToolTip"));
			this.m_gbFields.Visible = ((bool)(resources.GetObject("m_gbFields.Visible")));
			// 
			// m_lvListaModelos
			// 
			this.m_lvListaModelos.AccessibleDescription = resources.GetString("m_lvListaModelos.AccessibleDescription");
			this.m_lvListaModelos.AccessibleName = resources.GetString("m_lvListaModelos.AccessibleName");
			this.m_lvListaModelos.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.m_lvListaModelos.Alignment = ((System.Windows.Forms.ListViewAlignment)(resources.GetObject("m_lvListaModelos.Alignment")));
			this.m_lvListaModelos.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("m_lvListaModelos.Anchor")));
			this.m_lvListaModelos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_lvListaModelos.BackgroundImage")));
			this.m_lvListaModelos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							   this.m_chFirst,
																							   this.m_chSecond});
			this.m_lvListaModelos.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("m_lvListaModelos.Dock")));
			this.m_lvListaModelos.Enabled = ((bool)(resources.GetObject("m_lvListaModelos.Enabled")));
			this.m_lvListaModelos.Font = ((System.Drawing.Font)(resources.GetObject("m_lvListaModelos.Font")));
			this.m_lvListaModelos.FullRowSelect = true;
			this.m_lvListaModelos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lvListaModelos.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("m_lvListaModelos.ImeMode")));
			this.m_lvListaModelos.LabelWrap = ((bool)(resources.GetObject("m_lvListaModelos.LabelWrap")));
			this.m_lvListaModelos.Location = ((System.Drawing.Point)(resources.GetObject("m_lvListaModelos.Location")));
			this.m_lvListaModelos.MultiSelect = false;
			this.m_lvListaModelos.Name = "m_lvListaModelos";
			this.m_lvListaModelos.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("m_lvListaModelos.RightToLeft")));
			this.m_lvListaModelos.Size = ((System.Drawing.Size)(resources.GetObject("m_lvListaModelos.Size")));
			this.m_lvListaModelos.TabIndex = ((int)(resources.GetObject("m_lvListaModelos.TabIndex")));
			this.m_lvListaModelos.Text = resources.GetString("m_lvListaModelos.Text");
			this.m_ttLista.SetToolTip(this.m_lvListaModelos, resources.GetString("m_lvListaModelos.ToolTip"));
			this.m_lvListaModelos.View = System.Windows.Forms.View.Details;
			this.m_lvListaModelos.Visible = ((bool)(resources.GetObject("m_lvListaModelos.Visible")));
			this.m_lvListaModelos.DoubleClick += new System.EventHandler(this.m_lvListaModelos_DoubleClick);
			// 
			// m_chFirst
			// 
			this.m_chFirst.Text = resources.GetString("m_chFirst.Text");
			this.m_chFirst.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("m_chFirst.TextAlign")));
			this.m_chFirst.Width = ((int)(resources.GetObject("m_chFirst.Width")));
			// 
			// m_chSecond
			// 
			this.m_chSecond.Text = resources.GetString("m_chSecond.Text");
			this.m_chSecond.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("m_chSecond.TextAlign")));
			this.m_chSecond.Width = ((int)(resources.GetObject("m_chSecond.Width")));
			// 
			// m_ttLista
			// 
			this.m_ttLista.AutomaticDelay = 100;
			this.m_ttLista.AutoPopDelay = 5000;
			this.m_ttLista.InitialDelay = 100;
			this.m_ttLista.ReshowDelay = 20;
			// 
			// frmFLista
			// 
			this.AccessibleDescription = resources.GetString("$this.AccessibleDescription");
			this.AccessibleName = resources.GetString("$this.AccessibleName");
			this.AutoScaleBaseSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScaleBaseSize")));
			this.AutoScroll = ((bool)(resources.GetObject("$this.AutoScroll")));
			this.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMargin")));
			this.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMinSize")));
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = ((System.Drawing.Size)(resources.GetObject("$this.ClientSize")));
			this.Controls.Add(this.m_gbFrame);
			this.Enabled = ((bool)(resources.GetObject("$this.Enabled")));
			this.Font = ((System.Drawing.Font)(resources.GetObject("$this.Font")));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("$this.ImeMode")));
			this.Location = ((System.Drawing.Point)(resources.GetObject("$this.Location")));
			this.MaximizeBox = false;
			this.MaximumSize = ((System.Drawing.Size)(resources.GetObject("$this.MaximumSize")));
			this.MinimizeBox = false;
			this.MinimumSize = ((System.Drawing.Size)(resources.GetObject("$this.MinimumSize")));
			this.Name = "frmFLista";
			this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
			this.ShowInTaskbar = false;
			this.StartPosition = ((System.Windows.Forms.FormStartPosition)(resources.GetObject("$this.StartPosition")));
			this.Text = resources.GetString("$this.Text");
			this.m_ttLista.SetToolTip(this, resources.GetString("$this.ToolTip"));
			this.Load += new System.EventHandler(this.frmFLista_Load);
			this.m_gbFrame.ResumeLayout(false);
			this.m_gbFields.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Cores
			private void trocaCor()
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
									"mdlComponentesGraficos.ListView") &&
									(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
									"mdlComponentesGraficos.ComboBox") &&
									(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
									"mdlComponentesGraficos.TextBox"))
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

		#region Eventos
			#region Formulario
				private void frmFLista_Load(object sender, System.EventArgs e)
				{
					this.mostraCor();
					OnCallCarregaDadosInterface();
				}
			#endregion
			#region ListView
				private void m_lvListaModelos_DoubleClick(object sender, System.EventArgs e)
				{
					try
					{
						this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
						if (m_lvListaModelos.SelectedItems.Count > 0)
						{
							m_bModificado = true;
							OnCallSelecionaItemLista();
							this.Close();
						}
						else
						{
							this.Cursor = System.Windows.Forms.Cursors.Default;
							mdlMensagens.clsMensagens.ShowInformation(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlCriacaoDocumentos_frmFLista_SelecionarFatura));
							//MessageBox.Show("Você precisa selecionar a fatura desejada.",this.Text);
						}
					}
					catch (Exception err)
					{
						Object erro = err;
						m_cls_ter_tratadorErro.trataErro(ref erro);
					}
				}
			#endregion
			#region Botoes
				private void m_btTrocarCor_Click(object sender, System.EventArgs e)
				{
					try
					{
						this.trocaCor();
					}
					catch (Exception err)
					{
						Object erro = err;
						m_cls_ter_tratadorErro.trataErro(ref erro);
					}
				}

				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					try
					{
						this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
						if (m_lvListaModelos.SelectedItems.Count > 0)
						{
							m_bModificado = true;
							OnCallSelecionaItemLista();
							this.Close();
						}
						else
						{
							this.Cursor = System.Windows.Forms.Cursors.Default;
							mdlMensagens.clsMensagens.ShowInformation(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlCriacaoDocumentos_frmFLista_SelecionarFatura));
							//MessageBox.Show("Você precisa selecionar a fatura desejada.",this.Text);
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
					this.m_bModificado = false;
					this.Close();
				}
			#endregion
		#endregion
	}
}
