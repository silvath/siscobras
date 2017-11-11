using System;
using System.Collections;
using System.Windows.Forms;

namespace mdlNotaFiscal.Frames
{
	/// <summary>
	/// Summary description for frmFNotasFiscais.
	/// </summary>
	internal class frmFNotasFiscais : mdlComponentesGraficos.FormFlutuante
	{
		#region Atributos
		private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
		private string m_strEnderecoExecutavel = "";

		internal bool m_bModificado = false;
		private bool m_bAtivado = true;

		private mdlComponentesGraficos.MessageBalloon m_mgblBalaoToolTip = null;
		protected bool m_bMostrarBaloes = true;

		private System.Windows.Forms.GroupBox m_gbFrame;
		private System.Windows.Forms.GroupBox m_gbFields;
		private System.Windows.Forms.Button m_btTrocarCor;
		private System.Windows.Forms.Button m_btOk;
		private System.Windows.Forms.Button m_btCancelar;
		private mdlComponentesGraficos.ListView m_lvNotasFiscais;
		private System.Windows.Forms.ColumnHeader m_chSecond;
		private mdlComponentesGraficos.Button m_btNova;
		private mdlComponentesGraficos.Button m_btExclui;
		private System.Windows.Forms.Label m_lMoedaNotas;
		private System.Windows.Forms.Label m_lValorNotas;
		private System.Windows.Forms.ToolTip m_ttNotasFiscais;
		private mdlComponentesGraficos.Button m_btEditar;
		private System.Windows.Forms.ColumnHeader m_chFirst;
		private System.Windows.Forms.ColumnHeader m_chThird;
		private System.ComponentModel.IContainer components;
		#endregion

		#region Construtores & Destrutores
		public frmFNotasFiscais(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, string enderecoExecutavel)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_cls_ter_tratadorErro = tratadorErro;
			m_strEnderecoExecutavel = enderecoExecutavel;
		}
		public frmFNotasFiscais(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, string enderecoExecutavel, bool bMostrarBaloes)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_cls_ter_tratadorErro = tratadorErro;
			m_strEnderecoExecutavel = enderecoExecutavel;
			m_bMostrarBaloes = bMostrarBaloes;
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
		public delegate void delCallCarregaDadosInterface(ref mdlComponentesGraficos.ListView lvNotas, ref mdlComponentesGraficos.Button btEditar, ref mdlComponentesGraficos.Button btExclui, ref mdlComponentesGraficos.Button btNovo, ref System.Windows.Forms.Label lMoedaNotas);
		public delegate void delCallCadastraNota(ref mdlComponentesGraficos.ListView lvNotas);
		public delegate void delCallEditaNota(ref mdlComponentesGraficos.ListView lvNotas);
		public delegate void delCallRemoveNota(ref mdlComponentesGraficos.ListView lvNotas);
		public delegate void delCallSalvaDadosBD(bool bModificado);
		#endregion
		#region Events
		public event delCallCarregaDadosInterface eCallCarregaDadosInterface;
		public event delCallCadastraNota eCallCadastraNota;
		public event delCallEditaNota eCallEditaNota;
		public event delCallRemoveNota eCallRemoveNota;
		public event delCallSalvaDadosBD eCallSalvaDadosBD;
		#endregion
		#region Events Methods
		protected virtual void OnCallCarregaDadosInterface()
		{
			if (eCallCarregaDadosInterface != null)
				eCallCarregaDadosInterface(ref m_lvNotasFiscais, ref m_btEditar, ref m_btExclui, ref m_btNova, ref m_lMoedaNotas);
		}
		protected virtual void OnCallCadastraNota()
		{
			if (eCallCadastraNota != null)
				eCallCadastraNota(ref m_lvNotasFiscais);
		}
		protected virtual void OnCallEditaNota()
		{
			if (eCallEditaNota != null)
				eCallEditaNota(ref m_lvNotasFiscais);
		}
		protected virtual void OnCallRemoveNota()
		{
			if (eCallRemoveNota != null)
				eCallRemoveNota(ref m_lvNotasFiscais);
		}
		protected virtual void OnCallSalvaDadosBD()
		{
			if (eCallSalvaDadosBD != null)
				eCallSalvaDadosBD(m_bModificado);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFNotasFiscais));
			this.m_gbFrame = new System.Windows.Forms.GroupBox();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_btTrocarCor = new System.Windows.Forms.Button();
			this.m_gbFields = new System.Windows.Forms.GroupBox();
			this.m_btEditar = new mdlComponentesGraficos.Button();
			this.m_lMoedaNotas = new System.Windows.Forms.Label();
			this.m_lValorNotas = new System.Windows.Forms.Label();
			this.m_btExclui = new mdlComponentesGraficos.Button();
			this.m_btNova = new mdlComponentesGraficos.Button();
			this.m_lvNotasFiscais = new mdlComponentesGraficos.ListView();
			this.m_chFirst = new System.Windows.Forms.ColumnHeader();
			this.m_chSecond = new System.Windows.Forms.ColumnHeader();
			this.m_chThird = new System.Windows.Forms.ColumnHeader();
			this.m_ttNotasFiscais = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbFrame.SuspendLayout();
			this.m_gbFields.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbFrame
			// 
			this.m_gbFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFrame.Controls.Add(this.m_btOk);
			this.m_gbFrame.Controls.Add(this.m_btCancelar);
			this.m_gbFrame.Controls.Add(this.m_btTrocarCor);
			this.m_gbFrame.Controls.Add(this.m_gbFields);
			this.m_gbFrame.Location = new System.Drawing.Point(2, 0);
			this.m_gbFrame.Name = "m_gbFrame";
			this.m_gbFrame.Size = new System.Drawing.Size(398, 261);
			this.m_gbFrame.TabIndex = 0;
			this.m_gbFrame.TabStop = false;
			// 
			// m_btOk
			// 
			this.m_btOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(139, 229);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 27);
			this.m_btOk.TabIndex = 4;
			this.m_ttNotasFiscais.SetToolTip(this.m_btOk, "Confirmar");
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(203, 229);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 27);
			this.m_btCancelar.TabIndex = 5;
			this.m_ttNotasFiscais.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_btTrocarCor
			// 
			this.m_btTrocarCor.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_btTrocarCor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btTrocarCor.Location = new System.Drawing.Point(4, 9);
			this.m_btTrocarCor.Name = "m_btTrocarCor";
			this.m_btTrocarCor.Size = new System.Drawing.Size(4, 4);
			this.m_btTrocarCor.TabIndex = 3;
			this.m_ttNotasFiscais.SetToolTip(this.m_btTrocarCor, "Cor");
			this.m_btTrocarCor.Click += new System.EventHandler(this.m_btTrocarCor_Click);
			// 
			// m_gbFields
			// 
			this.m_gbFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFields.Controls.Add(this.m_btEditar);
			this.m_gbFields.Controls.Add(this.m_lMoedaNotas);
			this.m_gbFields.Controls.Add(this.m_lValorNotas);
			this.m_gbFields.Controls.Add(this.m_btExclui);
			this.m_gbFields.Controls.Add(this.m_btNova);
			this.m_gbFields.Controls.Add(this.m_lvNotasFiscais);
			this.m_gbFields.Font = new System.Drawing.Font("Arial", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbFields.Location = new System.Drawing.Point(8, 7);
			this.m_gbFields.Name = "m_gbFields";
			this.m_gbFields.Size = new System.Drawing.Size(381, 218);
			this.m_gbFields.TabIndex = 0;
			this.m_gbFields.TabStop = false;
			// 
			// m_btEditar
			// 
			this.m_btEditar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.m_btEditar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btEditar.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btEditar.GradiendColorEnd = System.Drawing.Color.Black;
			this.m_btEditar.GradiendColorStart = System.Drawing.Color.White;
			this.m_btEditar.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
			this.m_btEditar.Image = ((System.Drawing.Image)(resources.GetObject("m_btEditar.Image")));
			this.m_btEditar.Location = new System.Drawing.Point(178, 55);
			this.m_btEditar.Name = "m_btEditar";
			this.m_btEditar.Size = new System.Drawing.Size(25, 25);
			this.m_btEditar.TabIndex = 7;
			this.m_ttNotasFiscais.SetToolTip(this.m_btEditar, "Editar");
			this.m_btEditar.Click += new System.EventHandler(this.m_btEditar_Click);
			// 
			// m_lMoedaNotas
			// 
			this.m_lMoedaNotas.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lMoedaNotas.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_lMoedaNotas.Location = new System.Drawing.Point(150, 25);
			this.m_lMoedaNotas.Name = "m_lMoedaNotas";
			this.m_lMoedaNotas.Size = new System.Drawing.Size(178, 16);
			this.m_lMoedaNotas.TabIndex = 6;
			this.m_lMoedaNotas.Text = "MOEDA NOTAS";
			this.m_lMoedaNotas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_lValorNotas
			// 
			this.m_lValorNotas.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lValorNotas.Location = new System.Drawing.Point(8, 25);
			this.m_lValorNotas.Name = "m_lValorNotas";
			this.m_lValorNotas.Size = new System.Drawing.Size(135, 16);
			this.m_lValorNotas.TabIndex = 5;
			this.m_lValorNotas.Text = "Valor Total Notas:";
			this.m_lValorNotas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_btExclui
			// 
			this.m_btExclui.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.m_btExclui.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btExclui.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btExclui.GradiendColorEnd = System.Drawing.Color.Black;
			this.m_btExclui.GradiendColorStart = System.Drawing.Color.White;
			this.m_btExclui.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
			this.m_btExclui.Image = ((System.Drawing.Image)(resources.GetObject("m_btExclui.Image")));
			this.m_btExclui.Location = new System.Drawing.Point(210, 55);
			this.m_btExclui.Name = "m_btExclui";
			this.m_btExclui.Size = new System.Drawing.Size(25, 25);
			this.m_btExclui.TabIndex = 4;
			this.m_ttNotasFiscais.SetToolTip(this.m_btExclui, "Excluir");
			this.m_btExclui.Click += new System.EventHandler(this.m_btExclui_Click);
			// 
			// m_btNova
			// 
			this.m_btNova.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.m_btNova.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btNova.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btNova.GradiendColorEnd = System.Drawing.Color.Black;
			this.m_btNova.GradiendColorStart = System.Drawing.Color.White;
			this.m_btNova.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
			this.m_btNova.Image = ((System.Drawing.Image)(resources.GetObject("m_btNova.Image")));
			this.m_btNova.Location = new System.Drawing.Point(146, 55);
			this.m_btNova.Name = "m_btNova";
			this.m_btNova.Size = new System.Drawing.Size(25, 25);
			this.m_btNova.TabIndex = 1;
			this.m_ttNotasFiscais.SetToolTip(this.m_btNova, "Nova");
			this.m_btNova.Click += new System.EventHandler(this.m_btNova_Click);
			// 
			// m_lvNotasFiscais
			// 
			this.m_lvNotasFiscais.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.m_lvNotasFiscais.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lvNotasFiscais.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							   this.m_chFirst,
																							   this.m_chSecond,
																							   this.m_chThird});
			this.m_lvNotasFiscais.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lvNotasFiscais.FullRowSelect = true;
			this.m_lvNotasFiscais.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.m_lvNotasFiscais.HideSelection = false;
			this.m_lvNotasFiscais.Location = new System.Drawing.Point(8, 87);
			this.m_lvNotasFiscais.Name = "m_lvNotasFiscais";
			this.m_lvNotasFiscais.Size = new System.Drawing.Size(365, 123);
			this.m_lvNotasFiscais.TabIndex = 3;
			this.m_ttNotasFiscais.SetToolTip(this.m_lvNotasFiscais, "Duplo clique para editar uma nota");
			this.m_lvNotasFiscais.View = System.Windows.Forms.View.Details;
			this.m_lvNotasFiscais.DoubleClick += new System.EventHandler(this.m_lvNotasFiscais_DoubleClick);
			// 
			// m_chFirst
			// 
			this.m_chFirst.Text = "Número";
			this.m_chFirst.Width = 114;
			// 
			// m_chSecond
			// 
			this.m_chSecond.Text = "Emissão";
			this.m_chSecond.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.m_chSecond.Width = 107;
			// 
			// m_chThird
			// 
			this.m_chThird.Text = "Valor";
			this.m_chThird.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.m_chThird.Width = 135;
			// 
			// m_ttNotasFiscais
			// 
			this.m_ttNotasFiscais.AutomaticDelay = 100;
			this.m_ttNotasFiscais.AutoPopDelay = 5000;
			this.m_ttNotasFiscais.InitialDelay = 100;
			this.m_ttNotasFiscais.ReshowDelay = 20;
			// 
			// frmFNotasFiscais
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(402, 263);
			this.Controls.Add(this.m_gbFrame);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFNotasFiscais";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Nota Fiscal";
			this.Load += new System.EventHandler(this.frmFNotasFiscais_Load);
			this.m_gbFrame.ResumeLayout(false);
			this.m_gbFields.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Procedimentos Para Troca de Cor
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
						if ((this.Controls[cont].Controls[cont2].GetType().ToString() != "mdlComponentesGraficos.TextBox") && (this.Controls[cont].Controls[cont2].GetType().ToString() != "mdlComponentes.compTextNumber"))
						{
							this.Controls[cont].Controls[cont2].BackColor = this.BackColor;
						}
						for (int cont3 = 0; cont3 < this.Controls[cont].Controls[cont2].Controls.Count; cont3++)
						{
							if ((this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"System.Windows.Forms.TextBox") &&
								(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.TextBox") &&
								(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.ListView"))
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

		#region Métodos Show Balão
		public void fechaBalao()
		{
			try
			{
				if (m_mgblBalaoToolTip != null)
					m_mgblBalaoToolTip.Close();
			}
			catch
			{
			}
		}
		public void mostraBalao(string strMensagem, System.Windows.Forms.Control ctrlBalao)
		{
			try
			{
				if (m_mgblBalaoToolTip != null)
					m_mgblBalaoToolTip.Close();
				if (m_bMostrarBaloes)
				{
					m_mgblBalaoToolTip = new mdlComponentesGraficos.MessageBalloon();
					m_mgblBalaoToolTip.Caption = mdlConstantes.clsConstantes.BALLONTIP_DEFAULT_CAPTION;
					m_mgblBalaoToolTip.Content = strMensagem;
					m_mgblBalaoToolTip.Icon = System.Drawing.SystemIcons.Information;
					m_mgblBalaoToolTip.CloseOnMouseClick = true;
					m_mgblBalaoToolTip.CloseOnDeactivate = false;
					m_mgblBalaoToolTip.CloseOnKeyPress = false;
					m_mgblBalaoToolTip.ShowBalloon((System.Windows.Forms.Control)ctrlBalao);
				}
			}
			catch (Exception err)
			{
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion

		#region Eventos
		#region Load
		private void frmFNotasFiscais_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.mostraCor();
				OnCallCarregaDadosInterface();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Exclui
		private void m_btExclui_Click(object sender, System.EventArgs e)
		{
			try
			{
				OnCallRemoveNota();
				OnCallCarregaDadosInterface();
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
		#region Ok
		private void m_btOk_Click(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			m_bModificado = true;
			OnCallSalvaDadosBD();
			this.Close();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}
		#endregion
		#region Cor
		private void m_btTrocarCor_Click(object sender, System.EventArgs e)
		{
			this.trocaCor();
		}
		#endregion
		#region Editar
		private void m_lvNotasFiscais_DoubleClick(object sender, System.EventArgs e)
		{
			OnCallEditaNota();
			OnCallCarregaDadosInterface();
		}
		private void m_btEditar_Click(object sender, System.EventArgs e)
		{
			if (m_lvNotasFiscais.SelectedItems.Count > 0)
			{
				OnCallEditaNota();
				OnCallCarregaDadosInterface();
			}
		}
		#endregion
		#region Nova
		private void m_btNova_Click(object sender, System.EventArgs e)
		{
			OnCallCadastraNota();
			OnCallCarregaDadosInterface();
		}
		#endregion
		#endregion
	}
}
