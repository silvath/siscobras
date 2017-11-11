using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlNumero.PEs
{
	/// <summary>
	/// Summary description for frmFNumeroSiscomex.
	/// </summary>
	internal class frmFNumeroSiscomex : mdlComponentesGraficos.FormFlutuante
	{
		#region Atributos
		private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
		private string m_strEnderecoExecutavel = "";

		internal bool m_bModificado = false;
		private bool m_bAtivado = true;

		private System.Windows.Forms.GroupBox m_gbFrame;
		internal System.Windows.Forms.Button m_btOk;
		internal System.Windows.Forms.Button m_btCancelar;
		internal System.Windows.Forms.Button m_btTrocarCor;
		private System.Windows.Forms.GroupBox m_gbFields;
		private mdlComponentesGraficos.TextBox m_tbRE;
		private mdlComponentesGraficos.TextBox m_tbSD;
		private System.Windows.Forms.Label m_lSD;
		private System.Windows.Forms.RadioButton m_rbRE;
		private System.Windows.Forms.RadioButton m_rbDSE;
		private mdlComponentesGraficos.TextBox m_tbDSE;
		private System.Windows.Forms.DateTimePicker m_dtpkRE;
		private System.Windows.Forms.DateTimePicker m_dtpkSD;
		private System.Windows.Forms.DateTimePicker m_dtpkDSE;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		#region Construtores & Destrutores
		public frmFNumeroSiscomex(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, string enderecoExecutavel)
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
		public delegate void delCallCarregaDadosInterface(ref System.Windows.Forms.RadioButton rbRE, ref mdlComponentesGraficos.TextBox tbRE, ref System.Windows.Forms.DateTimePicker dtpkRE, ref System.Windows.Forms.Label lSD, ref mdlComponentesGraficos.TextBox tbSD, ref System.Windows.Forms.DateTimePicker dtpkSD, ref System.Windows.Forms.RadioButton rbDSE, ref mdlComponentesGraficos.TextBox tbDSE, ref System.Windows.Forms.DateTimePicker dtpkDSE);
		public delegate void delCallSalvaDadosInterface(ref System.Windows.Forms.RadioButton rbRE, ref mdlComponentesGraficos.TextBox tbRE, ref System.Windows.Forms.DateTimePicker dtpkRE, ref System.Windows.Forms.Label lSD, ref mdlComponentesGraficos.TextBox tbSD, ref System.Windows.Forms.DateTimePicker dtpkSD, ref System.Windows.Forms.RadioButton rbDSE, ref mdlComponentesGraficos.TextBox tbDSE, ref System.Windows.Forms.DateTimePicker dtpkDSE);
		public delegate void delCallSalvaDadosBD();
		#endregion
		#region Events
		public event delCallCarregaDadosInterface eCallCarregaDadosInterface;
		public event delCallSalvaDadosInterface eCallSalvaDadosInterface;
		public event delCallSalvaDadosBD eCallSalvaDadosBD;
		#endregion
		#region Events Methods
		protected virtual void OnCallCarregaDadosInterface()
		{
			if (eCallCarregaDadosInterface != null)
				eCallCarregaDadosInterface(ref m_rbRE, ref m_tbRE, ref m_dtpkRE, ref m_lSD, ref m_tbSD, ref m_dtpkSD, ref m_rbDSE, ref m_tbDSE, ref m_dtpkDSE);
		}
		protected virtual void OnCallSalvaDadosInterface()
		{
			if (eCallSalvaDadosInterface != null)
				eCallSalvaDadosInterface(ref m_rbRE, ref m_tbRE, ref m_dtpkRE, ref m_lSD, ref m_tbSD, ref m_dtpkSD, ref m_rbDSE, ref m_tbDSE, ref m_dtpkDSE);
		}
		protected virtual void OnCallSalvaDadosBD()
		{
			if (eCallSalvaDadosBD != null)
				eCallSalvaDadosBD();
		}
		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFNumeroSiscomex));
			this.m_gbFrame = new System.Windows.Forms.GroupBox();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_btTrocarCor = new System.Windows.Forms.Button();
			this.m_gbFields = new System.Windows.Forms.GroupBox();
			this.m_dtpkDSE = new System.Windows.Forms.DateTimePicker();
			this.m_dtpkSD = new System.Windows.Forms.DateTimePicker();
			this.m_dtpkRE = new System.Windows.Forms.DateTimePicker();
			this.m_rbDSE = new System.Windows.Forms.RadioButton();
			this.m_tbDSE = new mdlComponentesGraficos.TextBox();
			this.m_rbRE = new System.Windows.Forms.RadioButton();
			this.m_tbSD = new mdlComponentesGraficos.TextBox();
			this.m_lSD = new System.Windows.Forms.Label();
			this.m_tbRE = new mdlComponentesGraficos.TextBox();
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
			this.m_gbFrame.Size = new System.Drawing.Size(270, 132);
			this.m_gbFrame.TabIndex = 2;
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
			this.m_btOk.Location = new System.Drawing.Point(75, 100);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 27);
			this.m_btOk.TabIndex = 1;
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
			this.m_btCancelar.Location = new System.Drawing.Point(139, 100);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 27);
			this.m_btCancelar.TabIndex = 2;
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
			this.m_btTrocarCor.Click += new System.EventHandler(this.m_btTrocarCor_Click);
			// 
			// m_gbFields
			// 
			this.m_gbFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFields.Controls.Add(this.m_dtpkDSE);
			this.m_gbFields.Controls.Add(this.m_dtpkSD);
			this.m_gbFields.Controls.Add(this.m_dtpkRE);
			this.m_gbFields.Controls.Add(this.m_rbDSE);
			this.m_gbFields.Controls.Add(this.m_tbDSE);
			this.m_gbFields.Controls.Add(this.m_rbRE);
			this.m_gbFields.Controls.Add(this.m_tbSD);
			this.m_gbFields.Controls.Add(this.m_lSD);
			this.m_gbFields.Controls.Add(this.m_tbRE);
			this.m_gbFields.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbFields.Location = new System.Drawing.Point(8, 8);
			this.m_gbFields.Name = "m_gbFields";
			this.m_gbFields.Size = new System.Drawing.Size(254, 87);
			this.m_gbFields.TabIndex = 0;
			this.m_gbFields.TabStop = false;
			// 
			// m_dtpkDSE
			// 
			this.m_dtpkDSE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_dtpkDSE.CustomFormat = "dd/MM/yyyy";
			this.m_dtpkDSE.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_dtpkDSE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.m_dtpkDSE.Location = new System.Drawing.Point(168, 59);
			this.m_dtpkDSE.Name = "m_dtpkDSE";
			this.m_dtpkDSE.Size = new System.Drawing.Size(80, 20);
			this.m_dtpkDSE.TabIndex = 8;
			// 
			// m_dtpkSD
			// 
			this.m_dtpkSD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_dtpkSD.CustomFormat = "dd/MM/yyyy";
			this.m_dtpkSD.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_dtpkSD.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.m_dtpkSD.Location = new System.Drawing.Point(168, 37);
			this.m_dtpkSD.Name = "m_dtpkSD";
			this.m_dtpkSD.Size = new System.Drawing.Size(80, 20);
			this.m_dtpkSD.TabIndex = 5;
			// 
			// m_dtpkRE
			// 
			this.m_dtpkRE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_dtpkRE.CustomFormat = "dd/MM/yyyy";
			this.m_dtpkRE.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_dtpkRE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.m_dtpkRE.Location = new System.Drawing.Point(168, 15);
			this.m_dtpkRE.Name = "m_dtpkRE";
			this.m_dtpkRE.Size = new System.Drawing.Size(80, 20);
			this.m_dtpkRE.TabIndex = 3;
			// 
			// m_rbDSE
			// 
			this.m_rbDSE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_rbDSE.CheckAlign = System.Drawing.ContentAlignment.BottomLeft;
			this.m_rbDSE.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_rbDSE.Location = new System.Drawing.Point(8, 62);
			this.m_rbDSE.Name = "m_rbDSE";
			this.m_rbDSE.Size = new System.Drawing.Size(51, 16);
			this.m_rbDSE.TabIndex = 6;
			this.m_rbDSE.Text = "DSE:";
			this.m_rbDSE.CheckedChanged += new System.EventHandler(this.m_rbDSE_CheckedChanged);
			// 
			// m_tbDSE
			// 
			this.m_tbDSE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_tbDSE.Enabled = false;
			this.m_tbDSE.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbDSE.Location = new System.Drawing.Point(65, 59);
			this.m_tbDSE.Mask = true;
			this.m_tbDSE.MaskAutomaticSpecialCharacters = true;
			this.m_tbDSE.MaskText = "NNNNNNNNNN/N";
			this.m_tbDSE.Name = "m_tbDSE";
			this.m_tbDSE.Size = new System.Drawing.Size(101, 20);
			this.m_tbDSE.TabIndex = 7;
			this.m_tbDSE.Text = "";
			this.m_tbDSE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// m_rbRE
			// 
			this.m_rbRE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_rbRE.CheckAlign = System.Drawing.ContentAlignment.BottomLeft;
			this.m_rbRE.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_rbRE.Location = new System.Drawing.Point(8, 15);
			this.m_rbRE.Name = "m_rbRE";
			this.m_rbRE.Size = new System.Drawing.Size(48, 16);
			this.m_rbRE.TabIndex = 1;
			this.m_rbRE.Text = "RE:";
			this.m_rbRE.CheckedChanged += new System.EventHandler(this.m_rbRE_CheckedChanged);
			// 
			// m_tbSD
			// 
			this.m_tbSD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_tbSD.Enabled = false;
			this.m_tbSD.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbSD.Location = new System.Drawing.Point(65, 37);
			this.m_tbSD.Mask = true;
			this.m_tbSD.MaskAutomaticSpecialCharacters = true;
			this.m_tbSD.MaskText = "NNNNNNNNNN/N";
			this.m_tbSD.Name = "m_tbSD";
			this.m_tbSD.Size = new System.Drawing.Size(101, 20);
			this.m_tbSD.TabIndex = 4;
			this.m_tbSD.Text = "";
			this.m_tbSD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// m_lSD
			// 
			this.m_lSD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_lSD.Enabled = false;
			this.m_lSD.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lSD.Location = new System.Drawing.Point(23, 37);
			this.m_lSD.Name = "m_lSD";
			this.m_lSD.Size = new System.Drawing.Size(25, 18);
			this.m_lSD.TabIndex = 0;
			this.m_lSD.Text = "SD:";
			this.m_lSD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_tbRE
			// 
			this.m_tbRE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_tbRE.Enabled = false;
			this.m_tbRE.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbRE.Location = new System.Drawing.Point(65, 15);
			this.m_tbRE.Mask = true;
			this.m_tbRE.MaskAutomaticSpecialCharacters = true;
			this.m_tbRE.MaskText = "NN/NNNNNNN-NNN";
			this.m_tbRE.Name = "m_tbRE";
			this.m_tbRE.Size = new System.Drawing.Size(101, 20);
			this.m_tbRE.TabIndex = 2;
			this.m_tbRE.Text = "";
			this.m_tbRE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// frmFNumeroSiscomex
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(274, 134);
			this.Controls.Add(this.m_gbFrame);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFNumeroSiscomex";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Siscomex";
			this.Load += new System.EventHandler(this.frmFNumeroSiscomex_Load);
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
		#endregion

		#region Eventos
		#region Load
		private void frmFNumeroSiscomex_Load(object sender, System.EventArgs e)
		{
			try
			{
				if (m_bAtivado)
				{
					m_bAtivado = false;
					this.mostraCor();
					OnCallCarregaDadosInterface();
					m_bAtivado = true;
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region RE Checked Changed
		private void m_rbRE_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (m_bAtivado)
				{
					m_bAtivado = false;
					OnCallSalvaDadosInterface();
					m_bAtivado = true;
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region DSE Checked Changed
		private void m_rbDSE_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (m_bAtivado)
				{
					m_bAtivado = false;
					OnCallSalvaDadosInterface();
					m_bAtivado = true;
				}
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
				if (m_bAtivado)
				{
					m_bAtivado = false;
					m_bModificado = true;
					OnCallSalvaDadosInterface();
					OnCallSalvaDadosBD();
					this.Close();
					m_bAtivado = true;
				}
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
				m_bModificado = false;
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
		#endregion
	}
}
