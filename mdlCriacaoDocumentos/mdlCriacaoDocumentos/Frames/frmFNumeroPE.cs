using System;
using System.Collections;

namespace mdlCriacaoDocumentos.Frames
{
	/// <summary>
	/// Summary description for frmFNumeroPE.
	/// </summary>
	internal class frmFNumeroPE : mdlComponentesGraficos.FormFlutuante
	{
		#region Atributos
		private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
		private string m_strEnderecoExecutavel = "";

		public bool m_bModificado = false;

		private System.Windows.Forms.GroupBox m_gbFrame;
		private System.Windows.Forms.Button m_btTrocarCor;
		private System.Windows.Forms.GroupBox m_gbFields;
		private System.Windows.Forms.Label m_lNumero;
		private System.Windows.Forms.ToolTip m_ttNumero;
		private System.Windows.Forms.Button m_btOk;
		private System.Windows.Forms.Button m_btCancelar;
		private mdlComponentesGraficos.TextBox m_tbNumero;
		private System.ComponentModel.IContainer components = null;
		#endregion

		#region Construtores & Destrutores
		public frmFNumeroPE(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, string enderecoExecutavel)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_cls_ter_tratadorErro = tratadorErro;
			m_strEnderecoExecutavel = enderecoExecutavel;
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
		public delegate void delCallCarregaDadosInterface(ref mdlComponentesGraficos.TextBox tbNumero, ref System.Windows.Forms.GroupBox gbFields);
		public delegate void delCallChecaIntegridadeDados();
		public delegate void delCallSalvaDadosInterface(ref mdlComponentesGraficos.TextBox tbNumero);
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
				eCallCarregaDadosInterface(ref this.m_tbNumero, ref this.m_gbFields);
		}
		protected virtual void OnCallChecaIntegridadeDados()
		{
			if (eCallChecaIntegridadeDados != null)
				eCallChecaIntegridadeDados();
		}

		protected virtual void OnCallSalvaDadosInterface()
		{
			if (eCallSalvaDadosInterface != null)
				eCallSalvaDadosInterface(ref this.m_tbNumero);
		} 

		protected virtual void OnCallSalvaDadosBD()
		{
			if (eCallSalvaDadosBD != null)
				eCallSalvaDadosBD(this.m_bModificado);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFNumeroPE));
			this.m_gbFrame = new System.Windows.Forms.GroupBox();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btTrocarCor = new System.Windows.Forms.Button();
			this.m_gbFields = new System.Windows.Forms.GroupBox();
			this.m_tbNumero = new mdlComponentesGraficos.TextBox();
			this.m_lNumero = new System.Windows.Forms.Label();
			this.m_ttNumero = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbFrame.SuspendLayout();
			this.m_gbFields.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbFrame
			// 
			this.m_gbFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFrame.Controls.Add(this.m_btCancelar);
			this.m_gbFrame.Controls.Add(this.m_btOk);
			this.m_gbFrame.Controls.Add(this.m_btTrocarCor);
			this.m_gbFrame.Controls.Add(this.m_gbFields);
			this.m_gbFrame.Location = new System.Drawing.Point(2, 0);
			this.m_gbFrame.Name = "m_gbFrame";
			this.m_gbFrame.Size = new System.Drawing.Size(246, 103);
			this.m_gbFrame.TabIndex = 0;
			this.m_gbFrame.TabStop = false;
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(127, 71);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 27);
			this.m_btCancelar.TabIndex = 3;
			this.m_ttNumero.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_btOk
			// 
			this.m_btOk.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(63, 71);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 27);
			this.m_btOk.TabIndex = 2;
			this.m_ttNumero.SetToolTip(this.m_btOk, "Confirmar");
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btTrocarCor
			// 
			this.m_btTrocarCor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.m_btTrocarCor.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_btTrocarCor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btTrocarCor.Location = new System.Drawing.Point(4, 9);
			this.m_btTrocarCor.Name = "m_btTrocarCor";
			this.m_btTrocarCor.Size = new System.Drawing.Size(4, 4);
			this.m_btTrocarCor.TabIndex = 4;
			this.m_ttNumero.SetToolTip(this.m_btTrocarCor, "Cor");
			this.m_btTrocarCor.Click += new System.EventHandler(this.m_btTrocarCor_Click);
			// 
			// m_gbFields
			// 
			this.m_gbFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFields.Controls.Add(this.m_tbNumero);
			this.m_gbFields.Controls.Add(this.m_lNumero);
			this.m_gbFields.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbFields.Location = new System.Drawing.Point(8, 8);
			this.m_gbFields.Name = "m_gbFields";
			this.m_gbFields.Size = new System.Drawing.Size(230, 58);
			this.m_gbFields.TabIndex = 0;
			this.m_gbFields.TabStop = false;
			this.m_gbFields.Text = "Edição do formato do número";
			// 
			// m_tbNumero
			// 
			this.m_tbNumero.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbNumero.Location = new System.Drawing.Point(65, 25);
			this.m_tbNumero.Name = "m_tbNumero";
			this.m_tbNumero.Size = new System.Drawing.Size(155, 20);
			this.m_tbNumero.TabIndex = 1;
			this.m_tbNumero.Text = "";
			this.m_tbNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// m_lNumero
			// 
			this.m_lNumero.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.m_lNumero.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lNumero.Location = new System.Drawing.Point(8, 27);
			this.m_lNumero.Name = "m_lNumero";
			this.m_lNumero.Size = new System.Drawing.Size(52, 16);
			this.m_lNumero.TabIndex = 0;
			this.m_lNumero.Text = "Número:";
			this.m_lNumero.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_ttNumero
			// 
			this.m_ttNumero.AutomaticDelay = 100;
			this.m_ttNumero.AutoPopDelay = 5000;
			this.m_ttNumero.InitialDelay = 100;
			this.m_ttNumero.ReshowDelay = 20;
			// 
			// frmFNumeroPE
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(250, 105);
			this.Controls.Add(this.m_gbFrame);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFNumeroPE";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Processo de Exportação (PE)";
			this.Load += new System.EventHandler(this.frmFNumero_Load);
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
						if ((this.Controls[cont].Controls[cont2].GetType().ToString() != "mdlComponentes.compTextBox") && (this.Controls[cont].Controls[cont2].GetType().ToString() != "mdlComponentes.compTextNumber"))
						{
							this.Controls[cont].Controls[cont2].BackColor = this.BackColor;
						}
						for (int cont3 = 0; cont3 < this.Controls[cont].Controls[cont2].Controls.Count; cont3++)
						{
							if ((this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"System.Windows.Forms.TextBox") &&
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
		#endregion

		#region Eventos
		#region Load
		private void frmFNumero_Load(object sender, System.EventArgs e)
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
		#region Ok
		private void m_btOk_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (m_tbNumero.Text.Trim() != "")
				{
					this.m_bModificado = true;
					OnCallSalvaDadosInterface();
					OnCallSalvaDadosBD();
					this.Close();
					this.Cursor = System.Windows.Forms.Cursors.Default;
				} 
				else 
				{
					this.Cursor = System.Windows.Forms.Cursors.Default;
					mdlMensagens.clsMensagens.ShowInformation(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlCriacaoDocumentos_frmFNumeroPE_NumeroInvalido));
					//MessageBox.Show("É necessário digitar um número.",this.Text);
				}				
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
