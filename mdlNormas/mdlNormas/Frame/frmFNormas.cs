using System;
using System.Collections;
using System.Windows.Forms;

namespace mdlNormas.Frames
{
	/// <summary>
	/// Summary description for frmFNormas.
	/// </summary>
	internal class frmFNormas : mdlComponentesGraficos.FormFlutuante
	{
		#region Atributos
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
		protected string m_strEnderecoExecutavel;

		public bool m_bModificado = false;
		protected bool m_bAtiva = true;
		private int m_nIndiceAnterior = -1;

		private System.Windows.Forms.GroupBox m_gbFrame;
		private System.Windows.Forms.GroupBox m_gbInformacoes;
		private System.Windows.Forms.Button m_btOk;
		private System.Windows.Forms.Button m_btCancelar;
		private System.Windows.Forms.Label m_lDadosNormas;
		private System.Windows.Forms.ColumnHeader m_chImportador;
		private System.Windows.Forms.Button m_btTrocarCor;
		private System.Windows.Forms.RichTextBox m_rtbDadosNormas;
		private mdlComponentesGraficos.ListView m_lvNormas;
		private System.Windows.Forms.ToolTip m_ttNormas;

		private System.ComponentModel.IContainer components;
		#endregion

		#region Construtores & Destrutores
		public frmFNormas(ref mdlTratamentoErro.clsTratamentoErro clstratadorErro, string strEnderecoExecutavel)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFNormas));
			this.m_gbFrame = new System.Windows.Forms.GroupBox();
			this.m_btTrocarCor = new System.Windows.Forms.Button();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbInformacoes = new System.Windows.Forms.GroupBox();
			this.m_rtbDadosNormas = new System.Windows.Forms.RichTextBox();
			this.m_lDadosNormas = new System.Windows.Forms.Label();
			this.m_lvNormas = new mdlComponentesGraficos.ListView();
			this.m_chImportador = new System.Windows.Forms.ColumnHeader();
			this.m_ttNormas = new System.Windows.Forms.ToolTip(this.components);
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
			this.m_ttNormas.SetToolTip(this.m_btTrocarCor, "Cor");
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
			this.m_ttNormas.SetToolTip(this.m_btOk, "Confirmar");
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
			this.m_ttNormas.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbInformacoes
			// 
			this.m_gbInformacoes.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_gbInformacoes.Controls.Add(this.m_rtbDadosNormas);
			this.m_gbInformacoes.Controls.Add(this.m_lDadosNormas);
			this.m_gbInformacoes.Controls.Add(this.m_lvNormas);
			this.m_gbInformacoes.Font = new System.Drawing.Font("Arial", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbInformacoes.Location = new System.Drawing.Point(8, 8);
			this.m_gbInformacoes.Name = "m_gbInformacoes";
			this.m_gbInformacoes.Size = new System.Drawing.Size(342, 311);
			this.m_gbInformacoes.TabIndex = 0;
			this.m_gbInformacoes.TabStop = false;
			// 
			// m_rtbDadosNormas
			// 
			this.m_rtbDadosNormas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_rtbDadosNormas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_rtbDadosNormas.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_rtbDadosNormas.Location = new System.Drawing.Point(8, 224);
			this.m_rtbDadosNormas.Name = "m_rtbDadosNormas";
			this.m_rtbDadosNormas.ReadOnly = true;
			this.m_rtbDadosNormas.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.m_rtbDadosNormas.Size = new System.Drawing.Size(326, 79);
			this.m_rtbDadosNormas.TabIndex = 7;
			this.m_rtbDadosNormas.Text = "";
			// 
			// m_lDadosNormas
			// 
			this.m_lDadosNormas.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_lDadosNormas.Font = new System.Drawing.Font("Arial", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lDadosNormas.Location = new System.Drawing.Point(6, 202);
			this.m_lDadosNormas.Name = "m_lDadosNormas";
			this.m_lDadosNormas.Size = new System.Drawing.Size(84, 18);
			this.m_lDadosNormas.TabIndex = 2;
			this.m_lDadosNormas.Text = "Descri��o:";
			// 
			// m_lvNormas
			// 
			this.m_lvNormas.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.m_lvNormas.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_lvNormas.CausesValidation = false;
			this.m_lvNormas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						 this.m_chImportador});
			this.m_lvNormas.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lvNormas.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lvNormas.HideSelection = false;
			this.m_lvNormas.Location = new System.Drawing.Point(8, 21);
			this.m_lvNormas.Name = "m_lvNormas";
			this.m_lvNormas.Size = new System.Drawing.Size(326, 179);
			this.m_lvNormas.TabIndex = 6;
			this.m_ttNormas.SetToolTip(this.m_lvNormas, "Selecionar Norma");
			this.m_lvNormas.View = System.Windows.Forms.View.Details;
			this.m_lvNormas.DoubleClick += new System.EventHandler(this.m_lvNormas_DoubleClick);
			this.m_lvNormas.Click += new System.EventHandler(this.m_lvNormas_Click);
			this.m_lvNormas.SelectedIndexChanged += new System.EventHandler(this.m_lvNormas_SelectedIndexChanged);
			// 
			// m_chImportador
			// 
			this.m_chImportador.Width = 300;
			// 
			// m_ttNormas
			// 
			this.m_ttNormas.AutomaticDelay = 100;
			this.m_ttNormas.AutoPopDelay = 5000;
			this.m_ttNormas.InitialDelay = 100;
			this.m_ttNormas.ReshowDelay = 20;
			// 
			// frmFNormas
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(366, 358);
			this.Controls.Add(this.m_gbFrame);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFNormas";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Normas";
			this.Load += new System.EventHandler(this.frmFNormas_Load);
			this.m_gbFrame.ResumeLayout(false);
			this.m_gbInformacoes.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Delegate
		// Delegate para BD
		public delegate void delCallCarregaDadosBD();
		public delegate void delCallCarregaDadosBDNormas(ref mdlComponentesGraficos.ListView lvNormas);
		public delegate void delCallCarregaDadosInterface(ref mdlComponentesGraficos.ListView lvNormas, ref System.Windows.Forms.Form frmNorma);
		public delegate void delCallCarregaDadosNormasInterface(ref System.Windows.Forms.RichTextBox rtbDadosNormas);
		public delegate void delCallChecaIntegridadeDados();
		public delegate void delCallSalvaDadosInterface();
		public delegate void delCallSalvaDadosBD(bool bModificado);
		#endregion
		#region Events
		// Eventos BD
		public event delCallCarregaDadosBD eCallCarregaDadosBD;
		public event delCallCarregaDadosBDNormas eCallCarregaDadosBDNormas;
		public event delCallCarregaDadosInterface eCallCarregaDadosInterface;
		public event delCallCarregaDadosNormasInterface eCallCarregaDadosNormasInterface;
		public event delCallChecaIntegridadeDados eCallChecaIntegridadeDados;
		public event delCallSalvaDadosInterface eCallSalvaDadosInterface;
		public event delCallSalvaDadosBD eCallSalvaDadosBD;
		#endregion
		#region Events Methods
		protected virtual void OnCallCarregaDadosBD()
		{
			if (eCallCarregaDadosBD != null)
				eCallCarregaDadosBD();
		}
		protected virtual void OnCallCarregaDadosBDNormas()
		{
			if (eCallCarregaDadosBDNormas != null)
				eCallCarregaDadosBDNormas(ref this.m_lvNormas);
		} 
		protected virtual void OnCallCarregaDadosNormasInterface()
		{
			if (eCallCarregaDadosNormasInterface != null)
				eCallCarregaDadosNormasInterface(ref this.m_rtbDadosNormas);
		}
		protected virtual void OnCallCarregaDadosInterface()
		{
			System.Windows.Forms.Form formNorma = (System.Windows.Forms.Form)this;
			if (eCallCarregaDadosInterface != null)
				eCallCarregaDadosInterface(ref this.m_lvNormas, ref formNorma);
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
						if ((this.Controls[cont].Controls[cont2].GetType().ToString() != "mdlComponentes.compTextBox") && (this.Controls[cont].Controls[cont2].GetType().ToString() != "mdlComponentes.compTextNumber"))
						{
							this.Controls[cont].Controls[cont2].BackColor = this.BackColor;
						}
						for (int cont3 = 0; cont3 < this.Controls[cont].Controls[cont2].Controls.Count; cont3++)
						{
							if ((this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.ListView") &&
								(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"System.Windows.Forms.RichTextBox") &&
								(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.ComboBox"))
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
				OnCallCarregaDadosNormasInterface();
				this.m_lvNormas.Focus();
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
				this.m_lvNormas.Focus();
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
		private void frmFNormas_Load(object sender, System.EventArgs e)
		{
			try 
			{
				this.mostraCor();
				OnCallCarregaDadosBD();
				OnCallCarregaDadosBDNormas();
				OnCallCarregaDadosInterface();
				OnCallCarregaDadosNormasInterface();
				this.m_lvNormas.Focus();
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
		#region List View Clique
		private void m_lvNormas_Click(object sender, System.EventArgs e)
		{
			if (m_bAtiva == true)
			{
				m_bAtiva = false;
				OnCallCarregaDadosBDNormas();
				OnCallCarregaDadosNormasInterface();
				m_bAtiva = true;
			}
		}
		#endregion
		#region SelectedIndexChanged
		private void m_lvNormas_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (m_lvNormas.SelectedItems.Count > 0)
				{
					if (m_lvNormas.SelectedItems[0].Index != m_nIndiceAnterior)
					{
						m_nIndiceAnterior = m_lvNormas.SelectedItems[0].Index;
						m_lvNormas_Click(sender, e);
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
		private void m_lvNormas_DoubleClick(object sender, System.EventArgs e)
		{
			try
			{
				m_lvNormas_Click(sender,e);
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