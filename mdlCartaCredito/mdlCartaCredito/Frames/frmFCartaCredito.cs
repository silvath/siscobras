using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlCartaCredito.Frames
{
	/// <summary>
	/// Summary description for frmFCartaCredito.
	/// </summary>
	internal class frmFCartaCredito : mdlComponentesGraficos.FormFlutuante
	{
		#region Atributos
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
		protected string m_strEnderecoExecutavel;

		private bool m_bModificado = false;

		private System.Windows.Forms.GroupBox m_gbFrame;
		private System.Windows.Forms.Button m_btTrocarCor;
		private System.Windows.Forms.Button m_btOk;
		private System.Windows.Forms.Button m_btCancelar;
		private System.Windows.Forms.GroupBox m_gbFields;
		private System.Windows.Forms.Label m_lNomeImportador;
		private System.Windows.Forms.Label m_lImportador;
		private mdlComponentesGraficos.ListView m_lvCartasCredito;
		private System.Windows.Forms.Button m_btExcluir;
		private System.Windows.Forms.Button m_btEditar;
		private System.Windows.Forms.Button m_btNovo;
		private System.Windows.Forms.ColumnHeader m_chBancoImportador;
		private System.Windows.Forms.ToolTip m_ttCartaCredito;
		private System.Windows.Forms.Label m_lDetalhes;
		private mdlComponentesGraficos.ListView m_lvDetalhes;
		private System.Windows.Forms.ColumnHeader m_chFirst;
		private System.Windows.Forms.ColumnHeader m_chSecond;
		private System.ComponentModel.IContainer components;
		#endregion

		#region Construtores & Destrutores
		public frmFCartaCredito(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, string EnderecoExecutavel)
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
		public delegate void delCallCarregaDadosInterface(ref mdlComponentesGraficos.ListView lvCartas, ref System.Windows.Forms.Label lImportador, ref System.Windows.Forms.Button btEditar, ref System.Windows.Forms.Button btExcluir, ref System.Windows.Forms.GroupBox gbFields);
		public delegate void delCallCarregaDadosInterfaceDetalhe(ref mdlComponentesGraficos.ListView lvCartas, ref mdlComponentesGraficos.ListView lvDetalhes);
		public delegate void delCallSalvaDadosInterface(ref mdlComponentesGraficos.ListView lvCartas);
		public delegate void delCallSalvaDadosBD(bool bModificado);
		// Botões
		public delegate void delCallNovaCarta();
		public delegate void delCallEditarCarta(ref mdlComponentesGraficos.ListView lvCartas);
		public delegate void delCallExcluirCartas(ref mdlComponentesGraficos.ListView lvCartas);
		#endregion
		#region Events
		public event delCallCarregaDadosInterface eCallCarregaDadosInterface;
		public event delCallCarregaDadosInterfaceDetalhe eCallCarregaDadosInterfaceDetalhe;
		public event delCallSalvaDadosInterface eCallSalvaDadosInterface;
		public event delCallSalvaDadosBD eCallSalvaDadosBD;
		// Botões
		public event delCallNovaCarta eCallNovaCarta;
		public event delCallEditarCarta eCallEditarCarta;
		public event delCallExcluirCartas eCallExcluirCartas;
		#endregion
		#region Events Methods
		protected virtual void OnCallCarregaDadosInterface()
		{
			if (eCallCarregaDadosInterface != null)
				eCallCarregaDadosInterface(ref m_lvCartasCredito, ref m_lNomeImportador, ref m_btEditar, ref m_btExcluir, ref m_gbFields);
		}
		protected virtual void OnCallCarregaDadosInterfaceDetalhe()
		{
			if (eCallCarregaDadosInterfaceDetalhe != null)
				eCallCarregaDadosInterfaceDetalhe(ref m_lvCartasCredito, ref m_lvDetalhes);
		}
		protected virtual void OnCallSalvaDadosInterface()
		{
			if (eCallSalvaDadosInterface != null)
				eCallSalvaDadosInterface(ref m_lvCartasCredito);
		}
		protected virtual void OnCallSalvaDadosBD()
		{
			if (eCallSalvaDadosBD != null)
				eCallSalvaDadosBD(m_bModificado);
		}
		// Botões
		protected virtual void OnCallNovaCarta()
		{
			if (eCallNovaCarta != null)
				eCallNovaCarta();
		}
		protected virtual void OnCallEditarCarta()
		{
			if (eCallEditarCarta != null)
				eCallEditarCarta(ref m_lvCartasCredito);
		}
		protected virtual void OnCallExcluirCartas()
		{
			if (eCallExcluirCartas != null)
				eCallExcluirCartas(ref m_lvCartasCredito);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFCartaCredito));
			this.m_gbFrame = new System.Windows.Forms.GroupBox();
			this.m_btTrocarCor = new System.Windows.Forms.Button();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbFields = new System.Windows.Forms.GroupBox();
			this.m_lvDetalhes = new mdlComponentesGraficos.ListView();
			this.m_chFirst = new System.Windows.Forms.ColumnHeader();
			this.m_chSecond = new System.Windows.Forms.ColumnHeader();
			this.m_lDetalhes = new System.Windows.Forms.Label();
			this.m_lNomeImportador = new System.Windows.Forms.Label();
			this.m_lImportador = new System.Windows.Forms.Label();
			this.m_lvCartasCredito = new mdlComponentesGraficos.ListView();
			this.m_chBancoImportador = new System.Windows.Forms.ColumnHeader();
			this.m_btExcluir = new System.Windows.Forms.Button();
			this.m_btEditar = new System.Windows.Forms.Button();
			this.m_btNovo = new System.Windows.Forms.Button();
			this.m_ttCartaCredito = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbFrame.SuspendLayout();
			this.m_gbFields.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbFrame
			// 
			this.m_gbFrame.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFrame.Controls.Add(this.m_btTrocarCor);
			this.m_gbFrame.Controls.Add(this.m_btOk);
			this.m_gbFrame.Controls.Add(this.m_btCancelar);
			this.m_gbFrame.Controls.Add(this.m_gbFields);
			this.m_gbFrame.Location = new System.Drawing.Point(2, 0);
			this.m_gbFrame.Name = "m_gbFrame";
			this.m_gbFrame.Size = new System.Drawing.Size(360, 355);
			this.m_gbFrame.TabIndex = 2;
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
			this.m_ttCartaCredito.SetToolTip(this.m_btTrocarCor, "Cor");
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
			this.m_btOk.Location = new System.Drawing.Point(121, 324);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 2;
			this.m_ttCartaCredito.SetToolTip(this.m_btOk, "Confirmar");
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
			this.m_btCancelar.Location = new System.Drawing.Point(185, 324);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 3;
			this.m_ttCartaCredito.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbFields
			// 
			this.m_gbFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFields.Controls.Add(this.m_lvDetalhes);
			this.m_gbFields.Controls.Add(this.m_lDetalhes);
			this.m_gbFields.Controls.Add(this.m_lNomeImportador);
			this.m_gbFields.Controls.Add(this.m_lImportador);
			this.m_gbFields.Controls.Add(this.m_lvCartasCredito);
			this.m_gbFields.Controls.Add(this.m_btExcluir);
			this.m_gbFields.Controls.Add(this.m_btEditar);
			this.m_gbFields.Controls.Add(this.m_btNovo);
			this.m_gbFields.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbFields.Location = new System.Drawing.Point(8, 8);
			this.m_gbFields.Name = "m_gbFields";
			this.m_gbFields.Size = new System.Drawing.Size(344, 311);
			this.m_gbFields.TabIndex = 0;
			this.m_gbFields.TabStop = false;
			// 
			// m_lvDetalhes
			// 
			this.m_lvDetalhes.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.m_lvDetalhes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_lvDetalhes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						   this.m_chFirst,
																						   this.m_chSecond});
			this.m_lvDetalhes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lvDetalhes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lvDetalhes.HideSelection = false;
			this.m_lvDetalhes.Location = new System.Drawing.Point(8, 211);
			this.m_lvDetalhes.Name = "m_lvDetalhes";
			this.m_lvDetalhes.Size = new System.Drawing.Size(327, 94);
			this.m_lvDetalhes.TabIndex = 8;
			this.m_lvDetalhes.View = System.Windows.Forms.View.Details;
			// 
			// m_chFirst
			// 
			this.m_chFirst.Width = 100;
			// 
			// m_chSecond
			// 
			this.m_chSecond.Width = 203;
			// 
			// m_lDetalhes
			// 
			this.m_lDetalhes.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lDetalhes.Location = new System.Drawing.Point(8, 191);
			this.m_lDetalhes.Name = "m_lDetalhes";
			this.m_lDetalhes.Size = new System.Drawing.Size(99, 14);
			this.m_lDetalhes.TabIndex = 7;
			this.m_lDetalhes.Text = "Dados da carta:";
			this.m_lDetalhes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
			// m_lvCartasCredito
			// 
			this.m_lvCartasCredito.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.m_lvCartasCredito.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																								this.m_chBancoImportador});
			this.m_lvCartasCredito.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lvCartasCredito.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lvCartasCredito.HideSelection = false;
			this.m_lvCartasCredito.Location = new System.Drawing.Point(8, 96);
			this.m_lvCartasCredito.Name = "m_lvCartasCredito";
			this.m_lvCartasCredito.Size = new System.Drawing.Size(327, 93);
			this.m_lvCartasCredito.TabIndex = 1;
			this.m_lvCartasCredito.View = System.Windows.Forms.View.Details;
			this.m_lvCartasCredito.DoubleClick += new System.EventHandler(this.m_lvCartasCredito_DoubleClick);
			this.m_lvCartasCredito.SelectedIndexChanged += new System.EventHandler(this.m_lvCartasCredito_SelectedIndexChanged);
			// 
			// m_chBancoImportador
			// 
			this.m_chBancoImportador.Width = 290;
			// 
			// m_btExcluir
			// 
			this.m_btExcluir.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.m_btExcluir.BackColor = System.Drawing.SystemColors.Control;
			this.m_btExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btExcluir.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btExcluir.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btExcluir.Image = ((System.Drawing.Image)(resources.GetObject("m_btExcluir.Image")));
			this.m_btExcluir.Location = new System.Drawing.Point(192, 63);
			this.m_btExcluir.Name = "m_btExcluir";
			this.m_btExcluir.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btExcluir.Size = new System.Drawing.Size(25, 25);
			this.m_btExcluir.TabIndex = 6;
			this.m_btExcluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttCartaCredito.SetToolTip(this.m_btExcluir, "Excluir");
			this.m_btExcluir.Click += new System.EventHandler(this.m_btExcluir_Click);
			// 
			// m_btEditar
			// 
			this.m_btEditar.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.m_btEditar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btEditar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btEditar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btEditar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btEditar.Image = ((System.Drawing.Image)(resources.GetObject("m_btEditar.Image")));
			this.m_btEditar.Location = new System.Drawing.Point(160, 63);
			this.m_btEditar.Name = "m_btEditar";
			this.m_btEditar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btEditar.Size = new System.Drawing.Size(25, 25);
			this.m_btEditar.TabIndex = 5;
			this.m_btEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttCartaCredito.SetToolTip(this.m_btEditar, "Editar");
			this.m_btEditar.Click += new System.EventHandler(this.m_btEditar_Click);
			// 
			// m_btNovo
			// 
			this.m_btNovo.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.m_btNovo.BackColor = System.Drawing.SystemColors.Control;
			this.m_btNovo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btNovo.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btNovo.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btNovo.Image = ((System.Drawing.Image)(resources.GetObject("m_btNovo.Image")));
			this.m_btNovo.Location = new System.Drawing.Point(128, 63);
			this.m_btNovo.Name = "m_btNovo";
			this.m_btNovo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btNovo.Size = new System.Drawing.Size(25, 25);
			this.m_btNovo.TabIndex = 4;
			this.m_btNovo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttCartaCredito.SetToolTip(this.m_btNovo, "Nova");
			this.m_btNovo.Click += new System.EventHandler(this.m_btNovo_Click);
			// 
			// m_ttCartaCredito
			// 
			this.m_ttCartaCredito.AutomaticDelay = 100;
			this.m_ttCartaCredito.AutoPopDelay = 5000;
			this.m_ttCartaCredito.InitialDelay = 100;
			this.m_ttCartaCredito.ReshowDelay = 20;
			// 
			// frmFCartaCredito
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(364, 357);
			this.Controls.Add(this.m_gbFrame);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFCartaCredito";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Cartas de Crédito";
			this.Load += new System.EventHandler(this.frmFCartaCredito_Load);
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
								((this.Controls[cont].Controls[cont2].Controls[cont3].Name == "m_lvDetalhes") &&
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

		#region Eventos
		#region Load
		private void frmFCartaCredito_Load(object sender, System.EventArgs e)
		{
			OnCallCarregaDadosInterface();
			OnCallCarregaDadosInterfaceDetalhe();
			this.mostraCor();
		}
		#endregion
		#region Ok
		private void m_btOk_Click(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			this.m_bModificado = true;
			OnCallSalvaDadosInterface();
			OnCallSalvaDadosBD();
			this.Close();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}
		#endregion
		#region Cancelar
		private void m_btCancelar_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		#endregion
		#region Excluir
		private void m_btExcluir_Click(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			OnCallExcluirCartas();
			OnCallCarregaDadosInterface();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}
		#endregion
		#region Editar
		private void m_btEditar_Click(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			OnCallEditarCarta();
			OnCallCarregaDadosInterface();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}
		#endregion
		#region Novo
		private void m_btNovo_Click(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			OnCallNovaCarta();
			OnCallCarregaDadosInterface();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}
		#endregion
		#region Cor
		private void m_btTrocarCor_Click(object sender, System.EventArgs e)
		{
			this.trocaCor();
		}
		#endregion
		#region Selected Index Changed
		private void m_lvCartasCredito_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			OnCallCarregaDadosInterfaceDetalhe();
		}
		#endregion
		#region Double Click
		private void m_lvCartasCredito_DoubleClick(object sender, System.EventArgs e)
		{
			m_btEditar_Click(sender, e);
		}
		#endregion
		#endregion
	}
}
