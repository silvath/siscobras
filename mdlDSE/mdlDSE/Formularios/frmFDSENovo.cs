using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlDSE.Formularios
{
	/// <summary>
	/// Summary description for frmFDSENovo.
	/// </summary>
	public class frmFDSENovo : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate bool delCallSalvaDados(string strNumero,System.DateTime dtEmissao);
			public delegate bool delCallSalvaDadosEditar(int nIdDSE,string strNumero,System.DateTime dtEmissao);
		#endregion
		#region Events
			public event delCallSalvaDados eCallSalvaDados;
			public event delCallSalvaDadosEditar eCallSalvaDadosEditar;
		#endregion
		#region Events Methods
			protected virtual bool OnCallSalvaDados()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				bool bRetorno = false;
				if (eCallSalvaDados != null)
					bRetorno = eCallSalvaDados(m_txtNumero.Text,m_dtpEmissao.Value);
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bRetorno);
			}

			protected virtual bool OnCallSalvaDadosEditar()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				bool bRetorno = false;
				if (eCallSalvaDadosEditar != null)
					bRetorno = eCallSalvaDadosEditar(m_nIdDSE,m_txtNumero.Text,m_dtpEmissao.Value);
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bRetorno);
			}
		#endregion

		#region Atributos
			private int m_nIdDSE = -1;
			private bool m_bModificado = false;

			private System.Windows.Forms.GroupBox m_gbMain;
			private System.Windows.Forms.GroupBox m_gbRE;
			private mdlComponentesGraficos.TextBox m_txtNumero;
			private System.Windows.Forms.Label m_lbNumero;
			internal System.Windows.Forms.Button m_btOk;
			internal System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.Label m_lbEmissao;
			private System.Windows.Forms.DateTimePicker m_dtpEmissao;
		#endregion
		private System.Windows.Forms.ToolTip m_ttDicas;
		private System.ComponentModel.IContainer components;
		#region Propriedades
			public bool Modificado
			{
				get
				{
					return(m_bModificado);
				}
			}

			public string Numero
			{
				set
				{
					m_txtNumero.Text = value;
				}
				get
				{
					return(m_txtNumero.Text);
				}
			}
				
			public System.DateTime Emissao
			{
				set
				{
					m_dtpEmissao.Value = value;
				}
				get
				{
					return(m_dtpEmissao.Value);
				}
			}
		#endregion
		#region Construtores
			public frmFDSENovo(string strEnderecoExecutavel,int nIdDSE)
			{
				m_nIdDSE = nIdDSE;
				InitializeComponent();
				vMostraCor(strEnderecoExecutavel);
			}

			public frmFDSENovo(string strEnderecoExecutavel)
			{
				InitializeComponent();
				vMostraCor(strEnderecoExecutavel);
			}

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFDSENovo));
			this.m_gbMain = new System.Windows.Forms.GroupBox();
			this.m_gbRE = new System.Windows.Forms.GroupBox();
			this.m_dtpEmissao = new System.Windows.Forms.DateTimePicker();
			this.m_lbEmissao = new System.Windows.Forms.Label();
			this.m_txtNumero = new mdlComponentesGraficos.TextBox();
			this.m_lbNumero = new System.Windows.Forms.Label();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_ttDicas = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbMain.SuspendLayout();
			this.m_gbRE.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbMain
			// 
			this.m_gbMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbMain.Controls.Add(this.m_gbRE);
			this.m_gbMain.Controls.Add(this.m_btOk);
			this.m_gbMain.Controls.Add(this.m_btCancelar);
			this.m_gbMain.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbMain.Location = new System.Drawing.Point(3, 0);
			this.m_gbMain.Name = "m_gbMain";
			this.m_gbMain.Size = new System.Drawing.Size(186, 111);
			this.m_gbMain.TabIndex = 1;
			this.m_gbMain.TabStop = false;
			// 
			// m_gbRE
			// 
			this.m_gbRE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbRE.Controls.Add(this.m_dtpEmissao);
			this.m_gbRE.Controls.Add(this.m_lbEmissao);
			this.m_gbRE.Controls.Add(this.m_txtNumero);
			this.m_gbRE.Controls.Add(this.m_lbNumero);
			this.m_gbRE.Location = new System.Drawing.Point(6, 6);
			this.m_gbRE.Name = "m_gbRE";
			this.m_gbRE.Size = new System.Drawing.Size(175, 74);
			this.m_gbRE.TabIndex = 1;
			this.m_gbRE.TabStop = false;
			// 
			// m_dtpEmissao
			// 
			this.m_dtpEmissao.CustomFormat = "dd/MM/yyyyy";
			this.m_dtpEmissao.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.m_dtpEmissao.Location = new System.Drawing.Point(63, 36);
			this.m_dtpEmissao.Name = "m_dtpEmissao";
			this.m_dtpEmissao.Size = new System.Drawing.Size(105, 20);
			this.m_dtpEmissao.TabIndex = 3;
			// 
			// m_lbEmissao
			// 
			this.m_lbEmissao.Location = new System.Drawing.Point(9, 40);
			this.m_lbEmissao.Name = "m_lbEmissao";
			this.m_lbEmissao.Size = new System.Drawing.Size(56, 16);
			this.m_lbEmissao.TabIndex = 2;
			this.m_lbEmissao.Text = "Emissão:";
			// 
			// m_txtNumero
			// 
			this.m_txtNumero.Location = new System.Drawing.Point(63, 13);
			this.m_txtNumero.Mask = true;
			this.m_txtNumero.MaskAutomaticSpecialCharacters = true;
			this.m_txtNumero.MaskText = "NNNNNNNNNN/N";
			this.m_txtNumero.Name = "m_txtNumero";
			this.m_txtNumero.Size = new System.Drawing.Size(105, 20);
			this.m_txtNumero.TabIndex = 1;
			this.m_txtNumero.Text = "";
			// 
			// m_lbNumero
			// 
			this.m_lbNumero.Location = new System.Drawing.Point(8, 16);
			this.m_lbNumero.Name = "m_lbNumero";
			this.m_lbNumero.Size = new System.Drawing.Size(56, 16);
			this.m_lbNumero.TabIndex = 0;
			this.m_lbNumero.Text = "Número:";
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(36, 82);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 14;
			this.m_ttDicas.SetToolTip(this.m_btOk, "Confirmar");
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(100, 82);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 15;
			this.m_ttDicas.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_ttDicas
			// 
			this.m_ttDicas.AutomaticDelay = 100;
			this.m_ttDicas.AutoPopDelay = 5000;
			this.m_ttDicas.InitialDelay = 100;
			this.m_ttDicas.ReshowDelay = 20;
			// 
			// frmFDSENovo
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(192, 111);
			this.Controls.Add(this.m_gbMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFDSENovo";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Novo DSE";
			this.m_gbMain.ResumeLayout(false);
			this.m_gbRE.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Botoes
				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					if (m_nIdDSE == -1)
					{
						if (OnCallSalvaDados())
						{
							m_bModificado = true;
							this.Close();
						}
					}else{
						if (OnCallSalvaDadosEditar())
						{
							m_bModificado = true;
							this.Close();
						}
					}
				}

				private void m_btCancelar_Click(object sender, System.EventArgs e)
				{
					m_bModificado = false;
					this.Close();
				}
			#endregion
		#endregion

		#region Cores
			private void vMostraCor(string strEnderecoExecutavel)
			{
				mdlPaletaDeCores.clsPaletaDeCores clsPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(strEnderecoExecutavel + "sisco.ini","SiscobrasCorSecundaria");
				this.BackColor = clsPaletaCores.retornaCorAtual();
				System.Windows.Forms.Control ctrControleChild;
				for (int nCont = 0 ;nCont < this.Controls.Count; nCont++)
				{
					ctrControleChild = this.Controls[nCont];
					vPaintControl(ref ctrControleChild,this.BackColor);
				}
			}

			private void vPaintControl(ref System.Windows.Forms.Control ctrControle,System.Drawing.Color clrBackColor)
			{
				switch(ctrControle.GetType().ToString())
				{
					case "mdlComponentesGraficos.ListView":
					case "System.Windows.Forms.ListView":
					case "mdlComponentesGraficos.ComboBox":
					case "mdlComponentesGraficos.TextBox":
						break;

					default:
						ctrControle.BackColor = clrBackColor;
						break;
				}
				System.Windows.Forms.Control ctrControleChild;
				for (int nCont = 0 ;nCont < ctrControle.Controls.Count; nCont++)
				{
					ctrControleChild = ctrControle.Controls[nCont];
					vPaintControl(ref ctrControleChild,clrBackColor);
				}
			}
		#endregion

	}
}
