using System;
using System.Collections;
using System.Windows.Forms;

namespace mdlEnderecoEntrega
{
	/// <summary>
	/// Summary description for frmFEnderecoEntregaImportador.
	/// </summary>
	internal class frmFEnderecoEntregaImportador : mdlComponentesGraficos.FormFlutuante
	{
		#region Atributos
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
		protected string m_strEnderecoExecutavel;

		public bool m_bModificado = false;
		private bool m_bAtivado = false;

		private System.Windows.Forms.GroupBox m_gbFrame;
		private System.Windows.Forms.GroupBox m_gbFields;
		private System.Windows.Forms.Button m_btOk;
		private System.Windows.Forms.Button m_btCancelar;
		private System.Windows.Forms.Button m_btExcluir;
		private System.Windows.Forms.Button m_btEditar;
		private System.Windows.Forms.Button m_btNovo;
		private System.Windows.Forms.Button m_btTrocarCor;
		private System.Windows.Forms.Label m_lDadosEndereco;
		private mdlComponentesGraficos.ListView m_lvEnderecos;
		private mdlComponentesGraficos.ListView m_lvDadosEnderecos;
		private System.Windows.Forms.Label m_lImportador;
		private System.Windows.Forms.Label m_lNomeImportador;
		private System.Windows.Forms.ColumnHeader m_chFirst;
		private System.Windows.Forms.ToolTip m_ttEnderecoEntrega;
		private System.Windows.Forms.ColumnHeader m_chEndEntrega;
		private System.ComponentModel.IContainer components = null;
		#endregion

		#region Construtores & Destrutores
		public frmFEnderecoEntregaImportador(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, string EnderecoExecutavel)
		{
			//
			// Required for Windows Form Designer support
			//
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

		#region Delegate
		// Delegate para BD
		public delegate void delCallCarregaDadosBD();
		public delegate void delCallCarregaDadosBDEnderecos();
		public delegate void delCallCarregaDadosEnderecosSelecionado(ref mdlComponentesGraficos.ListView lvEnderecos);
		public delegate void delCallCarregaDadosInterface(ref mdlComponentesGraficos.ListView lvEnderecos, ref System.Windows.Forms.Button btEditar, ref System.Windows.Forms.Button btExcluir, ref System.Windows.Forms.Label lNomeImportador);
		public delegate void delCallCarregaDadosEnderecoInterface(ref mdlComponentesGraficos.ListView lvDadosEnderecos);
		public delegate void delCallChecaIntegridadeDados();
		public delegate void delCallSalvaDadosInterface(ref mdlComponentesGraficos.ListView lvEnderecos);
		public delegate void delCallSalvaDadosBD(bool bModificado);
		// Delegate para Editar Importadores
		public delegate void delCallEditaEndereco();
		public delegate void delCallCadastraEndereco();
		public delegate void delCallRemoveEndereco(ref mdlComponentesGraficos.ListView lvEnderecos);
		#endregion
		#region Events
		// Events BD
		public event delCallCarregaDadosBD eCallCarregaDadosBD;
		public event delCallCarregaDadosBDEnderecos eCallCarregaDadosBDEnderecos;
		public event delCallCarregaDadosEnderecosSelecionado eCallCarregaDadosEnderecosSelecionado;
		public event delCallCarregaDadosInterface eCallCarregaDadosInterface;
		public event delCallCarregaDadosEnderecoInterface eCallCarregaDadosEnderecoInterface;
		public event delCallChecaIntegridadeDados eCallChecaIntegridadeDados;
		public event delCallSalvaDadosInterface eCallSalvaDadosInterface;
		public event delCallSalvaDadosBD eCallSalvaDadosBD;
		// Events Editar / Cadastrar Importadores
		public event delCallEditaEndereco eCallEditaEndereco;
		public event delCallCadastraEndereco eCallCadastraEndereco;
		public event delCallRemoveEndereco eCallRemoveEndereco;
		#endregion
		#region Events Methods
		protected virtual void OnCallCarregaDadosBD()
		{
			if (eCallCarregaDadosBD != null)
				eCallCarregaDadosBD();
		}

		protected virtual void OnCallCarregaDadosBDEnderecos()
		{
			if (eCallCarregaDadosBDEnderecos != null)
				eCallCarregaDadosBDEnderecos();
		}

		protected virtual void OnCallCarregaDadosEnderecosSelecionado()
		{
			if (eCallCarregaDadosEnderecosSelecionado != null)
				eCallCarregaDadosEnderecosSelecionado(ref this.m_lvEnderecos);
		}
 
		protected virtual void OnCallCarregaDadosEnderecoInterface()
		{
			if (eCallCarregaDadosEnderecoInterface != null)
				eCallCarregaDadosEnderecoInterface(ref this.m_lvDadosEnderecos);
		}

		protected virtual void OnCallCarregaDadosInterface()
		{
			if (eCallCarregaDadosInterface != null)
				eCallCarregaDadosInterface(ref this.m_lvEnderecos, ref this.m_btEditar, ref this.m_btExcluir, ref this.m_lNomeImportador);
		} 

		protected virtual void OnCallChecaIntegridadeDados()
		{
			if (eCallChecaIntegridadeDados != null)
				eCallChecaIntegridadeDados();
		}

		protected virtual void OnCallSalvaDadosInterface()
		{
			if (eCallSalvaDadosInterface != null)
				eCallSalvaDadosInterface(ref this.m_lvEnderecos);
		} 

		protected virtual void OnCallSalvaDadosBD()
		{
			if (eCallSalvaDadosBD != null)
				eCallSalvaDadosBD(this.m_bModificado);
		}
		protected virtual void OnCallCadastraEndereco()
		{
			if (eCallCadastraEndereco != null)
				eCallCadastraEndereco();
		}
		protected virtual void OnCallEditaEndereco()
		{
			if (eCallEditaEndereco != null)
				eCallEditaEndereco();
		}
		protected virtual void OnCallRemoveEndereco()
		{
			if (eCallRemoveEndereco != null)
				eCallRemoveEndereco(ref this.m_lvEnderecos);
		}
		#endregion

		#region Procedimentos Para Troca de Cor
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
						if ((this.Controls[cont].Controls[cont2].GetType().ToString() != "System.Windows.Forms.ListView") && (this.Controls[cont].Controls[cont2].GetType().ToString() != "mdlComponentes.compTextNumber") &&
							(this.Controls[cont].Controls[cont2].Name != "m_lvDadosEnderecos"))
						{
							this.Controls[cont].Controls[cont2].BackColor = this.BackColor;
						}
						for (int cont3 = 0; cont3 < this.Controls[cont].Controls[cont2].Controls.Count; cont3++)
						{
							if ((this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.ListView") ||
								((this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() == 
								"mdlComponentesGraficos.ListView") && (this.Controls[cont].Controls[cont2].Controls[cont3].Name == "m_lvDadosEnderecos")))
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

		#region Refresh
		protected void refreshAll()
		{
			try
			{
				this.mostraCor();
				OnCallCarregaDadosBD();
				OnCallCarregaDadosInterface();
				OnCallCarregaDadosEnderecosSelecionado();
				OnCallCarregaDadosEnderecoInterface();
				this.m_lvEnderecos.Focus();
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected void refresh()
		{
			try
			{
				this.mostraCor();
				OnCallCarregaDadosInterface();
				OnCallCarregaDadosEnderecoInterface();
				this.m_lvEnderecos.Focus();
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFEnderecoEntregaImportador));
			this.m_gbFrame = new System.Windows.Forms.GroupBox();
			this.m_btTrocarCor = new System.Windows.Forms.Button();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbFields = new System.Windows.Forms.GroupBox();
			this.m_lNomeImportador = new System.Windows.Forms.Label();
			this.m_lImportador = new System.Windows.Forms.Label();
			this.m_lvDadosEnderecos = new mdlComponentesGraficos.ListView();
			this.m_chFirst = new System.Windows.Forms.ColumnHeader();
			this.m_lvEnderecos = new mdlComponentesGraficos.ListView();
			this.m_chEndEntrega = new System.Windows.Forms.ColumnHeader();
			this.m_lDadosEndereco = new System.Windows.Forms.Label();
			this.m_btExcluir = new System.Windows.Forms.Button();
			this.m_btEditar = new System.Windows.Forms.Button();
			this.m_btNovo = new System.Windows.Forms.Button();
			this.m_ttEnderecoEntrega = new System.Windows.Forms.ToolTip(this.components);
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
			this.m_gbFrame.Location = new System.Drawing.Point(4, 0);
			this.m_gbFrame.Name = "m_gbFrame";
			this.m_gbFrame.Size = new System.Drawing.Size(358, 355);
			this.m_gbFrame.TabIndex = 0;
			this.m_gbFrame.TabStop = false;
			// 
			// m_btTrocarCor
			// 
			this.m_btTrocarCor.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_btTrocarCor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btTrocarCor.Location = new System.Drawing.Point(4, 9);
			this.m_btTrocarCor.Name = "m_btTrocarCor";
			this.m_btTrocarCor.Size = new System.Drawing.Size(4, 4);
			this.m_btTrocarCor.TabIndex = 7;
			this.m_ttEnderecoEntrega.SetToolTip(this.m_btTrocarCor, "Cor");
			this.m_btTrocarCor.Click += new System.EventHandler(this.m_btTrocarCor_Click);
			// 
			// m_btOk
			// 
			this.m_btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(119, 324);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 2;
			this.m_ttEnderecoEntrega.SetToolTip(this.m_btOk, "Confirmar");
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(183, 324);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 3;
			this.m_ttEnderecoEntrega.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbFields
			// 
			this.m_gbFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFields.Controls.Add(this.m_lNomeImportador);
			this.m_gbFields.Controls.Add(this.m_lImportador);
			this.m_gbFields.Controls.Add(this.m_lvDadosEnderecos);
			this.m_gbFields.Controls.Add(this.m_lvEnderecos);
			this.m_gbFields.Controls.Add(this.m_lDadosEndereco);
			this.m_gbFields.Controls.Add(this.m_btExcluir);
			this.m_gbFields.Controls.Add(this.m_btEditar);
			this.m_gbFields.Controls.Add(this.m_btNovo);
			this.m_gbFields.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbFields.Location = new System.Drawing.Point(8, 8);
			this.m_gbFields.Name = "m_gbFields";
			this.m_gbFields.Size = new System.Drawing.Size(342, 311);
			this.m_gbFields.TabIndex = 0;
			this.m_gbFields.TabStop = false;
			// 
			// m_lNomeImportador
			// 
			this.m_lNomeImportador.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lNomeImportador.Location = new System.Drawing.Point(80, 36);
			this.m_lNomeImportador.Name = "m_lNomeImportador";
			this.m_lNomeImportador.Size = new System.Drawing.Size(256, 18);
			this.m_lNomeImportador.TabIndex = 0;
			// 
			// m_lImportador
			// 
			this.m_lImportador.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lImportador.Location = new System.Drawing.Point(6, 36);
			this.m_lImportador.Name = "m_lImportador";
			this.m_lImportador.Size = new System.Drawing.Size(68, 18);
			this.m_lImportador.TabIndex = 0;
			this.m_lImportador.Text = "Importador:";
			// 
			// m_lvDadosEnderecos
			// 
			this.m_lvDadosEnderecos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_lvDadosEnderecos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																								 this.m_chFirst});
			this.m_lvDadosEnderecos.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lvDadosEnderecos.FullRowSelect = true;
			this.m_lvDadosEnderecos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lvDadosEnderecos.HideSelection = false;
			this.m_lvDadosEnderecos.Location = new System.Drawing.Point(8, 236);
			this.m_lvDadosEnderecos.Name = "m_lvDadosEnderecos";
			this.m_lvDadosEnderecos.Size = new System.Drawing.Size(326, 67);
			this.m_lvDadosEnderecos.TabIndex = 0;
			this.m_lvDadosEnderecos.View = System.Windows.Forms.View.Details;
			// 
			// m_chFirst
			// 
			this.m_chFirst.Width = 306;
			// 
			// m_lvEnderecos
			// 
			this.m_lvEnderecos.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.m_lvEnderecos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							this.m_chEndEntrega});
			this.m_lvEnderecos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lvEnderecos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lvEnderecos.HideSelection = false;
			this.m_lvEnderecos.Location = new System.Drawing.Point(8, 96);
			this.m_lvEnderecos.Name = "m_lvEnderecos";
			this.m_lvEnderecos.Size = new System.Drawing.Size(326, 112);
			this.m_lvEnderecos.TabIndex = 1;
			this.m_ttEnderecoEntrega.SetToolTip(this.m_lvEnderecos, "Selecionar endereço");
			this.m_lvEnderecos.View = System.Windows.Forms.View.Details;
			this.m_lvEnderecos.DoubleClick += new System.EventHandler(this.m_lvEnderecos_DoubleClick);
			this.m_lvEnderecos.Click += new System.EventHandler(this.m_lvEnderecos_Click);
			// 
			// m_chEndEntrega
			// 
			this.m_chEndEntrega.Width = 290;
			// 
			// m_lDadosEndereco
			// 
			this.m_lDadosEndereco.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lDadosEndereco.Location = new System.Drawing.Point(6, 212);
			this.m_lDadosEndereco.Name = "m_lDadosEndereco";
			this.m_lDadosEndereco.Size = new System.Drawing.Size(151, 18);
			this.m_lDadosEndereco.TabIndex = 0;
			this.m_lDadosEndereco.Text = "Dados do Endereço:";
			// 
			// m_btExcluir
			// 
			this.m_btExcluir.BackColor = System.Drawing.SystemColors.Control;
			this.m_btExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btExcluir.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btExcluir.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btExcluir.Image = ((System.Drawing.Image)(resources.GetObject("m_btExcluir.Image")));
			this.m_btExcluir.Location = new System.Drawing.Point(191, 65);
			this.m_btExcluir.Name = "m_btExcluir";
			this.m_btExcluir.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btExcluir.Size = new System.Drawing.Size(25, 25);
			this.m_btExcluir.TabIndex = 6;
			this.m_btExcluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttEnderecoEntrega.SetToolTip(this.m_btExcluir, "Excluir");
			this.m_btExcluir.Click += new System.EventHandler(this.m_btExcluir_Click);
			// 
			// m_btEditar
			// 
			this.m_btEditar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btEditar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btEditar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btEditar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btEditar.Image = ((System.Drawing.Image)(resources.GetObject("m_btEditar.Image")));
			this.m_btEditar.Location = new System.Drawing.Point(159, 65);
			this.m_btEditar.Name = "m_btEditar";
			this.m_btEditar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btEditar.Size = new System.Drawing.Size(25, 25);
			this.m_btEditar.TabIndex = 5;
			this.m_btEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttEnderecoEntrega.SetToolTip(this.m_btEditar, "Editar");
			this.m_btEditar.Click += new System.EventHandler(this.m_btEditar_Click);
			// 
			// m_btNovo
			// 
			this.m_btNovo.BackColor = System.Drawing.SystemColors.Control;
			this.m_btNovo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btNovo.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btNovo.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btNovo.Image = ((System.Drawing.Image)(resources.GetObject("m_btNovo.Image")));
			this.m_btNovo.Location = new System.Drawing.Point(127, 65);
			this.m_btNovo.Name = "m_btNovo";
			this.m_btNovo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btNovo.Size = new System.Drawing.Size(25, 25);
			this.m_btNovo.TabIndex = 4;
			this.m_btNovo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttEnderecoEntrega.SetToolTip(this.m_btNovo, "Novo");
			this.m_btNovo.Click += new System.EventHandler(this.m_btNovo_Click);
			// 
			// m_ttEnderecoEntrega
			// 
			this.m_ttEnderecoEntrega.AutomaticDelay = 100;
			this.m_ttEnderecoEntrega.AutoPopDelay = 5000;
			this.m_ttEnderecoEntrega.InitialDelay = 100;
			this.m_ttEnderecoEntrega.ReshowDelay = 20;
			// 
			// frmFEnderecoEntregaImportador
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(366, 358);
			this.Controls.Add(this.m_gbFrame);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFEnderecoEntregaImportador";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Endereço de Entrega";
			this.Load += new System.EventHandler(this.frmFEnderecoEntregaImportador_Load);
			this.m_gbFrame.ResumeLayout(false);
			this.m_gbFields.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
		#region OK
		private void m_btOk_Click(object sender, System.EventArgs e)
		{
			try 
			{
				this.m_bModificado = true;
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (this.m_lvEnderecos.SelectedItems.Count > 1)
				{
					mdlMensagens.clsMensagens.ShowInformation(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlEnderecoEntrega_frmFEnderecoEntregaImportador_MaisDeUmEnderecoSelecionado));
					//System.Windows.Forms.MessageBox.Show("É possível selecionar apenas 1(UM)\n endereço de entrega",this.Text);
				}
				else
				{
					OnCallSalvaDadosInterface();
					OnCallSalvaDadosBD();
					this.Close();
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
		#region Cancelar
		private void m_btCancelar_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		#endregion
		#region Load
		private void frmFEnderecoEntregaImportador_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.mostraCor();
				OnCallCarregaDadosInterface();
				OnCallCarregaDadosEnderecoInterface();
				this.m_lvEnderecos.Focus();
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
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				this.mostraCor();
				this.Cursor = System.Windows.Forms.Cursors.Default;
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Excluir
		private void m_btExcluir_Click(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			if (m_lvEnderecos.SelectedItems.Count > 0)
			{
				OnCallRemoveEndereco();
				this.refresh();
			}
			else
			{
				mdlMensagens.clsMensagens.ShowInformation(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlEnderecoEntrega_frmFEnderecoEntregaImportador_EnderecoNaoSelecionadoExclusao));
				//System.Windows.Forms.MessageBox.Show("Você precisa selecionar o endereço que deseja excluir.",this.Text);
			}
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}
		#endregion
		#region Editar
		private void m_btEditar_Click(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			if (m_lvEnderecos.SelectedItems.Count > 0)
			{
				OnCallEditaEndereco();
				this.refresh();
			}
			else
			{
				mdlMensagens.clsMensagens.ShowInformation(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlEnderecoEntrega_frmFEnderecoEntregaImportador_EnderecoNaoSelecionadoEdicao));
				//System.Windows.Forms.MessageBox.Show("Você precisa selecionar o endereço que deseja editar.",this.Text);
			}
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}
		#endregion
		#region Novo
		private void m_btNovo_Click(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			OnCallCadastraEndereco();
			this.refresh();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}
		#endregion
		#region Click
		private void m_lvEnderecos_Click(object sender, System.EventArgs e)
		{
			if (m_bAtivado == false)
			{
				m_bAtivado = true;
				try
				{
					OnCallCarregaDadosEnderecosSelecionado();
					OnCallCarregaDadosEnderecoInterface();
				} 
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
				m_bAtivado = false;
			}
		}
		#endregion
		#region Double Click
		private void m_lvEnderecos_DoubleClick(object sender, System.EventArgs e)
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
		#endregion
	}
}
