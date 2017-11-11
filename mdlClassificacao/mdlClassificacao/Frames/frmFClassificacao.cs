using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlClassificacao.Frames
{
	/// <summary>
	/// Summary description for frmFClassificacao.
	/// </summary>
	internal class frmFClassificacao : mdlComponentesGraficos.FormFlutuante
	{
		#region Atributos
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
		protected string m_strEnderecoExecutavel;

		public bool m_bModificado = false;
		protected bool m_bAtiva = true;
		private int m_nIndiceAnterior = -1;

		private System.Windows.Forms.GroupBox m_gbFrame;
		private System.Windows.Forms.GroupBox m_gbInformacoes;
		internal System.Windows.Forms.Button m_btOk;
		internal System.Windows.Forms.Button m_btCancelar;
		public System.Windows.Forms.Button m_btExcluir;
		public System.Windows.Forms.Button m_btEditar;
		public System.Windows.Forms.Button m_btNovo;
		private System.Windows.Forms.Label m_lDadosImportador;
		private System.Windows.Forms.ToolTip m_ttImportadores;
		private System.Windows.Forms.ColumnHeader m_chImportador;
		internal System.Windows.Forms.Button m_btTrocarCor;
		private mdlComponentesGraficos.ListView m_lvClassificacao;
		private System.Windows.Forms.RichTextBox m_rtbDadosClassificacao;

		private System.ComponentModel.IContainer components;
		#endregion

		#region Construtores & Destrutores
		public frmFClassificacao(ref mdlTratamentoErro.clsTratamentoErro clstratadorErro, string strEnderecoExecutavel)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_cls_ter_tratadorErro = clstratadorErro;
			m_strEnderecoExecutavel = strEnderecoExecutavel;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFClassificacao));
			this.m_gbFrame = new System.Windows.Forms.GroupBox();
			this.m_btTrocarCor = new System.Windows.Forms.Button();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbInformacoes = new System.Windows.Forms.GroupBox();
			this.m_rtbDadosClassificacao = new System.Windows.Forms.RichTextBox();
			this.m_btExcluir = new System.Windows.Forms.Button();
			this.m_btEditar = new System.Windows.Forms.Button();
			this.m_btNovo = new System.Windows.Forms.Button();
			this.m_lDadosImportador = new System.Windows.Forms.Label();
			this.m_lvClassificacao = new mdlComponentesGraficos.ListView();
			this.m_chImportador = new System.Windows.Forms.ColumnHeader();
			this.m_ttImportadores = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbFrame.SuspendLayout();
			this.m_gbInformacoes.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbFrame
			// 
			this.m_gbFrame.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_gbFrame.Controls.Add(this.m_btTrocarCor);
			this.m_gbFrame.Controls.Add(this.m_btOk);
			this.m_gbFrame.Controls.Add(this.m_btCancelar);
			this.m_gbFrame.Controls.Add(this.m_gbInformacoes);
			this.m_gbFrame.Location = new System.Drawing.Point(4, 0);
			this.m_gbFrame.Name = "m_gbFrame";
			this.m_gbFrame.Size = new System.Drawing.Size(358, 355);
			this.m_gbFrame.TabIndex = 0;
			this.m_gbFrame.TabStop = false;
			// 
			// m_btTrocarCor
			// 
			this.m_btTrocarCor.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_btTrocarCor.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_btTrocarCor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btTrocarCor.Location = new System.Drawing.Point(4, 9);
			this.m_btTrocarCor.Name = "m_btTrocarCor";
			this.m_btTrocarCor.Size = new System.Drawing.Size(4, 4);
			this.m_btTrocarCor.TabIndex = 11;
			this.m_ttImportadores.SetToolTip(this.m_btTrocarCor, "Cor");
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
			this.m_btOk.Location = new System.Drawing.Point(119, 325);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 8;
			this.m_ttImportadores.SetToolTip(this.m_btOk, "Confirmar");
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
			this.m_btCancelar.Location = new System.Drawing.Point(183, 325);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 9;
			this.m_ttImportadores.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbInformacoes
			// 
			this.m_gbInformacoes.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_gbInformacoes.Controls.Add(this.m_rtbDadosClassificacao);
			this.m_gbInformacoes.Controls.Add(this.m_btExcluir);
			this.m_gbInformacoes.Controls.Add(this.m_btEditar);
			this.m_gbInformacoes.Controls.Add(this.m_btNovo);
			this.m_gbInformacoes.Controls.Add(this.m_lDadosImportador);
			this.m_gbInformacoes.Controls.Add(this.m_lvClassificacao);
			this.m_gbInformacoes.Font = new System.Drawing.Font("Arial", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbInformacoes.Location = new System.Drawing.Point(8, 8);
			this.m_gbInformacoes.Name = "m_gbInformacoes";
			this.m_gbInformacoes.Size = new System.Drawing.Size(342, 311);
			this.m_gbInformacoes.TabIndex = 0;
			this.m_gbInformacoes.TabStop = false;
			// 
			// m_rtbDadosClassificacao
			// 
			this.m_rtbDadosClassificacao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_rtbDadosClassificacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_rtbDadosClassificacao.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_rtbDadosClassificacao.Location = new System.Drawing.Point(8, 227);
			this.m_rtbDadosClassificacao.Name = "m_rtbDadosClassificacao";
			this.m_rtbDadosClassificacao.ReadOnly = true;
			this.m_rtbDadosClassificacao.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.m_rtbDadosClassificacao.Size = new System.Drawing.Size(326, 77);
			this.m_rtbDadosClassificacao.TabIndex = 7;
			this.m_rtbDadosClassificacao.Text = "";
			// 
			// m_btExcluir
			// 
			this.m_btExcluir.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_btExcluir.BackColor = System.Drawing.SystemColors.Control;
			this.m_btExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btExcluir.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btExcluir.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btExcluir.Image = ((System.Drawing.Image)(resources.GetObject("m_btExcluir.Image")));
			this.m_btExcluir.Location = new System.Drawing.Point(191, 22);
			this.m_btExcluir.Name = "m_btExcluir";
			this.m_btExcluir.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btExcluir.Size = new System.Drawing.Size(25, 25);
			this.m_btExcluir.TabIndex = 3;
			this.m_btExcluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttImportadores.SetToolTip(this.m_btExcluir, "Excluir");
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
			this.m_btEditar.Location = new System.Drawing.Point(159, 22);
			this.m_btEditar.Name = "m_btEditar";
			this.m_btEditar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btEditar.Size = new System.Drawing.Size(25, 25);
			this.m_btEditar.TabIndex = 2;
			this.m_btEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttImportadores.SetToolTip(this.m_btEditar, "Editar");
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
			this.m_btNovo.Location = new System.Drawing.Point(127, 22);
			this.m_btNovo.Name = "m_btNovo";
			this.m_btNovo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btNovo.Size = new System.Drawing.Size(25, 25);
			this.m_btNovo.TabIndex = 1;
			this.m_btNovo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttImportadores.SetToolTip(this.m_btNovo, "Nova");
			this.m_btNovo.Click += new System.EventHandler(this.m_btNovo_Click);
			// 
			// m_lDadosImportador
			// 
			this.m_lDadosImportador.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_lDadosImportador.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lDadosImportador.Location = new System.Drawing.Point(6, 205);
			this.m_lDadosImportador.Name = "m_lDadosImportador";
			this.m_lDadosImportador.Size = new System.Drawing.Size(112, 18);
			this.m_lDadosImportador.TabIndex = 2;
			this.m_lDadosImportador.Text = "Denominação:";
			this.m_lDadosImportador.Visible = false;
			// 
			// m_lvClassificacao
			// 
			this.m_lvClassificacao.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.m_lvClassificacao.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_lvClassificacao.CausesValidation = false;
			this.m_lvClassificacao.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																								this.m_chImportador});
			this.m_lvClassificacao.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lvClassificacao.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lvClassificacao.HideSelection = false;
			this.m_lvClassificacao.Location = new System.Drawing.Point(8, 53);
			this.m_lvClassificacao.Name = "m_lvClassificacao";
			this.m_lvClassificacao.Size = new System.Drawing.Size(326, 147);
			this.m_lvClassificacao.TabIndex = 6;
			this.m_ttImportadores.SetToolTip(this.m_lvClassificacao, "Selecionar Classificação");
			this.m_lvClassificacao.View = System.Windows.Forms.View.Details;
			this.m_lvClassificacao.DoubleClick += new System.EventHandler(this.m_lvClassificacao_DoubleClick);
			this.m_lvClassificacao.Click += new System.EventHandler(this.m_lvClassificacao_Click);
			this.m_lvClassificacao.SelectedIndexChanged += new System.EventHandler(this.m_lvClassificacao_SelectedIndexChanged);
			// 
			// m_chImportador
			// 
			this.m_chImportador.Width = 300;
			// 
			// m_ttImportadores
			// 
			this.m_ttImportadores.AutomaticDelay = 100;
			this.m_ttImportadores.AutoPopDelay = 5000;
			this.m_ttImportadores.InitialDelay = 100;
			this.m_ttImportadores.ReshowDelay = 20;
			// 
			// frmFClassificacao
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(366, 358);
			this.Controls.Add(this.m_gbFrame);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFClassificacao";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Classificação";
			this.Load += new System.EventHandler(this.frmFClassificacao_Load);
			this.m_gbFrame.ResumeLayout(false);
			this.m_gbInformacoes.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Delegate
		// Delegate para BD
		public delegate void delCallCarregaDadosBD();
		public delegate void delCallCarregaDadosBDClassificacao(ref mdlComponentesGraficos.ListView lvClassificacao);
		public delegate void delCallCarregaDadosInterface(ref mdlComponentesGraficos.ListView lvClassificacao, ref System.Windows.Forms.Button btEditar, ref System.Windows.Forms.Button btExcluir, ref System.Windows.Forms.Form frmClassificacao);
		public delegate void delCallCarregaDadosClassificacaoInterface(ref System.Windows.Forms.RichTextBox rtbDadosClassificacao);
		public delegate void delCallChecaIntegridadeDados();
		public delegate void delCallSalvaDadosInterface();
		public delegate void delCallSalvaDadosBD(bool bModificado);
		// Delegate para Editar Classificacao
		public delegate void delCallEditaClassificacao();
		public delegate void delCallCadastraClassificacao();
		public delegate void delCallRemoveClassificacao(ref mdlComponentesGraficos.ListView lvClassificacao);
		#endregion
		#region Events
		// Eventos BD
		public event delCallCarregaDadosBD eCallCarregaDadosBD;
		public event delCallCarregaDadosBDClassificacao eCallCarregaDadosBDClassificacao;
		public event delCallCarregaDadosInterface eCallCarregaDadosInterface;
		public event delCallCarregaDadosClassificacaoInterface eCallCarregaDadosClassificacaoInterface;
		public event delCallChecaIntegridadeDados eCallChecaIntegridadeDados;
		public event delCallSalvaDadosInterface eCallSalvaDadosInterface;
		public event delCallSalvaDadosBD eCallSalvaDadosBD;
		// Eventos Editar / Cadastrar Importadores
		public event delCallEditaClassificacao eCallEditaClassificacao;
		public event delCallCadastraClassificacao eCallCadastraClassificacao;
		public event delCallRemoveClassificacao eCallRemoveClassificacao;
		#endregion
		#region Events Methods
		protected virtual void OnCallCarregaDadosBD()
		{
			if (eCallCarregaDadosBD != null)
				eCallCarregaDadosBD();
		}
		protected virtual void OnCallCarregaDadosBDClassificacao()
		{
			if (eCallCarregaDadosBDClassificacao != null)
				eCallCarregaDadosBDClassificacao(ref this.m_lvClassificacao);
		} 
		protected virtual void OnCallCarregaDadosClassificacaoInterface()
		{
			if (eCallCarregaDadosClassificacaoInterface != null)
				eCallCarregaDadosClassificacaoInterface(ref this.m_rtbDadosClassificacao);
		}
		protected virtual void OnCallCarregaDadosInterface()
		{
			System.Windows.Forms.Form formClassificacao = (System.Windows.Forms.Form)this;
			if (eCallCarregaDadosInterface != null)
				eCallCarregaDadosInterface(ref this.m_lvClassificacao, ref this.m_btEditar, ref this.m_btExcluir, ref formClassificacao);
		}
		protected virtual void OnCallChecaIntegridadeDados()
		{
			if (eCallChecaIntegridadeDados != null)
				eCallChecaIntegridadeDados();
		}
		protected virtual void OnCallSalvaDadosInterface()
		{
			if (eCallSalvaDadosInterface != null)
				eCallSalvaDadosInterface();
		} 

		protected virtual void OnCallSalvaDadosBD()
		{
			if (eCallSalvaDadosBD != null)
				eCallSalvaDadosBD(this.m_bModificado);
		}
		protected virtual void OnCallCadastraClassificacao()
		{
			if (eCallCadastraClassificacao != null)
				eCallCadastraClassificacao();
		}
		protected virtual void OnCallEditaClassificacao()
		{
			if (eCallEditaClassificacao != null)
				eCallEditaClassificacao();
		}
		protected virtual void OnCallRemoveClassificacao()
		{
			if (eCallRemoveClassificacao != null)
				eCallRemoveClassificacao(ref this.m_lvClassificacao);
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
						if ((this.Controls[cont].Controls[cont2].GetType().ToString() != "System.Windows.Forms.ListView") && (this.Controls[cont].Controls[cont2].GetType().ToString() != "mdlComponentes.compTextNumber"))
						{
							this.Controls[cont].Controls[cont2].BackColor = this.BackColor;
						}
						for (int cont3 = 0; cont3 < this.Controls[cont].Controls[cont2].Controls.Count; cont3++)
						{
							if ((this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.ListView")/* && (this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"System.Windows.Forms.RichTextBox")*/)
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
		
		#region Refresh Lista e Dados dos Importadores
		public void refreshAll()
		{
			try 
			{
				this.mostraCor();
				OnCallCarregaDadosInterface();
				OnCallCarregaDadosClassificacaoInterface();
				this.m_lvClassificacao.Focus();
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		public void refresh()
		{
			try
			{
				this.mostraCor();
				OnCallCarregaDadosInterface();
				this.m_lvClassificacao.Focus();
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Eventos
		#region Cor
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
		#endregion
		#region Load
		private void frmFClassificacao_Load(object sender, System.EventArgs e)
		{
			try 
			{
				this.mostraCor();
				OnCallCarregaDadosBD();
				OnCallCarregaDadosBDClassificacao();
				OnCallCarregaDadosInterface();
				OnCallCarregaDadosClassificacaoInterface();
				this.m_lvClassificacao.Focus();
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
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
				OnCallSalvaDadosInterface();
				OnCallSalvaDadosBD();
				this.Cursor = System.Windows.Forms.Cursors.Default;
				this.Close();
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
		#region Editar
		private void m_btEditar_Click(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			if (m_lvClassificacao.SelectedItems.Count > 0)
			{
				OnCallEditaClassificacao();
				this.refreshAll();
			}
			else
			{
				mdlMensagens.clsMensagens.ShowInformation(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlClassificacao_frmFClassificacao_ClassificacaoNaoSelecionadaParaEdicao));
				//System.Windows.Forms.MessageBox.Show("Você precisa selecionar a classificação que deseja editar.",this.Text);
			}
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}
		#endregion
		#region Novo
		private void m_btNovo_Click(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			OnCallCadastraClassificacao();
			this.refreshAll();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}
		#endregion
		#region Excluir
		private void m_btExcluir_Click(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			if (m_lvClassificacao.SelectedItems.Count > 0)
			{
				OnCallRemoveClassificacao();
				this.refreshAll();
			}
			else
			{
				mdlMensagens.clsMensagens.ShowInformation(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlClassificacao_frmFClassificacao_ClassificacaoNaoSelecionadaParaExclusao));
				//System.Windows.Forms.MessageBox.Show("Você precisa selecionar o importador que deseja excluir!",this.Text);
			}
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}
		#endregion
		#region List View Clique
		private void m_lvClassificacao_Click(object sender, System.EventArgs e)
		{
			if (m_bAtiva == true)
			{
				m_bAtiva = false;
				OnCallCarregaDadosBDClassificacao();
				OnCallCarregaDadosClassificacaoInterface();
				m_bAtiva = true;
			}
		}
		#endregion
		#region SelectedIndexChanged
		private void m_lvClassificacao_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (m_lvClassificacao.SelectedItems.Count > 0)
				{
					if (m_lvClassificacao.SelectedItems[0].Index != m_nIndiceAnterior)
					{
						m_nIndiceAnterior = m_lvClassificacao.SelectedItems[0].Index;
						m_lvClassificacao_Click(sender, e);
					}
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Double Click
		private void m_lvClassificacao_DoubleClick(object sender, System.EventArgs e)
		{
			try
			{
				m_lvClassificacao_Click(sender,e);
				m_btOk_Click(sender,e);
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
