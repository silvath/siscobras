using System;
using System.Collections;
using System.Windows.Forms;

namespace mdlDocumentacao.Frames
{
	/// <summary>
	/// Summary description for frmFBordero.
	/// </summary>
	internal class frmFBordero : mdlComponentesGraficos.FormFlutuante
	{
		#region Atributos
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
		protected string m_strEnderecoExecutavel;

		private bool m_bAtivado = true;
		private bool m_bModificado = false;
		private System.Windows.Forms.GroupBox m_gbFrame;
		private System.Windows.Forms.GroupBox m_gbFields;
		private System.Windows.Forms.Button m_btOk;
		private System.Windows.Forms.Button m_btCancelar;
		private System.Windows.Forms.Button m_btTrocarCor;
		private System.Windows.Forms.Label m_lIdentificar;
		private System.Windows.Forms.Label m_lFitoSanitario;
		private mdlComponentesGraficos.TextBox m_tbIdentificacaoCE;
		private mdlComponentesGraficos.TextBox m_tbIdentificacaoFC;
		private System.Windows.Forms.Label m_lFaturaComercial;
		private System.Windows.Forms.Label m_lQde;
		private mdlComponentesGraficos.TextBox m_tbQdeFC;
		private mdlComponentesGraficos.TextBox m_tbQdeCE;
		private System.Windows.Forms.ToolTip m_ttBordero;
		private System.ComponentModel.IContainer components;
		#endregion

		#region Construtores & Destrutores
		public frmFBordero(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, string EnderecoExecutavel)
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

		#region Delegate
		public delegate void delCallCarregaDadosInterface(ref mdlComponentesGraficos.TextBox tbFCIdentificacao, ref mdlComponentesGraficos.TextBox tbFCCopias, ref mdlComponentesGraficos.TextBox tbCEIdentificacao, ref mdlComponentesGraficos.TextBox tbCECopias);
		public delegate void delCallSalvaDadosInterface(ref mdlComponentesGraficos.TextBox tbFCCopias, ref mdlComponentesGraficos.TextBox tbCECopias);
		public delegate void delCallSalvaDadosBD(bool bModificado);
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
				eCallCarregaDadosInterface(ref m_tbIdentificacaoFC, ref m_tbQdeFC, ref m_tbIdentificacaoCE, ref m_tbQdeCE);
		}
		protected virtual void OnCallSalvaDadosInterface()
		{
			if (eCallSalvaDadosInterface != null)
				eCallSalvaDadosInterface(ref m_tbQdeFC, ref m_tbQdeCE);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFBordero));
			this.m_gbFrame = new System.Windows.Forms.GroupBox();
			this.m_btTrocarCor = new System.Windows.Forms.Button();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbFields = new System.Windows.Forms.GroupBox();
			this.m_tbQdeCE = new mdlComponentesGraficos.TextBox();
			this.m_tbQdeFC = new mdlComponentesGraficos.TextBox();
			this.m_tbIdentificacaoCE = new mdlComponentesGraficos.TextBox();
			this.m_lFitoSanitario = new System.Windows.Forms.Label();
			this.m_tbIdentificacaoFC = new mdlComponentesGraficos.TextBox();
			this.m_lFaturaComercial = new System.Windows.Forms.Label();
			this.m_lQde = new System.Windows.Forms.Label();
			this.m_lIdentificar = new System.Windows.Forms.Label();
			this.m_ttBordero = new System.Windows.Forms.ToolTip(this.components);
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
			this.m_gbFrame.Size = new System.Drawing.Size(398, 139);
			this.m_gbFrame.TabIndex = 0;
			this.m_gbFrame.TabStop = false;
			// 
			// m_btTrocarCor
			// 
			this.m_btTrocarCor.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_btTrocarCor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btTrocarCor.Location = new System.Drawing.Point(4, 10);
			this.m_btTrocarCor.Name = "m_btTrocarCor";
			this.m_btTrocarCor.Size = new System.Drawing.Size(4, 4);
			this.m_btTrocarCor.TabIndex = 3;
			this.m_ttBordero.SetToolTip(this.m_btTrocarCor, "Cor");
			this.m_btTrocarCor.Click += new System.EventHandler(this.m_btTrocarCor_Click);
			// 
			// m_btOk
			// 
			this.m_btOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(139, 108);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 1;
			this.m_ttBordero.SetToolTip(this.m_btOk, "Confirmar");
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
			this.m_btCancelar.Location = new System.Drawing.Point(203, 108);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 2;
			this.m_ttBordero.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbFields
			// 
			this.m_gbFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFields.Controls.Add(this.m_tbQdeCE);
			this.m_gbFields.Controls.Add(this.m_tbQdeFC);
			this.m_gbFields.Controls.Add(this.m_tbIdentificacaoCE);
			this.m_gbFields.Controls.Add(this.m_lFitoSanitario);
			this.m_gbFields.Controls.Add(this.m_tbIdentificacaoFC);
			this.m_gbFields.Controls.Add(this.m_lFaturaComercial);
			this.m_gbFields.Controls.Add(this.m_lQde);
			this.m_gbFields.Controls.Add(this.m_lIdentificar);
			this.m_gbFields.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbFields.Location = new System.Drawing.Point(8, 8);
			this.m_gbFields.Name = "m_gbFields";
			this.m_gbFields.Size = new System.Drawing.Size(382, 95);
			this.m_gbFields.TabIndex = 0;
			this.m_gbFields.TabStop = false;
			this.m_gbFields.Text = "Quantificar";
			// 
			// m_tbQdeCE
			// 
			this.m_tbQdeCE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_tbQdeCE.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbQdeCE.Location = new System.Drawing.Point(307, 61);
			this.m_tbQdeCE.Name = "m_tbQdeCE";
			this.m_tbQdeCE.OnlyNumbers = true;
			this.m_tbQdeCE.Size = new System.Drawing.Size(67, 21);
			this.m_tbQdeCE.TabIndex = 2;
			this.m_tbQdeCE.Text = "";
			this.m_tbQdeCE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.m_ttBordero.SetToolTip(this.m_tbQdeCE, "Digite a quantidade de cópias");
			// 
			// m_tbQdeFC
			// 
			this.m_tbQdeFC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_tbQdeFC.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbQdeFC.Location = new System.Drawing.Point(307, 37);
			this.m_tbQdeFC.Name = "m_tbQdeFC";
			this.m_tbQdeFC.OnlyNumbers = true;
			this.m_tbQdeFC.Size = new System.Drawing.Size(67, 21);
			this.m_tbQdeFC.TabIndex = 1;
			this.m_tbQdeFC.Text = "";
			this.m_tbQdeFC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.m_ttBordero.SetToolTip(this.m_tbQdeFC, "Digite a quantidade de cópias");
			// 
			// m_tbIdentificacaoCE
			// 
			this.m_tbIdentificacaoCE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_tbIdentificacaoCE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_tbIdentificacaoCE.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbIdentificacaoCE.Location = new System.Drawing.Point(178, 61);
			this.m_tbIdentificacaoCE.Name = "m_tbIdentificacaoCE";
			this.m_tbIdentificacaoCE.ReadOnly = true;
			this.m_tbIdentificacaoCE.Size = new System.Drawing.Size(125, 21);
			this.m_tbIdentificacaoCE.TabIndex = 0;
			this.m_tbIdentificacaoCE.Text = "";
			this.m_tbIdentificacaoCE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.m_tbIdentificacaoCE.Enter += new System.EventHandler(this.m_tbIdentificacaoCE_Enter);
			// 
			// m_lFitoSanitario
			// 
			this.m_lFitoSanitario.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lFitoSanitario.Location = new System.Drawing.Point(8, 64);
			this.m_lFitoSanitario.Name = "m_lFitoSanitario";
			this.m_lFitoSanitario.Size = new System.Drawing.Size(165, 16);
			this.m_lFitoSanitario.TabIndex = 0;
			this.m_lFitoSanitario.Text = "Conhecimento de Embarque:";
			this.m_lFitoSanitario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_tbIdentificacaoFC
			// 
			this.m_tbIdentificacaoFC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_tbIdentificacaoFC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_tbIdentificacaoFC.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbIdentificacaoFC.Location = new System.Drawing.Point(178, 37);
			this.m_tbIdentificacaoFC.Name = "m_tbIdentificacaoFC";
			this.m_tbIdentificacaoFC.ReadOnly = true;
			this.m_tbIdentificacaoFC.Size = new System.Drawing.Size(125, 21);
			this.m_tbIdentificacaoFC.TabIndex = 0;
			this.m_tbIdentificacaoFC.Text = "";
			this.m_tbIdentificacaoFC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.m_tbIdentificacaoFC.Enter += new System.EventHandler(this.m_tbIdentificacaoFC_Enter);
			// 
			// m_lFaturaComercial
			// 
			this.m_lFaturaComercial.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lFaturaComercial.Location = new System.Drawing.Point(8, 38);
			this.m_lFaturaComercial.Name = "m_lFaturaComercial";
			this.m_lFaturaComercial.Size = new System.Drawing.Size(103, 16);
			this.m_lFaturaComercial.TabIndex = 0;
			this.m_lFaturaComercial.Text = "Fatura Comercial:";
			this.m_lFaturaComercial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_lQde
			// 
			this.m_lQde.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_lQde.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lQde.Location = new System.Drawing.Point(312, 16);
			this.m_lQde.Name = "m_lQde";
			this.m_lQde.Size = new System.Drawing.Size(56, 16);
			this.m_lQde.TabIndex = 1;
			this.m_lQde.Text = "Cópias";
			this.m_lQde.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_lIdentificar
			// 
			this.m_lIdentificar.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lIdentificar.Location = new System.Drawing.Point(178, 18);
			this.m_lIdentificar.Name = "m_lIdentificar";
			this.m_lIdentificar.Size = new System.Drawing.Size(125, 16);
			this.m_lIdentificar.TabIndex = 0;
			this.m_lIdentificar.Text = "Identificação";
			this.m_lIdentificar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_ttBordero
			// 
			this.m_ttBordero.AutomaticDelay = 100;
			this.m_ttBordero.AutoPopDelay = 5000;
			this.m_ttBordero.InitialDelay = 100;
			this.m_ttBordero.ReshowDelay = 20;
			// 
			// frmFBordero
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(402, 141);
			this.Controls.Add(this.m_gbFrame);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFBordero";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Documentos";
			this.Load += new System.EventHandler(this.frmFBordero_Load);
			this.Activated += new System.EventHandler(this.frmFBordero_Activated);
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
								"mdlComponentesGraficos.TextBox") &&
								(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"System.Windows.Forms.DateTimePicker") ||
								(this.Controls[cont].Controls[cont2].Controls[cont3].Name == 
								"m_tbIdentificacaoFC") ||
								(this.Controls[cont].Controls[cont2].Controls[cont3].Name == 
								"m_tbIdentificacaoCE"))
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
		private void frmFBordero_Load(object sender, System.EventArgs e)
		{
			this.mostraCor();
			OnCallCarregaDadosInterface();
		}
		#endregion
		#region Cor
		private void m_btTrocarCor_Click(object sender, System.EventArgs e)
		{
			this.trocaCor();
		}
		#endregion
		#region Cancelar
		private void m_btCancelar_Click(object sender, System.EventArgs e)
		{
			m_bModificado = false;
			this.Close();
		}
		#endregion
		#region Ok
		private void m_btOk_Click(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			m_bModificado = true;
			OnCallSalvaDadosInterface();
			OnCallSalvaDadosBD();
			this.Close();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}
		#endregion
		#region Activated
		private void frmFBordero_Activated(object sender, System.EventArgs e)
		{
			m_tbQdeFC.Focus();
		}
		#endregion
		#region Enter
		private void m_tbIdentificacaoFC_Enter(object sender, System.EventArgs e)
		{
			m_tbQdeFC.Focus();
		}
		private void m_tbIdentificacaoCE_Enter(object sender, System.EventArgs e)
		{
			m_tbQdeCE.Focus();
		}
		#endregion
		#endregion
	}
}
