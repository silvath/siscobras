using System;
using System.Collections;
using System.Windows.Forms;

namespace mdlObservacoes
{
	/// <summary>
	/// Summary description for frmFObservacoes.
	/// </summary>
	internal class frmFObservacoes : mdlComponentesGraficos.FormFlutuante
	{
		#region Delegate
			// Delegate para BD
			public delegate void delCallCarregaDadosBD();
			public delegate void delCallCarregaDadosInterface(ref System.Windows.Forms.TextBox tbObservacoes, ref System.Windows.Forms.GroupBox gbFields);
			public delegate void delCallChecaIntegridadeDados();
			public delegate void delCallSalvaDadosInterface(ref System.Windows.Forms.TextBox tbObservacoes);
			public delegate void delCallSalvaDadosBD(bool modificado);
		#endregion
		#region Events
			// Events BD
			public event delCallCarregaDadosBD eCallCarregaDadosBD;
			public event delCallCarregaDadosInterface eCallCarregaDadosInterface;
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
	 
			protected virtual void OnCallCarregaDadosInterface()
			{
				if (eCallCarregaDadosInterface != null)
					eCallCarregaDadosInterface(ref this.m_tbObservacoes, ref this.m_gbFields);
			}
			protected virtual void OnCallChecaIntegridadeDados()
			{
				if (eCallChecaIntegridadeDados != null)
					eCallChecaIntegridadeDados();
			}

			protected virtual void OnCallSalvaDadosInterface()
			{
				if (eCallSalvaDadosInterface != null)
					eCallSalvaDadosInterface(ref this.m_tbObservacoes);
			} 

			protected virtual void OnCallSalvaDadosBD()
			{
				if (eCallSalvaDadosBD != null)
					eCallSalvaDadosBD(this.m_bModificado);
			}
		#endregion

		#region Atributos
		private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
		private string m_strEnderecoExecutavel = "";

		private bool m_bModificado = false;

		private bool m_bMostrarLabel = true;

		private System.Windows.Forms.GroupBox m_gbFrame;
		private System.Windows.Forms.Button m_btOk;
		private System.Windows.Forms.Button m_btCancelar;
		private System.Windows.Forms.Button m_btTrocarCor;
		private System.Windows.Forms.GroupBox m_gbFields;
		private System.Windows.Forms.TextBox m_tbObservacoes;
		private System.Windows.Forms.ToolTip m_ttObservacoes;
		private System.ComponentModel.IContainer components;
		#endregion
		#region Properties
			public bool Multiline
			{
				set
				{
					if (value)
					{
						if (!m_tbObservacoes.Multiline)
						{
							this.Size = new System.Drawing.Size(392,197);
							m_tbObservacoes.Multiline = true;
						}
					}else{
						if (m_tbObservacoes.Multiline)
						{
							this.Size = new System.Drawing.Size(392,128);
							m_tbObservacoes.Multiline = false;
						}
					}
				}
			}
		#endregion
		#region Construtors and Destrutors
			public frmFObservacoes(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, string EnderecoExecutavel, bool bMostrarLabel)
			{
				//
				// Required for Windows Form Designer support
				//
				InitializeComponent();
				m_cls_ter_tratadorErro = tratadorErro;
				m_strEnderecoExecutavel = EnderecoExecutavel;
				m_bMostrarLabel = bMostrarLabel;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFObservacoes));
			this.m_gbFrame = new System.Windows.Forms.GroupBox();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_btTrocarCor = new System.Windows.Forms.Button();
			this.m_gbFields = new System.Windows.Forms.GroupBox();
			this.m_tbObservacoes = new System.Windows.Forms.TextBox();
			this.m_ttObservacoes = new System.Windows.Forms.ToolTip(this.components);
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
			this.m_gbFrame.Size = new System.Drawing.Size(382, 163);
			this.m_gbFrame.TabIndex = 0;
			this.m_gbFrame.TabStop = false;
			// 
			// m_btOk
			// 
			this.m_btOk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(131, 131);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 27);
			this.m_btOk.TabIndex = 2;
			this.m_ttObservacoes.SetToolTip(this.m_btOk, "Confirmar");
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(195, 131);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 27);
			this.m_btCancelar.TabIndex = 3;
			this.m_ttObservacoes.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_btTrocarCor
			// 
			this.m_btTrocarCor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_btTrocarCor.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_btTrocarCor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btTrocarCor.Location = new System.Drawing.Point(4, 9);
			this.m_btTrocarCor.Name = "m_btTrocarCor";
			this.m_btTrocarCor.Size = new System.Drawing.Size(4, 4);
			this.m_btTrocarCor.TabIndex = 4;
			this.m_ttObservacoes.SetToolTip(this.m_btTrocarCor, "Cor");
			this.m_btTrocarCor.Click += new System.EventHandler(this.m_btTrocarCor_Click);
			// 
			// m_gbFields
			// 
			this.m_gbFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFields.Controls.Add(this.m_tbObservacoes);
			this.m_gbFields.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbFields.Location = new System.Drawing.Point(8, 8);
			this.m_gbFields.Name = "m_gbFields";
			this.m_gbFields.Size = new System.Drawing.Size(366, 118);
			this.m_gbFields.TabIndex = 0;
			this.m_gbFields.TabStop = false;
			// 
			// m_tbObservacoes
			// 
			this.m_tbObservacoes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_tbObservacoes.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbObservacoes.HideSelection = false;
			this.m_tbObservacoes.Location = new System.Drawing.Point(8, 17);
			this.m_tbObservacoes.Multiline = true;
			this.m_tbObservacoes.Name = "m_tbObservacoes";
			this.m_tbObservacoes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.m_tbObservacoes.Size = new System.Drawing.Size(352, 91);
			this.m_tbObservacoes.TabIndex = 1;
			this.m_tbObservacoes.Text = "";
			// 
			// m_ttObservacoes
			// 
			this.m_ttObservacoes.AutomaticDelay = 100;
			this.m_ttObservacoes.AutoPopDelay = 5000;
			this.m_ttObservacoes.InitialDelay = 100;
			this.m_ttObservacoes.ReshowDelay = 20;
			// 
			// frmFObservacoes
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(386, 165);
			this.Controls.Add(this.m_gbFrame);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFObservacoes";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Informações Complementares";
			this.Load += new System.EventHandler(this.frmFObservacoes_Load);
			this.m_gbFrame.ResumeLayout(false);
			this.m_gbFields.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Cores
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

		#region LabelInvisível
		private void escondeLabel()
		{
			try
			{
				m_tbObservacoes.SetBounds(8,m_tbObservacoes.Bounds.Y, m_gbFields.Bounds.Width - 16, m_tbObservacoes.Bounds.Height);
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
		#region Load
		private void frmFObservacoes_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.mostraCor();
				OnCallCarregaDadosInterface();
				if (!m_bMostrarLabel)
					escondeLabel();
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
			try
			{
				this.Close();
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
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				this.m_bModificado = true;
				OnCallSalvaDadosInterface();
				OnCallSalvaDadosBD();
				this.Close();
				this.Cursor = System.Windows.Forms.Cursors.Default;
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
