using System;
using System.Collections;
using System.Windows.Forms;

namespace mdlAgentes.Frames
{
	/// <summary>
	/// Summary description for frmFListaContatos.
	/// </summary>
	internal class frmFListaContatos : mdlComponentesGraficos.FormFlutuante
	{
		#region Delegate
			public delegate void delCallCarregaDadosBDContatos(ref mdlComponentesGraficos.ListView lvContatos);
			public delegate void delCallCarregaDadosInterface(ref mdlComponentesGraficos.ListView lvContatos, ref System.Windows.Forms.Button btEditar, ref System.Windows.Forms.Button btExcluir);
			public delegate void delCallCarregaDadosInterfaceCompleta(ref mdlComponentesGraficos.ListView lvContatos, ref System.Windows.Forms.Button btEditar, ref System.Windows.Forms.Button btExcluir, ref System.Windows.Forms.GroupBox gbFields, out string strCaption);
			public delegate void delCallCarregaDadosContatoInterface(ref mdlComponentesGraficos.ListView lvDadosContato);
			public delegate void delCallCancelaSalvamento(bool bModificado);
			public delegate void delCallSalvaDadosBD(bool bModificado);
			public delegate void delCallEditaContato();
			public delegate void delCallCadastraContato();
			public delegate void delCallExcluiContatos(ref mdlComponentesGraficos.ListView lvContatos);
			// Método extra só para modificar visual
			public delegate void delCallModificaVisibilidade(ref mdlComponentesGraficos.ListView lvLista, ref mdlComponentesGraficos.ListView lvDados);
		#endregion
		#region Events
			public event delCallCarregaDadosBDContatos eCallCarregaDadosBDContatos;
			public event delCallCarregaDadosInterface eCallCarregaDadosInterface;
			public event delCallCarregaDadosInterfaceCompleta eCallCarregaDadosInterfaceCompleta;
			public event delCallCarregaDadosContatoInterface eCallCarregaDadosContatoInterface;
			public event delCallCancelaSalvamento eCallCancelaSalvamento;
			public event delCallSalvaDadosBD eCallSalvaDadosBD;
			public event delCallEditaContato eCallEditaContato;
			public event delCallCadastraContato eCallCadastraContato;
			public event delCallExcluiContatos eCallExcluiContatos;
			// Auxiliar
			public event delCallModificaVisibilidade eCallModificaVisibilidade;
		#endregion
		#region Events Methods
			protected virtual void OnCallCarregaDadosBDContatos()
			{
				if (eCallCarregaDadosBDContatos != null)
					eCallCarregaDadosBDContatos(ref m_lvContato);
			}
			protected virtual void OnCallCarregaDadosInterface()
			{
				if (eCallCarregaDadosInterface != null)
					eCallCarregaDadosInterface(ref m_lvContato, ref m_btEditar, ref m_btExcluir);
			}
			protected virtual void OnCallCarregaDadosInterfaceCompleta(out string strCaption)
			{
				strCaption = "";
				if (eCallCarregaDadosInterfaceCompleta != null)
					eCallCarregaDadosInterfaceCompleta(ref m_lvContato, ref m_btEditar, ref m_btExcluir, ref m_gbFields, out strCaption);
			}
			protected virtual void OnCallCarregaDadosContatoInterface()
			{
				if (eCallCarregaDadosContatoInterface != null)
					eCallCarregaDadosContatoInterface(ref m_lvDadosContatos);
			}
			protected virtual void OnCallCancelaSalvamento()
			{
				if (eCallCancelaSalvamento != null)
					eCallCancelaSalvamento(m_bModificado);
			}
			protected virtual void OnCallSalvaDadosBD()
			{
				if (eCallSalvaDadosBD != null)
					eCallSalvaDadosBD(m_bModificado);
			}
			protected virtual void OnCallEditaContato()
			{
				if (eCallEditaContato != null)
					eCallEditaContato();
			}
			protected virtual void OnCallCadastraContato()
			{
				if (eCallCadastraContato != null)
					eCallCadastraContato();
			}
			protected virtual void OnCallExcluiContatos()
			{
				if (eCallExcluiContatos != null)
					eCallExcluiContatos(ref m_lvContato);
			}
			protected virtual void OnCallModificaVisibilidade()
			{
				if (eCallModificaVisibilidade != null)
					eCallModificaVisibilidade(ref m_lvContato, ref m_lvDadosContatos);
			}
		#endregion

		#region Atributos
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
		protected string m_strEnderecoExecutavel;

		public bool m_bModificado = false;
		protected bool m_bAtiva = true;

		private System.Windows.Forms.GroupBox m_gbFrame;
		private System.Windows.Forms.Button m_btTrocarCor;
		private System.Windows.Forms.Button m_btOk;
		private System.Windows.Forms.Button m_btCancelar;
		private System.Windows.Forms.GroupBox m_gbFields;
		private System.Windows.Forms.Button m_btExcluir;
		private System.Windows.Forms.Button m_btEditar;
		private System.Windows.Forms.Button m_btNovo;
		private System.Windows.Forms.ColumnHeader m_chFirst;
		private mdlComponentesGraficos.ListView m_lvContato;
		private mdlComponentesGraficos.ListView m_lvDadosContatos;
		private System.Windows.Forms.ColumnHeader m_chFirstTwo;
		private System.Windows.Forms.ColumnHeader m_chSecondTwo;
		private System.Windows.Forms.ToolTip m_ttContatos;
		private System.ComponentModel.IContainer components;
		#endregion
		#region Construtores & Destrutores
		public frmFListaContatos(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, string EnderecoExecutavel)
		{
			InitializeComponent();

			m_cls_ter_tratadorErro = tratadorErro;
			m_strEnderecoExecutavel = EnderecoExecutavel;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFListaContatos));
			this.m_gbFrame = new System.Windows.Forms.GroupBox();
			this.m_btTrocarCor = new System.Windows.Forms.Button();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbFields = new System.Windows.Forms.GroupBox();
			this.m_lvDadosContatos = new mdlComponentesGraficos.ListView();
			this.m_chFirstTwo = new System.Windows.Forms.ColumnHeader();
			this.m_chSecondTwo = new System.Windows.Forms.ColumnHeader();
			this.m_btExcluir = new System.Windows.Forms.Button();
			this.m_btEditar = new System.Windows.Forms.Button();
			this.m_btNovo = new System.Windows.Forms.Button();
			this.m_lvContato = new mdlComponentesGraficos.ListView();
			this.m_chFirst = new System.Windows.Forms.ColumnHeader();
			this.m_ttContatos = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbFrame.SuspendLayout();
			this.m_gbFields.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbFrame
			// 
			this.m_gbFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFrame.Controls.Add(this.m_btTrocarCor);
			this.m_gbFrame.Controls.Add(this.m_btOk);
			this.m_gbFrame.Controls.Add(this.m_btCancelar);
			this.m_gbFrame.Controls.Add(this.m_gbFields);
			this.m_gbFrame.Location = new System.Drawing.Point(2, 0);
			this.m_gbFrame.Name = "m_gbFrame";
			this.m_gbFrame.Size = new System.Drawing.Size(278, 293);
			this.m_gbFrame.TabIndex = 1;
			this.m_gbFrame.TabStop = false;
			// 
			// m_btTrocarCor
			// 
			this.m_btTrocarCor.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_btTrocarCor.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_btTrocarCor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btTrocarCor.Location = new System.Drawing.Point(4, 10);
			this.m_btTrocarCor.Name = "m_btTrocarCor";
			this.m_btTrocarCor.Size = new System.Drawing.Size(4, 4);
			this.m_btTrocarCor.TabIndex = 3;
			this.m_ttContatos.SetToolTip(this.m_btTrocarCor, "Cor");
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
			this.m_btOk.Location = new System.Drawing.Point(79, 262);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 1;
			this.m_ttContatos.SetToolTip(this.m_btOk, "Confirmar");
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(143, 262);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 2;
			this.m_ttContatos.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbFields
			// 
			this.m_gbFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFields.Controls.Add(this.m_lvDadosContatos);
			this.m_gbFields.Controls.Add(this.m_btExcluir);
			this.m_gbFields.Controls.Add(this.m_btEditar);
			this.m_gbFields.Controls.Add(this.m_btNovo);
			this.m_gbFields.Controls.Add(this.m_lvContato);
			this.m_gbFields.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbFields.Location = new System.Drawing.Point(8, 8);
			this.m_gbFields.Name = "m_gbFields";
			this.m_gbFields.Size = new System.Drawing.Size(262, 249);
			this.m_gbFields.TabIndex = 0;
			this.m_gbFields.TabStop = false;
			// 
			// m_lvDadosContatos
			// 
			this.m_lvDadosContatos.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.m_lvDadosContatos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lvDadosContatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_lvDadosContatos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																								this.m_chFirstTwo,
																								this.m_chSecondTwo});
			this.m_lvDadosContatos.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lvDadosContatos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lvDadosContatos.HideSelection = false;
			this.m_lvDadosContatos.Location = new System.Drawing.Point(8, 176);
			this.m_lvDadosContatos.Name = "m_lvDadosContatos";
			this.m_lvDadosContatos.Size = new System.Drawing.Size(245, 65);
			this.m_lvDadosContatos.TabIndex = 6;
			this.m_lvDadosContatos.View = System.Windows.Forms.View.Details;
			// 
			// m_chSecondTwo
			// 
			this.m_chSecondTwo.Width = 140;
			// 
			// m_btExcluir
			// 
			this.m_btExcluir.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_btExcluir.BackColor = System.Drawing.SystemColors.Control;
			this.m_btExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btExcluir.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btExcluir.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btExcluir.Image = ((System.Drawing.Image)(resources.GetObject("m_btExcluir.Image")));
			this.m_btExcluir.Location = new System.Drawing.Point(151, 20);
			this.m_btExcluir.Name = "m_btExcluir";
			this.m_btExcluir.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btExcluir.Size = new System.Drawing.Size(25, 25);
			this.m_btExcluir.TabIndex = 3;
			this.m_btExcluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttContatos.SetToolTip(this.m_btExcluir, "Excluir");
			this.m_btExcluir.Click += new System.EventHandler(this.m_btExcluir_Click);
			// 
			// m_btEditar
			// 
			this.m_btEditar.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_btEditar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btEditar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btEditar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btEditar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btEditar.Image = ((System.Drawing.Image)(resources.GetObject("m_btEditar.Image")));
			this.m_btEditar.Location = new System.Drawing.Point(119, 20);
			this.m_btEditar.Name = "m_btEditar";
			this.m_btEditar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btEditar.Size = new System.Drawing.Size(25, 25);
			this.m_btEditar.TabIndex = 2;
			this.m_btEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttContatos.SetToolTip(this.m_btEditar, "Editar");
			this.m_btEditar.Click += new System.EventHandler(this.m_btEditar_Click);
			// 
			// m_btNovo
			// 
			this.m_btNovo.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_btNovo.BackColor = System.Drawing.SystemColors.Control;
			this.m_btNovo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btNovo.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btNovo.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btNovo.Image = ((System.Drawing.Image)(resources.GetObject("m_btNovo.Image")));
			this.m_btNovo.Location = new System.Drawing.Point(87, 20);
			this.m_btNovo.Name = "m_btNovo";
			this.m_btNovo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btNovo.Size = new System.Drawing.Size(25, 25);
			this.m_btNovo.TabIndex = 1;
			this.m_btNovo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttContatos.SetToolTip(this.m_btNovo, "Novo");
			this.m_btNovo.Click += new System.EventHandler(this.m_btNovo_Click);
			// 
			// m_lvContato
			// 
			this.m_lvContato.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.m_lvContato.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lvContato.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						  this.m_chFirst});
			this.m_lvContato.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lvContato.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lvContato.HideSelection = false;
			this.m_lvContato.Location = new System.Drawing.Point(8, 50);
			this.m_lvContato.Name = "m_lvContato";
			this.m_lvContato.Size = new System.Drawing.Size(245, 121);
			this.m_lvContato.TabIndex = 5;
			this.m_lvContato.View = System.Windows.Forms.View.Details;
			this.m_lvContato.DoubleClick += new System.EventHandler(this.m_lvContato_DoubleClick);
			this.m_lvContato.Click += new System.EventHandler(this.m_lvContato_Click);
			this.m_lvContato.SelectedIndexChanged += new System.EventHandler(this.m_lvContato_SelectedIndexChanged);
			this.m_lvContato.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_lvContato_MouseUp);
			// 
			// m_chFirst
			// 
			this.m_chFirst.Width = 200;
			// 
			// m_ttContatos
			// 
			this.m_ttContatos.AutomaticDelay = 100;
			this.m_ttContatos.AutoPopDelay = 5000;
			this.m_ttContatos.InitialDelay = 100;
			this.m_ttContatos.ReshowDelay = 20;
			// 
			// frmFListaContatos
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(282, 295);
			this.Controls.Add(this.m_gbFrame);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFListaContatos";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Agente / Contatos";
			this.Load += new System.EventHandler(this.frmFListaContatos_Load);
			this.m_gbFrame.ResumeLayout(false);
			this.m_gbFields.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
	
		#region Procedimentos Para Troca de Cor
		/// <summary>
		/// Troca a cor do Formulario Controlado
		/// </summary>
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
						if ((this.Controls[cont].Controls[cont2].GetType().ToString() != "System.Windows.Forms.ListView") && (this.Controls[cont].Controls[cont2].GetType().ToString() != "mdlComponentes.compTextNumber"))
						{
							this.Controls[cont].Controls[cont2].BackColor = this.BackColor;
						}
						for (int cont3 = 0; cont3 < this.Controls[cont].Controls[cont2].Controls.Count; cont3++)
						{
							if ((this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.ListView") ||
								((this.Controls[cont].Controls[cont2].Controls[cont3].Name == "m_lvDadosContatos") &&
								(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() == 
								"mdlComponentesGraficos.ListView")))
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

		#region Refreshs
		private void refreshAll()
		{
			string strCaption;
			OnCallCarregaDadosBDContatos();
			OnCallCarregaDadosInterface();
			OnCallCarregaDadosInterfaceCompleta(out strCaption);
			OnCallCarregaDadosContatoInterface();
		}
		#endregion

		#region Eventos
		#region Load
		private void frmFListaContatos_Load(object sender, System.EventArgs e)
		{
			try 
			{
				string strCaption = "";
				this.mostraCor();
				//				OnCallCarregaDadosBD();
				OnCallCarregaDadosBDContatos();
				OnCallCarregaDadosInterface();
				OnCallCarregaDadosInterfaceCompleta(out strCaption);
				OnCallCarregaDadosContatoInterface();
				//				this.m_lvImportadores.Focus();
				if (strCaption.Trim() != "")
					this.Text = strCaption;
				OnCallModificaVisibilidade();
			} 
			catch
			{
			}
		}
		#endregion
		#region Ok
		private void m_btOk_Click(object sender, System.EventArgs e)
		{
			try 
			{
				this.m_bModificado = true;
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				//				OnCallSalvaDadosInterface();
				OnCallSalvaDadosBD();
				this.Cursor = System.Windows.Forms.Cursors.Default;
				this.Close();
			} 
			catch
			{
			}
		}
		#endregion
		#region Cancelar
		private void m_btCancelar_Click(object sender, System.EventArgs e)
		{
			this.m_bModificado = false;
			OnCallCancelaSalvamento();
			this.Close();
		}
		#endregion
		#region Editar
		private void m_btEditar_Click(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			if (m_lvContato.SelectedItems.Count > 0)
			{
				OnCallEditaContato();
				refreshAll();
			}
			else
			{
				//mdlMensagens.clsMensagens.ShowInformation(this.Text, mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlImportador_frmFImportador_ImportadorNaoSelecionadoEdicao));
				//System.Windows.Forms.MessageBox.Show("Você precisa selecionar o importador que deseja editar!",this.Text);
			}
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}
		#endregion
		#region Novo
		private void m_btNovo_Click(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			OnCallCadastraContato();
			refreshAll();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}
		#endregion
		#region Excluir
		private void m_btExcluir_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (m_lvContato.SelectedItems.Count > 0)
				{
					OnCallExcluiContatos();
					this.refreshAll();
				}
				else
				{
					//mdlMensagens.clsMensagens.ShowInformation(this.Text, mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlImportador_frmFImportador_ImportadorNaoSelecionadoExclusao));
					//System.Windows.Forms.MessageBox.Show("Você precisa selecionar o importador que deseja excluir!",this.Text);
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region List View Clique
		private void m_lvContato_Click(object sender, System.EventArgs e)
		{
			if (m_bAtiva == true)
			{
				m_bAtiva = false;
				OnCallCarregaDadosBDContatos();
				OnCallCarregaDadosContatoInterface();
				m_bAtiva = true;
			}
		}
		#endregion
		#region List View Duplo Clique
		private void m_lvContato_DoubleClick(object sender, System.EventArgs e)
		{
			try 
			{
				m_btEditar_Click(sender, e);
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Selected Index Changed
		private void m_lvContato_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (m_bAtiva == true)
				{
					m_bAtiva = false;
					OnCallCarregaDadosBDContatos();
					OnCallCarregaDadosContatoInterface();
					m_bAtiva = true;
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Mouse UP
		private void m_lvContato_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			try
			{
				if (m_lvContato.GetItemAt(e.X,e.Y) == null)
					m_lvContato.SelectedItems.Clear();
				if (m_bAtiva == true)
				{
					m_bAtiva = false;
					OnCallCarregaDadosBDContatos();
					OnCallCarregaDadosContatoInterface();
					m_bAtiva = true;
				}
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
			this.trocaCor();
		}
		#endregion
		#endregion
	}
}
